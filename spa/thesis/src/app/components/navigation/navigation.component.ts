import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss',
})
export class NavigationComponent {
  @Output() select = new EventEmitter<string>();
  
  onComputerClick() {
    this.select.emit('Computers');
  }

  onGraphicsCardsClick() {
    this.select.emit('GraphicsCards');
  }

  onPowerSupplyClick() {
    this.select.emit('PowerSupply');
  }

  onProcessorClick() {
    this.select.emit('Processor');
  }

  onRAMClick() {
    this.select.emit('RAM');
  }

  onStorageClick() {
    this.select.emit('Storage');
  }
}
