function BuscarCategoria(categoria, marca) {
    var categories = categoria;
    var marcas = marca
    window.location = "/ProductosVistaController1/Index?category=" + categories + "&marca=" + marcas;
   


}
function TodosLosProductos(){
    window.location = "/ProductosVistaController1/Index";
}

$("#CategoryIdCmb").change(function () {
    redirection();
});
$("#MarcasIdCmb").change(function () {
    redirection();
});
$("#FilterStr").change(function () {
    redirection();
});

//java script
var input = document.getElementById("FilterStr");

// Execute a function when the user releases a key on the keyboard
input.addEventListener("keyup", function (event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        // Cancel the default action, if needed
        event.preventDefault();
        // Trigger the button element with a click
        redirection();
    }
});

function redirection() {
    var str = $("#FilterStr").val();
    var idCategory = $("#CategoryIdCmb").val();
    var idMarcas = $("#MarcasIdCmb").val();

    window.location = "/Products/Index?idCategory=" + idCategory + "&idMarcas=" + idMarcas + "&strFilter=" + str ;
}