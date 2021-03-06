using System.Linq;
using aspnetcoregraphql.Data.Repositories;
using aspnetcoregraphql.Models.Entities;
using GraphQL.Types;

namespace aspnetcoregraphql.Models.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name, nullable: true).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}