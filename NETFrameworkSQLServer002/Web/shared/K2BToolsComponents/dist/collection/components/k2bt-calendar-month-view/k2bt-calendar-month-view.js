import { Component, Event, h, Prop, State } from '@stencil/core';
import { DateUtils, WeekStartDay } from '../../utils/dateutils';
import { CalendarItem } from '../../utils/utils';
export class K2btCalendarMonthView {
  constructor() {
    this.readonly = true;
    this.calendars = [];
    this.seemorecaption = 'See all';
    this.itemsperday = 5;
    this.weekstartday = WeekStartDay.Sunday;
    this.currentDate = new Date();
    this.intervalId = null;
  }
  onItemClicked(item) {
    this.itemClicked.emit({ item: item });
  }
  onActionClicked(item, actionId) {
    this.actionClicked.emit({ item: item, action: actionId });
  }
  render() {
    var weeks = DateUtils.getWeeksOfMonth(this.year, this.month, this.weekstartday);
    const firstDayOfMonth = new Date(this.year, this.month - 1, 1);
    const lastDayOfMonth = new Date(this.year, this.month, 0);
    return (h("div", { class: "K2BT_CalendarMonthView" },
      h("div", { class: "K2BT_CalendarMonthDayNames" }, weeks[0]
        .map(d => d.getDay())
        .map(d => (h("div", { class: "K2BT_CalendarMonthViewDayName" }, DateUtils.getDayOfWeekShortStringFromDayNumber(d))))),
      weeks.map(w => {
        return (h("div", { class: "K2BT_CalendarMonthViewWeek" }, w.map(d => {
          var year = d.getFullYear();
          var month = d.getMonth();
          var day = d.getDate();
          var filteredAppointments = this.getFilteredAppointments(year, month, day);
          var visibleAppointments = this.itemsperday > 0 ? filteredAppointments.slice(0, this.itemsperday) : filteredAppointments;
          var dayClasses = this.getClassesForDayContainer(d, firstDayOfMonth, lastDayOfMonth);
          var dayNumberContainerClasses = this.getClassesForNumberContainer(year, month, day);
          visibleAppointments.sort((a, b) => a.dateFrom.getTime() - b.dateFrom.getTime());
          return (h("div", { class: dayClasses, onClick: () => this.onDayClicked(d) },
            h("div", { class: "K2BT_CalendarMonthDayComponent" },
              h("div", { class: dayNumberContainerClasses }, d.getDate()),
              h("div", { class: "K2BT_CalendarMonthViewDayAppointmentList" },
                visibleAppointments.map(item => {
                  var _a;
                  var calendar = (_a = this.calendars.filter(c => c.id === item.calendarId)[0]) !== null && _a !== void 0 ? _a : this.calendars[0];
                  var classList = new Array('K2BT_CalendarMonthViewDayAppointmentBadge');
                  classList.push(calendar.class);
                  CalendarItem.addItemClasses(classList, item, this.currentDate);
                  const periodString = item.allDay ? '' : DateUtils.formatItemDate(item.dateFrom) + '-' + DateUtils.formatItemDate(item.dateTo);
                  return (h("div", { class: "K2BT_CalendarMonthViewDayAppointment", onClick: e => {
                      e.stopPropagation();
                      this.onItemClicked(item);
                    }, title: item.description + '\n' + periodString },
                    h("div", { class: classList.join(' ') }),
                    h("div", { class: "K2BT_CalendarMonthViewDayAppointmentPeriod" }, periodString),
                    h("div", { class: "K2BT_CalendarMonthViewDayAppointmentDescription" }, item.description),
                    h("k2bt-calendar-action-menu", { actions: item.actions, onActionClicked: e => this.onActionClicked(item, e.detail) })));
                }),
                visibleAppointments.length < filteredAppointments.length ? h("div", { class: "K2BT_CalendarMonthViewDaySeeMore" }, this.seemorecaption) : ''))));
        })));
      })));
  }
  getClassesForNumberContainer(year, month, day) {
    var dayNumberContainerClasses = 'K2BT_CalendarMonthViewDayNumber';
    if (this.currentDate.getFullYear() === year && this.currentDate.getMonth() === month && this.currentDate.getDate() === day)
      dayNumberContainerClasses += ' K2BT_CalendarDayViewToday';
    return dayNumberContainerClasses;
  }
  getClassesForDayContainer(d, firstDayOfMonth, lastDayOfMonth) {
    var dayClasses = 'K2BT_CalendarMonthViewDay';
    if (!(d >= firstDayOfMonth && d <= lastDayOfMonth)) {
      dayClasses += ' K2BT_CalendarMonthViewDayOtherMonth';
    }
    if (d < new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), this.currentDate.getDate())) {
      dayClasses += ' K2BT_CalendarMonthViewDayPast';
    }
    return dayClasses;
  }
  getFilteredAppointments(year, month, day) {
    return this.calendars
      .map(c => c.items
      .filter(i => (i.dateFrom.getFullYear() == year && i.dateFrom.getMonth() == month && i.dateFrom.getDate() == day) ||
      (i.dateTo.getFullYear() == year && i.dateTo.getMonth() == month && i.dateTo.getDate() == day))
      .map(i => {
      i.calendarId = c.id;
      return i;
    }))
      .reduce((i1, i2) => i1.concat(i2), []);
  }
  componentDidLoad() {
    this.intervalId = setInterval(function () {
      this.currentDate = new Date();
    }.bind(this), 1000 * 60 * 10); // Every 10 minutes
  }
  disconnectedCallback() {
    clearInterval(this.intervalId);
  }
  onDayClicked(day) {
    this.dayClicked.emit({ date: day });
  }
  static get is() { return "k2bt-calendar-month-view"; }
  static get properties() { return {
    "year": {
      "type": "number",
      "mutable": true,
      "complexType": {
        "original": "number",
        "resolved": "number",
        "references": {}
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "year",
      "reflect": false
    },
    "month": {
      "type": "number",
      "mutable": true,
      "complexType": {
        "original": "number",
        "resolved": "number",
        "references": {}
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "month",
      "reflect": false
    },
    "readonly": {
      "type": "boolean",
      "mutable": false,
      "complexType": {
        "original": "boolean",
        "resolved": "boolean",
        "references": {}
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "readonly",
      "reflect": false,
      "defaultValue": "true"
    },
    "calendars": {
      "type": "unknown",
      "mutable": false,
      "complexType": {
        "original": "Calendar[]",
        "resolved": "Calendar[]",
        "references": {
          "Calendar": {
            "location": "import",
            "path": "../../utils/utils"
          }
        }
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "defaultValue": "[]"
    },
    "seemorecaption": {
      "type": "string",
      "mutable": false,
      "complexType": {
        "original": "string",
        "resolved": "string",
        "references": {}
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "seemorecaption",
      "reflect": false,
      "defaultValue": "'See all'"
    },
    "itemsperday": {
      "type": "number",
      "mutable": false,
      "complexType": {
        "original": "number",
        "resolved": "number",
        "references": {}
      },
      "required": false,
      "optional": false,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "itemsperday",
      "reflect": false,
      "defaultValue": "5"
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
  static get states() { return {
    "currentDate": {}
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
        "original": "object",
        "resolved": "object",
        "references": {}
      }
    }, {
      "method": "itemClicked",
      "name": "itemClicked",
      "bubbles": true,
      "cancelable": true,
      "composed": true,
      "docs": {
        "tags": [],
        "text": ""
      },
      "complexType": {
        "original": "object",
        "resolved": "object",
        "references": {}
      }
    }, {
      "method": "actionClicked",
      "name": "actionClicked",
      "bubbles": true,
      "cancelable": true,
      "composed": true,
      "docs": {
        "tags": [],
        "text": ""
      },
      "complexType": {
        "original": "object",
        "resolved": "object",
        "references": {}
      }
    }]; }
}
