import { Component, h, Prop, Event, Listen, Method } from '@stencil/core';
import { ControlInfoValue } from '../../utils/utils';
export class K2btEnhancedsuggest {
  constructor() {
    this.value = [];
    this.noresultsfoundtext = 'No results found';
    this.enableadditem = true;
    this.additemcaption = 'New record';
    this.enabled = true;
    this.readonlyclass = '';
    this.searchvalue = '';
    this.placeholder = '';
    this.selectedValueDescription = '';
    this.maxSelectionSize = 1;
    this.suggestmaxitems = 5;
    this.activeElementValue = null;
    this.showiconsintags = true;
    this.emptyitemtext = '(none)';
    this.container = null;
    this.selectedElement = null;
    this.searchfield = null;
    // See problem with transactions in display mode in 0022649: Soportar datasource dataprovider en extended suggest
    this.seekSuggestValuesForMissingValueExecuted = false;
    this.seekSuggestValuesDebouncer = null;
  }
  isCollection() {
    return this.maxSelectionSize != 1;
  }
  // @ts-ignore
  selectionIsFull() {
    return this.isCollection() && this.maxSelectionSize != 0 && this.maxSelectionSize <= this.value.length;
  }
  itemIsSelected(item) {
    var _a, _b;
    return ((_b = (_a = this.value) === null || _a === void 0 ? void 0 : _a.filter(selectedItem => selectedItem.toString().trim() == item.value.toString().trim()).length) !== null && _b !== void 0 ? _b : 0) > 0;
  }
  async setFocusToSearch() {
    if (this.searchfield != null)
      this.searchfield.focus();
  }
  async updateDescription() {
    if (!this.isCollection()) {
      const atomicValues = this.getAtomicValues();
      const selectedItems = atomicValues.filter(value => this.itemIsSelected(value));
      const selectedItemCount = selectedItems.length;
      if (selectedItemCount > 0) {
        this.searchvalue = this.getValueDescription();
        this.seekSuggestValuesForMissingValueExecuted = false;
      }
      else {
        if (!this.seekSuggestValuesForMissingValueExecuted) {
          this.inputValueChangedEvent.emit(null);
          this.seekSuggestValuesForMissingValueExecuted = true;
        }
        this.searchvalue = '';
      }
    }
  }
  processInput(event) {
    if (event.target == this.searchfield) {
      this.changeSearchValue(this.searchfield.value);
    }
    event.stopPropagation();
    return false;
  }
  processKeydown(event) {
    if (event.key === 'Escape') {
      this.open = false;
      event.stopPropagation();
    }
    if (event.key === 'Tab')
      this.open = false;
    if (!this.isCollection()) {
      this.processKeydownSingleSelection(event);
    }
    else {
      this.processKeydownCollection(event);
    }
  }
  processKeydownCollection(event) {
    if (event.key == 'Enter') {
      this.processEnterKeyWhenCollection(event);
    }
    else if (this.open) {
      if (event.key == 'ArrowDown') {
        this.processArrowDownKeyWhenCollection(event);
      }
      else if (event.key == 'ArrowUp') {
        this.processArrowUpKeyWhenCollection(event);
      }
      else if (event.key === ' ' || event.key === 'Spacebar') {
        this.processSpacebarKeyWhenCollection(event);
      }
    }
  }
  processEnterKeyWhenCollection(event) {
    if (this.open) {
      this.setValueWithoutClosing(this.activeElementValue);
      this.emitChangedEvent();
    }
    this.open = !this.open;
    event.stopPropagation();
  }
  processSpacebarKeyWhenCollection(event) {
    if (this.activeElementValue !== '' && this.activeElementValue !== null) {
      this.setValueWithoutClosing(this.activeElementValue);
      this.emitChangedEvent();
      event.stopPropagation();
      event.preventDefault();
    }
  }
  processArrowUpKeyWhenCollection(event) {
    event.stopPropagation();
    event.preventDefault();
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value == this.activeElementValue);
      if (pos == -1) {
        pos = currentValues.length - 1;
      }
      else {
        if (pos === 0)
          pos = -1;
        else
          pos -= 1;
      }
      if (pos !== -1)
        this.activeElementValue = currentValues[pos].value;
      else
        this.activeElementValue = null;
    }
  }
  processArrowDownKeyWhenCollection(event) {
    event.stopPropagation();
    event.preventDefault();
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value == this.activeElementValue);
      if (pos === -1) {
        pos = 0;
      }
      else {
        pos = (((pos + 1) % currentValues.length) + currentValues.length) % currentValues.length;
        if (pos === 0)
          pos = -1;
      }
      if (pos !== -1)
        this.activeElementValue = currentValues[pos].value;
      else
        this.activeElementValue = null;
    }
  }
  processKeydownSingleSelection(event) {
    if (event.key == 'Enter') {
      this.processEnterKeyWhenNotCollection(event);
    }
    else if (event.key == 'Tab') {
      this.processTabKeyWhenNotCollection(event);
    }
    else if (this.open) {
      if (event.key == 'ArrowDown') {
        this.processArrowDownKeyWhenNotCollection(event);
      }
      else if (event.key == 'ArrowUp') {
        this.processArrowUpKeyWhenNotCollection(event);
      }
    }
  }
  processArrowUpKeyWhenNotCollection(event) {
    event.stopPropagation();
    event.preventDefault();
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value == this.value[0]);
      if (pos == -1) {
        this.setValueWithoutClosing(currentValues[currentValues.length - 1].value);
      }
      else {
        pos = (((pos - 1) % currentValues.length) + currentValues.length) % currentValues.length;
        this.setValueWithoutClosing(currentValues[pos].value);
      }
    }
  }
  processArrowDownKeyWhenNotCollection(event) {
    event.stopPropagation();
    event.preventDefault();
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value == this.value[0]);
      if (pos == -1) {
        this.setValueWithoutClosing(currentValues[0].value);
      }
      else {
        pos = (((pos + 1) % currentValues.length) + currentValues.length) % currentValues.length;
        this.setValueWithoutClosing(currentValues[pos].value);
      }
    }
  }
  processEnterKeyWhenNotCollection(event) {
    this.open = !this.open;
    if (!this.open) {
      this.searchvalue = this.getValueDescription();
      this.emitChangedEvent();
    }
    event.stopPropagation();
  }
  processTabKeyWhenNotCollection(event) {
    if (!this.open) {
      this.searchvalue = this.getValueDescription();
      this.emitChangedEvent();
    }
    event.stopPropagation();
  }
  closeMenu(ev) {
    if (this.open && this.container && !this.container.contains(ev.target)) {
      this.open = false;
      if (!this.isCollection())
        this.setValue(this.value[0]);
    }
  }
  async setValue(value) {
    if (!this.isCollection())
      this.open = false;
    this.setValueWithoutClosing(value);
    if (!this.isCollection())
      this.searchvalue = this.getValueDescription();
    this.emitChangedEvent();
  }
  emitChangedEvent() {
    this.changeEvent.emit(this.value);
  }
  setValueWithoutClosing(value) {
    if (!this.isCollection()) {
      if (value !== null && value !== undefined)
        this.value = [value];
      else
        this.value = [];
      this.selectedValueDescription = this.getValueDescription();
    }
    else {
      if (this.value.filter(v => v.toString().trim() === value.toString().trim()).length === 0) {
        if (!this.selectionIsFull())
          this.value = this.value.concat([value]);
        else {
          this.errorCode = K2btEnhancedsuggest.ERROR_SELECTION_FULL;
          this.selectionErrorEvent.emit({});
        }
      }
      else
        this.value = this.value.filter(v => v.toString().trim() !== value.toString().trim());
    }
  }
  getRawValues() {
    var result;
    if (this.values == null) {
      result = [];
    }
    else if (typeof this.values === 'string') {
      if (this.values == '')
        result = [];
      else
        result = JSON.parse(this.values);
    }
    else {
      result = [...this.values];
    }
    return result;
  }
  getFilteredValues() {
    if (!this.open)
      return [];
    // The suggest control should not consider categories
    var result = this.getAtomicValues();
    if (this.searchvalue != '')
      result = this.getFilteredValues_impl(result);
    return result;
  }
  getFilteredValues_impl(origin) {
    var result = [];
    if (origin != undefined) {
      for (let cv of origin) {
        if (cv.description.toLocaleLowerCase().indexOf(this.searchvalue.toLocaleLowerCase()) != -1) {
          result = result.concat(cv);
        }
        else {
          // Check if child items must be added
          var filteredChildren = this.getFilteredValues_impl(cv.items);
          if (filteredChildren.length > 0) {
            var cv2 = Object.assign({}, cv);
            cv2.items = filteredChildren;
            result = result.concat(cv2);
          }
        }
      }
    }
    return result;
  }
  onIncludeNewRecordClick() {
    this.open = false;
    this.newRecordClickedEvent.emit(null);
  }
  getAtomicValues() {
    const atomicValues = ControlInfoValue.getAtomicValues_impl(this.getRawValues());
    return this.removeDuplicates(atomicValues);
  }
  removeDuplicates(atomicValues) {
    return atomicValues.filter((value, index, self) => index === self.findIndex(t => t.value === value.value));
  }
  getSuggestPopoverContent() {
    const rawValues = this.getRawValues();
    var containsDetails = ControlInfoValue.containsDetails(rawValues);
    var containsIcons = ControlInfoValue.containsIcons(rawValues);
    var containsTrailingText = ControlInfoValue.containsTrailingText(rawValues);
    const filteredValues = this.getFilteredValues().slice(0, this.suggestmaxitems);
    if (filteredValues.length > 0)
      return filteredValues.map(item => this.getItemContent(item, containsDetails, containsIcons, containsTrailingText));
    else if (this.seekSuggestValuesDebouncer)
      return h("div", { class: "K2BT_LoadingSpinner" });
    else
      return h("div", { class: "K2BTEnhancedComboNoItemsFound" }, this.noresultsfoundtext);
  }
  onImageError(e) {
    e.target.classList.add('K2BTEnhancedComboIconInvisible');
  }
  getItemContent(item, containsDetails, containsIcons, containsTrailingText) {
    var _a;
    if (((_a = item.items) === null || _a === void 0 ? void 0 : _a.length) > 0) {
      // Item is a category
      return this.getCategoryContent(item, containsDetails, containsIcons, containsTrailingText);
    }
    else {
      return this.getAtomicItemContent(item, containsIcons, containsTrailingText, containsDetails);
    }
  }
  getAtomicItemContent(item, containsIcons, containsTrailingText, containsDetails) {
    var itemClass = this.getItemClass(item);
    return (h("div", { class: itemClass, ref: c => {
        if (this.itemIsSelected(item) || this.activeElementValue === item.value)
          this.selectedElement = c;
      }, onClick: () => {
        this.setValue(item.value);
      } },
      this.addCheckboxIfNecessary(item),
      this.addIconIfNecessary(containsIcons, item),
      this.addMainItemContent(item, containsTrailingText, containsDetails)));
  }
  addMainItemContent(item, containsTrailingText, containsDetails) {
    return (h("div", { class: "K2BTEnhancedComboItem_TextColumn" },
      h("div", { class: "K2BTEnhancedComboItem_TextContainer" },
        h("span", { class: "K2BTEnhancedComboDescription" }, this.getHighlightedText(item.description)),
        containsTrailingText ? h("span", { class: "K2BTEnhancedComboTrailingText" }, this.getHighlightedText(item.trailingText)) : ''),
      h("div", { class: "K2BTEnhancedComboItem_TextContainer" }, containsDetails ? h("span", { class: "K2BTEnhancedComboSubtitle" }, this.getHighlightedText(item.detail)) : '')));
  }
  addIconIfNecessary(containsIcons, item) {
    return containsIcons ? (h("div", { class: "K2BTEnhancedComboIconContainer" },
      h("img", { class: "K2BTEnhancedComboIcon", src: item.imageUrl, onError: e => this.onImageError(e) }))) : ('');
  }
  addCheckboxIfNecessary(item) {
    return this.isCollection() ? (h("div", { class: "K2BT_EnhancedComboCheckbox" },
      h("input", { type: "checkbox", checked: this.itemIsSelected(item), tabIndex: -1, disabled: this.selectionIsFull() && !this.itemIsSelected(item) }),
      h("label", { htmlFor: "", "data-gx-sr-only": "" }, "\u00A0"))) : ('');
  }
  getItemClass(item) {
    var itemClass = 'K2BTEnhancedComboItem';
    if (this.itemIsSelected(item))
      itemClass += ' K2BTEnhancedComboSelected';
    else if (this.selectionIsFull())
      itemClass += ' K2BTEnhancedComboDisabled';
    if (this.activeElementValue === item.value)
      itemClass += ' K2BTEnhancedComboActive';
    return itemClass;
  }
  getCategoryContent(item, containsDetails, containsIcons, containsTrailingText) {
    return (h("div", { class: "K2BTEnhancedComboCategory" },
      h("span", { class: "K2BTEnhancedComboCategoryName" }, item.description),
      h("div", { class: "K2BTEnchancedComboCategoryContents" }, item.items.map(i => this.getItemContent(i, containsDetails, containsIcons, containsTrailingText)))));
  }
  getHighlightedText(originalText) {
    var position = originalText.toLowerCase().indexOf(this.searchvalue.toLowerCase());
    if (this.searchvalue == undefined || this.searchvalue == '' || position == -1) {
      return h("span", null, originalText);
    }
    else {
      return (h("span", null,
        originalText.substring(0, position),
        h("span", { class: "K2BTEnhancedComboSearchHighlight" }, originalText.substring(position, position + this.searchvalue.length)),
        this.getHighlightedText(originalText.substring(position + this.searchvalue.length))));
    }
  }
  changeSearchValue(value) {
    this.searchvalue = value;
    this.open = true;
    if (!this.isCollection()) {
      var valueSelected = this.getAtomicValues()
        .map(v => v.value)
        .indexOf(this.value[0]) != -1;
      this.value = [];
      if (valueSelected)
        this.emitChangedEvent();
    }
    if (this.seekSuggestValuesDebouncer) {
      clearTimeout(this.seekSuggestValuesDebouncer);
      this.seekSuggestValuesDebouncer = null;
    }
    this.seekSuggestValuesDebouncer = setTimeout((() => {
      this.seekSuggestValuesDebouncer = null;
      this.inputValueChangedEvent.emit(null);
    }).bind(this), 200);
  }
  getValueDescription() {
    if (this.value.length === 1) {
      var values = this.getAtomicValues();
      var v = values.find(val => val.value == this.value[0]);
      if (v != undefined) {
        return v.description;
      }
      return this.value[0];
    }
    return '';
  }
  getReadonlyValue(headerValues) {
    if (headerValues.length == 0)
      return this.emptyitemtext;
    else {
      return headerValues.map(v => v.description).join(', ');
    }
  }
  componentWillRender() {
    if (this.value == null || this.value == undefined || this.value.length === 0) {
      const valuesMatchingDescription = this.getAtomicValues().filter(item => item.description == this.searchfield.value);
      if (valuesMatchingDescription.length > 0) {
        this.setValueWithoutClosing(valuesMatchingDescription[0].value);
      }
    }
  }
  getHeaderTagsContent(vals) {
    var containsIcons = ControlInfoValue.containsIcons(this.getAtomicValues());
    if (this.isCollection())
      return vals.map(v => {
        return (h("div", { class: "K2BT_EnhancedComboHeaderTag" },
          this.showiconsintags && containsIcons && v.imageUrl !== '' ? h("img", { class: "K2BT_EnhancedComboTagIcon", src: v.imageUrl }) : '',
          h("span", { class: "K2BT_EnhancedComboHeaderTagDescription" }, v.description),
          h("span", { class: "K2BT_EnhancedComboHeaderTagDelete", onClick: ev => {
              ev.cancelBubble = true;
              this.setValueWithoutClosing(v.value);
              this.emitChangedEvent();
            } })));
      });
  }
  render() {
    var atomicValues = this.getAtomicValues();
    const headerValues = this.value.map(sv => atomicValues.filter(v => sv.toString().trim() === v.value.trim())[0]).filter(f => f);
    this.selectedElement = null;
    return (h("div", null,
      h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} },
        h("span", { class: this.readonlyclass, "data-gx-readonly": "" }, this.getReadonlyValue(headerValues))),
      h("div", { class: "K2BTEnhancedSuggest", ref: node => (this.container = node), style: !this.enabled ? { display: 'none' } : {} },
        h("div", { class: "K2BTEnhancedSuggestTags" }, this.getHeaderTagsContent(headerValues)),
        h("input", { type: "text", class: "form-control Attribute_Trn K2BTEnhancedSuggestInput", value: this.searchvalue, onInput: event => {
            event.preventDefault();
            this.changeSearchValue(event.target.value);
            return false;
          }, placeholder: this.placeholder, onClick: () => {
            this.open = true;
            this.activeElementValue = null;
          }, onFocus: () => {
            this.open = true;
            this.focusEvent.emit();
          }, ref: control => (this.searchfield = control) }),
        h("div", { class: this.open ? 'K2BTEnhancedComboContentsOpen' : 'K2BTEnhancedComboContentsClosed' },
          h("div", { class: "K2BTEnhancedComboItems" }, this.getSuggestPopoverContent()),
          this.enableadditem ? (h("span", { class: "K2BTEnhancedComboNewAction", onClick: () => this.onIncludeNewRecordClick() }, this.additemcaption)) : ('')))));
  }
  static get is() { return "k2bt-enhancedsuggest"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-enhancedsuggest.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-enhancedsuggest.css"]
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
    "values": {
      "type": "string",
      "mutable": false,
      "complexType": {
        "original": "Array<object> | string",
        "resolved": "object[] | string",
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
      "attribute": "values",
      "reflect": false
    },
    "noresultsfoundtext": {
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
      "attribute": "noresultsfoundtext",
      "reflect": false,
      "defaultValue": "'No results found'"
    },
    "open": {
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
      "attribute": "open",
      "reflect": false
    },
    "enableadditem": {
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
      "attribute": "enableadditem",
      "reflect": false,
      "defaultValue": "true"
    },
    "additemcaption": {
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
      "attribute": "additemcaption",
      "reflect": false,
      "defaultValue": "'New record'"
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
    "searchvalue": {
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
      "attribute": "searchvalue",
      "reflect": false,
      "defaultValue": "''"
    },
    "placeholder": {
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
      "attribute": "placeholder",
      "reflect": false,
      "defaultValue": "''"
    },
    "selectedValueDescription": {
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
      "attribute": "selected-value-description",
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
    "suggestmaxitems": {
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
      "attribute": "suggestmaxitems",
      "reflect": false,
      "defaultValue": "5"
    },
    "activeElementValue": {
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
      "attribute": "active-element-value",
      "reflect": false,
      "defaultValue": "null"
    },
    "showiconsintags": {
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
      "attribute": "showiconsintags",
      "reflect": false,
      "defaultValue": "true"
    },
    "emptyitemtext": {
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
      "attribute": "emptyitemtext",
      "reflect": false,
      "defaultValue": "'(none)'"
    }
  }; }
  static get events() { return [{
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
    }, {
      "method": "focusEvent",
      "name": "focus",
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
    }, {
      "method": "changeEvent",
      "name": "SuggestValueChanged",
      "bubbles": true,
      "cancelable": true,
      "composed": true,
      "docs": {
        "tags": [],
        "text": ""
      },
      "complexType": {
        "original": "string[]",
        "resolved": "string[]",
        "references": {}
      }
    }, {
      "method": "newRecordClickedEvent",
      "name": "newRecordClicked",
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
      "method": "inputValueChangedEvent",
      "name": "inputValueChanged",
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
    "setFocusToSearch": {
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
    },
    "updateDescription": {
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
    },
    "setValue": {
      "complexType": {
        "signature": "(value: any) => Promise<void>",
        "parameters": [{
            "tags": [],
            "text": ""
          }],
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
  static get listeners() { return [{
      "name": "input",
      "method": "processInput",
      "target": undefined,
      "capture": true,
      "passive": false
    }, {
      "name": "keydown",
      "method": "processKeydown",
      "target": undefined,
      "capture": false,
      "passive": false
    }, {
      "name": "click",
      "method": "closeMenu",
      "target": "window",
      "capture": false,
      "passive": false
    }]; }
}
K2btEnhancedsuggest.ERROR_SELECTION_FULL = 'SELECTION_FULL';
