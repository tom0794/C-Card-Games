using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using cardProgram;

namespace cardsForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainMenu());
            Application.Run(new Blackjack());
        }

        //Consumes an unsorted list of int and returns a sorted list of int (largest to smallest)
        public static List<Card> SortHand(List<Card> unsortedList, Func<int, int, bool> listOrder)
        {
            if (unsortedList.Count == 1 || unsortedList.Count == 0)
            {
                return unsortedList;
            }
            else
            {
                return InsertItem(unsortedList[0], SortHand(unsortedList.GetRange(1, unsortedList.Count - 1), listOrder), listOrder);
            }
        }

        public static bool GreaterThan(int a, int b)
        {
            return a >= b;
        }

        public static bool LessThan(int a, int b)
        {
            return a <= b;
        }

        //Insert: Consumes an integer and a sorted list. Inserts int into list
        //Func<int, int, bool> myOperator
        public static List<Card> InsertItem(Card cardToAdd, List<Card> sortedList, Func<int, int, bool> predicate)
        {
            int indexPos = 0;
            bool done = false;
            while (!done)
            {
                if (predicate(cardToAdd.GetStrength(), sortedList[indexPos].GetStrength()))
                {
                    sortedList.Insert(indexPos, cardToAdd);
                    done = true;
                }
                else if (indexPos == sortedList.Count - 1)
                {
                    sortedList.Add(cardToAdd);
                    done = true;
                }
                indexPos++;
            }
            return sortedList;
        }

        public static Stack<Card> deckOfCards = new Stack<Card>(Card.Deck());
        public static List<Card> dealtHand = new List<Card>();
        public static List<Card> sortedHand = new List<Card>();
        public static List<int> handStrength = new List<int>();
        public static List<int> counterHands = new List<int>();

    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
