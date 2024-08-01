<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProductWebsiteUI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

         <div >
             <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" BackColor="Yellow"></asp:Label>
              <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green" BackColor="Yellow"></asp:Label>
 </div>
        <div>
            <div style="text-align:center;" >Search id : <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click" />
            </div>
            
        
        Product Code:
        <asp:TextBox ID="txt_product_code" runat="server" required="" ></asp:TextBox> <br /> <br />
         Product Name:
        <asp:TextBox ID="txt_product_name" runat="server" ></asp:TextBox> <br /> <br />
        Quantity:
        <asp:TextBox ID="txt_quantity" runat="server"></asp:TextBox> <br /> <br />
        Rate:
        <asp:TextBox ID="txt_Rate" runat="server" ></asp:TextBox> <br /> <br />
        TaxPercentage:
        <asp:TextBox ID="txt_TaxPercentage" runat="server"></asp:TextBox> <br /> <br />

        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" /> 
            
            <asp:Button ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
        <hr />
         </div>
          <asp:GridView ID="GridView1" runat="server"></asp:GridView>
  <asp:Button ID="Button1" runat="server" Text="Select" OnClick="Button1_Click" />
    </form>

  
</body>
</html>
