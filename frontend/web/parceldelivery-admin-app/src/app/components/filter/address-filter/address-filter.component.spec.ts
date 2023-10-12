import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressFilterComponent } from './address-filter.component';

describe('AddressFilterComponent', () => {
  let component: AddressFilterComponent;
  let fixture: ComponentFixture<AddressFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddressFilterComponent]
    });
    fixture = TestBed.createComponent(AddressFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
