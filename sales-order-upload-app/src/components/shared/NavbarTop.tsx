import React from 'react';
import {Nav, NavDropdown} from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';

function NavbarTop() {
	return (<>
		<Navbar bg='light' expand='lg'>
		   <Navbar.Brand href=''>Sales Order Client</Navbar.Brand>
		   <Navbar.Toggle aria-controls='basic-navbar-nav' />
		   <Navbar.Collapse id='basic-navbar-nav'>
			   <Nav className='mr-auto'>
				   <Nav.Link href='#home'>Home</Nav.Link>
			   </Nav>
		   </Navbar.Collapse>
	   </Navbar>
	</>);
}

export default NavbarTop;
