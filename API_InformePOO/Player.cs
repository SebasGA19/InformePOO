using System;
using System.Collections.Generic;
using System.Text;

namespace API_InformePOO
{
    public class Player
    {
        private List<Card> hand = new List<Card>();

        public List<Card> Hand { get => hand; set => hand = value; }

        public void AddCard(Card carta)
        {
            Hand.Add(carta);
        }

        public void Init(Card carta1, Card carta2)
        {
            AddCard(carta1);
            AddCard(carta2);
        }

    }
}
