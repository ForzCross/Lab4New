using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;

namespace lab4
{
    public partial class SymbolSearchForm : Form
    {
        string FileName;
        public SymbolSearchForm(Image img,string filename)
        {            
            InitializeComponent();
            pictureBox1.Image = img;
            FileName = filename;          
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            FindAndResult obj1 = new ResultFoundHandler();
            FindAndResult obj2 = new ResultNotFoundHandler();
            obj1.SetConnect(obj2);
            try
            {
                //нахождение контура шаблона
                Mat hierarhy = new Mat();
                Mat img_template = new Mat();
                VectorOfVectorOfPoint contours_template = new VectorOfVectorOfPoint();
                VectorOfVectorOfPoint contours_real_img = new VectorOfVectorOfPoint();
                VectorOfVectorOfPoint newcontours = new VectorOfVectorOfPoint();
                // Bitmap im = new Bitmap("C:\\Users\\Marina\\Desktop\\diplomvlop\\22.jpg");
                Mat image = new Mat("C:\\Users\\Marina\\Desktop\\diplomvlop\\22.jpg", Emgu.CV.CvEnum.LoadImageType.Grayscale);

                CvInvoke.GaussianBlur(image, img_template, new Size(7, 7), 2);
                CvInvoke.Canny(img_template, img_template, 90, 120, 3, true);
                CvInvoke.Threshold(img_template, img_template, 127, 256, ThresholdType.Binary);
                CvInvoke.FindContours(img_template, contours_template, hierarhy, RetrType.Tree, ChainApproxMethod.LinkRuns);
                //нахождение максимального контура у шаблона если нашлось много мусорных контуров
                int maxArea = 0;
                for (int i = 0; i < contours_template.Size; i++)
                {
                    if (CvInvoke.ContourArea(contours_template[i], true) > 7)// подразумевается что площадь большего кнтура будет больше 7, число произвольное но оно достаточно чтобы отсеяь мусор 
                    {
                        newcontours.Push(contours_template[i]);
                        if (CvInvoke.ContourArea(contours_template[i]) > CvInvoke.ContourArea(newcontours[maxArea]))
                            maxArea = newcontours.Size - 1;
                    }
                }


                double res = 0;
                int find_cntr = -2;
                //нахождение контура изображения с опенфайладиалога

                Mat image2 = new Mat(FileName, Emgu.CV.CvEnum.LoadImageType.Grayscale);
                Mat img_real = new Mat();
                CvInvoke.GaussianBlur(image2, img_real, new Size(7, 7), 2);
                CvInvoke.Canny(img_real, img_real, 90, 120, 3, true);
                CvInvoke.FindContours(img_real, contours_real_img, hierarhy, RetrType.Tree, ChainApproxMethod.LinkRuns);
                //поиск контура по шаблону сравнивая их эквализационные моменты:)

                Image<Bgr, Byte> imag1 = new Image<Bgr, byte>(image2.Bitmap);
                for (int i = 0; i < newcontours.Size; i++)
                {
                    for (int t = 0; t < contours_real_img.Size; t++)
                    {
                        res = CvInvoke.MatchShapes(newcontours[i], contours_real_img[t], ContoursMatchType.I1);
                        find_cntr = obj1.FindSimbol(res);
                        if (find_cntr == 1)
                        {
                            CvInvoke.DrawContours(imag1, contours_real_img, t, new MCvScalar(0, 0, 255));


                        }
                    }
                }

                pictureBox1.Image = imag1.Bitmap;
            }
               
        
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ашипка");
            }
        }
    }
}
