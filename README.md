<p align="center">
  <a href="https://www.mojoauth.com">
    <img alt="MojoAuth" src="https://mojoauth.com/blog/assets/images/logo.svg" width="200" />
  </a>
</p>

<h1 align="center">
  MojoAuth DotNet SDK
</h1>


## Documentation

* [Configuration](https://mojoauth.com/docs/) - Everything you need to begin using the MojoAuth SDK.

## Installation

Run the following command in the NuGet Package Manager Console:

`PM> Install-Package MojoAuth.NET`

## Usage

Take a peek:

Before making any API calls, the MojoAuth API client must be initialized with your MojoAuth API Key and Secret.

Sample code:

```
using MojoAuth.NET;

var mojoAuthHttpClient = new MojoAuthHttpClient("____key____", "____secret____");

var resp = await mojoAuthHttpClient.SendMagicLink("email.address@example.com");

Console.WriteLine(resp.Result.StateId);
```
## How to contribute

We appreciate all kinds of contributions from anyone.

Please check the [contributing guide](CONTRIBUTING.md) to become a contributor.

## License

For more information on licensing, please refer to [License](LICENSE)
