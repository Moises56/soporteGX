gx.evt.autoSkip=!1;gx.define("gam_myaccount",!1,function(){this.ServerClass="gam_myaccount";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_myaccount.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV30URLProfile=gx.fn.getControlValue("vURLPROFILE")};this.Validv_Datelastauthentication=function(){return this.validCliEvt("Validv_Datelastauthentication",0,function(){try{var n=gx.util.balloon.getNew("vDATELASTAUTHENTICATION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12DateLastAuthentication)===0||new gx.date.gxdate(this.AV12DateLastAuthentication).compare(gx.date.ymdhmstot(1753,1,1,0,0,0))>=0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Date Last Authentication"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Birthday=function(){return this.validCliEvt("Validv_Birthday",0,function(){try{var n=gx.util.balloon.getNew("vBIRTHDAY");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV10Birthday)===0||new gx.date.gxdate(this.AV10Birthday).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Birthday"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gender=function(){return this.validCliEvt("Validv_Gender",0,function(){try{var n=gx.util.balloon.getNew("vGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV21Gender,"N")==0||gx.text.compare(this.AV21Gender,"F")==0||gx.text.compare(this.AV21Gender,"M")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Gender"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s112_client=function(){this.createWebComponent("Wcmessages","GAM_Messages",[])};this.e11391_client=function(){return this.clearMessages(),this.call("gam_myaccount.aspx",["UPD"],null,["Mode"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12391_client=function(){return this.clearMessages(),this.AV31Window.Url=gx.http.formatLink("gam_userchangeidentification.aspx",[gx.getMessage("name")]),this.AV31Window.ReturnParms=[""],this.popupOpen(this.AV31Window),this.call("gam_myaccount.aspx",["DSP"],null,["Mode"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13391_client=function(){return this.clearMessages(),this.AV31Window.Url=gx.http.formatLink("gam_userchangeidentification.aspx",[gx.getMessage("email")]),this.AV31Window.ReturnParms=[""],this.popupOpen(this.AV31Window),this.call("gam_myaccount.aspx",["DSP"],null,["Mode"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15392_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e16392_client=function(){return this.executeServerEvent("'AUTHENTICATORAPP'",!0,null,!1,!1)};this.e18392_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e19391_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,139,140,141,142,143,144,145,146,147,148];this.GXLastCtrlId=148;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBLHEADER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TXTUSER",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",format:0,grid:0,ctrltype:"textblock"};n[14]={id:14,fld:"TOOLBAR_INNER",grid:0};n[15]={id:15,fld:"BTNEDIT",format:0,grid:0,evt:"e11391_client",ctrltype:"textblock"};n[16]={id:16,fld:"BTNTOTPAUTHENTICATOR",format:0,grid:0,evt:"e16392_client",ctrltype:"textblock"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"GAM_DATACARD",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"GAM_DATACARD_TABLEGENERALTITLE",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"GAM_DATACARD_TBTITLEGENERAL",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GAM_DATACARD_TABLEDATAGENERAL",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGE",fmt:0,gxz:"ZV22Image",gxold:"OV22Image",gxvar:"AV22Image",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22Image=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Image=n)},v2c:function(){gx.fn.setMultimediaValue("vIMAGE",gx.O.AV22Image,gx.O.AV34Image_GXI)},c2v:function(){gx.O.AV34Image_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV22Image=this.val())},val:function(){return gx.fn.getBlobValue("vIMAGE")},val_GXI:function(){return gx.fn.getControlValue("vIMAGE_GXI")},gxvar_GXI:"AV34Image_GXI",nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vAUTHENTICATIONTYPENAME",fmt:0,gxz:"ZV7AuthenticationTypeName",gxold:"OV7AuthenticationTypeName",gxvar:"AV7AuthenticationTypeName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV7AuthenticationTypeName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7AuthenticationTypeName=n)},v2c:function(){gx.fn.setComboBoxValue("vAUTHENTICATIONTYPENAME",gx.O.AV7AuthenticationTypeName);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7AuthenticationTypeName=this.val())},val:function(){return gx.fn.getControlValue("vAUTHENTICATIONTYPENAME")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV25Name",gxold:"OV25Name",gxvar:"AV25Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV25Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV25Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV25Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTNCHANGENAME",grid:0,evt:"e12391_client"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV14EMail",gxold:"OV14EMail",gxvar:"AV14EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV14EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNCHANGEEMAIL",grid:0,evt:"e13391_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV18FirstName",gxold:"OV18FirstName",gxvar:"AV18FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV18FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(56,function(){});n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV24LastName",gxold:"OV24LastName",gxvar:"AV24LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV24LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV24LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDONTRECEIVEINFORMATION",fmt:0,gxz:"ZV13DontReceiveInformation",gxold:"OV13DontReceiveInformation",gxvar:"AV13DontReceiveInformation",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV13DontReceiveInformation=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13DontReceiveInformation=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vDONTRECEIVEINFORMATION",gx.O.AV13DontReceiveInformation,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13DontReceiveInformation=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vDONTRECEIVEINFORMATION")},nac:gx.falseFn,values:["true","false"]};this.declareDomainHdlr(66,function(){});n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vENABLETWOFACTORAUTHENTICATION",fmt:0,gxz:"ZV15EnableTwoFactorAuthentication",gxold:"OV15EnableTwoFactorAuthentication",gxvar:"AV15EnableTwoFactorAuthentication",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV15EnableTwoFactorAuthentication=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15EnableTwoFactorAuthentication=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vENABLETWOFACTORAUTHENTICATION",gx.O.AV15EnableTwoFactorAuthentication,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15EnableTwoFactorAuthentication=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vENABLETWOFACTORAUTHENTICATION")},nac:gx.falseFn,values:["true","false"]};this.declareDomainHdlr(71,function(){});n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"LASTAUTHCELL",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"dtime",len:8,dec:5,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Datelastauthentication,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDATELASTAUTHENTICATION",fmt:0,gxz:"ZV12DateLastAuthentication",gxold:"OV12DateLastAuthentication",gxvar:"AV12DateLastAuthentication",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[76],ip:[76],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12DateLastAuthentication=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12DateLastAuthentication=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vDATELASTAUTHENTICATION",gx.O.AV12DateLastAuthentication,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12DateLastAuthentication=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("vDATELASTAUTHENTICATION")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"RIGHTTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"STENCIL1",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"STENCIL1_TABLEGENERALTITLE",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"STENCIL1_TBTITLEGENERAL",format:0,grid:0,ctrltype:"textblock"};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"STENCIL1_TABLEDATAGENERAL",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Birthday,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBIRTHDAY",fmt:0,gxz:"ZV10Birthday",gxold:"OV10Birthday",gxvar:"AV10Birthday",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[95],ip:[95],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10Birthday=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10Birthday=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vBIRTHDAY",gx.O.AV10Birthday,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10Birthday=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vBIRTHDAY")},nac:gx.falseFn};this.declareDomainHdlr(95,function(){});n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"",grid:0};n[100]={id:100,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Gender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENDER",fmt:0,gxz:"ZV21Gender",gxold:"OV21Gender",gxvar:"AV21Gender",ucs:[],op:[100],ip:[100],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV21Gender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21Gender=n)},v2c:function(){gx.fn.setComboBoxValue("vGENDER",gx.O.AV21Gender);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21Gender=this.val())},val:function(){return gx.fn.getControlValue("vGENDER")},nac:gx.falseFn};this.declareDomainHdlr(100,function(){});n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"",grid:0};n[105]={id:105,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPHONE",fmt:0,gxz:"ZV26Phone",gxold:"OV26Phone",gxvar:"AV26Phone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26Phone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26Phone=n)},v2c:function(){gx.fn.setControlValue("vPHONE",gx.O.AV26Phone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV26Phone=this.val())},val:function(){return gx.fn.getControlValue("vPHONE")},nac:gx.falseFn};this.declareDomainHdlr(105,function(){});n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"",grid:0};n[109]={id:109,fld:"",grid:0};n[110]={id:110,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vADDRESS",fmt:0,gxz:"ZV5Address",gxold:"OV5Address",gxvar:"AV5Address",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Address=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Address=n)},v2c:function(){gx.fn.setControlValue("vADDRESS",gx.O.AV5Address,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Address=this.val())},val:function(){return gx.fn.getControlValue("vADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(110,function(){});n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[113]={id:113,fld:"",grid:0};n[114]={id:114,fld:"",grid:0};n[115]={id:115,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vADDRESS2",fmt:0,gxz:"ZV6Address2",gxold:"OV6Address2",gxvar:"AV6Address2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6Address2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6Address2=n)},v2c:function(){gx.fn.setControlValue("vADDRESS2",gx.O.AV6Address2,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6Address2=this.val())},val:function(){return gx.fn.getControlValue("vADDRESS2")},nac:gx.falseFn};this.declareDomainHdlr(115,function(){});n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[118]={id:118,fld:"",grid:0};n[119]={id:119,fld:"",grid:0};n[120]={id:120,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCITY",fmt:0,gxz:"ZV11City",gxold:"OV11City",gxvar:"AV11City",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11City=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11City=n)},v2c:function(){gx.fn.setControlValue("vCITY",gx.O.AV11City,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11City=this.val())},val:function(){return gx.fn.getControlValue("vCITY")},nac:gx.falseFn};this.declareDomainHdlr(120,function(){});n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"",grid:0};n[123]={id:123,fld:"",grid:0};n[124]={id:124,fld:"",grid:0};n[125]={id:125,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATE",fmt:0,gxz:"ZV28State",gxold:"OV28State",gxvar:"AV28State",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28State=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28State=n)},v2c:function(){gx.fn.setControlValue("vSTATE",gx.O.AV28State,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28State=this.val())},val:function(){return gx.fn.getControlValue("vSTATE")},nac:gx.falseFn};this.declareDomainHdlr(125,function(){});n[126]={id:126,fld:"",grid:0};n[127]={id:127,fld:"",grid:0};n[128]={id:128,fld:"",grid:0};n[129]={id:129,fld:"",grid:0};n[130]={id:130,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLANGUAGE",fmt:0,gxz:"ZV23Language",gxold:"OV23Language",gxvar:"AV23Language",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23Language=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23Language=n)},v2c:function(){gx.fn.setControlValue("vLANGUAGE",gx.O.AV23Language,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV23Language=this.val())},val:function(){return gx.fn.getControlValue("vLANGUAGE")},nac:gx.falseFn};this.declareDomainHdlr(130,function(){});n[131]={id:131,fld:"",grid:0};n[132]={id:132,fld:"",grid:0};n[133]={id:133,fld:"",grid:0};n[134]={id:134,fld:"",grid:0};n[135]={id:135,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIMEZONE",fmt:0,gxz:"ZV29Timezone",gxold:"OV29Timezone",gxvar:"AV29Timezone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29Timezone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29Timezone=n)},v2c:function(){gx.fn.setControlValue("vTIMEZONE",gx.O.AV29Timezone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29Timezone=this.val())},val:function(){return gx.fn.getControlValue("vTIMEZONE")},nac:gx.falseFn};this.declareDomainHdlr(135,function(){});n[136]={id:136,fld:"",grid:0};n[137]={id:137,fld:"",grid:0};n[139]={id:139,fld:"",grid:0};n[140]={id:140,fld:"",grid:0};n[141]={id:141,fld:"GAM_FOOTERENTRY",grid:0};n[142]={id:142,fld:"",grid:0};n[143]={id:143,fld:"",grid:0};n[144]={id:144,fld:"GAM_FOOTERENTRY_TABLEBUTTONS",grid:0};n[145]={id:145,fld:"",grid:0};n[146]={id:146,fld:"GAM_FOOTERENTRY_BTNCANCEL",grid:0,evt:"e19391_client"};n[147]={id:147,fld:"",grid:0};n[148]={id:148,fld:"GAM_FOOTERENTRY_BTNCONFIRM",grid:0,evt:"e15392_client"};this.AV34Image_GXI="";this.AV22Image="";this.ZV22Image="";this.OV22Image="";this.AV7AuthenticationTypeName="";this.ZV7AuthenticationTypeName="";this.OV7AuthenticationTypeName="";this.AV25Name="";this.ZV25Name="";this.OV25Name="";this.AV14EMail="";this.ZV14EMail="";this.OV14EMail="";this.AV18FirstName="";this.ZV18FirstName="";this.OV18FirstName="";this.AV24LastName="";this.ZV24LastName="";this.OV24LastName="";this.AV13DontReceiveInformation=!1;this.ZV13DontReceiveInformation=!1;this.OV13DontReceiveInformation=!1;this.AV15EnableTwoFactorAuthentication=!1;this.ZV15EnableTwoFactorAuthentication=!1;this.OV15EnableTwoFactorAuthentication=!1;this.AV12DateLastAuthentication=gx.date.nullDate();this.ZV12DateLastAuthentication=gx.date.nullDate();this.OV12DateLastAuthentication=gx.date.nullDate();this.AV10Birthday=gx.date.nullDate();this.ZV10Birthday=gx.date.nullDate();this.OV10Birthday=gx.date.nullDate();this.AV21Gender="";this.ZV21Gender="";this.OV21Gender="";this.AV26Phone="";this.ZV26Phone="";this.OV26Phone="";this.AV5Address="";this.ZV5Address="";this.OV5Address="";this.AV6Address2="";this.ZV6Address2="";this.OV6Address2="";this.AV11City="";this.ZV11City="";this.OV11City="";this.AV28State="";this.ZV28State="";this.OV28State="";this.AV23Language="";this.ZV23Language="";this.OV23Language="";this.AV29Timezone="";this.ZV29Timezone="";this.OV29Timezone="";this.AV22Image="";this.AV7AuthenticationTypeName="";this.AV25Name="";this.AV14EMail="";this.AV18FirstName="";this.AV24LastName="";this.AV13DontReceiveInformation=!1;this.AV15EnableTwoFactorAuthentication=!1;this.AV12DateLastAuthentication=gx.date.nullDate();this.AV10Birthday=gx.date.nullDate();this.AV21Gender="";this.AV26Phone="";this.AV5Address="";this.AV6Address2="";this.AV11City="";this.AV28State="";this.AV23Language="";this.AV29Timezone="";this.Gx_mode="";this.AV30URLProfile="";this.AV31Window={};this.Events={e15392_client:["'CONFIRM'",!0],e16392_client:["'AUTHENTICATORAPP'",!0],e18392_client:["ENTER",!0],e19391_client:["CANCEL",!0],e11391_client:["'EDIT'",!1],e12391_client:["'CHANGENAME'",!1],e13391_client:["'CHANGEEMAIL'",!1]};this.EvtParms.REFRESH=[[{av:"AV13DontReceiveInformation",fld:"vDONTRECEIVEINFORMATION",pic:""},{av:"AV15EnableTwoFactorAuthentication",fld:"vENABLETWOFACTORAUTHENTICATION",pic:""},{av:"AV30URLProfile",fld:"vURLPROFILE",pic:"",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{ctrl:"vAUTHENTICATIONTYPENAME"},{av:"AV7AuthenticationTypeName",fld:"vAUTHENTICATIONTYPENAME",pic:"",hsh:!0},{av:"AV25Name",fld:"vNAME",pic:"",hsh:!0},{av:"AV14EMail",fld:"vEMAIL",pic:"",hsh:!0}],[]];this.EvtParms["'CONFIRM'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{ctrl:"vAUTHENTICATIONTYPENAME"},{av:"AV7AuthenticationTypeName",fld:"vAUTHENTICATIONTYPENAME",pic:"",hsh:!0},{av:"AV25Name",fld:"vNAME",pic:"",hsh:!0},{av:"AV14EMail",fld:"vEMAIL",pic:"",hsh:!0},{av:"AV18FirstName",fld:"vFIRSTNAME",pic:""},{av:"AV24LastName",fld:"vLASTNAME",pic:""},{av:"AV10Birthday",fld:"vBIRTHDAY",pic:""},{ctrl:"vGENDER"},{av:"AV21Gender",fld:"vGENDER",pic:""},{av:"AV26Phone",fld:"vPHONE",pic:""},{av:"AV5Address",fld:"vADDRESS",pic:""},{av:"AV6Address2",fld:"vADDRESS2",pic:""},{av:"AV11City",fld:"vCITY",pic:""},{av:"AV28State",fld:"vSTATE",pic:""},{av:"AV23Language",fld:"vLANGUAGE",pic:""},{av:"AV29Timezone",fld:"vTIMEZONE",pic:""},{av:"AV30URLProfile",fld:"vURLPROFILE",pic:"",hsh:!0},{av:"AV13DontReceiveInformation",fld:"vDONTRECEIVEINFORMATION",pic:""},{av:"AV15EnableTwoFactorAuthentication",fld:"vENABLETWOFACTORAUTHENTICATION",pic:""}],[{av:'gx.fn.getCtrlProperty("GAM_FOOTERENTRY","Visible")',ctrl:"GAM_FOOTERENTRY",prop:"Visible"}]];this.EvtParms["'EDIT'"]=[[],[]];this.EvtParms["'CHANGENAME'"]=[[],[]];this.EvtParms["'CHANGEEMAIL'"]=[[],[]];this.EvtParms["'AUTHENTICATORAPP'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_DATELASTAUTHENTICATION=[[],[]];this.EvtParms.VALIDV_BIRTHDAY=[[],[]];this.EvtParms.VALIDV_GENDER=[[],[]];this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV30URLProfile","vURLPROFILE",0,"svchar",2048,250);this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0138",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_myaccount)})