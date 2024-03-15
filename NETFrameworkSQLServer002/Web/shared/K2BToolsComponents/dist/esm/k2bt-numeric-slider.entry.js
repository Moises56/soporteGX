import { r as registerInstance, c as createEvent, h, H as Host } from './index-93e0a246.js';

const k2btNumericSliderCss = ":host{display:block}.K2BT_NumericSliderContainer{max-width:300px;display:flex;flex-direction:row}.K2BT_NumericSliderControl{margin-right:8px}input[type='range']{-webkit-appearance:none;width:100%;background:transparent;}input[type='range']:focus{outline:none;}input[type='range']::-webkit-slider-thumb{border:none;-webkit-appearance:none;height:16px;width:16px;border-radius:8px;background:#019f0c;cursor:pointer;margin-top:-4px}input[type='range']::-webkit-slider-thumb:hover{background:#01890a}input[type='range']::-moz-range-thumb{border:none;height:16px;width:16px;border-radius:8px;background:#019f0c;cursor:pointer;box-sizing:border-box}input[type='range']::-moz-range-thumb:hover{background:#01890a}input[type='range']::-ms-thumb{border:none;height:16px;width:16px;border-radius:3px;background:#019f0c;cursor:pointer}input[type='range']::-ms-thumb:hover{background:#01890a}input[type='range']::-webkit-slider-runnable-track{width:100%;height:8.4px;cursor:pointer;background:#ebebeb;border-radius:1.3px}input[type='range']::-moz-range-track{width:100%;height:8.4px;cursor:pointer;background:#ebebeb;border-radius:1.3px}input[type='range']::-moz-range-progress{background:#019f0c32;height:8.4px}input[type='range']::-ms-track{width:100%;height:8.4px;cursor:pointer;background:transparent;border-color:transparent;border-width:16px 0;color:transparent}input[type='range']::-ms-fill-lower{background:#019f0c32;border-radius:2.6px}input[type='range']:focus::-ms-fill-lower{background:#019f0c32}input[type='range']::-ms-fill-upper{background:#ebebeb;border:0.2px solid #010101;border-radius:2.6px;box-shadow:1px 1px 1px #000000, 0px 0px 1px #0d0d0d}input[type='range']:focus::-ms-fill-upper{background:#ebebeb}";

const K2btNumericSlider = class {
  constructor(hostRef) {
    registerInstance(this, hostRef);
    this.inputEvent = createEvent(this, "input", 7);
    this.changeEvent = createEvent(this, "change", 7);
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
    return (h(Host, null, h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} }, h("span", { class: readonlyClassString, "data-gx-readonly": "" }, this.value)), h("div", { class: "K2BT_NumericSliderContainer", style: !this.enabled ? { display: 'none' } : {} }, h("input", { type: "range", min: this.min, max: this.max, step: this.step, class: inputClasses, value: this.value, ref: el => (this.nativeInput = el), onInput: () => this.onSliderInput(), onChange: () => this.changeEvent.emit() }), h("span", { style: this.numbervisible && this.numberreadonly ? { minWidth: this.max.toString().length + 3 + 'ch', textAlign: 'right' } : { display: 'none' }, class: readonlyClassString, "data-gx-readonly": "" }, this.value), h("input", { type: "text", inputmode: "numeric", class: auxiliaryInputClasses, value: this.value, ref: el => (this.auxiliaryInput = el), onInput: () => this.onAuxiliaryInput(), onChange: () => this.changeEvent.emit(), size: this.max.toString().length, style: this.numbervisible && !this.numberreadonly ? {} : { display: 'none' } }))));
  }
};
K2btNumericSlider.style = k2btNumericSliderCss;

export { K2btNumericSlider as k2bt_numeric_slider };
