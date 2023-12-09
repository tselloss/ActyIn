using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Interface;
public interface IMatchModel
{
    Task<IEnumerable<MatchModelEntity>> GetAllMatchModelsOfAthletesAsync();
    Task<MatchModelEntity> GetMatchModelsOfAthletesInfoByIdAsync(int matchModelId);
    IActionResult SaveMatchModelOfUser(MatchModelEntity matchModel);
    void DeleteMatchModelOfAthleteByIdAsync(MatchModelEntity matchModel);
}
