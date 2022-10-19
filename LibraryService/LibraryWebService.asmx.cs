using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LibraryService.Models;
using LibraryService.Services;
using LibraryService.Services.Impl;

namespace LibraryService
{
    /// <summary>
    /// Summary description for LibraryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryWebService : System.Web.Services.WebService
    {
        private readonly ILibraryRepositoryService _libraryRepositoryService;
        
        public LibraryWebService()
        {
            _libraryRepositoryService = new LibraryRepository(new LibraryDatabaseContext());
        }
        
        [WebMethod]
        public Book[] GetBookByTitle(string title)
        {
            return _libraryRepositoryService.GetByTitle(title).ToArray();
        }
        
        [WebMethod]
        public Book[] GetBookByCategory(string category)
        {
            return _libraryRepositoryService.GetByCategory(category).ToArray();
        }
        
        [WebMethod]
        public Book[] GetBookByAuthor(string authorName)
        {
            return _libraryRepositoryService.GetByAuthor(authorName).ToArray();
        }
    }
}
