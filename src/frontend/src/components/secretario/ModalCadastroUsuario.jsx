import React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { BrowserRouter as Router } from 'react-router-dom';


const CadastroUsuario = ({ show, handleClose, addAtividade }) => {
  return (
    <Modal show={show} onHide={handleClose} animation={false}>
      <Modal.Header closeButton>
        <Modal.Title>Novo Registro</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <form class="row g-3">
          <div class="col-3">
            <label class="form-label">Matrícula</label>
            <input type="text" class="form-control" id="matricula" placeholder="0001" disabled />
          </div>
          <div class="col-9">
            <label class="form-label">Nome</label>
            <input type="text" class="form-control" id="nome" />
          </div>
          <div class="col-8">
            <label class="form-label">Cpf</label>
            <input type="text" class="form-control" id="cpf" />
          </div>
          <div class="col-md-4">
            <label for="inputState" class="form-label">Tipo</label>
            <select id="tipo" class="form-select">
              <option defaultValue={0}>Tipo</option>
              <option>Professor</option>
              <option>Secretário</option>
              <option>Aluno</option>
            </select>
          </div>
          <div class="col-12">
            <label for="inputEmail4" class="form-label">Email</label>
            <input type="email" class="form-control" id="email" />
          </div>
          <div class="col-8">
            <label class="form-label">Endereço</label>
            <input type="text" class="form-control" id="endereço" />
          </div>
          <div class="col-4">
            <label class="form-label">Senha</label>
            <input type="text" class="form-control" id="senha" />
          </div>
          <div class="col-12 bg-light">
            <label for="inputState" class="form-label">Curso</label>
            <select id="curso" class="form-select">
              <option defaultValue={0}>Selecione</option>
              <option>SI</option>
              <option>Direito</option>
              <option>ADS</option>
            </select>

            <div className='row mt-3'>
              <div className="col-6">
                <h6>1° Semestre</h6>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina A</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina B</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina C</label>
                </div>
              </div>
              <div className="col-6">

                <h6>2° Semestre</h6>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina D</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina E</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina F</label>
                </div>
              </div>
              <div className="col-6">
                <h6>3 ° Semestre</h6>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina A</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina B</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina C</label>
                </div>
              </div>
              <div className="col-6">

                <h6>4° Semestre</h6>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina D</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina E</label>
                </div>
                <div class="form-check form-switch">
                  <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                  <label class="form-check-label" for="flexSwitchCheckDefault">Disciplina F</label>
                </div>
              </div>
            </div>
          </div>
        </form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Fechar
        </Button>
        <Button variant="primary" onClick={addAtividade} >
          Salvar
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default CadastroUsuario;
