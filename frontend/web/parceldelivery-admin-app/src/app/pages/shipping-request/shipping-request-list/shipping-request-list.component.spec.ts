import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingRequestListComponent } from './shipping-request-list.component';

describe('ShippingRequestListComponent', () => {
  let component: ShippingRequestListComponent;
  let fixture: ComponentFixture<ShippingRequestListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippingRequestListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippingRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
