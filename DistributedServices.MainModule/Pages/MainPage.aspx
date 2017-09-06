<%@ Page Language="C#" MasterPageFile="~/MasterMainPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" 
Inherits="DistributedServices.MainModule.MainPage" meta:resourceKey="Page"%>
<asp:Content ID="Tittle" ContentPlaceHolderID="Content_Tittle" runat="server">
</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="Content_Header" runat="server">
    <asp:Menu ID="MenuHeader" runat="server" StaticDisplayLevels="1" CssClass="menuHeader" Orientation="Horizontal" OnMenuItemClick="MenuHeader_MenuItemClick">
        <LevelMenuItemStyles>
            <asp:MenuItemStyle CssClass="menuItem"/>
            <asp:MenuItemStyle CssClass="menuItem"/>
        </LevelMenuItemStyles>
        <Items>
        <asp:MenuItem Value="File" meta:resourcekey="menuItemFile">
            <asp:MenuItem meta:resourcekey="subMenuItemLoadXsd" Value="LoadXsd"></asp:MenuItem>
            <asp:MenuItem meta:resourceKey="subMenuItemLoadXml" Value="LoadXml"></asp:MenuItem>
            <asp:MenuItem meta:resourcekey="subMenuItemLanguage" Value="Language" NavigateUrl="~/Pages/SetLocale.aspx"></asp:MenuItem>
        </asp:MenuItem>
        </Items>
        </asp:Menu>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="Content_Main" runat="server"> 
    <div id="panel">
        <asp:Panel ID="PnlUpload" runat="server" Visible="false" CssClass="panel">
            <div class="panel">
                <span="input">
                        <asp:FileUpload ID="FileUploadControl" runat="server" meta:resourcekey="btnUploadFile"/>
                        <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="FileUploadControl"
                        Display="Dynamic" CssClass="errorMessage" ErrorMessage="<%$Resources:, noFileError%>" SetFocusOnError="true">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="typeFileUploadValidator" runat="server" ControlToValidate="FileUploadControl"
                        ValidationExpression="^.+\.((xml)|(XML)|(xsd)|(XSD))$" CssClass="errorMessage" Display="Dynamic" 
                        ErrorMessage="<%$Resources:, xsdorxmlFiles %>" SetFocusOnError="true"></asp:RegularExpressionValidator>            
                </span>
                <span="button">  
                    <asp:Button ID="BtnUpload"  runat="server" meta:resourceKey="btnUpload" CssClass="buttonStyle" OnClick="BtnUpload_Click"></asp:Button>
                </span>
            </div>
        </asp:Panel>
        <asp:Panel ID="PnlFormUpload" runat="server" Visible="false" CssClass="panel">
            <div id="headerLinks">
                <asp:LinkButton ID="LnkEstimate" runat="server" CssClass="linkStyle">Estimate</asp:LinkButton>   
                <asp:LinkButton ID="LnkMilestones" runat="server" CssClass="linkStyle">Milestones</asp:LinkButton>
                <asp:LinkButton ID="LnkEstimateList" runat="server" CssClass="linkStyle">EstimateList</asp:LinkButton>        
                <asp:LinkButton ID="LnkPartQuery" runat="server" CssClass="linkStyle">PartQuery</asp:LinkButton>
            </div> 
          <%--  <asp:Panel ID="PnlFormTable" runat="server" Visible="false" CssClass="panel">
                <%-- <asp:TreeView ID="treeViewForm" runat="server" DataSourceID="FormDataSource">
                 </asp:TreeView>
                 <asp:XmlDataSource ID="FormDataSource" DataFile="form.xml" runat="server">
                 </asp:XmlDataSource>
            </asp:Panel>--%>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Footer" ContentPlaceHolderID="Content_Footer"  runat="server">
</asp:Content>


   
    


