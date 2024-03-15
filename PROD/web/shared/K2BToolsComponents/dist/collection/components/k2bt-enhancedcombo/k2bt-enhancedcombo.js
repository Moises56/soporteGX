import { Component, Event, h, Listen, Prop } from '@stencil/core';
import { ControlInfoValue } from '../../utils/utils';
export class K2btEnhancedcombo {
  constructor() {
    this.value = null;
    this.includesearch = true;
    this.includeemptyitem = true;
    this.emptyitemtext = '(none)';
    this.noresultsfoundtext = 'No results found';
    this.enableadditem = true;
    this.additemcaption = 'New record';
    this.clearselectioncaption = 'Clear selection';
    this.selectallcaption = 'Clear selection';
    this.searchfieldplaceholder = 'Search';
    this.searchvalue = '';
    this.enabled = true;
    this.maxSelectionSize = 1;
    this.headermaxvisibleitems = 3;
    this.readonlyclass = '';
    this.showselectionastags = false;
    this.showiconsintags = true;
    this.displayaslist = false;
    this.enableclearselectionaction = false;
    this.enableselectallaction = false;
    this.activeElementValue = null;
    this.container = null;
    this.selectedElement = null;
    this.searchfield = null;
    this.listContainer = null;
    this._keyboardSearchPrefix = '';
    this._keyboardSearchLastKeystroke = null;
  }
  isCollection() {
    return this.maxSelectionSize != 1;
  }
  processKeydown(event) {
    if (event.key == 'Escape') {
      this.resetPrefixSearch();
      this.open = false;
      event.stopPropagation();
    }
    else if (event.key == 'Enter') {
      this.resetPrefixSearch();
      this.open = !this.open;
      event.stopPropagation();
    }
    else if (this.isCollection()) {
      this.processKeydownForCollection(event);
    }
    else {
      this.processKeydownSingleSelection(event);
    }
  }
  processKeydownForCollection(event) {
    var pos;
    if (this.open) {
      if (event.key == 'ArrowDown') {
        this.processArrowDownForCollection(event, pos);
      }
      else if (event.key == 'ArrowUp') {
        this.processArrowUpForCollection(event, pos);
      }
      else if (event.key === ' ' || event.key === 'Spacebar') {
        this.processSpacebarForCollection(event);
      }
      else {
        this.processCharacterForCollection(event);
      }
    }
  }
  processCharacterForCollection(event) {
    var key = event.key;
    // Check if the key pressed maps to a single character
    if (key.length == 1) {
      if (document.activeElement != this.searchfield) {
        var currentDate = Date.now();
        if (this._keyboardSearchLastKeystroke == null || currentDate - this._keyboardSearchLastKeystroke > 3000) {
          this._keyboardSearchPrefix = '';
        }
        this._keyboardSearchPrefix = this._keyboardSearchPrefix + key;
        var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
        var selectedValue = currentValues.find(v => v.description.toLowerCase().indexOf(this._keyboardSearchPrefix.toLowerCase()) == 0);
        if (selectedValue != null) {
          this.activeElementValue = selectedValue.value.trim();
        }
        this._keyboardSearchLastKeystroke = currentDate;
      }
    }
  }
  processSpacebarForCollection(event) {
    var _a;
    if (((_a = this.activeElementValue) !== null && _a !== void 0 ? _a : '') !== '') {
      this.setValueWithoutClosing(this.activeElementValue, false);
      event.stopPropagation();
      event.preventDefault();
    }
  }
  processArrowUpForCollection(event, pos) {
    this.resetPrefixSearch();
    event.stopPropagation();
    event.preventDefault();
    //up key
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      pos = currentValues.findIndex(v => v.value.trim() == this.activeElementValue);
      if (pos == -1) {
        pos = currentValues.length - 1;
      }
      else {
        pos = (((pos - 1) % currentValues.length) + currentValues.length) % currentValues.length;
      }
      this.activeElementValue = currentValues[pos].value.trim();
    }
  }
  processArrowDownForCollection(event, pos) {
    this.resetPrefixSearch();
    event.stopPropagation();
    event.preventDefault();
    //down key
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      pos = currentValues.findIndex(v => v.value.trim() == this.activeElementValue);
      if (pos == -1) {
        pos = 0;
      }
      else {
        pos = (((pos + 1) % currentValues.length) + currentValues.length) % currentValues.length;
      }
      this.activeElementValue = currentValues[pos].value.trim();
    }
  }
  processKeydownSingleSelection(event) {
    if (event.key == 'ArrowDown') {
      this.processArrowDownForSingleSelection(event);
    }
    else if (event.key == 'ArrowUp') {
      this.processArrowUpForSingleSelection(event);
    }
    else {
      this.processCharacterForSingleSelection(event);
    }
  }
  processCharacterForSingleSelection(event) {
    var key = event.key;
    // Check if the key pressed maps to a single character
    if (key.length == 1) {
      if (document.activeElement != this.searchfield) {
        var currentDate = Date.now();
        if (this._keyboardSearchLastKeystroke == null || currentDate - this._keyboardSearchLastKeystroke > 3000) {
          this._keyboardSearchPrefix = '';
        }
        this._keyboardSearchPrefix = this._keyboardSearchPrefix + key;
        var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
        var selectedValue = currentValues.find(v => v.description.toLowerCase().indexOf(this._keyboardSearchPrefix.toLowerCase()) == 0);
        if (selectedValue != null) {
          this.setValueWithoutClosing(selectedValue.value.trim(), false);
        }
        this._keyboardSearchLastKeystroke = currentDate;
      }
    }
  }
  processArrowUpForSingleSelection(event) {
    this.resetPrefixSearch();
    event.stopPropagation();
    event.preventDefault();
    //up key
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value.trim() == this.value[0].trim());
      if (pos == -1) {
        this.setValueWithoutClosing(currentValues[currentValues.length - 1].value.trim(), false);
      }
      else {
        pos = (((pos - 1) % currentValues.length) + currentValues.length) % currentValues.length;
        this.setValueWithoutClosing(currentValues[pos].value.trim(), false);
      }
    }
  }
  processArrowDownForSingleSelection(event) {
    this.resetPrefixSearch();
    event.stopPropagation();
    event.preventDefault();
    //down key
    var currentValues = ControlInfoValue.getAtomicValues_impl(this.getFilteredValues());
    if (currentValues.length > 0) {
      var pos = currentValues.findIndex(v => v.value.trim() == this.value[0].trim());
      if (pos == -1) {
        this.setValueWithoutClosing(currentValues[0].value.trim(), false);
      }
      else {
        pos = (((pos + 1) % currentValues.length) + currentValues.length) % currentValues.length;
        this.setValueWithoutClosing(currentValues[pos].value.trim(), false);
      }
    }
  }
  onFocusIn() {
    this.resetPrefixSearch();
    this.focusEvent.emit();
  }
  resetPrefixSearch() {
    this._keyboardSearchLastKeystroke = null;
  }
  closeMenu(ev) {
    this.resetPrefixSearch();
    if (this.open && this.container && !this.container.contains(ev.target))
      this.open = false;
  }
  getHeaderContent() {
    if (this.value == null)
      return this.emptyitemtext;
    else {
      var vals = this.getAtomicValues().filter(value => this.valueIsSelected(value));
      if (vals.length > 0) {
        if (this.isCollection() && this.showselectionastags) {
          return this.getHeaderTagsContent(vals);
        }
        else {
          if (vals.length > this.headermaxvisibleitems)
            return [
              vals
                .slice(0, this.headermaxvisibleitems)
                .map(v => this.getSelectedItemSpan(v))
                .reduce((prev, curr) => [prev, h("span", null, ",\u00A0"), curr]),
              h("span", null,
                "\u00A0(+",
                vals.length - this.headermaxvisibleitems,
                ")"),
            ];
          else
            return vals.map(v => this.getSelectedItemSpan(v)).reduce((prev, curr) => [prev, h("span", null, ",\u00A0"), curr]);
        }
      }
      else
        return this.emptyitemtext;
    }
  }
  getSelectedItemSpan(v) {
    return h("span", { class: "K2BT_EnhancedControlInfoSelectedValue" }, v.description);
  }
  getReadonlyContent() {
    if (this.value == null)
      return this.emptyitemtext;
    else {
      var vals = this.getAtomicValues().filter(value => this.valueIsSelected(value));
      if (vals.length > 0)
        return vals.map(v => v.description).join(', ');
      else
        return this.emptyitemtext;
    }
  }
  getHeaderTagsContent(vals) {
    var containsIcons = ControlInfoValue.containsIcons(this.getAtomicValues());
    return vals.map(v => {
      return (h("div", { class: "K2BT_EnhancedComboHeaderTag" },
        this.showiconsintags && containsIcons && v.imageUrl !== '' ? h("img", { class: "K2BT_EnhancedComboTagIcon", src: v.imageUrl }) : '',
        h("span", { class: "K2BT_EnhancedComboHeaderTagDescription" }, v.description),
        h("span", { class: "K2BT_EnhancedComboHeaderTagDelete", onClick: ev => {
            ev.cancelBubble = true;
            this.setValueWithoutClosing(v.value, false);
          } })));
    });
  }
  valueIsSelected(value) {
    return this.value.filter(v => value.value.trim() == v.toString().trim()).length > 0;
  }
  toggleContentVisibilty() {
    this.resetPrefixSearch();
    this.open = !this.open;
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
    if (this.includeemptyitem && !this.isCollection()) {
      result.unshift({
        value: '',
        description: this.emptyitemtext,
        imageUrl: '',
        detail: '',
        trailingText: '',
        badgeClass: '',
        items: [],
      });
    }
    return result;
  }
  getFilteredValues() {
    var result = this.getRawValues();
    if (this.includesearch && this.searchvalue != '')
      result = this.getFilteredValues_impl(result);
    return result;
  }
  getFilteredValues_impl(origin) {
    var result = [];
    if (origin != undefined) {
      for (let cv of origin) {
        if (cv.description.toLocaleLowerCase().indexOf(this.searchvalue.toLocaleLowerCase()) != -1 ||
          cv.detail.toLocaleLowerCase().indexOf(this.searchvalue.toLocaleLowerCase()) != -1 ||
          cv.trailingText.toLocaleLowerCase().indexOf(this.searchvalue.toLocaleLowerCase()) != -1) {
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
  setValue(value) {
    this.setValueWithoutClosing(value, true);
    this.open = false;
  }
  setValueWithoutClosing(value, triggerChangeEventImmediately) {
    if (this.isCollection()) {
      if (this.value.filter(v => v.toString().trim() === value.toString().trim()).length === 0) {
        if (!this.selectionIsFull())
          this.value = this.value.concat([value]);
        else {
          this.errorCode = K2btEnhancedcombo.ERROR_SELECTION_FULL;
          this.selectionErrorEvent.emit({});
        }
      }
      else
        this.value = this.value.filter(v => v.toString().trim() !== value.toString().trim());
    }
    else {
      this.value = [value];
    }
    if (this.setValueDebouncer) {
      clearTimeout(this.setValueDebouncer);
      this.setValueDebouncer = null;
    }
    if (triggerChangeEventImmediately) {
      this.emitChangedEvents(value);
    }
    else {
      this.setValueDebouncer = setTimeout((() => {
        this.setValueDebouncer = null;
        this.emitChangedEvents(value);
      }).bind(this), 200);
    }
  }
  emitChangedEvents(value) {
    this.inputEvent.emit();
    this.changeEvent.emit(value);
  }
  changeSearchValue(value) {
    this.searchvalue = value;
    this.searchChangedEvent.emit({ value });
  }
  onIncludeNewRecordClick() {
    this.open = false;
    this.newRecordClickedEvent.emit(null);
  }
  render() {
    this.selectedElement = null;
    var listClass = '';
    if (!this.displayaslist)
      listClass = this.open ? 'K2BTEnhancedComboContentsOpen' : 'K2BTEnhancedComboContentsClosed';
    else
      listClass = 'K2BTEnhancedListContents';
    return (h("div", null,
      h("p", { class: "form-control-static", style: this.enabled ? { display: 'none' } : {} },
        h("span", { class: this.readonlyclass, "data-gx-readonly": "" }, this.getReadonlyContent())),
      h("div", { tabindex: "0", class: "K2BTEnhancedCombo", ref: node => (this.container = node), style: !this.enabled ? { display: 'none' } : {} },
        this.addHeaderIfNecessary(),
        h("div", { class: listClass, ref: c => (this.listContainer = c) },
          this.includesearch ? (h("input", { type: "text", class: "form-control K2BTEnhancedComboSearchInput", ref: c => (this.searchfield = c), onInput: event => {
              this.changeSearchValue(event.target.value);
              event.stopPropagation();
            }, onChange: event => event.stopPropagation(), placeholder: this.searchfieldplaceholder })) : (''),
          this.getCollectionActionsHeader(),
          h("div", { class: "K2BTEnhancedComboItems" }, this.getComboContent()),
          this.enableadditem ? (h("span", { class: "K2BTEnhancedComboNewAction", onClick: () => this.onIncludeNewRecordClick() }, this.additemcaption)) : ('')))));
  }
  getCollectionActionsHeader() {
    return this.enableselectallaction || this.enableclearselectionaction ? (h("div", { class: "K2BT_EnhancedComboCollectionActions" },
      this.getClearSelectionAction(),
      this.getSelectAllAction())) : ('');
  }
  getSelectAllAction() {
    return this.enableselectallaction ? (h("span", { class: "K2BT_EnhancedComboSelectAll", onClick: () => this.onSelectAllClick() }, this.selectallcaption)) : ('');
  }
  getClearSelectionAction() {
    return this.enableclearselectionaction ? (h("span", { class: "K2BT_EnhancedComboSelectNone", onClick: () => this.onClearSelectionClick() }, this.clearselectioncaption)) : ('');
  }
  onClearSelectionClick() {
    this.value = [];
    this.emitChangedEvents(this.value);
  }
  onSelectAllClick() {
    this.value = this.getAtomicValues().map(v => v.value);
    this.emitChangedEvents(this.value);
  }
  addHeaderIfNecessary() {
    return !this.displayaslist ? (h("div", { class: "K2BTEnhancedComboHeader", onClick: () => this.toggleContentVisibilty() },
      h("div", { class: "K2BTHeaderContent" }, this.getHeaderContent()))) : ('');
  }
  getAtomicValues() {
    return ControlInfoValue.getAtomicValues_impl(this.getRawValues());
  }
  getComboContent() {
    const rawValues = ControlInfoValue.getAtomicValues_impl(this.getRawValues());
    var containsDetails = ControlInfoValue.containsDetails(rawValues);
    var containsIcons = ControlInfoValue.containsIcons(rawValues);
    var containsTrailingText = ControlInfoValue.containsTrailingText(rawValues);
    var containsBadges = ControlInfoValue.containsBadges(rawValues);
    const filteredValues = !this.open && !this.displayaslist ? [] : this.getFilteredValues();
    if (filteredValues.length > 0)
      return filteredValues.map(item => this.getItemContent(item, containsDetails, containsIcons, containsTrailingText, containsBadges));
    else
      return h("div", { class: "K2BTEnhancedComboNoItemsFound" }, this.noresultsfoundtext);
  }
  onImageError(e) {
    e.target.classList.add('K2BTEnhancedComboIconInvisible');
  }
  getItemContent(item, containsDetails, containsIcons, containsTrailingText, containsBadges) {
    var _a;
    if (((_a = item.items) === null || _a === void 0 ? void 0 : _a.length) > 0) {
      return this.getCategoryContent(item, containsDetails, containsIcons, containsTrailingText, containsBadges);
    }
    else {
      return this.getAtomicItemContent(item, containsIcons, containsTrailingText, containsDetails, containsBadges);
    }
  }
  getAtomicItemContent(item, containsIcons, containsTrailingText, containsDetails, containsBadges) {
    var itemClass = 'K2BTEnhancedComboItem';
    if (this.valueIsSelected(item))
      itemClass += ' K2BTEnhancedComboSelected';
    else if (this.selectionIsFull())
      itemClass += ' K2BTEnhancedComboDisabled';
    if (this.activeElementValue === item.value)
      itemClass += ' K2BTEnhancedComboActive';
    return (h("div", { class: itemClass, ref: c => {
        if ((!this.isCollection() && this.valueIsSelected(item)) || (this.isCollection() && this.activeElementValue === item.value))
          this.selectedElement = c;
      }, onClick: () => {
        if (this.isCollection())
          this.setValueWithoutClosing(item.value.trim(), true);
        else
          this.setValue(item.value.trim());
      } },
      this.addCheckboxIfNecessary(item),
      this.addIconIfNecessary(containsIcons, item),
      this.addBadgeIfNecessary(containsBadges, item),
      this.addMainItemContent(item, containsTrailingText, containsDetails)));
  }
  addMainItemContent(item, containsTrailingText, containsDetails) {
    return (h("div", { class: "K2BTEnhancedComboItem_TextColumn" },
      h("div", { class: "K2BTEnhancedComboItem_TextContainer" },
        h("span", { class: "K2BTEnhancedComboDescription" }, this.getHighlightedText(item.description)),
        containsTrailingText ? h("span", { class: "K2BTEnhancedComboTrailingText" }, this.getHighlightedText(item.trailingText)) : ''),
      h("div", { class: "K2BTEnhancedComboItem_TextContainer" }, containsDetails ? h("span", { class: "K2BTEnhancedComboSubtitle" }, this.getHighlightedText(item.detail)) : '')));
  }
  addBadgeIfNecessary(containsBadges, item) {
    const c = 'K2BTEnhancedComboBadge ' + item.badgeClass;
    if (!containsBadges)
      return '';
    else
      return h("div", { class: c });
  }
  addIconIfNecessary(containsIcons, item) {
    if (!containsIcons)
      return '';
    else
      return (h("div", { class: "K2BTEnhancedComboIconContainer" },
        h("img", { class: item.imageUrl === '' ? 'K2BTEnhancedComboIcon K2BTEnhancedComboIconInvisible' : 'K2BTEnhancedComboIcon', src: item.imageUrl, onError: e => this.onImageError(e) })));
  }
  addCheckboxIfNecessary(item) {
    return this.isCollection() ? (h("div", { class: "K2BT_EnhancedComboCheckbox" },
      h("input", { type: "checkbox", checked: this.valueIsSelected(item), tabIndex: -1, disabled: this.selectionIsFull() && !this.valueIsSelected(item) }),
      h("label", { htmlFor: "", "data-gx-sr-only": "" }, "\u00A0"))) : ('');
  }
  getCategoryContent(item, containsDetails, containsIcons, containsTrailingText, containsBadges) {
    return (h("div", { class: "K2BTEnhancedComboCategory" },
      h("span", { class: "K2BTEnhancedComboCategoryName" }, item.description),
      h("div", { class: "K2BTEnchancedComboCategoryContents" }, item.items.map(i => this.getItemContent(i, containsDetails, containsIcons, containsTrailingText, containsBadges)))));
  }
  selectionIsFull() {
    return this.isCollection() && this.maxSelectionSize != 0 && this.maxSelectionSize <= this.value.length;
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
  componentDidRender() {
    if (this.selectedElement != null) {
      this.selectedElement.scrollIntoView({ block: 'nearest' });
    }
    if (this.listContainer.getBoundingClientRect().right + this.listContainer.getBoundingClientRect().width > window.innerWidth) {
      this.listContainer.style.right = '0px';
    }
    else {
      this.listContainer.style.right = null;
    }
  }
  componentDidLoad() {
    var currentValues = this.getAtomicValues();
    if (!this.isCollection() && !this.includeemptyitem && currentValues.filter(v => this.valueIsSelected(v)).length == 0) {
      if (currentValues.length > 0) {
        this.setValueWithoutClosing(currentValues[0].value.trim(), true);
      }
    }
  }
  static get is() { return "k2bt-enhancedcombo"; }
  static get originalStyleUrls() { return {
    "$": ["k2bt-enhancedcombo.css"]
  }; }
  static get styleUrls() { return {
    "$": ["k2bt-enhancedcombo.css"]
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
      "defaultValue": "null"
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
    "includesearch": {
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
      "attribute": "includesearch",
      "reflect": false,
      "defaultValue": "true"
    },
    "includeemptyitem": {
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
      "attribute": "includeemptyitem",
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
    "clearselectioncaption": {
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
      "attribute": "clearselectioncaption",
      "reflect": false,
      "defaultValue": "'Clear selection'"
    },
    "selectallcaption": {
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
      "attribute": "selectallcaption",
      "reflect": false,
      "defaultValue": "'Clear selection'"
    },
    "searchfieldplaceholder": {
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
      "attribute": "searchfieldplaceholder",
      "reflect": false,
      "defaultValue": "'Search'"
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
    "headermaxvisibleitems": {
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
      "attribute": "headermaxvisibleitems",
      "reflect": false,
      "defaultValue": "3"
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
    "showselectionastags": {
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
      "attribute": "showselectionastags",
      "reflect": false,
      "defaultValue": "false"
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
    "displayaslist": {
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
      "attribute": "displayaslist",
      "reflect": false,
      "defaultValue": "false"
    },
    "enableclearselectionaction": {
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
      "attribute": "enableclearselectionaction",
      "reflect": false,
      "defaultValue": "false"
    },
    "enableselectallaction": {
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
      "attribute": "enableselectallaction",
      "reflect": false,
      "defaultValue": "false"
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
        "original": "object",
        "resolved": "object",
        "references": {}
      }
    }, {
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
    }, {
      "method": "searchChangedEvent",
      "name": "searchChanged",
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
    }]; }
  static get listeners() { return [{
      "name": "keydown",
      "method": "processKeydown",
      "target": undefined,
      "capture": false,
      "passive": false
    }, {
      "name": "focusin",
      "method": "onFocusIn",
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
K2btEnhancedcombo.ERROR_SELECTION_FULL = 'SELECTION_FULL';
