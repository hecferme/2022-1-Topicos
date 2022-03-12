using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Codigo.AsyncWarming
{
    public class AdventureWorksLTConsultas
    {
        public async Task MenuPrincipal ()
        {
            string? opcion = String.Empty;
            while (opcion != "0")
            {
                DesplegarMenu();
                opcion = CapturarOpcion();
                await EjecutarOpcion(opcion);
            }
        }

        private async Task EjecutarOpcion(string? opcion)
        {
            switch (opcion)
            {
                case "1": ConsultarPorId();
                    break;
                case "2": await ConsultarPorNombreOApellidoAsync();
                    break;
                case "3": await ConsultarPorCountryAsync();
                    break;
                case "0":
                    break;
                default: System.Console.WriteLine("Opción errónea");
                    break;
            }
        }

        private async Task ConsultarPorCountryAsync()
        {
            var customerCriteria = string.Empty;
            var pageNumberString = string.Empty;
            var pageNumber = 0;
            while (customerCriteria == null || customerCriteria == string.Empty)
            {
                System.Console.Write("Digite el Country de búsqueda para Customers: ");
                customerCriteria = System.Console.ReadLine();
                System.Console.Write("Digite el número de página deseada (Default) 0: ");
                pageNumberString = System.Console.ReadLine();
            }
            if (pageNumberString != null && pageNumberString != string.Empty)
            {
                pageNumber = int.Parse(pageNumberString);
            }

            var laLogicaDeNegocio = new AdventureWorksLT.BL.Customers();
            var timer = new Stopwatch();
            timer.Start();
            System.Console.WriteLine($"Iniciando la consulta en {timer.Elapsed}....");

            var cantidadCustomers = await laLogicaDeNegocio.ContarPorCountryAsync(customerCriteria);
            var losCustomers = await laLogicaDeNegocio.BuscarPorCountryAsync(customerCriteria, pageNumber);

            timer.Stop();
            System.Console.WriteLine($"Consulta finalizada en {timer.Elapsed}....");

            System.Console.WriteLine($"La cantidad total de registros es {cantidadCustomers}.");
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

        private async Task ConsultarPorNombreOApellidoAsync()
        {
            var customerCriteria = string.Empty;
            while (customerCriteria == null || customerCriteria == string.Empty)
            {
                System.Console.Write("Digite el criterio de búsqueda de Customers: ");
                customerCriteria = System.Console.ReadLine();
            }
            var laLogicaDeNegocio = new AdventureWorksLT.BL.Customers();

            var timer = new Stopwatch();
            timer.Start();
            System.Console.WriteLine($"Iniciando la consulta en {timer.Elapsed}....");

            var cantidadCustomers = await laLogicaDeNegocio.ContarPorNombreOApellidoAsync(customerCriteria);
            var losCustomers = await laLogicaDeNegocio.BuscarPorNombreOApellidoAsync(customerCriteria);

            timer.Stop();
            System.Console.WriteLine($"Consulta finalizada en {timer.Elapsed}....");

            System.Console.WriteLine($"La cantidad total de registros es {cantidadCustomers}.");
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
