using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebApiSample.XTest
{
    // WebApplicationFactory implements IDisposable and that will be called 
    // by xUnit once all of the tests in the collection have run. Additionally, 
    // on line 8 it is using a Startup class. That is the same Startup class 
    // used by the main program. So all of your service bindings and 
    // configuration will be part of your TestHost, pretty neat.


    [CollectionDefinition("Integration Tests")]
    public class TestCollection : ICollectionFixture<WebApplicationFactory<WebApiSample.Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
