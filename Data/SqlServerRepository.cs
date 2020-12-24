using System.Collections.Generic;
using System.Linq;
using MasterarbeitRestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterarbeitGraphQL.Data
{
    class SqlServerRepository : IRepository
    {
        // Verweis auf den Datenbank Kontext
        private readonly ApiContext _context;

        // Konstruktor
        public SqlServerRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Autor> GetAlleAutoren()
        {
            return _context.AUTOR.Include(a => a.BUECHER);
        }

        public Autor GetAutorAusId(int id)
        {
            return _context.AUTOR.Include(async => async.BUECHER).FirstOrDefault(i => i.ID == id);
        }

        public IEnumerable<Autor> GetErsteXAutoren(int X)
        {
            return _context.AUTOR.Include(a => a.BUECHER).Where(i => i.ID <= X);
        }
    }
}