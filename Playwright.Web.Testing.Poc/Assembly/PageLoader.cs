using Microsoft.Playwright;
using Playwright.Web.Testing.Poc.PageObjects;
using System;

namespace Playwright.Web.Testing.Poc.Assembly;

public class PageLoader
{
    private readonly IPage _page;

    public PageLoader(IPage page)
    {
        _page = page;
    }

    public SignInPage SignInPage => GetPage<SignInPage>(_page);
    public LandingPage LandingPage => GetPage<LandingPage>(_page);


    private static P GetPage<P>(IPage page) where P : class 
    {
        return (P)Activator.CreateInstance(typeof(P), page)!
            ?? throw new InvalidOperationException("Page instance could be initialised");
    }
}
