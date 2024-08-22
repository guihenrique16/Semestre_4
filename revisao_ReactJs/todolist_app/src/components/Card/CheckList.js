import { useState } from 'react'
import './CheckList.css'
import iconDelete from '../../assets/icon-delete.svg'
import iconCheck from '../../assets/icon-check.png'
import iconEdit from '../../assets/icon-edit.svg'



function CheckList() {
    const [check, setCheck] = useState(false)

    return (
        <>

            {check !== true ?
                (<>
                    <div className='card'>
                        <div className='part-left'>
                            <button className='check' onClick={() => setCheck(true)}>

                            </button>
                            <p className='text-card'>Começar a execução do projeto</p>
                        </div>


                        <div className='part-left'>
                            <button className='buttons'>
                                <img src={iconDelete} alt='' />
                            </button>
                            <button className='buttons'>
                                <img src={iconEdit} alt='' />
                            </button>
                        </div>
                    </div>
                </>)

                :

                (<>
                    <div className='card card-true'>
                        <div className='part-left'>
                            <button className='check check-true' onClick={() => setCheck(false)}>
                                <img src={iconCheck} alt='' />
                            </button>
                            <p className='text-card text-card-true'>Começar a execução do projeto</p>
                        </div>


                        <div className='part-left'>
                            <button className='buttons buttons-true'>
                                <img src={iconDelete} alt='' />
                            </button>
                            <button className='buttons buttons-true'>
                                <img src={iconEdit} alt='' />
                            </button>
                        </div>
                    </div>
                </>)}


        </>
    )
}

export default CheckList