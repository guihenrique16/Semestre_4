import React, { useState } from "react";
import Modal from "./Components/Modal";
import "./App.css";

function App() {
  const [tasks, setTasks] = useState([
    // { id: 1, text: "Começar a execução do projeto", completed: false },
  ]);

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isEditing, setIsEditing] = useState(false);
  const [currentTask, setCurrentTask] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");

  const toggleTaskCompletion = (id) => {
    setTasks(
      tasks.map((task) =>
        task.id === id ? { ...task, completed: !task.completed } : task
      )
    );
  };

  const deleteTask = (id) => {
    setTasks(tasks.filter((task) => task.id !== id));
  };

  const addTask = (taskDescription) => {
    setTasks([
      ...tasks,
      { id: tasks.length + 1, text: taskDescription, completed: false },
    ]);
  };

  const editTask = (taskDescription) => {
    setTasks(
      tasks.map((task) =>
        task.id === currentTask.id ? { ...task, text: taskDescription } : task
      )
    );
    setCurrentTask(null);
    setIsEditing(false);
  };

  const handleEditClick = (task) => {
    setCurrentTask(task);
    setIsEditing(true);
    setIsModalOpen(true);
  };

  const filteredTasks = tasks.filter((task) =>
    task.text.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="container">
      <div className="task-container">
        <h2 className="date-text">
          Terça-Feira, <span>24</span> de Julho
        </h2>
        <div className="search-box">
          <input
            type="text"
            placeholder="Procurar tarefa"
            className="search-input"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
        <div className="task-list">
          {filteredTasks.map((task) => (
            <div
              key={task.id}
              className={`task-item ${task.completed ? "completed" : ""}`}
            >
              <button
                className="check-button"
                onClick={() => toggleTaskCompletion(task.id)}
              >
                {task.completed ? <img src="../src/Assets/check-icon.png"/> : ""}
              </button>
              <span>{task.text}</span>
              <div className="button-group">
                <button
                  className="task-button"
                  onClick={() => deleteTask(task.id)}
                >
                  <img className="icon-button" src="../src/Assets/delete-icon.png" alt="" />
                </button>
                <button
                  className="task-button"
                  onClick={() => handleEditClick(task)}
                >
                  <img className="icon-button" src="../src/Assets/edit-icon.png" alt="" />
                </button>
              </div>
            </div>
          ))}
        </div>
        <button
          className="new-task-button"
          onClick={() => setIsModalOpen(true)}
        >
          Nova tarefa
        </button>
      </div>
      <Modal
        isOpen={isModalOpen}
        onClose={() => {
          setIsModalOpen(false);
          setIsEditing(false);
        }}
        onSave={isEditing ? editTask : addTask}
        initialDescription={isEditing ? currentTask.text : ""}
      />
    </div>
  );
}

export default App;
