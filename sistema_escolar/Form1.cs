using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_escolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(label1.Text)   || !string.IsNullOrEmpty(label2.Text) )  {
            
            menu menuform = new menu();  
            menuform.ShowDialog();
            
            
            }
            else
            {
                MessageBox.Show("validacion erronea");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
