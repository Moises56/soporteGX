gx.evt.autoSkip=!1;gx.define("gamexamplelogin",!1,function(){var n,t;this.ServerClass="gamexamplelogin";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamexamplelogin.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV23Language=gx.fn.getControlValue("vLANGUAGE");this.AV8AuxUserName=gx.fn.getControlValue("vAUXUSERNAME");this.AV33UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",gx.thousandSeparator);this.AV16IDP_State=gx.fn.getControlValue("vIDP_STATE");this.subGridextauthtypes_Recordcount=gx.fn.getIntegerValue("subGridextauthtypes_Recordcount",gx.thousandSeparator)};this.e122v1_client=function(){return this.clearMessages(),this.call("gamexamplerecoverpasswordstep1.aspx",[this.AV16IDP_State],null,["IDP_State"]),this.refreshOutputs([{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e112v1_client=function(){return this.clearMessages(),this.call("gamexampleregisteruser.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e132v2_client=function(){return this.executeServerEvent("VLOGONTO.CLICK",!0,null,!1,!0)};this.e142v2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e152v2_client=function(){return this.executeServerEvent("'SELECTAUTHENTICATIONTYPE'",!0,arguments[0],!1,!1)};this.e192v2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,63,64,65,66,67,68,69];this.GXLastCtrlId=69;this.GridextauthtypesContainer=new gx.grid.grid(this,2,"WbpLvl2",62,"Gridextauthtypes","Gridextauthtypes","GridextauthtypesContainer",this.CmpContext,this.IsMasterPage,"gamexamplelogin",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.GridextauthtypesContainer;t.startDiv(63,"Tblgridextauthtypes","0px","0px");t.startDiv(64,"","0px","0px");t.startDiv(65,"","0px","0px");t.addButton(66,"EXTERNALAUTHENTICATION","standard","'","e152v2_client");t.endDiv();t.startDiv(67,"","0px","0px");t.startDiv(68,"","0px","0px");t.addLabel();t.addSingleLineEdit("Nameauthtype",69,"vNAMEAUTHTYPE","","","NameAuthType","char",60,"chr",60,60,"start",null,[],"Nameauthtype","NameAuthType",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();this.GridextauthtypesContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBTITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TBCURRENTREPOSITORY",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECREATEACCOUNT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TBHAVEACCOUNT",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TBREGISTER",format:0,grid:0,evt:"e112v1_client",ctrltype:"textblock"};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",fmt:0,gxz:"ZV25LogOnTo",gxold:"OV25LogOnTo",gxvar:"AV25LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV25LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV25LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV25LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn,evt:"e132v2_client"};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV31UserName",gxold:"OV31UserName",gxvar:"AV31UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV31UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV31UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(27,function(){});n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV32UserPassword",gxold:"OV32UserPassword",gxvar:"AV32UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV32UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV32UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV32UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TBFORGOTPWD",format:0,grid:0,evt:"e122v1_client",ctrltype:"textblock"};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",fmt:0,gxz:"ZV27RememberMe",gxold:"OV27RememberMe",gxvar:"AV27RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV27RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV27RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV27RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV27RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TBLLOGINBUTTON",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",fmt:0,gxz:"ZV22KeepMeLoggedIn",gxold:"OV22KeepMeLoggedIn",gxvar:"AV22KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV22KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV22KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"LOGIN",grid:0,evt:"e142v2_client",std:"ENTER"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"TBLEXTERNALSAUTH",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"TBEXTERNALAUTHENTICATION",format:0,grid:0,ctrltype:"textblock"};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[63]={id:63,fld:"TBLGRIDEXTAUTHTYPES",grid:62};n[64]={id:64,fld:"",grid:62};n[65]={id:65,fld:"",grid:62};n[66]={id:66,fld:"EXTERNALAUTHENTICATION",grid:62,evt:"e152v2_client"};n[67]={id:67,fld:"",grid:62};n[68]={id:68,fld:"",grid:62};n[69]={id:69,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:62,gxgrid:this.GridextauthtypesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAMEAUTHTYPE",fmt:0,gxz:"ZV26NameAuthType",gxold:"OV26NameAuthType",gxvar:"AV26NameAuthType",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV26NameAuthType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26NameAuthType=n)},v2c:function(n){gx.fn.setGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(62),gx.O.AV26NameAuthType,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV26NameAuthType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(62))},nac:gx.falseFn};this.AV25LogOnTo="";this.ZV25LogOnTo="";this.OV25LogOnTo="";this.AV31UserName="";this.ZV31UserName="";this.OV31UserName="";this.AV32UserPassword="";this.ZV32UserPassword="";this.OV32UserPassword="";this.AV27RememberMe=!1;this.ZV27RememberMe=!1;this.OV27RememberMe=!1;this.AV22KeepMeLoggedIn=!1;this.ZV22KeepMeLoggedIn=!1;this.OV22KeepMeLoggedIn=!1;this.ZV26NameAuthType="";this.OV26NameAuthType="";this.AV25LogOnTo="";this.AV31UserName="";this.AV32UserPassword="";this.AV27RememberMe=!1;this.AV22KeepMeLoggedIn=!1;this.AV26NameAuthType="";this.AV23Language="";this.AV8AuxUserName="";this.AV33UserRememberMe=0;this.AV16IDP_State="";this.Events={e132v2_client:["VLOGONTO.CLICK",!0],e142v2_client:["ENTER",!0],e152v2_client:["'SELECTAUTHENTICATIONTYPE'",!0],e192v2_client:["CANCEL",!0],e122v1_client:["'FORGOTPASSWORD'",!1],e112v1_client:["'REGISTER'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDEXTAUTHTYPES_nFirstRecordOnPage"},{av:"GRIDEXTAUTHTYPES_nEOF"},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV22KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV23Language",fld:"vLANGUAGE",pic:"",hsh:!0},{av:"AV8AuxUserName",fld:"vAUXUSERNAME",pic:"",hsh:!0},{av:"AV33UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("GRIDEXTAUTHTYPES","Visible")',ctrl:"GRIDEXTAUTHTYPES",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERNAME","Invitemessage")',ctrl:"vUSERNAME",prop:"Invitemessage"},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{ctrl:"LOGIN",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBFORGOTPWD","Visible")',ctrl:"TBFORGOTPWD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TABLECREATEACCOUNT","Visible")',ctrl:"TABLECREATEACCOUNT",prop:"Visible"}]];this.EvtParms["GRIDEXTAUTHTYPES.LOAD"]=[[{av:'gx.fn.getCtrlProperty("TBLEXTERNALSAUTH","Visible")',ctrl:"TBLEXTERNALSAUTH",prop:"Visible"}],[{av:"AV26NameAuthType",fld:"vNAMEAUTHTYPE",pic:"",hsh:!0},{ctrl:"EXTERNALAUTHENTICATION",prop:"Caption"},{ctrl:"EXTERNALAUTHENTICATION",prop:"Tooltiptext"},{av:'gx.fn.getCtrlProperty("TBLEXTERNALSAUTH","Visible")',ctrl:"TBLEXTERNALSAUTH",prop:"Visible"}]];this.EvtParms["VLOGONTO.CLICK"]=[[{av:"AV23Language",fld:"vLANGUAGE",pic:"",hsh:!0},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""}],[{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Invitemessage")',ctrl:"vUSERPASSWORD",prop:"Invitemessage"},{ctrl:"LOGIN",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBFORGOTPWD","Visible")',ctrl:"TBFORGOTPWD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TABLECREATEACCOUNT","Visible")',ctrl:"TABLECREATEACCOUNT",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV22KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""}]];this.EvtParms["'FORGOTPASSWORD'"]=[[{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}]];this.EvtParms["'REGISTER'"]=[[],[]];this.EvtParms["'SELECTAUTHENTICATIONTYPE'"]=[[{av:"AV22KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV26NameAuthType",fld:"vNAMEAUTHTYPE",pic:"",hsh:!0},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""}],[]];this.EnterCtrl=["LOGIN"];this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV16IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV16IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);t.addRefreshingVar({rfrVar:"AV23Language"});t.addRefreshingVar({rfrVar:"AV8AuxUserName"});t.addRefreshingVar({rfrVar:"AV33UserRememberMe"});t.addRefreshingParm({rfrVar:"AV23Language"});t.addRefreshingParm({rfrVar:"AV8AuxUserName"});t.addRefreshingParm({rfrVar:"AV33UserRememberMe"});t.addRefreshingParm(this.GXValidFnc[40]);t.addRefreshingParm(this.GXValidFnc[51]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamexamplelogin)})