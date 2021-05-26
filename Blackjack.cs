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
        public string imgFolder = "..\\..\\Resources\\";

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
            UpdateOutput("--------Next Hand---------");
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
            btnDouble.Enabled = false;
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnSplit.Enabled = false;
            btnStart.Enabled = true;
            trackBetValue.Enabled = true;
            lblPlayerHandValue.Text = "0";
            lblDealerHandValue.Text = "0";
        }

        // PlayerWins executes when the player wins
        private void PlayerWins()
        {
            MessageBox.Show("You have " + lblPlayerHandValue.Text + " and the dealer has " + lblDealerHandValue.Text + ". You win $" + (wager * 2) + "!", "Blackjack");
            UpdateOutput("You have " + lblPlayerHandValue.Text + " and the dealer has " + lblDealerHandValue.Text + ". You win $" + (wager * 2) + "!");
            bankroll = bankroll + (wager * 2);
            lblBankroll.Text = "$" + bankroll;
            ResetGameState();
        }

        // CompareHands - Compares the player hand to the dealer hand to determine a winner.
        private void CompareHands()
        {
            int[] playerHandValue = GetHandValue(listPlayerCards, true);
            int[] dealerHandValue = GetHandValue(listDealerCards, false);
            if (playerHandValue[0] > 21)
            {
                playerHandValue[0] = playerHandValue[1];
            }
            if (dealerHandValue[0] > 21)
            {
                dealerHandValue[0] = dealerHandValue[1];
            }

            if (playerHandValue[0] > dealerHandValue[0])
            {
                PlayerWins();
            }
            else if (playerHandValue[0] < dealerHandValue[0])
            {
                MessageBox.Show("You have " + playerHandValue[0].ToString() + " and the dealer has " + dealerHandValue[0].ToString() + ". You lose!", "Blackjack");
                UpdateOutput("You have " + playerHandValue[0].ToString() + " and the dealer had " + dealerHandValue[0].ToString() + ". You lose!");
                ResetGameState();
            }
            else if (playerHandValue[0] == dealerHandValue[0])
            {
                MessageBox.Show("You have " + playerHandValue[0].ToString() + " and the dealer has " + dealerHandValue[0].ToString() + ". It is a push!", "Blackjack");
                bankroll = bankroll + wager;
                lblBankroll.Text = "$" + bankroll;
                ResetGameState();
            }
        }

        // DealerHandPlay - the dealer plays out their hand
        private void DealerHandPlay()
        {
            int[] dealerHandValue = GetHandValue(listDealerCards, false);
            picDealerCards[1].Image = Image.FromFile(imgFolder + listDealerCards.ElementAt(1).GetPath());
            picDealerCards[1].BringToFront();
            DisplayHandValue(dealerHandValue, false);
            MessageBox.Show("Dealer's facedown card is the " + listDealerCards.ElementAt(1) + ". Hand value is " + dealerHandValue[0] + ".", "Blackjack");
            
            bool dealerStand = false;
            bool dealerBust = false;

            if (dealerHandValue[0] >= 17)
            {
                dealerStand = true;
                UpdateOutput("Dealer stands with " + dealerHandValue[0]);
                CompareHands();
            }


            // Loop: dealer hits until they have at least 17, or have busted
            while (!dealerStand && !dealerBust)
            {
                AddCardToHand(listDealerCards.Count, picDealerCards, false, listDealerCards);
                UpdateOutput("Card dealt: " + listDealerCards.ElementAt(listDealerCards.Count - 1));
                dealerHandValue = GetHandValue(listDealerCards, false);
                DisplayHandValue(dealerHandValue, false);
                MessageBox.Show("Dealer is dealt a " + listDealerCards.ElementAt(listDealerCards.Count - 1) + ". Hand value is now " + lblDealerHandValue.Text + ".", "Blackjack");

                CheckForBust(dealerHandValue, false);
                if (dealerHandValue[0] > 21 && dealerHandValue[1] > 21)
                {
                    dealerBust = true;
                }
                else if (dealerHandValue[0] >= 17 && dealerHandValue[0] <= 21)
                {
                    dealerStand = true;
                    MessageBox.Show("Dealer stands with " + lblDealerHandValue.Text + ".", "Blackjack");
                    UpdateOutput("Dealer stands with " + lblDealerHandValue.Text + ".");
                    CompareHands();
                }
                else if (dealerHandValue[1] >= 17 && dealerHandValue[1] <= 21)
                {
                    dealerStand = true;
                    MessageBox.Show("Dealer stands with " + lblDealerHandValue.Text + ".", "Blackjack");
                    UpdateOutput("Dealer stands with " + lblDealerHandValue.Text + ".");
                    CompareHands();
                }
            }
            
        }

        // CheckForBust identifies if a hand has busted.
        private void CheckForBust(int[] inHandValue, bool playerHand)
        {
            if (inHandValue[0] > 21 && inHandValue[1] > 21)
            {
                if (playerHand)
                {
                    UpdateOutput("You have busted.");
                    MessageBox.Show("You have busted.", "Blackjack");
                }
                else if (!playerHand)
                {
                    UpdateOutput("Dealer busts!");
                    MessageBox.Show("Dealer busts!", "Blackjack");
                    PlayerWins();
                }
                ResetGameState();
            }
            else if (inHandValue[0] > 21)
            {
                if (playerHand)
                {
                    lblPlayerHandValue.Text = inHandValue[1].ToString();
                }
                else
                {
                    lblDealerHandValue.Text = inHandValue[1].ToString();
                }
            }
        }

        // Display hand value updates the labels displaying the hand value
        private void DisplayHandValue(int[] inHandValue, bool playerHand)
        {
            if (playerHand && inHandValue[0] != inHandValue[1] && inHandValue[0] < 21)
            {
                lblPlayerHandValue.Text = inHandValue[0] + " / " + inHandValue[1];
                UpdateOutput("Player hand value is now: " + lblPlayerHandValue.Text);
            }
            else if (playerHand && inHandValue[0] > 21)
            {
                lblPlayerHandValue.Text = inHandValue[1].ToString();
                UpdateOutput("Player hand value is now: " + lblPlayerHandValue.Text);
            }
            else if (playerHand)
            {
                lblPlayerHandValue.Text = inHandValue[0].ToString();
                UpdateOutput("Player hand value is now: " + lblPlayerHandValue.Text);
            }
            else if (!playerHand && inHandValue[0] != inHandValue[1] && inHandValue[0] != 21)
            {
                lblDealerHandValue.Text = inHandValue[0] + " / " + inHandValue[1];
                UpdateOutput("Dealer hand value is now: " + lblDealerHandValue.Text);
            }
            else if (!playerHand && inHandValue[0] > 21)
            {
                lblDealerHandValue.Text = inHandValue[1].ToString();
                UpdateOutput("Player hand value is now: " + lblDealerHandValue.Text);
            }
            else if (!playerHand)
            {
                lblDealerHandValue.Text = inHandValue[0].ToString();
                UpdateOutput("Dealer hand value is now: " + lblDealerHandValue.Text);
            }
        }

        // GetHandValue consumes a hand and produces the value of the hand.
        private int[] GetHandValue(List<Card> inHand, bool playerHand)
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

            return calculatedValue;
        }

        // AddCardToHand consumes card count and a hand. Deals one card to the specified hand (facedown if indicated)
        private void AddCardToHand(int cardsInHand, PictureBox[] picToAddTo, bool facedown, List<Card> handToAddTo)
        {
            Card newCard = new Card();
            newCard = Program.deckOfCards.Pop();
            handToAddTo.Add(newCard);
            if (cardsInHand >= 11)
            {
                cardsInHand = 10;
            }
            picToAddTo[cardsInHand].Visible = true;
            if (facedown)
            {
                picToAddTo[cardsInHand].Image = Image.FromFile(cardBack);
            }
            else
            {
                picToAddTo[cardsInHand].Image = Image.FromFile(imgFolder + newCard.GetPath());
                picToAddTo[cardsInHand].BringToFront();
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
            AddCardToHand(playerCardCount, picPlayerCards, false, listPlayerCards);
            playerCardCount++;
            AddCardToHand(playerCardCount, picPlayerCards, false, listPlayerCards);
            playerCardCount++;
            DisplayHandValue(GetHandValue(listPlayerCards, true), true);

            AddCardToHand(dealerCardCount, picDealerCards, false, listDealerCards);
            dealerCardCount++;
            DisplayHandValue(GetHandValue(listDealerCards, false), false);
            AddCardToHand(dealerCardCount, picDealerCards, true, listDealerCards);
            dealerCardCount++;

            // Enable actions, disable wager.
            btnStart.Enabled = false;
            trackBetValue.Enabled = false;

            btnHit.Enabled = true;
            btnStand.Enabled = true;
            btnDouble.Enabled = true;

            // if the player has a pair, split is enabled.
            if (listPlayerCards.ElementAt(0).GetName() == listPlayerCards.ElementAt(1).GetName())
            {
                btnSplit.Enabled = true;
            }

            if (GetHandValue(listPlayerCards, true)[0] == 21)
            {
                MessageBox.Show("Blackjack!", "Blackjack");
                btnStand_Click(sender, e);
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            AddCardToHand(listPlayerCards.Count, picPlayerCards, false, listPlayerCards);
            UpdateOutput("Card dealt: " + listPlayerCards.ElementAt(listPlayerCards.Count - 1));
            int[] handValue = GetHandValue(listPlayerCards, true);
            DisplayHandValue(handValue, true);
            if (handValue[0] == 21 || handValue[1] == 21)
            {
                MessageBox.Show("Blackjack!", "Blackjack");
                btnStand_Click(sender, e);
            } 
            else
            {
                CheckForBust(handValue, true);
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            foreach (Button b in grpActions.Controls)
            {
                b.Enabled = false;
            }
            int[] playerHand = GetHandValue(listPlayerCards, true);
            if (playerHand[0] >= playerHand[1])
            {
                lblPlayerHandValue.Text = playerHand[0].ToString();
            }
            else
            {
                lblPlayerHandValue.Text = playerHand[1].ToString();
            }
            DealerHandPlay();
        }
    }
}
