import{r as s,c as e,h as t,g as i,H as n}from"./p-d5b54d3b.js";import{m as o}from"./p-5b00d7e6.js";const h=class{constructor(t){s(this,t),this.columnResizeStarted=e(this,"columnResizeStarted",7),this.columnResizeFinished=e(this,"columnResizeFinished",7),this.resizing=!1,this.mousemoveFn=this.mousemoveHandler.bind(this)}componentDidLoad(){this.el.addEventListener("mousedown",this.mousedownHandler.bind(this))}mousedownHandler(s){s.stopPropagation(),s.preventDefault(),this.startPageX=s.pageX,this.startColumnWidth=this.column.getBoundingClientRect().width,document.addEventListener("mousemove",this.mousemoveFn,{passive:!0}),document.addEventListener("mouseup",this.mouseupHandler.bind(this),{once:!0}),this.columnResizeStarted.emit()}mousemoveHandler(s){const e=this.startColumnWidth-(this.startPageX-s.pageX);e>=0&&(this.column.size=`minmax(min-content, ${e}px)`)}mouseupHandler(){document.removeEventListener("mousemove",this.mousemoveFn),this.columnResizeFinished.emit()}clickHandler(s){s.stopPropagation()}dblclickHandler(s){s.stopPropagation(),this.column.size=o(s)?"auto":"max-content"}columnResizeStartedHandler(){this.resizing=!0}columnResizeFinishedHandler(){this.resizing=!1}render(){return t("div",{class:"resize-mask",hidden:!this.resizing})}get el(){return i(this)}};h.style=":host{display:block;min-width:1px;height:100%;cursor:ew-resize}.resize-mask{position:fixed;inset:0}";const d=class{constructor(e){s(this,e),this.show=!1}windowClosedHandler(s){s.stopPropagation(),this.column.showSettings=!1}columnSettingsChangedHandler(){this.column.showSettings=!1}render(){return t(n,null,t("ch-window",{modal:!0,container:this.column,xAlign:"inside-start",yAlign:"outside-end",caption:this.column.columnName,closeText:"Close",closeOnOutsideClick:!0,closeOnEscape:!0,allowDrag:"header",hidden:!this.show,exportparts:"mask,window,header,caption,close,main,footer"},t("slot",null)))}};d.style=":host{display:contents}";export{h as ch_grid_column_resize,d as ch_grid_column_settings}