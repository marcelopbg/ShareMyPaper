export enum Severity {
  success = 'success',
  info = 'info',
  warning = 'warning',
  danger = 'danger'
}
export interface Alert {
  message: string;
  severity: Severity;
}