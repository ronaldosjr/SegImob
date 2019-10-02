import {Component} from '@angular/core';
import {ActivatedRoute, NavigationStart, Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private activatedRouter: ActivatedRoute,
              private router: Router) {
      this.router.events.subscribe((evt) => {
        if (evt instanceof NavigationStart && evt.url === '/') {
          this.router.navigate(['/dashboard']);
        }
      });
  }
}
