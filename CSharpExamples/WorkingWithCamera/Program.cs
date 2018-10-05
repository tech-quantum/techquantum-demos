using System;

namespace WorkingWithCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            //CameraModule cameraModule = new CameraModule();
            //try
            //{
            //    cameraModule.Init();
            //    var capturedImage = cameraModule.Capture(save: true);
            //    var manipulatedImage = cameraModule.Manipulate(capturedImage);
            //    cameraModule.ShowImage(capturedImage);
            //    cameraModule.ShowImage(manipulatedImage);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Oops something happened! {0}", ex.Message);
            //}
            //finally
            //{
            //    cameraModule.Release();
            //}

            FaceFeatureDetection faceFeatureDetection = new FaceFeatureDetection();
            faceFeatureDetection.Init();
            faceFeatureDetection.DetectFeatures();
            faceFeatureDetection.Release();
        }
    }
}
