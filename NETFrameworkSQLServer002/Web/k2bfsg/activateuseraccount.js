gx.evt.autoSkip=!1;gx.define("k2bfsg.activateuseraccount",!1,function(){var n,t;this.ServerClass="k2bfsg.activateuseraccount";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.activateuseraccount.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV19ActivationKey=gx.fn.getControlValue("vACTIVATIONKEY")};this.s112_client=function(){};this.s122_client=function(){};this.e114k1_client=function(){return this.clearMessages(),this.s132_client(),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s132_client=function(){this.call("k2bfsg.login.aspx",[],null,[])};this.e134k2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e164k2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22];this.GXLastCtrlId=22;this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,23,0,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");t=this.K2BCONTROLBEAUTIFY1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"CONTENTTABLE",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TBMSG",format:0,grid:0,ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"RESPONSIVETABLE_CONTAINERNODE_ACTIONS",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"ACTIONSCONTAINERTABLELEFT_ACTIONS",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"GOTOLOGIN",grid:0,evt:"e114k1_client"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};this.AV19ActivationKey="";this.Events={e134k2_client:["ENTER",!0],e164k2_client:["CANCEL",!0],e114k1_client:["'E_GOTOLOGIN'",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms["'E_GOTOLOGIN'"]=[[],[]];this.setVCMap("AV19ActivationKey","vACTIVATIONKEY",0,"char",254,0);this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},InitialProperties:{sdt:"GeneXusSecurity\\GAMProperty"},SecurityPolicy:{sdt:"GeneXusSecurity\\GAMSecurityPolicy"}});this.setSDTMapping("GeneXusSecurity\\GAMUser",{Attributes:{sdt:"GeneXusSecurity\\GAMUserAttribute"}});this.setSDTMapping("GeneXusSecurity\\GAMRole",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRepository",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Email:{sdt:"GeneXusSecurity\\GAMRepositoryEmail"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationFilter",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMPermission",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationPermission",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicyFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicy",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRoleFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMLoginAdditionalParameters",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenu",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationTypeFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationType",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BActivityList.K2BActivityListItem",{Activity:{sdt:"K2BActivity"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenuOption",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BTrnContext",{TransactionName:{extr:"Transaction"},CallerUrl:{extr:"CallerUrl"},EntityManagerName:{extr:"EMName"},EntityManagerNextTaskCode:{extr:"NextTaskCode"},EntityManagerNextTaskMode:{extr:"NextTaskMode"},EntityManagerEncryptUrlParameters:{extr:"EncryptUrlParms"},ReturnMode:{extr:"ReturnMode"},SavePK:{extr:"SavePK"},AfterInsert:{sdt:"K2BTrnNavigation"},AfterUpdate:{sdt:"K2BTrnNavigation"},AfterDelete:{sdt:"K2BTrnNavigation"},Attributes:{extr:"Attributes"}});this.setSDTMapping("GeneXusSecurity\\GAMEventSubscription",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}})});gx.wi(function(){gx.createParentObj(this.k2bfsg.activateuseraccount)})