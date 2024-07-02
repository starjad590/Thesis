import { Component, Input } from '@angular/core';
import { RAM } from '../../../_models/ram.model';

@Component({
  selector: 'app-ramItem',
  standalone: true,
  templateUrl: './ramItem.component.html',
  styleUrls: ['./ramItem.component.css'],
})
export class RamItemComponent {
  @Input({ required: true }) ram!: RAM;
}
