gx.evt.autoSkip=!1;gx.define("gamexampleidplogin",!1,function(){var n,t;this.ServerClass="gamexampleidplogin";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamexampleidplogin.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV13IDP_State=gx.fn.getControlValue("vIDP_STATE");this.AV18Language=gx.fn.getControlValue("vLANGUAGE");this.AV37AuxUserName=gx.fn.getControlValue("vAUXUSERNAME");this.AV30UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",gx.thousandSeparator);this.subGridauthtypes_Recordcount=gx.fn.getIntegerValue("subGridauthtypes_Recordcount",gx.thousandSeparator)};this.e11321_client=function(){return this.clearMessages(),this.call("gamexamplerecoverpasswordstep1.aspx",[this.AV13IDP_State],null,["IDP_State"]),this.refreshOutputs([{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12322_client=function(){return this.executeServerEvent("VLOGONTO.CLICK",!0,null,!1,!0)};this.e13322_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14322_client=function(){return this.executeServerEvent("'SELECTAUTHENTICATIONTYPE'",!0,arguments[0],!1,!1)};this.e18322_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,59,60,61,62,63,64,65];this.GXLastCtrlId=65;this.GridauthtypesContainer=new gx.grid.grid(this,2,"WbpLvl2",58,"Gridauthtypes","Gridauthtypes","GridauthtypesContainer",this.CmpContext,this.IsMasterPage,"gamexampleidplogin",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.GridauthtypesContainer;t.startDiv(59,"Tblgridextauthtypes","0px","0px");t.startDiv(60,"","0px","0px");t.startDiv(61,"","0px","0px");t.addButton(62,"EXTERNALAUTHENTICATION","standard","'","e14322_client");t.endDiv();t.startDiv(63,"","0px","0px");t.startDiv(64,"","0px","0px");t.addLabel();t.addSingleLineEdit("Nameauthtype",65,"vNAMEAUTHTYPE","","","NameAuthType","char",60,"chr",60,60,"start",null,[],"Nameauthtype","NameAuthType",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();this.GridauthtypesContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBTITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGOAPPCLIENT",fmt:0,gxz:"ZV20LogoAppClient",gxold:"OV20LogoAppClient",gxvar:"AV20LogoAppClient",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20LogoAppClient=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20LogoAppClient=n)},v2c:function(){gx.fn.setMultimediaValue("vLOGOAPPCLIENT",gx.O.AV20LogoAppClient,gx.O.AV41Logoappclient_GXI)},c2v:function(){gx.O.AV41Logoappclient_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV20LogoAppClient=this.val())},val:function(){return gx.fn.getBlobValue("vLOGOAPPCLIENT")},val_GXI:function(){return gx.fn.getControlValue("vLOGOAPPCLIENT_GXI")},gxvar_GXI:"AV41Logoappclient_GXI",nac:gx.falseFn};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"TBAPPNAME",format:0,grid:0,ctrltype:"textblock"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",fmt:0,gxz:"ZV21LogOnTo",gxold:"OV21LogOnTo",gxvar:"AV21LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV21LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV21LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn,evt:"e12322_client"};this.declareDomainHdlr(18,function(){});n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV28UserName",gxold:"OV28UserName",gxvar:"AV28UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV28UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV29UserPassword",gxold:"OV29UserPassword",gxvar:"AV29UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV29UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TBFORGOTPWD",format:0,grid:0,evt:"e11321_client",ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",fmt:0,gxz:"ZV22RememberMe",gxold:"OV22RememberMe",gxvar:"AV22RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV22RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TBLLOGINBUTTON",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",fmt:0,gxz:"ZV17KeepMeLoggedIn",gxold:"OV17KeepMeLoggedIn",gxvar:"AV17KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV17KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"LOGIN",grid:0,evt:"e13322_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TBLEXTERNALSAUTH",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TBEXTERNALAUTHENTICATION",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[59]={id:59,fld:"TBLGRIDEXTAUTHTYPES",grid:58};n[60]={id:60,fld:"",grid:58};n[61]={id:61,fld:"",grid:58};n[62]={id:62,fld:"EXTERNALAUTHENTICATION",grid:58,evt:"e14322_client"};n[63]={id:63,fld:"",grid:58};n[64]={id:64,fld:"",grid:58};n[65]={id:65,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:58,gxgrid:this.GridauthtypesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAMEAUTHTYPE",fmt:0,gxz:"ZV36NameAuthType",gxold:"OV36NameAuthType",gxvar:"AV36NameAuthType",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV36NameAuthType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36NameAuthType=n)},v2c:function(n){gx.fn.setGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(58),gx.O.AV36NameAuthType,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV36NameAuthType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(58))},nac:gx.falseFn};this.AV41Logoappclient_GXI="";this.AV20LogoAppClient="";this.ZV20LogoAppClient="";this.OV20LogoAppClient="";this.AV21LogOnTo="";this.ZV21LogOnTo="";this.OV21LogOnTo="";this.AV28UserName="";this.ZV28UserName="";this.OV28UserName="";this.AV29UserPassword="";this.ZV29UserPassword="";this.OV29UserPassword="";this.AV22RememberMe=!1;this.ZV22RememberMe=!1;this.OV22RememberMe=!1;this.AV17KeepMeLoggedIn=!1;this.ZV17KeepMeLoggedIn=!1;this.OV17KeepMeLoggedIn=!1;this.ZV36NameAuthType="";this.OV36NameAuthType="";this.AV20LogoAppClient="";this.AV21LogOnTo="";this.AV28UserName="";this.AV29UserPassword="";this.AV22RememberMe=!1;this.AV17KeepMeLoggedIn=!1;this.AV13IDP_State="";this.AV36NameAuthType="";this.AV18Language="";this.AV37AuxUserName="";this.AV30UserRememberMe=0;this.Events={e12322_client:["VLOGONTO.CLICK",!0],e13322_client:["ENTER",!0],e14322_client:["'SELECTAUTHENTICATIONTYPE'",!0],e18322_client:["CANCEL",!0],e11321_client:["'FORGOTPASSWORD'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDAUTHTYPES_nFirstRecordOnPage"},{av:"GRIDAUTHTYPES_nEOF"},{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV18Language",fld:"vLANGUAGE",pic:"",hsh:!0},{av:"AV37AuxUserName",fld:"vAUXUSERNAME",pic:"",hsh:!0},{av:"AV30UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("GRIDAUTHTYPES","Visible")',ctrl:"GRIDAUTHTYPES",prop:"Visible"},{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{ctrl:"LOGIN",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBFORGOTPWD","Visible")',ctrl:"TBFORGOTPWD",prop:"Visible"}]];this.EvtParms["GRIDAUTHTYPES.LOAD"]=[[{av:'gx.fn.getCtrlProperty("TBLEXTERNALSAUTH","Visible")',ctrl:"TBLEXTERNALSAUTH",prop:"Visible"}],[{av:"AV36NameAuthType",fld:"vNAMEAUTHTYPE",pic:"",hsh:!0},{ctrl:"EXTERNALAUTHENTICATION",prop:"Caption"},{ctrl:"EXTERNALAUTHENTICATION",prop:"Tooltiptext"},{av:'gx.fn.getCtrlProperty("TBLEXTERNALSAUTH","Visible")',ctrl:"TBLEXTERNALSAUTH",prop:"Visible"}]];this.EvtParms["VLOGONTO.CLICK"]=[[{av:"AV18Language",fld:"vLANGUAGE",pic:"",hsh:!0},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""}],[{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Invitemessage")',ctrl:"vUSERPASSWORD",prop:"Invitemessage"},{ctrl:"LOGIN",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBFORGOTPWD","Visible")',ctrl:"TBFORGOTPWD",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""}],[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""}]];this.EvtParms["'FORGOTPASSWORD'"]=[[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""}]];this.EvtParms["'SELECTAUTHENTICATIONTYPE'"]=[[{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV36NameAuthType",fld:"vNAMEAUTHTYPE",pic:"",hsh:!0},{av:"AV13IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""}],[]];this.EnterCtrl=["LOGIN"];this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV18Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV37AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV30UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV18Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV37AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV30UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV18Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV37AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV30UserRememberMe","vUSERREMEMBERME",0,"int",2,0);t.addRefreshingVar({rfrVar:"AV13IDP_State"});t.addRefreshingVar({rfrVar:"AV18Language"});t.addRefreshingVar({rfrVar:"AV37AuxUserName"});t.addRefreshingVar({rfrVar:"AV30UserRememberMe"});t.addRefreshingParm({rfrVar:"AV13IDP_State"});t.addRefreshingParm({rfrVar:"AV18Language"});t.addRefreshingParm({rfrVar:"AV37AuxUserName"});t.addRefreshingParm({rfrVar:"AV30UserRememberMe"});t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[47]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamexampleidplogin)})