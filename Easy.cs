using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Easy : Form
    {
        private int difficulty;
        public Easy(int number)
        {
            InitializeComponent();
            timer1.Start();
            difficulty = number;
            if (number == 1)
            {
                label1.Text = "Easy";
                for (int n = 0; n < easy1.GetLength(0); n++)
                {
                    this.Controls["p_" + easy1[n, 0] + "_" + easy1[n, 1]].Text = easy1[n, 2].ToString();
                    this.Controls["p_" + easy1[n, 0] + "_" + easy1[n, 1]].ForeColor = Color.White;
                    pointNum[easy1[n, 0], easy1[n, 1]] = easy1[n, 2];
                }

            }
            else if (number == 2)
            {
                label1.Text = "Normal";
                for (int n = 0; n < normal1.GetLength(0); n++)
                {
                    this.Controls["p_" + normal1[n, 0] + "_" + normal1[n, 1]].Text = normal1[n, 2].ToString();
                    this.Controls["p_" + normal1[n, 0] + "_" + normal1[n, 1]].ForeColor = Color.White;
                    pointNum[normal1[n, 0], normal1[n, 1]] = normal1[n, 2];
                }
            }
            else if (number == 3)
            {
                label1.Text = "Hard";
                for (int n = 0; n < hard1.GetLength(0); n++)
                {
                    this.Controls["p_" + hard1[n, 0] + "_" + hard1[n, 1]].Text = hard1[n, 2].ToString();
                    this.Controls["p_" + hard1[n, 0] + "_" + hard1[n, 1]].ForeColor = Color.White;
                    pointNum[hard1[n, 0], hard1[n, 1]] = hard1[n, 2];
                }
            }
        }

        public void Clear()
        {
            timer1.Stop();
            MessageBox.Show("클리어");
            this.Hide();
            ClearMenu cm = new ClearMenu(difficulty, second);
            cm.ShowDialog();
            this.Close();

        }
        int second = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            lb_Time.Text = string.Format("{0}시간 {1}분 {2}초", second / 3600, second / 60 % 60, second % 60);
        }

        private void Easy_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.label != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        this.Controls["p_" + i + "_" + j].BackColor = Color.FromArgb(56, 56, 56);
                    }
                }
                this.label = null;
            }
        }

        private void Easy_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    button1_Click(sender, e);
                    break;
                case Keys.D2:
                    button2_Click(sender, e);
                    break;
                case Keys.D3:
                    button3_Click(sender, e);
                    break;
                case Keys.D4:
                    button4_Click(sender, e);
                    break;
                case Keys.D5:
                    button5_Click(sender, e);
                    break;
                case Keys.D6:
                    button6_Click(sender, e);
                    break;
                case Keys.D7:
                    button7_Click(sender, e);
                    break;
                case Keys.D8:
                    button8_Click(sender, e);
                    break;
                case Keys.D9:
                    button9_Click(sender, e);
                    break;
            }
        }
    }
}
