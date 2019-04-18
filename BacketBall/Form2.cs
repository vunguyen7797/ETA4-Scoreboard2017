using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BacketBall
{
    public partial class screen_form : Form
    {
        private ControlPanel_Manager controlpanel;


        public screen_form(ControlPanel_Manager controlpanel)
        {
            InitializeComponent();
  
            this.controlpanel = controlpanel;

            //abcxyz
            Form1.DownTimeForm2Clock += Form1_DownTimeForm2Clock;
            Form1.ResetForm2Clock += Form1_ResetForm2Clock;
            Form1.EnterForm2Clock += Form1_EnterForm2Clock;
            Form1.EnterForm2Period += Form1_EnterForm2Period;
            Form1.EnterForm2Name += Form1_EnterForm2Name;
       
            
            Form1.PlusForm2ScoreTeam1 += Form1_PlusForm2ScoreTeam1;
            Form1.PlusForm2ScoreTeam2 += Form1_PlusForm2ScoreTeam2;
            Form1.DecForm2ScoreTeam1 += Form1_DecForm2ScoreTeam1;
            Form1.DecForm2ScoreTeam2 += Form1_DecForm2ScoreTeam2;

            Form1.PlusForm2FoulTeam1 += Form1_PlusForm2FoulTeam1;
            Form1.PlusForm2FoulTeam2 += Form1_PlusForm2FoulTeam2;
            Form1.DecForm2FoulTeam1 += Form1_DecForm2FoulTeam1;
            Form1.DecForm2FoulTeam2 += Form1_DecForm2FoulTeam2;

            Form1.PlusForm2TmOutTeam1 += Form1_PlusForm2TmOutTeam1;
            Form1.PlusForm2TmOutTeam2 += Form1_PlusForm2TmOutTeam2;
            Form1.DecForm2TmOutTeam1 += Form1_DecForm2TmOutTeam1;
            Form1.DecForm2TmOutTeam2 += Form1_DecForm2TmOutTeam2;

            Form1.AvaForm2Team1 += Form1_AvaForm2Team1;
            Form1.AvaForm2Team2 += Form1_AvaForm2Team2;
        }


        // moveable form
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        // ava team 1
        void Form1_AvaForm2Team1()
        {
            ava_team1.Image = controlpanel.Ava1.Image;
        }

        // ava team 1
        void Form1_AvaForm2Team2()
        {
            ava_team2.Image = controlpanel.Ava2.Image;
        }

        // Cộng điểm team 1
        void Form1_PlusForm2ScoreTeam1()
        {
            score_t1_lb.Text = controlpanel.T1_score_lb.Text;
        }

        // Cộng điểm team 2
        void Form1_PlusForm2ScoreTeam2()
        {
            score_t2_lb.Text = controlpanel.T2_score_lb.Text;
        }

        // trừ điểm team 1
        void Form1_DecForm2ScoreTeam1()
        {
            score_t1_lb.Text = controlpanel.T1_score_lb.Text;
        }

        // trừ điểm team 2
        void Form1_DecForm2ScoreTeam2()
        {
            score_t2_lb.Text = controlpanel.T2_score_lb.Text;
        }

        // Cộng lỗi team 1
        void Form1_PlusForm2FoulTeam1()
        {
            foul_t1_lb.Text = controlpanel.T1_foul_lb.Text;
        }

        // Cộng lỗi team 2
        void Form1_PlusForm2FoulTeam2()
        {
            foul_t2_lb.Text = controlpanel.T2_foul_lb.Text;
        }

        // trừ lỗi team 1
        void Form1_DecForm2FoulTeam1()
        {
            foul_t1_lb.Text = controlpanel.T1_foul_lb.Text;
        }

        // trừ lỗi team 2
        void Form1_DecForm2FoulTeam2()
        {
            foul_t2_lb.Text = controlpanel.T2_foul_lb.Text;
        }

        // Cộng TmOut team 1
        void Form1_PlusForm2TmOutTeam1()
        {
            label7.Text = controlpanel.T1_tmOut_lb.Text;
        }

        // Cộng TmOut team 2
        void Form1_PlusForm2TmOutTeam2()
        {
            label8.Text = controlpanel.T2_tmOut_lb.Text;
        }

        // trừ TmOut team 1
        void Form1_DecForm2TmOutTeam1()
        {
            label7.Text = controlpanel.T1_tmOut_lb.Text;
        }

        // trừ TmOut team 2
        void Form1_DecForm2TmOutTeam2()
        {
            label8.Text = controlpanel.T2_tmOut_lb.Text;
        }

        // Đếm ngược thời gian Shot ở Form 2
     

        // Tên đội
        void Form1_EnterForm2Name()
        {
            name_t1_lb.Text = controlpanel.Name1.Text;
            name_t2_lb.Text = controlpanel.Name2.Text;
        }

        // Hiệp
        void Form1_EnterForm2Period()
        {
            per_num_lb.Text = controlpanel.Period.Text;
        }
        //Đếm ngược thời gian ở Form 2
        void Form1_DownTimeForm2Clock()
        {
            minute_lb.Text = controlpanel.Current_min_lb.Text;
            second_lb.Text = controlpanel.Current_se_lb.Text;
            
        }

        //Reset Clock ở Form 2
        void Form1_ResetForm2Clock()
        {
            if (controlpanel.Minute < 10)
            {
                minute_lb.Text = "0" + controlpanel.Minute.ToString();
            }
            else
                minute_lb.Text = controlpanel.Minute.ToString();

            if (controlpanel.Second <10)
            {
                second_lb.Text = "0" + controlpanel.Second.ToString();   
            } else
                second_lb.Text = controlpanel.Second.ToString();
            
        }

        //Nhập thời gian ở Form 2
        void Form1_EnterForm2Clock()
        {
            minute_lb.Text = controlpanel.Current_min_lb.Text;
            second_lb.Text = controlpanel.Current_se_lb.Text;

        }

        //Nhập tên đội ở Form 2
        void getName(String name1, String name2)
        {
            name_t1_lb.Text = name1;
            name_t2_lb.Text = name2;
        }
        
        
    
        private void ResizeAllControls(Control recussiveControl, float WidthPerscpective, float HeightPerscpective)
        {

            foreach (Control control in recussiveControl.Controls)
            {

                //gọi đệ quy nếu như 1 control nào có chứa các control khác nữa

                if (control.Controls.Count != 0)

                    ResizeAllControls(control, WidthPerscpective, HeightPerscpective);

                //canh lại toạ độ x, y, chiều rộng, cao cho các control trên form

                control.Left = (int)(control.Left * WidthPerscpective);

                control.Top = (int)(control.Top * HeightPerscpective);

                control.Width = (int)(control.Width * WidthPerscpective);

                control.Height = (int)(control.Height * HeightPerscpective);

            }
        }
  

        private void ava_team2_Click(object sender, EventArgs e)
        {
         
        }
        private void ava_team2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                ava_team2.Image = Image.FromFile(file.InitialDirectory + file.FileName);

            }
        }

        private void ava_team1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                ava_team1.Image = Image.FromFile(file.InitialDirectory + file.FileName);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void second_lb_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void minute_lb_Click(object sender, EventArgs e)
        {

        }

        private void minute_lb_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void second_lb_Click_1(object sender, EventArgs e)
        {

        }

        private void screen_form_Load(object sender, EventArgs e)
        {

        }

        private void period_lb_Click(object sender, EventArgs e)
        {

        }

        private void name_t1_lb_Click(object sender, EventArgs e)
        {
          
        }

        private void label5_Click_2(object sender, EventArgs e)
        {

        }

        private void minute_lb_Click_2(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void per_num_lb_Click(object sender, EventArgs e)
        {

        }

        private void score_t1_lb_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void foul_t1_lb_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void shotClock_lb_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void score_t1_lb_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void score_t1_lb_Click_2(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
