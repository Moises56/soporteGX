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
namespace GeneXus.Programs.k2btools.designsystems.aries {
   public class uiconfiguration : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public uiconfiguration( )
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

      public uiconfiguration( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
            PA0R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0R2( ) ;
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
            context.SendWebValue( "K2 BT_UIConfiguration Aries") ;
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
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BColorOptionPicker/K2BColorOptionPickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
         context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2btools.designsystems.aries.uiconfiguration.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vBASECOLOR", StringUtil.RTrim( AV5BaseColor));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOLORVARIANT", StringUtil.RTrim( AV6ColorVariant));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLANGUAGE", StringUtil.RTrim( AV11Language));
         GxWebStd.gx_hidden_field( context, sPrefix+"BASECOLOR_Enabled", StringUtil.BoolToStr( Basecolor_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"BASECOLOR_Captionclass", StringUtil.RTrim( Basecolor_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"BASECOLOR_Captionstyle", StringUtil.RTrim( Basecolor_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"BASECOLOR_Captionposition", StringUtil.RTrim( Basecolor_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Class", StringUtil.RTrim( Colorvariant_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Includeemptyitem", StringUtil.BoolToStr( Colorvariant_Includeemptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Enabled", StringUtil.BoolToStr( Colorvariant_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Captionclass", StringUtil.RTrim( Colorvariant_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Captionstyle", StringUtil.RTrim( Colorvariant_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"COLORVARIANT_Captionposition", StringUtil.RTrim( Colorvariant_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Class", StringUtil.RTrim( Language_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Includeemptyitem", StringUtil.BoolToStr( Language_Includeemptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Enabled", StringUtil.BoolToStr( Language_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Captionclass", StringUtil.RTrim( Language_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Captionstyle", StringUtil.RTrim( Language_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"LANGUAGE_Captionposition", StringUtil.RTrim( Language_Captionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONFIGURATIONCONTENTS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divConfigurationcontents_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0R2( )
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
         return "K2BTools.DesignSystems.Aries.UIConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2 BT_UIConfiguration Aries" ;
      }

      protected void WB0R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btools.designsystems.aries.uiconfiguration.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("K2BColorOptionPicker/K2BColorOptionPickerRender.js", "", false, true);
               context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
               context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divToggleconfigurationmenu_Internalname, 1, 0, "px", 0, "px", "K2BT_UIConfigurationButton", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divConfigurationcontents_Internalname, divConfigurationcontents_Visible, 0, "px", 0, "px", "ControlBeautify_CollapsableTable K2BT_UIConfigurationSection K2BT_EditableForm", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPalettecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_palette_Internalname, "Palette", "", "", lblTextblock_palette_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop Label", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\UIConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+Basecolor_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBasecolor.SetProperty("Attribute", AV5BaseColor);
            ucBasecolor.SetProperty("CaptionClass", Basecolor_Captionclass);
            ucBasecolor.SetProperty("CaptionStyle", Basecolor_Captionstyle);
            ucBasecolor.SetProperty("CaptionPosition", Basecolor_Captionposition);
            ucBasecolor.Render(context, "k2bcoloroptionpicker", Basecolor_Internalname, sPrefix+"BASECOLORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+Colorvariant_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucColorvariant.SetProperty("Attribute", AV6ColorVariant);
            ucColorvariant.SetProperty("Class", Colorvariant_Class);
            ucColorvariant.SetProperty("IncludeEmptyItem", Colorvariant_Includeemptyitem);
            ucColorvariant.SetProperty("CaptionClass", Colorvariant_Captionclass);
            ucColorvariant.SetProperty("CaptionStyle", Colorvariant_Captionstyle);
            ucColorvariant.SetProperty("CaptionPosition", Colorvariant_Captionposition);
            ucColorvariant.Render(context, "k2btogglebar", Colorvariant_Internalname, sPrefix+"COLORVARIANTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLanguagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+Language_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Language_Internalname, "Language", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLanguage.SetProperty("Attribute", AV11Language);
            ucLanguage.SetProperty("Class", Language_Class);
            ucLanguage.SetProperty("IncludeEmptyItem", Language_Includeemptyitem);
            ucLanguage.SetProperty("CaptionClass", Language_Captionclass);
            ucLanguage.SetProperty("CaptionStyle", Language_Captionstyle);
            ucLanguage.SetProperty("CaptionPosition", Language_Captionposition);
            ucLanguage.Render(context, "k2btogglebar", Language_Internalname, sPrefix+"LANGUAGEContainer");
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
         }
         wbLoad = true;
      }

      protected void START0R2( )
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
            Form.Meta.addItem("description", "K2 BT_UIConfiguration Aries", 0) ;
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
               STRUP0R0( ) ;
            }
         }
      }

      protected void WS0R2( )
      {
         START0R2( ) ;
         EVT0R2( ) ;
      }

      protected void EVT0R2( )
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
                                 STRUP0R0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "VBASECOLOR.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E110R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCOLORVARIANT.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E120R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLANGUAGE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E130R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E140R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E150R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0R0( ) ;
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
                                 STRUP0R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE0R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0R2( ) ;
            }
         }
      }

      protected void PA0R2( )
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
         RF0R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E150R2 ();
            WB0R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0R2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E140R2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV5BaseColor = cgiGet( sPrefix+"vBASECOLOR");
            AV6ColorVariant = cgiGet( sPrefix+"vCOLORVARIANT");
            AV11Language = cgiGet( sPrefix+"vLANGUAGE");
            Basecolor_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"BASECOLOR_Enabled"));
            Basecolor_Captionclass = cgiGet( sPrefix+"BASECOLOR_Captionclass");
            Basecolor_Captionstyle = cgiGet( sPrefix+"BASECOLOR_Captionstyle");
            Basecolor_Captionposition = cgiGet( sPrefix+"BASECOLOR_Captionposition");
            Colorvariant_Class = cgiGet( sPrefix+"COLORVARIANT_Class");
            Colorvariant_Includeemptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COLORVARIANT_Includeemptyitem"));
            Colorvariant_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COLORVARIANT_Enabled"));
            Colorvariant_Captionclass = cgiGet( sPrefix+"COLORVARIANT_Captionclass");
            Colorvariant_Captionstyle = cgiGet( sPrefix+"COLORVARIANT_Captionstyle");
            Colorvariant_Captionposition = cgiGet( sPrefix+"COLORVARIANT_Captionposition");
            Language_Class = cgiGet( sPrefix+"LANGUAGE_Class");
            Language_Includeemptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"LANGUAGE_Includeemptyitem"));
            Language_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"LANGUAGE_Enabled"));
            Language_Captionclass = cgiGet( sPrefix+"LANGUAGE_Captionclass");
            Language_Captionstyle = cgiGet( sPrefix+"LANGUAGE_Captionstyle");
            Language_Captionposition = cgiGet( sPrefix+"LANGUAGE_Captionposition");
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

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E140R2 ();
         if (returnInSub) return;
      }

      protected void E140R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divConfigurationcontents_Visible = 0;
         AssignProp(sPrefix, false, divConfigurationcontents_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divConfigurationcontents_Visible), 5, 0), true);
         AV9K2BT_ExtendedControlValues = new GXBaseCollection<SdtK2BT_ExtendedControlValues_Item>( context, "Item", "test");
         AV10K2BT_ExtendedControlValuesItem = new SdtK2BT_ExtendedControlValues_Item(context);
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Value = "light";
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Description = "Light";
         AV9K2BT_ExtendedControlValues.Add(AV10K2BT_ExtendedControlValuesItem, 0);
         AV10K2BT_ExtendedControlValuesItem = new SdtK2BT_ExtendedControlValues_Item(context);
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Value = "dark";
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Description = "Dark";
         AV9K2BT_ExtendedControlValues.Add(AV10K2BT_ExtendedControlValuesItem, 0);
         this.executeUsercontrolMethod(sPrefix, false, "COLORVARIANTContainer", "SetValues", "", new Object[] {(GXBaseCollection<SdtK2BT_ExtendedControlValues_Item>)AV9K2BT_ExtendedControlValues});
         GXt_char1 = AV6ColorVariant;
         new GeneXus.Programs.k2btools.getdesignsystemoptionvalue(context ).execute(  "color-variant", out  GXt_char1) ;
         AV6ColorVariant = GXt_char1;
         AssignAttri(sPrefix, false, "AV6ColorVariant", AV6ColorVariant);
         AV8K2BT_BaseColorOptions = new GXBaseCollection<GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color>( context, "Color", "test");
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         AV7K2BT_BaseColorOption.gxTpr_Id = "violet";
         AV7K2BT_BaseColorOption.gxTpr_Colorcode = "#6015af";
         AV7K2BT_BaseColorOption.gxTpr_Description = "Violet";
         AV8K2BT_BaseColorOptions.Add(AV7K2BT_BaseColorOption, 0);
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         AV7K2BT_BaseColorOption.gxTpr_Id = "violetflat";
         AV7K2BT_BaseColorOption.gxTpr_Colorcode = "#5a6ee0";
         AV7K2BT_BaseColorOption.gxTpr_Description = "Violet Flat";
         AV8K2BT_BaseColorOptions.Add(AV7K2BT_BaseColorOption, 0);
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         AV7K2BT_BaseColorOption.gxTpr_Id = "green";
         AV7K2BT_BaseColorOption.gxTpr_Colorcode = "#2A898E";
         AV7K2BT_BaseColorOption.gxTpr_Description = "Green";
         AV8K2BT_BaseColorOptions.Add(AV7K2BT_BaseColorOption, 0);
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         AV7K2BT_BaseColorOption.gxTpr_Id = "skyblue";
         AV7K2BT_BaseColorOption.gxTpr_Colorcode = "#5CCEDF";
         AV7K2BT_BaseColorOption.gxTpr_Description = "Sky Blue";
         AV8K2BT_BaseColorOptions.Add(AV7K2BT_BaseColorOption, 0);
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         AV7K2BT_BaseColorOption.gxTpr_Id = "red";
         AV7K2BT_BaseColorOption.gxTpr_Colorcode = "#A83453";
         AV7K2BT_BaseColorOption.gxTpr_Description = "Red";
         AV8K2BT_BaseColorOptions.Add(AV7K2BT_BaseColorOption, 0);
         this.executeUsercontrolMethod(sPrefix, false, "BASECOLORContainer", "SetOptions", "", new Object[] {(GXBaseCollection<GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color>)AV8K2BT_BaseColorOptions});
         GXt_char1 = AV5BaseColor;
         new GeneXus.Programs.k2btools.getdesignsystemoptionvalue(context ).execute(  "base-color", out  GXt_char1) ;
         AV5BaseColor = GXt_char1;
         AssignAttri(sPrefix, false, "AV5BaseColor", AV5BaseColor);
         AV9K2BT_ExtendedControlValues = new GXBaseCollection<SdtK2BT_ExtendedControlValues_Item>( context, "Item", "test");
         AV10K2BT_ExtendedControlValuesItem = new SdtK2BT_ExtendedControlValues_Item(context);
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Value = "English";
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Description = "English";
         AV10K2BT_ExtendedControlValuesItem.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "cd19377b-aadb-4458-91ca-fe8f890d88cb", "", context.GetTheme( ))));
         AV9K2BT_ExtendedControlValues.Add(AV10K2BT_ExtendedControlValuesItem, 0);
         this.executeUsercontrolMethod(sPrefix, false, "LANGUAGEContainer", "SetValues", "", new Object[] {(GXBaseCollection<SdtK2BT_ExtendedControlValues_Item>)AV9K2BT_ExtendedControlValues});
         AV11Language = context.GetLanguage( );
         AssignAttri(sPrefix, false, "AV11Language", AV11Language);
      }

      protected void E120R2( )
      {
         /* Colorvariant_Controlvaluechanged Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"color-variant",(string)AV6ColorVariant}, false);
         new GeneXus.Programs.k2btools.setdesignsystemoptionvalue(context ).execute(  "color-variant",  AV6ColorVariant) ;
      }

      protected void E110R2( )
      {
         /* Basecolor_Controlvaluechanged Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {(string)"base-color",(string)AV5BaseColor}, false);
         new GeneXus.Programs.k2btools.setdesignsystemoptionvalue(context ).execute(  "base-color",  AV5BaseColor) ;
      }

      protected void E130R2( )
      {
         /* Language_Controlvaluechanged Routine */
         returnInSub = false;
         AV12x = (short)(context.SetLanguage( AV11Language));
         context.DoAjaxRefreshForm();
      }

      protected void nextLoad( )
      {
      }

      protected void E150R2( )
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
         PA0R2( ) ;
         WS0R2( ) ;
         WE0R2( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btools\\designsystems\\aries\\uiconfiguration", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0R2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA0R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0R2( ) ;
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
         WS0R2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE0R2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138143159", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/uiconfiguration.js", "?20243138143159", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BColorOptionPicker/K2BColorOptionPickerRender.js", "", false, true);
         context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
         context.AddJavascriptSource("K2BToggleBar/K2BToggleBarRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divToggleconfigurationmenu_Internalname = sPrefix+"TOGGLECONFIGURATIONMENU";
         lblTextblock_palette_Internalname = sPrefix+"TEXTBLOCK_PALETTE";
         Basecolor_Internalname = sPrefix+"BASECOLOR";
         Colorvariant_Internalname = sPrefix+"COLORVARIANT";
         divPalettecontainer_Internalname = sPrefix+"PALETTECONTAINER";
         Language_Internalname = sPrefix+"LANGUAGE";
         divLanguagecontainer_Internalname = sPrefix+"LANGUAGECONTAINER";
         divConfigurationcontents_Internalname = sPrefix+"CONFIGURATIONCONTENTS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
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
         divConfigurationcontents_Visible = 1;
         Language_Captionposition = "Top";
         Language_Captionstyle = "width: 100%;";
         Language_Captionclass = "gx-form-item Attribute_TrnLabel";
         Language_Enabled = Convert.ToBoolean( -1);
         Language_Includeemptyitem = Convert.ToBoolean( 0);
         Language_Class = "Attribute_Trn";
         Colorvariant_Captionposition = "Top";
         Colorvariant_Captionstyle = "width: 100%;";
         Colorvariant_Captionclass = "gx-form-item Attribute_TrnLabel";
         Colorvariant_Enabled = Convert.ToBoolean( -1);
         Colorvariant_Includeemptyitem = Convert.ToBoolean( 0);
         Colorvariant_Class = "Attribute_Trn";
         Basecolor_Captionposition = "Top";
         Basecolor_Captionstyle = "width: 100%;";
         Basecolor_Captionclass = "gx-form-item AttributeLabel";
         Basecolor_Enabled = Convert.ToBoolean( -1);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VCOLORVARIANT.CONTROLVALUECHANGED","{handler:'E120R2',iparms:[{av:'AV6ColorVariant',fld:'vCOLORVARIANT',pic:''}]");
         setEventMetadata("VCOLORVARIANT.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VBASECOLOR.CONTROLVALUECHANGED","{handler:'E110R2',iparms:[{av:'AV5BaseColor',fld:'vBASECOLOR',pic:''}]");
         setEventMetadata("VBASECOLOR.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VLANGUAGE.CONTROLVALUECHANGED","{handler:'E130R2',iparms:[{av:'AV11Language',fld:'vLANGUAGE',pic:''}]");
         setEventMetadata("VLANGUAGE.CONTROLVALUECHANGED",",oparms:[]}");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5BaseColor = "";
         AV6ColorVariant = "";
         AV11Language = "";
         GX_FocusControl = "";
         lblTextblock_palette_Jsonclick = "";
         ucBasecolor = new GXUserControl();
         ucColorvariant = new GXUserControl();
         ucLanguage = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9K2BT_ExtendedControlValues = new GXBaseCollection<SdtK2BT_ExtendedControlValues_Item>( context, "Item", "test");
         AV10K2BT_ExtendedControlValuesItem = new SdtK2BT_ExtendedControlValues_Item(context);
         AV8K2BT_BaseColorOptions = new GXBaseCollection<GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color>( context, "Color", "test");
         AV7K2BT_BaseColorOption = new GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color(context);
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV12x ;
      private short nGXWrapped ;
      private int divConfigurationcontents_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV5BaseColor ;
      private string AV6ColorVariant ;
      private string AV11Language ;
      private string Basecolor_Captionclass ;
      private string Basecolor_Captionstyle ;
      private string Basecolor_Captionposition ;
      private string Colorvariant_Class ;
      private string Colorvariant_Captionclass ;
      private string Colorvariant_Captionstyle ;
      private string Colorvariant_Captionposition ;
      private string Language_Class ;
      private string Language_Captionclass ;
      private string Language_Captionstyle ;
      private string Language_Captionposition ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divContenttable_Internalname ;
      private string divToggleconfigurationmenu_Internalname ;
      private string divConfigurationcontents_Internalname ;
      private string divPalettecontainer_Internalname ;
      private string lblTextblock_palette_Internalname ;
      private string lblTextblock_palette_Jsonclick ;
      private string Basecolor_Internalname ;
      private string Colorvariant_Internalname ;
      private string divLanguagecontainer_Internalname ;
      private string Language_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Basecolor_Enabled ;
      private bool Colorvariant_Includeemptyitem ;
      private bool Colorvariant_Enabled ;
      private bool Language_Includeemptyitem ;
      private bool Language_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucBasecolor ;
      private GXUserControl ucColorvariant ;
      private GXUserControl ucLanguage ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color> AV8K2BT_BaseColorOptions ;
      private GXBaseCollection<SdtK2BT_ExtendedControlValues_Item> AV9K2BT_ExtendedControlValues ;
      private GeneXus.Programs.k2btools.controltypes.coloroptionpicker.SdtColorOptions_Color AV7K2BT_BaseColorOption ;
      private SdtK2BT_ExtendedControlValues_Item AV10K2BT_ExtendedControlValuesItem ;
   }

}
