gx.evt.autoSkip=!1;gx.define("k2bfsg.wwsecuritypolicy",!1,function(){var n,t,i;this.ServerClass="k2bfsg.wwsecuritypolicy";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.wwsecuritypolicy.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV7CurrentPage_Grid=gx.fn.getIntegerValue("vCURRENTPAGE_GRID",gx.thousandSeparator);this.AV35GenericFilter_PreviousValue_Grid=gx.fn.getControlValue("vGENERICFILTER_PREVIOUSVALUE_GRID");this.AV33ClassCollection_Grid=gx.fn.getControlValue("vCLASSCOLLECTION_GRID");this.AV37Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV32GridConfiguration=gx.fn.getControlValue("vGRIDCONFIGURATION");this.AV14HasNextPage_Grid=gx.fn.getControlValue("vHASNEXTPAGE_GRID");this.AV26RowsPerPage_Grid=gx.fn.getIntegerValue("vROWSPERPAGE_GRID",gx.thousandSeparator);this.AV16I_LoadCount_Grid=gx.fn.getIntegerValue("vI_LOADCOUNT_GRID",gx.thousandSeparator);this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",gx.thousandSeparator)};this.s112_client=function(){};this.s142_client=function(){this.s252_client()};this.s252_client=function(){gx.fn.setCtrlProperty("NEW","Visible",!0)};this.s162_client=function(){};this.e123e1_client=function(){return this.clearMessages(),this.s172_client(),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s172_client=function(){this.call("k2bfsg.entrysecuritypolicy.aspx",["INS",this.AV17Id],null,["Mode","Id"])};this.e133e1_client=function(){return this.clearMessages(),this.AV7CurrentPage_Grid>1&&(this.AV7CurrentPage_Grid=gx.num.trunc(this.AV7CurrentPage_Grid-1,0)),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e153e1_client=function(){return this.clearMessages(),this.AV14HasNextPage_Grid&&(this.AV7CurrentPage_Grid=gx.num.trunc(this.AV7CurrentPage_Grid+1,0)),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e213e2_client=function(){return this.clearMessages(),this.s182_client(),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s182_client=function(){this.call("k2bfsg.entrysecuritypolicy.aspx",["UPD",this.AV17Id],null,["Mode","Id"])};this.e223e2_client=function(){return this.clearMessages(),this.s192_client(),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.s192_client=function(){this.call("k2bfsg.entrysecuritypolicy.aspx",["DLT",this.AV17Id],null,["Mode","Id"])};this.s212_client=function(){};this.s222_client=function(){gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption","1");gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV7CurrentPage_Grid-1,10,0));gx.fn.setCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV7CurrentPage_Grid,4,0));gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV7CurrentPage_Grid+1,10,0));gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal");gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal");0==this.AV7CurrentPage_Grid||this.AV7CurrentPage_Grid<=1?(gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationDisabled"),gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible",!0),this.AV7CurrentPage_Grid==2?(gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!0),this.AV7CurrentPage_Grid==3?gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1):gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!0)));this.AV14HasNextPage_Grid==!1?(gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal_Disabled"),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible",!0),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible",!0));this.AV7CurrentPage_Grid<=1&&this.AV14HasNextPage_Grid==!1?gx.fn.setCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible",!1):gx.fn.setCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible",!0)};this.e143e1_client=function(){return this.clearMessages(),this.AV7CurrentPage_Grid=gx.num.trunc(1,0),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e113e1_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible")==!1?(this.AV27GridSettingsRowsPerPage_Grid=gx.num.trunc(this.AV26RowsPerPage_Grid,0),gx.fn.setCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible",!0)):gx.fn.setCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible",!1),this.refreshOutputs([{ctrl:"vGRIDSETTINGSROWSPERPAGE_GRID"},{av:"AV27GridSettingsRowsPerPage_Grid",fld:"vGRIDSETTINGSROWSPERPAGE_GRID",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible")',ctrl:"GRIDSETTINGS_CONTENTOUTERTABLEGRID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e163e2_client=function(){return this.executeServerEvent("'SAVEGRIDSETTINGS(GRID)'",!1,null,!1,!1)};this.e233e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e243e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,84,85,86,87,88,89,90,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108];this.GXLastCtrlId=108;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",83,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"k2bfsg.wwsecuritypolicy",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit("Name",84,"vNAME",gx.getMessage("K2BT_GAM_Name"),"","Name","char",0,"px",60,60,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn");t.addSingleLineEdit("Id",85,"vID",gx.getMessage("K2BT_GAM_Id"),"","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn InvisibleInExtraSmallColumn");t.addBitmap("&Update_action","vUPDATE_ACTION",86,20,"px",17,"px","e213e2_client","","","Image_Action","K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover");t.addBitmap("&Delete_action","vDELETE_ACTION",87,20,"px",17,"px","e223e2_client","","","Image_Action","K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(t);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,109,35,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");i=this.K2BCONTROLBEAUTIFY1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINERSECTION",grid:0};n[7]={id:7,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"CONTENTTABLE",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"GRIDCOMPONENTCONTENT_GRID",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"LAYOUTDEFINED_GRID_INNER_GRID",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LAYOUTDEFINED_TABLE10_GRID",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID",grid:0};n[25]={id:25,fld:"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"LAYOUTDEFINED_TABLE9_GRID",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LAYOUTDEFINED_TABLE8_GRID",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENERICFILTER_GRID",fmt:0,gxz:"ZV31GenericFilter_Grid",gxold:"OV31GenericFilter_Grid",gxvar:"AV31GenericFilter_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31GenericFilter_Grid=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31GenericFilter_Grid=n)},v2c:function(){gx.fn.setControlValue("vGENERICFILTER_GRID",gx.O.AV31GenericFilter_Grid,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV31GenericFilter_Grid=this.val())},val:function(){return gx.fn.getControlValue("vGENERICFILTER_GRID")},nac:gx.falseFn};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"LAYOUTDEFINED_TABLE7_GRID",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"GRIDSETTINGS_GLOBALTABLE_GRID",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"GRIDSETTINGS_LABELGRID",grid:0,evt:"e113e1_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"GRIDSETTINGS_CONTENTOUTERTABLEGRID",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"GRIDCUSTOMIZATIONCONTAINER_GRID",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB",format:0,grid:0,ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"ROWSPERPAGECONTAINER_GRID",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDSETTINGSROWSPERPAGE_GRID",fmt:0,gxz:"ZV27GridSettingsRowsPerPage_Grid",gxold:"OV27GridSettingsRowsPerPage_Grid",gxvar:"AV27GridSettingsRowsPerPage_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV27GridSettingsRowsPerPage_Grid=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV27GridSettingsRowsPerPage_Grid=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vGRIDSETTINGSROWSPERPAGE_GRID",gx.O.AV27GridSettingsRowsPerPage_Grid)},c2v:function(){this.val()!==undefined&&(gx.O.AV27GridSettingsRowsPerPage_Grid=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vGRIDSETTINGSROWSPERPAGE_GRID",gx.thousandSeparator)},nac:gx.falseFn};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"FREEZECOLUMNTITLESCONTAINER_GRID",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFREEZECOLUMNTITLES_GRID",fmt:0,gxz:"ZV34FreezeColumnTitles_Grid",gxold:"OV34FreezeColumnTitles_Grid",gxvar:"AV34FreezeColumnTitles_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV34FreezeColumnTitles_Grid=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV34FreezeColumnTitles_Grid=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vFREEZECOLUMNTITLES_GRID",gx.O.AV34FreezeColumnTitles_Grid,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV34FreezeColumnTitles_Grid=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vFREEZECOLUMNTITLES_GRID")},nac:gx.falseFn,values:["true","false"]};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"GRIDSETTINGS_SAVEGRID",grid:0,evt:"e163e2_client"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"ACTIONS_GRID_TOPRIGHT",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"NEW",grid:0,evt:"e123e1_client"};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"LAYOUTDEFINED_TABLE3_GRID",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"MAINGRID_RESPONSIVETABLE_GRID",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[84]={id:84,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:83,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV19Name",gxold:"OV19Name",gxvar:"AV19Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV19Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(83),gx.O.AV19Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV19Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(83))},nac:gx.falseFn};n[85]={id:85,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:83,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV17Id",gxold:"OV17Id",gxvar:"AV17Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV17Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(83),gx.O.AV17Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(83),gx.thousandSeparator)},nac:gx.falseFn};n[86]={id:86,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:83,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE_ACTION",fmt:0,gxz:"ZV29Update_Action",gxold:"OV29Update_Action",gxvar:"AV29Update_Action",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV29Update_Action=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29Update_Action=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vUPDATE_ACTION",n||gx.fn.currentGridRowImpl(83),gx.O.AV29Update_Action,gx.O.AV38Update_action_GXI)},c2v:function(n){gx.O.AV38Update_action_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV29Update_Action=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE_ACTION",n||gx.fn.currentGridRowImpl(83))},val_GXI:function(n){return gx.fn.getGridControlValue("vUPDATE_ACTION_GXI",n||gx.fn.currentGridRowImpl(83))},gxvar_GXI:"AV38Update_action_GXI",nac:gx.falseFn,evt:"e213e2_client"};n[87]={id:87,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:83,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE_ACTION",fmt:0,gxz:"ZV30Delete_Action",gxold:"OV30Delete_Action",gxvar:"AV30Delete_Action",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV30Delete_Action=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30Delete_Action=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vDELETE_ACTION",n||gx.fn.currentGridRowImpl(83),gx.O.AV30Delete_Action,gx.O.AV39Delete_action_GXI)},c2v:function(n){gx.O.AV39Delete_action_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV30Delete_Action=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE_ACTION",n||gx.fn.currentGridRowImpl(83))},val_GXI:function(n){return gx.fn.getGridControlValue("vDELETE_ACTION_GXI",n||gx.fn.currentGridRowImpl(83))},gxvar_GXI:"AV39Delete_action_GXI",nac:gx.falseFn,evt:"e223e2_client"};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"I_NORESULTSFOUNDTABLENAME_GRID",grid:0};n[93]={id:93,fld:"I_NORESULTSFOUNDTEXTBLOCK_GRID",format:0,grid:0,ctrltype:"textblock"};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"LAYOUTDEFINED_SECTION8_GRID",grid:0};n[97]={id:97,fld:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",grid:0};n[98]={id:98,fld:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",format:0,grid:0,evt:"e133e1_client",ctrltype:"textblock"};n[99]={id:99,fld:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e143e1_client",ctrltype:"textblock"};n[100]={id:100,fld:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};n[101]={id:101,fld:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e133e1_client",ctrltype:"textblock"};n[102]={id:102,fld:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};n[103]={id:103,fld:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e153e1_client",ctrltype:"textblock"};n[104]={id:104,fld:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};n[105]={id:105,fld:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",format:0,grid:0,evt:"e153e1_client",ctrltype:"textblock"};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"",grid:0};this.AV31GenericFilter_Grid="";this.ZV31GenericFilter_Grid="";this.OV31GenericFilter_Grid="";this.AV27GridSettingsRowsPerPage_Grid=0;this.ZV27GridSettingsRowsPerPage_Grid=0;this.OV27GridSettingsRowsPerPage_Grid=0;this.AV34FreezeColumnTitles_Grid=!1;this.ZV34FreezeColumnTitles_Grid=!1;this.OV34FreezeColumnTitles_Grid=!1;this.ZV19Name="";this.OV19Name="";this.ZV17Id=0;this.OV17Id=0;this.ZV29Update_Action="";this.OV29Update_Action="";this.ZV30Delete_Action="";this.OV30Delete_Action="";this.AV31GenericFilter_Grid="";this.AV27GridSettingsRowsPerPage_Grid=0;this.AV34FreezeColumnTitles_Grid=!1;this.AV19Name="";this.AV17Id=0;this.AV29Update_Action="";this.AV30Delete_Action="";this.AV7CurrentPage_Grid=0;this.AV35GenericFilter_PreviousValue_Grid="";this.AV33ClassCollection_Grid=[];this.AV37Pgmname="";this.AV32GridConfiguration={FreezeColumnTitles:!1,GridColumns:[],GridColumnsOrder:[]};this.AV14HasNextPage_Grid=!1;this.AV26RowsPerPage_Grid=0;this.AV16I_LoadCount_Grid=0;this.Events={e163e2_client:["'SAVEGRIDSETTINGS(GRID)'",!0],e233e2_client:["ENTER",!0],e243e2_client:["CANCEL",!0],e123e1_client:["'E_NEW'",!1],e133e1_client:["'PAGINGPREVIOUS(GRID)'",!1],e153e1_client:["'PAGINGNEXT(GRID)'",!1],e213e2_client:["'E_UPDATE'",!1],e223e2_client:["'E_DELETE'",!1],e143e1_client:["'PAGINGFIRST(GRID)'",!1],e113e1_client:["'TOGGLEGRIDSETTINGS(GRID)'",!1]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0}],[{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}]];this.EvtParms["'E_NEW'"]=[[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'PAGINGPREVIOUS(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}],[{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}]];this.EvtParms["'PAGINGNEXT(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}],[{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}]];this.EvtParms["'E_UPDATE'"]=[[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'E_DELETE'"]=[[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("I_NORESULTSFOUNDTABLENAME_GRID","Visible")',ctrl:"I_NORESULTSFOUNDTABLENAME_GRID",prop:"Visible"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV29Update_Action",fld:"vUPDATE_ACTION",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE_ACTION","Tooltiptext")',ctrl:"vUPDATE_ACTION",prop:"Tooltiptext"},{av:"AV30Delete_Action",fld:"vDELETE_ACTION",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE_ACTION","Tooltiptext")',ctrl:"vDELETE_ACTION",prop:"Tooltiptext"},{av:"AV19Name",fld:"vNAME",pic:""},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:'gx.fn.getCtrlProperty("vNAME","Link")',ctrl:"vNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible")',ctrl:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",prop:"Visible"}]];this.EvtParms["'PAGINGFIRST(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}],[{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}]];this.EvtParms["'TOGGLEGRIDSETTINGS(GRID)'"]=[[{av:'gx.fn.getCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible")',ctrl:"GRIDSETTINGS_CONTENTOUTERTABLEGRID",prop:"Visible"},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"}],[{ctrl:"vGRIDSETTINGSROWSPERPAGE_GRID"},{av:"AV27GridSettingsRowsPerPage_Grid",fld:"vGRIDSETTINGSROWSPERPAGE_GRID",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible")',ctrl:"GRIDSETTINGS_CONTENTOUTERTABLEGRID",prop:"Visible"}]];this.EvtParms["'SAVEGRIDSETTINGS(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV16I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""},{ctrl:"vGRIDSETTINGSROWSPERPAGE_GRID"},{av:"AV27GridSettingsRowsPerPage_Grid",fld:"vGRIDSETTINGSROWSPERPAGE_GRID",pic:"ZZZ9"}],[{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV26RowsPerPage_Grid",fld:"vROWSPERPAGE_GRID",pic:"ZZZ9"},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("GRIDSETTINGS_CONTENTOUTERTABLEGRID","Visible")',ctrl:"GRIDSETTINGS_CONTENTOUTERTABLEGRID",prop:"Visible"},{av:"AV35GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""}]];this.EvtParms["GRID.REFRESH"]=[[{av:"AV37Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV7CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV31GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV14HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""}],[{ctrl:"GRID",prop:"Backcolorstyle"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible")',ctrl:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",prop:"Visible"},{av:"AV32GridConfiguration",fld:"vGRIDCONFIGURATION",pic:""},{ctrl:"NEW",prop:"Visible"},{av:"AV34FreezeColumnTitles_Grid",fld:"vFREEZECOLUMNTITLES_GRID",pic:""},{av:"AV33ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV7CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV35GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV33ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV37Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV32GridConfiguration","vGRIDCONFIGURATION",0,"K2BGridConfiguration",0,0);this.setVCMap("AV14HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV26RowsPerPage_Grid","vROWSPERPAGE_GRID",0,"int",4,0);this.setVCMap("AV16I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV35GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV37Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV7CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV14HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV32GridConfiguration","vGRIDCONFIGURATION",0,"K2BGridConfiguration",0,0);this.setVCMap("AV33ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV26RowsPerPage_Grid","vROWSPERPAGE_GRID",0,"int",4,0);this.setVCMap("AV16I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV26RowsPerPage_Grid","vROWSPERPAGE_GRID",0,"int",4,0);this.setVCMap("AV7CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV14HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV35GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV37Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV7CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV14HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV32GridConfiguration","vGRIDCONFIGURATION",0,"K2BGridConfiguration",0,0);this.setVCMap("AV33ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV26RowsPerPage_Grid","vROWSPERPAGE_GRID",0,"int",4,0);this.setVCMap("AV16I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);t.addRefreshingVar({rfrVar:"AV35GenericFilter_PreviousValue_Grid"});t.addRefreshingVar({rfrVar:"AV37Pgmname"});t.addRefreshingVar({rfrVar:"AV7CurrentPage_Grid"});t.addRefreshingVar(this.GXValidFnc[35]);t.addRefreshingVar({rfrVar:"AV14HasNextPage_Grid"});t.addRefreshingVar({rfrVar:"AV32GridConfiguration"});t.addRefreshingVar({rfrVar:"AV33ClassCollection_Grid"});t.addRefreshingVar({rfrVar:"AV26RowsPerPage_Grid"});t.addRefreshingVar({rfrVar:"AV16I_LoadCount_Grid"});t.addRefreshingParm({rfrVar:"AV35GenericFilter_PreviousValue_Grid"});t.addRefreshingParm({rfrVar:"AV37Pgmname"});t.addRefreshingParm({rfrVar:"AV7CurrentPage_Grid"});t.addRefreshingParm(this.GXValidFnc[35]);t.addRefreshingParm({rfrVar:"AV14HasNextPage_Grid"});t.addRefreshingParm({rfrVar:"AV32GridConfiguration"});t.addRefreshingParm({rfrVar:"AV33ClassCollection_Grid"});t.addRefreshingParm({rfrVar:"AV26RowsPerPage_Grid"});t.addRefreshingParm({rfrVar:"AV16I_LoadCount_Grid"});t.addRefreshingParm(this.GXValidFnc[67]);this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},InitialProperties:{sdt:"GeneXusSecurity\\GAMProperty"},SecurityPolicy:{sdt:"GeneXusSecurity\\GAMSecurityPolicy"}});this.setSDTMapping("GeneXusSecurity\\GAMUser",{Attributes:{sdt:"GeneXusSecurity\\GAMUserAttribute"}});this.setSDTMapping("K2BGridState",{FilterValues:{sdt:"K2BGridState.FilterValue"}});this.setSDTMapping("GeneXusSecurity\\GAMRole",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRepository",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Email:{sdt:"GeneXusSecurity\\GAMRepositoryEmail"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationFilter",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMPermission",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationPermission",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicyFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicy",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRoleFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMLoginAdditionalParameters",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenu",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationTypeFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationType",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BActivityList.K2BActivityListItem",{Activity:{sdt:"K2BActivity"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenuOption",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BTrnContext",{TransactionName:{extr:"Transaction"},CallerUrl:{extr:"CallerUrl"},EntityManagerName:{extr:"EMName"},EntityManagerNextTaskCode:{extr:"NextTaskCode"},EntityManagerNextTaskMode:{extr:"NextTaskMode"},EntityManagerEncryptUrlParameters:{extr:"EncryptUrlParms"},ReturnMode:{extr:"ReturnMode"},SavePK:{extr:"SavePK"},AfterInsert:{sdt:"K2BTrnNavigation"},AfterUpdate:{sdt:"K2BTrnNavigation"},AfterDelete:{sdt:"K2BTrnNavigation"},Attributes:{extr:"Attributes"}});this.setSDTMapping("GeneXusSecurity\\GAMEventSubscription",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}})});gx.wi(function(){gx.createParentObj(this.k2bfsg.wwsecuritypolicy)})