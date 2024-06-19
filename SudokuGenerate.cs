﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public int[,] easy1 = { { 0, 0, 5 }, { 0, 2, 1 }, { 0, 3, 6 }, { 0,5,7},{ 0, 6, 9 },
        {1,2,9 }, {1,5,3 },{1,6,2 },{1,7,5 },{2,0,8 },{2,1,2 },{2,2,7 },{2,4,9 },
        {3,0,9 },{3,2,2 },{3,4,5 },{3,5,1 },{3,6,3 },{3,7,7 }, {4,0,3 },{4,3,9 },
        {4,4,8 },{5,2,5 },{5,3,7 },{5,5,6 }, {6,0,4 },{6,2,6 },{6,4,7 },{6,5,5 },
        {6,7,3 },{6,8,2 },{7,1,1 },{7,6,7 },{7,8,5 },{8,2,3 },{8,6,1 },{8,7,9 },{8,8,6 } };

        public int[,] normal1 = { { 0, 3, 3}, { 0, 7, 6 }, { 0, 8, 2 }, { 1, 1, 7 }, { 1, 2, 3 },
        {1, 3, 4 }, {2, 0, 2 }, { 2, 6, 3 }, { 3, 3, 9 }, {3, 4, 8,}, {3, 6, 5 }, {3, 7, 3 }, {3,8,1},
        {4,2, 1 }, {4, 5, 7}, {4, 7 , 4 }, {4, 8 , 9 }, {5, 3, 6}, {6, 2, 6 }, {6,6,2}, {6, 7, 1}, {6, 8, 8},
        {7, 2, 4 }, {7, 5, 6}, { 7, 7, 5}, {8, 1, 1 }, {8, 2, 7 }, {8, 4, 3 }, {8, 5, 2 }, {8, 7, 9 } };

        public int[,] hard1 = { { 0, 1, 6 }, { 0, 2, 5 }, { 0, 3, 2 }, { 0, 5, 9 },{ 0, 6, 3 }, { 1, 1, 8 },
        {1, 8, 1 }, {2, 4, 6 }, {3, 2, 6 }, {3, 4, 3 }, {4, 1,5 },{4,3,6 },{4,5,4 },{4,7,8 },
        {5,4,7 },{5,6,4 },{6,5,7 }, {7,2,2 },{7,3,4 },{7,5,5 },{7,6,9 },{8,0,9 },{8,7,3 } };
    }
    
}