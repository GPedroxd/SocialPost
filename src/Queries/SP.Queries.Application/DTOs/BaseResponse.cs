namespace SP.Queries.Application.Dtos;

public record BaseResponse<TSuccess>
{
    public bool Success { get; set; }
    public string? Message { get;set; }
    public TSuccess? SuccessResponse { get; set; }
}