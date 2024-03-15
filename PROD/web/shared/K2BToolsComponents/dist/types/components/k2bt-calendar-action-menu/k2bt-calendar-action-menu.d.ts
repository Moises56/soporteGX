import { EventEmitter } from '../../stencil-public-runtime';
import { CalendarItemAction } from '../../utils/utils';
export declare class K2btCalendarActionMenu {
  actions: CalendarItemAction[];
  isOpen: boolean;
  actionClicked: EventEmitter<string>;
  toggleMenu(): void;
  executeAction(action: CalendarItemAction): void;
  quickDaySelectorContainer: HTMLDivElement;
  closeMenu(ev: any): void;
  render(): any;
}
