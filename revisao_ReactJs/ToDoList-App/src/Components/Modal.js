import React, { useState, useEffect } from "react";
import "./Modal.css";

function Modal(
  { isOpen,
    onClose,
    onSave,
    initialDescription,
    setIsModalOpen
  }) {
  const [newTask, setNewTask] = useState(initialDescription);

  useEffect(() => {
    setNewTask(initialDescription);
  }, [initialDescription]);

  const handleSave = () => {
    onSave(newTask);
    setNewTask("");
    onClose();
  };

  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>{initialDescription ? "Editar tarefa" : "Descreva sua tarefa"}</h2>
        <textarea
          value={newTask}
          onChange={(e) => setNewTask(e.target.value)}
          placeholder="Exemplo de descrição"
        />
        <button
          onClick={() => {
            if (newTask !== "") {
              handleSave()
            } else {
              alert("Preencha este campo")
            }
          }}>
          {initialDescription ? "Salvar edição" : "Confirmar tarefa"}
        </button>
      </div>
    </div>
  );
}

export default Modal;
