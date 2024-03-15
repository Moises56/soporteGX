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
   public class roleadduser : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public roleadduser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public roleadduser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_RoleId )
      {
         this.AV46RoleId = aP0_RoleId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCheckall_grid = new GXCheckbox();
         chkavMultirowitemselected_grid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
               AV46RoleId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46RoleId", StringUtil.LTrimStr( (decimal)(AV46RoleId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46RoleId), "ZZZZZZZZZZZ9"), context));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV16CurrentPage_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."), 18, MidpointRounding.ToEven));
         AV24GenericFilter_PreviousValue_Grid = GetPar( "GenericFilter_PreviousValue_Grid");
         AV46RoleId = (long)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11AllSelectedItems_Grid);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13ClassCollection_Grid);
         AV59Pgmname = GetPar( "Pgmname");
         AV23GenericFilter_Grid = GetPar( "GenericFilter_Grid");
         AV14CountSelectedItems_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "CountSelectedItems_Grid"), "."), 18, MidpointRounding.ToEven));
         AV30Guid = GetPar( "Guid");
         AV25Grid_SelectedRows = (short)(Math.Round(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."), 18, MidpointRounding.ToEven));
         AV35I_LoadCount_Grid = (short)(Math.Round(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."), 18, MidpointRounding.ToEven));
         AV15CurrentAvailableUser = (short)(Math.Round(NumberUtil.Val( GetPar( "CurrentAvailableUser"), "."), 18, MidpointRounding.ToEven));
         AV12CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV16CurrentPage_Grid, AV24GenericFilter_PreviousValue_Grid, AV46RoleId, AV11AllSelectedItems_Grid, AV13ClassCollection_Grid, AV59Pgmname, AV23GenericFilter_Grid, AV14CountSelectedItems_Grid, AV30Guid, AV25Grid_SelectedRows, AV35I_LoadCount_Grid, AV15CurrentAvailableUser, AV12CheckAll_Grid) ;
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
         PA4Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4Q2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleadduser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV46RoleId,12,0))}, new string[] {"RoleId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV24GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46RoleId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46RoleId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTAVAILABLEUSER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentAvailableUser), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV24GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24GenericFilter_PreviousValue_Grid, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_GRID", AV13ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_GRID", AV13ClassCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vCOUNTSELECTEDITEMS_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14CountSelectedItems_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46RoleId), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46RoleId), "ZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALLSELECTEDITEMS_GRID", AV11AllSelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALLSELECTEDITEMS_GRID", AV11AllSelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Grid_SelectedRows), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTAVAILABLEUSER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentAvailableUser), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vMULTIROWHASNEXT_GRID", AV40MultiRowHasNext_Grid);
         GxWebStd.gx_hidden_field( context, "vMULTIROWITERATOR_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42MultiRowIterator_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDITEMS_GRID", AV50SelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDITEMS_GRID", AV50SelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, "vS_GUID", StringUtil.RTrim( AV47S_Guid));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFIELDVALUES_GRID", AV20FieldValues_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFIELDVALUES_GRID", AV20FieldValues_Grid);
         }
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            WE4Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4Q2( ) ;
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
         return formatLink("k2bfsg.roleadduser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV46RoleId,12,0))}, new string[] {"RoleId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RoleAddUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2BT_GAM_Roleadduser", "") ;
      }

      protected void WB4Q0( )
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
            GxWebStd.gx_div_start( context, divTable_container_rolename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtavRolename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRolename_Internalname, context.GetMessage( "K2BT_GAM_RoleName", ""), "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRolename_Internalname, StringUtil.RTrim( AV8RoleName), StringUtil.RTrim( context.localUtil.Format( AV8RoleName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRolename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavRolename_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_K2BFSG\\RoleAddUser.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_grid_Internalname, StringUtil.RTrim( AV23GenericFilter_Grid), StringUtil.RTrim( context.localUtil.Format( AV23GenericFilter_Grid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "K2BT_GenericFilterInviteMessage", ""), edtavGenericfilter_grid_Jsonclick, 0, "K2BT_GenericFilter", "", "", "", "", 1, edtavGenericfilter_grid_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BFSG\\RoleAddUser.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddselected_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "K2BT_GAM_Addselected", ""), bttAddselected_Jsonclick, 5, "", "", StyleString, ClassString, bttAddselected_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ADDSELECTED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleAddUser.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegridcontainer_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_grid_Internalname, StringUtil.BoolToStr( AV12CheckAll_Grid), "", "", 1, chkavCheckall_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,63);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_70_4Q2( true) ;
         }
         else
         {
            wb_table1_70_4Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_70_4Q2e( bool wbgen )
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
         if ( wbEnd == 64 )
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

      protected void START4Q2( )
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
         Form.Meta.addItem("description", context.GetMessage( "K2BT_GAM_Roleadduser", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4Q0( ) ;
      }

      protected void WS4Q2( )
      {
         START4Q2( ) ;
         EVT4Q2( ) ;
      }

      protected void EVT4Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VCHECKALL_GRID.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E114Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADDSELECTED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AddSelected' */
                              E124Q2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV41MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
                              AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
                              AV43Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV43Name);
                              GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV43Name, "")), context));
                              AV30Guid = cgiGet( edtavGuid_Internalname);
                              AssignAttri("", false, edtavGuid_Internalname, AV30Guid);
                              GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV30Guid, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E134Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E144Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E154Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E164Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E174Q2 ();
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

      protected void WE4Q2( )
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

      protected void PA4Q2( )
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
               GX_FocusControl = edtavRolename_Internalname;
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( short AV16CurrentPage_Grid ,
                                       string AV24GenericFilter_PreviousValue_Grid ,
                                       long AV46RoleId ,
                                       GXBaseCollection<SdtK2BSelectionItem> AV11AllSelectedItems_Grid ,
                                       GxSimpleCollection<string> AV13ClassCollection_Grid ,
                                       string AV59Pgmname ,
                                       string AV23GenericFilter_Grid ,
                                       short AV14CountSelectedItems_Grid ,
                                       string AV30Guid ,
                                       short AV25Grid_SelectedRows ,
                                       short AV35I_LoadCount_Grid ,
                                       short AV15CurrentAvailableUser ,
                                       bool AV12CheckAll_Grid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30Guid, "")), context));
         GxWebStd.gx_hidden_field( context, "vGUID", StringUtil.RTrim( AV30Guid));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Name, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAME", StringUtil.RTrim( AV43Name));
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
         AV12CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV12CheckAll_Grid));
         AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E144Q2 ();
         RF4Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV59Pgmname = "K2BFSG.RoleAddUser";
         edtavRolename_Enabled = 0;
         AssignProp("", false, edtavRolename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRolename_Enabled), 5, 0), true);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void RF4Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 64;
         /* Execute user event: Refresh */
         E144Q2 ();
         E154Q2 ();
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            E164Q2 ();
            wbEnd = 64;
            WB4Q0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CurrentPage_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGENERICFILTER_PREVIOUSVALUE_GRID", StringUtil.RTrim( AV24GenericFilter_PreviousValue_Grid));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24GenericFilter_PreviousValue_Grid, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV30Guid, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35I_LoadCount_Grid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTAVAILABLEUSER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentAvailableUser), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV43Name, "")), context));
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
         AV59Pgmname = "K2BFSG.RoleAddUser";
         edtavRolename_Enabled = 0;
         AssignProp("", false, edtavRolename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRolename_Enabled), 5, 0), true);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Attributes_Title = cgiGet( "ATTRIBUTES_Title");
            Attributes_Collapsible = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Collapsible"));
            Attributes_Open = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Open"));
            Attributes_Showborders = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Showborders"));
            Attributes_Containseditableform = StringUtil.StrToBool( cgiGet( "ATTRIBUTES_Containseditableform"));
            /* Read variables values. */
            AV8RoleName = cgiGet( edtavRolename_Internalname);
            AssignAttri("", false, "AV8RoleName", AV8RoleName);
            AV23GenericFilter_Grid = cgiGet( edtavGenericfilter_grid_Internalname);
            AssignAttri("", false, "AV23GenericFilter_Grid", AV23GenericFilter_Grid);
            AV12CheckAll_Grid = StringUtil.StrToBool( cgiGet( chkavCheckall_grid_Internalname));
            AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
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
         E134Q2 ();
         if (returnInSub) return;
      }

      protected void E134Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV24GenericFilter_PreviousValue_Grid = AV23GenericFilter_Grid;
         AssignAttri("", false, "AV24GenericFilter_PreviousValue_Grid", AV24GenericFilter_PreviousValue_Grid);
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24GenericFilter_PreviousValue_Grid, "")), context));
         subGrid_Backcolorstyle = 3;
      }

      protected void E144Q2( )
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
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16CurrentPage_Grid), "ZZZ9"), context));
         }
         if ( StringUtil.StrCmp(AV24GenericFilter_PreviousValue_Grid, AV23GenericFilter_Grid) != 0 )
         {
            AV24GenericFilter_PreviousValue_Grid = AV23GenericFilter_Grid;
            AssignAttri("", false, "AV24GenericFilter_PreviousValue_Grid", AV24GenericFilter_PreviousValue_Grid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGENERICFILTER_PREVIOUSVALUE_GRID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24GenericFilter_PreviousValue_Grid, "")), context));
            AV16CurrentPage_Grid = 1;
            AssignAttri("", false, "AV16CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV16CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16CurrentPage_Grid), "ZZZ9"), context));
         }
         AV44Reload_Grid = true;
         if ( StringUtil.StrCmp(AV34HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
            S142 ();
            if (returnInSub) return;
            AV25Grid_SelectedRows = 0;
            AssignAttri("", false, "AV25Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV25Grid_SelectedRows), 4, 0));
         }
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV13ClassCollection_Grid) ;
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV13ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13ClassCollection_Grid", AV13ClassCollection_Grid);
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

      protected void S152( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         if ( (0==AV46RoleId) )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV6GAMRole.load( AV46RoleId);
            AV8RoleName = AV6GAMRole.gxTpr_Name;
            AssignAttri("", false, "AV8RoleName", AV8RoleName);
         }
      }

      protected void E154Q2( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         AV25Grid_SelectedRows = 0;
         AssignAttri("", false, "AV25Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV25Grid_SelectedRows), 4, 0));
         if ( AV11AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV13ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV13ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV13ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S172 ();
         if (returnInSub) return;
         AV12CheckAll_Grid = false;
         AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13ClassCollection_Grid", AV13ClassCollection_Grid);
      }

      protected void S172( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      private void E164Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV35I_LoadCount_Grid = 0;
         AssignAttri("", false, "AV35I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV35I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35I_LoadCount_Grid), "ZZZ9"), context));
         AV18Exit_Grid = false;
         while ( true )
         {
            AV35I_LoadCount_Grid = (short)(AV35I_LoadCount_Grid+1);
            AssignAttri("", false, "AV35I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV35I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S182 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S192 ();
            if (returnInSub) return;
            if ( AV18Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp("", false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            AV41MultiRowItemSelected_Grid = false;
            AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
            AV57GXV1 = 1;
            while ( AV57GXV1 <= AV11AllSelectedItems_Grid.Count )
            {
               AV49SelectedItem_Grid = ((SdtK2BSelectionItem)AV11AllSelectedItems_Grid.Item(AV57GXV1));
               if ( StringUtil.StrCmp(AV49SelectedItem_Grid.gxTpr_Skcharacter1, AV30Guid) == 0 )
               {
                  if ( AV49SelectedItem_Grid.gxTpr_Isselected )
                  {
                     AV41MultiRowItemSelected_Grid = true;
                     AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
                     AV25Grid_SelectedRows = (short)(AV25Grid_SelectedRows+1);
                     AssignAttri("", false, "AV25Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV25Grid_SelectedRows), 4, 0));
                  }
                  if (true) break;
               }
               AV57GXV1 = (int)(AV57GXV1+1);
            }
            if ( AV35I_LoadCount_Grid == 1 )
            {
               AV12CheckAll_Grid = true;
               AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
            }
            if ( ! AV41MultiRowItemSelected_Grid )
            {
               AV12CheckAll_Grid = false;
               AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 64;
            }
            sendrow_642( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
            {
               context.DoAjaxLoad(64, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53UserFilter", AV53UserFilter);
      }

      protected void S182( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         if ( AV35I_LoadCount_Grid == 1 )
         {
            AV53UserFilter.gxTpr_Name = "%"+AV23GenericFilter_Grid;
            AV22GAMUsers = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusers(ref  AV53UserFilter, out  AV17Errors);
            AV22GAMUsers.Sort("Name");
            AV15CurrentAvailableUser = AV35I_LoadCount_Grid;
            AssignAttri("", false, "AV15CurrentAvailableUser", StringUtil.LTrimStr( (decimal)(AV15CurrentAvailableUser), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
            AV6GAMRole.load( AV46RoleId);
            AV56GAMAvailableUsers = AV6GAMRole.getusers(out  AV17Errors);
         }
         /* Execute user subroutine: 'FINDNEXTUNASSIGNEDUSER' */
         S292 ();
         if (returnInSub) return;
         if ( AV22GAMUsers.Count >= AV15CurrentAvailableUser )
         {
            AV43Name = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV22GAMUsers.Item(AV15CurrentAvailableUser)).gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV43Name);
            GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV43Name, "")), context));
            AV30Guid = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV22GAMUsers.Item(AV15CurrentAvailableUser)).gxTpr_Guid;
            AssignAttri("", false, edtavGuid_Internalname, AV30Guid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV30Guid, "")), context));
            AV15CurrentAvailableUser = (short)(AV15CurrentAvailableUser+1);
            AssignAttri("", false, "AV15CurrentAvailableUser", StringUtil.LTrimStr( (decimal)(AV15CurrentAvailableUser), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
         }
         else
         {
            AV18Exit_Grid = true;
         }
      }

      protected void S292( )
      {
         /* 'FINDNEXTUNASSIGNEDUSER' Routine */
         returnInSub = false;
         while ( AV22GAMUsers.Count >= AV15CurrentAvailableUser )
         {
            AV30Guid = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV22GAMUsers.Item(AV15CurrentAvailableUser)).gxTpr_Guid;
            AssignAttri("", false, edtavGuid_Internalname, AV30Guid);
            GxWebStd.gx_hidden_field( context, "gxhash_vGUID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( AV30Guid, "")), context));
            AV33HasUser = false;
            AV58GXV2 = 1;
            while ( AV58GXV2 <= AV56GAMAvailableUsers.Count )
            {
               AV7GAMUser = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV56GAMAvailableUsers.Item(AV58GXV2));
               if ( StringUtil.StrCmp(AV7GAMUser.gxTpr_Guid, AV30Guid) == 0 )
               {
                  AV33HasUser = true;
                  if (true) break;
               }
               AV58GXV2 = (int)(AV58GXV2+1);
            }
            if ( ! AV33HasUser )
            {
               if (true) break;
            }
            else
            {
               AV15CurrentAvailableUser = (short)(AV15CurrentAvailableUser+1);
               AssignAttri("", false, "AV15CurrentAvailableUser", StringUtil.LTrimStr( (decimal)(AV15CurrentAvailableUser), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTAVAILABLEUSER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15CurrentAvailableUser), "ZZZ9"), context));
            }
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV29GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV29GridStateKey, out  AV27GridState) ;
         AV27GridState.gxTpr_Filtervalues.Clear();
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "GenericFilter_Grid";
         AV28GridStateFilterValue.gxTpr_Value = AV23GenericFilter_Grid;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV59Pgmname,  AV29GridStateKey,  AV27GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV29GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV59Pgmname,  AV29GridStateKey, out  AV27GridState) ;
         AV60GXV3 = 1;
         while ( AV60GXV3 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV60GXV3));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "GenericFilter_Grid") == 0 )
            {
               AV23GenericFilter_Grid = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23GenericFilter_Grid", AV23GenericFilter_Grid);
            }
            AV60GXV3 = (int)(AV60GXV3+1);
         }
      }

      protected void S262( )
      {
         /* 'RESETMULTIROWITERATOR(GRID)' Routine */
         returnInSub = false;
         AV42MultiRowIterator_Grid = 1;
         AssignAttri("", false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void S272( )
      {
         /* 'GETNEXTMULTIROW(GRID)' Routine */
         returnInSub = false;
         AV48S_Name = "";
         AV47S_Guid = "";
         AssignAttri("", false, "AV47S_Guid", AV47S_Guid);
         while ( ( AV42MultiRowIterator_Grid <= AV50SelectedItems_Grid.Count ) && ! ((SdtK2BSelectionItem)AV50SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Isselected )
         {
            AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
            AssignAttri("", false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
         }
         if ( AV42MultiRowIterator_Grid > AV50SelectedItems_Grid.Count )
         {
            AV40MultiRowHasNext_Grid = false;
            AssignAttri("", false, "AV40MultiRowHasNext_Grid", AV40MultiRowHasNext_Grid);
         }
         else
         {
            AV40MultiRowHasNext_Grid = true;
            AssignAttri("", false, "AV40MultiRowHasNext_Grid", AV40MultiRowHasNext_Grid);
            AV20FieldValues_Grid = ((SdtK2BSelectionItem)AV50SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_GRID' */
            S302 ();
            if (returnInSub) return;
         }
         AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
         AssignAttri("", false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void E174Q2( )
      {
         /* Multirowitemselected_grid_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(GRID)' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13ClassCollection_Grid", AV13ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AllSelectedItems_Grid", AV11AllSelectedItems_Grid);
      }

      protected void S202( )
      {
         /* 'PROCESSSELECTION(GRID)' Routine */
         returnInSub = false;
         AV12CheckAll_Grid = true;
         AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
         /* Start For Each Line in Grid */
         nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_64_fel_idx = 0;
         while ( nGXsfl_64_fel_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_64_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_fel_idx+1);
            sGXsfl_64_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_642( ) ;
            AV41MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV43Name = cgiGet( edtavName_Internalname);
            AV30Guid = cgiGet( edtavGuid_Internalname);
            /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
            S212 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_64_fel_idx == 0 )
         {
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         nGXsfl_64_fel_idx = 1;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(GRID)' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S252 ();
         if (returnInSub) return;
         if ( AV11AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV13ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV13ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV13ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
      }

      protected void E114Q2( )
      {
         /* Checkall_grid_Click Routine */
         returnInSub = false;
         /* Start For Each Line in Grid */
         nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_64_fel_idx = 0;
         while ( nGXsfl_64_fel_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_64_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_fel_idx+1);
            sGXsfl_64_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_642( ) ;
            AV41MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV43Name = cgiGet( edtavName_Internalname);
            AV30Guid = cgiGet( edtavGuid_Internalname);
            if ( AV41MultiRowItemSelected_Grid != AV12CheckAll_Grid )
            {
               AV41MultiRowItemSelected_Grid = AV12CheckAll_Grid;
               AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
               /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
               S212 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_64_fel_idx == 0 )
         {
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         nGXsfl_64_fel_idx = 1;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S222 ();
         if (returnInSub) return;
         if ( AV14CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S232 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S242 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S252 ();
         if (returnInSub) return;
         if ( AV11AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV13ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV13ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV13ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13ClassCollection_Grid", AV13ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AllSelectedItems_Grid", AV11AllSelectedItems_Grid);
      }

      protected void S212( )
      {
         /* 'UPDATESELECTION(GRID)' Routine */
         returnInSub = false;
         AV36Index_Grid = 1;
         while ( AV36Index_Grid <= AV11AllSelectedItems_Grid.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BSelectionItem)AV11AllSelectedItems_Grid.Item(AV36Index_Grid)).gxTpr_Skcharacter1, AV30Guid) == 0 )
            {
               AV11AllSelectedItems_Grid.RemoveItem(AV36Index_Grid);
            }
            else
            {
               AV36Index_Grid = (short)(AV36Index_Grid+1);
            }
         }
         if ( AV41MultiRowItemSelected_Grid )
         {
            AV49SelectedItem_Grid = new SdtK2BSelectionItem(context);
            AV49SelectedItem_Grid.gxTpr_Isselected = AV41MultiRowItemSelected_Grid;
            AV49SelectedItem_Grid.gxTpr_Skcharacter1 = AV30Guid;
            AV19FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV19FieldValue_Grid.gxTpr_Name = "Name";
            AV19FieldValue_Grid.gxTpr_Value = AV43Name;
            AV49SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV19FieldValue_Grid, 0);
            AV19FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV19FieldValue_Grid.gxTpr_Name = "Guid";
            AV19FieldValue_Grid.gxTpr_Value = AV30Guid;
            AV49SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV19FieldValue_Grid, 0);
            AV11AllSelectedItems_Grid.Add(AV49SelectedItem_Grid, 0);
         }
         if ( ! AV41MultiRowItemSelected_Grid )
         {
            AV12CheckAll_Grid = false;
            AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
         }
      }

      protected void S142( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS(GRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_GRID' */
         S222 ();
         if (returnInSub) return;
         if ( AV14CountSelectedItems_Grid > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' */
            S232 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(GRID)' */
            S242 ();
            if (returnInSub) return;
         }
      }

      protected void S232( )
      {
         /* 'DISPLAYMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 1;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S242( )
      {
         /* 'HIDEMULTIPLEGLOBALACTIONS(GRID)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 0;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S252( )
      {
         /* 'U_MULTIROWITEMSELECTED(GRID)' Routine */
         returnInSub = false;
      }

      protected void S222( )
      {
         /* 'GETSELECTEDITEMSCOUNT_GRID' Routine */
         returnInSub = false;
         AV14CountSelectedItems_Grid = 0;
         AssignAttri("", false, "AV14CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV14CountSelectedItems_Grid), 4, 0));
         AV63GXV4 = 1;
         while ( AV63GXV4 <= AV11AllSelectedItems_Grid.Count )
         {
            AV49SelectedItem_Grid = ((SdtK2BSelectionItem)AV11AllSelectedItems_Grid.Item(AV63GXV4));
            if ( AV49SelectedItem_Grid.gxTpr_Isselected )
            {
               AV14CountSelectedItems_Grid = (short)(AV14CountSelectedItems_Grid+1);
               AssignAttri("", false, "AV14CountSelectedItems_Grid", StringUtil.LTrimStr( (decimal)(AV14CountSelectedItems_Grid), 4, 0));
            }
            AV63GXV4 = (int)(AV63GXV4+1);
         }
      }

      protected void S302( )
      {
         /* 'GETFIELDVALUES_GRID' Routine */
         returnInSub = false;
         AV64GXV5 = 1;
         while ( AV64GXV5 <= AV20FieldValues_Grid.Count )
         {
            AV19FieldValue_Grid = ((SdtK2BSelectionItem_FieldValuesItem)AV20FieldValues_Grid.Item(AV64GXV5));
            if ( StringUtil.StrCmp(AV19FieldValue_Grid.gxTpr_Name, "Name") == 0 )
            {
               AV48S_Name = AV19FieldValue_Grid.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19FieldValue_Grid.gxTpr_Name, "Guid") == 0 )
            {
               AV47S_Guid = AV19FieldValue_Grid.gxTpr_Value;
               AssignAttri("", false, "AV47S_Guid", AV47S_Guid);
            }
            AV64GXV5 = (int)(AV64GXV5+1);
         }
      }

      protected void E124Q2( )
      {
         /* 'E_AddSelected' Routine */
         returnInSub = false;
         AV50SelectedItems_Grid = AV11AllSelectedItems_Grid;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S262 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S272 ();
         if (returnInSub) return;
         if ( ! AV40MultiRowHasNext_Grid )
         {
            AV44Reload_Grid = false;
            new k2btoolsmsg(context ).execute(  context.GetMessage( "Error : You must select at least one permission", ""),  0) ;
         }
         else
         {
            /* Execute user subroutine: 'U_ADDSELECTED' */
            S282 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50SelectedItems_Grid", AV50SelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20FieldValues_Grid", AV20FieldValues_Grid);
      }

      protected void S282( )
      {
         /* 'U_ADDSELECTED' Routine */
         returnInSub = false;
         AV6GAMRole.load( AV46RoleId);
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S262 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S272 ();
         if (returnInSub) return;
         AV31HasError = false;
         while ( AV40MultiRowHasNext_Grid )
         {
            AV7GAMUser.load( AV47S_Guid);
            AV37IsOK = AV7GAMUser.addrolebyid(AV46RoleId, out  AV17Errors);
            if ( ! AV37IsOK )
            {
               AV31HasError = true;
               AV65GXV6 = 1;
               while ( AV65GXV6 <= AV17Errors.Count )
               {
                  AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV17Errors.Item(AV65GXV6));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV5Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV5Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV65GXV6 = (int)(AV65GXV6+1);
               }
               if (true) break;
            }
            /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
            S272 ();
            if (returnInSub) return;
         }
         if ( ! AV31HasError )
         {
            context.CommitDataStores("k2bfsg.roleadduser",pr_default);
            AV38Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV38Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "K2BT_GAM_Usersforhavesuccessfullybeenadded", ""), AV6GAMRole.gxTpr_Name, "", "", "", "", "", "", "", "");
            new k2btoolsmessagequeueadd(context ).execute(  AV38Message) ;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S192( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void wb_table1_70_4Q2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, context.GetMessage( "K2BT_NoResultsFound", ""), "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddUser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_70_4Q2e( true) ;
         }
         else
         {
            wb_table1_70_4Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV46RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV46RoleId", StringUtil.LTrimStr( (decimal)(AV46RoleId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46RoleId), "ZZZZZZZZZZZ9"), context));
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
         PA4Q2( ) ;
         WS4Q2( ) ;
         WE4Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243122141747", true, true);
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
         context.AddJavascriptSource("k2bfsg/roleadduser.js", "?20243122141750", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID_"+sGXsfl_64_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_64_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID_"+sGXsfl_64_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_64_fel_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB4Q0( ) ;
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
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 65,'',false,'"+sGXsfl_64_idx+"',64)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_64_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_64_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         AV41MultiRowItemSelected_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV41MultiRowItemSelected_Grid));
         AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_grid_Internalname,StringUtil.BoolToStr( AV41MultiRowItemSelected_Grid),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,65);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'"+sGXsfl_64_idx+"',64)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV43Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,66);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'',false,'"+sGXsfl_64_idx+"',64)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGuid_Internalname,StringUtil.RTrim( AV30Guid),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGuid_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavGuid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes4Q2( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_64_idx = ((subGrid_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         chkavCheckall_grid.Name = "vCHECKALL_GRID";
         chkavCheckall_grid.WebTags = "";
         chkavCheckall_grid.Caption = "";
         AssignProp("", false, chkavCheckall_grid_Internalname, "TitleCaption", chkavCheckall_grid.Caption, true);
         chkavCheckall_grid.CheckedValue = "false";
         AV12CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV12CheckAll_Grid));
         AssignAttri("", false, "AV12CheckAll_Grid", AV12CheckAll_Grid);
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_64_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_64_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         AV41MultiRowItemSelected_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV41MultiRowItemSelected_Grid));
         AssignAttri("", false, chkavMultirowitemselected_grid_Internalname, AV41MultiRowItemSelected_Grid);
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.SendWebValue( context.GetMessage( "K2BT_GAM_Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "K2BT_GUID", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV41MultiRowItemSelected_Grid)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV43Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV30Guid)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGuid_Enabled), 5, 0, ".", "")));
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
         edtavRolename_Internalname = "vROLENAME";
         divTable_container_rolename_Internalname = "TABLE_CONTAINER_ROLENAME";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divAttributes_content_Internalname = "ATTRIBUTES_CONTENT";
         Attributes_Internalname = "ATTRIBUTES";
         edtavGenericfilter_grid_Internalname = "vGENERICFILTER_GRID";
         divLayoutdefined_table8_grid_Internalname = "LAYOUTDEFINED_TABLE8_GRID";
         divLayoutdefined_table9_grid_Internalname = "LAYOUTDEFINED_TABLE9_GRID";
         divLayoutdefined_onlygenericfilterlayout_grid_Internalname = "LAYOUTDEFINED_ONLYGENERICFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         divLayoutdefined_filtercontainersection_grid_Internalname = "LAYOUTDEFINED_FILTERCONTAINERSECTION_GRID";
         bttAddselected_Internalname = "ADDSELECTED";
         divActions_grid_topright_Internalname = "ACTIONS_GRID_TOPRIGHT";
         divLayoutdefined_table7_grid_Internalname = "LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = "LAYOUTDEFINED_TABLE10_GRID";
         chkavCheckall_grid_Internalname = "vCHECKALL_GRID";
         chkavMultirowitemselected_grid_Internalname = "vMULTIROWITEMSELECTED_GRID";
         edtavName_Internalname = "vNAME";
         edtavGuid_Internalname = "vGUID";
         divTablegridcontainer_grid_Internalname = "TABLEGRIDCONTAINER_GRID";
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
         chkavCheckall_grid.Caption = "";
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
         tblI_noresultsfoundtablename_grid_Visible = 1;
         subGrid_Sortable = 0;
         chkavCheckall_grid.Enabled = 1;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         bttAddselected_Visible = 1;
         edtavGenericfilter_grid_Jsonclick = "";
         edtavGenericfilter_grid_Enabled = 1;
         edtavRolename_Jsonclick = "";
         edtavRolename_Enabled = 1;
         Attributes_Containseditableform = Convert.ToBoolean( 0);
         Attributes_Showborders = Convert.ToBoolean( -1);
         Attributes_Open = Convert.ToBoolean( -1);
         Attributes_Collapsible = Convert.ToBoolean( 0);
         Attributes_Title = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "K2BT_GAM_Roleadduser", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV30Guid',fld:'vGUID',pic:'',hsh:true},{av:'AV25Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV23GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV24GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV46RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV15CurrentAvailableUser',fld:'vCURRENTAVAILABLEUSER',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV16CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV24GenericFilter_PreviousValue_Grid',fld:'vGENERICFILTER_PREVIOUSVALUE_GRID',pic:'',hsh:true},{av:'AV25Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV8RoleName',fld:'vROLENAME',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E154Q2',iparms:[{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV23GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'AV25Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E164Q2',iparms:[{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV30Guid',fld:'vGUID',pic:'',hsh:true},{av:'AV25Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV23GenericFilter_Grid',fld:'vGENERICFILTER_GRID',pic:''},{av:'AV46RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV15CurrentAvailableUser',fld:'vCURRENTAVAILABLEUSER',pic:'ZZZ9',hsh:true},{av:'AV59Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV35I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV41MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV25Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9'},{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV15CurrentAvailableUser',fld:'vCURRENTAVAILABLEUSER',pic:'ZZZ9',hsh:true},{av:'AV43Name',fld:'vNAME',pic:'',hsh:true},{av:'AV30Guid',fld:'vGUID',pic:'',hsh:true}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK","{handler:'E174Q2',iparms:[{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV30Guid',fld:'vGUID',grid:64,pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'GRID',grid:64,prop:'GridRC',grid:64},{av:'AV41MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:64,pic:''},{av:'AV43Name',fld:'vNAME',grid:64,pic:'',hsh:true},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'}]");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK",",oparms:[{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("VCHECKALL_GRID.CLICK","{handler:'E114Q2',iparms:[{av:'AV41MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:64,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'GRID',grid:64,prop:'GridRC',grid:64},{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV30Guid',fld:'vGUID',grid:64,pic:'',hsh:true},{av:'AV43Name',fld:'vNAME',grid:64,pic:'',hsh:true}]");
         setEventMetadata("VCHECKALL_GRID.CLICK",",oparms:[{av:'AV41MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV13ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV12CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV14CountSelectedItems_Grid',fld:'vCOUNTSELECTEDITEMS_GRID',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'}]}");
         setEventMetadata("'E_ADDSELECTED'","{handler:'E124Q2',iparms:[{av:'AV11AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV40MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV50SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV46RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV47S_Guid',fld:'vS_GUID',pic:''},{av:'AV20FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''}]");
         setEventMetadata("'E_ADDSELECTED'",",oparms:[{av:'AV50SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV47S_Guid',fld:'vS_GUID',pic:''},{av:'AV20FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV40MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Guid',iparms:[]");
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
         AV24GenericFilter_PreviousValue_Grid = "";
         AV11AllSelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV13ClassCollection_Grid = new GxSimpleCollection<string>();
         AV59Pgmname = "";
         AV23GenericFilter_Grid = "";
         AV30Guid = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV50SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "test");
         AV47S_Guid = "";
         AV20FieldValues_Grid = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "test");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucAttributes = new GXUserControl();
         TempTags = "";
         AV8RoleName = "";
         bttAddselected_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV43Name = "";
         AV34HttpRequest = new GxHttpRequest( context);
         AV6GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV49SelectedItem_Grid = new SdtK2BSelectionItem(context);
         GridRow = new GXWebRow();
         AV53UserFilter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV22GAMUsers = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV17Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV56GAMAvailableUsers = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         AV7GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV29GridStateKey = "";
         AV27GridState = new SdtK2BGridState(context);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV48S_Name = "";
         GXt_char1 = "";
         AV19FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
         AV5Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV38Message = new GeneXus.Utils.SdtMessages_Message(context);
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleadduser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleadduser__default(),
            new Object[][] {
            }
         );
         AV59Pgmname = "K2BFSG.RoleAddUser";
         /* GeneXus formulas. */
         AV59Pgmname = "K2BFSG.RoleAddUser";
         edtavRolename_Enabled = 0;
         edtavName_Enabled = 0;
         edtavGuid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV16CurrentPage_Grid ;
      private short AV14CountSelectedItems_Grid ;
      private short AV25Grid_SelectedRows ;
      private short AV35I_LoadCount_Grid ;
      private short AV15CurrentAvailableUser ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV42MultiRowIterator_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GRID_nEOF ;
      private short AV36Index_Grid ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_64 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_64_idx=1 ;
      private int edtavRolename_Enabled ;
      private int edtavGenericfilter_grid_Enabled ;
      private int bttAddselected_Visible ;
      private int subGrid_Islastpage ;
      private int edtavName_Enabled ;
      private int edtavGuid_Enabled ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV57GXV1 ;
      private int AV58GXV2 ;
      private int AV60GXV3 ;
      private int nGXsfl_64_fel_idx=1 ;
      private int AV63GXV4 ;
      private int AV64GXV5 ;
      private int AV65GXV6 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavName_Visible ;
      private int edtavGuid_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV46RoleId ;
      private long wcpOAV46RoleId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV24GenericFilter_PreviousValue_Grid ;
      private string AV59Pgmname ;
      private string AV23GenericFilter_Grid ;
      private string AV30Guid ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV47S_Guid ;
      private string Attributes_Title ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string Attributes_Internalname ;
      private string divAttributes_content_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_rolename_Internalname ;
      private string edtavRolename_Internalname ;
      private string TempTags ;
      private string AV8RoleName ;
      private string edtavRolename_Jsonclick ;
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
      private string divActions_grid_topright_Internalname ;
      private string bttAddselected_Internalname ;
      private string bttAddselected_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divTablegridcontainer_grid_Internalname ;
      private string chkavCheckall_grid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_grid_Internalname ;
      private string AV43Name ;
      private string edtavName_Internalname ;
      private string edtavGuid_Internalname ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string AV48S_Name ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string GXt_char1 ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavGuid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckAll_Grid ;
      private bool AV40MultiRowHasNext_Grid ;
      private bool Attributes_Collapsible ;
      private bool Attributes_Open ;
      private bool Attributes_Showborders ;
      private bool Attributes_Containseditableform ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV41MultiRowItemSelected_Grid ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV44Reload_Grid ;
      private bool AV18Exit_Grid ;
      private bool AV33HasUser ;
      private bool AV31HasError ;
      private bool AV37IsOK ;
      private string AV29GridStateKey ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucAttributes ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCheckall_grid ;
      private GXCheckbox chkavMultirowitemselected_grid ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV34HttpRequest ;
      private GxSimpleCollection<string> AV13ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV17Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV22GAMUsers ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV56GAMAvailableUsers ;
      private GXBaseCollection<SdtK2BSelectionItem> AV11AllSelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem> AV50SelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV20FieldValues_Grid ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV5Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV6GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV7GAMUser ;
      private SdtK2BSelectionItem AV49SelectedItem_Grid ;
      private SdtK2BSelectionItem_FieldValuesItem AV19FieldValue_Grid ;
      private SdtK2BGridState AV27GridState ;
      private SdtK2BGridState_FilterValue AV28GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV38Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV53UserFilter ;
   }

   public class roleadduser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class roleadduser__default : DataStoreHelperBase, IDataStoreHelper
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
