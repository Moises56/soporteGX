import { Component, h, Prop, Listen, Event, Watch } from '@stencil/core';
export class K2btNumericInput {
  constructor() {
    this.decimals = 2;
    this.integerdigits = 10;
    this.includethousandseparator = true;
    this.includesign = false;
    this.usermustenterdecimalseparator = true;
    this.decimalseparator = '.';
    this.thousandseparator = ',';
    this.valueprefix = '';
    this.zeropadding = false;
    this.inputclass = '';
    this.readonlyclass = '';
    this.editorPosition = 0;
    this.value = '0';
    this.changeTimeout = null;
  }
  onInput() {
    clearTimeout(this.changeTimeout);
    var component = this;
    this.changeTimeout = setTimeout(function () {
      component.inputEvent.emit({ value: component.inputControl.value });
    }, 300);
  }
  /*
  This method must determine if this keypress should be accepted or not.

  In some cases it should move the cursor or alter how the keypress should be processed.
  */
  handleKeydown(event) {
    if (event.key != 'Tab' && event.key != 'Shift' && this.inputControl.selectionStart == 0 && this.inputControl.selectionEnd == this.inputControl.value.length) {
      this.inputControl.value = this.getFormattedValue_impl('0');
      if (!this.usermustenterdecimalseparator) {
        this.setCursorPosition(this.inputControl.value.length);
      }
    }
    var preventDefault = false;
    const currentPosition = this.getCursorPosition();
    if (event.key == 'Delete' || event.key == 'Backspace') {
      preventDefault = this.processDelete(event, currentPosition);
    }
    else if (event.key == this.decimalseparator) {
      preventDefault = this.processDecimalSeparator();
    }
    else if (event.key == '-') {
      preventDefault = this.processMinusSign(currentPosition);
    }
    else if (K2btNumericInput.digits.includes(event.key)) {
      preventDefault = this.processDigitInsertion(event, currentPosition);
    }
    else if (event.key.length == 1 && !event.ctrlKey) {
      // ignore all other keys
      preventDefault = true;
    }
    if (preventDefault) {
      event.preventDefault();
      return false;
    }
  }
  processMinusSign(currentPosition) {
    var preventDefault = true; // Generally this key should not be processed
    const firstDigitPosition = Math.min(...K2btNumericInput.digits.map(d => this.inputControl.value.indexOf(d)).filter(i => i != -1));
    if (this.includesign && currentPosition == firstDigitPosition && this.inputControl.value[firstDigitPosition - 1] != '-') {
      // If the number should support sign, the cursor is in the position is where the sign should be added, and no minus sign is there, this keypress should be processed
      preventDefault = false;
    }
    return preventDefault;
  }
  processDecimalSeparator() {
    var preventDefault = false;
    if (this.inputControl.value.charAt(this.getCursorPosition()) == this.decimalseparator) {
      this.setCursorPosition(this.getCursorPosition() + 1);
    }
    var selectionBegin = Math.min(this.inputControl.selectionStart, this.inputControl.selectionEnd);
    var selectionFinish = Math.max(this.inputControl.selectionStart, this.inputControl.selectionEnd);
    if (this.decimals > 0 && selectionBegin == 0 && selectionFinish == this.inputControl.value.length) {
      this.setCursorPosition(this.inputControl.value.indexOf(this.decimalseparator) + 1);
    }
    if (this.inputControl.value.indexOf(this.decimalseparator) != -1 || this.decimals == 0) {
      preventDefault = true;
    }
    return preventDefault;
  }
  processDigitInsertion(event, currentPosition) {
    var decimalPosition = this.inputControl.value.indexOf(this.decimalseparator);
    if (event.key == '0') {
      // ignore non-significant zeroes
      const firstSignificantDigitPosition = Math.min(...K2btNumericInput.digits
        .filter(d => d != '0')
        .map(d => this.inputControl.value.indexOf(d))
        .filter(i => i != -1));
      if (firstSignificantDigitPosition != -1 &&
        !((decimalPosition != -1 && currentPosition > decimalPosition) || (firstSignificantDigitPosition != -1 && currentPosition > firstSignificantDigitPosition))) {
        return true; // prevent default
      }
    }
    var preventDefault = false;
    if (!this.usermustenterdecimalseparator && currentPosition == this.inputControl.value.length) {
      // This digit is inserted at the end of the number, and the configuration is set for ATM-style.
      // Because of this, the current digits should be left shifted and the new digit added at the end.
      // The decimal separator should stay in place.
      // The digit should be ignored if the amount of digits matches the definition for integer digits + decimals
      var newdigits = (this.inputControl.value.replace(/\D/g, '') + event.key).replace(/^0+/, '');
      if (newdigits.length <= this.decimals + this.integerdigits) {
        if (newdigits.length <= this.decimals) {
          this.inputControl.value = this.getFormattedValue_impl('0.' + '0'.repeat(this.decimals - newdigits.length) + newdigits);
        }
        else {
          this.inputControl.value = this.getFormattedValue_impl(newdigits.substring(0, newdigits.length - this.decimals) + '.' + newdigits.substring(newdigits.length - this.decimals));
        }
        preventDefault = true;
        this.onInputChange();
      }
      preventDefault = true;
    }
    else {
      if (this.decimals > 0 && decimalPosition != -1 && decimalPosition < currentPosition) {
        // The digit is inserted after the decimal sign.
        // Check that the current position is not after the last accepted decimal.
        if (this.decimals != currentPosition - decimalPosition - 1) {
          // If it's not after the last decimal, the "next" digit should be overwritten and the cursor should be moved to the next position.
          this.inputControl.value = this.inputControl.value.substring(0, this.getCursorPosition()) + event.key + this.inputControl.value.substring(this.getCursorPosition() + 1);
          this.setCursorPosition(currentPosition + 1);
        }
        preventDefault = true;
      }
      else {
        // The digit is not in the decimal part.
        var integerPart = this.inputControl.value;
        if (this.decimals > 0 && decimalPosition != -1) {
          integerPart = integerPart.substring(0, integerPart.indexOf(this.decimalseparator));
        }
        // Input is in integer part
        var currentDigits = integerPart.replace(/\D/g, '').replace(/^0+/, '').length;
        if (currentDigits >= this.integerdigits) {
          // If integer part is complete, discard this keypress
          preventDefault = true;
        }
        else {
          if (currentDigits == 0) {
            if (this.inputControl.value.indexOf(this.decimalseparator) != -1) {
              this.inputControl.value = this.getFormattedValue_impl(event.key + this.value.substring(this.value.indexOf(this.decimalseparator)));
            }
            else {
              this.inputControl.value = this.getFormattedValue_impl(event.key);
              this.setCursorPosition(this.inputControl.value.length);
            }
            if (this.inputControl.value.indexOf(this.decimalseparator) != -1) {
              this.setCursorPosition(this.inputControl.value.indexOf(this.decimalseparator));
            }
            else {
              this.setCursorPosition(this.inputControl.value.length);
            }
            preventDefault = true;
            this.onInputChange();
          }
        }
      }
    }
    return preventDefault;
  }
  processDelete(event, currentPosition) {
    var preventDefault = false;
    var selectionBegin = Math.min(this.inputControl.selectionStart, this.inputControl.selectionEnd);
    var selectionFinish = Math.max(this.inputControl.selectionStart, this.inputControl.selectionEnd);
    if (selectionBegin == 0 && selectionFinish == this.inputControl.value.length) {
      this.inputControl.value = this.getFormattedValue_impl('0');
      if (this.usermustenterdecimalseparator) {
        // If user must enter decimal separator, place cursor in the unit's place
        this.setCursorPosition(this.inputControl.value.indexOf(this.decimalseparator) == -1 ? this.inputControl.value.length : this.inputControl.value.indexOf(this.decimalseparator));
      }
      else {
        // Else, place it at the end
        this.setCursorPosition(this.inputControl.value.length);
      }
      preventDefault = true;
      this.onInputChange();
    }
    else if (selectionBegin != selectionFinish) {
      // The user has selected a range delete it
      var newValue = this.inputControl.value.substring(0, selectionBegin) + this.inputControl.value.substring(selectionFinish);
      newValue = newValue.replace(/\D/g, '');
      this.inputControl.value = this.getFormattedValue_impl(newValue.substring(0, newValue.length - this.decimals) + '.' + newValue.substring(newValue.length - this.decimals));
      preventDefault = true;
      // Adjust cursor position
      if (event.key == 'Backspace')
        this.setCursorPosition(selectionBegin);
      else
        this.setCursorPosition(selectionFinish);
      this.onInputChange();
    }
    else if (event.key == 'Backspace') {
      if (!this.usermustenterdecimalseparator && currentPosition == this.inputControl.value.length) {
        var newdigits = this.inputControl.value.replace(/\D/g, '').replace(/^0+/, '');
        newdigits = newdigits.substring(0, newdigits.length - 1);
        var decimals = newdigits.substring(newdigits.length - this.decimals);
        decimals = '0'.repeat(this.decimals - decimals.length) + decimals;
        this.value = newdigits.substring(0, newdigits.length - this.decimals) + '.' + decimals;
        preventDefault = true;
      }
      else {
        if (this.inputControl.value.charAt(this.getCursorPosition() - 1) == this.thousandseparator ||
          this.inputControl.value.charAt(this.getCursorPosition() - 1) == this.decimalseparator) {
          this.setCursorPosition(this.getCursorPosition() - 1);
          preventDefault = true;
        }
        else if (selectionBegin == 0 && this.inputControl.value.charAt(selectionFinish) == this.decimalseparator) {
          const currentPosition = this.getCursorPosition();
          this.inputControl.value = this.inputControl.value.substring(0, this.getCursorPosition() - 1) + this.inputControl.value.substring(this.getCursorPosition());
          this.setCursorPosition(currentPosition - 1);
          preventDefault = true;
          this.onInputChange();
        }
      }
    }
    else if (event.key == 'Delete') {
      if (this.inputControl.value.charAt(this.getCursorPosition()) == this.thousandseparator || this.inputControl.value.charAt(this.getCursorPosition()) == this.decimalseparator) {
        this.setCursorPosition(this.getCursorPosition() + 1);
        preventDefault = true;
      }
      else if (selectionBegin == 0 && this.inputControl.value.charAt(selectionFinish + 1) == this.decimalseparator) {
        this.inputControl.value = this.inputControl.value.substring(0, this.getCursorPosition() - 1) + this.inputControl.value.substring(this.getCursorPosition() + 1);
        this.setCursorPosition(currentPosition);
        preventDefault = true;
        this.onInputChange();
      }
    }
    return preventDefault;
  }
  escapeRegExp(string) {
    return string.replace(/[.*+\-?^${}()|[\]\\]/g, '\\$&'); // $& means the whole matched string
  }
  replaceAll(str, find, replace) {
    return str.replace(new RegExp(this.escapeRegExp(find), 'g'), replace);
  }
  onInputChange() {
    // the contents were changed, try to parse the value
    var originalValue = this.inputControl.value;
    var previousValue = this.value;
    this.editorPosition = this.getCursorPosition();
    this.value = this.inputControl.value.replace(new RegExp('[^\\d' + this.decimalseparator + '-]', 'g'), '').replace(/^0+/, '');
    if (this.value[0] == this.decimalseparator)
      this.value = '0' + this.value;
    if (Number.isNaN(this.value))
      this.value = '0';
    this.inputControl.value = this.getFormattedValue();
    var previousDigits = previousValue.indexOf(this.decimalseparator) == -1 ? previousValue.length : previousValue.indexOf(this.decimalseparator);
    var currentDigits = this.value.indexOf(this.decimalseparator) == -1 ? this.value.length : this.value.indexOf(this.decimalseparator);
    if (this.includethousandseparator && !this.zeropadding) {
      if (currentDigits > previousDigits && currentDigits % 3 == 1) {
        this.editorPosition = this.editorPosition + 1;
      }
      else if (currentDigits < previousDigits && currentDigits % 3 == 0) {
        if (originalValue.substring(0, this.editorPosition) != this.getFormattedValue().substring(0, this.editorPosition)) {
          this.editorPosition = this.editorPosition - 1;
        }
      }
    }
    else if (this.zeropadding) {
      this.editorPosition = this.inputControl.value.length - originalValue.length + this.editorPosition;
    }
  }
  setCursorPosition(val) {
    this.inputControl.selectionStart = val;
    this.inputControl.selectionEnd = val;
  }
  getCursorPosition() {
    if (!this.inputControl)
      return; // No (input) element found
    if ('selectionStart' in this.inputControl) {
      // Standard-compliant browsers
      return this.inputControl.selectionStart;
    }
    else {
      //@ts-ignore
      var sel = document.selection;
      if (sel) {
        // IE
        //@ts-ignore
        this.inputControl.focus();
        var sel = sel.createRange();
        var selLen = sel.createRange().text.length;
        //@ts-ignore
        sel.moveStart('character', -this.inputControl.value.length);
        return sel.text.length - selLen;
      }
    }
  }
  getFormattedValue() {
    return this.getFormattedValue_impl(this.value);
  }
  getFormattedValue_impl(value) {
    var result = '';
    if (this.valueprefix != '')
      result = this.valueprefix + ' ';
    if (value.startsWith('-'))
      result = result + '-';
    const decimalSeparatorPosition = value.indexOf(this.decimalseparator);
    // now include integer part
    var integerPart = (decimalSeparatorPosition != -1 ? value.substring(0, decimalSeparatorPosition) : value).replace('-', '');
    if (this.zeropadding)
      integerPart = '0'.repeat(this.integerdigits - integerPart.length) + integerPart;
    if (this.includethousandseparator) {
      var pendingdigits = integerPart;
      var withSeparator = '';
      while (pendingdigits.length > 3) {
        withSeparator = this.thousandseparator + pendingdigits.substring(pendingdigits.length - 3) + withSeparator;
        pendingdigits = pendingdigits.substring(0, pendingdigits.length - 3);
      }
      withSeparator = pendingdigits + withSeparator;
      result = result + withSeparator;
    }
    else {
      result = result + integerPart;
    }
    // now include decimal part
    if (this.decimals > 0) {
      var decimalValue = decimalSeparatorPosition != -1 ? value.substring(value.indexOf(this.decimalseparator) + 1) : '';
      result = result + this.decimalseparator + decimalValue.substring(0, this.decimals);
      if (this.decimals - decimalValue.length > 0)
        result = result + '0'.repeat(this.decimals - decimalValue.length);
    }
    return result;
  }
  render() {
    var styleObj = {};
    if (!this.enabled) {
      styleObj.display = 'none';
    }
    styleObj.textAlign = 'right';
    var classString = this.inputclass;
    var readonlyClassString = this.readonlyclass + ' ' + this.inputclass;
    return (h("div", null,
      h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} },
        h("span", { class: readonlyClassString, "data-gx-readonly": "" }, this.value)),
      h("input", { class: 'form-control ' + classString, type: "text", ref: c => (this.inputControl = c), style: styleObj, onInput: () => this.onInputChange(), onBlur: () => this.onInputChange(), onChange: () => this.changeEvent.emit() })));
  }
  componentDidRender() {
    this.inputControl.value = this.getFormattedValue();
  }
  componentDidUpdate() {
    if (this.editorPosition != -1) {
      this.setCursorPosition(this.editorPosition);
      this.editorPosition = -1;
    }
  }
  static get is() { return "k2bt-numeric-input"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-numeric-input.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-numeric-input.css"]
  }; }
  static get properties() { return {
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
    "integerdigits": {
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
      "attribute": "integerdigits",
      "reflect": false,
      "defaultValue": "10"
    },
    "includethousandseparator": {
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
      "attribute": "includethousandseparator",
      "reflect": false,
      "defaultValue": "true"
    },
    "includesign": {
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
      "attribute": "includesign",
      "reflect": false,
      "defaultValue": "false"
    },
    "usermustenterdecimalseparator": {
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
      "attribute": "usermustenterdecimalseparator",
      "reflect": false,
      "defaultValue": "true"
    },
    "decimalseparator": {
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
      "attribute": "decimalseparator",
      "reflect": false,
      "defaultValue": "'.'"
    },
    "thousandseparator": {
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
      "attribute": "thousandseparator",
      "reflect": false,
      "defaultValue": "','"
    },
    "valueprefix": {
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
      "attribute": "valueprefix",
      "reflect": false,
      "defaultValue": "''"
    },
    "zeropadding": {
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
      "attribute": "zeropadding",
      "reflect": false,
      "defaultValue": "false"
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
      "defaultValue": "'0'"
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
      "reflect": false
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
  static get watchers() { return [{
      "propName": "value",
      "methodName": "onInput"
    }]; }
  static get listeners() { return [{
      "name": "keydown",
      "method": "handleKeydown",
      "target": undefined,
      "capture": true,
      "passive": false
    }]; }
}
K2btNumericInput.digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
