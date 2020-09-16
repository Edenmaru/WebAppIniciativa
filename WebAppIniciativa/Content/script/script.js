$("#arriba").hover(
    function () {
        $(this).css('opacity', '0.5');
       



    }, function () {
        $("#strong").remove();
        $(this).css('opacity', '1')
    }
);


$('.btnEditar').click(function (eve) {


    $("#modal-content").load("/Negocios/Select/" + $(this).data("id"));

});


$('#actualizaEmail').click(function () {

    $('.inputEmail').slideToggle("slow", function () {
        // Animation complete.
    });
});

$('#actualizaDireccion').click(function () {

    $('.inputDireccion').slideToggle("slow", function () {
        // Animation complete.
    });
});
$('#actualizaUsuario').click(function () {

    $('.inputUsuario').slideToggle("slow", function () {
        // Animation complete.
    });
});
$('#actualizaClave').click(function () {

    $('.inputClave').slideToggle("slow", function () {
        // Animation complete.
    });
});
