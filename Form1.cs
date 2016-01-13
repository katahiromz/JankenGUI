using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace JankenGUI
{
    public partial class Form1 : Form
    {
        bool start = false;

        SoundPlayer gu_player = new SoundPlayer(Properties.Resources.gu1);
        SoundPlayer choki_player = new SoundPlayer(Properties.Resources.choki1);
        SoundPlayer pa_player = new SoundPlayer(Properties.Resources.pa1);
        SoundPlayer kachi_player = new SoundPlayer(Properties.Resources.kachi);
        SoundPlayer make_player = new SoundPlayer(Properties.Resources.make);
        SoundPlayer aiko_player = new SoundPlayer(Properties.Resources.aikodesho);
        SoundPlayer janken_player = new SoundPlayer(Properties.Resources.jankenpon);

        enum HanteiKekka {
            HANTEI_KACHI,
            HANTEI_MAKE,
            HANTEI_AIKO
        };

        public Form1()
        {
            InitializeComponent();
        }

        void show_hand(int player_hand)
        {
            janken_player.Stop();
            aiko_player.Stop();
            button4.Visible = false;
            if (!start)
            {
                //メッセージボックスを表示する
                MessageBox.Show("じゃんけんぽんを押してね",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            switch (player_hand)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources.gu;
                    gu_player.PlaySync();
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources.choki;
                    choki_player.PlaySync();
                    break;
                case 3:
                    pictureBox2.Image = Properties.Resources.pa;
                    pa_player.PlaySync();
                    break;
            }

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
            bool aiko = false;
            switch (hantei(player_hand, comp_hand))
            {
                case HanteiKekka.HANTEI_KACHI:
                    label3.Text = "あなたの勝ちです";
                    kachi_player.Play();
                    break;
                case HanteiKekka.HANTEI_MAKE:
                    label3.Text = "あなたの負けです";
                    make_player.Play();
                    break;
                case HanteiKekka.HANTEI_AIKO:
                    label3.Text = "あいこ";
                    aiko = true;
                    break;
            }
            if (aiko)
            {
                aiko_player.Play();
            }
            else
            {
                //スタートをリセット
                start = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
            }

        }

        int get_comp_hand()
        {
            Random cRnd = new System.Random();    // インスタンスを生成 
            return cRnd.Next(1, 4);       // １以上４未満の乱数を取得
        }

        HanteiKekka hantei(int player_hand, int comp_hand)
        {
            if (player_hand == comp_hand)
            {
                return HanteiKekka.HANTEI_AIKO;
            }
            else if ((3 + player_hand - comp_hand) % 3 == 1)
            {
                return HanteiKekka.HANTEI_MAKE;
            }
            else
            {
                return HanteiKekka.HANTEI_KACHI;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_hand(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //start
            start = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            label3.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            janken_player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            show_hand(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            show_hand(3);
        }
    }
}
