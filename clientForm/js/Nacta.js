


function AddClient() {


    var ajax_data = {
        cnic: $('#cnic').val(),
        ntn: $('#Ntn').val(),
        Refno: $('#RefNo').val(),
        clientname: $('#ClientName').val(),
        address: $('#Address').val()
    };
    $.ajax({
        url: "api/Nacta/GetGIAClient",
        type: 'GET',
        data: ajax_data,
        dataType: 'json',
        success: function (data) {

            table = data;
            if (table.length == 0) {


                $.ajax({
                    url: "api/Nacta/GetNactaAlreadyClient",
                    type: 'GET',
                    data: ajax_data,
                    dataType: 'json',
                    success: function (data) {

                        table = data;
                        if (table.length == 0) {

                            $.ajax({
                                url: "api/Nacta/GetInsertClient",
                                type: 'GET',
                                data: ajax_data,
                                dataType: 'json',
                                success: function (data) {
                                    alert('Add Successfully!')
                                    GetClient();
                                    $("#cnic").inputmask();


                                },
                                error: function (request) {

                                }
                            });
                        }
                        else {
                            alert('Client Already exists! ')
                            GetClient();
                            $("#cnic").inputmask();
                        }

                    },
                    error: function (request) {

                    }
                });

            }

            else {
                alert('Client Already exists in GIAS! ')
                GetClient();
                $("#cnic").inputmask();
            }
        }
        ,
        error: function (request) {

        }
    });

}


function GetClient() {

    $.ajax({
        url: "api/Nacta/GetNactaClient",
        type: 'GET',
        dataType: 'json',
        data: {},
        success: function (data) {

            LoadViewNactaClient(data);


        },
        error: function (request) {
            notifyError('Data Load failed!');

        }
    });

}


function LoadViewNactaClient(data) {




    if ($.fn.dataTable.isDataTable('#tblNactaClients')) {
        accounttablevar = $('#tblNactaClients').DataTable().clear().destroy();
    }
    accounttablevar = $('#tblNactaClients').dataTable({

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

       { "data": "CLIENT_NAME" },
       { "data": "NTN" },
       { "data": "CNIC" },
       { "data": "ADDRESS" },
       { "data": "REF_NO" },
       { "data": "IN_DATE" },
        {
            "mRender": function (data, type, full) {
                return '<input type="date" class="form-control" id="OutDateCalender" name="ClientName"/>';


            }
        },
        {
            "mRender": function (data, type, full) {
                return '<a class="btn btn-success btn-xs Update" id="btnUpdate"  onclick=UpdateOutDate("' + full["REF_NO"] + '") data-th ="' + full["REF_NO"] + '" href="#" >' + ' Update' + '</a> ';


            }
        },


        ],
    });

}


function UpdateOutDate(REF_NO) {


    var table = $('#tblNactaClients').DataTable();
    $('#tblNactaClients tbody').on('click', 'tr', function () {
       // debugger
       //var id = $(this).attr('id');
       //if (id == 'btnUpdate') {
           var outDate = $(this).find('#OutDateCalender').val();

           var r = confirm("Are you sure you want to Save?");
           if (r == true) {
               var ajax_data = {
                   refno: REF_NO,
                   outDate: outDate

               };

               $.ajax({
                   url: "api/Nacta/GetUpdateNactaClient",
                   type: 'GET',
                   data: ajax_data,
                   dataType: 'json',
                   success: function (data) {


                       alert("Update Successfully !");
                       GetClient();
                       $("#cnic").inputmask();



                   },
                   error: function (request) {

                   }
               });
           }

           else {
               GetClient();

           }
       
       //else {

       //}

    });
}





function GetClearClient() {

    $.ajax({
        url: "api/Nacta/GetNactaClearClient",
        type: 'GET',
        dataType: 'json',
        data: {},
        success: function (data) {

            LoadViewNactaClearClient(data);


        },
        error: function (request) {
            notifyError('Data Load failed!');

        }
    });

}


function LoadViewNactaClearClient(data) {




    if ($.fn.dataTable.isDataTable('#tblNactaClearClients')) {
        accounttablevar = $('#tblNactaClearClients').DataTable().clear().destroy();
    }
    accounttablevar = $('#tblNactaClearClients').dataTable({

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

       { "data": "CLIENT_NAME" },
       { "data": "NTN" },
       { "data": "CNIC" },
       { "data": "ADDRESS" },
       { "data": "REF_NO" },
       { "data": "IN_DATE" },
        { "data": "OUT_DATE" },




        ],
    });

}