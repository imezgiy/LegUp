namespace DAL.Models.Helping
{
    public class HelpingModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ApplierId { get; set; }
        public int Status { get; set; } // 1 = Onaylanmış 2 = Beklemede 0 = Reddedilmiş
    }
}
