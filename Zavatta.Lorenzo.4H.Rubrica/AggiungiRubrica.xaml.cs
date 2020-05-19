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
using System.Windows.Shapes;

namespace Zavatta.Lorenzo._4H.Rubrica
{
    /// <summary>
    /// Logica di interazione per AggiungiRubrica.xaml
    /// </summary>
    public partial class AggiungiRubrica : Window
    {
        
        public Persona persona { get; set; }
        public bool exit = false;

        public AggiungiRubrica()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(exit == false)
            {
                if (nuovoNome.Text == "" || nuovoCognome.Text == "" || nuovaCitta.Text == "" || nuovoCap.Text == "" || nuovoTelefono.Text == "" || nuovaNascita.Text == "")
                {
                    MessageBox.Show("ERRORE!!! devi compilare tutti i campi");
                    e.Cancel = true;
                }
                else
                {
                    this.persona = new Persona($"{nuovoNome.Text};{nuovoCognome.Text};{nuovaCitta.Text};{nuovoCap.Text};{nuovoTelefono.Text};{nuovaNascita.Text}");
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("GRAZIE!!!");
        }

       private void Salva_Click(object sender, RoutedEventArgs e)
       {
            exit = false;
            this.Close();
       }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            exit = true;
            this.Close();
        }
    }
}
