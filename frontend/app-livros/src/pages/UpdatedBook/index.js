import React, { useState } from 'react';
import { BiSearchAlt2 } from 'react-icons/bi';

import api from '../../services/api';
import { PageContainerCenter } from '../../components/MainComponents';
import HeaderArea from '../../components/Header/index';
import './styled.css';

function UpdatedBook() {

    const [id, setId] = useState(null);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [purchaseDate, setPurchaseDate] = useState("");
    const [numberOfPages, setNumberOfPages] = useState(null);
    const [numberChapter, setNumberChapter] = useState(null);
    const [pageCurrent, setPageCurrent] = useState(null);

    function clearFields() {
        setId("");
        setTitle("");
        setDescription("");
        setPurchaseDate("");
        setNumberOfPages("");
        setNumberChapter("");
        setPageCurrent("");
    }

    async function handleSearchBook(event) {
        try {
            let response = await api.get(`/book/${id}`);

            const { 
                    title, 
                    description, 
                    numberOfPages, 
                    purchaseDate, 
                    lastPage, 
                    lastChapter 
                } = response.data;

            setTitle(title);
            setDescription(description);
            setNumberOfPages(numberOfPages);
            setPageCurrent(lastPage);
            setNumberChapter(lastChapter);
            
            let date = new Date(purchaseDate);
            let day = date.getDate();
            let month = date.getMonth() + 1;
            let year = date.getFullYear();
            setPurchaseDate(`${year}-${month < 10 ? `0${month}` : month}-${(day < 10) ? `0${day}` : day}`);
            
        } catch(error) {
            alert(error.response.data);
        }
    }

    async function handleUpdate(event) {
        event.preventDefault();

        try {
            let response = await api.put('/book', {
                Id: id,
                Title: title,
                Description: description,
                NumberOfPages: numberOfPages,
                PurchaseDate: purchaseDate,
                LastChapter: numberChapter,
                LastPage: pageCurrent,                    
            });

            alert(response.data);
            clearFields();

        } catch(error) {
            console.log(error);
        }
    }

    return (
            <div className="content-page">      
                <HeaderArea />
                <PageContainerCenter>
                    <div className="container">
                        <h3>Atualize um Livro</h3>

                        <form method="POST" onSubmit={handleUpdate}>
                            <p>
                                <label htmlFor="id-book">
                                    ID do livro:
                                </label>
                                <input 
                                    type="number" 
                                    name="id-book" 
                                    id="id-book"
                                    onChange={(e) => setId(Number(e.target.value))}
                                    value={id}
                                />
                                <button 
                                    className="btn-search" 
                                    type="button"
                                    onClick={handleSearchBook}
                                >
                                    <BiSearchAlt2 color="#FFF" size={20} />
                                    <label>Buscar</label>
                                </button>
                            </p>
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
                                    value={numberOfPages}
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
                                    value={numberChapter}
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
                                    value={pageCurrent}
                                />
                            </p>
                            
                            <div className="buttons">
                                <button type="submit" className="btn-register">Atualizar</button>
                                <button className="btn-clear" onClick={clearFields}>Limpar</button>
                            </div>
                        </form>
                    </div>
                </PageContainerCenter>
            </div>
    );
}

export default UpdatedBook;