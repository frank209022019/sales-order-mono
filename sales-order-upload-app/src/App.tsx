import React from 'react';

import SalesDropzone from './components/SalesDropzone';
import NavbarTop from './components/shared/NavbarTop';

import './App.scss';

function App() {
	return (
		<>
			{/* Top Navigation */}
			<div>
				<NavbarTop />
			</div>
			{/* Dropzone */}
			<SalesDropzone />
		</>
	);
}

export default App;
