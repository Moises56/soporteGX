export declare class DateUtils {
  static equalsDate(date1: Date, date2: Date): boolean;
  static getDayOfWeekShortStringFromDayNumber(number: any): any;
  static getDayOfWeekShortString(day: Date): any;
  static getMonthName(monthNumber: number): any;
  static getDateAtMidnight(date: Date): Date;
  static datePeriodInBound(lowerBound: Date, upperBound: Date, periodFrom: Date, periodTo: Date): boolean;
  static formatItemDate(dateFrom: Date): string | number;
  private static ensureTwoDigits;
  static getWeeksOfMonth(year: number, month: number, weekstartday: WeekStartDay): Date[][];
}
export declare enum CalendarPeriodView {
  Day = "day",
  Week = "week",
  WorkWeek = "workweek",
  Month = "month"
}
export declare enum WeekStartDay {
  Sunday = "Sunday",
  Monday = "Monday"
}
