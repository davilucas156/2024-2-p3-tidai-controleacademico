import React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { BrowserRouter as Router } from 'react-router-dom';



const CadastroCurso = ({ show, handleClose, addAtividade }) => {
    return (
        <Modal show={show} onHide={handleClose} animation={false}>
            <Modal.Header closeButton>
                <Modal.Title>Novo Registro</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form class="row g-3">
                    <div class="col-3">
                        <label class="form-label">Id</label>
                        <input type="text" class="form-control" id="id" placeholder="001" disabled />
                    </div>
                    <div class="col-9">
                        <label class="form-label">Nome</label>
                        <input type="text" class="form-control" id="nome" placeholder="" />
                    </div>
                    <div class="col-6">
                        <label for="inputState" class="form-label">Nível</label>
                        <select id="nivel" class="form-select">
                            <option selected>Graduação</option>
                            <option>Pós-Graduação</option>
                            <option>Doutorado</option>
                            <option>Mestrado</option>
                        </select>
                    </div>
                    <div class="col-md-6">
                        <label for="inputState" class="form-label">Tipo</label>
                        <select id="tipo" class="form-select">
                            <option selected>Presencial</option>
                            <option>Ead</option>
                            <option>Misto</option>
                        </select>
                    </div>

                    <div class="container bg-light p-3 my-3">
                        <div class="row mb-3 align-items-center">
                            <h6 class="form-label mt-3">Disciplinas por Semestre</h6>
                        </div>
                        <div class="row align-items-center mb-2">
                            <div class="col-7">
                                <input type="text" class="form-control" id="nome" placeholder="Disciplina" />
                            </div>
                            <div className="col-3">
                                <input type="text" class="form-control" id="nome" placeholder="Semestre" />
                            </div>
                            <div class="col-2 ">
                                <button id="btn_unfilter" type="button" class="btn btn-outline-danger">
                                    <i class="fa-regular fa-trash-can"></i>
                                </button>
                            </div>
                        </div>
                        <div class="row align-items-center mb-2">
                            <div class="col-7">
                                <input type="text" class="form-control" id="nome" placeholder="Disciplina" />
                            </div>
                            <div className="col-3">
                                <input type="text" class="form-control" id="nome" placeholder="Semestre" />
                            </div>
                            <div class="col-2 ">
                                <button id="btn_unfilter" type="button" class="btn btn-outline-danger">
                                    <i class="fa-regular fa-trash-can"></i>
                                </button>
                            </div>
                        </div>
                        <div class="row align-items-center mb-2">
                            <div class="col-7">
                                <input type="text" class="form-control" id="nome" placeholder="Disciplina" />
                            </div>
                            <div className="col-3">
                                <input type="text" class="form-control" id="nome" placeholder="Semestre" />
                            </div>
                            <div class="col-2 ">
                                <button id="btn_unfilter" type="button" class="btn btn-outline-danger">
                                    <i class="fa-regular fa-trash-can"></i>
                                </button>
                            </div>
                        </div>
                        <div class="col-1 text-end">
                            <button class="btn btn-outline-primary">
                                +
                            </button>
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

export default CadastroCurso;