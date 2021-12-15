using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Likha_Art_Gallery
{
    public partial class UserMM : Form
    {
        public UserMM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Register nf = new Login_Register();
            nf.Show();
            this.Hide();
        }
    }
}
