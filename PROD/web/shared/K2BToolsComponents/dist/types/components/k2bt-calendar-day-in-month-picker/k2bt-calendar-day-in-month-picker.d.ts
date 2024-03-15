import { EventEmitter } from '../../stencil-public-runtime';
import { WeekStartDay } from '../../utils/dateutils';
export declare class K2btCalendarDayInMonthPicker {
  selectedDate: Date;
  weekstartday: WeekStartDay;
  currentMonth: number;
  currentYear: number;
  dayClicked: EventEmitter<Date>;
  componentWillRender(): void;
  render(): any;
  previousMonth(): void;
  nextMonth(): void;
  updateSelectedDate(): void;
  dayClickHandler(date: Date): void;
}
