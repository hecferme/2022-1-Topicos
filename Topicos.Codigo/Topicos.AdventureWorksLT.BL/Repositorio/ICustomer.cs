
namespace Topicos.AdventureWorksLT.BL.Repositorio
{
    public interface ICustomer
    {
        IList<Model.Models.Customer> BuscarPorCountry(string hilera, int pageNumber = 0);

        Task<int> ContarPorCountryAsync(string hilera);

        Task<IList<Model.Models.Customer>> BuscarPorCountryAsync(string hilera, int pageNumber = 0);

        Model.Models.Customer? BuscarPorId(int id);

        Task<Model.Models.Customer?> BuscarPorIdAsync(int id);

        IList<Model.Models.Customer> BuscarPorNombreOApellido(string hilera, int pageNumber = 0);

        Task<int> ContarPorNombreOApellidoAsync(string hilera);

        Task<IList<Model.Models.Customer>> BuscarPorNombreOApellidoAsync(string hilera, int pageNumber = 0);

        IList<Model.Models.Customer> Listar();

        Task<IList<Model.Models.Customer>> ListarAsync();
    }
}