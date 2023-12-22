namespace Ejercicio1.Clases
{
    public class Naipe
    {
        #region Propiedades
        public string Palo { get; set; }
        public int Numero { get; set; }
        #endregion
        #region Constructor
        public Naipe(string palo, int numero)
        {
            Palo = palo;
            Numero = numero;
        }
        #endregion
    }
}