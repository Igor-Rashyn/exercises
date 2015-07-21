<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientDataGridASPNet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- &raquo - это две стрелочки --%>
     <%-- описывается 3 различными классами "btn", "btn-primary", "btn-lg" --%>
<%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p> 
    </div>--%>
    

<%--    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>

    </div>--%>
                 <div class="myGrid">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="787px" PageSize="15" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Height="498px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                         <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                         <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                         <asp:BoundField DataField="Strength" HeaderText="Strength" SortExpression="Strength" />
                         <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                         <asp:BoundField DataField="Stamina" HeaderText="Stamina" SortExpression="Stamina" />
                         <asp:BoundField DataField="Beauty" HeaderText="Beauty" SortExpression="Beauty" />
                         <asp:BoundField DataField="EyeColor" HeaderText="EyeColor" SortExpression="EyeColor" />
                         <asp:BoundField DataField="Smile" HeaderText="Smile" SortExpression="Smile" />
                         <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                         <asp:CommandField ShowEditButton="True" />
                         <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
                     <br/>
                     <p>
                        ID: <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
                        Name: <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                        Strength: <asp:TextBox ID="TextBoxStrength" runat="server"></asp:TextBox>
                        Age: <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
                        Stamina: <asp:TextBox ID="TextBoxStamina" runat="server"></asp:TextBox>
                     </p>
                     <br/>
                         <p>
                             Beauty: <asp:TextBox ID="TextBoxBeauty" runat="server"></asp:TextBox>
                             Color: <asp:TextBox ID="TextBoxEyeColor" runat="server"></asp:TextBox>
                             Smile: <asp:TextBox ID="TextBoxSmile" runat="server"></asp:TextBox>
                             <asp:Button ID="Button1" runat="server" Text="Add row" OnClick="Button1_Click" />
                         </p>
            </div>



</asp:Content>
