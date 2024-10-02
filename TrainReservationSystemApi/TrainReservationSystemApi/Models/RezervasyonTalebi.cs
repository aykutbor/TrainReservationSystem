namespace TrainReservationSystemApi.Models
{
    public class RezervasyonTalebi
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir {  get; set; }
    }
}
