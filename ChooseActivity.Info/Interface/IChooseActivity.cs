using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace ChooseActivity.Info.Interface;

public interface IChooseActivity
{
    Task<IEnumerable<ChosenActivityEntity>> GetAllChosenActivityOfAthletesAsync();
    Task<ChosenActivityEntity> GetChosenActivityOfAthletesInfoByIdAsync(int chosenActivityId);
    IActionResult CreateAnActivity(ChosenActivityEntity chosenActivityEntity);
    void DeleteChosenActivityOfAthletesByIdAsync(ChosenActivityEntity chosenActivityEntity);
}
