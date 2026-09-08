using AutoTestsForApplications.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AutoTestsForApplications.Tests
{
    public class DiTests
    {
        // Заглушка вместо настоящего EmailSender
        private class FakeEmailSender : IEmailSender
        {
            public List<(string To, string Text)> SentMessages { get; } = new();

            public void Send(string to, string text)
            {
                SentMessages.Add((to, text));
            }
        }

        [Test]
        public void UserNotifier_UsesInjectedSender()
        {
            // создаём заглушку и внедряем в UserNotifier через конструктор
            var fakeSender = new FakeEmailSender();
            var notifier = new UserNotifier(fakeSender);

            // вызываем метод
            notifier.Notify(42);

            // проверяем, что отправитель был вызван с нужными данными
            fakeSender.SentMessages.Should().HaveCount(1);
            fakeSender.SentMessages[0].To.Should().Be("user@mail.com");
            fakeSender.SentMessages[0].Text.Should().Be("Hello, user 42!");
        }
    }
}