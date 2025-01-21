namespace InfisicalConfiguration;

public class UniversalAuthCredentials
{
  public string ClientId { get; set; }
  public string ClientSecret { get; set; }

  public UniversalAuthCredentials(string clientId, string clientSecret)
  {
    ClientId = clientId;
    ClientSecret = clientSecret;
  }
}

public enum InfisicalAuthType
{
  Universal,
}

public class InfisicalAuth
{
  private InfisicalAuthType AuthType { get; set; }
  private UniversalAuthCredentials? universalAuthCredentials;

  internal InfisicalAuth() { }

  public InfisicalAuthType GetAuthMethod()
  {
    return AuthType;
  }

  public UniversalAuthCredentials GetUniversalAuth()
  {
    if (universalAuthCredentials == null)
    {
      throw new InvalidOperationException("UniversalAuth must be set");
    }

    if (AuthType == InfisicalAuthType.Universal)
    {
      return universalAuthCredentials;
    }

    throw new InvalidOperationException("AuthType must be set. Are you missing a call to SetUniversalAuth?");
  }

  internal void SetUniversalAuthCredentials(UniversalAuthCredentials credentials)
  {
    universalAuthCredentials = credentials;
    AuthType = InfisicalAuthType.Universal;
  }
}

public class InfisicalAuthBuilder
{
  private readonly InfisicalAuth _auth;

  public InfisicalAuthBuilder()
  {
    _auth = new InfisicalAuth();
  }

  public InfisicalAuthBuilder SetUniversalAuth(string clientId, string clientSecret)
  {
    _auth.SetUniversalAuthCredentials(new UniversalAuthCredentials(clientId, clientSecret));
    return this;
  }

  public InfisicalAuth Build()
  {
    var auth = _auth;
    if (auth.GetAuthMethod() == InfisicalAuthType.Universal)
    {
      var universalAuth = auth.GetUniversalAuth();
      if (string.IsNullOrEmpty(universalAuth.ClientId) || string.IsNullOrEmpty(universalAuth.ClientSecret))
      {
        throw new InvalidOperationException("ClientId and ClientSecret must be set");
      }
    }
    else
    {
      throw new InvalidOperationException("AuthType must be set. Are you missing a call to SetUniversalAuth?");
    }

    return auth;
  }
}