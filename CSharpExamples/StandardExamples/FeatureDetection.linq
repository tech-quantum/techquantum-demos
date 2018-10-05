<Query Kind="Program">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
  <Namespace>OpenCvSharp.XFeatures2D</Namespace>
</Query>

void Main()
{
	ORB_OpenCV();
}

void HarrisCorner()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\chessboard.jpg");
	Mat gray = new Mat();
	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);
	
	var points = Cv2.GoodFeaturesToTrack(gray, 50, 0.01, 10, null, blockSize: 2, useHarrisDetector: true, k: 0.04);
	
	//points = Cv2.CornerSubPix(gray, points, new Size(3,3), new Size(-1, -1), new TermCriteria(CriteriaType.Count, 20, 0.03));
	
	foreach (var element in points)
	{
		Cv2.Circle(img, element, 3, new Scalar(0, 255, 0), 2);
	}
	
	Cv2.ImShow("image", img);
}

void SciThomasCorner()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\chessboard.jpg");
	Mat gray = new Mat();
	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	var points = Cv2.GoodFeaturesToTrack(gray, 50, 0.01, 10, null, blockSize: 2, useHarrisDetector: false, k: 0);

	foreach (var element in points)
	{
		Cv2.Circle(img, element, 3, new Scalar(0, 255, 0), 2);
	}

	Cv2.ImShow("image1", img);
}

void SIFT()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");
	Mat gray = new Mat();
	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	OpenCvSharp.XFeatures2D.SIFT sift = OpenCvSharp.XFeatures2D.SIFT.Create(nFeatures: 400);

	KeyPoint[] keypoints = null;
	Mat descriptors = new Mat();
	sift.DetectAndCompute(gray, null, out keypoints, descriptors);
	
	Cv2.DrawKeypoints(img, keypoints, img, new Scalar(0, 255, 0), DrawMatchesFlags.Default);
	Cv2.ImShow("image1", img);
}

void SURF()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");
	Mat gray = new Mat();
	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	OpenCvSharp.XFeatures2D.SURF surf = OpenCvSharp.XFeatures2D.SURF.Create(hessianThreshold: 2000);
	
	//U-SURF which is more faster
	OpenCvSharp.XFeatures2D.SURF usurf = OpenCvSharp.XFeatures2D.SURF.Create(hessianThreshold: 200, upright: true);

	KeyPoint[] keypoints = null;
	keypoints = surf.Detect(gray, null);

	Cv2.DrawKeypoints(img, keypoints, img, new Scalar(0, 255, 0), DrawMatchesFlags.Default);
	Cv2.ImShow("image2", img);
}

void FAST()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");
	Mat gray = new Mat();
	
	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	OpenCvSharp.FastFeatureDetector fast = OpenCvSharp.FastFeatureDetector.Create(threshold: 25);

	KeyPoint[] keypoints = null;
	keypoints = fast.Detect(gray, null);

	Cv2.DrawKeypoints(img, keypoints, img, new Scalar(0, 255, 0), DrawMatchesFlags.Default);
	Cv2.ImShow("image3", img);
}

void BRIEF()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");
	Mat gray = new Mat();

	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	StarDetector star = StarDetector.Create(responseThreshold: 100);
	KeyPoint[] keypoints = star.Detect(gray, null);
	
	BriefDescriptorExtractor brief = BriefDescriptorExtractor.Create();
	Mat descriptor = new Mat();
	keypoints = brief.Detect(gray);
	brief.Compute(gray, ref keypoints, descriptor);
}

void ORB_OpenCV()
{
	Mat img = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\building.jpg");
	Mat gray = new Mat();

	Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

	OpenCvSharp.ORB orb = ORB.Create();
	KeyPoint[] keypoints = orb.Detect(gray, null);

	Mat descriptor = new Mat();
	orb.Compute(gray, ref keypoints, descriptor);
	Cv2.DrawKeypoints(img, keypoints, img, new Scalar(0, 255, 0), DrawMatchesFlags.Default);
	Cv2.ImShow("image3", img);
}