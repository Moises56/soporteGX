import { Component, Host, h, Prop, Event } from '@stencil/core';
export class K2btSignaturePad {
  constructor() {
    this.width = 300;
    this.height = 200;
    this.backgroundimageurl = '';
    this.backgroundcolor = '#FFFFFF';
    this.showclearbutton = true;
    this.clearbuttoncaption = 'Clear';
    this.canvas = null;
    this.ctx = null;
    this.isWriting = false;
    this.setValueDebouncer = null;
  }
  render() {
    var _a, _b;
    var style = {
      backgroundImage: ((_a = this.backgroundimageurl) !== null && _a !== void 0 ? _a : '') !== '' ? 'url(' + this.backgroundimageurl + ')' : null,
      backgroundColor: ((_b = this.backgroundcolor) !== null && _b !== void 0 ? _b : '') !== '' ? this.backgroundcolor : null,
    };
    console.log(style);
    return (h(Host, null,
      h("div", { class: "K2BT_SignaturePadContainer", style: style },
        h("canvas", { height: this.height, width: this.width, class: "K2BT_SignaturePad", ref: canvas => {
            this.canvas = canvas;
            this.ctx = canvas.getContext('2d');
          } })),
      this.showclearbutton ? (h("button", { class: "K2BT_SignaturePadClearButton", onClick: this.clearCanvas.bind(this) }, this.clearbuttoncaption)) : ('')));
  }
  componentDidRender() {
    this.canvas.addEventListener('pointerdown', this.handlePointerDown.bind(this), { passive: true });
    document.addEventListener('pointerup', this.handlePointerUp.bind(this), { passive: true });
    this.canvas.addEventListener('pointermove', this.handlePointerMove.bind(this), { passive: true });
  }
  clearCanvas() {
    this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
  }
  handlePointerDown(event) {
    this.isWriting = true;
    this.ctx.beginPath();
    const [positionX, positionY] = this.getCursorPosition(event);
    this.ctx.moveTo(positionX, positionY);
  }
  handlePointerUp() {
    var wasWriting = this.isWriting;
    this.isWriting = false;
    if (wasWriting) {
      if (this.setValueDebouncer !== null) {
        clearTimeout(this.setValueDebouncer);
      }
      this.setValueDebouncer = setTimeout((() => {
        this.setValueDebouncer = null;
        this.changeEvent.emit(this.canvas.toDataURL());
      }).bind(this), 200);
    }
  }
  handlePointerMove(event) {
    if (!this.isWriting)
      return;
    const [positionX, positionY] = this.getCursorPosition(event);
    this.ctx.lineTo(positionX, positionY);
    this.ctx.stroke();
  }
  getCursorPosition(event) {
    var positionX = event.clientX - event.target.getBoundingClientRect().x;
    var positionY = event.clientY - event.target.getBoundingClientRect().y;
    return [positionX, positionY];
  }
  static get is() { return "k2bt-signature-pad"; }
  static get properties() { return {
    "width": {
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
      "attribute": "width",
      "reflect": false,
      "defaultValue": "300"
    },
    "height": {
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
      "attribute": "height",
      "reflect": false,
      "defaultValue": "200"
    },
    "backgroundimageurl": {
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
      "attribute": "backgroundimageurl",
      "reflect": false,
      "defaultValue": "''"
    },
    "backgroundcolor": {
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
      "attribute": "backgroundcolor",
      "reflect": false,
      "defaultValue": "'#FFFFFF'"
    },
    "showclearbutton": {
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
      "attribute": "showclearbutton",
      "reflect": false,
      "defaultValue": "true"
    },
    "clearbuttoncaption": {
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
      "attribute": "clearbuttoncaption",
      "reflect": false,
      "defaultValue": "'Clear'"
    }
  }; }
  static get events() { return [{
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
        "original": "string",
        "resolved": "string",
        "references": {}
      }
    }]; }
}
