import { KeyValue } from './key-value-dictionary';

export interface IColumnDefs {
    field: string;  // Name of coulumn like in DTO but with first letter in lower case ex: FirstName => firstName
    header: string; // Display name
    identity: true | false; // Only one identity column can exist this is usualy Id column.

    type:   'string'    // Type of column
            | 'number'
            | 'checkbox'
            | 'dropdown'
            | 'autocomplete'
            | 'datepicker'
            | 'hidden'
            | 'navigation_left' // This is custom column that can be used for navigation between versions
            | 'navigation_right'    // This is custom column that can be used for navigation between versions
            | 'multiselect';
    width: string;  // width in datatable grid
    columns: 1 | 2; // width in edit and create mode

    filter: true | false;    // enable or disable filtering for this field
    sortable: true | false; // enable or disable sorting for this field
    disabled: true | false; // enable or disable edit for this field
    required: true | false; // is required for saving for this field

    suggestions: string;    // for autocompletes or dropdowns. This contains name of codebook that provides suggestions

    gridShow: true | false; // enable or disable grid show for this field
    detailsShow: true | false;  // enable or disable detail show for this field
    editShow: true | false; // enable or disable edit show for this field

    routerField: string;
    routerLink: string;

    fk: string;
    fk_prop: string;

    additional_info: KeyValue<any>[];
}
