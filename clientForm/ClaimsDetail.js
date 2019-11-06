var tablevarhist;
var endorementType = '';
var tablevarposting;
var tablevarrevision;
var tablevarendorsement;
var global_assignedTo = '';
var global_intimationFinalized = '';
var global_amount;
var global_currentUserAmount;
function getEndorsementData(ajax_data, Heading_label) {
    $.ajax({
        url: "api/Claim/GetEndorsements",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {

            for (var i = 0; i < data.length; i++) {
                if (data[i].GDH_ISSUEDATE !=null)
                data[i].GDH_ISSUEDATE = moment(data[i].GDH_ISSUEDATE).format('DD/MM/YYYY');
                if (data[i].GDH_POSTING_DATE !=null)
                data[i].GDH_POSTING_DATE = moment(data[i].GDH_POSTING_DATE).format('DD/MM/YYYY');
                if (data[i].GDH_GROSSPREMIUM != null)
                    data[i].GDH_GROSSPREMIUM = numberWithCommas(data[i].GDH_GROSSPREMIUM);
                if (data[i].PAIDLOSS != null)
                    data[i].PAIDLOSS = numberWithCommas(data[i].PAIDLOSS);
                if (data[i].INTILOSS != null) {
                    data[i].INTILOSS = numberWithCommas(data[i].INTILOSS);
                }
            }


            $('#PostingEndorsementHistory').modal('show');
            if ($.fn.dataTable.isDataTable('#tblEndorsementHistory')) {
                tablevarendorsement = $('#tblEndorsementHistory').DataTable().clear().destroy();
            }
            
            tablevarendorsement = $('#tblEndorsementHistory').dataTable({

                responsive: true,
                data: data,

                "columns": [
                    //SETTLEMENTREFNO
                    {"data" : "GDH_SEQNO"},
                    { "data": "GDH_DOC_REFERENCE_NO" },
                    { "data": "GDH_GROSSPREMIUM" },
                    { "data": "GDH_ISSUEDATE" },
                    { "data": "ADT_CREATEUSER" },
                    { "data": "GDH_ISSUEDATE" },
                    { "data": "GDH_POST_USER" },
                    { "data": "GDH_POSTING_DATE" }
               


                ],
                responsive: {
                    details: {
                        display: $.fn.dataTable.Responsive.display.modal({
                            header: function (row) {

                                var data = row.data();

                                return 'Comments Detail';
                            }
                        }),
                        renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                            tableClass: 'table'
                        })
                    }
                },
            })

            //tblPolicyHistory
        },
        error: function (data) { }

    });
}
function getIntimationsData(ajax_data, Heading_label) {
    $.ajax({
        url: "api/Claim/GetPostingsEntryNo",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            for (var i = 0; i < data.length; i++) {
                if (data[i].GSH_SETTLEMENTDATE != null)
                    data[i].GSH_SETTLEMENTDATE = moment(data[i].GSH_SETTLEMENTDATE).format('DD/MM/YYYY');
                if (data[i].GIH_POST_DATE != null)
                    data[i].GIH_POST_DATE = moment(data[i].GIH_POST_DATE).format('DD/MM/YYYY');
                if (data[i].GIH_LOSSCLAIMED != null)
                    data[i].GIH_LOSSCLAIMED = numberWithCommas(data[i].GIH_LOSSCLAIMED);
                if (data[i].PAIDLOSS != null)
                    data[i].PAIDLOSS = numberWithCommas(data[i].PAIDLOSS);
                if (data[i].INTILOSS != null) {
                    data[i].INTILOSS = numberWithCommas(data[i].INTILOSS);
                }
            }

            $('#PostingIntimationHistory').modal('show');
            if ($.fn.dataTable.isDataTable('#tblPostingIntimationHistory')) {
                tablevarposting = $('#tblPostingIntimationHistory').DataTable().clear().destroy();
            }

            tablevarposting = $('#tblPostingIntimationHistory').dataTable({

                responsive: true,
                data: data,

                "columns": [
                    //SETTLEMENTREFNO
                    { "data": "GIH_INTI_ENTRYNO" },
                    { "data": "GIH_DOC_REF_NO" },
                    { "data": "GIH_INTI_ENTRYNO" },
                    { "data": "GIH_LOSSCLAIMED" },
                    { "data": "GIH_POSTINGTAG" },
                    { "data": "GIH_CLAIMREVISE" },
                    { "data": "GIH_FULLFINAL_TAG" },
                    { "data": "GIH_CREATEUSER" },
                    { "data": "GIH_CREATEDATE" },
                    { "data": "GIH_POST_USER" },
                    { "data": "GIH_POST_DATE" }



                ],
                responsive: {
                    details: {
                        display: $.fn.dataTable.Responsive.display.modal({
                            header: function (row) {

                                var data = row.data();

                                return 'Comments Detail';
                            }
                        }),
                        renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                            tableClass: 'table'
                        })
                    }
                },
            })


           

            //tblPolicyHistory
        },
        error: function (data) { }

    });
}
function getSettlementData(ajax_data, Heading_label) {
    $.ajax({
        url: "api/Claim/GetBySettlements",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            for (var i = 0; i < data.length; i++) {
                if (data[i].GSH_CREATEDATE != null)
                    data[i].GSH_CREATEDATE = moment(data[i].GSH_CREATEDATE).format('DD/MM/YYYY');
                if (data[i].GSH_POSTING_DATE != null)
                    data[i].GSH_POSTING_DATE = moment(data[i].GSH_POSTING_DATE).format('DD/MM/YYYY');
                if (data[i].GIH_LOSSCLAIMED != null)
                    data[i].GIH_LOSSCLAIMED = numberWithCommas(data[i].GIH_LOSSCLAIMED);
                if (data[i].PAIDLOSS != null)
                    data[i].PAIDLOSS = numberWithCommas(data[i].PAIDLOSS);
                if (data[i].INTILOSS != null) {
                    data[i].INTILOSS = numberWithCommas(data[i].INTILOSS);
                }
            }


           
            $('#PostingSettlementHistory').modal('show');
            if ($.fn.dataTable.isDataTable('#tblSettlementHistory')) {
                tablevarrevision = $('#tblSettlementHistory').DataTable().clear().destroy();
            }

            tablevarrevision = $('#tblSettlementHistory').dataTable({

                responsive: true,
                data: data,

                "columns": [
                    //SETTLEMENTREFNO
                     { "data": "GIH_INTI_ENTRYNO" },
                    { "data": "GSH_DOC_REF_NO" },
                    { "data": "GIH_INTI_ENTRYNO" },
                    { "data": "GSH_ENTRYNO" },
                    { "data": "GSH_SETTLEMENTDATE" },
                    { "data": "GSH_CREATEUSER" },
                    { "data": "GSH_CREATEDATE" },
                    { "data": "GSH_POST_USER" },
                    { "data": "GSH_POSTING_DATE" }


                ],
                responsive: {
                    details: {
                        display: $.fn.dataTable.Responsive.display.modal({
                            header: function (row) {

                                var data = row.data();

                                return 'Comments Detail';
                            }
                        }),
                        renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                            tableClass: 'table'
                        })
                    }
                },
            })
            //tblPolicyHistory
        },
        error: function (data) { }

    });
}
function getHistoryData(ajax_data, Heading_label) {
    $.ajax({
        url: "api/Claim/GetPolicyHistoryByChasisNumber",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            
            for (var i = 0; i < data.length; i++) {
                data[i].INTI_DATE = moment(data[i].INTI_DATE).format('DD/MM/YYYY');
                data[i].DATEOFLOSS = moment(data[i].DATEOFLOSS).format('DD/MM/YYYY');
                if (data[i].ESTI_LOSS != null)
                data[i].ESTI_LOSS = numberWithCommas(data[i].ESTI_LOSS);
                if (data[i].PAIDLOSS!=null)
                data[i].PAIDLOSS = numberWithCommas(data[i].PAIDLOSS);
                if (data[i].INTILOSS != null) {
                    data[i].INTILOSS = numberWithCommas(data[i].INTILOSS);
                }
            }

           
            $('#PolicyHistory').modal('show');
            if ($.fn.dataTable.isDataTable('#tblPolicyHistory')) {
                tablevarhist = $('#tblPolicyHistory').DataTable().clear().destroy();
            }
            $('#lblHistory').html(Heading_label);
            tablevarhist = $('#tblPolicyHistory').dataTable({
                
                responsive: true,
                data: data,

                "columns": [
                    //SETTLEMENTREFNO
                    { "data": "CALIMREFNO" },
                    { "data": "DOCNO" },
                    {"data": "CLIENT"},
                    {"data": "PDP_DESC"},
                    {"data": "PBC_DESC"},
                   // {"data" : ""}
                    { "data": "INTI_DATE" },
                    { "data": "INTILOSS" },
                    { "data": "ESTI_LOSS" },
                    { "data": "DATEOFLOSS" },
                    { "data": "PAIDLOSS" }


                ],
                responsive: {
                details: {
                        display: $.fn.dataTable.Responsive.display.modal( {
                            header: function (row) {
                        
                                var data = row.data();

                                return 'Comments Detail';
                            }
                        } ),
                        renderer: $.fn.dataTable.Responsive.renderer.tableAll( {
                            tableClass: 'table'
                        } )
                }
            },
            })

            //tblPolicyHistory
        },
        error: function (data) { }

    });
}
var globalInitEntyNo = '';
function ViewReport(doc_ref_no, Entry_no) {
    event.preventDefault();
    var localreport = '';
  
    localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cclaimno,''[Doc_Name]'';_q_cSET_ENTRYNO,''[Entry_No]'';_q_cPayTag,''Y'';&_ShowPDF=T&_RepName=performa_settlement";
    localreport = localreport.replace('[Doc_Name]', global_initmationNumber);
    localreport = localreport.replace('[Entry_No]', Entry_no);
    //  localreport = encodeURI(localreport);
    console.log(localreport)
    var win = window.open(localreport, '_blank');

    win.focus();
}
function checkEndorements() {
    var ajax_data ={
        PolicyNumber: global_baseDocNumber
    }
    
    $.ajax({
        url: "api/Claim/GetEndorements",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data)
            if (data.length > 0) {
                endorementType = data[0].ENDOREMENTCOUNT;
            }
        },
        error: function (data) { }
    });
}
function replaceAtMentionsWithLinks(text) {
    return text.replace(/@([a-z\d_]+)/ig, '<span class="primary">@$1</span>');
}
function getRemarks() {
    
        var ajax_data = {
            doc_ref_no: global_initmationNumber

        };
        $.ajax({
            url: "api/Claim/GetRemarks",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                console.log(data);
                for (var i = 0; i < data.length; i++) {
                    var comment = leftchattemplate;
                    if (data[i].USERIDX == user_code) {
                        comment = rightchattemplate;
                    }
                    comment = comment.replace('[IH]', data[i].USERIDX);
                    comment = comment.replace('[ChatContent]', replaceAtMentionsWithLinks(data[i].DESCRIPTION));
                    comment = comment.replace('[TS]', moment(data[i].DATETIME).format('DD/MM/YYYY'));
                    $('.chat').append(comment);
                }


                if (data != null && data.d != null && data.d == "SUCCESS") {

                } else {
                    //notifyError('Saving User Detail failed!');
                }
            },
            error: function (request) {
                //notifyError('Saving User Detail failed!');

            }
        });

    

}

function GetClaimFinalized() {

    var ajax_data = {
        doc_ref_no: global_initmationNumber

    };
    $.ajax({
        url: "api/Claim/GetDocumentsFinalized",
        data: ajax_data,
        
        dataType: 'json',       
        success: function (data) {
            $('#tblSettlementApprovals').show();
            $('#approvalpanel').show();
            if (data.length > 0  ) {
                $('#chcklst-container').hide();               
                $('#approvalpanel').show();
                $('#tblDocumenations').show();
                
            }
            else if ( isPLRExists()){
                $('#chcklst-container').hide();
            }
            else {
                $('#chcklst-container').show();
                $('#approvalpanel').hide();
                $('#tblDocumenations').hide();
                $('#tblSettlementApprovals').hide();
            }
        }
    });
}

function isPLRExists() {
    console.log($('.docrows'));
    
    $('.Docname').each(function () {
        var title = $(this).html();
        if (title.indexOf('Preliminary Loss Report (if applicable)') >= 0) {
            return true;
        }
    })
    return false;

}

function applyReadyOnly() {
    if (global_readonly == true) {
    
        $('#tblDocumenations').find('input, textarea, select, a, button').attr("disabled", true);
        $('#tblSettlementApprovals').find('input, textarea, select, a, button').attr("disabled", true);
    }

}

$('#detailbody').ready(function () {
        applyReadyOnly()
    
        getUsers();
        $('#btnProceedSettlement').hide();
    $('#documentUpload').on('click', function (evt) {
        evt.preventDefault();
        $("#uploadModal").modal('show');
        $("#uploadModal").on("shown.bs.modal", function () {
            $('.modal-backdrop').hide();
        });
    })
    
    $('.modal').on('shown.bs.modal', function () {
        $('.modal-backdrop').hide();
    });

    isPLRExists();
    $('#tblSettlementApprovals').show();
    if (user_type == 'USER') {
       // $('#tabSettlement').hide();
        $('#btnFinalizedDocument').show();
    }
    else {
        $('#tabSettlement').show();
        //$('#btnFinalizedDocument').hide();
    }
    $('#btnFinalizedDocument').on('click', function () {
        approveClaim(user_code, 125, 100, user_code)
    })
    $('#approvalpanel').show();
    $('#tblDocumenations').show();
    $('#btnFinalizeSettlements').on('click', function (e) {
        e.preventDefault();
        approveSettlement(user_code, 50, 10, user_code);
    });
    $('#btn-chat').on('click', function (e) {
      
        e.preventDefault();
        var comment = rightchattemplate;
        comment = comment.replace('[IH]', user_code);
        comment = comment.replace('[ChatContent]', replaceAtMentionsWithLinks($('#btn-input').val()));
        comment = comment.replace('[TS]', moment(new Date()).format('DD/MM/YYYY'));

        var ajax_data = {
            description: $('#btn-input').val(),
          
            doc_ref_no: global_initmationNumber

        };
        $.ajax({
            url: "api/Claim/InsertComment",
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
    })
  
    getRemarks();
    if (typeof Element.prototype.addEventListener === 'undefined') {
        Element.prototype.addEventListener = function (e, callback) {
            e = 'on' + e;
            return this.attachEvent(e, callback);
        };
    }

    $('#linkClaimStatus').on('click', function (e) {
        $('#claimRemarksBody').hide();
        $('#chatfooter').hide();
        $('#claimStatusBody').show();
    });
   

    $('#btnFinalize').on('click', function (e) {
        e.preventDefault();

        $('#approvalpanel').show();
        $('#tblDocumenations').show();
        $('#tblSettlementApprovals').show();
        return;



    });

    //btnFinalizeInimation
    $('#btnProceedSettlement').on('click', function (e) {
        if (global_intimationFinalized != 100) {
            notifyError('claim cannot be moved to approval process without finalizing intimation');
        }
        e.preventDefault();
        var ajax_data = {
            Doc_Ref_No: global_initmationNumber,
            Reviewer_Id: ' ',

            Approval_Status: 110,
            next_approval: ''

        };

        var _self = this;
        $.ajax({
            url: "api/Reviewer/ApproveSettlements",
            data: ajax_data,
            type: 'POST',
            dataType: 'json',

            success: function (data) {
                notifyError('claim moved to approval process');
                $('#btnProceedSettlement').attr('disabled', 'disabled');
            },
            error: function (request) {

            }
        });

    });
    $('#btnFinalizeInimation').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            Doc_Ref_No: global_initmationNumber,
            Reviewer_Id: ' ',

            Approval_Status: 100,
            next_approval: ''

        };

        var _self = this;
        $.ajax({
            url: "api/Reviewer/FinalizeClaims",
            data: ajax_data,
            type: 'POST',
            dataType: 'json',

            success: function (data) {
                notifyError('check by proccess has been finalized ');
                $('#btnFinalizeInimation').attr('disabled', 'disabled');
            },
            error: function (request) {

            }
        });

    });
    $('#btnFinalizeInimation').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            Doc_Ref_No: global_initmationNumber,
            Reviewer_Id: ' ',

            Approval_Status: 100,
            next_approval: ''

        };

        var _self = this;
        $.ajax({
            url: "api/Reviewer/FinalizeClaims",
            data: ajax_data,
            type: 'POST',
            dataType: 'json',

            success: function (data) {
                notifyError('check by proccess has been finalized ');
                $('#btnFinalizeInimation').attr('disabled', 'disabled');
            },
            error: function (request) {

            }
        });

    });
    $('#linkClaimRemarks').on('click', function (e) {
        $('#claimRemarksBody').show();
        $('#chatfooter').show();
        $('#claimStatusBody').hide();
        var at_config = {
            at: "@",
            data: global_chatUsers,
            limit: 10
        }
        $('#btn-input').atwho(at_config);
    });

    $('#PolicyReport1').on('click', function (e) {
        var localreport ='';
        if (endorementType == 'C') {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,%27%27[Doc_Name]%27%27;_q_cDocDesc,%27%27N%27%27;_q_cPerilTag,%27%27N%27%27;&_ShowPDF=T&_RepName=GeneralSchedule_C";
        }
        else {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,%27%27[Doc_Name]%27%27;_q_cDocDesc,%27%27N%27%27;_q_cPerilTag,%27%27N%27%27;&_ShowPDF=T&_RepName=GeneralSchedule";
        }
         localreport = localreport.replace('[Doc_Name]', global_initmationNumber);
        
      //  localreport = encodeURI(localreport);
        console.log(localreport)
        var win = window.open(localreport, '_blank');
        win.focus();



    });
    $('#PolicyReport2').on('click', function (e) {
        var localreport = '';
        if (endorementType == 'C') {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,%27%27[Doc_Name]%27%27;_q_cDocDesc,%27%27N%27%27;_q_cPerilTag,%27%27N%27%27;&_ShowPDF=T&_RepName=GeneralSchedule_C";
        }
        else {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,%27%27[Doc_Name]%27%27;_q_cDocDesc,%27%27N%27%27;_q_cPerilTag,%27%27N%27%27;&_ShowPDF=T&_RepName=GeneralSchedule";
        }
        localreport = localreport.replace('[Doc_Name]', global_baseDocNumber);
        //  localreport = encodeURI(localreport);
        console.log(localreport)
        var win = window.open(localreport, '_blank');
        win.focus();



    });
    $('#PolicyReport3').on('click', function (e) {
        var localreport = '';
        if (endorementType == 'C') {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,''[Doc_Name]'';_q_cDocDesc,''N'';&_ShowPDF=T&_RepName=Motor_Certificate_C";
        }
        else {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,''[Doc_Name]'';_q_cDocDesc,''N'';&_ShowPDF=T&_RepName=Motor_Certificate";
        }
        localreport = localreport.replace('[Doc_Name]', global_baseDocNumber);
        //  localreport = encodeURI(localreport);
        console.log(localreport)
        var win = window.open(localreport, '_blank');
        win.focus();



    });
    $('#PolicyReport4').on('click', function (e) {
        var localreport = '';
        if (endorementType == 'C') {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,''[Doc_Name]'';_q_cDocDesc,''N'';&_ShowPDF=T&_RepName=mt_ItemSchedule-Motor_C";
        }
        else {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cDocumentNo,''[Doc_Name]'';_q_cDocDesc,''N'';&_ShowPDF=T&_RepName=mt_ItemSchedule-Motor";
        }
        localreport = localreport.replace('[Doc_Name]', global_baseDocNumber);
        //  localreport = encodeURI(localreport);
        console.log(localreport)
        var win = window.open(localreport, '_blank');
        win.focus();



    });
    //PefromaReport
    $('#PefromaReport').on('click', function (e) {
        var localreport = '';
        if (endorementType == 'C') {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cclaimno,%27%27[Doc_Name]%27%27;_q_cINTI_ENTRYNO,%27%27[Entry_No]%27%27;&_RepName=performa_intimation";
        }
        else {
            localreport = "http://192.168.20.24:8080/LiveCReports/report-viewer.jsp?_ParamStr=_q_cclaimno,%27%27[Doc_Name]%27%27;_q_cINTI_ENTRYNO,%27%27[Entry_No]%27%27;&_RepName=performa_intimation";
        }
        localreport = localreport.replace('[Doc_Name]', global_initmationNumber);
        localreport = localreport.replace('[Entry_No]', globalInitEntyNo);
        //  localreport = encodeURI(localreport);
        console.log(localreport)
        var win = window.open(localreport, '_blank');

        win.focus();



    });
    $('#History1').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            chasisNumber: 'All',
            PartyCode : 'All',
           PolicyNumber : global_baseDocNumber

        };
        getHistoryData(ajax_data, 'Policy History');
        console.log(ajax_data)
       
    });
    $('#History2').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            chasisNumber: globalChasisNo,
            PartyCode: 'All',
            PolicyNumber: 'All'

        };
        getHistoryData(ajax_data, 'Loss History');
        console.log(ajax_data)

    });
    $('#History3').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            chasisNumber: 'All',
            PartyCode: global_partyCode,
            PolicyNumber: 'All'

        };
        getHistoryData(ajax_data, 'Client History');
        console.log(ajax_data)

    });
    $('#btnclose').on('click', function (e) {
        $('#claimdetailpanel').hide();
        e.preventDefault();

    });
    $('#btnEndorsements').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {
            
            doc_ref_no: 'All',
            base_doc_ref_no: global_baseDocNumber

        };
        getEndorsementData(ajax_data, '');

    });
    $('#btnSettlements').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {

            
            doc_ref_no: global_initmationNumber

        };
        getSettlementData(ajax_data, '');

    });
    $('#btnRevision').on('click', function (e) {
        e.preventDefault();
        var ajax_data = {

            
            doc_ref_no: global_initmationNumber

        };
        getIntimationsData(ajax_data, '');

    });
    $('#uploadModal').on("hidden.bs.modal", function (){
      //  GetDocuments();
    });
    
    



    $('#hometab').on('click', function () {
        $('#hometab').tab('show');
        $('#hometab').addClass('active');
        $('#Settlement').removeClass('active');
        //applyReadyOnly()

    })
    $('#settlementtab').on('click', function () {
       // $('#settlementtab').tab('show');
       // $('#home').removeClass('active');
        //$('#Settlement').addClass('active');
        applyReadyOnly()
    })
    
    GetClaimComments();
    GetDocumentsbyDepartment();
    GetClaimDetails();
    GetPolicyDetails();
    
    //$('.tohide').show();
    $('#Surveyorlbl').html('Rpeort1');
    $('#Invoice1lbl').html('Invoice1');
    $('#Invoice2lbl').html('Invoice2');
    //GetDocuments();
    refreshDocumentTypes();
})

var settlementHeader = [];
var settlementDetails = [];

var leftchattemplate = '<li class="left clearfix">       <span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff&text=[IH]" alt="User Avatar" class="img-circle" />'+
                       '</span><div class="chat-body clearfix"><div class="" >  </div><p >[ChatContent] </p><small class="pull-right text-muted pull-left"><span class="glyphicon glyphicon-time"></span>' +
                       '</small></div></li>';
var rightchattemplate='<li class="right clearfix" style="float:right"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff&text=[IH]" alt="User Avatar" class="img-circle" /></span>'+
                '<div class="chat-body clearfix"><div> </div> <p>[ChatContent]</p><small class=" text-muted pull-right"><span class="glyphicon glyphicon-time"></span>[TS]</small>  </div></li>';

                                                                  
                                                                             
                                                                          
                                                                          
                                                                                                                                                                                          
                
var statusTemplate ='<div class="col-md-9 col-md-offset-3 "><div class="panel panel-default"><div class="panel-heading"><strong>[Description]</strong> </div>' + 
                    '<div class="panel-body"> <span class="text-left">[Date]</span><span class="text-right">[Time]</span> </div></div>'


var docTemplate = '<div class="row docrows" id="div-[ID]" style="background-color:#696969"><div class="col-md-4 doc_row"><label id="Invoice1lbl-[Id]" class="Docname">[Document_Name]</label></div><div class="col-md-4">' +
                  '<a id="link-[id]" target ="_blank" ><input type="button" class="btn btn-success btn-sm") value="View Details" download /></a></div>' +
                  '<div class="col-md-4"><span id=flag-[Id] class="glyphicon glyphicon-flag" onclick ="markPLR([DOC_ID])"></span><span class="glyphicon glyphicon-comment"></span>' +
                   '</div></div>'


var reportTemplate = '<div class="row reportdoc"><div class="col-md-6"><label id="Surveyorlbl-[Id]">[Document_Name]</label></div>' +
                    '<div class="col-md-6"> <a href="[hrefurl]">  <input type="button" class="btn btn-success btn-sm" value="View Report" /> </a></div></div>';


var approvaltemplate = ' <tr  class="approvalclass" style="width:100%; padding-bottom:10px"><td style="padding:1px; border:0; width: 25%">[ApproverName]:</td>' +
                       '<td style="padding:0px; border:0; width: 25%"><button id ="btnApproveClaim-[id]" class="btn btn-success btnClaimApprove">Approve</button></td>' +
                       '<td style="padding:0px; border:0; width: 35%"><button id ="btnrevertClaim-[id]"class="btn btn-danger btn-sm btnRevert">Revert</button></td>' +
                         '</tr><tr><td> &nbsp; </td></tr>';

var settlementApprovaltemplate = ' <tr  class="settlementapprovalclass" style="width:100%; padding-bottom:10px"><td style="padding:1px; border:0; width: 25%">[ApproverName]:</td>' +
                       '<td style="padding:0px; border:0; width: 25%"><button id ="btnsettlementApprove-[id]" class="btn btn-success btnsettlementApprove">Approve</button></td>' +
                       '<td style="padding:0px; border:0; width: 35%"><button id="btnrevertSettlement-[id]" class="btn btn-danger btn-sm btnsettlementRevert" >Revert</button></td>' +
                       '</tr><tr><td> &nbsp; </td></tr>';
function refreshDocumentTypes() {
    var select = document.getElementById("ddlCat");
    
    select.options.length = 0;
    for (var i = 0; i < global_approvalDocuments.length; i++) {
        
        if (global_approvalDocuments[i].DEPT_CODE == global_deptcode) {
            option = document.createElement("option");
            option.text = global_approvalDocuments[i].DOCUMENTNAME;
            option.value = global_approvalDocuments[i].DOCUMENTID;
            select.appendChild(option);
        }
    }

}
function markPLR(Doc_Id) {
    var ajax_data = {
        Doc_Ref_No: global_initmationNumber,
        DocId: Doc_Id.toString()
    };
    
    $.ajax({
        url: "api/Documents/MarkDocumentPLR",
        type: 'POST',
        data: ajax_data,
        dataType: 'json',
        success: function (data) {
            
        },
        error: function (request) {
            //notifyError('Saving User Detail failed!');

        }
    });
}
function GetClaimComments() {
    var ajax_data = {
        doc_ref_no: global_initmationNumber

    };

    $.ajax({
        url: "api/Claim/GetClaimsComments",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {

            if (data.length > 0) {
                
                    //tblClaimComments

                    $('#tblClaimComments').dataTable({
                        data: data,
                        "columns": [
                            { "data": "CLAIMIDX" },
                            { "data": "USERIDX" },

                            { "data": "ASSIGNEDTO" },
                            { "data": "DATETIME" },
                            { "data": "DESCRIPTION" },
                            { "data": "HOLDSTATUS" },
                            { "data": "CLAIMSTATUS" }
                        ]
                    })

                


                
            }           



        },
        error: function (request) {
            console.log('failure');
            //notifyError('Saving User Detail failed!');

        }
    });

}


function GetClaimDetails() {
    var ajax_data = {
        doc_ref_no: global_initmationNumber

    };

    $.ajax({
        url: "api/Claim/GetClaimDetails",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {

            console.log(data);
            if (data.length > 0) {
                //DOCREFNO
                global_assignedTo = data[0].ASSIGNEDTO;
                global_intimationFinalized = data[0].STATUSIDX;
                globalInitEntyNo = data[0].GIH_INTI_ENTRYNO;
                $('#lblClaimNo').html(data[0].GIH_DOC_REF_NO);
                $('#lblClient').html(data[0].CLIENT);
                $('#lblIntimidationDate').html(moment(data[0].GIH_INTIMATIONDATE).format('DD/MM/YYYY'));
                $('#lbldepartment').html(data[0].DEPTT + '-' + data[0].PBC_DESC.toString().capitalize(true));
                $('#lblDateofLoss').html(moment(data[0].GIH_DATEOFLOSS).format('DD/MM/YYYY'));
                $('#lblLossType').html(data[0].LOSS_TYPE);
                $('#lblOrganization').html(data[0].ORGAN.toString().capitalize(true));
                global_amount = data[0].LOSS;
                $('#lblEstAmount').html(numberWithCommas(data[0].LOSS));
                $('#lblTransDate').html(moment(data[0].TRANS_DATE).format('DD/MM/YYYY'));
                if (data[0].PDP_DEPT_CODE == 13) {
                    $('#rowSurveyour').show();
                    
                    if (data[0].SURYNAME !=null)
                    $('#SurveyourName').html(data[0].SURYNAME.toString().capitalize(true));
                    if (data[0].SURYDATE != null) {
                        $('#SurveyourDate').html('<strong>Appointment Date </strong> <br> ' + moment(data[0].SURYDATE).format('DD/MM/YYYY'));
                    }
                    if (data[0].SURV_FEES != null) {
                        var osamount = numberWithCommas(parseInt(data[0].SURV_FEES) + parseInt(data[0].LOSS))
                        $('#OSAmount').html('<strong>Survey Fees </strong> <br> ' + numberWithCommas(data[0].SURV_FEES));

                        if ((parseInt(data[0].SURV_FEES) + parseInt(data[0].LOSS)) > parseInt(data[0].LOSS) && user_type != 'USER') {
                            $('.nav-tabs a[href="#Settlement"]').tab('show');
                        }
                    }

                }
                else {
                    $('#rowSurveyour').hide();
                }
                getApprovals();
                getSettlements();
                //tblClaimComments
                
                getSettelementApprovals();
                





            }



        },
        error: function (request) {
            console.log('failure');
            //notifyError('Saving User Detail failed!');

        }
    });

}
var global_partyCode = 0;

function ApplyReadOnlyCheckBy() {
    debugger;
    var ischeckbyfinalized = false;

    if (global_intimationFinalized == 100 || global_intimationFinalized > 100) {
        $('#btnFinalizeInimation').attr('disabled', 'disabled');
        ischeckbyfinalized = true;

    }
    
    if (ischeckbyfinalized) {
        $('.dllcheckby').attr('disabled', 'disabled');
        $('.dllrevetcheck').attr('disabled', 'disabled');
    }
    if (global_assignedTo != null) {
        if (global_assignedTo.toLowerCase() != user_code.toLowerCase()) {
            $('.dllcheckby').attr('disabled', 'disabled');
            $('.dllrevetcheck').attr('disabled', 'disabled');
            $('#btnFinalizeInimation').attr('disabled', 'disabled');
        }
        if (global_assignedTo.toLowerCase() == user_code.toLowerCase() && global_intimationFinalized <= 100) {
            $('.dllcheckby').removeAttr('disabled');
            $('.dllrevetcheck').removeAttr('disabled');
            $('#btnFinalizeInimation').removeAttr('disabled');


        }
    }
    if ( global_intimationFinalized == 125) {
        $('.dllcheckby').removeAttr('disabled');
        $('.dllrevetcheck').removeAttr('disabled');
        $('#btnFinalizeInimation').removeAttr('disabled');


    }
    if (global_assignedTo == null) {
        $('.dllcheckby').removeAttr('disabled');
        $('.dllrevetcheck').removeAttr('disabled');
        $('#btnFinalizeInimation').removeAttr('disabled');
    }
    if (global_intimationFinalized == 35) {
        $('.dllcheckby').removeAttr('disabled');
        $('.dllrevetcheck').removeAttr('disabled');
        $('#btnFinalizeInimation').removeAttr('disabled');
    }
}
function ApplyReadOnlySettlements() {
    
    var ischeckbyfinalized = false;

    if (global_intimationFinalized < 100) {
        $('.ddlsetlementApproval').attr('disabled', 'disabled');
        $('#dllrevertsettlement').attr('disabled', 'disabled');
        $('#btnFinalizeSettlements').attr('disabled', 'disabled');
       
        
    }
    if (global_assignedTo != null) {
        if (global_assignedTo.toLowerCase() != user_code.toLowerCase() && global_assignedTo != null && global_intimationFinalized != 35) {
            $('.ddlsetlementApproval').attr('disabled', 'disabled');
            $('#dllrevertsettlement').attr('disabled', 'disabled');
            $('#btnFinalizeSettlements').attr('disabled', 'disabled');
            return;
        }
        if (global_assignedTo.toLowerCase() != user_code.toLowerCase()) {
            $('.ddlsetlementApproval').attr('disabled', 'disabled');
            $('#dllrevertsettlement').attr('disabled', 'disabled');
            $('#btnFinalizeSettlements').attr('disabled', 'disabled');
        }
    }
    //if (global_assignedTo == user_code && global_intimationFinalized <= 100) {
    //    $('.ddlsetlementApproval').removeAttr('disabled', 'disabled');
    //    $('.dllrevertsettlement').removeAttr('disabled', 'disabled');
    //    $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');


    //}
    if (global_intimationFinalized == 125) {
        $('.ddlsetlementApproval').removeAttr('disabled');
        $('#revertapprovedd').removeAttr('disabled');
        $('#ddlsetlementApproval').removeAttr('disabled');
        $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');

    }
    if (global_intimationFinalized == 100 && global_assignedTo != user_code) {
        $('.ddlsetlementApproval').removeAttr('disabled');
        $('#revertapprovedd').removeAttr('disabled');
        $('#ddlsetlementApproval').removeAttr('disabled');
        $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');

    }
    if (global_intimationFinalized == 50) {
        $('.ddlsetlementApproval').attr('disabled', 'disabled');
        $('.dllrevertsettlement').attr('disabled', 'disabled');
        $('#ddlsetlementApproval').attr('disabled', 'disabled');
        $('#btnFinalizeSettlements').attr('disabled', 'disabled');
        return;
    }
    
    if (global_intimationFinalized == 15) {
        $('.ddlsetlementApproval').removeAttr('disabled');
        $('.dllrevertsettlement').removeAttr('disabled');
        $('#ddlsetlementApproval').removeAttr('disabled');
        $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');

    }
    if (global_intimationFinalized == 35) {
        $('.ddlsetlementApproval').removeAttr('disabled');
        $('#ddlsetlementApproval').removeAttr('disabled');
        $('#ddlsetlementApproval').removeAttr('disabled');
        $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');

    }
    if (global_assignedTo != null) {
        if (global_assignedTo.toLowerCase() == user_code.toLowerCase() && global_intimationFinalized == 10) {
            $('.ddlsetlementApproval').removeAttr('disabled', 'disabled');
            $('#dllrevertsettlement').removeAttr('disabled', 'disabled');
            $('#btnFinalizeSettlements').removeAttr('disabled', 'disabled');
        }
    }
    if (global_amount > global_currentUserAmount) {
        $('#btnFinalizeSettlements').attr('disabled', 'disabled');
    }
    
}
function GetPolicyDetails() {
    var ajax_data = {
        doc_ref_no: global_initmationNumber

    };

    $.ajax({
        url: "api/Claim/GetPolicyDetails",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {
            console.log('policy details');
            console.log(data);
            if (data.length > 0) {
                
                $('#lblPolicyNo').html(global_baseDocNumber);

                var index = 0; 

                var greater_gihEntryNum = 0;
                var objdata = {};
               
                objdata = data[0];

                if (data[0].GDH_GROSSPREMIUM != null)
                    $('#lblGP').html(numberWithCommas(objdata.GDH_GROSSPREMIUM));
                
                $('#lblSumInsured').html(numberWithCommas(objdata.GIS_SUMINSURED));
                $('#lblPremPayable').html(numberWithCommas(objdata.GDH_NETPREMIUM));
                $('#lblClient').html(objdata.PPS_DESC);
                $('#lblCNICNo').html(objdata.PPS_CNIC_NO);
                $('#lblOldClaimNo').html(objdata.OLD_CLAIM_NO);
                $('#lblIndividualClient').html(objdata.GDH_INDIVIDUAL_CLIENT.toString().capitalize(true));
                $('#lblAddress').html(objdata.GIA_ADDRESS1.toString().capitalize(true) + objdata.GIA_CITY.toString().capitalize(true));
                $('#lblModel').html(objdata.PMK_DESC);
                $('#lblEngine').html(objdata.GIS_ENGINE_NO);
                $('#lblChasis').html(objdata.GIS_CHASSIS_NO);
                $('#regnum').html(objdata.GIS_REGISTRATION_NO);

                //GIA_ADDRESS1
                //$('#lblAddress').html(data[0].PPS_DESC);
                if (data[0].GIS_CHASSIS_NO == null) {
                    $('#History2').hide();
                }
                else {
                    globalChasisNo = data[0].GIS_CHASSIS_NO;
                      
                    $('#History2').show();
                }
                global_partyCode = data[0].PPS_PARTY_CODE;

                //lblCOMMDATE
                checkEndorements();
                






            }

            for (var i = 0; i < data.length; i++) {
                
            }

        },
        error: function (request) {
            console.log('failure');
            //notifyError('Saving User Detail failed!');

        }
    });

}
var globalChasisNo = '';
function GetDocuments() {
    var ajax_data = {
        ref_doc_no: global_initmationNumber

    };

    $.ajax({
        url: "api/Documents/GetDocuments",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {
            var id = 0;

            

            if (data.length > 0) {
                
                var isplr = false;
                $('#repot-container .docrows').remove()
                for (var i = 0; i < data.length; i++) {

                        
                    var row_data = docTemplate.replace("[Id]", i);
                    $('#div-' + data[i].DOCUMENTID).remove();
                    var claimwoslah = data[i].FOLDERNAME.replace("\/", "");
                    var doc_url = getRootWebSitePath() + "UploadedFiles/" + claimwoslah + "/" + data[i].FILENAME;
                          
                    if (getRootWebSitePath().indexOf("CMS")>0)
                        doc_url = getRootWebSitePath() + "/UploadedFiles/" + claimwoslah + "/" + data[i].FILENAME;

                    
                    
                    var row_data = docTemplate.replace("[Id]", data[i].DOC_CATEGORY);
                    row_data = row_data.replace("[DOC_ID]", data[i].DOC_CATEGORY);
                    row_data = row_data.replace("flag-[Id]", 'flag-' +data[i].DOC_CATEGORY);
                    row_data = row_data.replace("link-[id]", 'link-' + data[i].DOC_CATEGORY);
                    row_data = row_data.replace("[Document_Name]", data[i].DOCUMENTNAME);
                    row_data = row_data.replace("div-[ID]", 'div-' + data[i].DOC_CATEGORY);
                    $('#repot-container').append(row_data);

                    $('#flag-' + data[i].DOC_CATEGORY).addClass('blue');
                    $('#link-' + data[i].DOC_CATEGORY).attr('href', doc_url);
                    //$('#flag-' + data[i].DOC_CATEGORY).addClass('blue');
                   
                }

               






            }
           
            

           
        },
        error: function (request) {
            console.log('failure');
            //notifyError('Saving User Detail failed!');

        }
    });

}
var global_deptdocs = [];
function GetDocumentsbyDepartment() {
    var ajax_data = {
        dept_code: global_deptcode

    };

    $.ajax({
        url: "api/Claim/GetClaimDocumentByDepartment",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',

        success: function (data) {
            var id = 0;

           
            for (var i = 0; i < data.length; i++) {
                var docobj = {};
                docobj.documentname = data[i].DOCUMENTNAME;
                docobj.isrequired = data[i].ISREQUIRED;
                docobj.documentid = data[i].DOCUMENTID;
                docobj.documentcategory = data[i].DOC_CATEGORY;
                global_deptdocs.push(docobj);
            }
                for (var i = 0; i < global_deptdocs.length; i++) {
                if (global_deptdocs[i].isrequired == 1) {
                    var row_data = docTemplate.replace("[Id]", global_deptdocs[i].documentid);
                    row_data = row_data.replace("[DOC_ID]", global_deptdocs[i].documentid);
                    row_data = row_data.replace("flag-[Id]", 'flag-' + global_deptdocs[i].documentid);
                    row_data = row_data.replace("link-[id]", 'link-' + global_deptdocs[i].documentid);
                    row_data = row_data.replace("[Document_Name]", global_deptdocs[i].documentname);
                    row_data = row_data.replace("div-[ID]", 'div-' + global_deptdocs[i].documentid);
                    $('#repot-container').append(row_data);
                    $('#flag-' + global_deptdocs[i].documentid).addClass('red');
                    
                   }
            }
             
            GetDocuments();

        },
        error: function (request) {
            console.log('failure');
            //notifyError('Saving User Detail failed!');

        }
    });

}


function isConsolidateEnty(ENTRYNO, GSHENTRYNO) {
    var entrycount = 0;
    for (var i = 0; i < settlementDetails.length; i++) {
        if (settlementDetails[i].GIH_INTI_ENTRYNO == ENTRYNO && settlementDetails[i].GSH_ENTRYNO == GSHENTRYNO) {
            entrycount += 1;
        }
    }
    if (entrycount >= 2) {
        return true;
    }
    else {
        return false;
    }


}

function ViewSettlementDetails(ENTRYNO, GSHENTRYNO) {
    var entrycount = 0;
    var temparr =[];
    for (var i = 0; i < settlementDetails.length; i++) {
        if (settlementDetails[i].GIH_INTI_ENTRYNO == ENTRYNO && settlementDetails[i].GSH_ENTRYNO == GSHENTRYNO) {
            temparr.push(settlementDetails[i]);
        }
    }
    $('#DetailSettlements').modal('show');
    $('#tblSettlementDetails').dataTable({
        data: temparr,
        "columns": [
            {
                "data": "LOSS_TYPE",
            },
            
            { "data": "SETTLEMENT_AGAINST" },
            {
                "data": "PAYEE_NAME",
            },
            
            { "data": "GIH_LOSSCLAIMED" },
            { "data": "SETTLEMENT_NATURE" }
        ]
    })

}

var global_SettlementPostData = [];
function getSettlements() {
    var ajax_data = {
        doc_ref_no: global_initmationNumber
        

    };
    console.log(ajax_data)
    $.ajax({
        url: "api/Claim/GetSetlementDetails",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            console.log(data);
            settlementHeader = [];
            settlementDetails = [];
            if (data["Table"].length > 0)
                settlementDetails = data["Table"]
            if (data["Summary "].length > 0) {
                settlementHeader = data["Summary "];
                for (var i = 0; i < settlementHeader.length; i++) {
                    settlementHeader[i].GSH_SETTLEMENTDATE = moment(settlementHeader[i].GSH_SETTLEMENTDATE).format('DD/MM/YYYY');
                    settlementHeader[i].GPDPAYEEAMOUNT = numberWithCommas(settlementHeader[i].GPDPAYEEAMOUNT);
                }

                var settlementtable = $('#tblSettlement').dataTable({
                    data: settlementHeader,
                    rowReorder: {
                        selector: 'td:nth-child(2)'
                    },
                    responsive: true,
                    "columns": [
                        {
                            "data": "GPD_SERILANO",
                            "render": function (data, type, full, meta) {
                                var coldata = '';
                                if (isConsolidateEnty(full['GIH_INTI_ENTRYNO'], full['GSH_ENTRYNO'])) {


                                    coldata = '<input type="checkbox" class="chksettlementEntry"/><a href="#" onclick =ViewSettlementDetails("' + full['GIH_INTI_ENTRYNO'] + '","' + full['GSH_ENTRYNO'] + '")  >' + full['GSH_ENTRYNO'] + ' </a></input> </td>';
                                }
                                else {
                                    coldata = '<input type="checkbox" class="chksettlementEntry"/>' + full['GSH_ENTRYNO'] + '</td>'
                                }



                                return coldata;
                            }
                        },
                        { "data": "PAYEE_NAME" },
                        { "data": "GIH_OLDCLAIM_NO" },
                        {"data": "SETTLEMENT_NATURE"},
                        { "data": "GIH_INTI_ENTRYNO" },
                        { "data": "GSH_SETTLEMENTDATE" },
                        { "data": "GPDPAYEEAMOUNT" },
                        {
                            "data": "GPDPAYEEAMOUNT",
                            "render": function (data, type, full, meta) {

                                var coldata = '<button class="btn  btn-success btn-sm " onclick = ViewReport("' + full['GIH_DOC_REF_NO'] + '","' + full['GSH_ENTRYNO'] + '"); return false; />  Performa Settlement </td>'
                                return coldata;
                            }

                        }

                    ]
                })

                $('.chksettlementEntry').change(function () {
                    if (this.checked) {

                        console.log($(this).closest('tr'));
                        var cells = $(this).closest('tr')[0].cells;
                        
                            var postEntry = {};
                            postEntry.IntimationNum = cells[0].innerText;
                            postEntry.settlementNum = cells[1].innerText;
                            postEntry.settlementAmount = parseInt( cells[3].innerText.replace(',',''));
                            global_SettlementPostData.push(postEntry);
                    }
                    else {
                        var postEntry = {};
                        var cells = $(this).closest('tr')[0].cells;
                        postEntry.IntimationNum = cells[0].innerText;
                        postEntry.settlementNum = cells[1].innerText;


                        for (var i = 0; i < global_SettlementPostData.length; i++) {
                            if (global_SettlementPostData[i].IntimationNum == postEntry.IntimationNum && global_SettlementPostData[i].settlementNum == postEntry.settlementNum) {
                                global_SettlementPostData.splice(i, 1);
                            }
                        }
                    }
                });



            }
        },
            
        error: function (request) {
            //notifyError('Saving User Detail failed!');

        }
    });
}


function updateGrids() {
     var grid_name=  getParameterByName("grid_name");
     if (grid_name == 'Unassigned') {
         var temp_row = table.row('.selected');
         uassignedtablevar.row('.selected').remove().draw(false);
         LoadGrid(null, true, temp_row);
     }

     
}

function approveClaim(assigned_by, approvalstatus, approvallevel, reviewerId ) {
    debugger;

    if (global_intimationFinalized == 100) {
        return;
    }
    
    //if ($(btnobj).hasClass('btn-default')) {
    //    notifyError('The Claim is already Approved/Reverted');
    //    return;
    //}
    var msg_dialog ="Claim will be moved";
    if (approvalstatus ==10){
        msg_dialog ="Claim will be reverted"
    }
    swal({
        title: "Are you sure?",
        text: msg_dialog,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then(function() {                        
        var ajax_data = {
            Doc_Ref_No: global_initmationNumber,
            Reviewer_Id: assigned_by,

            Approval_Status: approvalstatus,
            next_approval: reviewerId

        };

        var _self = this;
        $.ajax({
            url: "api/Reviewer/ApproveClaims",
            data: ajax_data,
            type: 'POST',
            dataType: 'json',

            success: function (data) {

                if (approvalstatus == 5) {
                    swal({
                        title: "Success",
                        text: 'Check by process has been moved to' + reviewerId,
                        icon: 'success'
                    });
                          
                  
                }
                if (approvalstatus == 15) {
                    swal({
                        title: "Success",
                        text: 'settlement process has been moved to' + reviewerId,
                        icon: 'success'
                    });
                    updateGrids();
                    $('#aprovebydd li').each(function (index) {
                        $(this).attr('disabled', 'disabled')
                    });
                }

            },
            error: function (request) {

            }
        });
    });
          
    
   
}
function approveSettlement(btnobj, approvalstatus, approvallevel, reviewerId) {


    swal({
        title: "Are you sure?",
        text: "Claim will be Proceed",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then(function (inputvale) {
        if (inputvale.dismiss == 'cancel') return;
        if (global_SettlementPostData.length == 0) {
            notifyError('There is no settlement(s) that needs to be approved ');
            return;
        }
        //settlementAmount
        var total_amount = 0;
        for (var i = 0; i < global_SettlementPostData.length; i++) {
            total_amount += global_SettlementPostData[i].settlementAmount;

        }
        for (var i = 0; i < global_settlementApprovals.length; i++) {
            if (user_code == global_settlementApprovals[i].SUS_USERCODE) {
                
            }
        }


        for (var i = 0; i < global_SettlementPostData.length; i++) {


            var ajax_data = {
                Doc_Ref_No: global_initmationNumber,
                Reviewer_Id: user_code,

                Approval_Status: approvalstatus,
                next_approval: reviewerId,
                settlementInitNum: global_SettlementPostData[i].settlementNum,
                settlementEntryNum: global_SettlementPostData[i].IntimationNum,
                settlementAmount: global_SettlementPostData[i].settlementAmount
            };

            var _self = this;
            $.ajax({
                url: "api/Reviewer/ApproveSettlements",
                data: ajax_data,
                type: 'POST',
                dataType: 'json',

                success: function (data) {
                    if (approvalstatus == 15) {
                        notifyError('Approval has been forwared to' + reviewerId);

                    }
                    if (approvalstatus == 20) {
                        notifyError('Approval has been Reverted to' + reviewerId);

                    }
                    if (approvalstatus == 50) {
                        notifyError('Approval has been moved to credit department' );

                    }
                },
                error: function (request) {

                }
            });
        }
    });

}
function revertClaim() {
    var ajax_data = {
        dept_type: global_initmationNumber,
        Reviewer_Id: user_code,
        Approval_Status: 2

    };
    var _self = this;
    $.ajax({
        url: "api/Reviewer/ApproveClaims",
        data: ajax_data,
        type: 'POST',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            $(_self).closest('tr').remove();
        },
        error: function (request) {

        }
    });

}
function assignClaim() {
    var ajax_data = {
        dept_type: global_initmationNumber,
        Reviewer_Id: user_code,
        Approval_Status: 2

    };
    var _self = this;
    $.ajax({
        url: "api/Reviewer/ApproveSettlements",
        data: ajax_data,
        type: 'POST',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
           
        },
        error: function (request) {

        }
    });
}
var currentApprovalLevel = 0;
function getApprovals() {
    var ajax_data = {
        dept_type: global_deptcode,
        amount: parseFloat($('#lblEstAmount').html()),
        doc_ref_no: global_initmationNumber
    };
    var checkApprovalLevel = 0
    $.ajax({
        url: "api/Claim/GetClaimApprovers",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            console.log(data);
            $('#checkbydd li').remove();
            var currentlevel =0;
            for (var i = 0; i < data.length; i++) {

                if (user_code == data[i].SUS_USERCODE)
                {
                    currentApprovalLevel = data[i].APPROVALLEVEL;
                }
            }
            var users = [];
            var reviewerId = "";
            $('#tblDocumenations').show();
            for (var i = 0; i < data.length; i++) {

                var approvalrow = ' <li id="liApprove-[ApproverUser]"><a  href="#"><input type="checkbox"  id="[UserCode]" class="clmchecked" />[User_name]</a></li>';
                var finalizerow = ' <li id="liFinalize-[FinalizedUser]"><a  href="#"><input type="checkbox"  id="[UserCode]" class="fnlchecked" />[User_name]</a></li>';
                var revertrow = ' <li id="liRevert-[RevertUser]"><a  href="#"><input type="checkbox" id="[UserCode]" class="clmrevert" />[User_name]</a></li>';
                var objusertoFind = {};
                objusertoFind.SUS_USERCODE = data[i].SUS_USERCODE;
                objusertoFind.APPROVALLEVEL = data[i].APPROVALLEVEL;
                var n = containsObject(users, data[i].SUS_USERCODE);
                if (n == false) {

                    approvalrow = approvalrow.replace('[User_name]', data[i].SUS_USERCODE);
                    revertrow = revertrow.replace('[User_name]', data[i].SUS_USERCODE);
                    finalizerow = finalizerow.replace('[User_name]', data[i].SUS_USERCODE);
                    approvalrow = approvalrow.replace('[ApproverUser]', data[i].SUS_USERCODE);
                    finalizerow = finalizerow.replace('[FinalizedUser]', data[i].SUS_USERCODE);
                    revertrow = revertrow.replace('[RevertUser]', data[i].SUS_USERCODE);
                    approvalrow = approvalrow.replace('[UserCode]', 'chkApproveUser-' + data[i].SUS_USERCODE + '-' + data[i].APPROVALLEVEL);
                    revertrow = revertrow.replace('[UserCode]', 'chkReverUser-' + data[i].SUS_USERCODE + '-' + data[i].APPROVALLEVEL);
                    finalizerow = finalizerow.replace('[UserCode]','chkFinalizeUser-'+ data[i].SUS_USERCODE +'-' + data[i].APPROVALLEVEL);
                    
                    var amount = parseInt(parseFloat($('#lblEstAmount').html()));
                    $('#checkbydd').append(approvalrow);
                    $('#revertdd').append(revertrow);
                    if (data[i].SUS_USERCODE.toLowerCase() == 'zafar' || data[i].SUS_USERCODE.toLowerCase() == 'murtazaclm') {
                        $('#Finalizedd').append(finalizerow);
                    }
                    reviewerId = data[i].SUS_USERCODE
                    if (data[i].APPROVALLEVEL <= currentApprovalLevel) {

                        $('#liApprove-' + data[i].SUS_USERCODE).addClass('disabled');
                        $('#liApprove-' + data[i].SUS_USERCODE).parent('li').addClass('disabled');
                      
                    }
                       
                    else {

                    }
                    
                    if (data[i].APPROVALLEVEL >= currentApprovalLevel) {
                        $('#liRevert-' + data[i].SUS_USERCODE).addClass('disabled');
                        $('#liRevert-' + data[i].SUS_USERCODE).parent('li').addClass('disabled');
                    }
                    var objuser = {};
                    objuser.SUS_USERCODE = data[i].SUS_USERCODE;
                    objuser.APPROVALLEVEL = data[i].APPROVALLEVEL;
                    objuser.NEXTREVIEWERID = data[i].NEXTREVIEWERID;
                    objuser.STATUS = data[i].STATUS;
                    users.push(objuser);

                 
                }
            }
            
            $('.fnlchecked').change(function () {

                if (this.checked) {
                    var levelid = $(this).attr('id').split('-')[2];
                    var next_reviewer = $(this).attr('id').split('-')[1];
                    if ($(this).hasClass('disabled') && reviewerId == null && currentlevel == levelid) {
                        notifyError('You cannot assignt claim to yourself');
                        return;
                    }
                    if (checkApprovalLevel >= levelid) {
                        notifyError('Claim is already approved or reverted');
                        return;
                    }
                    approveClaim(user_code, 9, 0, next_reviewer);
                    
                } else {
                    // the checkbox is now no longer checked
                }
            });
            ApplyReadOnlyCheckBy();
            
                $('.clmchecked').change(function () {

                    if (this.checked) {
                        var levelid = $(this).attr('id').split('-')[2];
                        var next_reviewer = $(this).attr('id').split('-')[1];
                        if ($(this).hasClass('disabled') && reviewerId == null && currentlevel == levelid) {
                            notifyError('You cannot assignt claim to yourself');
                            return;
                        }

                        approveClaim(user_code, 5, 0, next_reviewer);
                        getApprovals();
                    } else {
                        // the checkbox is now no longer checked
                    }
                });

                $('.clmrevert').change(function () {
                  

                    if (this.checked) {
                        var levelid = $(this).attr('id').split('-')[2];
                        var next_reviewer = $(this).attr('id').split('-')[1];
                        if ($(this).hasClass('disabled') && reviewerId == null && currentlevel == levelid) {
                            notifyError('You cannot assign claim to yourself');
                            return;
                        }
                        if (levelid >= currentApprovalLevel) {
                            notifyError('Claim is already approved or reverted');
                            return;
                        }
                        approveClaim(user_code, 10, 0, next_reviewer)
                        getApprovals();
                    } else {
                        // the checkbox is now no longer checked
                    }
                });
            
         


        },
        failure: function (data) {

        }
    });

}

var global_settlementApprovals = [];
function getSettelementApprovals() {
    var ajax_data = {
        dept_type: global_deptcode,
        amount: parseFloat($('#lblEstAmount').html()),
        doc_ref_no: global_initmationNumber
    };
    $.ajax({
        url: "api/Claim/GetSettlementApprovers",
        data: ajax_data,
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            console.log(data);
            $('.approvalclass').remove();
            var currentlevel =0;
            for (var i = 0; i < data.length; i++) {

                if (user_code == data[i].SUS_USERCODE)
                {
                    currentApprovalLevel = data[i].APPROVALLEVEL;
                    global_currentUserAmount = data[i].UPPERLIMIT;
                }
            }
            var users = [];
            var reviewerId = "";
            for (var i = 0; i < data.length; i++) {

                var approvalrow = ' <li id="liClaimApprove-[ApproverUser]"><a  href="#"><input type="checkbox"  id="Approve_[UserCode]" class="lmtchecked" />[User_name]</a></li>';
                var revertrow = ' <li id="liClaimRevert-[RevertUser]"><a  href="#"><input type="checkbox" id="Revet_[UserCode]" class="lmtrevert" />[User_name]</a></li>';
                var objusertoFind = {};
                objusertoFind.SUS_USERCODE = data[i].SUS_USERCODE;
                objusertoFind.APPROVALLEVEL = data[i].APPROVALLEVEL;
                
                var n = containsObject(users, data[i].SUS_USERCODE);
                if (n == false) {

                    approvalrow = approvalrow.replace('[User_name]', data[i].SUS_USERCODE);
                    revertrow = revertrow.replace('[User_name]', data[i].SUS_USERCODE);
                    approvalrow = approvalrow.replace('[ApproverUser]', data[i].SUS_USERCODE);
                    revertrow = revertrow.replace('[RevertUser]', data[i].SUS_USERCODE);
                    approvalrow = approvalrow.replace('[UserCode]', 'chkApproveLimitUser-' + data[i].SUS_USERCODE + '-' + data[i].APPROVALLEVEL);
                    revertrow = revertrow.replace('[UserCode]', 'chkRevertLimitUser-' + data[i].SUS_USERCODE + '-' + data[i].APPROVALLEVEL);
                    var amount = parseInt(parseFloat($('#lblEstAmount').html()));
                    $('#aprovebydd').append(approvalrow);
                    $('#revertapprovedd').append(revertrow);
                    reviewerId = data[i].NEXTREVIEWERID
                    if (data[i].APPROVALLEVEL <= currentApprovalLevel) {

                        $('#liClaimApprove-' + data[i].SUS_USERCODE).addClass('disabled');
                        $('#liClaimApprove-' + data[i].SUS_USERCODE).parent('li').addClass('disabled');
                      
                    }
                       
                    else {

                    }

                    if (reviewerId != null) {
                        
                    }
                    if (data[i].APPROVALLEVEL >= currentApprovalLevel) {
                        $('#liClaimRevert-' + data[i].SUS_USERCODE).addClass('disabled');
                        $('#liClaimRevert-' + data[i].SUS_USERCODE).parent('li').addClass('disabled');
                    }
                    var objuser = {};
                    objuser.SUS_USERCODE = data[i].SUS_USERCODE;
                    objuser.APPROVALLEVEL = data[i].APPROVALLEVEL;
                    objuser.NEXTREVIEWERID = data[i].NEXTREVIEWERID;
                    objuser.STATUS = data[i].STATUS;
                    objuser.UPPERLIMIT = data[i].UPPERLIMIT;
                    users.push(objuser);

                 
                }
            }
            ApplyReadOnlySettlements();
            global_settlementApprovals = users;
            $('#tblSettlementApprovals').show();
            $('.lmtchecked').change(function () {

                if (this.checked) {
                    var levelid = $(this).attr('id').split('-')[2];
                    var next_reviewer = $(this).attr('id').split('-')[1];
                    if ($(this).hasClass('disabled') && reviewerId == null && currentlevel == levelid) {
                        notifyError('You cannot assignt claim to yourself');
                        return;
                    }
                    
                    approveSettlement(user_code, 15, 0, next_reviewer);
                    
                } else {
                    // the checkbox is now no longer checked
                }
            });
            $('.lmtrevert').change(function () {

                if (this.checked) {
                    var levelid = $(this).attr('id').split('-')[2];
                    var next_reviewer = $(this).attr('id').split('-')[1];
                    if ($(this).hasClass('disabled') && reviewerId == null && currentlevel == levelid) {
                        notifyError('You cannot assignt claim to yourself');
                        return;
                    }
                    
                    approveSettlement(user_code, 20, 0, next_reviewer)

                } else {
                    // the checkbox is now no longer checked
                }
            });
         


        },
        failure: function (data) {
        }
    });
}

Dropzone.autoDiscover = false;

function containsObject(list, value) {
    var i;
    for (i = 0; i < list.length; i++) {
        if (list[i].SUS_USERCODE== value) {
            return true;
        }
    }

    return false;
}
var dropzone = new Dropzone('#demo-upload', {
previewTemplate: document.querySelector('#preview-template').innerHTML,
parallelUploads: 10,
thumbnailHeight: 120,
thumbnailWidth: 120,
maxFilesize: 500,
filesizeBase: 1000,

thumbnail: function(file, dataUrl) {
    if (file.previewElement) {
        file.previewElement.classList.remove("dz-file-preview");
        var images = file.previewElement.querySelectorAll("[data-dz-thumbnail]");
        for (var i = 0; i < images.length; i++) {
            var thumbnailElement = images[i];
            thumbnailElement.alt = file.name;
            thumbnailElement.src = dataUrl;
            
        }
        setTimeout(function () { file.previewElement.classList.add("dz-image-preview"); }, 1);
        
    }
},
init: function () {
            
            this.on("addedfile", function (file) {
                file.previewElement.addEventListener("click", function (file) {
                    
                    file_details = file.path[2];
                    console.log(file_details)
                    file_info = $(file_details).context.innerText.split("\n");

                    if (file_info[0] == '') {
                        return;
                    }
                    file_size = file_info[0];

                    file_name = file_info[1];
                    $('#txtFileName').val(file_name)
                    $('#lblFileFormat').html('<strong> File Format: </strong>' + file_name.split('.')[1]);
                    $('#txtFileName').val(file_name.split('.')[0])
                    $('#lblFileName').html('<strong> File Size: </strong>' + file_size);
                    $('#uploadModal').modal('hide');
                    $('#filedetails').modal('show');
                });
            });
    }
});


// Now fake the file upload, since GitHub does not handle file uploads
// and returns a 404

var minSteps = 6,
    maxSteps = 60,
    timeBetweenSteps = 100,
    bytesPerStep = 100000;
var file_name = '';
var files_arr = [];
var file_size = 0;
var format_identified=false
dropzone.uploadFiles = function(files) {
    var self = this;

    for (var i = 0; i < files.length; i++) {

        var file = files[i];
        
        files_arr.push(file)
        totalSteps = Math.round(Math.min(maxSteps, Math.max(minSteps, file.size / bytesPerStep)));
      
        for (var step = 0; step < totalSteps; step++) {
            var duration = timeBetweenSteps * (step + 1);
            setTimeout(function(file, totalSteps, step) {
                return function() {
                    file.upload = {
                        progress: 100 * (step + 1) / totalSteps,
                        total: file.size,
                        bytesSent: (step + 1) * file.size / totalSteps
                    };

                    self.emit('uploadprogress', file, file.upload.progress, file.upload.bytesSent);
                    if (file.upload.progress == 100) {
                        file.status = Dropzone.SUCCESS;
                        self.emit("success", file, 'success', null);
                        self.emit("complete", file);


                        
                            //document.getElementsByClassName("dz-success-mark").style.opacity = "1";
                        }
                    };
            }(file, totalSteps, step), duration);
        }
    }
}
var modalConfirm = function (callback) {

    $("#btnsave").on("click", function () {
        $("#confirm-modal").modal('show');
    });

    $("#modal-btn-si").on("click", function () {
        callback(true);
        $("#confirm-modal").modal('hide');
    });

    $("#modal-btn-no").on("click", function () {
        callback(false);
        $("#confirm-modal").modal('hide');
    });
};
function UploadeFile(){
        var filesearched;
        event.preventDefault();
      
        var ajax_data = {
            ref_doc_no: global_initmationNumber,
            catId: $('#ddlCat').val()
        };
        $.ajax({
            url: "api/Documents/GetDocumentsByCat",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {
                if (data.length > 0) {
                    modalConfirm(function (confirm) {
                        if (confirm) {
                            proceedFileUpload();
                        } else {

                        }
                    });
                }
                else {
                    proceedFileUpload();

                }
            }
          });

}


function proceedFileUpload() {
    if (files_arr.length > 0) {

        for (var i = 0; i < files_arr.length; i++) {
            console.log($('#txtFileName').val() + "." + $(lblFileFormat).html());
            if (files_arr[i].name.indexOf($('#txtFileName').val()) >= 0) {
                filesearched = files_arr[i];
            }

        }



        var data = new FormData();
        data.append("UploadedFile", filesearched);
        data.append('DocumentCategory', $('#ddlCat').val());
        data.append('doc_name', filesearched.name);
        data.append("doc_ref_no", global_initmationNumber)
        data.append("DocId", $('#ddlCat').val())
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "api/Documents/UploadDocuments",
            contentType: false,
            processData: false,
            data: data,
            success: function (data) {

                var row_data = docTemplate.replace("[Id]", $('#ddlCat').val());
                row_data = row_data.replace("[DOC_ID]", $('#ddlCat').val());
                row_data = row_data.replace("flag-[Id]", 'flag-' + $('#ddlCat').val());
                row_data = row_data.replace("link-[id]", 'link-' + $('#ddlCat').val());

                row_data = row_data.replace("[Document_Name]", $('#ddlCat  option:selected').text());
                row_data = row_data.replace("div-[ID]", 'div-' + $('#ddlCat').val());
                var docid = '';

                for (var i = 0; i < global_deptdocs.length; i++) {
                    if (global_deptdocs[i].isrequired == 1 && global_deptdocs[i].documentname == $('#ddlCat  option:selected').text()) {
                        row_data = row_data.replace('style="background-color:#696969"', 'style="background-color:#2F4F4F"');
                        docid = global_deptdocs[i].documentid;
                    }
                }


                var doccount = 0;
                GetDocuments();

                $('#uploadModal').modal('show');
                $('#filedetails').modal('hide');

            }
        });





    }

}
