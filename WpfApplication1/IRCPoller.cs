using IRCModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1;
    
public class IRCPoller
{
    IRC irc;
    bool running = false;

    public IRCPoller(IRC irc)
    {
        this.irc = irc;
    }

    public async Task Run()
    {
        while(running)
        {
            var msg = await irc.GetLine();
            Console.WriteLine(msg);
            OnMessageAdded(msg);
            await Handle(msg);
        }
    }

    public void Start()
    {
        running = true;
        Task.Run(async () => await Run());
    }

    public void Stop()
    {
        running = false;
    }

    async Task Handle(Message msg)
    {
        switch (msg.Command)
        {
            case ("PING"):
                await irc.Send("PONG " + msg.Trail + "/r/n");
                break;
        }
    }

    public delegate void MessageAdded(Message msg);
    public MessageAdded OnMessageAdded;
}

