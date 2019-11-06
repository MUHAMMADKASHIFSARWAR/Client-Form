<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="clientForm.ClientDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="bootstrap/js/jq3.3.1.js"></script>
    <script src="bootstrap/js/maxcdnMincs.js"></script>
    <%--   <link href="bootstrap/css/fonts.css" rel="stylesheet" />
    <link href="fontawesome-free-5.8.1-web/css/all.css" rel="stylesheet" />--%>
    <%--      <link rel="stylesheet" href="bower_components/kendo-ui/styles/kendo.common-material.min.css" />--%>
    <link rel="stylesheet" href="bower_components/kendo-ui/styles/kendo.material.min.css" id="kendoCSS" />
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css" media="all" />
 <%--   <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" type="text/css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="assets/css/main.min.css" media="all" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap/css/ClientFormStyle.css" rel="stylesheet" />
    <link href="css/attachement.css" rel="stylesheet" />
    <link href="bootstrap/css/CP.css" rel="stylesheet" />
    <script src="js/CFJquery.js"></script>
    <%-- new Add--%>
    <link href="css/Dropzone.css" rel="stylesheet" />
    <script src="js/DropzondJS.js"></script>
    <link href="css/ClientForm.css" rel="stylesheet" />
    <script src="Cform.js"></script>
    <script src="js/DropdownJs.js"></script>
    <script src="js/CFNewJS.js"></script>
    <script src="js/CFNewJS2.js"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>

    <%--    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/dropzone/4.3.0/dropzone.css" />--%>
    <%-- <script type="text/javascript" language="javascript" src="https://cdnjs.cloudflare.com/ajax/libs/dropzone/4.3.0/dropzone.js"></script>--%>

    <%-- <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />--%>

    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-dropdown/2.0.3/jquery.dropdown.min.js"></script>--%>


    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <%-- <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {


            localStorage.setItem('userid', $('#hdnuser').val());
            localStorage.setItem('UserRole', $('#hdnUserRole').val());


        });


        function check(input) {

            var checkboxes = document.getElementsByClassName("radioCheck");

            for (var i = 0; i < checkboxes.length; i++) {
                //uncheck all
                if (checkboxes[i].checked == true) {
                    checkboxes[i].checked = false;
                }
            }

            //set checked of clicked object
            if (input.checked == true) {
                input.checked = false;
            }
            else {
                input.checked = true;
            }
        }


    </script>
    <style type="text/css">
        .dz-default {
            background-image: url(images/Upload.png);
            background-repeat: no-repeat;
            background-position: center;
            background-size: 212px 92px;
            height: 100px;
            margin-top: -14px;
        }

        label.error {
            background: url(images/unchecked.gif) no-repeat;
            padding-left: 16px;
            margin-left: .3em;
            margin-top: 55px;
        }

        .md-input {
            text-transform: uppercase;
        }

        label.error active {
            margin-top: 40px
        }

        label.valid {
            background: url(images/checked.gif) no-repeat;
            display: block;
            margin-top: 62px;
            width: 16px;
            height: 16px;
        }

        .reqbtn {
            background-color: #096735;
            color: white;
            padding: 8px;
            border-radius: 6px;
            font-size: 15px;
            width: 86px;
            border: none;
            cursor: pointer;
        }

        .md-card .md-card-head {
            height: 160px;
            position: relative;
            border-bottom: 1px solid rgba(0,0,0,.12);
            /* background-color: aquamarine; */
            height: 115px;
            border: solid;
            border-width: thin;
            border-color: #6fa0a0;
            border-radius: 1em;
        }

        .checkboxRevrt {
            margin-left: 10px;
            float: left;
        }
    </style>
</head>
<body>


    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnuser" runat="server" />
        <asp:HiddenField ID="hdnUserRole" runat="server" />
        <div class="row">
            
        </div>
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
                                <li> <span style="color:white">
                                            <asp:Label ID="lblUserName" Font-Size="Large" runat="server" Text=""></asp:Label>
                                        </span></li>

                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" style="margin-top: -13px;" data-toggle="dropdown">
                                       
                                        <i class="glyphicon glyphicon-user pull-right" style="font-size: large;"  aria-hidden="true"></i></a>
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
        <div id="tabs">
            <ul class="nav nav-tabs">
                <li id="CfCF" class="active"><a id="CForm" runat="server" data-toggle="tab" href="#home">CLIENT FORM</a></li>
                <li id="detailTab" runat="server"><a data-toggle="tab" id="CFDetail" runat="server" href="#MyTask">MY TASK
                </a></li>
                <%-- <li id="ITTab" runat="server"><a data-toggle="tab" id="finalize" runat="server" href="#menu2">Fanalize Client</a></li>--%>
                <li><a data-toggle="tab" id="AssignedTab" runat="server" href="#AssigTab">ASSIGNED </a></li>
                <li><a data-toggle="tab" id="FinalizeTab" style="display: none" runat="server" href="#Finalize">FINALIZE CLIENT </a></li>
            </ul>
        </div>
        <div class="tab-content">
            <div id="home" runat="server" class="tab-pane fade in active">
                <div class="col-sm-12">


                    <div class="col-xs-4  col-sm-2">
                        <%--  data-toggle="tab"--%>
                        <ul id="ClientMenu" class="nav nav-tabs tabs-left sideways" style="margin-left: -30px;">
                            <li class="active"><a href="#home-v">CLIENT DETAIL</a></li>
                            <li><a href="#Address">ADDRESS</a></li>
                            <li><a href="#ContactInfo">CONTACT INFO</a></li>
                            <li><a href="#OtherDetails">OTHER DETAILS</a></li>

                            <li><a href="#BusniessInfo">BUSNIESS CLASS RATE</a></li>
                            <li><a href="#AgentProducer">AGENT / PRODUCER</a></li>
                            <li><a href="#Compliance" >AML / COMPLIANCE</a></li>
                            <li><a href="#InstallmentMode">CREDIT TERMS</a></li>
                            <li><a href="#Attachment" >ATTACHMENT</a></li>
                            <li id="historyMenu" style="display: none"><a href="#History" data-toggle="tab">HISTORY</a></li>
                            <li id="ChatMenu"><a href="#Chat">CHAT</a></li>
                        </ul>
                    </div>

                    <div class="col-xs-8  col-md-10">

                        <div class="tab-content">
                            <%-- --%>
                            <div class="tab-pane active" id="home-v">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">CLIENT DETAIL</label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>BRANCH</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="md-input">
                                                        <%--   <asp:ListItem Value="" disabled="" Selected="" hidden="">Select Branch</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>CATEGORY</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="md-input" title="Please select Category" required="">
                                                        <%--  <asp:ListItem Value="" disabled="" Selected="" >Select Category</asp:ListItem>--%>
                                                        <asp:ListItem>Individual</asp:ListItem>
                                                        <asp:ListItem>Corporate</asp:ListItem>
                                                        <%-- <asp:ListItem>Group</asp:ListItem>
                                                    <asp:ListItem>Maket</asp:ListItem>
                                                    <asp:ListItem>Walk-in</asp:ListItem>
                                                    <asp:ListItem>Reciprocal</asp:ListItem>
                                                    <asp:ListItem>Leasing</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>PREFIX</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlPrefix" runat="server" CssClass="md-input" required="">
                                                        <%--  <asp:ListItem Value="" disabled="" Selected="" hidden="">Select Prefix</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>




                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>CLIENT NAME</label>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="md-input" required=""></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-sm-4" id="form_test">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>CNIC</label>
                                                    <%--<input type="text"  data-inputmask="'mask': '99999-9999999-9'"  placeholder="XXXXX-XXXXXXX-X"  name="cnic" required="" />--%>
                                                    <asp:TextBox ID="txtNic" runat="server" required="" minlength="13" CssClass="md-input md-input-danger" name="cnic"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>CNIC ISSUE DATE</label>
                                                    <asp:TextBox ID="txtIssueDate" required="" runat="server" CssClass="datepicker  md-input md-input-danger"></asp:TextBox>
                                                    <%--  <cc1:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" TargetControlID="txtIssueDate" runat="server" />--%>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>




                                    </div>



                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>CNIC EXPIRY DATE</label>
                                                    <asp:TextBox ID="txtExpireDate" required="" runat="server" CssClass="datepicker  md-input md-input-danger"></asp:TextBox>
                                                    <%--  <cc1:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" TargetControlID="txtExpireDate" runat="server" />--%>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>NTN</label>
                                                    <asp:TextBox ID="txtNTN" required="" minlength="13" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>STN</label>
                                                    <asp:TextBox ID="txtSTN" minlength="7" runat="server" CssClass="md-input"></asp:TextBox>

                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <input type="checkbox" class="radioCheck" name="filerCheck" id="c01" value="YES" onclick="check(this);" />FILER     
                                            <input type="checkbox" class="radioCheck" name="filerCheck" id="c02" value="NO" onclick="check(this);" />NON FILER
                                        </div>



                                        <div class="col-sm-9">
                                            <div class="icon-preview">
                                                <button class="btn btn-success" id="btnAddClientDetail" style="width: 92px; font-size: 12px; background-color: #096735;" value="Validate!">
                                                    <%--id="btnAddClientDetail"--%>
                                                    Next<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                                <div class="dropdown" id="drpList" runat="server" >
                                                    <button class="btn btn-primary dropdown-toggle" style="background-color: red;width: 135px;" type="button" data-toggle="dropdown">
                                                        Revert By
                                                                                         <span class="caret"></span>
                                                    </button>
                                                    <ul class="dropdown-menu" id="ddlrevert" style="width: 150px;">
                                                        <asp:CheckBoxList ID="chkRevert" runat="server" CssClass="checkboxRevrt"></asp:CheckBoxList>

                                                    </ul>
                                                </div>
                                                <div class="dropdown" runat="server" id="dropApprove">
                                                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                                                        Approved By
                                                                                    <span class="caret"></span>
                                                    </button>
                                                    <ul class="dropdown-menu" id="ApproveBind" style="width: 150px;">
                                                        <%--   OnClick="if(!confirm('Are you sure you want to Forward?'))return false;"   AutoPostBack="true" OnSelectedIndexChanged="chkApproved_SelectedIndexChanged" --%>

                                                        <%--  <input type="checkbox" id="chkApproved"  />    --%>
                                                        <%--  <asp:CheckBoxList ID="chkApproved" CssClass="checkboxRevrt" runat="server"></asp:CheckBoxList>--%>
                                                    </ul>



                                                </div>
                                                <button class="btn btn-primary dropdown-toggle" id="btnFinalize" style="display: none" type="button" data-toggle="dropdown">
                                                    Finalize
                                                                                     
                                                </button>
                                            </div>

                                        </div>




                                    </div>
                                </div>



                            </div>
                            <%----%>
                            <div class="tab-pane" id="Address">


                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">ADDRESS</label>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>ADDRESS TYPE</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlAddressType" runat="server" required="" CssClass="md-input">
                                                        <%--<asp:ListItem Value=""  Selected="" >Select Address Type</asp:ListItem>--%>
                                                        <asp:ListItem>RESIDENT / MAILING ADDRESS</asp:ListItem>
                                                        <asp:ListItem>OFFICE</asp:ListItem>
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>ADDRESS</label>
                                                    <asp:TextBox ID="txtAdress" runat="server" required="" CssClass="md-input md-input-danger"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>COUNTRY</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlCountry" required="" runat="server" CssClass="md-input">
                                                        <%-- <asp:ListItem Value="" disabled="" Selected="" hidden="">Select Country</asp:ListItem>--%>
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>CITY</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlCity" required="" runat="server" CssClass="md-input">
                                                        <%--<asp:ListItem Value="" disabled="" Selected="" hidden="">Select City</asp:ListItem>--%>
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <br />
                                <div class="row">
                                    <div class="col-sm-12">


                                        <div class="col-sm-4">
                                            <br />
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>EMAIL</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="md-input"></asp:TextBox>

                                                    <span class="md-input-bar "></span>


                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ErrorMessage="In valid email" ForeColor="Red" ControlToValidate="txtEmail"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <label>PTCL NO</label>
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper" style="display: flex;">

                                                    <asp:DropDownList ID="ddlPtclCode" Width="67px" runat="server" CssClass="md-input">
                                                        <asp:ListItem disabled="" Selected="" hidden="">Code</asp:ListItem>
                                                        <asp:ListItem>056 </asp:ListItem>
                                                        <asp:ListItem>021 </asp:ListItem>
                                                        <asp:ListItem>051 </asp:ListItem>
                                                        <asp:ListItem>042 </asp:ListItem>
                                                        <asp:ListItem>041 </asp:ListItem>
                                                        <asp:ListItem>046 </asp:ListItem>
                                                        <asp:ListItem>022 </asp:ListItem>

                                                        <asp:ListItem>071 </asp:ListItem>
                                                        <asp:ListItem>081 </asp:ListItem>
                                                        <asp:ListItem>091 </asp:ListItem>
                                                        <asp:ListItem>052 </asp:ListItem>
                                                        <asp:ListItem>0966 </asp:ListItem>
                                                        <asp:ListItem>064 </asp:ListItem>
                                                        <asp:ListItem>0606 </asp:ListItem>
                                                        <asp:ListItem>053 </asp:ListItem>
                                                        <asp:ListItem>061 </asp:ListItem>
                                                        <asp:ListItem>062 </asp:ListItem>
                                                        <asp:ListItem>068 </asp:ListItem>
                                                        <asp:ListItem>055 </asp:ListItem>
                                                        <asp:ListItem>0544 </asp:ListItem>
                                                        <asp:ListItem>0546 </asp:ListItem>
                                                        <asp:ListItem>0926 </asp:ListItem>
                                                        <asp:ListItem>048 </asp:ListItem>

                                                        <asp:ListItem>040 </asp:ListItem>
                                                        <asp:ListItem>0938 </asp:ListItem>
                                                        <asp:ListItem>049 </asp:ListItem>
                                                        <asp:ListItem>044 </asp:ListItem>
                                                        <asp:ListItem>057 </asp:ListItem>
                                                        <asp:ListItem>0316</asp:ListItem>
                                                        <asp:ListItem>0317</asp:ListItem>
                                                        <asp:ListItem>0318</asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="md-input"></asp:TextBox>

                                                    <%-- <span class="md-input-bar "></span>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <label>MOBILE NO</label>
                                            <div class="uk-width-medium uk-row-first">

                                                <div class="md-input-wrapper" style="display: flex;">


                                                    <asp:DropDownList required="" ID="ddlMobileCode" Width="67px" runat="server" CssClass="md-input">
                                                        <%--   <asp:ListItem disabled="" Selected="" hidden="">Code</asp:ListItem>--%>
                                                        <asp:ListItem>0331</asp:ListItem>
                                                        <asp:ListItem>0332</asp:ListItem>
                                                        <asp:ListItem>0333</asp:ListItem>
                                                        <asp:ListItem>0334</asp:ListItem>
                                                        <asp:ListItem>0335</asp:ListItem>
                                                        <asp:ListItem>0336</asp:ListItem>
                                                        <asp:ListItem>0337</asp:ListItem>

                                                        <asp:ListItem>0300</asp:ListItem>
                                                        <asp:ListItem>0301</asp:ListItem>
                                                        <asp:ListItem>0302</asp:ListItem>
                                                        <asp:ListItem>0303</asp:ListItem>
                                                        <asp:ListItem>0304</asp:ListItem>
                                                        <asp:ListItem>0305</asp:ListItem>
                                                        <asp:ListItem>0306</asp:ListItem>
                                                        <asp:ListItem>0307</asp:ListItem>
                                                        <asp:ListItem>0341</asp:ListItem>
                                                        <asp:ListItem>0342</asp:ListItem>
                                                        <asp:ListItem>0343</asp:ListItem>
                                                        <asp:ListItem>0344</asp:ListItem>
                                                        <asp:ListItem>0345</asp:ListItem>
                                                        <asp:ListItem>0346</asp:ListItem>
                                                        <asp:ListItem>0347</asp:ListItem>
                                                        <asp:ListItem>0348</asp:ListItem>

                                                        <asp:ListItem>0311</asp:ListItem>
                                                        <asp:ListItem>0312</asp:ListItem>
                                                        <asp:ListItem>0313</asp:ListItem>
                                                        <asp:ListItem>0314</asp:ListItem>
                                                        <asp:ListItem>0315</asp:ListItem>
                                                        <asp:ListItem>0316</asp:ListItem>
                                                        <asp:ListItem>0317</asp:ListItem>
                                                        <asp:ListItem>0318</asp:ListItem>




                                                    </asp:DropDownList>

                                                    <asp:TextBox ID="txtClientMobile" required="" minlength="7" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <%-- <span class="md-input-bar "></span>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium-1-6">

                                                <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="addAdress" href="javascript:void(0)">ADD</a>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="md-card uk-margin-medium-bottom">
                                            <div class="md-card-content">
                                                <div class="uk-overflow-container">
                                                    <table class="uk-table uk-table-striped uk-table-hover" id="tblAddress" runat="server">
                                                        <caption>Table caption</caption>
                                                        <thead>
                                                            <tr>

                                                                <th>ADDRESS TYPE</th>
                                                                <th>ADDRESS</th>
                                                                <th>COUNTRY</th>
                                                                <th>CITY</th>
                                                                <th>EMAIL</th>
                                                                <th>PTCL</th>
                                                                <th>MOBILE NO</th>
                                                                <th style="width: 1%;"></th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                         <button id="btnBackClientDet" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                            <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>

                                        <button class="btn btn-success" id="btnAddAddresss" style="width: 92px; font-size: 12px; background-color: #096735;">
                                            NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>



                                       

                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>

                            </div>

                            <%----%>
                            <div class="tab-pane" id="ContactInfo">
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">CONTACT INFO</label>
                                    </div>
                                </div>



                                <%--<div class="row">
                                    <div class="col-sm-12">
                                      <div class="col-sm-6">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>Name Of Empolyer</label>
                                                    <asp:TextBox ID="txtNameEmpolyer" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-sm-6">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>Source Of Income</label>
                                                    <asp:TextBox ID="txtSourceIncome" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div



                                    </div>
                                </div>--%>

                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>CONTACT PERSON</label>
                                                    <asp:TextBox ID="txtContactPerson" required="" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>DESIGNATION / REF</label>
                                                    <asp:TextBox ID="txtDesgRef" runat="server" required="" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <label>MOBILE NO</label>
                                            <div class="uk-width-medium uk-row-first">

                                                <div class="md-input-wrapper" style="display: flex;">


                                                    <asp:DropDownList required="" ID="ddlContactPersonMobCode" Width="67px" runat="server" CssClass="md-input">
                                                        <asp:ListItem disabled="" Selected="" hidden="">Code</asp:ListItem>
                                                        <asp:ListItem>0331</asp:ListItem>
                                                        <asp:ListItem>0332</asp:ListItem>
                                                        <asp:ListItem>0333</asp:ListItem>
                                                        <asp:ListItem>0334</asp:ListItem>
                                                        <asp:ListItem>0335</asp:ListItem>
                                                        <asp:ListItem>0336</asp:ListItem>
                                                        <asp:ListItem>0337</asp:ListItem>

                                                        <asp:ListItem>0300</asp:ListItem>
                                                        <asp:ListItem>0301</asp:ListItem>
                                                        <asp:ListItem>0302</asp:ListItem>
                                                        <asp:ListItem>0303</asp:ListItem>
                                                        <asp:ListItem>0304</asp:ListItem>
                                                        <asp:ListItem>0305</asp:ListItem>
                                                        <asp:ListItem>0306</asp:ListItem>
                                                        <asp:ListItem>0307</asp:ListItem>
                                                        <asp:ListItem>0341</asp:ListItem>
                                                        <asp:ListItem>0342</asp:ListItem>
                                                        <asp:ListItem>0343</asp:ListItem>
                                                        <asp:ListItem>0344</asp:ListItem>
                                                        <asp:ListItem>0345</asp:ListItem>
                                                        <asp:ListItem>0346</asp:ListItem>
                                                        <asp:ListItem>0347</asp:ListItem>
                                                        <asp:ListItem>0348</asp:ListItem>

                                                        <asp:ListItem>0311</asp:ListItem>
                                                        <asp:ListItem>0312</asp:ListItem>
                                                        <asp:ListItem>0313</asp:ListItem>
                                                        <asp:ListItem>0314</asp:ListItem>
                                                        <asp:ListItem>0315</asp:ListItem>
                                                        <asp:ListItem>0316</asp:ListItem>
                                                        <asp:ListItem>0317</asp:ListItem>
                                                        <asp:ListItem>0318</asp:ListItem>




                                                    </asp:DropDownList>

                                                    <asp:TextBox ID="txtContactPersonMobile" required="" minlength="7" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <%-- <span class="md-input-bar "></span>--%>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                </div>

                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">


                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>EMAIL</label>
                                                    <asp:TextBox ID="txtContactPersonEamil" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ErrorMessage="In valid email" ForeColor="Red" ControlToValidate="txtContactPersonEamil"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium-1-6">

                                                <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnContactPersonList" href="javascript:void(0)">ADD</a>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="md-card uk-margin-medium-bottom">
                                            <div class="md-card-content">
                                                <div class="uk-overflow-container">
                                                    <table class="uk-table uk-table-striped uk-table-hover" id="tblContactPerson" runat="server">

                                                        <thead>
                                                            <tr>

                                                                <th>CONTACT PERSON</th>
                                                                <th>DESIGNATION</th>
                                                                <th>MOBILE NO</th>
                                                                <th>EMAIL</th>

                                                                <th style="width: 1%;"></th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                             <button id="btnBackAddress" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddContactInfo" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                           


                                        </div>
                                        <div class="icon-preview col s6 m3">
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>
                            </div>
                            <%----%>
                            <div class="tab-pane" id="OtherDetails">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">OTHER DETAIL</label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>Reference By</label>
                                                    <asp:TextBox ID="txtReference" required="" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>BANK</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlBank" required="" CssClass="md-input" runat="server">
                                                        <%-- <asp:ListItem Value="">Select Bank</asp:ListItem>--%>
                                                        <asp:ListItem Value="1103000045">Bank AL Habib Limited</asp:ListItem>
                                                        <asp:ListItem Value="1300017576">Habib Metro Bank Ltd.</asp:ListItem>

                                                    </asp:DropDownList>

                                                    <%--<asp:ListBox ID="ddlBank" runat="server" CssClass="md-input-wrapper" SelectionMode="Multiple"></asp:ListBox>--%>
                                                    <span class="md-input-bar"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>GROUP</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlGroupName" required="" CssClass="md-input" runat="server">

                                                        <%-- <asp:ListItem Value="" disabled="" Selected="" hidden="">Select Group</asp:ListItem>--%>
                                                    </asp:DropDownList>

                                                    <span class="md-input-bar"></span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>COMPANY INDUSTRY</label>
                                                <div class="md-input-wrapper">

                                                    <asp:DropDownList ID="ddlCompIndustry" runat="server" CssClass="md-input">
                                                        <%--<asp:ListItem Value="" disabled="" Selected="" hidden="">Select Company Industry</asp:ListItem>--%>
                                                    </asp:DropDownList>

                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                            <button id="btnBackContactInfo" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddOtherDetails" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>

                            </div>
                            <%----%>
                            <div class="tab-pane" id="BusniessInfo">
                                <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>--%>

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">BUSNIESS CLASS RATE</label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">

                                            <div class="uk-width-medium uk-row-first">
                                                <label>DEPARTMENT</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlDeptment" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>--%>
                                        <div class="col-sm-4">

                                            <div class="uk-width-medium uk-row-first">
                                                <label>BUSNIESS CLASS CATEGORY</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlBusClassCat" runat="server" CssClass="md-input">

                                                        <asp:ListItem Text="CONVENTIONAL"></asp:ListItem>
                                                        <asp:ListItem Text="TAKAFUL"></asp:ListItem>
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <%--  </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>BUSNIESS CLASS</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlBusClass" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>INSURANCE TYPE</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlInsuranceType" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>EXPOSURE</label>
                                                    <asp:TextBox required="" ID="txtExposure" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>RATE</label>
                                                    <asp:TextBox required="" ID="txtRate" runat="server" CssClass="md-input"></asp:TextBox>
                                                    <span class="md-input-bar "></span>


                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--   </ContentTemplate>
                                </asp:UpdatePanel>--%>

                                <br />

                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-4">
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium-1-6">
                                                <%--  <asp:LinkButton OnClick="btnAddBusClass_Click" class="md-fab md-fab-accent md-fab-wave-light waves-effect waves-button waves-light" data-uk-tooltip="{pos:'right'}" ID="btnAddBusClass" runat="server"> <i class="material-icons"></i><i class="material-icons md-fab-action-close" style="display: none"></i></asp:LinkButton>--%>
                                                <%-- <a class="md-fab md-fab-accent md-fab-wave-light waves-effect waves-button waves-light" id="addBusClass" href="javascript:void(0)" data-uk-tooltip="{pos:'right'}">
                                                            <i class="material-icons"></i><i class="material-icons md-fab-action-close" style="display: none"></i></a>--%>
                                                <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="addBusClass" href="javascript:void(0)">ADD</a>

                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                        </div>
                                    </div>
                                </div>
                                <br />


                                <div class="row">
                                    <div class="col-sm-12">





                                        <div class="md-card uk-margin-medium-bottom">
                                            <div class="md-card-content">
                                                <div class="uk-overflow-container">

                                                    <table class="uk-table uk-table-striped uk-table-hover" id="tblBusClass" runat="server">
                                                        <caption>Table caption</caption>
                                                        <thead>
                                                            <tr>

                                                                <th>DEPARTMENT</th>
                                                                <th>BUSNIESS CLASS CATEGORY</th>
                                                                <th>BUSNIESS CLASS</th>
                                                                <th>INSURANCE TYPE</th>
                                                                <th>EXPOSURE</th>
                                                                <th>RATE</th>
                                                                <th></th>

                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                              <button id="btnBackOtherDetail" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddBusniessInfo" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                          
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>
                            </div>


                            <%-- --%>
                            <div class="tab-pane" id="AgentProducer">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">AGENT / PRODUCER</label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>DEPARTMENT</label>
                                                <div class="md-input-wrapper">

                                                    <asp:DropDownList ID="ddlAppDept" required="" CssClass="md-input" runat="server">
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>BUSNIESS CLASS CATEGORY</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlApprBusClassCat" required="" CssClass="md-input" runat="server">
                                                        <%-- <asp:ListItem Text="Select Category"></asp:ListItem>--%>
                                                        <asp:ListItem Text="CONVENTIONAL"></asp:ListItem>
                                                        <asp:ListItem Text="TAKAFUL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>BUSNIESS CLASS</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlApprBusClass" CssClass="md-input" runat="server">
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <div class="md-input-wrapper">
                                                    <label>AGENT RATE</label>
                                                    <asp:TextBox required="" ID="txtAggentRate" runat="server" CssClass="md-input"></asp:TextBox>

                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>PRODUCER</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList ID="ddlProducer" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="uk-width-medium uk-row-first">
                                                <label>AGENT</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlAgent" CssClass="md-input" runat="server">
                                                    </asp:DropDownList>
                                                    <span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                             <button id="btnBackBusniessInfo" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddAgentProducer" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                           
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>

                            </div>
                            <%--  --%>
                            <div class="tab-pane" id="Compliance">


                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <label class="clientFormMainHead">COMPLIANCE</label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-8">
                                                <div class="md-card uk-margin-medium-bottom">
                                                    <div class="md-card-content">
                                                        <div class="uk-overflow-container">

                                                            <table class="uk-table uk-table-striped uk-table-hover" id="tblRating" runat="server">

                                                                <thead>
                                                                    <tr>

                                                                        <th>RATING</th>
                                                                        <th>HIGH</th>
                                                                        <th>LOW</th>
                                                                        <th>MEDIUM</th>

                                                                    </tr>

                                                                </thead>

                                                                <tbody>
                                                                    <tr>
                                                                        <td>CUSTOMER</td>
                                                                        <td>
                                                                            <input type="checkbox" value="HIGH" class="CustomerCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="LOW" class="CustomerCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="MEDIUM" class="CustomerCheck" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>TRANSACTION</td>
                                                                        <td>
                                                                            <input type="checkbox" value="HIGH" class="TransactionCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="LOW" class="TransactionCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="MEDIUM" class="TransactionCheck" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>GEOGRAPHICAL</td>
                                                                        <td>
                                                                            <input type="checkbox" value="HIGH" class="GeographicalCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="LOW" class="GeographicalCheck" /></td>
                                                                        <td>
                                                                            <input type="checkbox" value="MEDIUM" class="GeographicalCheck" /></td>
                                                                    </tr>


                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- <asp:GridView ID="GvRating" runat="server"
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
                                                </asp:GridView>--%>
                                            </div>

                                            <div class="col-sm-4">

                                                <input type="file" multiple="multiple" id="ComplienceFileUpload" />
                                            </div>


                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="col-sm-3">
                                                    <div class="uk-width-medium uk-row-first">
                                                        <label>OWNERSHIP</label>
                                                        <div class="md-input-wrapper">
                                                            <asp:DropDownList ID="ddlOwnership" required="" runat="server" CssClass="md-input">
                                                                <%--    <asp:ListItem disabled="" Selected="">Select Ownership</asp:ListItem>--%>
                                                                <asp:ListItem>SOLE PROPRIETOR</asp:ListItem>
                                                                <asp:ListItem>PARTNERSHIP</asp:ListItem>
                                                                <asp:ListItem>PRIVATE LIMITED COMPANY</asp:ListItem>
                                                                <asp:ListItem>PUBLIC LIMITED COMPANY</asp:ListItem>
                                                                <asp:ListItem>TRUST / CLUB / NGO</asp:ListItem>

                                                            </asp:DropDownList>
                                                            <span class="md-input-bar "></span>


                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="uk-width-medium uk-row-first">
                                                        <div class="md-input-wrapper">
                                                            <label>SOURCE OF INCOME</label>
                                                            <asp:TextBox ID="txtSourceIncome" required="" runat="server" CssClass="md-input"></asp:TextBox>
                                                            <span class="md-input-bar "></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">

                                                    <input type="checkbox" class="ResidentrCheck" name="ResidentrCheck" id="Resident" value="RESIDENT" onclick="checkResident(this);" />RESIDENT   
                                            <br />
                                                    <input type="checkbox" class="ResidentrCheck" name="ResidentCheck" id="NonResident" value="NON RESIDENT" onclick="checkResident(this);" />
                                                    NON RESIDENT
                                      
                                                </div>
                                                <div class="col-sm-3">
                                                    <label>POLITICALLY EXPOSED PERSON (PEP)</label>
                                                    <br />
                                                    <input type="checkbox" id="chkPep" />
                                                    <%-- YES / NO--%>
                                                </div>


                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="uk-grid uk-grid-medium uk-grid-width-small-1-2 uk-grid-width-medium-1-3 uk-grid-width-large-1-4" id="list_gridDocComplience" style="height: 138px; overflow: scroll;">
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                              <button id="btnBackAgentProducer" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddCompliance" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                          

                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>
                            </div>
                            <%--  --%>
                            <div class="tab-pane" id="InstallmentMode">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">INSTALLMENT MODE</label>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">

                                            <div class="uk-width-medium uk-row-first">
                                                <label>DEPARTMENT</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlDept" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">

                                            <div class="uk-width-medium uk-row-first">
                                                <label>INSTALLMENT MODE</label>
                                                <div class="md-input-wrapper">
                                                    <asp:DropDownList required="" ID="ddlInstalMode" runat="server" CssClass="md-input">
                                                    </asp:DropDownList><span class="md-input-bar "></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-4">
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="uk-width-medium-1-6">

                                                <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="addInstallment" href="javascript:void(0)">ADD</a>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-sm-12">




                                        <div class="md-card uk-margin-medium-bottom">
                                            <div class="md-card-content">
                                                <div class="uk-overflow-container">
                                                    <table class="uk-table uk-table-striped uk-table-hover" id="tblInstalment" runat="server">

                                                        <thead>
                                                            <tr>
                                                                <th>DEPARTMENT</th>
                                                                <th>INSTALLMENT MODE</th>
                                                                <th></th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                             <button id="btnBackCompliance" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnAddInstallmentMode" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                           
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                </div>

                            </div>
                            <%-- --%>
                            <div class="tab-pane" id="Attachment">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">ATTACHMENTS</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">


                                        <div align="center">

                                            <div id="dZUpload" style="border-radius: 6px; height: 210px; overflow: scroll; margin: 0 auto; border-color: #6fa0a0;" class="dropzone" action="/upload">
                                                <div class="dz-default dz-message" style="margin-top: 0px;">
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    DRAG & DROP FILES HERE
                                                </div>
                                            </div>
                                            <br />
                                            <%--    <button type="button" id="btnsubmit">Save Files </button>--%>


                                            <%--   <asp:Button ID="btnsubmit" runat="server" Text="Save Files" />--%>
                                        </div>

                                    </div>
                                </div>

                                <div class="uk-grid uk-grid-medium uk-grid-width-small-1-2 uk-grid-width-medium-1-3 uk-grid-width-large-1-4" id="list_grid" style="height: 192px; overflow: scroll;">
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                             <button id="btnBackInstallmentMode" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>

                                            <button class="btn btn-success" id="btnAddAttachment" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                NEXT<i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_forward</i></button>
                                           
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                        </div>
                                    </div>
                                </div>


                            </div>

                            <div class="tab-pane" id="History">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">HISTORY</label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="uk-width-medium-1-6">

                                            <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnAttachment" href="javascript:void(0)">BACK</a>

                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="uk-width-medium-1-6">

                                            <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnNext" href="javascript:void(0)">NEXT</a>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--  --%>
                            <div class="tab-pane" id="Chat">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="clientFormMainHead">CHAT</label>
                                    </div>
                                </div>

                                <div class="uk-grid uk-grid-collapse" data-uk-grid-margin="">
                                    <div class="uk-width-large-12 uk-row-first" style="border: solid; border-color: #6fa0a0; border-radius: 8px;">
                                        <div class="md-card md-card-single">
                                            <div class="md-card-toolbar">

                                                <h3 class="md-card-toolbar-heading-text large">
                                                    <span class="uk-text-muted">Chat with</span>
                                                </h3>
                                            </div>
                                            <div class="md-card-content padding-reset">
                                                <div id="MsgContet" class="chat_box_wrapper chat_message_right" style="overflow: scroll; height: 315px;">
                                                    <div class="chat_box touchscroll chat_box_colors_a" id="chat">

                                                        <%--   <div class="chat_message_wrapper chat_message_right">
                                                    <div class="chat_user_avatar">
                                                        <img class="md-user-image" src="assets/img/avatars/avatar_03_tn.png" alt="">
                                                    </div>
                                                    <ul class="chat_message">
                                                        <li>
                                                            <p>
                                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Autem delectus distinctio dolor earum est hic id impedit ipsum minima mollitia natus nulla perspiciatis quae quasi, quis recusandae, saepe, sunt totam.
                                                        <span class="chat_message_time">13:34</span>
                                                            </p>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div class="chat_message_wrapper">
                                                    <div class="chat_user_avatar">
                                                        <img class="md-user-image" src="assets/img/avatars/avatar_11_tn.png" alt="">
                                                    </div>
                                                    <ul class="chat_message">
                                                        <li>
                                                            <p>
                                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Atque ea mollitia pariatur porro quae sed sequi sint tenetur ut veritatis.
                                                        <span class="chat_message_time">23 Jun 1:10am</span>
                                                            </p>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div class="chat_message_wrapper chat_message_right">
                                                    <div class="chat_user_avatar">
                                                        <img class="md-user-image" src="assets/img/avatars/avatar_03_tn.png" alt="">
                                                    </div>
                                                    <ul class="chat_message">
                                                        <li>
                                                            <p>Lorem ipsum dolor sit amet, consectetur. </p>
                                                        </li>
                                                        <li>
                                                            <p>
                                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                                                        <span class="chat_message_time">Friday 13:34</span>
                                                            </p>
                                                        </li>
                                                    </ul>
                                                </div>--%>
                                                    </div>
                                                    <div class="chat_submit_box" id="chat_submit_box">
                                                        <div class="uk-input-group">
                                                            <div class="md-input-wrapper md-input-filled">
                                                                <input type="text" class="md-input" name="submit_message" id="submit_message" placeholder="Send message"><span class="md-input-bar ">
                                                                </span>
                                                            </div>
                                                            <span class="uk-input-group-addon">
                                                                <a id="btnSendMsg" href="#"><i class="material-icons md-24"></i></a>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                            <button id="btnBackAttachment" class="btn btn-success" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                <i style="font-weight: bold; color: white;" class="material-icons dp48">arrow_back</i>BACK</button>
                                            <button class="btn btn-success" id="btnFinalizeclientData" style="width: 92px; font-size: 12px; background-color: #096735;">
                                                FINALIZE</button>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="icon-preview col s6 m3">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="MyTask" runat="server" class="tab-pane fade">
                <br />
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class='col-sm-4'>
                                    <input type="text" id='txtFromDate' class="datepicker" />
                                    <%--<div class="form-group">
                                        <div class='input-group date' id='datetimepickerFromDate'>
                                            <input type='text' id="txtFromDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class='col-sm-4'>
                                    <input type="text" id='txtToDate' class="datepicker" />
                                    <%--<div class="form-group">
                                        <div class='input-group date' id='datetimepickerToDate'>
                                            <input type='text' id="txtToDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="col-sm-2">
                                    <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnSearchMyTask" href="javascript:void(0)">SEARCH</a>


                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">

                            <!--<div class="table-responsive">-->
                            <table id="tblMyTask" style="overflow-x: auto;">
                                <thead>
                                    <tr>

                                        <th>CF-NO</th>
                                        <th>BRANCH</th>
                                        <th>CLIENT NAME</th>
                                        <th>CLIENT CNIC</th>
                                        <th>REQUESTED USER</th>
                                        <th>REQUESTED DATE</th>
                                        <th>ASSIGNED FORM</th>
                                        <th>ASSIGNED TO</th>

                                        <th>CLIENT TYPE </th>
                                        <th></th>

                                    </tr>
                                </thead>


                                <tbody></tbody>
                            </table>


                        </div>


                    </div>
                    <%--  <div id="menu2" runat="server" class="tab-pane fade">
            </div>--%>
                </div>
            </div>
            <div id="AssigTab" runat="server" class="tab-pane fade">
                <br />

                <div class="container-fluid">

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class='col-sm-4'>
                                    <input type="text" id='txtAssFromDate' class="datepicker" />
                                    <%--  <div class="form-group">
                                        <div class='input-group date' id='datetimepickerAssFromDate'>
                                            <input type='text' id="txtAssFromDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class='col-sm-4'>
                                    <input type="text" id='txtAssToDate' class="datepicker" />
                                    <%-- <div class="form-group">
                                        <div class='input-group date' id='datetimepickerAssToDate'>
                                            <input type='text' id="txtAssToDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="col-sm-2">
                                    <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnSearchAssTask" href="javascript:void(0)">SEARCH</a>


                                </div>


                            </div>
                        </div>
                    </div>


                    <div class="table-responsive">
                        <table id="tblAssign" class="display" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>CF-NO</th>
                                    <th>BRANCH</th>
                                    <th>CLIENT NAME</th>
                                    <th>CLIENT CNIC</th>
                                    <th>REQUESTED USER</th>
                                    <th>REQUESTED DATE</th>
                                    <th>ASSIGNED FORM</th>
                                    <th>ASSIGNED TO</th>

                                    <th>CLIENT TYPE </th>

                                    <th data-priority="0"></th>
                                </tr>
                            </thead>


                            <tbody>
                            </tbody>
                        </table>
                    </div>



                    <div class="row">
                        <div class="col-sm-12">
                            <div class="modalViewHistory fade" id="myModal" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modalViewHistory-content" style="width: 70%; margin: auto;">
                                        <div class="modalViewHistory-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modalViewHistory-title">COMMENTS HISTORY</h4>
                                        </div>
                                        <div class="modalViewHistory-body">
                                            <div style="width: 100%; padding-left: -10px;">
                                                <div class="table-responsive">
                                                    <table id="tblViewComment" class="display" style="width: 100%">
                                                        <thead>
                                                            <tr>
                                                                <th id="tblViewComment-1" data-priority="2">ID</th>
                                                                <th id="tblViewComment-2" data-priority="2">USER ID</th>
                                                                <th id="tblViewComment-3" data-priority="2">ASSIGNED TO</th>
                                                                <th id="tblViewComment-4" data-priority="3">ASSIGNED DATE</th>
                                                                <th id="tblViewComment-5" data-priority="1">COMMENTS</th>

                                                            </tr>
                                                        </thead>


                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>



                                        </div>
                                        <div class="modalViewHistory-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">CLOSE</button>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

            <div id="Finalize" runat="server" class="tab-pane fade">

                <br />

                <div class="container-fluid">


                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class='col-sm-4'>
                                    <input type="text" id='txtFinalizeFromDate' class="datepicker" />

                                </div>
                                <div class='col-sm-4'>
                                    <input type="text" id='txtFinalizeToDate' class="datepicker" />

                                </div>
                                <div class="col-sm-2">
                                    <a class="btn btn-success" style="width: 80px; font-size: 12px; background-color: #096735;" id="btnSearchFinalize" href="javascript:void(0)">SEARCH</a>


                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table id="tblFinalize" class="display" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>CF-NO</th>
                                    <th>BRANCH</th>
                                    <th>CLIENT NAME</th>
                                    <th>CLIENT CNIC</th>
                                    <th>REQUESTED USER</th>
                                    <th>REQUESTED DATE</th>
                                    <th>ASSIGNED FORM</th>
                                    <th>ASSIGNED TO</th>

                                    <th>CLIENT TYPE </th>

                                    <%-- <th data-priority="0"></th>--%>
                                </tr>
                            </thead>


                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>


        <!-- common functions -->
        <script src="assets/js/common.min.js"></script>
        <script src="assets/js/uikit_custom.min.js"></script>
        <script src="assets/js/altair_admin_common.min.js"></script>
        <script src="assets/js/kendoui_custom.min.js"></script>
        <script src="assets/js/pages/kendoui.min.js"></script>

        <script src="https://cdn.jsdelivr.net/jquery.validation/1.16.0/jquery.validate.min.js"></script>
        <script src="https://cdn.jsdelivr.net/jquery.validation/1.16.0/additional-methods.min.js"></script>

        <link href="bootstrap/css/DatatableCSS.css" rel="stylesheet" />
        <script src="bootstrap/js/DatatableJS.js"></script>
        <script src="bootstrap/js/DatePicker.js"></script>

        <script src="js/MaterilizeDatapickerJS.js"></script>
        <link href="bootstrap/css/MaterializeDatepicker.css" rel="stylesheet" />
        <script src="js/jquery.sumoselect.min.js"></script>
        <link href="css/sumoselect.css" rel="stylesheet" />
        <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>--%>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>
        <link rel="stylesheet" href="https://jqueryvalidation.org/files/demo/site-demos.css" />
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    </form>

</body>
</html>
