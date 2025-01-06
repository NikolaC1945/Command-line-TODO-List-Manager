const fs = require('fs');
const filePath = './tasks.json';

// Helper to load tasks from JSON file
function loadTasks() {
    try {
        const data = fs.readFileSync(filePath, 'utf8');
        return JSON.parse(data);
    } catch (err) {
        console.error("Could not load tasks:", err);
        return [];
    }
}

// Helper to save tasks to JSON file
function saveTasks(tasks) {
    fs.writeFileSync(filePath, JSON.stringify(tasks, null, 2));
}

// Add task function
function addTask(description) {
    const tasks = loadTasks();
    const newTask = {
        id: tasks.length + 1,
        description,
        completed: false
    };
    tasks.push(newTask);
    saveTasks(tasks);
    console.log("Task added:", description);
}

// Edit task function
function editTask(id, newDescription) {
    const tasks = loadTasks();
    const task = tasks.find(task => task.id === id);
    if (task) {
        task.description = newDescription;
        saveTasks(tasks);
        console.log(`Task ${id} updated.`);
    } else {
        console.log(`Task with id ${id} not found.`);
    }
}

// Delete task function
function deleteTask(id) {
    let tasks = loadTasks();
    const initialLength = tasks.length;
    tasks = tasks.filter(task => task.id !== id);
    if (tasks.length < initialLength) {
        saveTasks(tasks);
        console.log(`Task ${id} deleted.`);
    } else {
        console.log(`Task with id ${id} not found.`);
    }
}

// Mark task as completed
function completeTask(id) {
    const tasks = loadTasks();
    const task = tasks.find(task => task.id === id);
    if (task) {
        task.completed = true;
        saveTasks(tasks);
        console.log(`Task ${id} marked as completed.`);
    } else {
        console.log(`Task with id ${id} not found.`);
    }
}

// List all tasks
function listTasks() {
    const tasks = loadTasks();
    tasks.forEach(task => {
        console.log(`${task.id}. [${task.completed ? '✓' : ' '}] ${task.description}`);
    });
}

// CLI commands handling
const [,, command, ...args] = process.argv;

switch (command) {
    case 'add':
        addTask(args.join(' '));
        break;
    case 'edit':
        editTask(parseInt(args[0]), args.slice(1).join(' '));
        break;
    case 'delete':
        deleteTask(parseInt(args[0]));
        break;
    case 'complete':
        completeTask(parseInt(args[0]));
        break;
    case 'list':
        listTasks();
        break;
    default:
        console.log("Unknown command. Available commands: add, edit, delete, complete, list.");
}
