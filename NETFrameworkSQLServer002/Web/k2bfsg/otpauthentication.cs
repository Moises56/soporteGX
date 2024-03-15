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
   public class otpauthentication : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public otpauthentication( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BTools.DesignSystems.Aries.Aries", true);
      }

      public otpauthentication( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV7IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV7IDP_State;
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
               AV7IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV7IDP_State", AV7IDP_State);
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
            PA4B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavUsername_Enabled = 0;
               AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
               WS4B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4B2( ) ;
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
         context.SendWebValue( context.GetMessage( "K2BT_GAM_OTPLogin", "")) ;
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
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal K2BFormLogin\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BFormLogin\" data-gx-class=\"form-horizontal K2BFormLogin\" novalidate action=\""+formatLink("k2bfsg.otpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal K2BFormLogin", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vAUTHENTICATIONTYPENAME", StringUtil.RTrim( AV13AuthenticationTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUTHENTICATIONTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AuthenticationTypeName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vUSETWOFACTORAUTHENTICATION", AV17UseTwoFactorAuthentication);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSETWOFACTORAUTHENTICATION", GetSecureSignedToken( "", AV17UseTwoFactorAuthentication, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLOGONTO", StringUtil.RTrim( AV28LogOnTo));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28LogOnTo, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"OTPAuthentication");
         forbiddenHiddens.Add("UserName", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("k2bfsg\\otpauthentication:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAUTHENTICATIONTYPENAME", StringUtil.RTrim( AV13AuthenticationTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUTHENTICATIONTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AuthenticationTypeName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vUSETWOFACTORAUTHENTICATION", AV17UseTwoFactorAuthentication);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSETWOFACTORAUTHENTICATION", GetSecureSignedToken( "", AV17UseTwoFactorAuthentication, context));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV7IDP_State));
         GxWebStd.gx_hidden_field( context, "vLOGONTO", StringUtil.RTrim( AV28LogOnTo));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28LogOnTo, "")), context));
      }

      protected void RenderHtmlCloseForm4B2( )
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
         return "K2BFSG.OTPAuthentication" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_OTPLogin", "") ;
      }

      protected void WB4B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BT_MainLoginTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginImageContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagetransparency_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginImageTransparency", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginForm", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;align-self:center;", "div");
            /* Static images/pictures */
            ClassString = "K2BT_LoginLogo" + " " + ((StringUtil.StrCmp(imgImage_gximage, "")==0) ? "GX_Image_K2BToolsMLTransp_Class" : "GX_Image_"+imgImage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "b204c38c-79ae-43b6-aab7-fdc3fcbe6833", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\OTPAuthentication.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer K2BT_EditableForm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblErrors_Internalname, lblErrors_Caption, "", "", lblErrors_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_2FAMessage", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\OTPAuthentication.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV11UserName, StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\OTPAuthentication.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, context.GetMessage( "K2BT_GAM_OTPCode", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV12UserPassword), StringUtil.RTrim( context.localUtil.Format( AV12UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 10, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\OTPAuthentication.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttValidatecode_Internalname, "", context.GetMessage( "K2BT_GAM_ValidateCode", ""), bttValidatecode_Jsonclick, 5, "", "", StyleString, ClassString, bttValidatecode_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_VALIDATECODE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\OTPAuthentication.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBacktologin_Internalname, "", context.GetMessage( "K2BT_GAM_BackToLogin", ""), bttBacktologin_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_BACKTOLOGIN\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\OTPAuthentication.htm");
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4B2( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_OTPLogin", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4B0( ) ;
      }

      protected void WS4B2( )
      {
         START4B2( ) ;
         EVT4B2( ) ;
      }

      protected void EVT4B2( )
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
                           E114B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E124B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'E_VALIDATECODE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'E_ValidateCode' */
                           E134B2 ();
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
                                 E144B2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'E_BACKTOLOGIN'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'E_BackToLogin' */
                           E154B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E164B2 ();
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

      protected void WE4B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4B2( ) ;
            }
         }
      }

      protected void PA4B2( )
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
         RF4B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
      }

      protected void RF4B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E124B2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E164B2 ();
            WB4B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4B2( )
      {
         GxWebStd.gx_hidden_field( context, "vAUTHENTICATIONTYPENAME", StringUtil.RTrim( AV13AuthenticationTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUTHENTICATIONTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AuthenticationTypeName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vUSETWOFACTORAUTHENTICATION", AV17UseTwoFactorAuthentication);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSETWOFACTORAUTHENTICATION", GetSecureSignedToken( "", AV17UseTwoFactorAuthentication, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLOGONTO", StringUtil.RTrim( AV28LogOnTo));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28LogOnTo, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV11UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV11UserName", AV11UserName);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), context));
            AV12UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV12UserPassword", AV12UserPassword);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"OTPAuthentication");
            AV11UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV11UserName", AV11UserName);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), context));
            forbiddenHiddens.Add("UserName", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("k2bfsg\\otpauthentication:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E114B2 ();
         if (returnInSub) return;
      }

      protected void E114B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV34GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV33GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV33GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV34GXV2 <= AV33GXV1.Count )
         {
            AV24ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV33GXV1.Item(AV34GXV2));
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {AV24ActivityLogProperty.gxTpr_Attributename,AV24ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S162 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV35GXV3 = 1;
         while ( AV35GXV3 <= AV6Errors.Count )
         {
            AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV6Errors.Item(AV35GXV3));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV5Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV5Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV35GXV3 = (int)(AV35GXV3+1);
         }
      }

      protected void E124B2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertootpauthentication(out  AV13AuthenticationTypeName, out  AV17UseTwoFactorAuthentication, out  AV6Errors);
         if ( AV6Errors.Count > 0 )
         {
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            bttValidatecode_Visible = 0;
            AssignProp("", false, bttValidatecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttValidatecode_Visible), 5, 0), true);
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S152 ();
            if (returnInSub) return;
         }
         else
         {
            AV6Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
            AV36GXV4 = 1;
            while ( AV36GXV4 <= AV6Errors.Count )
            {
               AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV6Errors.Item(AV36GXV4));
               if ( AV5Error.gxTpr_Code != 410 )
               {
                  lblErrors_Caption = lblErrors_Caption+StringUtil.NewLine( )+AV5Error.gxTpr_Message+StringUtil.NewLine( );
                  AssignProp("", false, lblErrors_Internalname, "Caption", lblErrors_Caption, true);
               }
               AV36GXV4 = (int)(AV36GXV4+1);
            }
            AV11UserName = AV9User.gxTpr_Name;
            AssignAttri("", false, "AV11UserName", AV11UserName);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), context));
         }
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E134B2( )
      {
         /* 'E_ValidateCode' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_VALIDATECODE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16AdditionalParameter", AV16AdditionalParameter);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144B2 ();
         if (returnInSub) return;
      }

      protected void E144B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_VALIDATECODE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16AdditionalParameter", AV16AdditionalParameter);
      }

      protected void S132( )
      {
         /* 'U_VALIDATECODE' Routine */
         returnInSub = false;
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertootpauthentication(out  AV13AuthenticationTypeName, out  AV17UseTwoFactorAuthentication, out  AV6Errors);
         if ( AV6Errors.Count == 0 )
         {
            AV16AdditionalParameter.gxTpr_Authenticationtypename = AV13AuthenticationTypeName;
            AV16AdditionalParameter.gxTpr_Usetwofactorauthentication = AV17UseTwoFactorAuthentication;
            AV16AdditionalParameter.gxTpr_Otpstep = 2;
            AV16AdditionalParameter.gxTpr_Idpstate = AV7IDP_State;
            AV14LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV11UserName, AV12UserPassword, AV16AdditionalParameter, out  AV6Errors);
            if ( AV14LoginOK )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7IDP_State)) )
               {
                  new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV28LogOnTo,  AV11UserName) ;
                  AV15URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15URL)) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV15URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
            else
            {
               if ( AV6Errors.Count > 0 )
               {
                  AV12UserPassword = "";
                  AssignAttri("", false, "AV12UserPassword", AV12UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S152 ();
                  if (returnInSub) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S152 ();
            if (returnInSub) return;
         }
      }

      protected void E154B2( )
      {
         /* 'E_BackToLogin' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BACKTOLOGIN' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'U_BACKTOLOGIN' Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV7IDP_State) )
         {
            CallWebObject(formatLink("k2bfsg.remotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7IDP_State))}, new string[] {"IDP_State"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            CallWebObject(formatLink("k2bfsg.login.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E164B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV7IDP_State", AV7IDP_State);
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
         PA4B2( ) ;
         WS4B2( ) ;
         WE4B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221383499", true, true);
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
         context.AddJavascriptSource("k2bfsg/otpauthentication.js", "?20243122138354", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
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
         divImagetransparency_Internalname = "IMAGETRANSPARENCY";
         divImagecontainer_Internalname = "IMAGECONTAINER";
         imgImage_Internalname = "IMAGE";
         lblErrors_Internalname = "ERRORS";
         edtavUsername_Internalname = "vUSERNAME";
         divTable_container_username_Internalname = "TABLE_CONTAINER_USERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divTable_container_userpassword_Internalname = "TABLE_CONTAINER_USERPASSWORD";
         bttValidatecode_Internalname = "VALIDATECODE";
         bttBacktologin_Internalname = "BACKTOLOGIN";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divTable22_Internalname = "TABLE22";
         divTable3_Internalname = "TABLE3";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BTools.DesignSystems.Aries.Aries", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttValidatecode_Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         lblErrors_Caption = context.GetMessage( "K2BT_GAM_EnterTFAValue", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:'',hsh:true},{av:'AV17UseTwoFactorAuthentication',fld:'vUSETWOFACTORAUTHENTICATION',pic:'',hsh:true},{av:'AV28LogOnTo',fld:'vLOGONTO',pic:'',hsh:true},{av:'AV11UserName',fld:'vUSERNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_VALIDATECODE'","{handler:'E134B2',iparms:[{av:'AV13AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:'',hsh:true},{av:'AV17UseTwoFactorAuthentication',fld:'vUSETWOFACTORAUTHENTICATION',pic:'',hsh:true},{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV11UserName',fld:'vUSERNAME',pic:'',hsh:true},{av:'AV12UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV28LogOnTo',fld:'vLOGONTO',pic:'',hsh:true}]");
         setEventMetadata("'E_VALIDATECODE'",",oparms:[{av:'AV12UserPassword',fld:'vUSERPASSWORD',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E144B2',iparms:[{av:'AV13AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:'',hsh:true},{av:'AV17UseTwoFactorAuthentication',fld:'vUSETWOFACTORAUTHENTICATION',pic:'',hsh:true},{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV11UserName',fld:'vUSERNAME',pic:'',hsh:true},{av:'AV12UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV28LogOnTo',fld:'vLOGONTO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12UserPassword',fld:'vUSERPASSWORD',pic:''}]}");
         setEventMetadata("'E_BACKTOLOGIN'","{handler:'E154B2',iparms:[{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("'E_BACKTOLOGIN'",",oparms:[{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''}]}");
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
         wcpOAV7IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV13AuthenticationTypeName = "";
         AV11UserName = "";
         AV28LogOnTo = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         imgImage_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblErrors_Jsonclick = "";
         TempTags = "";
         AV12UserPassword = "";
         bttValidatecode_Jsonclick = "";
         bttBacktologin_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV33GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV24ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         AV6Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV15URL = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavUsername_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int bttValidatecode_Visible ;
      private int AV34GXV2 ;
      private int AV35GXV3 ;
      private int AV36GXV4 ;
      private int idxLst ;
      private string AV7IDP_State ;
      private string wcpOAV7IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavUsername_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV13AuthenticationTypeName ;
      private string AV28LogOnTo ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable3_Internalname ;
      private string divImagecontainer_Internalname ;
      private string divImagetransparency_Internalname ;
      private string divTable22_Internalname ;
      private string ClassString ;
      private string imgImage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string lblErrors_Internalname ;
      private string lblErrors_Caption ;
      private string lblErrors_Jsonclick ;
      private string divTable_container_username_Internalname ;
      private string TempTags ;
      private string edtavUsername_Jsonclick ;
      private string divTable_container_userpassword_Internalname ;
      private string edtavUserpassword_Internalname ;
      private string AV12UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttValidatecode_Internalname ;
      private string bttValidatecode_Jsonclick ;
      private string bttBacktologin_Internalname ;
      private string bttBacktologin_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17UseTwoFactorAuthentication ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14LoginOK ;
      private string AV11UserName ;
      private string AV15URL ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV6Errors ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV33GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV5Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9User ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV16AdditionalParameter ;
      private SdtK2BAttributeValue_Item AV24ActivityLogProperty ;
   }

}
