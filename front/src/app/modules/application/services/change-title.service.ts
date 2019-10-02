import {Injectable} from '@angular/core';
import {DashboardComponent} from '../pages/dashboard/dashboard.component';

@Injectable({
  providedIn: 'root'
})
export class ChangeTitleService {

  dashboard: DashboardComponent;

  setDashboard(dashboard: DashboardComponent) {
    this.dashboard = dashboard;
  }

  changeTitle(newTitle: string) {
    if (!this.dashboard) {
      throw new Error('kkkk se fudeu');
    }

    if (!this.dashboard.showTitleBar) {
      this.show();
    }

    this.dashboard.setTitle(newTitle);
  }

  toggle() {
    this.dashboard.showTitleBar = !this.dashboard.showTitleBar;
  }

  hide() {
    this.dashboard.showTitleBar = false;
  }

  show() {
    this.dashboard.showTitleBar = true;
  }

  constructor() {
  }
}
