import React, { useState } from 'react';

import api from '../../services/api';
import { PageContainerCenter } from '../../components/MainComponents';
import HeaderArea from '../../components/Header/index';
import './styled.css';

function RegisterBook() {

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [purchaseDate, setPurchaseDate] = useState("");
    const [numberOfPages, setNumberOfPages] = useState(0);
    const [numberChapter, setNumberChapter] = useState(0);
    const [pageCurrent, setPageCurrent] = useState(0);

    async function handleRegister(e) {
        e.preventDefault();

        try {
            let response = await api.post('book', {
                Title: title,
                Description: description,
                PurchaseDate: purchaseDate,
                NumberOfPages: numberOfPages,
                LastChapter: numberChapter,
                LastPage: pageCurrent
            });

            alert(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    return (
            <div className="content-page">                
                <HeaderArea />
                <PageContainerCenter>
                    <div className="container">
                        <h3>Cadastre um Livro</h3>

                        <form method="POST" onSubmit={handleRegister}>
                            <p>
                                <label htmlFor="title" className="label">
                                    Título: 
                                </label>
                                <input 
                                    type="text" 
                                    name="title" 
                                    id="title" 
                                    placeholder="Nome do Livro"
                                    onChange={(e) => setTitle(e.target.value)}
                                    value={title}
                                />
                            </p>
                            <p>
                                <label htmlFor="description" className="label">
                                    Descrição: <br />
                                </label>
                                <textarea  
                                    name="description" 
                                    id="description" 
                                    placeholder="Informe um resumo do livro"
                                    onChange={(e) => setDescription(e.target.value)}
                                    value={description}
                                ></textarea>
                            </p>
                            <p>
                                <label htmlFor="purchase_date" className="label">
                                    Data da compra: 
                                </label>
                                <input 
                                    type="date"
                                    name="purchase_date" 
                                    id="purchase_date"
                                    onChange={(e) => setPurchaseDate(e.target.value)}
                                    value={purchaseDate}
                                />
                            </p>
                            <p>
                                <label htmlFor="num_of_pages" className="label">
                                    Núm. Páginas: 
                                </label>
                                <input 
                                    type="number" 
                                    name="num_of_pages" 
                                    id="num_of_pages" 
                                    placeholder="Quantidade páginas"
                                    onChange={(e) => setNumberOfPages(Number(e.target.value))}
                                />
                            </p>
                            <p>
                                <label htmlFor="number_chapter" className="label">
                                    Número capítulos: 
                                </label>
                                <input 
                                    type="number" 
                                    name="number_chapter" 
                                    id="number_chapter" 
                                    placeholder="Quantidade de capítulos do livro"
                                    onChange={(e) => setNumberChapter(Number(e.target.value))}
                                />
                            </p>
                            <p>
                                <label htmlFor="page_current" className="label">
                                    Página atual: 
                                </label>
                                <input 
                                    type="number" 
                                    name="page_current" 
                                    id="page_current" 
                                    placeholder="Página atual que está lendo"
                                    onChange={(e) => setPageCurrent(Number(e.target.value))}
                                />
                            </p>
                            
                            <div className="buttons">
                                <button type="submit" className="btn-register">Cadastrar</button>
                                <button type="reset" className="btn-clear">Limpar</button>
                            </div>
                        </form>
                    </div>
                </PageContainerCenter>
            </div>
    );
}

export default RegisterBook;