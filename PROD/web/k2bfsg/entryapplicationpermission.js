gx.evt.autoSkip=!1;gx.define("k2bfsg.entryapplicationpermission",!1,function(){var n,t,i;this.ServerClass="k2bfsg.entryapplicationpermission";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.entryapplicationpermission.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV7ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",",");this.AV14Id=gx.fn.getControlValue("vID");this.AV15IsOk=gx.fn.getControlValue("vISOK");this.AV17Message=gx.fn.getControlValue("vMESSAGE")};this.Validv_Accesstype=function(){return this.validCliEvt("Validv_Accesstype",0,function(){try{var n=gx.util.balloon.getNew("vACCESSTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV23AccessType,"A")==0||gx.text.compare(this.AV23AccessType,"R")==0))try{n.setError("Field Access Type is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s122_client=function(){};this.s132_client=function(){};this.e11461_client=function(){return this.clearMessages(),this.s152_client(),this.refreshOutputs([{av:"AV14Id",fld:"vID",pic:""},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s152_client=function(){this.call("k2bfsg.entryapplicationpermission.aspx",["UPD",this.AV7ApplicationId,this.AV14Id],null,["Mode","ApplicationId","Id"])};this.e12461_client=function(){return this.clearMessages(),this.s162_client(),this.refreshOutputs([{av:"AV14Id",fld:"vID",pic:""},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s162_client=function(){this.call("k2bfsg.entryapplicationpermission.aspx",["DLT",this.AV7ApplicationId,this.AV14Id],null,["Mode","ApplicationId","Id"])};this.e15462_client=function(){return this.executeServerEvent("'E_CONFIRM'",!1,null,!1,!1)};this.e16462_client=function(){return this.executeServerEvent("'E_CANCEL'",!1,null,!1,!1)};this.e18462_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e19462_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,83,84];this.GXLastCtrlId=84;this.GENERALContainer=gx.uc.getNew(this,22,0,"K2BT_Component","GENERALContainer","General","GENERAL");t=this.GENERALContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Icon","Icon","","str");t.setProp("Title","Title","General","str");t.setProp("TitleClass","Titleclass","TextBlock_Subtitle","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Open","Open",!0,"bool");t.setProp("ShowBorders","Showborders",!0,"bool");t.setDynProp("ContainsEditableForm","Containseditableform",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,85,43,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");i=this.K2BCONTROLBEAUTIFY1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINERSECTION",grid:0};n[7]={id:7,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"CONTENTTABLE",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"COLUMNS",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"COLUMN",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[24]={id:24,fld:"GENERAL_CONTENT",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"ATTRIBUTESCONTAINERTABLE_GENERAL",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"RESPONSIVETABLE_CONTAINERNODE_ACTIONS2",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"ACTIONSCONTAINERTABLERIGHT_ACTIONS2",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"UPDATE",grid:0,evt:"e11461_client"};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"DELETE",grid:0,evt:"e12461_client"};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TABLE_CONTAINER_GUID",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",fmt:0,gxz:"ZV12GUID",gxold:"OV12GUID",gxvar:"AV12GUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12GUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12GUID=n)},v2c:function(){gx.fn.setControlValue("vGUID",gx.O.AV12GUID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12GUID=this.val())},val:function(){return gx.fn.getControlValue("vGUID")},nac:gx.falseFn};this.declareDomainHdlr(43,function(){});n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TABLE_CONTAINER_NAME",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:120,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV21Name",gxold:"OV21Name",gxvar:"AV21Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV21Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TABLE_CONTAINER_DSC",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,lvl:0,type:"char",len:120,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV22Dsc",gxold:"OV22Dsc",gxvar:"AV22Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Dsc=n)},v2c:function(){gx.fn.setControlValue("vDSC",gx.O.AV22Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV22Dsc=this.val())},val:function(){return gx.fn.getControlValue("vDSC")},nac:gx.falseFn};this.declareDomainHdlr(55,function(){});n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"TABLE_CONTAINER_ACCESSTYPE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Accesstype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACCESSTYPE",fmt:0,gxz:"ZV23AccessType",gxold:"OV23AccessType",gxvar:"AV23AccessType",ucs:[],op:[61],ip:[61],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV23AccessType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23AccessType=n)},v2c:function(){gx.fn.setComboBoxValue("vACCESSTYPE",gx.O.AV23AccessType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV23AccessType=this.val())},val:function(){return gx.fn.getControlValue("vACCESSTYPE")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"TABLE_CONTAINER_ISPARENT",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"boolean",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vISPARENT",fmt:0,gxz:"ZV16IsParent",gxold:"OV16IsParent",gxvar:"AV16IsParent",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV16IsParent=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16IsParent=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vISPARENT",gx.O.AV16IsParent,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16IsParent=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vISPARENT")},nac:gx.falseFn,values:["true","false"]};this.declareDomainHdlr(67,function(){});n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"RESPONSIVETABLE_CONTAINERNODE_ACTIONS1",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"ACTIONSCONTAINERTABLELEFT_ACTIONS1",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"CONFIRM",grid:0,evt:"e15462_client"};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"CANCEL",grid:0,evt:"e16462_client"};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"COLUMN1",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};this.AV12GUID="";this.ZV12GUID="";this.OV12GUID="";this.AV21Name="";this.ZV21Name="";this.OV21Name="";this.AV22Dsc="";this.ZV22Dsc="";this.OV22Dsc="";this.AV23AccessType="";this.ZV23AccessType="";this.OV23AccessType="";this.AV16IsParent=!1;this.ZV16IsParent=!1;this.OV16IsParent=!1;this.AV12GUID="";this.AV21Name="";this.AV22Dsc="";this.AV23AccessType="";this.AV16IsParent=!1;this.AV7ApplicationId=0;this.AV14Id="";this.Gx_mode="";this.AV15IsOk=!1;this.AV17Message={Id:"",Type:0,Description:""};this.Events={e15462_client:["'E_CONFIRM'",!0],e16462_client:["'E_CANCEL'",!0],e18462_client:["ENTER",!0],e19462_client:["CANCEL",!0],e11461_client:["'E_UPDATE'",!1],e12461_client:["'E_DELETE'",!1]};this.EvtParms.REFRESH=[[{av:"AV16IsParent",fld:"vISPARENT",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV12GUID",fld:"vGUID",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("UPDATE","Tooltiptext")',ctrl:"UPDATE",prop:"Tooltiptext"},{av:'gx.fn.getCtrlProperty("DELETE","Tooltiptext")',ctrl:"DELETE",prop:"Tooltiptext"}]];this.EvtParms["'E_CONFIRM'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Id",fld:"vID",pic:""},{av:"AV21Name",fld:"vNAME",pic:""},{av:"AV22Dsc",fld:"vDSC",pic:""},{ctrl:"vACCESSTYPE"},{av:"AV23AccessType",fld:"vACCESSTYPE",pic:""},{av:"AV12GUID",fld:"vGUID",pic:"",hsh:!0},{av:"AV15IsOk",fld:"vISOK",pic:""},{av:"AV17Message",fld:"vMESSAGE",pic:""}],[{av:"AV15IsOk",fld:"vISOK",pic:""},{av:"AV17Message",fld:"vMESSAGE",pic:""}]];this.EvtParms["'E_UPDATE'"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Id",fld:"vID",pic:""}],[{av:"AV14Id",fld:"vID",pic:""},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'E_DELETE'"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Id",fld:"vID",pic:""}],[{av:"AV14Id",fld:"vID",pic:""},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'E_CANCEL'"]=[[{av:"AV14Id",fld:"vID",pic:""},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_ACCESSTYPE=[[],[]];this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV14Id","vID",0,"char",40,0);this.setVCMap("AV15IsOk","vISOK",0,"boolean",4,0);this.setVCMap("AV17Message","vMESSAGE",0,"GeneXusCommonMessages.Message",0,0);this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV14Id","vID",0,"char",40,0);this.Initialize();this.setComponent({id:"CHILDREN",GXClass:null,Prefix:"W0082",lvl:1});this.setSDTMapping("GeneXusSecurity\\GAMRole",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRoleFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMUser",{Attributes:{sdt:"GeneXusSecurity\\GAMUserAttribute"}});this.setSDTMapping("K2BActivityList.K2BActivityListItem",{Activity:{sdt:"K2BActivity"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationPermission",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenuOption",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenu",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BTrnContext",{TransactionName:{extr:"Transaction"},CallerUrl:{extr:"CallerUrl"},EntityManagerName:{extr:"EMName"},EntityManagerNextTaskCode:{extr:"NextTaskCode"},EntityManagerNextTaskMode:{extr:"NextTaskMode"},EntityManagerEncryptUrlParameters:{extr:"EncryptUrlParms"},ReturnMode:{extr:"ReturnMode"},SavePK:{extr:"SavePK"},AfterInsert:{sdt:"K2BTrnNavigation"},AfterUpdate:{sdt:"K2BTrnNavigation"},AfterDelete:{sdt:"K2BTrnNavigation"},Attributes:{extr:"Attributes"}})});gx.wi(function(){gx.createParentObj(this.k2bfsg.entryapplicationpermission)})