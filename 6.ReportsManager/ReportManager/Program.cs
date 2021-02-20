using System;
using ReportManager.BLL.Services;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Repositories;
using ReportManager.DAL.Repositories.ReportRepository;
using ReportManager.UL.Controllers;

namespace ReportManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new FutureTimer();
            var commitRepo = new CommitsRepository();
            var employeeRepo = new EmployeeRepository();
            var tasksRepo = new TasksRepository();
            var dailyReportRepo = new DailyReportRepo();
            var sprintRepo = new SprintReportRepo();
            var teamLeaderRepo = new TeamLeaderReportRepo();
            
            var database = new UnitOfWork(timer, commitRepo, employeeRepo, 
                tasksRepo, dailyReportRepo, sprintRepo, teamLeaderRepo);
            
            var commitServ = new CommitService(database);
            var employeeServ = new EmployeeService(database);
            var reportServ = new ReportService(database);
            var tasksServ = new TasksService(database);
            var timerServ = new TimerService(database);
            
            var commitContr = new CommitController(commitServ);
            var employeeContr = new EmployeeController(employeeServ);
            var reportContr = new ReportController(reportServ);
            var tasksContr = new TasksController(tasksServ);
            var timerContr = new TimerController(timerServ);
            
            employeeContr.SetTeamLeader("Max");
            employeeContr.AddEmployee("Cyrill");
            employeeContr.AddEmployee("Egor");
            
            employeeContr.UpdateSuperior("Cyrill", "Max");
            employeeContr.UpdateSuperior("Egor", "Max");
            employeeContr.ShowHierarchy();
            
            reportContr.CreateDailyReport(employeeContr.GetId("Egor"));
            reportContr.CreateDailyReport(employeeContr.GetId("Cyrill"));

            
            tasksContr.Create("Task1", employeeContr.GetId("Cyrill"));
            tasksContr.Create("Task2", employeeContr.GetId("Cyrill"));
            tasksContr.Create("Task3", employeeContr.GetId("Egor"));
            tasksContr.Create("Task4", employeeContr.GetId("Egor"));
            
            tasksContr.UpdateComment("Task1", "MUST-DO");
            tasksContr.UpdateEmployee("Task2", employeeContr.GetId("Egor"));

            var task = tasksContr.GetTaskById(tasksContr.GetIdByName("Task4"));
            Console.WriteLine(task.Name == "Task4");
            task = tasksContr.GetTaskByLastCommit();
            Console.WriteLine(task.Name == "Task2");
            task = tasksContr.GetLastCreatedTask();
            Console.WriteLine(task.Name == "Task4");
            var tasks = tasksContr.GetTasksOfEmployee(employeeContr.GetId("Cyrill"));
            Console.WriteLine(tasks[0].EmployeeInChargeId == employeeContr.GetId("Cyrill"));
            tasks = tasksContr.GetEditedTasks();
            Console.WriteLine(tasks[0].Edited());
            tasks = tasksContr.GetTasksOfSubordinates(employeeContr.GetId("Max"));
            Console.WriteLine(tasks.Count == 4);
            
            reportContr.AddDailyTasks(employeeContr.GetId("Egor"), 
                tasksContr.GetDailyTaskOfEmployee(employeeContr.GetId("Egor")));
            reportContr.AddDailyChanges(employeeContr.GetId("Egor"), 
                commitContr.GetDailyCommitsOfEmployee(employeeContr.GetId("Egor")));
            reportContr.CompleteReport(reportServ.GetLastDailyReportIdOfEmployee(employeeContr.GetId("Egor")));
            
            
            reportContr.AddDailyTasks(employeeContr.GetId("Cyrill"), 
                tasksContr.GetDailyTaskOfEmployee(employeeContr.GetId("Cyrill")));
            reportContr.AddDailyChanges(employeeContr.GetId("Cyrill"), 
                commitContr.GetDailyCommitsOfEmployee(employeeContr.GetId("Cyrill")));
            reportContr.CompleteReport(reportServ.GetLastDailyReportIdOfEmployee(employeeContr.GetId("Cyrill")));
            
            timerContr.NextDay();
            
            tasksContr.Create("Task5", employeeContr.GetId("Max"));
            tasksContr.Create("Task6", employeeContr.GetId("Cyrill"));
            tasksContr.UpdateComment("Task5", "New Task");
            tasksContr.UpdateComment("Task6", "Important");
            
            reportContr.AddDailyTasks(employeeContr.GetId("Egor"), 
                tasksContr.GetDailyTaskOfEmployee(employeeContr.GetId("Egor")));
            reportContr.AddDailyChanges(employeeContr.GetId("Egor"), 
                commitContr.GetDailyCommitsOfEmployee(employeeContr.GetId("Egor")));
            reportContr.CompleteReport(reportServ.GetLastDailyReportIdOfEmployee(employeeContr.GetId("Egor")));
            
            
            reportContr.AddDailyTasks(employeeContr.GetId("Cyrill"), 
                tasksContr.GetDailyTaskOfEmployee(employeeContr.GetId("Cyrill")));
            reportContr.AddDailyChanges(employeeContr.GetId("Cyrill"), 
                commitContr.GetDailyCommitsOfEmployee(employeeContr.GetId("Cyrill")));
            reportContr.CompleteReport(reportServ.GetLastDailyReportIdOfEmployee(employeeContr.GetId("Cyrill")));
            
            reportContr.CreateSprintReport(2);
            reportContr.AddReportsToSprint(reportContr.GetLastSprint(),
                reportContr.GetReportsOfPeriod(2));
            
        }
    }
}