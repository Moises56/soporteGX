function K2BDesktopNotification(JQuery) {
	this._JQuery = JQuery;
	this.ClickedTag = "";
	var uc = this;
	
	this.GetPermission = function() {
		return Notification.permission;
	}
	
	this.SetPermission = function(data) {
	}
	
	this.GetClickedNotificationTag = function() {
		return uc.ClickedTag;
	}
	
	this.SetClickedNotificationTag = function(data) {
	}
	
	this.show = function () {
		this.triggerPermissionGranted();
	}
	
	this.triggerPermissionGranted = function() {
		if(typeof(uc.OnPermissionGranted) == "function"){
			uc.OnPermissionGranted();
		}
	}
	
	this.RequestPermission = function() {
		Notification.requestPermission().then(function(){
			uc.triggerPermissionGranted();
		});
	}
	
	this.ShowNotification = function(notificationInfo){
		if(Notification.permission  == "granted"){
			var options = {};
			options.body = notificationInfo.Message;
			
			if(notificationInfo.Icon != "" && notificationInfo.Icon != undefined && notificationInfo.Icon != null){
				options.icon = notificationInfo.Icon;
			}
			
			if(notificationInfo.Badge != "" && notificationInfo.Badge != undefined && notificationInfo.Badge != null){
				options.badge = notificationInfo.Badge;
			}
			
			if(notificationInfo.Tag != "" && notificationInfo.Tag != undefined && notificationInfo.Tag != null){
				options.tag = notificationInfo.Tag;
			}
			
			var notif = new Notification(notificationInfo.Title, options);
			notif.onclick = function(event) {
				if(typeof(uc.OnNotificationClicked) == "function"){
					uc.ClickedTag = notif.tag;
					uc.OnNotificationClicked();
				}
			}
			
			if(notificationInfo.Timeout != 0){
				setTimeout(function(){
					notif.close();
				}, notificationInfo.Timeout);
			}
		}
	}
}
