using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace AutoTestsForApplications.Utils;

public static class JsonFileReader
{
    public static T Read<T>(string fileName)
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", fileName);
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json);
    }
}