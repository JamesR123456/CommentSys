using CommentSys.Requests;
using Models;
using Newtonsoft.Json;
using NJsonSchema;
using NUnit.Framework;
using System.Net;

namespace TestCases.CommentSys
{
    [TestFixture(Description ="Tests for the GET v1/comments/")]
    public class GetCommentTests
    {
        //TODO: Autofac for context injection.
        private CommentSystemRequests comments;

        /// <summary>
        /// Generates instance of REST client for the service
        /// </summary>
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected response code.");
            //TODO:Remove serialization of object, double conversion is inefficient.
            validateResponse<CommentResponse>(JsonConvert.SerializeObject(response.Data));
            Assert.AreEqual(postResult.Data.id.commentId, response.Data.id.commentId, "Comment id retreived is not comment expected.");
        }

        [Test(Description = "Negative flow for record not found.")]
        public void GetComment_NotFound()
        {
            //TODO: check that this id is not possbile.
            var response = comments.GetComment("NotExistant");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Unexpected response code.");
            //TODO: Find out expect code value, message etc.
        }

        [Test(Description ="Generates a bad request for GET Comments")]
        public void GetComment_BadRequest()
        {
            var response = comments.GetComment("%");//TODO: Find better way to trigger bad request.
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected response code.");
        }
        
        [Test(Description ="Geneates an internal server response from GET comments.")]
        public void GetComment_InternalServerError()
        {
            Assert.Inconclusive("Not Implemented");
            //TODO: How to generate an internal server error?
        }

        [Test(Description = "Exception flow test for unauthencated request.")]
        public void GetComment_Unauthenticated()
        {
            CommentSystemRequests.bearerToken = null;
            var response = comments.GetComment();
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode, "Unexpected response code.");
            //TODO: Find out expect code value, message etc.
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
