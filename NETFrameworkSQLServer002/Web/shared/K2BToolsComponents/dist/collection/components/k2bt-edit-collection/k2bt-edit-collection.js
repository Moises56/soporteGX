import { Component, Host, h, Prop, Event } from '@stencil/core';
export class K2btEditCollection {
  constructor() {
    this.value = [];
    this.maxSelectionSize = 0;
    this.datatype = K2btEditCollection.DATATYPE_CHARACTER;
    // used only for character
    this.length = 10;
    // used only for numerics
    this.integers = 5;
    // used only for numerics
    this.decimals = 2;
    this.enabled = true;
    this.inputclass = '';
    this.readonlyclass = '';
    this.invitemessage = '';
    this.itemInputs = [];
    this._triggerChangeDebouncer = null;
  }
  removeItem(index) {
    this.value = this.value.filter((_item, i) => i != index);
    this.triggerChangeEvent();
  }
  onInput(index, _ev) {
    if (index == this.value.length && this.itemInputs[index].value !== '') {
      this.value = this.value.concat(['']);
    }
    this.value[index] = this.itemInputs[index].value;
    _ev.stopPropagation();
    this.inputEvent.emit(null);
  }
  triggerChangeEvent() {
    if (this._triggerChangeDebouncer != null)
      clearTimeout(this._triggerChangeDebouncer);
    this._triggerChangeDebouncer = setTimeout(() => {
      this.changeEvent.emit(null);
    }, 200);
  }
  render() {
    this.itemInputs = [];
    var styleObj = {};
    var maxLength = 0;
    if (this.datatype == K2btEditCollection.DATATYPE_NUMERIC) {
      //@ts-ignore
      styleObj.textAlign = 'right';
      maxLength = this.integers + this.decimals + (this.decimals > 0 ? 1 : 0);
    }
    else {
      maxLength = this.length;
    }
    //@ts-ignore
    styleObj.width = maxLength + 'ch';
    const displayedvalues = this.maxSelectionSize == 0 || this.value.length < this.maxSelectionSize ? this.value.concat(['']) : this.value;
    return (h(Host, null,
      h("div", { class: "K2BT_EditCollection", style: !this.enabled ? {} : { display: 'none' } }, !this.enabled
        ? this.value.map(v => (h("div", { class: "K2BT_EditCollectionItem" },
          h("p", { class: "form-control-static" },
            h("span", { class: this.readonlyclass, "data-gx-readonly": "" }, v)))))
        : ''),
      h("div", { class: "K2BT_EditCollection", style: this.enabled ? {} : { display: 'none' } }, displayedvalues.map((v, index) => (h("div", { class: "K2BT_EditCollectionItem" },
        h("input", { class: 'form-control K2BT_EditCollectionItemInput ' + this.inputclass, type: "text", value: v, style: styleObj, maxLength: maxLength, onInput: ev => this.onInput(index, ev), ref: c => (this.itemInputs[index] = c), onChange: () => this.triggerChangeEvent(), placeholder: this.invitemessage }),
        h("span", { class: "K2BT_EditCollectionItemDelete", onClick: () => this.removeItem(index) })))))));
  }
  static get is() { return "k2bt-edit-collection"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-edit-collection.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-edit-collection.css"]
  }; }
  static get properties() { return {
    "value": {
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
      },
      "defaultValue": "[]"
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
      "defaultValue": "0"
    },
    "datatype": {
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
      "attribute": "datatype",
      "reflect": false,
      "defaultValue": "K2btEditCollection.DATATYPE_CHARACTER"
    },
    "length": {
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
      "attribute": "length",
      "reflect": false,
      "defaultValue": "10"
    },
    "integers": {
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
      "attribute": "integers",
      "reflect": false,
      "defaultValue": "5"
    },
    "decimals": {
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
      "attribute": "decimals",
      "reflect": false,
      "defaultValue": "2"
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
    "inputclass": {
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
      "attribute": "inputclass",
      "reflect": false,
      "defaultValue": "''"
    },
    "readonlyclass": {
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
      "attribute": "readonlyclass",
      "reflect": false,
      "defaultValue": "''"
    },
    "invitemessage": {
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
      "attribute": "invitemessage",
      "reflect": false,
      "defaultValue": "''"
    }
  }; }
  static get events() { return [{
      "method": "inputEvent",
      "name": "input",
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
      "method": "changeEvent",
      "name": "change",
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
K2btEditCollection.DATATYPE_CHARACTER = 'CHAR';
K2btEditCollection.DATATYPE_NUMERIC = 'NUMERIC';
