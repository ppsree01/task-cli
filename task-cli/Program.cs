// Read arguments from command line:

// args = ["add", "grocery"];

string command = args[0];
string subCommand = "";
string id = "0";
string item = "";
List<Task> tasks = new List<Task>();

TaskManager.LoadTasks();

switch(command) {
    case "add":
        item = args[1];
        TaskManager.AddTask(item);
        TaskManager.LoadTasks();
        break;
    case "update":
        id = args[1];
        item = args[2]; 
        TaskManager.UpdateTask(Convert.ToInt32(id), item);
        TaskManager.LoadTasks();
        break;
    case "mark-in-progress":
        id = args[1];
        TaskManager.UpdateStatus(Convert.ToInt32(id), Status.IN_PROGRESS);
        TaskManager.LoadTasks();
        break;
    case "mark-done":
        id = args[1];
        TaskManager.UpdateStatus(Convert.ToInt32(id), Status.DONE);
        TaskManager.LoadTasks();
        break;
    case "delete":
        id = args[1];
        TaskManager.DeleteTask(Convert.ToInt32(id));
        TaskManager.LoadTasks();
        break;
    case "list":
        if (args.Length == 1) {
            TaskManager.ListTasks(null);
        } else {
            subCommand = args[1];
            if (subCommand == "done") TaskManager.ListTasks(Status.DONE);
            else if (subCommand == "in-progress") TaskManager.ListTasks(Status.IN_PROGRESS);
            else if (subCommand == "todo") TaskManager.ListTasks(Status.TODO);
        }
        break;
}


