namespace TestCase.Parameter.ViewModel
{
    public class NoteViewModel
    {
        public NoteSearchModel SearchModel { get; set; }
        public List<NoteResultModel> ResultModel { get; set; }
        public NoteResultModel SaveView { get; set; }

        public bool result { get; set; }
        public bool error { get; set; }
        public string messager { get; set; }
        public Exception exception { set; get; }
    }
}
