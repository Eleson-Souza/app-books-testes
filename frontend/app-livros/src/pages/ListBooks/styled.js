import styled from 'styled-components';

export const ContainerArea = styled.div`

.table {
    display: flex;
    justify-content: center;
    margin-top: 20px;
}

table {
    width: 90%;
    border: 1px solid #000;
    border-collapse: collapse;

    thead, tbody {
        th, td {
            border: 1px solid #000;
            padding: 10px;
        }
    }

    thead {
        background-color: #000;
        color: #FFF;
    }
}

`;