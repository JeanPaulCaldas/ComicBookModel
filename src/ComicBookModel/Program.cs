﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookModel.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    var artistRoleNames = comicBook.Artists
                        .Select(x => $"{x.Artist.Name} - {x.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }
                Console.ReadLine();
            }
        }
    }
}
