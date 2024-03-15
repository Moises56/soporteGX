/* K2btoolsComponents custom elements bundle */

import type { Components, JSX } from "../types/components";

interface K2btBaseColorPicker extends Components.K2btBaseColorPicker, HTMLElement {}
export const K2btBaseColorPicker: {
  prototype: K2btBaseColorPicker;
  new (): K2btBaseColorPicker;
};

interface K2btCalendarActionMenu extends Components.K2btCalendarActionMenu, HTMLElement {}
export const K2btCalendarActionMenu: {
  prototype: K2btCalendarActionMenu;
  new (): K2btCalendarActionMenu;
};

interface K2btCalendarDayInMonthPicker extends Components.K2btCalendarDayInMonthPicker, HTMLElement {}
export const K2btCalendarDayInMonthPicker: {
  prototype: K2btCalendarDayInMonthPicker;
  new (): K2btCalendarDayInMonthPicker;
};

interface K2btCalendarDayView extends Components.K2btCalendarDayView, HTMLElement {}
export const K2btCalendarDayView: {
  prototype: K2btCalendarDayView;
  new (): K2btCalendarDayView;
};

interface K2btCalendarFullView extends Components.K2btCalendarFullView, HTMLElement {}
export const K2btCalendarFullView: {
  prototype: K2btCalendarFullView;
  new (): K2btCalendarFullView;
};

interface K2btCalendarMonthView extends Components.K2btCalendarMonthView, HTMLElement {}
export const K2btCalendarMonthView: {
  prototype: K2btCalendarMonthView;
  new (): K2btCalendarMonthView;
};

interface K2btCalendarPeriodView extends Components.K2btCalendarPeriodView, HTMLElement {}
export const K2btCalendarPeriodView: {
  prototype: K2btCalendarPeriodView;
  new (): K2btCalendarPeriodView;
};

interface K2btEditCollection extends Components.K2btEditCollection, HTMLElement {}
export const K2btEditCollection: {
  prototype: K2btEditCollection;
  new (): K2btEditCollection;
};

interface K2btEnhancedcombo extends Components.K2btEnhancedcombo, HTMLElement {}
export const K2btEnhancedcombo: {
  prototype: K2btEnhancedcombo;
  new (): K2btEnhancedcombo;
};

interface K2btEnhancedsuggest extends Components.K2btEnhancedsuggest, HTMLElement {}
export const K2btEnhancedsuggest: {
  prototype: K2btEnhancedsuggest;
  new (): K2btEnhancedsuggest;
};

interface K2btImageRegionSelector extends Components.K2btImageRegionSelector, HTMLElement {}
export const K2btImageRegionSelector: {
  prototype: K2btImageRegionSelector;
  new (): K2btImageRegionSelector;
};

interface K2btMaskedInput extends Components.K2btMaskedInput, HTMLElement {}
export const K2btMaskedInput: {
  prototype: K2btMaskedInput;
  new (): K2btMaskedInput;
};

interface K2btNumericInput extends Components.K2btNumericInput, HTMLElement {}
export const K2btNumericInput: {
  prototype: K2btNumericInput;
  new (): K2btNumericInput;
};

interface K2btNumericSlider extends Components.K2btNumericSlider, HTMLElement {}
export const K2btNumericSlider: {
  prototype: K2btNumericSlider;
  new (): K2btNumericSlider;
};

interface K2btSignaturePad extends Components.K2btSignaturePad, HTMLElement {}
export const K2btSignaturePad: {
  prototype: K2btSignaturePad;
  new (): K2btSignaturePad;
};

interface K2btToggleBar extends Components.K2btToggleBar, HTMLElement {}
export const K2btToggleBar: {
  prototype: K2btToggleBar;
  new (): K2btToggleBar;
};

/**
 * Utility to define all custom elements within this package using the tag name provided in the component's source. 
 * When defining each custom element, it will also check it's safe to define by:
 *
 * 1. Ensuring the "customElements" registry is available in the global context (window).
 * 2. The component tag name is not already defined.
 *
 * Use the standard [customElements.define()](https://developer.mozilla.org/en-US/docs/Web/API/CustomElementRegistry/define) 
 * method instead to define custom elements individually, or to provide a different tag name.
 */
export declare const defineCustomElements: (opts?: any) => void;

/**
 * Used to manually set the base path where assets can be found.
 * If the script is used as "module", it's recommended to use "import.meta.url",
 * such as "setAssetPath(import.meta.url)". Other options include
 * "setAssetPath(document.currentScript.src)", or using a bundler's replace plugin to
 * dynamically set the path at build time, such as "setAssetPath(process.env.ASSET_PATH)".
 * But do note that this configuration depends on how your script is bundled, or lack of
 * bunding, and where your assets can be loaded from. Additionally custom bundling
 * will have to ensure the static assets are copied to its build directory.
 */
export declare const setAssetPath: (path: string) => void;

export interface SetPlatformOptions {
  raf?: (c: FrameRequestCallback) => number;
  ael?: (el: EventTarget, eventName: string, listener: EventListenerOrEventListenerObject, options: boolean | AddEventListenerOptions) => void;
  rel?: (el: EventTarget, eventName: string, listener: EventListenerOrEventListenerObject, options: boolean | AddEventListenerOptions) => void;
  ce?: (eventName: string, opts?: any) => CustomEvent;
}
export declare const setPlatformOptions: (opts: SetPlatformOptions) => void;

export type { Components, JSX };

export * from '../types';
