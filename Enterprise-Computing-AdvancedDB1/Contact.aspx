<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Enterprise_Computing_AdvancedDB1.contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-6 text-center">
                <h1>Contact Us</h1>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Contact Info</div>
                    <div class="panel-body">

                        <address>
                            <strong>Jesse Baril</strong><br>
                            67 Toronto Street<br>
                            Barrie, CA L9L 9L9<br>
                            <abbr title="Phone">TEL:</abbr>
                            (705) 129-5432
                        </address>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label" for="FirstNameTextBox">First Name:</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger pull-right" ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is required!" ControlToValidate="FirstNameTextBox"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextBox" placeholder="First Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Last Name:</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger pull-right" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is required!" ControlToValidate="LastNameTextBox"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox" placeholder="Last Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="EmailTextBox">Email:</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger pull-right" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is required!" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="EmailTextBox" placeholder="Email" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="ContactNumberTextBox">Phone Number:</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger pull-right" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Phone Number is required!" ControlToValidate="ContactNumberTextBox"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" TextMode="Phone" CssClass="form-control" ID="ContactNumberTextBox" placeholder="Phone #" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="MessageTextBox">Message:</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger pull-right" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Message is required!" ControlToValidate="MessageTextBox"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Columns="3" CssClass="form-control" ID="MessageTextBox" placeholder="Phone #" required="true"></asp:TextBox>
                </div>
                <div class="text-right">
                    <a class="btn btn-warning btn-lg" id="CancelButton" href="Default.aspx">Cancel</a>
                    <asp:Button runat="server" CssClass="btn btn-primary btn-lg" ID="SendButton" Text="Send" CausesValidation="true" OnClick="SendButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
