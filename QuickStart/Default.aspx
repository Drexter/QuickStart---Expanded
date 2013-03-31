<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuickStart.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DB Schema tool</title>
</head>
<body>
    <form id="form1" runat="server">
    <p><asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label></p>
    <h1>Before you begin:</h1>
    <ol>
        <li>First create the tables by clicking the 'Create Tables' button</li>
        <li>Click on 'Proceed to Sample Application' to go to the test application</li>
    </ol>
    <div>
        <asp:Button ID="btnCreateTables" runat="server" onclick="btnCreateTables_Click" 
            Text="Create Tables" />
        <asp:Button ID="btnDropTables" runat="server" onclick="btnDropTables_Click" 
            Text="Drop Tables" />
        <a href="Main.aspx">Proceed to Sample application</a>
    </div>
    </form>
</body>
</html>
