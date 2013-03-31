<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="QuickStart.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog Example - Main</title>
</head>
<body>
    <h1>Blog Example</h1>
    <form id="form1" runat="server">
    <p><asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label></p>
    <div>
        <p><label>Blog Name:</label><asp:TextBox runat="server" ID="txtBlog" EnableViewState="false"></asp:TextBox></p>
        <p><label>Blog Title:</label><asp:TextBox runat="server" ID="txtTitle" EnableViewState="false"></asp:TextBox></p>
        <p><label>Blog Text:</label><asp:TextBox runat="server" ID="txtBlogText" TextMode="MultiLine" Rows="6" EnableViewState="false"></asp:TextBox></p>
    </div>
    <div>
        <asp:Button runat="server" ID="btnSubmit" onclick="btnSubmit_Click" Text="Submit" />
    </div>
    <br/>
    <div>
        <asp:GridView 
        ID="GridView1" 
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        OnRowDataBound="gvBlogs_OnRowDataBound"
        AllowPaging="True"
        AllowSorting="True"
        DataSourceID="ObjectDataSource1"
        PageSize="5">
            <Columns>
                 <asp:TemplateField HeaderText="Link Id">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnId" runat="server" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Blog Id" SortExpression="Id">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Blog.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="this.Title">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Text" >
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Text") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server"
            TypeName="QuickStart.lib.BlogOds"
            SelectMethod="GetBlogRecords"
            SelectCountMethod="GetRecordCount"
            SortParameterName="sortExpression"
            StartRowIndexParameterName="startIndex"
            MaximumRowsParameterName="maximumRows">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
