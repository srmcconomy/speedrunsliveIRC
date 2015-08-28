using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace TemplateSelectors
{
    class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IncomingMessageTemplate { get; set; }
        public DataTemplate OutgoingMessageTemplate { get; set; }

        public DataTemplate NoticeMessageTemplate { get; set; }
        public DataTemplate JoinMessageTemplate { get; set; }
        public DataTemplate PartMessageTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var viewModel = (MessageViewModel)item;
            if (viewModel.Message.Command == "PART") return PartMessageTemplate;
            if (viewModel.Message.Command == "JOIN") return JoinMessageTemplate;
            if (viewModel.Message.Command == "NOTICE") return NoticeMessageTemplate;
            if (viewModel.Message.Command == "PRIVMSG") return IncomingMessageTemplate;
            return OutgoingMessageTemplate;
        }
    }
}
