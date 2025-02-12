internal static class TaskManager
{
    public static List<Task> tasks = new List<Task>();
    public static void LoadTasks()
    {
        FileManager.CreateFileIfNotExist();
        tasks = FileManager.ReadData();
    }

    // Add a new item to list
    public static void AddTask(string item)
    {
        int id = 0;
        try
        {
            if (item.Trim() == "") throw new Exception("New item cannot be empty"); 
            if (tasks.Count > 0)
            {
                id = tasks.OrderByDescending(x => x.id).ToList().First().id;
            }
            id += 1;

            tasks.Add(new Task
            {
                id = id,
                item = item,
                status = Status.TODO
            });

            FileManager.WriteData(tasks);

            Message.Format($"Task added successfully (ID: {id})", MessageType.Info);
        }
        catch (Exception ex)
        {
            Message.Format(ex.Message, MessageType.Error);
        }
    }

    public static void UpdateStatus(int id, Status status) {
        try {
            bool exists = tasks.FindAll(x => x.id == id).Count > 0;

            if (!exists) throw new Exception($"ID: {id} does not exist");
            else {
                foreach(var task in tasks) {
                    if (task.id == id) {
                        task.status = status;
                    }
                }
            }
            FileManager.WriteData(tasks);
        }
        catch(Exception ex) {
            Message.Format(ex.Message, MessageType.Error);
        }
    }

    // Update a task if it exists
    public static void UpdateTask(int id, string item)
    {
        try {
            bool exists = tasks.FindAll(x => x.id == id).Count > 0;

            if (!exists) throw new Exception($"ID: {id} does not exist");
            else {
                foreach(var task in tasks) {
                    if (task.id == id) {
                        task.item = item;
                    }
                }
            }
            FileManager.WriteData(tasks);
        }
        catch(Exception ex) {
            Message.Format(ex.Message, MessageType.Error);
        }
    }

    // Delete a task if it exists
    public static void DeleteTask(int id)
    {
        try {
            bool exists = tasks.FindAll(x => x.id == id).Count > 0;
            if (!exists) throw new Exception($"ID: {id} does not exist");
            else {
                int index = tasks.FindIndex(x => x.id == id);
                tasks.RemoveAt(index);
            }
            FileManager.WriteData(tasks);
        }
        catch(Exception ex) {
            Message.Format(ex.Message, MessageType.Error);
        }
    }

    // List all tasks or by status
    public static void ListTasks(Status? status)
    {
        var subTasks = new List<Task>();
        if (status == null)
        {
            subTasks = tasks;
        }
        else
        {
            subTasks = tasks.Where(x => x.status == status).ToList();
        }

        if (tasks.Count == 0) {
            Message.Format("No tasks stored in file");
            return;
        }

        Message.Format("Please see below tasks stored:");
        foreach(var item in subTasks) {
            Console.WriteLine($"{item.id}\t{item.item}\t{item.status}");
        }
    }
}