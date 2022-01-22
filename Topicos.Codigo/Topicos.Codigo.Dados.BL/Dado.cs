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

        public Dado(int valor)
        {
            Valor = valor;
        }

        public void Tirar ()
        {
            var random = new Random();
            int elNumero = random.Next(1, 6);
            Valor = elNumero;
        }

        public void Tirar (int cantidadVeces)
        {
            for (int i = 0; i < cantidadVeces; i++)
            {
                this.Tirar();
            }
        }
    }
}