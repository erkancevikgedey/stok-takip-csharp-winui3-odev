using StokTakip.EntityFramework;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public interface IItemService
    {
        List<Product> GetProducts();
        bool AddProduct(string productName, int productQuantity);
        bool DeleteProduct(int productId);
        string GetProductName(int productId);
        int GetProductQuantity(int productId);
        bool EditProduct(int productId, string productName, int productQuantity);
        bool AddStockToProduct(int productId, int quantity);
        bool RemoveStockFromProduct(int productId, int quantity);
    }
    public class ItemService : IItemService
    {
        private readonly IHistoryService _historyService;
        MainContext dbContext = new MainContext();

        public ItemService()
        {
            _historyService = new HistoryService();
        }

        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList<Product>();
        }

        public bool AddProduct(string productName, int productQuantity)
        {
            try
            {
                var product = new Product { ProductName = productName, ProductStock = productQuantity };
                dbContext.Add(product);
                _historyService.UpdateHistories(Models.Action.AddStock);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool DeleteProduct(int productId)
        {
        
                var product = GetProducts().Where(x => x.Id == productId).Single();


                dbContext.Remove(product);

                dbContext.SaveChanges();
                return true;
        }

        public string GetProductName(int productId)
        {
            var product = GetProducts().Where(x => x.Id == productId).Single();
            return product.ProductName;
        }

        public int GetProductQuantity(int productId)
        {
            var product = GetProducts().Where(x => x.Id == productId).Single();
            return product.ProductStock;
        }

        public bool EditProduct(int productId, string productName, int productQuantity)
        {
            try
            {
                var product = dbContext.Products.Where(x => x.Id == productId).Single();
                product.ProductName = productName;
                product.ProductStock = productQuantity;
                _historyService.UpdateHistories(Models.Action.Edit);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddStockToProduct(int productId, int quantity)
        {
            try
            {
                var product = dbContext.Products.Where(x => x.Id == productId).Single();
                product.ProductStock = product.ProductStock + quantity;
                var updateDetails = new Changed { ActionName = Models.Action.AddStock, ActionTime = DateTime.Now};
                dbContext.Add(updateDetails);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveStockFromProduct(int productId, int quantity)
        {
            try
            {
                var product = dbContext.Products.Where(x => x.Id == productId).Single();
                product.ProductStock = product.ProductStock - quantity;
                var updateDetails = new Changed { ActionName = Models.Action.StockDown, ActionTime = DateTime.Now };
                dbContext.Add(updateDetails);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
