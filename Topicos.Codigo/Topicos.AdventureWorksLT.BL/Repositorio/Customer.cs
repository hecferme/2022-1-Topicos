using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.AdventureWorksLT.Model.Models;

namespace Topicos.AdventureWorksLT.BL.Repositorio
{
    internal class Customer
    {
        private readonly db_adventureworksltContext _contexto = new();

        public Model.Models.Customer? BuscarPorId (int id)
        {
            var resultado = _contexto.Customers.Find(id);
            return resultado;
        }

        public IList<Model.Models.Customer> BuscarPorNombreOApellido (string hilera)
        {
            var resultado = _contexto.Customers.Where(c => c.FirstName.Contains(hilera) || c.LastName.Contains (hilera)).OrderBy(c => c.FirstName).ToList();
            return resultado;
        }
    }
}
