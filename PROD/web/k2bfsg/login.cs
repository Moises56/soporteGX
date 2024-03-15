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
   public class login : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public login( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public login( IGxContext context )
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
         AV40IDP_State = GetPar( "IDP_State");
         cmbavLogonto.FromJSonString( GetNextPar( ));
         AV51LogOnTo = GetPar( "LogOnTo");
         AV68UserName = GetPar( "UserName");
         AV53LogOnToTmp = GetPar( "LogOnToTmp");
         AV70UserRememberMe = (short)(Math.Round(NumberUtil.Val( GetPar( "UserRememberMe"), "."), 18, MidpointRounding.ToEven));
         AV63ShowDetailedMessages = StringUtil.StrToBool( GetPar( "ShowDetailedMessages"));
         AV6isModeOTP = StringUtil.StrToBool( GetPar( "isModeOTP"));
         AV10AmountOfCharacters = (short)(Math.Round(NumberUtil.Val( GetPar( "AmountOfCharacters"), "."), 18, MidpointRounding.ToEven));
         AV52LogOnToDefault = GetPar( "LogOnToDefault");
         AV46KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
         AV57RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
         AV47Language = GetPar( "Language");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridauthtypes_refresh( AV40IDP_State, AV51LogOnTo, AV68UserName, AV53LogOnToTmp, AV70UserRememberMe, AV63ShowDetailedMessages, AV6isModeOTP, AV10AmountOfCharacters, AV52LogOnToDefault, AV46KeepMeLoggedIn, AV57RememberMe, AV47Language) ;
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
            PA3K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               cmbavTypeauthtype.Enabled = 0;
               AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS3K2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE3K2( ) ;
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
         context.SendWebValue( "Login") ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BFormLogin\" data-gx-class=\"form-horizontal K2BFormLogin\" novalidate action=\""+formatLink("k2bfsg.login.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLOGONTOTMP", StringUtil.RTrim( AV53LogOnToTmp));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTOTMP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53LogOnToTmp, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV70UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV63ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV63ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vLOGONTODEFAULT", StringUtil.RTrim( AV52LogOnToDefault));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52LogOnToDefault, "")), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV47Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Language, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV40IDP_State));
         GxWebStd.gx_hidden_field( context, "vLOGONTOTMP", StringUtil.RTrim( AV53LogOnToTmp));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTOTMP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53LogOnToTmp, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV70UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV63ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV63ShowDetailedMessages, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISMODEOTP", AV6isModeOTP);
         GxWebStd.gx_hidden_field( context, "vAMOUNTOFCHARACTERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10AmountOfCharacters), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONCLIENTID", StringUtil.RTrim( AV12ApplicationClientId));
         GxWebStd.gx_hidden_field( context, "vURL", AV67URL);
         GxWebStd.gx_hidden_field( context, "vLOGONTODEFAULT", StringUtil.RTrim( AV52LogOnToDefault));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52LogOnToDefault, "")), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV47Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Language, "")), context));
         GxWebStd.gx_hidden_field( context, "subGridauthtypes_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXTERNALAUTHENTICATIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divExternalauthentications_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EXTERNALAUTHENTICATIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divExternalauthentications_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3K2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.Login" ;
      }

      public override string GetPgmdesc( )
      {
         return "Login" ;
      }

      protected void WB3K0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BT_MainLoginTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
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
            ClassString = "K2BT_LoginLogo" + " " + ((StringUtil.StrCmp(imgImage_gximage, "")==0) ? "GX_Image_login1_Class" : "GX_Image_"+imgImage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "083dbda2-1edf-4c54-8dc4-844f072813be", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentrepository_Internalname, lblCurrentrepository_Caption, "", "", lblCurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblCurrentrepository_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divExternalauthentications_Internalname, divExternalauthentications_Visible, 0, "px", 0, "px", "TableButtons", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, "Login using", "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns3_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log On To", "gx-form-item K2BToolsFSGAM_Attribute100WidthLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_20_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV51LogOnTo), 1, cmbavLogonto_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVLOGONTO.CLICK."+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "K2BToolsFSGAM_Attribute100Width", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_K2BFSG\\Login.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV51LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection3_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginFieldContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection4_Internalname, 1, 0, "px", 0, "px", "K2BT_UsernameIcon", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV68UserName, StringUtil.RTrim( context.localUtil.Format( AV68UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Username or email", edtavUsername_Jsonclick, 0, "K2BT_LoginUsername", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection5_Internalname, 1, 0, "px", 0, "px", "K2BT_LoginFieldContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection6_Internalname, 1, 0, "px", 0, "px", "K2BT_PasswordIcon", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV69UserPassword), StringUtil.RTrim( context.localUtil.Format( AV69UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUserpassword_Invitemessage, edtavUserpassword_Jsonclick, 0, "K2BT_LoginPassword", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblForgotpassword_action_Internalname, "Forgot password", "", "", lblForgotpassword_action_Jsonclick, "'"+""+"'"+",false,"+"'"+"e113k1_client"+"'", "", "K2BT_LoginSecondaryAction", 7, "", lblForgotpassword_action_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCreateanaccount_action_Internalname, "Create account", "", "", lblCreateanaccount_action_Jsonclick, "'"+""+"'"+",false,"+"'"+"e123k1_client"+"'", "", "K2BT_LoginSecondaryAction", 7, "", lblCreateanaccount_action_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, "Keep me logged in", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_20_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV46KeepMeLoggedIn), "", "Keep me logged in", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, "Remember me", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_20_idx + "',0)\"";
            ClassString = "CheckBoxAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV57RememberMe), "", "Remember me", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(63, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,63);\"");
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
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, "Please insert the text below", "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgavCaptchaimage_gximage, "")==0) ? "" : "GX_Image_"+imgavCaptchaimage_gximage+"_Class");
            StyleString = "";
            AV19CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV80Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)) ? AV80Captchaimage_GXI : context.PathToRelativeUrl( AV19CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV19CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV23CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV23CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "K2BT_LoginCaptcha", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 10, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "K2BDescription", "start", true, "", "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-shrink:0;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "K2BT_LoginButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", bttLogin_Caption, bttLogin_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
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

      protected void START3K2( )
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
         Form.Meta.addItem("description", "Login", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3K0( ) ;
      }

      protected void WS3K2( )
      {
         START3K2( ) ;
         EVT3K2( ) ;
      }

      protected void EVT3K2( )
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
                                 E133K2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "VLOGONTO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E143K2 ();
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) )
                        {
                           nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                           SubsflControlProps_202( ) ;
                           AV42ImageAuthType = cgiGet( edtavImageauthtype_Internalname);
                           AssignProp("", false, edtavImageauthtype_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV42ImageAuthType)) ? AV82Imageauthtype_GXI : context.convertURL( context.PathToRelativeUrl( AV42ImageAuthType))), !bGXsfl_20_Refreshing);
                           AssignProp("", false, edtavImageauthtype_Internalname, "SrcSet", context.GetImageSrcSet( AV42ImageAuthType), true);
                           AV55NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV55NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV55NameAuthType, "")), context));
                           cmbavTypeauthtype.Name = cmbavTypeauthtype_Internalname;
                           cmbavTypeauthtype.CurrentValue = cgiGet( cmbavTypeauthtype_Internalname);
                           AV66TypeAuthType = cgiGet( cmbavTypeauthtype_Internalname);
                           AssignAttri("", false, cmbavTypeauthtype_Internalname, AV66TypeAuthType);
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E153K2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E163K2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRIDAUTHTYPES.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E173K2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E183K2 ();
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

      protected void WE3K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3K2( ) ;
            }
         }
      }

      protected void PA3K2( )
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

      protected void gxgrGridauthtypes_refresh( string AV40IDP_State ,
                                                string AV51LogOnTo ,
                                                string AV68UserName ,
                                                string AV53LogOnToTmp ,
                                                short AV70UserRememberMe ,
                                                bool AV63ShowDetailedMessages ,
                                                bool AV6isModeOTP ,
                                                short AV10AmountOfCharacters ,
                                                string AV52LogOnToDefault ,
                                                bool AV46KeepMeLoggedIn ,
                                                bool AV57RememberMe ,
                                                string AV47Language )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDAUTHTYPES_nCurrentRecord = 0;
         RF3K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV55NameAuthType));
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
            AV51LogOnTo = cmbavLogonto.getValidValue(AV51LogOnTo);
            AssignAttri("", false, "AV51LogOnTo", AV51LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV51LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV46KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV46KeepMeLoggedIn));
         AssignAttri("", false, "AV46KeepMeLoggedIn", AV46KeepMeLoggedIn);
         AV57RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV57RememberMe));
         AssignAttri("", false, "AV57RememberMe", AV57RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3K2( ) ;
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

      protected void RF3K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridauthtypesContainer.ClearRows();
         }
         wbStart = 20;
         /* Execute user event: Refresh */
         E163K2 ();
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
            E173K2 ();
            wbEnd = 20;
            WB3K0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3K2( )
      {
         GxWebStd.gx_hidden_field( context, "vLOGONTOTMP", StringUtil.RTrim( AV53LogOnToTmp));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTOTMP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53LogOnToTmp, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV70UserRememberMe), "Z9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV63ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV63ShowDetailedMessages, context));
         GxWebStd.gx_hidden_field( context, "vLOGONTODEFAULT", StringUtil.RTrim( AV52LogOnToDefault));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52LogOnToDefault, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV55NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV47Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Language, "")), context));
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

      protected void STRUP3K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), ".", ","), 18, MidpointRounding.ToEven));
            subGridauthtypes_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridauthtypes_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            divExternalauthentications_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EXTERNALAUTHENTICATIONS_Visible"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV51LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV51LogOnTo", AV51LogOnTo);
            AV68UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV68UserName", AV68UserName);
            AV69UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV69UserPassword", AV69UserPassword);
            AV46KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV46KeepMeLoggedIn", AV46KeepMeLoggedIn);
            AV57RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV57RememberMe", AV57RememberMe);
            AV19CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV23CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV23CaptchaText", AV23CaptchaText);
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
         AV75GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV74GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV74GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV75GXV2 <= AV74GXV1.Count )
         {
            AV73DesignSystemOption = ((SdtK2BAttributeValue_Item)AV74GXV1.Item(AV75GXV2));
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {AV73DesignSystemOption.gxTpr_Attributename,AV73DesignSystemOption.gxTpr_Attributevalue}, false);
            AV75GXV2 = (int)(AV75GXV2+1);
         }
         AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S182 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV5isConnectionOK )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV59RepositoryGUID) )
               {
                  AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV59RepositoryGUID, out  AV30Errors);
                  AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
               }
               else
               {
                  AV25ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
                  if ( AV25ConnectionInfoCollection.Count > 0 )
                  {
                     AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV25ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV30Errors);
                     AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
                  }
               }
            }
         }
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV10AmountOfCharacters, out  AV11AmountOfFailedLogins, out  AV15BadLoginsExpire, out  AV62ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV10AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV10AmountOfCharacters), 4, 0));
         Form.Class = "K2BFormLogin";
         AssignProp("", false, "FORM", "Class", Form.Class, true);
         lblCurrentrepository_Visible = 0;
         AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         AV44isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AV25ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
         if ( ! AV44isOK )
         {
            if ( AV25ConnectionInfoCollection.Count > 0 )
            {
               AV44isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV25ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV30Errors);
            }
         }
         if ( AV25ConnectionInfoCollection.Count > 1 )
         {
            AV34GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            lblCurrentrepository_Caption = "Repository:"+AV34GAMRepository.gxTpr_Name;
            AssignProp("", false, lblCurrentrepository_Internalname, "Caption", lblCurrentrepository_Caption, true);
            lblCurrentrepository_Visible = 1;
            AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         }
         cmbavLogonto.removeAllItems();
         divExternalauthentications_Visible = 0;
         AssignProp("", false, divExternalauthentications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divExternalauthentications_Visible), 5, 0), true);
         AV14AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV47Language, out  AV30Errors);
         AV76GXV3 = 1;
         while ( AV76GXV3 <= AV14AuthenticationTypes.Count )
         {
            AV13AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV14AuthenticationTypes.Item(AV76GXV3));
            if ( AV13AuthenticationType.gxTpr_Needusername )
            {
               cmbavLogonto.addItem(AV13AuthenticationType.gxTpr_Name, AV13AuthenticationType.gxTpr_Description, 0);
            }
            AV76GXV3 = (int)(AV76GXV3+1);
         }
         if ( cmbavLogonto.ItemCount <= 1 )
         {
            cmbavLogonto.Visible = 0;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
         }
         AV58Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( cmbavLogonto.ItemCount > 1 )
         {
            AV51LogOnTo = AV58Repository.gxTpr_Defaultauthenticationtypename;
            AssignAttri("", false, "AV51LogOnTo", AV51LogOnTo);
            AV52LogOnToDefault = AV58Repository.gxTpr_Defaultauthenticationtypename;
            AssignAttri("", false, "AV52LogOnToDefault", AV52LogOnToDefault);
            GxWebStd.gx_hidden_field( context, "gxhash_vLOGONTODEFAULT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52LogOnToDefault, "")), context));
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
         E153K2 ();
         if (returnInSub) return;
      }

      protected void E153K2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E163K2( )
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
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13AuthenticationType", AV13AuthenticationType);
      }

      protected void S132( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S192 ();
         if (returnInSub) return;
         AV45isRedirect = false;
         AV31ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV31ErrorsLogin.Count > 0 )
         {
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31ErrorsLogin.Item(1)).gxTpr_Code == 1 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31ErrorsLogin.Item(1)).gxTpr_Code == 104 ) )
            {
            }
            else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV31ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV40IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
               AV45isRedirect = true;
            }
            else
            {
               AV69UserPassword = "";
               AssignAttri("", false, "AV69UserPassword", AV69UserPassword);
               AV30Errors = AV31ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S202 ();
               if (returnInSub) return;
            }
         }
         /* Execute user subroutine: 'DISPLAYMESSAGES' */
         S202 ();
         if (returnInSub) return;
         if ( ! AV45isRedirect )
         {
            AV61SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV60Session, out  AV30Errors);
            if ( AV61SessionValid && ! AV60Session.gxTpr_Isanonymous )
            {
               AV67URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               AssignAttri("", false, "AV67URL", AV67URL);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67URL)) )
               {
                  new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV51LogOnTo,  AV68UserName) ;
                  /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
                  S212 ();
                  if (returnInSub) return;
                  new GeneXus.Programs.k2btools.integrationprocedures.updatecontextafterlogin(context ).execute( ) ;
                  CallWebObject(formatLink("k2bfsg.applicationhome.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV51LogOnTo,  AV68UserName) ;
                  /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
                  S212 ();
                  if (returnInSub) return;
                  new GeneXus.Programs.k2btools.integrationprocedures.updatecontextafterlogin(context ).execute( ) ;
                  CallWebObject(formatLink(AV67URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV53LogOnToTmp, out  AV68UserName, out  AV70UserRememberMe, out  AV30Errors) )
               {
                  if ( AV70UserRememberMe == 2 )
                  {
                     AV57RememberMe = true;
                     AssignAttri("", false, "AV57RememberMe", AV57RememberMe);
                  }
               }
               /* Execute user subroutine: 'DISPLAYCHECKBOX' */
               S222 ();
               if (returnInSub) return;
               AV6isModeOTP = false;
               AssignAttri("", false, "AV6isModeOTP", AV6isModeOTP);
               AV77GXV4 = 1;
               while ( AV77GXV4 <= AV14AuthenticationTypes.Count )
               {
                  AV13AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV14AuthenticationTypes.Item(AV77GXV4));
                  if ( ( StringUtil.StrCmp(AV13AuthenticationType.gxTpr_Name, AV51LogOnTo) == 0 ) || ( AV14AuthenticationTypes.Count == 1 ) )
                  {
                     /* Execute user subroutine: 'VALIDLOGONTOOTP' */
                     S172 ();
                     if (returnInSub) return;
                     if (true) break;
                  }
                  AV77GXV4 = (int)(AV77GXV4+1);
               }
               /* Execute user subroutine: 'SETLOGONFORM' */
               S262 ();
               if (returnInSub) return;
            }
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E133K2 ();
         if (returnInSub) return;
      }

      protected void E133K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_LOGIN' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9AdditionalParameter", AV9AdditionalParameter);
      }

      protected void S142( )
      {
         /* 'U_LOGIN' Routine */
         returnInSub = false;
         GXt_char2 = AV67URL;
         new k2bsessionget(context ).execute(  "SessionCaptchaRedirectURL", out  GXt_char2) ;
         AV67URL = GXt_char2;
         AssignAttri("", false, "AV67URL", AV67URL);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67URL)) )
         {
            AV67URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            AssignAttri("", false, "AV67URL", AV67URL);
         }
         GXt_boolean3 = AV43IncorrectLoginsExisted;
         new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV51LogOnTo,  AV68UserName, out  GXt_boolean3) ;
         AV43IncorrectLoginsExisted = GXt_boolean3;
         if ( AV43IncorrectLoginsExisted )
         {
            GXt_boolean3 = AV20CaptchaIsCorrect;
            new GeneXus.Programs.k2bfsg.evaluatecaptchacorrectness(context ).execute(  AV23CaptchaText, out  GXt_boolean3) ;
            AV20CaptchaIsCorrect = GXt_boolean3;
            if ( AV20CaptchaIsCorrect )
            {
               /* Execute user subroutine: 'PROCESSLOGIN' */
               S232 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'ACTIVATECAPTCHA' */
               S242 ();
               if (returnInSub) return;
               CallWebObject(formatLink("k2bfsg.login.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            /* Execute user subroutine: 'PROCESSLOGIN' */
            S232 ();
            if (returnInSub) return;
         }
      }

      protected void S232( )
      {
         /* 'PROCESSLOGIN' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadloginparameters(context ).execute( out  AV10AmountOfCharacters, out  AV11AmountOfFailedLogins, out  AV15BadLoginsExpire, out  AV62ShouldAddSleepOnFailure) ;
         AssignAttri("", false, "AV10AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV10AmountOfCharacters), 4, 0));
         if ( AV46KeepMeLoggedIn )
         {
            AV9AdditionalParameter.gxTpr_Rememberusertype = (short)((AV46KeepMeLoggedIn ? 3 : 1));
         }
         else
         {
            if ( AV57RememberMe )
            {
               AV9AdditionalParameter.gxTpr_Rememberusertype = (short)((AV57RememberMe ? 2 : 1));
            }
            else
            {
               AV9AdditionalParameter.gxTpr_Rememberusertype = 1;
            }
         }
         AV9AdditionalParameter.gxTpr_Authenticationtypename = AV51LogOnTo;
         AV9AdditionalParameter.gxTpr_Otpstep = 1;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV18CaptchaActive) ;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV22CaptchaRequiredText) ;
         AV50LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV68UserName, AV69UserPassword, AV9AdditionalParameter, out  AV30Errors);
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  AV18CaptchaActive) ;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV22CaptchaRequiredText) ;
         if ( ! AV50LoginOK )
         {
            if ( AV30Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("k2bfsg.forcechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12ApplicationClientId))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(1)).gxTpr_Code == 400 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(1)).gxTpr_Code == 410 ) )
                  {
                     CallWebObject(formatLink("k2bfsg.otpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV40IDP_State))}, new string[] {"IDP_State"}) );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     new GeneXus.Programs.k2bfsg.saveincorrectlogin(context ).execute(  AV51LogOnTo,  AV68UserName) ;
                     if ( AV11AmountOfFailedLogins == 1 )
                     {
                        /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                        S242 ();
                        if (returnInSub) return;
                     }
                     else
                     {
                        GXt_boolean3 = AV43IncorrectLoginsExisted;
                        new GeneXus.Programs.k2bfsg.captchashouldberequired(context ).execute(  AV51LogOnTo,  AV68UserName, out  GXt_boolean3) ;
                        AV43IncorrectLoginsExisted = GXt_boolean3;
                        if ( AV43IncorrectLoginsExisted )
                        {
                           /* Execute user subroutine: 'ACTIVATECAPTCHA' */
                           S242 ();
                           if (returnInSub) return;
                        }
                     }
                     CallWebObject(formatLink("k2bfsg.login.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
               }
            }
         }
         else
         {
            new GeneXus.Programs.k2bfsg.savecorrectlogin(context ).execute(  AV51LogOnTo,  AV68UserName) ;
            /* Execute user subroutine: 'DEACTIVATECAPTCHA' */
            S212 ();
            if (returnInSub) return;
            new GeneXus.Programs.k2btools.integrationprocedures.updatecontextafterlogin(context ).execute( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67URL)) )
            {
               CallWebObject(formatLink("k2bfsg.applicationhome.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink(AV67URL) );
               context.wjLocDisableFrm = 0;
            }
         }
      }

      protected void S202( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV22CaptchaRequiredText) ;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV63ShowDetailedMessages) ;
         AssignAttri("", false, "AV63ShowDetailedMessages", AV63ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOWDETAILEDMESSAGES", GetSecureSignedToken( "", AV63ShowDetailedMessages, context));
         AV29ErrorCount = 0;
         AV78GXV5 = 1;
         while ( AV78GXV5 <= AV30Errors.Count )
         {
            AV28Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(AV78GXV5));
            if ( AV28Error.gxTpr_Code == 104 )
            {
               new k2btoolsmsg(context ).execute(  AV28Error.gxTpr_Message,  2) ;
            }
            else
            {
               AV29ErrorCount = (short)(AV29ErrorCount+1);
            }
            AV78GXV5 = (int)(AV78GXV5+1);
         }
         if ( ( AV29ErrorCount > 0 ) || ( StringUtil.StrCmp(AV22CaptchaRequiredText, "true") == 0 ) )
         {
            new k2btoolsmsg(context ).execute(  "Wrong username or password",  2) ;
         }
         if ( AV63ShowDetailedMessages )
         {
            AV79GXV6 = 1;
            while ( AV79GXV6 <= AV30Errors.Count )
            {
               AV28Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV30Errors.Item(AV79GXV6));
               if ( AV28Error.gxTpr_Code != 13 )
               {
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV28Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV28Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  new k2btoolsmsg(context ).execute(  StringUtil.Format( "%1 (GAM%2)", AV28Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV28Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""),  2) ;
               }
               AV79GXV6 = (int)(AV79GXV6+1);
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

      protected void S242( )
      {
         /* 'ACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "true") ;
         new k2bsessionset(context ).execute(  "SessionCaptchaRedirectURL",  AV67URL) ;
      }

      protected void S212( )
      {
         /* 'DEACTIVATECAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaActive",  "false") ;
      }

      protected void S252( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV21CaptchaProvider.generatestringtoken(AV10AmountOfCharacters)) ;
      }

      protected void S192( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaActive", out  AV22CaptchaRequiredText) ;
         if ( StringUtil.StrCmp(AV22CaptchaRequiredText, "true") == 0 )
         {
            /* Execute user subroutine: 'CREATENEWCAPTCHA' */
            S252 ();
            if (returnInSub) return;
            new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV22CaptchaRequiredText) ;
            lblCaptchadescription_Visible = 1;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 1;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 1;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV16Base64String = AV21CaptchaProvider.generateimage(180, 75, AV22CaptchaRequiredText);
            AV22CaptchaRequiredText = "";
            AV19CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV16Base64String;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)) ? AV80Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV19CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV19CaptchaImage), true);
            AV80Captchaimage_GXI = GXDbFile.PathToUrl( "data:image/jpeg;charset=utf-8;base64,"+AV16Base64String);
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)) ? AV80Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV19CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV19CaptchaImage), true);
         }
         else
         {
            AV22CaptchaRequiredText = "";
            lblCaptchadescription_Visible = 0;
            AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
            imgavCaptchaimage_Visible = 0;
            AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
            edtavCaptchatext_Visible = 0;
            AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
            AV19CaptchaImage = "data:image/jpeg;charset=utf-8;base64,R0lGODlhAQABAPAAAP///////ywAAAAAAQABAEAIBAABBAQAOw==";
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)) ? AV80Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV19CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV19CaptchaImage), true);
            AV80Captchaimage_GXI = GXDbFile.PathToUrl( "data:image/jpeg;charset=utf-8;base64,R0lGODlhAQABAPAAAP///////ywAAAAAAQABAEAIBAABBAQAOw==");
            AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19CaptchaImage)) ? AV80Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV19CaptchaImage))), true);
            AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV19CaptchaImage), true);
         }
      }

      private void E173K2( )
      {
         /* Gridauthtypes_Load Routine */
         returnInSub = false;
         AV51LogOnTo = AV52LogOnToDefault;
         AssignAttri("", false, "AV51LogOnTo", AV51LogOnTo);
         cmbavTypeauthtype.Visible = 0;
         AV81GXV7 = 1;
         while ( AV81GXV7 <= AV14AuthenticationTypes.Count )
         {
            AV13AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV14AuthenticationTypes.Item(AV81GXV7));
            if ( AV13AuthenticationType.gxTpr_Redirtoauthenticate )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13AuthenticationType.gxTpr_Smallimagename)) )
               {
                  AV42ImageAuthType = context.GetImagePath( AV13AuthenticationType.gxTpr_Smallimagename, "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV42ImageAuthType);
                  AV82Imageauthtype_GXI = GXDbFile.PathToUrl( AV13AuthenticationType.gxTpr_Smallimagename);
               }
               else
               {
                  edtavImageauthtype_gximage = "GAMButtonGAMRemoteSmall";
                  AV42ImageAuthType = context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV42ImageAuthType);
                  AV82Imageauthtype_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( )));
               }
               AV66TypeAuthType = AV13AuthenticationType.gxTpr_Type;
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV66TypeAuthType);
               AV55NameAuthType = StringUtil.Trim( AV13AuthenticationType.gxTpr_Name);
               AssignAttri("", false, edtavNameauthtype_Internalname, AV55NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV55NameAuthType, "")), context));
               edtavImageauthtype_Tooltiptext = StringUtil.Format( "Sign in with %1", StringUtil.Trim( AV13AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               if ( divExternalauthentications_Visible == 0 )
               {
                  divExternalauthentications_Visible = 1;
                  AssignProp("", false, divExternalauthentications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divExternalauthentications_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 20;
               }
               sendrow_202( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
               {
                  context.DoAjaxLoad(20, GridauthtypesRow);
               }
            }
            AV81GXV7 = (int)(AV81GXV7+1);
         }
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV51LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13AuthenticationType", AV13AuthenticationType);
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV66TypeAuthType);
      }

      protected void E183K2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         if ( AV46KeepMeLoggedIn )
         {
            AV9AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV57RememberMe )
         {
            AV9AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV9AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV9AdditionalParameter.gxTpr_Authenticationtypename = AV55NameAuthType;
         AV50LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV68UserName, AV69UserPassword, AV9AdditionalParameter, out  AV30Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9AdditionalParameter", AV9AdditionalParameter);
      }

      protected void S182( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV34GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV34GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV34GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV30Errors);
            AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
         }
         if ( ! AV5isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV59RepositoryGUID) )
            {
               AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV59RepositoryGUID, out  AV30Errors);
               AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
            }
            else
            {
               AV25ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV25ConnectionInfoCollection.Count > 0 )
               {
                  AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV25ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV30Errors);
                  AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
               }
            }
         }
         if ( AV5isConnectionOK )
         {
            AV34GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV34GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV5isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV34GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV30Errors);
               AssignAttri("", false, "AV5isConnectionOK", AV5isConnectionOK);
               AV34GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
            lblCurrentrepository_Caption = "Repository:"+AV34GAMRepository.gxTpr_Name;
            AssignProp("", false, lblCurrentrepository_Internalname, "Caption", lblCurrentrepository_Caption, true);
            lblCurrentrepository_Visible = 1;
            AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'DISPLAYCHECKBOX' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34GAMRepository.gxTpr_Userremembermetype, "Login") == 0 )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV34GAMRepository.gxTpr_Userremembermetype, "Auth") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV34GAMRepository.gxTpr_Userremembermetype, "Both") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else
         {
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'VALIDLOGONTOOTP' Routine */
         returnInSub = false;
         if ( AV13AuthenticationType.gxTpr_Needusername && ! AV13AuthenticationType.gxTpr_Needuserpassword )
         {
            AV6isModeOTP = true;
            AssignAttri("", false, "AV6isModeOTP", AV6isModeOTP);
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            bttLogin_Caption = "Send access code";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblForgotpassword_action_Visible = 0;
            AssignProp("", false, lblForgotpassword_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblForgotpassword_action_Visible), 5, 0), true);
            lblCreateanaccount_action_Visible = 0;
            AssignProp("", false, lblCreateanaccount_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCreateanaccount_action_Visible), 5, 0), true);
         }
      }

      protected void S262( )
      {
         /* 'SETLOGONFORM' Routine */
         returnInSub = false;
         if ( AV6isModeOTP )
         {
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            bttLogin_Caption = "Send access code";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblForgotpassword_action_Visible = 0;
            AssignProp("", false, lblForgotpassword_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblForgotpassword_action_Visible), 5, 0), true);
            lblCreateanaccount_action_Visible = 0;
            AssignProp("", false, lblCreateanaccount_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCreateanaccount_action_Visible), 5, 0), true);
         }
         else
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavUserpassword_Invitemessage = "Password";
            AssignProp("", false, edtavUserpassword_Internalname, "Invitemessage", edtavUserpassword_Invitemessage, true);
            bttLogin_Caption = "Login";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblForgotpassword_action_Visible = 1;
            AssignProp("", false, lblForgotpassword_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblForgotpassword_action_Visible), 5, 0), true);
            lblCreateanaccount_action_Visible = 1;
            AssignProp("", false, lblCreateanaccount_action_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCreateanaccount_action_Visible), 5, 0), true);
         }
      }

      protected void E143K2( )
      {
         /* Logonto_Click Routine */
         returnInSub = false;
         AV14AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV47Language, out  AV30Errors);
         AV6isModeOTP = false;
         AssignAttri("", false, "AV6isModeOTP", AV6isModeOTP);
         AV83GXV8 = 1;
         while ( AV83GXV8 <= AV14AuthenticationTypes.Count )
         {
            AV13AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV14AuthenticationTypes.Item(AV83GXV8));
            if ( StringUtil.StrCmp(AV13AuthenticationType.gxTpr_Name, AV51LogOnTo) == 0 )
            {
               /* Execute user subroutine: 'VALIDLOGONTOOTP' */
               S172 ();
               if (returnInSub) return;
               if (true) break;
            }
            AV83GXV8 = (int)(AV83GXV8+1);
         }
         /* Execute user subroutine: 'SETLOGONFORM' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13AuthenticationType", AV13AuthenticationType);
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
         PA3K2( ) ;
         WS3K2( ) ;
         WE3K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138195193", true, true);
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
         context.AddJavascriptSource("k2bfsg/login.js", "?2024313819520", false, true);
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
         WB3K0( ) ;
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
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Image Auth Type",(string)"col-sm-3 Fixed30Label",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavImageauthtype_Enabled!=0)&&(edtavImageauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 25,'',false,'',20)\"" : " ");
         ClassString = "Fixed30" + " " + ((StringUtil.StrCmp(edtavImageauthtype_gximage, "")==0) ? "" : "GX_Image_"+edtavImageauthtype_gximage+"_Class");
         StyleString = "";
         AV42ImageAuthType_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV42ImageAuthType))&&String.IsNullOrEmpty(StringUtil.RTrim( AV82Imageauthtype_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV42ImageAuthType)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42ImageAuthType)) ? AV82Imageauthtype_GXI : context.PathToRelativeUrl( AV42ImageAuthType));
         GridauthtypesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImageauthtype_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)edtavImageauthtype_Tooltiptext,(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavImageauthtype_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_20_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV42ImageAuthType_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
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
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,(string)"Name Auth Type",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'',false,'"+sGXsfl_20_idx+"',20)\"" : " ");
         ROClassString = "Attribute";
         GridauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV55NameAuthType),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,29);\"" : " "),"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_20_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"start",(bool)true,(string)""});
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
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavTypeauthtype_Internalname,(string)"Type Auth Type",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         TempTags = " " + ((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 34,'',false,'"+sGXsfl_20_idx+"',20)\"" : " ");
         if ( ( cmbavTypeauthtype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_20_idx;
            cmbavTypeauthtype.Name = GXCCtl;
            cmbavTypeauthtype.WebTags = "";
            cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
            cmbavTypeauthtype.addItem("Custom", "Custom", 0);
            cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
            cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
            cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
            cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
            cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
            cmbavTypeauthtype.addItem("Google", "Google", 0);
            cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
            cmbavTypeauthtype.addItem("OTP", "One Time Password", 0);
            cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
            cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
            cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
            if ( cmbavTypeauthtype.ItemCount > 0 )
            {
               AV66TypeAuthType = cmbavTypeauthtype.getValidValue(AV66TypeAuthType);
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV66TypeAuthType);
            }
         }
         /* ComboBox */
         GridauthtypesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTypeauthtype,(string)cmbavTypeauthtype_Internalname,StringUtil.RTrim( AV66TypeAuthType),(short)1,(string)cmbavTypeauthtype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavTypeauthtype.Visible,cmbavTypeauthtype.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,34);\"" : " "),(string)"",(bool)true,(short)0});
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV66TypeAuthType);
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Values", (string)(cmbavTypeauthtype.ToJavascriptSource()), !bGXsfl_20_Refreshing);
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3K2( ) ;
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
         cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
         cmbavTypeauthtype.addItem("Custom", "Custom", 0);
         cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
         cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
         cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
         cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
         cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
         cmbavTypeauthtype.addItem("Google", "Google", 0);
         cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
         cmbavTypeauthtype.addItem("OTP", "One Time Password", 0);
         cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
         cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
         cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
         if ( cmbavTypeauthtype.ItemCount > 0 )
         {
            AV66TypeAuthType = cmbavTypeauthtype.getValidValue(AV66TypeAuthType);
            AssignAttri("", false, cmbavTypeauthtype_Internalname, AV66TypeAuthType);
         }
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV51LogOnTo = cmbavLogonto.getValidValue(AV51LogOnTo);
            AssignAttri("", false, "AV51LogOnTo", AV51LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV46KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV46KeepMeLoggedIn));
         AssignAttri("", false, "AV46KeepMeLoggedIn", AV46KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV57RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV57RememberMe));
         AssignAttri("", false, "AV57RememberMe", AV57RememberMe);
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
            GridauthtypesColumn.AddObjectProperty("Value", context.convertURL( AV42ImageAuthType));
            GridauthtypesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavImageauthtype_Tooltiptext));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
            GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV55NameAuthType)));
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
            GridauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV66TypeAuthType)));
            GridauthtypesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Visible), 5, 0, ".", "")));
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
         imgImage_Internalname = "IMAGE";
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
         divSection4_Internalname = "SECTION4";
         edtavUsername_Internalname = "vUSERNAME";
         divSection3_Internalname = "SECTION3";
         divSection6_Internalname = "SECTION6";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divSection5_Internalname = "SECTION5";
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
         chkavRememberme.Caption = "Remember me";
         chkavKeepmeloggedin.Caption = "Keep me logged in";
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
         edtavImageauthtype_Tooltiptext = "";
         subGridauthtypes_Class = "FreeStyleGrid";
         subGridauthtypes_Backcolorstyle = 0;
         bttLogin_Caption = "Login";
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
         lblCreateanaccount_action_Visible = 1;
         lblForgotpassword_action_Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Invitemessage = "Password";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         divExternalauthentications_Visible = 1;
         lblCurrentrepository_Caption = "Text Block";
         lblCurrentrepository_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDAUTHTYPES_nEOF'},{av:'AV40IDP_State',fld:'vIDP_STATE',pic:''},{av:'cmbavLogonto'},{av:'AV51LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV68UserName',fld:'vUSERNAME',pic:''},{av:'AV6isModeOTP',fld:'vISMODEOTP',pic:''},{av:'AV10AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV46KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV57RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV53LogOnToTmp',fld:'vLOGONTOTMP',pic:'',hsh:true},{av:'AV70UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV63ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'AV52LogOnToDefault',fld:'vLOGONTODEFAULT',pic:'',hsh:true},{av:'AV47Language',fld:'vLANGUAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV69UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV67URL',fld:'vURL',pic:''},{av:'AV57RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV6isModeOTP',fld:'vISMODEOTP',pic:''},{av:'lblCaptchadescription_Visible',ctrl:'CAPTCHADESCRIPTION',prop:'Visible'},{av:'imgavCaptchaimage_Visible',ctrl:'vCAPTCHAIMAGE',prop:'Visible'},{av:'edtavCaptchatext_Visible',ctrl:'vCAPTCHATEXT',prop:'Visible'},{av:'AV19CaptchaImage',fld:'vCAPTCHAIMAGE',pic:''},{av:'AV63ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:'',hsh:true},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblForgotpassword_action_Visible',ctrl:'FORGOTPASSWORD_ACTION',prop:'Visible'},{av:'lblCreateanaccount_action_Visible',ctrl:'CREATEANACCOUNT_ACTION',prop:'Visible'},{av:'edtavUserpassword_Invitemessage',ctrl:'vUSERPASSWORD',prop:'Invitemessage'}]}");
         setEventMetadata("ENTER","{handler:'E133K2',iparms:[{av:'cmbavLogonto'},{av:'AV51LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV68UserName',fld:'vUSERNAME',pic:''},{av:'AV23CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV46KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV57RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV69UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV12ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV40IDP_State',fld:'vIDP_STATE',pic:''},{av:'AV67URL',fld:'vURL',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV67URL',fld:'vURL',pic:''},{av:'AV10AmountOfCharacters',fld:'vAMOUNTOFCHARACTERS',pic:'ZZZ9'},{av:'AV12ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV40IDP_State',fld:'vIDP_STATE',pic:''}]}");
         setEventMetadata("'E_FORGOTPASSWORD'","{handler:'E113K1',iparms:[]");
         setEventMetadata("'E_FORGOTPASSWORD'",",oparms:[]}");
         setEventMetadata("'E_CREATEANACCOUNT'","{handler:'E123K1',iparms:[]");
         setEventMetadata("'E_CREATEANACCOUNT'",",oparms:[]}");
         setEventMetadata("GRIDAUTHTYPES.LOAD","{handler:'E173K2',iparms:[{av:'AV52LogOnToDefault',fld:'vLOGONTODEFAULT',pic:'',hsh:true},{av:'divExternalauthentications_Visible',ctrl:'EXTERNALAUTHENTICATIONS',prop:'Visible'}]");
         setEventMetadata("GRIDAUTHTYPES.LOAD",",oparms:[{av:'cmbavLogonto'},{av:'AV51LogOnTo',fld:'vLOGONTO',pic:''},{av:'cmbavTypeauthtype'},{av:'AV42ImageAuthType',fld:'vIMAGEAUTHTYPE',pic:''},{av:'AV66TypeAuthType',fld:'vTYPEAUTHTYPE',pic:''},{av:'AV55NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'edtavImageauthtype_Tooltiptext',ctrl:'vIMAGEAUTHTYPE',prop:'Tooltiptext'},{av:'divExternalauthentications_Visible',ctrl:'EXTERNALAUTHENTICATIONS',prop:'Visible'}]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E183K2',iparms:[{av:'AV46KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV57RememberMe',fld:'vREMEMBERME',pic:''},{av:'AV55NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV68UserName',fld:'vUSERNAME',pic:''},{av:'AV69UserPassword',fld:'vUSERPASSWORD',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[]}");
         setEventMetadata("VLOGONTO.CLICK","{handler:'E143K2',iparms:[{av:'AV47Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavLogonto'},{av:'AV51LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV6isModeOTP',fld:'vISMODEOTP',pic:''}]");
         setEventMetadata("VLOGONTO.CLICK",",oparms:[{av:'AV6isModeOTP',fld:'vISMODEOTP',pic:''},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{ctrl:'LOGIN',prop:'Caption'},{av:'lblForgotpassword_action_Visible',ctrl:'FORGOTPASSWORD_ACTION',prop:'Visible'},{av:'lblCreateanaccount_action_Visible',ctrl:'CREATEANACCOUNT_ACTION',prop:'Visible'},{av:'edtavUserpassword_Invitemessage',ctrl:'vUSERPASSWORD',prop:'Invitemessage'}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV40IDP_State = "";
         AV51LogOnTo = "";
         AV68UserName = "";
         AV53LogOnToTmp = "";
         AV52LogOnToDefault = "";
         AV47Language = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12ApplicationClientId = "";
         AV67URL = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         imgImage_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblCurrentrepository_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         AV69UserPassword = "";
         lblForgotpassword_action_Jsonclick = "";
         lblCreateanaccount_action_Jsonclick = "";
         lblCaptchadescription_Jsonclick = "";
         AV19CaptchaImage = "";
         AV80Captchaimage_GXI = "";
         AV23CaptchaText = "";
         bttLogin_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV42ImageAuthType = "";
         AV82Imageauthtype_GXI = "";
         AV55NameAuthType = "";
         AV66TypeAuthType = "";
         AV74GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV73DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         AV59RepositoryGUID = "";
         AV30Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV25ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV34GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV14AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV13AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV58Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV31ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV60Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV9AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         GXt_char2 = "";
         AV18CaptchaActive = "";
         AV22CaptchaRequiredText = "";
         AV28Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV21CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV16Base64String = "";
         GridauthtypesRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridauthtypes_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         subGridauthtypes_Header = "";
         GridauthtypesColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
         cmbavTypeauthtype.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV70UserRememberMe ;
      private short AV10AmountOfCharacters ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridauthtypes_Backcolorstyle ;
      private short AV11AmountOfFailedLogins ;
      private short GRIDAUTHTYPES_nEOF ;
      private short AV29ErrorCount ;
      private short nGXWrapped ;
      private short subGridauthtypes_Backstyle ;
      private short subGridauthtypes_Allowselection ;
      private short subGridauthtypes_Allowhovering ;
      private short subGridauthtypes_Allowcollapsing ;
      private short subGridauthtypes_Collapsed ;
      private int divExternalauthentications_Visible ;
      private int nRC_GXsfl_20 ;
      private int subGridauthtypes_Recordcount ;
      private int nGXsfl_20_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int lblCurrentrepository_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int lblForgotpassword_action_Visible ;
      private int lblCreateanaccount_action_Visible ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int edtavCaptchatext_Enabled ;
      private int subGridauthtypes_Islastpage ;
      private int AV75GXV2 ;
      private int AV76GXV3 ;
      private int AV77GXV4 ;
      private int AV78GXV5 ;
      private int AV79GXV6 ;
      private int AV81GXV7 ;
      private int AV83GXV8 ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_20_idx="0001" ;
      private string AV40IDP_State ;
      private string AV51LogOnTo ;
      private string AV53LogOnToTmp ;
      private string AV52LogOnToDefault ;
      private string AV47Language ;
      private string edtavNameauthtype_Internalname ;
      private string cmbavTypeauthtype_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV12ApplicationClientId ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable3_Internalname ;
      private string divImagecontainer_Internalname ;
      private string divImagetransparency_Internalname ;
      private string divTable22_Internalname ;
      private string ClassString ;
      private string imgImage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage_Internalname ;
      private string lblCurrentrepository_Internalname ;
      private string lblCurrentrepository_Caption ;
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
      private string cmbavLogonto_Jsonclick ;
      private string divSection3_Internalname ;
      private string divSection4_Internalname ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string divSection5_Internalname ;
      private string divSection6_Internalname ;
      private string edtavUserpassword_Internalname ;
      private string AV69UserPassword ;
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
      private string AV23CaptchaText ;
      private string edtavCaptchatext_Jsonclick ;
      private string bttLogin_Internalname ;
      private string bttLogin_Caption ;
      private string bttLogin_Jsonclick ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavImageauthtype_Internalname ;
      private string AV55NameAuthType ;
      private string AV66TypeAuthType ;
      private string AV59RepositoryGUID ;
      private string GXt_char2 ;
      private string AV18CaptchaActive ;
      private string AV22CaptchaRequiredText ;
      private string AV16Base64String ;
      private string edtavImageauthtype_gximage ;
      private string edtavImageauthtype_Tooltiptext ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string subGridauthtypes_Class ;
      private string subGridauthtypes_Linesclass ;
      private string divGridauthtypestable1_Internalname ;
      private string edtavImageauthtype_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private string divSection1_Internalname ;
      private string GXCCtl ;
      private string cmbavTypeauthtype_Jsonclick ;
      private string subGridauthtypes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV63ShowDetailedMessages ;
      private bool AV6isModeOTP ;
      private bool AV46KeepMeLoggedIn ;
      private bool AV57RememberMe ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool AV19CaptchaImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5isConnectionOK ;
      private bool AV15BadLoginsExpire ;
      private bool AV62ShouldAddSleepOnFailure ;
      private bool AV44isOK ;
      private bool gx_refresh_fired ;
      private bool AV45isRedirect ;
      private bool AV61SessionValid ;
      private bool AV43IncorrectLoginsExisted ;
      private bool AV20CaptchaIsCorrect ;
      private bool AV50LoginOK ;
      private bool GXt_boolean3 ;
      private bool AV42ImageAuthType_IsBlob ;
      private string AV68UserName ;
      private string AV67URL ;
      private string AV80Captchaimage_GXI ;
      private string AV82Imageauthtype_GXI ;
      private string AV19CaptchaImage ;
      private string AV42ImageAuthType ;
      private GXWebGrid GridauthtypesContainer ;
      private GXWebRow GridauthtypesRow ;
      private GXWebColumn GridauthtypesColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private SdtK2BToolsCaptchaProvider AV21CaptchaProvider ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTypeauthtype ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV14AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV25ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV31ErrorsLogin ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV74GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV9AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV13AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV28Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV34GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV58Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV60Session ;
      private SdtK2BAttributeValue_Item AV73DesignSystemOption ;
   }

}
