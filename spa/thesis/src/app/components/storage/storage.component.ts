import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { StorageItemComponent } from "./storageItem/storageItem.component";
import { Storage } from '../../_models/storage.model';

@Component({
    selector: 'app-storage',
    standalone: true,
    templateUrl: './storage.component.html',
    styleUrls: ['./storage.component.css'],
    imports: [StorageItemComponent]
})
export class StorageComponent implements OnInit {
  storage!: Storage[];

  private apiUrl = 'https://localhost:7233/api/v1/storage/';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAll().subscribe({
      next: (data) => {
        this.storage = data['storage'];
      },
      error: (error) => {
        console.error('Error fetching storage', error);
      },
    });
  }

  onClick() {
    console.log(this.storage);
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'all');
  }
}
