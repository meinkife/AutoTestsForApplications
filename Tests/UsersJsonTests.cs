using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using AutoTestsForApplications.DTO;
using FluentAssertions;
using NUnit.Framework;
using AutoTestsForApplications.Utils;

namespace AutoTestsForApplications.Tests;

public class UsersJsonTests
{
    private UsersResponseDTO users;

    [OneTimeSetUp]
    public void Setup()
    {
        users = JsonFileReader.Read<UsersResponseDTO>("UsersData.json");
    }

    [Test]
    public void Test1_UsersCountIsEqualTo10()
    {
        users.Data.Should().HaveCount(10);
    }

    [Test]
    public void Test2_FirstUserIsAliceJohnson()
    {
        users.Data.First().Profile.FullName.Should().Be("Alice Johnson");
    }

    [Test]
    public void Test3_IDsUniqueness()
    {
        var ids = users.Data.Select(user => user.Id).ToList();
        ids.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void Test4_CheckPremiumUser()
    {
        users.Data.Should().Contain(user => user.Profile.Tags.Contains("premium"));
    }

    [Test]
    public void Test5_AllCitiesAreNotEmpty()
    {
        users.Data.Should().OnlyContain(user => !string.IsNullOrEmpty(user.Profile.Address.City));
    }

    [Test]
    public void Test6_HasStockholmUser()
    {
        users.Data.Should().Contain(user => user.Profile.Address.City == "Stockholm");
    }

    [Test]
    public void Test7_AgesCheckBetween18And60()
    {
        users.Data.Should().OnlyContain(user => user.Profile.Age >= 18 && user.Profile.Age <= 60);
    }

    [Test]
    public void Test8_HasAdmin()
    {
        users.Data.Should().Contain(user => user.Roles.Contains("admin"));
    }

    [Test] //Задача 3
    public void Test9_AllUsersWithinSweden()
    {
        users.Data.Should().OnlyContain(user =>
            user.Profile.Address.Geo.Lat >= 55 && user.Profile.Address.Geo.Lat <= 69 &&
            user.Profile.Address.Geo.Lng >= 10 && user.Profile.Address.Geo.Lng <= 24);
    }

}