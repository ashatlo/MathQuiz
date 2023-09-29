namespace MathQuiz
{
    public partial class Quiz : Form
    {
          Button[,] button;
          string number = string.Empty;
          int result = 0;
          int correct = 0;
          List<Equasion> equasions = new List<Equasion>();
        public Quiz()
        {
            InitializeComponent();
            button = new Button[5, 5]
            {
            { btn1,btn2,btn3,btn4,btn5},
            { btn6,btn7,btn8,btn9,btn10},
            { btn11,btn12,btn13,btn14,btn15},
            { btn16,btn17,btn18,btn19,btn20},
            { btn21,btn22,btn23,btn24,btn25},
            };

            Equasion e1 = new Equasion();
            e1.buttons = new List<Button>() { btn1, btn2, btn3, btn4, btn5 };
            e1.Active = true;
            equasions.Add(e1);

            Target();
    }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
           List<string> input = new List<string>();
           int u = 0;
           int userResult = 0;

           foreach (Equasion equasion  in equasions)
           {
                string firstNumber = equasion.buttons[0].Text;
              switch (firstNumber)
              {
               case "+":
               userResult += int.Parse(input[u + 1]);
               u++;
               break;
               case "-":
               userResult -= int.Parse(input[u + 1]);
               u++;
               break;
               case "*":
               userResult *= int.Parse(input[u + 1]);
               u++;
               break;
               case "/":
               userResult /= int.Parse(input[u + 1]);
               u++;
               break;
               }
           } 
            MessageBox.Show(userResult.ToString());
            return;
         }
       #region finished
        private void tsQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Target()
        {
            Random rand = new Random();
            int min = 30;
            int max = 200;
            string[] operators = new string[] { "+", "-", "*", "/" };
            int[] operands = new int[3];

            bool validResult = false;
            while (!validResult)
            {
                for (int x = 0; x < 3; x++)
                {
                    operands[x] = rand.Next(1, 9);
                }
                int numOperators = 2;
                string[] chosenOperations = new string[numOperators];
                for (int x = 0; x < numOperators; x++)
                {
                    chosenOperations[x] = operators[rand.Next(0, 4)];
                }

                result = operands[0];
                for (int y = 0; y < numOperators; y++)
                {
                    switch (chosenOperations[y])
                    {
                        case "+":
                            result += operands[y + 1];
                            break;
                        case "-":
                            result -= operands[y + 1];
                            break;
                        case "*":
                            result *= operands[y + 1];
                            break;
                        case "/":
                            result /= operands[y + 1];
                            break;
                    }
                }
                if (result >= min && result <= max)
                {
                    // txtTarget.Text = result + " = " + operands[0];
                    validResult = true;
                    for (int x = 0; x < numOperators; x++)

                    {
                        // string target = result + " = " + operands[0]+ chosenOperations[x] + operands[x + 1];
                        txtTarget.Text = "   " + "Find the hidden calculation that equals" + "  " + result;
                    }
                }
            }
        }
        private void highScore_Click(object sender, EventArgs e)
        {
            String Score = "";

            StreamWriter sw = File.AppendText(@"C:\Users\Ahmad\source\repos\MathQuiz\Score\HighScore.txt");
            sw.Write("");
            sw.WriteLine(Score);
            sw.Close();
        }
        private void targetNumber(object sender, EventArgs e)
        {
            number = ((Button)sender).Text;

            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (button[i, x].Text == string.Empty)
                    {
                        button[i, x].Text = number;

                        return;
                    }
                    if (button[i, x].Text == button[0, 4].Text)
                    {
                        button[i, x].Enabled = true;
                        i--;
                        return;
                    }
                }
            }
        }
        private void opNumber(object sender, EventArgs e)
        {
            string op = ((Button)sender).Text;
            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (button[i, x].Text == string.Empty)
                    {
                        button[i, x].Text = op;

                        return;
                    }
                    if (button[i, x].Text == button[0, 4].Text)
                    {
                        button[i, x].Enabled = true;
                        i--;
                        return;
                    }
                }
            }
        }
        private void tsRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    button[i, x].Enabled = true;
                    button[i, x].Text = string.Empty;
                    button[i, x].BackColor = Color.Gainsboro;
                }
            }
        }
        #endregion 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int x = 4; x >= 0; x--)
                {
                    if (button[i, x].Text.Length > 0)
                    {
                        button[i, x].Text = button[i, x].Text.Remove(button[i, x].Text.Length - 1);
                        return;
                    }
                }
            }
        }

    }
}