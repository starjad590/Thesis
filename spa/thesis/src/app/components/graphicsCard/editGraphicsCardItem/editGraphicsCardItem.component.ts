import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { GraphicsCard } from '../../../_models/graphicsCard.model';

@Component({
  selector: 'app-editGraphicsCardItem',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './editGraphicsCardItem.component.html',
  styleUrls: ['./editGraphicsCardItem.component.css'],
})
export class EditGraphicsCardItemComponent {
  @Output() cancel = new EventEmitter<void>();
  @Output() update = new EventEmitter<GraphicsCard>();
  @Input({ required: true }) id!: string;
  @Input({ required: true }) enteredMake!: string;
  @Input({ required: true }) enteredModel!: string;
  @Input({ required: true }) enteredVersion!: string;

  onCancel() {
    this.cancel.emit();
  }

  onSubmit() {
    this.update.emit({
      id: this.id,
      make: this.enteredMake,
      model: this.enteredModel,
      version: this.enteredVersion,
    });
  }
}
