<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotationForm.aspx.cs" Inherits="clientForm.QuotationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/css/Quotation.css" rel="stylesheet" />
</head>
     <script type="text/javascript">
        $(document).ready(function () {
            getDept();
        });
</script>
<body>
    <form id="form1" runat="server">
        <div class="Quotation">
            <%--<div class="row">
                <div class="col-sm-12">
                    <h1>Quotation Form</h1>
                </div>
            </div>--%>


            <div class="panel panel-primary">
                <div class="panel-heading" style="background: #17a2b8; height: 42px;">
                    <h2 style="margin-top: 0px; font-size: 22px; color: white;">Quotation Form</h2>
                </div>
                <div class="container-fluid">
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Branch">Branch:</label>
                                        <label class="lbllabel" for="Branch">Karachi</label>
                                        <%--  <input type="email" class="form-control" id="Branch" placeholder="Enter email" name="email" />--%>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Producer">Producer Name:</label>
                                        <label class="lbllabel" for="Producer">Waqar Khan:</label>
                                        <%-- <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd" />--%>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Producer">Date:</label>
                                        <label class="lbllabel" for="Producer">21-Feb-2019</label>
                                        <%-- <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd" />--%>
                                    </div>
                                </div>



                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">
                                <h1>Client Detail</h1>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="clientName">Client Name:</label>

                                        <input type="text" class="form-control" id="clientName" placeholder="Enter Client Name" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Occupation">Occupation:</label>

                                        <input type="text" class="form-control" id="Occupation" placeholder="Enter Occupation" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Address">Client Address:</label>

                                        <input type="text" class="form-control" id="Address" placeholder="Enter Address" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Contact">Contact No:</label>

                                        <input type="text" class="form-control" id="Contact" placeholder="Enter Contact No" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Email">Email:</label>

                                        <input type="text" class="form-control" id="Email" placeholder="Enter Email" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="ReferenceBy">Reference By:</label>

                                        <input type="text" class="form-control" id="ReferenceBy" placeholder="Enter Reference By" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="TypeOfBusiness">Type Of Business:</label>

                                        <input type="text" class="form-control" id="TypeOfBusiness" placeholder="Enter Type Of Business" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <h1>Insure Detail</h1>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Department">Department:</label>
                                        <select id="ddlDept"></select>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="ReferenceBy">Bussiness Class:</label>

                                        <select id="ddlBusClass"></select>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="GrossPremium">Gross Premium:</label>
                                        <input type="text" class="form-control" id="GrossPremium" placeholder="Enter Gross Premium" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="GrossRate">Gross Rate:</label>
                                        <input type="text" class="form-control" id="GrossRate" placeholder="Enter Gross Rate" />

                                    </div>
                                </div>

                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="NetRate">Net Rate:</label>
                                        <input type="text" class="form-control" id="NetRate" placeholder="Enter Net Rate" />

                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="NetPremium">Net Premium:</label>
                                        <input type="text" class="form-control" id="NetPremium" placeholder="Enter Net Premium" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Taxes">Taxes:</label>
                                        <input type="text" class="form-control" id="Taxes" placeholder="Enter Taxes" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Deductable">Deductable:</label>
                                        <input type="text" class="form-control" id="Deductable" placeholder="Enter Deductable" />

                                    </div>
                                </div>


                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="PeriodFrom">Insure Period From:</label>
                                        <input type="date" class="form-control" id="InsurePeriodFrom" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Period">Insure Period To:</label>
                                        <input type="date" class="form-control" id="InsurePeriod" />
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Condition">Condition:</label>
                                        <input type="text" class="form-control" id="Condition" placeholder="Enter Condition" />

                                    </div>
                                </div>
                                   <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="Validity">Validity:</label>
                                        <input type="text" class="form-control" id="Validity" placeholder="Enter Validity" />

                                    </div>
                                </div>
                                   <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="LastInsure">Last Insure:</label>
                                        <input type="text" class="form-control" id="LastInsure" placeholder="Enter Last Insure" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>


    </form>
</body>
</html>
