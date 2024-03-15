'use strict';

Object.defineProperty(exports, '__esModule', { value: true });

const index = require('./index-4aad5e76.js');

const K2btBaseColorPicker = class {
  constructor(hostRef) {
    index.registerInstance(this, hostRef);
    this.selectionChangedEvent = index.createEvent(this, "selectionChanged", 7);
    this.selectionErrorEvent = index.createEvent(this, "selectionError", 7);
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
    return (index.h("div", { class: sectionClass }, this.getColorRows().map(r => {
      return (index.h("div", { class: "K2BT_BaseColorPickerRow" }, r.map(c => {
        var style = { backgroundColor: c.colorCode };
        var itemClass = 'K2BT_BaseColorPickerItem' + (this.colorIsSelected(c) ? ' K2BT_BaseColorPickerItemSelected' : '');
        return index.h("div", { class: itemClass, style: style, title: c.description, onClick: () => this.selectColor(c) });
      })));
    })));
  }
};
K2btBaseColorPicker.ERROR_SELECTION_FULL = 'SELECTION_FULL';

exports.k2bt_base_color_picker = K2btBaseColorPicker;
