﻿using Bakery.Product.DomainApi.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bakery.Product.DomainApi.UnitTest.Model
{
    public class DealInfoTest
    {
        private readonly DealInfo _dealInfo;

        public DealInfoTest()
        {
            _dealInfo = new DealInfo();
        }

        [Test]
        public void TestSetAndGetName()
        {
            _dealInfo.Deals = GetDeals();
            Assert.IsTrue(_dealInfo.Deals.Count > 0);
        }

        private List<Deal> GetDeals()
        {
            return
                new List<Deal> { new Deal { Description = "", Name = "" } };
        }
    }
}