import React, {useCallback} from 'react';
import {useDropzone} from 'react-dropzone';
import {toast} from 'react-toastify';
import styled from 'styled-components';

import {submitSalesOrder} from '../services/UploadService';

// #region Style

export const DropzoneWrapper = styled.div`
  cursor: pointer;

  .dropzone-section {
    :hover {
        border: 1px solid !important;
    }
  }
`;
// #endregion

const onDrop = async (event: any) => {
	const files: File[] = event as File[];
	if (!files || files.length !== 1) {
		toast.error('Upload a single valid JSON file');
	}

	const file: File = files[0];
	if (file.name.endsWith('.json')) {
		// The file has a valid extension
		toast.warning(`Please wait while file ${file.name} is uploaded`);
		// Submit sales order
		await submitSalesOrder(file).then(result => {
			// do something for success
			// eslint-disable-next-line no-debugger
			debugger;
		}).catch(error => {
			// do something for failure
			// eslint-disable-next-line no-debugger
			debugger;
		});
	} else {
		// The file does not have a valid extension
		toast.error(`The file ${file.name} is not a valid JSON file`);
	}
};

function SalesDropzone() {
	const onDropAccepted = useCallback((acceptedFiles: any) => {
		// eslint-disable-next-line @typescript-eslint/no-floating-promises
		onDrop(acceptedFiles);
	}, [onDrop]);

	const {getRootProps, getInputProps, isDragActive} = useDropzone({
		onDrop: onDropAccepted,
		// eslint-disable-next-line @typescript-eslint/naming-convention
		accept: {'application/json': ['.json']},
		multiple: false,
	});

	return (
		<DropzoneWrapper>
			<section className='dropzone-section container-fluid text-center w-50 h-50 border rounded mt-5 p-3'>
				<div {...getRootProps({className: 'dropzone'})}>
					<input {...getInputProps()} />
					<p>Drag 'n' drop a <em>JSON</em> file here, or click to select a file</p>
					<em>(1 file is the maximum number of files you can drop here)</em>
				</div>
			</section>
		</DropzoneWrapper>
	);
}

export default SalesDropzone;