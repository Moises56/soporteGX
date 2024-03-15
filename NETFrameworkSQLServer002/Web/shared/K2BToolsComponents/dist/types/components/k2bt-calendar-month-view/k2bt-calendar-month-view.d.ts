import { EventEmitter } from '../../stencil-public-runtime';
import { WeekStartDay } from '../../utils/dateutils';
import { Calendar, CalendarItem } from '../../utils/utils';
export declare class K2btCalendarMonthView {
  year: number;
  month: number;
  readonly: boolean;
  calendars: Calendar[];
  seemorecaption: string;
  itemsperday: number;
  weekstartday: WeekStartDay;
  currentDate: Date;
  intervalId: any;
  dayClicked: EventEmitter<object>;
  itemClicked: EventEmitter<object>;
  actionClicked: EventEmitter<object>;
  onItemClicked(item: CalendarItem): void;
  onActionClicked(item: CalendarItem, actionId: string): void;
  render(): any;
  private getClassesForNumberContainer;
  private getClassesForDayContainer;
  private getFilteredAppointments;
  componentDidLoad(): void;
  disconnectedCallback(): void;
  onDayClicked(day: any): void;
}
