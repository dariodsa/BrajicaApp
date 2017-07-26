using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.Windows.Controls;

namespace BrajicaApp
{
    class LetterGUI : Grid
    {
        private List<RadioButton> buttons = new List<RadioButton>();
        private int id;
        private bool[] klikani=new bool[6];
		
        public LetterGUI(int id) : base()
        {
            table();
            this.id = id;
            for (int i=0;i<6;++i)
            {
                RadioButton radio = new RadioButton();
                radio.Click += Radio_Checked;
                radio.GroupName = (id*6+i).ToString();
                radio.Name = ('a'+(i).ToString()+'a'.ToString()).ToString();
                radio.Visibility = Visibility.Visible;
                


                Grid.SetColumn(radio, i % 2);
                Grid.SetRow(radio, i / 2);
                radio.HorizontalAlignment = HorizontalAlignment.Center;
                radio.VerticalAlignment = VerticalAlignment.Center;
                this.Children.Add(radio);
                buttons.Add(radio);
                
            }
        }
        public void clearData()
        {
            foreach(var K in buttons)
            {
                K.IsChecked = false;
            }
        }
        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton R = (RadioButton)sender;
            int br =R.Name[1]-'0';
            klikani[br] = !klikani[br];
            if (klikani[br]==false)
                R.IsChecked = false;

        }
        public bool isEmpty()
        {
            for (int i = 0; i < 6; ++i)
                if (klikani[i]) return false;
            return true;
        }
        private void table()
        {
            for (int i = 0; i < 2; ++i)
            {
                ColumnDefinition C = new ColumnDefinition();
                C.Width = new GridLength(50, GridUnitType.Star);
                this.ColumnDefinitions.Add(C);
            }

            for (int i = 0; i < 3; ++i)
            {
                RowDefinition R = new RowDefinition();
                R.Height = new GridLength(33.3333, GridUnitType.Star);
                this.RowDefinitions.Add(R);
            }
            
        }

        public bool[,] getMask()
        {
            bool[,] mask = new bool[3, 2];
            for(int i=0;i<6;++i)
                if (buttons[i].IsChecked == true) mask[i/2, i%2] = true;
            return mask;
        }
    }
}
