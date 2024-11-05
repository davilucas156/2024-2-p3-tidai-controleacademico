import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';


const UserTable = ({ atividades, handleShow, handleShow2 }) => {
  return (
    <table className="table table-striped table-responsive">
      <thead>
        <tr>
          <th scope="col">Matrícula</th>
          <th scope="col">Nome</th>
          <th scope="col">Cpf</th>
          <th scope="col">Email</th>
          <th scope="col">Endereço</th>
          <th scope="col">Tipo</th>
          <th scope="col">Curso</th>
          <th></th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {atividades.map((ativ) => (
          <tr key={ativ.Matrícula}>
            <td>{ativ.Matrícula}</td>
            <td>{ativ.Nome}</td>
            <td>{ativ.Cpf}</td>
            <td>{ativ.Email}</td>
            <td>{ativ.Endereço}</td>
            <td>{ativ.Tipo}</td>
            <td>{ativ.Curso}</td>
            <td>
              <button type="button" className="btn btn-outline-primary" onClick={handleShow}>
                <i className="fa-regular fa-pen-to-square"></i>
              </button>
            </td>
            <td>
              <button type="button" className="btn btn-outline-danger" onClick={handleShow2}>
                <i className="fa-regular fa-trash-can"></i>
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default UserTable;
