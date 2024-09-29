import React from 'react';

const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <a className="navbar-brand" href="#">UNIBH</a>
        <div className="d-flex">
          <a href="login.html" className="btn btn-primary login-btn">Login Acadêmico</a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
