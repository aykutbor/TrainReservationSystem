using TrainReservationSystemApi.Models;

namespace TrainReservationSystemApi.Services
{
    public class RezervasyonService : IRezervasyonService
    {
        public RezervasyonSonucu RezervasyonYap(RezervasyonTalebi talep)
        {
            var sonuc = new RezervasyonSonucu();
            int kalanKisiSayisi = talep.RezervasyonYapilacakKisiSayisi;

            foreach (var vagon in talep.Tren.Vagonlar)
            {
                int musaitKoltukSayisi = (int)(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;

                if (musaitKoltukSayisi > 0)
                {
                    int yerlestirilecekKisi = Math.Min(kalanKisiSayisi, musaitKoltukSayisi);
                    sonuc.YerlesimAyrintisi.Add(new RezervasyonSonucu.YerlesimAyrinti
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = yerlestirilecekKisi
                    });

                    kalanKisiSayisi -= yerlestirilecekKisi;

                    if (kalanKisiSayisi == 0)
                        break;
                }
            }
            sonuc.RezervasyonYapilabilir = kalanKisiSayisi == 0;

            if (!talep.KisilerFarkliVagonlaraYerlestirilebilir && sonuc.YerlesimAyrintisi.Count > 1)
            {
                sonuc.RezervasyonYapilabilir = false;
                sonuc.YerlesimAyrintisi.Clear();
            }
            return sonuc;
        }
    }
}
