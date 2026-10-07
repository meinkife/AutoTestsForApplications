using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace AutoTestsForApplications.ForUI.TestData
{
    public static class LoginTestData
    {
        public static IEnumerable<TestCaseData> UsersFromJson()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Users.json");
            var json = File.ReadAllText(path);
            var users = JsonSerializer.Deserialize<List<string>>(json);

            foreach (var user in users)
            {
                yield return new TestCaseData(user).SetName($"Login_{user}");
            }
        }
    }
}