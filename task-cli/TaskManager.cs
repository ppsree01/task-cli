internal static class TaskManager
{
    public static List<Task> tasks = new List<Task>();
    public static void LoadTasks()
    {
        
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
                id = tasks.OrderBy(x => x.id).ToList().First().id;
            }

            tasks.Add(new Task
            {
                id = id,
                item = item,
                status = Status.TODO
            });

            Message.Format($"Task added successfully (ID: {id})", MessageType.Info);
        }
        catch (Exception ex)
        {
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
                    if (task.id == id) task.item = item;
                }
            }
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
        }
        catch(Exception ex) {
            Message.Format(ex.Message, MessageType.Error);
        }
    }

    // List all tasks or by status
    public static List<Task> ListTasks(Status? status)
    {
        if (status == null)
        {
            return tasks;
        }
        else
        {
            return tasks.Where(x => x.status == status).ToList();
        }
    }
}