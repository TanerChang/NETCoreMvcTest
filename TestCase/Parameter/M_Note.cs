using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase.Parameter
{
    public class M_Note
    {
        public int Note_Sn { get; set; }
        public DateTime? Note_Date { get; set; }
        public string Note_Title { get; set; }
        public string Note_Content { get; set; }
    }
}
