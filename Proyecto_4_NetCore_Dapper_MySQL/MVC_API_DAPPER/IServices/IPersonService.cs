using MVC_API_DAPPER.Models;
using System.Collections.Generic;

namespace MVC_API_DAPPER.IServices
{
    public interface IPersonService
    {
        Person Save(Person oPerson);
        List<Person> Gets();
        Person Get(int personId);
        string Delete(int personId);
    }
}