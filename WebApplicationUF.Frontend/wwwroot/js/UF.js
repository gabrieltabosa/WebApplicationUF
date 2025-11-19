
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
function toggleDescricao(id) {
    // Seleciona o botão que acionou esta função (exemplo: #btn_model_2).
    // Usamos $ para indicar uma variável que armazena um objeto jQuery.
    const $btn = $("#btn_model_" + id);

    // Seleciona o elemento que serve de "placeholder" (recipiente) para injetar o HTML do modal.
    // O modal em si é carregado dentro deste placeholder.
    const $placeholder = $("#modalPlaceholder");

    // Se o botão ($btn) foi encontrado (length > 0), remove o foco dele.
    // Isso evita que o botão permaneça com o estado de foco após ser clicado.
    if ($btn.length) $btn.blur();

    // --- Tratamento do Botão e Carregamento (Loading) ---

    // Desabilita o botão para evitar múltiplos cliques enquanto a requisição AJAX estiver pendente.
    if ($btn.length) $btn.prop("disabled", true);

    // Coloca um indicador de "Carregando..." dentro do placeholder do modal.
    // Isso dá feedback imediato ao usuário enquanto espera a resposta do servidor.
    $placeholder.html(`
        <div id="modalLoadingInline" style="text-align:center;padding:1rem;">
            Carregando...
        </div>
    `);

    // --- Requisição AJAX ---

    // Inicia a requisição AJAX usando o objeto jQuery $.ajax.
    $.ajax({
        
        url: urlRaiz + "/GetById",
        method: "POST",
        data: { id: id },

        // Espera que o servidor retorne um conteúdo no formato HTML (o partial view).
        dataType: "html",

        // Função executada quando a requisição for bem-sucedida (status 200 OK).
        success: function (html) {

            // Injeta o HTML retornado pelo servidor (o partial view do modal) dentro do placeholder.
            // O placeholder agora contém o HTML completo do modal preenchido.
            $placeholder.html(html);

            // --- Exibição do Modal (Bootstrap 5) ---

            // Pega o elemento DOM do modal pelo seu ID.
            const modalEl = document.getElementById("modalDescricaoCompartilhado");

            // Verifica se o elemento modal foi realmente injetado no DOM.
            if (modalEl) {
                // Tenta obter uma instância existente do modal (se já foi inicializado).
                let modalInstance = bootstrap.Modal.getInstance(modalEl);

                // Se a instância não existir, cria uma nova instância do Bootstrap Modal.
                if (!modalInstance) modalInstance = new bootstrap.Modal(modalEl);

                // Exibe o modal para o usuário.
                modalInstance.show();
            } else {
                // Se o elemento modal não foi encontrado no HTML retornado (um erro),
                // exibe uma mensagem de erro no console e no placeholder.
                console.error("Modal não encontrado no HTML retornado.");
                $placeholder.html(`<div class="alert alert-danger">
                    Erro: modal não encontrado.
                </div>`);
            }
        },

        // Função executada se a requisição falhar (ex: erro 404, 500, ou falha de conexão).
        error: function (xhr, status, err) {
            // Exibe uma mensagem de erro no placeholder, informando o código HTTP do erro.
            $placeholder.html(`
                <div class="alert alert-danger">
                    Erro ao carregar descrição (${xhr.status})
                </div>
            `);
            // Registra o erro detalhado no console para depuração.
            console.error("Erro AJAX:", err);
        },

        // Função executada independentemente de sucesso ou falha da requisição.
        complete: function () {
            // Reabilita o botão, permitindo que o usuário clique novamente.
            if ($btn.length) $btn.prop("disabled", false);
        }
    });
}


$("#siglaInput").on("change", function () {
    changeUFInformado();
});
