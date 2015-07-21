using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        static string usr;
        static TcpClient client;
        static NetworkStream netStream;

        static void Main(string[] args)
        {
            Console.Write("User name: ");
            usr = Console.ReadLine();
            //Console.Write("IP: ");
            //string ip = Console.ReadLine();
            //Console.Write("Port: ");
            //int port = Convert.ToInt32(Console.ReadLine());
            Connect("127.0.0.1", 1000);
        }

        static void Connect(string ip, int port)
        {
          //  IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), port); //IP с номером порта
            client = new TcpClient(); //подключение клиента
            try
            {
                client.Connect("127.0.0.1", 1000);
                netStream = client.GetStream();
                Thread receiveThread = new Thread(new ParameterizedThreadStart(ReceiveData));//получение данных
                receiveThread.Start();//старт потока
                Console.WriteLine("Connected!");

            }
            catch
            {
                Connect(ip, port);
            }
            SendMessage();
        }

        static void SendMessage()
        {
            Console.WriteLine("-----------------------------------");
            while (true)
            {
                try
                {
                    string message = usr + ": " + Console.ReadLine();
                    byte[] toSend = new byte[64];
                    toSend = Encoding.ASCII.GetBytes(message); // разбиваем сообщение на байты
                    netStream.Write(toSend, 0, toSend.Length); // пишем в поток
                    netStream.Flush(); //удаление данных из потока


                    // обнуляем массив
                    for (int i = 0; i < message.Length; i++)
                    {
                        toSend[i] = 0;
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }
        }

        static void ReceiveData(object e)
        {
            byte[] receiveMessage = new byte[64];

            while (true)
            {
                try
                {
                    netStream.Read(receiveMessage, 0, 64);//чтение сообщения
                }
                catch
                {
                    Console.WriteLine("The connection to the server was interrupted!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }

                string message = Encoding.ASCII.GetString(receiveMessage); // переводим сообщение в текст
                Console.WriteLine(message);//вывод сообщения
            }
        }


        static void Disconnect()
        {
            client.Close();//отключение клиента
            netStream.Close();//отключение потока
            Environment.Exit(0); //завершение процесса
        }
    }
}
