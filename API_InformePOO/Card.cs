using System;

namespace API_InformePOO
{
    public class Card
    {
        private char suit;
        private string symbol;
        private int score;
        private string color;

        public Card(char suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;

            if (suit == '♥' || suit == '♦')
            {
                color = "rojo";
            }
            else
            {
                color = "negro";
            }

            if (symbol == "A")
            {
                score = 11;
            }
            else if (symbol == "2")
            {
                score = 2;
            }
            else if (symbol == "3")
            {
                score = 3;
            }
            else if (symbol == "4")
            {
                score = 4;
            }
            else if (symbol == "5")
            {
                score = 5;
            }
            else if (symbol == "6")
            {
                score = 6;
            }
            else if (symbol == "7")
            {
                score = 7;
            }
            else if (symbol == "8")
            {
                score = 8;
            }
            else if (symbol == "9")
            {
                score = 9;
            }
            else if (symbol == "10")
            {
                score = 10;
            }
            else if (symbol == "J")
            {
                score = 10;
            }
            else if (symbol == "Q")
            {
                score = 10;
            }
            else if (symbol == "K")
            {
                score = 10;
            }
        }

        public char Suit { get => suit; set => suit = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Score { get => score; set => score = value; }
        public string Color { get => color; set => color = value; }
    }
}
