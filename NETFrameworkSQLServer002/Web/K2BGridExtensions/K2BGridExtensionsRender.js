var GridColumnMetadata = /** @class */ (function () {
    function GridColumnMetadata() {
    }
    return GridColumnMetadata;
}());
var Aggregations = /** @class */ (function () {
    function Aggregations() {
    }
    return Aggregations;
}());
var GridActionGroup = /** @class */ (function () {
    function GridActionGroup() {
    }
    return GridActionGroup;
}());
var GridColumnGroups = /** @class */ (function () {
    function GridColumnGroups() {
    }
    return GridColumnGroups;
}());
var K2BExtendedGridMetadata = /** @class */ (function () {
    function K2BExtendedGridMetadata() {
    }
    K2BExtendedGridMetadata.POSITION_RIGHT = 'Right';
    K2BExtendedGridMetadata.POSITION_LEFT = 'Left';
    return K2BExtendedGridMetadata;
}());
var GridActionMenuMap = /** @class */ (function () {
    function GridActionMenuMap() {
    }
    return GridActionMenuMap;
}());
var K2BGridExtensions = /** @class */ (function () {
    function K2BGridExtensions(jQuery) {
        var _this = this;
        this.OrderByChanged = null;
        this.ColumnOrderChanged = null;
        this.AGGREGATION_ROW_CLASS = 'K2BT_GridAggregationsRow';
        this.metadata = null;
        this.selectedGridOrder = -1;
        this.initializationComplete = false;
        this.filterScrollTimeout = null;
        this.scrollHandler = function (ev) {
            _this.overflowMenus
                .filter(function (menu) { return menu.container.style.display != 'none'; })
                .forEach(function (menu) {
                _this.fixActionContainerPosition(menu.toggle, menu.container);
            });
            _this.actionGroups
                .filter(function (menu) { return menu.container.style.display != 'none'; })
                .forEach(function (menu) {
                _this.fixActionContainerPosition(menu.toggle, menu.container);
            });
            if (_this.filterScrollTimeout != null) {
                clearTimeout(_this.filterScrollTimeout);
            }
            _this.metadata.Columns.filter(function (col) { return col.FilterSectionInternalName; }).forEach(function (column) {
                var section = document.getElementById(column.FilterSectionInternalName);
                section.style.visibility = 'hidden';
            });
            _this.filterScrollTimeout = setTimeout(function () {
                var headerRow = _this.getHeadersRow(_this.getTable());
                _this.fixFilterSectionPositions(headerRow);
            }, 200);
        };
        this.windowClickHandler = function (ev) {
            var table = document.getElementById(_this.GetGridTableId());
            _this.hideActionMenus(ev, table);
            _this.hideFilterSections(ev);
        };
        this.rwdVisibilityClasses = ['InvisibleInExtraSmallColumn', 'InvisibleInSmallColumn', 'InvisibleInMediumColumn', 'InvisibleInLargeColumn'];
        this.overflowMenus = [];
        this.actionGroups = [];
        this.columnOrder = null;
        this.dragging = false;
        this.$ = jQuery;
    }
    K2BGridExtensions.prototype.SetGridMetadata = function (value) {
        this.metadata = value;
    };
    K2BGridExtensions.prototype.GetGridMetadata = function () {
        return this.metadata;
    };
    K2BGridExtensions.prototype.SetSelectedGridOrder = function (data) {
        this.selectedGridOrder = data;
    };
    K2BGridExtensions.prototype.GetSelectedGridOrder = function () {
        return this.selectedGridOrder;
    };
    K2BGridExtensions.prototype.show = function () {
        try {
            if (this.propertiesAreLoaded()) {
                var table = this.getTable();
                var headerRow = this.getHeadersRow(table);
                this.addOrderByFeature(headerRow);
                this.addGridFiltersFeature(table, headerRow);
                this.addGridOverflowMenu(table, headerRow);
                this.addGridActionGroups(table, headerRow);
                this.addGridColumnOrdering(table, headerRow);
                this.addGridTotalsFeature(table, headerRow);
                //@ts-ignore
                gx.fx.obs.addObserver('grid.onafterrender', this, this.refreshGridFiltersFeature, { single: false, unique: true });
                window.addEventListener('click', this.windowClickHandler);
                window.addEventListener('scroll', this.scrollHandler);
                this.initializationComplete = true;
            }
        }
        catch (error) {
            console.log(error);
        }
    };
    K2BGridExtensions.prototype.propertiesAreLoaded = function () {
        return this.GridControlName !== undefined;
    };
    K2BGridExtensions.prototype.getTable = function () {
        return document.getElementById(this.GetGridTableId());
    };
    K2BGridExtensions.prototype.destroy = function () {
        window.removeEventListener('click', this.windowClickHandler);
        window.removeEventListener('scroll', this.scrollHandler);
        this.cleanupOrphanNodes();
    };
    K2BGridExtensions.prototype.cleanupOrphanNodes = function () {
        this.overflowMenus.forEach(function (m) { return m.container.remove(); });
        this.actionGroups.forEach(function (ag) { return ag.container.remove(); });
        this.metadata.Columns.filter(function (col) { return col.FilterSectionInternalName; }).forEach(function (column) { return document.getElementById(column.FilterSectionInternalName).remove(); });
    };
    K2BGridExtensions.prototype.concat = function (x, y) {
        return x.concat(y);
    };
    K2BGridExtensions.prototype.flatMap = function (f, xs) {
        return xs.map(f).reduce(this.concat, []);
    };
    K2BGridExtensions.prototype.getArray = function (e) {
        return Array.prototype.slice.call(e);
    };
    K2BGridExtensions.prototype.addGridOverflowMenu = function (table, headerRow) {
        var _a, _b, _c, _d;
        var _this = this;
        var headers = Array.prototype.slice.call(headerRow.children);
        this.overflowMenus.forEach(function (menu) {
            if (!document.body.contains(menu.toggle)) {
                menu.container.remove();
                _this.overflowMenus.splice(_this.overflowMenus.indexOf(menu), 1);
            }
        });
        if (table.getElementsByClassName('K2BT_ActionForOverflowMenu').length > 0) {
            var insertBeforeOnLeftId = 0;
            if (this.metadata.OverflowActionPosition == K2BExtendedGridMetadata.POSITION_LEFT) {
                for (var i = 0; i < this.metadata.Columns.length; i++) {
                    if (this.metadata.Columns[i].Name.indexOf('action:') != 0 && this.metadata.Columns[i].Name != this.metadata.RowSelectionFlagColumnName) {
                        insertBeforeOnLeftId = i;
                        break;
                    }
                }
            }
            var header = null;
            var overflowMenuHeaders = headers.filter(function (columnHeader) { return columnHeader.dataset.k2btoolsOverflowMenuHeader == 'true'; });
            // If the overflow menu has not been created yet, and overflow actions exist in the grid
            if (overflowMenuHeaders.length == 0) {
                var rowCellClasses = this.flatMap(function (h) { return _this.getArray(h.classList); }, headers.filter(function (h) { return h.classList.contains('K2BT_ActionForOverflowMenu'); })).filter(function (c) { return c != '' && c.indexOf('gx') != 0 && c != 'K2BT_ActionForOverflowMenu'; });
                var th = document.createElement('th');
                th.dataset.k2btoolsOverflowMenuHeader = 'true';
                // Add all row classes (except those used for RWD column visibility)
                (_a = th.classList).add.apply(_a, rowCellClasses.filter(function (item) { return _this.rwdVisibilityClasses.indexOf(item) == -1; }));
                // Add RWD column visibility classes that are not mentioned in the actions
                (_b = th.classList).add.apply(_b, this.rwdVisibilityClasses.filter(function (item) { return rowCellClasses.indexOf(item) == -1; }));
                if (this.metadata.OverflowActionPosition == K2BExtendedGridMetadata.POSITION_RIGHT) {
                    headerRow.append(th);
                }
                else {
                    headerRow.insertBefore(th, this.getArray(headerRow.children).filter(function (el) { return el.dataset.colindex == insertBeforeOnLeftId; })[0]);
                }
                header = th;
            }
            else {
                header = overflowMenuHeaders[0];
            }
            var lastRowCell = null;
            var rows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
            for (i = 0; i < rows.length; i++) {
                var row = rows[i];
                var cells = this.getArray(row.children);
                var overflowActionsContainer;
                var moreActionsToggle;
                if (!row.classList.contains(this.AGGREGATION_ROW_CLASS)) {
                    var overflowMenuCells = cells.filter(function (cell) { return cell.dataset.k2btoolsOverflowmenu == 'true'; });
                    if (overflowMenuCells.length == 0) {
                        var rowCellClasses = this.flatMap(function (h) { return _this.getArray(h.classList); }, cells.filter(function (h) { return h.classList.contains('K2BT_ActionForOverflowMenu'); })).filter(function (c) { return c != '' && c.indexOf('gx') != 0 && c != 'K2BT_ActionForOverflowMenu'; });
                        var containsImage = cells.filter(function (cell) { return cell.classList.contains('K2BT_ActionForOverflowMenu') && cell.getElementsByTagName('img').length > 0; }).length > 0;
                        var moreActionsCell = document.createElement('td');
                        moreActionsCell.classList.add('K2BT_OverflowActionsCollapsibleContainer');
                        moreActionsCell.dataset.k2btoolsOverflowmenu = 'true';
                        // Add all row classes (except those used for RWD column visibility)
                        (_c = moreActionsCell.classList).add.apply(_c, rowCellClasses.filter(function (item) { return _this.rwdVisibilityClasses.indexOf(item) == -1; }));
                        // Add RWD column visibility classes that are not mentioned in the actions
                        (_d = moreActionsCell.classList).add.apply(_d, this.rwdVisibilityClasses.filter(function (item) { return rowCellClasses.indexOf(item) == -1; }));
                        var moreActionsDiv = document.createElement('div');
                        moreActionsDiv.classList.add('K2BT_OverflowActionsCellContainer');
                        moreActionsCell.appendChild(moreActionsDiv);
                        moreActionsToggle = document.createElement('span');
                        moreActionsToggle.classList.add('K2BT_OverflowActionsToggle');
                        moreActionsToggle.appendChild(document.createElement('a'));
                        moreActionsDiv.appendChild(moreActionsToggle);
                        overflowActionsContainer = document.createElement('div');
                        overflowActionsContainer.classList.add('K2BT_OverflowActionsContainer');
                        if (containsImage)
                            overflowActionsContainer.classList.add('K2BT_OverflowActionsContainerWithImage');
                        overflowActionsContainer.style.display = 'none';
                        document.body.appendChild(overflowActionsContainer);
                        if (this.metadata.OverflowActionPosition == K2BExtendedGridMetadata.POSITION_RIGHT) {
                            row.appendChild(moreActionsCell);
                        }
                        else {
                            row.insertBefore(moreActionsCell, this.getArray(row.children).filter(function (cell) { return cell.dataset.colindex == insertBeforeOnLeftId; })[0]);
                        }
                        this.overflowMenus.push({
                            toggle: moreActionsToggle,
                            container: overflowActionsContainer,
                        });
                        this.addToggleToMenu(overflowActionsContainer, moreActionsToggle);
                        lastRowCell = moreActionsCell;
                    }
                    else {
                        lastRowCell = overflowMenuCells[0];
                        moreActionsToggle = cells.filter(function (c) { return c.dataset.k2btoolsOverflowmenu == 'true'; }).map(function (c) { return c.getElementsByClassName('K2BT_OverflowActionsToggle')[0]; })[0];
                        overflowActionsContainer = this.overflowMenus.filter(function (menu) { return menu.toggle == moreActionsToggle; })[0].container;
                    }
                    this.addRowActionsToMenu(cells, 'K2BT_ActionForOverflowMenu', overflowActionsContainer, moreActionsToggle, true);
                }
                else {
                    // add empty cell at location
                    var td = document.createElement('td');
                    td.dataset.k2btoolsOverflowmenu = 'true';
                    row.appendChild(td);
                }
            }
            if (header != null && lastRowCell != null) {
                header.style.width = lastRowCell.offsetWidth + 'px';
            }
            this.parents(table)
                .filter(function (e) {
                return (window.getComputedStyle(e).overflowY == 'scroll' ||
                    window.getComputedStyle(e).overflowX == 'scroll' ||
                    window.getComputedStyle(e).overflowY == 'auto' ||
                    window.getComputedStyle(e).overflowX == 'auto') &&
                    e.tagName != 'BODY';
            })
                .forEach(function (e) { return e.addEventListener('scroll', _this.scrollHandler); });
        }
    };
    K2BGridExtensions.prototype.getCurrentGridColumnPositionByName = function (name, row) {
        for (var i = 0; i < this.metadata.Columns.length; i++) {
            if (this.metadata.Columns[i].Name == name) {
                for (var j = 0; j < row.children.length; j++) {
                    if (row.children[j].dataset.colindex == i.toString())
                        return j;
                }
            }
        }
        return -1;
    };
    K2BGridExtensions.prototype.addGridActionGroups = function (table, headerRow) {
        var _a, _b;
        var _this = this;
        var _c, _d;
        if (((_d = (_c = this.metadata.ActionGroups) === null || _c === void 0 ? void 0 : _c.length) !== null && _d !== void 0 ? _d : 0) > 0 && table != null) {
            this.actionGroups.forEach(function (menu) {
                if (!document.body.contains(menu.toggle)) {
                    menu.container.remove();
                    _this.actionGroups.splice(_this.actionGroups.indexOf(menu), 1);
                }
            });
            for (var i = 0; i < this.metadata.ActionGroups.length; i++) {
                var group = this.metadata.ActionGroups[i];
                var groupHeader = null;
                var groupHeaders = this.getArray(headerRow.getElementsByTagName('TH')).filter(function (th) { return th.dataset.k2btoolsActiongroup == i.toString(); });
                if (groupHeaders.length == 0) {
                    var columnIndexes = group.MemberColumnNames.map(function (cn) { return _this.getCurrentGridColumnPositionByName(cn, headerRow); });
                    var rowCellClasses = this.flatMap(function (i) { return _this.getArray(headerRow.children[i].classList); }, columnIndexes).filter(function (item) { return item != '' && item.indexOf('gx') != 0 && item != 'K2BT_InvisibleColumn'; });
                    var th = document.createElement('th');
                    th.dataset.k2btoolsActiongroup = i.toString();
                    (_a = th.classList).add.apply(_a, rowCellClasses);
                    headerRow.insertBefore(th, headerRow.children[columnIndexes[0]]);
                    groupHeader = th;
                }
                else {
                    groupHeader = groupHeaders[0];
                }
                var lastRowGroupCell = null;
                var rows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
                for (var j = 0; j < rows.length; j++) {
                    var row = rows[j];
                    var cells = this.getArray(row.children);
                    var columnIndexes = group.MemberColumnNames.map(function (cn) { return _this.getCurrentGridColumnPositionByName(cn, row); });
                    var overflowActionsContainer;
                    var moreActionsToggle;
                    if (!row.classList.contains(this.AGGREGATION_ROW_CLASS)) {
                        var groupCells = cells.filter(function (c) { return c.dataset.k2btoolsActiongroup == i.toString(); });
                        if (groupCells.length == 0) {
                            var rowCellClasses = this.flatMap(function (i) { return _this.getArray(cells[i].classList); }, columnIndexes).filter(function (item) { return item != '' && item.indexOf('gx') != 0 && item != 'K2BT_InvisibleColumn'; });
                            var containsImage = columnIndexes.filter(function (i) { return cells[i].getElementsByTagName('IMG').length > 0; }).length > 0;
                            var moreActionsCell = document.createElement('TD');
                            moreActionsCell.classList.add('K2BT_OverflowActionsCollapsibleContainer');
                            moreActionsCell.dataset.k2btoolsActiongroup = i.toString();
                            // Add all row classes (except those used for RWD column visibility)
                            (_b = moreActionsCell.classList).add.apply(_b, rowCellClasses.filter(function (item) { return _this.rwdVisibilityClasses.indexOf(item) == -1; }));
                            var moreActionsDiv = document.createElement('div');
                            moreActionsDiv.classList.add('K2BT_OverflowActionsCellContainer');
                            moreActionsCell.appendChild(moreActionsDiv);
                            if (group.Caption != null && group.Caption != '' && group.Caption != undefined) {
                                moreActionsToggle = document.createElement('SPAN');
                                moreActionsToggle.classList.add('K2BT_OverflowActionsToggleText');
                                var a = document.createElement('A');
                                moreActionsToggle.appendChild(a);
                                a.appendChild(document.createTextNode(group.Caption));
                            }
                            else {
                                moreActionsToggle = document.createElement('SPAN');
                                moreActionsToggle.classList.add('K2BT_OverflowActionsToggle');
                                var a = document.createElement('A');
                                moreActionsToggle.appendChild(a);
                            }
                            moreActionsDiv.append(moreActionsToggle);
                            overflowActionsContainer = document.createElement('div');
                            overflowActionsContainer.classList.add('K2BT_OverflowActionsContainer');
                            if (containsImage)
                                overflowActionsContainer.classList.add('K2BT_OverflowActionsContainerWithImage');
                            overflowActionsContainer.style.display = 'none';
                            document.body.appendChild(overflowActionsContainer);
                            row.insertBefore(moreActionsCell, row.children[columnIndexes[0]]);
                            this.actionGroups.push({
                                toggle: moreActionsToggle,
                                container: overflowActionsContainer,
                            });
                            this.addToggleToMenu(overflowActionsContainer, moreActionsToggle);
                            lastRowGroupCell = moreActionsCell;
                        }
                        else {
                            lastRowGroupCell = groupCells[0];
                            moreActionsToggle = cells.filter(function (c) { return c.dataset.k2btoolsActiongroup == i.toString(); }).map(function (c) { return c.getElementsByClassName('K2BT_OverflowActionsToggleText')[0]; })[0];
                            overflowActionsContainer = this.actionGroups.filter(function (menu) { return menu.toggle == moreActionsToggle; })[0].container;
                        }
                        this.addCellActionsToMenu(columnIndexes.map(function (i) { return cells[i]; }), '', overflowActionsContainer, moreActionsToggle, false);
                    }
                    else {
                        // add empty cell at location
                        var th = document.createElement('td');
                        th.dataset.k2btoolsActiongroup = i.toString();
                        row.insertBefore(th, row.children[columnIndexes[0]]);
                    }
                }
                if (lastRowGroupCell != null && groupHeader != null) {
                    groupHeader.style.width = lastRowGroupCell.offsetWidth + 'px';
                }
                this.parents(table)
                    .filter(function (e) {
                    return (window.getComputedStyle(e).overflowY == 'scroll' ||
                        window.getComputedStyle(e).overflowX == 'scroll' ||
                        window.getComputedStyle(e).overflowY == 'auto' ||
                        window.getComputedStyle(e).overflowX == 'auto') &&
                        e.tagName != 'BODY';
                })
                    .forEach(function (e) { return e.addEventListener('scroll', _this.scrollHandler); });
            }
        }
    };
    K2BGridExtensions.prototype.addRowActionsToMenu = function (cells, className, overflowActionsContainer, toggleControl, addRWDClasses) {
        var actionCells = cells.filter(function (c) { return c.classList.contains(className); });
        this.addCellActionsToMenu(actionCells, className, overflowActionsContainer, toggleControl, addRWDClasses);
    };
    K2BGridExtensions.prototype.addCellActionsToMenu = function (actionCells, className, overflowActionsContainer, toggleControl, addRWDClasses) {
        var _a, _b;
        var actionsInMenu = 0;
        for (var i = 0; i < actionCells.length; i++) {
            var cell = actionCells[i];
            if (cell.style.display != 'none') {
                var rowCellClasses = Array.prototype.slice.call(cell.classList).filter(function (f) { return f != '' && f.indexOf('gx') != 0 && f != className; });
                var id, txt, imgSrc, enabled, imageClassList;
                if (cell.getElementsByTagName('IMG').length > 0) {
                    var img = cell.getElementsByTagName('IMG')[0];
                    id = img.id;
                    imgSrc = img.src;
                    txt = img.title;
                    imageClassList = this.getArray(img.classList).filter(function (c) { return c.indexOf('GX_Image_') == 0; });
                    if (txt == undefined || txt == '') {
                        txt = img.dataset.originalTitle;
                    }
                    if (txt == undefined || txt == '') {
                        txt = img.alt;
                    }
                    enabled = !img.classList.contains('gx-disabled');
                }
                else {
                    var sp = cell.getElementsByTagName('SPAN')[0];
                    id = sp.id;
                    txt = sp.textContent;
                    imgSrc = '';
                    enabled = txt != '';
                }
                if (enabled) {
                    actionsInMenu++;
                    if (Array.prototype.slice.call(overflowActionsContainer.children).filter(function (e) { return e.dataset.k2btoolsOriginalId == id; }).length == 0) {
                        var actionDiv = document.createElement('div');
                        actionDiv.classList.add('K2BT_OverflowMenuAction');
                        if (addRWDClasses) {
                            var rwdClassesForAction = this.rwdVisibilityClasses.filter(function (item) { return rowCellClasses.indexOf(item) == -1; });
                            if (rwdClassesForAction.length != this.rwdVisibilityClasses.length) {
                                (_a = actionDiv.classList).add.apply(_a, rwdClassesForAction);
                            }
                        }
                        actionDiv.dataset.k2btoolsOriginalId = id;
                        if (imgSrc) {
                            var img = document.createElement('img');
                            img.src = imgSrc;
                            (_b = img.classList).add.apply(_b, imageClassList);
                            actionDiv.appendChild(img);
                        } //actionDiv.style.backgroundImage = "url('" + imgSrc + "')";
                        var actionSpan = document.createElement('span');
                        actionSpan.appendChild(document.createTextNode(txt));
                        actionDiv.appendChild(actionSpan);
                        overflowActionsContainer.appendChild(actionDiv);
                        var uc = this;
                        actionDiv.addEventListener('click', function (e) {
                            var originalElement = document.getElementById(e.currentTarget.dataset.k2btoolsOriginalId);
                            uc.getArray(document.getElementsByClassName('K2BT_OverflowActionsToggleOpen')).forEach(function (el) { return el.classList.remove('K2BT_OverflowActionsToggleOpen'); });
                            if (originalElement.tagName == 'SPAN') {
                                uc.simulateClick(originalElement.getElementsByTagName('A')[0]);
                            }
                            else {
                                uc.simulateClick(originalElement);
                            }
                            overflowActionsContainer.style.display = 'none';
                        });
                    }
                }
            }
        }
        overflowActionsContainer.style.display = null;
        if (overflowActionsContainer.getBoundingClientRect().left < 0) {
            overflowActionsContainer.style.right = 'initial';
        }
        overflowActionsContainer.style.display = 'none';
        if (actionsInMenu == 0) {
            toggleControl.style.display = 'none';
        }
    };
    K2BGridExtensions.prototype.simulateClick = function (elem) {
        if (elem != null) {
            // Create our event (with options)
            var evt = new MouseEvent('click', {
                bubbles: true,
                cancelable: true,
                view: window,
            });
            // If cancelled, don't dispatch our event
            var canceled = !elem.dispatchEvent(evt);
        }
    };
    K2BGridExtensions.prototype.parents = function (element) {
        var result = [];
        var e = element.parentElement;
        while (e != null) {
            result.push(e);
            e = e.parentElement;
        }
        return result;
    };
    K2BGridExtensions.prototype.addToggleToMenu = function (overflowActionsContainer, moreActionsToggle) {
        var uc = this;
        moreActionsToggle.addEventListener('click', function () {
            if (overflowActionsContainer.style.display == 'none') {
                overflowActionsContainer.style.display = null;
                moreActionsToggle.classList.add('K2BT_OverflowActionsToggleOpen');
            }
            else {
                overflowActionsContainer.style.display = 'none';
                moreActionsToggle.classList.remove('K2BT_OverflowActionsToggleOpen');
            }
            uc.fixActionContainerPosition(moreActionsToggle, overflowActionsContainer);
        });
    };
    K2BGridExtensions.prototype.fixActionContainerPosition = function (toggle, container) {
        if (this.isVisibleInScroll(toggle, container)) {
            var toggleBoundingRect = toggle.getBoundingClientRect();
            var containerBoundingRect = container.getBoundingClientRect();
            var topValue = toggleBoundingRect.top + toggleBoundingRect.height;
            if (topValue + containerBoundingRect.height > document.documentElement.clientHeight) {
                topValue -= toggleBoundingRect.height + containerBoundingRect.height;
            }
            container.style.top = topValue + 'px';
            var width = containerBoundingRect.width;
            var leftValue = toggleBoundingRect.left - width + toggleBoundingRect.width;
            if (leftValue > 0) {
                container.style.left = leftValue + 'px';
            }
            else {
                container.style.left = leftValue + width - toggleBoundingRect.width + 'px';
            }
        }
        else {
            container.style.display = 'none';
            toggle.classList.remove('K2BT_OverflowActionsToggleOpen');
        }
    };
    K2BGridExtensions.prototype.isVisibleInScroll = function (toggle, container) {
        var _this = this;
        var scrollContainers = this.parents(toggle).filter(function (e) {
            return (window.getComputedStyle(e).overflowY == 'scroll' ||
                window.getComputedStyle(e).overflowX == 'scroll' ||
                window.getComputedStyle(e).overflowY == 'auto' ||
                window.getComputedStyle(e).overflowX == 'auto') &&
                e.tagName != 'BODY';
        });
        if (scrollContainers.length == 0)
            return true;
        return scrollContainers.filter(function (scrollContainer) { return !_this.isVisibleInScrollContainer(toggle, scrollContainer, container); }).length == 0;
    };
    K2BGridExtensions.prototype.isVisibleInScrollContainer = function (element, scrollContainer, container) {
        var _a;
        var elementPos = element.getBoundingClientRect();
        var containerPos = scrollContainer.getBoundingClientRect();
        var elementBottomEdge = elementPos.top + elementPos.height;
        var containerTopEdge = containerPos.top;
        var containerBottomEdge = containerPos.top + containerPos.height;
        // temporarily hide actions container
        var originalDisplayValue = container.style.display;
        container.style.display = 'none';
        var elementInPos = document.elementFromPoint(elementPos.left + elementPos.width, elementPos.top + elementPos.height);
        while (elementInPos != null &&
            !elementInPos.classList.contains('K2BT_OverflowActionsCellContainer') &&
            !elementInPos.classList.contains('K2BT_OverflowActionsCollapsibleContainer')) {
            elementInPos = elementInPos.parentElement;
        }
        container.style.display = originalDisplayValue;
        return (_a = (containerTopEdge < elementBottomEdge && containerBottomEdge > elementBottomEdge && (elementInPos === null || elementInPos === void 0 ? void 0 : elementInPos.contains(element)))) !== null && _a !== void 0 ? _a : false;
    };
    K2BGridExtensions.prototype.refreshGridFiltersFeature = function () {
        try {
            var table = document.getElementById(this.GetGridTableId());
            var headerRow = this.getHeadersRow(table);
            this.refreshGridContents(table, headerRow);
            this.addGridFiltersFeature(table, headerRow);
        }
        catch (e) {
            console.log(e);
        }
    };
    K2BGridExtensions.prototype.isVisibleTable = function (table) {
        return table.offsetWidth > 0 && table.offsetHeight > 0;
    };
    K2BGridExtensions.prototype.GetTotalRows = function () {
        var maxRows = 1;
        for (var rowIndex in this.metadata.Columns) {
            if (this.metadata.Columns[rowIndex].Aggregations && this.metadata.Columns[rowIndex].Aggregations.length > maxRows) {
                maxRows = this.metadata.Columns[rowIndex].Aggregations.length;
            }
        }
        return maxRows;
    };
    K2BGridExtensions.prototype.addGridTotalsFeature = function (table, headerRow) {
        var tbody = table.getElementsByTagName('tbody')[0];
        if (this.metadata.Columns.filter(function (c) { return c.Aggregations && c.Aggregations.length; }).length > 0 && tbody.getElementsByTagName('tr').length > 0) {
            var firstRow = tbody.getElementsByTagName('tr')[0];
            var elements = tbody.getElementsByClassName(this.AGGREGATION_ROW_CLASS);
            while (elements.length > 0) {
                tbody.removeChild(elements[0]);
            }
            var maxRows = this.GetTotalRows();
            for (var row = 0; row < maxRows; row++) {
                var tr = document.createElement('tr');
                tr.className = this.AGGREGATION_ROW_CLASS;
                tbody.appendChild(tr);
                var lastCaption = '';
                for (var col = 0; col < firstRow.children.length; col++) {
                    var td = document.createElement('td');
                    tr.appendChild(td);
                    var tdInFirstRow = firstRow.children[col];
                    td.className = tdInFirstRow.className;
                    td.style.cssText = tdInFirstRow.style.cssText;
                    if (col == firstRow.children.length) {
                        td.classList.add('K2BToolsLastVisibleColumn');
                    }
                    var p = document.createElement('p');
                    p.className = 'form-control-static';
                    td.append(p);
                    var flexTable = document.createElement('div');
                    flexTable.className = 'K2BT_AggregationContainer';
                    p.append(flexTable);
                    if (tdInFirstRow.dataset.colindex != null && tdInFirstRow.dataset.colindex != undefined && tdInFirstRow.dataset.colindex != '') {
                        td.dataset.colindex = tdInFirstRow.dataset.colindex;
                        var column = this.metadata.Columns[td.dataset.colindex];
                        if (column.Aggregations && row < column.Aggregations.length) {
                            var columnHeaderCell = Array.prototype.slice.call(headerRow.childNodes).filter(function (h) { return h.dataset.colindex == td.dataset.colindex; })[0];
                            if (column.Aggregations[row].Caption != null && column.Aggregations[row].Caption.trim() != '') {
                                var captionDiv = document.createElement('div');
                                captionDiv.className = 'K2BT_ColumnAggregationCaption';
                                if (lastCaption != column.Aggregations[row].Caption) {
                                    captionDiv.classList.add('K2BT_ColumnAggregationcaptionFirst');
                                    lastCaption = column.Aggregations[row].Caption;
                                }
                                flexTable.appendChild(captionDiv);
                                captionDiv.appendChild(document.createTextNode(column.Aggregations[row].Caption));
                                columnHeaderCell.title = column.Aggregations[row].Caption.trim() + ': ' + column.Aggregations[row].Value.trim();
                            }
                            else {
                                columnHeaderCell.title = column.Aggregations[row].Value.trim();
                            }
                            var valueDiv = document.createElement('div');
                            var spansInFirstRow = tdInFirstRow.getElementsByTagName('span');
                            if (spansInFirstRow.length > 0)
                                valueDiv.className = spansInFirstRow[0].className;
                            valueDiv.dataset.gxReadonly = '';
                            valueDiv.appendChild(document.createTextNode(column.Aggregations[row].Value));
                            flexTable.appendChild(valueDiv);
                        }
                    }
                }
            }
        }
    };
    K2BGridExtensions.prototype.addGridFiltersFeature = function (table, headerRow) {
        var _this = this;
        this.metadata.Columns.filter(function (col) { return col.FilterSectionInternalName; }).forEach(function (column) {
            var th = _this.getTableHeaderForColumn(column, headerRow);
            var filterSection = document.getElementById(column.FilterSectionInternalName);
            var spans = Array.prototype.slice.call(th.childNodes).filter(function (e) { return e instanceof HTMLSpanElement && e.className == 'K2BT_ColumnFilterButton'; });
            if (spans.length == 0) {
                var span = document.createElement('span');
                span.className = 'K2BT_ColumnFilterButton';
                th.appendChild(span);
                span.addEventListener('click', function (ev) {
                    _this.fixFilterSectionPositions(headerRow);
                    Array.prototype.slice
                        .call(document.getElementsByClassName('K2BT_GridColumnFilterSection'))
                        .filter(function (section) { return section != filterSection; })
                        .forEach(function (section) {
                        section.style.display = 'none';
                    });
                    Array.prototype.slice.call(headerRow.getElementsByTagName('th')).forEach(function (h) { return h.classList.remove('K2BT_ColumnWithFilterOpen'); });
                    if (window.getComputedStyle(filterSection).display == 'none') {
                        filterSection.style.display = 'block';
                        th.classList.add('K2BT_ColumnWithFilterOpen');
                    }
                    else {
                        filterSection.style.display = 'none';
                    }
                    ev.stopPropagation();
                });
            }
            if (column.ContainsActiveFilter) {
                th.classList.add('K2BT_ColumnWithActiveFilter');
            }
            else {
                th.classList.remove('K2BT_ColumnWithActiveFilter');
            }
        });
        this.fixFilterSectionPositions(headerRow);
    };
    K2BGridExtensions.prototype.fixFilterSectionPositions = function (headerRow) {
        var _this = this;
        this.metadata.Columns.filter(function (col) { return col.FilterSectionInternalName; }).forEach(function (column) {
            var th = _this.getTableHeaderForColumn(column, headerRow);
            var section = document.getElementById(column.FilterSectionInternalName);
            if (!(section.parentElement instanceof HTMLBodyElement)) {
                document.body.appendChild(section);
                section.style.position = 'fixed';
            }
            section.style.visibility = 'hidden';
            var originalDisplay = section.style.display;
            section.style.display = 'block';
            var thBoundingRect = th.getBoundingClientRect();
            var sectionBoundingRect = section.getBoundingClientRect();
            var topValue = thBoundingRect.top + thBoundingRect.height;
            section.style.top = topValue + 'px';
            var width = sectionBoundingRect.width;
            var leftValue = thBoundingRect.left - width + thBoundingRect.width;
            if (leftValue > 0) {
                section.style.left = leftValue + 'px';
            }
            else {
                section.style.left = leftValue + width - thBoundingRect.width + 'px';
            }
            // scroll to selected date if necessary
            var selectedItem = section.getElementsByClassName('K2BT_DateRangeItemSelected');
            if (selectedItem.length > 0) {
                var offset = selectedItem[0].offsetTop - section.offsetTop;
                section.scrollTop = offset;
            }
            section.style.display = originalDisplay;
            section.style.visibility = 'visible';
        });
    };
    K2BGridExtensions.prototype.hideFilterSections = function (ev) {
        if (ev.target instanceof HTMLElement) {
            var target = ev.target;
            if (!target.classList.contains('K2BT_ColumnFilterButton') &&
                this.closest(target, function (e) { return e.classList.contains('K2BT_GridColumnFilterSection'); }) == null &&
                this.closest(target, function (e) { return e.classList.contains('calendar'); }) == null) {
                Array.prototype.slice.call(document.getElementsByClassName('K2BT_GridColumnFilterSection')).forEach(function (element) {
                    element.style.display = 'none';
                });
                Array.prototype.slice.call(document.getElementsByClassName('K2BT_ColumnWithFilterOpen')).forEach(function (element) {
                    element.classList.remove('K2BT_ColumnWithFilterOpen');
                });
            }
        }
    };
    K2BGridExtensions.prototype.hideActionMenus = function (ev, table) {
        if (ev.target instanceof HTMLElement) {
            var visibleMenuElements = this.overflowMenus.concat(this.actionGroups).filter(function (menu) { return window.getComputedStyle(menu.container).display != 'none'; });
            if (visibleMenuElements.length > 0) {
                var targetParents_1 = this.parents(ev.target);
                targetParents_1.push(ev.target);
                visibleMenuElements.forEach(function (visibleMenuElement) {
                    if (targetParents_1.indexOf(visibleMenuElement.container) == -1 && targetParents_1.indexOf(visibleMenuElement.toggle) == -1) {
                        visibleMenuElement.container.style.display = 'none';
                        visibleMenuElement.toggle.classList.remove('K2BT_OverflowActionsToggleOpen');
                    }
                });
            }
        }
    };
    K2BGridExtensions.prototype.closest = function (element, condition) {
        var el = element;
        while (el != null && !condition.call(this, el)) {
            el = el.parentElement;
        }
        return el;
    };
    K2BGridExtensions.prototype.addOrderByFeature = function (headerRow) {
        var _this = this;
        var uc = this;
        this.metadata.Columns.filter(function (v) { return v.AscendingOrder != -1 || v.DescendingOrder != -1; }).forEach(function (column) {
            var th = _this.getTableHeaderForColumn(column, headerRow);
            if (th != null) {
                if (column.AscendingOrder == _this.selectedGridOrder) {
                    th.classList.add('GridColumnAscending');
                }
                else {
                    th.classList.remove('GridColumnAscending');
                }
                if (column.DescendingOrder == _this.selectedGridOrder) {
                    th.classList.add('GridColumnDescending');
                }
                else {
                    th.classList.remove('GridColumnDescending');
                }
                // add listener only once
                if (th.dataset.k2btOrderByEventAdded != 'true') {
                    th.dataset.k2btOrderByEventAdded = 'true';
                    th.addEventListener('click', function (ev) {
                        ev.preventDefault();
                        if (column.AscendingOrder == -1) {
                            th.classList.add('GridColumnDescending');
                            uc.selectedGridOrder = column.DescendingOrder;
                        }
                        else if (column.DescendingOrder == -1) {
                            th.classList.add('GridColumnAscending');
                            uc.selectedGridOrder = column.AscendingOrder;
                        }
                        else if (th.classList.contains('GridColumnDescending')) {
                            th.classList.add('GridColumnAscending');
                            uc.selectedGridOrder = column.AscendingOrder;
                        }
                        else if (th.classList.contains('GridColumnAscending')) {
                            th.classList.add('GridColumnDescending');
                            uc.selectedGridOrder = column.DescendingOrder;
                        }
                        else {
                            if (column.AscendingOrder < column.DescendingOrder) {
                                th.classList.add('GridColumnAscending');
                                uc.selectedGridOrder = column.AscendingOrder;
                            }
                            else {
                                th.classList.add('GridColumnDescending');
                                uc.selectedGridOrder = column.DescendingOrder;
                            }
                        }
                        if (uc.OrderByChanged != null)
                            uc.OrderByChanged();
                    });
                }
            }
        });
    };
    K2BGridExtensions.prototype.SetSelectedColumnOrder = function (value) {
        var _this = this;
        var table = document.getElementById(this.GetGridTableId());
        var headerRow = this.getHeadersRow(table);
        var draggableColumns = this.getDraggableColumns(headerRow);
        if (draggableColumns.length > 0) {
            this.columnOrder = value
                .map(function (c) {
                var columnsMatchingName = _this.metadata.Columns.filter(function (v) { return v.Name == c; });
                return columnsMatchingName.length > 0 ? _this.metadata.Columns.indexOf(columnsMatchingName[0]) : -1;
            })
                .filter(function (v) { return v != -1; });
            if (this.initializationComplete) {
                this.validateCurrentColumnOrder(draggableColumns);
                this.refreshGridContents(table, headerRow);
            }
        }
    };
    K2BGridExtensions.prototype.GetSelectedColumnOrder = function () {
        var _this = this;
        return this.columnOrder.map(function (i) { return _this.metadata.Columns[i].Name; });
    };
    K2BGridExtensions.prototype.addGridColumnOrdering = function (table, headerRow) {
        var _this = this;
        var draggableColumns = this.getDraggableColumns(headerRow);
        // At least one column can be moved
        if (draggableColumns.length > 0) {
            this.validateCurrentColumnOrder(draggableColumns);
            this.refreshGridContents(table, headerRow);
            var draggableHeaders_2 = draggableColumns.map(function (i) { return _this.getArray(headerRow.children).filter(function (v) { return v.dataset.colindex == i; })[0]; });
            for (var _i = 0, draggableHeaders_1 = draggableHeaders_2; _i < draggableHeaders_1.length; _i++) {
                var cell = draggableHeaders_1[_i];
                var th = cell;
                th.draggable = true;
                th.addEventListener('dragstart', function (e) {
                    var _a;
                    e.dataTransfer.effectAllowed = 'all';
                    var position = (_a = _this.getTableHeaderElementFromDragEvent(e)) === null || _a === void 0 ? void 0 : _a.dataset.colindex;
                    e.dataTransfer.setData('originalPosition', position);
                    draggableHeaders_2.filter(function (v) { return v.dataset.colindex != position; }).forEach(function (th) { return th.classList.add('K2BT_GridColumnHoverTarget'); });
                    _this.dragging = true;
                    table.classList.add('K2BT_DraggingColumn');
                });
                th.addEventListener('dragover', function (e) {
                    e.dataTransfer.dropEffect = 'move';
                    e.preventDefault();
                    var cell = _this.getTableHeaderElementFromDragEvent(e);
                    cell.classList.add('K2BT_GridColumnHovering');
                    if (e.preventDefault) {
                        e.preventDefault(); // Necessary. Allows us to drop.
                    }
                    return false;
                });
                th.addEventListener('dragenter', function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    var cell = _this.getTableHeaderElementFromDragEvent(e);
                    cell.classList.add('K2BT_GridColumnHovering');
                });
                th.addEventListener('dragleave', function (e) {
                    var cell = _this.getTableHeaderElementFromDragEvent(e);
                    cell.classList.remove('K2BT_GridColumnHovering');
                    return false;
                });
                var uc = this;
                th.addEventListener('dragend', function (e) {
                    draggableHeaders_2.forEach(function (c) {
                        c.classList.remove('K2BT_GridColumnHovering');
                        c.classList.remove('K2BT_GridColumnHoverTarget');
                    });
                    uc.fixFilterSectionPositions(headerRow);
                });
                ['drop', 'dragdrop'].forEach(function (ev) {
                    return th.addEventListener(ev, function (e) {
                        _this.dragging = false;
                        table.classList.remove('K2BT_DraggingColumn');
                        e.stopImmediatePropagation();
                        var dst = parseInt(_this.getTableHeaderElementFromDragEvent(e).dataset.colindex);
                        var orgn = e.dataTransfer ? parseInt(e.dataTransfer.getData('originalPosition')) : NaN;
                        if (!isNaN(orgn) && !isNaN(dst)) {
                            var from = _this.columnOrder.indexOf(orgn);
                            var to = _this.columnOrder.indexOf(dst);
                            if (from < to)
                                _this.columnOrder.splice(to - 1, 0, _this.columnOrder.splice(from, 1)[0]);
                            else
                                _this.columnOrder.splice(to, 0, _this.columnOrder.splice(from, 1)[0]);
                            if (_this.ColumnOrderChanged != null)
                                _this.ColumnOrderChanged();
                            _this.refreshGridContents(table, headerRow);
                        }
                        return false;
                    });
                });
            }
        }
    };
    K2BGridExtensions.prototype.getTableHeaderElementFromDragEvent = function (e) {
        return this.closest(e.target, function (element) { return element.tagName == 'TH'; });
    };
    K2BGridExtensions.prototype.getDraggableColumns = function (headerRow) {
        var _this = this;
        return this.flatMap(function (g) { return g.MemberColumnNames.map(function (cn) { return _this.getColindexByName(cn); }); }, this.metadata.ColumnGroups.filter(function (g) { return g.CanBeMoved; }));
    };
    K2BGridExtensions.prototype.getColindexByName = function (cn) {
        for (var i = 0; i < this.metadata.Columns.length; i++) {
            if (this.metadata.Columns[i].Name == cn)
                return i;
        }
        return -1;
    };
    K2BGridExtensions.prototype.validateCurrentColumnOrder = function (draggableColumns) {
        var result = [];
        var firstDraggable = Math.min.apply(Math, draggableColumns);
        var lastDraggable = Math.max.apply(Math, draggableColumns);
        // Add fixed at beggining
        for (var i = 0; i < firstDraggable; i++)
            result.push(i);
        // Add currently in prop that are draggable
        if (this.columnOrder != null) {
            for (var _i = 0, _a = this.columnOrder; _i < _a.length; _i++) {
                var col = _a[_i];
                if (draggableColumns.indexOf(col) != -1)
                    result.push(col);
            }
        }
        // Add missing draggable columns
        for (i = 0; i < this.metadata.Columns.length; i++) {
            if (result.indexOf(i) == -1 && i >= firstDraggable && i <= lastDraggable) {
                result.push(i);
            }
        }
        // Add fixed at end
        for (i = lastDraggable + 1; i < this.metadata.Columns.length; i++)
            result.push(i);
        this.columnOrder = result;
    };
    K2BGridExtensions.prototype.refreshGridContents = function (table, headerRow) {
        if (this.isVisibleTable(table)) {
            this.reorderColumnsIfNecessary(table, headerRow);
            this.addGridActionGroups(table, headerRow);
            this.addGridOverflowMenu(table, headerRow);
            this.addGridTotalsFeature(table, headerRow);
        }
    };
    K2BGridExtensions.prototype.reorderColumnsIfNecessary = function (table, headerRow) {
        if (this.metadata.ColumnGroups.filter(function (g) { return g.CanBeMoved; }).length > 0) {
            var rows = table.getElementsByTagName('TR');
            for (var i = 0; i < rows.length; i++) {
                var tr = rows[i];
                if (tr.classList.contains(this.AGGREGATION_ROW_CLASS)) {
                    tr.remove();
                }
                else {
                    var cols = this.getArray(tr.children);
                    cols.forEach(function (c) { return c.remove(); });
                    this.columnOrder
                        .map(function (i) { return cols.filter(function (c) { return c.dataset.colindex == i.toString(); })[0]; })
                        .forEach(function (c) {
                        tr.appendChild(c);
                    });
                }
            }
            this.setHeaderCellWidths(table, headerRow);
        }
    };
    K2BGridExtensions.prototype.setHeaderCellWidths = function (table, headerRow) {
        var contentRows = table.getElementsByTagName('TBODY')[0].getElementsByTagName('TR');
        if (contentRows.length > 0) {
            var firstRow = contentRows[0];
            for (var j = 0; j < firstRow.children.length; j++) {
                var cell = firstRow.children[j];
                var header = this.getArray(headerRow.children).filter(function (th) { return th.dataset.colindex == cell.dataset.colindex; })[0];
                header.style.width = cell.offsetWidth + 'px';
            }
        }
    };
    // Helpers
    K2BGridExtensions.prototype.GetGridTableId = function () {
        // @ts-ignore
        var cmpContext = this.ParentObject.CmpContext;
        if (cmpContext === '')
            return this.GridControlName[0].toUpperCase() + this.GridControlName.substring(1).toLowerCase() + 'ContainerTbl';
        else {
            var localGridName = this.GridControlName.substring(cmpContext.length);
            return cmpContext + localGridName[0].toUpperCase() + localGridName.substring(1).toLowerCase() + 'ContainerTbl';
        }
    };
    K2BGridExtensions.prototype.getTableHeaderForColumn = function (column, headerRow) {
        var columnIndex = this.metadata.Columns.indexOf(column);
        return Array.prototype.slice.call(headerRow.childNodes).filter(function (e) { return e.dataset.colindex == columnIndex.toString(); })[0];
    };
    K2BGridExtensions.prototype.getHeadersRow = function (table) {
        var tr = null;
        var thead = table.getElementsByTagName('thead');
        if (thead != null && thead.length == 1) {
            var trList = thead[0].getElementsByTagName('tr');
            if (trList != null && trList.length == 1)
                tr = trList[0];
        }
        return tr;
    };
    return K2BGridExtensions;
}());
