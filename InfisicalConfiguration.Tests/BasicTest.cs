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
            .SetProjectId("d3a577f2-efd7-49b4-a345-5e5aed564fc7")
            .SetEnvironment("dev")
            .SetSecretPath("/")
            .SetInfisicalUrl("http://localhost:8080")
            .SetAuth(
                new InfisicalAuthBuilder()
                    .SetUniversalAuth(
                        "fe5ed60a-76ca-4148-814e-05c0a84254c3",
                        "92d7de0e11e5cf7790de93780e4c1e594a639e9a0a45c1669191fc24a132ae08"
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