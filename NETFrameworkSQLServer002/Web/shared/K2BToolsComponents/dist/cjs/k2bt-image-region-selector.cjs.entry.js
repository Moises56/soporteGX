'use strict';

Object.defineProperty(exports, '__esModule', { value: true });

const index = require('./index-4aad5e76.js');
const utils = require('./utils-af9e8537.js');

const k2btImageRegionSelectorCss = ":host{display:block}.K2BT_LocationInBlueprintSelectorContainer{position:relative;background-repeat:no-repeat;background-size:100% 100%}.K2BT_LocationInBlueprintSelectorItem{position:absolute;background-repeat:no-repeat;background-size:100% 100%}.K2BT_LocationInBlueprintSelectorItemName{display:none}.K2BT_LocationInBlueprintSelectorContainer .tooltip-inner{white-space:pre-wrap}.K2BT_LocationInBlueprintSelectorItemUnavailable{cursor:initial;pointer-events:none}";

const K2btImageRegionSelector = class {
  constructor(hostRef) {
    index.registerInstance(this, hostRef);
    this.selectionChangedEvent = index.createEvent(this, "selectionChanged", 7);
    this.selectionErrorEvent = index.createEvent(this, "selectionError", 7);
    this.maxSelectionSize = 1;
    this.enabled = true;
    this.elementsWithTooltips = [];
    this.elementDivs = [];
  }
  getRegions() {
    var _a, _b;
    return (_b = (_a = this.imageWithRegionsDefinition) === null || _a === void 0 ? void 0 : _a.Regions) !== null && _b !== void 0 ? _b : [];
  }
  itemClicked(id) {
    if (this.enabled) {
      var element = this.getRegions().filter(r => r.id == id)[0];
      if (element.status == utils.ImageRegion.AVAILABLE) {
        if (this.selectedIds.includes(id)) {
          // It is always possible to remove items
          this.selectedIds = this.selectedIds.filter(i => i != id);
          this.selectionChangedEvent.emit({});
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
            this.errorCode = K2btImageRegionSelector.ERROR_SELECTION_FULL;
            this.selectionErrorEvent.emit({});
          }
        }
      }
    }
  }
  componentDidRender() {
    // @ts-ignore
    $(this.elementsWithTooltips).tooltip();
  }
  render() {
    if (this.imageWithRegionsDefinition) {
      return this.renderExistingDefinition();
    }
    else {
      return this.renderNonExistingDefinition();
    }
  }
  renderNonExistingDefinition() {
    return index.h("div", null, "Image definition not set");
  }
  renderExistingDefinition() {
    var _a, _b, _c, _d, _e, _f, _g, _h, _j, _k;
    this.elementsWithTooltips = [];
    this.elementDivs = [];
    return (index.h(index.Host, null, index.h("div", { class: (_c = 'K2BT_LocationInBlueprintSelectorContainer ' + ((_b = (_a = this.imageWithRegionsDefinition) === null || _a === void 0 ? void 0 : _a.Frame) === null || _b === void 0 ? void 0 : _b.class)) !== null && _c !== void 0 ? _c : '', style: {
        height: (_e = (_d = this.imageWithRegionsDefinition) === null || _d === void 0 ? void 0 : _d.Frame) === null || _e === void 0 ? void 0 : _e.height,
        width: (_g = (_f = this.imageWithRegionsDefinition) === null || _f === void 0 ? void 0 : _f.Frame) === null || _g === void 0 ? void 0 : _g.width,
        backgroundImage: ((_k = (_j = (_h = this.imageWithRegionsDefinition) === null || _h === void 0 ? void 0 : _h.Frame) === null || _j === void 0 ? void 0 : _j.backgroundImageURL) !== null && _k !== void 0 ? _k : '') != '' ? 'url(' + this.imageWithRegionsDefinition.Frame.backgroundImageURL + ')' : null,
      } }, this.getRegions().map(r => this.renderRegion(r)))));
  }
  renderRegion(r) {
    var imageUrl = this.getBestImageForItemStatus(r);
    var style = {
      backgroundImage: '',
      height: r.height,
      width: r.width,
      top: r.top,
      left: r.left,
    };
    return (index.h("div", { class: 'K2BT_LocationInBlueprintSelectorItem' +
        (this.selectedIds.map(v => v.toString().trim()).includes(r.id.toString().trim()) ? ' K2BT_LocationInBlueprintSelectorItemSelected' : '') +
        (r.status == utils.ImageRegion.UNAVAILABLE || !this.enabled ? ' K2BT_LocationInBlueprintSelectorItemUnavailable' : '') +
        (r.class != '' ? ' ' + r.class : ''), ref: e => this.elementDivs.push({ id: r.id, element: e }), style: style }, this.getMapForItem(r), this.getImage(r, imageUrl), index.h("span", { class: "K2BT_LocationInBlueprintSelectorItemName" }, r.name)));
  }
  getBestImageForItemStatus(r) {
    if (this.selectedIds.map(v => v.toString().trim()).includes(r.id.toString().trim()) && r.selectedImageURL != '')
      return r.selectedImageURL;
    if ((!this.enabled || r.status == utils.ImageRegion.UNAVAILABLE) && r.unavailableImageURL != '')
      return r.unavailableImageURL;
    return r.availableImageURL;
  }
  getImage(r, imageUrl) {
    return (index.h("img", { ref: e => {
        if (r.selectableRegionCoordinates == '')
          this.elementsWithTooltips.push(e);
      }, title: r.selectableRegionCoordinates == '' ? this.getTooltipLines(r) : '', src: imageUrl, style: { height: '100%', width: '100%', cursor: r.selectableRegionCoordinates == '' ? 'pointer' : null }, usemap: r.selectableRegionCoordinates != '' ? '#K2BT_Image' + r.id : null, onClick: () => {
        if (r.selectableRegionCoordinates == '')
          this.itemClicked(r.id);
      } }));
  }
  getTooltipLines(r) {
    if (r.tooltipLines == null || r.tooltipLines.length == 0)
      return null;
    else
      return r.tooltipLines.join('\n');
  }
  getMapForItem(r) {
    if (r.selectableRegionCoordinates != '') {
      return (index.h("map", { name: 'K2BT_Image' + r.id }, index.h("area", { shape: "poly", coords: r.selectableRegionCoordinates, onClick: () => this.itemClicked(r.id), href: "#", title: this.getTooltipLines(r), ref: c => this.elementsWithTooltips.push(c) }), index.h("area", { shape: "poly", coords: '0,0,' + r.width + ',0,' + r.width + ',' + r.height + ',0,' + r.height, onClick: e => this.clickBelow(e, r.id), onMouseOver: e => this.bringElementBelowToForeground(e, r.id) })));
    }
  }
  bringElementBelowToForeground(e, regionId) {
    var evt = e || window.event;
    var regionDiv = this.elementDivs.filter(d => d.id == regionId)[0].element;
    regionDiv.style.pointerEvents = 'none';
    // get element at point of click
    var starter = document.elementFromPoint(evt.clientX, evt.clientY);
    var elements = this.elementDivs.filter(div => div.element.contains(starter));
    if (elements.length > 0) {
      console.log('hovering: ' + elements[0].id);
      this.elementDivs.forEach(el => (el.element.style.zIndex = 'initial'));
      elements.forEach(el => (el.element.style.zIndex = '1'));
    }
    // bring back the cursor
    regionDiv.style.pointerEvents = 'auto';
  }
  clickBelow(e, regionId) {
    var evt = e || window.event;
    var regionDiv = this.elementDivs.filter(d => d.id == regionId)[0].element;
    regionDiv.style.pointerEvents = 'none';
    // get element at point of click
    var starter = document.elementFromPoint(evt.clientX, evt.clientY);
    var elements = this.elementDivs.filter(div => div.element.contains(starter));
    if (elements.length > 0)
      this.itemClicked(elements[0].id);
    // bring back the cursor
    regionDiv.style.pointerEvents = 'auto';
  }
};
K2btImageRegionSelector.ERROR_SELECTION_FULL = 'SELECTION_FULL';
K2btImageRegionSelector.style = k2btImageRegionSelectorCss;

exports.k2bt_image_region_selector = K2btImageRegionSelector;
