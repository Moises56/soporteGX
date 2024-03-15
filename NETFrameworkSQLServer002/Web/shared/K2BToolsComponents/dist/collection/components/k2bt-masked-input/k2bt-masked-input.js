import { Component, h, Prop, Event, Method } from '@stencil/core';
import Inputmask from 'inputmask';
export class K2btMaskedInput {
  constructor() {
    this.enabled = true;
    this.uppercase = false;
    this.nativeInput = null;
    this.SYMBOL_OPTIONAL_DIGIT = 'Z';
    this.SYMBOL_OPTIONAL_LETTER = 'B';
    this.SYMBOL_DIGIT = '9';
    this.SYMBOL_LETTER = 'A';
    this.SYMBOL_CHARACTER = 'X';
    this.SYMBOL_ESCAPE = '\\';
    this.SYMBOL_MASK_SEPARATOR = ';';
    this.LANGUAGE_SYMBOLS = [
      this.SYMBOL_OPTIONAL_DIGIT,
      this.SYMBOL_OPTIONAL_LETTER,
      this.SYMBOL_DIGIT,
      this.SYMBOL_LETTER,
      this.SYMBOL_CHARACTER,
      this.SYMBOL_ESCAPE,
      this.SYMBOL_MASK_SEPARATOR,
    ];
    this.INPUTMASK_SPECIAL_CHARS = 'a9X[]{}()|\\';
    this.changeTimeout = null;
  }
  async getUnformattedValue() {
    var _a, _b, _c;
    // @ts-ignore
    return (_c = (_b = (_a = this.nativeInput) === null || _a === void 0 ? void 0 : _a.inputmask) === null || _b === void 0 ? void 0 : _b.unmaskedvalue()) !== null && _c !== void 0 ? _c : '';
  }
  async getFormattedValue() {
    var _a, _b;
    // @ts-ignore
    return (_b = (_a = this.nativeInput) === null || _a === void 0 ? void 0 : _a.value) !== null && _b !== void 0 ? _b : '';
  }
  componentDidLoad() {
    if (this.mask) {
      this.getInputMask().mask(this.nativeInput);
    }
  }
  getInputMask() {
    return Inputmask(this.getTransformedMask(this.mask), {
      numericInput: this.numeric,
      keepStatic: true,
      jitMasking: true,
      positionCaretOnTab: !this.numeric,
      casing: this.uppercase ? 'upper' : null,
      definitions: {
        X: {
          validator: '[A-Za-z0-9]',
        },
      },
    });
  }
  getTransformedMask(mask) {
    mask = this.reorderOptionalCharacters(mask);
    var pos = 0; // start processing at beggining
    var result = [];
    while (pos < mask.length) {
      var currentMaskBuffer = '';
      var startNewMask = false;
      // if input is numeric, check if trailing zeroes exist
      if (this.numeric && mask[pos] == this.SYMBOL_OPTIONAL_DIGIT) {
        var closing = ']';
        currentMaskBuffer += '[9';
        pos++;
        var exit_numeric_preamble = false;
        while (pos < mask.length && !exit_numeric_preamble) {
          switch (mask[pos]) {
            case this.SYMBOL_OPTIONAL_DIGIT:
              currentMaskBuffer += '[9';
              closing += ']';
              pos++;
              break;
            case this.SYMBOL_CHARACTER:
            case this.SYMBOL_DIGIT:
            case this.SYMBOL_LETTER:
            case this.SYMBOL_MASK_SEPARATOR:
            case this.SYMBOL_OPTIONAL_LETTER:
              exit_numeric_preamble = true;
              break;
            case this.SYMBOL_ESCAPE:
              pos++; // Move over to next character and treat it as a literal character (default case)
            default:
              currentMaskBuffer = '[' + currentMaskBuffer + closing + this.escape_char(mask[pos]) + ']';
              closing = '';
              pos++;
              break;
          }
        }
        currentMaskBuffer += closing;
      }
      var escaping = false;
      while (pos < mask.length && !startNewMask) {
        if (!escaping) {
          switch (mask[pos]) {
            case this.SYMBOL_MASK_SEPARATOR:
              startNewMask = true;
              break;
            case this.SYMBOL_DIGIT:
            case this.SYMBOL_CHARACTER:
              currentMaskBuffer += mask[pos];
              break;
            case this.SYMBOL_LETTER:
              currentMaskBuffer += 'a';
              break;
            case this.SYMBOL_OPTIONAL_DIGIT:
              currentMaskBuffer += '[9]';
              break;
            case this.SYMBOL_OPTIONAL_LETTER:
              currentMaskBuffer += '[a]';
              break;
            case this.SYMBOL_ESCAPE:
              escaping = true;
            default:
              currentMaskBuffer += this.escape_char(mask[pos]);
          }
        }
        else {
          escaping = false;
          currentMaskBuffer += this.escape_char(mask[pos]);
        }
        pos++;
      }
      result.push(currentMaskBuffer);
    }
    return result;
  }
  reorderOptionalCharacters(mask) {
    var maskArray = [...mask];
    for (var i = 1; i < mask.length; i++) {
      var j = i;
      while ((maskArray[j - 1] == this.SYMBOL_OPTIONAL_LETTER && maskArray[j] == this.SYMBOL_LETTER) ||
        (maskArray[j - 1] == this.SYMBOL_OPTIONAL_DIGIT && maskArray[j] == this.SYMBOL_DIGIT)) {
        var temp = maskArray[j];
        maskArray[j] = maskArray[j - 1];
        maskArray[j - 1] = temp;
        j--;
      }
    }
    return maskArray.join('');
  }
  escape_char(c) {
    if (this.INPUTMASK_SPECIAL_CHARS.indexOf(c) != -1)
      return '\\' + c;
    else
      return c;
  }
  onInput() {
    clearTimeout(this.changeTimeout);
    var component = this;
    this.changeTimeout = setTimeout(function () {
      component.inputEvent.emit({ value: component.nativeInput.value });
    }, 300);
  }
  render() {
    var styleObj = {};
    if (!this.enabled) {
      styleObj.display = 'none';
    }
    if (this.numeric) {
      styleObj.textAlign = 'right';
    }
    var classString = this.inputclass;
    var readonlyClassString = this.readonlyclass + ' ' + this.inputclass;
    return (h("div", null,
      h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} },
        h("span", { class: readonlyClassString, "data-gx-readonly": "" }, !this.enabled ? this.getInputMask().format(this.value) : '')),
      h("input", { type: "text", inputmode: "text", class: 'form-control ' + classString, value: this.value, ref: el => (this.nativeInput = el), onInput: () => this.onInput(), onChange: () => this.changeEvent.emit(), style: styleObj })));
  }
  static get is() { return "k2bt-masked-input"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-masked-input.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-masked-input.css"]
  }; }
  static get properties() { return {
    "mask": {
      "type": "string",
      "mutable": false,
      "complexType": {
        "original": "string",
        "resolved": "string",
        "references": {}
      },
      "required": false,
      "optional": true,
      "docs": {
        "tags": [],
        "text": ""
      },
      "attribute": "mask",
      "reflect": false
    },
    "numeric": {
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
      "attribute": "numeric",
      "reflect": false
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
      "reflect": false
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
      "reflect": false
    },
    "uppercase": {
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
      "attribute": "uppercase",
      "reflect": false,
      "defaultValue": "false"
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
  static get methods() { return {
    "getUnformattedValue": {
      "complexType": {
        "signature": "() => Promise<any>",
        "parameters": [],
        "references": {
          "Promise": {
            "location": "global"
          }
        },
        "return": "Promise<any>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    },
    "getFormattedValue": {
      "complexType": {
        "signature": "() => Promise<string>",
        "parameters": [],
        "references": {
          "Promise": {
            "location": "global"
          }
        },
        "return": "Promise<string>"
      },
      "docs": {
        "text": "",
        "tags": []
      }
    }
  }; }
}
