using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class AboutController : Controller
    {
        CommentRepository commentRepository;
        Comment objEntity;

        // GET: About
        public ActionResult Index(string Reply)
        {
            System.Diagnostics.Debug.WriteLine(Reply);
            commentRepository = new CommentRepository();
            var objResults = commentRepository.GetListCommentRP();

            return View(objResults);
        }

        public ActionResult AddComment(string userId, string comment)
        {
            Comment objEntity = new Comment();
            commentRepository = new CommentRepository();
            var validation = 0;

            objEntity.UserRefId = Convert.ToInt32(userId);
            objEntity.Comment1 = comment;
            objEntity.CommentDateTime = DateTime.Now;

            var objResults = commentRepository.SaveCommentRP(objEntity);

            if(objResults != null)
            {
                validation = 0;
            }
            else
            {
                validation = 1;
            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddReply(string userId, string commentId, string reply)
        {

            Reply objEntity = new Reply();
            commentRepository = new CommentRepository();
            var validation = 0;

            objEntity.UserRefId = Convert.ToInt32(userId);
            objEntity.CommentRefId = Convert.ToInt32(commentId);
            objEntity.Reply1 = reply;
            objEntity.ReplyDateTime = DateTime.Now;

            var objResults = commentRepository.SaveReplyRP(objEntity);

            if (objResults != null)
            {
                validation = 0;
            }
            else
            {
                validation = 1;
            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeleteComment(string commentId)
        {
            Comment objEntity = new Comment();
            commentRepository = new CommentRepository();

            var objResults = commentRepository.DeleteCommentRP(Convert.ToInt32(commentId));

            return RedirectToAction("Index");
        }

        public ActionResult DeleteReply(string replyId)
        {
            Comment objEntity = new Comment();
            commentRepository = new CommentRepository();

            var objResults = commentRepository.DeleteReplyRP(Convert.ToInt32(replyId));

            return RedirectToAction("Index");
        }
    }
}