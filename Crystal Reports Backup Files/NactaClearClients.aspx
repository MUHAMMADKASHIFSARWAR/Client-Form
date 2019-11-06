<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NactaClearClients.aspx.cs" Inherits="clientForm.NactaClearClients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/JavaScript.js"></script>
    <script src="js/Nacta.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="//cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <link href="bootstrap/css/datatableCss.css" rel="stylesheet" />
    <script src="js/DatatableJS.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            GetClearClient();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="background: #17a2b8; height: 55px;">
                            <h2 style="margin-top: 0px; font-size: 22px; color: white;">Clear Clients</h2>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <table id="tblNactaClearClients" class="display" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th id="tblNactaClients-1" data-priority="1">Client Name</th>
                                                    <th id="tblNactaClients-2" data-priority="1">NTN #</th>
                                                    <th id="tblNactaClients-7" data-priority="2">CNIC #</th>
                                                    <th id="tblNactaClients-3" data-priority="1">ADDRESS</th>
                                                    <th id="tblNactaClients-4" data-priority="1">REF # </th>
                                                    <th id="tblNactaClients-5" data-priority="2">IN DATE</th>
                                                    <th id="tblNactaClients-6" data-priority="2">OUT DATE</th>
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

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
