<Query Kind="Program">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
</Query>

void Main()
{
	Mat orgimage = Cv2.ImRead(@"C:\git\ComputerVision\LinqPadExamples\images\cat.jpeg");
	
	Cv2.ImShow("orgimage", orgimage);
	Mat edgePreserveImage = new Mat();
	Cv2.EdgePreservingFilter(orgimage, edgePreserveImage, EdgePreservingMethods.NormconvFilter);
	Cv2.ImShow("edgePreserveImage", edgePreserveImage);

	Mat detailEnhancedImage = new Mat();
	Cv2.DetailEnhance(orgimage, detailEnhancedImage);
	Cv2.ImShow("detailEnhancedImage", detailEnhancedImage);

	Mat colorSketchImage = new Mat();
	Mat graySketchImage = new Mat();
	Cv2.PencilSketch(orgimage, colorSketchImage, graySketchImage, 60, 0.08f, 0.08f);
	Cv2.ImShow("colorSketchImage", colorSketchImage);
	Cv2.ImShow("graySketchImage", graySketchImage);

	Mat styleImage = new Mat();
	Cv2.Stylization(orgimage, styleImage);
	Cv2.ImShow("styleImage", styleImage);
}

// Define other methods and classes here
