using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using IRCModels;

class AsyncSocket : Socket
{
    public AsyncSocket(AddressFamily af, SocketType st, ProtocolType pt) : base(af, st, pt) { }

    public Task ConnectTaskAsync(EndPoint endPoint)
    {
        return Task.Factory.FromAsync(
            (cb, st) => BeginConnect(endPoint, cb, st),
            ias => EndConnect(ias),
            null);
    }

    public Task<int> ReceiveTaskAsync(Byte[] buffer)
    {
        return Task<int>.Factory.FromAsync(
            (cb, st) => BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, cb, st),
            ias => EndReceive(ias),
            null);
    }

    public Task SendTaskAsync(Byte[] buffer)
    {
        return Task.Factory.FromAsync(
            (cb, st) => BeginSend(buffer, 0, buffer.Length, SocketFlags.None, cb, st),
            ias => EndSend(ias),
            null);
    }
}

public class IRC
{
    List<String> ss = new List<string>();
    AsyncSocket s = null;

    public async Task<bool> Connect(string host)
    {
        IPHostEntry hostEntry = null;
        hostEntry = Dns.GetHostEntry(host);

        foreach (IPAddress address in hostEntry.AddressList)
        {
            IPEndPoint ipe = new IPEndPoint(address, 6667);
            AsyncSocket temp = new AsyncSocket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Unspecified);
            await temp.ConnectTaskAsync(ipe);

            if (temp.Connected)
            {
                s = temp;
                break;
            }
        }
        return s.Connected;
    }

    public async Task<Message> GetLine()
    {
        if (!s.Connected) 
            return null;
        String line;

        if (ss.Count > 1)
        {
            line = ss[0];
            Console.WriteLine("POPP");
            ss.RemoveAt(0);
            ss.RemoveAt(0);
            var msg = Message.ParseString(line);
            return msg;
        }

        int numbytes;
        String stream = "";
        do
        {
            Byte[] buf = new Byte[512];
            numbytes = await s.ReceiveTaskAsync(buf);
            if (numbytes == 0) return null;
            stream += Encoding.UTF8.GetString(buf, 0, numbytes);
        } while (numbytes == 512);
        List<String> streamsplit = new List<String>(stream.Split("\r\n".ToCharArray()));
        streamsplit.RemoveAt(streamsplit.Count - 1);
        ss.AddRange(streamsplit);
        return await GetLine();

    }
    public async Task Send(String str)
    {
        await s.SendTaskAsync(Encoding.UTF8.GetBytes(str));
    }
}
