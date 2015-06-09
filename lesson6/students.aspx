<%@ Page Title="Contoso University - Students" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="lesson6.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>
    <a href="student.aspx">Add Student</a>
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdStudents_RowDeleting" 
        DataKeyNames="StudentID" OnSorting="grdStudents_Sorting" AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="LastName" SortExpression="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" SortExpression="FirstMidName" HeaderText="First Name" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/student.aspx" Text="Edit"
                DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="student.aspx?StudentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
