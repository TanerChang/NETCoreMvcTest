using TestCase.Parameter;
using TestCase.Parameter.ViewModel;

namespace TestCase.DataAccessLayer.Interface
{
    public interface INoteProvider
    {
        public IList<M_Note> Search_Note(NoteSearchModel searchModel);

        public bool AddNote(M_Note note);

        public bool UpdateNote(M_Note note);

        public bool DelteNote(M_Note note);
    }
}
