<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="chatClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .panl-bottom {
            margin-bottom: 30px;
            border-bottom-width: 10px;
            border-radius: 0px;
            border-bottom-color: darkseagreen;
            height: 22em;
        }

        .nostyle {
            text-decoration: none;
        }

        .table-user-information > tbody > tr > td {
            padding: 0px;
            line-height: 1.42857143;
            vertical-align: middle;
            border-top: 1px solid #ddd;
        }

        .dropzone {
            background: white;
            border-radius: 5px;
            border: 2px dashed rgb(0, 135, 247);
            border-image: none;
            max-width: 500px;
            margin-left: auto;
            margin-right: auto;
        }

        .chat {
            list-style: none;
            margin: 0;
            padding: 0;
            height: 20em;
            overflow-y: scroll;
        }



            .chat li {
                margin-bottom: 10px;
                padding-bottom: 5px;
            }

                .chat li.left .chat-body {
                    margin-left: 60px;
                    width: 50em;
                }

                .chat li.right .chat-body {
                    margin-right: 60px;
                    width: 50em;
                }

                .chat li .chat-body .after {
                    z-index: -1;
                    position: absolute;
                    right: 100%;
                    left: 50%;
                    margin-left: -10px;
                    content: '';
                    width: 0;
                    height: 0;
                    border-top: solid 10px #659EC7;
                    border-left: solid 10px transparent;
                    border-right: solid 10px transparent;
                }

                .chat li .chat-body p {
                    margin: 0;
                    color: #777777;
                    border-bottom: 1px dotted #B3A9A9;
                }

            .panel .slidedown .glyphicon, .chat .glyphicon {
                margin-right: 5px;
            }

        .chat-panel-body {
            overflow-y: scroll;
            height: 250px;
        }



        ::-webkit-scrollbar-track {
            -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
            background-color: #F5F5F5;
        }

        ::-webkit-scrollbar {
            width: 12px;
            background-color: #F5F5F5;
        }

        ::-webkit-scrollbar-thumb {
            -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.3);
            background-color: #555;
        }
    </style>
    
    <link href="css/bootstrap.css" rel="stylesheet" />

       <script src="jquery-1.7.1.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        $('#btn-chat"').on('click', function (e) {
            e.preventDefault();

            var FirstName = $('#btn-input').val();
            var comment = rightchattemplate;
            comment = comment.replace('[IH]', user_code);
            comment = comment.replace('[ChatContent]', replaceAtMentionsWithLinks($('#btn-input').val()));
            comment = comment.replace('[TS]', moment(new Date()).format('DD/MM/YYYY'));

            var ajax_data = {
                description: $('#btn-input').val(),

                doc_ref_no: global_initmationNumber

            };
            $.ajax({
                url: 'api/Remarks/InsertComment',
                type: 'POST',
                data: ajax_data,
                dataType: 'json',
                success: function (data) {


                    if (data != null && data.d != null && data.d == "SUCCESS") {



                    } else {
                        //notifyError('Saving User Detail failed!');
                    }
                },
                error: function (request) {
                    //notifyError('Saving User Detail failed!');

                }
            });

            $('.chat').append(comment);
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
                                    <button class="btn btn-success btn-sm" id="btn-chat" >
                                        Send
                                    </button>
                                </span>
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
