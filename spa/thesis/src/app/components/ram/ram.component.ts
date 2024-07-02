import { Component, OnInit } from '@angular/core';
import { RAM } from '../../_models/ram.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RamItemComponent } from "./ramItem/ramItem.component";

@Component({
    selector: 'app-ram',
    standalone: true,
    templateUrl: './ram.component.html',
    styleUrls: ['./ram.component.css'],
    imports: [RamItemComponent]
})
export class RamComponent implements OnInit {
  ram!: RAM[];

  private apiUrl = 'https://localhost:7233/api/v1/ram/';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAll().subscribe({
      next: (data) => {
        this.ram = data['ram'];
      },
      error: (error) => {
        console.error('Error fetching ram', error);
      },
    });
  }

  onClick() {
    console.log(this.ram);
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'all');
  }
}
