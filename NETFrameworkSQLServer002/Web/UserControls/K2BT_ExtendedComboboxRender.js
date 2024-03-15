function K2BT_ExtendedCombobox($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  

	var template = '<k2bt-enhancedcombo data-gx-binding=\"value\"  data-event=\"CreateItem\" 	includesearch={{IncludeSearch}} 	enableadditem={{EnableAddItem}} 	includeemptyitem={{IncludeEmptyItem}} 	emptyitemtext=\"{{EmptyItemText}}\"	noresultsfoundtext=\"{{NoResultsFoundText}} \"	searchfieldplaceholder=\"{{SearchFieldPlaceHolder}}\"	additemcaption=\"{{AddItemCaption}}\" />';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnCreateItem = 0; 
	var _iOnComboboxValueChanged = 0; 
	var $container;
	var valueObject = {};

	this.setAttribute = function (v) {
		valueObject.value = v;
	}
	this.getAttribute = function () {
		var v = valueObject.value;
		return v;
	}

	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnCreateItem = 0; 
			_iOnComboboxValueChanged = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			var $dataElement = $container.find("[data-gx-binding]");
			var dataElementProp = $dataElement.attr("data-gx-binding") || "value";
			$dataElement.on("input", function () {
				valueObject.value = this[dataElementProp];
			});
			$dataElement.on("change", function () {
				valueObject.value = this[dataElementProp];
			});
			$dataElement.on("focus", this.onfocus.closure(this));
			$dataElement.on("input", this.oninput.closure(this));
			$dataElement.on("change", this.onchange.closure(this));

			$dataElement.prop(dataElementProp, valueObject.value);

			$(this.getContainerControl())
				.find("[data-event='CreateItem']")
				.on('newRecordClicked', this.onCreateItemHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='ComboboxValueChanged']")
				.on('comboboxvaluechanged', this.onComboboxValueChangedHandler.closure(this))
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
				this.control = $(container).find("k2bt-enhancedcombo");
				this.control[0].enabled = this.Enabled;
			      this.control[0].readonlyclass = this.Class.split(' ')
			        .map(s => 'Readonly' + s)
			        .join(' ');

				this.control[0].emptyitemtext = this._getTranslatedMessage(this._resolveValue(this.EmptyItemText, 'GX_EmptyItemText'));
				this.control[0].noresultsfoundtext = this._getTranslatedMessage(this._resolveValue(this.NoResultsFoundText, 'K2BT_NoItems'));
				this.control[0].searchfieldplaceholder = this._getTranslatedMessage(this._resolveValue(this.SearchFieldPlaceholder, 'K2BT_Search'));
				this.control[0].additemcaption = this._getTranslatedMessage(this._resolveValue(this.AddItemCaption, 'K2BT_EnhancedComboAddItemCaption'));
				
				this.control.on('change', function (event) {
					uc.setAttribute(event.originalEvent.detail);
					if (uc.ComboboxValueChanged) {
						uc.ComboboxValueChanged();
					}
				});
			  
		}
		this.SetValues = function(v ) {

			    this.Values = v;
			    if (this.control != null) this.control[0].values = this.Values;
			  
		}
		this.SetValue = function(v ) {

			    this.setAttribute(v);
				if (this.control != null) this.control[0].value = v;
			    if (this.ComboboxValueChanged) {
			      this.ComboboxValueChanged();
			    }
			  
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


		this.onCreateItemHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.CreateItem) {
				this.CreateItem();
			}
		} 

		this.onComboboxValueChangedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.ComboboxValueChanged) {
				this.ComboboxValueChanged();
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