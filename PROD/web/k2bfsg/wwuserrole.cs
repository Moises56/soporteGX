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
   public class wwuserrole : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwuserrole( )
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

      public wwuserrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_UserId )
      {
         this.AV17UserId = aP0_UserId;
         executePrivate();
         aP0_UserId=this.AV17UserId;
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
         chkavDisplayinheritroles = new GXCheckbox();
         chkavCheckall_grid = new GXCheckbox();
         chkavMultirowitemselected_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "UserId");
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
                  AV17UserId = GetPar( "UserId");
                  AssignAttri(sPrefix, false, "AV17UserId", AV17UserId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV17UserId});
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
                  gxfirstwebparm = GetFirstPar( "UserId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UserId");
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
                  AV17UserId = gxfirstwebparm;
                  AssignAttri(sPrefix, false, "AV17UserId", AV17UserId);
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
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
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
         AV38DisplayInheritRoles_PreviousValue = StringUtil.StrToBool( GetPar( "DisplayInheritRoles_PreviousValue"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV54AllSelectedItems_Grid);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV49ClassCollection_Grid);
         AV37DisplayInheritRoles = StringUtil.StrToBool( GetPar( "DisplayInheritRoles"));
         AV67Pgmname = GetPar( "Pgmname");
         AV29CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV57CountSelectedItems_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CountSelectedItems_Grid"), "."), 18, MidpointRounding.ToEven));
         AV63HasNextPage_Grid = StringUtil.StrToBool( GetPar( "HasNextPage_Grid"));
         AV18isDirectRole = StringUtil.StrToBool( GetPar( "isDirectRole"));
         AV36Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
         AV58Grid_SelectedRows = (short)(Math.Round(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."), 18, MidpointRounding.ToEven));
         AV17UserId = GetPar( "UserId");
         AV31I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV50CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV38DisplayInheritRoles_PreviousValue, AV54AllSelectedItems_Grid, AV49ClassCollection_Grid, AV37DisplayInheritRoles, AV67Pgmname, AV29CurrentPage_Grid, AV57CountSelectedItems_Grid, AV63HasNextPage_Grid, AV18isDirectRole, AV36Id, AV58Grid_SelectedRows, AV17UserId, AV31I_LoadCount_Grid, AV50CheckAll_Grid, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA422( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV67Pgmname = "K2BFSG.WWUserRole";
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavGuid_Enabled = 0;
               AssignProp(sPrefix, false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavMainrole_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavMainrole_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMainrole_action_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               WS422( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     WE422( ) ;
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
            context.SendWebValue( "User roles") ;
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.wwuserrole.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17UserId))}, new string[] {"UserId"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISDIRECTROLE", AV18isDirectRole);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISDIRECTROLE", GetSecureSignedToken( sPrefix, AV18isDirectRole, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV63HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV63HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDISPLAYINHERITROLES_PREVIOUSVALUE", AV38DisplayInheritRoles_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISPLAYINHERITROLES_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, AV38DisplayInheritRoles_PreviousValue, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV43FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV43FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG_GRID", StringUtil.RTrim( AV44DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV17UserId", StringUtil.RTrim( wcpOAV17UserId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERID", StringUtil.RTrim( AV17UserId));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISDIRECTROLE", AV18isDirectRole);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISDIRECTROLE", GetSecureSignedToken( sPrefix, AV18isDirectRole, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29CurrentPage_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLSELECTEDITEMS_GRID", AV54AllSelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLSELECTEDITEMS_GRID", AV54AllSelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV63HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV63HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDISPLAYINHERITROLES_PREVIOUSVALUE", AV38DisplayInheritRoles_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISPLAYINHERITROLES_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, AV38DisplayInheritRoles_PreviousValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV49ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV49ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOUNTSELECTEDITEMS_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57CountSelectedItems_Grid), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vMULTIROWHASNEXT_GRID", AV47MultiRowHasNext_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMULTIROWITERATOR_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48MultiRowIterator_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDITEMS_GRID", AV55SelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDITEMS_GRID", AV55SelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61S_Id), 12, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFIELDVALUES_GRID", AV53FieldValues_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFIELDVALUES_GRID", AV53FieldValues_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Title", StringUtil.RTrim( Gridcomponent_grid_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Collapsible", StringUtil.BoolToStr( Gridcomponent_grid_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Open", StringUtil.BoolToStr( Gridcomponent_grid_Open));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Showborders", StringUtil.BoolToStr( Gridcomponent_grid_Showborders));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENT_GRID_Containseditableform", StringUtil.BoolToStr( Gridcomponent_grid_Containseditableform));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDISPLAYINHERITROLES_Caption", StringUtil.RTrim( chkavDisplayinheritroles.Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDISPLAYINHERITROLES_Caption", StringUtil.RTrim( chkavDisplayinheritroles.Caption));
      }

      protected void RenderHtmlCloseForm422( )
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
         return "K2BFSG.WWUserRole" ;
      }

      public override string GetPgmdesc( )
      {
         return "User roles" ;
      }

      protected void WB420( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.wwuserrole.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton" + " " + ((StringUtil.StrCmp(imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage, "")==0) ? "GX_Image_K2BT_Filters_Class" : "GX_Image_"+imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1de3a117-b285-46fd-b5f1-8befd508af22", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11421_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWUserRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_k2bt_filtercaption_grid_Internalname, "Filters", "", "", lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BT_FilterToggleText", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV43FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV44DeletedTag_Grid);
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
            GxWebStd.gx_div_start( context, divTable_container_displayinheritroles_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+chkavDisplayinheritroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDisplayinheritroles_Internalname, "Display inherit role", "gx-form-item AttributeLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDisplayinheritroles_Internalname, StringUtil.BoolToStr( AV37DisplayInheritRoles), "", "Display inherit role", 1, chkavDisplayinheritroles.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_topright_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(76), 2, 0)+","+"null"+");", "Add new", bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\WWUserRole.htm");
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_grid_gridassociatedleft_Internalname, 1, 0, "px", 0, "px", "Table_ActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(imgMultipledelete_gximage, "")==0) ? "GX_Image_K2BActionDelete_Class" : "GX_Image_"+imgMultipledelete_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgMultipledelete_Bitmap;
            GxWebStd.gx_bitmap( context, imgMultipledelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgMultipledelete_Visible, 1, "Multiple Delete", imgMultipledelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgMultipledelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_MULTIPLEDELETE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\WWUserRole.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_grid_Internalname, StringUtil.BoolToStr( AV50CheckAll_Grid), "", "", 1, chkavCheckall_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,75);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl76( ) ;
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
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
            wb_table1_85_422( true) ;
         }
         else
         {
            wb_table1_85_422( false) ;
         }
         return  ;
      }

      protected void wb_table1_85_422e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e12421_client"+"'", "", lblPaginationbar_previouspagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockgrid_Internalname, lblPaginationbar_firstpagetextblockgrid_Caption, "", "", lblPaginationbar_firstpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e13421_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockgrid_Internalname, lblPaginationbar_previouspagetextblockgrid_Caption, "", "", lblPaginationbar_previouspagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e12421_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockgrid_Internalname, lblPaginationbar_currentpagetextblockgrid_Caption, "", "", lblPaginationbar_currentpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockgrid_Internalname, lblPaginationbar_nextpagetextblockgrid_Caption, "", "", lblPaginationbar_nextpagetextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e14421_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockgrid_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockgrid_Visible, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e14421_client"+"'", "", lblPaginationbar_nextpagebuttontextblockgrid_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
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
         if ( wbEnd == 76 )
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

      protected void START422( )
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
            Form.Meta.addItem("description", "User roles", 0) ;
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
               STRUP420( ) ;
            }
         }
      }

      protected void WS422( )
      {
         START422( ) ;
         EVT422( ) ;
      }

      protected void EVT422( )
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
                                 STRUP420( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E15422 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCHECKALL_GRID.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E16422 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_MULTIPLEDELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_MultipleDelete' */
                                    E17422 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'E_MAINROLE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'E_MAINROLE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP420( ) ;
                              }
                              nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_762( ) ;
                              AV46MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
                              AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV46MultiRowItemSelected_Grid);
                              AV34Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV34Name);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), context));
                              AV35GUID = cgiGet( edtavGuid_Internalname);
                              AssignAttri(sPrefix, false, edtavGuid_Internalname, AV35GUID);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGUID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV35GUID, "")), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                                 GX_FocusControl = edtavId_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV36Id = 0;
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV36Id), 12, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV36Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV36Id), 12, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
                              }
                              AV33MainRole_Action = cgiGet( edtavMainrole_action_Internalname);
                              AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
                              AV41Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete_Action)) ? AV69Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV41Delete_Action))), !bGXsfl_76_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV41Delete_Action), true);
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
                                          E18422 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Delete' */
                                          E19422 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_MAINROLE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_MainRole' */
                                          E20422 ();
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
                                          E21422 ();
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
                                          E22422 ();
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
                                          E23422 ();
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
                                          E24422 ();
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
                                       STRUP420( ) ;
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

      protected void WE422( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm422( ) ;
            }
         }
      }

      protected void PA422( )
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
               GX_FocusControl = chkavDisplayinheritroles_Internalname;
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
         SubsflControlProps_762( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_762( ) ;
            nGXsfl_76_idx = ((subGrid_Islastpage==1)&&(nGXsfl_76_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( bool AV38DisplayInheritRoles_PreviousValue ,
                                       GXBaseCollection<SdtK2BSelectionItem> AV54AllSelectedItems_Grid ,
                                       GxSimpleCollection<string> AV49ClassCollection_Grid ,
                                       bool AV37DisplayInheritRoles ,
                                       string AV67Pgmname ,
                                       short AV29CurrentPage_Grid ,
                                       short AV57CountSelectedItems_Grid ,
                                       bool AV63HasNextPage_Grid ,
                                       bool AV18isDirectRole ,
                                       long AV36Id ,
                                       short AV58Grid_SelectedRows ,
                                       string AV17UserId ,
                                       short AV31I_LoadCount_Grid ,
                                       bool AV50CheckAll_Grid ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF422( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME", StringUtil.RTrim( AV34Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGUID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35GUID, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGUID", StringUtil.RTrim( AV35GUID));
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
         AV37DisplayInheritRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV37DisplayInheritRoles));
         AssignAttri(sPrefix, false, "AV37DisplayInheritRoles", AV37DisplayInheritRoles);
         AV50CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV50CheckAll_Grid));
         AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E22422 ();
         RF422( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV67Pgmname = "K2BFSG.WWUserRole";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp(sPrefix, false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavMainrole_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavMainrole_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMainrole_action_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void RF422( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 76;
         /* Execute user event: Refresh */
         E22422 ();
         E23422 ();
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         bGXsfl_76_Refreshing = true;
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
            SubsflControlProps_762( ) ;
            E21422 ();
            wbEnd = 76;
            WB420( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes422( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISDIRECTROLE", AV18isDirectRole);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISDIRECTROLE", GetSecureSignedToken( sPrefix, AV18isDirectRole, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_GRID", AV63HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV63HasNextPage_Grid, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDISPLAYINHERITROLES_PREVIOUSVALUE", AV38DisplayInheritRoles_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISPLAYINHERITROLES_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, AV38DisplayInheritRoles_PreviousValue, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGUID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV35GUID, "")), context));
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
         AV67Pgmname = "K2BFSG.WWUserRole";
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp(sPrefix, false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavMainrole_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavMainrole_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMainrole_action_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP420( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18422 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGSCOLLECTION_GRID"), AV43FilterTagsCollection_Grid);
            /* Read saved values. */
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
            AV44DeletedTag_Grid = cgiGet( sPrefix+"vDELETEDTAG_GRID");
            wcpOAV17UserId = cgiGet( sPrefix+"wcpOAV17UserId");
            AV29CurrentPage_Grid = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_GRID"), ".", ","), 18, MidpointRounding.ToEven));
            AV63HasNextPage_Grid = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_GRID"));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            Gridcomponent_grid_Title = cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Title");
            Gridcomponent_grid_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Collapsible"));
            Gridcomponent_grid_Open = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Open"));
            Gridcomponent_grid_Showborders = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Showborders"));
            Gridcomponent_grid_Containseditableform = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDCOMPONENT_GRID_Containseditableform"));
            chkavDisplayinheritroles.Caption = cgiGet( sPrefix+"vDISPLAYINHERITROLES_Caption");
            /* Read variables values. */
            AV37DisplayInheritRoles = StringUtil.StrToBool( cgiGet( chkavDisplayinheritroles_Internalname));
            AssignAttri(sPrefix, false, "AV37DisplayInheritRoles", AV37DisplayInheritRoles);
            AV50CheckAll_Grid = StringUtil.StrToBool( cgiGet( chkavCheckall_grid_Internalname));
            AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
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
      }

      protected void S202( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV42Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV42Messages = GXt_objcol_SdtMessages_Message1;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV42Messages.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV42Messages.Item(AV66GXV1));
            GX_msglist.addItem(AV20Message.gxTpr_Description);
            AV66GXV1 = (int)(AV66GXV1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E18422 ();
         if (returnInSub) return;
      }

      protected void E18422( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV67Pgmname,  "Grid", out  AV64RowsPerPage_Grid, out  AV65RowsPerPageLoaded_Grid) ;
         if ( ! AV65RowsPerPageLoaded_Grid )
         {
            AV64RowsPerPage_Grid = 10;
         }
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV38DisplayInheritRoles_PreviousValue = AV37DisplayInheritRoles;
         AssignAttri(sPrefix, false, "AV38DisplayInheritRoles_PreviousValue", AV38DisplayInheritRoles_PreviousValue);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISPLAYINHERITROLES_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, AV38DisplayInheritRoles_PreviousValue, context));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
      }

      protected void S222( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      protected void S342( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         if ( AV6Errors.Count > 0 )
         {
            AV68GXV2 = 1;
            while ( AV68GXV2 <= AV6Errors.Count )
            {
               AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV6Errors.Item(AV68GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV5Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV5Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV68GXV2 = (int)(AV68GXV2+1);
            }
         }
      }

      protected void S142( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV16isOK = false;
         AV11GAMUser.load( AV17UserId);
         AV16isOK = AV11GAMUser.deleterolebyid(AV36Id, out  AV6Errors);
         if ( AV16isOK )
         {
            context.CommitDataStores("k2bfsg.wwuserrole",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S342 ();
            if (returnInSub) return;
         }
         if ( AV16isOK )
         {
            GX_msglist.addItem("Role was succesffully deleted");
            gxgrGrid_refresh( AV38DisplayInheritRoles_PreviousValue, AV54AllSelectedItems_Grid, AV49ClassCollection_Grid, AV37DisplayInheritRoles, AV67Pgmname, AV29CurrentPage_Grid, AV57CountSelectedItems_Grid, AV63HasNextPage_Grid, AV18isDirectRole, AV36Id, AV58Grid_SelectedRows, AV17UserId, AV31I_LoadCount_Grid, AV50CheckAll_Grid, sPrefix) ;
         }
      }

      protected void E19422( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
      }

      protected void S152( )
      {
         /* 'U_MAINROLE' Routine */
         returnInSub = false;
         AV11GAMUser.load( AV17UserId);
         AV16isOK = AV11GAMUser.setmainrolebyid(AV36Id, out  AV6Errors);
         if ( AV16isOK )
         {
            context.CommitDataStores("k2bfsg.wwuserrole",pr_default);
            GX_msglist.addItem("Role was successfully set as main");
            gxgrGrid_refresh( AV38DisplayInheritRoles_PreviousValue, AV54AllSelectedItems_Grid, AV49ClassCollection_Grid, AV37DisplayInheritRoles, AV67Pgmname, AV29CurrentPage_Grid, AV57CountSelectedItems_Grid, AV63HasNextPage_Grid, AV18isDirectRole, AV36Id, AV58Grid_SelectedRows, AV17UserId, AV31I_LoadCount_Grid, AV50CheckAll_Grid, sPrefix) ;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S342 ();
            if (returnInSub) return;
         }
      }

      protected void E20422( )
      {
         /* 'E_MainRole' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MAINROLE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
      }

      private void E21422( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV31I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV31I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV31I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31I_LoadCount_Grid), "ZZZ9"), context));
         AV63HasNextPage_Grid = false;
         AssignAttri(sPrefix, false, "AV63HasNextPage_Grid", AV63HasNextPage_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV63HasNextPage_Grid, context));
         AV32Exit_Grid = false;
         while ( true )
         {
            AV31I_LoadCount_Grid = (short)(AV31I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV31I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV31I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S162 ();
            if (returnInSub) return;
            AV33MainRole_Action = "Set as main";
            AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
            if ( ! AV18isDirectRole )
            {
               edtavDelete_action_gximage = "K2BActionDelete";
               AV41Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV41Delete_Action);
               AV69Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 1;
               edtavDelete_action_Tooltiptext = "Delete";
            }
            else
            {
               edtavDelete_action_gximage = "K2BActionDelete";
               AV41Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
               AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV41Delete_Action);
               AV69Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
               edtavDelete_action_Enabled = 0;
               edtavDelete_action_Tooltiptext = "";
            }
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S172 ();
            if (returnInSub) return;
            if ( AV32Exit_Grid )
            {
               if (true) break;
            }
            if ( AV31I_LoadCount_Grid > 10 * AV29CurrentPage_Grid )
            {
               AV63HasNextPage_Grid = true;
               AssignAttri(sPrefix, false, "AV63HasNextPage_Grid", AV63HasNextPage_Grid);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_GRID", GetSecureSignedToken( sPrefix, AV63HasNextPage_Grid, context));
               if (true) break;
            }
            if ( AV31I_LoadCount_Grid > 10 * ( AV29CurrentPage_Grid - 1 ) )
            {
               tblI_noresultsfoundtablename_grid_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
               AV46MultiRowItemSelected_Grid = false;
               AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV46MultiRowItemSelected_Grid);
               AV70GXV3 = 1;
               while ( AV70GXV3 <= AV54AllSelectedItems_Grid.Count )
               {
                  AV51SelectedItem_Grid = ((SdtK2BSelectionItem)AV54AllSelectedItems_Grid.Item(AV70GXV3));
                  if ( AV51SelectedItem_Grid.gxTpr_Sknumeric1 == AV36Id )
                  {
                     if ( AV51SelectedItem_Grid.gxTpr_Isselected )
                     {
                        AV46MultiRowItemSelected_Grid = true;
                        AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV46MultiRowItemSelected_Grid);
                        AV58Grid_SelectedRows = (short)(AV58Grid_SelectedRows+1);
                        AssignAttri(sPrefix, false, "AV58Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV58Grid_SelectedRows), 4, 0));
                     }
                     if (true) break;
                  }
                  AV70GXV3 = (int)(AV70GXV3+1);
               }
               if ( ((int)((AV31I_LoadCount_Grid) % (10))) == 1 )
               {
                  AV50CheckAll_Grid = true;
                  AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
               }
               if ( ! AV46MultiRowItemSelected_Grid )
               {
                  AV50CheckAll_Grid = false;
                  AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 76;
               }
               sendrow_762( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
               {
                  context.DoAjaxLoad(76, GridRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         AV11GAMUser.load( AV17UserId);
         if ( ! AV37DisplayInheritRoles )
         {
            if ( AV31I_LoadCount_Grid == 1 )
            {
               AV13Roles = AV11GAMUser.getroles(out  AV6Errors);
               AV13Roles.Sort("Description");
            }
            if ( AV13Roles.Count >= AV31I_LoadCount_Grid )
            {
               AV8GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV13Roles.Item(AV31I_LoadCount_Grid));
               if ( AV8GAMRole.gxTpr_Id == AV11GAMUser.gxTpr_Defaultroleid )
               {
                  AV33MainRole_Action = "";
                  AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
               }
               else
               {
                  AV33MainRole_Action = "Set main";
                  AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
               }
               AV35GUID = AV8GAMRole.gxTpr_Guid;
               AssignAttri(sPrefix, false, edtavGuid_Internalname, AV35GUID);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGUID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV35GUID, "")), context));
               AV36Id = AV8GAMRole.gxTpr_Id;
               AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV36Id), 12, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
               AV34Name = AV8GAMRole.gxTpr_Name;
               AssignAttri(sPrefix, false, edtavName_Internalname, AV34Name);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), context));
               edtavName_Link = formatLink("k2bfsg.entryrole.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(AV36Id,12,0))}, new string[] {"Mode","Id"}) ;
               AssignProp(sPrefix, false, edtavName_Internalname, "Link", edtavName_Link, !bGXsfl_76_Refreshing);
            }
            else
            {
               AV32Exit_Grid = true;
            }
         }
         else
         {
            if ( AV31I_LoadCount_Grid == 1 )
            {
               AV10GAMRolesDirect = AV11GAMUser.getroles(out  AV6Errors);
               if ( AV10GAMRolesDirect.Count > 0 )
               {
                  AV13Roles = AV11GAMUser.getallroles(out  AV6Errors);
               }
               AV13Roles.Sort("Description");
            }
            if ( AV10GAMRolesDirect.Count >= AV31I_LoadCount_Grid )
            {
               AV8GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV13Roles.Item(AV31I_LoadCount_Grid));
               AV18isDirectRole = false;
               AssignAttri(sPrefix, false, "AV18isDirectRole", AV18isDirectRole);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISDIRECTROLE", GetSecureSignedToken( sPrefix, AV18isDirectRole, context));
               AV71GXV4 = 1;
               while ( AV71GXV4 <= AV10GAMRolesDirect.Count )
               {
                  AV9GAMRoleAux = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV10GAMRolesDirect.Item(AV71GXV4));
                  if ( AV8GAMRole.gxTpr_Id == AV9GAMRoleAux.gxTpr_Id )
                  {
                     AV18isDirectRole = true;
                     AssignAttri(sPrefix, false, "AV18isDirectRole", AV18isDirectRole);
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISDIRECTROLE", GetSecureSignedToken( sPrefix, AV18isDirectRole, context));
                     if (true) break;
                  }
                  AV71GXV4 = (int)(AV71GXV4+1);
               }
               if ( AV18isDirectRole )
               {
                  if ( AV8GAMRole.gxTpr_Id == AV11GAMUser.gxTpr_Defaultroleid )
                  {
                     AV33MainRole_Action = "";
                     AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
                  }
                  else
                  {
                     AV33MainRole_Action = "Set main";
                     AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
                  }
               }
               else
               {
                  AV33MainRole_Action = "";
                  AssignAttri(sPrefix, false, edtavMainrole_action_Internalname, AV33MainRole_Action);
               }
               AV35GUID = AV12Role.gxTpr_Guid;
               AssignAttri(sPrefix, false, edtavGuid_Internalname, AV35GUID);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGUID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV35GUID, "")), context));
               AV36Id = AV8GAMRole.gxTpr_Id;
               AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV36Id), 12, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9"), context));
               AV34Name = AV8GAMRole.gxTpr_Name;
               AssignAttri(sPrefix, false, edtavName_Internalname, AV34Name);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_76_idx, GetSecureSignedToken( sPrefix+sGXsfl_76_idx, StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), context));
            }
            else
            {
               AV32Exit_Grid = true;
            }
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV24GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV67Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV25GridState.gxTpr_Currentpage = AV29CurrentPage_Grid;
         AV25GridState.gxTpr_Filtervalues.Clear();
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV26GridStateFilterValue.gxTpr_Filtername = "DisplayInheritRoles";
         AV26GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV37DisplayInheritRoles);
         AV25GridState.gxTpr_Filtervalues.Add(AV26GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV67Pgmname,  AV24GridStateKey,  AV25GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV24GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV67Pgmname,  AV24GridStateKey, out  AV25GridState) ;
         AV72GXV5 = 1;
         while ( AV72GXV5 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV72GXV5));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Filtername, "DisplayInheritRoles") == 0 )
            {
               AV37DisplayInheritRoles = BooleanUtil.Val( AV26GridStateFilterValue.gxTpr_Value);
               AssignAttri(sPrefix, false, "AV37DisplayInheritRoles", AV37DisplayInheritRoles);
            }
            AV72GXV5 = (int)(AV72GXV5+1);
         }
         if ( AV25GridState.gxTpr_Currentpage > 0 )
         {
            AV29CurrentPage_Grid = AV25GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV29CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV29CurrentPage_Grid), 4, 0));
         }
      }

      protected void E22422( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S202 ();
         if (returnInSub) return;
         if ( (0==AV29CurrentPage_Grid) )
         {
            AV29CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV29CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV29CurrentPage_Grid), 4, 0));
         }
         if ( AV38DisplayInheritRoles_PreviousValue != AV37DisplayInheritRoles )
         {
            AV38DisplayInheritRoles_PreviousValue = AV37DisplayInheritRoles;
            AssignAttri(sPrefix, false, "AV38DisplayInheritRoles_PreviousValue", AV38DisplayInheritRoles_PreviousValue);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISPLAYINHERITROLES_PREVIOUSVALUE", GetSecureSignedToken( sPrefix, AV38DisplayInheritRoles_PreviousValue, context));
            AV29CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV29CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV29CurrentPage_Grid), 4, 0));
         }
         AV30Reload_Grid = true;
         if ( StringUtil.StrCmp(AV23HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
            S212 ();
            if (returnInSub) return;
            AV58Grid_SelectedRows = 0;
            AssignAttri(sPrefix, false, "AV58Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV58Grid_SelectedRows), 4, 0));
         }
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV49ClassCollection_Grid) ;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV49ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
      }

      protected void S232( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E23422( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S192 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S212 ();
         if (returnInSub) return;
         AV58Grid_SelectedRows = 0;
         AssignAttri(sPrefix, false, "AV58Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV58Grid_SelectedRows), 4, 0));
         if ( AV54AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV49ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV49ClassCollection_Grid) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV49ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S232 ();
         if (returnInSub) return;
         AV50CheckAll_Grid = false;
         AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(GRID)' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV43FilterTagsCollection_Grid", AV43FilterTagsCollection_Grid);
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV43FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV39K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         if ( ! (false==AV37DisplayInheritRoles) )
         {
            AV40K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "DisplayInheritRoles";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Description = chkavDisplayinheritroles.Caption;
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Canbedeleted = true;
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Value = StringUtil.BoolToStr( AV37DisplayInheritRoles);
            AV40K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = "Yes";
            AV39K2BFilterValuesSDT_WebForm.Add(AV40K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No filters are applied";
         ucFiltertagsusercontrol_grid.SendProperty(context, sPrefix, false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV39K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV43FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV67Pgmname,  "Filters",  AV39K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV43FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void S352( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
      }

      protected void E15422( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S242 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
      }

      protected void S242( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         AV19Window.Autoresize = 1;
         AV19Window.Url = formatLink("k2bfsg.useraddrole.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17UserId))}, new string[] {"UserId"}) ;
         AV19Window.SetReturnParms(new Object[] {});
         context.NewWindow(AV19Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S172( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void S312( )
      {
         /* 'RESETMULTIROWITERATOR(GRID)' Routine */
         returnInSub = false;
         AV48MultiRowIterator_Grid = 1;
         AssignAttri(sPrefix, false, "AV48MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV48MultiRowIterator_Grid), 4, 0));
      }

      protected void S322( )
      {
         /* 'GETNEXTMULTIROW(GRID)' Routine */
         returnInSub = false;
         AV59S_Name = "";
         AV60S_GUID = "";
         AV61S_Id = 0;
         AssignAttri(sPrefix, false, "AV61S_Id", StringUtil.LTrimStr( (decimal)(AV61S_Id), 12, 0));
         while ( ( AV48MultiRowIterator_Grid <= AV55SelectedItems_Grid.Count ) && ! ((SdtK2BSelectionItem)AV55SelectedItems_Grid.Item(AV48MultiRowIterator_Grid)).gxTpr_Isselected )
         {
            AV48MultiRowIterator_Grid = (short)(AV48MultiRowIterator_Grid+1);
            AssignAttri(sPrefix, false, "AV48MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV48MultiRowIterator_Grid), 4, 0));
         }
         if ( AV48MultiRowIterator_Grid > AV55SelectedItems_Grid.Count )
         {
            AV47MultiRowHasNext_Grid = false;
            AssignAttri(sPrefix, false, "AV47MultiRowHasNext_Grid", AV47MultiRowHasNext_Grid);
         }
         else
         {
            AV47MultiRowHasNext_Grid = true;
            AssignAttri(sPrefix, false, "AV47MultiRowHasNext_Grid", AV47MultiRowHasNext_Grid);
            AV53FieldValues_Grid = ((SdtK2BSelectionItem)AV55SelectedItems_Grid.Item(AV48MultiRowIterator_Grid)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_GRID' */
            S362 ();
            if (returnInSub) return;
         }
         AV48MultiRowIterator_Grid = (short)(AV48MultiRowIterator_Grid+1);
         AssignAttri(sPrefix, false, "AV48MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV48MultiRowIterator_Grid), 4, 0));
      }

      protected void E24422( )
      {
         /* Multirowitemselected_grid_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(GRID)' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV54AllSelectedItems_Grid", AV54AllSelectedItems_Grid);
      }

      protected void S252( )
      {
         /* 'PROCESSSELECTION(GRID)' Routine */
         returnInSub = false;
         AV50CheckAll_Grid = true;
         AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
         /* Start For Each Line in Grid */
         nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_76_fel_idx = 0;
         while ( nGXsfl_76_fel_idx < nRC_GXsfl_76 )
         {
            nGXsfl_76_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_76_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_fel_idx+1);
            sGXsfl_76_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_762( ) ;
            AV46MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV34Name = cgiGet( edtavName_Internalname);
            AV35GUID = cgiGet( edtavGuid_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               wbErr = true;
               AV36Id = 0;
            }
            else
            {
               AV36Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV33MainRole_Action = cgiGet( edtavMainrole_action_Internalname);
            AV41Delete_Action = cgiGet( edtavDelete_action_Internalname);
            /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
            S262 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_76_fel_idx == 0 )
         {
            nGXsfl_76_idx = 1;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         nGXsfl_76_fel_idx = 1;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S302 ();
         if (returnInSub) return;
         if ( AV54AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV49ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV49ClassCollection_Grid) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV49ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
      }

      protected void E16422( )
      {
         /* Checkall_grid_Click Routine */
         returnInSub = false;
         /* Start For Each Line in Grid */
         nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_76_fel_idx = 0;
         while ( nGXsfl_76_fel_idx < nRC_GXsfl_76 )
         {
            nGXsfl_76_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_76_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_fel_idx+1);
            sGXsfl_76_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_762( ) ;
            AV46MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV34Name = cgiGet( edtavName_Internalname);
            AV35GUID = cgiGet( edtavGuid_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               wbErr = true;
               AV36Id = 0;
            }
            else
            {
               AV36Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV33MainRole_Action = cgiGet( edtavMainrole_action_Internalname);
            AV41Delete_Action = cgiGet( edtavDelete_action_Internalname);
            if ( AV46MultiRowItemSelected_Grid != AV50CheckAll_Grid )
            {
               AV46MultiRowItemSelected_Grid = AV50CheckAll_Grid;
               AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV46MultiRowItemSelected_Grid);
               /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
               S262 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_76_fel_idx == 0 )
         {
            nGXsfl_76_idx = 1;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         nGXsfl_76_fel_idx = 1;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S272 ();
         if (returnInSub) return;
         if ( AV57CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S292 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S302 ();
         if (returnInSub) return;
         if ( AV54AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV49ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV49ClassCollection_Grid) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV49ClassCollection_Grid,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV54AllSelectedItems_Grid", AV54AllSelectedItems_Grid);
      }

      protected void S262( )
      {
         /* 'UPDATESELECTION(GRID)' Routine */
         returnInSub = false;
         AV56Index_Grid = 1;
         while ( AV56Index_Grid <= AV54AllSelectedItems_Grid.Count )
         {
            if ( ((SdtK2BSelectionItem)AV54AllSelectedItems_Grid.Item(AV56Index_Grid)).gxTpr_Sknumeric1 == AV36Id )
            {
               AV54AllSelectedItems_Grid.RemoveItem(AV56Index_Grid);
            }
            else
            {
               AV56Index_Grid = (short)(AV56Index_Grid+1);
            }
         }
         if ( AV46MultiRowItemSelected_Grid )
         {
            AV51SelectedItem_Grid = new SdtK2BSelectionItem(context);
            AV51SelectedItem_Grid.gxTpr_Isselected = AV46MultiRowItemSelected_Grid;
            AV51SelectedItem_Grid.gxTpr_Sknumeric1 = AV36Id;
            AV52FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV52FieldValue_Grid.gxTpr_Name = "Name";
            AV52FieldValue_Grid.gxTpr_Value = AV34Name;
            AV51SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV52FieldValue_Grid, 0);
            AV52FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV52FieldValue_Grid.gxTpr_Name = "GUID";
            AV52FieldValue_Grid.gxTpr_Value = AV35GUID;
            AV51SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV52FieldValue_Grid, 0);
            AV52FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV52FieldValue_Grid.gxTpr_Name = "Id";
            AV52FieldValue_Grid.gxTpr_Value = StringUtil.Str( (decimal)(AV36Id), 12, 0);
            AV51SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV52FieldValue_Grid, 0);
            AV54AllSelectedItems_Grid.Add(AV51SelectedItem_Grid, 0);
         }
         if ( ! AV46MultiRowItemSelected_Grid )
         {
            AV50CheckAll_Grid = false;
            AssignAttri(sPrefix, false, "AV50CheckAll_Grid", AV50CheckAll_Grid);
         }
      }

      protected void S212( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S272 ();
         if (returnInSub) return;
         if ( AV57CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S292 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(GRID)' */
         S352 ();
         if (returnInSub) return;
      }

      protected void S282( )
      {
         /* 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         imgMultipledelete_Visible = 1;
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgMultipledelete_Visible), 5, 0), true);
         imgMultipledelete_gximage = "K2BActionDelete";
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "gximage", imgMultipledelete_gximage, true);
         imgMultipledelete_Bitmap = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgMultipledelete_Bitmap)), true);
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "SrcSet", context.GetImageSrcSet( imgMultipledelete_Bitmap), true);
         imgMultipledelete_Tooltiptext = "Multiple Delete";
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "Tooltiptext", imgMultipledelete_Tooltiptext, true);
      }

      protected void S292( )
      {
         /* 'HIDEMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         imgMultipledelete_Visible = 0;
         AssignProp(sPrefix, false, imgMultipledelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgMultipledelete_Visible), 5, 0), true);
      }

      protected void S302( )
      {
         /* 'U_MULTIROWITEMSELECTED(GRID)' Routine */
         returnInSub = false;
      }

      protected void S272( )
      {
         /* 'GETSELECTEDITEMSCOUNT_GRID' Routine */
         returnInSub = false;
         AV57CountSelectedItems_Grid = 0;
         AssignAttri(sPrefix, false, "AV57CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV57CountSelectedItems_Grid), 4, 0));
         AV75GXV6 = 1;
         while ( AV75GXV6 <= AV54AllSelectedItems_Grid.Count )
         {
            AV51SelectedItem_Grid = ((SdtK2BSelectionItem)AV54AllSelectedItems_Grid.Item(AV75GXV6));
            if ( AV51SelectedItem_Grid.gxTpr_Isselected )
            {
               AV57CountSelectedItems_Grid = (short)(AV57CountSelectedItems_Grid+1);
               AssignAttri(sPrefix, false, "AV57CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV57CountSelectedItems_Grid), 4, 0));
            }
            AV75GXV6 = (int)(AV75GXV6+1);
         }
      }

      protected void S362( )
      {
         /* 'GETFIELDVALUES_GRID' Routine */
         returnInSub = false;
         AV76GXV7 = 1;
         while ( AV76GXV7 <= AV53FieldValues_Grid.Count )
         {
            AV52FieldValue_Grid = ((SdtK2BSelectionItem_FieldValuesItem)AV53FieldValues_Grid.Item(AV76GXV7));
            if ( StringUtil.StrCmp(AV52FieldValue_Grid.gxTpr_Name, "Name") == 0 )
            {
               AV59S_Name = AV52FieldValue_Grid.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52FieldValue_Grid.gxTpr_Name, "GUID") == 0 )
            {
               AV60S_GUID = AV52FieldValue_Grid.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52FieldValue_Grid.gxTpr_Name, "Id") == 0 )
            {
               AV61S_Id = (long)(Math.Round(NumberUtil.Val( AV52FieldValue_Grid.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV61S_Id", StringUtil.LTrimStr( (decimal)(AV61S_Id), 12, 0));
            }
            AV76GXV7 = (int)(AV76GXV7+1);
         }
      }

      protected void E17422( )
      {
         /* 'E_MultipleDelete' Routine */
         returnInSub = false;
         AV55SelectedItems_Grid = AV54AllSelectedItems_Grid;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S312 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S322 ();
         if (returnInSub) return;
         if ( ! AV47MultiRowHasNext_Grid )
         {
            AV30Reload_Grid = false;
            new k2btoolsmsg(context ).execute(  "Error: You must select a row",  0) ;
         }
         else
         {
            /* Execute user subroutine: 'U_MULTIPLEDELETE' */
            S332 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55SelectedItems_Grid", AV55SelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV53FieldValues_Grid", AV53FieldValues_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV54AllSelectedItems_Grid", AV54AllSelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49ClassCollection_Grid", AV49ClassCollection_Grid);
      }

      protected void S332( )
      {
         /* 'U_MULTIPLEDELETE' Routine */
         returnInSub = false;
         AV16isOK = true;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S312 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S322 ();
         if (returnInSub) return;
         while ( AV47MultiRowHasNext_Grid )
         {
            AV11GAMUser.load( AV17UserId);
            AV16isOK = (bool)(AV11GAMUser.deleterolebyid(AV61S_Id, out  AV6Errors)&&AV16isOK);
            /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
            S322 ();
            if (returnInSub) return;
         }
         if ( AV16isOK )
         {
            context.CommitDataStores("k2bfsg.wwuserrole",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S342 ();
            if (returnInSub) return;
         }
         if ( AV16isOK )
         {
            GX_msglist.addItem("Role was succesffully deleted");
            AV54AllSelectedItems_Grid.Clear();
            gxgrGrid_refresh( AV38DisplayInheritRoles_PreviousValue, AV54AllSelectedItems_Grid, AV49ClassCollection_Grid, AV37DisplayInheritRoles, AV67Pgmname, AV29CurrentPage_Grid, AV57CountSelectedItems_Grid, AV63HasNextPage_Grid, AV18isDirectRole, AV36Id, AV58Grid_SelectedRows, AV17UserId, AV31I_LoadCount_Grid, AV50CheckAll_Grid, sPrefix) ;
         }
      }

      protected void S182( )
      {
         /* 'UPDATEPAGINGCONTROLS(GRID)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockgrid_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockgrid_Internalname, "Caption", lblPaginationbar_firstpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV29CurrentPage_Grid-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockgrid_Internalname, "Caption", lblPaginationbar_previouspagetextblockgrid_Caption, true);
         lblPaginationbar_currentpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV29CurrentPage_Grid), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockgrid_Internalname, "Caption", lblPaginationbar_currentpagetextblockgrid_Caption, true);
         lblPaginationbar_nextpagetextblockgrid_Caption = StringUtil.Str( (decimal)(AV29CurrentPage_Grid+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockgrid_Internalname, "Caption", lblPaginationbar_nextpagetextblockgrid_Caption, true);
         lblPaginationbar_previouspagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockgrid_Class, true);
         lblPaginationbar_nextpagebuttontextblockgrid_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockgrid_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockgrid_Class, true);
         if ( (0==AV29CurrentPage_Grid) || ( AV29CurrentPage_Grid <= 1 ) )
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
            if ( AV29CurrentPage_Grid == 2 )
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
               if ( AV29CurrentPage_Grid == 3 )
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
         if ( ! AV63HasNextPage_Grid )
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
         if ( ( AV29CurrentPage_Grid <= 1 ) && ! AV63HasNextPage_Grid )
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

      protected void wb_table1_85_422( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No results found", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\WWUserRole.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_85_422e( true) ;
         }
         else
         {
            wb_table1_85_422e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17UserId = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV17UserId", AV17UserId);
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
         PA422( ) ;
         WS422( ) ;
         WE422( ) ;
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
         sCtrlAV17UserId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA422( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\wwuserrole", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA422( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV17UserId = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV17UserId", AV17UserId);
         }
         wcpOAV17UserId = cgiGet( sPrefix+"wcpOAV17UserId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV17UserId, wcpOAV17UserId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV17UserId = AV17UserId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV17UserId = cgiGet( sPrefix+"AV17UserId_CTRL");
         if ( StringUtil.Len( sCtrlAV17UserId) > 0 )
         {
            AV17UserId = cgiGet( sCtrlAV17UserId);
            AssignAttri(sPrefix, false, "AV17UserId", AV17UserId);
         }
         else
         {
            AV17UserId = cgiGet( sPrefix+"AV17UserId_PARM");
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
         PA422( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS422( ) ;
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
         WS422( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV17UserId_PARM", StringUtil.RTrim( AV17UserId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV17UserId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV17UserId_CTRL", StringUtil.RTrim( sCtrlAV17UserId));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            WE422( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138143054", true, true);
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
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bfsg/wwuserrole.js", "?20243138143057", false, true);
            context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
            context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_762( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_76_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_76_idx;
         edtavGuid_Internalname = sPrefix+"vGUID_"+sGXsfl_76_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_76_idx;
         edtavMainrole_action_Internalname = sPrefix+"vMAINROLE_ACTION_"+sGXsfl_76_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_762( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_76_fel_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_76_fel_idx;
         edtavGuid_Internalname = sPrefix+"vGUID_"+sGXsfl_76_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_76_fel_idx;
         edtavMainrole_action_Internalname = sPrefix+"vMAINROLE_ACTION_"+sGXsfl_76_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_76_fel_idx;
      }

      protected void sendrow_762( )
      {
         SubsflControlProps_762( ) ;
         WB420( ) ;
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
            if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 77,'"+sPrefix+"',false,'"+sGXsfl_76_idx+"',76)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_76_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_76_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_grid_Internalname,StringUtil.BoolToStr( AV46MultiRowItemSelected_Grid),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,77);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 78,'"+sPrefix+"',false,'"+sGXsfl_76_idx+"',76)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV34Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,78);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavName_Link,(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'"+sPrefix+"',false,'"+sGXsfl_76_idx+"',76)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGuid_Internalname,StringUtil.RTrim( AV35GUID),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,79);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGuid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavGuid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 80,'"+sPrefix+"',false,'"+sGXsfl_76_idx+"',76)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV36Id), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,80);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavMainrole_action_Enabled!=0)&&(edtavMainrole_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 81,'"+sPrefix+"',false,'"+sGXsfl_76_idx+"',76)\"" : " ");
         ROClassString = "Attribute_Grid K2BT_TextAction";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMainrole_action_Internalname,StringUtil.RTrim( AV33MainRole_Action),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavMainrole_action_Enabled!=0)&&(edtavMainrole_action_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,81);\"" : " "),"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_MAINROLE\\'."+sGXsfl_76_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMainrole_action_Jsonclick,(short)5,(string)"Attribute_Grid K2BT_TextAction",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavMainrole_action_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 82,'"+sPrefix+"',false,'',76)\"" : " ");
         ClassString = "Image_Action" + " " + ((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class");
         StyleString = "";
         AV41Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV69Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41Delete_Action)) ? AV69Delete_action_GXI : context.PathToRelativeUrl( AV41Delete_Action));
         GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtavDelete_action_Enabled,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)14,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETE\\'."+sGXsfl_76_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV41Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes422( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_76_idx = ((subGrid_Islastpage==1)&&(nGXsfl_76_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         /* End function sendrow_762 */
      }

      protected void init_web_controls( )
      {
         chkavDisplayinheritroles.Name = "vDISPLAYINHERITROLES";
         chkavDisplayinheritroles.WebTags = "";
         chkavDisplayinheritroles.Caption = "";
         AssignProp(sPrefix, false, chkavDisplayinheritroles_Internalname, "TitleCaption", chkavDisplayinheritroles.Caption, true);
         chkavDisplayinheritroles.CheckedValue = "false";
         chkavCheckall_grid.Name = "vCHECKALL_GRID";
         chkavCheckall_grid.WebTags = "";
         chkavCheckall_grid.Caption = "";
         AssignProp(sPrefix, false, chkavCheckall_grid_Internalname, "TitleCaption", chkavCheckall_grid.Caption, true);
         chkavCheckall_grid.CheckedValue = "false";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_76_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_76_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl76( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"76\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "GUID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid K2BT_TextAction"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(14), 4, 0)+"px"+" class=\""+"Image_Action"+" "+((StringUtil.StrCmp(edtavDelete_action_gximage, "")==0) ? "" : "GX_Image_"+edtavDelete_action_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV46MultiRowItemSelected_Grid)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV35GUID)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGuid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Id), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV33MainRole_Action)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMainrole_action_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV41Delete_Action));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_action_Enabled), 5, 0, ".", "")));
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
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         lblLayoutdefined_k2bt_filtercaption_grid_Internalname = sPrefix+"LAYOUTDEFINED_K2BT_FILTERCAPTION_GRID";
         Filtertagsusercontrol_grid_Internalname = sPrefix+"FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_table11_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE11_GRID";
         chkavDisplayinheritroles_Internalname = sPrefix+"vDISPLAYINHERITROLES";
         divTable_container_displayinheritroles_Internalname = sPrefix+"TABLE_CONTAINER_DISPLAYINHERITROLES";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         bttAdd_Internalname = sPrefix+"ADD";
         divActions_grid_topright_Internalname = sPrefix+"ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         imgMultipledelete_Internalname = sPrefix+"MULTIPLEDELETE";
         divActions_grid_gridassociatedleft_Internalname = sPrefix+"ACTIONS_GRID_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_GRID";
         divLayoutdefined_section3_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_GRID";
         divLayoutdefined_section1_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_GRID";
         chkavCheckall_grid_Internalname = sPrefix+"vCHECKALL_GRID";
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavGuid_Internalname = sPrefix+"vGUID";
         edtavId_Internalname = sPrefix+"vID";
         edtavMainrole_action_Internalname = sPrefix+"vMAINROLE_ACTION";
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION";
         divTablegridcontainer_grid_Internalname = sPrefix+"TABLEGRIDCONTAINER_GRID";
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
         chkavCheckall_grid.Caption = "";
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_gximage = "";
         edtavDelete_action_Visible = -1;
         edtavDelete_action_Tooltiptext = "";
         edtavDelete_action_Enabled = 1;
         edtavMainrole_action_Jsonclick = "";
         edtavMainrole_action_Visible = -1;
         edtavMainrole_action_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavId_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Visible = 0;
         edtavGuid_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         edtavName_Enabled = 1;
         chkavMultirowitemselected_grid.Caption = "";
         chkavMultirowitemselected_grid.Visible = -1;
         chkavMultirowitemselected_grid.Enabled = 1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavName_Link = "";
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
         chkavCheckall_grid.Enabled = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         imgMultipledelete_Tooltiptext = "Multiple Delete";
         imgMultipledelete_Visible = 1;
         imgMultipledelete_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         bttAdd_Visible = 1;
         chkavDisplayinheritroles.Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         chkavDisplayinheritroles.Caption = "Display inherit role";
         Gridcomponent_grid_Containseditableform = Convert.ToBoolean( 0);
         Gridcomponent_grid_Showborders = Convert.ToBoolean( -1);
         Gridcomponent_grid_Open = Convert.ToBoolean( -1);
         Gridcomponent_grid_Collapsible = Convert.ToBoolean( -1);
         Gridcomponent_grid_Title = "Roles";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'sPrefix'},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'E_DELETE'","{handler:'E19422',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'E_MAINROLE'","{handler:'E20422',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_MAINROLE'",",oparms:[{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E21422',iparms:[{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV33MainRole_Action',fld:'vMAINROLE_ACTION',pic:''},{av:'AV41Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Enabled',ctrl:'vDELETE_ACTION',prop:'Enabled'},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV46MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV35GUID',fld:'vGUID',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV34Name',fld:'vNAME',pic:'',hsh:true},{av:'edtavName_Link',ctrl:'vNAME',prop:'Link'},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E23422',iparms:[{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'chkavDisplayinheritroles.Caption',ctrl:'vDISPLAYINHERITROLES',prop:'Caption'},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV43FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'lblPaginationbar_firstpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockgrid_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockgrid_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKGRID',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockgrid_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKGRID',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockgrid_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKGRID',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_grid_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_GRID',prop:'Visible'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'E_ADD'","{handler:'E15422',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK","{handler:'E24422',iparms:[{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36Id',fld:'vID',grid:76,pic:'ZZZZZZZZZZZ9',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRID',grid:76,prop:'GridRC',grid:76},{av:'AV46MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:76,pic:''},{av:'AV34Name',fld:'vNAME',grid:76,pic:'',hsh:true},{av:'AV35GUID',fld:'vGUID',grid:76,pic:'',hsh:true},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'}]");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK",",oparms:[{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("VCHECKALL_GRID.CLICK","{handler:'E16422',iparms:[{av:'AV46MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:76,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRID',grid:76,prop:'GridRC',grid:76},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV36Id',fld:'vID',grid:76,pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV34Name',fld:'vNAME',grid:76,pic:'',hsh:true},{av:'AV35GUID',fld:'vGUID',grid:76,pic:'',hsh:true}]");
         setEventMetadata("VCHECKALL_GRID.CLICK",",oparms:[{av:'AV46MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'}]}");
         setEventMetadata("'E_MULTIPLEDELETE'","{handler:'E17422',iparms:[{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV48MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV55SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'},{av:'AV61S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV53FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''}]");
         setEventMetadata("'E_MULTIPLEDELETE'",",oparms:[{av:'AV55SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV48MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV61S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV53FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV47MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'PAGINGFIRST(GRID)'","{handler:'E13421',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGFIRST(GRID)'",",oparms:[{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'","{handler:'E12421',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGPREVIOUS(GRID)'",",oparms:[{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("'PAGINGNEXT(GRID)'","{handler:'E14421',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV54AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV37DisplayInheritRoles',fld:'vDISPLAYINHERITROLES',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV63HasNextPage_Grid',fld:'vHASNEXTPAGE_GRID',pic:'',hsh:true},{av:'AV18isDirectRole',fld:'vISDIRECTROLE',pic:'',hsh:true},{av:'AV36Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV17UserId',fld:'vUSERID',pic:''},{av:'AV31I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PAGINGNEXT(GRID)'",",oparms:[{av:'AV50CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV29CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9'},{av:'AV38DisplayInheritRoles_PreviousValue',fld:'vDISPLAYINHERITROLES_PREVIOUSVALUE',pic:'',hsh:true},{av:'AV58Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV49ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'imgMultipledelete_Visible',ctrl:'MULTIPLEDELETE',prop:'Visible'},{av:'imgMultipledelete_Tooltiptext',ctrl:'MULTIPLEDELETE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E11421',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'}]}");
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
         wcpOAV17UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV54AllSelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV49ClassCollection_Grid = new GxSimpleCollection<string>();
         AV67Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV43FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV44DeletedTag_Grid = "";
         AV55SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV53FieldValues_Grid = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "test");
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGridcomponent_grid = new GXUserControl();
         TempTags = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_gximage = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick = "";
         lblLayoutdefined_k2bt_filtercaption_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         bttAdd_Jsonclick = "";
         imgMultipledelete_gximage = "";
         imgMultipledelete_Jsonclick = "";
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
         AV34Name = "";
         AV35GUID = "";
         AV33MainRole_Action = "";
         AV41Delete_Action = "";
         AV69Delete_action_GXI = "";
         AV42Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV6Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV51SelectedItem_Grid = new SdtK2BSelectionItem(context);
         GridRow = new GXWebRow();
         AV13Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV8GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMRolesDirect = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV9GAMRoleAux = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV12Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV24GridStateKey = "";
         AV25GridState = new SdtK2BGridState(context);
         AV26GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV23HttpRequest = new GxHttpRequest( context);
         AV39K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "test");
         AV40K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV19Window = new GXWindow();
         AV59S_Name = "";
         AV60S_GUID = "";
         GXt_char2 = "";
         AV52FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV17UserId = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwuserrole__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.wwuserrole__default(),
            new Object[][] {
            }
         );
         AV67Pgmname = "K2BFSG.WWUserRole";
         /* GeneXus formulas. */
         AV67Pgmname = "K2BFSG.WWUserRole";
         edtavName_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavId_Enabled = 0;
         edtavMainrole_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV29CurrentPage_Grid ;
      private short AV57CountSelectedItems_Grid ;
      private short AV58Grid_SelectedRows ;
      private short AV31I_LoadCount_Grid ;
      private short initialized ;
      private short nGXWrapped ;
      private short AV48MultiRowIterator_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV64RowsPerPage_Grid ;
      private short GRID_nEOF ;
      private short AV56Index_Grid ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_76 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_76_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavId_Enabled ;
      private int edtavMainrole_action_Enabled ;
      private int bttAdd_Visible ;
      private int imgMultipledelete_Visible ;
      private int divPaginationbar_pagingcontainertable_grid_Visible ;
      private int lblPaginationbar_firstpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacinglefttextblockgrid_Visible ;
      private int lblPaginationbar_previouspagetextblockgrid_Visible ;
      private int lblPaginationbar_nextpagetextblockgrid_Visible ;
      private int lblPaginationbar_spacingrighttextblockgrid_Visible ;
      private int subGrid_Islastpage ;
      private int AV66GXV1 ;
      private int AV68GXV2 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int edtavDelete_action_Enabled ;
      private int AV70GXV3 ;
      private int AV71GXV4 ;
      private int AV72GXV5 ;
      private int nGXsfl_76_fel_idx=1 ;
      private int AV75GXV6 ;
      private int AV76GXV7 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavGuid_Visible ;
      private int edtavId_Visible ;
      private int edtavMainrole_action_Visible ;
      private int edtavDelete_action_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV36Id ;
      private long AV61S_Id ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string AV17UserId ;
      private string wcpOAV17UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_76_idx="0001" ;
      private string AV67Pgmname ;
      private string edtavName_Internalname ;
      private string edtavGuid_Internalname ;
      private string edtavId_Internalname ;
      private string edtavMainrole_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV44DeletedTag_Grid ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
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
      private string divTable_container_displayinheritroles_Internalname ;
      private string chkavDisplayinheritroles_Internalname ;
      private string divLayoutdefined_table7_grid_Internalname ;
      private string divActions_grid_topright_Internalname ;
      private string bttAdd_Internalname ;
      private string bttAdd_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divLayoutdefined_section1_grid_Internalname ;
      private string divLayoutdefined_section7_grid_Internalname ;
      private string divActions_grid_gridassociatedleft_Internalname ;
      private string imgMultipledelete_gximage ;
      private string imgMultipledelete_Internalname ;
      private string imgMultipledelete_Tooltiptext ;
      private string imgMultipledelete_Jsonclick ;
      private string divLayoutdefined_section3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divTablegridcontainer_grid_Internalname ;
      private string chkavCheckall_grid_Internalname ;
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
      private string chkavMultirowitemselected_grid_Internalname ;
      private string AV34Name ;
      private string AV35GUID ;
      private string AV33MainRole_Action ;
      private string edtavDelete_action_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string edtavDelete_action_gximage ;
      private string edtavDelete_action_Tooltiptext ;
      private string edtavName_Link ;
      private string AV59S_Name ;
      private string AV60S_GUID ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string GXt_char2 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string sCtrlAV17UserId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavGuid_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavMainrole_action_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV38DisplayInheritRoles_PreviousValue ;
      private bool AV37DisplayInheritRoles ;
      private bool AV63HasNextPage_Grid ;
      private bool AV18isDirectRole ;
      private bool AV50CheckAll_Grid ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool AV47MultiRowHasNext_Grid ;
      private bool Gridcomponent_grid_Collapsible ;
      private bool Gridcomponent_grid_Open ;
      private bool Gridcomponent_grid_Showborders ;
      private bool Gridcomponent_grid_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV46MultiRowItemSelected_Grid ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV65RowsPerPageLoaded_Grid ;
      private bool AV16isOK ;
      private bool AV32Exit_Grid ;
      private bool gx_refresh_fired ;
      private bool AV30Reload_Grid ;
      private bool AV41Delete_Action_IsBlob ;
      private string AV69Delete_action_GXI ;
      private string AV24GridStateKey ;
      private string imgMultipledelete_Bitmap ;
      private string AV41Delete_Action ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridcomponent_grid ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_UserId ;
      private GXCheckbox chkavDisplayinheritroles ;
      private GXCheckbox chkavCheckall_grid ;
      private GXCheckbox chkavMultirowitemselected_grid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV23HttpRequest ;
      private GxSimpleCollection<string> AV49ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV6Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV13Roles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV10GAMRolesDirect ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV42Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV39K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV43FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXBaseCollection<SdtK2BSelectionItem> AV54AllSelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem> AV55SelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV53FieldValues_Grid ;
      private GXWindow AV19Window ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV5Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV8GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV9GAMRoleAux ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV12Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private SdtK2BGridState AV25GridState ;
      private SdtK2BGridState_FilterValue AV26GridStateFilterValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV40K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BSelectionItem AV51SelectedItem_Grid ;
      private SdtK2BSelectionItem_FieldValuesItem AV52FieldValue_Grid ;
   }

   public class wwuserrole__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwuserrole__default : DataStoreHelperBase, IDataStoreHelper
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
