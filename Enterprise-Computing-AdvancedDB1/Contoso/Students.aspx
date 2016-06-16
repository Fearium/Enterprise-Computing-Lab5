<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Enterprise_Computing_AdvancedDB1.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Student</a>

                <label for="PageSizeDropDownList">Records per page: </label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged" CssClass="btn btn-default bt-sm dropdown-toggle">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="9999" />
                    </asp:DropDownList>

                <asp:GridView ID="StudentsGridView" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="false" 
                    DataKeyNames="StudentID" onRowDeleting="StudentsGridView_RowDeleting" AllowPaging="true" PageSize="3" 
                    AllowSorting="true" OnSorting="StudentsGridView_Sorting" OnPageIndexChanging="StudentsGridView_PageIndexChanging" 
                    PagerStyle-CssClass="pagination-ys" runat="server" OnRowDataBound="StudentsGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true" SortExpression="StudentID" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true" SortExpression="FirstMidName" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true" DataFormatString="{0:MMM dd, yyyy}" SortExpression="EnrollmentDate"/>

                        <asp:HyperLinkField HeaderText="Edit" Text="<i calss='fa fa-encil-square-o fa-lg'></i> Edit"
                            NavigateUrl="StudentDetails.aspx"  ControlStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="StudentID"
                            runat="server" DataNavigateUrlFormatString="StudentDetails.aspx?StudentID={0}" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" 
                            ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

