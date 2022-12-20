using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MangaApi.Models;

namespace MangaApi.Controllers
{
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


        [Route("api/HelloWebApi")]
        [HttpGet]
        public IHttpActionResult HelloWebApi()
        {
            return Ok("Welcome to WebApi!");
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
    }
}