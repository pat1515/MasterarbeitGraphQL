using GraphQL.Types;
using MasterarbeitRestServer.Models;

namespace MasterarbeitGraphQL.GraphQL
{
    public class AutorType: ObjectGraphType<Autor>
    {
        public AutorType()
        {
            Name = "Autor";

            Field(x => x.ID, type: typeof(IdGraphType));
            Field(x => x.VORNAME).Name("vorname");
            Field(x => x.NACHNAME).Name("nachname");
            Field(x => x.ALTER).Name("alter");
            Field(x => x.ORT).Name("ort");
            Field(x => x.LAND).Name("land");
            Field(x => x.GROESSE).Name("groesse");
            Field(x => x.BUECHER, type: typeof(ListGraphType<BuchType>)).Name("buecher");
        }
    }
}