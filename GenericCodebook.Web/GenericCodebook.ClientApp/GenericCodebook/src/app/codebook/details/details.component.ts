import { Component, OnInit, Input } from '@angular/core';
import { IColumnDefs } from '../model/IColumnDefs';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
@Input('model') model: any;
@Input('colDefs') colDefs: Array<IColumnDefs>;
@Input('sifName') sifName: string;

  constructor() { }

  ngOnInit() {
  }

  getDetailsColDefs(): Array<IColumnDefs> {
    return this.colDefs.filter(x => x.detailsShow === true);
  }

  // TODO: Implement reroute

  close() {
    this.model = null;
  }

}
