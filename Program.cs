using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchingAndSorting
{
    internal class Program
    {
       
       
            static void Main(string[] args)
            {
                string filePath = @"C:\Users\priscilla glory\Desktop\PP3\SearchingAndSorting\SearchingAndSorting\Student_Data.txt";

                
                if (File.Exists(filePath))
                {
                    
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length == 0)
                    {
                        Console.WriteLine("Error: The file is empty.");
                        return;
                    }

                    
                    Console.WriteLine("Original Student Data:");
                    Console.WriteLine("Name\t\t\tClass");
                    foreach (var line in lines)
                    {
                        var entry = line.Split(',');
                        if (entry.Length >= 2)
                        {
                            Console.WriteLine($"{entry[0],-30}{entry[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format for a student entry.");
                        }
                    }

                    
                    var sortedData = lines
                        .Select(line => line.Split(','))
                        .OrderBy(data => data[0])
                        .ToList();

                    
                    Console.WriteLine("\nSorted Student Data:");
                    Console.WriteLine("Name\t\t\tClass");
                    foreach (var entry in sortedData)
                    {
                        if (entry.Length >= 2)
                        {
                            Console.WriteLine($"{entry[0],-30}{entry[1]}");
                        }
                    }

                    
                    Console.Write("\nEnter student name to search: ");
                    string searchName = Console.ReadLine();
                    SearchAndDisplayStudent(sortedData, searchName);
                }
                else
                {
                    Console.WriteLine("Error: The file does not exist.");
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }

            static void SearchAndDisplayStudent(IEnumerable<string[]> data, string searchName)
            {
                
                var result = data.FirstOrDefault(entry =>
                    entry[0].IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0);

                if (result != null)
                {
                    Console.WriteLine($"\nStudent found: {result[0]}, Class: {result[1]}");
                }
                else
                {
                    Console.WriteLine($"\nStudent '{searchName}' not found.");
                }
            }
        }
    }

