<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CategoryObjectDSPage.aspx.vb" Inherits="MyWebFormApp.Web.CategoryObjectDSPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Contoh Object Datasource</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Contoh Object Datasource</h6>
            </div>

            <div class="row">
                <div class="col">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
                </div>
                <div class="col">
                    <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-success btn-sm" />
                </div>
            </div>
            <hr />
            <div class="card-body">
                <%-- <asp:ObjectDataSource ID="odsCategories" TypeName="MyWebFormApp.BLL.CategoryBLL"
                   SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" runat="server">
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>--%>
                 <div class="row">
                    <asp:Literal ID="ltMessage" runat="server" />
                </div>
                <asp:GridView ID="gvCategories" CssClass="table table-hover" ItemType="MyWebFormApp.BLL.DTOs.CategoryDTO"
                    SelectMethod="GetAll" UpdateMethod="Update" DeleteMethod="Delete"
                    DataKeyNames="id_kat,nama_kat" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="CategoryName">
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Item.nama_kat %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# BindItem.nama_kat %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-outline-success btn-sm" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-default btn-sm" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-warning btn-sm" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-danger btn-sm" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('Apakah anda yakin untuk delete data ?')" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnPrev" Text="Prev" CssClass="btn btn-primary" runat="server" OnClick="btnPrev_Click" />
                <asp:Button ID="btnNext" Text="Next" CssClass="btn btn-primary" runat="server" OnClick="btnNext_Click" />
                <asp:Literal ID="ltPosition" runat="server" />
                <asp:Label ID="lblKeterangan" runat="server" /><br />
                <div class="col-lg-6">
                    <div class="mb-3 mt-3">
                        <label for="txtCategoryNameInput" class="form-label">Cetegory Name :</label>
                        <asp:TextBox ID="txtCategoryNameInput" CssClass="form-control" runat="server" />
                    </div>
                    <asp:Button Text="Add" ID="btnAdd" class="btn btn-primary btn-sm" OnClick="btnAdd_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
