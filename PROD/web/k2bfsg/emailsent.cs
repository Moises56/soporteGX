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
   public class emailsent : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public emailsent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public emailsent( IGxContext context )
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
            PA4F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavGotologin_action_Enabled = 0;
               AssignProp("", false, edtavGotologin_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGotologin_action_Enabled), 5, 0), true);
               WS4F2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4F2( ) ;
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
         context.SendWebValue( "Email sent") ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.emailsent.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Title", StringUtil.RTrim( Attributes_Title));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Open", StringUtil.BoolToStr( Attributes_Open));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Showborders", StringUtil.BoolToStr( Attributes_Showborders));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Attributes_Containseditableform));
      }

      protected void RenderHtmlCloseForm4F2( )
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
         return "K2BFSG.EmailSent" ;
      }

      public override string GetPgmdesc( )
      {
         return "Email sent" ;
      }

      protected void WB4F0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblock_message_cellcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMessage_Internalname, "If the information provided in the last step was correct, an email was sent to your account with instructions to recover your password.", "", "", lblMessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EmailSent.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblock_waittime_cellcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWaittime_Internalname, lblWaittime_Caption, "", "", lblWaittime_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", lblWaittime_Visible, 1, 0, 0, "HLP_K2BFSG\\EmailSent.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGotologin_action_Internalname, StringUtil.RTrim( AV8GoToLogin_Action), StringUtil.RTrim( context.localUtil.Format( AV8GoToLogin_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+"e114f1_client"+"'", "", "", "", "", edtavGotologin_action_Jsonclick, 7, "K2BT_TextAction", "", "", "", "", 1, edtavGotologin_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_K2BFSG\\EmailSent.htm");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4F2( )
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
         Form.Meta.addItem("description", "Email sent", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4F0( ) ;
      }

      protected void WS4F2( )
      {
         START4F2( ) ;
         EVT4F2( ) ;
      }

      protected void EVT4F2( )
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
                           E124F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E134F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E144F2 ();
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

      protected void WE4F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4F2( ) ;
            }
         }
      }

      protected void PA4F2( )
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
               GX_FocusControl = edtavGotologin_action_Internalname;
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
         RF4F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavGotologin_action_Enabled = 0;
         AssignProp("", false, edtavGotologin_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGotologin_action_Enabled), 5, 0), true);
      }

      protected void RF4F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E134F2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144F2 ();
            WB4F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4F2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavGotologin_action_Enabled = 0;
         AssignProp("", false, edtavGotologin_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGotologin_action_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Attributes_Title = cgiGet( "ATTRIBUTES_Title");
            Attributes_Collapsible = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Collapsible"));
            Attributes_Open = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Open"));
            Attributes_Showborders = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Showborders"));
            Attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E124F2 ();
         if (returnInSub) return;
      }

      protected void E124F2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV28GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV27GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV27GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV28GXV2 <= AV27GXV1.Count )
         {
            AV26ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV27GXV1.Item(AV28GXV2));
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {AV26ActivityLogProperty.gxTpr_Attributename,AV26ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV28GXV2 = (int)(AV28GXV2+1);
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E134F2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if (returnInSub) return;
         AV8GoToLogin_Action = "Go to login";
         AssignAttri("", false, "AV8GoToLogin_Action", AV8GoToLogin_Action);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadrecoverpasswordemailparameters(context ).execute( out  AV13SendPasswordEmail, out  AV10MailSubject, out  AV5MailMessage, out  AV21SMTPServerName, out  AV22SMTPUserName, out  AV17SMTPPassword, out  AV18SMTPPort, out  AV16SMTPAuthentication, out  AV20SMTPSenderName, out  AV19SMTPSenderAddress, out  AV12MinMinutesBetweenEmails, out  AV14ServerHost, out  AV15ServerPort, out  AV6ServerBaseURL) ;
         if ( AV12MinMinutesBetweenEmails > 0 )
         {
            lblWaittime_Caption = StringUtil.Format( "If you recently received a recovery email and need a new one, please wait %1 minutes before requesting it. Requests done before that time will be ignored.", StringUtil.LTrimStr( (decimal)(AV12MinMinutesBetweenEmails), 4, 0), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblWaittime_Internalname, "Caption", lblWaittime_Caption, true);
         }
         else
         {
            lblWaittime_Visible = 0;
            AssignProp("", false, lblWaittime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblWaittime_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'U_GOTOLOGIN' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.login.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E144F2( )
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
         PA4F2( ) ;
         WS4F2( ) ;
         WE4F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138193824", true, true);
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
         context.AddJavascriptSource("k2bfsg/emailsent.js", "?20243138193825", false, true);
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
         lblMessage_Internalname = "MESSAGE";
         divTextblock_message_cellcontainertable_Internalname = "TEXTBLOCK_MESSAGE_CELLCONTAINERTABLE";
         lblWaittime_Internalname = "WAITTIME";
         divTextblock_waittime_cellcontainertable_Internalname = "TEXTBLOCK_WAITTIME_CELLCONTAINERTABLE";
         edtavGotologin_action_Internalname = "vGOTOLOGIN_ACTION";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divAttributes_content_Internalname = "ATTRIBUTES_CONTENT";
         Attributes_Internalname = "ATTRIBUTES";
         divColumn_Internalname = "COLUMN";
         divColumns_Internalname = "COLUMNS";
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
         edtavGotologin_action_Jsonclick = "";
         edtavGotologin_action_Enabled = 1;
         lblWaittime_Caption = "";
         lblWaittime_Visible = 1;
         Attributes_Containseditableform = Convert.ToBoolean( 0);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = "Email sent";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV8GoToLogin_Action',fld:'vGOTOLOGIN_ACTION',pic:''}]}");
         setEventMetadata("'E_GOTOLOGIN'","{handler:'E114F1',iparms:[]");
         setEventMetadata("'E_GOTOLOGIN'",",oparms:[]}");
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
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucAttributes = new GXUserControl();
         lblMessage_Jsonclick = "";
         lblWaittime_Jsonclick = "";
         TempTags = "";
         AV8GoToLogin_Action = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV26ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         AV10MailSubject = "";
         AV5MailMessage = "";
         AV21SMTPServerName = "";
         AV22SMTPUserName = "";
         AV17SMTPPassword = "";
         AV20SMTPSenderName = "";
         AV19SMTPSenderAddress = "";
         AV14ServerHost = "";
         AV6ServerBaseURL = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavGotologin_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV18SMTPPort ;
      private short AV16SMTPAuthentication ;
      private short AV12MinMinutesBetweenEmails ;
      private short nGXWrapped ;
      private int edtavGotologin_action_Enabled ;
      private int lblWaittime_Visible ;
      private int AV28GXV2 ;
      private int AV15ServerPort ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavGotologin_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Attributes_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divColumns_Internalname ;
      private string divColumn_Internalname ;
      private string Attributes_Internalname ;
      private string divAttributes_content_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTextblock_message_cellcontainertable_Internalname ;
      private string lblMessage_Internalname ;
      private string lblMessage_Jsonclick ;
      private string divTextblock_waittime_cellcontainertable_Internalname ;
      private string lblWaittime_Internalname ;
      private string lblWaittime_Caption ;
      private string lblWaittime_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string TempTags ;
      private string AV8GoToLogin_Action ;
      private string edtavGotologin_action_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV10MailSubject ;
      private string AV5MailMessage ;
      private string AV21SMTPServerName ;
      private string AV22SMTPUserName ;
      private string AV17SMTPPassword ;
      private string AV20SMTPSenderName ;
      private string AV19SMTPSenderAddress ;
      private string AV14ServerHost ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Attributes_Collapsible ;
      private bool Attributes_Open ;
      private bool Attributes_Showborders ;
      private bool Attributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13SendPasswordEmail ;
      private string AV6ServerBaseURL ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV27GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private SdtK2BAttributeValue_Item AV26ActivityLogProperty ;
   }

}
