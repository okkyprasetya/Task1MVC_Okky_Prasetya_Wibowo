Imports System.Web.ModelBinding
Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class CategoryObjectDSPage
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL()
    Public Function GetAll(<Control("txtSearch")> categoryName As String) As List(Of CategoryDTO)
        Return _categoryBLL.GetByName(categoryName)
    End Function

    Public Sub Update(id_kat As Integer, name_kat As String)
        Try
            Dim row As GridViewRow = gvCategories.Rows(gvCategories.EditIndex)
            Dim txtCategoryName As TextBox = CType(row.FindControl("txtCategoryName"), TextBox)
            'updateCategory.CategoryName =

            If txtCategoryName IsNot Nothing Then
                name_kat = txtCategoryName.Text
                Dim _categoryUpdateDTO As New CategoryUpdateDTO
                _categoryUpdateDTO.id_kat = id_kat
                _categoryUpdateDTO.nama_kat = name_kat
                _categoryBLL.Update(_categoryUpdateDTO)
                lblKeterangan.Text = "Data berhasil diupdate " & name_kat.ToString()
            Else
                lblKeterangan.Text = "Not found"
            End If

            gvCategories.DataBind()
        Catch ex As Exception
            lblKeterangan.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub Delete(id_kat As Integer)
        Try
            _categoryBLL.Delete(id_kat)
            lblKeterangan.Text = "Data berhasil dihapus " & id_kat.ToString()
            gvCategories.DataBind()
        Catch ex As Exception
            lblKeterangan.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim categoryInsert = New CategoryCreateDTO
        categoryInsert.nama_kat = txtCategoryNameInput.Text
        _categoryBLL.Insert(categoryInsert)

        gvCategories.DataBind()
    End Sub

#Region "Initiate"
    Sub InitiateButtonNavigation()
        Dim maxPage = 0
        Dim pagediv = CInt(ViewState("RecordCount")) Mod CInt(ViewState("PageSize"))

        If CInt(ViewState("RecordCount")) = 0 Then
            maxPage = 1
        ElseIf pagediv = 0 Then
            maxPage = CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize"))
        Else
            maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        End If

        If maxPage = 1 Then
            btnPrev.Enabled = False
            btnNext.Enabled = False
        ElseIf CInt(ViewState("PageNumber")) = 1 Then
            btnPrev.Enabled = False
            btnNext.Enabled = True
        ElseIf CInt(ViewState("PageNumber")) = maxPage Then
            btnPrev.Enabled = True
            btnNext.Enabled = False
        Else
            btnPrev.Enabled = True
            btnNext.Enabled = True
        End If

        ViewState("RecordCount") = _categoryBLL.GetCountCategories(txtSearch.Text)
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
    End Sub
#End Region

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        Dim maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        If CInt(ViewState("PageNumber")) < maxPage Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) + 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the first page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        ViewState("PageNumber") = 1
        InitiateButtonNavigation()
    End Sub
End Class