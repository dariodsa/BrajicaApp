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
using System.Data.SqlClient;

namespace BrajicaApp
{
    /// <summary>
    /// Interaction logic for vjezba.xaml
    /// </summary>
    public partial class vjezba : Page
    {
        /// <summary>
        /// 1 je pisanje, 2 je citanje
        /// </summary>
        private int type = 1;

        private LetterGUI L = new LetterGUI(0);
        private LetterGUI L2 = new LetterGUI(1);

        string question = "";

        public vjezba()
        {
            InitializeComponent();
            Sentence.rjecnik = Baza.get();
            
            //Baza.DBOperation("SELECT * FROM STANJA_R", true);
            question = Baza.getNextLetter(type);
            pitanje.Text = question;

            Grid.SetRow(L, 3);
            Grid.SetRowSpan(L, 2);
            Grid.SetColumn(L, 4);

            Grid.SetRow(L2, 3);
            Grid.SetRowSpan(L2, 2);
            Grid.SetColumn(L2, 3);

            g1.Children.Add(L);
            g1.Children.Add(L2);

            

            //update(1, false);
        }
        public void update(int id, bool success)
        {
            
        }

        private void dalje_Click(object sender, RoutedEventArgs e)
        {
            List<Letter> slova = new List<Letter>();
            
            if(!L.isEmpty())slova.Add(new Letter(L.getMask()));
            if (!L2.isEmpty())slova.Add(new Letter(L2.getMask()));
            //MessageBox.Show(L.isEmpty() + " " + L2.isEmpty());
            if (type == 2)
                slova.Reverse();
            
            Sentence solution = new Sentence(slova,type);
            MessageBox.Show("p"+solution.ToString()+"p"+question+"p");
            string Ssolution=solution.ToString();
            if (Ssolution == question)
            {
                Baza.updateLetterState(question, 1,type);
                question = Baza.getNextLetter(type);
                pitanje.Text = question;
                border.BorderBrush = Brushes.ForestGreen;
                obrisi();
            }
            else
            {
                Baza.updateLetterState(question, 0,type);
                border.BorderBrush = Brushes.Red;
                obrisi();
            }

        }
        private void obrisi()
        {
            L.clearData();
            L2.clearData();
        }
        private void comboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            String value = comboBox.SelectedValue.ToString();
            if (value[0] == 'P') type = 1;
            else type = 2;
        }
    }
}
