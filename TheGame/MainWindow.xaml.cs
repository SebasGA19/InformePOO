using API_InformePOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TheGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player myPlayer = new Player();
        Dealer myDealer = new Dealer();
        int contadorG = 0;
        int contadorP = 0;
        int contadorJ = 0;

        private void Inicio()
        {
            btnReinicio.IsEnabled = false;
            myDealer.Generate();
            myDealer.Randomize();
            Card carta1 = myDealer.Deal();
            Card carta2 = myDealer.Deal();
            myPlayer.Init(carta1, carta2);
            myDealer.Init();

            foreach (Card card in myPlayer.Hand)
            {
                txtPlayerC.Text += card.Suit.ToString() + card.Symbol + "\n";
            }

            Card cartaD = myDealer.Hand[0];
            txtDealer.Text = cartaD.Suit.ToString() + cartaD.Symbol + "\n";

            if (Check(myPlayer.Hand) == "blackjack")
            {
                txtResultado.Text = "BlackJack!";
                btnEmpezar.IsEnabled = false;
                btnPlantar.IsEnabled = false;
                contadorG = contadorG + 1;
                contadorJ = contadorJ + 1;
                txtPartidasJ.Text = contadorJ.ToString();
                txtPartidasG.Text = contadorG.ToString();
                txtPartidasP.Text = contadorP.ToString();
                btnReinicio.IsEnabled = true;
            }
        }
        public string Check(List<Card> hand)
        {
            int value = 0;
            string checker = "falta";

            foreach (Card c in hand)
            {
                value = value + c.Score;
                if(value > 21 && c.Score== 11) 
                {
                    value = value - 10;
                }
            }
            if(value > 21)
            {
                checker = "quemado";
            }
            else if(value == 21)
            {
                checker = "blackjack";
            }
            else
            {
                checker = "falta";
            }
            return checker;
        }

        public int Value(List<Card> hand)
        {
            int value = 0;
            foreach (Card c in hand)
            {
                value = value + c.Score;
                if (value > 21 && c.Score == 11)
                {
                    value = value - 10;
                }
            }
            return value;
        }

        public MainWindow()
        {

            InitializeComponent();
            Inicio();

        }

        private void btnEmpezar_Click(object sender, RoutedEventArgs e)
        {
            Card card1 = myDealer.Deal();
            myPlayer.AddCard(card1);
            txtPlayerC.Text = "";
            foreach (Card card in myPlayer.Hand)
            {
                txtPlayerC.Text += card.Suit.ToString() + card.Symbol.ToString() + "\n";
            }
            
            if (Check(myPlayer.Hand) == "blackjack")
            {
                txtResultado.Text = "GANASTE!";
                btnEmpezar.IsEnabled = false;
                contadorG = contadorG + 1;
                contadorJ = contadorJ + 1;
                txtPartidasJ.Text = contadorJ.ToString();
                txtPartidasG.Text = contadorG.ToString();
                txtPartidasP.Text = contadorP.ToString();
                btnReinicio.IsEnabled = true;
            }
            else if (Check(myPlayer.Hand) == "quemado")
            {
                txtResultado.Text = "Te pasaste";
                imgMaster.Visibility = Visibility.Visible;
                btnEmpezar.IsEnabled = false;
                btnPlantar.IsEnabled = false;
                contadorP = contadorP + 1;
                contadorJ = contadorJ + 1;
                txtPartidasJ.Text = contadorJ.ToString();
                txtPartidasG.Text = contadorG.ToString();
                txtPartidasP.Text = contadorP.ToString();
                btnReinicio.IsEnabled = true;
            }
            else
            {

            }
            
        }

        private void btnPlantar_Click(object sender, RoutedEventArgs e)
        {
            btnEmpezar.IsEnabled = false;
            btnPlantar.IsEnabled = false;
            Card cartaD = myDealer.Hand[1];
            txtDealer.Text += cartaD.Suit.ToString() + cartaD.Symbol + "\n";
            while (Value(myDealer.Hand) < Value(myPlayer.Hand))
            {
                myDealer.AddCard(myDealer.Deal());
                txtDealer.Text = "";
                foreach (Card card in myDealer.Hand)
                {
                    txtDealer.Text += card.Suit.ToString() + card.Symbol.ToString() + "\n";
                }
            }
            if (Value(myDealer.Hand) >= Value(myPlayer.Hand) && Value(myDealer.Hand) <= 21 )
            {
                txtResultado.Text = "Gana la casa";
                contadorP = contadorP + 1;
                contadorJ = contadorJ + 1;
                imgMaster.Visibility = Visibility.Visible;
            }
            else
            {
                txtResultado.Text = "Gana el jugador";
                contadorG = contadorG + 1;
                contadorJ = contadorJ + 1;
            }
            txtPartidasJ.Text = contadorJ.ToString();
            txtPartidasG.Text = contadorG.ToString();
            txtPartidasP.Text = contadorP.ToString();
            btnReinicio.IsEnabled = true;
        }

        private void btnReinicio_Click(object sender, RoutedEventArgs e)
        {
            myDealer.Hand.Clear();
            myPlayer.Hand.Clear();
            txtPlayerC.Text = "";
            txtDealer.Text = "";
            txtResultado.Text = "";
            btnPlantar.IsEnabled = true;
            btnEmpezar.IsEnabled = true;
            imgMaster.Visibility = Visibility.Hidden;
            Inicio();
        }

    }
}
