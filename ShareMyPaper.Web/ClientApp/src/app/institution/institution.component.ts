import { Component, OnInit } from '@angular/core';
import { faPencilAlt, faPlus, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from '../auth/auth.service';
import { IUser } from '../auth/model/user.model';
import { IInstitution } from '../model/institution.model';
import { InstitutionService } from '../services/institution.service';

@Component({
  selector: 'app-institution',
  templateUrl: './institution.component.html',
  styleUrls: ['./institution.component.css']
})
export class InstitutionComponent implements OnInit {
  faPlus = faPlus;
  faPencilAlt = faPencilAlt;
  faTrashAlt = faTrashAlt;
  institutions: IInstitution[] = [];

  selectedInstitution?: IInstitution;
  currentUser?: IUser;
  
  deleteModalRef = '#confirmDeletionModalRef'
  createAndEditModalRef = '#createAndEditModalRef'

  constructor(
    private institutionService: InstitutionService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.load();
  }
  load(): void {
    this.authService.currentUser.subscribe(user => this.currentUser = user!);
    this.selectedInstitution = undefined;
    this.institutionService.getInstitutions().subscribe(r => this.institutions = r)
  }
  setSelectedInstitution(institution?: IInstitution): void {
    this.selectedInstitution = institution;
  }

  reloadInstitutions(): void {
    this.load();
  }
}
