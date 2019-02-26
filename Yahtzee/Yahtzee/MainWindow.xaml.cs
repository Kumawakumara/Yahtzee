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
        int eindeTweedeDeel = 0;        
        
        public MainWindow()
        {
            InitializeComponent();         
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }
        void StartNewGame()
        {
            lblTotal.Visibility = Visibility.Hidden;
            lblTotalText.Visibility = Visibility.Hidden;
            lblTotalTweedeDeel.Visibility = Visibility.Hidden;
            lblTotaalTweedeDeelText.Visibility = Visibility.Hidden;
            lblTotaalSpel.Visibility = Visibility.Hidden;

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

            for (int i = 0; i <= 5; i++)
            {
                spelVerloop.StenenList[i].Waarde = 0;
            }
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

                VerbergEersteDeel();
            }
        }
        void VerbergEersteDeel()
        {
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            lbl3.Visibility = Visibility.Hidden;
            lbl4.Visibility = Visibility.Hidden;
            lbl5.Visibility = Visibility.Hidden;
            lbl6.Visibility = Visibility.Hidden;

            btnEentjes.Visibility = Visibility.Hidden;
            btnTwees.Visibility = Visibility.Hidden;
            btnDries.Visibility = Visibility.Hidden;
            btnViers.Visibility = Visibility.Hidden;
            btnVijfs.Visibility = Visibility.Hidden;
            btnZess.Visibility = Visibility.Hidden;
            
        }
        void EindeOndersteRij()
        {
            if (eindeTweedeDeel == 6)
            {
                int threeOfAKind = Convert.ToInt32(btnThreeOfAKind.Content);
                int fourOfAKind = Convert.ToInt32(btnFourOfAKind.Content);
                int kleineStraat = Convert.ToInt32(btnKleineStraat.Content);
                int groteStraat = Convert.ToInt32(btnGroteStraat.Content);
                int chance = Convert.ToInt32(btnChance.Content);
                int yahtzee = Convert.ToInt32(btnYahtzee.Content);
                

                int total = threeOfAKind + fourOfAKind + kleineStraat + groteStraat + chance + yahtzee;
                lblTotalTweedeDeel.Content = total;
                

                VerbergTweedeDeel();
            }
        }
        void VerbergTweedeDeel()
        {
            lbl3OfKind.Visibility = Visibility.Hidden;
            lbl4OfKind.Visibility = Visibility.Hidden;
            lblKleineStraat.Visibility = Visibility.Hidden;
            lblGroteStraat.Visibility = Visibility.Hidden;
            lblChance.Visibility = Visibility.Hidden;
            lblYahtzee.Visibility = Visibility.Hidden;

            btnThreeOfAKind.Visibility = Visibility.Hidden;
            btnFourOfAKind.Visibility = Visibility.Hidden;
            btnKleineStraat.Visibility = Visibility.Hidden;
            btnGroteStraat.Visibility = Visibility.Hidden;
            btnChance.Visibility = Visibility.Hidden;
            btnYahtzee.Visibility = Visibility.Hidden;

            lblTotaalTweedeDeelText.Visibility = Visibility.Visible;
            lblTotalTweedeDeel.Visibility = Visibility.Visible;
        }
        private void EndGame()
        {
            if (eindeEersteDeel == 6 && eindeTweedeDeel == 6)
            {
                lblTotaalSpel.Visibility = Visibility.Visible;
                btn1.Visibility = Visibility.Hidden;
                btn2.Visibility = Visibility.Hidden;
                btn3.Visibility = Visibility.Hidden;
                btn4.Visibility = Visibility.Hidden;
                btn5.Visibility = Visibility.Hidden;
                btn6.Visibility = Visibility.Hidden;
                btnRol.Visibility = Visibility.Hidden;
                lblBeurten.Visibility = Visibility.Hidden;
                lblAantalBeurten.Visibility = Visibility.Hidden;


                int firstPart = Convert.ToInt32(lblTotal.Content);
                int secondPart = Convert.ToInt32(lblTotalTweedeDeel.Content);
                int totaal = firstPart + secondPart;
                lblTotaalSpel.Content = "Totaal spel: " + totaal;
            }
        }
        
        void RolStenen()
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
            if (beurten == 0)
            {

                btnRol.IsEnabled = false;
            }
        }
        void CheckKleineStraat()
        {
            bool one = false;
            bool two = false;
            bool three = false;
            bool four = false;
            bool five = false;
            bool six = false;

            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 1)
                {
                    one = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 2)
                {
                    two = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 3)
                {
                    three = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 4)
                {
                    four = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 5)
                {
                    five = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 6)
                {
                    six = true;
                }
            }

            if (one == true && two == true && three == true && four == true)
            {
                btnKleineStraat.Content = 30;
            }
            else if (two == true && three == true && four == true && five == true)
            {
                btnKleineStraat.Content = 30;
            }
            else if (three == true && four == true && five == true && six == true)
            {
                btnKleineStraat.Content = 30;
            }
            else
            {
                btnKleineStraat.Content = 0;
            }
        }
        void CheckGroteStraat()
        {
            bool one = false;
            bool two = false;
            bool three = false;
            bool four = false;
            bool five = false;
            bool six = false;

            for (int i = 0; i <= 5; i++)
            {
                if (spelVerloop.StenenList[i].Waarde == 1)
                {
                    one = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 2)
                {
                    two = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 3)
                {
                    three = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 4)
                {
                    four = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 5)
                {
                    five = true;
                }
                else if (spelVerloop.StenenList[i].Waarde == 6)
                {
                    six = true;
                }
            }

            if (one == true && two == true && three == true && four == true && five == true)
            {
                btnGroteStraat.Content = 40;
            }
            else if (two == true && three == true && four == true && five == true && six == true)
            {
                btnGroteStraat.Content = 40;
            }
            else
            {
                btnGroteStraat.Content = 0;
            }
        }

        private void btnRol_Click(object sender, RoutedEventArgs e)
        {
            RolStenen();
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
            EndGame();
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
            EndGame();
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
            EndGame();
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
            EndGame();
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
            EndGame();
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
            EndGame();
        }

        private void btnThreeOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int totaal = 0;
            bool ThreeOfAKind = false;

            for (int i = 1; i <= 6; i++)
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
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
        }

        private void btnFourOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int totaal = 0;
            bool FourOfAKind = false;

            for (int i = 1; i <= 6; i++)
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
                EndGame();
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
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
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
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
        }

        private void btnYahtzee_Click(object sender, RoutedEventArgs e)
        {   
            if (spelVerloop.StenenList[0].Waarde != 0)
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
            }
            else
            {
                btnYahtzee.Content = 0;
            }
            

            btnYahtzee.IsEnabled = false;
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
        }

        private void btnGroteStraat_Click(object sender, RoutedEventArgs e)
        {
            CheckGroteStraat();            
            btnGroteStraat.IsEnabled = false;
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
        }

        private void btnKleineStraat_Click(object sender, RoutedEventArgs e)
        {
            CheckKleineStraat();
            btnKleineStraat.IsEnabled = false;
            eindeTweedeDeel++;
            EindeOndersteRij();
            Reset();
            EndGame();
        }        
    }
}
