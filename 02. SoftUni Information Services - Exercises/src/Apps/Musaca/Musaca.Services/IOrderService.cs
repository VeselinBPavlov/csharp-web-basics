using Musaca.Models;

namespace Musaca.Services
{
    public interface IOrderService
    {
        void AddProduct(Product product, string userId);
        void CashoutOrder(string orderId);
        void CreateOrder(string userId);
        Order GetActiveOrderByUserId(string userId);
        System.Collections.Generic.List<Order> GetCompletedOrders(string userId);
    }
}