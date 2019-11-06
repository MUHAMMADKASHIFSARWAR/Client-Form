function uncheckRadioButton() {
    var checked = false;
    $('.leftBLight').on('click', function (rvt) {

        checked = !checked;
        $(this).prop("checked", checked);
        if ($(this).is(':checked')) {
            var demages = $(this).data("name");
            alert(demages);
        }
        else {
            $(this).removeAttr("name")
        }

    })
  
}


