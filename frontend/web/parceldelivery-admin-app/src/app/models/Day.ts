export class Day {
  public id?: number;
  public name?: string;

  public constructor(init?: Partial<Day>) {
    Object.assign(this, init);
  }
}
