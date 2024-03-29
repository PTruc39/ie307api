﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MangaApi.Models;

namespace MangaApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class XulyController : ApiController
    {
        [Route("api/category/GetCategory")]
        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            try
            {
                DataTable tb = Database.GetCategory();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/chapter/GetChapterByManga")]
        [HttpGet]
        public IHttpActionResult GetChapterByManga(int MangaID)
        {
            try
            {
                DataTable tb = Database.GetChapterByManga(MangaID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/chapter/GetListByChapter")]
        [HttpGet]
        public IHttpActionResult GetListByChapter(int ChapterID)
        {
            try
            {
                DataTable tb = Database.GetListByChapter(ChapterID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/favorite/GetFavoriteByUser")]
        [HttpGet]
        public IHttpActionResult GetFavoriteByUser(int userID)
        {
            try
            {
                DataTable tb = Database.GetFavoriteByUser(userID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/follow/GetFollowByUser")]
        [HttpGet]
        public IHttpActionResult GetFollowByUser(int userID)
        {
            try
            {
                DataTable tb = Database.GetFollowByUser(userID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
        
        [Route("api/user/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(userInfor user)
        {
            try
            {
                int kq = Database.AddUser(user);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/user/Login")]
        [HttpPost]
        public IHttpActionResult Login(userInfor user)
        {
            try
            {
                int kq = Database.Login(user);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/user/AddFavorite")]
        [HttpPost]
        public IHttpActionResult AddFavorite(favorite newf)
        {
            try
            {
                int kq = Database.AddFavorite(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/follow/AddFollow")]
        [HttpPost]
        public IHttpActionResult AddFollow(follow newf)
        {
            try
            {
                int kq = Database.AddFollow(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/user/AddComment")]
        [HttpPost]
        public IHttpActionResult AddComment(comments cmt)
        {
            try
            {
                int kq = Database.AddComment(cmt);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/user/DeleteFavorite")]
        [HttpPost]
        public IHttpActionResult DeleteFavorite(favorite newf)
        {
            try
            {
                int kq = Database.DeleteFavorite(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/follow/DeleteFollow")]
        [HttpPost]
        public IHttpActionResult DeleteFollow(follow newf)
        {
            try
            {
                int kq = Database.DeleteFollow(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/user/DeleteNotify")]
        [HttpPost]
        public IHttpActionResult DeleteNotify(favorite newf)
        {
            try
            {
                int kq = Database.DeleteNotify(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/comment/DeleteComment")]
        [HttpPost]
        public IHttpActionResult DeleteComment(comments newf)
        {
            try
            {
                int kq = Database.DeleteComment(newf);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/manga/GetMangaList")]
        [HttpGet]
        public IHttpActionResult GetMangaList()
        {
            try
            {
                DataTable tb = Database.GetMangaList();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/manga/GetMangaByCategory")]
        [HttpGet]
        public IHttpActionResult GetMangaByCategory(int categoryID)
        {
            try
            {
                DataTable tb = Database.GetMangaByCategory(categoryID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/user/GetNotifyByUser")]
        [HttpGet]
        public IHttpActionResult GetNotifyByUser(int userID)
        {
            try
            {
                DataTable tb = Database.GetNotifyByUser(userID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/comment/GetCommentByManga")]
        [HttpGet]
        public IHttpActionResult GetCommentByManga(int? MangaID = null, int? BlogID = null)
        {
            try
            {
                DataTable tb = Database.GetCommentByManga(MangaID, BlogID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        /*
         [Route("api/comment/GetCommentByManga")]
        [HttpGet]
        public IHttpActionResult GetCommentByManga(int MangaID)
        {
            try
            {
                DataTable tb = Database.GetCommentByManga(MangaID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
         
         */


        [Route("api/userInfor/GetUserByID")]
        [HttpGet]
        public IHttpActionResult GetUserByID(int userID)
        {
            try
            {
                DataTable tb = Database.GetUserByID(userID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/checkfavorite")]
        [HttpGet]
        public IHttpActionResult CheckFavorite(int MangaID, int userID)
        {
            try
            {
                int tb = Database.CheckFavorite(MangaID, userID);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/favorite/GetTop10Favorite")]
        [HttpGet]
        public IHttpActionResult GetTop10Favorite()
        {
            try
            {
                DataTable tb = Database.GetTop10Favorite();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/manga/findmanga")]
        [HttpGet]
        public IHttpActionResult FindManga(string name = "", string categoryID = "")
        {
            try
            {
                DataTable tb = Database.FindManga(name, categoryID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("api/HelloWebApi")]
        [HttpGet]
        public IHttpActionResult HelloWebApi()
        {
            return Ok("Welcome to WebApi!");
        }

        [Route("api/blog/GetBlogList")]
        [HttpGet]
        public IHttpActionResult GetBlogList()
        {
            try
            {
                DataTable tb = Database.GetBlogList();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/blog/AddBlog")]
        [HttpPost]
        public IHttpActionResult AddBlog(blogs blog)
        {
            try
            {
                int kq = Database.AddBlog(blog);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/manga/AddChapter")]
        [HttpPost]
        public IHttpActionResult AddChapter(chapter chap)
        {
            try
            {
                int kq = Database.AddChapter(chap);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        /*[Route("api/UpdateUser")]
        [HttpPut]
        public IHttpActionResult UpdateUser()
        {
            try
            {
                DataTable tb = Database.UpdateUser();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }*/
        [Route("api/user/EditUser")]
        [HttpPost]
        public IHttpActionResult EditUser(userInfor user)
        {
            try
            {
                int kq = Database.EditUser(user);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/category/GetCategoryByMangaID")]
        [HttpGet]
        public IHttpActionResult GetCategoryByMangaID(int MangaID)
        {
            try
            {
                DataTable tb = Database.GetCategoryByMangaID(MangaID);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/user/ResetPassword")]
        [HttpPost]
        public IHttpActionResult ResetPassword(int userID, string newPassword, string currentPassword)
        {
            try
            {
                int kq = Database.ResetPassword(userID, newPassword, currentPassword);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


        /*MANGA API HERE*/
        [Route("api/manga/EditManga")]
        [HttpPost]
        public IHttpActionResult EditManga(manga mg)
        {
            try
            {
                int kq = Database.EditManga(mg);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/manga/AddManga")]
        [HttpPost]
        public IHttpActionResult AddManga(manga mg)
        {
            try
            {
                int kq = Database.AddManga(mg);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        // API THÊM XÓA SỬA list
        [Route("api/list/AddList")]
        [HttpPost]
        public IHttpActionResult AddList(list lst)
        {
            try
            {
                int kq = Database.AddList(lst);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/list/EditList")]
        [HttpPost]
        public IHttpActionResult EditList(list lst)
        {
            try
            {
                int kq = Database.EditList(lst);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/list/DeleteList")]
        [HttpPost]
        public IHttpActionResult DeleteList(int listID)
        {
            try
            {
                int kq = Database.DeleteList(listID);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        // API SỬA chapter
        [Route("api/chapter/EditChapter")]
        [HttpPost]
        public IHttpActionResult EditChapter(chapter chapter)
        {
            try
            {
                int kq = Database.EditChapter(chapter);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}