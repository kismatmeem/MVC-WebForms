<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPageHR.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="HR.UI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedContent" runat="server">
     
    
    
    <style>
.homepage-container {
    height: 70vh; /* takes 70% of viewport height */
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-align: center;
    background-color: #f5f5f5; /* optional light background */
}

.homepage-container h1 {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 48px;
    color: #2c3e50;
    text-shadow: 1px 1px 2px #bdc3c7;
    margin: 0;
}



</style>


    <div class="homepage-container">
        <h1>HR Management System</h1>
        
    </div>



</asp:Content>


