﻿using System.Text.Json;
using Microsoft.Azure.Functions.DotNetWorker.Converters;
using Microsoft.Azure.WebJobs.Script.Grpc.Messages;
using Xunit;

namespace Microsoft.Azure.Functions.DotNetWorkerTests
{
    public class JsonPocoConverterTests
    {
        private JsonPocoConverter _jsonPocoConverter;
        public JsonPocoConverterTests()
        {
            _jsonPocoConverter = new JsonPocoConverter();
        }

        [Fact]
        public void SourceIsNotStringTest()
        {
            object source = new RpcHttp();
            object target;
            System.Type targetType = typeof(Book);
            var result = _jsonPocoConverter.TryConvert(source, targetType, "name", out target);
            Assert.False(result);
        }

        [Fact]
        public void SourceIsNotValidJsonStringTest()
        {
            object source = "invalid string";
            object target;
            System.Type targetType = typeof(Book);
            var result = _jsonPocoConverter.TryConvert(source, targetType, "name", out target);
            Assert.False(result);
        }

        [Fact]
        public void SuccessfulConversionTest()
        {
            var book = new Book();
            book.name = "The Color Purple";
            book.id = "123";
            object source = JsonSerializer.Serialize(book);
            object target;
            System.Type targetType = typeof(Book);
            var result = _jsonPocoConverter.TryConvert(source, targetType, "name", out target);
            Assert.True(result);
        }
    }

    class Book
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}