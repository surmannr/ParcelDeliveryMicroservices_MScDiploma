import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewWorkingDaysComponent } from './add-new-working-days.component';

describe('AddNewWorkingDaysComponent', () => {
  let component: AddNewWorkingDaysComponent;
  let fixture: ComponentFixture<AddNewWorkingDaysComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewWorkingDaysComponent]
    });
    fixture = TestBed.createComponent(AddNewWorkingDaysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
