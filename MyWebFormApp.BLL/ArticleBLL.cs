using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;
using MyWebFormApp.DAL;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebFormApp.BLL
{
    public class ArticleBLL : IArticleBLL
    {
        private readonly IArticleDAL _articleDAL;

        public ArticleBLL()
        {
            _articleDAL = new ArticleDAL();
        }
        public void Delete(int id)
        {
            if (id<=0)
            {
                throw new ArgumentException("ArticleID is required");
            }
            try
            {
                _articleDAL.Delete(id);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            List<ArticleDTO> listArticleDTO = new List<ArticleDTO>();
            var articles = _articleDAL.GetAll();
            foreach (var article in articles)
            {
                listArticleDTO.Add(new ArticleDTO { 
                    ArticleID = article.ArticleID,
                    Title = article.Title,
                    Details = article.Details,
                    PublishDate = article.PublishDate,
                    Pic=article.Pic,
                    IsApproved=article.IsApproved,
                    Category = new CategoryDTO
                    {
                        CategoryID = article.Category.CategoryID,
                        CategoryName = article.Category.CategoryName
                    },
                    username = article.username
                   
                });
            }
            return listArticleDTO;
        }

        public IEnumerable<ArticleDTO> GetArticleWithCategory(int id)
        {
                List<ArticleDTO> listArticleDTO = new List<ArticleDTO>();
                var articles = _articleDAL.GetArticleWithCategory(id);
                foreach (var article in articles)
                {
                    listArticleDTO.Add(new ArticleDTO
                    {
                        ArticleID = article.ArticleID,
                        Title = article.Title,
                        Details = article.Details,
                        PublishDate = article.PublishDate,
                        Pic = article.Pic,
                        IsApproved = article.IsApproved,
                        Category = new CategoryDTO
                        {
                            CategoryID   = article.Category.CategoryID,
                            CategoryName= article.Category.CategoryName
                        }
                    });
                }
                return listArticleDTO;
        }

        public void Insert(ArticleCreateDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Title))
            {
                throw new ArgumentException("Title is required");
            }
            else if(entity.Title.Length > 50)
            {
                throw new ArgumentException("Title cant be more than 50 characters");
            }
            //try
            //{
                var newArticle = new Article {
                    Title=entity.Title,
                    Details=entity.Details,
                    Pic=entity.Pic,
                    CategoryID = (int)entity.CategoryID,
                };
                _articleDAL.Insert(newArticle);
            //}
            //catch(Exception ex)
            //{
            //    throw new ArgumentException(ex.Message);
            //}
        }


        public void Update(ArticleUpdateDTO entity)
        {
            if (entity.ArticleID <= 0)
            {
                throw new ArgumentException("Article id is required");
            }
            else if (string.IsNullOrEmpty(entity.Title))
            {
                throw new ArgumentException("Title is required");
            }
            else if(entity.Title.Length > 50)
            {
                throw new ArgumentException("Title cant be more than 5- characters");
            }
            try
            {
                var article = new Article
                {
                    ArticleID = entity.ArticleID,
                    Title = entity.Title,
                    Details = entity.Details,
                    PublishDate = entity.PublishDate,
                    Pic = entity.Pic,
                    IsApproved = entity.IsApproved,
                    CategoryID = entity.CategoryID
                };
                _articleDAL.Update(article);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        ArticleDTO IArticleBLL.GetById(int id)
        {
            ArticleDTO article = new ArticleDTO();
            var articleFromDAL = _articleDAL.GetById(id);

            if (articleFromDAL == null)
            {
                throw new ArgumentException($"Data article with id:{id} not found");
            }

            article.ArticleID = articleFromDAL.ArticleID;
            article.CategoryID = articleFromDAL.CategoryID;
            article.Title = articleFromDAL.Title;
            article.Details = articleFromDAL.Details;
            article.PublishDate = articleFromDAL.PublishDate;
            article.IsApproved = articleFromDAL.IsApproved;
            article.Pic = articleFromDAL.Pic;

            return article;
        }
    }
}
