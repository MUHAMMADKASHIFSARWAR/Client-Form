$(document).ready(function () {
    $('.registration-form fieldset:first-child').fadeIn('slow');

    $('.registration-form input[type="text"]').on('focus', function () {
        $(this).removeClass('input-error');
    });

    // next step
    $('.registration-form .btn-next').on('click', function () {
        var parent_fieldset = $(this).parents('fieldset');
        var next_step = true;

        //parent_fieldset.find('input[type="text"],input[type="email"]').each(function () {
        //    if ($(this).val() == "") {
        //        $(this).addClass('input-error');
        //        next_step = false;
        //    } else {
        //        $(this).removeClass('input-error');
        //    }
        //});

        if (next_step) {
            parent_fieldset.fadeOut(400, function () {
                $(this).next().fadeIn();
            });
        }

    });

    // previous step
    $('.registration-form .btn-previous').on('click', function () {
        $(this).parents('fieldset').fadeOut(400, function () {
            $(this).prev().fadeIn();
        });
    });
    $('#btn-Next').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#MotorDeliverGrid').fadeIn();
            $('#MotorGrid').hide();
            $('#ClientGrid').hide();
            $('#btnPreDeliver').fadeIn();
            
        });


    });
    $('#btn-NextDeliver').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableField').fadeIn();
            $('#TableDealer2').fadeIn();
            $('#btnPreDealer').show();
            $('#MotorGrid').hide();
            $('#ClientGrid').hide();



        });


    });
    $('#btnPreDeliver').on('click', function () {
        $(this).fadeOut(400, function () {

            $('#btn-Next').show();

        });
    });
   
    $('#btnPreDealer').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableField').hide();
            $('#TableDealer2').hide();

            $('#MotorDeliverGrid').fadeIn();
            $('#btn-NextDeliver').fadeIn();

            $('#ClientGrid').hide();


        });
    });
    $('#btn-Indus').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableField').hide();
            $('#TableDealer2').hide();

            $('#TableIndus').fadeIn();
            $('#btn-PreDealer').fadeIn();

        });
    });
    $('#btn-PreDealer').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableField').fadeIn();
            $('#TableDealer2').fadeIn();

            $('#TableIndus').hide();
            $('#btn-Indus').fadeIn();



        });
    });
    $('#btn-NextDealerA').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableIndus').hide();

            $('#btn-NextDealerA').fadeIn();
            $('#TableIndusDealerA').fadeIn();
            //$('#btn-Indus').fadeIn();



        });
    });
    $('#btnReq').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableIndusDealerA').hide();

            $('#TableIndusReq').fadeIn();
            $('#btn-PreReq').fadeIn();
            //$('#btn-Indus').fadeIn();



        });
    });
    $('#btn-PreReq').on('click', function () {
        $(this).fadeOut(400, function () {
            $('#TableIndusReq').hide();

            $('#TableIndusDealerA').fadeIn();
            $('#btnReq').fadeIn();
            //$('#btn-Indus').fadeIn();



        });
    });


    // submit
    $('.registration-form').on('submit', function (e) {

        //$(this).find('input[type="text"],input[type="email"]').each(function () {
        //    if ($(this).val() == "") {
        //        e.preventDefault();
        //        $(this).addClass('input-error');
        //    } else {
        //        $(this).removeClass('input-error');
        //    }
        //});

    });


});
