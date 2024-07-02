import { Component, Input } from '@angular/core';
import { Storage } from '../../../_models/storage.model';

@Component({
  selector: 'app-storageItem',
  standalone: true,
  templateUrl: './storageItem.component.html',
  styleUrls: ['./storageItem.component.css'],
})
export class StorageItemComponent {
  @Input({ required: true }) storage!: Storage;
}
