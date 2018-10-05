<Query Kind="Statements">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
</Query>

//Load Image
var image = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");

//Convert to gray
Mat gray = new Mat();
Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

//Threshold the image
Mat thresholdImage = new Mat();
Cv2.Threshold(gray, thresholdImage, 128, 255, ThresholdTypes.Binary);
Cv2.ImShow("Thresold", thresholdImage);

//Run Open and Close morphological transformation
Cv2.MorphologyEx(thresholdImage, thresholdImage, MorphTypes.Open, InputArray.Create(new Scalar(5,5)));
Cv2.MorphologyEx(thresholdImage, thresholdImage, MorphTypes.Close, InputArray.Create(new Scalar(5,5)));

//Threshold the image again
Cv2.Threshold(thresholdImage, thresholdImage, 128, 255, ThresholdTypes.BinaryInv);
Cv2.ImShow("Morph", thresholdImage);

//Find contours
Mat[] contours = null;
Mat hierarcy = new Mat();
Cv2.FindContours(thresholdImage, out contours, hierarcy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

//Draw contours
Scalar greenColor = new Scalar(0,255,0);

Cv2.DrawContours(image, contours, -1, greenColor, 2);
Cv2.ImShow("image", image);