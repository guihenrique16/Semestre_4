import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <body>
      <div className="List-content">
        <div className='search-box'>
          <h1 className='Title'>Terca-Feira, <span style={{color: "#8758FF"}}>24</span> de julho</h1>
          <input className='Input' placeholder='Procurar Tarefas'/>
        </div>
        <div className='cards-box'>

        </div>
      </div>

    	<button className='button'>Nova Tarefa</button>

    </body>
  );
}

export default App;
