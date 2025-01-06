using Newtonsoft.Json;

namespace ConsoleApp1;

class Program
{
    static string filePath = "tasks.json";

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: todo <command> [options]");
            return;
        }

        string command = args[0].ToLower();
        switch (command)
        {
            case "add":
                AddTask(string.Join(" ", args[1..]));
                break;
            case "edit":
                if (args.Length >= 3)
                {
                    EditTask(int.Parse(args[1]), string.Join(" ", args[2..]));
                }
                else
                {
                    Console.WriteLine("Usage: todo edit <task-id> \"Updated description\"");
                }
                break;
            case "delete":
                if (args.Length >= 2)
                {
                    DeleteTask(int.Parse(args[1]));
                }
                else
                {
                    Console.WriteLine("Usage: todo delete <task-id>");
                }
                break;
            case "complete":
                if (args.Length >= 2)
                {
                    CompleteTask(int.Parse(args[1]));
                }
                else
                {
                    Console.WriteLine("Usage: todo complete <task-id>");
                }
                break;
            case "list":
                ListTasks();
                break;
            default:
                Console.WriteLine("Unknown command. Available commands: add, edit, delete, complete, list.");
                break;
        }
    }

    static List<Task> LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
        }
        return new List<Task>();
    }

    static void SaveTasks(List<Task> tasks)
    {
        string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    static void AddTask(string description)
    {
        var tasks = LoadTasks();
        var newTask = new Task
        {
            Id = tasks.Count > 0 ? tasks[^1].Id + 1 : 1,
            Description = description,
            Completed = false
        };
        tasks.Add(newTask);
        SaveTasks(tasks);
        Console.WriteLine("Task added: " + description);
    }

    static void EditTask(int id, string newDescription)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Description = newDescription;
            SaveTasks(tasks);
            Console.WriteLine($"Task {id} updated.");
        }
        else
        {
            Console.WriteLine($"Task with id {id} not found.");
        }
    }

    static void DeleteTask(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks(tasks);
            Console.WriteLine($"Task {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Task with id {id} not found.");
        }
    }

    static void CompleteTask(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Completed = true;
            SaveTasks(tasks);
            Console.WriteLine($"Task {id} marked as completed.");
        }
        else
        {
            Console.WriteLine($"Task with id {id} not found.");
        }
    }

    static void ListTasks()
    {
        var tasks = LoadTasks();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. [{(task.Completed ? "✓" : " ")}] {task.Description}");
        }
    }
}

class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
}