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
   public class entryrepository : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryrepository( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entryrepository( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref int aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV28Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV28Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavUsecurrentrepositorasmasterauthentication = new GXCheckbox();
         cmbavGeneratesessionstatistics = new GXCombobox();
         chkavUpdateconnectionfile = new GXCheckbox();
         chkavIsgamadminaccessrepository = new GXCheckbox();
         chkavCreategamapplication = new GXCheckbox();
         cmbavCopyfromrepositoryid = new GXCombobox();
         chkavCopyroles = new GXCheckbox();
         chkavCopysecuritypolicies = new GXCheckbox();
         chkavCopyapplication = new GXCheckbox();
         chkavCopyapplicationrolepermissions = new GXCheckbox();
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
                  AV28Id = (int)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV28Id", StringUtil.LTrimStr( (decimal)(AV28Id), 9, 0));
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
         PA4O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryrepository.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV28Id,9,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vALLOWOAUTHACCESS", AV44AllowOauthAccess);
         GxWebStd.gx_hidden_field( context, "gxhash_vALLOWOAUTHACCESS", GetSecureSignedToken( "", AV44AllowOauthAccess, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Id), 9, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOWOAUTHACCESS", AV44AllowOauthAccess);
         GxWebStd.gx_hidden_field( context, "gxhash_vALLOWOAUTHACCESS", GetSecureSignedToken( "", AV44AllowOauthAccess, context));
         GxWebStd.gx_hidden_field( context, "GENERAL_Title", StringUtil.RTrim( General_Title));
         GxWebStd.gx_hidden_field( context, "GENERAL_Collapsible", StringUtil.BoolToStr( General_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERAL_Open", StringUtil.BoolToStr( General_Open));
         GxWebStd.gx_hidden_field( context, "GENERAL_Showborders", StringUtil.BoolToStr( General_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERAL_Containseditableform", StringUtil.BoolToStr( General_Containseditableform));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Title", StringUtil.RTrim( Responsivetable_mainattributes_copyapplicationtable_Title));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Collapsible));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Open));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Showborders));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Containseditableform));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Visible));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4O2( ) ;
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
         return formatLink("k2bfsg.entryrepository.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV28Id,9,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryRepository" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entry Repository" ;
      }

      protected void WB4O0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Repository", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryRepository.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgUpdate_gximage, "")==0) ? "GX_Image_K2BActionUpdate_Class" : "GX_Image_"+imgUpdate_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114o1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryRepository.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124o1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGuid_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV26GUID), StringUtil.RTrim( context.localUtil.Format( AV26GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavGuid_Visible, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV31Name), StringUtil.RTrim( context.localUtil.Format( AV31Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_description_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDescription_Internalname, "Description", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDescription_Internalname, StringUtil.RTrim( AV23Description), StringUtil.RTrim( context.localUtil.Format( AV23Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDescription_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDescription_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_usecurrentrepositorasmasterauthentication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavUsecurrentrepositorasmasterauthentication.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUsecurrentrepositorasmasterauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUsecurrentrepositorasmasterauthentication_Internalname, "Use current repository as master authentication?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUsecurrentrepositorasmasterauthentication_Internalname, StringUtil.BoolToStr( AV45UseCurrentRepositorAsMasterAuthentication), "", "Use current repository as master authentication?", chkavUsecurrentrepositorasmasterauthentication.Visible, chkavUsecurrentrepositorasmasterauthentication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_namespace_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNamespace_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavNamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNamespace_Internalname, "Namespace", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNamespace_Internalname, StringUtil.RTrim( AV32NameSpace), StringUtil.RTrim( context.localUtil.Format( AV32NameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNamespace_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavNamespace_Visible, edtavNamespace_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_generatesessionstatistics_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavGeneratesessionstatistics_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGeneratesessionstatistics_Internalname, "Generate session statistics", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGeneratesessionstatistics, cmbavGeneratesessionstatistics_Internalname, StringUtil.RTrim( AV25GenerateSessionStatistics), 1, cmbavGeneratesessionstatistics_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGeneratesessionstatistics.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_K2BFSG\\EntryRepository.htm");
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV25GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", (string)(cmbavGeneratesessionstatistics.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpConnection_Internalname, "Connection", 1, 0, "px", 0, "px", grpConnection_Class, "", "HLP_K2BFSG\\EntryRepository.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_connection_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_connectionusername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConnectionusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionusername_Internalname, "Connection user name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionusername_Internalname, StringUtil.RTrim( AV15ConnectionUserName), StringUtil.RTrim( context.localUtil.Format( AV15ConnectionUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionusername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConnectionusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_connectionuserpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionuserpassword_Internalname, "Connection user password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavConnectionuserpassword_Internalname, StringUtil.RTrim( AV16ConnectionUserPassword), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", 0, 1, edtavConnectionuserpassword_Enabled, 1, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "K2BFSG\\RepositoryPassword", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_confconnectionuserpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConfconnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfconnectionuserpassword_Internalname, "Connection user password (confirmation)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavConfconnectionuserpassword_Internalname, StringUtil.RTrim( AV14ConfConnectionUserPassword), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtavConfconnectionuserpassword_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "K2BFSG\\RepositoryPassword", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_authenticationmasterauthtypename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAuthenticationmasterauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthenticationmasterauthtypename_Internalname, "Master authentication type name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthenticationmasterauthtypename_Internalname, StringUtil.RTrim( AV46AuthenticationMasterAuthTypeName), StringUtil.RTrim( context.localUtil.Format( AV46AuthenticationMasterAuthTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthenticationmasterauthtypename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAuthenticationmasterauthtypename_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_administratorusername_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAdministratorusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratorusername_Internalname, edtavAdministratorusername_Caption, "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratorusername_Internalname, StringUtil.RTrim( AV11AdministratorUserName), StringUtil.RTrim( context.localUtil.Format( AV11AdministratorUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratorusername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavAdministratorusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "start", true, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_administratoruserpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavAdministratoruserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAdministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratoruserpassword_Internalname, "Administrator user password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavAdministratoruserpassword_Internalname, StringUtil.RTrim( AV12AdministratorUserPassword), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", 0, edtavAdministratoruserpassword_Visible, edtavAdministratoruserpassword_Enabled, 1, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "K2BFSG\\RepositoryPassword", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_confadministratoruserpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavConfadministratoruserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConfadministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfadministratoruserpassword_Internalname, "Administrator user password (confirmation)", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavConfadministratoruserpassword_Internalname, StringUtil.RTrim( AV13ConfAdministratorUserPassword), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", 0, edtavConfadministratoruserpassword_Visible, edtavConfadministratoruserpassword_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "K2BFSG\\RepositoryPassword", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\EntryRepository.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_updateconnectionfile_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavUpdateconnectionfile.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavUpdateconnectionfile_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUpdateconnectionfile_Internalname, "Update connection.gam file", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUpdateconnectionfile_Internalname, StringUtil.BoolToStr( AV40UpdateConnectionFile), "", "Update connection.gam file", chkavUpdateconnectionfile.Visible, chkavUpdateconnectionfile.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(119, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,119);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_isgamadminaccessrepository_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavIsgamadminaccessrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsgamadminaccessrepository_Internalname, "Enable gamadmin user to access the new repository?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsgamadminaccessrepository_Internalname, StringUtil.BoolToStr( AV29isGAMAdminAccessRepository), "", "Enable gamadmin user to access the new repository?", 1, chkavIsgamadminaccessrepository.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(125, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,125);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_creategamapplication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCreategamapplication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCreategamapplication_Internalname, "Create GAM Backend application?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCreategamapplication_Internalname, StringUtil.BoolToStr( AV22CreateGAMApplication), "", "Create GAM Backend application?", 1, chkavCreategamapplication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucResponsivetable_mainattributes_copyapplicationtable.SetProperty("Title", Responsivetable_mainattributes_copyapplicationtable_Title);
            ucResponsivetable_mainattributes_copyapplicationtable.SetProperty("Collapsible", Responsivetable_mainattributes_copyapplicationtable_Collapsible);
            ucResponsivetable_mainattributes_copyapplicationtable.SetProperty("Open", Responsivetable_mainattributes_copyapplicationtable_Open);
            ucResponsivetable_mainattributes_copyapplicationtable.SetProperty("ShowBorders", Responsivetable_mainattributes_copyapplicationtable_Showborders);
            ucResponsivetable_mainattributes_copyapplicationtable.SetProperty("ContainsEditableForm", Responsivetable_mainattributes_copyapplicationtable_Containseditableform);
            ucResponsivetable_mainattributes_copyapplicationtable.Render(context, "k2bt_component", Responsivetable_mainattributes_copyapplicationtable_Internalname, "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLEContainer"+"Responsivetable_mainattributes_copyapplicationtable_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_copyapplicationtable_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_responsivetable_mainattributes_copyapplicationtable_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_copyfromrepositoryid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavCopyfromrepositoryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCopyfromrepositoryid_Internalname, "Copy from repository ID.", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCopyfromrepositoryid, cmbavCopyfromrepositoryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19CopyFromRepositoryId), 9, 0)), 1, cmbavCopyfromrepositoryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavCopyfromrepositoryid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "", true, 0, "HLP_K2BFSG\\EntryRepository.htm");
            cmbavCopyfromrepositoryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19CopyFromRepositoryId), 9, 0));
            AssignProp("", false, cmbavCopyfromrepositoryid_Internalname, "Values", (string)(cmbavCopyfromrepositoryid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_copyroles_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCopyroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyroles_Internalname, "Copy roles?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyroles_Internalname, StringUtil.BoolToStr( AV20CopyRoles), "", "Copy roles?", 1, chkavCopyroles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,151);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_administratorroleid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavAdministratorroleid_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavAdministratorroleid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratorroleid_Internalname, "Administrator Role Id.", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratorroleid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10AdministratorRoleId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavAdministratorroleid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10AdministratorRoleId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10AdministratorRoleId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratorroleid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavAdministratorroleid_Visible, edtavAdministratorroleid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_copysecuritypolicies_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCopysecuritypolicies_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopysecuritypolicies_Internalname, "Copy security policies?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopysecuritypolicies_Internalname, StringUtil.BoolToStr( AV21CopySecurityPolicies), "", "Copy security policies?", 1, chkavCopysecuritypolicies.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(163, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,163);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_copyapplication_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCopyapplication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyapplication_Internalname, "Copy application? (Menus and permissions)", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyapplication_Internalname, StringUtil.BoolToStr( AV17CopyApplication), "", "Copy application? (Menus and permissions)", 1, chkavCopyapplication.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,169);\"");
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
            GxWebStd.gx_div_start( context, divTable_container_copyfromapplicationid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavCopyfromapplicationid_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavCopyfromapplicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCopyfromapplicationid_Internalname, "Copy from application ID.", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCopyfromapplicationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18CopyFromApplicationId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCopyfromapplicationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18CopyFromApplicationId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18CopyFromApplicationId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,175);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCopyfromapplicationid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavCopyfromapplicationid_Visible, edtavCopyfromapplicationid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_K2BFSG\\EntryRepository.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_copyapplicationrolepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavCopyapplicationrolepermissions.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavCopyapplicationrolepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyapplicationrolepermissions_Internalname, "Copy roles permissions?", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyapplicationrolepermissions_Internalname, StringUtil.BoolToStr( AV42CopyApplicationRolePermissions), "", "Copy roles permissions?", chkavCopyapplicationrolepermissions.Visible, chkavCopyapplicationrolepermissions.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,181);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryRepository.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancel", bttCancel_Jsonclick, 5, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryRepository.htm");
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

      protected void START4O2( )
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
         Form.Meta.addItem("description", "Entry Repository", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4O0( ) ;
      }

      protected void WS4O2( )
      {
         START4O2( ) ;
         EVT4O2( ) ;
      }

      protected void EVT4O2( )
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
                              E134O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E144O2 ();
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
                                    E154O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Cancel' */
                              E174O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E184O2 ();
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

      protected void WE4O2( )
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

      protected void PA4O2( )
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
         AV45UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV45UseCurrentRepositorAsMasterAuthentication));
         AssignAttri("", false, "AV45UseCurrentRepositorAsMasterAuthentication", AV45UseCurrentRepositorAsMasterAuthentication);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV25GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV25GenerateSessionStatistics);
            AssignAttri("", false, "AV25GenerateSessionStatistics", AV25GenerateSessionStatistics);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV25GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         }
         AV40UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UpdateConnectionFile));
         AssignAttri("", false, "AV40UpdateConnectionFile", AV40UpdateConnectionFile);
         AV29isGAMAdminAccessRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV29isGAMAdminAccessRepository));
         AssignAttri("", false, "AV29isGAMAdminAccessRepository", AV29isGAMAdminAccessRepository);
         AV22CreateGAMApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV22CreateGAMApplication));
         AssignAttri("", false, "AV22CreateGAMApplication", AV22CreateGAMApplication);
         if ( cmbavCopyfromrepositoryid.ItemCount > 0 )
         {
            AV19CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cmbavCopyfromrepositoryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19CopyFromRepositoryId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV19CopyFromRepositoryId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCopyfromrepositoryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19CopyFromRepositoryId), 9, 0));
            AssignProp("", false, cmbavCopyfromrepositoryid_Internalname, "Values", cmbavCopyfromrepositoryid.ToJavascriptSource(), true);
         }
         AV20CopyRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV20CopyRoles));
         AssignAttri("", false, "AV20CopyRoles", AV20CopyRoles);
         AV21CopySecurityPolicies = StringUtil.StrToBool( StringUtil.BoolToStr( AV21CopySecurityPolicies));
         AssignAttri("", false, "AV21CopySecurityPolicies", AV21CopySecurityPolicies);
         AV17CopyApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17CopyApplication));
         AssignAttri("", false, "AV17CopyApplication", AV17CopyApplication);
         AV42CopyApplicationRolePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV42CopyApplicationRolePermissions));
         AssignAttri("", false, "AV42CopyApplicationRolePermissions", AV42CopyApplicationRolePermissions);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E144O2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E184O2 ();
            WB4O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4O2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOWOAUTHACCESS", AV44AllowOauthAccess);
         GxWebStd.gx_hidden_field( context, "gxhash_vALLOWOAUTHACCESS", GetSecureSignedToken( "", AV44AllowOauthAccess, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV28Id = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vID"), ".", ","), 18, MidpointRounding.ToEven));
            General_Title = cgiGet( "GENERAL_Title");
            General_Collapsible = StringUtil.StrToBool( cgiGet( "GENERAL_Collapsible"));
            General_Open = StringUtil.StrToBool( cgiGet( "GENERAL_Open"));
            General_Showborders = StringUtil.StrToBool( cgiGet( "GENERAL_Showborders"));
            General_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERAL_Containseditableform"));
            Responsivetable_mainattributes_copyapplicationtable_Title = cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Title");
            Responsivetable_mainattributes_copyapplicationtable_Collapsible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Collapsible"));
            Responsivetable_mainattributes_copyapplicationtable_Open = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Open"));
            Responsivetable_mainattributes_copyapplicationtable_Showborders = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Showborders"));
            Responsivetable_mainattributes_copyapplicationtable_Containseditableform = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Containseditableform"));
            Responsivetable_mainattributes_copyapplicationtable_Visible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_Visible"));
            /* Read variables values. */
            AV26GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV26GUID", AV26GUID);
            AV31Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV31Name", AV31Name);
            AV23Description = cgiGet( edtavDescription_Internalname);
            AssignAttri("", false, "AV23Description", AV23Description);
            AV45UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( cgiGet( chkavUsecurrentrepositorasmasterauthentication_Internalname));
            AssignAttri("", false, "AV45UseCurrentRepositorAsMasterAuthentication", AV45UseCurrentRepositorAsMasterAuthentication);
            AV32NameSpace = cgiGet( edtavNamespace_Internalname);
            AssignAttri("", false, "AV32NameSpace", AV32NameSpace);
            cmbavGeneratesessionstatistics.CurrentValue = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AV25GenerateSessionStatistics = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AssignAttri("", false, "AV25GenerateSessionStatistics", AV25GenerateSessionStatistics);
            AV15ConnectionUserName = cgiGet( edtavConnectionusername_Internalname);
            AssignAttri("", false, "AV15ConnectionUserName", AV15ConnectionUserName);
            AV16ConnectionUserPassword = cgiGet( edtavConnectionuserpassword_Internalname);
            AssignAttri("", false, "AV16ConnectionUserPassword", AV16ConnectionUserPassword);
            AV14ConfConnectionUserPassword = cgiGet( edtavConfconnectionuserpassword_Internalname);
            AssignAttri("", false, "AV14ConfConnectionUserPassword", AV14ConfConnectionUserPassword);
            AV46AuthenticationMasterAuthTypeName = cgiGet( edtavAuthenticationmasterauthtypename_Internalname);
            AssignAttri("", false, "AV46AuthenticationMasterAuthTypeName", AV46AuthenticationMasterAuthTypeName);
            AV11AdministratorUserName = cgiGet( edtavAdministratorusername_Internalname);
            AssignAttri("", false, "AV11AdministratorUserName", AV11AdministratorUserName);
            AV12AdministratorUserPassword = cgiGet( edtavAdministratoruserpassword_Internalname);
            AssignAttri("", false, "AV12AdministratorUserPassword", AV12AdministratorUserPassword);
            AV13ConfAdministratorUserPassword = cgiGet( edtavConfadministratoruserpassword_Internalname);
            AssignAttri("", false, "AV13ConfAdministratorUserPassword", AV13ConfAdministratorUserPassword);
            AV40UpdateConnectionFile = StringUtil.StrToBool( cgiGet( chkavUpdateconnectionfile_Internalname));
            AssignAttri("", false, "AV40UpdateConnectionFile", AV40UpdateConnectionFile);
            AV29isGAMAdminAccessRepository = StringUtil.StrToBool( cgiGet( chkavIsgamadminaccessrepository_Internalname));
            AssignAttri("", false, "AV29isGAMAdminAccessRepository", AV29isGAMAdminAccessRepository);
            AV22CreateGAMApplication = StringUtil.StrToBool( cgiGet( chkavCreategamapplication_Internalname));
            AssignAttri("", false, "AV22CreateGAMApplication", AV22CreateGAMApplication);
            cmbavCopyfromrepositoryid.CurrentValue = cgiGet( cmbavCopyfromrepositoryid_Internalname);
            AV19CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavCopyfromrepositoryid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV19CopyFromRepositoryId), 9, 0));
            AV20CopyRoles = StringUtil.StrToBool( cgiGet( chkavCopyroles_Internalname));
            AssignAttri("", false, "AV20CopyRoles", AV20CopyRoles);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vADMINISTRATORROLEID");
               GX_FocusControl = edtavAdministratorroleid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10AdministratorRoleId = 0;
               AssignAttri("", false, "AV10AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV10AdministratorRoleId), 12, 0));
            }
            else
            {
               AV10AdministratorRoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV10AdministratorRoleId), 12, 0));
            }
            AV21CopySecurityPolicies = StringUtil.StrToBool( cgiGet( chkavCopysecuritypolicies_Internalname));
            AssignAttri("", false, "AV21CopySecurityPolicies", AV21CopySecurityPolicies);
            AV17CopyApplication = StringUtil.StrToBool( cgiGet( chkavCopyapplication_Internalname));
            AssignAttri("", false, "AV17CopyApplication", AV17CopyApplication);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPYFROMAPPLICATIONID");
               GX_FocusControl = edtavCopyfromapplicationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18CopyFromApplicationId = 0;
               AssignAttri("", false, "AV18CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV18CopyFromApplicationId), 12, 0));
            }
            else
            {
               AV18CopyFromApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV18CopyFromApplicationId), 12, 0));
            }
            AV42CopyApplicationRolePermissions = StringUtil.StrToBool( cgiGet( chkavCopyapplicationrolepermissions_Internalname));
            AssignAttri("", false, "AV42CopyApplicationRolePermissions", AV42CopyApplicationRolePermissions);
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
         E134O2 ();
         if (returnInSub) return;
      }

      protected void E134O2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E144O2( )
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
         imgUpdate_Tooltiptext = "Update";
         AssignProp("", false, imgUpdate_Internalname, "Tooltiptext", imgUpdate_Tooltiptext, true);
         imgDelete_gximage = "K2BActionDelete";
         AssignProp("", false, imgDelete_Internalname, "gximage", imgDelete_gximage, true);
         imgDelete_Bitmap = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, imgDelete_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgDelete_Bitmap)), true);
         AssignProp("", false, imgDelete_Internalname, "SrcSet", context.GetImageSrcSet( imgDelete_Bitmap), true);
         imgDelete_Tooltiptext = "Delete";
         AssignProp("", false, imgDelete_Internalname, "Tooltiptext", imgDelete_Tooltiptext, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV35Repository.load( AV28Id);
            if ( AV35Repository.success() )
            {
               AV26GUID = AV35Repository.gxTpr_Guid;
               AssignAttri("", false, "AV26GUID", AV26GUID);
               AV31Name = AV35Repository.gxTpr_Name;
               AssignAttri("", false, "AV31Name", AV31Name);
               AV32NameSpace = AV35Repository.gxTpr_Namespace;
               AssignAttri("", false, "AV32NameSpace", AV32NameSpace);
               AV23Description = AV35Repository.gxTpr_Description;
               AssignAttri("", false, "AV23Description", AV23Description);
               AV25GenerateSessionStatistics = AV35Repository.gxTpr_Generatesessionstatistics;
               AssignAttri("", false, "AV25GenerateSessionStatistics", AV25GenerateSessionStatistics);
               edtavGuid_Enabled = 0;
               AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               edtavNamespace_Enabled = 0;
               AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
               edtavDescription_Enabled = 0;
               AssignProp("", false, edtavDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescription_Enabled), 5, 0), true);
               edtavAdministratorusername_Enabled = 0;
               AssignProp("", false, edtavAdministratorusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratorusername_Enabled), 5, 0), true);
               edtavAdministratoruserpassword_Enabled = 0;
               AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Enabled), 5, 0), true);
               cmbavGeneratesessionstatistics.Enabled = 0;
               AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGeneratesessionstatistics.Enabled), 5, 0), true);
               edtavConnectionusername_Enabled = 0;
               AssignProp("", false, edtavConnectionusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionusername_Enabled), 5, 0), true);
               edtavConnectionuserpassword_Enabled = 0;
               AssignProp("", false, edtavConnectionuserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionuserpassword_Enabled), 5, 0), true);
               grpConnection_Class = "Group_Invisible";
               AssignProp("", false, grpConnection_Internalname, "Class", grpConnection_Class, true);
               chkavUpdateconnectionfile.Visible = 0;
               AssignProp("", false, chkavUpdateconnectionfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUpdateconnectionfile.Visible), 5, 0), true);
               bttConfirm_Caption = "Delete";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else
            {
               AV24Errors = AV35Repository.geterrors();
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S182 ();
               if (returnInSub) return;
            }
         }
         else
         {
            edtavGuid_Visible = 0;
            AssignProp("", false, edtavGuid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGuid_Visible), 5, 0), true);
         }
         Responsivetable_mainattributes_copyapplicationtable_Visible = false;
         ucResponsivetable_mainattributes_copyapplicationtable.SendProperty(context, "", false, Responsivetable_mainattributes_copyapplicationtable_Internalname, "Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Visible));
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV25GenerateSessionStatistics = "Minimum";
            AssignAttri("", false, "AV25GenerateSessionStatistics", AV25GenerateSessionStatistics);
            AV22CreateGAMApplication = true;
            AssignAttri("", false, "AV22CreateGAMApplication", AV22CreateGAMApplication);
            AV40UpdateConnectionFile = true;
            AssignAttri("", false, "AV40UpdateConnectionFile", AV40UpdateConnectionFile);
            Responsivetable_mainattributes_copyapplicationtable_Visible = true;
            ucResponsivetable_mainattributes_copyapplicationtable.SendProperty(context, "", false, Responsivetable_mainattributes_copyapplicationtable_Internalname, "Visible", StringUtil.BoolToStr( Responsivetable_mainattributes_copyapplicationtable_Visible));
            AV34Repositories = new GeneXus.Programs.genexussecurity.SdtGAM(context).getallrepositories(AV43RepositoryFilter, out  AV24Errors);
            cmbavCopyfromrepositoryid.removeAllItems();
            cmbavCopyfromrepositoryid.addItem("0", "(No copying)", 0);
            if ( AV24Errors.Count == 0 )
            {
               AV49GXV1 = 1;
               while ( AV49GXV1 <= AV34Repositories.Count )
               {
                  AV33Repo = ((GeneXus.Programs.genexussecurity.SdtGAMRepository)AV34Repositories.Item(AV49GXV1));
                  cmbavCopyfromrepositoryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV33Repo.gxTpr_Id), 9, 0)), StringUtil.Str( (decimal)(AV33Repo.gxTpr_Id), 9, 0)+" - "+StringUtil.Trim( AV33Repo.gxTpr_Name), 0);
                  AV49GXV1 = (int)(AV49GXV1+1);
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S182 ();
               if (returnInSub) return;
            }
            AV19CopyFromRepositoryId = 2;
            AssignAttri("", false, "AV19CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV19CopyFromRepositoryId), 9, 0));
            AV20CopyRoles = true;
            AssignAttri("", false, "AV20CopyRoles", AV20CopyRoles);
            AV10AdministratorRoleId = 2;
            AssignAttri("", false, "AV10AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV10AdministratorRoleId), 12, 0));
            AV21CopySecurityPolicies = true;
            AssignAttri("", false, "AV21CopySecurityPolicies", AV21CopySecurityPolicies);
            AV17CopyApplication = true;
            AssignAttri("", false, "AV17CopyApplication", AV17CopyApplication);
            AV18CopyFromApplicationId = 2;
            AssignAttri("", false, "AV18CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV18CopyFromApplicationId), 12, 0));
            AV42CopyApplicationRolePermissions = true;
            AssignAttri("", false, "AV42CopyApplicationRolePermissions", AV42CopyApplicationRolePermissions);
         }
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
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
               bttConfirm_Caption = "Delete";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               bttConfirm_Caption = "Update";
               AssignProp("", false, bttConfirm_Internalname, "Caption", bttConfirm_Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               bttConfirm_Caption = "Insert";
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

      protected void S142( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV28Id,9,0))}, new string[] {"Id"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.entryrepository.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV28Id,9,0))}, new string[] {"Mode","Id"}) );
         context.wjLocDisableFrm = 1;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E154O2 ();
         if (returnInSub) return;
      }

      protected void E154O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36RepositoryCreate", AV36RepositoryCreate);
      }

      protected void S162( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV35Repository.load( AV28Id);
         AV7isOK = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Trim( AV12AdministratorUserPassword), StringUtil.Trim( AV13ConfAdministratorUserPassword)) != 0 )
            {
               GX_msglist.addItem("The administrator password and confirmation do not match");
               AV7isOK = false;
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( AV16ConnectionUserPassword), StringUtil.Trim( AV14ConfConnectionUserPassword)) != 0 )
            {
               GX_msglist.addItem("Connection password and confirmation do not match");
               AV7isOK = false;
            }
         }
         if ( AV7isOK )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV26GUID = Guid.NewGuid( ).ToString();
               AssignAttri("", false, "AV26GUID", AV26GUID);
               AV36RepositoryCreate.gxTpr_Guid = AV26GUID;
               AV36RepositoryCreate.gxTpr_Name = AV31Name;
               AV36RepositoryCreate.gxTpr_Namespace = AV32NameSpace;
               AV36RepositoryCreate.gxTpr_Description = AV23Description;
               AV36RepositoryCreate.gxTpr_Administratorusername = AV11AdministratorUserName;
               AV36RepositoryCreate.gxTpr_Administratoruserpassword = AV12AdministratorUserPassword;
               AV36RepositoryCreate.gxTpr_Allowoauthaccess = AV44AllowOauthAccess;
               AV36RepositoryCreate.gxTpr_Connectionusername = AV15ConnectionUserName;
               AV36RepositoryCreate.gxTpr_Connectionuserpassword = AV16ConnectionUserPassword;
               AV36RepositoryCreate.gxTpr_Generatesessionstatistics = AV25GenerateSessionStatistics;
               AV36RepositoryCreate.gxTpr_Giveanonymoussession = true;
               AV36RepositoryCreate.gxTpr_Allowoauthaccess = true;
               if ( AV45UseCurrentRepositorAsMasterAuthentication )
               {
                  AV47GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
                  AV36RepositoryCreate.gxTpr_Authenticationmasterrepositoryid = AV47GAMRepository.gxTpr_Id;
                  AV36RepositoryCreate.gxTpr_Authenticationmasterauthtypename = AV46AuthenticationMasterAuthTypeName;
               }
               AV36RepositoryCreate.gxTpr_Creategamapplication = AV22CreateGAMApplication;
               if ( ! (0==AV19CopyFromRepositoryId) )
               {
                  AV36RepositoryCreate.gxTpr_Copyfromrepositoryid = AV19CopyFromRepositoryId;
                  if ( AV20CopyRoles )
                  {
                     AV36RepositoryCreate.gxTpr_Copyroles = AV20CopyRoles;
                     AV36RepositoryCreate.gxTpr_Administratorroleid = AV10AdministratorRoleId;
                  }
                  AV36RepositoryCreate.gxTpr_Copysecuritypolicies = AV21CopySecurityPolicies;
               }
               if ( AV17CopyApplication && ! (0==AV18CopyFromApplicationId) )
               {
                  AV36RepositoryCreate.gxTpr_Copyapplication = AV17CopyApplication;
                  AV36RepositoryCreate.gxTpr_Copyfromapplicationid = AV18CopyFromApplicationId;
                  AV36RepositoryCreate.gxTpr_Copyapplicationrolepermissions = AV42CopyApplicationRolePermissions;
               }
               AV7isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).createrepository(AV36RepositoryCreate, AV40UpdateConnectionFile, out  AV24Errors);
               if ( AV7isOK )
               {
                  context.CommitDataStores("k2bfsg.entryrepository",pr_default);
                  if ( AV29isGAMAdminAccessRepository )
                  {
                     AV37RepositoryNew = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getbyguid(AV26GUID, out  AV24Errors);
                     AV6GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
                     AV7isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).repositoryuserenable(AV37RepositoryNew.gxTpr_Id, AV6GAMUser, AV10AdministratorRoleId, out  AV24Errors);
                  }
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV7isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).deleterepository(AV35Repository.gxTpr_Guid, out  AV24Errors);
            }
         }
         if ( AV7isOK )
         {
            context.CommitDataStores("k2bfsg.entryrepository",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(int)AV28Id});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV28Id"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S182 ();
            if (returnInSub) return;
         }
      }

      protected void E164O2( )
      {
         /* Usecurrentrepositorasmasterauthentication_Click Routine */
         returnInSub = false;
         AV47GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV32NameSpace = AV47GAMRepository.gxTpr_Namespace;
         AssignAttri("", false, "AV32NameSpace", AV32NameSpace);
         if ( AV45UseCurrentRepositorAsMasterAuthentication )
         {
            edtavNamespace_Visible = 0;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            chkavUsecurrentrepositorasmasterauthentication.Visible = 1;
            AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUsecurrentrepositorasmasterauthentication.Visible), 5, 0), true);
            edtavAdministratorusername_Caption = "Administrator user name (nickname)";
            AssignProp("", false, edtavAdministratorusername_Internalname, "Caption", edtavAdministratorusername_Caption, true);
            AV12AdministratorUserPassword = "";
            AssignAttri("", false, "AV12AdministratorUserPassword", AV12AdministratorUserPassword);
            edtavAdministratoruserpassword_Visible = 0;
            AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Visible), 5, 0), true);
            AV13ConfAdministratorUserPassword = "";
            AssignAttri("", false, "AV13ConfAdministratorUserPassword", AV13ConfAdministratorUserPassword);
            edtavConfadministratoruserpassword_Visible = 0;
            AssignProp("", false, edtavConfadministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfadministratoruserpassword_Visible), 5, 0), true);
         }
         else
         {
            edtavNamespace_Visible = 1;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            chkavUsecurrentrepositorasmasterauthentication.Visible = 0;
            AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUsecurrentrepositorasmasterauthentication.Visible), 5, 0), true);
            edtavAdministratorusername_Caption = "Administrator user name (nickname)";
            AssignProp("", false, edtavAdministratorusername_Internalname, "Caption", edtavAdministratorusername_Caption, true);
            edtavAdministratoruserpassword_Visible = 1;
            AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Visible), 5, 0), true);
            edtavConfadministratoruserpassword_Visible = 1;
            AssignProp("", false, edtavConfadministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfadministratoruserpassword_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E174O2( )
      {
         /* 'E_Cancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CANCEL' */
         S172 ();
         if (returnInSub) return;
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(string)Gx_mode,(int)AV28Id});
         context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV28Id"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S182( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         AV50GXV2 = 1;
         while ( AV50GXV2 <= AV24Errors.Count )
         {
            AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV24Errors.Item(AV50GXV2));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV5Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV5Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV50GXV2 = (int)(AV50GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E184O2( )
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
         AV28Id = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV28Id", StringUtil.LTrimStr( (decimal)(AV28Id), 9, 0));
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
         PA4O2( ) ;
         WS4O2( ) ;
         WE4O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138211786", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryrepository.js", "?20243138211789", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavUsecurrentrepositorasmasterauthentication.Name = "vUSECURRENTREPOSITORASMASTERAUTHENTICATION";
         chkavUsecurrentrepositorasmasterauthentication.WebTags = "";
         chkavUsecurrentrepositorasmasterauthentication.Caption = "";
         AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "TitleCaption", chkavUsecurrentrepositorasmasterauthentication.Caption, true);
         chkavUsecurrentrepositorasmasterauthentication.CheckedValue = "false";
         AV45UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV45UseCurrentRepositorAsMasterAuthentication));
         AssignAttri("", false, "AV45UseCurrentRepositorAsMasterAuthentication", AV45UseCurrentRepositorAsMasterAuthentication);
         cmbavGeneratesessionstatistics.Name = "vGENERATESESSIONSTATISTICS";
         cmbavGeneratesessionstatistics.WebTags = "";
         cmbavGeneratesessionstatistics.addItem("None", "None", 0);
         cmbavGeneratesessionstatistics.addItem("Minimum", "Minimum (Only authenticated users)", 0);
         cmbavGeneratesessionstatistics.addItem("Detail", "Detail (Authenticated and anonymous users)", 0);
         cmbavGeneratesessionstatistics.addItem("Full", "Full log (Authenticated and anonymous users)", 0);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV25GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV25GenerateSessionStatistics);
            AssignAttri("", false, "AV25GenerateSessionStatistics", AV25GenerateSessionStatistics);
         }
         chkavUpdateconnectionfile.Name = "vUPDATECONNECTIONFILE";
         chkavUpdateconnectionfile.WebTags = "";
         chkavUpdateconnectionfile.Caption = "";
         AssignProp("", false, chkavUpdateconnectionfile_Internalname, "TitleCaption", chkavUpdateconnectionfile.Caption, true);
         chkavUpdateconnectionfile.CheckedValue = "false";
         AV40UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UpdateConnectionFile));
         AssignAttri("", false, "AV40UpdateConnectionFile", AV40UpdateConnectionFile);
         chkavIsgamadminaccessrepository.Name = "vISGAMADMINACCESSREPOSITORY";
         chkavIsgamadminaccessrepository.WebTags = "";
         chkavIsgamadminaccessrepository.Caption = "";
         AssignProp("", false, chkavIsgamadminaccessrepository_Internalname, "TitleCaption", chkavIsgamadminaccessrepository.Caption, true);
         chkavIsgamadminaccessrepository.CheckedValue = "false";
         AV29isGAMAdminAccessRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV29isGAMAdminAccessRepository));
         AssignAttri("", false, "AV29isGAMAdminAccessRepository", AV29isGAMAdminAccessRepository);
         chkavCreategamapplication.Name = "vCREATEGAMAPPLICATION";
         chkavCreategamapplication.WebTags = "";
         chkavCreategamapplication.Caption = "";
         AssignProp("", false, chkavCreategamapplication_Internalname, "TitleCaption", chkavCreategamapplication.Caption, true);
         chkavCreategamapplication.CheckedValue = "false";
         AV22CreateGAMApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV22CreateGAMApplication));
         AssignAttri("", false, "AV22CreateGAMApplication", AV22CreateGAMApplication);
         cmbavCopyfromrepositoryid.Name = "vCOPYFROMREPOSITORYID";
         cmbavCopyfromrepositoryid.WebTags = "";
         if ( cmbavCopyfromrepositoryid.ItemCount > 0 )
         {
            AV19CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cmbavCopyfromrepositoryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19CopyFromRepositoryId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV19CopyFromRepositoryId), 9, 0));
         }
         chkavCopyroles.Name = "vCOPYROLES";
         chkavCopyroles.WebTags = "";
         chkavCopyroles.Caption = "";
         AssignProp("", false, chkavCopyroles_Internalname, "TitleCaption", chkavCopyroles.Caption, true);
         chkavCopyroles.CheckedValue = "false";
         AV20CopyRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV20CopyRoles));
         AssignAttri("", false, "AV20CopyRoles", AV20CopyRoles);
         chkavCopysecuritypolicies.Name = "vCOPYSECURITYPOLICIES";
         chkavCopysecuritypolicies.WebTags = "";
         chkavCopysecuritypolicies.Caption = "";
         AssignProp("", false, chkavCopysecuritypolicies_Internalname, "TitleCaption", chkavCopysecuritypolicies.Caption, true);
         chkavCopysecuritypolicies.CheckedValue = "false";
         AV21CopySecurityPolicies = StringUtil.StrToBool( StringUtil.BoolToStr( AV21CopySecurityPolicies));
         AssignAttri("", false, "AV21CopySecurityPolicies", AV21CopySecurityPolicies);
         chkavCopyapplication.Name = "vCOPYAPPLICATION";
         chkavCopyapplication.WebTags = "";
         chkavCopyapplication.Caption = "";
         AssignProp("", false, chkavCopyapplication_Internalname, "TitleCaption", chkavCopyapplication.Caption, true);
         chkavCopyapplication.CheckedValue = "false";
         AV17CopyApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17CopyApplication));
         AssignAttri("", false, "AV17CopyApplication", AV17CopyApplication);
         chkavCopyapplicationrolepermissions.Name = "vCOPYAPPLICATIONROLEPERMISSIONS";
         chkavCopyapplicationrolepermissions.WebTags = "";
         chkavCopyapplicationrolepermissions.Caption = "";
         AssignProp("", false, chkavCopyapplicationrolepermissions_Internalname, "TitleCaption", chkavCopyapplicationrolepermissions.Caption, true);
         chkavCopyapplicationrolepermissions.CheckedValue = "false";
         AV42CopyApplicationRolePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV42CopyApplicationRolePermissions));
         AssignAttri("", false, "AV42CopyApplicationRolePermissions", AV42CopyApplicationRolePermissions);
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
         edtavGuid_Internalname = "vGUID";
         divTable_container_guid_Internalname = "TABLE_CONTAINER_GUID";
         edtavName_Internalname = "vNAME";
         divTable_container_name_Internalname = "TABLE_CONTAINER_NAME";
         edtavDescription_Internalname = "vDESCRIPTION";
         divTable_container_description_Internalname = "TABLE_CONTAINER_DESCRIPTION";
         chkavUsecurrentrepositorasmasterauthentication_Internalname = "vUSECURRENTREPOSITORASMASTERAUTHENTICATION";
         divTable_container_usecurrentrepositorasmasterauthentication_Internalname = "TABLE_CONTAINER_USECURRENTREPOSITORASMASTERAUTHENTICATION";
         edtavNamespace_Internalname = "vNAMESPACE";
         divTable_container_namespace_Internalname = "TABLE_CONTAINER_NAMESPACE";
         cmbavGeneratesessionstatistics_Internalname = "vGENERATESESSIONSTATISTICS";
         divTable_container_generatesessionstatistics_Internalname = "TABLE_CONTAINER_GENERATESESSIONSTATISTICS";
         edtavConnectionusername_Internalname = "vCONNECTIONUSERNAME";
         divTable_container_connectionusername_Internalname = "TABLE_CONTAINER_CONNECTIONUSERNAME";
         edtavConnectionuserpassword_Internalname = "vCONNECTIONUSERPASSWORD";
         divTable_container_connectionuserpassword_Internalname = "TABLE_CONTAINER_CONNECTIONUSERPASSWORD";
         edtavConfconnectionuserpassword_Internalname = "vCONFCONNECTIONUSERPASSWORD";
         divTable_container_confconnectionuserpassword_Internalname = "TABLE_CONTAINER_CONFCONNECTIONUSERPASSWORD";
         edtavAuthenticationmasterauthtypename_Internalname = "vAUTHENTICATIONMASTERAUTHTYPENAME";
         divTable_container_authenticationmasterauthtypename_Internalname = "TABLE_CONTAINER_AUTHENTICATIONMASTERAUTHTYPENAME";
         edtavAdministratorusername_Internalname = "vADMINISTRATORUSERNAME";
         divTable_container_administratorusername_Internalname = "TABLE_CONTAINER_ADMINISTRATORUSERNAME";
         edtavAdministratoruserpassword_Internalname = "vADMINISTRATORUSERPASSWORD";
         divTable_container_administratoruserpassword_Internalname = "TABLE_CONTAINER_ADMINISTRATORUSERPASSWORD";
         edtavConfadministratoruserpassword_Internalname = "vCONFADMINISTRATORUSERPASSWORD";
         divTable_container_confadministratoruserpassword_Internalname = "TABLE_CONTAINER_CONFADMINISTRATORUSERPASSWORD";
         divMaingroupresponsivetable_connection_Internalname = "MAINGROUPRESPONSIVETABLE_CONNECTION";
         grpConnection_Internalname = "CONNECTION";
         chkavUpdateconnectionfile_Internalname = "vUPDATECONNECTIONFILE";
         divTable_container_updateconnectionfile_Internalname = "TABLE_CONTAINER_UPDATECONNECTIONFILE";
         chkavIsgamadminaccessrepository_Internalname = "vISGAMADMINACCESSREPOSITORY";
         divTable_container_isgamadminaccessrepository_Internalname = "TABLE_CONTAINER_ISGAMADMINACCESSREPOSITORY";
         chkavCreategamapplication_Internalname = "vCREATEGAMAPPLICATION";
         divTable_container_creategamapplication_Internalname = "TABLE_CONTAINER_CREATEGAMAPPLICATION";
         divAttributescontainertable_general_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERAL";
         divGeneral_content_Internalname = "GENERAL_CONTENT";
         General_Internalname = "GENERAL";
         cmbavCopyfromrepositoryid_Internalname = "vCOPYFROMREPOSITORYID";
         divTable_container_copyfromrepositoryid_Internalname = "TABLE_CONTAINER_COPYFROMREPOSITORYID";
         chkavCopyroles_Internalname = "vCOPYROLES";
         divTable_container_copyroles_Internalname = "TABLE_CONTAINER_COPYROLES";
         edtavAdministratorroleid_Internalname = "vADMINISTRATORROLEID";
         divTable_container_administratorroleid_Internalname = "TABLE_CONTAINER_ADMINISTRATORROLEID";
         chkavCopysecuritypolicies_Internalname = "vCOPYSECURITYPOLICIES";
         divTable_container_copysecuritypolicies_Internalname = "TABLE_CONTAINER_COPYSECURITYPOLICIES";
         chkavCopyapplication_Internalname = "vCOPYAPPLICATION";
         divTable_container_copyapplication_Internalname = "TABLE_CONTAINER_COPYAPPLICATION";
         edtavCopyfromapplicationid_Internalname = "vCOPYFROMAPPLICATIONID";
         divTable_container_copyfromapplicationid_Internalname = "TABLE_CONTAINER_COPYFROMAPPLICATIONID";
         chkavCopyapplicationrolepermissions_Internalname = "vCOPYAPPLICATIONROLEPERMISSIONS";
         divTable_container_copyapplicationrolepermissions_Internalname = "TABLE_CONTAINER_COPYAPPLICATIONROLEPERMISSIONS";
         divAttributescontainertable_responsivetable_mainattributes_copyapplicationtable_Internalname = "ATTRIBUTESCONTAINERTABLE_RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE";
         divResponsivetable_mainattributes_copyapplicationtable_content_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE_CONTENT";
         Responsivetable_mainattributes_copyapplicationtable_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_COPYAPPLICATIONTABLE";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions1_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS1";
         divResponsivetable_containernode_actions1_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS1";
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
         chkavCopyapplicationrolepermissions.Caption = "Copy roles permissions?";
         chkavCopyapplication.Caption = "Copy application? (Menus and permissions)";
         chkavCopysecuritypolicies.Caption = "Copy security policies?";
         chkavCopyroles.Caption = "Copy roles?";
         chkavCreategamapplication.Caption = "Create GAM Backend application?";
         chkavIsgamadminaccessrepository.Caption = "Enable gamadmin user to access the new repository?";
         chkavUpdateconnectionfile.Caption = "Update connection.gam file";
         chkavUsecurrentrepositorasmasterauthentication.Caption = "Use current repository as master authentication?";
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Caption = "Confirm";
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         chkavCopyapplicationrolepermissions.Enabled = 1;
         chkavCopyapplicationrolepermissions.Visible = 1;
         edtavCopyfromapplicationid_Jsonclick = "";
         edtavCopyfromapplicationid_Enabled = 1;
         edtavCopyfromapplicationid_Visible = 1;
         chkavCopyapplication.Enabled = 1;
         chkavCopysecuritypolicies.Enabled = 1;
         edtavAdministratorroleid_Jsonclick = "";
         edtavAdministratorroleid_Enabled = 1;
         edtavAdministratorroleid_Visible = 1;
         chkavCopyroles.Enabled = 1;
         cmbavCopyfromrepositoryid_Jsonclick = "";
         cmbavCopyfromrepositoryid.Enabled = 1;
         chkavCreategamapplication.Enabled = 1;
         chkavIsgamadminaccessrepository.Enabled = 1;
         chkavUpdateconnectionfile.Enabled = 1;
         chkavUpdateconnectionfile.Visible = 1;
         edtavConfadministratoruserpassword_Enabled = 1;
         edtavConfadministratoruserpassword_Visible = 1;
         edtavAdministratoruserpassword_Enabled = 1;
         edtavAdministratoruserpassword_Visible = 1;
         edtavAdministratorusername_Jsonclick = "";
         edtavAdministratorusername_Enabled = 1;
         edtavAdministratorusername_Caption = "Administrator user name (nickname)";
         edtavAuthenticationmasterauthtypename_Jsonclick = "";
         edtavAuthenticationmasterauthtypename_Enabled = 1;
         edtavConfconnectionuserpassword_Enabled = 1;
         edtavConnectionuserpassword_Enabled = 1;
         edtavConnectionusername_Jsonclick = "";
         edtavConnectionusername_Enabled = 1;
         grpConnection_Class = "Group_Tabular";
         cmbavGeneratesessionstatistics_Jsonclick = "";
         cmbavGeneratesessionstatistics.Enabled = 1;
         edtavNamespace_Jsonclick = "";
         edtavNamespace_Enabled = 1;
         edtavNamespace_Visible = 1;
         chkavUsecurrentrepositorasmasterauthentication.Enabled = 1;
         chkavUsecurrentrepositorasmasterauthentication.Visible = 1;
         edtavDescription_Jsonclick = "";
         edtavDescription_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavGuid_Visible = 1;
         imgDelete_Tooltiptext = "Delete";
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = "Update";
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         Responsivetable_mainattributes_copyapplicationtable_Visible = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_copyapplicationtable_Containseditableform = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_copyapplicationtable_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_copyapplicationtable_Open = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_copyapplicationtable_Collapsible = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_copyapplicationtable_Title = "Copy repository data";
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( 0);
         General_Title = "General";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Entry Repository";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV45UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''},{av:'AV40UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''},{av:'AV29isGAMAdminAccessRepository',fld:'vISGAMADMINACCESSREPOSITORY',pic:''},{av:'AV22CreateGAMApplication',fld:'vCREATEGAMAPPLICATION',pic:''},{av:'AV20CopyRoles',fld:'vCOPYROLES',pic:''},{av:'AV21CopySecurityPolicies',fld:'vCOPYSECURITYPOLICIES',pic:''},{av:'AV17CopyApplication',fld:'vCOPYAPPLICATION',pic:''},{av:'AV42CopyApplicationRolePermissions',fld:'vCOPYAPPLICATIONROLEPERMISSIONS',pic:''},{av:'AV44AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E114O1',iparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E124O1',iparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("ENTER","{handler:'E154O2',iparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12AdministratorUserPassword',fld:'vADMINISTRATORUSERPASSWORD',pic:''},{av:'AV13ConfAdministratorUserPassword',fld:'vCONFADMINISTRATORUSERPASSWORD',pic:''},{av:'AV16ConnectionUserPassword',fld:'vCONNECTIONUSERPASSWORD',pic:''},{av:'AV14ConfConnectionUserPassword',fld:'vCONFCONNECTIONUSERPASSWORD',pic:''},{av:'AV31Name',fld:'vNAME',pic:''},{av:'AV32NameSpace',fld:'vNAMESPACE',pic:''},{av:'AV23Description',fld:'vDESCRIPTION',pic:''},{av:'AV11AdministratorUserName',fld:'vADMINISTRATORUSERNAME',pic:''},{av:'AV44AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:'',hsh:true},{av:'AV15ConnectionUserName',fld:'vCONNECTIONUSERNAME',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV25GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'AV45UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''},{av:'AV46AuthenticationMasterAuthTypeName',fld:'vAUTHENTICATIONMASTERAUTHTYPENAME',pic:''},{av:'AV22CreateGAMApplication',fld:'vCREATEGAMAPPLICATION',pic:''},{av:'cmbavCopyfromrepositoryid'},{av:'AV19CopyFromRepositoryId',fld:'vCOPYFROMREPOSITORYID',pic:'ZZZZZZZZ9'},{av:'AV20CopyRoles',fld:'vCOPYROLES',pic:''},{av:'AV10AdministratorRoleId',fld:'vADMINISTRATORROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV21CopySecurityPolicies',fld:'vCOPYSECURITYPOLICIES',pic:''},{av:'AV17CopyApplication',fld:'vCOPYAPPLICATION',pic:''},{av:'AV18CopyFromApplicationId',fld:'vCOPYFROMAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV42CopyApplicationRolePermissions',fld:'vCOPYAPPLICATIONROLEPERMISSIONS',pic:''},{av:'AV40UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''},{av:'AV29isGAMAdminAccessRepository',fld:'vISGAMADMINACCESSREPOSITORY',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV26GUID',fld:'vGUID',pic:''}]}");
         setEventMetadata("VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK","{handler:'E164O2',iparms:[{av:'AV45UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''}]");
         setEventMetadata("VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK",",oparms:[{av:'AV32NameSpace',fld:'vNAMESPACE',pic:''},{av:'AV12AdministratorUserPassword',fld:'vADMINISTRATORUSERPASSWORD',pic:''},{av:'AV13ConfAdministratorUserPassword',fld:'vCONFADMINISTRATORUSERPASSWORD',pic:''},{av:'edtavNamespace_Visible',ctrl:'vNAMESPACE',prop:'Visible'},{av:'chkavUsecurrentrepositorasmasterauthentication.Visible',ctrl:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',prop:'Visible'},{av:'edtavAdministratorusername_Caption',ctrl:'vADMINISTRATORUSERNAME',prop:'Caption'},{av:'edtavAdministratoruserpassword_Visible',ctrl:'vADMINISTRATORUSERPASSWORD',prop:'Visible'},{av:'edtavConfadministratoruserpassword_Visible',ctrl:'vCONFADMINISTRATORUSERPASSWORD',prop:'Visible'}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E174O2',iparms:[{av:'AV28Id',fld:'vID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS","{handler:'Validv_Generatesessionstatistics',iparms:[]");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS",",oparms:[]}");
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
         AV26GUID = "";
         AV31Name = "";
         AV23Description = "";
         AV32NameSpace = "";
         AV25GenerateSessionStatistics = "";
         AV15ConnectionUserName = "";
         AV16ConnectionUserPassword = "";
         AV14ConfConnectionUserPassword = "";
         AV46AuthenticationMasterAuthTypeName = "";
         AV11AdministratorUserName = "";
         AV12AdministratorUserPassword = "";
         AV13ConfAdministratorUserPassword = "";
         ucResponsivetable_mainattributes_copyapplicationtable = new GXUserControl();
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV35Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV24Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV34Repositories = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepository", "GeneXus.Programs");
         AV43RepositoryFilter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter(context);
         AV33Repo = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV36RepositoryCreate = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate(context);
         AV47GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV37RepositoryNew = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV6GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV5Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryrepository__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryrepository__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV28Id ;
      private int wcpOAV28Id ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int edtavGuid_Visible ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDescription_Enabled ;
      private int edtavNamespace_Visible ;
      private int edtavNamespace_Enabled ;
      private int edtavConnectionusername_Enabled ;
      private int edtavConnectionuserpassword_Enabled ;
      private int edtavConfconnectionuserpassword_Enabled ;
      private int edtavAuthenticationmasterauthtypename_Enabled ;
      private int edtavAdministratorusername_Enabled ;
      private int edtavAdministratoruserpassword_Visible ;
      private int edtavAdministratoruserpassword_Enabled ;
      private int edtavConfadministratoruserpassword_Visible ;
      private int edtavConfadministratoruserpassword_Enabled ;
      private int AV19CopyFromRepositoryId ;
      private int edtavAdministratorroleid_Visible ;
      private int edtavAdministratorroleid_Enabled ;
      private int edtavCopyfromapplicationid_Visible ;
      private int edtavCopyfromapplicationid_Enabled ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int AV49GXV1 ;
      private int AV50GXV2 ;
      private int idxLst ;
      private long AV10AdministratorRoleId ;
      private long AV18CopyFromApplicationId ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string General_Title ;
      private string Responsivetable_mainattributes_copyapplicationtable_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
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
      private string divTable_container_guid_Internalname ;
      private string edtavGuid_Internalname ;
      private string AV26GUID ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV31Name ;
      private string edtavName_Jsonclick ;
      private string divTable_container_description_Internalname ;
      private string edtavDescription_Internalname ;
      private string AV23Description ;
      private string edtavDescription_Jsonclick ;
      private string divTable_container_usecurrentrepositorasmasterauthentication_Internalname ;
      private string chkavUsecurrentrepositorasmasterauthentication_Internalname ;
      private string divTable_container_namespace_Internalname ;
      private string edtavNamespace_Internalname ;
      private string AV32NameSpace ;
      private string edtavNamespace_Jsonclick ;
      private string divTable_container_generatesessionstatistics_Internalname ;
      private string cmbavGeneratesessionstatistics_Internalname ;
      private string AV25GenerateSessionStatistics ;
      private string cmbavGeneratesessionstatistics_Jsonclick ;
      private string grpConnection_Internalname ;
      private string grpConnection_Class ;
      private string divMaingroupresponsivetable_connection_Internalname ;
      private string divTable_container_connectionusername_Internalname ;
      private string edtavConnectionusername_Internalname ;
      private string AV15ConnectionUserName ;
      private string edtavConnectionusername_Jsonclick ;
      private string divTable_container_connectionuserpassword_Internalname ;
      private string edtavConnectionuserpassword_Internalname ;
      private string AV16ConnectionUserPassword ;
      private string divTable_container_confconnectionuserpassword_Internalname ;
      private string edtavConfconnectionuserpassword_Internalname ;
      private string AV14ConfConnectionUserPassword ;
      private string divTable_container_authenticationmasterauthtypename_Internalname ;
      private string edtavAuthenticationmasterauthtypename_Internalname ;
      private string AV46AuthenticationMasterAuthTypeName ;
      private string edtavAuthenticationmasterauthtypename_Jsonclick ;
      private string divTable_container_administratorusername_Internalname ;
      private string edtavAdministratorusername_Internalname ;
      private string edtavAdministratorusername_Caption ;
      private string AV11AdministratorUserName ;
      private string edtavAdministratorusername_Jsonclick ;
      private string divTable_container_administratoruserpassword_Internalname ;
      private string edtavAdministratoruserpassword_Internalname ;
      private string AV12AdministratorUserPassword ;
      private string divTable_container_confadministratoruserpassword_Internalname ;
      private string edtavConfadministratoruserpassword_Internalname ;
      private string AV13ConfAdministratorUserPassword ;
      private string divTable_container_updateconnectionfile_Internalname ;
      private string chkavUpdateconnectionfile_Internalname ;
      private string divTable_container_isgamadminaccessrepository_Internalname ;
      private string chkavIsgamadminaccessrepository_Internalname ;
      private string divTable_container_creategamapplication_Internalname ;
      private string chkavCreategamapplication_Internalname ;
      private string Responsivetable_mainattributes_copyapplicationtable_Internalname ;
      private string divResponsivetable_mainattributes_copyapplicationtable_content_Internalname ;
      private string divAttributescontainertable_responsivetable_mainattributes_copyapplicationtable_Internalname ;
      private string divTable_container_copyfromrepositoryid_Internalname ;
      private string cmbavCopyfromrepositoryid_Internalname ;
      private string cmbavCopyfromrepositoryid_Jsonclick ;
      private string divTable_container_copyroles_Internalname ;
      private string chkavCopyroles_Internalname ;
      private string divTable_container_administratorroleid_Internalname ;
      private string edtavAdministratorroleid_Internalname ;
      private string edtavAdministratorroleid_Jsonclick ;
      private string divTable_container_copysecuritypolicies_Internalname ;
      private string chkavCopysecuritypolicies_Internalname ;
      private string divTable_container_copyapplication_Internalname ;
      private string chkavCopyapplication_Internalname ;
      private string divTable_container_copyfromapplicationid_Internalname ;
      private string edtavCopyfromapplicationid_Internalname ;
      private string edtavCopyfromapplicationid_Jsonclick ;
      private string divTable_container_copyapplicationrolepermissions_Internalname ;
      private string chkavCopyapplicationrolepermissions_Internalname ;
      private string divResponsivetable_containernode_actions1_Internalname ;
      private string divActionscontainertableleft_actions1_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Caption ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV44AllowOauthAccess ;
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool Responsivetable_mainattributes_copyapplicationtable_Collapsible ;
      private bool Responsivetable_mainattributes_copyapplicationtable_Open ;
      private bool Responsivetable_mainattributes_copyapplicationtable_Showborders ;
      private bool Responsivetable_mainattributes_copyapplicationtable_Containseditableform ;
      private bool Responsivetable_mainattributes_copyapplicationtable_Visible ;
      private bool wbLoad ;
      private bool AV45UseCurrentRepositorAsMasterAuthentication ;
      private bool AV40UpdateConnectionFile ;
      private bool AV29isGAMAdminAccessRepository ;
      private bool AV22CreateGAMApplication ;
      private bool AV20CopyRoles ;
      private bool AV21CopySecurityPolicies ;
      private bool AV17CopyApplication ;
      private bool AV42CopyApplicationRolePermissions ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV7isOK ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucResponsivetable_mainattributes_copyapplicationtable ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private int aP1_Id ;
      private GXCheckbox chkavUsecurrentrepositorasmasterauthentication ;
      private GXCombobox cmbavGeneratesessionstatistics ;
      private GXCheckbox chkavUpdateconnectionfile ;
      private GXCheckbox chkavIsgamadminaccessrepository ;
      private GXCheckbox chkavCreategamapplication ;
      private GXCombobox cmbavCopyfromrepositoryid ;
      private GXCheckbox chkavCopyroles ;
      private GXCheckbox chkavCopysecuritypolicies ;
      private GXCheckbox chkavCopyapplication ;
      private GXCheckbox chkavCopyapplicationrolepermissions ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository> AV34Repositories ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV5Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV6GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV35Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV33Repo ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV47GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV37RepositoryNew ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate AV36RepositoryCreate ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter AV43RepositoryFilter ;
   }

   public class entryrepository__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class entryrepository__default : DataStoreHelperBase, IDataStoreHelper
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
