using AutoMapper;
using Contracts;
using Entities.DTO.UserDTOs;
using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace StaffManagement.Test
{
    public class UserControllerTest
    {
        private  Mock<IManagerContract> managerContractStub = new Mock<IManagerContract>();
        private Mock<IMapper> mapperStub = new Mock<IMapper>();


        [Fact]
        public void CreateUser_WithUserToCreate_ReturnsCreatedUser()
        {
            //Arrange
            var userToCreate = new UserCreateDto()
            {
                FirstName = "First",
                LastName = "Last"
            };
            var createdUser = new User()
            {
                Id = 10,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName
            };
            var controler = new UserController(managerContractStub.Object, mapperStub.Object);

            managerContractStub.Setup(x => x.userContract.Create(It.IsAny<User>()))
                .Returns( createdUser );

            // Act
            var result = controler.CreateUser(userToCreate);

            //Assert
            var createdUser1 = (result.Result as CreatedAtActionResult).Value as User;
            Assert.IsType<CreatedAtActionResult>(result.Result);

            createdUser.Should().BeEquivalentTo(createdUser1);

        }

        [Fact]
        public void GetAllUsers_WithExistingUsers_ReturnsAllUsers()
        {
            //Arrange
            var expextedUsers = GetUsers();
            var controler = new UserController(managerContractStub.Object, mapperStub.Object);

            managerContractStub.Setup(x => x.userContract.GetAll())
                .Returns(expextedUsers);

            //Act
            var result = controler.GetAllUsers();

            //Assert
            var actualUsers = (result.Result as OkObjectResult).Value as List<User>;
            actualUsers.Should().BeEquivalentTo(expextedUsers);

        }

        [Fact]
        public void GetUserById_WithExistingUserId_ReturnsUser()
        {
            //Arrange
            var expextedUsers = GetUsers();
            var controler = new UserController(managerContractStub.Object, mapperStub.Object);

            managerContractStub.Setup(x => x.userContract.GetById(It.IsAny<int>()))
                .Returns(expextedUsers[0]);

            //Act
            var result = controler.GetUserById(expextedUsers[0].Id);

            //Assert
            var actualUsers = (result.Result as OkObjectResult).Value as User;
            actualUsers.Should().BeEquivalentTo(expextedUsers[0]);

        }
        
        [Fact]
        public void GetUserById_WithoutExistingUserId_ReturnsNotFound()
        {
            //Arrange
            int userId = 1000;
            var controler = new UserController(managerContractStub.Object, mapperStub.Object);

            managerContractStub.Setup(x => x.userContract.GetById(It.IsAny<int>()))
                .Returns((User) null);

            //Act
            var result = controler.GetUserById(userId);

            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }
        
        [Fact]
        public void UpdateUser_WithExistingUsers_ReturnsNoContent()
        {
            // Arrange
            var existingUser = GetUsers();
          
            managerContractStub.Setup(x => x.userContract.GetById(It.IsAny<int>()))
                .Returns(existingUser[0]);
            var userToUpdate = new User()
            {
                Id = existingUser[0].Id,
                FirstName = "Qwerty",
                LastName = "mnbv"
            };

            var controler = new UserController(managerContractStub.Object, mapperStub.Object);


            // Act
            var result = controler.UpdateUser(userToUpdate);

            //Assert
           result.Result.Should().BeOfType<NoContentResult>();

          
        }
        
        [Fact]
        public void DeleteUserById_WithExistingUserId_ReturnsNoContent()
        {
            // Arrange
            var existingUser = GetUsers();
             managerContractStub.Setup(x => x.userContract.GetById(It.IsAny<int>()))
                .Returns(existingUser[0]);
           

            var controler = new UserController(managerContractStub.Object, mapperStub.Object);


            // Act
            var result = controler.DeleteUserById(existingUser[0].Id);

            //Assert
            result.Should().BeOfType<NoContentResult>();
            

        }
        
        [Fact]
        public void DeleteUserById_WithoutExistingUserId_ReturnsBadRequest()
        {
            // Arrange          
            managerContractStub.Setup(x => x.userContract.GetById(It.IsAny<int>()))
                .Returns((User)null);
            
            var controler = new UserController(managerContractStub.Object, mapperStub.Object);

            // Act
            var result = controler.DeleteUserById(5);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        private List<User> GetUsers()
        {
            var userList = new List<User>()
            {
                new User()
                {
                    Id = 3,
                    FirstName = "qwert",
                    LastName = "zcxzzc",
                    Role = EnumRoles.Admin

                },
                 new User()
                {
                    Id = 3,
                    FirstName = "dasdsad",
                    LastName = "gfhhfh",
                    Role = EnumRoles.Hr
                },
                  new User()
                {
                    Id = 3,
                    FirstName = "ghjgjg",
                    LastName = "vcbcb",
                    Role = EnumRoles.Seller
                }
                

            };
            return userList;
        }
    }
}
