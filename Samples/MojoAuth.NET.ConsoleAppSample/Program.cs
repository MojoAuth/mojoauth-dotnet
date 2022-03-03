using MojoAuth.NET;

var mojoAuthHttpClient = new MojoAuthHttpClient("____key____", "____secret____");

var resp = await mojoAuthHttpClient.SendMagicLink("email.address@example.com");

Console.WriteLine(resp.Result.StateId);