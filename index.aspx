<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplicationcrud.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <asp:HiddenField ID="hfProductID" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label Text="Product" runat="server" />
            </td>
            <td colspan="2">
                 <asp:TextBox ID="txtProduct" runat="server" />

            </td>

         </tr>
         <tr>
             <td>
                <asp:Label Text="Price" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtPrice" runat="server" />

            </td>
         </tr>
         <tr>
             <td>
                <asp:Label Text="Count" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtCount" runat="server" />

            </td>
         </tr>
         <tr>
             <td>
                <asp:Label Text="Description" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDescription" runat="server" />

            </td>
         </tr>
       <tr>
          <td> </td>
          <td colspan="2">
            <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="btnSave_Click" />
               <asp:Button Text="Delete" ID="btnDeleted" runat="server"  OnClick="btnDelete_Click" />
              <asp:Button Text="Clear" ID="btnClear" runat="server" OnClick="btnClear_Click" />

          </td>
       </tr>
        <tr>
            <td> </td>
                <td colspan="2">
                    <asp:Label Text="" ID="iblSucessMessage" runat="server" ForeColor="Green" />
                </td>
           
        </tr>

         <tr>
            <td> </td>
                <td colspan="2">
                    <asp:Label Text="" ID="IblErrorMessage" runat="server" ForeColor="Red" />
                </td>
           
        </tr>
    </table>
        <br/ . />
        <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Product" HeaderText="Product" />
                 <asp:BoundField DataField="Price" HeaderText="Price" />
                 <asp:BoundField DataField="Count" HeaderText="Product" />
                <asp:TemplateField>
                    <ItemTemplate>
                        
                        <asp:LinkButton Text="Select" ID="LinkButton1" CommandArgument='<%# Eval("ProductID") %>' runat="server" Onclick="InkSelect_OnClick" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    </form>
</body>
</html>

