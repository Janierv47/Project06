//Se usa el document on ready 
//que nos permite darnos cuenta cuando todo el contenido 
//como html, scripts y hojas de estilo han sido descargados
//o se encuentran disponibles

$(function () {
    creaValidaciones();
});

//crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmTipoCliente").validate(
        {
            //El objeto que contiene "las condiciones" que el formulario debe cumplir para ser considerado válido
            rules: {
                nombre: {
                    required: true,
                    minlength: 3,
                    maxlength: 7
                },
                descripcion: {
                    required: true,
                    minlength: 3,
                    maxlength: 7
                },
            }
        }

    );
}