
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
function toggleDescricao(e) {
    $('#modalLoading').show();
    $('#descricaoEstadoContainer').hide();

    $.ajax({
        url: urlRaiz + '/GetById',
        type: 'GET',
        data: { e: e },
        success: function (data) {
            $('#estadoNome').text(data.nome);
            $('#estadoSigla').text(data.sigla);
            $('#estadoDescricao').text(data.descricao);

            $('#modalLoading').hide();
            $('#descricaoEstadoContainer').show();
        },
        error: function () {
            $('#modalLoading').text('Erro ao carregar os dados.');
        }
    });

    $('#modalDescricaoCompartilhado').modal('show');



}


$("#siglaInput").on("change", function () {
    changeUFInformado();
});
