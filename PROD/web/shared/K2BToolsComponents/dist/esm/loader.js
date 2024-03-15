import { p as promiseResolve, b as bootstrapLazy } from './index-93e0a246.js';

/*
 Stencil Client Patch Esm v2.17.3 | MIT Licensed | https://stenciljs.com
 */
const patchEsm = () => {
    return promiseResolve();
};

const defineCustomElements = (win, options) => {
  if (typeof window === 'undefined') return Promise.resolve();
  return patchEsm().then(() => {
  return bootstrapLazy([["k2bt-base-color-picker",[[0,"k2bt-base-color-picker",{"columns":[2],"containerclass":[1],"maxSelectionSize":[2,"max-selection-size"],"enabled":[4],"errorCode":[1,"error-code"],"colorOptions":[16],"selectedIds":[16]}]]],["k2bt-enhancedsuggest",[[0,"k2bt-enhancedsuggest",{"value":[16],"values":[1],"noresultsfoundtext":[1],"open":[4],"enableadditem":[4],"additemcaption":[1],"enabled":[4],"readonlyclass":[1],"searchvalue":[1],"placeholder":[1],"selectedValueDescription":[1,"selected-value-description"],"maxSelectionSize":[2,"max-selection-size"],"errorCode":[1,"error-code"],"suggestmaxitems":[2],"activeElementValue":[1,"active-element-value"],"showiconsintags":[4],"emptyitemtext":[1],"setFocusToSearch":[64],"updateDescription":[64],"setValue":[64]},[[2,"input","processInput"],[0,"keydown","processKeydown"],[8,"click","closeMenu"]]]]],["k2bt-image-region-selector",[[0,"k2bt-image-region-selector",{"imageWithRegionsDefinition":[16],"selectedIds":[16],"maxSelectionSize":[2,"max-selection-size"],"errorCode":[1,"error-code"],"enabled":[4]}]]],["k2bt-numeric-slider",[[0,"k2bt-numeric-slider",{"max":[2],"min":[2],"step":[2],"numbervisible":[4],"numberreadonly":[4],"numberclass":[1],"sliderclass":[1],"value":[1],"readonlyclass":[1],"enabled":[4]}]]],["k2bt-toggle-bar",[[0,"k2bt-toggle-bar",{"value":[16],"values":[16],"includeemptyitem":[4],"emptyitemtext":[1],"noresultsfoundtext":[1],"enableadditem":[4],"additemcaption":[1],"enabled":[4],"readonlyclass":[1],"togglestyle":[1],"maxSelectionSize":[2,"max-selection-size"],"errorCode":[1,"error-code"]}]]],["k2bt-calendar-action-menu_11",[[0,"k2bt-calendar-full-view",{"showheader":[4],"showcalendarnavigation":[4],"showperiodnavigation":[4],"showviewselection":[4],"showcalendarselection":[4],"starthour":[2],"endhour":[2],"readonly":[4],"todaycaption":[1],"daycaption":[1],"weekcaption":[1],"workweekcaption":[1],"monthcaption":[1],"yearcaption":[1],"seemorecaption":[1],"itemsperdayinmonthview":[2],"dayviewenabled":[4],"weekviewenabled":[4],"workweekviewenabled":[4],"monthviewenabled":[4],"weekstartday":[1],"dateFrom":[1040],"dateTo":[1040],"currentview":[32],"calendars":[32],"selectedCalendars":[32],"advancedSelectorOpen":[32],"setPeriodAppointments":[64],"switchView":[64],"cancelDraft":[64],"goToNextPeriod":[64],"goToPreviousPeriod":[64],"goToDate":[64]},[[8,"click","closeMenu"]]],[0,"k2bt-edit-collection",{"value":[16],"maxSelectionSize":[2,"max-selection-size"],"datatype":[1],"length":[2],"integers":[2],"decimals":[2],"enabled":[4],"inputclass":[1],"readonlyclass":[1],"invitemessage":[1]}],[0,"k2bt-masked-input",{"mask":[1],"numeric":[4],"enabled":[4],"inputclass":[1],"readonlyclass":[1],"value":[1],"uppercase":[4],"getUnformattedValue":[64],"getFormattedValue":[64]}],[0,"k2bt-numeric-input",{"decimals":[2],"integerdigits":[2],"includethousandseparator":[4],"includesign":[4],"usermustenterdecimalseparator":[4],"decimalseparator":[1],"thousandseparator":[1],"valueprefix":[1],"zeropadding":[4],"inputclass":[1],"readonlyclass":[1],"value":[1],"enabled":[4]},[[2,"keydown","handleKeydown"]]],[0,"k2bt-signature-pad",{"width":[2],"height":[2],"backgroundimageurl":[1],"backgroundcolor":[1],"showclearbutton":[4],"clearbuttoncaption":[1]}],[0,"k2bt-calendar-period-view",{"calendars":[16],"startHour":[2,"start-hour"],"endHour":[2,"end-hour"],"dateFrom":[16],"dateTo":[16],"readonly":[4],"draftItemDescription":[1,"draft-item-description"],"draftItem":[32],"cancelDraft":[64]}],[0,"k2bt-calendar-month-view",{"year":[1026],"month":[1026],"readonly":[4],"calendars":[16],"seemorecaption":[1],"itemsperday":[2],"weekstartday":[1],"currentDate":[32]}],[0,"k2bt-calendar-day-in-month-picker",{"selectedDate":[16],"weekstartday":[1]}],[0,"k2bt-enhancedcombo",{"value":[16],"values":[1],"includesearch":[4],"includeemptyitem":[4],"emptyitemtext":[1],"noresultsfoundtext":[1],"open":[4],"enableadditem":[4],"additemcaption":[1],"clearselectioncaption":[1],"selectallcaption":[1],"searchfieldplaceholder":[1],"searchvalue":[1],"enabled":[4],"maxSelectionSize":[2,"max-selection-size"],"headermaxvisibleitems":[2],"readonlyclass":[1],"errorCode":[1,"error-code"],"showselectionastags":[4],"showiconsintags":[4],"displayaslist":[4],"enableclearselectionaction":[4],"enableselectallaction":[4],"activeElementValue":[1,"active-element-value"]},[[0,"keydown","processKeydown"],[0,"focusin","onFocusIn"],[8,"click","closeMenu"]]],[0,"k2bt-calendar-day-view",{"calendars":[16],"startHour":[2,"start-hour"],"endHour":[2,"end-hour"],"year":[2],"month":[2],"day":[2],"readonly":[4],"draftItemDescription":[1,"draft-item-description"],"showhours":[4],"alldayrows":[2],"draftItem":[32],"currentDate":[32],"cancelDraft":[64]}],[0,"k2bt-calendar-action-menu",{"actions":[16],"isOpen":[32]},[[8,"click","closeMenu"]]]]]], options);
  });
};

export { defineCustomElements };
