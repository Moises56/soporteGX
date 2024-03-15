import { Component, h, Prop, Event } from '@stencil/core';
export class K2btBaseColorPicker {
  constructor() {
    this.columns = 0;
    this.containerclass = '';
    this.maxSelectionSize = 1;
    this.enabled = true;
  }
  getColorRows() {
    var result = [];
    if (this.columns > 0) {
      for (let i = 0; i < this.colorOptions.length; i += this.columns) {
        const row = this.colorOptions.slice(i, i + this.columns);
        result.push(row);
      }
    }
    else {
      result.push(this.colorOptions);
    }
    return result;
  }
  colorIsSelected(c) {
    return this.selectedIds.indexOf(c.id) != -1;
  }
  selectColor(c) {
    debugger;
    if (this.enabled) {
      var id = c.id;
      if (this.selectedIds.includes(id)) {
        // if only one item, it cannot be unselected
        if (this.maxSelectionSize != 1) {
          this.selectedIds = this.selectedIds.filter(i => i != id);
          this.selectionChangedEvent.emit({});
        }
      }
      else {
        // Before selecting this item, check that the amount of items is OK
        if (this.maxSelectionSize == 1) {
          this.selectedIds = [id];
          this.selectionChangedEvent.emit({});
        }
        else if (this.maxSelectionSize == 0 || this.maxSelectionSize > this.selectedIds.length) {
          this.selectedIds = this.selectedIds.concat(id);
          this.selectionChangedEvent.emit({});
        }
        else {
          this.errorCode = K2btBaseColorPicker.ERROR_SELECTION_FULL;
          this.selectionErrorEvent.emit({});
        }
      }
    }
  }
  componentWillRender() {
    if (this.maxSelectionSize > 0 && this.selectedIds.length > this.maxSelectionSize)
      this.selectedIds = this.selectedIds.slice(0, this.maxSelectionSize);
  }
  render() {
    var sectionClass = 'K2BT_BaseColorPicker ' + this.containerclass;
    if (!this.enabled)
      sectionClass += ' K2BT_BaseColorPickerDisabled';
    return (h("div", { class: sectionClass }, this.getColorRows().map(r => {
      return (h("div", { class: "K2BT_BaseColorPickerRow" }, r.map(c => {
        var style = { backgroundColor: c.colorCode };
        var itemClass = 'K2BT_BaseColorPickerItem' + (this.colorIsSelected(c) ? ' K2BT_BaseColorPickerItemSelected' : '');
        return h("div", { class: itemClass, style: style, title: c.description, onClick: () => this.selectColor(c) });
      })));
    })));
  }
  static get is() { return "k2bt-base-color-picker"; }
  static get properties() { return {
    "columns": {
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
      "attribute": "columns",
      "reflect": false,
      "defaultValue": "0"
    },
    "containerclass": {
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
      "attribute": "containerclass",
      "reflect": false,
      "defaultValue": "''"
    },
    "maxSelectionSize": {
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
      "attribute": "max-selection-size",
      "reflect": false,
      "defaultValue": "1"
    },
    "enabled": {
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
      "attribute": "enabled",
      "reflect": false,
      "defaultValue": "true"
    },
    "errorCode": {
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
      "attribute": "error-code",
      "reflect": false
    },
    "colorOptions": {
      "type": "unknown",
      "mutable": false,
      "complexType": {
        "original": "Array<BaseColorOption>",
        "resolved": "BaseColorOption[]",
        "references": {
          "Array": {
            "location": "global"
          },
          "BaseColorOption": {
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
      }
    },
    "selectedIds": {
      "type": "unknown",
      "mutable": false,
      "complexType": {
        "original": "Array<string>",
        "resolved": "string[]",
        "references": {
          "Array": {
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
  static get events() { return [{
      "method": "selectionChangedEvent",
      "name": "selectionChanged",
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
      "method": "selectionErrorEvent",
      "name": "selectionError",
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
K2btBaseColorPicker.ERROR_SELECTION_FULL = 'SELECTION_FULL';
