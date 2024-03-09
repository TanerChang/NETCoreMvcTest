using Microsoft.AspNetCore.Mvc;
using TestCase.BusinessLogicLayer.Interface;
using TestCase.BusinessLogicLayer.Service;
using TestCase.DataAccessLayer;
using TestCase.DataAccessLayer.Interface;
using TestCase.DataAccessLayer.Provider;
using TestCase.Parameter.ViewModel;

namespace TestCase.Controllers
{
    public class MyNoteController : Controller
    {
        // GET: SVM020103
        MyNoteService _MyNoteService;
        private readonly MvcDBContext _context;

        public MyNoteController(MvcDBContext context)
        {
            _context = context;
            _MyNoteService = new MyNoteService();
        }
        public IActionResult MyNote()
        {
            return View();
        }
        public IActionResult Table(int limit, int offset, NoteViewModel ViewModel)
        {
            ViewModel = _MyNoteService.QueryNote(ViewModel, _context);
            var total = ViewModel.ResultModel.Count;
            var rows = ViewModel.ResultModel.ToList();
            return Json(new { total, rows });
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <info>Author: Taner; Date: 2024/03/09 </info>
        /// <history>
        /// xx.  YYYY/MM/DD   Ver   Author      Comments
        /// ===  ==========  ====  ==========  ==========
        /// 01.  2024/03/09  1.00    taner       Creat
        /// </history> 
        public ActionResult Update(NoteViewModel model)
        {
            model = _MyNoteService.UpdateNote(model, _context);
            
            return Json(model);
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <info>Author: Taner; Date: 2024/03/09 </info>
        /// <history>
        /// xx.  YYYY/MM/DD   Ver   Author      Comments
        /// ===  ==========  ====  ==========  ==========
        /// 01.  2024/03/09  1.00    taner       Delete
        /// </history> 
        public ActionResult Delete(NoteViewModel model)
        {
            model = _MyNoteService.DeleteNote(model, _context);

            return Json(model);
        }
    }
}
