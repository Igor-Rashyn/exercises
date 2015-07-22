using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_TTT
{
    class Server
    {
        List<Player> players = new List<Player>();
        List<Challenge> challenges = new List<Challenge>();
        List<Playroom> playrooms = new List<Playroom>();
        HttpListener listener;
        public void Start(string prefixes)
        {
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            listener = new HttpListener();
            listener.Prefixes.Add(prefixes);

            listener.Start();
            Console.WriteLine("Listening...");

            Thread threadListener = new Thread(new ThreadStart(Listener));
            threadListener.Start();         
        }

        public void Request(object listenerContext)
        {
                var context = (HttpListenerContext)listenerContext;
                HttpListenerRequest request = context.Request;
            
                switch (request.QueryString["Command"])
                {
                    case "New":
                        {
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            if (pl == null)
                            {
                                players.Add(new Player(request.QueryString["name"]) { DateOfLastVisit = DateTime.Now });
                                Response(context, "RefreshPlayers", ConvertPlayersToHtml());
                                if (players.Count==1)
                                {
                                    Thread threadListener = new Thread(new ThreadStart(DeleteOfflinePlayer));
                                    threadListener.Start();   
                                }
                            }
                            else
                            {
                                Response(context, "RefreshPlayers", "FALSE");
                            }
                        }
                        break;
                    case "Update":
                        {
                           Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                           pl.DateOfLastVisit = DateTime.Now;
                           Response(context, "RefreshPlayers", ConvertPlayersToHtml());
                        }
                        break;
                    case "Challenge":
                        {
                            challenges.Add(new Challenge()
                            {
                                First = players.Find(x => x.Name == request.QueryString["Name"]),
                                Second = players.Find(x => x.Name == request.QueryString["NameEnemy"]),
                                Status = 1
                            });
                            Response(context, "Challenge", " ");
                        }
                        break;
                    case "CheckChallenge":
                        {
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            pl.DateOfLastVisit = DateTime.Now;
                            Challenge result = challenges.Find(x => (x.Second == players.Find(y => y.Name == request.QueryString["Name"]) && x.Status!=5));
                            Challenge answer = challenges.Find(x => (x.First == players.Find(y => y.Name == request.QueryString["Name"]) && x.Status != 5));
                            if (result != null)
                            {
                                if (result.Status == 1)
                                {
                                    Response(context, "CheckChallenge", Convert.ToString(result.Status));
                                    result.Status = 4;
                                    playrooms.Add(new Playroom ()
                                    { 
                                       Second=result.Second,
                                       First=result.First,
                                       Status=1
                                    });
                                }
                            }
                            else if (answer != null)
                            {
                                if (answer.Status == 2 || answer.Status == 3)
                                {
                                    Player pl1 = players.Find(y => y.Name == request.QueryString["Name"]);
                                    pl1.Playing = true;
                                    Playroom pr = playrooms.Find(item => item.First == pl1);
                                    pr.Status = 2;
                                    Response(context, "CheckChallenge", Convert.ToString(answer.Status));
                                    answer.Status = 5;
                                }
                            }
                            else
                            {
                                Response(context, "CheckChallenge", "0");
                            }
                        }
                        break;
                    case "ResponseToChallenge":
                        {
                            Challenge result = challenges.Find(x => x.Second == players.Find(y => y.Name == request.QueryString["Name"]));
                            if (request.QueryString["Response"] == "YES")
                            {
                                result.Status = 2;
                                Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                                pl.Playing = true;
                            }
                            else if (request.QueryString["Response"] == "NO")
                            {
                                result.Status = 3;
                            }
                            Response(context, "ResponseToChallenge", "TRUE");   
                        }
                        break;
                    #region GAME
                    case "Step":
                        {
                            if (request.QueryString["First"] == "TRUE")
                            {
                                Playroom pr = playrooms.Find(room => room.First == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status==2);
                                pr.FirstPlayerStep = request.QueryString["Step"];
                            }
                            else
                            {
                                Playroom pr = playrooms.Find(room => room.Second == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status == 2);
                                pr.SecondPlayerStep = request.QueryString["Step"];
                            }
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            pl.DateOfLastVisit = DateTime.Now;
                            Response(context, "Step", "EMPTY");
                        }
                        break;

                    case "checkStep":
                        {
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            pl.DateOfLastVisit = DateTime.Now;
                            Playroom pl1 = playrooms.Find(room => room.First == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status==2);
                            Playroom pl2 = playrooms.Find(room => room.Second == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status == 2);
                            if (pl1 != null || pl2 != null)
                            {
                                if (request.QueryString["First"] == "TRUE")
                                {
                                    Response(context, "checkStep", pl1.SecondPlayerStep);
                                }
                                else
                                {
                                    Response(context, "checkStep", pl2.FirstPlayerStep);
                                }
                            }
                        }
                        break;
                    case "Continue":
                        {
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            pl.DateOfLastVisit = DateTime.Now;
                            Playroom pl1 = playrooms.Find(room => room.First == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status == 2);
                            Playroom pl2 = playrooms.Find(room => room.Second == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status == 2);
                            if (pl1 != null)
                            {
                                pl1.ContinueFirst = request.QueryString["Response"]=="NO"?2:1;
                                if (pl1.ContinueFirst == 2)
                                {
                                    Player player1 = players.Find(item => item.Name == request.QueryString["Name"]);
                                    player1.Playing = false;
                                }
                            }
                            else if (pl2 != null)
                            {
                                pl2.ContinueSecond = request.QueryString["Response"]=="NO"?2:1;

                                if (pl2.ContinueSecond == 2)
                                {
                                    Player player2 = players.Find(item => item.Name == request.QueryString["Name"]);
                                    player2.Playing = false;
                                }
                            }
                            Response(context, "Continue", "EMPTY");
                        }
                    break;
                    case "checkContinue":
                        {
                            Player pl = players.Find(y => y.Name == request.QueryString["Name"]);
                            pl.DateOfLastVisit = DateTime.Now;
                            Playroom pl1 = playrooms.Find(room => room.First == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status != 5);
                            Playroom pl2 = playrooms.Find(room => room.Second == players.Find(y => y.Name == request.QueryString["Name"]) && room.Status != 5);
                            string result = " ";
                            if (pl1 != null)
                            {
                                result = pl1.ContinueSecond != 0 ? (pl1.ContinueSecond == 2 ? "NO" : "YES") : "EMPTY";
                                if (result=="YES")
                                {
                                    pl1.FirstPlayerStep = "EMPTY";
                                    pl1.SecondPlayerStep = "EMPTY";
                                    pl1.Status = 2;
                                }
                                else if (result=="NO")
                                {
                                    pl1.Status = 5;
                                    Player player1 = players.Find(y => y.Name == pl1.First.Name);
                                    player1.Playing=false;
                                    Player player2 = players.Find(y => y.Name == pl1.Second.Name);
                                    player2.Playing = false;

                                }
                                
                            }
                            else if (pl2 != null)
                            {
                                result = pl2.ContinueFirst != 0 ? (pl2.ContinueFirst == 2 ? "NO" : "YES") : "EMPTY";
                                if (result == "YES")
                                {
                                    pl2.FirstPlayerStep = "EMPTY";
                                    pl2.SecondPlayerStep = "EMPTY";
                                    pl2.Status = 2;
                                }
                                else if (result == "NO")
                                {
                                    pl2.Status = 5;
                                    Player player1 = players.Find(y => y.Name == pl2.First.Name);
                                    player1.Playing = false;
                                    Player player2 = players.Find(y => y.Name == pl2.Second.Name);
                                    player2.Playing = false;
                                }
                            }
                            Response(context, "checkContinue", result);
                        }
                    break;
                    #endregion
                }
       }


        public void Response(HttpListenerContext context, string command, string data)
        {
            System.IO.Stream output = context.Response.OutputStream;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            switch (command)
            {
                case "RefreshPlayers":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "Challenge":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "CheckChallenge":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "ResponseToChallenge":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("TRUE");
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "Step":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "checkStep":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                break;
                case "Continue":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                        context.Response.ContentLength64 = buffer.Length;
                        output.Write(buffer, 0, buffer.Length);
                    }
                break;
                case "checkContinue":
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                    context.Response.ContentLength64 = buffer.Length;
                    output.Write(buffer, 0, buffer.Length);
                }
                break;

            }
            context.Response.Close();

        }

        public void Listener()
        {
            // Note: The GetContext method blocks while waiting for a request. 

            while (listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(Request, context);
                    //Thread threadListener = new Thread(() => Request(context));
                   // threadListener.Start();    
                   // Request(context);
                }
                catch
                {
                    Dispose();
                }

            }
        }
        public void Dispose()
        {
            listener.Stop();

        }
        private string ConvertPlayersToHtml()
        {
            string str = "";
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Playing == false)
                    str = str + "<tr>" + players[i].WriteToHtml(players[i]) + "</tr>";
            }

            return str;
        }
        private void DeleteOfflinePlayer ()
        {
            while (true)
            {
                if (players != null)
                {
                   // playrooms = playrooms.Where(item => item.Status != 3).ToList();
                    challenges = challenges.Where(item => item.Status != 5).ToList();
                    players = players.Where(p => (( DateTime.Now.Minute - p.DateOfLastVisit.Minute) * 60 + (p.DateOfLastVisit.Second - DateTime.Now.Second)) < 30).ToList();
                   // players.RemoveAll(item => (( DateTime.Now.Minute - item.DateOfLastVisit.Minute) * 60 + (item.DateOfLastVisit.Second - DateTime.Now.Second)) > 30);
                }
                Thread.Sleep(TimeSpan.FromSeconds(480));
            }
        }
    }
}
