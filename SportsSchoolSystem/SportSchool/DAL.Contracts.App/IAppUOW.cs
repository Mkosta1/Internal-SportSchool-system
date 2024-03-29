﻿using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IAppUOW : IBaseUOW
{
    
    ICompetitionRepository CompetitionRepository { get; }
    IExcerciseRepository ExcerciseRepository { get; }
    ILocationRepository LocationRepository { get; }
    IMessageRepository MessageRepository { get; }
    IMonthlySubscriptionRepository MonthlySubscriptionRepository { get; }
    ISportSchoolRepository SportSchoolRepository { get; }
    ITrainingRepository TrainingRepository { get; }
    IUserAtTrainingRepository UserAtTrainingRepository { get; }
    IUserInGroupRepository UserInGroupRepository { get; }
    IUserGroupRepository UserGroupRepository { get; }
    IUserAtCompetitionRepository UserAtCompetitionRepository { get; }
    
}