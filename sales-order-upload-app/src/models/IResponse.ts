/* eslint-disable @typescript-eslint/naming-convention */
/* eslint-disable @typescript-eslint/consistent-type-definitions */

import {type IMessageDTO} from './IMessage';

export interface ISalesOrderResponseDTO {
	isValid: boolean;
	responseDate: string;
	fileName: string;
	data: string;
}

export interface IFailedResponseStructureDTO {
	result: string;
	messages: IMessageDTO[];
}

export interface ISuccessResponseStructureDTO {
	result: string;
	messages: IMessageDTO[];
}
