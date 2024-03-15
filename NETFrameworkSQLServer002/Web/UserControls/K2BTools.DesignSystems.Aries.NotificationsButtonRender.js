function K2BTools_DesignSystems_Aries_NotificationsButton($) {
	  
	  
	  

	var template = '<div class=\"K2BT_NotificationsBellButton {{ButtonClass}}\"  data-event=\"Event\" >	<div class=\"K2BT_NotificationsBellCounter\">{{Count}}</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnEvent = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts
			this.NormalizeCount(); 

			_iOnEvent = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Event']")
				.on('click', this.onEventHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this._hideCounterIfNecessary(); 
	}

	this.Scripts = [];

		this._hideCounterIfNecessary = function() {

			  	if(this.Count != "9+" && this.Count < 1){
					$(this.getContainerControl()).find(".K2BT_NotificationsBellCounter").hide();
				}else{
					$(this.getContainerControl()).find(".K2BT_NotificationsBellCounter").show();
				}
			  
		}
		this.NormalizeCount = function() {

			  	if(this.Count > 9) this.Count = "9+";
			  
		}


		this.onEventHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
			}

			if (this.Event) {
				this.Event();
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