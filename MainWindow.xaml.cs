using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BrajicaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private List<LetterGUI> slovaGUI = new List<LetterGUI>();
        private Sentence question;

        List<String> recenice = new List<string>();

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            recenice.Add("Pod tim se slojem nazirala");
            recenice.Add("A meni kad ćeš?");
            recenice.Add("Dobit ćeš! Dobar budi!");
            recenice.Add("Rasteš.");
            recenice.Add("Jelo na stolu čeka.");
            recenice.Add("Koju? Ovu uz peć?");
            recenice.Add("Najbolji komad daješ.");

            Random r = new Random();
            r1 = recenice[r.Next() % (recenice.Count)];
            sentence.Text = r1;

            for (int i = 0; i < 30; ++i) slovaGUI.Add(new LetterGUI(75 + i));
            for (int i=0;i<10;++i)
            {
                LetterGUI L = new LetterGUI(i);
                Grid.SetRow(L, 3);
                Grid.SetColumn(L, 2 * i + 2);
                g1.Children.Add(L);

                slovaGUI[9 - i] = L;
            }
            for (int i = 0; i < 10; ++i)
            {
                LetterGUI L = new LetterGUI(i+10);
                Grid.SetRow(L, 5);
                Grid.SetColumn(L, 2 * i + 2);
                g1.Children.Add(L);

                slovaGUI[19 - i] = L;
            }
            for (int i = 0; i < 10; ++i)
            {
                LetterGUI L = new LetterGUI(i+20);
                Grid.SetRow(L, 7);
                Grid.SetColumn(L, 2 * i + 2);
                g1.Children.Add(L);

                slovaGUI[29 - i] = L;
            }

            Sentence.rjecnik = Baza.get();

        }
        string r1 = "";
        private void dalje_Click(object sender, RoutedEventArgs e)
        {
            List<Letter> slova=new List<Letter>();
            foreach (LetterGUI slovo in slovaGUI)
            {
                slova.Add(new Letter(slovo.getMask()));
            }
            Sentence solution = new Sentence(slova);
            MessageBox.Show(solution.ToString());

            if (solution.ToString().CompareTo(r1) == 0)
                MessageBox.Show("Super");
            else MessageBox.Show("Nije dobro.");
            Random r = new Random();
            r1 = recenice[r.Next() % (recenice.Count)];
            sentence.Text = r1;

        }
    }
}
