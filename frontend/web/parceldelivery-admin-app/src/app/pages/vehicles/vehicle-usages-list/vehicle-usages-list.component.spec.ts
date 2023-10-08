import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleUsagesListComponent } from './vehicle-usages-list.component';

describe('VehicleUsagesListComponent', () => {
  let component: VehicleUsagesListComponent;
  let fixture: ComponentFixture<VehicleUsagesListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleUsagesListComponent]
    });
    fixture = TestBed.createComponent(VehicleUsagesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
