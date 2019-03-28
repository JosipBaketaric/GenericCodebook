import { Component, OnInit, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IConfigurationData } from '../model/IConfigurationData';
import { IColumnDefs } from '../model/IColumnDefs';
import { CodebookService } from '../services/codebook.service';
import { BaseCodebookFilter } from '../model/BaseFilter';

@Component({
  selector: 'app-codebook-grid',
  templateUrl: './codebook-grid.component.html',
  styleUrls: ['./codebook-grid.component.css']
})
export class CodebookGridComponent implements OnInit {
  public data: IConfigurationData;
  public codebookModel: any;
  public infoModel: any;
  public editModel: any;
  public filter: BaseCodebookFilter = new BaseCodebookFilter();
  public createMode = false;

  constructor(private activatedRoute: ActivatedRoute,
              private codebookService: CodebookService,
  ) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe(params => {
      this.data = params as IConfigurationData;
      this.filter.codebookName = this.data.tableName;
      this.getFiltered();
    });

    this.activatedRoute.params.subscribe(params => {
      if (params['id'] && params['mode'] === 'details') {
        this.loadById(params['id'], 'details');
      }
      if (params['id'] && params['mode'] === 'edit') {
        this.loadById(params['id'], 'edit');
      }
    });

  }

  getFiltered() {
    if (this.filter === null) {
    }

    this.codebookService.getFiltered(this.data.tableName, this.filter)
      .subscribe(result => {
        this.codebookModel = result;
        console.log(this.codebookModel);
      });
  }




  loadById(id: number, mode: 'details' | 'edit') {
    // this.codebookService.getById(id).subscribe(x => {
    //   if (mode === 'details') {
    //     this.openDetailsDialog(x);
    //   } else if (mode === 'edit') {
    //     this.openEditDialog(x);
    //   }
    // });
  }

  getGridColDefs(): Array<IColumnDefs> {
    return this.data.columnDefs.filter(x => x.gridShow === true);
  }


  showInfo(item: any) {
    this.infoModel = JSON.parse(JSON.stringify(item));
  }

  showEdit(item: any) {
    this.createMode = false;
    this.editModel = JSON.parse(JSON.stringify(item));
  }

  showCreate() {
    this.createMode = true;
    this.editModel = {};
  }

  deleteRow(item: any) {
    const identityCol = this.findIdentityColumn(this.data.columnDefs);
    this.codebookService.delete(this.data.tableName, item[identityCol]).subscribe(res => {
      this.getFiltered();
    });
  }



  private findIdentityColumn(colDefs: Array<IColumnDefs>): string {

    const identityCol = colDefs.filter(x => x.identity === true);

    if (identityCol.length === 0) {
      throw Error('Codebook configuration error! Missing identity column definition!');
    }
    if (identityCol.length > 1) {
      throw Error('Codebook configuration error!Multiple identity column definitions!');
    }

    return identityCol[0].field;
  }


  // delete everything bellow - this is only for this datatable
  getNumberOfPages(): string[] {
    if (this.codebookModel === null || this.codebookModel['numOfTotalRecords'] === null || this.codebookModel['numOfTotalRecords'] === 0) {
      return [];
    }

    const size = Math.floor(this.codebookModel['numOfTotalRecords'] / 10);

    const result: Array<string> = new Array<string>();

    for (let i = 0; i < size; i++) {
      result.push((i + 1).toString());
    }

    return result;
  }



  getClass(i: string): string {
    if ((this.filter.CurrentPageIndex == null || this.filter.CurrentPageIndex === undefined) && i === '1') {
      this.filter.CurrentPageIndex = 1;
      return 'active-page';
    }

    const distanceFromActivePage = Math.abs(this.filter.CurrentPageIndex - Number(i));


    if (this.filter.CurrentPageIndex == null || this.filter.CurrentPageIndex === undefined) {
      if (distanceFromActivePage > 5) {
        return 'inactive-page-far';
      }
      return 'inactive-page';
    }

    if (this.filter.CurrentPageIndex.toString() === i) {
      return 'active-page';
    }

    if (distanceFromActivePage > 5) {
      return 'inactive-page-far';
    }

    return 'inactive-page';
  }

  loadLazy(i: number) {
    this.filter.CurrentPageIndex = i;
    this.getFiltered();
  }



}
