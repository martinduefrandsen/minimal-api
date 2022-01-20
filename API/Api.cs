using DataAccess.Mediators;

namespace MartinDueAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Pets", GetPets);
    }

    private static async Task<IResult> GetPets(IMediator pets)
    {
        try
        {
            return Results.Ok(await pets.GetAll());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}