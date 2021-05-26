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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn5Poker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formPoker = new Form1();
            formPoker.Show();
        }

        private void btnTexas_Click(object sender, EventArgs e)
        {
            this.Hide();
            TexasHoldem txForm = new TexasHoldem();
            txForm.Show();
        }

        private void btnBlackjack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Blackjack bForm = new Blackjack();
            bForm.Show();
        }
    }
}
