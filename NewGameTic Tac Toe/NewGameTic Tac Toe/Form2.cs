using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGameTic_Tac_Toe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((p1.Text =="" ) || (p2.Text == ""))
            {
                MessageBox.Show("pLease enter the corrected data in all fields ");
            }
            else
            {

                Form1.setPlayerNames(p1.Text, p2.Text);  // calling form1 to display names in it and play and enter form1 game menu
                this.Close();
                //Form1.setTurn(p3.Text, p4.Text);  // in case set x or o for players 
                //this.Close();
                
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick(); // perform click on action (press_click) button after move from p2 textbox
        }

        private void Mouse_enter(object sender, EventArgs e)
        {

        }

        private void p3_Click(object sender, EventArgs e)
        {
            
               
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();  // to return dialoge from form 1 to form 2
            //f1.ShowDialog();
        }
    }
}
