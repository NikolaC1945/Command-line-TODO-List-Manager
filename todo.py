import json
import sys

file_path = './tasks.json'

# Helper to load tasks from JSON file
def load_tasks():
    try:
        with open(file_path, 'r') as file:
            return json.load(file)
    except (FileNotFoundError, json.JSONDecodeError):
        print("Could not load tasks. Returning an empty list.")
        return []

# Helper to save tasks to JSON file
def save_tasks(tasks):
    with open(file_path, 'w') as file:
        json.dump(tasks, file, indent=2)

# Add task function
def add_task(description):
    tasks = load_tasks()
    new_task = {
        'id': len(tasks) + 1,
        'description': description,
        'completed': False
    }
    tasks.append(new_task)
    save_tasks(tasks)
    print("Task added:", description)

# Edit task function
def edit_task(task_id, new_description):
    tasks = load_tasks()
    task = next((task for task in tasks if task['id'] == task_id), None)
    if task:
        task['description'] = new_description
        save_tasks(tasks)
        print(f"Task {task_id} updated.")
    else:
        print(f"Task with id {task_id} not found.")

# Delete task function
def delete_task(task_id):
    tasks = load_tasks()
    initial_length = len(tasks)
    tasks = [task for task in tasks if task['id'] != task_id]
    if len(tasks) < initial_length:
        save_tasks(tasks)
        print(f"Task {task_id} deleted.")
    else:
        print(f"Task with id {task_id} not found.")

# Mark task as completed
def complete_task(task_id):
    tasks = load_tasks()
    task = next((task for task in tasks if task['id'] == task_id), None)
    if task:
        task['completed'] = True
        save_tasks(tasks)
        print(f"Task {task_id} marked as completed.")
    else:
        print(f"Task with id {task_id} not found.")

# List all tasks
def list_tasks():
    tasks = load_tasks()
    for task in tasks:
        status = '✓' if task['completed'] else ' '
        print(f"{task['id']}. [{status}] {task['description']}")

# CLI commands handling
def main():
    if len(sys.argv) < 2:
        print("Unknown command. Available commands: add, edit, delete, complete, list.")
        return

    command = sys.argv[1]
    args = sys.argv[2:]

    if command == 'add':
        add_task(' '.join(args))
    elif command == 'edit':
        if len(args) >= 2:
            edit_task(int(args[0]), ' '.join(args[1:]))
        else:
            print("Usage: edit <id> <new_description>")
    elif command == 'delete':
        if args:
            delete_task(int(args[0]))
        else:
            print("Usage: delete <id>")
    elif command == 'complete':
        if args:
            complete_task(int(args[0]))
        else:
            print("Usage: complete <id>")
    elif command == 'list':
        list_tasks()
    else:
        print("Unknown command. Available commands: add, edit, delete, complete, list.")

if __name__ == '__main__':
    main()
