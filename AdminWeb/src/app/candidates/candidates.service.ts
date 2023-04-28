import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { CandidateForms} from '../models/CandidateForms.model';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class CandidatesService {

  constructor(private http:HttpClient) {}

  private url = 'https://superadminbackend.herokuapp.com/api/admin';//https://localhost:5001 //http://localhost:4200/forms

  public getCandidateForms() {
    return this.http.get<CandidateForms[]>(this.url + "/FormView");
  }

  public getCandidates(id) {
    return this.http.get(this.url + "/get-candidates/"+ id);
  }

  public getDetails(id) {
    return this.http.get(this.url + "/detailcandidate/"+ id);
  }

  public deleteCandidate(ids) {
    return this.http.post(this.url + "/delete/", ids);
  }

  public createCandidates(candidates) {
    return this.http.post<CandidateForms>(this.url + "/add-candidates", candidates);
  }

  public updateCandidates(candidates) {
    return this.http.put<CandidateForms>(this.url + "/update-candidates", candidates);
  }

}
