<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SetLocale.aspx.cs" 
Inherits="DistributedServices.MainModule.Pages.SetLocale" meta:resourceKey="Page"%>
<asp:Content ID="ContentLocale" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <div id="form">
        <div class="field">
            <span class="label">
                <asp:Localize ID="LclLanguage" runat="server" meta:resourcekey="lclLanguage" />
            </span><span class="entry">
                <asp:DropDownList ID="ComboLanguage" runat="server" AutoPostBack="True" Width="100px"
                    OnSelectedIndexChanged="ComboLanguageSelectedIndexChanged">
                </asp:DropDownList>
            </span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="LclCountry" runat="server" meta:resourcekey="lclCountry" /></span><span
                    class="entry">
                    <asp:DropDownList ID="ComboCountry" runat="server" Width="100">
                </asp:DropDownList>
            </span>
        </div>
        <div class="button">
            <asp:Button ID="BtnSetLocale" runat="server" OnClick="BtnSetLocaleClick" meta:resourcekey="btnSetLocale" CssClass="buttonStyle" />
        </div>
    </div>
</asp:Content>


