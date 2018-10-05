using ComputerVisionApi.Model;
using ComputerVisionApi.Module;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ComputerVisionApi.Controllers
{
    [Route("api/[controller]")]
    
    public class CVController : Controller
    {
        FaceFeatureDetection faceDetectionModule = new FaceFeatureDetection();

        [HttpPost("facedetect")]
        public IEnumerable<FaceFeature> FaceDetect([FromBody] ImageInput model)
        {
            return faceDetectionModule.DetectFeatures(model.ImageUrl);
        }
    }
}