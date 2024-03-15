import { EventEmitter } from '../../stencil-public-runtime';
import { ImageRegion, ImageWithRegionsDefinition } from '../../utils/utils';
export declare class K2btImageRegionSelector {
  static readonly ERROR_SELECTION_FULL: string;
  imageWithRegionsDefinition: ImageWithRegionsDefinition;
  selectedIds: Array<string>;
  maxSelectionSize: number;
  errorCode: string;
  enabled: boolean;
  selectionChangedEvent: EventEmitter<object>;
  selectionErrorEvent: EventEmitter<object>;
  getRegions(): Array<ImageRegion>;
  itemClicked(id: string): void;
  elementsWithTooltips: any[];
  elementDivs: any[];
  componentDidRender(): void;
  render(): any;
  private renderNonExistingDefinition;
  private renderExistingDefinition;
  renderRegion(r: ImageRegion): any;
  private getBestImageForItemStatus;
  getImage(r: ImageRegion, imageUrl: string): any;
  private getTooltipLines;
  getMapForItem(r: ImageRegion): any;
  bringElementBelowToForeground(e: MouseEvent, regionId: string): void;
  clickBelow(e: any, regionId: any): void;
}
