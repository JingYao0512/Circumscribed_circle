using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circumscribed_circle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        // 計算中點
        private void center_point(ref double[] ans, double[] x, double[] y)
        {
            ans[0] = (x[0] + y[0]) / 2;

            ans[1] = (x[1] + y[1]) / 2;

            ans[2] = (x[2] + y[2]) / 2;
        }

        //計算兩向量的差
        private void get_vector_diff(ref double[] ans, double[] x, double[] y)
        {
            ans[0] = y[0] - x[0];

            ans[1] = y[1] - x[1];

            ans[2] = y[2] - x[2];

        }
        //計算兩向量的外積
        public static double[] Cross(double[] left, double[] right)
        {

            double[] result = new double[3];
            result[0] = left[1] * right[2] - left[2] * right[1];
            result[1] = -left[0] * right[2] + left[2] * right[0];
            result[2] = left[0] * right[1] - left[1] * right[0];

            return result;
        }
        //計算兩向量的內積
        private float get_inner_product(float[] x, float[] y)
        {
            return x[0] * y[0] + x[1] * y[1] + x[2] * y[2];
        }

        private double get_det(double[,] ans)
        {
            

            return ans[0, 0] * ans[1, 1] * ans[2, 2] +
                    ans[0, 1] * ans[1, 2] * ans[2, 0] +
                    ans[0, 2] * ans[1, 0] * ans[2, 1] -
                    ans[0, 2] * ans[1, 1] * ans[2, 0] -
                    ans[0, 1] * ans[1, 0] * ans[2, 2] -
                    ans[0, 0] * ans[1, 2] * ans[2, 1];
        }

        private double get_det4(double[,]ans)
        {
            return ans[0, 0] * get_det(new double[3, 3] { { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) -
            ans[1, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) +
            ans[2, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) -
            ans[3, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] } });

        } 

        private double get_enclidean (double[] x, double[] y)
        {
            return  Math.Sqrt(Math.Pow(x[0] - y[0], 2) +
                Math.Pow(x[1] - y[1], 2) +
                Math.Pow(x[2] - y[2], 2));
        }

        private double[,] set_det(double[] x, double[] y, double[] z, int col)
        {
            // set which col is 1
            double[,] ans = new double[3, 3];
            for (int i = 0; i < 3; ++i)
            {
                if (i == (col - 1))
                {
                    ans[0, i] = 1;
                    ans[1, i] = 1;
                    ans[2, i] = 1;
                }
                else
                {
                    ans[0, i] = x[i];
                    ans[1, i] = y[i];
                    ans[2, i] = z[i];
                }
            }
            return ans;

        }


        private void calculate_radius(double[] x, double[] y, double[] z, ref double[] ori, ref double radi, ref double[] norm, ref double angle)
        {

            /* 參考網址 http://www.mathchina.net/dvbbs/dispbbs.asp?boardid=3&Id=5262&authorid=1 */

            double[,] det1 = set_det(x, y, z, 1);
            double[,] det2 = set_det(x, y, z, 2);
            double[,] det3 = set_det(x, y, z, 3);
            double[,] det4 = set_det(x, y, z, 4);

            double detVal1 = get_det(det1);
            double detVal2 = get_det(det2);
            double detVal3 = get_det(det3);
            double detVal4 = get_det(det4);

            double avgX = (Math.Pow(x[0], 2) + Math.Pow(x[1], 2) + Math.Pow(x[2], 2)) / 2;
            double avgY = (Math.Pow(y[0], 2) + Math.Pow(y[1], 2) + Math.Pow(y[2], 2)) / 2;
            double avgZ = (Math.Pow(z[0], 2) + Math.Pow(z[1], 2) + Math.Pow(z[2], 2)) / 2;

            double[,] w = new double[4, 4] { { x[0], x[1], x[2], 1 }, {y[0], y[1], y[2], 1 }, 
                {z[0], z[1], z[2], 1 }, {detVal1, detVal2 ,detVal3, 0} };
            double[,] w1 = new double[4, 4] { { avgX, x[1], x[2], 1 }, {avgY, y[1], y[2], 1 },
                {avgZ, z[1], z[2], 1 }, {detVal4, detVal2 ,detVal3, 0} };
            double[,] w2 = new double[4, 4] { { x[0], avgX, x[2], 1 }, {y[0], avgY, y[2], 1 },
                {z[0], avgZ, z[2], 1 }, {detVal1, detVal4 ,detVal3, 0} };
            double[,] w3 = new double[4, 4] { { x[0], x[1], avgX, 1 }, {y[0], y[1], avgY, 1 },
                {z[0], z[1], avgZ, 1 }, {detVal1, detVal2 ,detVal4, 0} };

            double wVal = get_det4(w);

            // 計算圓心、半徑
            ori = new double[3] { get_det4(w1) / wVal, get_det4(w2) / wVal, get_det4(w3) / wVal};
            radi = Math.Sqrt(Math.Pow(ori[0] - x[0], 2) + Math.Pow(ori[1] - x[1], 2) + Math.Pow(ori[2] - x[2], 2));

            // 計算法向量
            double[] centerAB = new double[3];
            center_point(ref centerAB, x , y);
            double[] centerBC = new double[4];
            center_point(ref centerBC, y, z);

            get_vector_diff(ref centerAB, ori, centerAB);
            get_vector_diff(ref centerBC, ori, centerBC);

            norm = Cross(centerAB, centerBC);
            
            //計算角度
            angle = (norm[0] * 1) / Math.Sqrt(Math.Pow(norm[0], 2) + Math.Pow(norm[1], 2) + Math.Pow(norm[2], 2));
            angle = Math.Acos(angle) / Math.PI * 180;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = this.textBox1.Text.Split(',');

            if (words.Length % 3 != 0)
            {
                string message = "Vectors must have a length of 3.";
                throw new Exception(message);
            }


            double[] x = new double[] { double.Parse(words[0]), double.Parse(words[1]), double.Parse(words[2]) };
            double[] y = new double[] { double.Parse(words[3]), double.Parse(words[4]), double.Parse(words[5]) };
            double[] z = new double[] { double.Parse(words[6]), double.Parse(words[7]), double.Parse(words[8]) };

            //calculate_radius(double[] x, double[] y, double[] z, ref double[] ori, ref double radi, ref double[] norm, ref double angle)

            double[] ori = new double[3];
            double radi = 0;
            double[] norm = new double[3];
            double angle = 0;
            calculate_radius(x, y, z, ref ori, ref radi, ref norm, ref angle);

            label2.Text = String.Format(" Center of circle: {0}, {1}, {2} \n Radius: {3}\n Normal Vector: {4}, {5}, {6}\n angle: {7}",
                ori[0], ori[1], ori[2], radi, norm[0], norm[1], norm[2], angle);
        }
    }
    


}
