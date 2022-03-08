using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace sayıtutmaoyunu
{
    public class MainForm : Form
    {
        Random rand = new Random();//random number generator
        int[] arr = new int[1000];
        int number;
        int j = 0;
        Boolean found = false;

        //fileds
        private TextBox txt_guess = new TextBox();
        private Button btn_submit = new Button();
        private Button btn_restart = new Button();
        private Button btn_start = new Button();

        private RadioButton radio_0_100 = new RadioButton();
        private RadioButton radio_0_1000 = new RadioButton();

        private Label lbl_guess = new Label();
        private Label lbl_succesfull = new Label();
        private Label lbl_allguess = new Label();
        private Label lbl_lower = new Label();
        private Label lbl_higher = new Label();
        private Label lbl_gap = new Label();
        private Label lbl_numbergenerated = new Label();

        private ListBox listbox_allguess = new ListBox();

        public MainForm()
        {
            this.BackColor = Color.SkyBlue;
            this.Size = new Size(450, 500);//mainform size
            CenterToScreen();//centralize mainform
            this.Text = "Main Form";
            Render();
        }

        void Render()
        {
            //radio button control customization
            radio_0_1000.Text = "0-1000";
            radio_0_100.Text = "0-100";
            radio_0_1000.Location = new Point(190, 100);
            radio_0_100.Location = new Point(190, 120);
            radio_0_1000.ForeColor = Color.Black;
            radio_0_100.ForeColor = Color.Black;

            //listbox control customization
            listbox_allguess.Size = new Size(200, 200);
            listbox_allguess.Location = new Point(125, 300);

            //label control customization
            lbl_allguess.Text = "Tüm Tahminleriniz";
            lbl_allguess.Location = new Point(180, 280);
            lbl_allguess.AutoSize = true;
            lbl_allguess.ForeColor = Color.Black;

            lbl_guess.Text = "Tahmininiz : ";
            lbl_guess.Location = new Point(120, 200);
            lbl_guess.AutoSize = true;
            lbl_guess.ForeColor = Color.Black;

            lbl_gap.Text = "Aralık Seçin";
            lbl_gap.Location = new Point(180, 80);
            lbl_gap.AutoSize = true;
            lbl_gap.ForeColor = Color.Black;

            lbl_lower.Text = "Yukarı";
            lbl_lower.ForeColor = Color.Red;
            lbl_lower.Location = new Point(100, 160);

            lbl_higher.Text = "Aşağı";
            lbl_higher.Location = new Point(100, 240);
            lbl_higher.ForeColor = Color.Red;

            lbl_succesfull.ForeColor = Color.DarkGreen;
            lbl_succesfull.Location = new Point(120, 260);
            lbl_succesfull.AutoSize = true;

            lbl_numbergenerated.ForeColor = Color.Black;
            lbl_numbergenerated.Location = new Point(100, 100);
            //button customizations
            btn_start.Location = new Point(30, 30);
            btn_submit.Location = new Point(320, 195);
            btn_restart.Location = new Point(110, 30);

            btn_start.BackColor = Color.Black;
            btn_restart.BackColor = Color.Black;
            btn_submit.BackColor = Color.Black;
            btn_start.ForeColor = Color.White;
            btn_submit.ForeColor = Color.White;
            btn_restart.ForeColor = Color.White;

            btn_submit.Text = "Dene";
            btn_start.Text = "Başla";
            btn_restart.Text = "Tekar Oyna";
            //textbox customizaiton
            txt_guess.Location = new Point(200, 200);

            //adding controls
            this.Controls.Add(lbl_gap);
            this.Controls.Add(radio_0_1000);
            this.Controls.Add(radio_0_100);
            this.Controls.Add(listbox_allguess);
            this.Controls.Add(btn_start);
            this.Controls.Add(btn_submit);
            this.Controls.Add(lbl_lower);
            this.Controls.Add(lbl_higher);
            this.Controls.Add(lbl_allguess);
            this.Controls.Add(lbl_succesfull);
            this.Controls.Add(lbl_guess);
            this.Controls.Add(txt_guess);
            this.Controls.Add(btn_restart);
            this.Controls.Add(lbl_numbergenerated);

            btn_submit.Click += Btn_Submit_Click;
            btn_start.Click += Btn_Start_Click;
            btn_restart.Click += Btn_Restart_Click;
            this.Load += Handle_Load;
        }

        //form load
        void Handle_Load(object sender, EventArgs e)//form load event
        {
            lbl_succesfull.Visible = false;
            lbl_allguess.Visible = false;
            listbox_allguess.Visible = false;
            lbl_lower.Visible = false;
            lbl_higher.Visible = false;
            btn_start.Enabled = true;
            btn_submit.Enabled = false;
            btn_restart.Visible = false;
        }

        //start button
        void Btn_Start_Click(object sender, EventArgs e)
        {
            if (radio_0_100.Checked == true || radio_0_1000.Checked == true)
            {
                if (radio_0_100.Checked == true)//for 0-100 radiobutton
                {
                    number = rand.Next(0, 100);
                }
                if (radio_0_1000.Checked == true)//for 0-1000 radiobutton
                {
                    number = rand.Next(0, 1000);
                }
                btn_start.Visible = false;
                btn_submit.Enabled = true;
                lbl_numbergenerated.Text = "Sayınız : " + number;//for following the number
            }
            else
                MessageBox.Show("Lütfen Aralık Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //submit button
        void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_guess.Text) < number)
            {
                lbl_lower.Visible = true;
                lbl_higher.Visible = false;
            }
            else if (Convert.ToInt32(txt_guess.Text) > number)
            {
                lbl_lower.Visible = false;
                lbl_higher.Visible = true;
            }
            else
            {
                lbl_lower.Visible = false;
                lbl_higher.Visible = false;
            }
            if (Convert.ToInt32(txt_guess.Text) == number)
            {
                found = true;
            }
            else
                found = false;
            if (found == false)
            {
                arr[j] = Convert.ToInt32(txt_guess.Text);
                j++;
            }
            if (found == true)
            {
                for (int i = 0; i < j; i++)
                {
                    listbox_allguess.Items.Add(arr[i]);
                    btn_restart.Visible = true;
                    btn_submit.Enabled = false;
                }
                lbl_allguess.Visible = true;
                listbox_allguess.Visible = true;
                lbl_succesfull.Visible = true;
                btn_restart.Visible = true;
                btn_submit.Enabled = false;
                lbl_succesfull.Text = "Tebrikler " + (j + 1) + ". denemede sayıyı buldunuz.";
            }
        }
        //restart button
        void Btn_Restart_Click(object sender, EventArgs e)
        {
            if (radio_0_100.Checked == true || radio_0_1000.Checked == true)
            {
                if (radio_0_100.Checked == true)//for 0-100 radiobutton
                {
                    number = rand.Next(0, 100);
                }
                if (radio_0_1000.Checked == true)//for 0-1000 radiobutton
                {
                    number = rand.Next(0, 1000);
                }
                btn_start.Visible = false;
                btn_submit.Enabled = true;
                lbl_numbergenerated.Text = "Sayınız : " + number;//for following the number
            }
            else
                MessageBox.Show("Lütfen Aralık Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            j = 0;
            btn_submit.Enabled = true;
            listbox_allguess.Visible = false;
            lbl_succesfull.Visible = false;
            lbl_allguess.Visible = false;
            btn_restart.Visible = false;
        }
    }
}
