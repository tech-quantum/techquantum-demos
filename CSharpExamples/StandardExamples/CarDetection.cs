using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace StandardExamples
{
    class CarDetection
    {
        public static void Run()
        {
            string imagePath = "./images/geo.jpg";
            Mat img = Cv2.ImRead(imagePath);
            SimpleBlobDetector.Params blobDetectorParams = new SimpleBlobDetector.Params();
            blobDetectorParams.MinThreshold = 10;
            blobDetectorParams.MaxThreshold = 100;
            FlannBasedMatcher matcher = new FlannBasedMatcher(null, null);
            blobDetectorParams.FilterByArea = true;
            blobDetectorParams.MinArea = 150;

            blobDetectorParams.FilterByCircularity = true;
            blobDetectorParams.MinCircularity = 0.3f;

            blobDetectorParams.FilterByConvexity = true;
            blobDetectorParams.MinConvexity = 0.2f;

            blobDetectorParams.FilterByInertia = true;
            blobDetectorParams.MinInertiaRatio = 0.1f;

            var detector = SimpleBlobDetector.Create(blobDetectorParams);
            var keypoints = detector.Detect(img);
            Mat output = new Mat();
            Cv2.DrawKeypoints(img, keypoints, output, new Scalar(0, 0, 255), DrawMatchesFlags.DrawRichKeypoints);

            Cv2.ImShow("Output", output);
            Cv2.WaitKey(0);

        }
    }
}
