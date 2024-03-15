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
   public class wcauthenticationtypeentryoauth20 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcauthenticationtypeentryoauth20( )
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

      public wcauthenticationtypeentryoauth20( IGxContext context )
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
         this.AV43Name = aP1_Name;
         this.AV103TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV43Name;
         aP2_TypeId=this.AV103TypeId;
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
         chkavOauth20redirecturliscustom = new GXCheckbox();
         chkavOauth20redirecttoauthenticate = new GXCheckbox();
         chkavAuthresptypeinclude = new GXCheckbox();
         chkavAuthscopeinclude = new GXCheckbox();
         chkavAuthstateincude = new GXCheckbox();
         chkavAuthclientidinclude = new GXCheckbox();
         chkavAuthclientsecretinclude = new GXCheckbox();
         chkavAuthredirurlinclide = new GXCheckbox();
         chkavAuthopenidconnectprotocolenable = new GXCheckbox();
         chkavAuthvalididtoken = new GXCheckbox();
         chkavAuthallowonlyuseremailverified = new GXCheckbox();
         cmbavTokenmethod = new GXCombobox();
         chkavTokenheaderauthenticationinclude = new GXCheckbox();
         cmbavTokenheaderauthenticationmethod = new GXCombobox();
         chkavTokenheaderauthorizationbasicinclude = new GXCheckbox();
         chkavTokengranttypeinclude = new GXCheckbox();
         chkavTokenaccesscodeinclude = new GXCheckbox();
         chkavTokencliidinclude = new GXCheckbox();
         chkavTokenclisecretinclude = new GXCheckbox();
         chkavTokenredirecturlinclude = new GXCheckbox();
         chkavAutovalidateexternaltokenandrefresh = new GXCheckbox();
         cmbavUserinfomethod = new GXCombobox();
         chkavUserinfoaccesstokeninclude = new GXCheckbox();
         chkavUserinfoclientidinclude = new GXCheckbox();
         chkavUserinfoclientsecretinclude = new GXCheckbox();
         chkavUserinfouseridinclude = new GXCheckbox();
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
                  AV43Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV43Name", AV43Name);
                  AV103TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV103TypeId", AV103TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV43Name,(string)AV103TypeId});
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
         nRC_GXsfl_602 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_602"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_602_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_602_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_602_idx = GetPar( "sGXsfl_602_idx");
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
         AV25CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV120Pgmname = GetPar( "Pgmname");
         AV39I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         AV41IsEnable = StringUtil.StrToBool( GetPar( "IsEnable"));
         AV104Oauth20RedirectURLisCustom = StringUtil.StrToBool( GetPar( "Oauth20RedirectURLisCustom"));
         AV105Oauth20RedirectToAuthenticate = StringUtil.StrToBool( GetPar( "Oauth20RedirectToAuthenticate"));
         AV16AuthRespTypeInclude = StringUtil.StrToBool( GetPar( "AuthRespTypeInclude"));
         AV19AuthScopeInclude = StringUtil.StrToBool( GetPar( "AuthScopeInclude"));
         AV110AuthStateIncude = StringUtil.StrToBool( GetPar( "AuthStateIncude"));
         AV9AuthClientIdInclude = StringUtil.StrToBool( GetPar( "AuthClientIdInclude"));
         AV10AuthClientSecretInclude = StringUtil.StrToBool( GetPar( "AuthClientSecretInclude"));
         AV13AuthRedirURLInclide = StringUtil.StrToBool( GetPar( "AuthRedirURLInclide"));
         AV111AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( GetPar( "AuthOpenIDConnectProtocolEnable"));
         AV112AuthValidIdToken = StringUtil.StrToBool( GetPar( "AuthValidIdToken"));
         AV115AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( GetPar( "AuthAllowOnlyUserEmailVerified"));
         AV106TokenHeaderAuthenticationInclude = StringUtil.StrToBool( GetPar( "TokenHeaderAuthenticationInclude"));
         AV109TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( GetPar( "TokenHeaderAuthorizationBasicInclude"));
         AV57TokenGrantTypeInclude = StringUtil.StrToBool( GetPar( "TokenGrantTypeInclude"));
         AV53TokenAccessCodeInclude = StringUtil.StrToBool( GetPar( "TokenAccessCodeInclude"));
         AV55TokenCliIdInclude = StringUtil.StrToBool( GetPar( "TokenCliIdInclude"));
         AV56TokenCliSecretInclude = StringUtil.StrToBool( GetPar( "TokenCliSecretInclude"));
         AV63TokenRedirectURLInclude = StringUtil.StrToBool( GetPar( "TokenRedirectURLInclude"));
         AV23AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( GetPar( "AutovalidateExternalTokenAndRefresh"));
         AV75UserInfoAccessTokenInclude = StringUtil.StrToBool( GetPar( "UserInfoAccessTokenInclude"));
         AV78UserInfoClientIdInclude = StringUtil.StrToBool( GetPar( "UserInfoClientIdInclude"));
         AV80UserInfoClientSecretInclude = StringUtil.StrToBool( GetPar( "UserInfoClientSecretInclude"));
         AV101UserInfoUserIdInclude = StringUtil.StrToBool( GetPar( "UserInfoUserIdInclude"));
         AV93UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( GetPar( "UserInfoResponseUserLastNameGenAuto"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV25CurrentPage_Grid, AV120Pgmname, AV39I_LoadCount_Grid, Gx_mode, AV41IsEnable, AV104Oauth20RedirectURLisCustom, AV105Oauth20RedirectToAuthenticate, AV16AuthRespTypeInclude, AV19AuthScopeInclude, AV110AuthStateIncude, AV9AuthClientIdInclude, AV10AuthClientSecretInclude, AV13AuthRedirURLInclide, AV111AuthOpenIDConnectProtocolEnable, AV112AuthValidIdToken, AV115AuthAllowOnlyUserEmailVerified, AV106TokenHeaderAuthenticationInclude, AV109TokenHeaderAuthorizationBasicInclude, AV57TokenGrantTypeInclude, AV53TokenAccessCodeInclude, AV55TokenCliIdInclude, AV56TokenCliSecretInclude, AV63TokenRedirectURLInclude, AV23AutovalidateExternalTokenAndRefresh, AV75UserInfoAccessTokenInclude, AV78UserInfoClientIdInclude, AV80UserInfoClientSecretInclude, AV101UserInfoUserIdInclude, AV93UserInfoResponseUserLastNameGenAuto, sPrefix) ;
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
            PA3R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV120Pgmname = "K2BFSG.WCAuthenticationTypeEntryOauth20";
               edtavDynamicpropname_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_602_Refreshing);
               edtavDynamicproptag_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_602_Refreshing);
               WS3R2( ) ;
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
            context.SendWebValue( context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntryOauth", "")) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wcauthenticationtypeentryoauth20.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV43Name)),UrlEncode(StringUtil.RTrim(AV103TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV25CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_602", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_602), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV43Name", StringUtil.RTrim( wcpOAV43Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV103TypeId", StringUtil.RTrim( wcpOAV103TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV25CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV103TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Title", StringUtil.RTrim( Tbl_valididtoken_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Collapsible", StringUtil.BoolToStr( Tbl_valididtoken_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Open", StringUtil.BoolToStr( Tbl_valididtoken_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Showborders", StringUtil.BoolToStr( Tbl_valididtoken_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Containseditableform", StringUtil.BoolToStr( Tbl_valididtoken_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_VALIDIDTOKEN_Visible", StringUtil.BoolToStr( Tbl_valididtoken_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Title", StringUtil.RTrim( Tbl_openidconnect_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Collapsible", StringUtil.BoolToStr( Tbl_openidconnect_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Open", StringUtil.BoolToStr( Tbl_openidconnect_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Showborders", StringUtil.BoolToStr( Tbl_openidconnect_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Containseditableform", StringUtil.BoolToStr( Tbl_openidconnect_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"TBL_OPENIDCONNECT_Visible", StringUtil.BoolToStr( Tbl_openidconnect_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Title", StringUtil.RTrim( Responsivetable_mainattributes_tbldata_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_tbldata_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_tbldata_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_tbldata_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_tbldata_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONLS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_advancedconfigurationls_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONTOKENLS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_advancedconfigurationtokenls_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LINESEPARATORCONTENT_ADVANCEDUSERCONFIGURATION_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_advanceduserconfiguration_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3R2( )
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
         return "K2BFSG.WCAuthenticationTypeEntryOauth20" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntryOauth", "") ;
      }

      protected void WB3R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wcauthenticationtypeentryoauth20.aspx");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
            ucResponsivetable_mainattributes_tbldata.SetProperty("Title", Responsivetable_mainattributes_tbldata_Title);
            ucResponsivetable_mainattributes_tbldata.SetProperty("Collapsible", Responsivetable_mainattributes_tbldata_Collapsible);
            ucResponsivetable_mainattributes_tbldata.SetProperty("Open", Responsivetable_mainattributes_tbldata_Open);
            ucResponsivetable_mainattributes_tbldata.SetProperty("ShowBorders", Responsivetable_mainattributes_tbldata_Showborders);
            ucResponsivetable_mainattributes_tbldata.SetProperty("ContainsEditableForm", Responsivetable_mainattributes_tbldata_Containseditableform);
            ucResponsivetable_mainattributes_tbldata.Render(context, "k2bt_component", Responsivetable_mainattributes_tbldata_Internalname, sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATAContainer"+"Responsivetable_mainattributes_tbldata_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_tbldata_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_responsivetable_mainattributes_tbldata_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV43Name), StringUtil.RTrim( context.localUtil.Format( AV43Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV33FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV33FunctionId);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV41IsEnable), "", context.GetMessage( "K2BT_GAM_Enabled?", ""), 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(33, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,33);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV27Dsc), StringUtil.RTrim( context.localUtil.Format( AV27Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV52SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV52SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV24BigImageName), StringUtil.RTrim( context.localUtil.Format( AV24BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_impersonate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavImpersonate_Internalname, context.GetMessage( "K2BT_GAM_Impersonate", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavImpersonate, cmbavImpersonate_Internalname, StringUtil.RTrim( AV40Impersonate), 1, cmbavImpersonate_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavImpersonate.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV40Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", (string)(cmbavImpersonate.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblTab_title_Internalname, context.GetMessage( "K2BT_General", ""), "", "", lblTab_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_oauth20clientidtag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidtag_Internalname, context.GetMessage( "K2BT_GAM_ClientIdTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidtag_Internalname, StringUtil.RTrim( AV44Oauth20ClientIdTag), StringUtil.RTrim( context.localUtil.Format( AV44Oauth20ClientIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20clientidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_oauth20clientidvalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientidvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidvalue_Internalname, context.GetMessage( "K2BT_GAM_ClientIdValue", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidvalue_Internalname, AV45Oauth20ClientIdValue, StringUtil.RTrim( context.localUtil.Format( AV45Oauth20ClientIdValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidvalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20clientidvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_oauth20clientsecrettag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientsecrettag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecrettag_Internalname, context.GetMessage( "K2BT_GAM_ClientSecretTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecrettag_Internalname, StringUtil.RTrim( AV46Oauth20ClientSecretTag), StringUtil.RTrim( context.localUtil.Format( AV46Oauth20ClientSecretTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecrettag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20clientsecrettag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_oauth20clientsecretvalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientsecretvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecretvalue_Internalname, context.GetMessage( "K2BT_GAM_ClientSecretValue", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecretvalue_Internalname, AV47Oauth20ClientSecretValue, StringUtil.RTrim( context.localUtil.Format( AV47Oauth20ClientSecretValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecretvalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20clientsecretvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_oauth20redirecturltag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20redirecturltag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturltag_Internalname, context.GetMessage( "K2BT_GAM_RedirectURLTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturltag_Internalname, StringUtil.RTrim( AV48Oauth20RedirectURLTag), StringUtil.RTrim( context.localUtil.Format( AV48Oauth20RedirectURLTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturltag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20redirecturltag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_oauth20redirecturlvalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauth20redirecturlvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturlvalue_Internalname, context.GetMessage( "K2BT_GAM_RedirectURLValue", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturlvalue_Internalname, AV49Oauth20RedirectURLValue, StringUtil.RTrim( context.localUtil.Format( AV49Oauth20RedirectURLValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturlvalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauth20redirecturlvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_oauth20redirecturliscustom_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavOauth20redirecturliscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOauth20redirecturliscustom_Internalname, context.GetMessage( "K2BT_GAM_Oauth20RedirectURLisCustom", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOauth20redirecturliscustom_Internalname, StringUtil.BoolToStr( AV104Oauth20RedirectURLisCustom), "", context.GetMessage( "K2BT_GAM_Oauth20RedirectURLisCustom", ""), 1, chkavOauth20redirecturliscustom.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(102, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,102);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_oauth20redirecttoauthenticate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavOauth20redirecttoauthenticate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOauth20redirecttoauthenticate_Internalname, context.GetMessage( "K2BT_GAM_Oauth20RedirectToAuthenticate", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOauth20redirecttoauthenticate_Internalname, StringUtil.BoolToStr( AV105Oauth20RedirectToAuthenticate), "", context.GetMessage( "K2BT_GAM_Oauth20RedirectToAuthenticate", ""), 1, chkavOauth20redirecttoauthenticate.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "K2BT_GAM_Authorization", ""), "", "", lblTab1_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authorizeurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthorizeurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthorizeurl_Internalname, context.GetMessage( "K2BT_GAM_URL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthorizeurl_Internalname, AV12AuthorizeURL, StringUtil.RTrim( context.localUtil.Format( AV12AuthorizeURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthorizeurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthorizeurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_advancedconfigurationls_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_advancedconfigurationls_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_advancedconfigurationls_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_advancedconfigurationls_Internalname, context.GetMessage( "K2BT_GAM_AdvancedConfiguration", ""), "", "", lblLineseparatortitle_advancedconfigurationls_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113r1_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_advancedconfigurationls_Internalname, divLineseparatorcontent_advancedconfigurationls_Visible, 0, "px", 0, "px", divLineseparatorcontent_advancedconfigurationls_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authresptypeinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthresptypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthresptypeinclude_Internalname, context.GetMessage( "K2BT_GAM_ResponseType", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthresptypeinclude_Internalname, StringUtil.BoolToStr( AV16AuthRespTypeInclude), "", context.GetMessage( "K2BT_GAM_ResponseType", ""), 1, chkavAuthresptypeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authresptypetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthresptypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypetag_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypetag_Internalname, StringUtil.RTrim( AV17AuthRespTypeTag), StringUtil.RTrim( context.localUtil.Format( AV17AuthRespTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthresptypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authresptypevalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthresptypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypevalue_Internalname, context.GetMessage( "K2BT_GAM_Value", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypevalue_Internalname, AV18AuthRespTypeValue, StringUtil.RTrim( context.localUtil.Format( AV18AuthRespTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypevalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthresptypevalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authscopeinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthscopeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthscopeinclude_Internalname, context.GetMessage( "K2BT_GAM_Scope", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthscopeinclude_Internalname, StringUtil.BoolToStr( AV19AuthScopeInclude), "", context.GetMessage( "K2BT_GAM_Scope", ""), 1, chkavAuthscopeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(147, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,147);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authscopetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthscopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopetag_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopetag_Internalname, StringUtil.RTrim( AV20AuthScopeTag), StringUtil.RTrim( context.localUtil.Format( AV20AuthScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthscopetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authscopevalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthscopevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopevalue_Internalname, context.GetMessage( "K2BT_GAM_Value", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopevalue_Internalname, AV21AuthScopeValue, StringUtil.RTrim( context.localUtil.Format( AV21AuthScopeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopevalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthscopevalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authstateincude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthstateincude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthstateincude_Internalname, context.GetMessage( "K2BT_GAM_State", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthstateincude_Internalname, StringUtil.BoolToStr( AV110AuthStateIncude), "", context.GetMessage( "K2BT_GAM_State", ""), 1, chkavAuthstateincude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(163, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,163);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authstatetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthstatetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthstatetag_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthstatetag_Internalname, StringUtil.RTrim( AV22AuthStateTag), StringUtil.RTrim( context.localUtil.Format( AV22AuthStateTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthstatetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthstatetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authclientidinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientidinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientId", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientidinclude_Internalname, StringUtil.BoolToStr( AV9AuthClientIdInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientId", ""), 1, chkavAuthclientidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(174, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,174);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authclientsecretinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientsecretinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientsecretinclude_Internalname, StringUtil.BoolToStr( AV10AuthClientSecretInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), 1, chkavAuthclientsecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(179, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,179);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authredirurlinclide_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthredirurlinclide_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthredirurlinclide_Internalname, context.GetMessage( "K2BT_GAM_IncludeRedirectURL", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthredirurlinclide_Internalname, StringUtil.BoolToStr( AV13AuthRedirURLInclide), "", context.GetMessage( "K2BT_GAM_IncludeRedirectURL", ""), 1, chkavAuthredirurlinclide.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(184, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,184);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_authadditionalparameters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameters_Internalname, context.GetMessage( "K2BT_GAM_AdditionalParameters", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameters_Internalname, StringUtil.RTrim( AV7AuthAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV7AuthAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,190);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameters_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authadditionalparameterssd_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameterssd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameterssd_Internalname, context.GetMessage( "K2BT_GAM_AdditionalParametersforSmartDevices", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameterssd_Internalname, StringUtil.RTrim( AV8AuthAdditionalParametersSD), StringUtil.RTrim( context.localUtil.Format( AV8AuthAdditionalParametersSD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,195);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameterssd_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthadditionalparameterssd_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authopenidconnectprotocolenable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthopenidconnectprotocolenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthopenidconnectprotocolenable_Internalname, context.GetMessage( "K2BT_GAM_State", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthopenidconnectprotocolenable_Internalname, StringUtil.BoolToStr( AV111AuthOpenIDConnectProtocolEnable), "", context.GetMessage( "K2BT_GAM_State", ""), 1, chkavAuthopenidconnectprotocolenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,201);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroupresponse_Internalname, context.GetMessage( "K2BT_GAM_Response", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_groupresponse_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authresponseaccesscodetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthresponseaccesscodetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseaccesscodetag_Internalname, context.GetMessage( "K2BT_GAM_AccessCodeTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseaccesscodetag_Internalname, StringUtil.RTrim( AV14AuthResponseAccessCodeTag), StringUtil.RTrim( context.localUtil.Format( AV14AuthResponseAccessCodeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseaccesscodetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthresponseaccesscodetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authresponseerrordesctag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthresponseerrordesctag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseerrordesctag_Internalname, context.GetMessage( "K2BT_GAM_ErrorDescriptionTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseerrordesctag_Internalname, StringUtil.RTrim( AV15AuthResponseErrorDescTag), StringUtil.RTrim( context.localUtil.Format( AV15AuthResponseErrorDescTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,217);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseerrordesctag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthresponseerrordesctag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTbl_openidconnect.SetProperty("Title", Tbl_openidconnect_Title);
            ucTbl_openidconnect.SetProperty("Collapsible", Tbl_openidconnect_Collapsible);
            ucTbl_openidconnect.SetProperty("Open", Tbl_openidconnect_Open);
            ucTbl_openidconnect.SetProperty("ShowBorders", Tbl_openidconnect_Showborders);
            ucTbl_openidconnect.SetProperty("ContainsEditableForm", Tbl_openidconnect_Containseditableform);
            ucTbl_openidconnect.Render(context, "k2bt_component", Tbl_openidconnect_Internalname, sPrefix+"TBL_OPENIDCONNECTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBL_OPENIDCONNECTContainer"+"Tbl_openidconnect_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbl_openidconnect_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbl_openidconnect_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGroup1_Internalname, context.GetMessage( "K2BT_GAM_OpenIDConnect", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authvalididtoken_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthvalididtoken_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthvalididtoken_Internalname, context.GetMessage( "K2BT_GAM_AuthValidIdToken", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 235,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthvalididtoken_Internalname, StringUtil.BoolToStr( AV112AuthValidIdToken), "", context.GetMessage( "K2BT_GAM_AuthValidIdToken", ""), 1, chkavAuthvalididtoken.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,235);\"");
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
            ucTbl_valididtoken.SetProperty("Title", Tbl_valididtoken_Title);
            ucTbl_valididtoken.SetProperty("Collapsible", Tbl_valididtoken_Collapsible);
            ucTbl_valididtoken.SetProperty("Open", Tbl_valididtoken_Open);
            ucTbl_valididtoken.SetProperty("ShowBorders", Tbl_valididtoken_Showborders);
            ucTbl_valididtoken.SetProperty("ContainsEditableForm", Tbl_valididtoken_Containseditableform);
            ucTbl_valididtoken.Render(context, "k2bt_component", Tbl_valididtoken_Internalname, sPrefix+"TBL_VALIDIDTOKENContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TBL_VALIDIDTOKENContainer"+"Tbl_valididtoken_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbl_valididtoken_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_tbl_valididtoken_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_authissuerurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthissuerurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthissuerurl_Internalname, context.GetMessage( "K2BT_GAM_AuthIssuerURL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthissuerurl_Internalname, AV113AuthIssuerURL, StringUtil.RTrim( context.localUtil.Format( AV113AuthIssuerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthissuerurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthissuerurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authcertificatepathfilename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthcertificatepathfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthcertificatepathfilename_Internalname, context.GetMessage( "K2BT_GAM_AuthCertificatePathFileName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 255,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthcertificatepathfilename_Internalname, AV114AuthCertificatePathFileName, StringUtil.RTrim( context.localUtil.Format( AV114AuthCertificatePathFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,255);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthcertificatepathfilename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthcertificatepathfilename_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authallowonlyuseremailverified_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAuthallowonlyuseremailverified_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthallowonlyuseremailverified_Internalname, context.GetMessage( "K2BT_GAM_AuthAllowOnlyUserEmailVerified", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthallowonlyuseremailverified_Internalname, StringUtil.BoolToStr( AV115AuthAllowOnlyUserEmailVerified), "", context.GetMessage( "K2BT_GAM_AuthAllowOnlyUserEmailVerified", ""), 1, chkavAuthallowonlyuseremailverified.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(261, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,261);\"");
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
            context.WriteHtmlText( "</fieldset>") ;
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, context.GetMessage( "K2BT_GAM_Token", ""), "", "", lblTab2_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenurl_Internalname, context.GetMessage( "K2BT_GAM_URL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 272,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenurl_Internalname, AV72TokenURL, StringUtil.RTrim( context.localUtil.Format( AV72TokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,272);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_advancedconfigurationtokenls_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_advancedconfigurationtokenls_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_advancedconfigurationtokenls_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_advancedconfigurationtokenls_Internalname, context.GetMessage( "K2BT_GAM_AdvancedConfiguration", ""), "", "", lblLineseparatortitle_advancedconfigurationtokenls_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e123r1_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_advancedconfigurationtokenls_Internalname, divLineseparatorcontent_advancedconfigurationtokenls_Visible, 0, "px", 0, "px", divLineseparatorcontent_advancedconfigurationtokenls_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenmethod_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavTokenmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTokenmethod_Internalname, context.GetMessage( "K2BT_GAM_TokenMethod", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTokenmethod, cmbavTokenmethod_Internalname, StringUtil.RTrim( AV62TokenMethod), 1, cmbavTokenmethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTokenmethod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,284);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV62TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", (string)(cmbavTokenmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderkeytag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeytag_Internalname, context.GetMessage( "K2BT_GAM_HeaderTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 289,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeytag_Internalname, StringUtil.RTrim( AV60TokenHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV60TokenHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,289);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeytag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenheaderkeytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderkeyvalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeyvalue_Internalname, context.GetMessage( "K2BT_GAM_HeaderValue", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 294,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeyvalue_Internalname, StringUtil.RTrim( AV61TokenHeaderKeyValue), StringUtil.RTrim( context.localUtil.Format( AV61TokenHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,294);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeyvalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenheaderkeyvalue_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderauthenticationinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokenheaderauthenticationinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenheaderauthenticationinclude_Internalname, context.GetMessage( "TokenHeaderAuthenticationInclude", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 300,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenheaderauthenticationinclude_Internalname, StringUtil.BoolToStr( AV106TokenHeaderAuthenticationInclude), "", context.GetMessage( "TokenHeaderAuthenticationInclude", ""), 1, chkavTokenheaderauthenticationinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(300, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,300);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderauthenticationmethod_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavTokenheaderauthenticationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTokenheaderauthenticationmethod_Internalname, context.GetMessage( "TokenHeaderAuthenticationMethod", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 305,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTokenheaderauthenticationmethod, cmbavTokenheaderauthenticationmethod_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0)), 1, cmbavTokenheaderauthenticationmethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTokenheaderauthenticationmethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,305);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            cmbavTokenheaderauthenticationmethod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0));
            AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Values", (string)(cmbavTokenheaderauthenticationmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderauthenticationrealm_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderauthenticationrealm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderauthenticationrealm_Internalname, context.GetMessage( "TokenHeaderAuthenticationRealm", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderauthenticationrealm_Internalname, StringUtil.RTrim( AV108TokenHeaderAuthenticationRealm), StringUtil.RTrim( context.localUtil.Format( AV108TokenHeaderAuthenticationRealm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,310);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderauthenticationrealm_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenheaderauthenticationrealm_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenheaderauthorizationbasicinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokenheaderauthorizationbasicinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenheaderauthorizationbasicinclude_Internalname, context.GetMessage( "TokenHeaderAuthorizationBasicInclude", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenheaderauthorizationbasicinclude_Internalname, StringUtil.BoolToStr( AV109TokenHeaderAuthorizationBasicInclude), "", context.GetMessage( "TokenHeaderAuthorizationBasicInclude", ""), 1, chkavTokenheaderauthorizationbasicinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(316, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,316);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_tokengranttypeinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokengranttypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokengranttypeinclude_Internalname, context.GetMessage( "K2BT_GAM_GrantType", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 322,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokengranttypeinclude_Internalname, StringUtil.BoolToStr( AV57TokenGrantTypeInclude), "", context.GetMessage( "K2BT_GAM_GrantType", ""), 1, chkavTokengranttypeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(322, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,322);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokengranttypetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokengranttypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypetag_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 327,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypetag_Internalname, StringUtil.RTrim( AV58TokenGrantTypeTag), StringUtil.RTrim( context.localUtil.Format( AV58TokenGrantTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,327);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokengranttypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokengranttypevalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokengranttypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypevalue_Internalname, context.GetMessage( "K2BT_GAM_Value", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 332,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypevalue_Internalname, StringUtil.RTrim( AV59TokenGrantTypeValue), StringUtil.RTrim( context.localUtil.Format( AV59TokenGrantTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,332);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypevalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokengranttypevalue_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenaccesscodeinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokenaccesscodeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenaccesscodeinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeAccessCode", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 338,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenaccesscodeinclude_Internalname, StringUtil.BoolToStr( AV53TokenAccessCodeInclude), "", context.GetMessage( "K2BT_GAM_IncludeAccessCode", ""), 1, chkavTokenaccesscodeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(338, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,338);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokencliidinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokencliidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokencliidinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientId", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 343,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokencliidinclude_Internalname, StringUtil.BoolToStr( AV55TokenCliIdInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientId", ""), 1, chkavTokencliidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(343, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,343);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenclisecretinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokenclisecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenclisecretinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 348,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenclisecretinclude_Internalname, StringUtil.BoolToStr( AV56TokenCliSecretInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), 1, chkavTokenclisecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(348, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,348);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenredirecturlinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavTokenredirecturlinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenredirecturlinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeRedirectURL", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 353,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenredirecturlinclude_Internalname, StringUtil.BoolToStr( AV63TokenRedirectURLInclude), "", context.GetMessage( "K2BT_GAM_IncludeRedirectURL", ""), 1, chkavTokenredirecturlinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(353, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,353);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenadditionalparameters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenadditionalparameters_Internalname, context.GetMessage( "K2BT_GAM_AdditionalParameters", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 359,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenadditionalparameters_Internalname, StringUtil.RTrim( AV54TokenAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV54TokenAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,359);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenadditionalparameters_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_group_start( context, grpResponse_Internalname, context.GetMessage( "K2BT_GAM_Response", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_response_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenresponseaccesstokentag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseaccesstokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseaccesstokentag_Internalname, context.GetMessage( "K2BT_GAM_AccessTokenTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 369,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseaccesstokentag_Internalname, StringUtil.RTrim( AV65TokenResponseAccessTokenTag), StringUtil.RTrim( context.localUtil.Format( AV65TokenResponseAccessTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,369);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseaccesstokentag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponseaccesstokentag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenresponsetokentypetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponsetokentypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsetokentypetag_Internalname, context.GetMessage( "K2BT_GAM_TokenTypeTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 374,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsetokentypetag_Internalname, StringUtil.RTrim( AV70TokenResponseTokenTypeTag), StringUtil.RTrim( context.localUtil.Format( AV70TokenResponseTokenTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,374);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsetokentypetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponsetokentypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenresponseexpiresintag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseexpiresintag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseexpiresintag_Internalname, context.GetMessage( "K2BT_GAM_ExpiresInTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 380,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseexpiresintag_Internalname, StringUtil.RTrim( AV67TokenResponseExpiresInTag), StringUtil.RTrim( context.localUtil.Format( AV67TokenResponseExpiresInTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,380);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseexpiresintag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponseexpiresintag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenresponsescopetag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponsescopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsescopetag_Internalname, context.GetMessage( "K2BT_GAM_ScopeTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 385,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsescopetag_Internalname, StringUtil.RTrim( AV69TokenResponseScopeTag), StringUtil.RTrim( context.localUtil.Format( AV69TokenResponseScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,385);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsescopetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponsescopetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenresponseuseridtag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseuseridtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseuseridtag_Internalname, context.GetMessage( "K2BT_GAM_UserIdTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 391,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseuseridtag_Internalname, StringUtil.RTrim( AV71TokenResponseUserIdTag), StringUtil.RTrim( context.localUtil.Format( AV71TokenResponseUserIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,391);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseuseridtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponseuseridtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenresponserefreshtokentag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponserefreshtokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponserefreshtokentag_Internalname, context.GetMessage( "K2BT_GAM_RefreshTokenTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 396,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponserefreshtokentag_Internalname, StringUtil.RTrim( AV68TokenResponseRefreshTokenTag), StringUtil.RTrim( context.localUtil.Format( AV68TokenResponseRefreshTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,396);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponserefreshtokentag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponserefreshtokentag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_tokenresponseerrordescriptiontag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseerrordescriptiontag_Internalname, context.GetMessage( "K2BT_GAM_ErrorDescriptionTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 402,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV66TokenResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV66TokenResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,402);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseerrordescriptiontag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenresponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_group_start( context, grpGroup_Internalname, context.GetMessage( "K2BT_GAM_RefreshToken", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_group_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_autovalidateexternaltokenandrefresh_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavAutovalidateexternaltokenandrefresh_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAutovalidateexternaltokenandrefresh_Internalname, context.GetMessage( "K2BT_GAM_ValidateExternalToken", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 412,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutovalidateexternaltokenandrefresh_Internalname, StringUtil.BoolToStr( AV23AutovalidateExternalTokenAndRefresh), "", context.GetMessage( "K2BT_GAM_ValidateExternalToken", ""), 1, chkavAutovalidateexternaltokenandrefresh.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(412, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,412);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_tokenrefreshtokenurl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavTokenrefreshtokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenrefreshtokenurl_Internalname, context.GetMessage( "K2BT_GAM_RefreshTokenURL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 417,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenrefreshtokenurl_Internalname, AV64TokenRefreshTokenURL, StringUtil.RTrim( context.localUtil.Format( AV64TokenRefreshTokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,417);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenrefreshtokenurl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavTokenrefreshtokenurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab3_title_Internalname, context.GetMessage( "K2BT_GAM_UserInformation", ""), "", "", lblTab3_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab3") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintabresponsivetable_tab3_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfourl_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfourl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfourl_Internalname, context.GetMessage( "K2BT_GAM_URL", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 428,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfourl_Internalname, AV100UserInfoURL, StringUtil.RTrim( context.localUtil.Format( AV100UserInfoURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,428);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfourl_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfourl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_advanceduserconfiguration_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_advanceduserconfiguration_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_advanceduserconfiguration_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_advanceduserconfiguration_Internalname, context.GetMessage( "K2BT_GAM_AdvancedUserConfiguration", ""), "", "", lblLineseparatortitle_advanceduserconfiguration_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133r1_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_advanceduserconfiguration_Internalname, divLineseparatorcontent_advanceduserconfiguration_Visible, 0, "px", 0, "px", divLineseparatorcontent_advanceduserconfiguration_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfomethod_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavUserinfomethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserinfomethod_Internalname, context.GetMessage( "K2BT_GAM_UserInfoMethod", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 440,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserinfomethod, cmbavUserinfomethod_Internalname, StringUtil.RTrim( AV84UserInfoMethod), 1, cmbavUserinfomethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUserinfomethod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,440);\"", "", true, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV84UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", (string)(cmbavUserinfomethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoheaderkeytag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeytag_Internalname, context.GetMessage( "K2BT_GAM_HeaderTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 445,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeytag_Internalname, StringUtil.RTrim( AV82UserInfoHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV82UserInfoHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,445);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeytag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoheaderkeytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoheaderkeyvalue_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeyvalue_Internalname, context.GetMessage( "K2BT_GAM_HeaderValue", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 450,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeyvalue_Internalname, StringUtil.RTrim( AV83UserInfoHeaderKeyValue), StringUtil.RTrim( context.localUtil.Format( AV83UserInfoHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,450);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeyvalue_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoheaderkeyvalue_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userinfoaccesstokeninclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUserinfoaccesstokeninclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoaccesstokeninclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeAccessToken", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 456,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoaccesstokeninclude_Internalname, StringUtil.BoolToStr( AV75UserInfoAccessTokenInclude), "", context.GetMessage( "K2BT_GAM_IncludeAccessToken", ""), 1, chkavUserinfoaccesstokeninclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(456, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,456);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoaccesstokenname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoaccesstokenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoaccesstokenname_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 461,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoaccesstokenname_Internalname, StringUtil.RTrim( AV76UserInfoAccessTokenName), StringUtil.RTrim( context.localUtil.Format( AV76UserInfoAccessTokenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,461);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoaccesstokenname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoaccesstokenname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userinfoclientidinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUserinfoclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientidinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientId", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 467,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientidinclude_Internalname, StringUtil.BoolToStr( AV78UserInfoClientIdInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientId", ""), 1, chkavUserinfoclientidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(467, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,467);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoclientidname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoclientidname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientidname_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 472,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientidname_Internalname, StringUtil.RTrim( AV79UserInfoClientIdName), StringUtil.RTrim( context.localUtil.Format( AV79UserInfoClientIdName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,472);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientidname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoclientidname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userinfoclientsecretinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUserinfoclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientsecretinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 478,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientsecretinclude_Internalname, StringUtil.BoolToStr( AV80UserInfoClientSecretInclude), "", context.GetMessage( "K2BT_GAM_IncludeClientSecret", ""), 1, chkavUserinfoclientsecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(478, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,478);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoclientsecretname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoclientsecretname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientsecretname_Internalname, context.GetMessage( "K2BT_GAM_Tag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 483,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientsecretname_Internalname, StringUtil.RTrim( AV81UserInfoClientSecretName), StringUtil.RTrim( context.localUtil.Format( AV81UserInfoClientSecretName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,483);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientsecretname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoclientsecretname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userinfouseridinclude_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUserinfouseridinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfouseridinclude_Internalname, context.GetMessage( "K2BT_GAM_IncludeUserId", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 489,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfouseridinclude_Internalname, StringUtil.BoolToStr( AV101UserInfoUserIdInclude), "", context.GetMessage( "K2BT_GAM_IncludeUserId", ""), 1, chkavUserinfouseridinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(489, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,489);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinfoadditionalparameters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinfoadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoadditionalparameters_Internalname, context.GetMessage( "K2BT_GAM_AdditionalParameters", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 494,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoadditionalparameters_Internalname, StringUtil.RTrim( AV77UserInfoAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV77UserInfoAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,494);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoadditionalparameters_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinfoadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_group_start( context, grpGroup1response_Internalname, context.GetMessage( "K2BT_GAM_Response", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 504,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuseremailtag_Internalname, StringUtil.RTrim( AV87UserInfoResponseUserEmailTag), StringUtil.RTrim( context.localUtil.Format( AV87UserInfoResponseUserEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,504);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuseremailtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuseremailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserverifiedemailtag_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserverifiedemailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserverifiedemailtag_Internalname, context.GetMessage( "K2BT_GAM_VerifiedEmailTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 509,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserverifiedemailtag_Internalname, StringUtil.RTrim( AV99UserInfoResponseUserVerifiedEmailTag), StringUtil.RTrim( context.localUtil.Format( AV99UserInfoResponseUserVerifiedEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,509);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserverifiedemailtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserverifiedemailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 515,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserexternalidtag_Internalname, StringUtil.RTrim( AV88UserInfoResponseUserExternalIdTag), StringUtil.RTrim( context.localUtil.Format( AV88UserInfoResponseUserExternalIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,515);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserexternalidtag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserexternalidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 520,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusernametag_Internalname, StringUtil.RTrim( AV95UserInfoResponseUserNameTag), StringUtil.RTrim( context.localUtil.Format( AV95UserInfoResponseUserNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,520);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusernametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusernametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 526,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserfirstnametag_Internalname, StringUtil.RTrim( AV89UserInfoResponseUserFirstNameTag), StringUtil.RTrim( context.localUtil.Format( AV89UserInfoResponseUserFirstNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,526);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserfirstnametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserfirstnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 531,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinforesponseuserlastnamegenauto_Internalname, StringUtil.BoolToStr( AV93UserInfoResponseUserLastNameGenAuto), "", context.GetMessage( "K2BT_GAM_GenerateLastNameAutomatically", ""), 1, chkavUserinforesponseuserlastnamegenauto.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,531);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_userinforesponseuserlastnametag_Internalname, context.GetMessage( "K2BT_GAM_UserLastNameTag", ""), "", "", lblTextblock_var_userinforesponseuserlastnametag_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userinforesponseuserlastnametagcellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlastnametag_Internalname, context.GetMessage( "K2BT_GAM_UserLastNameTag", ""), "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 538,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlastnametag_Internalname, StringUtil.RTrim( AV94UserInfoResponseUserLastNameTag), StringUtil.RTrim( context.localUtil.Format( AV94UserInfoResponseUserLastNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,538);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlastnametag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUserinforesponseuserlastnametag_Visible, edtavUserinforesponseuserlastnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbuserlastnamehelp_Internalname, lblTbuserlastnamehelp_Caption, "", "", lblTbuserlastnamehelp_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 545,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendertag_Internalname, StringUtil.RTrim( AV90UserInfoResponseUserGenderTag), StringUtil.RTrim( context.localUtil.Format( AV90UserInfoResponseUserGenderTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,545);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendertag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusergendertag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 550,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendervalues_Internalname, AV91UserInfoResponseUserGenderValues, StringUtil.RTrim( context.localUtil.Format( AV91UserInfoResponseUserGenderValues, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,550);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendervalues_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusergendervalues_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 556,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserbirthdaytag_Internalname, StringUtil.RTrim( AV86UserInfoResponseUserBirthdayTag), StringUtil.RTrim( context.localUtil.Format( AV86UserInfoResponseUserBirthdayTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,556);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserbirthdaytag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserbirthdaytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlimagetag_Internalname, context.GetMessage( "K2BT_GAM_UserImageURLTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 561,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlimagetag_Internalname, StringUtil.RTrim( AV97UserInfoResponseUserURLImageTag), StringUtil.RTrim( context.localUtil.Format( AV97UserInfoResponseUserURLImageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,561);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlimagetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserurlimagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlprofiletag_Internalname, context.GetMessage( "K2BT_GAM_UserProfileURLTag", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 567,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlprofiletag_Internalname, StringUtil.RTrim( AV98UserInfoResponseUserURLProfileTag), StringUtil.RTrim( context.localUtil.Format( AV98UserInfoResponseUserURLProfileTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,567);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlprofiletag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserurlprofiletag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 572,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlanguagetag_Internalname, StringUtil.RTrim( AV92UserInfoResponseUserLanguageTag), StringUtil.RTrim( context.localUtil.Format( AV92UserInfoResponseUserLanguageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,572);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlanguagetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseuserlanguagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 578,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusertimezonetag_Internalname, StringUtil.RTrim( AV96UserInfoResponseUserTimeZoneTag), StringUtil.RTrim( context.localUtil.Format( AV96UserInfoResponseUserTimeZoneTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,578);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusertimezonetag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseusertimezonetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 583,'" + sPrefix + "',false,'" + sGXsfl_602_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV85UserInfoResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV85UserInfoResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,583);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseerrordescriptiontag_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserinforesponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_group_start( context, grpGroupcustomuserattributes_Internalname, context.GetMessage( "K2BT_GAM_CustomUserAttributes", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            StartGridControl602( ) ;
         }
         if ( wbEnd == 602 )
         {
            wbEnd = 0;
            nRC_GXsfl_602 = (int)(nGXsfl_602_idx-1);
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
            wb_table1_608_3R2( true) ;
         }
         else
         {
            wb_table1_608_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_608_3R2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 615,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(602), 3, 0)+","+"null"+");", context.GetMessage( "K2BT_MultipleFilterAdd", ""), bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 623,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(602), 3, 0)+","+"null"+");", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 625,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(602), 3, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e143r1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 602 )
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

      protected void START3R2( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_WCAuthenticationTypeEntryOauth", ""), 0) ;
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
               STRUP3R0( ) ;
            }
         }
      }

      protected void WS3R2( )
      {
         START3R2( ) ;
         EVT3R2( ) ;
      }

      protected void EVT3R2( )
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
                                 STRUP3R0( ) ;
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
                                 STRUP3R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E153R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Confirm' */
                                    E163R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3R0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3R0( ) ;
                              }
                              nGXsfl_602_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_602_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_idx), 4, 0), 4, "0");
                              SubsflControlProps_6022( ) ;
                              AV28DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV28DynamicPropName);
                              AV29DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV29DynamicPropTag);
                              AV26Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action)) ? AV119Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV26Delete_Action))), !bGXsfl_602_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV26Delete_Action), true);
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
                                          E173R2 ();
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
                                          E183R2 ();
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
                                          E193R2 ();
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
                                          E203R2 ();
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
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Delete' */
                                          E213R2 ();
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
                                       STRUP3R0( ) ;
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

      protected void WE3R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3R2( ) ;
            }
         }
      }

      protected void PA3R2( )
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
         SubsflControlProps_6022( ) ;
         while ( nGXsfl_602_idx <= nRC_GXsfl_602 )
         {
            sendrow_6022( ) ;
            nGXsfl_602_idx = ((subGrid_Islastpage==1)&&(nGXsfl_602_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_602_idx+1);
            sGXsfl_602_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_idx), 4, 0), 4, "0");
            SubsflControlProps_6022( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( short AV25CurrentPage_Grid ,
                                       string AV120Pgmname ,
                                       short AV39I_LoadCount_Grid ,
                                       string Gx_mode ,
                                       bool AV41IsEnable ,
                                       bool AV104Oauth20RedirectURLisCustom ,
                                       bool AV105Oauth20RedirectToAuthenticate ,
                                       bool AV16AuthRespTypeInclude ,
                                       bool AV19AuthScopeInclude ,
                                       bool AV110AuthStateIncude ,
                                       bool AV9AuthClientIdInclude ,
                                       bool AV10AuthClientSecretInclude ,
                                       bool AV13AuthRedirURLInclide ,
                                       bool AV111AuthOpenIDConnectProtocolEnable ,
                                       bool AV112AuthValidIdToken ,
                                       bool AV115AuthAllowOnlyUserEmailVerified ,
                                       bool AV106TokenHeaderAuthenticationInclude ,
                                       bool AV109TokenHeaderAuthorizationBasicInclude ,
                                       bool AV57TokenGrantTypeInclude ,
                                       bool AV53TokenAccessCodeInclude ,
                                       bool AV55TokenCliIdInclude ,
                                       bool AV56TokenCliSecretInclude ,
                                       bool AV63TokenRedirectURLInclude ,
                                       bool AV23AutovalidateExternalTokenAndRefresh ,
                                       bool AV75UserInfoAccessTokenInclude ,
                                       bool AV78UserInfoClientIdInclude ,
                                       bool AV80UserInfoClientSecretInclude ,
                                       bool AV101UserInfoUserIdInclude ,
                                       bool AV93UserInfoResponseUserLastNameGenAuto ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3R2( ) ;
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
            AV33FunctionId = cmbavFunctionid.getValidValue(AV33FunctionId);
            AssignAttri(sPrefix, false, "AV33FunctionId", AV33FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV33FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV41IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV41IsEnable));
         AssignAttri(sPrefix, false, "AV41IsEnable", AV41IsEnable);
         if ( cmbavImpersonate.ItemCount > 0 )
         {
            AV40Impersonate = cmbavImpersonate.getValidValue(AV40Impersonate);
            AssignAttri(sPrefix, false, "AV40Impersonate", AV40Impersonate);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV40Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", cmbavImpersonate.ToJavascriptSource(), true);
         }
         AV104Oauth20RedirectURLisCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV104Oauth20RedirectURLisCustom));
         AssignAttri(sPrefix, false, "AV104Oauth20RedirectURLisCustom", AV104Oauth20RedirectURLisCustom);
         AV105Oauth20RedirectToAuthenticate = StringUtil.StrToBool( StringUtil.BoolToStr( AV105Oauth20RedirectToAuthenticate));
         AssignAttri(sPrefix, false, "AV105Oauth20RedirectToAuthenticate", AV105Oauth20RedirectToAuthenticate);
         AV16AuthRespTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV16AuthRespTypeInclude));
         AssignAttri(sPrefix, false, "AV16AuthRespTypeInclude", AV16AuthRespTypeInclude);
         AV19AuthScopeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV19AuthScopeInclude));
         AssignAttri(sPrefix, false, "AV19AuthScopeInclude", AV19AuthScopeInclude);
         AV110AuthStateIncude = StringUtil.StrToBool( StringUtil.BoolToStr( AV110AuthStateIncude));
         AssignAttri(sPrefix, false, "AV110AuthStateIncude", AV110AuthStateIncude);
         AV9AuthClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV9AuthClientIdInclude));
         AssignAttri(sPrefix, false, "AV9AuthClientIdInclude", AV9AuthClientIdInclude);
         AV10AuthClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV10AuthClientSecretInclude));
         AssignAttri(sPrefix, false, "AV10AuthClientSecretInclude", AV10AuthClientSecretInclude);
         AV13AuthRedirURLInclide = StringUtil.StrToBool( StringUtil.BoolToStr( AV13AuthRedirURLInclide));
         AssignAttri(sPrefix, false, "AV13AuthRedirURLInclide", AV13AuthRedirURLInclide);
         AV111AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV111AuthOpenIDConnectProtocolEnable));
         AssignAttri(sPrefix, false, "AV111AuthOpenIDConnectProtocolEnable", AV111AuthOpenIDConnectProtocolEnable);
         AV112AuthValidIdToken = StringUtil.StrToBool( StringUtil.BoolToStr( AV112AuthValidIdToken));
         AssignAttri(sPrefix, false, "AV112AuthValidIdToken", AV112AuthValidIdToken);
         AV115AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( StringUtil.BoolToStr( AV115AuthAllowOnlyUserEmailVerified));
         AssignAttri(sPrefix, false, "AV115AuthAllowOnlyUserEmailVerified", AV115AuthAllowOnlyUserEmailVerified);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
            AV62TokenMethod = cmbavTokenmethod.getValidValue(AV62TokenMethod);
            AssignAttri(sPrefix, false, "AV62TokenMethod", AV62TokenMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV62TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", cmbavTokenmethod.ToJavascriptSource(), true);
         }
         AV106TokenHeaderAuthenticationInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV106TokenHeaderAuthenticationInclude));
         AssignAttri(sPrefix, false, "AV106TokenHeaderAuthenticationInclude", AV106TokenHeaderAuthenticationInclude);
         if ( cmbavTokenheaderauthenticationmethod.ItemCount > 0 )
         {
            AV107TokenHeaderAuthenticationMethod = (short)(Math.Round(NumberUtil.Val( cmbavTokenheaderauthenticationmethod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV107TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTokenheaderauthenticationmethod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0));
            AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Values", cmbavTokenheaderauthenticationmethod.ToJavascriptSource(), true);
         }
         AV109TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV109TokenHeaderAuthorizationBasicInclude));
         AssignAttri(sPrefix, false, "AV109TokenHeaderAuthorizationBasicInclude", AV109TokenHeaderAuthorizationBasicInclude);
         AV57TokenGrantTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV57TokenGrantTypeInclude));
         AssignAttri(sPrefix, false, "AV57TokenGrantTypeInclude", AV57TokenGrantTypeInclude);
         AV53TokenAccessCodeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV53TokenAccessCodeInclude));
         AssignAttri(sPrefix, false, "AV53TokenAccessCodeInclude", AV53TokenAccessCodeInclude);
         AV55TokenCliIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV55TokenCliIdInclude));
         AssignAttri(sPrefix, false, "AV55TokenCliIdInclude", AV55TokenCliIdInclude);
         AV56TokenCliSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV56TokenCliSecretInclude));
         AssignAttri(sPrefix, false, "AV56TokenCliSecretInclude", AV56TokenCliSecretInclude);
         AV63TokenRedirectURLInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV63TokenRedirectURLInclude));
         AssignAttri(sPrefix, false, "AV63TokenRedirectURLInclude", AV63TokenRedirectURLInclude);
         AV23AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( StringUtil.BoolToStr( AV23AutovalidateExternalTokenAndRefresh));
         AssignAttri(sPrefix, false, "AV23AutovalidateExternalTokenAndRefresh", AV23AutovalidateExternalTokenAndRefresh);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
            AV84UserInfoMethod = cmbavUserinfomethod.getValidValue(AV84UserInfoMethod);
            AssignAttri(sPrefix, false, "AV84UserInfoMethod", AV84UserInfoMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV84UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", cmbavUserinfomethod.ToJavascriptSource(), true);
         }
         AV75UserInfoAccessTokenInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV75UserInfoAccessTokenInclude));
         AssignAttri(sPrefix, false, "AV75UserInfoAccessTokenInclude", AV75UserInfoAccessTokenInclude);
         AV78UserInfoClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV78UserInfoClientIdInclude));
         AssignAttri(sPrefix, false, "AV78UserInfoClientIdInclude", AV78UserInfoClientIdInclude);
         AV80UserInfoClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV80UserInfoClientSecretInclude));
         AssignAttri(sPrefix, false, "AV80UserInfoClientSecretInclude", AV80UserInfoClientSecretInclude);
         AV101UserInfoUserIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV101UserInfoUserIdInclude));
         AssignAttri(sPrefix, false, "AV101UserInfoUserIdInclude", AV101UserInfoUserIdInclude);
         AV93UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( StringUtil.BoolToStr( AV93UserInfoResponseUserLastNameGenAuto));
         AssignAttri(sPrefix, false, "AV93UserInfoResponseUserLastNameGenAuto", AV93UserInfoResponseUserLastNameGenAuto);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E183R2 ();
         RF3R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV120Pgmname = "K2BFSG.WCAuthenticationTypeEntryOauth20";
         edtavDynamicpropname_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicproptag_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_602_Refreshing);
      }

      protected void RF3R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 602;
         /* Execute user event: Refresh */
         E183R2 ();
         E193R2 ();
         nGXsfl_602_idx = 1;
         sGXsfl_602_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_idx), 4, 0), 4, "0");
         SubsflControlProps_6022( ) ;
         bGXsfl_602_Refreshing = true;
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
            SubsflControlProps_6022( ) ;
            E203R2 ();
            wbEnd = 602;
            WB3R0( ) ;
         }
         bGXsfl_602_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3R2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV25CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39I_LoadCount_Grid), "ZZZ9"), context));
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
         AV120Pgmname = "K2BFSG.WCAuthenticationTypeEntryOauth20";
         edtavDynamicpropname_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicproptag_Enabled = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_602_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E173R2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_602 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_602"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV43Name = cgiGet( sPrefix+"wcpOAV43Name");
            wcpOAV103TypeId = cgiGet( sPrefix+"wcpOAV103TypeId");
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tbl_valididtoken_Title = cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Title");
            Tbl_valididtoken_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Collapsible"));
            Tbl_valididtoken_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Open"));
            Tbl_valididtoken_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Showborders"));
            Tbl_valididtoken_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Containseditableform"));
            Tbl_valididtoken_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_VALIDIDTOKEN_Visible"));
            Tbl_openidconnect_Title = cgiGet( sPrefix+"TBL_OPENIDCONNECT_Title");
            Tbl_openidconnect_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_OPENIDCONNECT_Collapsible"));
            Tbl_openidconnect_Open = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_OPENIDCONNECT_Open"));
            Tbl_openidconnect_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_OPENIDCONNECT_Showborders"));
            Tbl_openidconnect_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_OPENIDCONNECT_Containseditableform"));
            Tbl_openidconnect_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"TBL_OPENIDCONNECT_Visible"));
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( sPrefix+"TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"TABS_Historymanagement"));
            Responsivetable_mainattributes_tbldata_Title = cgiGet( sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Title");
            Responsivetable_mainattributes_tbldata_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Collapsible"));
            Responsivetable_mainattributes_tbldata_Open = StringUtil.StrToBool( cgiGet( sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Open"));
            Responsivetable_mainattributes_tbldata_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Showborders"));
            Responsivetable_mainattributes_tbldata_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_Containseditableform"));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV43Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV43Name", AV43Name);
            }
            cmbavFunctionid.Name = cmbavFunctionid_Internalname;
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV33FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV33FunctionId", AV33FunctionId);
            AV41IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV41IsEnable", AV41IsEnable);
            AV27Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV27Dsc", AV27Dsc);
            AV52SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV52SmallImageName", AV52SmallImageName);
            AV24BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV24BigImageName", AV24BigImageName);
            cmbavImpersonate.Name = cmbavImpersonate_Internalname;
            cmbavImpersonate.CurrentValue = cgiGet( cmbavImpersonate_Internalname);
            AV40Impersonate = cgiGet( cmbavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV40Impersonate", AV40Impersonate);
            AV44Oauth20ClientIdTag = cgiGet( edtavOauth20clientidtag_Internalname);
            AssignAttri(sPrefix, false, "AV44Oauth20ClientIdTag", AV44Oauth20ClientIdTag);
            AV45Oauth20ClientIdValue = cgiGet( edtavOauth20clientidvalue_Internalname);
            AssignAttri(sPrefix, false, "AV45Oauth20ClientIdValue", AV45Oauth20ClientIdValue);
            AV46Oauth20ClientSecretTag = cgiGet( edtavOauth20clientsecrettag_Internalname);
            AssignAttri(sPrefix, false, "AV46Oauth20ClientSecretTag", AV46Oauth20ClientSecretTag);
            AV47Oauth20ClientSecretValue = cgiGet( edtavOauth20clientsecretvalue_Internalname);
            AssignAttri(sPrefix, false, "AV47Oauth20ClientSecretValue", AV47Oauth20ClientSecretValue);
            AV48Oauth20RedirectURLTag = cgiGet( edtavOauth20redirecturltag_Internalname);
            AssignAttri(sPrefix, false, "AV48Oauth20RedirectURLTag", AV48Oauth20RedirectURLTag);
            AV49Oauth20RedirectURLValue = cgiGet( edtavOauth20redirecturlvalue_Internalname);
            AssignAttri(sPrefix, false, "AV49Oauth20RedirectURLValue", AV49Oauth20RedirectURLValue);
            AV104Oauth20RedirectURLisCustom = StringUtil.StrToBool( cgiGet( chkavOauth20redirecturliscustom_Internalname));
            AssignAttri(sPrefix, false, "AV104Oauth20RedirectURLisCustom", AV104Oauth20RedirectURLisCustom);
            AV105Oauth20RedirectToAuthenticate = StringUtil.StrToBool( cgiGet( chkavOauth20redirecttoauthenticate_Internalname));
            AssignAttri(sPrefix, false, "AV105Oauth20RedirectToAuthenticate", AV105Oauth20RedirectToAuthenticate);
            AV12AuthorizeURL = cgiGet( edtavAuthorizeurl_Internalname);
            AssignAttri(sPrefix, false, "AV12AuthorizeURL", AV12AuthorizeURL);
            AV16AuthRespTypeInclude = StringUtil.StrToBool( cgiGet( chkavAuthresptypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV16AuthRespTypeInclude", AV16AuthRespTypeInclude);
            AV17AuthRespTypeTag = cgiGet( edtavAuthresptypetag_Internalname);
            AssignAttri(sPrefix, false, "AV17AuthRespTypeTag", AV17AuthRespTypeTag);
            AV18AuthRespTypeValue = cgiGet( edtavAuthresptypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV18AuthRespTypeValue", AV18AuthRespTypeValue);
            AV19AuthScopeInclude = StringUtil.StrToBool( cgiGet( chkavAuthscopeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV19AuthScopeInclude", AV19AuthScopeInclude);
            AV20AuthScopeTag = cgiGet( edtavAuthscopetag_Internalname);
            AssignAttri(sPrefix, false, "AV20AuthScopeTag", AV20AuthScopeTag);
            AV21AuthScopeValue = cgiGet( edtavAuthscopevalue_Internalname);
            AssignAttri(sPrefix, false, "AV21AuthScopeValue", AV21AuthScopeValue);
            AV110AuthStateIncude = StringUtil.StrToBool( cgiGet( chkavAuthstateincude_Internalname));
            AssignAttri(sPrefix, false, "AV110AuthStateIncude", AV110AuthStateIncude);
            AV22AuthStateTag = cgiGet( edtavAuthstatetag_Internalname);
            AssignAttri(sPrefix, false, "AV22AuthStateTag", AV22AuthStateTag);
            AV9AuthClientIdInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV9AuthClientIdInclude", AV9AuthClientIdInclude);
            AV10AuthClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV10AuthClientSecretInclude", AV10AuthClientSecretInclude);
            AV13AuthRedirURLInclide = StringUtil.StrToBool( cgiGet( chkavAuthredirurlinclide_Internalname));
            AssignAttri(sPrefix, false, "AV13AuthRedirURLInclide", AV13AuthRedirURLInclide);
            AV7AuthAdditionalParameters = cgiGet( edtavAuthadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV7AuthAdditionalParameters", AV7AuthAdditionalParameters);
            AV8AuthAdditionalParametersSD = cgiGet( edtavAuthadditionalparameterssd_Internalname);
            AssignAttri(sPrefix, false, "AV8AuthAdditionalParametersSD", AV8AuthAdditionalParametersSD);
            AV111AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( cgiGet( chkavAuthopenidconnectprotocolenable_Internalname));
            AssignAttri(sPrefix, false, "AV111AuthOpenIDConnectProtocolEnable", AV111AuthOpenIDConnectProtocolEnable);
            AV14AuthResponseAccessCodeTag = cgiGet( edtavAuthresponseaccesscodetag_Internalname);
            AssignAttri(sPrefix, false, "AV14AuthResponseAccessCodeTag", AV14AuthResponseAccessCodeTag);
            AV15AuthResponseErrorDescTag = cgiGet( edtavAuthresponseerrordesctag_Internalname);
            AssignAttri(sPrefix, false, "AV15AuthResponseErrorDescTag", AV15AuthResponseErrorDescTag);
            AV112AuthValidIdToken = StringUtil.StrToBool( cgiGet( chkavAuthvalididtoken_Internalname));
            AssignAttri(sPrefix, false, "AV112AuthValidIdToken", AV112AuthValidIdToken);
            AV113AuthIssuerURL = cgiGet( edtavAuthissuerurl_Internalname);
            AssignAttri(sPrefix, false, "AV113AuthIssuerURL", AV113AuthIssuerURL);
            AV114AuthCertificatePathFileName = cgiGet( edtavAuthcertificatepathfilename_Internalname);
            AssignAttri(sPrefix, false, "AV114AuthCertificatePathFileName", AV114AuthCertificatePathFileName);
            AV115AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( cgiGet( chkavAuthallowonlyuseremailverified_Internalname));
            AssignAttri(sPrefix, false, "AV115AuthAllowOnlyUserEmailVerified", AV115AuthAllowOnlyUserEmailVerified);
            AV72TokenURL = cgiGet( edtavTokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV72TokenURL", AV72TokenURL);
            cmbavTokenmethod.Name = cmbavTokenmethod_Internalname;
            cmbavTokenmethod.CurrentValue = cgiGet( cmbavTokenmethod_Internalname);
            AV62TokenMethod = cgiGet( cmbavTokenmethod_Internalname);
            AssignAttri(sPrefix, false, "AV62TokenMethod", AV62TokenMethod);
            AV60TokenHeaderKeyTag = cgiGet( edtavTokenheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV60TokenHeaderKeyTag", AV60TokenHeaderKeyTag);
            AV61TokenHeaderKeyValue = cgiGet( edtavTokenheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV61TokenHeaderKeyValue", AV61TokenHeaderKeyValue);
            AV106TokenHeaderAuthenticationInclude = StringUtil.StrToBool( cgiGet( chkavTokenheaderauthenticationinclude_Internalname));
            AssignAttri(sPrefix, false, "AV106TokenHeaderAuthenticationInclude", AV106TokenHeaderAuthenticationInclude);
            cmbavTokenheaderauthenticationmethod.Name = cmbavTokenheaderauthenticationmethod_Internalname;
            cmbavTokenheaderauthenticationmethod.CurrentValue = cgiGet( cmbavTokenheaderauthenticationmethod_Internalname);
            AV107TokenHeaderAuthenticationMethod = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavTokenheaderauthenticationmethod_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV107TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0));
            AV108TokenHeaderAuthenticationRealm = cgiGet( edtavTokenheaderauthenticationrealm_Internalname);
            AssignAttri(sPrefix, false, "AV108TokenHeaderAuthenticationRealm", AV108TokenHeaderAuthenticationRealm);
            AV109TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( cgiGet( chkavTokenheaderauthorizationbasicinclude_Internalname));
            AssignAttri(sPrefix, false, "AV109TokenHeaderAuthorizationBasicInclude", AV109TokenHeaderAuthorizationBasicInclude);
            AV57TokenGrantTypeInclude = StringUtil.StrToBool( cgiGet( chkavTokengranttypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV57TokenGrantTypeInclude", AV57TokenGrantTypeInclude);
            AV58TokenGrantTypeTag = cgiGet( edtavTokengranttypetag_Internalname);
            AssignAttri(sPrefix, false, "AV58TokenGrantTypeTag", AV58TokenGrantTypeTag);
            AV59TokenGrantTypeValue = cgiGet( edtavTokengranttypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV59TokenGrantTypeValue", AV59TokenGrantTypeValue);
            AV53TokenAccessCodeInclude = StringUtil.StrToBool( cgiGet( chkavTokenaccesscodeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV53TokenAccessCodeInclude", AV53TokenAccessCodeInclude);
            AV55TokenCliIdInclude = StringUtil.StrToBool( cgiGet( chkavTokencliidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV55TokenCliIdInclude", AV55TokenCliIdInclude);
            AV56TokenCliSecretInclude = StringUtil.StrToBool( cgiGet( chkavTokenclisecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV56TokenCliSecretInclude", AV56TokenCliSecretInclude);
            AV63TokenRedirectURLInclude = StringUtil.StrToBool( cgiGet( chkavTokenredirecturlinclude_Internalname));
            AssignAttri(sPrefix, false, "AV63TokenRedirectURLInclude", AV63TokenRedirectURLInclude);
            AV54TokenAdditionalParameters = cgiGet( edtavTokenadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV54TokenAdditionalParameters", AV54TokenAdditionalParameters);
            AV65TokenResponseAccessTokenTag = cgiGet( edtavTokenresponseaccesstokentag_Internalname);
            AssignAttri(sPrefix, false, "AV65TokenResponseAccessTokenTag", AV65TokenResponseAccessTokenTag);
            AV70TokenResponseTokenTypeTag = cgiGet( edtavTokenresponsetokentypetag_Internalname);
            AssignAttri(sPrefix, false, "AV70TokenResponseTokenTypeTag", AV70TokenResponseTokenTypeTag);
            AV67TokenResponseExpiresInTag = cgiGet( edtavTokenresponseexpiresintag_Internalname);
            AssignAttri(sPrefix, false, "AV67TokenResponseExpiresInTag", AV67TokenResponseExpiresInTag);
            AV69TokenResponseScopeTag = cgiGet( edtavTokenresponsescopetag_Internalname);
            AssignAttri(sPrefix, false, "AV69TokenResponseScopeTag", AV69TokenResponseScopeTag);
            AV71TokenResponseUserIdTag = cgiGet( edtavTokenresponseuseridtag_Internalname);
            AssignAttri(sPrefix, false, "AV71TokenResponseUserIdTag", AV71TokenResponseUserIdTag);
            AV68TokenResponseRefreshTokenTag = cgiGet( edtavTokenresponserefreshtokentag_Internalname);
            AssignAttri(sPrefix, false, "AV68TokenResponseRefreshTokenTag", AV68TokenResponseRefreshTokenTag);
            AV66TokenResponseErrorDescriptionTag = cgiGet( edtavTokenresponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV66TokenResponseErrorDescriptionTag", AV66TokenResponseErrorDescriptionTag);
            AV23AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( cgiGet( chkavAutovalidateexternaltokenandrefresh_Internalname));
            AssignAttri(sPrefix, false, "AV23AutovalidateExternalTokenAndRefresh", AV23AutovalidateExternalTokenAndRefresh);
            AV64TokenRefreshTokenURL = cgiGet( edtavTokenrefreshtokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV64TokenRefreshTokenURL", AV64TokenRefreshTokenURL);
            AV100UserInfoURL = cgiGet( edtavUserinfourl_Internalname);
            AssignAttri(sPrefix, false, "AV100UserInfoURL", AV100UserInfoURL);
            cmbavUserinfomethod.Name = cmbavUserinfomethod_Internalname;
            cmbavUserinfomethod.CurrentValue = cgiGet( cmbavUserinfomethod_Internalname);
            AV84UserInfoMethod = cgiGet( cmbavUserinfomethod_Internalname);
            AssignAttri(sPrefix, false, "AV84UserInfoMethod", AV84UserInfoMethod);
            AV82UserInfoHeaderKeyTag = cgiGet( edtavUserinfoheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV82UserInfoHeaderKeyTag", AV82UserInfoHeaderKeyTag);
            AV83UserInfoHeaderKeyValue = cgiGet( edtavUserinfoheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV83UserInfoHeaderKeyValue", AV83UserInfoHeaderKeyValue);
            AV75UserInfoAccessTokenInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoaccesstokeninclude_Internalname));
            AssignAttri(sPrefix, false, "AV75UserInfoAccessTokenInclude", AV75UserInfoAccessTokenInclude);
            AV76UserInfoAccessTokenName = cgiGet( edtavUserinfoaccesstokenname_Internalname);
            AssignAttri(sPrefix, false, "AV76UserInfoAccessTokenName", AV76UserInfoAccessTokenName);
            AV78UserInfoClientIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV78UserInfoClientIdInclude", AV78UserInfoClientIdInclude);
            AV79UserInfoClientIdName = cgiGet( edtavUserinfoclientidname_Internalname);
            AssignAttri(sPrefix, false, "AV79UserInfoClientIdName", AV79UserInfoClientIdName);
            AV80UserInfoClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV80UserInfoClientSecretInclude", AV80UserInfoClientSecretInclude);
            AV81UserInfoClientSecretName = cgiGet( edtavUserinfoclientsecretname_Internalname);
            AssignAttri(sPrefix, false, "AV81UserInfoClientSecretName", AV81UserInfoClientSecretName);
            AV101UserInfoUserIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfouseridinclude_Internalname));
            AssignAttri(sPrefix, false, "AV101UserInfoUserIdInclude", AV101UserInfoUserIdInclude);
            AV77UserInfoAdditionalParameters = cgiGet( edtavUserinfoadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV77UserInfoAdditionalParameters", AV77UserInfoAdditionalParameters);
            AV87UserInfoResponseUserEmailTag = cgiGet( edtavUserinforesponseuseremailtag_Internalname);
            AssignAttri(sPrefix, false, "AV87UserInfoResponseUserEmailTag", AV87UserInfoResponseUserEmailTag);
            AV99UserInfoResponseUserVerifiedEmailTag = cgiGet( edtavUserinforesponseuserverifiedemailtag_Internalname);
            AssignAttri(sPrefix, false, "AV99UserInfoResponseUserVerifiedEmailTag", AV99UserInfoResponseUserVerifiedEmailTag);
            AV88UserInfoResponseUserExternalIdTag = cgiGet( edtavUserinforesponseuserexternalidtag_Internalname);
            AssignAttri(sPrefix, false, "AV88UserInfoResponseUserExternalIdTag", AV88UserInfoResponseUserExternalIdTag);
            AV95UserInfoResponseUserNameTag = cgiGet( edtavUserinforesponseusernametag_Internalname);
            AssignAttri(sPrefix, false, "AV95UserInfoResponseUserNameTag", AV95UserInfoResponseUserNameTag);
            AV89UserInfoResponseUserFirstNameTag = cgiGet( edtavUserinforesponseuserfirstnametag_Internalname);
            AssignAttri(sPrefix, false, "AV89UserInfoResponseUserFirstNameTag", AV89UserInfoResponseUserFirstNameTag);
            AV93UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( cgiGet( chkavUserinforesponseuserlastnamegenauto_Internalname));
            AssignAttri(sPrefix, false, "AV93UserInfoResponseUserLastNameGenAuto", AV93UserInfoResponseUserLastNameGenAuto);
            AV94UserInfoResponseUserLastNameTag = cgiGet( edtavUserinforesponseuserlastnametag_Internalname);
            AssignAttri(sPrefix, false, "AV94UserInfoResponseUserLastNameTag", AV94UserInfoResponseUserLastNameTag);
            AV90UserInfoResponseUserGenderTag = cgiGet( edtavUserinforesponseusergendertag_Internalname);
            AssignAttri(sPrefix, false, "AV90UserInfoResponseUserGenderTag", AV90UserInfoResponseUserGenderTag);
            AV91UserInfoResponseUserGenderValues = cgiGet( edtavUserinforesponseusergendervalues_Internalname);
            AssignAttri(sPrefix, false, "AV91UserInfoResponseUserGenderValues", AV91UserInfoResponseUserGenderValues);
            AV86UserInfoResponseUserBirthdayTag = cgiGet( edtavUserinforesponseuserbirthdaytag_Internalname);
            AssignAttri(sPrefix, false, "AV86UserInfoResponseUserBirthdayTag", AV86UserInfoResponseUserBirthdayTag);
            AV97UserInfoResponseUserURLImageTag = cgiGet( edtavUserinforesponseuserurlimagetag_Internalname);
            AssignAttri(sPrefix, false, "AV97UserInfoResponseUserURLImageTag", AV97UserInfoResponseUserURLImageTag);
            AV98UserInfoResponseUserURLProfileTag = cgiGet( edtavUserinforesponseuserurlprofiletag_Internalname);
            AssignAttri(sPrefix, false, "AV98UserInfoResponseUserURLProfileTag", AV98UserInfoResponseUserURLProfileTag);
            AV92UserInfoResponseUserLanguageTag = cgiGet( edtavUserinforesponseuserlanguagetag_Internalname);
            AssignAttri(sPrefix, false, "AV92UserInfoResponseUserLanguageTag", AV92UserInfoResponseUserLanguageTag);
            AV96UserInfoResponseUserTimeZoneTag = cgiGet( edtavUserinforesponseusertimezonetag_Internalname);
            AssignAttri(sPrefix, false, "AV96UserInfoResponseUserTimeZoneTag", AV96UserInfoResponseUserTimeZoneTag);
            AV85UserInfoResponseErrorDescriptionTag = cgiGet( edtavUserinforesponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV85UserInfoResponseErrorDescriptionTag", AV85UserInfoResponseErrorDescriptionTag);
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
         E173R2 ();
         if (returnInSub) return;
      }

      protected void E173R2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         divLineseparatorcontent_advancedconfigurationls_Visible = 0;
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedconfigurationls_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_advancedconfigurationls_Visible), 5, 0), true);
         divLineseparatorcontent_advancedconfigurationls_Class = "Section_LineSeparatorContentClose";
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedconfigurationls_Internalname, "Class", divLineseparatorcontent_advancedconfigurationls_Class, true);
         divLineseparatorheader_advancedconfigurationls_Class = "Section_LineSeparatorClose";
         AssignProp(sPrefix, false, divLineseparatorheader_advancedconfigurationls_Internalname, "Class", divLineseparatorheader_advancedconfigurationls_Class, true);
         divLineseparatorcontent_advancedconfigurationtokenls_Visible = 0;
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedconfigurationtokenls_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_advancedconfigurationtokenls_Visible), 5, 0), true);
         divLineseparatorcontent_advancedconfigurationtokenls_Class = "Section_LineSeparatorContentClose";
         AssignProp(sPrefix, false, divLineseparatorcontent_advancedconfigurationtokenls_Internalname, "Class", divLineseparatorcontent_advancedconfigurationtokenls_Class, true);
         divLineseparatorheader_advancedconfigurationtokenls_Class = "Section_LineSeparatorClose";
         AssignProp(sPrefix, false, divLineseparatorheader_advancedconfigurationtokenls_Internalname, "Class", divLineseparatorheader_advancedconfigurationtokenls_Class, true);
         divLineseparatorcontent_advanceduserconfiguration_Visible = 0;
         AssignProp(sPrefix, false, divLineseparatorcontent_advanceduserconfiguration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_advanceduserconfiguration_Visible), 5, 0), true);
         divLineseparatorcontent_advanceduserconfiguration_Class = "Section_LineSeparatorContentClose";
         AssignProp(sPrefix, false, divLineseparatorcontent_advanceduserconfiguration_Internalname, "Class", divLineseparatorcontent_advanceduserconfiguration_Class, true);
         divLineseparatorheader_advanceduserconfiguration_Class = "Section_LineSeparatorClose";
         AssignProp(sPrefix, false, divLineseparatorheader_advanceduserconfiguration_Internalname, "Class", divLineseparatorheader_advanceduserconfiguration_Class, true);
         subGrid_Backcolorstyle = 3;
      }

      protected void E183R2( )
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
         if ( (0==AV25CurrentPage_Grid) )
         {
            AV25CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV25CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV25CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV25CurrentPage_Grid), "ZZZ9"), context));
         }
         AV50Reload_Grid = true;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         divContenttable_Class = "Section";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         /* Execute user subroutine: 'INITAUTHENTICATIONOAUTH20' */
         S262 ();
         if (returnInSub) return;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               bttConfirm_Visible = 0;
               AssignProp(sPrefix, false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            }
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
            bttConfirm_Caption = context.GetMessage( "Delete", "");
            AssignProp(sPrefix, false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            bttAdd_Visible = 0;
            AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
            edtavName_Enabled = 0;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
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
            edtavOauth20clientidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientidtag_Enabled), 5, 0), true);
            edtavOauth20clientidvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientidvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientidvalue_Enabled), 5, 0), true);
            edtavOauth20clientsecrettag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientsecrettag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientsecrettag_Enabled), 5, 0), true);
            edtavOauth20clientsecretvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientsecretvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientsecretvalue_Enabled), 5, 0), true);
            edtavOauth20redirecturltag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20redirecturltag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20redirecturltag_Enabled), 5, 0), true);
            edtavOauth20redirecturlvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20redirecturlvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20redirecturlvalue_Enabled), 5, 0), true);
            chkavOauth20redirecturliscustom.Enabled = 0;
            AssignProp(sPrefix, false, chkavOauth20redirecturliscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOauth20redirecturliscustom.Enabled), 5, 0), true);
            chkavOauth20redirecttoauthenticate.Enabled = 0;
            AssignProp(sPrefix, false, chkavOauth20redirecttoauthenticate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOauth20redirecttoauthenticate.Enabled), 5, 0), true);
            edtavAuthorizeurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthorizeurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthorizeurl_Enabled), 5, 0), true);
            chkavAuthresptypeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthresptypeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthresptypeinclude.Enabled), 5, 0), true);
            edtavAuthresptypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresptypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresptypetag_Enabled), 5, 0), true);
            edtavAuthresptypevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresptypevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresptypevalue_Enabled), 5, 0), true);
            chkavAuthscopeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthscopeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthscopeinclude.Enabled), 5, 0), true);
            edtavAuthscopetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthscopetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthscopetag_Enabled), 5, 0), true);
            edtavAuthscopevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthscopevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthscopevalue_Enabled), 5, 0), true);
            chkavAuthstateincude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthstateincude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthstateincude.Enabled), 5, 0), true);
            edtavAuthstatetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthstatetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthstatetag_Enabled), 5, 0), true);
            chkavAuthclientidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthclientidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthclientidinclude.Enabled), 5, 0), true);
            chkavAuthclientsecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthclientsecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthclientsecretinclude.Enabled), 5, 0), true);
            chkavAuthredirurlinclide.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthredirurlinclide_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthredirurlinclide.Enabled), 5, 0), true);
            edtavAuthadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthadditionalparameters_Enabled), 5, 0), true);
            edtavAuthadditionalparameterssd_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthadditionalparameterssd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthadditionalparameterssd_Enabled), 5, 0), true);
            chkavAuthopenidconnectprotocolenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthopenidconnectprotocolenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthopenidconnectprotocolenable.Enabled), 5, 0), true);
            chkavAuthvalididtoken.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthvalididtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthvalididtoken.Enabled), 5, 0), true);
            edtavAuthcertificatepathfilename_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthcertificatepathfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthcertificatepathfilename_Enabled), 5, 0), true);
            edtavAuthissuerurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthissuerurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthissuerurl_Enabled), 5, 0), true);
            chkavAuthallowonlyuseremailverified.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthallowonlyuseremailverified_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthallowonlyuseremailverified.Enabled), 5, 0), true);
            edtavAuthresponseaccesscodetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresponseaccesscodetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresponseaccesscodetag_Enabled), 5, 0), true);
            edtavAuthresponseerrordesctag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresponseerrordesctag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresponseerrordesctag_Enabled), 5, 0), true);
            edtavTokenurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenurl_Enabled), 5, 0), true);
            cmbavTokenmethod.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTokenmethod.Enabled), 5, 0), true);
            edtavTokenheaderkeytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenheaderkeytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenheaderkeytag_Enabled), 5, 0), true);
            edtavTokenheaderkeyvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenheaderkeyvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenheaderkeyvalue_Enabled), 5, 0), true);
            chkavTokenheaderauthorizationbasicinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenheaderauthorizationbasicinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenheaderauthorizationbasicinclude.Enabled), 5, 0), true);
            chkavTokengranttypeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokengranttypeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokengranttypeinclude.Enabled), 5, 0), true);
            edtavTokengranttypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokengranttypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokengranttypetag_Enabled), 5, 0), true);
            edtavTokengranttypevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokengranttypevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokengranttypevalue_Enabled), 5, 0), true);
            chkavTokenaccesscodeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenaccesscodeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenaccesscodeinclude.Enabled), 5, 0), true);
            chkavTokencliidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokencliidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokencliidinclude.Enabled), 5, 0), true);
            chkavTokenclisecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenclisecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenclisecretinclude.Enabled), 5, 0), true);
            chkavTokenredirecturlinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenredirecturlinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenredirecturlinclude.Enabled), 5, 0), true);
            edtavTokenadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenadditionalparameters_Enabled), 5, 0), true);
            edtavTokenresponseaccesstokentag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseaccesstokentag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseaccesstokentag_Enabled), 5, 0), true);
            edtavTokenresponsetokentypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponsetokentypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponsetokentypetag_Enabled), 5, 0), true);
            edtavTokenresponseexpiresintag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseexpiresintag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseexpiresintag_Enabled), 5, 0), true);
            edtavTokenresponsescopetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponsescopetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponsescopetag_Enabled), 5, 0), true);
            edtavTokenresponseuseridtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseuseridtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseuseridtag_Enabled), 5, 0), true);
            edtavTokenresponserefreshtokentag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponserefreshtokentag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponserefreshtokentag_Enabled), 5, 0), true);
            edtavTokenresponseerrordescriptiontag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseerrordescriptiontag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseerrordescriptiontag_Enabled), 5, 0), true);
            chkavAutovalidateexternaltokenandrefresh.Enabled = 0;
            AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAutovalidateexternaltokenandrefresh.Enabled), 5, 0), true);
            edtavTokenrefreshtokenurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenrefreshtokenurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenrefreshtokenurl_Enabled), 5, 0), true);
            edtavUserinfourl_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfourl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfourl_Enabled), 5, 0), true);
            cmbavUserinfomethod.Enabled = 0;
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUserinfomethod.Enabled), 5, 0), true);
            edtavUserinfoheaderkeytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoheaderkeytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoheaderkeytag_Enabled), 5, 0), true);
            edtavUserinfoheaderkeyvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoheaderkeyvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoheaderkeyvalue_Enabled), 5, 0), true);
            chkavUserinfoaccesstokeninclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoaccesstokeninclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoaccesstokeninclude.Enabled), 5, 0), true);
            edtavUserinfoaccesstokenname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoaccesstokenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoaccesstokenname_Enabled), 5, 0), true);
            chkavUserinfoclientidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoclientidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoclientidinclude.Enabled), 5, 0), true);
            edtavUserinfoclientidname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoclientidname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoclientidname_Enabled), 5, 0), true);
            chkavUserinfoclientsecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoclientsecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoclientsecretinclude.Enabled), 5, 0), true);
            edtavUserinfoclientsecretname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoclientsecretname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoclientsecretname_Enabled), 5, 0), true);
            chkavUserinfouseridinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfouseridinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfouseridinclude.Enabled), 5, 0), true);
            edtavUserinfoadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoadditionalparameters_Enabled), 5, 0), true);
            edtavUserinforesponseuseremailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuseremailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuseremailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserverifiedemailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserverifiedemailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserverifiedemailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserexternalidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserexternalidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserexternalidtag_Enabled), 5, 0), true);
            edtavUserinforesponseusernametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusernametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusernametag_Enabled), 5, 0), true);
            edtavUserinforesponseuserfirstnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserfirstnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserfirstnametag_Enabled), 5, 0), true);
            chkavUserinforesponseuserlastnamegenauto.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinforesponseuserlastnamegenauto.Enabled), 5, 0), true);
            edtavUserinforesponseuserlastnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendertag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendertag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendertag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendervalues_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendervalues_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendervalues_Enabled), 5, 0), true);
            edtavUserinforesponseuserbirthdaytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserbirthdaytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserbirthdaytag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlimagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlimagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlimagetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlprofiletag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlprofiletag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlprofiletag_Enabled), 5, 0), true);
            edtavUserinforesponseuserlanguagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlanguagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlanguagetag_Enabled), 5, 0), true);
            edtavUserinforesponseusertimezonetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusertimezonetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusertimezonetag_Enabled), 5, 0), true);
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

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E193R2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S152 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E203R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV39I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV39I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV39I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39I_LoadCount_Grid), "ZZZ9"), context));
         AV32Exit_Grid = false;
         while ( true )
         {
            AV39I_LoadCount_Grid = (short)(AV39I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV39I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV39I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S172 ();
            if (returnInSub) return;
            edtavDelete_action_gximage = "K2BActionDelete";
            AV26Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV26Delete_Action);
            AV119Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S182 ();
            if (returnInSub) return;
            if ( AV32Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 602;
            }
            sendrow_6022( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_602_Refreshing )
            {
               context.DoAjaxLoad(602, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV39I_LoadCount_Grid == 1 )
         {
            AV51sdt = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserproperties;
         }
         if ( AV51sdt.Count >= AV39I_LoadCount_Grid )
         {
            AV28DynamicPropName = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV51sdt.Item(AV39I_LoadCount_Grid)).gxTpr_Id;
            AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV28DynamicPropName);
            AV29DynamicPropTag = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV51sdt.Item(AV39I_LoadCount_Grid)).gxTpr_Value;
            AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV29DynamicPropTag);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtavDelete_action_Visible = 0;
               AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_action_Visible), 5, 0), !bGXsfl_602_Refreshing);
               edtavDynamicpropname_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_602_Refreshing);
               edtavDynamicproptag_Enabled = 0;
               AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_602_Refreshing);
            }
         }
         else
         {
            AV32Exit_Grid = true;
         }
      }

      protected void S182( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV37GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV120Pgmname,  AV37GridStateKey, out  AV35GridState) ;
         AV35GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV120Pgmname,  AV37GridStateKey,  AV35GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV37GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV120Pgmname,  AV37GridStateKey, out  AV35GridState) ;
      }

      protected void E153R2( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         edtavDelete_action_gximage = "K2BActionDelete";
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "gximage", edtavDelete_action_gximage, !bGXsfl_602_Refreshing);
         AV26Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action)) ? AV119Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV26Delete_Action))), !bGXsfl_602_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV26Delete_Action), true);
         AV119Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action)) ? AV119Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV26Delete_Action))), !bGXsfl_602_Refreshing);
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV26Delete_Action), true);
         edtavDelete_action_Visible = 1;
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_action_Visible), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicpropname_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicpropname_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicproptag_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicproptag_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_602_Refreshing);
         sendrow_6022( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_602_Refreshing )
         {
            context.DoAjaxLoad(602, GridRow);
         }
      }

      protected void E213R2( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11AuthenticationTypeOauth20", AV11AuthenticationTypeOauth20);
      }

      protected void S202( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         edtavDelete_action_Visible = 0;
         AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_action_Visible), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicpropname_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_602_Refreshing);
         edtavDynamicproptag_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_602_Refreshing);
         AV28DynamicPropName = "";
         AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV28DynamicPropName);
         AV29DynamicPropTag = "";
         AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV29DynamicPropTag);
         AV11AuthenticationTypeOauth20.gxTpr_Name = AV43Name;
         AV11AuthenticationTypeOauth20.removeuserinfoproperty( AV28DynamicPropName, out  AV31Errors);
      }

      protected void S232( )
      {
         /* 'USERINFOLASTNAMEFIELDTAG' Routine */
         returnInSub = false;
         if ( AV93UserInfoResponseUserLastNameGenAuto )
         {
            edtavUserinforesponseuserlastnametag_Visible = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            lblTbuserlastnamehelp_Caption = "*Generate Last Name automatically using the first name spaces";
            AssignProp(sPrefix, false, lblTbuserlastnamehelp_Internalname, "Caption", lblTbuserlastnamehelp_Caption, true);
         }
         else
         {
            edtavUserinforesponseuserlastnametag_Visible = 1;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            lblTbuserlastnamehelp_Caption = "";
            AssignProp(sPrefix, false, lblTbuserlastnamehelp_Internalname, "Caption", lblTbuserlastnamehelp_Caption, true);
         }
      }

      protected void S262( )
      {
         /* 'INITAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S272 ();
         if (returnInSub) return;
         AV11AuthenticationTypeOauth20.load( AV43Name);
         AV43Name = AV11AuthenticationTypeOauth20.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV43Name", AV43Name);
         AV41IsEnable = AV11AuthenticationTypeOauth20.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV41IsEnable", AV41IsEnable);
         AV27Dsc = AV11AuthenticationTypeOauth20.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV27Dsc", AV27Dsc);
         AV52SmallImageName = AV11AuthenticationTypeOauth20.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV52SmallImageName", AV52SmallImageName);
         AV24BigImageName = AV11AuthenticationTypeOauth20.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV24BigImageName", AV24BigImageName);
         AV40Impersonate = AV11AuthenticationTypeOauth20.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV40Impersonate", AV40Impersonate);
         AV44Oauth20ClientIdTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV44Oauth20ClientIdTag", AV44Oauth20ClientIdTag);
         AV45Oauth20ClientIdValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value;
         AssignAttri(sPrefix, false, "AV45Oauth20ClientIdValue", AV45Oauth20ClientIdValue);
         AV46Oauth20ClientSecretTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV46Oauth20ClientSecretTag", AV46Oauth20ClientSecretTag);
         AV47Oauth20ClientSecretValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value;
         AssignAttri(sPrefix, false, "AV47Oauth20ClientSecretValue", AV47Oauth20ClientSecretValue);
         AV48Oauth20RedirectURLTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name;
         AssignAttri(sPrefix, false, "AV48Oauth20RedirectURLTag", AV48Oauth20RedirectURLTag);
         AV49Oauth20RedirectURLValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value;
         AssignAttri(sPrefix, false, "AV49Oauth20RedirectURLValue", AV49Oauth20RedirectURLValue);
         AV104Oauth20RedirectURLisCustom = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_iscustom;
         AssignAttri(sPrefix, false, "AV104Oauth20RedirectURLisCustom", AV104Oauth20RedirectURLisCustom);
         AV105Oauth20RedirectToAuthenticate = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecttoauthenticate;
         AssignAttri(sPrefix, false, "AV105Oauth20RedirectToAuthenticate", AV105Oauth20RedirectToAuthenticate);
         AV12AuthorizeURL = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV12AuthorizeURL", AV12AuthorizeURL);
         AV16AuthRespTypeInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_include;
         AssignAttri(sPrefix, false, "AV16AuthRespTypeInclude", AV16AuthRespTypeInclude);
         AV17AuthRespTypeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name;
         AssignAttri(sPrefix, false, "AV17AuthRespTypeTag", AV17AuthRespTypeTag);
         AV18AuthRespTypeValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value;
         AssignAttri(sPrefix, false, "AV18AuthRespTypeValue", AV18AuthRespTypeValue);
         AV19AuthScopeInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include;
         AssignAttri(sPrefix, false, "AV19AuthScopeInclude", AV19AuthScopeInclude);
         AV20AuthScopeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name;
         AssignAttri(sPrefix, false, "AV20AuthScopeTag", AV20AuthScopeTag);
         AV21AuthScopeValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value;
         AssignAttri(sPrefix, false, "AV21AuthScopeValue", AV21AuthScopeValue);
         AV110AuthStateIncude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include;
         AssignAttri(sPrefix, false, "AV110AuthStateIncude", AV110AuthStateIncude);
         AV22AuthStateTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name;
         AssignAttri(sPrefix, false, "AV22AuthStateTag", AV22AuthStateTag);
         AV9AuthClientIdInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV9AuthClientIdInclude", AV9AuthClientIdInclude);
         AV10AuthClientSecretInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV10AuthClientSecretInclude", AV10AuthClientSecretInclude);
         AV13AuthRedirURLInclide = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV13AuthRedirURLInclide", AV13AuthRedirURLInclide);
         AV7AuthAdditionalParameters = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV7AuthAdditionalParameters", AV7AuthAdditionalParameters);
         AV8AuthAdditionalParametersSD = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd;
         AssignAttri(sPrefix, false, "AV8AuthAdditionalParametersSD", AV8AuthAdditionalParametersSD);
         AV111AuthOpenIDConnectProtocolEnable = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV111AuthOpenIDConnectProtocolEnable", AV111AuthOpenIDConnectProtocolEnable);
         AV112AuthValidIdToken = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken;
         AssignAttri(sPrefix, false, "AV112AuthValidIdToken", AV112AuthValidIdToken);
         AV114AuthCertificatePathFileName = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename;
         AssignAttri(sPrefix, false, "AV114AuthCertificatePathFileName", AV114AuthCertificatePathFileName);
         AV113AuthIssuerURL = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl;
         AssignAttri(sPrefix, false, "AV113AuthIssuerURL", AV113AuthIssuerURL);
         AV115AuthAllowOnlyUserEmailVerified = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified;
         AssignAttri(sPrefix, false, "AV115AuthAllowOnlyUserEmailVerified", AV115AuthAllowOnlyUserEmailVerified);
         AV14AuthResponseAccessCodeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name;
         AssignAttri(sPrefix, false, "AV14AuthResponseAccessCodeTag", AV14AuthResponseAccessCodeTag);
         AV15AuthResponseErrorDescTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV15AuthResponseErrorDescTag", AV15AuthResponseErrorDescTag);
         AV72TokenURL = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV72TokenURL", AV72TokenURL);
         AV62TokenMethod = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV62TokenMethod", AV62TokenMethod);
         AV60TokenHeaderKeyTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV60TokenHeaderKeyTag", AV60TokenHeaderKeyTag);
         AV61TokenHeaderKeyValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV61TokenHeaderKeyValue", AV61TokenHeaderKeyValue);
         AV106TokenHeaderAuthenticationInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_include;
         AssignAttri(sPrefix, false, "AV106TokenHeaderAuthenticationInclude", AV106TokenHeaderAuthenticationInclude);
         AV107TokenHeaderAuthenticationMethod = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_method;
         AssignAttri(sPrefix, false, "AV107TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV107TokenHeaderAuthenticationMethod), 4, 0));
         AV108TokenHeaderAuthenticationRealm = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_realm;
         AssignAttri(sPrefix, false, "AV108TokenHeaderAuthenticationRealm", AV108TokenHeaderAuthenticationRealm);
         AV109TokenHeaderAuthorizationBasicInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authorizationbasic_include;
         AssignAttri(sPrefix, false, "AV109TokenHeaderAuthorizationBasicInclude", AV109TokenHeaderAuthorizationBasicInclude);
         AV57TokenGrantTypeInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include;
         AssignAttri(sPrefix, false, "AV57TokenGrantTypeInclude", AV57TokenGrantTypeInclude);
         AV58TokenGrantTypeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name;
         AssignAttri(sPrefix, false, "AV58TokenGrantTypeTag", AV58TokenGrantTypeTag);
         AV59TokenGrantTypeValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value;
         AssignAttri(sPrefix, false, "AV59TokenGrantTypeValue", AV59TokenGrantTypeValue);
         AV53TokenAccessCodeInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include;
         AssignAttri(sPrefix, false, "AV53TokenAccessCodeInclude", AV53TokenAccessCodeInclude);
         AV55TokenCliIdInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV55TokenCliIdInclude", AV55TokenCliIdInclude);
         AV56TokenCliSecretInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV56TokenCliSecretInclude", AV56TokenCliSecretInclude);
         AV63TokenRedirectURLInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV63TokenRedirectURLInclude", AV63TokenRedirectURLInclude);
         AV54TokenAdditionalParameters = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV54TokenAdditionalParameters", AV54TokenAdditionalParameters);
         AV65TokenResponseAccessTokenTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name;
         AssignAttri(sPrefix, false, "AV65TokenResponseAccessTokenTag", AV65TokenResponseAccessTokenTag);
         AV70TokenResponseTokenTypeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name;
         AssignAttri(sPrefix, false, "AV70TokenResponseTokenTypeTag", AV70TokenResponseTokenTypeTag);
         AV67TokenResponseExpiresInTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name;
         AssignAttri(sPrefix, false, "AV67TokenResponseExpiresInTag", AV67TokenResponseExpiresInTag);
         AV69TokenResponseScopeTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name;
         AssignAttri(sPrefix, false, "AV69TokenResponseScopeTag", AV69TokenResponseScopeTag);
         AV71TokenResponseUserIdTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name;
         AssignAttri(sPrefix, false, "AV71TokenResponseUserIdTag", AV71TokenResponseUserIdTag);
         AV68TokenResponseRefreshTokenTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name;
         AssignAttri(sPrefix, false, "AV68TokenResponseRefreshTokenTag", AV68TokenResponseRefreshTokenTag);
         AV66TokenResponseErrorDescriptionTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV66TokenResponseErrorDescriptionTag", AV66TokenResponseErrorDescriptionTag);
         AV23AutovalidateExternalTokenAndRefresh = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh;
         AssignAttri(sPrefix, false, "AV23AutovalidateExternalTokenAndRefresh", AV23AutovalidateExternalTokenAndRefresh);
         AV64TokenRefreshTokenURL = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url;
         AssignAttri(sPrefix, false, "AV64TokenRefreshTokenURL", AV64TokenRefreshTokenURL);
         AV100UserInfoURL = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV100UserInfoURL", AV100UserInfoURL);
         AV84UserInfoMethod = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV84UserInfoMethod", AV84UserInfoMethod);
         AV82UserInfoHeaderKeyTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV82UserInfoHeaderKeyTag", AV82UserInfoHeaderKeyTag);
         AV83UserInfoHeaderKeyValue = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV83UserInfoHeaderKeyValue", AV83UserInfoHeaderKeyValue);
         AV75UserInfoAccessTokenInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include;
         AssignAttri(sPrefix, false, "AV75UserInfoAccessTokenInclude", AV75UserInfoAccessTokenInclude);
         AV76UserInfoAccessTokenName = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name;
         AssignAttri(sPrefix, false, "AV76UserInfoAccessTokenName", AV76UserInfoAccessTokenName);
         AV78UserInfoClientIdInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV78UserInfoClientIdInclude", AV78UserInfoClientIdInclude);
         AV79UserInfoClientIdName = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV79UserInfoClientIdName", AV79UserInfoClientIdName);
         AV80UserInfoClientSecretInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV80UserInfoClientSecretInclude", AV80UserInfoClientSecretInclude);
         AV81UserInfoClientSecretName = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV81UserInfoClientSecretName", AV81UserInfoClientSecretName);
         AV101UserInfoUserIdInclude = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include;
         AssignAttri(sPrefix, false, "AV101UserInfoUserIdInclude", AV101UserInfoUserIdInclude);
         AV77UserInfoAdditionalParameters = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV77UserInfoAdditionalParameters", AV77UserInfoAdditionalParameters);
         AV87UserInfoResponseUserEmailTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name;
         AssignAttri(sPrefix, false, "AV87UserInfoResponseUserEmailTag", AV87UserInfoResponseUserEmailTag);
         AV99UserInfoResponseUserVerifiedEmailTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name;
         AssignAttri(sPrefix, false, "AV99UserInfoResponseUserVerifiedEmailTag", AV99UserInfoResponseUserVerifiedEmailTag);
         AV88UserInfoResponseUserExternalIdTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name;
         AssignAttri(sPrefix, false, "AV88UserInfoResponseUserExternalIdTag", AV88UserInfoResponseUserExternalIdTag);
         AV95UserInfoResponseUserNameTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name;
         AssignAttri(sPrefix, false, "AV95UserInfoResponseUserNameTag", AV95UserInfoResponseUserNameTag);
         AV89UserInfoResponseUserFirstNameTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name;
         AssignAttri(sPrefix, false, "AV89UserInfoResponseUserFirstNameTag", AV89UserInfoResponseUserFirstNameTag);
         AV93UserInfoResponseUserLastNameGenAuto = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic;
         AssignAttri(sPrefix, false, "AV93UserInfoResponseUserLastNameGenAuto", AV93UserInfoResponseUserLastNameGenAuto);
         AV94UserInfoResponseUserLastNameTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name;
         AssignAttri(sPrefix, false, "AV94UserInfoResponseUserLastNameTag", AV94UserInfoResponseUserLastNameTag);
         AV90UserInfoResponseUserGenderTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name;
         AssignAttri(sPrefix, false, "AV90UserInfoResponseUserGenderTag", AV90UserInfoResponseUserGenderTag);
         AV91UserInfoResponseUserGenderValues = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values;
         AssignAttri(sPrefix, false, "AV91UserInfoResponseUserGenderValues", AV91UserInfoResponseUserGenderValues);
         AV86UserInfoResponseUserBirthdayTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name;
         AssignAttri(sPrefix, false, "AV86UserInfoResponseUserBirthdayTag", AV86UserInfoResponseUserBirthdayTag);
         AV97UserInfoResponseUserURLImageTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name;
         AssignAttri(sPrefix, false, "AV97UserInfoResponseUserURLImageTag", AV97UserInfoResponseUserURLImageTag);
         AV98UserInfoResponseUserURLProfileTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name;
         AssignAttri(sPrefix, false, "AV98UserInfoResponseUserURLProfileTag", AV98UserInfoResponseUserURLProfileTag);
         AV92UserInfoResponseUserLanguageTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name;
         AssignAttri(sPrefix, false, "AV92UserInfoResponseUserLanguageTag", AV92UserInfoResponseUserLanguageTag);
         AV96UserInfoResponseUserTimeZoneTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name;
         AssignAttri(sPrefix, false, "AV96UserInfoResponseUserTimeZoneTag", AV96UserInfoResponseUserTimeZoneTag);
         AV85UserInfoResponseErrorDescriptionTag = AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV85UserInfoResponseErrorDescriptionTag", AV85UserInfoResponseErrorDescriptionTag);
         AV33FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV33FunctionId", AV33FunctionId);
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         /* Execute user subroutine: 'USERINFOLASTNAMEFIELDTAG' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_OPENIDCONNECT' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_VALIDIDTOKEN' */
         S252 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV11AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         }
      }

      protected void S282( )
      {
         /* 'SAVEAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         AV11AuthenticationTypeOauth20.load( AV43Name);
         AV11AuthenticationTypeOauth20.gxTpr_Name = AV43Name;
         AV11AuthenticationTypeOauth20.gxTpr_Isenable = AV41IsEnable;
         AV11AuthenticationTypeOauth20.gxTpr_Description = AV27Dsc;
         AV11AuthenticationTypeOauth20.gxTpr_Smallimagename = AV52SmallImageName;
         AV11AuthenticationTypeOauth20.gxTpr_Bigimagename = AV24BigImageName;
         AV11AuthenticationTypeOauth20.gxTpr_Impersonate = AV40Impersonate;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name = AV44Oauth20ClientIdTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value = AV45Oauth20ClientIdValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name = AV46Oauth20ClientSecretTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value = AV47Oauth20ClientSecretValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name = AV48Oauth20RedirectURLTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value = AV49Oauth20RedirectURLValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_iscustom = AV104Oauth20RedirectURLisCustom;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecttoauthenticate = AV105Oauth20RedirectToAuthenticate;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url = AV12AuthorizeURL;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_include = AV16AuthRespTypeInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name = AV17AuthRespTypeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value = AV18AuthRespTypeValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include = AV19AuthScopeInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name = AV20AuthScopeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value = AV21AuthScopeValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include = AV110AuthStateIncude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name = AV22AuthStateTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include = AV9AuthClientIdInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include = AV10AuthClientSecretInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include = AV13AuthRedirURLInclide;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters = AV7AuthAdditionalParameters;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd = AV8AuthAdditionalParametersSD;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Enable = AV111AuthOpenIDConnectProtocolEnable;
         if ( AV111AuthOpenIDConnectProtocolEnable )
         {
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken = AV112AuthValidIdToken;
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename = AV114AuthCertificatePathFileName;
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl = AV113AuthIssuerURL;
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified = AV115AuthAllowOnlyUserEmailVerified;
         }
         else
         {
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken = false;
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename = "";
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl = "";
            AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified = false;
         }
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name = AV14AuthResponseAccessCodeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name = AV15AuthResponseErrorDescTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url = AV72TokenURL;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method = AV62TokenMethod;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key = AV60TokenHeaderKeyTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value = AV61TokenHeaderKeyValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_include = AV106TokenHeaderAuthenticationInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_method = AV107TokenHeaderAuthenticationMethod;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_realm = AV108TokenHeaderAuthenticationRealm;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authorizationbasic_include = AV109TokenHeaderAuthorizationBasicInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include = AV57TokenGrantTypeInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name = AV58TokenGrantTypeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value = AV59TokenGrantTypeValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include = AV53TokenAccessCodeInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include = AV55TokenCliIdInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include = AV56TokenCliSecretInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include = AV63TokenRedirectURLInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters = AV54TokenAdditionalParameters;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name = AV65TokenResponseAccessTokenTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name = AV70TokenResponseTokenTypeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name = AV67TokenResponseExpiresInTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name = AV69TokenResponseScopeTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name = AV71TokenResponseUserIdTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name = AV68TokenResponseRefreshTokenTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name = AV66TokenResponseErrorDescriptionTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh = AV23AutovalidateExternalTokenAndRefresh;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url = AV64TokenRefreshTokenURL;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url = AV100UserInfoURL;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method = AV84UserInfoMethod;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key = AV82UserInfoHeaderKeyTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value = AV83UserInfoHeaderKeyValue;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include = AV75UserInfoAccessTokenInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name = AV76UserInfoAccessTokenName;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include = AV78UserInfoClientIdInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name = AV79UserInfoClientIdName;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include = AV80UserInfoClientSecretInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name = AV81UserInfoClientSecretName;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include = AV101UserInfoUserIdInclude;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters = AV77UserInfoAdditionalParameters;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name = AV87UserInfoResponseUserEmailTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name = AV99UserInfoResponseUserVerifiedEmailTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name = AV88UserInfoResponseUserExternalIdTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name = AV95UserInfoResponseUserNameTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name = AV89UserInfoResponseUserFirstNameTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic = AV93UserInfoResponseUserLastNameGenAuto;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name = AV94UserInfoResponseUserLastNameTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name = AV90UserInfoResponseUserGenderTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values = AV91UserInfoResponseUserGenderValues;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name = AV86UserInfoResponseUserBirthdayTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name = AV97UserInfoResponseUserURLImageTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name = AV98UserInfoResponseUserURLProfileTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name = AV92UserInfoResponseUserLanguageTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name = AV96UserInfoResponseUserTimeZoneTag;
         AV11AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name = AV85UserInfoResponseErrorDescriptionTag;
         AV11AuthenticationTypeOauth20.save();
         /* Start For Each Line */
         nRC_GXsfl_602 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_602"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_602_fel_idx = 0;
         while ( nGXsfl_602_fel_idx < nRC_GXsfl_602 )
         {
            nGXsfl_602_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_602_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_602_fel_idx+1);
            sGXsfl_602_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_6022( ) ;
            AV28DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
            AV29DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
            AV26Delete_Action = cgiGet( edtavDelete_action_Internalname);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28DynamicPropName)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29DynamicPropTag)) )
            {
               AV34GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
               AV34GAMPropertySimple.gxTpr_Id = AV28DynamicPropName;
               AV34GAMPropertySimple.gxTpr_Value = AV29DynamicPropTag;
               if ( ! AV11AuthenticationTypeOauth20.setuserinfoproperty(AV34GAMPropertySimple, out  AV31Errors) )
               {
                  AV122GXV1 = 1;
                  while ( AV122GXV1 <= AV31Errors.Count )
                  {
                     AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31Errors.Item(AV122GXV1));
                     context.StatusMessage( StringUtil.Format( "%1 (GAM%2)", AV30Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV30Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", "") );
                     AV122GXV1 = (int)(AV122GXV1+1);
                  }
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_602_fel_idx == 0 )
         {
            nGXsfl_602_idx = 1;
            sGXsfl_602_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_idx), 4, 0), 4, "0");
            SubsflControlProps_6022( ) ;
         }
         nGXsfl_602_fel_idx = 1;
      }

      protected void E163R2( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11AuthenticationTypeOauth20", AV11AuthenticationTypeOauth20);
      }

      protected void S212( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'SAVEAUTHENTICATIONOAUTH20' */
            S282 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV11AuthenticationTypeOauth20.load( AV43Name);
            AV11AuthenticationTypeOauth20.delete();
         }
         if ( AV11AuthenticationTypeOauth20.success() )
         {
            context.CommitDataStores("k2bfsg.wcauthenticationtypeentryoauth20",pr_default);
            CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV31Errors = AV11AuthenticationTypeOauth20.geterrors();
            AV123GXV2 = 1;
            while ( AV123GXV2 <= AV31Errors.Count )
            {
               AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31Errors.Item(AV123GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV30Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV30Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV123GXV2 = (int)(AV123GXV2+1);
            }
         }
      }

      protected void S222( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.wwauthtype.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S242( )
      {
         /* 'UI_OPENIDCONNECT' Routine */
         returnInSub = false;
         if ( AV111AuthOpenIDConnectProtocolEnable )
         {
            Tbl_openidconnect_Visible = true;
            ucTbl_openidconnect.SendProperty(context, sPrefix, false, Tbl_openidconnect_Internalname, "Visible", StringUtil.BoolToStr( Tbl_openidconnect_Visible));
         }
         else
         {
            Tbl_openidconnect_Visible = false;
            ucTbl_openidconnect.SendProperty(context, sPrefix, false, Tbl_openidconnect_Internalname, "Visible", StringUtil.BoolToStr( Tbl_openidconnect_Visible));
         }
      }

      protected void S252( )
      {
         /* 'UI_VALIDIDTOKEN' Routine */
         returnInSub = false;
         if ( AV111AuthOpenIDConnectProtocolEnable && AV112AuthValidIdToken )
         {
            Tbl_valididtoken_Visible = true;
            ucTbl_valididtoken.SendProperty(context, sPrefix, false, Tbl_valididtoken_Internalname, "Visible", StringUtil.BoolToStr( Tbl_valididtoken_Visible));
         }
         else
         {
            Tbl_valididtoken_Visible = false;
            ucTbl_valididtoken.SendProperty(context, sPrefix, false, Tbl_valididtoken_Internalname, "Visible", StringUtil.BoolToStr( Tbl_valididtoken_Visible));
         }
      }

      protected void S272( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' Routine */
         returnInSub = false;
         cmbavImpersonate.removeAllItems();
         AV125GXV4 = 1;
         AV124GXV3 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV116GAMAuthenticationTypeFilter, out  AV31Errors);
         while ( AV125GXV4 <= AV124GXV3.Count )
         {
            AV117AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV124GXV3.Item(AV125GXV4));
            if ( StringUtil.StrCmp(AV117AuthenticationType.gxTpr_Name, AV43Name) != 0 )
            {
               cmbavImpersonate.addItem(AV117AuthenticationType.gxTpr_Name, AV117AuthenticationType.gxTpr_Name, 0);
            }
            AV125GXV4 = (int)(AV125GXV4+1);
         }
      }

      protected void wb_table1_608_3R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WCAuthenticationTypeEntryOauth20.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_608_3R2e( true) ;
         }
         else
         {
            wb_table1_608_3R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV43Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV43Name", AV43Name);
         AV103TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV103TypeId", AV103TypeId);
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
         PA3R2( ) ;
         WS3R2( ) ;
         WE3R2( ) ;
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
         sCtrlAV43Name = (string)((string)getParm(obj,1));
         sCtrlAV103TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wcauthenticationtypeentryoauth20", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3R2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV43Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV43Name", AV43Name);
            AV103TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV103TypeId", AV103TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV43Name = cgiGet( sPrefix+"wcpOAV43Name");
         wcpOAV103TypeId = cgiGet( sPrefix+"wcpOAV103TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV43Name, wcpOAV43Name) != 0 ) || ( StringUtil.StrCmp(AV103TypeId, wcpOAV103TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV43Name = AV43Name;
         wcpOAV103TypeId = AV103TypeId;
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
         sCtrlAV43Name = cgiGet( sPrefix+"AV43Name_CTRL");
         if ( StringUtil.Len( sCtrlAV43Name) > 0 )
         {
            AV43Name = cgiGet( sCtrlAV43Name);
            AssignAttri(sPrefix, false, "AV43Name", AV43Name);
         }
         else
         {
            AV43Name = cgiGet( sPrefix+"AV43Name_PARM");
         }
         sCtrlAV103TypeId = cgiGet( sPrefix+"AV103TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV103TypeId) > 0 )
         {
            AV103TypeId = cgiGet( sCtrlAV103TypeId);
            AssignAttri(sPrefix, false, "AV103TypeId", AV103TypeId);
         }
         else
         {
            AV103TypeId = cgiGet( sPrefix+"AV103TypeId_PARM");
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
         PA3R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3R2( ) ;
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
         WS3R2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV43Name_PARM", StringUtil.RTrim( AV43Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV43Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV43Name_CTRL", StringUtil.RTrim( sCtrlAV43Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV103TypeId_PARM", StringUtil.RTrim( AV103TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV103TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV103TypeId_CTRL", StringUtil.RTrim( sCtrlAV103TypeId));
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
         WE3R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243122135541", true, true);
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
         context.AddJavascriptSource("k2bfsg/wcauthenticationtypeentryoauth20.js", "?20243122135547", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_6022( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_602_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_602_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_602_idx;
      }

      protected void SubsflControlProps_fel_6022( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_602_fel_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_602_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_602_fel_idx;
      }

      protected void sendrow_6022( )
      {
         SubsflControlProps_6022( ) ;
         WB3R0( ) ;
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
            if ( ((int)((nGXsfl_602_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_602_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 603,'"+sPrefix+"',false,'"+sGXsfl_602_idx+"',602)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicpropname_Internalname,StringUtil.RTrim( AV28DynamicPropName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,603);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicpropname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(int)edtavDynamicpropname_Visible,(int)edtavDynamicpropname_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)602,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMPropertyId",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 604,'"+sPrefix+"',false,'"+sGXsfl_602_idx+"',602)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicproptag_Internalname,StringUtil.RTrim( AV29DynamicPropTag),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,604);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicproptag_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavDynamicproptag_Visible,(int)edtavDynamicproptag_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)602,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_action_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 605,'"+sPrefix+"',false,'',602)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV26Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV119Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26Delete_Action)) ? AV119Delete_action_GXI : context.PathToRelativeUrl( AV26Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_action_Visible,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETE\\'."+sGXsfl_602_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV26Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3R2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_602_idx = ((subGrid_Islastpage==1)&&(nGXsfl_602_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_602_idx+1);
         sGXsfl_602_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_602_idx), 4, 0), 4, "0");
         SubsflControlProps_6022( ) ;
         /* End function sendrow_6022 */
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
         cmbavImpersonate.Name = "vIMPERSONATE";
         cmbavImpersonate.WebTags = "";
         if ( cmbavImpersonate.ItemCount > 0 )
         {
         }
         chkavOauth20redirecturliscustom.Name = "vOAUTH20REDIRECTURLISCUSTOM";
         chkavOauth20redirecturliscustom.WebTags = "";
         chkavOauth20redirecturliscustom.Caption = "";
         AssignProp(sPrefix, false, chkavOauth20redirecturliscustom_Internalname, "TitleCaption", chkavOauth20redirecturliscustom.Caption, true);
         chkavOauth20redirecturliscustom.CheckedValue = "false";
         chkavOauth20redirecttoauthenticate.Name = "vOAUTH20REDIRECTTOAUTHENTICATE";
         chkavOauth20redirecttoauthenticate.WebTags = "";
         chkavOauth20redirecttoauthenticate.Caption = "";
         AssignProp(sPrefix, false, chkavOauth20redirecttoauthenticate_Internalname, "TitleCaption", chkavOauth20redirecttoauthenticate.Caption, true);
         chkavOauth20redirecttoauthenticate.CheckedValue = "false";
         chkavAuthresptypeinclude.Name = "vAUTHRESPTYPEINCLUDE";
         chkavAuthresptypeinclude.WebTags = "";
         chkavAuthresptypeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthresptypeinclude_Internalname, "TitleCaption", chkavAuthresptypeinclude.Caption, true);
         chkavAuthresptypeinclude.CheckedValue = "false";
         chkavAuthscopeinclude.Name = "vAUTHSCOPEINCLUDE";
         chkavAuthscopeinclude.WebTags = "";
         chkavAuthscopeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthscopeinclude_Internalname, "TitleCaption", chkavAuthscopeinclude.Caption, true);
         chkavAuthscopeinclude.CheckedValue = "false";
         chkavAuthstateincude.Name = "vAUTHSTATEINCUDE";
         chkavAuthstateincude.WebTags = "";
         chkavAuthstateincude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthstateincude_Internalname, "TitleCaption", chkavAuthstateincude.Caption, true);
         chkavAuthstateincude.CheckedValue = "false";
         chkavAuthclientidinclude.Name = "vAUTHCLIENTIDINCLUDE";
         chkavAuthclientidinclude.WebTags = "";
         chkavAuthclientidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthclientidinclude_Internalname, "TitleCaption", chkavAuthclientidinclude.Caption, true);
         chkavAuthclientidinclude.CheckedValue = "false";
         chkavAuthclientsecretinclude.Name = "vAUTHCLIENTSECRETINCLUDE";
         chkavAuthclientsecretinclude.WebTags = "";
         chkavAuthclientsecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthclientsecretinclude_Internalname, "TitleCaption", chkavAuthclientsecretinclude.Caption, true);
         chkavAuthclientsecretinclude.CheckedValue = "false";
         chkavAuthredirurlinclide.Name = "vAUTHREDIRURLINCLIDE";
         chkavAuthredirurlinclide.WebTags = "";
         chkavAuthredirurlinclide.Caption = "";
         AssignProp(sPrefix, false, chkavAuthredirurlinclide_Internalname, "TitleCaption", chkavAuthredirurlinclide.Caption, true);
         chkavAuthredirurlinclide.CheckedValue = "false";
         chkavAuthopenidconnectprotocolenable.Name = "vAUTHOPENIDCONNECTPROTOCOLENABLE";
         chkavAuthopenidconnectprotocolenable.WebTags = "";
         chkavAuthopenidconnectprotocolenable.Caption = "";
         AssignProp(sPrefix, false, chkavAuthopenidconnectprotocolenable_Internalname, "TitleCaption", chkavAuthopenidconnectprotocolenable.Caption, true);
         chkavAuthopenidconnectprotocolenable.CheckedValue = "false";
         chkavAuthvalididtoken.Name = "vAUTHVALIDIDTOKEN";
         chkavAuthvalididtoken.WebTags = "";
         chkavAuthvalididtoken.Caption = "";
         AssignProp(sPrefix, false, chkavAuthvalididtoken_Internalname, "TitleCaption", chkavAuthvalididtoken.Caption, true);
         chkavAuthvalididtoken.CheckedValue = "false";
         chkavAuthallowonlyuseremailverified.Name = "vAUTHALLOWONLYUSEREMAILVERIFIED";
         chkavAuthallowonlyuseremailverified.WebTags = "";
         chkavAuthallowonlyuseremailverified.Caption = "";
         AssignProp(sPrefix, false, chkavAuthallowonlyuseremailverified_Internalname, "TitleCaption", chkavAuthallowonlyuseremailverified.Caption, true);
         chkavAuthallowonlyuseremailverified.CheckedValue = "false";
         cmbavTokenmethod.Name = "vTOKENMETHOD";
         cmbavTokenmethod.WebTags = "";
         cmbavTokenmethod.addItem("POST", context.GetMessage( "POST", ""), 0);
         cmbavTokenmethod.addItem("GET", context.GetMessage( "GET", ""), 0);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
         }
         chkavTokenheaderauthenticationinclude.Name = "vTOKENHEADERAUTHENTICATIONINCLUDE";
         chkavTokenheaderauthenticationinclude.WebTags = "";
         chkavTokenheaderauthenticationinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenheaderauthenticationinclude_Internalname, "TitleCaption", chkavTokenheaderauthenticationinclude.Caption, true);
         chkavTokenheaderauthenticationinclude.CheckedValue = "false";
         cmbavTokenheaderauthenticationmethod.Name = "vTOKENHEADERAUTHENTICATIONMETHOD";
         cmbavTokenheaderauthenticationmethod.WebTags = "";
         cmbavTokenheaderauthenticationmethod.addItem("0", context.GetMessage( "Basic", ""), 0);
         cmbavTokenheaderauthenticationmethod.addItem("1", context.GetMessage( "Digest", ""), 0);
         cmbavTokenheaderauthenticationmethod.addItem("2", context.GetMessage( "NTLM", ""), 0);
         cmbavTokenheaderauthenticationmethod.addItem("3", context.GetMessage( "Kerberos", ""), 0);
         if ( cmbavTokenheaderauthenticationmethod.ItemCount > 0 )
         {
         }
         chkavTokenheaderauthorizationbasicinclude.Name = "vTOKENHEADERAUTHORIZATIONBASICINCLUDE";
         chkavTokenheaderauthorizationbasicinclude.WebTags = "";
         chkavTokenheaderauthorizationbasicinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenheaderauthorizationbasicinclude_Internalname, "TitleCaption", chkavTokenheaderauthorizationbasicinclude.Caption, true);
         chkavTokenheaderauthorizationbasicinclude.CheckedValue = "false";
         chkavTokengranttypeinclude.Name = "vTOKENGRANTTYPEINCLUDE";
         chkavTokengranttypeinclude.WebTags = "";
         chkavTokengranttypeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokengranttypeinclude_Internalname, "TitleCaption", chkavTokengranttypeinclude.Caption, true);
         chkavTokengranttypeinclude.CheckedValue = "false";
         chkavTokenaccesscodeinclude.Name = "vTOKENACCESSCODEINCLUDE";
         chkavTokenaccesscodeinclude.WebTags = "";
         chkavTokenaccesscodeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenaccesscodeinclude_Internalname, "TitleCaption", chkavTokenaccesscodeinclude.Caption, true);
         chkavTokenaccesscodeinclude.CheckedValue = "false";
         chkavTokencliidinclude.Name = "vTOKENCLIIDINCLUDE";
         chkavTokencliidinclude.WebTags = "";
         chkavTokencliidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokencliidinclude_Internalname, "TitleCaption", chkavTokencliidinclude.Caption, true);
         chkavTokencliidinclude.CheckedValue = "false";
         chkavTokenclisecretinclude.Name = "vTOKENCLISECRETINCLUDE";
         chkavTokenclisecretinclude.WebTags = "";
         chkavTokenclisecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenclisecretinclude_Internalname, "TitleCaption", chkavTokenclisecretinclude.Caption, true);
         chkavTokenclisecretinclude.CheckedValue = "false";
         chkavTokenredirecturlinclude.Name = "vTOKENREDIRECTURLINCLUDE";
         chkavTokenredirecturlinclude.WebTags = "";
         chkavTokenredirecturlinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenredirecturlinclude_Internalname, "TitleCaption", chkavTokenredirecturlinclude.Caption, true);
         chkavTokenredirecturlinclude.CheckedValue = "false";
         chkavAutovalidateexternaltokenandrefresh.Name = "vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         chkavAutovalidateexternaltokenandrefresh.WebTags = "";
         chkavAutovalidateexternaltokenandrefresh.Caption = "";
         AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "TitleCaption", chkavAutovalidateexternaltokenandrefresh.Caption, true);
         chkavAutovalidateexternaltokenandrefresh.CheckedValue = "false";
         cmbavUserinfomethod.Name = "vUSERINFOMETHOD";
         cmbavUserinfomethod.WebTags = "";
         cmbavUserinfomethod.addItem("POST", context.GetMessage( "POST", ""), 0);
         cmbavUserinfomethod.addItem("GET", context.GetMessage( "GET", ""), 0);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
         }
         chkavUserinfoaccesstokeninclude.Name = "vUSERINFOACCESSTOKENINCLUDE";
         chkavUserinfoaccesstokeninclude.WebTags = "";
         chkavUserinfoaccesstokeninclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoaccesstokeninclude_Internalname, "TitleCaption", chkavUserinfoaccesstokeninclude.Caption, true);
         chkavUserinfoaccesstokeninclude.CheckedValue = "false";
         chkavUserinfoclientidinclude.Name = "vUSERINFOCLIENTIDINCLUDE";
         chkavUserinfoclientidinclude.WebTags = "";
         chkavUserinfoclientidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoclientidinclude_Internalname, "TitleCaption", chkavUserinfoclientidinclude.Caption, true);
         chkavUserinfoclientidinclude.CheckedValue = "false";
         chkavUserinfoclientsecretinclude.Name = "vUSERINFOCLIENTSECRETINCLUDE";
         chkavUserinfoclientsecretinclude.WebTags = "";
         chkavUserinfoclientsecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoclientsecretinclude_Internalname, "TitleCaption", chkavUserinfoclientsecretinclude.Caption, true);
         chkavUserinfoclientsecretinclude.CheckedValue = "false";
         chkavUserinfouseridinclude.Name = "vUSERINFOUSERIDINCLUDE";
         chkavUserinfouseridinclude.WebTags = "";
         chkavUserinfouseridinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfouseridinclude_Internalname, "TitleCaption", chkavUserinfouseridinclude.Caption, true);
         chkavUserinfouseridinclude.CheckedValue = "false";
         chkavUserinforesponseuserlastnamegenauto.Name = "vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         chkavUserinforesponseuserlastnamegenauto.WebTags = "";
         chkavUserinforesponseuserlastnamegenauto.Caption = "";
         AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "TitleCaption", chkavUserinforesponseuserlastnamegenauto.Caption, true);
         chkavUserinforesponseuserlastnamegenauto.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl602( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"602\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class")+"\" "+" style=\""+((edtavDelete_action_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28DynamicPropName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29DynamicPropTag)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV26Delete_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_action_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_action_Visible), 5, 0, ".", "")));
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
         cmbavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         divTable_container_impersonate_Internalname = sPrefix+"TABLE_CONTAINER_IMPERSONATE";
         lblTab_title_Internalname = sPrefix+"TAB_TITLE";
         edtavOauth20clientidtag_Internalname = sPrefix+"vOAUTH20CLIENTIDTAG";
         divTable_container_oauth20clientidtag_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20CLIENTIDTAG";
         edtavOauth20clientidvalue_Internalname = sPrefix+"vOAUTH20CLIENTIDVALUE";
         divTable_container_oauth20clientidvalue_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20CLIENTIDVALUE";
         edtavOauth20clientsecrettag_Internalname = sPrefix+"vOAUTH20CLIENTSECRETTAG";
         divTable_container_oauth20clientsecrettag_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20CLIENTSECRETTAG";
         edtavOauth20clientsecretvalue_Internalname = sPrefix+"vOAUTH20CLIENTSECRETVALUE";
         divTable_container_oauth20clientsecretvalue_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20CLIENTSECRETVALUE";
         edtavOauth20redirecturltag_Internalname = sPrefix+"vOAUTH20REDIRECTURLTAG";
         divTable_container_oauth20redirecturltag_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20REDIRECTURLTAG";
         edtavOauth20redirecturlvalue_Internalname = sPrefix+"vOAUTH20REDIRECTURLVALUE";
         divTable_container_oauth20redirecturlvalue_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20REDIRECTURLVALUE";
         chkavOauth20redirecturliscustom_Internalname = sPrefix+"vOAUTH20REDIRECTURLISCUSTOM";
         divTable_container_oauth20redirecturliscustom_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20REDIRECTURLISCUSTOM";
         chkavOauth20redirecttoauthenticate_Internalname = sPrefix+"vOAUTH20REDIRECTTOAUTHENTICATE";
         divTable_container_oauth20redirecttoauthenticate_Internalname = sPrefix+"TABLE_CONTAINER_OAUTH20REDIRECTTOAUTHENTICATE";
         divMaintabresponsivetable_tab_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB";
         lblTab1_title_Internalname = sPrefix+"TAB1_TITLE";
         edtavAuthorizeurl_Internalname = sPrefix+"vAUTHORIZEURL";
         divTable_container_authorizeurl_Internalname = sPrefix+"TABLE_CONTAINER_AUTHORIZEURL";
         lblLineseparatortitle_advancedconfigurationls_Internalname = sPrefix+"LINESEPARATORTITLE_ADVANCEDCONFIGURATIONLS";
         divLineseparatorheader_advancedconfigurationls_Internalname = sPrefix+"LINESEPARATORHEADER_ADVANCEDCONFIGURATIONLS";
         chkavAuthresptypeinclude_Internalname = sPrefix+"vAUTHRESPTYPEINCLUDE";
         divTable_container_authresptypeinclude_Internalname = sPrefix+"TABLE_CONTAINER_AUTHRESPTYPEINCLUDE";
         edtavAuthresptypetag_Internalname = sPrefix+"vAUTHRESPTYPETAG";
         divTable_container_authresptypetag_Internalname = sPrefix+"TABLE_CONTAINER_AUTHRESPTYPETAG";
         edtavAuthresptypevalue_Internalname = sPrefix+"vAUTHRESPTYPEVALUE";
         divTable_container_authresptypevalue_Internalname = sPrefix+"TABLE_CONTAINER_AUTHRESPTYPEVALUE";
         chkavAuthscopeinclude_Internalname = sPrefix+"vAUTHSCOPEINCLUDE";
         divTable_container_authscopeinclude_Internalname = sPrefix+"TABLE_CONTAINER_AUTHSCOPEINCLUDE";
         edtavAuthscopetag_Internalname = sPrefix+"vAUTHSCOPETAG";
         divTable_container_authscopetag_Internalname = sPrefix+"TABLE_CONTAINER_AUTHSCOPETAG";
         edtavAuthscopevalue_Internalname = sPrefix+"vAUTHSCOPEVALUE";
         divTable_container_authscopevalue_Internalname = sPrefix+"TABLE_CONTAINER_AUTHSCOPEVALUE";
         chkavAuthstateincude_Internalname = sPrefix+"vAUTHSTATEINCUDE";
         divTable_container_authstateincude_Internalname = sPrefix+"TABLE_CONTAINER_AUTHSTATEINCUDE";
         edtavAuthstatetag_Internalname = sPrefix+"vAUTHSTATETAG";
         divTable_container_authstatetag_Internalname = sPrefix+"TABLE_CONTAINER_AUTHSTATETAG";
         chkavAuthclientidinclude_Internalname = sPrefix+"vAUTHCLIENTIDINCLUDE";
         divTable_container_authclientidinclude_Internalname = sPrefix+"TABLE_CONTAINER_AUTHCLIENTIDINCLUDE";
         chkavAuthclientsecretinclude_Internalname = sPrefix+"vAUTHCLIENTSECRETINCLUDE";
         divTable_container_authclientsecretinclude_Internalname = sPrefix+"TABLE_CONTAINER_AUTHCLIENTSECRETINCLUDE";
         chkavAuthredirurlinclide_Internalname = sPrefix+"vAUTHREDIRURLINCLIDE";
         divTable_container_authredirurlinclide_Internalname = sPrefix+"TABLE_CONTAINER_AUTHREDIRURLINCLIDE";
         edtavAuthadditionalparameters_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERS";
         divTable_container_authadditionalparameters_Internalname = sPrefix+"TABLE_CONTAINER_AUTHADDITIONALPARAMETERS";
         edtavAuthadditionalparameterssd_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERSSD";
         divTable_container_authadditionalparameterssd_Internalname = sPrefix+"TABLE_CONTAINER_AUTHADDITIONALPARAMETERSSD";
         chkavAuthopenidconnectprotocolenable_Internalname = sPrefix+"vAUTHOPENIDCONNECTPROTOCOLENABLE";
         divTable_container_authopenidconnectprotocolenable_Internalname = sPrefix+"TABLE_CONTAINER_AUTHOPENIDCONNECTPROTOCOLENABLE";
         edtavAuthresponseaccesscodetag_Internalname = sPrefix+"vAUTHRESPONSEACCESSCODETAG";
         divTable_container_authresponseaccesscodetag_Internalname = sPrefix+"TABLE_CONTAINER_AUTHRESPONSEACCESSCODETAG";
         edtavAuthresponseerrordesctag_Internalname = sPrefix+"vAUTHRESPONSEERRORDESCTAG";
         divTable_container_authresponseerrordesctag_Internalname = sPrefix+"TABLE_CONTAINER_AUTHRESPONSEERRORDESCTAG";
         divMaingroupresponsivetable_groupresponse_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUPRESPONSE";
         grpGroupresponse_Internalname = sPrefix+"GROUPRESPONSE";
         chkavAuthvalididtoken_Internalname = sPrefix+"vAUTHVALIDIDTOKEN";
         divTable_container_authvalididtoken_Internalname = sPrefix+"TABLE_CONTAINER_AUTHVALIDIDTOKEN";
         edtavAuthissuerurl_Internalname = sPrefix+"vAUTHISSUERURL";
         divTable_container_authissuerurl_Internalname = sPrefix+"TABLE_CONTAINER_AUTHISSUERURL";
         edtavAuthcertificatepathfilename_Internalname = sPrefix+"vAUTHCERTIFICATEPATHFILENAME";
         divTable_container_authcertificatepathfilename_Internalname = sPrefix+"TABLE_CONTAINER_AUTHCERTIFICATEPATHFILENAME";
         chkavAuthallowonlyuseremailverified_Internalname = sPrefix+"vAUTHALLOWONLYUSEREMAILVERIFIED";
         divTable_container_authallowonlyuseremailverified_Internalname = sPrefix+"TABLE_CONTAINER_AUTHALLOWONLYUSEREMAILVERIFIED";
         divAttributescontainertable_tbl_valididtoken_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBL_VALIDIDTOKEN";
         divTbl_valididtoken_content_Internalname = sPrefix+"TBL_VALIDIDTOKEN_CONTENT";
         Tbl_valididtoken_Internalname = sPrefix+"TBL_VALIDIDTOKEN";
         divMaingroupresponsivetable_group1_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUP1";
         grpGroup1_Internalname = sPrefix+"GROUP1";
         divAttributescontainertable_tbl_openidconnect_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_TBL_OPENIDCONNECT";
         divTbl_openidconnect_content_Internalname = sPrefix+"TBL_OPENIDCONNECT_CONTENT";
         Tbl_openidconnect_Internalname = sPrefix+"TBL_OPENIDCONNECT";
         divLineseparatorcontent_advancedconfigurationls_Internalname = sPrefix+"LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONLS";
         divLineseparatorcontainer_advancedconfigurationls_Internalname = sPrefix+"LINESEPARATORCONTAINER_ADVANCEDCONFIGURATIONLS";
         divMaintabresponsivetable_tab1_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB1";
         lblTab2_title_Internalname = sPrefix+"TAB2_TITLE";
         edtavTokenurl_Internalname = sPrefix+"vTOKENURL";
         divTable_container_tokenurl_Internalname = sPrefix+"TABLE_CONTAINER_TOKENURL";
         lblLineseparatortitle_advancedconfigurationtokenls_Internalname = sPrefix+"LINESEPARATORTITLE_ADVANCEDCONFIGURATIONTOKENLS";
         divLineseparatorheader_advancedconfigurationtokenls_Internalname = sPrefix+"LINESEPARATORHEADER_ADVANCEDCONFIGURATIONTOKENLS";
         cmbavTokenmethod_Internalname = sPrefix+"vTOKENMETHOD";
         divTable_container_tokenmethod_Internalname = sPrefix+"TABLE_CONTAINER_TOKENMETHOD";
         edtavTokenheaderkeytag_Internalname = sPrefix+"vTOKENHEADERKEYTAG";
         divTable_container_tokenheaderkeytag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERKEYTAG";
         edtavTokenheaderkeyvalue_Internalname = sPrefix+"vTOKENHEADERKEYVALUE";
         divTable_container_tokenheaderkeyvalue_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERKEYVALUE";
         chkavTokenheaderauthenticationinclude_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONINCLUDE";
         divTable_container_tokenheaderauthenticationinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERAUTHENTICATIONINCLUDE";
         cmbavTokenheaderauthenticationmethod_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONMETHOD";
         divTable_container_tokenheaderauthenticationmethod_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERAUTHENTICATIONMETHOD";
         edtavTokenheaderauthenticationrealm_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONREALM";
         divTable_container_tokenheaderauthenticationrealm_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERAUTHENTICATIONREALM";
         chkavTokenheaderauthorizationbasicinclude_Internalname = sPrefix+"vTOKENHEADERAUTHORIZATIONBASICINCLUDE";
         divTable_container_tokenheaderauthorizationbasicinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENHEADERAUTHORIZATIONBASICINCLUDE";
         chkavTokengranttypeinclude_Internalname = sPrefix+"vTOKENGRANTTYPEINCLUDE";
         divTable_container_tokengranttypeinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENGRANTTYPEINCLUDE";
         edtavTokengranttypetag_Internalname = sPrefix+"vTOKENGRANTTYPETAG";
         divTable_container_tokengranttypetag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENGRANTTYPETAG";
         edtavTokengranttypevalue_Internalname = sPrefix+"vTOKENGRANTTYPEVALUE";
         divTable_container_tokengranttypevalue_Internalname = sPrefix+"TABLE_CONTAINER_TOKENGRANTTYPEVALUE";
         chkavTokenaccesscodeinclude_Internalname = sPrefix+"vTOKENACCESSCODEINCLUDE";
         divTable_container_tokenaccesscodeinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENACCESSCODEINCLUDE";
         chkavTokencliidinclude_Internalname = sPrefix+"vTOKENCLIIDINCLUDE";
         divTable_container_tokencliidinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENCLIIDINCLUDE";
         chkavTokenclisecretinclude_Internalname = sPrefix+"vTOKENCLISECRETINCLUDE";
         divTable_container_tokenclisecretinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENCLISECRETINCLUDE";
         chkavTokenredirecturlinclude_Internalname = sPrefix+"vTOKENREDIRECTURLINCLUDE";
         divTable_container_tokenredirecturlinclude_Internalname = sPrefix+"TABLE_CONTAINER_TOKENREDIRECTURLINCLUDE";
         edtavTokenadditionalparameters_Internalname = sPrefix+"vTOKENADDITIONALPARAMETERS";
         divTable_container_tokenadditionalparameters_Internalname = sPrefix+"TABLE_CONTAINER_TOKENADDITIONALPARAMETERS";
         edtavTokenresponseaccesstokentag_Internalname = sPrefix+"vTOKENRESPONSEACCESSTOKENTAG";
         divTable_container_tokenresponseaccesstokentag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSEACCESSTOKENTAG";
         edtavTokenresponsetokentypetag_Internalname = sPrefix+"vTOKENRESPONSETOKENTYPETAG";
         divTable_container_tokenresponsetokentypetag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSETOKENTYPETAG";
         edtavTokenresponseexpiresintag_Internalname = sPrefix+"vTOKENRESPONSEEXPIRESINTAG";
         divTable_container_tokenresponseexpiresintag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSEEXPIRESINTAG";
         edtavTokenresponsescopetag_Internalname = sPrefix+"vTOKENRESPONSESCOPETAG";
         divTable_container_tokenresponsescopetag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSESCOPETAG";
         edtavTokenresponseuseridtag_Internalname = sPrefix+"vTOKENRESPONSEUSERIDTAG";
         divTable_container_tokenresponseuseridtag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSEUSERIDTAG";
         edtavTokenresponserefreshtokentag_Internalname = sPrefix+"vTOKENRESPONSEREFRESHTOKENTAG";
         divTable_container_tokenresponserefreshtokentag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSEREFRESHTOKENTAG";
         edtavTokenresponseerrordescriptiontag_Internalname = sPrefix+"vTOKENRESPONSEERRORDESCRIPTIONTAG";
         divTable_container_tokenresponseerrordescriptiontag_Internalname = sPrefix+"TABLE_CONTAINER_TOKENRESPONSEERRORDESCRIPTIONTAG";
         divMaingroupresponsivetable_response_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_RESPONSE";
         grpResponse_Internalname = sPrefix+"RESPONSE";
         chkavAutovalidateexternaltokenandrefresh_Internalname = sPrefix+"vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         divTable_container_autovalidateexternaltokenandrefresh_Internalname = sPrefix+"TABLE_CONTAINER_AUTOVALIDATEEXTERNALTOKENANDREFRESH";
         edtavTokenrefreshtokenurl_Internalname = sPrefix+"vTOKENREFRESHTOKENURL";
         divTable_container_tokenrefreshtokenurl_Internalname = sPrefix+"TABLE_CONTAINER_TOKENREFRESHTOKENURL";
         divMaingroupresponsivetable_group_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUP";
         grpGroup_Internalname = sPrefix+"GROUP";
         divLineseparatorcontent_advancedconfigurationtokenls_Internalname = sPrefix+"LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONTOKENLS";
         divLineseparatorcontainer_advancedconfigurationtokenls_Internalname = sPrefix+"LINESEPARATORCONTAINER_ADVANCEDCONFIGURATIONTOKENLS";
         divMaintabresponsivetable_tab2_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB2";
         lblTab3_title_Internalname = sPrefix+"TAB3_TITLE";
         edtavUserinfourl_Internalname = sPrefix+"vUSERINFOURL";
         divTable_container_userinfourl_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOURL";
         lblLineseparatortitle_advanceduserconfiguration_Internalname = sPrefix+"LINESEPARATORTITLE_ADVANCEDUSERCONFIGURATION";
         divLineseparatorheader_advanceduserconfiguration_Internalname = sPrefix+"LINESEPARATORHEADER_ADVANCEDUSERCONFIGURATION";
         cmbavUserinfomethod_Internalname = sPrefix+"vUSERINFOMETHOD";
         divTable_container_userinfomethod_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOMETHOD";
         edtavUserinfoheaderkeytag_Internalname = sPrefix+"vUSERINFOHEADERKEYTAG";
         divTable_container_userinfoheaderkeytag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOHEADERKEYTAG";
         edtavUserinfoheaderkeyvalue_Internalname = sPrefix+"vUSERINFOHEADERKEYVALUE";
         divTable_container_userinfoheaderkeyvalue_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOHEADERKEYVALUE";
         chkavUserinfoaccesstokeninclude_Internalname = sPrefix+"vUSERINFOACCESSTOKENINCLUDE";
         divTable_container_userinfoaccesstokeninclude_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOACCESSTOKENINCLUDE";
         edtavUserinfoaccesstokenname_Internalname = sPrefix+"vUSERINFOACCESSTOKENNAME";
         divTable_container_userinfoaccesstokenname_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOACCESSTOKENNAME";
         chkavUserinfoclientidinclude_Internalname = sPrefix+"vUSERINFOCLIENTIDINCLUDE";
         divTable_container_userinfoclientidinclude_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOCLIENTIDINCLUDE";
         edtavUserinfoclientidname_Internalname = sPrefix+"vUSERINFOCLIENTIDNAME";
         divTable_container_userinfoclientidname_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOCLIENTIDNAME";
         chkavUserinfoclientsecretinclude_Internalname = sPrefix+"vUSERINFOCLIENTSECRETINCLUDE";
         divTable_container_userinfoclientsecretinclude_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOCLIENTSECRETINCLUDE";
         edtavUserinfoclientsecretname_Internalname = sPrefix+"vUSERINFOCLIENTSECRETNAME";
         divTable_container_userinfoclientsecretname_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOCLIENTSECRETNAME";
         chkavUserinfouseridinclude_Internalname = sPrefix+"vUSERINFOUSERIDINCLUDE";
         divTable_container_userinfouseridinclude_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOUSERIDINCLUDE";
         edtavUserinfoadditionalparameters_Internalname = sPrefix+"vUSERINFOADDITIONALPARAMETERS";
         divTable_container_userinfoadditionalparameters_Internalname = sPrefix+"TABLE_CONTAINER_USERINFOADDITIONALPARAMETERS";
         edtavUserinforesponseuseremailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREMAILTAG";
         divTable_container_userinforesponseuseremailtag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSEREMAILTAG";
         edtavUserinforesponseuserverifiedemailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSERVERIFIEDEMAILTAG";
         divTable_container_userinforesponseuserverifiedemailtag_Internalname = sPrefix+"TABLE_CONTAINER_USERINFORESPONSEUSERVERIFIEDEMAILTAG";
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
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         bttAdd_Internalname = sPrefix+"ADD";
         divMaingroupresponsivetable_groupcustomuserattributes_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUPCUSTOMUSERATTRIBUTES";
         grpGroupcustomuserattributes_Internalname = sPrefix+"GROUPCUSTOMUSERATTRIBUTES";
         divMaingroupresponsivetable_group1response_Internalname = sPrefix+"MAINGROUPRESPONSIVETABLE_GROUP1RESPONSE";
         grpGroup1response_Internalname = sPrefix+"GROUP1RESPONSE";
         divLineseparatorcontent_advanceduserconfiguration_Internalname = sPrefix+"LINESEPARATORCONTENT_ADVANCEDUSERCONFIGURATION";
         divLineseparatorcontainer_advanceduserconfiguration_Internalname = sPrefix+"LINESEPARATORCONTAINER_ADVANCEDUSERCONFIGURATION";
         divMaintabresponsivetable_tab3_Internalname = sPrefix+"MAINTABRESPONSIVETABLE_TAB3";
         Tabs_Internalname = sPrefix+"TABS";
         bttConfirm_Internalname = sPrefix+"CONFIRM";
         bttCancel_Internalname = sPrefix+"CANCEL";
         divActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_responsivetable_mainattributes_tbldata_Internalname = sPrefix+"ATTRIBUTESCONTAINERTABLE_RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA";
         divResponsivetable_mainattributes_tbldata_content_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA_CONTENT";
         Responsivetable_mainattributes_tbldata_Internalname = sPrefix+"RESPONSIVETABLE_MAINATTRIBUTES_TBLDATA";
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
         chkavUserinfouseridinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeUserId", "");
         chkavUserinfoclientsecretinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientSecret", "");
         chkavUserinfoclientidinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientId", "");
         chkavUserinfoaccesstokeninclude.Caption = context.GetMessage( "K2BT_GAM_IncludeAccessToken", "");
         chkavAutovalidateexternaltokenandrefresh.Caption = context.GetMessage( "K2BT_GAM_ValidateExternalToken", "");
         chkavTokenredirecturlinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeRedirectURL", "");
         chkavTokenclisecretinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientSecret", "");
         chkavTokencliidinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientId", "");
         chkavTokenaccesscodeinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeAccessCode", "");
         chkavTokengranttypeinclude.Caption = context.GetMessage( "K2BT_GAM_GrantType", "");
         chkavTokenheaderauthorizationbasicinclude.Caption = context.GetMessage( "TokenHeaderAuthorizationBasicInclude", "");
         chkavTokenheaderauthenticationinclude.Caption = context.GetMessage( "TokenHeaderAuthenticationInclude", "");
         chkavAuthallowonlyuseremailverified.Caption = context.GetMessage( "K2BT_GAM_AuthAllowOnlyUserEmailVerified", "");
         chkavAuthvalididtoken.Caption = context.GetMessage( "K2BT_GAM_AuthValidIdToken", "");
         chkavAuthopenidconnectprotocolenable.Caption = context.GetMessage( "K2BT_GAM_State", "");
         chkavAuthredirurlinclide.Caption = context.GetMessage( "K2BT_GAM_IncludeRedirectURL", "");
         chkavAuthclientsecretinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientSecret", "");
         chkavAuthclientidinclude.Caption = context.GetMessage( "K2BT_GAM_IncludeClientId", "");
         chkavAuthstateincude.Caption = context.GetMessage( "K2BT_GAM_State", "");
         chkavAuthscopeinclude.Caption = context.GetMessage( "K2BT_GAM_Scope", "");
         chkavAuthresptypeinclude.Caption = context.GetMessage( "K2BT_GAM_ResponseType", "");
         chkavOauth20redirecttoauthenticate.Caption = context.GetMessage( "K2BT_GAM_Oauth20RedirectToAuthenticate", "");
         chkavOauth20redirecturliscustom.Caption = context.GetMessage( "K2BT_GAM_Oauth20RedirectURLisCustom", "");
         chkavIsenable.Caption = context.GetMessage( "K2BT_GAM_Enabled?", "");
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_Enabled = 1;
         edtavDelete_action_Tooltiptext = "";
         edtavDynamicproptag_Jsonclick = "";
         edtavDynamicpropname_Jsonclick = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDynamicproptag_Visible = -1;
         edtavDynamicpropname_Visible = -1;
         edtavDelete_action_gximage = "";
         edtavDynamicproptag_Enabled = 1;
         edtavDynamicpropname_Enabled = 1;
         edtavDelete_action_Visible = -1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         bttConfirm_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttConfirm_Visible = 1;
         bttAdd_Visible = 1;
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
         lblTbuserlastnamehelp_Caption = "";
         edtavUserinforesponseuserlastnametag_Jsonclick = "";
         edtavUserinforesponseuserlastnametag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Visible = 1;
         chkavUserinforesponseuserlastnamegenauto.Enabled = 1;
         edtavUserinforesponseuserfirstnametag_Jsonclick = "";
         edtavUserinforesponseuserfirstnametag_Enabled = 1;
         edtavUserinforesponseusernametag_Jsonclick = "";
         edtavUserinforesponseusernametag_Enabled = 1;
         edtavUserinforesponseuserexternalidtag_Jsonclick = "";
         edtavUserinforesponseuserexternalidtag_Enabled = 1;
         edtavUserinforesponseuserverifiedemailtag_Jsonclick = "";
         edtavUserinforesponseuserverifiedemailtag_Enabled = 1;
         edtavUserinforesponseuseremailtag_Jsonclick = "";
         edtavUserinforesponseuseremailtag_Enabled = 1;
         edtavUserinfoadditionalparameters_Jsonclick = "";
         edtavUserinfoadditionalparameters_Enabled = 1;
         chkavUserinfouseridinclude.Enabled = 1;
         edtavUserinfoclientsecretname_Jsonclick = "";
         edtavUserinfoclientsecretname_Enabled = 1;
         chkavUserinfoclientsecretinclude.Enabled = 1;
         edtavUserinfoclientidname_Jsonclick = "";
         edtavUserinfoclientidname_Enabled = 1;
         chkavUserinfoclientidinclude.Enabled = 1;
         edtavUserinfoaccesstokenname_Jsonclick = "";
         edtavUserinfoaccesstokenname_Enabled = 1;
         chkavUserinfoaccesstokeninclude.Enabled = 1;
         edtavUserinfoheaderkeyvalue_Jsonclick = "";
         edtavUserinfoheaderkeyvalue_Enabled = 1;
         edtavUserinfoheaderkeytag_Jsonclick = "";
         edtavUserinfoheaderkeytag_Enabled = 1;
         cmbavUserinfomethod_Jsonclick = "";
         cmbavUserinfomethod.Enabled = 1;
         divLineseparatorcontent_advanceduserconfiguration_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_advanceduserconfiguration_Visible = 1;
         divLineseparatorheader_advanceduserconfiguration_Class = "Section_LineSeparatorOpen";
         edtavUserinfourl_Jsonclick = "";
         edtavUserinfourl_Enabled = 1;
         edtavTokenrefreshtokenurl_Jsonclick = "";
         edtavTokenrefreshtokenurl_Enabled = 1;
         chkavAutovalidateexternaltokenandrefresh.Enabled = 1;
         edtavTokenresponseerrordescriptiontag_Jsonclick = "";
         edtavTokenresponseerrordescriptiontag_Enabled = 1;
         edtavTokenresponserefreshtokentag_Jsonclick = "";
         edtavTokenresponserefreshtokentag_Enabled = 1;
         edtavTokenresponseuseridtag_Jsonclick = "";
         edtavTokenresponseuseridtag_Enabled = 1;
         edtavTokenresponsescopetag_Jsonclick = "";
         edtavTokenresponsescopetag_Enabled = 1;
         edtavTokenresponseexpiresintag_Jsonclick = "";
         edtavTokenresponseexpiresintag_Enabled = 1;
         edtavTokenresponsetokentypetag_Jsonclick = "";
         edtavTokenresponsetokentypetag_Enabled = 1;
         edtavTokenresponseaccesstokentag_Jsonclick = "";
         edtavTokenresponseaccesstokentag_Enabled = 1;
         edtavTokenadditionalparameters_Jsonclick = "";
         edtavTokenadditionalparameters_Enabled = 1;
         chkavTokenredirecturlinclude.Enabled = 1;
         chkavTokenclisecretinclude.Enabled = 1;
         chkavTokencliidinclude.Enabled = 1;
         chkavTokenaccesscodeinclude.Enabled = 1;
         edtavTokengranttypevalue_Jsonclick = "";
         edtavTokengranttypevalue_Enabled = 1;
         edtavTokengranttypetag_Jsonclick = "";
         edtavTokengranttypetag_Enabled = 1;
         chkavTokengranttypeinclude.Enabled = 1;
         chkavTokenheaderauthorizationbasicinclude.Enabled = 1;
         edtavTokenheaderauthenticationrealm_Jsonclick = "";
         edtavTokenheaderauthenticationrealm_Enabled = 1;
         cmbavTokenheaderauthenticationmethod_Jsonclick = "";
         cmbavTokenheaderauthenticationmethod.Enabled = 1;
         chkavTokenheaderauthenticationinclude.Enabled = 1;
         edtavTokenheaderkeyvalue_Jsonclick = "";
         edtavTokenheaderkeyvalue_Enabled = 1;
         edtavTokenheaderkeytag_Jsonclick = "";
         edtavTokenheaderkeytag_Enabled = 1;
         cmbavTokenmethod_Jsonclick = "";
         cmbavTokenmethod.Enabled = 1;
         divLineseparatorcontent_advancedconfigurationtokenls_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_advancedconfigurationtokenls_Visible = 1;
         divLineseparatorheader_advancedconfigurationtokenls_Class = "Section_LineSeparatorOpen";
         edtavTokenurl_Jsonclick = "";
         edtavTokenurl_Enabled = 1;
         chkavAuthallowonlyuseremailverified.Enabled = 1;
         edtavAuthcertificatepathfilename_Jsonclick = "";
         edtavAuthcertificatepathfilename_Enabled = 1;
         edtavAuthissuerurl_Jsonclick = "";
         edtavAuthissuerurl_Enabled = 1;
         chkavAuthvalididtoken.Enabled = 1;
         edtavAuthresponseerrordesctag_Jsonclick = "";
         edtavAuthresponseerrordesctag_Enabled = 1;
         edtavAuthresponseaccesscodetag_Jsonclick = "";
         edtavAuthresponseaccesscodetag_Enabled = 1;
         chkavAuthopenidconnectprotocolenable.Enabled = 1;
         edtavAuthadditionalparameterssd_Jsonclick = "";
         edtavAuthadditionalparameterssd_Enabled = 1;
         edtavAuthadditionalparameters_Jsonclick = "";
         edtavAuthadditionalparameters_Enabled = 1;
         chkavAuthredirurlinclide.Enabled = 1;
         chkavAuthclientsecretinclude.Enabled = 1;
         chkavAuthclientidinclude.Enabled = 1;
         edtavAuthstatetag_Jsonclick = "";
         edtavAuthstatetag_Enabled = 1;
         chkavAuthstateincude.Enabled = 1;
         edtavAuthscopevalue_Jsonclick = "";
         edtavAuthscopevalue_Enabled = 1;
         edtavAuthscopetag_Jsonclick = "";
         edtavAuthscopetag_Enabled = 1;
         chkavAuthscopeinclude.Enabled = 1;
         edtavAuthresptypevalue_Jsonclick = "";
         edtavAuthresptypevalue_Enabled = 1;
         edtavAuthresptypetag_Jsonclick = "";
         edtavAuthresptypetag_Enabled = 1;
         chkavAuthresptypeinclude.Enabled = 1;
         divLineseparatorcontent_advancedconfigurationls_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_advancedconfigurationls_Visible = 1;
         divLineseparatorheader_advancedconfigurationls_Class = "Section_LineSeparatorOpen";
         edtavAuthorizeurl_Jsonclick = "";
         edtavAuthorizeurl_Enabled = 1;
         chkavOauth20redirecttoauthenticate.Enabled = 1;
         chkavOauth20redirecturliscustom.Enabled = 1;
         edtavOauth20redirecturlvalue_Jsonclick = "";
         edtavOauth20redirecturlvalue_Enabled = 1;
         edtavOauth20redirecturltag_Jsonclick = "";
         edtavOauth20redirecturltag_Enabled = 1;
         edtavOauth20clientsecretvalue_Jsonclick = "";
         edtavOauth20clientsecretvalue_Enabled = 1;
         edtavOauth20clientsecrettag_Jsonclick = "";
         edtavOauth20clientsecrettag_Enabled = 1;
         edtavOauth20clientidvalue_Jsonclick = "";
         edtavOauth20clientidvalue_Enabled = 1;
         edtavOauth20clientidtag_Jsonclick = "";
         edtavOauth20clientidtag_Enabled = 1;
         cmbavImpersonate_Jsonclick = "";
         cmbavImpersonate.Enabled = 1;
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
         divContenttable_Class = "K2BToolsTable_WebPanelDesignerContent";
         Responsivetable_mainattributes_tbldata_Containseditableform = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_tbldata_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_tbldata_Open = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_tbldata_Collapsible = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_tbldata_Title = "";
         Tabs_Historymanagement = Convert.ToBoolean( 0);
         Tabs_Class = "Tab";
         Tabs_Pagecount = 4;
         Tbl_openidconnect_Visible = Convert.ToBoolean( -1);
         Tbl_openidconnect_Containseditableform = Convert.ToBoolean( -1);
         Tbl_openidconnect_Showborders = Convert.ToBoolean( -1);
         Tbl_openidconnect_Open = Convert.ToBoolean( -1);
         Tbl_openidconnect_Collapsible = Convert.ToBoolean( 0);
         Tbl_openidconnect_Title = "";
         Tbl_valididtoken_Visible = Convert.ToBoolean( -1);
         Tbl_valididtoken_Containseditableform = Convert.ToBoolean( -1);
         Tbl_valididtoken_Showborders = Convert.ToBoolean( -1);
         Tbl_valididtoken_Open = Convert.ToBoolean( -1);
         Tbl_valididtoken_Collapsible = Convert.ToBoolean( 0);
         Tbl_valididtoken_Title = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'sPrefix'},{av:'AV41IsEnable',fld:'vISENABLE',pic:''},{av:'AV104Oauth20RedirectURLisCustom',fld:'vOAUTH20REDIRECTURLISCUSTOM',pic:''},{av:'AV105Oauth20RedirectToAuthenticate',fld:'vOAUTH20REDIRECTTOAUTHENTICATE',pic:''},{av:'AV16AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV19AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV110AuthStateIncude',fld:'vAUTHSTATEINCUDE',pic:''},{av:'AV9AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV10AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV13AuthRedirURLInclide',fld:'vAUTHREDIRURLINCLIDE',pic:''},{av:'AV111AuthOpenIDConnectProtocolEnable',fld:'vAUTHOPENIDCONNECTPROTOCOLENABLE',pic:''},{av:'AV112AuthValidIdToken',fld:'vAUTHVALIDIDTOKEN',pic:''},{av:'AV115AuthAllowOnlyUserEmailVerified',fld:'vAUTHALLOWONLYUSEREMAILVERIFIED',pic:''},{av:'AV106TokenHeaderAuthenticationInclude',fld:'vTOKENHEADERAUTHENTICATIONINCLUDE',pic:''},{av:'AV109TokenHeaderAuthorizationBasicInclude',fld:'vTOKENHEADERAUTHORIZATIONBASICINCLUDE',pic:''},{av:'AV57TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV53TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV55TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV56TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV63TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV23AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV75UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV78UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV80UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV101UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV93UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''},{av:'AV25CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV39I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV25CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E193R2',iparms:[{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E203R2',iparms:[{av:'AV39I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV39I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV26Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV28DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV29DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''},{av:'edtavDelete_action_Visible',ctrl:'vDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'}]}");
         setEventMetadata("'E_ADD'","{handler:'E153R2',iparms:[]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV26Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Visible',ctrl:'vDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E213R2',iparms:[{av:'AV43Name',fld:'vNAME',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'edtavDelete_action_Visible',ctrl:'vDELETE_ACTION',prop:'Visible'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'},{av:'AV28DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV29DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''}]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E163R2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV43Name',fld:'vNAME',pic:''},{av:'AV41IsEnable',fld:'vISENABLE',pic:''},{av:'AV27Dsc',fld:'vDSC',pic:''},{av:'AV52SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV24BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'cmbavImpersonate'},{av:'AV40Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV44Oauth20ClientIdTag',fld:'vOAUTH20CLIENTIDTAG',pic:''},{av:'AV45Oauth20ClientIdValue',fld:'vOAUTH20CLIENTIDVALUE',pic:''},{av:'AV46Oauth20ClientSecretTag',fld:'vOAUTH20CLIENTSECRETTAG',pic:''},{av:'AV47Oauth20ClientSecretValue',fld:'vOAUTH20CLIENTSECRETVALUE',pic:''},{av:'AV48Oauth20RedirectURLTag',fld:'vOAUTH20REDIRECTURLTAG',pic:''},{av:'AV49Oauth20RedirectURLValue',fld:'vOAUTH20REDIRECTURLVALUE',pic:''},{av:'AV104Oauth20RedirectURLisCustom',fld:'vOAUTH20REDIRECTURLISCUSTOM',pic:''},{av:'AV105Oauth20RedirectToAuthenticate',fld:'vOAUTH20REDIRECTTOAUTHENTICATE',pic:''},{av:'AV12AuthorizeURL',fld:'vAUTHORIZEURL',pic:''},{av:'AV16AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthRespTypeTag',fld:'vAUTHRESPTYPETAG',pic:''},{av:'AV18AuthRespTypeValue',fld:'vAUTHRESPTYPEVALUE',pic:''},{av:'AV19AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV20AuthScopeTag',fld:'vAUTHSCOPETAG',pic:''},{av:'AV21AuthScopeValue',fld:'vAUTHSCOPEVALUE',pic:''},{av:'AV110AuthStateIncude',fld:'vAUTHSTATEINCUDE',pic:''},{av:'AV22AuthStateTag',fld:'vAUTHSTATETAG',pic:''},{av:'AV9AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV10AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV13AuthRedirURLInclide',fld:'vAUTHREDIRURLINCLIDE',pic:''},{av:'AV7AuthAdditionalParameters',fld:'vAUTHADDITIONALPARAMETERS',pic:''},{av:'AV8AuthAdditionalParametersSD',fld:'vAUTHADDITIONALPARAMETERSSD',pic:''},{av:'AV111AuthOpenIDConnectProtocolEnable',fld:'vAUTHOPENIDCONNECTPROTOCOLENABLE',pic:''},{av:'AV112AuthValidIdToken',fld:'vAUTHVALIDIDTOKEN',pic:''},{av:'AV114AuthCertificatePathFileName',fld:'vAUTHCERTIFICATEPATHFILENAME',pic:''},{av:'AV113AuthIssuerURL',fld:'vAUTHISSUERURL',pic:''},{av:'AV115AuthAllowOnlyUserEmailVerified',fld:'vAUTHALLOWONLYUSEREMAILVERIFIED',pic:''},{av:'AV14AuthResponseAccessCodeTag',fld:'vAUTHRESPONSEACCESSCODETAG',pic:''},{av:'AV15AuthResponseErrorDescTag',fld:'vAUTHRESPONSEERRORDESCTAG',pic:''},{av:'AV72TokenURL',fld:'vTOKENURL',pic:''},{av:'cmbavTokenmethod'},{av:'AV62TokenMethod',fld:'vTOKENMETHOD',pic:''},{av:'AV60TokenHeaderKeyTag',fld:'vTOKENHEADERKEYTAG',pic:''},{av:'AV61TokenHeaderKeyValue',fld:'vTOKENHEADERKEYVALUE',pic:''},{av:'AV106TokenHeaderAuthenticationInclude',fld:'vTOKENHEADERAUTHENTICATIONINCLUDE',pic:''},{av:'cmbavTokenheaderauthenticationmethod'},{av:'AV107TokenHeaderAuthenticationMethod',fld:'vTOKENHEADERAUTHENTICATIONMETHOD',pic:'ZZZ9'},{av:'AV108TokenHeaderAuthenticationRealm',fld:'vTOKENHEADERAUTHENTICATIONREALM',pic:''},{av:'AV109TokenHeaderAuthorizationBasicInclude',fld:'vTOKENHEADERAUTHORIZATIONBASICINCLUDE',pic:''},{av:'AV57TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV58TokenGrantTypeTag',fld:'vTOKENGRANTTYPETAG',pic:''},{av:'AV59TokenGrantTypeValue',fld:'vTOKENGRANTTYPEVALUE',pic:''},{av:'AV53TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV55TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV56TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV63TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV54TokenAdditionalParameters',fld:'vTOKENADDITIONALPARAMETERS',pic:''},{av:'AV65TokenResponseAccessTokenTag',fld:'vTOKENRESPONSEACCESSTOKENTAG',pic:''},{av:'AV70TokenResponseTokenTypeTag',fld:'vTOKENRESPONSETOKENTYPETAG',pic:''},{av:'AV67TokenResponseExpiresInTag',fld:'vTOKENRESPONSEEXPIRESINTAG',pic:''},{av:'AV69TokenResponseScopeTag',fld:'vTOKENRESPONSESCOPETAG',pic:''},{av:'AV71TokenResponseUserIdTag',fld:'vTOKENRESPONSEUSERIDTAG',pic:''},{av:'AV68TokenResponseRefreshTokenTag',fld:'vTOKENRESPONSEREFRESHTOKENTAG',pic:''},{av:'AV66TokenResponseErrorDescriptionTag',fld:'vTOKENRESPONSEERRORDESCRIPTIONTAG',pic:''},{av:'AV23AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV64TokenRefreshTokenURL',fld:'vTOKENREFRESHTOKENURL',pic:''},{av:'AV100UserInfoURL',fld:'vUSERINFOURL',pic:''},{av:'cmbavUserinfomethod'},{av:'AV84UserInfoMethod',fld:'vUSERINFOMETHOD',pic:''},{av:'AV82UserInfoHeaderKeyTag',fld:'vUSERINFOHEADERKEYTAG',pic:''},{av:'AV83UserInfoHeaderKeyValue',fld:'vUSERINFOHEADERKEYVALUE',pic:''},{av:'AV75UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV76UserInfoAccessTokenName',fld:'vUSERINFOACCESSTOKENNAME',pic:''},{av:'AV78UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV79UserInfoClientIdName',fld:'vUSERINFOCLIENTIDNAME',pic:''},{av:'AV80UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV81UserInfoClientSecretName',fld:'vUSERINFOCLIENTSECRETNAME',pic:''},{av:'AV101UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV77UserInfoAdditionalParameters',fld:'vUSERINFOADDITIONALPARAMETERS',pic:''},{av:'AV87UserInfoResponseUserEmailTag',fld:'vUSERINFORESPONSEUSEREMAILTAG',pic:''},{av:'AV99UserInfoResponseUserVerifiedEmailTag',fld:'vUSERINFORESPONSEUSERVERIFIEDEMAILTAG',pic:''},{av:'AV88UserInfoResponseUserExternalIdTag',fld:'vUSERINFORESPONSEUSEREXTERNALIDTAG',pic:''},{av:'AV95UserInfoResponseUserNameTag',fld:'vUSERINFORESPONSEUSERNAMETAG',pic:''},{av:'AV89UserInfoResponseUserFirstNameTag',fld:'vUSERINFORESPONSEUSERFIRSTNAMETAG',pic:''},{av:'AV93UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''},{av:'AV94UserInfoResponseUserLastNameTag',fld:'vUSERINFORESPONSEUSERLASTNAMETAG',pic:''},{av:'AV90UserInfoResponseUserGenderTag',fld:'vUSERINFORESPONSEUSERGENDERTAG',pic:''},{av:'AV91UserInfoResponseUserGenderValues',fld:'vUSERINFORESPONSEUSERGENDERVALUES',pic:''},{av:'AV86UserInfoResponseUserBirthdayTag',fld:'vUSERINFORESPONSEUSERBIRTHDAYTAG',pic:''},{av:'AV97UserInfoResponseUserURLImageTag',fld:'vUSERINFORESPONSEUSERURLIMAGETAG',pic:''},{av:'AV98UserInfoResponseUserURLProfileTag',fld:'vUSERINFORESPONSEUSERURLPROFILETAG',pic:''},{av:'AV92UserInfoResponseUserLanguageTag',fld:'vUSERINFORESPONSEUSERLANGUAGETAG',pic:''},{av:'AV96UserInfoResponseUserTimeZoneTag',fld:'vUSERINFORESPONSEUSERTIMEZONETAG',pic:''},{av:'AV85UserInfoResponseErrorDescriptionTag',fld:'vUSERINFORESPONSEERRORDESCRIPTIONTAG',pic:''},{av:'AV28DynamicPropName',fld:'vDYNAMICPROPNAME',grid:602,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_602',ctrl:'GRID',grid:602,prop:'GridRC',grid:602},{av:'AV29DynamicPropTag',fld:'vDYNAMICPROPTAG',grid:602,pic:''}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E143R1',iparms:[]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDCONFIGURATIONLS.CLICK","{handler:'E113R1',iparms:[{av:'divLineseparatorcontent_advancedconfigurationls_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONLS',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDCONFIGURATIONLS.CLICK",",oparms:[{av:'divLineseparatorcontent_advancedconfigurationls_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONLS',prop:'Visible'},{av:'divLineseparatorcontent_advancedconfigurationls_Class',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONLS',prop:'Class'},{av:'divLineseparatorheader_advancedconfigurationls_Class',ctrl:'LINESEPARATORHEADER_ADVANCEDCONFIGURATIONLS',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDCONFIGURATIONTOKENLS.CLICK","{handler:'E123R1',iparms:[{av:'divLineseparatorcontent_advancedconfigurationtokenls_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONTOKENLS',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDCONFIGURATIONTOKENLS.CLICK",",oparms:[{av:'divLineseparatorcontent_advancedconfigurationtokenls_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONTOKENLS',prop:'Visible'},{av:'divLineseparatorcontent_advancedconfigurationtokenls_Class',ctrl:'LINESEPARATORCONTENT_ADVANCEDCONFIGURATIONTOKENLS',prop:'Class'},{av:'divLineseparatorheader_advancedconfigurationtokenls_Class',ctrl:'LINESEPARATORHEADER_ADVANCEDCONFIGURATIONTOKENLS',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDUSERCONFIGURATION.CLICK","{handler:'E133R1',iparms:[{av:'divLineseparatorcontent_advanceduserconfiguration_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDUSERCONFIGURATION',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_ADVANCEDUSERCONFIGURATION.CLICK",",oparms:[{av:'divLineseparatorcontent_advanceduserconfiguration_Visible',ctrl:'LINESEPARATORCONTENT_ADVANCEDUSERCONFIGURATION',prop:'Visible'},{av:'divLineseparatorcontent_advanceduserconfiguration_Class',ctrl:'LINESEPARATORCONTENT_ADVANCEDUSERCONFIGURATION',prop:'Class'},{av:'divLineseparatorheader_advanceduserconfiguration_Class',ctrl:'LINESEPARATORHEADER_ADVANCEDUSERCONFIGURATION',prop:'Class'}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[]}");
         setEventMetadata("VALIDV_TOKENMETHOD","{handler:'Validv_Tokenmethod',iparms:[]");
         setEventMetadata("VALIDV_TOKENMETHOD",",oparms:[]}");
         setEventMetadata("VALIDV_TOKENHEADERAUTHENTICATIONMETHOD","{handler:'Validv_Tokenheaderauthenticationmethod',iparms:[]");
         setEventMetadata("VALIDV_TOKENHEADERAUTHENTICATIONMETHOD",",oparms:[]}");
         setEventMetadata("VALIDV_USERINFOMETHOD","{handler:'Validv_Userinfomethod',iparms:[]");
         setEventMetadata("VALIDV_USERINFOMETHOD",",oparms:[]}");
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
         wcpOGx_mode = "";
         wcpOAV43Name = "";
         wcpOAV103TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV120Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucResponsivetable_mainattributes_tbldata = new GXUserControl();
         TempTags = "";
         AV33FunctionId = "";
         AV27Dsc = "";
         AV52SmallImageName = "";
         AV24BigImageName = "";
         AV40Impersonate = "";
         ucTabs = new GXUserControl();
         lblTab_title_Jsonclick = "";
         AV44Oauth20ClientIdTag = "";
         AV45Oauth20ClientIdValue = "";
         AV46Oauth20ClientSecretTag = "";
         AV47Oauth20ClientSecretValue = "";
         AV48Oauth20RedirectURLTag = "";
         AV49Oauth20RedirectURLValue = "";
         lblTab1_title_Jsonclick = "";
         AV12AuthorizeURL = "";
         lblLineseparatortitle_advancedconfigurationls_Jsonclick = "";
         AV17AuthRespTypeTag = "";
         AV18AuthRespTypeValue = "";
         AV20AuthScopeTag = "";
         AV21AuthScopeValue = "";
         AV22AuthStateTag = "";
         AV7AuthAdditionalParameters = "";
         AV8AuthAdditionalParametersSD = "";
         AV14AuthResponseAccessCodeTag = "";
         AV15AuthResponseErrorDescTag = "";
         ucTbl_openidconnect = new GXUserControl();
         ucTbl_valididtoken = new GXUserControl();
         AV113AuthIssuerURL = "";
         AV114AuthCertificatePathFileName = "";
         lblTab2_title_Jsonclick = "";
         AV72TokenURL = "";
         lblLineseparatortitle_advancedconfigurationtokenls_Jsonclick = "";
         AV62TokenMethod = "";
         AV60TokenHeaderKeyTag = "";
         AV61TokenHeaderKeyValue = "";
         AV108TokenHeaderAuthenticationRealm = "";
         AV58TokenGrantTypeTag = "";
         AV59TokenGrantTypeValue = "";
         AV54TokenAdditionalParameters = "";
         AV65TokenResponseAccessTokenTag = "";
         AV70TokenResponseTokenTypeTag = "";
         AV67TokenResponseExpiresInTag = "";
         AV69TokenResponseScopeTag = "";
         AV71TokenResponseUserIdTag = "";
         AV68TokenResponseRefreshTokenTag = "";
         AV66TokenResponseErrorDescriptionTag = "";
         AV64TokenRefreshTokenURL = "";
         lblTab3_title_Jsonclick = "";
         AV100UserInfoURL = "";
         lblLineseparatortitle_advanceduserconfiguration_Jsonclick = "";
         AV84UserInfoMethod = "";
         AV82UserInfoHeaderKeyTag = "";
         AV83UserInfoHeaderKeyValue = "";
         AV76UserInfoAccessTokenName = "";
         AV79UserInfoClientIdName = "";
         AV81UserInfoClientSecretName = "";
         AV77UserInfoAdditionalParameters = "";
         AV87UserInfoResponseUserEmailTag = "";
         AV99UserInfoResponseUserVerifiedEmailTag = "";
         AV88UserInfoResponseUserExternalIdTag = "";
         AV95UserInfoResponseUserNameTag = "";
         AV89UserInfoResponseUserFirstNameTag = "";
         lblTextblock_var_userinforesponseuserlastnametag_Jsonclick = "";
         AV94UserInfoResponseUserLastNameTag = "";
         lblTbuserlastnamehelp_Jsonclick = "";
         AV90UserInfoResponseUserGenderTag = "";
         AV91UserInfoResponseUserGenderValues = "";
         AV86UserInfoResponseUserBirthdayTag = "";
         AV97UserInfoResponseUserURLImageTag = "";
         AV98UserInfoResponseUserURLProfileTag = "";
         AV92UserInfoResponseUserLanguageTag = "";
         AV96UserInfoResponseUserTimeZoneTag = "";
         AV85UserInfoResponseErrorDescriptionTag = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttAdd_Jsonclick = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28DynamicPropName = "";
         AV29DynamicPropTag = "";
         AV26Delete_Action = "";
         AV119Delete_action_GXI = "";
         GridRow = new GXWebRow();
         AV51sdt = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPropertySimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMPropertySimple", "GeneXus.Programs");
         AV11AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         AV37GridStateKey = "";
         AV35GridState = new SdtK2BGridState(context);
         AV31Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV34GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
         AV30Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV124GXV3 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV116GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV117AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV43Name = "";
         sCtrlAV103TypeId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentryoauth20__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wcauthenticationtypeentryoauth20__default(),
            new Object[][] {
            }
         );
         AV120Pgmname = "K2BFSG.WCAuthenticationTypeEntryOauth20";
         /* GeneXus formulas. */
         AV120Pgmname = "K2BFSG.WCAuthenticationTypeEntryOauth20";
         edtavDynamicpropname_Enabled = 0;
         edtavDynamicproptag_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV25CurrentPage_Grid ;
      private short AV39I_LoadCount_Grid ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV107TokenHeaderAuthenticationMethod ;
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
      private int divLineseparatorcontent_advancedconfigurationls_Visible ;
      private int divLineseparatorcontent_advancedconfigurationtokenls_Visible ;
      private int divLineseparatorcontent_advanceduserconfiguration_Visible ;
      private int nRC_GXsfl_602 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_602_idx=1 ;
      private int edtavDynamicpropname_Enabled ;
      private int edtavDynamicproptag_Enabled ;
      private int Tabs_Pagecount ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavOauth20clientidtag_Enabled ;
      private int edtavOauth20clientidvalue_Enabled ;
      private int edtavOauth20clientsecrettag_Enabled ;
      private int edtavOauth20clientsecretvalue_Enabled ;
      private int edtavOauth20redirecturltag_Enabled ;
      private int edtavOauth20redirecturlvalue_Enabled ;
      private int edtavAuthorizeurl_Enabled ;
      private int edtavAuthresptypetag_Enabled ;
      private int edtavAuthresptypevalue_Enabled ;
      private int edtavAuthscopetag_Enabled ;
      private int edtavAuthscopevalue_Enabled ;
      private int edtavAuthstatetag_Enabled ;
      private int edtavAuthadditionalparameters_Enabled ;
      private int edtavAuthadditionalparameterssd_Enabled ;
      private int edtavAuthresponseaccesscodetag_Enabled ;
      private int edtavAuthresponseerrordesctag_Enabled ;
      private int edtavAuthissuerurl_Enabled ;
      private int edtavAuthcertificatepathfilename_Enabled ;
      private int edtavTokenurl_Enabled ;
      private int edtavTokenheaderkeytag_Enabled ;
      private int edtavTokenheaderkeyvalue_Enabled ;
      private int edtavTokenheaderauthenticationrealm_Enabled ;
      private int edtavTokengranttypetag_Enabled ;
      private int edtavTokengranttypevalue_Enabled ;
      private int edtavTokenadditionalparameters_Enabled ;
      private int edtavTokenresponseaccesstokentag_Enabled ;
      private int edtavTokenresponsetokentypetag_Enabled ;
      private int edtavTokenresponseexpiresintag_Enabled ;
      private int edtavTokenresponsescopetag_Enabled ;
      private int edtavTokenresponseuseridtag_Enabled ;
      private int edtavTokenresponserefreshtokentag_Enabled ;
      private int edtavTokenresponseerrordescriptiontag_Enabled ;
      private int edtavTokenrefreshtokenurl_Enabled ;
      private int edtavUserinfourl_Enabled ;
      private int edtavUserinfoheaderkeytag_Enabled ;
      private int edtavUserinfoheaderkeyvalue_Enabled ;
      private int edtavUserinfoaccesstokenname_Enabled ;
      private int edtavUserinfoclientidname_Enabled ;
      private int edtavUserinfoclientsecretname_Enabled ;
      private int edtavUserinfoadditionalparameters_Enabled ;
      private int edtavUserinforesponseuseremailtag_Enabled ;
      private int edtavUserinforesponseuserverifiedemailtag_Enabled ;
      private int edtavUserinforesponseuserexternalidtag_Enabled ;
      private int edtavUserinforesponseusernametag_Enabled ;
      private int edtavUserinforesponseuserfirstnametag_Enabled ;
      private int edtavUserinforesponseuserlastnametag_Visible ;
      private int edtavUserinforesponseuserlastnametag_Enabled ;
      private int edtavUserinforesponseusergendertag_Enabled ;
      private int edtavUserinforesponseusergendervalues_Enabled ;
      private int edtavUserinforesponseuserbirthdaytag_Enabled ;
      private int edtavUserinforesponseuserurlimagetag_Enabled ;
      private int edtavUserinforesponseuserurlprofiletag_Enabled ;
      private int edtavUserinforesponseuserlanguagetag_Enabled ;
      private int edtavUserinforesponseusertimezonetag_Enabled ;
      private int edtavUserinforesponseerrordescriptiontag_Enabled ;
      private int bttAdd_Visible ;
      private int bttConfirm_Visible ;
      private int subGrid_Islastpage ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int edtavDelete_action_Visible ;
      private int edtavDynamicpropname_Visible ;
      private int edtavDynamicproptag_Visible ;
      private int nGXsfl_602_fel_idx=1 ;
      private int AV122GXV1 ;
      private int AV123GXV2 ;
      private int AV125GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavDelete_action_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string Gx_mode ;
      private string AV43Name ;
      private string AV103TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV43Name ;
      private string wcpOAV103TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_602_idx="0001" ;
      private string AV120Pgmname ;
      private string edtavDynamicpropname_Internalname ;
      private string edtavDynamicproptag_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tbl_valididtoken_Title ;
      private string Tbl_openidconnect_Title ;
      private string Tabs_Class ;
      private string Responsivetable_mainattributes_tbldata_Title ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divContenttable_Class ;
      private string Responsivetable_mainattributes_tbldata_Internalname ;
      private string divResponsivetable_mainattributes_tbldata_content_Internalname ;
      private string divAttributescontainertable_responsivetable_mainattributes_tbldata_Internalname ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string divTable_container_functionid_Internalname ;
      private string cmbavFunctionid_Internalname ;
      private string AV33FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string divTable_container_isenable_Internalname ;
      private string chkavIsenable_Internalname ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV27Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divTable_container_smallimagename_Internalname ;
      private string edtavSmallimagename_Internalname ;
      private string AV52SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string divTable_container_bigimagename_Internalname ;
      private string edtavBigimagename_Internalname ;
      private string AV24BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string divTable_container_impersonate_Internalname ;
      private string cmbavImpersonate_Internalname ;
      private string AV40Impersonate ;
      private string cmbavImpersonate_Jsonclick ;
      private string Tabs_Internalname ;
      private string lblTab_title_Internalname ;
      private string lblTab_title_Jsonclick ;
      private string divMaintabresponsivetable_tab_Internalname ;
      private string divTable_container_oauth20clientidtag_Internalname ;
      private string edtavOauth20clientidtag_Internalname ;
      private string AV44Oauth20ClientIdTag ;
      private string edtavOauth20clientidtag_Jsonclick ;
      private string divTable_container_oauth20clientidvalue_Internalname ;
      private string edtavOauth20clientidvalue_Internalname ;
      private string edtavOauth20clientidvalue_Jsonclick ;
      private string divTable_container_oauth20clientsecrettag_Internalname ;
      private string edtavOauth20clientsecrettag_Internalname ;
      private string AV46Oauth20ClientSecretTag ;
      private string edtavOauth20clientsecrettag_Jsonclick ;
      private string divTable_container_oauth20clientsecretvalue_Internalname ;
      private string edtavOauth20clientsecretvalue_Internalname ;
      private string edtavOauth20clientsecretvalue_Jsonclick ;
      private string divTable_container_oauth20redirecturltag_Internalname ;
      private string edtavOauth20redirecturltag_Internalname ;
      private string AV48Oauth20RedirectURLTag ;
      private string edtavOauth20redirecturltag_Jsonclick ;
      private string divTable_container_oauth20redirecturlvalue_Internalname ;
      private string edtavOauth20redirecturlvalue_Internalname ;
      private string edtavOauth20redirecturlvalue_Jsonclick ;
      private string divTable_container_oauth20redirecturliscustom_Internalname ;
      private string chkavOauth20redirecturliscustom_Internalname ;
      private string divTable_container_oauth20redirecttoauthenticate_Internalname ;
      private string chkavOauth20redirecttoauthenticate_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divMaintabresponsivetable_tab1_Internalname ;
      private string divTable_container_authorizeurl_Internalname ;
      private string edtavAuthorizeurl_Internalname ;
      private string edtavAuthorizeurl_Jsonclick ;
      private string divLineseparatorcontainer_advancedconfigurationls_Internalname ;
      private string divLineseparatorheader_advancedconfigurationls_Internalname ;
      private string divLineseparatorheader_advancedconfigurationls_Class ;
      private string lblLineseparatortitle_advancedconfigurationls_Internalname ;
      private string lblLineseparatortitle_advancedconfigurationls_Jsonclick ;
      private string divLineseparatorcontent_advancedconfigurationls_Internalname ;
      private string divLineseparatorcontent_advancedconfigurationls_Class ;
      private string divTable_container_authresptypeinclude_Internalname ;
      private string chkavAuthresptypeinclude_Internalname ;
      private string divTable_container_authresptypetag_Internalname ;
      private string edtavAuthresptypetag_Internalname ;
      private string AV17AuthRespTypeTag ;
      private string edtavAuthresptypetag_Jsonclick ;
      private string divTable_container_authresptypevalue_Internalname ;
      private string edtavAuthresptypevalue_Internalname ;
      private string edtavAuthresptypevalue_Jsonclick ;
      private string divTable_container_authscopeinclude_Internalname ;
      private string chkavAuthscopeinclude_Internalname ;
      private string divTable_container_authscopetag_Internalname ;
      private string edtavAuthscopetag_Internalname ;
      private string AV20AuthScopeTag ;
      private string edtavAuthscopetag_Jsonclick ;
      private string divTable_container_authscopevalue_Internalname ;
      private string edtavAuthscopevalue_Internalname ;
      private string edtavAuthscopevalue_Jsonclick ;
      private string divTable_container_authstateincude_Internalname ;
      private string chkavAuthstateincude_Internalname ;
      private string divTable_container_authstatetag_Internalname ;
      private string edtavAuthstatetag_Internalname ;
      private string AV22AuthStateTag ;
      private string edtavAuthstatetag_Jsonclick ;
      private string divTable_container_authclientidinclude_Internalname ;
      private string chkavAuthclientidinclude_Internalname ;
      private string divTable_container_authclientsecretinclude_Internalname ;
      private string chkavAuthclientsecretinclude_Internalname ;
      private string divTable_container_authredirurlinclide_Internalname ;
      private string chkavAuthredirurlinclide_Internalname ;
      private string divTable_container_authadditionalparameters_Internalname ;
      private string edtavAuthadditionalparameters_Internalname ;
      private string AV7AuthAdditionalParameters ;
      private string edtavAuthadditionalparameters_Jsonclick ;
      private string divTable_container_authadditionalparameterssd_Internalname ;
      private string edtavAuthadditionalparameterssd_Internalname ;
      private string AV8AuthAdditionalParametersSD ;
      private string edtavAuthadditionalparameterssd_Jsonclick ;
      private string divTable_container_authopenidconnectprotocolenable_Internalname ;
      private string chkavAuthopenidconnectprotocolenable_Internalname ;
      private string grpGroupresponse_Internalname ;
      private string divMaingroupresponsivetable_groupresponse_Internalname ;
      private string divTable_container_authresponseaccesscodetag_Internalname ;
      private string edtavAuthresponseaccesscodetag_Internalname ;
      private string AV14AuthResponseAccessCodeTag ;
      private string edtavAuthresponseaccesscodetag_Jsonclick ;
      private string divTable_container_authresponseerrordesctag_Internalname ;
      private string edtavAuthresponseerrordesctag_Internalname ;
      private string AV15AuthResponseErrorDescTag ;
      private string edtavAuthresponseerrordesctag_Jsonclick ;
      private string Tbl_openidconnect_Internalname ;
      private string divTbl_openidconnect_content_Internalname ;
      private string divAttributescontainertable_tbl_openidconnect_Internalname ;
      private string grpGroup1_Internalname ;
      private string divMaingroupresponsivetable_group1_Internalname ;
      private string divTable_container_authvalididtoken_Internalname ;
      private string chkavAuthvalididtoken_Internalname ;
      private string Tbl_valididtoken_Internalname ;
      private string divTbl_valididtoken_content_Internalname ;
      private string divAttributescontainertable_tbl_valididtoken_Internalname ;
      private string divTable_container_authissuerurl_Internalname ;
      private string edtavAuthissuerurl_Internalname ;
      private string edtavAuthissuerurl_Jsonclick ;
      private string divTable_container_authcertificatepathfilename_Internalname ;
      private string edtavAuthcertificatepathfilename_Internalname ;
      private string edtavAuthcertificatepathfilename_Jsonclick ;
      private string divTable_container_authallowonlyuseremailverified_Internalname ;
      private string chkavAuthallowonlyuseremailverified_Internalname ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divMaintabresponsivetable_tab2_Internalname ;
      private string divTable_container_tokenurl_Internalname ;
      private string edtavTokenurl_Internalname ;
      private string edtavTokenurl_Jsonclick ;
      private string divLineseparatorcontainer_advancedconfigurationtokenls_Internalname ;
      private string divLineseparatorheader_advancedconfigurationtokenls_Internalname ;
      private string divLineseparatorheader_advancedconfigurationtokenls_Class ;
      private string lblLineseparatortitle_advancedconfigurationtokenls_Internalname ;
      private string lblLineseparatortitle_advancedconfigurationtokenls_Jsonclick ;
      private string divLineseparatorcontent_advancedconfigurationtokenls_Internalname ;
      private string divLineseparatorcontent_advancedconfigurationtokenls_Class ;
      private string divTable_container_tokenmethod_Internalname ;
      private string cmbavTokenmethod_Internalname ;
      private string AV62TokenMethod ;
      private string cmbavTokenmethod_Jsonclick ;
      private string divTable_container_tokenheaderkeytag_Internalname ;
      private string edtavTokenheaderkeytag_Internalname ;
      private string AV60TokenHeaderKeyTag ;
      private string edtavTokenheaderkeytag_Jsonclick ;
      private string divTable_container_tokenheaderkeyvalue_Internalname ;
      private string edtavTokenheaderkeyvalue_Internalname ;
      private string AV61TokenHeaderKeyValue ;
      private string edtavTokenheaderkeyvalue_Jsonclick ;
      private string divTable_container_tokenheaderauthenticationinclude_Internalname ;
      private string chkavTokenheaderauthenticationinclude_Internalname ;
      private string divTable_container_tokenheaderauthenticationmethod_Internalname ;
      private string cmbavTokenheaderauthenticationmethod_Internalname ;
      private string cmbavTokenheaderauthenticationmethod_Jsonclick ;
      private string divTable_container_tokenheaderauthenticationrealm_Internalname ;
      private string edtavTokenheaderauthenticationrealm_Internalname ;
      private string AV108TokenHeaderAuthenticationRealm ;
      private string edtavTokenheaderauthenticationrealm_Jsonclick ;
      private string divTable_container_tokenheaderauthorizationbasicinclude_Internalname ;
      private string chkavTokenheaderauthorizationbasicinclude_Internalname ;
      private string divTable_container_tokengranttypeinclude_Internalname ;
      private string chkavTokengranttypeinclude_Internalname ;
      private string divTable_container_tokengranttypetag_Internalname ;
      private string edtavTokengranttypetag_Internalname ;
      private string AV58TokenGrantTypeTag ;
      private string edtavTokengranttypetag_Jsonclick ;
      private string divTable_container_tokengranttypevalue_Internalname ;
      private string edtavTokengranttypevalue_Internalname ;
      private string AV59TokenGrantTypeValue ;
      private string edtavTokengranttypevalue_Jsonclick ;
      private string divTable_container_tokenaccesscodeinclude_Internalname ;
      private string chkavTokenaccesscodeinclude_Internalname ;
      private string divTable_container_tokencliidinclude_Internalname ;
      private string chkavTokencliidinclude_Internalname ;
      private string divTable_container_tokenclisecretinclude_Internalname ;
      private string chkavTokenclisecretinclude_Internalname ;
      private string divTable_container_tokenredirecturlinclude_Internalname ;
      private string chkavTokenredirecturlinclude_Internalname ;
      private string divTable_container_tokenadditionalparameters_Internalname ;
      private string edtavTokenadditionalparameters_Internalname ;
      private string AV54TokenAdditionalParameters ;
      private string edtavTokenadditionalparameters_Jsonclick ;
      private string grpResponse_Internalname ;
      private string divMaingroupresponsivetable_response_Internalname ;
      private string divTable_container_tokenresponseaccesstokentag_Internalname ;
      private string edtavTokenresponseaccesstokentag_Internalname ;
      private string AV65TokenResponseAccessTokenTag ;
      private string edtavTokenresponseaccesstokentag_Jsonclick ;
      private string divTable_container_tokenresponsetokentypetag_Internalname ;
      private string edtavTokenresponsetokentypetag_Internalname ;
      private string AV70TokenResponseTokenTypeTag ;
      private string edtavTokenresponsetokentypetag_Jsonclick ;
      private string divTable_container_tokenresponseexpiresintag_Internalname ;
      private string edtavTokenresponseexpiresintag_Internalname ;
      private string AV67TokenResponseExpiresInTag ;
      private string edtavTokenresponseexpiresintag_Jsonclick ;
      private string divTable_container_tokenresponsescopetag_Internalname ;
      private string edtavTokenresponsescopetag_Internalname ;
      private string AV69TokenResponseScopeTag ;
      private string edtavTokenresponsescopetag_Jsonclick ;
      private string divTable_container_tokenresponseuseridtag_Internalname ;
      private string edtavTokenresponseuseridtag_Internalname ;
      private string AV71TokenResponseUserIdTag ;
      private string edtavTokenresponseuseridtag_Jsonclick ;
      private string divTable_container_tokenresponserefreshtokentag_Internalname ;
      private string edtavTokenresponserefreshtokentag_Internalname ;
      private string AV68TokenResponseRefreshTokenTag ;
      private string edtavTokenresponserefreshtokentag_Jsonclick ;
      private string divTable_container_tokenresponseerrordescriptiontag_Internalname ;
      private string edtavTokenresponseerrordescriptiontag_Internalname ;
      private string AV66TokenResponseErrorDescriptionTag ;
      private string edtavTokenresponseerrordescriptiontag_Jsonclick ;
      private string grpGroup_Internalname ;
      private string divMaingroupresponsivetable_group_Internalname ;
      private string divTable_container_autovalidateexternaltokenandrefresh_Internalname ;
      private string chkavAutovalidateexternaltokenandrefresh_Internalname ;
      private string divTable_container_tokenrefreshtokenurl_Internalname ;
      private string edtavTokenrefreshtokenurl_Internalname ;
      private string edtavTokenrefreshtokenurl_Jsonclick ;
      private string lblTab3_title_Internalname ;
      private string lblTab3_title_Jsonclick ;
      private string divMaintabresponsivetable_tab3_Internalname ;
      private string divTable_container_userinfourl_Internalname ;
      private string edtavUserinfourl_Internalname ;
      private string edtavUserinfourl_Jsonclick ;
      private string divLineseparatorcontainer_advanceduserconfiguration_Internalname ;
      private string divLineseparatorheader_advanceduserconfiguration_Internalname ;
      private string divLineseparatorheader_advanceduserconfiguration_Class ;
      private string lblLineseparatortitle_advanceduserconfiguration_Internalname ;
      private string lblLineseparatortitle_advanceduserconfiguration_Jsonclick ;
      private string divLineseparatorcontent_advanceduserconfiguration_Internalname ;
      private string divLineseparatorcontent_advanceduserconfiguration_Class ;
      private string divTable_container_userinfomethod_Internalname ;
      private string cmbavUserinfomethod_Internalname ;
      private string AV84UserInfoMethod ;
      private string cmbavUserinfomethod_Jsonclick ;
      private string divTable_container_userinfoheaderkeytag_Internalname ;
      private string edtavUserinfoheaderkeytag_Internalname ;
      private string AV82UserInfoHeaderKeyTag ;
      private string edtavUserinfoheaderkeytag_Jsonclick ;
      private string divTable_container_userinfoheaderkeyvalue_Internalname ;
      private string edtavUserinfoheaderkeyvalue_Internalname ;
      private string AV83UserInfoHeaderKeyValue ;
      private string edtavUserinfoheaderkeyvalue_Jsonclick ;
      private string divTable_container_userinfoaccesstokeninclude_Internalname ;
      private string chkavUserinfoaccesstokeninclude_Internalname ;
      private string divTable_container_userinfoaccesstokenname_Internalname ;
      private string edtavUserinfoaccesstokenname_Internalname ;
      private string AV76UserInfoAccessTokenName ;
      private string edtavUserinfoaccesstokenname_Jsonclick ;
      private string divTable_container_userinfoclientidinclude_Internalname ;
      private string chkavUserinfoclientidinclude_Internalname ;
      private string divTable_container_userinfoclientidname_Internalname ;
      private string edtavUserinfoclientidname_Internalname ;
      private string AV79UserInfoClientIdName ;
      private string edtavUserinfoclientidname_Jsonclick ;
      private string divTable_container_userinfoclientsecretinclude_Internalname ;
      private string chkavUserinfoclientsecretinclude_Internalname ;
      private string divTable_container_userinfoclientsecretname_Internalname ;
      private string edtavUserinfoclientsecretname_Internalname ;
      private string AV81UserInfoClientSecretName ;
      private string edtavUserinfoclientsecretname_Jsonclick ;
      private string divTable_container_userinfouseridinclude_Internalname ;
      private string chkavUserinfouseridinclude_Internalname ;
      private string divTable_container_userinfoadditionalparameters_Internalname ;
      private string edtavUserinfoadditionalparameters_Internalname ;
      private string AV77UserInfoAdditionalParameters ;
      private string edtavUserinfoadditionalparameters_Jsonclick ;
      private string grpGroup1response_Internalname ;
      private string divMaingroupresponsivetable_group1response_Internalname ;
      private string divTable_container_userinforesponseuseremailtag_Internalname ;
      private string edtavUserinforesponseuseremailtag_Internalname ;
      private string AV87UserInfoResponseUserEmailTag ;
      private string edtavUserinforesponseuseremailtag_Jsonclick ;
      private string divTable_container_userinforesponseuserverifiedemailtag_Internalname ;
      private string edtavUserinforesponseuserverifiedemailtag_Internalname ;
      private string AV99UserInfoResponseUserVerifiedEmailTag ;
      private string edtavUserinforesponseuserverifiedemailtag_Jsonclick ;
      private string divTable_container_userinforesponseuserexternalidtag_Internalname ;
      private string edtavUserinforesponseuserexternalidtag_Internalname ;
      private string AV88UserInfoResponseUserExternalIdTag ;
      private string edtavUserinforesponseuserexternalidtag_Jsonclick ;
      private string divTable_container_userinforesponseusernametag_Internalname ;
      private string edtavUserinforesponseusernametag_Internalname ;
      private string AV95UserInfoResponseUserNameTag ;
      private string edtavUserinforesponseusernametag_Jsonclick ;
      private string divTable_container_userinforesponseuserfirstnametag_Internalname ;
      private string edtavUserinforesponseuserfirstnametag_Internalname ;
      private string AV89UserInfoResponseUserFirstNameTag ;
      private string edtavUserinforesponseuserfirstnametag_Jsonclick ;
      private string divTable_container_userinforesponseuserlastnamegenauto_Internalname ;
      private string chkavUserinforesponseuserlastnamegenauto_Internalname ;
      private string divTable_container_userinforesponseuserlastnametag_Internalname ;
      private string lblTextblock_var_userinforesponseuserlastnametag_Internalname ;
      private string lblTextblock_var_userinforesponseuserlastnametag_Jsonclick ;
      private string divTable_container_userinforesponseuserlastnametagcellcontainer_Internalname ;
      private string edtavUserinforesponseuserlastnametag_Internalname ;
      private string AV94UserInfoResponseUserLastNameTag ;
      private string edtavUserinforesponseuserlastnametag_Jsonclick ;
      private string lblTbuserlastnamehelp_Internalname ;
      private string lblTbuserlastnamehelp_Caption ;
      private string lblTbuserlastnamehelp_Jsonclick ;
      private string divTable_container_userinforesponseusergendertag_Internalname ;
      private string edtavUserinforesponseusergendertag_Internalname ;
      private string AV90UserInfoResponseUserGenderTag ;
      private string edtavUserinforesponseusergendertag_Jsonclick ;
      private string divTable_container_userinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Jsonclick ;
      private string divTable_container_userinforesponseuserbirthdaytag_Internalname ;
      private string edtavUserinforesponseuserbirthdaytag_Internalname ;
      private string AV86UserInfoResponseUserBirthdayTag ;
      private string edtavUserinforesponseuserbirthdaytag_Jsonclick ;
      private string divTable_container_userinforesponseuserurlimagetag_Internalname ;
      private string edtavUserinforesponseuserurlimagetag_Internalname ;
      private string AV97UserInfoResponseUserURLImageTag ;
      private string edtavUserinforesponseuserurlimagetag_Jsonclick ;
      private string divTable_container_userinforesponseuserurlprofiletag_Internalname ;
      private string edtavUserinforesponseuserurlprofiletag_Internalname ;
      private string AV98UserInfoResponseUserURLProfileTag ;
      private string edtavUserinforesponseuserurlprofiletag_Jsonclick ;
      private string divTable_container_userinforesponseuserlanguagetag_Internalname ;
      private string edtavUserinforesponseuserlanguagetag_Internalname ;
      private string AV92UserInfoResponseUserLanguageTag ;
      private string edtavUserinforesponseuserlanguagetag_Jsonclick ;
      private string divTable_container_userinforesponseusertimezonetag_Internalname ;
      private string edtavUserinforesponseusertimezonetag_Internalname ;
      private string AV96UserInfoResponseUserTimeZoneTag ;
      private string edtavUserinforesponseusertimezonetag_Jsonclick ;
      private string divTable_container_userinforesponseerrordescriptiontag_Internalname ;
      private string edtavUserinforesponseerrordescriptiontag_Internalname ;
      private string AV85UserInfoResponseErrorDescriptionTag ;
      private string edtavUserinforesponseerrordescriptiontag_Jsonclick ;
      private string grpGroupcustomuserattributes_Internalname ;
      private string divMaingroupresponsivetable_groupcustomuserattributes_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string bttAdd_Internalname ;
      private string bttAdd_Jsonclick ;
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
      private string AV28DynamicPropName ;
      private string AV29DynamicPropTag ;
      private string edtavDelete_action_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string sGXsfl_602_fel_idx="0001" ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV43Name ;
      private string sCtrlAV103TypeId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDynamicpropname_Jsonclick ;
      private string edtavDynamicproptag_Jsonclick ;
      private string sImgUrl ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV41IsEnable ;
      private bool AV104Oauth20RedirectURLisCustom ;
      private bool AV105Oauth20RedirectToAuthenticate ;
      private bool AV16AuthRespTypeInclude ;
      private bool AV19AuthScopeInclude ;
      private bool AV110AuthStateIncude ;
      private bool AV9AuthClientIdInclude ;
      private bool AV10AuthClientSecretInclude ;
      private bool AV13AuthRedirURLInclide ;
      private bool AV111AuthOpenIDConnectProtocolEnable ;
      private bool AV112AuthValidIdToken ;
      private bool AV115AuthAllowOnlyUserEmailVerified ;
      private bool AV106TokenHeaderAuthenticationInclude ;
      private bool AV109TokenHeaderAuthorizationBasicInclude ;
      private bool AV57TokenGrantTypeInclude ;
      private bool AV53TokenAccessCodeInclude ;
      private bool AV55TokenCliIdInclude ;
      private bool AV56TokenCliSecretInclude ;
      private bool AV63TokenRedirectURLInclude ;
      private bool AV23AutovalidateExternalTokenAndRefresh ;
      private bool AV75UserInfoAccessTokenInclude ;
      private bool AV78UserInfoClientIdInclude ;
      private bool AV80UserInfoClientSecretInclude ;
      private bool AV101UserInfoUserIdInclude ;
      private bool AV93UserInfoResponseUserLastNameGenAuto ;
      private bool bGXsfl_602_Refreshing=false ;
      private bool Tbl_valididtoken_Collapsible ;
      private bool Tbl_valididtoken_Open ;
      private bool Tbl_valididtoken_Showborders ;
      private bool Tbl_valididtoken_Containseditableform ;
      private bool Tbl_valididtoken_Visible ;
      private bool Tbl_openidconnect_Collapsible ;
      private bool Tbl_openidconnect_Open ;
      private bool Tbl_openidconnect_Showborders ;
      private bool Tbl_openidconnect_Containseditableform ;
      private bool Tbl_openidconnect_Visible ;
      private bool Tabs_Historymanagement ;
      private bool Responsivetable_mainattributes_tbldata_Collapsible ;
      private bool Responsivetable_mainattributes_tbldata_Open ;
      private bool Responsivetable_mainattributes_tbldata_Showborders ;
      private bool Responsivetable_mainattributes_tbldata_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV50Reload_Grid ;
      private bool AV32Exit_Grid ;
      private bool AV26Delete_Action_IsBlob ;
      private string AV45Oauth20ClientIdValue ;
      private string AV47Oauth20ClientSecretValue ;
      private string AV49Oauth20RedirectURLValue ;
      private string AV12AuthorizeURL ;
      private string AV18AuthRespTypeValue ;
      private string AV21AuthScopeValue ;
      private string AV113AuthIssuerURL ;
      private string AV114AuthCertificatePathFileName ;
      private string AV72TokenURL ;
      private string AV64TokenRefreshTokenURL ;
      private string AV100UserInfoURL ;
      private string AV91UserInfoResponseUserGenderValues ;
      private string AV119Delete_action_GXI ;
      private string AV37GridStateKey ;
      private string AV26Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucResponsivetable_mainattributes_tbldata ;
      private GXUserControl ucTabs ;
      private GXUserControl ucTbl_openidconnect ;
      private GXUserControl ucTbl_valididtoken ;
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
      private GXCheckbox chkavOauth20redirecturliscustom ;
      private GXCheckbox chkavOauth20redirecttoauthenticate ;
      private GXCheckbox chkavAuthresptypeinclude ;
      private GXCheckbox chkavAuthscopeinclude ;
      private GXCheckbox chkavAuthstateincude ;
      private GXCheckbox chkavAuthclientidinclude ;
      private GXCheckbox chkavAuthclientsecretinclude ;
      private GXCheckbox chkavAuthredirurlinclide ;
      private GXCheckbox chkavAuthopenidconnectprotocolenable ;
      private GXCheckbox chkavAuthvalididtoken ;
      private GXCheckbox chkavAuthallowonlyuseremailverified ;
      private GXCombobox cmbavTokenmethod ;
      private GXCheckbox chkavTokenheaderauthenticationinclude ;
      private GXCombobox cmbavTokenheaderauthenticationmethod ;
      private GXCheckbox chkavTokenheaderauthorizationbasicinclude ;
      private GXCheckbox chkavTokengranttypeinclude ;
      private GXCheckbox chkavTokenaccesscodeinclude ;
      private GXCheckbox chkavTokencliidinclude ;
      private GXCheckbox chkavTokenclisecretinclude ;
      private GXCheckbox chkavTokenredirecturlinclude ;
      private GXCheckbox chkavAutovalidateexternaltokenandrefresh ;
      private GXCombobox cmbavUserinfomethod ;
      private GXCheckbox chkavUserinfoaccesstokeninclude ;
      private GXCheckbox chkavUserinfoclientidinclude ;
      private GXCheckbox chkavUserinfoclientsecretinclude ;
      private GXCheckbox chkavUserinfouseridinclude ;
      private GXCheckbox chkavUserinforesponseuserlastnamegenauto ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPropertySimple> AV51sdt ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV31Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV124GXV3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20 AV11AuthenticationTypeOauth20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMPropertySimple AV34GAMPropertySimple ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV30Error ;
      private SdtK2BGridState AV35GridState ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV116GAMAuthenticationTypeFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV117AuthenticationType ;
   }

   public class wcauthenticationtypeentryoauth20__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wcauthenticationtypeentryoauth20__default : DataStoreHelperBase, IDataStoreHelper
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
