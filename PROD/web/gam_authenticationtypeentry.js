gx.evt.autoSkip=!1;gx.define("gam_authenticationtypeentry",!1,function(){this.ServerClass="gam_authenticationtypeentry";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_authenticationtypeentry.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV5Name=gx.fn.getControlValue("vNAME");this.AV6TypeId=gx.fn.getControlValue("vTYPEID");this.Gx_mode=gx.fn.getControlValue("vMODE")};this.e120f1_client=function(){return this.clearMessages(),this.call("gam_authenticationtypeentry.aspx",["DLT",this.AV5Name,this.AV6TypeId],null,["Mode","Name","TypeId"]),this.refreshOutputs([{av:"AV6TypeId",fld:"vTYPEID",pic:""},{av:"AV5Name",fld:"vNAME",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110f1_client=function(){return this.clearMessages(),this.call("gam_authenticationtypeentry.aspx",["UPD",this.AV5Name,this.AV6TypeId],null,["Mode","Name","TypeId"]),this.refreshOutputs([{av:"AV6TypeId",fld:"vTYPEID",pic:""},{av:"AV5Name",fld:"vNAME",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150f1_client=function(){return this.clearMessages(),this.call("gam_wwauthtypes.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e170f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERENTRY",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERENTRY_TBLBACKCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GAM_HEADERENTRY_TABLEBACK",grid:0,evt:"e150f1_client"};n[15]={id:15,fld:"GAM_HEADERENTRY_TXTBACK",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_HEADERENTRY_TABLETITLEACTIONS",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"GAM_HEADERENTRY_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"GAM_HEADERENTRY_TXTSTATUS",format:0,grid:0,ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GAM_HEADERENTRY_TBLTOOLBARS",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",format:0,grid:0,ctrltype:"textblock"};n[29]={id:29,fld:"GAM_HEADERENTRY_BUTTONSTOOLBAR_INNER",grid:0};n[30]={id:30,fld:"BUTTONEDIT",format:0,grid:0,evt:"e110f1_client",ctrltype:"textblock"};n[31]={id:31,fld:"BUTTONDELETE",format:0,grid:0,evt:"e120f1_client",ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"GAM_HEADERENTRY_MENUTABLE",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};this.AV5Name="";this.AV6TypeId="";this.Gx_mode="";this.Events={e160f2_client:["ENTER",!0],e170f2_client:["CANCEL",!0],e120f1_client:["'DELETE'",!1],e110f1_client:["'EDIT'",!1],e150f1_client:["GAM_HEADERENTRY_TABLEBACK.CLICK",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DELETE'"]=[[{av:"AV5Name",fld:"vNAME",pic:""},{av:"AV6TypeId",fld:"vTYPEID",pic:""}],[{av:"AV6TypeId",fld:"vTYPEID",pic:""},{av:"AV5Name",fld:"vNAME",pic:""}]];this.EvtParms["'EDIT'"]=[[{av:"AV5Name",fld:"vNAME",pic:""},{av:"AV6TypeId",fld:"vTYPEID",pic:""}],[{av:"AV6TypeId",fld:"vTYPEID",pic:""},{av:"AV5Name",fld:"vNAME",pic:""}]];this.EvtParms["GAM_HEADERENTRY_TABLEBACK.CLICK"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV5Name","vNAME",0,"char",254,0);this.setVCMap("AV6TypeId","vTYPEID",0,"char",30,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV6TypeId","vTYPEID",0,"char",30,0);this.setVCMap("AV5Name","vNAME",0,"char",254,0);this.Initialize();this.setComponent({id:"WCENTRYPANEL",GXClass:null,Prefix:"W0037",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_authenticationtypeentry)})