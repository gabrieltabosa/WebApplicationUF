
function changeUFInformado() {
    const sigla = $('#siglaInput').val().trim().toUpperCase();
    const resultadoDiv = $('#resultadoVerificacao');
    

    $.ajax({
        url: urlRaiz + "/Verificador",
        method: "POST",
        data: { sigla: sigla },

        success: function (retorno) {
            //quero que voce retorne a lista aqui e monte seu grid na mao , dependendo da uf informada
            
        },

        error: function (xhr, status, error) {
            // Captura a mensagem de erro do Controller (xhr.responseText)
            const errorMessage = xhr.responseText || "Erro desconhecido na verificação do estado.";
            resultadoDiv.html(`<div class="alert alert-danger">❌ ${errorMessage}</div>`);
            console.error("Erro na requisição:", status, error);
        }
    });
}

$("#siglaInput").on("change", function () {
    changeUFInformado();
});