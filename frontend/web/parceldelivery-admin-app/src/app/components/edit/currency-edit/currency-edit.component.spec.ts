import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyEditComponent } from './currency-edit.component';

describe('CurrencyEditComponent', () => {
  let component: CurrencyEditComponent;
  let fixture: ComponentFixture<CurrencyEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurrencyEditComponent]
    });
    fixture = TestBed.createComponent(CurrencyEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
