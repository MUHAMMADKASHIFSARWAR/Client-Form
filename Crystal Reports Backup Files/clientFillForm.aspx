<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientFillForm.aspx.cs" Inherits="clientForm.clientFillForm" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--author: W3layouts
author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Form</title>
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="css/jquery-ui.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/jquery-ui.css" rel="stylesheet" />

    <%-- <link href="//fonts.googleapis.com/css?family=Josefin+Sans:100,100i,300,300i,400,400i,600,600i,700,700i" rel="stylesheet" />--%>
    <%--<link href="//fonts.googleapis.com/css?family=PT+Sans:400,400i,700,700i" rel="stylesheet" />--%>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/ClientForm.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnAdd').click(function () {

                var table = document.getElementById("myTable");
                var row = table.insertRow(0);
                var cell1 = row.insertCell(0);
                cell1.innerHTML = $('#txtContactPerson').val();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Wizard ID="Wizard1" runat="server">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1"></asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2"></asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <h1>New Client & Rate Approval Form </h1>
                <ul class="nav nav-tabs">
                    <li width="147px" enableviewstate="true" class="active" runat="server"><a id="CBDActvPolicies" data-toggle="tab" href="#ClientForm">Client Form</a></li>
                    <li width="147px" enableviewstate="true" runat="server"><a id="ExpiredPolicies" data-toggle="tab" onclick="JavaScript: ClaimOnClick();" href="#ClientFormList">Aproval List</a></li>
                    <%--   <li width="147px" enableviewstate="true" runat="server"><a id="RequestStatus" data-toggle="tab" onclick="JavaScript: buttonOnClick();" href="#menu2">Request Status</a></li>--%>
                </ul>

                <div class="tab-content">
                    <div id="ClientForm" class="tab-pane fade in active">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="ClientFormStyle">

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Issue Date:"></asp:Label>
                                                <asp:TextBox ID="txtIssueDate" runat="server" Placeholder="Select Effective Date" CssClass="CFform-control"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtIssueDate" runat="server" />

                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Request Type:"></asp:Label>
                                                <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="CFform-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Branch:"></asp:Label>
                                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="CFform-control"></asp:DropDownList>
                                            </div>
                                            <%--    <div class="col-sm-3">
                        <asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Request User:"></asp:Label>
                        <asp:TextBox ID="txtReqUser" runat="server" CssClass="CFform-control" placeholder="Please Enter Requested User"></asp:TextBox>
                    </div>--%>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Requested Branch:"></asp:Label>
                                                <asp:DropDownList ID="ddlReqBranch" runat="server" CssClass="CFform-control"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Total Exposure:"></asp:Label>
                                                <asp:TextBox ID="txtExposure" runat="server" CssClass="CFform-control" placeholder="Please enter Total Exposure"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Potential Premium:"></asp:Label>
                                                <asp:TextBox ID="txtPotential" runat="server" CssClass="CFform-control" placeholder="Please enter Potential Premium"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <br />
                                            <h2>Client Particulars</h2>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Category:"></asp:Label>
                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="CFform-control">
                                                    <asp:ListItem>Corporate</asp:ListItem>
                                                    <asp:ListItem>Group</asp:ListItem>
                                                    <asp:ListItem>Individual</asp:ListItem>
                                                    <asp:ListItem>Maket</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-sm-3">
                                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Prefix:"></asp:Label>
                                                <asp:DropDownList ID="ddlPrefix" runat="server" CssClass="CFform-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lbl_Name" CssClass="lbl" runat="server" Text="Client Name:"></asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="CFform-control" placeholder="Please enter Client Name"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Address:"></asp:Label>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="CFform-control" placeholder="Please enter Address"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <br />
                                            <h2>Client Identity</h2>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="CNIC #:"></asp:Label>
                                                <asp:TextBox ID="txtNic" runat="server" CssClass="CFform-control" placeholder="Please enter CNIC"></asp:TextBox>

                                            </div>

                                            <div class="col-sm-3">
                                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="NTN #:"></asp:Label>
                                                <asp:TextBox ID="txtNTN" runat="server" CssClass="CFform-control" placeholder="Please enter NTN"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="GST #:"></asp:Label>
                                                <asp:TextBox ID="txtGST" runat="server" CssClass="CFform-control" placeholder="Please enter GST"></asp:TextBox>

                                            </div>

                                            <div class="col-sm-3">
                                                <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="CNIC Expiry Date:"></asp:Label>
                                                <asp:TextBox ID="txtCIExpiry" runat="server" CssClass="CFform-control" placeholder="Please enter Cnic Expiry Date"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="txtCIExpiry" runat="server" />
                                            </div>

                                            <div class="col-sm-3">
                                                <br />
                                                <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Filer/Non Filer:"></asp:Label>
                                                <asp:CheckBox ID="chkFiler" runat="server" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-sm-12">
                                            <br />
                                            <h2>Contact Details</h2>

                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label22" CssClass="lbl" runat="server" Text="Contact Persons:"></asp:Label>
                                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="CFform-control" placeholder="Please enter Contact Person Name"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Phone #:"></asp:Label>
                                                <asp:TextBox ID="txtPhone" runat="server" CssClass="CFform-control" placeholder="Please enter Phone"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label23" CssClass="lbl" runat="server" Text="Cnic:"></asp:Label>
                                                <asp:TextBox ID="txtContactCnic" runat="server" CssClass="CFform-control" placeholder="Please enter Cnic"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Fax #:"></asp:Label>
                                                <asp:TextBox ID="txtFax" runat="server" CssClass="CFform-control" placeholder="Please enter Fax"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <table id="myTable">
                                    </table>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label24" CssClass="lbl" runat="server" Text="CNIC Expiry Date:"></asp:Label>
                                                <asp:TextBox ID="txtCnicExpiry" runat="server" CssClass="CFform-control" placeholder="Please enter Cnic Expiry Date"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MMM/yyyy" TargetControlID="txtCnicExpiry" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <br />
                                            <h2>Agent & Producer Details</h2>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Producer Name:"></asp:Label>
                                                <asp:TextBox ID="txtProducer" runat="server" CssClass="CFform-control" placeholder="Please enter Producer"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Agent Name:"></asp:Label>
                                                <asp:TextBox ID="txtAgent" runat="server" CssClass="CFform-control" placeholder="Please enter Agent"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-3">
                                                <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Agent Rate:"></asp:Label>
                                                <asp:TextBox ID="txtAggentRate" runat="server" CssClass="CFform-control" placeholder="Please enter Aggent Rate"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <br />

                                                <asp:FileUpload runat="server" ID="fileUplaod" />
                                            </div>
                                        </div>
                                    </div>



                                    <%--<div class="row">
                <div class="col-sm-12">

                    <div class="col-sm-3">
                        <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Department:"></asp:Label>
                        <asp:DropDownList ID="ddlDepartment" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="CFform-control"></asp:DropDownList>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Business Class:"></asp:Label>
                        <asp:DropDownList ID="ddlBussniessClass" runat="server" CssClass="CFform-control"></asp:DropDownList>
                    </div>
                    <div class="col-sm-3">

                        <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Insurance Type:"></asp:Label>
                        <asp:DropDownList ID="ddlInsuranceType" runat="server" CssClass="CFform-control"></asp:DropDownList>
                    </div>

                </div>
            </div>--%>

                                    <%--<div class="row">
                <div class="col-sm-12">


                    <div class="col-sm-3">
                        <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Effective Date:"></asp:Label>
                        <asp:TextBox ID="txtEffectiveDate" runat="server" Placeholder="Select Effective Date" CssClass="CFform-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="txtEffectiveDate" runat="server" />

                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Company Industries:"></asp:Label>
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="CFform-control"></asp:DropDownList>

                    </div>
                    <div class="col-sm-3">
                    </div>

                </div>
            </div>--%>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btn">
                                                <asp:Label ID="lblMessage" Text="" runat="server"></asp:Label>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                                            </div>
                                        </div>
                                    </div>


                                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                </div>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                    <div id="ClientFormList" class="tab-pane fade in active">

                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>



                    <footer>
                        <a>&copy; 2018 HICL  Registration Form. All Rights Reserved |</a>
                    </footer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
