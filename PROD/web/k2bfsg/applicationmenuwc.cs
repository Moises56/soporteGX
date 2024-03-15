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
   public class applicationmenuwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public applicationmenuwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
      }

      public applicationmenuwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ApplicationId )
      {
         this.AV8ApplicationId = aP0_ApplicationId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV8ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8ApplicationId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_100 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_100"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_100_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_100_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_100_idx = GetPar( "sGXsfl_100_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV46Name_Filter_PreviousValue = GetPar( "Name_Filter_PreviousValue");
         AV45Name_Filter = GetPar( "Name_Filter");
         AV52Pgmname = GetPar( "Pgmname");
         AV17CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV26HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47GridConfiguration);
         AV16CurrentApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CurrentApplicationId"), "."), 18, MidpointRounding.ToEven));
         AV8ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV50ClassCollection_Grid);
         AV36RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV30MenuId = (long)(Math.Round(NumberUtil.Val( GetPar( "MenuId"), "."), 18, MidpointRounding.ToEven));
         AV28I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV46Name_Filter_PreviousValue, AV45Name_Filter, AV52Pgmname, AV17CurrentPage_Grid, AV26HasNextPage_Grid, AV47GridConfiguration, AV16CurrentApplicationId, AV8ApplicationId, AV50ClassCollection_Grid, AV36RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV52Pgmname = "K2BFSG.ApplicationMenuWC";
               edtavMenuid_Enabled = 0;
               AssignProp(sPrefix, false, edtavMenuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuid_Enabled), 5, 0), !bGXsfl_100_Refreshing);
               edtavMenuname_Enabled = 0;
               AssignProp(sPrefix, false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), !bGXsfl_100_Refreshing);
               edtavMenudescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), !bGXsfl_100_Refreshing);
               edtavOptions_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_100_Refreshing);
               WS3P2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Application Menu WC") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.applicationmenuwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0))}, new string[] {"ApplicationId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME_FILTER_PREVIOUSVALUE", StringUtil.RTrim( AV46Name_Filter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME_FILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Name_Filter_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV16CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_100", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_100), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV48FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV48FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG_GRID", StringUtil.RTrim( AV49DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ApplicationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME_FILTER_PREVIOUSVALUE", StringUtil.RTrim( AV46Name_Filter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME_FILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Name_Filter_PreviousValue, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV47GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV47GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV16CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCONFIRMATIONREQUIRED", AV11ConfirmationRequired);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONFIRMATIONSUBID", StringUtil.RTrim( AV12ConfirmationSubId));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BT_CONFIRMDIALOG_Confirmmessage", StringUtil.RTrim( K2bt_confirmdialog_Confirmmessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BT_CONFIRMDIALOG_Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME_FILTER_Caption", StringUtil.RTrim( edtavName_filter_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME_FILTER_Caption", StringUtil.RTrim( edtavName_filter_Caption));
      }

      protected void RenderHtmlCloseForm3P2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.ApplicationMenuWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Application Menu WC" ;
      }

      protected void WB3P0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.applicationmenuwc.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ConfirmDialogRender.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113p1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\ApplicationMenuWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_k2bt_filtercaption_grid_Internalname, "Filters", "", "", lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_FilterToggleText", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV48FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV49DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, sPrefix+"FILTERTAGSUSERCONTROL_GRIDContainer");
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
            GxWebStd.gx_div_start( context, divTable_container_name_filter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavName_filter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_filter_Internalname, "Name", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_100_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_filter_Internalname, StringUtil.RTrim( AV45Name_Filter), StringUtil.RTrim( context.localUtil.Format( AV45Name_Filter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Try a search", edtavName_filter_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavName_filter_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Grid Settings", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e123p1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Grid Settings", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'" + sGXsfl_100_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'" + sGXsfl_100_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid), "", "Freeze column titles", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(100), 3, 0)+","+"null"+");", "Apply", bttGridsettings_savegrid_Jsonclick, 5, "Apply", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddnew_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(100), 3, 0)+","+"null"+");", "Add new", bttAddnew_Jsonclick, 5, "", "", StyleString, ClassString, bttAddnew_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADDNEW\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLoadapplicationmenus_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(100), 3, 0)+","+"null"+");", "Load application menus", bttLoadapplicationmenus_Jsonclick, 5, bttLoadapplicationmenus_Tooltiptext, "", StyleString, ClassString, bttLoadapplicationmenus_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_LOADAPPLICATIONMENUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            StartGridControl100( ) ;
         }
         if ( wbEnd == 100 )
         {
            wbEnd = 0;
            nRC_GXsfl_100 = (int)(nGXsfl_100_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_109_3P2( true) ;
         }
         else
         {
            wb_table1_109_3P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_109_3P2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133p1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e143p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e153p1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e153p1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
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
            ucK2bt_confirmdialog.Render(context, "k2bt_confirmdialog", K2bt_confirmdialog_Internalname, sPrefix+"K2BT_CONFIRMDIALOGContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 100 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3P2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_5-175581", 0) ;
               }
            }
            Form.Meta.addItem("description", "Application Menu WC", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3P0( ) ;
            }
         }
      }

      protected void WS3P2( )
      {
         START3P2( ) ;
         EVT3P2( ) ;
      }

      protected void EVT3P2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "K2BT_CONFIRMDIALOG.ONOKCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E163P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings(Grid)' */
                                    E173P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADDNEW'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_AddNew' */
                                    E183P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_LOADAPPLICATIONMENUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_LoadApplicationMenus' */
                                    E193P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavMenuid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              nGXsfl_100_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
                              SubsflControlProps_1002( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMENUID");
                                 GX_FocusControl = edtavMenuid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV30MenuId = 0;
                                 AssignAttri(sPrefix, false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
                              }
                              else
                              {
                                 AV30MenuId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavMenuid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
                              }
                              AV31MenuName = cgiGet( edtavMenuname_Internalname);
                              AssignAttri(sPrefix, false, edtavMenuname_Internalname, AV31MenuName);
                              AV29MenuDescription = cgiGet( edtavMenudescription_Internalname);
                              AssignAttri(sPrefix, false, edtavMenudescription_Internalname, AV29MenuDescription);
                              AV33Options_Action = cgiGet( edtavOptions_action_Internalname);
                              AssignAttri(sPrefix, false, edtavOptions_action_Internalname, AV33Options_Action);
                              AV43Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update_Action)) ? AV54Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV43Update_Action))), !bGXsfl_100_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV43Update_Action), true);
                              AV44Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete_Action)) ? AV55Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV44Delete_Action))), !bGXsfl_100_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV44Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E203P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E213P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E223P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E233P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_UPDATE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Update' */
                                          E243P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Delete' */
                                          E253P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3P0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMenuid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE3P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3P2( ) ;
            }
         }
      }

      protected void PA3P2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavName_filter_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1002( ) ;
         while ( nGXsfl_100_idx <= nRC_GXsfl_100 )
         {
            sendrow_1002( ) ;
            nGXsfl_100_idx = ((subGrid_Islastpage==1)&&(nGXsfl_100_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1002( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV46Name_Filter_PreviousValue ,
                                       string AV45Name_Filter ,
                                       string AV52Pgmname ,
                                       short AV17CurrentPage_Grid ,
                                       bool AV26HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV47GridConfiguration ,
                                       long AV16CurrentApplicationId ,
                                       long AV8ApplicationId ,
                                       GxSimpleCollection<string> AV50ClassCollection_Grid ,
                                       short AV36RowsPerPage_Grid ,
                                       long AV30MenuId ,
                                       short AV28I_LoadCount_Grid ,
                                       bool AV51FreezeColumnTitles_Grid ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3P2( ) ;
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
            AV22GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid));
         AssignAttri(sPrefix, false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E213P2 ();
         RF3P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "K2BFSG.ApplicationMenuWC";
         edtavMenuid_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuid_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavMenuname_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavMenudescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_100_Refreshing);
      }

      protected void RF3P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 100;
         /* Execute user event: Refresh */
         E213P2 ();
         E223P2 ();
         nGXsfl_100_idx = 1;
         sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
         SubsflControlProps_1002( ) ;
         bGXsfl_100_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1002( ) ;
            E233P2 ();
            wbEnd = 100;
            WB3P0( ) ;
         }
         bGXsfl_100_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3P2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME_FILTER_PREVIOUSVALUE", StringUtil.RTrim( AV46Name_Filter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME_FILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Name_Filter_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV16CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV26HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
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
         AV52Pgmname = "K2BFSG.ApplicationMenuWC";
         edtavMenuid_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuid_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavMenuname_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavMenudescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_100_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E203P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGSCOLLECTION_GRID"), AV48FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_100 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_100"), ".", ","), 18, MidpointRounding.ToEven));
            AV49DeletedTag_Grid = cgiGet( sPrefix+"vDELETEDTAG_GRID");
            wcpOAV8ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ApplicationId"), ".", ","), 18, MidpointRounding.ToEven));
            AV12ConfirmationSubId = cgiGet( sPrefix+"vCONFIRMATIONSUBID");
            AV17CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV8ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vAPPLICATIONID"), ".", ","), 18, MidpointRounding.ToEven));
            AV36RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vROWSPERPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV26HasNextPage_Grid = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            K2bt_confirmdialog_Confirmmessage = cgiGet( sPrefix+"K2BT_CONFIRMDIALOG_Confirmmessage");
            K2bt_confirmdialog_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BT_CONFIRMDIALOG_Visible"));
            edtavName_filter_Caption = cgiGet( sPrefix+"vNAME_FILTER_Caption");
            /* Read variables values. */
            AV45Name_Filter = cgiGet( edtavName_filter_Internalname);
            AssignAttri(sPrefix, false, "AV45Name_Filter", AV45Name_Filter);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV22GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
            AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri(sPrefix, false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
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
         E203P2 ();
         if (returnInSub) return;
      }

      protected void E203P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV52Pgmname,  "Grid", out  AV36RowsPerPage_Grid, out  AV40RowsPerPageLoaded_Grid) ;
         AssignAttri(sPrefix, false, "AV36RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36RowsPerPage_Grid), 4, 0));
         if ( ! AV40RowsPerPageLoaded_Grid )
         {
            AV36RowsPerPage_Grid = 20;
            AssignAttri(sPrefix, false, "AV36RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36RowsPerPage_Grid), 4, 0));
         }
         AV22GridSettingsRowsPerPage_Grid = AV36RowsPerPage_Grid;
         AssignAttri(sPrefix, false, "AV22GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV46Name_Filter_PreviousValue = AV45Name_Filter;
         AssignAttri(sPrefix, false, "AV46Name_Filter_PreviousValue", AV46Name_Filter_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME_FILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Name_Filter_PreviousValue, "")), context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         K2bt_confirmdialog_Visible = false;
         ucK2bt_confirmdialog.SendProperty(context, sPrefix, false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E213P2( )
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
         AssignAttri(sPrefix, false, "AV11ConfirmationRequired", AV11ConfirmationRequired);
         if ( (0==AV17CurrentPage_Grid) )
         {
            AV17CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV17CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV17CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV46Name_Filter_PreviousValue, AV45Name_Filter) != 0 )
         {
            AV46Name_Filter_PreviousValue = AV45Name_Filter;
            AssignAttri(sPrefix, false, "AV46Name_Filter_PreviousValue", AV46Name_Filter_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME_FILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46Name_Filter_PreviousValue, "")), context));
            AV17CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV17CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV17CurrentPage_Grid), 4, 0));
         }
         AV34Reload_Grid = true;
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
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
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
         GXt_objcol_SdtMessages_Message2 = AV5Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message2) ;
         AV5Messages = GXt_objcol_SdtMessages_Message2;
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV5Messages.Count )
         {
            AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV5Messages.Item(AV53GXV1));
            GX_msglist.addItem(AV32Message.gxTpr_Description);
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         AV15CurrentApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getbyguid(new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getguid(), out  AV18Errors);
         AV16CurrentApplicationId = AV15CurrentApplication.gxTpr_Id;
         AssignAttri(sPrefix, false, "AV16CurrentApplicationId", StringUtil.LTrimStr( (decimal)(AV16CurrentApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTAPPLICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV16CurrentApplicationId), "ZZZZZZZZZZZ9"), context));
      }

      protected void E223P2( )
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
         AssignProp(sPrefix, false, edtavMenuid_Internalname, "Columnheaderclass", edtavMenuid_Columnheaderclass, !bGXsfl_100_Refreshing);
         edtavMenuname_Columnheaderclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
         AssignProp(sPrefix, false, edtavMenuname_Internalname, "Columnheaderclass", edtavMenuname_Columnheaderclass, !bGXsfl_100_Refreshing);
         edtavMenudescription_Columnheaderclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn";
         AssignProp(sPrefix, false, edtavMenudescription_Internalname, "Columnheaderclass", edtavMenudescription_Columnheaderclass, !bGXsfl_100_Refreshing);
         edtavOptions_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp(sPrefix, false, edtavOptions_action_Internalname, "Columnheaderclass", edtavOptions_action_Columnheaderclass, !bGXsfl_100_Refreshing);
         edtavUpdate_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp(sPrefix, false, edtavUpdate_action_Internalname, "Columnheaderclass", edtavUpdate_action_Columnheaderclass, !bGXsfl_100_Refreshing);
         edtavDelete_action_Columnheaderclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover";
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Columnheaderclass", edtavDelete_action_Columnheaderclass, !bGXsfl_100_Refreshing);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48FilterTagsCollection_Grid", AV48FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
      }

      protected void S192( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E233P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV28I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
         AV26HasNextPage_Grid = false;
         AssignAttri(sPrefix, false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV26HasNextPage_Grid, context));
         AV19Exit_Grid = false;
         while ( true )
         {
            AV28I_LoadCount_Grid = (short)(AV28I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV28I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV28I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV28I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S212 ();
            if (returnInSub) return;
            AV33Options_Action = "Options";
            AssignAttri(sPrefix, false, edtavOptions_action_Internalname, AV33Options_Action);
            edtavUpdate_action_gximage = "K2BActionUpdate";
            AV43Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavUpdate_action_Internalname, AV43Update_Action);
            AV54Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            edtavUpdate_action_Tooltiptext = "Update";
            edtavDelete_action_gximage = "K2BActionDelete";
            AV44Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV44Delete_Action);
            AV55Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = "Delete";
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S222 ();
            if (returnInSub) return;
            if ( AV19Exit_Grid )
            {
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV36RowsPerPage_Grid * AV17CurrentPage_Grid )
            {
               AV26HasNextPage_Grid = true;
               AssignAttri(sPrefix, false, "AV26HasNextPage_Grid", AV26HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV26HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV28I_LoadCount_Grid > AV36RowsPerPage_Grid * ( AV17CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               if ( new GeneXus.Programs.k2bfsg.isapplicationmainmenu(context).executeUdp(  AV8ApplicationId,  AV30MenuId) )
               {
                  edtavOptions_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavUpdate_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavDelete_action_Columnclass = "K2BToolsGridColumn"+" "+"ActionColumn"+" "+"ActionVisibleOnRowHover"+" "+"Column_NotOK";
                  edtavMenuid_Columnclass = "K2BToolsGridColumn"+" "+"Column_NotOK";
                  edtavMenuname_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn"+" "+"Column_NotOK";
                  edtavMenudescription_Columnclass = "K2BToolsGridColumn"+" "+"InvisibleInExtraSmallColumn"+" "+"Column_NotOK";
               }
               else
               {
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
                  wbStart = 100;
               }
               sendrow_1002( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_100_Refreshing )
               {
                  context.DoAjaxLoad(100, GridRow);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20Filter", AV20Filter);
      }

      protected void S212( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV28I_LoadCount_Grid == 1 )
         {
            AV9Application.load( AV8ApplicationId);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Name_Filter)) )
            {
               AV20Filter.gxTpr_Name = "%"+AV45Name_Filter;
            }
            AV10AppMenu = AV9Application.getmenus(AV20Filter, out  AV18Errors);
         }
         if ( AV10AppMenu.Count >= AV28I_LoadCount_Grid )
         {
            AV30MenuId = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Id;
            AssignAttri(sPrefix, false, edtavMenuid_Internalname, StringUtil.LTrimStr( (decimal)(AV30MenuId), 12, 0));
            AV31MenuName = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri(sPrefix, false, edtavMenuname_Internalname, AV31MenuName);
            AV29MenuDescription = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV10AppMenu.Item(AV28I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri(sPrefix, false, edtavMenudescription_Internalname, AV29MenuDescription);
         }
         else
         {
            AV19Exit_Grid = true;
         }
      }

      protected void S202( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV17CurrentPage_Grid-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV17CurrentPage_Grid), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV17CurrentPage_Grid+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV17CurrentPage_Grid) || ( AV17CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV17CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV17CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV26HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV17CurrentPage_Grid <= 1 ) && ! AV26HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV52Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV23GridState.gxTpr_Currentpage = AV17CurrentPage_Grid;
         AV23GridState.gxTpr_Filtervalues.Clear();
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV24GridStateFilterValue.gxTpr_Filtername = "Name_Filter";
         AV24GridStateFilterValue.gxTpr_Value = AV45Name_Filter;
         AV23GridState.gxTpr_Filtervalues.Add(AV24GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV52Pgmname,  AV25GridStateKey,  AV23GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV25GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV52Pgmname,  AV25GridStateKey, out  AV23GridState) ;
         AV56GXV2 = 1;
         while ( AV56GXV2 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV56GXV2));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Filtername, "Name_Filter") == 0 )
            {
               AV45Name_Filter = AV24GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV45Name_Filter", AV45Name_Filter);
            }
            AV56GXV2 = (int)(AV56GXV2+1);
         }
         if ( AV23GridState.gxTpr_Currentpage > 0 )
         {
            AV17CurrentPage_Grid = AV23GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV17CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV17CurrentPage_Grid), 4, 0));
         }
      }

      protected void E173P2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV52Pgmname,  "Grid", ref  AV47GridConfiguration) ;
         AV47GridConfiguration.gxTpr_Freezecolumntitles = AV51FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV52Pgmname,  "Grid",  AV47GridConfiguration,  true) ;
         if ( AV36RowsPerPage_Grid != AV22GridSettingsRowsPerPage_Grid )
         {
            AV36RowsPerPage_Grid = AV22GridSettingsRowsPerPage_Grid;
            AssignAttri(sPrefix, false, "AV36RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV52Pgmname,  "Grid",  AV36RowsPerPage_Grid) ;
            AV17CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV17CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV17CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV46Name_Filter_PreviousValue, AV45Name_Filter, AV52Pgmname, AV17CurrentPage_Grid, AV26HasNextPage_Grid, AV47GridConfiguration, AV16CurrentApplicationId, AV8ApplicationId, AV50ClassCollection_Grid, AV36RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid, sPrefix) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
      }

      protected void S292( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddnew_Visible = 1;
         AssignProp(sPrefix, false, bttAddnew_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddnew_Visible), 5, 0), true);
         bttLoadapplicationmenus_Visible = 1;
         AssignProp(sPrefix, false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
         if ( AV16CurrentApplicationId == AV8ApplicationId )
         {
            bttLoadapplicationmenus_Visible = 1;
            AssignProp(sPrefix, false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
         }
         else
         {
            bttLoadapplicationmenus_Visible = 0;
            AssignProp(sPrefix, false, bttLoadapplicationmenus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationmenus_Visible), 5, 0), true);
            bttLoadapplicationmenus_Tooltiptext = "";
            AssignProp(sPrefix, false, bttLoadapplicationmenus_Internalname, "Tooltiptext", bttLoadapplicationmenus_Tooltiptext, true);
         }
      }

      protected void E183P2( )
      {
         /* 'E_AddNew' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADDNEW' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void S232( )
      {
         /* 'U_ADDNEW' Routine */
         returnInSub = false;
         AV39Window.Autoresize = 1;
         AV39Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV39Window.SetReturnParms(new Object[] {"AV8ApplicationId","AV30MenuId",});
         context.NewWindow(AV39Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void E243P2( )
      {
         /* 'E_Update' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_UPDATE' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void S242( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         AV39Window.Autoresize = 1;
         AV39Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV39Window.SetReturnParms(new Object[] {"AV8ApplicationId","AV30MenuId",});
         context.NewWindow(AV39Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void E253P2( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void S252( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV39Window.Autoresize = 1;
         AV39Window.Url = formatLink("k2bfsg.entrymenu.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"Mode","ApplicationId","MenuId"}) ;
         AV39Window.SetReturnParms(new Object[] {"AV8ApplicationId","AV30MenuId",});
         context.NewWindow(AV39Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S262( )
      {
         /* 'U_OPTIONS' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.wwmenuoptions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV30MenuId,12,0))}, new string[] {"ApplicationId","MenuId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E193P2( )
      {
         /* 'E_LoadApplicationMenus' Routine */
         returnInSub = false;
         AV13ConfirmMessage = "All defined menus will be added to the GAM database. Are you sure?";
         /* Execute user subroutine: 'U_CONFIRMATIONREQUIRED(LOADAPPLICATIONMENUS)' */
         S272 ();
         if (returnInSub) return;
         if ( AV11ConfirmationRequired )
         {
            AV12ConfirmationSubId = "'U_LoadApplicationMenus'";
            AssignAttri(sPrefix, false, "AV12ConfirmationSubId", AV12ConfirmationSubId);
            AV34Reload_Grid = false;
            K2bt_confirmdialog_Confirmmessage = AV13ConfirmMessage;
            ucK2bt_confirmdialog.SendProperty(context, sPrefix, false, K2bt_confirmdialog_Internalname, "ConfirmMessage", K2bt_confirmdialog_Confirmmessage);
            K2bt_confirmdialog_Visible = true;
            ucK2bt_confirmdialog.SendProperty(context, sPrefix, false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         }
         else
         {
            /* Execute user subroutine: 'U_LOADAPPLICATIONMENUS' */
            S282 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void S282( )
      {
         /* 'U_LOADAPPLICATIONMENUS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV35Result;
         new GeneXus.Programs.k2bfsg.persistmenusingam(context ).execute(  AV8ApplicationId, out  AV5Messages, out  GXt_boolean3) ;
         AV35Result = GXt_boolean3;
         AV57GXV3 = 1;
         while ( AV57GXV3 <= AV5Messages.Count )
         {
            AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV5Messages.Item(AV57GXV3));
            GX_msglist.addItem(AV32Message.gxTpr_Description);
            AV57GXV3 = (int)(AV57GXV3+1);
         }
         gxgrGrid_refresh( AV46Name_Filter_PreviousValue, AV45Name_Filter, AV52Pgmname, AV17CurrentPage_Grid, AV26HasNextPage_Grid, AV47GridConfiguration, AV16CurrentApplicationId, AV8ApplicationId, AV50ClassCollection_Grid, AV36RowsPerPage_Grid, AV30MenuId, AV28I_LoadCount_Grid, AV51FreezeColumnTitles_Grid, sPrefix) ;
      }

      protected void S272( )
      {
         /* 'U_CONFIRMATIONREQUIRED(LOADAPPLICATIONMENUS)' Routine */
         returnInSub = false;
         AV11ConfirmationRequired = true;
         AssignAttri(sPrefix, false, "AV11ConfirmationRequired", AV11ConfirmationRequired);
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV48FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV41K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Name_Filter)) )
         {
            AV42K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "Name_Filter";
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Description = edtavName_filter_Caption;
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV45Name_Filter;
            AV42K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.RTrim( context.localUtil.Format( AV45Name_Filter, ""));
            AV41K2BFilterValuesSDT_WebForm.Add(AV42K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No filters are applied";
         ucFiltertagsusercontrol_grid.SendProperty(context, sPrefix, false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV41K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = AV48FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV52Pgmname,  "Filters",  AV41K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item4) ;
            AV48FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item4;
         }
      }

      protected void S152( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S292 ();
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
         new k2bloadgridconfiguration(context ).execute(  AV52Pgmname,  "Grid", ref  AV47GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S302 ();
         if (returnInSub) return;
      }

      protected void S302( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV51FreezeColumnTitles_Grid = AV47GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
         if ( AV51FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV50ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV50ClassCollection_Grid) ;
         }
      }

      protected void E163P2( )
      {
         /* K2bt_confirmdialog_Onokclicked Routine */
         returnInSub = false;
         K2bt_confirmdialog_Visible = false;
         ucK2bt_confirmdialog.SendProperty(context, sPrefix, false, K2bt_confirmdialog_Internalname, "Visible", StringUtil.BoolToStr( K2bt_confirmdialog_Visible));
         if ( StringUtil.StrCmp(AV12ConfirmationSubId, "'U_LoadApplicationMenus'") == 0 )
         {
            /* Execute user subroutine: 'U_LOADAPPLICATIONMENUS' */
            S282 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void wb_table1_109_3P2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ApplicationMenuWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_109_3P2e( true) ;
         }
         else
         {
            wb_table1_109_3P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8ApplicationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
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
         PA3P2( ) ;
         WS3P2( ) ;
         WE3P2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV8ApplicationId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\applicationmenuwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8ApplicationId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
         }
         wcpOAV8ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ApplicationId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8ApplicationId != wcpOAV8ApplicationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8ApplicationId = AV8ApplicationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8ApplicationId = cgiGet( sPrefix+"AV8ApplicationId_CTRL");
         if ( StringUtil.Len( sCtrlAV8ApplicationId) > 0 )
         {
            AV8ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8ApplicationId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8ApplicationId", StringUtil.LTrimStr( (decimal)(AV8ApplicationId), 12, 0));
         }
         else
         {
            AV8ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8ApplicationId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8ApplicationId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ApplicationId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8ApplicationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8ApplicationId_CTRL", StringUtil.RTrim( sCtrlAV8ApplicationId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024313814406", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("k2bfsg/applicationmenuwc.js", "?20243138144010", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ConfirmDialogRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1002( )
      {
         edtavMenuid_Internalname = sPrefix+"vMENUID_"+sGXsfl_100_idx;
         edtavMenuname_Internalname = sPrefix+"vMENUNAME_"+sGXsfl_100_idx;
         edtavMenudescription_Internalname = sPrefix+"vMENUDESCRIPTION_"+sGXsfl_100_idx;
         edtavOptions_action_Internalname = sPrefix+"vOPTIONS_ACTION_"+sGXsfl_100_idx;
         edtavUpdate_action_Internalname = sPrefix+"vUPDATE_ACTION_"+sGXsfl_100_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_100_idx;
      }

      protected void SubsflControlProps_fel_1002( )
      {
         edtavMenuid_Internalname = sPrefix+"vMENUID_"+sGXsfl_100_fel_idx;
         edtavMenuname_Internalname = sPrefix+"vMENUNAME_"+sGXsfl_100_fel_idx;
         edtavMenudescription_Internalname = sPrefix+"vMENUDESCRIPTION_"+sGXsfl_100_fel_idx;
         edtavOptions_action_Internalname = sPrefix+"vOPTIONS_ACTION_"+sGXsfl_100_fel_idx;
         edtavUpdate_action_Internalname = sPrefix+"vUPDATE_ACTION_"+sGXsfl_100_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_100_fel_idx;
      }

      protected void sendrow_1002( )
      {
         SubsflControlProps_1002( ) ;
         WB3P0( ) ;
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
            if ( ((int)((nGXsfl_100_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_100_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenuid_Enabled!=0)&&(edtavMenuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 101,'"+sPrefix+"',false,'"+sGXsfl_100_idx+"',100)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenuid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30MenuId), 12, 0, ".", "")),StringUtil.LTrim( ((edtavMenuid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30MenuId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30MenuId), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavMenuid_Enabled!=0)&&(edtavMenuid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenuid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenuid_Columnclass,(string)edtavMenuid_Columnheaderclass,(short)0,(int)edtavMenuid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenuname_Enabled!=0)&&(edtavMenuname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'"+sPrefix+"',false,'"+sGXsfl_100_idx+"',100)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenuname_Internalname,StringUtil.RTrim( AV31MenuName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMenuname_Enabled!=0)&&(edtavMenuname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,102);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e263p2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenuname_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenuname_Columnclass,(string)edtavMenuname_Columnheaderclass,(short)-1,(int)edtavMenuname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMenudescription_Enabled!=0)&&(edtavMenudescription_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 103,'"+sPrefix+"',false,'"+sGXsfl_100_idx+"',100)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMenudescription_Internalname,StringUtil.RTrim( AV29MenuDescription),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMenudescription_Enabled!=0)&&(edtavMenudescription_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,103);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMenudescription_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)edtavMenudescription_Columnclass,(string)edtavMenudescription_Columnheaderclass,(short)-1,(int)edtavMenudescription_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 104,'"+sPrefix+"',false,'"+sGXsfl_100_idx+"',100)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptions_action_Internalname,StringUtil.RTrim( AV33Options_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,104);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e273p2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptions_action_Jsonclick,(short)7,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)edtavOptions_action_Columnclass,(string)edtavOptions_action_Columnheaderclass,(short)-1,(int)edtavOptions_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 105,'"+sPrefix+"',false,'',100)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class");
         StyleString = "";
         AV43Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV43Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV54Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV43Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Update_Action)) ? AV54Update_action_GXI : context.PathToRelativeUrl( AV43Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"K2BT_UpdateAction",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUpdate_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_UPDATE\\'."+sGXsfl_100_idx+"'",(string)StyleString,(string)ClassString,(string)edtavUpdate_action_Columnclass,(string)edtavUpdate_action_Columnheaderclass,(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV43Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 106,'"+sPrefix+"',false,'',100)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV44Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV55Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Delete_Action)) ? AV55Delete_action_GXI : context.PathToRelativeUrl( AV44Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"K2BT_DeleteAction",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETE\\'."+sGXsfl_100_idx+"'",(string)StyleString,(string)ClassString,(string)edtavDelete_action_Columnclass,(string)edtavDelete_action_Columnheaderclass,(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV44Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3P2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_100_idx = ((subGrid_Islastpage==1)&&(nGXsfl_100_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
         sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
         SubsflControlProps_1002( ) ;
         /* End function sendrow_1002 */
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
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp(sPrefix, false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl100( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"100\">") ;
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
            context.SendWebValue( "ID") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV33Options_Action)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavOptions_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavOptions_action_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptions_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV43Update_Action));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavUpdate_action_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavUpdate_action_Columnheaderclass));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV44Delete_Action));
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
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         lblLayoutdefined_k2bt_filtercaption_grid_Internalname = sPrefix+"LAYOUTDEFINED_K2BT_FILTERCAPTION_GRID";
         Filtertagsusercontrol_grid_Internalname = sPrefix+"FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table11_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE11_GRID";
         edtavName_filter_Internalname = sPrefix+"vNAME_FILTER";
         divTable_container_name_filter_Internalname = sPrefix+"TABLE_CONTAINER_NAME_FILTER";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         imgGridsettings_labelgrid_Internalname = sPrefix+"GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_grid_Internalname = sPrefix+"vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = sPrefix+"ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = sPrefix+"vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = sPrefix+"FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = sPrefix+"GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = sPrefix+"GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = sPrefix+"GRIDSETTINGS_GLOBALTABLE_GRID";
         bttAddnew_Internalname = sPrefix+"ADDNEW";
         divActions_grid_topright_Internalname = sPrefix+"ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         bttLoadapplicationmenus_Internalname = sPrefix+"LOADAPPLICATIONMENUS";
         divActions_grid_gridassociatedleft_Internalname = sPrefix+"ACTIONS_GRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_GRID";
         divLayoutdefined_section3_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_GRID";
         divLayoutdefined_section1_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_GRID";
         edtavMenuid_Internalname = sPrefix+"vMENUID";
         edtavMenuname_Internalname = sPrefix+"vMENUNAME";
         edtavMenudescription_Internalname = sPrefix+"vMENUDESCRIPTION";
         edtavOptions_action_Internalname = sPrefix+"vOPTIONS_ACTION";
         edtavUpdate_action_Internalname = sPrefix+"vUPDATE_ACTION";
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = sPrefix+"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bt_confirmdialog_Internalname = sPrefix+"K2BT_CONFIRMDIALOG";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
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
         edtavName_filter_Jsonclick = "";
         edtavName_filter_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         edtavName_filter_Caption = "Name";
         K2bt_confirmdialog_Visible = Convert.ToBoolean( -1);
         K2bt_confirmdialog_Confirmmessage = "K2BT_AreYouSure";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'sPrefix'},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E223P2',iparms:[{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'edtavName_filter_Caption',ctrl:'vNAME_FILTER',prop:'Caption'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'edtavMenuid_Columnheaderclass',ctrl:'vMENUID',prop:'Columnheaderclass'},{av:'edtavMenuname_Columnheaderclass',ctrl:'vMENUNAME',prop:'Columnheaderclass'},{av:'edtavMenudescription_Columnheaderclass',ctrl:'vMENUDESCRIPTION',prop:'Columnheaderclass'},{av:'edtavOptions_action_Columnheaderclass',ctrl:'vOPTIONS_ACTION',prop:'Columnheaderclass'},{av:'edtavUpdate_action_Columnheaderclass',ctrl:'vUPDATE_ACTION',prop:'Columnheaderclass'},{av:'edtavDelete_action_Columnheaderclass',ctrl:'vDELETE_ACTION',prop:'Columnheaderclass'},{av:'AV48FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E233P2',iparms:[{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV33Options_Action',fld:'vOPTIONS_ACTION',pic:''},{av:'AV43Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV44Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'edtavOptions_action_Columnclass',ctrl:'vOPTIONS_ACTION',prop:'Columnclass'},{av:'edtavUpdate_action_Columnclass',ctrl:'vUPDATE_ACTION',prop:'Columnclass'},{av:'edtavDelete_action_Columnclass',ctrl:'vDELETE_ACTION',prop:'Columnclass'},{av:'edtavMenuid_Columnclass',ctrl:'vMENUID',prop:'Columnclass'},{av:'edtavMenuname_Columnclass',ctrl:'vMENUNAME',prop:'Columnclass'},{av:'edtavMenudescription_Columnclass',ctrl:'vMENUDESCRIPTION',prop:'Columnclass'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV31MenuName',fld:'vMENUNAME',pic:''},{av:'AV29MenuDescription',fld:'vMENUDESCRIPTION',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E143P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E133P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E153P1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E123P1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV22GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E173P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV22GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ADDNEW'","{handler:'E183P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_ADDNEW'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E243P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E253P2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_OPTIONS'","{handler:'E273P2',iparms:[{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_OPTIONS'",",oparms:[{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("VMENUNAME.CLICK","{handler:'E263P2',iparms:[{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("VMENUNAME.CLICK",",oparms:[]}");
         setEventMetadata("'E_LOADAPPLICATIONMENUS'","{handler:'E193P2',iparms:[{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_LOADAPPLICATIONMENUS'",",oparms:[{av:'AV12ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'K2bt_confirmdialog_Confirmmessage',ctrl:'K2BT_CONFIRMDIALOG',prop:'ConfirmMessage'},{av:'K2bt_confirmdialog_Visible',ctrl:'K2BT_CONFIRMDIALOG',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E113P1',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]}");
         setEventMetadata("K2BT_CONFIRMDIALOG.ONOKCLICKED","{handler:'E163P2',iparms:[{av:'AV12ConfirmationSubId',fld:'vCONFIRMATIONSUBID',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV45Name_Filter',fld:'vNAME_FILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV26HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV8ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV30MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9'},{av:'AV28I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("K2BT_CONFIRMDIALOG.ONOKCLICKED",",oparms:[{av:'K2bt_confirmdialog_Visible',ctrl:'K2BT_CONFIRMDIALOG',prop:'Visible'},{av:'AV11ConfirmationRequired',fld:'vCONFIRMATIONREQUIRED',pic:''},{av:'AV17CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46Name_Filter_PreviousValue',fld:'vNAME_FILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV16CurrentApplicationId',fld:'vCURRENTAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{ctrl:'ADDNEW',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Visible'},{ctrl:'LOADAPPLICATIONMENUS',prop:'Tooltiptext'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
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
         sPrefix = "";
         AV46Name_Filter_PreviousValue = "";
         AV45Name_Filter = "";
         AV52Pgmname = "";
         AV47GridConfiguration = new SdtK2BGridConfiguration(context);
         AV50ClassCollection_Grid = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV48FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV49DeletedTag_Grid = "";
         AV12ConfirmationSubId = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31MenuName = "";
         AV29MenuDescription = "";
         AV33Options_Action = "";
         AV43Update_Action = "";
         AV54Update_action_GXI = "";
         AV44Delete_Action = "";
         AV55Delete_action_GXI = "";
         GXt_char1 = "";
         AV5Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV15CurrentApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV18Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridRow = new GXWebRow();
         AV20Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV9Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV10AppMenu = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV25GridStateKey = "";
         AV23GridState = new SdtK2BGridState(context);
         AV24GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV39Window = new GXWindow();
         AV13ConfirmMessage = "";
         AV41K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV42K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item4 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8ApplicationId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         AV52Pgmname = "K2BFSG.ApplicationMenuWC";
         /* GeneXus formulas. */
         AV52Pgmname = "K2BFSG.ApplicationMenuWC";
         edtavMenuid_Enabled = 0;
         edtavMenuname_Enabled = 0;
         edtavMenudescription_Enabled = 0;
         edtavOptions_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV17CurrentPage_Grid ;
      private short AV36RowsPerPage_Grid ;
      private short AV28I_LoadCount_Grid ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV22GridSettingsRowsPerPage_Grid ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_100 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_100_idx=1 ;
      private int edtavMenuid_Enabled ;
      private int edtavMenuname_Enabled ;
      private int edtavMenudescription_Enabled ;
      private int edtavOptions_action_Enabled ;
      private int edtavName_filter_Enabled ;
      private int bttAddnew_Visible ;
      private int bttLoadapplicationmenus_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int AV53GXV1 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV56GXV2 ;
      private int AV57GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavMenuid_Visible ;
      private int edtavMenuname_Visible ;
      private int edtavMenudescription_Visible ;
      private int edtavOptions_action_Visible ;
      private int edtavUpdate_action_Enabled ;
      private int edtavUpdate_action_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8ApplicationId ;
      private long wcpOAV8ApplicationId ;
      private long AV16CurrentApplicationId ;
      private long AV30MenuId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string edtavName_filter_Caption ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_100_idx="0001" ;
      private string AV46Name_Filter_PreviousValue ;
      private string AV45Name_Filter ;
      private string AV52Pgmname ;
      private string edtavMenuid_Internalname ;
      private string edtavMenuname_Internalname ;
      private string edtavMenudescription_Internalname ;
      private string edtavOptions_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV49DeletedTag_Grid ;
      private string AV12ConfirmationSubId ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string K2bt_confirmdialog_Confirmmessage ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
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
      private string divTable_container_name_filter_Internalname ;
      private string edtavName_filter_Internalname ;
      private string edtavName_filter_Jsonclick ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV31MenuName ;
      private string AV29MenuDescription ;
      private string AV33Options_Action ;
      private string edtavUpdate_action_Internalname ;
      private string edtavDelete_action_Internalname ;
      private string GXt_char1 ;
      private string edtavMenuid_Columnheaderclass ;
      private string edtavMenuname_Columnheaderclass ;
      private string edtavMenudescription_Columnheaderclass ;
      private string edtavOptions_action_Columnheaderclass ;
      private string edtavUpdate_action_Columnheaderclass ;
      private string edtavDelete_action_Columnheaderclass ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavUpdate_action_gximage ;
      private string edtavUpdate_action_Tooltiptext ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string edtavOptions_action_Columnclass ;
      private string edtavUpdate_action_Columnclass ;
      private string edtavDelete_action_Columnclass ;
      private string edtavMenuid_Columnclass ;
      private string edtavMenuname_Columnclass ;
      private string edtavMenudescription_Columnclass ;
      private string AV13ConfirmMessage ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlAV8ApplicationId ;
      private string sGXsfl_100_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavMenuid_Jsonclick ;
      private string edtavMenuname_Jsonclick ;
      private string edtavMenudescription_Jsonclick ;
      private string edtavOptions_action_Jsonclick ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26HasNextPage_Grid ;
      private bool AV51FreezeColumnTitles_Grid ;
      private bool bGXsfl_100_Refreshing=false ;
      private bool AV11ConfirmationRequired ;
      private bool K2bt_confirmdialog_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV40RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV34Reload_Grid ;
      private bool AV19Exit_Grid ;
      private bool AV35Result ;
      private bool GXt_boolean3 ;
      private bool AV43Update_Action_IsBlob ;
      private bool AV44Delete_Action_IsBlob ;
      private string AV54Update_action_GXI ;
      private string AV55Delete_action_GXI ;
      private string AV25GridStateKey ;
      private string AV43Update_Action ;
      private string AV44Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bt_confirmdialog ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV50ClassCollection_Grid ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV18Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV10AppMenu ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV41K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV48FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item4 ;
      private GXWindow AV39Window ;
      private GeneXus.Utils.SdtMessages_Message AV32Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV15CurrentApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV9Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV20Filter ;
      private SdtK2BGridState AV23GridState ;
      private SdtK2BGridState_FilterValue AV24GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV42K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV47GridConfiguration ;
   }

}
