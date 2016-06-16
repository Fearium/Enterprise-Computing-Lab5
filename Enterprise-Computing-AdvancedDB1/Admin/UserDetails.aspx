<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="Enterprise_Computing_AdvancedDB1.Admin.UserDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">


        <div class="row">


            <div class="col-md-offset-4 col-md-4">


                 <div class="alert alert-danger" id="AlertFlash" runat="server" visible="false">


                    <asp:Label runat="server" ID="StatusLabel" />


                </div>


                <h1>User Details Page</h1>


                <h5>All Fields are Required</h5>


                <br />


                <div class="panel panel-primary">


                    <div class="panel-heading">


                        <h1 class="panel-title"><i class="fa fa-user-plus fa-lg"></i> User Details</h1>


                    </div>


                    <div class="panel-body">


                        <div class="form-group">


                            <label class="control-label" for="UserNameTextBox">Username:</label>


                            <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>


                        </div>


                        <div class="form-group">


                            <label class="control-label" for="PhoneNumberTextBox">Phone Number:</label>


                            <asp:TextBox runat="server" TextMode="Phone" CssClass="form-control" ID="PhoneNumberTextBox" placeholder="Phone Number" required="true" TabIndex="0"></asp:TextBox>


                        </div>


                        <div class="form-group">


                            <label class="control-label" for="EmailTextBox">Email:</label>


                            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="EmailTextBox" placeholder="Email" required="true" TabIndex="0"></asp:TextBox>


                        </div>


                        <!-- Only Display if New User is being Registered -->


                        <asp:PlaceHolder ID="PasswordPlaceHolder" runat="server">


                            <div class="form-group">


                                <label class="control-label" for="PasswordTextBox">Password:</label>


                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>


                            </div>


                            <div class="form-group">


                                <label class="control-label" for="ConfirmPasswordTextBox">Confirm:</label>


                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="ConfirmPasswordTextBox" placeholder="Confirm Password" required="true" TabIndex="0"></asp:TextBox>


                                <asp:CompareValidator ErrorMessage="Your Passwords Must Match" Type="String" Operator="Equal"  ControlToValidate="ConfirmPasswordTextBox" runat="server"


                                    ControlToCompare="PasswordTextBox" CssClass="label label-danger" />


                            </div>


                        </asp:PlaceHolder>


                        <div class="text-right">


                            <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />


                            <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" TabIndex="0" />


                        </div>


                    </div>


                </div>  


            </div>


        </div>


    </div>


</asp:Content>
