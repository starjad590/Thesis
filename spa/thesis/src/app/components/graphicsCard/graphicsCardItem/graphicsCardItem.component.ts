import { Component, Input } from '@angular/core';
import { GraphicsCard } from '../../../_models/graphicsCard.model';
import { EditGraphicsCardItemComponent } from '../editGraphicsCardItem/editGraphicsCardItem.component';

@Component({
  selector: 'app-graphicsCardItem',
  standalone: true,
  templateUrl: './graphicsCardItem.component.html',
  styleUrls: ['./graphicsCardItem.component.css'],
  imports: [EditGraphicsCardItemComponent],
})
export class GraphicsCardItemComponent {
  @Input({ required: true }) graphicsCard!: GraphicsCard;

  isEdit: boolean = false;

  onClick() {
    this.isEdit = true;
  }

  onCancelEditGraphicsCard() {
    this.isEdit = false;
  }

  onUpdate(event: GraphicsCard){

  }
}
