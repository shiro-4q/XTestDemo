using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

var server = WireMockServer.Start();
server.Given(Request.Create().WithPath("/test").WithParam("search","1"))
    .RespondWith(Response.Create().WithStatusCode(200).WithBody("Hello World 1!"));
server.Given(Request.Create().WithPath("/test").WithParam("search", "2"))
    .RespondWith(Response.Create().WithStatusCode(200).WithBody("Hello World 2!"));
server.Given(Request.Create().WithPath("/test").WithParam("search", "-1"))
    .RespondWith(Response.Create().WithStatusCode(400).WithBody("negative is not allowed!"));

Console.WriteLine(server.Url);
Console.ReadLine();
