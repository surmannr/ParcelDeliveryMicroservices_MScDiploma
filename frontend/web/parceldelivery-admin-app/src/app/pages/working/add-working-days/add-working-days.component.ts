import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { TimesheetDto } from 'src/app/_dtos/timesheet-dto';
import { Day } from 'src/app/models/Day';
import { Timesheet } from 'src/app/models/Timesheet';
import { EmployeeService } from 'src/app/services/api/employee.service';

@Component({
  selector: 'app-add-working-days',
  templateUrl: './add-working-days.component.html',
  styleUrls: ['./add-working-days.component.scss'],
})
export class AddWorkingDaysComponent implements OnInit {
  availableDays: Day[] = [];
  selectedDays: Day[] = [];
  draggedDay: Day | null = null;

  firstDate: Date = new Date();
  lastDate: Date = new Date();

  note = '';

  weekStart: number = 1;

  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.selectedDays = [];
    this.availableDays = this.getWeekDays('hu-HU');
  }

  save(event: Event) {
    this.confirmationService.confirm({
      target: event.target!,
      message: 'Biztos vagy benne, hogy felveszed a munkahetet?',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Igen',
      rejectLabel: 'Nem',
      accept: () => {
        const timesheet: TimesheetDto = {
          id: '',
          dateFrom: this.firstDate,
          dateTo: this.lastDate,
          note: this.note,
          days: this.selectedDays.map((x) => x.id!),
          userId: '',
        };
        this.employeeService.saveTimesheet(timesheet).subscribe({
          next: () => {},
          error: () => {
            this.messageService.add({
              severity: 'error',
              summary: 'Hiba',
              detail: 'Nem sikerült felvenned a munkahetet.',
            });
          },
          complete: () => {
            this.messageService.add({
              severity: 'info',
              summary: 'Felvéve',
              detail: 'Sikeresen felvetted a munkahetet.',
            });
            this.router.navigate(['/timesheet']);
          },
        });
      },
      reject: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Mégse',
          detail: 'Visszaléptél a munkahét mentése során.',
        });
      },
    });
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

  nextWeek() {
    this.weekStart = this.weekStart + 7;
    this.ngOnInit();
  }

  previousWeek() {
    this.weekStart = this.weekStart - 7;
    this.ngOnInit();
  }

  dragStart(day: Day) {
    this.draggedDay = day;
  }

  drop() {
    if (this.draggedDay) {
      let draggedDayIndex = this.availableDays.indexOf(this.draggedDay);
      this.selectedDays = [...this.selectedDays, this.draggedDay];
      this.availableDays = this.availableDays.filter(
        (val, i) => i != draggedDayIndex
      );
      this.draggedDay = null;
    }
  }

  dragEnd() {
    this.draggedDay = null;
  }
}
