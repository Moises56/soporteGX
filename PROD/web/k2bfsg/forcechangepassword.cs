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
   public class forcechangepassword : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public forcechangepassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public forcechangepassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV11IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV11IDP_State;
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
               AV11IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV11IDP_State", AV11IDP_State);
               GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
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
            PA4A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavUsername_Enabled = 0;
               AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
               WS4A2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4A2( ) ;
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
         context.SendWebValue( "Force Change Password") ;
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
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV11IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV11IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Title", StringUtil.RTrim( Responsivetable_mainattributes_attributes_Title));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Open));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Showborders));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Containseditableform));
      }

      protected void RenderHtmlCloseForm4A2( )
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
         return "K2BFSG.ForceChangePassword" ;
      }

      public override string GetPgmdesc( )
      {
         return "Force Change Password" ;
      }

      protected void WB4A0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_username_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV16UserName, StringUtil.RTrim( context.localUtil.Format( AV16UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\ForceChangePassword.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "Current password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV17UserPassword), StringUtil.RTrim( context.localUtil.Format( AV17UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\ForceChangePassword.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userpasswordnew_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserpasswordnew_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpasswordnew_Internalname, "New password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpasswordnew_Internalname, StringUtil.RTrim( AV18UserPasswordNew), StringUtil.RTrim( context.localUtil.Format( AV18UserPasswordNew, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpasswordnew_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserpasswordnew_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\ForceChangePassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userpasswordnewconf_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserpasswordnewconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpasswordnewconf_Internalname, "New password (Confirmation)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpasswordnewconf_Internalname, StringUtil.RTrim( AV19UserPasswordNewConf), StringUtil.RTrim( context.localUtil.Format( AV19UserPasswordNewConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpasswordnewconf_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserpasswordnewconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\ForceChangePassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", "Confirm", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\ForceChangePassword.htm");
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

      protected void START4A2( )
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
         Form.Meta.addItem("description", "Force Change Password", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4A0( ) ;
      }

      protected void WS4A2( )
      {
         START4A2( ) ;
         EVT4A2( ) ;
      }

      protected void EVT4A2( )
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
                           E114A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E124A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'E_Confirm' */
                           E134A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E144A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
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

      protected void WE4A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4A2( ) ;
            }
         }
      }

      protected void PA4A2( )
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
         RF4A2( ) ;
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

      protected void RF4A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E124A2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144A2 ();
            WB4A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4A2( )
      {
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV11IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114A2 ();
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
            AV16UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV16UserName", AV16UserName);
            AV17UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV17UserPassword", AV17UserPassword);
            AV18UserPasswordNew = cgiGet( edtavUserpasswordnew_Internalname);
            AssignAttri("", false, "AV18UserPasswordNew", AV18UserPasswordNew);
            AV19UserPasswordNewConf = cgiGet( edtavUserpasswordnewconf_Internalname);
            AssignAttri("", false, "AV19UserPasswordNewConf", AV19UserPasswordNewConf);
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
         E114A2 ();
         if (returnInSub) return;
      }

      protected void E114A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV23GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV22GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV22GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV23GXV2 <= AV22GXV1.Count )
         {
            AV21ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV22GXV1.Item(AV23GXV2));
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {AV21ActivityLogProperty.gxTpr_Attributename,AV21ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV23GXV2 = (int)(AV23GXV2+1);
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E124A2( )
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

      protected void S142( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV15User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertochangepassword();
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15User.gxTpr_Name)) )
         {
            AV16UserName = AV15User.gxTpr_Name;
            AssignAttri("", false, "AV16UserName", AV16UserName);
         }
         else
         {
            AV9Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S152 ();
            if (returnInSub) return;
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

      protected void E134A2( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18UserPasswordNew, AV19UserPasswordNewConf) == 0 )
         {
            AV5isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateusertochangepassword(AV17UserPassword, AV18UserPasswordNew, out  AV9Errors);
            if ( AV5isOK )
            {
               if ( AV9Errors.Count > 0 )
               {
                  GX_msglist.addItem("Your new password has been saved successfully!");
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  new GeneXus.Programs.k2btools.integrationprocedures.updatecontextafterlogin(context ).execute( ) ;
                  if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV11IDP_State) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV11IDP_State) ;
                  }
                  else
                  {
                     AV6URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6URL)) )
                     {
                        new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
                     }
                     else
                     {
                        CallWebObject(formatLink(AV6URL) );
                        context.wjLocDisableFrm = 0;
                     }
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
         else
         {
            GX_msglist.addItem("The new password and confirmation do not match.");
         }
      }

      protected void S152( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV24GXV3 = 1;
         while ( AV24GXV3 <= AV9Errors.Count )
         {
            AV8Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9Errors.Item(AV24GXV3));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV8Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV8Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV24GXV3 = (int)(AV24GXV3+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E144A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV11IDP_State", AV11IDP_State);
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11IDP_State, "")), context));
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
         PA4A2( ) ;
         WS4A2( ) ;
         WE4A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138192945", true, true);
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
         context.AddJavascriptSource("k2bfsg/forcechangepassword.js", "?20243138192950", false, true);
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
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divTable_container_userpassword_Internalname = "TABLE_CONTAINER_USERPASSWORD";
         edtavUserpasswordnew_Internalname = "vUSERPASSWORDNEW";
         divTable_container_userpasswordnew_Internalname = "TABLE_CONTAINER_USERPASSWORDNEW";
         edtavUserpasswordnewconf_Internalname = "vUSERPASSWORDNEWCONF";
         divTable_container_userpasswordnewconf_Internalname = "TABLE_CONTAINER_USERPASSWORDNEWCONF";
         bttConfirm_Internalname = "CONFIRM";
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
         edtavUserpasswordnewconf_Jsonclick = "";
         edtavUserpasswordnewconf_Enabled = 1;
         edtavUserpasswordnew_Jsonclick = "";
         edtavUserpasswordnew_Enabled = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         Responsivetable_mainattributes_attributes_Containseditableform = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Open = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Collapsible = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_attributes_Title = "A password change is required. Choose your new password.";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E134A2',iparms:[{av:'AV18UserPasswordNew',fld:'vUSERPASSWORDNEW',pic:''},{av:'AV19UserPasswordNewConf',fld:'vUSERPASSWORDNEWCONF',pic:''},{av:'AV17UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV11IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[]}");
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
         wcpOAV11IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucResponsivetable_mainattributes_attributes = new GXUserControl();
         TempTags = "";
         AV16UserName = "";
         AV17UserPassword = "";
         AV18UserPasswordNew = "";
         AV19UserPasswordNewConf = "";
         bttConfirm_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV22GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV21ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         AV15User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6URL = "";
         AV8Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
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
      private int edtavUserpassword_Enabled ;
      private int edtavUserpasswordnew_Enabled ;
      private int edtavUserpasswordnewconf_Enabled ;
      private int AV23GXV2 ;
      private int AV24GXV3 ;
      private int idxLst ;
      private string AV11IDP_State ;
      private string wcpOAV11IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavUsername_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string divTable_container_username_Internalname ;
      private string TempTags ;
      private string edtavUsername_Jsonclick ;
      private string divTable_container_userpassword_Internalname ;
      private string edtavUserpassword_Internalname ;
      private string AV17UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string divTable_container_userpasswordnew_Internalname ;
      private string edtavUserpasswordnew_Internalname ;
      private string AV18UserPasswordNew ;
      private string edtavUserpasswordnew_Jsonclick ;
      private string divTable_container_userpasswordnewconf_Internalname ;
      private string edtavUserpasswordnewconf_Internalname ;
      private string AV19UserPasswordNewConf ;
      private string edtavUserpasswordnewconf_Jsonclick ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Responsivetable_mainattributes_attributes_Collapsible ;
      private bool Responsivetable_mainattributes_attributes_Open ;
      private bool Responsivetable_mainattributes_attributes_Showborders ;
      private bool Responsivetable_mainattributes_attributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5isOK ;
      private string AV16UserName ;
      private string AV6URL ;
      private GXUserControl ucResponsivetable_mainattributes_attributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9Errors ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV22GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV15User ;
      private SdtK2BAttributeValue_Item AV21ActivityLogProperty ;
   }

}
