export class DateUtils {
  static equalsDate(date1, date2) {
    return date1.getFullYear() === date2.getFullYear() && date1.getMonth() === date2.getMonth() && date1.getDate() === date2.getDate();
  }
  static getDayOfWeekShortStringFromDayNumber(number) {
    //@ts-ignore
    return k2btools.getDayOfWeekShortStringFromDayNumber(number);
  }
  static getDayOfWeekShortString(day) {
    //@ts-ignore
    return k2btools.getDayOfWeekShortString(day);
  }
  static getMonthName(monthNumber) {
    //@ts-ignore
    return k2btools.getMonthName(monthNumber);
  }
  static getDateAtMidnight(date) {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate(), 0, 0, 0);
  }
  static datePeriodInBound(lowerBound, upperBound, periodFrom, periodTo) {
    return ((lowerBound <= periodFrom && upperBound >= periodFrom) ||
      (lowerBound <= periodTo && upperBound >= periodTo) ||
      (periodFrom <= lowerBound && periodTo >= lowerBound) ||
      (periodFrom <= upperBound && periodTo >= upperBound));
  }
  static formatItemDate(dateFrom) {
    if (dateFrom.getMinutes() !== 0)
      return dateFrom.getHours() + ':' + this.ensureTwoDigits(dateFrom.getMinutes());
    else
      return dateFrom.getHours();
  }
  static ensureTwoDigits(arg0) {
    if (arg0 < 10)
      return '0' + arg0;
    else
      return arg0.toString();
  }
  static getWeeksOfMonth(year, month, weekstartday) {
    const firstDayOfMonth = new Date(year, month - 1, 1);
    const lastDayOfMonth = new Date(year, month, 0);
    var startOfFirstWeek = new Date(firstDayOfMonth.getTime());
    if (weekstartday == WeekStartDay.Sunday) {
      startOfFirstWeek.setDate(firstDayOfMonth.getDate() - firstDayOfMonth.getDay());
    }
    else {
      startOfFirstWeek.setDate(firstDayOfMonth.getDate() - firstDayOfMonth.getDay() + 1);
    }
    var endOfLastWeek = new Date(lastDayOfMonth.getTime());
    if (weekstartday == WeekStartDay.Sunday) {
      endOfLastWeek.setDate(lastDayOfMonth.getDate() - lastDayOfMonth.getDay() + 7);
    }
    else {
      endOfLastWeek.setDate(lastDayOfMonth.getDate() - lastDayOfMonth.getDay() + 8);
    }
    const weeks = [];
    var day = new Date(startOfFirstWeek.getTime());
    while (day < endOfLastWeek) {
      if ((weekstartday == WeekStartDay.Sunday && day.getDay() === 0) || (weekstartday == WeekStartDay.Monday && day.getDay() === 1)) {
        weeks.push([]);
      }
      weeks[weeks.length - 1].push(day);
      day = new Date(day.getTime());
      day.setDate(day.getDate() + 1);
    }
    return weeks;
  }
}
export var CalendarPeriodView;
(function (CalendarPeriodView) {
  CalendarPeriodView["Day"] = "day";
  CalendarPeriodView["Week"] = "week";
  CalendarPeriodView["WorkWeek"] = "workweek";
  CalendarPeriodView["Month"] = "month";
})(CalendarPeriodView || (CalendarPeriodView = {}));
export var WeekStartDay;
(function (WeekStartDay) {
  WeekStartDay["Sunday"] = "Sunday";
  WeekStartDay["Monday"] = "Monday";
})(WeekStartDay || (WeekStartDay = {}));
