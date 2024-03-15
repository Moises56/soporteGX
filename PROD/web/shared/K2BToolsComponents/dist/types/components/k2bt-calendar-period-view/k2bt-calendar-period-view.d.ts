import { EventEmitter } from '../../stencil-public-runtime';
import { Calendar, CalendarItem } from '../../utils/utils';
export declare class K2btCalendarPeriodView {
  calendars: Calendar[];
  startHour: number;
  endHour: number;
  dateFrom: Date;
  dateTo: Date;
  readonly: boolean;
  draftItemDescription: string;
  draftItem: CalendarItem;
  dayComponents: HTMLK2btCalendarDayViewElement[];
  newDraftCreated: EventEmitter<object>;
  draftCanceled: EventEmitter<object>;
  itemClicked: EventEmitter<object>;
  onDayViewDraftCancelled(): void;
  onCreatingNewDraft(event: any): Promise<void>;
  cancelDraft(): Promise<void>;
  render(): any;
}
