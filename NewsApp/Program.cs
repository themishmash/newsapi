using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using System.Net;
using Figgle;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace NewsApp
{
    class Program
    {
        static void Main(string[] args)
        {

            processUserOptions();

           
        }

        public enum UserOptions
        {
            AusHeadlines,
            Exit
        }

        public static int processUserOptions()
        {


            Console.WriteLine(FiggleFonts.Standard.Render("Get the news"));

            while (true)
            {

                
                    Console.WriteLine("----------");
                    Console.WriteLine("What would you like to read today?");
                    Console.WriteLine("1. Australian News Headlines");
                    Console.WriteLine("2. Exit");
                    Console.WriteLine("----------");
                    string userInput = Console.ReadLine();

                    int number;
                    if (!Int32.TryParse(userInput, out number))
                    {
                        Console.WriteLine("Please enter number");

                    }


                    //Console.WriteLine("----------");
                    //this was parsing again
                    //UserOptions userOption = (UserOptions)Convert.ToInt32(number) - 1;
                    UserOptions userOption = (UserOptions)(number) - 1;

                    switch (userOption)
                    {
                        case UserOptions.AusHeadlines:
                            Console.WriteLine("The news is...");
                            string newsJSON = WebJSON.MakeRequestToUrl(WebJSON.GenerateURLToHeadlines());

                            //Console.WriteLine(newsJSON);

                            RootObject headlines = JsonConvert.DeserializeObject<RootObject>(newsJSON);

                            Article[] fiveArticles = WebJSON.headlines().Take(5).ToArray();


                            //have to use for loop so can control how many items to iterate over
                            for (int i = 0; i < fiveArticles.Length; i++)

                            {
                                Console.WriteLine($"{i + 1}:{fiveArticles[i].title}");
                                //var firstFiveItems = 

                            }

                            //WebJSON.userSelectArticle();

                            int userInputNum = WebJSON.userSelectArticle();

                            if (userInputNum == 1)
                            {
                                Console.WriteLine(fiveArticles[0].description);
                                Console.WriteLine($"Find out more here: {fiveArticles[0].url}");
                            }
                            else if (userInputNum == 2)
                            {
                                Console.WriteLine(fiveArticles[1].description);
                                Console.WriteLine($"Find out more here: {fiveArticles[1].url}");


                            }

                            else if (userInputNum == 3)
                            {
                                Console.WriteLine(fiveArticles[2].description);
                                Console.WriteLine($"Find out more here: {fiveArticles[2].url}");
                            }

                            else if (userInputNum == 4)
                            {
                                Console.WriteLine(fiveArticles[3].description);
                                Console.WriteLine($"Find out more here: {fiveArticles[3].url}");
                            }

                            else if (userInputNum == 5)
                            {
                                Console.WriteLine(fiveArticles[4].description);
                                Console.WriteLine($"Find out more here: {fiveArticles[4].url}");
                            }

                            Console.WriteLine("----------");

                            break;


                        case UserOptions.Exit:
                            Console.WriteLine(FiggleFonts.Standard.Render("Goodbye"));
                            return 0;

                    }
                }
            }
        }
    }
