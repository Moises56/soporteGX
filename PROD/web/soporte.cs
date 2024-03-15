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
namespace GeneXus.Programs {
   public class soporte : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
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
               AV8soporteID = (int)(Math.Round(NumberUtil.Val( GetPar( "soporteID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV8soporteID", StringUtil.LTrimStr( (decimal)(AV8soporteID), 9, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8soporteID});
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8soporteID = (int)(Math.Round(NumberUtil.Val( GetPar( "soporteID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8soporteID", StringUtil.LTrimStr( (decimal)(AV8soporteID), 9, 0));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_5-175581", 0) ;
               }
            }
            Form.Meta.addItem("description", "soporte", 0) ;
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
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edthostName_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public soporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("AriesCustom", true);
         }
      }

      public soporte( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_soporteID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8soporteID = aP1_soporteID;
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
            return "soporte_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
            RenderHtmlCloseForm022( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "soporte.aspx");
            context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besmaintable_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2beserrviewercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besdataareacontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2babstracttabledataareacontainer_Internalname, 1, 0, "px", 0, "px", divK2babstracttabledataareacontainer_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btrnformmaintablecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributesinformsection1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersoporteid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtsoporteID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtsoporteID_Internalname, "ID", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
         GxWebStd.gx_single_line_edit( context, edtsoporteID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4soporteID), 9, 0, ".", "")), StringUtil.LTrim( ((edtsoporteID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtsoporteID_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtsoporteID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerhostname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edthostName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edthostName_Internalname, "Name", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A5hostName", A5hostName);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edthostName_Internalname, A5hostName, StringUtil.RTrim( context.localUtil.Format( A5hostName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edthostName_Jsonclick, 0, edthostName_Class, "", "", "", "", 1, edthostName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerserie_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtserie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtserie_Internalname, "serie", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A9serie", A9serie);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtserie_Internalname, A9serie, StringUtil.RTrim( context.localUtil.Format( A9serie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtserie_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtserie_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineripv4_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtipv4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtipv4_Internalname, "ipv4", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A10ipv4", A10ipv4);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtipv4_Internalname, A10ipv4, StringUtil.RTrim( context.localUtil.Format( A10ipv4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtipv4_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtipv4_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainermac_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtmac_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmac_Internalname, "mac", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A11mac", A11mac);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtmac_Internalname, A11mac, StringUtil.RTrim( context.localUtil.Format( A11mac, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmac_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtmac_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainermodelo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtmodelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmodelo_Internalname, "modelo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A12modelo", A12modelo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtmodelo_Internalname, A12modelo, StringUtil.RTrim( context.localUtil.Format( A12modelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmodelo_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtmodelo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombreusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtnombreUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombreUsuario_Internalname, "Usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A13nombreUsuario", A13nombreUsuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtnombreUsuario_Internalname, A13nombreUsuario, StringUtil.RTrim( context.localUtil.Format( A13nombreUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtnombreUsuario_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtnombreUsuario_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombredepartamento_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "start", "top", ""+" data-gx-for=\""+edtnombreDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombreDepartamento_Internalname, "Departamento", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A14nombreDepartamento", A14nombreDepartamento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtnombreDepartamento_Internalname, A14nombreDepartamento, StringUtil.RTrim( context.localUtil.Format( A14nombreDepartamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtnombreDepartamento_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtnombreDepartamento_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_soporte.htm");
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
         GxWebStd.gx_div_start( context, divK2besactioncontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divActionscontainerbuttons_Internalname, 1, 0, "px", 0, "px", "Table_TrnActionsContainer", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_soporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BToolsTableCell_ActionContainer", "start", "top", "", "flex-grow:1;", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancel", bttCancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_soporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2bescontrolbeaufitycell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z4soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z4soporteID"), ".", ","), 18, MidpointRounding.ToEven));
               Z5hostName = cgiGet( sPrefix+"Z5hostName");
               Z9serie = cgiGet( sPrefix+"Z9serie");
               Z10ipv4 = cgiGet( sPrefix+"Z10ipv4");
               Z11mac = cgiGet( sPrefix+"Z11mac");
               Z12modelo = cgiGet( sPrefix+"Z12modelo");
               Z13nombreUsuario = cgiGet( sPrefix+"Z13nombreUsuario");
               Z14nombreDepartamento = cgiGet( sPrefix+"Z14nombreDepartamento");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8soporteID"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vSOPORTEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV27Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A4soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtsoporteID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
               A5hostName = cgiGet( edthostName_Internalname);
               AssignAttri(sPrefix, false, "A5hostName", A5hostName);
               A9serie = cgiGet( edtserie_Internalname);
               AssignAttri(sPrefix, false, "A9serie", A9serie);
               A10ipv4 = cgiGet( edtipv4_Internalname);
               AssignAttri(sPrefix, false, "A10ipv4", A10ipv4);
               A11mac = cgiGet( edtmac_Internalname);
               AssignAttri(sPrefix, false, "A11mac", A11mac);
               A12modelo = cgiGet( edtmodelo_Internalname);
               AssignAttri(sPrefix, false, "A12modelo", A12modelo);
               A13nombreUsuario = cgiGet( edtnombreUsuario_Internalname);
               AssignAttri(sPrefix, false, "A13nombreUsuario", A13nombreUsuario);
               A14nombreDepartamento = cgiGet( edtnombreDepartamento_Internalname);
               AssignAttri(sPrefix, false, "A14nombreDepartamento", A14nombreDepartamento);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"soporte");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A4soporteID != Z4soporteID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("soporte:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A4soporteID = (int)(Math.Round(NumberUtil.Val( GetPar( "soporteID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SOPORTEID");
                        AnyError = 1;
                        GX_FocusControl = edtsoporteID_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E11022 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E12022 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOCANCEL'") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: 'DoCancel' */
                                 E13022 ();
                              }
                           }
                           nKeyPressed = 3;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttEnter_Visible = 0;
               AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
            }
            DisableAttributes022( ) ;
         }
         AssignProp(sPrefix, false, edthostName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edthostName_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtserie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtserie_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtipv4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtipv4_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtmac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmac_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtmodelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmodelo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombreUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombreUsuario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombreDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombreDepartamento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         new k2bgetcontext(context ).execute( out  AV14Context) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV19StandardActivityType = "Insert";
            AssignAttri(sPrefix, false, "AV19StandardActivityType", AV19StandardActivityType);
            AV20UserActivityType = "";
            AssignAttri(sPrefix, false, "AV20UserActivityType", AV20UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV19StandardActivityType = "Update";
            AssignAttri(sPrefix, false, "AV19StandardActivityType", AV19StandardActivityType);
            AV20UserActivityType = "";
            AssignAttri(sPrefix, false, "AV20UserActivityType", AV20UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV19StandardActivityType = "Delete";
            AssignAttri(sPrefix, false, "AV19StandardActivityType", AV19StandardActivityType);
            AV20UserActivityType = "";
            AssignAttri(sPrefix, false, "AV20UserActivityType", AV20UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV19StandardActivityType = "Display";
            AssignAttri(sPrefix, false, "AV19StandardActivityType", AV19StandardActivityType);
            AV20UserActivityType = "";
            AssignAttri(sPrefix, false, "AV20UserActivityType", AV20UserActivityType);
         }
         new k2bisauthorizedactivityname(context ).execute(  "soporte",  "soporte",  AV19StandardActivityType,  AV20UserActivityType,  AV27Pgmname, out  AV21IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV21IsAuthorized", AV21IsAuthorized);
         if ( ! AV21IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("soporte")),UrlEncode(StringUtil.RTrim("soporte")),UrlEncode(StringUtil.RTrim(AV19StandardActivityType)),UrlEncode(StringUtil.RTrim(AV20UserActivityType)),UrlEncode(StringUtil.RTrim(AV27Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
         AV29GXV2 = 1;
         AssignAttri(sPrefix, false, "AV29GXV2", StringUtil.LTrimStr( (decimal)(AV29GXV2), 8, 0));
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV28GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV28GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV29GXV2 <= AV28GXV1.Count )
         {
            AV26ActivityLogProperty = ((SdtK2BAttributeValue_Item)AV28GXV1.Item(AV29GXV2));
            this.executeExternalObjectMethod(sPrefix, false, "gx.core.ds", "setOption", new Object[] {AV26ActivityLogProperty.gxTpr_Attributename,AV26ActivityLogProperty.gxTpr_Attributevalue}, false);
            AV29GXV2 = (int)(AV29GXV2+1);
            AssignAttri(sPrefix, false, "AV29GXV2", StringUtil.LTrimStr( (decimal)(AV29GXV2), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            divK2babstracttabledataareacontainer_Class = divK2babstracttabledataareacontainer_Class+" "+"K2BT_EditableForm";
            AssignProp(sPrefix, false, divK2babstracttabledataareacontainer_Internalname, "Class", divK2babstracttabledataareacontainer_Class, true);
         }
         AV15BtnCaption = "Confirm";
         AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
         AV16BtnTooltip = "Confirm";
         AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV15BtnCaption = "Update";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Update";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV15BtnCaption = "Confirm";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Confirm";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV15BtnCaption = "Delete";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Delete";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         bttEnter_Caption = AV15BtnCaption;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Caption", bttEnter_Caption, true);
         bttEnter_Tooltiptext = AV16BtnTooltip;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Tooltiptext", bttEnter_Tooltiptext, true);
         bttEnter_Visible = 0;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
         bttCancel_Visible = 0;
         AssignProp(sPrefix, false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            bttEnter_Visible = 1;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
            bttCancel_Visible = 1;
            AssignProp(sPrefix, false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
         }
         new k2bgettrncontextbyname(context ).execute(  "soporte", out  AV10TrnContext) ;
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insert %1", "soporte", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Update %1", "soporte", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Delete %1", "soporte", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edthostName_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edthostName_Internalname, "Class", edthostName_Class, true);
            }
            else
            {
               edthostName_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edthostName_Internalname, "Class", edthostName_Class, true);
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV10TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 ) || ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Raiseafterconfirmevent, "\"\"") != 0 ) )
         {
            AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
            AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV23AttributeValueItem.gxTpr_Attributename = "soporteID";
            AV23AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A4soporteID), 9, 0);
            AV22AttributeValue.Add(AV23AttributeValueItem, 0);
            if ( AV10TrnContext.gxTpr_Savepk )
            {
               new k2bsettransactionpk(context ).execute(  "soporte",  AV22AttributeValue) ;
            }
         }
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "The soporte %1 was created", A5hostName, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "The soporte %1 was updated", A5hostName, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "The soporte %1 was deleted", A5hostName, "", "", "", "", "", "", "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Message.gxTpr_Description)) )
         {
            new k2btoolsmessagequeueadd(context ).execute(  AV24Message) ;
         }
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"soporte",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV22AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV10TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV10TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "soporte") ;
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV12Navigation = AV10TrnContext.gxTpr_Afterinsert;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               AV12Navigation = AV10TrnContext.gxTpr_Afterupdate;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV12Navigation = AV10TrnContext.gxTpr_Afterdelete;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AttributeValue", AV22AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12Navigation", AV12Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", AV10TrnContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9EventArgs", AV9EventArgs);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV18encrypt = AV10TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18encrypt)) )
         {
            GXt_char2 = AV18encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char2) ;
            AV18encrypt = GXt_char2;
         }
         if ( AV12Navigation.gxTpr_Aftertrn == 2 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem("K2BEntityServices: TransactionNavigation Invalid invocation method. Delete method cannot return using entity manager");
            }
            else
            {
               AV13DinamicObjToLink = StringUtil.Lower( AV10TrnContext.gxTpr_Entitymanagername);
               if ( StringUtil.StrCmp(AV18encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A4soporteID,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A4soporteID = (int)(args[2]) ;
                        AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV18encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A4soporteID,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A4soporteID = (int)(args[2]) ;
                           AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                        else
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A4soporteID,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A4soporteID = (int)(args[1]) ;
                           AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
         }
         else
         {
            if ( AV12Navigation.gxTpr_Aftertrn == 3 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Navigation.gxTpr_Mode)) )
               {
                  AV12Navigation.gxTpr_Mode = Gx_mode;
               }
               AV13DinamicObjToLink = StringUtil.Lower( AV12Navigation.gxTpr_Objecttolink);
               if ( StringUtil.StrCmp(AV18encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV12Navigation.gxTpr_Mode,(int)A4soporteID,AV12Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV12Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A4soporteID = (int)(args[2]) ;
                        AV12Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV18encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV12Navigation.gxTpr_Mode,(int)A4soporteID,AV12Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV12Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A4soporteID = (int)(args[2]) ;
                           AV12Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                        else
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV12Navigation.gxTpr_Mode,(int)A4soporteID,AV12Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV12Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A4soporteID = (int)(args[1]) ;
                           AV12Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A4soporteID,9,0)),UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
            else
            {
               if ( AV12Navigation.gxTpr_Aftertrn == 5 )
               {
                  if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Raiseafterconfirmevent, "TransactionConfirmed") == 0 )
                  {
                     /* Execute user subroutine: 'SAVEEVENTARGS' */
                     S132 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        returnInSub = true;
                        if (true) return;
                     }
                     this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_TransactionConfirmed", new Object[] {(GeneXus.Programs.k2btools.transactionutils.SdtTransactionEventArgs)AV9EventArgs}, true);
                  }
               }
               else
               {
                  /* Execute user subroutine: 'K2BCLOSE' */
                  S122 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
         }
      }

      protected void E13022( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "soporte") ;
         /* Execute user subroutine: 'K2BCLOSE' */
         S122 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AttributeValue", AV22AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9EventArgs", AV9EventArgs);
      }

      protected void S122( )
      {
         /* 'K2BCLOSE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"soporte"}, true);
         }
         else if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Stack") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            pr_default.close(1);
            returnInSub = true;
            if (true) return;
         }
         else if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "CallerObject") == 0 )
         {
            AV17Url = AV10TrnContext.gxTpr_Callerurl;
            CallWebObject(formatLink(AV17Url) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Raiseaftercancelevent, "\"\"") == 0 )
            {
               AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
               AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
               AV23AttributeValueItem.gxTpr_Attributename = "soporteID";
               AV23AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8soporteID), 9, 0);
               AV22AttributeValue.Add(AV23AttributeValueItem, 0);
               /* Execute user subroutine: 'SAVEEVENTARGS' */
               S132 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_TransactionCancelled", new Object[] {(GeneXus.Programs.k2btools.transactionutils.SdtTransactionEventArgs)AV9EventArgs}, true);
            }
            else
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S132( )
      {
         /* 'SAVEEVENTARGS' Routine */
         returnInSub = false;
         AV9EventArgs = new GeneXus.Programs.k2btools.transactionutils.SdtTransactionEventArgs(context);
         AV9EventArgs.gxTpr_Programname = AV27Pgmname;
         AV9EventArgs.gxTpr_Mode = Gx_mode;
         AV9EventArgs.gxTpr_Keyvalue = AV22AttributeValue;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5hostName = T00023_A5hostName[0];
               Z9serie = T00023_A9serie[0];
               Z10ipv4 = T00023_A10ipv4[0];
               Z11mac = T00023_A11mac[0];
               Z12modelo = T00023_A12modelo[0];
               Z13nombreUsuario = T00023_A13nombreUsuario[0];
               Z14nombreDepartamento = T00023_A14nombreDepartamento[0];
            }
            else
            {
               Z5hostName = A5hostName;
               Z9serie = A9serie;
               Z10ipv4 = A10ipv4;
               Z11mac = A11mac;
               Z12modelo = A12modelo;
               Z13nombreUsuario = A13nombreUsuario;
               Z14nombreDepartamento = A14nombreDepartamento;
            }
         }
         if ( GX_JID == -6 )
         {
            Z4soporteID = A4soporteID;
            Z5hostName = A5hostName;
            Z9serie = A9serie;
            Z10ipv4 = A10ipv4;
            Z11mac = A11mac;
            Z12modelo = A12modelo;
            Z13nombreUsuario = A13nombreUsuario;
            Z14nombreDepartamento = A14nombreDepartamento;
         }
      }

      protected void standaloneNotModal( )
      {
         edtsoporteID_Enabled = 0;
         AssignProp(sPrefix, false, edtsoporteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsoporteID_Enabled), 5, 0), true);
         edtsoporteID_Enabled = 0;
         AssignProp(sPrefix, false, edtsoporteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsoporteID_Enabled), 5, 0), true);
         if ( ! (0==AV8soporteID) )
         {
            A4soporteID = AV8soporteID;
            AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttEnter_Enabled = 0;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
         else
         {
            bttEnter_Enabled = 1;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A4soporteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A5hostName = T00024_A5hostName[0];
            AssignAttri(sPrefix, false, "A5hostName", A5hostName);
            A9serie = T00024_A9serie[0];
            AssignAttri(sPrefix, false, "A9serie", A9serie);
            A10ipv4 = T00024_A10ipv4[0];
            AssignAttri(sPrefix, false, "A10ipv4", A10ipv4);
            A11mac = T00024_A11mac[0];
            AssignAttri(sPrefix, false, "A11mac", A11mac);
            A12modelo = T00024_A12modelo[0];
            AssignAttri(sPrefix, false, "A12modelo", A12modelo);
            A13nombreUsuario = T00024_A13nombreUsuario[0];
            AssignAttri(sPrefix, false, "A13nombreUsuario", A13nombreUsuario);
            A14nombreDepartamento = T00024_A14nombreDepartamento[0];
            AssignAttri(sPrefix, false, "A14nombreDepartamento", A14nombreDepartamento);
            ZM022( -6) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV27Pgmname = "soporte";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV27Pgmname = "soporte";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A5hostName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required", "Name", "", "", "", "", "", "", "", ""), 1, "HOSTNAME");
            AnyError = 1;
            GX_FocusControl = edthostName_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A4soporteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A4soporteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 6) ;
            RcdFound2 = 1;
            A4soporteID = T00023_A4soporteID[0];
            AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
            A5hostName = T00023_A5hostName[0];
            AssignAttri(sPrefix, false, "A5hostName", A5hostName);
            A9serie = T00023_A9serie[0];
            AssignAttri(sPrefix, false, "A9serie", A9serie);
            A10ipv4 = T00023_A10ipv4[0];
            AssignAttri(sPrefix, false, "A10ipv4", A10ipv4);
            A11mac = T00023_A11mac[0];
            AssignAttri(sPrefix, false, "A11mac", A11mac);
            A12modelo = T00023_A12modelo[0];
            AssignAttri(sPrefix, false, "A12modelo", A12modelo);
            A13nombreUsuario = T00023_A13nombreUsuario[0];
            AssignAttri(sPrefix, false, "A13nombreUsuario", A13nombreUsuario);
            A14nombreDepartamento = T00023_A14nombreDepartamento[0];
            AssignAttri(sPrefix, false, "A14nombreDepartamento", A14nombreDepartamento);
            Z4soporteID = A4soporteID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A4soporteID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00026_A4soporteID[0] < A4soporteID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00026_A4soporteID[0] > A4soporteID ) ) )
            {
               A4soporteID = T00026_A4soporteID[0];
               AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A4soporteID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00027_A4soporteID[0] > A4soporteID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00027_A4soporteID[0] < A4soporteID ) ) )
            {
               A4soporteID = T00027_A4soporteID[0];
               AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edthostName_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4soporteID != Z4soporteID )
               {
                  A4soporteID = Z4soporteID;
                  AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SOPORTEID");
                  AnyError = 1;
                  GX_FocusControl = edtsoporteID_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edthostName_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edthostName_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4soporteID != Z4soporteID )
               {
                  /* Insert record */
                  GX_FocusControl = edthostName_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SOPORTEID");
                     AnyError = 1;
                     GX_FocusControl = edtsoporteID_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edthostName_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A4soporteID != Z4soporteID )
         {
            A4soporteID = Z4soporteID;
            AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SOPORTEID");
            AnyError = 1;
            GX_FocusControl = edtsoporteID_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edthostName_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A4soporteID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"soporte"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z5hostName, T00022_A5hostName[0]) != 0 ) || ( StringUtil.StrCmp(Z9serie, T00022_A9serie[0]) != 0 ) || ( StringUtil.StrCmp(Z10ipv4, T00022_A10ipv4[0]) != 0 ) || ( StringUtil.StrCmp(Z11mac, T00022_A11mac[0]) != 0 ) || ( StringUtil.StrCmp(Z12modelo, T00022_A12modelo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z13nombreUsuario, T00022_A13nombreUsuario[0]) != 0 ) || ( StringUtil.StrCmp(Z14nombreDepartamento, T00022_A14nombreDepartamento[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z5hostName, T00022_A5hostName[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"hostName");
                  GXUtil.WriteLogRaw("Old: ",Z5hostName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A5hostName[0]);
               }
               if ( StringUtil.StrCmp(Z9serie, T00022_A9serie[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"serie");
                  GXUtil.WriteLogRaw("Old: ",Z9serie);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9serie[0]);
               }
               if ( StringUtil.StrCmp(Z10ipv4, T00022_A10ipv4[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"ipv4");
                  GXUtil.WriteLogRaw("Old: ",Z10ipv4);
                  GXUtil.WriteLogRaw("Current: ",T00022_A10ipv4[0]);
               }
               if ( StringUtil.StrCmp(Z11mac, T00022_A11mac[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"mac");
                  GXUtil.WriteLogRaw("Old: ",Z11mac);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11mac[0]);
               }
               if ( StringUtil.StrCmp(Z12modelo, T00022_A12modelo[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"modelo");
                  GXUtil.WriteLogRaw("Old: ",Z12modelo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12modelo[0]);
               }
               if ( StringUtil.StrCmp(Z13nombreUsuario, T00022_A13nombreUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"nombreUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z13nombreUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13nombreUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z14nombreDepartamento, T00022_A14nombreDepartamento[0]) != 0 )
               {
                  GXUtil.WriteLog("soporte:[seudo value changed for attri]"+"nombreDepartamento");
                  GXUtil.WriteLogRaw("Old: ",Z14nombreDepartamento);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14nombreDepartamento[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"soporte"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         if ( ! IsAuthorized("soporte_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00028 */
                     pr_default.execute(6, new Object[] {A5hostName, A9serie, A10ipv4, A11mac, A12modelo, A13nombreUsuario, A14nombreDepartamento});
                     A4soporteID = T00028_A4soporteID[0];
                     AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("soporte");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         if ( ! IsAuthorized("soporte_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00029 */
                     pr_default.execute(7, new Object[] {A5hostName, A9serie, A10ipv4, A11mac, A12modelo, A13nombreUsuario, A14nombreDepartamento, A4soporteID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("soporte");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"soporte"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("soporte_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000210 */
                  pr_default.execute(8, new Object[] {A4soporteID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("soporte");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV27Pgmname = "soporte";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("soporte",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("soporte",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000211 */
         pr_default.execute(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A4soporteID = T000211_A4soporteID[0];
            AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A4soporteID = T000211_A4soporteID[0];
            AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtsoporteID_Enabled = 0;
         AssignProp(sPrefix, false, edtsoporteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtsoporteID_Enabled), 5, 0), true);
         edthostName_Enabled = 0;
         AssignProp(sPrefix, false, edthostName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edthostName_Enabled), 5, 0), true);
         edtserie_Enabled = 0;
         AssignProp(sPrefix, false, edtserie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtserie_Enabled), 5, 0), true);
         edtipv4_Enabled = 0;
         AssignProp(sPrefix, false, edtipv4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtipv4_Enabled), 5, 0), true);
         edtmac_Enabled = 0;
         AssignProp(sPrefix, false, edtmac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmac_Enabled), 5, 0), true);
         edtmodelo_Enabled = 0;
         AssignProp(sPrefix, false, edtmodelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmodelo_Enabled), 5, 0), true);
         edtnombreUsuario_Enabled = 0;
         AssignProp(sPrefix, false, edtnombreUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombreUsuario_Enabled), 5, 0), true);
         edtnombreDepartamento_Enabled = 0;
         AssignProp(sPrefix, false, edtnombreDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombreDepartamento_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
      {
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
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("soporte.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8soporteID,9,0))}, new string[] {"Gx_mode","soporteID"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"soporte");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("soporte:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z4soporteID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4soporteID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z5hostName", Z5hostName);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z9serie", Z9serie);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z10ipv4", Z10ipv4);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z11mac", Z11mac);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z12modelo", Z12modelo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z13nombreUsuario", Z13nombreUsuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z14nombreDepartamento", Z14nombreDepartamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8soporteID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8soporteID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV12Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV12Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV12Navigation, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEVENTARGS", AV9EventArgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEVENTARGS", AV9EventArgs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vSOPORTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8soporteID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm022( )
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
         return "soporte" ;
      }

      public override string GetPgmdesc( )
      {
         return "soporte" ;
      }

      protected void InitializeNonKey022( )
      {
         A5hostName = "";
         AssignAttri(sPrefix, false, "A5hostName", A5hostName);
         A9serie = "";
         AssignAttri(sPrefix, false, "A9serie", A9serie);
         A10ipv4 = "";
         AssignAttri(sPrefix, false, "A10ipv4", A10ipv4);
         A11mac = "";
         AssignAttri(sPrefix, false, "A11mac", A11mac);
         A12modelo = "";
         AssignAttri(sPrefix, false, "A12modelo", A12modelo);
         A13nombreUsuario = "";
         AssignAttri(sPrefix, false, "A13nombreUsuario", A13nombreUsuario);
         A14nombreDepartamento = "";
         AssignAttri(sPrefix, false, "A14nombreDepartamento", A14nombreDepartamento);
         Z5hostName = "";
         Z9serie = "";
         Z10ipv4 = "";
         Z11mac = "";
         Z12modelo = "";
         Z13nombreUsuario = "";
         Z14nombreDepartamento = "";
      }

      protected void InitAll022( )
      {
         A4soporteID = 0;
         AssignAttri(sPrefix, false, "A4soporteID", StringUtil.LTrimStr( (decimal)(A4soporteID), 9, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV8soporteID = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "soporte", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV8soporteID = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8soporteID", StringUtil.LTrimStr( (decimal)(AV8soporteID), 9, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8soporteID"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8soporteID != wcpOAV8soporteID ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8soporteID = AV8soporteID;
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
         sCtrlAV8soporteID = cgiGet( sPrefix+"AV8soporteID_CTRL");
         if ( StringUtil.Len( sCtrlAV8soporteID) > 0 )
         {
            AV8soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8soporteID), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8soporteID", StringUtil.LTrimStr( (decimal)(AV8soporteID), 9, 0));
         }
         else
         {
            AV8soporteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8soporteID_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
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
         UserMain( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8soporteID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8soporteID), 9, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8soporteID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8soporteID_CTRL", StringUtil.RTrim( sCtrlAV8soporteID));
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
            Draw( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243138144567", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("soporte.js", "?20243138144568", false, true);
         context.AddJavascriptSource("shared/K2BToolsCommon.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtsoporteID_Internalname = sPrefix+"SOPORTEID";
         divK2btoolstable_attributecontainersoporteid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSOPORTEID";
         edthostName_Internalname = sPrefix+"HOSTNAME";
         divK2btoolstable_attributecontainerhostname_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERHOSTNAME";
         edtserie_Internalname = sPrefix+"SERIE";
         divK2btoolstable_attributecontainerserie_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSERIE";
         edtipv4_Internalname = sPrefix+"IPV4";
         divK2btoolstable_attributecontaineripv4_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERIPV4";
         edtmac_Internalname = sPrefix+"MAC";
         divK2btoolstable_attributecontainermac_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERMAC";
         edtmodelo_Internalname = sPrefix+"MODELO";
         divK2btoolstable_attributecontainermodelo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERMODELO";
         edtnombreUsuario_Internalname = sPrefix+"NOMBREUSUARIO";
         divK2btoolstable_attributecontainernombreusuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBREUSUARIO";
         edtnombreDepartamento_Internalname = sPrefix+"NOMBREDEPARTAMENTO";
         divK2btoolstable_attributecontainernombredepartamento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBREDEPARTAMENTO";
         divTableattributesinformsection1_Internalname = sPrefix+"TABLEATTRIBUTESINFORMSECTION1";
         divK2btrnformmaintablecell_Internalname = sPrefix+"K2BTRNFORMMAINTABLECELL";
         divK2babstracttabledataareacontainer_Internalname = sPrefix+"K2BABSTRACTTABLEDATAAREACONTAINER";
         divK2besdataareacontainercell_Internalname = sPrefix+"K2BESDATAAREACONTAINERCELL";
         bttEnter_Internalname = sPrefix+"ENTER";
         bttCancel_Internalname = sPrefix+"CANCEL";
         divActionscontainerbuttons_Internalname = sPrefix+"ACTIONSCONTAINERBUTTONS";
         divK2besactioncontainercell_Internalname = sPrefix+"K2BESACTIONCONTAINERCELL";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divK2bescontrolbeaufitycell_Internalname = sPrefix+"K2BESCONTROLBEAUFITYCELL";
         divK2besmaintable_Internalname = sPrefix+"K2BESMAINTABLE";
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
         Form.Caption = "soporte";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirm";
         bttEnter_Caption = "Confirm";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtnombreDepartamento_Jsonclick = "";
         edtnombreDepartamento_Enabled = 1;
         edtnombreUsuario_Jsonclick = "";
         edtnombreUsuario_Enabled = 1;
         edtmodelo_Jsonclick = "";
         edtmodelo_Enabled = 1;
         edtmac_Jsonclick = "";
         edtmac_Enabled = 1;
         edtipv4_Jsonclick = "";
         edtipv4_Enabled = 1;
         edtserie_Jsonclick = "";
         edtserie_Enabled = 1;
         edthostName_Jsonclick = "";
         edthostName_Class = "Attribute_Trn Attribute_Required";
         edthostName_Enabled = 1;
         edtsoporteID_Jsonclick = "";
         edtsoporteID_Enabled = 0;
         divK2babstracttabledataareacontainer_Class = "Table_DataAreaContainer Table_TransactionDataAreaContainer K2BT_NGA";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8soporteID',fld:'vSOPORTEID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A4soporteID',fld:'SOPORTEID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A5hostName',fld:'HOSTNAME',pic:''},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:''},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9EventArgs',fld:'vEVENTARGS',pic:''},{av:'AV27Pgmname',fld:'vPGMNAME',pic:''},{av:'AV8soporteID',fld:'vSOPORTEID',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:''},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A4soporteID',fld:'SOPORTEID',pic:'ZZZZZZZZ9'},{av:'AV9EventArgs',fld:'vEVENTARGS',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13022',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV8soporteID',fld:'vSOPORTEID',pic:'ZZZZZZZZ9'},{av:'AV9EventArgs',fld:'vEVENTARGS',pic:''},{av:'AV27Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:''},{av:'AV9EventArgs',fld:'vEVENTARGS',pic:''}]}");
         setEventMetadata("VALID_SOPORTEID","{handler:'Valid_Soporteid',iparms:[]");
         setEventMetadata("VALID_SOPORTEID",",oparms:[]}");
         setEventMetadata("VALID_HOSTNAME","{handler:'Valid_Hostname',iparms:[]");
         setEventMetadata("VALID_HOSTNAME",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z5hostName = "";
         Z9serie = "";
         Z10ipv4 = "";
         Z11mac = "";
         Z12modelo = "";
         Z13nombreUsuario = "";
         Z14nombreDepartamento = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         A5hostName = "";
         TempTags = "";
         A9serie = "";
         A10ipv4 = "";
         A11mac = "";
         A12modelo = "";
         A13nombreUsuario = "";
         A14nombreDepartamento = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV27Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV14Context = new SdtK2BContext(context);
         AV19StandardActivityType = "";
         AV20UserActivityType = "";
         AV28GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV26ActivityLogProperty = new SdtK2BAttributeValue_Item(context);
         AV15BtnCaption = "";
         AV16BtnTooltip = "";
         AV10TrnContext = new SdtK2BTrnContext(context);
         AV7HttpRequest = new GxHttpRequest( context);
         AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12Navigation = new SdtK2BTrnNavigation(context);
         AV9EventArgs = new GeneXus.Programs.k2btools.transactionutils.SdtTransactionEventArgs(context);
         AV18encrypt = "";
         GXt_char2 = "";
         AV13DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV17Url = "";
         T00024_A4soporteID = new int[1] ;
         T00024_A5hostName = new string[] {""} ;
         T00024_A9serie = new string[] {""} ;
         T00024_A10ipv4 = new string[] {""} ;
         T00024_A11mac = new string[] {""} ;
         T00024_A12modelo = new string[] {""} ;
         T00024_A13nombreUsuario = new string[] {""} ;
         T00024_A14nombreDepartamento = new string[] {""} ;
         T00025_A4soporteID = new int[1] ;
         T00023_A4soporteID = new int[1] ;
         T00023_A5hostName = new string[] {""} ;
         T00023_A9serie = new string[] {""} ;
         T00023_A10ipv4 = new string[] {""} ;
         T00023_A11mac = new string[] {""} ;
         T00023_A12modelo = new string[] {""} ;
         T00023_A13nombreUsuario = new string[] {""} ;
         T00023_A14nombreDepartamento = new string[] {""} ;
         T00026_A4soporteID = new int[1] ;
         T00027_A4soporteID = new int[1] ;
         T00022_A4soporteID = new int[1] ;
         T00022_A5hostName = new string[] {""} ;
         T00022_A9serie = new string[] {""} ;
         T00022_A10ipv4 = new string[] {""} ;
         T00022_A11mac = new string[] {""} ;
         T00022_A12modelo = new string[] {""} ;
         T00022_A13nombreUsuario = new string[] {""} ;
         T00022_A14nombreDepartamento = new string[] {""} ;
         T00028_A4soporteID = new int[1] ;
         T000211_A4soporteID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV8soporteID = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.soporte__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.soporte__default(),
            new Object[][] {
                new Object[] {
               T00022_A4soporteID, T00022_A5hostName, T00022_A9serie, T00022_A10ipv4, T00022_A11mac, T00022_A12modelo, T00022_A13nombreUsuario, T00022_A14nombreDepartamento
               }
               , new Object[] {
               T00023_A4soporteID, T00023_A5hostName, T00023_A9serie, T00023_A10ipv4, T00023_A11mac, T00023_A12modelo, T00023_A13nombreUsuario, T00023_A14nombreDepartamento
               }
               , new Object[] {
               T00024_A4soporteID, T00024_A5hostName, T00024_A9serie, T00024_A10ipv4, T00024_A11mac, T00024_A12modelo, T00024_A13nombreUsuario, T00024_A14nombreDepartamento
               }
               , new Object[] {
               T00025_A4soporteID
               }
               , new Object[] {
               T00026_A4soporteID
               }
               , new Object[] {
               T00027_A4soporteID
               }
               , new Object[] {
               T00028_A4soporteID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000211_A4soporteID
               }
            }
         );
         AV27Pgmname = "soporte";
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short nIsDirty_2 ;
      private short Gx_BScreen ;
      private int wcpOAV8soporteID ;
      private int Z4soporteID ;
      private int AV8soporteID ;
      private int trnEnded ;
      private int A4soporteID ;
      private int edtsoporteID_Enabled ;
      private int edthostName_Enabled ;
      private int edtserie_Enabled ;
      private int edtipv4_Enabled ;
      private int edtmac_Enabled ;
      private int edtmodelo_Enabled ;
      private int edtnombreUsuario_Enabled ;
      private int edtnombreDepartamento_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV29GXV2 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edthostName_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2babstracttabledataareacontainer_Class ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainersoporteid_Internalname ;
      private string edtsoporteID_Internalname ;
      private string edtsoporteID_Jsonclick ;
      private string divK2btoolstable_attributecontainerhostname_Internalname ;
      private string TempTags ;
      private string edthostName_Jsonclick ;
      private string edthostName_Class ;
      private string divK2btoolstable_attributecontainerserie_Internalname ;
      private string edtserie_Internalname ;
      private string edtserie_Jsonclick ;
      private string divK2btoolstable_attributecontaineripv4_Internalname ;
      private string edtipv4_Internalname ;
      private string edtipv4_Jsonclick ;
      private string divK2btoolstable_attributecontainermac_Internalname ;
      private string edtmac_Internalname ;
      private string edtmac_Jsonclick ;
      private string divK2btoolstable_attributecontainermodelo_Internalname ;
      private string edtmodelo_Internalname ;
      private string edtmodelo_Jsonclick ;
      private string divK2btoolstable_attributecontainernombreusuario_Internalname ;
      private string edtnombreUsuario_Internalname ;
      private string edtnombreUsuario_Jsonclick ;
      private string divK2btoolstable_attributecontainernombredepartamento_Internalname ;
      private string edtnombreDepartamento_Internalname ;
      private string edtnombreDepartamento_Jsonclick ;
      private string divK2besactioncontainercell_Internalname ;
      private string divActionscontainerbuttons_Internalname ;
      private string bttEnter_Internalname ;
      private string bttEnter_Caption ;
      private string bttEnter_Jsonclick ;
      private string bttEnter_Tooltiptext ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divK2bescontrolbeaufitycell_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string AV27Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19StandardActivityType ;
      private string AV15BtnCaption ;
      private string AV16BtnTooltip ;
      private string AV18encrypt ;
      private string GXt_char2 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV8soporteID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV21IsAuthorized ;
      private bool Gx_longc ;
      private string Z5hostName ;
      private string Z9serie ;
      private string Z10ipv4 ;
      private string Z11mac ;
      private string Z12modelo ;
      private string Z13nombreUsuario ;
      private string Z14nombreDepartamento ;
      private string A5hostName ;
      private string A9serie ;
      private string A10ipv4 ;
      private string A11mac ;
      private string A12modelo ;
      private string A13nombreUsuario ;
      private string A14nombreDepartamento ;
      private string AV20UserActivityType ;
      private string AV13DinamicObjToLink ;
      private string AV17Url ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private int[] T00024_A4soporteID ;
      private string[] T00024_A5hostName ;
      private string[] T00024_A9serie ;
      private string[] T00024_A10ipv4 ;
      private string[] T00024_A11mac ;
      private string[] T00024_A12modelo ;
      private string[] T00024_A13nombreUsuario ;
      private string[] T00024_A14nombreDepartamento ;
      private int[] T00025_A4soporteID ;
      private int[] T00023_A4soporteID ;
      private string[] T00023_A5hostName ;
      private string[] T00023_A9serie ;
      private string[] T00023_A10ipv4 ;
      private string[] T00023_A11mac ;
      private string[] T00023_A12modelo ;
      private string[] T00023_A13nombreUsuario ;
      private string[] T00023_A14nombreDepartamento ;
      private int[] T00026_A4soporteID ;
      private int[] T00027_A4soporteID ;
      private int[] T00022_A4soporteID ;
      private string[] T00022_A5hostName ;
      private string[] T00022_A9serie ;
      private string[] T00022_A10ipv4 ;
      private string[] T00022_A11mac ;
      private string[] T00022_A12modelo ;
      private string[] T00022_A13nombreUsuario ;
      private string[] T00022_A14nombreDepartamento ;
      private int[] T00028_A4soporteID ;
      private int[] T000211_A4soporteID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV7HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV28GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV22AttributeValue ;
      private GeneXus.Programs.k2btools.transactionutils.SdtTransactionEventArgs AV9EventArgs ;
      private SdtK2BAttributeValue_Item AV26ActivityLogProperty ;
      private SdtK2BAttributeValue_Item AV23AttributeValueItem ;
      private SdtK2BTrnContext AV10TrnContext ;
      private SdtK2BTrnNavigation AV12Navigation ;
      private SdtK2BContext AV14Context ;
      private GeneXus.Utils.SdtMessages_Message AV24Message ;
   }

   public class soporte__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class soporte__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@hostName",GXType.NVarChar,40,0) ,
        new ParDef("@serie",GXType.NVarChar,40,0) ,
        new ParDef("@ipv4",GXType.NVarChar,40,0) ,
        new ParDef("@mac",GXType.NVarChar,40,0) ,
        new ParDef("@modelo",GXType.NVarChar,40,0) ,
        new ParDef("@nombreUsuario",GXType.NVarChar,40,0) ,
        new ParDef("@nombreDepartamento",GXType.NVarChar,40,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("@hostName",GXType.NVarChar,40,0) ,
        new ParDef("@serie",GXType.NVarChar,40,0) ,
        new ParDef("@ipv4",GXType.NVarChar,40,0) ,
        new ParDef("@mac",GXType.NVarChar,40,0) ,
        new ParDef("@modelo",GXType.NVarChar,40,0) ,
        new ParDef("@nombreUsuario",GXType.NVarChar,40,0) ,
        new ParDef("@nombreDepartamento",GXType.NVarChar,40,0) ,
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("@soporteID",GXType.Int32,9,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT [soporteID], [hostName], [serie], [ipv4], [mac], [modelo], [nombreUsuario], [nombreDepartamento] FROM [soporte] WITH (UPDLOCK) WHERE [soporteID] = @soporteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT [soporteID], [hostName], [serie], [ipv4], [mac], [modelo], [nombreUsuario], [nombreDepartamento] FROM [soporte] WHERE [soporteID] = @soporteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT TM1.[soporteID], TM1.[hostName], TM1.[serie], TM1.[ipv4], TM1.[mac], TM1.[modelo], TM1.[nombreUsuario], TM1.[nombreDepartamento] FROM [soporte] TM1 WHERE TM1.[soporteID] = @soporteID ORDER BY TM1.[soporteID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT [soporteID] FROM [soporte] WHERE [soporteID] = @soporteID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT TOP 1 [soporteID] FROM [soporte] WHERE ( [soporteID] > @soporteID) ORDER BY [soporteID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00027", "SELECT TOP 1 [soporteID] FROM [soporte] WHERE ( [soporteID] < @soporteID) ORDER BY [soporteID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00028", "INSERT INTO [soporte]([hostName], [serie], [ipv4], [mac], [modelo], [nombreUsuario], [nombreDepartamento]) VALUES(@hostName, @serie, @ipv4, @mac, @modelo, @nombreUsuario, @nombreDepartamento); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00029", "UPDATE [soporte] SET [hostName]=@hostName, [serie]=@serie, [ipv4]=@ipv4, [mac]=@mac, [modelo]=@modelo, [nombreUsuario]=@nombreUsuario, [nombreDepartamento]=@nombreDepartamento  WHERE [soporteID] = @soporteID", GxErrorMask.GX_NOMASK,prmT00029)
           ,new CursorDef("T000210", "DELETE FROM [soporte]  WHERE [soporteID] = @soporteID", GxErrorMask.GX_NOMASK,prmT000210)
           ,new CursorDef("T000211", "SELECT [soporteID] FROM [soporte] ORDER BY [soporteID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
