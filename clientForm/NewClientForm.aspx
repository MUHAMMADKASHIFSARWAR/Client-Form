<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewClientForm.aspx.cs" Inherits="clientForm.test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script
        src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="Cform.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap/css/CP.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ClientForm.css" rel="stylesheet" />
    <link href="css/CP.css" rel="stylesheet" />
    <link href="css/form-elements.css" rel="stylesheet" />

    <title></title>

    <script type="text/javascript" src="//cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.3.js"></script>
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" />
    <script src="js/jquery.sumoselect.min.js"></script>
    <link href="css/sumoselect.css" rel="stylesheet" />
    <script type="text/javascript">

        $(document).ready(function () {

            //var userType = document.getElementById('getSession').value;
            //if (user == 'MANAGER')
            //{
            //    $("#CFDetail").attr("aria-expanded", "true");

            //}
            //if (user == 'BackEnd') {
            //    $("#CFDetail").attr("aria-expanded", "true");

            //}

            $('#Panel2').hide();
            $('#Panel3').hide();
            $('#ddlBank').SumoSelect();
            //$('#ddlAgent').SumoSelect();
            $('#ddlBranch').SumoSelect();
            LoadAssigned();
            $("#ddlGroupName").chosen();


        });


        //$(document).ready(function () {


        //});

        function AssignReload(elementRef) {
            LoadAssigned();
        }

        function Pnl1OnClick(elementRef) {
            if (document.getElementById("txtNic").value == "") {
                document.getElementById("txtNic").style.borderColor = "Red";


            }
            else if (document.getElementById("txtCIExpiry").value == "") {
                document.getElementById("txtCIExpiry").style.borderColor = "Red";


            } else if (document.getElementById("txtNTN").value == "") {
                document.getElementById("txtNTN").style.borderColor = "Red";


            }
            else if (document.getElementById("txtNic").value == document.getElementById("txtContactCnic").value) {
                alert('Please Enter Correct Cnic Number , Client and Customer Cnic # same!');
                document.getElementById("txtNic").style.borderColor = "Red";
                document.getElementById("txtContactCnic").style.borderColor = "Red";
            }
            else if (document.getElementById("ddlCompIndustry").value == "Select") {

                alert('Company Industries Must be Select');

            }




            else {
                document.getElementById("txtNic").style.borderColor = "white";
                $('#Panel2').show();
                $('#Panel1').hide();
                $("#chkResNoRes :checkbox").click(function () {
                    $("#chkResNoRes input:checked").attr("checked", "");
                    $(this).attr("checked", "checked");
                });
            }




        }

        function PreviousPnl2(elementRef) {
            $('#Panel1').show();
            $('#Panel2').hide();

        }
        function PreviousPnl3(elementRef) {
            $('#Panel2').show();
            $('#Panel3').hide();
        }


        function Pnl2OnClick(elementRef) {
            $('#Panel2').hide();
            $('#Panel3').show();

        }
        //function confirm(elementRef) {
        //    if (document.getElementById("txtAggentRate").value == "") {
        //        document.getElementById("txtAggentRate").style.borderColor = "Red";
        //    }

        //    else (!confirm('Are you sure you want to Save?')) return false;

        //}





        function UncheckOthers(objchkbox) {
            var objchkList = objchkbox.parentNode.parentNode.parentNode;
            var chkboxControls = objchkList.getElementsByTagName("input");
            for (var i = 0; i < chkboxControls.length; i++) {
                if (chkboxControls[i] != objchkbox && objchkbox.checked) {
                    chkboxControls[i].checked = false;
                }
            }
        }
        function CloseOnClick(elementRef) {
            $('#lnkGVReload')[0].click();
        }

        function ShoWDrop(elementRef) {
            $('#showDrp').toggle();

        }


    </script>






    <style type="text/css">
        .dropdown {
            width: 300px;
        }

        .dropdown-menu > li > a {
            color: #428bca;
        }

        .dropdown ul.dropdown-menu {
            border-radius: 4px;
            box-shadow: none;
            margin-top: 20px;
            width: 300px;
        }

            .dropdown ul.dropdown-menu:before {
                content: "";
                border-bottom: 10px solid #fff;
                border-right: 10px solid transparent;
                border-left: 10px solid transparent;
                position: absolute;
                top: -10px;
                right: 16px;
                z-index: 10;
            }

            .dropdown ul.dropdown-menu:after {
                content: "";
                border-bottom: 12px solid #ccc;
                border-right: 12px solid transparent;
                border-left: 12px solid transparent;
                position: absolute;
                top: -12px;
                right: 14px;
                z-index: 9;
            }

        .navbar-inverse .navbar-nav > .open > a, .navbar-inverse .navbar-nav > .open > a:hover, .navbar-inverse .navbar-nav > .open > a:focus {
            color: #fff;
            Background: #006400;
        }

        body {
            background-color: #fafafa;
        }

        h1 {
            margin: 70px auto 50px auto;
        }

        .box {
            width: 80%;
            height: 400px;
            margin: 50px auto;
            background-color: #ccc;
        }

        #demo-1 {
            color: #fff;
            font-size: 90px;
        }

        body {
            font-family: "Lato", sans-serif;
        }

        .sidenav {
            height: 100%;
            width: 0;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #111;
            overflow-x: hidden;
            transition: 0.5s;
            padding-top: 60px;
        }

            .sidenav a {
                padding: 8px 8px 8px 32px;
                text-decoration: none;
                font-size: 20px;
                color: #818181;
                display: block;
                transition: 0.3s;
            }

                .sidenav a:hover {
                    color: #f1f1f1;
                }

            .sidenav .closebtn {
                position: absolute;
                top: 0;
                right: 25px;
                font-size: 36px;
                margin-left: 50px;
            }

        @media screen and (max-height: 450px) {
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }

        @media (min-width: 768px) {
            html, body {
                margin: 0;
                padding: 0;
                height: 100%;
            }

            .modalBackground {
                background-color: Gray;
                filter: alpha(opacity=70);
                opacity: 0.7;
            }

            .modalPopup {
                position: fixed;
                z-index: 10002;
                border-radius: 8px;
                left: 131px;
                top: 292px;
                width: 80%;
                background-color: white;
                /*background-color: rgba(0,0,0,0.5);*/
                /*border: 3px solid #0DA9D0;*/
            }

            #mp1_backgroundElement {
                position: fixed; /* Sit on top of the page content */
                display: none; /* Hidden by default */
                width: 100%; /* Full width (cover the whole page) */
                height: 100%; /* Full height (cover the whole page) */
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                background-color: rgba(0,0,0,0.5); /* Black background with opacity */
                z-index: 2; /* Specify a stack order in case you're using a different order for other elements */
                cursor: pointer; /* Add a pointer on hover */
            }

            .modalPopup .header {
                background-color: #006400;
                height: 40px;
                color: White;
                line-height: 30px;
                font-family: "Times New Roman", Times, serif;
                font-size: 20px;
                text-align: center;
                border-radius: 4px;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                padding: 5px;
                height: 500px;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .button {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup td {
                text-align: left;
            }

            .navbar-nav {
                float: left;
                margin: 0;
                font: left;
                margin-left: 21px;
                margin-top: 22px;
            }
        }

        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .tab-content .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .modalPopup {
            position: fixed;
            z-index: 10002;
            border-radius: 8px;
            left: 131px;
            top: 292px;
            width: 80%;
            background-color: white;
            /*background-color: rgba(0,0,0,0.5);*/
            /*border: 3px solid #0DA9D0;*/
        }

        #mp1_backgroundElement {
            position: fixed; /* Sit on top of the page content */
            display: none; /* Hidden by default */
            width: 100%; /* Full width (cover the whole page) */
            height: 100%; /* Full height (cover the whole page) */
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: rgba(0,0,0,0.5); /* Black background with opacity */
            z-index: 2; /* Specify a stack order in case you're using a different order for other elements */
            cursor: pointer; /* Add a pointer on hover */
        }

        .modalPopup .header {
            background-color: #006400;
            height: 40px;
            color: White;
            line-height: 30px;
            font-family: "Times New Roman", Times, serif;
            font-size: 20px;
            text-align: center;
            border-radius: 4px;
            font-weight: bold;
        }

        .modalPopup .body {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            padding: 5px;
            height: 500px;
        }

        .modalPopup .footer {
            padding: 3px;
        }

        .modalPopup .button {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }

        .modalPopup td {
            text-align: left;
        }

        .badge1 {
            position: relative;
        }

            .badge1[data-badge]:after {
                content: attr(data-badge);
                position: absolute;
                top: 0px;
                right: -22px;
                font-size: .7em;
                background: green;
                color: white;
                width: 18px;
                height: 18px;
                text-align: center;
                line-height: 18px;
                border-radius: 50%;
                box-shadow: 0 0 1px #333;
            }
        /*.inactiveLink {
   pointer-events: visible;
   cursor: default;
}*/
    </style>


</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:HiddenField ID="getSession" runat="server" />
        <div class="row">
            <div class="col-md-12">
                <div class="NavBar">
                    <nav class="navbar navbar-inverse">
                        <div class="container-fluid">

                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <h2>Contact:</h2>
                                    <h1>UAN (92-21)111-03-03-03</h1>

                                </li>

                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" style="margin-top: -13px;" data-toggle="dropdown">
                                        <span>
                                            <asp:Label ID="lblUserName" Font-Size="Large" runat="server" Text=""></asp:Label>
                                        </span><i class="glyphicon glyphicon-user pull-right" style="font-size: large;" onclick="ShoWDrop();" aria-hidden="true"></i></a>
                                    <ul class="dropdown-menu" id="showDrp">
                                        <li><a href="#">Account Settings <span class="glyphicon glyphicon-cog pull-right"></span></a></li>
                                        <li class="divider"></li>
                                        <li><a href="#">User stats <span class="glyphicon glyphicon-stats pull-right"></span></a></li>
                                        <li class="divider"></li>
                                        <li><a href="Default.aspx">Sign Out <span class="glyphicon glyphicon-log-out pull-right"></span></a></li>
                                    </ul>

                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
            </div>
        </div>




        <div class="container-fluid">

            <h1 style="font-size: 20px; color: #006400; margin-top: 7px; margin-bottom: 5px; text-align: center;">New Client & Rate Approval Form </h1>
            <ul class="nav nav-tabs">
                <li class="active"><a id="CForm" runat="server" data-toggle="tab" href="#home">Client Form</a></li>
                <li id="detailTab" runat="server"><a data-toggle="tab" id="CFDetail" runat="server" href="#menu1">My Task</a></li>
                <li id="ITTab" runat="server"><a data-toggle="tab" id="finalize" runat="server" href="#menu2">Fanalize Client</a></li>
                <li><a data-toggle="tab" id="AssignedTab" runat="server" href="#AssigTab" onclick="JavaScript: AssignReload();">Assigned </a></li>
            </ul>

            <div class="tab-content">
                <div id="home" runat="server" class="tab-pane fade in active">

                    <div class="content">
                        <div class="ClientFormStyle">




                            <br />
                            <div id="Panel1">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h2>Client Identity</h2>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Issue Date:"></asp:Label>
                                            <asp:TextBox ID="txtIssueDate" runat="server" Height="33px" Placeholder="Select Effective Date" CssClass="CFform-control"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtIssueDate" runat="server" />

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Category:"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlCategory" runat="server" Width="354px" CssClass="chosen-choices">
                                                <asp:ListItem>Individual</asp:ListItem>
                                                <asp:ListItem>Corporate</asp:ListItem>
                                                <asp:ListItem>Group</asp:ListItem>
                                                <asp:ListItem>Maket</asp:ListItem>
                                                <asp:ListItem>Walk-in</asp:ListItem>
                                                <asp:ListItem>Reciprocal</asp:ListItem>
                                                <asp:ListItem>Leasing</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Group Name:"></asp:Label>
                                            <asp:DropDownList ID="ddlGroupName" Width="354px" CssClass="chosen-choices" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Branch:"></asp:Label>
                                            <%--  <asp:ListBox ID="ddlBranch" runat="server" CssClass="CFform-control" SelectionMode="Multiple"></asp:ListBox>--%>

                                            <asp:DropDownList ID="ddlBranch" Height="33px" runat="server" CssClass="CFform-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Bank Include:"></asp:Label>
                                            <%-- <asp:DropDownList ID="ddlBank" runat="server" CssClass="CFform-control"></asp:DropDownList>--%>

                                            <asp:ListBox ID="ddlBank" runat="server" CssClass="CFform-control" SelectionMode="Multiple"></asp:ListBox>
                                        </div>


                                        <div class="col-sm-3">
                                            <asp:Label ID="lbl_Name" CssClass="lbl" runat="server" Text="Client Name:"></asp:Label>
                                            <asp:TextBox ID="txtName" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Client Name"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Prefix:"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlPrefix" Width="358px" runat="server" CssClass="chosen-choices">
                                            </asp:DropDownList>
                                        </div>



                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="CNIC #:"></asp:Label>
                                            <asp:TextBox ID="txtNic" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter CNIC"></asp:TextBox>
                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                runat="server" ForeColor="Red"
                                                ValidationExpression="^[0-9]{5}-[-|]-[0-9]{7}-[-|]-[0-9]{1}"
                                                ControlToValidate="txtNic"
                                                ErrorMessage="*">  
                                            </asp:RegularExpressionValidator>--%>
                                            <cc1:MaskedEditExtender
                                                TargetControlID="txtNic" ID="nicval" runat="server"
                                                Mask="99999-9999999-9" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="CNIC Issue Date:"></asp:Label>
                                            <asp:TextBox ID="txtCIExpiry" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Cnic Expiry Date"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="txtCIExpiry" runat="server" />
                                        </div>
                                        <%--     <div class="col-sm-3">
                                            <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Fax #:"></asp:Label>
                                            <asp:TextBox ID="txtFax" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Fax"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="NTN #:"></asp:Label>
                                            <asp:TextBox ID="txtNTN" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter NTN"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label9" CssClass="lbl" runat="server" Text="GST #:"></asp:Label>
                                            <asp:TextBox ID="txtGST" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter GST"></asp:TextBox>

                                        </div>


                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">

                                        <%--   <div class="col-sm-3">
                                            <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Email:"></asp:Label>
                                            <asp:TextBox ID="txtemail" Height="33px" runat="server" CssClass="CFform-control" placeholder="Please enter email"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label22" CssClass="lbl" runat="server" Text="Contact Persons:"></asp:Label>
                                            <asp:TextBox ID="txtContactPerson" Height="33px" runat="server" CssClass="CFform-control" placeholder="Please enter Contact Person Name"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label23" CssClass="lbl" runat="server" Text="Contact Person Cnic:"></asp:Label>
                                            <asp:TextBox ID="txtContactCnic" Height="33px" runat="server" CssClass="CFform-control" placeholder="Please enter Cnic"></asp:TextBox>

                                            <cc1:MaskedEditExtender
                                                TargetControlID="txtContactCnic" ID="contactVal" runat="server"
                                                Mask="99999-9999999-9" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="CNIC Issue Date:"></asp:Label>
                                            <asp:TextBox ID="txtCPnicExpire" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Cnic Expiry Date"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MMM/yyyy" TargetControlID="txtCPnicExpire" runat="server" />
                                        </div>


                                        <div class="col-sm-3">
                                            <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Reference By:"></asp:Label>
                                            <asp:TextBox ID="txtReference" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Reference "></asp:TextBox>

                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Company Industries:"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlCompIndustry" Width="360px" runat="server" CssClass="chosen-choices">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Comment:"></asp:Label>
                                            <asp:TextBox ID="txtComment" Height="100px" runat="server" CssClass="CFform-control" placeholder="Please enter Comment"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <br />
                                            <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Filer / Non Filer:"></asp:Label>
                                            <asp:CheckBoxList runat="server" CssClass="lblAML" ID="chkFiler">
                                                <asp:ListItem onclick="UncheckOthers(this);">  Filer</asp:ListItem>
                                                <asp:ListItem onclick="UncheckOthers(this);">  Non Filer</asp:ListItem>
                                            </asp:CheckBoxList>


                                            <%-- <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Filer:"></asp:Label>
                                            <asp:CheckBox ID="chkFiler" runat="server" />
                                            <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Non Filer:"></asp:Label>
                                            <asp:CheckBox ID="chkNonFiler" runat="server" />--%>
                                        </div>


                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sms-12">
                                        <h2>Client Address</h2>
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="col-sm-12">


                                                <asp:GridView ID="Gridview1" runat="server" ShowFooter="true"
                                                    AutoGenerateColumns="false" CssClass="table table-striped table-bordered responsive" OnRowDataBound="Gridview1_RowDataBound"
                                                    OnRowCreated="Gridview1_RowCreated">
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                                        <asp:TemplateField HeaderText="Address Type" HeaderStyle-Width="170px">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="txtAddresType" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Address" HeaderStyle-Width="370px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtAdress"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country" HeaderStyle-Width="180px">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="txtCountry" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="txtCity" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ZipCode" HeaderStyle-Width="127px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtZipCode"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Fax" HeaderStyle-Width="127px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFax"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="230px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtEmail"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>




                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="ButtonAdd" runat="server"
                                                                    Text="Add" CssClass="btn btn-success"
                                                                    OnClick="ButtonAdd_Click" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server"
                                                                    OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>



                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="row">
                                    <div class="col-sms-12">
                                        <h2>Contact Person Address</h2>
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="col-sm-12">


                                                <asp:GridView ID="GvContactPrson" runat="server" ShowFooter="true"
                                                    AutoGenerateColumns="false" CssClass="table table-striped table-bordered responsive"
                                                    OnRowCreated="GvContactPrson_RowCreated">
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                                        <asp:TemplateField HeaderText="Contact Person">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtcontactPerson"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtContPerNumb"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Cnic">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtContactPersonCnic"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                                <cc1:MaskedEditExtender
                                                                    TargetControlID="txtContactPersonCnic" ID="nicval" runat="server"
                                                                    Mask="99999-9999999-9" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cnic Expiry">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtContactPersonCnicExpiry"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtContactPersonCnicExpiry" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ntn">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtContactPersonNtn"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Gst">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtcontactPersonGst"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtContPerAddresss"
                                                                    class="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="btnContPerson" runat="server"
                                                                    Text="Add" CssClass="btn btn-success"
                                                                    OnClick="btnContPerson_Click" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkContPersonDelete" runat="server"
                                                                    OnClick="lnkContPersonDelete_Click">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>



                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">

                                            <button type="button" onclick="JavaScript: Pnl1OnClick();" id="btnNext" runat="server" class="btn btn-next">Next</button>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div id="Panel2">
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Request Type:"></asp:Label>
                                            <asp:DropDownList ID="ddlRequestType" Height="33px" runat="server" CssClass="CFform-control">
                                            </asp:DropDownList>
                                        </div>

                                        <%-- <div class="col-sm-3">
                                    <asp:Label ID="Label25" CssClass="lbl" runat="server" Text="Requested User:"></asp:Label>
                                    <asp:TextBox ID="txtReqUSer" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Requested User"></asp:TextBox>
                                </div>--%>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Potential Exposure:"></asp:Label>
                                            <asp:TextBox ID="txtExposure" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Total Exposure"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Potential Premium:"></asp:Label>
                                            <asp:TextBox ID="txtPotential" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Potential Premium"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Insurance Type:"></asp:Label>
                                            <asp:DropDownList ID="ddlInsType" CssClass="CFform-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <%--   <div class="col-sm-3">
                                            <asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Requested Branch:"></asp:Label>
                                            <asp:DropDownList ID="ddlReqBranch" Height="33px" runat="server" CssClass="CFform-control"></asp:DropDownList>

                                        </div>--%>
                                    </div>

                                </div>

                                <%--      <div class="row">
                                    <div class="col-sm-12">
                                       <asp:DropDownList ID="ddlBussCat" CssClass="CFform-control" OnSelectedIndexChanged="ddlBussCat_SelectedIndexChanged" runat="server">
                                           <asp:ListItem Text="Conventional "></asp:ListItem>
                                                 <asp:ListItem Text="Takaful "></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>--%>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-12">

                                                <asp:GridView ID="gvCFDept" runat="server"
                                                    CellPadding="4" ForeColor="#333333" Width="100%" ShowFooter="true" AutoGenerateColumns="false"
                                                    CssClass="table table-striped table-bordered responsive" OnRowCreated="gvCFDept_RowCreated" OnRowDataBound="gvCFDept_RowDataBound" DataKeyNames="">

                                                    <AlternatingRowStyle BackColor="White" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                                    <PagerStyle BackColor="#006400" HorizontalAlign="Right" CssClass="GridPager" />
                                                    <EmptyDataTemplate>
                                                        <h1>No records Found!</h1>
                                                    </EmptyDataTemplate>
                                                    <RowStyle BackColor="#E0E0E0" HorizontalAlign="Justify" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Width="50px" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" Width="50px" />
                                                    <SortedAscendingHeaderStyle BackColor="#D9EDF7" Width="50px" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" Width="50px" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" Width="50px" />

                                                    <Columns>
                                                        <%--    <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDept" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                        <%--   <asp:BoundField DataField="Department" HeaderText="Department" />--%>


                                                        <asp:TemplateField HeaderText="Department">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlDept" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bussniess Class Category">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlBusClassCat" CssClass="CFform-control" OnSelectedIndexChanged="ddlBusClassCat_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Conventional"></asp:ListItem>
                                                                    <asp:ListItem Text="Takaful"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bussniess Class">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlBusClass" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Insurance Type">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlInsrType" CssClass="CFform-control" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Exposure">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtExposure" runat="server" Height="33px" placeholder="Please Enter Exposure" CssClass="form-control"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Rate">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtRate" runat="server" Height="33px" placeholder="Please Enter Rate" CssClass="form-control"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Commission">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCommession" runat="server" Height="33px" placeholder="Please Enter Commission" CssClass="form-control"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="btnDeptAdd" runat="server"
                                                                    Text="Add" CssClass="btn btn-success"
                                                                    OnClick="btnDeptAdd_Click" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDepartmentDelete" runat="server"
                                                                    OnClick="lnkDepartmentDelete_Click">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>


                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <p class="labelAMl">AML:</p>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-6">

                                                <asp:GridView ID="GvRating" runat="server"
                                                    CellPadding="4" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                                    CssClass="table table-striped table-bordered responsive" DataKeyNames="">

                                                    <AlternatingRowStyle BackColor="White" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                                    <PagerStyle BackColor="#006400" HorizontalAlign="Right" CssClass="GridPager" />
                                                    <EmptyDataTemplate>
                                                        <h1>No records Found!</h1>
                                                    </EmptyDataTemplate>
                                                    <RowStyle BackColor="#E0E0E0" HorizontalAlign="Justify" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Width="50px" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" Width="50px" />
                                                    <SortedAscendingHeaderStyle BackColor="#D9EDF7" Width="50px" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" Width="50px" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" Width="50px" />

                                                    <Columns>
                                                        <asp:BoundField DataField="Rating" HeaderText="Rating" HeaderStyle-Width="181px" ItemStyle-Width="181px" />
                                                        <asp:TemplateField HeaderText="High">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkHigh" AutoPostBack="true" OnCheckedChanged="chkHigh_CheckedChanged" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Medium">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkMed" AutoPostBack="true" OnCheckedChanged="chkMed_CheckedChanged" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Low">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkLow" AutoPostBack="true" OnCheckedChanged="chkLow_CheckedChanged" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>





                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <%--  <div class="col-sm-3">

                                        <asp:Label ID="Label26" CssClass="lblAML" runat="server" Text="Customer Type:"></asp:Label>
                                        <asp:DropDownList ID="ddlCustType" Width="200px" runat="server" Height="33px" CssClass="CFform-control">
                                            <asp:ListItem>Listed</asp:ListItem>
                                            <asp:ListItem>Individual</asp:ListItem>
                                            <asp:ListItem>Coporate</asp:ListItem>
                                            <asp:ListItem>Pep</asp:ListItem>

                                        </asp:DropDownList>

                                    </div>--%>
                                            <div class="col-sm-3">

                                                <asp:CheckBoxList runat="server" CssClass="lblAML" ID="chkResNoRes">
                                                    <asp:ListItem onclick="UncheckOthers(this);">  Resident</asp:ListItem>
                                                    <asp:ListItem onclick="UncheckOthers(this);">  Non Resident</asp:ListItem>
                                                </asp:CheckBoxList>



                                            </div>

                                            <%--  <div class="col-sm-3">
                                            <asp:CheckBox ID="chkResident" onclick="CheckOne(this)" runat="server" /> Resident 
                                          <asp:CheckBox ID="CheckBox1" onclick="CheckOne(this)" runat="server" /> Non Resident 
                                        </div>--%>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <button type="button" onclick="JavaScript: PreviousPnl2();" class="btn btn-previous">Previous</button>
                                <button type="button" onclick="JavaScript: Pnl2OnClick();" class="btn btn-next">Next</button>
                            </div>
                            <br />
                            <div id="Panel3">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label28" CssClass="lbl" runat="server" Text="Producer Name:"></asp:Label>
                                            <asp:TextBox ID="txtProducer" Height="33px" runat="server" CssClass="CFform-control" placeholder="Please enter Producer"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label29" CssClass="lbl" runat="server" Text="Agent Name:"></asp:Label>
                                            <%--<asp:TextBox ID="txtAgent" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Agent"></asp:TextBox>--%>
                                            <%-- <asp:ListBox ID="ddlAgent" runat="server" CssClass="chosen-choices" SelectionMode="Multiple"></asp:ListBox>--%>
                                            <asp:DropDownList ID="ddlAgent" Width="357px" CssClass="chosen-choices" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label30" CssClass="lbl" runat="server" Text="Agent Rate:"></asp:Label>
                                            <asp:TextBox ID="txtAggentRate" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Aggent Rate"></asp:TextBox>
                                            <%-- <cc1:MaskedEditExtender Mask="99.99" MaskType="Number" ClearMaskOnLostFocus="true"
                                                ClearTextOnInvalid="true" AcceptNegative="Left" ID="MaskedEditExtender1" runat="server"
                                                TargetControlID="txtAggentRate" />--%>

                                            <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtAggentRate"  text="Rate Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                                        </div>

                                    </div>
                                </div>
                                <br />
                                <br />
                                <button type="button" onclick="JavaScript: PreviousPnl3();" class="btn btn-previous">Previous</button>
                                <asp:Button ID="btnSubmit" runat="server" OnClientClick="if(!confirm('Are you sure you want to Save?')) return false;" Text="Submit" CssClass="btnAdd" OnClick="btnSubmit_Click" />
                            </div>

                        </div>
                    </div>
                </div>
                <div id="menu1" runat="server" class="tab-pane fade">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-3 ">
                                        <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Client Name:"></asp:Label>
                                        <asp:TextBox ID="txtClient" runat="server" CssClass="form-control" placeholder="Please Enter Client Name"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="Label24" CssClass="lbl" runat="server" Text="CNIC #:"></asp:Label>
                                        <asp:TextBox ID="txtcnics" runat="server" CssClass="form-control" placeholder="Please Enter Cnic"></asp:TextBox>

                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="Label25" CssClass="lbl" runat="server" Text="NTN #:"></asp:Label>
                                        <asp:TextBox ID="txtntns" runat="server" CssClass="form-control" placeholder="Please Enter  Ntn #"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label26" CssClass="lbl" runat="server" Text="GST #:"></asp:Label>
                                        <asp:TextBox ID="txtgsts" runat="server" CssClass="form-control" placeholder="Please Enter Gst #"></asp:TextBox>
                                    </div>




                                    <div class="col-md-3">
                                        <asp:Label ID="Label33" runat="server" CssClass="lbl" Text="From Date:"></asp:Label>
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MMM/yyyy" TargetControlID="txtFromDate" runat="server" />

                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label34" CssClass="lbl" runat="server" Text="To Date:"></asp:Label>
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MMM/yyyy" TargetControlID="txtToDate" runat="server" />
                                    </div>


                                    <div class="col-md-3">
                                        <br />
                                        <asp:Button ID="btnSearch" CssClass="PolicyButton" OnClick="btnSearch_Click" runat="server" Text="Search" />
                                    </div>
                                </div>
                            </div>

                            <br />
                            <h2 style="font-size: 15px; font-weight: 600; color: #006400; margin-top: 7px; margin-bottom: 5px;">Pending Client</h2>
                            <div class="row">
                                <asp:LinkButton ID="lnkGVReload" Visible="true" Style="display: none; width: 0px;" OnClick="lnkGVReload_Click" runat="server">Re Load</asp:LinkButton>
                                <div class="col-md-12">
                                    <asp:GridView ID="gvClientForm" runat="server"
                                        CellPadding="4" AllowPaging="true" PageSize="20" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                        CssClass="table table-striped table-bordered responsive" DataKeyNames="CF_ID,LOC_CODE" OnPageIndexChanging="gvClientForm_PageIndexChanging">

                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                        <PagerStyle BackColor="#006400" HorizontalAlign="Right" CssClass="GridPager" />
                                        <EmptyDataTemplate>
                                            <h1>No records Found!</h1>
                                        </EmptyDataTemplate>

                                        <RowStyle BackColor="#E0E0E0" HorizontalAlign="Justify" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Width="50px" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" Width="50px" />
                                        <SortedAscendingHeaderStyle BackColor="#D9EDF7" Width="50px" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" Width="50px" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" Width="50px" />


                                        <Columns>

                                            <asp:BoundField DataField="CF_ID" HeaderText="Id" />
                                            <asp:BoundField DataField="PLC_LOCADESC" HeaderText="Branch" />
                                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                                            <asp:BoundField DataField="REQUESTUSER" HeaderText="Request User" />
                                            <asp:BoundField DataField="REQUEST_DATE" HeaderText="Request Date" />
                                            <asp:BoundField DataField="CATEGORY_CODE" HeaderText="Category" />
                                            <asp:BoundField DataField="GROUP_NAME" HeaderText="Group" />
                                            <asp:BoundField DataField="PSP_STYPDESC" HeaderText="Request Type" />

                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkViewDetail" ControlStyle-ForeColor="#6699ff" OnClick="linkViewDetail_Click" runat="server" Text="View Detail"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:ModalPopupExtender ID="mp2" TargetControlID="btnShowPopupView" runat="server" PopupControlID="pnlPopUpView"
                                        CancelControlID="btnCloseView" BackgroundCssClass="modalBackground" BehaviorID="mp1">
                                    </cc1:ModalPopupExtender>

                                    <asp:Button ID="btnShowPopupView" runat="server" Style="display: none" />

                                    <asp:Panel ID="pnlPopUpView" runat="server" Width="90%" CssClass="modalPopup" align="center" Style="display: grid">
                                        <div class="overlay" id="parentframesCRUpdate" style="border-bottom: solid; border-bottom-color: #006400">
                                            <div class="header">
                                                Client Form Details:

                                       <a href="#" id="btnCloseView" onclick="JavaScript: CloseOnClick();" style="color: white"><i class="fa fa-window-close" style="float: right; margin-top: 7px; font-size: 24px; margin-right: 10px" aria-hidden="true"></i>

                                       </a>

                                            </div>

                                            <iframe height="500px" width="100%" id="Iframe1" src="clientFormDetails.aspx" runat="server"></iframe>

                                            <br />
                                        </div>

                                    </asp:Panel>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(".chosen-choices").chosen();
                            </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div id="menu2" runat="server" class="tab-pane fade">
                    <%--   <h2 style="font-size: 15px; font-weight: 600; color: #006400; margin-top: 7px; margin-bottom: 5px;">Finalize Client</h2>--%>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <br />
                            <asp:LinkButton ID="lnkFinalize" Visible="true" Style="display: none; width: 0px;" OnClick="lnkFinalize_Click" runat="server">Re Load</asp:LinkButton>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-3 ">
                                        <asp:Label ID="Label27" CssClass="lbl" runat="server" Text="Client Name:"></asp:Label>
                                        <asp:TextBox ID="txtclientFinal" runat="server" CssClass="form-control" placeholder="Please Enter Client Name"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="Label31" CssClass="lbl" runat="server" Text="CNIC #:"></asp:Label>
                                        <asp:TextBox ID="txtcnicFinal" runat="server" CssClass="form-control" placeholder="Please Enter Cnic"></asp:TextBox>

                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="Label32" CssClass="lbl" runat="server" Text="NTN #:"></asp:Label>
                                        <asp:TextBox ID="txtntnFinal" runat="server" CssClass="form-control" placeholder="Please Enter  Ntn #"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label35" CssClass="lbl" runat="server" Text="GST #:"></asp:Label>
                                        <asp:TextBox ID="txtgstFinal" runat="server" CssClass="form-control" placeholder="Please Enter Gst #"></asp:TextBox>
                                    </div>




                                    <div class="col-md-3">
                                        <asp:Label ID="Label36" runat="server" CssClass="lbl" Text="From Date:"></asp:Label>
                                        <asp:TextBox ID="txtfromDateFinal" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender6" Format="dd/MMM/yyyy" TargetControlID="txtfromDateFinal" runat="server" />

                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label37" CssClass="lbl" runat="server" Text="To Date:"></asp:Label>
                                        <asp:TextBox ID="txttoDateFinal" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender7" Format="dd/MMM/yyyy" TargetControlID="txttoDateFinal" runat="server" />
                                    </div>


                                    <div class="col-md-3">
                                        <br />
                                        <asp:Button ID="btnSearchFinal" CssClass="PolicyButton" OnClick="btnSearchFinal_Click" runat="server" Text="Search" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">

                                <div class="col-md-12">
                                    <asp:GridView ID="gvFinaliazeclient" runat="server"
                                        CellPadding="4" AllowPaging="true" PageSize="20" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                        CssClass="table table-striped table-bordered responsive" OnRowCommand="gvFinaliazeclient_RowCommand" DataKeyNames="CF_ID" OnPageIndexChanging="gvFinaliazeclient_PageIndexChanging">

                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                        <PagerStyle BackColor="#006400" HorizontalAlign="Right" CssClass="GridPager" />
                                        <EmptyDataTemplate>
                                            <h1>No records Found!</h1>
                                        </EmptyDataTemplate>
                                        <%--  <PagerStyle BackColor="green" ForeColor="White" HorizontalAlign="Center" />--%>
                                        <RowStyle BackColor="#E0E0E0" HorizontalAlign="Justify" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Width="50px" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" Width="50px" />
                                        <SortedAscendingHeaderStyle BackColor="#D9EDF7" Width="50px" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" Width="50px" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" Width="50px" />


                                        <Columns>
                                            <%--  <asp:HyperLinkField HeaderText="Intimation No" DataTextField="gih_doc_ref_no" DataNavigateUrlFormatString="CBDPolicyDetails.aspx?GDH_DOC_REFERENCE_NO={0}&ClaimStatus={1}&Mode=2"
                                        DataNavigateUrlFields="gih_doc_ref_no,ClaimStatus" />--%>

                                            <asp:BoundField DataField="CF_ID" HeaderText="Id" />
                                            <asp:BoundField DataField="PLC_LOCADESC" HeaderText="Branch" />
                                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                                            <asp:BoundField DataField="REQUESTUSER" HeaderText="Request User" />
                                            <asp:BoundField DataField="REQUEST_DATE" HeaderText="Request Date" />
                                            <asp:BoundField DataField="CATEGORY_CODE" HeaderText="Category" />
                                            <asp:BoundField DataField="GROUP_NAME" HeaderText="Group" />
                                            <asp:BoundField DataField="PSP_STYPDESC" HeaderText="Request Type" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkFinalView" ControlStyle-ForeColor="#6699ff" OnClick="linkFinalView_Click" runat="server" Text="View Detail" CommandName="linkViewDetail"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:ModalPopupExtender ID="mpF" TargetControlID="btnCloseViewFinalize" runat="server" PopupControlID="pnlPopUpfinalize"
                                        CancelControlID="btnCloseFinalize" BackgroundCssClass="Background" BehaviorID="mpF">
                                    </cc1:ModalPopupExtender>

                                    <asp:Button ID="btnCloseViewFinalize" runat="server" Style="display: none" />

                                    <asp:Panel ID="pnlPopUpfinalize" runat="server" Width="90%" CssClass="modalPopup" align="center" Style="display: grid">
                                        <div class="overlay" id="parentframesCRUFinalize" style="border-bottom: solid; border-bottom-color: #006400">
                                            <div class="header">
                                                Client Form Details:

                                       <a href="#" id="btnCloseFinalize" onclick="JavaScript: CloseOnClick();" style="color: white"><i class="fa fa-window-close" style="float: right; margin-top: 7px; font-size: 24px; margin-right: 10px" aria-hidden="true"></i>

                                       </a>

                                            </div>

                                            <iframe height="500px" width="100%" id="Iframe2" src="clientFormDetails.aspx" runat="server"></iframe>

                                            <br />
                                        </div>

                                    </asp:Panel>
                                </div>
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>





                </div>


                <div id="AssigTab" runat="server" class="tab-pane fade">

                    <br />
                    <div style="width: 100%; padding-left: -10px;">
                        <div class="table-responsive">
                            <table id="tblAssign" class="display" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th id="tbAssign-1" data-priority="1">ID</th>
                                        <th id="tbAssign-2" data-priority="1">Department</th>
                                        <th id="tbAssign-7" data-priority="2">Client Name</th>
                                        <th id="tbAssign-3" data-priority="1">Assign User</th>
                                        <th id="tbAssign-4" data-priority="1">Assigned To</th>
                                        <th id="tbAssign-5" data-priority="2">Request Date</th>
                                        <th id="tbAssign-6" data-priority="2">Group Name</th>

                                        <th data-priority="0"></th>
                                    </tr>
                                </thead>


                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-12">
                            <div class="modal fade" id="myModal" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content" style="width: 1000px; margin-left: -220px;">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Comments History</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div style="width: 100%; padding-left: -10px;">
                                                <div class="table-responsive">
                                                    <table id="tblViewComment" class="display" style="width: 100%">
                                                        <thead>
                                                            <tr>
                                                                <th id="tblViewComment-1" data-priority="2">ID</th>
                                                                <th id="tblViewComment-2" data-priority="2">User Id</th>
                                                                <th id="tblViewComment-3" data-priority="2">Assigned To</th>
                                                                <th id="tblViewComment-4" data-priority="3">Assigned Date</th>
                                                                <th id="tblViewComment-5" data-priority="1">Comments</th>

                                                            </tr>
                                                        </thead>


                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>



                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
