<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="latihan1.aspx.vb" Inherits="MyWebFormApp.Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Articles</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Article Page</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" /><br />
                    <div class="row d-none">
                        <asp:ListView ID="lvCategories" ItemType="MyWebFormApp.BLL.DTOs.CategoryDTO"
                            SelectMethod="lvCategories_GetData" DataKeyNames="id_kat" OnItemCommand="lvCategories_ItemCommand" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("nama_kat") %>' CommandName="FilterByCategory"
                                        CommandArgument='<%# Eval("id_kat") %>'
                                        runat="server" CssClass="btn btn-outline-info btn-sm" />
                                </div>
                            </ItemTemplate>
                            <SelectedItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("nama_kat") %>' CommandName="FilterByCategory"
                                        runat="server" CssClass="btn btn-info btn-sm" />
                                </div>
                            </SelectedItemTemplate>
                        </asp:ListView>
                    </div>
                    <hr />
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Title</th>
                                <th>Details</th>
                                <th>PublishDate</th>
                                <th>IsApproved</th>
                                <th>Picture</th>
                                <th>&nbsp;</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvArticles" ItemType="MyWebFormApp.BLL.DTOs.ArticleDTO"
                                SelectMethod="lvArticles_GetData" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Item.Id_berita  %></td>
                                        <td><%# Item.judul_berita %></td>
                                        <td><%# Item.detail_berita  %></td>
                                        <td><%# Item.tanggal  %></td>
                                        <td><%# Item.IsApprove  %></td>
                                        <td><%# Item.Pic  %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                    <%-- <table class="table table-hover">
                        <asp:ListView ID="ListView1" ItemType="MyWebFormApp.BLL.DTOs.ArticleDTO"
                            SelectMethod="lvArticles_GetData" runat="server">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Category</th>
                                        <th>Title</th>
                                        <th>Details</th>
                                        <th>Created</th>
                                        <th>Approval</th>
                                        <th>Approval</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("id_kat") %></td>
                                    <td><%# Eval("Category.nama_kat") %></td>
                                    <td><%# Eval("judul_berita") %></td>
                                    <td><%# Eval("detail_berita") %></td>
                                    <td><%# Eval("tanggal", "{0:d}") %></td>
                                    <td><%# Eval("IsApprove") %></td>
                                    <td>
                                        <%# Eval("pic") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                <tr>
                                    <td colspan="7">No records found</td>
                                </tr>
                            </EmptyItemTemplate>
                        </asp:ListView>

                    </table>--%>
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addArticleModal">
                        Add New Article
                    </button>
                    <div class="modal fade" id="addArticleModal" tabindex="-1" role="dialog" aria-labelledby="addArticleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="addArticleModalLabel">Add New Article</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <!-- Add form fields for new article here -->
                                    <!-- Example: -->

                                    <div class="form-group">
                                        <label for="txtTitle">Title</label>
                                        <input type="text" class="form-control" id="txtTitle" placeholder="Enter title">
                                    </div>
                                    <!-- Add more fields as needed -->
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <button type="button" class="btn btn-primary" onclick="saveArticle()">Save</button>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

            </div>

        </div>

    </div>
</asp:Content>
