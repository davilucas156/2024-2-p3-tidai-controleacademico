import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';


const UserTable = ({ atividades, handleShow, handleShow2 }) => {
    return (
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Nível</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Disciplinas</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody class="table-group-divider">
                {atividades.map(ativ => (
                    <tr key={ativ.id}>
                        <td>{ativ.id}</td>
                        <td>{ativ.nome}</td>
                        <td>{ativ.nivel}</td>
                        <td>{ativ.tipo}</td>
                        <td>{ativ.disciplinas}</td>
                        <td>
                            <button type="button" className="btn btn-outline-primary" variant="primary" onClick={handleShow}>
                                <i i class="fa-regular fa-pen-to-square"></i>
                            </button>
                        </td>
                        <td>
                            <button id="btn_unfilter" type="button" className="btn btn-outline-danger" variant="primary" onClick={handleShow2}>
                                <i class="fa-regular fa-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default UserTable;