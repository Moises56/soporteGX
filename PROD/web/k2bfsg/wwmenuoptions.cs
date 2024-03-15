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
   public class wwmenuoptions : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwmenuoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public wwmenuoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ApplicationId ,
                           ref long aP1_MenuId )
      {
         this.AV9ApplicationId = aP0_ApplicationId;
         this.AV27MenuId = aP1_MenuId;
         executePrivate();
         aP0_ApplicationId=this.AV9ApplicationId;
         aP1_MenuId=this.AV27MenuId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
         cmbavOptiontype = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ApplicationId");
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
               gxfirstwebparm = GetFirstPar( "ApplicationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ApplicationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
               AV9ApplicationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV27MenuId = (long)(Math.Round(NumberUtil.Val( GetPar( "MenuId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV27MenuId", StringUtil.LTrimStr( (decimal)(AV27MenuId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27MenuId), "ZZZZZZZZZZZ9"), context));
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         AV52GenericFilter_PreviousValue_Grid = GetPar( "GenericFilter_PreviousValue_Grid");
         AV53Pgmname = GetPar( "Pgmname");
         AV12CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV48GenericFilter_Grid = GetPar( "GenericFilter_Grid");
         AV22HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49GridConfiguration);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV50ClassCollection_Grid);
         AV38RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV24I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV9ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         AV27MenuId = (long)(Math.Round(NumberUtil.Val( GetPar( "MenuId"), "."), 18, MidpointRounding.ToEven));
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV53Pgmname, AV12CurrentPage_Grid, AV48GenericFilter_Grid, AV22HasNextPage_Grid, AV49GridConfiguration, AV50ClassCollection_Grid, AV38RowsPerPage_Grid, AV24I_LoadCount_Grid, AV9ApplicationId, AV27MenuId, AV51FreezeColumnTitles_Grid) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
         PA4I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4I2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwmenuoptions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV27MenuId,12,0))}, new string[] {"ApplicationId","MenuId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV22HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV22HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27MenuId), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_113), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV50ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV49GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV49GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV22HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV22HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38RowsPerPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Title", StringUtil.RTrim( Responsivetable_mainattributes_attributes_Title));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Collapsible", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Open", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Open));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Showborders", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Showborders));
         GxWebStd.gx_hidden_field( context, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Containseditableform", StringUtil.BoolToStr( Responsivetable_mainattributes_attributes_Containseditableform));
         GxWebStd.gx_hidden_field( context, "GRIDCOMPONENT_GRID_Title", StringUtil.RTrim( Gridcomponent_grid_Title));
         GxWebStd.gx_hidden_field( context, "GRIDCOMPONENT_GRID_Collapsible", StringUtil.BoolToStr( Gridcomponent_grid_Collapsible));
         GxWebStd.gx_hidden_field( context, "GRIDCOMPONENT_GRID_Open", StringUtil.BoolToStr( Gridcomponent_grid_Open));
         GxWebStd.gx_hidden_field( context, "GRIDCOMPONENT_GRID_Showborders", StringUtil.BoolToStr( Gridcomponent_grid_Showborders));
         GxWebStd.gx_hidden_field( context, "GRIDCOMPONENT_GRID_Containseditableform", StringUtil.BoolToStr( Gridcomponent_grid_Containseditableform));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
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
            WE4I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4I2( ) ;
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
         return formatLink("k2bfsg.wwmenuoptions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV27MenuId,12,0))}, new string[] {"ApplicationId","MenuId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.WWMenuOptions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Menu options" ;
      }

      protected void WB4I0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Menu options", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
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
            ucResponsivetable_mainattributes_attributes.SetProperty("Title", Responsivetable_mainattributes_attributes_Title);
            ucResponsivetable_mainattributes_attributes.SetProperty("Collapsible", Responsivetable_mainattributes_attributes_Collapsible);
            ucResponsivetable_mainattributes_attributes.SetProperty("Open", Responsivetable_mainattributes_attributes_Open);
            ucResponsivetable_mainattributes_attributes.SetProperty("ShowBorders", Responsivetable_mainattributes_attributes_Showborders);
            ucResponsivetable_mainattributes_attributes.SetProperty("ContainsEditableForm", Responsivetable_mainattributes_attributes_Containseditableform);
            ucResponsivetable_mainattributes_attributes.Render(context, "k2bt_component", Responsivetable_mainattributes_attributes_Internalname, "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTESContainer"+"Responsivetable_mainattributes_attributes_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_applicationname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavApplicationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavApplicationname_Internalname, "Application", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavApplicationname_Internalname, StringUtil.RTrim( AV10ApplicationName), StringUtil.RTrim( context.localUtil.Format( AV10ApplicationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavApplicationname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavApplicationname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WWMenuOptions.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_menuname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMenuname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMenuname_Internalname, "Name", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMenuname_Internalname, StringUtil.RTrim( AV28MenuName), StringUtil.RTrim( context.localUtil.Format( AV28MenuName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMenuname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMenuname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WWMenuOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_menudescription_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavMenudescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMenudescription_Internalname, "Description", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMenudescription_Internalname, StringUtil.RTrim( AV26MenuDescription), StringUtil.RTrim( context.localUtil.Format( AV26MenuDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMenudescription_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavMenudescription_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\WWMenuOptions.htm");
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
            ucGridcomponent_grid.SetProperty("Title", Gridcomponent_grid_Title);
            ucGridcomponent_grid.SetProperty("Collapsible", Gridcomponent_grid_Collapsible);
            ucGridcomponent_grid.SetProperty("Open", Gridcomponent_grid_Open);
            ucGridcomponent_grid.SetProperty("ShowBorders", Gridcomponent_grid_Showborders);
            ucGridcomponent_grid.SetProperty("ContainsEditableForm", Gridcomponent_grid_Containseditableform);
            ucGridcomponent_grid.Render(context, "k2bt_component", Gridcomponent_grid_Internalname, "GRIDCOMPONENT_GRIDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GRIDCOMPONENT_GRIDContainer"+"Gridcomponent_grid_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_grid_content_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BeforeGridContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercontainersection_grid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_onlygenericfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table9_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table8_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_SearchContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_113_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV48GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV48GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search by name", edtavGenericfilter_grid_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\WWMenuOptions.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Grid Settings", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114i1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWMenuOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertablegrid_Internalname, divGridsettings_contentoutertablegrid_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, "Grid Settings", "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, "Rows per page", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_113_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_grid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, "Freeze column titles", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_113_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid), "", "Freeze column titles", 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Apply", bttGridsettings_savegrid_Jsonclick, 5, "Apply", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWMenuOptions.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_topright_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(113), 3, 0)+","+"null"+");", "Add new", bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWMenuOptions.htm");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_grid_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl113( ) ;
         }
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            nRC_GXsfl_113 = (int)(nGXsfl_113_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_125_4I2( true) ;
         }
         else
         {
            wb_table1_125_4I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_125_4I2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_grid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_grid_Internalname, divPaginationbar_pagingcontainertable_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124i1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e134i1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124i1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e144i1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+""+"'"+",false,"+"'"+"e144i1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
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
         if ( wbEnd == 113 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4I2( )
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
         Form.Meta.addItem("description", "Menu options", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4I0( ) ;
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(Grid)' */
                              E154I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_Add' */
                              E164I2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "'E_UP'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_DOWN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'E_OPTIONS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "'E_UP'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'E_DOWN'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'E_OPTIONS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_UPDATE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
                              SubsflControlProps_1132( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavOptionid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOptionid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPTIONID");
                                 GX_FocusControl = edtavOptionid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV33OptionId = 0;
                                 AssignAttri("", false, edtavOptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV33OptionId), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vOPTIONID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV33OptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavOptionid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavOptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV33OptionId), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vOPTIONID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9"), context));
                              }
                              AV34OptionName = cgiGet( edtavOptionname_Internalname);
                              AssignAttri("", false, edtavOptionname_Internalname, AV34OptionName);
                              AV32OptionDescription = cgiGet( edtavOptiondescription_Internalname);
                              AssignAttri("", false, edtavOptiondescription_Internalname, AV32OptionDescription);
                              cmbavOptiontype.Name = cmbavOptiontype_Internalname;
                              cmbavOptiontype.CurrentValue = cgiGet( cmbavOptiontype_Internalname);
                              AV35OptionType = cgiGet( cmbavOptiontype_Internalname);
                              AssignAttri("", false, cmbavOptiontype_Internalname, AV35OptionType);
                              AV41Up_Action = cgiGet( edtavUp_action_Internalname);
                              AssignAttri("", false, edtavUp_action_Internalname, AV41Up_Action);
                              AV13Down_Action = cgiGet( edtavDown_action_Internalname);
                              AssignAttri("", false, edtavDown_action_Internalname, AV13Down_Action);
                              AV44Options_Action = cgiGet( edtavOptions_action_Internalname);
                              AssignAttri("", false, edtavOptions_action_Internalname, AV44Options_Action);
                              AV46Update_Action = cgiGet( edtavUpdate_action_Internalname);
                              AssignProp("", false, edtavUpdate_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)) ? AV55Update_action_GXI : context.convertURL( context.PathToRelativeUrl( AV46Update_Action))), !bGXsfl_113_Refreshing);
                              AssignProp("", false, edtavUpdate_action_Internalname, "SrcSet", context.GetImageSrcSet( AV46Update_Action), true);
                              AV47Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp("", false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)) ? AV56Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV47Delete_Action))), !bGXsfl_113_Refreshing);
                              AssignProp("", false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV47Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E174I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E184I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_UP'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Up' */
                                    E214I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DOWN'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Down' */
                                    E224I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_UPDATE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Update' */
                                    E234I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Delete' */
                                    E244I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_OPTIONS'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Options' */
                                    E254I2 ();
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

      protected void WE4I2( )
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

      protected void PA4I2( )
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
               GX_FocusControl = edtavApplicationname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1132( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            sendrow_1132( ) ;
            nGXsfl_113_idx = ((subGrid_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_1132( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV52GenericFilter_PreviousValue_Grid ,
                                       string AV53Pgmname ,
                                       short AV12CurrentPage_Grid ,
                                       string AV48GenericFilter_Grid ,
                                       bool AV22HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV49GridConfiguration ,
                                       GxSimpleCollection<string> AV50ClassCollection_Grid ,
                                       short AV38RowsPerPage_Grid ,
                                       short AV24I_LoadCount_Grid ,
                                       long AV9ApplicationId ,
                                       long AV27MenuId ,
                                       bool AV51FreezeColumnTitles_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vOPTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33OptionId), 12, 0, ".", "")));
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
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV18GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E184I2 ();
         RF4I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "K2BFSG.WWMenuOptions";
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), true);
         edtavMenudescription_Enabled = 0;
         AssignProp("", false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), true);
         edtavOptionid_Enabled = 0;
         AssignProp("", false, edtavOptionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionid_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptionname_Enabled = 0;
         AssignProp("", false, edtavOptionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionname_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptiondescription_Enabled = 0;
         AssignProp("", false, edtavOptiondescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiondescription_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         cmbavOptiontype.Enabled = 0;
         AssignProp("", false, cmbavOptiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOptiontype.Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavUp_action_Enabled = 0;
         AssignProp("", false, edtavUp_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUp_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavDown_action_Enabled = 0;
         AssignProp("", false, edtavDown_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDown_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp("", false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 113;
         /* Execute user event: Refresh */
         E184I2 ();
         E194I2 ();
         nGXsfl_113_idx = 1;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1132( ) ;
         bGXsfl_113_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1132( ) ;
            E204I2 ();
            wbEnd = 113;
            WB4I0( ) ;
         }
         bGXsfl_113_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4I2( )
      {
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV52GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_GRID", AV22HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV22HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPTIONID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "K2BFSG.WWMenuOptions";
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavMenuname_Enabled = 0;
         AssignProp("", false, edtavMenuname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenuname_Enabled), 5, 0), true);
         edtavMenudescription_Enabled = 0;
         AssignProp("", false, edtavMenudescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMenudescription_Enabled), 5, 0), true);
         edtavOptionid_Enabled = 0;
         AssignProp("", false, edtavOptionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionid_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptionname_Enabled = 0;
         AssignProp("", false, edtavOptionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptionname_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptiondescription_Enabled = 0;
         AssignProp("", false, edtavOptiondescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiondescription_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         cmbavOptiontype.Enabled = 0;
         AssignProp("", false, cmbavOptiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOptiontype.Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavUp_action_Enabled = 0;
         AssignProp("", false, edtavUp_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUp_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavDown_action_Enabled = 0;
         AssignProp("", false, edtavDown_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDown_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtavOptions_action_Enabled = 0;
         AssignProp("", false, edtavOptions_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptions_action_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E174I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ".", ","), 18, MidpointRounding.ToEven));
            AV27MenuId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMENUID"), ".", ","), 18, MidpointRounding.ToEven));
            AV9ApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vAPPLICATIONID"), ".", ","), 18, MidpointRounding.ToEven));
            AV38RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV12CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV22HasNextPage_Grid = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            Responsivetable_mainattributes_attributes_Title = cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Title");
            Responsivetable_mainattributes_attributes_Collapsible = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Collapsible"));
            Responsivetable_mainattributes_attributes_Open = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Open"));
            Responsivetable_mainattributes_attributes_Showborders = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Showborders"));
            Responsivetable_mainattributes_attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_Containseditableform"));
            Gridcomponent_grid_Title = cgiGet( "GRIDCOMPONENT_GRID_Title");
            Gridcomponent_grid_Collapsible = StringUtil.StrToBool( cgiGet( "GRIDCOMPONENT_GRID_Collapsible"));
            Gridcomponent_grid_Open = StringUtil.StrToBool( cgiGet( "GRIDCOMPONENT_GRID_Open"));
            Gridcomponent_grid_Showborders = StringUtil.StrToBool( cgiGet( "GRIDCOMPONENT_GRID_Showborders"));
            Gridcomponent_grid_Containseditableform = StringUtil.StrToBool( cgiGet( "GRIDCOMPONENT_GRID_Containseditableform"));
            /* Read variables values. */
            AV10ApplicationName = cgiGet( edtavApplicationname_Internalname);
            AssignAttri("", false, "AV10ApplicationName", AV10ApplicationName);
            AV28MenuName = cgiGet( edtavMenuname_Internalname);
            AssignAttri("", false, "AV28MenuName", AV28MenuName);
            AV26MenuDescription = cgiGet( edtavMenudescription_Internalname);
            AssignAttri("", false, "AV26MenuDescription", AV26MenuDescription);
            AV48GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV48GenericFilter_Grid", AV48GenericFilter_Grid);
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV18GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
            AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
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
         E174I2 ();
         if (returnInSub) return;
      }

      protected void E174I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bloadrowsperpage(context ).execute(  AV53Pgmname,  "Grid", out  AV38RowsPerPage_Grid, out  AV45RowsPerPageLoaded_Grid) ;
         AssignAttri("", false, "AV38RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV38RowsPerPage_Grid), 4, 0));
         if ( ! AV45RowsPerPageLoaded_Grid )
         {
            AV38RowsPerPage_Grid = 20;
            AssignAttri("", false, "AV38RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV38RowsPerPage_Grid), 4, 0));
         }
         AV18GridSettingsRowsPerPage_Grid = AV38RowsPerPage_Grid;
         AssignAttri("", false, "AV18GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV52GenericFilter_PreviousValue_Grid = AV48GenericFilter_Grid;
         AssignAttri("", false, "AV52GenericFilter_PreviousValue_Grid", AV52GenericFilter_PreviousValue_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E184I2( )
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
         if ( (0==AV12CurrentPage_Grid) )
         {
            AV12CurrentPage_Grid = 1;
            AssignAttri("", false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV52GenericFilter_PreviousValue_Grid, AV48GenericFilter_Grid) != 0 )
         {
            AV52GenericFilter_PreviousValue_Grid = AV48GenericFilter_Grid;
            AssignAttri("", false, "AV52GenericFilter_PreviousValue_Grid", AV52GenericFilter_PreviousValue_Grid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52GenericFilter_PreviousValue_Grid, "")), context));
            AV12CurrentPage_Grid = 1;
            AssignAttri("", false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         AV36Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S152 ();
         if (returnInSub) return;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV50ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV50ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV8Application.load( AV9ApplicationId);
         AV10ApplicationName = AV8Application.gxTpr_Name;
         AssignAttri("", false, "AV10ApplicationName", AV10ApplicationName);
         AV25Menu = AV8Application.getmenu(AV27MenuId, out  AV15Errors);
         AV28MenuName = AV25Menu.gxTpr_Name;
         AssignAttri("", false, "AV28MenuName", AV28MenuName);
         AV26MenuDescription = AV25Menu.gxTpr_Description;
         AssignAttri("", false, "AV26MenuDescription", AV26MenuDescription);
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message2 = AV5Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message2) ;
         AV5Messages = GXt_objcol_SdtMessages_Message2;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV5Messages.Count )
         {
            AV31Message = ((GeneXus.Utils.SdtMessages_Message)AV5Messages.Item(AV54GXV1));
            GX_msglist.addItem(AV31Message.gxTpr_Description);
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void E194I2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
      }

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E204I2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV24I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV24I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV24I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24I_LoadCount_Grid), "ZZZ9"), context));
         AV22HasNextPage_Grid = false;
         AssignAttri("", false, "AV22HasNextPage_Grid", AV22HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV22HasNextPage_Grid, context));
         AV16Exit_Grid = false;
         while ( true )
         {
            AV24I_LoadCount_Grid = (short)(AV24I_LoadCount_Grid+1);
            AssignAttri("", false, "AV24I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV24I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S202 ();
            if (returnInSub) return;
            AV41Up_Action = "Up";
            AssignAttri("", false, edtavUp_action_Internalname, AV41Up_Action);
            AV13Down_Action = "Down";
            AssignAttri("", false, edtavDown_action_Internalname, AV13Down_Action);
            AV44Options_Action = "Options";
            AssignAttri("", false, edtavOptions_action_Internalname, AV44Options_Action);
            edtavUpdate_action_gximage = "K2BActionUpdate";
            AV46Update_Action = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
            AssignAttri("", false, edtavUpdate_action_Internalname, AV46Update_Action);
            AV55Update_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            edtavUpdate_action_Tooltiptext = "Update";
            edtavDelete_action_gximage = "K2BActionDelete";
            AV47Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri("", false, edtavDelete_action_Internalname, AV47Delete_Action);
            AV56Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = "Delete";
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S212 ();
            if (returnInSub) return;
            if ( AV16Exit_Grid )
            {
               if (true) break;
            }
            if ( AV24I_LoadCount_Grid > AV38RowsPerPage_Grid * AV12CurrentPage_Grid )
            {
               AV22HasNextPage_Grid = true;
               AssignAttri("", false, "AV22HasNextPage_Grid", AV22HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( "", AV22HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV24I_LoadCount_Grid > AV38RowsPerPage_Grid * ( AV12CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 113;
               }
               sendrow_1132( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_113_Refreshing )
               {
                  context.DoAjaxLoad(113, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17Filter", AV17Filter);
         cmbavOptiontype.CurrentValue = StringUtil.RTrim( AV35OptionType);
      }

      protected void S202( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV24I_LoadCount_Grid == 1 )
         {
            AV8Application.load( AV9ApplicationId);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48GenericFilter_Grid)) )
            {
               AV17Filter.gxTpr_Name = "%"+AV48GenericFilter_Grid;
            }
            AV30MenuOptions = AV8Application.getmenuoptions(AV27MenuId, AV17Filter, out  AV15Errors);
         }
         if ( AV30MenuOptions.Count >= AV24I_LoadCount_Grid )
         {
            AV33OptionId = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV30MenuOptions.Item(AV24I_LoadCount_Grid)).gxTpr_Id;
            AssignAttri("", false, edtavOptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV33OptionId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vOPTIONID"+"_"+sGXsfl_113_idx, GetSecureSignedToken( sGXsfl_113_idx, context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9"), context));
            AV34OptionName = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV30MenuOptions.Item(AV24I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri("", false, edtavOptionname_Internalname, AV34OptionName);
            AV32OptionDescription = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV30MenuOptions.Item(AV24I_LoadCount_Grid)).gxTpr_Description;
            AssignAttri("", false, edtavOptiondescription_Internalname, AV32OptionDescription);
            AV35OptionType = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption)AV30MenuOptions.Item(AV24I_LoadCount_Grid)).gxTpr_Type;
            AssignAttri("", false, cmbavOptiontype_Internalname, AV35OptionType);
            if ( StringUtil.StrCmp(AV35OptionType, "M") == 0 )
            {
               AV44Options_Action = "Options";
               AssignAttri("", false, edtavOptions_action_Internalname, AV44Options_Action);
            }
            else
            {
               AV44Options_Action = "";
               AssignAttri("", false, edtavOptions_action_Internalname, AV44Options_Action);
            }
         }
         else
         {
            AV16Exit_Grid = true;
         }
      }

      protected void S192( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV12CurrentPage_Grid+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV12CurrentPage_Grid) || ( AV12CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV12CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV12CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV22HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV12CurrentPage_Grid <= 1 ) && ! AV22HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV21GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV21GridStateKey, out  AV19GridState) ;
         AV19GridState.gxTpr_Currentpage = AV12CurrentPage_Grid;
         AV19GridState.gxTpr_Filtervalues.Clear();
         AV20GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV20GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV20GridStateFilterValue.gxTpr_Value = AV48GenericFilter_Grid;
         AV19GridState.gxTpr_Filtervalues.Add(AV20GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV53Pgmname,  AV21GridStateKey,  AV19GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV21GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV53Pgmname,  AV21GridStateKey, out  AV19GridState) ;
         AV57GXV2 = 1;
         while ( AV57GXV2 <= AV19GridState.gxTpr_Filtervalues.Count )
         {
            AV20GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV19GridState.gxTpr_Filtervalues.Item(AV57GXV2));
            if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV48GenericFilter_Grid = AV20GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48GenericFilter_Grid", AV48GenericFilter_Grid);
            }
            AV57GXV2 = (int)(AV57GXV2+1);
         }
         if ( AV19GridState.gxTpr_Currentpage > 0 )
         {
            AV12CurrentPage_Grid = AV19GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
      }

      protected void S282( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp("", false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
      }

      protected void E154I2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV53Pgmname,  "Grid", ref  AV49GridConfiguration) ;
         AV49GridConfiguration.gxTpr_Freezecolumntitles = AV51FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV53Pgmname,  "Grid",  AV49GridConfiguration,  true) ;
         if ( AV38RowsPerPage_Grid != AV18GridSettingsRowsPerPage_Grid )
         {
            AV38RowsPerPage_Grid = AV18GridSettingsRowsPerPage_Grid;
            AssignAttri("", false, "AV38RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV38RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV53Pgmname,  "Grid",  AV38RowsPerPage_Grid) ;
            AV12CurrentPage_Grid = 1;
            AssignAttri("", false, "AV12CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV12CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV53Pgmname, AV12CurrentPage_Grid, AV48GenericFilter_Grid, AV22HasNextPage_Grid, AV49GridConfiguration, AV50ClassCollection_Grid, AV38RowsPerPage_Grid, AV24I_LoadCount_Grid, AV9ApplicationId, AV27MenuId, AV51FreezeColumnTitles_Grid) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
      }

      protected void E214I2( )
      {
         /* 'E_Up' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_UP' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S222( )
      {
         /* 'U_UP' Routine */
         returnInSub = false;
         AV37Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV8Application.load( AV9ApplicationId);
         AV29MenuOption = AV8Application.getmenuoption(AV27MenuId, AV33OptionId, out  AV15Errors);
         AV29MenuOption.moveup( AV37Repository.gxTpr_Id,  AV9ApplicationId,  AV27MenuId, out  AV15Errors);
         if ( AV15Errors.Count > 0 )
         {
            AV58GXV3 = 1;
            while ( AV58GXV3 <= AV15Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV58GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV58GXV3 = (int)(AV58GXV3+1);
            }
         }
         else
         {
            context.CommitDataStores("k2bfsg.wwmenuoptions",pr_default);
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV53Pgmname, AV12CurrentPage_Grid, AV48GenericFilter_Grid, AV22HasNextPage_Grid, AV49GridConfiguration, AV50ClassCollection_Grid, AV38RowsPerPage_Grid, AV24I_LoadCount_Grid, AV9ApplicationId, AV27MenuId, AV51FreezeColumnTitles_Grid) ;
      }

      protected void E224I2( )
      {
         /* 'E_Down' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DOWN' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S232( )
      {
         /* 'U_DOWN' Routine */
         returnInSub = false;
         AV37Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV8Application.load( AV9ApplicationId);
         AV29MenuOption = AV8Application.getmenuoption(AV27MenuId, AV33OptionId, out  AV15Errors);
         AV29MenuOption.movedown( AV37Repository.gxTpr_Id,  AV9ApplicationId,  AV27MenuId, out  AV15Errors);
         if ( AV15Errors.Count > 0 )
         {
            AV59GXV4 = 1;
            while ( AV59GXV4 <= AV15Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV15Errors.Item(AV59GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV59GXV4 = (int)(AV59GXV4+1);
            }
         }
         else
         {
            context.CommitDataStores("k2bfsg.wwmenuoptions",pr_default);
         }
         gxgrGrid_refresh( AV52GenericFilter_PreviousValue_Grid, AV53Pgmname, AV12CurrentPage_Grid, AV48GenericFilter_Grid, AV22HasNextPage_Grid, AV49GridConfiguration, AV50ClassCollection_Grid, AV38RowsPerPage_Grid, AV24I_LoadCount_Grid, AV9ApplicationId, AV27MenuId, AV51FreezeColumnTitles_Grid) ;
      }

      protected void E164I2( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S242( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         AV42Window.Autoresize = 1;
         AV42Window.Url = formatLink("k2bfsg.entrymenuoption.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV27MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","ApplicationId","MenuId","MenuOptionId"}) ;
         AV42Window.SetReturnParms(new Object[] {"AV9ApplicationId","AV27MenuId","",});
         context.NewWindow(AV42Window);
         context.DoAjaxRefresh();
      }

      protected void E234I2( )
      {
         /* 'E_Update' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_UPDATE' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S252( )
      {
         /* 'U_UPDATE' Routine */
         returnInSub = false;
         AV42Window.Autoresize = 1;
         AV42Window.Url = formatLink("k2bfsg.entrymenuoption.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV27MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV33OptionId,12,0))}, new string[] {"Mode","ApplicationId","MenuId","MenuOptionId"}) ;
         AV42Window.SetReturnParms(new Object[] {"AV9ApplicationId","AV27MenuId","AV33OptionId",});
         context.NewWindow(AV42Window);
         context.DoAjaxRefresh();
      }

      protected void E244I2( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ClassCollection_Grid", AV50ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49GridConfiguration", AV49GridConfiguration);
      }

      protected void S262( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV42Window.Autoresize = 1;
         AV42Window.Url = formatLink("k2bfsg.entrymenuoption.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV27MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV33OptionId,12,0))}, new string[] {"Mode","ApplicationId","MenuId","MenuOptionId"}) ;
         AV42Window.SetReturnParms(new Object[] {"AV9ApplicationId","AV27MenuId","AV33OptionId",});
         context.NewWindow(AV42Window);
         context.DoAjaxRefresh();
      }

      protected void E254I2( )
      {
         /* 'E_Options' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPTIONS' */
         S272 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S272( )
      {
         /* 'U_OPTIONS' Routine */
         returnInSub = false;
         AV8Application.load( AV9ApplicationId);
         AV43ApplicationMenuOption = AV8Application.getmenuoption(AV27MenuId, AV33OptionId, out  AV15Errors);
         if ( StringUtil.StrCmp(AV43ApplicationMenuOption.gxTpr_Type, "M") == 0 )
         {
            CallWebObject(formatLink("k2bfsg.wwmenuoptions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV43ApplicationMenuOption.gxTpr_Submenuid,12,0))}, new string[] {"ApplicationId","MenuId"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S142( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S282 ();
         if (returnInSub) return;
      }

      protected void S212( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV53Pgmname,  "Grid", ref  AV49GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S292 ();
         if (returnInSub) return;
      }

      protected void S292( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV51FreezeColumnTitles_Grid = AV49GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
         if ( AV51FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV50ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV50ClassCollection_Grid) ;
         }
      }

      protected void wb_table1_125_4I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWMenuOptions.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_125_4I2e( true) ;
         }
         else
         {
            wb_table1_125_4I2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9ApplicationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV9ApplicationId", StringUtil.LTrimStr( (decimal)(AV9ApplicationId), 12, 0));
         AV27MenuId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV27MenuId", StringUtil.LTrimStr( (decimal)(AV27MenuId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27MenuId), "ZZZZZZZZZZZ9"), context));
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138211542", true, true);
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
         context.AddJavascriptSource("k2bfsg/wwmenuoptions.js", "?20243138211546", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1132( )
      {
         edtavOptionid_Internalname = "vOPTIONID_"+sGXsfl_113_idx;
         edtavOptionname_Internalname = "vOPTIONNAME_"+sGXsfl_113_idx;
         edtavOptiondescription_Internalname = "vOPTIONDESCRIPTION_"+sGXsfl_113_idx;
         cmbavOptiontype_Internalname = "vOPTIONTYPE_"+sGXsfl_113_idx;
         edtavUp_action_Internalname = "vUP_ACTION_"+sGXsfl_113_idx;
         edtavDown_action_Internalname = "vDOWN_ACTION_"+sGXsfl_113_idx;
         edtavOptions_action_Internalname = "vOPTIONS_ACTION_"+sGXsfl_113_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_113_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_1132( )
      {
         edtavOptionid_Internalname = "vOPTIONID_"+sGXsfl_113_fel_idx;
         edtavOptionname_Internalname = "vOPTIONNAME_"+sGXsfl_113_fel_idx;
         edtavOptiondescription_Internalname = "vOPTIONDESCRIPTION_"+sGXsfl_113_fel_idx;
         cmbavOptiontype_Internalname = "vOPTIONTYPE_"+sGXsfl_113_fel_idx;
         edtavUp_action_Internalname = "vUP_ACTION_"+sGXsfl_113_fel_idx;
         edtavDown_action_Internalname = "vDOWN_ACTION_"+sGXsfl_113_fel_idx;
         edtavOptions_action_Internalname = "vOPTIONS_ACTION_"+sGXsfl_113_fel_idx;
         edtavUpdate_action_Internalname = "vUPDATE_ACTION_"+sGXsfl_113_fel_idx;
         edtavDelete_action_Internalname = "vDELETE_ACTION_"+sGXsfl_113_fel_idx;
      }

      protected void sendrow_1132( )
      {
         SubsflControlProps_1132( ) ;
         WB4I0( ) ;
         GridRow = GXWebRow.GetNew(context,GridContainer);
         if ( subGrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
         }
         else if ( subGrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid_Backstyle = 0;
            subGrid_Backcolor = subGrid_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Uniform";
            }
         }
         else if ( subGrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
            subGrid_Backcolor = (int)(0x0);
         }
         else if ( subGrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Even";
               }
            }
            else
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_113_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptionid_Enabled!=0)&&(edtavOptionid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 114,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33OptionId), 12, 0, ".", "")),StringUtil.LTrim( ((edtavOptionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV33OptionId), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavOptionid_Enabled!=0)&&(edtavOptionid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,114);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptionid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtavOptionid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptionname_Enabled!=0)&&(edtavOptionname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 115,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptionname_Internalname,StringUtil.RTrim( AV34OptionName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOptionname_Enabled!=0)&&(edtavOptionname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,115);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e264i2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptionname_Jsonclick,(short)7,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavOptionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptiondescription_Enabled!=0)&&(edtavOptiondescription_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 116,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptiondescription_Internalname,StringUtil.RTrim( AV32OptionDescription),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOptiondescription_Enabled!=0)&&(edtavOptiondescription_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,116);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptiondescription_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavOptiondescription_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavOptiontype.Enabled!=0)&&(cmbavOptiontype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 117,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         if ( ( cmbavOptiontype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vOPTIONTYPE_" + sGXsfl_113_idx;
            cmbavOptiontype.Name = GXCCtl;
            cmbavOptiontype.WebTags = "";
            cmbavOptiontype.addItem("S", "Simple", 0);
            cmbavOptiontype.addItem("M", "Menu", 0);
            if ( cmbavOptiontype.ItemCount > 0 )
            {
               AV35OptionType = cmbavOptiontype.getValidValue(AV35OptionType);
               AssignAttri("", false, cmbavOptiontype_Internalname, AV35OptionType);
            }
         }
         /* ComboBox */
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavOptiontype,(string)cmbavOptiontype_Internalname,StringUtil.RTrim( AV35OptionType),(short)1,(string)cmbavOptiontype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavOptiontype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavOptiontype.Enabled!=0)&&(cmbavOptiontype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,117);\"" : " "),(string)"",(bool)true,(short)0});
         cmbavOptiontype.CurrentValue = StringUtil.RTrim( AV35OptionType);
         AssignProp("", false, cmbavOptiontype_Internalname, "Values", (string)(cmbavOptiontype.ToJavascriptSource()), !bGXsfl_113_Refreshing);
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavUp_action_Enabled!=0)&&(edtavUp_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 118,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUp_action_Internalname,StringUtil.RTrim( AV41Up_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUp_action_Enabled!=0)&&(edtavUp_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,118);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_UP\\'."+sGXsfl_113_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUp_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavUp_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDown_action_Enabled!=0)&&(edtavDown_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 119,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDown_action_Internalname,StringUtil.RTrim( AV13Down_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDown_action_Enabled!=0)&&(edtavDown_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,119);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_DOWN\\'."+sGXsfl_113_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDown_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavDown_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 120,'',false,'"+sGXsfl_113_idx+"',113)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptions_action_Internalname,StringUtil.RTrim( AV44Options_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavOptions_action_Enabled!=0)&&(edtavOptions_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,120);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_OPTIONS\\'."+sGXsfl_113_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptions_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(short)-1,(int)edtavOptions_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_action_Enabled!=0)&&(edtavUpdate_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 121,'',false,'',113)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class");
         StyleString = "";
         AV46Update_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV55Update_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV46Update_Action)) ? AV55Update_action_GXI : context.PathToRelativeUrl( AV46Update_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Update",(string)edtavUpdate_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUpdate_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_UPDATE\\'."+sGXsfl_113_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV46Update_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 122,'',false,'',113)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV47Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV56Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47Delete_Action)) ? AV56Delete_action_GXI : context.PathToRelativeUrl( AV47Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'E_DELETE\\'."+sGXsfl_113_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV47Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes4I2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_113_idx = ((subGrid_Islastpage==1)&&(nGXsfl_113_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_1132( ) ;
         /* End function sendrow_1132 */
      }

      protected void init_web_controls( )
      {
         cmbavGridsettingsrowsperpage_grid.Name = "vGRIDSETTINGSROWSPERPAGE_GRID";
         cmbavGridsettingsrowsperpage_grid.WebTags = "";
         cmbavGridsettingsrowsperpage_grid.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_grid.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_grid.ItemCount > 0 )
         {
            AV18GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV18GridSettingsRowsPerPage_Grid), 4, 0));
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         AV51FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV51FreezeColumnTitles_Grid));
         AssignAttri("", false, "AV51FreezeColumnTitles_Grid", AV51FreezeColumnTitles_Grid);
         GXCCtl = "vOPTIONTYPE_" + sGXsfl_113_idx;
         cmbavOptiontype.Name = GXCCtl;
         cmbavOptiontype.WebTags = "";
         cmbavOptiontype.addItem("S", "Simple", 0);
         cmbavOptiontype.addItem("M", "Menu", 0);
         if ( cmbavOptiontype.ItemCount > 0 )
         {
            AV35OptionType = cmbavOptiontype.getValidValue(AV35OptionType);
            AssignAttri("", false, cmbavOptiontype_Internalname, AV35OptionType);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl113( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"113\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavUpdate_action_gximage, "")==0) ? "" : "GX_Image_"+edtavUpdate_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33OptionId), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34OptionName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV32OptionDescription)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptiondescription_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV35OptionType)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavOptiontype.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41Up_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUp_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Down_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDown_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV44Options_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptions_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV46Update_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV47Delete_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_action_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         edtavApplicationname_Internalname = "vAPPLICATIONNAME";
         divTable_container_applicationname_Internalname = "TABLE_CONTAINER_APPLICATIONNAME";
         edtavMenuname_Internalname = "vMENUNAME";
         divTable_container_menuname_Internalname = "TABLE_CONTAINER_MENUNAME";
         edtavMenudescription_Internalname = "vMENUDESCRIPTION";
         divTable_container_menudescription_Internalname = "TABLE_CONTAINER_MENUDESCRIPTION";
         divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_content_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES_CONTENT";
         Responsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         divLayoutdefined_table8_grid_Internalname = "LAYOUTDEFINED_TABLE8_GRID";
         divLayoutdefined_table9_grid_Internalname = "LAYOUTDEFINED_TABLE9_GRID";
         divLayoutdefined_onlygenericfilterlayout_grid_Internalname = "LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = "LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         imgGridsettings_labelgrid_Internalname = "GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_grid_Internalname = "vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = "ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = "vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = "FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = "GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = "GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = "GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = "GRIDSETTINGS_GLOBALTABLE_GRID";
         bttAdd_Internalname = "ADD";
         divActions_grid_topright_Internalname = "ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         edtavOptionid_Internalname = "vOPTIONID";
         edtavOptionname_Internalname = "vOPTIONNAME";
         edtavOptiondescription_Internalname = "vOPTIONDESCRIPTION";
         cmbavOptiontype_Internalname = "vOPTIONTYPE";
         edtavUp_action_Internalname = "vUP_ACTION";
         edtavDown_action_Internalname = "vDOWN_ACTION";
         edtavOptions_action_Internalname = "vOPTIONS_ACTION";
         edtavUpdate_action_Internalname = "vUPDATE_ACTION";
         edtavDelete_action_Internalname = "vDELETE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = "LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
         divGridcomponent_grid_content_Internalname = "GRIDCOMPONENT_GRID_CONTENT";
         Gridcomponent_grid_Internalname = "GRIDCOMPONENT_GRID";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavFreezecolumntitles_grid.Caption = "Freeze column titles";
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_gximage = "";
         edtavDelete_action_Visible = -1;
         edtavDelete_action_Enabled = 1;
         edtavDelete_action_Tooltiptext = "";
         edtavUpdate_action_Jsonclick = "";
         edtavUpdate_action_gximage = "";
         edtavUpdate_action_Visible = -1;
         edtavUpdate_action_Enabled = 1;
         edtavUpdate_action_Tooltiptext = "";
         edtavOptions_action_Jsonclick = "";
         edtavOptions_action_Visible = -1;
         edtavOptions_action_Enabled = 1;
         edtavDown_action_Jsonclick = "";
         edtavDown_action_Visible = -1;
         edtavDown_action_Enabled = 1;
         edtavUp_action_Jsonclick = "";
         edtavUp_action_Visible = -1;
         edtavUp_action_Enabled = 1;
         cmbavOptiontype_Jsonclick = "";
         cmbavOptiontype.Visible = -1;
         cmbavOptiontype.Enabled = 1;
         edtavOptiondescription_Jsonclick = "";
         edtavOptiondescription_Visible = -1;
         edtavOptiondescription_Enabled = 1;
         edtavOptionname_Jsonclick = "";
         edtavOptionname_Visible = -1;
         edtavOptionname_Enabled = 1;
         edtavOptionid_Jsonclick = "";
         edtavOptionid_Visible = 0;
         edtavOptionid_Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
         lblPaginationbar_nextpagetextblockgrid_Caption = "#";
         lblPaginationbar_nextpagetextblockgrid_Visible = 1;
         lblPaginationbar_currentpagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Caption = "#";
         lblPaginationbar_previouspagetextblockgrid_Visible = 1;
         lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         lblPaginationbar_firstpagetextblockgrid_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_grid_Visible = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         bttAdd_Visible = 1;
         chkavFreezecolumntitles_grid.Enabled = 1;
         cmbavGridsettingsrowsperpage_grid_Jsonclick = "";
         cmbavGridsettingsrowsperpage_grid.Enabled = 1;
         divGridsettings_contentoutertablegrid_Visible = 1;
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         edtavMenudescription_Jsonclick = "";
         edtavMenudescription_Enabled = 1;
         edtavMenuname_Jsonclick = "";
         edtavMenuname_Enabled = 1;
         edtavApplicationname_Jsonclick = "";
         edtavApplicationname_Enabled = 1;
         Gridcomponent_grid_Containseditableform = Convert.ToBoolean( 0);
         Gridcomponent_grid_Showborders = Convert.ToBoolean( -1);
         Gridcomponent_grid_Open = Convert.ToBoolean( -1);
         Gridcomponent_grid_Collapsible = Convert.ToBoolean( 0);
         Gridcomponent_grid_Title = "Options";
         Responsivetable_mainattributes_attributes_Containseditableform = Convert.ToBoolean( 0);
         Responsivetable_mainattributes_attributes_Showborders = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Open = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Collapsible = Convert.ToBoolean( -1);
         Responsivetable_mainattributes_attributes_Title = "Menu";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Menu options";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E194I2',iparms:[{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E204I2',iparms:[{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV41Up_Action',fld:'vUP_ACTION',pic:''},{av:'AV13Down_Action',fld:'vDOWN_ACTION',pic:''},{av:'AV44Options_Action',fld:'vOPTIONS_ACTION',pic:''},{av:'AV46Update_Action',fld:'vUPDATE_ACTION',pic:''},{av:'edtavUpdate_action_Tooltiptext',ctrl:'vUPDATE_ACTION',prop:'Tooltiptext'},{av:'AV47Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV34OptionName',fld:'vOPTIONNAME',pic:''},{av:'AV32OptionDescription',fld:'vOPTIONDESCRIPTION',pic:''},{av:'cmbavOptiontype'},{av:'AV35OptionType',fld:'vOPTIONTYPE',pic:''},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E134I1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E124I1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E144I1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E114I1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV18GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E154I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV18GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UP'","{handler:'E214I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_UP'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_DOWN'","{handler:'E224I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_DOWN'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ADD'","{handler:'E164I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_UPDATE'","{handler:'E234I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_UPDATE'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("VOPTIONNAME.CLICK","{handler:'E264I2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("VOPTIONNAME.CLICK",",oparms:[]}");
         setEventMetadata("'E_DELETE'","{handler:'E244I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV53Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV48GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV22HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV24I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV12CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV52GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV50ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV49GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV51FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_OPTIONS'","{handler:'E254I2',iparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV27MenuId',fld:'vMENUID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV33OptionId',fld:'vOPTIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'E_OPTIONS'",",oparms:[{av:'AV9ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_OPTIONTYPE","{handler:'Validv_Optiontype',iparms:[]");
         setEventMetadata("VALIDV_OPTIONTYPE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete_action',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV52GenericFilter_PreviousValue_Grid = "";
         AV53Pgmname = "";
         AV48GenericFilter_Grid = "";
         AV49GridConfiguration = new SdtK2BGridConfiguration(context);
         AV50ClassCollection_Grid = new GxSimpleCollection<string>();
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
         ucResponsivetable_mainattributes_attributes = new GXUserControl();
         TempTags = "";
         AV10ApplicationName = "";
         AV28MenuName = "";
         AV26MenuDescription = "";
         ucGridcomponent_grid = new GXUserControl();
         imgGridsettings_labelgrid_gximage = "";
         sImgUrl = "";
         imgGridsettings_labelgrid_Jsonclick = "";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_savegrid_Jsonclick = "";
         bttAdd_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick = "";
         lblPaginationbar_firstpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockgrid_Jsonclick = "";
         lblPaginationbar_previouspagetextblockgrid_Jsonclick = "";
         lblPaginationbar_currentpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagetextblockgrid_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockgrid_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34OptionName = "";
         AV32OptionDescription = "";
         AV35OptionType = "";
         AV41Up_Action = "";
         AV13Down_Action = "";
         AV44Options_Action = "";
         AV46Update_Action = "";
         AV55Update_action_GXI = "";
         AV47Delete_Action = "";
         AV56Delete_action_GXI = "";
         GXt_char1 = "";
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV25Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV15Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31Message = new GeneXus.Utils.SdtMessages_Message(context);
         GridRow = new GXWebRow();
         AV17Filter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter(context);
         AV30MenuOptions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption", "GeneXus.Programs");
         AV21GridStateKey = "";
         AV19GridState = new SdtK2BGridState(context);
         AV20GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV37Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV29MenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV14Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV42Window = new GXWindow();
         AV43ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwmenuoptions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwmenuoptions__default(),
            new Object[][] {
            }
         );
         AV53Pgmname = "K2BFSG.WWMenuOptions";
         /* GeneXus formulas. */
         AV53Pgmname = "K2BFSG.WWMenuOptions";
         edtavApplicationname_Enabled = 0;
         edtavMenuname_Enabled = 0;
         edtavMenudescription_Enabled = 0;
         edtavOptionid_Enabled = 0;
         edtavOptionname_Enabled = 0;
         edtavOptiondescription_Enabled = 0;
         cmbavOptiontype.Enabled = 0;
         edtavUp_action_Enabled = 0;
         edtavDown_action_Enabled = 0;
         edtavOptions_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV12CurrentPage_Grid ;
      private short AV38RowsPerPage_Grid ;
      private short AV24I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18GridSettingsRowsPerPage_Grid ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GRID_nEOF ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int divGridsettings_contentoutertablegrid_Visible ;
      private int nRC_GXsfl_113 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_113_idx=1 ;
      private int edtavApplicationname_Enabled ;
      private int edtavMenuname_Enabled ;
      private int edtavMenudescription_Enabled ;
      private int edtavGenericfilter_grid_Enabled ;
      private int bttAdd_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavOptionid_Enabled ;
      private int edtavOptionname_Enabled ;
      private int edtavOptiondescription_Enabled ;
      private int edtavUp_action_Enabled ;
      private int edtavDown_action_Enabled ;
      private int edtavOptions_action_Enabled ;
      private int AV54GXV1 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV57GXV2 ;
      private int AV58GXV3 ;
      private int AV59GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavOptionid_Visible ;
      private int edtavOptionname_Visible ;
      private int edtavOptiondescription_Visible ;
      private int edtavUp_action_Visible ;
      private int edtavDown_action_Visible ;
      private int edtavOptions_action_Visible ;
      private int edtavUpdate_action_Enabled ;
      private int edtavUpdate_action_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV9ApplicationId ;
      private long AV27MenuId ;
      private long wcpOAV9ApplicationId ;
      private long wcpOAV27MenuId ;
      private long AV33OptionId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_113_idx="0001" ;
      private string AV52GenericFilter_PreviousValue_Grid ;
      private string AV53Pgmname ;
      private string AV48GenericFilter_Grid ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Responsivetable_mainattributes_attributes_Title ;
      private string Gridcomponent_grid_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Responsivetable_mainattributes_attributes_Internalname ;
      private string divResponsivetable_mainattributes_attributes_content_Internalname ;
      private string divAttributescontainertable_responsivetable_mainattributes_attributes_Internalname ;
      private string divTable_container_applicationname_Internalname ;
      private string edtavApplicationname_Internalname ;
      private string TempTags ;
      private string AV10ApplicationName ;
      private string edtavApplicationname_Jsonclick ;
      private string divTable_container_menuname_Internalname ;
      private string edtavMenuname_Internalname ;
      private string AV28MenuName ;
      private string edtavMenuname_Jsonclick ;
      private string divTable_container_menudescription_Internalname ;
      private string edtavMenudescription_Internalname ;
      private string AV26MenuDescription ;
      private string edtavMenudescription_Jsonclick ;
      private string Gridcomponent_grid_Internalname ;
      private string divGridcomponent_grid_content_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filtercontainersection_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlygenericfilterlayout_grid_Internalname ;
      private string divLayoutdefined_table9_grid_Internalname ;
      private string divLayoutdefined_table8_grid_Internalname ;
      private string edtavGenericfilter_grid_Internalname ;
      private string edtavGenericfilter_grid_Jsonclick ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string imgGridsettings_labelgrid_gximage ;
      private string sImgUrl ;
      private string imgGridsettings_labelgrid_Internalname ;
      private string imgGridsettings_labelgrid_Jsonclick ;
      private string divGridsettings_contentoutertablegrid_Internalname ;
      private string divGslayoutdefined_gridcontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_grid_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Internalname ;
      private string cmbavGridsettingsrowsperpage_grid_Jsonclick ;
      private string divFreezecolumntitlescontainer_grid_Internalname ;
      private string chkavFreezecolumntitles_grid_Internalname ;
      private string bttGridsettings_savegrid_Internalname ;
      private string bttGridsettings_savegrid_Jsonclick ;
      private string divActions_grid_topright_Internalname ;
      private string bttAdd_Internalname ;
      private string bttAdd_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divLayoutdefined_section8_grid_Internalname ;
      private string divPaginationbar_pagingcontainertable_grid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockgrid_Class ;
      private string lblPaginationbar_firstpagetextblockgrid_Internalname ;
      private string lblPaginationbar_firstpagetextblockgrid_Caption ;
      private string lblPaginationbar_firstpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockgrid_Internalname ;
      private string lblPaginationbar_spacinglefttextblockgrid_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockgrid_Internalname ;
      private string lblPaginationbar_previouspagetextblockgrid_Caption ;
      private string lblPaginationbar_previouspagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockgrid_Internalname ;
      private string lblPaginationbar_currentpagetextblockgrid_Caption ;
      private string lblPaginationbar_currentpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagetextblockgrid_Caption ;
      private string lblPaginationbar_nextpagetextblockgrid_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockgrid_Internalname ;
      private string lblPaginationbar_spacingrighttextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockgrid_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavOptionid_Internalname ;
      private string AV34OptionName ;
      private string edtavOptionname_Internalname ;
      private string AV32OptionDescription ;
      private string edtavOptiondescription_Internalname ;
      private string cmbavOptiontype_Internalname ;
      private string AV35OptionType ;
      private string AV41Up_Action ;
      private string edtavUp_action_Internalname ;
      private string AV13Down_Action ;
      private string edtavDown_action_Internalname ;
      private string AV44Options_Action ;
      private string edtavOptions_action_Internalname ;
      private string edtavUpdate_action_Internalname ;
      private string edtavDelete_action_Internalname ;
      private string GXt_char1 ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavUpdate_action_gximage ;
      private string edtavUpdate_action_Tooltiptext ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavOptionid_Jsonclick ;
      private string edtavOptionname_Jsonclick ;
      private string edtavOptiondescription_Jsonclick ;
      private string GXCCtl ;
      private string cmbavOptiontype_Jsonclick ;
      private string edtavUp_action_Jsonclick ;
      private string edtavDown_action_Jsonclick ;
      private string edtavOptions_action_Jsonclick ;
      private string edtavUpdate_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22HasNextPage_Grid ;
      private bool AV51FreezeColumnTitles_Grid ;
      private bool Responsivetable_mainattributes_attributes_Collapsible ;
      private bool Responsivetable_mainattributes_attributes_Open ;
      private bool Responsivetable_mainattributes_attributes_Showborders ;
      private bool Responsivetable_mainattributes_attributes_Containseditableform ;
      private bool Gridcomponent_grid_Collapsible ;
      private bool Gridcomponent_grid_Open ;
      private bool Gridcomponent_grid_Showborders ;
      private bool Gridcomponent_grid_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV45RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV36Reload_Grid ;
      private bool AV16Exit_Grid ;
      private bool AV46Update_Action_IsBlob ;
      private bool AV47Delete_Action_IsBlob ;
      private string AV55Update_action_GXI ;
      private string AV56Delete_action_GXI ;
      private string AV21GridStateKey ;
      private string AV46Update_Action ;
      private string AV47Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucResponsivetable_mainattributes_attributes ;
      private GXUserControl ucGridcomponent_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_ApplicationId ;
      private long aP1_MenuId ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private GXCombobox cmbavOptiontype ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV50ClassCollection_Grid ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption> AV30MenuOptions ;
      private GXWebForm Form ;
      private GXWindow AV42Window ;
      private GeneXus.Utils.SdtMessages_Message AV31Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV14Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV25Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV29MenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV43ApplicationMenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOptionFilter AV17Filter ;
      private SdtK2BGridState AV19GridState ;
      private SdtK2BGridState_FilterValue AV20GridStateFilterValue ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV37Repository ;
      private SdtK2BGridConfiguration AV49GridConfiguration ;
   }

   public class wwmenuoptions__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwmenuoptions__default : DataStoreHelperBase, IDataStoreHelper
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
