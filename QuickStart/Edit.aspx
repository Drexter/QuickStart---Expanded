<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="QuickStart.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog Example - Edit</title>
</head>
<body>
    <h1>Blog Example</h1>
    <form id="form1" runat="server">
    <div>
        <p>Title <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox></p>
        <p>Text <asp:TextBox ID="txtText" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox></p>
        <p><asp:Button runat="server" ID="btnUpdate" onclick="btnUpdate_Click" Text="Update" /></p>
    </div>
    </form>
</body>
</html>
