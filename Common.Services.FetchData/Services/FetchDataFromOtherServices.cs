using AutoMapper;
using ChooseActivity.Info.Repository;
using Postgres.Context.DBContext;

namespace Common.Services.FetchData.Services
{
    public class FetchDataFromOtherServices
    {
        private readonly NpgsqlContext _context;
        private readonly IMapper _mapper;

        public FetchDataFromOtherServices(NpgsqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task GetDataFromChosenActivityServiceAsync()
        {
            try
            {
                var chosenActivities = new ChosenActivityInfoService(_context, _mapper);

                var list = await chosenActivities.GetAllChosenActivityOfAthletesAsync();

                foreach (var activity in list)
                {
                    // Do something with each activity
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
    }
}