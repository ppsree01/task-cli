# task-cli

Task-CLI is just another command line based track-tracker / todo list. Use the commands below to view, add, edit or delete your tasks, or update their status. Data is stored in a file `data.json` which is created if it does not already exist.

See the Project URL [here](https://roadmap.sh/projects/task-tracker)

## How to run the project:
- Download and install .NET 8.0 if not installed
- Navigate to folder task-cli
- Run `dotnet run -- list` to view all 


## Commands:
```
# Adding a new task
dotnet run -- add "Buy groceries"
# Output: Task added successfully (ID: 1)

# Updating and deleting tasks
dotnet run -- update 1 "Buy groceries and cook dinner"
dotnet run -- delete 1

# Marking a task as in progress or done
dotnet run -- mark-in-progress 1
dotnet run -- mark-done 1

# Listing all tasks
dotnet run -- list

# Listing tasks by status
dotnet run -- list done
dotnet run -- list todo
dotnet run -- list in-progress
```