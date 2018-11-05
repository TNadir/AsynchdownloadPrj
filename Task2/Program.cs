using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            //Task Parallel Library
            RunParallelAsync();
            Console.ReadLine();
        }

        private static void DownloadWebsite(string url)
        {
            WebClient client = new WebClient();
            Console.WriteLine(url+"-"+client.DownloadString(url).Length); 
        }

        public static async void RunParallelAsync()
        {
            List<string> websites = new List<string>();
            websites.Add("https://www.yahoo.com");
            websites.Add("https://www.google.com");
            websites.Add("https://www.microsoft.com");
            websites.Add("https://www.cnn.com");
            websites.Add("https://www.amazon.com");
            websites.Add("https://www.facebook.com");
            websites.Add("https://www.twitter.com");
            websites.Add("https://www.codeproject.com");
            websites.Add("https://www.stackoverflow.com");
            websites.Add("https://en.wikipedia.org/wiki/.NET_Framework");
            await Task.Run(() =>
            {
                Parallel.ForEach(websites, DownloadWebsite);
            });
        }
    }
}
