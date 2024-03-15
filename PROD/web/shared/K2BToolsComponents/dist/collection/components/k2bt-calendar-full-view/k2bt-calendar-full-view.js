import { Component, h, Method, Prop, State, Event, Listen } from '@stencil/core';
import { CalendarPeriodView, DateUtils, WeekStartDay } from '../../utils/dateutils';
import { EnumUtils } from '../../utils/utils';
export class K2btCalendarFullView {
  constructor() {
    this.showheader = true;
    this.showcalendarnavigation = true;
    this.showperiodnavigation = true;
    this.showviewselection = true;
    this.showcalendarselection = true;
    this.starthour = 8;
    this.endhour = 20;
    this.readonly = true;
    this.todaycaption = 'Today';
    this.daycaption = 'Day';
    this.weekcaption = 'Week';
    this.workweekcaption = 'Work Week';
    this.monthcaption = 'Month';
    this.yearcaption = 'Year';
    this.seemorecaption = 'See more';
    this.itemsperdayinmonthview = 5;
    this.dayviewenabled = true;
    this.weekviewenabled = true;
    this.workweekviewenabled = true;
    this.monthviewenabled = true;
    this.weekstartday = WeekStartDay.Sunday;
    this.calendars = [];
    this.selectedCalendars = null;
    this.advancedSelectorOpen = false;
  }
  setPeriodAppointments(parm) {
    if (this.selectedCalendars == null) {
      this.selectedCalendars = parm.calendars.map(c => c.id);
    }
    this.clearAppointmentsInRange(parm.dateFrom, parm.dateTo);
    this.pruneFarawayItems(parm.dateFrom, parm.dateTo);
    this.mergeCalendars(parm.calendars);
    this.assignCalendarMissingClasses(this.calendars);
    this.calendars = [].concat(this.calendars);
  }
  pruneFarawayItems(dateFrom, dateTo) {
    for (let calendar of this.calendars) {
      if (calendar.items.length > K2btCalendarFullView.MAX_STORED_ITEMS) {
        calendar.items.sort((i1, i2) => this.getDistance(i1, dateFrom, dateTo) - this.getDistance(i2, dateFrom, dateTo));
        calendar.items = calendar.items.slice(0, K2btCalendarFullView.MAX_STORED_ITEMS);
      }
    }
  }
  // Item is assumed to be outside range, only check relevant bounds
  getDistance(i, dateFrom, dateTo) {
    return Math.min(Math.abs(i.dateTo.getTime() - dateFrom.getTime()), Math.abs(i.dateFrom.getTime() - dateTo.getTime()));
  }
  assignCalendarMissingClasses(calendars) {
    for (var i = 0; i < calendars.length; i++) {
      if (!calendars[i].class)
        calendars[i].class = 'K2BT_Calendar' + i;
    }
  }
  mergeCalendars(appointments) {
    for (let calendar of appointments) {
      var filteredCalendars = this.calendars.filter(c => c.id == calendar.id);
      if (filteredCalendars.length > 0) {
        filteredCalendars[0].items = filteredCalendars[0].items.concat(calendar.items);
      }
      else {
        this.calendars.push(calendar);
      }
    }
  }
  // dateFrom and dateTo should be treated as local date only values (no time)
  clearAppointmentsInRange(dateFrom, dateTo) {
    var lowerBound = dateFrom;
    var upperBound = dateTo;
    this.calendars = this.calendars.map(c => {
      return {
        id: c.id,
        description: c.description,
        class: c.class,
        items: c.items.filter(i => !DateUtils.datePeriodInBound(lowerBound, upperBound, DateUtils.getDateAtMidnight(i.dateFrom), DateUtils.getDateAtMidnight(i.dateTo))),
      };
    });
  }
  componentWillLoad() {
    this.currentview = CalendarPeriodView.Week;
    this.goToToday();
  }
  render() {
    return (h("div", { class: "K2BT_CalendarContainer" },
      this.getHeader(),
      h("div", { class: "K2BT_CalendarFullViewContent" }, this.getCalendarFullViewContent())));
  }
  getHeader() {
    return this.showheader ? (h("div", { class: "K2BT_CalendarFullViewHeader" },
      this.getTodayButton(),
      this.getPreviousNextButtons(),
      this.getContextTitle(),
      this.getCalendarSelectionCombobox(),
      this.getPeriodSelectionCombobox())) : ('');
  }
  componentDidRender() { }
  getCalendarFullViewContent() {
    switch (this.currentview) {
      case CalendarPeriodView.Day:
        return (h("k2bt-calendar-day-view", { year: this.dateFrom.getFullYear(), month: this.dateFrom.getMonth(), day: this.dateFrom.getDate(), startHour: this.starthour, endHour: this.endhour, readonly: this.readonly, calendars: this.filterSelectedCalendars(this.calendars), showhours: true, alldayrows: 0, ref: c => (this.dayView = c) }));
      case CalendarPeriodView.Week:
      case CalendarPeriodView.WorkWeek:
        return (h("k2bt-calendar-period-view", { dateFrom: this.dateFrom, dateTo: this.dateTo, startHour: this.starthour, endHour: this.endhour, readonly: this.readonly, calendars: this.filterSelectedCalendars(this.calendars), ref: c => (this.weekView = c) }));
      case CalendarPeriodView.Month:
        return (h("k2bt-calendar-month-view", { year: this.dateFrom.getFullYear(), month: this.dateFrom.getMonth() + 1, readonly: this.readonly, calendars: this.filterSelectedCalendars(this.calendars), seemorecaption: this.seemorecaption, itemsperday: this.itemsperdayinmonthview, weekstartday: this.weekstartday, 
          //@ts-ignore
          onDayClicked: ev => this.dayClicked(ev.detail.date), ref: c => (this.monthView = c) }));
    }
  }
  filterSelectedCalendars(calendars) {
    return calendars.filter(c => this.selectedCalendars.indexOf(c.id) !== -1);
  }
  calendarSelectionChanged() {
    this.selectedCalendars = this.calendarCombo.value;
  }
  getCalendarSelectionCombobox() {
    if (this.showcalendarselection) {
      var values = this.getAvailableCalendars();
      if (values.length > 1) {
        return (h("div", { class: "K2BT_CalendarCalendarSelectionCombobox" },
          h("k2bt-enhancedcombo", { onChange: () => this.calendarSelectionChanged(), includesearch: false, showselectionastags: false, enableadditem: false, includeemptyitem: false, headermaxvisibleitems: 1, values: values, value: this.selectedCalendars, maxSelectionSize: 0, ref: c => (this.calendarCombo = c) })));
      }
    }
    return '';
  }
  getAvailableCalendars() {
    return this.calendars.map(c => {
      return { value: c.id, description: c.description, badgeClass: c.class };
    });
  }
  getPeriodSelectionCombobox() {
    if (this.showviewselection) {
      var values = this.getAvailableContentViews();
      if (values.length > 1) {
        var value = [this.currentview];
        return (h("div", { class: "K2BT_CalendarPeriodSelectionCombobox" },
          h("k2bt-enhancedcombo", { onChange: this.periodSelectionChanged.bind(this), includesearch: false, enableadditem: false, includeemptyitem: false, values: values, value: value, ref: c => (this.periodCombo = c) })));
      }
    }
    return '';
  }
  getAvailableContentViews() {
    var values = [];
    if (this.dayviewenabled)
      values.push({
        value: CalendarPeriodView.Day,
        description: this.daycaption,
      });
    if (this.weekviewenabled)
      values.push({
        value: CalendarPeriodView.Week,
        description: this.weekcaption,
      });
    if (this.workweekviewenabled)
      values.push({
        value: CalendarPeriodView.WorkWeek,
        description: this.workweekcaption,
      });
    if (this.monthviewenabled)
      values.push({
        value: CalendarPeriodView.Month,
        description: this.monthcaption,
      });
    return values;
  }
  getContextTitle() {
    return h("div", { class: "K2BT_CalendarHeaderTitle" }, DateUtils.getMonthName(this.dateFrom.getMonth()) + ' ' + this.dateFrom.getFullYear());
  }
  periodSelectionChanged() {
    this.switchView(CalendarPeriodView[EnumUtils.getEnumKeyByEnumValue(CalendarPeriodView, this.periodCombo.value[0])]);
  }
  switchView(view) {
    this.currentview = view;
    this.goToDate(this.dateFrom);
  }
  cancelDraft() {
    var _a;
    (_a = this.dayView) === null || _a === void 0 ? void 0 : _a.cancelDraft();
    if (this.weekView)
      this.weekView.cancelDraft();
  }
  getPreviousNextButtons() {
    return this.showperiodnavigation ? (h("div", { class: "K2BT_CalendarPeriodButtons" },
      h("div", { class: "K2BT_CalendarPreviousPeriodButton", onClick: this.goToPreviousPeriod.bind(this) }),
      h("div", { class: "K2BT_CalendarNextPeriodButton", onClick: this.goToNextPeriod.bind(this) }))) : ('');
  }
  goToNextPeriod() {
    var d = new Date(this.dateFrom.getTime());
    switch (this.currentview) {
      case CalendarPeriodView.Day:
        d.setDate(d.getDate() + 1);
        break;
      case CalendarPeriodView.Week:
      case CalendarPeriodView.WorkWeek:
        d.setDate(d.getDate() + 7);
        break;
      case CalendarPeriodView.Month:
        d = new Date(d.getFullYear(), d.getMonth() + 1, 1);
        break;
    }
    this.goToDate(d);
  }
  goToPreviousPeriod() {
    var d = new Date(this.dateFrom.getTime());
    switch (this.currentview) {
      case CalendarPeriodView.Day:
        d.setDate(d.getDate() - 1);
        break;
      case CalendarPeriodView.Week:
      case CalendarPeriodView.WorkWeek:
        d.setDate(d.getDate() - 7);
        break;
      case CalendarPeriodView.Month:
        d = new Date(d.getFullYear(), d.getMonth() - 1, 1);
        break;
    }
    this.goToDate(d);
  }
  closeMenu(ev) {
    if (this.advancedSelectorOpen && this.quickDaySelectorContainer && !this.quickDaySelectorContainer.contains(ev.target))
      this.advancedSelectorOpen = false;
  }
  getTodayButton() {
    return this.showcalendarnavigation ? (h("div", { class: "K2B_CalendarQuickDaySelectorContainer", ref: c => (this.quickDaySelectorContainer = c) },
      h("div", { class: "K2B_CalendarQuickDaySelector" },
        h("div", { class: "K2BT_CalendarTodayButton", onClick: this.goToToday.bind(this) }, this.todaycaption),
        h("div", { class: "K2BT_CalendarAdvancedSelectorToggle", onClick: () => (this.advancedSelectorOpen = !this.advancedSelectorOpen) })),
      this.getAdvancedSelectorContents())) : ('');
  }
  getAdvancedSelectorContents() {
    return this.advancedSelectorOpen ? (h("div", { class: "K2BT_CalendarAdvancedSelectorContents" },
      h("k2bt-calendar-day-in-month-picker", { selectedDate: this.dateFrom, weekstartday: this.weekstartday, onDayClicked: e => {
          this.advancedSelectorOpen = false;
          this.goToDate(e.detail);
        } }))) : ('');
  }
  dayClicked(d) {
    if (this.dayviewenabled) {
      this.switchView(CalendarPeriodView.Day);
      this.goToDate(d);
    }
  }
  goToToday() {
    this.goToDate(new Date());
  }
  goToDate(date) {
    var originalDateFrom = this.dateFrom ? new Date(this.dateFrom.getTime()) : null;
    var originalDateTo = this.dateTo ? new Date(this.dateTo.getTime()) : null;
    switch (this.currentview) {
      case CalendarPeriodView.Day:
        this.dateFrom = date;
        this.dateTo = date;
        break;
      case CalendarPeriodView.Week:
        var d = new Date(date.getTime());
        if (this.weekstartday === WeekStartDay.Sunday) {
          d.setDate(d.getDate() - d.getDay());
        }
        else {
          d.setDate(d.getDate() - d.getDay() + 1);
        }
        this.dateFrom = d;
        d = new Date(date.getTime());
        if (this.weekstartday === WeekStartDay.Sunday) {
          d.setDate(d.getDate() - d.getDay() + 7);
        }
        else {
          d.setDate(d.getDate() - d.getDay() + 8);
        }
        this.dateTo = d;
        break;
      case CalendarPeriodView.WorkWeek:
        d = new Date(date.getTime());
        d.setDate(d.getDate() - d.getDay() + 1);
        this.dateFrom = d;
        d = new Date(date.getTime());
        d.setDate(d.getDate() - d.getDay() + 6);
        this.dateTo = d;
        break;
      case CalendarPeriodView.Month:
        this.dateFrom = new Date(date.getFullYear(), date.getMonth(), 1);
        this.dateTo = new Date(date.getFullYear(), date.getMonth() + 1, 0);
        break;
    }
    if (originalDateFrom != this.dateFrom || originalDateTo != this.dateTo) {
      this.fetchAppointmentsForPeriod.emit({
        dateFrom: this.dateFrom,
        dateTo: this.dateTo,
      });
    }
  }
  static get is() { return "k2bt-calendar-full-view"; }
  static get properties() { return {
    "showheader": {
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
      "attribute": "showheader",
      "reflect": false,
      "defaultValue": "true"
    },
    "showcalendarnavigation": {
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
      "attribute": "showcalendarnavigation",
      "reflect": false,
      "defaultValue": "true"
    },
    "showperiodnavigation": {
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
      "attribute": "showperiodnavigation",
      "reflect": false,
      "defaultValue": "true"
    },
    "showviewselection": {
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
      "attribute": "showviewselection",
      "reflect": false,
      "defaultValue": "true"
    },
    "showcalendarselection": {
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
      "attribute": "showcalendarselection",
      "reflect": false,
      "defaultValue": "true"
    },
    "starthour": {
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
      "attribute": "starthour",
      "reflect": false,
      "defaultValue": "8"
    },
    "endhour": {
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
      "attribute": "endhour",
      "reflect": false,
      "defaultValue": "20"
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
    "todaycaption": {
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
      "attribute": "todaycaption",
      "reflect": false,
      "defaultValue": "'Today'"
    },
    "daycaption": {
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
      "attribute": "daycaption",
      "reflect": false,
      "defaultValue": "'Day'"
    },
    "weekcaption": {
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
      "attribute": "weekcaption",
      "reflect": false,
      "defaultValue": "'Week'"
    },
    "workweekcaption": {
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
      "attribute": "workweekcaption",
      "reflect": false,
      "defaultValue": "'Work Week'"
    },
    "monthcaption": {
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
      "attribute": "monthcaption",
      "reflect": false,
      "defaultValue": "'Month'"
    },
    "yearcaption": {
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
      "attribute": "yearcaption",
      "reflect": false,
      "defaultValue": "'Year'"
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
      "defaultValue": "'See more'"
    },
    "itemsperdayinmonthview": {
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
      "attribute": "itemsperdayinmonthview",
      "reflect": false,
      "defaultValue": "5"
    },
    "dayviewenabled": {
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
      "attribute": "dayviewenabled",
      "reflect": false,
      "defaultValue": "true"
    },
    "weekviewenabled": {
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
      "attribute": "weekviewenabled",
      "reflect": false,
      "defaultValue": "true"
    },
    "workweekviewenabled": {
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
      "attribute": "workweekviewenabled",
      "reflect": false,
      "defaultValue": "true"
    },
    "monthviewenabled": {
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
      "attribute": "monthviewenabled",
      "reflect": false,
      "defaultValue": "true"
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
    },
    "dateFrom": {
      "type": "unknown",
      "mutable": true,
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
    "dateTo": {
      "type": "unknown",
      "mutable": true,
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
    }
  }; }
  static get states() { return {
    "currentview": {},
    "calendars": {},
    "selectedCalendars": {},
    "advancedSelectorOpen": {}
  }; }
  static get events() { return [{
      "method": "newDraftCreated",
      "name": "newDraftCreated",
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
      "method": "draftCancelled",
      "name": "draftCancelled",
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
      "method": "fetchAppointmentsForPeriod",
      "name": "fetchAppointmentsForPeriod",
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
  static get methods() { return {
    "setPeriodAppointments": {
      "complexType": {
        "signature": "(parm: SetPeriodAppointmentsParms) => Promise<void>",
        "parameters": [{
            "tags": [],
            "text": ""
          }],
        "references": {
          "SetPeriodAppointmentsParms": {
            "location": "import",
            "path": "../../utils/utils"
          }
        },
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "switchView": {
      "complexType": {
        "signature": "(view: CalendarPeriodView) => Promise<void>",
        "parameters": [{
            "tags": [],
            "text": ""
          }],
        "references": {
          "CalendarPeriodView": {
            "location": "import",
            "path": "../../utils/dateutils"
          }
        },
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "cancelDraft": {
      "complexType": {
        "signature": "() => Promise<void>",
        "parameters": [],
        "references": {},
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "goToNextPeriod": {
      "complexType": {
        "signature": "() => Promise<void>",
        "parameters": [],
        "references": {
          "Date": {
            "location": "global"
          }
        },
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "goToPreviousPeriod": {
      "complexType": {
        "signature": "() => Promise<void>",
        "parameters": [],
        "references": {
          "Date": {
            "location": "global"
          }
        },
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "goToDate": {
      "complexType": {
        "signature": "(date: Date) => Promise<void>",
        "parameters": [{
            "tags": [],
            "text": ""
          }],
        "references": {
          "Date": {
            "location": "global"
          }
        },
        "return": "Promise<void>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    }
  }; }
  static get listeners() { return [{
      "name": "click",
      "method": "closeMenu",
      "target": "window",
      "capture": false,
      "passive": false
    }]; }
}
K2btCalendarFullView.MAX_STORED_ITEMS = 300;
