import { Component, Host, h, Prop, Event } from '@stencil/core';
export class K2btNumericSlider {
  constructor() {
    this.value = '';
    this.readonlyclass = '';
    this.enabled = true;
    this.changeTimeout = null;
  }
  onAuxiliaryInput() {
    clearTimeout(this.changeTimeout);
    var component = this;
    this.value = this.auxiliaryInput.value;
    this.changeTimeout = setTimeout(function () {
      component.inputEvent.emit({ value: component.nativeInput.value });
    }, 300);
  }
  onSliderInput() {
    clearTimeout(this.changeTimeout);
    var component = this;
    this.value = this.nativeInput.value;
    this.changeTimeout = setTimeout(function () {
      component.inputEvent.emit({ value: component.nativeInput.value });
    }, 300);
  }
  render() {
    var inputClasses = 'K2BT_NumericSliderControl ' + this.sliderclass;
    var auxiliaryInputClasses = 'K2BT_NumericSliderAuxiliaryInput form-control ' + this.numberclass;
    var readonlyClassString = this.readonlyclass;
    return (h(Host, null,
      h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} },
        h("span", { class: readonlyClassString, "data-gx-readonly": "" }, this.value)),
      h("div", { class: "K2BT_NumericSliderContainer", style: !this.enabled ? { display: 'none' } : {} },
        h("input", { type: "range", min: this.min, max: this.max, step: this.step, class: inputClasses, value: this.value, ref: el => (this.nativeInput = el), onInput: () => this.onSliderInput(), onChange: () => this.changeEvent.emit() }),
        h("span", { style: this.numbervisible && this.numberreadonly ? { minWidth: this.max.toString().length + 3 + 'ch', textAlign: 'right' } : { display: 'none' }, class: readonlyClassString, "data-gx-readonly": "" }, this.value),
        h("input", { type: "text", inputmode: "numeric", class: auxiliaryInputClasses, value: this.value, ref: el => (this.auxiliaryInput = el), onInput: () => this.onAuxiliaryInput(), onChange: () => this.changeEvent.emit(), size: this.max.toString().length, style: this.numbervisible && !this.numberreadonly ? {} : { display: 'none' } }))));
  }
  static get is() { return "k2bt-numeric-slider"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-numeric-slider.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-numeric-slider.css"]
  }; }
  static get properties() { return {
    "max": {
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
      "attribute": "max",
      "reflect": false
    },
    "min": {
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
      "attribute": "min",
      "reflect": false
    },
    "step": {
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
      "attribute": "step",
      "reflect": false
    },
    "numbervisible": {
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
      "attribute": "numbervisible",
      "reflect": false
    },
    "numberreadonly": {
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
      "attribute": "numberreadonly",
      "reflect": false
    },
    "numberclass": {
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
      "attribute": "numberclass",
      "reflect": false
    },
    "sliderclass": {
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
      "attribute": "sliderclass",
      "reflect": false
    },
    "value": {
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
      "attribute": "value",
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
