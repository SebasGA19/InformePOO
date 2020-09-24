using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_InformePOO
{
    class Dealer
    {
        private List<Card> hand = new List<Card>();
        
        private Random random = new Random();
        Card MyCard;
        private List<Card> deck = new List<Card>();

        string[] suit2 = new string[] { "corazon", "rombo", "pica", "trebol" };
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

        public void Randomize(List<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public Card Deal(List<Card> list)
        {
            Card lastItem = list.LastOrDefault();
            list.Remove(lastItem);
            return lastItem;
        }

        public void AddCard(Card carta)
        {
            hand.Add(carta);
        }

        public void Init()
        {
            Card carta1;
            Card carta2;

            carta1 = Deal(deck);
            carta2 = Deal(deck);

            AddCard(carta1);
            AddCard(carta2);
        }
    }
}
