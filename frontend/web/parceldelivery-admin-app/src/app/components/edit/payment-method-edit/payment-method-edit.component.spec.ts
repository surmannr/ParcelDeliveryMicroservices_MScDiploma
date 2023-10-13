import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentMethodEditComponent } from './payment-method-edit.component';

describe('PaymentMethodEditComponent', () => {
  let component: PaymentMethodEditComponent;
  let fixture: ComponentFixture<PaymentMethodEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaymentMethodEditComponent]
    });
    fixture = TestBed.createComponent(PaymentMethodEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
