using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using SharpCompress.Readers.Tar;
using SharpCompress.Common.Tar;
using SharpCompress.Readers;
using SharpCompress.Common;
using OpenCvSharp;
using System.Runtime.InteropServices;
using Microsoft.Azure.CognitiveServices.Search.ImageSearch;

namespace ImageSearchEngine
{
    class PrepareDataset
    {
        static int MaxCount = 25;

        static string BING_KEY = "f17f2df005c64a769464ffd0083b1186";
        static string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/images/search";

        public static void DownloadImages(string[] categories)
        {
            foreach (var category in categories)
            {
                var client = new ImageSearchAPI(new ApiKeyServiceClientCredentials(BING_KEY));
                var imageResults = client.Images.SearchAsync(query: category, count: MaxCount).Result;
                foreach (var item in imageResults.Value)
                {
                    DownloadPhoto(category, item.ContentUrl);
                }
            }
        }

        private static void DownloadPhoto(string category, string url)
        {
            try
            {
                WebClient client = new WebClient();
                string folder = "./dataset/" + category;
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                client.DownloadFile(url, folder + "\\" + Guid.NewGuid().ToString() + ".jpg");
            }
            catch
            {

            }
        }
    }
}
