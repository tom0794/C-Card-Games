using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cardsForm
{
    public partial class Blackjack : Form
    {
        public int bankroll = 50000;
        public int wager = 100;
        public PictureBox[] picPlayerCards;
        public PictureBox[] picDealerCards;
        public Blackjack()
        {
            InitializeComponent();
            // Creating arrays containing the player and dealer hand images.
            picPlayerCards = new PictureBox[] { playerCard0, playerCard1, playerCard2, playerCard3,
                playerCard4, playerCard5, playerCard6, playerCard7, playerCard8, playerCard9, playerCard10 };
            picDealerCards = new PictureBox[] { dealerCard0, dealerCard1, dealerCard2, dealerCard3, 
                dealerCard4, dealerCard5, dealerCard6, dealerCard7, dealerCard8, dealerCard9};
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
            picDealerCards[9].Visible = false;         
        }
    }
}
