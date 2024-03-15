class ControlInfoValue {
  static getAtomicValues_impl(values) {
    var _a;
    return (_a = values === null || values === void 0 ? void 0 : values.map(value => { var _a; return (((_a = value.items) === null || _a === void 0 ? void 0 : _a.length) > 0 ? ControlInfoValue.getAtomicValues_impl(value.items) : [value]); }).reduce((a, b) => a.concat(b), [])) !== null && _a !== void 0 ? _a : [];
  }
  static containsDetails(values) {
    var _a;
    return (_a = (values === null || values === void 0 ? void 0 : values.filter(value => value.detail != '' && value.detail != undefined).length) != 0) !== null && _a !== void 0 ? _a : false;
  }
  static containsIcons(values) {
    var _a;
    return (_a = (values === null || values === void 0 ? void 0 : values.filter(value => value.imageUrl != '' && value.imageUrl != undefined).length) != 0) !== null && _a !== void 0 ? _a : false;
  }
  static containsTrailingText(values) {
    var _a;
    return (_a = (values === null || values === void 0 ? void 0 : values.filter(value => value.trailingText != '' && value.trailingText != undefined).length) != 0) !== null && _a !== void 0 ? _a : false;
  }
  static containsBadges(values) {
    var _a;
    return (_a = (values === null || values === void 0 ? void 0 : values.filter(value => value.badgeClass != '' && value.badgeClass != undefined).length) != 0) !== null && _a !== void 0 ? _a : false;
  }
}
class ImageRegion {
}
ImageRegion.AVAILABLE = 'AVAILABLE';
ImageRegion.UNAVAILABLE = 'UNAVAILABLE';
class CalendarItem {
  constructor() {
    this.isDraft = false;
  }
  static calendarItemsCollide(item1, item2) {
    var first = item1.dateFrom < item2.dateFrom ? item1 : item2;
    var second = first == item1 ? item2 : item1;
    return second.dateFrom < first.dateTo;
  }
  static isInDay(i, dateFrom, dateTo) {
    // Check if event should be shown on this day
    return ((dateFrom <= i.dateFrom && dateTo > i.dateFrom) ||
      (dateFrom <= i.dateTo && dateTo > i.dateTo) || // Option 1: event starts or ends in this day
      (i.dateFrom < dateFrom && i.dateTo > dateTo) // Option 2: events starts before and ends after this day
    );
  }
  static allDayItemIsInDay(i, day) {
    var from = new Date(day.getFullYear(), day.getMonth(), day.getDate(), 0, 0, 0);
    var to = new Date(day.getFullYear(), day.getMonth(), day.getDate() + 1, 0, 0, 0);
    return this.isInDay(i, from, to);
  }
  static itemIsInPast(item, currentDate) {
    return !item.allDay ? item.dateFrom < currentDate && item.dateTo < currentDate : currentDate > item.dateTo && !this.allDayItemIsInDay(item, currentDate);
  }
  static addItemClasses(classList, item, currentDate) {
    if (item.isDraft)
      classList.push('K2BT_CalendarDayItemDraft');
    if (item.class)
      classList.push(item.class);
    if (CalendarItem.itemIsInPast(item, currentDate))
      classList.push(' K2BT_CalendarDayItemPast');
  }
}
class EnumUtils {
  static getEnumKeyByEnumValue(myEnum, enumValue) {
    let keys = Object.keys(myEnum).filter(x => myEnum[x] == enumValue);
    return keys.length > 0 ? keys[0] : null;
  }
}
class LanguageUtils {
  static getTranslatedMessage(msg) {
    //@ts-ignore
    return k2btools.getTranslatedMessage(msg);
  }
}

export { CalendarItem as C, EnumUtils as E, ImageRegion as I, LanguageUtils as L, ControlInfoValue as a };
