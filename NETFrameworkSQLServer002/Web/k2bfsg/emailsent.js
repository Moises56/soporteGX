gx.evt.autoSkip=!1;gx.define("k2bfsg.emailsent",!1,function(){var n,t,i;this.ServerClass="k2bfsg.emailsent";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.emailsent.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){};this.s112_client=function(){};this.s122_client=function(){};this.e114f1_client=function(){return this.clearMessages(),this.s132_client(),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s132_client=function(){this.call("k2bfsg.login.aspx",[],null,[])};this.e154f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e164f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42];this.GXLastCtrlId=42;this.ATTRIBUTESContainer=gx.uc.getNew(this,18,0,"K2BT_Component","ATTRIBUTESContainer","Attributes","ATTRIBUTES");t=this.ATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Icon","Icon","","str");t.setProp("Title","Title",gx.getMessage("K2BT_GAM_EmailSent"),"str");t.setProp("TitleClass","Titleclass","TextBlock_Subtitle","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Open","Open",!0,"bool");t.setProp("ShowBorders","Showborders",!0,"bool");t.setProp("ContainsEditableForm","Containseditableform",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,43,40,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");i=this.K2BCONTROLBEAUTIFY1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"CONTENTTABLE",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"COLUMNS",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"COLUMN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[20]={id:20,fld:"ATTRIBUTES_CONTENT",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"ATTRIBUTESCONTAINERTABLE_ATTRIBUTES",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"TEXTBLOCK_MESSAGE_CELLCONTAINERTABLE",grid:0};n[27]={id:27,fld:"MESSAGE",format:0,grid:0,ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCK_WAITTIME_CELLCONTAINERTABLE",grid:0};n[31]={id:31,fld:"WAITTIME",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"RESPONSIVETABLE_CONTAINERNODE_ACTIONS",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"ACTIONSCONTAINERTABLELEFT_ACTIONS",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGOTOLOGIN_ACTION",fmt:0,gxz:"ZV8GoToLogin_Action",gxold:"OV8GoToLogin_Action",gxvar:"AV8GoToLogin_Action",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8GoToLogin_Action=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8GoToLogin_Action=n)},v2c:function(){gx.fn.setControlValue("vGOTOLOGIN_ACTION",gx.O.AV8GoToLogin_Action,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8GoToLogin_Action=this.val())},val:function(){return gx.fn.getControlValue("vGOTOLOGIN_ACTION")},nac:gx.falseFn,evt:"e114f1_client"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};this.AV8GoToLogin_Action="";this.ZV8GoToLogin_Action="";this.OV8GoToLogin_Action="";this.AV8GoToLogin_Action="";this.Events={e154f2_client:["ENTER",!0],e164f2_client:["CANCEL",!0],e114f1_client:["'E_GOTOLOGIN'",!1]};this.EvtParms.REFRESH=[[],[{av:"AV8GoToLogin_Action",fld:"vGOTOLOGIN_ACTION",pic:""}]];this.EvtParms["'E_GOTOLOGIN'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize();this.setSDTMapping("K2BActivityList.K2BActivityListItem",{Activity:{sdt:"K2BActivity"}})});gx.wi(function(){gx.createParentObj(this.k2bfsg.emailsent)})