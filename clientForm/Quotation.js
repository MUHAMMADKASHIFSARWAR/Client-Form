function getDept() {
    $.ajax({
        url: baseUrl + "api/Nacta/GetDept",
        type: 'GET',
        dataType: 'json',
        data: ajax_data,
        success: function (data) {

            for (var i = 0; i < data.length; i++) {

                $('#ddlDept').append("<option value='" + data[i].PDP_DEPTCODE + "'>" + data[i].PDP_DEPTDESC + "</option>");
            }

        },
        error: function (request) {
            //notifyError('Data Load failed!');

        }
    });


    }