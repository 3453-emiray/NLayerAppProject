namespace NLayer.Core.Models
{
    public abstract class BaseEntity //baseentityden nesne örneğinde alınmasın diye abstract kullandım // bu alan projenin classlar için ortak property ve metodları tanımlarız
    {
        public int Id { get; set; }   //her entityde bu 3 alan olmalı // interfacelerdede genelde kontratlar tanımlanır ama abstaract ile de yapabiliriz çünki ikiside soyut
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
