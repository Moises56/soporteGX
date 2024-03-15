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
namespace GeneXus.Programs {
   public class k2bgetusermenu : GXProcedure
   {
      public k2bgetusermenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetusermenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems )
      {
         this.AV8MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         initialize();
         executePrivate();
         aP0_MenuItems=this.AV8MenuItems;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( )
      {
         execute(out aP0_MenuItems);
         return AV8MenuItems ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems )
      {
         k2bgetusermenu objk2bgetusermenu;
         objk2bgetusermenu = new k2bgetusermenu();
         objk2bgetusermenu.AV8MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         objk2bgetusermenu.context.SetSubmitInitialConfig(context);
         objk2bgetusermenu.initialize();
         Submit( executePrivateCatch,objk2bgetusermenu);
         aP0_MenuItems=this.AV8MenuItems;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusermenu)stateInfo).executePrivate();
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
         AV12GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplicationbyguid(new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getguid(), out  AV18Errors);
         AV14AditionalParameters.gxTpr_Loadproperties = true;
         AV14AditionalParameters.gxTpr_Loaddescriptions = true;
         AV13GamMenuOptionList = AV12GAMApplication.getusermainmenu(AV14AditionalParameters, out  AV18Errors);
         if ( AV13GamMenuOptionList.gxTpr_Nodes.Count > 0 )
         {
            GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = AV8MenuItems;
            new GeneXus.Programs.k2bfsg.gamapplicationmenutok2bmultilevelmenu(context ).execute(  AV13GamMenuOptionList.gxTpr_Nodes, out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
            AV8MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
         }
         else
         {
            GXt_objcol_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem2 = AV15AllStaticMenu;
            new k2blistallstaticmenus(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem2) ;
            AV15AllStaticMenu = GXt_objcol_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem2;
            if ( AV15AllStaticMenu.Count > 0 )
            {
               AV8MenuItems = ((SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem)AV15AllStaticMenu.Item(1)).gxTpr_K2bmultilevelmenu;
            }
            else
            {
               GXt_objcol_SdtK2BProgramNames_ProgramName3 = AV24ProgramNames;
               new k2blistprograms(context ).execute( out  GXt_objcol_SdtK2BProgramNames_ProgramName3) ;
               AV24ProgramNames = GXt_objcol_SdtK2BProgramNames_ProgramName3;
               if ( AV24ProgramNames.Count > 0 )
               {
                  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = AV8MenuItems;
                  new k2blistprogramstomultilevelmenusdt(context ).execute(  AV24ProgramNames, out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
                  AV8MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
                  AV23MenuItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
                  AV23MenuItem.gxTpr_Code = "FastStartGAMBackendInListPrograms";
                  AV23MenuItem.gxTpr_Title = context.GetMessage( "Security Backend", "");
                  AV23MenuItem.gxTpr_Showinlarge = true;
                  AV23MenuItem.gxTpr_Showinmedium = true;
                  AV23MenuItem.gxTpr_Showinsmall = true;
                  AV23MenuItem.gxTpr_Showinextrasmall = true;
                  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>();
                  new GeneXus.Programs.k2bfsg.faststartgammenuloader(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
                  AV23MenuItem.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
                  AV8MenuItems.Add(AV23MenuItem, 0);
               }
               else
               {
                  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = AV8MenuItems;
                  new GeneXus.Programs.k2bfsg.faststartgammenuloader(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
                  AV8MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
               }
            }
         }
         this.cleanup();
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
         AV8MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV12GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV18Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14AditionalParameters = new GeneXus.Programs.genexussecurity.SdtGAMMenuAdditionalParameters(context);
         AV13GamMenuOptionList = new GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList(context);
         AV15AllStaticMenu = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test");
         GXt_objcol_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem2 = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test");
         AV24ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "test");
         GXt_objcol_SdtK2BProgramNames_ProgramName3 = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "test");
         AV23MenuItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV18Errors ;
      private GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> AV15AllStaticMenu ;
      private GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> GXt_objcol_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem2 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV8MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV24ProgramNames ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> GXt_objcol_SdtK2BProgramNames_ProgramName3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV12GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList AV13GamMenuOptionList ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuAdditionalParameters AV14AditionalParameters ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV23MenuItem ;
   }

}
