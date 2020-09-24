using System;
using System.Collections.Generic;
using System.Text;

namespace API_InformePOO
{
    class Player
    {
        private List<Card> hand = new List<Card>();
        public void AddCard(Card carta)
        {
            hand.Add(carta);
        }

        public void Init(Card carta1, Card carta2)
        {
            AddCard(carta1);
            AddCard(carta2);
        }
    }
}
