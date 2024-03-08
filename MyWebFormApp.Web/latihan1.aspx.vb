Imports MyWebFormApp.BLL.DTOs
Imports System.Web.ModelBinding

Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
    Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function lvCategories_GetData() As IEnumerable(Of MyWebFormApp.BLL.DTOs.CategoryDTO)
        Dim results = _categoryBLL.GetAll()
        Return results
    End Function

    Protected Sub lvCategories_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles lvCategories.ItemCommand
        If e.CommandName = "FilterByCategory" Then
            'Dim lnkSelect = CType(e.Item.FindControl("lnkSelect"), LinkButton)
            Dim categoryid As Integer = Convert.ToInt32(e.CommandArgument)
            FilterArticlesByCategory(categoryid)
        End If
    End Sub

    Public Function lvArticles_GetData() As IEnumerable(Of ArticleDTO)
        Dim results = _articleBLL.GetAll()
        Return results
    End Function

    Private Sub FilterArticlesByCategory(categoryId As Integer)
        lvArticles.DataSource = lvArticles_GetDataByCategory(categoryId)
        lvArticles.DataBind()
    End Sub

    Public Function lvArticles_GetDataByCategory(<Control("lvCategories")> categoryId As String) As IEnumerable(Of MyWebFormApp.BLL.DTOs.ArticleDTO)
        ' Assuming _articleBLL is an instance of your article business logic layer class
        Dim results = _articleBLL.GetArticleWithCategory(categoryId)
        Return results
    End Function



End Class