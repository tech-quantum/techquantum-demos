using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tesseract;

namespace StandardExamples
{
    class BusinessCardDemo
    {
        private static string EMAIL_PATTERN = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        private static string PHONE_PATTERN = @"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})";
        private static string NAME_PATTERN = @"www.([\w]+\.){1}([\w]+\.?)+";

        public static void Run()
        {
            string imagePath = AppDomain.CurrentDomain.BaseDirectory + @"\images\businesscard.jpg";
            Console.WriteLine("Raw Text --------------------------------------------------------");
            string rawText = GetText(imagePath);
            
            Regex websiteRegEx = new Regex(NAME_PATTERN, RegexOptions.IgnoreCase);
            Regex emailRegEx = new Regex(EMAIL_PATTERN, RegexOptions.IgnoreCase);
            Regex phoneRegEx = new Regex(PHONE_PATTERN, RegexOptions.IgnoreCase);

            Console.WriteLine("Contact info ------------------------------------------------------------");
            var urlMatch = websiteRegEx.Match(rawText);
            if(urlMatch.Success)
            {
                Console.WriteLine("Website:" + urlMatch.Value);
            }

            
            var emailMatch = emailRegEx.Match(rawText);
            if (emailMatch.Success)
            {
                Console.WriteLine("Email:" + emailMatch.Value);
            }

            var phoneMatch = phoneRegEx.Match(rawText);
            if (phoneMatch.Success)
            {
                Console.WriteLine("Phone:" + phoneMatch.Value);
            }
            
        }

        private static string DownloadAndExtractLanguagePack()
        {
            //Source path to the zip file
            string langPackPath = "https://github.com/tesseract-ocr/tessdata/archive/3.04.00.zip";


            string zipFileName = AppDomain.CurrentDomain.BaseDirectory + "\\tessdata.zip";
            string tessDataFolder = AppDomain.CurrentDomain.BaseDirectory + "\\tessdata"; ;

            //Check and download the source file
            if (!File.Exists(zipFileName))
            {
                WebClient client = new WebClient();
                client.DownloadFile(langPackPath, zipFileName);
            }

            //Extract the zip to tessdata folder
            if (string.IsNullOrWhiteSpace(tessDataFolder))
            {
                ZipFile.ExtractToDirectory(zipFileName, AppDomain.CurrentDomain.BaseDirectory);
                var extractedDir = Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory).FirstOrDefault(x => (x.Contains("tessdata")));
                Directory.Move(extractedDir, tessDataFolder);
            }

            return tessDataFolder;
        }

        private static string GetText(string imagePath)
        {
            string tessDataFolder = DownloadAndExtractLanguagePack();
            string result = "";
            using (var engine = new TesseractEngine(tessDataFolder, "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    var page = engine.Process(img.ConvertRGBToGray());
                    
                    result = page.GetText();
                    Console.WriteLine(result);
                }
            }

            return result;
        }

        private static string GetTextCV2(string imagePath)
        {
            Mat img = Cv2.ImRead(imagePath);

            string tessDataPath = DownloadAndExtractLanguagePack();
            string result = "";
            OpenCvSharp.Rect[] textLocations = null;
            string[] componentTexts = null;
            float[] confidences = null;

            using (var engine = OpenCvSharp.Text.OCRTesseract.Create(tessDataPath, "eng"))
            {
                engine.Run(img, out result, out textLocations, out componentTexts, out confidences, OpenCvSharp.Text.ComponentLevels.TextLine);
            }

            Console.WriteLine(result);

            return result;
        }
    }
    
}
