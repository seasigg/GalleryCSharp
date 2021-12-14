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
    public partial class Login_Register : Form
    {
        Color selectedPanel = Color.FromArgb(242, 241, 239);
        Color notSelectedPanel = Color.FromArgb(46, 49, 49);
        public Login_Register()
        {
            InitializeComponent();
        }

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
    }
}
