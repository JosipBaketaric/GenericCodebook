import { Type } from '@angular/core';
import { IConfigurationData } from './IConfigurationData';

export interface ICodebookConfiguration {
    path: string;
    component: Type<any>;
    data: IConfigurationData;
}
