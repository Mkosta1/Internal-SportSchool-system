using BLL.Contracts.App;
using Domain;

namespace BLL.Contracts.Base;

public interface IAppBLL : IBaseBLL
{
    ICompetitionService CompetitionService { get; }
    IExcerciseService ExcerciseService { get; }
    ILocationService LocationService { get; }
    IMessageService MessageService { get; }
    IMonthlySubscriptionService MonthlySubscriptionService { get; }
    ISportsSchoolService SportsSchoolService { get; }
    ITrainingService TrainingService { get; }
    IUserAtTrainingService UserAtTrainingService { get; }
    IUserGroupService UserGroupService { get; }
    IUserInGroupService UserInGroupService { get; }
    IUserAtCompetitionService UserAtCompetitionService { get; }
}