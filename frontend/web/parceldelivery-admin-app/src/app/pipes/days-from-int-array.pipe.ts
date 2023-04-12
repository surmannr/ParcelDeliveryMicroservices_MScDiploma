import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'daysFromIntArray',
})
export class DaysFromIntArrayPipe implements PipeTransform {
  days: string[] = [
    'hétfő',
    'kedd',
    'szerda',
    'csütörtök',
    'péntek',
    'szombat',
    'vasárnap',
  ];

  transform(value: number[]): string {
    let resultArrays: string[] = [];
    for (let i = 0; i < value.length; i++) {
      resultArrays.push(this.days[value[i]]);
    }
    return resultArrays.join(', ');
  }
}
