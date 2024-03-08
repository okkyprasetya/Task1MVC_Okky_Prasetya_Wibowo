using MyWebFormApp.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IArticleDAL : ICrud<Article>
    {
        IEnumerable<Article> GetArticleWithCategory(int id);
    }
}
