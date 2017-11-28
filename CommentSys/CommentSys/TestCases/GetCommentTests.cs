using CommentSys.Requests;
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

        [Test]
        public void GetComment_PositiveFlow()
        {
            comments.PostComment("test comment");
            //TODO: Last request/response stored via framework.
            var response = comments.GetComment();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "");
        }

    }
}
