import logo from './logo.svg';
import './App.css';
import Card from './components/Card/Card';

import React, { useState } from 'react';
// Importa a modal do react-modal
import Modal from 'react-modal';

function App() {
  const [modalIsOpen, setIsOpen] = React.useState(false);
  const [text, setText] = useState(null)

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
      <div className="List-content">
        <div className='search-box'>
          <h1 className='Title'>Terca-Feira, <span style={{ color: "#8758FF" }}>24</span> de julho</h1>
          <input className='Input' placeholder='Procurar Tarefas' />
        </div>
        <div className='cards-box'>
          {/* <Card /> */}
        </div>
      </div>

      <button
        className='button'
        onClick={abrirModal}
      >Nova Tarefa</button>

      <Modal
        className={'modal'}
        overlayClassName={'modal-overlay'}
        isOpen={modalIsOpen}
        onRequestClose={fecharModal}
        contentLabel="Modal de exemplo"
      >
        
          <h1 className='h1-modal'>Descreva sua tarefa</h1>
          
        


        <input
          className='input-modal'
          placeholder='Descricao'
          onChangeText={(e) => setText(e.Target.value)}
        />

        <button
          onClick={fecharModal && console.log(text)}
          className='button-modal'
        >Adicionar</button>

        <button 
        className='fechar'
        onClick={fecharModal}
        >Fechar</button>

      </Modal>

    </body>



  );
}

export default App;
