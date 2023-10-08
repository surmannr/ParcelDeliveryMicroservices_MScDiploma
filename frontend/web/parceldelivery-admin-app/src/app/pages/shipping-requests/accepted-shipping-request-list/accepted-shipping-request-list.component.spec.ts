import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptedShippingRequestListComponent } from './accepted-shipping-request-list.component';

describe('AcceptedShippingRequestListComponent', () => {
  let component: AcceptedShippingRequestListComponent;
  let fixture: ComponentFixture<AcceptedShippingRequestListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AcceptedShippingRequestListComponent]
    });
    fixture = TestBed.createComponent(AcceptedShippingRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
