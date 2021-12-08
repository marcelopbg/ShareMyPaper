import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstitutionFormComponent } from './institution-form.component';

describe('InstitutionFormComponent', () => {
  let component: InstitutionFormComponent;
  let fixture: ComponentFixture<InstitutionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InstitutionFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InstitutionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
