using AutoTestsForApplications.DTO;
using AutoTestsForApplications.Utils;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace AutoTestsForApplications.Tests
{
    public class OrderJsonTests
    {
        private OrderDTO order;
        [OneTimeSetUp]
        public void Setup()
        {
            order = JsonFileReader.Read<OrderDTO>("OrderData.json");
        }

        [Test]
        public void Test1_CheckItemsIsNotNull()
        {
            foreach (var item in order.Items)
            {
                TestContext.WriteLine($"{item.ProductId} | {item.Quantity.ToString()} | {item.Price.ToString()}");
            }
            order.Items.Should().NotBeNull();
            order.Items.Should().HaveCount(3);

        }

        [Test]
        public void test2_CheckSumOfItems()
        {
            var sum = order.Items.Select(item => item.Quantity * item.Price).Sum();
            sum.Should().Be(order.Summary.ItemsTotal);
         }

        [Test]
        public void test3_CheckElectronicsQuantity()
        {
            var hasElectronicsCategory = order.Items.Where(item => item.Category == "Electronics").ToList();
            hasElectronicsCategory.Should().OnlyContain(item => item.Category == "Electronics");
            hasElectronicsCategory.Should().HaveCount(2);
         }
    }
}

