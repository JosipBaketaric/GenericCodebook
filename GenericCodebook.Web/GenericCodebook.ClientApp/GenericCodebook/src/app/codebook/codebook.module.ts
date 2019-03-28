import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CodebookGridComponent } from './codebook-grid/codebook-grid.component';
import { routing } from './codebook.routing';
import { CodebookService } from './services/codebook.service';
import { CodebookFiltersComponent } from './codebook-filters/codebook-filters.component';
import { FormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { CodebookEditComponent } from './codebook-edit/codebook-edit.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    routing,
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  declarations: [
    CodebookGridComponent,
    CodebookFiltersComponent,
    DetailsComponent,
    CodebookEditComponent,
  ],
  providers: [
    CodebookService
    ]
})
export class CodebookModule { }
