using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cardProgram;

namespace cardsForm
{
    class Poker
    {
        public static List<Card> player1Hand = new List<Card>();
        public static List<Card> communityCards = new List<Card>();

        /* Consumes a sorted Hand (listof 5 cards) and returns a list of integers.
         *  Hand Values:
         *      Straight flush
         *          Value: 8 -- Tiebreaker 1: Highest card -- Tiebreaker 2-5: N/A
         *      Quads
         *          Value: 7 -- Tiebreaker 1: Strength of quad card -- Tiebreaker 2: Strength of kicker -- Tiebreaker 3-5: N/A
         *      Full house
         *          Value: 6 -- Tiebreaker 1: Strength of trips card -- Tiebeaker 2: Stength of pair card -- Tiebreaker 3-5: N/A
         *      Flush
         *          Value: 5 -- Tiebreaker 1-5: Highest card 
         *      Straight
         *          Value: 4 -- Tiebreaker 1: Highest card -- Tiebreaker 2-5: N/A
         *      Trips
         *          Value: 3 -- Tiebreaker 1: Strength of trips card -- Tiebreaker 2-3: Strenght of kickers -- Tiebreaker 4-5: N/A
         *      Two pair
         *          Value: 2 -- Tiebreaker 1: Strength of strongest pair -- Tiebreaker 2: Weaker pair -- Tiebreaker 3: Kicker -- Tiebreaker 4-5: N/A
         *      One pair
         *          Value: 1 -- Tiebreaker 1: Strength of pair -- Tiebreaker 2-4: Kickers -- Tiebreaker 5: N/A
         *      High card
         *          Value: 0 -- Tiebreaker 1-5: High card to low card strength
         * Returned list format:
         *   (Value, Tie 1, Tie 2, Tie 3, Tie 4, Tie 5)
         */
        public static KeyValuePair<string[], List<int>> GetHandStrength(List<Card> inHand)
        {
            string[] handName = new string[2];
            List<int> calculatedStrength = new List<int>();
            bool strengthFound = false;
            bool flush = false;
            bool straight = false;

            // Check for flush
            int numOfSuit = 0;
            foreach (Card c in inHand)
            {
                if (c.GetSuit() == inHand[0].GetSuit())
                {
                    numOfSuit++;
                }
            }
            if (numOfSuit == 5)
            {
                flush = true;
            }

            // Check for straight
            int firstCard = inHand[0].GetStrength();
            int secondCard = inHand[1].GetStrength();

            if (inHand[1].GetStrength() == firstCard + 1 &&
                inHand[2].GetStrength() == firstCard + 2 &&
                inHand[3].GetStrength() == firstCard + 3)
            {
                if (inHand[4].GetStrength() == firstCard + 4 ||
                    inHand[4].GetStrength() == firstCard + 12)
                {
                    straight = true;
                }
            }

            // Set values if hand is straight flush
            if (flush && straight)
            {
                calculatedStrength.Add(8);
                if (inHand[0].GetStrength() == 10)
                {
                    handName[0] = "Royal Flush";
                }
                else
                {
                    handName[0] = "Straight Flush";
                }
                // Special case A, 2, 3, 4, 5
                if (inHand[3].GetStrength() == 5 && inHand[4].GetStrength() == 14)
                {
                    handName[1] = "Five high";
                    calculatedStrength.Add(5);
                }
                else
                {
                    handName[1] = inHand[4].GetName() + " high";
                    calculatedStrength.Add(inHand[4].GetStrength());
                }
                strengthFound = true;
            }
            // Set value if hand is flush or straight
            if (!strengthFound)
            {
                if (flush)
                {
                    calculatedStrength.Add(5);
                    handName[0] = "Flush";
                    handName[1] = inHand[4].GetName() + " high";
                    calculatedStrength.Add(inHand[4].GetStrength());
                    calculatedStrength.Add(inHand[3].GetStrength());
                    calculatedStrength.Add(inHand[2].GetStrength());
                    calculatedStrength.Add(inHand[1].GetStrength());
                    calculatedStrength.Add(inHand[0].GetStrength());
                    strengthFound = true;
                }
                else if (straight)
                {
                    calculatedStrength.Add(4);
                    handName[0] = "Straight";
                    // Special case A, 2, 3, 4, 5
                    if (inHand[3].GetStrength() == 5 && inHand[4].GetStrength() == 14)
                    {
                        handName[1] = "Five high";
                        calculatedStrength.Add(5);
                    }
                    else
                    {
                        handName[1] = inHand[4].GetName() + " high";
                        calculatedStrength.Add(inHand[4].GetStrength());
                    }
                    strengthFound = true;
                }
            }

            // Set value if hand is quads
            if (!strengthFound)
            {
                int quadCounter1 = 0;
                int quadCounter2 = 0;
                foreach (Card c in inHand)
                {
                    if (c.GetStrength() == firstCard)
                    {
                        quadCounter1++;
                    }
                    else if (c.GetStrength() == secondCard)
                    {
                        quadCounter2++;
                    }
                }
                if (quadCounter1 == 4)
                {
                    calculatedStrength.Add(7);
                    handName[0] = "Quads";
                    if (inHand[0].GetName() == "Six")
                    {
                        handName[1] = "Quad Sixes";
                    }
                    else
                    {
                        handName[1] = "Quad " + inHand[0].GetName() + "s";
                    }
                    calculatedStrength.Add(inHand[4].GetStrength());
                    strengthFound = true;
                }
                if (quadCounter2 == 4)
                {
                    calculatedStrength.Add(7);
                    handName[0] = "Quads";
                    if (inHand[1].GetName() == "Six")
                    {
                        handName[1] = "Sixes";
                    }
                    else
                    {
                        handName[1] = inHand[1].GetName() + "s";
                    }
                    calculatedStrength.Add(inHand[0].GetStrength());
                    strengthFound = true;
                }
            }

            // Full house
            if (!strengthFound)
            {
                if (firstCard == inHand[1].GetStrength() &&
                    firstCard == inHand[2].GetStrength() &&
                    inHand[3].GetStrength() == inHand[4].GetStrength())
                {
                    calculatedStrength.Add(6);
                    handName[0] = "Full House";
                    handName[1] = inHand[0].GetName() + " full of " + inHand[3].GetName();
                    calculatedStrength.Add(firstCard);
                    calculatedStrength.Add(inHand[3].GetStrength());
                    strengthFound = true;
                }
                else if (firstCard == inHand[1].GetStrength() &&
                    inHand[2].GetStrength() == inHand[3].GetStrength() &&
                    inHand[2].GetStrength() == inHand[4].GetStrength())
                {
                    calculatedStrength.Add(6);
                    handName[0] = "Full House";
                    handName[1] = inHand[2].GetName() + " full of " + inHand[0].GetName();
                    calculatedStrength.Add(inHand[2].GetStrength());
                    calculatedStrength.Add(inHand[0].GetStrength());
                    strengthFound = true;
                }
            }

            // Trips
            if (!strengthFound)
            {
                void MakeTrips (int tripsCard, int kicker1, int kicker2)
                {
                    calculatedStrength.Add(3);
                    handName[0] = "Trips";
                    if (inHand[tripsCard].GetName() == "Six")
                    {
                        handName[1] = "Trip Sixes";
                    }
                    else
                    {
                        handName[1] = "Trip " + inHand[tripsCard].GetName() + "s";
                    }
                    calculatedStrength.Add(inHand[tripsCard].GetStrength());
                    calculatedStrength.Add(inHand[kicker1].GetStrength());
                    calculatedStrength.Add(inHand[kicker2].GetStrength());
                    strengthFound = true;
                }
                if (firstCard == inHand[1].GetStrength() &&
                    firstCard == inHand[2].GetStrength())
                {
                    MakeTrips(0, 4, 3);
                }
                else if (secondCard == inHand[2].GetStrength() &&
                         secondCard == inHand[3].GetStrength())
                {
                    MakeTrips(1, 4, 0);
                }
                else if (inHand[2].GetStrength() == inHand[3].GetStrength() &&
                         inHand[2].GetStrength() == inHand[4].GetStrength())
                {
                    MakeTrips(2, 1, 0);
                }
            }

            // Two pair
            if (!strengthFound)
            {
                void MakeTwoPair (int kicker)
                {
                    calculatedStrength.Add(2);
                    handName[0] = "Two pair";
                    calculatedStrength.Add(inHand[3].GetStrength());
                    calculatedStrength.Add(inHand[1].GetStrength());
                    calculatedStrength.Add(inHand[kicker].GetStrength());
                    handName[1] = inHand[3].GetName() + "s and " + inHand[1].GetName() + "s";
                    strengthFound = true;
                }
                if (firstCard == secondCard &&
                    inHand[2].GetStrength() == inHand[3].GetStrength())
                {
                    MakeTwoPair(4);
                }
                else if (firstCard == secondCard &&
                        inHand[3].GetStrength() == inHand[4].GetStrength())
                {
                    MakeTwoPair(2);
                }
                else if (inHand[1].GetStrength() == inHand[2].GetStrength() &&
                        inHand[3].GetStrength() == inHand[4].GetStrength())
                {
                    MakeTwoPair(0);
                }
            }

            // One pair
            if (!strengthFound)
            {
                void MakePair(int pairStr, int kicker1, int kicker2, int kicker3)
                {
                    calculatedStrength.Add(1);
                    handName[0] = "Pair";
                    if (inHand[pairStr].GetName() == "Six")
                    {
                        handName[1] = "of Sixes";
                    }
                    else
                    {
                        handName[1] = "of " + inHand[pairStr].GetName() + "s";
                    }
                    calculatedStrength.Add(inHand[pairStr].GetStrength());
                    calculatedStrength.Add(inHand[kicker1].GetStrength());
                    calculatedStrength.Add(inHand[kicker2].GetStrength());
                    calculatedStrength.Add(inHand[kicker3].GetStrength());
                    strengthFound = true;
                }

                if (firstCard == secondCard)
                {
                    MakePair(0, 4, 3, 2);
                }
                else if (inHand[1].GetStrength() == inHand[2].GetStrength())
                {
                    MakePair(1, 4, 3, 0);   
                }
                else if (inHand[2].GetStrength() == inHand[3].GetStrength())
                {
                    MakePair(2, 4, 1, 0);
                }
                else if (inHand[3].GetStrength() == inHand[4].GetStrength())
                {
                    MakePair(3, 2, 1, 0);
                }
            }

            // High Card
            if (!strengthFound)
            {
                calculatedStrength.Add(0);
                handName[0] = inHand[4].GetName() + " high";
                handName[1] = "";
                calculatedStrength.Add(inHand[4].GetStrength());
                calculatedStrength.Add(inHand[3].GetStrength());
                calculatedStrength.Add(inHand[2].GetStrength());
                calculatedStrength.Add(inHand[1].GetStrength());
                calculatedStrength.Add(inHand[0].GetStrength());
                strengthFound = true;
            }

            KeyValuePair<string[], List<int>> handStrengthResult = new KeyValuePair<string[], List<int>>(handName, calculatedStrength);
            return handStrengthResult;
        }
    }
}
