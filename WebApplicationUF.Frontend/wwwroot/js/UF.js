
function changeUFInformado() {
    const sigla = $('#siglaInput').val().trim().toUpperCase();
    const resultadoDiv = $('#resultadoVerificacao');
    
    

    $.ajax({
        url: urlRaiz + "/Verificador",
        method: "POST",
        data: { sigla: sigla },

        success: function (retorno) {
            $("#btnBuscar").trigger("click");
        },

        error: function (xhr, status, error) {
            alert("UF não encontrada!");

            $("#siglaInput").val("");
        }
    });
}


$("#siglaInput").on("change", function () {
    changeUFInformado();
});