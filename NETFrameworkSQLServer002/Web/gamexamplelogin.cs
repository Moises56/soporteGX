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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamexamplelogin : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public gamexamplelogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamexamplelogin( IGxContext context )
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
         cmbavLogonto = new GXCombobox();
         chkavRememberme = new GXCheckbox();
         chkavKeepmeloggedin = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridextauthtypes") == 0 )
            {
               gxnrGridextauthtypes_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridextauthtypes") == 0 )
            {
               gxgrGridextauthtypes_refresh_invoke( ) ;
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

      protected void gxnrGridextauthtypes_newrow_invoke( )
      {
         nRC_GXsfl_62 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_62"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_62_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_62_idx = GetPar( "sGXsfl_62_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridextauthtypes_newrow( ) ;
         /* End function gxnrGridextauthtypes_newrow_invoke */
      }

      protected void gxgrGridextauthtypes_refresh_invoke( )
      {
         AV23Language = GetPar( "Language");
         AV8AuxUserName = GetPar( "AuxUserName");
         AV33UserRememberMe = (short)(Math.Round(NumberUtil.Val( GetPar( "UserRememberMe"), "."), 18, MidpointRounding.ToEven));
         AV27RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
         AV22KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridextauthtypes_refresh( AV23Language, AV8AuxUserName, AV33UserRememberMe, AV27RememberMe, AV22KeepMeLoggedIn) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridextauthtypes_refresh_invoke */
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
            ValidateSpaRequest();
            PA2V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_62_Refreshing);
               WS2V2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE2V2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "Login", "")) ;
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
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexamplelogin.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV23Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_62", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_62), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV23Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV16IDP_State));
         GxWebStd.gx_hidden_field( context, "subGridextauthtypes_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "TBLEXTERNALSAUTH_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTblexternalsauth_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TBLEXTERNALSAUTH_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTblexternalsauth_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2V2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMExampleLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Login", "") ;
      }

      protected void WB2V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, context.GetMessage( "Login", ""), "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbcurrentrepository_Internalname, lblTbcurrentrepository_Caption, "", "", lblTbcurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTbcurrentrepository_Visible, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecreateaccount_Internalname, divTablecreateaccount_Visible, 0, "px", 0, "px", "table w-100", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhaveaccount_Internalname, context.GetMessage( "Don’t have an account?", ""), "", "", lblTbhaveaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbregister_Internalname, context.GetMessage( "Register", ""), "", "", lblTbregister_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112v1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, context.GetMessage( "Log on to", ""), "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_62_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV25LogOnTo), 1, cmbavLogonto_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVLOGONTO.CLICK."+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute w-100", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_GAMExampleLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV25LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, context.GetMessage( "User", ""), "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV31UserName, StringUtil.RTrim( context.localUtil.Format( AV31UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUsername_Invitemessage, edtavUsername_Jsonclick, 0, "Attribute w-100", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 0, "px", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, context.GetMessage( "Password", ""), "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV32UserPassword), StringUtil.RTrim( context.localUtil.Format( AV32UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\""+" "+"idenableshowpasswordhint=\"False\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUserpassword_Invitemessage, edtavUserpassword_Jsonclick, 0, "Attribute w-100", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 0, "px", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbforgotpwd_Internalname, context.GetMessage( "Forgot your password?", ""), "", "", lblTbforgotpwd_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122v1_client"+"'", "", "TextBlock", 7, "", lblTbforgotpwd_Visible, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_62_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV27RememberMe), "", "", chkavRememberme.Visible, chkavRememberme.Enabled, "true", context.GetMessage( "Remember Me", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblloginbutton_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_62_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV22KeepMeLoggedIn), "", "", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", context.GetMessage( "Keep me logged in", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(51, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,51);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Button Primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");", bttLogin_Caption, bttLogin_Jsonclick, 5, context.GetMessage( "SIGN IN", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblexternalsauth_Internalname, divTblexternalsauth_Visible, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, context.GetMessage( "Or login with", ""), "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "text-line-separator", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /*  Grid Control  */
            GridextauthtypesContainer.SetIsFreestyle(true);
            GridextauthtypesContainer.SetWrapped(nGXWrapped);
            StartGridControl62( ) ;
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            nRC_GXsfl_62 = (int)(nGXsfl_62_idx-1);
            if ( GridextauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               if ( subGridextauthtypes_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridextauthtypes", GridextauthtypesContainer, subGridextauthtypes_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData", GridextauthtypesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData"+"V", GridextauthtypesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridextauthtypesContainerData"+"V"+"\" value='"+GridextauthtypesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridextauthtypesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  if ( subGridextauthtypes_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridextauthtypes", GridextauthtypesContainer, subGridextauthtypes_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData", GridextauthtypesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData"+"V", GridextauthtypesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridextauthtypesContainerData"+"V"+"\" value='"+GridextauthtypesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2V2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Login", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2V0( ) ;
      }

      protected void WS2V2( )
      {
         START2V2( ) ;
         EVT2V2( ) ;
      }

      protected void EVT2V2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "VLOGONTO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E132V2 ();
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
                                 E142V2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'SelectAuthenticationType' */
                           E152V2 ();
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "GRIDEXTAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                        {
                           nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
                           SubsflControlProps_622( ) ;
                           AV26NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV26NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV26NameAuthType, "")), context));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E162V2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E172V2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRIDEXTAUTHTYPES.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E182V2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E152V2 ();
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

      protected void WE2V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2V2( ) ;
            }
         }
      }

      protected void PA2V2( )
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
               GX_FocusControl = cmbavLogonto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridextauthtypes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_622( ) ;
         while ( nGXsfl_62_idx <= nRC_GXsfl_62 )
         {
            sendrow_622( ) ;
            nGXsfl_62_idx = ((subGridextauthtypes_Islastpage==1)&&(nGXsfl_62_idx+1>subGridextauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_622( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridextauthtypesContainer)) ;
         /* End function gxnrGridextauthtypes_newrow */
      }

      protected void gxgrGridextauthtypes_refresh( string AV23Language ,
                                                   string AV8AuxUserName ,
                                                   short AV33UserRememberMe ,
                                                   bool AV27RememberMe ,
                                                   bool AV22KeepMeLoggedIn )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDEXTAUTHTYPES_nCurrentRecord = 0;
         RF2V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridextauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV26NameAuthType));
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
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV25LogOnTo = cmbavLogonto.getValidValue(AV25LogOnTo);
            AssignAttri("", false, "AV25LogOnTo", AV25LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV25LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV27RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV27RememberMe));
         AssignAttri("", false, "AV27RememberMe", AV27RememberMe);
         AV22KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV22KeepMeLoggedIn));
         AssignAttri("", false, "AV22KeepMeLoggedIn", AV22KeepMeLoggedIn);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_62_Refreshing);
      }

      protected void RF2V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridextauthtypesContainer.ClearRows();
         }
         wbStart = 62;
         /* Execute user event: Refresh */
         E172V2 ();
         nGXsfl_62_idx = 1;
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         bGXsfl_62_Refreshing = true;
         GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
         GridextauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridextauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridextauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridextauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Backcolorstyle), 1, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
         GridextauthtypesContainer.PageSize = subGridextauthtypes_fnc_Recordsperpage( );
         if ( subGridextauthtypes_Islastpage != 0 )
         {
            GRIDEXTAUTHTYPES_nFirstRecordOnPage = (long)(subGridextauthtypes_fnc_Recordcount( )-subGridextauthtypes_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDEXTAUTHTYPES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDEXTAUTHTYPES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("GRIDEXTAUTHTYPES_nFirstRecordOnPage", GRIDEXTAUTHTYPES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_622( ) ;
            E182V2 ();
            wbEnd = 62;
            WB2V0( ) ;
         }
         bGXsfl_62_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2V2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV23Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV26NameAuthType, "")), context));
      }

      protected int subGridextauthtypes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16IDP_State = cgiGet( "vIDP_STATE");
            subGridextauthtypes_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridextauthtypes_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divTblexternalsauth_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TBLEXTERNALSAUTH_Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV25LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV25LogOnTo", AV25LogOnTo);
            AV31UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV31UserName", AV31UserName);
            AV32UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
            AV27RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV27RememberMe", AV27RememberMe);
            AV22KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV22KeepMeLoggedIn", AV22KeepMeLoggedIn);
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
         E162V2 ();
         if (returnInSub) return;
      }

      protected void E162V2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTbcurrentrepository_Visible = 0;
         AssignProp("", false, lblTbcurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbcurrentrepository_Visible), 5, 0), true);
         divTblexternalsauth_Visible = 0;
         AssignProp("", false, divTblexternalsauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternalsauth_Visible), 5, 0), true);
         AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV18isConnectionOK )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV28RepositoryGUID) )
               {
                  AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV28RepositoryGUID, out  AV12GAMErrorCollection);
                  AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
               }
               else
               {
                  AV9ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
                  if ( AV9ConnectionInfoCollection.Count > 0 )
                  {
                     AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV9ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV12GAMErrorCollection);
                     AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
                  }
               }
            }
         }
      }

      protected void E172V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         subGridextauthtypes_Visible = 0;
         AssignProp("", false, "GridextauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridextauthtypes_Visible), 5, 0), true);
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "name") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "namema") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"namema");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         AV15hasErrors = false;
         AV12GAMErrorCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV12GAMErrorCollection.Count > 0 )
         {
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 13 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 1 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 104 ) )
            {
            }
            else
            {
               AV15hasErrors = true;
               AV32UserPassword = "";
               AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV15hasErrors )
         {
            AV21isValidSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV14GAMSession, out  AV12GAMErrorCollection);
            if ( AV21isValidSession && ! AV14GAMSession.gxTpr_Isanonymous )
            {
               AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
               {
                  CallWebObject(formatLink("gamhome.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  CallWebObject(formatLink(AV30URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV23Language, out  AV12GAMErrorCollection);
               AV35GXV1 = 1;
               while ( AV35GXV1 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV35GXV1));
                  if ( AV6AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV6AuthenticationType.gxTpr_Name, AV6AuthenticationType.gxTpr_Description, 0);
                  }
                  else
                  {
                     subGridextauthtypes_Visible = 1;
                     AssignProp("", false, "GridextauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridextauthtypes_Visible), 5, 0), true);
                  }
                  AV35GXV1 = (int)(AV35GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               else
               {
                  AV25LogOnTo = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(1)).gxTpr_Name;
                  AssignAttri("", false, "AV25LogOnTo", AV25LogOnTo);
               }
               AV20isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV25LogOnTo, out  AV8AuxUserName, out  AV33UserRememberMe, out  AV12GAMErrorCollection);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AuxUserName)) )
               {
                  AV31UserName = AV8AuxUserName;
                  AssignAttri("", false, "AV31UserName", AV31UserName);
               }
               if ( AV33UserRememberMe == 2 )
               {
                  AV27RememberMe = true;
                  AssignAttri("", false, "AV27RememberMe", AV27RememberMe);
               }
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV25LogOnTo = AV13GAMRepository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV25LogOnTo", AV25LogOnTo);
               }
               /* Execute user subroutine: 'DISPLAYCHECKBOX' */
               S132 ();
               if (returnInSub) return;
               AV36GXV2 = 1;
               while ( AV36GXV2 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV36GXV2));
                  if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV25LogOnTo) == 0 )
                  {
                     /* Execute user subroutine: 'VALIDLOGONTOOTP' */
                     S142 ();
                     if (returnInSub) return;
                     if (true) break;
                  }
                  AV36GXV2 = (int)(AV36GXV2+1);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GAMRepository", AV13GAMRepository);
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV25LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      private void E182V2( )
      {
         /* Gridextauthtypes_Load Routine */
         returnInSub = false;
         AV37GXV3 = 1;
         while ( AV37GXV3 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV37GXV3));
            if ( AV6AuthenticationType.gxTpr_Redirtoauthenticate )
            {
               AV26NameAuthType = GXUtil.UrlEncode( StringUtil.Trim( AV6AuthenticationType.gxTpr_Name));
               AssignAttri("", false, edtavNameauthtype_Internalname, AV26NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV26NameAuthType, "")), context));
               bttExternalauthentication_Caption = StringUtil.Trim( AV6AuthenticationType.gxTpr_Description);
               AssignProp("", false, bttExternalauthentication_Internalname, "Caption", bttExternalauthentication_Caption, !bGXsfl_62_Refreshing);
               bttExternalauthentication_Tooltiptext = StringUtil.Format( context.GetMessage( "Sign in with %1", ""), StringUtil.Trim( AV6AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               AssignProp("", false, bttExternalauthentication_Internalname, "Tooltiptext", bttExternalauthentication_Tooltiptext, !bGXsfl_62_Refreshing);
               if ( divTblexternalsauth_Visible == 0 )
               {
                  divTblexternalsauth_Visible = 1;
                  AssignProp("", false, divTblexternalsauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternalsauth_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 62;
               }
               sendrow_622( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_62_Refreshing )
               {
                  context.DoAjaxLoad(62, GridextauthtypesRow);
               }
            }
            AV37GXV3 = (int)(AV37GXV3+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      protected void E132V2( )
      {
         /* Logonto_Click Routine */
         returnInSub = false;
         AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV23Language, out  AV12GAMErrorCollection);
         AV19isModeOTP = false;
         AV38GXV4 = 1;
         while ( AV38GXV4 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV38GXV4));
            if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV25LogOnTo) == 0 )
            {
               /* Execute user subroutine: 'VALIDLOGONTOOTP' */
               S142 ();
               if (returnInSub) return;
               if (true) break;
            }
            AV38GXV4 = (int)(AV38GXV4+1);
         }
         if ( ! AV19isModeOTP )
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavUserpassword_Invitemessage = context.GetMessage( "Password", "");
            AssignProp("", false, edtavUserpassword_Internalname, "Invitemessage", edtavUserpassword_Invitemessage, true);
            bttLogin_Caption = context.GetMessage( "SIGN IN", "");
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblTbforgotpwd_Visible = 1;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E142V2 ();
         if (returnInSub) return;
      }

      protected void E142V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV22KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV27RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV25LogOnTo;
         AV5AdditionalParameter.gxTpr_Otpstep = 1;
         AV24LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV31UserName, AV32UserPassword, AV5AdditionalParameter, out  AV12GAMErrorCollection);
         if ( AV24LoginOK )
         {
            AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
            {
               CallWebObject(formatLink("gamhome.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink(AV30URL) );
               context.wjLocDisableFrm = 0;
            }
         }
         else
         {
            if ( AV12GAMErrorCollection.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamexamplechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 400 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(1)).gxTpr_Code == 410 ) )
               {
                  CallWebObject(formatLink("gamexampleotpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV32UserPassword = "";
                  AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void E152V2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         if ( AV22KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV27RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV26NameAuthType;
         AV24LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV31UserName, AV32UserPassword, AV5AdditionalParameter, out  AV12GAMErrorCollection);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S112( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV13GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV13GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV12GAMErrorCollection);
            AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
         }
         if ( ! AV18isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV28RepositoryGUID) )
            {
               AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV28RepositoryGUID, out  AV12GAMErrorCollection);
               AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
            }
            else
            {
               AV9ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV9ConnectionInfoCollection.Count > 0 )
               {
                  AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV9ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV12GAMErrorCollection);
                  AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
               }
            }
         }
         if ( AV18isConnectionOK )
         {
            AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV13GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV18isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV13GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV12GAMErrorCollection);
               AssignAttri("", false, "AV18isConnectionOK", AV18isConnectionOK);
               AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
            lblTbcurrentrepository_Caption = context.GetMessage( "Repository: ", "")+AV13GAMRepository.gxTpr_Name;
            AssignProp("", false, lblTbcurrentrepository_Internalname, "Caption", lblTbcurrentrepository_Caption, true);
            lblTbcurrentrepository_Visible = 1;
            AssignProp("", false, lblTbcurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbcurrentrepository_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'DISPLAYCHECKBOX' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Userremembermetype, "Login") == 0 )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Userremembermetype, "Auth") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Userremembermetype, "Both") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else
         {
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'VALIDLOGONTOOTP' Routine */
         returnInSub = false;
         if ( AV6AuthenticationType.gxTpr_Needusername && ! AV6AuthenticationType.gxTpr_Needuserpassword )
         {
            AV19isModeOTP = true;
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            if ( AV6AuthenticationType.gxTpr_Istotp )
            {
               bttLogin_Caption = "NEXT";
               AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            }
            else
            {
               bttLogin_Caption = "SEND ME A CODE";
               AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            }
            lblTbforgotpwd_Visible = 0;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
            divTablecreateaccount_Visible = 0;
            AssignProp("", false, divTablecreateaccount_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecreateaccount_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV34GAMErrorDelete = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         AV39GXV5 = 1;
         while ( AV39GXV5 <= AV12GAMErrorCollection.Count )
         {
            AV11GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12GAMErrorCollection.Item(AV39GXV5));
            GX_msglist.addItem(AV11GAMError.gxTpr_Message);
            AV39GXV5 = (int)(AV39GXV5+1);
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
         PA2V2( ) ;
         WS2V2( ) ;
         WE2V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221345892", true, true);
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
         context.AddJavascriptSource("gamexamplelogin.js", "?202431221345895", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_622( )
      {
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_62_idx;
      }

      protected void SubsflControlProps_fel_622( )
      {
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_62_fel_idx;
      }

      protected void sendrow_622( )
      {
         SubsflControlProps_622( ) ;
         WB2V0( ) ;
         GridextauthtypesRow = GXWebRow.GetNew(context,GridextauthtypesContainer);
         if ( subGridextauthtypes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridextauthtypes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
            }
         }
         else if ( subGridextauthtypes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridextauthtypes_Backstyle = 0;
            subGridextauthtypes_Backcolor = subGridextauthtypes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Uniform";
            }
         }
         else if ( subGridextauthtypes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridextauthtypes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
            }
            subGridextauthtypes_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridextauthtypes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridextauthtypes_Backstyle = 1;
            if ( ((int)((nGXsfl_62_idx) % (2))) == 0 )
            {
               subGridextauthtypes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
               {
                  subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Even";
               }
            }
            else
            {
               subGridextauthtypes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
               {
                  subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridextauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridextauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_62_idx+"\">") ;
         }
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTblgridextauthtypes_Internalname+"_"+sGXsfl_62_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 stack-bottom-l",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary w-100";
         StyleString = "";
         GridextauthtypesRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttExternalauthentication_Internalname+"_"+sGXsfl_62_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");",(string)bttExternalauthentication_Caption,(string)bttExternalauthentication_Jsonclick,(short)5,(string)bttExternalauthentication_Tooltiptext,(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridextauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,context.GetMessage( "Name Auth Type", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         GridextauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV26NameAuthType),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"start",(bool)true,(string)""});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2V2( ) ;
         /* End of Columns property logic. */
         GridextauthtypesContainer.AddRow(GridextauthtypesRow);
         nGXsfl_62_idx = ((subGridextauthtypes_Islastpage==1)&&(nGXsfl_62_idx+1>subGridextauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         /* End function sendrow_622 */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV25LogOnTo = cmbavLogonto.getValidValue(AV25LogOnTo);
            AssignAttri("", false, "AV25LogOnTo", AV25LogOnTo);
         }
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = context.GetMessage( "Remember Me", "");
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV27RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV27RememberMe));
         AssignAttri("", false, "AV27RememberMe", AV27RememberMe);
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = context.GetMessage( "Keep me logged in", "");
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV22KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV22KeepMeLoggedIn));
         AssignAttri("", false, "AV22KeepMeLoggedIn", AV22KeepMeLoggedIn);
         /* End function init_web_controls */
      }

      protected void StartGridControl62( )
      {
         if ( GridextauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"DivS\" data-gxgridid=\"62\">") ;
            sStyleString = "";
            if ( subGridextauthtypes_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridextauthtypes_Internalname, subGridextauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
         }
         else
         {
            GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
            GridextauthtypesContainer.AddObjectProperty("Header", subGridextauthtypes_Header);
            GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridextauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridextauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Backcolorstyle), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("CmpContext", "");
            GridextauthtypesContainer.AddObjectProperty("InMasterPage", "false");
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV26NameAuthType)));
            GridextauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Selectedindex), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowselection), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Selectioncolor), 9, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowhovering), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Hoveringcolor), 9, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowcollapsing), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         lblTbcurrentrepository_Internalname = "TBCURRENTREPOSITORY";
         lblTbhaveaccount_Internalname = "TBHAVEACCOUNT";
         lblTbregister_Internalname = "TBREGISTER";
         divTablecreateaccount_Internalname = "TABLECREATEACCOUNT";
         cmbavLogonto_Internalname = "vLOGONTO";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         lblTbforgotpwd_Internalname = "TBFORGOTPWD";
         chkavRememberme_Internalname = "vREMEMBERME";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         bttLogin_Internalname = "LOGIN";
         divTblloginbutton_Internalname = "TBLLOGINBUTTON";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         bttExternalauthentication_Internalname = "EXTERNALAUTHENTICATION";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         divTblgridextauthtypes_Internalname = "TBLGRIDEXTAUTHTYPES";
         divTblexternalsauth_Internalname = "TBLEXTERNALSAUTH";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridextauthtypes_Internalname = "GRIDEXTAUTHTYPES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridextauthtypes_Allowcollapsing = 0;
         chkavKeepmeloggedin.Caption = "";
         chkavRememberme.Caption = "";
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Enabled = 0;
         subGridextauthtypes_Class = "FreeStyleGrid";
         bttExternalauthentication_Tooltiptext = context.GetMessage( "External Authentication", "");
         bttExternalauthentication_Caption = context.GetMessage( "External Authentication", "");
         subGridextauthtypes_Backcolorstyle = 0;
         subGridextauthtypes_Visible = 1;
         divTblexternalsauth_Visible = 1;
         bttLogin_Caption = context.GetMessage( "SIGN IN", "");
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         lblTbforgotpwd_Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Invitemessage = "";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Invitemessage = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         divTablecreateaccount_Visible = 1;
         lblTbcurrentrepository_Caption = "";
         lblTbcurrentrepository_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDEXTAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDEXTAUTHTYPES_nEOF'},{av:'AV27RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV22KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV23Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV8AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV33UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGridextauthtypes_Visible',ctrl:'GRIDEXTAUTHTYPES',prop:'Visible'},{av:'edtavUsername_Invitemessage',ctrl:'vUSERNAME',prop:'Invitemessage'},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'cmbavLogonto'},{av:'AV25LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV31UserName',fld:'vUSERNAME',pic:''},{av:'AV27RememberMe',fld:'vREMEMBERME',pic:''},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblTbforgotpwd_Visible',ctrl:'TBFORGOTPWD',prop:'Visible'},{av:'divTablecreateaccount_Visible',ctrl:'TABLECREATEACCOUNT',prop:'Visible'}]}");
         setEventMetadata("GRIDEXTAUTHTYPES.LOAD","{handler:'E182V2',iparms:[{av:'divTblexternalsauth_Visible',ctrl:'TBLEXTERNALSAUTH',prop:'Visible'}]");
         setEventMetadata("GRIDEXTAUTHTYPES.LOAD",",oparms:[{av:'AV26NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{ctrl:'EXTERNALAUTHENTICATION',prop:'Caption'},{ctrl:'EXTERNALAUTHENTICATION',prop:'Tooltiptext'},{av:'divTblexternalsauth_Visible',ctrl:'TBLEXTERNALSAUTH',prop:'Visible'}]}");
         setEventMetadata("VLOGONTO.CLICK","{handler:'E132V2',iparms:[{av:'AV23Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavLogonto'},{av:'AV25LogOnTo',fld:'vLOGONTO',pic:''}]");
         setEventMetadata("VLOGONTO.CLICK",",oparms:[{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavUserpassword_Invitemessage',ctrl:'vUSERPASSWORD',prop:'Invitemessage'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblTbforgotpwd_Visible',ctrl:'TBFORGOTPWD',prop:'Visible'},{av:'divTablecreateaccount_Visible',ctrl:'TABLECREATEACCOUNT',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E142V2',iparms:[{av:'AV22KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV27RememberMe',fld:'vREMEMBERME',pic:''},{av:'cmbavLogonto'},{av:'AV25LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV31UserName',fld:'vUSERNAME',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV16IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV16IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''}]}");
         setEventMetadata("'FORGOTPASSWORD'","{handler:'E122V1',iparms:[{av:'AV16IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("'FORGOTPASSWORD'",",oparms:[{av:'AV16IDP_State',fld:'vIDP_STATE',pic:''}]}");
         setEventMetadata("'REGISTER'","{handler:'E112V1',iparms:[]");
         setEventMetadata("'REGISTER'",",oparms:[]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E152V2',iparms:[{av:'AV22KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV27RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV26NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV31UserName',fld:'vUSERNAME',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Nameauthtype',iparms:[]");
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
         AV23Language = "";
         AV8AuxUserName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16IDP_State = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         lblTbcurrentrepository_Jsonclick = "";
         lblTbhaveaccount_Jsonclick = "";
         lblTbregister_Jsonclick = "";
         TempTags = "";
         AV25LogOnTo = "";
         AV31UserName = "";
         AV32UserPassword = "";
         lblTbforgotpwd_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttLogin_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridextauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26NameAuthType = "";
         AV28RepositoryGUID = "";
         AV12GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV14GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV30URL = "";
         AV7AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         GridextauthtypesRow = new GXWebRow();
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV34GAMErrorDelete = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridextauthtypes_Linesclass = "";
         bttExternalauthentication_Jsonclick = "";
         ROClassString = "";
         subGridextauthtypes_Header = "";
         GridextauthtypesColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV33UserRememberMe ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridextauthtypes_Backcolorstyle ;
      private short GRIDEXTAUTHTYPES_nEOF ;
      private short nGXWrapped ;
      private short subGridextauthtypes_Backstyle ;
      private short subGridextauthtypes_Allowselection ;
      private short subGridextauthtypes_Allowhovering ;
      private short subGridextauthtypes_Allowcollapsing ;
      private short subGridextauthtypes_Collapsed ;
      private int divTblexternalsauth_Visible ;
      private int nRC_GXsfl_62 ;
      private int subGridextauthtypes_Recordcount ;
      private int nGXsfl_62_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int lblTbcurrentrepository_Visible ;
      private int divTablecreateaccount_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int lblTbforgotpwd_Visible ;
      private int subGridextauthtypes_Visible ;
      private int subGridextauthtypes_Islastpage ;
      private int AV35GXV1 ;
      private int AV36GXV2 ;
      private int AV37GXV3 ;
      private int AV38GXV4 ;
      private int AV39GXV5 ;
      private int idxLst ;
      private int subGridextauthtypes_Backcolor ;
      private int subGridextauthtypes_Allbackcolor ;
      private int subGridextauthtypes_Selectedindex ;
      private int subGridextauthtypes_Selectioncolor ;
      private int subGridextauthtypes_Hoveringcolor ;
      private long GRIDEXTAUTHTYPES_nCurrentRecord ;
      private long GRIDEXTAUTHTYPES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_62_idx="0001" ;
      private string AV23Language ;
      private string edtavNameauthtype_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV16IDP_State ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string lblTbcurrentrepository_Internalname ;
      private string lblTbcurrentrepository_Caption ;
      private string lblTbcurrentrepository_Jsonclick ;
      private string divTablecreateaccount_Internalname ;
      private string lblTbhaveaccount_Internalname ;
      private string lblTbhaveaccount_Jsonclick ;
      private string lblTbregister_Internalname ;
      private string lblTbregister_Jsonclick ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string AV25LogOnTo ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Invitemessage ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV32UserPassword ;
      private string edtavUserpassword_Invitemessage ;
      private string edtavUserpassword_Jsonclick ;
      private string lblTbforgotpwd_Internalname ;
      private string lblTbforgotpwd_Jsonclick ;
      private string chkavRememberme_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTblloginbutton_Internalname ;
      private string chkavKeepmeloggedin_Internalname ;
      private string bttLogin_Internalname ;
      private string bttLogin_Caption ;
      private string bttLogin_Jsonclick ;
      private string divTblexternalsauth_Internalname ;
      private string lblTbexternalauthentication_Internalname ;
      private string lblTbexternalauthentication_Jsonclick ;
      private string sStyleString ;
      private string subGridextauthtypes_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV26NameAuthType ;
      private string AV28RepositoryGUID ;
      private string bttExternalauthentication_Caption ;
      private string bttExternalauthentication_Internalname ;
      private string bttExternalauthentication_Tooltiptext ;
      private string sGXsfl_62_fel_idx="0001" ;
      private string subGridextauthtypes_Class ;
      private string subGridextauthtypes_Linesclass ;
      private string divTblgridextauthtypes_Internalname ;
      private string bttExternalauthentication_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private string subGridextauthtypes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV27RememberMe ;
      private bool AV22KeepMeLoggedIn ;
      private bool bGXsfl_62_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18isConnectionOK ;
      private bool gx_refresh_fired ;
      private bool AV15hasErrors ;
      private bool AV21isValidSession ;
      private bool AV20isOK ;
      private bool AV19isModeOTP ;
      private bool AV24LoginOK ;
      private string AV8AuxUserName ;
      private string AV31UserName ;
      private string AV30URL ;
      private GXWebGrid GridextauthtypesContainer ;
      private GXWebRow GridextauthtypesRow ;
      private GXWebColumn GridextauthtypesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavRememberme ;
      private GXCheckbox chkavKeepmeloggedin ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV7AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV9ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV34GAMErrorDelete ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11GAMError ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV14GAMSession ;
   }

}
