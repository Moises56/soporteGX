export declare class ControlInfoValue {
  value: string;
  description: string;
  imageUrl: string;
  detail: string;
  trailingText: string;
  badgeClass: string;
  items: Array<ControlInfoValue>;
  static getAtomicValues_impl(values: Array<ControlInfoValue>): Array<ControlInfoValue>;
  static containsDetails(values: Array<ControlInfoValue>): boolean;
  static containsIcons(values: Array<ControlInfoValue>): boolean;
  static containsTrailingText(values: Array<ControlInfoValue>): boolean;
  static containsBadges(values: Array<ControlInfoValue>): boolean;
}
export declare class ImageWithRegionsDefinition {
  Regions: ImageRegion[];
  Frame: ImageFrameDefinition;
}
export declare class ImageFrameDefinition {
  class: string;
  backgroundImageURL: string;
  height: string;
  width: string;
}
export declare class ImageRegion {
  id: string;
  name: string;
  tooltipLines: Array<string>;
  status: string;
  top: string;
  left: string;
  height: string;
  width: string;
  class: string;
  availableImageURL: string;
  unavailableImageURL: string;
  selectedImageURL: string;
  selectableRegionCoordinates: string;
  static readonly AVAILABLE: string;
  static readonly UNAVAILABLE: string;
}
export declare class BaseColorOption {
  id: string;
  description: string;
  colorCode: string;
}
export declare class Calendar {
  id: string;
  description: string;
  class: string;
  items: CalendarItem[];
}
export declare class CalendarItem {
  id: string;
  description: string;
  dateFrom: Date;
  dateTo: Date;
  allDay: boolean;
  class: string;
  calendarId: string;
  isDraft: boolean;
  actions: CalendarItemAction[];
  static calendarItemsCollide(item1: CalendarItem, item2: CalendarItem): boolean;
  static isInDay(i: CalendarItem, dateFrom: Date, dateTo: Date): boolean;
  static allDayItemIsInDay(i: CalendarItem, day: Date): boolean;
  static itemIsInPast(item: CalendarItem, currentDate: Date): boolean;
  static addItemClasses(classList: string[], item: CalendarItem, currentDate: Date): void;
}
export declare class CalendarItemAction {
  id: string;
  name: string;
  imageUrl: string;
  imageName: string;
}
export declare class SetPeriodAppointmentsParms {
  dateFrom: Date;
  dateTo: Date;
  calendars: Calendar[];
}
export declare class EnumUtils {
  static getEnumKeyByEnumValue<T extends {
    [index: string]: string;
  }>(myEnum: T, enumValue: string): keyof T | null;
}
export declare class LanguageUtils {
  static getTranslatedMessage(msg: string): any;
}
