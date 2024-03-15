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
   public class tabbedviewforuniversalsearch : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public tabbedviewforuniversalsearch( )
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

      public tabbedviewforuniversalsearch( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> aP1_Tabs ,
                           string aP2_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Tabs = aP1_Tabs;
         this.AV15TabCode = aP2_TabCode;
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
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV18Tabs);
                  AV15TabCode = GetPar( "TabCode");
                  AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV18Tabs,(string)AV15TabCode});
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
            PA122( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS122( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
            context.SendWebValue( context.GetMessage( "K2 BTabbed View For Layout Aries Universal Search", "")) ;
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
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("k2btools.designsystems.aries.tabbedviewforuniversalsearch.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV15TabCode))}, new string[] {"Gx_mode","Tabs","TabCode"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LastTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SelectedTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15TabCode", StringUtil.RTrim( wcpOAV15TabCode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTABS", AV18Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTABS", AV18Tabs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LastTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SelectedTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABCODE", StringUtil.RTrim( AV15TabCode));
      }

      protected void RenderHtmlCloseForm122( )
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
            if ( ! ( WebComp_Component == null ) )
            {
               WebComp_Component.componentjscripts();
            }
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
         return "K2BTools.DesignSystems.Aries.TabbedViewForUniversalSearch" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2 BTabbed View For Layout Aries Universal Search", "") ;
      }

      protected void WB120( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btools.designsystems.aries.tabbedviewforuniversalsearch.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_TabContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabs_Internalname, lblTabs_Caption, "", "", lblTabs_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_K2BTools\\DesignSystems\\Aries\\TabbedViewForUniversalSearch.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging" + " " + ((StringUtil.StrCmp(imgTabprevious_gximage, "")==0) ? "GX_Image_K2BTabGroupPrevious_Class" : "GX_Image_"+imgTabprevious_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ab84de32-929a-4946-a007-1b4c50d1e214", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgTabprevious_Internalname, sImgUrl, imgTabprevious_Link, "", "", context.GetTheme( ), imgTabprevious_Visible, 1, "", context.GetMessage( "Previous Tab", ""), 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\TabbedViewForUniversalSearch.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging" + " " + ((StringUtil.StrCmp(imgTabnext_gximage, "")==0) ? "GX_Image_K2BTabGroupNext_Class" : "GX_Image_"+imgTabnext_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e67e1229-b202-42dc-b64c-894bf5de2fcd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgTabnext_Internalname, sImgUrl, imgTabnext_Link, "", "", context.GetTheme( ), imgTabnext_Visible, 1, "", context.GetMessage( "Next Tab", ""), 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\TabbedViewForUniversalSearch.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsSection_TabbedView", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0008"+"", StringUtil.RTrim( WebComp_Component_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0008"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Component_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent), StringUtil.Lower( WebComp_Component_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0008"+"");
                  }
                  WebComp_Component.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponent), StringUtil.Lower( WebComp_Component_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START122( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2 BTabbed View For Layout Aries Universal Search", ""), 0) ;
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
               STRUP120( ) ;
            }
         }
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                                 STRUP120( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E11122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
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
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
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
                        if ( nCmpId == 8 )
                        {
                           OldComponent = cgiGet( sPrefix+"W0008");
                           if ( ( StringUtil.Len( OldComponent) == 0 ) || ( StringUtil.StrCmp(OldComponent, WebComp_Component_Component) != 0 ) )
                           {
                              WebComp_Component = getWebComponent(GetType(), "GeneXus.Programs", OldComponent, new Object[] {context} );
                              WebComp_Component.ComponentInit();
                              WebComp_Component.Name = "OldComponent";
                              WebComp_Component_Component = OldComponent;
                           }
                           if ( StringUtil.Len( WebComp_Component_Component) != 0 )
                           {
                              WebComp_Component.componentprocess(sPrefix+"W0008", "", sEvt);
                           }
                           WebComp_Component_Component = OldComponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm122( ) ;
            }
         }
      }

      protected void PA122( )
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
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E11122 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Component_Component) != 0 )
               {
                  WebComp_Component.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12122 ();
            WB120( ) ;
         }
      }

      protected void send_integrity_lvl_hashes122( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LastTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SelectedTab), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV15TabCode = cgiGet( sPrefix+"wcpOAV15TabCode");
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

      protected void E11122( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'FINDTABINDEX' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SCROLLTABS' */
         S122 ();
         if (returnInSub) return;
         GXt_char1 = "";
         new GeneXus.Programs.k2btools.tabbedview.gettabsmarkup(context ).execute(  AV18Tabs,  AV5FirstTab,  AV11LastTab,  AV13SelectedTab,  Gx_mode, out  GXt_char1) ;
         lblTabs_Caption = GXt_char1;
         AssignProp(sPrefix, false, lblTabs_Internalname, "Caption", lblTabs_Caption, true);
         if ( ( AV13SelectedTab > 0 ) && ( AV13SelectedTab <= AV18Tabs.Count ) )
         {
            AV22WebComponentUrl = ((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV13SelectedTab)).gxTpr_Webcomponent;
            /* Object Property */
            gxDynCompUrl = AV22WebComponentUrl;
            if ( ! IsSameComponent( WebComp_Component_Component, gxDynCompUrl) )
            {
               WebComp_Component = getWebComponent(GetType(), "GeneXus.Programs", gxDynCompUrl, new Object[] {context} );
               WebComp_Component.ComponentInit();
               WebComp_Component.Name = "gxDynCompUrl";
               WebComp_Component_Component = gxDynCompUrl;
            }
            else
            {
               WebComp_Component.setparmsfromurl(gxDynCompUrl);
            }
            if ( StringUtil.Len( WebComp_Component_Component) != 0 )
            {
               WebComp_Component.setjustcreated();
               WebComp_Component.componentprepare(new Object[] {(string)sPrefix+"W0008",(string)""});
               WebComp_Component.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Component )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0008"+"");
               WebComp_Component.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'FINDTABINDEX' Routine */
         returnInSub = false;
         AV6Found = false;
         AV8Index = 1;
         while ( AV8Index <= AV18Tabs.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV8Index)).gxTpr_Code, AV15TabCode) == 0 )
            {
               AV13SelectedTab = AV8Index;
               AssignAttri(sPrefix, false, "AV13SelectedTab", StringUtil.LTrimStr( (decimal)(AV13SelectedTab), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
               AV6Found = true;
               if (true) break;
            }
            AV8Index = (short)(AV8Index+1);
         }
         if ( ! AV6Found && ( AV18Tabs.Count > 0 ) )
         {
            AV13SelectedTab = 1;
            AssignAttri(sPrefix, false, "AV13SelectedTab", StringUtil.LTrimStr( (decimal)(AV13SelectedTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13SelectedTab), "ZZZ9"), context));
         }
      }

      protected void S122( )
      {
         /* 'SCROLLTABS' Routine */
         returnInSub = false;
         AV24TotalTabs = 8;
         AV23CurrentPage = (short)((AV13SelectedTab-1)/ (decimal)(AV24TotalTabs));
         AV5FirstTab = (short)(AV23CurrentPage*AV24TotalTabs+1);
         AssignAttri(sPrefix, false, "AV5FirstTab", StringUtil.LTrimStr( (decimal)(AV5FirstTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         AV11LastTab = (short)(AV5FirstTab+AV24TotalTabs-1);
         AssignAttri(sPrefix, false, "AV11LastTab", StringUtil.LTrimStr( (decimal)(AV11LastTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         if ( AV11LastTab > AV18Tabs.Count )
         {
            AV11LastTab = (short)(AV18Tabs.Count);
            AssignAttri(sPrefix, false, "AV11LastTab", StringUtil.LTrimStr( (decimal)(AV11LastTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11LastTab), "ZZZ9"), context));
         }
         if ( AV5FirstTab <= AV24TotalTabs )
         {
            imgTabprevious_Visible = 0;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabprevious_Visible), 5, 0), true);
         }
         else
         {
            imgTabprevious_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV5FirstTab-AV24TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Link", imgTabprevious_Link, true);
         }
         if ( AV11LastTab >= AV18Tabs.Count )
         {
            imgTabnext_Visible = 0;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabnext_Visible), 5, 0), true);
         }
         else
         {
            imgTabnext_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV18Tabs.Item(AV5FirstTab+AV24TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Link", imgTabnext_Link, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12122( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV18Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,1);
         AV15TabCode = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV18Tabs = (string)((string)getParm(obj,1));
         sCtrlAV15TabCode = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA122( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btools\\designsystems\\aries\\tabbedviewforuniversalsearch", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA122( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV18Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,3);
            AV15TabCode = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV15TabCode = cgiGet( sPrefix+"wcpOAV15TabCode");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV15TabCode, wcpOAV15TabCode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV15TabCode = AV15TabCode;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV18Tabs = cgiGet( sPrefix+"AV18Tabs_CTRL");
         if ( StringUtil.Len( sCtrlAV18Tabs) > 0 )
         {
            AV18Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV18Tabs_PARM"), AV18Tabs);
         }
         sCtrlAV15TabCode = cgiGet( sPrefix+"AV15TabCode_CTRL");
         if ( StringUtil.Len( sCtrlAV15TabCode) > 0 )
         {
            AV15TabCode = cgiGet( sCtrlAV15TabCode);
            AssignAttri(sPrefix, false, "AV15TabCode", AV15TabCode);
         }
         else
         {
            AV15TabCode = cgiGet( sPrefix+"AV15TabCode_PARM");
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
         PA122( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS122( ) ;
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
         WS122( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV18Tabs_PARM", AV18Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV18Tabs_PARM", AV18Tabs);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18Tabs)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18Tabs_CTRL", StringUtil.RTrim( sCtrlAV18Tabs));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15TabCode_PARM", StringUtil.RTrim( AV15TabCode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15TabCode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15TabCode_CTRL", StringUtil.RTrim( sCtrlAV15TabCode));
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
         WE122( ) ;
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
         if ( ! ( WebComp_Component == null ) )
         {
            WebComp_Component.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Component == null ) )
         {
            if ( StringUtil.Len( WebComp_Component_Component) != 0 )
            {
               WebComp_Component.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221324210", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/tabbedviewforuniversalsearch.js", "?202431221324210", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTabs_Internalname = sPrefix+"TABS";
         imgTabprevious_Internalname = sPrefix+"TABPREVIOUS";
         imgTabnext_Internalname = sPrefix+"TABNEXT";
         divTabcontainer_Internalname = sPrefix+"TABCONTAINER";
         divSection1_Internalname = sPrefix+"SECTION1";
         Form.Internalname = sPrefix+"FORM";
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
         imgTabnext_Visible = 1;
         imgTabnext_Link = "";
         imgTabprevious_Visible = 1;
         imgTabprevious_Link = "";
         lblTabs_Caption = context.GetMessage( "Tabs", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV18Tabs',fld:'vTABS',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV15TabCode',fld:'vTABCODE',pic:''},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblTabs_Caption',ctrl:'TABS',prop:'Caption'},{ctrl:'COMPONENT'},{av:'AV13SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV11LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'imgTabprevious_Visible',ctrl:'TABPREVIOUS',prop:'Visible'},{av:'imgTabprevious_Link',ctrl:'TABPREVIOUS',prop:'Link'},{av:'imgTabnext_Visible',ctrl:'TABNEXT',prop:'Visible'},{av:'imgTabnext_Link',ctrl:'TABNEXT',prop:'Link'}]}");
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
         AV18Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "test");
         wcpOGx_mode = "";
         wcpOAV15TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblTabs_Jsonclick = "";
         ClassString = "";
         imgTabprevious_gximage = "";
         StyleString = "";
         sImgUrl = "";
         imgTabnext_gximage = "";
         WebComp_Component_Component = "";
         gxDynCompUrl = "";
         OldComponent = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_char1 = "";
         AV22WebComponentUrl = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV18Tabs = "";
         sCtrlAV15TabCode = "";
         WebComp_Component = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short AV5FirstTab ;
      private short AV11LastTab ;
      private short AV13SelectedTab ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV8Index ;
      private short AV24TotalTabs ;
      private short AV23CurrentPage ;
      private short nGXWrapped ;
      private int imgTabprevious_Visible ;
      private int imgTabnext_Visible ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV15TabCode ;
      private string wcpOGx_mode ;
      private string wcpOAV15TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divTabcontainer_Internalname ;
      private string lblTabs_Internalname ;
      private string lblTabs_Caption ;
      private string lblTabs_Jsonclick ;
      private string ClassString ;
      private string imgTabprevious_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgTabprevious_Internalname ;
      private string imgTabprevious_Link ;
      private string imgTabnext_gximage ;
      private string imgTabnext_Internalname ;
      private string imgTabnext_Link ;
      private string divSection1_Internalname ;
      private string WebComp_Component_Component ;
      private string gxDynCompUrl ;
      private string OldComponent ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private string sCtrlGx_mode ;
      private string sCtrlAV18Tabs ;
      private string sCtrlAV15TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Component ;
      private bool AV6Found ;
      private string AV22WebComponentUrl ;
      private GXWebComponent WebComp_Component ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV18Tabs ;
   }

}
