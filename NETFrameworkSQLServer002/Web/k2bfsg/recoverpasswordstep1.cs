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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class recoverpasswordstep1 : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public recoverpasswordstep1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public recoverpasswordstep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV63IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV63IDP_State;
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
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
               AV63IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV63IDP_State", AV63IDP_State);
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
            PA4C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4C2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4C2( ) ;
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
         context.SendWebValue( context.GetMessage( "Recover Password Step 1", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.recoverpasswordstep1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV63IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV45UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AmountOfCharacters), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMOUNTOFCHARACTERS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AmountOfCharacters), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCAPTCHAISCORRECT", AV9CaptchaIsCorrect);
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV45UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLASTEMAILSENT", context.localUtil.TToC( AV22LastEmailSent, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV63IDP_State));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV35ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "vERRORMESSAGE", StringUtil.RTrim( AV15ErrorMessage));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AmountOfCharacters), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMOUNTOFCHARACTERS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AmountOfCharacters), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Title", StringUtil.RTrim( Responsivetable_mainattributes_attributes_Title));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Open));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Showborders));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Containseditableform));
      }

      protected void RenderHtmlCloseForm4C2( )
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
         return "K2BFSG.RecoverPasswordStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Recover Password Step 1", "") ;
      }

      protected void WB4C0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
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
            ucResponsivetable_mainattributes_attributes.SetProperty("Title", Responsivetable_mainattributes_attributes_Title);
            ucResponsivetable_mainattributes_attributes.SetProperty("Collapsible", Responsivetable_mainattributes_attributes_Collapsible);
            ucResponsivetable_mainattributes_attributes.SetProperty("Open", Responsivetable_mainattributes_attributes_Open);
            ucResponsivetable_mainattributes_attributes.SetProperty("ShowBorders", Responsivetable_mainattributes_attributes_Showborders);
            ucResponsivetable_mainattributes_attributes.SetProperty("ContainsEditableForm", Responsivetable_mainattributes_attributes_Containseditableform);
            ucResponsivetable_mainattributes_attributes.Render(context, "k2bt_component", Responsivetable_mainattributes_attributes_Internalname, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTESContainer"+"Responsivetable_mainattributes_attributes_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_username_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, context.GetMessage( "K2BT_GAM_Username", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, StringUtil.RTrim( AV56UserName), StringUtil.RTrim( context.localUtil.Format( AV56UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_useremail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUseremail_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUseremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUseremail_Internalname, context.GetMessage( "K2BT_GAM_Email", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUseremail_Internalname, AV57UserEmail, StringUtil.RTrim( context.localUtil.Format( AV57UserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUseremail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUseremail_Visible, edtavUseremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userbirthday_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserbirthday_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserbirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserbirthday_Internalname, context.GetMessage( "K2BT_GAM_Birthday", ""), "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUserbirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUserbirthday_Internalname, context.localUtil.Format(AV58UserBirthDay, "99/99/9999"), context.localUtil.Format( AV58UserBirthDay, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserbirthday_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", edtavUserbirthday_Visible, edtavUserbirthday_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_bitmap( context, edtavUserbirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavUserbirthday_Visible==0)||(edtavUserbirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTable_container_userfirstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserfirstname_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserfirstname_Internalname, context.GetMessage( "K2BT_GAM_FirstName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserfirstname_Internalname, StringUtil.RTrim( AV59UserFirstName), StringUtil.RTrim( context.localUtil.Format( AV59UserFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserfirstname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUserfirstname_Visible, edtavUserfirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblock_captchadescription_cellcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, context.GetMessage( "K2BT_GAM_Pleaseinsertthetextbelow", ""), "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_captchaimage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute_Trn" + " " + ((StringUtil.StrCmp(imgavCaptchaimage_gximage, "")==0) ? "" : "GX_Image_"+imgavCaptchaimage_gximage+"_Class");
            StyleString = "";
            AV60CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV60CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV69Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV60CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV60CaptchaImage)) ? AV69Captchaimage_GXI : context.PathToRelativeUrl( AV60CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV60CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_captchatext_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV61CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV61CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "K2BDescription", "start", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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

      protected void START4C2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Recover Password Step 1", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4C0( ) ;
      }

      protected void WS4C2( )
      {
         START4C2( ) ;
         EVT4C2( ) ;
      }

      protected void EVT4C2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E114C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E124C2 ();
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
                                 E134C2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E144C2 ();
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

      protected void WE4C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4C2( ) ;
            }
         }
      }

      protected void PA4C2( )
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
               GX_FocusControl = edtavUsername_Internalname;
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
         RF4C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E114C2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144C2 ();
            WB4C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4C2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV45UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AmountOfCharacters), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMOUNTOFCHARACTERS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AmountOfCharacters), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Responsivetable_mainattributes_attributes_Title = cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Title");
            Responsivetable_mainattributes_attributes_Collapsible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Collapsible"));
            Responsivetable_mainattributes_attributes_Open = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Open"));
            Responsivetable_mainattributes_attributes_Showborders = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Showborders"));
            Responsivetable_mainattributes_attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            AV56UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV56UserName", AV56UserName);
            AV57UserEmail = cgiGet( edtavUseremail_Internalname);
            AssignAttri("", false, "AV57UserEmail", AV57UserEmail);
            if ( context.localUtil.VCDate( cgiGet( edtavUserbirthday_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "User Birth Day", "")}), 1, "vUSERBIRTHDAY");
               GX_FocusControl = edtavUserbirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV58UserBirthDay = DateTime.MinValue;
               AssignAttri("", false, "AV58UserBirthDay", context.localUtil.Format(AV58UserBirthDay, "99/99/9999"));
            }
            else
            {
               AV58UserBirthDay = context.localUtil.CToD( cgiGet( edtavUserbirthday_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV58UserBirthDay", context.localUtil.Format(AV58UserBirthDay, "99/99/9999"));
            }
            AV59UserFirstName = cgiGet( edtavUserfirstname_Internalname);
            AssignAttri("", false, "AV59UserFirstName", AV59UserFirstName);
            AV60CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV61CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV61CaptchaText", AV61CaptchaText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S142( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV6AmountOfCharacters = 5;
         AssignAttri("", false, "AV6AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV6AmountOfCharacters), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMOUNTOFCHARACTERS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AmountOfCharacters), "ZZZ9"), context));
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void E114C2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E124C2 ();
         if (returnInSub) return;
      }

      protected void E124C2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV67GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV66GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV66GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV67GXV2 <= AV66GXV1.Count )
         {
            AV64ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV66GXV1.Item(AV67GXV2));
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {AV64ActivityLogProperty.gxTpr_Attributename,AV64ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV67GXV2 = (int)(AV67GXV2+1);
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadrecoverpasswordrequirementsparameters(context ).execute( out  AV27RequireEmail, out  AV28RequireFirstName, out  AV26RequireBirthday) ;
         edtavUserbirthday_Visible = (AV26RequireBirthday ? 1 : 0);
         AssignProp("", false, edtavUserbirthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserbirthday_Visible), 5, 0), true);
         edtavUseremail_Visible = (AV27RequireEmail ? 1 : 0);
         AssignProp("", false, edtavUseremail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseremail_Visible), 5, 0), true);
         edtavUserfirstname_Visible = (AV28RequireFirstName ? 1 : 0);
         AssignProp("", false, edtavUserfirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserfirstname_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ADDARTIFICIALDELAY' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EVALUATECAPTCHACORRECTNESS' */
         S172 ();
         if (returnInSub) return;
         if ( AV9CaptchaIsCorrect )
         {
            new GeneXus.Programs.k2bfsg.loadrecoverpasswordrequirementsparameters(context ).execute( out  AV27RequireEmail, out  AV28RequireFirstName, out  AV26RequireBirthday) ;
            AV65ValidFields = true;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56UserName)) )
            {
               new k2btoolsmsg(context ).execute(  context.GetMessage( "K2BT_GAM_UserNameCannotBeEmpty", ""),  2) ;
               AV65ValidFields = false;
            }
            if ( AV27RequireEmail && String.IsNullOrEmpty(StringUtil.RTrim( AV57UserEmail)) )
            {
               new k2btoolsmsg(context ).execute(  context.GetMessage( "K2BT_GAM_UserEmailCannotBeEmpty", ""),  2) ;
               AV65ValidFields = false;
            }
            if ( AV28RequireFirstName && String.IsNullOrEmpty(StringUtil.RTrim( AV59UserFirstName)) )
            {
               new k2btoolsmsg(context ).execute(  context.GetMessage( "K2BT_GAM_UserFirstNameCannotBeEmpty", ""),  2) ;
               AV65ValidFields = false;
            }
            if ( AV26RequireBirthday && (DateTime.MinValue==AV58UserBirthDay) )
            {
               new k2btoolsmsg(context ).execute(  context.GetMessage( "K2BT_GAM_UserBirthdayCannotBeEmpty", ""),  2) ;
               AV65ValidFields = false;
            }
            if ( AV65ValidFields )
            {
               AV15ErrorMessage = "";
               AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
               AV44User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV45UserAuthTypeName, AV56UserName, out  AV16Errors);
               if ( AV16Errors.Count == 0 )
               {
                  AV17ExecuteAction = true;
                  if ( AV26RequireBirthday && ( DateTimeUtil.ResetTime ( AV58UserBirthDay ) != DateTimeUtil.ResetTime ( AV44User.gxTpr_Birthday ) ) )
                  {
                     AV17ExecuteAction = false;
                  }
                  if ( AV27RequireEmail && ( StringUtil.StrCmp(AV57UserEmail, AV44User.gxTpr_Email) != 0 ) )
                  {
                     AV17ExecuteAction = false;
                  }
                  if ( AV28RequireFirstName && ( StringUtil.StrCmp(AV59UserFirstName, AV44User.gxTpr_Firstname) != 0 ) )
                  {
                     AV17ExecuteAction = false;
                  }
                  if ( AV17ExecuteAction )
                  {
                     /* Execute user subroutine: 'EXECUTEACTIONTORECOVER' */
                     S182 ();
                     if (returnInSub) return;
                  }
                  else
                  {
                     AV15ErrorMessage = context.GetMessage( "K2BT_GAM_Candidatefailedidentitychallenges", "");
                     AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S192 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S192 ();
                  if (returnInSub) return;
               }
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "K2BT_GAM_Captchadoesnotmatch", ""));
            /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
            S152 ();
            if (returnInSub) return;
         }
      }

      protected void S182( )
      {
         /* 'EXECUTEACTIONTORECOVER' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadrecoverpasswordemailparameters(context ).execute( out  AV31SendPasswordEmail, out  AV24MailSubject, out  AV5MailMessage, out  AV42SMTPServerName, out  AV43SMTPUserName, out  AV38SMTPPassword, out  AV39SMTPPort, out  AV37SMTPAuthentication, out  AV41SMTPSenderName, out  AV40SMTPSenderAddress, out  AV25MinMinutesBetweenEmails, out  AV33ServerHost, out  AV34ServerPort, out  AV32ServerBaseURL) ;
         /* Execute user subroutine: 'GETLASTEMAILSENTTIME' */
         S202 ();
         if (returnInSub) return;
         if ( (DateTime.MinValue==AV22LastEmailSent) || ( DateTimeUtil.TAdd( AV22LastEmailSent, 60*(AV25MinMinutesBetweenEmails)) <= DateTimeUtil.ServerNow( context, pr_default) ) )
         {
            AV21KeyToChangePassword = AV44User.recoverpasswordbykey(out  AV16Errors);
            if ( AV16Errors.Count == 0 )
            {
               if ( AV31SendPasswordEmail )
               {
                  AV62Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
                  new GeneXus.Programs.k2bfsg.sendrecoveryemail(context).executeSubmit(  AV56UserName,  AV63IDP_State) ;
                  CallWebObject(formatLink("k2bfsg.emailsent.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  CallWebObject(formatLink("k2bfsg.recoverpasswordstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV63IDP_State)),UrlEncode(StringUtil.RTrim(AV21KeyToChangePassword))}, new string[] {"IDP_State","KeyToChangePassword"}) );
                  context.wjLocDisableFrm = 1;
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S192 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S192 ();
            if (returnInSub) return;
         }
      }

      protected void S162( )
      {
         /* 'ADDARTIFICIALDELAY' Routine */
         returnInSub = false;
         AV30seconds = (short)(NumberUtil.Random( )*3);
         AV29result = GXUtil.Sleep( AV30seconds);
      }

      protected void S202( )
      {
         /* 'GETLASTEMAILSENTTIME' Routine */
         returnInSub = false;
         AV18GAMUserAttribute = AV44User.getattribute("LastPasswordRecoveryEmailDate", out  AV16Errors);
         if ( AV16Errors.Count == 0 )
         {
            AV22LastEmailSent = context.localUtil.CToT( AV18GAMUserAttribute.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else
         {
            AV22LastEmailSent = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E134C2 ();
         if (returnInSub) return;
      }

      protected void E134C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44User", AV44User);
      }

      protected void S192( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV35ShowDetailedMessages) ;
         AssignAttri("", false, "AV35ShowDetailedMessages", AV35ShowDetailedMessages);
         if ( AV35ShowDetailedMessages )
         {
            GX_msglist.addItem(context.GetMessage( "K2BT_GAM_AnEmailWasSent", ""));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ErrorMessage)) )
            {
               GX_msglist.addItem(AV15ErrorMessage);
            }
            AV68GXV3 = 1;
            while ( AV68GXV3 <= AV16Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV68GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV68GXV3 = (int)(AV68GXV3+1);
            }
         }
         else
         {
            CallWebObject(formatLink("k2bfsg.emailsent.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'EVALUATECAPTCHACORRECTNESS' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV11CaptchaRequiredText) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11CaptchaRequiredText)) )
         {
            AV9CaptchaIsCorrect = false;
            AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
         }
         else
         {
            if ( StringUtil.StrCmp(AV11CaptchaRequiredText, AV61CaptchaText) == 0 )
            {
               AV9CaptchaIsCorrect = true;
               AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
            }
            else
            {
               AV9CaptchaIsCorrect = false;
               AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
            }
         }
      }

      protected void S212( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV10CaptchaProvider.generatestringtoken(AV6AmountOfCharacters)) ;
      }

      protected void S152( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CREATENEWCAPTCHA' */
         S212 ();
         if (returnInSub) return;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV11CaptchaRequiredText) ;
         lblCaptchadescription_Visible = 1;
         AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
         imgavCaptchaimage_Visible = 1;
         AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
         edtavCaptchatext_Visible = 1;
         AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
         AV7Base64String = AV10CaptchaProvider.generateimage(180, 75, AV11CaptchaRequiredText);
         AV61CaptchaText = "";
         AssignAttri("", false, "AV61CaptchaText", AV61CaptchaText);
         AV60CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV7Base64String;
         AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60CaptchaImage)) ? AV69Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV60CaptchaImage))), true);
         AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV60CaptchaImage), true);
         AV69Captchaimage_GXI = GXDbFile.PathToUrl( context.GetMessage( "data:image/jpeg;charset=utf-8;base64,", "")+AV7Base64String);
         AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV60CaptchaImage)) ? AV69Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV60CaptchaImage))), true);
         AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV60CaptchaImage), true);
         AV11CaptchaRequiredText = "";
      }

      protected void nextLoad( )
      {
      }

      protected void E144C2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV63IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV63IDP_State", AV63IDP_State);
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
         PA4C2( ) ;
         WS4C2( ) ;
         WE4C2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221393565", true, true);
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
         context.AddJavascriptSource("k2bfsg/recoverpasswordstep1.js", "?202431221393569", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUsername_Internalname = "vUSERNAME";
         divTable_container_username_Internalname = "TABLE_CONTAINER_USERNAME";
         edtavUseremail_Internalname = "vUSEREMAIL";
         divTable_container_useremail_Internalname = "TABLE_CONTAINER_USEREMAIL";
         edtavUserbirthday_Internalname = "vUSERBIRTHDAY";
         divTable_container_userbirthday_Internalname = "TABLE_CONTAINER_USERBIRTHDAY";
         edtavUserfirstname_Internalname = "vUSERFIRSTNAME";
         divTable_container_userfirstname_Internalname = "TABLE_CONTAINER_USERFIRSTNAME";
         divColumn_Internalname = "COLUMN";
         lblCaptchadescription_Internalname = "CAPTCHADESCRIPTION";
         divTextblock_captchadescription_cellcontainertable_Internalname = "TEXTBLOCK_CAPTCHADESCRIPTION_CELLCONTAINERTABLE";
         imgavCaptchaimage_Internalname = "vCAPTCHAIMAGE";
         divTable_container_captchaimage_Internalname = "TABLE_CONTAINER_CAPTCHAIMAGE";
         edtavCaptchatext_Internalname = "vCAPTCHATEXT";
         divTable_container_captchatext_Internalname = "TABLE_CONTAINER_CAPTCHATEXT";
         divColumn1_Internalname = "COLUMN1";
         divColumns_Internalname = "COLUMNS";
         bttConfirm_Internalname = "CONFIRM";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_content_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_CONTENT";
         Responsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
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
         edtavCaptchatext_Jsonclick = "";
         edtavCaptchatext_Enabled = 1;
         edtavCaptchatext_Visible = 1;
         imgavCaptchaimage_gximage = "";
         imgavCaptchaimage_Visible = 1;
         lblCaptchadescription_Visible = 1;
         edtavUserfirstname_Jsonclick = "";
         edtavUserfirstname_Enabled = 1;
         edtavUserfirstname_Visible = 1;
         edtavUserbirthday_Jsonclick = "";
         edtavUserbirthday_Enabled = 1;
         edtavUserbirthday_Visible = 1;
         edtavUseremail_Jsonclick = "";
         edtavUseremail_Enabled = 1;
         edtavUseremail_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         Responsivetable_mainattributes_attributes_Containseditableform = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Open = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Collapsible = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_attributes_Title = context.GetMessage( "K2BT_GAM_RecoverPassword", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV45UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV6AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavUserbirthday_Visible',ctrl:'vUSERBIRTHDAY',prop:'Visible'},{av:'edtavUseremail_Visible',ctrl:'vUSEREMAIL',prop:'Visible'},{av:'edtavUserfirstname_Visible',ctrl:'vUSERFIRSTNAME',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E134C2',iparms:[{av:'AV9CaptchaIsCorrect',fld:'vCAPTCHAISCORRECT',pic:''},{av:'AV56UserName',fld:'vUSERNAME',pic:''},{av:'AV57UserEmail',fld:'vUSEREMAIL',pic:''},{av:'AV59UserFirstName',fld:'vUSERFIRSTNAME',pic:''},{av:'AV58UserBirthDay',fld:'vUSERBIRTHDAY',pic:''},{av:'AV45UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV61CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV22LastEmailSent',fld:'vLASTEMAILSENT',pic:'99/99/99 99:99'},{av:'AV63IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV35ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:''},{av:'AV15ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV6AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV15ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV9CaptchaIsCorrect',fld:'vCAPTCHAISCORRECT',pic:''},{av:'AV56UserName',fld:'vUSERNAME',pic:''},{av:'AV63IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV35ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:''},{av:'lblCaptchadescription_Visible',ctrl:'CAPTCHADESCRIPTION',prop:'Visible'},{av:'imgavCaptchaimage_Visible',ctrl:'vCAPTCHAIMAGE',prop:'Visible'},{av:'edtavCaptchatext_Visible',ctrl:'vCAPTCHATEXT',prop:'Visible'},{av:'AV61CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV60CaptchaImage',fld:'vCAPTCHAIMAGE',pic:''},{av:'AV22LastEmailSent',fld:'vLASTEMAILSENT',pic:'99/99/99 99:99'}]}");
         setEventMetadata("VALIDV_USERBIRTHDAY","{handler:'Validv_Userbirthday',iparms:[]");
         setEventMetadata("VALIDV_USERBIRTHDAY",",oparms:[]}");
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
         wcpOAV63IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV45UserAuthTypeName = "";
         GXKey = "";
         AV22LastEmailSent = (DateTime)(DateTime.MinValue);
         AV15ErrorMessage = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucResponsivetable_mainattributes_attributes = new GXUserControl();
         TempTags = "";
         AV56UserName = "";
         AV57UserEmail = "";
         AV58UserBirthDay = DateTime.MinValue;
         AV59UserFirstName = "";
         lblCaptchadescription_Jsonclick = "";
         AV60CaptchaImage = "";
         AV69Captchaimage_GXI = "";
         sImgUrl = "";
         AV61CaptchaText = "";
         bttConfirm_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV66GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV64ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         AV44User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV24MailSubject = "";
         AV5MailMessage = "";
         AV42SMTPServerName = "";
         AV43SMTPUserName = "";
         AV38SMTPPassword = "";
         AV41SMTPSenderName = "";
         AV40SMTPSenderAddress = "";
         AV33ServerHost = "";
         AV32ServerBaseURL = "";
         AV21KeyToChangePassword = "";
         AV62Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV18GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV14Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV11CaptchaRequiredText = "";
         AV10CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV7Base64String = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.recoverpasswordstep1__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short AV6AmountOfCharacters ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV39SMTPPort ;
      private short AV37SMTPAuthentication ;
      private short AV25MinMinutesBetweenEmails ;
      private short AV30seconds ;
      private short AV29result ;
      private short nGXWrapped ;
      private int edtavUsername_Enabled ;
      private int edtavUseremail_Visible ;
      private int edtavUseremail_Enabled ;
      private int edtavUserbirthday_Visible ;
      private int edtavUserbirthday_Enabled ;
      private int edtavUserfirstname_Visible ;
      private int edtavUserfirstname_Enabled ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int edtavCaptchatext_Enabled ;
      private int AV67GXV2 ;
      private int AV34ServerPort ;
      private int AV68GXV3 ;
      private int idxLst ;
      private string AV63IDP_State ;
      private string wcpOAV63IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV45UserAuthTypeName ;
      private string GXKey ;
      private string AV15ErrorMessage ;
      private string Responsivetable_mainattributes_attributes_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Responsivetable_mainattributes_attributes_Internalname ;
      private string divResponsivetable_mainattributes_attributes_content_Internalname ;
      private string divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname ;
      private string divColumns_Internalname ;
      private string divColumn_Internalname ;
      private string divTable_container_username_Internalname ;
      private string edtavUsername_Internalname ;
      private string TempTags ;
      private string AV56UserName ;
      private string edtavUsername_Jsonclick ;
      private string divTable_container_useremail_Internalname ;
      private string edtavUseremail_Internalname ;
      private string edtavUseremail_Jsonclick ;
      private string divTable_container_userbirthday_Internalname ;
      private string edtavUserbirthday_Internalname ;
      private string edtavUserbirthday_Jsonclick ;
      private string divTable_container_userfirstname_Internalname ;
      private string edtavUserfirstname_Internalname ;
      private string AV59UserFirstName ;
      private string edtavUserfirstname_Jsonclick ;
      private string divColumn1_Internalname ;
      private string divTextblock_captchadescription_cellcontainertable_Internalname ;
      private string lblCaptchadescription_Internalname ;
      private string lblCaptchadescription_Jsonclick ;
      private string divTable_container_captchaimage_Internalname ;
      private string imgavCaptchaimage_gximage ;
      private string sImgUrl ;
      private string imgavCaptchaimage_Internalname ;
      private string divTable_container_captchatext_Internalname ;
      private string edtavCaptchatext_Internalname ;
      private string AV61CaptchaText ;
      private string edtavCaptchatext_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV24MailSubject ;
      private string AV5MailMessage ;
      private string AV42SMTPServerName ;
      private string AV43SMTPUserName ;
      private string AV38SMTPPassword ;
      private string AV41SMTPSenderName ;
      private string AV40SMTPSenderAddress ;
      private string AV33ServerHost ;
      private string AV21KeyToChangePassword ;
      private string AV11CaptchaRequiredText ;
      private string AV7Base64String ;
      private DateTime AV22LastEmailSent ;
      private DateTime AV58UserBirthDay ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9CaptchaIsCorrect ;
      private bool AV35ShowDetailedMessages ;
      private bool Responsivetable_mainattributes_attributes_Collapsible ;
      private bool Responsivetable_mainattributes_attributes_Open ;
      private bool Responsivetable_mainattributes_attributes_Showborders ;
      private bool Responsivetable_mainattributes_attributes_Containseditableform ;
      private bool wbLoad ;
      private bool AV60CaptchaImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV27RequireEmail ;
      private bool AV28RequireFirstName ;
      private bool AV26RequireBirthday ;
      private bool AV65ValidFields ;
      private bool AV17ExecuteAction ;
      private bool AV31SendPasswordEmail ;
      private string AV57UserEmail ;
      private string AV69Captchaimage_GXI ;
      private string AV32ServerBaseURL ;
      private string AV60CaptchaImage ;
      private GXUserControl ucResponsivetable_mainattributes_attributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private SdtK2BToolsCaptchaProvider AV10CaptchaProvider ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16Errors ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV66GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV14Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV18GAMUserAttribute ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV44User ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV62Application ;
      private SdtK2BAttributeValue_Item AV64ActivityLogProperty ;
   }

   public class recoverpasswordstep1__default : DataStoreHelperBase, IDataStoreHelper
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
