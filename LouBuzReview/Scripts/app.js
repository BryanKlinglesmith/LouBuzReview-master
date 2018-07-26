
function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}
//Initialise date picker
//$(function () { 
//    $('.datepicker').datepicker();
//});
$(document).ready(function () {
    $("#myDIV").style.display = "none";
});

$(document).ready(function () {
    $('#detailClass').css('visibility', 'hidden');
    $('#editClass').css('visibility', 'hidden');
    $('#deleteClass').css('visibility', 'hidden');
});


$(document).ready(function () {
    setTimeout(function () { $('.messages.status').fadeOut(); }, 8000);
    $(window).click(function () { $('.messages.status').fadeOut(); });
});
