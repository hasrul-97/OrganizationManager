using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Organization.Abstraction.Business;
using Organization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationHandler _organizationHandler;
        private readonly HubConnection _hubConnection;
        public OrganizationController(IOrganizationHandler organizationHandler, IConfiguration configuration)
        {
            _organizationHandler = organizationHandler;
            _hubConnection = new HubConnectionBuilder().WithUrl(configuration.GetSection("hub").Value).Build();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _organizationHandler.GetAllUser());
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            string response = await _organizationHandler.AddUser(user);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("UserAdded", string.Format("A new user has been added: {0}", user.Name));
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            string response = await _organizationHandler.UpdateUser(user);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("UserUpdated", string.Format("A user has been updated: {0}", user.Name));
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            string response = await _organizationHandler.DeleteUser(user);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("UserUpdated", string.Format("A user has been deleted: {0}", user.Name));
            }
            return Ok(response);
        }

        public async Task SendPulse(string method, string description)
        {
            await _hubConnection.StartAsync();
            await _hubConnection.InvokeAsync(method, description);
            await _hubConnection.DisposeAsync();
        }
    }
}
