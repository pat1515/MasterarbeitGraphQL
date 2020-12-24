using System.Collections.Generic;
using MasterarbeitRestServer.Models;

namespace MasterarbeitGraphQL.Data
{
    public interface IRepository
    {
         // Alle Autoren zurückgeben
        IEnumerable<Autor> GetAlleAutoren();
        
        // Einen bestimmten Autor anhand der ID (Primärschlüssel) zurückgeben
        Autor GetAutorAusId(int id); 

        // Die ersten X Autoren
        IEnumerable<Autor> GetErsteXAutoren(int X);       
    }
}