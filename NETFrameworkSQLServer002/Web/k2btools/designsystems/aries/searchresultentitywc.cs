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
namespace GeneXus.Programs.k2btools.designsystems.aries {
   public class searchresultentitywc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public searchresultentitywc( )
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

      public searchresultentitywc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchCriteriaIn ,
                           string aP1_EntityName )
      {
         this.AV26SearchCriteriaIn = aP0_SearchCriteriaIn;
         this.AV11EntityName = aP1_EntityName;
         executePrivate();
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "SearchCriteriaIn");
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
                  AV26SearchCriteriaIn = GetPar( "SearchCriteriaIn");
                  AssignAttri(sPrefix, false, "AV26SearchCriteriaIn", AV26SearchCriteriaIn);
                  AV11EntityName = GetPar( "EntityName");
                  AssignAttri(sPrefix, false, "AV11EntityName", AV11EntityName);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV26SearchCriteriaIn,(string)AV11EntityName});
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
                  gxfirstwebparm = GetFirstPar( "SearchCriteriaIn");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SearchCriteriaIn");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Entitiesresultsgridlarge") == 0 )
               {
                  gxnrEntitiesresultsgridlarge_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Entitiesresultsgridlarge") == 0 )
               {
                  gxgrEntitiesresultsgridlarge_refresh_invoke( ) ;
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

      protected void gxnrEntitiesresultsgridlarge_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrEntitiesresultsgridlarge_newrow( ) ;
         /* End function gxnrEntitiesresultsgridlarge_newrow_invoke */
      }

      protected void gxgrEntitiesresultsgridlarge_refresh_invoke( )
      {
         AV26SearchCriteriaIn = GetPar( "SearchCriteriaIn");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24ResultsEntities);
         AV25SearchCriteria = GetPar( "SearchCriteria");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrEntitiesresultsgridlarge_refresh( AV26SearchCriteriaIn, AV24ResultsEntities, AV25SearchCriteria, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrEntitiesresultsgridlarge_refresh_invoke */
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
            PA132( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavCtlsearchresultdescriptionlarge_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlsearchresultdescriptionlarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsearchresultdescriptionlarge_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavNextpage_action_Enabled = 0;
               AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Enabled), 5, 0), true);
               WS132( ) ;
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
            context.SendWebValue( context.GetMessage( "K2 BTools Search Result Entity WCAries", "")) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2btools.designsystems.aries.searchresultentitywc.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26SearchCriteriaIn)),UrlEncode(StringUtil.RTrim(AV11EntityName))}, new string[] {"SearchCriteriaIn","EntityName"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vSEARCHCRITERIA", StringUtil.RTrim( AV25SearchCriteria));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSEARCHCRITERIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25SearchCriteria, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Resultsentities", AV24ResultsEntities);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Resultsentities", AV24ResultsEntities);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26SearchCriteriaIn", StringUtil.RTrim( wcpOAV26SearchCriteriaIn));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11EntityName", StringUtil.RTrim( wcpOAV11EntityName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSEARCHCRITERIAIN", StringUtil.RTrim( AV26SearchCriteriaIn));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESULTSENTITIES", AV24ResultsEntities);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESULTSENTITIES", AV24ResultsEntities);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vSEARCHCRITERIA", StringUtil.RTrim( AV25SearchCriteria));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSEARCHCRITERIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25SearchCriteria, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vENTITYNAME", StringUtil.RTrim( AV11EntityName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vENTITYITEMTOSKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10EntityItemToSkip), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vENTITYITEMSPROCESSED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9EntityItemsProcessed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPENDINGITEMSEXIST", AV21PendingItemsExist);
      }

      protected void RenderHtmlCloseForm132( )
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
         return "K2BTools.DesignSystems.Aries.SearchResultEntityWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2 BTools Search Result Entity WCAries", "") ;
      }

      protected void WB130( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btools.designsystems.aries.searchresultentitywc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_SearchResultContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_6_132( true) ;
         }
         else
         {
            wb_table1_6_132( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_132e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            EntitiesresultsgridlargeContainer.SetIsFreestyle(true);
            EntitiesresultsgridlargeContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV29GXV1 = nGXsfl_12_idx;
               if ( subEntitiesresultsgridlarge_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+sPrefix+"EntitiesresultsgridlargeContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Entitiesresultsgridlarge", EntitiesresultsgridlargeContainer, subEntitiesresultsgridlarge_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"EntitiesresultsgridlargeContainerData", EntitiesresultsgridlargeContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"EntitiesresultsgridlargeContainerData"+"V", EntitiesresultsgridlargeContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"EntitiesresultsgridlargeContainerData"+"V"+"\" value='"+EntitiesresultsgridlargeContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNextpage_action_Internalname, context.GetMessage( "Next Page_Action", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNextpage_action_Internalname, StringUtil.RTrim( AV20NextPage_Action), StringUtil.RTrim( context.localUtil.Format( AV20NextPage_Action, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_NEXTPAGE\\'."+"'", "", "", "", "", edtavNextpage_action_Jsonclick, 5, "Attribute", "", "", "", "", edtavNextpage_action_Visible, edtavNextpage_action_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_K2BTools\\DesignSystems\\Aries\\SearchResultEntityWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV29GXV1 = nGXsfl_12_idx;
                  if ( subEntitiesresultsgridlarge_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+sPrefix+"EntitiesresultsgridlargeContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Entitiesresultsgridlarge", EntitiesresultsgridlargeContainer, subEntitiesresultsgridlarge_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"EntitiesresultsgridlargeContainerData", EntitiesresultsgridlargeContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"EntitiesresultsgridlargeContainerData"+"V", EntitiesresultsgridlargeContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"EntitiesresultsgridlargeContainerData"+"V"+"\" value='"+EntitiesresultsgridlargeContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START132( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2 BTools Search Result Entity WCAries", ""), 0) ;
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
               STRUP130( ) ;
            }
         }
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
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
                                 STRUP130( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_NEXTPAGE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_NextPage' */
                                    E11132 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavNextpage_action_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 29), "ENTITIESRESULTSGRIDLARGE.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV29GXV1 = nGXsfl_12_idx;
                              if ( ( AV24ResultsEntities.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
                              {
                                 AV24ResultsEntities.CurrentItem = ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1));
                                 AV27SearchResultTitle = cgiGet( edtavSearchresulttitle_Internalname);
                                 AssignAttri(sPrefix, false, edtavSearchresulttitle_Internalname, AV27SearchResultTitle);
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
                                          GX_FocusControl = edtavNextpage_action_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12132 ();
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
                                          GX_FocusControl = edtavNextpage_action_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13132 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTITIESRESULTSGRIDLARGE.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNextpage_action_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E14132 ();
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
                                       STRUP130( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNextpage_action_Internalname;
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

      protected void WE132( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm132( ) ;
            }
         }
      }

      protected void PA132( )
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
               GX_FocusControl = edtavNextpage_action_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrEntitiesresultsgridlarge_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subEntitiesresultsgridlarge_Islastpage==1)&&(nGXsfl_12_idx+1>subEntitiesresultsgridlarge_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( EntitiesresultsgridlargeContainer)) ;
         /* End function gxnrEntitiesresultsgridlarge_newrow */
      }

      protected void gxgrEntitiesresultsgridlarge_refresh( string AV26SearchCriteriaIn ,
                                                           GXBaseCollection<SdtK2BSearchResult_Item> AV24ResultsEntities ,
                                                           string AV25SearchCriteria ,
                                                           string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ENTITIESRESULTSGRIDLARGE_nCurrentRecord = 0;
         RF132( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrEntitiesresultsgridlarge_refresh */
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
         RF132( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCtlsearchresultdescriptionlarge_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsearchresultdescriptionlarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsearchresultdescriptionlarge_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         edtavNextpage_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Enabled), 5, 0), true);
      }

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            EntitiesresultsgridlargeContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13132 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         EntitiesresultsgridlargeContainer.AddObjectProperty("GridName", "Entitiesresultsgridlarge");
         EntitiesresultsgridlargeContainer.AddObjectProperty("CmpContext", sPrefix);
         EntitiesresultsgridlargeContainer.AddObjectProperty("InMasterPage", "false");
         EntitiesresultsgridlargeContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0, ".", "")));
         EntitiesresultsgridlargeContainer.AddObjectProperty("Class", StringUtil.RTrim( "K2BTools_SearchGrid"));
         EntitiesresultsgridlargeContainer.AddObjectProperty("Class", "K2BTools_SearchGrid");
         EntitiesresultsgridlargeContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         EntitiesresultsgridlargeContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         EntitiesresultsgridlargeContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Backcolorstyle), 1, 0, ".", "")));
         EntitiesresultsgridlargeContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0, ".", "")));
         EntitiesresultsgridlargeContainer.PageSize = subEntitiesresultsgridlarge_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            E14132 ();
            wbEnd = 12;
            WB130( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes132( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vSEARCHCRITERIA", StringUtil.RTrim( AV25SearchCriteria));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSEARCHCRITERIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25SearchCriteria, "")), context));
      }

      protected int subEntitiesresultsgridlarge_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subEntitiesresultsgridlarge_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subEntitiesresultsgridlarge_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subEntitiesresultsgridlarge_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavCtlsearchresultdescriptionlarge_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsearchresultdescriptionlarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsearchresultdescriptionlarge_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         edtavNextpage_action_Enabled = 0;
         AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12132 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Resultsentities"), AV24ResultsEntities);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESULTSENTITIES"), AV24ResultsEntities);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV26SearchCriteriaIn = cgiGet( sPrefix+"wcpOAV26SearchCriteriaIn");
            wcpOAV11EntityName = cgiGet( sPrefix+"wcpOAV11EntityName");
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_12_fel_idx = 0;
            while ( nGXsfl_12_fel_idx < nRC_GXsfl_12 )
            {
               nGXsfl_12_fel_idx = ((subEntitiesresultsgridlarge_Islastpage==1)&&(nGXsfl_12_fel_idx+1>subEntitiesresultsgridlarge_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_fel_idx+1);
               sGXsfl_12_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_122( ) ;
               AV29GXV1 = nGXsfl_12_fel_idx;
               if ( ( AV24ResultsEntities.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
               {
                  AV24ResultsEntities.CurrentItem = ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1));
                  AV27SearchResultTitle = cgiGet( edtavSearchresulttitle_Internalname);
               }
            }
            if ( nGXsfl_12_fel_idx == 0 )
            {
               nGXsfl_12_idx = 1;
               sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
               SubsflControlProps_122( ) ;
            }
            nGXsfl_12_fel_idx = 1;
            /* Read variables values. */
            AV20NextPage_Action = cgiGet( edtavNextpage_action_Internalname);
            AssignAttri(sPrefix, false, "AV20NextPage_Action", AV20NextPage_Action);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12132 ();
         if (returnInSub) return;
      }

      protected void E12132( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S112 ();
            if (returnInSub) return;
         }
         AV20NextPage_Action = context.GetMessage( "K2BT_NextPage", "");
         AssignAttri(sPrefix, false, "AV20NextPage_Action", AV20NextPage_Action);
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E13132( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         edtavNextpage_action_Visible = 0;
         AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Visible), 5, 0), true);
         AV24ResultsEntities = new GXBaseCollection<SdtK2BSearchResult_Item>( context, "Item", "test");
         gx_BV12 = true;
         AV10EntityItemToSkip = 0;
         AssignAttri(sPrefix, false, "AV10EntityItemToSkip", StringUtil.LTrimStr( (decimal)(AV10EntityItemToSkip), 4, 0));
         AV25SearchCriteria = AV26SearchCriteriaIn;
         AssignAttri(sPrefix, false, "AV25SearchCriteria", AV25SearchCriteria);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSEARCHCRITERIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25SearchCriteria, "")), context));
         /* Execute user subroutine: 'LOADENTITIESRESULTPAGE' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         AV25SearchCriteria = AV26SearchCriteriaIn;
         AssignAttri(sPrefix, false, "AV25SearchCriteria", AV25SearchCriteria);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSEARCHCRITERIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV25SearchCriteria, "")), context));
      }

      private void E14132( )
      {
         /* Entitiesresultsgridlarge_Load Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV24ResultsEntities.Count )
         {
            AV24ResultsEntities.CurrentItem = ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1));
            AV27SearchResultTitle = ((SdtK2BSearchResult_Item)(AV24ResultsEntities.CurrentItem)).gxTpr_Searchresulttitle;
            AssignAttri(sPrefix, false, edtavSearchresulttitle_Internalname, AV27SearchResultTitle);
            edtavSearchresulttitle_Link = ((SdtK2BSearchResult_Item)(AV24ResultsEntities.CurrentItem)).gxTpr_Searchresultlink;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               context.DoAjaxLoad(12, EntitiesresultsgridlargeRow);
            }
            AV29GXV1 = (int)(AV29GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'LOADENTITIESRESULTPAGE' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SearchCriteria)) )
         {
            new k2btoolsgetsearchresults(context ).execute(  AV11EntityName,  AV25SearchCriteria+"*",  12,  AV10EntityItemToSkip, out  AV9EntityItemsProcessed, out  AV21PendingItemsExist, out  AV24ResultsEntities) ;
            gx_BV12 = true;
            AssignAttri(sPrefix, false, "AV9EntityItemsProcessed", StringUtil.LTrimStr( (decimal)(AV9EntityItemsProcessed), 4, 0));
            AssignAttri(sPrefix, false, "AV21PendingItemsExist", AV21PendingItemsExist);
         }
         AV10EntityItemToSkip = (short)(AV9EntityItemsProcessed+1);
         AssignAttri(sPrefix, false, "AV10EntityItemToSkip", StringUtil.LTrimStr( (decimal)(AV10EntityItemToSkip), 4, 0));
         if ( AV24ResultsEntities.Count == 0 )
         {
            subEntitiesresultsgridlarge_Visible = 0;
            AssignProp(sPrefix, false, sPrefix+"EntitiesresultsgridlargeContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0), true);
            tblNoresultsfoundtable_Visible = 1;
            AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         }
         else
         {
            subEntitiesresultsgridlarge_Visible = 1;
            AssignProp(sPrefix, false, sPrefix+"EntitiesresultsgridlargeContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0), true);
            tblNoresultsfoundtable_Visible = 0;
            AssignProp(sPrefix, false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         }
         if ( AV21PendingItemsExist )
         {
            edtavNextpage_action_Visible = 1;
            AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Visible), 5, 0), true);
         }
         else
         {
            edtavNextpage_action_Visible = 0;
            AssignProp(sPrefix, false, edtavNextpage_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNextpage_action_Visible), 5, 0), true);
         }
      }

      protected void E11132( )
      {
         AV29GXV1 = nGXsfl_12_idx;
         if ( ( AV29GXV1 > 0 ) && ( AV24ResultsEntities.Count >= AV29GXV1 ) )
         {
            AV24ResultsEntities.CurrentItem = ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1));
         }
         /* 'E_NextPage' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_NEXTPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24ResultsEntities", AV24ResultsEntities);
         nGXsfl_12_bak_idx = nGXsfl_12_idx;
         gxgrEntitiesresultsgridlarge_refresh( AV26SearchCriteriaIn, AV24ResultsEntities, AV25SearchCriteria, sPrefix) ;
         nGXsfl_12_idx = nGXsfl_12_bak_idx;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
      }

      protected void S142( )
      {
         /* 'U_NEXTPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADENTITIESRESULTPAGE' */
         S152 ();
         if (returnInSub) return;
      }

      protected void wb_table1_6_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblNoresultsfoundtable_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblNoresultsfoundtable_Internalname, tblNoresultsfoundtable_Internalname, "", "K2BToolsTable_NoResultsFoundUniversalSearch", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, context.GetMessage( "No results found", ""), "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\SearchResultEntityWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_132e( true) ;
         }
         else
         {
            wb_table1_6_132e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26SearchCriteriaIn = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV26SearchCriteriaIn", AV26SearchCriteriaIn);
         AV11EntityName = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV11EntityName", AV11EntityName);
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
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
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
         sCtrlAV26SearchCriteriaIn = (string)((string)getParm(obj,0));
         sCtrlAV11EntityName = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA132( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btools\\designsystems\\aries\\searchresultentitywc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA132( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV26SearchCriteriaIn = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV26SearchCriteriaIn", AV26SearchCriteriaIn);
            AV11EntityName = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV11EntityName", AV11EntityName);
         }
         wcpOAV26SearchCriteriaIn = cgiGet( sPrefix+"wcpOAV26SearchCriteriaIn");
         wcpOAV11EntityName = cgiGet( sPrefix+"wcpOAV11EntityName");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV26SearchCriteriaIn, wcpOAV26SearchCriteriaIn) != 0 ) || ( StringUtil.StrCmp(AV11EntityName, wcpOAV11EntityName) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV26SearchCriteriaIn = AV26SearchCriteriaIn;
         wcpOAV11EntityName = AV11EntityName;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV26SearchCriteriaIn = cgiGet( sPrefix+"AV26SearchCriteriaIn_CTRL");
         if ( StringUtil.Len( sCtrlAV26SearchCriteriaIn) > 0 )
         {
            AV26SearchCriteriaIn = cgiGet( sCtrlAV26SearchCriteriaIn);
            AssignAttri(sPrefix, false, "AV26SearchCriteriaIn", AV26SearchCriteriaIn);
         }
         else
         {
            AV26SearchCriteriaIn = cgiGet( sPrefix+"AV26SearchCriteriaIn_PARM");
         }
         sCtrlAV11EntityName = cgiGet( sPrefix+"AV11EntityName_CTRL");
         if ( StringUtil.Len( sCtrlAV11EntityName) > 0 )
         {
            AV11EntityName = cgiGet( sCtrlAV11EntityName);
            AssignAttri(sPrefix, false, "AV11EntityName", AV11EntityName);
         }
         else
         {
            AV11EntityName = cgiGet( sPrefix+"AV11EntityName_PARM");
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
         PA132( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS132( ) ;
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
         WS132( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26SearchCriteriaIn_PARM", StringUtil.RTrim( AV26SearchCriteriaIn));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26SearchCriteriaIn)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26SearchCriteriaIn_CTRL", StringUtil.RTrim( sCtrlAV26SearchCriteriaIn));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11EntityName_PARM", StringUtil.RTrim( AV11EntityName));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11EntityName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11EntityName_CTRL", StringUtil.RTrim( sCtrlAV11EntityName));
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
         WE132( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221324145", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/searchresultentitywc.js", "?202431221324145", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavCtlsearchresultimagelarge_Internalname = sPrefix+"CTLSEARCHRESULTIMAGELARGE_"+sGXsfl_12_idx;
         edtavSearchresulttitle_Internalname = sPrefix+"vSEARCHRESULTTITLE_"+sGXsfl_12_idx;
         edtavCtlsearchresultdescriptionlarge_Internalname = sPrefix+"CTLSEARCHRESULTDESCRIPTIONLARGE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavCtlsearchresultimagelarge_Internalname = sPrefix+"CTLSEARCHRESULTIMAGELARGE_"+sGXsfl_12_fel_idx;
         edtavSearchresulttitle_Internalname = sPrefix+"vSEARCHRESULTTITLE_"+sGXsfl_12_fel_idx;
         edtavCtlsearchresultdescriptionlarge_Internalname = sPrefix+"CTLSEARCHRESULTDESCRIPTIONLARGE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB130( ) ;
         EntitiesresultsgridlargeRow = GXWebRow.GetNew(context,EntitiesresultsgridlargeContainer);
         if ( subEntitiesresultsgridlarge_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subEntitiesresultsgridlarge_Backstyle = 0;
            if ( StringUtil.StrCmp(subEntitiesresultsgridlarge_Class, "") != 0 )
            {
               subEntitiesresultsgridlarge_Linesclass = subEntitiesresultsgridlarge_Class+"Odd";
            }
         }
         else if ( subEntitiesresultsgridlarge_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subEntitiesresultsgridlarge_Backstyle = 0;
            subEntitiesresultsgridlarge_Backcolor = subEntitiesresultsgridlarge_Allbackcolor;
            if ( StringUtil.StrCmp(subEntitiesresultsgridlarge_Class, "") != 0 )
            {
               subEntitiesresultsgridlarge_Linesclass = subEntitiesresultsgridlarge_Class+"Uniform";
            }
         }
         else if ( subEntitiesresultsgridlarge_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subEntitiesresultsgridlarge_Backstyle = 1;
            if ( StringUtil.StrCmp(subEntitiesresultsgridlarge_Class, "") != 0 )
            {
               subEntitiesresultsgridlarge_Linesclass = subEntitiesresultsgridlarge_Class+"Odd";
            }
            subEntitiesresultsgridlarge_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subEntitiesresultsgridlarge_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subEntitiesresultsgridlarge_Backstyle = 1;
            if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
            {
               subEntitiesresultsgridlarge_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subEntitiesresultsgridlarge_Class, "") != 0 )
               {
                  subEntitiesresultsgridlarge_Linesclass = subEntitiesresultsgridlarge_Class+"Even";
               }
            }
            else
            {
               subEntitiesresultsgridlarge_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subEntitiesresultsgridlarge_Class, "") != 0 )
               {
                  subEntitiesresultsgridlarge_Linesclass = subEntitiesresultsgridlarge_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subEntitiesresultsgridlarge_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
         }
         /* Table start */
         EntitiesresultsgridlargeRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblGrid2table1_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"K2BToolsSection_Card",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         EntitiesresultsgridlargeRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         EntitiesresultsgridlargeRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablelarge_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-4",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         EntitiesresultsgridlargeRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",context.GetMessage( "SearchResultImage", ""),(string)"col-sm-3 K2BTools_SearchResultImageLabel",(short)0,(bool)true,(string)""});
         /* Static Bitmap Variable */
         ClassString = "K2BTools_SearchResultImage" + " " + ((StringUtil.StrCmp(edtavCtlsearchresultimagelarge_gximage, "")==0) ? "" : "GX_Image_"+edtavCtlsearchresultimagelarge_gximage+"_Class");
         StyleString = "";
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1)).gxTpr_Searchresultimage)) ? ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1)).gxTpr_Searchresultimage_gxi : context.PathToRelativeUrl( ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1)).gxTpr_Searchresultimage));
         EntitiesresultsgridlargeRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsearchresultimagelarge_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-8",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable2large_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"K2BToolsTable_SearchTextContainer",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         EntitiesresultsgridlargeRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSearchresulttitle_Internalname,context.GetMessage( "Search Result Title", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         EntitiesresultsgridlargeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSearchresulttitle_Internalname,StringUtil.RTrim( AV27SearchResultTitle),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavSearchresulttitle_Link,(string)"",(string)"",(string)"",(string)edtavSearchresulttitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)50,(string)"chr",(short)1,(string)"row",(short)50,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"K2BDescription",(string)"start",(bool)true,(string)""});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         EntitiesresultsgridlargeRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         EntitiesresultsgridlargeRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsearchresultdescriptionlarge_Internalname,context.GetMessage( "SearchResultDescription", ""),(string)"col-sm-3 K2BSearchResult_DescriptionLabel",(short)0,(bool)true,(string)""});
         /* Multiple line edit */
         ClassString = "K2BSearchResult_Description";
         StyleString = "";
         ClassString = "K2BSearchResult_Description";
         StyleString = "";
         EntitiesresultsgridlargeRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsearchresultdescriptionlarge_Internalname,StringUtil.RTrim( ((SdtK2BSearchResult_Item)AV24ResultsEntities.Item(AV29GXV1)).gxTpr_Searchresultdescription),(string)"",(string)"",(short)1,(short)1,(int)edtavCtlsearchresultdescriptionlarge_Enabled,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         EntitiesresultsgridlargeRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
         {
            EntitiesresultsgridlargeContainer.CloseTag("cell");
         }
         if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
         {
            EntitiesresultsgridlargeContainer.CloseTag("row");
         }
         if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
         {
            EntitiesresultsgridlargeContainer.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes132( ) ;
         /* End of Columns property logic. */
         EntitiesresultsgridlargeContainer.AddRow(EntitiesresultsgridlargeRow);
         nGXsfl_12_idx = ((subEntitiesresultsgridlarge_Islastpage==1)&&(nGXsfl_12_idx+1>subEntitiesresultsgridlarge_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( EntitiesresultsgridlargeContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"EntitiesresultsgridlargeContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            if ( subEntitiesresultsgridlarge_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subEntitiesresultsgridlarge_Internalname, subEntitiesresultsgridlarge_Internalname, "", "K2BTools_SearchGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            EntitiesresultsgridlargeContainer.AddObjectProperty("GridName", "Entitiesresultsgridlarge");
         }
         else
         {
            EntitiesresultsgridlargeContainer.AddObjectProperty("GridName", "Entitiesresultsgridlarge");
            EntitiesresultsgridlargeContainer.AddObjectProperty("Header", subEntitiesresultsgridlarge_Header);
            EntitiesresultsgridlargeContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Class", StringUtil.RTrim( "K2BTools_SearchGrid"));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Class", "K2BTools_SearchGrid");
            EntitiesresultsgridlargeContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Backcolorstyle), 1, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Visible), 5, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("CmpContext", sPrefix);
            EntitiesresultsgridlargeContainer.AddObjectProperty("InMasterPage", "false");
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27SearchResultTitle)));
            EntitiesresultsgridlargeColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSearchresulttitle_Link));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            EntitiesresultsgridlargeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsearchresultdescriptionlarge_Enabled), 5, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddColumnProperties(EntitiesresultsgridlargeColumn);
            EntitiesresultsgridlargeContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Selectedindex), 4, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Allowselection), 1, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Selectioncolor), 9, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Allowhovering), 1, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Hoveringcolor), 9, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Allowcollapsing), 1, 0, ".", "")));
            EntitiesresultsgridlargeContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subEntitiesresultsgridlarge_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblNoresultsfoundtextblock_Internalname = sPrefix+"NORESULTSFOUNDTEXTBLOCK";
         tblNoresultsfoundtable_Internalname = sPrefix+"NORESULTSFOUNDTABLE";
         edtavCtlsearchresultimagelarge_Internalname = sPrefix+"CTLSEARCHRESULTIMAGELARGE";
         edtavSearchresulttitle_Internalname = sPrefix+"vSEARCHRESULTTITLE";
         edtavCtlsearchresultdescriptionlarge_Internalname = sPrefix+"CTLSEARCHRESULTDESCRIPTIONLARGE";
         divTable2large_Internalname = sPrefix+"TABLE2LARGE";
         divTablelarge_Internalname = sPrefix+"TABLELARGE";
         tblGrid2table1_Internalname = sPrefix+"GRID2TABLE1";
         edtavNextpage_action_Internalname = sPrefix+"vNEXTPAGE_ACTION";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subEntitiesresultsgridlarge_Internalname = sPrefix+"ENTITIESRESULTSGRIDLARGE";
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
         subEntitiesresultsgridlarge_Allowcollapsing = 0;
         edtavCtlsearchresultdescriptionlarge_Enabled = 0;
         edtavSearchresulttitle_Jsonclick = "";
         edtavSearchresulttitle_Link = "";
         edtavCtlsearchresultimagelarge_gximage = "";
         subEntitiesresultsgridlarge_Class = "K2BTools_SearchGrid";
         tblNoresultsfoundtable_Visible = 1;
         subEntitiesresultsgridlarge_Backcolorstyle = 0;
         edtavNextpage_action_Jsonclick = "";
         edtavNextpage_action_Enabled = 1;
         edtavNextpage_action_Visible = 1;
         subEntitiesresultsgridlarge_Visible = 1;
         edtavCtlsearchresultdescriptionlarge_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage'},{av:'ENTITIESRESULTSGRIDLARGE_nEOF'},{av:'AV24ResultsEntities',fld:'vRESULTSENTITIES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'nRC_GXsfl_12',ctrl:'ENTITIESRESULTSGRIDLARGE',prop:'GridRC',grid:12},{av:'sPrefix'},{av:'AV26SearchCriteriaIn',fld:'vSEARCHCRITERIAIN',pic:''},{av:'AV25SearchCriteria',fld:'vSEARCHCRITERIA',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV25SearchCriteria',fld:'vSEARCHCRITERIA',pic:'',hsh:true}]}");
         setEventMetadata("ENTITIESRESULTSGRIDLARGE.LOAD","{handler:'E14132',iparms:[{av:'AV24ResultsEntities',fld:'vRESULTSENTITIES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage'},{av:'nRC_GXsfl_12',ctrl:'ENTITIESRESULTSGRIDLARGE',prop:'GridRC',grid:12}]");
         setEventMetadata("ENTITIESRESULTSGRIDLARGE.LOAD",",oparms:[{av:'AV27SearchResultTitle',fld:'vSEARCHRESULTTITLE',pic:''},{av:'edtavSearchresulttitle_Link',ctrl:'vSEARCHRESULTTITLE',prop:'Link'}]}");
         setEventMetadata("'E_NEXTPAGE'","{handler:'E11132',iparms:[{av:'AV25SearchCriteria',fld:'vSEARCHCRITERIA',pic:'',hsh:true},{av:'AV11EntityName',fld:'vENTITYNAME',pic:''},{av:'AV10EntityItemToSkip',fld:'vENTITYITEMTOSKIP',pic:'ZZZ9'},{av:'AV9EntityItemsProcessed',fld:'vENTITYITEMSPROCESSED',pic:'ZZZ9'},{av:'AV24ResultsEntities',fld:'vRESULTSENTITIES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage'},{av:'nRC_GXsfl_12',ctrl:'ENTITIESRESULTSGRIDLARGE',prop:'GridRC',grid:12},{av:'AV21PendingItemsExist',fld:'vPENDINGITEMSEXIST',pic:''},{av:'ENTITIESRESULTSGRIDLARGE_nEOF'},{av:'sPrefix'},{av:'AV26SearchCriteriaIn',fld:'vSEARCHCRITERIAIN',pic:''}]");
         setEventMetadata("'E_NEXTPAGE'",",oparms:[{av:'AV24ResultsEntities',fld:'vRESULTSENTITIES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage'},{av:'nRC_GXsfl_12',ctrl:'ENTITIESRESULTSGRIDLARGE',prop:'GridRC',grid:12},{av:'AV21PendingItemsExist',fld:'vPENDINGITEMSEXIST',pic:''},{av:'AV9EntityItemsProcessed',fld:'vENTITYITEMSPROCESSED',pic:'ZZZ9'},{av:'AV10EntityItemToSkip',fld:'vENTITYITEMTOSKIP',pic:'ZZZ9'},{av:'subEntitiesresultsgridlarge_Visible',ctrl:'ENTITIESRESULTSGRIDLARGE',prop:'Visible'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtavNextpage_action_Visible',ctrl:'vNEXTPAGE_ACTION',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv3',iparms:[]");
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
         wcpOAV26SearchCriteriaIn = "";
         wcpOAV11EntityName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV24ResultsEntities = new GXBaseCollection<SdtK2BSearchResult_Item>( context, "Item", "test");
         AV25SearchCriteria = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         EntitiesresultsgridlargeContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         AV20NextPage_Action = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27SearchResultTitle = "";
         AV17HttpRequest = new GxHttpRequest( context);
         EntitiesresultsgridlargeRow = new GXWebRow();
         lblNoresultsfoundtextblock_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV26SearchCriteriaIn = "";
         sCtrlAV11EntityName = "";
         subEntitiesresultsgridlarge_Linesclass = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         ROClassString = "";
         subEntitiesresultsgridlarge_Header = "";
         EntitiesresultsgridlargeColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavCtlsearchresultdescriptionlarge_Enabled = 0;
         edtavNextpage_action_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short AV10EntityItemToSkip ;
      private short AV9EntityItemsProcessed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subEntitiesresultsgridlarge_Backcolorstyle ;
      private short ENTITIESRESULTSGRIDLARGE_nEOF ;
      private short nGXWrapped ;
      private short subEntitiesresultsgridlarge_Backstyle ;
      private short subEntitiesresultsgridlarge_Allowselection ;
      private short subEntitiesresultsgridlarge_Allowhovering ;
      private short subEntitiesresultsgridlarge_Allowcollapsing ;
      private short subEntitiesresultsgridlarge_Collapsed ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int edtavCtlsearchresultdescriptionlarge_Enabled ;
      private int edtavNextpage_action_Enabled ;
      private int AV29GXV1 ;
      private int subEntitiesresultsgridlarge_Visible ;
      private int edtavNextpage_action_Visible ;
      private int subEntitiesresultsgridlarge_Islastpage ;
      private int nGXsfl_12_fel_idx=1 ;
      private int tblNoresultsfoundtable_Visible ;
      private int nGXsfl_12_bak_idx=1 ;
      private int idxLst ;
      private int subEntitiesresultsgridlarge_Backcolor ;
      private int subEntitiesresultsgridlarge_Allbackcolor ;
      private int subEntitiesresultsgridlarge_Selectedindex ;
      private int subEntitiesresultsgridlarge_Selectioncolor ;
      private int subEntitiesresultsgridlarge_Hoveringcolor ;
      private long ENTITIESRESULTSGRIDLARGE_nCurrentRecord ;
      private long ENTITIESRESULTSGRIDLARGE_nFirstRecordOnPage ;
      private string AV26SearchCriteriaIn ;
      private string AV11EntityName ;
      private string wcpOAV26SearchCriteriaIn ;
      private string wcpOAV11EntityName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string AV25SearchCriteria ;
      private string edtavCtlsearchresultdescriptionlarge_Internalname ;
      private string edtavNextpage_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string sStyleString ;
      private string subEntitiesresultsgridlarge_Internalname ;
      private string TempTags ;
      private string AV20NextPage_Action ;
      private string edtavNextpage_action_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27SearchResultTitle ;
      private string edtavSearchresulttitle_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string edtavSearchresulttitle_Link ;
      private string tblNoresultsfoundtable_Internalname ;
      private string lblNoresultsfoundtextblock_Internalname ;
      private string lblNoresultsfoundtextblock_Jsonclick ;
      private string sCtrlAV26SearchCriteriaIn ;
      private string sCtrlAV11EntityName ;
      private string edtavCtlsearchresultimagelarge_Internalname ;
      private string subEntitiesresultsgridlarge_Class ;
      private string subEntitiesresultsgridlarge_Linesclass ;
      private string tblGrid2table1_Internalname ;
      private string divTablelarge_Internalname ;
      private string ClassString ;
      private string edtavCtlsearchresultimagelarge_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string divTable2large_Internalname ;
      private string ROClassString ;
      private string edtavSearchresulttitle_Jsonclick ;
      private string subEntitiesresultsgridlarge_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool AV21PendingItemsExist ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV12 ;
      private GXWebGrid EntitiesresultsgridlargeContainer ;
      private GXWebRow EntitiesresultsgridlargeRow ;
      private GXWebColumn EntitiesresultsgridlargeColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV17HttpRequest ;
      private GXBaseCollection<SdtK2BSearchResult_Item> AV24ResultsEntities ;
   }

}
