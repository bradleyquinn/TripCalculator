<%@ Page Title="Student Expenses" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StudentExpenses.aspx.cs" Inherits="BWQ.TripCalculator.StudentExpenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlSplash" CssClass="splashExpense">
        <asp:Panel runat="server" ID="pnlMain" CssClass="pnlwht pnlmain">
            <asp:Panel runat="server" ID="pnlInfo" CssClass="pnlinfo">
                <asp:Label runat="server" ID="lblName" CssClass="mg5" Text="<b>Name:</b> (First, Last or both)" />
                <asp:TextBox runat="server" ID="tbxName" CssClass="mg5" /><br />
                <asp:Label runat="server" ID="lblFuel" CssClass="mg5" Style="margin-left: 43px;" Text="<b>Fuel or Flight cost:</b>" />
                <asp:TextBox runat="server" ID="tbxFuel" CssClass="mg5" /><br />
                <asp:Label runat="server" ID="lblFood" CssClass="mg5" Style="margin-left: 29px;" Text="<b>Food and Drink cost:</b>" />
                <asp:TextBox runat="server" ID="tbxFood" CssClass="mg5" /><br />
                <asp:Label runat="server" ID="lblLodging" CssClass="mg5" Style="margin-left: 77px;" Text="<b>Lodging cost:</b>" />
                <asp:TextBox runat="server" ID="tbxLodging" CssClass="mg5" /><br />
                <asp:Label runat="server" ID="lblActivities" CssClass="mg5" Style="margin-left: 7px;" Text="<b>Activites and Misc cost:</b>" />
                <asp:TextBox runat="server" ID="tbxActivities" CssClass="mg5" /><br />
                <asp:Button runat="server" ID="btnAnother" CssClass="btn btn-success mg5 mgt20" Text="Add another student" />
                <asp:Button runat="server" ID="btnDone" CssClass="btn btn-danger mg5 mgt20" Text="Done" />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
