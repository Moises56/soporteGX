using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class faststartgammenuloader : GXProcedure
   {
      public faststartgammenuloader( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public faststartgammenuloader( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 )
      {
         this.AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         initialize();
         executePrivate();
         aP0_MenuLevel0=this.AV10MenuLevel0;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( )
      {
         execute(out aP0_MenuLevel0);
         return AV10MenuLevel0 ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 )
      {
         faststartgammenuloader objfaststartgammenuloader;
         objfaststartgammenuloader = new faststartgammenuloader();
         objfaststartgammenuloader.AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         objfaststartgammenuloader.context.SetSubmitInitialConfig(context);
         objfaststartgammenuloader.initialize();
         Submit( executePrivateCatch,objfaststartgammenuloader);
         aP0_MenuLevel0=this.AV10MenuLevel0;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((faststartgammenuloader)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.SECBACKENDHOME' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWUSER' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWROLE' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWMENU' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWAPPLICATION' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.REPOSITORYCONFIGURATION' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWAUTHTYPE' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWCONNECTIONS' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWSECURITYPOLICY' */
         S201 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.CHANGEREPOSITORY' */
         S211 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWREPOSITORIES' */
         S221 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.WWEVENTSUBSCRIPTION' */
         S231 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORK2BFSG.GAMCONFIGURATION' */
         S241 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         new k2bisauthorizedactivitylist(context ).execute( ref  AV8ActivityList) ;
         GXt_boolean1 = true;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.SecBackendHome",  "Home",  "",  "fa fa-home",  formatLink("k2bfsg.secbackendhome.aspx") ,  1,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  AV10MenuLevel0) ;
         GXt_boolean2 = true;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWUser",  "Users",  "",  "fa fa-user",  formatLink("k2bfsg.wwuser.aspx") ,  2,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  AV10MenuLevel0) ;
         GXt_boolean3 = true;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWRole",  "Roles",  "",  "fa fa-users",  formatLink("k2bfsg.wwrole.aspx") ,  3,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  AV10MenuLevel0) ;
         GXt_boolean4 = true;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWMenu",  "Menus",  "",  "fa fa-bars",  formatLink("k2bfsg.wwmenu.aspx") ,  4,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  AV10MenuLevel0) ;
         GXt_boolean5 = true;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWApplication",  "Applications",  "",  "fa fa-archive",  formatLink("k2bfsg.wwapplication.aspx") ,  5,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  AV10MenuLevel0) ;
         /* Execute user subroutine: 'ADDADVANCED' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDADVANCED' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "Advanced";
         AV12MenuLevel1.gxTpr_Title = "Advanced";
         GXt_boolean5 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean5, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV12MenuLevel1.gxTpr_Imageclass = "fa fa-cogs ";
         GXt_boolean5 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem6 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.RepositoryConfiguration",  "Repository configuration",  "",  "fa fa-cog",  formatLink("k2bfsg.repositoryconfiguration.aspx", new object[] {GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Id"}) ,  6,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem6) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem6;
         GXt_boolean4 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem7 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWAuthType",  "Authentication types",  "",  "fa fa-key",  formatLink("k2bfsg.wwauthtype.aspx") ,  7,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem7) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem7;
         GXt_boolean3 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWConnections",  "Repository connections",  "",  "fa fa-plug",  formatLink("k2bfsg.wwconnections.aspx") ,  8,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8;
         GXt_boolean2 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWSecurityPolicy",  "Security policies",  "",  "fa fa-file-text-o",  formatLink("k2bfsg.wwsecuritypolicy.aspx") ,  9,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9;
         GXt_boolean1 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.ChangeRepository",  "Change Repository",  "",  "",  formatLink("k2bfsg.changerepository.aspx") ,  10,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10;
         GXt_boolean11 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWRepositories",  "Repositories",  "",  "",  formatLink("k2bfsg.wwrepositories.aspx") ,  11,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean11, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12;
         GXt_boolean13 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.WWEventSubscription",  "Event subscriptions",  "",  "",  formatLink("k2bfsg.wweventsubscription.aspx") ,  12,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean13, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14;
         GXt_boolean15 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "K2BFSG.GAMConfiguration",  "GAM Configuration",  "",  "",  formatLink("k2bfsg.gamconfiguration.aspx") ,  13,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean15, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S121( )
      {
         /* 'CHECKSECURITYFORK2BFSG.SECBACKENDHOME' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "SecBackendHome";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S131( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWUSER' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWUser";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S141( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWROLE' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWRole";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S151( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWMENU' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWMenu";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S161( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWAPPLICATION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWApplication";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S171( )
      {
         /* 'CHECKSECURITYFORK2BFSG.REPOSITORYCONFIGURATION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "RepositoryConfiguration";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S181( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWAUTHTYPE' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWAuthType";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S191( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWCONNECTIONS' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWConnections";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S201( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWSECURITYPOLICY' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWSecurityPolicy";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S211( )
      {
         /* 'CHECKSECURITYFORK2BFSG.CHANGEREPOSITORY' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "ChangeRepository";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "ChangeRepository";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S221( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWREPOSITORIES' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "K2BSecurity";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWRepositories";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S231( )
      {
         /* 'CHECKSECURITYFORK2BFSG.WWEVENTSUBSCRIPTION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WWEventSubscription";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWEventSubscription";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S241( )
      {
         /* 'CHECKSECURITYFORK2BFSG.GAMCONFIGURATION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "GAMExampleGAMConfiguration";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "GAMConfiguration";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV8ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem6 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem7 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private bool GXt_boolean5 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean3 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean11 ;
      private bool GXt_boolean13 ;
      private bool GXt_boolean15 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV8ActivityList ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV10MenuLevel0 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem6 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem7 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 ;
      private SdtK2BActivityList_K2BActivityListItem AV9ActivityItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV12MenuLevel1 ;
   }

}
