
namespace cardsForm
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btn5Poker = new System.Windows.Forms.Button();
            this.btnTexas = new System.Windows.Forms.Button();
            this.btnBlackjack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn5Poker
            // 
            this.btn5Poker.Location = new System.Drawing.Point(21, 17);
            this.btn5Poker.Name = "btn5Poker";
            this.btn5Poker.Size = new System.Drawing.Size(146, 38);
            this.btn5Poker.TabIndex = 0;
            this.btn5Poker.Text = "5 Card Draw";
            this.btn5Poker.UseVisualStyleBackColor = true;
            this.btn5Poker.Click += new System.EventHandler(this.btn5Poker_Click);
            // 
            // btnTexas
            // 
            this.btnTexas.Location = new System.Drawing.Point(21, 66);
            this.btnTexas.Name = "btnTexas";
            this.btnTexas.Size = new System.Drawing.Size(145, 37);
            this.btnTexas.TabIndex = 1;
            this.btnTexas.Text = "Texas Holdem";
            this.btnTexas.UseVisualStyleBackColor = true;
            this.btnTexas.Click += new System.EventHandler(this.btnTexas_Click);
            // 
            // btnBlackjack
            // 
            this.btnBlackjack.Location = new System.Drawing.Point(22, 118);
            this.btnBlackjack.Name = "btnBlackjack";
            this.btnBlackjack.Size = new System.Drawing.Size(145, 37);
            this.btnBlackjack.TabIndex = 2;
            this.btnBlackjack.Text = "Blackjack";
            this.btnBlackjack.UseVisualStyleBackColor = true;
            this.btnBlackjack.Click += new System.EventHandler(this.btnBlackjack_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(125)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBlackjack);
            this.Controls.Add(this.btnTexas);
            this.Controls.Add(this.btn5Poker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn5Poker;
        private System.Windows.Forms.Button btnTexas;
        private System.Windows.Forms.Button btnBlackjack;
    }
}