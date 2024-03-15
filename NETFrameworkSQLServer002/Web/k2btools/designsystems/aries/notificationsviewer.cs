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
   public class notificationsviewer : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public notificationsviewer( )
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

      public notificationsviewer( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavNotificationisread = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Notificationsgrid") == 0 )
               {
                  gxnrNotificationsgrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Notificationsgrid") == 0 )
               {
                  gxgrNotificationsgrid_refresh_invoke( ) ;
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

      protected void gxnrNotificationsgrid_newrow_invoke( )
      {
         nRC_GXsfl_21 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_21"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_21_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_21_idx = GetPar( "sGXsfl_21_idx");
         sPrefix = GetPar( "sPrefix");
         AV24MarkAsRead_Action = GetPar( "MarkAsRead_Action");
         edtavMarkasread_action_Tooltiptext = GetNextPar( );
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_21_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrNotificationsgrid_newrow( ) ;
         /* End function gxnrNotificationsgrid_newrow_invoke */
      }

      protected void gxgrNotificationsgrid_refresh_invoke( )
      {
         AV24MarkAsRead_Action = GetPar( "MarkAsRead_Action");
         edtavMarkasread_action_Tooltiptext = GetNextPar( );
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_21_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12DP_SDT_ITEM_NotificationsGrid);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrNotificationsgrid_refresh( AV24MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrNotificationsgrid_refresh_invoke */
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
            PA0Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "K2 BT_Notifications Viewer Aries", "")) ;
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
         context.AddJavascriptSource("UserControls/K2BTools.DesignSystems.Aries.NotificationsButtonRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2btools.designsystems.aries.notificationsviewer.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESKTOPNOTIFICATIONSPERMISSION", StringUtil.RTrim( AV10DesktopNotificationsPermission));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESKTOPNOTIFICATIONTAG", StringUtil.RTrim( AV11DesktopNotificationTag));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICATIONINFO", AV31NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICATIONINFO", AV31NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"subNotificationsgrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTIFICATIONINFO_Message", AV31NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMARKASREAD_ACTION_Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
      }

      protected void RenderHtmlCloseForm0Q2( )
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
         return "K2BTools.DesignSystems.Aries.NotificationsViewer" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "K2 BT_Notifications Viewer Aries", "") ;
      }

      protected void WB0Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2btools.designsystems.aries.notificationsviewer.aspx");
               context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
               context.AddJavascriptSource("UserControls/K2BTools.DesignSystems.Aries.NotificationsButtonRender.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
               context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderNotificationsContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", divContenttable_Class, "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucK2bt_notificationsbutton1.SetProperty("Caption", K2bt_notificationsbutton1_Caption);
            ucK2bt_notificationsbutton1.Render(context, "k2btools.designsystems.aries.notificationsbutton", K2bt_notificationsbutton1_Internalname, sPrefix+"K2BT_NOTIFICATIONSBUTTON1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_notificationsgrid_Internalname, divGridcomponentcontent_notificationsgrid_Visible, 0, "px", 0, "px", divGridcomponentcontent_notificationsgrid_Class, "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "K2BT_NotificationsComponentActions", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewall_action_Internalname, context.GetMessage( "K2BT_ViewAllNotifications", ""), "", "", lblViewall_action_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e110q1_client"+"'", "", "K2BT_TextAction", 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnablenotifications_action_Internalname, context.GetMessage( "K2BT_Notif_EnableWebNotifications", ""), "", "", lblEnablenotifications_action_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e120q1_client"+"'", "", "K2BT_TextAction", 7, "", lblEnablenotifications_action_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRefresh_action_Internalname, context.GetMessage( "K2BT_RefreshAction", ""), "", "", lblRefresh_action_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e130q1_client"+"'", "", "K2BT_TextAction", 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\NotificationsViewer.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_notificationsgrid_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /*  Grid Control  */
            NotificationsgridContainer.SetIsFreestyle(true);
            NotificationsgridContainer.SetWrapped(nGXWrapped);
            StartGridControl21( ) ;
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( NotificationsgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer, subNotificationsgrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divI_noresultsfoundtablename_notificationsgrid_Internalname, divI_noresultsfoundtablename_notificationsgrid_Visible, 0, "px", 0, "px", "K2BToolsTable_NoResultsFound", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_notificationsgrid_Internalname, context.GetMessage( "K2BT_NoNotifications", ""), "", "", lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\NotificationsViewer.htm");
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucK2bdesktopnotification.SetProperty("Permission", AV10DesktopNotificationsPermission);
            ucK2bdesktopnotification.SetProperty("ClickedNotificationTag", AV11DesktopNotificationTag);
            ucK2bdesktopnotification.Render(context, "k2bdesktopnotification", K2bdesktopnotification_Internalname, sPrefix+"K2BDESKTOPNOTIFICATIONContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( NotificationsgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Notificationsgrid", NotificationsgridContainer, subNotificationsgrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData", NotificationsgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"NotificationsgridContainerData"+"V", NotificationsgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"NotificationsgridContainerData"+"V"+"\" value='"+NotificationsgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "K2 BT_Notifications Viewer Aries", ""), 0) ;
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
               STRUP0Q0( ) ;
            }
         }
      }

      protected void WS0Q2( )
      {
         START0Q2( ) ;
         EVT0Q2( ) ;
      }

      protected void EVT0Q2( )
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
                                 STRUP0Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_ViewNotification' */
                                    E140Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID_NOTIFICATIONCONTAINER.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E150Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavNotificationtext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E160Q2 ();
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "NOTIFICATIONSGRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "NOTIFICATIONSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'E_VIEWNOTIFICATION'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 45), "NOTIFICATIONSGRID_NOTIFICATIONCONTAINER.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "VMARKASREAD_ACTION.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              AV29NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV29NotificationIcon)) ? AV41Notificationicon_GXI : context.convertURL( context.PathToRelativeUrl( AV29NotificationIcon))), !bGXsfl_21_Refreshing);
                              AssignProp(sPrefix, false, edtavNotificationicon_Internalname, "SrcSet", context.GetImageSrcSet( AV29NotificationIcon), true);
                              AV24MarkAsRead_Action = cgiGet( edtavMarkasread_action_Internalname);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action)) ? AV39Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV24MarkAsRead_Action))), !bGXsfl_21_Refreshing);
                              AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV24MarkAsRead_Action), true);
                              AV33NotificationText = cgiGet( edtavNotificationtext_Internalname);
                              AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV33NotificationText);
                              AV32NotificationIsRead = StringUtil.StrToBool( cgiGet( chkavNotificationisread_Internalname));
                              AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV32NotificationIsRead);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOTIFICATIONID");
                                 GX_FocusControl = edtavNotificationid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV30NotificationId = 0;
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV30NotificationId), 15, 0));
                              }
                              else
                              {
                                 AV30NotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavNotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV30NotificationId), 15, 0));
                              }
                              AV15EventTargetUrl = cgiGet( edtavEventtargeturl_Internalname);
                              AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV15EventTargetUrl);
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
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E170Q2 ();
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
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E180Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E190Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E200Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMARKASREAD_ACTION.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E210Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_VIEWNOTIFICATION'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_ViewNotification' */
                                          E140Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONSGRID_NOTIFICATIONCONTAINER.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E150Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E160Q2 ();
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
                                       STRUP0Q0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationtext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E160Q2 ();
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

      protected void WE0Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Q2( ) ;
            }
         }
      }

      protected void PA0Q2( )
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

      protected void gxnrNotificationsgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_21_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( NotificationsgridContainer)) ;
         /* End function gxnrNotificationsgrid_newrow */
      }

      protected void gxgrNotificationsgrid_refresh( string AV24MarkAsRead_Action ,
                                                    GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV12DP_SDT_ITEM_NotificationsGrid ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         NOTIFICATIONSGRID_nCurrentRecord = 0;
         RF0Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrNotificationsgrid_refresh */
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
         /* Execute user event: Refresh */
         E180Q2 ();
         RF0Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            NotificationsgridContainer.ClearRows();
         }
         wbStart = 21;
         /* Execute user event: Refresh */
         E180Q2 ();
         E190Q2 ();
         nGXsfl_21_idx = 1;
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
         NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
         NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
         NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
         NotificationsgridContainer.PageSize = subNotificationsgrid_fnc_Recordsperpage( );
         if ( subNotificationsgrid_Islastpage != 0 )
         {
            NOTIFICATIONSGRID_nFirstRecordOnPage = (long)(subNotificationsgrid_fnc_Recordcount( )-subNotificationsgrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONSGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(NOTIFICATIONSGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("NOTIFICATIONSGRID_nFirstRecordOnPage", NOTIFICATIONSGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            E200Q2 ();
            wbEnd = 21;
            WB0Q0( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Q2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDP_SDT_ITEM_NOTIFICATIONSGRID", AV12DP_SDT_ITEM_NotificationsGrid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDP_SDT_ITEM_NOTIFICATIONSGRID", GetSecureSignedToken( sPrefix, AV12DP_SDT_ITEM_NotificationsGrid, context));
      }

      protected int subNotificationsgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subNotificationsgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E170Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTIFICATIONINFO"), AV31NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_21"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV10DesktopNotificationsPermission = cgiGet( sPrefix+"vDESKTOPNOTIFICATIONSPERMISSION");
            AV11DesktopNotificationTag = cgiGet( sPrefix+"vDESKTOPNOTIFICATIONTAG");
            subNotificationsgrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subNotificationsgrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E170Q2 ();
         if (returnInSub) return;
      }

      protected void E170Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         subNotificationsgrid_Backcolorstyle = 3;
         if ( (0==AV8CurrentPage_NotificationsGrid) )
         {
            AV8CurrentPage_NotificationsGrid = 1;
            AssignAttri(sPrefix, false, "AV8CurrentPage_NotificationsGrid", StringUtil.LTrimStr( (decimal)(AV8CurrentPage_NotificationsGrid), 4, 0));
         }
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' */
         S112 ();
         if (returnInSub) return;
         edtavMarkasread_action_gximage = "K2BNotificationMarkRead";
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "gximage", edtavMarkasread_action_gximage, !bGXsfl_21_Refreshing);
         AV24MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action)) ? AV39Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV24MarkAsRead_Action))), !bGXsfl_21_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV24MarkAsRead_Action), true);
         AV39Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action)) ? AV39Markasread_action_GXI : context.convertURL( context.PathToRelativeUrl( AV24MarkAsRead_Action))), !bGXsfl_21_Refreshing);
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "SrcSet", context.GetImageSrcSet( AV24MarkAsRead_Action), true);
         edtavMarkasread_action_Tooltiptext = context.GetMessage( "K2BT_MarkAsRead", "");
         AssignProp(sPrefix, false, edtavMarkasread_action_Internalname, "Tooltiptext", edtavMarkasread_action_Tooltiptext, !bGXsfl_21_Refreshing);
         if ( StringUtil.StrCmp(AV17HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'U_OPENPAGE' */
            S122 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_STARTPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E180Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         divGridcomponentcontent_notificationsgrid_Class = "ControlBeautify_CollapsableTable"+" "+"K2BT_NotificationsTableContainer";
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Class", divGridcomponentcontent_notificationsgrid_Class, true);
         divContenttable_Class = "ControlBeautify_ParentCollapsableTable";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         divGridcomponentcontent_notificationsgrid_Visible = 0;
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
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
         divGridcomponentcontent_notificationsgrid_Class = "ControlBeautify_CollapsableTable"+" "+"K2BT_NotificationsTableContainer";
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Class", divGridcomponentcontent_notificationsgrid_Class, true);
         divContenttable_Class = "ControlBeautify_ParentCollapsableTable";
         AssignProp(sPrefix, false, divContenttable_Internalname, "Class", divContenttable_Class, true);
         divGridcomponentcontent_notificationsgrid_Visible = 0;
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'U_TOGGLENOTIFICATIONS' Routine */
         returnInSub = false;
         divGridcomponentcontent_notificationsgrid_Visible = (!((divGridcomponentcontent_notificationsgrid_Visible==1)) ? 1 : 0);
         AssignProp(sPrefix, false, divGridcomponentcontent_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_notificationsgrid_Visible), 5, 0), true);
      }

      protected void E190Q2( )
      {
         /* Notificationsgrid_Refresh Routine */
         returnInSub = false;
         subNotificationsgrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_GRIDREFRESH(NOTIFICATIONSGRID)' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'U_GRIDREFRESH(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         GXt_char1 = new k2bgetusercode(context).executeUdp( );
         new GeneXus.Programs.k2btools.integrationprocedures.registerclient(context ).execute( ref  GXt_char1) ;
         GXt_int2 = 0;
         new GeneXus.Programs.k2btools.integrationprocedures.getwebnotificationsunreadcount(context ).execute( out  GXt_int2) ;
         K2bt_notificationsbutton1_Count = GXt_int2;
         ucK2bt_notificationsbutton1.SendProperty(context, sPrefix, false, K2bt_notificationsbutton1_Internalname, "Count", StringUtil.LTrimStr( (decimal)(K2bt_notificationsbutton1_Count), 9, 0));
      }

      private void E200Q2( )
      {
         /* Notificationsgrid_Load Routine */
         returnInSub = false;
         AV18I_LoadCount_NotificationsGrid = 0;
         GXt_objcol_SdtWebNotificationSDT_Notification3 = AV13DP_SDT_NotificationsGrid;
         new GeneXus.Programs.k2btools.integrationprocedures.getlatestnotificationsforcurrentuser(context ).execute( out  GXt_objcol_SdtWebNotificationSDT_Notification3) ;
         AV13DP_SDT_NotificationsGrid = GXt_objcol_SdtWebNotificationSDT_Notification3;
         if ( AV13DP_SDT_NotificationsGrid.Count == 0 )
         {
            divI_noresultsfoundtablename_notificationsgrid_Visible = 1;
            AssignProp(sPrefix, false, divI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         else
         {
            divI_noresultsfoundtablename_notificationsgrid_Visible = 0;
            AssignProp(sPrefix, false, divI_noresultsfoundtablename_notificationsgrid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divI_noresultsfoundtablename_notificationsgrid_Visible), 5, 0), true);
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV13DP_SDT_NotificationsGrid.Count )
         {
            AV12DP_SDT_ITEM_NotificationsGrid = ((GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification)AV13DP_SDT_NotificationsGrid.Item(AV40GXV1));
            AV18I_LoadCount_NotificationsGrid = (short)(AV18I_LoadCount_NotificationsGrid+1);
            AV23LoadRow_NotificationsGrid = true;
            AV29NotificationIcon = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon;
            AssignAttri(sPrefix, false, edtavNotificationicon_Internalname, AV29NotificationIcon);
            AV41Notificationicon_GXI = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationicon_gxi;
            AV33NotificationText = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationtext;
            AssignAttri(sPrefix, false, edtavNotificationtext_Internalname, AV33NotificationText);
            AV14EventCreationDateTime = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventcreationdatetime;
            AV32NotificationIsRead = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationisread;
            AssignAttri(sPrefix, false, chkavNotificationisread_Internalname, AV32NotificationIsRead);
            AV30NotificationId = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationid;
            AssignAttri(sPrefix, false, edtavNotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV30NotificationId), 15, 0));
            AV15EventTargetUrl = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Eventtargeturl;
            AssignAttri(sPrefix, false, edtavEventtargeturl_Internalname, AV15EventTargetUrl);
            edtavMarkasread_action_gximage = "K2BNotificationMarkRead";
            AV24MarkAsRead_Action = context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavMarkasread_action_Internalname, AV24MarkAsRead_Action);
            AV39Markasread_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dfbe6635-f23c-4133-8627-41bb5fc11325", "", context.GetTheme( )));
            edtavMarkasread_action_Tooltiptext = context.GetMessage( "K2BT_MarkAsRead", "");
            lblNotificationsgrid_notificationtexttb_Caption = AV33NotificationText;
            GXt_char1 = "";
            new getdatefriendlystring(context ).execute(  AV14EventCreationDateTime, out  GXt_char1) ;
            lblNotificationsgrid_notificationdatetb_Caption = GXt_char1;
            if ( AV32NotificationIsRead )
            {
               edtavMarkasread_action_Visible = 0;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_21_Refreshing);
            }
            else
            {
               edtavMarkasread_action_Visible = 1;
               divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer"+" "+"K2BT_UnreadNotificationContainer";
               AssignProp(sPrefix, false, divNotificationsgrid_notificationcontainer_Internalname, "Class", divNotificationsgrid_notificationcontainer_Class, !bGXsfl_21_Refreshing);
            }
            /* Execute user subroutine: 'U_LOADROWVARS(NOTIFICATIONSGRID)' */
            S172 ();
            if (returnInSub) return;
            if ( AV23LoadRow_NotificationsGrid )
            {
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 21;
               }
               sendrow_212( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
               {
                  context.DoAjaxLoad(21, NotificationsgridRow);
               }
            }
            else
            {
               AV18I_LoadCount_NotificationsGrid = (short)(AV18I_LoadCount_NotificationsGrid-1);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12DP_SDT_ITEM_NotificationsGrid", AV12DP_SDT_ITEM_NotificationsGrid);
      }

      protected void S172( )
      {
         /* 'U_LOADROWVARS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         bttViewnotification_Caption = AV12DP_SDT_ITEM_NotificationsGrid.gxTpr_Notificationactioncaption;
         AssignProp(sPrefix, false, bttViewnotification_Internalname, "Caption", bttViewnotification_Caption, !bGXsfl_21_Refreshing);
      }

      protected void E210Q2( )
      {
         /* Markasread_action_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'U_MARKASREAD' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2btools.integrationprocedures.markwebnotificationasread(context ).execute(  (short)(AV30NotificationId), out  AV35Success, out  AV26Messages) ;
         if ( AV35Success )
         {
            context.CommitDataStores("k2btools.designsystems.aries.notificationsviewer",pr_default);
         }
         else
         {
            AV42GXV2 = 1;
            while ( AV42GXV2 <= AV26Messages.Count )
            {
               AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV26Messages.Item(AV42GXV2));
               GX_msglist.addItem(AV25Message.gxTpr_Description);
               AV42GXV2 = (int)(AV42GXV2+1);
            }
         }
         gxgrNotificationsgrid_refresh( AV24MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, sPrefix) ;
      }

      protected void E140Q2( )
      {
         /* 'E_ViewNotification' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_VIEWNOTIFICATION' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_VIEWNOTIFICATION' Routine */
         returnInSub = false;
         AV5Url = AV15EventTargetUrl;
         /* Execute user subroutine: 'U_MARKASREAD' */
         S182 ();
         if (returnInSub) return;
         CallWebObject(formatLink(AV5Url) );
         context.wjLocDisableFrm = 0;
      }

      protected void E150Q2( )
      {
         /* Notificationsgrid_notificationcontainer_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_VIEWNOTIFICATION' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'REFRESHGRIDACTIONS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' */
         S222 ();
         if (returnInSub) return;
      }

      protected void S222( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(NOTIFICATIONSGRID)' Routine */
         returnInSub = false;
      }

      protected void S202( )
      {
         /* 'U_VIEWALL' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2btools.designsystems.aries.viewallnotifications.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'U_REFRESH' Routine */
         returnInSub = false;
         gxgrNotificationsgrid_refresh( AV24MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, sPrefix) ;
      }

      protected void E160Q2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31NotificationInfo.gxTpr_Id, "K2BTools.Notifications.DesktopNotification") == 0 )
         {
            AV27NewNotificationId = (long)(Math.Round(NumberUtil.Val( AV31NotificationInfo.gxTpr_Message, "."), 18, MidpointRounding.ToEven));
            GXt_boolean4 = AV22Loaded;
            new GeneXus.Programs.k2btools.integrationprocedures.getdesktopnotificationinformation(context ).execute(  (short)(AV27NewNotificationId), out  AV9DesktopNotificationInfoSDT, out  GXt_boolean4) ;
            AV22Loaded = GXt_boolean4;
            if ( AV22Loaded )
            {
               this.executeUsercontrolMethod(sPrefix, false, "K2BDESKTOPNOTIFICATIONContainer", "ShowNotification", "", new Object[] {(SdtDesktopNotificationInfoSDT)AV9DesktopNotificationInfoSDT});
            }
            gxgrNotificationsgrid_refresh( AV24MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, sPrefix) ;
         }
         else
         {
            if ( StringUtil.StrCmp(AV31NotificationInfo.gxTpr_Id, "K2BTools.Notifications.Refresh") == 0 )
            {
               gxgrNotificationsgrid_refresh( AV24MarkAsRead_Action, AV12DP_SDT_ITEM_NotificationsGrid, sPrefix) ;
            }
         }
         /*  Sending Event outputs  */
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
         PA0Q2( ) ;
         WS0Q2( ) ;
         WE0Q2( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2btools\\designsystems\\aries\\notificationsviewer", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA0Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Q2( ) ;
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
         WS0Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE0Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221325483", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/notificationsviewer.js", "?202431221325484", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BTools.DesignSystems.Aries.NotificationsButtonRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("K2BDesktopNotification/K2BDesktopNotificationRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_212( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_21_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_21_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_21_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_21_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_21_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_21_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_21_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_21_idx;
      }

      protected void SubsflControlProps_fel_212( )
      {
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON_"+sGXsfl_21_fel_idx;
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB_"+sGXsfl_21_fel_idx;
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION_"+sGXsfl_21_fel_idx;
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB_"+sGXsfl_21_fel_idx;
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT_"+sGXsfl_21_fel_idx;
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD_"+sGXsfl_21_fel_idx;
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID_"+sGXsfl_21_fel_idx;
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL_"+sGXsfl_21_fel_idx;
      }

      protected void sendrow_212( )
      {
         SubsflControlProps_212( ) ;
         WB0Q0( ) ;
         NotificationsgridRow = GXWebRow.GetNew(context,NotificationsgridContainer);
         if ( subNotificationsgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subNotificationsgrid_Backstyle = 0;
            subNotificationsgrid_Backcolor = subNotificationsgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Uniform";
            }
         }
         else if ( subNotificationsgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
            {
               subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
            }
            subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subNotificationsgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subNotificationsgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_21_idx) % (2))) == 0 )
            {
               subNotificationsgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Even";
               }
            }
            else
            {
               subNotificationsgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subNotificationsgrid_Class, "") != 0 )
               {
                  subNotificationsgrid_Linesclass = subNotificationsgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( NotificationsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subNotificationsgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_21_idx+"\">") ;
         }
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgridtable1_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"K2BToolsSection_HoverActionContainer",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_notificationcontainer_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divNotificationsgrid_notificationcontainer_Class,(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Static Bitmap Variable */
         ClassString = "K2BT_NotificationIcon" + " " + ((StringUtil.StrCmp(edtavNotificationicon_gximage, "")==0) ? "" : "GX_Image_"+edtavNotificationicon_gximage+"_Class");
         StyleString = "";
         AV29NotificationIcon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV29NotificationIcon))&&String.IsNullOrEmpty(StringUtil.RTrim( AV41Notificationicon_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV29NotificationIcon)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV29NotificationIcon)) ? AV41Notificationicon_GXI : context.PathToRelativeUrl( AV29NotificationIcon));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV29NotificationIcon_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_section1_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"K2BT_NotificationContentContainer",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationsgrid_section2_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationsgrid_notificationtexttb_Internalname,(string)lblNotificationsgrid_notificationtexttb_Caption,(string)"",(string)"",(string)lblNotificationsgrid_notificationtexttb_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"K2BT_NotificationMessage",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",context.GetMessage( "MarkAsRead", ""),(string)"gx-form-item Image_ActionLabel Image_Action_OnSectionHoverLabel K2BT_NotificationMarkAsReadLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavMarkasread_action_Enabled!=0)&&(edtavMarkasread_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'"+sPrefix+"',false,'',21)\"" : " ");
         ClassString = "Image_Action Image_Action_OnSectionHover K2BT_NotificationMarkAsRead" + " " + ((StringUtil.StrCmp(edtavMarkasread_action_gximage, "")==0) ? "" : "GX_Image_"+edtavMarkasread_action_gximage+"_Class");
         StyleString = "";
         AV24MarkAsRead_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV39Markasread_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24MarkAsRead_Action)) ? AV39Markasread_action_GXI : context.PathToRelativeUrl( AV24MarkAsRead_Action));
         NotificationsgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavMarkasread_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavMarkasread_action_Visible,(short)1,(string)"",(string)edtavMarkasread_action_Tooltiptext,(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavMarkasread_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVMARKASREAD_ACTION.CLICK."+sGXsfl_21_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV24MarkAsRead_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Text block */
         NotificationsgridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationsgrid_notificationdatetb_Internalname,(string)lblNotificationsgrid_notificationdatetb_Caption,(string)"",(string)"",(string)lblNotificationsgrid_notificationdatetb_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"K2BT_NotificationDate",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MinimalAction";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttViewnotification_Internalname+"_"+sGXsfl_21_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(21), 2, 0)+","+"null"+");",(string)bttViewnotification_Caption,(string)bttViewnotification_Jsonclick,(short)5,(string)"",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_VIEWNOTIFICATION\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutcontent_invisiblecontrolssection_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section_Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavNotificationtext_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,context.GetMessage( "Notification Text", ""),(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Multiple line edit */
         TempTags = " " + ((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 40,'"+sPrefix+"',false,'"+sGXsfl_21_idx+"',21)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         NotificationsgridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationtext_Internalname,(string)AV33NotificationText,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNotificationtext_Enabled!=0)&&(edtavNotificationtext_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,40);\"" : " "),(short)0,(short)1,(short)1,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"10000",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"K2BTools\\K2BT_NotificationMessage",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"start",(string)"top",(string)""+" data-gx-for=\""+chkavNotificationisread_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,context.GetMessage( "Notification Is Read", ""),(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Check box */
         TempTags = " " + ((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 43,'"+sPrefix+"',false,'"+sGXsfl_21_idx+"',21)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_21_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_21_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         NotificationsgridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavNotificationisread_Internalname,StringUtil.BoolToStr( AV32NotificationIsRead),(string)"",context.GetMessage( "Notification Is Read", ""),(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavNotificationisread.Enabled!=0)&&(chkavNotificationisread.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,43);\"" : " ")});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavNotificationid_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,context.GetMessage( "Notification Id", ""),(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 46,'"+sPrefix+"',false,'"+sGXsfl_21_idx+"',21)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NotificationId), 15, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30NotificationId), "ZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+((edtavNotificationid_Enabled!=0)&&(edtavNotificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)15,(string)"chr",(short)1,(string)"row",(short)15,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"K2BTools\\K2BT_LargeId",(string)"end",(bool)false,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group gx-label-top",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavEventtargeturl_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         NotificationsgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,context.GetMessage( "Event Target Url", ""),(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 100%;"});
         /* Div Control */
         NotificationsgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 49,'"+sPrefix+"',false,'"+sGXsfl_21_idx+"',21)\"" : " ");
         ROClassString = "Attribute";
         NotificationsgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEventtargeturl_Internalname,(string)AV15EventTargetUrl,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavEventtargeturl_Enabled!=0)&&(edtavEventtargeturl_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,49);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)AV15EventTargetUrl,(string)"_blank",(string)"",(string)"",(string)edtavEventtargeturl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"url",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         NotificationsgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0Q2( ) ;
         /* End of Columns property logic. */
         NotificationsgridContainer.AddRow(NotificationsgridRow);
         nGXsfl_21_idx = ((subNotificationsgrid_Islastpage==1)&&(nGXsfl_21_idx+1>subNotificationsgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         /* End function sendrow_212 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vNOTIFICATIONISREAD_" + sGXsfl_21_idx;
         chkavNotificationisread.Name = GXCCtl;
         chkavNotificationisread.WebTags = "";
         chkavNotificationisread.Caption = "";
         AssignProp(sPrefix, false, chkavNotificationisread_Internalname, "TitleCaption", chkavNotificationisread.Caption, !bGXsfl_21_Refreshing);
         chkavNotificationisread.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl21( )
      {
         if ( NotificationsgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"NotificationsgridContainer"+"DivS\" data-gxgridid=\"21\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subNotificationsgrid_Internalname, subNotificationsgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
         }
         else
         {
            NotificationsgridContainer.AddObjectProperty("GridName", "Notificationsgrid");
            NotificationsgridContainer.AddObjectProperty("Header", subNotificationsgrid_Header);
            NotificationsgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            NotificationsgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            NotificationsgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Backcolorstyle), 1, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("CmpContext", sPrefix);
            NotificationsgridContainer.AddObjectProperty("InMasterPage", "false");
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV29NotificationIcon));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", context.convertURL( AV24MarkAsRead_Action));
            NotificationsgridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavMarkasread_action_Tooltiptext));
            NotificationsgridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMarkasread_action_Visible), 5, 0, ".", "")));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", lblNotificationsgrid_notificationtexttb_Caption);
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV33NotificationText));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV32NotificationIsRead)));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NotificationId), 15, 0, ".", ""))));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            NotificationsgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV15EventTargetUrl));
            NotificationsgridContainer.AddColumnProperties(NotificationsgridColumn);
            NotificationsgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectedindex), 4, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowselection), 1, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Selectioncolor), 9, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowhovering), 1, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Hoveringcolor), 9, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Allowcollapsing), 1, 0, ".", "")));
            NotificationsgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subNotificationsgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         K2bt_notificationsbutton1_Internalname = sPrefix+"K2BT_NOTIFICATIONSBUTTON1";
         lblViewall_action_Internalname = sPrefix+"VIEWALL_ACTION";
         lblEnablenotifications_action_Internalname = sPrefix+"ENABLENOTIFICATIONS_ACTION";
         lblRefresh_action_Internalname = sPrefix+"REFRESH_ACTION";
         divTable1_Internalname = sPrefix+"TABLE1";
         edtavNotificationicon_Internalname = sPrefix+"vNOTIFICATIONICON";
         lblNotificationsgrid_notificationtexttb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONTEXTTB";
         edtavMarkasread_action_Internalname = sPrefix+"vMARKASREAD_ACTION";
         divNotificationsgrid_section2_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION2";
         lblNotificationsgrid_notificationdatetb_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONDATETB";
         bttViewnotification_Internalname = sPrefix+"VIEWNOTIFICATION";
         divNotificationsgrid_section1_Internalname = sPrefix+"NOTIFICATIONSGRID_SECTION1";
         divNotificationsgrid_notificationcontainer_Internalname = sPrefix+"NOTIFICATIONSGRID_NOTIFICATIONCONTAINER";
         edtavNotificationtext_Internalname = sPrefix+"vNOTIFICATIONTEXT";
         chkavNotificationisread_Internalname = sPrefix+"vNOTIFICATIONISREAD";
         edtavNotificationid_Internalname = sPrefix+"vNOTIFICATIONID";
         edtavEventtargeturl_Internalname = sPrefix+"vEVENTTARGETURL";
         divLayoutcontent_invisiblecontrolssection_Internalname = sPrefix+"LAYOUTCONTENT_INVISIBLECONTROLSSECTION";
         divNotificationsgridtable1_Internalname = sPrefix+"NOTIFICATIONSGRIDTABLE1";
         lblI_noresultsfoundtextblock_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_NOTIFICATIONSGRID";
         divI_noresultsfoundtablename_notificationsgrid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID";
         divMaingrid_responsivetable_notificationsgrid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_NOTIFICATIONSGRID";
         divGridcomponentcontent_notificationsgrid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         K2bdesktopnotification_Internalname = sPrefix+"K2BDESKTOPNOTIFICATION";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subNotificationsgrid_Internalname = sPrefix+"NOTIFICATIONSGRID";
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
         subNotificationsgrid_Allowcollapsing = 0;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         edtavEventtargeturl_Jsonclick = "";
         edtavEventtargeturl_Visible = 1;
         edtavEventtargeturl_Enabled = 1;
         edtavNotificationid_Jsonclick = "";
         edtavNotificationid_Visible = 1;
         edtavNotificationid_Enabled = 1;
         chkavNotificationisread.Caption = context.GetMessage( "Notification Is Read", "");
         chkavNotificationisread.Visible = 1;
         chkavNotificationisread.Enabled = 1;
         edtavNotificationtext_Visible = 1;
         edtavNotificationtext_Enabled = 1;
         lblNotificationsgrid_notificationdatetb_Caption = "";
         edtavMarkasread_action_Jsonclick = "";
         edtavMarkasread_action_Enabled = 1;
         edtavMarkasread_action_Visible = 1;
         lblNotificationsgrid_notificationtexttb_Caption = "";
         edtavNotificationicon_gximage = "";
         subNotificationsgrid_Class = "FreeStyleGrid";
         bttViewnotification_Caption = "";
         divNotificationsgrid_notificationcontainer_Class = "K2BT_NotificationContainer K2BT_UnreadNotificationContainer";
         K2bt_notificationsbutton1_Count = 0;
         edtavMarkasread_action_gximage = "";
         subNotificationsgrid_Backcolorstyle = 0;
         divI_noresultsfoundtablename_notificationsgrid_Visible = 1;
         lblEnablenotifications_action_Visible = 1;
         divGridcomponentcontent_notificationsgrid_Class = "K2BToolsTable_GridControlsContainer";
         divGridcomponentcontent_notificationsgrid_Visible = 1;
         K2bt_notificationsbutton1_Caption = context.GetMessage( "E_Toggle Notifications", "");
         divContenttable_Class = "Flex";
         edtavMarkasread_action_Tooltiptext = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'sPrefix'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("NOTIFICATIONSGRID.REFRESH","{handler:'E190Q2',iparms:[]");
         setEventMetadata("NOTIFICATIONSGRID.REFRESH",",oparms:[{av:'subNotificationsgrid_Backcolorstyle',ctrl:'NOTIFICATIONSGRID',prop:'Backcolorstyle'},{av:'K2bt_notificationsbutton1_Count',ctrl:'K2BT_NOTIFICATIONSBUTTON1',prop:'Count'}]}");
         setEventMetadata("NOTIFICATIONSGRID.LOAD","{handler:'E200Q2',iparms:[{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true}]");
         setEventMetadata("NOTIFICATIONSGRID.LOAD",",oparms:[{av:'divI_noresultsfoundtablename_notificationsgrid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_NOTIFICATIONSGRID',prop:'Visible'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'AV29NotificationIcon',fld:'vNOTIFICATIONICON',pic:''},{av:'AV33NotificationText',fld:'vNOTIFICATIONTEXT',pic:''},{av:'AV32NotificationIsRead',fld:'vNOTIFICATIONISREAD',pic:''},{av:'AV30NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'},{av:'AV15EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'lblNotificationsgrid_notificationtexttb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONTEXTTB',prop:'Caption'},{av:'lblNotificationsgrid_notificationdatetb_Caption',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONDATETB',prop:'Caption'},{av:'edtavMarkasread_action_Visible',ctrl:'vMARKASREAD_ACTION',prop:'Visible'},{av:'divNotificationsgrid_notificationcontainer_Class',ctrl:'NOTIFICATIONSGRID_NOTIFICATIONCONTAINER',prop:'Class'},{ctrl:'VIEWNOTIFICATION',prop:'Caption'}]}");
         setEventMetadata("VMARKASREAD_ACTION.CLICK","{handler:'E210Q2',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'sPrefix'},{av:'AV30NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("VMARKASREAD_ACTION.CLICK",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("'E_VIEWNOTIFICATION'","{handler:'E140Q2',iparms:[{av:'AV15EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'sPrefix'},{av:'AV30NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("'E_VIEWNOTIFICATION'",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("NOTIFICATIONSGRID_NOTIFICATIONCONTAINER.CLICK","{handler:'E150Q2',iparms:[{av:'AV15EventTargetUrl',fld:'vEVENTTARGETURL',pic:''},{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'sPrefix'},{av:'AV30NotificationId',fld:'vNOTIFICATIONID',pic:'ZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("NOTIFICATIONSGRID_NOTIFICATIONCONTAINER.CLICK",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("'E_VIEWALL'","{handler:'E110Q1',iparms:[]");
         setEventMetadata("'E_VIEWALL'",",oparms:[]}");
         setEventMetadata("'E_REFRESH'","{handler:'E130Q1',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'E_REFRESH'",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("ENABLENOTIFICATIONS_ACTION.CLICK","{handler:'E120Q1',iparms:[]");
         setEventMetadata("ENABLENOTIFICATIONS_ACTION.CLICK",",oparms:[]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E160Q2',iparms:[{av:'NOTIFICATIONSGRID_nFirstRecordOnPage'},{av:'NOTIFICATIONSGRID_nEOF'},{av:'AV24MarkAsRead_Action',fld:'vMARKASREAD_ACTION',pic:''},{av:'edtavMarkasread_action_Tooltiptext',ctrl:'vMARKASREAD_ACTION',prop:'Tooltiptext'},{av:'AV12DP_SDT_ITEM_NotificationsGrid',fld:'vDP_SDT_ITEM_NOTIFICATIONSGRID',pic:'',hsh:true},{av:'sPrefix'},{av:'AV31NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[{av:'divGridcomponentcontent_notificationsgrid_Class',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Class'},{av:'divContenttable_Class',ctrl:'CONTENTTABLE',prop:'Class'},{av:'divGridcomponentcontent_notificationsgrid_Visible',ctrl:'GRIDCOMPONENTCONTENT_NOTIFICATIONSGRID',prop:'Visible'}]}");
         setEventMetadata("VALIDV_EVENTTARGETURL","{handler:'Validv_Eventtargeturl',iparms:[]");
         setEventMetadata("VALIDV_EVENTTARGETURL",",oparms:[]}");
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
         AV31NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV24MarkAsRead_Action = "";
         AV12DP_SDT_ITEM_NotificationsGrid = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10DesktopNotificationsPermission = "";
         AV11DesktopNotificationTag = "";
         GX_FocusControl = "";
         ucK2bt_notificationsbutton1 = new GXUserControl();
         lblViewall_action_Jsonclick = "";
         lblEnablenotifications_action_Jsonclick = "";
         lblRefresh_action_Jsonclick = "";
         NotificationsgridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         ucK2bdesktopnotification = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29NotificationIcon = "";
         AV41Notificationicon_GXI = "";
         AV39Markasread_action_GXI = "";
         AV33NotificationText = "";
         AV15EventTargetUrl = "";
         AV17HttpRequest = new GxHttpRequest( context);
         AV13DP_SDT_NotificationsGrid = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test");
         GXt_objcol_SdtWebNotificationSDT_Notification3 = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test");
         AV14EventCreationDateTime = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         NotificationsgridRow = new GXWebRow();
         AV26Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV5Url = "";
         AV9DesktopNotificationInfoSDT = new SdtDesktopNotificationInfoSDT(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subNotificationsgrid_Linesclass = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblNotificationsgrid_notificationtexttb_Jsonclick = "";
         TempTags = "";
         lblNotificationsgrid_notificationdatetb_Jsonclick = "";
         bttViewnotification_Jsonclick = "";
         GXCCtl = "";
         ROClassString = "";
         subNotificationsgrid_Header = "";
         NotificationsgridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2btools.designsystems.aries.notificationsviewer__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2btools.designsystems.aries.notificationsviewer__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subNotificationsgrid_Backcolorstyle ;
      private short AV8CurrentPage_NotificationsGrid ;
      private short NOTIFICATIONSGRID_nEOF ;
      private short GXt_int2 ;
      private short AV18I_LoadCount_NotificationsGrid ;
      private short nGXWrapped ;
      private short subNotificationsgrid_Backstyle ;
      private short subNotificationsgrid_Allowselection ;
      private short subNotificationsgrid_Allowhovering ;
      private short subNotificationsgrid_Allowcollapsing ;
      private short subNotificationsgrid_Collapsed ;
      private int divGridcomponentcontent_notificationsgrid_Visible ;
      private int nRC_GXsfl_21 ;
      private int subNotificationsgrid_Recordcount ;
      private int nGXsfl_21_idx=1 ;
      private int lblEnablenotifications_action_Visible ;
      private int divI_noresultsfoundtablename_notificationsgrid_Visible ;
      private int subNotificationsgrid_Islastpage ;
      private int K2bt_notificationsbutton1_Count ;
      private int AV40GXV1 ;
      private int edtavMarkasread_action_Visible ;
      private int AV42GXV2 ;
      private int idxLst ;
      private int subNotificationsgrid_Backcolor ;
      private int subNotificationsgrid_Allbackcolor ;
      private int edtavMarkasread_action_Enabled ;
      private int edtavNotificationtext_Enabled ;
      private int edtavNotificationtext_Visible ;
      private int edtavNotificationid_Enabled ;
      private int edtavNotificationid_Visible ;
      private int edtavEventtargeturl_Enabled ;
      private int edtavEventtargeturl_Visible ;
      private int subNotificationsgrid_Selectedindex ;
      private int subNotificationsgrid_Selectioncolor ;
      private int subNotificationsgrid_Hoveringcolor ;
      private long AV30NotificationId ;
      private long NOTIFICATIONSGRID_nCurrentRecord ;
      private long NOTIFICATIONSGRID_nFirstRecordOnPage ;
      private long AV27NewNotificationId ;
      private string edtavMarkasread_action_Tooltiptext ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_21_idx="0001" ;
      private string edtavMarkasread_action_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV10DesktopNotificationsPermission ;
      private string AV11DesktopNotificationTag ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divContenttable_Internalname ;
      private string divContenttable_Class ;
      private string K2bt_notificationsbutton1_Caption ;
      private string K2bt_notificationsbutton1_Internalname ;
      private string divGridcomponentcontent_notificationsgrid_Internalname ;
      private string divGridcomponentcontent_notificationsgrid_Class ;
      private string divTable1_Internalname ;
      private string lblViewall_action_Internalname ;
      private string lblViewall_action_Jsonclick ;
      private string lblEnablenotifications_action_Internalname ;
      private string lblEnablenotifications_action_Jsonclick ;
      private string lblRefresh_action_Internalname ;
      private string lblRefresh_action_Jsonclick ;
      private string divMaingrid_responsivetable_notificationsgrid_Internalname ;
      private string sStyleString ;
      private string subNotificationsgrid_Internalname ;
      private string divI_noresultsfoundtablename_notificationsgrid_Internalname ;
      private string lblI_noresultsfoundtextblock_notificationsgrid_Internalname ;
      private string lblI_noresultsfoundtextblock_notificationsgrid_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string K2bdesktopnotification_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationtext_Internalname ;
      private string edtavNotificationicon_Internalname ;
      private string chkavNotificationisread_Internalname ;
      private string edtavNotificationid_Internalname ;
      private string edtavEventtargeturl_Internalname ;
      private string edtavMarkasread_action_gximage ;
      private string lblNotificationsgrid_notificationtexttb_Caption ;
      private string lblNotificationsgrid_notificationdatetb_Caption ;
      private string GXt_char1 ;
      private string divNotificationsgrid_notificationcontainer_Class ;
      private string divNotificationsgrid_notificationcontainer_Internalname ;
      private string bttViewnotification_Caption ;
      private string bttViewnotification_Internalname ;
      private string lblNotificationsgrid_notificationtexttb_Internalname ;
      private string lblNotificationsgrid_notificationdatetb_Internalname ;
      private string sGXsfl_21_fel_idx="0001" ;
      private string subNotificationsgrid_Class ;
      private string subNotificationsgrid_Linesclass ;
      private string divNotificationsgridtable1_Internalname ;
      private string ClassString ;
      private string edtavNotificationicon_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string divNotificationsgrid_section1_Internalname ;
      private string divNotificationsgrid_section2_Internalname ;
      private string lblNotificationsgrid_notificationtexttb_Jsonclick ;
      private string TempTags ;
      private string edtavMarkasread_action_Jsonclick ;
      private string lblNotificationsgrid_notificationdatetb_Jsonclick ;
      private string bttViewnotification_Jsonclick ;
      private string divLayoutcontent_invisiblecontrolssection_Internalname ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavNotificationid_Jsonclick ;
      private string edtavEventtargeturl_Jsonclick ;
      private string subNotificationsgrid_Header ;
      private DateTime AV14EventCreationDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_21_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV32NotificationIsRead ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV23LoadRow_NotificationsGrid ;
      private bool AV35Success ;
      private bool AV22Loaded ;
      private bool GXt_boolean4 ;
      private bool AV29NotificationIcon_IsBlob ;
      private bool AV24MarkAsRead_Action_IsBlob ;
      private string AV41Notificationicon_GXI ;
      private string AV39Markasread_action_GXI ;
      private string AV33NotificationText ;
      private string AV15EventTargetUrl ;
      private string AV5Url ;
      private string AV24MarkAsRead_Action ;
      private string AV29NotificationIcon ;
      private GXWebGrid NotificationsgridContainer ;
      private GXWebRow NotificationsgridRow ;
      private GXWebColumn NotificationsgridColumn ;
      private GXUserControl ucK2bt_notificationsbutton1 ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucK2bdesktopnotification ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavNotificationisread ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV17HttpRequest ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> AV13DP_SDT_NotificationsGrid ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> GXt_objcol_SdtWebNotificationSDT_Notification3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV26Messages ;
      private SdtDesktopNotificationInfoSDT AV9DesktopNotificationInfoSDT ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification AV12DP_SDT_ITEM_NotificationsGrid ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV31NotificationInfo ;
   }

   public class notificationsviewer__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class notificationsviewer__default : DataStoreHelperBase, IDataStoreHelper
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
