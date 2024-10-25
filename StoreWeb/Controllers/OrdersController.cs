﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities;

using Store.Service.Services.OrderService;
using Store.Service.Services.OrderService.DTOs;
using StoreService.HandleResponses;
using StoreWeb.Controllers;
using System.Security.Claims;

namespace Store.Web.Controllers
{

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailsDTO>> CreateOrderAsync(OrderDTO input)
        {
            var order = await _orderService.CreateOrderAsync(input);

            if (order == null)
            {
                return BadRequest(new Response(400, "Error while creating your order"));
            }

            return Ok(order);
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDTO>>> GetAllOrdersForUserAsync()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var orders = await _orderService.GetAllOrdersForUserAsync(email);

            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetOrderByIdAsync(Guid id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await _orderService.GetOrderByIdAsync(id);

            return Ok(order);
        }

        [HttpGet]
        //public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetAllDeliveryMethodAsync()
        //{
        //    return Ok(await _orderService.GetAllDeliveryMethodAsync());
        //}

    }
}