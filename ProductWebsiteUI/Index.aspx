<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProductWebsiteUI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <nav class="navbar bg-primary sticky-top" data-bs-theme="dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Home</a>
                <a class="navbar-brand" href="#list">ProductList</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Home</a>
                        </li>

                    </ul>

                </div>
            </div>
        </nav>
        <h1 style="text-align: center;">Shopping Product Tax Calculation</h1>

        <div class="container">

            <div class="row">
                <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" BackColor="Yellow"></asp:Label>
                <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green" BackColor="Yellow"></asp:Label>
            </div>

            <div class="col-6">
                <form id="form1" method="post" class="align-center">

                    <h2>Product Page</h2>
                    <div class="form-group">
                        <div style="text-align: center;">
                            <label>Search id</label>
                            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox><br />
                            <br />
                            <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click" class="form-control btn btn-info" />
                        </div>
                        <div class="form-group">
                            <label>Product Code</label>
                            <asp:TextBox ID="txt_product_code" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Product Name</label>
                            <asp:TextBox ID="txt_product_name" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Quantity</label>
                            <asp:TextBox ID="txt_quantity" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Rate</label>
                            <asp:TextBox ID="txt_Rate" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>TaxPercentage</label>
                            <asp:TextBox ID="txt_TaxPercentage" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <br />


                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" CssClass="btn btn-primary" />

                        <asp:Button ID="Button3" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="Button4_Click" />
                        <hr />
                    </div>
                </form>
            </div>
            <h3 id="list">ProductList</h3>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Select" OnClick="Button1_Click" CssClass="btn btn-primary" />
        </div>


    </form>
    <script src="	https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
