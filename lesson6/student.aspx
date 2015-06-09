<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="lesson6.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtLastName" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtEnrollDate" class="col-sm-3">Enrollment Date(yyyy-mm-dd):</label>
        <asp:TextBox ID="txtEnrollDate" runat="server" required="true" 
            MaxLength="50"/>
        <asp:CompareValidator
            ID="dateValidator" runat="server" 
            Type="Date"
            Operator="DataTypeCheck"
            ControlToValidate="txtEnrollDate" 
            ErrorMessage="Please enter a valid date.">
        </asp:CompareValidator>
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" 
        OnClick="btnSave_Click"/>
    </div>
</asp:Content>
