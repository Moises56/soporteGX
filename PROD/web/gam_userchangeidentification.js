gx.evt.autoSkip=!1;gx.define("gam_userchangeidentification",!1,function(){this.ServerClass="gam_userchangeidentification";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_userchangeidentification.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV6ChangeType=gx.fn.getControlValue("vCHANGETYPE")};this.s112_client=function(){this.createWebComponent("Wcmessages","GAM_Messages",[])};this.e123b2_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e143b2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e153b2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCURRENTUSERIDENTIFICATON",fmt:0,gxz:"ZV8CurrentUserIdentificaton",gxold:"OV8CurrentUserIdentificaton",gxvar:"AV8CurrentUserIdentificaton",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8CurrentUserIdentificaton=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8CurrentUserIdentificaton=n)},v2c:function(){gx.fn.setControlValue("vCURRENTUSERIDENTIFICATON",gx.O.AV8CurrentUserIdentificaton,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8CurrentUserIdentificaton=this.val())},val:function(){return gx.fn.getControlValue("vCURRENTUSERIDENTIFICATON")},nac:gx.falseFn};this.declareDomainHdlr(8,function(){});n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNEWUSERIDENTIFICATION",fmt:0,gxz:"ZV12NewUserIdentification",gxold:"OV12NewUserIdentification",gxvar:"AV12NewUserIdentification",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12NewUserIdentification=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12NewUserIdentification=n)},v2c:function(){gx.fn.setControlValue("vNEWUSERIDENTIFICATION",gx.O.AV12NewUserIdentification,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12NewUserIdentification=this.val())},val:function(){return gx.fn.getControlValue("vNEWUSERIDENTIFICATION")},nac:gx.falseFn};this.declareDomainHdlr(13,function(){});n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCONFIRMUSERIDENTIFICATION",fmt:0,gxz:"ZV7ConfirmUserIdentification",gxold:"OV7ConfirmUserIdentification",gxvar:"AV7ConfirmUserIdentification",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7ConfirmUserIdentification=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ConfirmUserIdentification=n)},v2c:function(){gx.fn.setControlValue("vCONFIRMUSERIDENTIFICATION",gx.O.AV7ConfirmUserIdentification,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7ConfirmUserIdentification=this.val())},val:function(){return gx.fn.getControlValue("vCONFIRMUSERIDENTIFICATION")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV13UserPassword",gxold:"OV13UserPassword",gxvar:"AV13UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV13UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"GAM_FOOTERPOPUP",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"GAM_FOOTERPOPUP_TABLEBUTTONS",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"GAM_FOOTERPOPUP_BTNCANCEL",grid:0,evt:"e163b1_client"};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"GAM_FOOTERPOPUP_BTNCONFIRM",grid:0,evt:"e123b2_client"};this.AV8CurrentUserIdentificaton="";this.ZV8CurrentUserIdentificaton="";this.OV8CurrentUserIdentificaton="";this.AV12NewUserIdentification="";this.ZV12NewUserIdentification="";this.OV12NewUserIdentification="";this.AV7ConfirmUserIdentification="";this.ZV7ConfirmUserIdentification="";this.OV7ConfirmUserIdentification="";this.AV13UserPassword="";this.ZV13UserPassword="";this.OV13UserPassword="";this.AV8CurrentUserIdentificaton="";this.AV12NewUserIdentification="";this.AV7ConfirmUserIdentification="";this.AV13UserPassword="";this.AV6ChangeType="";this.Events={e123b2_client:["'CONFIRM'",!0],e143b2_client:["ENTER",!0],e153b2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV8CurrentUserIdentificaton",fld:"vCURRENTUSERIDENTIFICATON",pic:"",hsh:!0},{av:"AV6ChangeType",fld:"vCHANGETYPE",pic:"",hsh:!0}],[]];this.EvtParms["'CONFIRM'"]=[[{av:"AV12NewUserIdentification",fld:"vNEWUSERIDENTIFICATION",pic:""},{av:"AV7ConfirmUserIdentification",fld:"vCONFIRMUSERIDENTIFICATION",pic:""},{av:"AV8CurrentUserIdentificaton",fld:"vCURRENTUSERIDENTIFICATON",pic:"",hsh:!0},{av:"AV13UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV6ChangeType",fld:"vCHANGETYPE",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vNEWUSERIDENTIFICATION","Enabled")',ctrl:"vNEWUSERIDENTIFICATION",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vCONFIRMUSERIDENTIFICATION","Enabled")',ctrl:"vCONFIRMUSERIDENTIFICATION",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Enabled")',ctrl:"vUSERPASSWORD",prop:"Enabled"},{ctrl:"GAM_FOOTERPOPUP_BTNCONFIRM",prop:"Visible"},{ctrl:"WCMESSAGES"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV6ChangeType","vCHANGETYPE",0,"svchar",40,0);this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0026",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_userchangeidentification)})