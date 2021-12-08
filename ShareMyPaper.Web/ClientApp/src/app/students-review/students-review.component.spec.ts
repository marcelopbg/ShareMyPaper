import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentsReviewComponent } from './students-review.component';

describe('StudentsReviewComponent', () => {
  let component: StudentsReviewComponent;
  let fixture: ComponentFixture<StudentsReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentsReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentsReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
