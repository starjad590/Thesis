import { Component, Input } from '@angular/core';
import { ComputerComponent } from '../computer/computer.component';
import { GraphicsCardComponent } from '../graphicsCard/graphicsCard.component';
import { PowerSupplyComponent } from "../powerSupply/powerSupply.component";
import { ProcessorComponent } from "../processor/processor.component";
import { RamComponent } from "../ram/ram.component";
import { StorageComponent } from "../storage/storage.component";

@Component({
    selector: 'app-partContainer',
    standalone: true,
    templateUrl: './partContainer.component.html',
    styleUrls: ['./partContainer.component.css'],
    imports: [ComputerComponent, GraphicsCardComponent, PowerSupplyComponent, ProcessorComponent, RamComponent, StorageComponent]
})
export class PartContainerComponent {
  @Input({ required: true }) pageName!: string;
}
