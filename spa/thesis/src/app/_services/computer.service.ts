import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ComputerService {
  private apiUrl = 'https://localhost:7233/api/v1/computer';

  constructor(private http: HttpClient) {}

  getById(data: string): Observable<any> {
    return this.http.get(`${this.apiUrl}?id=${data}`);
  }

  getAll(): Observable<any> {
    return this.http.get(`${this.apiUrl}}`);
  }

  add(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(`${this.apiUrl}}`, data, { headers });
  }

  update(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.patch(`${this.apiUrl}}`, data, { headers });
  }

  delete(data: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${data}`);
  }
}
