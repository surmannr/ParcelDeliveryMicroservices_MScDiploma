import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleUsageListComponent } from './vehicle-usage-list.component';

describe('VehicleUsageListComponent', () => {
  let component: VehicleUsageListComponent;
  let fixture: ComponentFixture<VehicleUsageListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicleUsageListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleUsageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
