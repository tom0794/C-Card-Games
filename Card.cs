using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cardsForm;

namespace cardProgram
{
    class Card
    {
        private int cardID;
        private string suit;
        private string name;
        private int strength;
        private string displayLong;
        private string displayShort;
        private string imgPath;

        public Card()
        {
            cardID = 0;
            suit = "";
            name = "";
            strength = 0;
            displayLong = "";
            displayShort = "";
            imgPath = "";
        }

        public Card(int inID, string inSuit, string inName, int inStrength, string inDisplayShort)
        {
            cardID = inID;
            suit = inSuit;
            name = inName;
            strength = inStrength;
            displayLong = inName + " of " + inSuit;
            displayShort = inDisplayShort;
            imgPath = inDisplayShort + ".png";
        }

        public string GetPath()
        {
            return imgPath;
        }

        public int GetStrength()
        {
            return strength;
        }

        public string GetSuit()
        {
            return suit;
        }
        
        public string GetName()
        {
            return name;
        }

        // Creates a Stack of 52 Cards
        public static Stack<Card> Deck()
        {
            Stack<Card> deck = new Stack<Card>();
            List<Card> deckList = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] cardNames = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] cardShort = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int deckSuitNum = 0;
            int deckCardNum = 0;
            int deckCardID = 1;
            int deckStrength = 2;

            while (deckCardID <= 52)
            {
                deckList.Add(new Card(deckCardID, suits[deckSuitNum], cardNames[deckCardNum], deckStrength, cardShort[deckCardNum] + suits[deckSuitNum][0]));
                deckCardID++;
                if (deckCardID != 53)
                {
                    // if ace was just added, move to the next suit and reset the card strength and value
                    if (deckCardNum == 12)
                    {
                        deckCardNum = 0;
                        deckStrength = 2;
                        deckSuitNum++;
                    }
                    else
                    {
                        deckCardNum++;
                        deckStrength++;
                    }
                }
            }
            deckList.Shuffle();
            foreach (Card c in deckList)
            {
                deck.Push(c);
            }
            return deck;
        }


        public override string ToString()
        {
            return displayLong;
        }

        public void Properties()
        {
            Console.WriteLine("Long Name: " + displayLong);
            Console.WriteLine("Short Name: " + displayShort);
            Console.WriteLine("Card ID: " + cardID);
            Console.WriteLine("Suit: " + suit);
            Console.WriteLine("Strength: " + strength);
        }
    }
}