import React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { BrowserRouter as Router } from 'react-router-dom';

const DeleteModal = ({ show2, handleClose2 }) => {
  return (
    <Modal show={show2} onHide={handleClose2} animation={false}>
      <Modal.Header closeButton>
        <Modal.Title>Excluir dados selecionados</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>Confirma exclusão?</p>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose2}>Fechar</Button>
        <Button variant="primary" onClick={handleClose2}>Excluir</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default DeleteModal;
