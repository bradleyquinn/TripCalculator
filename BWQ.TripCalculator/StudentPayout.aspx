<%@ Page Title="Student Payout" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StudentPayout.aspx.cs" Inherits="BWQ.TripCalculator.StudentPayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlSplash" CssClass="splashPayout">
        <asp:Panel runat="server" ID="Panel1" CssClass="pnlwht pnlmain">
            <asp:Label runat="server" ID="DummyTag" Text="This is the Payout Page!" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
