function K2BT_ConfirmDialog($) {
	  
	  
	  

	var template = '<div class=\"Table_ConditionalConfirm\" style=\"display:none;\">	<div class=\"Section_CondConf_Dialog\">		<div class=\"Section_CondConf_DialogInner\">			<span class=\"K2BT_ConfirmDialogMessage\"></span>			<div class=\"K2BT_ConfirmActions\">				<input type=\"button\" value=\"Ok\" class=\"K2BT_ConfirmDialogOk K2BToolsButton_MainAction_Confirm btn btn-default\"/>				<input type=\"button\" value=\"Cancel\" class=\"K2BT_ConfirmDialogCancel Button_Standard btn btn-default\"/>			</div>		</div>	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnOKClicked = 0; 
	var _iOnOnCancelClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnOKClicked = 0; 
			_iOnOnCancelClicked = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnOKClicked']")
				.on('okclicked', this.onOnOKClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='OnCancelClicked']")
				.on('cancelclicked', this.onOnCancelClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.ButtonHandlers(); 
	}

	this.Scripts = [];

		this.ButtonHandlers = function() {

			  	var uc = this;
				var container = this.getContainerControl();
				
				$(container).hide();
				$(container).find(".Table_ConditionalConfirm").show();
				
				var message = $(container).find(".K2BT_ConfirmDialogMessage");
				var okbutton = $(container).find(".K2BT_ConfirmDialogOk");
				var cancelbutton = $(container).find(".K2BT_ConfirmDialogCancel");
				
				message.text(this._getTranslatedMessage(this._resolveValue(this.ConfirmMessage, 'K2BT_AreYouSure')));
				var okButtonText = this._getTranslatedMessage(this._resolveValue(this.OKCaption, 'K2BT_ConfirmOk'));
				okbutton.prop('value', okButtonText);
				
				var cancelButtonText = this._getTranslatedMessage(this._resolveValue(this.CancelCaption, 'K2BT_ConfirmCancel'));
				cancelbutton.prop('value', cancelButtonText);
				
				okbutton.on('click', function (event) {
					if (uc.OnOKClicked) {
						uc.OnOKClicked();
					}
				});

				cancelbutton.on('click', function (event) {
					if (uc.OnCancelClicked) {
						uc.OnCancelClicked();
					}
				});
				
			  
		}
		this._resolveValue = function(provided ,defaultValue ) {

			  	return provided == undefined || provided == '' || provided == null ? defaultValue : provided;
			  
		}
		this._getTranslatedMessage = function(msg ) {

			  	if (msg.indexOf('GX') == 0 || msg.indexOf('K2B') == 0) {
			      var translated = gx.msg[msg];
			      if (translated !== undefined) {
			        return translated;
			      }
			    }
			    return msg;
			  
		}


		this.onOnOKClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
			}

			if (this.OnOKClicked) {
				this.OnOKClicked();
			}
		} 

		this.onOnCancelClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
			}

			if (this.OnCancelClicked) {
				this.OnCancelClicked();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}