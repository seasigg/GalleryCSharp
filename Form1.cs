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


        private String imageLocation = null;

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

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (emptyChecker())
            {
                if(accTypeChecker())
                {
                    if(passCheck())
                    {

                    }
                }
            }
        }

        private Boolean emptyChecker()
        {
            Boolean t = false;
            if (txt_username_register.TextLength == 0 || txt_password_register.TextLength == 0 ||
                txt_confirmpass.TextLength == 0 || txt_fname.TextLength == 0 ||
                txt_lname.TextLength == 0 || imageLocation == null)
            {
                MessageBox.Show("Please Input All Required Fields");
            }
            else
                t = true;
            return t;
        }

        private Boolean accTypeChecker()
        {
            Boolean t = false;
            if (radio_artist.Checked || radio_visitor.Checked)
                t = true;
            else
                MessageBox.Show("Please Choose Account Type");
            return t;
        }

        private Boolean passCheck()
        {
            Boolean t = false;
            if (txt_password_register == txt_confirmpass)
                t = true;
            else
                MessageBox.Show("Passwords are not the same");
            return t;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(emptyCheckerLogin())
            {

            }
        }

        private Boolean emptyCheckerLogin()
        {
            Boolean t = false;
            if (txt_username_login.TextLength == 0 || txt_password_login.TextLength == 0)
                MessageBox.Show("Please Fill up All Fields");
            else
                t = true;
            return t;
        }
    }
}
