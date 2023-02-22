
/* eslint-disable no-negated-condition */
import React, {useCallback} from 'react';
import {useDropzone} from 'react-dropzone';
import {toast, ToastContainer, useToast} from 'react-toastify';
import {upload} from '@testing-library/user-event/dist/upload';
import styled from 'styled-components';

import {type ISalesOrderResponseDTO} from '../models/IResponse';
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

// #region Functions

const onFileDrop = async (event: any) => {
	const files: File[] = event as File[];
	// Validate File[] from control
	if (!files || files.length !== 1) {
		toast.error('Upload a single valid JSON file');
	}

	const file: File = files[0];
	// Validate extension
	if (file.name.endsWith('.json')) {
		// The file has a valid extension
		toast.warning(`Please wait while file ${file.name} is uploaded`, {autoClose: 2000});

		// Submit sales order
		await submitSalesOrder(file)
			.then((result: ISalesOrderResponseDTO) => {
				// Handle result
				if (!result.isValid) {
					onDownloadFile(result.data, result.fileName ?? 'sales_order_response.json', file.name, true);
				} else {
					// onDownloadFile(result.data, result.fileName ?? 'sales_order_response.json', file.name, false);
				}
			})
			.catch(error => {
				// Handle error
				console.error(error);
				toast.error(`The file ${file.name} failed to upload. See console for more information`);
			});
	} else {
		// The file does not have a valid extension
		toast.error(`The file ${file.name} is not a valid JSON file`);
	}
};

const onDownloadFile = (jsonString: string, newFileName: string, sourceFileName: string, hasError: boolean) => {
	const data = new Blob([jsonString], {type: 'application/json'});
	const url = URL.createObjectURL(data);
	const link = document.createElement('a');
	link.href = url;
	link.setAttribute('download', newFileName);
	document.body.appendChild(link);
	link.click();

	// Display toast
	if (hasError) {
		toast.error(`The file ${sourceFileName} contains errors. See the response file for more information`);
	} else {
		toast.success(`The file ${sourceFileName} submitted successfully. See the expected sales order file`);
	}
};

// #endregion

const SalesDropzone = () => {
	const onDropAccepted = useCallback((acceptedFiles: any) => {
		// eslint-disable-next-line @typescript-eslint/no-floating-promises
		onFileDrop(acceptedFiles);
	}, []);

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
};

export default SalesDropzone;
