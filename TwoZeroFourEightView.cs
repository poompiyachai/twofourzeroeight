﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
        int sum = 0;
        int keepsum = 0;

        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
                 if (i.ToString().Length == 4)
                {
                    l.Font = new Font("Microsoft Sans Serif", 14);
                }
                if (i.ToString().Length == 3){
                    l.Font = new Font("Microsoft Sans Serif", 16);
                                   }
                if (i.ToString().Length == 2){
                    l.Font = new Font("Microsoft Sans Serif", 20);
                                    }
            } else {
                l.Text = "";
               
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);

            sum = 0;

            for (int i = 0;i<=3;i++)
            {
                for(int j=0;j<=3; j++)
                {
                    sum += board[i, j];
                }
            }
                 if(sum!=0)
                    {

                textBox1.Text = sum.ToString();
                 keepsum = sum;
              
                     }
            else
            {
                textBox1.Text = "gameover     " + "score = " + keepsum.ToString();
            }

                
            
            
            
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }

        private void TwoZeroFourEightView_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
         {
             switch (keyData)
             {
                 case Keys.Up:
                     controller.ActionPerformed(TwoZeroFourEightController.UP);
                     break;
                 case Keys.Right:
                     controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                     break;
                 case Keys.Down:
                     controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                     break;
                 case Keys.Left:
                     controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                     break;
                 default:
                     break;
             }
             return base.ProcessCmdKey(ref msg, keyData);
         }
    }
}
