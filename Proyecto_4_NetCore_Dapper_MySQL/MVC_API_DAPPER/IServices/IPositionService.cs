using MVC_API_DAPPER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API_DAPPER.IServices
{
    public interface IPositionService
    {
        Position Save(Position oPosition);
        List<Position> Gets();
        Position Get(int positionId);
        string Delete(int positionId);
    }
}
