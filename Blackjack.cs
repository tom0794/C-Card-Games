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
    public partial class Blackjack : Form
    {
        public int bankroll = 50000;
        public int wager = 100;
        public const int NUM_DECKS = 6;
        public const int EVENT_LINES = 15;
        public PictureBox[] picPlayerCards;
        public PictureBox[] picDealerCards;
        public int playerCardCount;
        public int dealerCardCount;
        private List<Card> listPlayerCards = new List<Card>();
        private List<Card> listDealerCards = new List<Card>();
        public string cardBack = "..\\..\\Resources\\blue_back.png";

        public Blackjack()
        {
            InitializeComponent();
            // Creating arrays containing the player and dealer hand images.
            picPlayerCards = new PictureBox[] { playerCard0, playerCard1, playerCard2, playerCard3,
                playerCard4, playerCard5, playerCard6, playerCard7, playerCard8, playerCard9, playerCard10 };
            picDealerCards = new PictureBox[] { dealerCard0, dealerCard1, dealerCard2, dealerCard3, 
                dealerCard4, dealerCard5, dealerCard6, dealerCard7, dealerCard8, dealerCard9};
        }

        // UpdateOutput adds new text to txtOutput
        private void UpdateOutput(string textToAdd)
        {
            List<string> outputLines = new List<string>();
            foreach (string line in txtOutput.Lines)
            {
                if (line != "")
                {
                    outputLines.Add(line);
                }
            }
            outputLines.Insert(0, textToAdd);
            if (outputLines.Count >= EVENT_LINES)
            {
                outputLines.RemoveAt(outputLines.Count - 1);
            }

            txtOutput.Clear();
            foreach (string line in outputLines)
            {
                txtOutput.Text += line + Environment.NewLine;
            }
        }

        private void ResetGameState()
        {
            playerCardCount = 0;
            dealerCardCount = 0;
            listDealerCards.Clear();
            listPlayerCards.Clear();
            foreach (PictureBox p in picPlayerCards)
            {
                p.Visible = false;
            }
            foreach (PictureBox p in picDealerCards)
            {
                p.Visible = false;
            }
        }
        // GetHandValue consumes a hand and produces the value of the hand.
        private void GetHandValue(List<Card> inHand, bool playerHand)
        {
            int[] calculatedValue = new int[2];
            bool aceFound = false;
            for (int i = 0; i < inHand.Count; i++)
            {
                if (inHand[i].GetStrength() == 14 && aceFound)
                {
                    calculatedValue[0] += 1;
                    calculatedValue[1] += 1;
                }
                else if (inHand[i].GetStrength() == 14 && !aceFound)
                {
                    calculatedValue[0] += 11;
                    calculatedValue[1] += 1;
                    aceFound = true;
                }
                else if (inHand[i].GetStrength() > 10)
                {
                    calculatedValue[0] += 10;
                    calculatedValue[1] += 10;
                }
                else
                {
                    calculatedValue[0] += inHand[i].GetStrength();
                    calculatedValue[1] += inHand[i].GetStrength();
                }
            }
            // call the next event here. put this in the next event 
            if (playerHand && calculatedValue[0] != calculatedValue[1] && calculatedValue[0] != 21)
            {
                lblPlayerHandValue.Text = calculatedValue[0] + " / " + calculatedValue[1];
            }
            else if (playerHand)
            {
                lblPlayerHandValue.Text = calculatedValue[0].ToString();
            }
            UpdateOutput("Hand value: " + calculatedValue[0] + " " + calculatedValue[1]);
        }

        // AddCardToHand consumes card count and a hand. Deals one card to the specified hand (facedown if indicated)
        private void AddCardToHand(int cardsInHand, PictureBox[] picToAddTo, bool facedown, List<Card> handToAddTo, bool playerHand)
        {
            string imgFolder = "..\\..\\Resources\\";
            Card newCard = new Card();
            newCard = Program.deckOfCards.Pop();
            handToAddTo.Add(newCard);
            picToAddTo[cardsInHand].Visible = true;
            if (facedown)
            {
                picToAddTo[cardsInHand].Image = Image.FromFile(cardBack);
            }
            else
            {
                picToAddTo[cardsInHand].Image = Image.FromFile(imgFolder + newCard.GetPath());
            }
            //GetHandValue(handToAddTo, playerHand);
        }

        // DealNewDeck creates a new deck of 312 cards.
        private void DealNewDeck()
        {
            Program.deckOfCards.Clear();
            for (int i = 0; i < NUM_DECKS; i++)
            {
                Stack<Card> newDeck = new Stack<Card>(Card.Deck());
                foreach (Card c in newDeck)
                {
                    Program.deckOfCards.Push(c);
                }
            }
            List<Card> shuffleDeck = new List<Card>();
            foreach (Card c in Program.deckOfCards)
            {
                shuffleDeck.Add(c);
            }
            shuffleDeck.Shuffle();
            Program.deckOfCards.Clear();
            foreach (Card c in shuffleDeck)
            {
                Program.deckOfCards.Push(c);
            }
        }

        private void Blackjack_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Adjusting the bet trackbar sets the wager value.
        private void trackBetValue_Scroll(object sender, EventArgs e)
        {
            wager = trackBetValue.Value;
            lblBetValue.Text = "$" + wager.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetGameState();
            bankroll = bankroll - wager;
            lblBankroll.Text = "$" + bankroll.ToString();
            UpdateOutput("Wager of $" + wager + " has been placed. Dealing hand.");
            if (Program.deckOfCards.Count < 60)
            {
                DealNewDeck();
            }
            AddCardToHand(playerCardCount, picPlayerCards, false, listPlayerCards, true);
            playerCardCount++;
            AddCardToHand(playerCardCount, picPlayerCards, false, listPlayerCards, true);
            playerCardCount++;
            GetHandValue(listPlayerCards, true);
            AddCardToHand(dealerCardCount, picDealerCards, true, listDealerCards, false);
            dealerCardCount++;
            AddCardToHand(dealerCardCount, picDealerCards, false, listDealerCards, false);
            dealerCardCount++;
            GetHandValue(listDealerCards, false);
        }
    }
}
