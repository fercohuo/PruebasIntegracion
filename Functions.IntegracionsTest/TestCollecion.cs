using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functions.IntegracionsTest
{
    [[CollectionDefinition(nameof(TestCollecion))]
    public class TestCollecion : ICollectionFixture<TestCollecion>
    {


    }
}
