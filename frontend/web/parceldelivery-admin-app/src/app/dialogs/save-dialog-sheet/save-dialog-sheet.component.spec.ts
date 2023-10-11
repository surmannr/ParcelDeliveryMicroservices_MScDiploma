import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveDialogSheetComponent } from './save-dialog-sheet.component';

describe('SaveDialogSheetComponent', () => {
  let component: SaveDialogSheetComponent;
  let fixture: ComponentFixture<SaveDialogSheetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaveDialogSheetComponent]
    });
    fixture = TestBed.createComponent(SaveDialogSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
