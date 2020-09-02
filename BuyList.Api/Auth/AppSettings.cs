namespace BuyList.Api.Auth
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationsHour { get; set; }
        public string Emitter { get; set; }
        public string ValidIn { get; set; }
    }
}
