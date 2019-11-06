
$('#btn-chat').on('click', function (e) {
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



var leftchattemplate = '<li class="left clearfix">       <span class="chat-img pull-left"><img src="http://placehold.it/50/55C1E7/fff&text=[IH]" alt="User Avatar" class="img-circle" />' +
                       '</span><div class="chat-body clearfix"><div class="" >  </div><p >[ChatContent] </p><small class="pull-right text-muted pull-left"><span class="glyphicon glyphicon-time"></span>' +
                       '</small></div></li>';
var rightchattemplate = '<li class="right clearfix" style="float:right"><span class="chat-img pull-right"><img src="http://placehold.it/50/FA6F57/fff&text=[IH]" alt="User Avatar" class="img-circle" /></span>' +
                '<div class="chat-body clearfix"><div> </div> <p>[ChatContent]</p><small class=" text-muted pull-right"><span class="glyphicon glyphicon-time"></span>[TS]</small>  </div></li>';

function replaceAtMentionsWithLinks(text) {
    return text.replace(/@([a-z\d_]+)/ig, '<span class="primary">@$1</span>');
}
getRemarks();
if (typeof Element.prototype.addEventListener === 'undefined') {
    Element.prototype.addEventListener = function (e, callback) {
        e = 'on' + e;
        return this.attachEvent(e, callback);
    };
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