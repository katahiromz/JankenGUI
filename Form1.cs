using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JankenGUI
{
    public partial class Form1 : Form
    {
        bool start = false;
        bool aiko = false;
        public Form1()
        {
            InitializeComponent();
        }

        void show_hand(int player_hand)
        {
            int comp_hand = get_comp_hand();
            switch (comp_hand)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.gu;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.choki;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.pa;
                    break;
            }
            switch (hantei(player_hand, comp_hand))
            {
                case 0:
                    label3.Text = "あなたの勝ちです";
                    var player = new System.Media.SoundPlayer(Properties.Resources.kachi);
                    player.Play();
                    aiko = false;
                    break;
                case 1:
                    label3.Text = "あなたの負けです";
                    var player2 = new System.Media.SoundPlayer(Properties.Resources.make);
                    player2.Play();
                    aiko = false;
                    break;
                case 2:
                    label3.Text = "あいこ";
                    var player3 = new System.Media.SoundPlayer(Properties.Resources.aikodesho);
                    player3.Play();
                    aiko = true;
                    break;
            }
            //スタートをリセット
            if (!aiko) start = false;
        }

        int get_comp_hand()
        {
            Random cRnd = new System.Random();    // インスタンスを生成 
            return cRnd.Next(1, 4);       // １以上４未満の乱数を取得
        }

        int hantei(int player_hand, int comp_hand)
        {
            int iHantei = 0;
            if (player_hand == 1)
            {
                if (comp_hand == 1) iHantei = 2;
                else if (comp_hand == 2) iHantei = 0;
                else if (comp_hand == 3) iHantei = 1;
            }
            if (player_hand == 2)
            {
                if (comp_hand == 1) iHantei = 1;
                else if (comp_hand == 2) iHantei = 2;
                else if (comp_hand == 3) iHantei = 0;
            }
            if (player_hand == 3)
            {
                if (comp_hand == 1) iHantei = 0;
                else if (comp_hand == 2) iHantei = 1;
                else if (comp_hand == 3) iHantei = 2;
            }
            return iHantei;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gu
            if (start == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("じゃんけんぽんを押してね",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                pictureBox2.Image = Properties.Resources.gu;
                var player = new System.Media.SoundPlayer(Properties.Resources.gu1);
                player.PlaySync();
                show_hand(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //start
            start = true;
            var player = new System.Media.SoundPlayer(Properties.Resources.jankenpon);
            player.PlaySync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //choki
            if (start == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("じゃんけんぽんを押してね",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                pictureBox2.Image = Properties.Resources.choki;
                var player = new System.Media.SoundPlayer(Properties.Resources.choki1);
                player.PlaySync();
                show_hand(2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pa
            if (start == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("じゃんけんぽんを押してね",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                pictureBox2.Image = Properties.Resources.pa;
                var player = new System.Media.SoundPlayer(Properties.Resources.pa1);
                player.PlaySync();
                show_hand(3);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
