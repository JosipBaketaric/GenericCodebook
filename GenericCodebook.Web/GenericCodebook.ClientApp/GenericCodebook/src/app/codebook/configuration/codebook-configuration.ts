import { ICodebookConfiguration } from '../model/ICodebookConfiguration';
import { CodebookGridComponent } from '../codebook-grid/codebook-grid.component';


export const SifCountryConfiguration: ICodebookConfiguration = {
    path: 'test_codebook',
    component: CodebookGridComponent,
    data: {
        tableName: 'TestCodebook',
        title: 'Test Codebook',
        columnDefs: [
            {
                field: 'id',
                header: 'Id',
                identity: true,
                type: 'number',
                width: '25%',
                columns: 1,
                filter: false,
                sortable: false,
                disabled: true,
                required: false,
                suggestions: null,
                gridShow: false,
                detailsShow: false,
                editShow: false,
                routerField: null,
                routerLink: null,
                fk: null,
                fk_prop: null,
                additional_info: null,
            },
            {
                field: 'name',
                header: 'Name',
                identity: false,
                type: 'string',
                width: '25%',
                columns: 1,
                filter: true,
                sortable: true,
                disabled: false,
                required: true,
                suggestions: null,
                gridShow: true,
                detailsShow: true,
                editShow: true,
                routerField: null,
                routerLink: null,
                fk: null,
                fk_prop: null,
                additional_info: null,
            }
        ]
    }
};
