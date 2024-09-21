using EFCoreProject;
using Microsoft.Extensions.Configuration;

namespace UnitTestProject;

public class Tests
{
    private string GetConnectionString(string connectionName,
        string settingsFileName = "appsettings.json")
    {
        var basePath = Directory.GetCurrentDirectory();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(settingsFileName, false, true)
            .Build();
        var connectionString = configuration.GetConnectionString(connectionName);
        return connectionString ?? "";
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestReadFromAppSettings()
    {
        var cnstring = GetConnectionString("CONTEXT_CONNECTIONSTRING",
            "appsettings.json");
        Assert.That(cnstring, Is.Not.Empty);
        Environment.SetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING", cnstring);
        using var ctx = new PortalContext();

        var cnstring2 = GetConnectionString("NEXT_CONNECTIONSTRING");
        Assert.That(cnstring2, Is.Not.Empty);
        Environment.SetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING", cnstring2);
        using var ctx2 = new PortalContext();
    }
}