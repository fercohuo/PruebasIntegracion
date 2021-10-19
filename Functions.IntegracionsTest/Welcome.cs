using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functions.IntegracionsTest
{
    public class Welcomo
    {
        private TestFixture testFixture;
        private HttpResponseMessage httpResponseMessage;

        public Welcomo(TestFixture fixture)
        {
            testFixture = fixture;
        }
        [Fact]
        public async Task WhenfunctionIsInvoked()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=FernandoCohuo");
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }

        [Fact]
        public async Task WhenResponseWnWith()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=FernandoCohuo");
            Assert.EndsWith("Success.", await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
