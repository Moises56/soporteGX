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
   public class roleusers : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public roleusers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
      }

      public roleusers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_Id )
      {
         this.AV38Id = aP0_Id;
         executePrivate();
         aP0_Id=this.AV38Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavGridsettingsrowsperpage_grid = new GXCombobox();
         chkavFreezecolumntitles_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Id");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV38Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV38Id", StringUtil.LTrimStr( (decimal)(AV38Id), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV38Id});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "Id");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Id");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_72 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_72"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_72_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_72_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_72_idx = GetPar( "sGXsfl_72_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV41Pgmname = GetPar( "Pgmname");
         AV16CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV20HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV15GridConfiguration);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ClassCollection_Grid);
         AV22RowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "RowsPerPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV19I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV38Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
         AV25FreezeColumnTitles_Grid = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_Grid"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV41Pgmname, AV16CurrentPage_Grid, AV20HasNextPage_Grid, AV15GridConfiguration, AV18ClassCollection_Grid, AV22RowsPerPage_Grid, AV19I_LoadCount_Grid, AV38Id, AV25FreezeColumnTitles_Grid, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV41Pgmname = "K2BFSG.RoleUsers";
               edtavAuthenticationtypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtavUsername_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtavFirstname_Enabled = 0;
               AssignProp(sPrefix, false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtavLastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtavEmail_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               edtavUserid_Enabled = 0;
               AssignProp(sPrefix, false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), !bGXsfl_72_Refreshing);
               WS3Z2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Role Users", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleusers.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV38Id,12,0))}, new string[] {"Id"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV20HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV20HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_72", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_72), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV38Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV38Id), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV18ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV18ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV15GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV15GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV20HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV20HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22RowsPerPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Id), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Title", StringUtil.RTrim( Gridcomponent_grid_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Collapsible", StringUtil.BoolToStr( Gridcomponent_grid_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Open", StringUtil.BoolToStr( Gridcomponent_grid_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Showborders", StringUtil.BoolToStr( Gridcomponent_grid_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Containseditableform", StringUtil.BoolToStr( Gridcomponent_grid_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3Z2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RoleUsers" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Role Users", "") ;
      }

      protected void WB3Z0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.roleusers.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            ucGridcomponent_grid.SetProperty("Title", Gridcomponent_grid_Title);
            ucGridcomponent_grid.SetProperty("Collapsible", Gridcomponent_grid_Collapsible);
            ucGridcomponent_grid.SetProperty("Open", Gridcomponent_grid_Open);
            ucGridcomponent_grid.SetProperty("ShowBorders", Gridcomponent_grid_Showborders);
            ucGridcomponent_grid.SetProperty("ContainsEditableForm", Gridcomponent_grid_Containseditableform);
            ucGridcomponent_grid.Render(context, "k2bt_component", Gridcomponent_grid_Internalname, sPrefix+"GRIDCOMPONENT_GRIDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GRIDCOMPONENT_GRIDContainer"+"Gridcomponent_grid_Content"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle" + " " + ((StringUtil.StrCmp(imgGridsettings_labelgrid_gximage, "")==0) ? "GX_Image_K2BT_GridSettings_Class" : "GX_Image_"+imgGridsettings_labelgrid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelgrid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", context.GetMessage( "K2BT_GridSettingsLabel", ""), 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113z1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleUsers.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname, context.GetMessage( "K2BT_GridSettingsLabel", ""), "", "", lblGslayoutdefined_gridruntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
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
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_grid_Internalname, context.GetMessage( "K2BT_RowsPerPage", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_72_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_grid, cmbavGridsettingsrowsperpage_grid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0)), 1, cmbavGridsettingsrowsperpage_grid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_grid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_K2BFSG\\RoleUsers.htm");
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_grid.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_grid_Internalname, context.GetMessage( "K2BT_FreezeColumnTitles", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_72_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_grid_Internalname, StringUtil.BoolToStr( AV25FreezeColumnTitles_Grid), "", context.GetMessage( "K2BT_FreezeColumnTitles", ""), 1, chkavFreezecolumntitles_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_GridSettingsSaveAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_savegrid_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(72), 2, 0)+","+"null"+");", context.GetMessage( "K2BT_GridSettingsApply", ""), bttGridsettings_savegrid_Jsonclick, 5, context.GetMessage( "K2BT_GridSettingsApply", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS(GRID)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleUsers.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(72), 2, 0)+","+"null"+");", context.GetMessage( "K2BT_InsertAction", ""), bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleUsers.htm");
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
            StartGridControl72( ) ;
         }
         if ( wbEnd == 72 )
         {
            wbEnd = 0;
            nRC_GXsfl_72 = (int)(nGXsfl_72_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_82_3Z2( true) ;
         }
         else
         {
            wb_table1_82_3Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_82_3Z2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e123z1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e133z1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e123z1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e143z1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e143z1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 72 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Z2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_5-175581", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Role Users", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3Z0( ) ;
            }
         }
      }

      protected void WS3Z2( )
      {
         START3Z2( ) ;
         EVT3Z2( ) ;
      }

      protected void EVT3Z2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(GRID)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings(Grid)' */
                                    E153Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E163Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_DELETEUSER'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'E_DELETEUSER'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              nGXsfl_72_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
                              SubsflControlProps_722( ) ;
                              AV26AuthenticationTypeName = cgiGet( edtavAuthenticationtypename_Internalname);
                              AssignAttri(sPrefix, false, edtavAuthenticationtypename_Internalname, AV26AuthenticationTypeName);
                              AV27UserName = cgiGet( edtavUsername_Internalname);
                              AssignAttri(sPrefix, false, edtavUsername_Internalname, AV27UserName);
                              AV28FirstName = cgiGet( edtavFirstname_Internalname);
                              AssignAttri(sPrefix, false, edtavFirstname_Internalname, AV28FirstName);
                              AV29LastName = cgiGet( edtavLastname_Internalname);
                              AssignAttri(sPrefix, false, edtavLastname_Internalname, AV29LastName);
                              AV30Email = cgiGet( edtavEmail_Internalname);
                              AssignAttri(sPrefix, false, edtavEmail_Internalname, AV30Email);
                              AV31UserId = cgiGet( edtavUserid_Internalname);
                              AssignAttri(sPrefix, false, edtavUserid_Internalname, AV31UserId);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sPrefix+sGXsfl_72_idx, StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
                              AV32DeleteUser_Action = cgiGet( edtavDeleteuser_action_Internalname);
                              AssignProp(sPrefix, false, edtavDeleteuser_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32DeleteUser_Action)) ? AV43Deleteuser_action_GXI : context.convertURL( context.PathToRelativeUrl( AV32DeleteUser_Action))), !bGXsfl_72_Refreshing);
                              AssignProp(sPrefix, false, edtavDeleteuser_action_Internalname, "SrcSet", context.GetImageSrcSet( AV32DeleteUser_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E173Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E183Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E193Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E203Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETEUSER'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_DeleteUser' */
                                          E213Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3Z0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAuthenticationtypename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE3Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Z2( ) ;
            }
         }
      }

      protected void PA3Z2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavGridsettingsrowsperpage_grid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_722( ) ;
         while ( nGXsfl_72_idx <= nRC_GXsfl_72 )
         {
            sendrow_722( ) ;
            nGXsfl_72_idx = ((subGrid_Islastpage==1)&&(nGXsfl_72_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_72_idx+1);
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
            SubsflControlProps_722( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( string AV41Pgmname ,
                                       short AV16CurrentPage_Grid ,
                                       bool AV20HasNextPage_Grid ,
                                       SdtK2BGridConfiguration AV15GridConfiguration ,
                                       GxSimpleCollection<string> AV18ClassCollection_Grid ,
                                       short AV22RowsPerPage_Grid ,
                                       short AV19I_LoadCount_Grid ,
                                       long AV38Id ,
                                       bool AV25FreezeColumnTitles_Grid ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERID", StringUtil.RTrim( AV31UserId));
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
            AV24GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cmbavGridsettingsrowsperpage_grid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_grid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_grid_Internalname, "Values", cmbavGridsettingsrowsperpage_grid.ToJavascriptSource(), true);
         }
         AV25FreezeColumnTitles_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV25FreezeColumnTitles_Grid));
         AssignAttri(sPrefix, false, "AV25FreezeColumnTitles_Grid", AV25FreezeColumnTitles_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E183Z2 ();
         RF3Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV41Pgmname = "K2BFSG.RoleUsers";
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavUsername_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp(sPrefix, false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp(sPrefix, false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavUserid_Enabled = 0;
         AssignProp(sPrefix, false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), !bGXsfl_72_Refreshing);
      }

      protected void RF3Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 72;
         /* Execute user event: Refresh */
         E183Z2 ();
         E193Z2 ();
         nGXsfl_72_idx = 1;
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_722( ) ;
         bGXsfl_72_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_722( ) ;
            E203Z2 ();
            wbEnd = 72;
            WB3Z0( ) ;
         }
         bGXsfl_72_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Z2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV20HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV20HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sPrefix+sGXsfl_72_idx, StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
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
         AV41Pgmname = "K2BFSG.RoleUsers";
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp(sPrefix, false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavUsername_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp(sPrefix, false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp(sPrefix, false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtavUserid_Enabled = 0;
         AssignProp(sPrefix, false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E173Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_72 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_72"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV38Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38Id"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV22RowsPerPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vROWSPERPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV20HasNextPage_Grid = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridcomponent_grid_Title = cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Title");
            Gridcomponent_grid_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Collapsible"));
            Gridcomponent_grid_Open = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Open"));
            Gridcomponent_grid_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Showborders"));
            Gridcomponent_grid_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Containseditableform"));
            /* Read variables values. */
            cmbavGridsettingsrowsperpage_grid.Name = cmbavGridsettingsrowsperpage_grid_Internalname;
            cmbavGridsettingsrowsperpage_grid.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname);
            AV24GridSettingsRowsPerPage_Grid = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_grid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0));
            AV25FreezeColumnTitles_Grid = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_grid_Internalname));
            AssignAttri(sPrefix, false, "AV25FreezeColumnTitles_Grid", AV25FreezeColumnTitles_Grid);
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
         E173Z2 ();
         if (returnInSub) return;
      }

      protected void E173Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bloadrowsperpage(context ).execute(  AV41Pgmname,  "Grid", out  AV22RowsPerPage_Grid, out  AV23RowsPerPageLoaded_Grid) ;
         AssignAttri(sPrefix, false, "AV22RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22RowsPerPage_Grid), 4, 0));
         if ( ! AV23RowsPerPageLoaded_Grid )
         {
            AV22RowsPerPage_Grid = 20;
            AssignAttri(sPrefix, false, "AV22RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22RowsPerPage_Grid), 4, 0));
         }
         AV24GridSettingsRowsPerPage_Grid = AV22RowsPerPage_Grid;
         AssignAttri(sPrefix, false, "AV24GridSettingsRowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV24GridSettingsRowsPerPage_Grid), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
      }

      protected void E183Z2( )
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
         if ( (0==AV16CurrentPage_Grid) )
         {
            AV16CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         AV17Reload_Grid = true;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(GRID)' */
         S152 ();
         if (returnInSub) return;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV18ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV18ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ClassCollection_Grid", AV18ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15GridConfiguration", AV15GridConfiguration);
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

      protected void S162( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message2 = AV40Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message2) ;
         AV40Messages = GXt_objcol_SdtMessages_Message2;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV40Messages.Count )
         {
            AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV40Messages.Item(AV42GXV1));
            GX_msglist.addItem(AV6Message.gxTpr_Description);
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S152( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(GRID)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV41Pgmname,  "Grid", ref  AV15GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(GRID)' */
         S242 ();
         if (returnInSub) return;
      }

      protected void S242( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(GRID)' Routine */
         returnInSub = false;
         AV25FreezeColumnTitles_Grid = AV15GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV25FreezeColumnTitles_Grid", AV25FreezeColumnTitles_Grid);
         if ( AV25FreezeColumnTitles_Grid )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV18ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV18ClassCollection_Grid) ;
         }
      }

      protected void E193Z2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ClassCollection_Grid", AV18ClassCollection_Grid);
      }

      protected void S182( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E203Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV19I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV19I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
         AV20HasNextPage_Grid = false;
         AssignAttri(sPrefix, false, "AV20HasNextPage_Grid", AV20HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV20HasNextPage_Grid, context));
         AV21Exit_Grid = false;
         while ( true )
         {
            AV19I_LoadCount_Grid = (short)(AV19I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV19I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S202 ();
            if (returnInSub) return;
            edtavDeleteuser_action_gximage = "K2BActionDelete";
            AV32DeleteUser_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDeleteuser_action_Internalname, AV32DeleteUser_Action);
            AV43Deleteuser_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDeleteuser_action_Tooltiptext = context.GetMessage( "K2BT_DeleteAction", "");
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S212 ();
            if (returnInSub) return;
            if ( AV21Exit_Grid )
            {
               if (true) break;
            }
            if ( AV19I_LoadCount_Grid > AV22RowsPerPage_Grid * AV16CurrentPage_Grid )
            {
               AV20HasNextPage_Grid = true;
               AssignAttri(sPrefix, false, "AV20HasNextPage_Grid", AV20HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV20HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV19I_LoadCount_Grid > AV22RowsPerPage_Grid * ( AV16CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 72;
               }
               sendrow_722( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_72_Refreshing )
               {
                  context.DoAjaxLoad(72, GridRow);
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
      }

      protected void S202( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV19I_LoadCount_Grid == 1 )
         {
            AV37Role.load( AV38Id);
            AV39GAMUsers = AV37Role.getusers(out  AV35Errors);
         }
         if ( AV39GAMUsers.Count >= AV19I_LoadCount_Grid )
         {
            AV26AuthenticationTypeName = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Authenticationtypename;
            AssignAttri(sPrefix, false, edtavAuthenticationtypename_Internalname, AV26AuthenticationTypeName);
            AV27UserName = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Name;
            AssignAttri(sPrefix, false, edtavUsername_Internalname, AV27UserName);
            AV28FirstName = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Firstname;
            AssignAttri(sPrefix, false, edtavFirstname_Internalname, AV28FirstName);
            AV29LastName = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Lastname;
            AssignAttri(sPrefix, false, edtavLastname_Internalname, AV29LastName);
            AV30Email = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Email;
            AssignAttri(sPrefix, false, edtavEmail_Internalname, AV30Email);
            AV31UserId = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV39GAMUsers.Item(AV19I_LoadCount_Grid)).gxTpr_Guid;
            AssignAttri(sPrefix, false, edtavUserid_Internalname, AV31UserId);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sPrefix+sGXsfl_72_idx, StringUtil.RTrim( context.localUtil.Format( AV31UserId, "")), context));
            edtavUsername_Link = formatLink("k2bfsg.entryuser.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(AV31UserId))}, new string[] {"Mode","UserId"}) ;
            AssignProp(sPrefix, false, edtavUsername_Internalname, "Link", edtavUsername_Link, !bGXsfl_72_Refreshing);
         }
         else
         {
            AV21Exit_Grid = true;
         }
      }

      protected void S212( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S192( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV16CurrentPage_Grid+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV16CurrentPage_Grid) || ( AV16CurrentPage_Grid <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
            lblPaginationbar_firstpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockgrid_Visible), 5, 0), true);
            if ( AV16CurrentPage_Grid == 2 )
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockgrid_Visible = 1;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockgrid_Visible), 5, 0), true);
               if ( AV16CurrentPage_Grid == 3 )
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 0;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockgrid_Visible = 1;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockgrid_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV20HasNextPage_Grid )
         {
            lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockgrid_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockgrid_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockgrid_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockgrid_Visible), 5, 0), true);
         }
         if ( ( AV16CurrentPage_Grid <= 1 ) && ! AV20HasNextPage_Grid )
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 0;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_grid_Visible = 1;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_grid_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV41Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         AV11GridState.gxTpr_Currentpage = AV16CurrentPage_Grid;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new k2bsavegridstate(context ).execute(  AV41Pgmname,  AV10GridStateKey,  AV11GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV10GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV41Pgmname,  AV10GridStateKey, out  AV11GridState) ;
         if ( AV11GridState.gxTpr_Currentpage > 0 )
         {
            AV16CurrentPage_Grid = AV11GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
      }

      protected void E153Z2( )
      {
         /* 'SaveGridSettings(Grid)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV41Pgmname,  "Grid", ref  AV15GridConfiguration) ;
         AV15GridConfiguration.gxTpr_Freezecolumntitles = AV25FreezeColumnTitles_Grid;
         new k2bsavegridconfiguration(context ).execute(  AV41Pgmname,  "Grid",  AV15GridConfiguration,  true) ;
         if ( AV22RowsPerPage_Grid != AV24GridSettingsRowsPerPage_Grid )
         {
            AV22RowsPerPage_Grid = AV24GridSettingsRowsPerPage_Grid;
            AssignAttri(sPrefix, false, "AV22RowsPerPage_Grid", StringUtil.LTrimStr( (decimal)(AV22RowsPerPage_Grid), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV41Pgmname,  "Grid",  AV22RowsPerPage_Grid) ;
            AV16CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
         }
         gxgrGrid_refresh( AV41Pgmname, AV16CurrentPage_Grid, AV20HasNextPage_Grid, AV15GridConfiguration, AV18ClassCollection_Grid, AV22RowsPerPage_Grid, AV19I_LoadCount_Grid, AV38Id, AV25FreezeColumnTitles_Grid, sPrefix) ;
         divGridsettings_contentoutertablegrid_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertablegrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertablegrid_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15GridConfiguration", AV15GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ClassCollection_Grid", AV18ClassCollection_Grid);
      }

      protected void E213Z2( )
      {
         /* 'E_DeleteUser' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETEUSER' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ClassCollection_Grid", AV18ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15GridConfiguration", AV15GridConfiguration);
      }

      protected void S222( )
      {
         /* 'U_DELETEUSER' Routine */
         returnInSub = false;
         AV34isOK = false;
         AV33GAMUser.load( AV31UserId);
         AV34isOK = AV33GAMUser.deleterolebyid(AV38Id, out  AV35Errors);
         if ( AV34isOK )
         {
            context.CommitDataStores("k2bfsg.roleusers",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S252 ();
            if (returnInSub) return;
         }
         if ( AV34isOK )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "K2BT_GAM_Userwasdeleted", ""), AV33GAMUser.gxTpr_Name, "", "", "", "", "", "", "", ""));
            gxgrGrid_refresh( AV41Pgmname, AV16CurrentPage_Grid, AV20HasNextPage_Grid, AV15GridConfiguration, AV18ClassCollection_Grid, AV22RowsPerPage_Grid, AV19I_LoadCount_Grid, AV38Id, AV25FreezeColumnTitles_Grid, sPrefix) ;
         }
      }

      protected void S252( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         if ( AV35Errors.Count > 0 )
         {
            AV44GXV2 = 1;
            while ( AV44GXV2 <= AV35Errors.Count )
            {
               AV36Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV35Errors.Item(AV44GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV36Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV36Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV44GXV2 = (int)(AV44GXV2+1);
            }
         }
      }

      protected void S142( )
      {
         /* 'REFRESHGRIDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S262 ();
         if (returnInSub) return;
      }

      protected void S262( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
      }

      protected void E163Z2( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S232 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ClassCollection_Grid", AV18ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15GridConfiguration", AV15GridConfiguration);
      }

      protected void S232( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         AV5Window.Autoresize = 1;
         AV5Window.Url = formatLink("k2bfsg.roleadduser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV38Id,12,0))}, new string[] {"RoleId"}) ;
         AV5Window.SetReturnParms(new Object[] {});
         context.NewWindow(AV5Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void wb_table1_82_3Z2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleUsers.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_82_3Z2e( true) ;
         }
         else
         {
            wb_table1_82_3Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV38Id = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV38Id", StringUtil.LTrimStr( (decimal)(AV38Id), 12, 0));
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
         PA3Z2( ) ;
         WS3Z2( ) ;
         WE3Z2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV38Id = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\roleusers", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Z2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV38Id = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV38Id", StringUtil.LTrimStr( (decimal)(AV38Id), 12, 0));
         }
         wcpOAV38Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV38Id"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV38Id != wcpOAV38Id ) ) )
         {
            setjustcreated();
         }
         wcpOAV38Id = AV38Id;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV38Id = cgiGet( sPrefix+"AV38Id_CTRL");
         if ( StringUtil.Len( sCtrlAV38Id) > 0 )
         {
            AV38Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV38Id), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV38Id", StringUtil.LTrimStr( (decimal)(AV38Id), 12, 0));
         }
         else
         {
            AV38Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV38Id_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV38Id_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Id), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV38Id)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV38Id_CTRL", StringUtil.RTrim( sCtrlAV38Id));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221324381", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("k2bfsg/roleusers.js", "?202431221324383", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_722( )
      {
         edtavAuthenticationtypename_Internalname = sPrefix+"vAUTHENTICATIONTYPENAME_"+sGXsfl_72_idx;
         edtavUsername_Internalname = sPrefix+"vUSERNAME_"+sGXsfl_72_idx;
         edtavFirstname_Internalname = sPrefix+"vFIRSTNAME_"+sGXsfl_72_idx;
         edtavLastname_Internalname = sPrefix+"vLASTNAME_"+sGXsfl_72_idx;
         edtavEmail_Internalname = sPrefix+"vEMAIL_"+sGXsfl_72_idx;
         edtavUserid_Internalname = sPrefix+"vUSERID_"+sGXsfl_72_idx;
         edtavDeleteuser_action_Internalname = sPrefix+"vDELETEUSER_ACTION_"+sGXsfl_72_idx;
      }

      protected void SubsflControlProps_fel_722( )
      {
         edtavAuthenticationtypename_Internalname = sPrefix+"vAUTHENTICATIONTYPENAME_"+sGXsfl_72_fel_idx;
         edtavUsername_Internalname = sPrefix+"vUSERNAME_"+sGXsfl_72_fel_idx;
         edtavFirstname_Internalname = sPrefix+"vFIRSTNAME_"+sGXsfl_72_fel_idx;
         edtavLastname_Internalname = sPrefix+"vLASTNAME_"+sGXsfl_72_fel_idx;
         edtavEmail_Internalname = sPrefix+"vEMAIL_"+sGXsfl_72_fel_idx;
         edtavUserid_Internalname = sPrefix+"vUSERID_"+sGXsfl_72_fel_idx;
         edtavDeleteuser_action_Internalname = sPrefix+"vDELETEUSER_ACTION_"+sGXsfl_72_fel_idx;
      }

      protected void sendrow_722( )
      {
         SubsflControlProps_722( ) ;
         WB3Z0( ) ;
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
            if ( ((int)((nGXsfl_72_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_72_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 73,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAuthenticationtypename_Internalname,StringUtil.RTrim( AV26AuthenticationTypeName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,73);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAuthenticationtypename_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(short)-1,(int)edtavAuthenticationtypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavUsername_Enabled!=0)&&(edtavUsername_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 74,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsername_Internalname,StringUtil.RTrim( AV27UserName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUsername_Enabled!=0)&&(edtavUsername_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,74);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUsername_Link,(string)"",(string)"",(string)"",(string)edtavUsername_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavUsername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 75,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFirstname_Internalname,StringUtil.RTrim( AV28FirstName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,75);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFirstname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(short)-1,(int)edtavFirstname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 76,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLastname_Internalname,StringUtil.RTrim( AV29LastName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,76);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLastname_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn InvisibleInSmallColumn InvisibleInMediumColumn",(string)"",(short)-1,(int)edtavLastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavEmail_Enabled!=0)&&(edtavEmail_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 77,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEmail_Internalname,(string)AV30Email,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEmail_Enabled!=0)&&(edtavEmail_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,77);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEmail_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavEmail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMEMail",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavUserid_Enabled!=0)&&(edtavUserid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 78,'"+sPrefix+"',false,'"+sGXsfl_72_idx+"',72)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserid_Internalname,StringUtil.RTrim( AV31UserId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUserid_Enabled!=0)&&(edtavUserid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,78);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUserid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavUserid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDeleteuser_action_Enabled!=0)&&(edtavDeleteuser_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'"+sPrefix+"',false,'',72)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDeleteuser_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDeleteuser_action_gximage+"_Class");
         StyleString = "";
         AV32DeleteUser_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32DeleteUser_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV43Deleteuser_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32DeleteUser_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32DeleteUser_Action)) ? AV43Deleteuser_action_GXI : context.PathToRelativeUrl( AV32DeleteUser_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleteuser_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete User",(string)edtavDeleteuser_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDeleteuser_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETEUSER\\'."+sGXsfl_72_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV32DeleteUser_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes3Z2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_72_idx = ((subGrid_Islastpage==1)&&(nGXsfl_72_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_72_idx+1);
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_722( ) ;
         /* End function sendrow_722 */
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
         }
         chkavFreezecolumntitles_grid.Name = "vFREEZECOLUMNTITLES_GRID";
         chkavFreezecolumntitles_grid.WebTags = "";
         chkavFreezecolumntitles_grid.Caption = "";
         AssignProp(sPrefix, false, chkavFreezecolumntitles_grid_Internalname, "TitleCaption", chkavFreezecolumntitles_grid.Caption, true);
         chkavFreezecolumntitles_grid.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl72( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"72\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Authentication", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_FirstName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_LastName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GAM_UserId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDeleteuser_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDeleteuser_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV26AuthenticationTypeName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27UserName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsername_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUsername_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28FirstName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29LastName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV30Email));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmail_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31UserId)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUserid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV32DeleteUser_Action));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDeleteuser_action_Tooltiptext));
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
         divLayoutdefined_filtercontainersection_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         imgGridsettings_labelgrid_Internalname = sPrefix+"GRIDSETTINGS_LABELGRID";
         lblGslayoutdefined_gridruntimecolumnselectiontb_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_grid_Internalname = sPrefix+"vGRIDSETTINGSROWSPERPAGE_GRID";
         divRowsperpagecontainer_grid_Internalname = sPrefix+"ROWSPERPAGECONTAINER_GRID";
         chkavFreezecolumntitles_grid_Internalname = sPrefix+"vFREEZECOLUMNTITLES_GRID";
         divFreezecolumntitlescontainer_grid_Internalname = sPrefix+"FREEZECOLUMNTITLESCONTAINER_GRID";
         bttGridsettings_savegrid_Internalname = sPrefix+"GRIDSETTINGS_SAVEGRID";
         divGslayoutdefined_gridcustomizationcollapsiblesection_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_grid_Internalname = sPrefix+"GRIDCUSTOMIZATIONCONTAINER_GRID";
         divGslayoutdefined_gridcontentinnertable_Internalname = sPrefix+"GSLAYOUTDEFINED_GRIDCONTENTINNERTABLE";
         divGridsettings_contentoutertablegrid_Internalname = sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEGRID";
         divGridsettings_globaltable_grid_Internalname = sPrefix+"GRIDSETTINGS_GLOBALTABLE_GRID";
         bttAdd_Internalname = sPrefix+"ADD";
         divActions_grid_topright_Internalname = sPrefix+"ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         edtavAuthenticationtypename_Internalname = sPrefix+"vAUTHENTICATIONTYPENAME";
         edtavUsername_Internalname = sPrefix+"vUSERNAME";
         edtavFirstname_Internalname = sPrefix+"vFIRSTNAME";
         edtavLastname_Internalname = sPrefix+"vLASTNAME";
         edtavEmail_Internalname = sPrefix+"vEMAIL";
         edtavUserid_Internalname = sPrefix+"vUSERID";
         edtavDeleteuser_action_Internalname = sPrefix+"vDELETEUSER_ACTION";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         lblPaginationbar_previouspagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID";
         lblPaginationbar_firstpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacinglefttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID";
         lblPaginationbar_previouspagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID";
         lblPaginationbar_currentpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID";
         lblPaginationbar_nextpagetextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID";
         lblPaginationbar_spacingrighttextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID";
         lblPaginationbar_nextpagebuttontextblockgrid_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID";
         divPaginationbar_pagingcontainertable_grid_Internalname = sPrefix+"PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID";
         divLayoutdefined_section8_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         divGridcomponent_grid_content_Internalname = sPrefix+"GRIDCOMPONENT_GRID_CONTENT";
         Gridcomponent_grid_Internalname = sPrefix+"GRIDCOMPONENT_GRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavFreezecolumntitles_grid.Caption = context.GetMessage( "K2BT_FreezeColumnTitles", "");
         edtavDeleteuser_action_Jsonclick = "";
         edtavDeleteuser_action_gximage = "";
         edtavDeleteuser_action_Visible = -1;
         edtavDeleteuser_action_Enabled = 1;
         edtavDeleteuser_action_Tooltiptext = "";
         edtavUserid_Jsonclick = "";
         edtavUserid_Visible = 0;
         edtavUserid_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Visible = -1;
         edtavEmail_Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Visible = -1;
         edtavLastname_Enabled = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Visible = -1;
         edtavFirstname_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Visible = -1;
         edtavUsername_Enabled = 1;
         edtavAuthenticationtypename_Jsonclick = "";
         edtavAuthenticationtypename_Visible = -1;
         edtavAuthenticationtypename_Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavUsername_Link = "";
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
         Gridcomponent_grid_Containseditableform = Convert.ToBoolean( 0);
         Gridcomponent_grid_Showborders = Convert.ToBoolean( -1);
         Gridcomponent_grid_Open = Convert.ToBoolean( 0);
         Gridcomponent_grid_Collapsible = Convert.ToBoolean( -1);
         Gridcomponent_grid_Title = context.GetMessage( "K2BT_GAM_Users", "");
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'sPrefix'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E193Z2',iparms:[{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E203Z2',iparms:[{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV32DeleteUser_Action',fld:'vDELETEUSER_ACTION',pic:''},{av:'edtavDeleteuser_action_Tooltiptext',ctrl:'vDELETEUSER_ACTION',prop:'Tooltiptext'},{av:'AV26AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV27UserName',fld:'vUSERNAME',pic:''},{av:'AV28FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV29LastName',fld:'vLASTNAME',pic:''},{av:'AV30Email',fld:'vEMAIL',pic:''},{av:'AV31UserId',fld:'vUSERID',pic:'',hsh:true},{av:'edtavUsername_Link',ctrl:'vUSERNAME',prop:'Link'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E133Z1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E123Z1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E143Z1',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'","{handler:'E113Z1',iparms:[{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(GRID)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV24GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'","{handler:'E153Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'},{av:'cmbavGridsettingsrowsperpage_grid'},{av:'AV24GridSettingsRowsPerPage_Grid',fld:'vGRIDSETTINGSROWSPERPAGE_GRID',pic:'ZZZ9'}]");
         setEventMetadata("'SAVEGRIDSETTINGS(GRID)'",",oparms:[{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'divGridsettings_contentoutertablegrid_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEGRID',prop:'Visible'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_DELETEUSER'","{handler:'E213Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'},{av:'AV31UserId',fld:'vUSERID',pic:'',hsh:true}]");
         setEventMetadata("'E_DELETEUSER'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("'E_ADD'","{handler:'E163Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV20HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV22RowsPerPage_Grid',fld:'vROWSPERPAGE_GRID',pic:'ZZZ9'},{av:'AV19I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV38Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV18ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV15GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'ADD',prop:'Visible'},{av:'AV25FreezeColumnTitles_Grid',fld:'vFREEZECOLUMNTITLES_GRID',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Deleteuser_action',iparms:[]");
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
         sPrefix = "";
         AV41Pgmname = "";
         AV15GridConfiguration = new SdtK2BGridConfiguration(context);
         AV18ClassCollection_Grid = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGridcomponent_grid = new GXUserControl();
         TempTags = "";
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26AuthenticationTypeName = "";
         AV27UserName = "";
         AV28FirstName = "";
         AV29LastName = "";
         AV30Email = "";
         AV31UserId = "";
         AV32DeleteUser_Action = "";
         AV43Deleteuser_action_GXI = "";
         GXt_char1 = "";
         AV40Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         GridRow = new GXWebRow();
         AV37Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV39GAMUsers = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV35Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GridStateKey = "";
         AV11GridState = new SdtK2BGridState(context);
         AV33GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV36Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV5Window = new GXWindow();
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV38Id = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleusers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleusers__default(),
            new Object[][] {
            }
         );
         AV41Pgmname = "K2BFSG.RoleUsers";
         /* GeneXus formulas. */
         AV41Pgmname = "K2BFSG.RoleUsers";
         edtavAuthenticationtypename_Enabled = 0;
         edtavUsername_Enabled = 0;
         edtavFirstname_Enabled = 0;
         edtavLastname_Enabled = 0;
         edtavEmail_Enabled = 0;
         edtavUserid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV16CurrentPage_Grid ;
      private short AV22RowsPerPage_Grid ;
      private short AV19I_LoadCount_Grid ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV24GridSettingsRowsPerPage_Grid ;
      private short nDraw ;
      private short nDoneStart ;
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
      private int nRC_GXsfl_72 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_72_idx=1 ;
      private int edtavAuthenticationtypename_Enabled ;
      private int edtavUsername_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavUserid_Enabled ;
      private int bttAdd_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int AV42GXV1 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV44GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavAuthenticationtypename_Visible ;
      private int edtavUsername_Visible ;
      private int edtavFirstname_Visible ;
      private int edtavLastname_Visible ;
      private int edtavEmail_Visible ;
      private int edtavUserid_Visible ;
      private int edtavDeleteuser_action_Enabled ;
      private int edtavDeleteuser_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV38Id ;
      private long wcpOAV38Id ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_72_idx="0001" ;
      private string AV41Pgmname ;
      private string edtavAuthenticationtypename_Internalname ;
      private string edtavUsername_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavEmail_Internalname ;
      private string edtavUserid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridcomponent_grid_Title ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Gridcomponent_grid_Internalname ;
      private string divGridcomponent_grid_content_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filtercontainersection_grid_Internalname ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divGridsettings_globaltable_grid_Internalname ;
      private string TempTags ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV26AuthenticationTypeName ;
      private string AV27UserName ;
      private string AV28FirstName ;
      private string AV29LastName ;
      private string AV31UserId ;
      private string edtavDeleteuser_action_Internalname ;
      private string GXt_char1 ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavDeleteuser_action_gximage ;
      private string edtavDeleteuser_action_Tooltiptext ;
      private string edtavUsername_Link ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlAV38Id ;
      private string sGXsfl_72_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavAuthenticationtypename_Jsonclick ;
      private string edtavUsername_Jsonclick ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Jsonclick ;
      private string edtavEmail_Jsonclick ;
      private string edtavUserid_Jsonclick ;
      private string edtavDeleteuser_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20HasNextPage_Grid ;
      private bool AV25FreezeColumnTitles_Grid ;
      private bool bGXsfl_72_Refreshing=false ;
      private bool Gridcomponent_grid_Collapsible ;
      private bool Gridcomponent_grid_Open ;
      private bool Gridcomponent_grid_Showborders ;
      private bool Gridcomponent_grid_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV23RowsPerPageLoaded_Grid ;
      private bool gx_refresh_fired ;
      private bool AV17Reload_Grid ;
      private bool AV21Exit_Grid ;
      private bool AV34isOK ;
      private bool AV32DeleteUser_Action_IsBlob ;
      private string AV30Email ;
      private string AV43Deleteuser_action_GXI ;
      private string AV10GridStateKey ;
      private string AV32DeleteUser_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridcomponent_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_Id ;
      private GXCombobox cmbavGridsettingsrowsperpage_grid ;
      private GXCheckbox chkavFreezecolumntitles_grid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV18ClassCollection_Grid ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV40Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message2 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV39GAMUsers ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV35Errors ;
      private GXWindow AV5Window ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private SdtK2BGridState AV11GridState ;
      private SdtK2BGridConfiguration AV15GridConfiguration ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV33GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV36Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV37Role ;
   }

   public class roleusers__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class roleusers__default : DataStoreHelperBase, IDataStoreHelper
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
