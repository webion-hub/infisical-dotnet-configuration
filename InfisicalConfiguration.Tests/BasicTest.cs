using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfisicalConfiguration.Tests;

[TestClass]
public class SystemTests
{

  public TestContext TestContext { get; set; }


  [TestMethod]
  public void ShouldGetSecretsFromTestAccount()
  {


    var configuration = new ConfigurationBuilder()
    .AddInfisical(
        new InfisicalConfigBuilder()
            .SetProjectId("<project-id>")
            .SetEnvironment("dev")
            .SetSecretPath("/")
            .SetInfisicalUrl("http://localhost:8080")
            .SetAuth(
                new InfisicalAuthBuilder()
                    .SetUniversalAuth(
                        "<machine-identity-client-id>",
                        "<machine-identity-client-secret>"
                    )
                    .Build()
            )
            .Build()
    )
    .Build();


    foreach (var kvp in configuration.AsEnumerable())
    {
      TestContext.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
    }
  }
}