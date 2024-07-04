using System;

namespace VjezbaDelegati
{
    internal class Program
    {
       public class Semafor
        {
            public delegate void PromjenaStanjaHandler(string stanje);
            public event PromjenaStanjaHandler PromjenaStanja;

            public void PromijeniStanje(string novoStanje)
            {
                PromjenaStanja?.Invoke(novoStanje);
            }
        }

        public class Raskrsnica
        {
            private Semafor _semafor;

            public Raskrsnica()
            {
                _semafor = new Semafor();
                _semafor.PromjenaStanja += Semafor_PromjenaStanja;
            }

            private void Semafor_PromjenaStanja(string novoStanje)
            {
                Console.WriteLine($"Stanje semafora na raskrsnici je promijenjeno na: {novoStanje}");
            }

            public void PromijeniStanjeSemafora(string novoStanje)
            {
                _semafor.PromijeniStanje(novoStanje);
            }
        }

        public class Program1
        {
            public static void Main(string[] args)
            {
                Raskrsnica raskrsnica = new Raskrsnica();
                raskrsnica.PromijeniStanjeSemafora("Crveno");
                raskrsnica.PromijeniStanjeSemafora("Zeleno");
            }
        }
    }
}