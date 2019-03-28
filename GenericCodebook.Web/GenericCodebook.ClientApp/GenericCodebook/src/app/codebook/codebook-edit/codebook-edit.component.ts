import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IColumnDefs } from '../model/IColumnDefs';
import { CodebookService } from '../services/codebook.service';

@Component({
  selector: 'app-codebook-edit',
  templateUrl: './codebook-edit.component.html',
  styleUrls: ['./codebook-edit.component.css']
})
export class CodebookEditComponent implements OnInit {
  @Input('model') model: any;
  @Input('colDefs') colDefs: Array<IColumnDefs>;
  @Input('sifName') sifName: string;
  @Input('createMode') createMode = false;
  @Output() savedEvent: EventEmitter<any> = new EventEmitter();

  multiSelectSuggestions: any = {};

  /*
  TODO: Implement links to other codebook-s
  */
  constructor(private codebookService: CodebookService) { }

  ngOnInit() {
  }

  hideCallback() {
    this.model = null;
  }

  save() {
    if (this.createMode === true) {
      this.codebookService.create(this.model, this.sifName)
      .subscribe(res => {
        this.model = res;
        this.createMode = false;
      });
    } else {
      this.codebookService.update(this.model, this.sifName)
      .subscribe(res => {
        this.model = res;
      });
    }

  }

  getEditColDefs(): Array<IColumnDefs> {
    return this.colDefs.filter(x => x.detailsShow === true);
  }

  loadAutocompleteSuggestions(colDef: IColumnDefs, query: string, loadAll: boolean = false) {
    const filterBy = this.getAdditionalInfoValueByKey('filterBy', colDef);
    let filterVal = null;

    if (filterBy != null) {
      filterVal = this.model[filterBy];

      if (filterVal != null && typeof filterVal === 'object') {
        filterVal = filterVal['Id'];
      }
    }
    this.codebookService.loadAutocompleteSuggestions(colDef.suggestions, query, loadAll, filterBy, filterVal)
      .subscribe(res => {
        this.multiSelectSuggestions[colDef.suggestions] = res;
      });

  }


  isDisabled(colDef: IColumnDefs) {
    if (colDef.disabled === true) {
      return true;
    }

    if (this.getAdditionalInfoValueByKey('dependantField', colDef) != null && !this.hasDependantFieldAssigned(colDef)) {
      return true;
    }

    return false;
  }



  public getAdditionalInfoValueByKey(key: string, col: IColumnDefs) {
    if (col === null || col.additional_info === null) {
      return null;
    }

    const result = col.additional_info.filter(x => x.key === key)[0];

    if (result === null) {
      return null;
    }

    return result.value;
  }

  public hasDependantFieldAssigned(col: IColumnDefs): boolean {
    const dependant = this.getAdditionalInfoValueByKey('dependantField', col);

    if (dependant == null) {
      return true;
    }

    if (this.model[dependant] == null) {
      return false;
    }

    return true;
  }

  close() {
    this.model = null;
  }

}
