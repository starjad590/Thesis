import { Component } from '@angular/core';
import { GraphicsCard, NewGraphicsCard } from '../../_models/graphicsCard.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GraphicsCardItemComponent } from "./graphicsCardItem/graphicsCardItem.component";
import { NewGraphicsCardItemComponent } from "./newGraphicsCardItem/newGraphicsCardItem.component";

@Component({
  selector: 'app-graphicsCard',
  standalone: true,
  templateUrl: './graphicsCard.component.html',
  styleUrls: ['./graphicsCard.component.css'],
  imports: [GraphicsCardItemComponent, NewGraphicsCardItemComponent],
})
export class GraphicsCardComponent {
  graphicsCards!: GraphicsCard[];
  isAddingGraphicsCard: boolean = false;

  private apiUrl = 'https://localhost:7233/api/v1/graphicsCard';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAllSub();
  }

  onClick() {
    this.isAddingGraphicsCard = true;
  }

  onCancelAddGraphicsCard() {
    this.isAddingGraphicsCard = false;
  }

  onAdd(event: NewGraphicsCard) {
    this.addSub({
      make: event.make,
      model: event.model,
      version: event.version,
    });
    this.getAllSub();
    this.onCancelAddGraphicsCard();
  }

  onUpdate(event: GraphicsCard) {
    this.addSub({
      make: event.make,
      model: event.model,
      version: event.version,
    });
    this.getAllSub();
  }

  getAllSub() {
    this.getAll().subscribe({
      next: (data) => {
        this.graphicsCards = data['graphicsCards'];
      },
      error: (error) => {
        console.error('Error fetching graphicsCards', error);
      },
    });
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + '/all');
  }

  addSub(data: any) {
    this.add(data).subscribe({
      next: (response) => console.log('Response:', response),
      error: (error) => console.error('Error:', error),
    });
  }

  add(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    console.log('here');
    return this.httpClient.post(this.apiUrl, data, { headers });
  }

  updateSub(data: any){
    this.add(data).subscribe({
      next: (response) => console.log('Response:', response),
      error: (error) => console.error('Error:', error),
    });
  }

  update(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.httpClient.patch(`${this.apiUrl}}`, data, { headers });
  }
}
