var k2btools = k2btools || {
  // Default value, if many instances are present then this properties will be set to false if any of the instances says so.
  $: $,
  updateCheckboxes: true,
  showMessagesAssociatedWithAttributes: true,

  checkboxSelector: 'input[type="checkbox"]:not(.bootstrap-switch *)',

  messagesShown: [], // Used to avoid duplicating messages

  ParentsCheck: function (element, hops) {
    i = 0;
    while (i < hops && element != document.documentElement && element.parentElement != null) {
      element = element.parentElement;
      i++;
    }
    return element.parentElement != null || element == document.documentElement;
  },

  checkboxRefresh: function () {
    if (this.updateCheckboxes) {
      k2btools.$(this.checkboxSelector).each(function (i, el) {
        var label = k2btools.$(el).next('label');
        if (k2btools.$(el).next('label').length == 0) {
          label = k2btools.$("<label data-gx-sr-only='' />");
          label.attr('for', k2btools.$(el).attr('id'));
          k2btools.$(el).after(label);

          k2btools.$(el).parent('label').addClass('K2BT_CheckboxContainer');
        }
        label.attr('title', k2btools.$(el).attr('title'));
      });
    }
  },

  RefreshTooltips: function () {
    k2btools.$(".tooltip[role='tooltip']").remove();
    k2btools.$('.Image_Action, .K2BImage_ContextHelp, .K2BContextHelp, .K2BT_EntityManagerSocialAction, .K2BT_ElementWithTooltip').each(function (i, element) {
      var $element = k2btools.$(element);
      $element.tooltip({ delay: { show: 500, hide: 500 }, container: $element.parent(), trigger: 'hover' });
    });

    k2btools.$('.Image_Action, .K2BImage_ContextHelp, .K2BContextHelp, .K2BT_ElementWithTooltip').on('click', function () {
      k2btools.$(this).tooltip('hide');
    });

    k2btools.$(".Image_Action[title!=''], .K2BImage_ContextHelp[title!=''], .K2BContextHelp[title!=''], .K2BT_ElementWithTooltip[title!='']").each(function (i, element) {
      var $element = k2btools.$(element);
      $element.tooltip('hide').attr('data-original-title', $element.attr('title')).tooltip('fixTitle');
      $element.attr('title', '');
    });

    var element = k2btools.$(".K2BT_EntityManagerSocialAction[title!=''][title!=data-original-title]");
    k2btools.$(element).attr('data-original-title', element.attr('title')).tooltip('fixTitle').tooltip('show');
  },

  RefreshGridLastColumnTag: function () {
    k2btools.$('.gx-grid .Grid_WorkWith').each(function (i, grid) {
      k2btools.$(grid).find('th, td').removeClass('K2BToolsLastVisibleColumn').removeClass('K2BToolsFirstVisibleColumn');
      var lastColumnHeader = k2btools
        .$(grid)
        .find('tr th')
        .filter(function (index, el) {
          return k2btools.$(el).css('display') != 'none';
        })
        .last();
      lastColumnHeader.addClass('K2BToolsLastVisibleColumn');

      var firstColumnHeader = k2btools
        .$(grid)
        .find('tr th')
        .filter(function (index, el) {
          return k2btools.$(el).css('display') != 'none';
        })
        .first();
      firstColumnHeader.addClass('K2BToolsFirstVisibleColumn');

      var colIndex = lastColumnHeader.attr('data-colindex');
      k2btools
        .$(grid)
        .find("td[data-colindex='" + colIndex + "']")
        .addClass('K2BToolsLastVisibleColumn');
    });
  },

  RefreshEditableFormsFields: function () {
    k2btools.$('.K2BT_EditableForm .K2BToolsTable_TopAttributeContainer').each(function (i, item) {
      var readonly = true;

      if (
        k2btools.$(item).find('.gx_usercontrol').length > 0 &&
        k2btools.$(item).find('.gx_usercontrol').children().length > 0 &&
        k2btools.$(item).find('.gx_usercontrol').children()[0].tagName.indexOf('K2BT') == 0
      ) {
        readonly = !k2btools.$(item).find('.gx_usercontrol').children()[0].enabled;
      } else if (
        k2btools
          .$(item)
          .find(
            'textarea:not(.gx-disabled),' +
              "input:not(.gx-disabled):not([readonly]):not([disabled]):not([style*='display:none'])," +
              "select:not(.gx-disabled):not([style*='display:none'])," +
              '.gx-radio-label:not(.disabled),' +
              '.bootstrap-switch:not(.bootstrap-switch-readonly)',
          ).length > 0
      ) {
        readonly = false;
      }

      if (readonly) {
        k2btools.$(item).addClass('K2BT_ReadonlyAttributeContainer');
      } else {
        k2btools.$(item).removeClass('K2BT_ReadonlyAttributeContainer');
      }
    });
  },

  afterEventObserver: function () {
    this.checkboxRefresh();
    this.RefreshTooltips();
    this.RefreshGridLastColumnTag();
    this.RefreshEditableFormsFields();
  },

  resolveValue: function (provided, defaultValue) {
    return provided === undefined || provided === '' || provided == null ? defaultValue : provided;
  },

  getTranslatedMessage: function (msg) {
    if (msg.indexOf('GX') === 0 || msg.indexOf('K2B') === 0) {
      var translated = gx.msg[msg];
      if (translated !== undefined) {
        return translated;
      }
    }
    return msg;
  },

  updateFormControlVisibility: function (container, visible) {
    if (container.parentElement.parentElement.classList.contains('gx-form-group')) {
      if (!visible) {
        container.parentElement.parentElement.style.display = 'none';
      } else {
        container.parentElement.parentElement.style.display = null;
      }
    }
  },

  getDayOfWeekShortString: function (day) {
    return this.getDayOfWeekShortStringFromDayNumber(day.getDay());
  },

  getDayOfWeekShortStringFromDayNumber: function (number) {
    switch (number) {
      case 0:
        return this.getTranslatedMessage('K2BT_Sunday_Short');
      case 1:
        return this.getTranslatedMessage('K2BT_Monday_Short');
      case 2:
        return this.getTranslatedMessage('K2BT_Tuesday_Short');
      case 3:
        return this.getTranslatedMessage('K2BT_Wednesday_Short');
      case 4:
        return this.getTranslatedMessage('K2BT_Thursday_Short');
      case 5:
        return this.getTranslatedMessage('K2BT_Friday_Short');
      case 6:
        return this.getTranslatedMessage('K2BT_Saturday_Short');
    }
  },

  getMonthName: function (monthNumber) {
    switch (monthNumber) {
      case 0:
        return this.getTranslatedMessage('K2BT_January');
      case 1:
        return this.getTranslatedMessage('K2BT_February');
      case 2:
        return this.getTranslatedMessage('K2BT_March');
      case 3:
        return this.getTranslatedMessage('K2BT_April');
      case 4:
        return this.getTranslatedMessage('K2BT_May');
      case 5:
        return this.getTranslatedMessage('K2BT_June');
      case 6:
        return this.getTranslatedMessage('K2BT_July');
      case 7:
        return this.getTranslatedMessage('K2BT_August');
      case 8:
        return this.getTranslatedMessage('K2BT_September');
      case 9:
        return this.getTranslatedMessage('K2BT_October');
      case 10:
        return this.getTranslatedMessage('K2BT_November');
      case 11:
        return this.getTranslatedMessage('K2BT_December');
    }
  },
};

(function (doc) {
  var scriptElm = doc.scripts[doc.scripts.length - 1];

  var parts = scriptElm.src.split('/');
  parts.pop();
  parts.push('K2BToolsComponents');
  parts.push('dist');
  parts.push('k2btools-components');
  var url = parts.join('/');

  var esmBuild = doc.createElement('script');

  esmBuild.src = url + '/k2btools-components.esm.js';
  esmBuild.setAttribute('data-stencil-namespace', 'k2btools-components');

  var nonEsmBuild = doc.createElement('script');
  nonEsmBuild.src = url + '/k2btools-components.js';
  nonEsmBuild.setAttribute('data-stencil-namespace', 'k2btools-components');

  esmBuild.setAttribute('type', 'module');
  nonEsmBuild.setAttribute('nomodule', '');

  doc.head.appendChild(esmBuild);
  doc.head.appendChild(nonEsmBuild);
})(document);
