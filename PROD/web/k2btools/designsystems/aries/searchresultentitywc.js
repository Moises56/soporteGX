gx.evt.autoSkip=!1;gx.define("k2btools.designsystems.aries.searchresultentitywc",!0,function(n){var i,t;this.ServerClass="k2btools.designsystems.aries.searchresultentitywc";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2btools.designsystems.aries.searchresultentitywc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV26SearchCriteriaIn=gx.fn.getControlValue("vSEARCHCRITERIAIN");this.AV24ResultsEntities=gx.fn.getControlValue("vRESULTSENTITIES");this.AV25SearchCriteria=gx.fn.getControlValue("vSEARCHCRITERIA");this.AV11EntityName=gx.fn.getControlValue("vENTITYNAME");this.AV10EntityItemToSkip=gx.fn.getIntegerValue("vENTITYITEMTOSKIP",",");this.AV9EntityItemsProcessed=gx.fn.getIntegerValue("vENTITYITEMSPROCESSED",",");this.AV21PendingItemsExist=gx.fn.getControlValue("vPENDINGITEMSEXIST")};this.s122_client=function(){};this.s132_client=function(){this.AV25SearchCriteria=this.AV26SearchCriteriaIn};this.e11132_client=function(){return this.executeServerEvent("'E_NEXTPAGE'",!0,null,!1,!1)};this.e15132_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16132_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,9,10,11,13,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34];this.GXLastCtrlId=34;this.EntitiesresultsgridlargeContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Entitiesresultsgridlarge","Entitiesresultsgridlarge","EntitiesresultsgridlargeContainer",this.CmpContext,this.IsMasterPage,"k2btools.designsystems.aries.searchresultentitywc",[],!0,3,!1,!0,0,!1,!1,!1,"CollK2BSearchResult.Item",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"AV24ResultsEntities",!0,[1,1,2,3],!1,0,!1,!1);t=this.EntitiesresultsgridlargeContainer;t.startTable("Grid2table1",13,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(16,"Tablelarge","0px","0px");t.startDiv(17,"","0px","0px");t.startDiv(18,"","0px","0px");t.startDiv(19,"","0px","0px");t.addLabel();t.addBitmap("Ctlsearchresultimagelarge","CTLSEARCHRESULTIMAGELARGE",20,0,"",0,"",null,"","","K2BTools_SearchResultImage","");t.endDiv();t.endDiv();t.startDiv(21,"","0px","0px");t.startDiv(22,"Table2large","0px","0px");t.startDiv(23,"","0px","0px");t.startDiv(24,"","0px","0px");t.startDiv(25,"","0px","0px");t.addLabel();t.addSingleLineEdit("Searchresulttitle",26,"vSEARCHRESULTTITLE","","","SearchResultTitle","char",50,"chr",50,50,"start",null,[],"Searchresulttitle","SearchResultTitle",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endDiv();t.endDiv();t.startDiv(27,"","0px","0px");t.startDiv(28,"","0px","0px");t.startDiv(29,"","0px","0px");t.addLabel();t.addMultipleLineEdit("GXV3",30,"CTLSEARCHRESULTDESCRIPTIONLARGE","","SearchResultDescription","char",80,"chr",5,"row","400",400,"start",null,!0,!1,1,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endCell();t.endRow();t.endTable();this.EntitiesresultsgridlargeContainer.emptyText="";this.setGrid(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"NORESULTSFOUNDTABLE",grid:0};i[9]={id:9,fld:"NORESULTSFOUNDTEXTBLOCK",format:0,grid:0,ctrltype:"textblock"};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[13]={id:13,fld:"GRID2TABLE1",grid:12};i[16]={id:16,fld:"TABLELARGE",grid:12};i[17]={id:17,fld:"",grid:12};i[18]={id:18,fld:"",grid:12};i[19]={id:19,fld:"",grid:12};i[20]={id:20,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.EntitiesresultsgridlargeContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLSEARCHRESULTIMAGELARGE",fmt:0,gxz:"ZV30GXV2",gxold:"OV30GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30GXV2=n)},v2c:function(n){gx.fn.setGridMultimediaValue("CTLSEARCHRESULTIMAGELARGE",n||gx.fn.currentGridRowImpl(12),gx.O.GXV2,"")},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CTLSEARCHRESULTIMAGELARGE",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[21]={id:21,fld:"",grid:12};i[22]={id:22,fld:"TABLE2LARGE",grid:12};i[23]={id:23,fld:"",grid:12};i[24]={id:24,fld:"",grid:12};i[25]={id:25,fld:"",grid:12};i[26]={id:26,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.EntitiesresultsgridlargeContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCHRESULTTITLE",fmt:0,gxz:"ZV27SearchResultTitle",gxold:"OV27SearchResultTitle",gxvar:"AV27SearchResultTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV27SearchResultTitle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27SearchResultTitle=n)},v2c:function(n){gx.fn.setGridControlValue("vSEARCHRESULTTITLE",n||gx.fn.currentGridRowImpl(12),gx.O.AV27SearchResultTitle,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV27SearchResultTitle=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSEARCHRESULTTITLE",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[27]={id:27,fld:"",grid:12};i[28]={id:28,fld:"",grid:12};i[29]={id:29,fld:"",grid:12};i[30]={id:30,lvl:2,type:"char",len:400,dec:0,sign:!1,ro:1,isacc:0,multiline:!0,grid:12,gxgrid:this.EntitiesresultsgridlargeContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLSEARCHRESULTDESCRIPTIONLARGE",fmt:1,gxz:"ZV31GXV3",gxold:"OV31GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("CTLSEARCHRESULTDESCRIPTIONLARGE",n||gx.fn.currentGridRowImpl(12),gx.O.GXV3,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CTLSEARCHRESULTDESCRIPTIONLARGE",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[31]={id:31,fld:"",grid:0};i[32]={id:32,fld:"",grid:0};i[33]={id:33,fld:"",grid:0};i[34]={id:34,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNEXTPAGE_ACTION",fmt:0,gxz:"ZV20NextPage_Action",gxold:"OV20NextPage_Action",gxvar:"AV20NextPage_Action",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20NextPage_Action=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20NextPage_Action=n)},v2c:function(){gx.fn.setControlValue("vNEXTPAGE_ACTION",gx.O.AV20NextPage_Action,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20NextPage_Action=this.val())},val:function(){return gx.fn.getControlValue("vNEXTPAGE_ACTION")},nac:gx.falseFn,evt:"e11132_client"};this.ZV30GXV2="";this.OV30GXV2="";this.ZV27SearchResultTitle="";this.OV27SearchResultTitle="";this.ZV31GXV3="";this.OV31GXV3="";this.AV20NextPage_Action="";this.ZV20NextPage_Action="";this.OV20NextPage_Action="";this.AV20NextPage_Action="";this.AV26SearchCriteriaIn="";this.AV11EntityName="";this.GXV2="";this.AV27SearchResultTitle="";this.GXV3="";this.AV24ResultsEntities=[];this.AV25SearchCriteria="";this.AV10EntityItemToSkip=0;this.AV9EntityItemsProcessed=0;this.AV21PendingItemsExist=!1;this.Events={e11132_client:["'E_NEXTPAGE'",!0],e15132_client:["ENTER",!0],e16132_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage"},{av:"ENTITIESRESULTSGRIDLARGE_nEOF"},{av:"AV24ResultsEntities",fld:"vRESULTSENTITIES",grid:12,pic:""},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"nRC_GXsfl_12",ctrl:"ENTITIESRESULTSGRIDLARGE",prop:"GridRC",grid:12},{av:"sPrefix"},{av:"AV26SearchCriteriaIn",fld:"vSEARCHCRITERIAIN",pic:""},{av:"AV25SearchCriteria",fld:"vSEARCHCRITERIA",pic:"",hsh:!0}],[{av:"AV25SearchCriteria",fld:"vSEARCHCRITERIA",pic:"",hsh:!0}]];this.EvtParms["ENTITIESRESULTSGRIDLARGE.LOAD"]=[[{av:"AV24ResultsEntities",fld:"vRESULTSENTITIES",grid:12,pic:""},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage"},{av:"nRC_GXsfl_12",ctrl:"ENTITIESRESULTSGRIDLARGE",prop:"GridRC",grid:12}],[{av:"AV27SearchResultTitle",fld:"vSEARCHRESULTTITLE",pic:""},{av:'gx.fn.getCtrlProperty("vSEARCHRESULTTITLE","Link")',ctrl:"vSEARCHRESULTTITLE",prop:"Link"}]];this.EvtParms["'E_NEXTPAGE'"]=[[{av:"AV25SearchCriteria",fld:"vSEARCHCRITERIA",pic:"",hsh:!0},{av:"AV11EntityName",fld:"vENTITYNAME",pic:""},{av:"AV10EntityItemToSkip",fld:"vENTITYITEMTOSKIP",pic:"ZZZ9"},{av:"AV9EntityItemsProcessed",fld:"vENTITYITEMSPROCESSED",pic:"ZZZ9"},{av:"AV24ResultsEntities",fld:"vRESULTSENTITIES",grid:12,pic:""},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage"},{av:"nRC_GXsfl_12",ctrl:"ENTITIESRESULTSGRIDLARGE",prop:"GridRC",grid:12},{av:"AV21PendingItemsExist",fld:"vPENDINGITEMSEXIST",pic:""},{av:"ENTITIESRESULTSGRIDLARGE_nEOF"},{av:"sPrefix"},{av:"AV26SearchCriteriaIn",fld:"vSEARCHCRITERIAIN",pic:""}],[{av:"AV24ResultsEntities",fld:"vRESULTSENTITIES",grid:12,pic:""},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage"},{av:"nRC_GXsfl_12",ctrl:"ENTITIESRESULTSGRIDLARGE",prop:"GridRC",grid:12},{av:"AV21PendingItemsExist",fld:"vPENDINGITEMSEXIST",pic:""},{av:"AV9EntityItemsProcessed",fld:"vENTITYITEMSPROCESSED",pic:"ZZZ9"},{av:"AV10EntityItemToSkip",fld:"vENTITYITEMTOSKIP",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("ENTITIESRESULTSGRIDLARGE","Visible")',ctrl:"ENTITIESRESULTSGRIDLARGE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("NORESULTSFOUNDTABLE","Visible")',ctrl:"NORESULTSFOUNDTABLE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNEXTPAGE_ACTION","Visible")',ctrl:"vNEXTPAGE_ACTION",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV26SearchCriteriaIn","vSEARCHCRITERIAIN",0,"char",150,0);this.setVCMap("AV24ResultsEntities","vRESULTSENTITIES",0,"CollK2BSearchResult.Item",0,0);this.setVCMap("AV25SearchCriteria","vSEARCHCRITERIA",0,"char",150,0);this.setVCMap("AV11EntityName","vENTITYNAME",0,"char",20,0);this.setVCMap("AV10EntityItemToSkip","vENTITYITEMTOSKIP",0,"int",4,0);this.setVCMap("AV9EntityItemsProcessed","vENTITYITEMSPROCESSED",0,"int",4,0);this.setVCMap("AV21PendingItemsExist","vPENDINGITEMSEXIST",0,"boolean",4,0);this.setVCMap("AV26SearchCriteriaIn","vSEARCHCRITERIAIN",0,"char",150,0);this.setVCMap("AV24ResultsEntities","vRESULTSENTITIES",0,"CollK2BSearchResult.Item",0,0);this.setVCMap("AV26SearchCriteriaIn","vSEARCHCRITERIAIN",0,"char",150,0);this.setVCMap("AV24ResultsEntities","vRESULTSENTITIES",0,"CollK2BSearchResult.Item",0,0);t.addRefreshingVar({rfrVar:"AV26SearchCriteriaIn"});t.addRefreshingVar({rfrVar:"AV24ResultsEntities"});t.addRefreshingVar({rfrVar:"AV25SearchCriteria"});t.addRefreshingParm({rfrVar:"AV26SearchCriteriaIn"});t.addRefreshingParm({rfrVar:"AV24ResultsEntities"});t.addRefreshingParm({rfrVar:"AV25SearchCriteria"});this.addGridBCProperty("Resultsentities",["SearchResultImage"],this.GXValidFnc[20],"AV24ResultsEntities");this.addGridBCProperty("Resultsentities",["SearchResultDescription"],this.GXValidFnc[30],"AV24ResultsEntities");this.Initialize()})