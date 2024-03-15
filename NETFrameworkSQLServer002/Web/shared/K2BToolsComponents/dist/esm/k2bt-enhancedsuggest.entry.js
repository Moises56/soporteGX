import { r as registerInstance, c as createEvent, h } from './index-93e0a246.js';
import { a as ControlInfoValue } from './utils-a6947f92.js';

const k2btEnhancedsuggestCss = ":host{display:block}k2bt-enhancedsuggest:focus-visible{outline:none}.K2BTEnhancedComboContentsOpen{display:flex;flex-direction:column;position:absolute}.K2BTEnhancedComboItems{max-height:300px;overflow:auto;scrollbar-width:thin;scrollbar-color:#d7d7d7 transparent}.K2BTEnhancedComboItems::-webkit-scrollbar{width:6px}.K2BTEnhancedComboItems::-webkit-scrollbar-thumb{background-color:#d7d7d7;border:1px solid transparent;cursor:pointer}.K2BTEnhancedComboContentsClosed{display:none}.K2BTEnhancedComboItem{display:flex;flex-direction:row;align-items:center}.K2BTEnhancedComboItem:hover{cursor:pointer}.K2BTEnhancedComboItem_TextContainer{display:flex;flex-grow:1}.K2BTEnhancedComboSubtitle{font-size:12px}.K2BTEnhancedComboIcon{width:30px;height:30px;object-fit:cover;margin-right:4px}.K2BTEnhancedComboIconInvisible{visibility:hidden}.K2BTEnhancedComboNoItemsFound{width:100%;text-align:center;margin-top:40px;margin-bottom:40px}.K2BTEnhancedComboTrailingText{flex-grow:0}@keyframes spinner{to{transform:rotate(360deg)}}.K2BT_LoadingSpinner{-webkit-box-sizing:border-box;box-sizing:border-box;position:relative;left:50%;width:20px;height:19px;margin-top:10px;margin-bottom:10px;border-radius:50%;border:2px solid #ccc;border-top-color:#000;-webkit-animation:spinner 0.6s linear infinite;animation:spinner 0.6s linear infinite;margin-left:-10px}.K2BT_EnhancedComboCheckbox{margin-right:8px;margin-top:6px;pointer-events:none}.K2BTEnhancedComboDisabled{cursor:normal;opacity:0.8}.K2BTEnhancedSuggestTags{display:flex;flex-direction:row;flex-wrap:wrap}";

const K2btEnhancedsuggest = class {
  constructor(hostRef) {
    registerInstance(this, hostRef);
    this.selectionErrorEvent = createEvent(this, "selectionError", 7);
    this.focusEvent = createEvent(this, "focus", 7);
    this.changeEvent = createEvent(this, "SuggestValueChanged", 7);
    this.newRecordClickedEvent = createEvent(this, "newRecordClicked", 7);
    this.inputValueChangedEvent = createEvent(this, "inputValueChanged", 7);
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
      } }, this.addCheckboxIfNecessary(item), this.addIconIfNecessary(containsIcons, item), this.addMainItemContent(item, containsTrailingText, containsDetails)));
  }
  addMainItemContent(item, containsTrailingText, containsDetails) {
    return (h("div", { class: "K2BTEnhancedComboItem_TextColumn" }, h("div", { class: "K2BTEnhancedComboItem_TextContainer" }, h("span", { class: "K2BTEnhancedComboDescription" }, this.getHighlightedText(item.description)), containsTrailingText ? h("span", { class: "K2BTEnhancedComboTrailingText" }, this.getHighlightedText(item.trailingText)) : ''), h("div", { class: "K2BTEnhancedComboItem_TextContainer" }, containsDetails ? h("span", { class: "K2BTEnhancedComboSubtitle" }, this.getHighlightedText(item.detail)) : '')));
  }
  addIconIfNecessary(containsIcons, item) {
    return containsIcons ? (h("div", { class: "K2BTEnhancedComboIconContainer" }, h("img", { class: "K2BTEnhancedComboIcon", src: item.imageUrl, onError: e => this.onImageError(e) }))) : ('');
  }
  addCheckboxIfNecessary(item) {
    return this.isCollection() ? (h("div", { class: "K2BT_EnhancedComboCheckbox" }, h("input", { type: "checkbox", checked: this.itemIsSelected(item), tabIndex: -1, disabled: this.selectionIsFull() && !this.itemIsSelected(item) }), h("label", { htmlFor: "", "data-gx-sr-only": "" }, "\u00A0"))) : ('');
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
    return (h("div", { class: "K2BTEnhancedComboCategory" }, h("span", { class: "K2BTEnhancedComboCategoryName" }, item.description), h("div", { class: "K2BTEnchancedComboCategoryContents" }, item.items.map(i => this.getItemContent(i, containsDetails, containsIcons, containsTrailingText)))));
  }
  getHighlightedText(originalText) {
    var position = originalText.toLowerCase().indexOf(this.searchvalue.toLowerCase());
    if (this.searchvalue == undefined || this.searchvalue == '' || position == -1) {
      return h("span", null, originalText);
    }
    else {
      return (h("span", null, originalText.substring(0, position), h("span", { class: "K2BTEnhancedComboSearchHighlight" }, originalText.substring(position, position + this.searchvalue.length)), this.getHighlightedText(originalText.substring(position + this.searchvalue.length))));
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
        return (h("div", { class: "K2BT_EnhancedComboHeaderTag" }, this.showiconsintags && containsIcons && v.imageUrl !== '' ? h("img", { class: "K2BT_EnhancedComboTagIcon", src: v.imageUrl }) : '', h("span", { class: "K2BT_EnhancedComboHeaderTagDescription" }, v.description), h("span", { class: "K2BT_EnhancedComboHeaderTagDelete", onClick: ev => {
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
    return (h("div", null, h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} }, h("span", { class: this.readonlyclass, "data-gx-readonly": "" }, this.getReadonlyValue(headerValues))), h("div", { class: "K2BTEnhancedSuggest", ref: node => (this.container = node), style: !this.enabled ? { display: 'none' } : {} }, h("div", { class: "K2BTEnhancedSuggestTags" }, this.getHeaderTagsContent(headerValues)), h("input", { type: "text", class: "form-control Attribute_Trn K2BTEnhancedSuggestInput", value: this.searchvalue, onInput: event => {
        event.preventDefault();
        this.changeSearchValue(event.target.value);
        return false;
      }, placeholder: this.placeholder, onClick: () => {
        this.open = true;
        this.activeElementValue = null;
      }, onFocus: () => {
        this.open = true;
        this.focusEvent.emit();
      }, ref: control => (this.searchfield = control) }), h("div", { class: this.open ? 'K2BTEnhancedComboContentsOpen' : 'K2BTEnhancedComboContentsClosed' }, h("div", { class: "K2BTEnhancedComboItems" }, this.getSuggestPopoverContent()), this.enableadditem ? (h("span", { class: "K2BTEnhancedComboNewAction", onClick: () => this.onIncludeNewRecordClick() }, this.additemcaption)) : ('')))));
  }
};
K2btEnhancedsuggest.ERROR_SELECTION_FULL = 'SELECTION_FULL';
K2btEnhancedsuggest.style = k2btEnhancedsuggestCss;

export { K2btEnhancedsuggest as k2bt_enhancedsuggest };
