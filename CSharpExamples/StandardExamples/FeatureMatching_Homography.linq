<Query Kind="Statements">
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
  <Namespace>OpenCvSharp.XFeatures2D</Namespace>
</Query>

//Read the nemo character
var nemoCharacter = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\nemo.jpg");

//Read the movie poster scene to find nemo
var moviePoster = Cv2.ImRead(@"C:\git\ComputerVision\StandardExamples\images\nemo_friends.jpg");

//Min feature match count to find nemo
int MIN_MATCH_COUNT = 10;

//We will use SIFT method to detect and describe keypoints. You are welcome to try others like SURF, FAST, BRIEF, ORB etc.
SIFT sift = SIFT.Create();
KeyPoint[] kp1 = null;
KeyPoint[] kp2 = null;
Mat des1 = new Mat();
Mat des2 = new Mat();

//Detect keypoint from first image: nemoCharacter
sift.DetectAndCompute(nemoCharacter, null, out kp1, des1);

//Detect keypoint from second image: moviePoster
sift.DetectAndCompute(moviePoster, null, out kp2, des2);

//We are using FLANN based matching technique to find the matching image of 1 in 2.
OpenCvSharp.Flann.IndexParams indexParams = new OpenCvSharp.Flann.IndexParams();
indexParams.SetAlgorithm(0);
indexParams.SetInt("trees", 5);

OpenCvSharp.Flann.SearchParams searchParams = new OpenCvSharp.Flann.SearchParams();
searchParams.SetInt("checks", 50);

FlannBasedMatcher flann = new FlannBasedMatcher(indexParams, searchParams);
var matches = flann.KnnMatch(des1, des2, k: 2);


//Store all the good matches as per Lowe's ratio test.
List<DMatch> goodMatches = new List<OpenCvSharp.DMatch>();

for (int i = 0; i < matches.Length; i++)
{
	if(matches[i][0].Distance < 0.75 * matches[i][1].Distance)
	{
		goodMatches.Add(matches[i][0]);
	}
}

//Test condition to see if we have enough good score
if (goodMatches.Count <= MIN_MATCH_COUNT)
{
	throw new Exception("Not enough good matches are found!");
}

//Draw the matches across two images and show
Mat final = new Mat();

Cv2.DrawMatches(nemoCharacter, kp1, moviePoster, kp2, goodMatches, final, new Scalar(0, 255, 0), null);
Cv2.ImShow("final", final);
Cv2.WaitKey(0);