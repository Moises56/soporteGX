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
   public class entryuser : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entryuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV66UserId = aP1_UserId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_UserId=this.AV66UserId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAuthenticationtypename = new GXCombobox();
         cmbavGender = new GXCombobox();
         chkavIsactive = new GXCheckbox();
         chkavIsenabledinrepository = new GXCheckbox();
         chkavDontreciveinformation = new GXCheckbox();
         chkavCanotchangepassword = new GXCheckbox();
         chkavMustchangepassword = new GXCheckbox();
         chkavPasswordneverexpires = new GXCheckbox();
         chkavIsblocked = new GXCheckbox();
         cmbavSecuritypolicyid = new GXCombobox();
         chkavEnabletwofactorauthentication = new GXCheckbox();
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
                  AV66UserId = GetPar( "UserId");
                  AssignAttri("", false, "AV66UserId", AV66UserId);
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
         PA412( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START412( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 115740), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"Gx_mode","UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV32Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Language, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV32Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_boolean_hidden_field( context, "vISLOCALAUTHENTICATION", AV69IsLocalAuthentication);
         GxWebStd.gx_hidden_field( context, "GENERAL_Title", StringUtil.RTrim( General_Title));
         GxWebStd.gx_hidden_field( context, "GENERAL_Collapsible", StringUtil.BoolToStr( General_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERAL_Open", StringUtil.BoolToStr( General_Open));
         GxWebStd.gx_hidden_field( context, "GENERAL_Showborders", StringUtil.BoolToStr( General_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERAL_Containseditableform", StringUtil.BoolToStr( General_Containseditableform));
         GxWebStd.gx_hidden_field( context, "LINESEPARATORCONTENT_LINESEPARATOR_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LINESEPARATORCONTENT_TBL2FA_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_tbl2fa_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LINESEPARATORCONTENT_TBLOTP_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLineseparatorcontent_tblotp_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Rolescomponent == null ) )
         {
            WebComp_Rolescomponent.componentjscripts();
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
            WE412( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT412( ) ;
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
         return formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"Gx_mode","UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_User", "") ;
      }

      protected void WB410( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, lblTitle_Caption, "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
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
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11411_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12411_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserid_Internalname, context.GetMessage( "K2BT_GUID", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUserid_Internalname, StringUtil.RTrim( AV66UserId), StringUtil.RTrim( context.localUtil.Format( AV66UserId, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUserid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_usernamespace_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUsernamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsernamespace_Internalname, context.GetMessage( "K2BT_GAM_NameSpace", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsernamespace_Internalname, StringUtil.RTrim( AV67UserNameSpace), StringUtil.RTrim( context.localUtil.Format( AV67UserNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsernamespace_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsernamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authenticationtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavAuthenticationtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavAuthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAuthenticationtypename_Internalname, context.GetMessage( "K2BT_GAM_AuthenticationType", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAuthenticationtypename, cmbavAuthenticationtypename_Internalname, StringUtil.RTrim( AV11AuthenticationTypeName), 1, cmbavAuthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavAuthenticationtypename.Visible, cmbavAuthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_K2BFSG\\EntryUser.htm");
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV11AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", (string)(cmbavAuthenticationtypename.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV38Name, StringUtil.RTrim( context.localUtil.Format( AV38Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_email_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, context.GetMessage( "K2BT_GAM_Email", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV18Email, StringUtil.RTrim( context.localUtil.Format( AV18Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 60, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_firstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, context.GetMessage( "K2BT_GAM_FirstName", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV24FirstName), StringUtil.RTrim( context.localUtil.Format( AV24FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_lastname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, context.GetMessage( "K2BT_GAM_LastName", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV33LastName), StringUtil.RTrim( context.localUtil.Format( AV33LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_password_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, context.GetMessage( "K2BT_GAM_Password", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV42Password), StringUtil.RTrim( context.localUtil.Format( AV42Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", edtavPassword_Visible, edtavPassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_passwordconf_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPasswordconf_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, context.GetMessage( "K2BT_GAM_PasswordConfirmation", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV43PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV43PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute_Trn Attribute_Required", "", "", "", "", edtavPasswordconf_Visible, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_urlimage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_urlimage_Internalname, context.GetMessage( "K2BT_GAM_Useravatarimageurl", ""), "", "", lblTextblock_var_urlimage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_urlimagecellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlimage_Internalname, context.GetMessage( "K2BT_GAM_Useravatarimageurl", ""), "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlimage_Internalname, AV62URLImage, StringUtil.RTrim( context.localUtil.Format( AV62URLImage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlimage_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUrlimage_Enabled, 1, "text", "", 400, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute_Trn" + " " + ((StringUtil.StrCmp(imgavImage_gximage, "")==0) ? "" : "GX_Image_"+imgavImage_gximage+"_Class");
            StyleString = "";
            AV5Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV76Image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5Image)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5Image)) ? AV76Image_GXI : context.PathToRelativeUrl( AV5Image));
            GxWebStd.gx_bitmap( context, imgavImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavImage_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV5Image_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_birthday_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, context.GetMessage( "K2BT_GAM_Birthday", ""), "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV15Birthday, "99/99/9999"), context.localUtil.Format( AV15Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavBirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_gender_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, context.GetMessage( "K2BT_GAM_Gender", ""), "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV26Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn Attribute_Required", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "", true, 0, "HLP_K2BFSG\\EntryUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV26Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_phone_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, context.GetMessage( "K2BT_GAM_Phone", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV46Phone), StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavPhone_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_isactive_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_isactive_Internalname, context.GetMessage( "K2BT_GAM_AccountIsActive", ""), "", "", lblTextblock_var_isactive_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isactivecellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsactive_Internalname, context.GetMessage( "K2BT_GAM_AccountIsActive", ""), "gx-form-item CheckBoxAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsactive_Internalname, StringUtil.BoolToStr( AV28IsActive), "", context.GetMessage( "K2BT_GAM_AccountIsActive", ""), chkavIsactive.Visible, chkavIsactive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(125, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,125);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavActivationdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavActivationdate_Internalname, context.localUtil.TToC( AV8ActivationDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV8ActivationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActivationdate_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", edtavActivationdate_Visible, edtavActivationdate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavActivationdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavActivationdate_Visible==0)||(edtavActivationdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsendactivationemail_Internalname, "", context.GetMessage( "K2BT_GAM_SendActivationEmail", ""), bttBtnsendactivationemail_Jsonclick, 5, bttBtnsendactivationemail_Tooltiptext, "", StyleString, ClassString, bttBtnsendactivationemail_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_BTNSENDACTIVATIONEMAIL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isenabledinrepository_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_isenabledinrepository_Internalname, context.GetMessage( "K2BT_GAM_IsEnabledInRepository", ""), "", "", lblTextblock_var_isenabledinrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_isenabledinrepositorycellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenabledinrepository_Internalname, context.GetMessage( "K2BT_GAM_IsEnabledInRepository", ""), "gx-form-item CheckBoxAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenabledinrepository_Internalname, StringUtil.BoolToStr( AV30IsEnabledInRepository), "", context.GetMessage( "K2BT_GAM_IsEnabledInRepository", ""), chkavIsenabledinrepository.Visible, chkavIsenabledinrepository.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(137, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,137);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEnable_Internalname, "", bttEnable_Caption, bttEnable_Jsonclick, 5, "", "", StyleString, ClassString, bttEnable_Visible, bttEnable_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ENABLE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lineseparator_Internalname, context.GetMessage( "K2BT_GAM_Advanced", ""), "", "", lblLineseparatortitle_lineseparator_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13411_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_lineseparator_Internalname, divLineseparatorcontent_lineseparator_Visible, 0, "px", 0, "px", divLineseparatorcontent_lineseparator_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_externalid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavExternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExternalid_Internalname, context.GetMessage( "K2BT_GAM_ExternalId", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavExternalid_Internalname, AV22ExternalId, StringUtil.RTrim( context.localUtil.Format( AV22ExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavExternalid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavExternalid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_urlprofile_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_urlprofile_Internalname, context.GetMessage( "K2BT_GAM_ProfileURL", ""), "", "", lblTextblock_var_urlprofile_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_urlprofilecellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlprofile_Internalname, context.GetMessage( "K2BT_GAM_ProfileURL", ""), "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlprofile_Internalname, AV63URLProfile, StringUtil.RTrim( context.localUtil.Format( AV63URLProfile, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlprofile_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUrlprofile_Visible, edtavUrlprofile_Enabled, 1, "text", "", 120, "chr", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttOpenprofile_Internalname, "", context.GetMessage( "K2BT_GAM_OpenProfile", ""), bttOpenprofile_Jsonclick, 7, "", "", StyleString, ClassString, bttOpenprofile_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e14411_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_dontreciveinformation_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavDontreciveinformation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDontreciveinformation_Internalname, context.GetMessage( "K2BT_GAM_Don'twanttoreciveadditionalinformation", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDontreciveinformation_Internalname, StringUtil.BoolToStr( AV17DontReciveInformation), "", context.GetMessage( "K2BT_GAM_Don'twanttoreciveadditionalinformation", ""), 1, chkavDontreciveinformation.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(164, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,164);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_canotchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCanotchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCanotchangepassword_Internalname, context.GetMessage( "K2BT_GAM_Cannotchangepassword", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCanotchangepassword_Internalname, StringUtil.BoolToStr( AV16CanotChangePassword), "", context.GetMessage( "K2BT_GAM_Cannotchangepassword", ""), 1, chkavCanotchangepassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(170, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,170);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_mustchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavMustchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMustchangepassword_Internalname, context.GetMessage( "K2BT_GAM_MustChangePassword", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMustchangepassword_Internalname, StringUtil.BoolToStr( AV37MustChangePassword), "", context.GetMessage( "K2BT_GAM_MustChangePassword", ""), 1, chkavMustchangepassword.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(176, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,176);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_passwordneverexpires_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavPasswordneverexpires_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavPasswordneverexpires_Internalname, context.GetMessage( "K2BT_GAM_PasswordNeverExpire", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavPasswordneverexpires_Internalname, StringUtil.BoolToStr( AV45PasswordNeverExpires), "", context.GetMessage( "K2BT_GAM_PasswordNeverExpire", ""), 1, chkavPasswordneverexpires.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(182, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,182);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_isblocked_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavIsblocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsblocked_Internalname, context.GetMessage( "K2BT_GAM_UserIsBlocked", ""), "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsblocked_Internalname, StringUtil.BoolToStr( AV29IsBlocked), "", context.GetMessage( "K2BT_GAM_UserIsBlocked", ""), 1, chkavIsblocked.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(188, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,188);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_securitypolicyid_Internalname, divTable_container_securitypolicyid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavSecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecuritypolicyid_Internalname, context.GetMessage( "K2BT_GAM_SecurityPolicyId", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecuritypolicyid, cmbavSecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0)), 1, cmbavSecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecuritypolicyid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "", true, 0, "HLP_K2BFSG\\EntryUser.htm");
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", (string)(cmbavSecuritypolicyid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_tbl2fa_Internalname, 1, 0, "px", 0, "px", divLineseparatorcontainer_tbl2fa_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_tbl2fa_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_tbl2fa_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_tbl2fa_Internalname, context.GetMessage( "K2BT_GAM_TwoFactorAuthentication", ""), "", "", lblLineseparatortitle_tbl2fa_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15411_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_tbl2fa_Internalname, divLineseparatorcontent_tbl2fa_Visible, 0, "px", 0, "px", divLineseparatorcontent_tbl2fa_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_enabletwofactorauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavEnabletwofactorauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnabletwofactorauthentication_Internalname, context.GetMessage( "K2BT_GAM_EnableTwoFactorAuthentication", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnabletwofactorauthentication_Internalname, StringUtil.BoolToStr( AV19EnableTwoFactorAuthentication), "", context.GetMessage( "K2BT_GAM_EnableTwoFactorAuthentication", ""), 1, chkavEnabletwofactorauthentication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(206, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,206);\"");
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
            GxWebStd.gx_div_start( context, divLineseparatorcontainer_tblotp_Internalname, 1, 0, "px", 0, "px", divLineseparatorcontainer_tblotp_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorheader_tblotp_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_tblotp_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_tblotp_Internalname, context.GetMessage( "K2BT_GAM_OneTimePassword", ""), "", "", lblLineseparatortitle_tblotp_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16411_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLineseparatorcontent_tblotp_Internalname, divLineseparatorcontent_tblotp_Visible, 0, "px", 0, "px", divLineseparatorcontent_tblotp_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_otpnumberlocked_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpnumberlocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpnumberlocked_Internalname, context.GetMessage( "K2BT_GAM_OTPNumberLocked", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 218,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpnumberlocked_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41OTPNumberLocked), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavOtpnumberlocked_Enabled!=0) ? context.localUtil.Format( (decimal)(AV41OTPNumberLocked), "ZZZ9") : context.localUtil.Format( (decimal)(AV41OTPNumberLocked), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,218);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpnumberlocked_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpnumberlocked_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otplastlockeddate_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtplastlockeddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastlockeddate_Internalname, context.GetMessage( "K2BT_GAM_OTPLastLockedDate", ""), "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastlockeddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastlockeddate_Internalname, context.localUtil.TToC( AV7OTPLastLockedDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV7OTPLastLockedDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,224);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastlockeddate_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtavOtplastlockeddate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastlockeddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavOtplastlockeddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otpdailynumbercodes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtpdailynumbercodes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpdailynumbercodes_Internalname, context.GetMessage( "K2BT_GAM_OTPDailyNumberCodes", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpdailynumbercodes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39OTPDailyNumberCodes), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavOtpdailynumbercodes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV39OTPDailyNumberCodes), "ZZZ9") : context.localUtil.Format( (decimal)(AV39OTPDailyNumberCodes), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpdailynumbercodes_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOtpdailynumbercodes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_otplastdaterequestcode_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOtplastdaterequestcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastdaterequestcode_Internalname, context.GetMessage( "K2BT_GAM_OTPLastDateRequestCode", ""), "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastdaterequestcode_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastdaterequestcode_Internalname, context.localUtil.Format(AV40OTPLastDateRequestCode, "99/99/9999"), context.localUtil.Format( AV40OTPLastDateRequestCode, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,236);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastdaterequestcode_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtavOtplastdaterequestcode_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastdaterequestcode_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavOtplastdaterequestcode_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEnableauthenticator_Internalname, "", bttEnableauthenticator_Caption, bttEnableauthenticator_Jsonclick, 5, "", "", StyleString, ClassString, bttEnableauthenticator_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ENABLEAUTHENTICATOR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUnblockotpcodes_Internalname, "", context.GetMessage( "K2BT_GAM_UnblockOTPCodes", ""), bttUnblockotpcodes_Jsonclick, 5, bttUnblockotpcodes_Tooltiptext, "", StyleString, ClassString, bttUnblockotpcodes_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_UNBLOCKOTPCODES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions1_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 254,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e17411_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryUser.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumn1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0261"+"", StringUtil.RTrim( WebComp_Rolescomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0261"+""+"\""+((WebComp_Rolescomponent_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRolescomponent), StringUtil.Lower( WebComp_Rolescomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0261"+"");
                  }
                  WebComp_Rolescomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRolescomponent), StringUtil.Lower( WebComp_Rolescomponent_Component)) != 0 )
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

      protected void START412( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_User", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP410( ) ;
      }

      protected void WS412( )
      {
         START412( ) ;
         EVT412( ) ;
      }

      protected void EVT412( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VAUTHENTICATIONTYPENAME.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E19412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E20412 ();
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
                                    E21412 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ENABLE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Enable' */
                              E22412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_UNBLOCKOTPCODES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_UnblockOTPCodes' */
                              E23412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_BTNSENDACTIVATIONEMAIL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_BtnSendActivationEmail' */
                              E24412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ENABLEAUTHENTICATOR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_EnableAuthenticator' */
                              E25412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E26412 ();
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
                        if ( nCmpId == 261 )
                        {
                           OldRolescomponent = cgiGet( "W0261");
                           if ( ( StringUtil.Len( OldRolescomponent) == 0 ) || ( StringUtil.StrCmp(OldRolescomponent, WebComp_Rolescomponent_Component) != 0 ) )
                           {
                              WebComp_Rolescomponent = getWebComponent(GetType(), "GeneXus.Programs", OldRolescomponent, new Object[] {context} );
                              WebComp_Rolescomponent.ComponentInit();
                              WebComp_Rolescomponent.Name = "OldRolescomponent";
                              WebComp_Rolescomponent_Component = OldRolescomponent;
                           }
                           if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
                           {
                              WebComp_Rolescomponent.componentprocess("W0261", "", sEvt);
                           }
                           WebComp_Rolescomponent_Component = OldRolescomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE412( )
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

      protected void PA412( )
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
               GX_FocusControl = edtavUsernamespace_Internalname;
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
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV11AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV11AuthenticationTypeName);
            AssignAttri("", false, "AV11AuthenticationTypeName", AV11AuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV11AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", cmbavAuthenticationtypename.ToJavascriptSource(), true);
         }
         if ( cmbavGender.ItemCount > 0 )
         {
            AV26Gender = cmbavGender.getValidValue(AV26Gender);
            AssignAttri("", false, "AV26Gender", AV26Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV26Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         AV28IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsActive));
         AssignAttri("", false, "AV28IsActive", AV28IsActive);
         AV30IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV30IsEnabledInRepository));
         AssignAttri("", false, "AV30IsEnabledInRepository", AV30IsEnabledInRepository);
         AV17DontReciveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV17DontReciveInformation));
         AssignAttri("", false, "AV17DontReciveInformation", AV17DontReciveInformation);
         AV16CanotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV16CanotChangePassword));
         AssignAttri("", false, "AV16CanotChangePassword", AV16CanotChangePassword);
         AV37MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV37MustChangePassword));
         AssignAttri("", false, "AV37MustChangePassword", AV37MustChangePassword);
         AV45PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV45PasswordNeverExpires));
         AssignAttri("", false, "AV45PasswordNeverExpires", AV45PasswordNeverExpires);
         AV29IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV29IsBlocked));
         AssignAttri("", false, "AV29IsBlocked", AV29IsBlocked);
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV58SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV58SecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         }
         AV19EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV19EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV19EnableTwoFactorAuthentication", AV19EnableTwoFactorAuthentication);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF412( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
      }

      protected void RF412( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E20412 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Rolescomponent_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
               {
                  WebComp_Rolescomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E26412 ();
            WB410( ) ;
         }
      }

      protected void send_integrity_lvl_hashes412( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV32Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32Language, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP410( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19412 ();
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
            /* Read variables values. */
            AV66UserId = cgiGet( edtavUserid_Internalname);
            AssignAttri("", false, "AV66UserId", AV66UserId);
            AV67UserNameSpace = cgiGet( edtavUsernamespace_Internalname);
            AssignAttri("", false, "AV67UserNameSpace", AV67UserNameSpace);
            cmbavAuthenticationtypename.CurrentValue = cgiGet( cmbavAuthenticationtypename_Internalname);
            AV11AuthenticationTypeName = cgiGet( cmbavAuthenticationtypename_Internalname);
            AssignAttri("", false, "AV11AuthenticationTypeName", AV11AuthenticationTypeName);
            AV38Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV38Name", AV38Name);
            AV18Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV18Email", AV18Email);
            AV24FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV24FirstName", AV24FirstName);
            AV33LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV33LastName", AV33LastName);
            AV42Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV42Password", AV42Password);
            AV43PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV43PasswordConf", AV43PasswordConf);
            AV62URLImage = cgiGet( edtavUrlimage_Internalname);
            AssignAttri("", false, "AV62URLImage", AV62URLImage);
            AV5Image = cgiGet( imgavImage_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Birthday", "")}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV15Birthday", context.localUtil.Format(AV15Birthday, "99/99/9999"));
            }
            else
            {
               AV15Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV15Birthday", context.localUtil.Format(AV15Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV26Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV26Gender", AV26Gender);
            AV46Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV46Phone", AV46Phone);
            AV28IsActive = StringUtil.StrToBool( cgiGet( chkavIsactive_Internalname));
            AssignAttri("", false, "AV28IsActive", AV28IsActive);
            if ( context.localUtil.VCDateTime( cgiGet( edtavActivationdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Activation Date", "")}), 1, "vACTIVATIONDATE");
               GX_FocusControl = edtavActivationdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ActivationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8ActivationDate", context.localUtil.TToC( AV8ActivationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV8ActivationDate = context.localUtil.CToT( cgiGet( edtavActivationdate_Internalname));
               AssignAttri("", false, "AV8ActivationDate", context.localUtil.TToC( AV8ActivationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            AV30IsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavIsenabledinrepository_Internalname));
            AssignAttri("", false, "AV30IsEnabledInRepository", AV30IsEnabledInRepository);
            AV22ExternalId = cgiGet( edtavExternalid_Internalname);
            AssignAttri("", false, "AV22ExternalId", AV22ExternalId);
            AV63URLProfile = cgiGet( edtavUrlprofile_Internalname);
            AssignAttri("", false, "AV63URLProfile", AV63URLProfile);
            AV17DontReciveInformation = StringUtil.StrToBool( cgiGet( chkavDontreciveinformation_Internalname));
            AssignAttri("", false, "AV17DontReciveInformation", AV17DontReciveInformation);
            AV16CanotChangePassword = StringUtil.StrToBool( cgiGet( chkavCanotchangepassword_Internalname));
            AssignAttri("", false, "AV16CanotChangePassword", AV16CanotChangePassword);
            AV37MustChangePassword = StringUtil.StrToBool( cgiGet( chkavMustchangepassword_Internalname));
            AssignAttri("", false, "AV37MustChangePassword", AV37MustChangePassword);
            AV45PasswordNeverExpires = StringUtil.StrToBool( cgiGet( chkavPasswordneverexpires_Internalname));
            AssignAttri("", false, "AV45PasswordNeverExpires", AV45PasswordNeverExpires);
            AV29IsBlocked = StringUtil.StrToBool( cgiGet( chkavIsblocked_Internalname));
            AssignAttri("", false, "AV29IsBlocked", AV29IsBlocked);
            cmbavSecuritypolicyid.CurrentValue = cgiGet( cmbavSecuritypolicyid_Internalname);
            AV58SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecuritypolicyid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV58SecurityPolicyId), 9, 0));
            AV19EnableTwoFactorAuthentication = StringUtil.StrToBool( cgiGet( chkavEnabletwofactorauthentication_Internalname));
            AssignAttri("", false, "AV19EnableTwoFactorAuthentication", AV19EnableTwoFactorAuthentication);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPNUMBERLOCKED");
               GX_FocusControl = edtavOtpnumberlocked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41OTPNumberLocked = 0;
               AssignAttri("", false, "AV41OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV41OTPNumberLocked), 4, 0));
            }
            else
            {
               AV41OTPNumberLocked = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV41OTPNumberLocked), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavOtplastlockeddate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "OTPLast Locked Date", "")}), 1, "vOTPLASTLOCKEDDATE");
               GX_FocusControl = edtavOtplastlockeddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7OTPLastLockedDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV7OTPLastLockedDate", context.localUtil.TToC( AV7OTPLastLockedDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV7OTPLastLockedDate = context.localUtil.CToT( cgiGet( edtavOtplastlockeddate_Internalname));
               AssignAttri("", false, "AV7OTPLastLockedDate", context.localUtil.TToC( AV7OTPLastLockedDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPDAILYNUMBERCODES");
               GX_FocusControl = edtavOtpdailynumbercodes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39OTPDailyNumberCodes = 0;
               AssignAttri("", false, "AV39OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV39OTPDailyNumberCodes), 4, 0));
            }
            else
            {
               AV39OTPDailyNumberCodes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV39OTPDailyNumberCodes), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavOtplastdaterequestcode_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "OTPLast Date Request Code", "")}), 1, "vOTPLASTDATEREQUESTCODE");
               GX_FocusControl = edtavOtplastdaterequestcode_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40OTPLastDateRequestCode = DateTime.MinValue;
               AssignAttri("", false, "AV40OTPLastDateRequestCode", context.localUtil.Format(AV40OTPLastDateRequestCode, "99/99/9999"));
            }
            else
            {
               AV40OTPLastDateRequestCode = context.localUtil.CToD( cgiGet( edtavOtplastdaterequestcode_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV40OTPLastDateRequestCode", context.localUtil.Format(AV40OTPLastDateRequestCode, "99/99/9999"));
            }
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
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
      }

      protected void E18412( )
      {
         /* Authenticationtypename_Isvalid Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDISLOCALAUTHENTICATION' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         divLineseparatorcontainer_tbl2fa_Class = "Group_Invisible";
         AssignProp("", false, divLineseparatorcontainer_tbl2fa_Internalname, "Class", divLineseparatorcontainer_tbl2fa_Class, true);
         divLineseparatorcontainer_tblotp_Class = "Group_Invisible";
         AssignProp("", false, divLineseparatorcontainer_tblotp_Internalname, "Class", divLineseparatorcontainer_tblotp_Class, true);
         AV25GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( (0==AV25GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            cmbavAuthenticationtypename.removeAllItems();
            AV12AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV32Language, out  AV21Errors);
            AV74GXV1 = 1;
            while ( AV74GXV1 <= AV12AuthenticationTypes.Count )
            {
               AV13AuthenticationTypesIns = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV12AuthenticationTypes.Item(AV74GXV1));
               cmbavAuthenticationtypename.addItem(AV13AuthenticationTypesIns.gxTpr_Name, AV13AuthenticationTypesIns.gxTpr_Description, 0);
               AV74GXV1 = (int)(AV74GXV1+1);
            }
         }
         else
         {
            cmbavAuthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
         }
         if ( AV25GAMRepository.istwofactorauthenticationenabled() )
         {
            divLineseparatorcontainer_tbl2fa_Class = "Group";
            AssignProp("", false, divLineseparatorcontainer_tbl2fa_Internalname, "Class", divLineseparatorcontainer_tbl2fa_Class, true);
         }
         if ( AV25GAMRepository.isonetimepasswordenabled() )
         {
            divLineseparatorcontainer_tblotp_Class = "Group";
            AssignProp("", false, divLineseparatorcontainer_tblotp_Internalname, "Class", divLineseparatorcontainer_tblotp_Class, true);
         }
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         edtavEmail_Enabled = 1;
         AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
         edtavFirstname_Enabled = 1;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
         edtavLastname_Enabled = 1;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
         edtavUrlimage_Enabled = 1;
         AssignProp("", false, edtavUrlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlimage_Enabled), 5, 0), true);
         edtavUrlprofile_Enabled = 1;
         AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
         edtavExternalid_Enabled = 1;
         AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
         edtavBirthday_Enabled = 1;
         AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
         cmbavGender.Enabled = 1;
         AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
         chkavIsactive.Enabled = 1;
         AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         chkavDontreciveinformation.Enabled = 1;
         AssignProp("", false, chkavDontreciveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreciveinformation.Enabled), 5, 0), true);
         chkavCanotchangepassword.Enabled = 1;
         AssignProp("", false, chkavCanotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCanotchangepassword.Enabled), 5, 0), true);
         chkavMustchangepassword.Enabled = 1;
         AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
         chkavIsblocked.Enabled = 1;
         AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
         chkavPasswordneverexpires.Enabled = 1;
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
         cmbavSecuritypolicyid.Enabled = 1;
         AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
         edtavPhone_Enabled = 1;
         AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
         AV38Name = "";
         AssignAttri("", false, "AV38Name", AV38Name);
         AV18Email = "";
         AssignAttri("", false, "AV18Email", AV18Email);
         AV24FirstName = "";
         AssignAttri("", false, "AV24FirstName", AV24FirstName);
         AV33LastName = "";
         AssignAttri("", false, "AV33LastName", AV33LastName);
         AV62URLImage = "";
         AssignAttri("", false, "AV62URLImage", AV62URLImage);
         AV63URLProfile = "";
         AssignAttri("", false, "AV63URLProfile", AV63URLProfile);
         AV22ExternalId = "";
         AssignAttri("", false, "AV22ExternalId", AV22ExternalId);
         AV15Birthday = DateTime.MinValue;
         AssignAttri("", false, "AV15Birthday", context.localUtil.Format(AV15Birthday, "99/99/9999"));
         AV26Gender = "";
         AssignAttri("", false, "AV26Gender", AV26Gender);
         AV28IsActive = true;
         AssignAttri("", false, "AV28IsActive", AV28IsActive);
         AV17DontReciveInformation = false;
         AssignAttri("", false, "AV17DontReciveInformation", AV17DontReciveInformation);
         AV16CanotChangePassword = false;
         AssignAttri("", false, "AV16CanotChangePassword", AV16CanotChangePassword);
         AV37MustChangePassword = false;
         AssignAttri("", false, "AV37MustChangePassword", AV37MustChangePassword);
         AV29IsBlocked = false;
         AssignAttri("", false, "AV29IsBlocked", AV29IsBlocked);
         AV45PasswordNeverExpires = false;
         AssignAttri("", false, "AV45PasswordNeverExpires", AV45PasswordNeverExpires);
         AV58SecurityPolicyId = 0;
         AssignAttri("", false, "AV58SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV58SecurityPolicyId), 9, 0));
         AV56SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV23FilterSecPol, out  AV21Errors);
         cmbavSecuritypolicyid.addItem("0", context.GetMessage( "GX_EmptyItemText", ""), 0);
         AV75GXV2 = 1;
         while ( AV75GXV2 <= AV56SecurityPolicies.Count )
         {
            AV57SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV56SecurityPolicies.Item(AV75GXV2));
            cmbavSecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV57SecurityPolicy.gxTpr_Id), 9, 0)), AV57SecurityPolicy.gxTpr_Name, 0);
            AV75GXV2 = (int)(AV75GXV2+1);
         }
         chkavIsenabledinrepository.Visible = 0;
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
         bttEnable_Visible = 0;
         AssignProp("", false, bttEnable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnable_Visible), 5, 0), true);
         bttEnable_Enabled = 0;
         AssignProp("", false, bttEnable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnable_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbavAuthenticationtypename.Enabled = 1;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV11AuthenticationTypeName = "local";
            AssignAttri("", false, "AV11AuthenticationTypeName", AV11AuthenticationTypeName);
            edtavUrlprofile_Visible = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            /* Execute user subroutine: 'VALIDISLOCALAUTHENTICATION' */
            S112 ();
            if (returnInSub) return;
            AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            AV67UserNameSpace = AV47Repository.gxTpr_Namespace;
            AssignAttri("", false, "AV67UserNameSpace", AV67UserNameSpace);
            lblTitle_Caption = context.GetMessage( "K2BT_GAM_User", "");
            AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
            chkavIsactive.Visible = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            edtavActivationdate_Visible = 0;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            WebComp_Rolescomponent_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0261"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
            AV19EnableTwoFactorAuthentication = false;
            AssignAttri("", false, "AV19EnableTwoFactorAuthentication", AV19EnableTwoFactorAuthentication);
         }
         else
         {
            chkavIsactive.Visible = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            edtavActivationdate_Visible = 1;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            edtavUrlprofile_Visible = 1;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            edtavPassword_Visible = 0;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            edtavPasswordconf_Visible = 0;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            /* Execute user subroutine: 'VALIDISLOCALAUTHENTICATION' */
            S112 ();
            if (returnInSub) return;
            AV64User.load( AV66UserId);
            cmbavAuthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV11AuthenticationTypeName = AV64User.gxTpr_Authenticationtypename;
            AssignAttri("", false, "AV11AuthenticationTypeName", AV11AuthenticationTypeName);
            AV14AuthTypeId = AV10AuthenticationType.gettypebyname(AV64User.gxTpr_Authenticationtypename, out  AV21Errors);
            if ( StringUtil.StrCmp(AV14AuthTypeId, "GAMLocal") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            AV66UserId = AV64User.gxTpr_Guid;
            AssignAttri("", false, "AV66UserId", AV66UserId);
            AV67UserNameSpace = AV64User.gxTpr_Namespace;
            AssignAttri("", false, "AV67UserNameSpace", AV67UserNameSpace);
            AV38Name = StringUtil.Trim( AV64User.gxTpr_Name);
            AssignAttri("", false, "AV38Name", AV38Name);
            AV18Email = StringUtil.Trim( AV64User.gxTpr_Email);
            AssignAttri("", false, "AV18Email", AV18Email);
            AV24FirstName = StringUtil.Trim( AV64User.gxTpr_Firstname);
            AssignAttri("", false, "AV24FirstName", AV24FirstName);
            AV33LastName = StringUtil.Trim( AV64User.gxTpr_Lastname);
            AssignAttri("", false, "AV33LastName", AV33LastName);
            AV63URLProfile = StringUtil.Trim( AV64User.gxTpr_Urlprofile);
            AssignAttri("", false, "AV63URLProfile", AV63URLProfile);
            AV62URLImage = StringUtil.Trim( AV64User.gxTpr_Urlimage);
            AssignAttri("", false, "AV62URLImage", AV62URLImage);
            AV22ExternalId = AV64User.gxTpr_Externalid;
            AssignAttri("", false, "AV22ExternalId", AV22ExternalId);
            AV15Birthday = AV64User.gxTpr_Birthday;
            AssignAttri("", false, "AV15Birthday", context.localUtil.Format(AV15Birthday, "99/99/9999"));
            AV26Gender = AV64User.gxTpr_Gender;
            AssignAttri("", false, "AV26Gender", AV26Gender);
            AV28IsActive = AV64User.gxTpr_Isactive;
            AssignAttri("", false, "AV28IsActive", AV28IsActive);
            if ( ! AV28IsActive && AV25GAMRepository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount )
            {
               bttBtnsendactivationemail_Visible = 1;
               AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
            }
            else
            {
               bttBtnsendactivationemail_Visible = 0;
               AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
            }
            AV8ActivationDate = AV64User.gxTpr_Activationdate;
            AssignAttri("", false, "AV8ActivationDate", context.localUtil.TToC( AV8ActivationDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV17DontReciveInformation = AV64User.gxTpr_Dontreceiveinformation;
            AssignAttri("", false, "AV17DontReciveInformation", AV17DontReciveInformation);
            AV16CanotChangePassword = AV64User.gxTpr_Cannotchangepassword;
            AssignAttri("", false, "AV16CanotChangePassword", AV16CanotChangePassword);
            AV37MustChangePassword = AV64User.gxTpr_Mustchangepassword;
            AssignAttri("", false, "AV37MustChangePassword", AV37MustChangePassword);
            AV45PasswordNeverExpires = AV64User.gxTpr_Passwordneverexpires;
            AssignAttri("", false, "AV45PasswordNeverExpires", AV45PasswordNeverExpires);
            AV29IsBlocked = AV64User.gxTpr_Isblocked;
            AssignAttri("", false, "AV29IsBlocked", AV29IsBlocked);
            AV58SecurityPolicyId = AV64User.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV58SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV58SecurityPolicyId), 9, 0));
            AV30IsEnabledInRepository = AV64User.gxTpr_Isenabledinrepository;
            AssignAttri("", false, "AV30IsEnabledInRepository", AV30IsEnabledInRepository);
            AV46Phone = AV64User.gxTpr_Phone;
            AssignAttri("", false, "AV46Phone", AV46Phone);
            AV39OTPDailyNumberCodes = AV64User.gxTpr_Otpdailynumbercodes;
            AssignAttri("", false, "AV39OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV39OTPDailyNumberCodes), 4, 0));
            AV40OTPLastDateRequestCode = AV64User.gxTpr_Otplastdaterequestcode;
            AssignAttri("", false, "AV40OTPLastDateRequestCode", context.localUtil.Format(AV40OTPLastDateRequestCode, "99/99/9999"));
            AV7OTPLastLockedDate = DateTimeUtil.ResetTime( AV64User.gxTpr_Otplastlockeddate ) ;
            AssignAttri("", false, "AV7OTPLastLockedDate", context.localUtil.TToC( AV7OTPLastLockedDate, 10, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV41OTPNumberLocked = AV64User.gxTpr_Otpnumberlocked;
            AssignAttri("", false, "AV41OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV41OTPNumberLocked), 4, 0));
            AV19EnableTwoFactorAuthentication = AV64User.gxTpr_Enabletwofactorauthentication;
            AssignAttri("", false, "AV19EnableTwoFactorAuthentication", AV19EnableTwoFactorAuthentication);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64User.gxTpr_Urlimage)) )
            {
               AV5Image = AV64User.gxTpr_Urlimage;
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5Image)) ? AV76Image_GXI : context.convertURL( context.PathToRelativeUrl( AV5Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV5Image), true);
               AV76Image_GXI = GXDbFile.PathToUrl( AV64User.gxTpr_Urlimage);
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5Image)) ? AV76Image_GXI : context.convertURL( context.PathToRelativeUrl( AV5Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV5Image), true);
            }
            else
            {
               imgavImage_Visible = 0;
               AssignProp("", false, imgavImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImage_Visible), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64User.gxTpr_Urlprofile)) && ( StringUtil.StrCmp(AV64User.gxTpr_Authenticationtypename, "GAMLocal") != 0 ) )
            {
               AV63URLProfile = AV64User.gxTpr_Urlprofile;
               AssignAttri("", false, "AV63URLProfile", AV63URLProfile);
               bttOpenprofile_Visible = 1;
               AssignProp("", false, bttOpenprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttOpenprofile_Visible), 5, 0), true);
            }
            else
            {
               bttOpenprofile_Visible = 0;
               AssignProp("", false, bttOpenprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttOpenprofile_Visible), 5, 0), true);
            }
            bttEnable_Caption = (AV30IsEnabledInRepository ? context.GetMessage( "K2BT_GAM_Disable", "") : context.GetMessage( "K2BT_GAM_Enable", ""));
            AssignProp("", false, bttEnable_Internalname, "Caption", bttEnable_Caption, true);
            if ( ! AV28IsActive && AV25GAMRepository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount )
            {
            }
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               lblTitle_Caption = context.GetMessage( "K2BT_GAM_User", "")+" - "+AV38Name;
               AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
               chkavIsenabledinrepository.Visible = 1;
               AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
               bttEnable_Visible = 1;
               AssignProp("", false, bttEnable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnable_Visible), 5, 0), true);
               bttEnable_Enabled = 1;
               AssignProp("", false, bttEnable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnable_Enabled), 5, 0), true);
               WebComp_Rolescomponent_Visible = 0;
               AssignProp("", false, "gxHTMLWrpW0261"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
            }
            else
            {
               if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  lblTitle_Caption = context.GetMessage( "K2BT_GAM_User", "")+" - "+AV38Name;
                  AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
                  WebComp_Rolescomponent_Visible = 0;
                  AssignProp("", false, "gxHTMLWrpW0261"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
                  {
                     lblTitle_Caption = context.GetMessage( "K2BT_GAM_User", "")+" - "+AV38Name;
                     AssignProp("", false, lblTitle_Internalname, "Caption", lblTitle_Caption, true);
                     /* Object Property */
                     if ( true )
                     {
                        bDynCreated_Rolescomponent = true;
                     }
                     if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Rolescomponent_Component), StringUtil.Lower( "K2BFSG.WWUserRole")) != 0 )
                     {
                        WebComp_Rolescomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wwuserrole", new Object[] {context} );
                        WebComp_Rolescomponent.ComponentInit();
                        WebComp_Rolescomponent.Name = "K2BFSG.WWUserRole";
                        WebComp_Rolescomponent_Component = "K2BFSG.WWUserRole";
                     }
                     if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
                     {
                        WebComp_Rolescomponent.setjustcreated();
                        WebComp_Rolescomponent.componentprepare(new Object[] {(string)"W0261",(string)"",(string)AV66UserId});
                        WebComp_Rolescomponent.componentbind(new Object[] {(string)"vUSERID"});
                     }
                     if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Rolescomponent )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0261"+"");
                        WebComp_Rolescomponent.componentdraw();
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( AV25GAMRepository.istotpauthenticatorenabled() )
            {
               bttEnableauthenticator_Visible = 1;
               AssignProp("", false, bttEnableauthenticator_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnableauthenticator_Visible), 5, 0), true);
               if ( AV64User.gxTpr_Totpenable )
               {
                  bttEnableauthenticator_Caption = context.GetMessage( "K2BT_GAM_DisableAuthenticator", "");
                  AssignProp("", false, bttEnableauthenticator_Internalname, "Caption", bttEnableauthenticator_Caption, true);
               }
               else
               {
                  bttEnableauthenticator_Caption = context.GetMessage( "K2BT_GAM_EnableAuthenticator", "");
                  AssignProp("", false, bttEnableauthenticator_Internalname, "Caption", bttEnableauthenticator_Caption, true);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavEmail_Enabled = 0;
            AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
            edtavFirstname_Enabled = 0;
            AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
            edtavLastname_Enabled = 0;
            AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
            edtavUrlprofile_Enabled = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            edtavUrlimage_Enabled = 0;
            AssignProp("", false, edtavUrlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlimage_Enabled), 5, 0), true);
            edtavExternalid_Enabled = 0;
            AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
            edtavBirthday_Enabled = 0;
            AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
            cmbavGender.Enabled = 0;
            AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
            chkavDontreciveinformation.Enabled = 0;
            AssignProp("", false, chkavDontreciveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreciveinformation.Enabled), 5, 0), true);
            chkavCanotchangepassword.Enabled = 0;
            AssignProp("", false, chkavCanotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCanotchangepassword.Enabled), 5, 0), true);
            chkavMustchangepassword.Enabled = 0;
            AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
            chkavIsblocked.Enabled = 0;
            AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
            chkavPasswordneverexpires.Enabled = 0;
            AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
            cmbavSecuritypolicyid.Enabled = 0;
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
            edtavPhone_Enabled = 0;
            AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
            chkavEnabletwofactorauthentication.Enabled = 0;
            AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Enabled), 5, 0), true);
         }
         if ( AV28IsActive )
         {
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
         else
         {
            chkavIsactive.Enabled = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19412 ();
         if (returnInSub) return;
      }

      protected void E19412( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S122 ();
         if (returnInSub) return;
         divLineseparatorcontent_lineseparator_Visible = 0;
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLineseparatorcontent_lineseparator_Visible), 5, 0), true);
         divLineseparatorcontent_lineseparator_Class = "Section_LineSeparatorContentClose";
         AssignProp("", false, divLineseparatorcontent_lineseparator_Internalname, "Class", divLineseparatorcontent_lineseparator_Class, true);
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorClose";
         AssignProp("", false, divLineseparatorheader_lineseparator_Internalname, "Class", divLineseparatorheader_lineseparator_Class, true);
      }

      protected void E20412( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
         divTable_container_securitypolicyid_Visible = 0;
         AssignProp("", false, divTable_container_securitypolicyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable_container_securitypolicyid_Visible), 5, 0), true);
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
         if ( AV25GAMRepository.isonetimepasswordenabled() )
         {
            bttBtnsendactivationemail_Visible = 1;
            AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
         }
         else
         {
            bttBtnsendactivationemail_Visible = 0;
            AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
            bttBtnsendactivationemail_Tooltiptext = "";
            AssignProp("", false, bttBtnsendactivationemail_Internalname, "Tooltiptext", bttBtnsendactivationemail_Tooltiptext, true);
         }
         if ( AV25GAMRepository.isonetimepasswordenabled() )
         {
            bttUnblockotpcodes_Visible = 1;
            AssignProp("", false, bttUnblockotpcodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttUnblockotpcodes_Visible), 5, 0), true);
         }
         else
         {
            bttUnblockotpcodes_Visible = 0;
            AssignProp("", false, bttUnblockotpcodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttUnblockotpcodes_Visible), 5, 0), true);
            bttUnblockotpcodes_Tooltiptext = "";
            AssignProp("", false, bttUnblockotpcodes_Internalname, "Tooltiptext", bttUnblockotpcodes_Tooltiptext, true);
         }
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25GAMRepository", AV25GAMRepository);
         cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV11AuthenticationTypeName);
         AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", cmbavAuthenticationtypename.ToJavascriptSource(), true);
         cmbavGender.CurrentValue = StringUtil.RTrim( AV26Gender);
         AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0));
         AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
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
         E21412 ();
         if (returnInSub) return;
      }

      protected void E21412( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S162( )
      {
         /* 'U_ENABLE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV64User.load( AV66UserId);
            if ( AV30IsEnabledInRepository )
            {
               AV31isOK = AV64User.repositorydisable(out  AV21Errors);
            }
            else
            {
               AV31isOK = AV64User.repositoryenable(out  AV21Errors);
            }
            if ( ! AV31isOK )
            {
               AV77GXV3 = 1;
               while ( AV77GXV3 <= AV21Errors.Count )
               {
                  AV20Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV21Errors.Item(AV77GXV3));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV20Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV20Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV77GXV3 = (int)(AV77GXV3+1);
               }
            }
            else
            {
               context.CommitDataStores("k2bfsg.entryuser",pr_default);
               CallWebObject(formatLink("k2bfsg.wwuser.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
      }

      protected void E22412( )
      {
         /* 'E_Enable' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ENABLE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S152( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            AV64User.gxTpr_Guid = AV66UserId;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV64User.load( AV66UserId);
            }
            AV44PasswordIsOK = true;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDISLOCALAUTHENTICATION' */
               S112 ();
               if (returnInSub) return;
               if ( AV69IsLocalAuthentication )
               {
                  if ( StringUtil.StrCmp(AV42Password, AV43PasswordConf) != 0 )
                  {
                     AV44PasswordIsOK = false;
                     GX_msglist.addItem(context.GetMessage( "K2BT_GAM_PasswordsDoNotMatch", ""));
                  }
               }
               else
               {
                  AV42Password = "";
                  AssignAttri("", false, "AV42Password", AV42Password);
               }
               if ( AV44PasswordIsOK )
               {
                  AV64User.gxTpr_Name = AV38Name;
                  AV64User.gxTpr_Email = AV18Email;
                  AV64User.gxTpr_Firstname = AV24FirstName;
                  AV64User.gxTpr_Lastname = AV33LastName;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
                  {
                     AV64User.gxTpr_Password = AV42Password;
                  }
                  AV64User.gxTpr_Externalid = AV22ExternalId;
                  AV64User.gxTpr_Birthday = AV15Birthday;
                  AV64User.gxTpr_Gender = AV26Gender;
                  AV64User.gxTpr_Isactive = AV28IsActive;
                  AV64User.gxTpr_Urlimage = AV62URLImage;
                  AV64User.gxTpr_Urlprofile = AV63URLProfile;
                  AV64User.gxTpr_Dontreceiveinformation = AV17DontReciveInformation;
                  AV64User.gxTpr_Cannotchangepassword = AV16CanotChangePassword;
                  AV64User.gxTpr_Mustchangepassword = AV37MustChangePassword;
                  AV64User.gxTpr_Isblocked = AV29IsBlocked;
                  AV64User.gxTpr_Passwordneverexpires = AV45PasswordNeverExpires;
                  AV64User.gxTpr_Securitypolicyid = AV58SecurityPolicyId;
                  AV64User.gxTpr_Phone = AV46Phone;
                  AV64User.gxTpr_Enabletwofactorauthentication = AV19EnableTwoFactorAuthentication;
                  AV64User.save();
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV64User.delete();
            }
            if ( AV44PasswordIsOK )
            {
               if ( AV64User.success() )
               {
                  AV35Message = new GeneXus.Utils.SdtMessages_Message(context);
                  if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
                  {
                     AV35Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Userwascreated", ""), AV64User.gxTpr_Name, "", "", "", "", "", "", "", "");
                  }
                  else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     AV35Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Userwasupdated", ""), AV64User.gxTpr_Name, "", "", "", "", "", "", "", "");
                  }
                  else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                  {
                     AV35Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Userwasdeleted", ""), AV38Name, "", "", "", "", "", "", "", "");
                  }
                  new k2btoolsmessagequeueadd(context ).execute(  AV35Message) ;
                  context.CommitDataStores("k2bfsg.entryuser",pr_default);
                  CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV64User.gxTpr_Guid))}, new string[] {"Mode","UserId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV21Errors = AV64User.geterrors();
                  AV78GXV4 = 1;
                  while ( AV78GXV4 <= AV21Errors.Count )
                  {
                     AV20Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV21Errors.Item(AV78GXV4));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV20Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV20Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV78GXV4 = (int)(AV78GXV4+1);
                  }
               }
            }
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwuser.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S182( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S202( )
      {
         /* 'U_OPENPROFILE' Routine */
         returnInSub = false;
         CallWebObject(formatLink(AV63URLProfile) );
         context.wjLocDisableFrm = 0;
      }

      protected void E23412( )
      {
         /* 'E_UnblockOTPCodes' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_UNBLOCKOTPCODES' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S212( )
      {
         /* 'U_UNBLOCKOTPCODES' Routine */
         returnInSub = false;
         AV64User.load( AV66UserId);
         if ( AV64User.unblockotpcodes(out  AV21Errors) )
         {
            context.CommitDataStores("k2bfsg.entryuser",pr_default);
            GX_msglist.addItem(context.GetMessage( "K2BT_GAM_UserOTPCodesUnlocked", ""));
         }
         else
         {
            AV79GXV5 = 1;
            while ( AV79GXV5 <= AV21Errors.Count )
            {
               AV20Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV21Errors.Item(AV79GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV20Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV20Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV79GXV5 = (int)(AV79GXV5+1);
            }
         }
      }

      protected void E24412( )
      {
         /* 'E_BtnSendActivationEmail' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_BTNSENDACTIVATIONEMAIL' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S222( )
      {
         /* 'U_BTNSENDACTIVATIONEMAIL' Routine */
         returnInSub = false;
         AV64User.load( AV66UserId);
         if ( ! AV64User.gxTpr_Isactive )
         {
            AV65UserActivationKey = AV64User.getnewactivationkey(out  AV21Errors);
            context.CommitDataStores("k2bfsg.entryuser",pr_default);
            AV6LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
            new GeneXus.Programs.k2bfsg.checkuseractivationmethod(context ).execute(  AV66UserId,  AV6LinkURL, out  AV36Messages) ;
            AV80GXV6 = 1;
            while ( AV80GXV6 <= AV36Messages.Count )
            {
               AV35Message = ((GeneXus.Utils.SdtMessages_Message)AV36Messages.Item(AV80GXV6));
               GX_msglist.addItem(AV35Message.gxTpr_Description);
               AV80GXV6 = (int)(AV80GXV6+1);
            }
         }
      }

      protected void E25412( )
      {
         /* 'E_EnableAuthenticator' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ENABLEAUTHENTICATOR' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64User", AV64User);
      }

      protected void S232( )
      {
         /* 'U_ENABLEAUTHENTICATOR' Routine */
         returnInSub = false;
         AV64User.load( AV66UserId);
         if ( AV64User.gxTpr_Totpenable )
         {
            AV64User.disabletotpauthenticator(out  AV21Errors);
            bttEnableauthenticator_Caption = context.GetMessage( "K2BT_GAM_DisableAuthenticator", "");
            AssignProp("", false, bttEnableauthenticator_Internalname, "Caption", bttEnableauthenticator_Caption, true);
            CallWebObject(formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            CallWebObject(formatLink("k2bfsg.usertotpactivation.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV66UserId))}, new string[] {"UserId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S112( )
      {
         /* 'VALIDISLOCALAUTHENTICATION' Routine */
         returnInSub = false;
         AV69IsLocalAuthentication = false;
         AssignAttri("", false, "AV69IsLocalAuthentication", AV69IsLocalAuthentication);
         AV12AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV32Language, out  AV21Errors);
         AV81GXV7 = 1;
         while ( AV81GXV7 <= AV12AuthenticationTypes.Count )
         {
            AV70AuthenticationTypeSimple = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV12AuthenticationTypes.Item(AV81GXV7));
            if ( StringUtil.StrCmp(AV70AuthenticationTypeSimple.gxTpr_Name, AV11AuthenticationTypeName) == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70AuthenticationTypeSimple.gxTpr_Impersonate)) )
               {
                  if ( StringUtil.StrCmp(AV70AuthenticationTypeSimple.gxTpr_Impersonate, "local") == 0 )
                  {
                     AV69IsLocalAuthentication = true;
                     AssignAttri("", false, "AV69IsLocalAuthentication", AV69IsLocalAuthentication);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV70AuthenticationTypeSimple.gxTpr_Type, "GAMLocal") == 0 )
                  {
                     AV69IsLocalAuthentication = true;
                     AssignAttri("", false, "AV69IsLocalAuthentication", AV69IsLocalAuthentication);
                  }
               }
               if ( AV69IsLocalAuthentication && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
               {
                  edtavPassword_Visible = 1;
                  AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
                  edtavPasswordconf_Visible = 1;
                  AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
               }
               else
               {
                  edtavPassword_Visible = 0;
                  AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
                  edtavPasswordconf_Visible = 0;
                  AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
               }
               if (true) break;
            }
            AV81GXV7 = (int)(AV81GXV7+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E26412( )
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
         AV66UserId = (string)getParm(obj,1);
         AssignAttri("", false, "AV66UserId", AV66UserId);
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
         PA412( ) ;
         WS412( ) ;
         WE412( ) ;
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
         if ( ! ( WebComp_Rolescomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Rolescomponent_Component) != 0 )
            {
               WebComp_Rolescomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024312214080", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryuser.js", "?2024312214085", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAuthenticationtypename.Name = "vAUTHENTICATIONTYPENAME";
         cmbavAuthenticationtypename.WebTags = "";
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV11AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV11AuthenticationTypeName);
            AssignAttri("", false, "AV11AuthenticationTypeName", AV11AuthenticationTypeName);
         }
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", context.GetMessage( "Not Specified", ""), 0);
         cmbavGender.addItem("F", context.GetMessage( "Female", ""), 0);
         cmbavGender.addItem("M", context.GetMessage( "Male", ""), 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV26Gender = cmbavGender.getValidValue(AV26Gender);
            AssignAttri("", false, "AV26Gender", AV26Gender);
         }
         chkavIsactive.Name = "vISACTIVE";
         chkavIsactive.WebTags = "";
         chkavIsactive.Caption = "";
         AssignProp("", false, chkavIsactive_Internalname, "TitleCaption", chkavIsactive.Caption, true);
         chkavIsactive.CheckedValue = "false";
         AV28IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsActive));
         AssignAttri("", false, "AV28IsActive", AV28IsActive);
         chkavIsenabledinrepository.Name = "vISENABLEDINREPOSITORY";
         chkavIsenabledinrepository.WebTags = "";
         chkavIsenabledinrepository.Caption = "";
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "TitleCaption", chkavIsenabledinrepository.Caption, true);
         chkavIsenabledinrepository.CheckedValue = "false";
         AV30IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV30IsEnabledInRepository));
         AssignAttri("", false, "AV30IsEnabledInRepository", AV30IsEnabledInRepository);
         chkavDontreciveinformation.Name = "vDONTRECIVEINFORMATION";
         chkavDontreciveinformation.WebTags = "";
         chkavDontreciveinformation.Caption = "";
         AssignProp("", false, chkavDontreciveinformation_Internalname, "TitleCaption", chkavDontreciveinformation.Caption, true);
         chkavDontreciveinformation.CheckedValue = "false";
         AV17DontReciveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV17DontReciveInformation));
         AssignAttri("", false, "AV17DontReciveInformation", AV17DontReciveInformation);
         chkavCanotchangepassword.Name = "vCANOTCHANGEPASSWORD";
         chkavCanotchangepassword.WebTags = "";
         chkavCanotchangepassword.Caption = "";
         AssignProp("", false, chkavCanotchangepassword_Internalname, "TitleCaption", chkavCanotchangepassword.Caption, true);
         chkavCanotchangepassword.CheckedValue = "false";
         AV16CanotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV16CanotChangePassword));
         AssignAttri("", false, "AV16CanotChangePassword", AV16CanotChangePassword);
         chkavMustchangepassword.Name = "vMUSTCHANGEPASSWORD";
         chkavMustchangepassword.WebTags = "";
         chkavMustchangepassword.Caption = "";
         AssignProp("", false, chkavMustchangepassword_Internalname, "TitleCaption", chkavMustchangepassword.Caption, true);
         chkavMustchangepassword.CheckedValue = "false";
         AV37MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV37MustChangePassword));
         AssignAttri("", false, "AV37MustChangePassword", AV37MustChangePassword);
         chkavPasswordneverexpires.Name = "vPASSWORDNEVEREXPIRES";
         chkavPasswordneverexpires.WebTags = "";
         chkavPasswordneverexpires.Caption = "";
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "TitleCaption", chkavPasswordneverexpires.Caption, true);
         chkavPasswordneverexpires.CheckedValue = "false";
         AV45PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV45PasswordNeverExpires));
         AssignAttri("", false, "AV45PasswordNeverExpires", AV45PasswordNeverExpires);
         chkavIsblocked.Name = "vISBLOCKED";
         chkavIsblocked.WebTags = "";
         chkavIsblocked.Caption = "";
         AssignProp("", false, chkavIsblocked_Internalname, "TitleCaption", chkavIsblocked.Caption, true);
         chkavIsblocked.CheckedValue = "false";
         AV29IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV29IsBlocked));
         AssignAttri("", false, "AV29IsBlocked", AV29IsBlocked);
         cmbavSecuritypolicyid.Name = "vSECURITYPOLICYID";
         cmbavSecuritypolicyid.WebTags = "";
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV58SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58SecurityPolicyId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV58SecurityPolicyId), 9, 0));
         }
         chkavEnabletwofactorauthentication.Name = "vENABLETWOFACTORAUTHENTICATION";
         chkavEnabletwofactorauthentication.WebTags = "";
         chkavEnabletwofactorauthentication.Caption = "";
         AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "TitleCaption", chkavEnabletwofactorauthentication.Caption, true);
         chkavEnabletwofactorauthentication.CheckedValue = "false";
         AV19EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV19EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV19EnableTwoFactorAuthentication", AV19EnableTwoFactorAuthentication);
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
         edtavUserid_Internalname = "vUSERID";
         divTable_container_userid_Internalname = "TABLE_CONTAINER_USERID";
         edtavUsernamespace_Internalname = "vUSERNAMESPACE";
         divTable_container_usernamespace_Internalname = "TABLE_CONTAINER_USERNAMESPACE";
         cmbavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         divTable_container_authenticationtypename_Internalname = "TABLE_CONTAINER_AUTHENTICATIONTYPENAME";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavEmail_Internalname = "vEMAIL";
         divTable_container_email_Internalname = "TABLE_CONTAINER_EMAIL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divTable_container_firstname_Internalname = "TABLE_CONTAINER_FIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         divTable_container_lastname_Internalname = "TABLE_CONTAINER_LASTNAME";
         edtavPassword_Internalname = "vPASSWORD";
         divTable_container_password_Internalname = "TABLE_CONTAINER_PASSWORD";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divTable_container_passwordconf_Internalname = "TABLE_CONTAINER_PASSWORDCONF";
         lblTextblock_var_urlimage_Internalname = "TEXTBLOCK_VAR_URLIMAGE";
         edtavUrlimage_Internalname = "vURLIMAGE";
         imgavImage_Internalname = "vIMAGE";
         divTable_container_urlimagecellcontainer_Internalname = "TABLE_CONTAINER_URLIMAGECELLCONTAINER";
         divTable_container_urlimage_Internalname = "TABLE_CONTAINER_URLIMAGE";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divTable_container_birthday_Internalname = "TABLE_CONTAINER_BIRTHDAY";
         cmbavGender_Internalname = "vGENDER";
         divTable_container_gender_Internalname = "TABLE_CONTAINER_GENDER";
         edtavPhone_Internalname = "vPHONE";
         divTable_container_phone_Internalname = "TABLE_CONTAINER_PHONE";
         lblTextblock_var_isactive_Internalname = "TEXTBLOCK_VAR_ISACTIVE";
         chkavIsactive_Internalname = "vISACTIVE";
         edtavActivationdate_Internalname = "vACTIVATIONDATE";
         divTable_container_isactivecellcontainer_Internalname = "TABLE_CONTAINER_ISACTIVECELLCONTAINER";
         divTable_container_isactive_Internalname = "TABLE_CONTAINER_ISACTIVE";
         bttBtnsendactivationemail_Internalname = "BTNSENDACTIVATIONEMAIL";
         lblTextblock_var_isenabledinrepository_Internalname = "TEXTBLOCK_VAR_ISENABLEDINREPOSITORY";
         chkavIsenabledinrepository_Internalname = "vISENABLEDINREPOSITORY";
         bttEnable_Internalname = "ENABLE";
         divTable_container_isenabledinrepositorycellcontainer_Internalname = "TABLE_CONTAINER_ISENABLEDINREPOSITORYCELLCONTAINER";
         divTable_container_isenabledinrepository_Internalname = "TABLE_CONTAINER_ISENABLEDINREPOSITORY";
         lblLineseparatortitle_lineseparator_Internalname = "LINESEPARATORTITLE_LINESEPARATOR";
         divLineseparatorheader_lineseparator_Internalname = "LINESEPARATORHEADER_LINESEPARATOR";
         edtavExternalid_Internalname = "vEXTERNALID";
         divTable_container_externalid_Internalname = "TABLE_CONTAINER_EXTERNALID";
         lblTextblock_var_urlprofile_Internalname = "TEXTBLOCK_VAR_URLPROFILE";
         edtavUrlprofile_Internalname = "vURLPROFILE";
         bttOpenprofile_Internalname = "OPENPROFILE";
         divTable_container_urlprofilecellcontainer_Internalname = "TABLE_CONTAINER_URLPROFILECELLCONTAINER";
         divTable_container_urlprofile_Internalname = "TABLE_CONTAINER_URLPROFILE";
         chkavDontreciveinformation_Internalname = "vDONTRECIVEINFORMATION";
         divTable_container_dontreciveinformation_Internalname = "TABLE_CONTAINER_DONTRECIVEINFORMATION";
         chkavCanotchangepassword_Internalname = "vCANOTCHANGEPASSWORD";
         divTable_container_canotchangepassword_Internalname = "TABLE_CONTAINER_CANOTCHANGEPASSWORD";
         chkavMustchangepassword_Internalname = "vMUSTCHANGEPASSWORD";
         divTable_container_mustchangepassword_Internalname = "TABLE_CONTAINER_MUSTCHANGEPASSWORD";
         chkavPasswordneverexpires_Internalname = "vPASSWORDNEVEREXPIRES";
         divTable_container_passwordneverexpires_Internalname = "TABLE_CONTAINER_PASSWORDNEVEREXPIRES";
         chkavIsblocked_Internalname = "vISBLOCKED";
         divTable_container_isblocked_Internalname = "TABLE_CONTAINER_ISBLOCKED";
         cmbavSecuritypolicyid_Internalname = "vSECURITYPOLICYID";
         divTable_container_securitypolicyid_Internalname = "TABLE_CONTAINER_SECURITYPOLICYID";
         divLineseparatorcontent_lineseparator_Internalname = "LINESEPARATORCONTENT_LINESEPARATOR";
         divLineseparatorcontainer_lineseparator_Internalname = "LINESEPARATORCONTAINER_LINESEPARATOR";
         lblLineseparatortitle_tbl2fa_Internalname = "LINESEPARATORTITLE_TBL2FA";
         divLineseparatorheader_tbl2fa_Internalname = "LINESEPARATORHEADER_TBL2FA";
         chkavEnabletwofactorauthentication_Internalname = "vENABLETWOFACTORAUTHENTICATION";
         divTable_container_enabletwofactorauthentication_Internalname = "TABLE_CONTAINER_ENABLETWOFACTORAUTHENTICATION";
         divLineseparatorcontent_tbl2fa_Internalname = "LINESEPARATORCONTENT_TBL2FA";
         divLineseparatorcontainer_tbl2fa_Internalname = "LINESEPARATORCONTAINER_TBL2FA";
         lblLineseparatortitle_tblotp_Internalname = "LINESEPARATORTITLE_TBLOTP";
         divLineseparatorheader_tblotp_Internalname = "LINESEPARATORHEADER_TBLOTP";
         edtavOtpnumberlocked_Internalname = "vOTPNUMBERLOCKED";
         divTable_container_otpnumberlocked_Internalname = "TABLE_CONTAINER_OTPNUMBERLOCKED";
         edtavOtplastlockeddate_Internalname = "vOTPLASTLOCKEDDATE";
         divTable_container_otplastlockeddate_Internalname = "TABLE_CONTAINER_OTPLASTLOCKEDDATE";
         edtavOtpdailynumbercodes_Internalname = "vOTPDAILYNUMBERCODES";
         divTable_container_otpdailynumbercodes_Internalname = "TABLE_CONTAINER_OTPDAILYNUMBERCODES";
         edtavOtplastdaterequestcode_Internalname = "vOTPLASTDATEREQUESTCODE";
         divTable_container_otplastdaterequestcode_Internalname = "TABLE_CONTAINER_OTPLASTDATEREQUESTCODE";
         bttEnableauthenticator_Internalname = "ENABLEAUTHENTICATOR";
         bttUnblockotpcodes_Internalname = "UNBLOCKOTPCODES";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divLineseparatorcontent_tblotp_Internalname = "LINESEPARATORCONTENT_TBLOTP";
         divLineseparatorcontainer_tblotp_Internalname = "LINESEPARATORCONTAINER_TBLOTP";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions1_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS1";
         divResponsivetable_containernode_actions1_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS1";
         divAttributescontainertable_general_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERAL";
         divGeneral_content_Internalname = "GENERAL_CONTENT";
         General_Internalname = "GENERAL";
         divColumn_Internalname = "COLUMN";
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
         chkavEnabletwofactorauthentication.Caption = context.GetMessage( "K2BT_GAM_EnableTwoFactorAuthentication", "");
         chkavIsblocked.Caption = context.GetMessage( "K2BT_GAM_UserIsBlocked", "");
         chkavPasswordneverexpires.Caption = context.GetMessage( "K2BT_GAM_PasswordNeverExpire", "");
         chkavMustchangepassword.Caption = context.GetMessage( "K2BT_GAM_MustChangePassword", "");
         chkavCanotchangepassword.Caption = context.GetMessage( "K2BT_GAM_Cannotchangepassword", "");
         chkavDontreciveinformation.Caption = context.GetMessage( "K2BT_GAM_Don'twanttoreciveadditionalinformation", "");
         chkavIsenabledinrepository.Caption = context.GetMessage( "K2BT_GAM_IsEnabledInRepository", "");
         chkavIsactive.Caption = context.GetMessage( "K2BT_GAM_AccountIsActive", "");
         WebComp_Rolescomponent_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0261"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Rolescomponent_Visible), 5, 0), true);
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         bttUnblockotpcodes_Tooltiptext = "";
         bttUnblockotpcodes_Visible = 1;
         bttEnableauthenticator_Caption = context.GetMessage( "K2BT_GAM_EnableAuthenticator", "");
         bttEnableauthenticator_Visible = 1;
         edtavOtplastdaterequestcode_Jsonclick = "";
         edtavOtplastdaterequestcode_Enabled = 1;
         edtavOtpdailynumbercodes_Jsonclick = "";
         edtavOtpdailynumbercodes_Enabled = 1;
         edtavOtplastlockeddate_Jsonclick = "";
         edtavOtplastlockeddate_Enabled = 1;
         edtavOtpnumberlocked_Jsonclick = "";
         edtavOtpnumberlocked_Enabled = 1;
         divLineseparatorcontent_tblotp_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_tblotp_Visible = 1;
         divLineseparatorheader_tblotp_Class = "Section_LineSeparatorOpen";
         divLineseparatorcontainer_tblotp_Class = "Section";
         chkavEnabletwofactorauthentication.Enabled = 1;
         divLineseparatorcontent_tbl2fa_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_tbl2fa_Visible = 1;
         divLineseparatorheader_tbl2fa_Class = "Section_LineSeparatorOpen";
         divLineseparatorcontainer_tbl2fa_Class = "Section";
         cmbavSecuritypolicyid_Jsonclick = "";
         cmbavSecuritypolicyid.Enabled = 1;
         divTable_container_securitypolicyid_Visible = 1;
         chkavIsblocked.Enabled = 1;
         chkavPasswordneverexpires.Enabled = 1;
         chkavMustchangepassword.Enabled = 1;
         chkavCanotchangepassword.Enabled = 1;
         chkavDontreciveinformation.Enabled = 1;
         bttOpenprofile_Visible = 1;
         edtavUrlprofile_Jsonclick = "";
         edtavUrlprofile_Enabled = 1;
         edtavUrlprofile_Visible = 1;
         edtavExternalid_Jsonclick = "";
         edtavExternalid_Enabled = 1;
         divLineseparatorcontent_lineseparator_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lineseparator_Visible = 1;
         divLineseparatorheader_lineseparator_Class = "Section_LineSeparatorOpen";
         bttEnable_Caption = context.GetMessage( "K2BT_GAM_Enable", "");
         bttEnable_Enabled = 1;
         bttEnable_Visible = 1;
         chkavIsenabledinrepository.Enabled = 1;
         chkavIsenabledinrepository.Visible = 1;
         bttBtnsendactivationemail_Tooltiptext = "";
         bttBtnsendactivationemail_Visible = 1;
         edtavActivationdate_Jsonclick = "";
         edtavActivationdate_Enabled = 1;
         edtavActivationdate_Visible = 1;
         chkavIsactive.Enabled = 1;
         chkavIsactive.Visible = 1;
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         imgavImage_gximage = "";
         imgavImage_Visible = 1;
         edtavUrlimage_Jsonclick = "";
         edtavUrlimage_Enabled = 1;
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Visible = 1;
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         cmbavAuthenticationtypename_Jsonclick = "";
         cmbavAuthenticationtypename.Enabled = 1;
         cmbavAuthenticationtypename.Visible = 1;
         edtavUsernamespace_Jsonclick = "";
         edtavUsernamespace_Enabled = 1;
         edtavUserid_Jsonclick = "";
         edtavUserid_Enabled = 0;
         imgDelete_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         lblTitle_Caption = context.GetMessage( "K2BT_GAM_User", "");
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( 0);
         General_Title = context.GetMessage( "K2BT_General", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_User", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'cmbavAuthenticationtypename'},{av:'AV11AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV28IsActive',fld:'vISACTIVE',pic:''},{av:'AV30IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV17DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV16CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV37MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV45PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV29IsBlocked',fld:'vISBLOCKED',pic:''},{av:'AV19EnableTwoFactorAuthentication',fld:'vENABLETWOFACTORAUTHENTICATION',pic:''},{av:'AV32Language',fld:'vLANGUAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divTable_container_securitypolicyid_Visible',ctrl:'TABLE_CONTAINER_SECURITYPOLICYID',prop:'Visible'},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'BTNSENDACTIVATIONEMAIL',prop:'Tooltiptext'},{ctrl:'BTNSENDACTIVATIONEMAIL',prop:'Visible'},{ctrl:'UNBLOCKOTPCODES',prop:'Tooltiptext'},{ctrl:'UNBLOCKOTPCODES',prop:'Visible'},{av:'divLineseparatorcontainer_tbl2fa_Class',ctrl:'LINESEPARATORCONTAINER_TBL2FA',prop:'Class'},{av:'divLineseparatorcontainer_tblotp_Class',ctrl:'LINESEPARATORCONTAINER_TBLOTP',prop:'Class'},{av:'cmbavAuthenticationtypename'},{av:'AV11AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'edtavEmail_Enabled',ctrl:'vEMAIL',prop:'Enabled'},{av:'edtavFirstname_Enabled',ctrl:'vFIRSTNAME',prop:'Enabled'},{av:'edtavLastname_Enabled',ctrl:'vLASTNAME',prop:'Enabled'},{av:'edtavUrlimage_Enabled',ctrl:'vURLIMAGE',prop:'Enabled'},{av:'edtavUrlprofile_Enabled',ctrl:'vURLPROFILE',prop:'Enabled'},{av:'edtavExternalid_Enabled',ctrl:'vEXTERNALID',prop:'Enabled'},{av:'edtavBirthday_Enabled',ctrl:'vBIRTHDAY',prop:'Enabled'},{av:'cmbavGender'},{av:'chkavIsactive.Enabled',ctrl:'vISACTIVE',prop:'Enabled'},{av:'chkavDontreciveinformation.Enabled',ctrl:'vDONTRECIVEINFORMATION',prop:'Enabled'},{av:'chkavCanotchangepassword.Enabled',ctrl:'vCANOTCHANGEPASSWORD',prop:'Enabled'},{av:'chkavMustchangepassword.Enabled',ctrl:'vMUSTCHANGEPASSWORD',prop:'Enabled'},{av:'chkavIsblocked.Enabled',ctrl:'vISBLOCKED',prop:'Enabled'},{av:'chkavPasswordneverexpires.Enabled',ctrl:'vPASSWORDNEVEREXPIRES',prop:'Enabled'},{av:'cmbavSecuritypolicyid'},{av:'edtavPhone_Enabled',ctrl:'vPHONE',prop:'Enabled'},{av:'AV38Name',fld:'vNAME',pic:''},{av:'AV18Email',fld:'vEMAIL',pic:''},{av:'AV24FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV33LastName',fld:'vLASTNAME',pic:''},{av:'AV62URLImage',fld:'vURLIMAGE',pic:''},{av:'AV63URLProfile',fld:'vURLPROFILE',pic:''},{av:'AV22ExternalId',fld:'vEXTERNALID',pic:''},{av:'AV15Birthday',fld:'vBIRTHDAY',pic:''},{av:'AV26Gender',fld:'vGENDER',pic:''},{av:'AV28IsActive',fld:'vISACTIVE',pic:''},{av:'AV17DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV16CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV37MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV29IsBlocked',fld:'vISBLOCKED',pic:''},{av:'AV45PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'AV58SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'chkavIsenabledinrepository.Visible',ctrl:'vISENABLEDINREPOSITORY',prop:'Visible'},{ctrl:'ENABLE',prop:'Visible'},{ctrl:'ENABLE',prop:'Enabled'},{av:'lblTitle_Caption',ctrl:'TITLE',prop:'Caption'},{ctrl:'ROLESCOMPONENT',prop:'Visible'},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'},{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'AV8ActivationDate',fld:'vACTIVATIONDATE',pic:'99/99/9999 99:99'},{av:'AV30IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''},{av:'AV46Phone',fld:'vPHONE',pic:''},{av:'AV39OTPDailyNumberCodes',fld:'vOTPDAILYNUMBERCODES',pic:'ZZZ9'},{av:'AV40OTPLastDateRequestCode',fld:'vOTPLASTDATEREQUESTCODE',pic:''},{av:'AV7OTPLastLockedDate',fld:'vOTPLASTLOCKEDDATE',pic:'99/99/9999 99:99'},{av:'AV41OTPNumberLocked',fld:'vOTPNUMBERLOCKED',pic:'ZZZ9'},{av:'AV5Image',fld:'vIMAGE',pic:''},{av:'imgavImage_Visible',ctrl:'vIMAGE',prop:'Visible'},{ctrl:'OPENPROFILE',prop:'Visible'},{ctrl:'ENABLE',prop:'Caption'},{ctrl:'ROLESCOMPONENT'},{av:'edtavUrlprofile_Visible',ctrl:'vURLPROFILE',prop:'Visible'},{av:'AV67UserNameSpace',fld:'vUSERNAMESPACE',pic:''},{av:'chkavIsactive.Visible',ctrl:'vISACTIVE',prop:'Visible'},{av:'edtavActivationdate_Visible',ctrl:'vACTIVATIONDATE',prop:'Visible'},{av:'AV19EnableTwoFactorAuthentication',fld:'vENABLETWOFACTORAUTHENTICATION',pic:''},{ctrl:'ENABLEAUTHENTICATOR',prop:'Visible'},{ctrl:'ENABLEAUTHENTICATOR',prop:'Caption'},{av:'chkavEnabletwofactorauthentication.Enabled',ctrl:'vENABLETWOFACTORAUTHENTICATION',prop:'Enabled'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'},{av:'AV69IsLocalAuthentication',fld:'vISLOCALAUTHENTICATION',pic:''}]}");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID","{handler:'E18412',iparms:[{av:'AV32Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavAuthenticationtypename'},{av:'AV11AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID",",oparms:[{av:'AV69IsLocalAuthentication',fld:'vISLOCALAUTHENTICATION',pic:''},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21412',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'AV69IsLocalAuthentication',fld:'vISLOCALAUTHENTICATION',pic:''},{av:'AV42Password',fld:'vPASSWORD',pic:''},{av:'AV43PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV38Name',fld:'vNAME',pic:''},{av:'AV18Email',fld:'vEMAIL',pic:''},{av:'AV24FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV33LastName',fld:'vLASTNAME',pic:''},{av:'AV22ExternalId',fld:'vEXTERNALID',pic:''},{av:'AV15Birthday',fld:'vBIRTHDAY',pic:''},{av:'cmbavGender'},{av:'AV26Gender',fld:'vGENDER',pic:''},{av:'AV28IsActive',fld:'vISACTIVE',pic:''},{av:'AV62URLImage',fld:'vURLIMAGE',pic:''},{av:'AV63URLProfile',fld:'vURLPROFILE',pic:''},{av:'AV17DontReciveInformation',fld:'vDONTRECIVEINFORMATION',pic:''},{av:'AV16CanotChangePassword',fld:'vCANOTCHANGEPASSWORD',pic:''},{av:'AV37MustChangePassword',fld:'vMUSTCHANGEPASSWORD',pic:''},{av:'AV29IsBlocked',fld:'vISBLOCKED',pic:''},{av:'AV45PasswordNeverExpires',fld:'vPASSWORDNEVEREXPIRES',pic:''},{av:'cmbavSecuritypolicyid'},{av:'AV58SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'AV46Phone',fld:'vPHONE',pic:''},{av:'AV19EnableTwoFactorAuthentication',fld:'vENABLETWOFACTORAUTHENTICATION',pic:''},{av:'AV32Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavAuthenticationtypename'},{av:'AV11AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV42Password',fld:'vPASSWORD',pic:''},{av:'AV69IsLocalAuthentication',fld:'vISLOCALAUTHENTICATION',pic:''},{av:'edtavPassword_Visible',ctrl:'vPASSWORD',prop:'Visible'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'}]}");
         setEventMetadata("'E_ENABLE'","{handler:'E22412',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'AV30IsEnabledInRepository',fld:'vISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("'E_ENABLE'",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E17411',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("'E_UPDATE'","{handler:'E11411',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV66UserId',fld:'vUSERID',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV66UserId',fld:'vUSERID',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E12411',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV66UserId',fld:'vUSERID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV66UserId',fld:'vUSERID',pic:''}]}");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK","{handler:'E13411',iparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LINESEPARATOR.CLICK",",oparms:[{av:'divLineseparatorcontent_lineseparator_Visible',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Visible'},{av:'divLineseparatorcontent_lineseparator_Class',ctrl:'LINESEPARATORCONTENT_LINESEPARATOR',prop:'Class'},{av:'divLineseparatorheader_lineseparator_Class',ctrl:'LINESEPARATORHEADER_LINESEPARATOR',prop:'Class'}]}");
         setEventMetadata("'E_OPENPROFILE'","{handler:'E14411',iparms:[{av:'AV63URLProfile',fld:'vURLPROFILE',pic:''}]");
         setEventMetadata("'E_OPENPROFILE'",",oparms:[]}");
         setEventMetadata("'E_UNBLOCKOTPCODES'","{handler:'E23412',iparms:[{av:'AV66UserId',fld:'vUSERID',pic:''}]");
         setEventMetadata("'E_UNBLOCKOTPCODES'",",oparms:[]}");
         setEventMetadata("'E_BTNSENDACTIVATIONEMAIL'","{handler:'E24412',iparms:[{av:'AV66UserId',fld:'vUSERID',pic:''}]");
         setEventMetadata("'E_BTNSENDACTIVATIONEMAIL'",",oparms:[]}");
         setEventMetadata("LINESEPARATORTITLE_TBL2FA.CLICK","{handler:'E15411',iparms:[{av:'divLineseparatorcontent_tbl2fa_Visible',ctrl:'LINESEPARATORCONTENT_TBL2FA',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_TBL2FA.CLICK",",oparms:[{av:'divLineseparatorcontent_tbl2fa_Visible',ctrl:'LINESEPARATORCONTENT_TBL2FA',prop:'Visible'},{av:'divLineseparatorcontent_tbl2fa_Class',ctrl:'LINESEPARATORCONTENT_TBL2FA',prop:'Class'},{av:'divLineseparatorheader_tbl2fa_Class',ctrl:'LINESEPARATORHEADER_TBL2FA',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_TBLOTP.CLICK","{handler:'E16411',iparms:[{av:'divLineseparatorcontent_tblotp_Visible',ctrl:'LINESEPARATORCONTENT_TBLOTP',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_TBLOTP.CLICK",",oparms:[{av:'divLineseparatorcontent_tblotp_Visible',ctrl:'LINESEPARATORCONTENT_TBLOTP',prop:'Visible'},{av:'divLineseparatorcontent_tblotp_Class',ctrl:'LINESEPARATORCONTENT_TBLOTP',prop:'Class'},{av:'divLineseparatorheader_tblotp_Class',ctrl:'LINESEPARATORHEADER_TBLOTP',prop:'Class'}]}");
         setEventMetadata("'E_ENABLEAUTHENTICATOR'","{handler:'E25412',iparms:[{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("'E_ENABLEAUTHENTICATOR'",",oparms:[{ctrl:'ENABLEAUTHENTICATOR',prop:'Caption'},{av:'AV66UserId',fld:'vUSERID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]}");
         setEventMetadata("VALIDV_BIRTHDAY","{handler:'Validv_Birthday',iparms:[]");
         setEventMetadata("VALIDV_BIRTHDAY",",oparms:[]}");
         setEventMetadata("VALIDV_GENDER","{handler:'Validv_Gender',iparms:[]");
         setEventMetadata("VALIDV_GENDER",",oparms:[]}");
         setEventMetadata("VALIDV_ACTIVATIONDATE","{handler:'Validv_Activationdate',iparms:[]");
         setEventMetadata("VALIDV_ACTIVATIONDATE",",oparms:[]}");
         setEventMetadata("VALIDV_OTPLASTLOCKEDDATE","{handler:'Validv_Otplastlockeddate',iparms:[]");
         setEventMetadata("VALIDV_OTPLASTLOCKEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_OTPLASTDATEREQUESTCODE","{handler:'Validv_Otplastdaterequestcode',iparms:[]");
         setEventMetadata("VALIDV_OTPLASTDATEREQUESTCODE",",oparms:[]}");
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
         wcpOAV66UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV32Language = "";
         GXKey = "";
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
         AV67UserNameSpace = "";
         AV11AuthenticationTypeName = "";
         AV38Name = "";
         AV18Email = "";
         AV24FirstName = "";
         AV33LastName = "";
         AV42Password = "";
         AV43PasswordConf = "";
         lblTextblock_var_urlimage_Jsonclick = "";
         AV62URLImage = "";
         AV5Image = "";
         AV76Image_GXI = "";
         AV15Birthday = DateTime.MinValue;
         AV26Gender = "";
         AV46Phone = "";
         lblTextblock_var_isactive_Jsonclick = "";
         AV8ActivationDate = (DateTime)(DateTime.MinValue);
         bttBtnsendactivationemail_Jsonclick = "";
         lblTextblock_var_isenabledinrepository_Jsonclick = "";
         bttEnable_Jsonclick = "";
         lblLineseparatortitle_lineseparator_Jsonclick = "";
         AV22ExternalId = "";
         lblTextblock_var_urlprofile_Jsonclick = "";
         AV63URLProfile = "";
         bttOpenprofile_Jsonclick = "";
         lblLineseparatortitle_tbl2fa_Jsonclick = "";
         lblLineseparatortitle_tblotp_Jsonclick = "";
         AV7OTPLastLockedDate = (DateTime)(DateTime.MinValue);
         AV40OTPLastDateRequestCode = DateTime.MinValue;
         bttEnableauthenticator_Jsonclick = "";
         bttUnblockotpcodes_Jsonclick = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         WebComp_Rolescomponent_Component = "";
         OldRolescomponent = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV25GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV12AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV21Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13AuthenticationTypesIns = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV56SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV23FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV57SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV64User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV14AuthTypeId = "";
         AV10AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV20Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV35Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV65UserActivationKey = "";
         AV6LinkURL = "";
         AV36Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV70AuthenticationTypeSimple = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryuser__default(),
            new Object[][] {
            }
         );
         WebComp_Rolescomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavUsernamespace_Enabled = 0;
         edtavActivationdate_Enabled = 0;
         edtavOtpnumberlocked_Enabled = 0;
         edtavOtplastlockeddate_Enabled = 0;
         edtavOtpdailynumbercodes_Enabled = 0;
         edtavOtplastdaterequestcode_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV41OTPNumberLocked ;
      private short AV39OTPDailyNumberCodes ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divLineseparatorcontent_lineseparator_Visible ;
      private int divLineseparatorcontent_tbl2fa_Visible ;
      private int divLineseparatorcontent_tblotp_Visible ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int edtavUserid_Enabled ;
      private int edtavUsernamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavPassword_Visible ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Visible ;
      private int edtavPasswordconf_Enabled ;
      private int edtavUrlimage_Enabled ;
      private int imgavImage_Visible ;
      private int edtavBirthday_Enabled ;
      private int edtavPhone_Enabled ;
      private int edtavActivationdate_Visible ;
      private int edtavActivationdate_Enabled ;
      private int bttBtnsendactivationemail_Visible ;
      private int bttEnable_Visible ;
      private int bttEnable_Enabled ;
      private int edtavExternalid_Enabled ;
      private int edtavUrlprofile_Visible ;
      private int edtavUrlprofile_Enabled ;
      private int bttOpenprofile_Visible ;
      private int divTable_container_securitypolicyid_Visible ;
      private int AV58SecurityPolicyId ;
      private int edtavOtpnumberlocked_Enabled ;
      private int edtavOtplastlockeddate_Enabled ;
      private int edtavOtpdailynumbercodes_Enabled ;
      private int edtavOtplastdaterequestcode_Enabled ;
      private int bttEnableauthenticator_Visible ;
      private int bttUnblockotpcodes_Visible ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int WebComp_Rolescomponent_Visible ;
      private int AV74GXV1 ;
      private int AV75GXV2 ;
      private int AV77GXV3 ;
      private int AV78GXV4 ;
      private int AV79GXV5 ;
      private int AV80GXV6 ;
      private int AV81GXV7 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV66UserId ;
      private string wcpOGx_mode ;
      private string wcpOAV66UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV32Language ;
      private string GXKey ;
      private string General_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Caption ;
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
      private string divTable_container_userid_Internalname ;
      private string edtavUserid_Internalname ;
      private string edtavUserid_Jsonclick ;
      private string divTable_container_usernamespace_Internalname ;
      private string edtavUsernamespace_Internalname ;
      private string AV67UserNameSpace ;
      private string edtavUsernamespace_Jsonclick ;
      private string divTable_container_authenticationtypename_Internalname ;
      private string cmbavAuthenticationtypename_Internalname ;
      private string AV11AuthenticationTypeName ;
      private string cmbavAuthenticationtypename_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string divTable_container_email_Internalname ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divTable_container_firstname_Internalname ;
      private string edtavFirstname_Internalname ;
      private string AV24FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divTable_container_lastname_Internalname ;
      private string edtavLastname_Internalname ;
      private string AV33LastName ;
      private string edtavLastname_Jsonclick ;
      private string divTable_container_password_Internalname ;
      private string edtavPassword_Internalname ;
      private string AV42Password ;
      private string edtavPassword_Jsonclick ;
      private string divTable_container_passwordconf_Internalname ;
      private string edtavPasswordconf_Internalname ;
      private string AV43PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divTable_container_urlimage_Internalname ;
      private string lblTextblock_var_urlimage_Internalname ;
      private string lblTextblock_var_urlimage_Jsonclick ;
      private string divTable_container_urlimagecellcontainer_Internalname ;
      private string edtavUrlimage_Internalname ;
      private string edtavUrlimage_Jsonclick ;
      private string imgavImage_gximage ;
      private string imgavImage_Internalname ;
      private string divTable_container_birthday_Internalname ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Jsonclick ;
      private string divTable_container_gender_Internalname ;
      private string cmbavGender_Internalname ;
      private string AV26Gender ;
      private string cmbavGender_Jsonclick ;
      private string divTable_container_phone_Internalname ;
      private string edtavPhone_Internalname ;
      private string AV46Phone ;
      private string edtavPhone_Jsonclick ;
      private string divTable_container_isactive_Internalname ;
      private string lblTextblock_var_isactive_Internalname ;
      private string lblTextblock_var_isactive_Jsonclick ;
      private string divTable_container_isactivecellcontainer_Internalname ;
      private string chkavIsactive_Internalname ;
      private string edtavActivationdate_Internalname ;
      private string edtavActivationdate_Jsonclick ;
      private string bttBtnsendactivationemail_Internalname ;
      private string bttBtnsendactivationemail_Jsonclick ;
      private string bttBtnsendactivationemail_Tooltiptext ;
      private string divTable_container_isenabledinrepository_Internalname ;
      private string lblTextblock_var_isenabledinrepository_Internalname ;
      private string lblTextblock_var_isenabledinrepository_Jsonclick ;
      private string divTable_container_isenabledinrepositorycellcontainer_Internalname ;
      private string chkavIsenabledinrepository_Internalname ;
      private string bttEnable_Internalname ;
      private string bttEnable_Caption ;
      private string bttEnable_Jsonclick ;
      private string divLineseparatorcontainer_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Internalname ;
      private string divLineseparatorheader_lineseparator_Class ;
      private string lblLineseparatortitle_lineseparator_Internalname ;
      private string lblLineseparatortitle_lineseparator_Jsonclick ;
      private string divLineseparatorcontent_lineseparator_Internalname ;
      private string divLineseparatorcontent_lineseparator_Class ;
      private string divTable_container_externalid_Internalname ;
      private string edtavExternalid_Internalname ;
      private string edtavExternalid_Jsonclick ;
      private string divTable_container_urlprofile_Internalname ;
      private string lblTextblock_var_urlprofile_Internalname ;
      private string lblTextblock_var_urlprofile_Jsonclick ;
      private string divTable_container_urlprofilecellcontainer_Internalname ;
      private string edtavUrlprofile_Internalname ;
      private string edtavUrlprofile_Jsonclick ;
      private string bttOpenprofile_Internalname ;
      private string bttOpenprofile_Jsonclick ;
      private string divTable_container_dontreciveinformation_Internalname ;
      private string chkavDontreciveinformation_Internalname ;
      private string divTable_container_canotchangepassword_Internalname ;
      private string chkavCanotchangepassword_Internalname ;
      private string divTable_container_mustchangepassword_Internalname ;
      private string chkavMustchangepassword_Internalname ;
      private string divTable_container_passwordneverexpires_Internalname ;
      private string chkavPasswordneverexpires_Internalname ;
      private string divTable_container_isblocked_Internalname ;
      private string chkavIsblocked_Internalname ;
      private string divTable_container_securitypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Jsonclick ;
      private string divLineseparatorcontainer_tbl2fa_Internalname ;
      private string divLineseparatorcontainer_tbl2fa_Class ;
      private string divLineseparatorheader_tbl2fa_Internalname ;
      private string divLineseparatorheader_tbl2fa_Class ;
      private string lblLineseparatortitle_tbl2fa_Internalname ;
      private string lblLineseparatortitle_tbl2fa_Jsonclick ;
      private string divLineseparatorcontent_tbl2fa_Internalname ;
      private string divLineseparatorcontent_tbl2fa_Class ;
      private string divTable_container_enabletwofactorauthentication_Internalname ;
      private string chkavEnabletwofactorauthentication_Internalname ;
      private string divLineseparatorcontainer_tblotp_Internalname ;
      private string divLineseparatorcontainer_tblotp_Class ;
      private string divLineseparatorheader_tblotp_Internalname ;
      private string divLineseparatorheader_tblotp_Class ;
      private string lblLineseparatortitle_tblotp_Internalname ;
      private string lblLineseparatortitle_tblotp_Jsonclick ;
      private string divLineseparatorcontent_tblotp_Internalname ;
      private string divLineseparatorcontent_tblotp_Class ;
      private string divTable_container_otpnumberlocked_Internalname ;
      private string edtavOtpnumberlocked_Internalname ;
      private string edtavOtpnumberlocked_Jsonclick ;
      private string divTable_container_otplastlockeddate_Internalname ;
      private string edtavOtplastlockeddate_Internalname ;
      private string edtavOtplastlockeddate_Jsonclick ;
      private string divTable_container_otpdailynumbercodes_Internalname ;
      private string edtavOtpdailynumbercodes_Internalname ;
      private string edtavOtpdailynumbercodes_Jsonclick ;
      private string divTable_container_otplastdaterequestcode_Internalname ;
      private string edtavOtplastdaterequestcode_Internalname ;
      private string edtavOtplastdaterequestcode_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttEnableauthenticator_Internalname ;
      private string bttEnableauthenticator_Caption ;
      private string bttEnableauthenticator_Jsonclick ;
      private string bttUnblockotpcodes_Internalname ;
      private string bttUnblockotpcodes_Jsonclick ;
      private string bttUnblockotpcodes_Tooltiptext ;
      private string divResponsivetable_containernode_actions1_Internalname ;
      private string divActionscontainertableleft_actions1_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Caption ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divColumn1_Internalname ;
      private string WebComp_Rolescomponent_Component ;
      private string OldRolescomponent ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV14AuthTypeId ;
      private string AV65UserActivationKey ;
      private DateTime AV8ActivationDate ;
      private DateTime AV7OTPLastLockedDate ;
      private DateTime AV15Birthday ;
      private DateTime AV40OTPLastDateRequestCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV69IsLocalAuthentication ;
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool wbLoad ;
      private bool AV5Image_IsBlob ;
      private bool AV28IsActive ;
      private bool AV30IsEnabledInRepository ;
      private bool AV17DontReciveInformation ;
      private bool AV16CanotChangePassword ;
      private bool AV37MustChangePassword ;
      private bool AV45PasswordNeverExpires ;
      private bool AV29IsBlocked ;
      private bool AV19EnableTwoFactorAuthentication ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Rolescomponent ;
      private bool AV31isOK ;
      private bool AV44PasswordIsOK ;
      private string AV38Name ;
      private string AV18Email ;
      private string AV62URLImage ;
      private string AV76Image_GXI ;
      private string AV22ExternalId ;
      private string AV63URLProfile ;
      private string AV6LinkURL ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private string AV5Image ;
      private GXWebComponent WebComp_Rolescomponent ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV10AuthenticationType ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_UserId ;
      private GXCombobox cmbavAuthenticationtypename ;
      private GXCombobox cmbavGender ;
      private GXCheckbox chkavIsactive ;
      private GXCheckbox chkavIsenabledinrepository ;
      private GXCheckbox chkavDontreciveinformation ;
      private GXCheckbox chkavCanotchangepassword ;
      private GXCheckbox chkavMustchangepassword ;
      private GXCheckbox chkavPasswordneverexpires ;
      private GXCheckbox chkavIsblocked ;
      private GXCombobox cmbavSecuritypolicyid ;
      private GXCheckbox chkavEnabletwofactorauthentication ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV12AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV56SecurityPolicies ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV36Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV20Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV13AuthenticationTypesIns ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV70AuthenticationTypeSimple ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV23FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV25GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV47Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV64User ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV57SecurityPolicy ;
      private GeneXus.Utils.SdtMessages_Message AV35Message ;
   }

   public class entryuser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class entryuser__default : DataStoreHelperBase, IDataStoreHelper
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
