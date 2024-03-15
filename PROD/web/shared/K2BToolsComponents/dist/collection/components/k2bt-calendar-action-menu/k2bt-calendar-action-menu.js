import { Component, h, Prop, State, Event, Listen } from '@stencil/core';
import { LanguageUtils } from '../../utils/utils';
export class K2btCalendarActionMenu {
  constructor() {
    this.actions = [];
    this.isOpen = false;
  }
  toggleMenu() {
    this.isOpen = !this.isOpen;
  }
  executeAction(action) {
    this.isOpen = false;
    this.actionClicked.emit(action.id);
  }
  closeMenu(ev) {
    if (this.isOpen && this.quickDaySelectorContainer && !this.quickDaySelectorContainer.contains(ev.target))
      this.isOpen = false;
  }
  render() {
    var _a, _b;
    const menuClass = `K2BT_CalendarActionMenu ${this.isOpen ? 'open' : ''}`;
    return ((_b = (_a = this.actions) === null || _a === void 0 ? void 0 : _a.length) !== null && _b !== void 0 ? _b : 0) > 0 ? (h("div", { class: menuClass, ref: c => (this.quickDaySelectorContainer = c) },
      h("span", { class: "K2BT_CalendarActionMenu_ToggleButton", onClick: e => {
          e.stopPropagation();
          this.toggleMenu();
        } }),
      h("div", { class: "K2BT_CalendarActionMenuContents" }, this.isOpen && (h("ul", { class: "K2BT_CalendarActionMenu_Dropdown" }, this.actions.map(action => (h("li", { onClick: e => {
          e.stopPropagation();
          this.executeAction(action);
        } },
        h("img", { class: 'K2BT_CalendarActionMenu_Image GX_Image_' + action.imageName + '_Class', src: action.imageUrl, alt: LanguageUtils.getTranslatedMessage(action.name) }),
        h("span", null, LanguageUtils.getTranslatedMessage(action.name)))))))))) : ('');
  }
  static get is() { return "k2bt-calendar-action-menu"; }
  static get properties() { return {
    "actions": {
      "type": "unknown",
      "mutable": false,
      "complexType": {
        "original": "CalendarItemAction[]",
        "resolved": "CalendarItemAction[]",
        "references": {
          "CalendarItemAction": {
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
    }
  }; }
  static get states() { return {
    "isOpen": {}
  }; }
  static get events() { return [{
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
        "original": "string",
        "resolved": "string",
        "references": {}
      }
    }]; }
  static get listeners() { return [{
      "name": "click",
      "method": "closeMenu",
      "target": "window",
      "capture": false,
      "passive": false
    }]; }
}
