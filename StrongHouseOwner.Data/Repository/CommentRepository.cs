using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class CommentRepository
    {
        StrongHouseDBEntities objEntity;
        public List<Comment> GetListCommentRP()
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.Comments.OrderByDescending(c => c.CommentId).Take(5).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public Comment SaveCommentRP(Comment objComment)
        {
            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.Comments.Add(objComment);
                objEntity.SaveChanges();

                return objComment;
            }
            catch (Exception)
            {

                return null;

            }

        }

        public Reply SaveReplyRP(Reply objReply)
        {

            objEntity = new StrongHouseDBEntities();
            objEntity.Replies.Add(objReply);
            objEntity.SaveChanges();

            return objReply;
        }

        public Comment DeleteCommentRP(int commentId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                Comment ct = objEntity.Comments.Find(commentId);

                objEntity.Comments.Remove(ct);
                objEntity.SaveChanges();

                return ct;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public Reply DeleteReplyRP(int replyId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                Reply ry = objEntity.Replies.Find(replyId);

                objEntity.Replies.Remove(ry);
                objEntity.SaveChanges();

                return ry;

            }
            catch (Exception)
            {

                return null;

            }

        }
    }

}