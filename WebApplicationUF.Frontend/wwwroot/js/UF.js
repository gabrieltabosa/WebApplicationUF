
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
$('#formConsultaAjax').submit(function (e) {

    // Previne a ação padrão do formulário (que é fazer um POST completo e recarregar a página).
    e.preventDefault();

    // Armazena a referência ao formulário atual (usado para obter dados e URL).
    var form = $(this);

    // Serializa os dados do formulário (converte 'nome=valor&nome2=valor2').
    var formData = form.serialize();

    // Pega a URL de destino da submissão definida no Html.BeginForm (ex: /Home/ConsultaSigla).
    var url = form.attr('action');

    // Opcional: Mostra uma mensagem de carregamento enquanto espera a resposta.
    $('#tabelaCorpo').html('<tr><td colspan="4">Carregando dados...</td></tr>');

    // Inicia a requisição AJAX usando o objeto $.ajax do jQuery.
    $.ajax({
        url: url,           // A URL para onde enviar os dados.
        type: 'POST',       // O método HTTP (deve ser o mesmo do BeginForm).
        data: formData,     // Os dados serializados do formulário.

        // Função executada se a requisição for bem-sucedida (status 200).
        success: function (partialViewHtml) {
            // O servidor deve retornar o HTML da Partial View (_TabelaEstados).
            // Atualiza o conteúdo do <tbody> ('#tabelaCorpo') com o novo HTML retornado.
            $('#tabelaCorpo').html(partialViewHtml);

            // Opcional: Remove qualquer alerta de erro anterior, se existir.
            $('.alert-danger').alert('close');
        },
        error: function (xhr, status, error) {
            // ...
            // Aqui também você está substituindo o conteúdo do corpo da tabela.
            $('#tabelaCorpo').html('<tr class="table-danger"><td colspan="4">Falha ao consultar. Por favor, tente novamente.</td></tr>');
        }

        
    });
});

$("#siglaInput").on("change", function () {
    changeUFInformado();
});