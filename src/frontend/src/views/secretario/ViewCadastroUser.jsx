import { BrowserRouter as Router } from 'react-router-dom';
import'../../styles/index.css';

import React, { useState } from 'react';
import CadastroUsuario from '../../components/secretario/ModalCadastroUsuario';
import CadastroCurso from '../../components/secretario/ModalCadastroCurso';
import UserTable from '../../components/secretario/TabelaUsuarios';
import DeleteModal from '../../components/common/ModalConfirmaExclusão';

const ViewCadastroUser = () => {
  const initialState = [
    {
      id: '1',
      Matrícula: '00001',
      Nome: 'Wagner Cipriano',
      Cpf: '48974587510',
      Email: 'wagner@gmail.com',
      Endereço: 'Rua Santo Antônio 71',
      Tipo: 'Professor',
      Senha: '654321',
      Curso: 'ADS',
      Disciplinas: '13'
    },
    {
      id: '2',
      Matrícula: '00002',
      Nome: 'Pedro Henrique Ferreira Gomes Martins',
      Cpf: '15387954810',
      Email: 'pedro@gmail.com',
      Endereço: 'Rua Del Rey 122',
      Tipo: 'Aluno',
      Senha: '123456',
      Curso: 'ADS',
      Disciplinas: '8'
    },
  ];

  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [show2, setShow2] = useState(false);
  const handleClose2 = () => setShow2(false);
  const handleShow2 = () => setShow2(true);

  const [atividades, setAtividade] = useState(initialState);
  function addAtividade(e) {
    e.preventDefault();
    const atividade = {
      Matrícula: document.getElementById('matricula').value,
      Nome: document.getElementById('nome').value,
      Cpf: document.getElementById('cpf').value,
      Email: document.getElementById('email').value,
      Endereço: document.getElementById('endereço').value,
      Tipo: document.getElementById('tipo').value,
      Senha: document.getElementById('senha').value,
      Curso: document.getElementById('curso').value,
    };
    setAtividade([...atividades, { ...atividade }]);
  }

  return (
    <div className="height-100">
      <h4 className='p-5'>Gestão de Usuários</h4>
      <div className="container">
        {/* Botões de controle */}
        <div className="container">
          <div className="row mb-3">
            <div className="col-2">
              <input type="text" className="form-control" id="" placeholder="Matrícula"></input>
            </div>
            <div className="col-2">
              <input type="text" className="form-control" id="" placeholder="Nome"></input>
            </div>
            <div className="col-2">
              <input type="text" className="form-control" id="" placeholder="Cpf"></input>
            </div>
            <div className="col-2">
              <select className="form-select" id="" aria-label="">
                <option value="" selected>Todos</option>
                <option value="2">Alunos</option>
                <option value="1">Professores</option>
                <option value="0">Secretário</option>
              </select>
            </div>
            <div className="col-4">
              <button id="btn_add" type="button" className="btn btn-primary me-1">
                Pesquisar
              </button>
              <button id="btn_unfilter" type="button" className="btn btn-secondary me-4">Limpar busca</button>
              <button type="button" className="btn btn-success" onClick={handleShow}>
                Novo Registro
              </button>
            </div>
          </div>
        </div>

        {/* Tabela de Usuários */}
        <UserTable atividades={atividades} handleShow={handleShow} handleShow2={handleShow2} />

        {/* Modal de Formulário */}
        <CadastroUsuario show={show} handleClose={handleClose} addAtividade={addAtividade} />

        {/* Modal de Exclusão */}
        <DeleteModal show2={show2} handleClose2={handleClose2} />
      </div>
    </div>
  );
}

export default ViewCadastroUser;
