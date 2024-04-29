namespace DaneshkarShop.Domain.Entitties.Slider
{
    public class Slider
    {
        #region properties

        public int Id { get; set; }

        public string SliderImage { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        #endregion
    }
}
