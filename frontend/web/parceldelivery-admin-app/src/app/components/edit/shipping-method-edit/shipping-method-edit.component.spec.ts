import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingMethodEditComponent } from './shipping-method-edit.component';

describe('ShippingMethodEditComponent', () => {
  let component: ShippingMethodEditComponent;
  let fixture: ComponentFixture<ShippingMethodEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShippingMethodEditComponent]
    });
    fixture = TestBed.createComponent(ShippingMethodEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
