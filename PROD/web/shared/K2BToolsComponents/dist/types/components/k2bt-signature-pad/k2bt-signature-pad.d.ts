import { EventEmitter } from '../../stencil-public-runtime';
export declare class K2btSignaturePad {
  width: number;
  height: number;
  backgroundimageurl: string;
  backgroundcolor: string;
  showclearbutton: boolean;
  clearbuttoncaption: string;
  changeEvent: EventEmitter<string>;
  canvas: HTMLCanvasElement;
  ctx: CanvasRenderingContext2D;
  isWriting: boolean;
  render(): any;
  componentDidRender(): void;
  clearCanvas(): void;
  handlePointerDown(event: PointerEvent): void;
  setValueDebouncer: any;
  handlePointerUp(): void;
  handlePointerMove(event: PointerEvent): void;
  getCursorPosition(event: PointerEvent): [number, number];
}
