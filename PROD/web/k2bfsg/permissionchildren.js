gx.evt.autoSkip=!1;gx.define("k2bfsg.permissionchildren",!0,function(n){var t,i,r,u;this.ServerClass="k2bfsg.permissionchildren";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2bfsg.permissionchildren.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV15CurrentPage_Grid=gx.fn.getIntegerValue("vCURRENTPAGE_GRID",",");this.AV38GenericFilter_PreviousValue_Grid=gx.fn.getControlValue("vGENERICFILTER_PREVIOUSVALUE_GRID");this.AV39Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV18HasNextPage_Grid=gx.fn.getControlValue("vHASNEXTPAGE_GRID");this.AV17I_LoadCount_Grid=gx.fn.getIntegerValue("vI_LOADCOUNT_GRID",",");this.AV32ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",",");this.AV28PermissionId=gx.fn.getControlValue("vPERMISSIONID");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",",")};this.Validv_Accesstype=function(){var n=gx.fn.currentGridRowImpl(52);return this.validCliEvt("Validv_Accesstype",52,function(){try{var n=gx.util.balloon.getNew("vACCESSTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV23AccessType,"A")==0||gx.text.compare(this.AV23AccessType,"R")==0))try{n.setError("Field Access Type is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s132_client=function(){};this.s152_client=function(){};this.s202_client=function(){};this.s182_client=function(){gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption","1");gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV15CurrentPage_Grid-1,10,0));gx.fn.setCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV15CurrentPage_Grid,4,0));gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption",gx.num.str(this.AV15CurrentPage_Grid+1,10,0));gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal");gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal");0==this.AV15CurrentPage_Grid||this.AV15CurrentPage_Grid<=1?(gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationDisabled"),gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible",!0),this.AV15CurrentPage_Grid==2?(gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible",!0),this.AV15CurrentPage_Grid==3?gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!1):gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible",!0)));this.AV18HasNextPage_Grid==!1?(gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class","K2BToolsTextBlock_PaginationNormal_Disabled"),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible",!1),gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible",!1)):(gx.fn.setCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible",!0),gx.fn.setCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible",!0));this.AV15CurrentPage_Grid<=1&&this.AV18HasNextPage_Grid==!1?gx.fn.setCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible",!1):gx.fn.setCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible",!0)};this.e124g1_client=function(){return this.clearMessages(),this.AV15CurrentPage_Grid=gx.num.trunc(1,0),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e114g1_client=function(){return this.clearMessages(),this.AV15CurrentPage_Grid>1&&(this.AV15CurrentPage_Grid=gx.num.trunc(this.AV15CurrentPage_Grid-1,0)),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e134g1_client=function(){return this.clearMessages(),this.AV18HasNextPage_Grid&&(this.AV15CurrentPage_Grid=gx.num.trunc(this.AV15CurrentPage_Grid+1,0)),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.refreshGrid("Grid"),this.refreshOutputs([{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e204g2_client=function(){return this.clearMessages(),this.call("k2bfsg.entryapplicationpermission.aspx",["DSP",this.AV32ApplicationId,this.AV24Id],null,["Mode","ApplicationId","Id"]),this.refreshOutputs([{av:"AV24Id",fld:"vID",pic:""},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e194g2_client=function(){return this.executeServerEvent("'E_DELETE'",!0,arguments[0],!1,!1)};this.e144g2_client=function(){return this.executeServerEvent("'E_ADD'",!1,null,!1,!1)};this.e214g2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e224g2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,53,54,55,56,57,58,59,60,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78];this.GXLastCtrlId=78;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",52,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"k2bfsg.permissionchildren",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit("Name",53,"vNAME","Name","","Name","char",0,"px",120,80,"start","e204g2_client",[],"Name","Name",!0,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn");i.addSingleLineEdit("Dsc",54,"vDSC","Description","","Dsc","char",570,"px",254,80,"start",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn InvisibleInExtraSmallColumn");i.addComboBox("Accesstype",55,"vACCESSTYPE","Access type","AccessType","char",null,0,!0,!1,0,"px","K2BToolsGridColumn InvisibleInExtraSmallColumn");i.addSingleLineEdit("Id",56,"vID","ID","","Id","char",0,"px",40,40,"start",null,[],"Id","Id",!1,0,!1,!1,"Attribute_Grid",0,"K2BToolsGridColumn InvisibleInExtraSmallColumn");i.addBitmap("&Delete_action","vDELETE_ACTION",57,20,"px",17,"px","e194g2_client","","","Image_Action","K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover");this.GridContainer.emptyText="";this.setGrid(i);this.GRIDCOMPONENT_GRIDContainer=gx.uc.getNew(this,12,0,"K2BT_Component",this.CmpContext+"GRIDCOMPONENT_GRIDContainer","Gridcomponent_grid","GRIDCOMPONENT_GRID");r=this.GRIDCOMPONENT_GRIDContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Icon","Icon","","str");r.setProp("Title","Title","Permission children","str");r.setProp("TitleClass","Titleclass","TextBlock_Subtitle","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Open","Open",!0,"bool");r.setProp("ShowBorders","Showborders",!0,"bool");r.setProp("ContainsEditableForm","Containseditableform",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,79,36,"K2BControlBeautify",this.CmpContext+"K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");u=this.K2BCONTROLBEAUTIFY1Container;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"CONTENTTABLE",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[14]={id:14,fld:"GRIDCOMPONENT_GRID_CONTENT",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"GRIDCOMPONENTCONTENT_GRID",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"LAYOUTDEFINED_GRID_INNER_GRID",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"LAYOUTDEFINED_TABLE10_GRID",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID",grid:0};t[26]={id:26,fld:"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"LAYOUTDEFINED_TABLE9_GRID",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"LAYOUTDEFINED_TABLE8_GRID",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENERICFILTER_GRID",fmt:0,gxz:"ZV20GenericFilter_Grid",gxold:"OV20GenericFilter_Grid",gxvar:"AV20GenericFilter_Grid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20GenericFilter_Grid=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20GenericFilter_Grid=n)},v2c:function(){gx.fn.setControlValue("vGENERICFILTER_GRID",gx.O.AV20GenericFilter_Grid,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20GenericFilter_Grid=this.val())},val:function(){return gx.fn.getControlValue("vGENERICFILTER_GRID")},nac:gx.falseFn};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,fld:"LAYOUTDEFINED_TABLE7_GRID",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"ACTIONS_GRID_TOPRIGHT",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,fld:"ADD",grid:0,evt:"e144g2_client"};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"LAYOUTDEFINED_TABLE3_GRID",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"MAINGRID_RESPONSIVETABLE_GRID",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[53]={id:53,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:52,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV21Name",gxold:"OV21Name",gxvar:"AV21Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV21Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(52),gx.O.AV21Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(52))},nac:gx.falseFn,evt:"e204g2_client"};t[54]={id:54,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:52,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV22Dsc",gxold:"OV22Dsc",gxvar:"AV22Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV22Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(52),gx.O.AV22Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV22Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(52))},nac:gx.falseFn};t[55]={id:55,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:52,gxgrid:this.GridContainer,fnc:this.Validv_Accesstype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACCESSTYPE",fmt:0,gxz:"ZV23AccessType",gxold:"OV23AccessType",gxvar:"AV23AccessType",ucs:[],op:[55],ip:[55],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV23AccessType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23AccessType=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(52),gx.O.AV23AccessType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV23AccessType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(52))},nac:gx.falseFn};t[56]={id:56,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:52,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV24Id",gxold:"OV24Id",gxvar:"AV24Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV24Id=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Id=n)},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(52),gx.O.AV24Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Id=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vID",n||gx.fn.currentGridRowImpl(52))},nac:gx.falseFn};t[57]={id:57,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:52,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE_ACTION",fmt:0,gxz:"ZV25Delete_Action",gxold:"OV25Delete_Action",gxvar:"AV25Delete_Action",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV25Delete_Action=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25Delete_Action=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vDELETE_ACTION",n||gx.fn.currentGridRowImpl(52),gx.O.AV25Delete_Action,gx.O.AV40Delete_action_GXI)},c2v:function(n){gx.O.AV40Delete_action_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV25Delete_Action=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE_ACTION",n||gx.fn.currentGridRowImpl(52))},val_GXI:function(n){return gx.fn.getGridControlValue("vDELETE_ACTION_GXI",n||gx.fn.currentGridRowImpl(52))},gxvar_GXI:"AV40Delete_action_GXI",nac:gx.falseFn,evt:"e194g2_client"};t[58]={id:58,fld:"",grid:0};t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"I_NORESULTSFOUNDTABLENAME_GRID",grid:0};t[63]={id:63,fld:"I_NORESULTSFOUNDTEXTBLOCK_GRID",format:0,grid:0,ctrltype:"textblock"};t[64]={id:64,fld:"",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"LAYOUTDEFINED_SECTION8_GRID",grid:0};t[67]={id:67,fld:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",grid:0};t[68]={id:68,fld:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",format:0,grid:0,evt:"e114g1_client",ctrltype:"textblock"};t[69]={id:69,fld:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e124g1_client",ctrltype:"textblock"};t[70]={id:70,fld:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};t[71]={id:71,fld:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e114g1_client",ctrltype:"textblock"};t[72]={id:72,fld:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};t[73]={id:73,fld:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",format:0,grid:0,evt:"e134g1_client",ctrltype:"textblock"};t[74]={id:74,fld:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",format:0,grid:0,ctrltype:"textblock"};t[75]={id:75,fld:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",format:0,grid:0,evt:"e134g1_client",ctrltype:"textblock"};t[76]={id:76,fld:"",grid:0};t[77]={id:77,fld:"",grid:0};t[78]={id:78,fld:"",grid:0};this.AV20GenericFilter_Grid="";this.ZV20GenericFilter_Grid="";this.OV20GenericFilter_Grid="";this.ZV21Name="";this.OV21Name="";this.ZV22Dsc="";this.OV22Dsc="";this.ZV23AccessType="";this.OV23AccessType="";this.ZV24Id="";this.OV24Id="";this.ZV25Delete_Action="";this.OV25Delete_Action="";this.AV20GenericFilter_Grid="";this.AV32ApplicationId=0;this.AV28PermissionId="";this.AV21Name="";this.AV22Dsc="";this.AV23AccessType="";this.AV24Id="";this.AV25Delete_Action="";this.AV15CurrentPage_Grid=0;this.AV38GenericFilter_PreviousValue_Grid="";this.AV39Pgmname="";this.AV18HasNextPage_Grid=!1;this.AV17I_LoadCount_Grid=0;this.Events={e194g2_client:["'E_DELETE'",!0],e144g2_client:["'E_ADD'",!0],e214g2_client:["ENTER",!0],e224g2_client:["CANCEL",!0],e124g1_client:["'PAGINGFIRST(GRID)'",!1],e114g1_client:["'PAGINGPREVIOUS(GRID)'",!1],e134g1_client:["'PAGINGNEXT(GRID)'",!1],e204g2_client:["VNAME.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0}],[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["GRID.REFRESH"]=[[{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0}],[{ctrl:"GRID",prop:"Backcolorstyle"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible")',ctrl:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",prop:"Visible"},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""}],[{av:'gx.fn.getCtrlProperty("I_NORESULTSFOUNDTABLENAME_GRID","Visible")',ctrl:"I_NORESULTSFOUNDTABLENAME_GRID",prop:"Visible"},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV25Delete_Action",fld:"vDELETE_ACTION",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE_ACTION","Enabled")',ctrl:"vDELETE_ACTION",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vDELETE_ACTION","Tooltiptext")',ctrl:"vDELETE_ACTION",prop:"Tooltiptext"},{av:"AV21Name",fld:"vNAME",pic:""},{av:"AV22Dsc",fld:"vDSC",pic:""},{ctrl:"vACCESSTYPE"},{av:"AV23AccessType",fld:"vACCESSTYPE",pic:""},{av:"AV24Id",fld:"vID",pic:""},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Caption")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Caption"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID","Class")',ctrl:"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID",prop:"Class"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID","Visible")',ctrl:"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID","Visible")',ctrl:"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID",prop:"Visible"}]];this.EvtParms["'PAGINGFIRST(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"}],[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["'PAGINGPREVIOUS(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"}],[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["'PAGINGNEXT(GRID)'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"}],[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["'E_DELETE'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"},{av:"AV24Id",fld:"vID",pic:""}],[{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["'E_ADD'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{av:"AV39Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV20GenericFilter_Grid",fld:"vGENERICFILTER_GRID",pic:""},{av:"AV18HasNextPage_Grid",fld:"vHASNEXTPAGE_GRID",pic:"",hsh:!0},{av:"AV17I_LoadCount_Grid",fld:"vI_LOADCOUNT_GRID",pic:"ZZZ9",hsh:!0},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"sPrefix"}],[{av:"AV28PermissionId",fld:"vPERMISSIONID",pic:""},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15CurrentPage_Grid",fld:"vCURRENTPAGE_GRID",pic:"ZZZ9"},{av:"AV38GenericFilter_PreviousValue_Grid",fld:"vGENERICFILTER_PREVIOUSVALUE_GRID",pic:"",hsh:!0},{ctrl:"ADD",prop:"Visible"},{ctrl:"ADD",prop:"Tooltiptext"}]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV24Id",fld:"vID",pic:""}],[{av:"AV24Id",fld:"vID",pic:""},{av:"AV32ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_ACCESSTYPE=[[{ctrl:"vACCESSTYPE"},{av:"AV23AccessType",fld:"vACCESSTYPE",pic:""}],[{ctrl:"vACCESSTYPE"},{av:"AV23AccessType",fld:"vACCESSTYPE",pic:""}]];this.setVCMap("AV15CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV38GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV39Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV18HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV17I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV32ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV28PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV38GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV39Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV15CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV18HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV17I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV32ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV28PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV15CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV18HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV38GenericFilter_PreviousValue_Grid","vGENERICFILTER_PREVIOUSVALUE_GRID",0,"char",100,0);this.setVCMap("AV39Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV15CurrentPage_Grid","vCURRENTPAGE_GRID",0,"int",4,0);this.setVCMap("AV18HasNextPage_Grid","vHASNEXTPAGE_GRID",0,"boolean",4,0);this.setVCMap("AV17I_LoadCount_Grid","vI_LOADCOUNT_GRID",0,"int",4,0);this.setVCMap("AV32ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV28PermissionId","vPERMISSIONID",0,"char",40,0);i.addRefreshingVar({rfrVar:"AV38GenericFilter_PreviousValue_Grid"});i.addRefreshingVar({rfrVar:"AV39Pgmname"});i.addRefreshingVar({rfrVar:"AV15CurrentPage_Grid"});i.addRefreshingVar(this.GXValidFnc[36]);i.addRefreshingVar({rfrVar:"AV18HasNextPage_Grid"});i.addRefreshingVar({rfrVar:"AV17I_LoadCount_Grid"});i.addRefreshingVar({rfrVar:"AV32ApplicationId"});i.addRefreshingVar({rfrVar:"AV28PermissionId"});i.addRefreshingParm({rfrVar:"AV38GenericFilter_PreviousValue_Grid"});i.addRefreshingParm({rfrVar:"AV39Pgmname"});i.addRefreshingParm({rfrVar:"AV15CurrentPage_Grid"});i.addRefreshingParm(this.GXValidFnc[36]);i.addRefreshingParm({rfrVar:"AV18HasNextPage_Grid"});i.addRefreshingParm({rfrVar:"AV17I_LoadCount_Grid"});i.addRefreshingParm({rfrVar:"AV32ApplicationId"});i.addRefreshingParm({rfrVar:"AV28PermissionId"});this.Initialize();this.setSDTMapping("K2BGridState",{FilterValues:{sdt:"K2BGridState.FilterValue"}})})