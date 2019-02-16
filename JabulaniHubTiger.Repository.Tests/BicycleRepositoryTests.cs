using JabulaniHubTiger.Repository.Bicycle;
using JabulaniHubTiger.Repository.Data;
using JabulaniHubTiger.Repository.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Repository.Tests
{
    [TestFixture]
    public class BicycleRepositoryTests
    {
        private BicycleRepository _BicycleRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void Initialize()
        {
            _context = ContextFactory.CreateContext(true);
            _BicycleRepository = new BicycleRepository(_context);
        }



        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
            _context = null;
            _BicycleRepository = null;
        }

        [Test]
        public async Task should_add_bicycle()
        {
            var expected = new ORM.Bicycle
            {
                BicyleCondition = Helper.BicyleCondition.good,
                CreatedOn = DateTime.Now,
                Id = 1,
                Model = "Honda"
            };

            var result = await _BicycleRepository.InsertAsync(expected);

            Assert.AreEqual(1, result.Id);
        }


        [Test]
        public async Task should_get_bicycle()
        {

            var objectData = new ORM.Bicycle
            {
                BicyleCondition = Helper.BicyleCondition.good,
                CreatedOn = DateTime.Now,
                Id = 1,
                Model = "Honda"
            };

            var result = await _BicycleRepository.InsertAsync(objectData);

            var response = await _BicycleRepository.GetAsync(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Honda", response.Model);
        }

    }
}
