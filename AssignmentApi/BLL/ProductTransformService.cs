using AssignmentApi.Models;
using AssignmentApi.BLL.Interfaces;
using System.Text;

namespace AssignmentApi.BLL
{
    public class ProductTransformService : IProductTransformService
    {
        private string Build(List<Image> imgs, Func<Image, string> selector)
        {
            if (imgs == null || imgs.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            for (int i = 0; i < imgs.Count; i++)
            {
                if (i > 0)
                    sb.Append(';');

                var value = selector(imgs[i]) ?? string.Empty;

                sb.Append(i)
                  .Append(':')
                  .Append(value);
            }
            
            return sb.ToString();
        }

        public object Transform(List<Product> products)
        {
            return products.Select(p => new
            {
                p.id,
                p.name,
                ImageId = Build(p.images, x => x.id),
                ImageAlt = Build(p.images, x => x.alt),
                ImageUrl = Build(p.images, x => x.detail?.url ?? string.Empty),
                ImageWidth = Build(p.images, x => x.detail?.width.ToString() ?? string.Empty),
                ImageHeight = Build(p.images, x => x.detail?.height.ToString() ?? string.Empty)
            });
        }
    }
}