using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Polenter.Serialization;

namespace ImageSearchEngine
{
    class IndexImages
    {
        public static void Execute(string trainFolder)
        {
            List<ExtractedFeature> features = new List<ExtractedFeature>();
            var files = Directory.GetFiles(trainFolder);
            int count = 0;

            foreach (var imgPath in files)
            {
                if (count % 5 == 0)
                {
                    features.Add(ExtractFeatures(imgPath));
                }

                count++;
                Console.WriteLine(count);
            }

            SaveFeatures(features);
        }

        private static ExtractedFeature ExtractFeatures(string image)
        {
            Mat img = Cv2.ImRead(image);
            string category = Path.GetFileNameWithoutExtension(image).Split('.')[0];

            OpenCvSharp.AKAZE kaze = OpenCvSharp.AKAZE.Create();
            KeyPoint[] keyPoints;
            Mat desc = new Mat();

            kaze.DetectAndCompute(img, null, out keyPoints, desc);
            ExtractedFeature result = new ExtractedFeature()
            {
                ImgData = desc.ToBytes(),
                Cols = desc.Cols,
                Rows = desc.Rows,
                ImgType = desc.Type(),
                Category = category
            };

            return result;
        }

        private static void SaveFeatures(List<ExtractedFeature> features)
        {
            SharpSerializer serializer = new SharpSerializer(true);
            serializer.Serialize(features, "./features.bin");
        }

        public static List<ExtractedFeature> GetFeatures()
        {
            if(!File.Exists("./features.bin"))
            {
                throw new Exception("Features does not exists!");
            }

            SharpSerializer serializer = new SharpSerializer(true);
            var result = (List<ExtractedFeature>)serializer.Deserialize("./features.bin");

            return result;
        }
    }

    [Serializable]
    public class ExtractedFeature
    {
        public string Category { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public byte[] ImgData { get; set; }

        public int ImgType { get; set; }
    }
}
