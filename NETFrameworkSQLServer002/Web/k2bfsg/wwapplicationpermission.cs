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
   public class wwapplicationpermission : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwapplicationpermission( )
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

      public wwapplicationpermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ApplicationId )
      {
         this.AV9ApplicationId = aP0_ApplicationId;
         executePrivate();
         aP0_ApplicationId=this.AV9ApplicationId;
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
         cmbavPermissionaccesstypedefault = new GXCombobox();
         cmbavPermissiontypefilter = new GXCombobox();
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
         cmbavAccesstype = new GXCombobox();
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
                  AV9ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV9ApplicationId});
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
         nRC_GXsfl_109 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_109"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_109_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_109_idx = GetPar( "sGXsfl_109_idx");
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
         AV50GenericFilter_PreviousValue_Grid = GetPar( "GenericFilter_PreviousValue_Grid");
         AV37PermissionAccessTypeDefault_PreviousValue = GetPar( "PermissionAccessTypeDefault_PreviousValue");
         AV38PermissionTypeFilter_PreviousValue = GetPar( "PermissionTypeFilter_PreviousValue");
         AV9ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         cmbavPermissionaccesstypedefault.FromJSonString( GetNextPar( ));
         AV28PermissionAccessTypeDefault = GetPar( "PermissionAccessTypeDefault");
         cmbavPermissiontypefilter.FromJSonString( GetNextPar( ));
         AV29PermissionTypeFilter = GetPar( "PermissionTypeFilter");
         AV52Pgmname = GetPar( "Pgmname");
         AV12CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV46GenericFilter_Grid = GetPar( "GenericFilter_Grid");
         AV21HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47GridConfiguration);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV48ClassCollection_Grid);
         AV35RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV23I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV49FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV50GenericFilter_PreviousValue_Grid, AV37PermissionAccessTypeDefault_PreviousValue, AV38PermissionTypeFilter_PreviousValue, AV9ApplicationId, AV28PermissionAccessTypeDefault, AV29PermissionTypeFilter, AV52Pgmname, AV12CurrentPage_Grid, AV46GenericFilter_Grid, AV21HasNextPage_Grid, AV47GridConfiguration, AV48ClassCollection_Grid, AV35RowsPerPage_Grid, AV23I_LoadCount_Grid, AV49FreezeColumnTitles_Grid, sPrefix) ;
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
            PA3O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV52Pgmname = "K2BFSG.WWApplicationPermission";
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_109_Refreshing);
               edtavDsc_Enabled = 0;
               AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_109_Refreshing);
               cmbavAccesstype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_109_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_109_Refreshing);
               WS3O2( ) ;
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
            context.SendWebValue( context.GetMessage( "K2BT_GAM_WWApplicationPermission", "")) ;
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
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwapplicationpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0))}, new string[] {"ApplicationId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV50GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", StringUtil.RTrim( AV37PermissionAccessTypeDefault_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37PermissionAccessTypeDefault_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONTYPEFILTER_PREVIOUSVALUE", StringUtil.RTrim( AV38PermissionTypeFilter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONTYPEFILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38PermissionTypeFilter_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV21HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV21HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_109", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_109), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV44FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV44FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG_GRID", StringUtil.RTrim( AV45DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9ApplicationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9ApplicationId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV50GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", StringUtil.RTrim( AV37PermissionAccessTypeDefault_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37PermissionAccessTypeDefault_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONTYPEFILTER_PREVIOUSVALUE", StringUtil.RTrim( AV38PermissionTypeFilter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONTYPEFILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38PermissionTypeFilter_PreviousValue, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV48ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV48ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV21HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV21HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35RowsPerPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_Caption", StringUtil.RTrim( cmbavPermissionaccesstypedefault.Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONTYPEFILTER_Caption", StringUtil.RTrim( cmbavPermissiontypefilter.Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_Caption", StringUtil.RTrim( cmbavPermissionaccesstypedefault.Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONTYPEFILTER_Caption", StringUtil.RTrim( cmbavPermissiontypefilter.Caption));
      }

      protected void RenderHtmlCloseForm3O2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "K2BFSG.WWApplicationPermission" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_WWApplicationPermission", "") ;
      }

      protected void WB3O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wwapplicationpermission.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV46GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV46GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "K2BT_GenericFilterInviteMessage", ""), edtavGenericfilter_grid_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\WWApplicationPermission.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_combined_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_combined_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_combined_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113o1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWApplicationPermission.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV44FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV45DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, sPrefix+"FILTERTAGSUSERCONTROL_GRIDContainer");
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
            GxWebStd.gx_div_start( context, divTable_container_permissionaccesstypedefault_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavPermissionaccesstypedefault_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPermissionaccesstypedefault_Internalname, context.GetMessage( "K2BT_GAM_DefaultAccess", ""), "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPermissionaccesstypedefault, cmbavPermissionaccesstypedefault_Internalname, StringUtil.RTrim( AV28PermissionAccessTypeDefault), 1, cmbavPermissionaccesstypedefault_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavPermissionaccesstypedefault.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            cmbavPermissionaccesstypedefault.CurrentValue = StringUtil.RTrim( AV28PermissionAccessTypeDefault);
            AssignProp(sPrefix, false, cmbavPermissionaccesstypedefault_Internalname, "Values", (string)(cmbavPermissionaccesstypedefault.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_permissiontypefilter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavPermissiontypefilter_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPermissiontypefilter_Internalname, context.GetMessage( "K2BT_GAM_FilterBy", ""), "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPermissiontypefilter, cmbavPermissiontypefilter_Internalname, StringUtil.RTrim( AV29PermissionTypeFilter), 1, cmbavPermissiontypefilter_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavPermissiontypefilter.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            cmbavPermissiontypefilter.CurrentValue = StringUtil.RTrim( AV29PermissionTypeFilter);
            AssignProp(sPrefix, false, cmbavPermissiontypefilter_Internalname, "Values", (string)(cmbavPermissiontypefilter.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", context.GetMessage( "K2BT_GridSettingsLabel", ""), 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e123o1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, context.GetMessage( "K2BT_GridSettingsLabel", ""), "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0));
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
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, context.GetMessage( "K2BT_FreezeColumnTitles", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_109_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV49FreezeColumnTitles_Grid), "", context.GetMessage( "K2BT_FreezeColumnTitles", ""), 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_GridSettingsApply", ""), bttGridsettings_savegrid_Jsonclick, 5, context.GetMessage( "K2BT_GridSettingsApply", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_InsertAction", ""), bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLoadapplicationpermissions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_GAM_LoadApplicationPermissions", ""), bttLoadapplicationpermissions_Jsonclick, 5, "", "", StyleString, ClassString, bttLoadapplicationpermissions_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_LOADAPPLICATIONPERMISSIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            StartGridControl109( ) ;
         }
         if ( wbEnd == 109 )
         {
            wbEnd = 0;
            nRC_GXsfl_109 = (int)(nGXsfl_109_idx-1);
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
            wb_table1_118_3O2( true) ;
         }
         else
         {
            wb_table1_118_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_118_3O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133o1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e143o1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133o1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e153o1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e153o1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 109 )
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

      protected void START3O2( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_WWApplicationPermission", ""), 0) ;
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
               STRUP3O0( ) ;
            }
         }
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                                 STRUP3O0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E163O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings(Grid)' */
                                    E173O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_LOADAPPLICATIONPERMISSIONS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_LoadApplicationPermissions' */
                                    E183O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavName_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
                              SubsflControlProps_1092( ) ;
                              AV27Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV27Name);
                              AV13Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri(sPrefix, false, edtavDsc_Internalname, AV13Dsc);
                              cmbavAccesstype.Name = cmbavAccesstype_Internalname;
                              cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
                              AV5AccessType = cgiGet( cmbavAccesstype_Internalname);
                              AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV5AccessType);
                              AV24Id = cgiGet( edtavId_Internalname);
                              AssignAttri(sPrefix, false, edtavId_Internalname, AV24Id);
                              AV42Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp(sPrefix, false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update_Action)) ? AV53Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV42Update_Action))), !bGXsfl_109_Refreshing);
                              AssignProp(sPrefix, false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV42Update_Action), true);
                              AV43Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete_Action)) ? AV54Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV43Delete_Action))), !bGXsfl_109_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV43Delete_Action), true);
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E193O2 ();
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E203O2 ();
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E213O2 ();
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
                                          GX_FocusControl = edtavName_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E223O2 ();
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
                                       STRUP3O0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavName_Internalname;
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

      protected void WE3O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3O2( ) ;
            }
         }
      }

      protected void PA3O2( )
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
               GX_FocusControl = edtavGenericfilter_grid_Internalname;
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
         SubsflControlProps_1092( ) ;
         while ( nGXsfl_109_idx <= nRC_GXsfl_109 )
         {
            sendrow_1092( ) ;
            nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV50GenericFilter_PreviousValue_Grid ,
                                       string AV37PermissionAccessTypeDefault_PreviousValue ,
                                       string AV38PermissionTypeFilter_PreviousValue ,
                                       long AV9ApplicationId ,
                                       string AV28PermissionAccessTypeDefault ,
                                       string AV29PermissionTypeFilter ,
                                       string AV52Pgmname ,
                                       short AV12CurrentPage_Grid ,
                                       string AV46GenericFilter_Grid ,
                                       bool AV21HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV47GridConfiguration ,
                                       GxSimpleCollection<string> AV48ClassCollection_Grid ,
                                       short AV35RowsPerPage_Grid ,
                                       short AV23I_LoadCount_Grid ,
                                       bool AV49FreezeColumnTitles_Grid ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3O2( ) ;
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
         if ( cmbavPermissionaccesstypedefault.ItemCount > 0 )
         {
            AV28PermissionAccessTypeDefault = cmbavPermissionaccesstypedefault.getValidValue(AV28PermissionAccessTypeDefault);
            AssignAttri(sPrefix, false, "AV28PermissionAccessTypeDefault", AV28PermissionAccessTypeDefault);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPermissionaccesstypedefault.CurrentValue = StringUtil.RTrim( AV28PermissionAccessTypeDefault);
            AssignProp(sPrefix, false, cmbavPermissionaccesstypedefault_Internalname, "Values", cmbavPermissionaccesstypedefault.ToJavascriptSource(), true);
         }
         if ( cmbavPermissiontypefilter.ItemCount > 0 )
         {
            AV29PermissionTypeFilter = cmbavPermissiontypefilter.getValidValue(AV29PermissionTypeFilter);
            AssignAttri(sPrefix, false, "AV29PermissionTypeFilter", AV29PermissionTypeFilter);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPermissiontypefilter.CurrentValue = StringUtil.RTrim( AV29PermissionTypeFilter);
            AssignProp(sPrefix, false, cmbavPermissiontypefilter_Internalname, "Values", cmbavPermissiontypefilter.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV36GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV36GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV49FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV49FreezeColumnTitles_Grid));
         AssignAttri(sPrefix, false, "AV49FreezeColumnTitles_Grid", AV49FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E203O2 ();
         RF3O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "K2BFSG.WWApplicationPermission";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_109_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_109_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_109_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_109_Refreshing);
      }

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E203O2 ();
         E223O2 ();
         nGXsfl_109_idx = 1;
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         bGXsfl_109_Refreshing = true;
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
            SubsflControlProps_1092( ) ;
            E213O2 ();
            wbEnd = 109;
            WB3O0( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV50GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", StringUtil.RTrim( AV37PermissionAccessTypeDefault_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37PermissionAccessTypeDefault_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPERMISSIONTYPEFILTER_PREVIOUSVALUE", StringUtil.RTrim( AV38PermissionTypeFilter_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONTYPEFILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38PermissionTypeFilter_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV21HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV21HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23I_LoadCount_Grid), "ZZZ9"), context));
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
         AV52Pgmname = "K2BFSG.WWApplicationPermission";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_109_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_109_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_109_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_109_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E193O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGSCOLLECTION_GRID"), AV44FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_109"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV45DeletedTag_Grid = cgiGet( sPrefix+"vDELETEDTAG_GRID");
            wcpOAV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9ApplicationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV12CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV35RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vROWSPERPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vAPPLICATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV21HasNextPage_Grid = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            cmbavPermissionaccesstypedefault.Caption = cgiGet( sPrefix+"vPERMISSIONACCESSTYPEDEFAULT_Caption");
            cmbavPermissiontypefilter.Caption = cgiGet( sPrefix+"vPERMISSIONTYPEFILTER_Caption");
            /* Read variables values. */
            AV46GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri(sPrefix, false, "AV46GenericFilter_Grid", AV46GenericFilter_Grid);
            cmbavPermissionaccesstypedefault.Name = cmbavPermissionaccesstypedefault_Internalname;
            cmbavPermissionaccesstypedefault.CurrentValue = cgiGet( cmbavPermissionaccesstypedefault_Internalname);
            AV28PermissionAccessTypeDefault = cgiGet( cmbavPermissionaccesstypedefault_Internalname);
            AssignAttri(sPrefix, false, "AV28PermissionAccessTypeDefault", AV28PermissionAccessTypeDefault);
            cmbavPermissiontypefilter.Name = cmbavPermissiontypefilter_Internalname;
            cmbavPermissiontypefilter.CurrentValue = cgiGet( cmbavPermissiontypefilter_Internalname);
            AV29PermissionTypeFilter = cgiGet( cmbavPermissiontypefilter_Internalname);
            AssignAttri(sPrefix, false, "AV29PermissionTypeFilter", AV29PermissionTypeFilter);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV36GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV36GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0));
            AV49FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri(sPrefix, false, "AV49FreezeColumnTitles_Grid", AV49FreezeColumnTitles_Grid);
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
         AV8Application.load( AV9ApplicationId);
         GXt_objcol_SdtMessages_Message1 = AV26Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV26Messages = GXt_objcol_SdtMessages_Message1;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV26Messages.Count )
         {
            AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV26Messages.Item(AV51GXV1));
            GX_msglist.addItem(AV25Message.gxTpr_Description);
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E193O2 ();
         if (returnInSub) return;
      }

      protected void E193O2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV52Pgmname,  "Grid", out  AV35RowsPerPage_Grid, out  AV39RowsPerPageLoaded_Grid) ;
         AssignAttri(sPrefix, false, "AV35RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV35RowsPerPage_Grid), 4, 0));
         if ( ! AV39RowsPerPageLoaded_Grid )
         {
            AV35RowsPerPage_Grid = 20;
            AssignAttri(sPrefix, false, "AV35RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV35RowsPerPage_Grid), 4, 0));
         }
         AV36GridSettingsRowsPerPage_Grid = AV35RowsPerPage_Grid;
         AssignAttri(sPrefix, false, "AV36GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV36GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV50GenericFilter_PreviousValue_Grid = AV46GenericFilter_Grid;
         AssignAttri(sPrefix, false, "AV50GenericFilter_PreviousValue_Grid", AV50GenericFilter_PreviousValue_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50GenericFilter_PreviousValue_Grid, "")), context));
         AV37PermissionAccessTypeDefault_PreviousValue = AV28PermissionAccessTypeDefault;
         AssignAttri(sPrefix, false, "AV37PermissionAccessTypeDefault_PreviousValue", AV37PermissionAccessTypeDefault_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37PermissionAccessTypeDefault_PreviousValue, "")), context));
         AV38PermissionTypeFilter_PreviousValue = AV29PermissionTypeFilter;
         AssignAttri(sPrefix, false, "AV38PermissionTypeFilter_PreviousValue", AV38PermissionTypeFilter_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONTYPEFILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38PermissionTypeFilter_PreviousValue, "")), context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E203O2( )
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
         if ( (0==AV12CurrentPage_Grid) )
         {
            AV12CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV50GenericFilter_PreviousValue_Grid, AV46GenericFilter_Grid) != 0 )
         {
            AV50GenericFilter_PreviousValue_Grid = AV46GenericFilter_Grid;
            AssignAttri(sPrefix, false, "AV50GenericFilter_PreviousValue_Grid", AV50GenericFilter_PreviousValue_Grid);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50GenericFilter_PreviousValue_Grid, "")), context));
            AV12CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV37PermissionAccessTypeDefault_PreviousValue, AV28PermissionAccessTypeDefault) != 0 )
         {
            AV37PermissionAccessTypeDefault_PreviousValue = AV28PermissionAccessTypeDefault;
            AssignAttri(sPrefix, false, "AV37PermissionAccessTypeDefault_PreviousValue", AV37PermissionAccessTypeDefault_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37PermissionAccessTypeDefault_PreviousValue, "")), context));
            AV12CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV38PermissionTypeFilter_PreviousValue, AV29PermissionTypeFilter) != 0 )
         {
            AV38PermissionTypeFilter_PreviousValue = AV29PermissionTypeFilter;
            AssignAttri(sPrefix, false, "AV38PermissionTypeFilter_PreviousValue", AV38PermissionTypeFilter_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPERMISSIONTYPEFILTER_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV38PermissionTypeFilter_PreviousValue, "")), context));
            AV12CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         AV30Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV48ClassCollection_Grid) ;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV48ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection_Grid", AV48ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      protected void S172( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S232( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV12CurrentPage_Grid) || ( AV12CurrentPage_Grid <= 1 ) )
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
            if ( AV12CurrentPage_Grid == 2 )
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
               if ( AV12CurrentPage_Grid == 3 )
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
         if ( ! AV21HasNextPage_Grid )
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
         if ( ( AV12CurrentPage_Grid <= 1 ) && ! AV21HasNextPage_Grid )
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
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryapplicationpermission.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV24Id))}, new string[] {"Mode","ApplicationId","Id"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryapplicationpermission.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(AV24Id))}, new string[] {"Mode","ApplicationId","Id"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryapplicationpermission.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","ApplicationId","Id"}) );
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void E163O2( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection_Grid", AV48ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
      }

      private void E213O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV23I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV23I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV23I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23I_LoadCount_Grid), "ZZZ9"), context));
         AV21HasNextPage_Grid = false;
         AssignAttri(sPrefix, false, "AV21HasNextPage_Grid", AV21HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV21HasNextPage_Grid, context));
         AV15Exit_Grid = false;
         while ( true )
         {
            AV23I_LoadCount_Grid = (short)(AV23I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV23I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV23I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S212 ();
            if (returnInSub) return;
            edtavUpdate_action_gximage = "K2BActionUpdate";
            AV42Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavUpdate_action_Internalname, AV42Update_Action);
            AV53Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            edtavUpdate_action_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
            edtavDelete_action_gximage = "K2BActionDelete";
            AV43Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV43Delete_Action);
            AV54Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S222 ();
            if (returnInSub) return;
            if ( AV15Exit_Grid )
            {
               if (true) break;
            }
            if ( AV23I_LoadCount_Grid > AV35RowsPerPage_Grid * AV12CurrentPage_Grid )
            {
               AV21HasNextPage_Grid = true;
               AssignAttri(sPrefix, false, "AV21HasNextPage_Grid", AV21HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV21HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV23I_LoadCount_Grid > AV35RowsPerPage_Grid * ( AV12CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 109;
               }
               sendrow_1092( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_109_Refreshing )
               {
                  context.DoAjaxLoad(109, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16Filter", AV16Filter);
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV5AccessType);
      }

      protected void S212( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV23I_LoadCount_Grid == 1 )
         {
            AV8Application.load( AV9ApplicationId);
            AV16Filter.gxTpr_Name = AV46GenericFilter_Grid;
            AV16Filter.gxTpr_Accesstypedefault = AV28PermissionAccessTypeDefault;
            AV16Filter.gxTpr_Typefilter = AV29PermissionTypeFilter;
            AV11AppPermissions = AV8Application.getpermissions(AV16Filter, out  AV14Errors);
         }
         if ( AV11AppPermissions.Count >= AV23I_LoadCount_Grid )
         {
            AV27Name = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV11AppPermissions.Item(AV23I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri(sPrefix, false, edtavName_Internalname, AV27Name);
            AV13Dsc = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV11AppPermissions.Item(AV23I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri(sPrefix, false, edtavDsc_Internalname, AV13Dsc);
            AV5AccessType = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV11AppPermissions.Item(AV23I_LoadCount_Grid)).gxTpr_Accesstype;
            AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV5AccessType);
            AV24Id = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV11AppPermissions.Item(AV23I_LoadCount_Grid)).gxTpr_Guid;
            AssignAttri(sPrefix, false, edtavId_Internalname, AV24Id);
         }
         else
         {
            AV15Exit_Grid = true;
         }
      }

      protected void S242( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV20GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV52Pgmname,  AV20GridStateKey, out  AV18GridState) ;
         AV18GridState.gxTpr_Currentpage = AV12CurrentPage_Grid;
         AV18GridState.gxTpr_Filtervalues.Clear();
         AV19GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV19GridStateFilterValue.gxTpr_Filtername = "PermissionAccessTypeDefault";
         AV19GridStateFilterValue.gxTpr_Value = AV28PermissionAccessTypeDefault;
         AV18GridState.gxTpr_Filtervalues.Add(AV19GridStateFilterValue, 0);
         AV19GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV19GridStateFilterValue.gxTpr_Filtername = "PermissionTypeFilter";
         AV19GridStateFilterValue.gxTpr_Value = AV29PermissionTypeFilter;
         AV18GridState.gxTpr_Filtervalues.Add(AV19GridStateFilterValue, 0);
         AV19GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV19GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV19GridStateFilterValue.gxTpr_Value = AV46GenericFilter_Grid;
         AV18GridState.gxTpr_Filtervalues.Add(AV19GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV52Pgmname,  AV20GridStateKey,  AV18GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV20GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV52Pgmname,  AV20GridStateKey, out  AV18GridState) ;
         AV55GXV2 = 1;
         while ( AV55GXV2 <= AV18GridState.gxTpr_Filtervalues.Count )
         {
            AV19GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV18GridState.gxTpr_Filtervalues.Item(AV55GXV2));
            if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Filtername, "PermissionAccessTypeDefault") == 0 )
            {
               AV28PermissionAccessTypeDefault = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28PermissionAccessTypeDefault", AV28PermissionAccessTypeDefault);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Filtername, "PermissionTypeFilter") == 0 )
            {
               AV29PermissionTypeFilter = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29PermissionTypeFilter", AV29PermissionTypeFilter);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV46GenericFilter_Grid = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV46GenericFilter_Grid", AV46GenericFilter_Grid);
            }
            AV55GXV2 = (int)(AV55GXV2+1);
         }
         if ( AV18GridState.gxTpr_Currentpage > 0 )
         {
            AV12CurrentPage_Grid = AV18GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
      }

      protected void S272( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
         bttLoadapplicationpermissions_Visible = 1;
         AssignProp(sPrefix, false, bttLoadapplicationpermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLoadapplicationpermissions_Visible), 5, 0), true);
      }

      protected void E173O2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV52Pgmname,  "Grid", ref  AV47GridConfiguration) ;
         AV47GridConfiguration.gxTpr_Freezecolumntitles = AV49FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV52Pgmname,  "Grid",  AV47GridConfiguration,  true) ;
         if ( AV35RowsPerPage_Grid != AV36GridSettingsRowsPerPage_Grid )
         {
            AV35RowsPerPage_Grid = AV36GridSettingsRowsPerPage_Grid;
            AssignAttri(sPrefix, false, "AV35RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV35RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV52Pgmname,  "Grid",  AV35RowsPerPage_Grid) ;
            AV12CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV50GenericFilter_PreviousValue_Grid, AV37PermissionAccessTypeDefault_PreviousValue, AV38PermissionTypeFilter_PreviousValue, AV9ApplicationId, AV28PermissionAccessTypeDefault, AV29PermissionTypeFilter, AV52Pgmname, AV12CurrentPage_Grid, AV46GenericFilter_Grid, AV21HasNextPage_Grid, AV47GridConfiguration, AV48ClassCollection_Grid, AV35RowsPerPage_Grid, AV23I_LoadCount_Grid, AV49FreezeColumnTitles_Grid, sPrefix) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection_Grid", AV48ClassCollection_Grid);
      }

      protected void S252( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E223O2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S242 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S252 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV44FilterTagsCollection_Grid", AV44FilterTagsCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47GridConfiguration", AV47GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48ClassCollection_Grid", AV48ClassCollection_Grid);
      }

      protected void E183O2( )
      {
         /* 'E_LoadApplicationPermissions' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_LOADAPPLICATIONPERMISSIONS' */
         S262 ();
         if (returnInSub) return;
      }

      protected void S262( )
      {
         /* 'U_LOADAPPLICATIONPERMISSIONS' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadapplicationpermissions(context ).execute(  AV9ApplicationId, out  AV26Messages) ;
         AV56GXV3 = 1;
         while ( AV56GXV3 <= AV26Messages.Count )
         {
            AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV26Messages.Item(AV56GXV3));
            GX_msglist.addItem(AV25Message.gxTpr_Description);
            AV56GXV3 = (int)(AV56GXV3+1);
         }
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV44FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV40K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PermissionAccessTypeDefault)) )
         {
            AV41K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "PermissionAccessTypeDefault";
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Description = cmbavPermissionaccesstypedefault.Caption;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV28PermissionAccessTypeDefault;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = context.GetMessage( GeneXus.Programs.genexussecuritycommon.gxdomaingampermissionaccesstypedefault.getDescription(context,AV28PermissionAccessTypeDefault), "");
            AV40K2BFilterValuesSDT_WebForm.Add(AV41K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PermissionTypeFilter)) )
         {
            AV41K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "PermissionTypeFilter";
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Description = cmbavPermissiontypefilter.Caption;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = false;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV29PermissionTypeFilter;
            AV41K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = context.GetMessage( GeneXus.Programs.genexussecuritycommon.gxdomaingampermissiontypefilter.getDescription(context,AV29PermissionTypeFilter), "");
            AV40K2BFilterValuesSDT_WebForm.Add(AV41K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = context.GetMessage( "K2BT_FilterSummaryEmptyState", "");
         ucFiltertagsusercontrol_grid.SendProperty(context, sPrefix, false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV40K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV44FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV52Pgmname,  "Filters",  AV40K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV44FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
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
         S282 ();
         if (returnInSub) return;
      }

      protected void S282( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV49FreezeColumnTitles_Grid = AV47GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV49FreezeColumnTitles_Grid", AV49FreezeColumnTitles_Grid);
         if ( AV49FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV48ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV48ClassCollection_Grid) ;
         }
      }

      protected void wb_table1_118_3O2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWApplicationPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_118_3O2e( true) ;
         }
         else
         {
            wb_table1_118_3O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9ApplicationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
         sCtrlAV9ApplicationId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wwapplicationpermission", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV9ApplicationId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
         }
         wcpOAV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9ApplicationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV9ApplicationId != wcpOAV9ApplicationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV9ApplicationId = AV9ApplicationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV9ApplicationId = cgiGet( sPrefix+"AV9ApplicationId_CTRL");
         if ( StringUtil.Len( sCtrlAV9ApplicationId) > 0 )
         {
            AV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9ApplicationId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
         }
         else
         {
            AV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9ApplicationId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3O2( ) ;
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
         WS3O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9ApplicationId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9ApplicationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9ApplicationId_CTRL", StringUtil.RTrim( sCtrlAV9ApplicationId));
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
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221325468", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("k2bfsg/wwapplicationpermission.js", "?202431221325471", false, true);
            context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1092( )
      {
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_109_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_109_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_109_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_109_idx;
         edtavUpdate_action_Internalname = sPrefix+"vUPDATE_ACTION_"+sGXsfl_109_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_109_fel_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_109_fel_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_109_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_109_fel_idx;
         edtavUpdate_action_Internalname = sPrefix+"vUPDATE_ACTION_"+sGXsfl_109_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         SubsflControlProps_1092( ) ;
         WB3O0( ) ;
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
            if ( ((int)((nGXsfl_109_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_109_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 110,'"+sPrefix+"',false,'"+sGXsfl_109_idx+"',109)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV27Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,110);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e233o2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 111,'"+sPrefix+"',false,'"+sGXsfl_109_idx+"',109)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV13Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 112,'"+sPrefix+"',false,'"+sGXsfl_109_idx+"',109)\"" : " ");
         if ( ( cmbavAccesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vACCESSTYPE_" + sGXsfl_109_idx;
            cmbavAccesstype.Name = GXCCtl;
            cmbavAccesstype.WebTags = "";
            cmbavAccesstype.addItem("A", context.GetMessage( "Allow", ""), 0);
            cmbavAccesstype.addItem("R", context.GetMessage( "Restricted", ""), 0);
            if ( cmbavAccesstype.ItemCount > 0 )
            {
               AV5AccessType = cmbavAccesstype.getValidValue(AV5AccessType);
               AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV5AccessType);
            }
         }
         /* ComboBox */
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccesstype,(string)cmbavAccesstype_Internalname,StringUtil.RTrim( AV5AccessType),(short)1,(string)cmbavAccesstype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavAccesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,112);\"" : " "),(string)"",(bool)true,(short)0});
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV5AccessType);
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Values", (string)(cmbavAccesstype.ToJavascriptSource()), !bGXsfl_109_Refreshing);
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 113,'"+sPrefix+"',false,'"+sGXsfl_109_idx+"',109)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV24Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,113);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 114,'"+sPrefix+"',false,'',109)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class");
         StyleString = "";
         AV42Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV42Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV53Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV42Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Update_Action)) ? AV53Update_action_GXI : context.PathToRelativeUrl( AV42Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Update",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUpdate_action_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e243o2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV42Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 115,'"+sPrefix+"',false,'',109)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV43Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV54Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Delete_Action)) ? AV54Delete_action_GXI : context.PathToRelativeUrl( AV43Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavDelete_action_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e253o2_client"+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV43Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3O2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         /* End function sendrow_1092 */
      }

      protected void init_web_controls( )
      {
         cmbavPermissionaccesstypedefault.Name = "vPERMISSIONACCESSTYPEDEFAULT";
         cmbavPermissionaccesstypedefault.WebTags = "";
         cmbavPermissionaccesstypedefault.addItem("", context.GetMessage( "GX_AllItems", ""), 0);
         cmbavPermissionaccesstypedefault.addItem("A", context.GetMessage( "Allow", ""), 0);
         cmbavPermissionaccesstypedefault.addItem("R", context.GetMessage( "Restricted", ""), 0);
         if ( cmbavPermissionaccesstypedefault.ItemCount > 0 )
         {
         }
         cmbavPermissiontypefilter.Name = "vPERMISSIONTYPEFILTER";
         cmbavPermissiontypefilter.WebTags = "";
         cmbavPermissiontypefilter.addItem("A", context.GetMessage( "All", ""), 0);
         cmbavPermissiontypefilter.addItem("F", context.GetMessage( "First level", ""), 0);
         cmbavPermissiontypefilter.addItem("P", context.GetMessage( "All parents", ""), 0);
         cmbavPermissiontypefilter.addItem("C", context.GetMessage( "All children", ""), 0);
         if ( cmbavPermissiontypefilter.ItemCount > 0 )
         {
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
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp(sPrefix, false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         GXCCtl = "vACCESSTYPE_" + sGXsfl_109_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", context.GetMessage( "Allow", ""), 0);
         cmbavAccesstype.addItem("R", context.GetMessage( "Restricted", ""), 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl109( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"109\">") ;
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
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_AccessType", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Id", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Dsc)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV5AccessType)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAccesstype.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24Id)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV42Update_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV43Delete_Action));
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
         edtavGenericfilter_grid_Internalname = sPrefix+"vGENERICFILTER_GRID";
         imgLayoutdefined_filtertoggle_combined_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID";
         divLayoutdefined_table1_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE1_GRID";
         Filtertagsusercontrol_grid_Internalname = sPrefix+"FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table5_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE5_GRID";
         cmbavPermissionaccesstypedefault_Internalname = sPrefix+"vPERMISSIONACCESSTYPEDEFAULT";
         divTable_container_permissionaccesstypedefault_Internalname = sPrefix+"TABLE_CONTAINER_PERMISSIONACCESSTYPEDEFAULT";
         cmbavPermissiontypefilter_Internalname = sPrefix+"vPERMISSIONTYPEFILTER";
         divTable_container_permissiontypefilter_Internalname = sPrefix+"TABLE_CONTAINER_PERMISSIONTYPEFILTER";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID";
         divLayoutdefined_combinedfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_COMBINEDFILTERLAYOUT_GRID";
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
         bttAdd_Internalname = sPrefix+"ADD";
         divActions_grid_topright_Internalname = sPrefix+"ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         bttLoadapplicationpermissions_Internalname = sPrefix+"LOADAPPLICATIONPERMISSIONS";
         divActions_grid_gridassociatedleft_Internalname = sPrefix+"ACTIONS_GRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_GRID";
         divLayoutdefined_section3_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_GRID";
         divLayoutdefined_section1_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_GRID";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavDsc_Internalname = sPrefix+"vDSC";
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE";
         edtavId_Internalname = sPrefix+"vID";
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
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavId_Enabled = 1;
         cmbavAccesstype_Jsonclick = "";
         cmbavAccesstype.Visible = -1;
         cmbavAccesstype.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Visible = -1;
         edtavDsc_Enabled = 1;
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
         bttLoadapplicationpermissions_Visible = 1;
         bttAdd_Visible = 1;
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         cmbavPermissiontypefilter_Jsonclick = "";
         cmbavPermissiontypefilter.Enabled = 1;
         cmbavPermissionaccesstypedefault_Jsonclick = "";
         cmbavPermissionaccesstypedefault.Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_grid_Visible = 1;
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         cmbavPermissiontypefilter.Caption = context.GetMessage( "K2BT_GAM_FilterBy", "");
         cmbavPermissionaccesstypedefault.Caption = context.GetMessage( "K2BT_GAM_DefaultAccess", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'sPrefix'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E133O1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E153O1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E243O2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV24Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV24Id',fld:'vID',pic:''},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E253O2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV24Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV24Id',fld:'vID',pic:''},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_ADD'","{handler:'E163O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E213O2',iparms:[{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV42Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV43Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV27Name',fld:'vNAME',pic:''},{av:'AV13Dsc',fld:'vDSC',pic:''},{av:'cmbavAccesstype'},{av:'AV5AccessType',fld:'vACCESSTYPE',pic:''},{av:'AV24Id',fld:'vID',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("VNAME.CLICK","{handler:'E233O2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV24Id',fld:'vID',pic:''}]");
         setEventMetadata("VNAME.CLICK",",oparms:[{av:'AV24Id',fld:'vID',pic:''},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E143O1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E123O1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV36GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E173O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV23I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV36GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV35RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV50GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV37PermissionAccessTypeDefault_PreviousValue',fld:'vPERMISSIONACCESSTYPEDEFAULT_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV38PermissionTypeFilter_PreviousValue',fld:'vPERMISSIONTYPEFILTER_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E223O2',iparms:[{av:'cmbavPermissionaccesstypedefault'},{av:'AV28PermissionAccessTypeDefault',fld:'vPERMISSIONACCESSTYPEDEFAULT',pic:''},{av:'cmbavPermissiontypefilter'},{av:'AV29PermissionTypeFilter',fld:'vPERMISSIONTYPEFILTER',pic:''},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV46GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV21HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV44FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV47GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{ctrl:'LOADAPPLICATIONPERMISSIONS',prop:'Visible'},{av:'AV49FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV48ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("'E_LOADAPPLICATIONPERMISSIONS'","{handler:'E183O2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_LOADAPPLICATIONPERMISSIONS'",",oparms:[]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK","{handler:'E113O1',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_GRID',prop:'Visible'}]}");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPEDEFAULT","{handler:'Validv_Permissionaccesstypedefault',iparms:[]");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPEDEFAULT",",oparms:[]}");
         setEventMetadata("VALIDV_PERMISSIONTYPEFILTER","{handler:'Validv_Permissiontypefilter',iparms:[]");
         setEventMetadata("VALIDV_PERMISSIONTYPEFILTER",",oparms:[]}");
         setEventMetadata("VALIDV_ACCESSTYPE","{handler:'Validv_Accesstype',iparms:[]");
         setEventMetadata("VALIDV_ACCESSTYPE",",oparms:[]}");
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
         AV50GenericFilter_PreviousValue_Grid = "";
         AV37PermissionAccessTypeDefault_PreviousValue = "";
         AV38PermissionTypeFilter_PreviousValue = "";
         AV28PermissionAccessTypeDefault = "";
         AV29PermissionTypeFilter = "";
         AV52Pgmname = "";
         AV46GenericFilter_Grid = "";
         AV47GridConfiguration = new SdtK2BGridConfiguration(context);
         AV48ClassCollection_Grid = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV45DeletedTag_Grid = "";
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
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
         bttAdd_Jsonclick = "";
         bttLoadapplicationpermissions_Jsonclick = "";
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27Name = "";
         AV13Dsc = "";
         AV5AccessType = "";
         AV24Id = "";
         AV42Update_Action = "";
         AV53Update_action_GXI = "";
         AV43Delete_Action = "";
         AV54Delete_action_GXI = "";
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV26Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV16Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV11AppPermissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV14Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV20GridStateKey = "";
         AV18GridState = new SdtK2BGridState(context);
         AV19GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV40K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV41K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV9ApplicationId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         AV52Pgmname = "K2BFSG.WWApplicationPermission";
         /* GeneXus formulas. */
         AV52Pgmname = "K2BFSG.WWApplicationPermission";
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12CurrentPage_Grid ;
      private short AV35RowsPerPage_Grid ;
      private short AV23I_LoadCount_Grid ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short AV36GridSettingsRowsPerPage_Grid ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int divLayoutdefined_filtercollapsiblesection_combined_grid_Visible ;
      private int nRC_GXsfl_109 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_109_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int edtavGenericfilter_grid_Enabled ;
      private int bttAdd_Visible ;
      private int bttLoadapplicationpermissions_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int AV51GXV1 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV55GXV2 ;
      private int AV56GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int edtavId_Visible ;
      private int edtavUpdate_action_Enabled ;
      private int edtavUpdate_action_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV9ApplicationId ;
      private long wcpOAV9ApplicationId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_109_idx="0001" ;
      private string AV50GenericFilter_PreviousValue_Grid ;
      private string AV37PermissionAccessTypeDefault_PreviousValue ;
      private string AV38PermissionTypeFilter_PreviousValue ;
      private string AV28PermissionAccessTypeDefault ;
      private string AV29PermissionTypeFilter ;
      private string AV52Pgmname ;
      private string AV46GenericFilter_Grid ;
      private string edtavName_Internalname ;
      private string edtavDsc_Internalname ;
      private string cmbavAccesstype_Internalname ;
      private string edtavId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV45DeletedTag_Grid ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
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
      private string divTable_container_permissionaccesstypedefault_Internalname ;
      private string cmbavPermissionaccesstypedefault_Internalname ;
      private string cmbavPermissionaccesstypedefault_Jsonclick ;
      private string divTable_container_permissiontypefilter_Internalname ;
      private string cmbavPermissiontypefilter_Internalname ;
      private string cmbavPermissiontypefilter_Jsonclick ;
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
      private string bttAdd_Internalname ;
      private string bttAdd_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divLayoutdefined_section1_grid_Internalname ;
      private string divLayoutdefined_section7_grid_Internalname ;
      private string divActions_grid_gridassociatedleft_Internalname ;
      private string bttLoadapplicationpermissions_Internalname ;
      private string bttLoadapplicationpermissions_Jsonclick ;
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
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27Name ;
      private string AV13Dsc ;
      private string AV5AccessType ;
      private string AV24Id ;
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
      private string sCtrlAV9ApplicationId ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string GXCCtl ;
      private string cmbavAccesstype_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21HasNextPage_Grid ;
      private bool AV49FreezeColumnTitles_Grid ;
      private bool bGXsfl_109_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV30Reload_Grid ;
      private bool AV15Exit_Grid ;
      private bool AV42Update_Action_IsBlob ;
      private bool AV43Delete_Action_IsBlob ;
      private string AV53Update_action_GXI ;
      private string AV54Delete_action_GXI ;
      private string AV20GridStateKey ;
      private string AV42Update_Action ;
      private string AV43Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_ApplicationId ;
      private GXCombobox cmbavPermissionaccesstypedefault ;
      private GXCombobox cmbavPermissiontypefilter ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private GXCombobox cmbavAccesstype ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV48ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV11AppPermissions ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV26Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV40K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV44FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV16Filter ;
      private SdtK2BGridState AV18GridState ;
      private SdtK2BGridState_FilterValue AV19GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV41K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV47GridConfiguration ;
   }

}
