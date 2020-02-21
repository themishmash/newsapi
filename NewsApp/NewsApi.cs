using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace NewsApp
{
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }




    class WebJSON
    {

        public static string GenerateURLToHeadlines()
        {
            return $"http://newsapi.org/v2/top-headlines?country=au&apiKey={Keys.apiKey}";
        }

        public static List <Article> headlines()
        {

            
            string ausHeadlines = WebJSON.MakeRequestToUrl(WebJSON.GenerateURLToHeadlines());

           

            RootObject APIResults = JsonConvert.DeserializeObject<RootObject>(ausHeadlines);
            //Console.WriteLine("----------");

            //Console.WriteLine($"Our first article title is: {APIResults.articles[0].title}");

            //Console.WriteLine("----------");


            //return APIResults.articles[0].title;

            return APIResults.articles;
        }

        public static int userSelectArticle()
        {

            while (true)
            {
                Console.WriteLine("----------");
                Console.WriteLine("Which article would you like more info about?");
                Console.WriteLine("----------");
                string userNum = Console.ReadLine();

                int number;
                if (Int32.TryParse(userNum, out number))
                {
                    return number;
                }
                Console.WriteLine("Please enter number");
            }
                
        }


        public static string MakeRequestToUrl(string urlToVisit) 
        {
            HttpClient client = new HttpClient();

            var clientResponse = client.GetAsync(urlToVisit).Result;

            return clientResponse.Content.ReadAsStringAsync().Result;
        }


    }

}
