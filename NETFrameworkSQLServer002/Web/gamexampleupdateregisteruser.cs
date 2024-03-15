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
   public class gamexampleupdateregisteruser : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public gamexampleupdateregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamexampleupdateregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV13IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV13IDP_State;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGender = new GXCombobox();
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
               AV13IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
               GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
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
            PA2X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE2X2( ) ;
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
         context.SendWebValue( context.GetMessage( "Update register user", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 115740), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 115740), false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
      }

      protected void RenderHtmlCloseForm2X2( )
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
         return "GAMExampleUpdateRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Update register user", "") ;
      }

      protected void WB2X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, context.GetMessage( "Update user data", ""), "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavName_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, context.GetMessage( "User name  *", ""), "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV16Name, StringUtil.RTrim( context.localUtil.Format( AV16Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", edtavName_Visible, edtavName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, edtavEmail_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV6EMail, StringUtil.RTrim( context.localUtil.Format( AV6EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, edtavFirstname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV7FirstName), StringUtil.RTrim( context.localUtil.Format( AV7FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, edtavLastname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV15LastName), StringUtil.RTrim( context.localUtil.Format( AV15LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, edtavBirthday_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV5Birthday, "99/99/9999"), context.localUtil.Format( AV5Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBirthday_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, cmbavGender.Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV12Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_GAMExampleUpdateRegisterUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV12Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "Button button-secondary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonlogin_Internalname, "", context.GetMessage( "Back to Login", ""), bttButtonlogin_Jsonclick, 5, context.GetMessage( "Back to Login", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'RETURNTOLOGIN\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButton2_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttButton2_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2X2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Update register user", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2X0( ) ;
      }

      protected void WS2X2( )
      {
         START2X2( ) ;
         EVT2X2( ) ;
      }

      protected void EVT2X2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112X2 ();
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
                                 E122X2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'RETURNTOLOGIN'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'ReturnToLogin' */
                           E132X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E142X2 ();
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE2X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2X2( ) ;
            }
         }
      }

      protected void PA2X2( )
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
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavGender.ItemCount > 0 )
         {
            AV12Gender = cmbavGender.getValidValue(AV12Gender);
            AssignAttri("", false, "AV12Gender", AV12Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV12Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142X2 ();
            WB2X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2X2( )
      {
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV16Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV16Name", AV16Name);
            AV6EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV7FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV7FirstName", AV7FirstName);
            AV15LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV15LastName", AV15LastName);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Birthday", "")}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            else
            {
               AV5Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV12Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV12Gender", AV12Gender);
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
         E112X2 ();
         if (returnInSub) return;
      }

      protected void E112X2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV10GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavName_Visible = 0;
            AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'MARKREQUIEREDUSERDATA' */
         S112 ();
         if (returnInSub) return;
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV9GAMErrorCollection);
         if ( AV9GAMErrorCollection.Count > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
         else
         {
            AV9GAMErrorCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
            AV16Name = AV11GAMUser.gxTpr_Name;
            AssignAttri("", false, "AV16Name", AV16Name);
            AV6EMail = AV11GAMUser.gxTpr_Email;
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV7FirstName = AV11GAMUser.gxTpr_Firstname;
            AssignAttri("", false, "AV7FirstName", AV7FirstName);
            AV15LastName = AV11GAMUser.gxTpr_Lastname;
            AssignAttri("", false, "AV15LastName", AV15LastName);
            AV5Birthday = AV11GAMUser.gxTpr_Birthday;
            AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            AV12Gender = AV11GAMUser.gxTpr_Gender;
            AssignAttri("", false, "AV12Gender", AV12Gender);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E122X2 ();
         if (returnInSub) return;
      }

      protected void E122X2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV9GAMErrorCollection);
         AV11GAMUser.gxTpr_Name = AV16Name;
         AV11GAMUser.gxTpr_Email = AV6EMail;
         AV11GAMUser.gxTpr_Firstname = AV7FirstName;
         AV11GAMUser.gxTpr_Lastname = AV15LastName;
         AV11GAMUser.gxTpr_Birthday = AV5Birthday;
         AV11GAMUser.gxTpr_Gender = AV12Gender;
         AV14isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateuserbykeytocompleteuserdata(AV11GAMUser, out  AV9GAMErrorCollection);
         if ( AV14isOK )
         {
            if ( AV9GAMErrorCollection.Count > 0 )
            {
               GX_msglist.addItem(context.GetMessage( "Your data has been updated successfully!.", ""));
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV13IDP_State) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV13IDP_State) ;
               }
               else
               {
                  AV17URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17URL)) )
                  {
                     CallWebObject(formatLink("gamhome.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV17URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
      }

      protected void S112( )
      {
         /* 'MARKREQUIEREDUSERDATA' Routine */
         returnInSub = false;
         if ( AV10GAMRepository.gxTpr_Requiredemail )
         {
            edtavEmail_Caption = edtavEmail_Caption+"  *";
            AssignProp("", false, edtavEmail_Internalname, "Caption", edtavEmail_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredfirstname )
         {
            edtavFirstname_Caption = edtavFirstname_Caption+"  *";
            AssignProp("", false, edtavFirstname_Internalname, "Caption", edtavFirstname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredlastname )
         {
            edtavLastname_Caption = edtavLastname_Caption+"  *";
            AssignProp("", false, edtavLastname_Internalname, "Caption", edtavLastname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredbirthday )
         {
            edtavBirthday_Caption = edtavBirthday_Caption+"  *";
            AssignProp("", false, edtavBirthday_Internalname, "Caption", edtavBirthday_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredgender )
         {
            cmbavGender.Caption = cmbavGender.Caption+"  *";
            AssignProp("", false, cmbavGender_Internalname, "Caption", cmbavGender.Caption, true);
         }
      }

      protected void E132X2( )
      {
         /* 'ReturnToLogin' Routine */
         returnInSub = false;
         AV14isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logout(out  AV9GAMErrorCollection);
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV9GAMErrorCollection.Count )
         {
            AV8GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV18GXV1));
            GX_msglist.addItem(AV8GAMError.gxTpr_Message);
            AV18GXV1 = (int)(AV18GXV1+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E142X2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
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
         PA2X2( ) ;
         WS2X2( ) ;
         WE2X2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243122134268", true, true);
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
         context.AddJavascriptSource("gamexampleupdateregisteruser.js", "?202431221342611", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", context.GetMessage( "Not Specified", ""), 0);
         cmbavGender.addItem("F", context.GetMessage( "Female", ""), 0);
         cmbavGender.addItem("M", context.GetMessage( "Male", ""), 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV12Gender = cmbavGender.getValidValue(AV12Gender);
            AssignAttri("", false, "AV12Gender", AV12Gender);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         edtavBirthday_Internalname = "vBIRTHDAY";
         cmbavGender_Internalname = "vGENDER";
         bttButtonlogin_Internalname = "BUTTONLOGIN";
         bttButton2_Internalname = "BUTTON2";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         cmbavGender.Caption = context.GetMessage( "Gender", "");
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         edtavBirthday_Caption = context.GetMessage( "Birthday", "");
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavLastname_Caption = context.GetMessage( "Last name", "");
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavFirstname_Caption = context.GetMessage( "First name", "");
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavEmail_Caption = context.GetMessage( "Email", "");
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavName_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E122X2',iparms:[{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV6EMail',fld:'vEMAIL',pic:''},{av:'AV7FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV15LastName',fld:'vLASTNAME',pic:''},{av:'AV5Birthday',fld:'vBIRTHDAY',pic:''},{av:'cmbavGender'},{av:'AV12Gender',fld:'vGENDER',pic:''},{av:'AV13IDP_State',fld:'vIDP_STATE',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("'RETURNTOLOGIN'","{handler:'E132X2',iparms:[]");
         setEventMetadata("'RETURNTOLOGIN'",",oparms:[]}");
         setEventMetadata("VALIDV_BIRTHDAY","{handler:'Validv_Birthday',iparms:[]");
         setEventMetadata("VALIDV_BIRTHDAY",",oparms:[]}");
         setEventMetadata("VALIDV_GENDER","{handler:'Validv_Gender',iparms:[]");
         setEventMetadata("VALIDV_GENDER",",oparms:[]}");
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
         wcpOAV13IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         TempTags = "";
         AV16Name = "";
         AV6EMail = "";
         AV7FirstName = "";
         AV15LastName = "";
         AV5Birthday = DateTime.MinValue;
         AV12Gender = "";
         ClassString = "";
         StyleString = "";
         bttButtonlogin_Jsonclick = "";
         bttButton2_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV17URL = "";
         AV8GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Visible ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavBirthday_Enabled ;
      private int AV18GXV1 ;
      private int idxLst ;
      private string AV13IDP_State ;
      private string wcpOAV13IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Caption ;
      private string edtavEmail_Jsonclick ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Caption ;
      private string AV7FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Caption ;
      private string AV15LastName ;
      private string edtavLastname_Jsonclick ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Caption ;
      private string edtavBirthday_Jsonclick ;
      private string cmbavGender_Internalname ;
      private string AV12Gender ;
      private string cmbavGender_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttButtonlogin_Internalname ;
      private string bttButtonlogin_Jsonclick ;
      private string bttButton2_Internalname ;
      private string bttButton2_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV5Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14isOK ;
      private string AV16Name ;
      private string AV6EMail ;
      private string AV17URL ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavGender ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMError ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV10GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
   }

}
