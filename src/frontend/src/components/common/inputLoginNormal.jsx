import React from 'react';
import { useNavigate } from 'react-router-dom'; /* dom? */  

const LoginButton = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    navigate('/login');  
  };

  return (
    <button onClick={handleLogin} className="btn btn-primary">
      Ir para o Login
    </button>
  );
};

export default LoginButton;
