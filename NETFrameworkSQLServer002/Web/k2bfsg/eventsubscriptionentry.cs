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
   public class eventsubscriptionentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public eventsubscriptionentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public eventsubscriptionentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_Id )
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
         cmbavStatus = new GXCombobox();
         cmbavEvent = new GXCombobox();
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
                  AV18Id = GetPar( "Id");
                  AssignAttri("", false, "AV18Id", AV18Id);
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
            return "eventsubscriptionentry_Execute" ;
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
         PA3J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.eventsubscriptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV18Id))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.RTrim( AV18Id));
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
            WE3J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3J2( ) ;
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
         return formatLink("k2bfsg.eventsubscriptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV18Id))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EventSubscriptionEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Event Subscription Entry", "") ;
      }

      protected void WB3J0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "K2BT_GAM_EventSubscription", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSubscribeunsubscribe_Internalname, "", bttSubscribeunsubscribe_Caption, bttSubscribeunsubscribe_Jsonclick, 5, "", "", StyleString, ClassString, bttSubscribeunsubscribe_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_SUBSCRIBEUNSUBSCRIBE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EventSubscriptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgUpdate_gximage, "")==0) ? "GX_Image_K2BActionUpdate_Class" : "GX_Image_"+imgUpdate_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "K2BT_UpdateAction", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EventSubscriptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "K2BT_DeleteAction", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123j1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_description_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDescription_Internalname, context.GetMessage( "K2BT_GAM_Description", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDescription_Internalname, StringUtil.RTrim( AV12Description), StringUtil.RTrim( context.localUtil.Format( AV12Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDescription_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavDescription_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_status_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavStatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavStatus_Internalname, context.GetMessage( "K2BT_GAM_Status", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavStatus, cmbavStatus_Internalname, StringUtil.RTrim( AV13Status), 1, cmbavStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_K2BFSG\\EventSubscriptionEntry.htm");
            cmbavStatus.CurrentValue = StringUtil.RTrim( AV13Status);
            AssignProp("", false, cmbavStatus_Internalname, "Values", (string)(cmbavStatus.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_event_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavEvent_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEvent_Internalname, context.GetMessage( "K2BT_GAM_Event", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEvent, cmbavEvent_Internalname, StringUtil.RTrim( AV14Event), 1, cmbavEvent_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavEvent.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_K2BFSG\\EventSubscriptionEntry.htm");
            cmbavEvent.CurrentValue = StringUtil.RTrim( AV14Event);
            AssignProp("", false, cmbavEvent_Internalname, "Values", (string)(cmbavEvent.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_filename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "K2BT_GAM_FileName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, StringUtil.RTrim( AV15FileName), StringUtil.RTrim( context.localUtil.Format( AV15FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavFilename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_classname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavClassname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClassname_Internalname, context.GetMessage( "K2BT_GAM_ClassName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClassname_Internalname, StringUtil.RTrim( AV16ClassName), StringUtil.RTrim( context.localUtil.Format( AV16ClassName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClassname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavClassname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_methodname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMethodname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMethodname_Internalname, context.GetMessage( "K2BT_GAM_MethodName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMethodname_Internalname, StringUtil.RTrim( AV17MethodName), StringUtil.RTrim( context.localUtil.Format( AV17MethodName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMethodname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMethodname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EventSubscriptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 5, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EventSubscriptionEntry.htm");
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

      protected void START3J2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Event Subscription Entry", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3J0( ) ;
      }

      protected void WS3J2( )
      {
         START3J2( ) ;
         EVT3J2( ) ;
      }

      protected void EVT3J2( )
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
                              E133J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E143J2 ();
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
                                    E153J2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Cancel' */
                              E163J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_SUBSCRIBEUNSUBSCRIBE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_SubscribeUnsubscribe' */
                              E173J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E183J2 ();
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

      protected void WE3J2( )
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

      protected void PA3J2( )
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
               GX_FocusControl = edtavDescription_Internalname;
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
         if ( cmbavStatus.ItemCount > 0 )
         {
            AV13Status = cmbavStatus.getValidValue(AV13Status);
            AssignAttri("", false, "AV13Status", AV13Status);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavStatus.CurrentValue = StringUtil.RTrim( AV13Status);
            AssignProp("", false, cmbavStatus_Internalname, "Values", cmbavStatus.ToJavascriptSource(), true);
         }
         if ( cmbavEvent.ItemCount > 0 )
         {
            AV14Event = cmbavEvent.getValidValue(AV14Event);
            AssignAttri("", false, "AV14Event", AV14Event);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEvent.CurrentValue = StringUtil.RTrim( AV14Event);
            AssignProp("", false, cmbavEvent_Internalname, "Values", cmbavEvent.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E143J2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E183J2 ();
            WB3J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3J2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV18Id = cgiGet( "vID");
            General_Title = cgiGet( "GENERAL_Title");
            General_Collapsible = StringUtil.StrToBool( cgiGet( "GENERAL_Collapsible"));
            General_Open = StringUtil.StrToBool( cgiGet( "GENERAL_Open"));
            General_Showborders = StringUtil.StrToBool( cgiGet( "GENERAL_Showborders"));
            General_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERAL_Containseditableform"));
            /* Read variables values. */
            AV12Description = cgiGet( edtavDescription_Internalname);
            AssignAttri("", false, "AV12Description", AV12Description);
            cmbavStatus.CurrentValue = cgiGet( cmbavStatus_Internalname);
            AV13Status = cgiGet( cmbavStatus_Internalname);
            AssignAttri("", false, "AV13Status", AV13Status);
            cmbavEvent.CurrentValue = cgiGet( cmbavEvent_Internalname);
            AV14Event = cgiGet( cmbavEvent_Internalname);
            AssignAttri("", false, "AV14Event", AV14Event);
            AV15FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri("", false, "AV15FileName", AV15FileName);
            AV16ClassName = cgiGet( edtavClassname_Internalname);
            AssignAttri("", false, "AV16ClassName", AV16ClassName);
            AV17MethodName = cgiGet( edtavMethodname_Internalname);
            AssignAttri("", false, "AV17MethodName", AV17MethodName);
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
         E133J2 ();
         if (returnInSub) return;
      }

      protected void E133J2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E143J2( )
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
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
         cmbavStatus.Enabled = 0;
         AssignProp("", false, cmbavStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStatus.Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV19EventSubscription.load( AV18Id);
            AV12Description = AV19EventSubscription.gxTpr_Description;
            AssignAttri("", false, "AV12Description", AV12Description);
            AV13Status = AV19EventSubscription.gxTpr_Status;
            AssignAttri("", false, "AV13Status", AV13Status);
            AV14Event = AV19EventSubscription.gxTpr_Event;
            AssignAttri("", false, "AV14Event", AV14Event);
            AV15FileName = AV19EventSubscription.gxTpr_Filename;
            AssignAttri("", false, "AV15FileName", AV15FileName);
            AV16ClassName = AV19EventSubscription.gxTpr_Classname;
            AssignAttri("", false, "AV16ClassName", AV16ClassName);
            AV17MethodName = AV19EventSubscription.gxTpr_Methodname;
            AssignAttri("", false, "AV17MethodName", AV17MethodName);
            if ( StringUtil.StrCmp(Gx_mode, "UPD") != 0 )
            {
               edtavDescription_Enabled = 0;
               AssignProp("", false, edtavDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescription_Enabled), 5, 0), true);
               cmbavEvent.Enabled = 0;
               AssignProp("", false, cmbavEvent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavEvent.Enabled), 5, 0), true);
               edtavFilename_Enabled = 0;
               AssignProp("", false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               edtavClassname_Enabled = 0;
               AssignProp("", false, edtavClassname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClassname_Enabled), 5, 0), true);
               edtavMethodname_Enabled = 0;
               AssignProp("", false, edtavMethodname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMethodname_Enabled), 5, 0), true);
            }
         }
         else
         {
            AV13Status = "u";
            AssignAttri("", false, "AV13Status", AV13Status);
         }
         /* Execute user subroutine: 'UPDATEACTIONSTATUS' */
         S192 ();
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
            bttSubscribeunsubscribe_Visible = 1;
            AssignProp("", false, bttSubscribeunsubscribe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSubscribeunsubscribe_Visible), 5, 0), true);
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
            bttSubscribeunsubscribe_Visible = 0;
            AssignProp("", false, bttSubscribeunsubscribe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSubscribeunsubscribe_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.eventsubscriptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV18Id))}, new string[] {"Mode","Id"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.eventsubscriptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV18Id))}, new string[] {"Mode","Id"}) );
         context.wjLocDisableFrm = 1;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E153J2 ();
         if (returnInSub) return;
      }

      protected void E153J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV19EventSubscription.load( AV18Id);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            AV19EventSubscription.gxTpr_Description = AV12Description;
            AV19EventSubscription.gxTpr_Event = AV14Event;
            AV19EventSubscription.gxTpr_Filename = AV15FileName;
            AV19EventSubscription.gxTpr_Classname = AV16ClassName;
            AV19EventSubscription.gxTpr_Methodname = AV17MethodName;
            AV19EventSubscription.save();
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV19EventSubscription.delete();
         }
         if ( AV19EventSubscription.success() )
         {
            context.CommitDataStores("k2bfsg.eventsubscriptionentry",pr_default);
            CallWebObject(formatLink("k2bfsg.wweventsubscription.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV20Errors = AV19EventSubscription.geterrors();
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV20Errors.Count )
            {
               AV21Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV20Errors.Item(AV24GXV1));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV21Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV21Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E163J2( )
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
         context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV18Id});
         context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV18Id"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E173J2( )
      {
         /* 'E_SubscribeUnsubscribe' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_SUBSCRIBEUNSUBSCRIBE' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavStatus.CurrentValue = StringUtil.RTrim( AV13Status);
         AssignProp("", false, cmbavStatus_Internalname, "Values", cmbavStatus.ToJavascriptSource(), true);
      }

      protected void S182( )
      {
         /* 'U_SUBSCRIBEUNSUBSCRIBE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Status, "u") == 0 )
         {
            AV22isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).subscribeevent(AV18Id, out  AV20Errors);
            AV13Status = "s";
            AssignAttri("", false, "AV13Status", AV13Status);
         }
         else
         {
            AV22isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).unsubscribeevent(AV18Id, out  AV20Errors);
            AV13Status = "u";
            AssignAttri("", false, "AV13Status", AV13Status);
         }
         if ( ! AV22isOK )
         {
            AV25GXV2 = 1;
            while ( AV25GXV2 <= AV20Errors.Count )
            {
               AV21Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV20Errors.Item(AV25GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV21Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV21Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV25GXV2 = (int)(AV25GXV2+1);
            }
         }
         else
         {
            context.CommitDataStores("k2bfsg.eventsubscriptionentry",pr_default);
         }
         /* Execute user subroutine: 'UPDATEACTIONSTATUS' */
         S192 ();
         if (returnInSub) return;
      }

      protected void S192( )
      {
         /* 'UPDATEACTIONSTATUS' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Status, "u") == 0 )
         {
            bttSubscribeunsubscribe_Caption = context.GetMessage( "K2BT_GAM_Subscribe", "");
            AssignProp("", false, bttSubscribeunsubscribe_Internalname, "Caption", bttSubscribeunsubscribe_Caption, true);
         }
         else
         {
            bttSubscribeunsubscribe_Caption = context.GetMessage( "K2BT_GAM_Unsubscribe", "");
            AssignProp("", false, bttSubscribeunsubscribe_Internalname, "Caption", bttSubscribeunsubscribe_Caption, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E183J2( )
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
         AV18Id = (string)getParm(obj,1);
         AssignAttri("", false, "AV18Id", AV18Id);
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
         PA3J2( ) ;
         WS3J2( ) ;
         WE3J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243122137610", true, true);
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
         context.AddJavascriptSource("k2bfsg/eventsubscriptionentry.js", "?20243122137614", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavStatus.Name = "vSTATUS";
         cmbavStatus.WebTags = "";
         cmbavStatus.addItem("u", context.GetMessage( "Unsubscribed", ""), 0);
         cmbavStatus.addItem("s", context.GetMessage( "Subscribed", ""), 0);
         if ( cmbavStatus.ItemCount > 0 )
         {
            AV13Status = cmbavStatus.getValidValue(AV13Status);
            AssignAttri("", false, "AV13Status", AV13Status);
         }
         cmbavEvent.Name = "vEVENT";
         cmbavEvent.WebTags = "";
         cmbavEvent.addItem("user-update", context.GetMessage( "User - Update", ""), 0);
         cmbavEvent.addItem("user-insert", context.GetMessage( "User - Insert", ""), 0);
         cmbavEvent.addItem("user-delete", context.GetMessage( "User - Delete", ""), 0);
         cmbavEvent.addItem("user-updateroles", context.GetMessage( "User - Update Roles", ""), 0);
         cmbavEvent.addItem("user-getcustominfo", context.GetMessage( "User - Get Custom Information on GAMRemote Server", ""), 0);
         cmbavEvent.addItem("user-savecustominfo", context.GetMessage( "User - Save Custom Information on GAMRemote Client", ""), 0);
         cmbavEvent.addItem("role-insert", context.GetMessage( "Role - Insert", ""), 0);
         cmbavEvent.addItem("role-update", context.GetMessage( "Role - Update", ""), 0);
         cmbavEvent.addItem("role-delete", context.GetMessage( "Role - Delete", ""), 0);
         cmbavEvent.addItem("repository-login", context.GetMessage( "Repository - Login", ""), 0);
         cmbavEvent.addItem("repository-loginfailed", context.GetMessage( "Repository - Login Failed", ""), 0);
         cmbavEvent.addItem("repository-logout", context.GetMessage( "Repository - Logout", ""), 0);
         cmbavEvent.addItem("externalauthentication-response", context.GetMessage( "Repository - External Authentication Response", ""), 0);
         cmbavEvent.addItem("application-checkprmfail", context.GetMessage( "Application - Check Permission Fail", ""), 0);
         cmbavEvent.addItem("user-otp-validateuser", context.GetMessage( "User - One Time Password Valid User", ""), 0);
         cmbavEvent.addItem("user-otp-generatecode", context.GetMessage( "User - One Time Password Generate Code", ""), 0);
         cmbavEvent.addItem("user-otp-sendcode", context.GetMessage( "User - One Time Password Send Code", ""), 0);
         cmbavEvent.addItem("user-otp-validatecode", context.GetMessage( "User - One Time Password Validate Code", ""), 0);
         if ( cmbavEvent.ItemCount > 0 )
         {
            AV14Event = cmbavEvent.getValidValue(AV14Event);
            AssignAttri("", false, "AV14Event", AV14Event);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         bttSubscribeunsubscribe_Internalname = "SUBSCRIBEUNSUBSCRIBE";
         imgUpdate_Internalname = "UPDATE";
         imgDelete_Internalname = "DELETE";
         divActionscontainertableright_actions2_Internalname = "ACTIONSCONTAINERTABLERIGHT_ACTIONS2";
         divResponsivetable_containernode_actions2_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS2";
         edtavDescription_Internalname = "vDESCRIPTION";
         divTable_container_description_Internalname = "TABLE_CONTAINER_DESCRIPTION";
         cmbavStatus_Internalname = "vSTATUS";
         divTable_container_status_Internalname = "TABLE_CONTAINER_STATUS";
         cmbavEvent_Internalname = "vEVENT";
         divTable_container_event_Internalname = "TABLE_CONTAINER_EVENT";
         edtavFilename_Internalname = "vFILENAME";
         divTable_container_filename_Internalname = "TABLE_CONTAINER_FILENAME";
         edtavClassname_Internalname = "vCLASSNAME";
         divTable_container_classname_Internalname = "TABLE_CONTAINER_CLASSNAME";
         edtavMethodname_Internalname = "vMETHODNAME";
         divTable_container_methodname_Internalname = "TABLE_CONTAINER_METHODNAME";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions1_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS1";
         divResponsivetable_containernode_actions1_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS1";
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
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Caption = context.GetMessage( "GX_BtnEnter", "");
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         edtavMethodname_Jsonclick = "";
         edtavMethodname_Enabled = 1;
         edtavClassname_Jsonclick = "";
         edtavClassname_Enabled = 1;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         cmbavEvent_Jsonclick = "";
         cmbavEvent.Enabled = 1;
         cmbavStatus_Jsonclick = "";
         cmbavStatus.Enabled = 1;
         edtavDescription_Jsonclick = "";
         edtavDescription_Enabled = 1;
         imgDelete_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         bttSubscribeunsubscribe_Caption = "";
         bttSubscribeunsubscribe_Visible = 1;
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( 0);
         General_Title = context.GetMessage( "K2BT_General", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Event Subscription Entry", "");
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
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'},{ctrl:'SUBSCRIBEUNSUBSCRIBE',prop:'Visible'}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E113J1',iparms:[{av:'AV18Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV18Id',fld:'vID',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E123J1',iparms:[{av:'AV18Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV18Id',fld:'vID',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E153J2',iparms:[{av:'AV18Id',fld:'vID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12Description',fld:'vDESCRIPTION',pic:''},{av:'cmbavEvent'},{av:'AV14Event',fld:'vEVENT',pic:''},{av:'AV15FileName',fld:'vFILENAME',pic:''},{av:'AV16ClassName',fld:'vCLASSNAME',pic:''},{av:'AV17MethodName',fld:'vMETHODNAME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_CANCEL'","{handler:'E163J2',iparms:[{av:'AV18Id',fld:'vID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("'E_SUBSCRIBEUNSUBSCRIBE'","{handler:'E173J2',iparms:[{av:'cmbavStatus'},{av:'AV13Status',fld:'vSTATUS',pic:''},{av:'AV18Id',fld:'vID',pic:''}]");
         setEventMetadata("'E_SUBSCRIBEUNSUBSCRIBE'",",oparms:[{av:'cmbavStatus'},{av:'AV13Status',fld:'vSTATUS',pic:''},{ctrl:'SUBSCRIBEUNSUBSCRIBE',prop:'Caption'}]}");
         setEventMetadata("VALIDV_STATUS","{handler:'Validv_Status',iparms:[]");
         setEventMetadata("VALIDV_STATUS",",oparms:[]}");
         setEventMetadata("VALIDV_EVENT","{handler:'Validv_Event',iparms:[]");
         setEventMetadata("VALIDV_EVENT",",oparms:[]}");
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
         wcpOAV18Id = "";
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
         bttSubscribeunsubscribe_Jsonclick = "";
         imgUpdate_gximage = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_gximage = "";
         imgDelete_Jsonclick = "";
         AV12Description = "";
         AV13Status = "";
         AV14Event = "";
         AV15FileName = "";
         AV16ClassName = "";
         AV17MethodName = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19EventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
         AV20Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV21Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.eventsubscriptionentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.eventsubscriptionentry__default(),
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
      private int bttSubscribeunsubscribe_Visible ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int edtavDescription_Enabled ;
      private int edtavFilename_Enabled ;
      private int edtavClassname_Enabled ;
      private int edtavMethodname_Enabled ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int AV24GXV1 ;
      private int AV25GXV2 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV18Id ;
      private string wcpOGx_mode ;
      private string wcpOAV18Id ;
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
      private string bttSubscribeunsubscribe_Internalname ;
      private string bttSubscribeunsubscribe_Caption ;
      private string bttSubscribeunsubscribe_Jsonclick ;
      private string imgUpdate_gximage ;
      private string sImgUrl ;
      private string imgUpdate_Internalname ;
      private string imgUpdate_Tooltiptext ;
      private string imgUpdate_Jsonclick ;
      private string imgDelete_gximage ;
      private string imgDelete_Internalname ;
      private string imgDelete_Tooltiptext ;
      private string imgDelete_Jsonclick ;
      private string divTable_container_description_Internalname ;
      private string edtavDescription_Internalname ;
      private string AV12Description ;
      private string edtavDescription_Jsonclick ;
      private string divTable_container_status_Internalname ;
      private string cmbavStatus_Internalname ;
      private string AV13Status ;
      private string cmbavStatus_Jsonclick ;
      private string divTable_container_event_Internalname ;
      private string cmbavEvent_Internalname ;
      private string AV14Event ;
      private string cmbavEvent_Jsonclick ;
      private string divTable_container_filename_Internalname ;
      private string edtavFilename_Internalname ;
      private string AV15FileName ;
      private string edtavFilename_Jsonclick ;
      private string divTable_container_classname_Internalname ;
      private string edtavClassname_Internalname ;
      private string AV16ClassName ;
      private string edtavClassname_Jsonclick ;
      private string divTable_container_methodname_Internalname ;
      private string edtavMethodname_Internalname ;
      private string AV17MethodName ;
      private string edtavMethodname_Jsonclick ;
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
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV22isOK ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Id ;
      private GXCombobox cmbavStatus ;
      private GXCombobox cmbavEvent ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV20Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscription AV19EventSubscription ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV21Error ;
   }

   public class eventsubscriptionentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class eventsubscriptionentry__default : DataStoreHelperBase, IDataStoreHelper
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
