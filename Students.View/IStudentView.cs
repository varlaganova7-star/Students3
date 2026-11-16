using Students.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Students.View
{
    public interface IStudentView
    {
        
        string FirstName { get; }
        string LastName { get; }
        string Group { get; }
        int SelectedStudentId { get; }

        
        event Action AddClicked;
        event Action DeleteClicked;
        event Action LoadClicked;

        
        void SetStudents(List<Student> students);
        void ShowMessage(string message);
        void ClearInputFields();
    }
}