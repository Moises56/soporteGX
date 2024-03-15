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
   public class k2blistprogramstomultilevelmenusdt : GXProcedure
   {
      public k2blistprogramstomultilevelmenusdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2blistprogramstomultilevelmenusdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramName ,
                           out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_MultiLevelMenu )
      {
         this.AV8ProgramName = aP0_ProgramName;
         this.AV9MultiLevelMenu = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         initialize();
         executePrivate();
         aP1_MultiLevelMenu=this.AV9MultiLevelMenu;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramName )
      {
         execute(aP0_ProgramName, out aP1_MultiLevelMenu);
         return AV9MultiLevelMenu ;
      }

      public void executeSubmit( GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramName ,
                                 out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_MultiLevelMenu )
      {
         k2blistprogramstomultilevelmenusdt objk2blistprogramstomultilevelmenusdt;
         objk2blistprogramstomultilevelmenusdt = new k2blistprogramstomultilevelmenusdt();
         objk2blistprogramstomultilevelmenusdt.AV8ProgramName = aP0_ProgramName;
         objk2blistprogramstomultilevelmenusdt.AV9MultiLevelMenu = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test") ;
         objk2blistprogramstomultilevelmenusdt.context.SetSubmitInitialConfig(context);
         objk2blistprogramstomultilevelmenusdt.initialize();
         Submit( executePrivateCatch,objk2blistprogramstomultilevelmenusdt);
         aP1_MultiLevelMenu=this.AV9MultiLevelMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistprogramstomultilevelmenusdt)stateInfo).executePrivate();
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
         AV9MultiLevelMenu = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8ProgramName.Count )
         {
            AV10ProgramItem = ((SdtK2BProgramNames_ProgramName)AV8ProgramName.Item(AV12GXV1));
            AV11MultiLevelItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
            AV11MultiLevelItem.gxTpr_Link = AV10ProgramItem.gxTpr_Link;
            AV11MultiLevelItem.gxTpr_Title = AV10ProgramItem.gxTpr_Description;
            AV11MultiLevelItem.gxTpr_Showinextrasmall = true;
            AV11MultiLevelItem.gxTpr_Showinsmall = true;
            AV11MultiLevelItem.gxTpr_Showinmedium = true;
            AV11MultiLevelItem.gxTpr_Showinlarge = true;
            AV9MultiLevelMenu.Add(AV11MultiLevelItem, 0);
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV9MultiLevelMenu = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "test");
         AV10ProgramItem = new SdtK2BProgramNames_ProgramName(context);
         AV11MultiLevelItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP1_MultiLevelMenu ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV8ProgramName ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV9MultiLevelMenu ;
      private SdtK2BProgramNames_ProgramName AV10ProgramItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV11MultiLevelItem ;
   }

}
