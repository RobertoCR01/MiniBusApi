﻿using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Api.Controllers.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Administration;
using MiniBusManagement.Service.Administration;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Test
{
    public class MiniBusServiceTest
    {
        [Fact]
        public async Task TestMiniBusServiceGetSucces()
        {
            var miniBusList = A.Fake<List<MiniBus>>();
            miniBusList.Add(new MiniBus { Id = 1, IdCompany = 2, Capacity = "20", Brand = "Toyota" });
            miniBusList.Add(new MiniBus { Id = 2, IdCompany = 2, Capacity = "20", Brand = "Isuzu" });

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibus()).ReturnsAsync(miniBusList);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.GetMinibus("Roberto", It.IsAny<DateTime>());
            Assert.NotNull(actionResult);
            var listMiniBusResponse = (List<MiniBus>) actionResult;
            Assert.NotNull(listMiniBusResponse);
            Assert.Equal(2, listMiniBusResponse.Count);
        }
        [Fact]
        public async Task TestMiniBusServiceGetByIDSucces()
        {
            var miniBus = A.Fake<MiniBus>();
            miniBus.Id = 1;
            miniBus.IdCompany = 2;
            miniBus.Capacity = "20";
            miniBus.Brand = "Toyota";

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibusByID(miniBus.Id)).ReturnsAsync(miniBus);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.GetMiniBusByID(1,"Roberto", It.IsAny<DateTime>());
            Assert.NotNull(actionResult);
            var miniBusResponse = (MiniBus)actionResult;
            Assert.NotNull(miniBusResponse);
            Assert.Equal(1, miniBusResponse.Id);
        }
        [Fact]
        public async Task TestMiniBusServiceInsertSucces()
        {
            var miniBus = A.Fake<MiniBus>();
            miniBus.Id = 1;
            miniBus.IdCompany = 2;
            miniBus.Capacity = "20";
            miniBus.Brand = "Toyota";
            var response = 201;
            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.InsertMinibus(miniBus)).ReturnsAsync(response);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.InsertMinibus(miniBus, "Roberto", It.IsAny<DateTime>());
            Assert.Equal(201,actionResult);
        }
        [Fact]
        public async Task TestMiniBusServiceUpdateucces()
        {
            var miniBus = A.Fake<MiniBus>();
            miniBus.Id = 1;
            miniBus.IdCompany = 2;
            miniBus.Capacity = "20";
            miniBus.Brand = "Toyota";
            miniBus.Year = 2020;
            miniBus.ModificationDate = It.IsAny<DateTime>();
            miniBus.InsertionDate = It.IsAny<DateTime>();
            miniBus.UserInsert = "Roberto";
            miniBus.UserModifies = "Roberto";
            var response = 201;
            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.UpdateMinibus(miniBus)).ReturnsAsync(response);
            mockMiniBusRepository.Setup(c => c.GetMinibusByID(miniBus.Id)).ReturnsAsync(miniBus);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.UpdateMinibus(1,miniBus, "Roberto", It.IsAny<DateTime>());
            Assert.Equal(201, actionResult);
        }
    }
}
