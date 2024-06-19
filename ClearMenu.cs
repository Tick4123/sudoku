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
    public partial class ClearMenu : Form
    {
        public ClearMenu(int difficulty, int second)
        {
            InitializeComponent();
            //Normal : 29, 75, Easy,Hard : 44, 75
            if (difficulty == 1)
            {
                label2.Location.Offset(44, 75);
                label2.Text = "Easy 난이도를 클리어 하였습니다";
            }
            else if (difficulty == 2)
            {
                label2.Location.Offset(29, 75);
                label2.Text = "Normal 난이도를 클리어 하였습니다";
            }
            else if (difficulty == 3)
            {
                label2.Location.Offset(44, 75);
                label2.Text = "Hard 난이도를 클리어 하였습니다";
            }
            label3.Text = String.Format($"클리어 타임 : {second / 3600}시간 {second / 60 % 60}분 {second % 60}초");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
            mf.ShowDialog();
            this.Close();
        }
    }
}
