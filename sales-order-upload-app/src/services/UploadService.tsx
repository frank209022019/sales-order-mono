import {type ISalesOrderResponseDTO} from '../models/IResponse';

const api = 'https://localhost:7057/api/sales-order';

export const submitSalesOrder = async (salesOrder: File) => new Promise<ISalesOrderResponseDTO>((resolve, reject) => {
	// append to formData
	const formData = new FormData();
	formData.append('salesOrder', salesOrder);
	// POST: /upload
	fetch(`${api}/upload`, {
		method: 'POST',
		body: formData,
	})
		.then(async response => {
			// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
			const data = await response.json();
			// eslint-disable-next-line @typescript-eslint/no-unsafe-argument
			resolve(data);
		})
		.catch(error => {
			console.error('Error uploading file:', error);
			reject(error);
		});
});
