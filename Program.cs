using ReadCsvAssessment.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadCsvAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<AvailityModel>();
            var isCSVExists = File.Exists(@"TestCSV.csv");
            if (isCSVExists)
            {
                var reader = new StreamReader(File.OpenRead(@"TestCSV.csv"));
                var lineNumber = 0;
                while (!reader.EndOfStream)
                {                   
                    var line = reader.ReadLine();
                    if (lineNumber == 0)
                    {
                        lineNumber++;
                        continue; 
                    }

                    if (!string.IsNullOrWhiteSpace(line)) 
                    {
                        var values = line.Split(',');
                        if (values.Length >= 4)
                        {
                            data.Add(new AvailityModel
                            {
                                UserId = values[0],
                                FirstAndLastName = values[1],
                                Version = int.Parse(values[2]),
                                InsuranceCompany = values[3]
                            });                            
                        }
                    }
                }
                Console.WriteLine("Read CSV file successfully.");
                Console.ReadLine();
            }
        }
    }
}
