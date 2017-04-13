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
        NonSymbolForm symbolForm = new NonSymbolForm();
        ImageDataBase DB = AppData.getInstance().dataBase;
        Product[] massProd;
        Image currentImage;
        Rectangle cropBorders = new Rectangle();
        bool cropChanging = false;
        FindAndResult obj1 = new ResultFoundHandler();
        FindAndResult obj2 = new ResultNotFoundHandler();

        public SymbolSearchForm(Image img)
        {
            InitializeComponent();
            
            pictureBox1.Image = img;
            if (!AppData.getInstance().isExpert)
            {
                NonCVButton.Hide();
                numericUpDown1.Hide();
            }
            numericUpDown1.Value = (decimal)AppData.getInstance().accuracy;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            massProd = DB.getAllImages();
            currentImage = img;
            obj1.SetConnect(obj2);

            foreach (var item in massProd)
            {
                checkImage(item);
            } 
        }
        private void checkImage(Product prod)
        {
            
            try
            {
                //нахождение контура шаблона
                Mat hierarhy = new Mat();
                Mat img_template = new Mat();
                VectorOfVectorOfPoint contours_template = new VectorOfVectorOfPoint();
                VectorOfVectorOfPoint contours_real_img = new VectorOfVectorOfPoint();
                VectorOfVectorOfPoint newcontours = new VectorOfVectorOfPoint();
                Mat image = (new Image<Gray, byte>(prod.template)).Mat;

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
                Image<Rgb, Byte> tempImage = new Image<Rgb, byte>(new Bitmap(currentImage));
                Mat image2 = tempImage.Convert<Gray,byte>().Mat;
                Mat img_real = new Mat();
                CvInvoke.GaussianBlur(image2, img_real, new Size(7, 7), 2);
                CvInvoke.Canny(img_real, img_real, 90, 120, 3, true);
                
                CvInvoke.FindContours(img_real, contours_real_img, hierarhy, RetrType.Tree, ChainApproxMethod.LinkRuns);
                
                //поиск контура по шаблону сравнивая их эквализационные моменты:)
                Image<Bgr, Byte> imag1 = new Image<Bgr, byte>(image2.Bitmap);
                //Image<Gray,byte> imag2 = imag1.Convert<Gray, byte>();
                for (int t = 0; t < contours_real_img.Size; t++)
                {
                    res = CvInvoke.MatchShapes(newcontours[0], contours_real_img[t], ContoursMatchType.I1);
                    find_cntr = obj1.FindSimbol(res);
                    if (find_cntr == 1)
                    {                    
                        CvInvoke.DrawContours(imag1, contours_real_img, t, new MCvScalar(0, 0, 255));
                        Point[] contour = contours_real_img[t].ToArray();
                        ConcreteFactory factory = new ConcreteFactory(prod);
                        
                        int x = int.MaxValue, y = int.MaxValue, x2 = int.MinValue, y2 = int.MinValue;
                        foreach (var p in contour)
                        {
                            if (p.X < x)
                                x = p.X;
                            if (p.Y < y)
                                y = p.Y;
                            if (p.X > x2)
                                x2 = p.X;
                            if (p.Y > y2)
                                y2 = p.Y;
                        }
                        Simvol simmm=(Simvol)factory.CreateSimvol(new Rectangle(x,y,x2-x,y2-y));
                        panel1.Controls.Add(simmm.infoButton);
                        simmm.infoButton.BringToFront();
                        simmm.infoButton.Show();
                        Rectangle bnds = simmm.infoButton.Bounds;
                        if(bnds.Width < 10 || bnds.Height < 10)
                        {
                            simmm.infoButton.Hide();
                            continue;
                        }
                        simmm.infoButton.Image = (new Bitmap(pictureBox1.Image)).Clone(simmm.infoButton.Bounds, pictureBox1.Image.PixelFormat);
                        simmm.infoButton.TextAlign = ContentAlignment.MiddleCenter;                                     
                    }
                }
                pictureBox1.Image = imag1.Bitmap;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ашипка");
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(cropChanging)
                e.Graphics.DrawRectangle(Pens.Red, cropBorders);
        }

        private void NonCVButton_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap tmp = bmp.Clone(cropBorders, bmp.PixelFormat);
            symbolForm = new NonSymbolForm(tmp);
            if (symbolForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cropChanging = true;
            cropBorders.Location = e.Location;
            pictureBox1.Invalidate();
        }
         private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(cropChanging)
            {
                cropBorders.Width = e.X - cropBorders.X ;
                cropBorders.Height = e.Y - cropBorders.Y ;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            cropChanging = false;
            cropBorders.Width = e.X - cropBorders.X;
            cropBorders.Height = e.Y - cropBorders.Y;
            NonCVButton.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            AppData.getInstance().accuracy = (double)numericUpDown1.Value;
            if (massProd != null)
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i] is Button)
                        panel1.Controls.RemoveAt(i--);
                }
                foreach (var item in massProd)
                {
                    checkImage(item);
                }
            }
        }
    }
}
