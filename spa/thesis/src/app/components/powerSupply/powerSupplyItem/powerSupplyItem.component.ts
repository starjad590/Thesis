import { Component, Input } from '@angular/core';
import { PowerSupply } from '../../../_models/powerSupply.model';

@Component({
  selector: 'app-powerSupplyItem',
  standalone: true,
  templateUrl: './powerSupplyItem.component.html',
  styleUrls: ['./powerSupplyItem.component.css'],
})
export class PowerSupplyItemComponent {
  @Input({ required: true }) powerSupply!: PowerSupply;
}
