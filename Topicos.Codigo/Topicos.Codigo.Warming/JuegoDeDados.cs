using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.Codigo.Dados.BL;

namespace Topicos.Codigo.Warming
{
    public class JuegoDeDados
    {
        /// <summary>
        /// Se encarga de tirar 2 dados las veces que el usuario lo desee y que muestre el valor de los dados en cada una de las veces que se tire.
        /// </summary>
        public void InicieElJuego ()
        {
            int veces = ObtenerVecesDeTirarElDado();
            TiraLosDadosEneVeces(veces);
        }

        private void TiraLosDadosEneVeces(int veces)
        {
            var dado1 = new Dado();
            var dado2 = new Dado();
            for (int i = 0; i < veces; i++)
            {
                TireLosDadosUnaVez(dado1, dado2);
                MuestreElResultado(i, dado1.Valor, dado2.Valor);
            }
        }

        private void MuestreElResultado(int iteracion, int dado1, int dado2)
        {
            //System.Console.WriteLine(string.Format("En la iteración {0} el dado 1 salió en {1} y el dado 2 salió en {2}.", iteracion, dado1.Valor, dado2.Valor));
            System.Console.WriteLine($"En la iteración {iteracion} el dado 1 salió en {dado1} y el dado 2 salió en {dado2}.");

        }

        private void TireLosDadosUnaVez(Dado dado1, Dado dado2)
        {
            var lista1 = dado1.Tirar(10);
            var lista2 = dado2.Tirar(10);
            AnimarListaDevalores(lista1);
            AnimarListaDevalores(lista2);
        }

        private void AnimarListaDevalores(IList<int> lista)
        {
            foreach (var item in lista)
            {
                System.Console.Write(item);
                System.Threading.Thread.Sleep(100);
                System.Console.Write("\r"); // carriage return 0x0A
            };
        }

        private int ObtenerVecesDeTirarElDado()
        {
            var veces = 0;
            var elValorCapturado = string.Empty;
            var capturaExitosa = false;
            while (! capturaExitosa)
            {
                System.Console.Write("Digite la cantidad de veces que desea tirar los dados: ");
                elValorCapturado = System.Console.ReadLine();
                capturaExitosa = int.TryParse(elValorCapturado, out veces);
                if (! capturaExitosa)
                {
                    System.Console.WriteLine("El valor digitado no corresponde a un número entero.");
                }
            }
            return veces;
        }
    }
}
