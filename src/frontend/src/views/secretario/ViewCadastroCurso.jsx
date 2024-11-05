import React, { useState } from 'react';
import CadastroCurso from '../../components/secretario/ModalCadastroCurso';
import UserTable from '../../components/secretario/TabelaCursos';
import DeleteModal from '../../components/common/ModalConfirmaExclusão';

const ViewCadastroUser = () => {
    const initialState = [
        {
            id: '1',
            nome: 'Direito',
            nivel: 'Pós-Graduação',
            tipo: 'Presencial',
            disciplinas: '15',
        },
        {
            id: '2',
            nome: 'Análise e Desenvolvimento de Sistemas',
            nivel: 'Graduação',
            tipo: 'Misto',
            disciplinas: '6',
        },
        {
            id: '3',
            nome: 'Inteligencia Artificial',
            nivel: 'Mestrado',
            tipo: 'EAD',
            disciplinas: '21',
        }
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
            id: document.getElementById('id').value,
            nome: document.getElementById('nome').value,
            nivel: document.getElementById('nivel').value,
            tipo: document.getElementById('tipo').value,
            disciplinas: document.getElementById('disciplinas').value,
        };
        setAtividade([...atividades, { ...atividade }]);
    }

    return (
        <div className='container'>
            <div className="height-100">
                <h4 className='p-5'>Gestão de Cursos</h4>
                <div className="container">
                    <div className="row mb-3">
                        <div className="col-1">
                            <input type="text" className="form-control" id="id" placeholder="Id" />
                        </div>
                        <div className="col-3">
                            <input type="text" className="form-control" id="nome" placeholder="Nome" />
                        </div>
                        <div className="col-2">
                            <select className="form-select" id="nivel" aria-label="">
                                <option value="">Nível</option>
                                <option value="graduação">Graduação</option>
                                <option value="pós-graduação">Pós-Graduação</option>
                                <option value="doutorado">Doutorado</option>
                                <option value="mestrado">Mestrado</option>
                            </select>
                        </div>
                        <div className="col-2">
                            <select className="form-select" id="tipo" aria-label="">
                                <option value="">Tipo</option>
                                <option value="presencial">Presencial</option>
                                <option value="ead">EAD</option>
                                <option value="misto">Misto</option>
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

                {/* Tabela de Cursos */}
                <UserTable atividades={atividades} handleShow={handleShow} handleShow2={handleShow2} />

                {/* Modal de Formulário */}
                <CadastroCurso show={show} handleClose={handleClose} addAtividade={addAtividade} />

                {/* Modal de Exclusão */}
                <DeleteModal show2={show2} handleClose2={handleClose2} />
            </div>
        </div>
    );
}

export default ViewCadastroUser;
