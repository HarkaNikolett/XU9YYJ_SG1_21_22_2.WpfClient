﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using XU9YYJ_HFT_2021221.Logic.Interfaces;
using XU9YYJ_HFT_2021221.Models.Entities;
using XU9YYJ_HFT_2021221.Models.Models;


namespace XU9YYJ_HFT_2021221.Endpoint.Controllers
{
    //add controller -> api -> empty
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderLogic orderLogic;

        public OrderController(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }
        // GET: api/Order/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Order> Get()
        {
            return orderLogic.ReadAll();
        }

        // GET api/Order/Get/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return orderLogic.Read(id);
        }

        // POST api/Order/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Order order)
        {
            var result = new ApiResult(true);
            try
            {
                orderLogic.Create(order);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }
            return result;

        }

        // PUT api/Order/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Order order)
        {
            var result = new ApiResult(true);
            try
            {
                orderLogic.Update(order);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }
            return result;
        }

        // DELETE api/Order/Delete/5
        [HttpDelete("{id}")]

        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);
            try
            {
                orderLogic.Delete(id);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }
            return result;
        }
        //GET: api/Order/AvaragePOValueBySupplier
        [HttpGet]

        public IEnumerable<AveragePOValue> AvaragePOValueBySupplier()
        {
            return orderLogic.AvaragePOValueBySupplier();
        }
        [HttpGet]
        [ActionName("GetAll/Top3OrderByValue")]
        public IList<Order> Top3OrderByValue()
        { return orderLogic.Top3OrderByValue(); }
        [HttpGet]
        [ActionName("GetAll/TotalQtyOfItem")]
        public int TotalQtyOfItem(int itemid)
        { return orderLogic.TotalQtyOfItem(itemid); }

        [HttpGet]
        [ActionName("GetAll/POListOfItem")]
        public IList<Order> POListOfItem(int itemid)
        {
            return orderLogic.POListOfItem(itemid);
        }

        [HttpGet]
        [ActionName("GetAll/POListOfSupplier")]
        public IList<Order> POListOfSupplier(int supplier)
        {
           
            return orderLogic.POListOfSupplier(supplier);
        }
    }
}
