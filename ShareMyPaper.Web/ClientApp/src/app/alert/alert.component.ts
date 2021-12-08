import { Component, OnInit } from '@angular/core';
import { Alert } from './alert.model';
import { ToastService } from './toast.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit {
  
  alert: Alert | null = null;
  delay = 8000;
  timeoutRef: any; 

  constructor(private toastService: ToastService) { }

  ngOnInit(): void {
    this.toastService.currentAlert.subscribe(r => {
      this.dismiss();
      this.alert = r!;
      this.timeoutRef = setTimeout(() => {
        this.dismiss();
      }, this.delay);
    });
  }
  dismiss(): void {
    this.alert = null;
    clearTimeout(this.timeoutRef);
  }
}
