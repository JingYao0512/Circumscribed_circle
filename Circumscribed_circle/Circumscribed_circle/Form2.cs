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
    public partial class Form2 : Form
    {

        public void loadDataTable(DataTable inDt)
        {
            dataGridView1.DataSource = inDt;
            
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
