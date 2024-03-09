using Microsoft.EntityFrameworkCore;
using TestCase.DataAccessLayer;
using TestCase.Parameter.ViewModel;

namespace TestCase.BusinessLogicLayer.Interface
{
    public interface IMyNoteService
    {
        public NoteViewModel QueryNote(NoteViewModel viewModel, MvcDBContext _context);
        public NoteViewModel UpdateNote(NoteViewModel viewModel, MvcDBContext _context);
        public NoteViewModel DeleteNote(NoteViewModel viewModel, MvcDBContext _context);

    }
}
