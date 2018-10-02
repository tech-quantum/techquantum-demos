using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace ImageSearchEngine
{
    class Predictor
    {
        public static string Execute(string imagePath)
        {
            var img = Cv2.ImRead(imagePath);
            List<string> result = new List<string>();
            List<KeyValuePair<string, double>> featureScores = new List<KeyValuePair<string, double>>();
            var features = IndexImages.GetFeatures();
            OpenCvSharp.AKAZE kaze = OpenCvSharp.AKAZE.Create();
            KeyPoint[] keyPoints;
            Mat desc = new Mat();
            kaze.DetectAndCompute(img, null, out keyPoints, desc);
            
            foreach (var feature in features)
            {
                var train = new Mat(feature.Rows, feature.Cols, feature.ImgType, feature.ImgData);
                var matches = GetMatches(desc, train);
                var score = GetScore(matches);
                if (score == double.MaxValue)
                    continue;

                featureScores.Add(new KeyValuePair<string, double>(feature.Category, score));
            }

            return featureScores.Count > 0 ? featureScores.OrderBy(x => (x.Value)).ToList()[0].Key : "Unknown";
        }

        private static DMatch[][] GetMatches(Mat query, Mat train)
        {
            BFMatcher matcher = new BFMatcher();
            var matches = matcher.KnnMatch(query, train, k: 2);
            
            return matches;
        }

        private static double GetScore(DMatch[][] matches)
        {
            double score = double.MaxValue;
            List<DMatch> goodMatches = new List<DMatch>();
            List<double> scores = new List<double>();
            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i].Length < 2)
                    continue;

                if (float.IsNaN(matches[i][0].Distance))
                    continue;

                double s = matches[i][0].Distance / matches[i][1].Distance;
                
                if (matches[i][0].Distance < 0.85 * matches[i][1].Distance)
                {
                    goodMatches.Add(matches[i][0]);
                    
                }
            }

            if (goodMatches.Count <= 10)
                return score;

            score = goodMatches.Average(x => (x.Distance));
            
            return score;
        }
    }
}
