using Ajax_Crud_Using_Model.Data;
using Ajax_Crud_Using_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_Crud_Using_Model.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<StudentViewModel> GetAll()
        {


            return _context.Students.Select(st => new StudentViewModel()
            {
                Id = st.Id,
                Name = st.Name,
                Address = st.Address


            }).ToList();


        }

        public StudentViewModel GetById(int id)
        {


            return _context.Students.Where(x => x.Id == id)
                .Select(st => new StudentViewModel()

                {
                    Id = st.Id,
                    Name = st.Name,
                    Address = st.Address

                }).FirstOrDefault();


        }

        public void Insert(StudentViewModel model)
        {

            var st = new Student()
            {
                Name = model.Name,
                Address = model.Address
            };

            _context.Students.Add(st);
            _context.SaveChanges();

        }

        public void Update(StudentViewModel model)
        {

            var st = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address
            };

            _context.Students.Update(st);
            _context.SaveChanges();

        }

        public void Delete(StudentViewModel model)
        {
            var st = new Student()
            {
                Id = model.Id,
                Name = model.Name
            };

            _context.Students.Update(st);
            _context.SaveChanges();
        }
    }
}
