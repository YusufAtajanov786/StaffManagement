using AutoMapper;
using Contracts;
using Entities.DTO.WarehouseDTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IManagerContract _managerContract;
        private readonly IMapper _mapper;

        public WarehouseController(IManagerContract managerContract, IMapper mapper)
        {
            this._managerContract = managerContract ?? throw new ArgumentNullException(nameof(managerContract));
            this._mapper = mapper;
        }


        // GET: api/<WarehouseController>
        [HttpGet("Get-All-Warehouses")]
        public ActionResult<IEnumerable<Warehouse>> GetAllWarehouses()
        {
            return Ok(_managerContract.warehouseContract.GetAll());
        }

        // GET api/<WarehouseController>/5
        [HttpGet("Get-Warehouse-By-Id/{id}")]
        public ActionResult<Warehouse> GetWarehouseById(int id)
        {
            var user = _managerContract.warehouseContract.Get(id);
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<WarehouseController>
        [HttpPost("Create-Warehouse")]
        public ActionResult<Warehouse> CreateWarehouse([FromBody] WarehouseCreateDTO warehouse)
        {
            var warehouseToCreate = _mapper.Map<Warehouse>(warehouse);
            var createdWarehouse = _managerContract.warehouseContract.Create(warehouseToCreate);
            _managerContract.Save();
            return createdWarehouse;
        }

        // PUT api/<WarehouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _managerContract.Save();
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("Delete-Warehouse/{id}")]
        public ActionResult Delete(int id)
        {
            var warehouse = _managerContract.warehouseContract.Get(id);
            if(warehouse is null)
            {
                return NotFound();
            }
            _managerContract.warehouseContract.Delete(warehouse);
            _managerContract.Save();
            return NoContent();
        }
    }
}
