import styled from 'styled-components';

export const HeaderArea = styled.div`
background-color: #CC9D57;
height: 80px;
display: flex;
justify-content: center;
align-items: center;

header ul {
    list-style: none;
}

header ul li {
    display: inline-block;
    margin-right: 50px;
    color: #FFF;
    font-weight: bold;
    font-size: 22px;
}

header ul li:hover {
    color: #dddddd;
}
`;