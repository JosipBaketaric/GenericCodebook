import { IColumnDefs } from './IColumnDefs';

export interface IConfigurationData {
    tableName: string;
    title: string;
    columnDefs: Array<IColumnDefs>;
}
