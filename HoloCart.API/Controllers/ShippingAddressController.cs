﻿using HoloCart.API.Base;
using HoloCart.Core.Features.ShippingAddressFeatures.command.Requests;
using HoloCart.Core.Features.ShippingAddressFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ShippingAddressController : AppControllerBase
    {
        [HttpGet(Router.ShippingAddressRouting.GetAll)]
        public async Task<IActionResult> GetAlllshippingAdressws()
        {
            var Response = await Mediator.Send(new GetAllShippingAddressQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.ShippingAddressRouting.GetById)]
        public async Task<IActionResult> GetShippingAddressById(int id)
        {
            var Response = await Mediator.Send(new GetShippingAddressByIdQuery(id));
            return NewResult(Response);
        }
        [HttpGet(Router.ShippingAddressRouting.GetByUserId)]
        public async Task<IActionResult> GetShippingAddressesByUserId(int UserId)
        {
            var Response = await Mediator.Send(new GetShippingAddressesByUserIdQuery(UserId));
            return NewResult(Response);
        }
        [HttpPost(Router.ShippingAddressRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateShippingAddressCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.ShippingAddressRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateShippingAddressCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.ShippingAddressRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteShippingAddressCommand(id));
            return NewResult(Response);
        }
    }
}
