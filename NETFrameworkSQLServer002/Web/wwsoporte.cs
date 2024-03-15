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
namespace GeneXus.Programs {
   public class wwsoporte : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwsoporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public wwsoporte( IGxContext context )
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
         chkavAtt_soporteid_visible = new GXCheckbox();
         chkavAtt_hostname_visible = new GXCheckbox();
         chkavAtt_serie_visible = new GXCheckbox();
         chkavAtt_ipv4_visible = new GXCheckbox();
         chkavAtt_mac_visible = new GXCheckbox();
         chkavAtt_modelo_visible = new GXCheckbox();
         chkavAtt_nombreusuario_visible = new GXCheckbox();
         chkavAtt_nombredepartamento_visible = new GXCheckbox();
         cmbavGridsettingsrowsperpagevariable = new GXCombobox();
         chkavFreezecolumntitles = new GXCheckbox();
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
         nRC_GXsfl_161 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_161"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_161_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_161_idx = GetPar( "sGXsfl_161_idx");
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
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV36K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
         AV31hostName_Filter = GetPar( "hostName_Filter");
         AV37OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV54Pgmname = GetPar( "Pgmname");
         AV11CurrentPage = (int)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13GridConfiguration);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30ClassCollection);
         AV46hostName_IsAuthorized = StringUtil.StrToBool( GetPar( "hostName_IsAuthorized"));
         AV17Att_soporteID_Visible = StringUtil.StrToBool( GetPar( "Att_soporteID_Visible"));
         AV18Att_hostName_Visible = StringUtil.StrToBool( GetPar( "Att_hostName_Visible"));
         AV19Att_serie_Visible = StringUtil.StrToBool( GetPar( "Att_serie_Visible"));
         AV20Att_ipv4_Visible = StringUtil.StrToBool( GetPar( "Att_ipv4_Visible"));
         AV21Att_mac_Visible = StringUtil.StrToBool( GetPar( "Att_mac_Visible"));
         AV22Att_modelo_Visible = StringUtil.StrToBool( GetPar( "Att_modelo_Visible"));
         AV23Att_nombreUsuario_Visible = StringUtil.StrToBool( GetPar( "Att_nombreUsuario_Visible"));
         AV53Att_nombreDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_nombreDepartamento_Visible"));
         AV14FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
         AV43Uri = GetPar( "Uri");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
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
            return "soporte_Execute" ;
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
         PA2S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2S2( ) ;
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
         context.AddJavascriptSource("K2BGridExtensions/K2BGridExtensionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwsoporte.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV43Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV36K2BToolsGenericSearchField));
         GxWebStd.gx_hidden_field( context, "GXH_vHOSTNAME_FILTER", AV31hostName_Filter);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_161", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_161), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGS", AV34FilterTags);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGS", AV34FilterTags);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG", StringUtil.RTrim( AV35DeletedTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDMETADATA", AV8GridMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDMETADATA", AV8GridMetadata);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40UC_OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV30ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV30ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11CurrentPage), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV13GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV13GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vHOSTNAME_ISAUTHORIZED", AV46hostName_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25RowsPerPageVariable), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV43Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSUMMARYTAGSUC_Emptystatemessage", StringUtil.RTrim( Filtersummarytagsuc_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "EXTENDEDGRIDUC_Gridcontrolname", StringUtil.RTrim( Extendedgriduc_Gridcontrolname));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vHOSTNAME_FILTER_Caption", StringUtil.RTrim( edtavHostname_filter_Caption));
         GxWebStd.gx_hidden_field( context, "K2BGRIDSETTINGSCONTENTOUTERTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERCOLLAPSIBLESECTION_COMBINED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOWNLOADACTIONSTABLE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divDownloadactionstable_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttReport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXPORT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttExport_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vHOSTNAME_FILTER_Caption", StringUtil.RTrim( edtavHostname_filter_Caption));
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
            WE2S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2S2( ) ;
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
         return formatLink("wwsoporte.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWsoporte" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "SOPORTE", "") ;
      }

      protected void WB2S0( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, context.GetMessage( "SOPORTE", ""), "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WorkWithContentTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainersection_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterglobalcontainer_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombinedfilterlayout_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "K2BT_CombinedFiltersWrapper", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BT_SearchContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_161_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV36K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV36K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "K2BT_GenericFilterInviteMessage", ""), edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgFiltertoggle_combined_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgFiltertoggle_combined_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgFiltertoggle_combined_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgFiltertoggle_combined_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112s1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltersummarytagsuc.SetProperty("TagValues", AV34FilterTags);
            ucFiltersummarytagsuc.SetProperty("DeletedTag", AV35DeletedTag);
            ucFiltersummarytagsuc.Render(context, "k2btagsviewer", Filtersummarytagsuc_Internalname, "FILTERSUMMARYTAGSUCContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercollapsiblesection_combined_Internalname, divFiltercollapsiblesection_combined_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable K2BT_EditableForm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolsfilterscontainer_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterattributestable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerhostname_filter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavHostname_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHostname_filter_Internalname, context.GetMessage( "Name", ""), "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_161_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHostname_filter_Internalname, AV31hostName_Filter, StringUtil.RTrim( context.localUtil.Format( AV31hostName_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHostname_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavHostname_filter_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingstable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgK2bgridsettingslabel_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgK2bgridsettingslabel_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", context.GetMessage( "K2BT_GridSettingsLabel", ""), 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122s1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2bgridsettingscontentoutertable_Internalname, divK2bgridsettingscontentoutertable_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, context.GetMessage( "K2BT_GridSettingsLabel", ""), "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettingstable_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSoporteid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_soporteid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_soporteid_visible_Internalname, context.GetMessage( "ID", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_soporteid_visible_Internalname, StringUtil.BoolToStr( AV17Att_soporteID_Visible), "", context.GetMessage( "ID", ""), 1, chkavAtt_soporteid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            GxWebStd.gx_div_start( context, divHostname_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_hostname_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_hostname_visible_Internalname, context.GetMessage( "HostName", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_hostname_visible_Internalname, StringUtil.BoolToStr( AV18Att_hostName_Visible), "", context.GetMessage( "HostName", ""), 1, chkavAtt_hostname_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_div_start( context, divSerie_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_serie_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_serie_visible_Internalname, context.GetMessage( "Serie", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_serie_visible_Internalname, StringUtil.BoolToStr( AV19Att_serie_Visible), "", context.GetMessage( "Serie", ""), 1, chkavAtt_serie_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
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
            GxWebStd.gx_div_start( context, divIpv4_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_ipv4_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_ipv4_visible_Internalname, context.GetMessage( "IPV4", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_ipv4_visible_Internalname, StringUtil.BoolToStr( AV20Att_ipv4_Visible), "", context.GetMessage( "IPV4", ""), 1, chkavAtt_ipv4_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
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
            GxWebStd.gx_div_start( context, divMac_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_mac_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_mac_visible_Internalname, context.GetMessage( "MAC", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_mac_visible_Internalname, StringUtil.BoolToStr( AV21Att_mac_Visible), "", context.GetMessage( "MAC", ""), 1, chkavAtt_mac_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            GxWebStd.gx_div_start( context, divModelo_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_modelo_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_modelo_visible_Internalname, context.GetMessage( "Modelo", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_modelo_visible_Internalname, StringUtil.BoolToStr( AV22Att_modelo_Visible), "", context.GetMessage( "Modelo", ""), 1, chkavAtt_modelo_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(106, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,106);\"");
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
            GxWebStd.gx_div_start( context, divNombreusuario_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_nombreusuario_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombreusuario_visible_Internalname, context.GetMessage( "NombreUsuario", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombreusuario_visible_Internalname, StringUtil.BoolToStr( AV23Att_nombreUsuario_Visible), "", context.GetMessage( "NombreUsuario", ""), 1, chkavAtt_nombreusuario_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
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
            GxWebStd.gx_div_start( context, divNombredepartamento_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavAtt_nombredepartamento_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_nombredepartamento_visible_Internalname, context.GetMessage( "Departamento", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_nombredepartamento_visible_Internalname, StringUtil.BoolToStr( AV53Att_nombreDepartamento_Visible), "", context.GetMessage( "Departamento", ""), 1, chkavAtt_nombredepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
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
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpagevariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpagevariable_Internalname, context.GetMessage( "K2BT_RowsPerPage", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_161_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "", true, 0, "HLP_WWsoporte.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", (string)(cmbavGridsettingsrowsperpagevariable.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezegridcolumntitlescontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_Internalname, context.GetMessage( "K2BT_FreezeColumnTitles", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_161_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_Internalname, StringUtil.BoolToStr( AV14FreezeColumnTitles), "", context.GetMessage( "K2BT_FreezeColumnTitles", ""), 1, chkavFreezecolumntitles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(161), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_GridSettingsApply", ""), bttK2bgridsettingssave_Jsonclick, 5, context.GetMessage( "K2BT_GridSettingsApply", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divDownloadsactionssectioncontainer_Internalname, divDownloadsactionssectioncontainer_Visible, 0, "px", 0, "px", "K2BToolsTable_DownloadActionsContainer ControlBeautify_ParentCollapsableTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "Image_ToggleDownloadsAction" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_K2BActionDownload_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c006d24f-342a-4714-a998-3641e764d052", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e132s1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDownloadactionstable_Internalname, divDownloadactionstable_Visible, 0, "px", 0, "px", "K2BToolsDownloadActionsTable ControlBeautify_CollapsableTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btabledownloadssectioncontainer_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(161), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_ReportAction", ""), bttReport_Jsonclick, 5, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWsoporte.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(161), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_ExportAction", ""), bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divK2btableactionsrightcontainer_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(161), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_InsertAction", ""), bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divGlobalgridtable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
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
            StartGridControl161( ) ;
         }
         if ( wbEnd == 161 )
         {
            wbEnd = 0;
            nRC_GXsfl_161 = (int)(nGXsfl_161_idx-1);
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
            wb_table1_174_2S2( true) ;
         }
         else
         {
            wb_table1_174_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_174_2S2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection8_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divK2btoolspagingcontainertable_Internalname, divK2btoolspagingcontainertable_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWsoporte.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
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
            GxWebStd.gx_div_start( context, divK2btoolsabstracthiddenitemsgrid_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucExtendedgriduc.SetProperty("GridMetadata", AV8GridMetadata);
            ucExtendedgriduc.SetProperty("SelectedOrderBy", AV40UC_OrderedBy);
            ucExtendedgriduc.Render(context, "k2bgridextensions", Extendedgriduc_Internalname, "EXTENDEDGRIDUCContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 161 )
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

      protected void START2S2( )
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
         Form.Meta.addItem("description", context.GetMessage( "SOPORTE", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2S0( ) ;
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "FILTERSUMMARYTAGSUC.TAGDELETED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "EXTENDEDGRIDUC.ORDERBYCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E152S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E162S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReport' */
                              E172S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E182S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E192S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E202S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E212S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E222S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E232S2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
                              SubsflControlProps_1612( ) ;
                              A4soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtsoporteID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A5hostName = cgiGet( edthostName_Internalname);
                              A9serie = cgiGet( edtserie_Internalname);
                              A10ipv4 = cgiGet( edtipv4_Internalname);
                              A11mac = cgiGet( edtmac_Internalname);
                              A12modelo = cgiGet( edtmodelo_Internalname);
                              A13nombreUsuario = cgiGet( edtnombreUsuario_Internalname);
                              A14nombreDepartamento = cgiGet( edtnombreDepartamento_Internalname);
                              AV47Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV47Update))), !bGXsfl_161_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV47Update), true);
                              AV48Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV48Delete))), !bGXsfl_161_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV48Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E242S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E252S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E262S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E272S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV36K2BToolsGenericSearchField) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Hostname_filter Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vHOSTNAME_FILTER"), AV31hostName_Filter) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE2S2( )
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

      protected void PA2S2( )
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
               GX_FocusControl = edtavK2btoolsgenericsearchfield_Internalname;
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
         SubsflControlProps_1612( ) ;
         while ( nGXsfl_161_idx <= nRC_GXsfl_161 )
         {
            sendrow_1612( ) ;
            nGXsfl_161_idx = ((subGrid_Islastpage==1)&&(nGXsfl_161_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_1612( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV36K2BToolsGenericSearchField ,
                                       string AV31hostName_Filter ,
                                       short AV37OrderedBy ,
                                       string AV54Pgmname ,
                                       int AV11CurrentPage ,
                                       SdtK2BGridConfiguration AV13GridConfiguration ,
                                       GxSimpleCollection<string> AV30ClassCollection ,
                                       bool AV46hostName_IsAuthorized ,
                                       bool AV17Att_soporteID_Visible ,
                                       bool AV18Att_hostName_Visible ,
                                       bool AV19Att_serie_Visible ,
                                       bool AV20Att_ipv4_Visible ,
                                       bool AV21Att_mac_Visible ,
                                       bool AV22Att_modelo_Visible ,
                                       bool AV23Att_nombreUsuario_Visible ,
                                       bool AV53Att_nombreDepartamento_Visible ,
                                       bool AV14FreezeColumnTitles ,
                                       string AV43Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOPORTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SOPORTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4soporteID), 9, 0, ".", "")));
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
         AV17Att_soporteID_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_soporteID_Visible));
         AssignAttri("", false, "AV17Att_soporteID_Visible", AV17Att_soporteID_Visible);
         AV18Att_hostName_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_hostName_Visible));
         AssignAttri("", false, "AV18Att_hostName_Visible", AV18Att_hostName_Visible);
         AV19Att_serie_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_serie_Visible));
         AssignAttri("", false, "AV19Att_serie_Visible", AV19Att_serie_Visible);
         AV20Att_ipv4_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ipv4_Visible));
         AssignAttri("", false, "AV20Att_ipv4_Visible", AV20Att_ipv4_Visible);
         AV21Att_mac_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_mac_Visible));
         AssignAttri("", false, "AV21Att_mac_Visible", AV21Att_mac_Visible);
         AV22Att_modelo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_modelo_Visible));
         AssignAttri("", false, "AV22Att_modelo_Visible", AV22Att_modelo_Visible);
         AV23Att_nombreUsuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_nombreUsuario_Visible));
         AssignAttri("", false, "AV23Att_nombreUsuario_Visible", AV23Att_nombreUsuario_Visible);
         AV53Att_nombreDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Att_nombreDepartamento_Visible));
         AssignAttri("", false, "AV53Att_nombreDepartamento_Visible", AV53Att_nombreDepartamento_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV14FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV14FreezeColumnTitles));
         AssignAttri("", false, "AV14FreezeColumnTitles", AV14FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E252S2 ();
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "WWsoporte";
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 161;
         /* Execute user event: Refresh */
         E252S2 ();
         E262S2 ();
         nGXsfl_161_idx = 1;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_1612( ) ;
         bGXsfl_161_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1612( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31hostName_Filter ,
                                                 AV36K2BToolsGenericSearchField ,
                                                 A5hostName ,
                                                 A4soporteID ,
                                                 A10ipv4 ,
                                                 A11mac ,
                                                 A12modelo ,
                                                 A13nombreUsuario ,
                                                 A14nombreDepartamento ,
                                                 AV37OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            lV31hostName_Filter = StringUtil.Concat( StringUtil.RTrim( AV31hostName_Filter), "%", "");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H002S2 */
            pr_default.execute(0, new Object[] {lV31hostName_Filter, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_161_idx = 1;
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_1612( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A14nombreDepartamento = H002S2_A14nombreDepartamento[0];
               A13nombreUsuario = H002S2_A13nombreUsuario[0];
               A12modelo = H002S2_A12modelo[0];
               A11mac = H002S2_A11mac[0];
               A10ipv4 = H002S2_A10ipv4[0];
               A9serie = H002S2_A9serie[0];
               A5hostName = H002S2_A5hostName[0];
               A4soporteID = H002S2_A4soporteID[0];
               E272S2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 161;
            WB2S0( ) ;
         }
         bGXsfl_161_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SOPORTEID"+"_"+sGXsfl_161_idx, GetSecureSignedToken( sGXsfl_161_idx, context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV43Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV31hostName_Filter ,
                                              AV36K2BToolsGenericSearchField ,
                                              A5hostName ,
                                              A4soporteID ,
                                              A10ipv4 ,
                                              A11mac ,
                                              A12modelo ,
                                              A13nombreUsuario ,
                                              A14nombreDepartamento ,
                                              AV37OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV31hostName_Filter = StringUtil.Concat( StringUtil.RTrim( AV31hostName_Filter), "%", "");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         lV36K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV36K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H002S3 */
         pr_default.execute(1, new Object[] {lV31hostName_Filter, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField, lV36K2BToolsGenericSearchField});
         GRID_nRecordCount = H002S3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "WWsoporte";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E242S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGS"), AV34FilterTags);
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDMETADATA"), AV8GridMetadata);
            /* Read saved values. */
            nRC_GXsfl_161 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_161"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV35DeletedTag = cgiGet( "vDELETEDTAG");
            AV40UC_OrderedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Filtersummarytagsuc_Emptystatemessage = cgiGet( "FILTERSUMMARYTAGSUC_Emptystatemessage");
            Extendedgriduc_Gridcontrolname = cgiGet( "EXTENDEDGRIDUC_Gridcontrolname");
            bttReport_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "REPORT_Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            bttExport_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            edtavHostname_filter_Caption = cgiGet( "vHOSTNAME_FILTER_Caption");
            /* Read variables values. */
            AV36K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV36K2BToolsGenericSearchField", AV36K2BToolsGenericSearchField);
            AV31hostName_Filter = cgiGet( edtavHostname_filter_Internalname);
            AssignAttri("", false, "AV31hostName_Filter", AV31hostName_Filter);
            AV17Att_soporteID_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_soporteid_visible_Internalname));
            AssignAttri("", false, "AV17Att_soporteID_Visible", AV17Att_soporteID_Visible);
            AV18Att_hostName_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_hostname_visible_Internalname));
            AssignAttri("", false, "AV18Att_hostName_Visible", AV18Att_hostName_Visible);
            AV19Att_serie_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_serie_visible_Internalname));
            AssignAttri("", false, "AV19Att_serie_Visible", AV19Att_serie_Visible);
            AV20Att_ipv4_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_ipv4_visible_Internalname));
            AssignAttri("", false, "AV20Att_ipv4_Visible", AV20Att_ipv4_Visible);
            AV21Att_mac_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_mac_visible_Internalname));
            AssignAttri("", false, "AV21Att_mac_Visible", AV21Att_mac_Visible);
            AV22Att_modelo_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_modelo_visible_Internalname));
            AssignAttri("", false, "AV22Att_modelo_Visible", AV22Att_modelo_Visible);
            AV23Att_nombreUsuario_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombreusuario_visible_Internalname));
            AssignAttri("", false, "AV23Att_nombreUsuario_Visible", AV23Att_nombreUsuario_Visible);
            AV53Att_nombreDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_nombredepartamento_visible_Internalname));
            AssignAttri("", false, "AV53Att_nombreDepartamento_Visible", AV53Att_nombreDepartamento_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV24GridSettingsRowsPerPageVariable = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
            AV14FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV14FreezeColumnTitles", AV14FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV36K2BToolsGenericSearchField) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vHOSTNAME_FILTER"), AV31hostName_Filter) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E242S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E242S2( )
      {
         /* Start Routine */
         returnInSub = false;
         divFiltercollapsiblesection_combined_Visible = 0;
         AssignProp("", false, divFiltercollapsiblesection_combined_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFiltercollapsiblesection_combined_Visible), 5, 0), true);
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         AV31hostName_Filter = "";
         AssignAttri("", false, "AV31hostName_Filter", AV31hostName_Filter);
         new k2bloadrowsperpage(context ).execute(  AV54Pgmname,  "Grid", out  AV25RowsPerPageVariable, out  AV26RowsPerPageLoaded) ;
         AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         if ( ! AV26RowsPerPageLoaded )
         {
            AV25RowsPerPageVariable = 20;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
         }
         AV24GridSettingsRowsPerPageVariable = AV25RowsPerPageVariable;
         AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV25RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = context.GetMessage( "SOPORTE", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Extendedgriduc_Gridcontrolname = subGrid_Internalname;
         ucExtendedgriduc.SendProperty(context, "", false, Extendedgriduc_Internalname, "GridControlName", Extendedgriduc_Gridcontrolname);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E252S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV44Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV44Messages = GXt_objcol_SdtMessages_Message1;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV44Messages.Count )
         {
            AV45Message = ((GeneXus.Utils.SdtMessages_Message)AV44Messages.Item(AV55GXV1));
            GX_msglist.addItem(AV45Message.gxTpr_Description);
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV51ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV54Pgmname;
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV51ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = context.GetMessage( "GXM_insert", "");
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         edtavUpdate_gximage = "K2BActionUpdate";
         AssignProp("", false, edtavUpdate_Internalname, "gximage", edtavUpdate_gximage, !bGXsfl_161_Refreshing);
         AV47Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV47Update))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV47Update), true);
         AV56Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV47Update))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV47Update), true);
         edtavUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_161_Refreshing);
         edtavDelete_gximage = "K2BActionDelete";
         AssignProp("", false, edtavDelete_Internalname, "gximage", edtavDelete_gximage, !bGXsfl_161_Refreshing);
         AV48Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV48Delete))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV48Delete), true);
         AV57Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV48Delete))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV48Delete), true);
         edtavDelete_Tooltiptext = context.GetMessage( "GXM_captiondelete", "");
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_161_Refreshing);
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV30ClassCollection) ;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV30ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV54Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV37OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV37OrderedBy", StringUtil.LTrimStr( (decimal)(AV37OrderedBy), 4, 0));
         AV40UC_OrderedBy = AV28GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV40UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV40UC_OrderedBy), 4, 0));
         AV58GXV2 = 1;
         while ( AV58GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV58GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "hostName_Filter") == 0 )
            {
               AV31hostName_Filter = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31hostName_Filter", AV31hostName_Filter);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV36K2BToolsGenericSearchField = AV29GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36K2BToolsGenericSearchField", AV36K2BToolsGenericSearchField);
            }
            AV58GXV2 = (int)(AV58GXV2+1);
         }
         AV12K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV28GridState.gxTpr_Currentpage > 0 ) && ( AV28GridState.gxTpr_Currentpage <= AV12K2BMaxPages ) )
         {
            AV11CurrentPage = AV28GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
            subgrid_gotopage( AV11CurrentPage) ;
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV54Pgmname,  AV27GridStateKey, out  AV28GridState) ;
         AV28GridState.gxTpr_Currentpage = (short)(AV11CurrentPage);
         AV28GridState.gxTpr_Orderedby = AV37OrderedBy;
         AV28GridState.gxTpr_Filtervalues.Clear();
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "hostName_Filter";
         AV29GridStateFilterValue.gxTpr_Value = AV31hostName_Filter;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV29GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV29GridStateFilterValue.gxTpr_Value = AV36K2BToolsGenericSearchField;
         AV28GridState.gxTpr_Filtervalues.Add(AV29GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV54Pgmname,  AV27GridStateKey,  AV28GridState) ;
      }

      protected void S192( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV49TrnContext = new SdtK2BTrnContext(context);
         AV49TrnContext.gxTpr_Callerurl = AV7HttpRequest.ScriptName+"?"+AV7HttpRequest.QueryString;
         AV49TrnContext.gxTpr_Returnmode = "Stack";
         AV49TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV49TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV49TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV49TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV49TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV49TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "soporte",  AV49TrnContext) ;
      }

      protected void E162S2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "soporte",  "soporte",  "Insert",  "",  "EntityManagersoporte") )
         {
            CallWebObject(formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","soporteID","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E172S2( )
      {
         /* 'DoReport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "soporte",  "soporte",  "List",  "",  AV54Pgmname) )
         {
            AV6Window.Url = formatLink("reportwwsoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV31hostName_Filter)),UrlEncode(StringUtil.RTrim(AV36K2BToolsGenericSearchField)),UrlEncode(StringUtil.LTrimStr(AV37OrderedBy,4,0))}, new string[] {"hostName_Filter","K2BToolsGenericSearchField","OrderedBy"}) ;
            AV6Window.SetReturnParms(new Object[] {});
            AV6Window.Autoresize = 1;
            context.NewWindow(AV6Window);
         }
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtsoporteID_Visible = 1;
         AssignProp("", false, edtsoporteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtsoporteID_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV17Att_soporteID_Visible = true;
         AssignAttri("", false, "AV17Att_soporteID_Visible", AV17Att_soporteID_Visible);
         edthostName_Visible = 1;
         AssignProp("", false, edthostName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edthostName_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV18Att_hostName_Visible = true;
         AssignAttri("", false, "AV18Att_hostName_Visible", AV18Att_hostName_Visible);
         edtserie_Visible = 1;
         AssignProp("", false, edtserie_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtserie_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV19Att_serie_Visible = true;
         AssignAttri("", false, "AV19Att_serie_Visible", AV19Att_serie_Visible);
         edtipv4_Visible = 1;
         AssignProp("", false, edtipv4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtipv4_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV20Att_ipv4_Visible = true;
         AssignAttri("", false, "AV20Att_ipv4_Visible", AV20Att_ipv4_Visible);
         edtmac_Visible = 1;
         AssignProp("", false, edtmac_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtmac_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV21Att_mac_Visible = true;
         AssignAttri("", false, "AV21Att_mac_Visible", AV21Att_mac_Visible);
         edtmodelo_Visible = 1;
         AssignProp("", false, edtmodelo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtmodelo_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV22Att_modelo_Visible = true;
         AssignAttri("", false, "AV22Att_modelo_Visible", AV22Att_modelo_Visible);
         edtnombreUsuario_Visible = 1;
         AssignProp("", false, edtnombreUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombreUsuario_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV23Att_nombreUsuario_Visible = true;
         AssignAttri("", false, "AV23Att_nombreUsuario_Visible", AV23Att_nombreUsuario_Visible);
         edtnombreDepartamento_Visible = 1;
         AssignProp("", false, edtnombreDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombreDepartamento_Visible), 5, 0), !bGXsfl_161_Refreshing);
         AV53Att_nombreDepartamento_Visible = true;
         AssignAttri("", false, "AV53Att_nombreDepartamento_Visible", AV53Att_nombreDepartamento_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV54Pgmname,  context.GetMessage( "Grid", ""),  AV13GridConfiguration,  false) ;
         AV59GXV3 = 1;
         while ( AV59GXV3 <= AV13GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV16GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV13GridConfiguration.gxTpr_Gridcolumns.Item(AV59GXV3));
            if ( ! AV16GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "soporteID") == 0 )
               {
                  edtsoporteID_Visible = 0;
                  AssignProp("", false, edtsoporteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtsoporteID_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV17Att_soporteID_Visible = false;
                  AssignAttri("", false, "AV17Att_soporteID_Visible", AV17Att_soporteID_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "hostName") == 0 )
               {
                  edthostName_Visible = 0;
                  AssignProp("", false, edthostName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edthostName_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV18Att_hostName_Visible = false;
                  AssignAttri("", false, "AV18Att_hostName_Visible", AV18Att_hostName_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "serie") == 0 )
               {
                  edtserie_Visible = 0;
                  AssignProp("", false, edtserie_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtserie_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV19Att_serie_Visible = false;
                  AssignAttri("", false, "AV19Att_serie_Visible", AV19Att_serie_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "ipv4") == 0 )
               {
                  edtipv4_Visible = 0;
                  AssignProp("", false, edtipv4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtipv4_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV20Att_ipv4_Visible = false;
                  AssignAttri("", false, "AV20Att_ipv4_Visible", AV20Att_ipv4_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "mac") == 0 )
               {
                  edtmac_Visible = 0;
                  AssignProp("", false, edtmac_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtmac_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV21Att_mac_Visible = false;
                  AssignAttri("", false, "AV21Att_mac_Visible", AV21Att_mac_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "modelo") == 0 )
               {
                  edtmodelo_Visible = 0;
                  AssignProp("", false, edtmodelo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtmodelo_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV22Att_modelo_Visible = false;
                  AssignAttri("", false, "AV22Att_modelo_Visible", AV22Att_modelo_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "nombreUsuario") == 0 )
               {
                  edtnombreUsuario_Visible = 0;
                  AssignProp("", false, edtnombreUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombreUsuario_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV23Att_nombreUsuario_Visible = false;
                  AssignAttri("", false, "AV23Att_nombreUsuario_Visible", AV23Att_nombreUsuario_Visible);
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "nombreDepartamento") == 0 )
               {
                  edtnombreDepartamento_Visible = 0;
                  AssignProp("", false, edtnombreDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtnombreDepartamento_Visible), 5, 0), !bGXsfl_161_Refreshing);
                  AV53Att_nombreDepartamento_Visible = false;
                  AssignAttri("", false, "AV53Att_nombreDepartamento_Visible", AV53Att_nombreDepartamento_Visible);
               }
            }
            AV59GXV3 = (int)(AV59GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV15GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "test");
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "soporteID";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "ID", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "hostName";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "HostName", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "serie";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "Serie", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "ipv4";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "IPV4", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "mac";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "MAC", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "modelo";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "Modelo", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "nombreUsuario";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "NombreUsuario", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "nombreDepartamento";
         AV16GridColumn.gxTpr_Columntitle = context.GetMessage( "Departamento", "");
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV13GridConfiguration.gxTpr_Gridcolumns = AV15GridColumns;
      }

      protected void S142( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYINGRIDACTIONS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'DISPLAYPERSISTENTACTIONS' Routine */
         returnInSub = false;
         AV51ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWsoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWsoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagersoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV51ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttInsert_Visible = 1;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
         else
         {
            bttInsert_Visible = 0;
            AssignProp("", false, bttInsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttInsert_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYINGRIDACTIONS' Routine */
         returnInSub = false;
         AV51ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagersoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagersoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "soporte";
         AV52ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagersoporte";
         AV51ActivityList.Add(AV52ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV51ActivityList) ;
         AV46hostName_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV46hostName_IsAuthorized", AV46hostName_IsAuthorized);
         edtavUpdate_Visible = (((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(2)).gxTpr_Isauthorized ? 1 : 0);
         AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_161_Refreshing);
         edtavDelete_Visible = (((SdtK2BActivityList_K2BActivityListItem)AV51ActivityList.Item(3)).gxTpr_Isauthorized ? 1 : 0);
         AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_161_Refreshing);
      }

      protected void S152( )
      {
         /* 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' Routine */
         returnInSub = false;
         if ( ( bttReport_Visible == 1 ) || ( bttExport_Visible == 1 ) )
         {
            divDownloadsactionssectioncontainer_Visible = 1;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
         else
         {
            divDownloadsactionssectioncontainer_Visible = 0;
            AssignProp("", false, divDownloadsactionssectioncontainer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadsactionssectioncontainer_Visible), 5, 0), true);
         }
      }

      protected void E262S2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = context.GetMessage( "GXM_insert", "");
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         edtavUpdate_gximage = "K2BActionUpdate";
         AssignProp("", false, edtavUpdate_Internalname, "gximage", edtavUpdate_gximage, !bGXsfl_161_Refreshing);
         AV47Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV47Update))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV47Update), true);
         AV56Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.convertURL( context.PathToRelativeUrl( AV47Update))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV47Update), true);
         edtavUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_161_Refreshing);
         edtavDelete_gximage = "K2BActionDelete";
         AssignProp("", false, edtavDelete_Internalname, "gximage", edtavDelete_gximage, !bGXsfl_161_Refreshing);
         AV48Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV48Delete))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV48Delete), true);
         AV57Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV48Delete))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV48Delete), true);
         edtavDelete_Tooltiptext = context.GetMessage( "GXM_captiondelete", "");
         AssignProp("", false, edtavDelete_Internalname, "Tooltiptext", edtavDelete_Tooltiptext, !bGXsfl_161_Refreshing);
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEDOWNLOADSSECTIONACTIONSVISIBILITY' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         tblNoresultsfoundtable_Visible = 1;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         AV40UC_OrderedBy = AV37OrderedBy;
         AssignAttri("", false, "AV40UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV40UC_OrderedBy), 4, 0));
         /* Execute user subroutine: 'APPLYGRIDCONFIGURATION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Backcolorstyle = 3;
         AV8GridMetadata = new SdtK2BT_ExtendedGridMetadata(context);
         AV8GridMetadata.gxTpr_Overflowactionposition = "Right";
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:soporteID";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = 0;
         AV9GridMetadataColumn.gxTpr_Descendingorder = 1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:hostName";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = 2;
         AV9GridMetadataColumn.gxTpr_Descendingorder = 3;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:serie";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:ipv4";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:mac";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:modelo";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:nombreUsuario";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "att:nombreDepartamento";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         AV10GridMetadataColumnGroup.gxTpr_Canbemoved = false;
         AV10GridMetadataColumnGroup.gxTpr_Membercolumnnames.Add(AV9GridMetadataColumn.gxTpr_Name, 0);
         AV8GridMetadata.gxTpr_Columngroups.Add(AV10GridMetadataColumnGroup, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "action:Update";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV9GridMetadataColumn.gxTpr_Name = "action:Delete";
         AV9GridMetadataColumn.gxTpr_Filtersectioninternalname = "";
         AV9GridMetadataColumn.gxTpr_Containsactivefilter = false;
         AV9GridMetadataColumn.gxTpr_Ascendingorder = -1;
         AV9GridMetadataColumn.gxTpr_Descendingorder = -1;
         AV8GridMetadata.gxTpr_Columns.Add(AV9GridMetadataColumn, 0);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8GridMetadata", AV8GridMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34FilterTags", AV34FilterTags);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      private void E272S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV46hostName_IsAuthorized )
         {
            edthostName_Link = formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","soporteID","TabCode"}) ;
         }
         else
         {
            edthostName_Link = "";
         }
         edtavUpdate_Link = formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","soporteID","TabCode"}) ;
         edtavUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         edtavDelete_Link = formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","soporteID","TabCode"}) ;
         edtavDelete_Tooltiptext = context.GetMessage( "GXM_captiondelete", "");
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 161;
         }
         sendrow_1612( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_161_Refreshing )
         {
            context.DoAjaxLoad(161, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATEFILTERSUMMARY' Routine */
         returnInSub = false;
         AV32K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31hostName_Filter)) )
         {
            AV33K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV33K2BFilterValuesSDTItem.gxTpr_Name = "hostName_Filter";
            AV33K2BFilterValuesSDTItem.gxTpr_Description = edtavHostname_filter_Caption;
            AV33K2BFilterValuesSDTItem.gxTpr_Canbedeleted = true;
            AV33K2BFilterValuesSDTItem.gxTpr_Type = "Standard";
            AV33K2BFilterValuesSDTItem.gxTpr_Value = AV31hostName_Filter;
            AV33K2BFilterValuesSDTItem.gxTpr_Valuedescription = StringUtil.RTrim( context.localUtil.Format( AV31hostName_Filter, ""));
            AV32K2BFilterValuesSDT.Add(AV33K2BFilterValuesSDTItem, 0);
         }
         Filtersummarytagsuc_Emptystatemessage = context.GetMessage( "K2BT_FilterSummaryEmptyState", "");
         ucFiltersummarytagsuc.SendProperty(context, "", false, Filtersummarytagsuc_Internalname, "EmptyStateMessage", Filtersummarytagsuc_Emptystatemessage);
         if ( AV32K2BFilterValuesSDT.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV34FilterTags;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV54Pgmname,  context.GetMessage( "Grid", ""),  AV32K2BFilterValuesSDT, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV34FilterTags = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E142S2( )
      {
         /* Filtersummarytagsuc_Tagdeleted Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35DeletedTag, "hostName_Filter") == 0 )
         {
            AV31hostName_Filter = "";
            AssignAttri("", false, "AV31hostName_Filter", AV31hostName_Filter);
         }
         gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void E152S2( )
      {
         /* Extendedgriduc_Orderbychanged Routine */
         returnInSub = false;
         AV37OrderedBy = AV40UC_OrderedBy;
         AssignAttri("", false, "AV37OrderedBy", StringUtil.LTrimStr( (decimal)(AV37OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void E182S2( )
      {
         /* 'SaveGridSettings' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV54Pgmname,  "Grid", ref  AV13GridConfiguration) ;
         AV60GXV4 = 1;
         while ( AV60GXV4 <= AV13GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV16GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV13GridConfiguration.gxTpr_Gridcolumns.Item(AV60GXV4));
            if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "soporteID") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV17Att_soporteID_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "hostName") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV18Att_hostName_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "serie") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV19Att_serie_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "ipv4") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV20Att_ipv4_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "mac") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV21Att_mac_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "modelo") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV22Att_modelo_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "nombreUsuario") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV23Att_nombreUsuario_Visible;
            }
            else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "nombreDepartamento") == 0 )
            {
               AV16GridColumn.gxTpr_Showattribute = AV53Att_nombreDepartamento_Visible;
            }
            AV60GXV4 = (int)(AV60GXV4+1);
         }
         AV13GridConfiguration.gxTpr_Freezecolumntitles = AV14FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV54Pgmname,  "Grid",  AV13GridConfiguration,  true) ;
         AV40UC_OrderedBy = AV37OrderedBy;
         AssignAttri("", false, "AV40UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV40UC_OrderedBy), 4, 0));
         if ( AV25RowsPerPageVariable != AV24GridSettingsRowsPerPageVariable )
         {
            AV25RowsPerPageVariable = AV24GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV25RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV25RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV25RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV54Pgmname,  "Grid",  AV25RowsPerPageVariable) ;
            AV11CurrentPage = 1;
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV36K2BToolsGenericSearchField, AV31hostName_Filter, AV37OrderedBy, AV54Pgmname, AV11CurrentPage, AV13GridConfiguration, AV30ClassCollection, AV46hostName_IsAuthorized, AV17Att_soporteID_Visible, AV18Att_hostName_Visible, AV19Att_serie_Visible, AV20Att_ipv4_Visible, AV21Att_mac_Visible, AV22Att_modelo_Visible, AV23Att_nombreUsuario_Visible, AV53Att_nombreDepartamento_Visible, AV14FreezeColumnTitles, AV43Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
      }

      protected void S172( )
      {
         /* 'DISPLAYPAGINGBUTTONS' Routine */
         returnInSub = false;
         AV12K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV11CurrentPage > AV12K2BMaxPages ) && ( AV12K2BMaxPages > 0 ) )
         {
            AV11CurrentPage = (int)(AV12K2BMaxPages);
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
            subgrid_lastpage( ) ;
            context.DoAjaxRefresh();
         }
         if ( AV12K2BMaxPages == 0 )
         {
            AV11CurrentPage = 1;
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
         }
         else
         {
            AV11CurrentPage = subGrid_fnc_Currentpage( );
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
         }
         lblFirstpagetextblock_Caption = "1";
         AssignProp("", false, lblFirstpagetextblock_Internalname, "Caption", lblFirstpagetextblock_Caption, true);
         lblPreviouspagetextblock_Caption = StringUtil.Str( (decimal)(AV11CurrentPage-1), 10, 0);
         AssignProp("", false, lblPreviouspagetextblock_Internalname, "Caption", lblPreviouspagetextblock_Caption, true);
         lblCurrentpagetextblock_Caption = StringUtil.Str( (decimal)(AV11CurrentPage), 5, 0);
         AssignProp("", false, lblCurrentpagetextblock_Internalname, "Caption", lblCurrentpagetextblock_Caption, true);
         lblNextpagetextblock_Caption = StringUtil.Str( (decimal)(AV11CurrentPage+1), 10, 0);
         AssignProp("", false, lblNextpagetextblock_Internalname, "Caption", lblNextpagetextblock_Caption, true);
         lblLastpagetextblock_Caption = StringUtil.Str( (decimal)(AV12K2BMaxPages), 18, 0);
         AssignProp("", false, lblLastpagetextblock_Internalname, "Caption", lblLastpagetextblock_Caption, true);
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
         if ( (0==AV11CurrentPage) || ( AV11CurrentPage <= 1 ) )
         {
            lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPreviouspagebuttontextblock_Internalname, "Class", lblPreviouspagebuttontextblock_Class, true);
            lblFirstpagetextblock_Visible = 0;
            AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
            lblSpacinglefttextblock_Visible = 0;
            AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            lblPreviouspagetextblock_Visible = 0;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblPreviouspagetextblock_Visible = 1;
            AssignProp("", false, lblPreviouspagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPreviouspagetextblock_Visible), 5, 0), true);
            if ( AV11CurrentPage == 2 )
            {
               lblFirstpagetextblock_Visible = 0;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               lblSpacinglefttextblock_Visible = 0;
               AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblFirstpagetextblock_Visible = 1;
               AssignProp("", false, lblFirstpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFirstpagetextblock_Visible), 5, 0), true);
               if ( AV11CurrentPage == 3 )
               {
                  lblSpacinglefttextblock_Visible = 0;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacinglefttextblock_Visible = 1;
                  AssignProp("", false, lblSpacinglefttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacinglefttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( AV11CurrentPage == AV12K2BMaxPages )
         {
            lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblNextpagebuttontextblock_Internalname, "Class", lblNextpagebuttontextblock_Class, true);
            lblLastpagetextblock_Visible = 0;
            AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
            lblSpacingrighttextblock_Visible = 0;
            AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            lblNextpagetextblock_Visible = 0;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
         }
         else
         {
            lblNextpagetextblock_Visible = 1;
            AssignProp("", false, lblNextpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNextpagetextblock_Visible), 5, 0), true);
            if ( AV11CurrentPage == AV12K2BMaxPages - 1 )
            {
               lblLastpagetextblock_Visible = 0;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               lblSpacingrighttextblock_Visible = 0;
               AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
            }
            else
            {
               lblLastpagetextblock_Visible = 1;
               AssignProp("", false, lblLastpagetextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLastpagetextblock_Visible), 5, 0), true);
               if ( AV11CurrentPage == AV12K2BMaxPages - 2 )
               {
                  lblSpacingrighttextblock_Visible = 0;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
               else
               {
                  lblSpacingrighttextblock_Visible = 1;
                  AssignProp("", false, lblSpacingrighttextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSpacingrighttextblock_Visible), 5, 0), true);
               }
            }
         }
         if ( ( AV11CurrentPage <= 1 ) && ( AV12K2BMaxPages <= 1 ) )
         {
            divK2btoolspagingcontainertable_Visible = 0;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
         else
         {
            divK2btoolspagingcontainertable_Visible = 1;
            AssignProp("", false, divK2btoolspagingcontainertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolspagingcontainertable_Visible), 5, 0), true);
         }
      }

      protected void E192S2( )
      {
         /* 'DoFirst' Routine */
         returnInSub = false;
         AV11CurrentPage = 1;
         AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
         subgrid_firstpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void E202S2( )
      {
         /* 'DoPrevious' Routine */
         returnInSub = false;
         if ( AV11CurrentPage > 1 )
         {
            AV11CurrentPage = (int)(AV11CurrentPage-1);
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
            subgrid_previouspage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void E212S2( )
      {
         /* 'DoNext' Routine */
         returnInSub = false;
         AV12K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( AV11CurrentPage != AV12K2BMaxPages )
         {
            AV11CurrentPage = (int)(AV11CurrentPage+1);
            AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
            subgrid_nextpage( ) ;
            /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void E222S2( )
      {
         /* 'DoLast' Routine */
         returnInSub = false;
         AV12K2BMaxPages = subGrid_fnc_Pagecount( );
         AV11CurrentPage = (int)(AV12K2BMaxPages);
         AssignAttri("", false, "AV11CurrentPage", StringUtil.LTrimStr( (decimal)(AV11CurrentPage), 5, 0));
         subgrid_lastpage( ) ;
         /* Execute user subroutine: 'DISPLAYPAGINGBUTTONS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ClassCollection", AV30ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridConfiguration", AV13GridConfiguration);
      }

      protected void S162( )
      {
         /* 'APPLYGRIDCONFIGURATION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new k2bloadgridconfiguration(context ).execute(  AV54Pgmname,  "Grid", ref  AV13GridConfiguration) ;
         /* Execute user subroutine: 'APPLYFREEZECOLUMNTITLES' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S232( )
      {
         /* 'APPLYFREEZECOLUMNTITLES' Routine */
         returnInSub = false;
         AV14FreezeColumnTitles = AV13GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV14FreezeColumnTitles", AV14FreezeColumnTitles);
         if ( AV14FreezeColumnTitles )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV30ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV30ClassCollection) ;
         }
      }

      protected void E232S2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "soporte",  "soporte",  "List",  "",  "ExportWWsoporte") )
         {
            new exportwwsoporte(context ).execute(  AV31hostName_Filter,  AV36K2BToolsGenericSearchField,  AV37OrderedBy, out  AV41OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV41OutFile, out  AV43Uri) )
            {
               CallWebObject(formatLink(AV43Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV42Guid = Guid.NewGuid( );
               new k2bsessionset(context ).execute(  AV42Guid.ToString(),  AV41OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV42Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table1_174_2S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblNoresultsfoundtable_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblNoresultsfoundtable_Internalname, tblNoresultsfoundtable_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWsoporte.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_174_2S2e( true) ;
         }
         else
         {
            wb_table1_174_2S2e( false) ;
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431311364785", true, true);
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
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("wwsoporte.js", "?202431311364786", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BGridExtensions/K2BGridExtensionsRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1612( )
      {
         edtsoporteID_Internalname = "SOPORTEID_"+sGXsfl_161_idx;
         edthostName_Internalname = "HOSTNAME_"+sGXsfl_161_idx;
         edtserie_Internalname = "SERIE_"+sGXsfl_161_idx;
         edtipv4_Internalname = "IPV4_"+sGXsfl_161_idx;
         edtmac_Internalname = "MAC_"+sGXsfl_161_idx;
         edtmodelo_Internalname = "MODELO_"+sGXsfl_161_idx;
         edtnombreUsuario_Internalname = "NOMBREUSUARIO_"+sGXsfl_161_idx;
         edtnombreDepartamento_Internalname = "NOMBREDEPARTAMENTO_"+sGXsfl_161_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_161_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_161_idx;
      }

      protected void SubsflControlProps_fel_1612( )
      {
         edtsoporteID_Internalname = "SOPORTEID_"+sGXsfl_161_fel_idx;
         edthostName_Internalname = "HOSTNAME_"+sGXsfl_161_fel_idx;
         edtserie_Internalname = "SERIE_"+sGXsfl_161_fel_idx;
         edtipv4_Internalname = "IPV4_"+sGXsfl_161_fel_idx;
         edtmac_Internalname = "MAC_"+sGXsfl_161_fel_idx;
         edtmodelo_Internalname = "MODELO_"+sGXsfl_161_fel_idx;
         edtnombreUsuario_Internalname = "NOMBREUSUARIO_"+sGXsfl_161_fel_idx;
         edtnombreDepartamento_Internalname = "NOMBREDEPARTAMENTO_"+sGXsfl_161_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_161_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_161_fel_idx;
      }

      protected void sendrow_1612( )
      {
         SubsflControlProps_1612( ) ;
         WB2S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_161_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_161_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_161_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtsoporteID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtsoporteID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4soporteID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtsoporteID_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtsoporteID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)73,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edthostName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edthostName_Internalname,(string)A5hostName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edthostName_Link,(string)"",(string)"",(string)"",(string)edthostName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edthostName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtserie_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtserie_Internalname,(string)A9serie,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtserie_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtserie_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtipv4_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtipv4_Internalname,(string)A10ipv4,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtipv4_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtipv4_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtmac_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtmac_Internalname,(string)A11mac,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtmac_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtmac_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtmodelo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtmodelo_Internalname,(string)A12modelo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtmodelo_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtmodelo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtnombreUsuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombreUsuario_Internalname,(string)A13nombreUsuario,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombreUsuario_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombreUsuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtnombreDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtnombreDepartamento_Internalname,(string)A14nombreDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtnombreDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtnombreDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_gximage+"_Class");
            StyleString = "";
            AV47Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV47Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV56Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47Update)) ? AV56Update_GXI : context.PathToRelativeUrl( AV47Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(short)1,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV47Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_gximage+"_Class");
            StyleString = "";
            AV48Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV57Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV48Delete)) ? AV57Delete_GXI : context.PathToRelativeUrl( AV48Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(short)1,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV48Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2S2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_161_idx = ((subGrid_Islastpage==1)&&(nGXsfl_161_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_1612( ) ;
         }
         /* End function sendrow_1612 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_soporteid_visible.Name = "vATT_SOPORTEID_VISIBLE";
         chkavAtt_soporteid_visible.WebTags = "";
         chkavAtt_soporteid_visible.Caption = "";
         AssignProp("", false, chkavAtt_soporteid_visible_Internalname, "TitleCaption", chkavAtt_soporteid_visible.Caption, true);
         chkavAtt_soporteid_visible.CheckedValue = "false";
         AV17Att_soporteID_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV17Att_soporteID_Visible));
         AssignAttri("", false, "AV17Att_soporteID_Visible", AV17Att_soporteID_Visible);
         chkavAtt_hostname_visible.Name = "vATT_HOSTNAME_VISIBLE";
         chkavAtt_hostname_visible.WebTags = "";
         chkavAtt_hostname_visible.Caption = "";
         AssignProp("", false, chkavAtt_hostname_visible_Internalname, "TitleCaption", chkavAtt_hostname_visible.Caption, true);
         chkavAtt_hostname_visible.CheckedValue = "false";
         AV18Att_hostName_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Att_hostName_Visible));
         AssignAttri("", false, "AV18Att_hostName_Visible", AV18Att_hostName_Visible);
         chkavAtt_serie_visible.Name = "vATT_SERIE_VISIBLE";
         chkavAtt_serie_visible.WebTags = "";
         chkavAtt_serie_visible.Caption = "";
         AssignProp("", false, chkavAtt_serie_visible_Internalname, "TitleCaption", chkavAtt_serie_visible.Caption, true);
         chkavAtt_serie_visible.CheckedValue = "false";
         AV19Att_serie_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Att_serie_Visible));
         AssignAttri("", false, "AV19Att_serie_Visible", AV19Att_serie_Visible);
         chkavAtt_ipv4_visible.Name = "vATT_IPV4_VISIBLE";
         chkavAtt_ipv4_visible.WebTags = "";
         chkavAtt_ipv4_visible.Caption = "";
         AssignProp("", false, chkavAtt_ipv4_visible_Internalname, "TitleCaption", chkavAtt_ipv4_visible.Caption, true);
         chkavAtt_ipv4_visible.CheckedValue = "false";
         AV20Att_ipv4_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV20Att_ipv4_Visible));
         AssignAttri("", false, "AV20Att_ipv4_Visible", AV20Att_ipv4_Visible);
         chkavAtt_mac_visible.Name = "vATT_MAC_VISIBLE";
         chkavAtt_mac_visible.WebTags = "";
         chkavAtt_mac_visible.Caption = "";
         AssignProp("", false, chkavAtt_mac_visible_Internalname, "TitleCaption", chkavAtt_mac_visible.Caption, true);
         chkavAtt_mac_visible.CheckedValue = "false";
         AV21Att_mac_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Att_mac_Visible));
         AssignAttri("", false, "AV21Att_mac_Visible", AV21Att_mac_Visible);
         chkavAtt_modelo_visible.Name = "vATT_MODELO_VISIBLE";
         chkavAtt_modelo_visible.WebTags = "";
         chkavAtt_modelo_visible.Caption = "";
         AssignProp("", false, chkavAtt_modelo_visible_Internalname, "TitleCaption", chkavAtt_modelo_visible.Caption, true);
         chkavAtt_modelo_visible.CheckedValue = "false";
         AV22Att_modelo_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Att_modelo_Visible));
         AssignAttri("", false, "AV22Att_modelo_Visible", AV22Att_modelo_Visible);
         chkavAtt_nombreusuario_visible.Name = "vATT_NOMBREUSUARIO_VISIBLE";
         chkavAtt_nombreusuario_visible.WebTags = "";
         chkavAtt_nombreusuario_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombreusuario_visible_Internalname, "TitleCaption", chkavAtt_nombreusuario_visible.Caption, true);
         chkavAtt_nombreusuario_visible.CheckedValue = "false";
         AV23Att_nombreUsuario_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV23Att_nombreUsuario_Visible));
         AssignAttri("", false, "AV23Att_nombreUsuario_Visible", AV23Att_nombreUsuario_Visible);
         chkavAtt_nombredepartamento_visible.Name = "vATT_NOMBREDEPARTAMENTO_VISIBLE";
         chkavAtt_nombredepartamento_visible.WebTags = "";
         chkavAtt_nombredepartamento_visible.Caption = "";
         AssignProp("", false, chkavAtt_nombredepartamento_visible_Internalname, "TitleCaption", chkavAtt_nombredepartamento_visible.Caption, true);
         chkavAtt_nombredepartamento_visible.CheckedValue = "false";
         AV53Att_nombreDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Att_nombreDepartamento_Visible));
         AssignAttri("", false, "AV53Att_nombreDepartamento_Visible", AV53Att_nombreDepartamento_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV24GridSettingsRowsPerPageVariable = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPageVariable), 4, 0));
         }
         chkavFreezecolumntitles.Name = "vFREEZECOLUMNTITLES";
         chkavFreezecolumntitles.WebTags = "";
         chkavFreezecolumntitles.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_Internalname, "TitleCaption", chkavFreezecolumntitles.Caption, true);
         chkavFreezecolumntitles.CheckedValue = "false";
         AV14FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV14FreezeColumnTitles));
         AssignAttri("", false, "AV14FreezeColumnTitles", AV14FreezeColumnTitles);
         /* End function init_web_controls */
      }

      protected void StartGridControl161( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"161\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(73), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtsoporteID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edthostName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "HostName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtserie_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Serie", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtipv4_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "IPV4", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtmac_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "MAC", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtmodelo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modelo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombreUsuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NombreUsuario", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtnombreDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavUpdate_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_gximage+"_Class")+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDelete_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_gximage+"_Class")+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4soporteID), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtsoporteID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5hostName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edthostName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edthostName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A9serie));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtserie_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10ipv4));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtipv4_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11mac));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtmac_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A12modelo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtmodelo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A13nombreUsuario));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombreUsuario_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A14nombreDepartamento));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtnombreDepartamento_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV47Update));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV48Delete));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
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
         lblPgmdescriptortextblock_Internalname = "PGMDESCRIPTORTEXTBLOCK";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavK2btoolsgenericsearchfield_Internalname = "vK2BTOOLSGENERICSEARCHFIELD";
         imgFiltertoggle_combined_Internalname = "FILTERTOGGLE_COMBINED";
         divTable3_Internalname = "TABLE3";
         Filtersummarytagsuc_Internalname = "FILTERSUMMARYTAGSUC";
         divTable5_Internalname = "TABLE5";
         edtavHostname_filter_Internalname = "vHOSTNAME_FILTER";
         divK2btoolstable_attributecontainerhostname_filter_Internalname = "K2BTOOLSTABLE_ATTRIBUTECONTAINERHOSTNAME_FILTER";
         divFilterattributestable_Internalname = "FILTERATTRIBUTESTABLE";
         divK2btoolsfilterscontainer_Internalname = "K2BTOOLSFILTERSCONTAINER";
         divFiltercollapsiblesection_combined_Internalname = "FILTERCOLLAPSIBLESECTION_COMBINED";
         divCombinedfilterlayout_Internalname = "COMBINEDFILTERLAYOUT";
         divFilterglobalcontainer_Internalname = "FILTERGLOBALCONTAINER";
         divFiltercontainersection_Internalname = "FILTERCONTAINERSECTION";
         imgK2bgridsettingslabel_Internalname = "K2BGRIDSETTINGSLABEL";
         lblRuntimecolumnselectiontb_Internalname = "RUNTIMECOLUMNSELECTIONTB";
         chkavAtt_soporteid_visible_Internalname = "vATT_SOPORTEID_VISIBLE";
         divSoporteid_gridsettingscontainer_Internalname = "SOPORTEID_GRIDSETTINGSCONTAINER";
         chkavAtt_hostname_visible_Internalname = "vATT_HOSTNAME_VISIBLE";
         divHostname_gridsettingscontainer_Internalname = "HOSTNAME_GRIDSETTINGSCONTAINER";
         chkavAtt_serie_visible_Internalname = "vATT_SERIE_VISIBLE";
         divSerie_gridsettingscontainer_Internalname = "SERIE_GRIDSETTINGSCONTAINER";
         chkavAtt_ipv4_visible_Internalname = "vATT_IPV4_VISIBLE";
         divIpv4_gridsettingscontainer_Internalname = "IPV4_GRIDSETTINGSCONTAINER";
         chkavAtt_mac_visible_Internalname = "vATT_MAC_VISIBLE";
         divMac_gridsettingscontainer_Internalname = "MAC_GRIDSETTINGSCONTAINER";
         chkavAtt_modelo_visible_Internalname = "vATT_MODELO_VISIBLE";
         divModelo_gridsettingscontainer_Internalname = "MODELO_GRIDSETTINGSCONTAINER";
         chkavAtt_nombreusuario_visible_Internalname = "vATT_NOMBREUSUARIO_VISIBLE";
         divNombreusuario_gridsettingscontainer_Internalname = "NOMBREUSUARIO_GRIDSETTINGSCONTAINER";
         chkavAtt_nombredepartamento_visible_Internalname = "vATT_NOMBREDEPARTAMENTO_VISIBLE";
         divNombredepartamento_gridsettingscontainer_Internalname = "NOMBREDEPARTAMENTO_GRIDSETTINGSCONTAINER";
         divGridsettingstable_content_Internalname = "GRIDSETTINGSTABLE_CONTENT";
         cmbavGridsettingsrowsperpagevariable_Internalname = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         divRowsperpagecontainer_Internalname = "ROWSPERPAGECONTAINER";
         chkavFreezecolumntitles_Internalname = "vFREEZECOLUMNTITLES";
         divFreezegridcolumntitlescontainer_Internalname = "FREEZEGRIDCOLUMNTITLESCONTAINER";
         bttK2bgridsettingssave_Internalname = "K2BGRIDSETTINGSSAVE";
         divCustomizationcollapsiblesection_Internalname = "CUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_Internalname = "GRIDCUSTOMIZATIONCONTAINER";
         divContentinnertable_Internalname = "CONTENTINNERTABLE";
         divK2bgridsettingscontentoutertable_Internalname = "K2BGRIDSETTINGSCONTENTOUTERTABLE";
         divK2bgridsettingstable_Internalname = "K2BGRIDSETTINGSTABLE";
         imgImage1_Internalname = "IMAGE1";
         bttReport_Internalname = "REPORT";
         bttExport_Internalname = "EXPORT";
         divK2btabledownloadssectioncontainer_Internalname = "K2BTABLEDOWNLOADSSECTIONCONTAINER";
         divDownloadactionstable_Internalname = "DOWNLOADACTIONSTABLE";
         divDownloadsactionssectioncontainer_Internalname = "DOWNLOADSACTIONSSECTIONCONTAINER";
         bttInsert_Internalname = "INSERT";
         divK2btableactionsrightcontainer_Internalname = "K2BTABLEACTIONSRIGHTCONTAINER";
         divTable6_Internalname = "TABLE6";
         divTable10_Internalname = "TABLE10";
         edtsoporteID_Internalname = "SOPORTEID";
         edthostName_Internalname = "HOSTNAME";
         edtserie_Internalname = "SERIE";
         edtipv4_Internalname = "IPV4";
         edtmac_Internalname = "MAC";
         edtmodelo_Internalname = "MODELO";
         edtnombreUsuario_Internalname = "NOMBREUSUARIO";
         edtnombreDepartamento_Internalname = "NOMBREDEPARTAMENTO";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         lblNoresultsfoundtextblock_Internalname = "NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = "NORESULTSFOUNDTABLE";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPreviouspagebuttontextblock_Internalname = "PREVIOUSPAGEBUTTONTEXTBLOCK";
         lblFirstpagetextblock_Internalname = "FIRSTPAGETEXTBLOCK";
         lblSpacinglefttextblock_Internalname = "SPACINGLEFTTEXTBLOCK";
         lblPreviouspagetextblock_Internalname = "PREVIOUSPAGETEXTBLOCK";
         lblCurrentpagetextblock_Internalname = "CURRENTPAGETEXTBLOCK";
         lblNextpagetextblock_Internalname = "NEXTPAGETEXTBLOCK";
         lblSpacingrighttextblock_Internalname = "SPACINGRIGHTTEXTBLOCK";
         lblLastpagetextblock_Internalname = "LASTPAGETEXTBLOCK";
         lblNextpagebuttontextblock_Internalname = "NEXTPAGEBUTTONTEXTBLOCK";
         divK2btoolspagingcontainertable_Internalname = "K2BTOOLSPAGINGCONTAINERTABLE";
         divSection8_Internalname = "SECTION8";
         divTable4_Internalname = "TABLE4";
         divGlobalgridtable_Internalname = "GLOBALGRIDTABLE";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         Extendedgriduc_Internalname = "EXTENDEDGRIDUC";
         divK2btoolsabstracthiddenitemsgrid_Internalname = "K2BTOOLSABSTRACTHIDDENITEMSGRID";
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
         chkavFreezecolumntitles.Caption = context.GetMessage( "K2BT_FreezeColumnTitles", "");
         chkavAtt_nombredepartamento_visible.Caption = context.GetMessage( "Departamento", "");
         chkavAtt_nombreusuario_visible.Caption = context.GetMessage( "NombreUsuario", "");
         chkavAtt_modelo_visible.Caption = context.GetMessage( "Modelo", "");
         chkavAtt_mac_visible.Caption = context.GetMessage( "MAC", "");
         chkavAtt_ipv4_visible.Caption = context.GetMessage( "IPV4", "");
         chkavAtt_serie_visible.Caption = context.GetMessage( "Serie", "");
         chkavAtt_hostname_visible.Caption = context.GetMessage( "HostName", "");
         chkavAtt_soporteid_visible.Caption = context.GetMessage( "ID", "");
         edtavDelete_Link = "";
         edtavUpdate_Link = "";
         edtnombreDepartamento_Jsonclick = "";
         edtnombreUsuario_Jsonclick = "";
         edtmodelo_Jsonclick = "";
         edtmac_Jsonclick = "";
         edtipv4_Jsonclick = "";
         edtserie_Jsonclick = "";
         edthostName_Jsonclick = "";
         edthostName_Link = "";
         edtsoporteID_Jsonclick = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblNoresultsfoundtable_Visible = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtnombreDepartamento_Visible = -1;
         edtnombreUsuario_Visible = -1;
         edtmodelo_Visible = -1;
         edtmac_Visible = -1;
         edtipv4_Visible = -1;
         edtserie_Visible = -1;
         edthostName_Visible = -1;
         edtsoporteID_Visible = -1;
         edtavDelete_Tooltiptext = "";
         edtavDelete_gximage = "";
         edtavUpdate_Tooltiptext = "";
         edtavUpdate_gximage = "";
         subGrid_Sortable = 0;
         lblNextpagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         lblLastpagetextblock_Caption = "1";
         lblLastpagetextblock_Visible = 1;
         lblSpacingrighttextblock_Visible = 1;
         lblNextpagetextblock_Caption = "#";
         lblNextpagetextblock_Visible = 1;
         lblCurrentpagetextblock_Caption = "#";
         lblPreviouspagetextblock_Caption = "#";
         lblPreviouspagetextblock_Visible = 1;
         lblSpacinglefttextblock_Visible = 1;
         lblFirstpagetextblock_Caption = "1";
         lblFirstpagetextblock_Visible = 1;
         lblPreviouspagebuttontextblock_Class = "K2BToolsTextBlock_PaginationNormal";
         divK2btoolspagingcontainertable_Visible = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         bttInsert_Tooltiptext = context.GetMessage( "GXM_insert", "");
         bttInsert_Visible = 1;
         bttExport_Tooltiptext = "";
         bttExport_Visible = 1;
         bttReport_Tooltiptext = "";
         bttReport_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_nombredepartamento_visible.Enabled = 1;
         chkavAtt_nombreusuario_visible.Enabled = 1;
         chkavAtt_modelo_visible.Enabled = 1;
         chkavAtt_mac_visible.Enabled = 1;
         chkavAtt_ipv4_visible.Enabled = 1;
         chkavAtt_serie_visible.Enabled = 1;
         chkavAtt_hostname_visible.Enabled = 1;
         chkavAtt_soporteid_visible.Enabled = 1;
         divK2bgridsettingscontentoutertable_Visible = 1;
         edtavHostname_filter_Jsonclick = "";
         edtavHostname_filter_Enabled = 1;
         divFiltercollapsiblesection_combined_Visible = 1;
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         edtavHostname_filter_Caption = context.GetMessage( "Name", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "SOPORTE", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E162S2',iparms:[{av:'A4soporteID',fld:'SOPORTEID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("'DOREPORT'","{handler:'E172S2',iparms:[{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'}]");
         setEventMetadata("'DOREPORT'",",oparms:[]}");
         setEventMetadata("GRID.REFRESH","{handler:'E262S2',iparms:[{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'edtavHostname_filter_Caption',ctrl:'vHOSTNAME_FILTER',prop:'Caption'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV40UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV8GridMetadata',fld:'vGRIDMETADATA',pic:''},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'Filtersummarytagsuc_Emptystatemessage',ctrl:'FILTERSUMMARYTAGSUC',prop:'EmptyStateMessage'},{av:'AV34FilterTags',fld:'vFILTERTAGS',pic:''},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E272S2',iparms:[{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'A4soporteID',fld:'SOPORTEID',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edthostName_Link',ctrl:'HOSTNAME',prop:'Link'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'}]}");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED","{handler:'E142S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV35DeletedTag',fld:'vDELETEDTAG',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("FILTERSUMMARYTAGSUC.TAGDELETED",",oparms:[{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("EXTENDEDGRIDUC.ORDERBYCHANGED","{handler:'E152S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV40UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("EXTENDEDGRIDUC.ORDERBYCHANGED",",oparms:[{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E122S1',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E182S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV24GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV25RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E192S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E202S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E212S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E222S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV11CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV47Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV48Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV30ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV13GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV46hostName_IsAuthorized',fld:'vHOSTNAME_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV14FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''},{av:'edtsoporteID_Visible',ctrl:'SOPORTEID',prop:'Visible'},{av:'AV17Att_soporteID_Visible',fld:'vATT_SOPORTEID_VISIBLE',pic:''},{av:'edthostName_Visible',ctrl:'HOSTNAME',prop:'Visible'},{av:'AV18Att_hostName_Visible',fld:'vATT_HOSTNAME_VISIBLE',pic:''},{av:'edtserie_Visible',ctrl:'SERIE',prop:'Visible'},{av:'AV19Att_serie_Visible',fld:'vATT_SERIE_VISIBLE',pic:''},{av:'edtipv4_Visible',ctrl:'IPV4',prop:'Visible'},{av:'AV20Att_ipv4_Visible',fld:'vATT_IPV4_VISIBLE',pic:''},{av:'edtmac_Visible',ctrl:'MAC',prop:'Visible'},{av:'AV21Att_mac_Visible',fld:'vATT_MAC_VISIBLE',pic:''},{av:'edtmodelo_Visible',ctrl:'MODELO',prop:'Visible'},{av:'AV22Att_modelo_Visible',fld:'vATT_MODELO_VISIBLE',pic:''},{av:'edtnombreUsuario_Visible',ctrl:'NOMBREUSUARIO',prop:'Visible'},{av:'AV23Att_nombreUsuario_Visible',fld:'vATT_NOMBREUSUARIO_VISIBLE',pic:''},{av:'edtnombreDepartamento_Visible',ctrl:'NOMBREDEPARTAMENTO',prop:'Visible'},{av:'AV53Att_nombreDepartamento_Visible',fld:'vATT_NOMBREDEPARTAMENTO_VISIBLE',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E232S2',iparms:[{av:'AV31hostName_Filter',fld:'vHOSTNAME_FILTER',pic:''},{av:'AV36K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV37OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true}]");
         setEventMetadata("'DOEXPORT'",",oparms:[]}");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK","{handler:'E112S1',iparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'}]");
         setEventMetadata("FILTERTOGGLE_COMBINED.CLICK",",oparms:[{av:'divFiltercollapsiblesection_combined_Visible',ctrl:'FILTERCOLLAPSIBLESECTION_COMBINED',prop:'Visible'}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E132S1',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
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
         AV36K2BToolsGenericSearchField = "";
         AV31hostName_Filter = "";
         AV54Pgmname = "";
         AV13GridConfiguration = new SdtK2BGridConfiguration(context);
         AV30ClassCollection = new GxSimpleCollection<string>();
         AV43Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV34FilterTags = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV35DeletedTag = "";
         AV8GridMetadata = new SdtK2BT_ExtendedGridMetadata(context);
         Filtersummarytagsuc_Emptystatemessage = "";
         Extendedgriduc_Gridcontrolname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblPgmdescriptortextblock_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         imgFiltertoggle_combined_gximage = "";
         sImgUrl = "";
         imgFiltertoggle_combined_Jsonclick = "";
         ucFiltersummarytagsuc = new GXUserControl();
         imgK2bgridsettingslabel_gximage = "";
         imgK2bgridsettingslabel_Jsonclick = "";
         lblRuntimecolumnselectiontb_Jsonclick = "";
         bttK2bgridsettingssave_Jsonclick = "";
         imgImage1_gximage = "";
         imgImage1_Jsonclick = "";
         bttReport_Jsonclick = "";
         bttExport_Jsonclick = "";
         bttInsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblPreviouspagebuttontextblock_Jsonclick = "";
         lblFirstpagetextblock_Jsonclick = "";
         lblSpacinglefttextblock_Jsonclick = "";
         lblPreviouspagetextblock_Jsonclick = "";
         lblCurrentpagetextblock_Jsonclick = "";
         lblNextpagetextblock_Jsonclick = "";
         lblSpacingrighttextblock_Jsonclick = "";
         lblLastpagetextblock_Jsonclick = "";
         lblNextpagebuttontextblock_Jsonclick = "";
         ucExtendedgriduc = new GXUserControl();
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A5hostName = "";
         A9serie = "";
         A10ipv4 = "";
         A11mac = "";
         A12modelo = "";
         A13nombreUsuario = "";
         A14nombreDepartamento = "";
         AV47Update = "";
         AV56Update_GXI = "";
         AV48Delete = "";
         AV57Delete_GXI = "";
         scmdbuf = "";
         lV31hostName_Filter = "";
         lV36K2BToolsGenericSearchField = "";
         H002S2_A14nombreDepartamento = new string[] {""} ;
         H002S2_A13nombreUsuario = new string[] {""} ;
         H002S2_A12modelo = new string[] {""} ;
         H002S2_A11mac = new string[] {""} ;
         H002S2_A10ipv4 = new string[] {""} ;
         H002S2_A9serie = new string[] {""} ;
         H002S2_A5hostName = new string[] {""} ;
         H002S2_A4soporteID = new int[1] ;
         H002S3_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV44Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV45Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV51ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV52ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HttpRequest = new GxHttpRequest( context);
         GXt_char2 = "";
         AV27GridStateKey = "";
         AV28GridState = new SdtK2BGridState(context);
         AV29GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV49TrnContext = new SdtK2BTrnContext(context);
         AV6Window = new GXWindow();
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "test");
         AV9GridMetadataColumn = new SdtK2BT_ExtendedGridMetadata_Column(context);
         AV10GridMetadataColumnGroup = new SdtK2BT_ExtendedGridMetadata_ColumnGroup(context);
         GridRow = new GXWebRow();
         AV32K2BFilterValuesSDT = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV33K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV41OutFile = "";
         AV42Guid = Guid.Empty;
         lblNoresultsfoundtextblock_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwsoporte__default(),
            new Object[][] {
                new Object[] {
               H002S2_A14nombreDepartamento, H002S2_A13nombreUsuario, H002S2_A12modelo, H002S2_A11mac, H002S2_A10ipv4, H002S2_A9serie, H002S2_A5hostName, H002S2_A4soporteID
               }
               , new Object[] {
               H002S3_AGRID_nRecordCount
               }
            }
         );
         AV54Pgmname = "WWsoporte";
         /* GeneXus formulas. */
         AV54Pgmname = "WWsoporte";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV37OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV40UC_OrderedBy ;
      private short AV25RowsPerPageVariable ;
      private short wbEnd ;
      private short wbStart ;
      private short AV24GridSettingsRowsPerPageVariable ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int bttReport_Visible ;
      private int bttExport_Visible ;
      private int divK2bgridsettingscontentoutertable_Visible ;
      private int divFiltercollapsiblesection_combined_Visible ;
      private int divDownloadactionstable_Visible ;
      private int nRC_GXsfl_161 ;
      private int subGrid_Rows ;
      private int nGXsfl_161_idx=1 ;
      private int AV11CurrentPage ;
      private int edtavK2btoolsgenericsearchfield_Enabled ;
      private int edtavHostname_filter_Enabled ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int bttInsert_Visible ;
      private int divK2btoolspagingcontainertable_Visible ;
      private int lblFirstpagetextblock_Visible ;
      private int lblSpacinglefttextblock_Visible ;
      private int lblPreviouspagetextblock_Visible ;
      private int lblNextpagetextblock_Visible ;
      private int lblSpacingrighttextblock_Visible ;
      private int lblLastpagetextblock_Visible ;
      private int A4soporteID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV55GXV1 ;
      private int AV58GXV2 ;
      private int edtsoporteID_Visible ;
      private int edthostName_Visible ;
      private int edtserie_Visible ;
      private int edtipv4_Visible ;
      private int edtmac_Visible ;
      private int edtmodelo_Visible ;
      private int edtnombreUsuario_Visible ;
      private int edtnombreDepartamento_Visible ;
      private int AV59GXV3 ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV60GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV12K2BMaxPages ;
      private string edtavHostname_filter_Caption ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_161_idx="0001" ;
      private string AV36K2BToolsGenericSearchField ;
      private string AV54Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV35DeletedTag ;
      private string Filtersummarytagsuc_Emptystatemessage ;
      private string Extendedgriduc_Gridcontrolname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblPgmdescriptortextblock_Internalname ;
      private string lblPgmdescriptortextblock_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable7_Internalname ;
      private string divTable10_Internalname ;
      private string divFiltercontainersection_Internalname ;
      private string divFilterglobalcontainer_Internalname ;
      private string divCombinedfilterlayout_Internalname ;
      private string divTable5_Internalname ;
      private string divTable3_Internalname ;
      private string TempTags ;
      private string edtavK2btoolsgenericsearchfield_Internalname ;
      private string edtavK2btoolsgenericsearchfield_Jsonclick ;
      private string imgFiltertoggle_combined_gximage ;
      private string sImgUrl ;
      private string imgFiltertoggle_combined_Internalname ;
      private string imgFiltertoggle_combined_Jsonclick ;
      private string Filtersummarytagsuc_Internalname ;
      private string divFiltercollapsiblesection_combined_Internalname ;
      private string divK2btoolsfilterscontainer_Internalname ;
      private string divFilterattributestable_Internalname ;
      private string divK2btoolstable_attributecontainerhostname_filter_Internalname ;
      private string edtavHostname_filter_Internalname ;
      private string edtavHostname_filter_Jsonclick ;
      private string divTable6_Internalname ;
      private string divK2bgridsettingstable_Internalname ;
      private string imgK2bgridsettingslabel_gximage ;
      private string imgK2bgridsettingslabel_Internalname ;
      private string imgK2bgridsettingslabel_Jsonclick ;
      private string divK2bgridsettingscontentoutertable_Internalname ;
      private string divContentinnertable_Internalname ;
      private string divGridcustomizationcontainer_Internalname ;
      private string lblRuntimecolumnselectiontb_Internalname ;
      private string lblRuntimecolumnselectiontb_Jsonclick ;
      private string divCustomizationcollapsiblesection_Internalname ;
      private string divGridsettingstable_content_Internalname ;
      private string divSoporteid_gridsettingscontainer_Internalname ;
      private string chkavAtt_soporteid_visible_Internalname ;
      private string divHostname_gridsettingscontainer_Internalname ;
      private string chkavAtt_hostname_visible_Internalname ;
      private string divSerie_gridsettingscontainer_Internalname ;
      private string chkavAtt_serie_visible_Internalname ;
      private string divIpv4_gridsettingscontainer_Internalname ;
      private string chkavAtt_ipv4_visible_Internalname ;
      private string divMac_gridsettingscontainer_Internalname ;
      private string chkavAtt_mac_visible_Internalname ;
      private string divModelo_gridsettingscontainer_Internalname ;
      private string chkavAtt_modelo_visible_Internalname ;
      private string divNombreusuario_gridsettingscontainer_Internalname ;
      private string chkavAtt_nombreusuario_visible_Internalname ;
      private string divNombredepartamento_gridsettingscontainer_Internalname ;
      private string chkavAtt_nombredepartamento_visible_Internalname ;
      private string divRowsperpagecontainer_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Jsonclick ;
      private string divFreezegridcolumntitlescontainer_Internalname ;
      private string chkavFreezecolumntitles_Internalname ;
      private string bttK2bgridsettingssave_Internalname ;
      private string bttK2bgridsettingssave_Jsonclick ;
      private string divDownloadsactionssectioncontainer_Internalname ;
      private string imgImage1_gximage ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string divDownloadactionstable_Internalname ;
      private string divK2btabledownloadssectioncontainer_Internalname ;
      private string bttReport_Internalname ;
      private string bttReport_Jsonclick ;
      private string bttReport_Tooltiptext ;
      private string bttExport_Internalname ;
      private string bttExport_Jsonclick ;
      private string bttExport_Tooltiptext ;
      private string divK2btableactionsrightcontainer_Internalname ;
      private string bttInsert_Internalname ;
      private string bttInsert_Jsonclick ;
      private string bttInsert_Tooltiptext ;
      private string divGlobalgridtable_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divTable4_Internalname ;
      private string divSection8_Internalname ;
      private string divK2btoolspagingcontainertable_Internalname ;
      private string lblPreviouspagebuttontextblock_Internalname ;
      private string lblPreviouspagebuttontextblock_Jsonclick ;
      private string lblPreviouspagebuttontextblock_Class ;
      private string lblFirstpagetextblock_Internalname ;
      private string lblFirstpagetextblock_Caption ;
      private string lblFirstpagetextblock_Jsonclick ;
      private string lblSpacinglefttextblock_Internalname ;
      private string lblSpacinglefttextblock_Jsonclick ;
      private string lblPreviouspagetextblock_Internalname ;
      private string lblPreviouspagetextblock_Caption ;
      private string lblPreviouspagetextblock_Jsonclick ;
      private string lblCurrentpagetextblock_Internalname ;
      private string lblCurrentpagetextblock_Caption ;
      private string lblCurrentpagetextblock_Jsonclick ;
      private string lblNextpagetextblock_Internalname ;
      private string lblNextpagetextblock_Caption ;
      private string lblNextpagetextblock_Jsonclick ;
      private string lblSpacingrighttextblock_Internalname ;
      private string lblSpacingrighttextblock_Jsonclick ;
      private string lblLastpagetextblock_Internalname ;
      private string lblLastpagetextblock_Caption ;
      private string lblLastpagetextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Internalname ;
      private string lblNextpagebuttontextblock_Jsonclick ;
      private string lblNextpagebuttontextblock_Class ;
      private string divK2btoolsabstracthiddenitemsgrid_Internalname ;
      private string Extendedgriduc_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtsoporteID_Internalname ;
      private string edthostName_Internalname ;
      private string edtserie_Internalname ;
      private string edtipv4_Internalname ;
      private string edtmac_Internalname ;
      private string edtmodelo_Internalname ;
      private string edtnombreUsuario_Internalname ;
      private string edtnombreDepartamento_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string scmdbuf ;
      private string lV36K2BToolsGenericSearchField ;
      private string edtavUpdate_gximage ;
      private string edtavUpdate_Tooltiptext ;
      private string edtavDelete_gximage ;
      private string edtavDelete_Tooltiptext ;
      private string GXt_char2 ;
      private string tblNoresultsfoundtable_Internalname ;
      private string edthostName_Link ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string lblNoresultsfoundtextblock_Internalname ;
      private string lblNoresultsfoundtextblock_Jsonclick ;
      private string sGXsfl_161_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtsoporteID_Jsonclick ;
      private string edthostName_Jsonclick ;
      private string edtserie_Jsonclick ;
      private string edtipv4_Jsonclick ;
      private string edtmac_Jsonclick ;
      private string edtmodelo_Jsonclick ;
      private string edtnombreUsuario_Jsonclick ;
      private string edtnombreDepartamento_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV46hostName_IsAuthorized ;
      private bool AV17Att_soporteID_Visible ;
      private bool AV18Att_hostName_Visible ;
      private bool AV19Att_serie_Visible ;
      private bool AV20Att_ipv4_Visible ;
      private bool AV21Att_mac_Visible ;
      private bool AV22Att_modelo_Visible ;
      private bool AV23Att_nombreUsuario_Visible ;
      private bool AV53Att_nombreDepartamento_Visible ;
      private bool AV14FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_161_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV26RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV47Update_IsBlob ;
      private bool AV48Delete_IsBlob ;
      private string AV31hostName_Filter ;
      private string AV43Uri ;
      private string A5hostName ;
      private string A9serie ;
      private string A10ipv4 ;
      private string A11mac ;
      private string A12modelo ;
      private string A13nombreUsuario ;
      private string A14nombreDepartamento ;
      private string AV56Update_GXI ;
      private string AV57Delete_GXI ;
      private string lV31hostName_Filter ;
      private string AV27GridStateKey ;
      private string AV41OutFile ;
      private string AV47Update ;
      private string AV48Delete ;
      private Guid AV42Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltersummarytagsuc ;
      private GXUserControl ucExtendedgriduc ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_soporteid_visible ;
      private GXCheckbox chkavAtt_hostname_visible ;
      private GXCheckbox chkavAtt_serie_visible ;
      private GXCheckbox chkavAtt_ipv4_visible ;
      private GXCheckbox chkavAtt_mac_visible ;
      private GXCheckbox chkavAtt_modelo_visible ;
      private GXCheckbox chkavAtt_nombreusuario_visible ;
      private GXCheckbox chkavAtt_nombredepartamento_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H002S2_A14nombreDepartamento ;
      private string[] H002S2_A13nombreUsuario ;
      private string[] H002S2_A12modelo ;
      private string[] H002S2_A11mac ;
      private string[] H002S2_A10ipv4 ;
      private string[] H002S2_A9serie ;
      private string[] H002S2_A5hostName ;
      private int[] H002S2_A4soporteID ;
      private long[] H002S3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HttpRequest ;
      private GxSimpleCollection<string> AV30ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV15GridColumns ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV32K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV34FilterTags ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV44Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV51ActivityList ;
      private GXWebForm Form ;
      private GXWindow AV6Window ;
      private SdtK2BContext AV5Context ;
      private SdtK2BT_ExtendedGridMetadata AV8GridMetadata ;
      private SdtK2BT_ExtendedGridMetadata_Column AV9GridMetadataColumn ;
      private SdtK2BT_ExtendedGridMetadata_ColumnGroup AV10GridMetadataColumnGroup ;
      private SdtK2BGridConfiguration AV13GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV16GridColumn ;
      private SdtK2BGridState AV28GridState ;
      private SdtK2BGridState_FilterValue AV29GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV33K2BFilterValuesSDTItem ;
      private GeneXus.Utils.SdtMessages_Message AV45Message ;
      private SdtK2BTrnContext AV49TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV52ActivityListItem ;
   }

   public class wwsoporte__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002S2( IGxContext context ,
                                             string AV31hostName_Filter ,
                                             string AV36K2BToolsGenericSearchField ,
                                             string A5hostName ,
                                             int A4soporteID ,
                                             string A10ipv4 ,
                                             string A11mac ,
                                             string A12modelo ,
                                             string A13nombreUsuario ,
                                             string A14nombreDepartamento ,
                                             short AV37OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [nombreDepartamento], [nombreUsuario], [modelo], [mac], [ipv4], [serie], [hostName], [soporteID]";
         sFromString = " FROM [soporte]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31hostName_Filter)) )
         {
            AddWhere(sWhereString, "([hostName] like @lV31hostName_Filter)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([soporteID] AS decimal(9,0))) like '%' + @lV36K2BToolsGenericSearchField + '%' or [hostName] like '%' + @lV36K2BToolsGenericSearchField + '%' or [serie] like '%' + @lV36K2BToolsGenericSearchField + '%' or [ipv4] like '%' + @lV36K2BToolsGenericSearchField + '%' or [mac] like '%' + @lV36K2BToolsGenericSearchField + '%' or [modelo] like '%' + @lV36K2BToolsGenericSearchField + '%' or [nombreUsuario] like '%' + @lV36K2BToolsGenericSearchField + '%' or [nombreDepartamento] like '%' + @lV36K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
         }
         if ( AV37OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [soporteID]";
         }
         else if ( AV37OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [soporteID] DESC";
         }
         else if ( AV37OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [hostName]";
         }
         else if ( AV37OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [hostName] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [soporteID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H002S3( IGxContext context ,
                                             string AV31hostName_Filter ,
                                             string AV36K2BToolsGenericSearchField ,
                                             string A5hostName ,
                                             int A4soporteID ,
                                             string A10ipv4 ,
                                             string A11mac ,
                                             string A12modelo ,
                                             string A13nombreUsuario ,
                                             string A14nombreDepartamento ,
                                             short AV37OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [soporte]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31hostName_Filter)) )
         {
            AddWhere(sWhereString, "([hostName] like @lV31hostName_Filter)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([soporteID] AS decimal(9,0))) like '%' + @lV36K2BToolsGenericSearchField + '%' or [hostName] like '%' + @lV36K2BToolsGenericSearchField + '%' or [serie] like '%' + @lV36K2BToolsGenericSearchField + '%' or [ipv4] like '%' + @lV36K2BToolsGenericSearchField + '%' or [mac] like '%' + @lV36K2BToolsGenericSearchField + '%' or [modelo] like '%' + @lV36K2BToolsGenericSearchField + '%' or [nombreUsuario] like '%' + @lV36K2BToolsGenericSearchField + '%' or [nombreDepartamento] like '%' + @lV36K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV37OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV37OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV37OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV37OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
               case 1 :
                     return conditional_H002S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002S2;
          prmH002S2 = new Object[] {
          new ParDef("@lV31hostName_Filter",GXType.NVarChar,40,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002S3;
          prmH002S3 = new Object[] {
          new ParDef("@lV31hostName_Filter",GXType.NVarChar,40,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.Char,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV36K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S3,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
