using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebFormApp.BLL.Interfaces
{
    public interface IArticleBLL
    {
        void Delete(int id);
        IEnumerable<ArticleDTO> GetAll();
        ArticleDTO GetById(int id);
        IEnumerable<ArticleDTO> GetArticleWithCategory(int id);
        void Insert(ArticleCreateDTO entity);
        void Update(ArticleUpdateDTO entity);
    }
}
