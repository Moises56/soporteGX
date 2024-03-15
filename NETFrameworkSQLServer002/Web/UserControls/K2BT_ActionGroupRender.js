function K2BT_ActionGroup($) {
	  
	  

	var template = '<div>	<div class=\"K2BT_ActionGroupHeader\" tabindex=\"0\">		<img src=\"{{HeaderImageURI}}\" />		<span>{{HeaderCaption}}</span>	</div>	<div>		<div class=\"K2BT_ActionGroupContents\">			<div data-slot=\"Contents\" data-parent=\"{{ContainerName}}\"></div>		</div>	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts
			this.ButtonHandlers(); 
	}

	this.Scripts = [];

		this.ButtonHandlers = function() {

			  	var uc = this;
				var container = this.getContainerControl();
				var contents = $(container).find(".K2BT_ActionGroupContents");
				$(contents).hide();
				$(container).find(".K2BT_ActionGroupHeader").on("click", function(){
					$(contents).toggle();
				});

				$(container).find(".K2BT_ActionGroupHeader").on("keydown", function(event){
					if (event.key == 'Enter')
						$(contents).toggle();
				});

				if(uc.HeaderImageURI == ""){
					$(container).find(".K2BT_ActionGroupHeader img").hide();
				}

				gx.fx.obs.addObserver('gx.onafterevent', k2btools, function(){
					$(contents).hide();
				}, { single: false, unique: true });

				k2btools.$('html').on('click', function(e){	
						if($(e.target).closest(container).length == 0){
							$(contents).hide();	
						}
				});
				
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