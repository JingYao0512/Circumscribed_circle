using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
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

        private double get_det4(double[,] ans)
        {
            return ans[0, 0] * get_det(new double[3, 3] { { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) -
            ans[1, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) +
            ans[2, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[3, 1], ans[3, 2], ans[3, 3] } }) -
            ans[3, 0] * get_det(new double[3, 3] { { ans[0, 1], ans[0, 2], ans[0, 3] }, { ans[1, 1], ans[1, 2], ans[1, 3] }, { ans[2, 1], ans[2, 2], ans[2, 3] } });

        }

        private double get_enclidean(double[] x, double[] y)
        {
            return Math.Sqrt(Math.Pow(x[0] - y[0], 2) +
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
            ori = new double[3] { get_det4(w1) / wVal, get_det4(w2) / wVal, get_det4(w3) / wVal };
            radi = Math.Sqrt(Math.Pow(ori[0] - x[0], 2) + Math.Pow(ori[1] - x[1], 2) + Math.Pow(ori[2] - x[2], 2));

            // 計算法向量
            double[] centerAB = new double[3];
            center_point(ref centerAB, x, y);
            double[] centerAC = new double[3];
            center_point(ref centerAC, x, z);

            get_vector_diff(ref centerAB, ori, centerAB);
            get_vector_diff(ref centerAC, ori, centerAC);

            norm = Cross(centerAB, centerAC);

            //計算角度
            angle = (norm[0] * 1 ) / Math.Sqrt(Math.Pow(norm[0], 2) + Math.Pow(norm[1], 2)) / Math.Sqrt(1);
            angle = Math.Acos(angle) / Math.PI * 180;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //--- Load the coordinate points 
            double[] x = new double[] { double.Parse(this.txt_x1.Text.ToString()),
                                        double.Parse(this.txt_y1.Text.ToString()),
                                        double.Parse(this.txt_z1.Text.ToString()) };
            double[] y = new double[] { double.Parse(this.txt_x2.Text.ToString()),
                                        double.Parse(this.txt_y2.Text.ToString()),
                                        double.Parse(this.txt_z2.Text.ToString()) };
            double[] z = new double[] { double.Parse(this.txt_x3.Text.ToString()),
                                        double.Parse(this.txt_y3.Text.ToString()),
                                        double.Parse(this.txt_z3.Text.ToString()) };

            //calculate_radius(double[] x, double[] y, double[] z, ref double[] ori, ref double radi, ref double[] norm, ref double angle)

            double[] ori = new double[3];
            double radi = 0;
            double[] norm = new double[3];
            double angle = 0;
            calculate_radius(x, y, z, ref ori, ref radi, ref norm, ref angle);
            DataTable dt = new DataTable();
            dt.Columns.Add("Type\\Value"); dt.Columns.Add("Value (X)"); dt.Columns.Add("Value (Y)"); dt.Columns.Add("Value (Z)");
            dt.Rows.Add(); dt.Rows.Add(); dt.Rows.Add(); dt.Rows.Add();
            dt.Rows[0][0] = "Center of circle"; dt.Rows[1][0] = "Radius"; dt.Rows[2][0] = "Normal Vector"; dt.Rows[3][0] = "Angle";
            dt.Rows[0][1] = ori[0].ToString(); dt.Rows[0][2] = ori[1].ToString(); dt.Rows[0][3] = ori[2].ToString();
            dt.Rows[1][1] = radi.ToString();
            dt.Rows[2][1] = norm[0].ToString(); dt.Rows[2][2] = norm[1].ToString(); dt.Rows[2][3] = norm[2].ToString();
            dt.Rows[3][1] = angle.ToString();

            Form2 f2    = new Form2();
            f2.loadDataTable(dt);
            f2.Show();

            //label2.Text = String.Format(" Center of circle: {0}, {1}, {2} \n Radius: {3}\n Normal Vector: {4}, {5}, {6}\n angle: {7}",
            //    ori[0], ori[1], ori[2], radi, norm[0], norm[1], norm[2], angle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_status.Text = "進行計算";
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string strExcelPath = file.FileName;

            //確認檔案是否為.csv, .xlsx 
            //若不是則顯示錯誤視窗
            string strExtension = System.IO.Path.GetExtension(strExcelPath);
            string strFileName = System.IO.Path.GetFileName(strExcelPath);
            string[] acceptedExtension = { ".xlsx", ".xls", ".csv" };

            if (!strExtension.Equals(acceptedExtension[0], StringComparison.OrdinalIgnoreCase) &
                !strExtension.Equals(acceptedExtension[1], StringComparison.OrdinalIgnoreCase) &
                !strExtension.Equals(acceptedExtension[2], StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("請選擇正確的檔案格式(.csv)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtBox_filepath.Text = strExcelPath;
                DataTable dt = new DataTable();
                FileStream fs = new FileStream(strExcelPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);

                //記錄每次讀取的一行記錄
                string strLine = "";
                //記錄每行記錄中的各字段內容
                string[] aryLine = null;
                string[] tableHead = null;
                //標示列數
                int columnCount = 0;
                //標示是否是讀取的第一行
                bool IsFirst = true;
                //逐行讀取CSV中的數據
                while ((strLine = sr.ReadLine()) != null)
                {
                    if (IsFirst == true)
                    {
                        tableHead = strLine.Split(',');
                        IsFirst = false;
                        columnCount = tableHead.Length;
                        test.Text = String.Format("{0}", columnCount);
                        //創建列
                        for (int i = 0; i < columnCount; i++)
                        {
                            tableHead[i] = tableHead[i].Replace("\"", "");
                            DataColumn dc = new DataColumn(tableHead[i]);
                            dt.Columns.Add(dc);
                        }
                    }
                    else
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j].Replace("\"", "");
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // 關閉串流
                sr.Close();
                fs.Close();


                // 讀取座標 目前只有遠端、中端、近端三個XYZ座標軸
                Form2 f2 = new Form2();
                f2.loadDataTable(dt);
                f2.Show();
                //Console.WriteLine("%d",dt.Rows.Count);
                //test.Text = String.Format("{0}", dt.Rows.Count);
                
                List<int> DataNumber = new List<int>();
                for (int times = dt.Rows.Count - 1; times >= 0; times--)
                {
                    if (dt.Rows[times][0].ToString().CompareTo("proximal") == 0)
                    {
                        DataNumber.Add(times);
                    }
                }
                test.Text = String.Format("{0}", DataNumber[0]);
                for (int addInd = dt.Columns.Count; addInd < 10; addInd++)
                {
                    dt.Columns.Add();
                }
                for (int dataInd = 0; dataInd < DataNumber.Count; dataInd++)
                {


                    double[] x, y, z, ori, norm;
                    double radi, angle;
                    try
                    {
                        for (int times = 0; times < 4; times++)
                        {
                            if (dt.Rows[times * 3 + DataNumber[dataInd] + 0][2].ToString() != "")
                            {

                                x = new double[] {  double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 0][2].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 0][3].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 0][4].ToString()) };
                                y = new double[] {  double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 1][2].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 1][3].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 1][4].ToString()) };
                                z = new double[] {  double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 2][2].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 2][3].ToString()),
                                                double.Parse(dt.Rows[times * 3 + DataNumber[dataInd] + 2][4].ToString()) };

                                ori = new double[3];
                                radi = 0;
                                norm = new double[3];
                                angle = 0;
                                calculate_radius(x, y, z, ref ori, ref radi, ref norm, ref angle);
                                dt.Rows[times * 3 + DataNumber[dataInd] + 0][6] = "Center of circle";
                                dt.Rows[times * 3 + DataNumber[dataInd] + 0][7] = ori[0].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 0][8] = ori[1].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 0][9] = ori[2].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 1][6] = "Normal Vector";
                                dt.Rows[times * 3 + DataNumber[dataInd] + 1][7] = norm[0].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 1][8] = norm[1].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 1][9] = norm[2].ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 2][6] = "Radius";
                                dt.Rows[times * 3 + DataNumber[dataInd] + 2][7] = radi.ToString();
                                dt.Rows[times * 3 + DataNumber[dataInd] + 2][8] = "Angle";
                                dt.Rows[times * 3 + DataNumber[dataInd] + 2][9] = angle.ToString();


                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("表格格式錯誤，無法正確取得座標資訊。", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        FileInfo fi = new FileInfo(strExcelPath);
                        if (!fi.Directory.Exists)
                        {
                            fi.Directory.Create();
                        }
                        fs = new FileStream(strExcelPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                        string data = "";
                        //寫出列名稱
                        
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            //data += "\"" + dt.Columns[i].ColumnName.ToString() + "\"";
                            if (i < dt.Columns.Count - 1)
                            {
                                data += ",";
                            }
                        }
                        
                        sw.WriteLine(data);
                        //寫出各行數據
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = "";
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                string str = dt.Rows[i][j].ToString();
                                if (str.CompareTo("") != 0)
                                {
                                    str = string.Format("\"{0}\"", str);
                                    data += str;
                                }
                                if (j < dt.Columns.Count - 1)
                                {
                                    data += ",";
                                }
                            }
                            sw.WriteLine(data);
                        }
                        sw.Close();
                        fs.Close();
                        label_status.Text = "完成計算";
                    }
                    catch
                    {
                        MessageBox.Show("無法寫入檔案，請通知開發人員。", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }



}
