using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
namespace sayıtutmaoyunu
{
    public class LoginForm : Form
    {
        //fields
        private Label lbl_username = new Label();
        private Label lbl_password = new Label();
        private Label lbl_info = new Label();
        private TextBox txt_username = new TextBox();
        private TextBox txt_password = new TextBox();
        private Button btn_login = new Button();

        public LoginForm()
        {
            this.Size = new Size(400, 400);//login form size
            CenterToScreen();//centralize loginform
            this.BackColor = Color.SkyBlue;
            this.Text = "Login Form";
            Render();
        }
        //Rendering Controls
        void Render()
        {
            //label customizations
            lbl_username.Text = "Kullanıcı Adı : ";
            lbl_username.Location = new Point(60, 150);
            lbl_username.ForeColor = Color.Black;
            lbl_password.Text = "Şifre";
            lbl_password.Location = new Point(60, 180);
            lbl_password.ForeColor = Color.Black;
            lbl_info.Text = "Kullanıcı Adı: admin    Şifre: admin";
            lbl_info.AutoSize = true;
            lbl_info.ForeColor = Color.Black;
            lbl_info.Location = new Point(50, 100);
            //textbox customization
            txt_password.Location = new Point(180, 180);
            txt_username.Location = new Point(180, 150);
            txt_password.PasswordChar =  '*'; 
            txt_password.Size = new Size(150, 30);
            txt_username.Size = new Size(150, 30);

            //button customization
            btn_login.Text = "Giriş Yap";
            btn_login.AutoSize = true;
            btn_login.Location = new Point(170, 300);
            btn_login.BackColor = Color.Black;
            btn_login.ForeColor = Color.White;

            //adding controls
            this.Controls.Add(lbl_password);
            this.Controls.Add(lbl_username);
            this.Controls.Add(lbl_info);
            this.Controls.Add(txt_username);
            this.Controls.Add(txt_password);
            this.Controls.Add(btn_login);

            //event handlers
            btn_login.Click += Btn_Login_Click;//login button click event
        }

        void Btn_Login_Click(object sender, EventArgs e)
        {
            //login password and username check
            if (txt_username.Text == "admin" && txt_password.Text == "admin")
            {
                MainForm mf = new MainForm();
                this.Hide();
                mf.Show();
            }
            else
                MessageBox.Show("Yanlış kullanıcı adı veya şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
