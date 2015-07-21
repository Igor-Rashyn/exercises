using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{

    class Program
    {
        static TcpListener tcpListener; // ожидаем подключения TCP клиентов
        static Thread listenThread; // созлдаем поток
        static List<TcpClient> clients = new List<TcpClient>(); // список клиентских подключений
        static List<NetworkStream> netStreams = new List<NetworkStream>(); // список потока данных. Класс NetworkStream обеспечивает методы для передачи и приема данных через сокеты Stream в блокирующем режиме

        static void Main(string[] args)
        {
           try
           {
               Console.WriteLine("Server Started...");
               tcpListener = new TcpListener(IPAddress.Any, 1000); // создаем прослушку. Слушаем любой IP адрес но с портом 1000
               listenThread = new Thread(new ThreadStart(ListenThread)); //  При создании управляемого потока, выполняемый в потоке метод представлен делегатом ThreadStart или делегатом ParameterizedThreadStart, передаваемым конструктору Thread. Поток не начинает выполняться до вызова метода Thread.Start. Выполнение начинается с первой строки метода, представленного делегатом ThreadStart или ParameterizedThreadStart.
               listenThread.Start(); // запускаем поток
           }
           catch
           {
               Disconnect();
           }
        }
        /// <summary>
        /// Метод начинающий прослушку порта 1000
        /// </summary>
    static void ListenThread()
        {
            tcpListener.Start(); // запускаем прослушку
        while (true)
        {
            clients.Add(tcpListener.AcceptTcpClient()); // подключение пользователя
            netStreams.Add(clients[clients.Count - 1].GetStream()); //обьект для получения данных

            Thread clientThread = new Thread(new ParameterizedThreadStart(ClientRecieve));
            clientThread.Start(clients.Count-1);// запускаем поток передаем ид клиента
        }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">Ид клиента</param>
        static void ClientRecieve(object ID)
        {
            int thisID = (int)ID;
 
            byte[] recieve = new byte[64];
 
            while (true)
            {
                try
                {
                    netStreams[thisID].Read(recieve, 0, 64);// разбиваю строку на байты и запихиваем в масив, масив будет содержать только 64 значения и всегда будет читать с начала.
                }
                catch
                {
                    Console.WriteLine("Client with ID: " + thisID + " has Disconnected!");
                    break;
                }
                Console.WriteLine(thisID + " message:" + Encoding.ASCII.GetString(recieve));


                SendMessageToClients(recieve, thisID);

                // данное обнулление необходимо, что бы обработать остульную часть строки, если строка большое 64 символов
                for (int i = 0; i < 64; i++)
                {

                    recieve[i] = 0;
                }
            }
        }
 
        /// <summary>
        /// Отправляем сообщение всем пользователя
        /// </summary>
        /// <param name="toSend"></param>
        static void SendMessageToClients(byte[] toSend, int Id)
        {
            for (int i = 0; i < netStreams.Count; i++)
            {
                if (Id !=i) // добивл исключение, которые убирает пользователя который написал сообщение
                {
                    netStreams[i].Write(toSend, 0, 64); //передача данных
                    netStreams[i].Flush(); //удаление данных с потока
                }
            }
        }
 
        static void Disconnect()
        {
            tcpListener.Stop(); //остановка чтения
 
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
                netStreams[i].Close(); //отключение потока
            }
            Environment.Exit(0); //завершение процесса
        }
    }

    }


