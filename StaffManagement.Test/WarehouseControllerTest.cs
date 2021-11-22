using AutoMapper;
using Contracts;
using Entities.DTO.WarehouseDTOs;
using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StaffManagement.Test
{
    public class WarehouseControllerTest
    {
        private Mock<IManagerContract> managerContractStub = new Mock<IManagerContract>();
        private Mock<IMapper> mapperStub = new Mock<IMapper>();
        [Fact]
        public void GetAllWarehouses_WithExistingWarehouses_ReturnsAllWarehouses()
        {
            // Arrange            
            var warehouse = new List<Warehouse> { getWarehouse()};
            managerContractStub.Setup(x => x.warehouseContract.GetAll())
                .Returns(warehouse);
            var controller = new WarehouseController(managerContractStub.Object, mapperStub.Object);
            
            //Act
            var result = controller.GetAllWarehouses();

            // Assert
            var warehouses = (result.Result as OkObjectResult).Value as List<Warehouse>;
            warehouse.Should().BeEquivalentTo(warehouse);       
        
        }
     
        [Fact]
        public void GetWarehouseById_WithExistingWarehous_ReturnsWarehouses()
        {
            // Arrange
            int warehouseId = 100;
            var warehouse = getWarehouse();
            managerContractStub.Setup(x => x.warehouseContract.Get(It.IsAny<int>()))
                .Returns(warehouse);
               
            var controller = new WarehouseController(managerContractStub.Object, mapperStub.Object);

            //Act
            var result = controller.GetWarehouseById(warehouseId);

            // Assert
            var warehouses = (result.Result as OkObjectResult).Value as Warehouse;
            warehouse.Should().BeEquivalentTo(warehouse);

        }

        [Fact]
        public void GetWarehouseById_WithoutExistingWarehous_ReturnsNotFound()
        {
            // Arrange
            int warehouseId = 100;
            var warehouse = getWarehouse();
            managerContractStub.Setup(x => x.warehouseContract.Get(It.IsAny<int>()))
                .Returns((Warehouse) null);

            var controller = new WarehouseController(managerContractStub.Object, mapperStub.Object);
            
            //Act
            var result = controller.GetWarehouseById(warehouseId);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
           

        }
        public Warehouse getWarehouse()
        {
            var warehouse = new Warehouse()
            {
                Id = 1,
                Name = "Gipr",
                Location = "Al-Khorazmiy"
            };
            return warehouse;
        }
        public WarehouseCreateDTO getWarehouseCreateDTO()
        {
            var warehouse = new WarehouseCreateDTO()
            {
                Name = "Gipr",
                Location = "Al-Khorazmiy"
            };
            return warehouse;
        }
    }
}
