using WebSocketSharp;
using WebSocketSharp.Server;

namespace csharp_server
{

    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Message recived: " + e.Data);
            Send(e.Data);
        }
    }

    public class EchoAll : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Message recived echo all: " + e.Data);
            Sessions.Broadcast(e.Data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wssv = new WebSocketServer("ws://192.168.1.5:8431");
            wssv.AddWebSocketService<Echo>("/Echo");
            wssv.AddWebSocketService<EchoAll>("/EchoAll");
            wssv.Start();
            Console.WriteLine("server is listening on ws://192.168.1.5:8431/Echo");
            Console.WriteLine("server is listening on ws://192.168.1.5:8431/EchoAll");
            Console.ReadKey();
            wssv.Stop();
        }
    }
}