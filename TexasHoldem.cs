using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cardProgram;

namespace cardsForm
{
    public partial class TexasHoldem : Form
    {
        public TexasHoldem()
        {
            InitializeComponent();
            Program.counterHands.Clear();
            for (int i = 0; i < 10; i++)
            {
                Program.counterHands.Add(0);
            }
        }

        private void ResetGame()
        {
            Poker.player1Hand.Clear();
            Poker.communityCards.Clear();
            holeCard1.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            holeCard2.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard1.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard2.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard3.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard4.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            dealtCard5.Image = Image.FromFile("..\\..\\Resources\\blue_back.png");
            buttonDealHand.Enabled = true;
        }

        private void TexasHandStrength(List<Card> inHand, List<Card> communityCards)
        {
            KeyValuePair<string[], List<int>> bestHandStrength = new KeyValuePair<string[], List<int>>();
            KeyValuePair<string[], List<int>> currentHandStrength = new KeyValuePair<string[], List<int>>();
            int omitCard1 = 0;
            int omitCard2 = 1;
            bool complete = false;
            // Combined hand is created, consisting of the player cards and community cards
            List<Card> currentHand = new List<Card>();
            List<Card> combinedHand = new List<Card>();
            foreach (Card c in inHand)
            {
                combinedHand.Add(c);
            }
            foreach (Card c in communityCards)
            {
                combinedHand.Add(c);
            }

            // If there are 5 cards
            if (combinedHand.Count == 5)
            {
                bestHandStrength = Poker.GetHandStrength(Program.SortHand(combinedHand, Program.LessThan));
                textOutput.Text = bestHandStrength.Key[0] + " " + bestHandStrength.Key[1];
                foreach (int value in bestHandStrength.Value)
                {
                    lblOutput.Text += value.ToString() + "/";
                }
            }
            // for six cards
            else if (combinedHand.Count == 6)
            {
                // grab the first hand and set it to the best hand
                for (int i = 1; i < 6; i++)
                {
                    currentHand.Add(combinedHand[i]);
                }
                bestHandStrength = Poker.GetHandStrength(Program.SortHand(currentHand, Program.LessThan));
                omitCard1 = 1;

                while (!complete)
                {
                    currentHand.Clear();
                    for (int i = 0; i < 6; i++)
                    {
                        if (i != omitCard1)
                        {
                            currentHand.Add(combinedHand[i]);
                        }
                    }
                    currentHandStrength = Poker.GetHandStrength(Program.SortHand(currentHand, Program.LessThan));
                    // compare current hand to best hand
                    if (currentHandStrength.Value.ElementAt(0) > bestHandStrength.Value.ElementAt(0))
                    {
                        bestHandStrength = currentHandStrength;
                    }
                    else if (currentHandStrength.Value.ElementAt(0) == bestHandStrength.Value.ElementAt(0))
                    {
                        // check the tiebreaker values in order
                        for (int i = 1; i < bestHandStrength.Value.Count(); i++)
                        {
                            if (currentHandStrength.Value.ElementAt(i) > bestHandStrength.Value.ElementAt(i))
                            {
                                bestHandStrength = currentHandStrength;
                                break;
                            }
                            else if (currentHandStrength.Value.ElementAt(i) < bestHandStrength.Value.ElementAt(i))
                            {
                                break;
                            }
                        }
                    }

                    // increment
                    if (omitCard1 == 6)
                    {
                        complete = true;
                    }
                    else
                    {
                        omitCard1++;
                    }
                }
                // display hand strength
                textOutput.Text = bestHandStrength.Key[0] + " " + bestHandStrength.Key[1];
                foreach (int value in bestHandStrength.Value)
                {
                    lblOutput.Text += value.ToString() + "/";
                }
            }
            // for 7 cards
            else if (combinedHand.Count == 7)
            {
                // grab the first hand and set it to the best hand
                for (int i = 0; i < 7; i++)
                {
                    if (i != omitCard1 && i != omitCard2)
                    {
                        currentHand.Add(combinedHand[i]);
                    }
                }
                bestHandStrength = Poker.GetHandStrength(Program.SortHand(currentHand, Program.LessThan));
                omitCard2++;

                while (!complete)
                {
                    currentHand.Clear();
                    for (int i = 0; i < 7; i++)
                    {
                        if (i != omitCard1 && i != omitCard2)
                        {
                            currentHand.Add(combinedHand[i]);
                        }
                    }
                    currentHandStrength = Poker.GetHandStrength(Program.SortHand(currentHand, Program.LessThan));
                    // compare current hand to best hand
                    if (currentHandStrength.Value.ElementAt(0) > bestHandStrength.Value.ElementAt(0))
                    {
                        bestHandStrength = currentHandStrength;
                    }
                    else if (currentHandStrength.Value.ElementAt(0) == bestHandStrength.Value.ElementAt(0))
                    {
                        // check the tiebreaker values in order
                        for (int i = 1; i < bestHandStrength.Value.Count(); i++)
                        {
                            if (currentHandStrength.Value.ElementAt(i) > bestHandStrength.Value.ElementAt(i))
                            {
                                bestHandStrength = currentHandStrength;
                                break;
                            }
                            else if (currentHandStrength.Value.ElementAt(i) < bestHandStrength.Value.ElementAt(i))
                            {
                                break;
                            }
                        }
                    }

                    // increment omit indexes
                    if (omitCard2 < 6)
                    {
                        omitCard2++;
                    }
                    else
                    {
                        if (omitCard1 < 5)
                        {
                            omitCard1++;
                            omitCard2 = omitCard1 + 1;
                        }
                        else
                        {
                            complete = true;
                        }
                    }
                }

                textOutput.Text = bestHandStrength.Key[0] + " " + bestHandStrength.Key[1];

                Program.counterHands[bestHandStrength.Value.ElementAt(0)]++;
                Program.counterHands[9]++;
                textTotal.Text = Program.counterHands.ElementAt(9).ToString();

                switch (bestHandStrength.Value.ElementAt(0))
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

                //testing
                foreach (int value in bestHandStrength.Value)
                {
                    lblOutput.Text += value.ToString() + "/";
                }

            }
        }

        private void TexasHoldem_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void TexasHoldem_Load(object sender, EventArgs e)
        {
            Program.deckOfCards.Clear();
            Program.deckOfCards = Card.Deck();
        }

        private void buttonDealHand_Click(object sender, EventArgs e)
        {
            // Clear hole and community cards
            if (chkShuffle.Checked)
            {
                Program.deckOfCards.Clear();
                Program.deckOfCards = Card.Deck();
            }
            ResetGame();

            // Deal the two hole cards
            for (int i = 0; i < 2; i++)
            {
                Poker.player1Hand.Add(Program.deckOfCards.Pop());
            }
            string imgFolder = "..\\..\\Resources\\";
            holeCard1.Image = Image.FromFile(imgFolder + Poker.player1Hand[0].GetPath());
            holeCard2.Image = Image.FromFile(imgFolder + Poker.player1Hand[1].GetPath());

            if (Program.deckOfCards.Count < 7)
            {
                buttonDealHand.Enabled = false;
            }
            if (Program.deckOfCards.Count >= 5)
            {
                buttonNextCard.Enabled = true;
            }
            
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Program.deckOfCards.Clear();
            Program.deckOfCards = Card.Deck();
            ResetGame();
        }

        private void buttonNextCard_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            string imgFolder = "..\\..\\Resources\\";
            if (Poker.communityCards.Count == 0)
            {
                // Deal the flop
                for (int i = 0; i < 3; i++)
                {
                    Poker.communityCards.Add(Program.deckOfCards.Pop());
                }
                dealtCard1.Image = Image.FromFile(imgFolder + Poker.communityCards[0].GetPath());
                dealtCard2.Image = Image.FromFile(imgFolder + Poker.communityCards[1].GetPath());
                dealtCard3.Image = Image.FromFile(imgFolder + Poker.communityCards[2].GetPath());
                TexasHandStrength(Poker.player1Hand, Poker.communityCards);
            }
            else if (Poker.communityCards.Count == 3)
            {
                Poker.communityCards.Add(Program.deckOfCards.Pop());
                dealtCard4.Image = Image.FromFile(imgFolder + Poker.communityCards[3].GetPath());
                TexasHandStrength(Poker.player1Hand, Poker.communityCards); 
            }
            else if (Poker.communityCards.Count == 4)
            {
                Poker.communityCards.Add(Program.deckOfCards.Pop());
                dealtCard5.Image = Image.FromFile(imgFolder + Poker.communityCards[4].GetPath());
                buttonNextCard.Enabled = false;
                TexasHandStrength(Poker.player1Hand, Poker.communityCards);
            }
        }

        private void chkShuffle_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonReset.Enabled == false)
            {
                buttonReset.Enabled = true;
            }
            else
            {
                buttonReset.Enabled = false;
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            Card card1 = new Card(1, "Diamonds", "Seven", 7, "QS");
            Card card2 = new Card(1, "Spades", "Seven", 7, "KS");
            Card card3 = new Card(1, "Spades", "Seven", 7, "7S");
            Card card4 = new Card(1, "Clubs", "Eight", 8, "8S");
            Card card5 = new Card(1, "Clubs", "Nine", 9, "9S");
            Card card6 = new Card(1, "Spades", "Eight", 8, "10S");
            Card card7 = new Card(1, "Hearts", "Eight", 8, "JS");
            List<Card> testPlayerHand = new List<Card>();
            List<Card> testCommHand = new List<Card>();
            testPlayerHand.Add(card1);
            testPlayerHand.Add(card2);
            testCommHand.Add(card3);
            testCommHand.Add(card4);
            testCommHand.Add(card5);
            testCommHand.Add(card6);
            testCommHand.Add(card7);
            TexasHandStrength(testPlayerHand, testCommHand);
        }
    }
}
