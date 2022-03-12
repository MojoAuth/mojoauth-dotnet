# MojoAuth DotNet SDK Web App Sample

## Documentation

* [Configuration](https://mojoauth.com/docs/sdks/asp.net/) - Everything you need to begin using the MojoAuth SDK.

In order to run the demo please configure the values in `appsettings.json`. 

```
  "MojoAuth_Key": "API_KEY",
  "MojoAuth_Secret": "API_SECRET",
  "MojoAuth_RedirectUri": "REDIRECT_URI"
```

> Whitelist your main domain in MojoAuth Dashbaord under Settings -> WebSite URL.

### Terms
- API_KEY: Your MojoAuth API Key
- API_SECRET: Your MojoAuth API Secret
- REDIRECT_URI: The URL where you wanted to redirect after successful authentication. For example: your whitelisted domain is `example.com` and Redirect URL is `https://example.com/profile`
