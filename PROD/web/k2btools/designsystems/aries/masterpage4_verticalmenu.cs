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
namespace GeneXus.Programs.k2btools.designsystems.aries {
   public class masterpage4_verticalmenu : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public masterpage4_verticalmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpage4_verticalmenu( IGxContext context )
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu";
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0X2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME_MPAGE", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV17Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vMENUITEMS_MPAGE", AV6MenuItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENUITEMS_MPAGE", AV6MenuItems);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME_MPAGE", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV17Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "K2BACCORDIONMENU_MPAGE_Includesearch", StringUtil.BoolToStr( K2baccordionmenu_Includesearch));
         GxWebStd.gx_hidden_field( context, "MAINTABLE_MPAGE_Class", StringUtil.RTrim( divMaintable_Class));
         GxWebStd.gx_hidden_field( context, "MYACCOUNTMENU_MPAGE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divMyaccountmenu_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentjscripts();
         }
         if ( ! ( WebComp_Uiconfiguration == null ) )
         {
            WebComp_Uiconfiguration.componentjscripts();
         }
         if ( ! ( WebComp_Footercomponent == null ) )
         {
            WebComp_Footercomponent.componentjscripts();
         }
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         context.AddJavascriptSource("k2btools/designsystems/aries/masterpage4_verticalmenu.js", "?20243138153686", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu" ;
      }

      public override string GetPgmdesc( )
      {
         return "Left collapsible vertical menu 4" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", divMaintable_Class, "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeader_Internalname, 1, 0, "px", 0, "px", "K2BHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',true,'',0)\"";
            ClassString = "K2BT_MenuToggleButton" + " " + ((StringUtil.StrCmp(imgMenutoggle_gximage, "")==0) ? "GX_Image_K2BT_MenuToggleButton_Class" : "GX_Image_"+imgMenutoggle_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "eadc98ac-fdd5-4cc3-8138-e3bb49dd5ff2", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMenutoggle_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgMenutoggle_Jsonclick, "'"+""+"'"+",true,"+"'"+"e110x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',true,'',0)\"";
            ClassString = "Image_HeaderLogo" + " " + ((StringUtil.StrCmp(imgApplicationicon_gximage, "")==0) ? "GX_Image_K2BLogotipo_Class" : "GX_Image_"+imgApplicationicon_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "bb4462ea-0eb3-44b4-8320-f971481f81b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgApplicationicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgApplicationicon_Jsonclick, "'"+""+"'"+",true,"+"'"+"e120x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApplicationname_Internalname, "Application name", "", "", lblApplicationname_Jsonclick, "'"+""+"'"+",true,"+"'"+"e130x1_client"+"'", "", "K2BT_ApplicationName", 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopmiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaEnd", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopend_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderArea", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUniversalsearch_Internalname, divUniversalsearch_Visible, 0, "px", 0, "px", "K2BToolsTable_SearchContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearchcriteria_Internalname, "Search Criteria", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',true,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearchcriteria_Internalname, StringUtil.RTrim( AV9SearchCriteria), StringUtil.RTrim( context.localUtil.Format( AV9SearchCriteria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "Search", edtavSearchcriteria_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavSearchcriteria_Enabled, 0, "text", "", 26, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "K2BSearchCriteria", "start", true, "", "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',true,'',0)\"";
            ClassString = "K2BToolsButton_Search" + " " + ((StringUtil.StrCmp(imgImage2_gximage, "")==0) ? "GX_Image_K2BUniversalSearch_Class" : "GX_Image_"+imgImage2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "b2f44a32-cd24-4170-a5da-849c2e18a0bd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage2_Jsonclick, "'"+""+"'"+",true,"+"'"+"e140x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0027"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0027"+"");
               }
               WebComp_Notificationscomponent.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0029"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0029"+"");
               }
               WebComp_Uiconfiguration.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMyaccount_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_MyAccountHeader", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinitialstextblocksmall_Internalname, lblUserinitialstextblocksmall_Caption, "", "", lblUserinitialstextblocksmall_Jsonclick, "'"+""+"'"+",true,"+"'"+"e150x1_client"+"'", "", "K2BToolsTextblock_InitialsCircleSmall", 7, "", lblUserinitialstextblocksmall_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "User Avatar Small", "gx-form-item K2BToolsImage_RoundPhotoSmallLabel", 0, true, "width: 25%;");
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',true,'',0)\"";
            ClassString = "K2BToolsImage_RoundPhotoSmall" + " " + ((StringUtil.StrCmp(imgavUseravatarsmall_gximage, "")==0) ? "" : "GX_Image_"+imgavUseravatarsmall_gximage+"_Class");
            StyleString = "";
            AV12UserAvatarSmall_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12UserAvatarSmall))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Useravatarsmall_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12UserAvatarSmall)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12UserAvatarSmall)) ? AV18Useravatarsmall_GXI : context.PathToRelativeUrl( AV12UserAvatarSmall));
            GxWebStd.gx_bitmap( context, imgavUseravatarsmall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavUseravatarsmall_Visible, 1, "", "", 0, -1, 0, "", 0, "", 0, 0, 7, imgavUseravatarsmall_Jsonclick, "'"+""+"'"+",true,"+"'"+"e150x1_client"+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, AV12UserAvatarSmall_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsernametextblock_Internalname, lblUsernametextblock_Caption, "", "", lblUsernametextblock_Jsonclick, "'"+""+"'"+",true,"+"'"+"e150x1_client"+"'", "", "K2BToolsTextBlock_MyAccount", 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMyaccountmenu_Internalname, divMyaccountmenu_Visible, 0, "px", 0, "px", "K2BToolsMyAccountTable", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "K2BT_UserInfoSection", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "User Avatar", "gx-form-item K2BToolsImage_RoundPhotoLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "K2BToolsImage_RoundPhoto" + " " + ((StringUtil.StrCmp(imgavUseravatar_gximage, "")==0) ? "" : "GX_Image_"+imgavUseravatar_gximage+"_Class");
            StyleString = "";
            AV11UserAvatar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV11UserAvatar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Useravatar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV11UserAvatar)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV11UserAvatar)) ? AV19Useravatar_GXI : context.PathToRelativeUrl( AV11UserAvatar));
            GxWebStd.gx_bitmap( context, imgavUseravatar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavUseravatar_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV11UserAvatar_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinitialstextblock_Internalname, lblUserinitialstextblock_Caption, "", "", lblUserinitialstextblock_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_InitialsCircle", 0, "", lblUserinitialstextblock_Visible, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsername_Internalname, lblUsername_Caption, "", "", lblUsername_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_UserName", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseremail_Internalname, lblUseremail_Caption, "", "", lblUseremail_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_UserEmail", 0, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblChangepassword_Internalname, "Change Password", "", "", lblChangepassword_Jsonclick, "'"+""+"'"+",true,"+"'"+"e160x1_client"+"'", "", "K2BToolsTextBlock_ChangePassword", 7, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignout_Internalname, "Sign out", "", "", lblSignout_Jsonclick, "'"+""+"'"+",true,"+"'"+"ESIGNOUT_MPAGE."+"'", "", "K2BToolsTextBlock_Logout", 5, "", 1, 1, 0, 0, "HLP_K2BTools\\DesignSystems\\Aries\\MasterPage4_VerticalMenu.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenucell_Internalname, 1, 0, "px", 0, "px", "K2BT_AreaStart", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCenterstart_Internalname, 1, 0, "px", 0, "px", "K2BT_FixedMenu", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenucontainer_Internalname, 1, 0, "px", 0, "px", "K2BToolsMenuContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucK2baccordionmenu.SetProperty("IncludeSearch", K2baccordionmenu_Includesearch);
            ucK2baccordionmenu.SetProperty("MenuItems", AV6MenuItems);
            ucK2baccordionmenu.Render(context, "k2baccordionmenu", K2baccordionmenu_Internalname, "K2BACCORDIONMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_MasterPageContentContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCentermiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFootercontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_MasterPage2FooterContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFootercontents_Internalname, 1, 0, "px", 0, "px", "K2BT_MasterPage2FooterContents", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0068"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0068"+"");
               }
               WebComp_Footercomponent.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E170X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E180X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SIGNOUT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'SignOut' */
                           E190X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E200X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 27 )
                     {
                        WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
                        WebComp_Notificationscomponent.ComponentInit();
                        WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                        WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                        WebComp_Notificationscomponent.componentprocess("MPW0027", "", sEvt);
                     }
                     else if ( nCmpId == 29 )
                     {
                        WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
                        WebComp_Uiconfiguration.ComponentInit();
                        WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
                        WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
                        WebComp_Uiconfiguration.componentprocess("MPW0029", "", sEvt);
                     }
                     else if ( nCmpId == 68 )
                     {
                        WebComp_Footercomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.samplefootercomponent", new Object[] {context} );
                        WebComp_Footercomponent.ComponentInit();
                        WebComp_Footercomponent.Name = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
                        WebComp_Footercomponent_Component = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
                        WebComp_Footercomponent.componentprocess("MPW0068", "", sEvt);
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
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
               GX_FocusControl = edtavSearchcriteria_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu";
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E180X2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
               {
                  WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
                  WebComp_Notificationscomponent.ComponentInit();
                  WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                  WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
               }
               WebComp_Notificationscomponent.setjustcreated();
               WebComp_Notificationscomponent.componentprepare(new Object[] {(string)"MPW0027",(string)""});
               WebComp_Notificationscomponent.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Notificationscomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0027"+"");
                  WebComp_Notificationscomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Notificationscomponent.componentstart();
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Uiconfiguration_Component, "") == 0 )
               {
                  WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
                  WebComp_Uiconfiguration.ComponentInit();
                  WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
                  WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
               }
               WebComp_Uiconfiguration.setjustcreated();
               WebComp_Uiconfiguration.componentprepare(new Object[] {(string)"MPW0029",(string)""});
               WebComp_Uiconfiguration.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Uiconfiguration )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0029"+"");
                  WebComp_Uiconfiguration.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Uiconfiguration.componentstart();
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Footercomponent_Component, "") == 0 )
               {
                  WebComp_Footercomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.samplefootercomponent", new Object[] {context} );
                  WebComp_Footercomponent.ComponentInit();
                  WebComp_Footercomponent.Name = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
                  WebComp_Footercomponent_Component = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
               }
               WebComp_Footercomponent.setjustcreated();
               WebComp_Footercomponent.componentprepare(new Object[] {(string)"MPW0068",(string)""});
               WebComp_Footercomponent.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Footercomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0068"+"");
                  WebComp_Footercomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Footercomponent.componentstart();
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E200X2 ();
            WB0X0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E170X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMENUITEMS_MPAGE"), AV6MenuItems);
            /* Read saved values. */
            K2baccordionmenu_Includesearch = StringUtil.StrToBool( cgiGet( "K2BACCORDIONMENU_MPAGE_Includesearch"));
            /* Read variables values. */
            AV9SearchCriteria = cgiGet( edtavSearchcriteria_Internalname);
            AssignAttri("", true, "AV9SearchCriteria", AV9SearchCriteria);
            AV12UserAvatarSmall = cgiGet( imgavUseravatarsmall_Internalname);
            AV11UserAvatar = cgiGet( imgavUseravatar_Internalname);
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
         E170X2 ();
         if (returnInSub) return;
      }

      protected void E170X2( )
      {
         /* Start Routine */
         returnInSub = false;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("viewport", "width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("apple-mobile-web-app-capable", "yes", 0) ;
         AV16GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV15GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV15GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV16GXV2 <= AV15GXV1.Count )
         {
            AV5DesignSystemOption = ((SdtK2BAttributeValue_Item)AV15GXV1.Item(AV16GXV2));
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {AV5DesignSystemOption.gxTpr_Attributename,AV5DesignSystemOption.gxTpr_Attributevalue}, false);
            AV16GXV2 = (int)(AV16GXV2+1);
         }
         divMyaccountmenu_Visible = 0;
         AssignProp("", true, divMyaccountmenu_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divMyaccountmenu_Visible), 5, 0), true);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = AV6MenuItems;
         new k2bgetusermenu(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2) ;
         AV6MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2;
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem3 = AV8SearchableTransactions;
         new k2bgetsearchableentities(context ).execute( out  GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem3) ;
         AV8SearchableTransactions = GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem3;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "",  "",  "None",  "K2BToolsSearchResult",  AV17Pgmname) && ( AV8SearchableTransactions.Count > 0 ) )
         {
            GXt_char4 = AV10SearchCriteriaSession;
            new k2bsessionget(context ).execute(  AV17Pgmname+"-SearchCriteria", out  GXt_char4) ;
            AV10SearchCriteriaSession = GXt_char4;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10SearchCriteriaSession)) )
            {
               AV9SearchCriteria = AV10SearchCriteriaSession;
               AssignAttri("", true, "AV9SearchCriteria", AV9SearchCriteria);
            }
         }
         else
         {
            divUniversalsearch_Visible = 0;
            AssignProp("", true, divUniversalsearch_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUniversalsearch_Visible), 5, 0), true);
         }
         GXt_char4 = AV13UserCaption;
         new k2bgetusercaption(context ).execute( out  GXt_char4) ;
         AV13UserCaption = GXt_char4;
         GXt_char4 = AV11UserAvatar;
         new k2bgetuseravatar(context ).execute( out  GXt_char4) ;
         AV11UserAvatar = GXt_char4;
         AssignProp("", true, imgavUseravatar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV11UserAvatar)) ? AV19Useravatar_GXI : context.convertURL( context.PathToRelativeUrl( AV11UserAvatar))), true);
         AssignProp("", true, imgavUseravatar_Internalname, "SrcSet", context.GetImageSrcSet( AV11UserAvatar), true);
         AV12UserAvatarSmall = AV11UserAvatar;
         AssignProp("", true, imgavUseravatarsmall_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12UserAvatarSmall)) ? AV18Useravatarsmall_GXI : context.convertURL( context.PathToRelativeUrl( AV12UserAvatarSmall))), true);
         AssignProp("", true, imgavUseravatarsmall_Internalname, "SrcSet", context.GetImageSrcSet( AV12UserAvatarSmall), true);
         AV18Useravatarsmall_GXI = AV19Useravatar_GXI;
         AssignProp("", true, imgavUseravatarsmall_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12UserAvatarSmall)) ? AV18Useravatarsmall_GXI : context.convertURL( context.PathToRelativeUrl( AV12UserAvatarSmall))), true);
         AssignProp("", true, imgavUseravatarsmall_Internalname, "SrcSet", context.GetImageSrcSet( AV12UserAvatarSmall), true);
         GXt_char4 = "";
         new k2bgetuseremail(context ).execute( out  GXt_char4) ;
         lblUseremail_Caption = GXt_char4;
         AssignProp("", true, lblUseremail_Internalname, "Caption", lblUseremail_Caption, true);
         lblUsername_Caption = AV13UserCaption;
         AssignProp("", true, lblUsername_Internalname, "Caption", lblUsername_Caption, true);
         lblUsernametextblock_Caption = AV13UserCaption;
         AssignProp("", true, lblUsernametextblock_Internalname, "Caption", lblUsernametextblock_Caption, true);
         lblUserinitialstextblock_Caption = "";
         AssignProp("", true, lblUserinitialstextblock_Internalname, "Caption", lblUserinitialstextblock_Caption, true);
         lblUserinitialstextblocksmall_Caption = "";
         AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Caption", lblUserinitialstextblocksmall_Caption, true);
         AV21GXV4 = 1;
         AV20GXV3 = GxRegex.Split(AV13UserCaption," ");
         while ( AV21GXV4 <= AV20GXV3.Count )
         {
            AV7Name = AV20GXV3.GetString(AV21GXV4);
            lblUserinitialstextblock_Caption = lblUserinitialstextblock_Caption+StringUtil.Upper( StringUtil.Substring( AV7Name, 1, 1));
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Caption", lblUserinitialstextblock_Caption, true);
            lblUserinitialstextblocksmall_Caption = lblUserinitialstextblocksmall_Caption+StringUtil.Upper( StringUtil.Substring( AV7Name, 1, 1));
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Caption", lblUserinitialstextblocksmall_Caption, true);
            if ( StringUtil.Len( lblUserinitialstextblock_Caption) == 2 )
            {
               if (true) break;
            }
            AV21GXV4 = (int)(AV21GXV4+1);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11UserAvatar)) && String.IsNullOrEmpty(StringUtil.RTrim( AV19Useravatar_GXI)) )
         {
            lblUserinitialstextblock_Visible = 1;
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblock_Visible), 5, 0), true);
            lblUserinitialstextblocksmall_Visible = 1;
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblocksmall_Visible), 5, 0), true);
            imgavUseravatar_Visible = 0;
            AssignProp("", true, imgavUseravatar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatar_Visible), 5, 0), true);
            imgavUseravatarsmall_Visible = 0;
            AssignProp("", true, imgavUseravatarsmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatarsmall_Visible), 5, 0), true);
         }
         else
         {
            lblUserinitialstextblock_Visible = 0;
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblock_Visible), 5, 0), true);
            lblUserinitialstextblocksmall_Visible = 0;
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblocksmall_Visible), 5, 0), true);
            imgavUseravatar_Visible = 1;
            AssignProp("", true, imgavUseravatar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatar_Visible), 5, 0), true);
            imgavUseravatarsmall_Visible = 1;
            AssignProp("", true, imgavUseravatarsmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatarsmall_Visible), 5, 0), true);
         }
      }

      protected void E180X2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new k2bisauthenticated(context).executeUdp( ) )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("None")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         GXt_char4 = AV10SearchCriteriaSession;
         new k2bsessionget(context ).execute(  AV17Pgmname+"-SearchCriteria", out  GXt_char4) ;
         AV10SearchCriteriaSession = GXt_char4;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10SearchCriteriaSession)) )
         {
            AV9SearchCriteria = AV10SearchCriteriaSession;
            AssignAttri("", true, "AV9SearchCriteria", AV9SearchCriteria);
         }
         /*  Sending Event outputs  */
      }

      protected void E190X2( )
      {
         /* 'SignOut' Routine */
         returnInSub = false;
         new k2blogoutimplementation(context ).execute( ) ;
      }

      protected void nextLoad( )
      {
      }

      protected void E200X2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("shared/fontawesome-free-5.1.1-web/css/all.css", "");
         AddStyleSheetFile("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/metisFolder.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/defaultTheme.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
         {
            WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
            WebComp_Notificationscomponent.ComponentInit();
            WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
            WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Uiconfiguration_Component, "") == 0 )
         {
            WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
            WebComp_Uiconfiguration.ComponentInit();
            WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
            WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
         }
         if ( ! ( WebComp_Uiconfiguration == null ) )
         {
            WebComp_Uiconfiguration.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Footercomponent_Component, "") == 0 )
         {
            WebComp_Footercomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.samplefootercomponent", new Object[] {context} );
            WebComp_Footercomponent.ComponentInit();
            WebComp_Footercomponent.Name = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
            WebComp_Footercomponent_Component = "K2BTools.DesignSystems.Aries.SampleFooterComponent";
         }
         if ( ! ( WebComp_Footercomponent == null ) )
         {
            WebComp_Footercomponent.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20243138153744", true, true);
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
         context.AddJavascriptSource("k2btools/designsystems/aries/masterpage4_verticalmenu.js", "?20243138153745", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgMenutoggle_Internalname = "MENUTOGGLE_MPAGE";
         imgApplicationicon_Internalname = "APPLICATIONICON_MPAGE";
         lblApplicationname_Internalname = "APPLICATIONNAME_MPAGE";
         divTable3_Internalname = "TABLE3_MPAGE";
         divTopmiddle_Internalname = "TOPMIDDLE_MPAGE";
         edtavSearchcriteria_Internalname = "vSEARCHCRITERIA_MPAGE";
         imgImage2_Internalname = "IMAGE2_MPAGE";
         divUniversalsearch_Internalname = "UNIVERSALSEARCH_MPAGE";
         lblUserinitialstextblocksmall_Internalname = "USERINITIALSTEXTBLOCKSMALL_MPAGE";
         imgavUseravatarsmall_Internalname = "vUSERAVATARSMALL_MPAGE";
         lblUsernametextblock_Internalname = "USERNAMETEXTBLOCK_MPAGE";
         divMyaccount_Internalname = "MYACCOUNT_MPAGE";
         imgavUseravatar_Internalname = "vUSERAVATAR_MPAGE";
         lblUserinitialstextblock_Internalname = "USERINITIALSTEXTBLOCK_MPAGE";
         lblUsername_Internalname = "USERNAME_MPAGE";
         lblUseremail_Internalname = "USEREMAIL_MPAGE";
         divSection1_Internalname = "SECTION1_MPAGE";
         lblChangepassword_Internalname = "CHANGEPASSWORD_MPAGE";
         lblSignout_Internalname = "SIGNOUT_MPAGE";
         divMyaccountmenu_Internalname = "MYACCOUNTMENU_MPAGE";
         divTable4_Internalname = "TABLE4_MPAGE";
         divTopend_Internalname = "TOPEND_MPAGE";
         divHeader_Internalname = "HEADER_MPAGE";
         K2baccordionmenu_Internalname = "K2BACCORDIONMENU_MPAGE";
         divMenucontainer_Internalname = "MENUCONTAINER_MPAGE";
         divCenterstart_Internalname = "CENTERSTART_MPAGE";
         divMenucell_Internalname = "MENUCELL_MPAGE";
         divTable2_Internalname = "TABLE2_MPAGE";
         divCentermiddle_Internalname = "CENTERMIDDLE_MPAGE";
         divMiddle_Internalname = "MIDDLE_MPAGE";
         divTable1_Internalname = "TABLE1_MPAGE";
         divFootercontents_Internalname = "FOOTERCONTENTS_MPAGE";
         divFootercontainer_Internalname = "FOOTERCONTAINER_MPAGE";
         divSection2_Internalname = "SECTION2_MPAGE";
         divMaintable_Internalname = "MAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblUseremail_Caption = "test@test.com";
         lblUsername_Caption = "User Name";
         lblUserinitialstextblock_Caption = "Initials";
         lblUserinitialstextblock_Visible = 1;
         imgavUseravatar_gximage = "";
         imgavUseravatar_Visible = 1;
         divMyaccountmenu_Visible = 1;
         lblUsernametextblock_Caption = "John Doe";
         imgavUseravatarsmall_Jsonclick = "";
         imgavUseravatarsmall_gximage = "";
         imgavUseravatarsmall_Visible = 1;
         lblUserinitialstextblocksmall_Caption = "Initials";
         lblUserinitialstextblocksmall_Visible = 1;
         edtavSearchcriteria_Jsonclick = "";
         edtavSearchcriteria_Enabled = 1;
         divUniversalsearch_Visible = 1;
         divMaintable_Class = "MasterPage4";
         K2baccordionmenu_Includesearch = Convert.ToBoolean( 0);
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[{av:'AV17Pgmname',fld:'vPGMNAME_MPAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[{av:'AV9SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]}");
         setEventMetadata("DOSEARCH_MPAGE","{handler:'E140X1',iparms:[{av:'AV9SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]");
         setEventMetadata("DOSEARCH_MPAGE",",oparms:[{av:'AV9SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]}");
         setEventMetadata("TOGGLEMENU_MPAGE","{handler:'E110X1',iparms:[{av:'divMaintable_Class',ctrl:'MAINTABLE_MPAGE',prop:'Class'}]");
         setEventMetadata("TOGGLEMENU_MPAGE",",oparms:[{av:'divMaintable_Class',ctrl:'MAINTABLE_MPAGE',prop:'Class'}]}");
         setEventMetadata("OPENTABLE_MPAGE","{handler:'E150X1',iparms:[{av:'divMyaccountmenu_Visible',ctrl:'MYACCOUNTMENU_MPAGE',prop:'Visible'}]");
         setEventMetadata("OPENTABLE_MPAGE",",oparms:[{av:'divMyaccountmenu_Visible',ctrl:'MYACCOUNTMENU_MPAGE',prop:'Visible'}]}");
         setEventMetadata("CHANGEPASSWORD_MPAGE","{handler:'E160X1',iparms:[]");
         setEventMetadata("CHANGEPASSWORD_MPAGE",",oparms:[]}");
         setEventMetadata("SIGNOUT_MPAGE","{handler:'E190X2',iparms:[]");
         setEventMetadata("SIGNOUT_MPAGE",",oparms:[]}");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE","{handler:'E120X1',iparms:[]");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE",",oparms:[]}");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE","{handler:'E130X1',iparms:[]");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         AV17Pgmname = "";
         GXKey = "";
         AV6MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         imgMenutoggle_gximage = "";
         StyleString = "";
         sImgUrl = "";
         imgMenutoggle_Jsonclick = "";
         imgApplicationicon_gximage = "";
         imgApplicationicon_Jsonclick = "";
         lblApplicationname_Jsonclick = "";
         AV9SearchCriteria = "";
         imgImage2_gximage = "";
         imgImage2_Jsonclick = "";
         lblUserinitialstextblocksmall_Jsonclick = "";
         AV12UserAvatarSmall = "";
         AV18Useravatarsmall_GXI = "";
         lblUsernametextblock_Jsonclick = "";
         AV11UserAvatar = "";
         AV19Useravatar_GXI = "";
         lblUserinitialstextblock_Jsonclick = "";
         lblUsername_Jsonclick = "";
         lblUseremail_Jsonclick = "";
         lblChangepassword_Jsonclick = "";
         lblSignout_Jsonclick = "";
         ucK2baccordionmenu = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         WebComp_Notificationscomponent_Component = "";
         WebComp_Uiconfiguration_Component = "";
         WebComp_Footercomponent_Component = "";
         GX_FocusControl = "";
         AV15GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "test");
         AV5DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV8SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "test");
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem3 = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "test");
         AV10SearchCriteriaSession = "";
         AV13UserCaption = "";
         AV20GXV3 = new GxSimpleCollection<string>();
         AV7Name = "";
         GXt_char4 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         WebComp_Notificationscomponent = new GeneXus.Http.GXNullWebComponent();
         WebComp_Uiconfiguration = new GeneXus.Http.GXNullWebComponent();
         WebComp_Footercomponent = new GeneXus.Http.GXNullWebComponent();
         AV17Pgmname = "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu";
         /* GeneXus formulas. */
         AV17Pgmname = "K2BTools.DesignSystems.Aries.MasterPage4_VerticalMenu";
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int divMyaccountmenu_Visible ;
      private int divUniversalsearch_Visible ;
      private int edtavSearchcriteria_Enabled ;
      private int lblUserinitialstextblocksmall_Visible ;
      private int imgavUseravatarsmall_Visible ;
      private int imgavUseravatar_Visible ;
      private int lblUserinitialstextblock_Visible ;
      private int AV16GXV2 ;
      private int AV21GXV4 ;
      private int idxLst ;
      private string divMaintable_Class ;
      private string AV17Pgmname ;
      private string GXKey ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divSection2_Internalname ;
      private string divTable1_Internalname ;
      private string divHeader_Internalname ;
      private string divTable3_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string imgMenutoggle_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgMenutoggle_Internalname ;
      private string imgMenutoggle_Jsonclick ;
      private string imgApplicationicon_gximage ;
      private string imgApplicationicon_Internalname ;
      private string imgApplicationicon_Jsonclick ;
      private string lblApplicationname_Internalname ;
      private string lblApplicationname_Jsonclick ;
      private string divTopmiddle_Internalname ;
      private string divTopend_Internalname ;
      private string divUniversalsearch_Internalname ;
      private string edtavSearchcriteria_Internalname ;
      private string AV9SearchCriteria ;
      private string edtavSearchcriteria_Jsonclick ;
      private string imgImage2_gximage ;
      private string imgImage2_Internalname ;
      private string imgImage2_Jsonclick ;
      private string divTable4_Internalname ;
      private string divMyaccount_Internalname ;
      private string lblUserinitialstextblocksmall_Internalname ;
      private string lblUserinitialstextblocksmall_Caption ;
      private string lblUserinitialstextblocksmall_Jsonclick ;
      private string imgavUseravatarsmall_gximage ;
      private string imgavUseravatarsmall_Internalname ;
      private string imgavUseravatarsmall_Jsonclick ;
      private string lblUsernametextblock_Internalname ;
      private string lblUsernametextblock_Caption ;
      private string lblUsernametextblock_Jsonclick ;
      private string divMyaccountmenu_Internalname ;
      private string divSection1_Internalname ;
      private string imgavUseravatar_gximage ;
      private string imgavUseravatar_Internalname ;
      private string lblUserinitialstextblock_Internalname ;
      private string lblUserinitialstextblock_Caption ;
      private string lblUserinitialstextblock_Jsonclick ;
      private string lblUsername_Internalname ;
      private string lblUsername_Caption ;
      private string lblUsername_Jsonclick ;
      private string lblUseremail_Internalname ;
      private string lblUseremail_Caption ;
      private string lblUseremail_Jsonclick ;
      private string lblChangepassword_Internalname ;
      private string lblChangepassword_Jsonclick ;
      private string lblSignout_Internalname ;
      private string lblSignout_Jsonclick ;
      private string divMiddle_Internalname ;
      private string divMenucell_Internalname ;
      private string divCenterstart_Internalname ;
      private string divMenucontainer_Internalname ;
      private string K2baccordionmenu_Internalname ;
      private string divCentermiddle_Internalname ;
      private string divTable2_Internalname ;
      private string divFootercontainer_Internalname ;
      private string divFootercontents_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string WebComp_Notificationscomponent_Component ;
      private string WebComp_Uiconfiguration_Component ;
      private string WebComp_Footercomponent_Component ;
      private string GX_FocusControl ;
      private string AV10SearchCriteriaSession ;
      private string AV13UserCaption ;
      private string AV7Name ;
      private string GXt_char4 ;
      private string sDynURL ;
      private bool K2baccordionmenu_Includesearch ;
      private bool wbLoad ;
      private bool AV12UserAvatarSmall_IsBlob ;
      private bool AV11UserAvatar_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool bDynCreated_Notificationscomponent ;
      private bool bDynCreated_Uiconfiguration ;
      private bool bDynCreated_Footercomponent ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV18Useravatarsmall_GXI ;
      private string AV19Useravatar_GXI ;
      private string AV12UserAvatarSmall ;
      private string AV11UserAvatar ;
      private GXWebComponent WebComp_Notificationscomponent ;
      private GXWebComponent WebComp_Uiconfiguration ;
      private GXWebComponent WebComp_Footercomponent ;
      private GXUserControl ucK2baccordionmenu ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV20GXV3 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV15GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV6MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> AV8SearchableTransactions ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem3 ;
      private GXWebForm Form ;
      private SdtK2BAttributeValue_Item AV5DesignSystemOption ;
   }

}
