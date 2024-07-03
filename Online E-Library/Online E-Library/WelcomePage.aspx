<%@ Page Title="" Language="C#" MasterPageFile="~/welcome.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="Online_E_Library.WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-5">
            <img style=" margin-top:65px" src="images/All%20necessary%20Images/imgs/e-library-concept-illustration_135170-50.png" width="837" height="auto" />
        </div>
        <div class="col-md-5">
            <h1 style="text-align: right; margin-top: 215px; font-size: 95px; margin-left: 270px;">Welcome</h1>
            <br />
            <h2 style="text-align:inherit;font-size: 35px; margin-left: 300px; margin-top: -40px;">To Online Library&nbsp;</h2>
            <p style="text-align:inherit;font-size: 35px; margin-left: 300px; margin-top: -40px;">&nbsp;</p>
            <p style="text-align:inherit;font-size: 35px; margin-left: 300px; margin-top: -40px;">&nbsp;</p>
            <p style="text-align:inherit;font-size: 35px; margin-left: 300px; margin-top: -40px;">&nbsp;</p>
            <br />
            <h6 style="margin-left:290px;margin-top:-20px;text-align: center;">Click hear to go to home page&nbsp; 
                <asp:Button class="btn btn-outline-success" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            </h6>

        </div>
    </div>

</asp:Content>
