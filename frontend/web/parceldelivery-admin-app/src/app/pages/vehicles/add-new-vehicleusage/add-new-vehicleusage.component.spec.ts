import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewVehicleusageComponent } from './add-new-vehicleusage.component';

describe('AddNewVehicleusageComponent', () => {
  let component: AddNewVehicleusageComponent;
  let fixture: ComponentFixture<AddNewVehicleusageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewVehicleusageComponent]
    });
    fixture = TestBed.createComponent(AddNewVehicleusageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
