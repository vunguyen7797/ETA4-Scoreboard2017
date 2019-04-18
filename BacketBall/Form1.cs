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
    public partial class Form1 : Form
    {
        #region Properties
        ControlPanel_Manager controlPanel;
        private string horn_path;
        private string sub_horn_path;
        #endregion
        public Form1()
        {
            InitializeComponent();

            controlPanel = new ControlPanel_Manager(min_tb, second_tb, minute_lb, second_lb, shot_time_lb, team1_score_lb, team2_score_lb, t1_foul_lb, t2_foul_lb, t1_tmOut_lb, t2_tmOut_lb,
                Count_Time,Count_Shot_time, period_lb, team_name1_lb, team_name2_lb, ava_team1, ava_team2);
          
            this.Load += Form1_Load;
        }
        //Delegate TimeClock
        public delegate void DownTimeClock();
        public static event DownTimeClock DownTimeForm2Clock;

        //Delegate ShotClock
        public delegate void DownTimeShotClock();
        public static event DownTimeShotClock DownTimeForm2ShotClock;
        
        //Delegate ResetClock
        public delegate void ResetClock();
        public static event ResetClock ResetForm2Clock;

        //Delegate Nhập Thời gian
        public delegate void EnterClock();
        public static event EnterClock EnterForm2Clock;

        // Delegate Nhập Tên Đội
        public delegate void EnterName();
        public static event EnterName EnterForm2Name;

        private void name_team1_TextChanged(object sender, EventArgs e)
        {
        }
   
        private void name_team2_TextChanged(object sender, EventArgs e)
        {
           
        }


        // Delegate Nhập hiệp
        public delegate void EnterPeriod();
        public static event EnterPeriod EnterForm2Period;

        // Delegate Cộng điểm team 1
        public delegate void PlusScoreT1();
        public static event PlusScoreT1 PlusForm2ScoreTeam1;

        // Delegate Cộng điểm team 2
        public delegate void PlusScoreT2();
        public static event PlusScoreT2 PlusForm2ScoreTeam2;

        // Delegate Trừ điểm team 1
        public delegate void DecScoreT1();
        public static event DecScoreT1 DecForm2ScoreTeam1;

        // Delegate Trừ điểm team 2
        public delegate void DecScoreT2();
        public static event DecScoreT2 DecForm2ScoreTeam2;

        // Delegate Cộng lỗi t1
        public delegate void PlusFoulT1();
        public static event PlusFoulT1 PlusForm2FoulTeam1;

        // Delegate Cộng lỗi team 2
        public delegate void PlusfoulT2();
        public static event PlusfoulT2 PlusForm2FoulTeam2;

        // Delegate Trừ lỗi team 1
        public delegate void DecFoulT1();
        public static event DecFoulT1 DecForm2FoulTeam1;

        // Delegate Trừ lỗi team 2
        public delegate void DecFoulT2();
        public static event DecFoulT2 DecForm2FoulTeam2;

        // Delegate Cộng tmout t1
        public delegate void PlusTmOutT1();
        public static event PlusTmOutT1 PlusForm2TmOutTeam1;

        // Delegate Cộng TmOut team 2
        public delegate void PlusTmOutT2();
        public static event PlusTmOutT2 PlusForm2TmOutTeam2;

        // Delegate Trừ TmOut team 1
        public delegate void DecTmOutT1();
        public static event DecTmOutT1 DecForm2TmOutTeam1;

        // Delegate Trừ TmOut team 2
        public delegate void DecTmOutT2();
        public static event DecTmOutT2 DecForm2TmOutTeam2;

        // Delegate Ava team1
        public delegate void AvaTeam1();
        public static event AvaTeam1 AvaForm2Team1;

        // Delegate Ava team2
        public delegate void AvaTeam2();
        public static event AvaTeam2 AvaForm2Team2;

        void Form1_Load(object sender, EventArgs e)
        {
            //Show Form 2 lúc khởi động
            screen_form frmshowClock = new screen_form(controlPanel);
            frmshowClock.Show();
        }

        #region Methods

        private void min_tb_TextChanged(object sender, EventArgs e)     // đổi thời gian phút
        {
            
            controlPanel.Minute = Convert.ToInt32(min_tb.Text);
         
        }

        private void second_tb_TextChanged(object sender, EventArgs e)      //đổi thời gian giây
        {
            controlPanel.Second = Convert.ToInt32(second_tb.Text);
        }
        
        private void Count_Time_Tick(object sender, EventArgs e)
        {
            //abcxyz
            controlPanel.DownTime_Timer1();             //đồng hồ trận đấu
            DownTimeForm2Clock();
         //   DownTimeForm2ShotClock();           
        }


        private void start_btt_Click(object sender, EventArgs e)            //bắt đầu chạy thời gian
        {
            controlPanel.Start_Time();
      
        }

        private void pause_btt_Click(object sender, EventArgs e)            //tạm dừng thời gian thi đấu
        {
            controlPanel.Pause_Time();

        }

        private void reset_btt_Click(object sender, EventArgs e)        // reset thời gian thi đấu
        {
            minute_lb.Text = min_tb.Text;
            second_lb.Text = second_tb.Text;
            controlPanel.Minute = Convert.ToInt32(minute_lb.Text);
            controlPanel.Second = Convert.ToInt32(second_lb.Text);

          //  controlPanel.Reset_Timer1();
          //  controlPanel.Pause_Time();
     
            ResetForm2Clock();
            
        }

        private void sc_gr_start_btt_Click(object sender, EventArgs e)      // start shot clock
        {
            controlPanel.Start_ShotClock();
        }

        private void sc_gr_reset_btt_Click(object sender, EventArgs e)  // reset shot clock
        {
            controlPanel.Reset_Timer2();

            controlPanel.Start_ShotClock();
        }

        private void reset_14s_btt_Click(object sender, EventArgs e)    //reset 14s
        {
            controlPanel.Reset14_Timer2();
        }

        private void sc_gr_pause_btt_Click(object sender, EventArgs e)  // pause shot clock
        {
            controlPanel.Pause_ShotClock();
        }

     

        private void time_ed_gr_enter_btt_Click(object sender, EventArgs e)  //bấm enter để nhập thời gian thi đấu
        {
            minute_lb.Text =min_tb.Text;
            second_lb.Text = second_tb.Text;
            EnterForm2Clock();
        }

       

        private void Count_Shot_time_Tick(object sender, EventArgs e)
        {
            controlPanel.DownTime_Timer2();                 //đồng hồ ném 24s
        }

        private void sc_gr_plus_btt_Click(object sender, EventArgs e)           //cộng thời gian 24s
        {
            controlPanel.Add_Shot_Time();
        }

        private void sc_gr_dec_btt_Click(object sender, EventArgs e)            //trừ thời gian 24s
        {
            controlPanel.Dec_Shot_Time();
        }

        private void Close_btt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ava_team1_Click(object sender, EventArgs e)            //thay ảnh đội 1    
        {
         
        }

        private void ava_team2_Click(object sender, EventArgs e)               // thay ảnh đổi 2
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                ava_team2.Image = Image.FromFile(file.InitialDirectory + file.FileName);
            }
            AvaForm2Team2();
        }

        private void add_sc_t1_btt_Click(object sender, EventArgs e)      //CỘNG ĐIỂM 1
        {
            controlPanel.Add_Score_T1();
            PlusForm2ScoreTeam1();
        }

        private void dec_sc_t1_btt_Click(object sender, EventArgs e)     //TRỪ ĐIỂM 1
        {
            controlPanel.Dec_Score_T1();
            DecForm2ScoreTeam1();
        }

        private void add_sc_t2_btt_Click(object sender, EventArgs e)    //CỘNG ĐIỂM 2
        {
            controlPanel.Add_Score_T2();
            PlusForm2ScoreTeam2();
        }

        private void dec_sc_t2_btt_Click(object sender, EventArgs e)    //TRỪ ĐIỂM 2
        {
            controlPanel.Dec_Score_T2();
            DecForm2ScoreTeam2();
        }

        private void add_foul_t1_btt_Click(object sender, EventArgs e)  //cộng lỗi 1
        {
            controlPanel.Add_Foul_T1();
            PlusForm2FoulTeam1();
        }

        private void dec_foul_t1_btt_Click(object sender, EventArgs e)  //trừ lỗi 1
        {
            controlPanel.Dec_Foul_T1();
            DecForm2FoulTeam1();
        }

        private void add_foul_t2_btt_Click(object sender, EventArgs e)      //cộng lỗi 2
        {
            controlPanel.Add_Foul_T2();
            PlusForm2FoulTeam2();
        }

        private void dec_foul_t2_btt_Click(object sender, EventArgs e)         //trừ lỗi 2
        {
            controlPanel.Dec_Foul_T2();
            DecForm2FoulTeam2();
        }

        private void add_tmOut_t1_btt_Click(object sender, EventArgs e)  //cộng TmOut 1
        {
            controlPanel.Add_TmOut_T1();
            PlusForm2TmOutTeam1();
        }

        private void dec_tmOut_t1_btt_Click(object sender, EventArgs e)  //trừ TmOut1
        {
            controlPanel.Dec_TmOut_T1();
            DecForm2TmOutTeam1();
        }

        private void add_tmOut_t2_btt_Click(object sender, EventArgs e)      //cộng TmOut 2
        {
            controlPanel.Add_TmOut_T2();
            PlusForm2TmOutTeam2();
        }

        private void dec_tmOut_t2_btt_Click(object sender, EventArgs e)         //trừ TmOut 2
        {
            controlPanel.Dec_TmOut_T2();
            DecForm2TmOutTeam2();
        }

        private void button1_Click(object sender, EventArgs e)          // reo còi
        {
            controlPanel.Play_horn();
        }

        private void period_enter_Click(object sender, EventArgs e)        // Nhập hiệp
        {
            period_lb.Text = period_num.Text;
            EnterForm2Period();
          
        }

        private void ed_ava1_btt_Click(object sender, EventArgs e)  // Nhập tên
        {
            team_name1_lb.Text = name_team1_tb.Text;
            team_name2_lb.Text = name_team2_tb.Text;
            EnterForm2Name();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void t1_timeout_lb_Click(object sender, EventArgs e)
        {

        }

        private void splitter3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }



     

        private void second_lb_Click(object sender, EventArgs e)
        {

        }

      

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void time_ed_gr_Enter(object sender, EventArgs e)
        {

        }

     

        private void period_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void show_btt_Click(object sender, EventArgs e)
        {
            screen_form screen = new screen_form(controlPanel);
            screen.Show();
        }

        private void minute_lb_Click(object sender, EventArgs e)
        {

        }

        private void shot_time_lb_Click(object sender, EventArgs e)
        {

        }

        private void ava_team1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                ava_team1.Image = Image.FromFile(file.InitialDirectory + file.FileName);

            }
            AvaForm2Team1();
        }
    }
    #endregion 
}
