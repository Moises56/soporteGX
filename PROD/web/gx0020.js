gx.evt.autoSkip=!1;gx.define("gx0020",!1,function(){var n,t;this.ServerClass="gx0020";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0020.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV11psoporteID=gx.fn.getIntegerValue("vPSOPORTEID",",")};this.e18051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("SOPORTEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SOPORTEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSOPORTEID","Visible",!0)):(gx.fn.setCtrlProperty("SOPORTEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSOPORTEID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SOPORTEIDFILTERCONTAINER","Class")',ctrl:"SOPORTEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSOPORTEID","Visible")',ctrl:"vCSOPORTEID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("HOSTNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("HOSTNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCHOSTNAME","Visible",!0)):(gx.fn.setCtrlProperty("HOSTNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCHOSTNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("HOSTNAMEFILTERCONTAINER","Class")',ctrl:"HOSTNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCHOSTNAME","Visible")',ctrl:"vCHOSTNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("SERIEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SERIEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSERIE","Visible",!0)):(gx.fn.setCtrlProperty("SERIEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSERIE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SERIEFILTERCONTAINER","Class")',ctrl:"SERIEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSERIE","Visible")',ctrl:"vCSERIE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IPV4FILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IPV4FILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIPV4","Visible",!0)):(gx.fn.setCtrlProperty("IPV4FILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIPV4","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IPV4FILTERCONTAINER","Class")',ctrl:"IPV4FILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIPV4","Visible")',ctrl:"vCIPV4",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("MACFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("MACFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCMAC","Visible",!0)):(gx.fn.setCtrlProperty("MACFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCMAC","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MACFILTERCONTAINER","Class")',ctrl:"MACFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMAC","Visible")',ctrl:"vCMAC",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("MODELOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("MODELOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCMODELO","Visible",!0)):(gx.fn.setCtrlProperty("MODELOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCMODELO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MODELOFILTERCONTAINER","Class")',ctrl:"MODELOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMODELO","Visible")',ctrl:"vCMODELO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17051_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCNOMBREUSUARIO","Visible",!0)):(gx.fn.setCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCNOMBREUSUARIO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class")',ctrl:"NOMBREUSUARIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCNOMBREUSUARIO","Visible")',ctrl:"vCNOMBREUSUARIO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e21052_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e22051_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91];this.GXLastCtrlId=91;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0020",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(4,86,"SOPORTEID","ID","","soporteID","int",0,"px",9,9,"end",null,[],4,"soporteID",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(5,87,"HOSTNAME","Name","","hostName","svchar",0,"px",40,40,"start",null,[],5,"hostName",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(9,88,"SERIE","serie","","serie","svchar",0,"px",40,40,"start",null,[],9,"serie",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"SOPORTEIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLSOPORTEIDFILTER",format:1,grid:0,evt:"e11051_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSOPORTEID",fmt:0,gxz:"ZV6csoporteID",gxold:"OV6csoporteID",gxvar:"AV6csoporteID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6csoporteID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6csoporteID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCSOPORTEID",gx.O.AV6csoporteID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6csoporteID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCSOPORTEID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"HOSTNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLHOSTNAMEFILTER",format:1,grid:0,evt:"e12051_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCHOSTNAME",fmt:0,gxz:"ZV7chostName",gxold:"OV7chostName",gxvar:"AV7chostName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7chostName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7chostName=n)},v2c:function(){gx.fn.setControlValue("vCHOSTNAME",gx.O.AV7chostName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7chostName=this.val())},val:function(){return gx.fn.getControlValue("vCHOSTNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"SERIEFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLSERIEFILTER",format:1,grid:0,evt:"e13051_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSERIE",fmt:0,gxz:"ZV13cserie",gxold:"OV13cserie",gxvar:"AV13cserie",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13cserie=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13cserie=n)},v2c:function(){gx.fn.setControlValue("vCSERIE",gx.O.AV13cserie,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13cserie=this.val())},val:function(){return gx.fn.getControlValue("vCSERIE")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"IPV4FILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLIPV4FILTER",format:1,grid:0,evt:"e14051_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIPV4",fmt:0,gxz:"ZV14cipv4",gxold:"OV14cipv4",gxvar:"AV14cipv4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14cipv4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14cipv4=n)},v2c:function(){gx.fn.setControlValue("vCIPV4",gx.O.AV14cipv4,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14cipv4=this.val())},val:function(){return gx.fn.getControlValue("vCIPV4")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"MACFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLMACFILTER",format:1,grid:0,evt:"e15051_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCMAC",fmt:0,gxz:"ZV15cmac",gxold:"OV15cmac",gxvar:"AV15cmac",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15cmac=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15cmac=n)},v2c:function(){gx.fn.setControlValue("vCMAC",gx.O.AV15cmac,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15cmac=this.val())},val:function(){return gx.fn.getControlValue("vCMAC")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"MODELOFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLMODELOFILTER",format:1,grid:0,evt:"e16051_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCMODELO",fmt:0,gxz:"ZV16cmodelo",gxold:"OV16cmodelo",gxvar:"AV16cmodelo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16cmodelo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16cmodelo=n)},v2c:function(){gx.fn.setControlValue("vCMODELO",gx.O.AV16cmodelo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16cmodelo=this.val())},val:function(){return gx.fn.getControlValue("vCMODELO")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"NOMBREUSUARIOFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLNOMBREUSUARIOFILTER",format:1,grid:0,evt:"e17051_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCNOMBREUSUARIO",fmt:0,gxz:"ZV17cnombreUsuario",gxold:"OV17cnombreUsuario",gxvar:"AV17cnombreUsuario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17cnombreUsuario=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17cnombreUsuario=n)},v2c:function(){gx.fn.setControlValue("vCNOMBREUSUARIO",gx.O.AV17cnombreUsuario,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17cnombreUsuario=this.val())},val:function(){return gx.fn.getControlValue("vCNOMBREUSUARIO")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e18051_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV18Linkselection_GXI)},c2v:function(n){gx.O.AV18Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV18Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SOPORTEID",fmt:0,gxz:"Z4soporteID",gxold:"O4soporteID",gxvar:"A4soporteID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4soporteID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4soporteID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SOPORTEID",n||gx.fn.currentGridRowImpl(84),gx.O.A4soporteID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4soporteID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SOPORTEID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HOSTNAME",fmt:0,gxz:"Z5hostName",gxold:"O5hostName",gxvar:"A5hostName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5hostName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5hostName=n)},v2c:function(n){gx.fn.setGridControlValue("HOSTNAME",n||gx.fn.currentGridRowImpl(84),gx.O.A5hostName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5hostName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HOSTNAME",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SERIE",fmt:0,gxz:"Z9serie",gxold:"O9serie",gxvar:"A9serie",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A9serie=n)},v2z:function(n){n!==undefined&&(gx.O.Z9serie=n)},v2c:function(n){gx.fn.setGridControlValue("SERIE",n||gx.fn.currentGridRowImpl(84),gx.O.A9serie,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A9serie=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SERIE",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTN_CANCEL",grid:0,evt:"e22051_client"};this.AV6csoporteID=0;this.ZV6csoporteID=0;this.OV6csoporteID=0;this.AV7chostName="";this.ZV7chostName="";this.OV7chostName="";this.AV13cserie="";this.ZV13cserie="";this.OV13cserie="";this.AV14cipv4="";this.ZV14cipv4="";this.OV14cipv4="";this.AV15cmac="";this.ZV15cmac="";this.OV15cmac="";this.AV16cmodelo="";this.ZV16cmodelo="";this.OV16cmodelo="";this.AV17cnombreUsuario="";this.ZV17cnombreUsuario="";this.OV17cnombreUsuario="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z4soporteID=0;this.O4soporteID=0;this.Z5hostName="";this.O5hostName="";this.Z9serie="";this.O9serie="";this.AV6csoporteID=0;this.AV7chostName="";this.AV13cserie="";this.AV14cipv4="";this.AV15cmac="";this.AV16cmodelo="";this.AV17cnombreUsuario="";this.AV11psoporteID=0;this.A10ipv4="";this.A11mac="";this.A12modelo="";this.A13nombreUsuario="";this.AV5LinkSelection="";this.A4soporteID=0;this.A5hostName="";this.A9serie="";this.Events={e21052_client:["ENTER",!0],e22051_client:["CANCEL",!0],e18051_client:["'TOGGLE'",!1],e11051_client:["LBLSOPORTEIDFILTER.CLICK",!1],e12051_client:["LBLHOSTNAMEFILTER.CLICK",!1],e13051_client:["LBLSERIEFILTER.CLICK",!1],e14051_client:["LBLIPV4FILTER.CLICK",!1],e15051_client:["LBLMACFILTER.CLICK",!1],e16051_client:["LBLMODELOFILTER.CLICK",!1],e17051_client:["LBLNOMBREUSUARIOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6csoporteID",fld:"vCSOPORTEID",pic:"ZZZZZZZZ9"},{av:"AV7chostName",fld:"vCHOSTNAME",pic:""},{av:"AV13cserie",fld:"vCSERIE",pic:""},{av:"AV14cipv4",fld:"vCIPV4",pic:""},{av:"AV15cmac",fld:"vCMAC",pic:""},{av:"AV16cmodelo",fld:"vCMODELO",pic:""},{av:"AV17cnombreUsuario",fld:"vCNOMBREUSUARIO",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLSOPORTEIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("SOPORTEIDFILTERCONTAINER","Class")',ctrl:"SOPORTEIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("SOPORTEIDFILTERCONTAINER","Class")',ctrl:"SOPORTEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSOPORTEID","Visible")',ctrl:"vCSOPORTEID",prop:"Visible"}]];this.EvtParms["LBLHOSTNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("HOSTNAMEFILTERCONTAINER","Class")',ctrl:"HOSTNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("HOSTNAMEFILTERCONTAINER","Class")',ctrl:"HOSTNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCHOSTNAME","Visible")',ctrl:"vCHOSTNAME",prop:"Visible"}]];this.EvtParms["LBLSERIEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("SERIEFILTERCONTAINER","Class")',ctrl:"SERIEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("SERIEFILTERCONTAINER","Class")',ctrl:"SERIEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSERIE","Visible")',ctrl:"vCSERIE",prop:"Visible"}]];this.EvtParms["LBLIPV4FILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IPV4FILTERCONTAINER","Class")',ctrl:"IPV4FILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IPV4FILTERCONTAINER","Class")',ctrl:"IPV4FILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIPV4","Visible")',ctrl:"vCIPV4",prop:"Visible"}]];this.EvtParms["LBLMACFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("MACFILTERCONTAINER","Class")',ctrl:"MACFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("MACFILTERCONTAINER","Class")',ctrl:"MACFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMAC","Visible")',ctrl:"vCMAC",prop:"Visible"}]];this.EvtParms["LBLMODELOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("MODELOFILTERCONTAINER","Class")',ctrl:"MODELOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("MODELOFILTERCONTAINER","Class")',ctrl:"MODELOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMODELO","Visible")',ctrl:"vCMODELO",prop:"Visible"}]];this.EvtParms["LBLNOMBREUSUARIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class")',ctrl:"NOMBREUSUARIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("NOMBREUSUARIOFILTERCONTAINER","Class")',ctrl:"NOMBREUSUARIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCNOMBREUSUARIO","Visible")',ctrl:"vCNOMBREUSUARIO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A4soporteID",fld:"SOPORTEID",pic:"ZZZZZZZZ9",hsh:!0}],[{av:"AV11psoporteID",fld:"vPSOPORTEID",pic:"ZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6csoporteID",fld:"vCSOPORTEID",pic:"ZZZZZZZZ9"},{av:"AV7chostName",fld:"vCHOSTNAME",pic:""},{av:"AV13cserie",fld:"vCSERIE",pic:""},{av:"AV14cipv4",fld:"vCIPV4",pic:""},{av:"AV15cmac",fld:"vCMAC",pic:""},{av:"AV16cmodelo",fld:"vCMODELO",pic:""},{av:"AV17cnombreUsuario",fld:"vCNOMBREUSUARIO",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6csoporteID",fld:"vCSOPORTEID",pic:"ZZZZZZZZ9"},{av:"AV7chostName",fld:"vCHOSTNAME",pic:""},{av:"AV13cserie",fld:"vCSERIE",pic:""},{av:"AV14cipv4",fld:"vCIPV4",pic:""},{av:"AV15cmac",fld:"vCMAC",pic:""},{av:"AV16cmodelo",fld:"vCMODELO",pic:""},{av:"AV17cnombreUsuario",fld:"vCNOMBREUSUARIO",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6csoporteID",fld:"vCSOPORTEID",pic:"ZZZZZZZZ9"},{av:"AV7chostName",fld:"vCHOSTNAME",pic:""},{av:"AV13cserie",fld:"vCSERIE",pic:""},{av:"AV14cipv4",fld:"vCIPV4",pic:""},{av:"AV15cmac",fld:"vCMAC",pic:""},{av:"AV16cmodelo",fld:"vCMODELO",pic:""},{av:"AV17cnombreUsuario",fld:"vCNOMBREUSUARIO",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6csoporteID",fld:"vCSOPORTEID",pic:"ZZZZZZZZ9"},{av:"AV7chostName",fld:"vCHOSTNAME",pic:""},{av:"AV13cserie",fld:"vCSERIE",pic:""},{av:"AV14cipv4",fld:"vCIPV4",pic:""},{av:"AV15cmac",fld:"vCMAC",pic:""},{av:"AV16cmodelo",fld:"vCMODELO",pic:""},{av:"AV17cnombreUsuario",fld:"vCNOMBREUSUARIO",pic:""}],[]];this.setVCMap("AV11psoporteID","vPSOPORTEID",0,"int",9,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0020)})