using ApplicationService;
using ApplicationService.DTOs;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Author;

namespace MVC.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorManagmentService authorManagmentService = new AuthorManagmentService();

        public IActionResult Index()
        {
            List<AuthorIndexViewModel> authorVM = new List<AuthorIndexViewModel>();
            foreach (var author in authorManagmentService.Get())
            {
                authorVM.Add(new AuthorIndexViewModel(author));
            }

            return View(authorVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AuthorCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel authorVM)
        {

            AuthorDTO authorDTO = new AuthorDTO();
            authorDTO.IsAlive = authorVM.IsAlive;
            authorDTO.Name = authorVM.Name;
            authorManagmentService.Save(authorDTO);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = authorManagmentService.GetById(id);

            return View(new AuthorIndexViewModel(author));
        }

        [HttpPost]
        public IActionResult Delete(AuthorIndexViewModel model)
        {
            var auhtor = authorManagmentService.Delete(model.Id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            AuthorDTO authorDto = this.authorManagmentService.GetById(id);



            return View(new AuthorIndexViewModel()
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                IsAlive = authorDto.IsAlive
            });
        }

        public IActionResult Details(int id)
        {
            var author = this.authorManagmentService.GetById(id);

            AuthorDetailsViewModel authorViewModel = new AuthorDetailsViewModel()
            {
                Id = author.Id,
                IsAlive = author.IsAlive,
                Name = author.Name,
                Books = author.Books
            };


            return View(authorViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorDetailsViewModel authoVM)
        {
            AuthorDTO authorDto = new AuthorDTO();
            authorDto.Id = authoVM.Id;
            authorDto.Name = authoVM.Name;
            authorDto.IsAlive = authoVM.IsAlive;

            authorManagmentService.Update(authorDto);

            return RedirectToAction("index");
        }
    }
}
