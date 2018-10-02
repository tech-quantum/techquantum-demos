<Query Kind="Program">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
</Query>

void Main()
{
	Mat orgimage = Cv2.ImRead(@"C:\git\ComputerVision\LinqPadExamples\images\blobs.jpg");
	
	SimpleBlobDetector blobDetector = SimpleBlobDetector.Create();
	KeyPoint[] keyPoints = blobDetector.Detect(orgimage);
	
	Mat image_keypoints = new Mat();
	Cv2.DrawKeypoints(orgimage, keyPoints, image_keypoints, new Scalar(0, 0, 0), DrawMatchesFlags.DrawRichKeypoints);
	Cv2.ImShow("image_keypoints", image_keypoints);
}

// Define other methods and classes here