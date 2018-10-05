<Query Kind="Statements">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
</Query>

var image = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\pokemon.png");
Mat gray = new Mat();
Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);


Mat dst = new Mat();
InputArray kernel = InputArray.Create(new Scalar(5,5 ));

//Transformation using Top Hat technique
Cv2.MorphologyEx(gray, dst, MorphTypes.TopHat ,kernel);
Cv2.ImShow("TopHat", dst);


//Transformation using Erode techinque
Cv2.MorphologyEx(gray, dst, MorphTypes.Erode, kernel);
Cv2.ImShow("Erode", dst);

//Transformation using Gradient techinque
Cv2.MorphologyEx(gray, dst, MorphTypes.Gradient, kernel);
Cv2.ImShow("Gradient", dst);

//Transformation using Dilate techinque
Cv2.MorphologyEx(gray, dst, MorphTypes.Dilate, kernel);
Cv2.ImShow("Dilate", dst);