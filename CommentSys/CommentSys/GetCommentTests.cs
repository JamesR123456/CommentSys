using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentSys
{
    [TestFixture(Description ="Tests for the GET v1/comments/")]
    public class GetCommentTests
    {

        //TODO: Autofac for context injection.
        private Requests.CommentSystemRequests comments;

        [SetUp]
        public void Setup()
        {
            comments = new Requests.CommentSystemRequests();    
        }

        [Test]
        public void GetComment_PositiveFlow()
        {
            comments.PostComment("test comment");
            comments.GetComment();
        }

    }
}
