
namespace MKKWebApplication.Models
{
    public class CreateSiswaModel
    {

        public string nama_lengkap { get; set; } = null!;
        public string kelasId { get; set; } = null!; 
        public string Kelas { get; set; } = null!;
        public string nisn { get; set; } = null!;
        public DateTime tanggalLahir { get; set; }
    }
}
