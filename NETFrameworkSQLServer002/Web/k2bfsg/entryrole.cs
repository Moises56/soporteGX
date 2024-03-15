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
   public class entryrole : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entryrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV18Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavSecpolid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV18Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18Id", StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
               }
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
         PA3W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3W2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"EntryRole");
         forbiddenHiddens.Add("GUID", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("k2bfsg\\entryrole:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "GENERAL_Title", StringUtil.RTrim( General_Title));
         GxWebStd.gx_hidden_field( context, "GENERAL_Collapsible", StringUtil.BoolToStr( General_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERAL_Open", StringUtil.BoolToStr( General_Open));
         GxWebStd.gx_hidden_field( context, "GENERAL_Showborders", StringUtil.BoolToStr( General_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERAL_Containseditableform", StringUtil.BoolToStr( General_Containseditableform));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Title", StringUtil.RTrim( Responsivetable_mainattributes_attributes1_Title));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Collapsible));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Open));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Showborders));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Containseditableform));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Visible));
         GxWebStd.gx_hidden_field( context, "LINESEPARATORCONTENT_LINESEPARATOR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Permissionswc == null ) )
         {
            WebComp_Permissionswc.componentjscripts();
         }
         if ( ! ( WebComp_Childrenwc == null ) )
         {
            WebComp_Childrenwc.componentjscripts();
         }
         if ( ! ( WebComp_Userswc == null ) )
         {
            WebComp_Userswc.componentjscripts();
         }
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
            WE3W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3W2( ) ;
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
         return formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryRole" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_Role", "") ;
      }

      protected void WB3W0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Role ", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryRole.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGeneral.SetProperty("Title", General_Title);
            ucGeneral.SetProperty("Collapsible", General_Collapsible);
            ucGeneral.SetProperty("Open", General_Open);
            ucGeneral.SetProperty("ShowBorders", General_Showborders);
            ucGeneral.SetProperty("ContainsEditableForm", General_Containseditableform);
            ucGeneral.Render(context, "k2bt_component", General_Internalname, "GENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GENERALContainer"+"General_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGeneral_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_general_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableright_actions2_Internalname, 1, 0, "px", 0, "px", "K2BTableActionsRightContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgUpdate_gximage, "")==0) ? "GX_Image_K2BActionUpdate_Class" : "GX_Image_"+imgUpdate_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113w1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123w1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryRole.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_id_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, context.GetMessage( "K2BT_GAM_Id", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Id), 12, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18Id), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_K2BFSG\\EntryRole.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGuid_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, context.GetMessage( "K2BT_GUID", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV19GUID), StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavGuid_Visible, edtavGuid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntryRole.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "K2BT_GAM_Name", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV20Name), StringUtil.RTrim( context.localUtil.Format( AV20Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\EntryRole.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_dsc_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, context.GetMessage( "K2BT_GAM_Description", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV21Dsc), StringUtil.RTrim( context.localUtil.Format( AV21Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\EntryRole.htm");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_lineseparator_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_lineseparator_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lineseparator_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lineseparator_Internalname, context.GetMessage( "K2BT_GAM_Advanced", ""), "", "", lblLineseparatortitle_lineseparator_Jsonclick, "'"+""+"'"+",false,"+"'"+"e133w1_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_lineseparator_Internalname, divLineseparatorcontent_lineseparator_Visible, 0, "px", 0, "px", divLineseparatorcontent_lineseparator_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_secpolid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavSecpolid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecpolid_Internalname, context.GetMessage( "K2BT_GAM_SecurityPolicy", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecpolid, cmbavSecpolid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0)), 1, cmbavSecpolid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecpolid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_K2BFSG\\EntryRole.htm");
            cmbavSecpolid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0));
            AssignProp("", false, cmbavSecpolid_Internalname, "Values", (string)(cmbavSecpolid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_extid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavExtid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExtid_Internalname, context.GetMessage( "K2BT_GAM_ExternalId", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavExtid_Internalname, StringUtil.RTrim( AV23ExtId), StringUtil.RTrim( context.localUtil.Format( AV23ExtId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavExtid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavExtid_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\EntryRole.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e143w1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryRole.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0094"+"", StringUtil.RTrim( WebComp_Permissionswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0094"+""+"\""+((WebComp_Permissionswc_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPermissionswc), StringUtil.Lower( WebComp_Permissionswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0094"+"");
                  }
                  WebComp_Permissionswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPermissionswc), StringUtil.Lower( WebComp_Permissionswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucResponsivetable_mainattributes_attributes1.SetProperty("Title", Responsivetable_mainattributes_attributes1_Title);
            ucResponsivetable_mainattributes_attributes1.SetProperty("Collapsible", Responsivetable_mainattributes_attributes1_Collapsible);
            ucResponsivetable_mainattributes_attributes1.SetProperty("Open", Responsivetable_mainattributes_attributes1_Open);
            ucResponsivetable_mainattributes_attributes1.SetProperty("ShowBorders", Responsivetable_mainattributes_attributes1_Showborders);
            ucResponsivetable_mainattributes_attributes1.SetProperty("ContainsEditableForm", Responsivetable_mainattributes_attributes1_Containseditableform);
            ucResponsivetable_mainattributes_attributes1.Render(context, "k2bt_component", Responsivetable_mainattributes_attributes1_Internalname, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1Container"+"Responsivetable_mainattributes_attributes1_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes1_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_responsivetable_mainattributes_attributes1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0105"+"", StringUtil.RTrim( WebComp_Childrenwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0105"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Childrenwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldChildrenwc), StringUtil.Lower( WebComp_Childrenwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0105"+"");
                  }
                  WebComp_Childrenwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldChildrenwc), StringUtil.Lower( WebComp_Childrenwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0108"+"", StringUtil.RTrim( WebComp_Userswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0108"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Userswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUserswc), StringUtil.Lower( WebComp_Userswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0108"+"");
                  }
                  WebComp_Userswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldUserswc), StringUtil.Lower( WebComp_Userswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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

      protected void START3W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_Role", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3W0( ) ;
      }

      protected void WS3W2( )
      {
         START3W2( ) ;
         EVT3W2( ) ;
      }

      protected void EVT3W2( )
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
                              E153W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E163W2 ();
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
                                    E173W2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E183W2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 94 )
                        {
                           OldPermissionswc = cgiGet( "W0094");
                           if ( ( StringUtil.Len( OldPermissionswc) == 0 ) || ( StringUtil.StrCmp(OldPermissionswc, WebComp_Permissionswc_Component) != 0 ) )
                           {
                              WebComp_Permissionswc = getWebComponent(GetType(), "GeneXus.Programs", OldPermissionswc, new Object[] {context} );
                              WebComp_Permissionswc.ComponentInit();
                              WebComp_Permissionswc.Name = "OldPermissionswc";
                              WebComp_Permissionswc_Component = OldPermissionswc;
                           }
                           if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
                           {
                              WebComp_Permissionswc.componentprocess("W0094", "", sEvt);
                           }
                           WebComp_Permissionswc_Component = OldPermissionswc;
                        }
                        else if ( nCmpId == 105 )
                        {
                           OldChildrenwc = cgiGet( "W0105");
                           if ( ( StringUtil.Len( OldChildrenwc) == 0 ) || ( StringUtil.StrCmp(OldChildrenwc, WebComp_Childrenwc_Component) != 0 ) )
                           {
                              WebComp_Childrenwc = getWebComponent(GetType(), "GeneXus.Programs", OldChildrenwc, new Object[] {context} );
                              WebComp_Childrenwc.ComponentInit();
                              WebComp_Childrenwc.Name = "OldChildrenwc";
                              WebComp_Childrenwc_Component = OldChildrenwc;
                           }
                           if ( StringUtil.Len( WebComp_Childrenwc_Component) != 0 )
                           {
                              WebComp_Childrenwc.componentprocess("W0105", "", sEvt);
                           }
                           WebComp_Childrenwc_Component = OldChildrenwc;
                        }
                        else if ( nCmpId == 108 )
                        {
                           OldUserswc = cgiGet( "W0108");
                           if ( ( StringUtil.Len( OldUserswc) == 0 ) || ( StringUtil.StrCmp(OldUserswc, WebComp_Userswc_Component) != 0 ) )
                           {
                              WebComp_Userswc = getWebComponent(GetType(), "GeneXus.Programs", OldUserswc, new Object[] {context} );
                              WebComp_Userswc.ComponentInit();
                              WebComp_Userswc.Name = "OldUserswc";
                              WebComp_Userswc_Component = OldUserswc;
                           }
                           if ( StringUtil.Len( WebComp_Userswc_Component) != 0 )
                           {
                              WebComp_Userswc.componentprocess("W0108", "", sEvt);
                           }
                           WebComp_Userswc_Component = OldUserswc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3W2( )
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

      protected void PA3W2( )
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
         if ( cmbavSecpolid.ItemCount > 0 )
         {
            AV22SecPolId = (int)(Math.Round(NumberUtil.Val( cmbavSecpolid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22SecPolId", StringUtil.LTrimStr( (decimal)(AV22SecPolId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecpolid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0));
            AssignProp("", false, cmbavSecpolid_Internalname, "Values", cmbavSecpolid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
      }

      protected void RF3W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E163W2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Permissionswc_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
               {
                  WebComp_Permissionswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Childrenwc_Component) != 0 )
               {
                  WebComp_Childrenwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Userswc_Component) != 0 )
               {
                  WebComp_Userswc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E183W2 ();
            WB3W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3W2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            General_Title = cgiGet( "GENERAL_Title");
            General_Collapsible = StringUtil.StrToBool( cgiGet( "GENERAL_Collapsible"));
            General_Open = StringUtil.StrToBool( cgiGet( "GENERAL_Open"));
            General_Showborders = StringUtil.StrToBool( cgiGet( "GENERAL_Showborders"));
            General_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERAL_Containseditableform"));
            Responsivetable_mainattributes_attributes1_Title = cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Title");
            Responsivetable_mainattributes_attributes1_Collapsible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Collapsible"));
            Responsivetable_mainattributes_attributes1_Open = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Open"));
            Responsivetable_mainattributes_attributes1_Showborders = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Showborders"));
            Responsivetable_mainattributes_attributes1_Containseditableform = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Containseditableform"));
            Responsivetable_mainattributes_attributes1_Visible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_Visible"));
            /* Read variables values. */
            AV18Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18Id", StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
            AV19GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV19GUID", AV19GUID);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), context));
            AV20Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV20Name", AV20Name);
            AV21Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV21Dsc", AV21Dsc);
            cmbavSecpolid.CurrentValue = cgiGet( cmbavSecpolid_Internalname);
            AV22SecPolId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecpolid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22SecPolId", StringUtil.LTrimStr( (decimal)(AV22SecPolId), 9, 0));
            AV23ExtId = cgiGet( edtavExtid_Internalname);
            AssignAttri("", false, "AV23ExtId", AV23ExtId);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"EntryRole");
            AV19GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV19GUID", AV19GUID);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), context));
            forbiddenHiddens.Add("GUID", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("k2bfsg\\entryrole:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         edtavDsc_Enabled = 1;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
         edtavExtid_Enabled = 1;
         AssignProp("", false, edtavExtid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExtid_Enabled), 5, 0), true);
         cmbavSecpolid.Enabled = 1;
         AssignProp("", false, cmbavSecpolid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecpolid.Enabled), 5, 0), true);
         AV20Name = "";
         AssignAttri("", false, "AV20Name", AV20Name);
         AV21Dsc = "";
         AssignAttri("", false, "AV21Dsc", AV21Dsc);
         AV23ExtId = "";
         AssignAttri("", false, "AV23ExtId", AV23ExtId);
         AV22SecPolId = 0;
         AssignAttri("", false, "AV22SecPolId", StringUtil.LTrimStr( (decimal)(AV22SecPolId), 9, 0));
         AV6SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV10Filter, out  AV8Errors);
         cmbavSecpolid.addItem("0", context.GetMessage( "GX_EmptyItemText", ""), 0);
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV6SecurityPolicies.Count )
         {
            AV7SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV6SecurityPolicies.Item(AV27GXV1));
            cmbavSecpolid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV7SecurityPolicy.gxTpr_Id), 9, 0)), AV7SecurityPolicy.gxTpr_Name, 0);
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         edtavDsc_Enabled = 1;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
         edtavExtid_Enabled = 1;
         AssignProp("", false, edtavExtid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExtid_Enabled), 5, 0), true);
         cmbavSecpolid.Enabled = 1;
         AssignProp("", false, cmbavSecpolid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecpolid.Enabled), 5, 0), true);
         bttConfirm_Visible = 1;
         AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
         edtavGuid_Visible = 1;
         AssignProp("", false, edtavGuid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGuid_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV5Role.load( AV18Id);
            AV19GUID = StringUtil.Trim( AV5Role.gxTpr_Guid);
            AssignAttri("", false, "AV19GUID", AV19GUID);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19GUID, "")), context));
            AV20Name = StringUtil.Trim( AV5Role.gxTpr_Name);
            AssignAttri("", false, "AV20Name", AV20Name);
            AV21Dsc = StringUtil.Trim( AV5Role.gxTpr_Description);
            AssignAttri("", false, "AV21Dsc", AV21Dsc);
            AV23ExtId = StringUtil.Trim( AV5Role.gxTpr_Externalid);
            AssignAttri("", false, "AV23ExtId", AV23ExtId);
            AV22SecPolId = AV5Role.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV22SecPolId", StringUtil.LTrimStr( (decimal)(AV22SecPolId), 9, 0));
         }
         else
         {
            WebComp_Permissionswc_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0094"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Permissionswc_Visible), 5, 0), true);
            Responsivetable_mainattributes_attributes1_Visible = false;
            ucResponsivetable_mainattributes_attributes1.SendProperty(context, "", false, Responsivetable_mainattributes_attributes1_Internalname, "Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Visible));
            edtavGuid_Visible = 0;
            AssignProp("", false, edtavGuid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGuid_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
            {
               WebComp_Permissionswc_Visible = 0;
               AssignProp("", false, "gxHTMLWrpW0094"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Permissionswc_Visible), 5, 0), true);
               Responsivetable_mainattributes_attributes1_Visible = false;
               ucResponsivetable_mainattributes_attributes1.SendProperty(context, "", false, Responsivetable_mainattributes_attributes1_Internalname, "Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes1_Visible));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavExtid_Enabled = 0;
            AssignProp("", false, edtavExtid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExtid_Enabled), 5, 0), true);
            cmbavSecpolid.Enabled = 0;
            AssignProp("", false, cmbavSecpolid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecpolid.Enabled), 5, 0), true);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E153W2 ();
         if (returnInSub) return;
      }

      protected void E153W2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         divLineseparatorcontent_lineseparator_Visible = 0;
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0), true);
         divLineseparatorcontent_lineseparator_Class = "Section_LineSeparatorContentClose";
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Class", divLineseparatorcontent_lineseparator_Class, true);
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorClose";
         AssignProp("", false, divLineseparatorheader_lineseparator_Internalname, "Class", divLineseparatorheader_lineseparator_Class, true);
      }

      protected void E163W2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         imgUpdate_gximage = "K2BActionUpdate";
         AssignProp("", false, imgUpdate_Internalname, "gximage", imgUpdate_gximage, true);
         imgUpdate_Bitmap = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, imgUpdate_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgUpdate_Bitmap)), true);
         AssignProp("", false, imgUpdate_Internalname, "SrcSet", context.GetImageSrcSet( imgUpdate_Bitmap), true);
         imgUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         AssignProp("", false, imgUpdate_Internalname, "Tooltiptext", imgUpdate_Tooltiptext, true);
         imgDelete_gximage = "K2BActionDelete";
         AssignProp("", false, imgDelete_Internalname, "gximage", imgDelete_gximage, true);
         imgDelete_Bitmap = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, imgDelete_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgDelete_Bitmap)), true);
         AssignProp("", false, imgDelete_Internalname, "SrcSet", context.GetImageSrcSet( imgDelete_Bitmap), true);
         imgDelete_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
         AssignProp("", false, imgDelete_Internalname, "Tooltiptext", imgDelete_Tooltiptext, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavSecpolid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0));
         AssignProp("", false, cmbavSecpolid_Internalname, "Values", cmbavSecpolid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Role", AV5Role);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Permissionswc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Permissionswc_Component), StringUtil.Lower( "K2BFSG.RoleSelectPermission")) != 0 )
         {
            WebComp_Permissionswc = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.roleselectpermission", new Object[] {context} );
            WebComp_Permissionswc.ComponentInit();
            WebComp_Permissionswc.Name = "K2BFSG.RoleSelectPermission";
            WebComp_Permissionswc_Component = "K2BFSG.RoleSelectPermission";
         }
         if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
         {
            WebComp_Permissionswc.setjustcreated();
            WebComp_Permissionswc.componentprepare(new Object[] {(string)"W0094",(string)"",(long)AV18Id});
            WebComp_Permissionswc.componentbind(new Object[] {(string)"vID"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Permissionswc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0094"+"");
            WebComp_Permissionswc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Childrenwc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Childrenwc_Component), StringUtil.Lower( "K2BFSG.RoleSelectChildren")) != 0 )
         {
            WebComp_Childrenwc = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.roleselectchildren", new Object[] {context} );
            WebComp_Childrenwc.ComponentInit();
            WebComp_Childrenwc.Name = "K2BFSG.RoleSelectChildren";
            WebComp_Childrenwc_Component = "K2BFSG.RoleSelectChildren";
         }
         if ( StringUtil.Len( WebComp_Childrenwc_Component) != 0 )
         {
            WebComp_Childrenwc.setjustcreated();
            WebComp_Childrenwc.componentprepare(new Object[] {(string)"W0105",(string)"",(long)AV18Id});
            WebComp_Childrenwc.componentbind(new Object[] {(string)"vID"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Childrenwc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0105"+"");
            WebComp_Childrenwc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Userswc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Userswc_Component), StringUtil.Lower( "K2BFSG.RoleUsers")) != 0 )
         {
            WebComp_Userswc = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.roleusers", new Object[] {context} );
            WebComp_Userswc.ComponentInit();
            WebComp_Userswc.Name = "K2BFSG.RoleUsers";
            WebComp_Userswc_Component = "K2BFSG.RoleUsers";
         }
         if ( StringUtil.Len( WebComp_Userswc_Component) != 0 )
         {
            WebComp_Userswc.setjustcreated();
            WebComp_Userswc.componentprepare(new Object[] {(string)"W0108",(string)"",(long)AV18Id});
            WebComp_Userswc.componentbind(new Object[] {(string)"vID"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Userswc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0108"+"");
            WebComp_Userswc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttConfirm_Visible = 0;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttConfirm_Enabled = 0;
            AssignProp("", false, bttConfirm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirm_Enabled), 5, 0), true);
            bttCancel_Visible = 0;
            AssignProp("", false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
            bttCancel_Enabled = 0;
            AssignProp("", false, bttCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttCancel_Enabled), 5, 0), true);
            imgUpdate_Visible = 1;
            AssignProp("", false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgUpdate_Enabled = 1;
            AssignProp("", false, imgUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgUpdate_Enabled), 5, 0), true);
            imgDelete_Visible = 1;
            AssignProp("", false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            imgDelete_Enabled = 1;
            AssignProp("", false, imgDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDelete_Enabled), 5, 0), true);
         }
         else
         {
            bttConfirm_Visible = 1;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttConfirm_Enabled = 1;
            AssignProp("", false, bttConfirm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirm_Enabled), 5, 0), true);
            bttCancel_Visible = 1;
            AssignProp("", false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
            bttCancel_Enabled = 1;
            AssignProp("", false, bttCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttCancel_Enabled), 5, 0), true);
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               bttConfirm_Caption = context.GetMessage( "K2BT_DeleteAction", "");
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               bttConfirm_Caption = context.GetMessage( "K2BT_UpdateAction", "");
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               bttConfirm_Caption = context.GetMessage( "GXM_insert", "");
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            imgUpdate_Visible = 0;
            AssignProp("", false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgUpdate_Enabled = 0;
            AssignProp("", false, imgUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgUpdate_Enabled), 5, 0), true);
            imgDelete_Visible = 0;
            AssignProp("", false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            imgDelete_Enabled = 0;
            AssignProp("", false, imgDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDelete_Enabled), 5, 0), true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E173W2 ();
         if (returnInSub) return;
      }

      protected void E173W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Role", AV5Role);
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV5Role.gxTpr_Id = AV18Id;
            AV5Role.load( AV18Id);
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               AV5Role.gxTpr_Guid = AV19GUID;
               AV5Role.gxTpr_Name = AV20Name;
               AV5Role.gxTpr_Description = AV21Dsc;
               AV5Role.gxTpr_Externalid = AV23ExtId;
               AV5Role.gxTpr_Securitypolicyid = AV22SecPolId;
               AV5Role.save();
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV5Role.delete();
            }
            if ( AV5Role.success() )
            {
               context.CommitDataStores("k2bfsg.entryrole",pr_default);
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV12Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Therolewascreated", ""), AV20Name, "", "", "", "", "", "", "", "");
               }
               if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV12Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Therolewasupdated", ""), AV20Name, "", "", "", "", "", "", "", "");
               }
               if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  AV12Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Therolewasdeleted", ""), AV20Name, "", "", "", "", "", "", "", "");
               }
               new k2btoolsmessagequeueadd(context ).execute(  AV12Message) ;
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  CallWebObject(formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(AV5Role.gxTpr_Id,12,0))}, new string[] {"Mode","Id"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  CallWebObject(formatLink("k2bfsg.wwrole.aspx") );
                  context.wjLocDisableFrm = 1;
               }
            }
            else
            {
               AV8Errors = AV5Role.geterrors();
               AV28GXV2 = 1;
               while ( AV28GXV2 <= AV8Errors.Count )
               {
                  AV9Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8Errors.Item(AV28GXV2));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV9Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV9Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV28GXV2 = (int)(AV28GXV2+1);
               }
            }
         }
      }

      protected void S152( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S162( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwrole.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E183W2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV18Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV18Id", StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
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
         PA3W2( ) ;
         WS3W2( ) ;
         WE3W2( ) ;
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
         if ( ! ( WebComp_Permissionswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Permissionswc_Component) != 0 )
            {
               WebComp_Permissionswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Childrenwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Childrenwc_Component) != 0 )
            {
               WebComp_Childrenwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Userswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Userswc_Component) != 0 )
            {
               WebComp_Userswc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221375639", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryrole.js", "?202431221375643", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavSecpolid.Name = "vSECPOLID";
         cmbavSecpolid.WebTags = "";
         if ( cmbavSecpolid.ItemCount > 0 )
         {
            AV22SecPolId = (int)(Math.Round(NumberUtil.Val( cmbavSecpolid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22SecPolId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22SecPolId", StringUtil.LTrimStr( (decimal)(AV22SecPolId), 9, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         imgUpdate_Internalname = "UPDATE";
         imgDelete_Internalname = "DELETE";
         divActionscontainertableright_actions2_Internalname = "ACTIONSCONTAINERTABLERIGHT_ACTIONS2";
         divResponsivetable_containernode_actions2_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS2";
         edtavId_Internalname = "vID";
         divTable_container_id_Internalname = "TABLE_CONTAINER_ID";
         edtavGuid_Internalname = "vGUID";
         divTable_container_guid_Internalname = "TABLE_CONTAINER_GUID";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavDsc_Internalname = "vDSC";
         divTable_container_dsc_Internalname = "TABLE_CONTAINER_DSC";
         lblLineseparatortitle_lineseparator_Internalname = "LINESEPARATORTITLE_LINESEPARATOR";
         divLineseparatorheader_lineseparator_Internalname = "LINESEPARATORHEADER_LINESEPARATOR";
         cmbavSecpolid_Internalname = "vSECPOLID";
         divTable_container_secpolid_Internalname = "TABLE_CONTAINER_SECPOLID";
         edtavExtid_Internalname = "vEXTID";
         divTable_container_extid_Internalname = "TABLE_CONTAINER_EXTID";
         divLineseparatorcontent_lineseparator_Internalname = "LINESEPARATORCONTENT_LINESEPARATOR";
         divLineseparatorcontainer_lineseparator_Internalname = "LINESEPARATORCONTAINER_LINESEPARATOR";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_general_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERAL";
         divGeneral_content_Internalname = "GENERAL_CONTENT";
         General_Internalname = "GENERAL";
         divColumn_Internalname = "COLUMN";
         divAttributescontainertable_responsivetable_mainattributes_attributes1_Internalname = "ATTRIBUTESCONTAINERTABLE_RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1";
         divResponsivetable_mainattributes_attributes1_content_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1_CONTENT";
         Responsivetable_mainattributes_attributes1_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1";
         divColumn1_Internalname = "COLUMN1";
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
         WebComp_Permissionswc_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0094"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Permissionswc_Visible), 5, 0), true);
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         edtavExtid_Jsonclick = "";
         edtavExtid_Enabled = 1;
         cmbavSecpolid_Jsonclick = "";
         cmbavSecpolid.Enabled = 1;
         divLineseparatorcontent_lineseparator_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lineseparator_Visible = 1;
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorOpen";
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavGuid_Visible = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         imgDelete_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         Responsivetable_mainattributes_attributes1_Visible = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes1_Containseditableform = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_attributes1_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes1_Open = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_attributes1_Collapsible = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes1_Title = context.GetMessage( "K2BT_GAM_ChildRoles", "");
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( -1);
         General_Title = context.GetMessage( "K2BT_General", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_Role", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV19GUID',fld:'vGUID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'edtavDsc_Enabled',ctrl:'vDSC',prop:'Enabled'},{av:'edtavExtid_Enabled',ctrl:'vEXTID',prop:'Enabled'},{av:'cmbavSecpolid'},{av:'AV20Name',fld:'vNAME',pic:''},{av:'AV21Dsc',fld:'vDSC',pic:''},{av:'AV23ExtId',fld:'vEXTID',pic:''},{av:'AV22SecPolId',fld:'vSECPOLID',pic:'ZZZZZZZZ9'},{ctrl:'CONFIRM',prop:'Visible'},{av:'edtavGuid_Visible',ctrl:'vGUID',prop:'Visible'},{av:'AV19GUID',fld:'vGUID',pic:'',hsh:true},{ctrl:'PERMISSIONSWC',prop:'Visible'},{av:'Responsivetable_mainattributes_attributes1_Visible',ctrl:'RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES1',prop:'Visible'},{ctrl:'PERMISSIONSWC'},{ctrl:'CHILDRENWC'},{ctrl:'USERSWC'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("ENTER","{handler:'E173W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV19GUID',fld:'vGUID',pic:'',hsh:true},{av:'AV20Name',fld:'vNAME',pic:''},{av:'AV21Dsc',fld:'vDSC',pic:''},{av:'AV23ExtId',fld:'vEXTID',pic:''},{av:'cmbavSecpolid'},{av:'AV22SecPolId',fld:'vSECPOLID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_UPDATE'","{handler:'E113W1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E123W1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV18Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E143W1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK","{handler:'E133W1',iparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK",",oparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'},{av:'divLineseparatorcontent_lineseparator_Class',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Class'},{av:'divLineseparatorheader_lineseparator_Class',ctrl:'LINESEPARATORHEADER_LINESEPARATOR',prop:'Class'}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV19GUID = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         ucGeneral = new GXUserControl();
         TempTags = "";
         imgUpdate_gximage = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_gximage = "";
         imgDelete_Jsonclick = "";
         AV20Name = "";
         AV21Dsc = "";
         lblLineseparatortitle_lineseparator_Jsonclick = "";
         AV23ExtId = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         WebComp_Permissionswc_Component = "";
         OldPermissionswc = "";
         ucResponsivetable_mainattributes_attributes1 = new GXUserControl();
         WebComp_Childrenwc_Component = "";
         OldChildrenwc = "";
         WebComp_Userswc_Component = "";
         OldUserswc = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV6SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV10Filter = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV7SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV5Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryrole__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryrole__default(),
            new Object[][] {
            }
         );
         WebComp_Permissionswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Childrenwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Userswc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavGuid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divLineseparatorcontent_lineseparator_Visible ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int edtavId_Enabled ;
      private int edtavGuid_Visible ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int AV22SecPolId ;
      private int edtavExtid_Enabled ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int WebComp_Permissionswc_Visible ;
      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private int idxLst ;
      private long AV18Id ;
      private long wcpOAV18Id ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV19GUID ;
      private string GXKey ;
      private string General_Title ;
      private string Responsivetable_mainattributes_attributes1_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divColumns_Internalname ;
      private string divColumn_Internalname ;
      private string General_Internalname ;
      private string divGeneral_content_Internalname ;
      private string divAttributescontainertable_general_Internalname ;
      private string divResponsivetable_containernode_actions2_Internalname ;
      private string divActionscontainertableright_actions2_Internalname ;
      private string TempTags ;
      private string imgUpdate_gximage ;
      private string sImgUrl ;
      private string imgUpdate_Internalname ;
      private string imgUpdate_Tooltiptext ;
      private string imgUpdate_Jsonclick ;
      private string imgDelete_gximage ;
      private string imgDelete_Internalname ;
      private string imgDelete_Tooltiptext ;
      private string imgDelete_Jsonclick ;
      private string divTable_container_id_Internalname ;
      private string edtavId_Internalname ;
      private string edtavId_Jsonclick ;
      private string divTable_container_guid_Internalname ;
      private string edtavGuid_Internalname ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV20Name ;
      private string edtavName_Jsonclick ;
      private string divTable_container_dsc_Internalname ;
      private string edtavDsc_Internalname ;
      private string AV21Dsc ;
      private string edtavDsc_Jsonclick ;
      private string divLineseparatorcontainer_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Class ;
      private string lblLineseparatortitle_lineseparator_Internalname ;
      private string lblLineseparatortitle_lineseparator_Jsonclick ;
      private string divLineseparatorcontent_lineseparator_Internalname ;
      private string divLineseparatorcontent_lineseparator_Class ;
      private string divTable_container_secpolid_Internalname ;
      private string cmbavSecpolid_Internalname ;
      private string cmbavSecpolid_Jsonclick ;
      private string divTable_container_extid_Internalname ;
      private string edtavExtid_Internalname ;
      private string AV23ExtId ;
      private string edtavExtid_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Caption ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divColumn1_Internalname ;
      private string WebComp_Permissionswc_Component ;
      private string OldPermissionswc ;
      private string Responsivetable_mainattributes_attributes1_Internalname ;
      private string divResponsivetable_mainattributes_attributes1_content_Internalname ;
      private string divAttributescontainertable_responsivetable_mainattributes_attributes1_Internalname ;
      private string WebComp_Childrenwc_Component ;
      private string OldChildrenwc ;
      private string WebComp_Userswc_Component ;
      private string OldUserswc ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool Responsivetable_mainattributes_attributes1_Collapsible ;
      private bool Responsivetable_mainattributes_attributes1_Open ;
      private bool Responsivetable_mainattributes_attributes1_Showborders ;
      private bool Responsivetable_mainattributes_attributes1_Containseditableform ;
      private bool Responsivetable_mainattributes_attributes1_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Permissionswc ;
      private bool bDynCreated_Childrenwc ;
      private bool bDynCreated_Userswc ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXWebComponent WebComp_Permissionswc ;
      private GXWebComponent WebComp_Childrenwc ;
      private GXWebComponent WebComp_Userswc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucResponsivetable_mainattributes_attributes1 ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCombobox cmbavSecpolid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV6SecurityPolicies ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV5Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV9Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV7SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV10Filter ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
   }

   public class entryrole__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class entryrole__default : DataStoreHelperBase, IDataStoreHelper
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
