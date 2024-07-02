import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Processor } from '../../_models/processor.model';
import { Observable } from 'rxjs';
import { ProcessorItemComponent } from "./processorItem/processorItem.component";

@Component({
    selector: 'app-processor',
    standalone: true,
    templateUrl: './processor.component.html',
    styleUrls: ['./processor.component.css'],
    imports: [ProcessorItemComponent]
})
export class ProcessorComponent implements OnInit {
  processors!: Processor[];

  private apiUrl = 'https://localhost:7233/api/v1/processor/';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAll().subscribe({
      next: (data) => {
        this.processors = data['processors'];
      },
      error: (error) => {
        console.error('Error fetching processors', error);
      },
    });
  }

  onClick() {
    console.log(this.processors);
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'all');
  }
}
