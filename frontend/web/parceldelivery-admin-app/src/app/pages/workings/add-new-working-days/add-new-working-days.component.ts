import { Component, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { TimesheetDto } from 'src/app/_dtos/timesheet-dto';
import { TimesheetService } from 'src/app/apiservices/timesheet.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';
import { Day } from 'src/app/models/Day';

@Component({
  selector: 'app-add-new-working-days',
  templateUrl: './add-new-working-days.component.html',
  styleUrls: ['./add-new-working-days.component.css'],
})
export class AddNewWorkingDaysComponent implements OnInit {
  availableDays: Day[] = [];
  selectedDays: number[] = [];

  firstDate: Date = new Date();
  lastDate: Date = new Date();

  note = '';

  weekStart: number = 1;

  constructor(
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private timesheetService: TimesheetService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.selectedDays = [];
    this.availableDays = this.getWeekDays('hu-HU');
  }

  nextWeek() {
    this.weekStart = this.weekStart + 7;
    this.ngOnInit();
  }

  previousWeek() {
    this.weekStart = this.weekStart - 7;
    this.ngOnInit();
  }

  getWeekDays(locale: string) {
    var baseDate = new Date();
    baseDate.setDate(baseDate.getDate() - baseDate.getDay() + this.weekStart);

    var weekDays = [];
    for (let i = 0; i < 7; i++) {
      weekDays.push(
        new Day({
          id: i,
          name: `${baseDate.toLocaleDateString(locale, {
            weekday: 'long',
          })} (${baseDate.toLocaleDateString(locale)})`,
        })
      );
      if (i === 0) {
        this.firstDate = new Date(baseDate);
      }
      if (i === 6) {
        this.lastDate = new Date(baseDate);
      }
      baseDate.setDate(baseDate.getDate() + 1);
    }
    return weekDays;
  }

  save() {
    const timesheet: TimesheetDto = {
      id: '',
      dateFrom: this.firstDate,
      dateTo: this.lastDate,
      note: this.note,
      days: this.selectedDays,
      userId: '',
    };
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        console.log(timesheet);
        this.timesheetService.saveTimesheet(timesheet).subscribe({
          next: () => {},
          error: () => {
            this.snackBar.open(
              'Nem sikerült felvenned a munkahetet.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
          complete: () => {
            this.snackBar.open('Sikeresen felvetted a munkahetet.', 'Értem', {
              duration: 3000,
            });
            this.router.navigate(['/timesheet']);
          },
        });
      }
    });
  }
}
