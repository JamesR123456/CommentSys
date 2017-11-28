using CommentSys.Requests;
using Models;
using Newtonsoft.Json;
using NJsonSchema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.CommentSys
{
    [TestFixture(Description ="Tests for the GET v1/comments/")]
    public class GetCommentTests
    {
        //TODO: Autofac for context injection.
        private CommentSystemRequests comments;

        [SetUp]
        public void Setup()
        {
            comments = new CommentSystemRequests();    
        }

        [TestCase("test comment",Description ="Add comment and then reteive same comment.")]
        public void GetComment_PositiveFlow(string comment)
        {
            var postResult = comments.PostComment(comment);
            Assert.AreEqual(HttpStatusCode.OK, postResult.StatusCode, "");
            validateResponse<CommentResponse>(JsonConvert.SerializeObject(postResult.Data));
            
            //TODO: Last request/response stored via framework.
            var response = comments.GetComment(postResult.Data.id.commentId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "");
            //TODO:Remove serialization of object, double conversion is inefficient.
            validateResponse<CommentResponse>(JsonConvert.SerializeObject(response.Data));
            Assert.AreEqual(postResult.Data.id.commentId, response.Data.id.commentId, "Comment id retreived is not comment expected.");
        }

        [Test]
        public void PostComment_Positive()
        {

        }

        /// <summary>
        /// TODO: Refactor out in generic assertion class for common assertions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        private async void validateResponse<T>(string json)
        {
            var schema = await JsonSchema4.FromTypeAsync<T>();
            var errorList = schema.Validate(json);
            //TODO: Better formatting for errors to make more readable.
            Assert.IsTrue(errorList.Count == 0, $"Schema validation errors" +
                $"generated {errorList.ToString()}");

        }
    }
}
