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
using System.IO;

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
        //public static SqlConnection con = new SqlConnection("Data Source=DESKTOP-DD2OE5B\\SQLEXPRESS;Initial Catalog=gallery;Integrated Security=True");

        //Mab
        //public static SqlConnection con = new SqlConnection();

        //Miggy


        //Keans

        
        //Jolo
        public static SqlConnection con = new SqlConnection("Data Source=DESKTOP-UFRTTCN\\SQLEXPRESS;Initial Catalog=gallery;Integrated Security=True");

        private String imageLocation = null;
        byte[] photo;
        SqlCommand cmd;
        private String accType;

        public static int currentUserID;
        public static String currentUsername;
        public static String currentType;

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
                        photo = getPhoto(imageLocation);

                        String un = txt_username_register.Text;
                        String pa = txt_password_register.Text;
                        String fn = txt_fname.Text;
                        String ln = txt_lname.Text;

                        con.Open();
                        cmd = new SqlCommand("INSERT INTO registration VALUES ('" + un + "', '" + pa + "', '" + fn + "', '" + ln + "', '" + accType + "', '" + photo + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Account Registered Successfully");

                        clearAllFields();
                        btn_login_panel.PerformClick();
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
            {
                t = true;
                if (radio_artist.Checked)
                    accType = "artist";
                else
                    accType = "user";
            }
                
            else
                MessageBox.Show("Please Choose Account Type");
            return t;
        }

        private Boolean passCheck()
        {
            Boolean t = false;
            if (txt_password_register.Text == txt_confirmpass.Text)
                t = true;
            else
                MessageBox.Show("Passwords are not the same");
            return t;
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            if(emptyCheckerLogin())
            {
                if(credentialsCheck())
                {
                    login();
                }
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

        public static byte[] getPhoto(String path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        private Boolean credentialsCheck()
        {
            con.Open();

            String u = txt_username_login.Text;
            String p = txt_password_login.Text;

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM registration WHERE username = '" + u + "' AND password = '" + p + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                SqlDataReader r;
                con.Open();
                cmd = new SqlCommand("SELECT * FROM registration WHERE username = '" + u + "' AND password = '" + p + "'", con);
                r = cmd.ExecuteReader();
                
                if (r.Read())
                {
                    currentUserID = Convert.ToInt32(r["user_id"]);
                    currentUsername = r["username"].ToString();
                    currentType = r["user_type"].ToString();

                }
                con.Close();
                MessageBox.Show("Successfully Logged In");
                return true;
            }

            else
            {
                MessageBox.Show("Invalid Credentials");
                return false;   
            }
        }

        private void login()
        {
            if(currentType.Equals("artist"))
            {
                ArtistMM a = new ArtistMM();
                a.Show();
                this.Hide();
            }
            else
            {
                UserMM u = new UserMM();
                u.Show();
                this.Hide();
            }
        }
    }
}
