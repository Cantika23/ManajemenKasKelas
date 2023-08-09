namespace Kas.Transaksi.Services.Models
{
    public class GlobalException : Exception
    {
        public GlobalException(string code, string message)
    : base($"{code}: {message}")
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
        }

        public string ErrorCode { get; }
        public string ErrorMessage { get; }
    }
}
