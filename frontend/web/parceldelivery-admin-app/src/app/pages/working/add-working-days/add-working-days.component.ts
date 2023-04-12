import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Day } from 'src/app/models/Day';

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

  weekStart: number = 1;

  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService
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
        this.messageService.add({
          severity: 'info',
          summary: 'Felvéve',
          detail: 'Sikeresen felvetted a munkahetet.',
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
