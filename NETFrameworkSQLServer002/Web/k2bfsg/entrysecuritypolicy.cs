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
   public class entrysecuritypolicy : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entrysecuritypolicy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entrysecuritypolicy( IGxContext context )
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
         this.AV15Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV15Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAllowmultipleconcurrentwebsessions = new GXCombobox();
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
                  AV15Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
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
         PA402( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START402( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entrysecuritypolicy.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GENERALATTRIBUTES_Title", StringUtil.RTrim( Generalattributes_Title));
         GxWebStd.gx_hidden_field( context, "GENERALATTRIBUTES_Collapsible", StringUtil.BoolToStr( Generalattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERALATTRIBUTES_Open", StringUtil.BoolToStr( Generalattributes_Open));
         GxWebStd.gx_hidden_field( context, "GENERALATTRIBUTES_Showborders", StringUtil.BoolToStr( Generalattributes_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERALATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Generalattributes_Containseditableform));
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
            WE402( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT402( ) ;
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
         return formatLink("k2bfsg.entrysecuritypolicy.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntrySecurityPolicy" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_SecurityPolicy", "") ;
      }

      protected void WB400( )
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
            ucGeneralattributes.SetProperty("Title", Generalattributes_Title);
            ucGeneralattributes.SetProperty("Collapsible", Generalattributes_Collapsible);
            ucGeneralattributes.SetProperty("Open", Generalattributes_Open);
            ucGeneralattributes.SetProperty("ShowBorders", Generalattributes_Showborders);
            ucGeneralattributes.SetProperty("ContainsEditableForm", Generalattributes_Containseditableform);
            ucGeneralattributes.Render(context, "k2bt_component", Generalattributes_Internalname, "GENERALATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GENERALATTRIBUTESContainer"+"Generalattributes_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGeneralattributes_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_generalattributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgUpdate_gximage, "")==0) ? "GX_Image_K2BActionUpdate_Class" : "GX_Image_"+imgUpdate_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgUpdate_Bitmap;
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11401_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12401_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_id_Internalname, divTable_container_id_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, context.GetMessage( "K2BT_GAM_Id", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Id), 12, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV15Id), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_guid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, context.GetMessage( "K2BT_GUID", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV16GUID), StringUtil.RTrim( context.localUtil.Format( AV16GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavGuid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_name_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "K2BT_GAM_Name", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV17Name), StringUtil.RTrim( context.localUtil.Format( AV17Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_group_start( context, grpOnlyweb_Internalname, context.GetMessage( "K2BT_GAM_OnlyWeb", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_onlyweb_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_allowmultipleconcurrentwebsessions_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavAllowmultipleconcurrentwebsessions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAllowmultipleconcurrentwebsessions_Internalname, context.GetMessage( "K2BT_GAM_AllowMultipleConcurrentWebSessions", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAllowmultipleconcurrentwebsessions, cmbavAllowmultipleconcurrentwebsessions_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0)), 1, cmbavAllowmultipleconcurrentwebsessions_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavAllowmultipleconcurrentwebsessions.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute_Trn", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            cmbavAllowmultipleconcurrentwebsessions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
            AssignProp("", false, cmbavAllowmultipleconcurrentwebsessions_Internalname, "Values", (string)(cmbavAllowmultipleconcurrentwebsessions.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_websessiontimeout_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavWebsessiontimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWebsessiontimeout_Internalname, context.GetMessage( "K2BT_GAM_WebSessionTimeout", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWebsessiontimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19WebSessionTimeout), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19WebSessionTimeout), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWebsessiontimeout_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavWebsessiontimeout_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpOnlysmartdevices_Internalname, context.GetMessage( "K2BT_GAM_OnlySmartDevices", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_onlysmartdevices_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_oauthtokenexpire_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauthtokenexpire_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauthtokenexpire_Internalname, context.GetMessage( "K2BT_GAM_OauthTokenExpire", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauthtokenexpire_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20OauthTokenExpire), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20OauthTokenExpire), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauthtokenexpire_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauthtokenexpire_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_oauthtokenmaximumrenovations_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavOauthtokenmaximumrenovations_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauthtokenmaximumrenovations_Internalname, context.GetMessage( "K2BT_GAM_OauthTokenMaximumRenovation", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauthtokenmaximumrenovations_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21OauthTokenMaximumRenovations), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21OauthTokenMaximumRenovations), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauthtokenmaximumrenovations_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavOauthtokenmaximumrenovations_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpGeneral_Internalname, context.GetMessage( "K2BT_GAM_PasswordConfigurations", ""), 1, 0, "px", 0, "px", "Group_Tabular", "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingroupresponsivetable_general_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_periodchangepassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavPeriodchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPeriodchangepassword_Internalname, context.GetMessage( "K2BT_GAM_PeriodChangePassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPeriodchangepassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22PeriodChangePassword), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22PeriodChangePassword), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPeriodchangepassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavPeriodchangepassword_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_minimumtimetochangepasswords_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumtimetochangepasswords_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumtimetochangepasswords_Internalname, context.GetMessage( "K2BT_GAM_MinimumTimeToChangePassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumtimetochangepasswords_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23MinimumTimeToChangePasswords), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23MinimumTimeToChangePasswords), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumtimetochangepasswords_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumtimetochangepasswords_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_minimumlengthpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumlengthpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumlengthpassword_Internalname, context.GetMessage( "K2BT_GAM_MinimumLengthPassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumlengthpassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24MinimumLengthPassword), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24MinimumLengthPassword), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumlengthpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumlengthpassword_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_minimumnumericalcharacterpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumnumericalcharacterpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumnumericalcharacterpassword_Internalname, context.GetMessage( "K2BT_GAM_MinimumNumericalCharacterPassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumnumericalcharacterpassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25MinimumNumericalCharacterPassword), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25MinimumNumericalCharacterPassword), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumnumericalcharacterpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumnumericalcharacterpassword_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_minimumuppercasecharacterspassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumuppercasecharacterspassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumuppercasecharacterspassword_Internalname, context.GetMessage( "K2BT_GAM_MinimumUpperCaseCharactersPassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumuppercasecharacterspassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26MinimumUpperCaseCharactersPassword), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26MinimumUpperCaseCharactersPassword), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumuppercasecharacterspassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumuppercasecharacterspassword_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_minimumspecialcharacterspassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMinimumspecialcharacterspassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMinimumspecialcharacterspassword_Internalname, context.GetMessage( "K2BT_GAM_MinimumSpecialCharactersPassword", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMinimumspecialcharacterspassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27MinimumSpecialCharactersPassword), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27MinimumSpecialCharactersPassword), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMinimumspecialcharacterspassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMinimumspecialcharacterspassword_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_maximumpasswordhistoryentries_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMaximumpasswordhistoryentries_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMaximumpasswordhistoryentries_Internalname, context.GetMessage( "K2BT_GAM_MaximumPasswordHistoryEntries", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMaximumpasswordhistoryentries_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28MaximumPasswordHistoryEntries), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28MaximumPasswordHistoryEntries), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMaximumpasswordhistoryentries_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMaximumpasswordhistoryentries_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntrySecurityPolicy.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e13401_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntrySecurityPolicy.htm");
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

      protected void START402( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_SecurityPolicy", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP400( ) ;
      }

      protected void WS402( )
      {
         START402( ) ;
         EVT402( ) ;
      }

      protected void EVT402( )
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
                              E14402 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E15402 ();
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
                                    E16402 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E17402 ();
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

      protected void WE402( )
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

      protected void PA402( )
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
         if ( cmbavAllowmultipleconcurrentwebsessions.ItemCount > 0 )
         {
            AV18AllowMultipleConcurrentWebSessions = (short)(Math.Round(NumberUtil.Val( cmbavAllowmultipleconcurrentwebsessions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18AllowMultipleConcurrentWebSessions", StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAllowmultipleconcurrentwebsessions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
            AssignProp("", false, cmbavAllowmultipleconcurrentwebsessions_Internalname, "Values", cmbavAllowmultipleconcurrentwebsessions.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF402( ) ;
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

      protected void RF402( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15402 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E17402 ();
            WB400( ) ;
         }
      }

      protected void send_integrity_lvl_hashes402( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP400( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14402 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            Generalattributes_Title = cgiGet( "GENERALATTRIBUTES_Title");
            Generalattributes_Collapsible = StringUtil.StrToBool( cgiGet( "GENERALATTRIBUTES_Collapsible"));
            Generalattributes_Open = StringUtil.StrToBool( cgiGet( "GENERALATTRIBUTES_Open"));
            Generalattributes_Showborders = StringUtil.StrToBool( cgiGet( "GENERALATTRIBUTES_Showborders"));
            Generalattributes_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERALATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            AV15Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
            AV16GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV16GUID", AV16GUID);
            AV17Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV17Name", AV17Name);
            cmbavAllowmultipleconcurrentwebsessions.CurrentValue = cgiGet( cmbavAllowmultipleconcurrentwebsessions_Internalname);
            AV18AllowMultipleConcurrentWebSessions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavAllowmultipleconcurrentwebsessions_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18AllowMultipleConcurrentWebSessions", StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWebsessiontimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWebsessiontimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWEBSESSIONTIMEOUT");
               GX_FocusControl = edtavWebsessiontimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19WebSessionTimeout = 0;
               AssignAttri("", false, "AV19WebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV19WebSessionTimeout), 4, 0));
            }
            else
            {
               AV19WebSessionTimeout = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavWebsessiontimeout_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19WebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV19WebSessionTimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOauthtokenexpire_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOauthtokenexpire_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOAUTHTOKENEXPIRE");
               GX_FocusControl = edtavOauthtokenexpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20OauthTokenExpire = 0;
               AssignAttri("", false, "AV20OauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV20OauthTokenExpire), 4, 0));
            }
            else
            {
               AV20OauthTokenExpire = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOauthtokenexpire_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20OauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV20OauthTokenExpire), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOauthtokenmaximumrenovations_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOauthtokenmaximumrenovations_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOAUTHTOKENMAXIMUMRENOVATIONS");
               GX_FocusControl = edtavOauthtokenmaximumrenovations_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21OauthTokenMaximumRenovations = 0;
               AssignAttri("", false, "AV21OauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV21OauthTokenMaximumRenovations), 4, 0));
            }
            else
            {
               AV21OauthTokenMaximumRenovations = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOauthtokenmaximumrenovations_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21OauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV21OauthTokenMaximumRenovations), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPeriodchangepassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPeriodchangepassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPERIODCHANGEPASSWORD");
               GX_FocusControl = edtavPeriodchangepassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22PeriodChangePassword = 0;
               AssignAttri("", false, "AV22PeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV22PeriodChangePassword), 4, 0));
            }
            else
            {
               AV22PeriodChangePassword = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavPeriodchangepassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22PeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV22PeriodChangePassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumtimetochangepasswords_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumtimetochangepasswords_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMTIMETOCHANGEPASSWORDS");
               GX_FocusControl = edtavMinimumtimetochangepasswords_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23MinimumTimeToChangePasswords = 0;
               AssignAttri("", false, "AV23MinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV23MinimumTimeToChangePasswords), 4, 0));
            }
            else
            {
               AV23MinimumTimeToChangePasswords = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumtimetochangepasswords_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23MinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV23MinimumTimeToChangePasswords), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumlengthpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumlengthpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMLENGTHPASSWORD");
               GX_FocusControl = edtavMinimumlengthpassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24MinimumLengthPassword = 0;
               AssignAttri("", false, "AV24MinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV24MinimumLengthPassword), 4, 0));
            }
            else
            {
               AV24MinimumLengthPassword = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumlengthpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24MinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV24MinimumLengthPassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumnumericalcharacterpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumnumericalcharacterpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMNUMERICALCHARACTERPASSWORD");
               GX_FocusControl = edtavMinimumnumericalcharacterpassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25MinimumNumericalCharacterPassword = 0;
               AssignAttri("", false, "AV25MinimumNumericalCharacterPassword", StringUtil.LTrimStr( (decimal)(AV25MinimumNumericalCharacterPassword), 4, 0));
            }
            else
            {
               AV25MinimumNumericalCharacterPassword = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumnumericalcharacterpassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25MinimumNumericalCharacterPassword", StringUtil.LTrimStr( (decimal)(AV25MinimumNumericalCharacterPassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumuppercasecharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumuppercasecharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMUPPERCASECHARACTERSPASSWORD");
               GX_FocusControl = edtavMinimumuppercasecharacterspassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26MinimumUpperCaseCharactersPassword = 0;
               AssignAttri("", false, "AV26MinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV26MinimumUpperCaseCharactersPassword), 4, 0));
            }
            else
            {
               AV26MinimumUpperCaseCharactersPassword = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumuppercasecharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26MinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV26MinimumUpperCaseCharactersPassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMinimumspecialcharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMinimumspecialcharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMINIMUMSPECIALCHARACTERSPASSWORD");
               GX_FocusControl = edtavMinimumspecialcharacterspassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27MinimumSpecialCharactersPassword = 0;
               AssignAttri("", false, "AV27MinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV27MinimumSpecialCharactersPassword), 4, 0));
            }
            else
            {
               AV27MinimumSpecialCharactersPassword = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMinimumspecialcharacterspassword_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27MinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV27MinimumSpecialCharactersPassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMaximumpasswordhistoryentries_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMaximumpasswordhistoryentries_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMAXIMUMPASSWORDHISTORYENTRIES");
               GX_FocusControl = edtavMaximumpasswordhistoryentries_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28MaximumPasswordHistoryEntries = 0;
               AssignAttri("", false, "AV28MaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV28MaximumPasswordHistoryEntries), 4, 0));
            }
            else
            {
               AV28MaximumPasswordHistoryEntries = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMaximumpasswordhistoryentries_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28MaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV28MaximumPasswordHistoryEntries), 4, 0));
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

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         Generalattributes_Containseditableform = true;
         ucGeneralattributes.SendProperty(context, "", false, Generalattributes_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( Generalattributes_Containseditableform));
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         cmbavAllowmultipleconcurrentwebsessions.Enabled = 1;
         AssignProp("", false, cmbavAllowmultipleconcurrentwebsessions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAllowmultipleconcurrentwebsessions.Enabled), 5, 0), true);
         edtavWebsessiontimeout_Enabled = 1;
         AssignProp("", false, edtavWebsessiontimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWebsessiontimeout_Enabled), 5, 0), true);
         edtavOauthtokenexpire_Enabled = 1;
         AssignProp("", false, edtavOauthtokenexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauthtokenexpire_Enabled), 5, 0), true);
         edtavOauthtokenmaximumrenovations_Enabled = 1;
         AssignProp("", false, edtavOauthtokenmaximumrenovations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauthtokenmaximumrenovations_Enabled), 5, 0), true);
         edtavPeriodchangepassword_Enabled = 1;
         AssignProp("", false, edtavPeriodchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPeriodchangepassword_Enabled), 5, 0), true);
         edtavMinimumtimetochangepasswords_Enabled = 1;
         AssignProp("", false, edtavMinimumtimetochangepasswords_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumtimetochangepasswords_Enabled), 5, 0), true);
         edtavMinimumlengthpassword_Enabled = 1;
         AssignProp("", false, edtavMinimumlengthpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumlengthpassword_Enabled), 5, 0), true);
         edtavMinimumnumericalcharacterpassword_Enabled = 1;
         AssignProp("", false, edtavMinimumnumericalcharacterpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumnumericalcharacterpassword_Enabled), 5, 0), true);
         edtavMinimumuppercasecharacterspassword_Enabled = 1;
         AssignProp("", false, edtavMinimumuppercasecharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumuppercasecharacterspassword_Enabled), 5, 0), true);
         edtavMinimumspecialcharacterspassword_Enabled = 1;
         AssignProp("", false, edtavMinimumspecialcharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumspecialcharacterspassword_Enabled), 5, 0), true);
         edtavMaximumpasswordhistoryentries_Enabled = 1;
         AssignProp("", false, edtavMaximumpasswordhistoryentries_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMaximumpasswordhistoryentries_Enabled), 5, 0), true);
         edtavName_Enabled = 1;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         AV16GUID = "";
         AssignAttri("", false, "AV16GUID", AV16GUID);
         AV17Name = "";
         AssignAttri("", false, "AV17Name", AV17Name);
         AV18AllowMultipleConcurrentWebSessions = 1;
         AssignAttri("", false, "AV18AllowMultipleConcurrentWebSessions", StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
         AV19WebSessionTimeout = 0;
         AssignAttri("", false, "AV19WebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV19WebSessionTimeout), 4, 0));
         AV20OauthTokenExpire = 0;
         AssignAttri("", false, "AV20OauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV20OauthTokenExpire), 4, 0));
         AV21OauthTokenMaximumRenovations = 0;
         AssignAttri("", false, "AV21OauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV21OauthTokenMaximumRenovations), 4, 0));
         AV22PeriodChangePassword = 0;
         AssignAttri("", false, "AV22PeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV22PeriodChangePassword), 4, 0));
         AV23MinimumTimeToChangePasswords = 0;
         AssignAttri("", false, "AV23MinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV23MinimumTimeToChangePasswords), 4, 0));
         AV24MinimumLengthPassword = 0;
         AssignAttri("", false, "AV24MinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV24MinimumLengthPassword), 4, 0));
         AV25MinimumNumericalCharacterPassword = 0;
         AssignAttri("", false, "AV25MinimumNumericalCharacterPassword", StringUtil.LTrimStr( (decimal)(AV25MinimumNumericalCharacterPassword), 4, 0));
         AV26MinimumUpperCaseCharactersPassword = 0;
         AssignAttri("", false, "AV26MinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV26MinimumUpperCaseCharactersPassword), 4, 0));
         AV27MinimumSpecialCharactersPassword = 0;
         AssignAttri("", false, "AV27MinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV27MinimumSpecialCharactersPassword), 4, 0));
         AV28MaximumPasswordHistoryEntries = 0;
         AssignAttri("", false, "AV28MaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV28MaximumPasswordHistoryEntries), 4, 0));
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV5SecurityPolicy.load( (int)(AV15Id));
            AV15Id = AV5SecurityPolicy.gxTpr_Id;
            AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
            AV16GUID = AV5SecurityPolicy.gxTpr_Guid;
            AssignAttri("", false, "AV16GUID", AV16GUID);
            AV17Name = AV5SecurityPolicy.gxTpr_Name;
            AssignAttri("", false, "AV17Name", AV17Name);
            AV18AllowMultipleConcurrentWebSessions = AV5SecurityPolicy.gxTpr_Allowmultipleconcurrentwebsessions;
            AssignAttri("", false, "AV18AllowMultipleConcurrentWebSessions", StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
            AV19WebSessionTimeout = (short)(AV5SecurityPolicy.gxTpr_Websessiontimeout);
            AssignAttri("", false, "AV19WebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV19WebSessionTimeout), 4, 0));
            AV20OauthTokenExpire = (short)(AV5SecurityPolicy.gxTpr_Oauthtokenexpire);
            AssignAttri("", false, "AV20OauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV20OauthTokenExpire), 4, 0));
            AV21OauthTokenMaximumRenovations = AV5SecurityPolicy.gxTpr_Oauthtokenmaximumrenovations;
            AssignAttri("", false, "AV21OauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV21OauthTokenMaximumRenovations), 4, 0));
            AV22PeriodChangePassword = AV5SecurityPolicy.gxTpr_Periodchangepassword;
            AssignAttri("", false, "AV22PeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV22PeriodChangePassword), 4, 0));
            AV23MinimumTimeToChangePasswords = (short)(AV5SecurityPolicy.gxTpr_Minimumtimetochangepasswords);
            AssignAttri("", false, "AV23MinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV23MinimumTimeToChangePasswords), 4, 0));
            AV24MinimumLengthPassword = AV5SecurityPolicy.gxTpr_Minimumlengthpassword;
            AssignAttri("", false, "AV24MinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV24MinimumLengthPassword), 4, 0));
            AV25MinimumNumericalCharacterPassword = AV5SecurityPolicy.gxTpr_Minimumnumericcharacterspassword;
            AssignAttri("", false, "AV25MinimumNumericalCharacterPassword", StringUtil.LTrimStr( (decimal)(AV25MinimumNumericalCharacterPassword), 4, 0));
            AV26MinimumUpperCaseCharactersPassword = AV5SecurityPolicy.gxTpr_Minimumuppercasecharacterspassword;
            AssignAttri("", false, "AV26MinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV26MinimumUpperCaseCharactersPassword), 4, 0));
            AV27MinimumSpecialCharactersPassword = AV5SecurityPolicy.gxTpr_Minimumspecialcharacterspassword;
            AssignAttri("", false, "AV27MinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV27MinimumSpecialCharactersPassword), 4, 0));
            AV28MaximumPasswordHistoryEntries = AV5SecurityPolicy.gxTpr_Maximumpasswordhistoryentries;
            AssignAttri("", false, "AV28MaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV28MaximumPasswordHistoryEntries), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttConfirm_Visible = 0;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            cmbavAllowmultipleconcurrentwebsessions.Enabled = 0;
            AssignProp("", false, cmbavAllowmultipleconcurrentwebsessions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAllowmultipleconcurrentwebsessions.Enabled), 5, 0), true);
            edtavWebsessiontimeout_Enabled = 0;
            AssignProp("", false, edtavWebsessiontimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWebsessiontimeout_Enabled), 5, 0), true);
            edtavOauthtokenexpire_Enabled = 0;
            AssignProp("", false, edtavOauthtokenexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauthtokenexpire_Enabled), 5, 0), true);
            edtavOauthtokenmaximumrenovations_Enabled = 0;
            AssignProp("", false, edtavOauthtokenmaximumrenovations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauthtokenmaximumrenovations_Enabled), 5, 0), true);
            edtavPeriodchangepassword_Enabled = 0;
            AssignProp("", false, edtavPeriodchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPeriodchangepassword_Enabled), 5, 0), true);
            edtavMinimumtimetochangepasswords_Enabled = 0;
            AssignProp("", false, edtavMinimumtimetochangepasswords_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumtimetochangepasswords_Enabled), 5, 0), true);
            edtavMinimumlengthpassword_Enabled = 0;
            AssignProp("", false, edtavMinimumlengthpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumlengthpassword_Enabled), 5, 0), true);
            edtavMinimumnumericalcharacterpassword_Enabled = 0;
            AssignProp("", false, edtavMinimumnumericalcharacterpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumnumericalcharacterpassword_Enabled), 5, 0), true);
            edtavMinimumuppercasecharacterspassword_Enabled = 0;
            AssignProp("", false, edtavMinimumuppercasecharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumuppercasecharacterspassword_Enabled), 5, 0), true);
            edtavMinimumspecialcharacterspassword_Enabled = 0;
            AssignProp("", false, edtavMinimumspecialcharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMinimumspecialcharacterspassword_Enabled), 5, 0), true);
            edtavMaximumpasswordhistoryentries_Enabled = 0;
            AssignProp("", false, edtavMaximumpasswordhistoryentries_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMaximumpasswordhistoryentries_Enabled), 5, 0), true);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14402 ();
         if (returnInSub) return;
      }

      protected void E14402( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E15402( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         divTable_container_id_Visible = 0;
         AssignProp("", false, divTable_container_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable_container_id_Visible), 5, 0), true);
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
         cmbavAllowmultipleconcurrentwebsessions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
         AssignProp("", false, cmbavAllowmultipleconcurrentwebsessions_Internalname, "Values", cmbavAllowmultipleconcurrentwebsessions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SecurityPolicy", AV5SecurityPolicy);
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

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) )
         {
            AV5SecurityPolicy.gxTpr_Id = (int)(AV15Id);
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV5SecurityPolicy.load( (int)(AV15Id));
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               AV5SecurityPolicy.gxTpr_Name = AV17Name;
               AV5SecurityPolicy.gxTpr_Allowmultipleconcurrentwebsessions = AV18AllowMultipleConcurrentWebSessions;
               AV5SecurityPolicy.gxTpr_Websessiontimeout = AV19WebSessionTimeout;
               AV5SecurityPolicy.gxTpr_Oauthtokenexpire = AV20OauthTokenExpire;
               AV5SecurityPolicy.gxTpr_Oauthtokenmaximumrenovations = AV21OauthTokenMaximumRenovations;
               AV5SecurityPolicy.gxTpr_Periodchangepassword = AV22PeriodChangePassword;
               AV5SecurityPolicy.gxTpr_Minimumtimetochangepasswords = AV23MinimumTimeToChangePasswords;
               AV5SecurityPolicy.gxTpr_Minimumlengthpassword = AV24MinimumLengthPassword;
               AV5SecurityPolicy.gxTpr_Minimumnumericcharacterspassword = AV25MinimumNumericalCharacterPassword;
               AV5SecurityPolicy.gxTpr_Minimumuppercasecharacterspassword = AV26MinimumUpperCaseCharactersPassword;
               AV5SecurityPolicy.gxTpr_Minimumspecialcharacterspassword = AV27MinimumSpecialCharactersPassword;
               AV5SecurityPolicy.gxTpr_Maximumpasswordhistoryentries = AV28MaximumPasswordHistoryEntries;
               AV5SecurityPolicy.save();
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV5SecurityPolicy.delete();
            }
            if ( AV5SecurityPolicy.success() )
            {
               AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV9Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Thesecuritypolicywascreated", ""), AV17Name, "", "", "", "", "", "", "", "");
               }
               else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV9Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Thesecuritypolicywasupdated", ""), AV17Name, "", "", "", "", "", "", "", "");
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  AV9Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Thesecuritypolicywasdeleted", ""), AV17Name, "", "", "", "", "", "", "", "");
               }
               new k2btoolsmessagequeueadd(context ).execute(  AV9Message) ;
               context.CommitDataStores("k2bfsg.entrysecuritypolicy",pr_default);
               CallWebObject(formatLink("k2bfsg.wwsecuritypolicy.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV7Errors = AV5SecurityPolicy.geterrors();
               AV30GXV1 = 1;
               while ( AV30GXV1 <= AV7Errors.Count )
               {
                  AV6Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV7Errors.Item(AV30GXV1));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV6Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV6Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV30GXV1 = (int)(AV30GXV1+1);
               }
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E16402 ();
         if (returnInSub) return;
      }

      protected void E16402( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SecurityPolicy", AV5SecurityPolicy);
      }

      protected void S152( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entrysecuritypolicy.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S162( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entrysecuritypolicy.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwsecuritypolicy.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E17402( )
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
         AV15Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
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
         PA402( ) ;
         WS402( ) ;
         WE402( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221374347", true, true);
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
         context.AddJavascriptSource("k2bfsg/entrysecuritypolicy.js", "?202431221374348", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAllowmultipleconcurrentwebsessions.Name = "vALLOWMULTIPLECONCURRENTWEBSESSIONS";
         cmbavAllowmultipleconcurrentwebsessions.WebTags = "";
         cmbavAllowmultipleconcurrentwebsessions.addItem("1", context.GetMessage( "Yes, from different IP address", ""), 0);
         cmbavAllowmultipleconcurrentwebsessions.addItem("2", context.GetMessage( "Yes, from same IP address", ""), 0);
         cmbavAllowmultipleconcurrentwebsessions.addItem("3", context.GetMessage( "No", ""), 0);
         if ( cmbavAllowmultipleconcurrentwebsessions.ItemCount > 0 )
         {
            AV18AllowMultipleConcurrentWebSessions = (short)(Math.Round(NumberUtil.Val( cmbavAllowmultipleconcurrentwebsessions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18AllowMultipleConcurrentWebSessions", StringUtil.Str( (decimal)(AV18AllowMultipleConcurrentWebSessions), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
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
         cmbavAllowmultipleconcurrentwebsessions_Internalname = "vALLOWMULTIPLECONCURRENTWEBSESSIONS";
         divTable_container_allowmultipleconcurrentwebsessions_Internalname = "TABLE_CONTAINER_ALLOWMULTIPLECONCURRENTWEBSESSIONS";
         edtavWebsessiontimeout_Internalname = "vWEBSESSIONTIMEOUT";
         divTable_container_websessiontimeout_Internalname = "TABLE_CONTAINER_WEBSESSIONTIMEOUT";
         divMaingroupresponsivetable_onlyweb_Internalname = "MAINGROUPRESPONSIVETABLE_ONLYWEB";
         grpOnlyweb_Internalname = "ONLYWEB";
         edtavOauthtokenexpire_Internalname = "vOAUTHTOKENEXPIRE";
         divTable_container_oauthtokenexpire_Internalname = "TABLE_CONTAINER_OAUTHTOKENEXPIRE";
         edtavOauthtokenmaximumrenovations_Internalname = "vOAUTHTOKENMAXIMUMRENOVATIONS";
         divTable_container_oauthtokenmaximumrenovations_Internalname = "TABLE_CONTAINER_OAUTHTOKENMAXIMUMRENOVATIONS";
         divMaingroupresponsivetable_onlysmartdevices_Internalname = "MAINGROUPRESPONSIVETABLE_ONLYSMARTDEVICES";
         grpOnlysmartdevices_Internalname = "ONLYSMARTDEVICES";
         edtavPeriodchangepassword_Internalname = "vPERIODCHANGEPASSWORD";
         divTable_container_periodchangepassword_Internalname = "TABLE_CONTAINER_PERIODCHANGEPASSWORD";
         edtavMinimumtimetochangepasswords_Internalname = "vMINIMUMTIMETOCHANGEPASSWORDS";
         divTable_container_minimumtimetochangepasswords_Internalname = "TABLE_CONTAINER_MINIMUMTIMETOCHANGEPASSWORDS";
         edtavMinimumlengthpassword_Internalname = "vMINIMUMLENGTHPASSWORD";
         divTable_container_minimumlengthpassword_Internalname = "TABLE_CONTAINER_MINIMUMLENGTHPASSWORD";
         edtavMinimumnumericalcharacterpassword_Internalname = "vMINIMUMNUMERICALCHARACTERPASSWORD";
         divTable_container_minimumnumericalcharacterpassword_Internalname = "TABLE_CONTAINER_MINIMUMNUMERICALCHARACTERPASSWORD";
         edtavMinimumuppercasecharacterspassword_Internalname = "vMINIMUMUPPERCASECHARACTERSPASSWORD";
         divTable_container_minimumuppercasecharacterspassword_Internalname = "TABLE_CONTAINER_MINIMUMUPPERCASECHARACTERSPASSWORD";
         edtavMinimumspecialcharacterspassword_Internalname = "vMINIMUMSPECIALCHARACTERSPASSWORD";
         divTable_container_minimumspecialcharacterspassword_Internalname = "TABLE_CONTAINER_MINIMUMSPECIALCHARACTERSPASSWORD";
         edtavMaximumpasswordhistoryentries_Internalname = "vMAXIMUMPASSWORDHISTORYENTRIES";
         divTable_container_maximumpasswordhistoryentries_Internalname = "TABLE_CONTAINER_MAXIMUMPASSWORDHISTORYENTRIES";
         divMaingroupresponsivetable_general_Internalname = "MAINGROUPRESPONSIVETABLE_GENERAL";
         grpGeneral_Internalname = "GENERAL";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_generalattributes_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERALATTRIBUTES";
         divGeneralattributes_content_Internalname = "GENERALATTRIBUTES_CONTENT";
         Generalattributes_Internalname = "GENERALATTRIBUTES";
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
         edtavMaximumpasswordhistoryentries_Jsonclick = "";
         edtavMaximumpasswordhistoryentries_Enabled = 1;
         edtavMinimumspecialcharacterspassword_Jsonclick = "";
         edtavMinimumspecialcharacterspassword_Enabled = 1;
         edtavMinimumuppercasecharacterspassword_Jsonclick = "";
         edtavMinimumuppercasecharacterspassword_Enabled = 1;
         edtavMinimumnumericalcharacterpassword_Jsonclick = "";
         edtavMinimumnumericalcharacterpassword_Enabled = 1;
         edtavMinimumlengthpassword_Jsonclick = "";
         edtavMinimumlengthpassword_Enabled = 1;
         edtavMinimumtimetochangepasswords_Jsonclick = "";
         edtavMinimumtimetochangepasswords_Enabled = 1;
         edtavPeriodchangepassword_Jsonclick = "";
         edtavPeriodchangepassword_Enabled = 1;
         edtavOauthtokenmaximumrenovations_Jsonclick = "";
         edtavOauthtokenmaximumrenovations_Enabled = 1;
         edtavOauthtokenexpire_Jsonclick = "";
         edtavOauthtokenexpire_Enabled = 1;
         edtavWebsessiontimeout_Jsonclick = "";
         edtavWebsessiontimeout_Enabled = 1;
         cmbavAllowmultipleconcurrentwebsessions_Jsonclick = "";
         cmbavAllowmultipleconcurrentwebsessions.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         divTable_container_id_Visible = 1;
         imgDelete_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = context.GetMessage( "K2BT_UpdateAction", "");
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         Generalattributes_Containseditableform = Convert.ToBoolean( -1);
         Generalattributes_Showborders = Convert.ToBoolean( -1);
         Generalattributes_Open = Convert.ToBoolean( -1);
         Generalattributes_Collapsible = Convert.ToBoolean( 0);
         Generalattributes_Title = context.GetMessage( "K2BT_General", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_SecurityPolicy", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divTable_container_id_Visible',ctrl:'TABLE_CONTAINER_ID',prop:'Visible'},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{av:'cmbavAllowmultipleconcurrentwebsessions'},{av:'edtavWebsessiontimeout_Enabled',ctrl:'vWEBSESSIONTIMEOUT',prop:'Enabled'},{av:'edtavOauthtokenexpire_Enabled',ctrl:'vOAUTHTOKENEXPIRE',prop:'Enabled'},{av:'edtavOauthtokenmaximumrenovations_Enabled',ctrl:'vOAUTHTOKENMAXIMUMRENOVATIONS',prop:'Enabled'},{av:'edtavPeriodchangepassword_Enabled',ctrl:'vPERIODCHANGEPASSWORD',prop:'Enabled'},{av:'edtavMinimumtimetochangepasswords_Enabled',ctrl:'vMINIMUMTIMETOCHANGEPASSWORDS',prop:'Enabled'},{av:'edtavMinimumlengthpassword_Enabled',ctrl:'vMINIMUMLENGTHPASSWORD',prop:'Enabled'},{av:'edtavMinimumnumericalcharacterpassword_Enabled',ctrl:'vMINIMUMNUMERICALCHARACTERPASSWORD',prop:'Enabled'},{av:'edtavMinimumuppercasecharacterspassword_Enabled',ctrl:'vMINIMUMUPPERCASECHARACTERSPASSWORD',prop:'Enabled'},{av:'edtavMinimumspecialcharacterspassword_Enabled',ctrl:'vMINIMUMSPECIALCHARACTERSPASSWORD',prop:'Enabled'},{av:'edtavMaximumpasswordhistoryentries_Enabled',ctrl:'vMAXIMUMPASSWORDHISTORYENTRIES',prop:'Enabled'},{av:'edtavName_Enabled',ctrl:'vNAME',prop:'Enabled'},{av:'AV16GUID',fld:'vGUID',pic:''},{av:'AV17Name',fld:'vNAME',pic:''},{av:'AV18AllowMultipleConcurrentWebSessions',fld:'vALLOWMULTIPLECONCURRENTWEBSESSIONS',pic:'9'},{av:'AV19WebSessionTimeout',fld:'vWEBSESSIONTIMEOUT',pic:'ZZZ9'},{av:'AV20OauthTokenExpire',fld:'vOAUTHTOKENEXPIRE',pic:'ZZZ9'},{av:'AV21OauthTokenMaximumRenovations',fld:'vOAUTHTOKENMAXIMUMRENOVATIONS',pic:'ZZZ9'},{av:'AV22PeriodChangePassword',fld:'vPERIODCHANGEPASSWORD',pic:'ZZZ9'},{av:'AV23MinimumTimeToChangePasswords',fld:'vMINIMUMTIMETOCHANGEPASSWORDS',pic:'ZZZ9'},{av:'AV24MinimumLengthPassword',fld:'vMINIMUMLENGTHPASSWORD',pic:'ZZZ9'},{av:'AV25MinimumNumericalCharacterPassword',fld:'vMINIMUMNUMERICALCHARACTERPASSWORD',pic:'ZZZ9'},{av:'AV26MinimumUpperCaseCharactersPassword',fld:'vMINIMUMUPPERCASECHARACTERSPASSWORD',pic:'ZZZ9'},{av:'AV27MinimumSpecialCharactersPassword',fld:'vMINIMUMSPECIALCHARACTERSPASSWORD',pic:'ZZZ9'},{av:'AV28MaximumPasswordHistoryEntries',fld:'vMAXIMUMPASSWORDHISTORYENTRIES',pic:'ZZZ9'},{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("ENTER","{handler:'E16402',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV17Name',fld:'vNAME',pic:''},{av:'cmbavAllowmultipleconcurrentwebsessions'},{av:'AV18AllowMultipleConcurrentWebSessions',fld:'vALLOWMULTIPLECONCURRENTWEBSESSIONS',pic:'9'},{av:'AV19WebSessionTimeout',fld:'vWEBSESSIONTIMEOUT',pic:'ZZZ9'},{av:'AV20OauthTokenExpire',fld:'vOAUTHTOKENEXPIRE',pic:'ZZZ9'},{av:'AV21OauthTokenMaximumRenovations',fld:'vOAUTHTOKENMAXIMUMRENOVATIONS',pic:'ZZZ9'},{av:'AV22PeriodChangePassword',fld:'vPERIODCHANGEPASSWORD',pic:'ZZZ9'},{av:'AV23MinimumTimeToChangePasswords',fld:'vMINIMUMTIMETOCHANGEPASSWORDS',pic:'ZZZ9'},{av:'AV24MinimumLengthPassword',fld:'vMINIMUMLENGTHPASSWORD',pic:'ZZZ9'},{av:'AV25MinimumNumericalCharacterPassword',fld:'vMINIMUMNUMERICALCHARACTERPASSWORD',pic:'ZZZ9'},{av:'AV26MinimumUpperCaseCharactersPassword',fld:'vMINIMUMUPPERCASECHARACTERSPASSWORD',pic:'ZZZ9'},{av:'AV27MinimumSpecialCharactersPassword',fld:'vMINIMUMSPECIALCHARACTERSPASSWORD',pic:'ZZZ9'},{av:'AV28MaximumPasswordHistoryEntries',fld:'vMAXIMUMPASSWORDHISTORYENTRIES',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_UPDATE'","{handler:'E11401',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E12401',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E13401',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("VALIDV_ALLOWMULTIPLECONCURRENTWEBSESSIONS","{handler:'Validv_Allowmultipleconcurrentwebsessions',iparms:[]");
         setEventMetadata("VALIDV_ALLOWMULTIPLECONCURRENTWEBSESSIONS",",oparms:[]}");
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
         ClassString = "";
         StyleString = "";
         ucGeneralattributes = new GXUserControl();
         TempTags = "";
         imgUpdate_gximage = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_gximage = "";
         imgDelete_Jsonclick = "";
         AV16GUID = "";
         AV17Name = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV7Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrysecuritypolicy__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entrysecuritypolicy__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavGuid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18AllowMultipleConcurrentWebSessions ;
      private short AV19WebSessionTimeout ;
      private short AV20OauthTokenExpire ;
      private short AV21OauthTokenMaximumRenovations ;
      private short AV22PeriodChangePassword ;
      private short AV23MinimumTimeToChangePasswords ;
      private short AV24MinimumLengthPassword ;
      private short AV25MinimumNumericalCharacterPassword ;
      private short AV26MinimumUpperCaseCharactersPassword ;
      private short AV27MinimumSpecialCharactersPassword ;
      private short AV28MaximumPasswordHistoryEntries ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int divTable_container_id_Visible ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavWebsessiontimeout_Enabled ;
      private int edtavOauthtokenexpire_Enabled ;
      private int edtavOauthtokenmaximumrenovations_Enabled ;
      private int edtavPeriodchangepassword_Enabled ;
      private int edtavMinimumtimetochangepasswords_Enabled ;
      private int edtavMinimumlengthpassword_Enabled ;
      private int edtavMinimumnumericalcharacterpassword_Enabled ;
      private int edtavMinimumuppercasecharacterspassword_Enabled ;
      private int edtavMinimumspecialcharacterspassword_Enabled ;
      private int edtavMaximumpasswordhistoryentries_Enabled ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int AV30GXV1 ;
      private int idxLst ;
      private long AV15Id ;
      private long wcpOAV15Id ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Generalattributes_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Generalattributes_Internalname ;
      private string divGeneralattributes_content_Internalname ;
      private string divAttributescontainertable_generalattributes_Internalname ;
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
      private string AV16GUID ;
      private string edtavGuid_Jsonclick ;
      private string divTable_container_name_Internalname ;
      private string edtavName_Internalname ;
      private string AV17Name ;
      private string edtavName_Jsonclick ;
      private string grpOnlyweb_Internalname ;
      private string divMaingroupresponsivetable_onlyweb_Internalname ;
      private string divTable_container_allowmultipleconcurrentwebsessions_Internalname ;
      private string cmbavAllowmultipleconcurrentwebsessions_Internalname ;
      private string cmbavAllowmultipleconcurrentwebsessions_Jsonclick ;
      private string divTable_container_websessiontimeout_Internalname ;
      private string edtavWebsessiontimeout_Internalname ;
      private string edtavWebsessiontimeout_Jsonclick ;
      private string grpOnlysmartdevices_Internalname ;
      private string divMaingroupresponsivetable_onlysmartdevices_Internalname ;
      private string divTable_container_oauthtokenexpire_Internalname ;
      private string edtavOauthtokenexpire_Internalname ;
      private string edtavOauthtokenexpire_Jsonclick ;
      private string divTable_container_oauthtokenmaximumrenovations_Internalname ;
      private string edtavOauthtokenmaximumrenovations_Internalname ;
      private string edtavOauthtokenmaximumrenovations_Jsonclick ;
      private string grpGeneral_Internalname ;
      private string divMaingroupresponsivetable_general_Internalname ;
      private string divTable_container_periodchangepassword_Internalname ;
      private string edtavPeriodchangepassword_Internalname ;
      private string edtavPeriodchangepassword_Jsonclick ;
      private string divTable_container_minimumtimetochangepasswords_Internalname ;
      private string edtavMinimumtimetochangepasswords_Internalname ;
      private string edtavMinimumtimetochangepasswords_Jsonclick ;
      private string divTable_container_minimumlengthpassword_Internalname ;
      private string edtavMinimumlengthpassword_Internalname ;
      private string edtavMinimumlengthpassword_Jsonclick ;
      private string divTable_container_minimumnumericalcharacterpassword_Internalname ;
      private string edtavMinimumnumericalcharacterpassword_Internalname ;
      private string edtavMinimumnumericalcharacterpassword_Jsonclick ;
      private string divTable_container_minimumuppercasecharacterspassword_Internalname ;
      private string edtavMinimumuppercasecharacterspassword_Internalname ;
      private string edtavMinimumuppercasecharacterspassword_Jsonclick ;
      private string divTable_container_minimumspecialcharacterspassword_Internalname ;
      private string edtavMinimumspecialcharacterspassword_Internalname ;
      private string edtavMinimumspecialcharacterspassword_Jsonclick ;
      private string divTable_container_maximumpasswordhistoryentries_Internalname ;
      private string edtavMaximumpasswordhistoryentries_Internalname ;
      private string edtavMaximumpasswordhistoryentries_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
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
      private bool Generalattributes_Collapsible ;
      private bool Generalattributes_Open ;
      private bool Generalattributes_Showborders ;
      private bool Generalattributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private GXUserControl ucGeneralattributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCombobox cmbavAllowmultipleconcurrentwebsessions ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV5SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV6Error ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
   }

   public class entrysecuritypolicy__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class entrysecuritypolicy__default : DataStoreHelperBase, IDataStoreHelper
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
