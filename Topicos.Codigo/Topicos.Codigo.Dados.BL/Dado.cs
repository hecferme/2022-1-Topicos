namespace Topicos.Codigo.Dados.BL
{
    // clase para la lógica de negocio de los dados
    public class Dado
    {
        const int _NoInicialiado = -1;
        // propiedades
        private int _valor;

        public int Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        // métodos
        public Dado()
        {
            Valor = _NoInicialiado;
        }

        /// <summary>
        /// Constructor con un valor del dado
        /// </summary>
        /// <param name="valor">Valor del dado</param>
        public Dado(int valor)
        {
            Valor = valor;
        }

        /// <summary>
        /// Acción de tirar el dado 1 vez
        /// </summary>
        public void Tirar ()
        {
            var random = new Random();
            int elNumero = random.Next(1, 6);
            Valor = elNumero;
        }

        /// <summary>
        /// Acción de tirar el dado n veces
        /// </summary>
        /// <param name="cantidadVeces">Cantidad de veces que se tira el dado</param>
        public IList<int> Tirar(int cantidadVeces)
        {
            var lista = new List<int>();
            for (int i = 0; i < cantidadVeces; i++)
            {
                this.Tirar();
                lista.Add(this.Valor);
            }
            return lista;
        }
    }
}