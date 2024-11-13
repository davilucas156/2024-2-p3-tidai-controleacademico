import './styles/App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import '@fortawesome/fontawesome-free/css/all.min.css';
import MenuSecretario from './views/secretario/menu';
import ViewLogin from './views/login';
import React from 'react';
import ViewIndex from './views';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          
         <Route path="/" element={<ViewIndex/>} />

          <Route path="/login" element={<ViewLogin />} />

          <Route path="/menu-secretario" element={<MenuSecretario />} />

        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
