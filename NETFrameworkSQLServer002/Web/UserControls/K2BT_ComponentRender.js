function K2BT_Component($) {
	  
	  
	  
	  
	  
	  
	  

	var template = '<div class=\"K2BToolsTable_ComponentContainer\">	<div class=\"K2BT_ComponentTitleContainer\">		<img class=\"K2BT_ComponentTitleIcon\" src=\"{{Icon}}\"/>		<div class=\"{{TitleClass}}\"><span>{{Title}}</span></div>		<div class=\"K2BT_CollapsibleCardButton\"><span></span></div>	</div>	<div class=\"K2BT_ComponentContent\">		<div data-slot=\"Content\" data-parent=\"{{ContainerName}}\"></div>	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnOpen = 0; 
	var _iOnOnCollapse = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnOpen = 0; 
			_iOnOnCollapse = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnOpen']")
				.on('open', this.onOnOpenHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='OnCollapse']")
				.on('collapse', this.onOnCollapseHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.ButtonHandlers(); 
	}

	this.Scripts = [];

		this.ButtonHandlers = function() {

					var uc = this;
					uc.container = $(this.getContainerControl()).children(".K2BToolsTable_ComponentContainer");
					var header = $(uc.container).children(".K2BT_ComponentTitleContainer");
					
					if(!uc.ShowBorders)
						uc.container.removeClass("K2BToolsTable_ComponentContainer");
					
					if(uc.Open == false || uc.Open == "false")
						uc.container.addClass("K2BT_CollapsedCard");
						
					if(uc.Icon == undefined || uc.Icon == "")
						header.children(".K2BT_ComponentTitleIcon").hide();
				
					if(uc.Title != null && uc.Title != undefined && uc.Title != ""){
						if(uc.Collapsible){
							uc.container.addClass("K2BT_CollapsibleCard");
							header.on("click", function(){			
								if(uc.container.hasClass("K2BT_CollapsedCard")){
									uc.container.removeClass("K2BT_CollapsedCard");
									uc.Open = true;
									if(uc.OnOpen){
										uc.OnOpen();
									}
								}else{
									uc.container.addClass("K2BT_CollapsedCard");
									uc.Open = false;
									if(uc.OnCollapse){
										uc.OnCollapse();
									}
								}
							});
						}
					}else{
						header.hide();
					}
				
					if(uc.ContainsEditableForm){
						uc.container.addClass("K2BT_EditableForm");
					}
				
		}
		this.SetIsOpen = function(isOpen ) {

					this.Open = isOpen;
					if(this.Open == false || this.Open == "false")
						this.container.addClass("K2BT_CollapsedCard");
					else
						this.container.removeClass("K2BT_CollapsedCard");
				
		}


		this.onOnOpenHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.OnOpen) {
				this.OnOpen();
			}
		} 

		this.onOnCollapseHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.OnCollapse) {
				this.OnCollapse();
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