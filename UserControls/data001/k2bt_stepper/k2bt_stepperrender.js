function K2BT_Stepper($) {
	  
	  
	  
	  
	  

	var template = '<div class=\"K2BT_Stepper\">	<span data-k2btools-stepper-id=\"readonly\" class=\"Readonly{{AttributeClass}}\"></span>	<span data-k2btools-stepper-id=\"decrease\" class=\"K2BT_Stepper_Button K2BT_Stepper_Decrease\">−</span>	<input data-k2btools-stepper-id=\"input\" class=\"form-control {{AttributeClass}} K2BT_StepperValue\" type=\"numeric\" data-gx-binding=\"value\" />	<span data-k2btools-stepper-id=\"increase\" class=\"K2BT_Stepper_Button K2BT_Stepper_Increase\">+</span></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	var valueObject = {};

	this.setAttribute = function (v) {
		valueObject.value = Number(v);
	}
	this.getAttribute = function () {
		var v = valueObject.value;
		return v;
	}

	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			var $dataElement = $container.find("[data-gx-binding]");
			var dataElementProp = $dataElement.attr("data-gx-binding") || "value";
			$dataElement.on("input", function () {
				valueObject.value = Number(this[dataElementProp]);
			});
			$dataElement.on("change", function () {
				valueObject.value = Number(this[dataElementProp]);
			});
			$dataElement.on("focus", this.onfocus.closure(this));
			$dataElement.on("input", this.oninput.closure(this));
			$dataElement.on("change", this.onchange.closure(this));

			$dataElement.prop(dataElementProp, valueObject.value);



			// Raise after show scripts
			this.ButtonHandlers(); 
	}

	this.Scripts = [];

		this.ButtonHandlers = function() {

			  	var uc = this;
				
				var container = this.getContainerControl();
				this.readonlySpan = $(container).find("span[data-k2btools-stepper-id='readonly']");
			  	this.decrease = $(container).find("span[data-k2btools-stepper-id='decrease']");
				this.increase = $(container).find("span[data-k2btools-stepper-id='increase']");
				this.input = $(container).find("input[data-k2btools-stepper-id='input']");
				
				var classes = $.map(uc.AttributeClass.split(" "), function(s){ return "Readonly"+s;});
				this.readonlySpan.addClass(classes);
				this.input.attr("maxlength", Math.max(this.MinValue.toString().length, this.MaxValue.toString().length, this.Step.toString().length))
				this.input.attr("size", this.input.attr("maxlength"));
				
				$(this.input).on("change", function(e){
					uc._setBoundedValue($(uc.input).val());
				});
				
				if(uc.Enabled){
					this.readonlySpan.hide();
					$(this.decrease).on("click", function(e){
						newValue = $(uc.input).val() - Number(uc.Step);
						uc._setBoundedValue(newValue);
					});
					
					$(this.increase).on("click", function(e){
						newValue = Number($(uc.input).val()) + Number(uc.Step);
						uc._setBoundedValue(newValue);
					});
				}else{
					this.readonlySpan.show();
					this.readonlySpan.text(this.input.val());
					this.decrease.hide();
					this.increase.hide();
					this.input.hide();
				}
			  
		}
		this._setBoundedValue = function(newValue ) {

			  		if(newValue > Number(this.MaxValue))
						$(this.input).val(Number(this.MaxValue));
					else if(newValue < Number(this.MinValue))
						$(this.input).val(Number(this.MinValue));
					else
						$(this.input).val(newValue);
					
					this.setAttribute(Number($(this.input).val()));
			  
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