///document on ready del view Registro de TipoCuenta
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoTipoCuenta").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            nombre: {
                required: true,
                minlength: 3,
                maxlength: 15
            },
            codigo: {
                required: true
            },

        }
    });
}