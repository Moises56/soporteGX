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
   public class wwconnections : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwconnections( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public wwconnections( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         nRC_GXsfl_102 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_102"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_102_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_102_idx = GetPar( "sGXsfl_102_idx");
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
         AV30FilName_PreviousValue = GetPar( "FilName_PreviousValue");
         AV31FilUserName_PreviousValue = GetPar( "FilUserName_PreviousValue");
         AV10FilName = GetPar( "FilName");
         AV12FilUserName = GetPar( "FilUserName");
         AV44Pgmname = GetPar( "Pgmname");
         AV7CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV17HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38GridConfiguration);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41ClassCollection_Grid);
         AV28RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV19I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV42FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV30FilName_PreviousValue, AV31FilUserName_PreviousValue, AV10FilName, AV12FilUserName, AV44Pgmname, AV7CurrentPage_Grid, AV17HasNextPage_Grid, AV38GridConfiguration, AV41ClassCollection_Grid, AV28RowsPerPage_Grid, AV19I_LoadCount_Grid, AV42FreezeColumnTitles_Grid) ;
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
            return "k2bsecurity_Execute" ;
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
         PA3D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3D2( ) ;
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
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwconnections.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV30FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILUSERNAME_PREVIOUSVALUE", StringUtil.RTrim( AV31FilUserName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILUSERNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31FilUserName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV17HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV17HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_102", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_102), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_GRID", AV39FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_GRID", AV39FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_GRID", StringUtil.RTrim( AV40DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV30FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILUSERNAME_PREVIOUSVALUE", StringUtil.RTrim( AV31FilUserName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILUSERNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31FilUserName_PreviousValue, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV41ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV41ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV38GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV38GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV17HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV17HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28RowsPerPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vFILNAME_Caption", StringUtil.RTrim( edtavFilname_Caption));
         GxWebStd.gx_hidden_field( context, "vFILUSERNAME_Caption", StringUtil.RTrim( edtavFilusername_Caption));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vFILNAME_Caption", StringUtil.RTrim( edtavFilname_Caption));
         GxWebStd.gx_hidden_field( context, "vFILUSERNAME_Caption", StringUtil.RTrim( edtavFilusername_Caption));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3D2( ) ;
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
         return formatLink("k2bfsg.wwconnections.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.WWConnections" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_RepositoryConnections", "") ;
      }

      protected void WB3D0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "start", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "K2BT_GAM_RepositoryConnections", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            GxWebStd.gx_div_end( context, "start", "top", "h1");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_onlydetailedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table11_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWConnections.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_k2bt_filtercaption_grid_Internalname, context.GetMessage( "K2BT_Filters", ""), "", "", lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_FilterToggleText", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV39FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV40DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, "FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable K2BT_EditableForm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_filname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, context.GetMessage( "K2BT_GAM_Name", ""), "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, StringUtil.RTrim( AV10FilName), StringUtil.RTrim( context.localUtil.Format( AV10FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WWConnections.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filusername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFilusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilusername_Internalname, context.GetMessage( "K2BT_GAM_Username", ""), "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilusername_Internalname, StringUtil.RTrim( AV12FilUserName), StringUtil.RTrim( context.localUtil.Format( AV12FilUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilusername_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilusername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WWConnections.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", context.GetMessage( "K2BT_GridSettingsLabel", ""), 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWConnections.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_Internalname, divGridsettings_contentoutertablegrid_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, context.GetMessage( "K2BT_GridSettingsLabel", ""), "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, context.GetMessage( "K2BT_RowsPerPage", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "", true, 0, "HLP_K2BFSG\\WWConnections.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, context.GetMessage( "K2BT_FreezeColumnTitles", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_102_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV42FreezeColumnTitles_Grid), "", context.GetMessage( "K2BT_FreezeColumnTitles", ""), 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(86, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,86);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_GridSettingsApply", ""), bttGridsettings_savegrid_Jsonclick, 5, context.GetMessage( "K2BT_GridSettingsApply", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWConnections.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_topright_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttNew_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_InsertAction", ""), bttNew_Jsonclick, 7, "", "", StyleString, ClassString, bttNew_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e133d1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WWConnections.htm");
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
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl102( ) ;
         }
         if ( wbEnd == 102 )
         {
            wbEnd = 0;
            nRC_GXsfl_102 = (int)(nGXsfl_102_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_110_3D2( true) ;
         }
         else
         {
            wb_table1_110_3D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_110_3D2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e143d1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e153d1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e143d1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e163d1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e163d1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
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
         if ( wbEnd == 102 )
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

      protected void START3D2( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_RepositoryConnections", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3D0( ) ;
      }

      protected void WS3D2( )
      {
         START3D2( ) ;
         EVT3D2( ) ;
      }

      protected void EVT3D2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E173D2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
                              SubsflControlProps_1022( ) ;
                              AV21Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV21Name);
                              AV25UserName = cgiGet( edtavUsername_Internalname);
                              AssignAttri("", false, edtavUsername_Internalname, AV25UserName);
                              AV36GenerateFile_Action = cgiGet( edtavGeneratefile_action_Internalname);
                              AssignAttri("", false, edtavGeneratefile_action_Internalname, AV36GenerateFile_Action);
                              AV35Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp("", false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV35Update_Action)) ? AV45Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV35Update_Action))), !bGXsfl_102_Refreshing);
                              AssignProp("", false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV35Update_Action), true);
                              AV37Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp("", false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete_Action)) ? AV46Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV37Delete_Action))), !bGXsfl_102_Refreshing);
                              AssignProp("", false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV37Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E183D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E193D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E203D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E213D2 ();
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

      protected void WE3D2( )
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

      protected void PA3D2( )
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
               GX_FocusControl = edtavFilname_Internalname;
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
         SubsflControlProps_1022( ) ;
         while ( nGXsfl_102_idx <= nRC_GXsfl_102 )
         {
            sendrow_1022( ) ;
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV30FilName_PreviousValue ,
                                       string AV31FilUserName_PreviousValue ,
                                       string AV10FilName ,
                                       string AV12FilUserName ,
                                       string AV44Pgmname ,
                                       short AV7CurrentPage_Grid ,
                                       bool AV17HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV38GridConfiguration ,
                                       GxSimpleCollection<string> AV41ClassCollection_Grid ,
                                       short AV28RowsPerPage_Grid ,
                                       short AV19I_LoadCount_Grid ,
                                       bool AV42FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV29GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV42FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV42FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV42FreezeColumnTitles_Grid", AV42FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E193D2 ();
         RF3D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "K2BFSG.WWConnections";
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_102_Refreshing);
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), !bGXsfl_102_Refreshing);
         edtavGeneratefile_action_Enabled = 0;
         AssignProp("", false, edtavGeneratefile_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGeneratefile_action_Enabled), 5, 0), !bGXsfl_102_Refreshing);
      }

      protected void RF3D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 102;
         /* Execute user event: Refresh */
         E193D2 ();
         E213D2 ();
         nGXsfl_102_idx = 1;
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         bGXsfl_102_Refreshing = true;
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
            SubsflControlProps_1022( ) ;
            E203D2 ();
            wbEnd = 102;
            WB3D0( ) ;
         }
         bGXsfl_102_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3D2( )
      {
         GxWebStd.gx_hidden_field( context, "vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV30FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILUSERNAME_PREVIOUSVALUE", StringUtil.RTrim( AV31FilUserName_PreviousValue));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILUSERNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31FilUserName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV17HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV17HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
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
         AV44Pgmname = "K2BFSG.WWConnections";
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_102_Refreshing);
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), !bGXsfl_102_Refreshing);
         edtavGeneratefile_action_Enabled = 0;
         AssignProp("", false, edtavGeneratefile_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGeneratefile_action_Enabled), 5, 0), !bGXsfl_102_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E183D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_GRID"), AV39FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_102 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_102"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40DeletedTag_Grid = cgiGet( "vDELETEDTAG_GRID");
            AV7CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV28RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            edtavFilname_Caption = cgiGet( "vFILNAME_Caption");
            edtavFilusername_Caption = cgiGet( "vFILUSERNAME_Caption");
            /* Read variables values. */
            AV10FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri("", false, "AV10FilName", AV10FilName);
            AV12FilUserName = cgiGet( edtavFilusername_Internalname);
            AssignAttri("", false, "AV12FilUserName", AV12FilUserName);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV29GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
            AV42FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV42FreezeColumnTitles_Grid", AV42FreezeColumnTitles_Grid);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV27Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV27Messages = GXt_objcol_SdtMessages_Message1;
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV27Messages.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV43GXV1));
            GX_msglist.addItem(AV20Message.gxTpr_Description);
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E183D2 ();
         if (returnInSub) return;
      }

      protected void E183D2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV44Pgmname,  "Grid", out  AV28RowsPerPage_Grid, out  AV32RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV28RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV28RowsPerPage_Grid), 4, 0));
         if ( ! AV32RowsPerPageLoaded_Grid )
         {
            AV28RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV28RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV28RowsPerPage_Grid), 4, 0));
         }
         AV29GridSettingsRowsPerPage_Grid = AV28RowsPerPage_Grid;
         AssignAttri("", false, "AV29GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV30FilName_PreviousValue = AV10FilName;
         AssignAttri("", false, "AV30FilName_PreviousValue", AV30FilName_PreviousValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30FilName_PreviousValue, "")), context));
         AV31FilUserName_PreviousValue = AV12FilUserName;
         AssignAttri("", false, "AV31FilUserName_PreviousValue", AV31FilUserName_PreviousValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vFILUSERNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31FilUserName_PreviousValue, "")), context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E193D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S142 ();
         if (returnInSub) return;
         if ( (0==AV7CurrentPage_Grid) )
         {
            AV7CurrentPage_Grid = 1;
            AssignAttri("", false, "AV7CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV30FilName_PreviousValue, AV10FilName) != 0 )
         {
            AV30FilName_PreviousValue = AV10FilName;
            AssignAttri("", false, "AV30FilName_PreviousValue", AV30FilName_PreviousValue);
            GxWebStd.gx_hidden_field( context, "gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30FilName_PreviousValue, "")), context));
            AV7CurrentPage_Grid = 1;
            AssignAttri("", false, "AV7CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV31FilUserName_PreviousValue, AV12FilUserName) != 0 )
         {
            AV31FilUserName_PreviousValue = AV12FilUserName;
            AssignAttri("", false, "AV31FilUserName_PreviousValue", AV31FilUserName_PreviousValue);
            GxWebStd.gx_hidden_field( context, "gxhash_vFILUSERNAME_PREVIOUSVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31FilUserName_PreviousValue, "")), context));
            AV7CurrentPage_Grid = 1;
            AssignAttri("", false, "AV7CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_Grid), 4, 0));
         }
         AV22Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV41ClassCollection_Grid) ;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV41ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ClassCollection_Grid", AV41ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38GridConfiguration", AV38GridConfiguration);
      }

      protected void S172( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'U_NEW' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","pConnectionName"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S242( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV7CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV7CurrentPage_Grid) || ( AV7CurrentPage_Grid <= 1 ) )
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
            if ( AV7CurrentPage_Grid == 2 )
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
               if ( AV7CurrentPage_Grid == 3 )
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
         if ( ! AV17HasNextPage_Grid )
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
         if ( ( AV7CurrentPage_Grid <= 1 ) && ! AV17HasNextPage_Grid )
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

      protected void S192( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV21Name))}, new string[] {"Mode","pConnectionName"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'U_GENERATEFILE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("XML")),UrlEncode(StringUtil.RTrim(AV21Name))}, new string[] {"Mode","pConnectionName"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV21Name))}, new string[] {"Mode","pConnectionName"}) );
         context.wjLocDisableFrm = 1;
      }

      private void E203D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV19I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV19I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         AV17HasNextPage_Grid = false;
         AssignAttri("", false, "AV17HasNextPage_Grid", AV17HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV17HasNextPage_Grid, context));
         AV9Exit_Grid = false;
         while ( true )
         {
            AV19I_LoadCount_Grid = (short)(AV19I_LoadCount_Grid+1);
            AssignAttri("", false, "AV19I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S222 ();
            if (returnInSub) return;
            AV36GenerateFile_Action = context.GetMessage( "K2BT_GAM_GenerateFile", "");
            AssignAttri("", false, edtavGeneratefile_action_Internalname, AV36GenerateFile_Action);
            edtavUpdate_action_gximage = "K2BActionUpdate";
            AV35Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
            AssignAttri("", false, edtavUpdate_action_Internalname, AV35Update_Action);
            AV45Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            edtavUpdate_action_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
            edtavDelete_action_gximage = "K2BActionDelete";
            AV37Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri("", false, edtavDelete_action_Internalname, AV37Delete_Action);
            AV46Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S232 ();
            if (returnInSub) return;
            if ( AV9Exit_Grid )
            {
               if (true) break;
            }
            if ( AV19I_LoadCount_Grid > AV28RowsPerPage_Grid * AV7CurrentPage_Grid )
            {
               AV17HasNextPage_Grid = true;
               AssignAttri("", false, "AV17HasNextPage_Grid", AV17HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV17HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV19I_LoadCount_Grid > AV28RowsPerPage_Grid * ( AV7CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 102;
               }
               sendrow_1022( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_102_Refreshing )
               {
                  context.DoAjaxLoad(102, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Filter", AV11Filter);
      }

      protected void S222( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV19I_LoadCount_Grid == 1 )
         {
            AV11Filter.gxTpr_Connectionname = AV10FilName;
            AV11Filter.gxTpr_Username = AV12FilUserName;
            AV13GAMRepositoryConnections = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getconnections(AV11Filter, out  AV8Errors);
         }
         if ( AV13GAMRepositoryConnections.Count >= AV19I_LoadCount_Grid )
         {
            AV21Name = ((GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection)AV13GAMRepositoryConnections.Item(AV19I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV21Name);
            AV25UserName = ((GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection)AV13GAMRepositoryConnections.Item(AV19I_LoadCount_Grid)).gxTpr_Username;
            AssignAttri("", false, edtavUsername_Internalname, AV25UserName);
         }
         else
         {
            AV9Exit_Grid = true;
         }
      }

      protected void S252( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV44Pgmname,  AV16GridStateKey, out  AV14GridState) ;
         AV14GridState.gxTpr_Currentpage = AV7CurrentPage_Grid;
         AV14GridState.gxTpr_Filtervalues.Clear();
         AV15GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV15GridStateFilterValue.gxTpr_Filtername = "FilName";
         AV15GridStateFilterValue.gxTpr_Value = AV10FilName;
         AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         AV15GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV15GridStateFilterValue.gxTpr_Filtername = "FilUserName";
         AV15GridStateFilterValue.gxTpr_Value = AV12FilUserName;
         AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV44Pgmname,  AV16GridStateKey,  AV14GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV16GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV44Pgmname,  AV16GridStateKey, out  AV14GridState) ;
         AV47GXV2 = 1;
         while ( AV47GXV2 <= AV14GridState.gxTpr_Filtervalues.Count )
         {
            AV15GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV14GridState.gxTpr_Filtervalues.Item(AV47GXV2));
            if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Filtername, "FilName") == 0 )
            {
               AV10FilName = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV10FilName", AV10FilName);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Filtername, "FilUserName") == 0 )
            {
               AV12FilUserName = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV12FilUserName", AV12FilUserName);
            }
            AV47GXV2 = (int)(AV47GXV2+1);
         }
         if ( AV14GridState.gxTpr_Currentpage > 0 )
         {
            AV7CurrentPage_Grid = AV14GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV7CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_Grid), 4, 0));
         }
      }

      protected void S272( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttNew_Visible = 1;
         AssignProp("", false, bttNew_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttNew_Visible), 5, 0), true);
      }

      protected void E173D2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV44Pgmname,  "Grid", ref  AV38GridConfiguration) ;
         AV38GridConfiguration.gxTpr_Freezecolumntitles = AV42FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV44Pgmname,  "Grid",  AV38GridConfiguration,  true) ;
         if ( AV28RowsPerPage_Grid != AV29GridSettingsRowsPerPage_Grid )
         {
            AV28RowsPerPage_Grid = AV29GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV28RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV28RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV44Pgmname,  "Grid",  AV28RowsPerPage_Grid) ;
            AV7CurrentPage_Grid = 1;
            AssignAttri("", false, "AV7CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV7CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV30FilName_PreviousValue, AV31FilUserName_PreviousValue, AV10FilName, AV12FilUserName, AV44Pgmname, AV7CurrentPage_Grid, AV17HasNextPage_Grid, AV38GridConfiguration, AV41ClassCollection_Grid, AV28RowsPerPage_Grid, AV19I_LoadCount_Grid, AV42FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38GridConfiguration", AV38GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ClassCollection_Grid", AV41ClassCollection_Grid);
      }

      protected void S262( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E213D2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S252 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S262 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39FilterTagsCollection_Grid", AV39FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38GridConfiguration", AV38GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ClassCollection_Grid", AV41ClassCollection_Grid);
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV39FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV33K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10FilName)) )
         {
            AV34K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilName";
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Description = edtavFilname_Caption;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV10FilName;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.RTrim( context.localUtil.Format( AV10FilName, ""));
            AV33K2BFilterValuesSDT_WebForm.Add(AV34K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilUserName)) )
         {
            AV34K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilUserName";
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Description = edtavFilusername_Caption;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV12FilUserName;
            AV34K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.RTrim( context.localUtil.Format( AV12FilUserName, ""));
            AV33K2BFilterValuesSDT_WebForm.Add(AV34K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = context.GetMessage( "K2BT_FilterSummaryEmptyState", "");
         ucFiltertagsusercontrol_grid.SendProperty(context, "", false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV33K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV39FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV44Pgmname,  "Filters",  AV33K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV39FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void S152( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S272 ();
         if (returnInSub) return;
      }

      protected void S232( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV44Pgmname,  "Grid", ref  AV38GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S282 ();
         if (returnInSub) return;
      }

      protected void S282( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV42FreezeColumnTitles_Grid = AV38GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV42FreezeColumnTitles_Grid", AV42FreezeColumnTitles_Grid);
         if ( AV42FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV41ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV41ClassCollection_Grid) ;
         }
      }

      protected void wb_table1_110_3D2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWConnections.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_110_3D2e( true) ;
         }
         else
         {
            wb_table1_110_3D2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA3D2( ) ;
         WS3D2( ) ;
         WE3D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221354156", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bfsg/wwconnections.js", "?202431221354161", false, true);
            context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1022( )
      {
         edtavName_Internalname = "vNAME_"+sGXsfl_102_idx;
         edtavUsername_Internalname = "vUSERNAME_"+sGXsfl_102_idx;
         edtavGeneratefile_action_Internalname = "vGENERATEFILE_ACTION_"+sGXsfl_102_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_102_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_102_idx;
      }

      protected void SubsflControlProps_fel_1022( )
      {
         edtavName_Internalname = "vNAME_"+sGXsfl_102_fel_idx;
         edtavUsername_Internalname = "vUSERNAME_"+sGXsfl_102_fel_idx;
         edtavGeneratefile_action_Internalname = "vGENERATEFILE_ACTION_"+sGXsfl_102_fel_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_102_fel_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_102_fel_idx;
      }

      protected void sendrow_1022( )
      {
         SubsflControlProps_1022( ) ;
         WB3D0( ) ;
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
            if ( ((int)((nGXsfl_102_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_102_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 103,'',false,'"+sGXsfl_102_idx+"',102)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV21Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,103);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e223d2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavUsername_Enabled!=0)&&(edtavUsername_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 104,'',false,'"+sGXsfl_102_idx+"',102)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsername_Internalname,StringUtil.RTrim( AV25UserName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsername_Enabled!=0)&&(edtavUsername_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,104);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsername_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavUsername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavGeneratefile_action_Enabled!=0)&&(edtavGeneratefile_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 105,'',false,'"+sGXsfl_102_idx+"',102)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGeneratefile_action_Internalname,StringUtil.RTrim( AV36GenerateFile_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavGeneratefile_action_Enabled!=0)&&(edtavGeneratefile_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,105);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e233d2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGeneratefile_action_Jsonclick,(short)7,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavGeneratefile_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 106,'',false,'',102)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class");
         StyleString = "";
         AV35Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV35Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV45Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV35Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35Update_Action)) ? AV45Update_action_GXI : context.PathToRelativeUrl( AV35Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Update",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUpdate_action_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e243d2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV35Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 107,'',false,'',102)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV37Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV46Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Delete_Action)) ? AV46Delete_action_GXI : context.PathToRelativeUrl( AV37Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavDelete_action_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e253d2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV37Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3D2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         /* End function sendrow_1022 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV29GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV42FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV42FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV42FreezeColumnTitles_Grid", AV42FreezeColumnTitles_Grid);
         /* End function init_web_controls */
      }

      protected void StartGridControl102( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"102\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Username", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV21Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV25UserName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsername_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV36GenerateFile_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGeneratefile_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV35Update_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV37Delete_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_action_Tooltiptext));
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
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         lblLayoutdefined_k2bt_filtercaption_grid_Internalname = "LAYOUTDEFINED_K2BT_FILTERCAPTION_GRID";
         Filtertagsusercontrol_grid_Internalname = "FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table11_grid_Internalname = "LAYOUTDEFINED_TABLE11_GRID";
         edtavFilname_Internalname = "vFILNAME";
         divTable_container_filname_Internalname = "TABLE_CONTAINER_FILNAME";
         edtavFilusername_Internalname = "vFILUSERNAME";
         divTable_container_filusername_Internalname = "TABLE_CONTAINER_FILUSERNAME";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = "LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = "LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         imgGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = "ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = "vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRID";
         bttNew_Internalname = "NEW";
         divActions_grid_topright_Internalname = "ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavName_Internalname = "vNAME";
         edtavUsername_Internalname = "vUSERNAME";
         edtavGeneratefile_action_Internalname = "vGENERATEFILE_ACTION";
         edtavUpdate_action_Internalname = "vUPDATE_ACTION";
         edtavDelete_action_Internalname = "vDELETE_ACTION";
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
         chkavFreezecolumntitles_grid.Caption = context.GetMessage( "K2BT_FreezeColumnTitles", "");
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_gximage = "";
         edtavDelete_action_Visible = -1;
         edtavDelete_action_Enabled = 1;
         edtavDelete_action_Tooltiptext = "";
         edtavUpdate_action_Jsonclick = "";
         edtavUpdate_action_gximage = "";
         edtavUpdate_action_Visible = -1;
         edtavUpdate_action_Enabled = 1;
         edtavUpdate_action_Tooltiptext = "";
         edtavGeneratefile_action_Jsonclick = "";
         edtavGeneratefile_action_Visible = -1;
         edtavGeneratefile_action_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Visible = -1;
         edtavUsername_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         edtavName_Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
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
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         bttNew_Visible = 1;
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         edtavFilusername_Jsonclick = "";
         edtavFilusername_Enabled = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         edtavFilusername_Caption = context.GetMessage( "K2BT_GAM_Username", "");
         edtavFilname_Caption = context.GetMessage( "K2BT_GAM_Name", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_RepositoryConnections", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_NEW'","{handler:'E133D1',iparms:[]");
         setEventMetadata("'E_NEW'",",oparms:[]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E143D1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E163D1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E243D2',iparms:[{av:'AV21Name',fld:'vNAME',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV21Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("'E_GENERATEFILE'","{handler:'E233D2',iparms:[{av:'AV21Name',fld:'vNAME',pic:''}]");
         setEventMetadata("'E_GENERATEFILE'",",oparms:[{av:'AV21Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E253D2',iparms:[{av:'AV21Name',fld:'vNAME',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV21Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E203D2',iparms:[{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV36GenerateFile_Action',fld:'vGENERATEFILE_ACTION',pic:''},{av:'AV35Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV37Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV21Name',fld:'vNAME',pic:''},{av:'AV25UserName',fld:'vUSERNAME',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E153D1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E123D1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV29GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E173D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV29GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV28RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV30FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV31FilUserName_PreviousValue',fld:'vFILUSERNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VNAME.CLICK","{handler:'E223D2',iparms:[{av:'AV21Name',fld:'vNAME',pic:''}]");
         setEventMetadata("VNAME.CLICK",",oparms:[{av:'AV21Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E213D2',iparms:[{av:'AV10FilName',fld:'vFILNAME',pic:''},{av:'edtavFilname_Caption',ctrl:'vFILNAME',prop:'Caption'},{av:'AV12FilUserName',fld:'vFILUSERNAME',pic:''},{av:'edtavFilusername_Caption',ctrl:'vFILUSERNAME',prop:'Caption'},{av:'AV44Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV17HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV39FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV38GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'NEW',prop:'Visible'},{av:'AV42FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV41ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E113D1',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete_action',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV30FilName_PreviousValue = "";
         AV31FilUserName_PreviousValue = "";
         AV10FilName = "";
         AV12FilUserName = "";
         AV44Pgmname = "";
         AV38GridConfiguration = new SdtK2BGridConfiguration(context);
         AV41ClassCollection_Grid = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV39FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV40DeletedTag_Grid = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick = "";
         lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         imgGridsettings_labelgrid_gximage = "";
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         bttNew_Jsonclick = "";
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
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV21Name = "";
         AV25UserName = "";
         AV36GenerateFile_Action = "";
         AV35Update_Action = "";
         AV45Update_action_GXI = "";
         AV37Delete_Action = "";
         AV46Delete_action_GXI = "";
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV11Filter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnectionFilter(context);
         AV13GAMRepositoryConnections = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection", "GeneXus.Programs");
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV16GridStateKey = "";
         AV14GridState = new SdtK2BGridState(context);
         AV15GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV34K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         AV44Pgmname = "K2BFSG.WWConnections";
         /* GeneXus formulas. */
         AV44Pgmname = "K2BFSG.WWConnections";
         edtavName_Enabled = 0;
         edtavUsername_Enabled = 0;
         edtavGeneratefile_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV7CurrentPage_Grid ;
      private short AV28RowsPerPage_Grid ;
      private short AV19I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short AV29GridSettingsRowsPerPage_Grid ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GRID_nEOF ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_102 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_102_idx=1 ;
      private int edtavFilname_Enabled ;
      private int edtavFilusername_Enabled ;
      private int bttNew_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavName_Enabled ;
      private int edtavUsername_Enabled ;
      private int edtavGeneratefile_action_Enabled ;
      private int AV43GXV1 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV47GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavUsername_Visible ;
      private int edtavGeneratefile_action_Visible ;
      private int edtavUpdate_action_Enabled ;
      private int edtavUpdate_action_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string edtavFilname_Caption ;
      private string edtavFilusername_Caption ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_102_idx="0001" ;
      private string AV30FilName_PreviousValue ;
      private string AV31FilUserName_PreviousValue ;
      private string AV10FilName ;
      private string AV12FilUserName ;
      private string AV44Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV40DeletedTag_Grid ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filtercontainersection_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlydetailedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_table11_grid_Internalname ;
      private string TempTags ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick ;
      private string lblLayoutdefined_k2bt_filtercaption_grid_Internalname ;
      private string lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_filname_Internalname ;
      private string edtavFilname_Internalname ;
      private string edtavFilname_Jsonclick ;
      private string divTable_container_filusername_Internalname ;
      private string edtavFilusername_Internalname ;
      private string edtavFilusername_Jsonclick ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string imgGridsettings_labelgrid_gximage ;
      private string imgGridsettings_labelgrid_Internalname ;
      private string imgGridsettings_labelgrid_Jsonclick ;
      private string divGridsettings_contentoutertablegrid_Internalname ;
      private string divGslayoutdefined_gridcontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_grid_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private string divFreezecolumntitlescontainer_grid_Internalname ;
      private string chkavFreezecolumntitles_grid_Internalname ;
      private string bttGridsettings_savegrid_Internalname ;
      private string bttGridsettings_savegrid_Jsonclick ;
      private string divActions_grid_topright_Internalname ;
      private string bttNew_Internalname ;
      private string bttNew_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
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
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV21Name ;
      private string edtavName_Internalname ;
      private string AV25UserName ;
      private string edtavUsername_Internalname ;
      private string AV36GenerateFile_Action ;
      private string edtavGeneratefile_action_Internalname ;
      private string edtavUpdate_action_Internalname ;
      private string edtavDelete_action_Internalname ;
      private string GXt_char2 ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavUpdate_action_gximage ;
      private string edtavUpdate_action_Tooltiptext ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sGXsfl_102_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavUsername_Jsonclick ;
      private string edtavGeneratefile_action_Jsonclick ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17HasNextPage_Grid ;
      private bool AV42FreezeColumnTitles_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_102_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV32RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV22Reload_Grid ;
      private bool AV9Exit_Grid ;
      private bool AV35Update_Action_IsBlob ;
      private bool AV37Delete_Action_IsBlob ;
      private string AV45Update_action_GXI ;
      private string AV46Delete_action_GXI ;
      private string AV16GridStateKey ;
      private string AV35Update_Action ;
      private string AV37Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV41ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection> AV13GAMRepositoryConnections ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV33K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV39FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnectionFilter AV11Filter ;
      private SdtK2BGridState AV14GridState ;
      private SdtK2BGridState_FilterValue AV15GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV34K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV38GridConfiguration ;
   }

}
