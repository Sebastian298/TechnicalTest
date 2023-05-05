namespace TechnicalTest.Models.BusinessLogic
{
    public class Interview
    {
        public int Id { get; set; }
        public string Vacancy { get; set; }
        public string Prospect { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Notes { get; set; }
        public bool Recruited { get; set; }
    }
}
