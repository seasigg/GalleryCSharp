using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Likha_Art_Gallery
{
    public partial class Login_Register : Form
    {
        Color selectedPanel = Color.FromArgb(242, 241, 239);
        Color notSelectedPanel = Color.FromArgb(46, 49, 49);
        public Login_Register()
        {
            InitializeComponent();
        }

        //Earl
        public static SqlConnection con = new SqlConnection("Data Source=DESKTOP-DD2OE5B\\SQLEXPRESS;Initial Catalog=gallery;Integrated Security=True");

        //Mab
        //public static SqlConnection con = new SqlConnection();
        
        //Miggy

        
        //Keans

        
        //Jolo

        private void Login_Register_Load(object sender, EventArgs e)
        {
            btn_login_panel.PerformClick();
        }

        private void btn_login_panel_Click(object sender, EventArgs e)
        {
            panel_login.BringToFront();
            panel_register.SendToBack();
            panel_login_bar.BackColor = selectedPanel;
            panel_register_bar.BackColor = notSelectedPanel;
            clearAllFields();
        }

        private void btn_register_panel_Click(object sender, EventArgs e)
        {
            panel_login.SendToBack();
            panel_register.BringToFront();
            panel_login_bar.BackColor = notSelectedPanel;
            panel_register_bar.BackColor = selectedPanel;
            clearAllFields();
        }

        private void clearAllFields()
        {
            txt_username_login.Clear();
            txt_password_login.Clear();
            txt_username_register.Clear();
            txt_password_register.Clear();
            txt_confirmpass.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            radio_artist.Checked = false;
            radio_visitor.Checked = false;
        }

        private void link_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btn_login_panel.PerformClick();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            String imageLocation;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error in uploading image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
