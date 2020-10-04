using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_InformePOO
{
    public class Dealer
    {
        private List<Card> hand = new List<Card>();
        
        private Random random = new Random();
        Card MyCard;
        private List<Card> deck = new List<Card>();

        char[] suit2 = new char[] { '♥', '♦', '♠', '♣' };
        string[] symbol2 = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public List<Card> Hand { get => hand; set => hand = value; }

        public List<Card> Generate()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    MyCard = new Card(suit2[i], symbol2[j]);
                    deck.Add(MyCard);
                }
            }
            return deck;
        }

        public void Randomize()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
        public Card Deal()
        {
            Card lastItem = deck.LastOrDefault();
            deck.Remove(lastItem);
            return lastItem;
        }

        public void AddCard(Card carta)
        {
            hand.Add(carta);
        }

        public void Init()
        {
            Card carta1 = Deal();
            Card carta2 = Deal();


            AddCard(carta1);
            AddCard(carta2);
        }
    }
}
