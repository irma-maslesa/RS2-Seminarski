namespace Pelikula.API.Model.FilmskaLicnost
{
    public partial class FilmskaLicnostUpsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool IsReziser { get; set; }
        public bool IsGlumac { get; set; }
    }
}
