jQuery(document).ready(function () {

    $('.dismiss, .overlay').on('click', function () {
        $('.sidebar').removeClass('active');
        $('.overlay').removeClass('active');
    });

    $('.open-menu').on('click', function (e) {
        e.preventDefault();
        $('.sidebar').addClass('active');
        $('.overlay').addClass('active');
        $('.collapse.show').toggleClass('show');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});

$(".jumbotron").css({ height: ($(window).height() - $('#header').height())/2 + "px" });

$(window).on("resize", function () {
    $(".jumbotron").css({ height: ($(window).height() - $('#header').height())/2 + "px" });
});
