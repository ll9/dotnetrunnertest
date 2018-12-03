using Microsoft.EntityFrameworkCore;
using NsSqliteServer.Data;
using NsSqliteServer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NsSqliteHelper
{
    class Program
    {
        private static Random _rand = new Random();
        //private static ApplicationDbContext _context = new ApplicationDbContext();

        static void Main(string[] args)
        {

            using (var context = new ApplicationDbContext())
            {
                context.Lichtpunkt.Add(new Lichtpunkt());
                context.SaveChanges();
            }
            //Insert10();
            //foreach (var lp in _context.Lichtpunkt)
            //{
            //    Console.WriteLine(lp);
            //}
        }

        private static void Insert10()
        {
            var range = Enumerable.Range(0, 10)
                .Select(i => GetRandomLichtpunkt());

            //_context.Lichtpunkt.Add(range.First());
            //_context.SaveChanges();
        }

        private static Lichtpunkt GetRandomLichtpunkt()
        {
            const int minLon = 10;
            const int maxLon = 18;
            const int minLat = 40;
            const int maxLat = 60;
            var orte = new[] { "Prien", "Bernau", "Bad Endorf", "Rosenheim", "München" };
            var straßen = new[] { "Lessingstraße", "Jensenstraße", "Seestraße", "Jensenstraße", "Nussbaumstraße" };


            return new Lichtpunkt
            {

                Latitude = _rand.Next(minLat * 100, maxLat * 100) / 100.0,
                Longitude = _rand.Next(minLon * 100, maxLon * 100) / 100.0,
                Ort = orte[_rand.Next(orte.Length)],
                Straße = straßen[_rand.Next(straßen.Length)]
            };
        }
    }
}
