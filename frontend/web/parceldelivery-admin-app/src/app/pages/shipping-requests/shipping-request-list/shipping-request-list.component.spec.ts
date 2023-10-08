import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingRequestListComponent } from './shipping-request-list.component';

describe('ShippingRequestListComponent', () => {
  let component: ShippingRequestListComponent;
  let fixture: ComponentFixture<ShippingRequestListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShippingRequestListComponent]
    });
    fixture = TestBed.createComponent(ShippingRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
