using System;
using System.Collections.Generic;
using System.IO;
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

namespace Zavatta.Lorenzo._4H.Rubrica
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona[] Rubrica = new Persona[10];
        int Conta = 0;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < Rubrica.Length; i++)
            {
                Rubrica[i] = new Persona();
            }
            Scrittura();
            Lettura();
            dgDati.ItemsSource = Rubrica;
        }

        int Lettura()
        {
            Conta = 0;
            StreamReader sr = new StreamReader("Dati.txt");
            for(int i = 0; i < Rubrica.Length; i++)
            {
                string riga = sr.ReadLine();
                Rubrica[i] = new Persona(riga);
                if(Rubrica[i].Nome != "")
                Conta++;
            }
            sr.Close();
            return Conta;
        }

        void Scrittura()
        {
            StreamWriter sw = new StreamWriter("Dati.txt");
            for(int i =0; i < Rubrica.Length; i++)
            {
                sw.WriteLine(Rubrica[i].ToString());
            }
            sw.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int Conta = 0;
            Conta = Lettura();
            if (Conta < Rubrica.Length)
            {
                AggiungiRubrica Finestra = new AggiungiRubrica();
                Finestra.ShowDialog();

                if(Finestra.exit == false)
                {
                    Rubrica[Conta] = Finestra.persona;
                    Conta++;
                    Scrittura();
                }                
            }
            else
            {
                MessageBox.Show("Limite persona raggiunto");
            }
            dgDati.ItemsSource = Rubrica;
            dgDati.Items.Refresh();
        }
    }
}
