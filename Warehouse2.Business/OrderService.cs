using System;
using System.Collections.Generic;
using Warehouse2.Data;
using Warehouse2.Entities;


namespace Warehouse2.Business
{
    public class OrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.GetOrderById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetOrders();
        }
        public Order CloseOrder(Order order)
        {
            var currentOrder = GetOrderById(order.Id);

            if (currentOrder == null)
            {
                throw new Exception("Order not found.");
            }

            if (currentOrder.ClosedAt != null)
            {
                throw new Exception("Order already closed.");
            }

            currentOrder.ClosedAt = order.ClosedAt ?? DateTimeOffset.Now;

            _orderRepo.UpdateOrder(currentOrder);

            return currentOrder;
        }

    }


}




