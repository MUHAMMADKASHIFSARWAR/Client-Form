<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientFormDetails.aspx.cs" Inherits="clientForm.clientFormDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="bootstrap/css/CP.css" rel="stylesheet" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src="signalr/hubs"></script>
    <link href="css/CP.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="Cform.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            // Declare a proxy to reference the hub.
            var chat = $.connection.chatHub;
            var globalmsg;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, message) {
                // Html encode display name and message.
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');


                var Cfid = '<%= Session["CFID"] %>';
                var comment = encodedMsg;
                var userid = encodedName;
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: 'clientFormDetails.aspx/InsertPersonRecord',
                    data: "{'Cfid':'" + Cfid + "', 'comment':'" + comment + "','userid':'" + userid + "'}",

                    success: function (data) {

                    },
                    error: function (err) {
                        console.log(err);
                    }
                });


            };
            // Get the user name and store it to prepend to messages.
            //$('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {


                    var getname = '<%= Session["USERID"] %>'

                    //chat.server.send($('#displayname').val(), $('#message').val());
                    chat.server.send(getname.toString(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();



                });

            });


            $('html,body').scrollTop(0);
            $('#sendmessageNew').click(function () {
                var message = $('#messagePopUp').val();
                var name = '<%= Session["USERID"] %>';
                var Cfid = '<%= Session["CFID"] %>';

                $('#discussionPopUp').append('<li><strong>' + name
                    + '</strong>:&nbsp;&nbsp;' + message + '</li>');
                $('#messagePopUp').val('');
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: 'clientFormDetails.aspx/InsertPersonRecord',
                    data: "{'Cfid':'" + Cfid + "', 'comment':'" + message + "','userid':'" + name + "'}",

                    success: function (data) {
                        GetTestData();
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });


            });

            GetTestData();
            $('#btnRevert').click(function () {
                //$('#btnForward').hide();
                chkboxRevert();

            });
         
            
            $('#btnForward').click(function () {

                chkboxForward();

            });
            $('#btnUpdateVerify').click(function () {

                UpdateITVerify();

            });

            $('#closePopUp').click(function () {

                var CHK = document.getElementById("<%=chkApproved.ClientID%>");
                var checkbox = CHK.getElementsByTagName("input");

                for (var i = 0; i < checkbox.length; i++) {

                    checkbox[i].checked = false;


                }

                var CHK = document.getElementById("<%=chkRevert.ClientID%>");
                var checkbox = CHK.getElementsByTagName("input");

                for (var i = 0; i < checkbox.length; i++) {

                    checkbox[i].checked = false;


                }

            });


        });


        function UpdateITVerify() {
            var data = new FormData();
            var files = $("#FileUpload1").get(0).files;

            // Add the uploaded image content to the form data collection
            if (files.length > 0) {

                for (var x = 0; x <= files.length ; x++) {
                    data.append("documents", files[x]);

                }
            }
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "api/Chat/FileAttachment",
                contentType: false,
                processData: false,
                data: data
            });

            ajaxRequest.done(function (xhr, textStatus) {

               
            });

            



    var filerValue;
    var VerisysValue;
    var CHKFiler = document.getElementById("<%=chkFiler.ClientID%>");
    var checkboxFiler = CHKFiler.getElementsByTagName("input");

    for (var i = 0; i < checkboxFiler.length; i++) {

        if (checkboxFiler[i].checked) {
            var fileType = checkboxFiler[i].value;
            filerValue = fileType;
        }


    }
    var CHK = document.getElementById("<%=chkVerisys.ClientID%>");
    var checkbox = CHK.getElementsByTagName("input");

    for (var i = 0; i < checkbox.length; i++) {

        if (checkbox[i].checked) {
            var VerisysType = checkbox[i].value;
            VerisysValue = VerisysType;
        }
        
    }
    var ajax_data = {
        filerValue: filerValue,
        VerisysValue: VerisysValue

    };
    $.ajax({
        url: "api/Chat/GetUpdateVerifyClient",

        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            $("#FileUpload1").val('');
           
            alert('Updated Successfully!');
        },
        error: function (request) {

        }
    });



};


        function GetTestData() {
            $.ajax({
                url: "api/Chat/GetComment",

                type: 'GET',
                dataType: 'json',
                success: function (data) {
                  
                    $('#discussion').empty();

                    for (var i = 0; i < data.length; i++) {

                        $('#discussion').append('<li><strong>' + data[i].USERID
                  + '</strong>:&nbsp;&nbsp;' + data[i].COMMENTS + '</li>');
                    }


                },
                error: function (request) {

                }
            });

        };

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


        function openPopup(popupmode) {
            $('#btnPopup').click();
            if (popupmode == 1) {
                $('#btnForward').hide();
                $('#btnRevert').show();
            }
            else if (popupmode == 2) {
                $('#btnForward').show();
                $('#btnRevert').hide();
            }


        }


        function chkboxRevert() {
          
            var CHK = document.getElementById("<%=chkRevert.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");

            for (var i = 0; i < checkbox.length; i++) {


                if (checkbox[i].checked) {
                    var statusid = checkbox[i].value;
                    var user = checkbox[i].parentNode.getElementsByTagName("LABEL")[0].innerHTML;
                  
                    var ajax_data = {
                        statusid: statusid,
                        AssignTouser: user

                    };
                    $.ajax({
                        url: "api/Chat/GetRevertStatus",

                        type: 'GET',
                        dataType: 'json',
                        data: ajax_data,
                        success: function (data) {
                            console.log(data);

                            alert('Successfully Revert to  ' + user)
                        },
                        error: function (request) {

                        }
                    });

                }
            }




        }
        function chkboxForward() {

            var CHK = document.getElementById("<%=chkApproved.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");

            for (var i = 0; i < checkbox.length; i++) {

                if (checkbox[i].checked) {
                    var statusid = checkbox[i].value;
                    var user = checkbox[i].parentNode.getElementsByTagName("LABEL")[0].innerHTML;
                   

                    var ajax_data = {
                        statusid: statusid,
                        AssignTouser: user

                    };
                    $.ajax({
                        url: "api/Chat/GetForwardStatus",

                        type: 'GET',
                        dataType: 'json',
                        data: ajax_data,
                        success: function (data) {
                            console.log(data);

                            alert('Successfully Forward to  ' + user)
                        },
                        error: function (request) {

                        }
                    });

                }
            }




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




    <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }

        .checkboxRevrt {
            margin-left: 10px;
        }

        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

     .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .modalPopup {
            position: fixed;
            z-index: 10002;
            border-radius: 8px;
            left: 76px;
            top: 0px;
            width: 90%;
            background-color: white;
            /* background-color: rgba(0,0,0,0.5); */
            /* border: 3px solid #0DA9D0; */
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
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="container-fluid ">
                    <div class="clientForm">



                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="wrapper">
                                        <div class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading active" role="tab">
                                                    <h4 class="panel-title">

                                                        <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px" href="#collapseOne">Client Detail</a></label>

                                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                    </h4>

                                                </div>

                                                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

                                                    <div class="panel-body">

                                                        <div class="Box">
                                                            <%--   <div id="fireDetail" runat="server" visible="false">--%>
                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>Client Name:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblClient" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>cnic:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblcnic" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>cnic Expiry:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblcnicExpiry" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>NTN:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblntn" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>GST:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblgst" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>Verify Filer Type:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVerifyFilerType" ForeColor="Green"  CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                    <h3>Verify Verisys Type:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVerifyVerisysType" ForeColor="Green" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>




                                                            <div class="row" runat="server"  id="btnITVerify"  visible="false">
                                                                <div class="col-md-12">

                                                                    <button type="button" id="btnPopupVerify" style="width: 111px; margin-left: 0px; margin-top: 11px;" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalVerify">
                                                                        Verify Client
                                                                    </button>
                                                                    <div class="modal fade" id="exampleModalVerify" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                                        <div class="modal-dialog" role="document">
                                                                            <div class="modal-content">
                                                                                <div class="modal-header">
                                                                                    <h5 class="modal-title" style="font-size: 21px; text-decoration: none; font-family: Times New Roman Times, serif; font-weight: 700; display: inline-block;" id="exampleModalLabelVerify">Verify Client</h5>
                                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                        <span aria-hidden="true">&times;</span>
                                                                                    </button>
                                                                                </div>
                                                                                <div class="modal-body">
                                                                                    <div class="row">



                                                                                        <div class="col-md-4">
                                                                                            <h3 style="font-size: 16px; text-decoration: none; font-family: Times New Roman Times, serif; display: inline-block;">Filer Type:</h3>
                                                                                            <asp:CheckBoxList runat="server" CssClass="lblAML" ID="chkFiler">
                                                                                                <asp:ListItem onclick="UncheckOthers(this);">  Filer</asp:ListItem>
                                                                                                <asp:ListItem onclick="UncheckOthers(this);">  Non Filer</asp:ListItem>
                                                                                            </asp:CheckBoxList>
                                                                                        </div>






                                                                                        <div class="col-md-4">
                                                                                            <h3 style="font-size: 16px; text-decoration: none; font-family: Times New Roman Times, serif; display: inline-block;">Verisys Type:</h3>
                                                                                            <asp:CheckBoxList runat="server" CssClass="lblAML" ID="chkVerisys">
                                                                                                <asp:ListItem onclick="UncheckOthers(this);">  Clear</asp:ListItem>
                                                                                                <asp:ListItem onclick="UncheckOthers(this);">  Not Clear</asp:ListItem>
                                                                                            </asp:CheckBoxList>
                                                                                        </div>

                                                                                        <div class="col-md-4" style=" margin-left: -19px;">

                                                                                            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                                                                                        

                                                                                        </div>

                                                                                    </div>

                                                                                </div>
                                                                                <div class="modal-footer">
                                                                                    <button type="button" id="closeVerifyPopUp" style="width: 100px" class="btn btn-secondary" data-dismiss="modal">Close</button>

                                                                                    <button type="button" id="btnUpdateVerify" style="width: 100px" class="btn btn-primary">Update</button>
                                                                                    <%-- <button type="button" id="btnForward" class="btn btn-primary">Forward</button>--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="wrapper">

                                        <div class="panel-group" id="accordion2s" role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading active" role="tab">
                                                    <h4 class="panel-title">
                                                        <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px" onclick="openTab('CBDpolicies.aspx#ExpiredPolicies');" href="CBDpolicies.aspx#ExpiredPolicies"></a></label>

                                                    </h4>
                                                    <span class="pull-right clickable" style="margin-top: -28px"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                </div>

                                                <div id="collapseTwos" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">

                                                    <div class="panel-body">
                                                        <div class="Box">
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Branch:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBranch" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Issue Date:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblissueDate" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Request Type:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblReqType" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Category:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCategory" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Potentail Exposure:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPotExposure" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Potentail Premium:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPotPrem" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Prefix:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblprefix" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Filer Type:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFiler" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>



                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="wrapper">

                                        <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading active" role="tab">
                                                    <h4 class="panel-title">
                                                        <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px" onclick="openTab('CBDpolicies.aspx#ExpiredPolicies');" href="CBDpolicies.aspx#ExpiredPolicies"></a></label>

                                                    </h4>
                                                    <span class="pull-right clickable" style="margin-top: -28px"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                </div>

                                                <div id="collapseTwo" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">

                                                    <div class="panel-body">
                                                        <div class="Box">
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Request User:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblReqUser" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Request Date:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblReqDate" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Group Name:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblGroup" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Reference By:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblRef" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Resident Type:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblResident" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Customer Rating:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCustRating" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Transaction Rating:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTransRating" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">

                                                                <div class="col-md-6">
                                                                    <h3>Geographical Rating:</h3>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblGeoRating" CssClass="Boxlabel" runat="server" Text=""></asp:Label>
                                                                </div>

                                                            </div>


                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">

                                <h1>Client Address</h1>
                                <asp:GridView ID="gvAddress" runat="server"
                                    CellPadding="4" AllowPaging="true" PageSize="10" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="table table-bordered responsive" AllowSorting="true">

                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                    <PagerSettings PageButtonCount="2" />
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
                                        <asp:BoundField DataField="PAT_ADD_TYPE_DESC" HeaderText="Address Type" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="ADDRESS" HeaderText="Address" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="PCO_DESC" HeaderText="Country" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="PCT_CITYDESC" HeaderText="City" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="ZIP_CODE" HeaderText="Zip Code" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="FAX" HeaderText="Fax" HeaderStyle-Width="288px" />
                                        <asp:BoundField DataField="EMAIL" HeaderText="Email" HeaderStyle-Width="288px" />

                                    </Columns>
                                </asp:GridView>

                                <%-- <div class="col-sm-4">
                                    <h1>Client Contact No</h1>
                                    <asp:GridView ID="gvContact" runat="server"
                                        CellPadding="4" AllowPaging="true" PageSize="10" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                        CssClass="table table-bordered responsive" AllowSorting="true">

                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                        <PagerSettings PageButtonCount="2" />
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
                                            <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No" />

                                        </Columns>
                                    </asp:GridView>
                                </div>--%>
                            </div>
                        </div>




                        <div class="row">
                            <div class="col-sm-12">


                                <h1>Contact Person Details </h1>
                                <asp:GridView ID="gvCPDetails" runat="server"
                                    CellPadding="4" AllowPaging="true" PageSize="10" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="table table-bordered responsive" AllowSorting="true">

                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                    <PagerSettings PageButtonCount="2" />
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
                                        <asp:BoundField DataField="CP_DIRECTOR_NAME" HeaderText="Contact Person Name" />
                                        <asp:BoundField DataField="CP_NUMB" HeaderText="Contact No" />
                                        <asp:BoundField DataField="CP_CNIC" HeaderText="Cnic" />
                                        <asp:BoundField DataField="CP_CNIC_EXPIRY" HeaderText="Cnic Expiry" />
                                        <asp:BoundField DataField="CP_NTN" HeaderText="Ntn" />

                                        <asp:BoundField DataField="CP_GST" HeaderText="Gst" />
                                        <asp:BoundField DataField="CP_ADDRESS" HeaderText="Address" />


                                    </Columns>
                                </asp:GridView>


                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">


                                <h1>Department Wise Rate</h1>
                                <asp:GridView ID="GvDeptRate" runat="server"
                                    CellPadding="4" AllowPaging="true" PageSize="10" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="table table-bordered responsive" AllowSorting="true">

                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                    <PagerSettings PageButtonCount="2" />
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
                                        <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" />
                                        <asp:BoundField DataField="PBC_DESC" HeaderText="Busniess Class" />
                                        <asp:BoundField DataField="INSURANCE_TYPE" HeaderText="Insurance Type" />
                                        <asp:BoundField DataField="EXPOSURE" HeaderText="Exposure" />
                                        <asp:BoundField DataField="RATE" HeaderText="Rate" />
                                        <asp:BoundField DataField="COMMISSION" HeaderText="Commission" />


                                    </Columns>
                                </asp:GridView>


                            </div>
                        </div>


                        <%--<div class="row">
                            <div class="col-sm-12">


                                <h1>Branches</h1>
                                <asp:GridView ID="gvBranches" runat="server"
                                    CellPadding="4" AllowPaging="true" PageSize="10" ForeColor="#333333" Width="100%" GridLines="None" AutoGenerateColumns="false"
                                    CssClass="table table-bordered responsive" AllowSorting="true">

                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#D9EDF7" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="HEadGrid" Height="40px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Justify" />
                                    <PagerSettings PageButtonCount="2" />
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
                                        <asp:BoundField DataField="PLC_LOCADESC" HeaderText="Branches" />

                                    </Columns>
                                </asp:GridView>


                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col-sm-12">


                                <div class="wrapper">
                                    <div class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading active" role="tab">
                                                <h4 class="panel-title">

                                                    <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px">Comments</a></label>

                                                    <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                </h4>

                                            </div>

                                            <div id="collapsechat" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

                                                <div class="panel-body" style="background-color: cornflowerblue">
                                                    <br />

                                                    <div class="Box1">
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <input type="hidden" id="displayname" />
                                                                <asp:HiddenField ID="hdnname" runat="Server" />
                                                                <ul id="discussion" style="width: 123%; height: 152px;"></ul>
                                                                <asp:HiddenField ID="hdncomment" runat="Server" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12" style="display: -webkit-box;">
                                                        <input type="text" style="width: 95%;" placeholder="Enter Comments Here..." class="form-control" id="message" />
                                                        &nbsp;
                                                                    <input type="button" style="width: 64px; height: 31px; background-color: #006400; color: white; margin: 1px 0px 0px -2px;" class="btn btn success" id="sendmessage" value="Send" />
                                                        <%-- <asp:Button ID="sendmessage"  runat="server" CssClass="btn btn success" Text="Send" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>



                            </div>
                        </div>




                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4" id="ApprovalPanel" runat="server">
                                    <div class="wrapper">
                                        <div class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading active" role="tab">
                                                    <h4 class="panel-title">

                                                        <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px">Approvals</a></label>

                                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                    </h4>

                                                </div>

                                                <div id="collapseOne1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

                                                    <div class="panel-body">
                                                        <br />
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <div class="Box1">
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div class="col-sm-4">
                                                                                <div class="dropdown" runat="server" id="dropApprove">
                                                                                    <button class="btn btn-primary dropdown-toggle" style="margin-left: 0px; width: 124px;" type="button" data-toggle="dropdown">
                                                                                        Approved By
                                                                                    <span class="caret"></span>
                                                                                    </button>
                                                                                    <ul class="dropdown-menu" id="ApproveBind">
                                                                                        <%--   OnClick="if(!confirm('Are you sure you want to Forward?'))return false;"   AutoPostBack="true" OnSelectedIndexChanged="chkApproved_SelectedIndexChanged" --%>
                                                                                        <asp:CheckBoxList ID="chkApproved" CssClass="checkboxRevrt" onclick="openPopup(2);" runat="server"></asp:CheckBoxList>

                                                                                        <%--  <asp:ListBox ID="ddlUser" runat="server" CssClass="CFform-control" SelectionMode="Multiple"></asp:ListBox>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkfawad" AutoPostBack="True" OnCheckedChanged="chkfawad_CheckedChanged" runat="server" />
                                                                                            Fawwad</li>
                                                                         s               <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chktariq" AutoPostBack="True" OnCheckedChanged="chktariq_CheckedChanged" runat="server" />
                                                                                            Tariq Awan</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkOmer" AutoPostBack="True" OnCheckedChanged="chkOmer_CheckedChanged" runat="server" />
                                                                                            Omer Zubair</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkShabir" AutoPostBack="True" OnCheckedChanged="chkShabir_CheckedChanged" runat="server" />
                                                                                            Shabir Gulam ALi</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkMurtaza" AutoPostBack="True" OnCheckedChanged="chkMurtaza_CheckedChanged" runat="server" />
                                                                                            Murtaza Hussain</li>--%>
                                                                                    </ul>


                                                                                    <%--  <li style="margin-left: 12px;">
                                                                        <input type="checkbox"  />
                                                                        Fawwad</li>
                                                                    <li style="margin-left: 12px;">
                                                                        <input type="checkbox" onclick="" />
                                                                        Tariq Awan</li>
                                                                    <li style="margin-left: 12px;">
                                                                        <input type="checkbox" />
                                                                        Omer Zubair</li>
                                                                    <li style="margin-left: 12px;">
                                                                        <input type="checkbox" />
                                                                        Shabir Gulam ALi</li>
                                                                    <li style="margin-left: 12px;">
                                                                        <input type="checkbox" />
                                                                        Murtaza Hussain</li>--%>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-sm-4">
                                                                                <div class="dropdown" id="drpList" runat="server">
                                                                                    <button class="btn btn-primary dropdown-toggle" style="width: 124px; background-color: red; margin-left: 41px;" type="button" data-toggle="dropdown">
                                                                                        Revert By
                                                                                         <span class="caret"></span>
                                                                                    </button>
                                                                                    <ul class="dropdown-menu" id="ddlrevert" style="margin-left: 40px;">
                                                                                        <asp:CheckBoxList ID="chkRevert" runat="server" CssClass="checkboxRevrt" onclick="openPopup(1);"></asp:CheckBoxList>
                                                                                        <%-- <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkFawardRevert" AutoPostBack="True" OnCheckedChanged="chkFawardRevert_CheckedChanged" runat="server" />
                                                                                            Fawwad</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chktariqRevert" AutoPostBack="True" OnCheckedChanged="chktariqRevert_CheckedChanged" runat="server" />
                                                                                            Tariq Awan</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkOmerRevert" AutoPostBack="True" OnCheckedChanged="chkOmerRevert_CheckedChanged" runat="server" />
                                                                                            Omer Zubair</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkShabirRevert" AutoPostBack="True" OnCheckedChanged="chkShabirRevert_CheckedChanged" runat="server" />
                                                                                            Shabir Gulam ALi</li>
                                                                                        <li style="margin-left: 12px;">
                                                                                            <asp:CheckBox ID="chkMurtazaRevert" AutoPostBack="True" OnCheckedChanged="chkMurtazaRevert_CheckedChanged" runat="server" />
                                                                                            Murtaza Hussain</li>--%>
                                                                                    </ul>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>



                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div class="col-sm-4">
                                                                                <div class="dropdown" id="btnFinal" runat="server">
                                                                                    <asp:Button CssClass="btn btn-primary dropdown-toggle" Style="width: 124px;" OnClientClick="if(!confirm('Are you sure you want to Finalize?'))return false;" ID="btnfanalize" runat="server" Text="Finalize" OnClick="btnfanalize_Click" />
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="dropdown" id="btnReinsuranceHide" runat="server">
                                                                                    <asp:Button CssClass="btn btn-primary dropdown-toggle" OnClientClick="if(!confirm('Are you sure you want to Forward to Re-Insurance?'))return false;" Style="width: 189px;" ID="btnReInsurance" runat="server" Text="Forward To Re-Insurance" OnClick="btnReInsurance_Click" />
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-8">

                                    <div class="wrapper">
                                        <div class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading active" role="tab">
                                                    <h4 class="panel-title">

                                                        <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px">Attachments</a></label>

                                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                    </h4>

                                                </div>

                                                <div id="collapseOneAttach" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

                                                    <div class="panel-body">
                                                        <br />
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <div class="Box1">
                                                                    <div class="row">
                                                                        <div class="col-sm-12" style="display: -webkit-inline-box;">
                                                                            <asp:ListView ID="listAttach" runat="server">
                                                                                <LayoutTemplate>
                                                                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                                                                </LayoutTemplate>
                                                                                <ItemTemplate>
                                                                                    <a id="A1" target="_blank" runat="server" style="font-size: 12px" href='<%# "~/documents/"+  Eval("ATTACHMENT_PATH")%>'>
                                                                                        <i style="font-size: 40px" class="fa fa-file" aria-hidden="true"></i>
                                                                                    </a>
                                                                                    <p style="margin-left: 0px;"><%# Eval("ATTACHMENT_PATH") %></p>



                                                                                    <%--  <asp:HyperLink runat="server" ID="hl" DataNavigateUrlFields="ATTACHMENT_PATH" Text='<%# Eval("ATTACHMENT_PATH") %>'></asp:HyperLink>--%>
                                                                                    <%-- <asp:Label ID="ResumeNameLabel" runat="server" Text="<a href='<%# Eval("ATTACHMENT_PATH") %>'</a>" />--%>
                                                                                    <%-- <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ATTACHMENT_PATH") %>' />--%>
                                                                                </ItemTemplate>
                                                                            </asp:ListView>
                                                                        </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>




                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">

                                <button type="button" id="btnPopup" style="display: none" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                                </button>
                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">Comments Section</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-sm-12">


                                                        <div class="wrapper">
                                                            <div class="panel-group">
                                                                <div class="panel panel-default">
                                                                    <div class="panel-heading active" role="tab">
                                                                        <h4 class="panel-title">

                                                                            <label for="ContentPlaceHolder1" style="color: green"><i style="color: gray" class="fa fa-file-text custom"></i><a style="margin-left: 10px">Comments</a></label>

                                                                            <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>
                                                                        </h4>

                                                                    </div>

                                                                    <div id="collapsechatPopUp" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">

                                                                        <div class="panel-body" style="background-color: cornflowerblue">
                                                                            <br />

                                                                            <%--  <div class="Box1">
                                                            <div class="row">--%>
                                                                            <div class="col-sm-12">


                                                                                <input type="hidden" id="displaynamePopUp" />
                                                                                <asp:HiddenField ID="hdnnamePopUp" runat="Server" />
                                                                                <ul id="discussionPopUp" style="width: 123%; height: 152px; margin-top: -25px; margin-left: -42px; overflow-y: overlay;"></ul>



                                                                                <asp:HiddenField ID="hdncommentPopUp" runat="Server" />
                                                                            </div>


                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-12" style="display: -webkit-box;">
                                                                                <input type="text" style="width: 86%;" placeholder="Enter Comments Here..." class="form-control" id="messagePopUp" />
                                                                                &nbsp;
                                                                    <input type="button" style="width: 71px; height: 31px; background-color: #006400; color: white; margin: 1px 0px 0px -2px;" class="btn btn success" id="sendmessageNew" value="Send" />

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <%--  </div>

                                                </div>--%>
                                                                </div>
                                                            </div>

                                                        </div>



                                                    </div>
                                                </div>

                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" id="closePopUp" class="btn btn-secondary" data-dismiss="modal">Close</button>

                                                <button type="button" id="btnRevert" class="btn btn-primary">Revert</button>
                                                <button type="button" id="btnForward" class="btn btn-primary">Forward</button>


                                            </div>
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
