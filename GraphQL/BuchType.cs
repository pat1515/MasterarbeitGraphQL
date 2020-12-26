using GraphQL.Types;
using MasterarbeitRestServer.Models;

namespace MasterarbeitGraphQL.GraphQL
{
    public class BuchType: ObjectGraphType<Buch>
    {
        public BuchType()
        {
            Name = "Buch";

            Field(x => x.ID, type: typeof(IdGraphType)).Name("id");
            Field(x => x.TITEL).Name("titel");
            Field(x => x.ISBN).Name("isbn");
            Field(x => x.ERSCHEINUNGSDATUM).Name("erscheinungsdatum");
            Field(x => x.VERLAG).Name("verlag");
            Field(x => x.DRUCKORT).Name("druckort");
            Field(x => x.SPRACHE).Name("sprache");
            Field(x => x.AUTOR, type: typeof(AutorType)).Name("autor");
        }
    }
}