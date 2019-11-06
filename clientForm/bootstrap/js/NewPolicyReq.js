





function LeasingTable() {
    var counter = 0;

    $("#addrow").on("click", function () {
        FillMake();

        if (typeof (Storage) !== "undefined") {
            if (localStorage.getItem.clickcount) {
                localStorage.getItem.clickcount = Number(localStorage.getItem.clickcount) + 1
            }
            else {
                localStorage.getItem.clickcount = 2;
            }
        }
        //Header Row//
        var newRow = $("<tr class='rowclass'>");
        var cols = "";
        cols += '<td  style="border-bottom: solid;border-bottom-color: green;"><h1 style="font-size: 17px; color:Black; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;"> ' + localStorage.getItem.clickcount + '  Vehicle :</h1></td>';
        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;

        //Header Row//
        var newRow = $("<tr>");
        var cols = "";
        cols += '<td><h1 style="font-size: 17px; color: #006400; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;">Vehicle Details:</h1></td>';
        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;

        // Car Detail//
        var newRow = $("<tr  id='tr" + localStorage.getItem.clickcount + "'>");
        var cols = "";
        cols += '<td><select  id="ddlMakePee-' + localStorage.getItem.clickcount + '" class="form-control"  name="make' + counter + '"/></td>';
        cols += '<td><input " id="LeesePower-' + localStorage.getItem.clickcount + '" type="text" placeholder="Enter Power" class="form-control" name="Power' + counter + '"/></td>';
        cols += '<td><input   id="LeeseEngine-' + localStorage.getItem.clickcount + '" type="text" placeholder="Enter Engine #" class="form-control" name="EngineNo' + counter + '"/></td>';
        cols += '<td><input     id="LeeseChasis-' + localStorage.getItem.clickcount + '" type="text" placeholder="Enter Chasis #" class="form-control" name="ChasisNo' + counter + '"/></td>';


        newRow.append(cols);
        $("table.order-list").append(newRow);
        populateDDL('ddlMakePee-' + localStorage.getItem.clickcount)
        counter++;



        //New Row Add//
        var newRow = $("<tr id='tr" + localStorage.getItem.clickcount + "-2'>");
        var cols = "";
        cols += '<td><input id="LeeseRegNo-' + localStorage.getItem.clickcount + '" type="text" placeholder="Enter Reg #" class="form-control" name="ReqNo' + counter + '"/></td>';
        cols += '<td><input   id="LeeseColor-' + localStorage.getItem.clickcount + '" type="text" placeholder="Enter Color" class="form-control" name="Color' + counter + '"/></td>';
        cols += '<td><input id="LeeseModel-' + localStorage.getItem.clickcount + '" placeholder="Enter Model" type="text" class="form-control" name="Model' + counter + '"/></td>';
        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;


        //Header Row//

        var newRow = $("<tr>");
        var cols = "";
        cols += '<td><h1 style="font-size: 17px; color: #006400; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;">Lessee Details:</h1></td>';
        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;


        //New Lessee  Row//
        var newRow = $("<tr id='tr" + localStorage.getItem.clickcount + "-3'>");
        var cols = "";
        cols += '<td><input id="LeeseAgrement-' + localStorage.getItem.clickcount + '" placeholder="Enter Lease Agreement #" type="text" class="form-control" name="LeaseAgreement' + counter + '"/></td>';
        cols += '<td><input id="LeeseName-' + localStorage.getItem.clickcount + '" placeholder="Enter Lessee Name" type="text" class="form-control" name="LesseeName' + counter + '"/></td>';
        cols += '<td><input id="LeeseAdres-' + localStorage.getItem.clickcount + '" placeholder="Enter Lessee Address" type="text" class="form-control" name="LesseeAddress' + counter + '"/></td>';
        cols += '<td><input id="LeeseContact-' + localStorage.getItem.clickcount + '" placeholder="Enter Lessee Contact #" type="text" class="form-control" name="LesseeContactNo' + counter + '"/></td>';
        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;

        //Header  Row//
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td><h1 style="font-size: 17px; color: #006400; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;">Contact Person Detail:</h1></td>';

        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;


        //New Customer  Row//
        var newRow = $("<tr id='tr" + localStorage.getItem.clickcount + "-4'>");
        var cols = "";
        cols += '<td><input id="LeeseContactPers-' + localStorage.getItem.clickcount + '" placeholder="Enter Contact person Name" type="text" class="form-control" name="ContactpersonName' + counter + '"/></td>';
        cols += '<td><input  id="LeeseContactPersCnic-' + localStorage.getItem.clickcount + '" placeholder="Enter Contact person CNIC" type="text" class="form-control" name="ContactpersonCNIC' + counter + '"/></td>';
        cols += '<td><input id="LeeseContactNo-' + localStorage.getItem.clickcount + '" placeholder="Enter Conatct person Cell #" type="text" class="form-control" name="ConatctpersonCell' + counter + '"/></td>';

        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;


        //Header  Row//
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td><h1 style="font-size: 17px; color: #006400; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;">Dealer Detail:</h1></td>';

        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;

        //New Dealer  Row//
        var newRow = $("<tr id='tr" + localStorage.getItem.clickcount + "-5'>");
        var cols = "";
        cols += '<td><input id="LeeseDealerName-' + localStorage.getItem.clickcount + '" placeholder="Enter Dealer Name" type="text" class="form-control" name="DealerName' + counter + '"/></td>';
        cols += '<td><input id="LeeseDealerAddress-' + localStorage.getItem.clickcount + '" placeholder="Enter Dealer Address" type="text" class="form-control" name="DealerAddress' + counter + '"/></td>';
        cols += '<td><input id="LeeseDealerRep-' + localStorage.getItem.clickcount + '" placeholder="Enter Dealer Representative" type="text" class="form-control" name="DealerRep' + counter + '"/></td>';

        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;


        //Header  Row//
        var newRow = $("<tr>");
        var cols = "";
        cols += '<td><h1 style="font-size: 17px; color: #006400; margin-bottom: 0px; margin-left: 12px; margin-top: 0px;">Insurance Detail:</h1></td>';
        newRow.append(cols);
        $("table.order-list").append(newRow);
        counter++;
        //New Insurance  Row//
        var newRow = $("<tr id='tr" + localStorage.getItem.clickcount + "-6'>");
        var cols = "";
        cols += '<td><input id="LeeseInsurancePeriod-' + localStorage.getItem.clickcount + '" placeholder="Enter Insurance Period" type="text" class="form-control" name="InsurancePeriod' + counter + '"/></td>';
        cols += '<td><input id="LeeseSumInsured-' + localStorage.getItem.clickcount + '" placeholder="Enter Sum Insured" type="text" class="form-control" name="SumInsured' + counter + '"/></td>';
        cols += '<td><input  id="LeeseInsuranceRate-' + localStorage.getItem.clickcount + '"  placeholder="Enter Insurance Rate" type="text" class="form-control" name="InsuranceRate' + counter + '"/></td>';
        cols += '<td><input  id="LeeseInsurancePre-' + localStorage.getItem.clickcount + '"  placeholder="Enter Insurance Premium" type="text" class="form-control" name="InsurancePrem' + counter + '"/></td>';
        cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger" value="Delete"></td>';
        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;
    });
    //$(".ibtnDel").on("click", function () {
    //    alert()
    //    $("tr[id=" + localStorage.getItem.clickcount + "]").remove();
    //});


    $("table.order-list").on("click", ".ibtnDel", function (event) {
        $("tr[id^=tr" + localStorage.getItem.clickcount).remove();
        //alert("tr[id=tr" + localStorage.getItem.clickcount + "]");

        // jQuery("#" + localStorage.getItem.clickcount).remove();
        //$("#" + localStorage.getItem.clickcount).remove();
        //$('#' + counter)('tr').remove();
        //counter -= 1

    });



    //function calculateRow(row) {
    //    var price = +row.find('input[name^="price"]').val();

    //}

    //function calculateGrandTotal() {
    //    var grandTotal = 0;
    //    $("table.order-list").find('input[name^="price"]').each(function () {
    //        grandTotal += +$(this).val();
    //    });
    //    $("#grandtotal").text(grandTotal.toFixed(2));
    //}
}
var array = [];

function populateDDL(id) {
    var optionsAsString = "";
    debugger;
    for (var i = 0; i< array.length; i++) {
        optionsAsString += "<option value='" + array[i].Code + "'>" + array[i].Desc + "</option>";

    }
    $('#' + id).append(optionsAsString);

}

function FillMake() {
    $.ajax({
        url: "api/Email/GetMake",

        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);

            var optionsAsString = "";
           
            for (var i = 0; i < data.length; i++) {
                var obj = { Code: null, Desc: null };

                obj.Code = data[i].PMK_MAKE_CODE;
                obj.Desc = data[i].PMK_DESC;
                array.push(obj);

                optionsAsString += "<option value='" + data[i].PMK_MAKE_CODE + "'>" + data[i].PMK_DESC + "</option>";
            }
          $('#ddlMakePee-1').append(optionsAsString);
            //var select = document.getElementById("ddlMakePee");

            //select.options.length = null;
            //for (var i = 0; i < data.length; i++) {


            //        option = document.createElement("option");
            //        option.text = data[i].PMK_DESC;
            //        option.value = data[i].PMK_MAKE_CODE;
            //      (')  select.appendChild(option);


            //}
        },
        error: function (request) {

        }
    });

};

//$(document).ready(function(){
//    $('#btnLeeseAdd').on('click', function (e) {
//        e.preventDefault();
        
//        alert();

//    });

//});

//function insertLeese() {
//    var rowCount = document.getElementById('LeeseTable').rows.length;

//    alert(rowCount);
//    var tabel = document.getElementById('LeeseTable');
//    var length= $("[id*=tr]")
//    for (i = 0; i < length; i++) {
//        var row = $("[id*=tr]")[i]
//        var rowdadta = {
//            //var  regno: $('#tr-'+ i +'td')


//        }
//    }
//    //$('#tr2-2 td')[0]
//}

