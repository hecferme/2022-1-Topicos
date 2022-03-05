using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.AdventureWorksLT.Model.Models;

namespace Topicos.AdventureWorksLT.BL.Repositorio
{
    internal class Customer : ICustomer
    {
        private readonly db_adventureworksltContext _contexto = new();
        private readonly int _pageNumber = 0;
        private readonly int _pagesize = 10;
        private readonly Mapper _mapper;

        public async Task<IList<Model.Models.Customer>> ListarAsync()
        {
            var resultado = await _contexto.Customers
                .Skip(_pagesize * _pageNumber).Take(_pagesize).
                OrderBy(c => c.FirstName).ToListAsync();
            return resultado;
        }
        public IList<Model.Models.Customer> Listar()
        {
            var resultado = _contexto.Customers
                .Skip(_pagesize * _pageNumber).Take(_pagesize).
                OrderBy(c => c.FirstName).ToList();
            return resultado;
        }

        public Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Model.Models.Customer, Model.Models.CustomerDTO>();
                cfg.CreateMap<Model.Models.CustomerAddress, Model.Models.CustomerAddressDTO>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public Customer()
        {
            _mapper = InitializeAutomapper();
        }

        public Customer(int pagesize)
        {
            _pagesize = pagesize;
            _mapper = InitializeAutomapper();
        }

        public Model.Models.CustomerDTO? BuscarPorIdDTO(int id)
        {
            Model.Models.CustomerDTO? resultadoDTO = null;
            var resultado = _contexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).FirstOrDefault(c => c.CustomerId == id);
            if (resultado != null)
            {
                resultadoDTO = _mapper.Map<CustomerDTO>(resultado);
            }               
            return resultadoDTO;
        }

        public Model.Models.Customer? BuscarPorId(int id)
        {
            var resultado = _contexto.Customers.Find(id);
            return resultado;
        }
        public async Task<Model.Models.Customer?> BuscarPorIdAsync(int id)
        {
            var resultado = await _contexto.Customers.FindAsync(id);
            return resultado;
        }

        public IList<Model.Models.Customer> BuscarPorNombreOApellido(string hilera, int pageNumber = 0)
        {
            var resultado = _contexto.Customers.Where(
                c => c.FirstName.Contains(hilera) || c.LastName.Contains(hilera))
                .Skip(_pagesize * pageNumber).Take(_pagesize).
                OrderBy(c => c.FirstName).ToList();
            return resultado;
        }

        public async Task<IList<Model.Models.Customer>> BuscarPorNombreOApellidoAsync(string hilera, int pageNumber = 0)
        {
            var resultado = await _contexto.Customers.Where(
                c => c.FirstName.Contains(hilera) || c.LastName.Contains(hilera))
                .Skip(_pagesize * pageNumber).Take(_pagesize).
                OrderBy(c => c.FirstName).ToListAsync();
            return resultado;
        }

        /// <summary>
        /// Lista todos los customers que tienen una dirección en un país determinado.
        /// </summary>
        /// <param name="hilera"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IList<Model.Models.Customer> BuscarPorCountry(string hilera, int pageNumber = 0)
        {
            var resultado = _contexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).Where(
                c => c.CustomerAddresses.Any(a => a.Address.CountryRegion.Contains(hilera)))
                .Skip(_pagesize * pageNumber).Take(_pagesize).
                OrderBy(c => c.CustomerId).ToList();
            return resultado;
        }

        public async Task<IList<Model.Models.Customer>> BuscarPorCountryAsync(string hilera, int pageNumber = 0)
        {
            var resultado = await _contexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).Where(
                c => c.CustomerAddresses.Any(a => a.Address.CountryRegion.Contains(hilera)))
                .Skip(_pagesize * pageNumber).Take(_pagesize).
                OrderBy(c => c.CustomerId).ToListAsync();
            return resultado;
        }

    }
}
