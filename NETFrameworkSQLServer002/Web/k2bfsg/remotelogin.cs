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
   public class remotelogin : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public remotelogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public remotelogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV42IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV42IDP_State;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTypeauthtype = new GXCombobox();
         cmbavLogonto = new GXCombobox();
         chkavKeepmeloggedin = new GXCheckbox();
         chkavRememberme = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridauthtypes") == 0 )
            {
               gxnrGridauthtypes_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridauthtypes") == 0 )
            {
               gxgrGridauthtypes_refresh_invoke( ) ;
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
               AV42IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV42IDP_State", AV42IDP_State);
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

      protected void gxnrGridauthtypes_newrow_invoke( )
      {
         nRC_GXsfl_20 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridauthtypes_newrow( ) ;
         /* End function gxnrGridauthtypes_newrow_invoke */
      }

      protected void gxgrGridauthtypes_refresh_invoke( )
      {
         AV42IDP_State = GetPar( "IDP_State");
         AV48Language = GetPar( "Language");
         AV71AuxUserName = GetPar( "AuxUserName");
         AV67UserRememberMe = (short)(Math.Round(NumberUtil.Val( GetPar( "UserRememberMe"), "."), 18, MidpointRounding.ToEven));
         AV61ShowDetailedMessages = StringUtil.StrToBool( GetPar( "ShowDetailedMessages"));
         AV12AmountOfCharacters = (short)(Math.Round(NumberUtil.Val( GetPar( "AmountOfCharacters"), "."), 18, MidpointRounding.ToEven));
         AV47KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
         AV55RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridauthtypes_refresh( AV42IDP_State, AV48Language, AV71AuxUserName, AV67UserRememberMe, AV61ShowDetailedMessages, AV12AmountOfCharacters, AV47KeepMeLoggedIn, AV55RememberMe) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridauthtypes_refresh_invoke */
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
            ValidateSpaRequest();
            PA4N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               cmbavTypeauthtype.Enabled = 0;
               AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS4N2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4N2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "Remote Login", "")) ;
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
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal K2BFormLogin\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BFormLogin\" data-gx-class=\"form-horizontal K2BFormLogin\" novalidate action=\""+formatLink("k2bfsg.remotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal K2BFormLogin", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV48Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV71AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV42IDP_State));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV48Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV71AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AmountOfCharacters), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vURL", AV64URL);
         GxWebStd.gx_hidden_field( context, "subGridauthtypes_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm4N2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RemoteLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Remote Login", "") ;
      }

      protected void WB4N0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_MainContentTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginImageContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagetransparency_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginImageTransparency", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginForm", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;align-self:center;", "div");
            /* Static images/pictures */
            ClassString = "K2BT_LoginLogo" + " " + ((StringUtil.StrCmp(imgAppimage_gximage, "")==0) ? "GX_Image_K2BToolsMLTransp_Class" : "GX_Image_"+imgAppimage_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgAppimage_Bitmap;
            GxWebStd.gx_bitmap( context, imgAppimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAppimage_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentrepository_Internalname, context.GetMessage( "Text Block", ""), "", "", lblCurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divExternalauthentications_Internalname, 1, 0, "px", 0, "px", "TableButtons", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, context.GetMessage( "Login using", ""), "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /*  Grid Control  */
            GridauthtypesContainer.SetIsFreestyle(true);
            GridauthtypesContainer.SetWrapped(nGXWrapped);
            StartGridControl20( ) ;
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer, subGridauthtypes_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns3_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, context.GetMessage( "K2BT_GAM_LogOnTo", ""), "gx-form-item K2BToolsFSGAM_Attribute100WidthLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_20_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV52LogOnTo), 1, cmbavLogonto_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVLOGONTO.CLICK."+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsFSGAM_Attribute100Width", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV65UserName, StringUtil.RTrim( context.localUtil.Format( AV65UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "K2BT_GAM_Usernameoremail", ""), edtavUsername_Jsonclick, 0, "K2BT_LoginUsername", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV66UserPassword), StringUtil.RTrim( context.localUtil.Format( AV66UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUserpassword_Invitemessage, edtavUserpassword_Jsonclick, 0, "K2BT_LoginPassword", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblForgotpassword_action_Internalname, context.GetMessage( "K2BT_GAM_Forgotpassword", ""), "", "", lblForgotpassword_action_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114n1_client"+"'", "", "K2BT_LoginSecondaryAction", 7, "", lblForgotpassword_action_Visible, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCreateanaccount_action_Internalname, context.GetMessage( "K2BT_GAM_CreateAccount", ""), "", "", lblCreateanaccount_action_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124n1_client"+"'", "", "K2BT_LoginSecondaryAction", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, context.GetMessage( "K2BT_GAM_KeepmeLoggedIn", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_20_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV47KeepMeLoggedIn), "", context.GetMessage( "K2BT_GAM_KeepmeLoggedIn", ""), chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(55, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, context.GetMessage( "K2BT_GAM_Rememberme", ""), "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_20_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV55RememberMe), "", context.GetMessage( "K2BT_GAM_Rememberme", ""), chkavRememberme.Visible, chkavRememberme.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "K2BFSGTable_CAPTCHAContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, context.GetMessage( "K2BT_GAM_Pleaseinsertthetextbelow", ""), "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgavCaptchaimage_gximage, "")==0) ? "" : "GX_Image_"+imgavCaptchaimage_gximage+"_Class");
            StyleString = "";
            AV20CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV81Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV81Captchaimage_GXI : context.PathToRelativeUrl( AV20CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV20CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV24CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV24CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "K2BT_LoginCaptcha", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 10, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "K2BDescription", "start", true, "", "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "K2BT_LoginButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", bttLogin_Caption, bttLogin_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbappname_Internalname, lblTbappname_Caption, "", "", lblTbappname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTbappname_Visible, 1, 0, 0, "HLP_K2BFSG\\RemoteLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridauthtypesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer, subGridauthtypes_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Remote Login", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4N0( ) ;
      }

      protected void WS4N2( )
      {
         START4N2( ) ;
         EVT4N2( ) ;
      }

      protected void EVT4N2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E134N2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "VLOGONTO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E144N2 ();
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) )
                        {
                           nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                           SubsflControlProps_202( ) ;
                           AV74ImageAuthType = cgiGet( edtavImageauthtype_Internalname);
                           AssignProp("", false, edtavImageauthtype_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV74ImageAuthType)) ? AV83Imageauthtype_GXI : context.convertURL( context.PathToRelativeUrl( AV74ImageAuthType))), !bGXsfl_20_Refreshing);
                           AssignProp("", false, edtavImageauthtype_Internalname, "SrcSet", context.GetImageSrcSet( AV74ImageAuthType), true);
                           AV75NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV75NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV75NameAuthType, "")), context));
                           cmbavTypeauthtype.Name = cmbavTypeauthtype_Internalname;
                           cmbavTypeauthtype.CurrentValue = cgiGet( cmbavTypeauthtype_Internalname);
                           AV76TypeAuthType = cgiGet( cmbavTypeauthtype_Internalname);
                           AssignAttri("", false, cmbavTypeauthtype_Internalname, AV76TypeAuthType);
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E154N2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E164N2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E174N2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Load */
                                 E184N2 ();
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

      protected void WE4N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4N2( ) ;
            }
         }
      }

      protected void PA4N2( )
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
               GX_FocusControl = cmbavLogonto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridauthtypes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_20_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridauthtypesContainer)) ;
         /* End function gxnrGridauthtypes_newrow */
      }

      protected void gxgrGridauthtypes_refresh( string AV42IDP_State ,
                                                string AV48Language ,
                                                string AV71AuxUserName ,
                                                short AV67UserRememberMe ,
                                                bool AV61ShowDetailedMessages ,
                                                short AV12AmountOfCharacters ,
                                                bool AV47KeepMeLoggedIn ,
                                                bool AV55RememberMe )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDAUTHTYPES_nCurrentRecord = 0;
         RF4N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV75NameAuthType));
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
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV52LogOnTo = cmbavLogonto.getValidValue(AV52LogOnTo);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV47KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV47KeepMeLoggedIn));
         AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
         AV55RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV55RememberMe));
         AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void RF4N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridauthtypesContainer.ClearRows();
         }
         wbStart = 20;
         /* Execute user event: Refresh */
         E164N2 ();
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
         GridauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
         GridauthtypesContainer.PageSize = subGridauthtypes_fnc_Recordsperpage( );
         if ( subGridauthtypes_Islastpage != 0 )
         {
            GRIDAUTHTYPES_nFirstRecordOnPage = (long)(subGridauthtypes_fnc_Recordcount( )-subGridauthtypes_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDAUTHTYPES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDAUTHTYPES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("GRIDAUTHTYPES_nFirstRecordOnPage", GRIDAUTHTYPES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            /* Execute user event: Load */
            E184N2 ();
            wbEnd = 20;
            WB4N0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4N2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV48Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV71AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67UserRememberMe), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV67UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV75NameAuthType, "")), context));
      }

      protected int subGridauthtypes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_20_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E154N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridauthtypes_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridauthtypes_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV52LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
            AV65UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV65UserName", AV65UserName);
            AV66UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV66UserPassword", AV66UserPassword);
            AV47KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
            AV55RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
            AV20CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV24CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV24CaptchaText", AV24CaptchaText);
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
         AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S182 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV8isConnectionOK )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV57RepositoryGUID) )
               {
                  AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV57RepositoryGUID, out  AV32Errors);
                  AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               }
               else
               {
                  AV26ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
                  if ( AV26ConnectionInfoCollection.Count > 0 )
                  {
                     AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV26ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV32Errors);
                     AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
                  }
               }
            }
         }
         lblTbappname_Visible = 0;
         AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
         imgAppimage_Visible = 0;
         AssignProp("", false, imgAppimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAppimage_Visible), 5, 0), true);
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
         {
            AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getremoteapplication(AV42IDP_State, out  AV32Errors);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5GAMApplication.gxTpr_Clientimageurl)) )
            {
               imgAppimage_Visible = 1;
               AssignProp("", false, imgAppimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAppimage_Visible), 5, 0), true);
               imgAppimage_Bitmap = AV5GAMApplication.gxTpr_Clientimageurl;
               AssignProp("", false, imgAppimage_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgAppimage_Bitmap)), true);
               AssignProp("", false, imgAppimage_Internalname, "SrcSet", context.GetImageSrcSet( imgAppimage_Bitmap), true);
            }
            else
            {
               lblTbappname_Visible = 1;
               AssignProp("", false, lblTbappname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbappname_Visible), 5, 0), true);
               lblTbappname_Caption = AV5GAMApplication.gxTpr_Name;
               AssignProp("", false, lblTbappname_Internalname, "Caption", lblTbappname_Caption, true);
            }
         }
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV12AmountOfCharacters, out  AV13AmountOfFailedLogins, out  AV17BadLoginsExpire, out  AV60ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV12AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV12AmountOfCharacters), 4, 0));
         Form.Class = "K2BFormLogin";
         AssignProp("", false, "FORM", "Class", Form.Class, true);
      }

      protected void S122( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E154N2 ();
         if (returnInSub) return;
      }

      protected void E154N2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E164N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S122 ();
         if (returnInSub) return;
         AV34ForgotPassword_Action = context.GetMessage( "K2BT_GAM_Forgotpassword", "");
         AV28CreateAnAccount_Action = context.GetMessage( "K2BT_GAM_CreateAccount", "");
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV52LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15AuthenticationType", AV15AuthenticationType);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S192 ();
         if (returnInSub) return;
         AV7hasError = false;
         AV33ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV33ErrorsLogin.Count > 0 )
         {
            AV7hasError = true;
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV33ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV33ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV66UserPassword = "";
               AssignAttri("", false, "AV66UserPassword", AV66UserPassword);
               AV32Errors = AV33ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S202 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV7hasError )
         {
            AV59SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV58Session, out  AV32Errors);
            if ( AV59SessionValid && ! AV58Session.gxTpr_Isanonymous )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV42IDP_State) ;
               }
               else
               {
                  AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  AssignAttri("", false, "AV64URL", AV64URL);
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV64URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV16AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV48Language, out  AV32Errors);
               AV77GXV1 = 1;
               while ( AV77GXV1 <= AV16AuthenticationTypes.Count )
               {
                  AV15AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV16AuthenticationTypes.Item(AV77GXV1));
                  if ( AV15AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV15AuthenticationType.gxTpr_Name, AV15AuthenticationType.gxTpr_Description, 0);
                  }
                  AV77GXV1 = (int)(AV77GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               AV45isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV52LogOnTo, out  AV71AuxUserName, out  AV67UserRememberMe, out  AV32Errors);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71AuxUserName)) )
               {
                  AV65UserName = AV71AuxUserName;
                  AssignAttri("", false, "AV65UserName", AV65UserName);
               }
               if ( AV67UserRememberMe == 2 )
               {
                  AV55RememberMe = true;
                  AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
               }
               AV56Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV52LogOnTo = AV56Repository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
               }
               chkavRememberme.Visible = 0;
               AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               chkavKeepmeloggedin.Visible = 0;
               AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV56Repository.gxTpr_Userremembermetype, "Both") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               AV78GXV2 = 1;
               while ( AV78GXV2 <= AV16AuthenticationTypes.Count )
               {
                  AV15AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV16AuthenticationTypes.Item(AV78GXV2));
                  if ( StringUtil.StrCmp(AV15AuthenticationType.gxTpr_Name, AV52LogOnTo) == 0 )
                  {
                     /* Execute user subroutine: 'VALIDLOGONTOOTP' */
                     S172 ();
                     if (returnInSub) return;
                     if (true) break;
                  }
                  AV78GXV2 = (int)(AV78GXV2+1);
               }
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E134N2 ();
         if (returnInSub) return;
      }

      protected void E134N2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_LOGIN' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AdditionalParameter", AV11AdditionalParameter);
      }

      protected void S142( )
      {
         /* 'U_LOGIN' Routine */
         returnInSub = false;
         GXt_char1 = AV64URL;
         new k2bsessionget(context ).execute(  "SessionCaptchaRedirectURL", out  GXt_char1) ;
         AV64URL = GXt_char1;
         AssignAttri("", false, "AV64URL", AV64URL);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
         {
            AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            AssignAttri("", false, "AV64URL", AV64URL);
         }
         GXt_boolean2 = AV44IncorrectLoginsExisted;
         new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV52LogOnTo,  AV65UserName, out  GXt_boolean2) ;
         AV44IncorrectLoginsExisted = GXt_boolean2;
         if ( AV44IncorrectLoginsExisted )
         {
            GXt_boolean2 = AV21CaptchaIsCorrect;
            new GeneXus.Programs.k2bfsg.evaluatecaptchacorrectness(context ).execute(  AV24CaptchaText, out  GXt_boolean2) ;
            AV21CaptchaIsCorrect = GXt_boolean2;
            if ( AV21CaptchaIsCorrect )
            {
               /* Execute user subroutine: 'PROCESSLOGIN' */
               S212 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'ACTIVATECAPTCHA' */
               S222 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'PROCESSLOGIN' */
            S212 ();
            if (returnInSub) return;
         }
      }

      protected void S212( )
      {
         /* 'PROCESSLOGIN' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV12AmountOfCharacters, out  AV13AmountOfFailedLogins, out  AV17BadLoginsExpire, out  AV60ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV12AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV12AmountOfCharacters), 4, 0));
         if ( AV47KeepMeLoggedIn )
         {
            AV11AdditionalParameter.gxTpr_Rememberusertype = (short)((AV47KeepMeLoggedIn ? 3 : 1));
         }
         else
         {
            if ( AV55RememberMe )
            {
               AV11AdditionalParameter.gxTpr_Rememberusertype = (short)((AV55RememberMe ? 2 : 1));
            }
            else
            {
               AV11AdditionalParameter.gxTpr_Rememberusertype = 1;
            }
         }
         AV72GAMProperties = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getgamremoteinitialproperties(AV42IDP_State);
         AV11AdditionalParameter.gxTpr_Properties = AV72GAMProperties;
         AV11AdditionalParameter.gxTpr_Authenticationtypename = AV52LogOnTo;
         AV11AdditionalParameter.gxTpr_Idpstate = AV42IDP_State;
         AV11AdditionalParameter.gxTpr_Otpstep = 1;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV70CaptchaActive) ;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV23CaptchaRequiredText) ;
         AV51LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV65UserName, AV66UserPassword, AV11AdditionalParameter, out  AV32Errors);
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  AV70CaptchaActive) ;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV23CaptchaRequiredText) ;
         if ( ! AV51LoginOK )
         {
            if ( AV32Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 400 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(1)).gxTpr_Code == 410 ) )
                  {
                     CallWebObject(formatLink("k2bfsg.otpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42IDP_State))}, new string[] {"IDP_State"}) );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     new GeneXus.Programs.k2bfsg.saveincorrectlogin(context ).execute(  AV52LogOnTo,  AV65UserName) ;
                     if ( AV13AmountOfFailedLogins == 1 )
                     {
                        /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                        S222 ();
                        if (returnInSub) return;
                     }
                     else
                     {
                        GXt_boolean2 = AV44IncorrectLoginsExisted;
                        new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV52LogOnTo,  AV65UserName, out  GXt_boolean2) ;
                        AV44IncorrectLoginsExisted = GXt_boolean2;
                        if ( AV44IncorrectLoginsExisted )
                        {
                           /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                           S222 ();
                           if (returnInSub) return;
                        }
                     }
                  }
               }
            }
         }
         else
         {
            new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV52LogOnTo,  AV65UserName) ;
            /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
            S232 ();
            if (returnInSub) return;
            new GeneXus.Programs.k2btools.integrationprocedures.updatecontextafterlogin(context ).execute( ) ;
            context.CommitDataStores("k2bfsg.remotelogin",pr_default);
            if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV42IDP_State) )
            {
               new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV42IDP_State) ;
            }
            else
            {
               AV64URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               AssignAttri("", false, "AV64URL", AV64URL);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64URL)) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
               }
               else
               {
                  CallWebObject(formatLink(AV64URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV23CaptchaRequiredText) ;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV61ShowDetailedMessages) ;
         AssignAttri("", false, "AV61ShowDetailedMessages", AV61ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV61ShowDetailedMessages, context));
         AV31ErrorCount = 0;
         AV79GXV3 = 1;
         while ( AV79GXV3 <= AV32Errors.Count )
         {
            AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(AV79GXV3));
            if ( AV30Error.gxTpr_Code == 104 )
            {
               new k2btoolsmsg(context ).execute(  AV30Error.gxTpr_Message,  2) ;
            }
            else
            {
               AV31ErrorCount = (short)(AV31ErrorCount+1);
            }
            AV79GXV3 = (int)(AV79GXV3+1);
         }
         if ( ( AV31ErrorCount > 0 ) || ( StringUtil.StrCmp(AV23CaptchaRequiredText, "true") == 0 ) )
         {
            new k2btoolsmsg(context ).execute(  context.GetMessage( "K2BT_GAM_Wrongusernameorpassword", ""),  2) ;
         }
         if ( AV61ShowDetailedMessages )
         {
            AV80GXV4 = 1;
            while ( AV80GXV4 <= AV32Errors.Count )
            {
               AV30Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV32Errors.Item(AV80GXV4));
               if ( AV30Error.gxTpr_Code != 13 )
               {
                  new k2btoolsmsg(context ).execute(  StringUtil.Format( "%1 (GAM%2)", AV30Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV30Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""),  2) ;
               }
               AV80GXV4 = (int)(AV80GXV4+1);
            }
         }
      }

      protected void S152( )
      {
         /* 'U_FORGOTPASSWORD' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.recoverpasswordstep1.aspx", new object[] {UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDP_State"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'U_CREATEANACCOUNT' Routine */
         returnInSub = false;
         CallWebObject(formatLink("k2bfsg.registeruser.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'ACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "true") ;
         new k2bsessionset(context ).execute(  "SessionCaptchaRedirectURL",  AV64URL) ;
         CallWebObject(formatLink("k2bfsg.remotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDP_State"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S232( )
      {
         /* 'DEACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "false") ;
      }

      protected void S242( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV22CaptchaProvider.generatestringtoken(AV12AmountOfCharacters)) ;
      }

      protected void S192( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV23CaptchaRequiredText) ;
         if ( StringUtil.StrCmp(AV23CaptchaRequiredText, context.GetMessage( "true", "")) == 0 )
         {
            /* Execute user subroutine: 'CREATENEWCAPTCHA' */
            S242 ();
            if (returnInSub) return;
            new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV23CaptchaRequiredText) ;
            lblCaptchadescription_Visible = 1;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 1;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 1;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV18Base64String = AV22CaptchaProvider.generateimage(180, 75, AV23CaptchaRequiredText);
            AV23CaptchaRequiredText = "";
            AV20CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV18Base64String;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV81Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
            AV81Captchaimage_GXI = GXDbFile.PathToUrl( context.GetMessage( "data:image/jpeg;charset=utf-8;base64,", "")+AV18Base64String);
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV81Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
         }
         else
         {
            AV23CaptchaRequiredText = "";
            lblCaptchadescription_Visible = 0;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 0;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 0;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV20CaptchaImage = "data:image/jpeg;charset=utf-8;base64,R0lGODlhAQABAPAAAP///////ywAAAAAAQABAEAIBAABBAQAOw==";
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV81Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
            AV81Captchaimage_GXI = GXDbFile.PathToUrl( context.GetMessage( "data:image/jpeg;charset=utf-8;base64,R0lGODlhAQABAPAAAP///////ywAAAAAAQABAEAIBAABBAQAOw==", ""));
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20CaptchaImage)) ? AV81Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV20CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV20CaptchaImage), true);
         }
      }

      protected void S182( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV32Errors);
            AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
         }
         if ( ! AV8isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV57RepositoryGUID) )
            {
               AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV57RepositoryGUID, out  AV32Errors);
               AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
            }
            else
            {
               AV26ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV26ConnectionInfoCollection.Count > 0 )
               {
                  AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV26ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV32Errors);
                  AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               }
            }
         }
         if ( AV8isConnectionOK )
         {
            AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV8isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV6GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV32Errors);
               AssignAttri("", false, "AV8isConnectionOK", AV8isConnectionOK);
               AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
         }
      }

      protected void E144N2( )
      {
         /* Logonto_Click Routine */
         returnInSub = false;
         AV16AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV48Language, out  AV32Errors);
         AV73isModeOTP = false;
         AV82GXV5 = 1;
         while ( AV82GXV5 <= AV16AuthenticationTypes.Count )
         {
            AV15AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV16AuthenticationTypes.Item(AV82GXV5));
            if ( StringUtil.StrCmp(AV15AuthenticationType.gxTpr_Name, AV52LogOnTo) == 0 )
            {
               /* Execute user subroutine: 'VALIDLOGONTOOTP' */
               S172 ();
               if (returnInSub) return;
               if (true) break;
            }
            AV82GXV5 = (int)(AV82GXV5+1);
         }
         if ( ! AV73isModeOTP )
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavUserpassword_Invitemessage = context.GetMessage( "K2BT_GAM_Password", "");
            AssignProp("", false, edtavUserpassword_Internalname, "Invitemessage", edtavUserpassword_Invitemessage, true);
            bttLogin_Caption = context.GetMessage( "K2BT_GAM_Login", "");
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblForgotpassword_action_Visible = 1;
            AssignProp("", false, lblForgotpassword_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblForgotpassword_action_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15AuthenticationType", AV15AuthenticationType);
      }

      protected void S172( )
      {
         /* 'VALIDLOGONTOOTP' Routine */
         returnInSub = false;
         if ( ! AV15AuthenticationType.gxTpr_Needuserpassword )
         {
            AV73isModeOTP = true;
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            bttLogin_Caption = context.GetMessage( "K2BT_GAM_SendMeACode", "");
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblForgotpassword_action_Visible = 0;
            AssignProp("", false, lblForgotpassword_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblForgotpassword_action_Visible), 5, 0), true);
         }
      }

      protected void E174N2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         if ( AV47KeepMeLoggedIn )
         {
            AV11AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV55RememberMe )
         {
            AV11AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV11AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV11AdditionalParameter.gxTpr_Authenticationtypename = AV75NameAuthType;
         AV51LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV65UserName, AV66UserPassword, AV11AdditionalParameter, out  AV32Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11AdditionalParameter", AV11AdditionalParameter);
      }

      private void E184N2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV42IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV42IDP_State", AV42IDP_State);
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
         PA4N2( ) ;
         WS4N2( ) ;
         WE4N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202431221415092", true, true);
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
         context.AddJavascriptSource("k2bfsg/remotelogin.js", "?202431221415097", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_20_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_20_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_20_fel_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_20_fel_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB4N0( ) ;
         GridauthtypesRow = GXWebRow.GetNew(context,GridauthtypesContainer);
         if ( subGridauthtypes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            subGridauthtypes_Backcolor = subGridauthtypes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Uniform";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
            subGridauthtypes_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridauthtypes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
            {
               subGridauthtypes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Even";
               }
            }
            else
            {
               subGridauthtypes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_20_idx+"\">") ;
         }
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridauthtypestable1_Internalname+"_"+sGXsfl_20_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",context.GetMessage( "Image Auth Type", ""),(string)"col-sm-3 Fixed30Label",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavImageauthtype_Enabled!=0)&&(edtavImageauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'',false,'',20)\"" : " ");
         ClassString = "Fixed30" + " " + ((StringUtil.StrCmp(edtavImageauthtype_gximage, "")==0) ? "" : "GX_Image_"+edtavImageauthtype_gximage+"_Class");
         StyleString = "";
         AV74ImageAuthType_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV74ImageAuthType))&&String.IsNullOrEmpty(StringUtil.RTrim( AV83Imageauthtype_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV74ImageAuthType)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV74ImageAuthType)) ? AV83Imageauthtype_GXI : context.PathToRelativeUrl( AV74ImageAuthType));
         GridauthtypesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImageauthtype_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavImageauthtype_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_20_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV74ImageAuthType_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,context.GetMessage( "Name Auth Type", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'',false,'"+sGXsfl_20_idx+"',20)\"" : " ");
         ROClassString = "Attribute";
         GridauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV75NameAuthType),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,29);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_20_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"start",(bool)true,(string)""});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divSection1_Internalname+"_"+sGXsfl_20_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section_Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavTypeauthtype_Internalname,context.GetMessage( "Type Auth Type", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         TempTags = " " + ((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 34,'',false,'"+sGXsfl_20_idx+"',20)\"" : " ");
         if ( ( cmbavTypeauthtype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_20_idx;
            cmbavTypeauthtype.Name = GXCCtl;
            cmbavTypeauthtype.WebTags = "";
            cmbavTypeauthtype.addItem("AppleID", context.GetMessage( "Apple", ""), 0);
            cmbavTypeauthtype.addItem("Custom", context.GetMessage( "Custom", ""), 0);
            cmbavTypeauthtype.addItem("ExternalWebService", context.GetMessage( "External Web Service", ""), 0);
            cmbavTypeauthtype.addItem("Facebook", context.GetMessage( "Facebook", ""), 0);
            cmbavTypeauthtype.addItem("GAMLocal", context.GetMessage( "GAM Local", ""), 0);
            cmbavTypeauthtype.addItem("GAMRemote", context.GetMessage( "GAM Remote", ""), 0);
            cmbavTypeauthtype.addItem("GAMRemoteRest", context.GetMessage( "GAM Remote Rest", ""), 0);
            cmbavTypeauthtype.addItem("Google", context.GetMessage( "Google", ""), 0);
            cmbavTypeauthtype.addItem("Oauth20", context.GetMessage( "Oauth 2.0", ""), 0);
            cmbavTypeauthtype.addItem("OTP", context.GetMessage( "One Time Password", ""), 0);
            cmbavTypeauthtype.addItem("Saml20", context.GetMessage( "Saml 2.0", ""), 0);
            cmbavTypeauthtype.addItem("Twitter", context.GetMessage( "Twitter", ""), 0);
            cmbavTypeauthtype.addItem("WeChat", context.GetMessage( "WeChat", ""), 0);
            if ( cmbavTypeauthtype.ItemCount > 0 )
            {
               AV76TypeAuthType = cmbavTypeauthtype.getValidValue(AV76TypeAuthType);
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV76TypeAuthType);
            }
         }
         /* ComboBox */
         GridauthtypesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTypeauthtype,(string)cmbavTypeauthtype_Internalname,StringUtil.RTrim( AV76TypeAuthType),(short)1,(string)cmbavTypeauthtype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)1,cmbavTypeauthtype.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,34);\"" : " "),(string)"",(bool)true,(short)0});
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV76TypeAuthType);
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Values", (string)(cmbavTypeauthtype.ToJavascriptSource()), !bGXsfl_20_Refreshing);
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes4N2( ) ;
         /* End of Columns property logic. */
         GridauthtypesContainer.AddRow(GridauthtypesRow);
         nGXsfl_20_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_20_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_20_idx;
         cmbavTypeauthtype.Name = GXCCtl;
         cmbavTypeauthtype.WebTags = "";
         cmbavTypeauthtype.addItem("AppleID", context.GetMessage( "Apple", ""), 0);
         cmbavTypeauthtype.addItem("Custom", context.GetMessage( "Custom", ""), 0);
         cmbavTypeauthtype.addItem("ExternalWebService", context.GetMessage( "External Web Service", ""), 0);
         cmbavTypeauthtype.addItem("Facebook", context.GetMessage( "Facebook", ""), 0);
         cmbavTypeauthtype.addItem("GAMLocal", context.GetMessage( "GAM Local", ""), 0);
         cmbavTypeauthtype.addItem("GAMRemote", context.GetMessage( "GAM Remote", ""), 0);
         cmbavTypeauthtype.addItem("GAMRemoteRest", context.GetMessage( "GAM Remote Rest", ""), 0);
         cmbavTypeauthtype.addItem("Google", context.GetMessage( "Google", ""), 0);
         cmbavTypeauthtype.addItem("Oauth20", context.GetMessage( "Oauth 2.0", ""), 0);
         cmbavTypeauthtype.addItem("OTP", context.GetMessage( "One Time Password", ""), 0);
         cmbavTypeauthtype.addItem("Saml20", context.GetMessage( "Saml 2.0", ""), 0);
         cmbavTypeauthtype.addItem("Twitter", context.GetMessage( "Twitter", ""), 0);
         cmbavTypeauthtype.addItem("WeChat", context.GetMessage( "WeChat", ""), 0);
         if ( cmbavTypeauthtype.ItemCount > 0 )
         {
            AV76TypeAuthType = cmbavTypeauthtype.getValidValue(AV76TypeAuthType);
            AssignAttri("", false, cmbavTypeauthtype_Internalname, AV76TypeAuthType);
         }
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV52LogOnTo = cmbavLogonto.getValidValue(AV52LogOnTo);
            AssignAttri("", false, "AV52LogOnTo", AV52LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV47KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV47KeepMeLoggedIn));
         AssignAttri("", false, "AV47KeepMeLoggedIn", AV47KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV55RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV55RememberMe));
         AssignAttri("", false, "AV55RememberMe", AV55RememberMe);
         /* End function init_web_controls */
      }

      protected void StartGridControl20( )
      {
         if ( GridauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"DivS\" data-gxgridid=\"20\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridauthtypes_Internalname, subGridauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
         }
         else
         {
            GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
            GridauthtypesContainer.AddObjectProperty("Header", subGridauthtypes_Header);
            GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("CmpContext", "");
            GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesColumn.AddObjectProperty("Value", context.convertURL( AV74ImageAuthType));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV75NameAuthType)));
            GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV76TypeAuthType)));
            GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Enabled), 5, 0, ".", "")));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectedindex), 4, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowselection), 1, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectioncolor), 9, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowhovering), 1, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Hoveringcolor), 9, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowcollapsing), 1, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         divImagetransparency_Internalname = "IMAGETRANSPARENCY";
         divImagecontainer_Internalname = "IMAGECONTAINER";
         imgAppimage_Internalname = "APPIMAGE";
         lblCurrentrepository_Internalname = "CURRENTREPOSITORY";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE";
         divSection1_Internalname = "SECTION1";
         divGridauthtypestable1_Internalname = "GRIDAUTHTYPESTABLE1";
         divExternalauthentications_Internalname = "EXTERNALAUTHENTICATIONS";
         cmbavLogonto_Internalname = "vLOGONTO";
         divSection2_Internalname = "SECTION2";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         lblForgotpassword_action_Internalname = "FORGOTPASSWORD_ACTION";
         lblCreateanaccount_action_Internalname = "CREATEANACCOUNT_ACTION";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         chkavRememberme_Internalname = "vREMEMBERME";
         lblCaptchadescription_Internalname = "CAPTCHADESCRIPTION";
         imgavCaptchaimage_Internalname = "vCAPTCHAIMAGE";
         edtavCaptchatext_Internalname = "vCAPTCHATEXT";
         divTable4_Internalname = "TABLE4";
         divColumns3_maincolumnstable_Internalname = "COLUMNS3_MAINCOLUMNSTABLE";
         bttLogin_Internalname = "LOGIN";
         lblTbappname_Internalname = "TBAPPNAME";
         divTable22_Internalname = "TABLE22";
         divTable3_Internalname = "TABLE3";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridauthtypes_Internalname = "GRIDAUTHTYPES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridauthtypes_Allowcollapsing = 0;
         chkavRememberme.Caption = context.GetMessage( "K2BT_GAM_Rememberme", "");
         chkavKeepmeloggedin.Caption = context.GetMessage( "K2BT_GAM_KeepmeLoggedIn", "");
         cmbavTypeauthtype_Jsonclick = "";
         cmbavTypeauthtype.Visible = 1;
         cmbavTypeauthtype.Enabled = 1;
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Visible = 1;
         edtavNameauthtype_Enabled = 1;
         edtavImageauthtype_Jsonclick = "";
         edtavImageauthtype_gximage = "";
         edtavImageauthtype_Visible = 1;
         edtavImageauthtype_Enabled = 1;
         subGridauthtypes_Class = "FreeStyleGrid";
         subGridauthtypes_Backcolorstyle = 0;
         lblTbappname_Caption = context.GetMessage( "Application Name", "");
         lblTbappname_Visible = 1;
         bttLogin_Caption = context.GetMessage( "GXM_Login", "");
         edtavCaptchatext_Jsonclick = "";
         edtavCaptchatext_Enabled = 1;
         edtavCaptchatext_Visible = 1;
         imgavCaptchaimage_gximage = "";
         imgavCaptchaimage_Visible = 1;
         lblCaptchadescription_Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         lblForgotpassword_action_Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Invitemessage = context.GetMessage( "K2BT_GAM_Password", "");
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         imgAppimage_Visible = 1;
         imgAppimage_Bitmap = (string)(context.GetImagePath( "b204c38c-79ae-43b6-aab7-fdc3fcbe6833", "", context.GetTheme( )));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDAUTHTYPES_nEOF'},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV12AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV48Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV71AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV67UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV61ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV66UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV64URL',fld:'vURL',pic:''},{av:'cmbavLogonto'},{av:'AV52LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV65UserName',fld:'vUSERNAME',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'lblCaptchadescription_Visible',ctrl:'CAPTCHADESCRIPTION',prop:'Visible'},{av:'imgavCaptchaimage_Visible',ctrl:'vCAPTCHAIMAGE',prop:'Visible'},{av:'edtavCaptchatext_Visible',ctrl:'vCAPTCHATEXT',prop:'Visible'},{av:'AV20CaptchaImage',fld:'vCAPTCHAIMAGE',pic:''},{av:'AV61ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblForgotpassword_action_Visible',ctrl:'FORGOTPASSWORD_ACTION',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E134N2',iparms:[{av:'cmbavLogonto'},{av:'AV52LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV65UserName',fld:'vUSERNAME',pic:''},{av:'AV24CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV66UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV64URL',fld:'vURL',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV64URL',fld:'vURL',pic:''},{av:'AV12AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV42IDP_State',fld:'vIDP_STATE',pic:''}]}");
         setEventMetadata("'E_FORGOTPASSWORD'","{handler:'E114N1',iparms:[]");
         setEventMetadata("'E_FORGOTPASSWORD'",",oparms:[]}");
         setEventMetadata("'E_CREATEANACCOUNT'","{handler:'E124N1',iparms:[]");
         setEventMetadata("'E_CREATEANACCOUNT'",",oparms:[]}");
         setEventMetadata("VLOGONTO.CLICK","{handler:'E144N2',iparms:[{av:'AV48Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavLogonto'},{av:'AV52LogOnTo',fld:'vLOGONTO',pic:''}]");
         setEventMetadata("VLOGONTO.CLICK",",oparms:[{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'edtavUserpassword_Invitemessage',ctrl:'vUSERPASSWORD',prop:'Invitemessage'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblForgotpassword_action_Visible',ctrl:'FORGOTPASSWORD_ACTION',prop:'Visible'}]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E174N2',iparms:[{av:'AV47KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV55RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV75NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV65UserName',fld:'vUSERNAME',pic:''},{av:'AV66UserPassword',fld:'vUSERPASSWORD',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[]}");
         setEventMetadata("VALIDV_TYPEAUTHTYPE","{handler:'Validv_Typeauthtype',iparms:[]");
         setEventMetadata("VALIDV_TYPEAUTHTYPE",",oparms:[]}");
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
         wcpOAV42IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV48Language = "";
         AV71AuxUserName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV64URL = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         imgAppimage_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblCurrentrepository_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         AV52LogOnTo = "";
         AV65UserName = "";
         AV66UserPassword = "";
         lblForgotpassword_action_Jsonclick = "";
         lblCreateanaccount_action_Jsonclick = "";
         lblCaptchadescription_Jsonclick = "";
         AV20CaptchaImage = "";
         AV81Captchaimage_GXI = "";
         AV24CaptchaText = "";
         bttLogin_Jsonclick = "";
         lblTbappname_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV74ImageAuthType = "";
         AV83Imageauthtype_GXI = "";
         AV75NameAuthType = "";
         AV76TypeAuthType = "";
         AV57RepositoryGUID = "";
         AV32Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV26ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV34ForgotPassword_Action = "";
         AV28CreateAnAccount_Action = "";
         AV15AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV33ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV58Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV16AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV56Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         GXt_char1 = "";
         AV72GAMProperties = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty>( context, "GeneXus.Programs.genexussecurity.SdtGAMProperty", "GeneXus.Programs");
         AV70CaptchaActive = "";
         AV23CaptchaRequiredText = "";
         AV30Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV22CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV18Base64String = "";
         AV6GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GridauthtypesRow = new GXWebRow();
         subGridauthtypes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         subGridauthtypes_Header = "";
         GridauthtypesColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.remotelogin__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
         cmbavTypeauthtype.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV67UserRememberMe ;
      private short AV12AmountOfCharacters ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridauthtypes_Backcolorstyle ;
      private short AV13AmountOfFailedLogins ;
      private short GRIDAUTHTYPES_nEOF ;
      private short AV31ErrorCount ;
      private short nGXWrapped ;
      private short subGridauthtypes_Backstyle ;
      private short subGridauthtypes_Allowselection ;
      private short subGridauthtypes_Allowhovering ;
      private short subGridauthtypes_Allowcollapsing ;
      private short subGridauthtypes_Collapsed ;
      private int nRC_GXsfl_20 ;
      private int subGridauthtypes_Recordcount ;
      private int nGXsfl_20_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int imgAppimage_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int lblForgotpassword_action_Visible ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int edtavCaptchatext_Enabled ;
      private int lblTbappname_Visible ;
      private int subGridauthtypes_Islastpage ;
      private int AV77GXV1 ;
      private int AV78GXV2 ;
      private int AV79GXV3 ;
      private int AV80GXV4 ;
      private int AV82GXV5 ;
      private int idxLst ;
      private int subGridauthtypes_Backcolor ;
      private int subGridauthtypes_Allbackcolor ;
      private int edtavImageauthtype_Enabled ;
      private int edtavImageauthtype_Visible ;
      private int edtavNameauthtype_Visible ;
      private int subGridauthtypes_Selectedindex ;
      private int subGridauthtypes_Selectioncolor ;
      private int subGridauthtypes_Hoveringcolor ;
      private long GRIDAUTHTYPES_nCurrentRecord ;
      private long GRIDAUTHTYPES_nFirstRecordOnPage ;
      private string AV42IDP_State ;
      private string wcpOAV42IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_20_idx="0001" ;
      private string AV48Language ;
      private string edtavNameauthtype_Internalname ;
      private string cmbavTypeauthtype_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable3_Internalname ;
      private string divImagecontainer_Internalname ;
      private string divImagetransparency_Internalname ;
      private string divTable22_Internalname ;
      private string ClassString ;
      private string imgAppimage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgAppimage_Internalname ;
      private string lblCurrentrepository_Internalname ;
      private string lblCurrentrepository_Jsonclick ;
      private string divExternalauthentications_Internalname ;
      private string lblTbexternalauthentication_Internalname ;
      private string lblTbexternalauthentication_Jsonclick ;
      private string sStyleString ;
      private string subGridauthtypes_Internalname ;
      private string divColumns3_maincolumnstable_Internalname ;
      private string divSection2_Internalname ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string AV52LogOnTo ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV66UserPassword ;
      private string edtavUserpassword_Invitemessage ;
      private string edtavUserpassword_Jsonclick ;
      private string lblForgotpassword_action_Internalname ;
      private string lblForgotpassword_action_Jsonclick ;
      private string lblCreateanaccount_action_Internalname ;
      private string lblCreateanaccount_action_Jsonclick ;
      private string chkavKeepmeloggedin_Internalname ;
      private string chkavRememberme_Internalname ;
      private string divTable4_Internalname ;
      private string lblCaptchadescription_Internalname ;
      private string lblCaptchadescription_Jsonclick ;
      private string imgavCaptchaimage_gximage ;
      private string imgavCaptchaimage_Internalname ;
      private string edtavCaptchatext_Internalname ;
      private string AV24CaptchaText ;
      private string edtavCaptchatext_Jsonclick ;
      private string bttLogin_Internalname ;
      private string bttLogin_Caption ;
      private string bttLogin_Jsonclick ;
      private string lblTbappname_Internalname ;
      private string lblTbappname_Caption ;
      private string lblTbappname_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavImageauthtype_Internalname ;
      private string AV75NameAuthType ;
      private string AV76TypeAuthType ;
      private string AV57RepositoryGUID ;
      private string AV34ForgotPassword_Action ;
      private string AV28CreateAnAccount_Action ;
      private string GXt_char1 ;
      private string AV70CaptchaActive ;
      private string AV23CaptchaRequiredText ;
      private string AV18Base64String ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string subGridauthtypes_Class ;
      private string subGridauthtypes_Linesclass ;
      private string divGridauthtypestable1_Internalname ;
      private string edtavImageauthtype_gximage ;
      private string edtavImageauthtype_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private string divSection1_Internalname ;
      private string GXCCtl ;
      private string cmbavTypeauthtype_Jsonclick ;
      private string subGridauthtypes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV61ShowDetailedMessages ;
      private bool AV47KeepMeLoggedIn ;
      private bool AV55RememberMe ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool AV20CaptchaImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV8isConnectionOK ;
      private bool AV17BadLoginsExpire ;
      private bool AV60ShouldAddSleepOnFailure ;
      private bool gx_refresh_fired ;
      private bool AV7hasError ;
      private bool AV59SessionValid ;
      private bool AV45isOK ;
      private bool AV44IncorrectLoginsExisted ;
      private bool AV21CaptchaIsCorrect ;
      private bool AV51LoginOK ;
      private bool GXt_boolean2 ;
      private bool AV73isModeOTP ;
      private bool AV74ImageAuthType_IsBlob ;
      private string AV71AuxUserName ;
      private string AV64URL ;
      private string AV65UserName ;
      private string AV81Captchaimage_GXI ;
      private string AV83Imageauthtype_GXI ;
      private string imgAppimage_Bitmap ;
      private string AV20CaptchaImage ;
      private string AV74ImageAuthType ;
      private GXWebGrid GridauthtypesContainer ;
      private GXWebRow GridauthtypesRow ;
      private GXWebColumn GridauthtypesColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private SdtK2BToolsCaptchaProvider AV22CaptchaProvider ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavTypeauthtype ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV72GAMProperties ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV32Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV33ErrorsLogin ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV16AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV26ConnectionInfoCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV5GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV30Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV56Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV6GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV11AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV58Session ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV15AuthenticationType ;
   }

   public class remotelogin__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class remotelogin__default : DataStoreHelperBase, IDataStoreHelper
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
