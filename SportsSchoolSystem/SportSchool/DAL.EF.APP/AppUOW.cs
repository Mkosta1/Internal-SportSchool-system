using DAL.Contracts.App;
using DAL.EF.APP.Repositories;
using DAL.EF.Base;

namespace DAL.EF.APP;

public class AppUOW : EFBaseUOW<ApplicationDbContext>, IAppUOW
{
    public AppUOW(ApplicationDbContext dataContext) : base(dataContext)
    {
        
    }

    private ICompetitionRepository? _competitionRepository;
    private IExerciseRepository? _exerciseRepository;
    private ILocationRepository? _locationRepository;
    private IMessageRepository? _messageRepository;
    private IMonthlySubscriptionRepository? _monthlySubscriptionRepository;
    private ISportSchoolRepository? _sportSchoolRepository;
    private ITrainingRepository? _trainingRepository;
    private IUserAtTrainingRepository? _userAtTrainingRepository;
    private IUserInGroupRepository? _userInGroupRepository;
    private IUserGroupRepository? _userGroupRepository;
    private IUserTypeRepository? _userTypeRepository;

    public ICompetitionRepository CompetitionRepository =>
        _competitionRepository ??= new CompetitionRepository(UowDbContext);

    public IExerciseRepository ExerciseRepository =>
        _exerciseRepository ??= new ExcerciseRepository(UowDbContext);

    public ILocationRepository LocationRepository =>
        _locationRepository ??= new LocationRepository(UowDbContext);

    public IMessageRepository MessageRepository =>
        _messageRepository ??= new MessageRepository(UowDbContext);

    public IMonthlySubscriptionRepository MonthlySubscriptionRepository =>
        _monthlySubscriptionRepository ??= new MonthlySubscriptionRepository(UowDbContext);

    public ISportSchoolRepository SportSchoolRepository =>
        _sportSchoolRepository ??= new SportSchoolRepository(UowDbContext);

    public ITrainingRepository TrainingRepository =>
        _trainingRepository ??= new TrainingRepository(UowDbContext);

    public IUserAtTrainingRepository UserAtTrainingRepository =>
        _userAtTrainingRepository ??= new UserAtTrainingRepository(UowDbContext);

    public IUserInGroupRepository UserInGroupRepository =>
        _userInGroupRepository ??= new UserInGroupRepository(UowDbContext);

    public IUserGroupRepository UserGroupRepository =>
        _userGroupRepository ??= new UserGroupRepository(UowDbContext);

    public IUserTypeRepository UserTypeRepository =>
        _userTypeRepository ??= new UserTypeRepository(UowDbContext);
}