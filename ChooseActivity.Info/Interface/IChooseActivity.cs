using ChooseActivity.Info.Model;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace ChooseActivity.Info.Interface;

public interface IChooseActivity
{
    Task<IEnumerable<ChooseActivityInfo>> GetAllChosenActivityOfAthletesAsync();
    Task<ChosenActivityEntity> GetChosenActivityOfAthletesInfoByIdAsync(int chosenActivityId);
    IActionResult CreateAnActivity(ChooseActivityInfo chosenActivityEntity);
    void DeleteChosenActivityOfAthletesByIdAsync(ChosenActivityEntity chosenActivityEntity);
}
