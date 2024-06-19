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
    partial class Easy : Form
    {
        int[,] pointNum = new int[9,9];
        int count = 0;
        bool memoButton = false;
        bool[,,] memoBool= new bool[9,9,9];
        public void numChange(int i)
        {
            
            if(this.label != null )
            {
                
                if (memoButton == false)
                {
                    int point1 = int.Parse(this.label.Name.Substring(2, 1));
                    int point2 = int.Parse(this.label.Name.Substring(4, 1));

                    for (int m = 0; m < 9; m++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            this.Controls["p_" + m + "_" + j].BackColor = Color.FromArgb(56, 56, 56);
                        }
                    }

                    if (this.Controls["p_" + point1 + "_" + point2].ForeColor.Equals(Color.White))
                    {
                        return;
                    }

                    this.Controls["p_" + point1 + "_" + point2].ForeColor = SystemColors.HotTrack;
                    this.Controls["p_" + point1 + "_" + point2].Font = new Font("맑은 고딕", 12, FontStyle.Bold);


                    if (pointNum[point1, point2] != i)
                    {
                        SaveNum(this.label, pointNum[point1, point2]);
                        this.label.Text = i.ToString();
                        pointNum[point1, point2] = i;
                        DeleteMemo(this.label);
                    }

                    for (int n = 0; n < 9; n++)
                    {
                        memoBool[point1, point2, n] = false;
                    }

                    pointBoxSelect(point1, point2);
                    pointNumSelect(point1, point2);
                    label.BackColor = Color.FromArgb(0, 162, 232);
                    CheckedNum(point1, point2);

                    //종료 조건문 
                    for (int n = 0; n < 9; n++)
                    {
                        for (int m = 0; m < 9; m++)
                        {
                            if (pointNum[n, m] == 0)
                            {
                                return;
                            }
                        }
                    }
                    count = 0;
                    for (int n = 0; n < 9; n++)
                    {
                        for (int m = 0; m < 9; m++)
                        {
                            CheckedNum(n, m, 1);
                        }
                    }
                    if (count == 0)
                    {
                        Clear();
                    }
                }
                else    //memo모드 ON
                {
                    int point1 = int.Parse(this.label.Name.Substring(2, 1));
                    int point2 = int.Parse(this.label.Name.Substring(4, 1));
                    
                    for (int m = 0; m < 9; m++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            this.Controls["p_" + m + "_" + j].BackColor = Color.FromArgb(56, 56, 56);
                        }
                    }

                    if (this.Controls["p_" + point1 + "_" + point2].ForeColor.Equals(Color.White))
                    {
                        return;
                    }
                    //기본 : 맑은 고딕, 12pt, style=Bold
                    this.Controls["p_" + point1 + "_" + point2].ForeColor = SystemColors.GradientActiveCaption;
                    this.Controls["p_" + point1 + "_" + point2].Font = new Font("맑은 고딕", 7, FontStyle.Regular);

                    string str = "";

                    SaveNum(this.label, pointNum[point1, point2], true);
                    DeleteMemo(this.label);

                    if (memoBool[point1, point2, i-1] == true)
                    {
                        memoBool[point1, point2, i-1] = false;
                    }
                    else
                    {
                        memoBool[point1, point2, i-1] = true;
                    }

                    for(int n = 0; n < 9; n++)
                    {
                        if (memoBool[point1, point2, n])
                            str += string.Format($"{n+1}");
                        else
                            str += "  ";
                        if (n + 1 % 3 == 0)
                            str += "\n";
                        else if(n != 8)
                            str += " ";
                    }

                    pointNum[point1, point2] = 0;
                    this.Controls["p_" + point1 + "_" + point2].Text = str;
                    


                    pointBoxSelect(point1, point2);
                    //pointNumSelect(point1, point2);
                    label.BackColor = Color.FromArgb(0, 162, 232);
                }
                
            }
        }

        public void CheckedNum(int point1, int point2, int check = 0)
        {
            //행 체크
            for(int i = 0; i < 9; i++)
            {
                if(point1 != i && pointNum[i, point2] == pointNum[point1, point2] && pointNum[i, point2] != 0)
                {
                    
                    if(check == 1 && count == 0)
                    {
                        count++;
                    }
                    if (check == 0)
                        this.Controls["p_" + i + "_" + point2].BackColor = Color.FromArgb(237, 28, 36);
                }       
            }

            //열 체크
            for(int i = 0;i < 9; i++)
            {
                if(point2 != i && pointNum[point1, i] == pointNum[point1, point2] && pointNum[point1, i] != 0)
                {
                     
                    if (check == 1 && count == 0)
                    {
                        count++;
                    }
                    if (check == 0)
                        this.Controls["p_" + point1 + "_" + i].BackColor = Color.FromArgb(237, 28, 36);
                }
            }
            

            //박스 체크
            int x1 = 0, x2 = 0;
            int y1 = 0, y2 = 0;

            if (point1 >= 0 && point1 <= 2)
            {
                x1 = 0;
                x2 = 2;
            }
            else if (point1 >=3 && point1 <= 5)
            {
                x1 = 3;
                x2 = 5;
            }
            else if (point1 >=6 && point1 <= 8)
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

            for(int i = x1; i <= x2; i++)
            {
                for(int j = y1; j <= y2; j++)
                {
                    if((point1 != i ||  point2 != j) && pointNum[point1, point2] == pointNum[i, j] && pointNum[point1, point2] != 0)
                    {
                        
                        if (check == 1 && count == 0)
                        {
                            count++;
                        }
                        if(check == 0)
                            this.Controls["p_" + i + "_" + j].BackColor = Color.FromArgb(237, 28, 36);
                    }
                }
            }
        }
        private void bt_Memo_Click(object sender, EventArgs e)
        {
            if(memoButton == false)
            {
                memoButton = true;
                bt_Memo.Text = "ON";
                bt_Memo.ForeColor = Color.DodgerBlue;
            }
            else
            {
                memoButton = false;
                bt_Memo.Text = "OFF";
                bt_Memo.ForeColor = Color.Black;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numChange(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numChange(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numChange(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numChange(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numChange(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numChange(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numChange(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numChange(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numChange(9);
        }
    }
}
