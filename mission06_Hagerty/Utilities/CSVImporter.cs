using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using mission06_Hagerty.Models;

namespace mission06_Hagerty.Utilities
{
    public class CSVImporter
    {
        public static void ImportMovies(AppDbContext context, string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var movies = new List<Movie>();

                if (csv.Read())
                {
                    csv.ReadHeader();
                }
                else
                {
                    Console.WriteLine("CSV file is empty. Skipping import.");
                    return;
                }

                while (csv.Read())
                {
                    string yearString = csv.GetField<string>("Year");

                    // Extract the first year from a range (e.g., "2001-2002" → "2001")
                    int parsedYear = 0;
                    if (!string.IsNullOrEmpty(yearString))
                    {
                        string firstYear = yearString.Split('-')[0]; // Take first part before '-'
                        if (!int.TryParse(firstYear, out parsedYear))
                        {
                            Console.WriteLine($"Skipping movie with invalid year: {yearString}");
                            continue; // Skip this row if year is invalid
                        }
                    }

                    var movie = new Movie
                    {
                        Title = csv.GetField<string>("Title"),
                        CategoryId = csv.GetField<int>("CategoryId"),
                        Year = parsedYear, // Now safely converted
                        Director = csv.GetField<string>("Director"),
                        Rating = csv.GetField<string>("Rating"),
                        Edited = csv.TryGetField<bool?>("Edited", out var edited) ? edited : null,
                        LentTo = csv.GetField<string>("LentTo"),
                        Notes = csv.GetField<string>("Notes")
                    };

                    movies.Add(movie);
                }

                if (movies.Count > 0)
                {
                    context.Movies.AddRange(movies);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported {movies.Count} movies from CSV.");
                }
                else
                {
                    Console.WriteLine("No valid movie records found in CSV.");
                }
            }
        }
    }
}