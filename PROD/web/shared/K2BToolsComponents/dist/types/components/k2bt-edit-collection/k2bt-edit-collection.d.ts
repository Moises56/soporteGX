import { EventEmitter } from '../../stencil-public-runtime';
export declare class K2btEditCollection {
  static readonly DATATYPE_CHARACTER: string;
  static readonly DATATYPE_NUMERIC: string;
  value: Array<string>;
  maxSelectionSize: number;
  datatype: string;
  length: number;
  integers: number;
  decimals: number;
  enabled: boolean;
  inputclass: string;
  readonlyclass: string;
  invitemessage: string;
  inputEvent: EventEmitter<object>;
  changeEvent: EventEmitter<object>;
  itemInputs: Array<HTMLInputElement>;
  removeItem(index: number): void;
  onInput(index: number, _ev: Event): void;
  _triggerChangeDebouncer: any;
  triggerChangeEvent(): void;
  render(): any;
}
