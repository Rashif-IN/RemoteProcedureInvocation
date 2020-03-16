﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace user_handler.Controllers
{
    public class user_controller : ControllerBase
    {

        private IMediator meciater;

        public user_controller(IMediator mediatr)
        {
            meciater = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<UseCase.User.Query.GetAll.Dto>> Get()
        {
            var result = new UseCase.User.Query.GetAll.Command();
            return Ok(await meciater.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int ID)
        {
            var result = new UseCase.User.Query.Get.Command(ID);
            var wait = await meciater.Send(result);
            return wait != null ? (IActionResult)Ok(wait) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(UseCase.User.Command.Post.Handler data)
        {
            var result = await meciater.Send(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, UseCase.User.Command.Put.Handler data)
        {
            data.Dataa.Attributes.id = ID;
            var result = await meciater.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var command = new UseCase.User.Command.Delete.Handler(ID);
            var result = await meciater.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}
