gx.evt.autoSkip=!1;gx.define("k2bfsg.useraddrole",!1,function(){var n,t,i;this.ServerClass="k2bfsg.useraddrole";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.useraddrole.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV14CurrentPage_Grid=gx.fn.getIntegerValue("vCURRENTPAGE_GRID",gx.thousandSeparator);this.AV52GenericFilter_PreviousValue_Grid=gx.fn.getControlValue("vGENERICFILTER_PREVIOUSVALUE_GRID");this.AV50ClassCollection_Grid=gx.fn.getControlValue("vCLASSCOLLECTION_GRID");this.AV12CountSelectedItems_Grid=gx.fn.getIntegerValue("vCOUNTSELECTEDITEMS_GRID",gx.thousandSeparator);this.AV10AllSelectedItems_Grid=gx.fn.getControlValue("vALLSELECTEDITEMS_GRID");this.AV56Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV20Grid_SelectedRows=gx.fn.getIntegerValue("vGRID_SELECTEDROWS",gx.thousandSeparator);this.AV28I_LoadCount_Grid=gx.fn.getIntegerValue("vI_LOADCOUNT_GRID",gx.thousandSeparator);this.AV13CurrentAvailableRole=gx.fn.getIntegerValue("vCURRENTAVAILABLEROLE",gx.thousandSeparator);this.AV47UserId=gx.fn.getControlValue("vUSERID");this.AV34MultiRowHasNext_Grid=gx.fn.getControlValue("vMULTIROWHASNEXT_GRID");this.AV36MultiRowIterator_Grid=gx.fn.getIntegerValue("vMULTIROWITERATOR_GRID",gx.thousandSeparator);this.AV44SelectedItems_Grid=gx.fn.getControlValue("vSELECTEDITEMS_GRID");this.AV41S_Id=gx.fn.getIntegerValue("vS_ID",gx.thousandSeparator);this.AV18FieldValues_Grid=gx.fn.getControlValue("vFIELDVALUES_GRID");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",gx.thousandSeparator)};this.s112_client=function(){};this.s132_client=function(){};this.s142_client=function(){this.s222_client();this.AV12CountSelectedItems_Grid>0?this.s232_client():this.s242_client()};this.s222_client=function(){for(this.AV12CountSelectedItems_Grid=gx.num.trunc(0,0),this.AV60GXV5=gx.num.trunc(1,0);this.AV60GXV5<=this.AV10AllSelectedItems_Grid.length;)this.AV43SelectedItem_Grid=this.AV10AllSelectedItems_Grid[this.AV60GXV5-1],this.AV43SelectedItem_Grid.IsSelected&&(this.AV12CountSelectedItems_Grid=gx.num.trunc(this.AV12CountSelectedItems_Grid+1,0)),this.AV60GXV5=gx.num.trunc(this.AV60GXV5+1,0)};this.s232_client=function(){gx.fn.setCtrlProperty("ADDSELECTED","Visible",!0)};this.s242_client=function(){gx.fn.setCtrlProperty("ADDSELECTED","Visible",!1)};this.s152_client=function(){};this.s192_client=function(){};this.s212_client=function(){for(this.AV30Index_Grid=gx.num.trunc(1,0);this.AV30Index_Grid<=this.AV10AllSelectedItems_Grid.length;)this.AV10AllSelectedItems_Grid[this.AV30Index_Grid-1].SKNumeric1==this.AV29Id?this.AV10AllSelectedItems_Grid.splice(this.AV30Index_Grid-1,1):this.AV30Index_Grid=gx.num.trunc(this.AV30Index_Grid+1,0);this.AV35MultiRowItemSelected_Grid&&(this.AV43SelectedItem_Grid={SKNumeric1:0,SKNumeric2:0,SKNumeric3:0,SKNumeric4:0,SKNumeric5:0,SKNumeric6:0,SKCharacter1:"",SKCharacter2:"",SKCharacter3:"",SKCharacter4:"",SKCharacter5:"",SKCharacter6:"",SKGUID1:"00000000-0000-0000-0000-000000000000",SKGUID2:"00000000-0000-0000-0000-000000000000",SKDateTime1:gx.date.nullDate(),SKDateTime2:gx.date.nullDate(),IsSelected:!1,FieldValues:[]},this.AV43SelectedItem_Grid.IsSelected=this.AV35MultiRowItemSelected_Grid,this.AV43SelectedItem_Grid.SKNumeric1=gx.num.trunc(this.AV29Id,0),this.AV17FieldValue_Grid={Name:"",Value:"",ImageValue:"",ImageValue_GXI:""},this.AV17FieldValue_Grid.Name="Name",this.AV17FieldValue_Grid.Value=this.AV37Name,this.AV43SelectedItem_Grid.FieldValues.push(this.AV17FieldValue_Grid),this.AV17FieldValue_Grid={Name:"",Value:"",ImageValue:"",ImageValue_GXI:""},this.AV17FieldValue_Grid.Name="Guid",this.AV17FieldValue_Grid.Value=this.AV25Guid,this.AV43SelectedItem_Grid.FieldValues.push(this.AV17FieldValue_Grid),this.AV17FieldValue_Grid={Name:"",Value:"",ImageValue:"",ImageValue_GXI:""},this.AV17FieldValue_Grid.Name="Id",this.AV17FieldValue_Grid.Value=gx.num.str(this.AV29Id,12,0),this.AV43SelectedItem_Grid.FieldValues.push(this.AV17FieldValue_Grid),this.AV10AllSelectedItems_Grid.push(this.AV43SelectedItem_Grid));this.AV35MultiRowItemSelected_Grid||(this.AV11CheckAll_Grid=!1)};this.s252_client=function(){};this.s262_client=function(){this.AV36MultiRowIterator_Grid=gx.num.trunc(1,0)};this.s272_client=function(){for(this.AV42S_Name="",this.AV40S_Guid="",this.AV41S_Id=gx.num.trunc(0,0);this.AV36MultiRowIterator_Grid<=this.AV44SelectedItems_Grid.length&&!this.AV44SelectedItems_Grid[this.AV36MultiRowIterator_Grid-1].IsSelected;)this.AV36MultiRowIterator_Grid=gx.num.trunc(this.AV36MultiRowIterator_Grid+1,0);this.AV36MultiRowIterator_Grid>this.AV44SelectedItems_Grid.length?this.AV34MultiRowHasNext_Grid=!1:(this.AV34MultiRowHasNext_Grid=!0,this.AV18FieldValues_Grid=this.AV44SelectedItems_Grid[this.AV36MultiRowIterator_Grid-1].FieldValues,this.s302_client());this.AV36MultiRowIterator_Grid=gx.num.trunc(this.AV36MultiRowIterator_Grid+1,0)};this.s302_client=function(){for(this.AV61GXV6=gx.num.trunc(1,0);this.AV61GXV6<=this.AV18FieldValues_Grid.length;)this.AV17FieldValue_Grid=this.AV18FieldValues_Grid[this.AV61GXV6-1],gx.text.compare(this.AV17FieldValue_Grid.Name,"Name")==0?this.AV42S_Name=this.AV17FieldValue_Grid.Value:gx.text.compare(this.AV17FieldValue_Grid.Name,"Guid")==0?this.AV40S_Guid=this.AV17FieldValue_Grid.Value:gx.text.compare(this.AV17FieldValue_Grid.Name,"Id")==0&&(this.AV41S_Id=gx.num.trunc(gx.num.val(this.AV17FieldValue_Grid.Value),0)),this.AV61GXV6=gx.num.trunc(this.AV61GXV6+1,0)};this.e17472_client=function(){return this.executeServerEvent("VMULTIROWITEMSELECTED_GRID.CLICK",!0,arguments[0],!1,!1)};this.e11472_client=function(){return this.executeServerEvent("VCHECKALL_GRID.CLICK",!0,null,!1,!0)};this.e12472_client=function(){return this.executeServerEvent("'E_ADDSELECTED'",!1,null,!1,!1)};this.e18472_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19472_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,51,52,53,54,55,56,57,60,61,62,63];this.GXLastCtrlId=63;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",50,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"k2bfsg.useraddrole",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addCheckBox("Multirowitemselected_grid",51,"vMULTIROWITEMSELECTED_GRID","","","MultiRowItemSelected_Grid","boolean","true","false","e17472_client",!0,!1,20,"px","K2BToolsCheckBoxColumn");t.addSingleLineEdit("Name",52,"vNAME",gx.getMessage("K2BT_GAM_Name"),"","Name","char",0,"px",120,80,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn");t.addSingleLineEdit("Guid",53,"vGUID",gx.getMessage("K2BT_GUID"),"","Guid","char",0,"px",40,40,"start",null,[],"Guid","Guid",!1,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn InvisibleInExtraSmallColumn");t.addSingleLineEdit("Id",54,"vID",gx.getMessage("K2BT_GAM_Id"),"","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn InvisibleInExtraSmallColumn");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(t);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,64,31,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");i=this.K2BCONTROLBEAUTIFY1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"CONTENTTABLE",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GRIDCOMPONENTCONTENT_GRID",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"LAYOUTDEFINED_GRID_INNER_GRID",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"LAYOUTDEFINED_TABLE10_GRID",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID",grid:0};n[21]={id:21,fld:"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"LAYOUTDEFINED_TABLE9_GRID",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"LAYOUTDEFINED_TABLE8_GRID",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENERICFILTER_GRID",fmt:0,gxz:"ZV51GenericFilter_Grid",gxold:"OV51GenericFilter_Grid",gxvar:"AV51GenericFilter_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV51GenericFilter_Grid=n)},v2z:function(n){n!==undefined&&(gx.O.ZV51GenericFilter_Grid=n)},v2c:function(){gx.fn.setControlValue("vGENERICFILTER_GRID",gx.O.AV51GenericFilter_Grid,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV51GenericFilter_Grid=this.val())},val:function(){return gx.fn.getControlValue("vGENERICFILTER_GRID")},nac:gx.falseFn};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"LAYOUTDEFINED_TABLE7_GRID",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"ACTIONS_GRID_TOPRIGHT",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"ADDSELECTED",grid:0,evt:"e12472_client"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"LAYOUTDEFINED_TABLE3_GRID",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"MAINGRID_RESPONSIVETABLE_GRID",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TABLEGRIDCONTAINER_GRID",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCHECKALL_GRID",fmt:0,gxz:"ZV11CheckAll_Grid",gxold:"OV11CheckAll_Grid",gxvar:"AV11CheckAll_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV11CheckAll_Grid=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11CheckAll_Grid=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCHECKALL_GRID",gx.O.AV11CheckAll_Grid,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11CheckAll_Grid=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCHECKALL_GRID")},nac:gx.falseFn,evt:"e11472_client",values:["true","false"]};n[51]={id:51,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:50,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMULTIROWITEMSELECTED_GRID",fmt:0,gxz:"ZV35MultiRowItemSelected_Grid",gxold:"OV35MultiRowItemSelected_Grid",gxvar:"AV35MultiRowItemSelected_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV35MultiRowItemSelected_Grid=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV35MultiRowItemSelected_Grid=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vMULTIROWITEMSELECTED_GRID",n||gx.fn.currentGridRowImpl(50),gx.O.AV35MultiRowItemSelected_Grid,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV35MultiRowItemSelected_Grid=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vMULTIROWITEMSELECTED_GRID",n||gx.fn.currentGridRowImpl(50))},nac:gx.falseFn,evt:"e17472_client",values:["true","false"]};n[52]={id:52,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:50,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV37Name",gxold:"OV37Name",gxvar:"AV37Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV37Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(50),gx.O.AV37Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV37Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(50))},nac:gx.falseFn};n[53]={id:53,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:50,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",fmt:0,gxz:"ZV25Guid",gxold:"OV25Guid",gxvar:"AV25Guid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV25Guid=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25Guid=n)},v2c:function(n){gx.fn.setGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(50),gx.O.AV25Guid,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV25Guid=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(50))},nac:gx.falseFn};n[54]={id:54,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:50,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV29Id",gxold:"OV29Id",gxvar:"AV29Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV29Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV29Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(50),gx.O.AV29Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV29Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(50),gx.thousandSeparator)},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"I_NORESULTSFOUNDTABLENAME_GRID",grid:0};n[60]={id:60,fld:"I_NORESULTSFOUNDTEXTBLOCK_GRID",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};this.AV51GenericFilter_Grid="";this.ZV51GenericFilter_Grid="";this.OV51GenericFilter_Grid="";this.AV11CheckAll_Grid=!1;this.ZV11CheckAll_Grid=!1;this.OV11CheckAll_Grid=!1;this.ZV35MultiRowItemSelected_Grid=!1;this.OV35MultiRowItemSelected_Grid=!1;this.ZV37Name="";this.OV37Name="";this.ZV25Guid="";this.OV25Guid="";this.ZV29Id=0;this.OV29Id=0;this.AV51GenericFilter_Grid="";this.AV11CheckAll_Grid=!1;this.AV47UserId="";this.AV35MultiRowItemSelected_Grid=!1;this.AV37Name="";this.AV25Guid="";this.AV29Id=0;this.AV14CurrentPage_Grid=0;this.AV52GenericFilter_PreviousValue_Grid="";this.AV50ClassCollection_Grid=[];this.AV12CountSelectedItems_Grid=0;this.AV10AllSelectedItems_Grid=[];this.AV56Pgmname="";this.AV20Grid_SelectedRows=0;this.AV28I_LoadCount_Grid=0;this.AV13CurrentAvailableRole=0;this.AV34MultiRowHasNext_Grid=!1;this.AV36MultiRowIterator_Grid=0;this.AV44SelectedItems_Grid=[];this.AV41S_Id=0;this.AV18FieldValues_Grid=[];this.AV60GXV5=0;this.AV43SelectedItem_Grid={SKNumeric1:0,SKNumeric2:0,SKNumeric3:0,SKNumeric4:0,SKNumeric5:0,SKNumeric6:0,SKCharacter1:"",SKCharacter2:"",SKCharacter3:"",SKCharacter4:"",SKCharacter5:"",SKCharacter6:"",SKGUID1:"00000000-0000-0000-0000-000000000000",SKGUID2:"00000000-0000-0000-0000-000000000000",SKDateTime1:gx.date.nullDate(),SKDateTime2:gx.date.nullDate(),IsSelected:!1,FieldValues:[]};this.AV17FieldValue_Grid={Name:"",Value:"",ImageValue:"",ImageValue_GXI:""};this.AV30Index_Grid=0;this.AV61GXV6=0;this.AV40S_Guid="";this.AV42S_Name="";this.Events={e17472_client:["VMULTIROWITEMSELECTED_GRID.CLICK",!0],e11472_client:["VCHECKALL_GRID.CLICK",!0],e12472_client:["'E_ADDSELECTED'",!0],e18472_client:["ENTER",!0],e19472_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV29Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV20Grid_SelectedRows",fld:"vGRID_SELECTEDROWS",pic:"ZZZ9"},{av:"AV51GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV14CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9",hsh:!0},{av:"AV52GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV56Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV13CurrentAvailableRole",fld:"vCURRENTAVAILABLEROLE",pic:"ZZZ9",hsh:!0},{av:"AV47UserId",fld:"vUSERID",pic:"",hsh:!0}],[{av:"AV14CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9",hsh:!0},{av:"AV52GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV20Grid_SelectedRows",fld:"vGRID_SELECTEDROWS",pic:"ZZZ9"},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{ctrl:"ADDSELECTED",prop:"Visible"}]];this.EvtParms["GRID.REFRESH"]=[[{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV56Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV51GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"}],[{ctrl:"GRID",prop:"Backcolorstyle"},{av:"AV20Grid_SelectedRows",fld:"vGRID_SELECTEDROWS",pic:"ZZZ9"},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{ctrl:"ADDSELECTED",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV29Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV20Grid_SelectedRows",fld:"vGRID_SELECTEDROWS",pic:"ZZZ9"},{av:"AV28I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV51GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV13CurrentAvailableRole",fld:"vCURRENTAVAILABLEROLE",pic:"ZZZ9",hsh:!0},{av:"AV56Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV47UserId",fld:"vUSERID",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("I_NORESULTSFOUNDTABLENAME_GRID","Visible")',ctrl:"I_NORESULTSFOUNDTABLENAME_GRID",prop:"Visible"},{av:"AV28I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV35MultiRowItemSelected_Grid",fld:"vMULTIROWITEMSELECTED_GRID",pic:""},{av:"AV20Grid_SelectedRows",fld:"vGRID_SELECTEDROWS",pic:"ZZZ9"},{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV13CurrentAvailableRole",fld:"vCURRENTAVAILABLEROLE",pic:"ZZZ9",hsh:!0},{av:"AV37Name",fld:"vNAME",pic:"",hsh:!0},{av:"AV25Guid",fld:"vGUID",pic:"",hsh:!0},{av:"AV29Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0}]];this.EvtParms["VMULTIROWITEMSELECTED_GRID.CLICK"]=[[{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV29Id",fld:"vID",grid:50,pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_50",ctrl:"GRID",grid:50,prop:"GridRC",grid:50},{av:"AV35MultiRowItemSelected_Grid",fld:"vMULTIROWITEMSELECTED_GRID",grid:50,pic:""},{av:"AV37Name",fld:"vNAME",grid:50,pic:"",hsh:!0},{av:"AV25Guid",fld:"vGUID",grid:50,pic:"",hsh:!0},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"}],[{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{ctrl:"ADDSELECTED",prop:"Visible"}]];this.EvtParms["VCHECKALL_GRID.CLICK"]=[[{av:"AV35MultiRowItemSelected_Grid",fld:"vMULTIROWITEMSELECTED_GRID",grid:50,pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_50",ctrl:"GRID",grid:50,prop:"GridRC",grid:50},{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:"AV29Id",fld:"vID",grid:50,pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV37Name",fld:"vNAME",grid:50,pic:"",hsh:!0},{av:"AV25Guid",fld:"vGUID",grid:50,pic:"",hsh:!0}],[{av:"AV35MultiRowItemSelected_Grid",fld:"vMULTIROWITEMSELECTED_GRID",pic:""},{av:"AV50ClassCollection_Grid",fld:"vCLASSCOLLECTION_GRID",pic:""},{av:'gx.fn.getCtrlProperty("MAINGRID_RESPONSIVETABLE_GRID","Class")',ctrl:"MAINGRID_RESPONSIVETABLE_GRID",prop:"Class"},{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV11CheckAll_Grid",fld:"vCHECKALL_GRID",pic:""},{av:"AV12CountSelectedItems_Grid",fld:"vCOUNTSELECTEDITEMS_GRID",pic:"ZZZ9"},{ctrl:"ADDSELECTED",prop:"Visible"}]];this.EvtParms["'E_ADDSELECTED'"]=[[{av:"AV10AllSelectedItems_Grid",fld:"vALLSELECTEDITEMS_GRID",pic:""},{av:"AV34MultiRowHasNext_Grid",fld:"vMULTIROWHASNEXT_GRID",pic:""},{av:"AV36MultiRowIterator_Grid",fld:"vMULTIROWITERATOR_GRID",pic:"ZZZ9"},{av:"AV44SelectedItems_Grid",fld:"vSELECTEDITEMS_GRID",pic:""},{av:"AV47UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV41S_Id",fld:"vS_ID",pic:"ZZZZZZZZZZZ9"},{av:"AV18FieldValues_Grid",fld:"vFIELDVALUES_GRID",pic:""}],[{av:"AV44SelectedItems_Grid",fld:"vSELECTEDITEMS_GRID",pic:""},{av:"AV36MultiRowIterator_Grid",fld:"vMULTIROWITERATOR_GRID",pic:"ZZZ9"},{av:"AV41S_Id",fld:"vS_ID",pic:"ZZZZZZZZZZZ9"},{av:"AV18FieldValues_Grid",fld:"vFIELDVALUES_GRID",pic:""},{av:"AV34MultiRowHasNext_Grid",fld:"vMULTIROWHASNEXT_GRID",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV14CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV52GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV50ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV12CountSelectedItems_Grid","vCOUNTSELECTEDITEMS_GRID",0,"int",4,0);this.setVCMap("AV10AllSelectedItems_Grid","vALLSELECTEDITEMS_GRID",0,"CollK2BSelectionItem",0,0);this.setVCMap("AV56Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV20Grid_SelectedRows","vGRID_SELECTEDROWS",0,"int",4,0);this.setVCMap("AV28I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV13CurrentAvailableRole","vCURRENTAVAILABLEROLE",0,"int",4,0);this.setVCMap("AV47UserId","vUSERID",0,"char",40,0);this.setVCMap("AV34MultiRowHasNext_Grid","vMULTIROWHASNEXT_GRID",0,"boolean",4,0);this.setVCMap("AV36MultiRowIterator_Grid","vMULTIROWITERATOR_GRID",0,"int",4,0);this.setVCMap("AV44SelectedItems_Grid","vSELECTEDITEMS_GRID",0,"CollK2BSelectionItem",0,0);this.setVCMap("AV41S_Id","vS_ID",0,"int",12,0);this.setVCMap("AV18FieldValues_Grid","vFIELDVALUES_GRID",0,"CollK2BSelectionItem.FieldValuesItem",0,0);this.setVCMap("AV14CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV52GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV10AllSelectedItems_Grid","vALLSELECTEDITEMS_GRID",0,"CollK2BSelectionItem",0,0);this.setVCMap("AV50ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV56Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV12CountSelectedItems_Grid","vCOUNTSELECTEDITEMS_GRID",0,"int",4,0);this.setVCMap("AV20Grid_SelectedRows","vGRID_SELECTEDROWS",0,"int",4,0);this.setVCMap("AV28I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV13CurrentAvailableRole","vCURRENTAVAILABLEROLE",0,"int",4,0);this.setVCMap("AV47UserId","vUSERID",0,"char",40,0);this.setVCMap("AV14CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV52GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV10AllSelectedItems_Grid","vALLSELECTEDITEMS_GRID",0,"CollK2BSelectionItem",0,0);this.setVCMap("AV50ClassCollection_Grid","vCLASSCOLLECTION_GRID",0,"Collchar",0,0);this.setVCMap("AV56Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV12CountSelectedItems_Grid","vCOUNTSELECTEDITEMS_GRID",0,"int",4,0);this.setVCMap("AV20Grid_SelectedRows","vGRID_SELECTEDROWS",0,"int",4,0);this.setVCMap("AV28I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV13CurrentAvailableRole","vCURRENTAVAILABLEROLE",0,"int",4,0);this.setVCMap("AV47UserId","vUSERID",0,"char",40,0);t.addRefreshingVar({rfrVar:"AV14CurrentPage_Grid"});t.addRefreshingVar({rfrVar:"AV52GenericFilter_PreviousValue_Grid"});t.addRefreshingVar({rfrVar:"AV10AllSelectedItems_Grid"});t.addRefreshingVar({rfrVar:"AV50ClassCollection_Grid"});t.addRefreshingVar({rfrVar:"AV56Pgmname"});t.addRefreshingVar(this.GXValidFnc[31]);t.addRefreshingVar({rfrVar:"AV12CountSelectedItems_Grid"});t.addRefreshingVar({rfrVar:"AV29Id",rfrProp:"Value",gxAttId:"Id"});t.addRefreshingVar({rfrVar:"AV20Grid_SelectedRows"});t.addRefreshingVar({rfrVar:"AV28I_LoadCount_Grid"});t.addRefreshingVar({rfrVar:"AV13CurrentAvailableRole"});t.addRefreshingVar({rfrVar:"AV47UserId"});t.addRefreshingParm({rfrVar:"AV14CurrentPage_Grid"});t.addRefreshingParm({rfrVar:"AV52GenericFilter_PreviousValue_Grid"});t.addRefreshingParm({rfrVar:"AV10AllSelectedItems_Grid"});t.addRefreshingParm({rfrVar:"AV50ClassCollection_Grid"});t.addRefreshingParm({rfrVar:"AV56Pgmname"});t.addRefreshingParm(this.GXValidFnc[31]);t.addRefreshingParm({rfrVar:"AV12CountSelectedItems_Grid"});t.addRefreshingParm({rfrVar:"AV29Id",rfrProp:"Value",gxAttId:"Id"});t.addRefreshingParm({rfrVar:"AV20Grid_SelectedRows"});t.addRefreshingParm({rfrVar:"AV28I_LoadCount_Grid"});t.addRefreshingParm({rfrVar:"AV13CurrentAvailableRole"});t.addRefreshingParm({rfrVar:"AV47UserId"});t.addRefreshingParm(this.GXValidFnc[49]);this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},InitialProperties:{sdt:"GeneXusSecurity\\GAMProperty"},SecurityPolicy:{sdt:"GeneXusSecurity\\GAMSecurityPolicy"}});this.setSDTMapping("GeneXusSecurity\\GAMUser",{Attributes:{sdt:"GeneXusSecurity\\GAMUserAttribute"}});this.setSDTMapping("K2BGridState",{FilterValues:{sdt:"K2BGridState.FilterValue"}});this.setSDTMapping("GeneXusSecurity\\GAMRole",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRepository",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Email:{sdt:"GeneXusSecurity\\GAMRepositoryEmail"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationFilter",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BSelectionItem",{FieldValues:{sdt:"K2BSelectionItem.FieldValuesItem"}});this.setSDTMapping("GeneXusSecurity\\GAMPermission",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationPermission",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"},Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicyFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMSecurityPolicy",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRoleFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMLoginAdditionalParameters",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenu",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationTypeFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMAuthenticationType",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BActivityList.K2BActivityListItem",{Activity:{sdt:"K2BActivity"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationMenuOption",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("K2BTrnContext",{TransactionName:{extr:"Transaction"},CallerUrl:{extr:"CallerUrl"},EntityManagerName:{extr:"EMName"},EntityManagerNextTaskCode:{extr:"NextTaskCode"},EntityManagerNextTaskMode:{extr:"NextTaskMode"},EntityManagerEncryptUrlParameters:{extr:"EncryptUrlParms"},ReturnMode:{extr:"ReturnMode"},SavePK:{extr:"SavePK"},AfterInsert:{sdt:"K2BTrnNavigation"},AfterUpdate:{sdt:"K2BTrnNavigation"},AfterDelete:{sdt:"K2BTrnNavigation"},Attributes:{extr:"Attributes"}});this.setSDTMapping("GeneXusSecurity\\GAMEventSubscription",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}})});gx.wi(function(){gx.createParentObj(this.k2bfsg.useraddrole)})