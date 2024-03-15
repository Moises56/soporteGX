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
   public class changerepository : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public changerepository( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public changerepository( IGxContext context )
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
         nRC_GXsfl_28 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_28"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_28_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_28_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_28_idx = GetPar( "sGXsfl_28_idx");
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
         AV9CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV28Pgmname = GetPar( "Pgmname");
         AV17I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV9CurrentPage_Grid, AV28Pgmname, AV17I_LoadCount_Grid) ;
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
            return "changerepository_Execute" ;
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
         PA3F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3F2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.changerepository.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_28", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_28), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
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
            WE3F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3F2( ) ;
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
         return formatLink("k2bfsg.changerepository.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.ChangeRepository" ;
      }

      public override string GetPgmdesc( )
      {
         return "Change Repository" ;
      }

      protected void WB3F0( )
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
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Change repository", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ChangeRepository.htm");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl28( ) ;
         }
         if ( wbEnd == 28 )
         {
            wbEnd = 0;
            nRC_GXsfl_28 = (int)(nGXsfl_28_idx-1);
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
            wb_table1_35_3F2( true) ;
         }
         else
         {
            wb_table1_35_3F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_35_3F2e( bool wbgen )
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
         if ( wbEnd == 28 )
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

      protected void START3F2( )
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
         Form.Meta.addItem("description", "Change Repository", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3F0( ) ;
      }

      protected void WS3F2( )
      {
         START3F2( ) ;
         EVT3F2( ) ;
      }

      protected void EVT3F2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_SETACTIVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'E_SETACTIVE'") == 0 ) )
                           {
                              nGXsfl_28_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
                              SubsflControlProps_282( ) ;
                              AV8ConnectionName = cgiGet( edtavConnectionname_Internalname);
                              AssignAttri("", false, edtavConnectionname_Internalname, AV8ConnectionName);
                              GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONNAME"+"_"+sGXsfl_28_idx, GetSecureSignedToken( sGXsfl_28_idx, StringUtil.RTrim( context.localUtil.Format( AV8ConnectionName, "")), context));
                              AV22RepositoryName = cgiGet( edtavRepositoryname_Internalname);
                              AssignAttri("", false, edtavRepositoryname_Internalname, AV22RepositoryName);
                              AV24Status = cgiGet( edtavStatus_Internalname);
                              AssignAttri("", false, edtavStatus_Internalname, AV24Status);
                              AV23SetActive_Action = cgiGet( edtavSetactive_action_Internalname);
                              AssignAttri("", false, edtavSetactive_action_Internalname, AV23SetActive_Action);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E123F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E133F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E143F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_SETACTIVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_SetActive' */
                                    E153F2 ();
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

      protected void WE3F2( )
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

      protected void PA3F2( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_282( ) ;
         while ( nGXsfl_28_idx <= nRC_GXsfl_28 )
         {
            sendrow_282( ) ;
            nGXsfl_28_idx = ((subGrid_Islastpage==1)&&(nGXsfl_28_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_28_idx+1);
            sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
            SubsflControlProps_282( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( short AV9CurrentPage_Grid ,
                                       string AV28Pgmname ,
                                       short AV17I_LoadCount_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8ConnectionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vCONNECTIONNAME", StringUtil.RTrim( AV8ConnectionName));
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
         E123F2 ();
         RF3F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV28Pgmname = "K2BFSG.ChangeRepository";
         edtavConnectionname_Enabled = 0;
         AssignProp("", false, edtavConnectionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavRepositoryname_Enabled = 0;
         AssignProp("", false, edtavRepositoryname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavStatus_Enabled = 0;
         AssignProp("", false, edtavStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStatus_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavSetactive_action_Enabled = 0;
         AssignProp("", false, edtavSetactive_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSetactive_action_Enabled), 5, 0), !bGXsfl_28_Refreshing);
      }

      protected void RF3F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 28;
         /* Execute user event: Refresh */
         E123F2 ();
         E133F2 ();
         nGXsfl_28_idx = 1;
         sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
         SubsflControlProps_282( ) ;
         bGXsfl_28_Refreshing = true;
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
            SubsflControlProps_282( ) ;
            E143F2 ();
            wbEnd = 28;
            WB3F0( ) ;
         }
         bGXsfl_28_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3F2( )
      {
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONNAME"+"_"+sGXsfl_28_idx, GetSecureSignedToken( sGXsfl_28_idx, StringUtil.RTrim( context.localUtil.Format( AV8ConnectionName, "")), context));
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
         AV28Pgmname = "K2BFSG.ChangeRepository";
         edtavConnectionname_Enabled = 0;
         AssignProp("", false, edtavConnectionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavRepositoryname_Enabled = 0;
         AssignProp("", false, edtavRepositoryname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavStatus_Enabled = 0;
         AssignProp("", false, edtavStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStatus_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         edtavSetactive_action_Enabled = 0;
         AssignProp("", false, edtavSetactive_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSetactive_action_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_28 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_28"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
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
         E113F2 ();
         if (returnInSub) return;
      }

      protected void E113F2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
      }

      protected void E123F2( )
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
         if ( (0==AV9CurrentPage_Grid) )
         {
            AV9CurrentPage_Grid = 1;
            AssignAttri("", false, "AV9CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV9CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CurrentPage_Grid), "ZZZ9"), context));
         }
         AV20Reload_Grid = true;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void E133F2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S152 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E143F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV17I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
         AV12Exit_Grid = false;
         while ( true )
         {
            AV17I_LoadCount_Grid = (short)(AV17I_LoadCount_Grid+1);
            AssignAttri("", false, "AV17I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV17I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S172 ();
            if (returnInSub) return;
            AV23SetActive_Action = "Set active";
            AssignAttri("", false, edtavSetactive_action_Internalname, AV23SetActive_Action);
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S182 ();
            if (returnInSub) return;
            if ( AV12Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 28;
            }
            sendrow_282( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_28_Refreshing )
            {
               context.DoAjaxLoad(28, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21Repository", AV21Repository);
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV17I_LoadCount_Grid == 1 )
         {
            AV7ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
            AV21Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         }
         if ( AV7ConnectionInfoCollection.Count >= AV17I_LoadCount_Grid )
         {
            AV8ConnectionName = ((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV7ConnectionInfoCollection.Item(AV17I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri("", false, edtavConnectionname_Internalname, AV8ConnectionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vCONNECTIONNAME"+"_"+sGXsfl_28_idx, GetSecureSignedToken( sGXsfl_28_idx, StringUtil.RTrim( context.localUtil.Format( AV8ConnectionName, "")), context));
            AV22RepositoryName = ((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV7ConnectionInfoCollection.Item(AV17I_LoadCount_Grid)).gxTpr_Repositoryname;
            AssignAttri("", false, edtavRepositoryname_Internalname, AV22RepositoryName);
            if ( StringUtil.StrCmp(AV21Repository.gxTpr_Guid, ((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV7ConnectionInfoCollection.Item(AV17I_LoadCount_Grid)).gxTpr_Repositoryguid) == 0 )
            {
               AV24Status = "Active";
               AssignAttri("", false, edtavStatus_Internalname, AV24Status);
               edtavSetactive_action_Visible = 0;
               AssignProp("", false, edtavSetactive_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSetactive_action_Visible), 5, 0), !bGXsfl_28_Refreshing);
            }
            else
            {
               AV24Status = "";
               AssignAttri("", false, edtavStatus_Internalname, AV24Status);
               edtavSetactive_action_Visible = 1;
               AssignProp("", false, edtavSetactive_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSetactive_action_Visible), 5, 0), !bGXsfl_28_Refreshing);
            }
         }
         else
         {
            AV12Exit_Grid = true;
         }
      }

      protected void S182( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV15GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV28Pgmname,  AV15GridStateKey, out  AV13GridState) ;
         AV13GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV28Pgmname,  AV15GridStateKey,  AV13GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV15GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV28Pgmname,  AV15GridStateKey, out  AV13GridState) ;
      }

      protected void E153F2( )
      {
         /* 'E_SetActive' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_SETACTIVE' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_SETACTIVE' Routine */
         returnInSub = false;
         AV19OK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(AV8ConnectionName, out  AV11Errors);
         if ( AV11Errors.Count > 0 )
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S202 ();
            if (returnInSub) return;
         }
         else
         {
            if ( AV19OK )
            {
               GX_msglist.addItem("Connection Changed");
               context.DoAjaxRefresh();
            }
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV11Errors.Count )
         {
            AV10Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(AV29GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV10Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV10Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV29GXV1 = (int)(AV29GXV1+1);
         }
      }

      protected void wb_table1_35_3F2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\ChangeRepository.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_35_3F2e( true) ;
         }
         else
         {
            wb_table1_35_3F2e( false) ;
         }
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
         PA3F2( ) ;
         WS3F2( ) ;
         WE3F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138175019", true, true);
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
         context.AddJavascriptSource("k2bfsg/changerepository.js", "?20243138175023", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_282( )
      {
         edtavConnectionname_Internalname = "vCONNECTIONNAME_"+sGXsfl_28_idx;
         edtavRepositoryname_Internalname = "vREPOSITORYNAME_"+sGXsfl_28_idx;
         edtavStatus_Internalname = "vSTATUS_"+sGXsfl_28_idx;
         edtavSetactive_action_Internalname = "vSETACTIVE_ACTION_"+sGXsfl_28_idx;
      }

      protected void SubsflControlProps_fel_282( )
      {
         edtavConnectionname_Internalname = "vCONNECTIONNAME_"+sGXsfl_28_fel_idx;
         edtavRepositoryname_Internalname = "vREPOSITORYNAME_"+sGXsfl_28_fel_idx;
         edtavStatus_Internalname = "vSTATUS_"+sGXsfl_28_fel_idx;
         edtavSetactive_action_Internalname = "vSETACTIVE_ACTION_"+sGXsfl_28_fel_idx;
      }

      protected void sendrow_282( )
      {
         SubsflControlProps_282( ) ;
         WB3F0( ) ;
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
            if ( ((int)((nGXsfl_28_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_28_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavConnectionname_Enabled!=0)&&(edtavConnectionname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'',false,'"+sGXsfl_28_idx+"',28)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConnectionname_Internalname,StringUtil.RTrim( AV8ConnectionName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavConnectionname_Enabled!=0)&&(edtavConnectionname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,29);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavConnectionname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtavConnectionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)28,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMConnectionName",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavRepositoryname_Enabled!=0)&&(edtavRepositoryname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 30,'',false,'"+sGXsfl_28_idx+"',28)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRepositoryname_Internalname,StringUtil.RTrim( AV22RepositoryName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavRepositoryname_Enabled!=0)&&(edtavRepositoryname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,30);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRepositoryname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavRepositoryname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)28,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavStatus_Enabled!=0)&&(edtavStatus_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 31,'',false,'"+sGXsfl_28_idx+"',28)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavStatus_Internalname,StringUtil.RTrim( AV24Status),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavStatus_Enabled!=0)&&(edtavStatus_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,31);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavStatus_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavStatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)28,(short)0,(short)-1,(short)-1,(bool)true,(string)"K2BDescription",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSetactive_action_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSetactive_action_Enabled!=0)&&(edtavSetactive_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'',false,'"+sGXsfl_28_idx+"',28)\"" : " ");
         ROClassString = "K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSetactive_action_Internalname,StringUtil.RTrim( AV23SetActive_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSetactive_action_Enabled!=0)&&(edtavSetactive_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,32);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'E_SETACTIVE\\'."+sGXsfl_28_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSetactive_action_Jsonclick,(short)5,(string)"K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(int)edtavSetactive_action_Visible,(int)edtavSetactive_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)28,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes3F2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_28_idx = ((subGrid_Islastpage==1)&&(nGXsfl_28_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_28_idx+1);
         sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
         SubsflControlProps_282( ) ;
         /* End function sendrow_282 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl28( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"28\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Repository") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"K2BT_TextAction"+"\" "+" style=\""+((edtavSetactive_action_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV8ConnectionName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConnectionname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV22RepositoryName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRepositoryname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24Status)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavStatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV23SetActive_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSetactive_action_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSetactive_action_Visible), 5, 0, ".", "")));
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
         edtavConnectionname_Internalname = "vCONNECTIONNAME";
         edtavRepositoryname_Internalname = "vREPOSITORYNAME";
         edtavStatus_Internalname = "vSTATUS";
         edtavSetactive_action_Internalname = "vSETACTIVE_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = "I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = "MAINGRID_RESPONSIVETABLE_GRID";
         divLayoutdefined_table3_grid_Internalname = "LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = "LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = "GRIDCOMPONENTCONTENT_GRID";
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
         edtavSetactive_action_Jsonclick = "";
         edtavSetactive_action_Enabled = 1;
         edtavStatus_Jsonclick = "";
         edtavStatus_Visible = -1;
         edtavStatus_Enabled = 1;
         edtavRepositoryname_Jsonclick = "";
         edtavRepositoryname_Visible = -1;
         edtavRepositoryname_Enabled = 1;
         edtavConnectionname_Jsonclick = "";
         edtavConnectionname_Visible = 0;
         edtavConnectionname_Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSetactive_action_Visible = -1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Change Repository";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV9CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV9CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E133F2',iparms:[{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E143F2',iparms:[{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV23SetActive_Action',fld:'vSETACTIVE_ACTION',pic:''},{av:'AV8ConnectionName',fld:'vCONNECTIONNAME',pic:'',hsh:true},{av:'AV22RepositoryName',fld:'vREPOSITORYNAME',pic:''},{av:'AV24Status',fld:'vSTATUS',pic:''},{av:'edtavSetactive_action_Visible',ctrl:'vSETACTIVE_ACTION',prop:'Visible'}]}");
         setEventMetadata("'E_SETACTIVE'","{handler:'E153F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV9CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV8ConnectionName',fld:'vCONNECTIONNAME',pic:'',hsh:true}]");
         setEventMetadata("'E_SETACTIVE'",",oparms:[{av:'AV9CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("NULL","{handler:'Validv_Setactive_action',iparms:[]");
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
         AV28Pgmname = "";
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8ConnectionName = "";
         AV22RepositoryName = "";
         AV24Status = "";
         AV23SetActive_Action = "";
         GridRow = new GXWebRow();
         AV21Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV7ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV15GridStateKey = "";
         AV13GridState = new SdtK2BGridState(context);
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         AV28Pgmname = "K2BFSG.ChangeRepository";
         /* GeneXus formulas. */
         AV28Pgmname = "K2BFSG.ChangeRepository";
         edtavConnectionname_Enabled = 0;
         edtavRepositoryname_Enabled = 0;
         edtavStatus_Enabled = 0;
         edtavSetactive_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV9CurrentPage_Grid ;
      private short AV17I_LoadCount_Grid ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int nRC_GXsfl_28 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_28_idx=1 ;
      private int subGrid_Islastpage ;
      private int edtavConnectionname_Enabled ;
      private int edtavRepositoryname_Enabled ;
      private int edtavStatus_Enabled ;
      private int edtavSetactive_action_Enabled ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int edtavSetactive_action_Visible ;
      private int AV29GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavConnectionname_Visible ;
      private int edtavRepositoryname_Visible ;
      private int edtavStatus_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_28_idx="0001" ;
      private string AV28Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV8ConnectionName ;
      private string edtavConnectionname_Internalname ;
      private string AV22RepositoryName ;
      private string edtavRepositoryname_Internalname ;
      private string AV24Status ;
      private string edtavStatus_Internalname ;
      private string AV23SetActive_Action ;
      private string edtavSetactive_action_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sGXsfl_28_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string TempTags ;
      private string ROClassString ;
      private string edtavConnectionname_Jsonclick ;
      private string edtavRepositoryname_Jsonclick ;
      private string edtavStatus_Jsonclick ;
      private string edtavSetactive_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_28_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV20Reload_Grid ;
      private bool AV12Exit_Grid ;
      private bool AV19OK ;
      private string AV15GridStateKey ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV7ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10Error ;
      private SdtK2BGridState AV13GridState ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV21Repository ;
   }

}
