using DobbesteenLib.Entities;
using DobbesteenLib.Services;
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

namespace Yahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpelVerloop spelVerloop = new SpelVerloop();
        
        bool rol1 = true;
        bool rol2 = true;
        bool rol3 = true;
        bool rol4 = true;
        bool rol5 = true;
        bool rol6 = true;
        int eindeEersteDeel = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            SpelVerloop starten = new SpelVerloop();
            lblTotal.Visibility = Visibility.Hidden;
            lblTotalText.Visibility = Visibility.Hidden;

        }

        void Reset()
        {
            btnRol.IsEnabled = true;
            lblAantalBeurten.Content = 3;
            btn1.Background = Brushes.LightGray;
            btn2.Background = Brushes.LightGray;
            btn3.Background = Brushes.LightGray;
            btn4.Background = Brushes.LightGray;
            btn5.Background = Brushes.LightGray;
            btn6.Background = Brushes.LightGray;
            btn1.Content = "";
            btn2.Content = "";
            btn3.Content = "";
            btn4.Content = "";
            btn5.Content = "";
            btn6.Content = "";
            rol1 = true;
            rol2 = true;
            rol3 = true;
            rol4 = true;
            rol5 = true;
            rol6 = true;
        }
        void EindeSingleNummers()
        {
            if (eindeEersteDeel == 6)
            {
                int eind1 = Convert.ToInt32(btnEentjes.Content);
                int eind2 = Convert.ToInt32(btnTwees.Content);
                int eind3 = Convert.ToInt32(btnDries.Content);
                int eind4 = Convert.ToInt32(btnViers.Content);
                int eind5 = Convert.ToInt32(btnVijfs.Content);
                int eind6 = Convert.ToInt32(btnZess.Content);
                int total = eind1 + eind2 + eind3 + eind4 + eind5 + eind6;
                lblTotal.Visibility = Visibility.Visible;
                lblTotalText.Visibility = Visibility.Visible;
                lblTotal.Content = total;
            }
        }

        private void btnRol_Click(object sender, RoutedEventArgs e)
        {
            int beurten = int.Parse(lblAantalBeurten.Content.ToString());
            if (beurten > 0)
            {                
                if (rol1 == true)
                {
                    spelVerloop.RolSteen1();
                    btn1.Content = spelVerloop.StenenList[0].Waarde;
                }
                if (rol2 == true)
                {
                    spelVerloop.RolSteen2();
                    btn2.Content = spelVerloop.StenenList[1].Waarde;
                }
                if (rol3 == true)
                {
                    spelVerloop.RolSteen3();
                    btn3.Content = spelVerloop.StenenList[2].Waarde;
                }
                if (rol4 == true)
                {
                    spelVerloop.RolSteen4();
                    btn4.Content = spelVerloop.StenenList[3].Waarde;
                }
                if (rol5 == true)
                {
                    spelVerloop.RolSteen5();
                    btn5.Content = spelVerloop.StenenList[4].Waarde;
                }
                if (rol6 == true)
                {
                    spelVerloop.RolSteen6();
                    btn6.Content = spelVerloop.StenenList[5].Waarde;
                }
                beurten--;
                lblAantalBeurten.Content = beurten;
            }
            if(beurten == 0)
            {
                
                btnRol.IsEnabled = false;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (rol1 == true)
            {
                rol1 = false;
                btn1.Background = Brushes.Gray;
            }
            else
            { 
                rol1 = true;
                btn1.IsEnabled = true;
                btn1.Background = Brushes.LightGray;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (rol2 == true)
            {
                rol2 = false;
                btn2.Background = Brushes.Gray;
            }
            else
            {
                rol2 = true;
                btn2.IsEnabled = true;
                btn2.Background = Brushes.LightGray;
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (rol3 == true)
            {
                rol3 = false;
                btn3.Background = Brushes.Gray;
            }
            else
            {
                rol3 = true;
                btn3.IsEnabled = true;
                btn3.Background = Brushes.LightGray;
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (rol4 == true)
            {
                rol4 = false;
                btn4.Background = Brushes.Gray;
            }
            else
            {
                rol4 = true;
                btn4.IsEnabled = true;
                btn4.Background = Brushes.LightGray;
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (rol5 == true)
            {
                rol5 = false;
                btn5.Background = Brushes.Gray;
            }
            else
            {
                rol5 = true;
                btn5.IsEnabled = true;
                btn5.Background = Brushes.LightGray;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (rol6 == true)
            {
                rol6 = false;
                btn6.Background = Brushes.Gray;
            }
            else
            {
                rol6 = true;
                btn6.IsEnabled = true;
                btn6.Background = Brushes.LightGray;
            }
        }

        private void btnEentjes_Click(object sender, RoutedEventArgs e)
        {
            int aantalEentjes = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 1)
                {
                    aantalEentjes++;
                }
            }
            btnEentjes.Content = aantalEentjes;
            btnEentjes.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnTwees_Click(object sender, RoutedEventArgs e)
        {
            int aantalTwees = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 2)
                {
                    aantalTwees += 2;
                }
            }
            btnTwees.Content = aantalTwees;
            btnTwees.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnDries_Click(object sender, RoutedEventArgs e)
        {
            int aantalDries = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 3)
                {
                    aantalDries += 3;
                }
            }
            btnDries.Content = aantalDries;
            btnDries.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnViers_Click(object sender, RoutedEventArgs e)
        {
            int aantalViers = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 4)
                {
                    aantalViers += 4;
                }
            }
            btnViers.Content = aantalViers;
            btnViers.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnVijfs_Click(object sender, RoutedEventArgs e)
        {
            int aantalVijfs = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 5)
                {
                    aantalVijfs += 5;
                }
            }
            btnVijfs.Content = aantalVijfs;
            btnVijfs.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnZess_Click(object sender, RoutedEventArgs e)
        {
            int aantalZess = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 6)
                {
                    aantalZess += 6;
                }
            }
            btnZess.Content = aantalZess;
            btnZess.IsEnabled = false;
            Reset();
            eindeEersteDeel++;
            EindeSingleNummers();
        }

        private void btnThreeOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int totaal = 0;
            bool ThreeOfAKind = false;

            for (int i = 0; i <= 5; i++)
            {
                int nummer = 0;
                for (int j = 0; j <= 5; j++)
                {
                    if(spelVerloop.StenenList[j].Waarde == i)
                    {
                        nummer++;
                        totaal += spelVerloop.StenenList[j].Waarde;
                    }
                    if(nummer > 2)
                    {
                        ThreeOfAKind = true;
                    }
                }
            }

            if (ThreeOfAKind == true)
            {
                btnThreeOfAKind.Content = totaal;
            }
            else
            {
                btnThreeOfAKind.Content = 0;
            }            

            btnThreeOfAKind.IsEnabled = false;
            Reset();
        }

        private void btnFourOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int totaal = 0;
            bool FourOfAKind = false;

            for (int i = 0; i <= 5; i++)
            {
                int nummer = 0;
                for (int j = 0; j <= 5; j++)
                {
                    if (spelVerloop.StenenList[j].Waarde == i)
                    {
                        nummer++;
                        totaal += spelVerloop.StenenList[j].Waarde;
                    }
                    if (nummer > 3)
                    {
                        FourOfAKind = true;
                    }
                }
            }

            if (FourOfAKind == true)
            {
                btnFourOfAKind.Content = totaal;
            }
            else
            {
                btnFourOfAKind.Content = 0;
            }

            btnFourOfAKind.IsEnabled = false;
            Reset();
        }

        private void btnChance_Click(object sender, RoutedEventArgs e)
        {
            int totaal = 0;
            for (int i = 0; i <= 5; i++)
            {
                totaal += spelVerloop.StenenList[i].Waarde;
            }
            btnChance.Content = totaal;
            btnChance.IsEnabled = false;
            Reset();
        }

        private void btnYahtzee_Click(object sender, RoutedEventArgs e)
        {
            if ((spelVerloop.StenenList[0].Waarde == spelVerloop.StenenList[1].Waarde) &&
                (spelVerloop.StenenList[1].Waarde == spelVerloop.StenenList[2].Waarde) &&
                (spelVerloop.StenenList[2].Waarde == spelVerloop.StenenList[3].Waarde) &&
                (spelVerloop.StenenList[4].Waarde == spelVerloop.StenenList[5].Waarde))
            {
                btnYahtzee.Content = 50;
            }
            else
                btnYahtzee.Content = 0;

            btnYahtzee.IsEnabled = false;
            Reset();
        }
    }
}
