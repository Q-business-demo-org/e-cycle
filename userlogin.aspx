<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="CyCity.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container" style="width:60%;margin-top: 63px;margin-bottom: 64px;">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Member Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Member ID</label>
                        <div class="form-group">
                           <asp:TextBox style="margin-top: 10px;" CssClass="form-control" ID="TextBox5" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                        <label style="margin-top: 10px;">Password</label>
                        <div class="form-group">
                           <asp:TextBox style="margin-top: 10px;" CssClass="form-control" ID="TextBox6" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:Button style="margin-top: 20px;width:100%" class="btn btn-success btn-block btn-lg" ID="Button4" runat="server" Text="Login" OnClick="Button4_Click" />
                        </div>
                        <div class="form-group">
                           <a href="usersignup.aspx"><input style="margin-top: 20px;width:100%" class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home/a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
