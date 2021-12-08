import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Alert } from './alert.model';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  private alertSubject: BehaviorSubject<Alert | null>;
  public currentAlert: Observable<Alert | null>;

  constructor() {
    this.alertSubject = new BehaviorSubject<Alert | null>(null);
    this.currentAlert = this.alertSubject.asObservable();
  }
  showToast(alert: Alert): void {
    this.alertSubject.next(alert)
  }
}
