using JabulaniHubTiger.Api.Controllers.API.V1;
using JabulaniHubTiger.Helper;
using JabulaniHubTiger.Service.Bicycle;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Api.Tests
{ 
    [TestFixture]
    public class BicycleControllerTests
    {
        private readonly Mock<IBicycleService> BicycleServiceMock = new Mock<IBicycleService>();
        private readonly BicycleController BicycleController;

        public BicycleControllerTests()
        {
            BicycleController = new BicycleController(BicycleServiceMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            BicycleServiceMock.Reset();
        }

        [Test]
        public async Task should_fail_to_add_bicycle()
        {
            
            var result = await BicycleController.Post(new Helper.BicycleRequestViewModel
            {
                BicyleCondition = Helper.BicyleCondition.good,
                Model = "Honda"
            });

            Assert.IsNotNull(result);
            var createRoute = result as ObjectResult;
            Assert.AreEqual(500, createRoute.StatusCode);
        }


        [Test]
        public async Task should_find_bicycle_by_id()
        {
            var result = await BicycleController.Get(300);
            Assert.IsNotNull(result);
            var createRoute = result as ObjectResult;
            Assert.AreEqual(404, createRoute.StatusCode);
        }
    }
}
