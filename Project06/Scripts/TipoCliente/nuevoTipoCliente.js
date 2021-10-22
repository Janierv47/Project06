///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoTipoCliente").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            nombre: {
                required: true,
                minlength: 3,
                maxlength: 7
            },
            descripcion: {
                required: true
            },
            
        }
    });
}