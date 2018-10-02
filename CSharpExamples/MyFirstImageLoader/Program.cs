using System;
using System.IO;
using System.Net;
using OpenCvSharp;

namespace MyFirstImageLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            LoadAndDisplayImage();
        }

        static void LoadAndDisplayImage()
        {
            string imagePath = string.Format("{0}\\images\\cat_dog.jpg", AppDomain.CurrentDomain.BaseDirectory);
            Mat colorImage = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat blackNwhiteImage = Cv2.ImRead(imagePath, ImreadModes.GrayScale);

            Cv2.ImShow("Color Image", colorImage);
            Cv2.ImShow("BW Image", blackNwhiteImage);
            Cv2.WaitKey(0);
        }

        static void DownloadImage(string imageUrl)
        {
            
        }
    }
}
