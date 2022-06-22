using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
var DatabaseSetup = new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig);
var labRepository = new LabRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    
    if (modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if (modelAction == "New")
    {
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            Console.WriteLine("Id de computador ja existe");
        }
        else
        {
            var computer = new Computer(Convert.ToInt32(args[2]), args[3], args[4]);
            computerRepository.Save(computer);
        }
    }
    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if (computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
        else {
            Console.WriteLine("Valor inserido invalido"); 
        }
    }

    if (modelAction == "Update")
    {
        Console.WriteLine("Computer Update");
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            var computer = new Computer(Convert.ToInt32(args[2]), args[3], args[4]);
            computerRepository.Update(computer);
            Console.WriteLine("Computer atualizado");
        }
        else
        {
            Console.WriteLine("Id de computador");
        }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if (computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
            Console.WriteLine("Deletado");
        }
        else { 
            Console.WriteLine("Valor inserido invalido"); 
        }
    }
}

if (modelName == "Lab")
{

    if (modelAction == "List")
    {
        Console.WriteLine("Lab List");
        foreach (var lab in labRepository.GetAll())
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];
        var lab = new Lab(id, number, name, block);

        labRepository.Save(lab);
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
        else {
            Console.WriteLine("Valor inserido invalido"); 
        }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {
            var number = args[3];
            var name = args[4];
            var block = args[5];

            var lab = new Lab(id, number, name, block);

            labRepository.Update(lab);
            Console.WriteLine("Atualizado");
        }
        else {
            Console.WriteLine("Valor inserido invalido"); 
        }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
            Console.WriteLine("Deletado");
        }
        else {
            Console.WriteLine("Valor inserido invalido"); 
        }
    }
}

