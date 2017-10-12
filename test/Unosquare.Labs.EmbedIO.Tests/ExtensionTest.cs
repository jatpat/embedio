﻿using NUnit.Framework;
using Unosquare.Labs.EmbedIO.Constants;

namespace Unosquare.Labs.EmbedIO.Tests
{
    [TestFixture]
    public class ExtensionTest
    {
        [TestCase(CompressionMethod.Gzip)]
        [TestCase(CompressionMethod.Deflate)]
        [TestCase(CompressionMethod.None)]
        public void CompressGzipTest(CompressionMethod method)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes("THIS IS DATA");

            var compressBuffer = buffer.Compress(method);

            Assert.IsNotNull(compressBuffer);

            var uncompressBuffer = compressBuffer.Compress(method, System.IO.Compression.CompressionMode.Decompress);

            Assert.IsNotNull(uncompressBuffer);
            Assert.AreEqual(uncompressBuffer, buffer);
        }

        [TestCase("/data/1", new[] { "1" })]
        [TestCase("/data/1/2", new[] { "1", "2" })]
        public void RequestWildcardUrlParamsWithLastParams(string urlMatch, string[] expected)
        {
            var result = Extensions.RequestWildcardUrlParams(urlMatch, "/data/*");
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected[0], result[0]);
        }

        [TestCase("/1/data", new[] { "1" })]
        [TestCase("/1/2/data", new[] { "1", "2" })]
        public void RequestWildcardUrlParamsWithInitialParams(string urlMatch, string[] expected)
        {
            var result = Extensions.RequestWildcardUrlParams(urlMatch, "/*/data");
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected[0], result[0]);
        }


        [TestCase("/api/1/data", new[] { "1" })]
        [TestCase("/api/1/2/data", new[] { "1", "2" })]
        public void RequestWildcardUrlParamsWithMiddleParams(string urlMatch, string[] expected)
        {
            var result = Extensions.RequestWildcardUrlParams(urlMatch, "/api/*/data");
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected[0], result[0]);
        }
    }
}