using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class addpermissionchildren : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public addpermissionchildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public addpermissionchildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ApplicationId ,
                           ref string aP1_PermissionId )
      {
         this.AV51ApplicationId = aP0_ApplicationId;
         this.AV24PermissionId = aP1_PermissionId;
         executePrivate();
         aP0_ApplicationId=this.AV51ApplicationId;
         aP1_PermissionId=this.AV24PermissionId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCheckall_grid = new GXCheckbox();
         chkavMultirowitemselected_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ApplicationId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ApplicationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ApplicationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV51ApplicationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51ApplicationId", StringUtil.LTrimStr( (decimal)(AV51ApplicationId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51ApplicationId), "ZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV24PermissionId = GetPar( "PermissionId");
                  AssignAttri("", false, "AV24PermissionId", AV24PermissionId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPERMISSIONID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24PermissionId, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_46 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_46"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_46_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_46_idx = GetPar( "sGXsfl_46_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         AV56GenericFilter_PreviousValue_Grid = GetPar( "GenericFilter_PreviousValue_Grid");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV37AllSelectedItems_Grid);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53ClassCollection_Grid);
         AV57Pgmname = GetPar( "Pgmname");
         AV15CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV27GenericFilter_Grid = GetPar( "GenericFilter_Grid");
         AV40CountSelectedItems_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CountSelectedItems_Grid"), "."), 18, MidpointRounding.ToEven));
         AV18HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         AV22Id = GetPar( "Id");
         AV23AppId = (long)(Math.Round(NumberUtil.Val( GetPar( "AppId"), "."), 18, MidpointRounding.ToEven));
         AV41Grid_SelectedRows = (short)(Math.Round(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."), 18, MidpointRounding.ToEven));
         AV17I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV51ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         AV24PermissionId = GetPar( "PermissionId");
         AV33CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV56GenericFilter_PreviousValue_Grid, AV37AllSelectedItems_Grid, AV53ClassCollection_Grid, AV57Pgmname, AV15CurrentPage_Grid, AV27GenericFilter_Grid, AV40CountSelectedItems_Grid, AV18HasNextPage_Grid, AV22Id, AV23AppId, AV41Grid_SelectedRows, AV17I_LoadCount_Grid, AV51ApplicationId, AV24PermissionId, AV33CheckAll_Grid) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "addpermissionchildren_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bt_masterpage", "GeneXus.Programs.k2bt_masterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA4P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4P2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 115740), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.addpermissionchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV51ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV24PermissionId))}, new string[] {"ApplicationId","PermissionId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV56GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPERMISSIONID", StringUtil.RTrim( AV24PermissionId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPERMISSIONID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24PermissionId, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_46", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_46), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV56GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56GenericFilter_PreviousValue_Grid, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV53ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV53ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vCOUNTSELECTEDITEMS_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40CountSelectedItems_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALLSELECTEDITEMS_GRID", AV37AllSelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALLSELECTEDITEMS_GRID", AV37AllSelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPERMISSIONID", StringUtil.RTrim( AV24PermissionId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPERMISSIONID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24PermissionId, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vMULTIROWHASNEXT_GRID", AV31MultiRowHasNext_Grid);
         GxWebStd.gx_hidden_field( context, "vMULTIROWITERATOR_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32MultiRowIterator_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDITEMS_GRID", AV38SelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDITEMS_GRID", AV38SelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vS_ID", StringUtil.RTrim( AV44S_Id));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFIELDVALUES_GRID", AV36FieldValues_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFIELDVALUES_GRID", AV36FieldValues_Grid);
         }
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4P2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.addpermissionchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV51ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV24PermissionId))}, new string[] {"ApplicationId","PermissionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.AddPermissionChildren" ;
      }

      public override string GetPgmdesc( )
      {
         return "Add permission children" ;
      }

      protected void WB4P0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercontainersection_grid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_onlygenericfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table9_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table8_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_SearchContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_46_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV27GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV27GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search...", edtavGenericfilter_grid_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\AddPermissionChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_grid_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegridcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_46_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_grid_Internalname, StringUtil.BoolToStr( AV33CheckAll_Grid), "", "", 1, chkavCheckall_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,45);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl46( ) ;
         }
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            nRC_GXsfl_46 = (int)(nGXsfl_46_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_54_4P2( true) ;
         }
         else
         {
            wb_table1_54_4P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_54_4P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_grid_Internalname, divPaginationbar_pagingcontainertable_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114p1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e134p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e134p1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_bottom_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddselected_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(46), 2, 0)+","+"null"+");", "Add selected", bttAddselected_Jsonclick, 5, "", "", StyleString, ClassString, bttAddselected_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ADDSELECTED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\AddPermissionChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4P2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_5-175581", 0) ;
            }
         }
         Form.Meta.addItem("description", "Add permission children", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4P0( ) ;
      }

      protected void WS4P2( )
      {
         START4P2( ) ;
         EVT4P2( ) ;
      }

      protected void EVT4P2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADDSELECTED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AddSelected' */
                              E144P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCHECKALL_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) )
                           {
                              nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
                              SubsflControlProps_462( ) ;
                              AV30MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
                              AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
                              AV20Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV20Name);
                              GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV20Name, "")), context));
                              AV21Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri("", false, edtavDsc_Internalname, AV21Dsc);
                              GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), context));
                              AV22Id = cgiGet( edtavId_Internalname);
                              AssignAttri("", false, edtavId_Internalname, AV22Id);
                              GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV22Id, "")), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPPID");
                                 GX_FocusControl = edtavAppid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV23AppId = 0;
                                 AssignAttri("", false, edtavAppid_Internalname, StringUtil.LTrimStr( (decimal)(AV23AppId), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vAPPID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV23AppId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavAppid_Internalname, StringUtil.LTrimStr( (decimal)(AV23AppId), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vAPPID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9"), context));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E164P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E174P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E184P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA4P2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGenericfilter_grid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_462( ) ;
         while ( nGXsfl_46_idx <= nRC_GXsfl_46 )
         {
            sendrow_462( ) ;
            nGXsfl_46_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV56GenericFilter_PreviousValue_Grid ,
                                       GXBaseCollection<SdtK2BSelectionItem> AV37AllSelectedItems_Grid ,
                                       GxSimpleCollection<string> AV53ClassCollection_Grid ,
                                       string AV57Pgmname ,
                                       short AV15CurrentPage_Grid ,
                                       string AV27GenericFilter_Grid ,
                                       short AV40CountSelectedItems_Grid ,
                                       bool AV18HasNextPage_Grid ,
                                       string AV22Id ,
                                       long AV23AppId ,
                                       short AV41Grid_SelectedRows ,
                                       short AV17I_LoadCount_Grid ,
                                       long AV51ApplicationId ,
                                       string AV24PermissionId ,
                                       bool AV33CheckAll_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Id, "")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.RTrim( AV22Id));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23AppId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Name, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAME", StringUtil.RTrim( AV20Name));
         GxWebStd.gx_hidden_field( context, "gxhash_vDSC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), context));
         GxWebStd.gx_hidden_field( context, "vDSC", StringUtil.RTrim( AV21Dsc));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV33CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV33CheckAll_Grid));
         AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E174P2 ();
         RF4P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV57Pgmname = "K2BFSG.AddPermissionChildren";
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavAppid_Enabled = 0;
         AssignProp("", false, edtavAppid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAppid_Enabled), 5, 0), !bGXsfl_46_Refreshing);
      }

      protected void RF4P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 46;
         /* Execute user event: Refresh */
         E174P2 ();
         E184P2 ();
         nGXsfl_46_idx = 1;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_462( ) ;
         bGXsfl_46_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_462( ) ;
            E194P2 ();
            wbEnd = 46;
            WB4P0( ) ;
         }
         bGXsfl_46_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4P2( )
      {
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV56GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV18HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV22Id, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPERMISSIONID", StringUtil.RTrim( AV24PermissionId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPERMISSIONID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24PermissionId, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV20Name, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV57Pgmname = "K2BFSG.AddPermissionChildren";
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavAppid_Enabled = 0;
         AssignProp("", false, edtavAppid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAppid_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
            AV15CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV18HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV27GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV27GenericFilter_Grid", AV27GenericFilter_Grid);
            AV33CheckAll_Grid = StringUtil.StrToBool( cgiGet( chkavCheckall_grid_Internalname));
            AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E164P2 ();
         if (returnInSub) return;
      }

      protected void E164P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bloadrowsperpage(context ).execute(  AV57Pgmname,  "Grid", out  AV54RowsPerPage_Grid, out  AV55RowsPerPageLoaded_Grid) ;
         if ( ! AV55RowsPerPageLoaded_Grid )
         {
            AV54RowsPerPage_Grid = 20;
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV56GenericFilter_PreviousValue_Grid = AV27GenericFilter_Grid;
         AssignAttri("", false, "AV56GenericFilter_PreviousValue_Grid", AV56GenericFilter_PreviousValue_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56GenericFilter_PreviousValue_Grid, "")), context));
         subGrid_Backcolorstyle = 3;
      }

      protected void E174P2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
         if ( (0==AV15CurrentPage_Grid) )
         {
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV56GenericFilter_PreviousValue_Grid, AV27GenericFilter_Grid) != 0 )
         {
            AV56GenericFilter_PreviousValue_Grid = AV27GenericFilter_Grid;
            AssignAttri("", false, "AV56GenericFilter_PreviousValue_Grid", AV56GenericFilter_PreviousValue_Grid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56GenericFilter_PreviousValue_Grid, "")), context));
            AV15CurrentPage_Grid = 1;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
         AV16Reload_Grid = true;
         if ( StringUtil.StrCmp(AV9HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
            S142 ();
            if (returnInSub) return;
            AV41Grid_SelectedRows = 0;
            AssignAttri("", false, "AV41Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV41Grid_SelectedRows), 4, 0));
         }
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV53ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV53ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53ClassCollection_Grid", AV53ClassCollection_Grid);
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E184P2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         AV41Grid_SelectedRows = 0;
         AssignAttri("", false, "AV41Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV41Grid_SelectedRows), 4, 0));
         if ( AV37AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV53ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV53ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV53ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S172 ();
         if (returnInSub) return;
         AV33CheckAll_Grid = false;
         AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53ClassCollection_Grid", AV53ClassCollection_Grid);
      }

      protected void S172( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E194P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV17I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         AV18HasNextPage_Grid = false;
         AssignAttri("", false, "AV18HasNextPage_Grid", AV18HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV18HasNextPage_Grid, context));
         AV19Exit_Grid = false;
         while ( true )
         {
            AV17I_LoadCount_Grid = (short)(AV17I_LoadCount_Grid+1);
            AssignAttri("", false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S192 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S202 ();
            if (returnInSub) return;
            if ( AV19Exit_Grid )
            {
               if (true) break;
            }
            if ( AV17I_LoadCount_Grid > 20 * AV15CurrentPage_Grid )
            {
               AV18HasNextPage_Grid = true;
               AssignAttri("", false, "AV18HasNextPage_Grid", AV18HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV18HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV17I_LoadCount_Grid > 20 * ( AV15CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               AV30MultiRowItemSelected_Grid = false;
               AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
               AV58GXV1 = 1;
               while ( AV58GXV1 <= AV37AllSelectedItems_Grid.Count )
               {
                  AV34SelectedItem_Grid = ((SdtK2BSelectionItem)AV37AllSelectedItems_Grid.Item(AV58GXV1));
                  if ( ( StringUtil.StrCmp(AV34SelectedItem_Grid.gxTpr_Skcharacter1, AV22Id) == 0 ) && ( AV34SelectedItem_Grid.gxTpr_Sknumeric1 == AV23AppId ) )
                  {
                     if ( AV34SelectedItem_Grid.gxTpr_Isselected )
                     {
                        AV30MultiRowItemSelected_Grid = true;
                        AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
                        AV41Grid_SelectedRows = (short)(AV41Grid_SelectedRows+1);
                        AssignAttri("", false, "AV41Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV41Grid_SelectedRows), 4, 0));
                     }
                     if (true) break;
                  }
                  AV58GXV1 = (int)(AV58GXV1+1);
               }
               if ( ((int)((AV17I_LoadCount_Grid) % (20))) == 1 )
               {
                  AV33CheckAll_Grid = true;
                  AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
               }
               if ( ! AV30MultiRowItemSelected_Grid )
               {
                  AV33CheckAll_Grid = false;
                  AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 46;
               }
               sendrow_462( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_46_Refreshing )
               {
                  context.DoAjaxLoad(46, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28Filter", AV28Filter);
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV17I_LoadCount_Grid == 1 )
         {
            AV25GAMApplication.load( AV51ApplicationId);
            AV23AppId = AV51ApplicationId;
            AssignAttri("", false, edtavAppid_Internalname, StringUtil.LTrimStr( (decimal)(AV23AppId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vAPPID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9"), context));
            AV28Filter.gxTpr_Name = "%"+AV27GenericFilter_Grid;
            AV26sdt = AV25GAMApplication.getunassignedpermissiontoparent(AV24PermissionId, AV28Filter, out  AV50Errors);
         }
         if ( AV26sdt.Count >= AV17I_LoadCount_Grid )
         {
            AV20Name = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV26sdt.Item(AV17I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV20Name);
            GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV20Name, "")), context));
            AV21Dsc = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV26sdt.Item(AV17I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri("", false, edtavDsc_Internalname, AV21Dsc);
            GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), context));
            AV22Id = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV26sdt.Item(AV17I_LoadCount_Grid)).gxTpr_Guid;
            AssignAttri("", false, edtavId_Internalname, AV22Id);
            GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sGXsfl_46_idx, StringUtil.RTrim( context.localUtil.Format( AV22Id, "")), context));
         }
         else
         {
            AV19Exit_Grid = true;
         }
      }

      protected void S202( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV15CurrentPage_Grid) || ( AV15CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV15CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV15CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV18HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV15CurrentPage_Grid <= 1 ) && ! AV18HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV57Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV11GridState.gxTpr_Currentpage = AV15CurrentPage_Grid;
         AV11GridState.gxTpr_Filtervalues.Clear();
         AV12GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV12GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV12GridStateFilterValue.gxTpr_Value = AV27GenericFilter_Grid;
         AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV57Pgmname,  AV10GridStateKey,  AV11GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV57Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV59GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV27GenericFilter_Grid = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27GenericFilter_Grid", AV27GenericFilter_Grid);
            }
            AV59GXV2 = (int)(AV59GXV2+1);
         }
         if ( AV11GridState.gxTpr_Currentpage > 0 )
         {
            AV15CurrentPage_Grid = AV11GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV15CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_Grid), 4, 0));
         }
      }

      protected void E144P2( )
      {
         /* 'E_AddSelected' Routine */
         returnInSub = false;
         AV38SelectedItems_Grid = AV37AllSelectedItems_Grid;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S222 ();
         if (returnInSub) return;
         if ( ! AV31MultiRowHasNext_Grid )
         {
            AV16Reload_Grid = false;
            new k2btoolsmsg(context ).execute(  "Error: You must select a row",  0) ;
         }
         else
         {
            /* Execute user subroutine: 'U_ADDSELECTED' */
            S232 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38SelectedItems_Grid", AV38SelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36FieldValues_Grid", AV36FieldValues_Grid);
      }

      protected void S232( )
      {
         /* 'U_ADDSELECTED' Routine */
         returnInSub = false;
         AV48isOK = true;
         AV25GAMApplication.load( AV51ApplicationId);
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S222 ();
         if (returnInSub) return;
         while ( AV31MultiRowHasNext_Grid )
         {
            AV48isOK = AV25GAMApplication.addpermissionchild(AV24PermissionId, AV44S_Id, out  AV50Errors);
            if ( ! AV48isOK )
            {
               AV60GXV3 = 1;
               while ( AV60GXV3 <= AV50Errors.Count )
               {
                  AV49Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV50Errors.Item(AV60GXV3));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV49Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV49Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV60GXV3 = (int)(AV60GXV3+1);
               }
               if (true) break;
            }
            /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
            S222 ();
            if (returnInSub) return;
         }
         if ( AV48isOK )
         {
            context.CommitDataStores("k2bfsg.addpermissionchildren",pr_default);
            context.setWebReturnParms(new Object[] {(long)AV51ApplicationId,(string)AV24PermissionId});
            context.setWebReturnParmsMetadata(new Object[] {"AV51ApplicationId","AV24PermissionId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV61GXV4 = 1;
            while ( AV61GXV4 <= AV50Errors.Count )
            {
               AV49Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV50Errors.Item(AV61GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV49Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV49Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV61GXV4 = (int)(AV61GXV4+1);
            }
         }
      }

      protected void S212( )
      {
         /* 'RESETMULTIROWITERATOR(GRID)' Routine */
         returnInSub = false;
         AV32MultiRowIterator_Grid = 1;
         AssignAttri("", false, "AV32MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_Grid), 4, 0));
      }

      protected void S222( )
      {
         /* 'GETNEXTMULTIROW(GRID)' Routine */
         returnInSub = false;
         AV42S_Name = "";
         AV43S_Dsc = "";
         AV44S_Id = "";
         AssignAttri("", false, "AV44S_Id", AV44S_Id);
         AV46S_AppId = 0;
         while ( ( AV32MultiRowIterator_Grid <= AV38SelectedItems_Grid.Count ) && ! ((SdtK2BSelectionItem)AV38SelectedItems_Grid.Item(AV32MultiRowIterator_Grid)).gxTpr_Isselected )
         {
            AV32MultiRowIterator_Grid = (short)(AV32MultiRowIterator_Grid+1);
            AssignAttri("", false, "AV32MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_Grid), 4, 0));
         }
         if ( AV32MultiRowIterator_Grid > AV38SelectedItems_Grid.Count )
         {
            AV31MultiRowHasNext_Grid = false;
            AssignAttri("", false, "AV31MultiRowHasNext_Grid", AV31MultiRowHasNext_Grid);
         }
         else
         {
            AV31MultiRowHasNext_Grid = true;
            AssignAttri("", false, "AV31MultiRowHasNext_Grid", AV31MultiRowHasNext_Grid);
            AV36FieldValues_Grid = ((SdtK2BSelectionItem)AV38SelectedItems_Grid.Item(AV32MultiRowIterator_Grid)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_GRID' */
            S302 ();
            if (returnInSub) return;
         }
         AV32MultiRowIterator_Grid = (short)(AV32MultiRowIterator_Grid+1);
         AssignAttri("", false, "AV32MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_Grid), 4, 0));
      }

      protected void E204P2( )
      {
         /* Multirowitemselected_grid_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(GRID)' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53ClassCollection_Grid", AV53ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37AllSelectedItems_Grid", AV37AllSelectedItems_Grid);
      }

      protected void S242( )
      {
         /* 'PROCESSSELECTION(GRID)' Routine */
         returnInSub = false;
         AV33CheckAll_Grid = true;
         AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
         /* Start For Each Line in Grid */
         nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_46_fel_idx = 0;
         while ( nGXsfl_46_fel_idx < nRC_GXsfl_46 )
         {
            nGXsfl_46_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_fel_idx+1);
            sGXsfl_46_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_462( ) ;
            AV30MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV20Name = cgiGet( edtavName_Internalname);
            AV21Dsc = cgiGet( edtavDsc_Internalname);
            AV22Id = cgiGet( edtavId_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPPID");
               GX_FocusControl = edtavAppid_Internalname;
               wbErr = true;
               AV23AppId = 0;
            }
            else
            {
               AV23AppId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
            S252 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_46_fel_idx == 0 )
         {
            nGXsfl_46_idx = 1;
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
         }
         nGXsfl_46_fel_idx = 1;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S292 ();
         if (returnInSub) return;
         if ( AV37AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV53ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV53ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV53ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
      }

      protected void E154P2( )
      {
         /* Checkall_grid_Click Routine */
         returnInSub = false;
         /* Start For Each Line in Grid */
         nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_46_fel_idx = 0;
         while ( nGXsfl_46_fel_idx < nRC_GXsfl_46 )
         {
            nGXsfl_46_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_fel_idx+1);
            sGXsfl_46_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_462( ) ;
            AV30MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV20Name = cgiGet( edtavName_Internalname);
            AV21Dsc = cgiGet( edtavDsc_Internalname);
            AV22Id = cgiGet( edtavId_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPPID");
               GX_FocusControl = edtavAppid_Internalname;
               wbErr = true;
               AV23AppId = 0;
            }
            else
            {
               AV23AppId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( AV30MultiRowItemSelected_Grid != AV33CheckAll_Grid )
            {
               AV30MultiRowItemSelected_Grid = AV33CheckAll_Grid;
               AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
               /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
               S252 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_46_fel_idx == 0 )
         {
            nGXsfl_46_idx = 1;
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
         }
         nGXsfl_46_fel_idx = 1;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S262 ();
         if (returnInSub) return;
         if ( AV40CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S272 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S292 ();
         if (returnInSub) return;
         if ( AV37AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV53ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV53ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV53ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53ClassCollection_Grid", AV53ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37AllSelectedItems_Grid", AV37AllSelectedItems_Grid);
      }

      protected void S252( )
      {
         /* 'UPDATESELECTION(GRID)' Routine */
         returnInSub = false;
         AV39Index_Grid = 1;
         while ( AV39Index_Grid <= AV37AllSelectedItems_Grid.Count )
         {
            if ( ( StringUtil.StrCmp(((SdtK2BSelectionItem)AV37AllSelectedItems_Grid.Item(AV39Index_Grid)).gxTpr_Skcharacter1, AV22Id) == 0 ) && ( ((SdtK2BSelectionItem)AV37AllSelectedItems_Grid.Item(AV39Index_Grid)).gxTpr_Sknumeric1 == AV23AppId ) )
            {
               AV37AllSelectedItems_Grid.RemoveItem(AV39Index_Grid);
            }
            else
            {
               AV39Index_Grid = (short)(AV39Index_Grid+1);
            }
         }
         if ( AV30MultiRowItemSelected_Grid )
         {
            AV34SelectedItem_Grid = new SdtK2BSelectionItem(context);
            AV34SelectedItem_Grid.gxTpr_Isselected = AV30MultiRowItemSelected_Grid;
            AV34SelectedItem_Grid.gxTpr_Skcharacter1 = AV22Id;
            AV34SelectedItem_Grid.gxTpr_Sknumeric1 = AV23AppId;
            AV35FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV35FieldValue_Grid.gxTpr_Name = "Name";
            AV35FieldValue_Grid.gxTpr_Value = AV20Name;
            AV34SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV35FieldValue_Grid, 0);
            AV35FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV35FieldValue_Grid.gxTpr_Name = "Dsc";
            AV35FieldValue_Grid.gxTpr_Value = AV21Dsc;
            AV34SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV35FieldValue_Grid, 0);
            AV35FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV35FieldValue_Grid.gxTpr_Name = "Id";
            AV35FieldValue_Grid.gxTpr_Value = AV22Id;
            AV34SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV35FieldValue_Grid, 0);
            AV35FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV35FieldValue_Grid.gxTpr_Name = "AppId";
            AV35FieldValue_Grid.gxTpr_Value = StringUtil.Str( (decimal)(AV23AppId), 12, 0);
            AV34SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV35FieldValue_Grid, 0);
            AV37AllSelectedItems_Grid.Add(AV34SelectedItem_Grid, 0);
         }
         if ( ! AV30MultiRowItemSelected_Grid )
         {
            AV33CheckAll_Grid = false;
            AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
         }
      }

      protected void S142( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S262 ();
         if (returnInSub) return;
         if ( AV40CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S272 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
      }

      protected void S272( )
      {
         /* 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 1;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S282( )
      {
         /* 'HIDEMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 0;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S292( )
      {
         /* 'U_MULTIROWITEMSELECTED(GRID)' Routine */
         returnInSub = false;
      }

      protected void S262( )
      {
         /* 'GETSELECTEDITEMSCOUNT_GRID' Routine */
         returnInSub = false;
         AV40CountSelectedItems_Grid = 0;
         AssignAttri("", false, "AV40CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV40CountSelectedItems_Grid), 4, 0));
         AV64GXV5 = 1;
         while ( AV64GXV5 <= AV37AllSelectedItems_Grid.Count )
         {
            AV34SelectedItem_Grid = ((SdtK2BSelectionItem)AV37AllSelectedItems_Grid.Item(AV64GXV5));
            if ( AV34SelectedItem_Grid.gxTpr_Isselected )
            {
               AV40CountSelectedItems_Grid = (short)(AV40CountSelectedItems_Grid+1);
               AssignAttri("", false, "AV40CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV40CountSelectedItems_Grid), 4, 0));
            }
            AV64GXV5 = (int)(AV64GXV5+1);
         }
      }

      protected void S302( )
      {
         /* 'GETFIELDVALUES_GRID' Routine */
         returnInSub = false;
         AV65GXV6 = 1;
         while ( AV65GXV6 <= AV36FieldValues_Grid.Count )
         {
            AV35FieldValue_Grid = ((SdtK2BSelectionItem_FieldValuesItem)AV36FieldValues_Grid.Item(AV65GXV6));
            if ( StringUtil.StrCmp(AV35FieldValue_Grid.gxTpr_Name, "Name") == 0 )
            {
               AV42S_Name = AV35FieldValue_Grid.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35FieldValue_Grid.gxTpr_Name, "Dsc") == 0 )
            {
               AV43S_Dsc = AV35FieldValue_Grid.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35FieldValue_Grid.gxTpr_Name, "Id") == 0 )
            {
               AV44S_Id = AV35FieldValue_Grid.gxTpr_Value;
               AssignAttri("", false, "AV44S_Id", AV44S_Id);
            }
            else if ( StringUtil.StrCmp(AV35FieldValue_Grid.gxTpr_Name, "AppId") == 0 )
            {
               AV46S_AppId = (long)(Math.Round(NumberUtil.Val( AV35FieldValue_Grid.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV65GXV6 = (int)(AV65GXV6+1);
         }
      }

      protected void wb_table1_54_4P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\AddPermissionChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_54_4P2e( true) ;
         }
         else
         {
            wb_table1_54_4P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV51ApplicationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV51ApplicationId", StringUtil.LTrimStr( (decimal)(AV51ApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51ApplicationId), "ZZZZZZZZZZZ9"), context));
         AV24PermissionId = (string)getParm(obj,1);
         AssignAttri("", false, "AV24PermissionId", AV24PermissionId);
         GxWebStd.gx_hidden_field( context, "gxhash_vPERMISSIONID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24PermissionId, "")), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA4P2( ) ;
         WS4P2( ) ;
         WE4P2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138203817", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("k2bfsg/addpermissionchildren.js", "?20243138203819", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_462( )
      {
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID_"+sGXsfl_46_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_46_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_46_idx;
         edtavId_Internalname = "vID_"+sGXsfl_46_idx;
         edtavAppid_Internalname = "vAPPID_"+sGXsfl_46_idx;
      }

      protected void SubsflControlProps_fel_462( )
      {
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID_"+sGXsfl_46_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_46_fel_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_46_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_46_fel_idx;
         edtavAppid_Internalname = "vAPPID_"+sGXsfl_46_fel_idx;
      }

      protected void sendrow_462( )
      {
         SubsflControlProps_462( ) ;
         WB4P0( ) ;
         GridRow = GXWebRow.GetNew(context,GridContainer);
         if ( subGrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
         }
         else if ( subGrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid_Backstyle = 0;
            subGrid_Backcolor = subGrid_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Uniform";
            }
         }
         else if ( subGrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
            subGrid_Backcolor = (int)(0x0);
         }
         else if ( subGrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( ((int)((nGXsfl_46_idx) % (2))) == 0 )
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Even";
               }
            }
            else
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_46_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 47,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_46_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_46_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         AV30MultiRowItemSelected_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV30MultiRowItemSelected_Grid));
         AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_grid_Internalname,StringUtil.BoolToStr( AV30MultiRowItemSelected_Grid),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,47);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 48,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV20Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,48);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 49,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV21Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,49);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 50,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV22Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,50);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavAppid_Enabled!=0)&&(edtavAppid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 51,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAppid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23AppId), 12, 0, ".", "")),StringUtil.LTrim( ((edtavAppid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23AppId), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavAppid_Enabled!=0)&&(edtavAppid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAppid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavAppid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes4P2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_46_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_462( ) ;
         /* End function sendrow_462 */
      }

      protected void init_web_controls( )
      {
         chkavCheckall_grid.Name = "vCHECKALL_GRID";
         chkavCheckall_grid.WebTags = "";
         chkavCheckall_grid.Caption = "";
         AssignProp("", false, chkavCheckall_grid_Internalname, "TitleCaption", chkavCheckall_grid.Caption, true);
         chkavCheckall_grid.CheckedValue = "false";
         AV33CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV33CheckAll_Grid));
         AssignAttri("", false, "AV33CheckAll_Grid", AV33CheckAll_Grid);
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_46_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_46_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         AV30MultiRowItemSelected_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV30MultiRowItemSelected_Grid));
         AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV30MultiRowItemSelected_Grid);
         /* End function init_web_controls */
      }

      protected void StartGridControl46( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"46\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV30MultiRowItemSelected_Grid)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV20Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV21Dsc)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV22Id)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23AppId), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAppid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         divLayoutdefined_table8_grid_Internalname = "LAYOUTDEFINED_TABLE8_GRID";
         divLayoutdefined_table9_grid_Internalname = "LAYOUTDEFINED_TABLE9_GRID";
         divLayoutdefined_onlygenericfilterlayout_grid_Internalname = "LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = "LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         divLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         chkavCheckall_grid_Internalname = "vCHECKALL_GRID";
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         edtavId_Internalname = "vID";
         edtavAppid_Internalname = "vAPPID";
         divTablegridcontainer_grid_Internalname = "TABLEGRIDCONTAINER_GRID";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = "LAYOUTDEFINED_SECTION8_GRID";
         bttAddselected_Internalname = "ADDSELECTED";
         divActions_grid_bottom_Internalname = "ACTIONS_GRID_BOTTOM";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavCheckall_grid.Caption = "";
         edtavAppid_Jsonclick = "";
         edtavAppid_Visible = 0;
         edtavAppid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavId_Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Visible = -1;
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         edtavName_Enabled = 1;
         chkavMultirowitemselected_grid.Caption = "";
         chkavMultirowitemselected_grid.Visible = -1;
         chkavMultirowitemselected_grid.Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         bttAddselected_Visible = 1;
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_grid_Visible = 1;
         chkavCheckall_grid.Enabled = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Add permission children";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E184P2',iparms:[{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E194P2',iparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV30MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV20Name',fld:'vNAME',pic:'',hsh:true},{av:'AV21Dsc',fld:'vDSC',pic:'',hsh:true},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E124P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E114P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E134P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV27GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV18HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV22Id',fld:'vID',pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV15CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV56GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV41Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("'E_ADDSELECTED'","{handler:'E144P2',iparms:[{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV31MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV32MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV38SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV51ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV24PermissionId',fld:'vPERMISSIONID',pic:'',hsh:true},{av:'AV44S_Id',fld:'vS_ID',pic:''},{av:'AV36FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''}]");
         setEventMetadata("'E_ADDSELECTED'",",oparms:[{av:'AV38SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV32MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV44S_Id',fld:'vS_ID',pic:''},{av:'AV36FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV31MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK","{handler:'E204P2',iparms:[{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22Id',fld:'vID',grid:46,pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID',grid:46,prop:'GridRC',grid:46},{av:'AV23AppId',fld:'vAPPID',grid:46,pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV30MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:46,pic:''},{av:'AV20Name',fld:'vNAME',grid:46,pic:'',hsh:true},{av:'AV21Dsc',fld:'vDSC',grid:46,pic:'',hsh:true},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'}]");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK",",oparms:[{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("VCHECKALL_GRID.CLICK","{handler:'E154P2',iparms:[{av:'AV30MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:46,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID',grid:46,prop:'GridRC',grid:46},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22Id',fld:'vID',grid:46,pic:'',hsh:true},{av:'AV23AppId',fld:'vAPPID',grid:46,pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV20Name',fld:'vNAME',grid:46,pic:'',hsh:true},{av:'AV21Dsc',fld:'vDSC',grid:46,pic:'',hsh:true}]");
         setEventMetadata("VCHECKALL_GRID.CLICK",",oparms:[{av:'AV30MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV53ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV37AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV33CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV40CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Appid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOAV24PermissionId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV56GenericFilter_PreviousValue_Grid = "";
         AV37AllSelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV53ClassCollection_Grid = new GxSimpleCollection<string>();
         AV57Pgmname = "";
         AV27GenericFilter_Grid = "";
         AV22Id = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV44S_Id = "";
         AV36FieldValues_Grid = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "test");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         bttAddselected_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV20Name = "";
         AV21Dsc = "";
         AV9HttpRequest = new GxHttpRequest( context);
         AV34SelectedItem_Grid = new SdtK2BSelectionItem(context);
         GridRow = new GXWebRow();
         AV28Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV25GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV26sdt = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV50Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GridStateKey = "";
         AV11GridState = new SdtK2BGridState(context);
         AV12GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV49Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV42S_Name = "";
         AV43S_Dsc = "";
         GXt_char1 = "";
         AV35FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addpermissionchildren__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addpermissionchildren__default(),
            new Object[][] {
            }
         );
         AV57Pgmname = "K2BFSG.AddPermissionChildren";
         /* GeneXus formulas. */
         AV57Pgmname = "K2BFSG.AddPermissionChildren";
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         edtavId_Enabled = 0;
         edtavAppid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15CurrentPage_Grid ;
      private short AV40CountSelectedItems_Grid ;
      private short AV41Grid_SelectedRows ;
      private short AV17I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV32MultiRowIterator_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV54RowsPerPage_Grid ;
      private short GRID_nEOF ;
      private short AV39Index_Grid ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_46 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_46_idx=1 ;
      private int edtavGenericfilter_grid_Enabled ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int bttAddselected_Visible ;
      private int subGrid_Islastpage ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int edtavAppid_Enabled ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV58GXV1 ;
      private int AV59GXV2 ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private int nGXsfl_46_fel_idx=1 ;
      private int AV64GXV5 ;
      private int AV65GXV6 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int edtavId_Visible ;
      private int edtavAppid_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV51ApplicationId ;
      private long wcpOAV51ApplicationId ;
      private long AV23AppId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private long AV46S_AppId ;
      private string AV24PermissionId ;
      private string wcpOAV24PermissionId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_46_idx="0001" ;
      private string AV56GenericFilter_PreviousValue_Grid ;
      private string AV57Pgmname ;
      private string AV27GenericFilter_Grid ;
      private string AV22Id ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV44S_Id ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filtercontainersection_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlygenericfilterlayout_grid_Internalname ;
      private string divLayoutdefined_table9_grid_Internalname ;
      private string divLayoutdefined_table8_grid_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_grid_Internalname ;
      private string edtavGenericfilter_grid_Jsonclick ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divTablegridcontainer_grid_Internalname ;
      private string chkavCheckall_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divLayoutdefined_section8_grid_Internalname ;
      private string divPaginationbar_pagingcontainertable_grid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Class ;
      private string lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private string lblPaginationbar_firstpagetextblockgrid_Caption ;
      private string lblPaginationbar_firstpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgrid_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagetextblockgrid_Caption ;
      private string lblPaginationbar_previouspagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private string lblPaginationbar_currentpagetextblockgrid_Caption ;
      private string lblPaginationbar_currentpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagetextblockgrid_Caption ;
      private string lblPaginationbar_nextpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Class ;
      private string divActions_grid_bottom_Internalname ;
      private string bttAddselected_Internalname ;
      private string bttAddselected_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_grid_Internalname ;
      private string AV20Name ;
      private string edtavName_Internalname ;
      private string AV21Dsc ;
      private string edtavDsc_Internalname ;
      private string edtavId_Internalname ;
      private string edtavAppid_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string AV42S_Name ;
      private string AV43S_Dsc ;
      private string sGXsfl_46_fel_idx="0001" ;
      private string GXt_char1 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavAppid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18HasNextPage_Grid ;
      private bool AV33CheckAll_Grid ;
      private bool AV31MultiRowHasNext_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV30MultiRowItemSelected_Grid ;
      private bool bGXsfl_46_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV55RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV16Reload_Grid ;
      private bool AV19Exit_Grid ;
      private bool AV48isOK ;
      private string AV10GridStateKey ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_ApplicationId ;
      private string aP1_PermissionId ;
      private GXCheckbox chkavCheckall_grid ;
      private GXCheckbox chkavMultirowitemselected_grid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV9HttpRequest ;
      private GxSimpleCollection<string> AV53ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV50Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV26sdt ;
      private GXBaseCollection<SdtK2BSelectionItem> AV37AllSelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem> AV38SelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV36FieldValues_Grid ;
      private GXWebForm Form ;
      private SdtK2BGridState AV11GridState ;
      private SdtK2BGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV25GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV49Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV28Filter ;
      private SdtK2BSelectionItem AV34SelectedItem_Grid ;
      private SdtK2BSelectionItem_FieldValuesItem AV35FieldValue_Grid ;
   }

   public class addpermissionchildren__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class addpermissionchildren__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
