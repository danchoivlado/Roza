using ApplicationService;
using ApplicationService.DTOs;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Author;
using MVC.Models.Book;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private BookManagmentService bookManagmentService = new BookManagmentService();
        private AuthorManagmentService authorManagmentService = new AuthorManagmentService();

        public IActionResult Index()
        {
            List<BookIndexViewModel> bookVM = new List<BookIndexViewModel>();
            foreach (var book in bookManagmentService.Get())
            {
                var author = this.authorManagmentService.GetById(book.AuthorId);
                bookVM.Add(new BookIndexViewModel(book, author.Name));
            }


            return View(bookVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<AuthorIndexViewModel> authorVM = new List<AuthorIndexViewModel>();

            foreach (var author in authorManagmentService.Get())
            {
                authorVM.Add(new AuthorIndexViewModel(author));
            }

            ViewBag.Authors = authorVM;

            return View(new BookCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel bookVM)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.ISBN = bookVM.ISBN;
            bookDTO.OnlineLink = bookVM.OnlineLink;
            bookDTO.AuthorId = bookVM.AuthorId;
            bookDTO.Name = bookVM.Name;

            bookManagmentService.Save(bookDTO);

            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            var book = this.bookManagmentService.GetById(id);
            var author = this.authorManagmentService.GetById(book.AuthorId);

            BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel()
            {
                AuthorName = author.Name,
                Id = book.Id,
                ISBN = book.ISBN,
                Name = book.Name,
                OnlineLink = book.OnlineLink
            };


            return View(bookDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = bookManagmentService.GetById(id);
            var author = this.authorManagmentService.GetById(book.AuthorId);


            return View(new BookDetailsViewModel(book, author.Name));
        }

        [HttpPost]
        public IActionResult Delete(BookDetailsViewModel model)
        {
            var book = bookManagmentService.Delete(model.Id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<AuthorIndexViewModel> authorVM = new List<AuthorIndexViewModel>();

            foreach (var author in authorManagmentService.Get())
            {
                authorVM.Add(new AuthorIndexViewModel(author));
            }

            ViewBag.Authors = authorVM;


            BookDTO bookDTO = this.bookManagmentService.GetById(id);



            return View(new BookEditViewModel()
            {
                Id = bookDTO.Id,
                AuthorId = bookDTO.AuthorId,
                ISBN = bookDTO.ISBN,
                Name = bookDTO.Name,
                OnlineLink = bookDTO.OnlineLink,
            });
        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel bookVM)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = bookVM.Id;
            bookDTO.ISBN = bookVM.ISBN;
            bookDTO.OnlineLink = bookVM.OnlineLink;
            bookDTO.AuthorId = bookVM.AuthorId;
            bookDTO.Name = bookVM.Name;

            bookManagmentService.Update(bookDTO);

            return RedirectToAction("index");
        }
    }
}
