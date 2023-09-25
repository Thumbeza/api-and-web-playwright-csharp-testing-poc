using FluentAssertions;
using NUnit.Framework;
using Plawright.Api.Testing.Poc.Models;
using Plawright.Api.Testing.Poc.TestData;
using Plawright.Api.Testing.Poc.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plawright.Api.Testing.Poc.Tests;

public class JokesFixture 
{
    private ApiRequestContext _apiRequestContext;

    [SetUp]
    public async Task SetUp()
    {
        _apiRequestContext = new ApiRequestContext(ApiSettings.BaseUrl);

        await _apiRequestContext.CreateAsync();
    }

    [Test]
    public async Task ShouldGenerateRandomJoke()
    {
        var generatedJoke = await _apiRequestContext.Request.GetAsync("random_joke");

        generatedJoke.Ok.Should().BeTrue();
    }

    [Test]
    public async Task PunchlineShouldNotBeNull()
    {
        var generatedJoke = await _apiRequestContext.Request.GetAsync("random_joke");

        var joke = JsonConverter.Deserialize<Joke>(await generatedJoke.TextAsync());

        joke.Punchline.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task ShouldGenerateTenJokes()
    {
        var generatedJoke = await _apiRequestContext.Request.GetAsync("random_ten");

        var ListOfJokes = JsonConverter.Deserialize<List<Joke>>(await generatedJoke.TextAsync());

        ListOfJokes.Count.Should().Be(10);
    }

    [TearDown]
    public async Task TearDown()
    {
        await _apiRequestContext.Request.DisposeAsync();
    }
}
