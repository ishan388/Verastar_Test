using VS_Models.ViewModels;

namespace VS_DLRepositories.CustomersOrdersItems
{
    public interface IDLCustomersOrdersItemsRepo
    {
        Task<List<VM_CustomersOrdersItems>> GetAllData();
    }
}
