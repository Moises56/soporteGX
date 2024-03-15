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
   public class entryconnection : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entryconnection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public entryconnection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_pConnectionName )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8pConnectionName = aP1_pConnectionName;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_pConnectionName=this.AV8pConnectionName;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwsysconns") == 0 )
            {
               gxnrGridwwsysconns_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridwwsysconns") == 0 )
            {
               gxgrGridwwsysconns_refresh_invoke( ) ;
               return  ;
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
                  AV8pConnectionName = GetPar( "pConnectionName");
                  AssignAttri("", false, "AV8pConnectionName", AV8pConnectionName);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8pConnectionName, "")), context));
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

      protected void gxnrGridwwsysconns_newrow_invoke( )
      {
         nRC_GXsfl_111 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_111"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_111_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_111_idx = GetPar( "sGXsfl_111_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwwsysconns_newrow( ) ;
         /* End function gxnrGridwwsysconns_newrow_invoke */
      }

      protected void gxgrGridwwsysconns_refresh_invoke( )
      {
         AV36CurrentPage_GridWWSysConns = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_GridWWSysConns"), "."), 18, MidpointRounding.ToEven));
         AV8pConnectionName = GetPar( "pConnectionName");
         Gx_mode = GetPar( "Mode");
         AV21ConnectionFileXML = GetPar( "ConnectionFileXML");
         AV45Pgmname = GetPar( "Pgmname");
         AV32CurrentConnectionKey = GetPar( "CurrentConnectionKey");
         AV40FileXML = GetPar( "FileXML");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridwwsysconns_refresh( AV36CurrentPage_GridWWSysConns, AV8pConnectionName, Gx_mode, AV21ConnectionFileXML, AV45Pgmname, AV32CurrentConnectionKey, AV40FileXML) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridwwsysconns_refresh_invoke */
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
         PA3V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV8pConnectionName))}, new string[] {"Gx_mode","pConnectionName"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDWWSYSCONNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36CurrentPage_GridWWSysConns), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRIDWWSYSCONNS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36CurrentPage_GridWWSysConns), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPCONNECTIONNAME", StringUtil.RTrim( AV8pConnectionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vPCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8pConnectionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTCONNECTIONKEY", StringUtil.RTrim( AV32CurrentConnectionKey));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTCONNECTIONKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32CurrentConnectionKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXML", StringUtil.RTrim( AV40FileXML));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXML", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40FileXML, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_111", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_111), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDWWSYSCONNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36CurrentPage_GridWWSysConns), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRIDWWSYSCONNS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36CurrentPage_GridWWSysConns), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPCONNECTIONNAME", StringUtil.RTrim( AV8pConnectionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vPCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8pConnectionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTCONNECTIONKEY", StringUtil.RTrim( AV32CurrentConnectionKey));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTCONNECTIONKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32CurrentConnectionKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXML", StringUtil.RTrim( AV40FileXML));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXML", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40FileXML, "")), context));
         GxWebStd.gx_hidden_field( context, "subGridwwsysconns_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GENERAL_Title", StringUtil.RTrim( General_Title));
         GxWebStd.gx_hidden_field( context, "GENERAL_Collapsible", StringUtil.BoolToStr( General_Collapsible));
         GxWebStd.gx_hidden_field( context, "GENERAL_Open", StringUtil.BoolToStr( General_Open));
         GxWebStd.gx_hidden_field( context, "GENERAL_Showborders", StringUtil.BoolToStr( General_Showborders));
         GxWebStd.gx_hidden_field( context, "GENERAL_Containseditableform", StringUtil.BoolToStr( General_Containseditableform));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3V2( ) ;
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
         return formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV8pConnectionName))}, new string[] {"Gx_mode","pConnectionName"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.EntryConnection" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entry connection" ;
      }

      protected void WB3V0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Repository connection", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, imgUpdate_Enabled, "Update", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgUpdate_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgDelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgDelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgDelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, imgDelete_Enabled, "Delete", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 7, imgDelete_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123v1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_connectionname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConnectionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionname_Internalname, "Connection name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionname_Internalname, StringUtil.RTrim( AV17ConnectionName), StringUtil.RTrim( context.localUtil.Format( AV17ConnectionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavConnectionname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_username_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, StringUtil.RTrim( AV18UserName), StringUtil.RTrim( context.localUtil.Format( AV18UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_userpassword_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "User password", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV19UserPassword), StringUtil.RTrim( context.localUtil.Format( AV19UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpassword_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_challengeexpire_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_challengeexpire_Internalname, "Connection challenge expire", "", "", lblTextblock_var_challengeexpire_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryConnection.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_challengeexpirecellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChallengeexpire_Internalname, "Connection challenge expire", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChallengeexpire_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ChallengeExpire), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20ChallengeExpire), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChallengeexpire_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavChallengeexpire_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "K2BNumber", "end", false, "", "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblChallengeexpire_var_righttext_Internalname, "minutes (0 = never expires)", "", "", lblChallengeexpire_var_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel RightLabel", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_encryptionkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer K2BT_FormGroup", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_var_encryptionkey_Internalname, "Encryption key", "", "", lblTextblock_var_encryptionkey_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BT_LabelTop", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryConnection.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_encryptionkeycellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEncryptionkey_Internalname, "Encryption key", "gx-form-item Attribute_TrnLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEncryptionkey_Internalname, StringUtil.RTrim( AV22EncryptionKey), StringUtil.RTrim( context.localUtil.Format( AV22EncryptionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEncryptionkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavEncryptionkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGeneratekey_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Generate key", bttGeneratekey_Jsonclick, 5, "", "", StyleString, ClassString, bttGeneratekey_Visible, bttGeneratekey_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_GENERATEKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryConnection.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", bttConfirm_Caption, bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, bttConfirm_Visible, bttConfirm_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryConnection.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 7, "", "", StyleString, ClassString, bttCancel_Visible, bttCancel_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e133v1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_newconnectionkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavNewconnectionkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewconnectionkey_Internalname, "New connection key", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewconnectionkey_Internalname, StringUtil.RTrim( AV26NewConnectionKey), StringUtil.RTrim( context.localUtil.Format( AV26NewConnectionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewconnectionkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavNewconnectionkey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divActioncontainertable_useautomatickey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_AttributeContainer K2BT_LeftAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActioncontainertable_useautomatickeycellcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SideTextContainer", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUseautomatickey_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Use automatic key", bttUseautomatickey_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_USEAUTOMATICKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryConnection.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUsecurrentkey_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Use current key", bttUsecurrentkey_Jsonclick, 5, "", "", StyleString, ClassString, bttUsecurrentkey_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_USECURRENTKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryConnection.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSavekey_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "Save key", bttSavekey_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_SAVEKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_gridwwsysconns_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_gridwwsysconns_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_gridwwsysconns_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridwwsysconns_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridwwsysconnsContainer.SetWrapped(nGXWrapped);
            StartGridControl111( ) ;
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            nRC_GXsfl_111 = (int)(nGXsfl_111_idx-1);
            if ( GridwwsysconnsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridwwsysconnsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwsysconns", GridwwsysconnsContainer, subGridwwsysconns_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwwsysconnsContainerData", GridwwsysconnsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwwsysconnsContainerData"+"V", GridwwsysconnsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwwsysconnsContainerData"+"V"+"\" value='"+GridwwsysconnsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_118_3V2( true) ;
         }
         else
         {
            wb_table1_118_3V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_118_3V2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_connectionfilexml_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavConnectionfilexml_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavConnectionfilexml_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionfilexml_Internalname, "Content for connection.gam file:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_111_idx + "',0)\"";
            ClassString = "Attribute_Trn";
            StyleString = "";
            ClassString = "Attribute_Trn";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavConnectionfilexml_Internalname, AV21ConnectionFileXML, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", 0, edtavConnectionfilexml_Visible, edtavConnectionfilexml_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "32768", -1, 0, "", "", -1, true, "GeneXusSecurityCommon\\GAMString", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_K2BFSG\\EntryConnection.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_fileconnectionkey_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFileconnectionkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFileconnectionkey_Internalname, "File connection Key", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFileconnectionkey_Internalname, StringUtil.RTrim( AV33FileConnectionKey), StringUtil.RTrim( context.localUtil.Format( AV33FileConnectionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFileconnectionkey_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavFileconnectionkey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_K2BFSG\\EntryConnection.htm");
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
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridwwsysconnsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridwwsysconnsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwsysconns", GridwwsysconnsContainer, subGridwwsysconns_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwwsysconnsContainerData", GridwwsysconnsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwwsysconnsContainerData"+"V", GridwwsysconnsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwwsysconnsContainerData"+"V"+"\" value='"+GridwwsysconnsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3V2( )
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
         Form.Meta.addItem("description", "Entry connection", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3V0( ) ;
      }

      protected void WS3V2( )
      {
         START3V2( ) ;
         EVT3V2( ) ;
      }

      protected void EVT3V2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E143V2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_GENERATEKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_GenerateKey' */
                              E153V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_USEAUTOMATICKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_UseAutomaticKey' */
                              E163V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_USECURRENTKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_UseCurrentKey' */
                              E173V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_SAVEKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_SaveKey' */
                              E183V2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDWWSYSCONNS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDWWSYSCONNS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_FILE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_DELETEKEY'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_FILE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_DELETEKEY'") == 0 ) )
                           {
                              nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
                              SubsflControlProps_1112( ) ;
                              AV27ConnectionKey = cgiGet( edtavConnectionkey_Internalname);
                              AssignAttri("", false, edtavConnectionkey_Internalname, AV27ConnectionKey);
                              GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONKEY"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, StringUtil.RTrim( context.localUtil.Format( AV27ConnectionKey, "")), context));
                              AV28isCurrentKey = cgiGet( edtavIscurrentkey_Internalname);
                              AssignAttri("", false, edtavIscurrentkey_Internalname, AV28isCurrentKey);
                              AV29File_Action = cgiGet( edtavFile_action_Internalname);
                              AssignAttri("", false, edtavFile_action_Internalname, AV29File_Action);
                              AV30DeleteKey_Action = cgiGet( edtavDeletekey_action_Internalname);
                              AssignAttri("", false, edtavDeletekey_action_Internalname, AV30DeleteKey_Action);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E193V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E203V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWWSYSCONNS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E213V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWWSYSCONNS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E223V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_FILE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_File' */
                                    E233V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETEKEY'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_DeleteKey' */
                                    E243V2 ();
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3V2( )
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

      protected void PA3V2( )
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
               GX_FocusControl = edtavConnectionname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridwwsysconns_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1112( ) ;
         while ( nGXsfl_111_idx <= nRC_GXsfl_111 )
         {
            sendrow_1112( ) ;
            nGXsfl_111_idx = ((subGridwwsysconns_Islastpage==1)&&(nGXsfl_111_idx+1>subGridwwsysconns_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridwwsysconnsContainer)) ;
         /* End function gxnrGridwwsysconns_newrow */
      }

      protected void gxgrGridwwsysconns_refresh( short AV36CurrentPage_GridWWSysConns ,
                                                 string AV8pConnectionName ,
                                                 string Gx_mode ,
                                                 string AV21ConnectionFileXML ,
                                                 string AV45Pgmname ,
                                                 string AV32CurrentConnectionKey ,
                                                 string AV40FileXML )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWWSYSCONNS_nCurrentRecord = 0;
         RF3V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridwwsysconns_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27ConnectionKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vCONNECTIONKEY", StringUtil.RTrim( AV27ConnectionKey));
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
         /* Execute user event: Refresh */
         E203V2 ();
         RF3V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV45Pgmname = "K2BFSG.EntryConnection";
         edtavConnectionkey_Enabled = 0;
         AssignProp("", false, edtavConnectionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionkey_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavIscurrentkey_Enabled = 0;
         AssignProp("", false, edtavIscurrentkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIscurrentkey_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavFile_action_Enabled = 0;
         AssignProp("", false, edtavFile_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFile_action_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavDeletekey_action_Enabled = 0;
         AssignProp("", false, edtavDeletekey_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeletekey_action_Enabled), 5, 0), !bGXsfl_111_Refreshing);
      }

      protected void RF3V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridwwsysconnsContainer.ClearRows();
         }
         wbStart = 111;
         /* Execute user event: Refresh */
         E203V2 ();
         E213V2 ();
         nGXsfl_111_idx = 1;
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         bGXsfl_111_Refreshing = true;
         GridwwsysconnsContainer.AddObjectProperty("GridName", "Gridwwsysconns");
         GridwwsysconnsContainer.AddObjectProperty("CmpContext", "");
         GridwwsysconnsContainer.AddObjectProperty("InMasterPage", "false");
         GridwwsysconnsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridwwsysconnsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridwwsysconnsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridwwsysconnsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Backcolorstyle), 1, 0, ".", "")));
         GridwwsysconnsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Sortable), 1, 0, ".", "")));
         GridwwsysconnsContainer.PageSize = subGridwwsysconns_fnc_Recordsperpage( );
         if ( subGridwwsysconns_Islastpage != 0 )
         {
            GRIDWWSYSCONNS_nFirstRecordOnPage = (long)(subGridwwsysconns_fnc_Recordcount( )-subGridwwsysconns_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDWWSYSCONNS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWWSYSCONNS_nFirstRecordOnPage), 15, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("GRIDWWSYSCONNS_nFirstRecordOnPage", GRIDWWSYSCONNS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1112( ) ;
            E223V2 ();
            wbEnd = 111;
            WB3V0( ) ;
         }
         bGXsfl_111_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3V2( )
      {
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRIDWWSYSCONNS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36CurrentPage_GridWWSysConns), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRIDWWSYSCONNS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36CurrentPage_GridWWSysConns), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPCONNECTIONNAME", StringUtil.RTrim( AV8pConnectionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vPCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8pConnectionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTCONNECTIONKEY", StringUtil.RTrim( AV32CurrentConnectionKey));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTCONNECTIONKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32CurrentConnectionKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONKEY"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, StringUtil.RTrim( context.localUtil.Format( AV27ConnectionKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXML", StringUtil.RTrim( AV40FileXML));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXML", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40FileXML, "")), context));
      }

      protected int subGridwwsysconns_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridwwsysconns_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridwwsysconns_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridwwsysconns_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV45Pgmname = "K2BFSG.EntryConnection";
         edtavConnectionkey_Enabled = 0;
         AssignProp("", false, edtavConnectionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionkey_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavIscurrentkey_Enabled = 0;
         AssignProp("", false, edtavIscurrentkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIscurrentkey_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavFile_action_Enabled = 0;
         AssignProp("", false, edtavFile_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFile_action_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavDeletekey_action_Enabled = 0;
         AssignProp("", false, edtavDeletekey_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeletekey_action_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E193V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_111 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "vMODE");
            subGridwwsysconns_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridwwsysconns_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            General_Title = cgiGet( "GENERAL_Title");
            General_Collapsible = StringUtil.StrToBool( cgiGet( "GENERAL_Collapsible"));
            General_Open = StringUtil.StrToBool( cgiGet( "GENERAL_Open"));
            General_Showborders = StringUtil.StrToBool( cgiGet( "GENERAL_Showborders"));
            General_Containseditableform = StringUtil.StrToBool( cgiGet( "GENERAL_Containseditableform"));
            Attributes_Title = cgiGet( "ATTRIBUTES_Title");
            Attributes_Collapsible = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Collapsible"));
            Attributes_Open = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Open"));
            Attributes_Showborders = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Showborders"));
            Attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            AV17ConnectionName = cgiGet( edtavConnectionname_Internalname);
            AssignAttri("", false, "AV17ConnectionName", AV17ConnectionName);
            AV18UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV18UserName", AV18UserName);
            AV19UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV19UserPassword", AV19UserPassword);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChallengeexpire_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChallengeexpire_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHALLENGEEXPIRE");
               GX_FocusControl = edtavChallengeexpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20ChallengeExpire = 0;
               AssignAttri("", false, "AV20ChallengeExpire", StringUtil.LTrimStr( (decimal)(AV20ChallengeExpire), 4, 0));
            }
            else
            {
               AV20ChallengeExpire = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavChallengeexpire_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ChallengeExpire", StringUtil.LTrimStr( (decimal)(AV20ChallengeExpire), 4, 0));
            }
            AV22EncryptionKey = cgiGet( edtavEncryptionkey_Internalname);
            AssignAttri("", false, "AV22EncryptionKey", AV22EncryptionKey);
            AV26NewConnectionKey = cgiGet( edtavNewconnectionkey_Internalname);
            AssignAttri("", false, "AV26NewConnectionKey", AV26NewConnectionKey);
            AV21ConnectionFileXML = cgiGet( edtavConnectionfilexml_Internalname);
            AssignAttri("", false, "AV21ConnectionFileXML", AV21ConnectionFileXML);
            AV33FileConnectionKey = cgiGet( edtavFileconnectionkey_Internalname);
            AssignAttri("", false, "AV33FileConnectionKey", AV33FileConnectionKey);
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
         General_Containseditableform = true;
         ucGeneral.SendProperty(context, "", false, General_Internalname, "ContainsEditableForm", StringUtil.BoolToStr( General_Containseditableform));
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         bttConfirm_Visible = 1;
         AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
         bttConfirm_Visible = 1;
         AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
         bttGeneratekey_Visible = 1;
         AssignProp("", false, bttGeneratekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Visible), 5, 0), true);
         bttGeneratekey_Enabled = 1;
         AssignProp("", false, bttGeneratekey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Enabled), 5, 0), true);
         edtavUserpassword_Visible = 1;
         AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
         edtavConnectionname_Enabled = 1;
         AssignProp("", false, edtavConnectionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionname_Enabled), 5, 0), true);
         edtavChallengeexpire_Enabled = 1;
         AssignProp("", false, edtavChallengeexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavChallengeexpire_Enabled), 5, 0), true);
         edtavUsername_Enabled = 1;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
         edtavEncryptionkey_Enabled = 1;
         AssignProp("", false, edtavEncryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEncryptionkey_Enabled), 5, 0), true);
         AV19UserPassword = "";
         AssignAttri("", false, "AV19UserPassword", AV19UserPassword);
         AV17ConnectionName = "";
         AssignAttri("", false, "AV17ConnectionName", AV17ConnectionName);
         AV20ChallengeExpire = 0;
         AssignAttri("", false, "AV20ChallengeExpire", StringUtil.LTrimStr( (decimal)(AV20ChallengeExpire), 4, 0));
         AV18UserName = "";
         AssignAttri("", false, "AV18UserName", AV18UserName);
         AV22EncryptionKey = "";
         AssignAttri("", false, "AV22EncryptionKey", AV22EncryptionKey);
         AV17ConnectionName = AV8pConnectionName;
         AssignAttri("", false, "AV17ConnectionName", AV17ConnectionName);
         GX_FocusControl = edtavConnectionname_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
         edtavConnectionfilexml_Visible = 0;
         AssignProp("", false, edtavConnectionfilexml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConnectionfilexml_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtavConnectionname_Enabled = 1;
            AssignProp("", false, edtavConnectionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionname_Enabled), 5, 0), true);
            edtavUsername_Enabled = 1;
            AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
         }
         else
         {
            AV5Connection.load( AV17ConnectionName);
            AV18UserName = AV5Connection.gxTpr_Username;
            AssignAttri("", false, "AV18UserName", AV18UserName);
            AV19UserPassword = AV5Connection.gxTpr_Userpassword;
            AssignAttri("", false, "AV19UserPassword", AV19UserPassword);
            AV20ChallengeExpire = (short)(AV5Connection.gxTpr_Challengeexpire);
            AssignAttri("", false, "AV20ChallengeExpire", StringUtil.LTrimStr( (decimal)(AV20ChallengeExpire), 4, 0));
            AV22EncryptionKey = AV5Connection.gxTpr_Key;
            AssignAttri("", false, "AV22EncryptionKey", AV22EncryptionKey);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "XML") == 0 ) )
         {
            bttConfirm_Visible = 0;
            AssignProp("", false, bttConfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirm_Visible), 5, 0), true);
            bttConfirm_Enabled = 0;
            AssignProp("", false, bttConfirm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirm_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "XML") == 0 ) )
         {
            bttGeneratekey_Visible = 0;
            AssignProp("", false, bttGeneratekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Visible), 5, 0), true);
            bttGeneratekey_Enabled = 0;
            AssignProp("", false, bttGeneratekey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttGeneratekey_Enabled), 5, 0), true);
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavConnectionname_Enabled = 0;
            AssignProp("", false, edtavConnectionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionname_Enabled), 5, 0), true);
            edtavChallengeexpire_Enabled = 0;
            AssignProp("", false, edtavChallengeexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavChallengeexpire_Enabled), 5, 0), true);
            edtavUsername_Enabled = 0;
            AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
            edtavEncryptionkey_Enabled = 0;
            AssignProp("", false, edtavEncryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEncryptionkey_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "XML") == 0 )
         {
            edtavConnectionfilexml_Visible = 1;
            AssignProp("", false, edtavConnectionfilexml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConnectionfilexml_Visible), 5, 0), true);
            AV9isOk = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).generateconnectionfile(AV17ConnectionName, out  AV21ConnectionFileXML, out  AV7Errors);
            if ( ! AV9isOk )
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S292 ();
               if (returnInSub) return;
            }
         }
      }

      protected void S292( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV7Errors.Count )
         {
            AV6Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV7Errors.Item(AV42GXV1));
            if ( AV6Error.gxTpr_Code != 13 )
            {
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV6Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV6Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E193V2 ();
         if (returnInSub) return;
      }

      protected void E193V2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRIDWWSYSCONNS)' */
         S122 ();
         if (returnInSub) return;
         subGridwwsysconns_Backcolorstyle = 3;
      }

      protected void E203V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
         if ( (0==AV36CurrentPage_GridWWSysConns) )
         {
            AV36CurrentPage_GridWWSysConns = 1;
            AssignAttri("", false, "AV36CurrentPage_GridWWSysConns", StringUtil.LTrimStr( (decimal)(AV36CurrentPage_GridWWSysConns), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRIDWWSYSCONNS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36CurrentPage_GridWWSysConns), "ZZZ9"), context));
         }
         AV37Reload_GridWWSysConns = true;
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
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Connection", AV5Connection);
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

      protected void S152( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "XML") == 0 ) ) )
         {
            AV5Connection.gxTpr_Name = AV17ConnectionName;
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV5Connection.load( AV17ConnectionName);
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               AV5Connection.gxTpr_Username = AV18UserName;
               AV5Connection.gxTpr_Userpassword = AV19UserPassword;
               AV5Connection.gxTpr_Challengeexpire = AV20ChallengeExpire;
               AV5Connection.gxTpr_Key = AV22EncryptionKey;
               AV5Connection.save();
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV5Connection.delete();
            }
            if ( AV5Connection.success() )
            {
               AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV11Message.gxTpr_Description = StringUtil.Format( "Connection %1 was created", AV17ConnectionName, "", "", "", "", "", "", "", "");
               }
               else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
               {
                  AV11Message.gxTpr_Description = StringUtil.Format( "Connection %1 was updated", AV17ConnectionName, "", "", "", "", "", "", "", "");
               }
               else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
               {
                  AV11Message.gxTpr_Description = StringUtil.Format( "Connection %1 was deleted", AV17ConnectionName, "", "", "", "", "", "", "", "");
               }
               new k2btoolsmessagequeueadd(context ).execute(  AV11Message) ;
               CallWebObject(formatLink("k2bfsg.wwconnections.aspx") );
               context.wjLocDisableFrm = 1;
               context.CommitDataStores("k2bfsg.entryconnection",pr_default);
            }
            else
            {
               AV7Errors = AV5Connection.geterrors();
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S292 ();
               if (returnInSub) return;
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E143V2 ();
         if (returnInSub) return;
      }

      protected void E143V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Connection", AV5Connection);
      }

      protected void S162( )
      {
         /* 'U_GENERATEKEY' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "XML") == 0 ) ) )
         {
            AV22EncryptionKey = Crypto.GetEncryptionKey( );
            AssignAttri("", false, "AV22EncryptionKey", AV22EncryptionKey);
         }
      }

      protected void E153V2( )
      {
         /* 'E_GenerateKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_GENERATEKEY' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV17ConnectionName))}, new string[] {"Mode","pConnectionName"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S182( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.entryconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV17ConnectionName))}, new string[] {"Mode","pConnectionName"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'U_CANCEL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwconnections.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E163V2( )
      {
         /* 'E_UseAutomaticKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_USEAUTOMATICKEY' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S202( )
      {
         /* 'U_USEAUTOMATICKEY' Routine */
         returnInSub = false;
         AV31GXGUID = Guid.NewGuid( );
         AV26NewConnectionKey = StringUtil.Trim( AV31GXGUID.ToString());
         AssignAttri("", false, "AV26NewConnectionKey", AV26NewConnectionKey);
      }

      protected void E173V2( )
      {
         /* 'E_UseCurrentKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_USECURRENTKEY' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'U_USECURRENTKEY' Routine */
         returnInSub = false;
         AV9isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnectionkey(out  AV32CurrentConnectionKey);
         AV26NewConnectionKey = StringUtil.Trim( AV32CurrentConnectionKey);
         AssignAttri("", false, "AV26NewConnectionKey", AV26NewConnectionKey);
      }

      protected void E183V2( )
      {
         /* 'E_SaveKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_SAVEKEY' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Connection", AV5Connection);
      }

      protected void S222( )
      {
         /* 'U_SAVEKEY' Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).addconnectiontofilekey(AV26NewConnectionKey, AV17ConnectionName, out  AV7Errors) )
         {
            gxgrGridwwsysconns_refresh( AV36CurrentPage_GridWWSysConns, AV8pConnectionName, Gx_mode, AV21ConnectionFileXML, AV45Pgmname, AV32CurrentConnectionKey, AV40FileXML) ;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S292 ();
            if (returnInSub) return;
         }
      }

      protected void E213V2( )
      {
         /* Gridwwsysconns_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRIDWWSYSCONNS)' */
         S232 ();
         if (returnInSub) return;
         subGridwwsysconns_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRIDWWSYSCONNS)' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S242( )
      {
         /* 'U_GRIDREFRESH(GRIDWWSYSCONNS)' Routine */
         returnInSub = false;
      }

      private void E223V2( )
      {
         /* Gridwwsysconns_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_gridwwsysconns_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_gridwwsysconns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridwwsysconns_Visible), 5, 0), true);
         AV38I_LoadCount_GridWWSysConns = 0;
         AV39Exit_GridWWSysConns = false;
         while ( true )
         {
            AV38I_LoadCount_GridWWSysConns = (short)(AV38I_LoadCount_GridWWSysConns+1);
            /* Execute user subroutine: 'U_LOADROWVARS(GRIDWWSYSCONNS)' */
            S252 ();
            if (returnInSub) return;
            AV29File_Action = "File";
            AssignAttri("", false, edtavFile_action_Internalname, AV29File_Action);
            AV30DeleteKey_Action = "Delete key";
            AssignAttri("", false, edtavDeletekey_action_Internalname, AV30DeleteKey_Action);
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRIDWWSYSCONNS)' */
            S262 ();
            if (returnInSub) return;
            if ( AV39Exit_GridWWSysConns )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_gridwwsysconns_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_gridwwsysconns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridwwsysconns_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 111;
            }
            sendrow_1112( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
            {
               context.DoAjaxLoad(111, GridwwsysconnsRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRIDWWSYSCONNS)' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S252( )
      {
         /* 'U_LOADROWVARS(GRIDWWSYSCONNS)' Routine */
         returnInSub = false;
         AV9isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnectionkey(out  AV32CurrentConnectionKey);
         AV34hasCurrentKey = false;
         AV44GXV3 = 1;
         AV43GXV2 = AV5Connection.getkeys(out  AV7Errors);
         while ( AV44GXV3 <= AV43GXV2.Count )
         {
            AV35GAMSystemConnection = ((GeneXus.Programs.genexussecurity.SdtGAMSystemConnection)AV43GXV2.Item(AV44GXV3));
            AV29File_Action = "File";
            AssignAttri("", false, edtavFile_action_Internalname, AV29File_Action);
            AV30DeleteKey_Action = "Delete key";
            AssignAttri("", false, edtavDeletekey_action_Internalname, AV30DeleteKey_Action);
            AV27ConnectionKey = AV35GAMSystemConnection.gxTpr_Key;
            AssignAttri("", false, edtavConnectionkey_Internalname, AV27ConnectionKey);
            GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONKEY"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, StringUtil.RTrim( context.localUtil.Format( AV27ConnectionKey, "")), context));
            if ( StringUtil.StrCmp(StringUtil.Trim( AV35GAMSystemConnection.gxTpr_Key), StringUtil.Trim( AV32CurrentConnectionKey)) == 0 )
            {
               AV34hasCurrentKey = true;
               AV28isCurrentKey = "(current)";
               AssignAttri("", false, edtavIscurrentkey_Internalname, AV28isCurrentKey);
            }
            else
            {
               AV28isCurrentKey = "";
               AssignAttri("", false, edtavIscurrentkey_Internalname, AV28isCurrentKey);
            }
            tblI_noresultsfoundtablename_gridwwsysconns_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_gridwwsysconns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_gridwwsysconns_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 111;
            }
            sendrow_1112( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
            {
               context.DoAjaxLoad(111, GridwwsysconnsRow);
            }
            AV44GXV3 = (int)(AV44GXV3+1);
         }
         if ( AV34hasCurrentKey )
         {
            bttUsecurrentkey_Visible = 0;
            AssignProp("", false, bttUsecurrentkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttUsecurrentkey_Visible), 5, 0), true);
         }
         AV39Exit_GridWWSysConns = true;
      }

      protected void S262( )
      {
         /* 'U_AFTERDATALOAD(GRIDWWSYSCONNS)' Routine */
         returnInSub = false;
      }

      protected void S232( )
      {
         /* 'SAVEGRIDSTATE(GRIDWWSYSCONNS)' Routine */
         returnInSub = false;
         AV23GridStateKey = "GridWWSysConns";
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV23GridStateKey, out  AV24GridState) ;
         AV24GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV45Pgmname,  AV23GridStateKey,  AV24GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRIDWWSYSCONNS)' Routine */
         returnInSub = false;
         AV23GridStateKey = "GridWWSysConns";
         new k2bloadgridstate(context ).execute(  AV45Pgmname,  AV23GridStateKey, out  AV24GridState) ;
      }

      protected void E233V2( )
      {
         /* 'E_File' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_FILE' */
         S272 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S272( )
      {
         /* 'U_FILE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33FileConnectionKey, AV27ConnectionKey) == 0 )
         {
            AV33FileConnectionKey = "";
            AssignAttri("", false, "AV33FileConnectionKey", AV33FileConnectionKey);
            edtavConnectionfilexml_Visible = 0;
            AssignProp("", false, edtavConnectionfilexml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConnectionfilexml_Visible), 5, 0), true);
         }
         else
         {
            AV33FileConnectionKey = AV27ConnectionKey;
            AssignAttri("", false, "AV33FileConnectionKey", AV33FileConnectionKey);
            edtavConnectionfilexml_Visible = 1;
            AssignProp("", false, edtavConnectionfilexml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConnectionfilexml_Visible), 5, 0), true);
            AV21ConnectionFileXML = "";
            AssignAttri("", false, "AV21ConnectionFileXML", AV21ConnectionFileXML);
            new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnectionxmlfromfilekey(AV17ConnectionName, AV27ConnectionKey, out  AV40FileXML, out  AV7Errors) ;
            if ( AV7Errors.Count == 0 )
            {
               AV21ConnectionFileXML = AV40FileXML;
               AssignAttri("", false, "AV21ConnectionFileXML", AV21ConnectionFileXML);
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S292 ();
               if (returnInSub) return;
            }
         }
      }

      protected void E243V2( )
      {
         /* 'E_DeleteKey' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETEKEY' */
         S282 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Connection", AV5Connection);
      }

      protected void S282( )
      {
         /* 'U_DELETEKEY' Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).deleteconnectionfromfilekey(AV27ConnectionKey, AV17ConnectionName, out  AV7Errors) )
         {
            gxgrGridwwsysconns_refresh( AV36CurrentPage_GridWWSysConns, AV8pConnectionName, Gx_mode, AV21ConnectionFileXML, AV45Pgmname, AV32CurrentConnectionKey, AV40FileXML) ;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S292 ();
            if (returnInSub) return;
         }
      }

      protected void wb_table1_118_3V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_gridwwsysconns_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_gridwwsysconns_Internalname, tblI_noresultsfoundtablename_gridwwsysconns_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_gridwwsysconns_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_gridwwsysconns_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\EntryConnection.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_118_3V2e( true) ;
         }
         else
         {
            wb_table1_118_3V2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV8pConnectionName = (string)getParm(obj,1);
         AssignAttri("", false, "AV8pConnectionName", AV8pConnectionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vPCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8pConnectionName, "")), context));
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
         PA3V2( ) ;
         WS3V2( ) ;
         WE3V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024313819574", true, true);
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
         context.AddJavascriptSource("k2bfsg/entryconnection.js", "?2024313819578", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1112( )
      {
         edtavConnectionkey_Internalname = "vCONNECTIONKEY_"+sGXsfl_111_idx;
         edtavIscurrentkey_Internalname = "vISCURRENTKEY_"+sGXsfl_111_idx;
         edtavFile_action_Internalname = "vFILE_ACTION_"+sGXsfl_111_idx;
         edtavDeletekey_action_Internalname = "vDELETEKEY_ACTION_"+sGXsfl_111_idx;
      }

      protected void SubsflControlProps_fel_1112( )
      {
         edtavConnectionkey_Internalname = "vCONNECTIONKEY_"+sGXsfl_111_fel_idx;
         edtavIscurrentkey_Internalname = "vISCURRENTKEY_"+sGXsfl_111_fel_idx;
         edtavFile_action_Internalname = "vFILE_ACTION_"+sGXsfl_111_fel_idx;
         edtavDeletekey_action_Internalname = "vDELETEKEY_ACTION_"+sGXsfl_111_fel_idx;
      }

      protected void sendrow_1112( )
      {
         SubsflControlProps_1112( ) ;
         WB3V0( ) ;
         GridwwsysconnsRow = GXWebRow.GetNew(context,GridwwsysconnsContainer);
         if ( subGridwwsysconns_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwwsysconns_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwwsysconns_Class, "") != 0 )
            {
               subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Odd";
            }
         }
         else if ( subGridwwsysconns_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwwsysconns_Backstyle = 0;
            subGridwwsysconns_Backcolor = subGridwwsysconns_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwwsysconns_Class, "") != 0 )
            {
               subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Uniform";
            }
         }
         else if ( subGridwwsysconns_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwwsysconns_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwwsysconns_Class, "") != 0 )
            {
               subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Odd";
            }
            subGridwwsysconns_Backcolor = (int)(0x0);
         }
         else if ( subGridwwsysconns_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwwsysconns_Backstyle = 1;
            if ( ((int)((nGXsfl_111_idx) % (2))) == 0 )
            {
               subGridwwsysconns_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwsysconns_Class, "") != 0 )
               {
                  subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Even";
               }
            }
            else
            {
               subGridwwsysconns_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwsysconns_Class, "") != 0 )
               {
                  subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Odd";
               }
            }
         }
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_111_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavConnectionkey_Enabled!=0)&&(edtavConnectionkey_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 112,'',false,'"+sGXsfl_111_idx+"',111)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridwwsysconnsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConnectionkey_Internalname,StringUtil.RTrim( AV27ConnectionKey),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavConnectionkey_Enabled!=0)&&(edtavConnectionkey_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,112);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavConnectionkey_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavConnectionkey_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavIscurrentkey_Enabled!=0)&&(edtavIscurrentkey_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 113,'',false,'"+sGXsfl_111_idx+"',111)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridwwsysconnsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavIscurrentkey_Internalname,StringUtil.RTrim( AV28isCurrentKey),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavIscurrentkey_Enabled!=0)&&(edtavIscurrentkey_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,113);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavIscurrentkey_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavIscurrentkey_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"K2BDescription",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavFile_action_Enabled!=0)&&(edtavFile_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 114,'',false,'"+sGXsfl_111_idx+"',111)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridwwsysconnsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFile_action_Internalname,StringUtil.RTrim( AV29File_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFile_action_Enabled!=0)&&(edtavFile_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,114);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_FILE\\'."+sGXsfl_111_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFile_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavFile_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDeletekey_action_Enabled!=0)&&(edtavDeletekey_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 115,'',false,'"+sGXsfl_111_idx+"',111)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridwwsysconnsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletekey_action_Internalname,StringUtil.RTrim( AV30DeleteKey_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDeletekey_action_Enabled!=0)&&(edtavDeletekey_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,115);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_DELETEKEY\\'."+sGXsfl_111_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeletekey_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavDeletekey_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes3V2( ) ;
         GridwwsysconnsContainer.AddRow(GridwwsysconnsRow);
         nGXsfl_111_idx = ((subGridwwsysconns_Islastpage==1)&&(nGXsfl_111_idx+1>subGridwwsysconns_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         /* End function sendrow_1112 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl111( )
      {
         if ( GridwwsysconnsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridwwsysconnsContainer"+"DivS\" data-gxgridid=\"111\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridwwsysconns_Internalname, subGridwwsysconns_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridwwsysconns_Backcolorstyle == 0 )
            {
               subGridwwsysconns_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridwwsysconns_Class) > 0 )
               {
                  subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Title";
               }
            }
            else
            {
               subGridwwsysconns_Titlebackstyle = 1;
               if ( subGridwwsysconns_Backcolorstyle == 1 )
               {
                  subGridwwsysconns_Titlebackcolor = subGridwwsysconns_Allbackcolor;
                  if ( StringUtil.Len( subGridwwsysconns_Class) > 0 )
                  {
                     subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridwwsysconns_Class) > 0 )
                  {
                     subGridwwsysconns_Linesclass = subGridwwsysconns_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Connection key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Is current key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridwwsysconnsContainer.AddObjectProperty("GridName", "Gridwwsysconns");
         }
         else
         {
            GridwwsysconnsContainer.AddObjectProperty("GridName", "Gridwwsysconns");
            GridwwsysconnsContainer.AddObjectProperty("Header", subGridwwsysconns_Header);
            GridwwsysconnsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
            GridwwsysconnsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Backcolorstyle), 1, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Sortable), 1, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("CmpContext", "");
            GridwwsysconnsContainer.AddObjectProperty("InMasterPage", "false");
            GridwwsysconnsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwwsysconnsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27ConnectionKey)));
            GridwwsysconnsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConnectionkey_Enabled), 5, 0, ".", "")));
            GridwwsysconnsContainer.AddColumnProperties(GridwwsysconnsColumn);
            GridwwsysconnsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwwsysconnsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28isCurrentKey)));
            GridwwsysconnsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavIscurrentkey_Enabled), 5, 0, ".", "")));
            GridwwsysconnsContainer.AddColumnProperties(GridwwsysconnsColumn);
            GridwwsysconnsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwwsysconnsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29File_Action)));
            GridwwsysconnsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFile_action_Enabled), 5, 0, ".", "")));
            GridwwsysconnsContainer.AddColumnProperties(GridwwsysconnsColumn);
            GridwwsysconnsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwwsysconnsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV30DeleteKey_Action)));
            GridwwsysconnsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletekey_action_Enabled), 5, 0, ".", "")));
            GridwwsysconnsContainer.AddColumnProperties(GridwwsysconnsColumn);
            GridwwsysconnsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Selectedindex), 4, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Allowselection), 1, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Selectioncolor), 9, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Allowhovering), 1, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Hoveringcolor), 9, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Allowcollapsing), 1, 0, ".", "")));
            GridwwsysconnsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwsysconns_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         imgUpdate_Internalname = "UPDATE";
         imgDelete_Internalname = "DELETE";
         divActionscontainertableright_actions2_Internalname = "ACTIONSCONTAINERTABLERIGHT_ACTIONS2";
         divResponsivetable_containernode_actions2_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS2";
         edtavConnectionname_Internalname = "vCONNECTIONNAME";
         divTable_container_connectionname_Internalname = "TABLE_CONTAINER_CONNECTIONNAME";
         edtavUsername_Internalname = "vUSERNAME";
         divTable_container_username_Internalname = "TABLE_CONTAINER_USERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divTable_container_userpassword_Internalname = "TABLE_CONTAINER_USERPASSWORD";
         lblTextblock_var_challengeexpire_Internalname = "TEXTBLOCK_VAR_CHALLENGEEXPIRE";
         edtavChallengeexpire_Internalname = "vCHALLENGEEXPIRE";
         lblChallengeexpire_var_righttext_Internalname = "CHALLENGEEXPIRE_VAR_RIGHTTEXT";
         divTable_container_challengeexpirecellcontainer_Internalname = "TABLE_CONTAINER_CHALLENGEEXPIRECELLCONTAINER";
         divTable_container_challengeexpire_Internalname = "TABLE_CONTAINER_CHALLENGEEXPIRE";
         lblTextblock_var_encryptionkey_Internalname = "TEXTBLOCK_VAR_ENCRYPTIONKEY";
         edtavEncryptionkey_Internalname = "vENCRYPTIONKEY";
         bttGeneratekey_Internalname = "GENERATEKEY";
         divTable_container_encryptionkeycellcontainer_Internalname = "TABLE_CONTAINER_ENCRYPTIONKEYCELLCONTAINER";
         divTable_container_encryptionkey_Internalname = "TABLE_CONTAINER_ENCRYPTIONKEY";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_general_Internalname = "ATTRIBUTESCONTAINERTABLE_GENERAL";
         divGeneral_content_Internalname = "GENERAL_CONTENT";
         General_Internalname = "GENERAL";
         edtavNewconnectionkey_Internalname = "vNEWCONNECTIONKEY";
         divTable_container_newconnectionkey_Internalname = "TABLE_CONTAINER_NEWCONNECTIONKEY";
         bttUseautomatickey_Internalname = "USEAUTOMATICKEY";
         bttUsecurrentkey_Internalname = "USECURRENTKEY";
         bttSavekey_Internalname = "SAVEKEY";
         divActioncontainertable_useautomatickeycellcontainer_Internalname = "ACTIONCONTAINERTABLE_USEAUTOMATICKEYCELLCONTAINER";
         divActioncontainertable_useautomatickey_Internalname = "ACTIONCONTAINERTABLE_USEAUTOMATICKEY";
         edtavConnectionkey_Internalname = "vCONNECTIONKEY";
         edtavIscurrentkey_Internalname = "vISCURRENTKEY";
         edtavFile_action_Internalname = "vFILE_ACTION";
         edtavDeletekey_action_Internalname = "vDELETEKEY_ACTION";
         lblI_noresultsfoundtextblock_gridwwsysconns_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRIDWWSYSCONNS";
         tblI_noresultsfoundtablename_gridwwsysconns_Internalname = "I_NORESULTSFOUNDTABLENAME_GRIDWWSYSCONNS";
         divMaingrid_responsivetable_gridwwsysconns_Internalname = "MAINGRID_RESPONSIVETABLE_GRIDWWSYSCONNS";
         divLayoutdefined_table3_gridwwsysconns_Internalname = "LAYOUTDEFINED_TABLE3_GRIDWWSYSCONNS";
         divLayoutdefined_grid_inner_gridwwsysconns_Internalname = "LAYOUTDEFINED_GRID_INNER_GRIDWWSYSCONNS";
         divGridcomponentcontent_gridwwsysconns_Internalname = "GRIDCOMPONENTCONTENT_GRIDWWSYSCONNS";
         edtavConnectionfilexml_Internalname = "vCONNECTIONFILEXML";
         divTable_container_connectionfilexml_Internalname = "TABLE_CONTAINER_CONNECTIONFILEXML";
         edtavFileconnectionkey_Internalname = "vFILECONNECTIONKEY";
         divTable_container_fileconnectionkey_Internalname = "TABLE_CONTAINER_FILECONNECTIONKEY";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divAttributes_content_Internalname = "ATTRIBUTES_CONTENT";
         Attributes_Internalname = "ATTRIBUTES";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridwwsysconns_Internalname = "GRIDWWSYSCONNS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridwwsysconns_Allowcollapsing = 0;
         subGridwwsysconns_Allowselection = 0;
         subGridwwsysconns_Header = "";
         edtavDeletekey_action_Jsonclick = "";
         edtavDeletekey_action_Visible = -1;
         edtavDeletekey_action_Enabled = 1;
         edtavFile_action_Jsonclick = "";
         edtavFile_action_Visible = -1;
         edtavFile_action_Enabled = 1;
         edtavIscurrentkey_Jsonclick = "";
         edtavIscurrentkey_Visible = -1;
         edtavIscurrentkey_Enabled = 1;
         edtavConnectionkey_Jsonclick = "";
         edtavConnectionkey_Visible = -1;
         edtavConnectionkey_Enabled = 1;
         subGridwwsysconns_Class = "K2BT_SG Grid_WorkWith";
         subGridwwsysconns_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_gridwwsysconns_Visible = 1;
         subGridwwsysconns_Sortable = 0;
         edtavFileconnectionkey_Jsonclick = "";
         edtavFileconnectionkey_Enabled = 1;
         edtavConnectionfilexml_Enabled = 1;
         edtavConnectionfilexml_Visible = 1;
         bttUsecurrentkey_Visible = 1;
         edtavNewconnectionkey_Jsonclick = "";
         edtavNewconnectionkey_Enabled = 1;
         bttCancel_Enabled = 1;
         bttCancel_Visible = 1;
         bttConfirm_Caption = "Confirm";
         bttConfirm_Enabled = 1;
         bttConfirm_Visible = 1;
         bttGeneratekey_Enabled = 1;
         bttGeneratekey_Visible = 1;
         edtavEncryptionkey_Jsonclick = "";
         edtavEncryptionkey_Enabled = 1;
         edtavChallengeexpire_Jsonclick = "";
         edtavChallengeexpire_Enabled = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         edtavConnectionname_Jsonclick = "";
         edtavConnectionname_Enabled = 1;
         imgDelete_Tooltiptext = "Delete";
         imgDelete_Enabled = 1;
         imgDelete_Visible = 1;
         imgDelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         imgUpdate_Tooltiptext = "Update";
         imgUpdate_Enabled = 1;
         imgUpdate_Visible = 1;
         imgUpdate_Bitmap = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         Attributes_Containseditableform = Convert.ToBoolean( -1);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = "Keys";
         General_Containseditableform = Convert.ToBoolean( -1);
         General_Showborders = Convert.ToBoolean( -1);
         General_Open = Convert.ToBoolean( -1);
         General_Collapsible = Convert.ToBoolean( 0);
         General_Title = "General";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Entry connection";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDWWSYSCONNS_nFirstRecordOnPage'},{av:'GRIDWWSYSCONNS_nEOF'},{av:'AV21ConnectionFileXML',fld:'vCONNECTIONFILEXML',pic:''},{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'AV32CurrentConnectionKey',fld:'vCURRENTCONNECTIONKEY',pic:'',hsh:true},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40FileXML',fld:'vFILEXML',pic:'',hsh:true},{av:'AV8pConnectionName',fld:'vPCONNECTIONNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Enabled'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavConnectionname_Enabled',ctrl:'vCONNECTIONNAME',prop:'Enabled'},{av:'edtavChallengeexpire_Enabled',ctrl:'vCHALLENGEEXPIRE',prop:'Enabled'},{av:'edtavUsername_Enabled',ctrl:'vUSERNAME',prop:'Enabled'},{av:'edtavEncryptionkey_Enabled',ctrl:'vENCRYPTIONKEY',prop:'Enabled'},{av:'AV19UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''},{av:'AV20ChallengeExpire',fld:'vCHALLENGEEXPIRE',pic:'ZZZ9'},{av:'AV18UserName',fld:'vUSERNAME',pic:''},{av:'AV22EncryptionKey',fld:'vENCRYPTIONKEY',pic:''},{av:'edtavConnectionfilexml_Visible',ctrl:'vCONNECTIONFILEXML',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("ENTER","{handler:'E143V2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''},{av:'AV18UserName',fld:'vUSERNAME',pic:''},{av:'AV19UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV20ChallengeExpire',fld:'vCHALLENGEEXPIRE',pic:'ZZZ9'},{av:'AV22EncryptionKey',fld:'vENCRYPTIONKEY',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'E_GENERATEKEY'","{handler:'E153V2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_GENERATEKEY'",",oparms:[{av:'AV22EncryptionKey',fld:'vENCRYPTIONKEY',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E113V1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E123V1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]}");
         setEventMetadata("'E_CANCEL'","{handler:'E133V1',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("'E_CANCEL'",",oparms:[]}");
         setEventMetadata("'E_USEAUTOMATICKEY'","{handler:'E163V2',iparms:[]");
         setEventMetadata("'E_USEAUTOMATICKEY'",",oparms:[{av:'AV26NewConnectionKey',fld:'vNEWCONNECTIONKEY',pic:''}]}");
         setEventMetadata("'E_USECURRENTKEY'","{handler:'E173V2',iparms:[{av:'AV32CurrentConnectionKey',fld:'vCURRENTCONNECTIONKEY',pic:'',hsh:true}]");
         setEventMetadata("'E_USECURRENTKEY'",",oparms:[{av:'AV26NewConnectionKey',fld:'vNEWCONNECTIONKEY',pic:''}]}");
         setEventMetadata("'E_SAVEKEY'","{handler:'E183V2',iparms:[{av:'GRIDWWSYSCONNS_nFirstRecordOnPage'},{av:'GRIDWWSYSCONNS_nEOF'},{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'AV8pConnectionName',fld:'vPCONNECTIONNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV21ConnectionFileXML',fld:'vCONNECTIONFILEXML',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32CurrentConnectionKey',fld:'vCURRENTCONNECTIONKEY',pic:'',hsh:true},{av:'AV40FileXML',fld:'vFILEXML',pic:'',hsh:true},{av:'AV26NewConnectionKey',fld:'vNEWCONNECTIONKEY',pic:''},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]");
         setEventMetadata("'E_SAVEKEY'",",oparms:[{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Enabled'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavConnectionname_Enabled',ctrl:'vCONNECTIONNAME',prop:'Enabled'},{av:'edtavChallengeexpire_Enabled',ctrl:'vCHALLENGEEXPIRE',prop:'Enabled'},{av:'edtavUsername_Enabled',ctrl:'vUSERNAME',prop:'Enabled'},{av:'edtavEncryptionkey_Enabled',ctrl:'vENCRYPTIONKEY',prop:'Enabled'},{av:'AV19UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''},{av:'AV20ChallengeExpire',fld:'vCHALLENGEEXPIRE',pic:'ZZZ9'},{av:'AV18UserName',fld:'vUSERNAME',pic:''},{av:'AV22EncryptionKey',fld:'vENCRYPTIONKEY',pic:''},{av:'edtavConnectionfilexml_Visible',ctrl:'vCONNECTIONFILEXML',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("GRIDWWSYSCONNS.REFRESH","{handler:'E213V2',iparms:[{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRIDWWSYSCONNS.REFRESH",",oparms:[{av:'subGridwwsysconns_Backcolorstyle',ctrl:'GRIDWWSYSCONNS',prop:'Backcolorstyle'}]}");
         setEventMetadata("GRIDWWSYSCONNS.LOAD","{handler:'E223V2',iparms:[{av:'AV32CurrentConnectionKey',fld:'vCURRENTCONNECTIONKEY',pic:'',hsh:true},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRIDWWSYSCONNS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_gridwwsysconns_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRIDWWSYSCONNS',prop:'Visible'},{av:'AV29File_Action',fld:'vFILE_ACTION',pic:''},{av:'AV30DeleteKey_Action',fld:'vDELETEKEY_ACTION',pic:''},{av:'AV27ConnectionKey',fld:'vCONNECTIONKEY',pic:'',hsh:true},{av:'AV28isCurrentKey',fld:'vISCURRENTKEY',pic:''},{ctrl:'USECURRENTKEY',prop:'Visible'}]}");
         setEventMetadata("'E_FILE'","{handler:'E233V2',iparms:[{av:'AV33FileConnectionKey',fld:'vFILECONNECTIONKEY',pic:''},{av:'AV27ConnectionKey',fld:'vCONNECTIONKEY',pic:'',hsh:true},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''},{av:'AV40FileXML',fld:'vFILEXML',pic:'',hsh:true}]");
         setEventMetadata("'E_FILE'",",oparms:[{av:'AV21ConnectionFileXML',fld:'vCONNECTIONFILEXML',pic:''},{av:'AV33FileConnectionKey',fld:'vFILECONNECTIONKEY',pic:''},{av:'edtavConnectionfilexml_Visible',ctrl:'vCONNECTIONFILEXML',prop:'Visible'}]}");
         setEventMetadata("'E_DELETEKEY'","{handler:'E243V2',iparms:[{av:'GRIDWWSYSCONNS_nFirstRecordOnPage'},{av:'GRIDWWSYSCONNS_nEOF'},{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'AV8pConnectionName',fld:'vPCONNECTIONNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV21ConnectionFileXML',fld:'vCONNECTIONFILEXML',pic:''},{av:'AV45Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32CurrentConnectionKey',fld:'vCURRENTCONNECTIONKEY',pic:'',hsh:true},{av:'AV40FileXML',fld:'vFILEXML',pic:'',hsh:true},{av:'AV27ConnectionKey',fld:'vCONNECTIONKEY',pic:'',hsh:true},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''}]");
         setEventMetadata("'E_DELETEKEY'",",oparms:[{av:'AV36CurrentPage_GridWWSysConns',fld:'vCURRENTPAGE_GRIDWWSYSCONNS',pic:'ZZZ9',hsh:true},{av:'imgUpdate_Tooltiptext',ctrl:'UPDATE',prop:'Tooltiptext'},{av:'imgDelete_Tooltiptext',ctrl:'DELETE',prop:'Tooltiptext'},{ctrl:'CONFIRM',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Visible'},{ctrl:'GENERATEKEY',prop:'Enabled'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavConnectionname_Enabled',ctrl:'vCONNECTIONNAME',prop:'Enabled'},{av:'edtavChallengeexpire_Enabled',ctrl:'vCHALLENGEEXPIRE',prop:'Enabled'},{av:'edtavUsername_Enabled',ctrl:'vUSERNAME',prop:'Enabled'},{av:'edtavEncryptionkey_Enabled',ctrl:'vENCRYPTIONKEY',prop:'Enabled'},{av:'AV19UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17ConnectionName',fld:'vCONNECTIONNAME',pic:''},{av:'AV20ChallengeExpire',fld:'vCHALLENGEEXPIRE',pic:'ZZZ9'},{av:'AV18UserName',fld:'vUSERNAME',pic:''},{av:'AV22EncryptionKey',fld:'vENCRYPTIONKEY',pic:''},{av:'edtavConnectionfilexml_Visible',ctrl:'vCONNECTIONFILEXML',prop:'Visible'},{ctrl:'CONFIRM',prop:'Enabled'},{ctrl:'CONFIRM',prop:'Caption'},{ctrl:'CANCEL',prop:'Visible'},{ctrl:'CANCEL',prop:'Enabled'},{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgUpdate_Enabled',ctrl:'UPDATE',prop:'Enabled'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{av:'imgDelete_Enabled',ctrl:'DELETE',prop:'Enabled'}]}");
         setEventMetadata("NULL","{handler:'Validv_Deletekey_action',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         wcpOAV8pConnectionName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV21ConnectionFileXML = "";
         AV45Pgmname = "";
         AV32CurrentConnectionKey = "";
         AV40FileXML = "";
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
         AV17ConnectionName = "";
         AV18UserName = "";
         AV19UserPassword = "";
         lblTextblock_var_challengeexpire_Jsonclick = "";
         lblChallengeexpire_var_righttext_Jsonclick = "";
         lblTextblock_var_encryptionkey_Jsonclick = "";
         AV22EncryptionKey = "";
         bttGeneratekey_Jsonclick = "";
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucAttributes = new GXUserControl();
         AV26NewConnectionKey = "";
         bttUseautomatickey_Jsonclick = "";
         bttUsecurrentkey_Jsonclick = "";
         bttSavekey_Jsonclick = "";
         GridwwsysconnsContainer = new GXWebGrid( context);
         sStyleString = "";
         AV33FileConnectionKey = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27ConnectionKey = "";
         AV28isCurrentKey = "";
         AV29File_Action = "";
         AV30DeleteKey_Action = "";
         AV5Connection = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection(context);
         AV7Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV31GXGUID = Guid.Empty;
         GridwwsysconnsRow = new GXWebRow();
         AV43GXV2 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSystemConnection>( context, "GeneXus.Programs.genexussecurity.SdtGAMSystemConnection", "GeneXus.Programs");
         AV35GAMSystemConnection = new GeneXus.Programs.genexussecurity.SdtGAMSystemConnection(context);
         AV23GridStateKey = "";
         AV24GridState = new SdtK2BGridState(context);
         lblI_noresultsfoundtextblock_gridwwsysconns_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridwwsysconns_Linesclass = "";
         ROClassString = "";
         GridwwsysconnsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryconnection__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.entryconnection__default(),
            new Object[][] {
            }
         );
         AV45Pgmname = "K2BFSG.EntryConnection";
         /* GeneXus formulas. */
         AV45Pgmname = "K2BFSG.EntryConnection";
         edtavConnectionkey_Enabled = 0;
         edtavIscurrentkey_Enabled = 0;
         edtavFile_action_Enabled = 0;
         edtavDeletekey_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV36CurrentPage_GridWWSysConns ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV20ChallengeExpire ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridwwsysconns_Backcolorstyle ;
      private short subGridwwsysconns_Sortable ;
      private short GRIDWWSYSCONNS_nEOF ;
      private short AV38I_LoadCount_GridWWSysConns ;
      private short nGXWrapped ;
      private short subGridwwsysconns_Backstyle ;
      private short subGridwwsysconns_Titlebackstyle ;
      private short subGridwwsysconns_Allowselection ;
      private short subGridwwsysconns_Allowhovering ;
      private short subGridwwsysconns_Allowcollapsing ;
      private short subGridwwsysconns_Collapsed ;
      private int nRC_GXsfl_111 ;
      private int subGridwwsysconns_Recordcount ;
      private int nGXsfl_111_idx=1 ;
      private int imgUpdate_Visible ;
      private int imgUpdate_Enabled ;
      private int imgDelete_Visible ;
      private int imgDelete_Enabled ;
      private int edtavConnectionname_Enabled ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int edtavChallengeexpire_Enabled ;
      private int edtavEncryptionkey_Enabled ;
      private int bttGeneratekey_Visible ;
      private int bttGeneratekey_Enabled ;
      private int bttConfirm_Visible ;
      private int bttConfirm_Enabled ;
      private int bttCancel_Visible ;
      private int bttCancel_Enabled ;
      private int edtavNewconnectionkey_Enabled ;
      private int bttUsecurrentkey_Visible ;
      private int edtavConnectionfilexml_Visible ;
      private int edtavConnectionfilexml_Enabled ;
      private int edtavFileconnectionkey_Enabled ;
      private int subGridwwsysconns_Islastpage ;
      private int edtavConnectionkey_Enabled ;
      private int edtavIscurrentkey_Enabled ;
      private int edtavFile_action_Enabled ;
      private int edtavDeletekey_action_Enabled ;
      private int AV42GXV1 ;
      private int tblI_noresultsfoundtablename_gridwwsysconns_Visible ;
      private int AV44GXV3 ;
      private int idxLst ;
      private int subGridwwsysconns_Backcolor ;
      private int subGridwwsysconns_Allbackcolor ;
      private int edtavConnectionkey_Visible ;
      private int edtavIscurrentkey_Visible ;
      private int edtavFile_action_Visible ;
      private int edtavDeletekey_action_Visible ;
      private int subGridwwsysconns_Titlebackcolor ;
      private int subGridwwsysconns_Selectedindex ;
      private int subGridwwsysconns_Selectioncolor ;
      private int subGridwwsysconns_Hoveringcolor ;
      private long GRIDWWSYSCONNS_nCurrentRecord ;
      private long GRIDWWSYSCONNS_nFirstRecordOnPage ;
      private string Gx_mode ;
      private string AV8pConnectionName ;
      private string wcpOGx_mode ;
      private string wcpOAV8pConnectionName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_111_idx="0001" ;
      private string AV45Pgmname ;
      private string AV32CurrentConnectionKey ;
      private string AV40FileXML ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string General_Title ;
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
      private string divTable_container_connectionname_Internalname ;
      private string edtavConnectionname_Internalname ;
      private string AV17ConnectionName ;
      private string edtavConnectionname_Jsonclick ;
      private string divTable_container_username_Internalname ;
      private string edtavUsername_Internalname ;
      private string AV18UserName ;
      private string edtavUsername_Jsonclick ;
      private string divTable_container_userpassword_Internalname ;
      private string edtavUserpassword_Internalname ;
      private string AV19UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string divTable_container_challengeexpire_Internalname ;
      private string lblTextblock_var_challengeexpire_Internalname ;
      private string lblTextblock_var_challengeexpire_Jsonclick ;
      private string divTable_container_challengeexpirecellcontainer_Internalname ;
      private string edtavChallengeexpire_Internalname ;
      private string edtavChallengeexpire_Jsonclick ;
      private string lblChallengeexpire_var_righttext_Internalname ;
      private string lblChallengeexpire_var_righttext_Jsonclick ;
      private string divTable_container_encryptionkey_Internalname ;
      private string lblTextblock_var_encryptionkey_Internalname ;
      private string lblTextblock_var_encryptionkey_Jsonclick ;
      private string divTable_container_encryptionkeycellcontainer_Internalname ;
      private string edtavEncryptionkey_Internalname ;
      private string AV22EncryptionKey ;
      private string edtavEncryptionkey_Jsonclick ;
      private string bttGeneratekey_Internalname ;
      private string bttGeneratekey_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Caption ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string Attributes_Internalname ;
      private string divAttributes_content_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_newconnectionkey_Internalname ;
      private string edtavNewconnectionkey_Internalname ;
      private string AV26NewConnectionKey ;
      private string edtavNewconnectionkey_Jsonclick ;
      private string divActioncontainertable_useautomatickey_Internalname ;
      private string divActioncontainertable_useautomatickeycellcontainer_Internalname ;
      private string bttUseautomatickey_Internalname ;
      private string bttUseautomatickey_Jsonclick ;
      private string bttUsecurrentkey_Internalname ;
      private string bttUsecurrentkey_Jsonclick ;
      private string bttSavekey_Internalname ;
      private string bttSavekey_Jsonclick ;
      private string divGridcomponentcontent_gridwwsysconns_Internalname ;
      private string divLayoutdefined_grid_inner_gridwwsysconns_Internalname ;
      private string divLayoutdefined_table3_gridwwsysconns_Internalname ;
      private string divMaingrid_responsivetable_gridwwsysconns_Internalname ;
      private string sStyleString ;
      private string subGridwwsysconns_Internalname ;
      private string divTable_container_connectionfilexml_Internalname ;
      private string edtavConnectionfilexml_Internalname ;
      private string divTable_container_fileconnectionkey_Internalname ;
      private string edtavFileconnectionkey_Internalname ;
      private string AV33FileConnectionKey ;
      private string edtavFileconnectionkey_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27ConnectionKey ;
      private string edtavConnectionkey_Internalname ;
      private string AV28isCurrentKey ;
      private string edtavIscurrentkey_Internalname ;
      private string AV29File_Action ;
      private string edtavFile_action_Internalname ;
      private string AV30DeleteKey_Action ;
      private string edtavDeletekey_action_Internalname ;
      private string tblI_noresultsfoundtablename_gridwwsysconns_Internalname ;
      private string lblI_noresultsfoundtextblock_gridwwsysconns_Internalname ;
      private string lblI_noresultsfoundtextblock_gridwwsysconns_Jsonclick ;
      private string sGXsfl_111_fel_idx="0001" ;
      private string subGridwwsysconns_Class ;
      private string subGridwwsysconns_Linesclass ;
      private string ROClassString ;
      private string edtavConnectionkey_Jsonclick ;
      private string edtavIscurrentkey_Jsonclick ;
      private string edtavFile_action_Jsonclick ;
      private string edtavDeletekey_action_Jsonclick ;
      private string subGridwwsysconns_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool General_Collapsible ;
      private bool General_Open ;
      private bool General_Showborders ;
      private bool General_Containseditableform ;
      private bool Attributes_Collapsible ;
      private bool Attributes_Open ;
      private bool Attributes_Showborders ;
      private bool Attributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_111_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9isOk ;
      private bool gx_refresh_fired ;
      private bool AV37Reload_GridWWSysConns ;
      private bool AV39Exit_GridWWSysConns ;
      private bool AV34hasCurrentKey ;
      private string AV21ConnectionFileXML ;
      private string AV23GridStateKey ;
      private string imgUpdate_Bitmap ;
      private string imgDelete_Bitmap ;
      private Guid AV31GXGUID ;
      private GXWebGrid GridwwsysconnsContainer ;
      private GXWebRow GridwwsysconnsRow ;
      private GXWebColumn GridwwsysconnsColumn ;
      private GXUserControl ucGeneral ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_pConnectionName ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSystemConnection> AV43GXV2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryConnection AV5Connection ;
      private GeneXus.Programs.genexussecurity.SdtGAMSystemConnection AV35GAMSystemConnection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV6Error ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private SdtK2BGridState AV24GridState ;
   }

   public class entryconnection__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class entryconnection__default : DataStoreHelperBase, IDataStoreHelper
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
