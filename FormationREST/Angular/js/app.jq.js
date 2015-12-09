$(document).ready(function () {

    $(".thumbnail").mouseenter(
                                function () {
                                    $(this).css("background-color", "purple");
                                });

    $(".thumbnail").mouseleave(
                                function () {
                                    $(this).css("background-color", "white");
                                });

});