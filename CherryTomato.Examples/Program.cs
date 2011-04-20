﻿using System;
using System.Configuration;
using CherryTomato.Entities;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace CherryTomato.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            //A Tomato is the main object that will allow you to access RottenTomatoes information. 
            //Be sure to provide it with your API key in String format.
            var tomato = new Tomato(apiKey);

            //Example 1: Finding a movie by it's RottenTomatoes internal ID number.
            Movie movie = tomato.FindMovieById(9818);

            //The Movie object, contains all sorts of goodies you might want to know about a movie.
            Console.WriteLine(movie.Title);
            Console.WriteLine(movie.Year);



            //Example 2: Finding a movie by it's name. 
            string searchTerm = "Gone With The Wind";
            var results = tomato.FindMovieByQuery(searchTerm);
            
            Console.WriteLine("Searching with query: [" + searchTerm + "]");
            Console.WriteLine("Found {0} results.", results.ResultCount);
            foreach (var result in results)
            {
                Console.WriteLine("ID: {0} \n Title: {1} \n Runtime: {2}\n", result.RottenTomatoesId, result.Title, result.Runtime);
            }

            //Normally, the first result will be the one you're looking for.
            

            Console.ReadKey();
        }
    }
}
