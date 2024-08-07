using Cepedi.ProjetoRFID.Shared.Exceptions;

namespace Cepedi.ProjetoRFID.Shared.Enums;
public class RegisteredErrors
{
    public static readonly ErrorResult Generic = new()
    {
        ErrorTitle = "Ops ocorreu um erro no nosso sistema",
        ErrorDescription = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = TypeError.Erro
    };

    public static readonly ErrorResult SemResultados = new()
    {
        ErrorTitle = "Sua busca não obteve resultados",
        ErrorDescription = "Tente buscar novamente",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult DadosInvalidos = new()
    {
        ErrorTitle = "Dados inválidos",
        ErrorDescription = "Os dados enviados na requisição são inválidos",
        Tipo = TypeError.Erro
    };

    public static ErrorResult ErroGravacaoUsuario = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação do usuário. Por favor tente novamente",
        Tipo = TypeError.Erro
    };

    public static ErrorResult ErroGravacaoPessoa = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Pessoa. Por favor tente novamente",
        Tipo = TypeError.Erro
    };

    public static ErrorResult ErroGravacaoMovimentacao = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Movimentacao. Por favor tente novamente",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ErroGravacaoConsulta = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Consulta. Por favor tente novamente",
        Tipo = TypeError.Erro
    };

    public static ErrorResult IdMovimentacaoInvalido = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da movimentação especificada não é válido",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult IdTipoMovimentacaoInvalido = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do tipo de movimentação especificado não é válido",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult IdPessoaInvalido = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da pessoa especificada não é válido",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult IdConsultaInvalido = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da consulta especificada não é válido",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult IdScoreInvalido = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do score especificado não é válido",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ScoreJaExistente = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Essa pessoa já tem um score associado",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ListaMovimentacoesVazia = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de movimentações retornada está vazia",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ListaScoresVazia = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de scores retornada está vazia",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ListaTiposMovimentacaoVazia = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de tipos de movitação retornada está vazia",
        Tipo = TypeError.Alerta
    };

    public static ErrorResult ListaConsultasVazia = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de consultas retornada está vazia",
        Tipo = TypeError.Alerta
    };
}