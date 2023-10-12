import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NumberFilterComponent } from './number-filter.component';

describe('NumberFilterComponent', () => {
  let component: NumberFilterComponent;
  let fixture: ComponentFixture<NumberFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NumberFilterComponent]
    });
    fixture = TestBed.createComponent(NumberFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
