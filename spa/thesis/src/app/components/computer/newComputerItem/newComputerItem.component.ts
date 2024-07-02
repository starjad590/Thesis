import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-newComputerItem',
  standalone: true,
  templateUrl: './newComputerItem.component.html',
  styleUrls: ['./newComputerItem.component.css'],
})
export class NewComputerItemComponent {
  @Output() cancel = new EventEmitter<void>();
  enteredGCard = '';

  onCancel() {
    this.cancel.emit();
  }
}
