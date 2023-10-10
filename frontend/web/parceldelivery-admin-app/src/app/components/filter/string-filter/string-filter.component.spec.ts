import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StringFilterComponent } from './string-filter.component';

describe('StringFilterComponent', () => {
  let component: StringFilterComponent;
  let fixture: ComponentFixture<StringFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StringFilterComponent]
    });
    fixture = TestBed.createComponent(StringFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
