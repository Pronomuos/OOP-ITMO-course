using System;
using ShopManager.Models;
using System.Collections.Generic;
using System.Linq;
using ShopManager.Repositories.Interfaces;


namespace ShopManager.Repositories
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        protected List<ProductType> productTypeList;

        public ProductTypesRepository()
        {
            productTypeList = new List<ProductType>();
        }
        
        public IEnumerable<ProductType> GetTypes()
        {
            return productTypeList;
        }


        public void Insert(Guid id, string name)
        {
            var type = new ProductType(id, name);
            if (!productTypeList.Contains(type))
                productTypeList.Add(type);
        }

        public void Delete(Guid id)
        {
            var typeToRemove = productTypeList.SingleOrDefault(x => x.ProductId == id);
            if (typeToRemove != null)
                productTypeList.Remove(typeToRemove);
        }

        public void UpdateName(Guid id, string name)
        {
            var index = productTypeList.FindIndex(x => x.ProductId == id);
            if (index != -1)
                productTypeList[index].ProductName = name;
        }

        public string GetName(Guid id)
        {
            var index = productTypeList.FindIndex(x => x.ProductId == id);
            return (index != -1) ? 
                productTypeList[index].ProductName :
                default;
        }

        public Guid GetId(string name)
        {
            var index = productTypeList.FindIndex(x => x.ProductName == name);
            return (index != -1) ? 
                 productTypeList[index].ProductId :
                 default;
        }
    }
}