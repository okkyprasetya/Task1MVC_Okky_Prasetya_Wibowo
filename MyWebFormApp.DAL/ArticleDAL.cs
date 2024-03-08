using Dapper;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyWebFormApp.DAL
{
    public class ArticleDAL : IArticleDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"delete from Articles where ArticleID = @ArticleID";
                var param = new { ArticleID = id };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil dihapus");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public IEnumerable<Article> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select a.ArticleID, a.CategoryID, a.Title, a.Details, a.PublishDate, a.IsApproved, a.Pic, c.CategoryID, c.CategoryName, a.username from Articles a inner join Categories c on a.CategoryID = c.CategoryID";


                //var results = conn.Query<Article>(strSql, commandType: System.Data.CommandType.Text);
                List<Article> articles = new List<Article>();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var article = new Article()
                        {
                            ArticleID = Convert.ToInt32(dr["ArticleID"]),
                            CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            Title = dr["Title"].ToString(),
                            Details = dr["Details"].ToString(),
                            PublishDate = Convert.ToDateTime(dr["PublishDate"]),
                            IsApproved = Convert.ToBoolean(dr["IsApproved"]),
                            Pic = dr["Pic"].ToString(),
                            Category = new Category()
                            {
                                CategoryID = Convert.ToInt32(dr["CategoryID"]),
                                CategoryName = dr["CategoryName"].ToString()
                            },
                            username = dr["username"].ToString()
                        };
                        articles.Add(article);
                    }
                }
                return articles;
            }
        }

        public IEnumerable<Article> GetArticleWithCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {

                var strSql = @"SELECT A.ArticleID,A.Title,A.Details,A.PublishDate, A.Pic,A.IsApproved, B.CategoryID, B.CategoryName FROM dbo.Articles as A join dbo.Categories as B on a.CategoryID = b.CategoryID WHERE A.CategoryID = @id_kat";
                var param = new { id_kat = id };
                var results = conn.Query<Article, Category, Article>(strSql, (article, category) =>
                {
                    article.Category = category;
                    return article;
                }, param, splitOn: "CategoryID");
                return results;
            }

        }

        public Article GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Articles where ArticleID = @beritaID";
                var param = new { beritaID = id };
                var result = conn.QuerySingleOrDefault<Article>(strSql, param);
                return result;
            }
        }

        public void Insert(Article entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"INSERT INTO Articles (CategoryID, Title, Details,Pic) VALUES (@idKat,@judulBerita,@detailBerita,@pic)";
                var param = new { 
                    idKat = entity.CategoryID,
                    judulBerita = entity.Title,
                    detailBerita = entity.Details,
                    pic = entity.Pic,
                };
                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.Text);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Update(Article entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"update Articles set Title=@Title, Details=@Details, IsApproved=@IsApproved, Pic=@Pic 
                               where ArticleID=@ArticleID";
                var param = new
                {
                    CategoryID = entity.CategoryID,
                    Title = entity.Title,
                    Details = entity.Details,
                    IsApproved = entity.IsApproved,
                    Pic = entity.Pic,
                    ArticleID = entity.ArticleID
                };

                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil diupdate");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }
    }
}
