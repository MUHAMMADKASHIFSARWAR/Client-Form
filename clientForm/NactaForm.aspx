<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NactaForm.aspx.cs" Inherits="clientForm.NactaForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/JavaScript.js"></script>
    <script src="js/Nacta.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/3/jquery.inputmask.bundle.js"></script>
    <script type="text/javascript" src="//cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <link href="bootstrap/css/datatableCss.css" rel="stylesheet" />
    <script src="js/DatatableJS.js"></script>


    <%--<link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />--%>
    <%-- <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>--%>

    <link href="bootstrap/css/DatetimePickerCss.css" rel="stylesheet" />
    <script src="js/DatetimePickerJs.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#cnic").inputmask();
            GetClient();


        });



        function getConfirmation() {
            var r = confirm("Are you sure you want to Save?");
            if (r == true) {


                AddClient();
            } else {
                GetClient();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <h2 style="text-align: center; font-weight: 700;">SECP/NACTA FORM</h2>
                    <div class="panel-group">


                        <div class="panel panel-primary">
                            <div class="panel-heading" style="background: #17a2b8; height: 55px;">
                                <h2 style="margin-top: 0px; font-size: 22px; color: white;">SECP/NACTA CLIENT</h2>
                            </div>
                            <div class="container-fluid">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-4">
                                                <label>Client Name:</label>
                                                <input type="text" class="form-control" name="ClientName" id="ClientName" placeholder="Please Enter Client Name" />
                                            </div>
                                            <div class="col-sm-4">
                                                <label>NTN #:</label>
                                                <input type="number" class="form-control"  name="Ntn" id="Ntn" />
                                            </div>
                                            <div class="col-sm-4">
                                                <label>CNIC #:</label>
                                                <input type="text" data-inputmask="'mask': '99999-9999999-9'" placeholder="XXXXX-XXXXXXX-X" class="form-control" name="cnic" id="cnic" />
                                            </div>

                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-4">
                                                <label>Address:</label>
                                                <input type="text" class="form-control" name="ClientName" id="Address" placeholder="Please Enter Address" />
                                            </div>
                                            <div class="col-sm-4">
                                                <label>Ref #:</label>
                                                <input type="text" class="form-control" name="RefNo" id="RefNo" placeholder="Please Enter Ref #" />
                                            </div>
                                            <div class="col-sm-4">
                                                <input type="submit" id="AddClient" onclick="getConfirmation();" style="margin-top: 22px; width: 173px;" class="btn btn-success" value="ADD" />
                                            </div>
                                        </div>
                                    </div>



                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h2 style="margin-top: 0px; font-size: 22px; color: #006400; font-family: 'Times New Roman'; font-weight: 600">Black List Clients:</h2>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <table id="tblNactaClients" class="display" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th id="tblNactaClients-1" data-priority="1">Client Name</th>
                                                        <th id="tblNactaClients-2" data-priority="1">NTN #</th>
                                                        <th id="tblNactaClients-7" data-priority="2">CNIC #</th>
                                                        <th id="tblNactaClients-3" data-priority="1">ADDRESS</th>
                                                        <th id="tblNactaClients-4" data-priority="1">REF # </th>
                                                        <th id="tblNactaClients-5" data-priority="2">IN DATE</th>
                                                        <th id="tblNactaClients-6" data-priority="2">OUT DATE</th>
                                                        <th data-priority="0"></th>
                                                    </tr>
                                                </thead>


                                                <tbody>
                                                </tbody>
                                            </table>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
