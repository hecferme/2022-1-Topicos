using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Codigo.Warming
{
    public class AdventureWorksLTConsultas
    {
        public void MenuPrincipal ()
        {
            string? opcion = String.Empty;
            while (opcion != "0")
            {
                DesplegarMenu();
                opcion = CapturarOpcion();
                EjecutarOpcion(opcion);
            }
        }

        private void EjecutarOpcion(string? opcion)
        {
            switch (opcion)
            {
                case "1": ConsultarPorId();
                    break;
                case "2": ConsultarPorNombreOApellido();
                    break;
                case "3": ConsultarPorCountry();
                    break;
                case "0":
                    break;
                default: System.Console.WriteLine("Opción errónea");
                    break;
            }
        }

        private void ConsultarPorCountry()
        {
            var customerCriteria = string.Empty;
            var pageNumberString = string.Empty;
            var pageNumber = 0;
            while (customerCriteria == string.Empty)
            {
                System.Console.Write("Digite el Country de búsqueda para Customers: ");
                customerCriteria = System.Console.ReadLine();
                System.Console.Write("Digite el número de página deseada (Default) 0: ");
                pageNumberString = System.Console.ReadLine();
            }
            if (pageNumberString != string.Empty)
            {
                pageNumber = int.Parse(pageNumberString);
            }


            var laLogicaDeNegocio = new AdventureWorksLT.BL.Customers();
            var losCustomers = laLogicaDeNegocio.BuscarPorCountry(customerCriteria, pageNumber);
            if (losCustomers.Count == 0)
            {
                System.Console.WriteLine("Customers no encontrados.");
            }
            else
            {
                foreach (var customer in losCustomers)
                {
                    ImprimaCustomerDetallado(customer);
                }
            }
        }

        private void ConsultarPorNombreOApellido()
        {
            var customerCriteria = string.Empty;
            while (customerCriteria == string.Empty)
            {
                System.Console.Write("Digite el criterio de búsqueda de Customers: ");
                customerCriteria = System.Console.ReadLine();
            }
            var laLogicaDeNegocio = new AdventureWorksLT.BL.Customers();
            var losCustomers = laLogicaDeNegocio.BuscarPorNombreOApellido(customerCriteria);
            if (losCustomers.Count == 0)
            {
                System.Console.WriteLine("Customers no encontrados.");
            }
            else
            {
                foreach (var customer in losCustomers)
                {
                    ImprimaCustomer(customer);
                }
            }
        }

        private void ConsultarPorId()
        {
            System.Console.Write("Digite el id del Customer: ");
            var customerId = System.Console.ReadLine();
            var customerIdInt = 0;
            if (int.TryParse(customerId, out customerIdInt))
            {
                var laLogicaDeNegocio = new AdventureWorksLT.BL.Customers();
                var elCustomer = laLogicaDeNegocio.BuscarPorId(customerIdInt);
                if (elCustomer == null)
                {
                    System.Console.WriteLine("Customer no encontrado.");
                }
                else
                {
                    ImprimaCustomer(elCustomer);
                }
            }
        }

        private void ImprimaCustomer(AdventureWorksLT.Model.Models.Customer elCustomer)
        {
            System.Console.WriteLine($"Id: {elCustomer.CustomerId} Nombre: {elCustomer.FullName} Teléfono: {elCustomer.Phone}");
        }

        private void ImprimaCustomerDetallado(AdventureWorksLT.Model.Models.Customer elCustomer)
        {
            System.Console.WriteLine($"Id: {elCustomer.CustomerId} Nombre: {elCustomer.FullName} City: {elCustomer.CustomerAddresses.FirstOrDefault().Address.City}");
        }

        private string? CapturarOpcion()
        {
            System.Console.Write("Digite la opción deseada: ");
            var opcion = System.Console.ReadLine();
            return opcion;
        }

        public void DesplegarMenu()
        {
            System.Console.WriteLine("Menú principal");
            System.Console.WriteLine("1. Consultar Customer por Id");
            System.Console.WriteLine("2. Consultar Customers por Nombre o Apellido");
            System.Console.WriteLine("3. Consultar Customers por Country");
            System.Console.WriteLine("0. Salir");

        }
    }
}
