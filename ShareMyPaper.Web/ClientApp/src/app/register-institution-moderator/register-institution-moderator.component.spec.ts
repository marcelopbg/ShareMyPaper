import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterInstitutionModeratorComponent } from './register-institution-moderator.component';

describe('RegisterInstitutionModeratorComponent', () => {
  let component: RegisterInstitutionModeratorComponent;
  let fixture: ComponentFixture<RegisterInstitutionModeratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterInstitutionModeratorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterInstitutionModeratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
