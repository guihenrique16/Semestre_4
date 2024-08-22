import './Modal.css'
import { useState } from "react";

export default function Modal({
    modalIsOpen,
    setIsOpen,
    items,

}) {
    const [novaTarefa, setNovaTarefa] = useState("");

    return (
        <div className="modal-content">
            <div className="modal-box">
                <h1 className='title-modal'>Descreva sua tarefa</h1>
                <input
                    value={novaTarefa}
                    setValue={setNovaTarefa}
                    placeholder="Título da tarefa"
                    className="input-modal"
                />
                <button
                    className='button-modal'
                    onClick={() => {
                        if (novaTarefa == "") return ("Preencha o campo de tarefa!");
                        setIsOpen(false);
                        // items.push({ title: novaTarefa, id: items.length + 1 });
                        setNovaTarefa("");
                    }}
                >
                    adicionar
                </button>
                {/* <button text="Cancelar" onClick={() => setIsOpen(false)} /> */}
                <button className='fechar' onClick={() => setIsOpen(false)} >Cancelar</button>
            </div>
        </div>
    );
}