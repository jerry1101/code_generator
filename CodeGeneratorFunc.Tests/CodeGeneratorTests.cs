using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using System.Collections.Generic;

namespace CodeGeneratorFunc.Tests
{
    public class FunctionsTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void Http_trigger_should_return_known_string()
        {
            var request = TestFactory.CreateHttpRequest("name", "Bill");
            var response = (ActionResult<List<ClassCode>>)await CodeGenerator.Run(request, logger);
            Assert.Equal("Hello, Bill", response.Value.ToString());
        }

        [Theory]
        [MemberData(nameof(TestFactory.Data), MemberType = typeof(TestFactory))]
        public async void Http_trigger_should_return_known_string_from_member_data(string queryStringKey, string queryStringValue)
        {
            var request = TestFactory.CreateHttpRequest(queryStringKey, queryStringValue);
            var response = (ActionResult<List<ClassCode>>)await CodeGenerator.Run(request, logger);
            Assert.Equal($"Hello, ", response.Value.ToString());
        }

        
    }
}
