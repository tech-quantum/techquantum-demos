<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.FileSystem.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>OpenCvSharp3-AnyCPU</NuGetReference>
  <NuGetReference>Tesseract</NuGetReference>
  <Namespace>OpenCvSharp</Namespace>
  <Namespace>System.IO.Compression</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>Tesseract</Namespace>
</Query>

string baseDir = @"C:\git\ComputerVision\LinqPadExamples";

void Main()
{
	string imagePath = baseDir + @"\images\businesscard.jpg";
	Mat img = Cv2.ImRead(imagePath, ImreadModes.GrayScale);
	
	string tessDataPath = DownloadAndExtractLanguagePack();
	string rawText = "";
	OpenCvSharp.Rect[] textLocations = null;
	string[] componentTexts= null;
	float[] confidences = null;
	
	using(var engine = OpenCvSharp.Text.OCRTesseract.Create(tessDataPath, "eng"))
	{
		engine.Run(img, out rawText, out textLocations, out componentTexts, out confidences, OpenCvSharp.Text.ComponentLevels.TextLine);
	}
}

string DownloadAndExtractLanguagePack()
{
	string langPackPath = "https://github.com/tesseract-ocr/tessdata/archive/3.04.00.zip";
	string zipFileName = AppDomain.CurrentDomain.BaseDirectory + "\\tessdata.zip";
	string tessDataFolder = AppDomain.CurrentDomain.BaseDirectory + "\\tessdata"; ;
	if (!File.Exists(zipFileName))
	{
		WebClient client = new WebClient();
		client.DownloadFile(langPackPath, zipFileName);
	}

	if (string.IsNullOrWhiteSpace(tessDataFolder))
	{
		ZipFile.ExtractToDirectory(zipFileName, AppDomain.CurrentDomain.BaseDirectory);
		var extractedDir = Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory).FirstOrDefault(x => (x.Contains("tessdata")));
		Directory.Move(extractedDir, tessDataFolder);
	}

	return tessDataFolder;
}