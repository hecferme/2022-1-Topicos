using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.AdventureWorksLT.BL
{
    public class Customers
    {
        public Model.Models.Customer? BuscarPorId(int id)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorId(id);
            return elResultado;
        }

        public IList<Model.Models.Customer> BuscarPorNombreOApellido(string hilera)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorNombreOApellido(hilera);
            return elResultado;
        }
    }
}
