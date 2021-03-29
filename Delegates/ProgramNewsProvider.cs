using System;
using System.Collections.Generic;

namespace CSharp
{
    //задание - создать делегат для события EconomicNewsCreated с 2мя параметрами - текст и время, подписаться на это событие

    class NewsProvider
    {
        public delegate void CreateNews();

        public delegate void CreateNewsWithText(string text);

        public event CreateNews SportNewCreated;
        public event CreateNewsWithText MusicNewsCreated;
        public event CreateNews EconomicNewsCreated;

        public void OnSportNewsCreated()
        {
            SportNewCreated();
        }

        public void OnMusicNewsCreated()
        {
            MusicNewsCreated(DateTime.Now.ToShortTimeString());
        }

    }

    class NewsSubscriber
    {
        private string name;
        public NewsSubscriber(string name)
        {
            this.name = name;
        }

        public void SportNewHandler()
        {
            Console.WriteLine("Sport news was received");
            Console.WriteLine($"Subscriber = {name}");
        }

        public void MusicNewsHandler(string text)
        {
            Console.WriteLine($"music news - {text}, Subscriber = {name}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewsProvider tass = new NewsProvider();

            NewsSubscriber tutby = new NewsSubscriber("tut");
            NewsSubscriber ont = new NewsSubscriber("ont");
            NewsSubscriber bt = new NewsSubscriber("bt");


            tass.SportNewCreated += tutby.SportNewHandler;

            tass.MusicNewsCreated += ont.MusicNewsHandler;
            tass.MusicNewsCreated += bt.MusicNewsHandler;

            tass.OnSportNewsCreated();
            tass.OnMusicNewsCreated();

            Console.ReadLine();


        }
    }
}
