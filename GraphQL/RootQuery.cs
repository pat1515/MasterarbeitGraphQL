using GraphQL.Types;
using MasterarbeitGraphQL.Data;

namespace MasterarbeitGraphQL.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IRepository repository)
        {
            Field<AutorType>(
                "Autor",
                "Autor nach ID suchen",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> 
                        { Name = "id", Description = "ID des Autors" }),
                    resolve: context =>
                    {
                        var id = context.GetArgument<int>("id");
                        return repository.GetAutorAusId(id);
                    }               
            );

            Field<ListGraphType<AutorType>>(
                "Autoren",
                "Liste an Autoren",
                arguments: new QueryArguments(
                    // Optionales QueryArgument
                    new QueryArgument<IntGraphType>  
                        { Name = "first", Description = "Einschränkung auf die ersten X Autoren" }),
                    resolve: context =>
                    {
                        if (context.HasArgument("first"))
                        {
                            int first = context.GetArgument<int>("first");
                            return repository.GetErsteXAutoren(first);
                        }
                        else
                        {
                            return repository.GetAlleAutoren();
                        }
                    }
            );
        
        }
    }
}