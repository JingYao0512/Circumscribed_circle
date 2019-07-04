namespace Circumscribed_circle
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_calculate = new System.Windows.Forms.Button();
            this.txtBox_filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_status = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_z3 = new System.Windows.Forms.TextBox();
            this.txt_y3 = new System.Windows.Forms.TextBox();
            this.txt_x3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_z2 = new System.Windows.Forms.TextBox();
            this.txt_y2 = new System.Windows.Forms.TextBox();
            this.txt_x2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_z1 = new System.Windows.Forms.TextBox();
            this.txt_y1 = new System.Windows.Forms.TextBox();
            this.txt_x1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_calculate
            // 
            this.btn_calculate.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_calculate.Location = new System.Drawing.Point(440, 110);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(94, 32);
            this.btn_calculate.TabIndex = 12;
            this.btn_calculate.Text = "計算";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_filepath
            // 
            this.txtBox_filepath.Location = new System.Drawing.Point(65, 106);
            this.txtBox_filepath.Name = "txtBox_filepath";
            this.txtBox_filepath.Size = new System.Drawing.Size(444, 22);
            this.txtBox_filepath.TabIndex = 1;
            this.txtBox_filepath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(68, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "請選擇座標檔案 (*.csv)";
            // 
            // btn_file
            // 
            this.btn_file.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_file.Location = new System.Drawing.Point(541, 96);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(94, 32);
            this.btn_file.TabIndex = 2;
            this.btn_file.Text = "選擇檔案";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(12, 444);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(41, 12);
            this.label_status.TabIndex = 8;
            this.label_status.Text = "待命中";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "x";
            // 
            // txt_z3
            // 
            this.txt_z3.Location = new System.Drawing.Point(313, 120);
            this.txt_z3.Name = "txt_z3";
            this.txt_z3.Size = new System.Drawing.Size(95, 22);
            this.txt_z3.TabIndex = 11;
            // 
            // txt_y3
            // 
            this.txt_y3.Location = new System.Drawing.Point(171, 120);
            this.txt_y3.Name = "txt_y3";
            this.txt_y3.Size = new System.Drawing.Size(95, 22);
            this.txt_y3.TabIndex = 10;
            // 
            // txt_x3
            // 
            this.txt_x3.Location = new System.Drawing.Point(37, 120);
            this.txt_x3.Name = "txt_x3";
            this.txt_x3.Size = new System.Drawing.Size(95, 22);
            this.txt_x3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "x";
            // 
            // txt_z2
            // 
            this.txt_z2.Location = new System.Drawing.Point(313, 70);
            this.txt_z2.Name = "txt_z2";
            this.txt_z2.Size = new System.Drawing.Size(95, 22);
            this.txt_z2.TabIndex = 8;
            // 
            // txt_y2
            // 
            this.txt_y2.Location = new System.Drawing.Point(171, 70);
            this.txt_y2.Name = "txt_y2";
            this.txt_y2.Size = new System.Drawing.Size(95, 22);
            this.txt_y2.TabIndex = 7;
            // 
            // txt_x2
            // 
            this.txt_x2.Location = new System.Drawing.Point(37, 70);
            this.txt_x2.Name = "txt_x2";
            this.txt_x2.Size = new System.Drawing.Size(95, 22);
            this.txt_x2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 36;
            this.label9.Text = "x";
            // 
            // txt_z1
            // 
            this.txt_z1.Location = new System.Drawing.Point(313, 20);
            this.txt_z1.Name = "txt_z1";
            this.txt_z1.Size = new System.Drawing.Size(95, 22);
            this.txt_z1.TabIndex = 5;
            // 
            // txt_y1
            // 
            this.txt_y1.Location = new System.Drawing.Point(171, 20);
            this.txt_y1.Name = "txt_y1";
            this.txt_y1.Size = new System.Drawing.Size(95, 22);
            this.txt_y1.TabIndex = 4;
            // 
            // txt_x1
            // 
            this.txt_x1.Location = new System.Drawing.Point(37, 20);
            this.txt_x1.Name = "txt_x1";
            this.txt_x1.Size = new System.Drawing.Size(95, 22);
            this.txt_x1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_calculate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_z1);
            this.panel1.Controls.Add(this.txt_y1);
            this.panel1.Controls.Add(this.txt_x1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_z2);
            this.panel1.Controls.Add(this.txt_y2);
            this.panel1.Controls.Add(this.txt_x2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_z3);
            this.panel1.Controls.Add(this.txt_y3);
            this.panel1.Controls.Add(this.txt_x3);
            this.panel1.Location = new System.Drawing.Point(101, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 166);
            this.panel1.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "Point-1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "Point-2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(63, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "Point-3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(68, 208);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 20);
            this.label16.TabIndex = 44;
            this.label16.Text = "請依序輸入各點座標";
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(99, 415);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(33, 12);
            this.test.TabIndex = 45;
            this.test.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 465);
            this.Controls.Add(this.test);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_filepath);
            this.Name = "Form1";
            this.Text = "外接圓計算機";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.TextBox txtBox_filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_z3;
        private System.Windows.Forms.TextBox txt_y3;
        private System.Windows.Forms.TextBox txt_x3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_z2;
        private System.Windows.Forms.TextBox txt_y2;
        private System.Windows.Forms.TextBox txt_x2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_z1;
        private System.Windows.Forms.TextBox txt_y1;
        private System.Windows.Forms.TextBox txt_x1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label test;
    }
}

