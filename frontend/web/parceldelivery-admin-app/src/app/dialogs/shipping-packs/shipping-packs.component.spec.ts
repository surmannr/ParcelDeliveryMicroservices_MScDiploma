import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingPacksComponent } from './shipping-packs.component';

describe('ShippingPacksComponent', () => {
  let component: ShippingPacksComponent;
  let fixture: ComponentFixture<ShippingPacksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShippingPacksComponent]
    });
    fixture = TestBed.createComponent(ShippingPacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
