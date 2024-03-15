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
   public class wcauthenticationtypeentrygeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcauthenticationtypeentrygeneral( )
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

      public wcauthenticationtypeentrygeneral( IGxContext context )
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
         this.AV29Name = aP1_Name;
         this.AV53TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV29Name;
         aP2_TypeId=this.AV53TypeId;
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
         cmbavImpersonate = new GXCombobox();
         chkavTfaenable = new GXCheckbox();
         cmbavTfaauthenticationtypename = new GXCombobox();
         chkavTfaforceforallusers = new GXCheckbox();
         chkavOtpuseforfirstfactorauthentication = new GXCheckbox();
         cmbavOtpeventvalidateuser = new GXCombobox();
         cmbavOtpgenerationtype = new GXCombobox();
         cmbavOtpgenerationtype_customeventgeneratecode = new GXCombobox();
         chkavOtpgeneratecodeonlynumbers = new GXCheckbox();
         cmbavOtpeventsendcode = new GXCombobox();
         cmbavOtpeventvalidatecode = new GXCombobox();
         chkavSiteurlcallbackiscustom = new GXCheckbox();
         chkavAdduseradditionaldatascope = new GXCheckbox();
         chkavAddinitialpropertiesscope = new GXCheckbox();
         chkavAutovalidateexternaltokenandrefresh = new GXCheckbox();
         cmbavWsversion = new GXCombobox();
         cmbavWsserversecureprotocol = new GXCombobox();
         cmbavCusversion = new GXCombobox();
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
                  AV29Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV29Name", AV29Name);
                  AV53TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV53TypeId", AV53TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV29Name,(string)AV53TypeId});
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
            PA3T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS3T2( ) ;
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
            context.SendWebValue( "Authentication type") ;
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
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wcauthenticationtypeentrygeneral.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV29Name)),UrlEncode(StringUtil.RTrim(AV53TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29Name", StringUtil.RTrim( wcpOAV29Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV53TypeId", StringUtil.RTrim( wcpOAV53TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV53TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLDATA_Title", StringUtil.RTrim( Tbldata_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLDATA_Collapsible", StringUtil.BoolToStr( Tbldata_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLDATA_Open", StringUtil.BoolToStr( Tbldata_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLDATA_Showborders", StringUtil.BoolToStr( Tbldata_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLDATA_Containseditableform", StringUtil.BoolToStr( Tbldata_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Title", StringUtil.RTrim( Tblimpersonate_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Collapsible", StringUtil.BoolToStr( Tblimpersonate_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Open", StringUtil.BoolToStr( Tblimpersonate_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Showborders", StringUtil.BoolToStr( Tblimpersonate_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Containseditableform", StringUtil.BoolToStr( Tblimpersonate_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLIMPERSONATE_Visible", StringUtil.BoolToStr( Tblimpersonate_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Title", StringUtil.RTrim( Tblenabletwofactorauth_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Collapsible", StringUtil.BoolToStr( Tblenabletwofactorauth_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Open", StringUtil.BoolToStr( Tblenabletwofactorauth_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Showborders", StringUtil.BoolToStr( Tblenabletwofactorauth_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Containseditableform", StringUtil.BoolToStr( Tblenabletwofactorauth_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLENABLETWOFACTORAUTH_Visible", StringUtil.BoolToStr( Tblenabletwofactorauth_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Title", StringUtil.RTrim( Tbltwofactorauthentication_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Collapsible", StringUtil.BoolToStr( Tbltwofactorauthentication_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Open", StringUtil.BoolToStr( Tbltwofactorauthentication_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Showborders", StringUtil.BoolToStr( Tbltwofactorauthentication_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Containseditableform", StringUtil.BoolToStr( Tbltwofactorauthentication_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWOFACTORAUTHENTICATION_Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Title", StringUtil.RTrim( Tblotpauthentication_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Collapsible", StringUtil.BoolToStr( Tblotpauthentication_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Open", StringUtil.BoolToStr( Tblotpauthentication_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Showborders", StringUtil.BoolToStr( Tblotpauthentication_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Containseditableform", StringUtil.BoolToStr( Tblotpauthentication_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLOTPAUTHENTICATION_Visible", StringUtil.BoolToStr( Tblotpauthentication_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Title", StringUtil.RTrim( Tblclientidsecret_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Collapsible", StringUtil.BoolToStr( Tblclientidsecret_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Open", StringUtil.BoolToStr( Tblclientidsecret_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Showborders", StringUtil.BoolToStr( Tblclientidsecret_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Containseditableform", StringUtil.BoolToStr( Tblclientidsecret_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTIDSECRET_Visible", StringUtil.BoolToStr( Tblclientidsecret_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Title", StringUtil.RTrim( Tblclientlocalserver_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Collapsible", StringUtil.BoolToStr( Tblclientlocalserver_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Open", StringUtil.BoolToStr( Tblclientlocalserver_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Showborders", StringUtil.BoolToStr( Tblclientlocalserver_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Containseditableform", StringUtil.BoolToStr( Tblclientlocalserver_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCLIENTLOCALSERVER_Visible", StringUtil.BoolToStr( Tblclientlocalserver_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCUSTOMCALLBACKURL_Title", StringUtil.RTrim( Tblcustomcallbackurl_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCUSTOMCALLBACKURL_Collapsible", StringUtil.BoolToStr( Tblcustomcallbackurl_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCUSTOMCALLBACKURL_Open", StringUtil.BoolToStr( Tblcustomcallbackurl_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCUSTOMCALLBACKURL_Showborders", StringUtil.BoolToStr( Tblcustomcallbackurl_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCUSTOMCALLBACKURL_Containseditableform", StringUtil.BoolToStr( Tblcustomcallbackurl_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Title", StringUtil.RTrim( Tbltwitter_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Collapsible", StringUtil.BoolToStr( Tbltwitter_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Open", StringUtil.BoolToStr( Tbltwitter_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Showborders", StringUtil.BoolToStr( Tbltwitter_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Containseditableform", StringUtil.BoolToStr( Tbltwitter_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLTWITTER_Visible", StringUtil.BoolToStr( Tbltwitter_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Title", StringUtil.RTrim( Tblscopes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Collapsible", StringUtil.BoolToStr( Tblscopes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Open", StringUtil.BoolToStr( Tblscopes_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Showborders", StringUtil.BoolToStr( Tblscopes_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Containseditableform", StringUtil.BoolToStr( Tblscopes_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSCOPES_Visible", StringUtil.BoolToStr( Tblscopes_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Title", StringUtil.RTrim( Tblcommonadditional_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Collapsible", StringUtil.BoolToStr( Tblcommonadditional_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Open", StringUtil.BoolToStr( Tblcommonadditional_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Showborders", StringUtil.BoolToStr( Tblcommonadditional_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Containseditableform", StringUtil.BoolToStr( Tblcommonadditional_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLCOMMONADDITIONAL_Visible", StringUtil.BoolToStr( Tblcommonadditional_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Title", StringUtil.RTrim( Tblauthtypename_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Collapsible", StringUtil.BoolToStr( Tblauthtypename_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Open", StringUtil.BoolToStr( Tblauthtypename_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Showborders", StringUtil.BoolToStr( Tblauthtypename_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Containseditableform", StringUtil.BoolToStr( Tblauthtypename_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLAUTHTYPENAME_Visible", StringUtil.BoolToStr( Tblauthtypename_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Title", StringUtil.RTrim( Tblserverhost_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Collapsible", StringUtil.BoolToStr( Tblserverhost_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Open", StringUtil.BoolToStr( Tblserverhost_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Showborders", StringUtil.BoolToStr( Tblserverhost_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Containseditableform", StringUtil.BoolToStr( Tblserverhost_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLSERVERHOST_Visible", StringUtil.BoolToStr( Tblserverhost_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Title", StringUtil.RTrim( Tblwebservice_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Collapsible", StringUtil.BoolToStr( Tblwebservice_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Open", StringUtil.BoolToStr( Tblwebservice_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Showborders", StringUtil.BoolToStr( Tblwebservice_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Containseditableform", StringUtil.BoolToStr( Tblwebservice_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLWEBSERVICE_Visible", StringUtil.BoolToStr( Tblwebservice_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Title", StringUtil.RTrim( Tblexternal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Collapsible", StringUtil.BoolToStr( Tblexternal_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Open", StringUtil.BoolToStr( Tblexternal_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Showborders", StringUtil.BoolToStr( Tblexternal_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Containseditableform", StringUtil.BoolToStr( Tblexternal_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBLEXTERNAL_Visible", StringUtil.BoolToStr( Tblexternal_Visible));
      }

      protected void RenderHtmlCloseForm3T2( )
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
         return "K2BFSG.WCAuthenticationTypeEntryGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Authentication type" ;
      }

      protected void WB3T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wcauthenticationtypeentrygeneral.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", divContenttable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTbldata.SetProperty("Title", Tbldata_Title);
            ucTbldata.SetProperty("Collapsible", Tbldata_Collapsible);
            ucTbldata.SetProperty("Open", Tbldata_Open);
            ucTbldata.SetProperty("ShowBorders", Tbldata_Showborders);
            ucTbldata.SetProperty("ContainsEditableForm", Tbldata_Containseditableform);
            ucTbldata.Render(context, "k2bt_component", Tbldata_Internalname, sPrefix+"TBLDATAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLDATAContainer"+"Tbldata_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbldata_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbldata_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tbldata_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV29Name), StringUtil.RTrim( context.localUtil.Format( AV29Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_label_element( context, cmbavFunctionid_Internalname, "Function", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV21FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV21FunctionId);
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
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, "Enabled?", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV27IsEnable), "", "Enabled?", 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(33, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,33);\"");
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
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Description", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV20Dsc), StringUtil.RTrim( context.localUtil.Format( AV20Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtavSmallimagename_Internalname, "Small image name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV31SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV31SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtavBigimagename_Internalname, "Big image name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV9BigImageName), StringUtil.RTrim( context.localUtil.Format( AV9BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblimpersonate.SetProperty("Title", Tblimpersonate_Title);
            ucTblimpersonate.SetProperty("Collapsible", Tblimpersonate_Collapsible);
            ucTblimpersonate.SetProperty("Open", Tblimpersonate_Open);
            ucTblimpersonate.SetProperty("ShowBorders", Tblimpersonate_Showborders);
            ucTblimpersonate.SetProperty("ContainsEditableForm", Tblimpersonate_Containseditableform);
            ucTblimpersonate.Render(context, "k2bt_component", Tblimpersonate_Internalname, sPrefix+"TBLIMPERSONATEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLIMPERSONATEContainer"+"Tblimpersonate_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblimpersonate_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblimpersonate_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblimpersonate_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_impersonate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavImpersonate_Internalname, "Impersonate", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavImpersonate, cmbavImpersonate_Internalname, StringUtil.RTrim( AV26Impersonate), 1, cmbavImpersonate_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavImpersonate.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV26Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", (string)(cmbavImpersonate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblenabletwofactorauth.SetProperty("Title", Tblenabletwofactorauth_Title);
            ucTblenabletwofactorauth.SetProperty("Collapsible", Tblenabletwofactorauth_Collapsible);
            ucTblenabletwofactorauth.SetProperty("Open", Tblenabletwofactorauth_Open);
            ucTblenabletwofactorauth.SetProperty("ShowBorders", Tblenabletwofactorauth_Showborders);
            ucTblenabletwofactorauth.SetProperty("ContainsEditableForm", Tblenabletwofactorauth_Containseditableform);
            ucTblenabletwofactorauth.Render(context, "k2bt_component", Tblenabletwofactorauth_Internalname, sPrefix+"TBLENABLETWOFACTORAUTHContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLENABLETWOFACTORAUTHContainer"+"Tblenabletwofactorauth_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblenabletwofactorauth_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblenabletwofactorauth_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tfaenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTfaenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTfaenable_Internalname, "TFA Enable", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTfaenable_Internalname, StringUtil.BoolToStr( AV60TFAEnable), "", "TFA Enable", 1, chkavTfaenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,78);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTbltwofactorauthentication.SetProperty("Title", Tbltwofactorauthentication_Title);
            ucTbltwofactorauthentication.SetProperty("Collapsible", Tbltwofactorauthentication_Collapsible);
            ucTbltwofactorauthentication.SetProperty("Open", Tbltwofactorauthentication_Open);
            ucTbltwofactorauthentication.SetProperty("ShowBorders", Tbltwofactorauthentication_Showborders);
            ucTbltwofactorauthentication.SetProperty("ContainsEditableForm", Tbltwofactorauthentication_Containseditableform);
            ucTbltwofactorauthentication.Render(context, "k2bt_component", Tbltwofactorauthentication_Internalname, sPrefix+"TBLTWOFACTORAUTHENTICATIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLTWOFACTORAUTHENTICATIONContainer"+"Tbltwofactorauthentication_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbltwofactorauthentication_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbltwofactorauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tfaauthenticationtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavTfaauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTfaauthenticationtypename_Internalname, "Authentication type name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTfaauthenticationtypename, cmbavTfaauthenticationtypename_Internalname, StringUtil.RTrim( AV61TFAAuthenticationTypeName), 1, cmbavTfaauthenticationtypename_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTfaauthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavTfaauthenticationtypename.CurrentValue = StringUtil.RTrim( AV61TFAAuthenticationTypeName);
            AssignProp(sPrefix, false, cmbavTfaauthenticationtypename_Internalname, "Values", (string)(cmbavTfaauthenticationtypename.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_tfafirstfactorauthenticationexpiration_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTfafirstfactorauthenticationexpiration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTfafirstfactorauthenticationexpiration_Internalname, "First factor authentication expiration (seconds)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTfafirstfactorauthenticationexpiration_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), "ZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTfafirstfactorauthenticationexpiration_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTfafirstfactorauthenticationexpiration_Enabled, 1, "text", "1", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "K2BTools\\K2BT_LargeId", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tfaforceforallusers_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTfaforceforallusers_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTfaforceforallusers_Internalname, "Force 2FA for all users?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTfaforceforallusers_Internalname, StringUtil.BoolToStr( AV63TFAForceForAllUsers), "", "Force 2FA for all users?", 1, chkavTfaforceforallusers.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblotpauthentication.SetProperty("Title", Tblotpauthentication_Title);
            ucTblotpauthentication.SetProperty("Collapsible", Tblotpauthentication_Collapsible);
            ucTblotpauthentication.SetProperty("Open", Tblotpauthentication_Open);
            ucTblotpauthentication.SetProperty("ShowBorders", Tblotpauthentication_Showborders);
            ucTblotpauthentication.SetProperty("ContainsEditableForm", Tblotpauthentication_Containseditableform);
            ucTblotpauthentication.Render(context, "k2bt_component", Tblotpauthentication_Internalname, sPrefix+"TBLOTPAUTHENTICATIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLOTPAUTHENTICATIONContainer"+"Tblotpauthentication_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblotpauthentication_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblotpauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpuseforfirstfactorauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavOtpuseforfirstfactorauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOtpuseforfirstfactorauthentication_Internalname, "Use for first factor authentication?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOtpuseforfirstfactorauthentication_Internalname, StringUtil.BoolToStr( AV64OTPUseForFirstFactorAuthentication), "", "Use for first factor authentication?", 1, chkavOtpuseforfirstfactorauthentication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
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
            GxWebStd.gx_div_start( context, divTblotpconfiguration_Internalname, divTblotpconfiguration_Visible, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpeventvalidateuser_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavOtpeventvalidateuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOtpeventvalidateuser_Internalname, "User validation event", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOtpeventvalidateuser, cmbavOtpeventvalidateuser_Internalname, StringUtil.RTrim( AV65OTPEventValidateUser), 1, cmbavOtpeventvalidateuser_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOtpeventvalidateuser.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavOtpeventvalidateuser.CurrentValue = StringUtil.RTrim( AV65OTPEventValidateUser);
            AssignProp(sPrefix, false, cmbavOtpeventvalidateuser_Internalname, "Values", (string)(cmbavOtpeventvalidateuser.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_otpgenerationtype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavOtpgenerationtype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOtpgenerationtype_Internalname, "Code generation type", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOtpgenerationtype, cmbavOtpgenerationtype_Internalname, StringUtil.RTrim( AV66OTPGenerationType), 1, cmbavOtpgenerationtype_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVOTPGENERATIONTYPE.CLICK."+"'", "svchar", "", 1, cmbavOtpgenerationtype.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavOtpgenerationtype.CurrentValue = StringUtil.RTrim( AV66OTPGenerationType);
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_Internalname, "Values", (string)(cmbavOtpgenerationtype.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblotpcustom_Internalname, divTblotpcustom_Visible, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpgenerationtype_customeventgeneratecode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavOtpgenerationtype_customeventgeneratecode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, "Event to generate OTP Custom", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOtpgenerationtype_customeventgeneratecode, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, StringUtil.RTrim( AV67OTPGenerationType_CustomEventGenerateCode), 1, cmbavOtpgenerationtype_customeventgeneratecode_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOtpgenerationtype_customeventgeneratecode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavOtpgenerationtype_customeventgeneratecode.CurrentValue = StringUtil.RTrim( AV67OTPGenerationType_CustomEventGenerateCode);
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, "Values", (string)(cmbavOtpgenerationtype_customeventgeneratecode.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTbltypeotpgeneratecode_Internalname, divTbltypeotpgeneratecode_Visible, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn3_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpautogeneratedcodelength_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpautogeneratedcodelength_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpautogeneratedcodelength_Internalname, "Autogenerated OTP code length", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpautogeneratedcodelength_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68OTPAutogeneratedCodeLength), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV68OTPAutogeneratedCodeLength), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,160);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpautogeneratedcodelength_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpautogeneratedcodelength_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpgeneratecodeonlynumbers_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavOtpgeneratecodeonlynumbers_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOtpgeneratecodeonlynumbers_Internalname, "Generate code only with numbers?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOtpgeneratecodeonlynumbers_Internalname, StringUtil.BoolToStr( AV69OTPGenerateCodeOnlyNumbers), "", "Generate code only with numbers?", 1, chkavOtpgeneratecodeonlynumbers.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(166, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,166);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_otpcodeexpirationtimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpcodeexpirationtimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpcodeexpirationtimeout_Internalname, "Code expiration timeout (seconds)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpcodeexpirationtimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70OTPCodeExpirationTimeout), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV70OTPCodeExpirationTimeout), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,172);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpcodeexpirationtimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpcodeexpirationtimeout_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "K2BTools\\K2BT_MediumId", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpmaximumdailynumbercodes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpmaximumdailynumbercodes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpmaximumdailynumbercodes_Internalname, "Maximum daily number of codes", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpmaximumdailynumbercodes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71OTPMaximumDailyNumberCodes), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV71OTPMaximumDailyNumberCodes), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,178);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpmaximumdailynumbercodes_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpmaximumdailynumbercodes_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpnumberunsuccessfulretriestolockotp_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpnumberunsuccessfulretriestolockotp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpnumberunsuccessfulretriestolockotp_Internalname, "Number of unsuccessful retries to lock the OTP", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpnumberunsuccessfulretriestolockotp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72OTPNumberUnsuccessfulRetriesToLockOTP), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV72OTPNumberUnsuccessfulRetriesToLockOTP), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,184);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpnumberunsuccessfulretriestolockotp_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpnumberunsuccessfulretriestolockotp_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpautounlocktime_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpautounlocktime_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpautounlocktime_Internalname, "Automatic OTP unlock time (minutes)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpautounlocktime_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73OTPAutoUnlockTime), 15, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV73OTPAutoUnlockTime), "ZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,190);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpautounlocktime_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpautounlocktime_Enabled, 1, "text", "1", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "K2BTools\\K2BT_LargeId", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname, "Number of unsuccessful retries to block user based on number of OTP locks", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,196);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpeventsendcode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavOtpeventsendcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOtpeventsendcode_Internalname, "Send code using", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOtpeventsendcode, cmbavOtpeventsendcode_Internalname, StringUtil.RTrim( AV75OTPEventSendCode), 1, cmbavOtpeventsendcode_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOtpeventsendcode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavOtpeventsendcode.CurrentValue = StringUtil.RTrim( AV75OTPEventSendCode);
            AssignProp(sPrefix, false, cmbavOtpeventsendcode_Internalname, "Values", (string)(cmbavOtpeventsendcode.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblsendemailbygam_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn4_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpmailmessagesubject_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpmailmessagesubject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpmailmessagesubject_Internalname, "Mail message subject", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpmailmessagesubject_Internalname, StringUtil.RTrim( AV76OTPMailMessageSubject), StringUtil.RTrim( context.localUtil.Format( AV76OTPMailMessageSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,214);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpmailmessagesubject_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpmailmessagesubject_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpmailmessagebodyhtml_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpmailmessagebodyhtml_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpmailmessagebodyhtml_Internalname, "Mail message HTML text", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavOtpmailmessagebodyhtml_Internalname, AV77OTPMailMessageBodyHTML, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,220);\"", 0, 1, edtavOtpmailmessagebodyhtml_Enabled, 1, 300, "chr", 5, "row", 0, StyleString, ClassString, "", "", "2048", 1, 0, "", "", 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpeventvalidatecode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavOtpeventvalidatecode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOtpeventvalidatecode_Internalname, "Validate code using", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOtpeventvalidatecode, cmbavOtpeventvalidatecode_Internalname, StringUtil.RTrim( AV78OTPEventValidateCode), 1, cmbavOtpeventvalidatecode_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOtpeventvalidatecode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,226);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavOtpeventvalidatecode.CurrentValue = StringUtil.RTrim( AV78OTPEventValidateCode);
            AssignProp(sPrefix, false, cmbavOtpeventvalidatecode_Internalname, "Values", (string)(cmbavOtpeventvalidatecode.ToJavascriptSource()), true);
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
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTblclientidsecret.SetProperty("Title", Tblclientidsecret_Title);
            ucTblclientidsecret.SetProperty("Collapsible", Tblclientidsecret_Collapsible);
            ucTblclientidsecret.SetProperty("Open", Tblclientidsecret_Open);
            ucTblclientidsecret.SetProperty("ShowBorders", Tblclientidsecret_Showborders);
            ucTblclientidsecret.SetProperty("ContainsEditableForm", Tblclientidsecret_Containseditableform);
            ucTblclientidsecret.Render(context, "k2bt_component", Tblclientidsecret_Internalname, sPrefix+"TBLCLIENTIDSECRETContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLCLIENTIDSECRETContainer"+"Tblclientidsecret_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblclientidsecret_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblclientidsecret_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblclientidsecret_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavClientid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientid_Internalname, "Client ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 240,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, AV11ClientId, StringUtil.RTrim( context.localUtil.Format( AV11ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,240);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_clientsecret_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavClientsecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientsecret_Internalname, "Client secret", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 245,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, AV12ClientSecret, StringUtil.RTrim( context.localUtil.Format( AV12ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,245);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_versionpath_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavVersionpath_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavVersionpath_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVersionpath_Internalname, "Version path", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVersionpath_Internalname, StringUtil.RTrim( AV55VersionPath), StringUtil.RTrim( context.localUtil.Format( AV55VersionPath, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVersionpath_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavVersionpath_Visible, edtavVersionpath_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblclientlocalserver.SetProperty("Title", Tblclientlocalserver_Title);
            ucTblclientlocalserver.SetProperty("Collapsible", Tblclientlocalserver_Collapsible);
            ucTblclientlocalserver.SetProperty("Open", Tblclientlocalserver_Open);
            ucTblclientlocalserver.SetProperty("ShowBorders", Tblclientlocalserver_Showborders);
            ucTblclientlocalserver.SetProperty("ContainsEditableForm", Tblclientlocalserver_Containseditableform);
            ucTblclientlocalserver.Render(context, "k2bt_component", Tblclientlocalserver_Internalname, sPrefix+"TBLCLIENTLOCALSERVERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLCLIENTLOCALSERVERContainer"+"Tblclientlocalserver_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblclientlocalserver_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblclientlocalserver_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblclientlocalserver_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_siteurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavSiteurl_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavSiteurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSiteurl_Internalname, "Local site URL", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 265,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSiteurl_Internalname, AV30SiteURL, StringUtil.RTrim( context.localUtil.Format( AV30SiteURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,265);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSiteurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavSiteurl_Visible, edtavSiteurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblcustomcallbackurl.SetProperty("Title", Tblcustomcallbackurl_Title);
            ucTblcustomcallbackurl.SetProperty("Collapsible", Tblcustomcallbackurl_Collapsible);
            ucTblcustomcallbackurl.SetProperty("Open", Tblcustomcallbackurl_Open);
            ucTblcustomcallbackurl.SetProperty("ShowBorders", Tblcustomcallbackurl_Showborders);
            ucTblcustomcallbackurl.SetProperty("ContainsEditableForm", Tblcustomcallbackurl_Containseditableform);
            ucTblcustomcallbackurl.Render(context, "k2bt_component", Tblcustomcallbackurl_Internalname, sPrefix+"TBLCUSTOMCALLBACKURLContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLCUSTOMCALLBACKURLContainer"+"Tblcustomcallbackurl_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblcustomcallbackurl_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblcustomcallbackurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_siteurlcallbackiscustom_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavSiteurlcallbackiscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSiteurlcallbackiscustom_Internalname, "Custom callback URL?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 279,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSiteurlcallbackiscustom_Internalname, StringUtil.BoolToStr( AV79SiteURLCallbackIsCustom), "", "Custom callback URL?", 1, chkavSiteurlcallbackiscustom.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(279, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,279);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTbltwitter.SetProperty("Title", Tbltwitter_Title);
            ucTbltwitter.SetProperty("Collapsible", Tbltwitter_Collapsible);
            ucTbltwitter.SetProperty("Open", Tbltwitter_Open);
            ucTbltwitter.SetProperty("ShowBorders", Tbltwitter_Showborders);
            ucTbltwitter.SetProperty("ContainsEditableForm", Tbltwitter_Containseditableform);
            ucTbltwitter.Render(context, "k2bt_component", Tbltwitter_Internalname, sPrefix+"TBLTWITTERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLTWITTERContainer"+"Tbltwitter_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbltwitter_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbltwitter_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tbltwitter_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_consumerkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConsumerkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumerkey_Internalname, "Consumer key", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 293,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumerkey_Internalname, StringUtil.RTrim( AV13ConsumerKey), StringUtil.RTrim( context.localUtil.Format( AV13ConsumerKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,293);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumerkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConsumerkey_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_consumersecret_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConsumersecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumersecret_Internalname, "Consumer secret", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 298,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumersecret_Internalname, StringUtil.RTrim( AV14ConsumerSecret), StringUtil.RTrim( context.localUtil.Format( AV14ConsumerSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,298);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumersecret_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConsumersecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_callbackurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavCallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCallbackurl_Internalname, "Callback URL", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 303,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCallbackurl_Internalname, AV10CallbackURL, StringUtil.RTrim( context.localUtil.Format( AV10CallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,303);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCallbackurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCallbackurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblscopes.SetProperty("Title", Tblscopes_Title);
            ucTblscopes.SetProperty("Collapsible", Tblscopes_Collapsible);
            ucTblscopes.SetProperty("Open", Tblscopes_Open);
            ucTblscopes.SetProperty("ShowBorders", Tblscopes_Showborders);
            ucTblscopes.SetProperty("ContainsEditableForm", Tblscopes_Containseditableform);
            ucTblscopes.Render(context, "k2bt_component", Tblscopes_Internalname, sPrefix+"TBLSCOPESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLSCOPESContainer"+"Tblscopes_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblscopes_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblscopes_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblscopes_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_adduseradditionaldatascope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAdduseradditionaldatascope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAdduseradditionaldatascope_Internalname, "Add gam_user_additional_data scope", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 317,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAdduseradditionaldatascope_Internalname, StringUtil.BoolToStr( AV56AddUserAdditionalDataScope), "", "Add gam_user_additional_data scope", 1, chkavAdduseradditionaldatascope.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(317, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,317);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_addinitialpropertiesscope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAddinitialpropertiesscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAddinitialpropertiesscope_Internalname, "Add gam_session_initial_prop scope", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 322,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAddinitialpropertiesscope_Internalname, StringUtil.BoolToStr( AV57AddInitialPropertiesScope), "", "Add gam_session_initial_prop scope", 1, chkavAddinitialpropertiesscope.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(322, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,322);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblcommonadditional.SetProperty("Title", Tblcommonadditional_Title);
            ucTblcommonadditional.SetProperty("Collapsible", Tblcommonadditional_Collapsible);
            ucTblcommonadditional.SetProperty("Open", Tblcommonadditional_Open);
            ucTblcommonadditional.SetProperty("ShowBorders", Tblcommonadditional_Showborders);
            ucTblcommonadditional.SetProperty("ContainsEditableForm", Tblcommonadditional_Containseditableform);
            ucTblcommonadditional.Render(context, "k2bt_component", Tblcommonadditional_Internalname, sPrefix+"TBLCOMMONADDITIONALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLCOMMONADDITIONALContainer"+"Tblcommonadditional_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblcommonadditional_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblcommonadditional_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblcommonadditional_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_additionalscope_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAdditionalscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdditionalscope_Internalname, "Additional scope", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 336,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdditionalscope_Internalname, AV8AdditionalScope, StringUtil.RTrim( context.localUtil.Format( AV8AdditionalScope, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,336);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdditionalscope_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAdditionalscope_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblauthtypename.SetProperty("Title", Tblauthtypename_Title);
            ucTblauthtypename.SetProperty("Collapsible", Tblauthtypename_Collapsible);
            ucTblauthtypename.SetProperty("Open", Tblauthtypename_Open);
            ucTblauthtypename.SetProperty("ShowBorders", Tblauthtypename_Showborders);
            ucTblauthtypename.SetProperty("ContainsEditableForm", Tblauthtypename_Containseditableform);
            ucTblauthtypename.Render(context, "k2bt_component", Tblauthtypename_Internalname, sPrefix+"TBLAUTHTYPENAMEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLAUTHTYPENAMEContainer"+"Tblauthtypename_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblauthtypename_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblauthtypename_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblauthtypename_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrauthenticationtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamrauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrauthenticationtypename_Internalname, "Remote server authentication type name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 350,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrauthenticationtypename_Internalname, StringUtil.RTrim( AV58GAMRAuthenticationTypeName), StringUtil.RTrim( context.localUtil.Format( AV58GAMRAuthenticationTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,350);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrauthenticationtypename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrauthenticationtypename_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblserverhost.SetProperty("Title", Tblserverhost_Title);
            ucTblserverhost.SetProperty("Collapsible", Tblserverhost_Collapsible);
            ucTblserverhost.SetProperty("Open", Tblserverhost_Open);
            ucTblserverhost.SetProperty("ShowBorders", Tblserverhost_Showborders);
            ucTblserverhost.SetProperty("ContainsEditableForm", Tblserverhost_Containseditableform);
            ucTblserverhost.Render(context, "k2bt_component", Tblserverhost_Internalname, sPrefix+"TBLSERVERHOSTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLSERVERHOSTContainer"+"Tblserverhost_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblserverhost_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblserverhost_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblserverhost_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrserverurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamrserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrserverurl_Internalname, "Remote server URL", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 364,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrserverurl_Internalname, AV24GAMRServerURL, StringUtil.RTrim( context.localUtil.Format( AV24GAMRServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,364);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrserverurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamrprivateencryptkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrprivateencryptkey_Internalname, "Private encryption key", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 369,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrprivateencryptkey_Internalname, StringUtil.RTrim( AV22GAMRPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV22GAMRPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,369);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamrrepositoryguid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamrrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrrepositoryguid_Internalname, "Repository GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 374,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrrepositoryguid_Internalname, StringUtil.RTrim( AV23GAMRRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV23GAMRRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,374);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrrepositoryguid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamrrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_autovalidateexternaltokenandrefresh_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAutovalidateexternaltokenandrefresh_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAutovalidateexternaltokenandrefresh_Internalname, "Validate external token", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 380,'" + sPrefix + "',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutovalidateexternaltokenandrefresh_Internalname, StringUtil.BoolToStr( AV59AutovalidateExternalTokenAndRefresh), "", "Validate external token", 1, chkavAutovalidateexternaltokenandrefresh.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(380, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,380);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblwebservice.SetProperty("Title", Tblwebservice_Title);
            ucTblwebservice.SetProperty("Collapsible", Tblwebservice_Collapsible);
            ucTblwebservice.SetProperty("Open", Tblwebservice_Open);
            ucTblwebservice.SetProperty("ShowBorders", Tblwebservice_Showborders);
            ucTblwebservice.SetProperty("ContainsEditableForm", Tblwebservice_Containseditableform);
            ucTblwebservice.Render(context, "k2bt_component", Tblwebservice_Internalname, sPrefix+"TBLWEBSERVICEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLWEBSERVICEContainer"+"Tblwebservice_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblwebservice_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblwebservice_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblwebservice_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavWsversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsversion_Internalname, "Web service version", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 394,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsversion, cmbavWsversion_Internalname, StringUtil.RTrim( AV44WSVersion), 1, cmbavWsversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavWsversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,394);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV44WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", (string)(cmbavWsversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_wsprivateencryptkey_Internalname, " Private encryption key", "", "", lblTextblock_var_wsprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsprivateencryptkeycellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsprivateencryptkey_Internalname, " Private encryption key", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 400,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsprivateencryptkey_Internalname, StringUtil.RTrim( AV38WSPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV38WSPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,400);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 401,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenkey_Internalname, "", "Generate key", bttBtngenkey_Jsonclick, 5, "", "", StyleString, ClassString, bttBtngenkey_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_BTNGENKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsservername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWsservername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsservername_Internalname, "Server name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 407,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsservername_Internalname, StringUtil.RTrim( AV40WSServerName), StringUtil.RTrim( context.localUtil.Format( AV40WSServerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,407);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavWsservername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsservername_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsserverport_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWsserverport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverport_Internalname, "Port", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 412,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41WSServerPort), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41WSServerPort), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,412);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Server Port", edtavWsserverport_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsserverport_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsserverbaseurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWsserverbaseurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverbaseurl_Internalname, "Base URL", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 417,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverbaseurl_Internalname, StringUtil.RTrim( AV39WSServerBaseURL), StringUtil.RTrim( context.localUtil.Format( AV39WSServerBaseURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,417);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsserverbaseurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsserverbaseurl_Enabled, 1, "text", "", 120, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_wsserversecureprotocol_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavWsserversecureprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsserversecureprotocol_Internalname, "Secure protocol", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 423,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsserversecureprotocol, cmbavWsserversecureprotocol_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42WSServerSecureProtocol), 4, 0)), 1, cmbavWsserversecureprotocol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavWsserversecureprotocol.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,423);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42WSServerSecureProtocol), 4, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", (string)(cmbavWsserversecureprotocol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wstimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWstimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWstimeout_Internalname, "Timeout (seconds)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 428,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWstimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43WSTimeout), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43WSTimeout), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,428);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWstimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWstimeout_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_wspackage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWspackage_Internalname, "Package", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 434,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWspackage_Internalname, StringUtil.RTrim( AV37WSPackage), StringUtil.RTrim( context.localUtil.Format( AV37WSPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,434);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWspackage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWsname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsname_Internalname, "Name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 439,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsname_Internalname, StringUtil.RTrim( AV36WSName), StringUtil.RTrim( context.localUtil.Format( AV36WSName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,439);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_wsextension_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWsextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsextension_Internalname, "Extension", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 444,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsextension_Internalname, StringUtil.RTrim( AV35WSExtension), StringUtil.RTrim( context.localUtil.Format( AV35WSExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,444);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsextension_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWsextension_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTblexternal.SetProperty("Title", Tblexternal_Title);
            ucTblexternal.SetProperty("Collapsible", Tblexternal_Collapsible);
            ucTblexternal.SetProperty("Open", Tblexternal_Open);
            ucTblexternal.SetProperty("ShowBorders", Tblexternal_Showborders);
            ucTblexternal.SetProperty("ContainsEditableForm", Tblexternal_Containseditableform);
            ucTblexternal.Render(context, "k2bt_component", Tblexternal_Internalname, sPrefix+"TBLEXTERNALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBLEXTERNALContainer"+"Tblexternal_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblexternal_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblexternal_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblexternal_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavCusversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCusversion_Internalname, "JSON Version", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 458,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCusversion, cmbavCusversion_Internalname, StringUtil.RTrim( AV19CusVersion), 1, cmbavCusversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavCusversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,458);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV19CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", (string)(cmbavCusversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_cusprivateencryptkey_Internalname, "Private encryption key", "", "", lblTextblock_var_cusprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusprivateencryptkeycellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusprivateencryptkey_Internalname, "Private encryption key", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 464,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusprivateencryptkey_Internalname, StringUtil.RTrim( AV18CusPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV18CusPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,464);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Private encryption key", edtavCusprivateencryptkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 465,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenkeycustom_Internalname, "", "Generate key", bttBtngenkeycustom_Jsonclick, 5, "", "", StyleString, ClassString, bttBtngenkeycustom_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_BTNGENKEYCUSTOM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusfilename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavCusfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusfilename_Internalname, "File name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 471,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusfilename_Internalname, StringUtil.RTrim( AV16CusFileName), StringUtil.RTrim( context.localUtil.Format( AV16CusFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,471);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusfilename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusfilename_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cuspackage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavCuspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuspackage_Internalname, "Package", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 476,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuspackage_Internalname, StringUtil.RTrim( AV17CusPackage), StringUtil.RTrim( context.localUtil.Format( AV17CusPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,476);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuspackage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCuspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_cusclassname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavCusclassname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusclassname_Internalname, "Class name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 481,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusclassname_Internalname, StringUtil.RTrim( AV15CusClassName), StringUtil.RTrim( context.localUtil.Format( AV15CusClassName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,481);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusclassname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavCusclassname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 489,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 491,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancel", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e113t1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WCAuthenticationTypeEntryGeneral.htm");
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
         wbLoad = true;
      }

      protected void START3T2( )
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
            Form.Meta.addItem("description", "Authentication type", 0) ;
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
               STRUP3T0( ) ;
            }
         }
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
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
                                 STRUP3T0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E123T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E133T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_BTNGENKEY'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_BtnGenKey' */
                                    E143T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_BTNGENKEYCUSTOM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_BtnGenKeyCustom' */
                                    E153T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Confirm' */
                                    E163T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTFAENABLE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E173T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VOTPGENERATIONTYPE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E183T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E193T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
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
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavFunctionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3T2( ) ;
            }
         }
      }

      protected void PA3T2( )
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
            AV21FunctionId = cmbavFunctionid.getValidValue(AV21FunctionId);
            AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV21FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV27IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV27IsEnable));
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         if ( cmbavImpersonate.ItemCount > 0 )
         {
            AV26Impersonate = cmbavImpersonate.getValidValue(AV26Impersonate);
            AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV26Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", cmbavImpersonate.ToJavascriptSource(), true);
         }
         AV60TFAEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV60TFAEnable));
         AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
         if ( cmbavTfaauthenticationtypename.ItemCount > 0 )
         {
            AV61TFAAuthenticationTypeName = cmbavTfaauthenticationtypename.getValidValue(AV61TFAAuthenticationTypeName);
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTfaauthenticationtypename.CurrentValue = StringUtil.RTrim( AV61TFAAuthenticationTypeName);
            AssignProp(sPrefix, false, cmbavTfaauthenticationtypename_Internalname, "Values", cmbavTfaauthenticationtypename.ToJavascriptSource(), true);
         }
         AV63TFAForceForAllUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV63TFAForceForAllUsers));
         AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
         AV64OTPUseForFirstFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV64OTPUseForFirstFactorAuthentication));
         AssignAttri(sPrefix, false, "AV64OTPUseForFirstFactorAuthentication", AV64OTPUseForFirstFactorAuthentication);
         if ( cmbavOtpeventvalidateuser.ItemCount > 0 )
         {
            AV65OTPEventValidateUser = cmbavOtpeventvalidateuser.getValidValue(AV65OTPEventValidateUser);
            AssignAttri(sPrefix, false, "AV65OTPEventValidateUser", AV65OTPEventValidateUser);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOtpeventvalidateuser.CurrentValue = StringUtil.RTrim( AV65OTPEventValidateUser);
            AssignProp(sPrefix, false, cmbavOtpeventvalidateuser_Internalname, "Values", cmbavOtpeventvalidateuser.ToJavascriptSource(), true);
         }
         if ( cmbavOtpgenerationtype.ItemCount > 0 )
         {
            AV66OTPGenerationType = cmbavOtpgenerationtype.getValidValue(AV66OTPGenerationType);
            AssignAttri(sPrefix, false, "AV66OTPGenerationType", AV66OTPGenerationType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOtpgenerationtype.CurrentValue = StringUtil.RTrim( AV66OTPGenerationType);
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_Internalname, "Values", cmbavOtpgenerationtype.ToJavascriptSource(), true);
         }
         if ( cmbavOtpgenerationtype_customeventgeneratecode.ItemCount > 0 )
         {
            AV67OTPGenerationType_CustomEventGenerateCode = cmbavOtpgenerationtype_customeventgeneratecode.getValidValue(AV67OTPGenerationType_CustomEventGenerateCode);
            AssignAttri(sPrefix, false, "AV67OTPGenerationType_CustomEventGenerateCode", AV67OTPGenerationType_CustomEventGenerateCode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOtpgenerationtype_customeventgeneratecode.CurrentValue = StringUtil.RTrim( AV67OTPGenerationType_CustomEventGenerateCode);
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, "Values", cmbavOtpgenerationtype_customeventgeneratecode.ToJavascriptSource(), true);
         }
         AV69OTPGenerateCodeOnlyNumbers = StringUtil.StrToBool( StringUtil.BoolToStr( AV69OTPGenerateCodeOnlyNumbers));
         AssignAttri(sPrefix, false, "AV69OTPGenerateCodeOnlyNumbers", AV69OTPGenerateCodeOnlyNumbers);
         if ( cmbavOtpeventsendcode.ItemCount > 0 )
         {
            AV75OTPEventSendCode = cmbavOtpeventsendcode.getValidValue(AV75OTPEventSendCode);
            AssignAttri(sPrefix, false, "AV75OTPEventSendCode", AV75OTPEventSendCode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOtpeventsendcode.CurrentValue = StringUtil.RTrim( AV75OTPEventSendCode);
            AssignProp(sPrefix, false, cmbavOtpeventsendcode_Internalname, "Values", cmbavOtpeventsendcode.ToJavascriptSource(), true);
         }
         if ( cmbavOtpeventvalidatecode.ItemCount > 0 )
         {
            AV78OTPEventValidateCode = cmbavOtpeventvalidatecode.getValidValue(AV78OTPEventValidateCode);
            AssignAttri(sPrefix, false, "AV78OTPEventValidateCode", AV78OTPEventValidateCode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOtpeventvalidatecode.CurrentValue = StringUtil.RTrim( AV78OTPEventValidateCode);
            AssignProp(sPrefix, false, cmbavOtpeventvalidatecode_Internalname, "Values", cmbavOtpeventvalidatecode.ToJavascriptSource(), true);
         }
         AV79SiteURLCallbackIsCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV79SiteURLCallbackIsCustom));
         AssignAttri(sPrefix, false, "AV79SiteURLCallbackIsCustom", AV79SiteURLCallbackIsCustom);
         AV56AddUserAdditionalDataScope = StringUtil.StrToBool( StringUtil.BoolToStr( AV56AddUserAdditionalDataScope));
         AssignAttri(sPrefix, false, "AV56AddUserAdditionalDataScope", AV56AddUserAdditionalDataScope);
         AV57AddInitialPropertiesScope = StringUtil.StrToBool( StringUtil.BoolToStr( AV57AddInitialPropertiesScope));
         AssignAttri(sPrefix, false, "AV57AddInitialPropertiesScope", AV57AddInitialPropertiesScope);
         AV59AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( StringUtil.BoolToStr( AV59AutovalidateExternalTokenAndRefresh));
         AssignAttri(sPrefix, false, "AV59AutovalidateExternalTokenAndRefresh", AV59AutovalidateExternalTokenAndRefresh);
         if ( cmbavWsversion.ItemCount > 0 )
         {
            AV44WSVersion = cmbavWsversion.getValidValue(AV44WSVersion);
            AssignAttri(sPrefix, false, "AV44WSVersion", AV44WSVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV44WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", cmbavWsversion.ToJavascriptSource(), true);
         }
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
            AV42WSServerSecureProtocol = (short)(Math.Round(NumberUtil.Val( cmbavWsserversecureprotocol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42WSServerSecureProtocol), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV42WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV42WSServerSecureProtocol), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42WSServerSecureProtocol), 4, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", cmbavWsserversecureprotocol.ToJavascriptSource(), true);
         }
         if ( cmbavCusversion.ItemCount > 0 )
         {
            AV19CusVersion = cmbavCusversion.getValidValue(AV19CusVersion);
            AssignAttri(sPrefix, false, "AV19CusVersion", AV19CusVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV19CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", cmbavCusversion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E133T2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E193T2 ();
            WB3T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV29Name = cgiGet( sPrefix+"wcpOAV29Name");
            wcpOAV53TypeId = cgiGet( sPrefix+"wcpOAV53TypeId");
            Gx_mode = cgiGet( sPrefix+"vMODE");
            Tbldata_Title = cgiGet( sPrefix+"TBLDATA_Title");
            Tbldata_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLDATA_Collapsible"));
            Tbldata_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLDATA_Open"));
            Tbldata_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLDATA_Showborders"));
            Tbldata_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLDATA_Containseditableform"));
            Tblimpersonate_Title = cgiGet( sPrefix+"TBLIMPERSONATE_Title");
            Tblimpersonate_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLIMPERSONATE_Collapsible"));
            Tblimpersonate_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLIMPERSONATE_Open"));
            Tblimpersonate_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLIMPERSONATE_Showborders"));
            Tblimpersonate_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLIMPERSONATE_Containseditableform"));
            Tblimpersonate_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLIMPERSONATE_Visible"));
            Tblenabletwofactorauth_Title = cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Title");
            Tblenabletwofactorauth_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Collapsible"));
            Tblenabletwofactorauth_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Open"));
            Tblenabletwofactorauth_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Showborders"));
            Tblenabletwofactorauth_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Containseditableform"));
            Tblenabletwofactorauth_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLENABLETWOFACTORAUTH_Visible"));
            Tbltwofactorauthentication_Title = cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Title");
            Tbltwofactorauthentication_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Collapsible"));
            Tbltwofactorauthentication_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Open"));
            Tbltwofactorauthentication_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Showborders"));
            Tbltwofactorauthentication_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Containseditableform"));
            Tbltwofactorauthentication_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWOFACTORAUTHENTICATION_Visible"));
            Tblotpauthentication_Title = cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Title");
            Tblotpauthentication_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Collapsible"));
            Tblotpauthentication_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Open"));
            Tblotpauthentication_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Showborders"));
            Tblotpauthentication_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Containseditableform"));
            Tblotpauthentication_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLOTPAUTHENTICATION_Visible"));
            Tblclientidsecret_Title = cgiGet( sPrefix+"TBLCLIENTIDSECRET_Title");
            Tblclientidsecret_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTIDSECRET_Collapsible"));
            Tblclientidsecret_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTIDSECRET_Open"));
            Tblclientidsecret_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTIDSECRET_Showborders"));
            Tblclientidsecret_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTIDSECRET_Containseditableform"));
            Tblclientidsecret_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTIDSECRET_Visible"));
            Tblclientlocalserver_Title = cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Title");
            Tblclientlocalserver_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Collapsible"));
            Tblclientlocalserver_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Open"));
            Tblclientlocalserver_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Showborders"));
            Tblclientlocalserver_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Containseditableform"));
            Tblclientlocalserver_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCLIENTLOCALSERVER_Visible"));
            Tblcustomcallbackurl_Title = cgiGet( sPrefix+"TBLCUSTOMCALLBACKURL_Title");
            Tblcustomcallbackurl_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCUSTOMCALLBACKURL_Collapsible"));
            Tblcustomcallbackurl_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCUSTOMCALLBACKURL_Open"));
            Tblcustomcallbackurl_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCUSTOMCALLBACKURL_Showborders"));
            Tblcustomcallbackurl_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCUSTOMCALLBACKURL_Containseditableform"));
            Tbltwitter_Title = cgiGet( sPrefix+"TBLTWITTER_Title");
            Tbltwitter_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWITTER_Collapsible"));
            Tbltwitter_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWITTER_Open"));
            Tbltwitter_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWITTER_Showborders"));
            Tbltwitter_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWITTER_Containseditableform"));
            Tbltwitter_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLTWITTER_Visible"));
            Tblscopes_Title = cgiGet( sPrefix+"TBLSCOPES_Title");
            Tblscopes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSCOPES_Collapsible"));
            Tblscopes_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSCOPES_Open"));
            Tblscopes_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSCOPES_Showborders"));
            Tblscopes_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSCOPES_Containseditableform"));
            Tblscopes_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSCOPES_Visible"));
            Tblcommonadditional_Title = cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Title");
            Tblcommonadditional_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Collapsible"));
            Tblcommonadditional_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Open"));
            Tblcommonadditional_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Showborders"));
            Tblcommonadditional_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Containseditableform"));
            Tblcommonadditional_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLCOMMONADDITIONAL_Visible"));
            Tblauthtypename_Title = cgiGet( sPrefix+"TBLAUTHTYPENAME_Title");
            Tblauthtypename_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLAUTHTYPENAME_Collapsible"));
            Tblauthtypename_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLAUTHTYPENAME_Open"));
            Tblauthtypename_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLAUTHTYPENAME_Showborders"));
            Tblauthtypename_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLAUTHTYPENAME_Containseditableform"));
            Tblauthtypename_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLAUTHTYPENAME_Visible"));
            Tblserverhost_Title = cgiGet( sPrefix+"TBLSERVERHOST_Title");
            Tblserverhost_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSERVERHOST_Collapsible"));
            Tblserverhost_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSERVERHOST_Open"));
            Tblserverhost_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSERVERHOST_Showborders"));
            Tblserverhost_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSERVERHOST_Containseditableform"));
            Tblserverhost_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLSERVERHOST_Visible"));
            Tblwebservice_Title = cgiGet( sPrefix+"TBLWEBSERVICE_Title");
            Tblwebservice_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLWEBSERVICE_Collapsible"));
            Tblwebservice_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLWEBSERVICE_Open"));
            Tblwebservice_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLWEBSERVICE_Showborders"));
            Tblwebservice_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLWEBSERVICE_Containseditableform"));
            Tblwebservice_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLWEBSERVICE_Visible"));
            Tblexternal_Title = cgiGet( sPrefix+"TBLEXTERNAL_Title");
            Tblexternal_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLEXTERNAL_Collapsible"));
            Tblexternal_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBLEXTERNAL_Open"));
            Tblexternal_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBLEXTERNAL_Showborders"));
            Tblexternal_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBLEXTERNAL_Containseditableform"));
            Tblexternal_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBLEXTERNAL_Visible"));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV29Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV29Name", AV29Name);
            }
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV21FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
            AV27IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
            AV20Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
            AV31SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
            AV9BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
            cmbavImpersonate.CurrentValue = cgiGet( cmbavImpersonate_Internalname);
            AV26Impersonate = cgiGet( cmbavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
            AV60TFAEnable = StringUtil.StrToBool( cgiGet( chkavTfaenable_Internalname));
            AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
            cmbavTfaauthenticationtypename.CurrentValue = cgiGet( cmbavTfaauthenticationtypename_Internalname);
            AV61TFAAuthenticationTypeName = cgiGet( cmbavTfaauthenticationtypename_Internalname);
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTfafirstfactorauthenticationexpiration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTfafirstfactorauthenticationexpiration_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTFAFIRSTFACTORAUTHENTICATIONEXPIRATION");
               GX_FocusControl = edtavTfafirstfactorauthenticationexpiration_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV62TFAFirstFactorAuthenticationExpiration = 0;
               AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            }
            else
            {
               AV62TFAFirstFactorAuthenticationExpiration = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavTfafirstfactorauthenticationexpiration_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            }
            AV63TFAForceForAllUsers = StringUtil.StrToBool( cgiGet( chkavTfaforceforallusers_Internalname));
            AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
            AV64OTPUseForFirstFactorAuthentication = StringUtil.StrToBool( cgiGet( chkavOtpuseforfirstfactorauthentication_Internalname));
            AssignAttri(sPrefix, false, "AV64OTPUseForFirstFactorAuthentication", AV64OTPUseForFirstFactorAuthentication);
            cmbavOtpeventvalidateuser.CurrentValue = cgiGet( cmbavOtpeventvalidateuser_Internalname);
            AV65OTPEventValidateUser = cgiGet( cmbavOtpeventvalidateuser_Internalname);
            AssignAttri(sPrefix, false, "AV65OTPEventValidateUser", AV65OTPEventValidateUser);
            cmbavOtpgenerationtype.CurrentValue = cgiGet( cmbavOtpgenerationtype_Internalname);
            AV66OTPGenerationType = cgiGet( cmbavOtpgenerationtype_Internalname);
            AssignAttri(sPrefix, false, "AV66OTPGenerationType", AV66OTPGenerationType);
            cmbavOtpgenerationtype_customeventgeneratecode.CurrentValue = cgiGet( cmbavOtpgenerationtype_customeventgeneratecode_Internalname);
            AV67OTPGenerationType_CustomEventGenerateCode = cgiGet( cmbavOtpgenerationtype_customeventgeneratecode_Internalname);
            AssignAttri(sPrefix, false, "AV67OTPGenerationType_CustomEventGenerateCode", AV67OTPGenerationType_CustomEventGenerateCode);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpautogeneratedcodelength_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpautogeneratedcodelength_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPAUTOGENERATEDCODELENGTH");
               GX_FocusControl = edtavOtpautogeneratedcodelength_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV68OTPAutogeneratedCodeLength = 0;
               AssignAttri(sPrefix, false, "AV68OTPAutogeneratedCodeLength", StringUtil.LTrimStr( (decimal)(AV68OTPAutogeneratedCodeLength), 4, 0));
            }
            else
            {
               AV68OTPAutogeneratedCodeLength = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpautogeneratedcodelength_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV68OTPAutogeneratedCodeLength", StringUtil.LTrimStr( (decimal)(AV68OTPAutogeneratedCodeLength), 4, 0));
            }
            AV69OTPGenerateCodeOnlyNumbers = StringUtil.StrToBool( cgiGet( chkavOtpgeneratecodeonlynumbers_Internalname));
            AssignAttri(sPrefix, false, "AV69OTPGenerateCodeOnlyNumbers", AV69OTPGenerateCodeOnlyNumbers);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpcodeexpirationtimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpcodeexpirationtimeout_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPCODEEXPIRATIONTIMEOUT");
               GX_FocusControl = edtavOtpcodeexpirationtimeout_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV70OTPCodeExpirationTimeout = 0;
               AssignAttri(sPrefix, false, "AV70OTPCodeExpirationTimeout", StringUtil.LTrimStr( (decimal)(AV70OTPCodeExpirationTimeout), 6, 0));
            }
            else
            {
               AV70OTPCodeExpirationTimeout = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpcodeexpirationtimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV70OTPCodeExpirationTimeout", StringUtil.LTrimStr( (decimal)(AV70OTPCodeExpirationTimeout), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpmaximumdailynumbercodes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpmaximumdailynumbercodes_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPMAXIMUMDAILYNUMBERCODES");
               GX_FocusControl = edtavOtpmaximumdailynumbercodes_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV71OTPMaximumDailyNumberCodes = 0;
               AssignAttri(sPrefix, false, "AV71OTPMaximumDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV71OTPMaximumDailyNumberCodes), 4, 0));
            }
            else
            {
               AV71OTPMaximumDailyNumberCodes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpmaximumdailynumbercodes_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV71OTPMaximumDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV71OTPMaximumDailyNumberCodes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestolockotp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestolockotp_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPNUMBERUNSUCCESSFULRETRIESTOLOCKOTP");
               GX_FocusControl = edtavOtpnumberunsuccessfulretriestolockotp_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV72OTPNumberUnsuccessfulRetriesToLockOTP = 0;
               AssignAttri(sPrefix, false, "AV72OTPNumberUnsuccessfulRetriesToLockOTP", StringUtil.LTrimStr( (decimal)(AV72OTPNumberUnsuccessfulRetriesToLockOTP), 4, 0));
            }
            else
            {
               AV72OTPNumberUnsuccessfulRetriesToLockOTP = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestolockotp_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV72OTPNumberUnsuccessfulRetriesToLockOTP", StringUtil.LTrimStr( (decimal)(AV72OTPNumberUnsuccessfulRetriesToLockOTP), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpautounlocktime_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpautounlocktime_Internalname), ".", ",") > Convert.ToDecimal( 999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPAUTOUNLOCKTIME");
               GX_FocusControl = edtavOtpautounlocktime_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV73OTPAutoUnlockTime = 0;
               AssignAttri(sPrefix, false, "AV73OTPAutoUnlockTime", StringUtil.LTrimStr( (decimal)(AV73OTPAutoUnlockTime), 15, 0));
            }
            else
            {
               AV73OTPAutoUnlockTime = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpautounlocktime_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV73OTPAutoUnlockTime", StringUtil.LTrimStr( (decimal)(AV73OTPAutoUnlockTime), 15, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPNUMBERUNSUCCESSFULRETRIESTOBLOCKUSERBASEDOFOTPLOCKS");
               GX_FocusControl = edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks = 0;
               AssignAttri(sPrefix, false, "AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks", StringUtil.LTrimStr( (decimal)(AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks), 4, 0));
            }
            else
            {
               AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks", StringUtil.LTrimStr( (decimal)(AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks), 4, 0));
            }
            cmbavOtpeventsendcode.CurrentValue = cgiGet( cmbavOtpeventsendcode_Internalname);
            AV75OTPEventSendCode = cgiGet( cmbavOtpeventsendcode_Internalname);
            AssignAttri(sPrefix, false, "AV75OTPEventSendCode", AV75OTPEventSendCode);
            AV76OTPMailMessageSubject = cgiGet( edtavOtpmailmessagesubject_Internalname);
            AssignAttri(sPrefix, false, "AV76OTPMailMessageSubject", AV76OTPMailMessageSubject);
            AV77OTPMailMessageBodyHTML = cgiGet( edtavOtpmailmessagebodyhtml_Internalname);
            AssignAttri(sPrefix, false, "AV77OTPMailMessageBodyHTML", AV77OTPMailMessageBodyHTML);
            cmbavOtpeventvalidatecode.CurrentValue = cgiGet( cmbavOtpeventvalidatecode_Internalname);
            AV78OTPEventValidateCode = cgiGet( cmbavOtpeventvalidatecode_Internalname);
            AssignAttri(sPrefix, false, "AV78OTPEventValidateCode", AV78OTPEventValidateCode);
            AV11ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
            AV12ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
            AV55VersionPath = cgiGet( edtavVersionpath_Internalname);
            AssignAttri(sPrefix, false, "AV55VersionPath", AV55VersionPath);
            AV30SiteURL = cgiGet( edtavSiteurl_Internalname);
            AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
            AV79SiteURLCallbackIsCustom = StringUtil.StrToBool( cgiGet( chkavSiteurlcallbackiscustom_Internalname));
            AssignAttri(sPrefix, false, "AV79SiteURLCallbackIsCustom", AV79SiteURLCallbackIsCustom);
            AV13ConsumerKey = cgiGet( edtavConsumerkey_Internalname);
            AssignAttri(sPrefix, false, "AV13ConsumerKey", AV13ConsumerKey);
            AV14ConsumerSecret = cgiGet( edtavConsumersecret_Internalname);
            AssignAttri(sPrefix, false, "AV14ConsumerSecret", AV14ConsumerSecret);
            AV10CallbackURL = cgiGet( edtavCallbackurl_Internalname);
            AssignAttri(sPrefix, false, "AV10CallbackURL", AV10CallbackURL);
            AV56AddUserAdditionalDataScope = StringUtil.StrToBool( cgiGet( chkavAdduseradditionaldatascope_Internalname));
            AssignAttri(sPrefix, false, "AV56AddUserAdditionalDataScope", AV56AddUserAdditionalDataScope);
            AV57AddInitialPropertiesScope = StringUtil.StrToBool( cgiGet( chkavAddinitialpropertiesscope_Internalname));
            AssignAttri(sPrefix, false, "AV57AddInitialPropertiesScope", AV57AddInitialPropertiesScope);
            AV8AdditionalScope = cgiGet( edtavAdditionalscope_Internalname);
            AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
            AV58GAMRAuthenticationTypeName = cgiGet( edtavGamrauthenticationtypename_Internalname);
            AssignAttri(sPrefix, false, "AV58GAMRAuthenticationTypeName", AV58GAMRAuthenticationTypeName);
            AV24GAMRServerURL = cgiGet( edtavGamrserverurl_Internalname);
            AssignAttri(sPrefix, false, "AV24GAMRServerURL", AV24GAMRServerURL);
            AV22GAMRPrivateEncryptKey = cgiGet( edtavGamrprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV22GAMRPrivateEncryptKey", AV22GAMRPrivateEncryptKey);
            AV23GAMRRepositoryGUID = cgiGet( edtavGamrrepositoryguid_Internalname);
            AssignAttri(sPrefix, false, "AV23GAMRRepositoryGUID", AV23GAMRRepositoryGUID);
            AV59AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( cgiGet( chkavAutovalidateexternaltokenandrefresh_Internalname));
            AssignAttri(sPrefix, false, "AV59AutovalidateExternalTokenAndRefresh", AV59AutovalidateExternalTokenAndRefresh);
            cmbavWsversion.CurrentValue = cgiGet( cmbavWsversion_Internalname);
            AV44WSVersion = cgiGet( cmbavWsversion_Internalname);
            AssignAttri(sPrefix, false, "AV44WSVersion", AV44WSVersion);
            AV38WSPrivateEncryptKey = cgiGet( edtavWsprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV38WSPrivateEncryptKey", AV38WSPrivateEncryptKey);
            AV40WSServerName = cgiGet( edtavWsservername_Internalname);
            AssignAttri(sPrefix, false, "AV40WSServerName", AV40WSServerName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSSERVERPORT");
               GX_FocusControl = edtavWsserverport_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41WSServerPort = 0;
               AssignAttri(sPrefix, false, "AV41WSServerPort", StringUtil.LTrimStr( (decimal)(AV41WSServerPort), 4, 0));
            }
            else
            {
               AV41WSServerPort = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV41WSServerPort", StringUtil.LTrimStr( (decimal)(AV41WSServerPort), 4, 0));
            }
            AV39WSServerBaseURL = cgiGet( edtavWsserverbaseurl_Internalname);
            AssignAttri(sPrefix, false, "AV39WSServerBaseURL", AV39WSServerBaseURL);
            cmbavWsserversecureprotocol.CurrentValue = cgiGet( cmbavWsserversecureprotocol_Internalname);
            AV42WSServerSecureProtocol = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWsserversecureprotocol_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV42WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV42WSServerSecureProtocol), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSTIMEOUT");
               GX_FocusControl = edtavWstimeout_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43WSTimeout = 0;
               AssignAttri(sPrefix, false, "AV43WSTimeout", StringUtil.LTrimStr( (decimal)(AV43WSTimeout), 4, 0));
            }
            else
            {
               AV43WSTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV43WSTimeout", StringUtil.LTrimStr( (decimal)(AV43WSTimeout), 4, 0));
            }
            AV37WSPackage = cgiGet( edtavWspackage_Internalname);
            AssignAttri(sPrefix, false, "AV37WSPackage", AV37WSPackage);
            AV36WSName = cgiGet( edtavWsname_Internalname);
            AssignAttri(sPrefix, false, "AV36WSName", AV36WSName);
            AV35WSExtension = cgiGet( edtavWsextension_Internalname);
            AssignAttri(sPrefix, false, "AV35WSExtension", AV35WSExtension);
            cmbavCusversion.CurrentValue = cgiGet( cmbavCusversion_Internalname);
            AV19CusVersion = cgiGet( cmbavCusversion_Internalname);
            AssignAttri(sPrefix, false, "AV19CusVersion", AV19CusVersion);
            AV18CusPrivateEncryptKey = cgiGet( edtavCusprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV18CusPrivateEncryptKey", AV18CusPrivateEncryptKey);
            AV16CusFileName = cgiGet( edtavCusfilename_Internalname);
            AssignAttri(sPrefix, false, "AV16CusFileName", AV16CusFileName);
            AV17CusPackage = cgiGet( edtavCuspackage_Internalname);
            AssignAttri(sPrefix, false, "AV17CusPackage", AV17CusPackage);
            AV15CusClassName = cgiGet( edtavCusclassname_Internalname);
            AssignAttri(sPrefix, false, "AV15CusClassName", AV15CusClassName);
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
         E123T2 ();
         if (returnInSub) return;
      }

      protected void E123T2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E133T2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         divAttributescontainertable_tbldata_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tbldata_Internalname, "Class", divAttributescontainertable_tbldata_Class, true);
         divAttributescontainertable_tblimpersonate_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblimpersonate_Internalname, "Class", divAttributescontainertable_tblimpersonate_Class, true);
         divAttributescontainertable_tblclientidsecret_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblclientidsecret_Internalname, "Class", divAttributescontainertable_tblclientidsecret_Class, true);
         divAttributescontainertable_tbltwitter_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tbltwitter_Internalname, "Class", divAttributescontainertable_tbltwitter_Class, true);
         divAttributescontainertable_tblcommonadditional_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblcommonadditional_Internalname, "Class", divAttributescontainertable_tblcommonadditional_Class, true);
         divAttributescontainertable_tblserverhost_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblserverhost_Internalname, "Class", divAttributescontainertable_tblserverhost_Class, true);
         divAttributescontainertable_tblwebservice_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblwebservice_Internalname, "Class", divAttributescontainertable_tblwebservice_Class, true);
         divAttributescontainertable_tblexternal_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblexternal_Internalname, "Class", divAttributescontainertable_tblexternal_Class, true);
         divAttributescontainertable_tblclientlocalserver_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblclientlocalserver_Internalname, "Class", divAttributescontainertable_tblclientlocalserver_Class, true);
         divAttributescontainertable_tblscopes_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblscopes_Internalname, "Class", divAttributescontainertable_tblscopes_Class, true);
         divAttributescontainertable_tblauthtypename_Class = "Section";
         AssignProp(sPrefix, false, divAttributescontainertable_tblauthtypename_Internalname, "Class", divAttributescontainertable_tblauthtypename_Class, true);
         divContenttable_Class = "Section";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtavName_Enabled = 1;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         }
         else
         {
            edtavName_Enabled = 0;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            AV21FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         }
         if ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEAPPLE' */
            S202 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPECUSTOM' */
            S212 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEEXTERNALWEBSERVICE' */
            S222 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEFACEBOOK' */
            S232 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEGAMLOCAL' */
            S242 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEGAMREMOTE' */
            S252 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEGAMREMOTEREST' */
            S262 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEGOOGLE' */
            S272 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEOTP' */
            S282 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPETWITTER' */
            S292 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 )
         {
            /* Execute user subroutine: 'INITAUTHENTICATIONTYPEWECHAT' */
            S302 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttConfirm_Visible = 0;
            AssignProp(sPrefix, false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            cmbavFunctionid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            bttBtngenkey_Visible = 0;
            AssignProp(sPrefix, false, bttBtngenkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenkey_Visible), 5, 0), true);
            bttBtngenkeycustom_Visible = 0;
            AssignProp(sPrefix, false, bttBtngenkeycustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenkeycustom_Visible), 5, 0), true);
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
            cmbavImpersonate.Enabled = 0;
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavImpersonate.Enabled), 5, 0), true);
            cmbavWsversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsversion.Enabled), 5, 0), true);
            edtavWsprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsprivateencryptkey_Enabled), 5, 0), true);
            edtavWsservername_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsservername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsservername_Enabled), 5, 0), true);
            edtavWsserverport_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverport_Enabled), 5, 0), true);
            edtavWsserverbaseurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverbaseurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverbaseurl_Enabled), 5, 0), true);
            cmbavWsserversecureprotocol.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsserversecureprotocol.Enabled), 5, 0), true);
            edtavWstimeout_Enabled = 0;
            AssignProp(sPrefix, false, edtavWstimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWstimeout_Enabled), 5, 0), true);
            edtavWspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavWspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWspackage_Enabled), 5, 0), true);
            edtavWsname_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsname_Enabled), 5, 0), true);
            edtavWsextension_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsextension_Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            edtavVersionpath_Enabled = 0;
            AssignProp(sPrefix, false, edtavVersionpath_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVersionpath_Enabled), 5, 0), true);
            edtavSiteurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavSiteurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSiteurl_Enabled), 5, 0), true);
            chkavSiteurlcallbackiscustom.Enabled = 0;
            AssignProp(sPrefix, false, chkavSiteurlcallbackiscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSiteurlcallbackiscustom.Enabled), 5, 0), true);
            edtavConsumerkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumerkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumerkey_Enabled), 5, 0), true);
            edtavConsumersecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumersecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumersecret_Enabled), 5, 0), true);
            edtavCallbackurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavCallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCallbackurl_Enabled), 5, 0), true);
            cmbavCusversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCusversion.Enabled), 5, 0), true);
            edtavCusprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusprivateencryptkey_Enabled), 5, 0), true);
            edtavCusfilename_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusfilename_Enabled), 5, 0), true);
            edtavCuspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavCuspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCuspackage_Enabled), 5, 0), true);
            edtavCusclassname_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusclassname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusclassname_Enabled), 5, 0), true);
            chkavAdduseradditionaldatascope.Enabled = 0;
            AssignProp(sPrefix, false, chkavAdduseradditionaldatascope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAdduseradditionaldatascope.Enabled), 5, 0), true);
            chkavAddinitialpropertiesscope.Enabled = 0;
            AssignProp(sPrefix, false, chkavAddinitialpropertiesscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAddinitialpropertiesscope.Enabled), 5, 0), true);
            edtavAdditionalscope_Enabled = 0;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Enabled), 5, 0), true);
            edtavGamrauthenticationtypename_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrauthenticationtypename_Enabled), 5, 0), true);
            edtavGamrserverurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Enabled), 5, 0), true);
            edtavGamrprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Enabled), 5, 0), true);
            edtavGamrrepositoryguid_Enabled = 0;
            AssignProp(sPrefix, false, edtavGamrrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamrrepositoryguid_Enabled), 5, 0), true);
            chkavAutovalidateexternaltokenandrefresh.Enabled = 0;
            AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAutovalidateexternaltokenandrefresh.Enabled), 5, 0), true);
            chkavOtpuseforfirstfactorauthentication.Enabled = 0;
            AssignProp(sPrefix, false, chkavOtpuseforfirstfactorauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOtpuseforfirstfactorauthentication.Enabled), 5, 0), true);
            chkavTfaenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavTfaenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTfaenable.Enabled), 5, 0), true);
            cmbavTfaauthenticationtypename.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTfaauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTfaauthenticationtypename.Enabled), 5, 0), true);
            edtavTfafirstfactorauthenticationexpiration_Enabled = 0;
            AssignProp(sPrefix, false, edtavTfafirstfactorauthenticationexpiration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTfafirstfactorauthenticationexpiration_Enabled), 5, 0), true);
            chkavTfaforceforallusers.Enabled = 0;
            AssignProp(sPrefix, false, chkavTfaforceforallusers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTfaforceforallusers.Enabled), 5, 0), true);
            cmbavOtpeventvalidateuser.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOtpeventvalidateuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOtpeventvalidateuser.Enabled), 5, 0), true);
            cmbavOtpgenerationtype.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOtpgenerationtype.Enabled), 5, 0), true);
            cmbavOtpgenerationtype_customeventgeneratecode.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOtpgenerationtype_customeventgeneratecode.Enabled), 5, 0), true);
            edtavOtpcodeexpirationtimeout_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpcodeexpirationtimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpcodeexpirationtimeout_Enabled), 5, 0), true);
            edtavOtpmaximumdailynumbercodes_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpmaximumdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpmaximumdailynumbercodes_Enabled), 5, 0), true);
            edtavOtpautogeneratedcodelength_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpautogeneratedcodelength_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpautogeneratedcodelength_Enabled), 5, 0), true);
            chkavOtpgeneratecodeonlynumbers.Enabled = 0;
            AssignProp(sPrefix, false, chkavOtpgeneratecodeonlynumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOtpgeneratecodeonlynumbers.Enabled), 5, 0), true);
            edtavOtpnumberunsuccessfulretriestolockotp_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpnumberunsuccessfulretriestolockotp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberunsuccessfulretriestolockotp_Enabled), 5, 0), true);
            edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Enabled), 5, 0), true);
            edtavOtpautounlocktime_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpautounlocktime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpautounlocktime_Enabled), 5, 0), true);
            cmbavOtpeventsendcode.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOtpeventsendcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOtpeventsendcode.Enabled), 5, 0), true);
            edtavOtpmailmessagesubject_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpmailmessagesubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpmailmessagesubject_Enabled), 5, 0), true);
            edtavOtpmailmessagebodyhtml_Enabled = 0;
            AssignProp(sPrefix, false, edtavOtpmailmessagebodyhtml_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpmailmessagebodyhtml_Enabled), 5, 0), true);
            cmbavOtpeventvalidatecode.Enabled = 0;
            AssignProp(sPrefix, false, cmbavOtpeventvalidatecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOtpeventvalidatecode.Enabled), 5, 0), true);
            bttConfirm_Caption = "Delete";
            AssignProp(sPrefix, false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
         }
         /* Execute user subroutine: 'REFRESHAUTHENTICATIONTYPE' */
         S312 ();
         if (returnInSub) return;
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

      protected void E143T2( )
      {
         /* 'E_BtnGenKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNGENKEY' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'U_BTNGENKEY' Routine */
         returnInSub = false;
         AV38WSPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV38WSPrivateEncryptKey", AV38WSPrivateEncryptKey);
      }

      protected void E153T2( )
      {
         /* 'E_BtnGenKeyCustom' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNGENKEYCUSTOM' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_BTNGENKEYCUSTOM' Routine */
         returnInSub = false;
         AV18CusPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV18CusPrivateEncryptKey", AV18CusPrivateEncryptKey);
      }

      protected void E163T2( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV80AuthenticationTypeWeChat", AV80AuthenticationTypeWeChat);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeTwitter", AV5AuthenticationTypeTwitter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV81AuthenticationTypeOTP", AV81AuthenticationTypeOTP);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47AuthenticationTypeGoogle", AV47AuthenticationTypeGoogle);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV54AuthenticationTypeGAMRemoteRest", AV54AuthenticationTypeGAMRemoteRest);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV46AuthenticationTypeGAMRemote", AV46AuthenticationTypeGAMRemote);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84AuthenticationTypeFacebook", AV84AuthenticationTypeFacebook);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50AuthenticationTypeWebService", AV50AuthenticationTypeWebService);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV45AuthenticationTypeCustom", AV45AuthenticationTypeCustom);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV82AuthenticationTypeApple", AV82AuthenticationTypeApple);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48AuthenticationTypeLocal", AV48AuthenticationTypeLocal);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49AuthenticationTypeOauth20", AV49AuthenticationTypeOauth20);
      }

      protected void S162( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).clearlasterrors() ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV48AuthenticationTypeLocal.load( AV29Name);
               }
               AV48AuthenticationTypeLocal.gxTpr_Name = AV29Name;
               AV48AuthenticationTypeLocal.gxTpr_Functionid = AV21FunctionId;
               AV48AuthenticationTypeLocal.gxTpr_Isenable = AV27IsEnable;
               AV48AuthenticationTypeLocal.gxTpr_Description = AV20Dsc;
               AV48AuthenticationTypeLocal.gxTpr_Smallimagename = AV31SmallImageName;
               AV48AuthenticationTypeLocal.gxTpr_Bigimagename = AV9BigImageName;
               AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Enable = AV60TFAEnable;
               if ( AV60TFAEnable )
               {
                  AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename = StringUtil.Trim( AV61TFAAuthenticationTypeName);
                  AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration = (int)(AV62TFAFirstFactorAuthenticationExpiration);
                  AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers = AV63TFAForceForAllUsers;
               }
               AV48AuthenticationTypeLocal.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV82AuthenticationTypeApple.load( AV29Name);
               }
               AV82AuthenticationTypeApple.gxTpr_Name = AV29Name;
               AV82AuthenticationTypeApple.gxTpr_Isenable = AV27IsEnable;
               AV82AuthenticationTypeApple.gxTpr_Description = AV20Dsc;
               AV82AuthenticationTypeApple.gxTpr_Smallimagename = AV31SmallImageName;
               AV82AuthenticationTypeApple.gxTpr_Bigimagename = AV9BigImageName;
               AV82AuthenticationTypeApple.gxTpr_Impersonate = AV26Impersonate;
               AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Clientid = AV11ClientId;
               AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Clientsecret = AV12ClientSecret;
               AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Siteurl = AV30SiteURL;
               AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Additionalscope = AV8AdditionalScope;
               AV82AuthenticationTypeApple.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV45AuthenticationTypeCustom.load( AV29Name);
               }
               AV45AuthenticationTypeCustom.gxTpr_Name = AV29Name;
               AV45AuthenticationTypeCustom.gxTpr_Functionid = AV21FunctionId;
               AV45AuthenticationTypeCustom.gxTpr_Isenable = AV27IsEnable;
               AV45AuthenticationTypeCustom.gxTpr_Description = AV20Dsc;
               AV45AuthenticationTypeCustom.gxTpr_Smallimagename = AV31SmallImageName;
               AV45AuthenticationTypeCustom.gxTpr_Bigimagename = AV9BigImageName;
               AV45AuthenticationTypeCustom.gxTpr_Impersonate = AV26Impersonate;
               AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Enable = AV60TFAEnable;
               if ( AV60TFAEnable )
               {
                  AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename = AV61TFAAuthenticationTypeName;
                  AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration = (int)(AV62TFAFirstFactorAuthenticationExpiration);
                  AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers = AV63TFAForceForAllUsers;
               }
               AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version = AV19CusVersion;
               AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey = AV18CusPrivateEncryptKey;
               AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename = AV16CusFileName;
               AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package = AV17CusPackage;
               AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname = AV15CusClassName;
               AV45AuthenticationTypeCustom.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV50AuthenticationTypeWebService.load( AV29Name);
               }
               AV50AuthenticationTypeWebService.gxTpr_Name = AV29Name;
               AV50AuthenticationTypeWebService.gxTpr_Functionid = AV21FunctionId;
               AV50AuthenticationTypeWebService.gxTpr_Isenable = AV27IsEnable;
               AV50AuthenticationTypeWebService.gxTpr_Description = AV20Dsc;
               AV50AuthenticationTypeWebService.gxTpr_Smallimagename = AV31SmallImageName;
               AV50AuthenticationTypeWebService.gxTpr_Bigimagename = AV9BigImageName;
               AV50AuthenticationTypeWebService.gxTpr_Impersonate = AV26Impersonate;
               AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Enable = AV60TFAEnable;
               if ( AV60TFAEnable )
               {
                  AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename = AV61TFAAuthenticationTypeName;
                  AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration = (int)(AV62TFAFirstFactorAuthenticationExpiration);
                  AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers = AV63TFAForceForAllUsers;
               }
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version = AV44WSVersion;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey = AV38WSPrivateEncryptKey;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout = AV43WSTimeout;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package = AV37WSPackage;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name = AV36WSName;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension = AV35WSExtension;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name = AV40WSServerName;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port = AV41WSServerPort;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl = AV39WSServerBaseURL;
               AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol = AV42WSServerSecureProtocol;
               AV50AuthenticationTypeWebService.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV84AuthenticationTypeFacebook.load( AV29Name);
               }
               AV84AuthenticationTypeFacebook.gxTpr_Name = AV29Name;
               AV84AuthenticationTypeFacebook.gxTpr_Isenable = AV27IsEnable;
               AV84AuthenticationTypeFacebook.gxTpr_Description = AV20Dsc;
               AV84AuthenticationTypeFacebook.gxTpr_Smallimagename = AV31SmallImageName;
               AV84AuthenticationTypeFacebook.gxTpr_Bigimagename = AV9BigImageName;
               AV84AuthenticationTypeFacebook.gxTpr_Impersonate = AV26Impersonate;
               AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid = AV11ClientId;
               AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret = AV12ClientSecret;
               AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Versionpath = AV55VersionPath;
               AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl = AV30SiteURL;
               AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope = AV8AdditionalScope;
               AV84AuthenticationTypeFacebook.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV46AuthenticationTypeGAMRemote.load( AV29Name);
               }
               AV46AuthenticationTypeGAMRemote.gxTpr_Name = AV29Name;
               AV46AuthenticationTypeGAMRemote.gxTpr_Functionid = AV21FunctionId;
               AV46AuthenticationTypeGAMRemote.gxTpr_Isenable = AV27IsEnable;
               AV46AuthenticationTypeGAMRemote.gxTpr_Description = AV20Dsc;
               AV46AuthenticationTypeGAMRemote.gxTpr_Smallimagename = AV31SmallImageName;
               AV46AuthenticationTypeGAMRemote.gxTpr_Bigimagename = AV9BigImageName;
               AV46AuthenticationTypeGAMRemote.gxTpr_Impersonate = AV26Impersonate;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid = AV11ClientId;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret = AV12ClientSecret;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl = AV30SiteURL;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurlcallbackiscustom = AV79SiteURLCallbackIsCustom;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Addsessioninitialpropertiesscope = AV57AddInitialPropertiesScope;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Adduseradditionaldatascope = AV56AddUserAdditionalDataScope;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope = AV8AdditionalScope;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl = AV24GAMRServerURL;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey = AV22GAMRPrivateEncryptKey;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid = AV23GAMRRepositoryGUID;
               AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Autovalidateexternaltokenandrefresh = AV59AutovalidateExternalTokenAndRefresh;
               AV46AuthenticationTypeGAMRemote.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV54AuthenticationTypeGAMRemoteRest.load( AV29Name);
               }
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Name = AV29Name;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Functionid = AV21FunctionId;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Isenable = AV27IsEnable;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Description = AV20Dsc;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Smallimagename = AV31SmallImageName;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Bigimagename = AV9BigImageName;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Impersonate = AV26Impersonate;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Enable = AV60TFAEnable;
               if ( AV60TFAEnable )
               {
                  AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename = AV61TFAAuthenticationTypeName;
                  AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration = (int)(AV62TFAFirstFactorAuthenticationExpiration);
                  AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers = AV63TFAForceForAllUsers;
               }
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientid = AV11ClientId;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientsecret = AV12ClientSecret;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Versionpath = AV55VersionPath;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Addsessioninitialpropertiesscope = AV57AddInitialPropertiesScope;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Adduseradditionaldatascope = AV56AddUserAdditionalDataScope;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Additionalscope = AV8AdditionalScope;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteauthenticationtypename = AV58GAMRAuthenticationTypeName;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverurl = AV24GAMRServerURL;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverkey = AV22GAMRPrivateEncryptKey;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoterepositoryguid = AV23GAMRRepositoryGUID;
               AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Autovalidateexternaltokenandrefresh = AV59AutovalidateExternalTokenAndRefresh;
               AV54AuthenticationTypeGAMRemoteRest.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV47AuthenticationTypeGoogle.load( AV29Name);
               }
               AV47AuthenticationTypeGoogle.gxTpr_Name = AV29Name;
               AV47AuthenticationTypeGoogle.gxTpr_Isenable = AV27IsEnable;
               AV47AuthenticationTypeGoogle.gxTpr_Description = AV20Dsc;
               AV47AuthenticationTypeGoogle.gxTpr_Smallimagename = AV31SmallImageName;
               AV47AuthenticationTypeGoogle.gxTpr_Bigimagename = AV9BigImageName;
               AV47AuthenticationTypeGoogle.gxTpr_Impersonate = AV26Impersonate;
               AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid = AV11ClientId;
               AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret = AV12ClientSecret;
               AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Versionpath = AV55VersionPath;
               AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl = AV30SiteURL;
               AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope = AV8AdditionalScope;
               AV47AuthenticationTypeGoogle.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV81AuthenticationTypeOTP.load( AV29Name);
               }
               AV81AuthenticationTypeOTP.gxTpr_Name = AV29Name;
               AV81AuthenticationTypeOTP.gxTpr_Isenable = AV27IsEnable;
               AV81AuthenticationTypeOTP.gxTpr_Description = AV20Dsc;
               AV81AuthenticationTypeOTP.gxTpr_Smallimagename = AV31SmallImageName;
               AV81AuthenticationTypeOTP.gxTpr_Bigimagename = AV9BigImageName;
               AV81AuthenticationTypeOTP.gxTpr_Impersonate = AV26Impersonate;
               AV81AuthenticationTypeOTP.gxTpr_Useforfirstfactorauthentication = AV64OTPUseForFirstFactorAuthentication;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventvaliduser = AV65OTPEventValidateUser;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generationtype = AV66OTPGenerationType;
               if ( StringUtil.StrCmp(AV66OTPGenerationType, "custom") == 0 )
               {
                  AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generationtype_customeventgeneratecode = AV67OTPGenerationType_CustomEventGenerateCode;
               }
               else
               {
               }
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Codeexpirationtimeout = AV70OTPCodeExpirationTimeout;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Maximumdailynumbercodes = AV71OTPMaximumDailyNumberCodes;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Autogeneratedcodelength = AV68OTPAutogeneratedCodeLength;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generatecodeonlynumbers = AV69OTPGenerateCodeOnlyNumbers;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Numberunsuccessfulretriestolockotp = AV72OTPNumberUnsuccessfulRetriesToLockOTP;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Numberunsuccessfulretriestoblockuserbasedofotplocks = AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Automaticotpunlocktime = (int)(AV73OTPAutoUnlockTime);
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventsendcode = AV75OTPEventSendCode;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Mailmessagesubject = AV76OTPMailMessageSubject;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Mailmessagebodyhtml = AV77OTPMailMessageBodyHTML;
               AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventvalidatecode = AV78OTPEventValidateCode;
               AV81AuthenticationTypeOTP.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV5AuthenticationTypeTwitter.load( AV29Name);
               }
               AV5AuthenticationTypeTwitter.gxTpr_Name = AV29Name;
               AV5AuthenticationTypeTwitter.gxTpr_Isenable = AV27IsEnable;
               AV5AuthenticationTypeTwitter.gxTpr_Description = AV20Dsc;
               AV5AuthenticationTypeTwitter.gxTpr_Smallimagename = AV31SmallImageName;
               AV5AuthenticationTypeTwitter.gxTpr_Bigimagename = AV9BigImageName;
               AV5AuthenticationTypeTwitter.gxTpr_Impersonate = AV26Impersonate;
               AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey = AV13ConsumerKey;
               AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret = AV14ConsumerSecret;
               AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl = AV10CallbackURL;
               AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope = AV8AdditionalScope;
               AV5AuthenticationTypeTwitter.save();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV80AuthenticationTypeWeChat.load( AV29Name);
               }
               AV80AuthenticationTypeWeChat.gxTpr_Name = AV29Name;
               AV80AuthenticationTypeWeChat.gxTpr_Isenable = AV27IsEnable;
               AV80AuthenticationTypeWeChat.gxTpr_Description = AV20Dsc;
               AV80AuthenticationTypeWeChat.gxTpr_Smallimagename = AV31SmallImageName;
               AV80AuthenticationTypeWeChat.gxTpr_Bigimagename = AV9BigImageName;
               AV80AuthenticationTypeWeChat.gxTpr_Impersonate = AV26Impersonate;
               AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Clientid = AV11ClientId;
               AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Clientsecret = AV12ClientSecret;
               AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Versionpath = AV55VersionPath;
               AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Siteurl = AV30SiteURL;
               AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Additionalscope = AV8AdditionalScope;
               AV80AuthenticationTypeWeChat.save();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 )
            {
               AV48AuthenticationTypeLocal.load( AV29Name);
               AV48AuthenticationTypeLocal.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 )
            {
               AV82AuthenticationTypeApple.load( AV29Name);
               AV82AuthenticationTypeApple.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 )
            {
               AV45AuthenticationTypeCustom.load( AV29Name);
               AV45AuthenticationTypeCustom.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 )
            {
               AV50AuthenticationTypeWebService.load( AV29Name);
               AV50AuthenticationTypeWebService.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 )
            {
               AV84AuthenticationTypeFacebook.load( AV29Name);
               AV84AuthenticationTypeFacebook.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 )
            {
               AV46AuthenticationTypeGAMRemote.load( AV29Name);
               AV46AuthenticationTypeGAMRemote.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 )
            {
               AV54AuthenticationTypeGAMRemoteRest.load( AV29Name);
               AV54AuthenticationTypeGAMRemoteRest.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 )
            {
               AV47AuthenticationTypeGoogle.load( AV29Name);
               AV47AuthenticationTypeGoogle.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Oauth20") == 0 )
            {
               AV49AuthenticationTypeOauth20.load( AV29Name);
               AV49AuthenticationTypeOauth20.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 )
            {
               AV81AuthenticationTypeOTP.load( AV29Name);
               AV81AuthenticationTypeOTP.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 )
            {
               AV5AuthenticationTypeTwitter.load( AV29Name);
               AV5AuthenticationTypeTwitter.delete();
            }
            else if ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 )
            {
               AV80AuthenticationTypeWeChat.load( AV29Name);
               AV80AuthenticationTypeWeChat.delete();
            }
         }
         if ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 )
         {
            if ( AV48AuthenticationTypeLocal.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 )
         {
            if ( AV82AuthenticationTypeApple.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 )
         {
            if ( AV45AuthenticationTypeCustom.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 )
         {
            if ( AV50AuthenticationTypeWebService.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 )
         {
            if ( AV84AuthenticationTypeFacebook.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 )
         {
            if ( AV46AuthenticationTypeGAMRemote.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 )
         {
            if ( AV54AuthenticationTypeGAMRemoteRest.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 )
         {
            if ( AV47AuthenticationTypeGoogle.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Oauth20") == 0 )
         {
            if ( AV49AuthenticationTypeOauth20.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 )
         {
            if ( AV81AuthenticationTypeOTP.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 )
         {
            if ( AV5AuthenticationTypeTwitter.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 )
         {
            if ( AV80AuthenticationTypeWeChat.success() )
            {
               context.CommitDataStores("k2bfsg.wcauthenticationtypeentrygeneral",pr_default);
            }
         }
         AV52Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV52Errors.Count == 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV89GXV1 = 1;
            while ( AV89GXV1 <= AV52Errors.Count )
            {
               AV51Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV52Errors.Item(AV89GXV1));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV51Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV51Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV89GXV1 = (int)(AV89GXV1+1);
            }
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S312( )
      {
         /* 'REFRESHAUTHENTICATIONTYPE' Routine */
         returnInSub = false;
         edtavSiteurl_Visible = 1;
         AssignProp(sPrefix, false, edtavSiteurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSiteurl_Visible), 5, 0), true);
         Tblimpersonate_Visible = true;
         ucTblimpersonate.SendProperty(context, sPrefix, false, Tblimpersonate_Internalname, "Visible", StringUtil.BoolToStr( Tblimpersonate_Visible));
         Tblclientidsecret_Visible = false;
         ucTblclientidsecret.SendProperty(context, sPrefix, false, Tblclientidsecret_Internalname, "Visible", StringUtil.BoolToStr( Tblclientidsecret_Visible));
         Tblclientlocalserver_Visible = false;
         ucTblclientlocalserver.SendProperty(context, sPrefix, false, Tblclientlocalserver_Internalname, "Visible", StringUtil.BoolToStr( Tblclientlocalserver_Visible));
         Tblscopes_Visible = false;
         ucTblscopes.SendProperty(context, sPrefix, false, Tblscopes_Internalname, "Visible", StringUtil.BoolToStr( Tblscopes_Visible));
         Tblauthtypename_Visible = false;
         ucTblauthtypename.SendProperty(context, sPrefix, false, Tblauthtypename_Internalname, "Visible", StringUtil.BoolToStr( Tblauthtypename_Visible));
         Tblcommonadditional_Visible = false;
         ucTblcommonadditional.SendProperty(context, sPrefix, false, Tblcommonadditional_Internalname, "Visible", StringUtil.BoolToStr( Tblcommonadditional_Visible));
         Tblserverhost_Visible = false;
         ucTblserverhost.SendProperty(context, sPrefix, false, Tblserverhost_Internalname, "Visible", StringUtil.BoolToStr( Tblserverhost_Visible));
         Tbltwitter_Visible = false;
         ucTbltwitter.SendProperty(context, sPrefix, false, Tbltwitter_Internalname, "Visible", StringUtil.BoolToStr( Tbltwitter_Visible));
         Tblwebservice_Visible = false;
         ucTblwebservice.SendProperty(context, sPrefix, false, Tblwebservice_Internalname, "Visible", StringUtil.BoolToStr( Tblwebservice_Visible));
         Tblexternal_Visible = false;
         ucTblexternal.SendProperty(context, sPrefix, false, Tblexternal_Internalname, "Visible", StringUtil.BoolToStr( Tblexternal_Visible));
         Tblotpauthentication_Visible = false;
         ucTblotpauthentication.SendProperty(context, sPrefix, false, Tblotpauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tblotpauthentication_Visible));
         divTblotpcustom_Visible = 0;
         AssignProp(sPrefix, false, divTblotpcustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpcustom_Visible), 5, 0), true);
         divTblotpconfiguration_Visible = 0;
         AssignProp(sPrefix, false, divTblotpconfiguration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpconfiguration_Visible), 5, 0), true);
         divTbltypeotpgeneratecode_Visible = 0;
         AssignProp(sPrefix, false, divTbltypeotpgeneratecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltypeotpgeneratecode_Visible), 5, 0), true);
         if ( ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 ) )
         {
            AV21FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         else
         {
            cmbavFunctionid.Enabled = 1;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 ) )
         {
            Tblenabletwofactorauth_Visible = true;
            ucTblenabletwofactorauth.SendProperty(context, sPrefix, false, Tblenabletwofactorauth_Internalname, "Visible", StringUtil.BoolToStr( Tblenabletwofactorauth_Visible));
            if ( AV60TFAEnable )
            {
               Tbltwofactorauthentication_Visible = true;
               ucTbltwofactorauthentication.SendProperty(context, sPrefix, false, Tbltwofactorauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
            }
            else
            {
               Tbltwofactorauthentication_Visible = false;
               ucTbltwofactorauthentication.SendProperty(context, sPrefix, false, Tbltwofactorauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
            }
         }
         else
         {
            Tblenabletwofactorauth_Visible = false;
            ucTblenabletwofactorauth.SendProperty(context, sPrefix, false, Tblenabletwofactorauth_Internalname, "Visible", StringUtil.BoolToStr( Tblenabletwofactorauth_Visible));
            Tbltwofactorauthentication_Visible = false;
            ucTbltwofactorauthentication.SendProperty(context, sPrefix, false, Tbltwofactorauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
         }
         if ( StringUtil.StrCmp(AV53TypeId, "GAMLocal") == 0 )
         {
            Tblimpersonate_Visible = false;
            ucTblimpersonate.SendProperty(context, sPrefix, false, Tblimpersonate_Internalname, "Visible", StringUtil.BoolToStr( Tblimpersonate_Visible));
         }
         else if ( ( StringUtil.StrCmp(AV53TypeId, "AppleID") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Facebook") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "Google") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 ) || ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 ) )
         {
            Tblclientidsecret_Visible = true;
            ucTblclientidsecret.SendProperty(context, sPrefix, false, Tblclientidsecret_Internalname, "Visible", StringUtil.BoolToStr( Tblclientidsecret_Visible));
            Tblclientlocalserver_Visible = true;
            ucTblclientlocalserver.SendProperty(context, sPrefix, false, Tblclientlocalserver_Internalname, "Visible", StringUtil.BoolToStr( Tblclientlocalserver_Visible));
            Tblcommonadditional_Visible = true;
            ucTblcommonadditional.SendProperty(context, sPrefix, false, Tblcommonadditional_Internalname, "Visible", StringUtil.BoolToStr( Tblcommonadditional_Visible));
            if ( StringUtil.StrCmp(AV53TypeId, "WeChat") == 0 )
            {
               edtavVersionpath_Visible = 0;
               AssignProp(sPrefix, false, edtavVersionpath_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVersionpath_Visible), 5, 0), true);
            }
            if ( StringUtil.StrCmp(AV53TypeId, "GAMRemote") == 0 )
            {
               edtavVersionpath_Visible = 0;
               AssignProp(sPrefix, false, edtavVersionpath_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVersionpath_Visible), 5, 0), true);
               Tblscopes_Visible = true;
               ucTblscopes.SendProperty(context, sPrefix, false, Tblscopes_Internalname, "Visible", StringUtil.BoolToStr( Tblscopes_Visible));
               Tblserverhost_Visible = true;
               ucTblserverhost.SendProperty(context, sPrefix, false, Tblserverhost_Internalname, "Visible", StringUtil.BoolToStr( Tblserverhost_Visible));
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "GAMRemoteRest") == 0 )
         {
            Tblclientidsecret_Visible = true;
            ucTblclientidsecret.SendProperty(context, sPrefix, false, Tblclientidsecret_Internalname, "Visible", StringUtil.BoolToStr( Tblclientidsecret_Visible));
            Tblscopes_Visible = true;
            ucTblscopes.SendProperty(context, sPrefix, false, Tblscopes_Internalname, "Visible", StringUtil.BoolToStr( Tblscopes_Visible));
            Tblcommonadditional_Visible = true;
            ucTblcommonadditional.SendProperty(context, sPrefix, false, Tblcommonadditional_Internalname, "Visible", StringUtil.BoolToStr( Tblcommonadditional_Visible));
            Tblauthtypename_Visible = true;
            ucTblauthtypename.SendProperty(context, sPrefix, false, Tblauthtypename_Internalname, "Visible", StringUtil.BoolToStr( Tblauthtypename_Visible));
            Tblserverhost_Visible = true;
            ucTblserverhost.SendProperty(context, sPrefix, false, Tblserverhost_Internalname, "Visible", StringUtil.BoolToStr( Tblserverhost_Visible));
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "OTP") == 0 )
         {
            Tblotpauthentication_Visible = true;
            ucTblotpauthentication.SendProperty(context, sPrefix, false, Tblotpauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tblotpauthentication_Visible));
            divTblotpconfiguration_Visible = 1;
            AssignProp(sPrefix, false, divTblotpconfiguration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpconfiguration_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(AV66OTPGenerationType, "gam") == 0 )
            {
               divTblotpcustom_Visible = 0;
               AssignProp(sPrefix, false, divTblotpcustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpcustom_Visible), 5, 0), true);
               divTbltypeotpgeneratecode_Visible = 1;
               AssignProp(sPrefix, false, divTbltypeotpgeneratecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltypeotpgeneratecode_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV66OTPGenerationType, "custom") == 0 )
            {
               divTblotpcustom_Visible = 1;
               AssignProp(sPrefix, false, divTblotpcustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpcustom_Visible), 5, 0), true);
               divTbltypeotpgeneratecode_Visible = 0;
               AssignProp(sPrefix, false, divTbltypeotpgeneratecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltypeotpgeneratecode_Visible), 5, 0), true);
               /* Execute user subroutine: 'GETEVENTLISTGENERATECODE' */
               S192 ();
               if (returnInSub) return;
            }
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Twitter") == 0 )
         {
            AV21FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            Tbltwitter_Visible = true;
            ucTbltwitter.SendProperty(context, sPrefix, false, Tbltwitter_Internalname, "Visible", StringUtil.BoolToStr( Tbltwitter_Visible));
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "ExternalWebService") == 0 )
         {
            Tblwebservice_Visible = true;
            ucTblwebservice.SendProperty(context, sPrefix, false, Tblwebservice_Internalname, "Visible", StringUtil.BoolToStr( Tblwebservice_Visible));
         }
         else if ( StringUtil.StrCmp(AV53TypeId, "Custom") == 0 )
         {
            Tblexternal_Visible = true;
            ucTblexternal.SendProperty(context, sPrefix, false, Tblexternal_Internalname, "Visible", StringUtil.BoolToStr( Tblexternal_Visible));
         }
      }

      protected void E173T2( )
      {
         /* Tfaenable_Click Routine */
         returnInSub = false;
         if ( AV60TFAEnable )
         {
            if ( (0==AV62TFAFirstFactorAuthenticationExpiration) )
            {
               AV62TFAFirstFactorAuthenticationExpiration = 900;
               AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            }
            Tbltwofactorauthentication_Visible = true;
            ucTbltwofactorauthentication.SendProperty(context, sPrefix, false, Tbltwofactorauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
            /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEOTP' */
            S182 ();
            if (returnInSub) return;
         }
         else
         {
            Tbltwofactorauthentication_Visible = false;
            ucTbltwofactorauthentication.SendProperty(context, sPrefix, false, Tbltwofactorauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tbltwofactorauthentication_Visible));
            AV61TFAAuthenticationTypeName = "";
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
         }
         /*  Sending Event outputs  */
         cmbavTfaauthenticationtypename.CurrentValue = StringUtil.RTrim( AV61TFAAuthenticationTypeName);
         AssignProp(sPrefix, false, cmbavTfaauthenticationtypename_Internalname, "Values", cmbavTfaauthenticationtypename.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV86GAMAuthenticationTypeFilter", AV86GAMAuthenticationTypeFilter);
      }

      protected void E183T2( )
      {
         /* Otpgenerationtype_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV66OTPGenerationType, "gam") == 0 )
         {
            divTblotpcustom_Visible = 0;
            AssignProp(sPrefix, false, divTblotpcustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpcustom_Visible), 5, 0), true);
            divTbltypeotpgeneratecode_Visible = 1;
            AssignProp(sPrefix, false, divTbltypeotpgeneratecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltypeotpgeneratecode_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV66OTPGenerationType, "custom") == 0 )
         {
            divTblotpcustom_Visible = 1;
            AssignProp(sPrefix, false, divTblotpcustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblotpcustom_Visible), 5, 0), true);
            divTbltypeotpgeneratecode_Visible = 0;
            AssignProp(sPrefix, false, divTbltypeotpgeneratecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltypeotpgeneratecode_Visible), 5, 0), true);
            /* Execute user subroutine: 'GETEVENTLISTGENERATECODE' */
            S192 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV87GAMEventSubscriptionFilter", AV87GAMEventSubscriptionFilter);
         cmbavOtpgenerationtype_customeventgeneratecode.CurrentValue = StringUtil.RTrim( AV67OTPGenerationType_CustomEventGenerateCode);
         AssignProp(sPrefix, false, cmbavOtpgenerationtype_customeventgeneratecode_Internalname, "Values", cmbavOtpgenerationtype_customeventgeneratecode.ToJavascriptSource(), true);
      }

      protected void S322( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' Routine */
         returnInSub = false;
         AV91GXV3 = 1;
         AV90GXV2 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV86GAMAuthenticationTypeFilter, out  AV52Errors);
         while ( AV91GXV3 <= AV90GXV2.Count )
         {
            AV83AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV90GXV2.Item(AV91GXV3));
            if ( ( StringUtil.StrCmp(AV83AuthenticationType.gxTpr_Name, AV29Name) != 0 ) && ( StringUtil.StrCmp(AV83AuthenticationType.gxTpr_Typeid, "OTP") != 0 ) )
            {
               cmbavImpersonate.addItem(AV83AuthenticationType.gxTpr_Name, AV83AuthenticationType.gxTpr_Name, 0);
            }
            AV91GXV3 = (int)(AV91GXV3+1);
         }
      }

      protected void S182( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEOTP' Routine */
         returnInSub = false;
         AV86GAMAuthenticationTypeFilter.gxTpr_Type = "OTP";
         AV93GXV5 = 1;
         AV92GXV4 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV86GAMAuthenticationTypeFilter, out  AV52Errors);
         while ( AV93GXV5 <= AV92GXV4.Count )
         {
            AV83AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV92GXV4.Item(AV93GXV5));
            cmbavTfaauthenticationtypename.addItem(AV83AuthenticationType.gxTpr_Name, AV83AuthenticationType.gxTpr_Description, 0);
            AV93GXV5 = (int)(AV93GXV5+1);
         }
      }

      protected void S332( )
      {
         /* 'GETEVENTLISTVALIDATEUSER' Routine */
         returnInSub = false;
         AV87GAMEventSubscriptionFilter.gxTpr_Event = "user-otp-validateuser";
         AV95GXV7 = 1;
         AV94GXV6 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV87GAMEventSubscriptionFilter, out  AV52Errors);
         while ( AV95GXV7 <= AV94GXV6.Count )
         {
            AV85EventSuscription = ((GeneXus.Programs.genexussecurity.SdtGAMEventSubscription)AV94GXV6.Item(AV95GXV7));
            cmbavOtpeventvalidateuser.addItem(AV85EventSuscription.gxTpr_Id, AV85EventSuscription.gxTpr_Description, 0);
            AV95GXV7 = (int)(AV95GXV7+1);
         }
      }

      protected void S192( )
      {
         /* 'GETEVENTLISTGENERATECODE' Routine */
         returnInSub = false;
         AV87GAMEventSubscriptionFilter.gxTpr_Event = "user-otp-generatecode";
         AV97GXV9 = 1;
         AV96GXV8 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV87GAMEventSubscriptionFilter, out  AV52Errors);
         while ( AV97GXV9 <= AV96GXV8.Count )
         {
            AV85EventSuscription = ((GeneXus.Programs.genexussecurity.SdtGAMEventSubscription)AV96GXV8.Item(AV97GXV9));
            cmbavOtpgenerationtype_customeventgeneratecode.addItem(AV85EventSuscription.gxTpr_Id, AV85EventSuscription.gxTpr_Description, 0);
            AV97GXV9 = (int)(AV97GXV9+1);
         }
      }

      protected void S342( )
      {
         /* 'GETEVENTLISTSENDCODE' Routine */
         returnInSub = false;
         AV87GAMEventSubscriptionFilter.gxTpr_Event = "user-otp-sendcode";
         AV99GXV11 = 1;
         AV98GXV10 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV87GAMEventSubscriptionFilter, out  AV52Errors);
         while ( AV99GXV11 <= AV98GXV10.Count )
         {
            AV85EventSuscription = ((GeneXus.Programs.genexussecurity.SdtGAMEventSubscription)AV98GXV10.Item(AV99GXV11));
            cmbavOtpeventsendcode.addItem(AV85EventSuscription.gxTpr_Id, AV85EventSuscription.gxTpr_Description, 0);
            AV99GXV11 = (int)(AV99GXV11+1);
         }
      }

      protected void S352( )
      {
         /* 'GETEVENTLISTVALIDATECODE' Routine */
         returnInSub = false;
         AV87GAMEventSubscriptionFilter.gxTpr_Event = "user-otp-validatecode";
         AV101GXV13 = 1;
         AV100GXV12 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV87GAMEventSubscriptionFilter, out  AV52Errors);
         while ( AV101GXV13 <= AV100GXV12.Count )
         {
            AV85EventSuscription = ((GeneXus.Programs.genexussecurity.SdtGAMEventSubscription)AV100GXV12.Item(AV101GXV13));
            cmbavOtpeventvalidatecode.addItem(AV85EventSuscription.gxTpr_Id, AV85EventSuscription.gxTpr_Description, 0);
            AV101GXV13 = (int)(AV101GXV13+1);
         }
      }

      protected void S202( )
      {
         /* 'INITAUTHENTICATIONTYPEAPPLE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV82AuthenticationTypeApple.load( AV29Name);
         AV29Name = AV82AuthenticationTypeApple.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV82AuthenticationTypeApple.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV82AuthenticationTypeApple.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV82AuthenticationTypeApple.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV82AuthenticationTypeApple.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV82AuthenticationTypeApple.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV11ClientId = AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV30SiteURL = AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Siteurl;
         AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
         AV8AdditionalScope = AV82AuthenticationTypeApple.gxTpr_Apple.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
      }

      protected void S212( )
      {
         /* 'INITAUTHENTICATIONTYPECUSTOM' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEOTP' */
         S182 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 1;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV45AuthenticationTypeCustom.load( AV29Name);
         AV29Name = AV45AuthenticationTypeCustom.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV21FunctionId = AV45AuthenticationTypeCustom.gxTpr_Functionid;
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV27IsEnable = AV45AuthenticationTypeCustom.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV45AuthenticationTypeCustom.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV45AuthenticationTypeCustom.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV45AuthenticationTypeCustom.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV45AuthenticationTypeCustom.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV60TFAEnable = AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
         if ( AV60TFAEnable )
         {
            AV61TFAAuthenticationTypeName = AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename;
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
            AV62TFAFirstFactorAuthenticationExpiration = AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration;
            AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            AV63TFAForceForAllUsers = AV45AuthenticationTypeCustom.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers;
            AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
         }
         AV19CusVersion = AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version;
         AssignAttri(sPrefix, false, "AV19CusVersion", AV19CusVersion);
         AV18CusPrivateEncryptKey = AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey;
         AssignAttri(sPrefix, false, "AV18CusPrivateEncryptKey", AV18CusPrivateEncryptKey);
         AV16CusFileName = AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV16CusFileName", AV16CusFileName);
         AV17CusPackage = AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package;
         AssignAttri(sPrefix, false, "AV17CusPackage", AV17CusPackage);
         AV15CusClassName = AV45AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname;
         AssignAttri(sPrefix, false, "AV15CusClassName", AV15CusClassName);
      }

      protected void S222( )
      {
         /* 'INITAUTHENTICATIONTYPEEXTERNALWEBSERVICE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEOTP' */
         S182 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 1;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV50AuthenticationTypeWebService.load( AV29Name);
         AV29Name = AV50AuthenticationTypeWebService.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV21FunctionId = AV50AuthenticationTypeWebService.gxTpr_Functionid;
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV27IsEnable = AV50AuthenticationTypeWebService.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV50AuthenticationTypeWebService.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV50AuthenticationTypeWebService.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV50AuthenticationTypeWebService.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV50AuthenticationTypeWebService.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV60TFAEnable = AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
         if ( AV60TFAEnable )
         {
            AV61TFAAuthenticationTypeName = AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename;
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
            AV62TFAFirstFactorAuthenticationExpiration = AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration;
            AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            AV63TFAForceForAllUsers = AV50AuthenticationTypeWebService.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers;
            AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
         }
         AV44WSVersion = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version;
         AssignAttri(sPrefix, false, "AV44WSVersion", AV44WSVersion);
         AV38WSPrivateEncryptKey = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey;
         AssignAttri(sPrefix, false, "AV38WSPrivateEncryptKey", AV38WSPrivateEncryptKey);
         AV40WSServerName = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV40WSServerName", AV40WSServerName);
         AV41WSServerPort = (short)(AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port);
         AssignAttri(sPrefix, false, "AV41WSServerPort", StringUtil.LTrimStr( (decimal)(AV41WSServerPort), 4, 0));
         AV39WSServerBaseURL = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl;
         AssignAttri(sPrefix, false, "AV39WSServerBaseURL", AV39WSServerBaseURL);
         AV42WSServerSecureProtocol = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol;
         AssignAttri(sPrefix, false, "AV42WSServerSecureProtocol", StringUtil.LTrimStr( (decimal)(AV42WSServerSecureProtocol), 4, 0));
         AV43WSTimeout = (short)(AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout);
         AssignAttri(sPrefix, false, "AV43WSTimeout", StringUtil.LTrimStr( (decimal)(AV43WSTimeout), 4, 0));
         AV37WSPackage = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package;
         AssignAttri(sPrefix, false, "AV37WSPackage", AV37WSPackage);
         AV36WSName = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV36WSName", AV36WSName);
         AV35WSExtension = AV50AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension;
         AssignAttri(sPrefix, false, "AV35WSExtension", AV35WSExtension);
      }

      protected void S232( )
      {
         /* 'INITAUTHENTICATIONTYPEFACEBOOK' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV84AuthenticationTypeFacebook.load( AV29Name);
         AV29Name = AV84AuthenticationTypeFacebook.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV84AuthenticationTypeFacebook.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV84AuthenticationTypeFacebook.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV84AuthenticationTypeFacebook.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV84AuthenticationTypeFacebook.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV84AuthenticationTypeFacebook.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV11ClientId = AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV55VersionPath = AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Versionpath;
         AssignAttri(sPrefix, false, "AV55VersionPath", AV55VersionPath);
         AV30SiteURL = AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl;
         AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
         AV8AdditionalScope = AV84AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
      }

      protected void S242( )
      {
         /* 'INITAUTHENTICATIONTYPEGAMLOCAL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEOTP' */
         S182 ();
         if (returnInSub) return;
         AV48AuthenticationTypeLocal.load( AV29Name);
         AV29Name = AV48AuthenticationTypeLocal.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV21FunctionId = AV48AuthenticationTypeLocal.gxTpr_Functionid;
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV27IsEnable = AV48AuthenticationTypeLocal.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV48AuthenticationTypeLocal.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV48AuthenticationTypeLocal.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV48AuthenticationTypeLocal.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV60TFAEnable = AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
         if ( AV60TFAEnable )
         {
            AV61TFAAuthenticationTypeName = AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename;
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
            AV62TFAFirstFactorAuthenticationExpiration = AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration;
            AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            AV63TFAForceForAllUsers = AV48AuthenticationTypeLocal.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers;
            AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
         }
      }

      protected void S252( )
      {
         /* 'INITAUTHENTICATIONTYPEGAMREMOTE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 1;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV46AuthenticationTypeGAMRemote.load( AV29Name);
         AV29Name = AV46AuthenticationTypeGAMRemote.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV21FunctionId = AV46AuthenticationTypeGAMRemote.gxTpr_Functionid;
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV27IsEnable = AV46AuthenticationTypeGAMRemote.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV46AuthenticationTypeGAMRemote.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV46AuthenticationTypeGAMRemote.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV46AuthenticationTypeGAMRemote.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV46AuthenticationTypeGAMRemote.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV11ClientId = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV30SiteURL = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl;
         AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
         AV79SiteURLCallbackIsCustom = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurlcallbackiscustom;
         AssignAttri(sPrefix, false, "AV79SiteURLCallbackIsCustom", AV79SiteURLCallbackIsCustom);
         AV57AddInitialPropertiesScope = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Addsessioninitialpropertiesscope;
         AssignAttri(sPrefix, false, "AV57AddInitialPropertiesScope", AV57AddInitialPropertiesScope);
         AV56AddUserAdditionalDataScope = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Adduseradditionaldatascope;
         AssignAttri(sPrefix, false, "AV56AddUserAdditionalDataScope", AV56AddUserAdditionalDataScope);
         AV8AdditionalScope = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
         AV24GAMRServerURL = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl;
         AssignAttri(sPrefix, false, "AV24GAMRServerURL", AV24GAMRServerURL);
         AV22GAMRPrivateEncryptKey = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey;
         AssignAttri(sPrefix, false, "AV22GAMRPrivateEncryptKey", AV22GAMRPrivateEncryptKey);
         AV23GAMRRepositoryGUID = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid;
         AssignAttri(sPrefix, false, "AV23GAMRRepositoryGUID", AV23GAMRRepositoryGUID);
         AV59AutovalidateExternalTokenAndRefresh = AV46AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Autovalidateexternaltokenandrefresh;
         AssignAttri(sPrefix, false, "AV59AutovalidateExternalTokenAndRefresh", AV59AutovalidateExternalTokenAndRefresh);
      }

      protected void S262( )
      {
         /* 'INITAUTHENTICATIONTYPEGAMREMOTEREST' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEOTP' */
         S182 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 1;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV54AuthenticationTypeGAMRemoteRest.load( AV29Name);
         AV29Name = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV21FunctionId = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Functionid;
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV27IsEnable = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV60TFAEnable = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV60TFAEnable", AV60TFAEnable);
         if ( AV60TFAEnable )
         {
            AV61TFAAuthenticationTypeName = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Authenticationtypename;
            AssignAttri(sPrefix, false, "AV61TFAAuthenticationTypeName", AV61TFAAuthenticationTypeName);
            AV62TFAFirstFactorAuthenticationExpiration = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Firstauthenticationfactorexpiration;
            AssignAttri(sPrefix, false, "AV62TFAFirstFactorAuthenticationExpiration", StringUtil.LTrimStr( (decimal)(AV62TFAFirstFactorAuthenticationExpiration), 15, 0));
            AV63TFAForceForAllUsers = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Twofactorauthentication.gxTpr_Forceforallusers;
            AssignAttri(sPrefix, false, "AV63TFAForceForAllUsers", AV63TFAForceForAllUsers);
         }
         AV11ClientId = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV55VersionPath = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Versionpath;
         AssignAttri(sPrefix, false, "AV55VersionPath", AV55VersionPath);
         AV57AddInitialPropertiesScope = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Addsessioninitialpropertiesscope;
         AssignAttri(sPrefix, false, "AV57AddInitialPropertiesScope", AV57AddInitialPropertiesScope);
         AV56AddUserAdditionalDataScope = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Adduseradditionaldatascope;
         AssignAttri(sPrefix, false, "AV56AddUserAdditionalDataScope", AV56AddUserAdditionalDataScope);
         AV8AdditionalScope = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
         AV58GAMRAuthenticationTypeName = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteauthenticationtypename;
         AssignAttri(sPrefix, false, "AV58GAMRAuthenticationTypeName", AV58GAMRAuthenticationTypeName);
         AV24GAMRServerURL = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverurl;
         AssignAttri(sPrefix, false, "AV24GAMRServerURL", AV24GAMRServerURL);
         AV22GAMRPrivateEncryptKey = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoteserverkey;
         AssignAttri(sPrefix, false, "AV22GAMRPrivateEncryptKey", AV22GAMRPrivateEncryptKey);
         AV23GAMRRepositoryGUID = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Remoterepositoryguid;
         AssignAttri(sPrefix, false, "AV23GAMRRepositoryGUID", AV23GAMRRepositoryGUID);
         AV59AutovalidateExternalTokenAndRefresh = AV54AuthenticationTypeGAMRemoteRest.gxTpr_Gamremoterest.gxTpr_Autovalidateexternaltokenandrefresh;
         AssignAttri(sPrefix, false, "AV59AutovalidateExternalTokenAndRefresh", AV59AutovalidateExternalTokenAndRefresh);
      }

      protected void S272( )
      {
         /* 'INITAUTHENTICATIONTYPEGOOGLE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV47AuthenticationTypeGoogle.load( AV29Name);
         AV29Name = AV47AuthenticationTypeGoogle.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV47AuthenticationTypeGoogle.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV47AuthenticationTypeGoogle.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV47AuthenticationTypeGoogle.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV47AuthenticationTypeGoogle.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV47AuthenticationTypeGoogle.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV11ClientId = AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV55VersionPath = AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Versionpath;
         AssignAttri(sPrefix, false, "AV55VersionPath", AV55VersionPath);
         AV30SiteURL = AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl;
         AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
         AV8AdditionalScope = AV47AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
      }

      protected void S282( )
      {
         /* 'INITAUTHENTICATIONTYPEOTP' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETEVENTLISTVALIDATEUSER' */
         S332 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETEVENTLISTSENDCODE' */
         S342 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETEVENTLISTVALIDATECODE' */
         S352 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV21FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV21FunctionId", AV21FunctionId);
         AV81AuthenticationTypeOTP.load( AV29Name);
         AV29Name = AV81AuthenticationTypeOTP.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV81AuthenticationTypeOTP.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV81AuthenticationTypeOTP.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV81AuthenticationTypeOTP.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV81AuthenticationTypeOTP.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV81AuthenticationTypeOTP.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV64OTPUseForFirstFactorAuthentication = AV81AuthenticationTypeOTP.gxTpr_Useforfirstfactorauthentication;
         AssignAttri(sPrefix, false, "AV64OTPUseForFirstFactorAuthentication", AV64OTPUseForFirstFactorAuthentication);
         AV65OTPEventValidateUser = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventvaliduser;
         AssignAttri(sPrefix, false, "AV65OTPEventValidateUser", AV65OTPEventValidateUser);
         AV66OTPGenerationType = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generationtype;
         AssignAttri(sPrefix, false, "AV66OTPGenerationType", AV66OTPGenerationType);
         AV67OTPGenerationType_CustomEventGenerateCode = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generationtype_customeventgeneratecode;
         AssignAttri(sPrefix, false, "AV67OTPGenerationType_CustomEventGenerateCode", AV67OTPGenerationType_CustomEventGenerateCode);
         AV70OTPCodeExpirationTimeout = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Codeexpirationtimeout;
         AssignAttri(sPrefix, false, "AV70OTPCodeExpirationTimeout", StringUtil.LTrimStr( (decimal)(AV70OTPCodeExpirationTimeout), 6, 0));
         AV71OTPMaximumDailyNumberCodes = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Maximumdailynumbercodes;
         AssignAttri(sPrefix, false, "AV71OTPMaximumDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV71OTPMaximumDailyNumberCodes), 4, 0));
         AV68OTPAutogeneratedCodeLength = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Autogeneratedcodelength;
         AssignAttri(sPrefix, false, "AV68OTPAutogeneratedCodeLength", StringUtil.LTrimStr( (decimal)(AV68OTPAutogeneratedCodeLength), 4, 0));
         AV69OTPGenerateCodeOnlyNumbers = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Generatecodeonlynumbers;
         AssignAttri(sPrefix, false, "AV69OTPGenerateCodeOnlyNumbers", AV69OTPGenerateCodeOnlyNumbers);
         AV72OTPNumberUnsuccessfulRetriesToLockOTP = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Numberunsuccessfulretriestolockotp;
         AssignAttri(sPrefix, false, "AV72OTPNumberUnsuccessfulRetriesToLockOTP", StringUtil.LTrimStr( (decimal)(AV72OTPNumberUnsuccessfulRetriesToLockOTP), 4, 0));
         AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Numberunsuccessfulretriestoblockuserbasedofotplocks;
         AssignAttri(sPrefix, false, "AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks", StringUtil.LTrimStr( (decimal)(AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks), 4, 0));
         AV73OTPAutoUnlockTime = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Automaticotpunlocktime;
         AssignAttri(sPrefix, false, "AV73OTPAutoUnlockTime", StringUtil.LTrimStr( (decimal)(AV73OTPAutoUnlockTime), 15, 0));
         AV75OTPEventSendCode = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventsendcode;
         AssignAttri(sPrefix, false, "AV75OTPEventSendCode", AV75OTPEventSendCode);
         AV76OTPMailMessageSubject = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Mailmessagesubject;
         AssignAttri(sPrefix, false, "AV76OTPMailMessageSubject", AV76OTPMailMessageSubject);
         AV77OTPMailMessageBodyHTML = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Mailmessagebodyhtml;
         AssignAttri(sPrefix, false, "AV77OTPMailMessageBodyHTML", AV77OTPMailMessageBodyHTML);
         AV78OTPEventValidateCode = AV81AuthenticationTypeOTP.gxTpr_Otp.gxTpr_Eventvalidatecode;
         AssignAttri(sPrefix, false, "AV78OTPEventValidateCode", AV78OTPEventValidateCode);
      }

      protected void S292( )
      {
         /* 'INITAUTHENTICATIONTYPETWITTER' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV5AuthenticationTypeTwitter.load( AV29Name);
         AV29Name = AV5AuthenticationTypeTwitter.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV5AuthenticationTypeTwitter.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV5AuthenticationTypeTwitter.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV5AuthenticationTypeTwitter.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV5AuthenticationTypeTwitter.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV5AuthenticationTypeTwitter.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV13ConsumerKey = AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey;
         AssignAttri(sPrefix, false, "AV13ConsumerKey", AV13ConsumerKey);
         AV14ConsumerSecret = AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret;
         AssignAttri(sPrefix, false, "AV14ConsumerSecret", AV14ConsumerSecret);
         AV10CallbackURL = AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl;
         AssignAttri(sPrefix, false, "AV10CallbackURL", AV10CallbackURL);
         AV8AdditionalScope = AV5AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
      }

      protected void S302( )
      {
         /* 'INITAUTHENTICATIONTYPEWECHAT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S322 ();
         if (returnInSub) return;
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         AV80AuthenticationTypeWeChat.load( AV29Name);
         AV29Name = AV80AuthenticationTypeWeChat.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV27IsEnable = AV80AuthenticationTypeWeChat.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV27IsEnable", AV27IsEnable);
         AV20Dsc = AV80AuthenticationTypeWeChat.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV20Dsc", AV20Dsc);
         AV31SmallImageName = AV80AuthenticationTypeWeChat.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV31SmallImageName", AV31SmallImageName);
         AV9BigImageName = AV80AuthenticationTypeWeChat.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV9BigImageName", AV9BigImageName);
         AV26Impersonate = AV80AuthenticationTypeWeChat.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV26Impersonate", AV26Impersonate);
         AV11ClientId = AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Clientid;
         AssignAttri(sPrefix, false, "AV11ClientId", AV11ClientId);
         AV12ClientSecret = AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Clientsecret;
         AssignAttri(sPrefix, false, "AV12ClientSecret", AV12ClientSecret);
         AV55VersionPath = AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Versionpath;
         AssignAttri(sPrefix, false, "AV55VersionPath", AV55VersionPath);
         AV30SiteURL = AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Siteurl;
         AssignAttri(sPrefix, false, "AV30SiteURL", AV30SiteURL);
         AV8AdditionalScope = AV80AuthenticationTypeWeChat.gxTpr_Wechat.gxTpr_Additionalscope;
         AssignAttri(sPrefix, false, "AV8AdditionalScope", AV8AdditionalScope);
      }

      protected void nextLoad( )
      {
      }

      protected void E193T2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV29Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV53TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV53TypeId", AV53TypeId);
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
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
         sCtrlAV29Name = (string)((string)getParm(obj,1));
         sCtrlAV53TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wcauthenticationtypeentrygeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV29Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV29Name", AV29Name);
            AV53TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV53TypeId", AV53TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV29Name = cgiGet( sPrefix+"wcpOAV29Name");
         wcpOAV53TypeId = cgiGet( sPrefix+"wcpOAV53TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV29Name, wcpOAV29Name) != 0 ) || ( StringUtil.StrCmp(AV53TypeId, wcpOAV53TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV29Name = AV29Name;
         wcpOAV53TypeId = AV53TypeId;
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
         sCtrlAV29Name = cgiGet( sPrefix+"AV29Name_CTRL");
         if ( StringUtil.Len( sCtrlAV29Name) > 0 )
         {
            AV29Name = cgiGet( sCtrlAV29Name);
            AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         }
         else
         {
            AV29Name = cgiGet( sPrefix+"AV29Name_PARM");
         }
         sCtrlAV53TypeId = cgiGet( sPrefix+"AV53TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV53TypeId) > 0 )
         {
            AV53TypeId = cgiGet( sCtrlAV53TypeId);
            AssignAttri(sPrefix, false, "AV53TypeId", AV53TypeId);
         }
         else
         {
            AV53TypeId = cgiGet( sPrefix+"AV53TypeId_PARM");
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
         PA3T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3T2( ) ;
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
         WS3T2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29Name_PARM", StringUtil.RTrim( AV29Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29Name_CTRL", StringUtil.RTrim( sCtrlAV29Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV53TypeId_PARM", StringUtil.RTrim( AV53TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV53TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV53TypeId_CTRL", StringUtil.RTrim( sCtrlAV53TypeId));
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
         WE3T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024313821019", true, true);
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
         context.AddJavascriptSource("k2bfsg/wcauthenticationtypeentrygeneral.js", "?2024313821027", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavFunctionid.Name = "vFUNCTIONID";
         cmbavFunctionid.WebTags = "";
         cmbavFunctionid.addItem("AuthenticationAndRoles", "Authentication and Roles", 0);
         cmbavFunctionid.addItem("OnlyAuthentication", "Only Authentication", 0);
         if ( cmbavFunctionid.ItemCount > 0 )
         {
         }
         chkavIsenable.Name = "vISENABLE";
         chkavIsenable.WebTags = "";
         chkavIsenable.Caption = "";
         AssignProp(sPrefix, false, chkavIsenable_Internalname, "TitleCaption", chkavIsenable.Caption, true);
         chkavIsenable.CheckedValue = "false";
         cmbavImpersonate.Name = "vIMPERSONATE";
         cmbavImpersonate.WebTags = "";
         cmbavImpersonate.addItem("", "(None)", 0);
         if ( cmbavImpersonate.ItemCount > 0 )
         {
         }
         chkavTfaenable.Name = "vTFAENABLE";
         chkavTfaenable.WebTags = "";
         chkavTfaenable.Caption = "";
         AssignProp(sPrefix, false, chkavTfaenable_Internalname, "TitleCaption", chkavTfaenable.Caption, true);
         chkavTfaenable.CheckedValue = "false";
         cmbavTfaauthenticationtypename.Name = "vTFAAUTHENTICATIONTYPENAME";
         cmbavTfaauthenticationtypename.WebTags = "";
         if ( cmbavTfaauthenticationtypename.ItemCount > 0 )
         {
         }
         chkavTfaforceforallusers.Name = "vTFAFORCEFORALLUSERS";
         chkavTfaforceforallusers.WebTags = "";
         chkavTfaforceforallusers.Caption = "";
         AssignProp(sPrefix, false, chkavTfaforceforallusers_Internalname, "TitleCaption", chkavTfaforceforallusers.Caption, true);
         chkavTfaforceforallusers.CheckedValue = "false";
         chkavOtpuseforfirstfactorauthentication.Name = "vOTPUSEFORFIRSTFACTORAUTHENTICATION";
         chkavOtpuseforfirstfactorauthentication.WebTags = "";
         chkavOtpuseforfirstfactorauthentication.Caption = "";
         AssignProp(sPrefix, false, chkavOtpuseforfirstfactorauthentication_Internalname, "TitleCaption", chkavOtpuseforfirstfactorauthentication.Caption, true);
         chkavOtpuseforfirstfactorauthentication.CheckedValue = "false";
         cmbavOtpeventvalidateuser.Name = "vOTPEVENTVALIDATEUSER";
         cmbavOtpeventvalidateuser.WebTags = "";
         if ( cmbavOtpeventvalidateuser.ItemCount > 0 )
         {
         }
         cmbavOtpgenerationtype.Name = "vOTPGENERATIONTYPE";
         cmbavOtpgenerationtype.WebTags = "";
         cmbavOtpgenerationtype.addItem("gam", "OTP", 0);
         cmbavOtpgenerationtype.addItem("custom", "OTP custom", 0);
         cmbavOtpgenerationtype.addItem("totp", "TOTP Authenticator", 0);
         if ( cmbavOtpgenerationtype.ItemCount > 0 )
         {
         }
         cmbavOtpgenerationtype_customeventgeneratecode.Name = "vOTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE";
         cmbavOtpgenerationtype_customeventgeneratecode.WebTags = "";
         if ( cmbavOtpgenerationtype_customeventgeneratecode.ItemCount > 0 )
         {
         }
         chkavOtpgeneratecodeonlynumbers.Name = "vOTPGENERATECODEONLYNUMBERS";
         chkavOtpgeneratecodeonlynumbers.WebTags = "";
         chkavOtpgeneratecodeonlynumbers.Caption = "";
         AssignProp(sPrefix, false, chkavOtpgeneratecodeonlynumbers_Internalname, "TitleCaption", chkavOtpgeneratecodeonlynumbers.Caption, true);
         chkavOtpgeneratecodeonlynumbers.CheckedValue = "false";
         cmbavOtpeventsendcode.Name = "vOTPEVENTSENDCODE";
         cmbavOtpeventsendcode.WebTags = "";
         cmbavOtpeventsendcode.addItem("", "Email by GAM", 0);
         if ( cmbavOtpeventsendcode.ItemCount > 0 )
         {
         }
         cmbavOtpeventvalidatecode.Name = "vOTPEVENTVALIDATECODE";
         cmbavOtpeventvalidatecode.WebTags = "";
         cmbavOtpeventvalidatecode.addItem("", "GAM", 0);
         if ( cmbavOtpeventvalidatecode.ItemCount > 0 )
         {
         }
         chkavSiteurlcallbackiscustom.Name = "vSITEURLCALLBACKISCUSTOM";
         chkavSiteurlcallbackiscustom.WebTags = "";
         chkavSiteurlcallbackiscustom.Caption = "";
         AssignProp(sPrefix, false, chkavSiteurlcallbackiscustom_Internalname, "TitleCaption", chkavSiteurlcallbackiscustom.Caption, true);
         chkavSiteurlcallbackiscustom.CheckedValue = "false";
         chkavAdduseradditionaldatascope.Name = "vADDUSERADDITIONALDATASCOPE";
         chkavAdduseradditionaldatascope.WebTags = "";
         chkavAdduseradditionaldatascope.Caption = "";
         AssignProp(sPrefix, false, chkavAdduseradditionaldatascope_Internalname, "TitleCaption", chkavAdduseradditionaldatascope.Caption, true);
         chkavAdduseradditionaldatascope.CheckedValue = "false";
         chkavAddinitialpropertiesscope.Name = "vADDINITIALPROPERTIESSCOPE";
         chkavAddinitialpropertiesscope.WebTags = "";
         chkavAddinitialpropertiesscope.Caption = "";
         AssignProp(sPrefix, false, chkavAddinitialpropertiesscope_Internalname, "TitleCaption", chkavAddinitialpropertiesscope.Caption, true);
         chkavAddinitialpropertiesscope.CheckedValue = "false";
         chkavAutovalidateexternaltokenandrefresh.Name = "vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         chkavAutovalidateexternaltokenandrefresh.WebTags = "";
         chkavAutovalidateexternaltokenandrefresh.Caption = "";
         AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "TitleCaption", chkavAutovalidateexternaltokenandrefresh.Caption, true);
         chkavAutovalidateexternaltokenandrefresh.CheckedValue = "false";
         cmbavWsversion.Name = "vWSVERSION";
         cmbavWsversion.WebTags = "";
         cmbavWsversion.addItem("GAM10", "Version 1.0", 0);
         cmbavWsversion.addItem("GAM20", "Version 2.0", 0);
         if ( cmbavWsversion.ItemCount > 0 )
         {
         }
         cmbavWsserversecureprotocol.Name = "vWSSERVERSECUREPROTOCOL";
         cmbavWsserversecureprotocol.WebTags = "";
         cmbavWsserversecureprotocol.addItem("0", "No", 0);
         cmbavWsserversecureprotocol.addItem("1", "Yes", 0);
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
         }
         cmbavCusversion.Name = "vCUSVERSION";
         cmbavCusversion.WebTags = "";
         cmbavCusversion.addItem("GAM10", "Version 1.0", 0);
         cmbavCusversion.addItem("GAM20", "Version 2.0", 0);
         if ( cmbavCusversion.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
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
         divAttributescontainertable_tbldata_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLDATA";
         divTbldata_content_Internalname = sPrefix+"TBLDATA_CONTENT";
         Tbldata_Internalname = sPrefix+"TBLDATA";
         cmbavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         divTable_container_impersonate_Internalname = sPrefix+"TABLE_CONTAINER_IMPERSONATE";
         divAttributescontainertable_tblimpersonate_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLIMPERSONATE";
         divTblimpersonate_content_Internalname = sPrefix+"TBLIMPERSONATE_CONTENT";
         Tblimpersonate_Internalname = sPrefix+"TBLIMPERSONATE";
         chkavTfaenable_Internalname = sPrefix+"vTFAENABLE";
         divTable_container_tfaenable_Internalname = sPrefix+"TABLE_CONTAINER_TFAENABLE";
         divAttributescontainertable_tblenabletwofactorauth_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLENABLETWOFACTORAUTH";
         divTblenabletwofactorauth_content_Internalname = sPrefix+"TBLENABLETWOFACTORAUTH_CONTENT";
         Tblenabletwofactorauth_Internalname = sPrefix+"TBLENABLETWOFACTORAUTH";
         cmbavTfaauthenticationtypename_Internalname = sPrefix+"vTFAAUTHENTICATIONTYPENAME";
         divTable_container_tfaauthenticationtypename_Internalname = sPrefix+"TABLE_CONTAINER_TFAAUTHENTICATIONTYPENAME";
         edtavTfafirstfactorauthenticationexpiration_Internalname = sPrefix+"vTFAFIRSTFACTORAUTHENTICATIONEXPIRATION";
         divTable_container_tfafirstfactorauthenticationexpiration_Internalname = sPrefix+"TABLE_CONTAINER_TFAFIRSTFACTORAUTHENTICATIONEXPIRATION";
         chkavTfaforceforallusers_Internalname = sPrefix+"vTFAFORCEFORALLUSERS";
         divTable_container_tfaforceforallusers_Internalname = sPrefix+"TABLE_CONTAINER_TFAFORCEFORALLUSERS";
         divAttributescontainertable_tbltwofactorauthentication_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLTWOFACTORAUTHENTICATION";
         divTbltwofactorauthentication_content_Internalname = sPrefix+"TBLTWOFACTORAUTHENTICATION_CONTENT";
         Tbltwofactorauthentication_Internalname = sPrefix+"TBLTWOFACTORAUTHENTICATION";
         chkavOtpuseforfirstfactorauthentication_Internalname = sPrefix+"vOTPUSEFORFIRSTFACTORAUTHENTICATION";
         divTable_container_otpuseforfirstfactorauthentication_Internalname = sPrefix+"TABLE_CONTAINER_OTPUSEFORFIRSTFACTORAUTHENTICATION";
         cmbavOtpeventvalidateuser_Internalname = sPrefix+"vOTPEVENTVALIDATEUSER";
         divTable_container_otpeventvalidateuser_Internalname = sPrefix+"TABLE_CONTAINER_OTPEVENTVALIDATEUSER";
         cmbavOtpgenerationtype_Internalname = sPrefix+"vOTPGENERATIONTYPE";
         divTable_container_otpgenerationtype_Internalname = sPrefix+"TABLE_CONTAINER_OTPGENERATIONTYPE";
         cmbavOtpgenerationtype_customeventgeneratecode_Internalname = sPrefix+"vOTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE";
         divTable_container_otpgenerationtype_customeventgeneratecode_Internalname = sPrefix+"TABLE_CONTAINER_OTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE";
         divColumn1_Internalname = sPrefix+"COLUMN1";
         divTblotpcustom_Internalname = sPrefix+"TBLOTPCUSTOM";
         edtavOtpautogeneratedcodelength_Internalname = sPrefix+"vOTPAUTOGENERATEDCODELENGTH";
         divTable_container_otpautogeneratedcodelength_Internalname = sPrefix+"TABLE_CONTAINER_OTPAUTOGENERATEDCODELENGTH";
         chkavOtpgeneratecodeonlynumbers_Internalname = sPrefix+"vOTPGENERATECODEONLYNUMBERS";
         divTable_container_otpgeneratecodeonlynumbers_Internalname = sPrefix+"TABLE_CONTAINER_OTPGENERATECODEONLYNUMBERS";
         divColumn3_Internalname = sPrefix+"COLUMN3";
         divTbltypeotpgeneratecode_Internalname = sPrefix+"TBLTYPEOTPGENERATECODE";
         edtavOtpcodeexpirationtimeout_Internalname = sPrefix+"vOTPCODEEXPIRATIONTIMEOUT";
         divTable_container_otpcodeexpirationtimeout_Internalname = sPrefix+"TABLE_CONTAINER_OTPCODEEXPIRATIONTIMEOUT";
         edtavOtpmaximumdailynumbercodes_Internalname = sPrefix+"vOTPMAXIMUMDAILYNUMBERCODES";
         divTable_container_otpmaximumdailynumbercodes_Internalname = sPrefix+"TABLE_CONTAINER_OTPMAXIMUMDAILYNUMBERCODES";
         edtavOtpnumberunsuccessfulretriestolockotp_Internalname = sPrefix+"vOTPNUMBERUNSUCCESSFULRETRIESTOLOCKOTP";
         divTable_container_otpnumberunsuccessfulretriestolockotp_Internalname = sPrefix+"TABLE_CONTAINER_OTPNUMBERUNSUCCESSFULRETRIESTOLOCKOTP";
         edtavOtpautounlocktime_Internalname = sPrefix+"vOTPAUTOUNLOCKTIME";
         divTable_container_otpautounlocktime_Internalname = sPrefix+"TABLE_CONTAINER_OTPAUTOUNLOCKTIME";
         edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname = sPrefix+"vOTPNUMBERUNSUCCESSFULRETRIESTOBLOCKUSERBASEDOFOTPLOCKS";
         divTable_container_otpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname = sPrefix+"TABLE_CONTAINER_OTPNUMBERUNSUCCESSFULRETRIESTOBLOCKUSERBASEDOFOTPLOCKS";
         cmbavOtpeventsendcode_Internalname = sPrefix+"vOTPEVENTSENDCODE";
         divTable_container_otpeventsendcode_Internalname = sPrefix+"TABLE_CONTAINER_OTPEVENTSENDCODE";
         edtavOtpmailmessagesubject_Internalname = sPrefix+"vOTPMAILMESSAGESUBJECT";
         divTable_container_otpmailmessagesubject_Internalname = sPrefix+"TABLE_CONTAINER_OTPMAILMESSAGESUBJECT";
         edtavOtpmailmessagebodyhtml_Internalname = sPrefix+"vOTPMAILMESSAGEBODYHTML";
         divTable_container_otpmailmessagebodyhtml_Internalname = sPrefix+"TABLE_CONTAINER_OTPMAILMESSAGEBODYHTML";
         divColumn4_Internalname = sPrefix+"COLUMN4";
         divTblsendemailbygam_Internalname = sPrefix+"TBLSENDEMAILBYGAM";
         cmbavOtpeventvalidatecode_Internalname = sPrefix+"vOTPEVENTVALIDATECODE";
         divTable_container_otpeventvalidatecode_Internalname = sPrefix+"TABLE_CONTAINER_OTPEVENTVALIDATECODE";
         divColumn_Internalname = sPrefix+"COLUMN";
         divTblotpconfiguration_Internalname = sPrefix+"TBLOTPCONFIGURATION";
         divAttributescontainertable_tblotpauthentication_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLOTPAUTHENTICATION";
         divTblotpauthentication_content_Internalname = sPrefix+"TBLOTPAUTHENTICATION_CONTENT";
         Tblotpauthentication_Internalname = sPrefix+"TBLOTPAUTHENTICATION";
         edtavClientid_Internalname = sPrefix+"vCLIENTID";
         divTable_container_clientid_Internalname = sPrefix+"TABLE_CONTAINER_CLIENTID";
         edtavClientsecret_Internalname = sPrefix+"vCLIENTSECRET";
         divTable_container_clientsecret_Internalname = sPrefix+"TABLE_CONTAINER_CLIENTSECRET";
         edtavVersionpath_Internalname = sPrefix+"vVERSIONPATH";
         divTable_container_versionpath_Internalname = sPrefix+"TABLE_CONTAINER_VERSIONPATH";
         divAttributescontainertable_tblclientidsecret_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCLIENTIDSECRET";
         divTblclientidsecret_content_Internalname = sPrefix+"TBLCLIENTIDSECRET_CONTENT";
         Tblclientidsecret_Internalname = sPrefix+"TBLCLIENTIDSECRET";
         edtavSiteurl_Internalname = sPrefix+"vSITEURL";
         divTable_container_siteurl_Internalname = sPrefix+"TABLE_CONTAINER_SITEURL";
         divAttributescontainertable_tblclientlocalserver_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCLIENTLOCALSERVER";
         divTblclientlocalserver_content_Internalname = sPrefix+"TBLCLIENTLOCALSERVER_CONTENT";
         Tblclientlocalserver_Internalname = sPrefix+"TBLCLIENTLOCALSERVER";
         chkavSiteurlcallbackiscustom_Internalname = sPrefix+"vSITEURLCALLBACKISCUSTOM";
         divTable_container_siteurlcallbackiscustom_Internalname = sPrefix+"TABLE_CONTAINER_SITEURLCALLBACKISCUSTOM";
         divAttributescontainertable_tblcustomcallbackurl_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCUSTOMCALLBACKURL";
         divTblcustomcallbackurl_content_Internalname = sPrefix+"TBLCUSTOMCALLBACKURL_CONTENT";
         Tblcustomcallbackurl_Internalname = sPrefix+"TBLCUSTOMCALLBACKURL";
         edtavConsumerkey_Internalname = sPrefix+"vCONSUMERKEY";
         divTable_container_consumerkey_Internalname = sPrefix+"TABLE_CONTAINER_CONSUMERKEY";
         edtavConsumersecret_Internalname = sPrefix+"vCONSUMERSECRET";
         divTable_container_consumersecret_Internalname = sPrefix+"TABLE_CONTAINER_CONSUMERSECRET";
         edtavCallbackurl_Internalname = sPrefix+"vCALLBACKURL";
         divTable_container_callbackurl_Internalname = sPrefix+"TABLE_CONTAINER_CALLBACKURL";
         divAttributescontainertable_tbltwitter_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLTWITTER";
         divTbltwitter_content_Internalname = sPrefix+"TBLTWITTER_CONTENT";
         Tbltwitter_Internalname = sPrefix+"TBLTWITTER";
         chkavAdduseradditionaldatascope_Internalname = sPrefix+"vADDUSERADDITIONALDATASCOPE";
         divTable_container_adduseradditionaldatascope_Internalname = sPrefix+"TABLE_CONTAINER_ADDUSERADDITIONALDATASCOPE";
         chkavAddinitialpropertiesscope_Internalname = sPrefix+"vADDINITIALPROPERTIESSCOPE";
         divTable_container_addinitialpropertiesscope_Internalname = sPrefix+"TABLE_CONTAINER_ADDINITIALPROPERTIESSCOPE";
         divAttributescontainertable_tblscopes_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLSCOPES";
         divTblscopes_content_Internalname = sPrefix+"TBLSCOPES_CONTENT";
         Tblscopes_Internalname = sPrefix+"TBLSCOPES";
         edtavAdditionalscope_Internalname = sPrefix+"vADDITIONALSCOPE";
         divTable_container_additionalscope_Internalname = sPrefix+"TABLE_CONTAINER_ADDITIONALSCOPE";
         divAttributescontainertable_tblcommonadditional_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLCOMMONADDITIONAL";
         divTblcommonadditional_content_Internalname = sPrefix+"TBLCOMMONADDITIONAL_CONTENT";
         Tblcommonadditional_Internalname = sPrefix+"TBLCOMMONADDITIONAL";
         edtavGamrauthenticationtypename_Internalname = sPrefix+"vGAMRAUTHENTICATIONTYPENAME";
         divTable_container_gamrauthenticationtypename_Internalname = sPrefix+"TABLE_CONTAINER_GAMRAUTHENTICATIONTYPENAME";
         divAttributescontainertable_tblauthtypename_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLAUTHTYPENAME";
         divTblauthtypename_content_Internalname = sPrefix+"TBLAUTHTYPENAME_CONTENT";
         Tblauthtypename_Internalname = sPrefix+"TBLAUTHTYPENAME";
         edtavGamrserverurl_Internalname = sPrefix+"vGAMRSERVERURL";
         divTable_container_gamrserverurl_Internalname = sPrefix+"TABLE_CONTAINER_GAMRSERVERURL";
         edtavGamrprivateencryptkey_Internalname = sPrefix+"vGAMRPRIVATEENCRYPTKEY";
         divTable_container_gamrprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_GAMRPRIVATEENCRYPTKEY";
         edtavGamrrepositoryguid_Internalname = sPrefix+"vGAMRREPOSITORYGUID";
         divTable_container_gamrrepositoryguid_Internalname = sPrefix+"TABLE_CONTAINER_GAMRREPOSITORYGUID";
         chkavAutovalidateexternaltokenandrefresh_Internalname = sPrefix+"vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         divTable_container_autovalidateexternaltokenandrefresh_Internalname = sPrefix+"TABLE_CONTAINER_AUTOVALIDATEEXTERNALTOKENANDREFRESH";
         divAttributescontainertable_tblserverhost_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLSERVERHOST";
         divTblserverhost_content_Internalname = sPrefix+"TBLSERVERHOST_CONTENT";
         Tblserverhost_Internalname = sPrefix+"TBLSERVERHOST";
         cmbavWsversion_Internalname = sPrefix+"vWSVERSION";
         divTable_container_wsversion_Internalname = sPrefix+"TABLE_CONTAINER_WSVERSION";
         lblTextblock_var_wsprivateencryptkey_Internalname = sPrefix+"TEXTBLOCK_VAR_WSPRIVATEENCRYPTKEY";
         edtavWsprivateencryptkey_Internalname = sPrefix+"vWSPRIVATEENCRYPTKEY";
         bttBtngenkey_Internalname = sPrefix+"BTNGENKEY";
         divTable_container_wsprivateencryptkeycellcontainer_Internalname = sPrefix+"TABLE_CONTAINER_WSPRIVATEENCRYPTKEYCELLCONTAINER";
         divTable_container_wsprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_WSPRIVATEENCRYPTKEY";
         edtavWsservername_Internalname = sPrefix+"vWSSERVERNAME";
         divTable_container_wsservername_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERNAME";
         edtavWsserverport_Internalname = sPrefix+"vWSSERVERPORT";
         divTable_container_wsserverport_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERPORT";
         edtavWsserverbaseurl_Internalname = sPrefix+"vWSSERVERBASEURL";
         divTable_container_wsserverbaseurl_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERBASEURL";
         cmbavWsserversecureprotocol_Internalname = sPrefix+"vWSSERVERSECUREPROTOCOL";
         divTable_container_wsserversecureprotocol_Internalname = sPrefix+"TABLE_CONTAINER_WSSERVERSECUREPROTOCOL";
         edtavWstimeout_Internalname = sPrefix+"vWSTIMEOUT";
         divTable_container_wstimeout_Internalname = sPrefix+"TABLE_CONTAINER_WSTIMEOUT";
         edtavWspackage_Internalname = sPrefix+"vWSPACKAGE";
         divTable_container_wspackage_Internalname = sPrefix+"TABLE_CONTAINER_WSPACKAGE";
         edtavWsname_Internalname = sPrefix+"vWSNAME";
         divTable_container_wsname_Internalname = sPrefix+"TABLE_CONTAINER_WSNAME";
         edtavWsextension_Internalname = sPrefix+"vWSEXTENSION";
         divTable_container_wsextension_Internalname = sPrefix+"TABLE_CONTAINER_WSEXTENSION";
         divAttributescontainertable_tblwebservice_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLWEBSERVICE";
         divTblwebservice_content_Internalname = sPrefix+"TBLWEBSERVICE_CONTENT";
         Tblwebservice_Internalname = sPrefix+"TBLWEBSERVICE";
         cmbavCusversion_Internalname = sPrefix+"vCUSVERSION";
         divTable_container_cusversion_Internalname = sPrefix+"TABLE_CONTAINER_CUSVERSION";
         lblTextblock_var_cusprivateencryptkey_Internalname = sPrefix+"TEXTBLOCK_VAR_CUSPRIVATEENCRYPTKEY";
         edtavCusprivateencryptkey_Internalname = sPrefix+"vCUSPRIVATEENCRYPTKEY";
         bttBtngenkeycustom_Internalname = sPrefix+"BTNGENKEYCUSTOM";
         divTable_container_cusprivateencryptkeycellcontainer_Internalname = sPrefix+"TABLE_CONTAINER_CUSPRIVATEENCRYPTKEYCELLCONTAINER";
         divTable_container_cusprivateencryptkey_Internalname = sPrefix+"TABLE_CONTAINER_CUSPRIVATEENCRYPTKEY";
         edtavCusfilename_Internalname = sPrefix+"vCUSFILENAME";
         divTable_container_cusfilename_Internalname = sPrefix+"TABLE_CONTAINER_CUSFILENAME";
         edtavCuspackage_Internalname = sPrefix+"vCUSPACKAGE";
         divTable_container_cuspackage_Internalname = sPrefix+"TABLE_CONTAINER_CUSPACKAGE";
         edtavCusclassname_Internalname = sPrefix+"vCUSCLASSNAME";
         divTable_container_cusclassname_Internalname = sPrefix+"TABLE_CONTAINER_CUSCLASSNAME";
         divAttributescontainertable_tblexternal_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBLEXTERNAL";
         divTblexternal_content_Internalname = sPrefix+"TBLEXTERNAL_CONTENT";
         Tblexternal_Internalname = sPrefix+"TBLEXTERNAL";
         bttConfirm_Internalname = sPrefix+"CONFIRM";
         bttCancel_Internalname = sPrefix+"CANCEL";
         divActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         chkavAutovalidateexternaltokenandrefresh.Caption = "Validate external token";
         chkavAddinitialpropertiesscope.Caption = "Add gam_session_initial_prop scope";
         chkavAdduseradditionaldatascope.Caption = "Add gam_user_additional_data scope";
         chkavSiteurlcallbackiscustom.Caption = "Custom callback URL?";
         chkavOtpgeneratecodeonlynumbers.Caption = "Generate code only with numbers?";
         chkavOtpuseforfirstfactorauthentication.Caption = "Use for first factor authentication?";
         chkavTfaforceforallusers.Caption = "Force 2FA for all users?";
         chkavTfaenable.Caption = "TFA Enable";
         chkavIsenable.Caption = "Enabled?";
         bttConfirm_Caption = "Confirm";
         bttConfirm_Visible = 1;
         edtavCusclassname_Jsonclick = "";
         edtavCusclassname_Enabled = 1;
         edtavCuspackage_Jsonclick = "";
         edtavCuspackage_Enabled = 1;
         edtavCusfilename_Jsonclick = "";
         edtavCusfilename_Enabled = 1;
         bttBtngenkeycustom_Visible = 1;
         edtavCusprivateencryptkey_Jsonclick = "";
         edtavCusprivateencryptkey_Enabled = 1;
         cmbavCusversion_Jsonclick = "";
         cmbavCusversion.Enabled = 1;
         divAttributescontainertable_tblexternal_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavWsextension_Jsonclick = "";
         edtavWsextension_Enabled = 1;
         edtavWsname_Jsonclick = "";
         edtavWsname_Enabled = 1;
         edtavWspackage_Jsonclick = "";
         edtavWspackage_Enabled = 1;
         edtavWstimeout_Jsonclick = "";
         edtavWstimeout_Enabled = 1;
         cmbavWsserversecureprotocol_Jsonclick = "";
         cmbavWsserversecureprotocol.Enabled = 1;
         edtavWsserverbaseurl_Jsonclick = "";
         edtavWsserverbaseurl_Enabled = 1;
         edtavWsserverport_Jsonclick = "";
         edtavWsserverport_Enabled = 1;
         edtavWsservername_Jsonclick = "";
         edtavWsservername_Enabled = 1;
         bttBtngenkey_Visible = 1;
         edtavWsprivateencryptkey_Jsonclick = "";
         edtavWsprivateencryptkey_Enabled = 1;
         cmbavWsversion_Jsonclick = "";
         cmbavWsversion.Enabled = 1;
         divAttributescontainertable_tblwebservice_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         chkavAutovalidateexternaltokenandrefresh.Enabled = 1;
         edtavGamrrepositoryguid_Jsonclick = "";
         edtavGamrrepositoryguid_Enabled = 1;
         edtavGamrprivateencryptkey_Jsonclick = "";
         edtavGamrprivateencryptkey_Enabled = 1;
         edtavGamrserverurl_Jsonclick = "";
         edtavGamrserverurl_Enabled = 1;
         divAttributescontainertable_tblserverhost_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavGamrauthenticationtypename_Jsonclick = "";
         edtavGamrauthenticationtypename_Enabled = 1;
         divAttributescontainertable_tblauthtypename_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavAdditionalscope_Jsonclick = "";
         edtavAdditionalscope_Enabled = 1;
         divAttributescontainertable_tblcommonadditional_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         chkavAddinitialpropertiesscope.Enabled = 1;
         chkavAdduseradditionaldatascope.Enabled = 1;
         divAttributescontainertable_tblscopes_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavCallbackurl_Jsonclick = "";
         edtavCallbackurl_Enabled = 1;
         edtavConsumersecret_Jsonclick = "";
         edtavConsumersecret_Enabled = 1;
         edtavConsumerkey_Jsonclick = "";
         edtavConsumerkey_Enabled = 1;
         divAttributescontainertable_tbltwitter_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         chkavSiteurlcallbackiscustom.Enabled = 1;
         edtavSiteurl_Jsonclick = "";
         edtavSiteurl_Enabled = 1;
         edtavSiteurl_Visible = 1;
         divAttributescontainertable_tblclientlocalserver_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavVersionpath_Jsonclick = "";
         edtavVersionpath_Enabled = 1;
         edtavVersionpath_Visible = 1;
         edtavClientsecret_Jsonclick = "";
         edtavClientsecret_Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         divAttributescontainertable_tblclientidsecret_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         cmbavOtpeventvalidatecode_Jsonclick = "";
         cmbavOtpeventvalidatecode.Enabled = 1;
         edtavOtpmailmessagebodyhtml_Enabled = 1;
         edtavOtpmailmessagesubject_Jsonclick = "";
         edtavOtpmailmessagesubject_Enabled = 1;
         cmbavOtpeventsendcode_Jsonclick = "";
         cmbavOtpeventsendcode.Enabled = 1;
         edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Jsonclick = "";
         edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Enabled = 1;
         edtavOtpautounlocktime_Jsonclick = "";
         edtavOtpautounlocktime_Enabled = 1;
         edtavOtpnumberunsuccessfulretriestolockotp_Jsonclick = "";
         edtavOtpnumberunsuccessfulretriestolockotp_Enabled = 1;
         edtavOtpmaximumdailynumbercodes_Jsonclick = "";
         edtavOtpmaximumdailynumbercodes_Enabled = 1;
         edtavOtpcodeexpirationtimeout_Jsonclick = "";
         edtavOtpcodeexpirationtimeout_Enabled = 1;
         chkavOtpgeneratecodeonlynumbers.Enabled = 1;
         edtavOtpautogeneratedcodelength_Jsonclick = "";
         edtavOtpautogeneratedcodelength_Enabled = 1;
         divTbltypeotpgeneratecode_Visible = 1;
         cmbavOtpgenerationtype_customeventgeneratecode_Jsonclick = "";
         cmbavOtpgenerationtype_customeventgeneratecode.Enabled = 1;
         divTblotpcustom_Visible = 1;
         cmbavOtpgenerationtype_Jsonclick = "";
         cmbavOtpgenerationtype.Enabled = 1;
         cmbavOtpeventvalidateuser_Jsonclick = "";
         cmbavOtpeventvalidateuser.Enabled = 1;
         divTblotpconfiguration_Visible = 1;
         chkavOtpuseforfirstfactorauthentication.Enabled = 1;
         chkavTfaforceforallusers.Enabled = 1;
         edtavTfafirstfactorauthenticationexpiration_Jsonclick = "";
         edtavTfafirstfactorauthenticationexpiration_Enabled = 1;
         cmbavTfaauthenticationtypename_Jsonclick = "";
         cmbavTfaauthenticationtypename.Enabled = 1;
         chkavTfaenable.Enabled = 1;
         cmbavImpersonate_Jsonclick = "";
         cmbavImpersonate.Enabled = 1;
         divAttributescontainertable_tblimpersonate_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
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
         divAttributescontainertable_tbldata_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         divContenttable_Class = "K2BToolsTable_WebPanelDesignerContent";
         Tblexternal_Visible = Convert.ToBoolean( -1);
         Tblexternal_Containseditableform = Convert.ToBoolean( -1);
         Tblexternal_Showborders = Convert.ToBoolean( -1);
         Tblexternal_Open = Convert.ToBoolean( -1);
         Tblexternal_Collapsible = Convert.ToBoolean( 0);
         Tblexternal_Title = "";
         Tblwebservice_Visible = Convert.ToBoolean( -1);
         Tblwebservice_Containseditableform = Convert.ToBoolean( -1);
         Tblwebservice_Showborders = Convert.ToBoolean( -1);
         Tblwebservice_Open = Convert.ToBoolean( -1);
         Tblwebservice_Collapsible = Convert.ToBoolean( 0);
         Tblwebservice_Title = "";
         Tblserverhost_Visible = Convert.ToBoolean( -1);
         Tblserverhost_Containseditableform = Convert.ToBoolean( -1);
         Tblserverhost_Showborders = Convert.ToBoolean( -1);
         Tblserverhost_Open = Convert.ToBoolean( -1);
         Tblserverhost_Collapsible = Convert.ToBoolean( 0);
         Tblserverhost_Title = "";
         Tblauthtypename_Visible = Convert.ToBoolean( -1);
         Tblauthtypename_Containseditableform = Convert.ToBoolean( -1);
         Tblauthtypename_Showborders = Convert.ToBoolean( -1);
         Tblauthtypename_Open = Convert.ToBoolean( -1);
         Tblauthtypename_Collapsible = Convert.ToBoolean( 0);
         Tblauthtypename_Title = "";
         Tblcommonadditional_Visible = Convert.ToBoolean( -1);
         Tblcommonadditional_Containseditableform = Convert.ToBoolean( -1);
         Tblcommonadditional_Showborders = Convert.ToBoolean( -1);
         Tblcommonadditional_Open = Convert.ToBoolean( -1);
         Tblcommonadditional_Collapsible = Convert.ToBoolean( 0);
         Tblcommonadditional_Title = "";
         Tblscopes_Visible = Convert.ToBoolean( -1);
         Tblscopes_Containseditableform = Convert.ToBoolean( -1);
         Tblscopes_Showborders = Convert.ToBoolean( -1);
         Tblscopes_Open = Convert.ToBoolean( -1);
         Tblscopes_Collapsible = Convert.ToBoolean( 0);
         Tblscopes_Title = "";
         Tbltwitter_Visible = Convert.ToBoolean( -1);
         Tbltwitter_Containseditableform = Convert.ToBoolean( -1);
         Tbltwitter_Showborders = Convert.ToBoolean( -1);
         Tbltwitter_Open = Convert.ToBoolean( -1);
         Tbltwitter_Collapsible = Convert.ToBoolean( 0);
         Tbltwitter_Title = "";
         Tblcustomcallbackurl_Containseditableform = Convert.ToBoolean( -1);
         Tblcustomcallbackurl_Showborders = Convert.ToBoolean( -1);
         Tblcustomcallbackurl_Open = Convert.ToBoolean( -1);
         Tblcustomcallbackurl_Collapsible = Convert.ToBoolean( 0);
         Tblcustomcallbackurl_Title = "";
         Tblclientlocalserver_Visible = Convert.ToBoolean( -1);
         Tblclientlocalserver_Containseditableform = Convert.ToBoolean( -1);
         Tblclientlocalserver_Showborders = Convert.ToBoolean( -1);
         Tblclientlocalserver_Open = Convert.ToBoolean( -1);
         Tblclientlocalserver_Collapsible = Convert.ToBoolean( 0);
         Tblclientlocalserver_Title = "";
         Tblclientidsecret_Visible = Convert.ToBoolean( -1);
         Tblclientidsecret_Containseditableform = Convert.ToBoolean( -1);
         Tblclientidsecret_Showborders = Convert.ToBoolean( -1);
         Tblclientidsecret_Open = Convert.ToBoolean( -1);
         Tblclientidsecret_Collapsible = Convert.ToBoolean( 0);
         Tblclientidsecret_Title = "";
         Tblotpauthentication_Visible = Convert.ToBoolean( -1);
         Tblotpauthentication_Containseditableform = Convert.ToBoolean( -1);
         Tblotpauthentication_Showborders = Convert.ToBoolean( -1);
         Tblotpauthentication_Open = Convert.ToBoolean( -1);
         Tblotpauthentication_Collapsible = Convert.ToBoolean( 0);
         Tblotpauthentication_Title = "";
         Tbltwofactorauthentication_Visible = Convert.ToBoolean( -1);
         Tbltwofactorauthentication_Containseditableform = Convert.ToBoolean( -1);
         Tbltwofactorauthentication_Showborders = Convert.ToBoolean( -1);
         Tbltwofactorauthentication_Open = Convert.ToBoolean( -1);
         Tbltwofactorauthentication_Collapsible = Convert.ToBoolean( 0);
         Tbltwofactorauthentication_Title = "";
         Tblenabletwofactorauth_Visible = Convert.ToBoolean( -1);
         Tblenabletwofactorauth_Containseditableform = Convert.ToBoolean( -1);
         Tblenabletwofactorauth_Showborders = Convert.ToBoolean( -1);
         Tblenabletwofactorauth_Open = Convert.ToBoolean( -1);
         Tblenabletwofactorauth_Collapsible = Convert.ToBoolean( 0);
         Tblenabletwofactorauth_Title = "";
         Tblimpersonate_Visible = Convert.ToBoolean( -1);
         Tblimpersonate_Containseditableform = Convert.ToBoolean( -1);
         Tblimpersonate_Showborders = Convert.ToBoolean( -1);
         Tblimpersonate_Open = Convert.ToBoolean( -1);
         Tblimpersonate_Collapsible = Convert.ToBoolean( 0);
         Tblimpersonate_Title = "";
         Tbldata_Containseditableform = Convert.ToBoolean( -1);
         Tbldata_Showborders = Convert.ToBoolean( -1);
         Tbldata_Open = Convert.ToBoolean( -1);
         Tbldata_Collapsible = Convert.ToBoolean( 0);
         Tbldata_Title = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV27IsEnable',fld:'vISENABLE',pic:''},{av:'AV60TFAEnable',fld:'vTFAENABLE',pic:''},{av:'AV63TFAForceForAllUsers',fld:'vTFAFORCEFORALLUSERS',pic:''},{av:'AV64OTPUseForFirstFactorAuthentication',fld:'vOTPUSEFORFIRSTFACTORAUTHENTICATION',pic:''},{av:'AV69OTPGenerateCodeOnlyNumbers',fld:'vOTPGENERATECODEONLYNUMBERS',pic:''},{av:'AV79SiteURLCallbackIsCustom',fld:'vSITEURLCALLBACKISCUSTOM',pic:''},{av:'AV56AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV57AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV59AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_BTNGENKEY'","{handler:'E143T2',iparms:[]");
         setEventMetadata("'E_BTNGENKEY'",",oparms:[{av:'AV38WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''}]}");
         setEventMetadata("'E_BTNGENKEYCUSTOM'","{handler:'E153T2',iparms:[]");
         setEventMetadata("'E_BTNGENKEYCUSTOM'",",oparms:[{av:'AV18CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''}]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E163T2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV15CusClassName',fld:'vCUSCLASSNAME',pic:''},{av:'AV17CusPackage',fld:'vCUSPACKAGE',pic:''},{av:'AV16CusFileName',fld:'vCUSFILENAME',pic:''},{av:'AV18CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavCusversion'},{av:'AV19CusVersion',fld:'vCUSVERSION',pic:''},{av:'cmbavWsserversecureprotocol'},{av:'AV42WSServerSecureProtocol',fld:'vWSSERVERSECUREPROTOCOL',pic:'ZZZ9'},{av:'AV39WSServerBaseURL',fld:'vWSSERVERBASEURL',pic:''},{av:'AV41WSServerPort',fld:'vWSSERVERPORT',pic:'ZZZ9'},{av:'AV40WSServerName',fld:'vWSSERVERNAME',pic:''},{av:'AV35WSExtension',fld:'vWSEXTENSION',pic:''},{av:'AV36WSName',fld:'vWSNAME',pic:''},{av:'AV37WSPackage',fld:'vWSPACKAGE',pic:''},{av:'AV43WSTimeout',fld:'vWSTIMEOUT',pic:'ZZZ9'},{av:'AV38WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavWsversion'},{av:'AV44WSVersion',fld:'vWSVERSION',pic:''},{av:'AV79SiteURLCallbackIsCustom',fld:'vSITEURLCALLBACKISCUSTOM',pic:''},{av:'AV59AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV23GAMRRepositoryGUID',fld:'vGAMRREPOSITORYGUID',pic:''},{av:'AV22GAMRPrivateEncryptKey',fld:'vGAMRPRIVATEENCRYPTKEY',pic:''},{av:'AV24GAMRServerURL',fld:'vGAMRSERVERURL',pic:''},{av:'AV58GAMRAuthenticationTypeName',fld:'vGAMRAUTHENTICATIONTYPENAME',pic:''},{av:'AV56AddUserAdditionalDataScope',fld:'vADDUSERADDITIONALDATASCOPE',pic:''},{av:'AV57AddInitialPropertiesScope',fld:'vADDINITIALPROPERTIESSCOPE',pic:''},{av:'AV63TFAForceForAllUsers',fld:'vTFAFORCEFORALLUSERS',pic:''},{av:'AV62TFAFirstFactorAuthenticationExpiration',fld:'vTFAFIRSTFACTORAUTHENTICATIONEXPIRATION',pic:'ZZZZZZZZZZZZZZ9'},{av:'cmbavTfaauthenticationtypename'},{av:'AV61TFAAuthenticationTypeName',fld:'vTFAAUTHENTICATIONTYPENAME',pic:''},{av:'AV60TFAEnable',fld:'vTFAENABLE',pic:''},{av:'cmbavFunctionid'},{av:'AV21FunctionId',fld:'vFUNCTIONID',pic:''},{av:'cmbavOtpeventvalidatecode'},{av:'AV78OTPEventValidateCode',fld:'vOTPEVENTVALIDATECODE',pic:''},{av:'AV77OTPMailMessageBodyHTML',fld:'vOTPMAILMESSAGEBODYHTML',pic:''},{av:'AV76OTPMailMessageSubject',fld:'vOTPMAILMESSAGESUBJECT',pic:''},{av:'cmbavOtpeventsendcode'},{av:'AV75OTPEventSendCode',fld:'vOTPEVENTSENDCODE',pic:''},{av:'AV73OTPAutoUnlockTime',fld:'vOTPAUTOUNLOCKTIME',pic:'ZZZZZZZZZZZZZZ9'},{av:'AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks',fld:'vOTPNUMBERUNSUCCESSFULRETRIESTOBLOCKUSERBASEDOFOTPLOCKS',pic:'ZZZ9'},{av:'AV72OTPNumberUnsuccessfulRetriesToLockOTP',fld:'vOTPNUMBERUNSUCCESSFULRETRIESTOLOCKOTP',pic:'ZZZ9'},{av:'AV69OTPGenerateCodeOnlyNumbers',fld:'vOTPGENERATECODEONLYNUMBERS',pic:''},{av:'AV68OTPAutogeneratedCodeLength',fld:'vOTPAUTOGENERATEDCODELENGTH',pic:'ZZZ9'},{av:'AV71OTPMaximumDailyNumberCodes',fld:'vOTPMAXIMUMDAILYNUMBERCODES',pic:'ZZZ9'},{av:'AV70OTPCodeExpirationTimeout',fld:'vOTPCODEEXPIRATIONTIMEOUT',pic:'ZZZZZ9'},{av:'cmbavOtpgenerationtype_customeventgeneratecode'},{av:'AV67OTPGenerationType_CustomEventGenerateCode',fld:'vOTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE',pic:''},{av:'cmbavOtpgenerationtype'},{av:'AV66OTPGenerationType',fld:'vOTPGENERATIONTYPE',pic:''},{av:'cmbavOtpeventvalidateuser'},{av:'AV65OTPEventValidateUser',fld:'vOTPEVENTVALIDATEUSER',pic:''},{av:'AV64OTPUseForFirstFactorAuthentication',fld:'vOTPUSEFORFIRSTFACTORAUTHENTICATION',pic:''},{av:'AV10CallbackURL',fld:'vCALLBACKURL',pic:''},{av:'AV14ConsumerSecret',fld:'vCONSUMERSECRET',pic:''},{av:'AV13ConsumerKey',fld:'vCONSUMERKEY',pic:''},{av:'AV8AdditionalScope',fld:'vADDITIONALSCOPE',pic:''},{av:'AV30SiteURL',fld:'vSITEURL',pic:''},{av:'AV55VersionPath',fld:'vVERSIONPATH',pic:''},{av:'AV12ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'AV11ClientId',fld:'vCLIENTID',pic:''},{av:'cmbavImpersonate'},{av:'AV26Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV9BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'AV31SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV20Dsc',fld:'vDSC',pic:''},{av:'AV27IsEnable',fld:'vISENABLE',pic:''},{av:'AV29Name',fld:'vNAME',pic:''},{av:'AV53TypeId',fld:'vTYPEID',pic:''}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E113T1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("VTFAENABLE.CLICK","{handler:'E173T2',iparms:[{av:'AV60TFAEnable',fld:'vTFAENABLE',pic:''},{av:'AV62TFAFirstFactorAuthenticationExpiration',fld:'vTFAFIRSTFACTORAUTHENTICATIONEXPIRATION',pic:'ZZZZZZZZZZZZZZ9'},{av:'cmbavTfaauthenticationtypename'},{av:'AV61TFAAuthenticationTypeName',fld:'vTFAAUTHENTICATIONTYPENAME',pic:''}]");
         setEventMetadata("VTFAENABLE.CLICK",",oparms:[{av:'AV62TFAFirstFactorAuthenticationExpiration',fld:'vTFAFIRSTFACTORAUTHENTICATIONEXPIRATION',pic:'ZZZZZZZZZZZZZZ9'},{av:'cmbavTfaauthenticationtypename'},{av:'AV61TFAAuthenticationTypeName',fld:'vTFAAUTHENTICATIONTYPENAME',pic:''},{av:'Tbltwofactorauthentication_Visible',ctrl:'TBLTWOFACTORAUTHENTICATION',prop:'Visible'}]}");
         setEventMetadata("VOTPGENERATIONTYPE.CLICK","{handler:'E183T2',iparms:[{av:'cmbavOtpgenerationtype'},{av:'AV66OTPGenerationType',fld:'vOTPGENERATIONTYPE',pic:''},{av:'cmbavOtpgenerationtype_customeventgeneratecode'},{av:'AV67OTPGenerationType_CustomEventGenerateCode',fld:'vOTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE',pic:''}]");
         setEventMetadata("VOTPGENERATIONTYPE.CLICK",",oparms:[{av:'divTblotpcustom_Visible',ctrl:'TBLOTPCUSTOM',prop:'Visible'},{av:'divTbltypeotpgeneratecode_Visible',ctrl:'TBLTYPEOTPGENERATECODE',prop:'Visible'},{av:'cmbavOtpgenerationtype_customeventgeneratecode'},{av:'AV67OTPGenerationType_CustomEventGenerateCode',fld:'vOTPGENERATIONTYPE_CUSTOMEVENTGENERATECODE',pic:''}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[]}");
         setEventMetadata("VALIDV_OTPGENERATIONTYPE","{handler:'Validv_Otpgenerationtype',iparms:[]");
         setEventMetadata("VALIDV_OTPGENERATIONTYPE",",oparms:[]}");
         setEventMetadata("VALIDV_WSVERSION","{handler:'Validv_Wsversion',iparms:[]");
         setEventMetadata("VALIDV_WSVERSION",",oparms:[]}");
         setEventMetadata("VALIDV_CUSVERSION","{handler:'Validv_Cusversion',iparms:[]");
         setEventMetadata("VALIDV_CUSVERSION",",oparms:[]}");
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
         wcpOAV29Name = "";
         wcpOAV53TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucTbldata = new GXUserControl();
         TempTags = "";
         AV21FunctionId = "";
         AV20Dsc = "";
         AV31SmallImageName = "";
         AV9BigImageName = "";
         ucTblimpersonate = new GXUserControl();
         AV26Impersonate = "";
         ucTblenabletwofactorauth = new GXUserControl();
         ucTbltwofactorauthentication = new GXUserControl();
         AV61TFAAuthenticationTypeName = "";
         ucTblotpauthentication = new GXUserControl();
         AV65OTPEventValidateUser = "";
         AV66OTPGenerationType = "";
         AV67OTPGenerationType_CustomEventGenerateCode = "";
         AV75OTPEventSendCode = "";
         AV76OTPMailMessageSubject = "";
         AV77OTPMailMessageBodyHTML = "";
         AV78OTPEventValidateCode = "";
         ucTblclientidsecret = new GXUserControl();
         AV11ClientId = "";
         AV12ClientSecret = "";
         AV55VersionPath = "";
         ucTblclientlocalserver = new GXUserControl();
         AV30SiteURL = "";
         ucTblcustomcallbackurl = new GXUserControl();
         ucTbltwitter = new GXUserControl();
         AV13ConsumerKey = "";
         AV14ConsumerSecret = "";
         AV10CallbackURL = "";
         ucTblscopes = new GXUserControl();
         ucTblcommonadditional = new GXUserControl();
         AV8AdditionalScope = "";
         ucTblauthtypename = new GXUserControl();
         AV58GAMRAuthenticationTypeName = "";
         ucTblserverhost = new GXUserControl();
         AV24GAMRServerURL = "";
         AV22GAMRPrivateEncryptKey = "";
         AV23GAMRRepositoryGUID = "";
         ucTblwebservice = new GXUserControl();
         AV44WSVersion = "";
         lblTextblock_var_wsprivateencryptkey_Jsonclick = "";
         AV38WSPrivateEncryptKey = "";
         bttBtngenkey_Jsonclick = "";
         AV40WSServerName = "";
         AV39WSServerBaseURL = "";
         AV37WSPackage = "";
         AV36WSName = "";
         AV35WSExtension = "";
         ucTblexternal = new GXUserControl();
         AV19CusVersion = "";
         lblTextblock_var_cusprivateencryptkey_Jsonclick = "";
         AV18CusPrivateEncryptKey = "";
         bttBtngenkeycustom_Jsonclick = "";
         AV16CusFileName = "";
         AV17CusPackage = "";
         AV15CusClassName = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV80AuthenticationTypeWeChat = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWeChat(context);
         AV5AuthenticationTypeTwitter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter(context);
         AV81AuthenticationTypeOTP = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOTP(context);
         AV47AuthenticationTypeGoogle = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle(context);
         AV54AuthenticationTypeGAMRemoteRest = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemoteRest(context);
         AV46AuthenticationTypeGAMRemote = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote(context);
         AV84AuthenticationTypeFacebook = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook(context);
         AV50AuthenticationTypeWebService = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService(context);
         AV45AuthenticationTypeCustom = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom(context);
         AV82AuthenticationTypeApple = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeApple(context);
         AV48AuthenticationTypeLocal = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal(context);
         AV49AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         AV52Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV51Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV86GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV87GAMEventSubscriptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter(context);
         AV90GXV2 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV83AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV92GXV4 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV94GXV6 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         AV85EventSuscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
         AV96GXV8 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         AV98GXV10 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         AV100GXV12 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV29Name = "";
         sCtrlAV53TypeId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentrygeneral__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV68OTPAutogeneratedCodeLength ;
      private short AV71OTPMaximumDailyNumberCodes ;
      private short AV72OTPNumberUnsuccessfulRetriesToLockOTP ;
      private short AV74OTPNumberUnsuccessfulRetriesToBlockUserBasedOfOTPLocks ;
      private short AV41WSServerPort ;
      private short AV42WSServerSecureProtocol ;
      private short AV43WSTimeout ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavTfafirstfactorauthenticationexpiration_Enabled ;
      private int divTblotpconfiguration_Visible ;
      private int divTblotpcustom_Visible ;
      private int divTbltypeotpgeneratecode_Visible ;
      private int edtavOtpautogeneratedcodelength_Enabled ;
      private int AV70OTPCodeExpirationTimeout ;
      private int edtavOtpcodeexpirationtimeout_Enabled ;
      private int edtavOtpmaximumdailynumbercodes_Enabled ;
      private int edtavOtpnumberunsuccessfulretriestolockotp_Enabled ;
      private int edtavOtpautounlocktime_Enabled ;
      private int edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Enabled ;
      private int edtavOtpmailmessagesubject_Enabled ;
      private int edtavOtpmailmessagebodyhtml_Enabled ;
      private int edtavClientid_Enabled ;
      private int edtavClientsecret_Enabled ;
      private int edtavVersionpath_Visible ;
      private int edtavVersionpath_Enabled ;
      private int edtavSiteurl_Visible ;
      private int edtavSiteurl_Enabled ;
      private int edtavConsumerkey_Enabled ;
      private int edtavConsumersecret_Enabled ;
      private int edtavCallbackurl_Enabled ;
      private int edtavAdditionalscope_Enabled ;
      private int edtavGamrauthenticationtypename_Enabled ;
      private int edtavGamrserverurl_Enabled ;
      private int edtavGamrprivateencryptkey_Enabled ;
      private int edtavGamrrepositoryguid_Enabled ;
      private int edtavWsprivateencryptkey_Enabled ;
      private int bttBtngenkey_Visible ;
      private int edtavWsservername_Enabled ;
      private int edtavWsserverport_Enabled ;
      private int edtavWsserverbaseurl_Enabled ;
      private int edtavWstimeout_Enabled ;
      private int edtavWspackage_Enabled ;
      private int edtavWsname_Enabled ;
      private int edtavWsextension_Enabled ;
      private int edtavCusprivateencryptkey_Enabled ;
      private int bttBtngenkeycustom_Visible ;
      private int edtavCusfilename_Enabled ;
      private int edtavCuspackage_Enabled ;
      private int edtavCusclassname_Enabled ;
      private int bttConfirm_Visible ;
      private int AV89GXV1 ;
      private int AV91GXV3 ;
      private int AV93GXV5 ;
      private int AV95GXV7 ;
      private int AV97GXV9 ;
      private int AV99GXV11 ;
      private int AV101GXV13 ;
      private int idxLst ;
      private long AV62TFAFirstFactorAuthenticationExpiration ;
      private long AV73OTPAutoUnlockTime ;
      private string Gx_mode ;
      private string AV29Name ;
      private string AV53TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV29Name ;
      private string wcpOAV53TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tbldata_Title ;
      private string Tblimpersonate_Title ;
      private string Tblenabletwofactorauth_Title ;
      private string Tbltwofactorauthentication_Title ;
      private string Tblotpauthentication_Title ;
      private string Tblclientidsecret_Title ;
      private string Tblclientlocalserver_Title ;
      private string Tblcustomcallbackurl_Title ;
      private string Tbltwitter_Title ;
      private string Tblscopes_Title ;
      private string Tblcommonadditional_Title ;
      private string Tblauthtypename_Title ;
      private string Tblserverhost_Title ;
      private string Tblwebservice_Title ;
      private string Tblexternal_Title ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divContenttable_Class ;
      private string Tbldata_Internalname ;
      private string divTbldata_content_Internalname ;
      private string divAttributescontainertable_tbldata_Internalname ;
      private string divAttributescontainertable_tbldata_Class ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divTable_container_functionid_Internalname ;
      private string cmbavFunctionid_Internalname ;
      private string AV21FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string divTable_container_isenable_Internalname ;
      private string chkavIsenable_Internalname ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV20Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_smallimagename_Internalname ;
      private string edtavSmallimagename_Internalname ;
      private string AV31SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string divTable_container_bigimagename_Internalname ;
      private string edtavBigimagename_Internalname ;
      private string AV9BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string Tblimpersonate_Internalname ;
      private string divTblimpersonate_content_Internalname ;
      private string divAttributescontainertable_tblimpersonate_Internalname ;
      private string divAttributescontainertable_tblimpersonate_Class ;
      private string divTable_container_impersonate_Internalname ;
      private string cmbavImpersonate_Internalname ;
      private string AV26Impersonate ;
      private string cmbavImpersonate_Jsonclick ;
      private string Tblenabletwofactorauth_Internalname ;
      private string divTblenabletwofactorauth_content_Internalname ;
      private string divAttributescontainertable_tblenabletwofactorauth_Internalname ;
      private string divTable_container_tfaenable_Internalname ;
      private string chkavTfaenable_Internalname ;
      private string Tbltwofactorauthentication_Internalname ;
      private string divTbltwofactorauthentication_content_Internalname ;
      private string divAttributescontainertable_tbltwofactorauthentication_Internalname ;
      private string divTable_container_tfaauthenticationtypename_Internalname ;
      private string cmbavTfaauthenticationtypename_Internalname ;
      private string AV61TFAAuthenticationTypeName ;
      private string cmbavTfaauthenticationtypename_Jsonclick ;
      private string divTable_container_tfafirstfactorauthenticationexpiration_Internalname ;
      private string edtavTfafirstfactorauthenticationexpiration_Internalname ;
      private string edtavTfafirstfactorauthenticationexpiration_Jsonclick ;
      private string divTable_container_tfaforceforallusers_Internalname ;
      private string chkavTfaforceforallusers_Internalname ;
      private string Tblotpauthentication_Internalname ;
      private string divTblotpauthentication_content_Internalname ;
      private string divAttributescontainertable_tblotpauthentication_Internalname ;
      private string divTable_container_otpuseforfirstfactorauthentication_Internalname ;
      private string chkavOtpuseforfirstfactorauthentication_Internalname ;
      private string divTblotpconfiguration_Internalname ;
      private string divColumn_Internalname ;
      private string divTable_container_otpeventvalidateuser_Internalname ;
      private string cmbavOtpeventvalidateuser_Internalname ;
      private string AV65OTPEventValidateUser ;
      private string cmbavOtpeventvalidateuser_Jsonclick ;
      private string divTable_container_otpgenerationtype_Internalname ;
      private string cmbavOtpgenerationtype_Internalname ;
      private string cmbavOtpgenerationtype_Jsonclick ;
      private string divTblotpcustom_Internalname ;
      private string divColumn1_Internalname ;
      private string divTable_container_otpgenerationtype_customeventgeneratecode_Internalname ;
      private string cmbavOtpgenerationtype_customeventgeneratecode_Internalname ;
      private string AV67OTPGenerationType_CustomEventGenerateCode ;
      private string cmbavOtpgenerationtype_customeventgeneratecode_Jsonclick ;
      private string divTbltypeotpgeneratecode_Internalname ;
      private string divColumn3_Internalname ;
      private string divTable_container_otpautogeneratedcodelength_Internalname ;
      private string edtavOtpautogeneratedcodelength_Internalname ;
      private string edtavOtpautogeneratedcodelength_Jsonclick ;
      private string divTable_container_otpgeneratecodeonlynumbers_Internalname ;
      private string chkavOtpgeneratecodeonlynumbers_Internalname ;
      private string divTable_container_otpcodeexpirationtimeout_Internalname ;
      private string edtavOtpcodeexpirationtimeout_Internalname ;
      private string edtavOtpcodeexpirationtimeout_Jsonclick ;
      private string divTable_container_otpmaximumdailynumbercodes_Internalname ;
      private string edtavOtpmaximumdailynumbercodes_Internalname ;
      private string edtavOtpmaximumdailynumbercodes_Jsonclick ;
      private string divTable_container_otpnumberunsuccessfulretriestolockotp_Internalname ;
      private string edtavOtpnumberunsuccessfulretriestolockotp_Internalname ;
      private string edtavOtpnumberunsuccessfulretriestolockotp_Jsonclick ;
      private string divTable_container_otpautounlocktime_Internalname ;
      private string edtavOtpautounlocktime_Internalname ;
      private string edtavOtpautounlocktime_Jsonclick ;
      private string divTable_container_otpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname ;
      private string edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Internalname ;
      private string edtavOtpnumberunsuccessfulretriestoblockuserbasedofotplocks_Jsonclick ;
      private string divTable_container_otpeventsendcode_Internalname ;
      private string cmbavOtpeventsendcode_Internalname ;
      private string AV75OTPEventSendCode ;
      private string cmbavOtpeventsendcode_Jsonclick ;
      private string divTblsendemailbygam_Internalname ;
      private string divColumn4_Internalname ;
      private string divTable_container_otpmailmessagesubject_Internalname ;
      private string edtavOtpmailmessagesubject_Internalname ;
      private string AV76OTPMailMessageSubject ;
      private string edtavOtpmailmessagesubject_Jsonclick ;
      private string divTable_container_otpmailmessagebodyhtml_Internalname ;
      private string edtavOtpmailmessagebodyhtml_Internalname ;
      private string divTable_container_otpeventvalidatecode_Internalname ;
      private string cmbavOtpeventvalidatecode_Internalname ;
      private string AV78OTPEventValidateCode ;
      private string cmbavOtpeventvalidatecode_Jsonclick ;
      private string Tblclientidsecret_Internalname ;
      private string divTblclientidsecret_content_Internalname ;
      private string divAttributescontainertable_tblclientidsecret_Internalname ;
      private string divAttributescontainertable_tblclientidsecret_Class ;
      private string divTable_container_clientid_Internalname ;
      private string edtavClientid_Internalname ;
      private string edtavClientid_Jsonclick ;
      private string divTable_container_clientsecret_Internalname ;
      private string edtavClientsecret_Internalname ;
      private string edtavClientsecret_Jsonclick ;
      private string divTable_container_versionpath_Internalname ;
      private string edtavVersionpath_Internalname ;
      private string AV55VersionPath ;
      private string edtavVersionpath_Jsonclick ;
      private string Tblclientlocalserver_Internalname ;
      private string divTblclientlocalserver_content_Internalname ;
      private string divAttributescontainertable_tblclientlocalserver_Internalname ;
      private string divAttributescontainertable_tblclientlocalserver_Class ;
      private string divTable_container_siteurl_Internalname ;
      private string edtavSiteurl_Internalname ;
      private string edtavSiteurl_Jsonclick ;
      private string Tblcustomcallbackurl_Internalname ;
      private string divTblcustomcallbackurl_content_Internalname ;
      private string divAttributescontainertable_tblcustomcallbackurl_Internalname ;
      private string divTable_container_siteurlcallbackiscustom_Internalname ;
      private string chkavSiteurlcallbackiscustom_Internalname ;
      private string Tbltwitter_Internalname ;
      private string divTbltwitter_content_Internalname ;
      private string divAttributescontainertable_tbltwitter_Internalname ;
      private string divAttributescontainertable_tbltwitter_Class ;
      private string divTable_container_consumerkey_Internalname ;
      private string edtavConsumerkey_Internalname ;
      private string AV13ConsumerKey ;
      private string edtavConsumerkey_Jsonclick ;
      private string divTable_container_consumersecret_Internalname ;
      private string edtavConsumersecret_Internalname ;
      private string AV14ConsumerSecret ;
      private string edtavConsumersecret_Jsonclick ;
      private string divTable_container_callbackurl_Internalname ;
      private string edtavCallbackurl_Internalname ;
      private string edtavCallbackurl_Jsonclick ;
      private string Tblscopes_Internalname ;
      private string divTblscopes_content_Internalname ;
      private string divAttributescontainertable_tblscopes_Internalname ;
      private string divAttributescontainertable_tblscopes_Class ;
      private string divTable_container_adduseradditionaldatascope_Internalname ;
      private string chkavAdduseradditionaldatascope_Internalname ;
      private string divTable_container_addinitialpropertiesscope_Internalname ;
      private string chkavAddinitialpropertiesscope_Internalname ;
      private string Tblcommonadditional_Internalname ;
      private string divTblcommonadditional_content_Internalname ;
      private string divAttributescontainertable_tblcommonadditional_Internalname ;
      private string divAttributescontainertable_tblcommonadditional_Class ;
      private string divTable_container_additionalscope_Internalname ;
      private string edtavAdditionalscope_Internalname ;
      private string edtavAdditionalscope_Jsonclick ;
      private string Tblauthtypename_Internalname ;
      private string divTblauthtypename_content_Internalname ;
      private string divAttributescontainertable_tblauthtypename_Internalname ;
      private string divAttributescontainertable_tblauthtypename_Class ;
      private string divTable_container_gamrauthenticationtypename_Internalname ;
      private string edtavGamrauthenticationtypename_Internalname ;
      private string AV58GAMRAuthenticationTypeName ;
      private string edtavGamrauthenticationtypename_Jsonclick ;
      private string Tblserverhost_Internalname ;
      private string divTblserverhost_content_Internalname ;
      private string divAttributescontainertable_tblserverhost_Internalname ;
      private string divAttributescontainertable_tblserverhost_Class ;
      private string divTable_container_gamrserverurl_Internalname ;
      private string edtavGamrserverurl_Internalname ;
      private string edtavGamrserverurl_Jsonclick ;
      private string divTable_container_gamrprivateencryptkey_Internalname ;
      private string edtavGamrprivateencryptkey_Internalname ;
      private string AV22GAMRPrivateEncryptKey ;
      private string edtavGamrprivateencryptkey_Jsonclick ;
      private string divTable_container_gamrrepositoryguid_Internalname ;
      private string edtavGamrrepositoryguid_Internalname ;
      private string AV23GAMRRepositoryGUID ;
      private string edtavGamrrepositoryguid_Jsonclick ;
      private string divTable_container_autovalidateexternaltokenandrefresh_Internalname ;
      private string chkavAutovalidateexternaltokenandrefresh_Internalname ;
      private string Tblwebservice_Internalname ;
      private string divTblwebservice_content_Internalname ;
      private string divAttributescontainertable_tblwebservice_Internalname ;
      private string divAttributescontainertable_tblwebservice_Class ;
      private string divTable_container_wsversion_Internalname ;
      private string cmbavWsversion_Internalname ;
      private string AV44WSVersion ;
      private string cmbavWsversion_Jsonclick ;
      private string divTable_container_wsprivateencryptkey_Internalname ;
      private string lblTextblock_var_wsprivateencryptkey_Internalname ;
      private string lblTextblock_var_wsprivateencryptkey_Jsonclick ;
      private string divTable_container_wsprivateencryptkeycellcontainer_Internalname ;
      private string edtavWsprivateencryptkey_Internalname ;
      private string AV38WSPrivateEncryptKey ;
      private string edtavWsprivateencryptkey_Jsonclick ;
      private string bttBtngenkey_Internalname ;
      private string bttBtngenkey_Jsonclick ;
      private string divTable_container_wsservername_Internalname ;
      private string edtavWsservername_Internalname ;
      private string AV40WSServerName ;
      private string edtavWsservername_Jsonclick ;
      private string divTable_container_wsserverport_Internalname ;
      private string edtavWsserverport_Internalname ;
      private string edtavWsserverport_Jsonclick ;
      private string divTable_container_wsserverbaseurl_Internalname ;
      private string edtavWsserverbaseurl_Internalname ;
      private string AV39WSServerBaseURL ;
      private string edtavWsserverbaseurl_Jsonclick ;
      private string divTable_container_wsserversecureprotocol_Internalname ;
      private string cmbavWsserversecureprotocol_Internalname ;
      private string cmbavWsserversecureprotocol_Jsonclick ;
      private string divTable_container_wstimeout_Internalname ;
      private string edtavWstimeout_Internalname ;
      private string edtavWstimeout_Jsonclick ;
      private string divTable_container_wspackage_Internalname ;
      private string edtavWspackage_Internalname ;
      private string AV37WSPackage ;
      private string edtavWspackage_Jsonclick ;
      private string divTable_container_wsname_Internalname ;
      private string edtavWsname_Internalname ;
      private string AV36WSName ;
      private string edtavWsname_Jsonclick ;
      private string divTable_container_wsextension_Internalname ;
      private string edtavWsextension_Internalname ;
      private string AV35WSExtension ;
      private string edtavWsextension_Jsonclick ;
      private string Tblexternal_Internalname ;
      private string divTblexternal_content_Internalname ;
      private string divAttributescontainertable_tblexternal_Internalname ;
      private string divAttributescontainertable_tblexternal_Class ;
      private string divTable_container_cusversion_Internalname ;
      private string cmbavCusversion_Internalname ;
      private string AV19CusVersion ;
      private string cmbavCusversion_Jsonclick ;
      private string divTable_container_cusprivateencryptkey_Internalname ;
      private string lblTextblock_var_cusprivateencryptkey_Internalname ;
      private string lblTextblock_var_cusprivateencryptkey_Jsonclick ;
      private string divTable_container_cusprivateencryptkeycellcontainer_Internalname ;
      private string edtavCusprivateencryptkey_Internalname ;
      private string AV18CusPrivateEncryptKey ;
      private string edtavCusprivateencryptkey_Jsonclick ;
      private string bttBtngenkeycustom_Internalname ;
      private string bttBtngenkeycustom_Jsonclick ;
      private string divTable_container_cusfilename_Internalname ;
      private string edtavCusfilename_Internalname ;
      private string AV16CusFileName ;
      private string edtavCusfilename_Jsonclick ;
      private string divTable_container_cuspackage_Internalname ;
      private string edtavCuspackage_Internalname ;
      private string AV17CusPackage ;
      private string edtavCuspackage_Jsonclick ;
      private string divTable_container_cusclassname_Internalname ;
      private string edtavCusclassname_Internalname ;
      private string AV15CusClassName ;
      private string edtavCusclassname_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Caption ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlGx_mode ;
      private string sCtrlAV29Name ;
      private string sCtrlAV53TypeId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Tbldata_Collapsible ;
      private bool Tbldata_Open ;
      private bool Tbldata_Showborders ;
      private bool Tbldata_Containseditableform ;
      private bool Tblimpersonate_Collapsible ;
      private bool Tblimpersonate_Open ;
      private bool Tblimpersonate_Showborders ;
      private bool Tblimpersonate_Containseditableform ;
      private bool Tblimpersonate_Visible ;
      private bool Tblenabletwofactorauth_Collapsible ;
      private bool Tblenabletwofactorauth_Open ;
      private bool Tblenabletwofactorauth_Showborders ;
      private bool Tblenabletwofactorauth_Containseditableform ;
      private bool Tblenabletwofactorauth_Visible ;
      private bool Tbltwofactorauthentication_Collapsible ;
      private bool Tbltwofactorauthentication_Open ;
      private bool Tbltwofactorauthentication_Showborders ;
      private bool Tbltwofactorauthentication_Containseditableform ;
      private bool Tbltwofactorauthentication_Visible ;
      private bool Tblotpauthentication_Collapsible ;
      private bool Tblotpauthentication_Open ;
      private bool Tblotpauthentication_Showborders ;
      private bool Tblotpauthentication_Containseditableform ;
      private bool Tblotpauthentication_Visible ;
      private bool Tblclientidsecret_Collapsible ;
      private bool Tblclientidsecret_Open ;
      private bool Tblclientidsecret_Showborders ;
      private bool Tblclientidsecret_Containseditableform ;
      private bool Tblclientidsecret_Visible ;
      private bool Tblclientlocalserver_Collapsible ;
      private bool Tblclientlocalserver_Open ;
      private bool Tblclientlocalserver_Showborders ;
      private bool Tblclientlocalserver_Containseditableform ;
      private bool Tblclientlocalserver_Visible ;
      private bool Tblcustomcallbackurl_Collapsible ;
      private bool Tblcustomcallbackurl_Open ;
      private bool Tblcustomcallbackurl_Showborders ;
      private bool Tblcustomcallbackurl_Containseditableform ;
      private bool Tbltwitter_Collapsible ;
      private bool Tbltwitter_Open ;
      private bool Tbltwitter_Showborders ;
      private bool Tbltwitter_Containseditableform ;
      private bool Tbltwitter_Visible ;
      private bool Tblscopes_Collapsible ;
      private bool Tblscopes_Open ;
      private bool Tblscopes_Showborders ;
      private bool Tblscopes_Containseditableform ;
      private bool Tblscopes_Visible ;
      private bool Tblcommonadditional_Collapsible ;
      private bool Tblcommonadditional_Open ;
      private bool Tblcommonadditional_Showborders ;
      private bool Tblcommonadditional_Containseditableform ;
      private bool Tblcommonadditional_Visible ;
      private bool Tblauthtypename_Collapsible ;
      private bool Tblauthtypename_Open ;
      private bool Tblauthtypename_Showborders ;
      private bool Tblauthtypename_Containseditableform ;
      private bool Tblauthtypename_Visible ;
      private bool Tblserverhost_Collapsible ;
      private bool Tblserverhost_Open ;
      private bool Tblserverhost_Showborders ;
      private bool Tblserverhost_Containseditableform ;
      private bool Tblserverhost_Visible ;
      private bool Tblwebservice_Collapsible ;
      private bool Tblwebservice_Open ;
      private bool Tblwebservice_Showborders ;
      private bool Tblwebservice_Containseditableform ;
      private bool Tblwebservice_Visible ;
      private bool Tblexternal_Collapsible ;
      private bool Tblexternal_Open ;
      private bool Tblexternal_Showborders ;
      private bool Tblexternal_Containseditableform ;
      private bool Tblexternal_Visible ;
      private bool wbLoad ;
      private bool AV27IsEnable ;
      private bool AV60TFAEnable ;
      private bool AV63TFAForceForAllUsers ;
      private bool AV64OTPUseForFirstFactorAuthentication ;
      private bool AV69OTPGenerateCodeOnlyNumbers ;
      private bool AV79SiteURLCallbackIsCustom ;
      private bool AV56AddUserAdditionalDataScope ;
      private bool AV57AddInitialPropertiesScope ;
      private bool AV59AutovalidateExternalTokenAndRefresh ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV66OTPGenerationType ;
      private string AV77OTPMailMessageBodyHTML ;
      private string AV11ClientId ;
      private string AV12ClientSecret ;
      private string AV30SiteURL ;
      private string AV10CallbackURL ;
      private string AV8AdditionalScope ;
      private string AV24GAMRServerURL ;
      private GXUserControl ucTbldata ;
      private GXUserControl ucTblimpersonate ;
      private GXUserControl ucTblenabletwofactorauth ;
      private GXUserControl ucTbltwofactorauthentication ;
      private GXUserControl ucTblotpauthentication ;
      private GXUserControl ucTblclientidsecret ;
      private GXUserControl ucTblclientlocalserver ;
      private GXUserControl ucTblcustomcallbackurl ;
      private GXUserControl ucTbltwitter ;
      private GXUserControl ucTblscopes ;
      private GXUserControl ucTblcommonadditional ;
      private GXUserControl ucTblauthtypename ;
      private GXUserControl ucTblserverhost ;
      private GXUserControl ucTblwebservice ;
      private GXUserControl ucTblexternal ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCombobox cmbavImpersonate ;
      private GXCheckbox chkavTfaenable ;
      private GXCombobox cmbavTfaauthenticationtypename ;
      private GXCheckbox chkavTfaforceforallusers ;
      private GXCheckbox chkavOtpuseforfirstfactorauthentication ;
      private GXCombobox cmbavOtpeventvalidateuser ;
      private GXCombobox cmbavOtpgenerationtype ;
      private GXCombobox cmbavOtpgenerationtype_customeventgeneratecode ;
      private GXCheckbox chkavOtpgeneratecodeonlynumbers ;
      private GXCombobox cmbavOtpeventsendcode ;
      private GXCombobox cmbavOtpeventvalidatecode ;
      private GXCheckbox chkavSiteurlcallbackiscustom ;
      private GXCheckbox chkavAdduseradditionaldatascope ;
      private GXCheckbox chkavAddinitialpropertiesscope ;
      private GXCheckbox chkavAutovalidateexternaltokenandrefresh ;
      private GXCombobox cmbavWsversion ;
      private GXCombobox cmbavWsserversecureprotocol ;
      private GXCombobox cmbavCusversion ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV52Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV90GXV2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV92GXV4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV94GXV6 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV96GXV8 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV98GXV10 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV100GXV12 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter AV5AuthenticationTypeTwitter ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV51Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom AV45AuthenticationTypeCustom ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote AV46AuthenticationTypeGAMRemote ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle AV47AuthenticationTypeGoogle ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal AV48AuthenticationTypeLocal ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20 AV49AuthenticationTypeOauth20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService AV50AuthenticationTypeWebService ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemoteRest AV54AuthenticationTypeGAMRemoteRest ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWeChat AV80AuthenticationTypeWeChat ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOTP AV81AuthenticationTypeOTP ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeApple AV82AuthenticationTypeApple ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV83AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook AV84AuthenticationTypeFacebook ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscription AV85EventSuscription ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV86GAMAuthenticationTypeFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter AV87GAMEventSubscriptionFilter ;
   }

   public class wcauthenticationtypeentrygeneral__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wcauthenticationtypeentrygeneral__default : DataStoreHelperBase, IDataStoreHelper
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
