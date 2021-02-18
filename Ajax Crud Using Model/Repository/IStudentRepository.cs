using Ajax_Crud_Using_Model.ViewModel;
using System.Collections.Generic;

namespace Ajax_Crud_Using_Model.Repository
{
    public interface IStudentRepository
    {
        void Delete(StudentViewModel model);
        List<StudentViewModel> GetAll();
        StudentViewModel GetById(int id);
        void Insert(StudentViewModel model);
        void Update(StudentViewModel model);
    }
}