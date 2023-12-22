namespace Ejercicio1.Clases
{
    public class Baraja
    {
        #region Propiedades
        private List<Naipe> naipes = new List<Naipe>();
        #endregion
        #region Metodos
        public void Inicializar()
        {
            string[] palos = { "oros", "copas", "espadas", "bastos" };

            foreach (var palo in palos)
            {
                for (int numero = 1; numero <= 12; numero++)
                {
                    naipes.Add(new Naipe(palo, numero));
                }
            }
        }
        public void Barajar()
        {
            int n = naipes.Count;

            Random random = new Random();

            while (n > 1)
            {
                n--;

                int k = random.Next(n + 1);

                Naipe value = naipes[k];
                naipes[k] = naipes[n];
                naipes[n] = value;
            }
        }
        public void Imprimir()
        {
            foreach (var naipe in naipes)
            {
                Console.WriteLine($"{naipe.Numero} de {naipe.Palo}");
            }
        }
        public void Ordenar()
        {
            naipes.Sort((n1, n2) =>
            {
                int paloComparison = string.Compare(n1.Palo, n2.Palo, StringComparison.Ordinal);

                if (paloComparison != 0)
                {
                    return paloComparison;
                }

                return n1.Numero.CompareTo(n2.Numero);
            });
        }
        #endregion
    }
}