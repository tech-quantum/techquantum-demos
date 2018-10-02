using OpenCvSharp;

namespace ComputerVisionApi.Model
{
    public class FaceFeature
    {
        public Rect Face { get; set; }

        public Rect[] Eyes { get; set; }
    }
}
