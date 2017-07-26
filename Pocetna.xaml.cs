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
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Page 
    {
        double visina;
        public Pocetna()
        {
            InitializeComponent();
            System.Windows.Forms.Application.EnableVisualStyles();
        }
        private void obojiUspjeh()
        {
            double val = uspjeh.Value;
            double x = 100 - val;
            postotak.Text = Math.Round(val, 1).ToString()+"%";
            var k = new SolidColorBrush(Color.FromRgb( (byte)((int)2.55f * x),(byte)(int)( 2.55f * (100 - x)),(byte) 0));
            //var myColor = new Brush(2.0f * x, 2.0f * (1 - x), 0);
            uspjeh.Foreground = k;
            
        }
        private void test_Click(object sender, RoutedEventArgs e)
        {

        }

        private void vjezbanje_Click(object sender, RoutedEventArgs e)
        {
            vjezba new_page = new vjezba();
            this.NavigationService.Navigate(new_page); 
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*double kol = Baza.getGrade(1);
            double kol2 = Baza.getGrade(2);
            double rez = (kol + kol2) / 2.0;
            double sol = 1.0 / (1 + Math.Exp(-0.082 * (rez - 32)));
            
            uspjeh.Value = rez*100;
            obojiUspjeh();*/
        }

        private void autor_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MessageBox.Show("reset");
            Baza.callsPreBase();
            MessageBox.Show("reset done.");
        }
    }
}
