var dir = "http://localhost:51470/api/";
var f = new Date();
var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
var oTabla = $("#tablaDatos").DataTable();
var vrInsc = 250000;

jQuery(function () {
    //Carga el menú
    $("#dvMenu").load("../Paginas/Menu.html");

    //Registrar los botones para responder al evento click
    $("#btnAgre").on("click", function () {
        alert("Agregar");
        //ejecutarComando("POST");
    });
    $("#btnModi").on("click", function () {
        alert("Modificar");
        //ejecutarComando("PUT");
    });
    $("#btnBusc").on("click", function () {
        alert("Buscar");
        //Consultar();
    });
    $("#btnCanc").on("click", function () {
        alert("Cancelar");
        //Cancelar();
    });
    $("#btnImpr").on("click", function () {
        alert("Impresión");
        //Imprimir();
    });
    $("#lblFechaAct").val(fecha);

    $("#txtValor").val(vrInsc);


    llenarComboEvento();
    llenarComboBanda();


});  //Del: jQuery


function mensajeError(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-danger");
    $("#dvMensaje").html(texto);
}
function mensajeInfo(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-info");
    $("#dvMensaje").html(texto);
}
function mensajeOk(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-success");
    $("#dvMensaje").html(texto);
}

async function llenarComboEvento() {
    let url = dir + "evento";
    let rpta = await llenarComboGral(url, "#cboEvento");
}

async function llenarComboBanda() {
    let url = dir + "banda";
    let rpta = await llenarComboGral(url, "#cboBanda");
    if (rpta == "Termino")
        llenarComboArtista();
}

async function llenarComboArtista(idArt) {
    let idB = $("#cboBanda").val();
    let url = dir + "BandArt?dato=" + idB + "&comando=1";
    let rpta = await llenarComboGral(url, "#cboBandArt");
    if (rpta == "Termino")
        consultarInstrum();
}

async function consultarInstrum() {
    mensajeInfo("");
    try {
        let idArt = $("#cboBandArt").val();
        if (idArt == undefined || idArt.trim() == "" || parseInt(idArt, 10) <= 0) {
            mensajeError("Error, no selección de artista");
            $("#cboBandArt").focus();
            return;
        }
        const datosOut = await fetch(dir + "BandArt?dato=" + idArt + "&comando=2",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "content-type": "application/json",
                }
            }
        );
        const datosIn = await datosOut.json();
        if (datosIn == "") {
            mensajeInfo("No se encontró instrumento para el artista ");
            return;
        }
        $("#txtInstrum").val(datosIn[0].Nombre);
    }
    catch (error) {
        mensajeError("Error: " + error);
    }
}


async function ejecutarComando(accion) {
    //Capturar los datos de entrada
    let _vr1 = $("#txtXXX").val();
    let _vr2 = $("#cboXXX").val();
    let _vr3 = $("#txtXXX").val();

    let _vr4 = $("#chkXXX").prop("checked");
    _vr4 = (_vr4 == true) ? 1 : 0;

    //Json es un lenguaje que permite gestionar datos con 
    //formato de estructura: Clave - Valor, y que puede contener 
    //estructuras complejas dentro de sus valores
    //Nombre: Valor
    let datosOut = {
        campo1: _vr1,
        campo2: _vr2,
        campo3: _vr3,
        campo4: _vr4
    }
    //Invocar el servicio con fetch
    try {
        const response = await fetch(dir + "nombre servicio", {
            method: accion,
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(datosOut),
        });   // stringify() convierte un objeto o valor de JavaScript en una cadena de texto JSON

        const Respuesta = await response.json();
        MensajeOk(Respuesta);

    } catch (error) {
        MensajeError("Error: ", error);
    }
}