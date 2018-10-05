using ComputerVisionApi.Model;
using OpenCvSharp;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ComputerVisionApi.Module
{
    class FaceFeatureDetection
    {
        CascadeClassifier face_cascade;
        CascadeClassifier eyes_cascade;

        public List<FaceFeature> DetectFeatures(string imageUrl)
        {
            List<FaceFeature> features = new List<FaceFeature>();

            face_cascade = new CascadeClassifier("./haarcascades/haarcascade_frontalface_default.xml");
            eyes_cascade = new CascadeClassifier("./haarcascades/haarcascade_eye.xml");
            //Grab image from url
            Mat image = GetImageFromUrl(imageUrl);
            if (image.Empty())
            {
                throw new System.Exception("Invalid image url");
            }

            //Convert to gray scale to improve the image processing
            Mat gray = ConvertGrayScale(image);

            //Detect faces using Cascase classifier
            Rect[] faces = DetectFaces(gray);

            //Loop through detected faces
            foreach (var item in faces)
            {
                //Get the region of interest where you can find facial features
                Mat face_roi = gray[item];

                //Detect eyes
                Rect[] eyes = DetectEyes(face_roi);

                //Record the facial features in a list
                features.Add(new FaceFeature()
                {
                    Face = item,
                    Eyes = eyes
                });
            }

            return features;
        }

        private Mat GetImageFromUrl(string url)
        {
            //Use web client to download the image as bytes
            WebClient client = new WebClient();
            byte[] imgBytes = client.DownloadData(url);

            //Convert the image byte data to Open CV Mat object
            Mat image = Cv2.ImDecode(imgBytes, ImreadModes.Color);
            return image;
        }

        private Mat ConvertGrayScale(Mat image)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            return gray;
        }

        private Rect[] DetectFaces(Mat image)
        {
            Rect[] faces = face_cascade.DetectMultiScale(image, 1.3, 5);
            return faces;
        }

        private Rect[] DetectEyes(Mat image)
        {
            Rect[] eyes = eyes_cascade.DetectMultiScale(image, 1.3, 5);
            return eyes;
        }
    }
}
