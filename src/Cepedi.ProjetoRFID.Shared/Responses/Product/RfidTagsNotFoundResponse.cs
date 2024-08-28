public record class RfidTagsNotFoundResponse
{
    public string Message { get; init; }

    public RfidTagsNotFoundResponse(string rfidTag)
    {
        Message = $"Produto não encontrado para a tag {rfidTag}";
    }
}
