import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PowerSupplyItemComponent } from './powerSupplyItem/powerSupplyItem.component';
import { PowerSupply } from '../../_models/powerSupply.model';

@Component({
  selector: 'app-powerSupply',
  standalone: true,
  templateUrl: './powerSupply.component.html',
  styleUrls: ['./powerSupply.component.css'],
  imports: [PowerSupplyItemComponent],
})
export class PowerSupplyComponent implements OnInit {
  powerSupplies!: PowerSupply[];

  private apiUrl = 'https://localhost:7233/api/v1/powerSupply/';

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getAll().subscribe({
      next: (data) => {
        this.powerSupplies = data['powerSupplies'];
      },
      error: (error) => {
        console.error('Error fetching powerSupplies', error);
      },
    });
  }

  onClick() {
    console.log(this.powerSupplies);
  }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiUrl + 'all');
  }
}
