import { Component, Input, OnInit } from '@angular/core';
import { Computer } from './../../../_models/computer.model'

@Component({
  selector: 'app-computerItem',
  standalone: true,
  templateUrl: './computerItem.component.html',
  styleUrls: ['./computerItem.component.css'],
})
export class ComputerItemComponent {
  @Input({ required: true }) computer!: Computer;

}
