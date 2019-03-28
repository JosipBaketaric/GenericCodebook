import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseCodebookFilter } from '../model/BaseFilter';
import { map } from 'rxjs/operators';
import { LongOptionDTO } from '../model/LongOptionDTO';
import { BaseCodebookDTO } from '../model/BaseCodebookDTO';

@Injectable({
  providedIn: 'root'
})
export class CodebookService {
  private readonly baseUrl = 'http://localhost:50417/api/';
  private readonly getFilteredUrl = 'codeBook/getFiltered';
  private readonly getByIdUrl = 'codeBook/getById';
  private readonly getAutocompleteSuggestionsUrl = 'codebook/getAutocompleteSuggestions';
  private readonly loadChildrenUrl = 'codeBook/loadChildren';
  private readonly deleteUrl = 'codeBook/delete';


  constructor(private http: HttpClient) { }


  // GET
  getFiltered(tableName: string, filter: BaseCodebookFilter): Observable<any> {
    return this.http.post(this.baseUrl + this.getFilteredUrl, filter);
  }

  public loadAutocompleteSuggestions(sugestionName: string, filter: string, all: boolean
    , filterBy: string, filterVal: string): Observable<LongOptionDTO[]> {
    if (filterBy == null) {
      filterBy = '';
    }

    if (filterVal == null) {
      filterVal = '';
    }

    return this.http.get(this.baseUrl + this.getAutocompleteSuggestionsUrl
      + '/' + sugestionName
      + '/' + filter
      + '/' + all
      + '/' + filterBy
      + '/' + filterVal)
      .pipe(map(val => {
        return val as LongOptionDTO[];
      }));
  }

  public getById(sifName: string, id: number): Observable<any> {
    return this.http.get(this.baseUrl + this.getByIdUrl
      + '/' + sifName
      + '/' + id);
  }

  public loadChildren(sifName: string, id: number): Observable<any> {
    return this.http.get(this.baseUrl + this.loadChildrenUrl
      + '/' + sifName
      + '/' + id);
  }


  // SET
  public create(val: any, sifName: string): Observable<any> {
    const baseCodebook: BaseCodebookDTO = new BaseCodebookDTO();

    baseCodebook.codebookName = sifName;
    baseCodebook.item = val;

    return this.http.post(this.baseUrl + 'codebook/' + 'create', baseCodebook);
  }

  public update(val: any, sifName: string): Observable<any> {
    const baseCodebook: BaseCodebookDTO = new BaseCodebookDTO();

    baseCodebook.codebookName = sifName;
    baseCodebook.item = val;

    return this.http.post(this.baseUrl + 'codebook/' + 'update', baseCodebook);
  }

  public delete(sifName: string, id: number): Observable<any> {
    return this.http.get(this.baseUrl + this.deleteUrl
      + '/' + sifName
      + '/' + id);
  }



}
