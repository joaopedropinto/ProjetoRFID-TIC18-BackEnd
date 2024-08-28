public record class RfidTagsNotFoundResponse
{
    public string RfidTag { get; init; }
    public string Message { get; init; }

    public RfidTagsNotFoundResponse(string rfidTag)
    {
        RfidTag = rfidTag;
        Message = $"Produto não encontrado para a tag {rfidTag}";
    }
}
