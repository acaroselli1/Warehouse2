﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse2.Business;
using Warehouse2.Entities;


namespace Warehouse2.Web.Controllers
{

    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {

            return Ok(_orderService.GetAllOrders());

        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpPost("close")]
        public IActionResult CloseOrder([FromBody]Order order)
        {
            _orderService.CloseOrder(order);
            return Ok();
        }


    }
}