import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { Expense } from '../dto/expense';
@Injectable({
  providedIn: 'root'
})
export class ExpServiceService {

  apiURL = 'https://localhost:5001/';
  constructor(private http : HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  
 
  getHackerRankData() : Observable<any>
  {
    return this.http.get("https://jsonmock.hackerrank.com/api/movies?Year=2015");
  }

  getExpTypes(url: string | undefined) : Observable<any>
  {
      return this.http.get(this.apiURL + url);   
  }

  PostPutDeleteExp(url: string, obj : Expense) : Observable<any>
  {
    return this.http.post(this.apiURL + url, obj);
  }

  getExpTypesTwo()
  {
      const promise = new Promise((resolve, rejects) => {
        this.http.get<any[]>(this.apiURL + 'Expense/GetExpTypes').toPromise().then((res: any) => {
          console.log(res.obj);
        })
      })
  }
  handleError(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
      console.log(error.error.message);
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
 }
}
