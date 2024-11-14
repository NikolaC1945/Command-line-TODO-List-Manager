# Command-Line To-Do List Manager

## Project Overview

-The Command-Line To-Do List Manager is a simple, yet effective tool to manage tasks directly from the command line. This project allows users to add, edit, delete, and mark tasks as completed, with tasks stored in a local file for persistence. It’s designed to help users stay organized and keep track of their to-do items without needing a complex graphical interface.

## Goals

- Efficient Task Management: Provide a quick and easy way for users to manage tasks through the command line.
- Persistence: Store tasks in a local file so they’re saved between sessions.
- User-Friendly CLI: Build an intuitive command-line interface with straightforward commands for managing tasks.

## Features

- Add Tasks: Easily add new tasks with a description.
- Edit Tasks: Update task descriptions.
- Delete Tasks: Remove tasks that are no longer needed.
- Mark as Completed: Mark tasks as done to track progress.
- View Tasks: Display a list of pending and completed tasks.

## Technologies Used

- JavaScript (Node.js): Primary language and runtime for building the CLI tool.
- File System (fs): Node.js library for file storage, ensuring tasks are saved locally.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/NikolaC1945/Command-line-TODO-List-Manager.git
   cd cli-todo-list
   ```
2. Install dependencies (if any):
   ```bash
   npm install
   ```

## Usage

### Running the Application
```bash
node todo.js
```

### Commands:

- **Add a Task**
  ```bash
  node todo.js add "Your task description"
  ```

- **Edit a Task**
  ```bash
  node todo.js edit <task-id> "Updated task description"
  ```

- **Delete a Task**
  ```bash
  node todo.js delete <task-id>
  ```

- **Mark Task as Completed**
  ```bash
  node todo.js complete <task-id>
  ```

- **View Tasks**
  ```bash
  node todo.js list
  ```

## File Structure

- `todo.js`: Main file containing the CLI logic.
- `tasks.json`: Local file storing tasks.

## Contributors:

- Nikola Cvjetinovic
- Mihailo Kuljanin
- Saruhan Celik

## Contributing

Contributions are welcome! Please feel free to submit a pull request.
