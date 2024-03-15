function K2BHorizontalMenu($) {
  this.SelectedItem = '';

  // Databinding for property MenuItems
  this.SetMenuItems = function (data) {
    if (this.MenuItems === undefined || JSON.stringify(this.MenuItems) !== JSON.stringify(data)) {
      this.MenuItems = data;
      this.updateMenuContents();
    }
  };

  // Databinding for property MenuItems
  this.GetMenuItems = function () {
    return this.MenuItems;
  };

  this.SetSelectedItem = function () {};

  // Databinding for property SelectedItem
  this.GetSelectedItem = function () {
    return this.SelectedItem;
  };

  this.show = function () {
    try {
      if (!this.IsPostBack) {
        this.createMenuContainerStructure();

        this.addDocumentLevelClickHandler();
      }
    } catch (e) {
      console.log(e);
    }
  };

  this.updateMenuContents = function () {
    var ulNode = $('#' + this.ContainerName + ' ul.navbar-nav.K2BToolsHorizontalMenu');
    $(ulNode).empty();

    this.loadMenuData(this.MenuItems, 0, ulNode);

    var urlComps = window.location.pathname.split('/');
    var scriptName = urlComps[urlComps.length - 1];
    var currentWPinMenu = false;
    $('UL.K2BHorizontalMenu a').each(function (i, item) {
      if ($(item).attr('href') === scriptName) {
        currentWPinMenu = true;
      }
    });

    if (currentWPinMenu) {
      $('UL.K2BHorizontalMenu li').removeClass('active');
      $('UL.K2BHorizontalMenu a').each(function (i, item) {
        if ($(item).attr('href') === scriptName) {
          $(item).closest('li').addClass('active');
        }
      });
    }

    var _menu = this;
    $.each($('UL.K2BMetisMenu a'), function (i, element) {
      if ($(element).attr('href') !== '' && $(element).attr('href') !== undefined) $(element).on('click', _menu.bind(this));
    });

    if (this.IncludeSearch) {
      var inputLi = $('<li>');
      inputLi.addClass('searchItem');
      ulNode.append(inputLi);

      var searchField = $('<input>').addClass('searchField');
      searchField.attr('title', this.SearchInviteMessage);
      inputLi.append(searchField);

      var timer;
      $(searchField).bind('input', function () {
        window.clearTimeout(timer);
        timer = window.setTimeout(function () {
          _menu.updateSearchResults($(searchField).val());
        }, 600);
      });

      var searchResults = $('<div>').addClass('searchResults').hide();
      inputLi.append(searchResults);
    }
  };

  this.createMenuContainerStructure = function () {
    var container = $('#' + this.ContainerName);
    var navBarNode = $('<div>');
    navBarNode.attr('role', 'navigation');
    container.append(navBarNode);

    var mainNavigationBar = $('<div>').addClass('collapse navbar-collapse');
    navBarNode.append(mainNavigationBar);

    var mainUL = $('<ul>').addClass('nav navbar-nav K2BToolsHorizontalMenu');
    if (this.ExpandDirection === 'Down') mainUL.addClass('K2BT_ExpandDirectionDown');
    else mainUL.addClass('K2BT_ExpandDirectionOnTheSide');
    mainNavigationBar.append(mainUL);

    this.updateMenuContents();
  };

  this.loadMenuData = function (MenuData, step, currentNode) {
    var i = 0;
    for (i = 0; MenuData[i] != undefined; i++) {
      const menuItem = MenuData[i];
      const hasFontAwesome = menuItem.ImageClass !== undefined && menuItem.ImageClass != null && menuItem.ImageClass.trim() !== '';
      const hasImage = menuItem.ImageUrl !== undefined && menuItem.ImageUrl != null && menuItem.ImageUrl.trim() !== '';

      var liElement = this.createLiElementForMenuItem(menuItem, currentNode);

      if (menuItem.Items !== undefined && menuItem.Items.toString() !== '') {
        if (!$(currentNode).hasClass('navbar-nav')) liElement.addClass('dropdown-submenu');

        var linkElement = $('<a></a>');
        linkElement.attr('href', '#');

        if (this.ExpandDirection !== 'Down') {
          linkElement.addClass('dropdown-toggle');
          linkElement.attr('data-toggle', 'dropdown');
        }
        liElement.append(linkElement);

        if (hasFontAwesome) {
          var spanElement = $('<span>').addClass('sidebar-nav-item-icon').addClass(menuItem.ImageClass);
          linkElement.append(spanElement);
        }

        if (hasImage) {
          var image = $('<img>').attr('src', menuItem.ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(menuItem.ImageClass);
          linkElement.append(image);
        }

        if (hasImage || hasFontAwesome) {
          linkElement.append($('<span>').addClass('sidebar-nav-item').text(menuItem.Title));
        } else {
          linkElement.text(menuItem.Title);
        }

        var newUl = $('<ul>').addClass('dropdown-menu multi-level');
        liElement.append(newUl);
        this.loadMenuData(menuItem.Items, step + 1, newUl);

        if (this.ExpandDirection === 'Down') {
          $(linkElement).on('click', function (event) {
            $(event.target).closest('li').toggleClass('K2BT_ExpandDirectionDownLevelOpen');
          });
        }
      } else {
        const linkObject = $('<a>');
        if (menuItem.Link !== '' && menuItem.Link != null) {
          linkObject.attr('href', menuItem.Link);
          if (menuItem.LinkTarget !== '' && menuItem.LinkTarget != null) $(linkObject).attr('target', menuItem.LinkTarget);
          linkObject.on('click', { code: menuItem.Code }, this.processItemClick);
        } else {
          linkObject.on('click', { code: menuItem.Code }, this.processItemClick);
        }
        liElement.append(linkObject);

        if (hasFontAwesome) {
          var spamFontAwesome = $('<span>').addClass('sidebar-nav-item-icon').addClass(menuItem.ImageClass);
          linkObject.append(spamFontAwesome);
        }

        if (hasImage) {
          const imageObject = $('<img>').attr('src', menuItem.ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(menuItem.ImageClass);
          linkObject.append(imageObject);
        }

        var span = $('<span>');
        span.addClass('sidebar-nav-item');
        span.text(menuItem.Title);
        linkObject.append(span);
      }
    }
    return;
  };

  this.updateSearchResults = function (criteria) {
    var searchResults = $('.K2BToolsHorizontalMenu div.searchResults');
    searchResults.empty();
    if (criteria === undefined || criteria === '') {
      searchResults.hide();
    } else {
      searchResults.show();
    }

    this.getSearchResults_Recursive(this.MenuItems, normalizeSearchString(criteria), [], searchResults);
  };

  this.processItemClick = function (e) {
    this.SelectedItem = e.data.code;
    if (this.ExpandDirection === 'Down') {
      $('.K2BT_ExpandDirectionDownLevelOpen').removeClass('K2BT_ExpandDirectionDownLevelOpen');
    }
    if (this.OptionClicked && typeof this.OptionClicked === 'function') this.OptionClicked();
  }.bind(this);

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

  this.addDocumentLevelClickHandler = function () {
    if (this.ExpandDirection === 'Down') {
      $(document).on('click', function (event) {
        $('.K2BToolsHorizontalMenu > li > ul:visible').each(function (_i, item) {
          var li = $(item).closest('li');
          if ($(event.target).closest(li).length < 1) {
            $(li).removeClass('K2BT_ExpandDirectionDownLevelOpen');
          }
        });
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
        normalizedTitle = normalizeSearchString(item.Title);
        if (normalizedTitle.includes(criteria)) {
          var link = $('<a>').attr('href', item.Link);

          var searchResult = $('<div>').addClass('searchResult');

          var index = normalizedTitle.indexOf(criteria.toLowerCase());
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
}
