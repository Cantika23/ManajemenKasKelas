namespace Kas.Transaksi.Services.Models
{
    public class ResponseBase<T>
    {
        public string Code { get; set; } = null!;
        public string Message { get; set; } = null!;
        public T? Data { get; set; }
    }
}
