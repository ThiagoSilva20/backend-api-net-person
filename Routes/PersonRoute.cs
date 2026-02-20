using System.Reflection.Metadata;
using backend_api_net.Data;
using backend_api_net.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api_net.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");

        route.MapPost("",
            async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.Name);
            await context.Person.AddAsync(person);
            await context.SaveChangesAsync();
            return Results.Created($"/person/{person.Id}", person);
        });

        route.MapGet("",
            async (PersonContext context) =>
            {
                var people = await context.Person.AsNoTracking().ToListAsync();
                return Results.Ok(people);
            });

        route.MapPut("{id:guid}",
            async (Guid id, PersonRequest req, PersonContext context) =>
            {
                var people = await context.Person.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (people == null) return Results.NotFound();

                people.ChangeName(req.Name);
                await context.SaveChangesAsync();
                return Results.Ok(people);

            });

        route.MapDelete("{id:guid}",
            async (Guid id, PersonContext context) =>
            {
                var people = await context.Person
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (people == null)
                    return Results.NotFound();

                people.SetInactive();
                await context.SaveChangesAsync();
                return Results.Ok(people);
            }
        );
    }
}
