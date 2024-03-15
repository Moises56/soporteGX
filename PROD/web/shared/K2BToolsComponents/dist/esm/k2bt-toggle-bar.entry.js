import { r as registerInstance, c as createEvent, h } from './index-93e0a246.js';
import { a as ControlInfoValue } from './utils-a6947f92.js';

const k2btToggleBarCss = ":host{display:block}";

const K2btToggleBar = class {
  constructor(hostRef) {
    registerInstance(this, hostRef);
    this.selectionErrorEvent = createEvent(this, "selectionError", 7);
    this.inputEvent = createEvent(this, "input", 7);
    this.changeEvent = createEvent(this, "change", 7);
    this.newRecordClickedEvent = createEvent(this, "newRecordClicked", 7);
    this.SmallChip = 'SmallChip';
    this.MediumChip = 'MediumChip';
    this.Rectangle = 'Rectangle';
    this.value = null;
    this.values = [];
    this.includeemptyitem = true;
    this.emptyitemtext = '(none)';
    this.noresultsfoundtext = 'No results found';
    this.enableadditem = true;
    this.additemcaption = 'New record';
    this.enabled = true;
    this.readonlyclass = '';
    this.togglestyle = this.MediumChip;
    this.maxSelectionSize = 1;
    this.selectedElement = null;
  }
  onImageError(e) {
    e.target.classList.add('K2BT_ToggleBarIconInvisible');
  }
  isCollection() {
    return this.maxSelectionSize != 1;
  }
  selectionIsFull() {
    return this.isCollection() && this.maxSelectionSize != 0 && this.maxSelectionSize <= this.value.length;
  }
  itemIsSelected(item) {
    var _a, _b;
    return ((_b = (_a = this.value) === null || _a === void 0 ? void 0 : _a.filter(selectedItem => selectedItem.toString().trim() == item.value.trim()).length) !== null && _b !== void 0 ? _b : 0) > 0;
  }
  setValue(value) {
    var _a, _b, _c;
    if (this.maxSelectionSize == 1) {
      this.value = [value];
    }
    else {
      if (((_b = (_a = this.value) === null || _a === void 0 ? void 0 : _a.filter(v => v.trim() === value.trim()).length) !== null && _b !== void 0 ? _b : 0) === 0) {
        if (!this.selectionIsFull())
          this.value = ((_c = this.value) !== null && _c !== void 0 ? _c : []).concat([value]);
        else {
          this.errorCode = K2btToggleBar.ERROR_SELECTION_FULL;
          this.selectionErrorEvent.emit({});
        }
      }
      else
        this.value = this.value.filter(v => v.trim() !== value.trim());
    }
    this.inputEvent.emit();
    this.changeEvent.emit(value);
  }
  getToggleContent(values, containsDetails, containsIcons, containsTrailingText) {
    if (values.length == 0) {
      return h("div", { class: "K2BT_ToggleBar_NoItems" }, this.noresultsfoundtext);
    }
    else {
      const atomic = values.filter(v => { var _a, _b; return ((_b = (_a = v.items) === null || _a === void 0 ? void 0 : _a.length) !== null && _b !== void 0 ? _b : 0) == 0; });
      const currentLevelCategories = values.filter(v => { var _a; return ((_a = v.items) === null || _a === void 0 ? void 0 : _a.length) > 0; });
      var containerClasses = this.GetContainerClasses();
      return (h("div", { class: containerClasses }, atomic.length > 0 ? (h("div", { class: "K2BT_ToggleBarItemContainer" }, atomic.map(item => this.getItemContent(item, containsIcons, containsTrailingText, containsDetails)))) : (''), currentLevelCategories.map(c => {
        return (h("div", { class: "K2BT_ToggleBar_CategoryContainer" }, h("div", { class: "K2BT_ToggleBarCategoryName" }, c.description), this.getToggleContent(c.items, containsDetails, containsIcons, containsTrailingText)));
      })));
    }
  }
  getItemContent(item, containsIcons, containsTrailingText, containsDetails) {
    return (h("div", { class: this.itemIsSelected(item) ? 'K2BT_ToggleBarItem K2BT_ToggleBarItemSelected' : 'K2BT_ToggleBarItem', ref: c => {
        if (this.itemIsSelected(item))
          this.selectedElement = c;
      }, onClick: () => this.setValue(item.value.trim()) }, this.getIconHTMLIfNecessary(containsIcons, item), h("div", { class: "K2BT_ToggleBarItem_TextSection" }, h("div", { class: "K2BT_ToggleBarItem_TextContainer" }, h("span", { class: "K2BT_ToggleBarDescription" }, item.description), containsTrailingText ? h("span", { class: "K2BT_ToggleBarTrailingText" }, item.trailingText) : ''), h("div", { class: "K2BT_ToggleBarItem_TextContainer" }, containsDetails ? h("span", { class: "K2BT_ToggleBarSubtitle" }, item.detail) : ''))));
  }
  getIconHTMLIfNecessary(containsIcons, item) {
    return containsIcons ? (h("div", { class: "K2BT_ToggleBarIconContainer" }, h("img", { class: "K2BT_ToggleBarIcon", src: item.imageUrl, onError: e => this.onImageError(e) }))) : ('');
  }
  GetContainerClasses() {
    var containerClasses = 'K2BT_ToggleBar_Container';
    if (this.togglestyle == this.SmallChip) {
      containerClasses += ' K2BT_ToggleBarSmallChip';
    }
    else if (this.togglestyle == this.Rectangle) {
      containerClasses += ' K2BT_ToggleBarRectangle';
    }
    return containerClasses;
  }
  getSelectedItemsContent() {
    if (this.value == null)
      return this.emptyitemtext;
    else {
      var vals = ControlInfoValue.getAtomicValues_impl(this.values).filter(value => this.itemIsSelected(value));
      if (vals.length > 0)
        return vals.map(v => v.description).join(', ');
      else
        return this.emptyitemtext;
    }
  }
  render() {
    var containsDetails = ControlInfoValue.containsDetails(ControlInfoValue.getAtomicValues_impl(this.values));
    var containsIcons = ControlInfoValue.containsIcons(ControlInfoValue.getAtomicValues_impl(this.values));
    var containsTrailingText = ControlInfoValue.containsTrailingText(ControlInfoValue.getAtomicValues_impl(this.values));
    var valueList = this.getValues();
    if (this.enabled) {
      return this.getToggleContent(valueList, containsDetails, containsIcons, containsTrailingText);
    }
    else {
      return (h("p", { class: "form-control-static" }, h("span", { class: this.readonlyclass, "data-gx-readonly": "" }, this.getSelectedItemsContent())));
    }
  }
  getValues() {
    var valueList = [...this.values];
    if (this.includeemptyitem && !this.isCollection()) {
      valueList.unshift({
        value: '',
        description: this.emptyitemtext,
        imageUrl: '',
        detail: '',
        trailingText: '',
        badgeClass: '',
        items: [],
      });
    }
    return valueList;
  }
  componentDidLoad() {
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.values);
    if (!this.includeemptyitem && currentValues.filter(v => this.itemIsSelected(v)).length == 0) {
      if (currentValues.length > 0) {
        this.setValue(currentValues[0].value.trim());
      }
    }
  }
};
K2btToggleBar.ERROR_SELECTION_FULL = 'SELECTION_FULL';
K2btToggleBar.style = k2btToggleBarCss;

export { K2btToggleBar as k2bt_toggle_bar };
