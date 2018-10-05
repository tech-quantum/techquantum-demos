using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string folder = "";
            if(args.Length == 0)
            {
                Console.WriteLine("Use command train or predict along with path to folder as second args.");
            }

            if(args.Length == 1)
            {
                Console.WriteLine("Missing path as second argument");
            }

            command = args[0].ToLower();
            folder = args[1];
            DateTime start = DateTime.Now;

            switch (command)
            {
                case "train":
                    IndexImages.Execute(folder);
                    Console.WriteLine("Indexing completed.");
                    Console.WriteLine("Time taken (in Mins): " + (DateTime.Now - start).TotalMinutes);
                    Console.ReadLine();
                    break;
                case "predict":
                    string prediction = Predictor.Execute(folder);
                    Console.WriteLine("Prediction: " + prediction);
                    Console.WriteLine("Time taken (in sec): " + (DateTime.Now - start).TotalSeconds);
                    Console.ReadLine();
                    break;
                case "test":
                    int match = 0;
                    int total = 0;
                    PredictCategory(folder, "cat", ref match, ref total);
                    PredictCategory(folder, "dog", ref match, ref total);

                    Console.WriteLine("Accuracy score: " + (match == 0 ? 0 : (match * 100) / total));
                    Console.WriteLine("Time taken (in sec): " + (DateTime.Now - start).TotalSeconds);
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
            
        }

        private static void PredictCategory(string folder, string category, ref int match, ref int total)
        {
            var files = Directory.GetFiles(folder + "/" + category);
            foreach (var imgpath in files)
            {
                string prediction = Predictor.Execute(imgpath);
                if (prediction == category)
                {
                    match++;
                }

                total++;
            }
        }
    }
}
