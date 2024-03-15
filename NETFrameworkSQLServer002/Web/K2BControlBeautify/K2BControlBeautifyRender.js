// Fix to show image chooser in a non-modal window. SAC #42886
gx.html.multimediaUpload.isModal = false;

function K2BControlBeautify(jQuery) {
  k2btools.$ = jQuery;

  this.show = function () {
    try {
      if (!this.UpdateCheckboxes) k2btools.updateCheckboxes = false;

      if (k2btools.updateCheckboxes) this.RefreshCheckboxes();

      this.RefreshTooltips();
      this.RefreshMenu();
      this.RefreshMessageHandling();
      this.RefreshMenuHide();
      this.RefreshTagsCollectionFocus();
      this.RefreshOnImagePrompt();
      k2btools.RefreshGridLastColumnTag();
      k2btools.RefreshEditableFormsFields();

      gx.fx.obs.addObserver('gx.onafterevent', k2btools, k2btools.afterEventObserver, { single: false, unique: true });
      gx.fx.obs.addObserver('grid.onafterrender', k2btools, k2btools.afterEventObserver, { single: false, unique: true });
    } catch (e) {
      console.log(e);
    }
  };

  this.destroy = function () {
    this.CleanupMenuHide();
    this.CleanupMenu();
  };

  this.CleanupMenuHide = function () {
    k2btools.$('html').off('click', this.htmlClickCallback);
  };

  this.CleanupMenu = function () {
    k2btools.$('#K2BToolsMenu a').off('click', this.onMenuClick);
  };

  // Used to hide menus - timeout added to improve performance
  this.clicktimeout = null;
  this.htmlClickCallback = function (e) {
    clearTimeout(this.clicktimeout);
    this.clicktimeout = setTimeout(function () {
      if (
        document.body.contains(e.target) &&
        k2btools.$(e.target).closest('.Calendar, .daterangepicker, .gx-mask, .Table_ConditionalConfirm').length == 0 &&
        !k2btools.$(e.target).is('body')
      ) {
        k2btools.$('.K2BToolsTable_GridSettings:visible, .K2BToolsMyAccountTable:visible,  .ControlBeautify_CollapsableTable:visible').each(function (index, element) {
          var containerTable = k2btools.$(element).closest('.K2BToolsTable_GridSettingsContainer, .K2BToolsTable_MyAccountContainer, .ControlBeautify_ParentCollapsableTable');

          if (k2btools.ParentsCheck(e.target, 10) && k2btools.$(e.target).closest(containerTable).length < 1) {
            k2btools.$(element).hide();
          }
        });

        if (k2btools.$('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').length != 0) {
          if (k2btools.$(e.target).closest('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').length == 0) {
            k2btools.$('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').removeClass('K2BT_CommentsFloatingSectionOpen');
          }
        }

        if (k2btools.$('.K2BT_VerticalFloatingFiltersSection.K2BT_VerticalFiltersSectionOpen').length != 0) {
          if (k2btools.$(e.target).closest('.K2BT_VerticalFloatingFiltersSection.K2BT_VerticalFiltersSectionOpen, .K2BT_VerticalFiltersToggle').length == 0) {
            k2btools.$('.K2BT_VerticalFloatingFiltersSection.K2BT_VerticalFiltersSectionOpen').removeClass('K2BT_VerticalFiltersSectionOpen');
            k2btools.$('.K2BT_VerticalFloatingFiltersToggle.K2BT_VerticalFiltersToggleOpen').removeClass('K2BT_VerticalFiltersToggleOpen');
          }
        }
      }
    }, 200);
  };

  this.RefreshMenuHide = function () {
    k2btools.$('html').on('click', this.htmlClickCallback);
  };

  this.RefreshCheckboxes = function () {
    k2btools.checkboxRefresh();
  };

  this.insideActions = function (item) {
    return (
      k2btools
        .$(item)
        .parents(
          '#K2BTABLEACTIONSLEFTCONTAINER, #K2BTABLEACTIONSRIGHTCONTAINER, #K2BTABLEGRIDACTIONSLEFTCONTAINER, #K2BTABLEGRIDACTIONSRIGHTCONTAINER, #K2BTABLEACTIONSTOPCONTAINER, #K2BTABLEACTIONSBOTTOMCONTAINER, .Table_ComboActionsContainer, .Table_ActionsContainer, .K2BToolsTableCell_ActionContainer',
        ).length > 0
    );
  };

  this.RefreshTooltips = function () {
    k2btools.RefreshTooltips();
  };

  this.RefreshMenu = function () {
    var urlComps = window.location.pathname.split('/');
    var scriptName = urlComps[urlComps.length - 1];

    if (!this.IsPostBack) {
      var currentWPinMenu = false;
      k2btools.$('#K2BToolsMenu a').each(function (i, item) {
        if (k2btools.$(item).attr('href') == scriptName) {
          currentWPinMenu = true;
        }
      });

      if (currentWPinMenu) {
        k2btools.$('#K2BToolsMenu a').removeClass('activeOption');
        k2btools.$('#K2BToolsMenu a').each(function (i, item) {
          if (k2btools.$(item).attr('href') == scriptName) {
            k2btools.$(item).addClass('activeOption');
          }
        });
      }
    }

    k2btools.$('#K2BToolsMenu a').on('click', this.onMenuClick);
  };

  this.onMenuClick = function () {
    k2btools.$('#K2BToolsMenu a').removeClass('activeOption');
    k2btools.$(this).addClass('activeOption');
  };

  this.messages_handler_added = false;

  this.RefreshMessageHandling = function () {
    if (k2btools.$('style#k2btools-controlbeautify').length == 0) {
      k2btools.$('<style>').attr('id', 'k2btools-controlbeautify').prop('type', 'text/css').html('.gx_ev{display:none;}').appendTo('head');
    }
    if (!this.IsPostBack) {
      var uc = this;
      if (!this.messages_handler_added) {
        this.messages_handler_added = true;

        toastr.options = {
          closeButton: true,
          debug: false,
          positionClass: 'toast-position',
          onclick: null,
          showDuration: '1000',
          hideDuration: '1000',
          timeOut: '8000',
          extendedTimeOut: '8000',
          showEasing: 'swing',
          hideEasing: 'linear',
          showMethod: 'fadeIn',
          hideMethod: 'fadeOut',
        };

        this.addOnMessageObserver(uc);
      }

      this.processErrorViewerMessages(uc);
    }
  };

  this.showMessage = function (encodeHTML) {
    return function (i, msg) {
      if (!(Object.prototype.toString.call(msg) === '[object Array]')) {
        // Refresh shown messages - take those generated in the last second
        k2btools.messagesShown = k2btools.$(k2btools.messagesShown).filter(function (index, element) {
          return new Date().getTime() - element.timestamp < 1000;
        });

        var message = htmlEncode(msg.text);
        if (!encodeHTML) message = msg.text;

        if (k2btools.showMessagesAssociatedWithAttributes || msg.att == '' || msg.att == undefined || msg.att == null || !gx.fn.isVisible(gx.fn.screen_CtrlRef(msg.att))) {
          if (
            k2btools.$(k2btools.messagesShown).filter(function (index, element) {
              return element.message.text === msg.text;
            }).length == 0
          ) {
            k2btools.messagesShown.push({ timestamp: new Date().getTime(), message: msg });
            if (msg.type === 1 || msg.value === 1) {
              toastr.error(message);
            } else {
              if (message.startsWith('K2BToolsMessage:error:')) {
                toastr.error(message.substr(22));
              } else if (message.startsWith('K2BToolsMessage:success:')) {
                toastr.success(message.substr(24));
              } else if (message.startsWith('K2BToolsMessage:warning:')) {
                toastr.warning(message.substr(24));
              } else if (message.startsWith('K2BToolsMessage:info:')) {
                toastr.info(message.substr(21));
              } else {
                toastr.success(message);
              }
            }
          }
        }
      }
    };
  };

  this.addOnMessageObserver = function (uc) {
    gx.fx.obs.addObserver('gx.onmessages', this, function (messages) {
      for (var obj in messages) {
        if (messages.hasOwnProperty(obj)) {
          var wc = gx.pO.WebComponents[obj];
          if (wc && k2btools.$(wc.containerControl).closest('.K2BT_TwoPaneTransactionContainer') != null) {
            k2btools.$.each(
              messages[obj].filter(m => m.id !== 'SuccessfullyAdded' && m.text !== gx.msg['GXM_confdelete']),
              uc.showMessage(true),
            );
          } else {
            k2btools.$.each(messages[obj], uc.showMessage(true));
          }
        }
      }
    });
  };

  this.processErrorViewerMessages = function (uc) {
    k2btools.$('.gx_ev').each(function (i, item) {
      var pendingMessages = k2btools
        .$(item)
        .children()
        .map(function () {
          if (k2btools.$(this).hasClass('gx-error-message')) return { text: k2btools.$(this).html(), type: 1 };
          else return { text: k2btools.$(this).html() };
        });

      if (item.closest('.K2BT_TwoPaneTransactionContainer') != null) {
        k2btools.$.each(
          k2btools.$(pendingMessages).filter((i, m) => m.text !== gx.msg['GXM_confdelete']),
          uc.showMessage(false),
        );
      } else {
        k2btools.$.each(pendingMessages, uc.showMessage(false));
      }
    });
  };

  function htmlEncode(text) {
    return k2btools.$('<div />').text(text).html();
  }

  this.RefreshTagsCollectionFocus = function () {
    k2btools.$('.K2BToolsAttribute_BorderlessFilter').on('focusin', function () {
      k2btools.$(this).closest('.K2BToolsTable_FieldBorder').addClass('K2BToolsTable_FieldBorderFocus');
    });
    k2btools.$('.K2BToolsAttribute_BorderlessFilter').on('focusout', function () {
      k2btools.$(this).closest('.K2BToolsTable_FieldBorderFocus').removeClass('K2BToolsTable_FieldBorderFocus');
    });
  };

  this.RefreshOnImagePrompt = function () {
    k2btools.$('.K2BToolsOnImagePrompt').closest('A').addClass('btn btn-default');
    k2btools.$('.K2BToolsSection_PromptImageAndFieldContainer').on('focusin', function () {
      k2btools.$(this).addClass('K2BToolsSection_PromptImageAndFieldContainerFocus');
    });
    k2btools.$('.K2BToolsSection_PromptImageAndFieldContainer').on('focusout', function () {
      k2btools.$(this).removeClass('K2BToolsSection_PromptImageAndFieldContainerFocus');
    });
  };
}

/* Old checkall code */

function checkall(ev) {
  checkallgrid(ev, 'vSEL');
}

function getEventTarget(e) {
  e = e || window.event;
  return e.target || e.srcElement;
}

function checkallgrid(e, checksNamePart) {
  if (!e) var e = window.event;
  e.cancelBubble = true;
  if (e.stopPropagation) e.stopPropagation();

  var target = getEventTarget(e);

  for (var i = 0; i < document.MAINFORM.elements.length - 1; i++) {
    var c = document.MAINFORM.elements[i];

    if (c.type == 'checkbox' && c.name != 'allbox' && c.name.toUpperCase().indexOf(checksNamePart.toUpperCase()) >= 0) {
      if (c.checked != target.checked) {
        k2btools.$(c).trigger('click');
        k2btools.$(c).prop('checked', target.checked);
      }
    }
  }
}

/* End old checkall code */
