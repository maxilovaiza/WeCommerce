function BuscarCategoria(categoria, marca) {
    var categories = categoria;
    var marcas = marca
    window.location = "/ProductosVistaController1/Index?category=" + categories + "&marca=" + marcas;
   


}
function TodosLosProductos(){
    window.location = "/ProductosVistaController1/Index";
}