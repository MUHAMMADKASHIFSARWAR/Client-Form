<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="clientForm.ClientForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="css/form-elements.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500" />
    <link rel="shortcut icon" href="ico/favicon.png" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="ico/apple-touch-icon-144-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="ico/apple-touch-icon-114-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="ico/apple-touch-icon-72-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" href="ico/apple-touch-icon-57-precomposed.png" />


    <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="js/jquery.sumoselect.min.js"></script>
    <link href="css/sumoselect.css" rel="stylesheet" />
   <script type="text/javascript">
        $(document).ready(function () {
            $(<%=ddlBank.ClientID%>).SumoSelect();
        });
    </script>--%>


    <script type="text/javascript">

        function Pnl1OnClick(elementRef) {
            $('#pnl2').show();
            $('#pnl1').hide();
            $("#chkResNoRes :checkbox").click(function () {
                $("#chkResNoRes input:checked").attr("checked", "");
                $(this).attr("checked", "checked");
            });
        }
        //if (document.getElementById("txtReference").value == "") {
        //    document.getElementById("txtReference").style.borderColor = "Red";

        //}
        //else {
        //    document.getElementById("txtReference").style.borderColor = "white";
        //    $('#pnl2').show();
        //    $('#pnl1').hide();
        //}


        function Pnl2OnClick(elementRef) {
            $('#pnl2').hide();
            $('#pnl3').show();

        }


        function UncheckOthers(objchkbox) {
            var objchkList = objchkbox.parentNode.parentNode.parentNode;
            var chkboxControls = objchkList.getElementsByTagName("input");
            for (var i = 0; i < chkboxControls.length; i++) {
                if (chkboxControls[i] != objchkbox && objchkbox.checked) {
                    chkboxControls[i].checked = false;
                }
            }
        }



    </script>
</head>

<body>



    <form id="form1" role="form" class="registration-form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="top-content">
            <h1>New Client & Rate Approval Form </h1>

            <div class="container">

                <div class="row">
                    <div class="col-sm-6 col-sm-offset-3 form-box">

                        <%--  <form role="form" action="" method="post" class="registration-form">--%>

                        <fieldset id="pnl1">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Step 1 / 3</h3>
                                    <p>Client Identity:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-user"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Issue Date:"></asp:Label>
                                            <asp:TextBox ID="txtIssueDate" runat="server" Height="33px" Placeholder="Select Effective Date" CssClass="CFform-control"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtIssueDate" runat="server" />

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Category:"></asp:Label>
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="CFform-control">
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
                                            <asp:DropDownList ID="ddlGroupName" runat="server" CssClass="CFform-control">
                                                <asp:ListItem>Habib</asp:ListItem>
                                                <asp:ListItem>Dawood</asp:ListItem>
                                                <asp:ListItem>DH</asp:ListItem>
                                                <asp:ListItem>MH</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Prefix:"></asp:Label>
                                            <asp:DropDownList ID="ddlPrefix" runat="server" CssClass="CFform-control">
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Bank Include:"></asp:Label>
                                            <asp:DropDownList ID="ddlBank" Width="200px" runat="server" Height="33px" CssClass="CFform-control"></asp:DropDownList>

                                            <%-- <asp:ListBox ID="ddlBank" runat="server" SelectionMode="Multiple"></asp:ListBox>--%>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Reference By:"></asp:Label>
                                            <asp:TextBox ID="txtReference" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Reference "></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lbl_Name" CssClass="lbl" runat="server" Text="Client Name:"></asp:Label>
                                            <asp:TextBox ID="txtName" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Client Name"></asp:TextBox>
                                        </div>
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




                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="CNIC Expiry Date:"></asp:Label>
                                            <asp:TextBox ID="txtCIExpiry" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Cnic Expiry Date"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="txtCIExpiry" runat="server" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Fax #:"></asp:Label>
                                            <asp:TextBox ID="txtFax" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Fax"></asp:TextBox>
                                        </div>
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
                                            <asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Comment:"></asp:Label>
                                            <asp:TextBox ID="txtComment" Height="100px" runat="server" CssClass="CFform-control" placeholder="Please enter Comment"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <br />
                                            <asp:CheckBox ID="chkFiler" runat="server" />
                                            <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Filer/Non Filer:"></asp:Label>

                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:GridView ID="Gridview1" runat="server" ShowFooter="true"
                                            AutoGenerateColumns="false"
                                            OnRowCreated="Gridview1_RowCreated">
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                                                <asp:TemplateField HeaderText="Header 1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header 2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header 3">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownList1" runat="server"
                                                            AppendDataBoundItems="true">
                                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header 4">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownList2" runat="server"
                                                            AppendDataBoundItems="true">
                                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="ButtonAdd" runat="server"
                                                            Text="Add New Row"
                                                            OnClick="ButtonAdd_Click" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server"
                                                            OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">
                                            <br />
                                            <br />
                                            <button type="button" onclick="JavaScript: Pnl1OnClick();" id="btnNext" runat="server" class="btn btn-next">Next</button>
                                        </div>
                                    </div>

                                </div>
                                <br />
                                <%--<asp:Button ID="btnNext" runat="server" CssClass="button" Text="Next"  />--%>
                            </div>
                        </fieldset>

                        <fieldset id="pnl2">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Step 2 / 3</h3>
                                    <%-- <p>Set up your account:</p>--%>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-user"></i>
                                </div>
                            </div>
                            <div class="form-bottom">

                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Request Type:"></asp:Label>
                                            <asp:DropDownList ID="ddlRequestType" Height="33px" runat="server" CssClass="CFform-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Branch:"></asp:Label>
                                            <asp:DropDownList ID="ddlBranch" Height="33px" runat="server" CssClass="CFform-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label25" CssClass="lbl" runat="server" Text="Requested User:"></asp:Label>
                                            <asp:TextBox ID="txtReqUSer" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Requested User"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Potential Exposure:"></asp:Label>
                                            <asp:TextBox ID="txtExposure" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Total Exposure"></asp:TextBox>
                                        </div>
                                        <%--   <div class="col-sm-3">
                                            <asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Requested Branch:"></asp:Label>
                                            <asp:DropDownList ID="ddlReqBranch" Height="33px" runat="server" CssClass="CFform-control"></asp:DropDownList>

                                        </div>--%>
                                    </div>

                                </div>


                                <div class="row">
                                    <div class="col-sm-12">

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Potential Premium:"></asp:Label>
                                            <asp:TextBox ID="txtPotential" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Potential Premium"></asp:TextBox>
                                        </div>


                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-sm-12">
                                       
                                    </div>
                                </div>--%>
                                <br />

                                <div class="row">
                                    <div class="col-sm-12">

                                        <asp:GridView ID="gvCFDept" runat="server"
                                            CellPadding="4" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered responsive" OnRowDataBound="gvCFDept_RowDataBound" DataKeyNames="">

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
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDept" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Department" HeaderText="Department" />

                                                <asp:TemplateField HeaderText="Bussniess Class">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlBusClass" CssClass="CFform-control" runat="server">
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
                                                <asp:TemplateField HeaderText="Commission">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCommession" runat="server" Height="33px" placeholder="Please Enter Commission" CssClass="form-control"></asp:TextBox>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                    </div>


                                </div>

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
                                            <div class="col-sm-3">

                                                <asp:Label ID="Label26" CssClass="lblAML" runat="server" Text="Customer Type:"></asp:Label>
                                                <asp:DropDownList ID="ddlCustType" Width="200px" runat="server" Height="33px" CssClass="CFform-control">
                                                    <asp:ListItem>Listed</asp:ListItem>
                                                    <asp:ListItem>Individual</asp:ListItem>
                                                    <asp:ListItem>Coporate</asp:ListItem>
                                                    <asp:ListItem>Pep</asp:ListItem>

                                                </asp:DropDownList>

                                            </div>
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
                                <button type="button" class="btn btn-previous">Previous</button>
                                <button type="button" onclick="JavaScript: Pnl2OnClick();" class="btn btn-next">Next</button>
                            </div>

                        </fieldset>

                        <fieldset id="pnl3">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Step 3 / 3</h3>
                                    <p>Agent & Producer Details:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-user"></i>

                                </div>
                            </div>
                            <div class="form-bottom">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label28" CssClass="lbl" runat="server" Text="Producer Name:"></asp:Label>
                                            <asp:TextBox ID="txtProducer" Height="33px" runat="server" CssClass="CFform-control" placeholder="Please enter Producer"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Label29" CssClass="lbl" runat="server" Text="Agent Name:"></asp:Label>
                                            <asp:TextBox ID="txtAgent" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Agent"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Label ID="Label30" CssClass="lbl" runat="server" Text="Agent Rate:"></asp:Label>
                                            <asp:TextBox ID="txtAggentRate" runat="server" Height="33px" CssClass="CFform-control" placeholder="Please enter Aggent Rate"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <button type="button" class="btn btn-previous">Previous</button>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
                                <%--   <button type="submit" class="btn">Sign me up!</button>--%>
                            </div>
                        </fieldset>

                        <%-- </form>--%>
                    </div>
                </div>
            </div>


        </div>



        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.backstretch.min.js"></script>
        <script src="js/retina-1.1.0.min.js"></script>
        <script src="js/scripts.js"></script>

    </form>



</body>
</html>
