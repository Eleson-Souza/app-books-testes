import React, { useEffect, useState } from 'react';

import HeaderArea from '../../components/Header';
import { ContainerArea } from './styled';
import api from '../../services/api';

function ListBook() {

    const [id, setId] = useState(null);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [purchaseDate, setPurchaseDate] = useState("");
    const [numberOfPages, setNumberOfPages] = useState(null);
    const [numberChapter, setNumberChapter] = useState(null);
    const [pageCurrent, setPageCurrent] = useState(null);
    const [bookData, setBookData] = useState([]);

    useEffect(() => {
        const getBooks = async () => {
            try {
                let response = await api.get('/book');
    
                setBookData(response.data);
            } catch(error) {
                alert(error.response.data);
            }
        }
        getBooks();
    }, []);

    return (
        <ContainerArea>
            <HeaderArea />
            <div className="table">
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Título</th>
                            <th>Descrição</th>
                            <th>Data compra</th>
                            <th>Nº Páginas</th>
                            <th>Nº capítulos</th>
                            <th>Página atual</th>
                            <th>Data criação</th>
                            <th>Data alteração</th>
                        </tr>
                    </thead>
                    <tbody>
                        {bookData.map(book => {
                            return (
                                <tr>
                                    <td align="center">{book.id}</td>
                                    <td>{book.title}</td>
                                    <td>{book.description.substr(0,40)}...</td>
                                    <td align="center">{book.purchaseDate}</td>
                                    <td align="center">{book.numberOfPages}</td>
                                    <td align="center">{book.lastChapter}</td>
                                    <td align="center">{book.lastPage}</td>
                                    <td align="center">{book.creationDate}</td>
                                    <td align="center">{book.changeDate}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </ContainerArea>
    );
}

export default ListBook;