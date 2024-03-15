import { EventEmitter } from '../../stencil-public-runtime';
import { BaseColorOption } from '../../utils/utils';
export declare class K2btBaseColorPicker {
  static readonly ERROR_SELECTION_FULL: string;
  columns: number;
  containerclass: string;
  maxSelectionSize: number;
  enabled: boolean;
  errorCode: string;
  colorOptions: Array<BaseColorOption>;
  selectedIds: Array<string>;
  selectionChangedEvent: EventEmitter<object>;
  selectionErrorEvent: EventEmitter<object>;
  getColorRows(): Array<Array<BaseColorOption>>;
  private colorIsSelected;
  selectColor(c: BaseColorOption): void;
  componentWillRender(): void;
  render(): any;
}
