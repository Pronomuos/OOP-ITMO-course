using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Models;
using BackupsManager.Exceptions;
using BackupsManager.Algorithms;
using BackupsManager.Services;
using BackupsManager.Algorithms.Interfaces;

namespace BackupsManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var directory1 = new Storage("Storage1",
                    "/Users/apple/RiderProjects/BackupsManager/BackupsManager");
                var copyAlgo1 = new ManyFilesCopyAlgorithm();
                var createAlgo1 = new FullPointCreateAlgorithm();
                var deleteAlgo1 = new DeletePointsByCount(1);
                var filesList1 = new List<File>()
                {
                    new File("File#1", 100),
                    new File("File#2", 100)
                };
                var backup1 = new Backup(filesList1);
                var backupService1 = new BackupService(backup1, directory1, copyAlgo1, createAlgo1, deleteAlgo1);

                backupService1.CreateRestorePoint(DateTime.Now);
                Console.WriteLine(backupService1.GetRestorePoints().Last().Files.Count() == 2);
                backupService1.CreateRestorePoint(DateTime.Now);
                backupService1.CleanRestorePoints();
                Console.WriteLine(backupService1.GetRestorePoints().ToList().Count == 1);
                

                var directory2 = new Storage("Storage2",
                    "/Users/apple/RiderProjects/BackupsManager/BackupsManager");
                var copyAlgo2 = new ManyFilesCopyAlgorithm();
                var createAlgo2 = new FullPointCreateAlgorithm();
                var deleteAlgo2 = new DeletePointsByMemory(200);
                var filesList2 = new List<File>()
                {
                    new File("File#1", 100),
                    new File("File#2", 100)
                };
                var backup2 = new Backup(filesList2);
                var backupService2 = new BackupService(backup2, directory2, copyAlgo2, createAlgo2, deleteAlgo2);

                backupService2.CreateRestorePoint(DateTime.Now);
                Console.WriteLine(backupService2.GetRestorePoints().Last().Files.Count() == 2 &&
                                  backupService2.GetRestorePoints().Last().Files.Sum(file => file.Length) == 200);
                backupService2.CreateRestorePoint(DateTime.Now);
                backupService2.CleanRestorePoints();
                Console.WriteLine(backupService2.GetRestorePoints().ToList().Count == 1);


                var directory3 = new Storage("Storage3",
                    "/Users/apple/RiderProjects/BackupsManager/BackupsManager");
                var copyAlgo3 = new ManyFilesCopyAlgorithm();
                var createAlgo3 = new FullPointCreateAlgorithm();
                var deleteAlgo3 = new DeletePointsByCount(2);
                var filesList3 = new List<File>()
                {
                    new File("File#1", 100),
                    new File("File#2", 100)
                };
                var backup3 = new Backup(filesList3);
                var backupService3 = new BackupService(backup3, directory3, copyAlgo3, createAlgo3, deleteAlgo3);

                backupService3.CreateRestorePoint(DateTime.Now);
                backupService3.CreateRestorePoint(DateTime.Now);
                backupService3.PointCreateAlgo = new IncrementPointCreateAlgorithm();
                backupService3.CreateRestorePoint(DateTime.Now);
                backupService3.CreateRestorePoint(DateTime.Now);
                backupService3.CleanRestorePoints();
                Console.WriteLine(backupService3.GetRestorePoints().ToList().Count == 3);
            

                var directory4 = new Storage("Storage4",
                    "/Users/apple/RiderProjects/BackupsManager/BackupsManager");
                var copyAlgo4 = new ManyFilesCopyAlgorithm();
                var createAlgo4 = new FullPointCreateAlgorithm();
                var algoList = new List<IPointsDeleteAlgorithm>()
                {
                    new DeletePointsByCount(3),
                    new DeletePointsByDate(DateTime.Today.AddDays(2))
                };
                var deleteAlgo4 = new MixedPointsDeleteAlgorithm(algoList, Limits.OneLimitPass);
                var filesList4 = new List<File>()
                {
                    new File("File#1", 100),
                    new File("File#2", 100)
                };
                var backup4 = new Backup(filesList4);
                var backupService4 = new BackupService(backup4, directory4, copyAlgo4, createAlgo4, deleteAlgo4);

                backupService4.CreateRestorePoint(DateTime.Today.AddDays(1));
                backupService4.CreateRestorePoint(DateTime.Today.AddDays(2));
                backupService4.CreateRestorePoint(DateTime.Today.AddDays(3));
                backupService4.CleanRestorePoints();
                Console.WriteLine(backupService4.GetRestorePoints().ToList().Count == 3);
                
            }
            catch (BackupManagerException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}