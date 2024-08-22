import './App.css';

import React, { useState } from 'react';
import Modal from './components/Modal/Modal';
import CheckList from './components/Card/CheckList';



function App() {
  const [modalIsOpen, setIsOpen] = useState(false);
  const [tarefas, setTarefas] = useState([1,2]);

  const tarefraHandler = (tarefa) => {
    setTarefas([...tarefas, tarefa])
  }

  // Função que abre a modal
  function abrirModal() {
    setIsOpen(true);
  }

  // Função que fecha a modal
  function fecharModal() {
    setIsOpen(false);
  }

  return (
    <body>

      {modalIsOpen ? (
        <Modal open={modalIsOpen} setIsOpen={setIsOpen} />
      ) : (
        <>
          <div className="List-content">
            <div className='search-box'>
              <h1 className='Title'>Terca-Feira, <span style={{ color: "#8758FF" }}>24</span> de julho</h1>
              <input className='Input' placeholder='Procurar Tarefas' />
            </div>

            {tarefas.map((tarefa) => (
              <CheckList />
            ))}

          </div>

          <button
            className='button'
            onClick={abrirModal}
          >Nova Tarefa</button>
        </>
      )}

    </body>
  );
}

export default App;
