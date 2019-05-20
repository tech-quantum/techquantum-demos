using Arithmetica;
using System;
using System.Threading.Tasks;
using System.Linq;
using OpenCvSharp;

namespace Learn_Convolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the image
            Image img = Image.FromFile("cat01.jpg", height: 200, width: 200, grayScale: true);

            //Small blur filter
            Matrix smallBlur = Matrix.Ones(7, 7) * (1.0f / (7 * 7));

            //Large blur filter
            Matrix largeBlur = Matrix.Ones(21, 21) * (1.0f / (21 * 21));

            //Sharpening filter
            Matrix sharpen = new Matrix(3, 3);
            sharpen.LoadArray(0f, -1f, 0f,
                             -1f, 5f, -1f,
                              0f, -1f, 0f);


            Convolve(img, smallBlur).Show();
            Convolve(img, largeBlur).Show();
            Convolve(img, sharpen).Show();
        }

        private static Image Convolve(Image img, Matrix filter)
        {
            //Get the image height and width
            int iH = img.Height;
            int iW = img.Width;

            //Get the kernel height and width
            int kH = (int)filter.Rows;
            int kW = (int)filter.Cols;

            //Pad the matrix
            int pad = (kW - 1) / 2;

            //Pad the image which will create a border of size of the pad length
            var image = img.Pad(pad, pad, pad, pad);

            //Create a empty image by allocating memory for the resulting image
            //taking care to the "pad" the borders of the image so that the spatial size are not reduced
            Image output = new Image(1, iH, iW);
            output.Fill(0);

            //Loop through the image to slide the kernel 
            //across each (x, y) coordinate from left to right and top to bottom
            Parallel.For(0, image.Height - kH, (y) =>
            {
                Parallel.For(0, image.Width - kW, (x) =>
                {
                    //Get the region of interest
                    var roi = image.GetRegion(x, y, kH, kW);

                    ////Convert it to a matrix, since we have one image we can take the 0 index.
                    ////Since its gray scale so we will get one matrix
                    var roiMatrix = roi.ToMatrix(0).First();

                    //// perform the actual convolution by taking the
                    //// element-wise multiplicate between the ROI and
                    //// the kernel, then summing the matrix
                    var k = Matrix.Sum(roiMatrix * filter);

                    // store the convolved value in the output (x,y)- coordinate of the output image
                    output.SetPixel(x, y, k);
                });
            });

            return output;
        }
    }
}
