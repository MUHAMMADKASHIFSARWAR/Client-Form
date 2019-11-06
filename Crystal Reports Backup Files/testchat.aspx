<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testchat.aspx.cs" Inherits="clientForm.testchat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <script src="jquery-1.7.1.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <a href="font-awesome/fonts/fontawesome-webfont.ttf">font-awesome/fonts/fontawesome-webfont.ttf</a>

    <script type="text/javascript">
        
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <br />
        <div class="col-md-8">
            <div class="panel panel-default panl-bottom">
                <div class="row">
                    <div class="col-sm-12" style="border-right: 1px solid #ccc;">
                        <div class="panel-heading pull-left">

                            <h4 class="panel-title">
                                <a data-toggle="collapse" id="linkClaimRemarks" style="text-decoration: none" class="nostyle" data-parent="#accordion">
                                    <span>
                                      
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </span><strong>Remarks</strong>

                                </a>

                            </h4>
                        </div>

                    </div>


                </div>
                <div class="panel-collapse" style="display: block">
                    <div class="panel-body">
                        <div id="claimRemarksBody">

                            <ul class="chat tbl-claim-details" style="height: 15em">
                            </ul>
                        </div>

                        <div class="panel-footer" id="chatfooter">
                            <div class="input-group">
                                <input id="btn-input" type="text" class="form-control input-sm" placeholder="Type your message here..." />
                                <span class="input-group-btn">
                                    <input type="button" id="btn-chat" value="Send" class="btn btn-success" onclick="ImageHosting_Click()"/> 
                                  <%--  <button class="btn btn-success btn-sm" id="btn-chat" >
                                        Send
                                    </button>--%>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
