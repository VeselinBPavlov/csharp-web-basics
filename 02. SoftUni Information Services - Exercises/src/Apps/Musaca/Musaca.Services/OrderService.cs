using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Models;
using Musaca.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Services
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext dbContext;

        public OrderService(MusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreateOrder(string userId)
        {
            var order = new Order() { CashierId = userId, IssuedOn = DateTime.Now, Status = OrderStatus.Active };
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

        }
        public void AddProduct(Product product, string userId)
        {
            var order = dbContext.Orders
                .SingleOrDefault(o => o.CashierId == userId && o.Status == OrderStatus.Active);
            order.Products.Add(new OrderProduct() { OrderId = order.Id, ProductId = product.Id });
            dbContext.SaveChanges();
        }
        public Order GetActiveOrderByUserId(string userId)
        {
            var order = dbContext.Orders
                .Include(o => o.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .SingleOrDefault(o => o.CashierId == userId && o.Status == OrderStatus.Active);

            return order;
        }
        public List<Order> GetCompletedOrders(string userId)
        {
            var orders = dbContext.Orders.Where(o => o.Status == OrderStatus.Completed && o.CashierId == userId)
                .Include(o => o.Cashier)
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .ToList();
            return orders;
        }
        public void CashoutOrder(string orderId)
        {
            var order = dbContext.Orders.Find(orderId);
            var userId = order.CashierId;
            order.Status = OrderStatus.Completed;
            dbContext.SaveChanges();
            CreateOrder(userId);
        }
    }
}
