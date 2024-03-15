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
namespace GeneXus.Programs.k2btools.designsystems.aries {
   public class viewallnotifications : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public viewallnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public viewallnotifications( IGxContext context )
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
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp = new GXCombobox();
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp = new GXCheckbox();
         chkavNotificationisread = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridgetallnotificationsforcurrentuserdp") == 0 )
            {
               gxnrGridgetallnotificationsforcurrentuserdp_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridgetallnotificationsforcurrentuserdp") == 0 )
            {
               gxgrGridgetallnotificationsforcurrentuserdp_refresh_invoke( ) ;
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

      protected void gxnrGridgetallnotificationsforcurrentuserdp_newrow_invoke( )
      {
         nRC_GXsfl_65 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_65"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_65_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_65_idx = GetPar( "sGXsfl_65_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridgetallnotificationsforcurrentuserdp_newrow( ) ;
         /* End function gxnrGridgetallnotificationsforcurrentuserdp_newrow_invoke */
      }

      protected void gxgrGridgetallnotificationsforcurrentuserdp_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
         AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_GridGetAllNotificationsForCurrentUserDP"), "."), 18, MidpointRounding.ToEven));
         AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( GetPar( "HasNextPage_GridGetAllNotificationsForCurrentUserDP"));
         AV32Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV27GridConfiguration);
         AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_GridGetAllNotificationsForCurrentUserDP"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridgetallnotificationsforcurrentuserdp_refresh( AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP, AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP, AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, AV32Pgmname, AV27GridConfiguration, AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP, AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridgetallnotificationsforcurrentuserdp_refresh_invoke */
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
            return "viewallnotifications_Execute" ;
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
         PA102( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START102( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2btools.designsystems.aries.viewallnotifications.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_65", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_65), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV27GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV27GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, context));
         GxWebStd.gx_hidden_field( context, "subGridgetallnotificationsforcurrentuserdp_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible), 5, 0, ".", "")));
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
            WE102( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT102( ) ;
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
         return formatLink("k2btools.designsystems.aries.viewallnotifications.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BTools.DesignSystems.Aries.ViewAllNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return "View All Notifications" ;
      }

      protected void WB100( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notifications", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table7_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Grid Settings", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11101_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Internalname, divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Internalname, "Grid Settings", "", "", lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname, "Rows per page", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_65_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0)), 1, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname, "Freeze column titles", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_65_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname, StringUtil.BoolToStr( AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP), "", "Freeze column titles", 1, chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(65), 2, 0)+","+"null"+");", "Apply", bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Jsonclick, 5, "Apply", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridgetallnotificationsforcurrentuserdpContainer.SetWrapped(nGXWrapped);
            StartGridControl65( ) ;
         }
         if ( wbEnd == 65 )
         {
            wbEnd = 0;
            nRC_GXsfl_65 = (int)(nGXsfl_65_idx-1);
            if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridgetallnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetallnotificationsforcurrentuserdp", GridgetallnotificationsforcurrentuserdpContainer, subGridgetallnotificationsforcurrentuserdp_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetallnotificationsforcurrentuserdpContainerData", GridgetallnotificationsforcurrentuserdpContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridgetallnotificationsforcurrentuserdpContainerData"+"V", GridgetallnotificationsforcurrentuserdpContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetallnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetallnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_74_102( true) ;
         }
         else
         {
            wb_table1_74_102( false) ;
         }
         return  ;
      }

      protected void wb_table1_74_102e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_gridgetallnotificationsforcurrentuserdp_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Internalname, divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12101_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13101_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12101_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, "", "", lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14101_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14101_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
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
         if ( wbEnd == 65 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridgetallnotificationsforcurrentuserdpContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridgetallnotificationsforcurrentuserdp", GridgetallnotificationsforcurrentuserdpContainer, subGridgetallnotificationsforcurrentuserdp_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetallnotificationsforcurrentuserdpContainerData", GridgetallnotificationsforcurrentuserdpContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridgetallnotificationsforcurrentuserdpContainerData"+"V", GridgetallnotificationsforcurrentuserdpContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridgetallnotificationsforcurrentuserdpContainerData"+"V"+"\" value='"+GridgetallnotificationsforcurrentuserdpContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START102( )
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
         Form.Meta.addItem("description", "View All Notifications", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP100( ) ;
      }

      protected void WS102( )
      {
         START102( ) ;
         EVT102( ) ;
      }

      protected void EVT102( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(GridGetAllNotificationsForCurrentUserDP)' */
                              E15102 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 47), "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 44), "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_OPEN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_MARKASREAD'") == 0 ) )
                           {
                              nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
                              SubsflControlProps_652( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV14NotificationId = 0;
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV14NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV14NotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV14NotificationId), 15, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9"), context));
                              }
                              AV16NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri("", false, edtavNotificationtext_Internalname, AV16NotificationText);
                              AV8EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri("", false, edtavEventtargeturl_Internalname, AV8EventTargetUrl);
                              GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( AV8EventTargetUrl, "")), context));
                              AV15NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri("", false, chkavNotificationisread_Internalname, AV15NotificationIsRead);
                              AV17Open_Action = cgiGet( edtavOpen_action_Internalname);
                              AssignAttri("", false, edtavOpen_action_Internalname, AV17Open_Action);
                              AV11MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignAttri("", false, edtavMarkasread_action_Internalname, AV11MarkAsRead_Action);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E17102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_OPEN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Open' */
                                    E18102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_MARKASREAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_MarkAsRead' */
                                    E19102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E20102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21102 ();
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

      protected void WE102( )
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

      protected void PA102( )
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
               GX_FocusControl = cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridgetallnotificationsforcurrentuserdp_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_652( ) ;
         while ( nGXsfl_65_idx <= nRC_GXsfl_65 )
         {
            sendrow_652( ) ;
            nGXsfl_65_idx = ((subGridgetallnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_65_idx+1>subGridgetallnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridgetallnotificationsforcurrentuserdpContainer)) ;
         /* End function gxnrGridgetallnotificationsforcurrentuserdp_newrow */
      }

      protected void gxgrGridgetallnotificationsforcurrentuserdp_refresh( GxSimpleCollection<string> AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP ,
                                                                          short AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP ,
                                                                          bool AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP ,
                                                                          string AV32Pgmname ,
                                                                          SdtK2BGridConfiguration AV27GridConfiguration ,
                                                                          short AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP ,
                                                                          GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP ,
                                                                          bool AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord = 0;
         RF102( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridgetallnotificationsforcurrentuserdp_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "vEVENTTARGETURL", AV8EventTargetUrl);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14NotificationId), 15, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname, "Values", cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.ToJavascriptSource(), true);
         }
         AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( StringUtil.BoolToStr( AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP));
         AssignAttri("", false, "AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP", AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E17102 ();
         RF102( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV32Pgmname = "K2BTools.DesignSystems.Aries.ViewAllNotifications";
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_65_Refreshing);
      }

      protected void RF102( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridgetallnotificationsforcurrentuserdpContainer.ClearRows();
         }
         wbStart = 65;
         /* Execute user event: Refresh */
         E17102 ();
         E20102 ();
         nGXsfl_65_idx = 1;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         bGXsfl_65_Refreshing = true;
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetallnotificationsforcurrentuserdp");
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
         GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
         GridgetallnotificationsforcurrentuserdpContainer.PageSize = subGridgetallnotificationsforcurrentuserdp_fnc_Recordsperpage( );
         if ( subGridgetallnotificationsforcurrentuserdp_Islastpage != 0 )
         {
            GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage = (long)(subGridgetallnotificationsforcurrentuserdp_fnc_Recordcount( )-subGridgetallnotificationsforcurrentuserdp_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage), 15, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage", GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_652( ) ;
            E21102 ();
            wbEnd = 65;
            WB100( ) ;
         }
         bGXsfl_65_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes102( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( AV8EventTargetUrl, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, context));
      }

      protected int subGridgetallnotificationsforcurrentuserdp_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetallnotificationsforcurrentuserdp_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetallnotificationsforcurrentuserdp_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridgetallnotificationsforcurrentuserdp_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV32Pgmname = "K2BTools.DesignSystems.Aries.ViewAllNotifications";
         edtavNotificationid_Enabled = 0;
         AssignProp("", false, edtavNotificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationid_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavNotificationtext_Enabled = 0;
         AssignProp("", false, edtavNotificationtext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationtext_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavEventtargeturl_Enabled = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         chkavNotificationisread.Enabled = 0;
         AssignProp("", false, chkavNotificationisread_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavNotificationisread.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavOpen_action_Enabled = 0;
         AssignProp("", false, edtavOpen_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOpen_action_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtavMarkasread_action_Enabled = 0;
         AssignProp("", false, edtavMarkasread_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMarkasread_action_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP100( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16102 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_65 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_65"), ".", ","), 18, MidpointRounding.ToEven));
            AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP"), ".", ","), 18, MidpointRounding.ToEven));
            AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP"), ".", ","), 18, MidpointRounding.ToEven));
            AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP"));
            subGridgetallnotificationsforcurrentuserdp_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridgetallnotificationsforcurrentuserdp_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.Name = cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname;
            cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname);
            AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
            AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname));
            AssignAttri("", false, "AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP", AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP);
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
         E16102 ();
         if (returnInSub) return;
      }

      protected void E16102( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bloadrowsperpage(context ).execute(  AV32Pgmname,  "GridGetAllNotificationsForCurrentUserDP", out  AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP, out  AV19RowsPerPageLoaded_GridGetAllNotificationsForCurrentUserDP) ;
         AssignAttri("", false, "AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         if ( ! AV19RowsPerPageLoaded_GridGetAllNotificationsForCurrentUserDP )
         {
            AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP = 20;
            AssignAttri("", false, "AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         }
         AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP = AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP;
         AssignAttri("", false, "AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         subGridgetallnotificationsforcurrentuserdp_Backcolorstyle = 3;
         divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
      }

      protected void E17102( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         if ( (0==AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP) )
         {
            AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         }
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S132 ();
         if (returnInSub) return;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Internalname, "Class", divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridConfiguration", AV27GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E18102( )
      {
         /* 'E_Open' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPEN' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridConfiguration", AV27GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
      }

      protected void S152( )
      {
         /* 'U_OPEN' Routine */
         returnInSub = false;
         AV31TargetUrl = AV8EventTargetUrl;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV31TargetUrl) );
         context.wjLocDisableFrm = 0;
      }

      protected void E19102( )
      {
         /* 'E_MarkAsRead' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridConfiguration", AV27GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
      }

      protected void S162( )
      {
         /* 'U_MARKASREAD' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV14NotificationId), out  AV20Success, out  AV13Messages) ;
         if ( AV20Success )
         {
            context.CommitDataStores("k2btools.designsystems.aries.viewallnotifications",pr_default);
         }
         else
         {
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV13Messages.Count )
            {
               AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV13Messages.Item(AV33GXV1));
               new GeneXus.Core.genexus.common.SdtLog(context).error("Error marking notification as read: "+AV12Message.gxTpr_Id+" - "+AV12Message.gxTpr_Description, "K2BTools.Notifications.ViewAllNotifications") ;
               AV33GXV1 = (int)(AV33GXV1+1);
            }
            context.RollbackDataStores("k2btools.designsystems.aries.viewallnotifications",pr_default);
         }
         gxgrGridgetallnotificationsforcurrentuserdp_refresh( AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP, AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP, AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, AV32Pgmname, AV27GridConfiguration, AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP, AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP) ;
      }

      protected void E20102( )
      {
         /* Gridgetallnotificationsforcurrentuserdp_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP) ;
         subGridgetallnotificationsforcurrentuserdp_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S182 ();
         if (returnInSub) return;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Internalname, "Class", divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class, true);
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridConfiguration", AV27GridConfiguration);
      }

      protected void S172( )
      {
         /* 'U_GRIDREFRESH(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
      }

      private void E21102( )
      {
         /* Gridgetallnotificationsforcurrentuserdp_Load Routine */
         returnInSub = false;
         AV10I_LoadCount_GridGetAllNotificationsForCurrentUserDP = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification2 = AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP;
         new GeneXus.Programs.k2btools.integrationprocedures.getallnotificationsforcurrentuserdp(context ).execute(  AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP,  (AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP-1)*(AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP), out  GXt_objcol_SdtWebNotificationSDT_Notification2) ;
         AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP = GXt_objcol_SdtWebNotificationSDT_Notification2;
         if ( AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP.Count == 0 )
         {
            tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP.Count == 0 ) || ( AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP.Count < AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP ) )
         {
            AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP = false;
            AssignAttri("", false, "AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, context));
         }
         else
         {
            AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP = true;
            AssignAttri("", false, "AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP);
            GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP", GetSecureSignedToken( "", AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, context));
         }
         AV34GXV2 = 1;
         while ( AV34GXV2 <= AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP.Count )
         {
            AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP.Item(AV34GXV2));
            AV10I_LoadCount_GridGetAllNotificationsForCurrentUserDP = (short)(AV10I_LoadCount_GridGetAllNotificationsForCurrentUserDP+1);
            AV14NotificationId = AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP.gxTpr_Notificationid;
            AssignAttri("", false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV14NotificationId), 15, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9"), context));
            AV16NotificationText = AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP.gxTpr_Notificationtext;
            AssignAttri("", false, edtavNotificationtext_Internalname, AV16NotificationText);
            AV8EventTargetUrl = AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP.gxTpr_Eventtargeturl;
            AssignAttri("", false, edtavEventtargeturl_Internalname, AV8EventTargetUrl);
            GxWebStd.gx_hidden_field( context, "gxhash_vEVENTTARGETURL"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( AV8EventTargetUrl, "")), context));
            AV15NotificationIsRead = false;
            AssignAttri("", false, chkavNotificationisread_Internalname, AV15NotificationIsRead);
            AV17Open_Action = "Open";
            AssignAttri("", false, edtavOpen_action_Internalname, AV17Open_Action);
            AV11MarkAsRead_Action = "Mark as read";
            AssignAttri("", false, edtavMarkasread_action_Internalname, AV11MarkAsRead_Action);
            /* Execute user subroutine: 'U_LOADROWVARS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
            S192 ();
            if (returnInSub) return;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 65;
            }
            sendrow_652( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_65_Refreshing )
            {
               context.DoAjaxLoad(65, GridgetallnotificationsforcurrentuserdpRow);
            }
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP", AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP);
      }

      protected void S192( )
      {
         /* 'U_LOADROWVARS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         AV15NotificationIsRead = AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP.gxTpr_Notificationisread;
         AssignAttri("", false, chkavNotificationisread_Internalname, AV15NotificationIsRead);
         AV17Open_Action = AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP.gxTpr_Notificationactioncaption;
         AssignAttri("", false, edtavOpen_action_Internalname, AV17Open_Action);
         edtavEventtargeturl_Visible = 0;
         AssignProp("", false, edtavEventtargeturl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEventtargeturl_Visible), 5, 0), !bGXsfl_65_Refreshing);
      }

      protected void S182( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = StringUtil.Str( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Caption", lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, true);
         lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, true);
         if ( (0==AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP) || ( AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            if ( AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP == 2 )
            {
               lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
               if ( AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP )
         {
            lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class, true);
            lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         if ( ( AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP <= 1 ) && ! AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP )
         {
            divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV32Pgmname,  "GridGetAllNotificationsForCurrentUserDP", ref  AV27GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' */
         S202 ();
         if (returnInSub) return;
      }

      protected void S202( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)' Routine */
         returnInSub = false;
         AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP = AV27GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP", AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP);
         if ( AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP) ;
         }
      }

      protected void E15102( )
      {
         /* 'SaveGridSettings(GridGetAllNotificationsForCurrentUserDP)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV32Pgmname,  "GridGetAllNotificationsForCurrentUserDP", ref  AV27GridConfiguration) ;
         AV27GridConfiguration.gxTpr_Freezecolumntitles = AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP;
         new k2bsavegridconfiguration(context ).execute(  AV32Pgmname,  "GridGetAllNotificationsForCurrentUserDP",  AV27GridConfiguration,  true) ;
         if ( AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP != AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP )
         {
            AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP = AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP;
            AssignAttri("", false, "AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV32Pgmname,  "GridGetAllNotificationsForCurrentUserDP",  AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP) ;
            AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP = 1;
            AssignAttri("", false, "AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         }
         gxgrGridgetallnotificationsforcurrentuserdp_refresh( AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP, AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP, AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP, AV32Pgmname, AV27GridConfiguration, AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP, AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP, AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP) ;
         divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridConfiguration", AV27GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP", AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP);
      }

      protected void wb_table1_74_102( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname, tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\ViewAllNotifications.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_74_102e( true) ;
         }
         else
         {
            wb_table1_74_102e( false) ;
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
         PA102( ) ;
         WS102( ) ;
         WE102( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138153991", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/viewallnotifications.js", "?20243138153991", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_652( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_65_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_65_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_65_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_65_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_65_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_65_idx;
      }

      protected void SubsflControlProps_fel_652( )
      {
         edtavNotificationid_Internalname = "vNOTIFICATIONID_"+sGXsfl_65_fel_idx;
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT_"+sGXsfl_65_fel_idx;
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL_"+sGXsfl_65_fel_idx;
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD_"+sGXsfl_65_fel_idx;
         edtavOpen_action_Internalname = "vOPEN_ACTION_"+sGXsfl_65_fel_idx;
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION_"+sGXsfl_65_fel_idx;
      }

      protected void sendrow_652( )
      {
         SubsflControlProps_652( ) ;
         WB100( ) ;
         GridgetallnotificationsforcurrentuserdpRow = GXWebRow.GetNew(context,GridgetallnotificationsforcurrentuserdpContainer);
         if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridgetallnotificationsforcurrentuserdp_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridgetallnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Odd";
            }
         }
         else if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridgetallnotificationsforcurrentuserdp_Backstyle = 0;
            subGridgetallnotificationsforcurrentuserdp_Backcolor = subGridgetallnotificationsforcurrentuserdp_Allbackcolor;
            if ( StringUtil.StrCmp(subGridgetallnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Uniform";
            }
         }
         else if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridgetallnotificationsforcurrentuserdp_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridgetallnotificationsforcurrentuserdp_Class, "") != 0 )
            {
               subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Odd";
            }
            subGridgetallnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
         }
         else if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridgetallnotificationsforcurrentuserdp_Backstyle = 1;
            if ( ((int)((nGXsfl_65_idx) % (2))) == 0 )
            {
               subGridgetallnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetallnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Even";
               }
            }
            else
            {
               subGridgetallnotificationsforcurrentuserdp_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridgetallnotificationsforcurrentuserdp_Class, "") != 0 )
               {
                  subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Odd";
               }
            }
         }
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_65_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14NotificationId), 15, 0, ".", "")),StringUtil.LTrim( ((edtavNotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV14NotificationId), "ZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtavNotificationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"K2BTools\\K2BT_LargeId",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,(string)AV16NotificationText,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationtext_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavNotificationtext_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)10000,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"K2BTools\\K2BT_NotificationMessage",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavEventtargeturl_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,(string)AV8EventTargetUrl,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)AV8EventTargetUrl,(string)"_blank",(string)"",(string)"",(string)edtavEventtargeturl_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavEventtargeturl_Visible,(int)edtavEventtargeturl_Enabled,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_65_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_65_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV15NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV15NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV15NotificationIsRead);
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV15NotificationIsRead),(string)"",(string)"",(short)-1,chkavNotificationisread.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,69);\"" : " ")});
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 70,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOpen_action_Internalname,StringUtil.RTrim( AV17Open_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOpen_action_Enabled!=0)&&(edtavOpen_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,70);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_OPEN\\'."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOpen_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavOpen_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 71,'',false,'"+sGXsfl_65_idx+"',65)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridgetallnotificationsforcurrentuserdpRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMarkasread_action_Internalname,StringUtil.RTrim( AV11MarkAsRead_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,71);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_MARKASREAD\\'."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMarkasread_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavMarkasread_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes102( ) ;
         GridgetallnotificationsforcurrentuserdpContainer.AddRow(GridgetallnotificationsforcurrentuserdpRow);
         nGXsfl_65_idx = ((subGridgetallnotificationsforcurrentuserdp_Islastpage==1)&&(nGXsfl_65_idx+1>subGridgetallnotificationsforcurrentuserdp_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         /* End function sendrow_652 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.Name = "vGRIDSETTINGSROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.WebTags = "";
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.ItemCount > 0 )
         {
            AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP", StringUtil.LTrimStr( (decimal)(AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP), 4, 0));
         }
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Name = "vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.WebTags = "";
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname, "TitleCaption", chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Caption, true);
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.CheckedValue = "false";
         AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP = StringUtil.StrToBool( StringUtil.BoolToStr( AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP));
         AssignAttri("", false, "AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP", AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP);
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_65_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp("", false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_65_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         AV15NotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( AV15NotificationIsRead));
         AssignAttri("", false, chkavNotificationisread_Internalname, AV15NotificationIsRead);
         /* End function init_web_controls */
      }

      protected void StartGridControl65( )
      {
         if ( GridgetallnotificationsforcurrentuserdpContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridgetallnotificationsforcurrentuserdpContainer"+"DivS\" data-gxgridid=\"65\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridgetallnotificationsforcurrentuserdp_Internalname, subGridgetallnotificationsforcurrentuserdp_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 0 )
            {
               subGridgetallnotificationsforcurrentuserdp_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridgetallnotificationsforcurrentuserdp_Class) > 0 )
               {
                  subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Title";
               }
            }
            else
            {
               subGridgetallnotificationsforcurrentuserdp_Titlebackstyle = 1;
               if ( subGridgetallnotificationsforcurrentuserdp_Backcolorstyle == 1 )
               {
                  subGridgetallnotificationsforcurrentuserdp_Titlebackcolor = subGridgetallnotificationsforcurrentuserdp_Allbackcolor;
                  if ( StringUtil.Len( subGridgetallnotificationsforcurrentuserdp_Class) > 0 )
                  {
                     subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridgetallnotificationsforcurrentuserdp_Class) > 0 )
                  {
                     subGridgetallnotificationsforcurrentuserdp_Linesclass = subGridgetallnotificationsforcurrentuserdp_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "NotificationId") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification text") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavEventtargeturl_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "EventTargetUrl") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Is read?") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetallnotificationsforcurrentuserdp");
         }
         else
         {
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("GridName", "Gridgetallnotificationsforcurrentuserdp");
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Header", subGridgetallnotificationsforcurrentuserdp_Header);
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Backcolorstyle), 1, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Sortable), 1, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("CmpContext", "");
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("InMasterPage", "false");
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14NotificationId), 15, 0, ".", ""))));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationid_Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV16NotificationText));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationtext_Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV8EventTargetUrl));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEventtargeturl_Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEventtargeturl_Visible), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV15NotificationIsRead)));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavNotificationisread.Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV17Open_Action)));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOpen_action_Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV11MarkAsRead_Action)));
            GridgetallnotificationsforcurrentuserdpColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Enabled), 5, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddColumnProperties(GridgetallnotificationsforcurrentuserdpColumn);
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Selectedindex), 4, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Allowselection), 1, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Selectioncolor), 9, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Allowhovering), 1, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Hoveringcolor), 9, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Allowcollapsing), 1, 0, ".", "")));
            GridgetallnotificationsforcurrentuserdpContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridgetallnotificationsforcurrentuserdp_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_LABELGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDPRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divRowsperpagecontainer_gridgetallnotificationsforcurrentuserdp_Internalname = "ROWSPERPAGECONTAINER_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname = "vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divFreezecolumntitlescontainer_gridgetallnotificationsforcurrentuserdp_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_SAVEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDPCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_gridgetallnotificationsforcurrentuserdp_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDPCONTENTINNERTABLE";
         divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divGridsettings_globaltable_gridgetallnotificationsforcurrentuserdp_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table7_gridgetallnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE7_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table10_gridgetallnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE10_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         edtavNotificationid_Internalname = "vNOTIFICATIONID";
         edtavNotificationtext_Internalname = "vNOTIFICATIONTEXT";
         edtavEventtargeturl_Internalname = "vEVENTTARGETURL";
         chkavNotificationisread_Internalname = "vNOTIFICATIONISREAD";
         edtavOpen_action_Internalname = "vOPEN_ACTION";
         edtavMarkasread_action_Internalname = "vMARKASREAD_ACTION";
         lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname = "I_NORESULTSFOUNDTABLENAME_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Internalname = "MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_section8_gridgetallnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_SECTION8_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_table3_gridgetallnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_TABLE3_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divLayoutdefined_grid_inner_gridgetallnotificationsforcurrentuserdp_Internalname = "LAYOUTDEFINED_GRID_INNER_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divGridcomponentcontent_gridgetallnotificationsforcurrentuserdp_Internalname = "GRIDCOMPONENTCONTENT_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridgetallnotificationsforcurrentuserdp_Internalname = "GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridgetallnotificationsforcurrentuserdp_Allowcollapsing = 0;
         subGridgetallnotificationsforcurrentuserdp_Allowselection = 0;
         subGridgetallnotificationsforcurrentuserdp_Header = "";
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Caption = "Freeze column titles";
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Visible = -1;
         edtavMarkasread_action_Enabled = 1;
         edtavOpen_action_Jsonclick = "";
         edtavOpen_action_Visible = -1;
         edtavOpen_action_Enabled = 1;
         chkavNotificationisread.Caption = "";
         chkavNotificationisread.Visible = -1;
         chkavNotificationisread.Enabled = 1;
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationtext_Jsonclick = "";
         edtavNotificationtext_Visible = -1;
         edtavNotificationtext_Enabled = 1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 0;
         edtavNotificationid_Enabled = 1;
         subGridgetallnotificationsforcurrentuserdp_Class = "K2BT_SG Grid_WorkWith";
         subGridgetallnotificationsforcurrentuserdp_Backcolorstyle = 0;
         edtavEventtargeturl_Visible = 0;
         tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible = 1;
         subGridgetallnotificationsforcurrentuserdp_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption = "#";
         lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption = "1";
         lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible = 1;
         divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class = "Section_Grid";
         chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp.Enabled = 1;
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp.Enabled = 1;
         divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "View All Notifications";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("'E_OPEN'","{handler:'E18102',iparms:[{av:'AV8EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV14NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_OPEN'",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("'E_MARKASREAD'","{handler:'E19102',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV14NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_MARKASREAD'",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.REFRESH","{handler:'E20102',iparms:[{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''}]");
         setEventMetadata("GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.REFRESH",",oparms:[{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'subGridgetallnotificationsforcurrentuserdp_Backcolorstyle',ctrl:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.LOAD","{handler:'E21102',iparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true}]");
         setEventMetadata("GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV14NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9',hsh:true},{av:'AV16NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV8EventTargetUrl',fld:'vEVENTTARGETURL',pic:'',hsh:true},{av:'AV15NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV17Open_Action',fld:'vOPEN_ACTION',pic:''},{av:'AV11MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavEventtargeturl_Visible',ctrl:'vEVENTTARGETURL',prop:'Visible'},{av:'lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E13101',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E12101',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E14101',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E11101',iparms:[{av:'divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp'},{av:'AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'","{handler:'E15102',iparms:[{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage'},{av:'GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF'},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP',fld:'vHASNEXTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP',fld:'vDP_SDT_ITEM_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'',hsh:true},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp'},{av:'AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vGRIDSETTINGSROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP)'",",oparms:[{av:'AV27GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP',fld:'vROWSPERPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP',fld:'vCURRENTPAGE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Visible'},{av:'divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',prop:'Class'},{av:'AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP',fld:'vFREEZECOLUMNTITLES_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''},{av:'AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP',fld:'vCLASSCOLLECTION_GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP',pic:''}]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Markasread_action',iparms:[]");
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
         AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP = new GxSimpleCollection<string>();
         AV32Pgmname = "";
         AV27GridConfiguration = new SdtK2BGridConfiguration(context);
         AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_gximage = "";
         sImgUrl = "";
         imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         GridgetallnotificationsforcurrentuserdpContainer = new GXWebGrid( context);
         sStyleString = "";
         lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16NotificationText = "";
         AV8EventTargetUrl = "";
         AV17Open_Action = "";
         AV11MarkAsRead_Action = "";
         AV31TargetUrl = "";
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char1 = "";
         AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test");
         GXt_objcol_SdtWebNotificationSDT_Notification2 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test");
         GridgetallnotificationsforcurrentuserdpRow = new GXWebRow();
         lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridgetallnotificationsforcurrentuserdp_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridgetallnotificationsforcurrentuserdpColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2btools.designsystems.aries.viewallnotifications__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2btools.designsystems.aries.viewallnotifications__default(),
            new Object[][] {
            }
         );
         AV32Pgmname = "K2BTools.DesignSystems.Aries.ViewAllNotifications";
         /* GeneXus formulas. */
         AV32Pgmname = "K2BTools.DesignSystems.Aries.ViewAllNotifications";
         edtavNotificationid_Enabled = 0;
         edtavNotificationtext_Enabled = 0;
         edtavEventtargeturl_Enabled = 0;
         chkavNotificationisread.Enabled = 0;
         edtavOpen_action_Enabled = 0;
         edtavMarkasread_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV5CurrentPage_GridGetAllNotificationsForCurrentUserDP ;
      private short AV18RowsPerPage_GridGetAllNotificationsForCurrentUserDP ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV29GridSettingsRowsPerPage_GridGetAllNotificationsForCurrentUserDP ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridgetallnotificationsforcurrentuserdp_Backcolorstyle ;
      private short subGridgetallnotificationsforcurrentuserdp_Sortable ;
      private short GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nEOF ;
      private short AV10I_LoadCount_GridGetAllNotificationsForCurrentUserDP ;
      private short nGXWrapped ;
      private short subGridgetallnotificationsforcurrentuserdp_Backstyle ;
      private short subGridgetallnotificationsforcurrentuserdp_Titlebackstyle ;
      private short subGridgetallnotificationsforcurrentuserdp_Allowselection ;
      private short subGridgetallnotificationsforcurrentuserdp_Allowhovering ;
      private short subGridgetallnotificationsforcurrentuserdp_Allowcollapsing ;
      private short subGridgetallnotificationsforcurrentuserdp_Collapsed ;
      private int divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Visible ;
      private int nRC_GXsfl_65 ;
      private int subGridgetallnotificationsforcurrentuserdp_Recordcount ;
      private int nGXsfl_65_idx=1 ;
      private int divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Visible ;
      private int lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Visible ;
      private int subGridgetallnotificationsforcurrentuserdp_Islastpage ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavOpen_action_Enabled ;
      private int edtavMarkasread_action_Enabled ;
      private int AV33GXV1 ;
      private int tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Visible ;
      private int AV34GXV2 ;
      private int edtavEventtargeturl_Visible ;
      private int idxLst ;
      private int subGridgetallnotificationsforcurrentuserdp_Backcolor ;
      private int subGridgetallnotificationsforcurrentuserdp_Allbackcolor ;
      private int edtavNotificationid_Visible ;
      private int edtavNotificationtext_Visible ;
      private int edtavOpen_action_Visible ;
      private int edtavMarkasread_action_Visible ;
      private int subGridgetallnotificationsforcurrentuserdp_Titlebackcolor ;
      private int subGridgetallnotificationsforcurrentuserdp_Selectedindex ;
      private int subGridgetallnotificationsforcurrentuserdp_Selectioncolor ;
      private int subGridgetallnotificationsforcurrentuserdp_Hoveringcolor ;
      private long AV14NotificationId ;
      private long GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nCurrentRecord ;
      private long GRIDGETALLNOTIFICATIONSFORCURRENTUSERDP_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_65_idx="0001" ;
      private string AV32Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_grid_inner_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_table10_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_table7_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divGridsettings_globaltable_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string TempTags ;
      private string imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_gximage ;
      private string sImgUrl ;
      private string imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string imgGridsettings_labelgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string divGridsettings_contentoutertablegridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridgetallnotificationsforcurrentuserdpruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridgetallnotificationsforcurrentuserdpcustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string divFreezecolumntitlescontainer_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Internalname ;
      private string bttGridsettings_savegridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string divLayoutdefined_table3_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divMaingrid_responsivetable_gridgetallnotificationsforcurrentuserdp_Class ;
      private string sStyleString ;
      private string subGridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divLayoutdefined_section8_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string divPaginationbar_pagingcontainertable_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class ;
      private string lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_firstpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_previouspagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_currentpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Caption ;
      private string lblPaginationbar_nextpagetextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgridgetallnotificationsforcurrentuserdp_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationid_Internalname ;
      private string edtavNotificationtext_Internalname ;
      private string edtavEventtargeturl_Internalname ;
      private string chkavNotificationisread_Internalname ;
      private string AV17Open_Action ;
      private string edtavOpen_action_Internalname ;
      private string AV11MarkAsRead_Action ;
      private string edtavMarkasread_action_Internalname ;
      private string GXt_char1 ;
      private string tblI_noresultsfoundtablename_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Internalname ;
      private string lblI_noresultsfoundtextblock_gridgetallnotificationsforcurrentuserdp_Jsonclick ;
      private string sGXsfl_65_fel_idx="0001" ;
      private string subGridgetallnotificationsforcurrentuserdp_Class ;
      private string subGridgetallnotificationsforcurrentuserdp_Linesclass ;
      private string ROClassString ;
      private string edtavNotificationid_Jsonclick ;
      private string edtavNotificationtext_Jsonclick ;
      private string edtavEventtargeturl_Jsonclick ;
      private string GXCCtl ;
      private string edtavOpen_action_Jsonclick ;
      private string edtavMarkasread_action_Jsonclick ;
      private string subGridgetallnotificationsforcurrentuserdp_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9HasNextPage_GridGetAllNotificationsForCurrentUserDP ;
      private bool AV30FreezeColumnTitles_GridGetAllNotificationsForCurrentUserDP ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV15NotificationIsRead ;
      private bool bGXsfl_65_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19RowsPerPageLoaded_GridGetAllNotificationsForCurrentUserDP ;
      private bool gx_refresh_fired ;
      private bool AV20Success ;
      private string AV16NotificationText ;
      private string AV8EventTargetUrl ;
      private string AV31TargetUrl ;
      private GXWebGrid GridgetallnotificationsforcurrentuserdpContainer ;
      private GXWebRow GridgetallnotificationsforcurrentuserdpRow ;
      private GXWebColumn GridgetallnotificationsforcurrentuserdpColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_gridgetallnotificationsforcurrentuserdp ;
      private GXCheckbox chkavFreezecolumntitles_gridgetallnotificationsforcurrentuserdp ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV28ClassCollection_GridGetAllNotificationsForCurrentUserDP ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV6DP_SDT_GridGetAllNotificationsForCurrentUserDP ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV7DP_SDT_ITEM_GridGetAllNotificationsForCurrentUserDP ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
      private SdtK2BGridConfiguration AV27GridConfiguration ;
   }

   public class viewallnotifications__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class viewallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
