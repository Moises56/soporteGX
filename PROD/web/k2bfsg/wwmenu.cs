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
   public class wwmenu : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public wwmenu( IGxContext context )
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
         cmbavApplicationid_filter = new GXCombobox();
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
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
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
         AV52GenericFilter_PreviousValue_Grid = GetPar( "GenericFilter_PreviousValue_Grid");
         AV9ApplicationId_Filter_PreviousValue = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId_Filter_PreviousValue"), "."), 18, MidpointRounding.ToEven));
         cmbavApplicationid_filter.FromJSonString( GetNextPar( ));
         AV8ApplicationId_Filter = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId_Filter"), "."), 18, MidpointRounding.ToEven));
         AV55Pgmname = GetPar( "Pgmname");
         AV16CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV48GenericFilter_Grid = GetPar( "GenericFilter_Grid");
         AV26HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49GridConfiguration);
         AV15CurrentApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CurrentApplicationId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV50ClassCollection_Grid);
         AV37RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV30MenuId = (long)(Math.Round(NumberUtil.Val( GetPar( "MenuId"), "."), 18, MidpointRounding.ToEven));
         AV28I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV9ApplicationId_Filter_PreviousValue, AV8ApplicationId_Filter, AV55Pgmname, AV16CurrentPage_Grid, AV48GenericFilter_Grid, AV26HasNextPage_Grid, AV49GridConfiguration, AV15CurrentApplicationId, AV50ClassCollection_Grid, AV37RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid) ;
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
         PA392( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START392( ) ;
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
         context.AddJavascriptSource("UserControls/K2BT_ConfirmDialogRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwmenu.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_PREVIOUSVALUE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId_Filter_PreviousValue), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID_FILTER_PREVIOUSVALUE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ApplicationId_Filter_PreviousValue), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_GRID", AV53FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_GRID", AV53FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_GRID", StringUtil.RTrim( AV54DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_PREVIOUSVALUE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId_Filter_PreviousValue), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID_FILTER_PREVIOUSVALUE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ApplicationId_Filter_PreviousValue), "ZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV49GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV49GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCONFIRMATIONREQUIRED", AV11ConfirmationRequired);
         GxWebStd.gx_hidden_field( context, "vCONFIRMATIONSUBID", StringUtil.RTrim( AV12ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "K2BT_CONFIRMDIALOG_Confirmmessage", StringUtil.RTrim( K2bt_confirmdialog_Confirmmessage));
         GxWebStd.gx_hidden_field( context, "K2BT_CONFIRMDIALOG_Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_Caption", StringUtil.RTrim( cmbavApplicationid_filter.Caption));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_Text", StringUtil.RTrim( cmbavApplicationid_filter.Description));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_Caption", StringUtil.RTrim( cmbavApplicationid_filter.Caption));
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
            WE392( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT392( ) ;
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
         return formatLink("k2bfsg.wwmenu.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.WWMenu" ;
      }

      public override string GetPgmdesc( )
      {
         return "Menus" ;
      }

      protected void WB390( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Menus", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table5_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_CombinedFiltersWrapper", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table1_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_SearchContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV48GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV48GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search...", edtavGenericfilter_grid_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\WWMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_combined_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_combined_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_combined_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11391_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV53FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV54DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, "FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, divLayoutdefined_filtercollapsiblesection_combined_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable K2BT_EditableForm", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTable_container_applicationid_filter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavApplicationid_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavApplicationid_filter_Internalname, "Application", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavApplicationid_filter, cmbavApplicationid_filter_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0)), 1, cmbavApplicationid_filter_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavApplicationid_filter.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_K2BFSG\\WWMenu.htm");
            cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
            AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", (string)(cmbavApplicationid_filter.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Grid Settings", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12391_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWMenu.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Grid Settings", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
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
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Rows per page", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_K2BFSG\\WWMenu.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
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
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, "Freeze column titles", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_107_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid), "", "Freeze column titles", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(83, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,83);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Apply", bttGridsettings_savegrid_Jsonclick, 5, "Apply", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWMenu.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddnew_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Add new", bttAddnew_Jsonclick, 5, "", "", StyleString, ClassString, bttAddnew_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ADDNEW\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWMenu.htm");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_gridassociatedleft_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLoadapplicationmenus_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Load application menus", bttLoadapplicationmenus_Jsonclick, 5, bttLoadapplicationmenus_Tooltiptext, "", StyleString, ClassString, bttLoadapplicationmenus_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_LOADAPPLICATIONMENUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
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
            wb_table1_117_392( true) ;
         }
         else
         {
            wb_table1_117_392( false) ;
         }
         return  ;
      }

      protected void wb_table1_117_392e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13391_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14391_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13391_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15391_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15391_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
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
            ucK2bt_confirmdialog.Render(context, "k2bt_confirmdialog", K2bt_confirmdialog_Internalname, "K2BT_CONFIRMDIALOGContainer");
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
         if ( wbEnd == 107 )
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

      protected void START392( )
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
         Form.Meta.addItem("description", "Menus", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP390( ) ;
      }

      protected void WS392( )
      {
         START392( ) ;
         EVT392( ) ;
      }

      protected void EVT392( )
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
                           else if ( StringUtil.StrCmp(sEvt, "K2BT_CONFIRMDIALOG.ONOKCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16392 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E17392 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADDNEW'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AddNew' */
                              E18392 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_LOADAPPLICATIONMENUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_LoadApplicationMenus' */
                              E19392 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'E_SETMAIN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'E_SETMAIN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMENUID");
                                 GX_FocusControl = edtavMenuid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV30MenuId = 0;
                                 AssignAttri("", false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
                              }
                              else
                              {
                                 AV30MenuId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
                              }
                              AV31MenuName = cgiGet( edtavMenuname_Internalname);
                              AssignAttri("", false, edtavMenuname_Internalname, AV31MenuName);
                              AV29MenuDescription = cgiGet( edtavMenudescription_Internalname);
                              AssignAttri("", false, edtavMenudescription_Internalname, AV29MenuDescription);
                              AV38SetMain_Action = cgiGet( edtavSetmain_action_Internalname);
                              AssignAttri("", false, edtavSetmain_action_Internalname, AV38SetMain_Action);
                              AV34Options_Action = cgiGet( edtavOptions_action_Internalname);
                              AssignAttri("", false, edtavOptions_action_Internalname, AV34Options_Action);
                              AV46Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp("", false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)) ? AV59Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV46Update_Action))), !bGXsfl_107_Refreshing);
                              AssignProp("", false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV46Update_Action), true);
                              AV47Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp("", false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)) ? AV60Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV47Delete_Action))), !bGXsfl_107_Refreshing);
                              AssignProp("", false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV47Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E20392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E21392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E23392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_UPDATE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Update' */
                                    E24392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Delete' */
                                    E25392 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_SETMAIN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_SetMain' */
                                    E26392 ();
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

      protected void WE392( )
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

      protected void PA392( )
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
         SubsflControlProps_1072( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1072( ) ;
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV52GenericFilter_PreviousValue_Grid ,
                                       long AV9ApplicationId_Filter_PreviousValue ,
                                       long AV8ApplicationId_Filter ,
                                       string AV55Pgmname ,
                                       short AV16CurrentPage_Grid ,
                                       string AV48GenericFilter_Grid ,
                                       bool AV26HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV49GridConfiguration ,
                                       long AV15CurrentApplicationId ,
                                       GxSimpleCollection<string> AV50ClassCollection_Grid ,
                                       short AV37RowsPerPage_Grid ,
                                       long AV30MenuId ,
                                       short AV28I_LoadCount_Grid ,
                                       bool AV51FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF392( ) ;
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
         if ( cmbavApplicationid_filter.ItemCount > 0 )
         {
            AV8ApplicationId_Filter = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid_filter.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ApplicationId_Filter", StringUtil.LTrimStr( (decimal)(AV8ApplicationId_Filter), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
            AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV22GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E21392 ();
         RF392( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "K2BFSG.WWMenu";
         edtavMenuid_Enabled = 0;
         AssignProp("", false, edtavMenuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuid_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavMenudescription_Enabled = 0;
         AssignProp("", false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavSetmain_action_Enabled = 0;
         AssignProp("", false, edtavSetmain_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSetmain_action_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp("", false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_107_Refreshing);
      }

      protected void RF392( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E21392 ();
         E22392 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
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
            SubsflControlProps_1072( ) ;
            E23392 ();
            wbEnd = 107;
            WB390( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes392( )
      {
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID_FILTER_PREVIOUSVALUE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId_Filter_PreviousValue), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID_FILTER_PREVIOUSVALUE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ApplicationId_Filter_PreviousValue), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
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
         AV55Pgmname = "K2BFSG.WWMenu";
         edtavMenuid_Enabled = 0;
         AssignProp("", false, edtavMenuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuid_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavMenudescription_Enabled = 0;
         AssignProp("", false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavSetmain_action_Enabled = 0;
         AssignProp("", false, edtavSetmain_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSetmain_action_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp("", false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP390( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E20392 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_GRID"), AV53FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), ".", ","), 18, MidpointRounding.ToEven));
            AV54DeletedTag_Grid = cgiGet( "vDELETEDTAG_GRID");
            AV16CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV12ConfirmationSubId = cgiGet( "vCONFIRMATIONSUBID");
            AV37RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV26HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            K2bt_confirmdialog_Confirmmessage = cgiGet( "K2BT_CONFIRMDIALOG_Confirmmessage");
            K2bt_confirmdialog_Visible = StringUtil.StrToBool( cgiGet( "K2BT_CONFIRMDIALOG_Visible"));
            cmbavApplicationid_filter.Caption = cgiGet( "vAPPLICATIONID_FILTER_Caption");
            /* Read variables values. */
            AV48GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV48GenericFilter_Grid", AV48GenericFilter_Grid);
            cmbavApplicationid_filter.Name = cmbavApplicationid_filter_Internalname;
            cmbavApplicationid_filter.CurrentValue = cgiGet( cmbavApplicationid_filter_Internalname);
            AV8ApplicationId_Filter = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavApplicationid_filter_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ApplicationId_Filter", StringUtil.LTrimStr( (decimal)(AV8ApplicationId_Filter), 12, 0));
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV22GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
            AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
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
         E20392 ();
         if (returnInSub) return;
      }

      protected void E20392( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV55Pgmname,  "Grid", out  AV37RowsPerPage_Grid, out  AV43RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV37RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV37RowsPerPage_Grid), 4, 0));
         if ( ! AV43RowsPerPageLoaded_Grid )
         {
            AV37RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV37RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV37RowsPerPage_Grid), 4, 0));
         }
         AV22GridSettingsRowsPerPage_Grid = AV37RowsPerPage_Grid;
         AssignAttri("", false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV52GenericFilter_PreviousValue_Grid = AV48GenericFilter_Grid;
         AssignAttri("", false, "AV52GenericFilter_PreviousValue_Grid", AV52GenericFilter_PreviousValue_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         AV9ApplicationId_Filter_PreviousValue = AV8ApplicationId_Filter;
         AssignAttri("", false, "AV9ApplicationId_Filter_PreviousValue", StringUtil.LTrimStr( (decimal)(AV9ApplicationId_Filter_PreviousValue), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID_FILTER_PREVIOUSVALUE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ApplicationId_Filter_PreviousValue), "ZZZZZZZZZZZ9"), context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         K2bt_confirmdialog_Visible = false;
         ucK2bt_confirmdialog.SendProperty(context, "", false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E21392( )
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
         AV11ConfirmationRequired = false;
         AssignAttri("", false, "AV11ConfirmationRequired", AV11ConfirmationRequired);
         if ( (0==AV16CurrentPage_Grid) )
         {
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV52GenericFilter_PreviousValue_Grid, AV48GenericFilter_Grid) != 0 )
         {
            AV52GenericFilter_PreviousValue_Grid = AV48GenericFilter_Grid;
            AssignAttri("", false, "AV52GenericFilter_PreviousValue_Grid", AV52GenericFilter_PreviousValue_Grid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         if ( AV9ApplicationId_Filter_PreviousValue != AV8ApplicationId_Filter )
         {
            AV9ApplicationId_Filter_PreviousValue = AV8ApplicationId_Filter;
            AssignAttri("", false, "AV9ApplicationId_Filter_PreviousValue", StringUtil.LTrimStr( (decimal)(AV9ApplicationId_Filter_PreviousValue), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID_FILTER_PREVIOUSVALUE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ApplicationId_Filter_PreviousValue), "ZZZZZZZZZZZ9"), context));
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         AV35Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV50ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV50ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
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
      }

      protected void S172( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message2 = AV33Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message2) ;
         AV33Messages = GXt_objcol_SdtMessages_Message2;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV33Messages.Count )
         {
            AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV33Messages.Item(AV56GXV1));
            GX_msglist.addItem(AV32Message.gxTpr_Description);
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         AV14CurrentAppGUID = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getguid();
         cmbavApplicationid_filter.removeAllItems();
         AV58GXV3 = 1;
         AV57GXV2 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV20GAMApplicationFilter, out  AV17Errors);
         while ( AV58GXV3 <= AV57GXV2.Count )
         {
            AV7Application = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV57GXV2.Item(AV58GXV3));
            if ( (0==AV8ApplicationId_Filter) && ( StringUtil.StrCmp(AV7Application.gxTpr_Guid, AV14CurrentAppGUID) == 0 ) )
            {
               AV8ApplicationId_Filter = AV7Application.gxTpr_Id;
               AssignAttri("", false, "AV8ApplicationId_Filter", StringUtil.LTrimStr( (decimal)(AV8ApplicationId_Filter), 12, 0));
            }
            cmbavApplicationid_filter.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Application.gxTpr_Id), 12, 0)), AV7Application.gxTpr_Name, 0);
            AV58GXV3 = (int)(AV58GXV3+1);
         }
         AV42CurrentApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getbyguid(new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getguid(), out  AV17Errors);
         AV15CurrentApplicationId = AV42CurrentApplication.gxTpr_Id;
         AssignAttri("", false, "AV15CurrentApplicationId", StringUtil.LTrimStr( (decimal)(AV15CurrentApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
      }

      protected void E22392( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S182 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         edtavMenuid_Columnheaderclass = "K2BToolsGridColumn";
         AssignProp("", false, edtavMenuid_Internalname, "Columnheaderclass", edtavMenuid_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavMenuname_Columnheaderclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
         AssignProp("", false, edtavMenuname_Internalname, "Columnheaderclass", edtavMenuname_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavMenudescription_Columnheaderclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
         AssignProp("", false, edtavMenudescription_Internalname, "Columnheaderclass", edtavMenudescription_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavSetmain_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp("", false, edtavSetmain_action_Internalname, "Columnheaderclass", edtavSetmain_action_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavOptions_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp("", false, edtavOptions_action_Internalname, "Columnheaderclass", edtavOptions_action_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavUpdate_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp("", false, edtavUpdate_action_Internalname, "Columnheaderclass", edtavUpdate_action_Columnheaderclass, !bGXsfl_107_Refreshing);
         edtavDelete_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp("", false, edtavDelete_action_Internalname, "Columnheaderclass", edtavDelete_action_Columnheaderclass, !bGXsfl_107_Refreshing);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53FilterTagsCollection_Grid", AV53FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
      }

      protected void S192( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E23392( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV28I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         AV26HasNextPage_Grid = false;
         AssignAttri("", false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
         AV18Exit_Grid = false;
         while ( true )
         {
            AV28I_LoadCount_Grid = (short)(AV28I_LoadCount_Grid+1);
            AssignAttri("", false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S212 ();
            if (returnInSub) return;
            AV38SetMain_Action = "Set as main";
            AssignAttri("", false, edtavSetmain_action_Internalname, AV38SetMain_Action);
            AV34Options_Action = "Options";
            AssignAttri("", false, edtavOptions_action_Internalname, AV34Options_Action);
            edtavUpdate_action_gximage = "K2BActionUpdate";
            AV46Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
            AssignAttri("", false, edtavUpdate_action_Internalname, AV46Update_Action);
            AV59Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            edtavUpdate_action_Tooltiptext = "Update";
            edtavDelete_action_gximage = "K2BActionDelete";
            AV47Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri("", false, edtavDelete_action_Internalname, AV47Delete_Action);
            AV60Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = "Delete";
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S222 ();
            if (returnInSub) return;
            if ( AV18Exit_Grid )
            {
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV37RowsPerPage_Grid * AV16CurrentPage_Grid )
            {
               AV26HasNextPage_Grid = true;
               AssignAttri("", false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV26HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV37RowsPerPage_Grid * ( AV16CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               if ( new GeneXus.Programs.k2bfsg.isapplicationmainmenu(context).executeUdp(  AV8ApplicationId_Filter,  AV30MenuId) )
               {
                  edtavSetmain_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavOptions_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavUpdate_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavDelete_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavMenuid_Columnclass = "K2BToolsGridColumn"+" "+"Column_NotOK";
                  edtavMenuname_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn"+" "+"Column_NotOK";
                  edtavMenudescription_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn"+" "+"Column_NotOK";
               }
               else
               {
                  edtavSetmain_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
                  edtavOptions_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
                  edtavUpdate_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
                  edtavDelete_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
                  edtavMenuid_Columnclass = "K2BToolsGridColumn";
                  edtavMenuname_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
                  edtavMenudescription_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 107;
               }
               sendrow_1072( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
               {
                  context.DoAjaxLoad(107, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
      }

      protected void S212( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV28I_LoadCount_Grid == 1 )
         {
            AV7Application.load( AV8ApplicationId_Filter);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48GenericFilter_Grid)) )
            {
               AV19Filter.gxTpr_Name = "%"+AV48GenericFilter_Grid;
            }
            AV10AppMenu = AV7Application.getmenus(AV19Filter, out  AV17Errors);
         }
         if ( AV10AppMenu.Count >= AV28I_LoadCount_Grid )
         {
            AV30MenuId = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Id;
            AssignAttri("", false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
            AV31MenuName = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri("", false, edtavMenuname_Internalname, AV31MenuName);
            AV29MenuDescription = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri("", false, edtavMenudescription_Internalname, AV29MenuDescription);
            if ( new GeneXus.Programs.k2bfsg.isapplicationmainmenu(context).executeUdp(  AV8ApplicationId_Filter,  AV30MenuId) )
            {
               AV29MenuDescription += "(Current main menu)";
               AssignAttri("", false, edtavMenudescription_Internalname, AV29MenuDescription);
               AV38SetMain_Action = "";
               AssignAttri("", false, edtavSetmain_action_Internalname, AV38SetMain_Action);
            }
            else
            {
               if ( new GeneXus.Programs.k2bfsg.menuhasparent(context).executeUdp(  AV8ApplicationId_Filter,  AV30MenuId) )
               {
                  AV38SetMain_Action = "";
                  AssignAttri("", false, edtavSetmain_action_Internalname, AV38SetMain_Action);
               }
               else
               {
                  AV38SetMain_Action = "Set as main";
                  AssignAttri("", false, edtavSetmain_action_Internalname, AV38SetMain_Action);
               }
            }
         }
         else
         {
            AV18Exit_Grid = true;
         }
      }

      protected void S202( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV16CurrentPage_Grid) || ( AV16CurrentPage_Grid <= 1 ) )
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
            if ( AV16CurrentPage_Grid == 2 )
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
               if ( AV16CurrentPage_Grid == 3 )
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
         if ( ! AV26HasNextPage_Grid )
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
         if ( ( AV16CurrentPage_Grid <= 1 ) && ! AV26HasNextPage_Grid )
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

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV23GridState.gxTpr_Currentpage = AV16CurrentPage_Grid;
         AV23GridState.gxTpr_Filtervalues.Clear();
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "ApplicationId_Filter";
         AV24GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0);
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV24GridStateFilterValue.gxTpr_Value = AV48GenericFilter_Grid;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey,  AV23GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV55Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV61GXV4 = 1;
         while ( AV61GXV4 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV61GXV4));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "ApplicationId_Filter") == 0 )
            {
               AV8ApplicationId_Filter = (long)(Math.Round(NumberUtil.Val( AV24GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8ApplicationId_Filter", StringUtil.LTrimStr( (decimal)(AV8ApplicationId_Filter), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV48GenericFilter_Grid = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48GenericFilter_Grid", AV48GenericFilter_Grid);
            }
            AV61GXV4 = (int)(AV61GXV4+1);
         }
         if ( AV23GridState.gxTpr_Currentpage > 0 )
         {
            AV16CurrentPage_Grid = AV23GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
      }

      protected void E17392( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV55Pgmname,  "Grid", ref  AV49GridConfiguration) ;
         AV49GridConfiguration.gxTpr_Freezecolumntitles = AV51FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV55Pgmname,  "Grid",  AV49GridConfiguration,  true) ;
         if ( AV37RowsPerPage_Grid != AV22GridSettingsRowsPerPage_Grid )
         {
            AV37RowsPerPage_Grid = AV22GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV37RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV37RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV55Pgmname,  "Grid",  AV37RowsPerPage_Grid) ;
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV9ApplicationId_Filter_PreviousValue, AV8ApplicationId_Filter, AV55Pgmname, AV16CurrentPage_Grid, AV48GenericFilter_Grid, AV26HasNextPage_Grid, AV49GridConfiguration, AV15CurrentApplicationId, AV50ClassCollection_Grid, AV37RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void S302( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddnew_Visible = 1;
         AssignProp("", false, bttAddnew_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddnew_Visible), 5, 0), true);
         bttLoadapplicationmenus_Visible = 1;
         AssignProp("", false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
         if ( AV15CurrentApplicationId == AV8ApplicationId_Filter )
         {
            bttLoadapplicationmenus_Visible = 1;
            AssignProp("", false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
         }
         else
         {
            bttLoadapplicationmenus_Visible = 0;
            AssignProp("", false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
            bttLoadapplicationmenus_Tooltiptext = "";
            AssignProp("", false, bttLoadapplicationmenus_Internalname, "Tooltiptext", bttLoadapplicationmenus_Tooltiptext, true);
         }
      }

      protected void E18392( )
      {
         /* 'E_AddNew' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADDNEW' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void S232( )
      {
         /* 'U_ADDNEW' Routine */
         returnInSub = false;
         AV41Window.Autoresize = 1;
         AV41Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId_Filter,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV41Window.SetReturnParms(new Object[] {"AV8ApplicationId_Filter","AV30MenuId",});
         context.NewWindow(AV41Window);
         context.DoAjaxRefresh();
      }

      protected void E24392( )
      {
         /* 'E_Update' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_UPDATE' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void S242( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         AV41Window.Autoresize = 1;
         AV41Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId_Filter,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV41Window.SetReturnParms(new Object[] {"AV8ApplicationId_Filter","AV30MenuId",});
         context.NewWindow(AV41Window);
         context.DoAjaxRefresh();
      }

      protected void E25392( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void S252( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV41Window.Autoresize = 1;
         AV41Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId_Filter,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV41Window.SetReturnParms(new Object[] {"AV8ApplicationId_Filter","AV30MenuId",});
         context.NewWindow(AV41Window);
         context.DoAjaxRefresh();
      }

      protected void S262( )
      {
         /* 'U_OPTIONS' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.wwmenuoptions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8ApplicationId_Filter,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"ApplicationId","MenuId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E26392( )
      {
         /* 'E_SetMain' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_SETMAIN' */
         S272 ();
         if (returnInSub) return;
      }

      protected void S272( )
      {
         /* 'U_SETMAIN' Routine */
         returnInSub = false;
         AV7Application.load( AV8ApplicationId_Filter);
         AV7Application.gxTpr_Mainmenuid = AV30MenuId;
         AV7Application.save();
         context.CommitDataStores("k2bfsg.wwmenu",pr_default);
         context.DoAjaxRefreshForm();
      }

      protected void E19392( )
      {
         /* 'E_LoadApplicationMenus' Routine */
         returnInSub = false;
         AV13ConfirmMessage = "All defined menus will be added to the GAM database. Are you sure?";
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(LOADAPPLICATIONMENUS)' */
         S282 ();
         if (returnInSub) return;
         if ( AV11ConfirmationRequired )
         {
            AV12ConfirmationSubId = "'U_LoadApplicationMenus'";
            AssignAttri("", false, "AV12ConfirmationSubId", AV12ConfirmationSubId);
            AV35Reload_Grid = false;
            K2bt_confirmdialog_Confirmmessage = AV13ConfirmMessage;
            ucK2bt_confirmdialog.SendProperty(context, "", false, K2bt_confirmdialog_Internalname, "ConfirmMessage", K2bt_confirmdialog_Confirmmessage);
            K2bt_confirmdialog_Visible = true;
            ucK2bt_confirmdialog.SendProperty(context, "", false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         }
         else
         {
            /* Execute user subroutine: 'U_LOADAPPLICATIONMENUS' */
            S292 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void S292( )
      {
         /* 'U_LOADAPPLICATIONMENUS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV36Result;
         new GeneXus.Programs.k2bfsg.persistmenusingam(context ).execute(  AV8ApplicationId_Filter, out  AV33Messages, out  GXt_boolean3) ;
         AV36Result = GXt_boolean3;
         AV62GXV5 = 1;
         while ( AV62GXV5 <= AV33Messages.Count )
         {
            AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV33Messages.Item(AV62GXV5));
            GX_msglist.addItem(AV32Message.gxTpr_Description);
            AV62GXV5 = (int)(AV62GXV5+1);
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV9ApplicationId_Filter_PreviousValue, AV8ApplicationId_Filter, AV55Pgmname, AV16CurrentPage_Grid, AV48GenericFilter_Grid, AV26HasNextPage_Grid, AV49GridConfiguration, AV15CurrentApplicationId, AV50ClassCollection_Grid, AV37RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid) ;
      }

      protected void S282( )
      {
         /* 'U_CONFIRMATIONREQUIRED(LOADAPPLICATIONMENUS)' Routine */
         returnInSub = false;
         AV11ConfirmationRequired = true;
         AssignAttri("", false, "AV11ConfirmationRequired", AV11ConfirmationRequired);
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV53FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV44K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! (0==AV8ApplicationId_Filter) )
         {
            AV45K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "ApplicationId_Filter";
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Description = cmbavApplicationid_filter.Caption;
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = false;
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Value = StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0);
            AV45K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = cmbavApplicationid_filter.Description;
            AV44K2BFilterValuesSDT_WebForm.Add(AV45K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No filters are applied";
         ucFiltertagsusercontrol_grid.SendProperty(context, "", false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV44K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV53FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV55Pgmname,  "Filters",  AV44K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV53FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void S152( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S302 ();
         if (returnInSub) return;
      }

      protected void S222( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV55Pgmname,  "Grid", ref  AV49GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S312 ();
         if (returnInSub) return;
      }

      protected void S312( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV51FreezeColumnTitles_Grid = AV49GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
         if ( AV51FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV50ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV50ClassCollection_Grid) ;
         }
      }

      protected void E16392( )
      {
         /* K2bt_confirmdialog_Onokclicked Routine */
         returnInSub = false;
         K2bt_confirmdialog_Visible = false;
         ucK2bt_confirmdialog.SendProperty(context, "", false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         if ( StringUtil.StrCmp(AV12ConfirmationSubId, "'U_LoadApplicationMenus'") == 0 )
         {
            /* Execute user subroutine: 'U_LOADAPPLICATIONMENUS' */
            S292 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         cmbavApplicationid_filter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0));
         AssignProp("", false, cmbavApplicationid_filter_Internalname, "Values", cmbavApplicationid_filter.ToJavascriptSource(), true);
      }

      protected void wb_table1_117_392( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenu.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_117_392e( true) ;
         }
         else
         {
            wb_table1_117_392e( false) ;
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
         PA392( ) ;
         WS392( ) ;
         WE392( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138171867", true, true);
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
         context.AddJavascriptSource("k2bfsg/wwmenu.js", "?20243138171872", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ConfirmDialogRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1072( )
      {
         edtavMenuid_Internalname = "vMENUID_"+sGXsfl_107_idx;
         edtavMenuname_Internalname = "vMENUNAME_"+sGXsfl_107_idx;
         edtavMenudescription_Internalname = "vMENUDESCRIPTION_"+sGXsfl_107_idx;
         edtavSetmain_action_Internalname = "vSETMAIN_ACTION_"+sGXsfl_107_idx;
         edtavOptions_action_Internalname = "vOPTIONS_ACTION_"+sGXsfl_107_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_107_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtavMenuid_Internalname = "vMENUID_"+sGXsfl_107_fel_idx;
         edtavMenuname_Internalname = "vMENUNAME_"+sGXsfl_107_fel_idx;
         edtavMenudescription_Internalname = "vMENUDESCRIPTION_"+sGXsfl_107_fel_idx;
         edtavSetmain_action_Internalname = "vSETMAIN_ACTION_"+sGXsfl_107_fel_idx;
         edtavOptions_action_Internalname = "vOPTIONS_ACTION_"+sGXsfl_107_fel_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_107_fel_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         SubsflControlProps_1072( ) ;
         WB390( ) ;
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
            if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenuid_Enabled!=0)&&(edtavMenuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 108,'',false,'"+sGXsfl_107_idx+"',107)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenuid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30MenuId), 12, 0, ".", "")),StringUtil.LTrim( ((edtavMenuid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30MenuId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30MenuId), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavMenuid_Enabled!=0)&&(edtavMenuid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenuid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenuid_Columnclass,(string)edtavMenuid_Columnheaderclass,(short)0,(int)edtavMenuid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenuname_Enabled!=0)&&(edtavMenuname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 109,'',false,'"+sGXsfl_107_idx+"',107)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenuname_Internalname,StringUtil.RTrim( AV31MenuName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMenuname_Enabled!=0)&&(edtavMenuname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,109);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e27392_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenuname_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenuname_Columnclass,(string)edtavMenuname_Columnheaderclass,(short)-1,(int)edtavMenuname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenudescription_Enabled!=0)&&(edtavMenudescription_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 110,'',false,'"+sGXsfl_107_idx+"',107)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenudescription_Internalname,StringUtil.RTrim( AV29MenuDescription),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMenudescription_Enabled!=0)&&(edtavMenudescription_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,110);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenudescription_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenudescription_Columnclass,(string)edtavMenudescription_Columnheaderclass,(short)-1,(int)edtavMenudescription_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSetmain_action_Enabled!=0)&&(edtavSetmain_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 111,'',false,'"+sGXsfl_107_idx+"',107)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSetmain_action_Internalname,StringUtil.RTrim( AV38SetMain_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSetmain_action_Enabled!=0)&&(edtavSetmain_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_SETMAIN\\'."+sGXsfl_107_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSetmain_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)edtavSetmain_action_Columnclass,(string)edtavSetmain_action_Columnheaderclass,(short)-1,(int)edtavSetmain_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 112,'',false,'"+sGXsfl_107_idx+"',107)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptions_action_Internalname,StringUtil.RTrim( AV34Options_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,112);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e28392_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptions_action_Jsonclick,(short)7,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)edtavOptions_action_Columnclass,(string)edtavOptions_action_Columnheaderclass,(short)-1,(int)edtavOptions_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 113,'',false,'',107)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class");
         StyleString = "";
         AV46Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV59Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)) ? AV59Update_action_GXI : context.PathToRelativeUrl( AV46Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Update",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUpdate_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_UPDATE\\'."+sGXsfl_107_idx+"'",(string)StyleString,(string)ClassString,(string)edtavUpdate_action_Columnclass,(string)edtavUpdate_action_Columnheaderclass,(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV46Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 114,'',false,'',107)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV47Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV60Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)) ? AV60Delete_action_GXI : context.PathToRelativeUrl( AV47Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_DELETE\\'."+sGXsfl_107_idx+"'",(string)StyleString,(string)ClassString,(string)edtavDelete_action_Columnclass,(string)edtavDelete_action_Columnheaderclass,(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV47Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes392( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         /* End function sendrow_1072 */
      }

      protected void init_web_controls( )
      {
         cmbavApplicationid_filter.Name = "vAPPLICATIONID_FILTER";
         cmbavApplicationid_filter.WebTags = "";
         if ( cmbavApplicationid_filter.ItemCount > 0 )
         {
            AV8ApplicationId_Filter = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid_filter.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8ApplicationId_Filter), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ApplicationId_Filter", StringUtil.LTrimStr( (decimal)(AV8ApplicationId_Filter), 12, 0));
         }
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV22GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Menu ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30MenuId), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMenuid_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMenuid_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMenuid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31MenuName)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMenuname_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMenuname_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMenuname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29MenuDescription)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMenudescription_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMenudescription_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMenudescription_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38SetMain_Action)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSetmain_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSetmain_action_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSetmain_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34Options_Action)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavOptions_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavOptions_action_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptions_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV46Update_Action));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavUpdate_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavUpdate_action_Columnheaderclass));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV47Delete_Action));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDelete_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDelete_action_Columnheaderclass));
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
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         imgLayoutdefined_filtertoggle_combined_grid_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID";
         divLayoutdefined_table1_grid_Internalname = "LAYOUTDEFINED_TABLE1_GRID";
         Filtertagsusercontrol_grid_Internalname = "FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table5_grid_Internalname = "LAYOUTDEFINED_TABLE5_GRID";
         cmbavApplicationid_filter_Internalname = "vAPPLICATIONID_FILTER";
         divTable_container_applicationid_filter_Internalname = "TABLE_CONTAINER_APPLICATIONID_FILTER";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID";
         divLayoutdefined_combinedfilterlayout_grid_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRID";
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
         bttAddnew_Internalname = "ADDNEW";
         divActions_grid_topright_Internalname = "ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         bttLoadapplicationmenus_Internalname = "LOADAPPLICATIONMENUS";
         divActions_grid_gridassociatedleft_Internalname = "ACTIONS_GRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_grid_Internalname = "LAYOUTDEFINED_SECTION7_GRID";
         divLayoutdefined_section3_grid_Internalname = "LAYOUTDEFINED_SECTION3_GRID";
         divLayoutdefined_section1_grid_Internalname = "LAYOUTDEFINED_SECTION1_GRID";
         edtavMenuid_Internalname = "vMENUID";
         edtavMenuname_Internalname = "vMENUNAME";
         edtavMenudescription_Internalname = "vMENUDESCRIPTION";
         edtavSetmain_action_Internalname = "vSETMAIN_ACTION";
         edtavOptions_action_Internalname = "vOPTIONS_ACTION";
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
         K2bt_confirmdialog_Internalname = "K2BT_CONFIRMDIALOG";
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
         chkavFreezecolumntitles_grid.Caption = "Freeze column titles";
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_Columnclass = "K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover";
         edtavDelete_action_gximage = "";
         edtavDelete_action_Visible = -1;
         edtavDelete_action_Enabled = 1;
         edtavDelete_action_Tooltiptext = "";
         edtavUpdate_action_Jsonclick = "";
         edtavUpdate_action_Columnclass = "K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover";
         edtavUpdate_action_gximage = "";
         edtavUpdate_action_Visible = -1;
         edtavUpdate_action_Enabled = 1;
         edtavUpdate_action_Tooltiptext = "";
         edtavOptions_action_Jsonclick = "";
         edtavOptions_action_Columnclass = "K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover";
         edtavOptions_action_Visible = -1;
         edtavOptions_action_Enabled = 1;
         edtavSetmain_action_Jsonclick = "";
         edtavSetmain_action_Columnclass = "K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover";
         edtavSetmain_action_Visible = -1;
         edtavSetmain_action_Enabled = 1;
         edtavMenudescription_Jsonclick = "";
         edtavMenudescription_Columnclass = "K2BToolsGridColumn InvisibleInExtraSmallColumn";
         edtavMenudescription_Visible = -1;
         edtavMenudescription_Enabled = 1;
         edtavMenuname_Jsonclick = "";
         edtavMenuname_Columnclass = "K2BToolsGridColumn InvisibleInExtraSmallColumn";
         edtavMenuname_Visible = -1;
         edtavMenuname_Enabled = 1;
         edtavMenuid_Jsonclick = "";
         edtavMenuid_Columnclass = "K2BToolsGridColumn";
         edtavMenuid_Visible = 0;
         edtavMenuid_Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         edtavDelete_action_Columnheaderclass = "";
         edtavUpdate_action_Columnheaderclass = "";
         edtavOptions_action_Columnheaderclass = "";
         edtavSetmain_action_Columnheaderclass = "";
         edtavMenudescription_Columnheaderclass = "";
         edtavMenuname_Columnheaderclass = "";
         edtavMenuid_Columnheaderclass = "";
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
         bttLoadapplicationmenus_Tooltiptext = "";
         bttLoadapplicationmenus_Visible = 1;
         bttAddnew_Visible = 1;
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         cmbavApplicationid_filter_Jsonclick = "";
         cmbavApplicationid_filter.Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         cmbavApplicationid_filter.Description = "";
         cmbavApplicationid_filter.Caption = "Application";
         K2bt_confirmdialog_Visible = Convert.ToBoolean( -1);
         K2bt_confirmdialog_Confirmmessage = "K2BT_AreYouSure";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Menus";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E22392',iparms:[{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'edtavMenuid_Columnheaderclass',ctrl:'vMENUID',prop:'Columnheaderclass'},{av:'edtavMenuname_Columnheaderclass',ctrl:'vMENUNAME',prop:'Columnheaderclass'},{av:'edtavMenudescription_Columnheaderclass',ctrl:'vMENUDESCRIPTION',prop:'Columnheaderclass'},{av:'edtavSetmain_action_Columnheaderclass',ctrl:'vSETMAIN_ACTION',prop:'Columnheaderclass'},{av:'edtavOptions_action_Columnheaderclass',ctrl:'vOPTIONS_ACTION',prop:'Columnheaderclass'},{av:'edtavUpdate_action_Columnheaderclass',ctrl:'vUPDATE_ACTION',prop:'Columnheaderclass'},{av:'edtavDelete_action_Columnheaderclass',ctrl:'vDELETE_ACTION',prop:'Columnheaderclass'},{av:'AV53FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E23392',iparms:[{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV38SetMain_Action',fld:'vSETMAIN_ACTION',pic:''},{av:'AV34Options_Action',fld:'vOPTIONS_ACTION',pic:''},{av:'AV46Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV47Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'edtavSetmain_action_Columnclass',ctrl:'vSETMAIN_ACTION',prop:'Columnclass'},{av:'edtavOptions_action_Columnclass',ctrl:'vOPTIONS_ACTION',prop:'Columnclass'},{av:'edtavUpdate_action_Columnclass',ctrl:'vUPDATE_ACTION',prop:'Columnclass'},{av:'edtavDelete_action_Columnclass',ctrl:'vDELETE_ACTION',prop:'Columnclass'},{av:'edtavMenuid_Columnclass',ctrl:'vMENUID',prop:'Columnclass'},{av:'edtavMenuname_Columnclass',ctrl:'vMENUNAME',prop:'Columnclass'},{av:'edtavMenudescription_Columnclass',ctrl:'vMENUDESCRIPTION',prop:'Columnclass'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV31MenuName',fld:'vMENUNAME',pic:''},{av:'AV29MenuDescription',fld:'vMENUDESCRIPTION',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E14391',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E13391',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E15391',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E12391',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV22GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E17392',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV22GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ADDNEW'","{handler:'E18392',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ADDNEW'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E24392',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E25392',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_OPTIONS'","{handler:'E28392',iparms:[{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_OPTIONS'",",oparms:[{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("VMENUNAME.CLICK","{handler:'E27392',iparms:[{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("VMENUNAME.CLICK",",oparms:[]}");
         setEventMetadata("'E_SETMAIN'","{handler:'E26392',iparms:[{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_SETMAIN'",",oparms:[]}");
         setEventMetadata("'E_LOADAPPLICATIONMENUS'","{handler:'E19392',iparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_LOADAPPLICATIONMENUS'",",oparms:[{av:'AV12ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'K2bt_confirmdialog_Confirmmessage',ctrl:'K2BT_CONFIRMDIALOG',prop:'ConfirmMessage'},{av:'K2bt_confirmdialog_Visible',ctrl:'K2BT_CONFIRMDIALOG',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK","{handler:'E11391',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("K2BT_CONFIRMDIALOG.ONOKCLICKED","{handler:'E16392',iparms:[{av:'AV12ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("K2BT_CONFIRMDIALOG.ONOKCLICKED",",oparms:[{av:'K2bt_confirmdialog_Visible',ctrl:'K2BT_CONFIRMDIALOG',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV9ApplicationId_Filter_PreviousValue',fld:'vAPPLICATIONID_FILTER_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'cmbavApplicationid_filter'},{av:'AV8ApplicationId_Filter',fld:'vAPPLICATIONID_FILTER',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
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
         AV52GenericFilter_PreviousValue_Grid = "";
         AV55Pgmname = "";
         AV48GenericFilter_Grid = "";
         AV49GridConfiguration = new SdtK2BGridConfiguration(context);
         AV50ClassCollection_Grid = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV53FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV54DeletedTag_Grid = "";
         AV12ConfirmationSubId = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         imgLayoutdefined_filtertoggle_combined_grid_gximage = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         imgGridsettings_labelgrid_gximage = "";
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         bttAddnew_Jsonclick = "";
         bttLoadapplicationmenus_Jsonclick = "";
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
         ucK2bt_confirmdialog = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31MenuName = "";
         AV29MenuDescription = "";
         AV38SetMain_Action = "";
         AV34Options_Action = "";
         AV46Update_Action = "";
         AV59Update_action_GXI = "";
         AV47Delete_Action = "";
         AV60Delete_action_GXI = "";
         GXt_char1 = "";
         AV33Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV14CurrentAppGUID = "";
         AV57GXV2 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV20GAMApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV17Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV7Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV42CurrentApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         GridRow = new GXWebRow();
         AV19Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV10AppMenu = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV25GridStateKey = "";
         AV23GridState = new SdtK2BGridState(context);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV41Window = new GXWindow();
         AV13ConfirmMessage = "";
         AV44K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV45K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwmenu__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwmenu__default(),
            new Object[][] {
            }
         );
         AV55Pgmname = "K2BFSG.WWMenu";
         /* GeneXus formulas. */
         AV55Pgmname = "K2BFSG.WWMenu";
         edtavMenuid_Enabled = 0;
         edtavMenuname_Enabled = 0;
         edtavMenudescription_Enabled = 0;
         edtavSetmain_action_Enabled = 0;
         edtavOptions_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV16CurrentPage_Grid ;
      private short AV37RowsPerPage_Grid ;
      private short AV28I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV22GridSettingsRowsPerPage_Grid ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GRID_nEOF ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_grid_Visible ;
      private int nRC_GXsfl_107 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_107_idx=1 ;
      private int edtavGenericfilter_grid_Enabled ;
      private int bttAddnew_Visible ;
      private int bttLoadapplicationmenus_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavMenuid_Enabled ;
      private int edtavMenuname_Enabled ;
      private int edtavMenudescription_Enabled ;
      private int edtavSetmain_action_Enabled ;
      private int edtavOptions_action_Enabled ;
      private int AV56GXV1 ;
      private int AV58GXV3 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV61GXV4 ;
      private int AV62GXV5 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavMenuid_Visible ;
      private int edtavMenuname_Visible ;
      private int edtavMenudescription_Visible ;
      private int edtavSetmain_action_Visible ;
      private int edtavOptions_action_Visible ;
      private int edtavUpdate_action_Enabled ;
      private int edtavUpdate_action_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV9ApplicationId_Filter_PreviousValue ;
      private long AV8ApplicationId_Filter ;
      private long AV15CurrentApplicationId ;
      private long AV30MenuId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_107_idx="0001" ;
      private string AV52GenericFilter_PreviousValue_Grid ;
      private string AV55Pgmname ;
      private string AV48GenericFilter_Grid ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV54DeletedTag_Grid ;
      private string AV12ConfirmationSubId ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string K2bt_confirmdialog_Confirmmessage ;
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
      private string divLayoutdefined_combinedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_table5_grid_Internalname ;
      private string divLayoutdefined_table1_grid_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_grid_Internalname ;
      private string edtavGenericfilter_grid_Jsonclick ;
      private string imgLayoutdefined_filtertoggle_combined_grid_gximage ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_combined_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_combined_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_applicationid_filter_Internalname ;
      private string cmbavApplicationid_filter_Internalname ;
      private string cmbavApplicationid_filter_Jsonclick ;
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
      private string bttAddnew_Internalname ;
      private string bttAddnew_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divLayoutdefined_section1_grid_Internalname ;
      private string divLayoutdefined_section7_grid_Internalname ;
      private string divActions_grid_gridassociatedleft_Internalname ;
      private string bttLoadapplicationmenus_Internalname ;
      private string bttLoadapplicationmenus_Jsonclick ;
      private string bttLoadapplicationmenus_Tooltiptext ;
      private string divLayoutdefined_section3_grid_Internalname ;
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
      private string K2bt_confirmdialog_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavMenuid_Internalname ;
      private string AV31MenuName ;
      private string edtavMenuname_Internalname ;
      private string AV29MenuDescription ;
      private string edtavMenudescription_Internalname ;
      private string AV38SetMain_Action ;
      private string edtavSetmain_action_Internalname ;
      private string AV34Options_Action ;
      private string edtavOptions_action_Internalname ;
      private string edtavUpdate_action_Internalname ;
      private string edtavDelete_action_Internalname ;
      private string GXt_char1 ;
      private string AV14CurrentAppGUID ;
      private string edtavMenuid_Columnheaderclass ;
      private string edtavMenuname_Columnheaderclass ;
      private string edtavMenudescription_Columnheaderclass ;
      private string edtavSetmain_action_Columnheaderclass ;
      private string edtavOptions_action_Columnheaderclass ;
      private string edtavUpdate_action_Columnheaderclass ;
      private string edtavDelete_action_Columnheaderclass ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavUpdate_action_gximage ;
      private string edtavUpdate_action_Tooltiptext ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string edtavSetmain_action_Columnclass ;
      private string edtavOptions_action_Columnclass ;
      private string edtavUpdate_action_Columnclass ;
      private string edtavDelete_action_Columnclass ;
      private string edtavMenuid_Columnclass ;
      private string edtavMenuname_Columnclass ;
      private string edtavMenudescription_Columnclass ;
      private string AV13ConfirmMessage ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavMenuid_Jsonclick ;
      private string edtavMenuname_Jsonclick ;
      private string edtavMenudescription_Jsonclick ;
      private string edtavSetmain_action_Jsonclick ;
      private string edtavOptions_action_Jsonclick ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26HasNextPage_Grid ;
      private bool AV51FreezeColumnTitles_Grid ;
      private bool AV11ConfirmationRequired ;
      private bool K2bt_confirmdialog_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV43RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV35Reload_Grid ;
      private bool AV18Exit_Grid ;
      private bool AV36Result ;
      private bool GXt_boolean3 ;
      private bool AV46Update_Action_IsBlob ;
      private bool AV47Delete_Action_IsBlob ;
      private string AV59Update_action_GXI ;
      private string AV60Delete_action_GXI ;
      private string AV25GridStateKey ;
      private string AV46Update_Action ;
      private string AV47Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bt_confirmdialog ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavApplicationid_filter ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV50ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV57GXV2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV17Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV10AppMenu ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message2 ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV44K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV53FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXWebForm Form ;
      private GXWindow AV41Window ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV7Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV42CurrentApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV19Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV20GAMApplicationFilter ;
      private SdtK2BGridState AV23GridState ;
      private SdtK2BGridState_FilterValue AV24GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV32Message ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV45K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV49GridConfiguration ;
   }

   public class wwmenu__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwmenu__default : DataStoreHelperBase, IDataStoreHelper
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
