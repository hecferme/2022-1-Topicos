using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.AdventureWorksLT.BL
{
    public class Customers
    {
        public IList<Model.Models.Customer> Listar()
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.Listar();
            return elResultado;
        }

        public async Task<IList<Model.Models.Customer>> ListarAsync()
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = await elRepositorio.ListarAsync();
            return elResultado;
        }

        public Model.Models.Customer? BuscarPorId(int id)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorId(id);
            return elResultado;
        }

        public Model.Models.CustomerDTO? BuscarPorIdDTO(int id)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorIdDTO(id);
            return elResultado;
        }

        public async Task<Model.Models.Customer?> BuscarPorIdAsync(int id)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = await elRepositorio.BuscarPorIdAsync(id);
            return elResultado;
        }

        public IList<Model.Models.Customer> BuscarPorNombreOApellido(string hilera)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorNombreOApellido(hilera);
            return elResultado;
        }

        public async Task<IList<Model.Models.Customer>> BuscarPorNombreOApellidoAsync(string hilera, int pageNumber = 0)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = await elRepositorio.BuscarPorNombreOApellidoAsync(hilera);
            return elResultado;
        }
        public IList<Model.Models.Customer> BuscarPorCountry(string hilera, int pageNumber = 0)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = elRepositorio.BuscarPorCountry(hilera, pageNumber);
            return elResultado;
        }
        public async Task<IList<Model.Models.Customer>> BuscarPorCountryAsync(string hilera, int pageNumber = 0)
        {
            var elRepositorio = new Repositorio.Customer();
            var elResultado = await elRepositorio.BuscarPorCountryAsync(hilera, pageNumber);
            return elResultado;
        }
    }
}
