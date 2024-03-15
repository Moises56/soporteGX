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
   public class wcauthenticationtypeentrysaml20 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcauthenticationtypeentrysaml20( )
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

      public wcauthenticationtypeentrysaml20( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_Name ,
                           ref string aP2_TypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV33Name = aP1_Name;
         this.AV41TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV33Name;
         aP2_TypeId=this.AV41TypeId;
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
         cmbavFunctionid = new GXCombobox();
         chkavIsenable = new GXCheckbox();
         chkavIsredirectbinding = new GXCheckbox();
         cmbavNameidpolicyformat = new GXCombobox();
         chkavForceauthn = new GXCheckbox();
         chkavDisablesinglelogout = new GXCheckbox();
         chkavUserinforesponseuserlastnamegenauto = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
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
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  AV33Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV33Name", AV33Name);
                  AV41TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV33Name,(string)AV41TypeId});
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
                  gxfirstwebparm = GetFirstPar( "Mode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Mode");
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
         nRC_GXsfl_304 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_304"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_304_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_304_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_304_idx = GetPar( "sGXsfl_304_idx");
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
         AV67CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV81Pgmname = GetPar( "Pgmname");
         AV69I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         AV20IsEnable = StringUtil.StrToBool( GetPar( "IsEnable"));
         AV21isRedirectBinding = StringUtil.StrToBool( GetPar( "isRedirectBinding"));
         AV15ForceAuthn = StringUtil.StrToBool( GetPar( "ForceAuthn"));
         AV74DisableSingleLogout = StringUtil.StrToBool( GetPar( "DisableSingleLogout"));
         AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( GetPar( "UserInfoResponseUserLastNameGenAuto"));
         AV45UserInfoResponseUserErrorDescriptionTag = GetPar( "UserInfoResponseUserErrorDescriptionTag");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV67CurrentPage_Grid, AV81Pgmname, AV69I_LoadCount_Grid, Gx_mode, AV20IsEnable, AV21isRedirectBinding, AV15ForceAuthn, AV74DisableSingleLogout, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
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
            PA3S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV81Pgmname = "K2BFSG.WCAuthenticationTypeEntrySaml20";
               edtavDynamicpropname_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_304_Refreshing);
               edtavDynamicproptag_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_304_Refreshing);
               WS3S2( ) ;
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
            context.SendWebValue( context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntrySaml", "")) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wcauthenticationtypeentrysaml20.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV33Name)),UrlEncode(StringUtil.RTrim(AV41TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV67CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV81Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV69I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", StringUtil.RTrim( AV45UserInfoResponseUserErrorDescriptionTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_304", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_304), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33Name", StringUtil.RTrim( wcpOAV33Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41TypeId", StringUtil.RTrim( wcpOAV41TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV67CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV81Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV69I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", StringUtil.RTrim( AV45UserInfoResponseUserErrorDescriptionTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV41TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, sPrefix+"ATTRIBUTES_Title", StringUtil.RTrim( Attributes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"ATTRIBUTES_Open", StringUtil.BoolToStr( Attributes_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"ATTRIBUTES_Showborders", StringUtil.BoolToStr( Attributes_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Attributes_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"LINESEPARATORCONTENT_ADVANCEDRESPONSECONFIGURATION_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_advancedresponseconfiguration_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3S2( )
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
         return "K2BFSG.WCAuthenticationTypeEntrySaml20" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntrySaml", "") ;
      }

      protected void WB3S0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wcauthenticationtypeentrysaml20.aspx");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
            /* User Defined Control */
            ucAttributes.SetProperty("Title", Attributes_Title);
            ucAttributes.SetProperty("Collapsible", Attributes_Collapsible);
            ucAttributes.SetProperty("Open", Attributes_Open);
            ucAttributes.SetProperty("ShowBorders", Attributes_Showborders);
            ucAttributes.SetProperty("ContainsEditableForm", Attributes_Containseditableform);
            ucAttributes.Render(context, "k2bt_component", Attributes_Internalname, sPrefix+"ATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"ATTRIBUTESContainer"+"Attributes_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributes_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "K2BT_GAM_Name", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV33Name), StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_functionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavFunctionid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFunctionid_Internalname, context.GetMessage( "K2BT_GAM_Function", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV16FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV16FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", (string)(cmbavFunctionid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavIsenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, context.GetMessage( "K2BT_GAM_Enabled?", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV20IsEnable), "", context.GetMessage( "K2BT_GAM_Enabled?", ""), 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(33, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,33);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_dsc_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, context.GetMessage( "K2BT_GAM_Description", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV10Dsc), StringUtil.RTrim( context.localUtil.Format( AV10Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_smallimagename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavSmallimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSmallimagename_Internalname, context.GetMessage( "K2BT_GAM_SmallImageName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV40SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV40SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_bigimagename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavBigimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBigimagename_Internalname, context.GetMessage( "K2BT_GAM_BigImageName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV7BigImageName), StringUtil.RTrim( context.localUtil.Format( AV7BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_impersonate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImpersonate_Internalname, context.GetMessage( "K2BT_GAM_Impersonate", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpersonate_Internalname, StringUtil.RTrim( AV19Impersonate), StringUtil.RTrim( context.localUtil.Format( AV19Impersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpersonate_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavImpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, sPrefix+"TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab_title_Internalname, context.GetMessage( "K2BT_General", ""), "", "", lblTab_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_localsiteurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavLocalsiteurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocalsiteurl_Internalname, context.GetMessage( "K2BT_GAM_LocalSiteURL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocalsiteurl_Internalname, AV31LocalSiteURL, StringUtil.RTrim( context.localUtil.Format( AV31LocalSiteURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocalsiteurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLocalsiteurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_serviceproviderentityid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavServiceproviderentityid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServiceproviderentityid_Internalname, context.GetMessage( "K2BT_GAM_ServiceProviderEntityID", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServiceproviderentityid_Internalname, AV38ServiceProviderEntityID, StringUtil.RTrim( context.localUtil.Format( AV38ServiceProviderEntityID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServiceproviderentityid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavServiceproviderentityid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_identityproviderentityid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavIdentityproviderentityid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIdentityproviderentityid_Internalname, context.GetMessage( "K2BT_GAM_IdentityProviderEntityID", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIdentityproviderentityid_Internalname, AV18IdentityProviderEntityID, StringUtil.RTrim( context.localUtil.Format( AV18IdentityProviderEntityID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIdentityproviderentityid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavIdentityproviderentityid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isredirectbinding_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavIsredirectbinding_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsredirectbinding_Internalname, context.GetMessage( "isRedirectBinding", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsredirectbinding_Internalname, StringUtil.BoolToStr( AV21isRedirectBinding), "", context.GetMessage( "isRedirectBinding", ""), 1, chkavIsredirectbinding.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(86, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,86);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpLogin_Internalname, context.GetMessage( "GXM_Login", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_login_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_samlendpointlocation_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavSamlendpointlocation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSamlendpointlocation_Internalname, context.GetMessage( "K2BT_GAM_SamlEndpointLocation", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSamlendpointlocation_Internalname, AV37SamlEndpointLocation, StringUtil.RTrim( context.localUtil.Format( AV37SamlEndpointLocation, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSamlendpointlocation_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSamlendpointlocation_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_nameidpolicyformat_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavNameidpolicyformat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNameidpolicyformat_Internalname, context.GetMessage( "K2BT_GAM_NameIDPolicyFormat", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNameidpolicyformat, cmbavNameidpolicyformat_Internalname, StringUtil.RTrim( AV73NameIDPolicyFormat), 1, cmbavNameidpolicyformat_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavNameidpolicyformat.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            cmbavNameidpolicyformat.CurrentValue = StringUtil.RTrim( AV73NameIDPolicyFormat);
            AssignProp(sPrefix, false, cmbavNameidpolicyformat_Internalname, "Values", (string)(cmbavNameidpolicyformat.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_forceauthn_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavForceauthn_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavForceauthn_Internalname, context.GetMessage( "K2BT_GAM_ForceAuthentication", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavForceauthn_Internalname, StringUtil.BoolToStr( AV15ForceAuthn), "", context.GetMessage( "K2BT_GAM_ForceAuthentication", ""), 1, chkavForceauthn.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authncontext_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthncontext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthncontext_Internalname, context.GetMessage( "K2BT_GAM_AuthenticationContext", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthncontext_Internalname, StringUtil.RTrim( AV6AuthnContext), StringUtil.RTrim( context.localUtil.Format( AV6AuthnContext, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthncontext_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthncontext_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpLogout_Internalname, context.GetMessage( "GXM_Logout", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_logout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_disablesinglelogout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavDisablesinglelogout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDisablesinglelogout_Internalname, context.GetMessage( "K2BT_GAM_DisableSingleLogout", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDisablesinglelogout_Internalname, StringUtil.BoolToStr( AV74DisableSingleLogout), "", context.GetMessage( "K2BT_GAM_DisableSingleLogout", ""), 1, chkavDisablesinglelogout.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,123);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_singlelogoutendpoint_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavSinglelogoutendpoint_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSinglelogoutendpoint_Internalname, context.GetMessage( "K2BT_GAM_SingleLogoutEndpoint", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSinglelogoutendpoint_Internalname, AV39SingleLogoutendpoint, StringUtil.RTrim( context.localUtil.Format( AV39SingleLogoutendpoint, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSinglelogoutendpoint_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSinglelogoutendpoint_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "K2BT_GAM_Credentials", ""), "", "", lblTab1_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpRequestcredentials_Internalname, context.GetMessage( "K2BT_GAM_RequestCredentials", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_requestcredentials_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_keystpathcredential_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystpathcredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystpathcredential_Internalname, context.GetMessage( "K2BT_GAM_KeyStorePath", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystpathcredential_Internalname, AV29KeyStPathCredential, StringUtil.RTrim( context.localUtil.Format( AV29KeyStPathCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystpathcredential_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystpathcredential_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_keystpwdcredential_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystpwdcredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystpwdcredential_Internalname, context.GetMessage( "K2BT_GAM_KeyStorePassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystpwdcredential_Internalname, StringUtil.RTrim( AV30KeyStPwdCredential), StringUtil.RTrim( context.localUtil.Format( AV30KeyStPwdCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystpwdcredential_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystpwdcredential_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_keyaliascredential_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeyaliascredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeyaliascredential_Internalname, context.GetMessage( "K2BT_GAM_CertificateAlias", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeyaliascredential_Internalname, StringUtil.RTrim( AV22KeyAliasCredential), StringUtil.RTrim( context.localUtil.Format( AV22KeyAliasCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeyaliascredential_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeyaliascredential_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_keystorecredential_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystorecredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorecredential_Internalname, context.GetMessage( "K2BT_GAM_KeyStoreFormat", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorecredential_Internalname, StringUtil.RTrim( AV25KeyStoreCredential), StringUtil.RTrim( context.localUtil.Format( AV25KeyStoreCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorecredential_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystorecredential_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpResponsecredentials_Internalname, context.GetMessage( "K2BT_GAM_ResponseCredentials", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_responsecredentials_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_keystorefilepathtrustcred_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystorefilepathtrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorefilepathtrustcred_Internalname, context.GetMessage( "K2BT_GAM_CertificatePath", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorefilepathtrustcred_Internalname, AV26KeyStoreFilePathTrustCred, StringUtil.RTrim( context.localUtil.Format( AV26KeyStoreFilePathTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorefilepathtrustcred_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystorefilepathtrustcred_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_advancedresponseconfiguration_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_advancedresponseconfiguration_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_advancedresponseconfiguration_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_advancedresponseconfiguration_Internalname, context.GetMessage( "K2BT_GAM_AdvancedResponseConfiguration", ""), "", "", lblLineseparatortitle_advancedresponseconfiguration_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113s1_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_advancedresponseconfiguration_Internalname, divLineseparatorcontent_advancedresponseconfiguration_Visible, 0, "px", 0, "px", divLineseparatorcontent_advancedresponseconfiguration_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_keystorepwdtrustcred_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystorepwdtrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorepwdtrustcred_Internalname, context.GetMessage( "K2BT_GAM_TrustStorePassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorepwdtrustcred_Internalname, StringUtil.RTrim( AV27KeyStorePwdTrustCred), StringUtil.RTrim( context.localUtil.Format( AV27KeyStorePwdTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorepwdtrustcred_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystorepwdtrustcred_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_keyaliastrustcred_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeyaliastrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeyaliastrustcred_Internalname, context.GetMessage( "K2BT_GAM_CertificateAlias", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeyaliastrustcred_Internalname, StringUtil.RTrim( AV23KeyAliasTrustCred), StringUtil.RTrim( context.localUtil.Format( AV23KeyAliasTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,190);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeyaliastrustcred_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeyaliastrustcred_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_keystoretrustcred_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavKeystoretrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystoretrustcred_Internalname, context.GetMessage( "K2BT_GAM_TrustStoreFormat", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystoretrustcred_Internalname, StringUtil.RTrim( AV28KeyStoreTrustCred), StringUtil.RTrim( context.localUtil.Format( AV28KeyStoreTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystoretrustcred_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavKeystoretrustcred_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, context.GetMessage( "K2BT_GAM_UserInformation", ""), "", "", lblTab2_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup1response_Internalname, context.GetMessage( "K2BT_GAM_Response", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group1response_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuseremailtag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuseremailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuseremailtag_Internalname, context.GetMessage( "K2BT_GAM_UserEmailTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuseremailtag_Internalname, StringUtil.RTrim( AV44UserInfoResponseUserEmailTag), StringUtil.RTrim( context.localUtil.Format( AV44UserInfoResponseUserEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuseremailtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuseremailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserexternalidtag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserexternalidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserexternalidtag_Internalname, context.GetMessage( "K2BT_GAM_ExternalIdTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserexternalidtag_Internalname, StringUtil.RTrim( AV46UserInfoResponseUserExternalIdTag), StringUtil.RTrim( context.localUtil.Format( AV46UserInfoResponseUserExternalIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,217);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserexternalidtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserexternalidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseusernametag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusernametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusernametag_Internalname, context.GetMessage( "K2BT_GAM_UserNameTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusernametag_Internalname, StringUtil.RTrim( AV53UserInfoResponseUserNameTag), StringUtil.RTrim( context.localUtil.Format( AV53UserInfoResponseUserNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,222);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusernametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusernametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserfirstnametag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserfirstnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserfirstnametag_Internalname, context.GetMessage( "K2BT_GAM_UserFirstNameTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserfirstnametag_Internalname, StringUtil.RTrim( AV47UserInfoResponseUserFirstNameTag), StringUtil.RTrim( context.localUtil.Format( AV47UserInfoResponseUserFirstNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,228);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserfirstnametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserfirstnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserlastnamegenauto_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUserinforesponseuserlastnamegenauto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinforesponseuserlastnamegenauto_Internalname, context.GetMessage( "K2BT_GAM_GenerateLastNameAutomatically", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 233,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinforesponseuserlastnamegenauto_Internalname, StringUtil.BoolToStr( AV51UserInfoResponseUserLastNameGenAuto), "", context.GetMessage( "K2BT_GAM_GenerateLastNameAutomatically", ""), 1, chkavUserinforesponseuserlastnamegenauto.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(233, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,233);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserlastnametag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_userinforesponseuserlastnametag_Internalname, context.GetMessage( "K2BT_GAM_UserLastNameTag", ""), "", "", lblTextblock_var_userinforesponseuserlastnametag_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserlastnametagcellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlastnametag_Internalname, context.GetMessage( "K2BT_GAM_UserLastNameTag", ""), "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 240,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlastnametag_Internalname, StringUtil.RTrim( AV52UserInfoResponseUserLastNameTag), StringUtil.RTrim( context.localUtil.Format( AV52UserInfoResponseUserLastNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,240);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlastnametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserlastnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbuserlastnamehelp_Internalname, "", "", "", lblTbuserlastnamehelp_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseusergendertag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendertag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendertag_Internalname, context.GetMessage( "K2BT_GAM_UserGenderTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 247,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendertag_Internalname, StringUtil.RTrim( AV48UserInfoResponseUserGenderTag), StringUtil.RTrim( context.localUtil.Format( AV48UserInfoResponseUserGenderTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,247);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendertag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusergendertag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseusergendervalues_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendervalues_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendervalues_Internalname, context.GetMessage( "K2BT_GAM_GenderValues", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendervalues_Internalname, AV49UserInfoResponseUserGenderValues, StringUtil.RTrim( context.localUtil.Format( AV49UserInfoResponseUserGenderValues, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,252);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendervalues_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusergendervalues_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserbirthdaytag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserbirthdaytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserbirthdaytag_Internalname, context.GetMessage( "K2BT_GAM_UserBirthdayTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserbirthdaytag_Internalname, StringUtil.RTrim( AV43UserInfoResponseUserBirthdayTag), StringUtil.RTrim( context.localUtil.Format( AV43UserInfoResponseUserBirthdayTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,258);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserbirthdaytag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserbirthdaytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserurlimagetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlimagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlimagetag_Internalname, context.GetMessage( "K2BT_GAM_UserURLImageTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 263,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlimagetag_Internalname, StringUtil.RTrim( AV55UserInfoResponseUserURLImageTag), StringUtil.RTrim( context.localUtil.Format( AV55UserInfoResponseUserURLImageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,263);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlimagetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserurlimagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserurlprofiletag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlprofiletag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlprofiletag_Internalname, context.GetMessage( "K2BT_GAM_UserURLProfileTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlprofiletag_Internalname, StringUtil.RTrim( AV56UserInfoResponseUserURLProfileTag), StringUtil.RTrim( context.localUtil.Format( AV56UserInfoResponseUserURLProfileTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,269);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlprofiletag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserurlprofiletag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserlanguagetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserlanguagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlanguagetag_Internalname, context.GetMessage( "K2BT_GAM_UserLanguageTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlanguagetag_Internalname, StringUtil.RTrim( AV50UserInfoResponseUserLanguageTag), StringUtil.RTrim( context.localUtil.Format( AV50UserInfoResponseUserLanguageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,274);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlanguagetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserlanguagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseusertimezonetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusertimezonetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusertimezonetag_Internalname, context.GetMessage( "K2BT_GAM_UserTimezoneTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 280,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusertimezonetag_Internalname, StringUtil.RTrim( AV54UserInfoResponseUserTimeZoneTag), StringUtil.RTrim( context.localUtil.Format( AV54UserInfoResponseUserTimeZoneTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,280);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusertimezonetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusertimezonetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseerrordescriptiontag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseerrordescriptiontag_Internalname, context.GetMessage( "K2BT_GAM_ErrorDescriptionTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'" + sPrefix + "',false,'" + sGXsfl_304_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV42UserInfoResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV42UserInfoResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,285);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseerrordescriptiontag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroupcustomuserattributes_Internalname, context.GetMessage( "K2BT_GAM_CustomUserAttributes", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_groupcustomuserattributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl304( ) ;
         }
         if ( wbEnd == 304 )
         {
            wbEnd = 0;
            nRC_GXsfl_304 = (int)(nGXsfl_304_idx-1);
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
            wb_table1_310_3S2( true) ;
         }
         else
         {
            wb_table1_310_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_310_3S2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 317,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(304), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_MultipleFilterAdd", ""), bttBtnadd_Jsonclick, 5, "", "", StyleString, ClassString, bttBtnadd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_BTNADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 325,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(304), 3, 0)+","+"null"+");", bttBtnconfirm_Caption, bttBtnconfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttBtnconfirm_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_BTNCONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 327,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(304), 3, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e123s1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
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
         if ( wbEnd == 304 )
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

      protected void START3S2( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntrySaml", ""), 0) ;
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
               STRUP3S0( ) ;
            }
         }
      }

      protected void WS3S2( )
      {
         START3S2( ) ;
         EVT3S2( ) ;
      }

      protected void EVT3S2( )
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
                                 STRUP3S0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_BTNADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_BtnAdd' */
                                    E133S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_BTNCONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_BtnConfirm' */
                                    E143S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDynamicpropname_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_BTNDELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_BTNDELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3S0( ) ;
                              }
                              nGXsfl_304_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_304_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_idx), 4, 0), 4, "0");
                              SubsflControlProps_3042( ) ;
                              AV11DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
                              AV12DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
                              AV75BtnDelete_Action = cgiGet( edtavBtndelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action)) ? AV80Btndelete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV75BtnDelete_Action))), !bGXsfl_304_Refreshing);
                              AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV75BtnDelete_Action), true);
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
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E153S2 ();
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
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E163S2 ();
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
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E173S2 ();
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
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E183S2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_BTNDELETE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_BtnDelete' */
                                          E193S2 ();
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
                                       STRUP3S0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
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

      protected void WE3S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3S2( ) ;
            }
         }
      }

      protected void PA3S2( )
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
               GX_FocusControl = cmbavFunctionid_Internalname;
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
         SubsflControlProps_3042( ) ;
         while ( nGXsfl_304_idx <= nRC_GXsfl_304 )
         {
            sendrow_3042( ) ;
            nGXsfl_304_idx = ((subGrid_Islastpage==1)&&(nGXsfl_304_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_304_idx+1);
            sGXsfl_304_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_idx), 4, 0), 4, "0");
            SubsflControlProps_3042( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( short AV67CurrentPage_Grid ,
                                       string AV81Pgmname ,
                                       short AV69I_LoadCount_Grid ,
                                       string Gx_mode ,
                                       bool AV20IsEnable ,
                                       bool AV21isRedirectBinding ,
                                       bool AV15ForceAuthn ,
                                       bool AV74DisableSingleLogout ,
                                       bool AV51UserInfoResponseUserLastNameGenAuto ,
                                       string AV45UserInfoResponseUserErrorDescriptionTag ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3S2( ) ;
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
         if ( cmbavFunctionid.ItemCount > 0 )
         {
            AV16FunctionId = cmbavFunctionid.getValidValue(AV16FunctionId);
            AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV16FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV20IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV20IsEnable));
         AssignAttri(sPrefix, false, "AV20IsEnable", AV20IsEnable);
         AV21isRedirectBinding = StringUtil.StrToBool( StringUtil.BoolToStr( AV21isRedirectBinding));
         AssignAttri(sPrefix, false, "AV21isRedirectBinding", AV21isRedirectBinding);
         if ( cmbavNameidpolicyformat.ItemCount > 0 )
         {
            AV73NameIDPolicyFormat = cmbavNameidpolicyformat.getValidValue(AV73NameIDPolicyFormat);
            AssignAttri(sPrefix, false, "AV73NameIDPolicyFormat", AV73NameIDPolicyFormat);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNameidpolicyformat.CurrentValue = StringUtil.RTrim( AV73NameIDPolicyFormat);
            AssignProp(sPrefix, false, cmbavNameidpolicyformat_Internalname, "Values", cmbavNameidpolicyformat.ToJavascriptSource(), true);
         }
         AV15ForceAuthn = StringUtil.StrToBool( StringUtil.BoolToStr( AV15ForceAuthn));
         AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
         AV74DisableSingleLogout = StringUtil.StrToBool( StringUtil.BoolToStr( AV74DisableSingleLogout));
         AssignAttri(sPrefix, false, "AV74DisableSingleLogout", AV74DisableSingleLogout);
         AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( StringUtil.BoolToStr( AV51UserInfoResponseUserLastNameGenAuto));
         AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E163S2 ();
         RF3S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV81Pgmname = "K2BFSG.WCAuthenticationTypeEntrySaml20";
         edtavDynamicpropname_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicproptag_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_304_Refreshing);
      }

      protected void RF3S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 304;
         /* Execute user event: Refresh */
         E163S2 ();
         E173S2 ();
         nGXsfl_304_idx = 1;
         sGXsfl_304_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_idx), 4, 0), 4, "0");
         SubsflControlProps_3042( ) ;
         bGXsfl_304_Refreshing = true;
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
            SubsflControlProps_3042( ) ;
            E183S2 ();
            wbEnd = 304;
            WB3S0( ) ;
         }
         bGXsfl_304_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3S2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV67CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV81Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV81Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV69I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", StringUtil.RTrim( AV45UserInfoResponseUserErrorDescriptionTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
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
         AV81Pgmname = "K2BFSG.WCAuthenticationTypeEntrySaml20";
         edtavDynamicpropname_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicproptag_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_304_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_304 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_304"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV33Name = cgiGet( sPrefix+"wcpOAV33Name");
            wcpOAV41TypeId = cgiGet( sPrefix+"wcpOAV41TypeId");
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( sPrefix+"TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"TABS_Historymanagement"));
            Attributes_Title = cgiGet( sPrefix+"ATTRIBUTES_Title");
            Attributes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"ATTRIBUTES_Collapsible"));
            Attributes_Open = StringUtil.StrToBool( cgiGet( sPrefix+"ATTRIBUTES_Open"));
            Attributes_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"ATTRIBUTES_Showborders"));
            Attributes_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV33Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV33Name", AV33Name);
            }
            cmbavFunctionid.Name = cmbavFunctionid_Internalname;
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV16FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
            AV20IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV20IsEnable", AV20IsEnable);
            AV10Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV10Dsc", AV10Dsc);
            AV40SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV40SmallImageName", AV40SmallImageName);
            AV7BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV7BigImageName", AV7BigImageName);
            AV19Impersonate = cgiGet( edtavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV19Impersonate", AV19Impersonate);
            AV31LocalSiteURL = cgiGet( edtavLocalsiteurl_Internalname);
            AssignAttri(sPrefix, false, "AV31LocalSiteURL", AV31LocalSiteURL);
            AV38ServiceProviderEntityID = cgiGet( edtavServiceproviderentityid_Internalname);
            AssignAttri(sPrefix, false, "AV38ServiceProviderEntityID", AV38ServiceProviderEntityID);
            AV18IdentityProviderEntityID = cgiGet( edtavIdentityproviderentityid_Internalname);
            AssignAttri(sPrefix, false, "AV18IdentityProviderEntityID", AV18IdentityProviderEntityID);
            AV21isRedirectBinding = StringUtil.StrToBool( cgiGet( chkavIsredirectbinding_Internalname));
            AssignAttri(sPrefix, false, "AV21isRedirectBinding", AV21isRedirectBinding);
            AV37SamlEndpointLocation = cgiGet( edtavSamlendpointlocation_Internalname);
            AssignAttri(sPrefix, false, "AV37SamlEndpointLocation", AV37SamlEndpointLocation);
            cmbavNameidpolicyformat.Name = cmbavNameidpolicyformat_Internalname;
            cmbavNameidpolicyformat.CurrentValue = cgiGet( cmbavNameidpolicyformat_Internalname);
            AV73NameIDPolicyFormat = cgiGet( cmbavNameidpolicyformat_Internalname);
            AssignAttri(sPrefix, false, "AV73NameIDPolicyFormat", AV73NameIDPolicyFormat);
            AV15ForceAuthn = StringUtil.StrToBool( cgiGet( chkavForceauthn_Internalname));
            AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
            AV6AuthnContext = cgiGet( edtavAuthncontext_Internalname);
            AssignAttri(sPrefix, false, "AV6AuthnContext", AV6AuthnContext);
            AV74DisableSingleLogout = StringUtil.StrToBool( cgiGet( chkavDisablesinglelogout_Internalname));
            AssignAttri(sPrefix, false, "AV74DisableSingleLogout", AV74DisableSingleLogout);
            AV39SingleLogoutendpoint = cgiGet( edtavSinglelogoutendpoint_Internalname);
            AssignAttri(sPrefix, false, "AV39SingleLogoutendpoint", AV39SingleLogoutendpoint);
            AV29KeyStPathCredential = cgiGet( edtavKeystpathcredential_Internalname);
            AssignAttri(sPrefix, false, "AV29KeyStPathCredential", AV29KeyStPathCredential);
            AV30KeyStPwdCredential = cgiGet( edtavKeystpwdcredential_Internalname);
            AssignAttri(sPrefix, false, "AV30KeyStPwdCredential", AV30KeyStPwdCredential);
            AV22KeyAliasCredential = cgiGet( edtavKeyaliascredential_Internalname);
            AssignAttri(sPrefix, false, "AV22KeyAliasCredential", AV22KeyAliasCredential);
            AV25KeyStoreCredential = cgiGet( edtavKeystorecredential_Internalname);
            AssignAttri(sPrefix, false, "AV25KeyStoreCredential", AV25KeyStoreCredential);
            AV26KeyStoreFilePathTrustCred = cgiGet( edtavKeystorefilepathtrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV26KeyStoreFilePathTrustCred", AV26KeyStoreFilePathTrustCred);
            AV27KeyStorePwdTrustCred = cgiGet( edtavKeystorepwdtrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV27KeyStorePwdTrustCred", AV27KeyStorePwdTrustCred);
            AV23KeyAliasTrustCred = cgiGet( edtavKeyaliastrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV23KeyAliasTrustCred", AV23KeyAliasTrustCred);
            AV28KeyStoreTrustCred = cgiGet( edtavKeystoretrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV28KeyStoreTrustCred", AV28KeyStoreTrustCred);
            AV44UserInfoResponseUserEmailTag = cgiGet( edtavUserinforesponseuseremailtag_Internalname);
            AssignAttri(sPrefix, false, "AV44UserInfoResponseUserEmailTag", AV44UserInfoResponseUserEmailTag);
            AV46UserInfoResponseUserExternalIdTag = cgiGet( edtavUserinforesponseuserexternalidtag_Internalname);
            AssignAttri(sPrefix, false, "AV46UserInfoResponseUserExternalIdTag", AV46UserInfoResponseUserExternalIdTag);
            AV53UserInfoResponseUserNameTag = cgiGet( edtavUserinforesponseusernametag_Internalname);
            AssignAttri(sPrefix, false, "AV53UserInfoResponseUserNameTag", AV53UserInfoResponseUserNameTag);
            AV47UserInfoResponseUserFirstNameTag = cgiGet( edtavUserinforesponseuserfirstnametag_Internalname);
            AssignAttri(sPrefix, false, "AV47UserInfoResponseUserFirstNameTag", AV47UserInfoResponseUserFirstNameTag);
            AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( cgiGet( chkavUserinforesponseuserlastnamegenauto_Internalname));
            AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
            AV52UserInfoResponseUserLastNameTag = cgiGet( edtavUserinforesponseuserlastnametag_Internalname);
            AssignAttri(sPrefix, false, "AV52UserInfoResponseUserLastNameTag", AV52UserInfoResponseUserLastNameTag);
            AV48UserInfoResponseUserGenderTag = cgiGet( edtavUserinforesponseusergendertag_Internalname);
            AssignAttri(sPrefix, false, "AV48UserInfoResponseUserGenderTag", AV48UserInfoResponseUserGenderTag);
            AV49UserInfoResponseUserGenderValues = cgiGet( edtavUserinforesponseusergendervalues_Internalname);
            AssignAttri(sPrefix, false, "AV49UserInfoResponseUserGenderValues", AV49UserInfoResponseUserGenderValues);
            AV43UserInfoResponseUserBirthdayTag = cgiGet( edtavUserinforesponseuserbirthdaytag_Internalname);
            AssignAttri(sPrefix, false, "AV43UserInfoResponseUserBirthdayTag", AV43UserInfoResponseUserBirthdayTag);
            AV55UserInfoResponseUserURLImageTag = cgiGet( edtavUserinforesponseuserurlimagetag_Internalname);
            AssignAttri(sPrefix, false, "AV55UserInfoResponseUserURLImageTag", AV55UserInfoResponseUserURLImageTag);
            AV56UserInfoResponseUserURLProfileTag = cgiGet( edtavUserinforesponseuserurlprofiletag_Internalname);
            AssignAttri(sPrefix, false, "AV56UserInfoResponseUserURLProfileTag", AV56UserInfoResponseUserURLProfileTag);
            AV50UserInfoResponseUserLanguageTag = cgiGet( edtavUserinforesponseuserlanguagetag_Internalname);
            AssignAttri(sPrefix, false, "AV50UserInfoResponseUserLanguageTag", AV50UserInfoResponseUserLanguageTag);
            AV54UserInfoResponseUserTimeZoneTag = cgiGet( edtavUserinforesponseusertimezonetag_Internalname);
            AssignAttri(sPrefix, false, "AV54UserInfoResponseUserTimeZoneTag", AV54UserInfoResponseUserTimeZoneTag);
            AV42UserInfoResponseErrorDescriptionTag = cgiGet( edtavUserinforesponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV42UserInfoResponseErrorDescriptionTag", AV42UserInfoResponseErrorDescriptionTag);
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
         E153S2 ();
         if (returnInSub) return;
      }

      protected void E153S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV79GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV78GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV78GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV79GXV2 <= AV78GXV1.Count )
         {
            AV76ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV78GXV1.Item(AV79GXV2));
            this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {AV76ActivityLogProperty.gxTpr_Attributename,AV76ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV79GXV2 = (int)(AV79GXV2+1);
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S222 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S112 ();
         if (returnInSub) return;
         divLineseparatorcontent_advancedresponseconfiguration_Visible = 0;
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedresponseconfiguration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_advancedresponseconfiguration_Visible), 5, 0), true);
         divLineseparatorcontent_advancedresponseconfiguration_Class = "Section_LineSeparatorContentClose";
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedresponseconfiguration_Internalname, "Class", divLineseparatorcontent_advancedresponseconfiguration_Class, true);
         divLineseparatorheader_advancedresponseconfiguration_Class = "Section_LineSeparatorClose";
         AssignProp(sPrefix, false, divLineseparatorheader_advancedresponseconfiguration_Internalname, "Class", divLineseparatorheader_advancedresponseconfiguration_Class, true);
         subGrid_Backcolorstyle = 3;
      }

      protected void E163S2( )
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
         if ( (0==AV67CurrentPage_Grid) )
         {
            AV67CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV67CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV67CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV67CurrentPage_Grid), "ZZZ9"), context));
         }
         AV68Reload_Grid = true;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S222( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'INITAUTHENTICATIONSAML' */
         S232 ();
         if (returnInSub) return;
         AV16FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               bttBtnconfirm_Visible = 0;
               AssignProp(sPrefix, false, bttBtnconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnconfirm_Visible), 5, 0), true);
            }
            bttBtnadd_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadd_Visible), 5, 0), true);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavSmallimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavSmallimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSmallimagename_Enabled), 5, 0), true);
            edtavBigimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavBigimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBigimagename_Enabled), 5, 0), true);
            edtavImpersonate_Enabled = 0;
            AssignProp(sPrefix, false, edtavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImpersonate_Enabled), 5, 0), true);
            bttBtnconfirm_Caption = context.GetMessage( "Delete", "");
            AssignProp(sPrefix, false, bttBtnconfirm_Internalname, "Caption", bttBtnconfirm_Caption, true);
            edtavServiceproviderentityid_Enabled = 0;
            AssignProp(sPrefix, false, edtavServiceproviderentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavServiceproviderentityid_Enabled), 5, 0), true);
            edtavIdentityproviderentityid_Enabled = 0;
            AssignProp(sPrefix, false, edtavIdentityproviderentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIdentityproviderentityid_Enabled), 5, 0), true);
            edtavSamlendpointlocation_Enabled = 0;
            AssignProp(sPrefix, false, edtavSamlendpointlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSamlendpointlocation_Enabled), 5, 0), true);
            edtavSinglelogoutendpoint_Enabled = 0;
            AssignProp(sPrefix, false, edtavSinglelogoutendpoint_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSinglelogoutendpoint_Enabled), 5, 0), true);
            chkavDisablesinglelogout.Enabled = 0;
            AssignProp(sPrefix, false, chkavDisablesinglelogout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDisablesinglelogout.Enabled), 5, 0), true);
            edtavLocalsiteurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavLocalsiteurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocalsiteurl_Enabled), 5, 0), true);
            edtavKeystpathcredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystpathcredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystpathcredential_Enabled), 5, 0), true);
            edtavKeystpwdcredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystpwdcredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystpwdcredential_Enabled), 5, 0), true);
            edtavKeyaliascredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeyaliascredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeyaliascredential_Enabled), 5, 0), true);
            edtavKeystorecredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorecredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorecredential_Enabled), 5, 0), true);
            edtavKeystorefilepathtrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorefilepathtrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorefilepathtrustcred_Enabled), 5, 0), true);
            edtavKeystorepwdtrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorepwdtrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorepwdtrustcred_Enabled), 5, 0), true);
            edtavKeyaliastrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeyaliastrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeyaliastrustcred_Enabled), 5, 0), true);
            edtavKeystoretrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystoretrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystoretrustcred_Enabled), 5, 0), true);
            chkavIsredirectbinding.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsredirectbinding_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsredirectbinding.Enabled), 5, 0), true);
            chkavForceauthn.Enabled = 0;
            AssignProp(sPrefix, false, chkavForceauthn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavForceauthn.Enabled), 5, 0), true);
            edtavAuthncontext_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthncontext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthncontext_Enabled), 5, 0), true);
            cmbavNameidpolicyformat.Enabled = 0;
            AssignProp(sPrefix, false, cmbavNameidpolicyformat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNameidpolicyformat.Enabled), 5, 0), true);
            edtavUserinforesponseuserbirthdaytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserbirthdaytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserbirthdaytag_Enabled), 5, 0), true);
            edtavUserinforesponseuseremailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuseremailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuseremailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserexternalidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserexternalidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserexternalidtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserfirstnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserfirstnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserfirstnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendertag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendertag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendertag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendervalues_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendervalues_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendervalues_Enabled), 5, 0), true);
            edtavUserinforesponseuserlanguagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlanguagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlanguagetag_Enabled), 5, 0), true);
            chkavUserinforesponseuserlastnamegenauto.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinforesponseuserlastnamegenauto.Enabled), 5, 0), true);
            edtavUserinforesponseuserlastnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusernametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusernametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusernametag_Enabled), 5, 0), true);
            edtavUserinforesponseusertimezonetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusertimezonetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusertimezonetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlimagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlimagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlimagetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlprofiletag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlprofiletag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlprofiletag_Enabled), 5, 0), true);
            edtavUserinforesponseerrordescriptiontag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseerrordescriptiontag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseerrordescriptiontag_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E173S2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S142 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E183S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV69I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV69I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV69I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV69I_LoadCount_Grid), "ZZZ9"), context));
         AV70Exit_Grid = false;
         while ( true )
         {
            AV69I_LoadCount_Grid = (short)(AV69I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV69I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV69I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV69I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S162 ();
            if (returnInSub) return;
            edtavBtndelete_action_gximage = "K2BActionDelete";
            AV75BtnDelete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavBtndelete_action_Internalname, AV75BtnDelete_Action);
            AV80Btndelete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavBtndelete_action_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S172 ();
            if (returnInSub) return;
            if ( AV70Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 304;
            }
            sendrow_3042( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_304_Refreshing )
            {
               context.DoAjaxLoad(304, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV69I_LoadCount_Grid == 1 )
         {
            AV71SDT = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserproperties;
         }
         if ( AV71SDT.Count >= AV69I_LoadCount_Grid )
         {
            AV11DynamicPropName = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV71SDT.Item(AV69I_LoadCount_Grid)).gxTpr_Id;
            AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
            AV12DynamicPropTag = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV71SDT.Item(AV69I_LoadCount_Grid)).gxTpr_Value;
            AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtavBtndelete_action_Visible = 0;
               AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtndelete_action_Visible), 5, 0), !bGXsfl_304_Refreshing);
               edtavDynamicpropname_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_304_Refreshing);
               edtavDynamicproptag_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_304_Refreshing);
            }
         }
         else
         {
            AV70Exit_Grid = true;
         }
      }

      protected void S172( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV63GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV81Pgmname,  AV63GridStateKey, out  AV64GridState) ;
         AV64GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV81Pgmname,  AV63GridStateKey,  AV64GridState) ;
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV63GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV81Pgmname,  AV63GridStateKey, out  AV64GridState) ;
      }

      protected void E193S2( )
      {
         /* 'E_BtnDelete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNDELETE' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeSaml20", AV5AuthenticationTypeSaml20);
      }

      protected void S182( )
      {
         /* 'U_BTNDELETE' Routine */
         returnInSub = false;
         edtavBtndelete_action_Visible = 0;
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtndelete_action_Visible), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicpropname_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicproptag_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_304_Refreshing);
         AV11DynamicPropName = "";
         AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
         AV12DynamicPropTag = "";
         AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
         AV5AuthenticationTypeSaml20.gxTpr_Name = AV33Name;
         AV5AuthenticationTypeSaml20.removeuserinfoproperty( AV11DynamicPropName, out  AV14Errors);
      }

      protected void E133S2( )
      {
         /* 'E_BtnAdd' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNADD' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_BTNADD' Routine */
         returnInSub = false;
         edtavBtndelete_action_gximage = "K2BActionDelete";
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "gximage", edtavBtndelete_action_gximage, !bGXsfl_304_Refreshing);
         AV75BtnDelete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action)) ? AV80Btndelete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV75BtnDelete_Action))), !bGXsfl_304_Refreshing);
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV75BtnDelete_Action), true);
         AV80Btndelete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action)) ? AV80Btndelete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV75BtnDelete_Action))), !bGXsfl_304_Refreshing);
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV75BtnDelete_Action), true);
         edtavBtndelete_action_Visible = 1;
         AssignProp(sPrefix, false, edtavBtndelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtndelete_action_Visible), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicpropname_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicpropname_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicproptag_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_304_Refreshing);
         edtavDynamicproptag_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_304_Refreshing);
         sendrow_3042( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_304_Refreshing )
         {
            context.DoAjaxLoad(304, GridRow);
         }
      }

      protected void E143S2( )
      {
         /* 'E_BtnConfirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNCONFIRM' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeSaml20", AV5AuthenticationTypeSaml20);
      }

      protected void S202( )
      {
         /* 'U_BTNCONFIRM' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'SAVEAUTHENTICATIONSAML' */
            S242 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV5AuthenticationTypeSaml20.load( AV33Name);
            AV5AuthenticationTypeSaml20.delete();
         }
         if ( AV5AuthenticationTypeSaml20.success() && ( AV14Errors.Count == 0 ) )
         {
            context.CommitDataStores("k2bfsg.wcauthenticationtypeentrysaml20",pr_default);
            CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV14Errors = AV5AuthenticationTypeSaml20.geterrors();
            AV82GXV3 = 1;
            while ( AV82GXV3 <= AV14Errors.Count )
            {
               AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV82GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV82GXV3 = (int)(AV82GXV3+1);
            }
         }
      }

      protected void S212( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S232( )
      {
         /* 'INITAUTHENTICATIONSAML' Routine */
         returnInSub = false;
         AV5AuthenticationTypeSaml20.load( AV33Name);
         AV33Name = AV5AuthenticationTypeSaml20.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV33Name", AV33Name);
         AV20IsEnable = AV5AuthenticationTypeSaml20.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV20IsEnable", AV20IsEnable);
         AV10Dsc = AV5AuthenticationTypeSaml20.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV10Dsc", AV10Dsc);
         AV40SmallImageName = AV5AuthenticationTypeSaml20.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV40SmallImageName", AV40SmallImageName);
         AV7BigImageName = AV5AuthenticationTypeSaml20.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV7BigImageName", AV7BigImageName);
         AV19Impersonate = AV5AuthenticationTypeSaml20.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV19Impersonate", AV19Impersonate);
         AV38ServiceProviderEntityID = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Serviceproviderentityid;
         AssignAttri(sPrefix, false, "AV38ServiceProviderEntityID", AV38ServiceProviderEntityID);
         AV18IdentityProviderEntityID = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Identityproviderentityid;
         AssignAttri(sPrefix, false, "AV18IdentityProviderEntityID", AV18IdentityProviderEntityID);
         AV6AuthnContext = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Authncontext;
         AssignAttri(sPrefix, false, "AV6AuthnContext", AV6AuthnContext);
         AV73NameIDPolicyFormat = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Nameidpolicyformat;
         AssignAttri(sPrefix, false, "AV73NameIDPolicyFormat", AV73NameIDPolicyFormat);
         AV21isRedirectBinding = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Isredirectbinding;
         AssignAttri(sPrefix, false, "AV21isRedirectBinding", AV21isRedirectBinding);
         AV15ForceAuthn = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Forceauthn;
         AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
         AV22KeyAliasCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliascredential;
         AssignAttri(sPrefix, false, "AV22KeyAliasCredential", AV22KeyAliasCredential);
         AV23KeyAliasTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliastrustcred;
         AssignAttri(sPrefix, false, "AV23KeyAliasTrustCred", AV23KeyAliasTrustCred);
         AV25KeyStoreCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorecredential;
         AssignAttri(sPrefix, false, "AV25KeyStoreCredential", AV25KeyStoreCredential);
         AV26KeyStoreFilePathTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorefilepathtrustcred;
         AssignAttri(sPrefix, false, "AV26KeyStoreFilePathTrustCred", AV26KeyStoreFilePathTrustCred);
         AV27KeyStorePwdTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorepwdtrustcred;
         AssignAttri(sPrefix, false, "AV27KeyStorePwdTrustCred", AV27KeyStorePwdTrustCred);
         AV28KeyStoreTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystoretrustcred;
         AssignAttri(sPrefix, false, "AV28KeyStoreTrustCred", AV28KeyStoreTrustCred);
         AV29KeyStPathCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpathcredential;
         AssignAttri(sPrefix, false, "AV29KeyStPathCredential", AV29KeyStPathCredential);
         AV30KeyStPwdCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpwdcredential;
         AssignAttri(sPrefix, false, "AV30KeyStPwdCredential", AV30KeyStPwdCredential);
         AV37SamlEndpointLocation = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Samlendpointlocation;
         AssignAttri(sPrefix, false, "AV37SamlEndpointLocation", AV37SamlEndpointLocation);
         AV31LocalSiteURL = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Localsiteurl;
         AssignAttri(sPrefix, false, "AV31LocalSiteURL", AV31LocalSiteURL);
         AV74DisableSingleLogout = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Disablesinglelogout;
         AssignAttri(sPrefix, false, "AV74DisableSingleLogout", AV74DisableSingleLogout);
         AV39SingleLogoutendpoint = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Singlelogoutendpoint;
         AssignAttri(sPrefix, false, "AV39SingleLogoutendpoint", AV39SingleLogoutendpoint);
         AV45UserInfoResponseUserErrorDescriptionTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV45UserInfoResponseUserErrorDescriptionTag", AV45UserInfoResponseUserErrorDescriptionTag);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         AV43UserInfoResponseUserBirthdayTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name;
         AssignAttri(sPrefix, false, "AV43UserInfoResponseUserBirthdayTag", AV43UserInfoResponseUserBirthdayTag);
         AV44UserInfoResponseUserEmailTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuseremail_name;
         AssignAttri(sPrefix, false, "AV44UserInfoResponseUserEmailTag", AV44UserInfoResponseUserEmailTag);
         AV46UserInfoResponseUserExternalIdTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name;
         AssignAttri(sPrefix, false, "AV46UserInfoResponseUserExternalIdTag", AV46UserInfoResponseUserExternalIdTag);
         AV47UserInfoResponseUserFirstNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name;
         AssignAttri(sPrefix, false, "AV47UserInfoResponseUserFirstNameTag", AV47UserInfoResponseUserFirstNameTag);
         AV48UserInfoResponseUserGenderTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_name;
         AssignAttri(sPrefix, false, "AV48UserInfoResponseUserGenderTag", AV48UserInfoResponseUserGenderTag);
         AV49UserInfoResponseUserGenderValues = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_values;
         AssignAttri(sPrefix, false, "AV49UserInfoResponseUserGenderValues", AV49UserInfoResponseUserGenderValues);
         AV50UserInfoResponseUserLanguageTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name;
         AssignAttri(sPrefix, false, "AV50UserInfoResponseUserLanguageTag", AV50UserInfoResponseUserLanguageTag);
         AV51UserInfoResponseUserLastNameGenAuto = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic;
         AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
         AV52UserInfoResponseUserLastNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name;
         AssignAttri(sPrefix, false, "AV52UserInfoResponseUserLastNameTag", AV52UserInfoResponseUserLastNameTag);
         AV53UserInfoResponseUserNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusername_name;
         AssignAttri(sPrefix, false, "AV53UserInfoResponseUserNameTag", AV53UserInfoResponseUserNameTag);
         AV54UserInfoResponseUserTimeZoneTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name;
         AssignAttri(sPrefix, false, "AV54UserInfoResponseUserTimeZoneTag", AV54UserInfoResponseUserTimeZoneTag);
         AV55UserInfoResponseUserURLImageTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name;
         AssignAttri(sPrefix, false, "AV55UserInfoResponseUserURLImageTag", AV55UserInfoResponseUserURLImageTag);
         AV56UserInfoResponseUserURLProfileTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name;
         AssignAttri(sPrefix, false, "AV56UserInfoResponseUserURLProfileTag", AV56UserInfoResponseUserURLProfileTag);
      }

      protected void S242( )
      {
         /* 'SAVEAUTHENTICATIONSAML' Routine */
         returnInSub = false;
         AV5AuthenticationTypeSaml20.load( AV33Name);
         AV5AuthenticationTypeSaml20.gxTpr_Name = AV33Name;
         AV5AuthenticationTypeSaml20.gxTpr_Isenable = AV20IsEnable;
         AV5AuthenticationTypeSaml20.gxTpr_Description = AV10Dsc;
         AV5AuthenticationTypeSaml20.gxTpr_Smallimagename = AV40SmallImageName;
         AV5AuthenticationTypeSaml20.gxTpr_Bigimagename = AV7BigImageName;
         AV5AuthenticationTypeSaml20.gxTpr_Impersonate = AV19Impersonate;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Serviceproviderentityid = AV38ServiceProviderEntityID;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Identityproviderentityid = AV18IdentityProviderEntityID;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Authncontext = AV6AuthnContext;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Nameidpolicyformat = AV73NameIDPolicyFormat;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Isredirectbinding = AV21isRedirectBinding;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Forceauthn = AV15ForceAuthn;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliascredential = AV22KeyAliasCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliastrustcred = AV23KeyAliasTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorecredential = AV25KeyStoreCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorefilepathtrustcred = AV26KeyStoreFilePathTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorepwdtrustcred = AV27KeyStorePwdTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystoretrustcred = AV28KeyStoreTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpathcredential = AV29KeyStPathCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpwdcredential = AV30KeyStPwdCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Samlendpointlocation = AV37SamlEndpointLocation;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Disablesinglelogout = AV74DisableSingleLogout;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Singlelogoutendpoint = AV39SingleLogoutendpoint;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Localsiteurl = AV31LocalSiteURL;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name = AV45UserInfoResponseUserErrorDescriptionTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name = AV43UserInfoResponseUserBirthdayTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuseremail_name = AV44UserInfoResponseUserEmailTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name = AV46UserInfoResponseUserExternalIdTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name = AV47UserInfoResponseUserFirstNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_name = AV48UserInfoResponseUserGenderTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_values = AV49UserInfoResponseUserGenderValues;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name = AV50UserInfoResponseUserLanguageTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic = AV51UserInfoResponseUserLastNameGenAuto;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name = AV52UserInfoResponseUserLastNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusername_name = AV53UserInfoResponseUserNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name = AV54UserInfoResponseUserTimeZoneTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name = AV55UserInfoResponseUserURLImageTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name = AV56UserInfoResponseUserURLProfileTag;
         AV5AuthenticationTypeSaml20.save();
         /* Start For Each Line */
         nRC_GXsfl_304 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_304"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_304_fel_idx = 0;
         while ( nGXsfl_304_fel_idx < nRC_GXsfl_304 )
         {
            nGXsfl_304_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_304_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_304_fel_idx+1);
            sGXsfl_304_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_3042( ) ;
            AV11DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
            AV12DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
            AV75BtnDelete_Action = cgiGet( edtavBtndelete_action_Internalname);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11DynamicPropName)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12DynamicPropTag)) )
            {
               AV17GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
               AV17GAMPropertySimple.gxTpr_Id = AV11DynamicPropName;
               AV17GAMPropertySimple.gxTpr_Value = AV12DynamicPropTag;
               if ( ! AV5AuthenticationTypeSaml20.setuserinfoproperty(AV17GAMPropertySimple, out  AV14Errors) )
               {
                  AV84GXV4 = 1;
                  while ( AV84GXV4 <= AV14Errors.Count )
                  {
                     AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV84GXV4));
                     context.StatusMessage( StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", "") );
                     AV84GXV4 = (int)(AV84GXV4+1);
                  }
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_304_fel_idx == 0 )
         {
            nGXsfl_304_idx = 1;
            sGXsfl_304_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_idx), 4, 0), 4, "0");
            SubsflControlProps_3042( ) ;
         }
         nGXsfl_304_fel_idx = 1;
      }

      protected void wb_table1_310_3S2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntrySaml20.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_310_3S2e( true) ;
         }
         else
         {
            wb_table1_310_3S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV33Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV33Name", AV33Name);
         AV41TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
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
         PA3S2( ) ;
         WS3S2( ) ;
         WE3S2( ) ;
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
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV33Name = (string)((string)getParm(obj,1));
         sCtrlAV41TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wcauthenticationtypeentrysaml20", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV33Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV33Name", AV33Name);
            AV41TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV33Name = cgiGet( sPrefix+"wcpOAV33Name");
         wcpOAV41TypeId = cgiGet( sPrefix+"wcpOAV41TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV33Name, wcpOAV33Name) != 0 ) || ( StringUtil.StrCmp(AV41TypeId, wcpOAV41TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV33Name = AV33Name;
         wcpOAV41TypeId = AV41TypeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV33Name = cgiGet( sPrefix+"AV33Name_CTRL");
         if ( StringUtil.Len( sCtrlAV33Name) > 0 )
         {
            AV33Name = cgiGet( sCtrlAV33Name);
            AssignAttri(sPrefix, false, "AV33Name", AV33Name);
         }
         else
         {
            AV33Name = cgiGet( sPrefix+"AV33Name_PARM");
         }
         sCtrlAV41TypeId = cgiGet( sPrefix+"AV41TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV41TypeId) > 0 )
         {
            AV41TypeId = cgiGet( sCtrlAV41TypeId);
            AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
         }
         else
         {
            AV41TypeId = cgiGet( sPrefix+"AV41TypeId_PARM");
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
         PA3S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3S2( ) ;
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
         WS3S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33Name_PARM", StringUtil.RTrim( AV33Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33Name_CTRL", StringUtil.RTrim( sCtrlAV33Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41TypeId_PARM", StringUtil.RTrim( AV41TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41TypeId_CTRL", StringUtil.RTrim( sCtrlAV41TypeId));
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
         WE3S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221325416", true, true);
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
         context.AddJavascriptSource("k2bfsg/wcauthenticationtypeentrysaml20.js", "?202431221325417", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_3042( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_304_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_304_idx;
         edtavBtndelete_action_Internalname = sPrefix+"vBTNDELETE_ACTION_"+sGXsfl_304_idx;
      }

      protected void SubsflControlProps_fel_3042( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_304_fel_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_304_fel_idx;
         edtavBtndelete_action_Internalname = sPrefix+"vBTNDELETE_ACTION_"+sGXsfl_304_fel_idx;
      }

      protected void sendrow_3042( )
      {
         SubsflControlProps_3042( ) ;
         WB3S0( ) ;
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
            if ( ((int)((nGXsfl_304_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_304_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 305,'"+sPrefix+"',false,'"+sGXsfl_304_idx+"',304)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicpropname_Internalname,StringUtil.RTrim( AV11DynamicPropName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,305);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicpropname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(int)edtavDynamicpropname_Visible,(int)edtavDynamicpropname_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)304,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMPropertyId",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 306,'"+sPrefix+"',false,'"+sGXsfl_304_idx+"',304)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicproptag_Internalname,StringUtil.RTrim( AV12DynamicPropTag),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,306);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicproptag_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavDynamicproptag_Visible,(int)edtavDynamicproptag_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)304,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavBtndelete_action_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavBtndelete_action_Enabled!=0)&&(edtavBtndelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 307,'"+sPrefix+"',false,'',304)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavBtndelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavBtndelete_action_gximage+"_Class");
         StyleString = "";
         AV75BtnDelete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV80Btndelete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV75BtnDelete_Action)) ? AV80Btndelete_action_GXI : context.PathToRelativeUrl( AV75BtnDelete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtndelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavBtndelete_action_Visible,(short)1,(string)"Btn Delete",(string)edtavBtndelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavBtndelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_BTNDELETE\\'."+sGXsfl_304_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV75BtnDelete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3S2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_304_idx = ((subGrid_Islastpage==1)&&(nGXsfl_304_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_304_idx+1);
         sGXsfl_304_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_304_idx), 4, 0), 4, "0");
         SubsflControlProps_3042( ) ;
         /* End function sendrow_3042 */
      }

      protected void init_web_controls( )
      {
         cmbavFunctionid.Name = "vFUNCTIONID";
         cmbavFunctionid.WebTags = "";
         cmbavFunctionid.addItem("AuthenticationAndRoles", context.GetMessage( "Authentication and Roles", ""), 0);
         cmbavFunctionid.addItem("OnlyAuthentication", context.GetMessage( "Only Authentication", ""), 0);
         if ( cmbavFunctionid.ItemCount > 0 )
         {
         }
         chkavIsenable.Name = "vISENABLE";
         chkavIsenable.WebTags = "";
         chkavIsenable.Caption = "";
         AssignProp(sPrefix, false, chkavIsenable_Internalname, "TitleCaption", chkavIsenable.Caption, true);
         chkavIsenable.CheckedValue = "false";
         chkavIsredirectbinding.Name = "vISREDIRECTBINDING";
         chkavIsredirectbinding.WebTags = "";
         chkavIsredirectbinding.Caption = "";
         AssignProp(sPrefix, false, chkavIsredirectbinding_Internalname, "TitleCaption", chkavIsredirectbinding.Caption, true);
         chkavIsredirectbinding.CheckedValue = "false";
         cmbavNameidpolicyformat.Name = "vNAMEIDPOLICYFORMAT";
         cmbavNameidpolicyformat.WebTags = "";
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified", context.GetMessage( "UNSPECIFIED", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress", context.GetMessage( "EMAIL", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:2.0:nameid-format:encrypted", context.GetMessage( "ENCRYPTED", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:2.0:nameid-format:transient", context.GetMessage( "TRANSIENT", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:2.0:nameid-format:persistent", context.GetMessage( "PERSISTENT", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:2.0:nameid-format:entity", context.GetMessage( "ENTITY", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:2.0:nameid-format:kerberos", context.GetMessage( "KERBEROS", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:1.1:nameid-format:WindowsDomainQualifiedName", context.GetMessage( "WIN_DOMAIN_QUALIFIED", ""), 0);
         cmbavNameidpolicyformat.addItem("urn:oasis:names:tc:SAML:1.1:nameid-format:X509SubjectName", context.GetMessage( "X509_SUBJECT", ""), 0);
         if ( cmbavNameidpolicyformat.ItemCount > 0 )
         {
         }
         chkavForceauthn.Name = "vFORCEAUTHN";
         chkavForceauthn.WebTags = "";
         chkavForceauthn.Caption = "";
         AssignProp(sPrefix, false, chkavForceauthn_Internalname, "TitleCaption", chkavForceauthn.Caption, true);
         chkavForceauthn.CheckedValue = "false";
         chkavDisablesinglelogout.Name = "vDISABLESINGLELOGOUT";
         chkavDisablesinglelogout.WebTags = "";
         chkavDisablesinglelogout.Caption = "";
         AssignProp(sPrefix, false, chkavDisablesinglelogout_Internalname, "TitleCaption", chkavDisablesinglelogout.Caption, true);
         chkavDisablesinglelogout.CheckedValue = "false";
         chkavUserinforesponseuserlastnamegenauto.Name = "vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         chkavUserinforesponseuserlastnamegenauto.WebTags = "";
         chkavUserinforesponseuserlastnamegenauto.Caption = "";
         AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "TitleCaption", chkavUserinforesponseuserlastnamegenauto.Caption, true);
         chkavUserinforesponseuserlastnamegenauto.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl304( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"304\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_AttributeName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_AttributeTag", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavBtndelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavBtndelete_action_gximage+"_Class")+"\" "+" style=\""+((edtavBtndelete_action_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV11DynamicPropName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12DynamicPropTag)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV75BtnDelete_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavBtndelete_action_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtndelete_action_Visible), 5, 0, ".", "")));
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
         edtavName_Internalname = sPrefix+"vNAME";
         divTable_container_name_Internalname = sPrefix+"TABLE_CONTAINER_NAME";
         cmbavFunctionid_Internalname = sPrefix+"vFUNCTIONID";
         divTable_container_functionid_Internalname = sPrefix+"TABLE_CONTAINER_FUNCTIONID";
         chkavIsenable_Internalname = sPrefix+"vISENABLE";
         divTable_container_isenable_Internalname = sPrefix+"TABLE_CONTAINER_ISENABLE";
         edtavDsc_Internalname = sPrefix+"vDSC";
         divTable_container_dsc_Internalname = sPrefix+"TABLE_CONTAINER_DSC";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         divTable_container_smallimagename_Internalname = sPrefix+"TABLE_CONTAINER_SMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTable_container_bigimagename_Internalname = sPrefix+"TABLE_CONTAINER_BIGIMAGENAME";
         edtavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         divTable_container_impersonate_Internalname = sPrefix+"TABLE_CONTAINER_IMPERSONATE";
         lblTab_title_Internalname = sPrefix+"TAB_TITLE";
         edtavLocalsiteurl_Internalname = sPrefix+"vLOCALSITEURL";
         divTable_container_localsiteurl_Internalname = sPrefix+"TABLE_CONTAINER_LOCALSITEURL";
         edtavServiceproviderentityid_Internalname = sPrefix+"vSERVICEPROVIDERENTITYID";
         divTable_container_serviceproviderentityid_Internalname = sPrefix+"TABLE_CONTAINER_SERVICEPROVIDERENTITYID";
         edtavIdentityproviderentityid_Internalname = sPrefix+"vIDENTITYPROVIDERENTITYID";
         divTable_container_identityproviderentityid_Internalname = sPrefix+"TABLE_CONTAINER_IDENTITYPROVIDERENTITYID";
         chkavIsredirectbinding_Internalname = sPrefix+"vISREDIRECTBINDING";
         divTable_container_isredirectbinding_Internalname = sPrefix+"TABLE_CONTAINER_ISREDIRECTBINDING";
         edtavSamlendpointlocation_Internalname = sPrefix+"vSAMLENDPOINTLOCATION";
         divTable_container_samlendpointlocation_Internalname = sPrefix+"TABLE_CONTAINER_SAMLENDPOINTLOCATION";
         cmbavNameidpolicyformat_Internalname = sPrefix+"vNAMEIDPOLICYFORMAT";
         divTable_container_nameidpolicyformat_Internalname = sPrefix+"TABLE_CONTAINER_NAMEIDPOLICYFORMAT";
         chkavForceauthn_Internalname = sPrefix+"vFORCEAUTHN";
         divTable_container_forceauthn_Internalname = sPrefix+"TABLE_CONTAINER_FORCEAUTHN";
         edtavAuthncontext_Internalname = sPrefix+"vAUTHNCONTEXT";
         divTable_container_authncontext_Internalname = sPrefix+"TABLE_CONTAINER_AUTHNCONTEXT";
         divMaingroupresponsivetable_login_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_LOGIN";
         grpLogin_Internalname = sPrefix+"LOGIN";
         chkavDisablesinglelogout_Internalname = sPrefix+"vDISABLESINGLELOGOUT";
         divTable_container_disablesinglelogout_Internalname = sPrefix+"TABLE_CONTAINER_DISABLESINGLELOGOUT";
         edtavSinglelogoutendpoint_Internalname = sPrefix+"vSINGLELOGOUTENDPOINT";
         divTable_container_singlelogoutendpoint_Internalname = sPrefix+"TABLE_CONTAINER_SINGLELOGOUTENDPOINT";
         divMaingroupresponsivetable_logout_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_LOGOUT";
         grpLogout_Internalname = sPrefix+"LOGOUT";
         divMaintabresponsivetable_tab_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB";
         lblTab1_title_Internalname = sPrefix+"TAB1_TITLE";
         edtavKeystpathcredential_Internalname = sPrefix+"vKEYSTPATHCREDENTIAL";
         divTable_container_keystpathcredential_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTPATHCREDENTIAL";
         edtavKeystpwdcredential_Internalname = sPrefix+"vKEYSTPWDCREDENTIAL";
         divTable_container_keystpwdcredential_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTPWDCREDENTIAL";
         edtavKeyaliascredential_Internalname = sPrefix+"vKEYALIASCREDENTIAL";
         divTable_container_keyaliascredential_Internalname = sPrefix+"TABLE_CONTAINER_KEYALIASCREDENTIAL";
         edtavKeystorecredential_Internalname = sPrefix+"vKEYSTORECREDENTIAL";
         divTable_container_keystorecredential_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTORECREDENTIAL";
         divMaingroupresponsivetable_requestcredentials_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_REQUESTCREDENTIALS";
         grpRequestcredentials_Internalname = sPrefix+"REQUESTCREDENTIALS";
         edtavKeystorefilepathtrustcred_Internalname = sPrefix+"vKEYSTOREFILEPATHTRUSTCRED";
         divTable_container_keystorefilepathtrustcred_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTOREFILEPATHTRUSTCRED";
         lblLineseparatortitle_advancedresponseconfiguration_Internalname = sPrefix+"LINESEPARATORTITLE_ADVANCEDRESPONSECONFIGURATION";
         divLineseparatorheader_advancedresponseconfiguration_Internalname = sPrefix+"LINESEPARATORHEADER_ADVANCEDRESPONSECONFIGURATION";
         edtavKeystorepwdtrustcred_Internalname = sPrefix+"vKEYSTOREPWDTRUSTCRED";
         divTable_container_keystorepwdtrustcred_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTOREPWDTRUSTCRED";
         edtavKeyaliastrustcred_Internalname = sPrefix+"vKEYALIASTRUSTCRED";
         divTable_container_keyaliastrustcred_Internalname = sPrefix+"TABLE_CONTAINER_KEYALIASTRUSTCRED";
         edtavKeystoretrustcred_Internalname = sPrefix+"vKEYSTORETRUSTCRED";
         divTable_container_keystoretrustcred_Internalname = sPrefix+"TABLE_CONTAINER_KEYSTORETRUSTCRED";
         divLineseparatorcontent_advancedresponseconfiguration_Internalname = sPrefix+"LINESEPARATORCONTENT_ADVANCEDRESPONSECONFIGURATION";
         divLineseparatorcontainer_advancedresponseconfiguration_Internalname = sPrefix+"LINESEPARATORCONTAINER_ADVANCEDRESPONSECONFIGURATION";
         divMaingroupresponsivetable_responsecredentials_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_RESPONSECREDENTIALS";
         grpResponsecredentials_Internalname = sPrefix+"RESPONSECREDENTIALS";
         divMaintabresponsivetable_tab1_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB1";
         lblTab2_title_Internalname = sPrefix+"TAB2_TITLE";
         edtavUserinforesponseuseremailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREMAILTAG";
         divTable_container_userinforesponseuseremailtag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSEREMAILTAG";
         edtavUserinforesponseuserexternalidtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREXTERNALIDTAG";
         divTable_container_userinforesponseuserexternalidtag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSEREXTERNALIDTAG";
         edtavUserinforesponseusernametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERNAMETAG";
         divTable_container_userinforesponseusernametag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERNAMETAG";
         edtavUserinforesponseuserfirstnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERFIRSTNAMETAG";
         divTable_container_userinforesponseuserfirstnametag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERFIRSTNAMETAG";
         chkavUserinforesponseuserlastnamegenauto_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         divTable_container_userinforesponseuserlastnamegenauto_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERLASTNAMEGENAUTO";
         lblTextblock_var_userinforesponseuserlastnametag_Internalname = sPrefix+"TEXTBLOCK_VAR_USERINFORESPONSEUSERLASTNAMETAG";
         edtavUserinforesponseuserlastnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMETAG";
         lblTbuserlastnamehelp_Internalname = sPrefix+"TBUSERLASTNAMEHELP";
         divTable_container_userinforesponseuserlastnametagcellcontainer_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERLASTNAMETAGCELLCONTAINER";
         divTable_container_userinforesponseuserlastnametag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERLASTNAMETAG";
         edtavUserinforesponseusergendertag_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERTAG";
         divTable_container_userinforesponseusergendertag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERGENDERTAG";
         edtavUserinforesponseusergendervalues_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERVALUES";
         divTable_container_userinforesponseusergendervalues_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERGENDERVALUES";
         edtavUserinforesponseuserbirthdaytag_Internalname = sPrefix+"vUSERINFORESPONSEUSERBIRTHDAYTAG";
         divTable_container_userinforesponseuserbirthdaytag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERBIRTHDAYTAG";
         edtavUserinforesponseuserurlimagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLIMAGETAG";
         divTable_container_userinforesponseuserurlimagetag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERURLIMAGETAG";
         edtavUserinforesponseuserurlprofiletag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLPROFILETAG";
         divTable_container_userinforesponseuserurlprofiletag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERURLPROFILETAG";
         edtavUserinforesponseuserlanguagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLANGUAGETAG";
         divTable_container_userinforesponseuserlanguagetag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERLANGUAGETAG";
         edtavUserinforesponseusertimezonetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERTIMEZONETAG";
         divTable_container_userinforesponseusertimezonetag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERTIMEZONETAG";
         edtavUserinforesponseerrordescriptiontag_Internalname = sPrefix+"vUSERINFORESPONSEERRORDESCRIPTIONTAG";
         divTable_container_userinforesponseerrordescriptiontag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEERRORDESCRIPTIONTAG";
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME";
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG";
         edtavBtndelete_action_Internalname = sPrefix+"vBTNDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         bttBtnadd_Internalname = sPrefix+"BTNADD";
         divMaingroupresponsivetable_groupcustomuserattributes_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUPCUSTOMUSERATTRIBUTES";
         grpGroupcustomuserattributes_Internalname = sPrefix+"GROUPCUSTOMUSERATTRIBUTES";
         divMaingroupresponsivetable_group1response_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUP1RESPONSE";
         grpGroup1response_Internalname = sPrefix+"GROUP1RESPONSE";
         divMaintabresponsivetable_tab2_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB2";
         Tabs_Internalname = sPrefix+"TABS";
         divAttributescontainertable_attributes_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divAttributes_content_Internalname = sPrefix+"ATTRIBUTES_CONTENT";
         Attributes_Internalname = sPrefix+"ATTRIBUTES";
         bttBtnconfirm_Internalname = sPrefix+"BTNCONFIRM";
         bttCancel_Internalname = sPrefix+"CANCEL";
         divActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
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
         chkavUserinforesponseuserlastnamegenauto.Caption = context.GetMessage( "K2BT_GAM_GenerateLastNameAutomatically", "");
         chkavDisablesinglelogout.Caption = context.GetMessage( "K2BT_GAM_DisableSingleLogout", "");
         chkavForceauthn.Caption = context.GetMessage( "K2BT_GAM_ForceAuthentication", "");
         chkavIsredirectbinding.Caption = context.GetMessage( "isRedirectBinding", "");
         chkavIsenable.Caption = context.GetMessage( "K2BT_GAM_Enabled?", "");
         edtavBtndelete_action_Jsonclick = "";
         edtavBtndelete_action_Enabled = 1;
         edtavBtndelete_action_Tooltiptext = "";
         edtavDynamicproptag_Jsonclick = "";
         edtavDynamicpropname_Jsonclick = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavBtndelete_action_gximage = "";
         edtavDynamicproptag_Visible = -1;
         edtavDynamicpropname_Visible = -1;
         edtavDynamicproptag_Enabled = 1;
         edtavDynamicpropname_Enabled = 1;
         edtavBtndelete_action_Visible = -1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         bttBtnconfirm_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttBtnconfirm_Visible = 1;
         bttBtnadd_Visible = 1;
         edtavUserinforesponseerrordescriptiontag_Jsonclick = "";
         edtavUserinforesponseerrordescriptiontag_Enabled = 1;
         edtavUserinforesponseusertimezonetag_Jsonclick = "";
         edtavUserinforesponseusertimezonetag_Enabled = 1;
         edtavUserinforesponseuserlanguagetag_Jsonclick = "";
         edtavUserinforesponseuserlanguagetag_Enabled = 1;
         edtavUserinforesponseuserurlprofiletag_Jsonclick = "";
         edtavUserinforesponseuserurlprofiletag_Enabled = 1;
         edtavUserinforesponseuserurlimagetag_Jsonclick = "";
         edtavUserinforesponseuserurlimagetag_Enabled = 1;
         edtavUserinforesponseuserbirthdaytag_Jsonclick = "";
         edtavUserinforesponseuserbirthdaytag_Enabled = 1;
         edtavUserinforesponseusergendervalues_Jsonclick = "";
         edtavUserinforesponseusergendervalues_Enabled = 1;
         edtavUserinforesponseusergendertag_Jsonclick = "";
         edtavUserinforesponseusergendertag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Jsonclick = "";
         edtavUserinforesponseuserlastnametag_Enabled = 1;
         chkavUserinforesponseuserlastnamegenauto.Enabled = 1;
         edtavUserinforesponseuserfirstnametag_Jsonclick = "";
         edtavUserinforesponseuserfirstnametag_Enabled = 1;
         edtavUserinforesponseusernametag_Jsonclick = "";
         edtavUserinforesponseusernametag_Enabled = 1;
         edtavUserinforesponseuserexternalidtag_Jsonclick = "";
         edtavUserinforesponseuserexternalidtag_Enabled = 1;
         edtavUserinforesponseuseremailtag_Jsonclick = "";
         edtavUserinforesponseuseremailtag_Enabled = 1;
         edtavKeystoretrustcred_Jsonclick = "";
         edtavKeystoretrustcred_Enabled = 1;
         edtavKeyaliastrustcred_Jsonclick = "";
         edtavKeyaliastrustcred_Enabled = 1;
         edtavKeystorepwdtrustcred_Jsonclick = "";
         edtavKeystorepwdtrustcred_Enabled = 1;
         divLineseparatorcontent_advancedresponseconfiguration_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_advancedresponseconfiguration_Visible = 1;
         divLineseparatorheader_advancedresponseconfiguration_Class = "Section_LineSeparatorOpen";
         edtavKeystorefilepathtrustcred_Jsonclick = "";
         edtavKeystorefilepathtrustcred_Enabled = 1;
         edtavKeystorecredential_Jsonclick = "";
         edtavKeystorecredential_Enabled = 1;
         edtavKeyaliascredential_Jsonclick = "";
         edtavKeyaliascredential_Enabled = 1;
         edtavKeystpwdcredential_Jsonclick = "";
         edtavKeystpwdcredential_Enabled = 1;
         edtavKeystpathcredential_Jsonclick = "";
         edtavKeystpathcredential_Enabled = 1;
         edtavSinglelogoutendpoint_Jsonclick = "";
         edtavSinglelogoutendpoint_Enabled = 1;
         chkavDisablesinglelogout.Enabled = 1;
         edtavAuthncontext_Jsonclick = "";
         edtavAuthncontext_Enabled = 1;
         chkavForceauthn.Enabled = 1;
         cmbavNameidpolicyformat_Jsonclick = "";
         cmbavNameidpolicyformat.Enabled = 1;
         edtavSamlendpointlocation_Jsonclick = "";
         edtavSamlendpointlocation_Enabled = 1;
         chkavIsredirectbinding.Enabled = 1;
         edtavIdentityproviderentityid_Jsonclick = "";
         edtavIdentityproviderentityid_Enabled = 1;
         edtavServiceproviderentityid_Jsonclick = "";
         edtavServiceproviderentityid_Enabled = 1;
         edtavLocalsiteurl_Jsonclick = "";
         edtavLocalsiteurl_Enabled = 1;
         edtavImpersonate_Jsonclick = "";
         edtavImpersonate_Enabled = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         chkavIsenable.Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         Attributes_Containseditableform = Convert.ToBoolean( -1);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = "";
         Tabs_Historymanagement = Convert.ToBoolean( 0);
         Tabs_Class = "Tab";
         Tabs_Pagecount = 3;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'sPrefix'},{av:'AV20IsEnable',fld:'vISENABLE',pic:''},{av:'AV21isRedirectBinding',fld:'vISREDIRECTBINDING',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV74DisableSingleLogout',fld:'vDISABLESINGLELOGOUT',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''},{av:'AV67CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV69I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV67CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDRESPONSECONFIGURATION.CLICK","{handler:'E113S1',iparms:[{av:'divLineseparatorcontent_advancedresponseconfiguration_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDRESPONSECONFIGURATION',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDRESPONSECONFIGURATION.CLICK",",oparms:[{av:'divLineseparatorcontent_advancedresponseconfiguration_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDRESPONSECONFIGURATION',prop:'Visible'},{av:'divLineseparatorcontent_advancedresponseconfiguration_Class',ctrl:'LINESEPARATORCONTENT_ADVANCEDRESPONSECONFIGURATION',prop:'Class'},{av:'divLineseparatorheader_advancedresponseconfiguration_Class',ctrl:'LINESEPARATORHEADER_ADVANCEDRESPONSECONFIGURATION',prop:'Class'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E173S2',iparms:[{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E183S2',iparms:[{av:'AV69I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV81Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV69I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV75BtnDelete_Action',fld:'vBTNDELETE_ACTION',pic:''},{av:'edtavBtndelete_action_Tooltiptext',ctrl:'vBTNDELETE_ACTION',prop:'Tooltiptext'},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''},{av:'edtavBtndelete_action_Visible',ctrl:'vBTNDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'}]}");
         setEventMetadata("'E_BTNDELETE'","{handler:'E193S2',iparms:[{av:'AV33Name',fld:'vNAME',pic:''}]");
         setEventMetadata("'E_BTNDELETE'",",oparms:[{av:'edtavBtndelete_action_Visible',ctrl:'vBTNDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''}]}");
         setEventMetadata("'E_BTNADD'","{handler:'E133S2',iparms:[]");
         setEventMetadata("'E_BTNADD'",",oparms:[{av:'AV75BtnDelete_Action',fld:'vBTNDELETE_ACTION',pic:''},{av:'edtavBtndelete_action_Visible',ctrl:'vBTNDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'}]}");
         setEventMetadata("'E_BTNCONFIRM'","{handler:'E143S2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV33Name',fld:'vNAME',pic:''},{av:'AV20IsEnable',fld:'vISENABLE',pic:''},{av:'AV10Dsc',fld:'vDSC',pic:''},{av:'AV40SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV7BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'AV19Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV38ServiceProviderEntityID',fld:'vSERVICEPROVIDERENTITYID',pic:''},{av:'AV18IdentityProviderEntityID',fld:'vIDENTITYPROVIDERENTITYID',pic:''},{av:'AV6AuthnContext',fld:'vAUTHNCONTEXT',pic:''},{av:'cmbavNameidpolicyformat'},{av:'AV73NameIDPolicyFormat',fld:'vNAMEIDPOLICYFORMAT',pic:''},{av:'AV21isRedirectBinding',fld:'vISREDIRECTBINDING',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV22KeyAliasCredential',fld:'vKEYALIASCREDENTIAL',pic:''},{av:'AV23KeyAliasTrustCred',fld:'vKEYALIASTRUSTCRED',pic:''},{av:'AV25KeyStoreCredential',fld:'vKEYSTORECREDENTIAL',pic:''},{av:'AV26KeyStoreFilePathTrustCred',fld:'vKEYSTOREFILEPATHTRUSTCRED',pic:''},{av:'AV27KeyStorePwdTrustCred',fld:'vKEYSTOREPWDTRUSTCRED',pic:''},{av:'AV28KeyStoreTrustCred',fld:'vKEYSTORETRUSTCRED',pic:''},{av:'AV29KeyStPathCredential',fld:'vKEYSTPATHCREDENTIAL',pic:''},{av:'AV30KeyStPwdCredential',fld:'vKEYSTPWDCREDENTIAL',pic:''},{av:'AV37SamlEndpointLocation',fld:'vSAMLENDPOINTLOCATION',pic:''},{av:'AV74DisableSingleLogout',fld:'vDISABLESINGLELOGOUT',pic:''},{av:'AV39SingleLogoutendpoint',fld:'vSINGLELOGOUTENDPOINT',pic:''},{av:'AV31LocalSiteURL',fld:'vLOCALSITEURL',pic:''},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true},{av:'AV43UserInfoResponseUserBirthdayTag',fld:'vUSERINFORESPONSEUSERBIRTHDAYTAG',pic:''},{av:'AV44UserInfoResponseUserEmailTag',fld:'vUSERINFORESPONSEUSEREMAILTAG',pic:''},{av:'AV46UserInfoResponseUserExternalIdTag',fld:'vUSERINFORESPONSEUSEREXTERNALIDTAG',pic:''},{av:'AV47UserInfoResponseUserFirstNameTag',fld:'vUSERINFORESPONSEUSERFIRSTNAMETAG',pic:''},{av:'AV48UserInfoResponseUserGenderTag',fld:'vUSERINFORESPONSEUSERGENDERTAG',pic:''},{av:'AV49UserInfoResponseUserGenderValues',fld:'vUSERINFORESPONSEUSERGENDERVALUES',pic:''},{av:'AV50UserInfoResponseUserLanguageTag',fld:'vUSERINFORESPONSEUSERLANGUAGETAG',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''},{av:'AV52UserInfoResponseUserLastNameTag',fld:'vUSERINFORESPONSEUSERLASTNAMETAG',pic:''},{av:'AV53UserInfoResponseUserNameTag',fld:'vUSERINFORESPONSEUSERNAMETAG',pic:''},{av:'AV54UserInfoResponseUserTimeZoneTag',fld:'vUSERINFORESPONSEUSERTIMEZONETAG',pic:''},{av:'AV55UserInfoResponseUserURLImageTag',fld:'vUSERINFORESPONSEUSERURLIMAGETAG',pic:''},{av:'AV56UserInfoResponseUserURLProfileTag',fld:'vUSERINFORESPONSEUSERURLPROFILETAG',pic:''},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',grid:304,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_304',ctrl:'GRID',grid:304,prop:'GridRC',grid:304},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',grid:304,pic:''}]");
         setEventMetadata("'E_BTNCONFIRM'",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E123S1',iparms:[]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[]}");
         setEventMetadata("VALIDV_NAMEIDPOLICYFORMAT","{handler:'Validv_Nameidpolicyformat',iparms:[]");
         setEventMetadata("VALIDV_NAMEIDPOLICYFORMAT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Btndelete_action',iparms:[]");
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
         wcpOGx_mode = "";
         wcpOAV33Name = "";
         wcpOAV41TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV81Pgmname = "";
         AV45UserInfoResponseUserErrorDescriptionTag = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucAttributes = new GXUserControl();
         TempTags = "";
         AV16FunctionId = "";
         AV10Dsc = "";
         AV40SmallImageName = "";
         AV7BigImageName = "";
         AV19Impersonate = "";
         ucTabs = new GXUserControl();
         lblTab_title_Jsonclick = "";
         AV31LocalSiteURL = "";
         AV38ServiceProviderEntityID = "";
         AV18IdentityProviderEntityID = "";
         AV37SamlEndpointLocation = "";
         AV73NameIDPolicyFormat = "";
         AV6AuthnContext = "";
         AV39SingleLogoutendpoint = "";
         lblTab1_title_Jsonclick = "";
         AV29KeyStPathCredential = "";
         AV30KeyStPwdCredential = "";
         AV22KeyAliasCredential = "";
         AV25KeyStoreCredential = "";
         AV26KeyStoreFilePathTrustCred = "";
         lblLineseparatortitle_advancedresponseconfiguration_Jsonclick = "";
         AV27KeyStorePwdTrustCred = "";
         AV23KeyAliasTrustCred = "";
         AV28KeyStoreTrustCred = "";
         lblTab2_title_Jsonclick = "";
         AV44UserInfoResponseUserEmailTag = "";
         AV46UserInfoResponseUserExternalIdTag = "";
         AV53UserInfoResponseUserNameTag = "";
         AV47UserInfoResponseUserFirstNameTag = "";
         lblTextblock_var_userinforesponseuserlastnametag_Jsonclick = "";
         AV52UserInfoResponseUserLastNameTag = "";
         lblTbuserlastnamehelp_Jsonclick = "";
         AV48UserInfoResponseUserGenderTag = "";
         AV49UserInfoResponseUserGenderValues = "";
         AV43UserInfoResponseUserBirthdayTag = "";
         AV55UserInfoResponseUserURLImageTag = "";
         AV56UserInfoResponseUserURLProfileTag = "";
         AV50UserInfoResponseUserLanguageTag = "";
         AV54UserInfoResponseUserTimeZoneTag = "";
         AV42UserInfoResponseErrorDescriptionTag = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnadd_Jsonclick = "";
         bttBtnconfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11DynamicPropName = "";
         AV12DynamicPropTag = "";
         AV75BtnDelete_Action = "";
         AV80Btndelete_action_GXI = "";
         AV78GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV76ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         GridRow = new GXWebRow();
         AV71SDT = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPropertySimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMPropertySimple", "GeneXus.Programs");
         AV5AuthenticationTypeSaml20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSaml20(context);
         AV63GridStateKey = "";
         AV64GridState = new SdtK2BGridState(context);
         AV14Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV17GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV33Name = "";
         sCtrlAV41TypeId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrysaml20__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrysaml20__default(),
            new Object[][] {
            }
         );
         AV81Pgmname = "K2BFSG.WCAuthenticationTypeEntrySaml20";
         /* GeneXus formulas. */
         AV81Pgmname = "K2BFSG.WCAuthenticationTypeEntrySaml20";
         edtavDynamicpropname_Enabled = 0;
         edtavDynamicproptag_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV67CurrentPage_Grid ;
      private short AV69I_LoadCount_Grid ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
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
      private int divLineseparatorcontent_advancedresponseconfiguration_Visible ;
      private int nRC_GXsfl_304 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_304_idx=1 ;
      private int edtavDynamicpropname_Enabled ;
      private int edtavDynamicproptag_Enabled ;
      private int Tabs_Pagecount ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavImpersonate_Enabled ;
      private int edtavLocalsiteurl_Enabled ;
      private int edtavServiceproviderentityid_Enabled ;
      private int edtavIdentityproviderentityid_Enabled ;
      private int edtavSamlendpointlocation_Enabled ;
      private int edtavAuthncontext_Enabled ;
      private int edtavSinglelogoutendpoint_Enabled ;
      private int edtavKeystpathcredential_Enabled ;
      private int edtavKeystpwdcredential_Enabled ;
      private int edtavKeyaliascredential_Enabled ;
      private int edtavKeystorecredential_Enabled ;
      private int edtavKeystorefilepathtrustcred_Enabled ;
      private int edtavKeystorepwdtrustcred_Enabled ;
      private int edtavKeyaliastrustcred_Enabled ;
      private int edtavKeystoretrustcred_Enabled ;
      private int edtavUserinforesponseuseremailtag_Enabled ;
      private int edtavUserinforesponseuserexternalidtag_Enabled ;
      private int edtavUserinforesponseusernametag_Enabled ;
      private int edtavUserinforesponseuserfirstnametag_Enabled ;
      private int edtavUserinforesponseuserlastnametag_Enabled ;
      private int edtavUserinforesponseusergendertag_Enabled ;
      private int edtavUserinforesponseusergendervalues_Enabled ;
      private int edtavUserinforesponseuserbirthdaytag_Enabled ;
      private int edtavUserinforesponseuserurlimagetag_Enabled ;
      private int edtavUserinforesponseuserurlprofiletag_Enabled ;
      private int edtavUserinforesponseuserlanguagetag_Enabled ;
      private int edtavUserinforesponseusertimezonetag_Enabled ;
      private int edtavUserinforesponseerrordescriptiontag_Enabled ;
      private int bttBtnadd_Visible ;
      private int bttBtnconfirm_Visible ;
      private int subGrid_Islastpage ;
      private int AV79GXV2 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int edtavBtndelete_action_Visible ;
      private int edtavDynamicpropname_Visible ;
      private int edtavDynamicproptag_Visible ;
      private int AV82GXV3 ;
      private int nGXsfl_304_fel_idx=1 ;
      private int AV84GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavBtndelete_action_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string Gx_mode ;
      private string AV33Name ;
      private string AV41TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV33Name ;
      private string wcpOAV41TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_304_idx="0001" ;
      private string AV81Pgmname ;
      private string AV45UserInfoResponseUserErrorDescriptionTag ;
      private string edtavDynamicpropname_Internalname ;
      private string edtavDynamicproptag_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tabs_Class ;
      private string Attributes_Title ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Attributes_Internalname ;
      private string divAttributes_content_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divTable_container_functionid_Internalname ;
      private string cmbavFunctionid_Internalname ;
      private string AV16FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string divTable_container_isenable_Internalname ;
      private string chkavIsenable_Internalname ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV10Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_smallimagename_Internalname ;
      private string edtavSmallimagename_Internalname ;
      private string AV40SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string divTable_container_bigimagename_Internalname ;
      private string edtavBigimagename_Internalname ;
      private string AV7BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string divTable_container_impersonate_Internalname ;
      private string edtavImpersonate_Internalname ;
      private string AV19Impersonate ;
      private string edtavImpersonate_Jsonclick ;
      private string Tabs_Internalname ;
      private string lblTab_title_Internalname ;
      private string lblTab_title_Jsonclick ;
      private string divMaintabresponsivetable_tab_Internalname ;
      private string divTable_container_localsiteurl_Internalname ;
      private string edtavLocalsiteurl_Internalname ;
      private string edtavLocalsiteurl_Jsonclick ;
      private string divTable_container_serviceproviderentityid_Internalname ;
      private string edtavServiceproviderentityid_Internalname ;
      private string edtavServiceproviderentityid_Jsonclick ;
      private string divTable_container_identityproviderentityid_Internalname ;
      private string edtavIdentityproviderentityid_Internalname ;
      private string edtavIdentityproviderentityid_Jsonclick ;
      private string divTable_container_isredirectbinding_Internalname ;
      private string chkavIsredirectbinding_Internalname ;
      private string grpLogin_Internalname ;
      private string divMaingroupresponsivetable_login_Internalname ;
      private string divTable_container_samlendpointlocation_Internalname ;
      private string edtavSamlendpointlocation_Internalname ;
      private string edtavSamlendpointlocation_Jsonclick ;
      private string divTable_container_nameidpolicyformat_Internalname ;
      private string cmbavNameidpolicyformat_Internalname ;
      private string AV73NameIDPolicyFormat ;
      private string cmbavNameidpolicyformat_Jsonclick ;
      private string divTable_container_forceauthn_Internalname ;
      private string chkavForceauthn_Internalname ;
      private string divTable_container_authncontext_Internalname ;
      private string edtavAuthncontext_Internalname ;
      private string AV6AuthnContext ;
      private string edtavAuthncontext_Jsonclick ;
      private string grpLogout_Internalname ;
      private string divMaingroupresponsivetable_logout_Internalname ;
      private string divTable_container_disablesinglelogout_Internalname ;
      private string chkavDisablesinglelogout_Internalname ;
      private string divTable_container_singlelogoutendpoint_Internalname ;
      private string edtavSinglelogoutendpoint_Internalname ;
      private string edtavSinglelogoutendpoint_Jsonclick ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divMaintabresponsivetable_tab1_Internalname ;
      private string grpRequestcredentials_Internalname ;
      private string divMaingroupresponsivetable_requestcredentials_Internalname ;
      private string divTable_container_keystpathcredential_Internalname ;
      private string edtavKeystpathcredential_Internalname ;
      private string edtavKeystpathcredential_Jsonclick ;
      private string divTable_container_keystpwdcredential_Internalname ;
      private string edtavKeystpwdcredential_Internalname ;
      private string AV30KeyStPwdCredential ;
      private string edtavKeystpwdcredential_Jsonclick ;
      private string divTable_container_keyaliascredential_Internalname ;
      private string edtavKeyaliascredential_Internalname ;
      private string AV22KeyAliasCredential ;
      private string edtavKeyaliascredential_Jsonclick ;
      private string divTable_container_keystorecredential_Internalname ;
      private string edtavKeystorecredential_Internalname ;
      private string AV25KeyStoreCredential ;
      private string edtavKeystorecredential_Jsonclick ;
      private string grpResponsecredentials_Internalname ;
      private string divMaingroupresponsivetable_responsecredentials_Internalname ;
      private string divTable_container_keystorefilepathtrustcred_Internalname ;
      private string edtavKeystorefilepathtrustcred_Internalname ;
      private string edtavKeystorefilepathtrustcred_Jsonclick ;
      private string divLineseparatorcontainer_advancedresponseconfiguration_Internalname ;
      private string divLineseparatorheader_advancedresponseconfiguration_Internalname ;
      private string divLineseparatorheader_advancedresponseconfiguration_Class ;
      private string lblLineseparatortitle_advancedresponseconfiguration_Internalname ;
      private string lblLineseparatortitle_advancedresponseconfiguration_Jsonclick ;
      private string divLineseparatorcontent_advancedresponseconfiguration_Internalname ;
      private string divLineseparatorcontent_advancedresponseconfiguration_Class ;
      private string divTable_container_keystorepwdtrustcred_Internalname ;
      private string edtavKeystorepwdtrustcred_Internalname ;
      private string AV27KeyStorePwdTrustCred ;
      private string edtavKeystorepwdtrustcred_Jsonclick ;
      private string divTable_container_keyaliastrustcred_Internalname ;
      private string edtavKeyaliastrustcred_Internalname ;
      private string AV23KeyAliasTrustCred ;
      private string edtavKeyaliastrustcred_Jsonclick ;
      private string divTable_container_keystoretrustcred_Internalname ;
      private string edtavKeystoretrustcred_Internalname ;
      private string AV28KeyStoreTrustCred ;
      private string edtavKeystoretrustcred_Jsonclick ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divMaintabresponsivetable_tab2_Internalname ;
      private string grpGroup1response_Internalname ;
      private string divMaingroupresponsivetable_group1response_Internalname ;
      private string divTable_container_userinforesponseuseremailtag_Internalname ;
      private string edtavUserinforesponseuseremailtag_Internalname ;
      private string AV44UserInfoResponseUserEmailTag ;
      private string edtavUserinforesponseuseremailtag_Jsonclick ;
      private string divTable_container_userinforesponseuserexternalidtag_Internalname ;
      private string edtavUserinforesponseuserexternalidtag_Internalname ;
      private string AV46UserInfoResponseUserExternalIdTag ;
      private string edtavUserinforesponseuserexternalidtag_Jsonclick ;
      private string divTable_container_userinforesponseusernametag_Internalname ;
      private string edtavUserinforesponseusernametag_Internalname ;
      private string AV53UserInfoResponseUserNameTag ;
      private string edtavUserinforesponseusernametag_Jsonclick ;
      private string divTable_container_userinforesponseuserfirstnametag_Internalname ;
      private string edtavUserinforesponseuserfirstnametag_Internalname ;
      private string AV47UserInfoResponseUserFirstNameTag ;
      private string edtavUserinforesponseuserfirstnametag_Jsonclick ;
      private string divTable_container_userinforesponseuserlastnamegenauto_Internalname ;
      private string chkavUserinforesponseuserlastnamegenauto_Internalname ;
      private string divTable_container_userinforesponseuserlastnametag_Internalname ;
      private string lblTextblock_var_userinforesponseuserlastnametag_Internalname ;
      private string lblTextblock_var_userinforesponseuserlastnametag_Jsonclick ;
      private string divTable_container_userinforesponseuserlastnametagcellcontainer_Internalname ;
      private string edtavUserinforesponseuserlastnametag_Internalname ;
      private string AV52UserInfoResponseUserLastNameTag ;
      private string edtavUserinforesponseuserlastnametag_Jsonclick ;
      private string lblTbuserlastnamehelp_Internalname ;
      private string lblTbuserlastnamehelp_Jsonclick ;
      private string divTable_container_userinforesponseusergendertag_Internalname ;
      private string edtavUserinforesponseusergendertag_Internalname ;
      private string AV48UserInfoResponseUserGenderTag ;
      private string edtavUserinforesponseusergendertag_Jsonclick ;
      private string divTable_container_userinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Jsonclick ;
      private string divTable_container_userinforesponseuserbirthdaytag_Internalname ;
      private string edtavUserinforesponseuserbirthdaytag_Internalname ;
      private string AV43UserInfoResponseUserBirthdayTag ;
      private string edtavUserinforesponseuserbirthdaytag_Jsonclick ;
      private string divTable_container_userinforesponseuserurlimagetag_Internalname ;
      private string edtavUserinforesponseuserurlimagetag_Internalname ;
      private string AV55UserInfoResponseUserURLImageTag ;
      private string edtavUserinforesponseuserurlimagetag_Jsonclick ;
      private string divTable_container_userinforesponseuserurlprofiletag_Internalname ;
      private string edtavUserinforesponseuserurlprofiletag_Internalname ;
      private string AV56UserInfoResponseUserURLProfileTag ;
      private string edtavUserinforesponseuserurlprofiletag_Jsonclick ;
      private string divTable_container_userinforesponseuserlanguagetag_Internalname ;
      private string edtavUserinforesponseuserlanguagetag_Internalname ;
      private string AV50UserInfoResponseUserLanguageTag ;
      private string edtavUserinforesponseuserlanguagetag_Jsonclick ;
      private string divTable_container_userinforesponseusertimezonetag_Internalname ;
      private string edtavUserinforesponseusertimezonetag_Internalname ;
      private string AV54UserInfoResponseUserTimeZoneTag ;
      private string edtavUserinforesponseusertimezonetag_Jsonclick ;
      private string divTable_container_userinforesponseerrordescriptiontag_Internalname ;
      private string edtavUserinforesponseerrordescriptiontag_Internalname ;
      private string AV42UserInfoResponseErrorDescriptionTag ;
      private string edtavUserinforesponseerrordescriptiontag_Jsonclick ;
      private string grpGroupcustomuserattributes_Internalname ;
      private string divMaingroupresponsivetable_groupcustomuserattributes_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string bttBtnadd_Internalname ;
      private string bttBtnadd_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtnconfirm_Caption ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV11DynamicPropName ;
      private string AV12DynamicPropTag ;
      private string edtavBtndelete_action_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavBtndelete_action_gximage ;
      private string edtavBtndelete_action_Tooltiptext ;
      private string sGXsfl_304_fel_idx="0001" ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV33Name ;
      private string sCtrlAV41TypeId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDynamicpropname_Jsonclick ;
      private string edtavDynamicproptag_Jsonclick ;
      private string sImgUrl ;
      private string edtavBtndelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20IsEnable ;
      private bool AV21isRedirectBinding ;
      private bool AV15ForceAuthn ;
      private bool AV74DisableSingleLogout ;
      private bool AV51UserInfoResponseUserLastNameGenAuto ;
      private bool bGXsfl_304_Refreshing=false ;
      private bool Tabs_Historymanagement ;
      private bool Attributes_Collapsible ;
      private bool Attributes_Open ;
      private bool Attributes_Showborders ;
      private bool Attributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV68Reload_Grid ;
      private bool AV70Exit_Grid ;
      private bool AV75BtnDelete_Action_IsBlob ;
      private string AV31LocalSiteURL ;
      private string AV38ServiceProviderEntityID ;
      private string AV18IdentityProviderEntityID ;
      private string AV37SamlEndpointLocation ;
      private string AV39SingleLogoutendpoint ;
      private string AV29KeyStPathCredential ;
      private string AV26KeyStoreFilePathTrustCred ;
      private string AV49UserInfoResponseUserGenderValues ;
      private string AV80Btndelete_action_GXI ;
      private string AV63GridStateKey ;
      private string AV75BtnDelete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucTabs ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCheckbox chkavIsredirectbinding ;
      private GXCombobox cmbavNameidpolicyformat ;
      private GXCheckbox chkavForceauthn ;
      private GXCheckbox chkavDisablesinglelogout ;
      private GXCheckbox chkavUserinforesponseuserlastnamegenauto ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPropertySimple> AV71SDT ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14Errors ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV78GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSaml20 AV5AuthenticationTypeSaml20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMPropertySimple AV17GAMPropertySimple ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV13Error ;
      private SdtK2BGridState AV64GridState ;
      private SdtK2BAttributeValue_Item AV76ActivityLogProperty ;
   }

   public class wcauthenticationtypeentrysaml20__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wcauthenticationtypeentrysaml20__default : DataStoreHelperBase, IDataStoreHelper
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
