using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavatta.Lorenzo._4H.Rubrica
{
    public class Persona
    {
        private DateTime _dataNascita;
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string NTelefono { get; set; }
        public int Eta { get { return DateTime.Now.Year - _dataNascita.Year; } }


        public Persona()
        {
            Nome = "";
            Cognome = "";
            Citta = "";
            CAP = "";
            NTelefono = "";
            _dataNascita = new DateTime(2019, 1, 1);
        }


        public Persona(string riga)
        {
            string[] persone = riga.Split(';');
            if(persone.Length != 6)
            {
                throw new Exception("Errore");
            }
            Nome = persone[0];
            Cognome = persone[1];
            Citta = persone[2];
            CAP = persone[3];
            NTelefono = persone[4];
            _dataNascita = Convert.ToDateTime(persone[5]);
        }


        public override string ToString()
        {
            return $"{Nome};{Cognome};{Citta};{CAP};{NTelefono};{_dataNascita}";
        }
    }


}
