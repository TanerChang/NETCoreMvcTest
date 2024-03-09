using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TestCase.DataAccessLayer.Interface;
using TestCase.Parameter;
using TestCase.Parameter.ViewModel;

namespace TestCase.DataAccessLayer.Provider
{    public class NoteProvider: INoteProvider
    {
        private readonly MvcDBContext _context;
        public NoteProvider(MvcDBContext context)
        {
            _context = context;
        }
        public IList<M_Note> Search_Note(NoteSearchModel searchModel)
        {
            StringBuilder SbSql = new StringBuilder();
            SqlCommand objCommand = new SqlCommand();
            SbSql.Append("SELECT * " + Environment.NewLine);
            SbSql.Append("FROM M_Note " + Environment.NewLine);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            if (searchModel?.NDate_S != null)
            {
                SbSql.Append("AND Note_Date >= @NDate_S" + Environment.NewLine);
                objCommand.Parameters.Add(new SqlParameter("@NDate_S", searchModel.NDate_S));
            }
            if (searchModel?.NDate_E != null)
            {
                SbSql.Append("AND Note_Date <= @NDate_E" + Environment.NewLine);
                objCommand.Parameters.Add(new SqlParameter("@NDate_E", searchModel.NDate_E));
            }
            if (searchModel?.NTitle != null)
            {
                SbSql.Append("AND Note_Title <= @NTitle" + Environment.NewLine);
                objCommand.Parameters.Add(new SqlParameter("@NTitle", searchModel.NTitle));
            }
            return _context.M_Note.FromSqlRaw(SbSql.ToString()).ToList();
        }
        public bool AddNote(M_Note note)
        {
            try
            {
                _context.M_Note.Add(note);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _context.Entry(note).State = EntityState.Unchanged;
                return false;
            }
       
        }
        public bool UpdateNote(M_Note note)
        {
            try
            {
                _context.M_Note.Update(note);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _context.Entry(note).State = EntityState.Unchanged;
                return false;
            }
        }
        public bool DelteNote(M_Note note)
        {
            try
            {
                _context.M_Note.Remove(note);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _context.Entry(note).State = EntityState.Unchanged;
                return false;
            }
        }
        //public void AddM_Note(M_Note note)
        //{
        //    StringBuilder SbSql = new StringBuilder();
        //    SqlParameter objParameter = new SqlParameter();
        //    _context.Database.ExecuteSqlRaw("INSERT INTO M_Note (Column1, Column2) VALUES ({0}, {1})", note.Column1, note.Column2);
        //}
        //public void UpdateM_Note(M_Note note)
        //{
        //    _context.Database.ExecuteSqlRaw("UPDATE M_Note SET Column1 = {0}, Column2 = {1} WHERE Id = {2}", note.Column1, note.Column2, note.Id);
        //}

        //public void DeleteM_Note(int id)
        //{
        //    _context.Database.ExecuteSqlRaw("DELETE FROM M_Note WHERE Id = {0}", id);
        //}
    }
}
