namespace WebUF.ViewModel
{
    public class ApiResponse<T>
    {
        public bool Sucesso { get; set; }       // indica se deu certo ou não
        public T? Data { get; set; }            // dado retornado (pode ser qualquer tipo)
        public string? Erro { get; set; }      // mensagem de erro, se houver

        public ApiResponse() { }

        public ApiResponse(T data)
        {
            Sucesso = true;
            Data = data;
        }

        public ApiResponse(string error)
        {
            Sucesso = false;
            Erro = error;
        }
    }
}
