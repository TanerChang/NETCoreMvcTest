using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TestCase.BusinessLogicLayer.Interface;
using TestCase.DataAccessLayer;
using TestCase.DataAccessLayer.Interface;
using TestCase.DataAccessLayer.Provider;
using TestCase.Parameter;
using TestCase.Parameter.ViewModel;

namespace TestCase.BusinessLogicLayer.Service
{
    public class MyNoteService: IMyNoteService
    {

        public NoteViewModel QueryNote(NoteViewModel viewModel,MvcDBContext _context)
        {
            viewModel.ResultModel = new List<NoteResultModel>();
            NoteResultModel RModel= new NoteResultModel();
            NoteProvider _noteProvider = new NoteProvider(_context);
            var GetList = _noteProvider.Search_Note(viewModel?.SearchModel);

            if (GetList != null && GetList.Count > 0)
            {
                foreach (var bean in GetList)
                {
                    RModel.Note_Sn_txt = bean.Note_Sn > 0 ? bean.Note_Sn.ToString() : "";
                    RModel.Note_Date_txt = bean.Note_Date?.ToString();
                    RModel.Note_Title = bean.Note_Title;
                    RModel.Note_Content = bean.Note_Content;
                    viewModel.ResultModel.Add(RModel);
                }
            }
            //轉換模組AutoMapper
          
            return viewModel;
        }

        public NoteViewModel UpdateNote(NoteViewModel viewModel, MvcDBContext _context)
        {
            try
            {
                NoteProvider _Provider = new NoteProvider(_context);
                M_Note NoteDB = new M_Note();
                //轉換成資料庫型態
                if (viewModel.SaveView != null)
                {
                    NoteDB.Note_Sn = string.IsNullOrWhiteSpace(viewModel.SaveView.Note_Sn_txt) ? 0 : int.Parse(viewModel.SaveView.Note_Sn_txt);
                    NoteDB.Note_Date = string.IsNullOrWhiteSpace(viewModel.SaveView.Note_Date_txt) ? null : DateTime.Parse(viewModel.SaveView.Note_Date_txt);
                    NoteDB.Note_Title = viewModel.SaveView.Note_Title;
                    NoteDB.Note_Content = viewModel.SaveView.Note_Content;

                    if (NoteDB.Note_Sn > 0)
                    {
                        viewModel.result = _Provider.UpdateNote(NoteDB);
                    }
                    else
                    {
                        viewModel.result = _Provider.AddNote(NoteDB);
                    }

                }
                if (viewModel.result)
                {
                    viewModel.messager = "筆記更新成功!";
                }
                else
                {
                    viewModel.messager = "筆記更新失敗!";
                }
            }
            catch (Exception ex)
            {
                viewModel.result = false;
                viewModel.error = true;
                viewModel.exception = ex;
                viewModel.messager = "執行錯誤" + ex.ToString();

            }
            return viewModel;
        }

        public NoteViewModel DeleteNote(NoteViewModel viewModel, MvcDBContext _context)
        {
            try
            {
                NoteProvider _Provider = new NoteProvider(_context);
                M_Note NoteDB = new M_Note();
                //轉換成資料庫型態
                NoteDB.Note_Sn = string.IsNullOrWhiteSpace(viewModel.SearchModel.NoteSN) ? 0 : int.Parse(viewModel.SearchModel.NoteSN);
                if (NoteDB.Note_Sn > 0)
                {
                    viewModel.result = _Provider.DelteNote(NoteDB);
                }
                else
                {
                    viewModel.result = false;
                }


                if (viewModel.result)
                {
                    viewModel.messager = "筆記刪除成功!";
                }
                else
                {
                    viewModel.messager = "筆記刪除失敗!";
                }
            }
            catch (Exception ex)
            {
                viewModel.result = false;
                viewModel.error = true;
                viewModel.exception = ex;
                viewModel.messager = "執行錯誤" + ex.ToString();
            }
            return viewModel;
        }
    }
}
