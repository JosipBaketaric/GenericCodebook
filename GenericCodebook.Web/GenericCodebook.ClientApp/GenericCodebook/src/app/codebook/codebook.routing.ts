import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import * as CodebookConfiguration from './configuration/codebook-configuration';

const routes: Routes = [
    {
        path: CodebookConfiguration.SifCountryConfiguration.path,
        component: CodebookConfiguration.SifCountryConfiguration.component,
        data: CodebookConfiguration.SifCountryConfiguration.data
    },
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
