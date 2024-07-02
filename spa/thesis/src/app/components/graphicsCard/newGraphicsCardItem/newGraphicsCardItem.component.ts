import { Component, EventEmitter, OnInit, Output, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NewGraphicsCard } from '../../../_models/graphicsCard.model';

@Component({
  selector: 'app-newGraphicsCardItem',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './newGraphicsCardItem.component.html',
  styleUrls: ['./newGraphicsCardItem.component.css'],
})
export class NewGraphicsCardItemComponent {
  @Output() cancel = new EventEmitter<void>();
  @Output() add = new EventEmitter<NewGraphicsCard>();
  enteredMake = '';
  enteredModel = '';
  enteredVersion = '';

  onCancel() {
    this.cancel.emit();
  }

  onSubmit() {
    this.add.emit({
      make: this.enteredMake,
      model: this.enteredModel,
      version: this.enteredVersion,
    });
  }
}
