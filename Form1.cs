using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cardProgram;
using cardsForm.Properties;

namespace cardsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Program.counterHands.Add(0);
            }
        }

        public int[] discardChecks = { 0, 0, 0, 0, 0 };

        private void ResetChecks()
        {
            for (int i = 0; i < 5; i++)
            {
                discardChecks[i] = 0;
            }
            checkCard1.Enabled = false;
            checkCard2.Enabled = false;
            checkCard3.Enabled = false;
            checkCard4.Enabled = false;
            checkCard5.Enabled = false;
            checkCard1.Checked = false;
            checkCard2.Checked = false;
            checkCard3.Checked = false;
            checkCard4.Checked = false;
            checkCard5.Checked = false;
        }

        private void DrawButtonState()
        {
            if (checkCard1.Checked == true &&
                checkCard2.Checked == true &&
                checkCard3.Checked == true &&
                checkCard4.Checked == true &&
                checkCard5.Checked == true)
            {
                buttonDrawNew.Enabled = false;
            }
            else if (checkCard1.Checked == true ||
                     checkCard2.Checked == true ||
                     checkCard3.Checked == true ||
                     checkCard4.Checked == true ||
                     checkCard5.Checked == true)
            {
                buttonDrawNew.Enabled = true;
            }
            else 
            {
                buttonDrawNew.Enabled = false;
            }

            int numOfUnchecked = 0;
            foreach (int i in discardChecks)
            {
                numOfUnchecked += i;
            }
            numOfUnchecked = 5 - numOfUnchecked;
            // if there are not enough cards remaining in the deck disable button
            if (Program.deckOfCards.Count < numOfUnchecked)
            {
                buttonDrawNew.Enabled = false;
            }
        }

        // Show the cards in the deck in the order they appear
        private void buttonShowCard_Click(object sender, EventArgs e)
        {
            //Stack<Card> deckOfCards = new Stack<Card>(Card.Deck());
            var rand = new Random();
            int cardNum = rand.Next(52);

            // First one: Random Card. Second one: Cards in order
            //string imagePath = "C:\\Users\\thoma\\OneDrive - University of Waterloo\\Pictures\\cards\\" + Program.deckOfCards.ElementAt(cardNum).GetPath();
            if (Program.deckOfCards.Count != 0)
            {
                string imagePath = "..\\..\\Resources\\" + Program.deckOfCards.Pop().GetPath();
                label1.Text = imagePath;
                cardImage1.Image = Image.FromFile(imagePath);
            }
            else
            {
                label1.Text = "End of deck.";
                cardImage1.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            }
            
            // The thing i'm trying to do here is called reflection, look it up later maybe
            //string filename = "AD";
            //Image myImage = Resources.filename;
            //cardImage1.Image = myImage;
        }

        // Deal a 5 card hand
        private void buttonDealHand_Click(object sender, EventArgs e)
        {
            // Deal Hand
            //List<Card> dealtHand = new List<Card>();
            Program.dealtHand.Clear();
            for (int i = 0; i < 5; i++)
            {
                Program.dealtHand.Add(Program.deckOfCards.Pop());
            }
            string imgFolder = "..\\..\\Resources\\";
            dealtCard1.Image = Image.FromFile(imgFolder + Program.dealtHand[0].GetPath());
            dealtCard2.Image = Image.FromFile(imgFolder + Program.dealtHand[1].GetPath());
            dealtCard3.Image = Image.FromFile(imgFolder + Program.dealtHand[2].GetPath());
            dealtCard4.Image = Image.FromFile(imgFolder + Program.dealtHand[3].GetPath());
            dealtCard5.Image = Image.FromFile(imgFolder + Program.dealtHand[4].GetPath());

            buttonSortHand.Enabled = true;
            ResetChecks();

            if (Program.deckOfCards.Count < 5)
            {
                buttonDealHand.Enabled = false;
            }
        }

        // Sorts the dealt hand
        private void buttonSortHand_Click(object sender, EventArgs e)
        {
            // Sort the hand
            buttonSortHand.Enabled = false;
            Program.sortedHand = Program.SortHand(Program.dealtHand, Program.LessThan);

            string imgFolder = "..\\..\\Resources\\";
            dealtCard1.Image = Image.FromFile(imgFolder + Program.sortedHand[0].GetPath());
            dealtCard2.Image = Image.FromFile(imgFolder + Program.sortedHand[1].GetPath());
            dealtCard3.Image = Image.FromFile(imgFolder + Program.sortedHand[2].GetPath());
            dealtCard4.Image = Image.FromFile(imgFolder + Program.sortedHand[3].GetPath());
            dealtCard5.Image = Image.FromFile(imgFolder + Program.sortedHand[4].GetPath());

            // Get hand strength

            KeyValuePair<string[], List<int>> handStrength = new KeyValuePair<string[], List<int>>();
            handStrength = Poker.GetHandStrength(Program.sortedHand);
            textOutput.Text = handStrength.Key[0] + " " + handStrength.Key[1];
            
            Program.counterHands[handStrength.Value.ElementAt(0)]++;
            Program.counterHands[9]++;
            textTotal.Text = Program.counterHands.ElementAt(9).ToString();

            switch (handStrength.Value.ElementAt(0))
            {
                case 0:
                    textHighCard.Text = Program.counterHands.ElementAt(0).ToString();
                    break;
                case 1:
                    text1Pair.Text = Program.counterHands.ElementAt(1).ToString();
                    break;
                case 2:
                    text2Pair.Text = Program.counterHands.ElementAt(2).ToString();
                    break;
                case 3:
                    textTrips.Text = Program.counterHands.ElementAt(3).ToString();
                    break;
                case 4:
                    textStraight.Text = Program.counterHands.ElementAt(4).ToString();
                    break;
                case 5:
                    textFlush.Text = Program.counterHands.ElementAt(5).ToString();
                    break;
                case 6:
                    textFullH.Text = Program.counterHands.ElementAt(6).ToString();
                    break;
                case 7:
                    textQuads.Text = Program.counterHands.ElementAt(7).ToString();
                    break;
                case 8:
                    textSFlush.Text = Program.counterHands.ElementAt(8).ToString();
                    break;
            }

            // Enable draw boxes
            checkCard1.Enabled = true;
            checkCard2.Enabled = true;
            checkCard3.Enabled = true;
            checkCard4.Enabled = true;
            checkCard5.Enabled = true;
            
        }

        // Clears deck and creates a new shuffled deck
        private void buttonReset_Click(object sender, EventArgs e)
        {
            Program.deckOfCards.Clear();
            Program.deckOfCards = Card.Deck();
            cardImage1.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard1.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard2.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard3.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard4.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard5.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            ResetChecks();
            buttonDealHand.Enabled = true;
        }

        private void checkCard1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCard1.Checked == true)
            {
                discardChecks[0] = 1;
            }
            else
            {
                discardChecks[0] = 0;
            }
            DrawButtonState();
        }

        private void checkCard2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCard2.Checked == true)
            {
                discardChecks[1] = 1;
            }
            else
            {
                discardChecks[1] = 0;
            }
            DrawButtonState();
        }

        private void checkCard3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCard3.Checked == true)
            {
                discardChecks[2] = 1;
            }
            else
            {
                discardChecks[2] = 0;
            }
            DrawButtonState();
        }

        private void checkCard4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCard4.Checked == true)
            {
                discardChecks[3] = 1;
            }
            else
            {
                discardChecks[3] = 0;
            }
            DrawButtonState();
        }

        private void checkCard5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCard5.Checked == true)
            {
                discardChecks[4] = 1;
            }
            else
            {
                discardChecks[4] = 0;
            }
            DrawButtonState();
        }

        private void buttonDrawNew_Click(object sender, EventArgs e)
        {
            Program.dealtHand.Clear();
            for (int i = 0; i < 5; i++)
            {
                if (discardChecks[i] == 1)
                {
                    Program.dealtHand.Add(Program.sortedHand[i]);
                }
            }
            while (Program.dealtHand.Count < 5)
            {
                Program.dealtHand.Add(Program.deckOfCards.Pop());
            }

            // Sort the hand
            Program.sortedHand = Program.SortHand(Program.dealtHand, Program.LessThan);

            string imgFolder = "..\\..\\Resources\\";
            dealtCard1.Image = Image.FromFile(imgFolder + Program.sortedHand[0].GetPath());
            dealtCard2.Image = Image.FromFile(imgFolder + Program.sortedHand[1].GetPath());
            dealtCard3.Image = Image.FromFile(imgFolder + Program.sortedHand[2].GetPath());
            dealtCard4.Image = Image.FromFile(imgFolder + Program.sortedHand[3].GetPath());
            dealtCard5.Image = Image.FromFile(imgFolder + Program.sortedHand[4].GetPath());

            // Get hand strength

            KeyValuePair<string[], List<int>> handStrength = new KeyValuePair<string[], List<int>>();
            handStrength = Poker.GetHandStrength(Program.sortedHand);
            textOutput.Text = handStrength.Key[0] + " " + handStrength.Key[1];

            Program.counterHands[handStrength.Value.ElementAt(0)]++;
            Program.counterHands[9]++;
            textTotal.Text = Program.counterHands.ElementAt(9).ToString();

            switch (handStrength.Value.ElementAt(0))
            {
                case 0:
                    textHighCard.Text = Program.counterHands.ElementAt(0).ToString();
                    break;
                case 1:
                    text1Pair.Text = Program.counterHands.ElementAt(1).ToString();
                    break;
                case 2:
                    text2Pair.Text = Program.counterHands.ElementAt(2).ToString();
                    break;
                case 3:
                    textTrips.Text = Program.counterHands.ElementAt(3).ToString();
                    break;
                case 4:
                    textStraight.Text = Program.counterHands.ElementAt(4).ToString();
                    break;
                case 5:
                    textFlush.Text = Program.counterHands.ElementAt(5).ToString();
                    break;
                case 6:
                    textFullH.Text = Program.counterHands.ElementAt(6).ToString();
                    break;
                case 7:
                    textQuads.Text = Program.counterHands.ElementAt(7).ToString();
                    break;
                case 8:
                    textSFlush.Text = Program.counterHands.ElementAt(8).ToString();
                    break;
            }

            if (Program.deckOfCards.Count < 5)
            {
                buttonDealHand.Enabled = false;
            }

            ResetChecks();
            buttonDrawNew.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
