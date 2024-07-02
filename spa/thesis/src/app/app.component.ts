import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./components/header/header.component";
import { NavigationComponent } from "./components/navigation/navigation.component";
import { PartContainerComponent } from './components/partContainer/partContainer.component';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, HeaderComponent, NavigationComponent, PartContainerComponent]
})
export class AppComponent {
  title = 'thesis';
  page: string = 'Computers';

  onSelectButton(page: string) {
    this.page = page;
  }
}
