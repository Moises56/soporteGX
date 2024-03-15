import { Component, h, Prop, Event, State, Method } from '@stencil/core';
import { DateUtils } from '../../utils/dateutils';
import { CalendarItem } from '../../utils/utils';
export class K2btCalendarDayView {
  constructor() {
    this.calendars = [];
    this.year = 2023;
    this.month = 1;
    this.day = 1;
    this.readonly = true;
    this.draftItemDescription = '(no title)';
    this.showhours = true;
    this.alldayrows = 10;
    this.draftItem = null;
    this.currentDate = new Date();
    this.creatingDraft = false;
    this.mouseMovedWhileCreating = false;
    this.draftBaseDate = null;
    this.intervalId = null;
    this.scopedfunction = this.onMouseUp.bind(this);
  }
  cancelDraft() {
    if (this.draftItem != null) {
      this.draftCancelled.emit(this.draftItem);
      this.draftItem = null;
    }
  }
  onMouseDown(event) {
    if (this.readonly) {
      if (this.draftItem) {
        this.draftCancelled.emit(this.draftItem);
        this.draftItem = null;
      }
      var mousePos = this.getMousePosition(event, this.baseGridControl);
      var hour = Math.floor((mousePos.y / this.baseGridControl.offsetHeight) * this.getAmountOfHours() + this.startHour);
      var min = (Math.round(((mousePos.y / this.baseGridControl.offsetHeight) * this.getAmountOfHours() + this.startHour - hour) * 4) / 4) * 60;
      this.draftItem = new CalendarItem();
      this.draftItem.class = '';
      this.draftItem.isDraft = true;
      this.draftItem.description = this.draftItemDescription;
      this.draftItem.dateFrom = new Date(this.year, this.month, this.day, hour, min, 0, 0);
      this.draftItem.dateTo = new Date(this.year, this.month, this.day, hour + 1, min, 0, 0);
      this.creatingDraft = true;
      this.mouseMovedWhileCreating = false;
      this.draftBaseDate = this.draftItem.dateFrom;
      this.creatingNewDraft.emit(null);
    }
  }
  onMouseMove(event) {
    if (this.readonly && this.creatingDraft) {
      this.mouseMovedWhileCreating = true;
      var mousePos = this.getMousePosition(event, this.baseGridControl);
      var hour = Math.floor((mousePos.y / this.baseGridControl.offsetHeight) * this.getAmountOfHours() + this.startHour);
      var min = (Math.round(((mousePos.y / this.baseGridControl.offsetHeight) * this.getAmountOfHours() + this.startHour - hour) * 4) / 4) * 60;
      if (min === 60) {
        min = 0;
        hour++;
      }
      if (hour > this.draftBaseDate.getHours() || (hour === this.draftBaseDate.getHours() && min > this.draftBaseDate.getMinutes())) {
        // Set draft to previous dates
        if (this.draftItem.dateFrom !== this.draftBaseDate || hour !== this.draftItem.dateTo.getHours() || min !== this.draftItem.dateTo.getMinutes()) {
          this.draftItem = Object.assign({}, this.draftItem);
          this.draftItem.dateFrom = this.draftBaseDate;
          this.draftItem.dateTo = new Date(this.year, this.month, this.day, hour, min, 0, 0);
        }
      }
      else if (hour < this.draftBaseDate.getHours() || (hour === this.draftBaseDate.getHours() && min < this.draftBaseDate.getMinutes())) {
        // Set draft to preceding dates
        if (this.draftItem.dateTo !== this.draftBaseDate || hour !== this.draftItem.dateFrom.getHours() || min !== this.draftItem.dateFrom.getMinutes()) {
          this.draftItem = Object.assign({}, this.draftItem);
          this.draftItem.dateFrom = new Date(this.year, this.month, this.day, hour, min, 0, 0);
          this.draftItem.dateTo = this.draftBaseDate;
        }
      }
    }
  }
  onMouseUp() {
    if (this.readonly && this.creatingDraft) {
      this.creatingDraft = false;
      this.mouseMovedWhileCreating = false;
      this.draftItem = Object.assign({}, this.draftItem);
      this.newDraftCreated.emit({ item: this.draftItem });
    }
  }
  onItemClicked(item) {
    this.itemClicked.emit({ item: item });
  }
  onActionClicked(item, actionId) {
    this.actionClicked.emit({ item: item, action: actionId });
  }
  getMousePosition(event, div) {
    const rect = div.getBoundingClientRect();
    const scrollTop = div.scrollTop;
    const scrollLeft = div.scrollLeft;
    const clientX = event.clientX;
    const clientY = event.clientY;
    const x = clientX - rect.left + scrollLeft;
    const y = clientY - rect.top + scrollTop;
    return { x, y };
  }
  getDateTo() {
    return new Date(this.year, this.month, this.day, this.endHour, 0, 0, 0);
  }
  getDateFrom() {
    return new Date(this.year, this.month, this.day, this.startHour, 0, 0, 0);
  }
  getAmountOfHours() {
    return this.endHour - this.startHour;
  }
  getBoundedDate(d) {
    if (d > this.getDateTo())
      return this.getDateTo();
    if (d < this.getDateFrom())
      return this.getDateFrom();
    return d;
  }
  render() {
    var day = this.getDay();
    var dayOfWeek = DateUtils.getDayOfWeekShortString(day);
    var dayOfMonth = this.day.toString();
    var hours = [];
    for (var hour = this.startHour; hour < this.endHour; hour++) {
      hours.push(hour);
    }
    var allDayItems = this.getAllDayItems();
    var items = this.getNonAllDayItems();
    if (this.draftItem != null && !this.creatingDraft)
      items.push(this.draftItem);
    var itemRows = this.sortIntoRows(items);
    if (this.draftItem != null && this.mouseMovedWhileCreating) {
      // add the draft item without looking at rows while user is moving the mouse
      itemRows.push([this.draftItem]);
      items.push(this.draftItem);
    }
    var hourPositionStyle = {
      top: ((this.currentDate.getTime() - this.getDateFrom().getTime()) / 1000 / 60 / 60 / this.getAmountOfHours()) * 100 + '%',
      display: this.currentDate >= this.getDateFrom() && this.currentDate <= this.getDateTo() ? 'block' : 'none',
    };
    var itemsViewClasses = 'K2BT_CalendarDayItemsView';
    if (!this.showhours)
      itemsViewClasses += ' K2BT_CalendarDayItemsNoMargin';
    var dayContainerClasses = 'K2BT_CalendarDayViewContainer';
    if (this.currentDate.getFullYear() === this.year && this.currentDate.getMonth() === this.month && this.currentDate.getDate() === this.day)
      dayContainerClasses += ' K2BT_CalendarDayViewToday';
    if (this.draftItem)
      dayContainerClasses += ' K2BT_CalendarDayCreatingDraft';
    return (h("div", { class: dayContainerClasses },
      h("div", { class: "K2BT_CalendarDayViewHeader" },
        h("div", { class: "K2BT_CalendarDayViewDoW" }, dayOfWeek),
        h("div", { class: "K2BT_CalendarDayViewDoM" }, dayOfMonth)),
      h("div", { class: "K2BT_AlldayItems" },
        allDayItems.map(item => {
          return this.getAllDayItemContents(item);
        }),
        this.alldayrows
          ? /* Add padding to all day items view */
            Array.from(Array(this.alldayrows - allDayItems.length).keys()).map(i => (h("div", { class: "K2BT_AlldayItem", style: { visibility: 'hidden' } }, 'Hidden: ' + i)))
          : ''),
      h("div", { class: "K2BT_CalendarDayContent" },
        h("div", { class: "K2BT_CalendarDayViewContainerBaseGrid", ref: c => (this.baseGridControl = c), onMouseDown: this.onMouseDown.bind(this), onMouseMove: this.onMouseMove.bind(this), onMouseUp: this.onMouseUp.bind(this) }, hours.map(hour => (h("div", { class: "K2BT_CalendarDayHour" }, this.showhours ? h("div", { class: "K2BT_CalendarDayHourNumber" }, hour) : '')))),
        h("div", { class: itemsViewClasses }, items.map(item => {
          return this.getInDayItemContents(item, itemRows);
        })),
        h("div", { class: "K2BT_CalendarDayHourMarker", style: hourPositionStyle }))));
  }
  getAllDayItemContents(item) {
    var _a, _b;
    var classList = new Array('K2BT_AlldayItem');
    CalendarItem.addItemClasses(classList, item, this.currentDate);
    var calendar = (_a = this.calendars.filter(c => c.id === item.calendarId)[0]) !== null && _a !== void 0 ? _a : this.calendars[0];
    return (h("div", { class: classList.join(' '), onClick: () => this.onItemClicked(item) },
      h("div", { class: "K2BT_AllDayItemDescription" }, item.description),
      h("k2bt-calendar-action-menu", { actions: item.actions, onActionClicked: e => {
          e.stopPropagation();
          this.onActionClicked(item, e.detail);
        } }),
      h("div", { class: (_b = 'K2BT_CalendarBackground ' + (calendar === null || calendar === void 0 ? void 0 : calendar.class)) !== null && _b !== void 0 ? _b : 'K2BT_Calendar0' })));
  }
  getInDayItemContents(item, itemRows) {
    var _a, _b;
    var offsetHours = (this.getBoundedDate(item.dateFrom).getTime() - this.getDateFrom().getTime()) / 1000 / 60 / 60;
    var lengthHours = (this.getBoundedDate(item.dateTo).getTime() - this.getBoundedDate(item.dateFrom).getTime()) / 1000 / 60 / 60;
    var row = itemRows.filter(r => r.indexOf(item) != -1)[0];
    var style = {
      top: (offsetHours / this.getAmountOfHours()) * 100 + '%',
      height: (lengthHours / this.getAmountOfHours()) * 100 + '%',
      width: null,
      left: null,
    };
    if (row.length > 1) {
      style.width = 'calc(' + 100 / row.length + '% - 2px)';
      style.left = row.indexOf(item) * (100 / row.length) + '%';
    }
    var classList = new Array('K2BT_CalendarDayItem');
    CalendarItem.addItemClasses(classList, item, this.currentDate);
    var calendar = (_a = this.calendars.filter(c => c.id === item.calendarId)[0]) !== null && _a !== void 0 ? _a : this.calendars[0];
    const periodString = DateUtils.formatItemDate(item.dateFrom) + '-' + DateUtils.formatItemDate(item.dateTo);
    return (h("div", { class: classList.join(' '), style: style, onClick: () => this.onItemClicked(item), title: item.description + '\n' + periodString },
      h("div", { class: "K2BT_CalendarDayItemContent" },
        h("div", { class: "K2BT_CalendarDayItemText" },
          h("div", { class: "K2BT_CalendarDayItemHeader" },
            h("div", { class: "K2BT_CalendarDayItemDescription" }, item.description)),
          h("div", { class: "K2BT_CalendarDayItemHourPeriod" }, periodString)),
        h("k2bt-calendar-action-menu", { actions: item.actions, onActionClicked: e => {
            e.stopPropagation();
            this.onActionClicked(item, e.detail);
          } })),
      h("div", { class: (_b = 'K2BT_CalendarBackground ' + (calendar === null || calendar === void 0 ? void 0 : calendar.class)) !== null && _b !== void 0 ? _b : 'K2BT_Calendar0' })));
  }
  getNonAllDayItems() {
    return this.calendars
      .map(c => c.items
      .filter(i => !i.allDay && CalendarItem.isInDay(i, this.getDateFrom(), this.getDateTo()))
      .map(i => {
      i.calendarId = c.id;
      return i;
    }))
      .reduce((i1, i2) => i1.concat(i2), []);
  }
  getAllDayItems() {
    return this.calendars
      .map(c => c.items
      .filter(i => i.allDay && CalendarItem.allDayItemIsInDay(i, this.getDay()))
      .map(i => {
      i.calendarId = c.id;
      return i;
    }))
      .reduce((i1, i2) => i1.concat(i2), []);
  }
  componentDidLoad() {
    if (this.readonly)
      document.addEventListener('mouseup', this.scopedfunction);
    this.intervalId = setInterval(function () {
      this.currentDate = new Date();
    }.bind(this), 1000 * 60 * 10); // Every 10 minutes
  }
  disconnectedCallback() {
    if (this.readonly)
      document.removeEventListener('mouseup', this.scopedfunction);
    clearInterval(this.intervalId);
  }
  sortIntoRows(items) {
    items = items.sort((a, b) => a.dateFrom.getTime() - b.dateFrom.getTime());
    const rows = [];
    for (const item of items) {
      // Check if it collides with one of the rows
      var overlaps = false;
      for (const row of rows) {
        for (const columnItem of row) {
          if (CalendarItem.calendarItemsCollide(item, columnItem)) {
            overlaps = true;
            break;
          }
        }
        if (overlaps) {
          row.push(item);
          break;
        }
      }
      if (!overlaps) {
        rows.push([item]);
      }
    }
    const result = [];
    for (let row of rows) {
      result.push(row.sort((i1, _i2) => (i1.isDraft ? 1 : -1)));
    }
    return result;
  }
  getDay() {
    return new Date(this.year, this.month, this.day, 0, 0, 0, 0);
  }
  static get is() { return "k2bt-calendar-day-view"; }
  static get properties() { return {
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
    "startHour": {
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
      "attribute": "start-hour",
      "reflect": false
    },
    "endHour": {
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
      "attribute": "end-hour",
      "reflect": false
    },
    "year": {
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
      "attribute": "year",
      "reflect": false,
      "defaultValue": "2023"
    },
    "month": {
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
      "attribute": "month",
      "reflect": false,
      "defaultValue": "1"
    },
    "day": {
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
      "attribute": "day",
      "reflect": false,
      "defaultValue": "1"
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
    "draftItemDescription": {
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
      "attribute": "draft-item-description",
      "reflect": false,
      "defaultValue": "'(no title)'"
    },
    "showhours": {
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
      "attribute": "showhours",
      "reflect": false,
      "defaultValue": "true"
    },
    "alldayrows": {
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
      "attribute": "alldayrows",
      "reflect": false,
      "defaultValue": "10"
    }
  }; }
  static get states() { return {
    "draftItem": {},
    "currentDate": {}
  }; }
  static get events() { return [{
      "method": "creatingNewDraft",
      "name": "creatingNewDraft",
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
  static get methods() { return {
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
    }
  }; }
}
