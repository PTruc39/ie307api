using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MangaApi.Models;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    public static DataTable Read_Table(string StoredProcedureName, Dictionary<string, object> dic_param = null)
    {
        string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        DataTable result = new DataTable("table1");
        using (SqlConnection conn = new SqlConnection(SQLconnectionString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (dic_param != null)
            {
                foreach (KeyValuePair<string, object> data in dic_param)
                {
                    if (data.Value == null)
                    {
                        cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                    }
                }
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(result);

            }
            catch (Exception ex)
            {

            }
        }
        return result;
    }
    public static DataTable GetCategory()
    {
        return Read_Table("GetCategory");
    }
    public static DataTable GetChapterByManga(int MangaID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("MangaID", MangaID);
        return Read_Table("GetChapterByManga", param);
    }
    public static DataTable GetListByChapter(int ChapterID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("ChapterID", ChapterID);
        return Read_Table("GetListByChapter", param);
    }
    public static DataTable GetFavoriteByUser(int userID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", userID);
        return Read_Table("GetFavoriteByUser", param);
    }
    public static DataTable GetMangaList()
    {
        return Read_Table("GetMangaList");
    }

    public static DataTable GetMangaByCategory(int categoryID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("categoryID", categoryID);
        return Read_Table("GetMangaByCategory", param);
    }

    public static DataTable GetUserByID(int userID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", userID);
        return Read_Table("GetUserByID", param);
    }

    public static DataTable GetNotifyByUser(int userID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", userID);
        return Read_Table("GetNotifyByUser ", param);
    }

    public static DataTable GetTop10Favorite()
    {
        return Read_Table("GetTop10Favorite");
    }

    public static DataTable GetCommentByManga(int? MangaID, int? BlogID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("mangaID", MangaID);
        param.Add("blogID", BlogID);
        return Read_Table("GetCommentByManga", param);
    }

    /*
     public static DataTable GetCommentByManga(int MangaID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("mangaID", MangaID);
        return Read_Table("GetCommentByManga", param);
    }
     */

    public static int CheckFavorite(int MangaID, int userID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("mangaID", MangaID);
        param.Add("userID", userID);
        int kq = int.Parse(Exec_Command("CheckFavorite", param).ToString());
        return kq;
    }

    public static DataTable FindManga(string name, string categoryID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("name", name);
        param.Add("categoryID", categoryID);
        return Read_Table("FindManga", param);
    }

    public static DataTable GetBlogList()
    {
        return Read_Table("GetBlogList");
    }

    public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
    {
        string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        object result = null;
        using (SqlConnection conn = new SqlConnection(SQLconnectionString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            // Start a local transaction.

            cmd.Connection = conn;
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (dic_param != null)
            {
                foreach (KeyValuePair<string, object> data in dic_param)
                {
                    if (data.Value == null)
                    {
                        cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                    }
                }
            }
            cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                result = cmd.Parameters["@CurrentID"].Value;
                // Attempt to commit the transaction.
            }
            catch (Exception ex)
            {

                result = null;
            }

        }
        return result;
    }

    public static int AddUser(userInfor user)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userName", user.userName);
        param.Add("email", user.email);
        param.Add("password", user.password);
        int kq = int.Parse(Exec_Command("AddUser", param).ToString());
        return kq;
    }
    public static int AddFavorite(favorite newfavorite)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", newfavorite.userID);
        param.Add("mangaID", newfavorite.mangaID);
        int kq = int.Parse(Exec_Command("AddFavorite", param).ToString());
        return kq;
    }
    public static int DeleteFavorite(favorite newfavorite)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", newfavorite.userID);
        param.Add("mangaID", newfavorite.mangaID);
        int kq = int.Parse(Exec_Command("DeleteFavorite", param).ToString());
        return kq;
    }

    public static int DeleteNotify(favorite newfavorite)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", newfavorite.userID);
        param.Add("mangaID", newfavorite.mangaID);
        int kq = int.Parse(Exec_Command("DeleteNotify", param).ToString());
        return kq;
    }

    public static int AddFollow(follow newfollow)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", newfollow.userID);
        param.Add("mangaID", newfollow.mangaID);
        int kq = int.Parse(Exec_Command("AddFollow", param).ToString());
        return kq;
    }
    public static int DeleteFollow(follow newfollow)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", newfollow.userID);
        param.Add("mangaID", newfollow.mangaID);
        int kq = int.Parse(Exec_Command("DeleteFollow", param).ToString());
        return kq;
    }

    public static int DeleteComment(comments comment)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("commentID", comment.commentID);
        int kq = int.Parse(Exec_Command("DeleteComment", param).ToString());
        return kq;
    }
    public static int AddComment(comments comment)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", comment.userID);
        param.Add("mangaID", comment.mangaID);
        param.Add("comment", comment.comment);
        param.Add("blogID", comment.blogID);
        int kq = int.Parse(Exec_Command("AddComment", param).ToString());
        return kq;
    }
    public static int AddBlog(blogs blog)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", blog.UserID);
        param.Add("BlogName", blog.BlogName);
        param.Add("BlogImg", blog.BlogImg);
        param.Add("BlogContent", blog.BlogContent);
        int kq = int.Parse(Exec_Command("AddBlog", param).ToString());
        return kq;
    }
    public static int Login(userInfor user)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("email", user.email);
        param.Add("password", user.password);
        int kq = int.Parse(Exec_Command("Login", param).ToString());
        return kq;
    }
    /*public static int UpdateUser(userInfor user)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userName", user.userName);
        param.Add("", user.password);
        int kq = int.Parse(Exec_Command("AddUser", param).ToString());
        return kq;
    }*/
    public static int EditUser(userInfor user)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", user.userID);
        param.Add("userName", user.userName);
        param.Add("email", user.email);
        param.Add("password", user.password);
        int kq = int.Parse(Exec_Command("EditUser", param).ToString());
        return kq;
    }

    public static DataTable GetCategoryByMangaID(int MangaID)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("MangaID", MangaID);
        return Read_Table("GetCategoryByMangaID", param);
    }

    public static int ResetPassword(int userID, string newPassword, string currentPassword)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("userID", userID);
        param.Add("password", newPassword);
        param.Add("currentPassword", currentPassword);
        int kq = int.Parse(Exec_Command("ResetPassword", param).ToString());
        return kq;
    }
}
