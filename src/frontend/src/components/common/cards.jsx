import React from 'react';

const HomePage = () => {
  return (
    <div>
      {/* Navbar */}
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">UNIBH</a>
          <div className="d-flex">
            <a href="login.html" className="btn btn-primary login-btn">Login Acadêmico</a>
          </div>
        </div>
      </nav>

      {/* Hero Section */}
      <section className="hero-section">
        <div className="container">
          <h1>Bem-vindo à UNIBH</h1>
          <p>Confira as últimas novidades, bolsas e notícias da nossa comunidade acadêmica.</p>
        </div>
      </section>

      {/* News and Cards Section */}
      <section className="py-5">
        <div className="container">
          <h2 className="text-center mb-4">Novidades e Notícias</h2>
          <div className="row g-4">
            {/* Card 1 */}
            <div className="col-md-4">
              <div className="card card-custom">
                <img src="https://fasam.edu.br/wp-content/uploads/2020/09/Bolsas-de-Estudos-FASAM-1.jpg" className="card-img-top" alt="Bolsas de Estudo" />
                <div className="card-body">
                  <h5 className="card-title">Bolsas de Estudo</h5>
                  <p className="card-text">Conheça as oportunidades de bolsas de estudo oferecidas para este semestre.</p>
                  <a href="#" className="btn btn-primary">Saiba Mais</a>
                </div>
              </div>
            </div>

            {/* Card 2 */}
            <div className="col-md-4">
              <div className="card card-custom">
                <img src="https://blog.even3.com.br/wp-content/uploads/2022/07/icone-materiais-educativos_guia-p-organizacao-de-congressos-1024x1024.png" className="card-img-top" alt="Eventos Acadêmicos" />
                <div className="card-body">
                  <h5 className="card-title">Eventos Acadêmicos</h5>
                  <p className="card-text">Fique por dentro dos próximos eventos acadêmicos e palestras da faculdade.</p>
                  <a href="#" className="btn btn-primary">Saiba Mais</a>
                </div>
              </div>
            </div>

            {/* Card 3 */}
            <div className="col-md-4">
              <div className="card card-custom">
                <img src="https://assets-blog.pagseguro.uol.com.br/wp-content/2021/06/como-guardar-dinheiro-pra-faculdade.jpg" className="card-img-top" alt="Últimas Notícias" />
                <div className="card-body">
                  <h5 className="card-title">Últimas Notícias</h5>
                  <p className="card-text">Veja as últimas notícias da nossa comunidade acadêmica e conquistas de alunos.</p>
                  <a href="#" className="btn btn-primary">Saiba Mais</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="text-center py-4 bg-light">
        <div className="container">
          <img src="https://static.vecteezy.com/ti/vetor-gratis/p1/15668053-modelo-de-design-de-logotipo-da-faculdade-ilustracaoial-logotipo-da-faculdade-da-universidade-distintivos-emblemas-sinais-estoque-logotipo-do-campus-da-faculdade-gratis-vetor.jpg" 
               alt="Logo da UNIBH" className="footer-logo mb-3" />
          <p>&copy; 2024 Faculdade UNIBH. Todos os direitos reservados.</p>
          <p>Faça parte da nossa comunidade acadêmica e transforme seu futuro!</p>

          {/* Footer Social Icons */}
          <ul className="footer-social-icons">
            <li><a href="https://facebook.com" target="_blank" rel="noreferrer"><i className="bi bi-facebook"></i></a></li>
            <li><a href="https://twitter.com" target="_blank" rel="noreferrer"><i className="bi bi-twitter"></i></a></li>
            <li><a href="https://instagram.com" target="_blank" rel="noreferrer"><i className="bi bi-instagram"></i></a></li>
            <li><a href="https://linkedin.com" target="_blank" rel="noreferrer"><i className="bi bi-linkedin"></i></a></li>
          </ul>

          <p>Contatos: <br /> Telefone: (31) 1234-5678 <br /> Email: contato@unibh.edu.br</p>
        </div>
      </footer>
    </div>
  );
};

export default HomePage;
