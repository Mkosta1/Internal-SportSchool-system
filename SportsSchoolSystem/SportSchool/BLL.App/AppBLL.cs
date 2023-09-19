using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Contracts.App;
using BLL.Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    protected IAppUOW Uow;
    private readonly IMapper _mapper;
    
    public AppBLL(IAppUOW uow, IMapper mapper) : base(uow)
    {
        Uow = uow;
        _mapper = mapper;
    }

    private ICompetitionService? _competition;
    public ICompetitionService CompetitionService =>
        _competition ??= new CompetitionService(Uow, new CompetitionMapper(_mapper));
    
    private IExcerciseService? _excercise;
    public IExcerciseService ExcerciseService =>
        _excercise ??= new ExcerciseService(Uow, new ExcerciseMapper(_mapper));

    private ILocationService? _location;
    public ILocationService LocationService =>
        _location ??= new LocationService(Uow, new LocationMapper(_mapper));

    private IMessageService? _message;
    public IMessageService MessageService =>
        _message ??= new MessageService(Uow, new MessageMapper(_mapper));

    private IMonthlySubscriptionService? _monthlySubscription;
    public IMonthlySubscriptionService MonthlySubscriptionService =>
        _monthlySubscription ??= new MonthlySubscriptionService(Uow, new MonthlySubscriptionMapper(_mapper));

    private ISportsSchoolService? _sportsSchool;
    public ISportsSchoolService SportsSchoolService =>
        _sportsSchool ??= new SportsSchoolService(Uow, new SportSchoolsMapper(_mapper));

    private ITrainingService? _training;
    public ITrainingService TrainingService =>
        _training ??= new TrainingService(Uow, new TrainingMapper(_mapper));
 
    private IUserAtTrainingService? _userAtTraining;
    public IUserAtTrainingService UserAtTrainingService =>
        _userAtTraining ??= new UserAtTrainingService(Uow, new UserAtTrainingMapper(_mapper));

    private IUserGroupService? _userGroup;
    public IUserGroupService UserGroupService =>
        _userGroup ??= new UserGroupService(Uow, new UserGroupMapper(_mapper));

    private IUserInGroupService? _userInGroup;
    public IUserInGroupService UserInGroupService =>
        _userInGroup ??= new UserInGroupService(Uow, new UserInGroupMapper(_mapper));
    
    
    private IUserAtCompetitionService? _userAtCompetition;
    public IUserAtCompetitionService UserAtCompetitionService=> 
    _userAtCompetition ??= new UserAtCompetitionService(Uow, new UserAtCompetitionMapper(_mapper));

}