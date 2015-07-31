using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ObservableDictionary<TKey, TValue> : INotifyPropertyChanged, INotifyCollectionChanged, IDictionary<TKey, TValue>, IList<TValue>
    {
        class Tuple<T1, T2>
        {
            public Tuple(T1 item1, T2 item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
            public T1 Item1 { get; set; }
            public T2 Item2 { get; set; }
        }
        private Dictionary<TKey, Tuple<int, TValue>> dict;
        private List<Tuple<TKey, TValue>> list;

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void NotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, args);
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public int Count
        {
            get { return list.Count; }
        }

        public ObservableDictionary()
        {
            dict = new Dictionary<TKey, Tuple<int, TValue>>();
            list = new List<Tuple<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value) // 1
        {
            dict.Add(key, new Tuple<int, TValue>(list.Count, value));
            list.Add(new Tuple<TKey, TValue>(key, value));
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            NotifyPropertyChanged("Count");
        }

        public void Insert(int index, TKey key, TValue value) // n
        {
            foreach (var t in dict)
            {
                if (t.Value.Item1 >= index)
                {
                    t.Value.Item1++;
                }
            }
            dict.Add(key, new Tuple<int, TValue>(index, value));
            list.Insert(index, new Tuple<TKey, TValue>(key, value));
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            NotifyPropertyChanged("Count");
        }

        public bool ContainsKey(TKey key) // 1
        {
            return dict.ContainsKey(key);
        }

        public bool Contains(TValue value) // n
        {
            return list.Any(t => t.Item2.Equals(value));
        }

        public bool Remove(TKey key) // n
        {
            if (!dict.ContainsKey(key)) return false;
            var t = dict[key];
            list.RemoveAt(t.Item1);
            dict.Remove(key);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, t.Item2));
            NotifyPropertyChanged("Count");
            return true;
        }

        public bool Remove(TValue value) // n
        {
            Tuple<TKey, TValue> t = null;
            int index = 0;
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Item2.Equals(value))
                {
                    t = list[i];
                    index = i;
                    break;
                }
            }
            if (t == null) return false;
            list.RemoveAt(index);
            dict.Remove(t.Item1);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, t.Item2));
            NotifyPropertyChanged("Count");
            return true;
        }

        public void RemoveAt(int index) // n
        {
            var t = list[index];
            dict.Remove(t.Item1);
            list.RemoveAt(index);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, t.Item2));
            NotifyPropertyChanged("Count");
        }

        public void Move(int oldIndex, int newIndex)
        {
            var t1 = list[oldIndex];
            foreach (var t in dict)
            {
                if (t.Value.Item1 >= newIndex)
                {
                    t.Value.Item1++;
                }
                if (t.Value.Item1 > oldIndex)
                {
                    t.Value.Item1--;
                }
            }
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, t1);
            dict[t1.Item1].Item1 = newIndex;
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, t1.Item2, newIndex, oldIndex));
        }

        public TValue this[TKey key]
        {
            get
            {
                return dict[key].Item2;
            }
            set
            {
                TValue replacedItem = default(TValue);
                var countChanged = false;
                var index = list.Count;
                if (dict.ContainsKey(key))
                {
                    index = dict[key].Item1;
                    replacedItem = dict[key].Item2;
                    list[index] = new Tuple<TKey, TValue>(key, value);
                }
                else
                {
                    countChanged = true;
                    list.Add(new Tuple<TKey, TValue>(key, value));
                }
                dict[key] = new Tuple<int,TValue>(index, value);
                if (countChanged)
                {
                    NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
                    NotifyPropertyChanged("Count");
                }
                else
                {
                    NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, replacedItem));
                }
            }
        }

        public TValue this[int index]
        {
            get
            {
                return list[index].Item2;
            }
        }

        TValue IList<TValue>.this[int index]
        {
            get { return default(TValue); }
            set { }
        }

        public int IndexOf(TValue value)
        {
            return list.FindIndex(t => t.Item2.Equals(value));
        }

        public int IndexOfKey(TKey key)
        {
            return dict[key].Item1;
        }

        public void Clear()
        {
            list.Clear();
            dict.Clear();
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            NotifyPropertyChanged("Count");
        }
        
        public IEnumerator<TValue> GetEnumerator()
        {
            return new ObservableDictionaryEnumerator(this);
        }

        #region explicit implementation

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { throw new NotImplementedException(); }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<TValue>.Add(TValue item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<TValue>.Contains(TValue item)
        {
            throw new NotImplementedException();
        }

        void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<TValue>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<TValue>.Remove(TValue item)
        {
            throw new NotImplementedException();
        }

        void IList<TValue>.Insert(int index, TValue item)
        {
            throw new NotImplementedException();
        }

        #endregion

        class ObservableDictionaryEnumerator : IEnumerator<TValue>
        {
            ObservableDictionary<TKey, TValue> observableDictionary;
            int index = -1;
            TValue current;
            public ObservableDictionaryEnumerator(ObservableDictionary<TKey, TValue> od)
            {
                observableDictionary = od;
            }

            public TValue Current
            {
                get { return current; }
            }

            public void Dispose() { }

            object System.Collections.IEnumerator.Current
            {
                get { return current; }
            }

            public bool MoveNext()
            {
                index++;
                if (index == observableDictionary.Count) return false;
                current = observableDictionary[index];
                return true;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
