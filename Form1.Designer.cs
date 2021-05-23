
namespace cardsForm
{
    partial class Form1
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
            this.buttonShowCard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDealHand = new System.Windows.Forms.Button();
            this.dealtCard1 = new System.Windows.Forms.PictureBox();
            this.dealtCard2 = new System.Windows.Forms.PictureBox();
            this.dealtCard3 = new System.Windows.Forms.PictureBox();
            this.dealtCard4 = new System.Windows.Forms.PictureBox();
            this.cardImage1 = new System.Windows.Forms.PictureBox();
            this.dealtCard5 = new System.Windows.Forms.PictureBox();
            this.buttonSortHand = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.labelSFlush = new System.Windows.Forms.Label();
            this.textSFlush = new System.Windows.Forms.TextBox();
            this.textQuads = new System.Windows.Forms.TextBox();
            this.labelQuads = new System.Windows.Forms.Label();
            this.textFullH = new System.Windows.Forms.TextBox();
            this.labelFullH = new System.Windows.Forms.Label();
            this.textFlush = new System.Windows.Forms.TextBox();
            this.labelFlush = new System.Windows.Forms.Label();
            this.textStraight = new System.Windows.Forms.TextBox();
            this.labelStraight = new System.Windows.Forms.Label();
            this.textTrips = new System.Windows.Forms.TextBox();
            this.labelTrips = new System.Windows.Forms.Label();
            this.text2Pair = new System.Windows.Forms.TextBox();
            this.label2Pair = new System.Windows.Forms.Label();
            this.text1Pair = new System.Windows.Forms.TextBox();
            this.label1Pair = new System.Windows.Forms.Label();
            this.textHighCard = new System.Windows.Forms.TextBox();
            this.labelHighCard = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.checkCard1 = new System.Windows.Forms.CheckBox();
            this.checkCard2 = new System.Windows.Forms.CheckBox();
            this.checkCard3 = new System.Windows.Forms.CheckBox();
            this.checkCard4 = new System.Windows.Forms.CheckBox();
            this.checkCard5 = new System.Windows.Forms.CheckBox();
            this.buttonDrawNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard5)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowCard
            // 
            this.buttonShowCard.Location = new System.Drawing.Point(15, 25);
            this.buttonShowCard.Name = "buttonShowCard";
            this.buttonShowCard.Size = new System.Drawing.Size(138, 47);
            this.buttonShowCard.TabIndex = 2;
            this.buttonShowCard.Text = "Show Card";
            this.buttonShowCard.UseVisualStyleBackColor = true;
            this.buttonShowCard.Click += new System.EventHandler(this.buttonShowCard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // buttonDealHand
            // 
            this.buttonDealHand.Location = new System.Drawing.Point(221, 25);
            this.buttonDealHand.Name = "buttonDealHand";
            this.buttonDealHand.Size = new System.Drawing.Size(138, 47);
            this.buttonDealHand.TabIndex = 9;
            this.buttonDealHand.Text = "Deal Hand";
            this.buttonDealHand.UseVisualStyleBackColor = true;
            this.buttonDealHand.Click += new System.EventHandler(this.buttonDealHand_Click);
            // 
            // dealtCard1
            // 
            this.dealtCard1.Image = global::cardsForm.Properties.Resources.blue_back;
            this.dealtCard1.Location = new System.Drawing.Point(221, 78);
            this.dealtCard1.Name = "dealtCard1";
            this.dealtCard1.Size = new System.Drawing.Size(138, 211);
            this.dealtCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealtCard1.TabIndex = 4;
            this.dealtCard1.TabStop = false;
            // 
            // dealtCard2
            // 
            this.dealtCard2.Image = global::cardsForm.Properties.Resources.blue_back;
            this.dealtCard2.Location = new System.Drawing.Point(258, 78);
            this.dealtCard2.Name = "dealtCard2";
            this.dealtCard2.Size = new System.Drawing.Size(138, 211);
            this.dealtCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealtCard2.TabIndex = 5;
            this.dealtCard2.TabStop = false;
            // 
            // dealtCard3
            // 
            this.dealtCard3.Image = global::cardsForm.Properties.Resources.blue_back;
            this.dealtCard3.Location = new System.Drawing.Point(294, 78);
            this.dealtCard3.Name = "dealtCard3";
            this.dealtCard3.Size = new System.Drawing.Size(138, 211);
            this.dealtCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealtCard3.TabIndex = 6;
            this.dealtCard3.TabStop = false;
            // 
            // dealtCard4
            // 
            this.dealtCard4.Image = global::cardsForm.Properties.Resources.blue_back;
            this.dealtCard4.Location = new System.Drawing.Point(330, 78);
            this.dealtCard4.Name = "dealtCard4";
            this.dealtCard4.Size = new System.Drawing.Size(138, 211);
            this.dealtCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealtCard4.TabIndex = 7;
            this.dealtCard4.TabStop = false;
            // 
            // cardImage1
            // 
            this.cardImage1.Image = global::cardsForm.Properties.Resources.blue_back;
            this.cardImage1.Location = new System.Drawing.Point(15, 78);
            this.cardImage1.Name = "cardImage1";
            this.cardImage1.Size = new System.Drawing.Size(138, 211);
            this.cardImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cardImage1.TabIndex = 1;
            this.cardImage1.TabStop = false;
            // 
            // dealtCard5
            // 
            this.dealtCard5.Image = global::cardsForm.Properties.Resources.blue_back;
            this.dealtCard5.Location = new System.Drawing.Point(365, 78);
            this.dealtCard5.Name = "dealtCard5";
            this.dealtCard5.Size = new System.Drawing.Size(138, 211);
            this.dealtCard5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealtCard5.TabIndex = 8;
            this.dealtCard5.TabStop = false;
            // 
            // buttonSortHand
            // 
            this.buttonSortHand.Enabled = false;
            this.buttonSortHand.Location = new System.Drawing.Point(365, 25);
            this.buttonSortHand.Name = "buttonSortHand";
            this.buttonSortHand.Size = new System.Drawing.Size(138, 47);
            this.buttonSortHand.TabIndex = 10;
            this.buttonSortHand.Text = "Sort Hand";
            this.buttonSortHand.UseVisualStyleBackColor = true;
            this.buttonSortHand.Click += new System.EventHandler(this.buttonSortHand_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(529, 25);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(138, 47);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reshuffle";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(529, 81);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(249, 25);
            this.textOutput.TabIndex = 12;
            // 
            // labelSFlush
            // 
            this.labelSFlush.AutoSize = true;
            this.labelSFlush.Location = new System.Drawing.Point(530, 119);
            this.labelSFlush.Name = "labelSFlush";
            this.labelSFlush.Size = new System.Drawing.Size(74, 13);
            this.labelSFlush.TabIndex = 13;
            this.labelSFlush.Text = "Straight Flush:";
            // 
            // textSFlush
            // 
            this.textSFlush.Location = new System.Drawing.Point(610, 116);
            this.textSFlush.Name = "textSFlush";
            this.textSFlush.ReadOnly = true;
            this.textSFlush.Size = new System.Drawing.Size(26, 20);
            this.textSFlush.TabIndex = 14;
            this.textSFlush.Text = "0";
            this.textSFlush.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textQuads
            // 
            this.textQuads.Location = new System.Drawing.Point(610, 140);
            this.textQuads.Name = "textQuads";
            this.textQuads.ReadOnly = true;
            this.textQuads.Size = new System.Drawing.Size(26, 20);
            this.textQuads.TabIndex = 16;
            this.textQuads.Text = "0";
            this.textQuads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelQuads
            // 
            this.labelQuads.AutoSize = true;
            this.labelQuads.Location = new System.Drawing.Point(530, 143);
            this.labelQuads.Name = "labelQuads";
            this.labelQuads.Size = new System.Drawing.Size(41, 13);
            this.labelQuads.TabIndex = 15;
            this.labelQuads.Text = "Quads:";
            // 
            // textFullH
            // 
            this.textFullH.Location = new System.Drawing.Point(610, 164);
            this.textFullH.Name = "textFullH";
            this.textFullH.ReadOnly = true;
            this.textFullH.Size = new System.Drawing.Size(26, 20);
            this.textFullH.TabIndex = 18;
            this.textFullH.Text = "0";
            this.textFullH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelFullH
            // 
            this.labelFullH.AutoSize = true;
            this.labelFullH.Location = new System.Drawing.Point(530, 167);
            this.labelFullH.Name = "labelFullH";
            this.labelFullH.Size = new System.Drawing.Size(60, 13);
            this.labelFullH.TabIndex = 17;
            this.labelFullH.Text = "Full House:";
            // 
            // textFlush
            // 
            this.textFlush.Location = new System.Drawing.Point(610, 189);
            this.textFlush.Name = "textFlush";
            this.textFlush.ReadOnly = true;
            this.textFlush.Size = new System.Drawing.Size(26, 20);
            this.textFlush.TabIndex = 20;
            this.textFlush.Text = "0";
            this.textFlush.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelFlush
            // 
            this.labelFlush.AutoSize = true;
            this.labelFlush.Location = new System.Drawing.Point(530, 192);
            this.labelFlush.Name = "labelFlush";
            this.labelFlush.Size = new System.Drawing.Size(35, 13);
            this.labelFlush.TabIndex = 19;
            this.labelFlush.Text = "Flush:";
            // 
            // textStraight
            // 
            this.textStraight.Location = new System.Drawing.Point(610, 213);
            this.textStraight.Name = "textStraight";
            this.textStraight.ReadOnly = true;
            this.textStraight.Size = new System.Drawing.Size(26, 20);
            this.textStraight.TabIndex = 22;
            this.textStraight.Text = "0";
            this.textStraight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStraight
            // 
            this.labelStraight.AutoSize = true;
            this.labelStraight.Location = new System.Drawing.Point(530, 216);
            this.labelStraight.Name = "labelStraight";
            this.labelStraight.Size = new System.Drawing.Size(46, 13);
            this.labelStraight.TabIndex = 21;
            this.labelStraight.Text = "Straight:";
            // 
            // textTrips
            // 
            this.textTrips.Location = new System.Drawing.Point(731, 116);
            this.textTrips.Name = "textTrips";
            this.textTrips.ReadOnly = true;
            this.textTrips.Size = new System.Drawing.Size(26, 20);
            this.textTrips.TabIndex = 24;
            this.textTrips.Text = "0";
            this.textTrips.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTrips
            // 
            this.labelTrips.AutoSize = true;
            this.labelTrips.Location = new System.Drawing.Point(651, 119);
            this.labelTrips.Name = "labelTrips";
            this.labelTrips.Size = new System.Drawing.Size(33, 13);
            this.labelTrips.TabIndex = 23;
            this.labelTrips.Text = "Trips:";
            // 
            // text2Pair
            // 
            this.text2Pair.Location = new System.Drawing.Point(731, 140);
            this.text2Pair.Name = "text2Pair";
            this.text2Pair.ReadOnly = true;
            this.text2Pair.Size = new System.Drawing.Size(26, 20);
            this.text2Pair.TabIndex = 26;
            this.text2Pair.Text = "0";
            this.text2Pair.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2Pair
            // 
            this.label2Pair.AutoSize = true;
            this.label2Pair.Location = new System.Drawing.Point(651, 143);
            this.label2Pair.Name = "label2Pair";
            this.label2Pair.Size = new System.Drawing.Size(52, 13);
            this.label2Pair.TabIndex = 25;
            this.label2Pair.Text = "Two Pair:";
            // 
            // text1Pair
            // 
            this.text1Pair.Location = new System.Drawing.Point(731, 164);
            this.text1Pair.Name = "text1Pair";
            this.text1Pair.ReadOnly = true;
            this.text1Pair.Size = new System.Drawing.Size(26, 20);
            this.text1Pair.TabIndex = 28;
            this.text1Pair.Text = "0";
            this.text1Pair.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1Pair
            // 
            this.label1Pair.AutoSize = true;
            this.label1Pair.Location = new System.Drawing.Point(651, 167);
            this.label1Pair.Name = "label1Pair";
            this.label1Pair.Size = new System.Drawing.Size(51, 13);
            this.label1Pair.TabIndex = 27;
            this.label1Pair.Text = "One Pair:";
            // 
            // textHighCard
            // 
            this.textHighCard.Location = new System.Drawing.Point(731, 189);
            this.textHighCard.Name = "textHighCard";
            this.textHighCard.ReadOnly = true;
            this.textHighCard.Size = new System.Drawing.Size(26, 20);
            this.textHighCard.TabIndex = 30;
            this.textHighCard.Text = "0";
            this.textHighCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelHighCard
            // 
            this.labelHighCard.AutoSize = true;
            this.labelHighCard.Location = new System.Drawing.Point(651, 192);
            this.labelHighCard.Name = "labelHighCard";
            this.labelHighCard.Size = new System.Drawing.Size(57, 13);
            this.labelHighCard.TabIndex = 29;
            this.labelHighCard.Text = "High Card:";
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(731, 213);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(26, 20);
            this.textTotal.TabIndex = 32;
            this.textTotal.Text = "0";
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(651, 216);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(68, 13);
            this.labelTotal.TabIndex = 31;
            this.labelTotal.Text = "Total Hands:";
            // 
            // checkCard1
            // 
            this.checkCard1.AutoSize = true;
            this.checkCard1.Enabled = false;
            this.checkCard1.Location = new System.Drawing.Point(221, 295);
            this.checkCard1.Name = "checkCard1";
            this.checkCard1.Size = new System.Drawing.Size(32, 17);
            this.checkCard1.TabIndex = 33;
            this.checkCard1.Text = "1";
            this.checkCard1.UseVisualStyleBackColor = true;
            this.checkCard1.CheckedChanged += new System.EventHandler(this.checkCard1_CheckedChanged);
            // 
            // checkCard2
            // 
            this.checkCard2.AutoSize = true;
            this.checkCard2.Enabled = false;
            this.checkCard2.Location = new System.Drawing.Point(258, 295);
            this.checkCard2.Name = "checkCard2";
            this.checkCard2.Size = new System.Drawing.Size(32, 17);
            this.checkCard2.TabIndex = 34;
            this.checkCard2.Text = "2";
            this.checkCard2.UseVisualStyleBackColor = true;
            this.checkCard2.CheckedChanged += new System.EventHandler(this.checkCard2_CheckedChanged);
            // 
            // checkCard3
            // 
            this.checkCard3.AutoSize = true;
            this.checkCard3.Enabled = false;
            this.checkCard3.Location = new System.Drawing.Point(294, 295);
            this.checkCard3.Name = "checkCard3";
            this.checkCard3.Size = new System.Drawing.Size(32, 17);
            this.checkCard3.TabIndex = 35;
            this.checkCard3.Text = "3";
            this.checkCard3.UseVisualStyleBackColor = true;
            this.checkCard3.CheckedChanged += new System.EventHandler(this.checkCard3_CheckedChanged);
            // 
            // checkCard4
            // 
            this.checkCard4.AutoSize = true;
            this.checkCard4.Enabled = false;
            this.checkCard4.Location = new System.Drawing.Point(330, 295);
            this.checkCard4.Name = "checkCard4";
            this.checkCard4.Size = new System.Drawing.Size(32, 17);
            this.checkCard4.TabIndex = 36;
            this.checkCard4.Text = "4";
            this.checkCard4.UseVisualStyleBackColor = true;
            this.checkCard4.CheckedChanged += new System.EventHandler(this.checkCard4_CheckedChanged);
            // 
            // checkCard5
            // 
            this.checkCard5.AutoSize = true;
            this.checkCard5.Enabled = false;
            this.checkCard5.Location = new System.Drawing.Point(365, 295);
            this.checkCard5.Name = "checkCard5";
            this.checkCard5.Size = new System.Drawing.Size(32, 17);
            this.checkCard5.TabIndex = 37;
            this.checkCard5.Text = "5";
            this.checkCard5.UseVisualStyleBackColor = true;
            this.checkCard5.CheckedChanged += new System.EventHandler(this.checkCard5_CheckedChanged);
            // 
            // buttonDrawNew
            // 
            this.buttonDrawNew.Enabled = false;
            this.buttonDrawNew.Location = new System.Drawing.Point(402, 294);
            this.buttonDrawNew.Name = "buttonDrawNew";
            this.buttonDrawNew.Size = new System.Drawing.Size(100, 31);
            this.buttonDrawNew.TabIndex = 38;
            this.buttonDrawNew.Text = "Draw Cards";
            this.buttonDrawNew.UseVisualStyleBackColor = true;
            this.buttonDrawNew.Click += new System.EventHandler(this.buttonDrawNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Keep:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDrawNew);
            this.Controls.Add(this.checkCard5);
            this.Controls.Add(this.checkCard4);
            this.Controls.Add(this.checkCard3);
            this.Controls.Add(this.checkCard2);
            this.Controls.Add(this.checkCard1);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.textHighCard);
            this.Controls.Add(this.labelHighCard);
            this.Controls.Add(this.text1Pair);
            this.Controls.Add(this.label1Pair);
            this.Controls.Add(this.text2Pair);
            this.Controls.Add(this.label2Pair);
            this.Controls.Add(this.textTrips);
            this.Controls.Add(this.labelTrips);
            this.Controls.Add(this.textStraight);
            this.Controls.Add(this.labelStraight);
            this.Controls.Add(this.textFlush);
            this.Controls.Add(this.labelFlush);
            this.Controls.Add(this.textFullH);
            this.Controls.Add(this.labelFullH);
            this.Controls.Add(this.textQuads);
            this.Controls.Add(this.labelQuads);
            this.Controls.Add(this.textSFlush);
            this.Controls.Add(this.labelSFlush);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSortHand);
            this.Controls.Add(this.dealtCard5);
            this.Controls.Add(this.dealtCard4);
            this.Controls.Add(this.dealtCard3);
            this.Controls.Add(this.buttonDealHand);
            this.Controls.Add(this.dealtCard2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonShowCard);
            this.Controls.Add(this.cardImage1);
            this.Controls.Add(this.dealtCard1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealtCard5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox cardImage1;
        private System.Windows.Forms.Button buttonShowCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox dealtCard1;
        private System.Windows.Forms.PictureBox dealtCard2;
        private System.Windows.Forms.PictureBox dealtCard3;
        private System.Windows.Forms.PictureBox dealtCard4;
        private System.Windows.Forms.PictureBox dealtCard5;
        private System.Windows.Forms.Button buttonDealHand;
        private System.Windows.Forms.Button buttonSortHand;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Label labelSFlush;
        private System.Windows.Forms.TextBox textSFlush;
        private System.Windows.Forms.TextBox textQuads;
        private System.Windows.Forms.Label labelQuads;
        private System.Windows.Forms.TextBox textFullH;
        private System.Windows.Forms.Label labelFullH;
        private System.Windows.Forms.TextBox textFlush;
        private System.Windows.Forms.Label labelFlush;
        private System.Windows.Forms.TextBox textStraight;
        private System.Windows.Forms.Label labelStraight;
        private System.Windows.Forms.TextBox textTrips;
        private System.Windows.Forms.Label labelTrips;
        private System.Windows.Forms.TextBox text2Pair;
        private System.Windows.Forms.Label label2Pair;
        private System.Windows.Forms.TextBox text1Pair;
        private System.Windows.Forms.Label label1Pair;
        private System.Windows.Forms.TextBox textHighCard;
        private System.Windows.Forms.Label labelHighCard;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.CheckBox checkCard1;
        private System.Windows.Forms.CheckBox checkCard2;
        private System.Windows.Forms.CheckBox checkCard3;
        private System.Windows.Forms.CheckBox checkCard4;
        private System.Windows.Forms.CheckBox checkCard5;
        private System.Windows.Forms.Button buttonDrawNew;
        private System.Windows.Forms.Label label2;
    }
}

