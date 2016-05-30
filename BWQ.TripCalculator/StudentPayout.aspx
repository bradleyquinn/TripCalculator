<%@ Page Title="Student Payout" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StudentPayout.aspx.cs" Inherits="BWQ.TripCalculator.StudentPayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlSplash" CssClass="splashPayout">
        <asp:Panel runat="server" ID="pnlMain" CssClass="pnlwht pnlmain">
            <asp:Panel runat="server" ID="pnlInfo" CssClass="pnlinfo">
                <asp:Label runat="server" ID="lblOwes" CssClass="alert alert-info displayowes" />
                <asp:Label runat="server" ID="lblOwed" CssClass="alert alert-success displayowed" />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
