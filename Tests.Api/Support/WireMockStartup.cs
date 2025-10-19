using System;
using NUnit.Framework;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

[SetUpFixture]
public class ApiTestServer
{
    private static WireMockServer? _server;

    [OneTimeSetUp]
    public void Start()
    {
        _server = WireMockServer.Start(9091);

        _server.Given(Request.Create().WithPath("/status").UsingGet())
               .RespondWith(Response.Create()
                   .WithStatusCode(200)
                   .WithHeader("Content-Type", "application/json")
                   .WithBody("{\"ok\":true}"));

        Console.WriteLine("[ApiTestServer] WireMock running on http://localhost:9091");
    }

    [OneTimeTearDown]
    public void Stop()
    {
        try { _server?.Stop(); } catch { /* no-op */ }
        _server?.Dispose();
        _server = null;
        Console.WriteLine("[ApiTestServer] WireMock stopped and disposed");
    }
}
