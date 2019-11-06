
var myDropzone, UpdateMyDropzone = null;

$(document).ready(function () {

    Dropzone.autoDiscover = false;
    myDropzone = new Dropzone("#dZUpload", {
        url: "Attachment.ashx",

        autoProcessQueue: false,
        //upload more than 2 files by Dropzone.js with button
        parallelUploads: 20,
        //File size

        maxfilesize: 1000,
        //Number of files
        maxFiles: 20,
        addRemoveLinks: true,

        success: function (file, response) {
            var imgName = response;
            file.previewElement.classList.add("dz-success");
            console.log("Successfully uploaded :" + imgName);
        },
        error: function (file, response) {
            file.previewElement.classList.add("dz-error");
        }
    });



    jQuery.validator.setDefaults({
        debug: true,
        success: "valid"



    });


    $("#form1").validate({
        rules: {
            field: {
                required: true
            }
        }
    });


    localStorage.setItem('UserRole', $('#hdnUserRole').val());
    localStorage.setItem('userid', $('#hdnuser').val());
    localStorage.setItem('statusidx', $('#hdnStatusidx').val());
    var statusidx = localStorage.getItem('statusidx');

    if (statusidx == "80") {
        $('#drpList').hide();
    }


    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'OperationHead') {
        $('#AproveRate').hide();
        $('#AproveCheck').hide();
        $('#BusclasRate').show();
        $('#AgentRate').show();
        $('#InstalTab').show();
        $('#BusClassAllRate').hide();
        $('#btnAddClientDetail').hide();

    }
    else if (UserRole == 'BranchManager') {
        $('#btnFinalizeclientData').show();
        $('#AproveRate').hide();
        $('#AproveCheck').hide();
        $('#BusclasRate').hide();
        $('#AgentRate').hide();
        $('#InstalTab').hide();
        //$('#btnAddClientDetail').hide();
    }
    else if (UserRole == 'Producer') {
        $('#AproveRate').hide();
        $('#AproveCheck').hide();
        $('#BusclasRate').hide();
        $('#AgentRate').hide();
        $('#InstalTab').hide();

        //$('#BusinessDetail').show();
    }
    else if (UserRole == 'OverComission') {

        $('#BusClassAllRate').hide();
        $('#FinalizeTab').hide();
        $('#btnAddClientDetail').hide();




    }
    else if (UserRole == 'IT') {

        $('#BusClassAllRate').hide();
        $('#FinalizeTab').hide();
        $('#btnAddClientDetail').hide();
    }

    //$('#BusclasRate').hide();
    //$('#AgentRate').hide();
    //$('#InstalTab').hide();

    GetMyTask();
    $('#list_gridDocComplience').hide();
    $("#txtNic").mask("99999-9999999-9");
    $("#txtSTN").mask("9999999999999");
    $("#txtNTN").mask("9999999-9");
    $("#txtClientMobile").mask("9999999");
    $("#txtPhone").mask("999999999");
    $("#txtContactPersonMobile").mask("9999999");


    $('#txtFromDate').datepicker({
        format: 'dd-mmm-yyyy',
       

    });
    

    $('#txtToDate').datepicker({
        format: 'dd-mmm-yyyy',

    });
    $('#txtAssFromDate').datepicker({
        format: 'dd-mmm-yyyy',

    });

    $('#txtAssToDate').datepicker({
        format: 'dd-mmm-yyyy',


    });
    $('#txtIssueDate').datepicker({
        format: 'dd-mm-yyyy',


    });
    $('#txtIssueDate').mask('99-99-9999', {  placeholder: "dd-mm-yyyy" });
    $('#txtExpireDate').datepicker({            
        format: 'dd-mm-yyyy',


    });
    $('#txtExpireDate').mask('99-99-9999', { placeholder: "dd-mm-yyyy" });
    $('#txtFinalizeFromDate').datepicker({
        format: 'dd-mmm-yyyy',


    });

    $('#txtFinalizeToDate').datepicker({
        format: 'dd-mmm-yyyy',


    });
    var dttodate = new Date();
    var Todateday = dttodate.toLocaleString('en-us', { day: 'numeric' });
    var Todatemonth = dttodate.toLocaleString('en-us', { month: 'short' });
    var Todateyear = dttodate.toLocaleString('en-us', { year: 'numeric' });
    var Todate = Todateday + '-' + Todatemonth + '-' + Todateyear;

    document.getElementById("txtToDate").value = Todate;
    document.getElementById("txtFromDate").value = '01-Jan-2019';
    document.getElementById("txtFinalizeToDate").value = Todate;
    document.getElementById("txtAssFromDate").value = '01-Jan-2019';
    document.getElementById("txtAssToDate").value = Todate;
    document.getElementById("txtFinalizeFromDate").value = '01-Jan-2019';
    BindBuscLass();
    BusclassAgentWise();
    LoadAssignedTask();
    GetFinalizeClient();


    BindPrefix($('#ddlCategory option:selected').text());



    if ($('#ddlCategory option:selected').text() == 'INDIVIDUAL') {

        $('#contInfoTab').hide();
        $('#compIndusDiv').hide();
        $('#STNDiv').show();
    }
    else {
        $('#contInfoTab').show();
        $('#compIndusDiv').show();
        $('#STNDiv').hide();
    }

    $('#STNDiv').hide();
    $('#NTNDiv').hide();
    $('#OwnershipDiv').hide();
    $('#chkPep').checked == true;
    $('#dropApprove').hide();
    $('#drpList').hide();


    $('input[class="ResidentrCheck"][value="RESIDENT"]').prop("checked", true);
    $('input[class="PepCheck"][value="NO"]').prop("checked", true);
    $('input[class="radioCheck"][value="NO"]').prop("checked", true);

    //GetProducer();
    //window.location = "ClientDetails.aspx";
});





$(document).on('change', ".CustomerCheck", function () {
    $(".CustomerCheck").prop("checked", false);
    $(this).prop("checked", true);
});
$(document).on('change', ".TransactionCheck", function () {
    $(".TransactionCheck").prop("checked", false);
    $(this).prop("checked", true);
});
$(document).on('change', ".GeographicalCheck", function () {
    $(".GeographicalCheck").prop("checked", false);
    $(this).prop("checked", true);
});

$(document).on('change', "#ddlCategory", function () {

    var category = $(this).val();
    BindPrefix(category);

    if (category == 'INDIVIDUAL') {
        $('#contInfoTab').hide();
        $('#compIndusDiv').hide();
        $('#STNDiv').hide();
        $('#NTNDiv').hide();
        $('#OwnershipDiv').hide();


    } else {
        $('#contInfoTab').show();
        $('#compIndusDiv').show();
        $('#STNDiv').show();
        $('#NTNDiv').show();
        $('#OwnershipDiv').show();
    }

});

function BindPrefix(category) {

    var ajax_data = {
        category: category
    };
    $.ajax({
        url: "api/ClientForm/GetPrefix",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                $('#ddlPrefix').empty();
                for (var i = 0; i < data.length; i++) {

                    $('#ddlPrefix').append("<option value='" + data[i].PPX_CODE + "'>" + data[i].PPX_DESC + "</option>");
                }

                if ($("#ddlCategory option:selected").text() == "INDIVIDUAL") {
                    $("#ddlPrefix option:selected").text('Mr.').trigger('change');
                }

            }

        },
        error: function (request) {

        }
    });
}
//function InsertClient() {
//    InsertClientDetail();
//    //InsertClientFormValidte();
//    //var cat = $('#ddlCategory option:selected').text();
//    //if (cat == 'Select Category') {
//    //    alert('Please Select Category')
//    //}
//    //else {

//    //    if (cat == 'Individual') {
//    //        if ($('#txtNic').val() == '') {
//    //            alert('Please Select CNIC # ');
//    //        } else if ($('#txtIssueDate').val() == '') {
//    //            alert('Please Select CNIC Issue Date  ');
//    //        }
//    //        else if ($('#txtExpireDate').val() == '') {
//    //            alert('Please Select CNIC Expire Date  ');
//    //        }
//    //        else {
//    //            InsertClientFormValidte();
//    //        }

//    //    }
//    //    else if (cat == 'Corporate') {
//    //        if ($('#txtNTN').val() == '') {
//    //            alert('Please Select NTN # ');
//    //        }
//    //        else if ($('#txtIssueDate').val() == '') {
//    //            alert('Please Select CNIC Issue Date  ');
//    //        }
//    //        else if ($('#txtExpireDate').val() == '') {
//    //            alert('Please Select CNIC Expire Date  ');
//    //        }
//    //        else {
//    //            InsertClientFormValidte();
//    //        }
//    //    }

//    // }




//}


function InsertClientFormValidte() {
    var pep;
    if ($('#chkPep').checked) {
        pep = 'Yes';
    }
    else {
        pep = 'No';
    }



    var filer;
    var resident;
    var CRating = $('input[class="CustomerCheck"]:checked').val();
    if (CRating == undefined) {
        CRating = "";
    }
    else {
        CRating = CRating;
    }
    var TRating = $('input[class="TransactionCheck"]:checked').val();
    if (TRating == undefined) {
        TRating = "";
    }
    else {
        TRating = TRating;
    }

    var GRating = $('input[class="GeographicalCheck"]:checked').val();
    if (GRating == undefined) {
        GRating = "";
    }
    else {
        GRating = GRating;
    }


    $(document).on('input[class="radioCheck"]:checked').each(function () {
        filer = ($('input[class="radioCheck"]:checked').val());
        if (filer == undefined) {
            filer = "";
        }
        else {
            filer = filer;
        }


    });
    $(document).on('input[class="ResidentrCheck"]:checked').each(function () {
        resident = ($('input[class="ResidentrCheck"]:checked').val());
        if (resident == undefined) {
            resident = "";

        }
        else {
            resident = resident;
        }
    });

    var prefix = $('#ddlPrefix option:selected').val();
    if (prefix == "Select Prefix") {
        prefix = '';
    }
    else {
        prefix = prefix;
    }
    var GroupName = $('#ddlGroupName option:selected').val();
    if (GroupName == "Select Group") {
        GroupName = '';
    }
    else {
        GroupName = GroupName;
    }
    var compIndus = $('#ddlCompIndustry option:selected').val();
    if (compIndus == "Select Company Industory") {
        compIndus = '';
    }
    else {
        compIndus = compIndus;
    }
    var agentname = $('#txtAggentRate').val();
    if (agentname == "Select Agent Name") {
        agentname = '';
    }
    else {
        agentname = agentname;
    }


    var ajax_data = {

        CFID: 'CF-',
        Branch: $('#ddlBranch option:selected').val(),
        Prefix: prefix,
        ClientName: $('#txtName').val(),
        CNIC: $('#txtNic').val(),
        issueDate: $('#txtIssueDate').val(),
        CNICExpiry: $('#txtExpireDate').val(),
        NTN: $('#txtNTN').val(),
        GST: $('#txtSTN').val(),
        clientType: $('#ddlCategory option:selected').text(),
        EmployeName: $('#txtNameEmpolyer').val(),
        SourceOfIncome: $('#txtSourceIncome').val(),
        ContactPerson: $('#txtContactPerson').val(),
        ContactPerDes: $('#txtDesgRef').val(),
        ContactPersonCnic: $('#txtContactCnic').val(),
        ContactPerNo: $('#txtContactPersonMobile').val(),
        ContactPerEmail: $('#txtContactPersonEamil').val(),
        reference: $('#txtReference').val(),
        GroupName: GroupName,
        companyInd: compIndus,
        ProducerName: $('#txtProducer').val(),
        AgentRate: $('#txtAggentRate').val(),
        Agent: agentname,
        filer: filer,
        CRating: CRating,
        TRating: TRating,
        GRating: GRating,
        resident: resident,
        pep: pep

    };
    $.ajax({
        url: "api/ClientForm/GetInsertClientForm",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            InsertAddress();
            InsertBusclass();
            InsertInstallment();
            insertBank();
            myDropzone.processQueue();
            location.href = "ClientDetails.aspx";
        },
        error: function (request) {

        }
    });
}

function InsertAddress() {

    var table = document.getElementById('tblAddress');
    debugger
    if (cfEdit != undefined) {

        var ajax_AddDta = {
            cfEdit: cfEdit
        };

        $.ajax({
            url: "api/ClientForm/GetClientAddressAlready",
            type: 'GET',
            dataType: 'json',
            data: ajax_AddDta,
            success: function (data) {

                if (data.length > 0) {

                    if (table.rows.length > 1) {

                        for (var i = 1; i < table.rows.length; i++) {
                            debugger
                            if (table.rows[i].cells.length) {
                                var addType = (table.rows[i].cells[0].textContent.trim());
                                var address = (table.rows[i].cells[1].textContent.trim());
                                var country = (table.rows[i].cells[2].textContent.trim());
                                var city = (table.rows[i].cells[3].textContent.trim());
                                var email = (table.rows[i].cells[4].textContent.trim());
                                var ptcl = (table.rows[i].cells[5].textContent.trim());
                                var mobile = (table.rows[i].cells[6].textContent.trim());
                                if (ptcl == null || ptcl == "null") {
                                    ptcl = "";
                                } else {
                                    ptcl: ptcl;
                                }


                                var ajax_data = {
                                    addType: addType.toUpperCase(),
                                    address: address.toUpperCase(),
                                    country: country.toUpperCase(),
                                    city: city.toUpperCase(),
                                    email: email,
                                    ptcl: ptcl,
                                    mobile: mobile,
                                    cfEdit: cfEdit
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetUpdAddress",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {


                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Address !');
                    }

                }

                else {
                    if (table.rows.length > 0) {

                        for (var i = 1; i < table.rows.length; i++) {
                            if (table.rows[i].cells.length) {
                                var addType = (table.rows[i].cells[0].textContent.trim());
                                var address = (table.rows[i].cells[1].textContent.trim());
                                var country = (table.rows[i].cells[2].textContent.trim());
                                var city = (table.rows[i].cells[3].textContent.trim());
                                var email = (table.rows[i].cells[4].textContent.trim());
                                var ptcl = (table.rows[i].cells[5].textContent.trim());
                                var mobile = (table.rows[i].cells[6].textContent.trim());


                                var ajax_data = {
                                    addType: addType.toUpperCase(),
                                    address: address.toUpperCase(),
                                    country: country.toUpperCase(),
                                    city: city.toUpperCase(),
                                    email: email,
                                    ptcl: ptcl,
                                    mobile: mobile,
                                    cfEdit: cfEdit
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertUpdateAddress",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {


                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Address !');
                    }

                }

            },
            error: function (request) {

            }
        });



    }
    else {
        debugger

        var ajax_AddDta = {

        };

        $.ajax({
            url: "api/ClientForm/GetInsertClientAddressAlready",
            type: 'GET',
            dataType: 'json',
            data: ajax_AddDta,
            success: function (data) {

                if (data.length > 0) {
                    if (table.rows.length > 1) {

                        for (var i = 1; i < table.rows.length; i++) {
                            if (table.rows[i].cells.length) {
                                var addType = (table.rows[i].cells[0].textContent.trim());
                                var address = (table.rows[i].cells[1].textContent.trim());
                                var country = (table.rows[i].cells[2].textContent.trim());
                                var city = (table.rows[i].cells[3].textContent.trim());
                                var email = (table.rows[i].cells[4].textContent.trim());
                                var ptcl = (table.rows[i].cells[5].textContent.trim());
                                var mobile = (table.rows[i].cells[6].textContent.trim());


                                var ajax_data = {
                                    addType: addType.toUpperCase(),
                                    address: address.toUpperCase(),
                                    country: country.toUpperCase(),
                                    city: city.toUpperCase(),
                                    email: email,
                                    ptcl: ptcl,
                                    mobile: mobile
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsrtUpdAddress",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {


                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Address !');
                    }

                }
                else {
                    if (table.rows.length > 1) {

                        for (var i = 1; i < table.rows.length; i++) {
                            if (table.rows[i].cells.length) {
                                var addType = (table.rows[i].cells[0].textContent.trim());
                                var address = (table.rows[i].cells[1].textContent.trim());
                                var country = (table.rows[i].cells[2].textContent.trim());
                                var city = (table.rows[i].cells[3].textContent.trim());
                                var email = (table.rows[i].cells[4].textContent.trim());
                                var ptcl = (table.rows[i].cells[5].textContent.trim());
                                var mobile = (table.rows[i].cells[6].textContent.trim());


                                var ajax_data = {
                                    addType: addType.toUpperCase(),
                                    address: address.toUpperCase(),
                                    country: country.toUpperCase(),
                                    city: city.toUpperCase(),
                                    email: email,
                                    ptcl: ptcl,
                                    mobile: mobile
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertAddress",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {


                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Address !');
                    }
                }
            },
            error: function (request) {

            }
        });




    }

    if ($('#ddlCategory option:selected').text() == 'INDIVIDUAL') {
        $('#ContactInfo').hide();
        $('#ClientMenu a[href="#OtherDetails"]').tab('show');
    }
    else {
        $('#ContactInfo').show();
        $('#ClientMenu a[href="#ContactInfo"]').tab('show');
    }



}


function InsertBusclass() {
    var Busclasstable = document.getElementById('tblBusClass');

    if (cfEdit != undefined) {


        var ajax_AddDta = {
            CF_ID: cfEdit,
            dept: $('#ddlDeptment option:selected').text()
        };

        $.ajax({
            url: "api/ClientForm/GetBusClassAlready",
            type: 'GET',
            dataType: 'json',
            data: ajax_AddDta,
            success: function (data) {

                if (data.length > 0) {
                    if (Busclasstable.rows.length > 1) {

                        for (var i = 1; i < Busclasstable.rows.length; i++) {
                            if (Busclasstable.rows[i].cells.length) {

                                var dept = (Busclasstable.rows[i].cells[0].textContent.trim());
                                var Category = (Busclasstable.rows[i].cells[1].textContent.trim());
                                var busClass = (Busclasstable.rows[i].cells[2].textContent.trim());
                                var InsuranceType = (Busclasstable.rows[i].cells[3].textContent.trim());
                                var exposure = (Busclasstable.rows[i].cells[4].textContent.trim());
                                var Rate = (Busclasstable.rows[i].cells[5].textContent.trim());

                                var ajax_data = {
                                    dept: dept,
                                    Category: Category.toUpperCase(),
                                    busClass: busClass,
                                    InsuranceType: InsuranceType,
                                    exposure: exposure.toUpperCase(),
                                    Rate: Rate,
                                    cfEdit: cfEdit
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetUpdateBusClass",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#AgentProducer"]').tab('show');
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Department Wise Rate !');
                    }
                }
                else {

                    if (Busclasstable.rows.length > 1) {
                        for (var i = 1; i < Busclasstable.rows.length; i++) {
                            if (Busclasstable.rows[i].cells.length) {
                                var dept = (Busclasstable.rows[i].cells[0].textContent.trim());
                                var Category = (Busclasstable.rows[i].cells[1].textContent.trim());
                                var busClass = (Busclasstable.rows[i].cells[2].textContent.trim());
                                var InsuranceType = (Busclasstable.rows[i].cells[3].textContent.trim());
                                var exposure = (Busclasstable.rows[i].cells[4].textContent.trim());
                                var Rate = (Busclasstable.rows[i].cells[5].textContent.trim());

                                var ajax_data = {
                                    dept: dept,
                                    Category: Category.toUpperCase(),
                                    busClass: busClass,
                                    InsuranceType: InsuranceType,
                                    exposure: exposure.toUpperCase(),
                                    Rate: Rate,
                                    cfEdit: cfEdit
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertUpdateBusClass",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {
                                        $('#ClientMenu a[href="#AgentProducer"]').tab('show');

                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Department Wise Rate !');
                    }
                }
            },
            error: function (request) {

            }
        });

    }
    else {
        var ajax_AddDta = {

            dept: $('#ddlDeptment option:selected').text()
        };

        $.ajax({
            url: "api/ClientForm/GetBusClassAlreadyInsert",
            type: 'GET',
            dataType: 'json',
            data: ajax_AddDta,
            success: function (data) {

                if (data.length > 0) {

                    if (Busclasstable.rows.length > 1) {

                        for (var i = 1; i < Busclasstable.rows.length; i++) {
                            if (Busclasstable.rows[i].cells.length) {
                                var dept = (Busclasstable.rows[i].cells[0].textContent.trim());
                                var Category = (Busclasstable.rows[i].cells[1].textContent.trim());
                                var busClass = (Busclasstable.rows[i].cells[2].textContent.trim());
                                var InsuranceType = (Busclasstable.rows[i].cells[3].textContent.trim());
                                var exposure = (Busclasstable.rows[i].cells[4].textContent.trim());
                                var Rate = (Busclasstable.rows[i].cells[5].textContent.trim());

                                var ajax_data = {
                                    dept: dept,
                                    Category: Category.toUpperCase(),
                                    busClass: busClass,
                                    InsuranceType: InsuranceType,
                                    exposure: exposure.toUpperCase(),
                                    Rate: Rate
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetAlreadyInsertUpdateBusClass",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {
                                        $('#ClientMenu a[href="#AgentProducer"]').tab('show');

                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Department Wise Rate !');
                    }
                }
                else {

                    if (Busclasstable.rows.length > 1) {

                        for (var i = 1; i < Busclasstable.rows.length; i++) {
                            if (Busclasstable.rows[i].cells.length) {
                                var dept = (Busclasstable.rows[i].cells[0].textContent.trim());
                                var Category = (Busclasstable.rows[i].cells[1].textContent.trim());
                                var busClass = (Busclasstable.rows[i].cells[2].textContent.trim());
                                var InsuranceType = (Busclasstable.rows[i].cells[3].textContent.trim());
                                var exposure = (Busclasstable.rows[i].cells[4].textContent.trim());
                                var Rate = (Busclasstable.rows[i].cells[5].textContent.trim());

                                var ajax_data = {
                                    dept: dept,
                                    Category: Category.toUpperCase(),
                                    busClass: busClass,
                                    InsuranceType: InsuranceType,
                                    exposure: exposure.toUpperCase(),
                                    Rate: Rate
                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertBusClass",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {
                                        $('#ClientMenu a[href="#AgentProducer"]').tab('show');

                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Select Department Wise Rate !');
                    }
                }

            },
            error: function (request) {

            }



        });


    }


}
function InsertInstallment() {

    var Installtable = document.getElementById('tblInstalment');

    if (cfEdit != undefined) {

        var ajax_data = {

            cfEdit: cfEdit

        };

        $.ajax({
            url: "api/ClientForm/GetInstallmentAlready",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {

                if (data.length > 0) {
                    if (Installtable.rows.length > 1) {
                        for (var i = 1; i < Installtable.rows.length; i++) {
                            if (Installtable.rows[i].cells.length) {
                                var dept = (Installtable.rows[i].cells[0].textContent.trim());
                                var InstallMode = (Installtable.rows[i].cells[1].textContent.trim());


                                var ajax_data = {
                                    dept: dept,
                                    InstallMode: InstallMode,
                                    cfEdit: cfEdit

                                };


                                $.ajax({
                                    url: "api/ClientForm/GetUpdateInstallment",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#Attachment"]').tab('show');
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }

                    } else {
                        alert('Please Select Installment !');
                    }
                }
                else {
                    if (Installtable.rows.length > 0) {
                        for (var i = 1; i < Installtable.rows.length; i++) {
                            if (Installtable.rows[i].cells.length) {
                                var dept = (Installtable.rows[i].cells[0].textContent.trim());
                                var InstallMode = (Installtable.rows[i].cells[1].textContent.trim());


                                var ajax_data = {
                                    dept: dept,
                                    InstallMode: InstallMode,
                                    cfEdit: cfEdit


                                };


                                $.ajax({
                                    url: "api/ClientForm/GetEditInsertInstallment",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#Attachment"]').tab('show');
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }

                    } else {
                        alert('Please Select Installment !');
                    }
                }
            },
            error: function (request) {

            }
        });



    }
    else {


        var ajax_data = {


        };

        $.ajax({
            url: "api/ClientForm/GetInsertInstallmentAlready",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {
                if (data.length > 0) {
                    if (Installtable.rows.length > 1) {
                        for (var i = 1; i < Installtable.rows.length; i++) {
                            if (Installtable.rows[i].cells.length) {
                                var dept = (Installtable.rows[i].cells[0].textContent.trim());
                                var InstallMode = (Installtable.rows[i].cells[1].textContent.trim());


                                var ajax_data = {
                                    dept: dept,
                                    InstallMode: InstallMode


                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertUpdateInstallment",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {
                                        $('#ClientMenu a[href="#Attachment"]').tab('show');

                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }

                    } else {
                        alert('Please Select Installment !');
                    }

                }
                else {
                    if (Installtable.rows.length > 1) {
                        for (var i = 1; i < Installtable.rows.length; i++) {
                            if (Installtable.rows[i].cells.length) {
                                var dept = (Installtable.rows[i].cells[0].textContent.trim());
                                var InstallMode = (Installtable.rows[i].cells[1].textContent.trim());


                                var ajax_data = {
                                    dept: dept,
                                    InstallMode: InstallMode


                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertInstallment",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#Attachment"]').tab('show');
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }

                    } else {
                        alert('Please Select Installment !');
                    }
                }
            },
            error: function (request) {

            }
        });



    }






}


$(document).on('click', '#addAdress', function () {


    var ptcl, mobile;
    if ($('#ddlAddressType').valid()) {
        if ($('#txtAdress').valid()) {
            if ($('#ddlCountry').valid()) {
                if ($('#ddlCity').valid()) {

                    if ($('#ddlCategory option:selected').text() == "INDIVIDUAL") {

                        if ($('#txtEmail').valid()) {
                            if ($('#txtClientMobile').valid()) {
                                $('#tblAddress').show();
                                if ($("#txtPhone").val() == "") {
                                    ptcl = "";
                                }
                                else {
                                    ptcl = $("#ddlPtclCode option:selected").text() + '-' + $("#txtPhone").val();
                                }


                                var mobile = $("#ddlMobileCode option:selected").text() + '-' + $("#txtClientMobile").val();
                                var addType = $("#ddlAddressType option:selected").text();
                                var address = $("#txtAdress").val();
                                var country = $("#ddlCountry option:selected").text();
                                var city = $("#ddlCity option:selected").text();
                                var email = $("#txtEmail").val();

                                var markup = "<tr><td>" + addType.toUpperCase() + "</td><td>" + address.toUpperCase() + "</td><td>" + country.toUpperCase() + "</td><td>" + city.toUpperCase() + "</td><td>" + email + "</td><td>" + ptcl.toUpperCase() + "</td><td>" + mobile + "</td><td id='AddressDeleteButton'><span onclick='DeleteAdress(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";

                                $("#tblAddress tbody").append(markup);

                                $('#txtAdress').val('');
                                $('#txtEmail').val('');
                                $('#txtPhone').val('');
                                $('#txtClientMobile').val('');

                            }
                        }

                    }
                    else {

                        $('#tblAddress').show();
                        if ($("#txtPhone").val() == "") {
                            ptcl = "";
                        }
                        else {
                            ptcl = $("#ddlPtclCode option:selected").text() + '-' + $("#txtPhone").val();
                        }
                        if ($("#txtClientMobile").val() == "") {
                            mobile = "";
                        }
                        else {
                            mobile = $("#ddlMobileCode option:selected").text() + '-' + $("#txtClientMobile").val();
                        }



                        //mobile = $("#ddlMobileCode option:selected").text() + '-' + $("#txtClientMobile").val();
                        var addType = $("#ddlAddressType option:selected").text();
                        var address = $("#txtAdress").val();
                        var country = $("#ddlCountry option:selected").text();
                        var city = $("#ddlCity option:selected").text();
                        var email = $("#txtEmail").val();

                        var markup = "<tr><td>" + addType.toUpperCase() + "</td><td>" + address.toUpperCase() + "</td><td>" + country.toUpperCase() + "</td><td>" + city.toUpperCase() + "</td><td>" + email + "</td><td>" + ptcl.toUpperCase() + "</td><td>" + mobile + "</td><td><span onclick='DeleteAdress(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";

                        $("#tblAddress tbody").append(markup);
                        $('#txtAdress').val('');
                        $('#txtEmail').val('');
                        $('#txtPhone').val('');
                        $('#txtClientMobile').val('');
                    }


                }
            }
        } else {

        }
    } else {

    }





});




$(document).on('click', '#btnSearchMyTask', function () {

    var ajax_data = {

        todate: $('#txtToDate').val(),
        toform: $('#txtFromDate').val()
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetMyTaskSearch",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {


            LoadMyTask(data);
        },
        error: function (request) {

        }
    });


});
$(document).on('click', '#btnSendMsg', function () {
    var date = new Date();
    var month = date.toLocaleString('en-us', { month: 'short' });

    var day = date.getDate();
    var hour = date.getHours();
    var min = date.getMinutes();
    var sec = date.getSeconds();

    month = (month < 10 ? "0" : "") + month;
    day = (day < 10 ? "0" : "") + day;
    hour = (hour < 10 ? "0" : "") + hour;
    min = (min < 10 ? "0" : "") + min;
    sec = (sec < 10 ? "0" : "") + sec;

    var curentdate = day + '-' + month + '-' + date.getFullYear() + ' ' + hour + ":" + min + ":" + sec;



    var userid = localStorage.getItem('userid');
    var msg = $('#submit_message').val();


    if (msg == '') {

    }
    else {
        var msgContent = '<div class="chat_message_wrapper"><div class="chat_user_avatar"><label class="md-user-image">' + userid + '</label></div><ul class="chat_message"><li><p>' + msg + '</p><span class="chat_message_time">' + curentdate + '</span></li></ul></div>';
        $('#chat').append(msgContent);
        document.getElementById("submit_message").value = '';


        if (cfEdit != undefined) {

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: 'ClientDetails.aspx/InsertUpdatePersonRecord',
                data: "{'comment':'" + msg.toUpperCase() + "','userid':'" + userid.toUpperCase() + "','cfEdit':'" + cfEdit.toUpperCase() + "'}",

                success: function (data) {
                    GetComments();
                },
                error: function (err) {
                    console.log(err);
                }
            });

        }
        else {

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: 'ClientDetails.aspx/InsertPersonRecord',
                data: "{'comment':'" + msg.toUpperCase() + "','userid':'" + userid.toUpperCase() + "','cfEdit':'" + cfEdit + "'}",

                success: function (data) {
                    GetComments();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }






    }
});

function GetComments() {
    $.ajax({
        url: "api/Chat/GetComment",

        type: 'GET',
        dataType: 'json',
        success: function (data) {

            $('#chat').empty();

            for (var i = 0; i < data.length; i++) {

                var getmsg = '<div class="chat_message_wrapper"><div class="chat_user_avatar"><label class="md-user-image">' + data[i].USERID + '</label></div><ul class="chat_message"><li><p>' + data[i].COMMENTS + '</p><span class="chat_message_time">' + data[i].DATETIME + '</span></li></ul></div>'

                $('#chat').append(getmsg);
            }

        },
        error: function (request) {

        }
    });

};
function DeleteAdress(e) {

    $(e).closest('tr').remove();
}
function DeleteAgentBusClassRate(e) {

    $(e).closest('tr').remove();
}



function DeleteTempContactPerson(e) {

    $(e).closest('tr').remove();
}
function DeleteTempBusClass(e) {

    $(e).closest('tr').remove();



}
function DeleteInstallmentMode(e) {

    $(e).closest('tr').remove();



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



function LoadAssignedTask() {

    $.ajax({
        url: "api/ClientForm/GetAssignedTask",
        type: 'GET',
        dataType: 'json',
        data: {},
        success: function (data) {

            LoadAssignedData(data);


        },
        error: function (request) {
            //notifyError('Data Load failed!');

        }
    });

}
function LoadAssignedData(data) {



    if ($.fn.dataTable.isDataTable('#tblAssign')) {
        accounttablevar = $('#tblAssign').DataTable().clear().destroy();
    }
    accounttablevar = $('#tblAssign').dataTable({

        "language": {
            "info": "_END_ of _TOTAL_"
        },
        bAutoWidth: false,

        responsive: {
            details: {
                type: 'column',
                target: 'tr'
            }
        },
        "pageLength": 5,
        "sPaginationType": "simple",
        data: data,
        columnDefs: [{ "width": "10%", "targets": 1 }],
        dom: 'Bfrtip',
        select: true,



        "columns": [

            { "data": "CF_ID" },
            {
                "data": "PLC_LOCADESC"
            },
            { "data": "CLIENT_NAME" },
            { "data": "CLIENT_CNIC" },
            { "data": "REQUESTUSER" },
            { "data": "REQUEST_DATE" },
            { "data": "ASSIGNUSER" },
            { "data": "ASSIGNEDTO" },




            { "data": "CLIENT_TYPE" },

            {
                "mRender": function (data, type, full) {
                    return '<a class="btn btn-success" style="font-size: 12px;background-color: #096735;"  data-toggle="modal" data-target="#myModal" onclick=viewcomments("' + full["CF_ID"] + '") data-th ="' + full["CF_ID"] + '" href="#" >' + ' View Comments' + '</a> ';
                }
            },

        ],
    });

}


$(document).on('click', '#btnSearchAssTask', function () {

    var ajax_data = {

        todate: $('#txtAssToDate').val(),
        formdate: $('#txtAssFromDate').val()
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetAssignedTaskSearch",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {


            LoadAssignedData(data);
        },
        error: function (request) {

        }
    });


});


function LoadViewComment(golabal_CF_ID) {
    var ajax_data = {
        CF_ID: golabal_CF_ID

    };
    $.ajax({
        url: "api/Chat/GetViewComment",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            console.log(data)
            LoadViewCommentsData(data);


        },
        error: function (request) {
            notifyError('Data Load failed!');

        }
    });





    function LoadViewCommentsData(data) {



        if ($.fn.dataTable.isDataTable('#tblViewComment')) {
            accounttablevar = $('#tblViewComment').DataTable().clear().destroy();
        }
        accounttablevar = $('#tblViewComment').dataTable({

            "language": {
                "info": "_END_ of _TOTAL_"
            },
            bAutoWidth: false,
            "pageLength": 5,
            responsive: {
                details: {
                    type: 'column',
                    target: 'tr'
                }
            },
            "sPaginationType": "simple",
            data: data,
            columnDefs: [{ "width": "10%", "targets": 1 }],
            dom: 'Bfrtip',
            select: true,



            "columns": [

                { "data": "CF_ID" },
                { "data": "USERID" },
                { "data": "FORWARD_TO" },
                { "data": "DATE_TIME" },
                { "data": "COMMENTS" },



            ],
        });

    }

}
function viewcomments(CF_ID) {


    golabal_CF_ID = CF_ID;

    LoadViewComment(golabal_CF_ID)


    $('#myModal').show();

    //$('#view_comments_modal').modal('show')

}



function GetTestData() {
    $.ajax({
        url: "api/Chat/GetComment",

        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);
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
$(document).on('change', '.radioCheck', function () {

    $('.radioCheck').not(this).prop('checked', false);

    if ($(this).is(":checked")) {
        var filerVal = $(this).val();
        if (filerVal == "YES") {
            $('#FilerDiv').show();
        }
        else {
            $('#FilerDiv').hide();
        }

    }
});

//$('.subject-list').on('change', function () {
//    $('.subject-list').not(this).prop('checked', false);
//});
//function checkFiler(input) {
//    debugger




//    var checkboxesFiler = document.getElementsByClassName("radioCheck");

//    var filerval = checkboxesFiler.checked

//    for (var i = 0; i < checkboxesFiler.length; i++) {
//       // uncheck all
//        if (checkboxesFiler[i].checked == true) {

//            checkboxesFiler[i].checked = false;
//        }
//    }

//    //set checked of clicked object
//    if (input.checked == true) {
//        input.checked = false;
//    }
//    else {
//        input.checked = true;
//    }

//    if ($(this).is(":checked")) {
//        var filerVal = $(this).val();
//    }
//}
function checkResident(input) {

    var checkboxes = document.getElementsByClassName("ResidentrCheck");

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

function checkPep(input) {

    var checkboxesPep = document.getElementsByClassName("PepCheck");

    for (var i = 0; i < checkboxesPep.length; i++) {
        //uncheck all
        if (checkboxesPep[i].checked == true) {
            checkboxesPep[i].checked = false;
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
function GetMyTask() {

    var ajax_data = {
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetMyTask",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {


            LoadMyTask(data);
        },
        error: function (request) {

        }
    });

}



function LoadMyTask(data) {
    if ($.fn.dataTable.isDataTable('#tblMyTask')) {
        accounttablevar = $('#tblMyTask').DataTable().clear().destroy();
    }
    accounttablevar = $('#tblMyTask').dataTable({

        "language": {
            "info": "_END_ of _TOTAL_"
        },
        bAutoWidth: false,

        responsive: {
            details: {
                type: 'column',
                target: 'tr'
            }
        },
        "pageLength": 5,
        "sPaginationType": "simple",
        data: data,
        columnDefs: [{ "width": "10%", "targets": 1 }],
        dom: 'Bfrtip',
        select: true,


        "columns": [


            { "data": "CF_ID" },
            {
                "data": "PLC_LOCADESC"
            },
            { "data": "CLIENT_NAME" },
            { "data": "CLIENT_CNIC" },
            { "data": "REQUESTUSER" },
            { "data": "REQUEST_DATE" },
            { "data": "ASSIGNUSER" },
            { "data": "ASSIGNEDTO" },


            { "data": "CLIENT_TYPE" },

            {

                "date": "CF_ID",
                "mRender": function (data, type, full, meta) {


                    return '<input type="button"  class="btn btn-success" value="View Detail"  style="font-size: 12px;background-color: #096735;"    onclick="OnMyTaskEdit(\'' + full["CF_ID"] + '\',\'' + full["LOC_CODE"] + '\',\'' + full["AGENT_RATE"] + '\')"></input>';
                    //data-toggle="modal" data-target="#SurveyorDetailModel"



                }
            },




        ],
    });
}
var cfEdit;
function OnMyTaskEdit(CF_ID, LOC_CODE, AGENT_RATE) {


    $('input[class="ResidentrCheck"][value="RESIDENT"]').prop("checked", false);
    $('input[class="PepCheck"][value="NO"]').prop("checked", false);
    $('input[class="radioCheck"][value="NO"]').prop("checked", false);

    EmptyAddress();
    EmptyContactPErson();
    EmptyBusClassRat();
    EmptyOtherDetail();
    EmptyBusClasssRate();
    EmptyCompilence();
    //EmptyInstallment();
    cfEdit = CF_ID;
    $('#hdnCFidx').val(cfEdit);

    $('#OverCommission').hide();

    $('.md-input-wrapper').addClass("md-input-filled");
    $('.md-input').removeClass("md-input-danger");
    $(".uk-width-medium uk-row-first").addClass("md-input-filled");
    $('#ChatMenu').show();
    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'Producer') {
        $('#ApproveBind').hide();
        //$('#btnFinalize').hide();
        $('#AproveRate').hide();
        $("#tblAgentBusClassRate  tr #AproveCheck").hide();
    }
    else if (UserRole == 'OperationHead') {
        //$('#btnFinalize').show();
        $('#dropApprove').show();
        $('#btnFinalizeclientData').hide();
        $("#tblAgentBusClassRate  tr #AproveCheck").hide();
        $('#AproveRate').hide();
        //$('#btnAddClientDetail').show();

    }
    else if (UserRole == 'BranchManager') {
        ////$('#btnFinalize').hide();
        $('#btnFinalizeclientData').hide();
        $('#dropApprove').show();
        $('#AproveRate').hide();
        $("#tblAgentBusClassRate  tr #AproveCheck").hide();
        $('#btnAddClientDetail').show();


    }
    else if (UserRole == 'OverComission') {
        $('#btnFinalizeAgentRate').show();
        $('#drpList').hide();
        $('#btnFinalizeclientData').hide();
        //$('#AproveCheck').show();
        //$('#AproveRate').show();

        $('#btnFinalizeOverCommission').show();
        $('#btnAddClientDetail').show();

    }



    //$('#drpList').show();
    //$('#btnSubmit').hide();
    //$('#tblAddress').show();
    //$('#tblBusClass').show();

    //$('#tblInstalment').show();
    var ajax_data = {
        CF_ID: CF_ID,
        LOC_CODE: LOC_CODE
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetCFDetail",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            if (data.length > 0) {

                $('#lblCFIDandClientName').show();
                $('#lblCFId').text(cfEdit);
                $('#MainHeadingCLientName').text(data[0].CLIENT_NAME);
                $("#ddlBranch").val(data[0].LOC_CODE).trigger('change');
                document.getElementById("txtName").value = data[0].CLIENT_NAME;
                document.getElementById("txtNic").value = data[0].CLIENT_CNIC;
                document.getElementById("txtIssueDate").value = data[0].CLIENT_NIC_ISSUE;
                document.getElementById("txtExpireDate").value = data[0].CLIENT_NIC_EXPIRY;
                document.getElementById("txtNTN").value = data[0].CLIENT_NTN;
                document.getElementById("txtSTN").value = data[0].CLIENT_GST;
                BindPrefix(data[0].CLIENT_TYPE);
                $("#ddlPrefix option:selected").val(data[0].PREFIX_CODE).trigger('change');
                $("#ddlCategory option:selected").text(data[0].CLIENT_TYPE).trigger('change');

                //  $("#ddlCategory").val(null);
                if (data[0].CLIENT_TYPE == "CORPORATE") {
                    $('#STNDiv').show();
                    $('#NTNDiv').show();
                }
                else {
                    $('#STNDiv').hide();
                    $('#NTNDiv').hide();
                }



                document.getElementById("txtSourceIncome").value = data[0].SOURCE_OF_INCOME;

                document.getElementById("txtContactPerson").value = data[0].CONTACT_PERSON;

                document.getElementById("txtDesgRef").value = data[0].CONTACT_PERSON_DESIGNATION;

                document.getElementById("txtReference").value = data[0].REFERENCEBY;
                $("#ddlGroupName").val(data[0].GROUP_NAME).trigger('change');
                $("#ddlCompIndustry").val(data[0].COMPANY_INDUSTRY).trigger('change');
                $("#ddlBank").val(data[0].BANK_NAME).trigger('change');

                $('input[class="radioCheck"][value="' + data[0].FILER_TYPE + '"]').prop("checked", true);
                $("#ddlAgent").val(data[0].AGENT).trigger('change');
                document.getElementById("txtAggentRate").value = data[0].AGENT_RATE;
                $("#ddlProducer").val(data[0].PRODUCER).trigger('change');

                $('input[class="CustomerCheck"][value="' + data[0].CUSTOMER_RATING + '"]').prop("checked", true);
                $('input[class="TransactionCheck"][value="' + data[0].TRANSACTION_RATING + '"]').prop("checked", true);
                $('input[class="GeographicalCheck"][value="' + data[0].GEOPRAPHICAL_RATING + '"]').prop("checked", true);
                $('input[class="ResidentrCheck"][value="' + data[0].RESIDENT_TYPE + '"]').prop("checked", true);

                $('input[class="PepCheck"][value="' + data[0].PEP + '"]').prop("checked", true);
                document.getElementById("txtSourceIncome").value = data[0].SOURCE_OF_INCOME;
                $("#ddlOwnership").val(data[0].OWNERSHIP).trigger('change');

                if (data[0].CLIENT_TYPE == 'INDIVIDUAL') {
                    $('#contInfoTab').hide();
                    $('#compIndusDiv').hide();

                } else {
                    $('#contInfoTab').show();
                    $('#compIndusDiv').show();
                }

                GetDocuments(CF_ID);
                GetComplienceDocuments(CF_ID);
                GetComments();
                //chkboxRevert();
                //chkboxForward();
                GetApproveUser();
                GetRevertUser(LOC_CODE);
                //GetFillAdreesDetail(CF_ID);

                GetApprovalBusClassDetail(CF_ID);
                GetFillInstallments(CF_ID);
                LoadTableAgentRateDeptWise(CF_ID);
                OnLoadAddressBind(CF_ID);
                onLoadContactPErson(CF_ID);
                LoadApprovalAgentRate(CF_ID);



                var statusidx = localStorage.getItem('statusidx');

                if (statusidx == "30") {

                    $('#btnFinalizeStandardRate').show();
                    $('#drpList').show();

                    $("#addAdress").attr("disabled", "disabled");
                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('.CustomerCheck').prop('disabled', true);
                    $('.TransactionCheck').prop('disabled', true);
                    $('.GeographicalCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();


                }
                if (statusidx == "40" || statusidx == "50") {

                    $('#btnFinalizeStandardRate').show();
                    $('#dropApprove').hide();
                    $('#drpList').show();

                    $("#addAdress").attr("disabled", "disabled");
                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('.CustomerCheck').prop('disabled', true);
                    $('.TransactionCheck').prop('disabled', true);
                    $('.GeographicalCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();
                    $('#btnAddressDelete').hide();

                }


                else if (statusidx == "90" || statusidx == "91") {
                    $('#drpList').hide();
                    $("#addAdress").attr("disabled", "disabled");
                    $('#addAgentDeptWiseRate').hide();
                    $('#btnFinalizeclientData').hide();
                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();




                }

                else if (statusidx == "80") {
                    $('#dropApprove').hide();
                    $('#addAdress').hide();
                    $('#btnFinalizeInstallMode').show();
                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('.CustomerCheck').prop('disabled', true);
                    $('.TransactionCheck').prop('disabled', true);
                    $('.GeographicalCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();

                }

                else if (statusidx == "70") {

                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('.CustomerCheck').prop('disabled', true);
                    $('.TransactionCheck').prop('disabled', true);
                    $('.GeographicalCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();


                }


                else if (statusidx == "40" || statusidx == "50") {
                    $('#drpList').show();
                    $('#dropApprove').hide();

                    $('.md-input').prop('disabled', true);
                    $('.radioCheck').prop('disabled', true);
                    $('#ComplienceFileUpload').prop('disabled', true);
                    $('.ResidentrCheck').prop('disabled', true);
                    $('.PepCheck').prop('disabled', true);
                    $('.CustomerCheck').prop('disabled', true);
                    $('.TransactionCheck').prop('disabled', true);
                    $('.GeographicalCheck').prop('disabled', true);
                    $('#btnAddClientDetail').show();


                }
                $('#CForm')[0].click();
            }

        },
        error: function (request) {

        }
    });




}
function OnLoadAddressBind(CF_ID) {
    var ajax_AddData = {
        CF_ID: CF_ID
    };
    $.ajax({
        url: "api/ClientForm/GetAddressDetail",
        type: 'GET',
        dataType: 'json',
        data: ajax_AddData,
        success: function (data) {
            if (data.length > 0) {
                $("#tblAddress tr:gt(0)").remove();
                for (var i = 0; i < data.length; i++) {
                    debugger
                    var phone;
                    if (data[i].PHONE == null) {
                        phone = "";
                    } else {
                        phone = data[i].PHONE;
                    }
                    var fillAdressDetail = "<tr><td>" + data[i].ADDRESS_TYPE + "</td><td>" + data[i].ADDRESS + "</td><td>" + data[i].COUNTRY + "</td><td>" + data[i].CITY + "</td><td>" + data[i].EMAIL + "</td><td>" + phone + "</td><td>" + data[i].MOBILE_NO + "</td><td><span id='btnAddressDelete' value='" + data[i].IDX + "' onclick='DeleteAddress(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";
                    $('#tblAddress tbody').append(fillAdressDetail);
                }
                $("#ddlAddressType option:selected").text(data[0].ADDRESS_TYPE).trigger('change');
                document.getElementById("txtAdress").value = data[0].ADDRESS;
                document.getElementById("txtEmail").value = data[0].EMAIL;
                var ptclNo;
                var getPtcl = data[0].PHONE;
                if (getPtcl == "null" || getPtcl == undefined) {
                    ptclNo = "";
                }
                else {
                    ptclNo = getPtcl.split('-');
                }
                var ptclcode, ptclNo;
                if (ptclNo[0] == "" || ptclNo[0] == undefined) {
                    ptclcode = "";
                } else {
                    ptclcode = ptclNo[0];
                }
                if (ptclNo[1] == "" || ptclNo[1] == undefined) {
                    ptclNo = "";
                } else {
                    ptclNo = ptclNo[1];
                }

                $("#ddlPtclCode option:selected").text(ptclcode).trigger('change');
                document.getElementById("txtPhone").value = ptclNo;

                var getMobile = data[0].MOBILE_NO;
                var Mobile;
                if (getMobile == null) {
                    Mobile = "";
                }
                else {
                    Mobile = getMobile.split('-');
                }
                //var fullptclNo;
                //if (data[0].PHONE)
                $("#ddlMobileCode option:selected").text(Mobile[0]).trigger('change');
                document.getElementById("txtClientMobile").value = Mobile[1];

                var statusidx = localStorage.getItem('statusidx');
                if (statusidx == "0" || statusidx == "10") {
                    $('#btnAddressDelete').show();
                }
                else {
                    $('#btnAddressDelete').hide();
                }

            }
        },
        error: function (request) {

        }
    });
}
function onLoadContactPErson(CF_ID) {
    var ajax_ContactPersonData = {
        CF_ID: CF_ID
    };
    $.ajax({
        url: "api/ClientForm/GetContactPerson",
        type: 'GET',
        dataType: 'json',
        data: ajax_ContactPersonData,
        success: function (data) {
            if (data.length > 0) {
                $("#tblContactPerson tr:gt(0)").remove();
                $('#tblContactPerson').show();
                for (var i = 0; i < data.length; i++) {

                    var ContactPersonList = "<tr><td>" + data[i].CONTACT_PERSON + "</td><td>" + data[i].CP_DESIGNATION + "</td><td>" + data[i].CP_MOBILE_NO + "</td><td>" + data[i].CP_EMAIL + "</td><td><span id='btnContPersonDelete' value='" + data[i].IDX + "' onclick='DeleteContactPerson(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";
                    $("#tblContactPerson tbody").append(ContactPersonList);
                }
                //debugger
                //if (data[0].CONTACT_PERSON == "") {
                //    document.getElementById("txtContactPerson").value = "";
                //}
                //else {

                //}
                document.getElementById("txtContactPerson").value = data[0].CONTACT_PERSON;
                document.getElementById("txtContactPerson").value = data[0].CONTACT_PERSON;
                document.getElementById("txtDesgRef").value = data[0].CP_DESIGNATION;
                document.getElementById("txtContactPersonEamil").value = data[0].CP_EMAIL;

                var ContPMob = data[0].CP_MOBILE_NO;
                var CPMobile = ContPMob.split('-');
                var FullMobile = CPMobile[0] + '-' + CPMobile[1];
                $("#ddlContactPersonMobCode option:selected").text(CPMobile[0]).trigger('change');
                document.getElementById("txtContactPersonMobile").value = CPMobile[1];
            }

        },
        error: function (request) {

        }
    });
}

function GetDocuments(CF_ID) {
    var ajax_data = {
        CF_ID: CF_ID,
        attachType: 'Other'
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetCFDocuments",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            $('#list_grid').empty();

            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {


                    var documentHtml = '<div id="OtherCFDoc" ><div class="md-card" ><div class="md-card-head uk-text-center uk-position-relative" style="width: 148px;"><img class="md-card-head-img" src="images/document icon.png" style="height: 50%;margin-top: 15px;" alt="" /><a id="A1" target="_blank" runat="server" style="font-size: 12px" href="/documents/' + data[i].ATTACHMENT_PATH + '"><p style="margin-left: 0px;">' + data[i].ATTACHMENT_PATH + '</p></a> </a></div > ';
                    $('#list_grid').append(documentHtml);
                }




            }
        },

        error: function (request) {

        }
    });
}
//$(document).on('click', '#btnRevert', function () {

//    //$('#btnForward').hide();
//    chkboxRevert();

//});

//$(document).on('click', '#btnForward', function () {


//    chkboxForward();

//});

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
//function chkboxForward() {



//    $(document).on("change", "$('#<%=chkApproved.ClientID%>')", function () {

//    alert();
//    var CHK = document.getElementById("<%=chkApproved.ClientID%>");
//    var checkbox = CHK.getElementsByTagName("input");

//    for (var i = 0; i < checkbox.length; i++) {

//        if (checkbox[i].checked) {
//            var statusid = checkbox[i].value;
//            var user = checkbox[i].parentNode.getElementsByTagName("LABEL")[0].innerHTML;


//            var ajax_data = {
//                statusid: statusid,
//                AssignTouser: user

//            };
//            $.ajax({
//                url: "api/Chat/GetForwardStatus",

//                type: 'GET',
//                dataType: 'json',
//                data: ajax_data,
//                success: function (data) {
//                    console.log(data);

//                    alert('Successfully Forward to  ' + user)
//                },
//                error: function (request) {

//                }
//            });

//        }
//    }


//});



function GetApproveUser() {


    $.ajax({
        url: "api/ClientForm/GetApproveName",
        type: 'GET',
        dataType: 'json',
        data: '',
        success: function (data) {

            if (data.length > 0) {
                $('#ApproveBind').empty();
                for (var i = 0; i < data.length; i++) {


                    var documentHtml = '<input type="checkbox" style="margin-left: 10px;float: left;"  class="ApproveCheck" value=' + data[i].STATUSIDX + ' id="chkApproved" /><label style="margin-left: 9px;margin-top: 2px;" for="chk1">' + data[i].USERID + '</label><br/>';
                    $('#ApproveBind').append(documentHtml);
                }



            }

        },
        error: function (request) {

        }
    });

}


$(document).on('click', 'input[class="ApproveCheck"]', function () {
    var statusidx = (this.checked ? $(this).val() : "");
    var AsignTo = (this.checked ? $(this).siblings('label').html() : "");

    if (confirm("Are You Sure Forward to !  " + AsignTo)) {
        if (cfEdit == undefined) {
            cfEdit = "";
        } else {
            cfEdit = cfEdit;
        }

        var ajax_data = {
            statusid: statusidx,
            AssignTouser: AsignTo,
            cfEdit: cfEdit

        };
        $.ajax({
            url: "api/ClientForm/GetForwardStatus",

            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {


                alert('Successfully Forward to  ' + AsignTo)
                window.location = "ClientDetails.aspx";
            },
            error: function (request) {

            }
        });

    }


    else {

        this.checked = false;
    }

});


function GetRevertUser(LOC_CODE) {

    var ajax_data = {
        LOC_CODE: LOC_CODE
    };
    $.ajax({
        url: "api/ClientForm/GetRevertName",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                $('#ddlrevert').empty();
                for (var i = 0; i < data.length; i++) {


                    var RevertHtml = '<input type="checkbox" style="margin-left: 10px;float: left;"  class="RevertCheck" value=' + data[i].STATUSIDX + ' id="chkApproved" /><label style="margin-left: 9px;margin-top: 2px;" for="chkRev">' + data[i].USERID + '</label><br/>';
                    $('#ddlrevert').append(RevertHtml);
                }



            }

        },
        error: function (request) {

        }
    });

}



$(document).on('click', 'input[class="RevertCheck"]', function () {
    var Revertstatusidx = (this.checked ? $(this).val() : "");
    var RevertTo = (this.checked ? $(this).siblings('label').html() : "");

    if (confirm("Are You Sure Revert to !  " + RevertTo)) {

        var ajax_data = {
            statusid: Revertstatusidx,
            AssignTouser: RevertTo

        };
        $.ajax({
            url: "api/ClientForm/GetRevertStatus",

            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {


                alert('Successfully Revert to  ' + RevertTo)
                window.location = "ClientDetails.aspx";
            },
            error: function (request) {

            }
        });

    }


    else {

        this.checked = false;
    }

});


function GetFillAdreesDetail(CF_ID) {

    var ajax_data = {

        CF_ID: CF_ID
    };
    $.ajax({
        url: "api/ClientForm/GetAddressDetail",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                $('#tblAddress tbody tr').empty();
                for (var i = 0; i < data.length; i++) {

                    var fillAdressDetail = "<tr><td>" + data[i].ADDRESS_TYPE + "</td><td>" + data[i].ADDRESS + "</td><td>" + data[i].COUNTRY + "</td><td>" + data[i].CITY + "</td><td>" + data[i].EMAIL + "</td><td>" + data[i].PHONE + "</td><td>" + data[i].MOBILE_NO + "</td></tr >";

                    $('#tblAddress tbody').append(fillAdressDetail);
                }



            }

        },
        error: function (request) {

        }
    });

}
//dept///
function GetApprovalBusClassDetail(CF_ID) {

    var ajax_data = {

        CF_ID: CF_ID
    };
    $.ajax({
        url: "api/ClientForm/GetBisClassDetail",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            $("#tblBusClass tr:gt(0)").remove();

            if (data.length > 0) {


                for (var i = 0; i < data.length; i++) {


                    var btnApprove, StandardRateEdit = "";
                    if (data[i].STATUS == "APPROVED") {
                        btnApprove = "<input type='button'  disabled='disabled' class='btn btn-success StandardApprove' data-standardrateapproveid=" + data[i].IDX + " id='StandardRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'/>";
                        StandardRateEdit = "<input id='btnStandardRateEdit' disabled='disabled' type='button'  class='btn btn-success StandardEdit' data-standardrateid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";

                    } else {
                        btnApprove = "<input type='button'  class='btn btn-success StandardApprove' data-standardrateapproveid=" + data[i].IDX + " id='StandardRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'/>";
                        StandardRateEdit = "<input id='btnStandardRateEdit' type='button'  class='btn btn-success StandardEdit' data-standardrateid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                    }
                    var AgentRateType = "<select class='form-control' id='ddlRateTypeEdit'  style='display:none' ><option value='SELECT RATE TYPE' >SELECT RATE TYPE</option><option value='PERCENT'>PERCENT</option><option value='PERMILLI'>PERMILLI</option><option value='RATE'>RATE</option></select>";

                    var fillBusClassDetail = "<tr><td>" + data[i].CF_ID + "</td><td>" + data[i].DEPARTMENT + "</td><td>" + data[i].BUSNIESS_CATEGORY + "</td><td>" + data[i].BUSNIESS_CLASS + "</td><td>" + data[i].INSURANCE_TYPE + "</td><td>" + data[i].EXPOSURE + "</td><td><input type='text'id='txtProposeStandardRate' disabled='disabled' value='" + data[i].RATE + "' /></td><td><label id='txtRateType'>" + data[i].RATE_TYPE + "</label>" + AgentRateType + "</td><td>" + data[i].STATUS + "</td><td>" + StandardRateEdit + "</td><td> " + btnApprove + "</td></tr>";

                    $('#tblBusClass tbody').append(fillBusClassDetail);

                    var statusidx = localStorage.getItem('statusidx');
                    if (statusidx == "90" || statusidx == "91" || statusidx == "70") {

                        //$('.StandardApprove').hide();
                        //$('.StandardEdit').hide();
                        $('.StandardApprove').prop('disabled', true);
                        $('.StandardEdit').prop('disabled', true);

                    }
                    //<input  style='zoom: 1.8;' id='AproveBuclassRateCheck' type='checkbox'>


                }

                //$("#ddlRateTypeEdit option:selected").text(data[0].RATE_TYPE).trigger('change');

                //$("#ddlBusClassCat").val(data[0].BUSNIESS_CATEGORY).trigger('change');
                ////$("#ddlBusClass").val(data[0].BUSNIESS_CLASS).trigger('change');
                //var buslasUpdate = data[0].INSURANCE_TYPE.toUpperCase();
                //console.log(buslasUpdate);
                //$("#ddlInsuranceType option:selected").text(buslasUpdate).trigger('change');
                //document.getElementById("txtExposure").value = data[0].EXPOSURE;
                //document.getElementById("txtRate").value = data[0].RATE;
                //$("#ddlBusClass option:selected").text(data[0].BUSNIESS_CLASS).trigger('change');
                //$("#ddlBusClass").text(data[0].BUSNIESS_CLASS).trigger('change');

                //var Dept = data[0].DEPARTMENT;
                //var busclasCat = data[0].BUSNIESS_CATEGORY;
                //BindBuscLassUpdate(Dept, busclasCat);
            }

        },
        error: function (request) {

        }
    });

}

function GetFillInstallments(CF_ID) {
    $('#tblInstalment').show();
    var ajax_data = {

        CF_ID: CF_ID
    };
    $.ajax({
        url: "api/ClientForm/GetInstallmentDetail",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                //$('#tblInstalment tbody tr').empty();
                //$('#tblInstalment thead tr').empty();
                //$('#tblInstalment thead tr').append('<th style="width: 12%;">Department</th> <th style="width: 22%;">Installment Mode</th> <th style="width: 1%;"></th>');
                $("#tblInstalment tr:gt(0)").remove();





                $.each(data, function (e, data) {
                    var instalAprove, instaledit = "";
                    if (data.STATUS == "APPROVED") {
                        instalAprove = "<input type='button' disabled='disabled'  class='btn btn-success InstalAprovebtn' data-installmentapproveid=" + data.IDX + " id='installmentAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        instaledit = "<input id='btninstallmentEdit' disabled='disabled' type='button'  class='btn btn-success InstalEditbtn' data-installmentid=" + data.IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                    }
                    else {
                        instalAprove = "<input type='button'  class='btn btn-success InstalAprovebtn' data-installmentapproveid=" + data.IDX + " id='installmentAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        instaledit = "<input id='btninstallmentEdit' type='button'  class='btn btn-success InstalEditbtn' data-installmentid=" + data.IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                    }
                    var InstalModeDropdown = "<select class='form-control' id='ddlInstalEdit' style='display:none'  disabled='disabled'><option value='SELECT INSTALLMENT MODE'>SELECT INSTALLMENT MODE</option><option value='UPFRONT PAYMENT'>UPFRONT PAYMENT</option><option value='QUARTERLY IN ADVANCE'>QUARTERLY IN ADVANCE</option><option value='QUARTERLY IN ARREARS'>QUARTERLY IN ARREARS</option><option value='WITHIN 90 DAYS'>WITHIN 90 DAYS</option></select>";
                    var fillInstallmentDetail = "<tr><td>" + data.DEPARTMENT + "</td><td><label id='txtInstalMode'>" + data.INSTALLMENT_MODE + "</label>" + InstalModeDropdown + "</td><td>" + data.STATUS + "</td><td>" + instaledit + "</td><td>" + instalAprove + "</td></tr>";

                    $('#tblInstalment tbody').append(fillInstallmentDetail);


                    // $(this).closest('tr').find('#ddlInstalEdit option:selected').text(data.INSTALLMENT_MODE);




                    var statusidx = localStorage.getItem('statusidx');
                    if (statusidx == "30" || statusidx == "40" || statusidx == "50" || statusidx == "90" || statusidx == "91" || statusidx == "70") {
                        $('#btninstallmentEdit').prop('disabled', true);
                        $('#installmentAprove').prop('disabled', true);
                        $('.InstalAprovebtn').prop('disabled', true);
                        $('.InstalEditbtn').prop('disabled', true);
                        //$('.InstalAprovebtn').hide();
                        //$('.InstalEditbtn').hide();
                    }



                });
            }
        },
        error: function (request) {

        }
    });

}
function insertBank() {

    var sel = document.getElementById("ddlBank");
    var listLength = sel.options.length;
    for (var i = 0; i < listLength; i++) {
        if (sel.options[i].selected) {
            var bankCode = sel.options[i].value;


            var ajax_data = {
                bankCode: bankCode
            };
            $.ajax({
                url: "api/ClientForm/GetInsertBank",
                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {




                },
                error: function (request) {

                }
            });

        }

    }




}


$(document).on('click', 'input[class="checkboxCommissions"]', function () {
    var ComissionStatusidx = (this.checked ? $(this).val() : "");
    var ComissionTo = (this.checked ? $(this).siblings('label').html() : "");

    if (confirm("Are You Sure Forward Over Commission to !  " + ComissionTo)) {

        var ajax_data = {
            statusid: ComissionStatusidx,
            AssignTouser: ComissionTo

        };
        $.ajax({
            url: "api/ClientForm/GetCommissionStatus",

            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {


                alert('Successfully Forward Over Commission to  ' + ComissionTo)
                window.location = "ClientDetails.aspx";
            },
            error: function (request) {

            }
        });

    }


    else {

        this.checked = false;
    }

});


$(document).on('click', '#btnFinalizeStandardRate', function () {

    var standardRateStatus = [];
    var AgentRateDiff = [];
    var installmentMode = [];
    var statusid, AssignTouser;

    var statusidx = localStorage.getItem('statusidx');
    if (statusidx == "30" || statusidx == "40" || statusidx == "50") {

        if (confirm("Are You Sure to Finalize Client !")) {

            // Business Rate Approval ///
            var StandardRatetable = document.getElementById('tblBusClass');
            if (StandardRatetable.rows.length > 1) {
                for (var i = 1; i < StandardRatetable.rows.length; i++) {

                    var AproveStatus = (StandardRatetable.rows[i].cells[8].textContent.trim());
                    standardRateStatus.push({ "STATUS": AproveStatus });

                }
            }

            var ApproveStatus = $.grep(standardRateStatus, function (v) {
                return v.STATUS == "NOT APPROVE";
            });

            if (ApproveStatus.length > 0) {
                alert('Please Approve All Rate Then Finalize');
            }
            else {
                // Agent Rate Approval ///
                var AgentRatetable = document.getElementById('tblAproveAgentRate');
                var installmenttable = document.getElementById('tblInstalment');

                if (AgentRatetable.rows.length > 1) {
                    for (var i = 1; i < AgentRatetable.rows.length; i++) {

                        var AproveRateDiff = (AgentRatetable.rows[i].cells[7].textContent.trim());
                        AgentRateDiff.push({ "RATE_DIFF": AproveRateDiff });

                    }

                }
                var AgentRateStatus = $.grep(AgentRateDiff, function (v) {
                    return v.RATE_DIFF != "0";
                });


                // Installment Mode Approval///
                debugger
                $('#tblInstalment').find('tr').each(function (i, el) {
                    if (i == 0) {

                    }
                    else {
                        var instalValue = $(this).closest('tr').find("label[id=txtInstalMode]").text()
                        installmentMode.push({ "INSTAL_MODE": instalValue });
                    }

                });




                var InstalModeStatus = $.grep(installmentMode, function (v) {
                    return v.INSTAL_MODE != "UPFRONT PAYMENT";
                });


                // Forward ti Murtaza over commission///
                if (AgentRateStatus.length > 0) {
                    statusid = "70";
                    AssignTouser = "MURTAZA.H";
                }
                // Forward to zeeshan lilani for Installment Mode/////
                else if (InstalModeStatus.length > 0) {
                    statusid = "80";
                    AssignTouser = "ZEESHANLILANI";
                }

                else {
                    statusid = "90";
                    AssignTouser = "IT";
                }
                if (cfEdit == undefined) {
                    cfEdit = "";
                } else {
                    cfEdit = cfEdit;
                }





                var ajax_data = {
                    statusid: statusid,
                    AssignTouser: AssignTouser,
                    cfEdit: cfEdit

                };
                $.ajax({
                    url: "api/ClientForm/GetForwardStatus",

                    type: 'GET',
                    dataType: 'json',
                    data: ajax_data,
                    success: function (data) {


                        alert('Successfully Forward To  ' + AssignTouser);
                        window.location = "ClientDetails.aspx";
                    },
                    error: function (request) {

                    }
                });
            }
        }
        else {
        }
    }

});


//$(document).on('change', '.radioCheck', function () {
//    var chkFiler = $(this).val();
//    alert(chkFiler);
//});

////$(document).on("#AproveBuclassRateCheck").change(function () {

////        if (confirm("Are You Sure You Want To Approve Rate !")) {


////        }
////        else {
////            $("#AproveBuclassRateCheck").prop("checked", false);
////    }

////});




function GetFinalizeClient() {

    var ajax_data = {

        statusidx: '90'
    };
    $.ajax({
        url: "api/ClientForm/GetFinalizeClient",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            LoadFinalizeClient(data);

        },
        error: function (request) {

        }
    });

}

function LoadFinalizeClient(data) {



    if ($.fn.dataTable.isDataTable('#tblFinalize')) {
        accounttablevar = $('#tblFinalize').DataTable().clear().destroy();
    }
    accounttablevar = $('#tblFinalize').dataTable({

        "language": {
            "info": "_END_ of _TOTAL_"
        },
        bAutoWidth: false,

        responsive: {
            details: {
                type: 'column',
                target: 'tr'
            }
        },
        "sPaginationType": "simple",
        data: data,
        columnDefs: [{ "width": "10%", "targets": 1 }],
        dom: 'Bfrtip',
        select: true,



        "columns": [

            { "data": "CF_ID" },
            {
                "data": "PLC_LOCADESC"
            },
            { "data": "CLIENT_NAME" },
            { "data": "CLIENT_CNIC" },
            { "data": "REQUESTUSER" },
            { "data": "REQUEST_DATE" },
            { "data": "ASSIGNUSER" },
            { "data": "ASSIGNEDTO" },




            { "data": "CLIENT_TYPE" },

            //{
            //    "mRender": function (data, type, full) {
            //        return '<a class="btn btn-success" style="font-size: 12px;background-color: #096735;"  data-toggle="modal" data-target="#myModal" onclick=viewcomments("' + full["CF_ID"] + '") data-th ="' + full["CF_ID"] + '" href="#" >' + ' View Comments' + '</a> ';
            //    }
            //},

        ],
    });

}



$(document).on('click', '#btnSearchFinalize', function () {

    var ajax_data = {

        todate: $('#txtFinalizeToDate').val(),
        toform: $('#txtFinalizeFromDate').val()
    };

    $.ajax({
        url: "api/ClientForm/GetFinalizeClientSearch",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {


            LoadFinalizeClient(data);
        },
        error: function (request) {

        }
    });


});



$(document).on('click', '#btnAddClientDetail', function () {

    if (cfEdit != undefined) {
        $('#ClientMenu a[href="#Address"]').tab('show');
    }
    else {
        var cat = $('#ddlCategory option:selected').text();
        if ($('#txtNic').valid()) {
            if ($('#txtName').valid()) {
                if ($('#txtIssueDate').valid()) {
                    if ($('#ddlCategory').valid()) {
                        if ($('#ddlPrefix').valid()) {
                            if ($('#txtExpireDate').valid()) {
                                var issuedate = new Date(Date.parse($("#txtIssueDate").val()));
                                var expiredate = new Date(Date.parse($("#txtExpireDate").val()));
                              
                                if (expiredate > issuedate) {
                                    var chkCompliencefiles = $("#ComplienceFileUpload").get(0).files;

                                    if (chkCompliencefiles.length > 0) {


                                        

                                        if (cat == 'CORPORATE') {
                                            if ($('#txtNTN').valid()) {
                                                InsertClientDetail();
                                                AddComplienceDocument();
                                            }
                                            //else {
                                            //    alert('Please Add NTN Number !');
                                            //}
                                        }
                                        else if (cat == 'INDIVIDUAL') {
                                            InsertClientDetail();
                                            AddComplienceDocument();
                                        }

                                    }




                                    else {
                                        alert('Please Must be Attach CNIC ! ')
                                    }
                                }
                                else {
                                    alert("Issue date is greater than Expiry date !");
                                }
                            }
                        }
                    } else {

                    }
                }
            }

            else {

            }

        }
    }












});

function InsertClientDetail() {
    var filer;
    $(document).on('input[class="radioCheck"]:checked').each(function () {
        filer = ($('input[class="radioCheck"]:checked').val());
        if (filer == undefined) {
            filer = "";
        }
        else {
            filer = filer;
        }

    });
    var prefix = $('#ddlPrefix option:selected').val();
    if (prefix == "Select Prefix") {
        prefix = '';
    }
    else {
        prefix = prefix;
    }


    if (cfEdit != undefined) {


        var ajax_data = {

            Branch: $('#ddlBranch option:selected').val(),
            clientType: $('#ddlCategory option:selected').text().toUpperCase(),
            Prefix: prefix,
            ClientName: $('#txtName').val().toUpperCase(),
            CNIC: $('#txtNic').val(),
            issueDate: $('#txtIssueDate').val(),
            CNICExpiry: $('#txtExpireDate').val(),
            NTN: $('#txtNTN').val(),
            GST: $('#txtSTN').val(),
            filer: filer.toUpperCase(),
            cfEdit: cfEdit


        };
        $.ajax({
            url: "api/ClientForm/GetInsertClientDetailUpdate",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {

                $('#ClientMenu a[href="#Address"]').tab('show');

            },
            error: function (request) {

            }
        });
    }
    else {



        var clientback = $('#btnBackClientDet').val();
        if (clientback == '1') {
            var ajax_data = {

                CFID: 'CF-',
                Branch: $('#ddlBranch option:selected').val(),
                clientType: $('#ddlCategory option:selected').text().toUpperCase(),
                Prefix: prefix,
                ClientName: $('#txtName').val().toUpperCase(),
                CNIC: $('#txtNic').val(),
                issueDate: $('#txtIssueDate').val(),
                CNICExpiry: $('#txtExpireDate').val(),
                NTN: $('#txtNTN').val(),
                GST: $('#txtSTN').val(),
                filer: filer.toUpperCase()


            };
            $.ajax({
                url: "api/ClientForm/GetInsertAlreadyClientDetailUpdate",
                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {
                    $('#ClientMenu a[href="#Address"]').tab('show');
                    //AddfilerDocument();
                    //var filerLength = $("#filerFileUpload").get(0).files;
                    //if (filerLength.length > 0) {

                    //    $('#ClientMenu a[href="#Address"]').tab('show');

                    //}
                    //else {
                    //    alert('Please Must Be Attach Filer Document !')
                    //}
                },
                error: function (request) {

                }
            });
        }
        else {
            var ajax_data = {

                CFID: 'CF-',
                Branch: $('#ddlBranch option:selected').val(),
                clientType: $('#ddlCategory option:selected').text().toUpperCase(),
                Prefix: prefix,
                ClientName: $('#txtName').val().toUpperCase(),
                CNIC: $('#txtNic').val(),
                issueDate: $('#txtIssueDate').val(),
                CNICExpiry: $('#txtExpireDate').val(),
                NTN: $('#txtNTN').val(),
                GST: $('#txtSTN').val(),
                filer: filer.toUpperCase()


            };
            $.ajax({
                url: "api/ClientForm/GetInsertClientDetail",
                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {
                    //var filerLength = $("#filerFileUpload").get(0).files;
                    //if (filerLength.length > 0) {
                    //    AddfilerDocument();
                    //    $('#ClientMenu a[href="#Address"]').tab('show');

                    //}
                    //else {
                    //    alert('Please Must Be Attach Filer Document !')
                    //}

                    AddfilerDocument();
                    $('#ClientMenu a[href="#Address"]').tab('show');

                },
                error: function (request) {

                }
            });
        }
    }
}

$(document).on('click', '#btnBackClientDet', function () {
    $('#btnBackClientDet').val('1');
    $('#ClientMenu a[href="#home-v"]').tab('show');


});
$(document).on('click', '#btnAddAddresss', function () {
    InsertAddress();

});
$(document).on('click', '#Address', function () {

    GetMyTask();
});


$(document).on('click', '#btnContactPersonList', function () {

    if ($('#txtContactPerson').valid()) {
        if ($('#txtDesgRef').valid()) {
            if ($('#txtContactPersonMobile').valid()) {
                $('#tblContactPerson').show();
                var ContactPerson = $("#txtContactPerson").val().toUpperCase();
                var Designation = $("#txtDesgRef").val().toUpperCase();
                var mobile = $("#ddlContactPersonMobCode option:selected").text() + '-' + $("#txtContactPersonMobile").val();
                var email = $("#txtContactPersonEamil").val().toUpperCase();


                var ContactPersonList = "<tr><td>" + ContactPerson + "</td><td>" + Designation + "</td><td>" + mobile + "</td><td>" + email + "</td><td><span onclick='DeleteTempContactPerson(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";
                $("#tblContactPerson tbody").append(ContactPersonList);

                $('#txtContactPerson').val('');
                $('#txtDesgRef').val('');
                $('#txtContactPersonMobile').val('');
                $('#txtContactPersonEamil').val('');

            }
        } else {

        }
    } else {

    }


});


function DeleteContactPerson(contactPErsonIdx) {
    if (confirm("Are You Sure You want to delete !")) {

        var contactPErsonIdx = $(contactPErsonIdx).attr("value");
        var ajaxConPerDelete = {
            contactPErsonIdx: contactPErsonIdx
        };

        $.ajax({
            url: "api/ClientForm/GetDeleteContactPerson",
            type: 'GET',
            dataType: 'json',
            data: ajaxConPerDelete,
            success: function (data) {
                onLoadContactPErson(cfEdit);
                alert('Delete Successfully !')
            },
            error: function (request) {

            }
        });
    }
    else {

    }


}
function DeleteAddress(contactPErsonIdx) {
    if (confirm("Are You Sure You want to delete !")) {
        debugger

        var AddressIdx = $(contactPErsonIdx).attr("value");
        var ajaxConPerDelete = {
            AddressIdx: AddressIdx
        };

        $.ajax({
            url: "api/ClientForm/GetDeleteAddress",
            type: 'GET',
            dataType: 'json',
            data: ajaxConPerDelete,
            success: function (data) {
                OnLoadAddressBind(cfEdit);
                alert('Delete Successfully !')
            },
            error: function (request) {

            }
        });
    }
    else {

    }


}

function DeleteBusClass(BusClassIdx) {
    if (confirm("Are You Sure You want to delete !")) {

        var BusniesClassIdx = $(BusClassIdx).attr("value");
        var ajaxBusClassDelete = {
            BusniesClassIdx: BusniesClassIdx
        };

        $.ajax({
            url: "api/ClientForm/GetDeleteBusClass",
            type: 'GET',
            dataType: 'json',
            data: ajaxBusClassDelete,
            success: function (data) {
                GetFillBusClassDetail(cfEdit);
                alert('Delete Successfully !')
            },
            error: function (request) {

            }
        });
    }
    else {

    }
}
function InsertContactPerson() {


    var ContPersontable = document.getElementById('tblContactPerson');
    if (cfEdit != undefined) {
        var ajax_data = {
            CF_ID: cfEdit
        };


        $.ajax({
            url: "api/ClientForm/GetContactPerson",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {


                if (data.length > 0) {
                    if (ContPersontable.rows.length > 0) {

                        for (var i = 1; i < ContPersontable.rows.length; i++) {
                            if (ContPersontable.rows[i].cells.length) {
                                var contactPerson = (ContPersontable.rows[i].cells[0].textContent.trim());
                                var designation = (ContPersontable.rows[i].cells[1].textContent.trim());
                                var mobile = (ContPersontable.rows[i].cells[2].textContent.trim());
                                var email = (ContPersontable.rows[i].cells[3].textContent.trim());



                                var ajax_data = {
                                    contactPerson: contactPerson.toUpperCase(),
                                    designation: designation.toUpperCase(),
                                    mobile: mobile,
                                    email: email,
                                    cfEdit: cfEdit

                                };


                                $.ajax({
                                    url: "api/ClientForm/GetUpdateContactPErson",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#OtherDetails"]').tab('show');
                                        $('#ContactInfo').hide();
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Add Contact Person !');
                    }
                }
                else {
                    if (ContPersontable.rows.length > 0) {

                        for (var i = 1; i < ContPersontable.rows.length; i++) {
                            if (ContPersontable.rows[i].cells.length) {
                                var contactPerson = (ContPersontable.rows[i].cells[0].textContent.trim());
                                var designation = (ContPersontable.rows[i].cells[1].textContent.trim());
                                var mobile = (ContPersontable.rows[i].cells[2].textContent.trim());
                                var email = (ContPersontable.rows[i].cells[3].textContent.trim());



                                var ajax_data = {
                                    contactPerson: contactPerson.toUpperCase(),
                                    designation: designation.toUpperCase(),
                                    mobile: mobile,
                                    email: email,
                                    cfEdit: cfEdit

                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertUpdateContactPErson",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#OtherDetails"]').tab('show');
                                        $('#ContactInfo').hide();
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Add Contact Person !');
                    }
                }
            },
            error: function (request) {

            }
        });


    }
    else {

        var ajax_data = {

        };


        $.ajax({
            url: "api/ClientForm/GetInsertAlreadyContactPerson",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {


                if (data.length > 0) {
                    if (ContPersontable.rows.length > 1) {

                        for (var i = 1; i < ContPersontable.rows.length; i++) {
                            if (ContPersontable.rows[i].cells.length) {
                                var contactPerson = (ContPersontable.rows[i].cells[0].textContent.trim());
                                var designation = (ContPersontable.rows[i].cells[1].textContent.trim());
                                var mobile = (ContPersontable.rows[i].cells[2].textContent.trim());
                                var email = (ContPersontable.rows[i].cells[3].textContent.trim());



                                var ajax_data = {
                                    contactPerson: contactPerson.toUpperCase(),
                                    designation: designation.toUpperCase(),
                                    mobile: mobile,
                                    email: email

                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertUpdateContactPErson",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#OtherDetails"]').tab('show');
                                        $('#ContactInfo').hide();
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Add Contact Person !');
                    }

                }
                else {
                    if (ContPersontable.rows.length > 1) {

                        for (var i = 1; i < ContPersontable.rows.length; i++) {
                            if (ContPersontable.rows[i].cells.length) {
                                var contactPerson = (ContPersontable.rows[i].cells[0].textContent.trim());
                                var designation = (ContPersontable.rows[i].cells[1].textContent.trim());
                                var mobile = (ContPersontable.rows[i].cells[2].textContent.trim());
                                var email = (ContPersontable.rows[i].cells[3].textContent.trim());



                                var ajax_data = {
                                    contactPerson: contactPerson.toUpperCase(),
                                    designation: designation.toUpperCase(),
                                    mobile: mobile,
                                    email: email

                                };


                                $.ajax({
                                    url: "api/ClientForm/GetInsertContactPErson",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#OtherDetails"]').tab('show');
                                        $('#ContactInfo').hide();
                                    },
                                    error: function (request) {

                                    }
                                });

                            }
                        }
                    }
                    else {
                        alert('Please Add Contact Person !');
                    }

                }
            },
            error: function (request) {

            }
        });


    }



}
$(document).on('click', '#btnBackAddress', function () {

    $('#ClientMenu a[href="#Address"]').tab('show');

    $('#ContactInfo').hide();
});



$(document).on('click', '#btnAddContactInfo', function () {

    InsertContactPerson();

});


$(document).on('click', '#CFDetail', function () {
    GetMyTask();
});



function EmptyAddress() {
    document.getElementById("ddlAddressType").selectedIndex = 0;
    //$("#ddlAddressType option:selected").text(null).trigger('change');
    document.getElementById("txtAdress").value = "";
    document.getElementById("txtEmail").value = "";
    document.getElementById("ddlMobileCode").selectedIndex = 0;
    //$("#ddlMobileCode option:selected").text(null).trigger('change');
    document.getElementById("txtClientMobile").value = "";
    document.getElementById("ddlPtclCode").selectedIndex = 0;
    //$("#ddlPtclCode option:selected").text(ptclNo[0]).trigger('change');
    document.getElementById("txtPhone").value = "";

}

function EmptyContactPErson() {
    document.getElementById("txtContactPerson").value = "";
    document.getElementById("txtDesgRef").value = "";
    document.getElementById("txtContactPersonEamil").value = "";
    document.getElementById("ddlContactPersonMobCode").selectedIndex = 0;


    document.getElementById("txtContactPersonMobile").value = "";
}

$(document).on('click', '#addBusClass', function () {

    if ($('#ddlDeptment').valid()) {
        if ($('#ddlBusClassCat').valid()) {
            if ($('#ddlBusClass').valid()) {
                if ($('#ddlInsuranceType').valid()) {
                    if ($('#txtExposure').valid()) {
                        if ($('#txtRate').valid()) {

                            $('#tblBusClass').show();
                            var dept = $("#ddlDeptment option:selected").text();
                            var Category = $("#ddlBusClassCat option:selected").text().toUpperCase();
                            var busClass = $("#ddlBusClass option:selected").text();
                            var InsuranceType = $("#ddlInsuranceType option:selected").text();
                            var exposure = $("#txtExposure").val().toUpperCase();
                            var Rate = $("#txtRate").val();

                            var AddBusClass = "<tr><td>" + dept + "</td><td>" + Category + "</td><td>" + busClass + "</td><td>" + InsuranceType + "</td><td>" + exposure + "</td><td>" + Rate + "</td><td><span onclick='DeleteTempBusClass(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";

                            $("#tblBusClass tbody").append(AddBusClass);
                        }
                    }
                }
            }
        } else {

        }
    }
});

$(document).on('click', '#btnAddBusniessInfo', function () {
    //InsertBusclass();
    $('#ClientMenu a[href="#AgentProducer"]').tab('show');
});
function EmptyBusClassRat() {
    document.getElementById("ddlDeptment").selectedIndex = 0;
    document.getElementById("ddlBusClassCat").selectedIndex = 0;
    document.getElementById("ddlBusClass").selectedIndex = 0;
    document.getElementById("ddlInsuranceType").selectedIndex = 0;

    document.getElementById("txtExposure").value = "";
    document.getElementById("txtRate").value = "";
}


$(document).on('click', '#btnBackOtherDetail', function () {
    $('#ClientMenu a[href="#OtherDetails"]').tab('show');

});
$(document).on('click', '#btnBackContactInfo', function () {

    if ($('#ddlCategory option:selected').text() == 'INDIVIDUAL') {
        //$("#ddlPrefix option:selected").val(002).trigger('change');
        $('#ContactInfo').hide();
        $('#ClientMenu a[href="#Address"]').tab('show');
        $('#STNDiv').hide();
    }
    else {
        $('#ContactInfo').show();
        $('#ClientMenu a[href="#ContactInfo"]').tab('show');
        $('#STNDiv').show();

    }





});
$(document).on('click', '#btnAddOtherDetails', function () {
    $('#btnBackBusniessInfo').val('');
    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'OperationHead' || UserRole == 'IT' || UserRole == 'AML' || UserRole == 'OverComission') {
        $('#ClientMenu a[href="#BusniessInfo"]').tab('show');


    } else {

        if ($('#txtReference').valid()) {
            insertOtherDetail();
        }

    }

});


function insertOtherDetail() {

    var group, compIndus, bank, ownership = '';
    if ($("#ddlGroupName option:selected").text() == 'Select Group' || $("#ddlGroupName option:selected").text() == undefined || $("#ddlGroupName option:selected").text() == "") {
        group = '';
    }
    else {
        group = $("#ddlGroupName option:selected").val();
    }
    if ($("#ddlCompIndustry option:selected").text() == 'Select Company Industory' || $("#ddlCompIndustry option:selected").text() == "" || $("#ddlCompIndustry option:selected").text() == undefined) {
        compIndus = '';
    }
    else {
        compIndus = $("#ddlCompIndustry option:selected").val();
    }

    if ($("#ddlBank option:selected").text() == 'Select Bank' || $("#ddlBank option:selected").text() == "" || $("#ddlBank option:selected").text() == undefined) {
        bank = '';
    }
    else {
        bank = $("#ddlBank option:selected").val();
    }
    if ($('#ddlOwnership option:selected').text() == "" || $('#ddlOwnership option:selected').text() == undefined) {
        ownership = '';
    }
    else {
        ownership = $('#ddlOwnership option:selected').val();
    }
    var resident;
    $(document).on('input[class="ResidentrCheck"]:checked').each(function () {
        resident = ($('input[class="ResidentrCheck"]:checked').val());
        if (resident == undefined) {
            resident = "";

        }
        else {
            resident = resident;
        }
    });
    var pep;
    $(document).on('input[class="PepCheck"]:checked').each(function () {
        pep = ($('input[class="PepCheck"]:checked').val());
        if (pep == undefined) {
            pep = "";

        }
        else {
            pep = pep;
        }
    });
    //var ownership = $('#ddlOwnership option:selected').val();
    var SoI = $('#txtSourceIncome').val();
    if (cfEdit != undefined) {

        var ajax_data = {

            reference: $('#txtReference').val().toUpperCase(),
            GroupName: group,
            bank: bank,
            CompIndust: compIndus,
            resident: resident.toUpperCase(),
            pep: pep.toUpperCase(),
            ownership: ownership,
            SoI: SoI.toUpperCase(),
            cfEdit: cfEdit

        };
        console.log(ajax_data);
        $.ajax({
            url: "api/ClientForm/GetUpdateOtherDetail",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {
                $('#ClientMenu a[href="#BusinessDetail"]').tab('show');

            },
            error: function (request) {

            }
        });
    }
    else {

        var ajax_data = {

            reference: $('#txtReference').val().toUpperCase(),
            GroupName: group,
            bank: bank,
            CompIndust: compIndus,
            resident: resident.toUpperCase(),
            pep: pep.toUpperCase(),
            ownership: ownership,
            SoI: SoI.toUpperCase()


        };
        $.ajax({
            url: "api/ClientForm/GetInsertUpdateOtherDetail",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {
                $('#ClientMenu a[href="#BusinessDetail"]').tab('show');

            },
            error: function (request) {

            }
        });
    }

}


function EmptyOtherDetail() {

    document.getElementById("ddlCompIndustry").selectedIndex = 0;
    document.getElementById("ddlBank").selectedIndex = 0;
    document.getElementById("ddlGroupName").selectedIndex = 0;
    document.getElementById("txtReference").value = "";

}

$(document).on('click', '#btnBackBusniessInfo', function () {
    $('#btnBackBusniessInfo').val('BusBack');
    $('#ClientMenu a[href="#OtherDetails"]').tab('show');

});
$(document).on('click', '#btnBackBusniessInfoAproval', function () {

    $('#ClientMenu a[href="#BusniessInfo"]').tab('show');

});

$(document).on('click', '#btnAddAgentProducerAproval', function () {

    $('#ClientMenu a[href="#Compliance"]').tab('show');

});
function GetProducer() {
    var ajax_data = {};
    $.ajax({
        url: "api/ClientForm/GetProducer",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                $('#ddlProducer').empty();
                $('#ddlProducer').append("<option>Select Producer</option>")
                for (var i = 0; i < data.length; i++) {

                    $('#ddlProducer').append("<option value='" + data[i].PDO_DEVOFFCODE + "'>" + data[i].PRODUCER + "</option>");
                }



            }

        },
        error: function (request) {

        }
    });
}

$(document).on('change', "#ddlAppDept", function () {

    BusclassAgentWise();


});

function BusclassAgentWise() {
    var dept = $('#ddlAppDept option:selected').text();
    var busclas = $('#ddlApprBusClassCat option:selected').text();
    var ajax_data = {
        dept: dept,
        busclas: busclas.toUpperCase()

    };
    $.ajax({
        url: "api/ClientForm/GetBusClass",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            if (data.length > 0) {
                $('#ddlApprBusClass').empty();
                for (var i = 0; i < data.length; i++) {

                    $('#ddlApprBusClass').append("<option value='" + data[i].PBC_BUSICLASS_CODE + "'>" + data[i].PBC_DESC + "</option>");
                }



            }

        },
        error: function (request) {

        }
    });
}
$(document).on('click', '#btnAddAgentProducer', function () {


    if ($('#ddlProducer').valid()) {
        if ($('#ddlAgent').valid()) {
            InsertAppBusClassRate();
        }


    }


});


function InsertAppBusClassRate() {
    debugger
    var BusClasRateTbl = document.getElementById('tblAgentBusClassRate');
    if (cfEdit != undefined) {

        if ($('#btnBackBusniessInfo').val() == "BusBack") {

            //var UserRole = localStorage.getItem('UserRole');
            //if (UserRole == 'OperationHead') {
            //    $('#ClientMenu a[href="#BusinessDetail"]').tab('show');
            //}
            //else {
            //    $('#ClientMenu a[href="#AgentProducer"]').tab('show');
            //}

            $('#ClientMenu a[href="#Compliance"]').tab('show');
        }

        else {
            var ajax_data = {
                cfEdit: cfEdit

            };
            $.ajax({
                url: "api/ClientForm/GetLoadBusClassAgentRate",
                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {
                    if (data.length > 0) {


                        $('#ClientMenu a[href="#Compliance"]').tab('show');


                    }
                    else {
                        if (BusClasRateTbl.rows.length > 1) {

                            for (var i = 1; i < BusClasRateTbl.rows.length; i++) {
                                if (BusClasRateTbl.rows[i].cells.length) {
                                    var Dept = (BusClasRateTbl.rows[i].cells[0].textContent.trim());
                                    var insuraceCat = (BusClasRateTbl.rows[i].cells[1].textContent.trim());
                                    var Busclass = (BusClasRateTbl.rows[i].cells[2].textContent.trim());
                                    var insuranceType = (BusClasRateTbl.rows[i].cells[3].textContent.trim());
                                    var exposure = (BusClasRateTbl.rows[i].cells[4].textContent.trim());
                                    var StandardRate = (BusClasRateTbl.rows[i].cells[5].textContent.trim());
                                    var StandardRateType = (BusClasRateTbl.rows[i].cells[6].textContent.trim());
                                    var StandardRateAgent = (BusClasRateTbl.rows[i].cells[7].textContent.trim());
                                    var agentRate = (BusClasRateTbl.rows[i].cells[8].textContent.trim());
                                    var agentRateType = (BusClasRateTbl.rows[i].cells[9].textContent.trim());
                                    var agentType = (BusClasRateTbl.rows[i].cells[10].textContent.trim());
                                    var instalmentMode = (BusClasRateTbl.rows[i].cells[11].textContent.trim());
                                    var ajax_data = {
                                        Dept: Dept,
                                        insuraceCat: insuraceCat.toUpperCase(),
                                        Busclass: Busclass,
                                        insuranceType: insuranceType,
                                        exposure: exposure,
                                        StandardRate: StandardRate,
                                        StandardRateType: StandardRateType,
                                        StandardRateAgent: StandardRateAgent,
                                        agentRate: agentRate,
                                        agentRateType: agentRateType,
                                        agentType: agentType,
                                        instalmentMode: instalmentMode,
                                        cfEdit: cfEdit


                                    };


                                    $.ajax({
                                        url: "api/ClientForm/GetUpdateBusClassAndAgentRate",
                                        type: 'GET',
                                        dataType: 'json',
                                        data: ajax_data,
                                        success: function (data) {

                                            var ajax_data = {

                                                Producer: $('#ddlProducer option:selected').val(),
                                                Agent: $('#ddlAgent option:selected').val(),
                                                cfEdit: cfEdit

                                            };
                                            $.ajax({
                                                url: "api/ClientForm/GetUpdateBusClassAgentRate",
                                                type: 'GET',
                                                dataType: 'json',
                                                data: ajax_data,
                                                success: function (data) {

                                                    $('#ClientMenu a[href="#Compliance"]').tab('show');

                                                },
                                                error: function (request) {

                                                }
                                            });

                                        },
                                        error: function (request) {

                                        }
                                    });

                                }
                            }
                        }
                        else {
                            alert('Please Add Commission Rates !');
                        }
                    }

                },
                error: function (request) {

                }
            });




        }

    }
    else {


        if ($('#btnBackBusniessInfo').val() == "BusBack" || $('#btnBackAgentProducer').val() == "BackBusDetail") {


            $('#ClientMenu a[href="#Compliance"]').tab('show');
            ////var UserRole = localStorage.getItem('UserRole');
            ////if (UserRole == 'OperationHead') {
            ////    $('#ClientMenu a[href="#BusinessDetail"]').tab('show');
            ////}
            ////else {
            ////    $('#ClientMenu a[href="#AgentProducer"]').tab('show');
            ////}

        }

        else {

            if (BusClasRateTbl.rows.length > 1) {

                for (var i = 1; i < BusClasRateTbl.rows.length; i++) {
                    if (BusClasRateTbl.rows[i].cells.length) {
                        var Dept = (BusClasRateTbl.rows[i].cells[0].textContent.trim());
                        var insuraceCat = (BusClasRateTbl.rows[i].cells[1].textContent.trim());
                        var Busclass = (BusClasRateTbl.rows[i].cells[2].textContent.trim());
                        var insuranceType = (BusClasRateTbl.rows[i].cells[3].textContent.trim());
                        var exposure = (BusClasRateTbl.rows[i].cells[4].textContent.trim());
                        var StandardRate = (BusClasRateTbl.rows[i].cells[5].textContent.trim());
                        var StandardRateType = (BusClasRateTbl.rows[i].cells[6].textContent.trim());
                        var StandardRateAgent = (BusClasRateTbl.rows[i].cells[7].textContent.trim());
                        var agentRate = (BusClasRateTbl.rows[i].cells[8].textContent.trim());
                        var agentRateType = (BusClasRateTbl.rows[i].cells[9].textContent.trim());
                        var agentType = (BusClasRateTbl.rows[i].cells[10].textContent.trim());
                        var instalmentMode = (BusClasRateTbl.rows[i].cells[11].textContent.trim());
                        var ajax_data = {
                            Dept: Dept,
                            insuraceCat: insuraceCat.toUpperCase(),
                            Busclass: Busclass,
                            insuranceType: insuranceType,
                            exposure: exposure,
                            StandardRate: StandardRate,
                            StandardRateType: StandardRateType,
                            StandardRateAgent: StandardRateAgent,
                            agentRate: agentRate,
                            agentRateType: agentRateType,
                            agentType: agentType,
                            instalmentMode: instalmentMode,


                        };



                        $.ajax({
                            url: "api/ClientForm/GetInsertBusClassRate",
                            type: 'GET',
                            dataType: 'json',
                            data: ajax_data,
                            success: function (data) {

                                var ajax_data = {

                                    Producer: $('#ddlProducer option:selected').val(),
                                    Agent: $('#ddlAgent option:selected').val()

                                };
                                $.ajax({
                                    url: "api/ClientForm/GetUpdateBusClassRate",
                                    type: 'GET',
                                    dataType: 'json',
                                    data: ajax_data,
                                    success: function (data) {

                                        $('#ClientMenu a[href="#Compliance"]').tab('show');

                                    },
                                    error: function (request) {

                                    }
                                });

                            },
                            error: function (request) {

                            }
                        });

                    }
                }
            }
            else {
                alert('Please Add Commission Rates !');
            }

        }
    }
}


$(document).on('click', '#btnBackAgentProducer', function () {

    $('#btnBackAgentProducer').val('BackBusDetail');
    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'OperationHead' || UserRole == 'IT' || UserRole == 'AML' || UserRole == 'OverComission') {
        $('#ClientMenu a[href="#AgentProducer"]').tab('show');
    }
    else {
        $('#ClientMenu a[href="#BusinessDetail"]').tab('show');
    }








});


function EmptyBusClasssRate() {
    document.getElementById("ddlAppDept").selectedIndex = 0;
    document.getElementById("ddlApprBusClassCat").selectedIndex = 0;
    document.getElementById("ddlApprBusClass").selectedIndex = 0;
    document.getElementById("ddlProducer").selectedIndex = 0;
    document.getElementById("ddlAgent").selectedIndex = 0;
    document.getElementById("txtAggentRate").value = "";


}



$(document).on('click', '#btnAddCompliance', function () {
    debugger
    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'OperationHead' || UserRole == 'OverComission') {
        $('#ClientMenu a[href="#InstallmentMode"]').tab('show');


    } else {


        if ($('#ddlOwnership').valid()) {
            if ($('#txtSourceIncome').valid()) {

                InsertCompilence();
            }
        }
    }
});

function InsertCompilence() {

    var CRating = $('input[class="CustomerCheck"]:checked').val();
    if (CRating == undefined) {
        CRating = "";
    }
    else {
        CRating = CRating;
    }
    var TRating = $('input[class="TransactionCheck"]:checked').val();
    if (TRating == undefined) {
        TRating = "";
    }
    else {
        TRating = TRating;
    }

    var GRating = $('input[class="GeographicalCheck"]:checked').val();
    if (GRating == undefined) {
        GRating = "";
    }
    else {
        GRating = GRating;
    }

    if (cfEdit != undefined) {

        var ajax_data = {
            CRating: CRating.toUpperCase(),
            TRating: TRating.toUpperCase(),
            GRating: GRating.toUpperCase(),
            cfEdit: cfEdit


        };

        $.ajax({
            url: "api/ClientForm/GetEditUpdateComplience",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {

                //UpdateComplienceDocument(cfEdit);
                var UserRole = localStorage.getItem('UserRole');
                if (UserRole == 'IT' || UserRole == 'AML') {
                    $('#ClientMenu a[href="#InstallmentMode"]').tab('show');
                }
                else {
                    $('#ClientMenu a[href="#Attachment"]').tab('show');
                }


            },
            error: function (request) {

            }
        });

    }
    else {





        var ajax_data = {
            CRating: CRating.toUpperCase(),
            TRating: TRating.toUpperCase(),
            GRating: GRating.toUpperCase()



        };
        $.ajax({
            url: "api/ClientForm/GetUpdateComplience",
            type: 'GET',
            dataType: 'json',
            data: ajax_data,
            success: function (data) {
                $('#ClientMenu a[href="#Attachment"]').tab('show');
            },
            error: function (request) {

            }
        });


    }

}


function EmptyCompilence() {

    $(".CustomerCheck").prop("checked", false);
    $(".ResidentrCheck").prop("checked", false);
    $(".TransactionCheck").prop("checked", false);
    $(".GeographicalCheck").prop("checked", false);
    $('#chkPep').checked == false;
    document.getElementById("ddlOwnership").selectedIndex = 0;
    document.getElementById("txtSourceIncome").value = "";

}


$(document).on('click', '#btnBackCompliance', function () {

    $('#ClientMenu a[href="#Compliance"]').tab('show');

});



//$(document).on('click', '#addInstallment', function () {
//    if ($('#ddlDept').valid()) {
//        if ($('#ddlInstalMode').valid()) {

//            $('#tblInstalment').show();
//            var dept = $("#ddlDept option:selected").text();
//            var InstalmentMode = $("#ddlInstalMode option:selected").text();
//            var maAddInst = "<tr><td>" + dept + "</td><td>" + InstalmentMode + "</td><td><span onclick='DeleteInstallmentMode(this);' class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";
//            $("#tblInstalment tbody").append(maAddInst);
//        }
//    }

//});

//



$(document).on('click', '#btnAddInstallmentMode', function () {

    $('#ClientMenu a[href="#Attachment"]').tab('show');
});
//$(document).on('click', '#btnBackInstallmentMode', function () {

//    $('#ClientMenu a[href="#InstallmentMode"]').tab('show');
//});
//function EmptyInstallment() {
//    document.getElementById("ddlDept").selectedIndex = 0;
//    document.getElementById("ddlInstalMode").selectedIndex = 0;
//}

$(document).on('click', '#btnAddAttachment', function () {

    if (cfEdit != undefined) {
        $('#ClientMenu a[href="#Chat"]').tab('show');
        myDropzone.processQueue();
    }
    else {

        myDropzone.processQueue();
        $('#ClientMenu a[href="#Chat"]').tab('show');
    }

});
$(document).on('click', '#btnBackInstallmentMode', function () {
    var UserRole = localStorage.getItem('UserRole');
    if (UserRole == 'OperationHead' || UserRole == 'IT' || UserRole == 'AML' || UserRole == 'OverComission') {
        $('#ClientMenu a[href="#InstallmentMode"]').tab('show');
    }
    else {
        $('#ClientMenu a[href="#Compliance"]').tab('show');
    }



});

$(document).on('click', '#btnBackAttachment', function () {

    $('#ClientMenu a[href="#Attachment"]').tab('show');


});


$(document).on('click', '#btnFinalizeclientData', function () {

    ////if (cfEdit != undefined) {

    ////    var ajax_Data = {
    ////        cfEdit: cfEdit
    ////    };

    ////    $.ajax({
    ////        url: "api/ClientForm/GetUpdateClientAlready",
    ////        type: 'GET',
    ////        dataType: 'json',
    ////        data: ajax_Data,
    ////        success: function (data) {

    ////            if (data.length > 0) {

    ////                var rate = data[0].AGENT_RATE;

    ////                if (rate > 5) {
    ////                    $.ajax({
    ////                        url: "api/ClientForm/GetOverCommmisionName",
    ////                        type: 'GET',
    ////                        dataType: 'json',
    ////                        data: '',
    ////                        success: function (data) {

    ////                            if (data.length > 0) {
    ////                                var AssignTouser = 'MURTAZA.H';
    ////                                var ajax_data = {
    ////                                    statusid: '70',
    ////                                    AssignTouser: AssignTouser,
    ////                                    cfEdit: cfEdit

    ////                                };
    ////                                $.ajax({
    ////                                    url: "api/ClientForm/GetCommisionForwardStatus",

    ////                                    type: 'GET',
    ////                                    dataType: 'json',
    ////                                    data: ajax_data,
    ////                                    success: function (data) {


    ////                                        alert('Successfully Forward to  ' + AssignTouser + 'For Over Commission !')
    ////                                        window.location = "ClientDetails.aspx";
    ////                                    },
    ////                                    error: function (request) {

    ////                                    }
    ////                                });

    ////                            }

    ////                        },
    ////                        error: function (request) {

    ////                        }
    ////                    });



    ////                }
    ////                else {

    ////                    $.ajax({
    ////                        url: "api/ClientForm/GetNextForwardUSer",
    ////                        type: 'GET',
    ////                        dataType: 'json',
    ////                        data: '',
    ////                        success: function (data) {

    ////                            if (data.length > 0) {
    ////                                var nextuser = data[0].USERID;
    ////                                var statusid = data[0].STATUSIDX;
    ////                                var ajax_data = {
    ////                                    statusid: statusid,
    ////                                    AssignTouser: nextuser



    ////                                };
    ////                                $.ajax({
    ////                                    url: "api/ClientForm/GetForwardStatus",

    ////                                    type: 'GET',
    ////                                    dataType: 'json',
    ////                                    data: ajax_data,
    ////                                    success: function (data) {


    ////                                        alert('Successfully Forward to  ' + nextuser)
    ////                                        window.location = "ClientDetails.aspx";
    ////                                    },
    ////                                    error: function (request) {

    ////                                    }
    ////                                });

    ////                            }

    ////                        },
    ////                        error: function (request) {

    ////                        }
    ////                    });



    ////                }





    ////            }



    ////        },
    ////        error: function (request) {

    ////        }
    ////    });
    ////}
    ////else {

    ////    var ajax_Data = {

    ////    };
    ////    $.ajax({
    ////        url: "api/ClientForm/GetInsertClientAlready",
    ////        type: 'GET',
    ////        dataType: 'json',
    ////        data: ajax_Data,
    ////        success: function (data) {

    ////            if (data.length > 0) {

    ////                var rate = data[0].AGENT_RATE;

    ////                if (rate > 5) {
    ////                    $.ajax({
    ////                        url: "api/ClientForm/GetOverCommmisionName",
    ////                        type: 'GET',
    ////                        dataType: 'json',
    ////                        data: '',
    ////                        success: function (data) {

    ////                            if (data.length > 0) {
    ////                                var AssignTouser = 'MURTAZA.H';
    ////                                var ajax_data = {
    ////                                    statusid: '70',
    ////                                    AssignTouser: AssignTouser


    ////                                };
    ////                                $.ajax({
    ////                                    url: "api/ClientForm/GetInsertForwardStatus",

    ////                                    type: 'GET',
    ////                                    dataType: 'json',
    ////                                    data: ajax_data,
    ////                                    success: function (data) {


    ////                                        alert('Successfully Forward to  ' + AssignTouser + 'For Over Commission !')
    ////                                        window.location = "ClientDetails.aspx";
    ////                                    },
    ////                                    error: function (request) {

    ////                                    }
    ////                                });

    ////                            }

    ////                        },
    ////                        error: function (request) {

    ////                        }
    ////                    });



    ////                }
    ////                else {

    ////                    $.ajax({
    ////                        url: "api/ClientForm/GetNextForwardUSer",
    ////                        type: 'GET',
    ////                        dataType: 'json',
    ////                        data: '',
    ////                        success: function (data) {

    ////                            if (data.length > 0) {
    ////                                var nextuser = data[0].USERID;
    ////                                var statusid = data[0].STATUSIDX;
    ////                                var ajax_data = {
    ////                                    statusid: statusid,
    ////                                    AssignTouser: nextuser


    ////                                };
    ////                                $.ajax({
    ////                                    url: "api/ClientForm/GetForwardStatus",

    ////                                    type: 'GET',
    ////                                    dataType: 'json',
    ////                                    data: ajax_data,
    ////                                    success: function (data) {


    ////                                        alert('Successfully Forward to  ' + nextuser)
    ////                                        window.location = "ClientDetails.aspx";
    ////                                    },
    ////                                    error: function (request) {

    ////                                    }
    ////                                });

    ////                            }

    ////                        },
    ////                        error: function (request) {

    ////                        }
    ////                    });



    ////                }





    ////            }



    ////        },
    ////        error: function (request) {

    ////        }
    ////    });

    ////}

    if (confirm("Are You Sure You want to Finalize !")) {
        if (cfEdit == undefined) {
            cfEdit = "";
        } else {
            cfEdit = cfEdit;
        }
        var statusidx = localStorage.getItem('statusidx');
        if (statusidx == "10") {

            var ajax_data = {
                statusid: '30',
                AssignTouser: 'FAWWADD',
                cfEdit: cfEdit
            };
            $.ajax({
                url: "api/ClientForm/GetForwardStatus",

                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {


                    alert('Successfully Forward to   FAWWADD');
                    window.location = "ClientDetails.aspx";
                },
                error: function (request) {

                }
            });
        }
        else {

            $.ajax({
                url: "api/ClientForm/GetNextForwardUSer",
                type: 'GET',
                dataType: 'json',
                data: '',
                success: function (data) {


                    if (data.length > 0) {
                        var nextuser = data[0].USERID;
                        var statusid = data[0].STATUSIDX;
                        var ajax_data = {
                            statusid: statusid,
                            AssignTouser: nextuser,
                            cfEdit: cfEdit
                        };
                        $.ajax({
                            url: "api/ClientForm/GetForwardStatus",

                            type: 'GET',
                            dataType: 'json',
                            data: ajax_data,
                            success: function (data) {


                                alert('Successfully Forward to  ' + nextuser)
                                window.location = "ClientDetails.aspx";
                            },
                            error: function (request) {

                            }
                        });

                    }

                },
                error: function (request) {

                }
            });

        }



    }
    else {

    }



});

$(document).on('change', '#ddlDeptment', function () {

    BindBuscLass();

});

function BindBuscLass() {
    var busclasCat = $('#ddlBusClassCat option:selected').text();
    var Dept = $('#ddlDeptment option:selected').text();


    var ajax_data = {

        busclasCat: busclasCat.toUpperCase(),
        Dept: Dept

    };
    $.ajax({
        url: "api/ClientForm/GetLoadBusClass",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            if (data.length > 0) {
                $('#ddlBusClass').empty();
                for (var i = 0; i < data.length; i++) {

                    $('#ddlBusClass').append("<option value='" + data[i].PBC_BUSICLASS_CODE + "'>" + data[i].PBC_DESC + "</option>");
                }



            }
        },
        error: function (request) {

        }
    });
}
//function BindBuscLassUpdate(busclasCat, Dept) {


//    var ajax_data = {

//        busclasCat: busclasCat,
//        Dept: Dept

//    };
//    $.ajax({
//        url: "api/ClientForm/GetLoadBusClass",
//        type: 'GET',
//        dataType: 'json',
//        data: ajax_data,
//        success: function (data) {
//            if (data.length > 0) {
//                $('#ddlBusClass').empty();
//                for (var i = 0; i < data.length; i++) {

//                    $('#ddlBusClass').append("<option value='" + data[i].PBC_BUSICLASS_CODE + "'>" + data[i].PBC_DESC + "</option>");
//                }



//            }
//        },
//        error: function (request) {

//        }
//    });
//}

function AddComplienceDocument() {

    var dataNewPolReq = new FormData();
    var filesNewPolReq = $("#ComplienceFileUpload").get(0).files;

    // Add the uploaded image content to the form data collection
    if (filesNewPolReq.length > 0) {

        for (var x = 0; x <= filesNewPolReq.length; x++) {
            dataNewPolReq.append("documents", filesNewPolReq[x]);

        }
    }

    var ajaxRequest = $.ajax({
        type: "POST",
        url: "api/ClientForm/fileAttachComplience",
        contentType: false,
        processData: false,
        data: dataNewPolReq
    });

    ajaxRequest.done(function (xhr, textStatus) {


    });
}

function UpdateComplienceDocument(cfEdit) {

    var dataCompilenceUpdate = new FormData();

    var filesUpdateComplience = $("#ComplienceFileUpload").get(0).files;

    // Add the uploaded image content to the form data collection
    if (filesUpdateComplience.length > 0) {

        for (var x = 0; x <= filesUpdateComplience.length; x++) {
            dataCompilenceUpdate.append("documents", filesUpdateComplience[x]);

        }
    }

    dataCompilenceUpdate.append('cfid', cfEdit);


    var ajaxRequest = $.ajax({
        type: "POST",
        url: "api/ClientForm/fileUpdateAttachComplience",
        contentType: false,
        processData: false,
        data: dataCompilenceUpdate
    });

    ajaxRequest.done(function (xhr, textStatus) {


    });
}

function GetComplienceDocuments(CF_ID) {


    var ajax_data = {
        CF_ID: CF_ID,
        attachType: 'Compilence'
    }
        ;
    $.ajax({
        url: "api/ClientForm/GetCFDocuments",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {
            $('#list_gridDocComplience').show();
            $('#ComplDocList').remove();

            //$('#list_gridDocComplience').remove();
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {


                    var CompliencedocumentHtml = '<div id="ComplDocList"><div class="md-card" ><div class="md-card-head uk-text-center uk-position-relative" style="width: 148px;"><img class="md-card-head-img" src="images/document icon.png" style="height: 50%;margin-top: 15px;" alt="" /><a id="A1" target="_blank" runat="server" style="font-size: 12px" href="/documents/' + data[i].ATTACHMENT_PATH + '"><p style="margin-left: 0px;">' + data[i].ATTACHMENT_PATH + '</p></a> </a></div > ';
                    $('#list_gridDocComplience').append(CompliencedocumentHtml);
                }




            }

        },

        error: function (request) {

        }
    });
}



function AddfilerDocument() {

    var datafiler = new FormData();
    var filerFiles = $("#filerFileUpload").get(0).files;

    // Add the uploaded image content to the form data collection
    if (filerFiles.length > 0) {

        for (var x = 0; x <= filerFiles.length; x++) {
            datafiler.append("documents", filerFiles[x]);

        }
    }


    var ajaxRequest = $.ajax({
        type: "POST",
        url: "api/ClientForm/fileUpdateAttachFiler",
        contentType: false,
        processData: false,
        data: datafiler
    });

    ajaxRequest.done(function (xhr, textStatus) {
        $('#ClientMenu a[href="#Address"]').tab('show');
        $("#filerFileUpload").val(null);
    });
}

$(document).on('click', '#addAgentDeptWiseRate', function () {
    if ($('#ddlProducer').valid()) {
        if ($('#ddlAgent').valid()) {
            if ($('#ddlDeptment').valid()) {
                if ($('#ddlBusClassCat').valid()) {
                    if ($('#ddlBusClass').valid()) {
                        if ($('#txtExposure').valid()) {
                            if ($('#txtAggentRate').valid()) {
                                if ($('#txtRate').valid()) {
                                    if ($('#ddlInstalMode').valid()) {
                                        debugger
                                        GetAgentRateDeptWise();

                                        var dept = $("#ddlDeptment  option:selected").text();
                                        var deptCode = $("#ddlDeptment  option:selected").val();
                                        var BusClassCat = $("#ddlBusClassCat option:selected").text();
                                        var BusClass = $("#ddlBusClass option:selected").text();
                                        var BusClassCode = $("#ddlBusClass option:selected").val();
                                        var installment = $("#ddlInstalMode option:selected").text();
                                        var agentRate = $("#txtAggentRate").val();
                                        var agentRateType = "PERCENT";
                                        var exposure = $("#txtExposure").val();
                                        var StandardRate = $("#txtRate").val();
                                        var StandardRateType = $("#ddlRateMil option:selected").text();

                                        var InsuranceType = $("#ddlInsuranceType option:selected").text();
                                        var InsuranceTypeCode = $("#ddlAgentInsuranceType option:selected").val();
                                        //var RateDef = parseInt(agentRate) - parseInt(standardrate);


                                        //if (parseInt(agentRate) > parseInt(standardrate)) {
                                        //    Status = 'APPROVAL REQ';
                                        //} else {
                                        //    Status = 'APPROVAL NOT REQ';

                                        //}

                                        var markup = "<tr><td value'" + deptCode + "'>" + dept.toUpperCase() + "</td><td>" + BusClassCat.toUpperCase() + "</td><td>" + BusClass.toUpperCase() + "</td><td>" + InsuranceType.toUpperCase() + "</td><td>" + exposure.toUpperCase() + "</td><td>" + StandardRate.toUpperCase() + "</td><td>" + StandardRateType.toUpperCase() + "</td><td>" + Agent_Rate + "</td><td>" + agentRate.toUpperCase() + "</td><td>" + agentRateType.toUpperCase() + "</td><td>" + Agent_type.toUpperCase() + "</td><td>" + installment.toUpperCase() + "</td><td><span onclick='DeleteAgentBusClassRate(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td></tr >";

                                        $("#tblAgentBusClassRate tbody").append(markup);
                                        $('#txtExposure').val('');
                                        $('#txtRate').val('');
                                        $('#txtAggentRate').val('');
                                      
                                        //if ($('#statusText').text() == 'APPROVAL REQ') {
                                        //    $('#statusText').css("color", "red");
                                        //}
                                        //else {
                                        //    $('#statusText').css("color", "green");

                                        //}

                                    }
                                }
                            }
                        }
                    }
                } else {

                }
            } else {
            }
        }
    }

 
});
var Agent_Rate, Agent_type;

function GetAgentRateDeptWise() {

    var dept = $("#ddlAppDept option:selected").val();
    var BusClassCat = $("#ddlApprBusClass option:selected").val();
    var ajax_data = {
        Dept: dept,
        busClass: BusClassCat

    };

    $.ajax({
        url: "api/ClientForm/GetBusClassStandardRate",
        data: ajax_data,
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            for (var i = 0; i < data.length; i++) {


                Agent_Rate = data[0].STANDARD_RATE;
                Agent_type = data[0].AGENT_TYPE;

            }


        },
        error: function (request) {

        }
    });
    return Agent_Rate, Agent_type;
};




function LoadTableAgentRateDeptWise(CF_ID) {

    var ajax_data = {
        cfEdit: CF_ID,


    };

    $.ajax({
        url: "api/ClientForm/GetLoadBusClassAgentRate",
        data: ajax_data,
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $("#tblAgentBusClassRate tr:gt(0)").remove();
            if (data.length > 0) {


                for (var i = 0; i < data.length; i++) {

                    var fillBusClassAgentRateDetail = "<tr><td style='display:none'>" + data[i].IDX + "</td><td>" + data[i].DEPARTMENT + "</td><td>" + data[i].INSURANCE_CATEGORY + "</td><td>" + data[i].BUSSNIESS_CLASS + "</td><td>" + data[i].INSURANCE_TYPE + "</td><td>" + data[i].EXPOSURE + "</td><td>" + data[i].RATE + "</td><td>" + data[i].STANDARDRATETYPE + "</td><td>" + data[i].STANDARD_RATE + "</td><td>" + data[i].AGENTRATE + "</td><td>" + data[i].AGENTRATETYPE + "</td><td>" + data[i].AGENT_TYPE + "</td><td>" + data[i].INSTALLMENT_MODE + "</td></tr >";
                    //<input  style='zoom: 1.8;' type='checkbox'> 
                    //<td><span id='btnBusClassAgentDelete'  value='" + data[0].IDX + "'  onclick='DeleteDeptAgentRate(this);'  class='material-icons md-33' style='color: red;font-size: 31px;cursor: pointer;'>delete</span></td><td id='AproveCheck' ></td>
                    $('#tblAgentBusClassRate tbody').append(fillBusClassAgentRateDetail);
                    //<span class='material-icons md-33' style='#3eb980: red;font-size: 31px;cursor: pointer;'>done</span><span class='material-icons md-33' style='red: red;font-size: 31px;cursor: pointer;'>cancel</span></td>
                }


                $("#ddlAppDept option:selected").text(data[0].DEPARTMENT).trigger('change');
                $("#ddlApprBusClassCat option:selected").text(data[0].INSURANCE_CATEGORY).trigger('change');
                var InsbuslasUpdate = data[0].INSURANCE_TYPE.toUpperCase();
                $("#ddlAgentInsuranceType option:selected").text(InsbuslasUpdate).trigger('change');
                $("#ddlApprBusClass option:selected").text(data[0].BUSSNIESS_CLASS).trigger('change');
                document.getElementById("txtAggentRate").value = data[0].AGENTRATE;
                document.getElementById("txtExposure").value = data[0].EXPOSURE;
                document.getElementById("txtRate").value = data[0].RATE;
                $("#ddlRateMil option:selected").text(data[0].RATE_TYPE).trigger('change');
                $("#ddlInstalMode option:selected").text(data[0].INSTALLMENT_MODE).trigger('change');

                //var UserRole = localStorage.getItem('UserRole');
                //if (UserRole == 'BranchManager' || UserRole == 'OperationHead' || UserRole == 'Producer') {
                //    $('#AproveRate').hide();
                //    $("#tblAgentBusClassRate  tr #AproveCheck").hide();


                //}

            }


        },
        error: function (request) {

        }
    });
    //return standard_Rate;
};

function DeleteDeptAgentRate(BusClassAgentRateIdx) {
    if (confirm("Are You Sure You want to delete !")) {

        var BusClassRateIdx = $(BusClassAgentRateIdx).attr("value");
        var ajaxConPerDelete = {
            BusClassRateIdx: BusClassRateIdx
        };

        $.ajax({
            url: "api/ClientForm/GetDeleteBusClassAgentRate",
            type: 'GET',
            dataType: 'json',
            data: ajaxConPerDelete,
            success: function (data) {
                LoadTableAgentRateDeptWise(cfEdit)
                alert('Delete Successfully !')
            },
            error: function (request) {

            }
        });
    }
    else {

    }
}

function LoadApprovalAgentRate(CF_ID) {

    var ajax_data = {
        cfEdit: CF_ID,


    };

    $.ajax({
        url: "api/ClientForm/GetLoadAprovalAgentRate",
        data: ajax_data,
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            $("#tblAproveAgentRate tr:gt(0)").remove();
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {

                    var AgentRateEdit, AgentRateApprove, AgentRateReject, ApproveStatus = "";

                    if (data[i].STATUS == "APPROVED") {

                        AgentRateEdit = "<input id='btnAgentEdit' disabled='disabled' type='button' data-standardvalue=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateApprovebtn' data-agentid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateApprove = " <input type='button' disabled='disabled'  class='btn btn-success AgentRateEditbtn' data-agentapproveid=" + data[i].IDX + " id='AgentRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateReject = "<input id='btnAgentRateReject' type='button'  disabled='disabled' data-standardrejectrate=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateRejectbtn' data-agentRateRejectid=" + data[i].IDX + "  value='Reject' style='font-size: 12px;background-color: #096735;'></input>";

                    }
                    else if (data[i].STATUS == "REJECTED") {

                        AgentRateEdit = "<input id='btnAgentEdit' disabled='disabled' type='button' data-standardvalue=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateApprovebtn' data-agentid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateApprove = " <input type='button' disabled='disabled'  class='btn btn-success AgentRateEditbtn' data-agentapproveid=" + data[i].IDX + " id='AgentRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateReject = "<input id='btnAgentRateReject' type='button'  disabled='disabled' data-standardrejectrate=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateRejectbtn' data-agentRateRejectid=" + data[i].IDX + "  value='Reject' style='font-size: 12px;background-color: #096735;'></input>";
                    }
                    else {
                        AgentRateEdit = "<input id='btnAgentEdit' type='button'  data-standardvalue=" + data[i].STANDARD_RATE + " class='btn btn-success AgentRateApprovebtn' data-agentid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateApprove = " <input type='button'  class='btn btn-success AgentRateEditbtn' data-agentapproveid=" + data[i].IDX + " id='AgentRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateReject = "<input id='btnAgentRateReject' type='button'  data-standardrejectrate=" + data[i].STANDARD_RATE + "   class='btn btn-success AgentRateRejectbtn' data-agentRateRejectid=" + data[i].IDX + "   value='Reject' style='font-size: 12px;background-color: #096735;'></input>";
                    }

                    var RateDef = parseInt(data[i].PROPOSE_RATE) - parseInt(data[i].STANDARD_RATE);

                    if (RateDef <= 0) {
                        AgentRateEdit = "<input id='btnAgentEdit' disabled='disabled' type='button' data-standardvalue=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateApprovebtn' data-agentid=" + data[i].IDX + "  value='Edit' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateApprove = " <input type='button' disabled='disabled'  class='btn btn-success AgentRateEditbtn' data-agentapproveid=" + data[i].IDX + " id='AgentRateAprove' value='Approve' style='font-size: 12px;background-color: #096735;'></input>";
                        AgentRateReject = "<input id='btnAgentRateReject' type='button'  disabled='disabled' data-standardrejectrate=" + data[i].STANDARD_RATE + "  class='btn btn-success AgentRateRejectbtn' data-agentRateRejectid=" + data[i].IDX + "  value='Reject' style='font-size: 12px;background-color: #096735;'></input>";
                    }
                    if (RateDef == "0") {
                        ApproveStatus = "APPROVED";
                    }
                    else {
                        ApproveStatus = "NOT APPROVE";
                    }

                    var fillAproveAgentRate = "<tr ><td>" + data[i].CF_ID + "</td><td>" + data[i].DEPARTMENT + "</td><td>" + data[i].INSURANCE_CATEGORY + "</td><td>" + data[i].BUSSNIESS_CLASS + "</td><td>" + data[i].INSURANCE_TYPE + "</td><td>" + data[i].STANDARD_RATE + "</td><td><input type='text'id='txtProposeAgnetRate' class='ProposeAgnetRate' disabled='disabled' value='" + data[i].PROPOSE_RATE + "' /></td><td>" + RateDef + "</td><td>" + data[i].AGENT_TYPE + "</td><td id='txtStatustext'>" + data[i].STATUS + "</td><td> " + AgentRateEdit + "</td><td>" + AgentRateApprove + "</td><td>" + AgentRateReject + "</td></tr>";
                    // style = 'display:none'
                    //<input  style='zoom: 1.8;' id='AproveAgentRateCheck' type='checkbox'>
                    //debugger
                    //if (data[i].STATUS = "Approved") {
                    //    $('#tblAproveAgentRate  tr td:eq(8)').css('color', 'green');
                    //}
                    //else {
                    //    $('#tblAproveAgentRate  tr td:eq(8)').css('color', 'red');
                    //}


                    $('#tblAproveAgentRate tbody').append(fillAproveAgentRate);
                    var statusidx = localStorage.getItem('statusidx');
                    if (statusidx == "30" || statusidx == "90" || statusidx == "91") {

                        //$('#btnAgentEdit').prop('disabled', true);
                        //$('#AgentRateAprove').prop('disabled', true);
                        $('.AgentRateApprovebtn').prop('disabled', true);
                        $('.AgentRateEditbtn').prop('disabled', true);
                        $('.AgentRateRejectbtn').prop('disabled', true);

                        //$('.AgentRateApprovebtn').hide();
                        //$('.AgentRateEditbtn').hide();




                    }

                }






            }


        },
        error: function (request) {

        }
    });

};


$(document).on('click', '#btnAgentEdit', function () {
    debugger
    var agentidx = $(this).attr("data-agentid");
    var standardRate = $(this).attr("data-standardvalue");
    var Agenteditbutton = $(this).closest('tr').find('#btnAgentEdit').val();
    if (Agenteditbutton == "Edit") {
        $(this).closest('tr').find('#txtProposeAgnetRate').prop('disabled', false);
        $(this).closest('tr').find('#btnAgentEdit').prop('disabled', false);
        $(this).closest('tr').find('#btnAgentEdit').val('Update');
        $(this).closest('tr').find('#txtProposeAgnetRate').val(standardRate);

    }
    else {
        var agentrateUpd = $(this).closest('tr').find('#txtProposeAgnetRate').val();


        var ajax_data = {
            agentidx: agentidx,
            agentrateUpd: agentrateUpd


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateAgentRate",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                LoadApprovalAgentRate(cfEdit);
                alert('Update Rate Successfully !');

            },
            error: function (request) {

            }
        });

    }



});
$(document).on('click', '#AgentRateAprove', function () {

    if (confirm("Are You Sure You Want To Approve Rate")) {
        var AgentApproveId = $(this).attr("data-agentapproveid");
        var ajax_data = {
            AgentApproveId: AgentApproveId,
            AgentRateStatus: 'APPROVED'


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateAgentStatus",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                LoadApprovalAgentRate(cfEdit);
                $(this).closest('tr').find('.AgentRateEditbtn').prop('disabled', true);
                $(this).closest('tr').find('.AgentRateApprovebtn').prop('disabled', true);
                $(this).closest('tr').find('.AgentRateRejectbtn').prop('disabled', true);
                //$(this).closest('tr').find('#btnAgentEdit').prop('disabled', true);
                //$(this).closest('tr').find('#AgentRateAprove').prop('disabled', true);
                //$('#btnAgentEdit').prop('disabled', true);
                //$('#AgentRateAprove').prop('disabled', true);

                alert('Approved Rate Successfully !');

            },
            error: function (request) {

            }
        });

    }
    else {

    }
});
$(document).on('click', '#btnAgentRateReject', function () {

    if (confirm("Are You Sure You Want To Reject Rate")) {
        var AgentRejectId = $(this).attr("data-agentRateRejectid");
        var standardAgentRateReject = $(this).attr("data-standardrejectrate");
        var ajax_data = {
            AgentRejectId: AgentRejectId,
            AgentRateStatus: 'REJECTED',
            standardAgentRateReject: standardAgentRateReject


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateAgentRejectStatus",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                LoadApprovalAgentRate(cfEdit);
                $(this).closest('tr').find('.AgentRateEditbtn').prop('disabled', true);
                $(this).closest('tr').find('.AgentRateApprovebtn').prop('disabled', true);
                $(this).closest('tr').find('.AgentRateRejectbtn').prop('disabled', true);

                //$('#btnAgentEdit').prop('disabled', true);
                //$('#AgentRateAprove').prop('disabled', true);

                alert('Rate Reject  Successfully !');

            },
            error: function (request) {

            }
        });

    }
    else {

    }
});

//$(document).on('click', '#btnFinalizeOverCommission', function () {

//});



$(document).on('click', '#btninstallmentEdit', function () {
    var Installidx = $(this).attr("data-installmentid");
    var Installeditbutton = $(this).closest('tr').find('#btninstallmentEdit').val();
    var instalmodeRowText = $(this).closest('tr').find("label[id=txtInstalMode]").text();
    if (Installeditbutton == "Edit") {
        $(this).closest('tr').find('#txtInstalMode').hide();
        $(this).closest('tr').find('#ddlInstalEdit').show();
        $(this).closest('tr').find("#ddlInstalEdit option:selected").text(instalmodeRowText);
        $(this).closest('tr').find('#btninstallmentEdit').val('Update');
        $(this).closest('tr').find('#ddlInstalEdit').prop('disabled', false);
    }
    else {

        var InstalUpd = $(this).closest('tr').find("#ddlInstalEdit option:selected").text();


        var ajax_data = {
            Installidx: Installidx,
            InstalUpd: InstalUpd


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateInstallement",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                GetFillInstallments(cfEdit);
                alert('Update Rate Successfully !');

            },
            error: function (request) {

            }
        });

    }



});
$(document).on('click', '#installmentAprove', function () {

    if (confirm("Are You Sure You Want To Approve Rate")) {
        var InstalApproveId = $(this).attr("data-installmentapproveid");
        var ajax_data = {
            InstalApproveId: InstalApproveId,
            InstalStatus: 'APPROVED'


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateInstallementStatus",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                GetFillInstallments(cfEdit);
                $('#btninstallmentEdit').prop('disabled', true);
                $('#installmentAprove').prop('disabled', true);

                alert('Approved Installment Successfully !');

            },
            error: function (request) {

            }
        });

    }
    else {

    }
});



$(document).on('click', '#btnStandardRateEdit', function () {

    var StandardRateidx = $(this).attr("data-standardrateid");
    var StandardRatebutton = $(this).closest('tr').find('#btnStandardRateEdit').val();
    var RateType = $(this).closest('tr').find("label[id=txtRateType]").text();
    if (StandardRatebutton == "Edit") {
        $(this).closest('tr').find('#txtProposeStandardRate').prop('disabled', false);

        $(this).closest('tr').find("#ddlRateTypeEdit option:selected").text(RateType);
        $(this).closest('tr').find('#txtRateType').hide();
        $(this).closest('tr').find('#ddlRateTypeEdit').show();
        $(this).closest('tr').find('#btnStandardRateEdit').val('Update');

    }
    else {

        var standardRate = $(this).closest('tr').find("#txtProposeStandardRate").val();
        var standardRateType = $(this).closest('tr').find("#ddlRateTypeEdit option:selected").text();

        var ajax_data = {
            StandardRateidx: StandardRateidx,
            standardRate: standardRate,
            standardRateType: standardRateType


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateStandardRate",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                GetApprovalBusClassDetail(cfEdit);
                alert('Update Rate Successfully !');

            },
            error: function (request) {

            }
        });

    }



});
$(document).on('click', '#StandardRateAprove', function () {

    if (confirm("Are You Sure You Want To Approve Rate")) {
        var StandardApproveId = $(this).attr("data-standardrateapproveid");
        var ajax_data = {
            StandardApproveId: StandardApproveId,
            StandardRateStatus: 'APPROVED'


        };
        $.ajax({
            url: "api/ClientForm/GetUpdateStandardRateStatus",
            data: ajax_data,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                GetApprovalBusClassDetail(cfEdit);
                $(this).closest('tr').find('#btnStandardRateEdit').prop('disabled', true);
                $(this).closest('tr').find('#StandardRateAprove').prop('disabled', true);

                alert('Approved Standard Rate Successfully !');

            },
            error: function (request) {

            }
        });

    }
    else {

    }
});



$(document).on('click', '#btnFinalizeAgentRate', function () {
    debugger
    if (confirm("Are You Sure to Finalize!")) {

        var InstalModeStatus = [];
        var AgentRateDiff = [];


        var AgentRatetable = document.getElementById('tblAproveAgentRate');
        if (AgentRatetable.rows.length > 1) {
            for (var i = 1; i < AgentRatetable.rows.length; i++) {

                var AgentAproveStatus = (AgentRatetable.rows[i].cells[9].textContent.trim());
                AgentRateDiff.push({ "RATE_STATUS": AgentAproveStatus });

            }
        }

        var AgentRateStatus = $.grep(AgentRateDiff, function (v) {
            return v.RATE_STATUS == "NOT APPROVE";
        });

        if (AgentRateStatus.length > 0) {
            alert('Please Approve All Rate Then Finalize');
        }
        else {
            $('#tblInstalment').find('tr').each(function (i, el) {
                if (i == 0) {

                }
                else {
                    var InstallmentValue = $(this).closest('tr').find("label[id=txtInstalMode]").text()
                    InstalModeStatus.push({ "INSTALL_VALUE": InstallmentValue });
                }

            });
            var InstalMode = $.grep(InstalModeStatus, function (v) {
                return v.INSTALL_VALUE != "UPFRONT PAYMENT";
            });
            if (InstalMode.length > 0) {
                statusid = "80";
                AssignTouser = "ZEESHANLILANI";
            }
            else {
                statusid = "90";
                AssignTouser = "IT";
            }
            if (cfEdit == undefined) {
                cfEdit = "";
            }
            else {
                cfEdit = cfEdit;
            }
            var ajax_data = {
                statusid: statusid,
                AssignTouser: AssignTouser,
                cfEdit: cfEdit

            };
            $.ajax({
                url: "api/ClientForm/GetForwardStatus",

                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {


                    alert('Successfully Forward To  ' + AssignTouser);
                    window.location = "ClientDetails.aspx";
                },
                error: function (request) {

                }
            });
        }
    }
    else {

    }

});




$(document).on('click', '#btnFinalizeInstallMode', function () {
    debugger
    if (confirm("Are You Sure to Finalize!")) {
        var InstalModeStatus = [];


        var InstalModetable = document.getElementById('tblInstalment');
        if (InstalModetable.rows.length > 1) {
            for (var i = 1; i < InstalModetable.rows.length; i++) {

                var IsntalAproveStatus = (InstalModetable.rows[i].cells[2].textContent.trim());
                InstalModeStatus.push({ "INSTAL_STATUS": IsntalAproveStatus });

            }
        }

        var InstalmentStatus = $.grep(InstalModeStatus, function (v) {
            return v.INSTAL_STATUS == "NOT APPROVE";
        });

        if (InstalmentStatus.length > 0) {
            alert('Please Approve All Installment Then Finalize');
        }
        else {
            var AssignTouser = 'IT';
            if (cfEdit == undefined) {
                cfEdit = "";
            }
            else {
                cfEdit = cfEdit;
            }
            var ajax_data = {
                statusid: '90',
                AssignTouser: AssignTouser,
                cfEdit: cfEdit

            };
            $.ajax({
                url: "api/ClientForm/GetForwardStatus",

                type: 'GET',
                dataType: 'json',
                data: ajax_data,
                success: function (data) {


                    alert('Successfully Forward To  ' + AssignTouser);
                    window.location = "ClientDetails.aspx";
                },
                error: function (request) {

                }
            });
        }

    }
    else {

    }
});



