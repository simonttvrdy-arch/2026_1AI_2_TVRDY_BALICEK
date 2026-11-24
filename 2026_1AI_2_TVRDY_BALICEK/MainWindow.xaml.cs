using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2026_1AI_2_TVRDY_BALICEK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int Goal = 50;
        Random random = new Random();
        List<Card> cards = new List<Card>();
        int packs;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }
        public void StartGame()
        {
            cards.Clear();
            packs = 0;
            lblMessage.Content = "";
            btnOpen.IsEnabled = true;
            //Refresh();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Card novaKarta = RandomCard();
            lstCards.Items.Add(novaKarta.Icon + " " + novaKarta.Name + " (+" + novaKarta.Points + ")");
            cards.Add(novaKarta);
            packs++;
            if (Vyhodnotenie() >= Goal)
            {
                // tu už som vyhral a nebudem viac otvárať
                btnOpen.IsEnabled = false;
                lblMessage.Content = "Vyhral si! Stačilo ti " + packs + " balíčkov.";
            }

        }

        public int Vyhodnotenie()
        {
            int body = 0;
            foreach (Card card in cards)
            {
                body += card.Points;
            }
            lblScore.Content = "Body: " + body + " / 50";
            lblPacks.Content = "Otverených balíčkov: " + packs;
            return body;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            cards.Clear();
            packs = 0;
            lblMessage.Content = "";
            btnOpen.IsEnabled = true;
            lstCards.Items.Clear();
        }

        public Card RandomCard()
        {
            int roll = random.Next(100);
            if (roll < 70)
            {
                // 70/100 prípadov je obyčajna karta
                return new Common();
            }
            else if (roll < 95)
            {
                // (95-70) -> 25/100 prípadov je rare karta
                return new Rare();
            }
            else
            {
                // posledných 5/100 prípadov je legendary karta
                return new Legendary();
            }
        }

    }
}