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
namespace GeneXus.Programs {
   public class entitymanagersoporte : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entitymanagersoporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entitymanagersoporte( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_soporteID ,
                           string aP2_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV6soporteID = aP1_soporteID;
         this.AV8TabCode = aP2_TabCode;
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
                  AV6soporteID = (int)(Math.Round(NumberUtil.Val( GetPar( "soporteID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV6soporteID", StringUtil.LTrimStr( (decimal)(AV6soporteID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSOPORTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6soporteID), "ZZZZZZZZ9"), context));
                  AV8TabCode = GetPar( "TabCode");
                  AssignAttri("", false, "AV8TabCode", AV8TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
            return "soporte_Execute" ;
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
         PA2R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2R2( ) ;
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
         context.AddJavascriptSource("UserControls/K2BT_ModalWindowRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"Gx_mode","soporteID","TabCode"}) +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV19AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV21RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSOPORTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6soporteID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOPORTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6soporteID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV19AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV21RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSOPORTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6soporteID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOPORTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6soporteID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGE_COMPONENTNAME", AV23GE_ComponentName);
         GxWebStd.gx_hidden_field( context, "vGE_ENTITYMANAGERNAME", AV22GE_EntityManagerName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Title", StringUtil.RTrim( Componentscontainer_components_Title));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Collapsible", StringUtil.BoolToStr( Componentscontainer_components_Collapsible));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Open", StringUtil.BoolToStr( Componentscontainer_components_Open));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Showborders", StringUtil.BoolToStr( Componentscontainer_components_Showborders));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
         GxWebStd.gx_hidden_field( context, "TABLEMODAL_Modaltitle", StringUtil.RTrim( Tablemodal_Modaltitle));
         GxWebStd.gx_hidden_field( context, "TABLEMODAL_Visible", StringUtil.BoolToStr( Tablemodal_Visible));
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            WebComp_Tabstrip.componentjscripts();
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            WebComp_Componentwc_general.componentjscripts();
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            WebComp_Popupcomponent.componentjscripts();
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
            WE2R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2R2( ) ;
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
         return formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"Gx_mode","soporteID","TabCode"})  ;
      }

      public override string GetPgmname( )
      {
         return "EntityManagersoporte" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "soporte", "") ;
      }

      protected void WB2R0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_label_ctrl( context, lblK2bpgmdesc_Internalname, lblK2bpgmdesc_Caption, "", "", lblK2bpgmdesc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_EntityManagersoporte.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitleright_Internalname, 1, 0, "px", 0, "px", "K2BT_TitleRight", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "h1");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainer_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BackToWorkWithContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBacktoworkwith_Internalname, lblBacktoworkwith_Caption, lblBacktoworkwith_Link, "", lblBacktoworkwith_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_BackToWorkWith", 0, "", 1, 1, 0, 0, "HLP_EntityManagersoporte.htm");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_EntityManagerContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucComponentscontainer_components.SetProperty("Title", Componentscontainer_components_Title);
            ucComponentscontainer_components.SetProperty("Collapsible", Componentscontainer_components_Collapsible);
            ucComponentscontainer_components.SetProperty("Open", Componentscontainer_components_Open);
            ucComponentscontainer_components.SetProperty("ShowBorders", Componentscontainer_components_Showborders);
            ucComponentscontainer_components.Render(context, "k2bt_component", Componentscontainer_components_Internalname, "COMPONENTSCONTAINER_COMPONENTSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"COMPONENTSCONTAINER_COMPONENTSContainer"+"Componentscontainer_components_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentscontainer_components_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContainercollapsiblesection_components_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponents_components_tabssection_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0032"+"", StringUtil.RTrim( WebComp_Tabstrip_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0032"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
                  }
                  WebComp_Tabstrip.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablayouts_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentstabcontainer_components_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentcontainer_general_Internalname, divComponentcontainer_general_Visible, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0042"+"", StringUtil.RTrim( WebComp_Componentwc_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0042"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0042"+"");
                  }
                  WebComp_Componentwc_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTablemodal.Render(context, "k2bt_modalwindow", Tablemodal_Internalname, "TABLEMODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABLEMODALContainer"+"Tablemodal_ModalContent"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemodal_modalcontent_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0054"+"", StringUtil.RTrim( WebComp_Popupcomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0054"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0054"+"");
                  }
                  WebComp_Popupcomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2R2( )
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
         Form.Meta.addItem("description", context.GetMessage( "soporte", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2R0( ) ;
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLEMODAL.ONCLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E122R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E132R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E152R2 ();
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
                        if ( nCmpId == 32 )
                        {
                           OldTabstrip = cgiGet( "W0032");
                           if ( ( StringUtil.Len( OldTabstrip) == 0 ) || ( StringUtil.StrCmp(OldTabstrip, WebComp_Tabstrip_Component) != 0 ) )
                           {
                              WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", OldTabstrip, new Object[] {context} );
                              WebComp_Tabstrip.ComponentInit();
                              WebComp_Tabstrip.Name = "OldTabstrip";
                              WebComp_Tabstrip_Component = OldTabstrip;
                           }
                           if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
                           {
                              WebComp_Tabstrip.componentprocess("W0032", "", sEvt);
                           }
                           WebComp_Tabstrip_Component = OldTabstrip;
                        }
                        else if ( nCmpId == 42 )
                        {
                           OldComponentwc_general = cgiGet( "W0042");
                           if ( ( StringUtil.Len( OldComponentwc_general) == 0 ) || ( StringUtil.StrCmp(OldComponentwc_general, WebComp_Componentwc_general_Component) != 0 ) )
                           {
                              WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", OldComponentwc_general, new Object[] {context} );
                              WebComp_Componentwc_general.ComponentInit();
                              WebComp_Componentwc_general.Name = "OldComponentwc_general";
                              WebComp_Componentwc_general_Component = OldComponentwc_general;
                           }
                           if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
                           {
                              WebComp_Componentwc_general.componentprocess("W0042", "", sEvt);
                           }
                           WebComp_Componentwc_general_Component = OldComponentwc_general;
                        }
                        else if ( nCmpId == 54 )
                        {
                           OldPopupcomponent = cgiGet( "W0054");
                           if ( ( StringUtil.Len( OldPopupcomponent) == 0 ) || ( StringUtil.StrCmp(OldPopupcomponent, WebComp_Popupcomponent_Component) != 0 ) )
                           {
                              WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", OldPopupcomponent, new Object[] {context} );
                              WebComp_Popupcomponent.ComponentInit();
                              WebComp_Popupcomponent.Name = "OldPopupcomponent";
                              WebComp_Popupcomponent_Component = OldPopupcomponent;
                           }
                           if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
                           {
                              WebComp_Popupcomponent.componentprocess("W0054", "", sEvt);
                           }
                           WebComp_Popupcomponent_Component = OldPopupcomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2R2( )
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

      protected void PA2R2( )
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
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV26Pgmname = "EntityManagersoporte";
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132R2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  WebComp_Tabstrip.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  WebComp_Componentwc_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152R2 ();
            WB2R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV19AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV19AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV21RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Pgmname, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV26Pgmname = "EntityManagersoporte";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Componentscontainer_components_Title = cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Title");
            Componentscontainer_components_Collapsible = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Collapsible"));
            Componentscontainer_components_Open = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Open"));
            Componentscontainer_components_Showborders = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Showborders"));
            Componentscontainer_components_Visible = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Visible"));
            Tablemodal_Modaltitle = cgiGet( "TABLEMODAL_Modaltitle");
            Tablemodal_Visible = StringUtil.StrToBool( cgiGet( "TABLEMODAL_Visible"));
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
         E122R2 ();
         if (returnInSub) return;
      }

      protected void E122R2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblBacktoworkwith_Caption = StringUtil.Format( context.GetMessage( "K2BT_BackToWorkWithCaption", ""), context.GetMessage( "SOPORTE", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, lblBacktoworkwith_Internalname, "Caption", lblBacktoworkwith_Caption, true);
         lblBacktoworkwith_Link = formatLink("wwsoporte.aspx") ;
         AssignProp("", false, lblBacktoworkwith_Internalname, "Link", lblBacktoworkwith_Link, true);
         AV25GXLvl7 = 0;
         /* Using cursor H002R2 */
         pr_default.execute(0, new Object[] {AV6soporteID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4soporteID = H002R2_A4soporteID[0];
            A5hostName = H002R2_A5hostName[0];
            AV25GXLvl7 = 1;
            Form.Caption = A5hostName;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblK2bpgmdesc_Caption = StringUtil.Format( context.GetMessage( "K2BT_TitleWithFixedData", ""), context.GetMessage( "soporte", ""), A5hostName, "", "", "", "", "", "", "");
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV25GXLvl7 == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            lblK2bpgmdesc_Caption = context.GetMessage( "soporte", "");
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
         }
         new k2bsetobjectcontainername(context ).execute(  AV26Pgmname) ;
         GXt_objcol_SdtMessages_Message1 = AV16Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV16Messages = GXt_objcol_SdtMessages_Message1;
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV16Messages.Count )
         {
            AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV27GXV1));
            GX_msglist.addItem(AV17Message.gxTpr_Description);
            AV27GXV1 = (int)(AV27GXV1+1);
         }
      }

      protected void E132R2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'LOADCOMPONENTGROUP_COMPONENTS' */
         S112 ();
         if (returnInSub) return;
         GXt_char2 = AV20NextComponentCode;
         new k2bgetnextcomponentcode(context ).execute(  AV19AvailableComponents,  AV8TabCode, out  GXt_char2) ;
         AV20NextComponentCode = GXt_char2;
         if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( StringUtil.StrCmp(AV8TabCode, "") == 0 ) )
         {
            AV21RelatedTransactionName = "soporte";
            AssignAttri("", false, "AV21RelatedTransactionName", AV21RelatedTransactionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21RelatedTransactionName, "")), context));
         }
         new k2bgettrncontextbyname(context ).execute(  AV21RelatedTransactionName, out  AV9TrnContext) ;
         AV14CurrentUrl = AV9TrnContext.gxTpr_Callerurl;
         GXt_char2 = "";
         new GeneXus.Programs.k2btools.getobjectnamefromscriptname(context ).execute(  AV18HttpRequest.ScriptName, out  GXt_char2) ;
         AV9TrnContext.gxTpr_Entitymanagername = GXt_char2;
         AV9TrnContext.gxTpr_Entitymanagerencrypturlparameters = "";
         AV9TrnContext.gxTpr_Entitymanagernexttaskcode = AV20NextComponentCode;
         AV9TrnContext.gxTpr_Entitymanagernexttaskmode = "DSP";
         new k2bsettrncontextbyname(context ).execute(  AV21RelatedTransactionName,  AV9TrnContext) ;
         Tablemodal_Visible = false;
         ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               Tablemodal_Modaltitle = StringUtil.Format( context.GetMessage( "K2BT_UpdateTransactionTitle", ""), context.GetMessage( "soporte", ""), "", "", "", "", "", "", "", "");
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "ModalTitle", Tablemodal_Modaltitle);
               Tablemodal_Visible = true;
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Popupcomponent = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "soporte")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "soporte", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "soporte";
                  WebComp_Popupcomponent_Component = "soporte";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(string)"W0054",(string)"",(string)"UPD",(int)AV6soporteID});
                  WebComp_Popupcomponent.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Popupcomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0054"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               Tablemodal_Modaltitle = StringUtil.Format( context.GetMessage( "K2BT_DeleteTransactionTitle", ""), context.GetMessage( "soporte", ""), "", "", "", "", "", "", "", "");
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "ModalTitle", Tablemodal_Modaltitle);
               Tablemodal_Visible = true;
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Popupcomponent = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "soporte")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "soporte", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "soporte";
                  WebComp_Popupcomponent_Component = "soporte";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(string)"W0054",(string)"",(string)"DLT",(int)AV6soporteID});
                  WebComp_Popupcomponent.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Popupcomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0054"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19AvailableComponents", AV19AvailableComponents);
      }

      protected void S112( )
      {
         /* 'LOADCOMPONENTGROUP_COMPONENTS' Routine */
         returnInSub = false;
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "test");
         AV19AvailableComponents.Add("General", 0);
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV11Tab.gxTpr_Code = "General";
         AV11Tab.gxTpr_Description = context.GetMessage( "K2BT_General", "");
         AV11Tab.gxTpr_Link = formatLink("entitymanagersoporte.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV11Tab.gxTpr_Code))}, new string[] {"Mode","soporteID","TabCode"}) ;
         AV11Tab.gxTpr_Componenttype = 3;
         AV11Tab.gxTpr_Relatedtransaction = "soporte";
         AV10Tabs.Add(AV11Tab, 0);
         if ( AV10Tabs.Count > 0 )
         {
            Componentscontainer_components_Visible = true;
            ucComponentscontainer_components.SendProperty(context, "", false, Componentscontainer_components_Internalname, "Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
            /* Object Property */
            if ( true )
            {
               bDynCreated_Tabstrip = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Tabstrip_Component), StringUtil.Lower( "K2BToolsTabsTitleComponent")) != 0 )
            {
               WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", "k2btoolstabstitlecomponent", new Object[] {context} );
               WebComp_Tabstrip.ComponentInit();
               WebComp_Tabstrip.Name = "K2BToolsTabsTitleComponent";
               WebComp_Tabstrip_Component = "K2BToolsTabsTitleComponent";
            }
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.setjustcreated();
               WebComp_Tabstrip.componentprepare(new Object[] {(string)"W0032",(string)"",(string)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV10Tabs,(string)AV8TabCode});
               WebComp_Tabstrip.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Tabstrip )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
               WebComp_Tabstrip.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            divComponentcontainer_general_Visible = 0;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) && ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV10Tabs.Item(1)).gxTpr_Code, "General") == 0 ) ) )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            Componentscontainer_components_Visible = false;
            ucComponentscontainer_components.SendProperty(context, "", false, Componentscontainer_components_Internalname, "Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMPONENT_GENERAL' Routine */
         returnInSub = false;
         divComponentcontainer_general_Visible = 0;
         AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "soporteGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "soportegeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "soporteGeneral";
               WebComp_Componentwc_general_Component = "soporteGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0042",(string)"",(string)Gx_mode,(int)AV6soporteID,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0042"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "soporteGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "soportegeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "soporteGeneral";
               WebComp_Componentwc_general_Component = "soporteGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0042",(string)"",(string)"DSP",(int)AV6soporteID,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0042"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "soporteGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "soportegeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "soporteGeneral";
               WebComp_Componentwc_general_Component = "soporteGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0042",(string)"",(string)"DSP",(int)AV6soporteID,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0042"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "soporteGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "soportegeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "soporteGeneral";
               WebComp_Componentwc_general_Component = "soporteGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0042",(string)"",(string)"DSP",(int)AV6soporteID,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0042"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void E142R2( )
      {
         /* General\GlobalEvents_K2bt_refreshentitymanager Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22GE_EntityManagerName)) || ( StringUtil.StrCmp(StringUtil.Lower( StringUtil.Trim( AV22GE_EntityManagerName)), StringUtil.Lower( StringUtil.Trim( AV26Pgmname))) == 0 ) )
         {
            if ( StringUtil.StrCmp(AV23GE_ComponentName, "General") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
            else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23GE_ComponentName)) )
            {
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E112R2( )
      {
         /* Tablemodal_Onclose Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E152R2( )
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
         AV6soporteID = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV6soporteID", StringUtil.LTrimStr( (decimal)(AV6soporteID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOPORTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6soporteID), "ZZZZZZZZ9"), context));
         AV8TabCode = (string)getParm(obj,2);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.componentthemes();
            }
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
            {
               WebComp_Popupcomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431311354062", true, true);
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
         context.AddJavascriptSource("entitymanagersoporte.js", "?202431311354063", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ModalWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblK2bpgmdesc_Internalname = "K2BPGMDESC";
         divTitleright_Internalname = "TITLERIGHT";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         lblBacktoworkwith_Internalname = "BACKTOWORKWITH";
         divBacktoworkwithcell_Internalname = "BACKTOWORKWITHCELL";
         divBacktoworkwithcontainertable_Internalname = "BACKTOWORKWITHCONTAINERTABLE";
         divBacktoworkwithcontainer_Internalname = "BACKTOWORKWITHCONTAINER";
         divComponentcontainer_general_Internalname = "COMPONENTCONTAINER_GENERAL";
         divComponentstabcontainer_components_Internalname = "COMPONENTSTABCONTAINER_COMPONENTS";
         divTablayouts_Internalname = "TABLAYOUTS";
         divSection2_Internalname = "SECTION2";
         divComponents_components_tabssection_Internalname = "COMPONENTS_COMPONENTS_TABSSECTION";
         divContainercollapsiblesection_components_Internalname = "CONTAINERCOLLAPSIBLESECTION_COMPONENTS";
         divComponentscontainer_components_content_Internalname = "COMPONENTSCONTAINER_COMPONENTS_CONTENT";
         Componentscontainer_components_Internalname = "COMPONENTSCONTAINER_COMPONENTS";
         divTable3_Internalname = "TABLE3";
         divTable2_Internalname = "TABLE2";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divTablemodal_modalcontent_Internalname = "TABLEMODAL_MODALCONTENT";
         Tablemodal_Internalname = "TABLEMODAL";
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
         divComponentcontainer_general_Visible = 1;
         lblBacktoworkwith_Link = "";
         lblBacktoworkwith_Caption = "";
         lblK2bpgmdesc_Caption = context.GetMessage( "soporte", "");
         Tablemodal_Visible = Convert.ToBoolean( -1);
         Tablemodal_Modaltitle = "";
         Componentscontainer_components_Visible = Convert.ToBoolean( -1);
         Componentscontainer_components_Showborders = Convert.ToBoolean( 0);
         Componentscontainer_components_Open = Convert.ToBoolean( -1);
         Componentscontainer_components_Collapsible = Convert.ToBoolean( 0);
         Componentscontainer_components_Title = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "soporte", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV19AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'AV21RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6soporteID',fld:'vSOPORTEID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV21RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'Tablemodal_Visible',ctrl:'TABLEMODAL',prop:'Visible'},{av:'Tablemodal_Modaltitle',ctrl:'TABLEMODAL',prop:'ModalTitle'},{ctrl:'POPUPCOMPONENT'},{av:'AV19AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{ctrl:'TABSTRIP'},{av:'divComponentcontainer_general_Visible',ctrl:'COMPONENTCONTAINER_GENERAL',prop:'Visible'},{av:'Componentscontainer_components_Visible',ctrl:'COMPONENTSCONTAINER_COMPONENTS',prop:'Visible'},{ctrl:'COMPONENTWC_GENERAL'}]}");
         setEventMetadata("GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER","{handler:'E142R2',iparms:[{av:'AV23GE_ComponentName',fld:'vGE_COMPONENTNAME',pic:''},{av:'AV22GE_EntityManagerName',fld:'vGE_ENTITYMANAGERNAME',pic:''},{av:'AV26Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6soporteID',fld:'vSOPORTEID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true}]");
         setEventMetadata("GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER",",oparms:[{av:'divComponentcontainer_general_Visible',ctrl:'COMPONENTCONTAINER_GENERAL',prop:'Visible'},{ctrl:'COMPONENTWC_GENERAL'}]}");
         setEventMetadata("TABLEMODAL.ONCLOSE","{handler:'E112R2',iparms:[]");
         setEventMetadata("TABLEMODAL.ONCLOSE",",oparms:[]}");
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
         wcpOAV8TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV19AvailableComponents = new GxSimpleCollection<string>();
         AV21RelatedTransactionName = "";
         AV26Pgmname = "";
         GXKey = "";
         AV23GE_ComponentName = "";
         AV22GE_EntityManagerName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblK2bpgmdesc_Jsonclick = "";
         lblBacktoworkwith_Jsonclick = "";
         ucComponentscontainer_components = new GXUserControl();
         WebComp_Tabstrip_Component = "";
         OldTabstrip = "";
         WebComp_Componentwc_general_Component = "";
         OldComponentwc_general = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         ucTablemodal = new GXUserControl();
         WebComp_Popupcomponent_Component = "";
         OldPopupcomponent = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H002R2_A4soporteID = new int[1] ;
         H002R2_A5hostName = new string[] {""} ;
         A5hostName = "";
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV5Context = new SdtK2BContext(context);
         AV20NextComponentCode = "";
         AV9TrnContext = new SdtK2BTrnContext(context);
         AV14CurrentUrl = "";
         GXt_char2 = "";
         AV18HttpRequest = new GxHttpRequest( context);
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "test");
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entitymanagersoporte__default(),
            new Object[][] {
                new Object[] {
               H002R2_A4soporteID, H002R2_A5hostName
               }
            }
         );
         WebComp_Tabstrip = new GeneXus.Http.GXNullWebComponent();
         WebComp_Componentwc_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Popupcomponent = new GeneXus.Http.GXNullWebComponent();
         AV26Pgmname = "EntityManagersoporte";
         /* GeneXus formulas. */
         AV26Pgmname = "EntityManagersoporte";
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV25GXLvl7 ;
      private short nGXWrapped ;
      private int AV6soporteID ;
      private int wcpOAV6soporteID ;
      private int divComponentcontainer_general_Visible ;
      private int A4soporteID ;
      private int AV27GXV1 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV8TabCode ;
      private string wcpOGx_mode ;
      private string wcpOAV8TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV21RelatedTransactionName ;
      private string AV26Pgmname ;
      private string GXKey ;
      private string Componentscontainer_components_Title ;
      private string Tablemodal_Modaltitle ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblK2bpgmdesc_Internalname ;
      private string lblK2bpgmdesc_Caption ;
      private string lblK2bpgmdesc_Jsonclick ;
      private string divTitleright_Internalname ;
      private string divBacktoworkwithcontainer_Internalname ;
      private string divBacktoworkwithcontainertable_Internalname ;
      private string divBacktoworkwithcell_Internalname ;
      private string lblBacktoworkwith_Internalname ;
      private string lblBacktoworkwith_Caption ;
      private string lblBacktoworkwith_Link ;
      private string lblBacktoworkwith_Jsonclick ;
      private string divTable2_Internalname ;
      private string divTable3_Internalname ;
      private string Componentscontainer_components_Internalname ;
      private string divComponentscontainer_components_content_Internalname ;
      private string divContainercollapsiblesection_components_Internalname ;
      private string divComponents_components_tabssection_Internalname ;
      private string WebComp_Tabstrip_Component ;
      private string OldTabstrip ;
      private string divSection2_Internalname ;
      private string divTablayouts_Internalname ;
      private string divComponentstabcontainer_components_Internalname ;
      private string divComponentcontainer_general_Internalname ;
      private string WebComp_Componentwc_general_Component ;
      private string OldComponentwc_general ;
      private string K2bcontrolbeautify1_Internalname ;
      private string Tablemodal_Internalname ;
      private string divTablemodal_modalcontent_Internalname ;
      private string WebComp_Popupcomponent_Component ;
      private string OldPopupcomponent ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string AV20NextComponentCode ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Componentscontainer_components_Collapsible ;
      private bool Componentscontainer_components_Open ;
      private bool Componentscontainer_components_Showborders ;
      private bool Componentscontainer_components_Visible ;
      private bool Tablemodal_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Popupcomponent ;
      private bool bDynCreated_Tabstrip ;
      private bool bDynCreated_Componentwc_general ;
      private string AV23GE_ComponentName ;
      private string AV22GE_EntityManagerName ;
      private string A5hostName ;
      private string AV14CurrentUrl ;
      private GXWebComponent WebComp_Tabstrip ;
      private GXWebComponent WebComp_Componentwc_general ;
      private GXWebComponent WebComp_Popupcomponent ;
      private GXUserControl ucComponentscontainer_components ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucTablemodal ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H002R2_A4soporteID ;
      private string[] H002R2_A5hostName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV18HttpRequest ;
      private GxSimpleCollection<string> AV19AvailableComponents ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV10Tabs ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BTrnContext AV9TrnContext ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV11Tab ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
   }

   public class entitymanagersoporte__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          new ParDef("@AV6soporteID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "SELECT TOP 1 [soporteID], [hostName] FROM [soporte] WHERE [soporteID] = @AV6soporteID ORDER BY [soporteID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
