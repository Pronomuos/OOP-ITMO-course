using ReportManager.DAL.Entities;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories.ReportRepository;

namespace ReportManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITimer Timer { get; set; }
        public ICommitsRepository CommitsRepo { get; set; }
        public IEmployeeRepository EmployeeRepo { get; set; }
        public ITasksRepository TasksRepo { get; set; }
        public IDailyRepo DailyReportRepo { get; set; }
        public ISprintRepo SprintReportRepo { get; set; }
        public ITeamLeaderRepo TeamLeaderReportRepo { get; set; }

        public UnitOfWork (ITimer timer,
         ICommitsRepository commitsRepo,
         IEmployeeRepository employeeRepo,
         ITasksRepository tasksRepo,
         IDailyRepo dailyReportRepo,
         ISprintRepo sprintReportRepo,
         ITeamLeaderRepo teamLeaderReportRepo)
        {
            Timer = timer;
            CommitsRepo = commitsRepo;
            EmployeeRepo = employeeRepo;
            TasksRepo = tasksRepo;
            DailyReportRepo = dailyReportRepo;
            SprintReportRepo = sprintReportRepo;
            TeamLeaderReportRepo = teamLeaderReportRepo;
        }
    }
}