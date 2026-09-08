using BookStore.DTO;
using FluentAssertions;
using helpers.classes;
using Interfaces.BookStore;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTestsForApplications.Tests
{
    public class BookStoreTests
    {
        private IBookStoreApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookStoreApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookStoreApi>();
        }

        [Test]
        public async Task GetUserToken()
        {
            var credentials = new UserCreateBodyDTO("GabaGama", "StrongPass123!");
            var result = await api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetUserId()
        {
            var credentials = new UserCreateBodyDTO("GabaGama", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            result.UserId.Should().NotBeNullOrEmpty();
        }
    }
}