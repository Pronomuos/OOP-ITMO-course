namespace ReportManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public ITimer Timer { get; set; }
        public ICommitsRepository CommitsRepo { get; set; }
        public IEmployeeRepository EmployeeRepo { get; set; }
        public ITasksRepository TasksRepo { get; set; }
        public IDailyRepo DailyReportRepo { get; set; }
        public ISprintRepo SprintReportRepo { get; set; }
        public ITeamLeaderRepo TeamLeaderReportRepo { get; set; }
    }
}