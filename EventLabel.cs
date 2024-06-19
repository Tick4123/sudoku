using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    partial class Easy : Form
    {
        Label label;
        public void pointSelect(Label label)
        {
            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    this.Controls["p_" + i + "_" + j].BackColor = Color.FromArgb(56, 56, 56);
                }
            }
            if (this.label == null)
            {
                int point1 = int.Parse(label.Name.Substring(2, 1));
                int point2 = int.Parse(label.Name.Substring(4, 1));

                pointBoxSelect(point1, point2);
                pointNumSelect(point1, point2);
                label.BackColor = Color.FromArgb(0, 162, 232);
                
                CheckedNum(point1, point2);
                this.label = label;
            }
            else if (this.label != label)
            {
                int point1 = int.Parse(label.Name.Substring(2, 1));
                int point2 = int.Parse(label.Name.Substring(4, 1));

                this.label.BackColor = Color.FromArgb(56, 56, 56);
                pointBoxSelect(point1, point2);
                pointNumSelect(point1, point2);
                label.BackColor = Color.FromArgb(0, 162, 232);
                
                CheckedNum(point1, point2);
                this.label = label;
            }
            else
            {
                int point1 = int.Parse(label.Name.Substring(2, 1));
                int point2 = int.Parse(label.Name.Substring(4, 1));

                this.label.BackColor = Color.FromArgb(56, 56, 56);
                pointBoxSelect(point1, point2);
                pointNumSelect(point1, point2);
                label.BackColor = Color.FromArgb(0, 162, 232);
                
                CheckedNum(point1, point2);
            }

        }
        
        public void pointBoxSelect(int point1, int point2)
        {
            for(int i = 0; i < 9; i++)
            {
                this.Controls["p_" + i + "_" + point2].BackColor = Color.FromArgb(43, 43, 43);
            }
            for (int i = 0; i < 9; i++)
            {
                this.Controls["p_" + point1 + "_" + i].BackColor = Color.FromArgb(43, 43, 43);
            }

            int x1 = 0, x2 = 0;
            int y1 = 0, y2 = 0;

            if (point1 >= 0 && point1 <= 2)
            {
                x1 = 0;
                x2 = 2;
            }
            else if (point1 >= 3 && point1 <= 5)
            {
                x1 = 3;
                x2 = 5;
            }
            else if (point1 >= 6 && point1 <= 8)
            {
                x1 = 6;
                x2 = 8;
            }

            if (point2 >= 0 && point2 <= 2)
            {
                y1 = 0;
                y2 = 2;
            }
            else if (point2 >= 3 && point2 <= 5)
            {
                y1 = 3;
                y2 = 5;
            }
            else if (point2 >= 6 && point2 <= 8)
            {
                y1 = 6;
                y2 = 8;
            }

            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    this.Controls["p_" + i + "_" + j].BackColor = Color.FromArgb(43, 43, 43);
                }
            }
        }

        public void pointNumSelect(int point1, int point2)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (pointNum[point1,point2] == pointNum[i,j] && pointNum[point1,point2] != 0 && (point1 != i || point2 != j))
                        this.Controls["p_" + i + "_" + j].BackColor = Color.FromArgb(30, 30, 30);
                }
            }
        }

        private void p_0_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_0);
        }

        private void p_0_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_1);
        }

        private void p_0_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_2);
        }

        private void p_0_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_3);
        }

        private void p_0_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_4);
        }

        private void p_0_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_5);
        }

        private void p_0_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_6);
        }

        private void p_0_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_7);
        }

        private void p_0_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_0_8);
        }

        private void p_1_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_0);
        }

        private void p_1_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_1);
        }

        private void p_1_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_2);
        }

        private void p_1_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_3);
        }

        private void p_1_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_4);
        }

        private void p_1_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_5);
        }

        private void p_1_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_6);
        }

        private void p_1_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_7);
        }
        private void p_1_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_1_8);
        }

        private void p_2_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_0);
        }

        private void p_2_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_1);
        }

        private void p_2_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_2);
        }

        private void p_2_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_3);
        }

        private void p_2_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_4);
        }

        private void p_2_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_5);
        }

        private void p_2_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_6);
        }

        private void p_2_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_7);
        }

        private void p_2_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_2_8);
        }

        private void p_3_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_0);
        }

        private void p_3_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_1);
        }

        private void p_3_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_2);
        }

        private void p_3_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_3);
        }

        private void p_3_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_4);
        }

        private void p_3_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_5);
        }

        private void p_3_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_6);
        }

        private void p_3_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_7);
        }

        private void p_3_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_3_8);
        }

        private void p_4_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_0);
        }

        private void p_4_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_1);
        }

        private void p_4_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_2);
        }

        private void p_4_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_3);
        }

        private void p_4_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_4);
        }

        private void p_4_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_5);
        }

        private void p_4_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_6);
        }

        private void p_4_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_7);
        }

        private void p_4_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_4_8);
        }

        private void p_5_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_0);
        }

        private void p_5_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_1);
        }

        private void p_5_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_2);
        }

        private void p_5_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_3);
        }

        private void p_5_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_4);
        }

        private void p_5_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_5);
        }

        private void p_5_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_6);
        }

        private void p_5_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_7);
        }

        private void p_5_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_5_8);
        }

        private void p_6_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_0);
        }

        private void p_6_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_1);
        }

        private void p_6_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_2);
        }

        private void p_6_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_3);
        }

        private void p_6_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_4);
        }

        private void p_6_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_5);
        }

        private void p_6_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_6);
        }

        private void p_6_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_7);
        }

        private void p_6_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_6_8);
        }


        private void p_7_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_0);
        }

        private void p_7_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_1);
        }

        private void p_7_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_2);
        }

        private void p_7_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_3);
        }

        private void p_7_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_4);
        }

        private void p_7_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_5);
        }

        private void p_7_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_6);
        }

        private void p_7_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_7);
        }

        private void p_7_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_7_8);
        }

        private void p_8_0_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_0);
        }

        private void p_8_1_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_1);
        }

        private void p_8_2_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_2);
        }

        private void p_8_3_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_3);
        }

        private void p_8_4_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_4);
        }

        private void p_8_5_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_5);
        }

        private void p_8_6_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_6);
        }

        private void p_8_7_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_7);
        }

        private void p_8_8_MouseClick(object sender, MouseEventArgs e)
        {
            pointSelect(p_8_8);
        }
    }
}
