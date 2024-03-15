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
   public class gamconfiguration : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamconfiguration( IGxContext context )
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
         cmbavDefaultrepository = new GXCombobox();
         cmbavEnabletracing = new GXCombobox();
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
            return "gamexamplegamconfiguration_Execute" ;
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
         PA3I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3I2( ) ;
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
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.gamconfiguration.aspx") +"\">") ;
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3I2( ) ;
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
         return formatLink("k2bfsg.gamconfiguration.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.GAMConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_GAMConfiguration", "") ;
      }

      protected void WB3I0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "K2BT_GAM_GAMConfiguration", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\GAMConfiguration.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_gamdatabaseversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamdatabaseversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamdatabaseversion_Internalname, context.GetMessage( "K2BT_GAM_GAMDatabaseVersion", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamdatabaseversion_Internalname, StringUtil.RTrim( AV12GAMDatabaseVersion), StringUtil.RTrim( context.localUtil.Format( AV12GAMDatabaseVersion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamdatabaseversion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamdatabaseversion_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\GAMConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_gamapiversion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGamapiversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamapiversion_Internalname, context.GetMessage( "K2BT_GAM_GAMAPIVersion", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamapiversion_Internalname, StringUtil.RTrim( AV11GAMAPIVersion), StringUtil.RTrim( context.localUtil.Format( AV11GAMAPIVersion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamapiversion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGamapiversion_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\GAMConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_defaultrepository_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavDefaultrepository.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavDefaultrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultrepository_Internalname, context.GetMessage( "K2BT_GAM_DefaultRepository", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultrepository, cmbavDefaultrepository_Internalname, StringUtil.RTrim( AV5DefaultRepository), 1, cmbavDefaultrepository_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavDefaultrepository.Visible, cmbavDefaultrepository.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_K2BFSG\\GAMConfiguration.htm");
            cmbavDefaultrepository.CurrentValue = StringUtil.RTrim( AV5DefaultRepository);
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Values", (string)(cmbavDefaultrepository.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_emailregularexpression_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavEmailregularexpression_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmailregularexpression_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailregularexpression_Internalname, context.GetMessage( "K2BT_GAM_EmailRegularExpression", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailregularexpression_Internalname, StringUtil.RTrim( AV6EmailRegularExpression), StringUtil.RTrim( context.localUtil.Format( AV6EmailRegularExpression, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailregularexpression_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavEmailregularexpression_Visible, edtavEmailregularexpression_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\GAMConfiguration.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_enabletracing_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavEnabletracing_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEnabletracing_Internalname, context.GetMessage( "K2BT_GAM_EnableTracing", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEnabletracing, cmbavEnabletracing_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0)), 1, cmbavEnabletracing_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEnabletracing.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_K2BFSG\\GAMConfiguration.htm");
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", (string)(cmbavEnabletracing.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\GAMConfiguration.htm");
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

      protected void START3I2( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_GAMConfiguration", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3I0( ) ;
      }

      protected void WS3I2( )
      {
         START3I2( ) ;
         EVT3I2( ) ;
      }

      protected void EVT3I2( )
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
                              E113I2 ();
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
                                    E123I2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E133I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Confirm' */
                              E143I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E153I2 ();
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

      protected void WE3I2( )
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

      protected void PA3I2( )
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
               GX_FocusControl = edtavGamdatabaseversion_Internalname;
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
         if ( cmbavDefaultrepository.ItemCount > 0 )
         {
            AV5DefaultRepository = cmbavDefaultrepository.getValidValue(AV5DefaultRepository);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultrepository.CurrentValue = StringUtil.RTrim( AV5DefaultRepository);
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Values", cmbavDefaultrepository.ToJavascriptSource(), true);
         }
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E133I2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E153I2 ();
            WB3I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3I2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113I2 ();
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
            AV12GAMDatabaseVersion = cgiGet( edtavGamdatabaseversion_Internalname);
            AssignAttri("", false, "AV12GAMDatabaseVersion", AV12GAMDatabaseVersion);
            AV11GAMAPIVersion = cgiGet( edtavGamapiversion_Internalname);
            AssignAttri("", false, "AV11GAMAPIVersion", AV11GAMAPIVersion);
            cmbavDefaultrepository.CurrentValue = cgiGet( cmbavDefaultrepository_Internalname);
            AV5DefaultRepository = cgiGet( cmbavDefaultrepository_Internalname);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
            AV6EmailRegularExpression = cgiGet( edtavEmailregularexpression_Internalname);
            AssignAttri("", false, "AV6EmailRegularExpression", AV6EmailRegularExpression);
            cmbavEnabletracing.CurrentValue = cgiGet( cmbavEnabletracing_Internalname);
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavEnabletracing_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
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
         E113I2 ();
         if (returnInSub) return;
      }

      protected void E113I2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E123I2 ();
         if (returnInSub) return;
      }

      protected void E123I2( )
      {
         /* Enter Routine */
         returnInSub = false;
      }

      protected void E133I2( )
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
         Attributes_Containseditableform = true;
         ucAttributes.SendProperty(context, "", false, Attributes_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( Attributes_Containseditableform));
         AV27GXV2 = 1;
         AV26GXV1 = (GxSimpleCollection<string>)(GeneXus.Programs.genexussecuritycommon.gxdomaingamversion.getValues());
         while ( AV27GXV2 <= AV26GXV1.Count )
         {
            AV11GAMAPIVersion = AV26GXV1.GetString(AV27GXV2);
            AssignAttri("", false, "AV11GAMAPIVersion", AV11GAMAPIVersion);
            if (true) break;
            AV27GXV2 = (int)(AV27GXV2+1);
         }
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getdatabaseversion(out  AV12GAMDatabaseVersion);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getenabletracing(out  AV7EnableTracing);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV5DefaultRepository);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getregularexpressiontovalidateemail(out  AV6EmailRegularExpression);
         edtavEmailregularexpression_Visible = 0;
         AssignProp("", false, edtavEmailregularexpression_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmailregularexpression_Visible), 5, 0), true);
         cmbavDefaultrepository.Visible = 0;
         AssignProp("", false, cmbavDefaultrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultrepository.Visible), 5, 0), true);
         AV17isAdminGAM = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV9Errors);
         cmbavDefaultrepository.removeAllItems();
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5DefaultRepository)) || new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            cmbavDefaultrepository.Visible = 1;
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultrepository.Visible), 5, 0), true);
            if ( AV17isAdminGAM )
            {
               cmbavDefaultrepository.addItem("", "(none)", 0);
            }
            AV18LoadDefaultOK = false;
            AV14GAMRepositoryCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getallrepositories(AV10Filter, out  AV9Errors);
            if ( AV14GAMRepositoryCollection.Count > 0 )
            {
               AV28GXV3 = 1;
               while ( AV28GXV3 <= AV14GAMRepositoryCollection.Count )
               {
                  AV15GAMRepositoryItem = ((GeneXus.Programs.genexussecurity.SdtGAMRepository)AV14GAMRepositoryCollection.Item(AV28GXV3));
                  if ( (0==AV15GAMRepositoryItem.gxTpr_Authenticationmasterrepositoryid) )
                  {
                     if ( StringUtil.StrCmp(AV15GAMRepositoryItem.gxTpr_Guid, AV5DefaultRepository) == 0 )
                     {
                        AV18LoadDefaultOK = true;
                     }
                     cmbavDefaultrepository.addItem(AV15GAMRepositoryItem.gxTpr_Guid, AV15GAMRepositoryItem.gxTpr_Name, 0);
                  }
                  AV28GXV3 = (int)(AV28GXV3+1);
               }
            }
            if ( ! AV18LoadDefaultOK && ! String.IsNullOrEmpty(StringUtil.RTrim( AV5DefaultRepository)) )
            {
               cmbavDefaultrepository.removeAllItems();
               cmbavDefaultrepository.addItem(AV5DefaultRepository, AV5DefaultRepository, 0);
            }
         }
         if ( AV17isAdminGAM )
         {
            edtavEmailregularexpression_Visible = 1;
            AssignProp("", false, edtavEmailregularexpression_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmailregularexpression_Visible), 5, 0), true);
         }
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

      protected void E143I2( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setenabletracing(AV7EnableTracing);
         if ( AV16isOk )
         {
            AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV9Errors) )
            {
               AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setregularexpressiontovalidateemail(AV6EmailRegularExpression);
               AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setdefaultrepository(AV5DefaultRepository);
               if ( AV16isOk )
               {
                  GX_msglist.addItem(context.GetMessage( context.GetMessage( "GXM_sucupdated", ""), ""));
               }
               else
               {
                  GX_msglist.addItem("K2BT_GAM_DefaultRepositoryCouldNotBeSaved");
               }
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( context.GetMessage( "GXM_sucupdated", ""), ""));
            }
         }
         else
         {
            GX_msglist.addItem("K2BT_GAM_TracingStatusCouldNotBeSaved");
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E153I2( )
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
         PA3I2( ) ;
         WS3I2( ) ;
         WE3I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243122137118", true, true);
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
         context.AddJavascriptSource("k2bfsg/gamconfiguration.js", "?20243122137123", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDefaultrepository.Name = "vDEFAULTREPOSITORY";
         cmbavDefaultrepository.WebTags = "";
         if ( cmbavDefaultrepository.ItemCount > 0 )
         {
            AV5DefaultRepository = cmbavDefaultrepository.getValidValue(AV5DefaultRepository);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
         }
         cmbavEnabletracing.Name = "vENABLETRACING";
         cmbavEnabletracing.WebTags = "";
         cmbavEnabletracing.addItem("0", context.GetMessage( "0 - Off", ""), 0);
         cmbavEnabletracing.addItem("1", context.GetMessage( "1 - Debug", ""), 0);
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavGamdatabaseversion_Internalname = "vGAMDATABASEVERSION";
         divTable_container_gamdatabaseversion_Internalname = "TABLE_CONTAINER_GAMDATABASEVERSION";
         edtavGamapiversion_Internalname = "vGAMAPIVERSION";
         divTable_container_gamapiversion_Internalname = "TABLE_CONTAINER_GAMAPIVERSION";
         cmbavDefaultrepository_Internalname = "vDEFAULTREPOSITORY";
         divTable_container_defaultrepository_Internalname = "TABLE_CONTAINER_DEFAULTREPOSITORY";
         edtavEmailregularexpression_Internalname = "vEMAILREGULAREXPRESSION";
         divTable_container_emailregularexpression_Internalname = "TABLE_CONTAINER_EMAILREGULAREXPRESSION";
         cmbavEnabletracing_Internalname = "vENABLETRACING";
         divTable_container_enabletracing_Internalname = "TABLE_CONTAINER_ENABLETRACING";
         bttConfirm_Internalname = "CONFIRM";
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
         cmbavEnabletracing_Jsonclick = "";
         cmbavEnabletracing.Enabled = 1;
         edtavEmailregularexpression_Jsonclick = "";
         edtavEmailregularexpression_Enabled = 1;
         edtavEmailregularexpression_Visible = 1;
         cmbavDefaultrepository_Jsonclick = "";
         cmbavDefaultrepository.Enabled = 1;
         cmbavDefaultrepository.Visible = 1;
         edtavGamapiversion_Jsonclick = "";
         edtavGamapiversion_Enabled = 1;
         edtavGamdatabaseversion_Jsonclick = "";
         edtavGamdatabaseversion_Enabled = 1;
         Attributes_Containseditableform = Convert.ToBoolean( -1);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = context.GetMessage( "K2BT_General", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_GAMConfiguration", "");
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
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E123I2',iparms:[]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E143I2',iparms:[{av:'cmbavEnabletracing'},{av:'AV7EnableTracing',fld:'vENABLETRACING',pic:'ZZZ9'},{av:'AV6EmailRegularExpression',fld:'vEMAILREGULAREXPRESSION',pic:''},{av:'cmbavDefaultrepository'},{av:'AV5DefaultRepository',fld:'vDEFAULTREPOSITORY',pic:''}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[]}");
         setEventMetadata("VALIDV_ENABLETRACING","{handler:'Validv_Enabletracing',iparms:[]");
         setEventMetadata("VALIDV_ENABLETRACING",",oparms:[]}");
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
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         ucAttributes = new GXUserControl();
         TempTags = "";
         AV12GAMDatabaseVersion = "";
         AV11GAMAPIVersion = "";
         AV5DefaultRepository = "";
         AV6EmailRegularExpression = "";
         bttConfirm_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26GXV1 = new GxSimpleCollection<string>();
         AV9Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMRepositoryCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepository", "GeneXus.Programs");
         AV10Filter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter(context);
         AV15GAMRepositoryItem = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV7EnableTracing ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavGamdatabaseversion_Enabled ;
      private int edtavGamapiversion_Enabled ;
      private int edtavEmailregularexpression_Visible ;
      private int edtavEmailregularexpression_Enabled ;
      private int AV27GXV2 ;
      private int AV28GXV3 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string divTable_container_gamdatabaseversion_Internalname ;
      private string edtavGamdatabaseversion_Internalname ;
      private string TempTags ;
      private string AV12GAMDatabaseVersion ;
      private string edtavGamdatabaseversion_Jsonclick ;
      private string divTable_container_gamapiversion_Internalname ;
      private string edtavGamapiversion_Internalname ;
      private string AV11GAMAPIVersion ;
      private string edtavGamapiversion_Jsonclick ;
      private string divTable_container_defaultrepository_Internalname ;
      private string cmbavDefaultrepository_Internalname ;
      private string AV5DefaultRepository ;
      private string cmbavDefaultrepository_Jsonclick ;
      private string divTable_container_emailregularexpression_Internalname ;
      private string edtavEmailregularexpression_Internalname ;
      private string AV6EmailRegularExpression ;
      private string edtavEmailregularexpression_Jsonclick ;
      private string divTable_container_enabletracing_Internalname ;
      private string cmbavEnabletracing_Internalname ;
      private string cmbavEnabletracing_Jsonclick ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
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
      private bool AV16isOk ;
      private bool AV17isAdminGAM ;
      private bool AV18LoadDefaultOK ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDefaultrepository ;
      private GXCombobox cmbavEnabletracing ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV26GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository> AV14GAMRepositoryCollection ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter AV10Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15GAMRepositoryItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13GAMRepository ;
   }

}
