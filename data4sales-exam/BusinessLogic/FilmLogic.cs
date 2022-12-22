using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FilmLogic : EntityLogic<Film>, IFilmLogic
    {
        public FilmLogic(IRepository<Film> planetRepository) : base(planetRepository) { }

        public Task Add(List<Film> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(Film entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Film entity)
        {
            throw new NotImplementedException();
        }
    }
}
