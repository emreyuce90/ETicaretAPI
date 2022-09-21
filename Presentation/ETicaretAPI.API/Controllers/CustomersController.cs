﻿using ETicaretAPI.Application.Repositories.CustomerRepo;
using ETicaretAPI.Application.ViewModels.CustomerVM;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }



        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerAddVM model)
        {
            if (ModelState.IsValid)
            {
                await _customerWriteRepository.AddAsync(new () {Name = model.Name});
                await _customerWriteRepository.SaveChangesAsync();
                return Created("",model);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok(_customerReadRepository.GetAll());
        }
    }
}