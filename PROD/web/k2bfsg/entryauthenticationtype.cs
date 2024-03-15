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
   public class entryauthenticationtype : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryauthenticationtype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entryauthenticationtype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_Name ,
                           ref string aP2_TypeIdDsp )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Name = aP1_Name;
         this.AV22TypeIdDsp = aP2_TypeIdDsp;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV18Name;
         aP2_TypeIdDsp=this.AV22TypeIdDsp;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTypeid = new GXCombobox();
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
                  AV18Name = GetPar( "Name");
                  AssignAttri("", false, "AV18Name", AV18Name);
                  AV22TypeIdDsp = GetPar( "TypeIdDsp");
                  AssignAttri("", false, "AV22TypeIdDsp", AV22TypeIdDsp);
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
         PA3Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3Q2( ) ;
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryauthenticationtype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV18Name)),UrlEncode(StringUtil.RTrim(AV22TypeIdDsp))}, new string[] {"Gx_mode","Name","TypeIdDsp"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNAME", StringUtil.RTrim( AV18Name));
         GxWebStd.gx_hidden_field( context, "vTYPEIDDSP", StringUtil.RTrim( AV22TypeIdDsp));
         GxWebStd.gx_hidden_field( context, "GENERAL_Title", StringUtil.RTrim( General_Title));
         GxWebStd.gx_hidden_field( context, "GENERAL_Collapsible", StringUtil.BoolToStr( General_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERAL_Open", StringUtil.BoolToStr( General_Open));
         GxWebStd.gx_hidden_field( context, "GENERAL_Showborders", StringUtil.BoolToStr( General_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERAL_Containseditableform", StringUtil.BoolToStr( General_Containseditableform));
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
         if ( ! ( WebComp_Wcentrypanel == null ) )
         {
            WebComp_Wcentrypanel.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3Q2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.entryauthenticationtype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV18Name)),UrlEncode(StringUtil.RTrim(AV22TypeIdDsp))}, new string[] {"Gx_mode","Name","TypeIdDsp"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryAuthenticationType" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entry authentication type" ;
      }

      protected void WB3Q0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Authentication type", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryAuthenticationType.htm");
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
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113q1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryAuthenticationType.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123q1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryAuthenticationType.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_typeid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavTypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTypeid_Internalname, "Type ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTypeid, cmbavTypeid_Internalname, StringUtil.RTrim( AV21TypeId), 1, cmbavTypeid_Jsonclick, 7, "'"+""+"'"+",false,"+"'"+"e133q1_client"+"'", "char", "", 1, cmbavTypeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_K2BFSG\\EntryAuthenticationType.htm");
            cmbavTypeid.CurrentValue = StringUtil.RTrim( AV21TypeId);
            AssignProp("", false, cmbavTypeid_Internalname, "Values", (string)(cmbavTypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0040"+"", StringUtil.RTrim( WebComp_Wcentrypanel_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0040"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcentrypanel), StringUtil.Lower( WebComp_Wcentrypanel_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
                  }
                  WebComp_Wcentrypanel.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcentrypanel), StringUtil.Lower( WebComp_Wcentrypanel_Component)) != 0 )
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

      protected void START3Q2( )
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
         Form.Meta.addItem("description", "Entry authentication type", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3Q0( ) ;
      }

      protected void WS3Q2( )
      {
         START3Q2( ) ;
         EVT3Q2( ) ;
      }

      protected void EVT3Q2( )
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
                              E143Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E153Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E163Q2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 40 )
                        {
                           OldWcentrypanel = cgiGet( "W0040");
                           if ( ( StringUtil.Len( OldWcentrypanel) == 0 ) || ( StringUtil.StrCmp(OldWcentrypanel, WebComp_Wcentrypanel_Component) != 0 ) )
                           {
                              WebComp_Wcentrypanel = getWebComponent(GetType(), "GeneXus.Programs", OldWcentrypanel, new Object[] {context} );
                              WebComp_Wcentrypanel.ComponentInit();
                              WebComp_Wcentrypanel.Name = "OldWcentrypanel";
                              WebComp_Wcentrypanel_Component = OldWcentrypanel;
                           }
                           if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
                           {
                              WebComp_Wcentrypanel.componentprocess("W0040", "", sEvt);
                           }
                           WebComp_Wcentrypanel_Component = OldWcentrypanel;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3Q2( )
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

      protected void PA3Q2( )
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
               GX_FocusControl = cmbavTypeid_Internalname;
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
         if ( cmbavTypeid.ItemCount > 0 )
         {
            AV21TypeId = cmbavTypeid.getValidValue(AV21TypeId);
            AssignAttri("", false, "AV21TypeId", AV21TypeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTypeid.CurrentValue = StringUtil.RTrim( AV21TypeId);
            AssignProp("", false, cmbavTypeid_Internalname, "Values", cmbavTypeid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E153Q2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
               {
                  WebComp_Wcentrypanel.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E163Q2 ();
            WB3Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            AV18Name = cgiGet( "vNAME");
            AV22TypeIdDsp = cgiGet( "vTYPEIDDSP");
            General_Title = cgiGet( "GENERAL_Title");
            General_Collapsible = StringUtil.StrToBool( cgiGet( "GENERAL_Collapsible"));
            General_Open = StringUtil.StrToBool( cgiGet( "GENERAL_Open"));
            General_Showborders = StringUtil.StrToBool( cgiGet( "GENERAL_Showborders"));
            General_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERAL_Containseditableform"));
            /* Read variables values. */
            cmbavTypeid.CurrentValue = cgiGet( cmbavTypeid_Internalname);
            AV21TypeId = cgiGet( cmbavTypeid_Internalname);
            AssignAttri("", false, "AV21TypeId", AV21TypeId);
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
         E143Q2 ();
         if (returnInSub) return;
      }

      protected void E143Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E153Q2( )
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
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV28GXV2 = 1;
            AV27GXV1 = (GxSimpleCollection<string>)(GeneXus.Programs.genexussecuritycommon.gxdomaingamauthenticationtypes.getValues());
            while ( AV28GXV2 <= AV27GXV1.Count )
            {
               AV25AuthenticationType = AV27GXV1.GetString(AV28GXV2);
               if ( StringUtil.StrCmp(AV25AuthenticationType, "GAMLocal") != 0 )
               {
                  cmbavTypeid.addItem(AV25AuthenticationType, GeneXus.Programs.genexussecuritycommon.gxdomaingamauthenticationtypes.getDescription(context,AV25AuthenticationType), 0);
               }
               AV28GXV2 = (int)(AV28GXV2+1);
            }
            cmbavTypeid.Enabled = 1;
            AssignProp("", false, cmbavTypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeid.Enabled), 5, 0), true);
         }
         else
         {
            cmbavTypeid.addItem(AV22TypeIdDsp, GeneXus.Programs.genexussecuritycommon.gxdomaingamauthenticationtypes.getDescription(context,AV22TypeIdDsp), 0);
            AV21TypeId = AV22TypeIdDsp;
            AssignAttri("", false, "AV21TypeId", AV21TypeId);
            cmbavTypeid.Enabled = 0;
            AssignProp("", false, cmbavTypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeid.Enabled), 5, 0), true);
         }
         /* Execute user subroutine: 'WCENTRY' */
         S162 ();
         if (returnInSub) return;
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

      protected void S142( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryauthenticationtype.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV18Name)),UrlEncode(StringUtil.RTrim(AV22TypeIdDsp))}, new string[] {"Mode","Name","TypeIdDsp"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S152( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryauthenticationtype.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV18Name)),UrlEncode(StringUtil.RTrim(AV22TypeIdDsp))}, new string[] {"Mode","Name","TypeIdDsp"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S162( )
      {
         /* 'WCENTRY' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21TypeId, "Oauth20") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcentrypanel = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcentrypanel_Component), StringUtil.Lower( "K2BFSG.WCAuthenticationTypeEntryOauth20")) != 0 )
            {
               WebComp_Wcentrypanel = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wcauthenticationtypeentryoauth20", new Object[] {context} );
               WebComp_Wcentrypanel.ComponentInit();
               WebComp_Wcentrypanel.Name = "K2BFSG.WCAuthenticationTypeEntryOauth20";
               WebComp_Wcentrypanel_Component = "K2BFSG.WCAuthenticationTypeEntryOauth20";
            }
            if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
            {
               WebComp_Wcentrypanel.setjustcreated();
               WebComp_Wcentrypanel.componentprepare(new Object[] {(string)"W0040",(string)"",(string)Gx_mode,(string)AV18Name,(string)AV21TypeId});
               WebComp_Wcentrypanel.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcentrypanel )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
               WebComp_Wcentrypanel.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV21TypeId, "Saml20") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcentrypanel = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcentrypanel_Component), StringUtil.Lower( "K2BFSG.WCAuthenticationTypeEntrySaml20")) != 0 )
            {
               WebComp_Wcentrypanel = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wcauthenticationtypeentrysaml20", new Object[] {context} );
               WebComp_Wcentrypanel.ComponentInit();
               WebComp_Wcentrypanel.Name = "K2BFSG.WCAuthenticationTypeEntrySaml20";
               WebComp_Wcentrypanel_Component = "K2BFSG.WCAuthenticationTypeEntrySaml20";
            }
            if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
            {
               WebComp_Wcentrypanel.setjustcreated();
               WebComp_Wcentrypanel.componentprepare(new Object[] {(string)"W0040",(string)"",(string)Gx_mode,(string)AV18Name,(string)AV21TypeId});
               WebComp_Wcentrypanel.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcentrypanel )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
               WebComp_Wcentrypanel.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcentrypanel = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcentrypanel_Component), StringUtil.Lower( "K2BFSG.WCAuthenticationTypeEntryGeneral")) != 0 )
            {
               WebComp_Wcentrypanel = getWebComponent(GetType(), "GeneXus.Programs", "k2bfsg.wcauthenticationtypeentrygeneral", new Object[] {context} );
               WebComp_Wcentrypanel.ComponentInit();
               WebComp_Wcentrypanel.Name = "K2BFSG.WCAuthenticationTypeEntryGeneral";
               WebComp_Wcentrypanel_Component = "K2BFSG.WCAuthenticationTypeEntryGeneral";
            }
            if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
            {
               WebComp_Wcentrypanel.setjustcreated();
               WebComp_Wcentrypanel.componentprepare(new Object[] {(string)"W0040",(string)"",(string)Gx_mode,(string)AV18Name,(string)AV21TypeId});
               WebComp_Wcentrypanel.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcentrypanel )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
               WebComp_Wcentrypanel.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E163Q2( )
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
         AV18Name = (string)getParm(obj,1);
         AssignAttri("", false, "AV18Name", AV18Name);
         AV22TypeIdDsp = (string)getParm(obj,2);
         AssignAttri("", false, "AV22TypeIdDsp", AV22TypeIdDsp);
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
         PA3Q2( ) ;
         WS3Q2( ) ;
         WE3Q2( ) ;
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
         if ( ! ( WebComp_Wcentrypanel == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcentrypanel_Component) != 0 )
            {
               WebComp_Wcentrypanel.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138181523", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryauthenticationtype.js", "?20243138181524", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTypeid.Name = "vTYPEID";
         cmbavTypeid.WebTags = "";
         cmbavTypeid.addItem("AppleID", "Apple", 0);
         cmbavTypeid.addItem("Custom", "Custom", 0);
         cmbavTypeid.addItem("ExternalWebService", "External Web Service", 0);
         cmbavTypeid.addItem("Facebook", "Facebook", 0);
         cmbavTypeid.addItem("GAMLocal", "GAM Local", 0);
         cmbavTypeid.addItem("GAMRemote", "GAM Remote", 0);
         cmbavTypeid.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
         cmbavTypeid.addItem("Google", "Google", 0);
         cmbavTypeid.addItem("Oauth20", "Oauth 2.0", 0);
         cmbavTypeid.addItem("OTP", "One Time Password", 0);
         cmbavTypeid.addItem("Saml20", "Saml 2.0", 0);
         cmbavTypeid.addItem("Twitter", "Twitter", 0);
         cmbavTypeid.addItem("WeChat", "WeChat", 0);
         if ( cmbavTypeid.ItemCount > 0 )
         {
            AV21TypeId = cmbavTypeid.getValidValue(AV21TypeId);
            AssignAttri("", false, "AV21TypeId", AV21TypeId);
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
         cmbavTypeid_Internalname = "vTYPEID";
         divTable_container_typeid_Internalname = "TABLE_CONTAINER_TYPEID";
         divAttributescontainertable_general_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERAL";
         divGeneral_content_Internalname = "GENERAL_CONTENT";
         General_Internalname = "GENERAL";
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
         cmbavTypeid_Jsonclick = "";
         cmbavTypeid.Enabled = 1;
         imgDelete_Tooltiptext = "Delete";
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = "Update";
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( 0);
         General_Title = "General";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Entry authentication type";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E113Q1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV22TypeIdDsp',fld:'vTYPEIDDSP',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV22TypeIdDsp',fld:'vTYPEIDDSP',pic:''},{av:'AV18Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E123Q1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV22TypeIdDsp',fld:'vTYPEIDDSP',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV22TypeIdDsp',fld:'vTYPEIDDSP',pic:''},{av:'AV18Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VTYPEID.CLICK","{handler:'E133Q1',iparms:[{av:'cmbavTypeid'},{av:'AV21TypeId',fld:'vTYPEID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18Name',fld:'vNAME',pic:''}]");
         setEventMetadata("VTYPEID.CLICK",",oparms:[{ctrl:'WCENTRYPANEL'}]}");
         setEventMetadata("VALIDV_TYPEID","{handler:'Validv_Typeid',iparms:[]");
         setEventMetadata("VALIDV_TYPEID",",oparms:[]}");
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
         wcpOAV18Name = "";
         wcpOAV22TypeIdDsp = "";
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
         AV21TypeId = "";
         WebComp_Wcentrypanel_Component = "";
         OldWcentrypanel = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27GXV1 = new GxSimpleCollection<string>();
         AV25AuthenticationType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcentrypanel = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
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
      private int AV28GXV2 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV18Name ;
      private string AV22TypeIdDsp ;
      private string wcpOGx_mode ;
      private string wcpOAV18Name ;
      private string wcpOAV22TypeIdDsp ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string General_Title ;
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
      private string divTable_container_typeid_Internalname ;
      private string cmbavTypeid_Internalname ;
      private string AV21TypeId ;
      private string cmbavTypeid_Jsonclick ;
      private string WebComp_Wcentrypanel_Component ;
      private string OldWcentrypanel ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV25AuthenticationType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcentrypanel ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXWebComponent WebComp_Wcentrypanel ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeIdDsp ;
      private GXCombobox cmbavTypeid ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV27GXV1 ;
      private GXWebForm Form ;
   }

}
