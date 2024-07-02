import { Component, OnInit } from '@angular/core';
import { ComputerItemComponent } from './computerItem/computerItem.component';
import { Computer } from '../../_models/computer.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewComputerItemComponent } from './newComputerItem/newComputerItem.component';

@Component({
  selector: 'app-computer',
  standalone: true,
  templateUrl: './computer.component.html',
  styleUrls: ['./computer.component.css'],
  imports: [ComputerItemComponent, NewComputerItemComponent],
})
export class ComputerComponent implements OnInit {
  computers!: Computer[];
  isAddingComputer: boolean = false;

  private apiUrl = 'https://localhost:7233/api/v1/computer/';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAll().subscribe({
      next: (data) => {
        this.computers = data['computers'];
      },
      error: (error) => {
        console.error('Error fetching computers', error);
      },
    });
  }

  onClick() {
    this.isAddingComputer = true;
  }

  onCancelAddComputer() {
    this.isAddingComputer = false;
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'all');
  }

  add(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.httpClient.post(`${this.apiUrl}}`, data, { headers });
  }
}
