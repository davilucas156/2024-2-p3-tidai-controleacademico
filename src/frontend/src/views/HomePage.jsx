import React from 'react';
import Navbar from '../components/common/Navbar';
import Footer from '../components/common/Footer';
import NewsCard from '../components/common/newscard';
import Welcome from '../components/common/welcome';

const HomePage = () => {
  return (
    <div>
      <Navbar />
      <Welcome />
      <div className="news-section">
        <NewsCard />
      </div>
      <Footer />
    </div>
  );
};

export default HomePage;
