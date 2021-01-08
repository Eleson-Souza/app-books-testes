import React from 'react';
import { Link } from 'react-router-dom';
import { HeaderArea } from './styled';

function Header() {
    return (
        <HeaderArea>
            <header className="navbar">
                    <ul>
                        <Link to="/book/register">
                            <li>Cadastro</li>
                        </Link>
                        <Link to="/book/update">
                            <li>Atualização</li>
                        </Link>
                        <Link to="/book/delete">
                            <li>Exclusão</li>
                        </Link>
                        <Link to="/book/list">
                            <li>Listagem</li>
                        </Link>
                    </ul>
                </header>
        </HeaderArea>
    );
}

export default Header;