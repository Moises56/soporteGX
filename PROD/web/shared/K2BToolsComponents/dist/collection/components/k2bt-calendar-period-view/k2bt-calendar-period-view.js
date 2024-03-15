import { Component, h, Prop, State, Event, Method } from '@stencil/core';
import { CalendarItem } from '../../utils/utils';
export class K2btCalendarPeriodView {
  constructor() {
    this.calendars = [];
    this.readonly = true;
    this.draftItemDescription = '(no title)';
    this.draftItem = null;
    this.dayComponents = [];
  }
  onDayViewDraftCancelled() { }
  async onCreatingNewDraft(event) {
    for (let d of this.dayComponents) {
      if (event.target != d)
        await d.cancelDraft();
    }
  }
  async cancelDraft() {
    for (let d of this.dayComponents) {
      await d.cancelDraft();
    }
  }
  render() {
    var days = [];
    var d = new Date(this.dateFrom.getTime());
    while (d < this.dateTo) {
      days.push({ year: d.getFullYear(), month: d.getMonth(), day: d.getDate() });
      d.setDate(d.getDate() + 1);
    }
    this.dayComponents = [];
    var maxDayItemsInDate = Math.max(...days
      .map(day => new Date(day.year, day.month, day.day, 0, 0, 0, 0))
      .map(date => this.calendars.map(c => c.items.filter(i => i.allDay && CalendarItem.allDayItemIsInDay(i, date))).reduce((i1, i2) => i1.concat(i2), []).length));
    var first = true;
    return (h("div", { class: "K2BT_CalendarPeriod" }, days.map(d => {
      var showhours = first;
      first = false;
      return (h("div", { class: "K2BT_CalendarPeriodDayContainer" },
        h("k2bt-calendar-day-view", { year: d.year, month: d.month, day: d.day, startHour: this.startHour, endHour: this.endHour, readonly: this.readonly, calendars: this.calendars, showhours: showhours, ref: c => this.dayComponents.push(c), alldayrows: maxDayItemsInDate, onDraftCancelled: this.onDayViewDraftCancelled.bind(this), onCreatingNewDraft: this.onCreatingNewDraft.bind(this) })));
    })));
  }
  static get is() { return "k2bt-calendar-period-view"; }
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
    "dateFrom": {
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
    "dateTo": {
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
    }
  }; }
  static get states() { return {
    "draftItem": {}
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
      "method": "draftCanceled",
      "name": "draftCanceled",
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
    }]; }
  static get methods() { return {
    "cancelDraft": {
      "complexType": {
        "signature": "() => Promise<void>",
        "parameters": [],
        "references": {
          "Promise": {
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
}
