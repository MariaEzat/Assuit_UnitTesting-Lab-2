using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace CarFactoryAPI_test
{
    public class OwnerRepositoryTests
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;

        public OwnerRepositoryTests()
        {
            // Create Mock of dependencies
            factoryContextMock = new Mock<FactoryContext>();

            // use fake object as dependency
            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }

        [Fact]
       
        public void AddOwner_NewOwner_AddedSuccessfully()
        {
            // Arrange
            Owner newOwner = new Owner() { Id = 1, Name = "John Doe" };

            // Act
            bool isAdded = ownerRepository.AddOwner(newOwner);

            // Assert
            Assert.True(isAdded);
        }

        [Fact]
       
        public void GetOwnerById_AskForOwner1_ReturnOwner()
        {
            // Arrange

            // Build the mock Data
            Owner owner = new Owner() { Id = 1, Name = "John Doe"};

            // setup called DbSets
            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(new List<Owner> { owner });

            // Act 
            Owner retrievedOwner = ownerRepository.GetOwnerById(1);

            // Assert
            Assert.NotNull(retrievedOwner);
        }
    }
}
