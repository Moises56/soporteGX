import { Component, Event, h, Prop } from '@stencil/core';
import { DateUtils, WeekStartDay } from '../../utils/dateutils';
export class K2btCalendarDayInMonthPicker {
  constructor() {
    this.weekstartday = WeekStartDay.Sunday;
  }
  componentWillRender() {
    this.currentMonth = this.selectedDate.getMonth();
    this.currentYear = this.selectedDate.getFullYear();
  }
  render() {
    const currentDate = new Date();
    const monthName = DateUtils.getMonthName(this.currentMonth);
    const weeks = DateUtils.getWeeksOfMonth(this.currentYear, this.currentMonth + 1, this.weekstartday);
    const firstDayOfMonth = new Date(this.currentYear, this.currentMonth, 1);
    const lastDayOfMonth = new Date(this.currentYear, this.currentMonth + 1, 0);
    return (h("div", { class: "K2BT_CalendarPickerContainer" },
      h("div", { class: "K2BT_CalendarPickerHeader" },
        h("div", { class: "K2BT_CalendarPickerPreviousMonth", onClick: () => this.previousMonth() }),
        h("div", { class: "K2BT_CalendarPickerCurrentMonth" },
          monthName,
          " ",
          this.currentYear),
        h("div", { class: "K2BT_CalendarPickerNextMonth", onClick: () => this.nextMonth() })),
      h("div", { class: "K2BT_CalendarPickerWeekdays" }, weeks[0]
        .map(d => d.getDay())
        .map(weekdayNum => (h("div", { class: "K2BT_CalendarPickerWeekday" }, DateUtils.getDayOfWeekShortStringFromDayNumber(weekdayNum))))),
      h("div", { class: "K2BT_CalendarPickerCalendar" }, weeks.map(week => (h("div", { class: "K2BT_CalendarPickerWeek" }, week.map(date => {
        const dayClass = DateUtils.equalsDate(date, currentDate) ? 'K2BT_CalendarPickerDay K2BT_CalendarPickerToday' : 'K2BT_CalendarPickerDay';
        return date >= firstDayOfMonth && date <= lastDayOfMonth ? (h("div", { class: dayClass, onClick: () => this.dayClickHandler(date) }, date.getDate())) : (h("div", { class: "K2BT_CalendarPickerDayPlaceholder" }));
      })))))));
  }
  previousMonth() {
    if (this.currentMonth == 0) {
      this.currentMonth = 11;
      this.currentYear = this.currentYear - 1;
    }
    else {
      this.currentMonth = this.currentMonth - 1;
    }
    this.updateSelectedDate();
  }
  nextMonth() {
    if (this.currentMonth == 11) {
      this.currentMonth = 0;
      this.currentYear = this.currentYear + 1;
    }
    else {
      this.currentMonth = this.currentMonth + 1;
    }
    this.updateSelectedDate();
  }
  updateSelectedDate() {
    this.selectedDate = new Date(this.currentYear, this.currentMonth, 1, 0, 0, 0);
  }
  dayClickHandler(date) {
    if (!date)
      return; // Ignore clicks on empty days
    this.dayClicked.emit(date);
  }
  static get is() { return "k2bt-calendar-day-in-month-picker"; }
  static get properties() { return {
    "selectedDate": {
      "type": "unknown",
      "mutable": false,
      "complexType": {
        "original": "Date",
        "resolved": "Date",
        "references": {
          "Date": {
            "location": "global"
          }
        }
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      }
    },
    "weekstartday": {
      "type": "string",
      "mutable": false,
      "complexType": {
        "original": "WeekStartDay",
        "resolved": "WeekStartDay.Monday | WeekStartDay.Sunday",
        "references": {
          "WeekStartDay": {
            "location": "import",
            "path": "../../utils/dateutils"
          }
        }
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "weekstartday",
      "reflect": false,
      "defaultValue": "WeekStartDay.Sunday"
    }
  }; }
  static get events() { return [{
      "method": "dayClicked",
      "name": "dayClicked",
      "bubbles": true,
      "cancelable": true,
      "composed": true,
      "docs": {
        "tags": [],
        "text": ""
      },
      "complexType": {
        "original": "Date",
        "resolved": "Date",
        "references": {
          "Date": {
            "location": "global"
          }
        }
      }
    }]; }
}
