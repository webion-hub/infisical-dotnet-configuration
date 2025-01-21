using Microsoft.Extensions.Configuration;

namespace InfisicalConfiguration;

public class InfisicalConfigurationSource : IConfigurationSource
{
  private readonly InfisicalConfig _config;


  public InfisicalConfigurationSource(
    InfisicalConfig config
    )
  {
    _config = config;
  }

  public IConfigurationProvider Build(IConfigurationBuilder builder)
  {
    return new InfisicalConfigurationProvider(_config);
  }
}