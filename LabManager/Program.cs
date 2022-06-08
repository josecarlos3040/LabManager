using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
var DatabaseSetup = new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig);

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
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }

    if (modelAction == "Show")
    {
  
        var id = Convert.ToInt32(args[2]);
        if(computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe");
        }

    }
    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);

        computerRepository.Update(computer);
        Console.WriteLine("Computador atualizado");
    }
     if(modelAction == "Delete")
    {
        
        Console.WriteLine("Computador deletado");
        try
        {
            computerRepository.Delete(Convert.ToInt32(args[2]));
            Console.WriteLine($"O Computer de id {args[2]} foi removido");
        }
        catch (System.Exception)
        {
            Console.WriteLine("Id Inválida");
        }
    }

}

