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
using System.Windows.Forms.Design.Behavior;

namespace Sudoku
{
    partial class Easy : Form
    {
        Stack<ReturnBox> rbStack = new Stack<ReturnBox>();
        Stack<SaveMemoStruct> rmStack = new Stack<SaveMemoStruct>();
        public struct ReturnBox
        {
            public int point1;
            public int point2;

            public bool memoCheck;
            public bool[] numCheck;

            public int beforeNum;

            public Label saveLabel;
        }

        public struct SaveMemoStruct
        {
            public bool[,,] saveMemo;
            public bool checkM;
        }
        public void DeleteMemo(Label label)
        {
            int point1 = int.Parse(label.Name.Substring(2, 1));
            int point2 = int.Parse(label.Name.Substring(4, 1));
            int cnt = 0;
            //MessageBox.Show(point1+" "+point2);
            bool[,,] saveMemo = new bool[9,9,9];
            if(pointNum[point1, point2] > 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (memoBool[i, point2, pointNum[point1, point2]-1] && (point1 != i))
                    {
                        saveMemo[i, point2, pointNum[point1, point2] - 1] = true;
                        memoBool[i, point2, pointNum[point1, point2] - 1] = false;
                        cnt++;

                        string str = "";
                        for (int n = 0; n < 9; n++)
                        {
                            if (memoBool[i, point2, n])
                                str += string.Format($"{n + 1}");
                            else
                                str += "  ";
                            if (n + 1 % 3 == 0)
                                str += "\n";
                            else if (n != 8)
                                str += " ";
                        }
                        this.Controls["p_" + i + "_" + point2].Text = str;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    if (memoBool[point1, i, pointNum[point1, point2] - 1] && (point2 != i))
                    {
                        saveMemo[point1, i, pointNum[point1, point2] - 1] = true;
                        memoBool[point1, i, pointNum[point1, point2] - 1] = false;
                        cnt++;

                        string str = "";
                        for (int n = 0; n < 9; n++)
                        {
                            if (memoBool[point1, i, n])
                                str += string.Format($"{n + 1}");
                            else
                                str += "  ";
                            if (n + 1 % 3 == 0)
                                str += "\n";
                            else if (n != 8)
                                str += " ";
                        }
                        this.Controls["p_" + point1 + "_" + i].Text = str;
                    }
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
                        if ((point1 != i || point2 != j) && memoBool[i, j, pointNum[point1, point2] - 1])
                        {
                            saveMemo[i, j, pointNum[point1, point2] - 1] = true;
                            memoBool[i, j, pointNum[point1, point2] - 1] = false;
                            cnt++;

                            string str = "";
                            for (int n = 0; n < 9; n++)
                            {
                                if (memoBool[i, j, n])
                                    str += string.Format($"{n + 1}");
                                else
                                    str += "  ";
                                if (n + 1 % 3 == 0)
                                    str += "\n";
                                else if (n != 8)
                                    str += " ";
                            }
                            this.Controls["p_" + i + "_" + j].Text = str;
                        }
                    }
                }
                if (cnt > 0)
                {
                    SaveMemo(saveMemo, true);
                }
                else
                    SaveMemo(saveMemo, false);
            }
            else
                SaveMemo(saveMemo, false);

        }
        public void SaveMemo(bool[,,] saveMemo, bool check = false)
        {
            SaveMemoStruct smt = new SaveMemoStruct();
            smt.saveMemo = new bool[9,9,9];
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    for(int k = 0; k < 9; k++)
                    {
                        smt.saveMemo[i, j,k] = saveMemo[i, j,k];
                    }
                }
            }
            smt.checkM = check;

            rmStack.Push(smt);
        }

        public void ReturnMemo()
        {
            if(rmStack.Count > 0 )
            {
                SaveMemoStruct smt = rmStack.Pop();
                if(smt.checkM)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                if (smt.saveMemo[i, j,k])
                                {
                                    memoBool[i,j,k] = true;
                                    string str = "";
                                    for (int n = 0; n < 9; n++)
                                    {
                                        if (memoBool[i, j, n])
                                            str += string.Format($"{n + 1}");
                                        else
                                            str += "  ";
                                        if (n + 1 % 3 == 0)
                                            str += "\n";
                                        else if (n != 8)
                                            str += " ";
                                    }
                                    this.Controls["p_" + i + "_" + j].Text = str;
                                }
                            }
                            
                        }
                    }
                }
            }
        }

        public void ReturnNum()
        {
            if(rbStack.Count > 0)
            {
                ReturnBox rb = rbStack.Pop();
                if(rb.memoCheck == false && rb.beforeNum != 0)
                {
                    if (rb.beforeNum == 0)  //필요 없어진 조건문    
                    {
                        this.Controls["p_" + rb.point1 + "_" + rb.point2].Text = "";
                        pointNum[rb.point1, rb.point2] = 0;
                    }
                    else
                    {
                        this.Controls["p_" + rb.point1 + "_" + rb.point2].Text = rb.beforeNum.ToString();
                        pointNum[rb.point1, rb.point2] = rb.beforeNum;
                    }

                    pointSelect(rb.saveLabel);
                }
                else
                {
                    this.Controls["p_" + rb.point1 + "_" + rb.point2].ForeColor = SystemColors.GradientActiveCaption;
                    this.Controls["p_" + rb.point1 + "_" + rb.point2].Font = new Font("맑은 고딕", 7, FontStyle.Regular);

                    string str = "";
                    for (int n = 0; n < 9; n++)
                    {
                        memoBool[rb.point1, rb.point2, n] = rb.numCheck[n];
                        if (rb.numCheck[n])
                            str += string.Format($"{n + 1}");
                        else
                            str += "  ";
                        if (n + 1 % 3 == 0)
                            str += "\n";
                        else if (n != 8)
                            str += " ";
                    }
                    this.Controls["p_" + rb.point1 + "_" + rb.point2].Text = str;
                    
                    pointNum[rb.point1, rb.point2] = rb.beforeNum;
                    pointBoxSelect(rb.point1, rb.point2);
                    
                    if (rb.beforeNum > 0)
                    {
                        this.Controls["p_" + rb.point1 + "_" + rb.point2].ForeColor = SystemColors.HotTrack;
                        this.Controls["p_" + rb.point1 + "_" + rb.point2].Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                        this.Controls["p_" + rb.point1 + "_" + rb.point2].Text = rb.beforeNum.ToString();
                        
                    }
                    pointSelect(rb.saveLabel);
                }
            }    
        }

        public void SaveNum(Label label,int num, bool check = false) 
        {
            ReturnBox rb = new ReturnBox();

            int point1 = int.Parse(label.Name.Substring(2, 1));
            int point2 = int.Parse(label.Name.Substring(4, 1));

            rb.point1 = point1;
            rb.point2 = point2;

            rb.beforeNum = num;

            rb.memoCheck = check;
            rb.numCheck = new bool[9];
            for(int i = 0; i < 9; i++)
            {
                rb.numCheck[i] = memoBool[point1, point2, i];
            }

            rb.saveLabel = label;

            rbStack.Push(rb);
        }
        private void bt_Return_Click(object sender, EventArgs e)
        {
            ReturnNum();
            ReturnMemo();
        }

        private void bt_Easer_Click(object sender, EventArgs e)
        {// 메모 삭제 추가 (완)
            if(this.label != null)
            {
                int point1 = int.Parse(label.Name.Substring(2, 1));
                int point2 = int.Parse(label.Name.Substring(4, 1));
                int cnt = 0;

                if(this.Controls["p_" + point1 + "_" + point2].ForeColor.Equals(Color.White))
                {
                    return;
                }
                if (pointNum[point1, point2] !=0)
                {
                    SaveNum(this.label, pointNum[point1, point2]);
                    this.Controls["p_" + point1 + "_" + point2].Text = "";
                    pointNum[point1, point2] = 0;
                    pointSelect(this.label);
                    DeleteMemo(this.label);
                }
                else
                {
                    for(int i = 0; i < 9; i++)
                    {
                        if (memoBool[point1, point2, i] == true)
                            cnt++;
                    }
                    if (cnt == 0)
                        return;
                    else
                    {
                        SaveNum(this.label, 0, true);
                        DeleteMemo(this.label);
                        for (int i = 0;i < 9;i++)
                            memoBool[point1, point2, i] = false;
                        this.Controls["p_" + point1 + "_" + point2].Text = "";
                    }
                }
            }
        }
    }
}
