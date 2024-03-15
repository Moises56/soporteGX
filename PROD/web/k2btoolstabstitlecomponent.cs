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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2btoolstabstitlecomponent : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public k2btoolstabstitlecomponent( )
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

      public k2btoolstabstitlecomponent( IGxContext context )
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
         this.AV16Tabs = aP1_Tabs;
         this.AV13TabCode = aP2_TabCode;
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
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV16Tabs);
                  AV13TabCode = GetPar( "TabCode");
                  AssignAttri(sPrefix, false, "AV13TabCode", AV13TabCode);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV16Tabs,(string)AV13TabCode});
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
            PA0H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0H2( ) ;
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
            context.SendWebValue( "K2 BTools Tabs Title Component") ;
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
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("k2btoolstabstitlecomponent.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV13TabCode))}, new string[] {"Gx_mode","Tabs","TabCode"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9LastTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV9LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SelectedTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11SelectedTab), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13TabCode", StringUtil.RTrim( wcpOAV13TabCode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTABS", AV16Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTABS", AV16Tabs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9LastTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV9LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SelectedTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11SelectedTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABCODE", StringUtil.RTrim( AV13TabCode));
      }

      protected void RenderHtmlCloseForm0H2( )
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
         return "K2BToolsTabsTitleComponent" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2 BTools Tabs Title Component" ;
      }

      protected void WB0H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btoolstabstitlecomponent.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabcontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_TabContainer", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabs_Internalname, lblTabs_Caption, "", "", lblTabs_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_K2BToolsTabsTitleComponent.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging" + " " + ((StringUtil.StrCmp(imgTabprevious_gximage, "")==0) ? "GX_Image_K2BTabGroupPrevious_Class" : "GX_Image_"+imgTabprevious_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ab84de32-929a-4946-a007-1b4c50d1e214", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgTabprevious_Internalname, sImgUrl, imgTabprevious_Link, "", "", context.GetTheme( ), imgTabprevious_Visible, 1, "", "Previous Tab", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BToolsTabsTitleComponent.htm");
            /* Static images/pictures */
            ClassString = "ImageTabPaging" + " " + ((StringUtil.StrCmp(imgTabnext_gximage, "")==0) ? "GX_Image_K2BTabGroupNext_Class" : "GX_Image_"+imgTabnext_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e67e1229-b202-42dc-b64c-894bf5de2fcd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgTabnext_Internalname, sImgUrl, imgTabnext_Link, "", "", context.GetTheme( ), imgTabnext_Visible, 1, "", "Next Tab", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BToolsTabsTitleComponent.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         }
         wbLoad = true;
      }

      protected void START0H2( )
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
            Form.Meta.addItem("description", "K2 BTools Tabs Title Component", 0) ;
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
               STRUP0H0( ) ;
            }
         }
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E110H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E120H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0H2( ) ;
            }
         }
      }

      protected void PA0H2( )
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
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E110H2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120H2 ();
            WB0H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vFIRSTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5FirstTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLASTTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9LastTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV9LastTab), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDTAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SelectedTab), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11SelectedTab), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
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
            wcpOAV13TabCode = cgiGet( sPrefix+"wcpOAV13TabCode");
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

      protected void E110H2( )
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
         new GeneXus.Programs.k2btools.tabbedview.gettabsmarkup(context ).execute(  AV16Tabs,  AV5FirstTab,  AV9LastTab,  AV11SelectedTab,  Gx_mode, out  GXt_char1) ;
         lblTabs_Caption = GXt_char1;
         AssignProp(sPrefix, false, lblTabs_Internalname, "Caption", lblTabs_Caption, true);
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'FINDTABINDEX' Routine */
         returnInSub = false;
         AV6Found = false;
         AV7Index = 1;
         while ( AV7Index <= AV16Tabs.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV16Tabs.Item(AV7Index)).gxTpr_Code, AV13TabCode) == 0 )
            {
               AV11SelectedTab = AV7Index;
               AssignAttri(sPrefix, false, "AV11SelectedTab", StringUtil.LTrimStr( (decimal)(AV11SelectedTab), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11SelectedTab), "ZZZ9"), context));
               AV6Found = true;
               if (true) break;
            }
            AV7Index = (short)(AV7Index+1);
         }
         if ( ! AV6Found && ( AV16Tabs.Count > 0 ) )
         {
            AV11SelectedTab = 1;
            AssignAttri(sPrefix, false, "AV11SelectedTab", StringUtil.LTrimStr( (decimal)(AV11SelectedTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV11SelectedTab), "ZZZ9"), context));
         }
      }

      protected void S122( )
      {
         /* 'SCROLLTABS' Routine */
         returnInSub = false;
         AV19TotalTabs = 8;
         AV22CurrentPage = (short)((AV11SelectedTab-1)/ (decimal)(AV19TotalTabs));
         AV5FirstTab = (short)(AV22CurrentPage*AV19TotalTabs+1);
         AssignAttri(sPrefix, false, "AV5FirstTab", StringUtil.LTrimStr( (decimal)(AV5FirstTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV5FirstTab), "ZZZ9"), context));
         AV9LastTab = (short)(AV5FirstTab+AV19TotalTabs-1);
         AssignAttri(sPrefix, false, "AV9LastTab", StringUtil.LTrimStr( (decimal)(AV9LastTab), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV9LastTab), "ZZZ9"), context));
         if ( AV9LastTab > AV16Tabs.Count )
         {
            AV9LastTab = (short)(AV16Tabs.Count);
            AssignAttri(sPrefix, false, "AV9LastTab", StringUtil.LTrimStr( (decimal)(AV9LastTab), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTTAB", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV9LastTab), "ZZZ9"), context));
         }
         if ( AV5FirstTab <= AV19TotalTabs )
         {
            imgTabprevious_Visible = 0;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabprevious_Visible), 5, 0), true);
         }
         else
         {
            imgTabprevious_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV16Tabs.Item(AV5FirstTab-AV19TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabprevious_Internalname, "Link", imgTabprevious_Link, true);
         }
         if ( AV9LastTab >= AV16Tabs.Count )
         {
            imgTabnext_Visible = 0;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgTabnext_Visible), 5, 0), true);
         }
         else
         {
            imgTabnext_Link = formatLink(((SdtK2BTabOptions_K2BTabOptionsItem)AV16Tabs.Item(AV5FirstTab+AV19TotalTabs)).gxTpr_Link) ;
            AssignProp(sPrefix, false, imgTabnext_Internalname, "Link", imgTabnext_Link, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E120H2( )
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
         AV16Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,1);
         AV13TabCode = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV13TabCode", AV13TabCode);
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
         sCtrlAV16Tabs = (string)((string)getParm(obj,1));
         sCtrlAV13TabCode = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btoolstabstitlecomponent", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV16Tabs = (GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)getParm(obj,3);
            AV13TabCode = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV13TabCode", AV13TabCode);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV13TabCode = cgiGet( sPrefix+"wcpOAV13TabCode");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV13TabCode, wcpOAV13TabCode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV13TabCode = AV13TabCode;
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
         sCtrlAV16Tabs = cgiGet( sPrefix+"AV16Tabs_CTRL");
         if ( StringUtil.Len( sCtrlAV16Tabs) > 0 )
         {
            AV16Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV16Tabs_PARM"), AV16Tabs);
         }
         sCtrlAV13TabCode = cgiGet( sPrefix+"AV13TabCode_CTRL");
         if ( StringUtil.Len( sCtrlAV13TabCode) > 0 )
         {
            AV13TabCode = cgiGet( sCtrlAV13TabCode);
            AssignAttri(sPrefix, false, "AV13TabCode", AV13TabCode);
         }
         else
         {
            AV13TabCode = cgiGet( sPrefix+"AV13TabCode_PARM");
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
         PA0H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0H2( ) ;
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
         WS0H2( ) ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV16Tabs_PARM", AV16Tabs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV16Tabs_PARM", AV16Tabs);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16Tabs)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16Tabs_CTRL", StringUtil.RTrim( sCtrlAV16Tabs));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13TabCode_PARM", StringUtil.RTrim( AV13TabCode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13TabCode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13TabCode_CTRL", StringUtil.RTrim( sCtrlAV13TabCode));
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
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138143041", true, true);
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
            context.AddJavascriptSource("k2btoolstabstitlecomponent.js", "?20243138143041", false, true);
         }
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
         lblTabs_Jsonclick = "";
         lblTabs_Caption = "Tabs";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV16Tabs',fld:'vTABS',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV13TabCode',fld:'vTABCODE',pic:''},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV9LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'AV11SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblTabs_Caption',ctrl:'TABS',prop:'Caption'},{av:'AV11SelectedTab',fld:'vSELECTEDTAB',pic:'ZZZ9',hsh:true},{av:'AV5FirstTab',fld:'vFIRSTTAB',pic:'ZZZ9',hsh:true},{av:'AV9LastTab',fld:'vLASTTAB',pic:'ZZZ9',hsh:true},{av:'imgTabprevious_Visible',ctrl:'TABPREVIOUS',prop:'Visible'},{av:'imgTabprevious_Link',ctrl:'TABPREVIOUS',prop:'Link'},{av:'imgTabnext_Visible',ctrl:'TABNEXT',prop:'Visible'},{av:'imgTabnext_Link',ctrl:'TABNEXT',prop:'Link'}]}");
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
         AV16Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "test");
         wcpOGx_mode = "";
         wcpOAV13TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         imgTabprevious_gximage = "";
         StyleString = "";
         sImgUrl = "";
         imgTabnext_gximage = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV16Tabs = "";
         sCtrlAV13TabCode = "";
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short AV5FirstTab ;
      private short AV9LastTab ;
      private short AV11SelectedTab ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV7Index ;
      private short AV19TotalTabs ;
      private short AV22CurrentPage ;
      private int imgTabprevious_Visible ;
      private int imgTabnext_Visible ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV13TabCode ;
      private string wcpOGx_mode ;
      private string wcpOAV13TabCode ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private string sCtrlGx_mode ;
      private string sCtrlAV16Tabs ;
      private string sCtrlAV13TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV6Found ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV16Tabs ;
   }

}
