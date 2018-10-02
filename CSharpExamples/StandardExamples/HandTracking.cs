using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace StandardExamples
{
    class HandTracking
    {
        static FrameSource frameSource;

        public static void Run()
        {
            Mat image = new Mat();
            frameSource = Cv2.CreateFrameSource_Camera(0);
            while (true)
            {
                //Grab the current frame
                frameSource.NextFrame(image);

                Mat gray = new Mat();
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

                Mat blur = new Mat();
                Cv2.GaussianBlur(gray, blur, new Size(19, 19), 0);

                Mat threshImg = new Mat();
                double thresh = Cv2.Threshold(gray, threshImg, 150, 255, ThresholdTypes.Otsu);

                Mat[] contours;

                Mat hierarchy = new Mat();
                Cv2.FindContours(threshImg, out contours, hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
                double maxArea = 100;
                Mat handContour = new Mat();
                handContour = contours.OrderByDescending(x => (x.ContourArea())).ToList()[0];
                //foreach (var item in contours)
                //{
                //    if(item.ContourArea() > maxArea)
                //    {
                //        handContour = item;
                //        break;
                //    }
                //}

                Mat hull = new Mat();
                Cv2.ConvexHull(handContour, hull);

                Mat defects = new Mat();
                Cv2.ConvexityDefects(handContour, hull, defects);

                Cv2.ImShow("frame", hull);
                //Cv2.WaitKey(0);
                if (Cv2.WaitKey(1) == (int)ConsoleKey.Enter)
                    break;
            }
        }
    }
}
