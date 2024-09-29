import React from 'react';

const NewsCards = () => {
  return (
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
  );
};

export default NewsCards;
