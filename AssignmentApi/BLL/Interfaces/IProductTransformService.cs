using AssignmentApi.Models;

namespace AssignmentApi.BLL.Interfaces
{
    public interface IProductTransformService
    {
        object Transform(List<Product> products);
    }
}