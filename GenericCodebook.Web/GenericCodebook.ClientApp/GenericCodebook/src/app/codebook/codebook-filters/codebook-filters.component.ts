import { Component, OnInit, Input } from '@angular/core';
import { BaseCodebookFilter } from '../model/BaseFilter';
import { IColumnDefs } from '../model/IColumnDefs';

@Component({
  selector: 'app-codebook-filters',
  templateUrl: './codebook-filters.component.html',
  styleUrls: ['./codebook-filters.component.css']
})
export class CodebookFiltersComponent implements OnInit {
  @Input('filter') filter: BaseCodebookFilter;
  @Input('colDefs') colDefs: Array<IColumnDefs>;


  constructor() { }

  ngOnInit() {
  }


  getGridFilters(): Array<IColumnDefs> {
    return this.colDefs.filter(x => x.filter === true);
  }

}
