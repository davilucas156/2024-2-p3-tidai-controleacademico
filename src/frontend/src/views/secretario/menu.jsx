import React from 'react';
import { Link, Route, Routes } from 'react-router-dom';
import '../../styles/menuUsuarios.css';

import ViewInicial from './viewInicial';
import ViewCadastroUser from './ViewCadastroUser';
import ViewCadastroCurso from './ViewCadastroCurso';
import ViewRelatorio from './ViewRelatorio';  // Corrigido o nome

function MenuSecretario() {
  return (
    <div>
      <div className="l-navbar" id="nav-bar">
        <nav className="nav">
          <div>
            <Link to="/" className="nav_logo">
              <i className='bx bx-layer nav_logo-icon'></i>
              <span className="nav_logo-name">Secretário</span>
            </Link>

            <div className="nav_list">
              <Link to="/gestao-usuario" className="nav_link">
                <i className='bx bx-user nav_icon'></i>
                <span className="nav_name">Gestão de Usuários</span>
              </Link>
              <Link to="/gestao-cursos" className="nav_link">
                <i className='bx bx-message-square-detail nav_icon'></i>
                <span className="nav_name">Gestão de Cursos</span>
              </Link>
              <Link to="/relatorios" className="nav_link">
                <i className='bx bx-grid-alt nav_icon'></i>
                <span className="nav_name">Relatórios</span>
              </Link>
              <Link to="/calendario" className="nav_link">
                <i className='bx bx-folder nav_icon'></i>
                <span className="nav_name">Calendário</span>
              </Link>
            </div>
          </div>

          <Link to="/logout" className="nav_link">
            <i className='bx bx-log-out nav_icon'></i>
            <span className="nav_name">Sair</span>
          </Link>
        </nav>
      </div>

      <div className="content">
        {/* Roteamento para renderizar as views conforme o menu selecionado */}
        <Routes>
          <Route path="/" element={<ViewInicial />} />
          <Route path="/gestao-cursos" element={<ViewCadastroCurso />} />
          <Route path="/relatorios" element={<ViewRelatorio />} />
          <Route path="/calendario" element={<ViewInicial />} />
          <Route path="/gestao-usuario" element={<ViewCadastroUser />} />
          <Route path="/logout" element={<ViewInicial />} />
        </Routes>
      </div>
    </div>
  );
}

export default MenuSecretario;
