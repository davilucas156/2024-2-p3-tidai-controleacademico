import React from 'react';

const Footer = () => {
  return (
    <footer className="text-center py-4 bg-light">
      <div className="container">
        <img
          src="https://static.vecteezy.com/ti/vetor-gratis/p1/15668053-modelo-de-design-de-logotipo-da-faculdade-ilustracaoial-logotipo-da-faculdade-da-universidade-distintivos-emblemas-sinais-estoque-logotipo-do-campus-da-faculdade-gratis-vetor.jpg"
          alt="Logo da UNIBH"
          className="footer-logo mb-3"
        />
        <p>&copy; 2024 Faculdade UNIBH. Todos os direitos reservados.</p>
        <p>Faça parte da nossa comunidade acadêmica e transforme seu futuro!</p>

        <ul className="footer-social-icons">
          <li><a href="https://facebook.com" target="_blank" rel="noreferrer"><i className="bi bi-facebook"></i></a></li>
          <li><a href="https://twitter.com" target="_blank" rel="noreferrer"><i className="bi bi-twitter"></i></a></li>
          <li><a href="https://instagram.com" target="_blank" rel="noreferrer"><i className="bi bi-instagram"></i></a></li>
          <li><a href="https://linkedin.com" target="_blank" rel="noreferrer"><i className="bi bi-linkedin"></i></a></li>
        </ul>

        <p>Contatos: <br /> Telefone: (31) 1234-5678 <br /> Email: contato@unibh.edu.br</p>
      </div>
    </footer>
  );
};

export default Footer;
    