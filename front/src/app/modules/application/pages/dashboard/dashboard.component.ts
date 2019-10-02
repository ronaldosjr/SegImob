import {Component} from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {ChangeTitleService} from '../../services/change-title.service';
import {Router} from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  titulozao = '';

  showTitleBar = true;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver,
              private changeTitle: ChangeTitleService,
              private router: Router) {
    this.changeTitle.setDashboard(this);
  }

  setTitle(newTitle: string) {

    if (!newTitle || newTitle == null) {
      this.titulozao = '';
    } else {
      this.titulozao = newTitle;
    }
  }
}
