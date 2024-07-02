import { Component, Input } from '@angular/core';
import { Processor } from '../../../_models/processor.model';

@Component({
  selector: 'app-processorItem',
  standalone: true,
  templateUrl: './processorItem.component.html',
  styleUrls: ['./processorItem.component.css'],
})
export class ProcessorItemComponent {
  @Input({ required: true }) processor!: Processor;
}
