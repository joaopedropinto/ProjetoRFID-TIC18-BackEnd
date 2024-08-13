namespace Cepedi.ProjetoRFID.Shared.Responses.Product;
// var response = products.Select(p => new GetProductsByRfidsResponse(p.Id, p.Name, p.Description, p.Weight, p.ManufacDate, p.DueDate, p.UnitMeasurement, p.PackingType, p.BatchNumber, p.Quantity, p.Price)).ToList();

public record class GetProductsByRfidsResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Peso { get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
    public string UnidadeMedida { get; set; }
    public string TipoEmbalagem { get; set; }
    public string NumeroLote { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }


    public GetProductsByRfidsResponse(int id, string nome, string descricao, decimal peso, DateTime dataFabricacao, DateTime dataValidade, string unidadeMedida, string tipoEmbalagem, string numeroLote, int quantidade, decimal preco)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Peso = peso;
        DataFabricacao = dataFabricacao;
        DataValidade = dataValidade;
        UnidadeMedida = unidadeMedida;
        TipoEmbalagem = tipoEmbalagem;
        NumeroLote = numeroLote;
        Quantidade = quantidade;
        Preco = preco;
    }
}
