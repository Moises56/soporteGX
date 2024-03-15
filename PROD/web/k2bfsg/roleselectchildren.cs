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
   public class roleselectchildren : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public roleselectchildren( )
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

      public roleselectchildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_RoleId )
      {
         this.AV7RoleId = aP0_RoleId;
         executePrivate();
         aP0_RoleId=this.AV7RoleId;
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
         chkavCheckall_grid = new GXCheckbox();
         chkavMultirowitemselected_grid = new GXCheckbox();
         chkavSelectedcheckall_multipleselection = new GXCheckbox();
         chkavSelectedgridmultirowitemselected_multipleselection = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "RoleId");
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
                  AV7RoleId = (long)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV7RoleId});
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
                  gxfirstwebparm = GetFirstPar( "RoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RoleId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Selectedgrid_multipleselection") == 0 )
               {
                  gxnrSelectedgrid_multipleselection_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Selectedgrid_multipleselection") == 0 )
               {
                  gxgrSelectedgrid_multipleselection_refresh_invoke( ) ;
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
         nRC_GXsfl_67 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_67"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_67_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_67_idx = GetPar( "sGXsfl_67_idx");
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
         AV38CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV64FilName_PreviousValue = GetPar( "FilName_PreviousValue");
         AV65FilExternalId_PreviousValue = GetPar( "FilExternalId_PreviousValue");
         AV34XMLItems_MultipleSelection = GetPar( "XMLItems_MultipleSelection");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV72ClassCollection_Grid);
         AV49FilName = GetPar( "FilName");
         AV83Pgmname = GetPar( "Pgmname");
         AV50FilExternalId = GetPar( "FilExternalId");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV57AllSelectedItems_Grid);
         AV47Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
         AV60Grid_SelectedRows = (short)(Math.Round(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."), 18, MidpointRounding.ToEven));
         AV7RoleId = (long)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         AV43I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV19I_LoadCount_Skip = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Skip"), "."), 18, MidpointRounding.ToEven));
         AV31InCollection = StringUtil.StrToBool( GetPar( "InCollection"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32MultipleSelectionItems);
         AV54CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
         AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( GetPar( "SelectedCheckAll_MultipleSelection"));
         AV35Reload_MultipleSelection = StringUtil.StrToBool( GetPar( "Reload_MultipleSelection"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV65FilExternalId_PreviousValue, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV83Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected void gxnrSelectedgrid_multipleselection_newrow_invoke( )
      {
         nRC_GXsfl_91 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_91"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_91_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_91_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_91_idx = GetPar( "sGXsfl_91_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrSelectedgrid_multipleselection_newrow( ) ;
         /* End function gxnrSelectedgrid_multipleselection_newrow_invoke */
      }

      protected void gxgrSelectedgrid_multipleselection_refresh_invoke( )
      {
         AV38CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV64FilName_PreviousValue = GetPar( "FilName_PreviousValue");
         AV49FilName = GetPar( "FilName");
         AV65FilExternalId_PreviousValue = GetPar( "FilExternalId_PreviousValue");
         AV50FilExternalId = GetPar( "FilExternalId");
         AV34XMLItems_MultipleSelection = GetPar( "XMLItems_MultipleSelection");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV72ClassCollection_Grid);
         AV35Reload_MultipleSelection = StringUtil.StrToBool( GetPar( "Reload_MultipleSelection"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32MultipleSelectionItems);
         AV54CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
         AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( GetPar( "SelectedCheckAll_MultipleSelection"));
         AV60Grid_SelectedRows = (short)(Math.Round(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."), 18, MidpointRounding.ToEven));
         AV43I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV19I_LoadCount_Skip = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Skip"), "."), 18, MidpointRounding.ToEven));
         AV83Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV49FilName, AV65FilExternalId_PreviousValue, AV50FilExternalId, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV83Pgmname, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrSelectedgrid_multipleselection_refresh_invoke */
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
            PA3Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV83Pgmname = "K2BFSG.RoleSelectChildren";
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavSelected_name_Enabled = 0;
               AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               edtavSelected_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_91_Refreshing);
               WS3Y2( ) ;
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
            context.SendWebValue( "Role select children") ;
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
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleselectchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV7RoleId,12,0))}, new string[] {"RoleId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV64FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV64FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILEXTERNALID_PREVIOUSVALUE", StringUtil.RTrim( AV65FilExternalId_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILEXTERNALID_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65FilExternalId_PreviousValue, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vRELOAD_MULTIPLESELECTION", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_SKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Skip), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_67", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_67), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_91", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_91), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV70FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV70FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG_GRID", StringUtil.RTrim( AV71DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7RoleId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV64FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV64FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILEXTERNALID_PREVIOUSVALUE", StringUtil.RTrim( AV65FilExternalId_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILEXTERNALID_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65FilExternalId_PreviousValue, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV72ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV72ClassCollection_Grid);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vRELOAD_MULTIPLESELECTION", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMULTIPLESELECTIONITEMS", AV32MultipleSelectionItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMULTIPLESELECTIONITEMS", AV32MultipleSelectionItems);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 12, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLSELECTEDITEMS_GRID", AV57AllSelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLSELECTEDITEMS_GRID", AV57AllSelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_SKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Skip), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vINCOLLECTION", AV31InCollection);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vMULTIROWHASNEXT_GRID", AV41MultiRowHasNext_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_NAME", StringUtil.RTrim( AV61S_Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62S_Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMULTIROWITERATOR_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42MultiRowIterator_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDITEMS_GRID", AV58SelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDITEMS_GRID", AV58SelectedItems_Grid);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFIELDVALUES_GRID", AV66FieldValues_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFIELDVALUES_GRID", AV66FieldValues_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subSelectedgrid_multipleselection_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILNAME_Caption", StringUtil.RTrim( edtavFilname_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILNAME_Caption", StringUtil.RTrim( edtavFilname_Caption));
      }

      protected void RenderHtmlCloseForm3Y2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "K2BFSG.RoleSelectChildren" ;
      }

      public override string GetPgmdesc( )
      {
         return "Role select children" ;
      }

      protected void WB3Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.roleselectchildren.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainmultipleselectionresponsivetable_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BT_MultipleSelectionContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BT_MultipleSelectionGridContainer", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_onlydetailedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table11_grid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e113y1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_k2bt_filtercaption_grid_Internalname, "Filters", "", "", lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_FilterToggleText", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV70FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV71DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, sPrefix+"FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable K2BT_EditableForm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_filname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, "Name", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, StringUtil.RTrim( AV49FilName), StringUtil.RTrim( context.localUtil.Format( AV49FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filexternalid_Internalname, divTable_container_filexternalid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavFilexternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilexternalid_Internalname, "External ID", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilexternalid_Internalname, StringUtil.RTrim( AV50FilExternalId), StringUtil.RTrim( context.localUtil.Format( AV50FilExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilexternalid_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilexternalid_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridConfigurationContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegridcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_grid_Internalname, StringUtil.BoolToStr( AV54CheckAll_Grid), "", "", 1, chkavCheckall_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl67( ) ;
         }
         if ( wbEnd == 67 )
         {
            wbEnd = 0;
            nRC_GXsfl_67 = (int)(nGXsfl_67_idx-1);
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_73_3Y2( true) ;
         }
         else
         {
            wb_table1_73_3Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_73_3Y2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BToolsMultipleSelectionButtons", "start", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsMultipleSelectionImage" + " " + ((StringUtil.StrCmp(imgMultipleselection_add_gximage, "")==0) ? "GX_Image_K2BActionRemove_Class" : "GX_Image_"+imgMultipleselection_add_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "403df9aa-667d-48f9-8058-9fe7672d9ae4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMultipleselection_add_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_MultipleSelectionRemove", "Remove", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgMultipleselection_add_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVE(MULTIPLESELECTION)\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsMultipleSelectionImage" + " " + ((StringUtil.StrCmp(imgMultipleselection_remove_gximage, "")==0) ? "GX_Image_K2BActionAdd_Class" : "GX_Image_"+imgMultipleselection_remove_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "80546ac5-4685-4f33-bad3-7ceb5a1259f4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMultipleselection_remove_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_MultipleSelectionAdd", "Add", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgMultipleselection_remove_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADD(MULTIPLESELECTION)\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecteduitemsmaintable_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BT_MultipleSelectionSelectedItems K2BToolsTable_ComponentWithoutTitleContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavXmlitems_multipleselection_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavXmlitems_multipleselection_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavXmlitems_multipleselection_Internalname, "XMLItems_Multiple Selection", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavXmlitems_multipleselection_Internalname, StringUtil.RTrim( AV34XMLItems_MultipleSelection), StringUtil.RTrim( context.localUtil.Format( AV34XMLItems_MultipleSelection, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavXmlitems_multipleselection_Jsonclick, 0, "Attribute", "", "", "", "", edtavXmlitems_multipleselection_Visible, edtavXmlitems_multipleselection_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecteditemsresponsivetablecontainer_multipleselection_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegridcontainermultipleselection_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectedcheckall_multipleselection_Internalname, StringUtil.BoolToStr( AV53SelectedCheckAll_MultipleSelection), "", "", 1, chkavSelectedcheckall_multipleselection.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /*  Grid Control  */
            Selectedgrid_multipleselectionContainer.SetWrapped(nGXWrapped);
            StartGridControl91( ) ;
         }
         if ( wbEnd == 91 )
         {
            wbEnd = 0;
            nRC_GXsfl_91 = (int)(nGXsfl_91_idx-1);
            if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selectedgrid_multipleselection", Selectedgrid_multipleselectionContainer, subSelectedgrid_multipleselection_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData", Selectedgrid_multipleselectionContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData"+"V", Selectedgrid_multipleselectionContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selectedgrid_multipleselectionContainerData"+"V"+"\" value='"+Selectedgrid_multipleselectionContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionscontainertableleft_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTableActionsLeftContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", "Confirm", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 67 )
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
         if ( wbEnd == 91 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selectedgrid_multipleselection", Selectedgrid_multipleselectionContainer, subSelectedgrid_multipleselection_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData", Selectedgrid_multipleselectionContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData"+"V", Selectedgrid_multipleselectionContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selectedgrid_multipleselectionContainerData"+"V"+"\" value='"+Selectedgrid_multipleselectionContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Y2( )
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
            Form.Meta.addItem("description", "Role select children", 0) ;
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
               STRUP3Y0( ) ;
            }
         }
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                                 STRUP3Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Confirm' */
                                    E123Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCHECKALL_GRID.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E133Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADD(MULTIPLESELECTION)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Add(MultipleSelection)' */
                                    E143Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVE(MULTIPLESELECTION)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Remove(MultipleSelection)' */
                                    E153Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E163Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E173Y2 ();
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
                              SubsflControlProps_672( ) ;
                              AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
                              AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
                              AV45Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                                 GX_FocusControl = edtavId_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV47Id = 0;
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                              }
                              else
                              {
                                 AV47Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                              }
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E183Y2 ();
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E193Y2 ();
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E203Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E163Y2 ();
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E213Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E223Y2 ();
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
                                       STRUP3Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E163Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E173Y2 ();
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "SELECTEDGRID_MULTIPLESELECTION.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.DROP") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              nGXsfl_91_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
                              SubsflControlProps_913( ) ;
                              AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
                              AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
                              AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
                              AssignAttri(sPrefix, false, edtavSelected_name_Internalname, AV46Selected_Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
                                 GX_FocusControl = edtavSelected_id_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV48Selected_Id = 0;
                                 AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
                              }
                              else
                              {
                                 AV48Selected_Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E233Y3 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E173Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E163Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E173Y2 ();
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

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Y2( ) ;
            }
         }
      }

      protected void PA3Y2( )
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
               GX_FocusControl = edtavFilname_Internalname;
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
         SubsflControlProps_672( ) ;
         while ( nGXsfl_67_idx <= nRC_GXsfl_67 )
         {
            sendrow_672( ) ;
            nGXsfl_67_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_idx+1);
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxnrSelectedgrid_multipleselection_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_913( ) ;
         while ( nGXsfl_91_idx <= nRC_GXsfl_91 )
         {
            sendrow_913( ) ;
            nGXsfl_91_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_91_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_idx+1);
            sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
            SubsflControlProps_913( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Selectedgrid_multipleselectionContainer)) ;
         /* End function gxnrSelectedgrid_multipleselection_newrow */
      }

      protected void gxgrGrid_refresh( short AV38CurrentPage_Grid ,
                                       string AV64FilName_PreviousValue ,
                                       string AV65FilExternalId_PreviousValue ,
                                       string AV34XMLItems_MultipleSelection ,
                                       GxSimpleCollection<string> AV72ClassCollection_Grid ,
                                       string AV49FilName ,
                                       string AV83Pgmname ,
                                       string AV50FilExternalId ,
                                       GXBaseCollection<SdtK2BSelectionItem> AV57AllSelectedItems_Grid ,
                                       long AV47Id ,
                                       short AV60Grid_SelectedRows ,
                                       long AV7RoleId ,
                                       short AV43I_LoadCount_Grid ,
                                       short AV19I_LoadCount_Skip ,
                                       bool AV31InCollection ,
                                       GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ,
                                       bool AV54CheckAll_Grid ,
                                       bool AV53SelectedCheckAll_MultipleSelection ,
                                       bool AV35Reload_MultipleSelection ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void gxgrSelectedgrid_multipleselection_refresh( short AV38CurrentPage_Grid ,
                                                                 string AV64FilName_PreviousValue ,
                                                                 string AV49FilName ,
                                                                 string AV65FilExternalId_PreviousValue ,
                                                                 string AV50FilExternalId ,
                                                                 string AV34XMLItems_MultipleSelection ,
                                                                 GxSimpleCollection<string> AV72ClassCollection_Grid ,
                                                                 bool AV35Reload_MultipleSelection ,
                                                                 GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ,
                                                                 bool AV54CheckAll_Grid ,
                                                                 bool AV53SelectedCheckAll_MultipleSelection ,
                                                                 short AV60Grid_SelectedRows ,
                                                                 short AV43I_LoadCount_Grid ,
                                                                 short AV19I_LoadCount_Skip ,
                                                                 string AV83Pgmname ,
                                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         SELECTEDGRID_MULTIPLESELECTION_nCurrentRecord = 0;
         RF3Y3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrSelectedgrid_multipleselection_refresh */
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
         AV54CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV54CheckAll_Grid));
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( StringUtil.BoolToStr( AV53SelectedCheckAll_MultipleSelection));
         AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E193Y2 ();
         RF3Y2( ) ;
         RF3Y3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV83Pgmname = "K2BFSG.RoleSelectChildren";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_67_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_67_Refreshing);
         edtavSelected_name_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavSelected_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_91_Refreshing);
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 67;
         /* Execute user event: Refresh */
         E193Y2 ();
         E213Y2 ();
         nGXsfl_67_idx = 1;
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         bGXsfl_67_Refreshing = true;
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
            SubsflControlProps_672( ) ;
            E203Y2 ();
            wbEnd = 67;
            WB3Y0( ) ;
         }
         bGXsfl_67_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILNAME_PREVIOUSVALUE", StringUtil.RTrim( AV64FilName_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV64FilName_PreviousValue, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILEXTERNALID_PREVIOUSVALUE", StringUtil.RTrim( AV65FilExternalId_PreviousValue));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILEXTERNALID_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65FilExternalId_PreviousValue, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vRELOAD_MULTIPLESELECTION", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_SKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Skip), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
      }

      protected void RF3Y3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Selectedgrid_multipleselectionContainer.ClearRows();
         }
         wbStart = 91;
         /* Execute user event: Refresh */
         E193Y2 ();
         nGXsfl_91_idx = 1;
         sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
         SubsflControlProps_913( ) ;
         bGXsfl_91_Refreshing = true;
         Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("CmpContext", sPrefix);
         Selectedgrid_multipleselectionContainer.AddObjectProperty("InMasterPage", "false");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Backcolorstyle), 1, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Sortable), 1, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.PageSize = subSelectedgrid_multipleselection_fnc_Recordsperpage( );
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
            SubsflControlProps_913( ) ;
            E233Y3 ();
            wbEnd = 91;
            WB3Y0( ) ;
         }
         bGXsfl_91_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Y3( )
      {
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

      protected int subSelectedgrid_multipleselection_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV83Pgmname = "K2BFSG.RoleSelectChildren";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_67_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_67_Refreshing);
         edtavSelected_name_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         edtavSelected_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_91_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E183Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGSCOLLECTION_GRID"), AV70FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_91 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_91"), ".", ","), 18, MidpointRounding.ToEven));
            AV71DeletedTag_Grid = cgiGet( sPrefix+"vDELETEDTAG_GRID");
            wcpOAV7RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7RoleId"), ".", ","), 18, MidpointRounding.ToEven));
            AV38CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            subSelectedgrid_multipleselection_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subSelectedgrid_multipleselection_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            edtavFilname_Caption = cgiGet( sPrefix+"vFILNAME_Caption");
            /* Read variables values. */
            AV49FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri(sPrefix, false, "AV49FilName", AV49FilName);
            AV50FilExternalId = cgiGet( edtavFilexternalid_Internalname);
            AssignAttri(sPrefix, false, "AV50FilExternalId", AV50FilExternalId);
            AV54CheckAll_Grid = StringUtil.StrToBool( cgiGet( chkavCheckall_grid_Internalname));
            AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            AV34XMLItems_MultipleSelection = cgiGet( edtavXmlitems_multipleselection_Internalname);
            AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
            AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedcheckall_multipleselection_Internalname));
            AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
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
         AV32MultipleSelectionItems.Clear();
         AV6GAMRole.load( AV7RoleId);
         AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV5ChildRoles.Count )
         {
            AV10RoleAux = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV73GXV1));
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Id = AV10RoleAux.gxTpr_Id;
            AV33MultipleSelectionItem.gxTpr_Name = AV10RoleAux.gxTpr_Name;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         AV19I_LoadCount_Skip = 0;
         AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E183Y2 ();
         if (returnInSub) return;
      }

      protected void E183Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV64FilName_PreviousValue = AV49FilName;
         AssignAttri(sPrefix, false, "AV64FilName_PreviousValue", AV64FilName_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV64FilName_PreviousValue, "")), context));
         AV65FilExternalId_PreviousValue = AV50FilExternalId;
         AssignAttri(sPrefix, false, "AV65FilExternalId_PreviousValue", AV65FilExternalId_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILEXTERNALID_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65FilExternalId_PreviousValue, "")), context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
      }

      protected void E193Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S142 ();
         if (returnInSub) return;
         if ( (0==AV38CurrentPage_Grid) )
         {
            AV38CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV38CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV38CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV64FilName_PreviousValue, AV49FilName) != 0 )
         {
            AV64FilName_PreviousValue = AV49FilName;
            AssignAttri(sPrefix, false, "AV64FilName_PreviousValue", AV64FilName_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILNAME_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV64FilName_PreviousValue, "")), context));
            AV38CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV38CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV38CurrentPage_Grid), 4, 0));
         }
         if ( StringUtil.StrCmp(AV65FilExternalId_PreviousValue, AV50FilExternalId) != 0 )
         {
            AV65FilExternalId_PreviousValue = AV50FilExternalId;
            AssignAttri(sPrefix, false, "AV65FilExternalId_PreviousValue", AV65FilExternalId_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFILEXTERNALID_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV65FilExternalId_PreviousValue, "")), context));
            AV38CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV38CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV38CurrentPage_Grid), 4, 0));
         }
         AV39Reload_Grid = true;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV35Reload_MultipleSelection = true;
         AssignAttri(sPrefix, false, "AV35Reload_MultipleSelection", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         edtavXmlitems_multipleselection_Visible = 0;
         AssignProp(sPrefix, false, edtavXmlitems_multipleselection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavXmlitems_multipleselection_Visible), 5, 0), true);
         divTable_container_filexternalid_Visible = 0;
         AssignProp(sPrefix, false, divTable_container_filexternalid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable_container_filexternalid_Visible), 5, 0), true);
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            AV60Grid_SelectedRows = 0;
            AssignAttri(sPrefix, false, "AV60Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV60Grid_SelectedRows), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         }
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV72ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      protected void S152( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         edtavSelected_id_Visible = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Visible), 5, 0), !bGXsfl_91_Refreshing);
      }

      protected void S163( )
      {
         /* 'U_LOADSELECTEDGRIDROWVARS(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S292( )
      {
         /* 'RESETMULTIROWITERATOR(GRID)' Routine */
         returnInSub = false;
         AV42MultiRowIterator_Grid = 1;
         AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void S282( )
      {
         /* 'GETNEXTMULTIROW(GRID)' Routine */
         returnInSub = false;
         AV61S_Name = "";
         AssignAttri(sPrefix, false, "AV61S_Name", AV61S_Name);
         AV62S_Id = 0;
         AssignAttri(sPrefix, false, "AV62S_Id", StringUtil.LTrimStr( (decimal)(AV62S_Id), 12, 0));
         while ( ( AV42MultiRowIterator_Grid <= AV58SelectedItems_Grid.Count ) && ! ((SdtK2BSelectionItem)AV58SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Isselected )
         {
            AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
            AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
         }
         if ( AV42MultiRowIterator_Grid > AV58SelectedItems_Grid.Count )
         {
            AV41MultiRowHasNext_Grid = false;
            AssignAttri(sPrefix, false, "AV41MultiRowHasNext_Grid", AV41MultiRowHasNext_Grid);
         }
         else
         {
            AV41MultiRowHasNext_Grid = true;
            AssignAttri(sPrefix, false, "AV41MultiRowHasNext_Grid", AV41MultiRowHasNext_Grid);
            AV66FieldValues_Grid = ((SdtK2BSelectionItem)AV58SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_GRID' */
            S302 ();
            if (returnInSub) return;
         }
         AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
         AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void S172( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV6GAMRole.load( AV7RoleId);
         AV52RoleName = AV6GAMRole.gxTpr_Name;
         AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV51isOK = true;
         AV75GXV2 = 1;
         while ( AV75GXV2 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV75GXV2));
            AV18Found = false;
            AV76GXV3 = 1;
            while ( AV76GXV3 <= AV5ChildRoles.Count )
            {
               AV17item = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV76GXV3));
               if ( AV17item.gxTpr_Id == AV33MultipleSelectionItem.gxTpr_Id )
               {
                  AV18Found = true;
               }
               AV76GXV3 = (int)(AV76GXV3+1);
            }
            if ( ! AV18Found )
            {
               AV51isOK = AV6GAMRole.addrolebyid(AV33MultipleSelectionItem.gxTpr_Id, ref  AV12Errors);
               if ( ! AV51isOK )
               {
                  AV77GXV4 = 1;
                  while ( AV77GXV4 <= AV12Errors.Count )
                  {
                     AV16Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV77GXV4));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV16Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV16Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV77GXV4 = (int)(AV77GXV4+1);
                  }
                  if (true) break;
               }
            }
            AV75GXV2 = (int)(AV75GXV2+1);
         }
         if ( AV51isOK )
         {
            AV78GXV5 = 1;
            while ( AV78GXV5 <= AV5ChildRoles.Count )
            {
               AV17item = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV78GXV5));
               AV18Found = false;
               AV79GXV6 = 1;
               while ( AV79GXV6 <= AV32MultipleSelectionItems.Count )
               {
                  AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV79GXV6));
                  if ( AV17item.gxTpr_Id == AV33MultipleSelectionItem.gxTpr_Id )
                  {
                     AV18Found = true;
                  }
                  AV79GXV6 = (int)(AV79GXV6+1);
               }
               if ( ! AV18Found )
               {
                  AV51isOK = AV6GAMRole.deleterolebyid(AV17item.gxTpr_Id, ref  AV12Errors);
                  if ( ! AV51isOK )
                  {
                     AV80GXV7 = 1;
                     while ( AV80GXV7 <= AV12Errors.Count )
                     {
                        AV16Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV80GXV7));
                        GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV16Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV16Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                        AV80GXV7 = (int)(AV80GXV7+1);
                     }
                     if (true) break;
                  }
               }
               AV78GXV5 = (int)(AV78GXV5+1);
            }
         }
         if ( AV51isOK )
         {
            context.CommitDataStores("k2bfsg.roleselectchildren",pr_default);
            GX_msglist.addItem(StringUtil.Format( "Child roles for %1 have been updated", AV52RoleName, "", "", "", "", "", "", "", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void E123Y2( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      private void E203Y2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV43I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV43I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV43I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         AV44Exit_Grid = false;
         while ( true )
         {
            AV43I_LoadCount_Grid = (short)(AV43I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV43I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV43I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S182 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S192 ();
            if (returnInSub) return;
            if ( AV44Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            AV40MultiRowItemSelected_Grid = false;
            AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
            AV81GXV8 = 1;
            while ( AV81GXV8 <= AV57AllSelectedItems_Grid.Count )
            {
               AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV81GXV8));
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  if ( AV55SelectedItem_Grid.gxTpr_Isselected )
                  {
                     AV40MultiRowItemSelected_Grid = true;
                     AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
                     AV60Grid_SelectedRows = (short)(AV60Grid_SelectedRows+1);
                     AssignAttri(sPrefix, false, "AV60Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV60Grid_SelectedRows), 4, 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
                  }
                  if (true) break;
               }
               AV81GXV8 = (int)(AV81GXV8+1);
            }
            if ( AV43I_LoadCount_Grid == 1 )
            {
               AV54CheckAll_Grid = true;
               AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            }
            if ( ! AV40MultiRowItemSelected_Grid )
            {
               AV54CheckAll_Grid = false;
               AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 67;
            }
            sendrow_672( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_67_Refreshing )
            {
               context.DoAjaxLoad(67, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9Filter", AV9Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      protected void S182( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         AV6GAMRole.load( AV7RoleId);
         AV9Filter.gxTpr_Name = AV49FilName;
         AV9Filter.gxTpr_Externalid = AV50FilExternalId;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         if ( AV43I_LoadCount_Grid == 1 )
         {
            AV19I_LoadCount_Skip = 0;
            AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
            AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
            AV11CandidateRoles = AV6GAMRole.getunassignedroles(AV9Filter, out  AV12Errors);
         }
         AV14FoundItem = false;
         if ( AV5ChildRoles.Count + AV11CandidateRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip )
         {
            while ( ( AV5ChildRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip ) && ! AV14FoundItem )
            {
               AV45Name = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip)).gxTpr_Name;
               AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
               AV47Id = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip)).gxTpr_Id;
               AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
               /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
               S212 ();
               if (returnInSub) return;
               if ( ! AV31InCollection )
               {
                  AV14FoundItem = true;
               }
               else
               {
                  AV19I_LoadCount_Skip = (short)(AV19I_LoadCount_Skip+1);
                  AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
               }
            }
            if ( ! AV14FoundItem )
            {
               while ( ( ( AV5ChildRoles.Count + AV11CandidateRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip ) ) && ! AV14FoundItem )
               {
                  AV13i = (short)(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip-AV5ChildRoles.Count);
                  AV45Name = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV11CandidateRoles.Item(AV13i)).gxTpr_Name;
                  AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
                  AV47Id = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV11CandidateRoles.Item(AV13i)).gxTpr_Id;
                  AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                  /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
                  S212 ();
                  if (returnInSub) return;
                  if ( ! AV31InCollection )
                  {
                     AV14FoundItem = true;
                  }
                  else
                  {
                     AV19I_LoadCount_Skip = (short)(AV19I_LoadCount_Skip+1);
                     AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
                  }
               }
            }
         }
         if ( ! AV14FoundItem )
         {
            AV44Exit_Grid = true;
         }
      }

      protected void S212( )
      {
         /* 'ISINCOLLECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
         AV31InCollection = false;
         AssignAttri(sPrefix, false, "AV31InCollection", AV31InCollection);
         AV82GXV9 = 1;
         while ( AV82GXV9 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV82GXV9));
            if ( AV47Id == AV33MultipleSelectionItem.gxTpr_Id )
            {
               AV31InCollection = true;
               AssignAttri(sPrefix, false, "AV31InCollection", AV31InCollection);
               if (true) break;
            }
            AV82GXV9 = (int)(AV82GXV9+1);
         }
      }

      protected void S202( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV26GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV83Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV27GridState.gxTpr_Filtervalues.Clear();
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "FilName";
         AV28GridStateFilterValue.gxTpr_Value = AV49FilName;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "FilExternalId";
         AV28GridStateFilterValue.gxTpr_Value = AV50FilExternalId;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV83Pgmname,  AV26GridStateKey,  AV27GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV26GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV83Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV84GXV10 = 1;
         while ( AV84GXV10 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV84GXV10));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "FilName") == 0 )
            {
               AV49FilName = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV49FilName", AV49FilName);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "FilExternalId") == 0 )
            {
               AV50FilExternalId = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV50FilExternalId", AV50FilExternalId);
            }
            AV84GXV10 = (int)(AV84GXV10+1);
         }
      }

      protected void E163Y2( )
      {
         /* Selectedgrid_multipleselection_Drop Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
         S212 ();
         if (returnInSub) return;
         if ( ! AV31InCollection )
         {
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Name = AV45Name;
            AV33MultipleSelectionItem.gxTpr_Id = AV47Id;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
            AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         }
         AV40MultiRowItemSelected_Grid = false;
         AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
         /* Execute user subroutine: 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' */
         S222 ();
         if (returnInSub) return;
         AV59Index_Grid = 1;
         while ( AV59Index_Grid <= AV57AllSelectedItems_Grid.Count )
         {
            if ( ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV59Index_Grid)).gxTpr_Sknumeric1 == AV47Id )
            {
               AV57AllSelectedItems_Grid.RemoveItem(AV59Index_Grid);
            }
            else
            {
               AV59Index_Grid = (short)(AV59Index_Grid+1);
            }
         }
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV65FilExternalId_PreviousValue, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV83Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV49FilName, AV65FilExternalId_PreviousValue, AV50FilExternalId, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV83Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      protected void E173Y2( )
      {
         /* Grid_Drop Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV85GXV11 = 1;
         while ( AV85GXV11 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV85GXV11));
            if ( AV48Selected_Id == AV33MultipleSelectionItem.gxTpr_Id )
            {
               AV37SelectedGridLoadCount_MultipleSelection = (short)(AV32MultipleSelectionItems.IndexOf(AV33MultipleSelectionItem));
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               if (true) break;
            }
            AV85GXV11 = (int)(AV85GXV11+1);
         }
         if ( AV37SelectedGridLoadCount_MultipleSelection != 0 )
         {
            AV32MultipleSelectionItems.RemoveItem(AV37SelectedGridLoadCount_MultipleSelection);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
         AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
         /* Execute user subroutine: 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' */
         S232 ();
         if (returnInSub) return;
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV65FilExternalId_PreviousValue, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV83Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV49FilName, AV65FilExternalId_PreviousValue, AV50FilExternalId, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV83Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      protected void S222( )
      {
         /* 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S232( )
      {
         /* 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S242( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E213Y2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S202 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S242 ();
         if (returnInSub) return;
         AV54CheckAll_Grid = false;
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV70FilterTagsCollection_Grid", AV70FilterTagsCollection_Grid);
      }

      protected void E223Y2( )
      {
         /* Multirowitemselected_grid_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(GRID)' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
      }

      protected void S252( )
      {
         /* 'PROCESSSELECTION(GRID)' Routine */
         returnInSub = false;
         AV54CheckAll_Grid = true;
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         /* Start For Each Line in Grid */
         nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_67_fel_idx = 0;
         while ( nGXsfl_67_fel_idx < nRC_GXsfl_67 )
         {
            nGXsfl_67_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_fel_idx+1);
            sGXsfl_67_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_672( ) ;
            AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV45Name = cgiGet( edtavName_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               wbErr = true;
               AV47Id = 0;
            }
            else
            {
               AV47Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
            S262 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_67_fel_idx == 0 )
         {
            nGXsfl_67_idx = 1;
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
         }
         nGXsfl_67_fel_idx = 1;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S272 ();
         if (returnInSub) return;
         if ( AV57AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV72ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV72ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
      }

      protected void E133Y2( )
      {
         /* Checkall_grid_Click Routine */
         returnInSub = false;
         /* Start For Each Line in Grid */
         nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_67_fel_idx = 0;
         while ( nGXsfl_67_fel_idx < nRC_GXsfl_67 )
         {
            nGXsfl_67_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_fel_idx+1);
            sGXsfl_67_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_672( ) ;
            AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV45Name = cgiGet( edtavName_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               wbErr = true;
               AV47Id = 0;
            }
            else
            {
               AV47Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( AV40MultiRowItemSelected_Grid != AV54CheckAll_Grid )
            {
               AV40MultiRowItemSelected_Grid = AV54CheckAll_Grid;
               AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
               /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
               S262 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_67_fel_idx == 0 )
         {
            nGXsfl_67_idx = 1;
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
         }
         nGXsfl_67_fel_idx = 1;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S272 ();
         if (returnInSub) return;
         if ( AV57AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV72ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV72ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
      }

      protected void S262( )
      {
         /* 'UPDATESELECTION(GRID)' Routine */
         returnInSub = false;
         AV59Index_Grid = 1;
         while ( AV59Index_Grid <= AV57AllSelectedItems_Grid.Count )
         {
            if ( ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV59Index_Grid)).gxTpr_Sknumeric1 == AV47Id )
            {
               AV57AllSelectedItems_Grid.RemoveItem(AV59Index_Grid);
            }
            else
            {
               AV59Index_Grid = (short)(AV59Index_Grid+1);
            }
         }
         if ( AV40MultiRowItemSelected_Grid )
         {
            AV55SelectedItem_Grid = new SdtK2BSelectionItem(context);
            AV55SelectedItem_Grid.gxTpr_Isselected = AV40MultiRowItemSelected_Grid;
            AV55SelectedItem_Grid.gxTpr_Sknumeric1 = AV47Id;
            AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV56FieldValue_Grid.gxTpr_Name = "Name";
            AV56FieldValue_Grid.gxTpr_Value = AV45Name;
            AV55SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV56FieldValue_Grid, 0);
            AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV56FieldValue_Grid.gxTpr_Name = "Id";
            AV56FieldValue_Grid.gxTpr_Value = StringUtil.Str( (decimal)(AV47Id), 12, 0);
            AV55SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV56FieldValue_Grid, 0);
            AV57AllSelectedItems_Grid.Add(AV55SelectedItem_Grid, 0);
         }
         if ( ! AV40MultiRowItemSelected_Grid )
         {
            AV54CheckAll_Grid = false;
            AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         }
      }

      protected void S272( )
      {
         /* 'U_MULTIROWITEMSELECTED(GRID)' Routine */
         returnInSub = false;
      }

      protected void S302( )
      {
         /* 'GETFIELDVALUES_GRID' Routine */
         returnInSub = false;
         AV90GXV12 = 1;
         while ( AV90GXV12 <= AV66FieldValues_Grid.Count )
         {
            AV56FieldValue_Grid = ((SdtK2BSelectionItem_FieldValuesItem)AV66FieldValues_Grid.Item(AV90GXV12));
            if ( StringUtil.StrCmp(AV56FieldValue_Grid.gxTpr_Name, "Name") == 0 )
            {
               AV61S_Name = AV56FieldValue_Grid.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV61S_Name", AV61S_Name);
            }
            else if ( StringUtil.StrCmp(AV56FieldValue_Grid.gxTpr_Name, "Id") == 0 )
            {
               AV62S_Id = (long)(Math.Round(NumberUtil.Val( AV56FieldValue_Grid.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV62S_Id", StringUtil.LTrimStr( (decimal)(AV62S_Id), 12, 0));
            }
            AV90GXV12 = (int)(AV90GXV12+1);
         }
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV70FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV68K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49FilName)) )
         {
            AV69K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilName";
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Description = edtavFilname_Caption;
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV49FilName;
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.RTrim( context.localUtil.Format( AV49FilName, ""));
            AV68K2BFilterValuesSDT_WebForm.Add(AV69K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No filters are applied";
         ucFiltertagsusercontrol_grid.SendProperty(context, sPrefix, false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV68K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = AV70FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV83Pgmname,  "Filters",  AV68K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item2) ;
            AV70FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item2;
         }
      }

      protected void S192( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void E143Y2( )
      {
         /* 'Add(MultipleSelection)' Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV58SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV91GXV13 = 1;
         while ( AV91GXV13 <= AV57AllSelectedItems_Grid.Count )
         {
            AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV91GXV13));
            /* Start For Each Line in Grid */
            nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_67_fel_idx = 0;
            while ( nGXsfl_67_fel_idx < nRC_GXsfl_67 )
            {
               nGXsfl_67_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_fel_idx+1);
               sGXsfl_67_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_672( ) ;
               AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
               AV45Name = cgiGet( edtavName_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                  GX_FocusControl = edtavId_Internalname;
                  wbErr = true;
                  AV47Id = 0;
               }
               else
               {
                  AV47Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               }
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  AV58SelectedItems_Grid.Add(AV55SelectedItem_Grid, 0);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               /* End For Each Line */
            }
            if ( nGXsfl_67_fel_idx == 0 )
            {
               nGXsfl_67_idx = 1;
               sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
               SubsflControlProps_672( ) ;
            }
            nGXsfl_67_fel_idx = 1;
            AV91GXV13 = (int)(AV91GXV13+1);
         }
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S292 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S282 ();
         if (returnInSub) return;
         while ( AV41MultiRowHasNext_Grid )
         {
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Name = AV61S_Name;
            AV33MultipleSelectionItem.gxTpr_Id = AV62S_Id;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
         AV93GXV14 = 1;
         while ( AV93GXV14 <= AV57AllSelectedItems_Grid.Count )
         {
            AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV93GXV14));
            /* Start For Each Line in Grid */
            nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_67_fel_idx = 0;
            while ( nGXsfl_67_fel_idx < nRC_GXsfl_67 )
            {
               nGXsfl_67_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_fel_idx+1);
               sGXsfl_67_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_672( ) ;
               AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
               AV45Name = cgiGet( edtavName_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                  GX_FocusControl = edtavId_Internalname;
                  wbErr = true;
                  AV47Id = 0;
               }
               else
               {
                  AV47Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               }
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  AV55SelectedItem_Grid.gxTpr_Isselected = false;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               /* End For Each Line */
            }
            if ( nGXsfl_67_fel_idx == 0 )
            {
               nGXsfl_67_idx = 1;
               sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
               SubsflControlProps_672( ) ;
            }
            nGXsfl_67_fel_idx = 1;
            AV93GXV14 = (int)(AV93GXV14+1);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         /* Execute user subroutine: 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' */
         S222 ();
         if (returnInSub) return;
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV65FilExternalId_PreviousValue, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV83Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV49FilName, AV65FilExternalId_PreviousValue, AV50FilExternalId, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV83Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV58SelectedItems_Grid", AV58SelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66FieldValues_Grid", AV66FieldValues_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      protected void E153Y2( )
      {
         /* 'Remove(MultipleSelection)' Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         /* Start For Each Line in Selectedgrid_multipleselection */
         nRC_GXsfl_91 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_91"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_91_fel_idx = 0;
         while ( nGXsfl_91_fel_idx < nRC_GXsfl_91 )
         {
            nGXsfl_91_fel_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_91_fel_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_fel_idx+1);
            sGXsfl_91_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_913( ) ;
            AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
            AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
               GX_FocusControl = edtavSelected_id_Internalname;
               wbErr = true;
               AV48Selected_Id = 0;
            }
            else
            {
               AV48Selected_Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( AV36SelectedGridMultiRowItemSelected_MultipleSelection )
            {
               AV37SelectedGridLoadCount_MultipleSelection = 0;
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               AV96GXV15 = 1;
               while ( AV96GXV15 <= AV32MultipleSelectionItems.Count )
               {
                  AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV96GXV15));
                  if ( AV48Selected_Id == AV33MultipleSelectionItem.gxTpr_Id )
                  {
                     AV37SelectedGridLoadCount_MultipleSelection = (short)(AV32MultipleSelectionItems.IndexOf(AV33MultipleSelectionItem));
                     AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
                     if (true) break;
                  }
                  AV96GXV15 = (int)(AV96GXV15+1);
               }
               if ( AV37SelectedGridLoadCount_MultipleSelection != 0 )
               {
                  AV32MultipleSelectionItems.RemoveItem(AV37SelectedGridLoadCount_MultipleSelection);
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_91_fel_idx == 0 )
         {
            nGXsfl_91_idx = 1;
            sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
            SubsflControlProps_913( ) ;
         }
         nGXsfl_91_fel_idx = 1;
         AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
         AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         /* Execute user subroutine: 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' */
         S232 ();
         if (returnInSub) return;
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV65FilExternalId_PreviousValue, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV83Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV64FilName_PreviousValue, AV49FilName, AV65FilExternalId_PreviousValue, AV50FilExternalId, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV83Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
      }

      private void E233Y3( )
      {
         /* Selectedgrid_multipleselection_Load Routine */
         returnInSub = false;
         AV53SelectedCheckAll_MultipleSelection = false;
         AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
         if ( ! AV35Reload_MultipleSelection )
         {
            /* Start For Each Line in Selectedgrid_multipleselection */
            nRC_GXsfl_91 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_91"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_91_fel_idx = 0;
            while ( nGXsfl_91_fel_idx < nRC_GXsfl_91 )
            {
               nGXsfl_91_fel_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_91_fel_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_fel_idx+1);
               sGXsfl_91_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_913( ) ;
               AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
               AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
                  GX_FocusControl = edtavSelected_id_Internalname;
                  wbErr = true;
                  AV48Selected_Id = 0;
               }
               else
               {
                  AV48Selected_Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 91;
               }
               sendrow_913( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_91_Refreshing )
               {
                  context.DoAjaxLoad(91, Selectedgrid_multipleselectionRow);
               }
               /* End For Each Line */
            }
            if ( nGXsfl_91_fel_idx == 0 )
            {
               nGXsfl_91_idx = 1;
               sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
               SubsflControlProps_913( ) ;
            }
            nGXsfl_91_fel_idx = 1;
         }
         else
         {
            AV37SelectedGridLoadCount_MultipleSelection = 0;
            AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
            while ( true )
            {
               AV37SelectedGridLoadCount_MultipleSelection = (short)(AV37SelectedGridLoadCount_MultipleSelection+1);
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               if ( AV37SelectedGridLoadCount_MultipleSelection > AV32MultipleSelectionItems.Count )
               {
                  if (true) break;
               }
               AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
               AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
               AV46Selected_Name = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV37SelectedGridLoadCount_MultipleSelection)).gxTpr_Name;
               AssignAttri(sPrefix, false, edtavSelected_name_Internalname, AV46Selected_Name);
               AV48Selected_Id = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV37SelectedGridLoadCount_MultipleSelection)).gxTpr_Id;
               AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
               /* Execute user subroutine: 'U_LOADSELECTEDGRIDROWVARS(MULTIPLESELECTION)' */
               S163 ();
               if (returnInSub) return;
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 91;
               }
               sendrow_913( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_91_Refreshing )
               {
                  context.DoAjaxLoad(91, Selectedgrid_multipleselectionRow);
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_73_3Y2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_73_3Y2e( true) ;
         }
         else
         {
            wb_table1_73_3Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
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
         sCtrlAV7RoleId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\roleselectchildren", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7RoleId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
         }
         wcpOAV7RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7RoleId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV7RoleId != wcpOAV7RoleId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7RoleId = AV7RoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7RoleId = cgiGet( sPrefix+"AV7RoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV7RoleId) > 0 )
         {
            AV7RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7RoleId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
         }
         else
         {
            AV7RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7RoleId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA3Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Y2( ) ;
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
         WS3Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7RoleId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7RoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7RoleId_CTRL", StringUtil.RTrim( sCtrlAV7RoleId));
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
         WE3Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138143353", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("k2bfsg/roleselectchildren.js", "?20243138143356", false, true);
            context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_672( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_67_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_67_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_67_idx;
      }

      protected void SubsflControlProps_fel_672( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_67_fel_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_67_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_67_fel_idx;
      }

      protected void sendrow_672( )
      {
         SubsflControlProps_672( ) ;
         WB3Y0( ) ;
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
            if ( ((int)((nGXsfl_67_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_67_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'"+sPrefix+"',false,'"+sGXsfl_67_idx+"',67)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_67_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_67_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_grid_Internalname,StringUtil.BoolToStr( AV40MultiRowItemSelected_Grid),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'"+sPrefix+"',false,'"+sGXsfl_67_idx+"',67)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV45Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,69);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 70,'"+sPrefix+"',false,'"+sGXsfl_67_idx+"',67)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV47Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV47Id), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,70);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes3Y2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_67_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_idx+1);
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         /* End function sendrow_672 */
      }

      protected void SubsflControlProps_913( )
      {
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_"+sGXsfl_91_idx;
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME_"+sGXsfl_91_idx;
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID_"+sGXsfl_91_idx;
      }

      protected void SubsflControlProps_fel_913( )
      {
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_"+sGXsfl_91_fel_idx;
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME_"+sGXsfl_91_fel_idx;
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID_"+sGXsfl_91_fel_idx;
      }

      protected void sendrow_913( )
      {
         SubsflControlProps_913( ) ;
         WB3Y0( ) ;
         Selectedgrid_multipleselectionRow = GXWebRow.GetNew(context,Selectedgrid_multipleselectionContainer);
         if ( subSelectedgrid_multipleselection_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 0;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
            }
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 0;
            subSelectedgrid_multipleselection_Backcolor = subSelectedgrid_multipleselection_Allbackcolor;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Uniform";
            }
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 1;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
            }
            subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 1;
            if ( ((int)((nGXsfl_91_idx) % (2))) == 0 )
            {
               subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
               {
                  subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Even";
               }
            }
            else
            {
               subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
               {
                  subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
               }
            }
         }
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_91_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavSelectedgridmultirowitemselected_multipleselection.Enabled!=0)&&(chkavSelectedgridmultirowitemselected_multipleselection.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 92,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_" + sGXsfl_91_idx;
         chkavSelectedgridmultirowitemselected_multipleselection.Name = GXCCtl;
         chkavSelectedgridmultirowitemselected_multipleselection.WebTags = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, "TitleCaption", chkavSelectedgridmultirowitemselected_multipleselection.Caption, !bGXsfl_91_Refreshing);
         chkavSelectedgridmultirowitemselected_multipleselection.CheckedValue = "false";
         Selectedgrid_multipleselectionRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelectedgridmultirowitemselected_multipleselection_Internalname,StringUtil.BoolToStr( AV36SelectedGridMultiRowItemSelected_MultipleSelection),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn",(string)"",TempTags+((chkavSelectedgridmultirowitemselected_multipleselection.Enabled!=0)&&(chkavSelectedgridmultirowitemselected_multipleselection.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,92);\"" : " ")});
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSelected_name_Enabled!=0)&&(edtavSelected_name_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 93,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
         ROClassString = "Attribute_Grid";
         Selectedgrid_multipleselectionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelected_name_Internalname,StringUtil.RTrim( AV46Selected_Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSelected_name_Enabled!=0)&&(edtavSelected_name_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,93);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelected_name_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavSelected_name_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavSelected_id_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSelected_id_Enabled!=0)&&(edtavSelected_id_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 94,'"+sPrefix+"',false,'"+sGXsfl_91_idx+"',91)\"" : " ");
         ROClassString = "Attribute_Grid";
         Selectedgrid_multipleselectionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelected_id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48Selected_Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavSelected_id_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48Selected_Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV48Selected_Id), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavSelected_id_Enabled!=0)&&(edtavSelected_id_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,94);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelected_id_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavSelected_id_Visible,(int)edtavSelected_id_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)91,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes3Y3( ) ;
         Selectedgrid_multipleselectionContainer.AddRow(Selectedgrid_multipleselectionRow);
         nGXsfl_91_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_91_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_91_idx+1);
         sGXsfl_91_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_91_idx), 4, 0), 4, "0");
         SubsflControlProps_913( ) ;
         /* End function sendrow_913 */
      }

      protected void init_web_controls( )
      {
         chkavCheckall_grid.Name = "vCHECKALL_GRID";
         chkavCheckall_grid.WebTags = "";
         chkavCheckall_grid.Caption = "";
         AssignProp(sPrefix, false, chkavCheckall_grid_Internalname, "TitleCaption", chkavCheckall_grid.Caption, true);
         chkavCheckall_grid.CheckedValue = "false";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_67_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_67_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         chkavSelectedcheckall_multipleselection.Name = "vSELECTEDCHECKALL_MULTIPLESELECTION";
         chkavSelectedcheckall_multipleselection.WebTags = "";
         chkavSelectedcheckall_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedcheckall_multipleselection_Internalname, "TitleCaption", chkavSelectedcheckall_multipleselection.Caption, true);
         chkavSelectedcheckall_multipleselection.CheckedValue = "false";
         GXCCtl = "vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_" + sGXsfl_91_idx;
         chkavSelectedgridmultirowitemselected_multipleselection.Name = GXCCtl;
         chkavSelectedgridmultirowitemselected_multipleselection.WebTags = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, "TitleCaption", chkavSelectedgridmultirowitemselected_multipleselection.Caption, !bGXsfl_91_Refreshing);
         chkavSelectedgridmultirowitemselected_multipleselection.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl67( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"67\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV40MultiRowItemSelected_Grid)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47Id), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
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

      protected void StartGridControl91( )
      {
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"DivS\" data-gxgridid=\"91\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subSelectedgrid_multipleselection_Internalname, subSelectedgrid_multipleselection_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subSelectedgrid_multipleselection_Backcolorstyle == 0 )
            {
               subSelectedgrid_multipleselection_Titlebackstyle = 0;
               if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
               {
                  subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Title";
               }
            }
            else
            {
               subSelectedgrid_multipleselection_Titlebackstyle = 1;
               if ( subSelectedgrid_multipleselection_Backcolorstyle == 1 )
               {
                  subSelectedgrid_multipleselection_Titlebackcolor = subSelectedgrid_multipleselection_Allbackcolor;
                  if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
                  {
                     subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
                  {
                     subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavSelected_id_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
         }
         else
         {
            Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Header", subSelectedgrid_multipleselection_Header);
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Backcolorstyle), 1, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Sortable), 1, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("CmpContext", sPrefix);
            Selectedgrid_multipleselectionContainer.AddObjectProperty("InMasterPage", "false");
            Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV36SelectedGridMultiRowItemSelected_MultipleSelection)));
            Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
            Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Selected_Name)));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_name_Enabled), 5, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
            Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48Selected_Id), 12, 0, ".", ""))));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_id_Enabled), 5, 0, ".", "")));
            Selectedgrid_multipleselectionColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_id_Visible), 5, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Selectedindex), 4, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowselection), 1, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Selectioncolor), 9, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowhovering), 1, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Hoveringcolor), 9, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowcollapsing), 1, 0, ".", "")));
            Selectedgrid_multipleselectionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         lblLayoutdefined_k2bt_filtercaption_grid_Internalname = sPrefix+"LAYOUTDEFINED_K2BT_FILTERCAPTION_GRID";
         Filtertagsusercontrol_grid_Internalname = sPrefix+"FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table11_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE11_GRID";
         edtavFilname_Internalname = sPrefix+"vFILNAME";
         divTable_container_filname_Internalname = sPrefix+"TABLE_CONTAINER_FILNAME";
         edtavFilexternalid_Internalname = sPrefix+"vFILEXTERNALID";
         divTable_container_filexternalid_Internalname = sPrefix+"TABLE_CONTAINER_FILEXTERNALID";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         divLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         chkavCheckall_grid_Internalname = sPrefix+"vCHECKALL_GRID";
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavId_Internalname = sPrefix+"vID";
         divTablegridcontainer_grid_Internalname = sPrefix+"TABLEGRIDCONTAINER_GRID";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         divGridcontainer_multipleselection_Internalname = sPrefix+"GRIDCONTAINER_MULTIPLESELECTION";
         imgMultipleselection_add_Internalname = sPrefix+"MULTIPLESELECTION_ADD";
         imgMultipleselection_remove_Internalname = sPrefix+"MULTIPLESELECTION_REMOVE";
         divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname = sPrefix+"MULTIPLESELECTIONACTIONSCONTAINERRESPONSIVETABLE_MULTIPLESELECTION";
         edtavXmlitems_multipleselection_Internalname = sPrefix+"vXMLITEMS_MULTIPLESELECTION";
         chkavSelectedcheckall_multipleselection_Internalname = sPrefix+"vSELECTEDCHECKALL_MULTIPLESELECTION";
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION";
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME";
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID";
         divTablegridcontainermultipleselection_multipleselection_Internalname = sPrefix+"TABLEGRIDCONTAINERMULTIPLESELECTION_MULTIPLESELECTION";
         divSelecteditemsresponsivetablecontainer_multipleselection_Internalname = sPrefix+"SELECTEDITEMSRESPONSIVETABLECONTAINER_MULTIPLESELECTION";
         divSelecteduitemsmaintable_multipleselection_Internalname = sPrefix+"SELECTEDUITEMSMAINTABLE_MULTIPLESELECTION";
         divMainmultipleselectionresponsivetable_multipleselection_Internalname = sPrefix+"MAINMULTIPLESELECTIONRESPONSIVETABLE_MULTIPLESELECTION";
         bttConfirm_Internalname = sPrefix+"CONFIRM";
         divActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
         subSelectedgrid_multipleselection_Internalname = sPrefix+"SELECTEDGRID_MULTIPLESELECTION";
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
         subSelectedgrid_multipleselection_Allowcollapsing = 0;
         subSelectedgrid_multipleselection_Allowselection = 0;
         subSelectedgrid_multipleselection_Header = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavSelectedcheckall_multipleselection.Caption = "";
         chkavCheckall_grid.Caption = "";
         edtavSelected_id_Jsonclick = "";
         edtavSelected_id_Enabled = 1;
         edtavSelected_name_Jsonclick = "";
         edtavSelected_name_Visible = -1;
         edtavSelected_name_Enabled = 1;
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Visible = -1;
         chkavSelectedgridmultirowitemselected_multipleselection.Enabled = 1;
         subSelectedgrid_multipleselection_Class = "K2BT_SG Grid_WorkWith";
         subSelectedgrid_multipleselection_Backcolorstyle = 0;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavId_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         edtavName_Enabled = 1;
         chkavMultirowitemselected_grid.Caption = "";
         chkavMultirowitemselected_grid.Visible = -1;
         chkavMultirowitemselected_grid.Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         edtavSelected_id_Visible = 0;
         subSelectedgrid_multipleselection_Sortable = 0;
         subGrid_Sortable = 0;
         chkavSelectedcheckall_multipleselection.Enabled = 1;
         edtavXmlitems_multipleselection_Jsonclick = "";
         edtavXmlitems_multipleselection_Enabled = 1;
         edtavXmlitems_multipleselection_Visible = 1;
         chkavCheckall_grid.Enabled = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavFilexternalid_Jsonclick = "";
         edtavFilexternalid_Enabled = 1;
         divTable_container_filexternalid_Visible = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         edtavFilname_Caption = "Name";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'sPrefix'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.LOAD","{handler:'E233Y3',iparms:[{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''}]");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.LOAD",",oparms:[{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV46Selected_Name',fld:'vSELECTED_NAME',pic:''},{av:'AV48Selected_Id',fld:'vSELECTED_ID',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E123Y2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'sPrefix'},{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E203Y2',iparms:[{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV45Name',fld:'vNAME',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''}]}");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.DROP","{handler:'E163Y2',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV45Name',fld:'vNAME',pic:''}]");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.DROP",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("GRID.DROP","{handler:'E173Y2',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV48Selected_Id',fld:'vSELECTED_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'}]");
         setEventMetadata("GRID.DROP",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E213Y2',iparms:[{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'edtavFilname_Caption',ctrl:'vFILNAME',prop:'Caption'},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV70FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK","{handler:'E223Y2',iparms:[{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV47Id',fld:'vID',grid:67,pic:'ZZZZZZZZZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_67',ctrl:'GRID',grid:67,prop:'GridRC',grid:67},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:67,pic:''},{av:'AV45Name',fld:'vNAME',grid:67,pic:''}]");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK",",oparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''}]}");
         setEventMetadata("VCHECKALL_GRID.CLICK","{handler:'E133Y2',iparms:[{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:67,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_67',ctrl:'GRID',grid:67,prop:'GridRC',grid:67},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV47Id',fld:'vID',grid:67,pic:'ZZZZZZZZZZZ9'},{av:'AV45Name',fld:'vNAME',grid:67,pic:''}]");
         setEventMetadata("VCHECKALL_GRID.CLICK",",oparms:[{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E113Y1',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]}");
         setEventMetadata("'ADD(MULTIPLESELECTION)'","{handler:'E143Y2',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',grid:67,pic:'ZZZZZZZZZZZ9'},{av:'nRC_GXsfl_67',ctrl:'GRID',grid:67,prop:'GridRC',grid:67},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV41MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV61S_Name',fld:'vS_NAME',pic:''},{av:'AV62S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV58SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV66FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''}]");
         setEventMetadata("'ADD(MULTIPLESELECTION)'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV58SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV61S_Name',fld:'vS_NAME',pic:''},{av:'AV62S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV66FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV41MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("'REMOVE(MULTIPLESELECTION)'","{handler:'E153Y2',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',grid:91,pic:''},{av:'nRC_GXsfl_91',ctrl:'SELECTEDGRID_MULTIPLESELECTION',grid:91,prop:'GridRC',grid:91},{av:'AV48Selected_Id',fld:'vSELECTED_ID',grid:91,pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'REMOVE(MULTIPLESELECTION)'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV64FilName_PreviousValue',fld:'vFILNAME_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV65FilExternalId_PreviousValue',fld:'vFILEXTERNALID_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Id',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Selected_id',iparms:[]");
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
         AV64FilName_PreviousValue = "";
         AV65FilExternalId_PreviousValue = "";
         AV34XMLItems_MultipleSelection = "";
         AV72ClassCollection_Grid = new GxSimpleCollection<string>();
         AV49FilName = "";
         AV83Pgmname = "";
         AV50FilExternalId = "";
         AV57AllSelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV32MultipleSelectionItems = new GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem>( context, "RolesSDTItem", "test");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV70FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV71DeletedTag_Grid = "";
         AV61S_Name = "";
         AV58SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV66FieldValues_Grid = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "test");
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick = "";
         lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         imgMultipleselection_add_gximage = "";
         imgMultipleselection_add_Jsonclick = "";
         imgMultipleselection_remove_gximage = "";
         imgMultipleselection_remove_Jsonclick = "";
         Selectedgrid_multipleselectionContainer = new GXWebGrid( context);
         bttConfirm_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV45Name = "";
         AV46Selected_Name = "";
         AV6GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV5ChildRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV9Filter = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10RoleAux = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
         AV24HttpRequest = new GxHttpRequest( context);
         AV52RoleName = "";
         AV17item = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV16Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV55SelectedItem_Grid = new SdtK2BSelectionItem(context);
         GridRow = new GXWebRow();
         AV11CandidateRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV26GridStateKey = "";
         AV27GridState = new SdtK2BGridState(context);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         GXt_char1 = "";
         AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
         AV68K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV69K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         Selectedgrid_multipleselectionRow = new GXWebRow();
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7RoleId = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         subSelectedgrid_multipleselection_Linesclass = "";
         GridColumn = new GXWebColumn();
         Selectedgrid_multipleselectionColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__default(),
            new Object[][] {
            }
         );
         AV83Pgmname = "K2BFSG.RoleSelectChildren";
         /* GeneXus formulas. */
         AV83Pgmname = "K2BFSG.RoleSelectChildren";
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         edtavSelected_name_Enabled = 0;
         edtavSelected_id_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV38CurrentPage_Grid ;
      private short AV60Grid_SelectedRows ;
      private short AV43I_LoadCount_Grid ;
      private short AV19I_LoadCount_Skip ;
      private short initialized ;
      private short nGXWrapped ;
      private short AV37SelectedGridLoadCount_MultipleSelection ;
      private short AV42MultiRowIterator_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short subSelectedgrid_multipleselection_Backcolorstyle ;
      private short subSelectedgrid_multipleselection_Sortable ;
      private short GRID_nEOF ;
      private short SELECTEDGRID_MULTIPLESELECTION_nEOF ;
      private short AV13i ;
      private short AV59Index_Grid ;
      private short subGrid_Backstyle ;
      private short subSelectedgrid_multipleselection_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subSelectedgrid_multipleselection_Titlebackstyle ;
      private short subSelectedgrid_multipleselection_Allowselection ;
      private short subSelectedgrid_multipleselection_Allowhovering ;
      private short subSelectedgrid_multipleselection_Allowcollapsing ;
      private short subSelectedgrid_multipleselection_Collapsed ;
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_67 ;
      private int nRC_GXsfl_91 ;
      private int subGrid_Recordcount ;
      private int subSelectedgrid_multipleselection_Recordcount ;
      private int nGXsfl_67_idx=1 ;
      private int nGXsfl_91_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavId_Enabled ;
      private int edtavSelected_name_Enabled ;
      private int edtavSelected_id_Enabled ;
      private int edtavFilname_Enabled ;
      private int divTable_container_filexternalid_Visible ;
      private int edtavFilexternalid_Enabled ;
      private int edtavXmlitems_multipleselection_Visible ;
      private int edtavXmlitems_multipleselection_Enabled ;
      private int subGrid_Islastpage ;
      private int subSelectedgrid_multipleselection_Islastpage ;
      private int AV73GXV1 ;
      private int edtavSelected_id_Visible ;
      private int AV75GXV2 ;
      private int AV76GXV3 ;
      private int AV77GXV4 ;
      private int AV78GXV5 ;
      private int AV79GXV6 ;
      private int AV80GXV7 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV81GXV8 ;
      private int AV82GXV9 ;
      private int AV84GXV10 ;
      private int AV85GXV11 ;
      private int nGXsfl_67_fel_idx=1 ;
      private int AV90GXV12 ;
      private int AV91GXV13 ;
      private int AV93GXV14 ;
      private int nGXsfl_91_fel_idx=1 ;
      private int AV96GXV15 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavId_Visible ;
      private int subSelectedgrid_multipleselection_Backcolor ;
      private int subSelectedgrid_multipleselection_Allbackcolor ;
      private int edtavSelected_name_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subSelectedgrid_multipleselection_Titlebackcolor ;
      private int subSelectedgrid_multipleselection_Selectedindex ;
      private int subSelectedgrid_multipleselection_Selectioncolor ;
      private int subSelectedgrid_multipleselection_Hoveringcolor ;
      private long AV7RoleId ;
      private long wcpOAV7RoleId ;
      private long AV47Id ;
      private long AV62S_Id ;
      private long AV48Selected_Id ;
      private long GRID_nCurrentRecord ;
      private long SELECTEDGRID_MULTIPLESELECTION_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private long SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage ;
      private string edtavFilname_Caption ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_67_idx="0001" ;
      private string AV64FilName_PreviousValue ;
      private string AV65FilExternalId_PreviousValue ;
      private string AV34XMLItems_MultipleSelection ;
      private string AV49FilName ;
      private string AV83Pgmname ;
      private string AV50FilExternalId ;
      private string sGXsfl_91_idx="0001" ;
      private string edtavName_Internalname ;
      private string edtavId_Internalname ;
      private string edtavSelected_name_Internalname ;
      private string edtavSelected_id_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV71DeletedTag_Grid ;
      private string AV61S_Name ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divMainmultipleselectionresponsivetable_multipleselection_Internalname ;
      private string divGridcontainer_multipleselection_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filtercontainersection_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlydetailedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_table11_grid_Internalname ;
      private string TempTags ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick ;
      private string lblLayoutdefined_k2bt_filtercaption_grid_Internalname ;
      private string lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_filname_Internalname ;
      private string edtavFilname_Internalname ;
      private string edtavFilname_Jsonclick ;
      private string divTable_container_filexternalid_Internalname ;
      private string edtavFilexternalid_Internalname ;
      private string edtavFilexternalid_Jsonclick ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divTablegridcontainer_grid_Internalname ;
      private string chkavCheckall_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname ;
      private string imgMultipleselection_add_gximage ;
      private string imgMultipleselection_add_Internalname ;
      private string imgMultipleselection_add_Jsonclick ;
      private string imgMultipleselection_remove_gximage ;
      private string imgMultipleselection_remove_Internalname ;
      private string imgMultipleselection_remove_Jsonclick ;
      private string divSelecteduitemsmaintable_multipleselection_Internalname ;
      private string edtavXmlitems_multipleselection_Internalname ;
      private string edtavXmlitems_multipleselection_Jsonclick ;
      private string divSelecteditemsresponsivetablecontainer_multipleselection_Internalname ;
      private string divTablegridcontainermultipleselection_multipleselection_Internalname ;
      private string chkavSelectedcheckall_multipleselection_Internalname ;
      private string subSelectedgrid_multipleselection_Internalname ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string divActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_grid_Internalname ;
      private string AV45Name ;
      private string chkavSelectedgridmultirowitemselected_multipleselection_Internalname ;
      private string AV46Selected_Name ;
      private string AV52RoleName ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string sGXsfl_67_fel_idx="0001" ;
      private string GXt_char1 ;
      private string sGXsfl_91_fel_idx="0001" ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlAV7RoleId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string subSelectedgrid_multipleselection_Class ;
      private string subSelectedgrid_multipleselection_Linesclass ;
      private string edtavSelected_name_Jsonclick ;
      private string edtavSelected_id_Jsonclick ;
      private string subGrid_Header ;
      private string subSelectedgrid_multipleselection_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV31InCollection ;
      private bool AV54CheckAll_Grid ;
      private bool AV53SelectedCheckAll_MultipleSelection ;
      private bool AV35Reload_MultipleSelection ;
      private bool bGXsfl_67_Refreshing=false ;
      private bool bGXsfl_91_Refreshing=false ;
      private bool AV41MultiRowHasNext_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV40MultiRowItemSelected_Grid ;
      private bool AV36SelectedGridMultiRowItemSelected_MultipleSelection ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV39Reload_Grid ;
      private bool AV51isOK ;
      private bool AV18Found ;
      private bool AV44Exit_Grid ;
      private bool AV14FoundItem ;
      private string AV26GridStateKey ;
      private GXWebGrid GridContainer ;
      private GXWebGrid Selectedgrid_multipleselectionContainer ;
      private GXWebRow GridRow ;
      private GXWebRow Selectedgrid_multipleselectionRow ;
      private GXWebColumn GridColumn ;
      private GXWebColumn Selectedgrid_multipleselectionColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_RoleId ;
      private GXCheckbox chkavCheckall_grid ;
      private GXCheckbox chkavMultirowitemselected_grid ;
      private GXCheckbox chkavSelectedcheckall_multipleselection ;
      private GXCheckbox chkavSelectedgridmultirowitemselected_multipleselection ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GxSimpleCollection<string> AV72ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV5ChildRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV11CandidateRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ;
      private GXBaseCollection<SdtK2BSelectionItem> AV57AllSelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem> AV58SelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV66FieldValues_Grid ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV68K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV70FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV6GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10RoleAux ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV17item ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV16Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV9Filter ;
      private GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem AV33MultipleSelectionItem ;
      private SdtK2BGridState AV27GridState ;
      private SdtK2BGridState_FilterValue AV28GridStateFilterValue ;
      private SdtK2BSelectionItem AV55SelectedItem_Grid ;
      private SdtK2BSelectionItem_FieldValuesItem AV56FieldValue_Grid ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV69K2BFilterValuesSDTItem_WebForm ;
   }

   public class roleselectchildren__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class roleselectchildren__default : DataStoreHelperBase, IDataStoreHelper
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
