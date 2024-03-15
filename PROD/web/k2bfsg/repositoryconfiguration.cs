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
   public class repositoryconfiguration : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public repositoryconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public repositoryconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_Id )
      {
         this.AV27Id = aP0_Id;
         executePrivate();
         aP0_Id=this.AV27Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDefaultauthtypename = new GXCombobox();
         cmbavDefaultroleid = new GXCombobox();
         cmbavDefaultsecuritypolicyid = new GXCombobox();
         chkavAllowoauthaccess = new GXCheckbox();
         cmbavLogoutbehavior = new GXCombobox();
         chkavEnableworkingasgammanagerrepo = new GXCheckbox();
         cmbavEnabletracing = new GXCombobox();
         cmbavUseridentification = new GXCombobox();
         chkavUseremailisunique = new GXCheckbox();
         cmbavUseractivationmethod = new GXCombobox();
         cmbavUserremembermetype = new GXCombobox();
         chkavRequiredemail = new GXCheckbox();
         chkavRequiredpassword = new GXCheckbox();
         chkavRequiredfirstname = new GXCheckbox();
         chkavRequiredlastname = new GXCheckbox();
         chkavRequiredbirthday = new GXCheckbox();
         chkavRequiredgender = new GXCheckbox();
         cmbavGeneratesessionstatistics = new GXCombobox();
         chkavGiveanonymoussession = new GXCheckbox();
         chkavSessionexpiresonipchange = new GXCheckbox();
         chkavEmailserversecure = new GXCheckbox();
         chkavEmailserverusesauthentication = new GXCheckbox();
         chkavEmailserver_sendemailwhenuseractivateaccount = new GXCheckbox();
         chkavEmailserver_sendemailwhenuserchangepassword = new GXCheckbox();
         chkavEmailserver_sendemailwhenuserchangeemail = new GXCheckbox();
         chkavEmailserver_sendemailforrecoverypassword = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Id");
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
               gxfirstwebparm = GetFirstPar( "Id");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Id");
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
               AV27Id = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"), context));
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
         PA3B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3B2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV27Id,12,0))}, new string[] {"Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV14Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vREPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87RepoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87RepoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECURITYADMINISTRATOREMAIL", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCANREGISTERUSERS", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV14Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vREPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87RepoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87RepoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECURITYADMINISTRATOREMAIL", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCANREGISTERUSERS", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Title", StringUtil.RTrim( Tblmasterrepo_Title));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Collapsible", StringUtil.BoolToStr( Tblmasterrepo_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Open", StringUtil.BoolToStr( Tblmasterrepo_Open));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Showborders", StringUtil.BoolToStr( Tblmasterrepo_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Containseditableform", StringUtil.BoolToStr( Tblmasterrepo_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLMASTERREPO_Visible", StringUtil.BoolToStr( Tblmasterrepo_Visible));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Title", StringUtil.RTrim( Tbldonthavemasterrepo_Title));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Collapsible", StringUtil.BoolToStr( Tbldonthavemasterrepo_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Open", StringUtil.BoolToStr( Tbldonthavemasterrepo_Open));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Showborders", StringUtil.BoolToStr( Tbldonthavemasterrepo_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Containseditableform", StringUtil.BoolToStr( Tbldonthavemasterrepo_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLDONTHAVEMASTERREPO_Visible", StringUtil.BoolToStr( Tbldonthavemasterrepo_Visible));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Title", StringUtil.RTrim( Tblenableworkinasmanager_Title));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Collapsible", StringUtil.BoolToStr( Tblenableworkinasmanager_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Open", StringUtil.BoolToStr( Tblenableworkinasmanager_Open));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Showborders", StringUtil.BoolToStr( Tblenableworkinasmanager_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Containseditableform", StringUtil.BoolToStr( Tblenableworkinasmanager_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLENABLEWORKINASMANAGER_Visible", StringUtil.BoolToStr( Tblenableworkinasmanager_Visible));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Title", StringUtil.RTrim( Tblemailserveruseauthentication_Title));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Collapsible", StringUtil.BoolToStr( Tblemailserveruseauthentication_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Open", StringUtil.BoolToStr( Tblemailserveruseauthentication_Open));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Showborders", StringUtil.BoolToStr( Tblemailserveruseauthentication_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Containseditableform", StringUtil.BoolToStr( Tblemailserveruseauthentication_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLEMAILSERVERUSEAUTHENTICATION_Visible", StringUtil.BoolToStr( Tblemailserveruseauthentication_Visible));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Title", StringUtil.RTrim( Tbluseractivateaccount_Title));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Collapsible", StringUtil.BoolToStr( Tbluseractivateaccount_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Open", StringUtil.BoolToStr( Tbluseractivateaccount_Open));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Showborders", StringUtil.BoolToStr( Tbluseractivateaccount_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Containseditableform", StringUtil.BoolToStr( Tbluseractivateaccount_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLUSERACTIVATEACCOUNT_Visible", StringUtil.BoolToStr( Tbluseractivateaccount_Visible));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Title", StringUtil.RTrim( Tbluserchangepassword_Title));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Collapsible", StringUtil.BoolToStr( Tbluserchangepassword_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Open", StringUtil.BoolToStr( Tbluserchangepassword_Open));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Showborders", StringUtil.BoolToStr( Tbluserchangepassword_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Containseditableform", StringUtil.BoolToStr( Tbluserchangepassword_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEPASSWORD_Visible", StringUtil.BoolToStr( Tbluserchangepassword_Visible));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Title", StringUtil.RTrim( Tbluserchangeemail_Title));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Collapsible", StringUtil.BoolToStr( Tbluserchangeemail_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Open", StringUtil.BoolToStr( Tbluserchangeemail_Open));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Showborders", StringUtil.BoolToStr( Tbluserchangeemail_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Containseditableform", StringUtil.BoolToStr( Tbluserchangeemail_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLUSERCHANGEEMAIL_Visible", StringUtil.BoolToStr( Tbluserchangeemail_Visible));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Title", StringUtil.RTrim( Tbluserrecoverypassword_Title));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Collapsible", StringUtil.BoolToStr( Tbluserrecoverypassword_Collapsible));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Open", StringUtil.BoolToStr( Tbluserrecoverypassword_Open));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Showborders", StringUtil.BoolToStr( Tbluserrecoverypassword_Showborders));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Containseditableform", StringUtil.BoolToStr( Tbluserrecoverypassword_Containseditableform));
         GxWebStd.gx_hidden_field( context, "TBLUSERRECOVERYPASSWORD_Visible", StringUtil.BoolToStr( Tbluserrecoverypassword_Visible));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Title", StringUtil.RTrim( Attributes_Title));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Open", StringUtil.BoolToStr( Attributes_Open));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Showborders", StringUtil.BoolToStr( Attributes_Showborders));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Attributes_Containseditableform));
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
            WE3B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3B2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV27Id,12,0))}, new string[] {"Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RepositoryConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return "Repository configuration" ;
      }

      protected void WB3B0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Repository configuration", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            /* User Defined Control */
            ucAttributes.SetProperty("Title", Attributes_Title);
            ucAttributes.SetProperty("Collapsible", Attributes_Collapsible);
            ucAttributes.SetProperty("Open", Attributes_Open);
            ucAttributes.SetProperty("ShowBorders", Attributes_Showborders);
            ucAttributes.SetProperty("ContainsEditableForm", Attributes_Containseditableform);
            ucAttributes.Render(context, "k2bt_component", Attributes_Internalname, "ATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"ATTRIBUTESContainer"+"Attributes_Content"+"\" style=\"display:none;\">") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab_title_Internalname, "General", "", "", lblTab_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_id_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, "ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Id), 12, 0, ".", "")), StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV28GUID), StringUtil.RTrim( context.localUtil.Format( AV28GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGuid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_namespace_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavNamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNamespace_Internalname, "Namespace", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNamespace_Internalname, StringUtil.RTrim( AV29NameSpace), StringUtil.RTrim( context.localUtil.Format( AV29NameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNamespace_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavNamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV30Name), StringUtil.RTrim( context.localUtil.Format( AV30Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV31Dsc), StringUtil.RTrim( context.localUtil.Format( AV31Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            ucTblmasterrepo.SetProperty("Title", Tblmasterrepo_Title);
            ucTblmasterrepo.SetProperty("Collapsible", Tblmasterrepo_Collapsible);
            ucTblmasterrepo.SetProperty("Open", Tblmasterrepo_Open);
            ucTblmasterrepo.SetProperty("ShowBorders", Tblmasterrepo_Showborders);
            ucTblmasterrepo.SetProperty("ContainsEditableForm", Tblmasterrepo_Containseditableform);
            ucTblmasterrepo.Render(context, "k2bt_component", Tblmasterrepo_Internalname, "TBLMASTERREPOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLMASTERREPOContainer"+"Tblmasterrepo_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblmasterrepo_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblmasterrepo_Internalname, 1, 0, "px", 0, "px", divAttributescontainertable_tblmasterrepo_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authenticationmasterrepository_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthenticationmasterrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthenticationmasterrepository_Internalname, "Authentication master repository", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthenticationmasterrepository_Internalname, StringUtil.RTrim( AV56AuthenticationMasterRepository), StringUtil.RTrim( context.localUtil.Format( AV56AuthenticationMasterRepository, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthenticationmasterrepository_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthenticationmasterrepository_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            ucTbldonthavemasterrepo.SetProperty("Title", Tbldonthavemasterrepo_Title);
            ucTbldonthavemasterrepo.SetProperty("Collapsible", Tbldonthavemasterrepo_Collapsible);
            ucTbldonthavemasterrepo.SetProperty("Open", Tbldonthavemasterrepo_Open);
            ucTbldonthavemasterrepo.SetProperty("ShowBorders", Tbldonthavemasterrepo_Showborders);
            ucTbldonthavemasterrepo.SetProperty("ContainsEditableForm", Tbldonthavemasterrepo_Containseditableform);
            ucTbldonthavemasterrepo.Render(context, "k2bt_component", Tbldonthavemasterrepo_Internalname, "TBLDONTHAVEMASTERREPOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLDONTHAVEMASTERREPOContainer"+"Tbldonthavemasterrepo_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbldonthavemasterrepo_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbldonthavemasterrepo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_defaultauthtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavDefaultauthtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavDefaultauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultauthtypename_Internalname, "Default authentication type", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultauthtypename, cmbavDefaultauthtypename_Internalname, StringUtil.RTrim( AV32DefaultAuthTypeName), 1, cmbavDefaultauthtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavDefaultauthtypename.Visible, cmbavDefaultauthtypename.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
            AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", (string)(cmbavDefaultauthtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_defaultroleid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavDefaultroleid.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavDefaultroleid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultroleid_Internalname, "Repository default role", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultroleid, cmbavDefaultroleid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0)), 1, cmbavDefaultroleid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDefaultroleid.Visible, cmbavDefaultroleid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
            AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", (string)(cmbavDefaultroleid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_defaultsecuritypolicyid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavDefaultsecuritypolicyid.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavDefaultsecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultsecuritypolicyid_Internalname, "Repository default security policy", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultsecuritypolicyid, cmbavDefaultsecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0)), 1, cmbavDefaultsecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDefaultsecuritypolicyid.Visible, cmbavDefaultsecuritypolicyid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", (string)(cmbavDefaultsecuritypolicyid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_allowoauthaccess_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAllowoauthaccess_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAllowoauthaccess_Internalname, "Allow Oauth Access", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAllowoauthaccess_Internalname, StringUtil.BoolToStr( AV34AllowOauthAccess), "", "Allow Oauth Access", 1, chkavAllowoauthaccess.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(101, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,101);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_logoutbehavior_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavLogoutbehavior_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogoutbehavior_Internalname, "Remote logout behaviour", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogoutbehavior, cmbavLogoutbehavior_Internalname, StringUtil.RTrim( AV85LogoutBehavior), 1, cmbavLogoutbehavior_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavLogoutbehavior.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavLogoutbehavior.CurrentValue = StringUtil.RTrim( AV85LogoutBehavior);
            AssignProp("", false, cmbavLogoutbehavior_Internalname, "Values", (string)(cmbavLogoutbehavior.ToJavascriptSource()), true);
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
            ucTblenableworkinasmanager.SetProperty("Title", Tblenableworkinasmanager_Title);
            ucTblenableworkinasmanager.SetProperty("Collapsible", Tblenableworkinasmanager_Collapsible);
            ucTblenableworkinasmanager.SetProperty("Open", Tblenableworkinasmanager_Open);
            ucTblenableworkinasmanager.SetProperty("ShowBorders", Tblenableworkinasmanager_Showborders);
            ucTblenableworkinasmanager.SetProperty("ContainsEditableForm", Tblenableworkinasmanager_Containseditableform);
            ucTblenableworkinasmanager.Render(context, "k2bt_component", Tblenableworkinasmanager_Internalname, "TBLENABLEWORKINASMANAGERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLENABLEWORKINASMANAGERContainer"+"Tblenableworkinasmanager_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblenableworkinasmanager_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblenableworkinasmanager_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_enableworkingasgammanagerrepo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEnableworkingasgammanagerrepo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnableworkingasgammanagerrepo_Internalname, "Enable working as GAMManager repository", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnableworkingasgammanagerrepo_Internalname, StringUtil.BoolToStr( AV57EnableWorkingAsGAMManagerRepo), "", "Enable working as GAMManager repository", 1, chkavEnableworkingasgammanagerrepo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_enabletracing_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavEnabletracing_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEnabletracing_Internalname, "Enable tracing", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEnabletracing, cmbavEnabletracing_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0)), 1, cmbavEnabletracing_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEnabletracing.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", (string)(cmbavEnabletracing.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, "User information", "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_useridentification_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavUseridentification_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUseridentification_Internalname, "User identification", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUseridentification, cmbavUseridentification_Internalname, StringUtil.RTrim( AV35UserIdentification), 1, cmbavUseridentification_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUseridentification.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
            AssignProp("", false, cmbavUseridentification_Internalname, "Values", (string)(cmbavUseridentification.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_useremailisunique_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavUseremailisunique.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUseremailisunique_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUseremailisunique_Internalname, "User email is unique", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUseremailisunique_Internalname, StringUtil.BoolToStr( AV38UserEmailisUnique), "", "User email is unique", chkavUseremailisunique.Visible, chkavUseremailisunique.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(144, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,144);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_useractivationmethod_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavUseractivationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUseractivationmethod_Internalname, "User activation method", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUseractivationmethod, cmbavUseractivationmethod_Internalname, StringUtil.RTrim( AV36UserActivationMethod), 1, cmbavUseractivationmethod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUseractivationmethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
            AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", (string)(cmbavUseractivationmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userautomaticactivationtimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserautomaticactivationtimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserautomaticactivationtimeout_Internalname, "User automatic activation timeout (Hours)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserautomaticactivationtimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserautomaticactivationtimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV37UserAutomaticActivationTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV37UserAutomaticActivationTimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserautomaticactivationtimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserautomaticactivationtimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userrecoverypasswordkeytimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserrecoverypasswordkeytimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserrecoverypasswordkeytimeout_Internalname, "User recovery password key timeout (Minutes)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserrecoverypasswordkeytimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserrecoverypasswordkeytimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), "ZZZ9") : context.localUtil.Format( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,160);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserrecoverypasswordkeytimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserrecoverypasswordkeytimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_loginattemptstolockuser_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavLoginattemptstolockuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLoginattemptstolockuser_Internalname, "Login retries to lock user", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLoginattemptstolockuser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46LoginAttemptsToLockUser), 4, 0, ".", "")), StringUtil.LTrim( ((edtavLoginattemptstolockuser_Enabled!=0) ? context.localUtil.Format( (decimal)(AV46LoginAttemptsToLockUser), "ZZZ9") : context.localUtil.Format( (decimal)(AV46LoginAttemptsToLockUser), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLoginattemptstolockuser_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLoginattemptstolockuser_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamunblockusertimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamunblockusertimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamunblockusertimeout_Internalname, "GAMUnblock user timeout (Minutes)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamunblockusertimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GAMUnblockUserTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavGamunblockusertimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV47GAMUnblockUserTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV47GAMUnblockUserTimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamunblockusertimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamunblockusertimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userremembermetype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavUserremembermetype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserremembermetype_Internalname, "User remember me type", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserremembermetype, cmbavUserremembermetype_Internalname, StringUtil.RTrim( AV42UserRememberMeType), 1, cmbavUserremembermetype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUserremembermetype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
            AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", (string)(cmbavUserremembermetype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userremembermetimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserremembermetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserremembermetimeout_Internalname, "User remember me timeout (Days)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserremembermetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43UserRememberMeTimeOut), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUserremembermetimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV43UserRememberMeTimeOut), "ZZZ9") : context.localUtil.Format( (decimal)(AV43UserRememberMeTimeOut), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserremembermetimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserremembermetimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRequiredemail.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredemail_Internalname, "Require email", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredemail_Internalname, StringUtil.BoolToStr( AV39RequiredEmail), "", "Require email", chkavRequiredemail.Visible, chkavRequiredemail.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(187, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,187);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredpassword_Internalname, "Require password", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredpassword_Internalname, StringUtil.BoolToStr( AV40RequiredPassword), "", "Require password", 1, chkavRequiredpassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(192, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,192);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredfirstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredfirstname_Internalname, "Required first name", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredfirstname_Internalname, StringUtil.BoolToStr( AV53RequiredFirstName), "", "Required first name", 1, chkavRequiredfirstname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(198, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,198);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredlastname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredlastname_Internalname, "Required last name", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredlastname_Internalname, StringUtil.BoolToStr( AV54RequiredLastName), "", "Required last name", 1, chkavRequiredlastname.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(203, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,203);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredbirthday_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredbirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredbirthday_Internalname, "Required birthday?", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredbirthday_Internalname, StringUtil.BoolToStr( AV58RequiredBirthday), "", "Required birthday?", 1, chkavRequiredbirthday.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(208, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,208);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_requiredgender_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavRequiredgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRequiredgender_Internalname, "Required gender?", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRequiredgender_Internalname, StringUtil.BoolToStr( AV59RequiredGender), "", "Required gender?", 1, chkavRequiredgender.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(214, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,214);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, "Session", "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_generatesessionstatistics_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavGeneratesessionstatistics_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGeneratesessionstatistics_Internalname, "Generate session statistics", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGeneratesessionstatistics, cmbavGeneratesessionstatistics_Internalname, StringUtil.RTrim( AV41GenerateSessionStatistics), 1, cmbavGeneratesessionstatistics_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGeneratesessionstatistics.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,225);\"", "", true, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", (string)(cmbavGeneratesessionstatistics.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_usersessioncachetimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUsersessioncachetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsersessioncachetimeout_Internalname, "User session cache timeout (Seconds)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsersessioncachetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50UserSessionCacheTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavUsersessioncachetimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV50UserSessionCacheTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV50UserSessionCacheTimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsersessioncachetimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsersessioncachetimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_giveanonymoussession_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavGiveanonymoussession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavGiveanonymoussession_Internalname, "Give web anonymous sessions", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavGiveanonymoussession_Internalname, StringUtil.BoolToStr( AV49GiveAnonymousSession), "", "Give web anonymous sessions", 1, chkavGiveanonymoussession.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(236, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,236);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_sessionexpiresonipchange_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavSessionexpiresonipchange_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSessionexpiresonipchange_Internalname, "GAM Session expires on IP change", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSessionexpiresonipchange_Internalname, StringUtil.BoolToStr( AV33SessionExpiresOnIPChange), "", "GAM Session expires on IP change", 1, chkavSessionexpiresonipchange.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(241, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,241);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_loginattemptstolocksession_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavLoginattemptstolocksession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLoginattemptstolocksession_Internalname, "Login attempts to lock session", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLoginattemptstolocksession_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48LoginAttemptsToLockSession), 4, 0, ".", "")), StringUtil.LTrim( ((edtavLoginattemptstolocksession_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48LoginAttemptsToLockSession), "ZZZ9") : context.localUtil.Format( (decimal)(AV48LoginAttemptsToLockSession), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLoginattemptstolocksession_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavLoginattemptstolocksession_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_minimumamountcharactersinlogin_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumamountcharactersinlogin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumamountcharactersinlogin_Internalname, "Minimum amount of characters in login", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumamountcharactersinlogin_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0, ".", "")), StringUtil.LTrim( ((edtavMinimumamountcharactersinlogin_Enabled!=0) ? context.localUtil.Format( (decimal)(AV45MinimumAmountCharactersInLogin), "ZZZ9") : context.localUtil.Format( (decimal)(AV45MinimumAmountCharactersInLogin), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,252);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumamountcharactersinlogin_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumamountcharactersinlogin_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_repositorycachetimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavRepositorycachetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositorycachetimeout_Internalname, "Repository cache timeout (minutes)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositorycachetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60RepositoryCacheTimeout), 6, 0, ".", "")), StringUtil.LTrim( ((edtavRepositorycachetimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV60RepositoryCacheTimeout), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV60RepositoryCacheTimeout), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,258);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositorycachetimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavRepositorycachetimeout_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "K2BTools\\K2BT_MediumId", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab3_title_Internalname, "E-mail", "", "", lblTab3_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab3") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab3_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserverhost_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserverhost_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserverhost_Internalname, "Server host", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserverhost_Internalname, StringUtil.RTrim( AV61EmailServerHost), StringUtil.RTrim( context.localUtil.Format( AV61EmailServerHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,269);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserverhost_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserverhost_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserverport_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserverport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserverport_Internalname, "Server port", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserverport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62EmailServerPort), 4, 0, ".", "")), StringUtil.LTrim( ((edtavEmailserverport_Enabled!=0) ? context.localUtil.Format( (decimal)(AV62EmailServerPort), "ZZZ9") : context.localUtil.Format( (decimal)(AV62EmailServerPort), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,274);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserverport_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserverport_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailservertimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailservertimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailservertimeout_Internalname, "Timeout (seconds)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 280,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailservertimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63EmailServerTimeout), 4, 0, ".", "")), StringUtil.LTrim( ((edtavEmailservertimeout_Enabled!=0) ? context.localUtil.Format( (decimal)(AV63EmailServerTimeout), "ZZZ9") : context.localUtil.Format( (decimal)(AV63EmailServerTimeout), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,280);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailservertimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailservertimeout_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserversecure_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserversecure_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserversecure_Internalname, "Secure", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserversecure_Internalname, StringUtil.BoolToStr( AV64EmailServerSecure), "", "Secure", 1, chkavEmailserversecure.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(285, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,285);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_serversenderaddress_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavServersenderaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServersenderaddress_Internalname, "Sender email address", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 291,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServersenderaddress_Internalname, AV65ServerSenderAddress, StringUtil.RTrim( context.localUtil.Format( AV65ServerSenderAddress, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,291);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServersenderaddress_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavServersenderaddress_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_serversendername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavServersendername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServersendername_Internalname, "Sender name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 296,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServersendername_Internalname, StringUtil.RTrim( AV66ServerSenderName), StringUtil.RTrim( context.localUtil.Format( AV66ServerSenderName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,296);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServersendername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavServersendername_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailserverusesauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserverusesauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserverusesauthentication_Internalname, "Server require authentication?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserverusesauthentication_Internalname, StringUtil.BoolToStr( AV67EmailServerUsesAuthentication), "", "Server require authentication?", 1, chkavEmailserverusesauthentication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,302);\"");
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
            ucTblemailserveruseauthentication.SetProperty("Title", Tblemailserveruseauthentication_Title);
            ucTblemailserveruseauthentication.SetProperty("Collapsible", Tblemailserveruseauthentication_Collapsible);
            ucTblemailserveruseauthentication.SetProperty("Open", Tblemailserveruseauthentication_Open);
            ucTblemailserveruseauthentication.SetProperty("ShowBorders", Tblemailserveruseauthentication_Showborders);
            ucTblemailserveruseauthentication.SetProperty("ContainsEditableForm", Tblemailserveruseauthentication_Containseditableform);
            ucTblemailserveruseauthentication.Render(context, "k2bt_component", Tblemailserveruseauthentication_Internalname, "TBLEMAILSERVERUSEAUTHENTICATIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLEMAILSERVERUSEAUTHENTICATIONContainer"+"Tblemailserveruseauthentication_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblemailserveruseauthentication_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tblemailserveruseauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserverauthenticationusername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserverauthenticationusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserverauthenticationusername_Internalname, "User name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserverauthenticationusername_Internalname, StringUtil.RTrim( AV68EmailServerAuthenticationUsername), StringUtil.RTrim( context.localUtil.Format( AV68EmailServerAuthenticationUsername, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,316);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserverauthenticationusername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserverauthenticationusername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserverauthenticationuserpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserverauthenticationuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserverauthenticationuserpassword_Internalname, "Password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 321,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserverauthenticationuserpassword_Internalname, StringUtil.RTrim( AV69EmailServerAuthenticationUserPassword), StringUtil.RTrim( context.localUtil.Format( AV69EmailServerAuthenticationUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,321);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserverauthenticationuserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserverauthenticationuserpassword_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailserver_sendemailwhenuseractivateaccount_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserver_sendemailwhenuseractivateaccount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserver_sendemailwhenuseractivateaccount_Internalname, "Send email when user activate account?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 327,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserver_sendemailwhenuseractivateaccount_Internalname, StringUtil.BoolToStr( AV70EmailServer_SendEmailWhenUserActivateAccount), "", "Send email when user activate account?", 1, chkavEmailserver_sendemailwhenuseractivateaccount.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,327);\"");
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
            ucTbluseractivateaccount.SetProperty("Title", Tbluseractivateaccount_Title);
            ucTbluseractivateaccount.SetProperty("Collapsible", Tbluseractivateaccount_Collapsible);
            ucTbluseractivateaccount.SetProperty("Open", Tbluseractivateaccount_Open);
            ucTbluseractivateaccount.SetProperty("ShowBorders", Tbluseractivateaccount_Showborders);
            ucTbluseractivateaccount.SetProperty("ContainsEditableForm", Tbluseractivateaccount_Containseditableform);
            ucTbluseractivateaccount.Render(context, "k2bt_component", Tbluseractivateaccount_Internalname, "TBLUSERACTIVATEACCOUNTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLUSERACTIVATEACCOUNTContainer"+"Tbluseractivateaccount_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbluseractivateaccount_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbluseractivateaccount_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailsubjectwhenuseractivateaccount_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname, "Email subject for activating a user account", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 341,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname, StringUtil.RTrim( AV71EmailServer_EmailSubjectWhenUserActivateAccount), StringUtil.RTrim( context.localUtil.Format( AV71EmailServer_EmailSubjectWhenUserActivateAccount, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,341);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserver_emailsubjectwhenuseractivateaccount_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserver_emailsubjectwhenuseractivateaccount_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailbodywhenuseractivateaccount_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailbodywhenuseractivateaccount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailbodywhenuseractivateaccount_Internalname, "Email body for activating a user account", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 346,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavEmailserver_emailbodywhenuseractivateaccount_Internalname, AV72EmailServer_EmailBodyWhenUserActivateAccount, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,346);\"", 0, 1, edtavEmailserver_emailbodywhenuseractivateaccount_Enabled, 0, 200, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", 1, 0, "", "", 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailserver_sendemailwhenuserchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserver_sendemailwhenuserchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserver_sendemailwhenuserchangepassword_Internalname, "Send email when user change password?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 352,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserver_sendemailwhenuserchangepassword_Internalname, StringUtil.BoolToStr( AV73EmailServer_SendEmailWhenUserChangePassword), "", "Send email when user change password?", 1, chkavEmailserver_sendemailwhenuserchangepassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,352);\"");
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
            ucTbluserchangepassword.SetProperty("Title", Tbluserchangepassword_Title);
            ucTbluserchangepassword.SetProperty("Collapsible", Tbluserchangepassword_Collapsible);
            ucTbluserchangepassword.SetProperty("Open", Tbluserchangepassword_Open);
            ucTbluserchangepassword.SetProperty("ShowBorders", Tbluserchangepassword_Showborders);
            ucTbluserchangepassword.SetProperty("ContainsEditableForm", Tbluserchangepassword_Containseditableform);
            ucTbluserchangepassword.Render(context, "k2bt_component", Tbluserchangepassword_Internalname, "TBLUSERCHANGEPASSWORDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLUSERCHANGEPASSWORDContainer"+"Tbluserchangepassword_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbluserchangepassword_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbluserchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailsubjectwhenuserchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname, "Email subject for changing a user password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 366,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname, StringUtil.RTrim( AV74EmailServer_EmailSubjectWhenUserChangePassword), StringUtil.RTrim( context.localUtil.Format( AV74EmailServer_EmailSubjectWhenUserChangePassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,366);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserver_emailsubjectwhenuserchangepassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserver_emailsubjectwhenuserchangepassword_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailbodywhenuserchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailbodywhenuserchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailbodywhenuserchangepassword_Internalname, "Email body for changing a user password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 371,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavEmailserver_emailbodywhenuserchangepassword_Internalname, AV75EmailServer_EmailBodyWhenUserChangePassword, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,371);\"", 0, 1, edtavEmailserver_emailbodywhenuserchangepassword_Enabled, 0, 200, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", 1, 0, "", "", 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailserver_sendemailwhenuserchangeemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserver_sendemailwhenuserchangeemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserver_sendemailwhenuserchangeemail_Internalname, "Send email when user change email/username?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 377,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserver_sendemailwhenuserchangeemail_Internalname, StringUtil.BoolToStr( AV76EmailServer_SendEmailWhenUserChangeEmail), "", "Send email when user change email/username?", 1, chkavEmailserver_sendemailwhenuserchangeemail.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,377);\"");
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
            ucTbluserchangeemail.SetProperty("Title", Tbluserchangeemail_Title);
            ucTbluserchangeemail.SetProperty("Collapsible", Tbluserchangeemail_Collapsible);
            ucTbluserchangeemail.SetProperty("Open", Tbluserchangeemail_Open);
            ucTbluserchangeemail.SetProperty("ShowBorders", Tbluserchangeemail_Showborders);
            ucTbluserchangeemail.SetProperty("ContainsEditableForm", Tbluserchangeemail_Containseditableform);
            ucTbluserchangeemail.Render(context, "k2bt_component", Tbluserchangeemail_Internalname, "TBLUSERCHANGEEMAILContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLUSERCHANGEEMAILContainer"+"Tbluserchangeemail_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbluserchangeemail_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbluserchangeemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailsubjectwhenuserchangeemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname, "Email subject for changing a user's email/username", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 391,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname, StringUtil.RTrim( AV77EmailServer_EmailSubjectWhenUserChangeEmail), StringUtil.RTrim( context.localUtil.Format( AV77EmailServer_EmailSubjectWhenUserChangeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,391);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserver_emailsubjectwhenuserchangeemail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserver_emailsubjectwhenuserchangeemail_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailbodywhenuserchangeemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailbodywhenuserchangeemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailbodywhenuserchangeemail_Internalname, "Email body for changing a user's email/username", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 396,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavEmailserver_emailbodywhenuserchangeemail_Internalname, AV78EmailServer_EmailBodyWhenUserChangeEmail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,396);\"", 0, 1, edtavEmailserver_emailbodywhenuserchangeemail_Enabled, 0, 200, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", 1, 0, "", "", 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_emailserver_sendemailforrecoverypassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEmailserver_sendemailforrecoverypassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmailserver_sendemailforrecoverypassword_Internalname, "Send email for recovery password?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 402,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmailserver_sendemailforrecoverypassword_Internalname, StringUtil.BoolToStr( AV79EmailServer_SendEmailForRecoveryPassword), "", "Send email for recovery password?", 1, chkavEmailserver_sendemailforrecoverypassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,402);\"");
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
            ucTbluserrecoverypassword.SetProperty("Title", Tbluserrecoverypassword_Title);
            ucTbluserrecoverypassword.SetProperty("Collapsible", Tbluserrecoverypassword_Collapsible);
            ucTbluserrecoverypassword.SetProperty("Open", Tbluserrecoverypassword_Open);
            ucTbluserrecoverypassword.SetProperty("ShowBorders", Tbluserrecoverypassword_Showborders);
            ucTbluserrecoverypassword.SetProperty("ContainsEditableForm", Tbluserrecoverypassword_Containseditableform);
            ucTbluserrecoverypassword.Render(context, "k2bt_component", Tbluserrecoverypassword_Internalname, "TBLUSERRECOVERYPASSWORDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TBLUSERRECOVERYPASSWORDContainer"+"Tbluserrecoverypassword_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbluserrecoverypassword_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbluserrecoverypassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailsubjectforrecoverypassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailsubjectforrecoverypassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailsubjectforrecoverypassword_Internalname, "Email subject for recovery password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 416,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailserver_emailsubjectforrecoverypassword_Internalname, StringUtil.RTrim( AV80EmailServer_EmailSubjectForRecoveryPassword), StringUtil.RTrim( context.localUtil.Format( AV80EmailServer_EmailSubjectForRecoveryPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,416);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailserver_emailsubjectforrecoverypassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEmailserver_emailsubjectforrecoverypassword_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_emailserver_emailbodyforrecoverypassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailserver_emailbodyforrecoverypassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailserver_emailbodyforrecoverypassword_Internalname, "Email body for recovery password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 421,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavEmailserver_emailbodyforrecoverypassword_Internalname, AV81EmailServer_EmailBodyForRecoveryPassword, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,421);\"", 0, 1, edtavEmailserver_emailbodyforrecoverypassword_Enabled, 0, 200, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2048", 1, 0, "", "", 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 429,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", "Confirm", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 431,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancel", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e113b1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\RepositoryConfiguration.htm");
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
         wbLoad = true;
      }

      protected void START3B2( )
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
         Form.Meta.addItem("description", "Repository configuration", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3B0( ) ;
      }

      protected void WS3B2( )
      {
         START3B2( ) ;
         EVT3B2( ) ;
      }

      protected void EVT3B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E123B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E133B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E143B2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E153B2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3B2( )
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

      protected void PA3B2( )
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
               GX_FocusControl = edtavGuid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavDefaultauthtypename.ItemCount > 0 )
         {
            AV32DefaultAuthTypeName = cmbavDefaultauthtypename.getValidValue(AV32DefaultAuthTypeName);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
            AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", cmbavDefaultauthtypename.ToJavascriptSource(), true);
         }
         if ( cmbavDefaultroleid.ItemCount > 0 )
         {
            AV52DefaultRoleId = (int)(Math.Round(NumberUtil.Val( cmbavDefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
            AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", cmbavDefaultroleid.ToJavascriptSource(), true);
         }
         if ( cmbavDefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV51DefaultSecurityPolicyId = (long)(Math.Round(NumberUtil.Val( cmbavDefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", cmbavDefaultsecuritypolicyid.ToJavascriptSource(), true);
         }
         AV34AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV34AllowOauthAccess));
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         if ( cmbavLogoutbehavior.ItemCount > 0 )
         {
            AV85LogoutBehavior = cmbavLogoutbehavior.getValidValue(AV85LogoutBehavior);
            AssignAttri("", false, "AV85LogoutBehavior", AV85LogoutBehavior);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogoutbehavior.CurrentValue = StringUtil.RTrim( AV85LogoutBehavior);
            AssignProp("", false, cmbavLogoutbehavior_Internalname, "Values", cmbavLogoutbehavior.ToJavascriptSource(), true);
         }
         AV57EnableWorkingAsGAMManagerRepo = StringUtil.StrToBool( StringUtil.BoolToStr( AV57EnableWorkingAsGAMManagerRepo));
         AssignAttri("", false, "AV57EnableWorkingAsGAMManagerRepo", AV57EnableWorkingAsGAMManagerRepo);
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV55EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV55EnableTracing", StringUtil.LTrimStr( (decimal)(AV55EnableTracing), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
         }
         if ( cmbavUseridentification.ItemCount > 0 )
         {
            AV35UserIdentification = cmbavUseridentification.getValidValue(AV35UserIdentification);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
            AssignProp("", false, cmbavUseridentification_Internalname, "Values", cmbavUseridentification.ToJavascriptSource(), true);
         }
         AV38UserEmailisUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV38UserEmailisUnique));
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         if ( cmbavUseractivationmethod.ItemCount > 0 )
         {
            AV36UserActivationMethod = cmbavUseractivationmethod.getValidValue(AV36UserActivationMethod);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
            AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", cmbavUseractivationmethod.ToJavascriptSource(), true);
         }
         if ( cmbavUserremembermetype.ItemCount > 0 )
         {
            AV42UserRememberMeType = cmbavUserremembermetype.getValidValue(AV42UserRememberMeType);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
            AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", cmbavUserremembermetype.ToJavascriptSource(), true);
         }
         AV39RequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV39RequiredEmail));
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         AV40RequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV40RequiredPassword));
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         AV53RequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV53RequiredFirstName));
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         AV54RequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV54RequiredLastName));
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         AV58RequiredBirthday = StringUtil.StrToBool( StringUtil.BoolToStr( AV58RequiredBirthday));
         AssignAttri("", false, "AV58RequiredBirthday", AV58RequiredBirthday);
         AV59RequiredGender = StringUtil.StrToBool( StringUtil.BoolToStr( AV59RequiredGender));
         AssignAttri("", false, "AV59RequiredGender", AV59RequiredGender);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV41GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV41GenerateSessionStatistics);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         }
         AV49GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV49GiveAnonymousSession));
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         AV33SessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV33SessionExpiresOnIPChange));
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         AV64EmailServerSecure = StringUtil.StrToBool( StringUtil.BoolToStr( AV64EmailServerSecure));
         AssignAttri("", false, "AV64EmailServerSecure", AV64EmailServerSecure);
         AV67EmailServerUsesAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV67EmailServerUsesAuthentication));
         AssignAttri("", false, "AV67EmailServerUsesAuthentication", AV67EmailServerUsesAuthentication);
         AV70EmailServer_SendEmailWhenUserActivateAccount = StringUtil.StrToBool( StringUtil.BoolToStr( AV70EmailServer_SendEmailWhenUserActivateAccount));
         AssignAttri("", false, "AV70EmailServer_SendEmailWhenUserActivateAccount", AV70EmailServer_SendEmailWhenUserActivateAccount);
         AV73EmailServer_SendEmailWhenUserChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV73EmailServer_SendEmailWhenUserChangePassword));
         AssignAttri("", false, "AV73EmailServer_SendEmailWhenUserChangePassword", AV73EmailServer_SendEmailWhenUserChangePassword);
         AV76EmailServer_SendEmailWhenUserChangeEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV76EmailServer_SendEmailWhenUserChangeEmail));
         AssignAttri("", false, "AV76EmailServer_SendEmailWhenUserChangeEmail", AV76EmailServer_SendEmailWhenUserChangeEmail);
         AV79EmailServer_SendEmailForRecoveryPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV79EmailServer_SendEmailForRecoveryPassword));
         AssignAttri("", false, "AV79EmailServer_SendEmailForRecoveryPassword", AV79EmailServer_SendEmailForRecoveryPassword);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavNamespace_Enabled = 0;
         AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
      }

      protected void RF3B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E133B2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E153B2 ();
            WB3B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3B2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV14Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vREPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87RepoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87RepoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECURITYADMINISTRATOREMAIL", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCANREGISTERUSERS", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
      }

      protected void before_start_formulas( )
      {
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavNamespace_Enabled = 0;
         AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Tblmasterrepo_Title = cgiGet( "TBLMASTERREPO_Title");
            Tblmasterrepo_Collapsible = StringUtil.StrToBool( cgiGet( "TBLMASTERREPO_Collapsible"));
            Tblmasterrepo_Open = StringUtil.StrToBool( cgiGet( "TBLMASTERREPO_Open"));
            Tblmasterrepo_Showborders = StringUtil.StrToBool( cgiGet( "TBLMASTERREPO_Showborders"));
            Tblmasterrepo_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLMASTERREPO_Containseditableform"));
            Tblmasterrepo_Visible = StringUtil.StrToBool( cgiGet( "TBLMASTERREPO_Visible"));
            Tbldonthavemasterrepo_Title = cgiGet( "TBLDONTHAVEMASTERREPO_Title");
            Tbldonthavemasterrepo_Collapsible = StringUtil.StrToBool( cgiGet( "TBLDONTHAVEMASTERREPO_Collapsible"));
            Tbldonthavemasterrepo_Open = StringUtil.StrToBool( cgiGet( "TBLDONTHAVEMASTERREPO_Open"));
            Tbldonthavemasterrepo_Showborders = StringUtil.StrToBool( cgiGet( "TBLDONTHAVEMASTERREPO_Showborders"));
            Tbldonthavemasterrepo_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLDONTHAVEMASTERREPO_Containseditableform"));
            Tbldonthavemasterrepo_Visible = StringUtil.StrToBool( cgiGet( "TBLDONTHAVEMASTERREPO_Visible"));
            Tblenableworkinasmanager_Title = cgiGet( "TBLENABLEWORKINASMANAGER_Title");
            Tblenableworkinasmanager_Collapsible = StringUtil.StrToBool( cgiGet( "TBLENABLEWORKINASMANAGER_Collapsible"));
            Tblenableworkinasmanager_Open = StringUtil.StrToBool( cgiGet( "TBLENABLEWORKINASMANAGER_Open"));
            Tblenableworkinasmanager_Showborders = StringUtil.StrToBool( cgiGet( "TBLENABLEWORKINASMANAGER_Showborders"));
            Tblenableworkinasmanager_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLENABLEWORKINASMANAGER_Containseditableform"));
            Tblenableworkinasmanager_Visible = StringUtil.StrToBool( cgiGet( "TBLENABLEWORKINASMANAGER_Visible"));
            Tblemailserveruseauthentication_Title = cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Title");
            Tblemailserveruseauthentication_Collapsible = StringUtil.StrToBool( cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Collapsible"));
            Tblemailserveruseauthentication_Open = StringUtil.StrToBool( cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Open"));
            Tblemailserveruseauthentication_Showborders = StringUtil.StrToBool( cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Showborders"));
            Tblemailserveruseauthentication_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Containseditableform"));
            Tblemailserveruseauthentication_Visible = StringUtil.StrToBool( cgiGet( "TBLEMAILSERVERUSEAUTHENTICATION_Visible"));
            Tbluseractivateaccount_Title = cgiGet( "TBLUSERACTIVATEACCOUNT_Title");
            Tbluseractivateaccount_Collapsible = StringUtil.StrToBool( cgiGet( "TBLUSERACTIVATEACCOUNT_Collapsible"));
            Tbluseractivateaccount_Open = StringUtil.StrToBool( cgiGet( "TBLUSERACTIVATEACCOUNT_Open"));
            Tbluseractivateaccount_Showborders = StringUtil.StrToBool( cgiGet( "TBLUSERACTIVATEACCOUNT_Showborders"));
            Tbluseractivateaccount_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLUSERACTIVATEACCOUNT_Containseditableform"));
            Tbluseractivateaccount_Visible = StringUtil.StrToBool( cgiGet( "TBLUSERACTIVATEACCOUNT_Visible"));
            Tbluserchangepassword_Title = cgiGet( "TBLUSERCHANGEPASSWORD_Title");
            Tbluserchangepassword_Collapsible = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEPASSWORD_Collapsible"));
            Tbluserchangepassword_Open = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEPASSWORD_Open"));
            Tbluserchangepassword_Showborders = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEPASSWORD_Showborders"));
            Tbluserchangepassword_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEPASSWORD_Containseditableform"));
            Tbluserchangepassword_Visible = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEPASSWORD_Visible"));
            Tbluserchangeemail_Title = cgiGet( "TBLUSERCHANGEEMAIL_Title");
            Tbluserchangeemail_Collapsible = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEEMAIL_Collapsible"));
            Tbluserchangeemail_Open = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEEMAIL_Open"));
            Tbluserchangeemail_Showborders = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEEMAIL_Showborders"));
            Tbluserchangeemail_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEEMAIL_Containseditableform"));
            Tbluserchangeemail_Visible = StringUtil.StrToBool( cgiGet( "TBLUSERCHANGEEMAIL_Visible"));
            Tbluserrecoverypassword_Title = cgiGet( "TBLUSERRECOVERYPASSWORD_Title");
            Tbluserrecoverypassword_Collapsible = StringUtil.StrToBool( cgiGet( "TBLUSERRECOVERYPASSWORD_Collapsible"));
            Tbluserrecoverypassword_Open = StringUtil.StrToBool( cgiGet( "TBLUSERRECOVERYPASSWORD_Open"));
            Tbluserrecoverypassword_Showborders = StringUtil.StrToBool( cgiGet( "TBLUSERRECOVERYPASSWORD_Showborders"));
            Tbluserrecoverypassword_Containseditableform = StringUtil.StrToBool( cgiGet( "TBLUSERRECOVERYPASSWORD_Containseditableform"));
            Tbluserrecoverypassword_Visible = StringUtil.StrToBool( cgiGet( "TBLUSERRECOVERYPASSWORD_Visible"));
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), ".", ","), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Attributes_Title = cgiGet( "ATTRIBUTES_Title");
            Attributes_Collapsible = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Collapsible"));
            Attributes_Open = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Open"));
            Attributes_Showborders = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Showborders"));
            Attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            AV28GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV28GUID", AV28GUID);
            AV29NameSpace = cgiGet( edtavNamespace_Internalname);
            AssignAttri("", false, "AV29NameSpace", AV29NameSpace);
            AV30Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV30Name", AV30Name);
            AV31Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV31Dsc", AV31Dsc);
            AV56AuthenticationMasterRepository = cgiGet( edtavAuthenticationmasterrepository_Internalname);
            AssignAttri("", false, "AV56AuthenticationMasterRepository", AV56AuthenticationMasterRepository);
            cmbavDefaultauthtypename.CurrentValue = cgiGet( cmbavDefaultauthtypename_Internalname);
            AV32DefaultAuthTypeName = cgiGet( cmbavDefaultauthtypename_Internalname);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
            cmbavDefaultroleid.CurrentValue = cgiGet( cmbavDefaultroleid_Internalname);
            AV52DefaultRoleId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavDefaultroleid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
            cmbavDefaultsecuritypolicyid.CurrentValue = cgiGet( cmbavDefaultsecuritypolicyid_Internalname);
            AV51DefaultSecurityPolicyId = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavDefaultsecuritypolicyid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
            AV34AllowOauthAccess = StringUtil.StrToBool( cgiGet( chkavAllowoauthaccess_Internalname));
            AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
            cmbavLogoutbehavior.CurrentValue = cgiGet( cmbavLogoutbehavior_Internalname);
            AV85LogoutBehavior = cgiGet( cmbavLogoutbehavior_Internalname);
            AssignAttri("", false, "AV85LogoutBehavior", AV85LogoutBehavior);
            AV57EnableWorkingAsGAMManagerRepo = StringUtil.StrToBool( cgiGet( chkavEnableworkingasgammanagerrepo_Internalname));
            AssignAttri("", false, "AV57EnableWorkingAsGAMManagerRepo", AV57EnableWorkingAsGAMManagerRepo);
            cmbavEnabletracing.CurrentValue = cgiGet( cmbavEnabletracing_Internalname);
            AV55EnableTracing = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavEnabletracing_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV55EnableTracing", StringUtil.LTrimStr( (decimal)(AV55EnableTracing), 4, 0));
            cmbavUseridentification.CurrentValue = cgiGet( cmbavUseridentification_Internalname);
            AV35UserIdentification = cgiGet( cmbavUseridentification_Internalname);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
            AV38UserEmailisUnique = StringUtil.StrToBool( cgiGet( chkavUseremailisunique_Internalname));
            AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
            cmbavUseractivationmethod.CurrentValue = cgiGet( cmbavUseractivationmethod_Internalname);
            AV36UserActivationMethod = cgiGet( cmbavUseractivationmethod_Internalname);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERAUTOMATICACTIVATIONTIMEOUT");
               GX_FocusControl = edtavUserautomaticactivationtimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37UserAutomaticActivationTimeout = 0;
               AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
            }
            else
            {
               AV37UserAutomaticActivationTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavUserautomaticactivationtimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERRECOVERYPASSWORDKEYTIMEOUT");
               GX_FocusControl = edtavUserrecoverypasswordkeytimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44UserRecoveryPasswordKeyTimeOut = 0;
               AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
            }
            else
            {
               AV44UserRecoveryPasswordKeyTimeOut = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavUserrecoverypasswordkeytimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLOGINATTEMPTSTOLOCKUSER");
               GX_FocusControl = edtavLoginattemptstolockuser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV46LoginAttemptsToLockUser = 0;
               AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
            }
            else
            {
               AV46LoginAttemptsToLockUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLoginattemptstolockuser_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGAMUNBLOCKUSERTIMEOUT");
               GX_FocusControl = edtavGamunblockusertimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47GAMUnblockUserTimeout = 0;
               AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
            }
            else
            {
               AV47GAMUnblockUserTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavGamunblockusertimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
            }
            cmbavUserremembermetype.CurrentValue = cgiGet( cmbavUserremembermetype_Internalname);
            AV42UserRememberMeType = cgiGet( cmbavUserremembermetype_Internalname);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERREMEMBERMETIMEOUT");
               GX_FocusControl = edtavUserremembermetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43UserRememberMeTimeOut = 0;
               AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
            }
            else
            {
               AV43UserRememberMeTimeOut = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavUserremembermetimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
            }
            AV39RequiredEmail = StringUtil.StrToBool( cgiGet( chkavRequiredemail_Internalname));
            AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
            AV40RequiredPassword = StringUtil.StrToBool( cgiGet( chkavRequiredpassword_Internalname));
            AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
            AV53RequiredFirstName = StringUtil.StrToBool( cgiGet( chkavRequiredfirstname_Internalname));
            AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
            AV54RequiredLastName = StringUtil.StrToBool( cgiGet( chkavRequiredlastname_Internalname));
            AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
            AV58RequiredBirthday = StringUtil.StrToBool( cgiGet( chkavRequiredbirthday_Internalname));
            AssignAttri("", false, "AV58RequiredBirthday", AV58RequiredBirthday);
            AV59RequiredGender = StringUtil.StrToBool( cgiGet( chkavRequiredgender_Internalname));
            AssignAttri("", false, "AV59RequiredGender", AV59RequiredGender);
            cmbavGeneratesessionstatistics.CurrentValue = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AV41GenerateSessionStatistics = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERSESSIONCACHETIMEOUT");
               GX_FocusControl = edtavUsersessioncachetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50UserSessionCacheTimeout = 0;
               AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
            }
            else
            {
               AV50UserSessionCacheTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsersessioncachetimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
            }
            AV49GiveAnonymousSession = StringUtil.StrToBool( cgiGet( chkavGiveanonymoussession_Internalname));
            AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
            AV33SessionExpiresOnIPChange = StringUtil.StrToBool( cgiGet( chkavSessionexpiresonipchange_Internalname));
            AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLOGINATTEMPTSTOLOCKSESSION");
               GX_FocusControl = edtavLoginattemptstolocksession_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV48LoginAttemptsToLockSession = 0;
               AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
            }
            else
            {
               AV48LoginAttemptsToLockSession = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLoginattemptstolocksession_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMAMOUNTCHARACTERSINLOGIN");
               GX_FocusControl = edtavMinimumamountcharactersinlogin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45MinimumAmountCharactersInLogin = 0;
               AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
            }
            else
            {
               AV45MinimumAmountCharactersInLogin = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumamountcharactersinlogin_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYCACHETIMEOUT");
               GX_FocusControl = edtavRepositorycachetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV60RepositoryCacheTimeout = 0;
               AssignAttri("", false, "AV60RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV60RepositoryCacheTimeout), 6, 0));
            }
            else
            {
               AV60RepositoryCacheTimeout = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV60RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV60RepositoryCacheTimeout), 6, 0));
            }
            AV61EmailServerHost = cgiGet( edtavEmailserverhost_Internalname);
            AssignAttri("", false, "AV61EmailServerHost", AV61EmailServerHost);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmailserverport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmailserverport_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMAILSERVERPORT");
               GX_FocusControl = edtavEmailserverport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV62EmailServerPort = 0;
               AssignAttri("", false, "AV62EmailServerPort", StringUtil.LTrimStr( (decimal)(AV62EmailServerPort), 4, 0));
            }
            else
            {
               AV62EmailServerPort = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmailserverport_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV62EmailServerPort", StringUtil.LTrimStr( (decimal)(AV62EmailServerPort), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmailservertimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmailservertimeout_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMAILSERVERTIMEOUT");
               GX_FocusControl = edtavEmailservertimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV63EmailServerTimeout = 0;
               AssignAttri("", false, "AV63EmailServerTimeout", StringUtil.LTrimStr( (decimal)(AV63EmailServerTimeout), 4, 0));
            }
            else
            {
               AV63EmailServerTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmailservertimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV63EmailServerTimeout", StringUtil.LTrimStr( (decimal)(AV63EmailServerTimeout), 4, 0));
            }
            AV64EmailServerSecure = StringUtil.StrToBool( cgiGet( chkavEmailserversecure_Internalname));
            AssignAttri("", false, "AV64EmailServerSecure", AV64EmailServerSecure);
            AV65ServerSenderAddress = cgiGet( edtavServersenderaddress_Internalname);
            AssignAttri("", false, "AV65ServerSenderAddress", AV65ServerSenderAddress);
            AV66ServerSenderName = cgiGet( edtavServersendername_Internalname);
            AssignAttri("", false, "AV66ServerSenderName", AV66ServerSenderName);
            AV67EmailServerUsesAuthentication = StringUtil.StrToBool( cgiGet( chkavEmailserverusesauthentication_Internalname));
            AssignAttri("", false, "AV67EmailServerUsesAuthentication", AV67EmailServerUsesAuthentication);
            AV68EmailServerAuthenticationUsername = cgiGet( edtavEmailserverauthenticationusername_Internalname);
            AssignAttri("", false, "AV68EmailServerAuthenticationUsername", AV68EmailServerAuthenticationUsername);
            AV69EmailServerAuthenticationUserPassword = cgiGet( edtavEmailserverauthenticationuserpassword_Internalname);
            AssignAttri("", false, "AV69EmailServerAuthenticationUserPassword", AV69EmailServerAuthenticationUserPassword);
            AV70EmailServer_SendEmailWhenUserActivateAccount = StringUtil.StrToBool( cgiGet( chkavEmailserver_sendemailwhenuseractivateaccount_Internalname));
            AssignAttri("", false, "AV70EmailServer_SendEmailWhenUserActivateAccount", AV70EmailServer_SendEmailWhenUserActivateAccount);
            AV71EmailServer_EmailSubjectWhenUserActivateAccount = cgiGet( edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname);
            AssignAttri("", false, "AV71EmailServer_EmailSubjectWhenUserActivateAccount", AV71EmailServer_EmailSubjectWhenUserActivateAccount);
            AV72EmailServer_EmailBodyWhenUserActivateAccount = cgiGet( edtavEmailserver_emailbodywhenuseractivateaccount_Internalname);
            AssignAttri("", false, "AV72EmailServer_EmailBodyWhenUserActivateAccount", AV72EmailServer_EmailBodyWhenUserActivateAccount);
            AV73EmailServer_SendEmailWhenUserChangePassword = StringUtil.StrToBool( cgiGet( chkavEmailserver_sendemailwhenuserchangepassword_Internalname));
            AssignAttri("", false, "AV73EmailServer_SendEmailWhenUserChangePassword", AV73EmailServer_SendEmailWhenUserChangePassword);
            AV74EmailServer_EmailSubjectWhenUserChangePassword = cgiGet( edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname);
            AssignAttri("", false, "AV74EmailServer_EmailSubjectWhenUserChangePassword", AV74EmailServer_EmailSubjectWhenUserChangePassword);
            AV75EmailServer_EmailBodyWhenUserChangePassword = cgiGet( edtavEmailserver_emailbodywhenuserchangepassword_Internalname);
            AssignAttri("", false, "AV75EmailServer_EmailBodyWhenUserChangePassword", AV75EmailServer_EmailBodyWhenUserChangePassword);
            AV76EmailServer_SendEmailWhenUserChangeEmail = StringUtil.StrToBool( cgiGet( chkavEmailserver_sendemailwhenuserchangeemail_Internalname));
            AssignAttri("", false, "AV76EmailServer_SendEmailWhenUserChangeEmail", AV76EmailServer_SendEmailWhenUserChangeEmail);
            AV77EmailServer_EmailSubjectWhenUserChangeEmail = cgiGet( edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname);
            AssignAttri("", false, "AV77EmailServer_EmailSubjectWhenUserChangeEmail", AV77EmailServer_EmailSubjectWhenUserChangeEmail);
            AV78EmailServer_EmailBodyWhenUserChangeEmail = cgiGet( edtavEmailserver_emailbodywhenuserchangeemail_Internalname);
            AssignAttri("", false, "AV78EmailServer_EmailBodyWhenUserChangeEmail", AV78EmailServer_EmailBodyWhenUserChangeEmail);
            AV79EmailServer_SendEmailForRecoveryPassword = StringUtil.StrToBool( cgiGet( chkavEmailserver_sendemailforrecoverypassword_Internalname));
            AssignAttri("", false, "AV79EmailServer_SendEmailForRecoveryPassword", AV79EmailServer_SendEmailForRecoveryPassword);
            AV80EmailServer_EmailSubjectForRecoveryPassword = cgiGet( edtavEmailserver_emailsubjectforrecoverypassword_Internalname);
            AssignAttri("", false, "AV80EmailServer_EmailSubjectForRecoveryPassword", AV80EmailServer_EmailSubjectForRecoveryPassword);
            AV81EmailServer_EmailBodyForRecoveryPassword = cgiGet( edtavEmailserver_emailbodyforrecoverypassword_Internalname);
            AssignAttri("", false, "AV81EmailServer_EmailBodyForRecoveryPassword", AV81EmailServer_EmailBodyForRecoveryPassword);
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
         divAttributescontainertable_tblmasterrepo_Class = "Section";
         AssignProp("", false, divAttributescontainertable_tblmasterrepo_Internalname, "Class", divAttributescontainertable_tblmasterrepo_Class, true);
         Attributes_Containseditableform = true;
         ucAttributes.SendProperty(context, "", false, Attributes_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( Attributes_Containseditableform));
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV86isLoginRepositoryAdm = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV13Errors);
         cmbavDefaultauthtypename.Visible = (!AV86isLoginRepositoryAdm ? 1 : 0);
         AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultauthtypename.Visible), 5, 0), true);
         cmbavDefaultsecuritypolicyid.Visible = (!AV86isLoginRepositoryAdm ? 1 : 0);
         AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultsecuritypolicyid.Visible), 5, 0), true);
         cmbavDefaultroleid.Visible = (!AV86isLoginRepositoryAdm ? 1 : 0);
         AssignProp("", false, cmbavDefaultroleid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultroleid.Visible), 5, 0), true);
         AV15AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV14Language, out  AV13Errors);
         AV88GXV1 = 1;
         while ( AV88GXV1 <= AV15AuthenticationTypes.Count )
         {
            AV5AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV15AuthenticationTypes.Item(AV88GXV1));
            cmbavDefaultauthtypename.addItem(AV5AuthenticationType.gxTpr_Name, AV5AuthenticationType.gxTpr_Description, 0);
            AV88GXV1 = (int)(AV88GXV1+1);
         }
         AV7SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV16FilterSecPol, out  AV13Errors);
         AV89GXV2 = 1;
         while ( AV89GXV2 <= AV7SecurityPolicies.Count )
         {
            AV8SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV7SecurityPolicies.Item(AV89GXV2));
            cmbavDefaultsecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8SecurityPolicy.gxTpr_Id), 12, 0)), AV8SecurityPolicy.gxTpr_Name, 0);
            AV89GXV2 = (int)(AV89GXV2+1);
         }
         AV6Roles = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV17FilterRole, out  AV13Errors);
         AV90GXV3 = 1;
         while ( AV90GXV3 <= AV6Roles.Count )
         {
            AV9Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV6Roles.Item(AV90GXV3));
            cmbavDefaultroleid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Role.gxTpr_Id), 9, 0)), AV9Role.gxTpr_Name, 0);
            AV90GXV3 = (int)(AV90GXV3+1);
         }
         if ( (0==AV27Id) )
         {
            AV87RepoId = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getid();
            AssignAttri("", false, "AV87RepoId", StringUtil.LTrimStr( (decimal)(AV87RepoId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vREPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87RepoId), "ZZZZZZZZZZZ9"), context));
         }
         else
         {
            AV87RepoId = AV27Id;
            AssignAttri("", false, "AV87RepoId", StringUtil.LTrimStr( (decimal)(AV87RepoId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vREPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV87RepoId), "ZZZZZZZZZZZ9"), context));
         }
         AV11Repository.load( (int)(AV87RepoId));
         AV28GUID = AV11Repository.gxTpr_Guid;
         AssignAttri("", false, "AV28GUID", AV28GUID);
         AV29NameSpace = AV11Repository.gxTpr_Namespace;
         AssignAttri("", false, "AV29NameSpace", AV29NameSpace);
         AV30Name = AV11Repository.gxTpr_Name;
         AssignAttri("", false, "AV30Name", AV30Name);
         AV31Dsc = AV11Repository.gxTpr_Description;
         AssignAttri("", false, "AV31Dsc", AV31Dsc);
         AV32DefaultAuthTypeName = AV11Repository.gxTpr_Defaultauthenticationtypename;
         AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         AV35UserIdentification = AV11Repository.gxTpr_Useridentification;
         AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         AV41GenerateSessionStatistics = AV11Repository.gxTpr_Generatesessionstatistics;
         AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         AV36UserActivationMethod = AV11Repository.gxTpr_Useractivationmethod;
         AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         AV37UserAutomaticActivationTimeout = (short)(AV11Repository.gxTpr_Userautomaticactivationtimeout);
         AssignAttri("", false, "AV37UserAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV37UserAutomaticActivationTimeout), 4, 0));
         AV42UserRememberMeType = AV11Repository.gxTpr_Userremembermetype;
         AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         AV43UserRememberMeTimeOut = AV11Repository.gxTpr_Userremembermetimeout;
         AssignAttri("", false, "AV43UserRememberMeTimeOut", StringUtil.LTrimStr( (decimal)(AV43UserRememberMeTimeOut), 4, 0));
         AV44UserRecoveryPasswordKeyTimeOut = (short)(AV11Repository.gxTpr_Userrecoverypasswordkeytimeout);
         AssignAttri("", false, "AV44UserRecoveryPasswordKeyTimeOut", StringUtil.LTrimStr( (decimal)(AV44UserRecoveryPasswordKeyTimeOut), 4, 0));
         AV45MinimumAmountCharactersInLogin = AV11Repository.gxTpr_Minimumamountcharactersinlogin;
         AssignAttri("", false, "AV45MinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV45MinimumAmountCharactersInLogin), 4, 0));
         AV46LoginAttemptsToLockUser = AV11Repository.gxTpr_Loginattemptstolockuser;
         AssignAttri("", false, "AV46LoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV46LoginAttemptsToLockUser), 4, 0));
         AV47GAMUnblockUserTimeout = (short)(AV11Repository.gxTpr_Gamunblockusertimeout);
         AssignAttri("", false, "AV47GAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV47GAMUnblockUserTimeout), 4, 0));
         AV48LoginAttemptsToLockSession = AV11Repository.gxTpr_Loginattemptstolocksession;
         AssignAttri("", false, "AV48LoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV48LoginAttemptsToLockSession), 4, 0));
         AV50UserSessionCacheTimeout = (short)(AV11Repository.gxTpr_Usersessioncachetimeout);
         AssignAttri("", false, "AV50UserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV50UserSessionCacheTimeout), 4, 0));
         AV60RepositoryCacheTimeout = AV11Repository.gxTpr_Cachetimeout;
         AssignAttri("", false, "AV60RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV60RepositoryCacheTimeout), 6, 0));
         AV85LogoutBehavior = AV11Repository.gxTpr_Gamremotelogoutbehavior;
         AssignAttri("", false, "AV85LogoutBehavior", AV85LogoutBehavior);
         AV18SecurityAdministratorEmail = AV11Repository.gxTpr_Securityadministratoremail;
         AssignAttri("", false, "AV18SecurityAdministratorEmail", AV18SecurityAdministratorEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECURITYADMINISTRATOREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18SecurityAdministratorEmail, "")), context));
         AV49GiveAnonymousSession = AV11Repository.gxTpr_Giveanonymoussession;
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         AV19CanRegisterUsers = AV11Repository.gxTpr_Canregisterusers;
         AssignAttri("", false, "AV19CanRegisterUsers", AV19CanRegisterUsers);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANREGISTERUSERS", GetSecureSignedToken( "", AV19CanRegisterUsers, context));
         AV38UserEmailisUnique = AV11Repository.gxTpr_Useremailisunique;
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         AV52DefaultRoleId = (int)(AV11Repository.gxTpr_Defaultroleid);
         AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         AV51DefaultSecurityPolicyId = AV11Repository.gxTpr_Defaultsecuritypolicyid;
         AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         AV57EnableWorkingAsGAMManagerRepo = AV11Repository.gxTpr_Enableworkingasgammanagerrepository;
         AssignAttri("", false, "AV57EnableWorkingAsGAMManagerRepo", AV57EnableWorkingAsGAMManagerRepo);
         AV55EnableTracing = AV11Repository.gxTpr_Enabletracing;
         AssignAttri("", false, "AV55EnableTracing", StringUtil.LTrimStr( (decimal)(AV55EnableTracing), 4, 0));
         AV34AllowOauthAccess = AV11Repository.gxTpr_Allowoauthaccess;
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         AV33SessionExpiresOnIPChange = AV11Repository.gxTpr_Sessionexpiresonipchange;
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         AV40RequiredPassword = AV11Repository.gxTpr_Requiredpassword;
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         AV39RequiredEmail = AV11Repository.gxTpr_Requiredemail;
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         AV53RequiredFirstName = AV11Repository.gxTpr_Requiredfirstname;
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         AV54RequiredLastName = AV11Repository.gxTpr_Requiredlastname;
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         AV58RequiredBirthday = AV11Repository.gxTpr_Requiredbirthday;
         AssignAttri("", false, "AV58RequiredBirthday", AV58RequiredBirthday);
         AV59RequiredGender = AV11Repository.gxTpr_Requiredgender;
         AssignAttri("", false, "AV59RequiredGender", AV59RequiredGender);
         Tblmasterrepo_Visible = false;
         ucTblmasterrepo.SendProperty(context, "", false, Tblmasterrepo_Internalname, "Visible", StringUtil.BoolToStr( Tblmasterrepo_Visible));
         Tblenableworkinasmanager_Visible = true;
         ucTblenableworkinasmanager.SendProperty(context, "", false, Tblenableworkinasmanager_Internalname, "Visible", StringUtil.BoolToStr( Tblenableworkinasmanager_Visible));
         Tbldonthavemasterrepo_Visible = true;
         ucTbldonthavemasterrepo.SendProperty(context, "", false, Tbldonthavemasterrepo_Internalname, "Visible", StringUtil.BoolToStr( Tbldonthavemasterrepo_Visible));
         if ( ! (0==AV11Repository.gxTpr_Authenticationmasterrepositoryid) )
         {
            Tbldonthavemasterrepo_Visible = false;
            ucTbldonthavemasterrepo.SendProperty(context, "", false, Tbldonthavemasterrepo_Internalname, "Visible", StringUtil.BoolToStr( Tbldonthavemasterrepo_Visible));
            Tblenableworkinasmanager_Visible = false;
            ucTblenableworkinasmanager.SendProperty(context, "", false, Tblenableworkinasmanager_Internalname, "Visible", StringUtil.BoolToStr( Tblenableworkinasmanager_Visible));
            AV82RepositoryCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getallrepositories(AV84Filter, out  AV13Errors);
            if ( AV82RepositoryCollection.Count > 1 )
            {
               Tblmasterrepo_Visible = true;
               ucTblmasterrepo.SendProperty(context, "", false, Tblmasterrepo_Internalname, "Visible", StringUtil.BoolToStr( Tblmasterrepo_Visible));
               AV91GXV4 = 1;
               while ( AV91GXV4 <= AV82RepositoryCollection.Count )
               {
                  AV83GAMRepositoryItem = ((GeneXus.Programs.genexussecurity.SdtGAMRepository)AV82RepositoryCollection.Item(AV91GXV4));
                  if ( AV83GAMRepositoryItem.gxTpr_Id == AV11Repository.gxTpr_Authenticationmasterrepositoryid )
                  {
                     AV56AuthenticationMasterRepository = StringUtil.Trim( AV83GAMRepositoryItem.gxTpr_Guid) + " - " + StringUtil.Trim( AV83GAMRepositoryItem.gxTpr_Name);
                     AssignAttri("", false, "AV56AuthenticationMasterRepository", AV56AuthenticationMasterRepository);
                     if (true) break;
                  }
                  AV91GXV4 = (int)(AV91GXV4+1);
               }
            }
         }
         AV61EmailServerHost = AV11Repository.gxTpr_Email.gxTpr_Serverhost;
         AssignAttri("", false, "AV61EmailServerHost", AV61EmailServerHost);
         AV62EmailServerPort = AV11Repository.gxTpr_Email.gxTpr_Serverport;
         AssignAttri("", false, "AV62EmailServerPort", StringUtil.LTrimStr( (decimal)(AV62EmailServerPort), 4, 0));
         AV64EmailServerSecure = AV11Repository.gxTpr_Email.gxTpr_Serversecure;
         AssignAttri("", false, "AV64EmailServerSecure", AV64EmailServerSecure);
         AV63EmailServerTimeout = AV11Repository.gxTpr_Email.gxTpr_Servertimeout;
         AssignAttri("", false, "AV63EmailServerTimeout", StringUtil.LTrimStr( (decimal)(AV63EmailServerTimeout), 4, 0));
         AV67EmailServerUsesAuthentication = AV11Repository.gxTpr_Email.gxTpr_Serverusesauthentication;
         AssignAttri("", false, "AV67EmailServerUsesAuthentication", AV67EmailServerUsesAuthentication);
         AV65ServerSenderAddress = AV11Repository.gxTpr_Email.gxTpr_Serversenderaddress;
         AssignAttri("", false, "AV65ServerSenderAddress", AV65ServerSenderAddress);
         AV66ServerSenderName = AV11Repository.gxTpr_Email.gxTpr_Serversendername;
         AssignAttri("", false, "AV66ServerSenderName", AV66ServerSenderName);
         if ( AV67EmailServerUsesAuthentication )
         {
            Tblemailserveruseauthentication_Visible = true;
            ucTblemailserveruseauthentication.SendProperty(context, "", false, Tblemailserveruseauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tblemailserveruseauthentication_Visible));
            AV68EmailServerAuthenticationUsername = AV11Repository.gxTpr_Email.gxTpr_Serverauthenticationusername;
            AssignAttri("", false, "AV68EmailServerAuthenticationUsername", AV68EmailServerAuthenticationUsername);
            AV69EmailServerAuthenticationUserPassword = AV11Repository.gxTpr_Email.gxTpr_Serverauthenticationuserpassword;
            AssignAttri("", false, "AV69EmailServerAuthenticationUserPassword", AV69EmailServerAuthenticationUserPassword);
         }
         else
         {
            Tblemailserveruseauthentication_Visible = false;
            ucTblemailserveruseauthentication.SendProperty(context, "", false, Tblemailserveruseauthentication_Internalname, "Visible", StringUtil.BoolToStr( Tblemailserveruseauthentication_Visible));
         }
         AV70EmailServer_SendEmailWhenUserActivateAccount = AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount;
         AssignAttri("", false, "AV70EmailServer_SendEmailWhenUserActivateAccount", AV70EmailServer_SendEmailWhenUserActivateAccount);
         if ( AV70EmailServer_SendEmailWhenUserActivateAccount )
         {
            Tbluseractivateaccount_Visible = true;
            ucTbluseractivateaccount.SendProperty(context, "", false, Tbluseractivateaccount_Internalname, "Visible", StringUtil.BoolToStr( Tbluseractivateaccount_Visible));
            AV71EmailServer_EmailSubjectWhenUserActivateAccount = AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuseractivateaccount;
            AssignAttri("", false, "AV71EmailServer_EmailSubjectWhenUserActivateAccount", AV71EmailServer_EmailSubjectWhenUserActivateAccount);
            AV72EmailServer_EmailBodyWhenUserActivateAccount = AV11Repository.gxTpr_Email.gxTpr_Bodywhenuseractivateaccount;
            AssignAttri("", false, "AV72EmailServer_EmailBodyWhenUserActivateAccount", AV72EmailServer_EmailBodyWhenUserActivateAccount);
         }
         else
         {
            Tbluseractivateaccount_Visible = false;
            ucTbluseractivateaccount.SendProperty(context, "", false, Tbluseractivateaccount_Internalname, "Visible", StringUtil.BoolToStr( Tbluseractivateaccount_Visible));
         }
         AV73EmailServer_SendEmailWhenUserChangePassword = AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuserchangepassword;
         AssignAttri("", false, "AV73EmailServer_SendEmailWhenUserChangePassword", AV73EmailServer_SendEmailWhenUserChangePassword);
         if ( AV73EmailServer_SendEmailWhenUserChangePassword )
         {
            Tbluserchangepassword_Visible = true;
            ucTbluserchangepassword.SendProperty(context, "", false, Tbluserchangepassword_Internalname, "Visible", StringUtil.BoolToStr( Tbluserchangepassword_Visible));
            AV74EmailServer_EmailSubjectWhenUserChangePassword = AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuserchangepassword;
            AssignAttri("", false, "AV74EmailServer_EmailSubjectWhenUserChangePassword", AV74EmailServer_EmailSubjectWhenUserChangePassword);
            AV75EmailServer_EmailBodyWhenUserChangePassword = AV11Repository.gxTpr_Email.gxTpr_Bodywhenuserchangepassword;
            AssignAttri("", false, "AV75EmailServer_EmailBodyWhenUserChangePassword", AV75EmailServer_EmailBodyWhenUserChangePassword);
         }
         else
         {
            Tbluserchangepassword_Visible = false;
            ucTbluserchangepassword.SendProperty(context, "", false, Tbluserchangepassword_Internalname, "Visible", StringUtil.BoolToStr( Tbluserchangepassword_Visible));
         }
         AV76EmailServer_SendEmailWhenUserChangeEmail = AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuserchangeemail;
         AssignAttri("", false, "AV76EmailServer_SendEmailWhenUserChangeEmail", AV76EmailServer_SendEmailWhenUserChangeEmail);
         if ( AV76EmailServer_SendEmailWhenUserChangeEmail )
         {
            Tbluserchangeemail_Visible = true;
            ucTbluserchangeemail.SendProperty(context, "", false, Tbluserchangeemail_Internalname, "Visible", StringUtil.BoolToStr( Tbluserchangeemail_Visible));
            AV77EmailServer_EmailSubjectWhenUserChangeEmail = AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuserchangeemail;
            AssignAttri("", false, "AV77EmailServer_EmailSubjectWhenUserChangeEmail", AV77EmailServer_EmailSubjectWhenUserChangeEmail);
            AV78EmailServer_EmailBodyWhenUserChangeEmail = AV11Repository.gxTpr_Email.gxTpr_Bodywhenuserchangeemail;
            AssignAttri("", false, "AV78EmailServer_EmailBodyWhenUserChangeEmail", AV78EmailServer_EmailBodyWhenUserChangeEmail);
         }
         else
         {
            Tbluserchangeemail_Visible = false;
            ucTbluserchangeemail.SendProperty(context, "", false, Tbluserchangeemail_Internalname, "Visible", StringUtil.BoolToStr( Tbluserchangeemail_Visible));
         }
         AV79EmailServer_SendEmailForRecoveryPassword = AV11Repository.gxTpr_Email.gxTpr_Sendemailtorecoveruserpassword;
         AssignAttri("", false, "AV79EmailServer_SendEmailForRecoveryPassword", AV79EmailServer_SendEmailForRecoveryPassword);
         if ( AV79EmailServer_SendEmailForRecoveryPassword )
         {
            Tbluserrecoverypassword_Visible = true;
            ucTbluserrecoverypassword.SendProperty(context, "", false, Tbluserrecoverypassword_Internalname, "Visible", StringUtil.BoolToStr( Tbluserrecoverypassword_Visible));
            AV80EmailServer_EmailSubjectForRecoveryPassword = AV11Repository.gxTpr_Email.gxTpr_Subjecttorecoveruserpassword;
            AssignAttri("", false, "AV80EmailServer_EmailSubjectForRecoveryPassword", AV80EmailServer_EmailSubjectForRecoveryPassword);
            AV81EmailServer_EmailBodyForRecoveryPassword = AV11Repository.gxTpr_Email.gxTpr_Bodytorecoveruserpassword;
            AssignAttri("", false, "AV81EmailServer_EmailBodyForRecoveryPassword", AV81EmailServer_EmailBodyForRecoveryPassword);
         }
         else
         {
            Tbluserrecoverypassword_Visible = false;
            ucTbluserrecoverypassword.SendProperty(context, "", false, Tbluserrecoverypassword_Internalname, "Visible", StringUtil.BoolToStr( Tbluserrecoverypassword_Visible));
         }
         /* Execute user subroutine: 'VALIDVIEWEMAILSCONFIGURATIONS' */
         S162 ();
         if (returnInSub) return;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E123B2 ();
         if (returnInSub) return;
      }

      protected void E123B2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E133B2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavDefaultauthtypename.CurrentValue = StringUtil.RTrim( AV32DefaultAuthTypeName);
         AssignProp("", false, cmbavDefaultauthtypename_Internalname, "Values", cmbavDefaultauthtypename.ToJavascriptSource(), true);
         cmbavDefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         AssignProp("", false, cmbavDefaultsecuritypolicyid_Internalname, "Values", cmbavDefaultsecuritypolicyid.ToJavascriptSource(), true);
         cmbavDefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0));
         AssignProp("", false, cmbavDefaultroleid_Internalname, "Values", cmbavDefaultroleid.ToJavascriptSource(), true);
         cmbavUseridentification.CurrentValue = StringUtil.RTrim( AV35UserIdentification);
         AssignProp("", false, cmbavUseridentification_Internalname, "Values", cmbavUseridentification.ToJavascriptSource(), true);
         cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV41GenerateSessionStatistics);
         AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         cmbavUseractivationmethod.CurrentValue = StringUtil.RTrim( AV36UserActivationMethod);
         AssignProp("", false, cmbavUseractivationmethod_Internalname, "Values", cmbavUseractivationmethod.ToJavascriptSource(), true);
         cmbavUserremembermetype.CurrentValue = StringUtil.RTrim( AV42UserRememberMeType);
         AssignProp("", false, cmbavUserremembermetype_Internalname, "Values", cmbavUserremembermetype.ToJavascriptSource(), true);
         cmbavLogoutbehavior.CurrentValue = StringUtil.RTrim( AV85LogoutBehavior);
         AssignProp("", false, cmbavLogoutbehavior_Internalname, "Values", cmbavLogoutbehavior.ToJavascriptSource(), true);
         cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0));
         AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV11Repository.load( (int)(AV87RepoId));
         AV11Repository.gxTpr_Name = AV30Name;
         AV11Repository.gxTpr_Description = AV31Dsc;
         AV11Repository.gxTpr_Defaultauthenticationtypename = AV32DefaultAuthTypeName;
         AV11Repository.gxTpr_Useridentification = AV35UserIdentification;
         AV11Repository.gxTpr_Generatesessionstatistics = AV41GenerateSessionStatistics;
         AV11Repository.gxTpr_Useractivationmethod = AV36UserActivationMethod;
         AV11Repository.gxTpr_Userautomaticactivationtimeout = AV37UserAutomaticActivationTimeout;
         AV11Repository.gxTpr_Gamunblockusertimeout = AV47GAMUnblockUserTimeout;
         AV11Repository.gxTpr_Userremembermetype = AV42UserRememberMeType;
         AV11Repository.gxTpr_Userremembermetimeout = AV43UserRememberMeTimeOut;
         AV11Repository.gxTpr_Userrecoverypasswordkeytimeout = AV44UserRecoveryPasswordKeyTimeOut;
         AV11Repository.gxTpr_Gamremotelogoutbehavior = AV85LogoutBehavior;
         AV11Repository.gxTpr_Minimumamountcharactersinlogin = AV45MinimumAmountCharactersInLogin;
         AV11Repository.gxTpr_Loginattemptstolockuser = AV46LoginAttemptsToLockUser;
         AV11Repository.gxTpr_Loginattemptstolocksession = AV48LoginAttemptsToLockSession;
         AV11Repository.gxTpr_Usersessioncachetimeout = AV50UserSessionCacheTimeout;
         AV11Repository.gxTpr_Cachetimeout = AV60RepositoryCacheTimeout;
         AV11Repository.gxTpr_Securityadministratoremail = AV18SecurityAdministratorEmail;
         AV11Repository.gxTpr_Giveanonymoussession = AV49GiveAnonymousSession;
         AV11Repository.gxTpr_Canregisterusers = AV19CanRegisterUsers;
         AV11Repository.gxTpr_Useremailisunique = AV38UserEmailisUnique;
         AV11Repository.gxTpr_Defaultroleid = AV52DefaultRoleId;
         AV11Repository.gxTpr_Defaultsecuritypolicyid = (int)(AV51DefaultSecurityPolicyId);
         AV11Repository.gxTpr_Enableworkingasgammanagerrepository = AV57EnableWorkingAsGAMManagerRepo;
         AV11Repository.gxTpr_Enabletracing = AV55EnableTracing;
         AV11Repository.gxTpr_Allowoauthaccess = AV34AllowOauthAccess;
         AV11Repository.gxTpr_Sessionexpiresonipchange = AV33SessionExpiresOnIPChange;
         AV11Repository.gxTpr_Requiredpassword = AV40RequiredPassword;
         AV11Repository.gxTpr_Requiredemail = AV39RequiredEmail;
         AV11Repository.gxTpr_Requiredfirstname = AV53RequiredFirstName;
         AV11Repository.gxTpr_Requiredlastname = AV54RequiredLastName;
         AV11Repository.gxTpr_Requiredbirthday = AV58RequiredBirthday;
         AV11Repository.gxTpr_Requiredgender = AV59RequiredGender;
         AV11Repository.gxTpr_Email.gxTpr_Serverhost = AV61EmailServerHost;
         AV11Repository.gxTpr_Email.gxTpr_Serverport = AV62EmailServerPort;
         AV11Repository.gxTpr_Email.gxTpr_Serversecure = AV64EmailServerSecure;
         AV11Repository.gxTpr_Email.gxTpr_Servertimeout = AV63EmailServerTimeout;
         AV11Repository.gxTpr_Email.gxTpr_Serverusesauthentication = AV67EmailServerUsesAuthentication;
         AV11Repository.gxTpr_Email.gxTpr_Serversenderaddress = AV65ServerSenderAddress;
         AV11Repository.gxTpr_Email.gxTpr_Serversendername = AV66ServerSenderName;
         if ( AV67EmailServerUsesAuthentication )
         {
            AV11Repository.gxTpr_Email.gxTpr_Serverauthenticationusername = AV68EmailServerAuthenticationUsername;
            AV11Repository.gxTpr_Email.gxTpr_Serverauthenticationuserpassword = AV69EmailServerAuthenticationUserPassword;
         }
         AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount = AV70EmailServer_SendEmailWhenUserActivateAccount;
         if ( AV70EmailServer_SendEmailWhenUserActivateAccount )
         {
            AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuseractivateaccount = AV71EmailServer_EmailSubjectWhenUserActivateAccount;
            AV11Repository.gxTpr_Email.gxTpr_Bodywhenuseractivateaccount = AV72EmailServer_EmailBodyWhenUserActivateAccount;
         }
         AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuserchangepassword = AV73EmailServer_SendEmailWhenUserChangePassword;
         if ( AV73EmailServer_SendEmailWhenUserChangePassword )
         {
            AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuserchangepassword = AV74EmailServer_EmailSubjectWhenUserChangePassword;
            AV11Repository.gxTpr_Email.gxTpr_Bodywhenuserchangepassword = AV75EmailServer_EmailBodyWhenUserChangePassword;
         }
         AV11Repository.gxTpr_Email.gxTpr_Sendemailwhenuserchangeemail = AV76EmailServer_SendEmailWhenUserChangeEmail;
         if ( AV76EmailServer_SendEmailWhenUserChangeEmail )
         {
            AV11Repository.gxTpr_Email.gxTpr_Subjectwhenuserchangeemail = AV77EmailServer_EmailSubjectWhenUserChangeEmail;
            AV11Repository.gxTpr_Email.gxTpr_Bodywhenuserchangeemail = AV78EmailServer_EmailBodyWhenUserChangeEmail;
         }
         AV11Repository.gxTpr_Email.gxTpr_Sendemailtorecoveruserpassword = AV79EmailServer_SendEmailForRecoveryPassword;
         if ( AV79EmailServer_SendEmailForRecoveryPassword )
         {
            AV11Repository.gxTpr_Email.gxTpr_Subjecttorecoveruserpassword = AV80EmailServer_EmailSubjectForRecoveryPassword;
            AV11Repository.gxTpr_Email.gxTpr_Bodytorecoveruserpassword = AV81EmailServer_EmailBodyForRecoveryPassword;
         }
         AV11Repository.save();
         if ( AV11Repository.success() )
         {
            context.CommitDataStores("k2bfsg.repositoryconfiguration",pr_default);
            GX_msglist.addItem(context.GetMessage( "Data has been successfully updated.", ""));
         }
         else
         {
            AV13Errors = AV11Repository.geterrors();
            AV92GXV5 = 1;
            while ( AV92GXV5 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV92GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV92GXV5 = (int)(AV92GXV5+1);
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E143B2 ();
         if (returnInSub) return;
      }

      protected void E143B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.secbackendhome.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'VALIDVIEWEMAILSCONFIGURATIONS' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV35UserIdentification, "email") == 0 ) || ( StringUtil.StrCmp(AV35UserIdentification, "namema") == 0 ) )
         {
            AV38UserEmailisUnique = true;
            AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
            AV39RequiredEmail = true;
            AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
            chkavUseremailisunique.Visible = 0;
            AssignProp("", false, chkavUseremailisunique_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUseremailisunique.Visible), 5, 0), true);
            chkavRequiredemail.Visible = 0;
            AssignProp("", false, chkavRequiredemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRequiredemail.Visible), 5, 0), true);
         }
         else
         {
            chkavUseremailisunique.Visible = 1;
            AssignProp("", false, chkavUseremailisunique_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUseremailisunique.Visible), 5, 0), true);
            chkavRequiredemail.Visible = 1;
            AssignProp("", false, chkavRequiredemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRequiredemail.Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E153B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27Id = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV27Id", StringUtil.LTrimStr( (decimal)(AV27Id), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Id), "ZZZZZZZZZZZ9"), context));
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
         PA3B2( ) ;
         WS3B2( ) ;
         WE3B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138184746", true, true);
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
         context.AddJavascriptSource("k2bfsg/repositoryconfiguration.js", "?20243138184750", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         cmbavDefaultauthtypename.Name = "vDEFAULTAUTHTYPENAME";
         cmbavDefaultauthtypename.WebTags = "";
         if ( cmbavDefaultauthtypename.ItemCount > 0 )
         {
            AV32DefaultAuthTypeName = cmbavDefaultauthtypename.getValidValue(AV32DefaultAuthTypeName);
            AssignAttri("", false, "AV32DefaultAuthTypeName", AV32DefaultAuthTypeName);
         }
         cmbavDefaultroleid.Name = "vDEFAULTROLEID";
         cmbavDefaultroleid.WebTags = "";
         if ( cmbavDefaultroleid.ItemCount > 0 )
         {
            AV52DefaultRoleId = (int)(Math.Round(NumberUtil.Val( cmbavDefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DefaultRoleId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DefaultRoleId", StringUtil.LTrimStr( (decimal)(AV52DefaultRoleId), 9, 0));
         }
         cmbavDefaultsecuritypolicyid.Name = "vDEFAULTSECURITYPOLICYID";
         cmbavDefaultsecuritypolicyid.WebTags = "";
         if ( cmbavDefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV51DefaultSecurityPolicyId = (long)(Math.Round(NumberUtil.Val( cmbavDefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51DefaultSecurityPolicyId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV51DefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV51DefaultSecurityPolicyId), 12, 0));
         }
         chkavAllowoauthaccess.Name = "vALLOWOAUTHACCESS";
         chkavAllowoauthaccess.WebTags = "";
         chkavAllowoauthaccess.Caption = "";
         AssignProp("", false, chkavAllowoauthaccess_Internalname, "TitleCaption", chkavAllowoauthaccess.Caption, true);
         chkavAllowoauthaccess.CheckedValue = "false";
         AV34AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV34AllowOauthAccess));
         AssignAttri("", false, "AV34AllowOauthAccess", AV34AllowOauthAccess);
         cmbavLogoutbehavior.Name = "vLOGOUTBEHAVIOR";
         cmbavLogoutbehavior.WebTags = "";
         cmbavLogoutbehavior.addItem("clionl", "Client only", 0);
         cmbavLogoutbehavior.addItem("cliip", "Identity Provider and Client", 0);
         cmbavLogoutbehavior.addItem("all", "Identity Provider and all Clients", 0);
         if ( cmbavLogoutbehavior.ItemCount > 0 )
         {
            AV85LogoutBehavior = cmbavLogoutbehavior.getValidValue(AV85LogoutBehavior);
            AssignAttri("", false, "AV85LogoutBehavior", AV85LogoutBehavior);
         }
         chkavEnableworkingasgammanagerrepo.Name = "vENABLEWORKINGASGAMMANAGERREPO";
         chkavEnableworkingasgammanagerrepo.WebTags = "";
         chkavEnableworkingasgammanagerrepo.Caption = "";
         AssignProp("", false, chkavEnableworkingasgammanagerrepo_Internalname, "TitleCaption", chkavEnableworkingasgammanagerrepo.Caption, true);
         chkavEnableworkingasgammanagerrepo.CheckedValue = "false";
         AV57EnableWorkingAsGAMManagerRepo = StringUtil.StrToBool( StringUtil.BoolToStr( AV57EnableWorkingAsGAMManagerRepo));
         AssignAttri("", false, "AV57EnableWorkingAsGAMManagerRepo", AV57EnableWorkingAsGAMManagerRepo);
         cmbavEnabletracing.Name = "vENABLETRACING";
         cmbavEnabletracing.WebTags = "";
         cmbavEnabletracing.addItem("0", "0 - Off", 0);
         cmbavEnabletracing.addItem("1", "1 - Debug", 0);
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV55EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV55EnableTracing", StringUtil.LTrimStr( (decimal)(AV55EnableTracing), 4, 0));
         }
         cmbavUseridentification.Name = "vUSERIDENTIFICATION";
         cmbavUseridentification.WebTags = "";
         cmbavUseridentification.addItem("name", "Name", 0);
         cmbavUseridentification.addItem("email", "EMail", 0);
         cmbavUseridentification.addItem("namema", "Email or Name", 0);
         if ( cmbavUseridentification.ItemCount > 0 )
         {
            AV35UserIdentification = cmbavUseridentification.getValidValue(AV35UserIdentification);
            AssignAttri("", false, "AV35UserIdentification", AV35UserIdentification);
         }
         chkavUseremailisunique.Name = "vUSEREMAILISUNIQUE";
         chkavUseremailisunique.WebTags = "";
         chkavUseremailisunique.Caption = "";
         AssignProp("", false, chkavUseremailisunique_Internalname, "TitleCaption", chkavUseremailisunique.Caption, true);
         chkavUseremailisunique.CheckedValue = "false";
         AV38UserEmailisUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV38UserEmailisUnique));
         AssignAttri("", false, "AV38UserEmailisUnique", AV38UserEmailisUnique);
         cmbavUseractivationmethod.Name = "vUSERACTIVATIONMETHOD";
         cmbavUseractivationmethod.WebTags = "";
         cmbavUseractivationmethod.addItem("A", "Automatic", 0);
         cmbavUseractivationmethod.addItem("U", "User", 0);
         cmbavUseractivationmethod.addItem("D", "Administrator", 0);
         if ( cmbavUseractivationmethod.ItemCount > 0 )
         {
            AV36UserActivationMethod = cmbavUseractivationmethod.getValidValue(AV36UserActivationMethod);
            AssignAttri("", false, "AV36UserActivationMethod", AV36UserActivationMethod);
         }
         cmbavUserremembermetype.Name = "vUSERREMEMBERMETYPE";
         cmbavUserremembermetype.WebTags = "";
         cmbavUserremembermetype.addItem("None", "None", 0);
         cmbavUserremembermetype.addItem("Login", "Login", 0);
         cmbavUserremembermetype.addItem("Auth", "Authentication", 0);
         cmbavUserremembermetype.addItem("Both", "Both", 0);
         if ( cmbavUserremembermetype.ItemCount > 0 )
         {
            AV42UserRememberMeType = cmbavUserremembermetype.getValidValue(AV42UserRememberMeType);
            AssignAttri("", false, "AV42UserRememberMeType", AV42UserRememberMeType);
         }
         chkavRequiredemail.Name = "vREQUIREDEMAIL";
         chkavRequiredemail.WebTags = "";
         chkavRequiredemail.Caption = "";
         AssignProp("", false, chkavRequiredemail_Internalname, "TitleCaption", chkavRequiredemail.Caption, true);
         chkavRequiredemail.CheckedValue = "false";
         AV39RequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV39RequiredEmail));
         AssignAttri("", false, "AV39RequiredEmail", AV39RequiredEmail);
         chkavRequiredpassword.Name = "vREQUIREDPASSWORD";
         chkavRequiredpassword.WebTags = "";
         chkavRequiredpassword.Caption = "";
         AssignProp("", false, chkavRequiredpassword_Internalname, "TitleCaption", chkavRequiredpassword.Caption, true);
         chkavRequiredpassword.CheckedValue = "false";
         AV40RequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV40RequiredPassword));
         AssignAttri("", false, "AV40RequiredPassword", AV40RequiredPassword);
         chkavRequiredfirstname.Name = "vREQUIREDFIRSTNAME";
         chkavRequiredfirstname.WebTags = "";
         chkavRequiredfirstname.Caption = "";
         AssignProp("", false, chkavRequiredfirstname_Internalname, "TitleCaption", chkavRequiredfirstname.Caption, true);
         chkavRequiredfirstname.CheckedValue = "false";
         AV53RequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV53RequiredFirstName));
         AssignAttri("", false, "AV53RequiredFirstName", AV53RequiredFirstName);
         chkavRequiredlastname.Name = "vREQUIREDLASTNAME";
         chkavRequiredlastname.WebTags = "";
         chkavRequiredlastname.Caption = "";
         AssignProp("", false, chkavRequiredlastname_Internalname, "TitleCaption", chkavRequiredlastname.Caption, true);
         chkavRequiredlastname.CheckedValue = "false";
         AV54RequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV54RequiredLastName));
         AssignAttri("", false, "AV54RequiredLastName", AV54RequiredLastName);
         chkavRequiredbirthday.Name = "vREQUIREDBIRTHDAY";
         chkavRequiredbirthday.WebTags = "";
         chkavRequiredbirthday.Caption = "";
         AssignProp("", false, chkavRequiredbirthday_Internalname, "TitleCaption", chkavRequiredbirthday.Caption, true);
         chkavRequiredbirthday.CheckedValue = "false";
         AV58RequiredBirthday = StringUtil.StrToBool( StringUtil.BoolToStr( AV58RequiredBirthday));
         AssignAttri("", false, "AV58RequiredBirthday", AV58RequiredBirthday);
         chkavRequiredgender.Name = "vREQUIREDGENDER";
         chkavRequiredgender.WebTags = "";
         chkavRequiredgender.Caption = "";
         AssignProp("", false, chkavRequiredgender_Internalname, "TitleCaption", chkavRequiredgender.Caption, true);
         chkavRequiredgender.CheckedValue = "false";
         AV59RequiredGender = StringUtil.StrToBool( StringUtil.BoolToStr( AV59RequiredGender));
         AssignAttri("", false, "AV59RequiredGender", AV59RequiredGender);
         cmbavGeneratesessionstatistics.Name = "vGENERATESESSIONSTATISTICS";
         cmbavGeneratesessionstatistics.WebTags = "";
         cmbavGeneratesessionstatistics.addItem("None", "None", 0);
         cmbavGeneratesessionstatistics.addItem("Minimum", "Minimum (Only authenticated users)", 0);
         cmbavGeneratesessionstatistics.addItem("Detail", "Detail (Authenticated and anonymous users)", 0);
         cmbavGeneratesessionstatistics.addItem("Full", "Full log (Authenticated and anonymous users)", 0);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV41GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV41GenerateSessionStatistics);
            AssignAttri("", false, "AV41GenerateSessionStatistics", AV41GenerateSessionStatistics);
         }
         chkavGiveanonymoussession.Name = "vGIVEANONYMOUSSESSION";
         chkavGiveanonymoussession.WebTags = "";
         chkavGiveanonymoussession.Caption = "";
         AssignProp("", false, chkavGiveanonymoussession_Internalname, "TitleCaption", chkavGiveanonymoussession.Caption, true);
         chkavGiveanonymoussession.CheckedValue = "false";
         AV49GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV49GiveAnonymousSession));
         AssignAttri("", false, "AV49GiveAnonymousSession", AV49GiveAnonymousSession);
         chkavSessionexpiresonipchange.Name = "vSESSIONEXPIRESONIPCHANGE";
         chkavSessionexpiresonipchange.WebTags = "";
         chkavSessionexpiresonipchange.Caption = "";
         AssignProp("", false, chkavSessionexpiresonipchange_Internalname, "TitleCaption", chkavSessionexpiresonipchange.Caption, true);
         chkavSessionexpiresonipchange.CheckedValue = "false";
         AV33SessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV33SessionExpiresOnIPChange));
         AssignAttri("", false, "AV33SessionExpiresOnIPChange", AV33SessionExpiresOnIPChange);
         chkavEmailserversecure.Name = "vEMAILSERVERSECURE";
         chkavEmailserversecure.WebTags = "";
         chkavEmailserversecure.Caption = "";
         AssignProp("", false, chkavEmailserversecure_Internalname, "TitleCaption", chkavEmailserversecure.Caption, true);
         chkavEmailserversecure.CheckedValue = "false";
         AV64EmailServerSecure = StringUtil.StrToBool( StringUtil.BoolToStr( AV64EmailServerSecure));
         AssignAttri("", false, "AV64EmailServerSecure", AV64EmailServerSecure);
         chkavEmailserverusesauthentication.Name = "vEMAILSERVERUSESAUTHENTICATION";
         chkavEmailserverusesauthentication.WebTags = "";
         chkavEmailserverusesauthentication.Caption = "";
         AssignProp("", false, chkavEmailserverusesauthentication_Internalname, "TitleCaption", chkavEmailserverusesauthentication.Caption, true);
         chkavEmailserverusesauthentication.CheckedValue = "false";
         AV67EmailServerUsesAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV67EmailServerUsesAuthentication));
         AssignAttri("", false, "AV67EmailServerUsesAuthentication", AV67EmailServerUsesAuthentication);
         chkavEmailserver_sendemailwhenuseractivateaccount.Name = "vEMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT";
         chkavEmailserver_sendemailwhenuseractivateaccount.WebTags = "";
         chkavEmailserver_sendemailwhenuseractivateaccount.Caption = "";
         AssignProp("", false, chkavEmailserver_sendemailwhenuseractivateaccount_Internalname, "TitleCaption", chkavEmailserver_sendemailwhenuseractivateaccount.Caption, true);
         chkavEmailserver_sendemailwhenuseractivateaccount.CheckedValue = "false";
         AV70EmailServer_SendEmailWhenUserActivateAccount = StringUtil.StrToBool( StringUtil.BoolToStr( AV70EmailServer_SendEmailWhenUserActivateAccount));
         AssignAttri("", false, "AV70EmailServer_SendEmailWhenUserActivateAccount", AV70EmailServer_SendEmailWhenUserActivateAccount);
         chkavEmailserver_sendemailwhenuserchangepassword.Name = "vEMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD";
         chkavEmailserver_sendemailwhenuserchangepassword.WebTags = "";
         chkavEmailserver_sendemailwhenuserchangepassword.Caption = "";
         AssignProp("", false, chkavEmailserver_sendemailwhenuserchangepassword_Internalname, "TitleCaption", chkavEmailserver_sendemailwhenuserchangepassword.Caption, true);
         chkavEmailserver_sendemailwhenuserchangepassword.CheckedValue = "false";
         AV73EmailServer_SendEmailWhenUserChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV73EmailServer_SendEmailWhenUserChangePassword));
         AssignAttri("", false, "AV73EmailServer_SendEmailWhenUserChangePassword", AV73EmailServer_SendEmailWhenUserChangePassword);
         chkavEmailserver_sendemailwhenuserchangeemail.Name = "vEMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL";
         chkavEmailserver_sendemailwhenuserchangeemail.WebTags = "";
         chkavEmailserver_sendemailwhenuserchangeemail.Caption = "";
         AssignProp("", false, chkavEmailserver_sendemailwhenuserchangeemail_Internalname, "TitleCaption", chkavEmailserver_sendemailwhenuserchangeemail.Caption, true);
         chkavEmailserver_sendemailwhenuserchangeemail.CheckedValue = "false";
         AV76EmailServer_SendEmailWhenUserChangeEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV76EmailServer_SendEmailWhenUserChangeEmail));
         AssignAttri("", false, "AV76EmailServer_SendEmailWhenUserChangeEmail", AV76EmailServer_SendEmailWhenUserChangeEmail);
         chkavEmailserver_sendemailforrecoverypassword.Name = "vEMAILSERVER_SENDEMAILFORRECOVERYPASSWORD";
         chkavEmailserver_sendemailforrecoverypassword.WebTags = "";
         chkavEmailserver_sendemailforrecoverypassword.Caption = "";
         AssignProp("", false, chkavEmailserver_sendemailforrecoverypassword_Internalname, "TitleCaption", chkavEmailserver_sendemailforrecoverypassword.Caption, true);
         chkavEmailserver_sendemailforrecoverypassword.CheckedValue = "false";
         AV79EmailServer_SendEmailForRecoveryPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV79EmailServer_SendEmailForRecoveryPassword));
         AssignAttri("", false, "AV79EmailServer_SendEmailForRecoveryPassword", AV79EmailServer_SendEmailForRecoveryPassword);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         lblTab_title_Internalname = "TAB_TITLE";
         edtavId_Internalname = "vID";
         divTable_container_id_Internalname = "TABLE_CONTAINER_ID";
         edtavGuid_Internalname = "vGUID";
         divTable_container_guid_Internalname = "TABLE_CONTAINER_GUID";
         edtavNamespace_Internalname = "vNAMESPACE";
         divTable_container_namespace_Internalname = "TABLE_CONTAINER_NAMESPACE";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavDsc_Internalname = "vDSC";
         divTable_container_dsc_Internalname = "TABLE_CONTAINER_DSC";
         edtavAuthenticationmasterrepository_Internalname = "vAUTHENTICATIONMASTERREPOSITORY";
         divTable_container_authenticationmasterrepository_Internalname = "TABLE_CONTAINER_AUTHENTICATIONMASTERREPOSITORY";
         divAttributescontainertable_tblmasterrepo_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLMASTERREPO";
         divTblmasterrepo_content_Internalname = "TBLMASTERREPO_CONTENT";
         Tblmasterrepo_Internalname = "TBLMASTERREPO";
         cmbavDefaultauthtypename_Internalname = "vDEFAULTAUTHTYPENAME";
         divTable_container_defaultauthtypename_Internalname = "TABLE_CONTAINER_DEFAULTAUTHTYPENAME";
         cmbavDefaultroleid_Internalname = "vDEFAULTROLEID";
         divTable_container_defaultroleid_Internalname = "TABLE_CONTAINER_DEFAULTROLEID";
         cmbavDefaultsecuritypolicyid_Internalname = "vDEFAULTSECURITYPOLICYID";
         divTable_container_defaultsecuritypolicyid_Internalname = "TABLE_CONTAINER_DEFAULTSECURITYPOLICYID";
         divAttributescontainertable_tbldonthavemasterrepo_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLDONTHAVEMASTERREPO";
         divTbldonthavemasterrepo_content_Internalname = "TBLDONTHAVEMASTERREPO_CONTENT";
         Tbldonthavemasterrepo_Internalname = "TBLDONTHAVEMASTERREPO";
         chkavAllowoauthaccess_Internalname = "vALLOWOAUTHACCESS";
         divTable_container_allowoauthaccess_Internalname = "TABLE_CONTAINER_ALLOWOAUTHACCESS";
         cmbavLogoutbehavior_Internalname = "vLOGOUTBEHAVIOR";
         divTable_container_logoutbehavior_Internalname = "TABLE_CONTAINER_LOGOUTBEHAVIOR";
         chkavEnableworkingasgammanagerrepo_Internalname = "vENABLEWORKINGASGAMMANAGERREPO";
         divTable_container_enableworkingasgammanagerrepo_Internalname = "TABLE_CONTAINER_ENABLEWORKINGASGAMMANAGERREPO";
         divAttributescontainertable_tblenableworkinasmanager_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLENABLEWORKINASMANAGER";
         divTblenableworkinasmanager_content_Internalname = "TBLENABLEWORKINASMANAGER_CONTENT";
         Tblenableworkinasmanager_Internalname = "TBLENABLEWORKINASMANAGER";
         cmbavEnabletracing_Internalname = "vENABLETRACING";
         divTable_container_enabletracing_Internalname = "TABLE_CONTAINER_ENABLETRACING";
         divMaintabresponsivetable_tab_Internalname = "MAINTABRESPONSIVETABLE_TAB";
         lblTab1_title_Internalname = "TAB1_TITLE";
         cmbavUseridentification_Internalname = "vUSERIDENTIFICATION";
         divTable_container_useridentification_Internalname = "TABLE_CONTAINER_USERIDENTIFICATION";
         chkavUseremailisunique_Internalname = "vUSEREMAILISUNIQUE";
         divTable_container_useremailisunique_Internalname = "TABLE_CONTAINER_USEREMAILISUNIQUE";
         cmbavUseractivationmethod_Internalname = "vUSERACTIVATIONMETHOD";
         divTable_container_useractivationmethod_Internalname = "TABLE_CONTAINER_USERACTIVATIONMETHOD";
         edtavUserautomaticactivationtimeout_Internalname = "vUSERAUTOMATICACTIVATIONTIMEOUT";
         divTable_container_userautomaticactivationtimeout_Internalname = "TABLE_CONTAINER_USERAUTOMATICACTIVATIONTIMEOUT";
         edtavUserrecoverypasswordkeytimeout_Internalname = "vUSERRECOVERYPASSWORDKEYTIMEOUT";
         divTable_container_userrecoverypasswordkeytimeout_Internalname = "TABLE_CONTAINER_USERRECOVERYPASSWORDKEYTIMEOUT";
         edtavLoginattemptstolockuser_Internalname = "vLOGINATTEMPTSTOLOCKUSER";
         divTable_container_loginattemptstolockuser_Internalname = "TABLE_CONTAINER_LOGINATTEMPTSTOLOCKUSER";
         edtavGamunblockusertimeout_Internalname = "vGAMUNBLOCKUSERTIMEOUT";
         divTable_container_gamunblockusertimeout_Internalname = "TABLE_CONTAINER_GAMUNBLOCKUSERTIMEOUT";
         cmbavUserremembermetype_Internalname = "vUSERREMEMBERMETYPE";
         divTable_container_userremembermetype_Internalname = "TABLE_CONTAINER_USERREMEMBERMETYPE";
         edtavUserremembermetimeout_Internalname = "vUSERREMEMBERMETIMEOUT";
         divTable_container_userremembermetimeout_Internalname = "TABLE_CONTAINER_USERREMEMBERMETIMEOUT";
         chkavRequiredemail_Internalname = "vREQUIREDEMAIL";
         divTable_container_requiredemail_Internalname = "TABLE_CONTAINER_REQUIREDEMAIL";
         chkavRequiredpassword_Internalname = "vREQUIREDPASSWORD";
         divTable_container_requiredpassword_Internalname = "TABLE_CONTAINER_REQUIREDPASSWORD";
         chkavRequiredfirstname_Internalname = "vREQUIREDFIRSTNAME";
         divTable_container_requiredfirstname_Internalname = "TABLE_CONTAINER_REQUIREDFIRSTNAME";
         chkavRequiredlastname_Internalname = "vREQUIREDLASTNAME";
         divTable_container_requiredlastname_Internalname = "TABLE_CONTAINER_REQUIREDLASTNAME";
         chkavRequiredbirthday_Internalname = "vREQUIREDBIRTHDAY";
         divTable_container_requiredbirthday_Internalname = "TABLE_CONTAINER_REQUIREDBIRTHDAY";
         chkavRequiredgender_Internalname = "vREQUIREDGENDER";
         divTable_container_requiredgender_Internalname = "TABLE_CONTAINER_REQUIREDGENDER";
         divMaintabresponsivetable_tab1_Internalname = "MAINTABRESPONSIVETABLE_TAB1";
         lblTab2_title_Internalname = "TAB2_TITLE";
         cmbavGeneratesessionstatistics_Internalname = "vGENERATESESSIONSTATISTICS";
         divTable_container_generatesessionstatistics_Internalname = "TABLE_CONTAINER_GENERATESESSIONSTATISTICS";
         edtavUsersessioncachetimeout_Internalname = "vUSERSESSIONCACHETIMEOUT";
         divTable_container_usersessioncachetimeout_Internalname = "TABLE_CONTAINER_USERSESSIONCACHETIMEOUT";
         chkavGiveanonymoussession_Internalname = "vGIVEANONYMOUSSESSION";
         divTable_container_giveanonymoussession_Internalname = "TABLE_CONTAINER_GIVEANONYMOUSSESSION";
         chkavSessionexpiresonipchange_Internalname = "vSESSIONEXPIRESONIPCHANGE";
         divTable_container_sessionexpiresonipchange_Internalname = "TABLE_CONTAINER_SESSIONEXPIRESONIPCHANGE";
         edtavLoginattemptstolocksession_Internalname = "vLOGINATTEMPTSTOLOCKSESSION";
         divTable_container_loginattemptstolocksession_Internalname = "TABLE_CONTAINER_LOGINATTEMPTSTOLOCKSESSION";
         edtavMinimumamountcharactersinlogin_Internalname = "vMINIMUMAMOUNTCHARACTERSINLOGIN";
         divTable_container_minimumamountcharactersinlogin_Internalname = "TABLE_CONTAINER_MINIMUMAMOUNTCHARACTERSINLOGIN";
         edtavRepositorycachetimeout_Internalname = "vREPOSITORYCACHETIMEOUT";
         divTable_container_repositorycachetimeout_Internalname = "TABLE_CONTAINER_REPOSITORYCACHETIMEOUT";
         divMaintabresponsivetable_tab2_Internalname = "MAINTABRESPONSIVETABLE_TAB2";
         lblTab3_title_Internalname = "TAB3_TITLE";
         edtavEmailserverhost_Internalname = "vEMAILSERVERHOST";
         divTable_container_emailserverhost_Internalname = "TABLE_CONTAINER_EMAILSERVERHOST";
         edtavEmailserverport_Internalname = "vEMAILSERVERPORT";
         divTable_container_emailserverport_Internalname = "TABLE_CONTAINER_EMAILSERVERPORT";
         edtavEmailservertimeout_Internalname = "vEMAILSERVERTIMEOUT";
         divTable_container_emailservertimeout_Internalname = "TABLE_CONTAINER_EMAILSERVERTIMEOUT";
         chkavEmailserversecure_Internalname = "vEMAILSERVERSECURE";
         divTable_container_emailserversecure_Internalname = "TABLE_CONTAINER_EMAILSERVERSECURE";
         edtavServersenderaddress_Internalname = "vSERVERSENDERADDRESS";
         divTable_container_serversenderaddress_Internalname = "TABLE_CONTAINER_SERVERSENDERADDRESS";
         edtavServersendername_Internalname = "vSERVERSENDERNAME";
         divTable_container_serversendername_Internalname = "TABLE_CONTAINER_SERVERSENDERNAME";
         chkavEmailserverusesauthentication_Internalname = "vEMAILSERVERUSESAUTHENTICATION";
         divTable_container_emailserverusesauthentication_Internalname = "TABLE_CONTAINER_EMAILSERVERUSESAUTHENTICATION";
         edtavEmailserverauthenticationusername_Internalname = "vEMAILSERVERAUTHENTICATIONUSERNAME";
         divTable_container_emailserverauthenticationusername_Internalname = "TABLE_CONTAINER_EMAILSERVERAUTHENTICATIONUSERNAME";
         edtavEmailserverauthenticationuserpassword_Internalname = "vEMAILSERVERAUTHENTICATIONUSERPASSWORD";
         divTable_container_emailserverauthenticationuserpassword_Internalname = "TABLE_CONTAINER_EMAILSERVERAUTHENTICATIONUSERPASSWORD";
         divAttributescontainertable_tblemailserveruseauthentication_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLEMAILSERVERUSEAUTHENTICATION";
         divTblemailserveruseauthentication_content_Internalname = "TBLEMAILSERVERUSEAUTHENTICATION_CONTENT";
         Tblemailserveruseauthentication_Internalname = "TBLEMAILSERVERUSEAUTHENTICATION";
         chkavEmailserver_sendemailwhenuseractivateaccount_Internalname = "vEMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT";
         divTable_container_emailserver_sendemailwhenuseractivateaccount_Internalname = "TABLE_CONTAINER_EMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT";
         edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname = "vEMAILSERVER_EMAILSUBJECTWHENUSERACTIVATEACCOUNT";
         divTable_container_emailserver_emailsubjectwhenuseractivateaccount_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILSUBJECTWHENUSERACTIVATEACCOUNT";
         edtavEmailserver_emailbodywhenuseractivateaccount_Internalname = "vEMAILSERVER_EMAILBODYWHENUSERACTIVATEACCOUNT";
         divTable_container_emailserver_emailbodywhenuseractivateaccount_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILBODYWHENUSERACTIVATEACCOUNT";
         divAttributescontainertable_tbluseractivateaccount_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLUSERACTIVATEACCOUNT";
         divTbluseractivateaccount_content_Internalname = "TBLUSERACTIVATEACCOUNT_CONTENT";
         Tbluseractivateaccount_Internalname = "TBLUSERACTIVATEACCOUNT";
         chkavEmailserver_sendemailwhenuserchangepassword_Internalname = "vEMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD";
         divTable_container_emailserver_sendemailwhenuserchangepassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD";
         edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname = "vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEPASSWORD";
         divTable_container_emailserver_emailsubjectwhenuserchangepassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILSUBJECTWHENUSERCHANGEPASSWORD";
         edtavEmailserver_emailbodywhenuserchangepassword_Internalname = "vEMAILSERVER_EMAILBODYWHENUSERCHANGEPASSWORD";
         divTable_container_emailserver_emailbodywhenuserchangepassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILBODYWHENUSERCHANGEPASSWORD";
         divAttributescontainertable_tbluserchangepassword_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLUSERCHANGEPASSWORD";
         divTbluserchangepassword_content_Internalname = "TBLUSERCHANGEPASSWORD_CONTENT";
         Tbluserchangepassword_Internalname = "TBLUSERCHANGEPASSWORD";
         chkavEmailserver_sendemailwhenuserchangeemail_Internalname = "vEMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL";
         divTable_container_emailserver_sendemailwhenuserchangeemail_Internalname = "TABLE_CONTAINER_EMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL";
         edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname = "vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEEMAIL";
         divTable_container_emailserver_emailsubjectwhenuserchangeemail_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILSUBJECTWHENUSERCHANGEEMAIL";
         edtavEmailserver_emailbodywhenuserchangeemail_Internalname = "vEMAILSERVER_EMAILBODYWHENUSERCHANGEEMAIL";
         divTable_container_emailserver_emailbodywhenuserchangeemail_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILBODYWHENUSERCHANGEEMAIL";
         divAttributescontainertable_tbluserchangeemail_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLUSERCHANGEEMAIL";
         divTbluserchangeemail_content_Internalname = "TBLUSERCHANGEEMAIL_CONTENT";
         Tbluserchangeemail_Internalname = "TBLUSERCHANGEEMAIL";
         chkavEmailserver_sendemailforrecoverypassword_Internalname = "vEMAILSERVER_SENDEMAILFORRECOVERYPASSWORD";
         divTable_container_emailserver_sendemailforrecoverypassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_SENDEMAILFORRECOVERYPASSWORD";
         edtavEmailserver_emailsubjectforrecoverypassword_Internalname = "vEMAILSERVER_EMAILSUBJECTFORRECOVERYPASSWORD";
         divTable_container_emailserver_emailsubjectforrecoverypassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILSUBJECTFORRECOVERYPASSWORD";
         edtavEmailserver_emailbodyforrecoverypassword_Internalname = "vEMAILSERVER_EMAILBODYFORRECOVERYPASSWORD";
         divTable_container_emailserver_emailbodyforrecoverypassword_Internalname = "TABLE_CONTAINER_EMAILSERVER_EMAILBODYFORRECOVERYPASSWORD";
         divAttributescontainertable_tbluserrecoverypassword_Internalname = "ATTRIBUTESCONTAINERTABLE_TBLUSERRECOVERYPASSWORD";
         divTbluserrecoverypassword_content_Internalname = "TBLUSERRECOVERYPASSWORD_CONTENT";
         Tbluserrecoverypassword_Internalname = "TBLUSERRECOVERYPASSWORD";
         divMaintabresponsivetable_tab3_Internalname = "MAINTABRESPONSIVETABLE_TAB3";
         Tabs_Internalname = "TABS";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divAttributes_content_Internalname = "ATTRIBUTES_CONTENT";
         Attributes_Internalname = "ATTRIBUTES";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavEmailserver_sendemailforrecoverypassword.Caption = "Send email for recovery password?";
         chkavEmailserver_sendemailwhenuserchangeemail.Caption = "Send email when user change email/username?";
         chkavEmailserver_sendemailwhenuserchangepassword.Caption = "Send email when user change password?";
         chkavEmailserver_sendemailwhenuseractivateaccount.Caption = "Send email when user activate account?";
         chkavEmailserverusesauthentication.Caption = "Server require authentication?";
         chkavEmailserversecure.Caption = "Secure";
         chkavSessionexpiresonipchange.Caption = "GAM Session expires on IP change";
         chkavGiveanonymoussession.Caption = "Give web anonymous sessions";
         chkavRequiredgender.Caption = "Required gender?";
         chkavRequiredbirthday.Caption = "Required birthday?";
         chkavRequiredlastname.Caption = "Required last name";
         chkavRequiredfirstname.Caption = "Required first name";
         chkavRequiredpassword.Caption = "Require password";
         chkavRequiredemail.Caption = "Require email";
         chkavUseremailisunique.Caption = "User email is unique";
         chkavEnableworkingasgammanagerrepo.Caption = "Enable working as GAMManager repository";
         chkavAllowoauthaccess.Caption = "Allow Oauth Access";
         edtavEmailserver_emailbodyforrecoverypassword_Enabled = 1;
         edtavEmailserver_emailsubjectforrecoverypassword_Jsonclick = "";
         edtavEmailserver_emailsubjectforrecoverypassword_Enabled = 1;
         chkavEmailserver_sendemailforrecoverypassword.Enabled = 1;
         edtavEmailserver_emailbodywhenuserchangeemail_Enabled = 1;
         edtavEmailserver_emailsubjectwhenuserchangeemail_Jsonclick = "";
         edtavEmailserver_emailsubjectwhenuserchangeemail_Enabled = 1;
         chkavEmailserver_sendemailwhenuserchangeemail.Enabled = 1;
         edtavEmailserver_emailbodywhenuserchangepassword_Enabled = 1;
         edtavEmailserver_emailsubjectwhenuserchangepassword_Jsonclick = "";
         edtavEmailserver_emailsubjectwhenuserchangepassword_Enabled = 1;
         chkavEmailserver_sendemailwhenuserchangepassword.Enabled = 1;
         edtavEmailserver_emailbodywhenuseractivateaccount_Enabled = 1;
         edtavEmailserver_emailsubjectwhenuseractivateaccount_Jsonclick = "";
         edtavEmailserver_emailsubjectwhenuseractivateaccount_Enabled = 1;
         chkavEmailserver_sendemailwhenuseractivateaccount.Enabled = 1;
         edtavEmailserverauthenticationuserpassword_Jsonclick = "";
         edtavEmailserverauthenticationuserpassword_Enabled = 1;
         edtavEmailserverauthenticationusername_Jsonclick = "";
         edtavEmailserverauthenticationusername_Enabled = 1;
         chkavEmailserverusesauthentication.Enabled = 1;
         edtavServersendername_Jsonclick = "";
         edtavServersendername_Enabled = 1;
         edtavServersenderaddress_Jsonclick = "";
         edtavServersenderaddress_Enabled = 1;
         chkavEmailserversecure.Enabled = 1;
         edtavEmailservertimeout_Jsonclick = "";
         edtavEmailservertimeout_Enabled = 1;
         edtavEmailserverport_Jsonclick = "";
         edtavEmailserverport_Enabled = 1;
         edtavEmailserverhost_Jsonclick = "";
         edtavEmailserverhost_Enabled = 1;
         edtavRepositorycachetimeout_Jsonclick = "";
         edtavRepositorycachetimeout_Enabled = 1;
         edtavMinimumamountcharactersinlogin_Jsonclick = "";
         edtavMinimumamountcharactersinlogin_Enabled = 1;
         edtavLoginattemptstolocksession_Jsonclick = "";
         edtavLoginattemptstolocksession_Enabled = 1;
         chkavSessionexpiresonipchange.Enabled = 1;
         chkavGiveanonymoussession.Enabled = 1;
         edtavUsersessioncachetimeout_Jsonclick = "";
         edtavUsersessioncachetimeout_Enabled = 1;
         cmbavGeneratesessionstatistics_Jsonclick = "";
         cmbavGeneratesessionstatistics.Enabled = 1;
         chkavRequiredgender.Enabled = 1;
         chkavRequiredbirthday.Enabled = 1;
         chkavRequiredlastname.Enabled = 1;
         chkavRequiredfirstname.Enabled = 1;
         chkavRequiredpassword.Enabled = 1;
         chkavRequiredemail.Enabled = 1;
         chkavRequiredemail.Visible = 1;
         edtavUserremembermetimeout_Jsonclick = "";
         edtavUserremembermetimeout_Enabled = 1;
         cmbavUserremembermetype_Jsonclick = "";
         cmbavUserremembermetype.Enabled = 1;
         edtavGamunblockusertimeout_Jsonclick = "";
         edtavGamunblockusertimeout_Enabled = 1;
         edtavLoginattemptstolockuser_Jsonclick = "";
         edtavLoginattemptstolockuser_Enabled = 1;
         edtavUserrecoverypasswordkeytimeout_Jsonclick = "";
         edtavUserrecoverypasswordkeytimeout_Enabled = 1;
         edtavUserautomaticactivationtimeout_Jsonclick = "";
         edtavUserautomaticactivationtimeout_Enabled = 1;
         cmbavUseractivationmethod_Jsonclick = "";
         cmbavUseractivationmethod.Enabled = 1;
         chkavUseremailisunique.Enabled = 1;
         chkavUseremailisunique.Visible = 1;
         cmbavUseridentification_Jsonclick = "";
         cmbavUseridentification.Enabled = 1;
         cmbavEnabletracing_Jsonclick = "";
         cmbavEnabletracing.Enabled = 1;
         chkavEnableworkingasgammanagerrepo.Enabled = 1;
         cmbavLogoutbehavior_Jsonclick = "";
         cmbavLogoutbehavior.Enabled = 1;
         chkavAllowoauthaccess.Enabled = 1;
         cmbavDefaultsecuritypolicyid_Jsonclick = "";
         cmbavDefaultsecuritypolicyid.Enabled = 1;
         cmbavDefaultsecuritypolicyid.Visible = 1;
         cmbavDefaultroleid_Jsonclick = "";
         cmbavDefaultroleid.Enabled = 1;
         cmbavDefaultroleid.Visible = 1;
         cmbavDefaultauthtypename_Jsonclick = "";
         cmbavDefaultauthtypename.Enabled = 1;
         cmbavDefaultauthtypename.Visible = 1;
         edtavAuthenticationmasterrepository_Jsonclick = "";
         edtavAuthenticationmasterrepository_Enabled = 1;
         divAttributescontainertable_tblmasterrepo_Class = "K2BT_NGA K2BToolsTable_TabularContentContainer";
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavNamespace_Jsonclick = "";
         edtavNamespace_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         Attributes_Containseditableform = Convert.ToBoolean( -1);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = "";
         Tabs_Historymanagement = Convert.ToBoolean( 0);
         Tabs_Class = "Tab";
         Tabs_Pagecount = 4;
         Tbluserrecoverypassword_Visible = Convert.ToBoolean( -1);
         Tbluserrecoverypassword_Containseditableform = Convert.ToBoolean( -1);
         Tbluserrecoverypassword_Showborders = Convert.ToBoolean( -1);
         Tbluserrecoverypassword_Open = Convert.ToBoolean( -1);
         Tbluserrecoverypassword_Collapsible = Convert.ToBoolean( 0);
         Tbluserrecoverypassword_Title = "";
         Tbluserchangeemail_Visible = Convert.ToBoolean( -1);
         Tbluserchangeemail_Containseditableform = Convert.ToBoolean( -1);
         Tbluserchangeemail_Showborders = Convert.ToBoolean( -1);
         Tbluserchangeemail_Open = Convert.ToBoolean( -1);
         Tbluserchangeemail_Collapsible = Convert.ToBoolean( 0);
         Tbluserchangeemail_Title = "";
         Tbluserchangepassword_Visible = Convert.ToBoolean( -1);
         Tbluserchangepassword_Containseditableform = Convert.ToBoolean( -1);
         Tbluserchangepassword_Showborders = Convert.ToBoolean( -1);
         Tbluserchangepassword_Open = Convert.ToBoolean( -1);
         Tbluserchangepassword_Collapsible = Convert.ToBoolean( 0);
         Tbluserchangepassword_Title = "";
         Tbluseractivateaccount_Visible = Convert.ToBoolean( -1);
         Tbluseractivateaccount_Containseditableform = Convert.ToBoolean( -1);
         Tbluseractivateaccount_Showborders = Convert.ToBoolean( -1);
         Tbluseractivateaccount_Open = Convert.ToBoolean( -1);
         Tbluseractivateaccount_Collapsible = Convert.ToBoolean( 0);
         Tbluseractivateaccount_Title = "";
         Tblemailserveruseauthentication_Visible = Convert.ToBoolean( -1);
         Tblemailserveruseauthentication_Containseditableform = Convert.ToBoolean( -1);
         Tblemailserveruseauthentication_Showborders = Convert.ToBoolean( -1);
         Tblemailserveruseauthentication_Open = Convert.ToBoolean( -1);
         Tblemailserveruseauthentication_Collapsible = Convert.ToBoolean( 0);
         Tblemailserveruseauthentication_Title = "";
         Tblenableworkinasmanager_Visible = Convert.ToBoolean( -1);
         Tblenableworkinasmanager_Containseditableform = Convert.ToBoolean( -1);
         Tblenableworkinasmanager_Showborders = Convert.ToBoolean( -1);
         Tblenableworkinasmanager_Open = Convert.ToBoolean( -1);
         Tblenableworkinasmanager_Collapsible = Convert.ToBoolean( 0);
         Tblenableworkinasmanager_Title = "";
         Tbldonthavemasterrepo_Visible = Convert.ToBoolean( -1);
         Tbldonthavemasterrepo_Containseditableform = Convert.ToBoolean( -1);
         Tbldonthavemasterrepo_Showborders = Convert.ToBoolean( -1);
         Tbldonthavemasterrepo_Open = Convert.ToBoolean( -1);
         Tbldonthavemasterrepo_Collapsible = Convert.ToBoolean( 0);
         Tbldonthavemasterrepo_Title = "";
         Tblmasterrepo_Visible = Convert.ToBoolean( -1);
         Tblmasterrepo_Containseditableform = Convert.ToBoolean( -1);
         Tblmasterrepo_Showborders = Convert.ToBoolean( -1);
         Tblmasterrepo_Open = Convert.ToBoolean( -1);
         Tblmasterrepo_Collapsible = Convert.ToBoolean( 0);
         Tblmasterrepo_Title = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Repository configuration";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'cmbavDefaultauthtypename'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'cmbavDefaultsecuritypolicyid'},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavDefaultroleid'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'cmbavUseridentification'},{av:'AV35UserIdentification',fld:'vUSERIDENTIFICATION',pic:''},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV57EnableWorkingAsGAMManagerRepo',fld:'vENABLEWORKINGASGAMMANAGERREPO',pic:''},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV58RequiredBirthday',fld:'vREQUIREDBIRTHDAY',pic:''},{av:'AV59RequiredGender',fld:'vREQUIREDGENDER',pic:''},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV64EmailServerSecure',fld:'vEMAILSERVERSECURE',pic:''},{av:'AV67EmailServerUsesAuthentication',fld:'vEMAILSERVERUSESAUTHENTICATION',pic:''},{av:'AV70EmailServer_SendEmailWhenUserActivateAccount',fld:'vEMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV73EmailServer_SendEmailWhenUserChangePassword',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD',pic:''},{av:'AV76EmailServer_SendEmailWhenUserChangeEmail',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL',pic:''},{av:'AV79EmailServer_SendEmailForRecoveryPassword',fld:'vEMAILSERVER_SENDEMAILFORRECOVERYPASSWORD',pic:''},{av:'AV14Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV87RepoId',fld:'vREPOID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'AV27Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDefaultauthtypename'},{av:'cmbavDefaultsecuritypolicyid'},{av:'cmbavDefaultroleid'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'AV87RepoId',fld:'vREPOID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV28GUID',fld:'vGUID',pic:''},{av:'AV29NameSpace',fld:'vNAMESPACE',pic:''},{av:'AV30Name',fld:'vNAME',pic:''},{av:'AV31Dsc',fld:'vDSC',pic:''},{av:'cmbavUseridentification'},{av:'AV35UserIdentification',fld:'vUSERIDENTIFICATION',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV41GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'cmbavUseractivationmethod'},{av:'AV36UserActivationMethod',fld:'vUSERACTIVATIONMETHOD',pic:''},{av:'AV37UserAutomaticActivationTimeout',fld:'vUSERAUTOMATICACTIVATIONTIMEOUT',pic:'ZZZ9'},{av:'cmbavUserremembermetype'},{av:'AV42UserRememberMeType',fld:'vUSERREMEMBERMETYPE',pic:''},{av:'AV43UserRememberMeTimeOut',fld:'vUSERREMEMBERMETIMEOUT',pic:'ZZZ9'},{av:'AV44UserRecoveryPasswordKeyTimeOut',fld:'vUSERRECOVERYPASSWORDKEYTIMEOUT',pic:'ZZZ9'},{av:'AV45MinimumAmountCharactersInLogin',fld:'vMINIMUMAMOUNTCHARACTERSINLOGIN',pic:'ZZZ9'},{av:'AV46LoginAttemptsToLockUser',fld:'vLOGINATTEMPTSTOLOCKUSER',pic:'ZZZ9'},{av:'AV47GAMUnblockUserTimeout',fld:'vGAMUNBLOCKUSERTIMEOUT',pic:'ZZZ9'},{av:'AV48LoginAttemptsToLockSession',fld:'vLOGINATTEMPTSTOLOCKSESSION',pic:'ZZZ9'},{av:'AV50UserSessionCacheTimeout',fld:'vUSERSESSIONCACHETIMEOUT',pic:'ZZZ9'},{av:'AV60RepositoryCacheTimeout',fld:'vREPOSITORYCACHETIMEOUT',pic:'ZZZZZ9'},{av:'cmbavLogoutbehavior'},{av:'AV85LogoutBehavior',fld:'vLOGOUTBEHAVIOR',pic:''},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'AV57EnableWorkingAsGAMManagerRepo',fld:'vENABLEWORKINGASGAMMANAGERREPO',pic:''},{av:'cmbavEnabletracing'},{av:'AV55EnableTracing',fld:'vENABLETRACING',pic:'ZZZ9'},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV58RequiredBirthday',fld:'vREQUIREDBIRTHDAY',pic:''},{av:'AV59RequiredGender',fld:'vREQUIREDGENDER',pic:''},{av:'Tblmasterrepo_Visible',ctrl:'TBLMASTERREPO',prop:'Visible'},{av:'Tblenableworkinasmanager_Visible',ctrl:'TBLENABLEWORKINASMANAGER',prop:'Visible'},{av:'Tbldonthavemasterrepo_Visible',ctrl:'TBLDONTHAVEMASTERREPO',prop:'Visible'},{av:'AV56AuthenticationMasterRepository',fld:'vAUTHENTICATIONMASTERREPOSITORY',pic:''},{av:'AV61EmailServerHost',fld:'vEMAILSERVERHOST',pic:''},{av:'AV62EmailServerPort',fld:'vEMAILSERVERPORT',pic:'ZZZ9'},{av:'AV64EmailServerSecure',fld:'vEMAILSERVERSECURE',pic:''},{av:'AV63EmailServerTimeout',fld:'vEMAILSERVERTIMEOUT',pic:'ZZZ9'},{av:'AV67EmailServerUsesAuthentication',fld:'vEMAILSERVERUSESAUTHENTICATION',pic:''},{av:'AV65ServerSenderAddress',fld:'vSERVERSENDERADDRESS',pic:''},{av:'AV66ServerSenderName',fld:'vSERVERSENDERNAME',pic:''},{av:'AV68EmailServerAuthenticationUsername',fld:'vEMAILSERVERAUTHENTICATIONUSERNAME',pic:''},{av:'AV69EmailServerAuthenticationUserPassword',fld:'vEMAILSERVERAUTHENTICATIONUSERPASSWORD',pic:''},{av:'Tblemailserveruseauthentication_Visible',ctrl:'TBLEMAILSERVERUSEAUTHENTICATION',prop:'Visible'},{av:'AV70EmailServer_SendEmailWhenUserActivateAccount',fld:'vEMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV71EmailServer_EmailSubjectWhenUserActivateAccount',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV72EmailServer_EmailBodyWhenUserActivateAccount',fld:'vEMAILSERVER_EMAILBODYWHENUSERACTIVATEACCOUNT',pic:''},{av:'Tbluseractivateaccount_Visible',ctrl:'TBLUSERACTIVATEACCOUNT',prop:'Visible'},{av:'AV73EmailServer_SendEmailWhenUserChangePassword',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD',pic:''},{av:'AV74EmailServer_EmailSubjectWhenUserChangePassword',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEPASSWORD',pic:''},{av:'AV75EmailServer_EmailBodyWhenUserChangePassword',fld:'vEMAILSERVER_EMAILBODYWHENUSERCHANGEPASSWORD',pic:''},{av:'Tbluserchangepassword_Visible',ctrl:'TBLUSERCHANGEPASSWORD',prop:'Visible'},{av:'AV76EmailServer_SendEmailWhenUserChangeEmail',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL',pic:''},{av:'AV77EmailServer_EmailSubjectWhenUserChangeEmail',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEEMAIL',pic:''},{av:'AV78EmailServer_EmailBodyWhenUserChangeEmail',fld:'vEMAILSERVER_EMAILBODYWHENUSERCHANGEEMAIL',pic:''},{av:'Tbluserchangeemail_Visible',ctrl:'TBLUSERCHANGEEMAIL',prop:'Visible'},{av:'AV79EmailServer_SendEmailForRecoveryPassword',fld:'vEMAILSERVER_SENDEMAILFORRECOVERYPASSWORD',pic:''},{av:'AV80EmailServer_EmailSubjectForRecoveryPassword',fld:'vEMAILSERVER_EMAILSUBJECTFORRECOVERYPASSWORD',pic:''},{av:'AV81EmailServer_EmailBodyForRecoveryPassword',fld:'vEMAILSERVER_EMAILBODYFORRECOVERYPASSWORD',pic:''},{av:'Tbluserrecoverypassword_Visible',ctrl:'TBLUSERRECOVERYPASSWORD',prop:'Visible'},{av:'chkavUseremailisunique.Visible',ctrl:'vUSEREMAILISUNIQUE',prop:'Visible'},{av:'chkavRequiredemail.Visible',ctrl:'vREQUIREDEMAIL',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E143B2',iparms:[{av:'AV87RepoId',fld:'vREPOID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV30Name',fld:'vNAME',pic:''},{av:'AV31Dsc',fld:'vDSC',pic:''},{av:'cmbavDefaultauthtypename'},{av:'AV32DefaultAuthTypeName',fld:'vDEFAULTAUTHTYPENAME',pic:''},{av:'cmbavUseridentification'},{av:'AV35UserIdentification',fld:'vUSERIDENTIFICATION',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV41GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'cmbavUseractivationmethod'},{av:'AV36UserActivationMethod',fld:'vUSERACTIVATIONMETHOD',pic:''},{av:'AV37UserAutomaticActivationTimeout',fld:'vUSERAUTOMATICACTIVATIONTIMEOUT',pic:'ZZZ9'},{av:'AV47GAMUnblockUserTimeout',fld:'vGAMUNBLOCKUSERTIMEOUT',pic:'ZZZ9'},{av:'cmbavUserremembermetype'},{av:'AV42UserRememberMeType',fld:'vUSERREMEMBERMETYPE',pic:''},{av:'AV43UserRememberMeTimeOut',fld:'vUSERREMEMBERMETIMEOUT',pic:'ZZZ9'},{av:'AV44UserRecoveryPasswordKeyTimeOut',fld:'vUSERRECOVERYPASSWORDKEYTIMEOUT',pic:'ZZZ9'},{av:'cmbavLogoutbehavior'},{av:'AV85LogoutBehavior',fld:'vLOGOUTBEHAVIOR',pic:''},{av:'AV45MinimumAmountCharactersInLogin',fld:'vMINIMUMAMOUNTCHARACTERSINLOGIN',pic:'ZZZ9'},{av:'AV46LoginAttemptsToLockUser',fld:'vLOGINATTEMPTSTOLOCKUSER',pic:'ZZZ9'},{av:'AV48LoginAttemptsToLockSession',fld:'vLOGINATTEMPTSTOLOCKSESSION',pic:'ZZZ9'},{av:'AV50UserSessionCacheTimeout',fld:'vUSERSESSIONCACHETIMEOUT',pic:'ZZZ9'},{av:'AV60RepositoryCacheTimeout',fld:'vREPOSITORYCACHETIMEOUT',pic:'ZZZZZ9'},{av:'AV18SecurityAdministratorEmail',fld:'vSECURITYADMINISTRATOREMAIL',pic:'',hsh:true},{av:'AV49GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV19CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:'',hsh:true},{av:'AV38UserEmailisUnique',fld:'vUSEREMAILISUNIQUE',pic:''},{av:'cmbavDefaultroleid'},{av:'AV52DefaultRoleId',fld:'vDEFAULTROLEID',pic:'ZZZZZZZZ9'},{av:'cmbavDefaultsecuritypolicyid'},{av:'AV51DefaultSecurityPolicyId',fld:'vDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZZZZ9'},{av:'AV57EnableWorkingAsGAMManagerRepo',fld:'vENABLEWORKINGASGAMMANAGERREPO',pic:''},{av:'cmbavEnabletracing'},{av:'AV55EnableTracing',fld:'vENABLETRACING',pic:'ZZZ9'},{av:'AV34AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV33SessionExpiresOnIPChange',fld:'vSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV40RequiredPassword',fld:'vREQUIREDPASSWORD',pic:''},{av:'AV39RequiredEmail',fld:'vREQUIREDEMAIL',pic:''},{av:'AV53RequiredFirstName',fld:'vREQUIREDFIRSTNAME',pic:''},{av:'AV54RequiredLastName',fld:'vREQUIREDLASTNAME',pic:''},{av:'AV58RequiredBirthday',fld:'vREQUIREDBIRTHDAY',pic:''},{av:'AV59RequiredGender',fld:'vREQUIREDGENDER',pic:''},{av:'AV61EmailServerHost',fld:'vEMAILSERVERHOST',pic:''},{av:'AV62EmailServerPort',fld:'vEMAILSERVERPORT',pic:'ZZZ9'},{av:'AV64EmailServerSecure',fld:'vEMAILSERVERSECURE',pic:''},{av:'AV63EmailServerTimeout',fld:'vEMAILSERVERTIMEOUT',pic:'ZZZ9'},{av:'AV67EmailServerUsesAuthentication',fld:'vEMAILSERVERUSESAUTHENTICATION',pic:''},{av:'AV65ServerSenderAddress',fld:'vSERVERSENDERADDRESS',pic:''},{av:'AV66ServerSenderName',fld:'vSERVERSENDERNAME',pic:''},{av:'AV68EmailServerAuthenticationUsername',fld:'vEMAILSERVERAUTHENTICATIONUSERNAME',pic:''},{av:'AV69EmailServerAuthenticationUserPassword',fld:'vEMAILSERVERAUTHENTICATIONUSERPASSWORD',pic:''},{av:'AV70EmailServer_SendEmailWhenUserActivateAccount',fld:'vEMAILSERVER_SENDEMAILWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV71EmailServer_EmailSubjectWhenUserActivateAccount',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV72EmailServer_EmailBodyWhenUserActivateAccount',fld:'vEMAILSERVER_EMAILBODYWHENUSERACTIVATEACCOUNT',pic:''},{av:'AV73EmailServer_SendEmailWhenUserChangePassword',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEPASSWORD',pic:''},{av:'AV74EmailServer_EmailSubjectWhenUserChangePassword',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEPASSWORD',pic:''},{av:'AV75EmailServer_EmailBodyWhenUserChangePassword',fld:'vEMAILSERVER_EMAILBODYWHENUSERCHANGEPASSWORD',pic:''},{av:'AV76EmailServer_SendEmailWhenUserChangeEmail',fld:'vEMAILSERVER_SENDEMAILWHENUSERCHANGEEMAIL',pic:''},{av:'AV77EmailServer_EmailSubjectWhenUserChangeEmail',fld:'vEMAILSERVER_EMAILSUBJECTWHENUSERCHANGEEMAIL',pic:''},{av:'AV78EmailServer_EmailBodyWhenUserChangeEmail',fld:'vEMAILSERVER_EMAILBODYWHENUSERCHANGEEMAIL',pic:''},{av:'AV79EmailServer_SendEmailForRecoveryPassword',fld:'vEMAILSERVER_SENDEMAILFORRECOVERYPASSWORD',pic:''},{av:'AV80EmailServer_EmailSubjectForRecoveryPassword',fld:'vEMAILSERVER_EMAILSUBJECTFORRECOVERYPASSWORD',pic:''},{av:'AV81EmailServer_EmailBodyForRecoveryPassword',fld:'vEMAILSERVER_EMAILBODYFORRECOVERYPASSWORD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E113B1',iparms:[]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("VALIDV_LOGOUTBEHAVIOR","{handler:'Validv_Logoutbehavior',iparms:[]");
         setEventMetadata("VALIDV_LOGOUTBEHAVIOR",",oparms:[]}");
         setEventMetadata("VALIDV_ENABLETRACING","{handler:'Validv_Enabletracing',iparms:[]");
         setEventMetadata("VALIDV_ENABLETRACING",",oparms:[]}");
         setEventMetadata("VALIDV_USERIDENTIFICATION","{handler:'Validv_Useridentification',iparms:[]");
         setEventMetadata("VALIDV_USERIDENTIFICATION",",oparms:[]}");
         setEventMetadata("VALIDV_USERACTIVATIONMETHOD","{handler:'Validv_Useractivationmethod',iparms:[]");
         setEventMetadata("VALIDV_USERACTIVATIONMETHOD",",oparms:[]}");
         setEventMetadata("VALIDV_USERREMEMBERMETYPE","{handler:'Validv_Userremembermetype',iparms:[]");
         setEventMetadata("VALIDV_USERREMEMBERMETYPE",",oparms:[]}");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS","{handler:'Validv_Generatesessionstatistics',iparms:[]");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV14Language = "";
         AV18SecurityAdministratorEmail = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         ucAttributes = new GXUserControl();
         ucTabs = new GXUserControl();
         lblTab_title_Jsonclick = "";
         TempTags = "";
         AV28GUID = "";
         AV29NameSpace = "";
         AV30Name = "";
         AV31Dsc = "";
         ucTblmasterrepo = new GXUserControl();
         AV56AuthenticationMasterRepository = "";
         ucTbldonthavemasterrepo = new GXUserControl();
         AV32DefaultAuthTypeName = "";
         AV85LogoutBehavior = "";
         ucTblenableworkinasmanager = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         AV35UserIdentification = "";
         AV36UserActivationMethod = "";
         AV42UserRememberMeType = "";
         lblTab2_title_Jsonclick = "";
         AV41GenerateSessionStatistics = "";
         lblTab3_title_Jsonclick = "";
         AV61EmailServerHost = "";
         AV65ServerSenderAddress = "";
         AV66ServerSenderName = "";
         ucTblemailserveruseauthentication = new GXUserControl();
         AV68EmailServerAuthenticationUsername = "";
         AV69EmailServerAuthenticationUserPassword = "";
         ucTbluseractivateaccount = new GXUserControl();
         AV71EmailServer_EmailSubjectWhenUserActivateAccount = "";
         AV72EmailServer_EmailBodyWhenUserActivateAccount = "";
         ucTbluserchangepassword = new GXUserControl();
         AV74EmailServer_EmailSubjectWhenUserChangePassword = "";
         AV75EmailServer_EmailBodyWhenUserChangePassword = "";
         ucTbluserchangeemail = new GXUserControl();
         AV77EmailServer_EmailSubjectWhenUserChangeEmail = "";
         AV78EmailServer_EmailBodyWhenUserChangeEmail = "";
         ucTbluserrecoverypassword = new GXUserControl();
         AV80EmailServer_EmailSubjectForRecoveryPassword = "";
         AV81EmailServer_EmailBodyForRecoveryPassword = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV15AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV5AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV7SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV16FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV8SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV17FilterRole = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV9Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV11Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV82RepositoryCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepository", "GeneXus.Programs");
         AV84Filter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter(context);
         AV83GAMRepositoryItem = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.repositoryconfiguration__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavNamespace_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV55EnableTracing ;
      private short AV37UserAutomaticActivationTimeout ;
      private short AV44UserRecoveryPasswordKeyTimeOut ;
      private short AV46LoginAttemptsToLockUser ;
      private short AV47GAMUnblockUserTimeout ;
      private short AV43UserRememberMeTimeOut ;
      private short AV50UserSessionCacheTimeout ;
      private short AV48LoginAttemptsToLockSession ;
      private short AV45MinimumAmountCharactersInLogin ;
      private short AV62EmailServerPort ;
      private short AV63EmailServerTimeout ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavNamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavAuthenticationmasterrepository_Enabled ;
      private int AV52DefaultRoleId ;
      private int edtavUserautomaticactivationtimeout_Enabled ;
      private int edtavUserrecoverypasswordkeytimeout_Enabled ;
      private int edtavLoginattemptstolockuser_Enabled ;
      private int edtavGamunblockusertimeout_Enabled ;
      private int edtavUserremembermetimeout_Enabled ;
      private int edtavUsersessioncachetimeout_Enabled ;
      private int edtavLoginattemptstolocksession_Enabled ;
      private int edtavMinimumamountcharactersinlogin_Enabled ;
      private int AV60RepositoryCacheTimeout ;
      private int edtavRepositorycachetimeout_Enabled ;
      private int edtavEmailserverhost_Enabled ;
      private int edtavEmailserverport_Enabled ;
      private int edtavEmailservertimeout_Enabled ;
      private int edtavServersenderaddress_Enabled ;
      private int edtavServersendername_Enabled ;
      private int edtavEmailserverauthenticationusername_Enabled ;
      private int edtavEmailserverauthenticationuserpassword_Enabled ;
      private int edtavEmailserver_emailsubjectwhenuseractivateaccount_Enabled ;
      private int edtavEmailserver_emailbodywhenuseractivateaccount_Enabled ;
      private int edtavEmailserver_emailsubjectwhenuserchangepassword_Enabled ;
      private int edtavEmailserver_emailbodywhenuserchangepassword_Enabled ;
      private int edtavEmailserver_emailsubjectwhenuserchangeemail_Enabled ;
      private int edtavEmailserver_emailbodywhenuserchangeemail_Enabled ;
      private int edtavEmailserver_emailsubjectforrecoverypassword_Enabled ;
      private int edtavEmailserver_emailbodyforrecoverypassword_Enabled ;
      private int AV88GXV1 ;
      private int AV89GXV2 ;
      private int AV90GXV3 ;
      private int AV91GXV4 ;
      private int AV92GXV5 ;
      private int idxLst ;
      private long AV27Id ;
      private long wcpOAV27Id ;
      private long AV87RepoId ;
      private long AV51DefaultSecurityPolicyId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV14Language ;
      private string GXKey ;
      private string Tblmasterrepo_Title ;
      private string Tbldonthavemasterrepo_Title ;
      private string Tblenableworkinasmanager_Title ;
      private string Tblemailserveruseauthentication_Title ;
      private string Tbluseractivateaccount_Title ;
      private string Tbluserchangepassword_Title ;
      private string Tbluserchangeemail_Title ;
      private string Tbluserrecoverypassword_Title ;
      private string Tabs_Class ;
      private string Attributes_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Attributes_Internalname ;
      private string divAttributes_content_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string Tabs_Internalname ;
      private string lblTab_title_Internalname ;
      private string lblTab_title_Jsonclick ;
      private string divMaintabresponsivetable_tab_Internalname ;
      private string divTable_container_id_Internalname ;
      private string edtavId_Internalname ;
      private string edtavId_Jsonclick ;
      private string divTable_container_guid_Internalname ;
      private string edtavGuid_Internalname ;
      private string TempTags ;
      private string AV28GUID ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_namespace_Internalname ;
      private string edtavNamespace_Internalname ;
      private string AV29NameSpace ;
      private string edtavNamespace_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV30Name ;
      private string edtavName_Jsonclick ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV31Dsc ;
      private string edtavDsc_Jsonclick ;
      private string Tblmasterrepo_Internalname ;
      private string divTblmasterrepo_content_Internalname ;
      private string divAttributescontainertable_tblmasterrepo_Internalname ;
      private string divAttributescontainertable_tblmasterrepo_Class ;
      private string divTable_container_authenticationmasterrepository_Internalname ;
      private string edtavAuthenticationmasterrepository_Internalname ;
      private string AV56AuthenticationMasterRepository ;
      private string edtavAuthenticationmasterrepository_Jsonclick ;
      private string Tbldonthavemasterrepo_Internalname ;
      private string divTbldonthavemasterrepo_content_Internalname ;
      private string divAttributescontainertable_tbldonthavemasterrepo_Internalname ;
      private string divTable_container_defaultauthtypename_Internalname ;
      private string cmbavDefaultauthtypename_Internalname ;
      private string AV32DefaultAuthTypeName ;
      private string cmbavDefaultauthtypename_Jsonclick ;
      private string divTable_container_defaultroleid_Internalname ;
      private string cmbavDefaultroleid_Internalname ;
      private string cmbavDefaultroleid_Jsonclick ;
      private string divTable_container_defaultsecuritypolicyid_Internalname ;
      private string cmbavDefaultsecuritypolicyid_Internalname ;
      private string cmbavDefaultsecuritypolicyid_Jsonclick ;
      private string divTable_container_allowoauthaccess_Internalname ;
      private string chkavAllowoauthaccess_Internalname ;
      private string divTable_container_logoutbehavior_Internalname ;
      private string cmbavLogoutbehavior_Internalname ;
      private string AV85LogoutBehavior ;
      private string cmbavLogoutbehavior_Jsonclick ;
      private string Tblenableworkinasmanager_Internalname ;
      private string divTblenableworkinasmanager_content_Internalname ;
      private string divAttributescontainertable_tblenableworkinasmanager_Internalname ;
      private string divTable_container_enableworkingasgammanagerrepo_Internalname ;
      private string chkavEnableworkingasgammanagerrepo_Internalname ;
      private string divTable_container_enabletracing_Internalname ;
      private string cmbavEnabletracing_Internalname ;
      private string cmbavEnabletracing_Jsonclick ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divMaintabresponsivetable_tab1_Internalname ;
      private string divTable_container_useridentification_Internalname ;
      private string cmbavUseridentification_Internalname ;
      private string AV35UserIdentification ;
      private string cmbavUseridentification_Jsonclick ;
      private string divTable_container_useremailisunique_Internalname ;
      private string chkavUseremailisunique_Internalname ;
      private string divTable_container_useractivationmethod_Internalname ;
      private string cmbavUseractivationmethod_Internalname ;
      private string AV36UserActivationMethod ;
      private string cmbavUseractivationmethod_Jsonclick ;
      private string divTable_container_userautomaticactivationtimeout_Internalname ;
      private string edtavUserautomaticactivationtimeout_Internalname ;
      private string edtavUserautomaticactivationtimeout_Jsonclick ;
      private string divTable_container_userrecoverypasswordkeytimeout_Internalname ;
      private string edtavUserrecoverypasswordkeytimeout_Internalname ;
      private string edtavUserrecoverypasswordkeytimeout_Jsonclick ;
      private string divTable_container_loginattemptstolockuser_Internalname ;
      private string edtavLoginattemptstolockuser_Internalname ;
      private string edtavLoginattemptstolockuser_Jsonclick ;
      private string divTable_container_gamunblockusertimeout_Internalname ;
      private string edtavGamunblockusertimeout_Internalname ;
      private string edtavGamunblockusertimeout_Jsonclick ;
      private string divTable_container_userremembermetype_Internalname ;
      private string cmbavUserremembermetype_Internalname ;
      private string AV42UserRememberMeType ;
      private string cmbavUserremembermetype_Jsonclick ;
      private string divTable_container_userremembermetimeout_Internalname ;
      private string edtavUserremembermetimeout_Internalname ;
      private string edtavUserremembermetimeout_Jsonclick ;
      private string divTable_container_requiredemail_Internalname ;
      private string chkavRequiredemail_Internalname ;
      private string divTable_container_requiredpassword_Internalname ;
      private string chkavRequiredpassword_Internalname ;
      private string divTable_container_requiredfirstname_Internalname ;
      private string chkavRequiredfirstname_Internalname ;
      private string divTable_container_requiredlastname_Internalname ;
      private string chkavRequiredlastname_Internalname ;
      private string divTable_container_requiredbirthday_Internalname ;
      private string chkavRequiredbirthday_Internalname ;
      private string divTable_container_requiredgender_Internalname ;
      private string chkavRequiredgender_Internalname ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divMaintabresponsivetable_tab2_Internalname ;
      private string divTable_container_generatesessionstatistics_Internalname ;
      private string cmbavGeneratesessionstatistics_Internalname ;
      private string AV41GenerateSessionStatistics ;
      private string cmbavGeneratesessionstatistics_Jsonclick ;
      private string divTable_container_usersessioncachetimeout_Internalname ;
      private string edtavUsersessioncachetimeout_Internalname ;
      private string edtavUsersessioncachetimeout_Jsonclick ;
      private string divTable_container_giveanonymoussession_Internalname ;
      private string chkavGiveanonymoussession_Internalname ;
      private string divTable_container_sessionexpiresonipchange_Internalname ;
      private string chkavSessionexpiresonipchange_Internalname ;
      private string divTable_container_loginattemptstolocksession_Internalname ;
      private string edtavLoginattemptstolocksession_Internalname ;
      private string edtavLoginattemptstolocksession_Jsonclick ;
      private string divTable_container_minimumamountcharactersinlogin_Internalname ;
      private string edtavMinimumamountcharactersinlogin_Internalname ;
      private string edtavMinimumamountcharactersinlogin_Jsonclick ;
      private string divTable_container_repositorycachetimeout_Internalname ;
      private string edtavRepositorycachetimeout_Internalname ;
      private string edtavRepositorycachetimeout_Jsonclick ;
      private string lblTab3_title_Internalname ;
      private string lblTab3_title_Jsonclick ;
      private string divMaintabresponsivetable_tab3_Internalname ;
      private string divTable_container_emailserverhost_Internalname ;
      private string edtavEmailserverhost_Internalname ;
      private string AV61EmailServerHost ;
      private string edtavEmailserverhost_Jsonclick ;
      private string divTable_container_emailserverport_Internalname ;
      private string edtavEmailserverport_Internalname ;
      private string edtavEmailserverport_Jsonclick ;
      private string divTable_container_emailservertimeout_Internalname ;
      private string edtavEmailservertimeout_Internalname ;
      private string edtavEmailservertimeout_Jsonclick ;
      private string divTable_container_emailserversecure_Internalname ;
      private string chkavEmailserversecure_Internalname ;
      private string divTable_container_serversenderaddress_Internalname ;
      private string edtavServersenderaddress_Internalname ;
      private string edtavServersenderaddress_Jsonclick ;
      private string divTable_container_serversendername_Internalname ;
      private string edtavServersendername_Internalname ;
      private string AV66ServerSenderName ;
      private string edtavServersendername_Jsonclick ;
      private string divTable_container_emailserverusesauthentication_Internalname ;
      private string chkavEmailserverusesauthentication_Internalname ;
      private string Tblemailserveruseauthentication_Internalname ;
      private string divTblemailserveruseauthentication_content_Internalname ;
      private string divAttributescontainertable_tblemailserveruseauthentication_Internalname ;
      private string divTable_container_emailserverauthenticationusername_Internalname ;
      private string edtavEmailserverauthenticationusername_Internalname ;
      private string AV68EmailServerAuthenticationUsername ;
      private string edtavEmailserverauthenticationusername_Jsonclick ;
      private string divTable_container_emailserverauthenticationuserpassword_Internalname ;
      private string edtavEmailserverauthenticationuserpassword_Internalname ;
      private string AV69EmailServerAuthenticationUserPassword ;
      private string edtavEmailserverauthenticationuserpassword_Jsonclick ;
      private string divTable_container_emailserver_sendemailwhenuseractivateaccount_Internalname ;
      private string chkavEmailserver_sendemailwhenuseractivateaccount_Internalname ;
      private string Tbluseractivateaccount_Internalname ;
      private string divTbluseractivateaccount_content_Internalname ;
      private string divAttributescontainertable_tbluseractivateaccount_Internalname ;
      private string divTable_container_emailserver_emailsubjectwhenuseractivateaccount_Internalname ;
      private string edtavEmailserver_emailsubjectwhenuseractivateaccount_Internalname ;
      private string AV71EmailServer_EmailSubjectWhenUserActivateAccount ;
      private string edtavEmailserver_emailsubjectwhenuseractivateaccount_Jsonclick ;
      private string divTable_container_emailserver_emailbodywhenuseractivateaccount_Internalname ;
      private string edtavEmailserver_emailbodywhenuseractivateaccount_Internalname ;
      private string divTable_container_emailserver_sendemailwhenuserchangepassword_Internalname ;
      private string chkavEmailserver_sendemailwhenuserchangepassword_Internalname ;
      private string Tbluserchangepassword_Internalname ;
      private string divTbluserchangepassword_content_Internalname ;
      private string divAttributescontainertable_tbluserchangepassword_Internalname ;
      private string divTable_container_emailserver_emailsubjectwhenuserchangepassword_Internalname ;
      private string edtavEmailserver_emailsubjectwhenuserchangepassword_Internalname ;
      private string AV74EmailServer_EmailSubjectWhenUserChangePassword ;
      private string edtavEmailserver_emailsubjectwhenuserchangepassword_Jsonclick ;
      private string divTable_container_emailserver_emailbodywhenuserchangepassword_Internalname ;
      private string edtavEmailserver_emailbodywhenuserchangepassword_Internalname ;
      private string divTable_container_emailserver_sendemailwhenuserchangeemail_Internalname ;
      private string chkavEmailserver_sendemailwhenuserchangeemail_Internalname ;
      private string Tbluserchangeemail_Internalname ;
      private string divTbluserchangeemail_content_Internalname ;
      private string divAttributescontainertable_tbluserchangeemail_Internalname ;
      private string divTable_container_emailserver_emailsubjectwhenuserchangeemail_Internalname ;
      private string edtavEmailserver_emailsubjectwhenuserchangeemail_Internalname ;
      private string AV77EmailServer_EmailSubjectWhenUserChangeEmail ;
      private string edtavEmailserver_emailsubjectwhenuserchangeemail_Jsonclick ;
      private string divTable_container_emailserver_emailbodywhenuserchangeemail_Internalname ;
      private string edtavEmailserver_emailbodywhenuserchangeemail_Internalname ;
      private string divTable_container_emailserver_sendemailforrecoverypassword_Internalname ;
      private string chkavEmailserver_sendemailforrecoverypassword_Internalname ;
      private string Tbluserrecoverypassword_Internalname ;
      private string divTbluserrecoverypassword_content_Internalname ;
      private string divAttributescontainertable_tbluserrecoverypassword_Internalname ;
      private string divTable_container_emailserver_emailsubjectforrecoverypassword_Internalname ;
      private string edtavEmailserver_emailsubjectforrecoverypassword_Internalname ;
      private string AV80EmailServer_EmailSubjectForRecoveryPassword ;
      private string edtavEmailserver_emailsubjectforrecoverypassword_Jsonclick ;
      private string divTable_container_emailserver_emailbodyforrecoverypassword_Internalname ;
      private string edtavEmailserver_emailbodyforrecoverypassword_Internalname ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19CanRegisterUsers ;
      private bool Tblmasterrepo_Collapsible ;
      private bool Tblmasterrepo_Open ;
      private bool Tblmasterrepo_Showborders ;
      private bool Tblmasterrepo_Containseditableform ;
      private bool Tblmasterrepo_Visible ;
      private bool Tbldonthavemasterrepo_Collapsible ;
      private bool Tbldonthavemasterrepo_Open ;
      private bool Tbldonthavemasterrepo_Showborders ;
      private bool Tbldonthavemasterrepo_Containseditableform ;
      private bool Tbldonthavemasterrepo_Visible ;
      private bool Tblenableworkinasmanager_Collapsible ;
      private bool Tblenableworkinasmanager_Open ;
      private bool Tblenableworkinasmanager_Showborders ;
      private bool Tblenableworkinasmanager_Containseditableform ;
      private bool Tblenableworkinasmanager_Visible ;
      private bool Tblemailserveruseauthentication_Collapsible ;
      private bool Tblemailserveruseauthentication_Open ;
      private bool Tblemailserveruseauthentication_Showborders ;
      private bool Tblemailserveruseauthentication_Containseditableform ;
      private bool Tblemailserveruseauthentication_Visible ;
      private bool Tbluseractivateaccount_Collapsible ;
      private bool Tbluseractivateaccount_Open ;
      private bool Tbluseractivateaccount_Showborders ;
      private bool Tbluseractivateaccount_Containseditableform ;
      private bool Tbluseractivateaccount_Visible ;
      private bool Tbluserchangepassword_Collapsible ;
      private bool Tbluserchangepassword_Open ;
      private bool Tbluserchangepassword_Showborders ;
      private bool Tbluserchangepassword_Containseditableform ;
      private bool Tbluserchangepassword_Visible ;
      private bool Tbluserchangeemail_Collapsible ;
      private bool Tbluserchangeemail_Open ;
      private bool Tbluserchangeemail_Showborders ;
      private bool Tbluserchangeemail_Containseditableform ;
      private bool Tbluserchangeemail_Visible ;
      private bool Tbluserrecoverypassword_Collapsible ;
      private bool Tbluserrecoverypassword_Open ;
      private bool Tbluserrecoverypassword_Showborders ;
      private bool Tbluserrecoverypassword_Containseditableform ;
      private bool Tbluserrecoverypassword_Visible ;
      private bool Tabs_Historymanagement ;
      private bool Attributes_Collapsible ;
      private bool Attributes_Open ;
      private bool Attributes_Showborders ;
      private bool Attributes_Containseditableform ;
      private bool wbLoad ;
      private bool AV34AllowOauthAccess ;
      private bool AV57EnableWorkingAsGAMManagerRepo ;
      private bool AV38UserEmailisUnique ;
      private bool AV39RequiredEmail ;
      private bool AV40RequiredPassword ;
      private bool AV53RequiredFirstName ;
      private bool AV54RequiredLastName ;
      private bool AV58RequiredBirthday ;
      private bool AV59RequiredGender ;
      private bool AV49GiveAnonymousSession ;
      private bool AV33SessionExpiresOnIPChange ;
      private bool AV64EmailServerSecure ;
      private bool AV67EmailServerUsesAuthentication ;
      private bool AV70EmailServer_SendEmailWhenUserActivateAccount ;
      private bool AV73EmailServer_SendEmailWhenUserChangePassword ;
      private bool AV76EmailServer_SendEmailWhenUserChangeEmail ;
      private bool AV79EmailServer_SendEmailForRecoveryPassword ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV86isLoginRepositoryAdm ;
      private string AV18SecurityAdministratorEmail ;
      private string AV65ServerSenderAddress ;
      private string AV72EmailServer_EmailBodyWhenUserActivateAccount ;
      private string AV75EmailServer_EmailBodyWhenUserChangePassword ;
      private string AV78EmailServer_EmailBodyWhenUserChangeEmail ;
      private string AV81EmailServer_EmailBodyForRecoveryPassword ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucTabs ;
      private GXUserControl ucTblmasterrepo ;
      private GXUserControl ucTbldonthavemasterrepo ;
      private GXUserControl ucTblenableworkinasmanager ;
      private GXUserControl ucTblemailserveruseauthentication ;
      private GXUserControl ucTbluseractivateaccount ;
      private GXUserControl ucTbluserchangepassword ;
      private GXUserControl ucTbluserchangeemail ;
      private GXUserControl ucTbluserrecoverypassword ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_Id ;
      private GXCombobox cmbavDefaultauthtypename ;
      private GXCombobox cmbavDefaultroleid ;
      private GXCombobox cmbavDefaultsecuritypolicyid ;
      private GXCheckbox chkavAllowoauthaccess ;
      private GXCombobox cmbavLogoutbehavior ;
      private GXCheckbox chkavEnableworkingasgammanagerrepo ;
      private GXCombobox cmbavEnabletracing ;
      private GXCombobox cmbavUseridentification ;
      private GXCheckbox chkavUseremailisunique ;
      private GXCombobox cmbavUseractivationmethod ;
      private GXCombobox cmbavUserremembermetype ;
      private GXCheckbox chkavRequiredemail ;
      private GXCheckbox chkavRequiredpassword ;
      private GXCheckbox chkavRequiredfirstname ;
      private GXCheckbox chkavRequiredlastname ;
      private GXCheckbox chkavRequiredbirthday ;
      private GXCheckbox chkavRequiredgender ;
      private GXCombobox cmbavGeneratesessionstatistics ;
      private GXCheckbox chkavGiveanonymoussession ;
      private GXCheckbox chkavSessionexpiresonipchange ;
      private GXCheckbox chkavEmailserversecure ;
      private GXCheckbox chkavEmailserverusesauthentication ;
      private GXCheckbox chkavEmailserver_sendemailwhenuseractivateaccount ;
      private GXCheckbox chkavEmailserver_sendemailwhenuserchangepassword ;
      private GXCheckbox chkavEmailserver_sendemailwhenuserchangeemail ;
      private GXCheckbox chkavEmailserver_sendemailforrecoverypassword ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV15AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV6Roles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV7SecurityPolicies ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository> AV82RepositoryCollection ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV5AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV9Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV17FilterRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV8SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV11Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV83GAMRepositoryItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV16FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter AV84Filter ;
   }

   public class repositoryconfiguration__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class repositoryconfiguration__default : DataStoreHelperBase, IDataStoreHelper
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
