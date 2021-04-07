document.addEventListener("DOMContentLoaded", function (event) {


    const cartButtons = document.querySelectorAll('.cart-button');

    cartButtons.forEach(button => {

        button.addEventListener('click', cartClick);

    });

    function cartClick() {
        let button = this;
        button.classList.add('clicked');
    }



});





function GetTotalCarrito() {
    $.ajax({
        url: "/VentaCabeceras/GetTotalCarrito",
        type: "post",
        cache: false,
        success: function (retorno) {
            $("#CantCarrito").html(retorno);
        },
        error: function (error) {

        }

    })
};



$(function () {
    var menues = $(".nav-link");
    menues.click(function () {
        menues.removeClass("active");
        $(this).addClass("active");
    });
});


$(function () {
    var Accordion = function (el, multiple) {
        this.el = el || {};
        this.multiple = multiple || false;

        var links = this.el.find('.link');

        links.on('click', { el: this.el, multiple: this.multiple }, this.dropdown)
    }

    Accordion.prototype.dropdown = function (e) {
        var $el = e.data.el;
        $this = $(this),
            $next = $this.next();

        $next.slideToggle();
        $this.parent().toggleClass('open');

        if (!e.data.multiple) {
            $el.find('.submenu').not($next).slideUp().parent().removeClass('open');
        };
    }

    var accordion = new Accordion($('#accordion'), false);
});





