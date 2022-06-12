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
    public class AuthorManagmentService
    {
        public List<AuthorDTO> Get()
        {
            List<AuthorDTO> authorList = new List<AuthorDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.AuthorRepository.Get())
                {

                    AuthorDTO author = new AuthorDTO(item);
                    authorList.Add(author);
                }
            }
            return authorList;
        }
        public AuthorDTO GetById(int id)
        {
            AuthorDTO authorDTO = new AuthorDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Author author = unitOfWork.AuthorRepository.GetByID(id);


                if (author != null)
                {
                    authorDTO = new AuthorDTO(author);
                }

                if (author.Books != null)
                {
                    authorDTO.Books = author.Books.ToList();
                }

            }

            return authorDTO;
        }

        public bool Save(AuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                Id = authorDTO.Id,
                Name = authorDTO.Name,
                IsAlive = authorDTO.IsAlive,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AuthorRepository.Insert(author);
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
                    Author author = unitOfWork.AuthorRepository.GetByID(id);
                    unitOfWork.AuthorRepository.Delete(author);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(AuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                Id = authorDTO.Id,
                Name = authorDTO.Name,
                IsAlive = authorDTO.IsAlive,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AuthorRepository.Update(author);
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
