gx.evt.autoSkip=!1;gx.define("products",!1,function(){this.ServerClass="products";this.PackageName="GeneXus.Programs";this.ServerFullClass="products.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){};this.Valid_Productsid=function(){return this.validSrvEvt("Valid_Productsid",0).then(function(n){return n}.closure(this))};this.e11011_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12011_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e13011_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e14011_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e15011_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e16011_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e17011_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Productsid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSID",fmt:0,gxz:"Z1productsId",gxold:"O1productsId",gxvar:"A1productsId",ucs:[],op:[44,39],ip:[44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1productsId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1productsId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRODUCTSID",gx.O.A1productsId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1productsId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRODUCTSID",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSNOMBRE",fmt:0,gxz:"Z2productsNombre",gxold:"O2productsNombre",gxvar:"A2productsNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2productsNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z2productsNombre=n)},v2c:function(){gx.fn.setControlValue("PRODUCTSNOMBRE",gx.O.A2productsNombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2productsNombre=this.val())},val:function(){return gx.fn.getControlValue("PRODUCTSNOMBRE")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSPRECIO",fmt:0,gxz:"Z3productsPrecio",gxold:"O3productsPrecio",gxvar:"A3productsPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A3productsPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3productsPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRODUCTSPRECIO",gx.O.A3productsPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A3productsPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRODUCTSPRECIO",",")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTN_ENTER",grid:0,evt:"e11011_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e12011_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTN_DELETE",grid:0,evt:"e18011_client",std:"DELETE"};this.A1productsId=0;this.Z1productsId=0;this.O1productsId=0;this.A2productsNombre="";this.Z2productsNombre="";this.O2productsNombre="";this.A3productsPrecio=0;this.Z3productsPrecio=0;this.O3productsPrecio=0;this.A1productsId=0;this.A2productsNombre="";this.A3productsPrecio=0;this.Events={e11011_client:["ENTER",!0],e12011_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_PRODUCTSID=[[{av:"A1productsId",fld:"PRODUCTSID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2productsNombre",fld:"PRODUCTSNOMBRE",pic:""},{av:"A3productsPrecio",fld:"PRODUCTSPRECIO",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z1productsId"},{av:"Z2productsNombre"},{av:"Z3productsPrecio"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.products)})