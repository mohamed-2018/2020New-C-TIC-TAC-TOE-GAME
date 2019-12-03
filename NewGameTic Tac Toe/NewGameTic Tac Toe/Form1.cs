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
    public partial class Form1 : Form
    {
        // assume player 1 is X and player 2 is O 
       bool turn =true; // true =x   or false = o
        bool aganist_computer = false;

        int turn_count = 0;
        static string player1, player2;
        static string x, o;  // IN CASE SET X O FOR PLAYERS 
        public Form1()
        {
            InitializeComponent();
           
        }
        public static void setPlayerNames(string n1, string n2) // set names of players
        {
            player1 = n1;
            player2 = n2;
        }
        //public static void setTurn(string z1, string z2)  // in case set x or o for players 
        //{
        //    x = z1;
        //    o = z2;
        //}

     
        private void Button_Click(object sender, EventArgs e)  // mouse click 
        {
            Button b = (Button)sender;  // object from sender 
            if (turn)
                b.Text = "X";

            else
                b.Text = "O";
            turn = !turn;  // true convert to false and vise versa 
            b.Enabled = false; // to keep the value of button 
            turn_count++;
            checkForWinner();

            // check to see if playing against computer and if it is 0 trurn
                if ((!turn) && (aganist_computer))
            {
                computer_make_move();  // calling computer move method
            }
        }
      
        private void computer_make_move()
        {
            // prirority 1: get Tic Tac Toe
            // priority 2: block x Tic Tac Toe
            //priority 3: go for corner space
            // priority 4: pick open space 
            Button move = null;
            // look for Tic Tac Toe oppertunities
            move = look_for_win_or_block("O"); // look for winining  
            if (move == null)
            {
                move = look_for_win_or_block("X"); // look for block (X) To prevent  other player as X to win 
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
                if(move==null)
                {
                    return ;
                }
            }
            move.PerformClick();
        }
        private Button look_for_win_or_block(string mark)
        {

            Console.WriteLine("look for win or block: " + mark);
            // horizental tests
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;
            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;
            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;
            //vertical tests
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;
            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;
            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;
            //diaognal tsets
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;
            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;
            return null; // incase all of above isn't true 

        }
        private Button look_for_corner()
        {
            Console.WriteLine("look for acorner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }
            if (C1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (A1.Text == "")
                    return A1;
            }
            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;
            //if (A2.Text == "")  //  computer check for empty position  and fill it 
            //    return A2;
            //if (C2.Text == "")
            //    return C2;
            //if (B1.Text == "")
            //    return B1;
            //if (B2.Text == "")
            //    return B2;
            //if (B3.Text == "")
            //    return B3;

            return null; // if the above isn't occured 


        }
        private Button look_for_open_space()
        {
            Console.WriteLine("lokking for open space ");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;

                }
            }
            return null; // incase all the above isn't occured 
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            // horizental checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            //  vertical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //   diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
             
                diablebutton();
                string winner = "";
                if (turn)
                {
                    winner = player2;
                    MessageBox.Show(winner + " Wins", "WOW");
                    diablebutton();
                    O_win_count.Text = (Int32.Parse(O_win_count.Text) + 1).ToString(); // label O_win_count  turn it to int value (+1) is mean the first win of O as O_win is zero at first 
                   
                }
                else
                {

                    winner = player1;
                    MessageBox.Show(winner + " Wins", "WOW");
                    diablebutton();
                    X_win_count.Text = (Int32.Parse(X_win_count.Text) + 1).ToString();
                   
                }
            }
            else
            {
                if (turn_count == 9 && !there_is_a_winner)
                {
                    MessageBox.Show("Draw !", "Bummer");
                    diablebutton();
                    Draw_count.Text = (Int32.Parse(Draw_count.Text) + 1).ToString();
                    
                }
            }
        

        }
        private void diablebutton()  //disable button after winner or Draw detected 
        {
            A1.Enabled = false; A2.Enabled = false;A3.Enabled = false;
            B1.Enabled = false; B2.Enabled = false; B3.Enabled = false;
            C1.Enabled = false; C2.Enabled = false; C3.Enabled = false;
           
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();  // create object from form2 
            f2.ShowDialog();
            p1.Text = player1; // note put label 1 insted of p1 in case of put them as labels not textbox and so on 
            p2.Text = player2;




        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
                aganist_computer = false;
                turn = true;
                turn_count = 0;
            A1.Enabled = true; A2.Enabled = true; A3.Enabled = true;
            B1.Enabled = true; B2.Enabled = true; B3.Enabled = true;
            C1.Enabled = true; C2.Enabled = true; C3.Enabled = true;
            A1.Text = ""; A2.Text = ""; A3.Text = "";
            B1.Text = ""; B2.Text = ""; B3.Text = "";
            C1.Text = ""; C2.Text = ""; C3.Text = "";
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender; // make areference  of button b
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "Y";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender; // make areference  of button b
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void button_laeve(object sender, EventArgs e)
        {

        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "COMPUTER") // p2 become computer
                aganist_computer = true;
            else
                aganist_computer = false;
        }

        private void newGameToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About Menu", "Tic Tac Toe Game");
        }

        private void p1_Click(object sender, EventArgs e)
        {

        }

        private void restCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_win_count.Text = "0";
            X_win_count.Text = "0";
            Draw_count.Text = "0";


        }
    }
}
