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
   public class gamexampleregisteruser : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public gamexampleregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamexampleregisteruser( IGxContext context )
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
            PA302( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS302( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE302( ) ;
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
         context.SendWebValue( "Register user ") ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexampleregisteruser.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV16Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV16Messages);
         }
      }

      protected void RenderHtmlCloseForm302( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMExampleRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Register user " ;
      }

      protected void WB300( )
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
            GxWebStd.gx_div_start( context, divTbpwd_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, "Register", "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhaveaccount_Internalname, "Already have an account?", "", "", lblTbhaveaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTblogin_Internalname, "Log in", "", "", lblTblogin_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11301_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavName_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "User name  *", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV17Name, StringUtil.RTrim( context.localUtil.Format( AV17Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", edtavName_Visible, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, edtavEmail_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV7EMail, StringUtil.RTrim( context.localUtil.Format( AV7EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, edtavPassword_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV18Password), StringUtil.RTrim( context.localUtil.Format( AV18Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPassword_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbpwdrequirements_Internalname, lblTbpwdrequirements_Caption, "", "", lblTbpwdrequirements_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "text-helper-gray", 0, "", 1, 1, 0, 1, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, edtavPasswordconf_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV19PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV19PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPasswordconf_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, edtavFirstname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV9FirstName), StringUtil.RTrim( context.localUtil.Format( AV9FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, edtavLastname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV13LastName), StringUtil.RTrim( context.localUtil.Format( AV13LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "Button Primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "", "CREATE ACCOUNT", bttLogin_Jsonclick, 5, "CREATE ACCOUNT", "", StyleString, ClassString, bttLogin_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START302( )
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
         Form.Meta.addItem("description", "Register user ", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP300( ) ;
      }

      protected void WS302( )
      {
         START302( ) ;
         EVT302( ) ;
      }

      protected void EVT302( )
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
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E12302 ();
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
                                 E13302 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E14302 ();
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

      protected void WE302( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm302( ) ;
            }
         }
      }

      protected void PA302( )
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
               GX_FocusControl = edtavName_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF302( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF302( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14302 ();
            WB300( ) ;
         }
      }

      protected void send_integrity_lvl_hashes302( )
      {
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP300( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12302 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV17Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV17Name", AV17Name);
            AV7EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV7EMail", AV7EMail);
            AV18Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV18Password", AV18Password);
            AV19PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV19PasswordConf", AV19PasswordConf);
            AV9FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV9FirstName", AV9FirstName);
            AV13LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV13LastName", AV13LastName);
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
         E12302 ();
         if (returnInSub) return;
      }

      protected void E12302( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = "";
         new gamgettextpasswordrequirement(context ).execute( out  GXt_char1) ;
         lblTbpwdrequirements_Caption = GXt_char1;
         AssignProp("", false, lblTbpwdrequirements_Internalname, "Caption", lblTbpwdrequirements_Caption, true);
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV10GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavName_Visible = 0;
            AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'MARKREQUIEREDUSERDATA' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13302 ();
         if (returnInSub) return;
      }

      protected void E13302( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV18Password, AV19PasswordConf) == 0 )
         {
            AV11GAMUser.gxTpr_Name = AV17Name;
            AV11GAMUser.gxTpr_Email = AV7EMail;
            AV11GAMUser.gxTpr_Firstname = AV9FirstName;
            AV11GAMUser.gxTpr_Lastname = AV13LastName;
            AV11GAMUser.gxTpr_Birthday = AV6Birthday;
            AV11GAMUser.gxTpr_Gender = AV12Gender;
            AV11GAMUser.gxTpr_Password = AV18Password;
            AV11GAMUser.save();
            if ( AV11GAMUser.success() )
            {
               context.CommitDataStores("gamexampleregisteruser",pr_default);
               if ( StringUtil.StrCmp(AV10GAMRepository.gxTpr_Useractivationmethod, "A") == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17Name)) )
                  {
                     AV17Name = AV7EMail;
                     AssignAttri("", false, "AV17Name", AV17Name);
                  }
                  AV15LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV17Name, AV18Password, AV5GAMLoginAdditionalParameters, out  AV22GAMErrorCollection);
                  if ( AV15LoginOK )
                  {
                     CallWebObject(formatLink("gamhome.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  AV14LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14LinkURL)) )
                  {
                     GXt_char1 = AV14LinkURL;
                     new gambuildappurl(context ).execute(  "gam_activateuseraccount", out  GXt_char1) ;
                     AV14LinkURL = GXt_char1;
                     AV14LinkURL += "%1";
                  }
                  new gamcheckuseractivationmethod(context ).execute(  AV11GAMUser.gxTpr_Guid,  AV14LinkURL, out  AV16Messages) ;
                  AV21isRegisterError = false;
                  AV24GXV1 = 1;
                  while ( AV24GXV1 <= AV16Messages.Count )
                  {
                     AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV24GXV1));
                     if ( AV20Message.gxTpr_Type == 1 )
                     {
                        AV21isRegisterError = true;
                        if (true) break;
                     }
                     AV24GXV1 = (int)(AV24GXV1+1);
                  }
                  if ( ! AV21isRegisterError )
                  {
                     edtavName_Enabled = 0;
                     AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
                     edtavEmail_Enabled = 0;
                     AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
                     edtavPassword_Enabled = 0;
                     AssignProp("", false, edtavPassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPassword_Enabled), 5, 0), true);
                     edtavPasswordconf_Enabled = 0;
                     AssignProp("", false, edtavPasswordconf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Enabled), 5, 0), true);
                     edtavFirstname_Enabled = 0;
                     AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
                     edtavLastname_Enabled = 0;
                     AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
                     bttLogin_Visible = 0;
                     AssignProp("", false, bttLogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLogin_Visible), 5, 0), true);
                  }
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               AV22GAMErrorCollection = AV11GAMUser.geterrors();
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            GX_msglist.addItem("The password and confirmation password do not match.");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GAMRepository", AV10GAMRepository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GAMUser", AV11GAMUser);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Messages", AV16Messages);
      }

      protected void S112( )
      {
         /* 'MARKREQUIEREDUSERDATA' Routine */
         returnInSub = false;
         if ( AV10GAMRepository.gxTpr_Requiredemail )
         {
            edtavEmail_Caption = edtavEmail_Caption+"  *";
            AssignProp("", false, edtavEmail_Internalname, "Caption", edtavEmail_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredfirstname )
         {
            edtavFirstname_Caption = edtavFirstname_Caption+"  *";
            AssignProp("", false, edtavFirstname_Internalname, "Caption", edtavFirstname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredlastname )
         {
            edtavLastname_Caption = edtavLastname_Caption+" *";
            AssignProp("", false, edtavLastname_Internalname, "Caption", edtavLastname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredpassword )
         {
            edtavPassword_Caption = edtavPassword_Caption+"  *";
            AssignProp("", false, edtavPassword_Internalname, "Caption", edtavPassword_Caption, true);
            edtavPasswordconf_Caption = edtavPasswordconf_Caption+"  *";
            AssignProp("", false, edtavPasswordconf_Internalname, "Caption", edtavPasswordconf_Caption, true);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV25GXV2 = 1;
         while ( AV25GXV2 <= AV16Messages.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV25GXV2));
            GX_msglist.addItem(AV20Message.gxTpr_Description);
            AV25GXV2 = (int)(AV25GXV2+1);
         }
         AV26GXV3 = 1;
         while ( AV26GXV3 <= AV22GAMErrorCollection.Count )
         {
            AV23GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV22GAMErrorCollection.Item(AV26GXV3));
            GX_msglist.addItem(AV23GAMError.gxTpr_Message);
            AV26GXV3 = (int)(AV26GXV3+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14302( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA302( ) ;
         WS302( ) ;
         WE302( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138164798", true, true);
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
         context.AddJavascriptSource("gamexampleregisteruser.js", "?2024313816480", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         lblTbhaveaccount_Internalname = "TBHAVEACCOUNT";
         lblTblogin_Internalname = "TBLOGIN";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavPassword_Internalname = "vPASSWORD";
         lblTbpwdrequirements_Internalname = "TBPWDREQUIREMENTS";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         bttLogin_Internalname = "LOGIN";
         divTbpwd_Internalname = "TBPWD";
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
         bttLogin_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavLastname_Caption = "Last name";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavFirstname_Caption = "First Name";
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Caption = "Confirm Password";
         lblTbpwdrequirements_Caption = "";
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Caption = "Password";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavEmail_Caption = "EMail";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavName_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV6Birthday',fld:'vBIRTHDAY',pic:'',hsh:true},{av:'AV12Gender',fld:'vGENDER',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E13302',iparms:[{av:'AV18Password',fld:'vPASSWORD',pic:''},{av:'AV19PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV17Name',fld:'vNAME',pic:''},{av:'AV7EMail',fld:'vEMAIL',pic:''},{av:'AV9FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV13LastName',fld:'vLASTNAME',pic:''},{av:'AV6Birthday',fld:'vBIRTHDAY',pic:'',hsh:true},{av:'AV12Gender',fld:'vGENDER',pic:'',hsh:true},{av:'AV16Messages',fld:'vMESSAGES',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV17Name',fld:'vNAME',pic:''},{av:'AV16Messages',fld:'vMESSAGES',pic:''},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'edtavEmail_Enabled',ctrl:'vEMAIL',prop:'Enabled'},{av:'edtavPassword_Enabled',ctrl:'vPASSWORD',prop:'Enabled'},{av:'edtavPasswordconf_Enabled',ctrl:'vPASSWORDCONF',prop:'Enabled'},{av:'edtavFirstname_Enabled',ctrl:'vFIRSTNAME',prop:'Enabled'},{av:'edtavLastname_Enabled',ctrl:'vLASTNAME',prop:'Enabled'},{ctrl:'LOGIN',prop:'Visible'}]}");
         setEventMetadata("'LOGIN'","{handler:'E11301',iparms:[]");
         setEventMetadata("'LOGIN'",",oparms:[]}");
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
         AV6Birthday = DateTime.MinValue;
         AV12Gender = "";
         GXKey = "";
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         lblTbhaveaccount_Jsonclick = "";
         lblTblogin_Jsonclick = "";
         TempTags = "";
         AV17Name = "";
         AV7EMail = "";
         AV18Password = "";
         lblTbpwdrequirements_Jsonclick = "";
         AV19PasswordConf = "";
         AV9FirstName = "";
         AV13LastName = "";
         ClassString = "";
         StyleString = "";
         bttLogin_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV5GAMLoginAdditionalParameters = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV22GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14LinkURL = "";
         GXt_char1 = "";
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV23GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Visible ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int bttLogin_Visible ;
      private int AV24GXV1 ;
      private int AV25GXV2 ;
      private int AV26GXV3 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV12Gender ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divTbpwd_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string lblTbhaveaccount_Internalname ;
      private string lblTbhaveaccount_Jsonclick ;
      private string lblTblogin_Internalname ;
      private string lblTblogin_Jsonclick ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Caption ;
      private string edtavEmail_Jsonclick ;
      private string edtavPassword_Internalname ;
      private string edtavPassword_Caption ;
      private string AV18Password ;
      private string edtavPassword_Jsonclick ;
      private string lblTbpwdrequirements_Internalname ;
      private string lblTbpwdrequirements_Caption ;
      private string lblTbpwdrequirements_Jsonclick ;
      private string edtavPasswordconf_Internalname ;
      private string edtavPasswordconf_Caption ;
      private string AV19PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Caption ;
      private string AV9FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Caption ;
      private string AV13LastName ;
      private string edtavLastname_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttLogin_Internalname ;
      private string bttLogin_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private DateTime AV6Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15LoginOK ;
      private bool AV21isRegisterError ;
      private string AV17Name ;
      private string AV7EMail ;
      private string AV14LinkURL ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrorCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5GAMLoginAdditionalParameters ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV23GAMError ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV10GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
   }

   public class gamexampleregisteruser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamexampleregisteruser__default : DataStoreHelperBase, IDataStoreHelper
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
