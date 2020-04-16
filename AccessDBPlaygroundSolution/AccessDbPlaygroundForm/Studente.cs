using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDbPlaygroundForm
{
    public class Studente
    {
        public string Cognome;
        public string Nome;

        public Studente(string cognome, string nome)
        {
            Cognome = cognome;
            Nome = nome;
        }

        public override string ToString()
        {
            return Cognome + " " + Nome;
        }
    }
}
