function K2BAccordionMenu($) {
  this.elementsWithCollapsedMenuClass = [];

  this.SetMenuItems = function (data) {
    if (this.MenuItems === undefined || JSON.stringify(this.MenuItems) !== JSON.stringify(data)) {
      $('#' + this.ControlName).metisMenu('dispose');
      this.MenuItems = data;
      this.updateMenuContents();
    }
  };

  this.GetMenuItems = function () {
    return this.MenuItems;
  };

  this.SetSelectedItem = function () {};

  // Databinding for property SelectedItem
  this.GetSelectedItem = function () {
    return this.SelectedItem;
  };

  this.documentReadyCallback = function () {
    $('#' + this.ControlName).metisMenu({ toggle: this.Toggle, doubleTapGo: this.DoubleTapGo });
  };

  this.show = function () {
    var uc = this;

    try {
      if (!this.IsPostBack) {
        this.createMenuContainerStructure();
        this.elementsWithCollapsedMenuClass = Array.prototype.slice.call(document.getElementsByClassName('K2BT_CollapsedMenu'));
      }

      $(document).ready(this.documentReadyCallback);

      $(document).on('click', function (e) {
        if (!$(e.target).hasClass('K2BToolsButton_BtnToggle') && $(e.target).closest('.Calendar').length === 0) {
          uc.fixMenuVisibilityInContainer(e);

          uc.fixMenuVisibilityInMasterPage(uc, e);
        }
      });

      this.documentReadyCallback();
    } catch (e) {
      console.log(e);
    }
  };

  this.updateMenuContents = function () {
    var ulNode = $('#' + this.ContainerName + ' ul.K2BMetisMenu');
    $(ulNode).empty();
    this.loadMenuData(this.MenuItems, 0, ulNode);

    var urlComps = window.location.pathname.split('/');
    var scriptName = urlComps[urlComps.length - 1];
    var currentWPinMenu = false;
    $('UL.K2BMetisMenu a').each(function (_i, item) {
      if ($(item).attr('href') === scriptName) {
        currentWPinMenu = true;
      }
    });

    if (currentWPinMenu) {
      $('UL.K2BMetisMenu li').removeClass('activeelement');
      $('UL.K2BMetisMenu a').each(function (_i, item) {
        if ($(item).attr('href') === scriptName) {
          $(item).closest('li').addClass('activeelement');
          $(item).parents('li').addClass('mm-active');
        }
      });
    }

    var uc = this;
    $('UL.K2BMetisMenu a').each(function (_i, e) {
      $(e).on('click', uc.onMenuClick.bind(uc));
    });
  };

  this.updateSearchResults = function (criteria) {
    var menu = $('#' + this.ContainerName + ' aside.sidebar > nav.sidebar-nav > ul.K2BMetisMenu');
    var searchResults = $('#' + this.ContainerName + ' aside.sidebar > nav.sidebar-nav > div.searchResults');
    searchResults.empty();
    if (criteria === undefined || criteria === '') {
      menu.show();
      searchResults.hide();
    } else {
      menu.hide();
      searchResults.show();
    }

    this.getSearchResults_Recursive(this.MenuItems, normalizeSearchString(criteria), [], searchResults);
  };

  this.fixMenuVisibilityInContainer = function (e) {
    $('.K2BToolsMenuContainerVisibleCompact').each(function (_index, element) {
      if ($(e.target).closest(element).length < 1) {
        $(element).removeClass('K2BToolsMenuContainerVisibleCompact');
        $(element).addClass('K2BToolsMenuContainerInvisibleCompact');
      }
    });
  };

  this.fixMenuVisibilityInMasterPage = function (uc, e) {
    if (uc.elementsWithCollapsedMenuClass.length > 0) {
      $('.K2BT_FloatingMenu').each(function (_index, element) {
        if ($(e.target).closest(element).length < 1) {
          for (var el of uc.elementsWithCollapsedMenuClass) {
            el.classList.add('K2BT_CollapsedMenu');
          }
        }
      });
    }
  };

  //https://stackoverflow.com/questions/990904/remove-accents-diacritics-in-a-string-in-javascript/37511463#37511463
  function normalizeSearchString(searchString) {
    return searchString
      .toLowerCase()
      .normalize('NFD')
      .replace(/[\u0300-\u036f]/g, '');
  }

  this.getSearchResults_Recursive = function (menuLevel, criteria, path, searchResults) {
    for (var i = 0; i < menuLevel.length; i++) {
      var item = menuLevel[i];
      if (item.Items === undefined || item.Items.length === 0) {
        const normalizedString = normalizeSearchString(item.Title);
        if (normalizedString.includes(criteria)) {
          var link = $('<a>').attr('href', item.Link);

          var searchResult = $('<div>').addClass('searchResult');

          var index = normalizedString.indexOf(criteria);
          var title = $('<span>').addClass('searchResultTitle');
          title.append(document.createTextNode(item.Title.substring(0, index)));
          var highlight = $('<span>')
            .addClass('searchResultHighlight')
            .text(item.Title.substring(index, index + criteria.length));
          title.append(highlight);
          title.append(document.createTextNode(item.Title.substring(index + criteria.length)));

          searchResult.append(title);
          var pathStr = Array.prototype.join.call(path, ' » ');
          var pathSpan = $('<span>').addClass('searchResultPath').text(pathStr);
          pathSpan.attr('title', pathStr);
          searchResult.append(pathSpan);

          link.append(searchResult);
          searchResults.append(link);
        }
      } else {
        var newpath = path.slice();
        Array.prototype.push.call(newpath, item.Title);
        this.getSearchResults_Recursive(item.Items, criteria, newpath, searchResults);
      }
    }
  };

  this.createMenuContainerStructure = function () {
    var container = $('#' + this.ContainerName);
    var rootNode = $('<aside>').addClass('sidebar');
    container.append(rootNode);

    var navNode = $('<nav>').addClass('sidebar-nav');
    rootNode.append(navNode);

    if (this.IncludeSearch) {
      var searchField = $('<input>').addClass('searchField');
      searchField.attr('title', this.SearchInviteMessage);
      searchField.attr('placeholder', this.SearchInviteMessage);
      navNode.append(searchField);

      var timer;
      var uc = this;
      $(searchField).bind('input', function () {
        window.clearTimeout(timer);
        timer = window.setTimeout(function () {
          uc.updateSearchResults($(searchField).val());
        }, 600);
      });

      $('nav.sidebar-nav').keydown(this.processKeyDown);
      $('nav.sidebar-nav').on('click', '.searchResults > a', function () {
        var parent = $(this).closest('.K2BToolsMenuContainerVisibleCompact');
        parent.removeClass('K2BToolsMenuContainerVisibleCompact');
        parent.addClass('K2BToolsMenuContainerInvisibleCompact');

        var link = $(this).attr('href');

        $('.searchField').val('');
        uc.updateSearchResults('');
        window.location.href = link;
      });
    }

    var ulNode = $('<ul>').attr('id', this.ControlName).addClass('K2BMetisMenu');
    navNode.append(ulNode);

    var searchResults = $('<div>').addClass('searchResults').hide();
    navNode.append(searchResults);
    this.updateMenuContents();
  };

  this.onMenuClick = function (event) {
    const target = $(event.target).closest('a');
    if ($(target).attr('href') !== '' && $(target).attr('href') !== undefined) {
      // menu item
      $('UL.K2BMetisMenu li').removeClass('activeelement');
      $(target).closest('li').addClass('activeelement');

      var parent = $(target).closest('.K2BToolsMenuContainerVisibleCompact');
      parent.removeClass('K2BToolsMenuContainerVisibleCompact');
      parent.addClass('K2BToolsMenuContainerInvisibleCompact');

      for (var el of this.elementsWithCollapsedMenuClass) {
        el.classList.add('K2BT_CollapsedMenu');
      }
    } else {
      if (this.Toggle) {
        // sublevel
        $('UL.K2BMetisMenu li').removeClass('activeelement');
      }
    }

    this.SelectedItem = $(target).attr('data-k2btcode');
    if (this.OptionClicked && typeof this.OptionClicked === 'function') this.OptionClicked();
  };

  this.loadMenuData = function (MenuData, step, currentNode) {
    var i = 0;
    for (i = 0; MenuData[i] !== undefined; i++) {
      const menuItem = MenuData[i];

      var hasFontAwesome = menuItem.ImageClass !== undefined && menuItem.ImageClass !== null && menuItem.ImageClass.trim() !== '';
      var hasImage = menuItem.ImageUrl !== undefined && menuItem.ImageUrl !== null && menuItem.ImageUrl.trim() !== '';
      var liElement = this.createLiElementForMenuItem(menuItem, currentNode);

      var linkElement = $('<a></a>');
      $(linkElement).attr('data-k2btcode', menuItem.Code);
      liElement.append(linkElement);

      var itemContent = $('<div></div>');
      itemContent.addClass('sidebar-nav-item-content');
      linkElement.append(itemContent);

      if (hasFontAwesome) {
        var spamFontAwesome = $('<span>').addClass('sidebar-nav-item-icon').addClass(menuItem.ImageClass);
        itemContent.append(spamFontAwesome);
      }

      if (hasImage) {
        const imageObject = $('<img>').attr('src', menuItem.ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(menuItem.ImageClass);
        itemContent.append(imageObject);
      }

      itemContent.append($('<span>').addClass('sidebar-nav-item').text(menuItem.Title));

      if (menuItem.Items !== undefined && menuItem.Items !== null && menuItem.Items.length !== 0) {
        linkElement.append($('<span>').addClass('sidebar-nav-expand-symbol').addClass('fa').addClass('arrow'));

        var newUl = $('<ul>');
        liElement.append(newUl);
        this.loadMenuData(menuItem.Items, step + 1, newUl);
      } else {
        $(linkElement).attr('href', menuItem.Link);
        if (menuItem.LinkTarget !== '' && menuItem.LinkTarget != null) $(linkElement).attr('target', menuItem.LinkTarget);
      }
    }
    return;
  };

  this.processKeyDown = function (event) {
    var currentFocus = $(document.activeElement);
    if (event.keyCode === 'ArrowDown') {
      this.processArrowDownKey(currentFocus, event);
    } else if (event.keyCode === 'ArrowUp') {
      this.processArrowUpKey(currentFocus, event);
    } else if (event.keyCode === 'Enter') {
      this.processEnterKey(currentFocus);
    }
  };

  this.processArrowDownKey = function (currentFocus, event) {
    if (currentFocus[0].nodeName.toLowerCase() === 'a') {
      if (currentFocus.next().length > 0) currentFocus.next().focus();
      else $('.searchField').focus();
    } else if (currentFocus.hasClass('searchField')) {
      $('.searchResults a:first-child').focus();
    }

    event.preventDefault();
  };

  this.processArrowUpKey = function (currentFocus, event) {
    if (currentFocus[0].nodeName.toLowerCase() === 'a') {
      if (currentFocus.prev().length > 0) currentFocus.prev().focus();
      else $('.searchField').focus();
    } else if (currentFocus.hasClass('searchField')) {
      $('.searchResults a:last-child').focus();
    }

    event.preventDefault();
  };

  this.processEnterKey = function (currentFocus) {
    if (currentFocus[0].nodeName.toLowerCase() === 'a') {
      $(currentFocus[0]).trigger('click');
    }
  };

  this.createLiElementForMenuItem = function (menuItem, currentNode) {
    var liElement = $('<li>');
    if (!menuItem.ShowInExtraSmall) {
      liElement.addClass('InvisibleInExtraSmallMenu');
    }

    if (!menuItem.ShowInSmall) {
      liElement.addClass('InvisibleInSmallMenu');
    }

    if (!menuItem.ShowInMedium) {
      liElement.addClass('InvisibleInMediumMenu');
    }

    if (!menuItem.ShowInLarge) {
      liElement.addClass('InvisibleInLargeMenu');
    }

    currentNode.append(liElement);
    return liElement;
  };
}
