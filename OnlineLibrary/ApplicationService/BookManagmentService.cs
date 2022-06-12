using ApplicationService.DTOs;
using Data.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class BookManagmentService
    {
        public List<BookDTO> Get()
        {
            List<BookDTO> bookList = new List<BookDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BookRepository.Get())
                {
                    BookDTO book = new BookDTO(item);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public BookDTO GetById(int id)
        {
            BookDTO bookDto = new BookDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Book book = unitOfWork.BookRepository.GetByID(id);
                if (book != null)
                {
                    bookDto = new BookDTO(book);
                }
            }

            return bookDto;
        }

        public bool Save(BookDTO bookDto)
        {
            Book book = new Book()
            {
                Id = bookDto.Id,
                Name = bookDto.Name,
                ISBN = bookDto.ISBN,
                OnlineLink = bookDto.OnlineLink,
                AuthorId = bookDto.AuthorId
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.BookRepository.Insert(book);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Book book = unitOfWork.BookRepository.GetByID(id);
                    unitOfWork.BookRepository.Delete(book);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BookDTO bookDto)
        {
            Book book = new Book()
            {
                Id = bookDto.Id,
                Name = bookDto.Name,
                ISBN = bookDto.ISBN,
                OnlineLink = bookDto.OnlineLink,
                AuthorId = bookDto.AuthorId
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.BookRepository.Update(book);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
