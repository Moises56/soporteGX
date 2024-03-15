import { EventEmitter } from '../../stencil-public-runtime';
export declare class K2btNumericSlider {
  max: number;
  min: number;
  step: number;
  numbervisible: boolean;
  numberreadonly: boolean;
  numberclass: string;
  sliderclass: string;
  value: string;
  readonlyclass: string;
  enabled: boolean;
  inputEvent: EventEmitter<object>;
  changeEvent: EventEmitter<object>;
  nativeInput: HTMLInputElement;
  auxiliaryInput: HTMLInputElement;
  changeTimeout: any;
  onAuxiliaryInput(): void;
  onSliderInput(): void;
  render(): any;
}
