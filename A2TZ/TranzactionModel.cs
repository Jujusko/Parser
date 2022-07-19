namespace A2TZ
{
    public class TranzactionModel
    {
        public UserModel Buyer { get; set; }
        public UserModel Seller { get; set; }
        public string Declaration { get; set; }
        public string Date { get; set; }
        public string Value { get; set; }
    }
}
