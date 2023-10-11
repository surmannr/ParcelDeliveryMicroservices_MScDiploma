import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteDialogSheetComponent } from './delete-dialog-sheet.component';

describe('DeleteDialogSheetComponent', () => {
  let component: DeleteDialogSheetComponent;
  let fixture: ComponentFixture<DeleteDialogSheetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteDialogSheetComponent]
    });
    fixture = TestBed.createComponent(DeleteDialogSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
