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
   public class k2bmenusetshowin : GXProcedure
   {
      public k2bmenusetshowin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bmenusetshowin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( bool aP0_ShowInExtraSmall ,
                           bool aP1_ShowInSmall ,
                           bool aP2_ShowInMedium ,
                           ref bool aP3_ShowInLarge ,
                           ref SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem aP4_CurrentMenuItem )
      {
         this.AV17ShowInExtraSmall = aP0_ShowInExtraSmall;
         this.AV18ShowInSmall = aP1_ShowInSmall;
         this.AV19ShowInMedium = aP2_ShowInMedium;
         this.AV20ShowInLarge = aP3_ShowInLarge;
         this.AV11CurrentMenuItem = aP4_CurrentMenuItem;
         initialize();
         executePrivate();
         aP3_ShowInLarge=this.AV20ShowInLarge;
         aP4_CurrentMenuItem=this.AV11CurrentMenuItem;
      }

      public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem executeUdp( bool aP0_ShowInExtraSmall ,
                                                                    bool aP1_ShowInSmall ,
                                                                    bool aP2_ShowInMedium ,
                                                                    ref bool aP3_ShowInLarge )
      {
         execute(aP0_ShowInExtraSmall, aP1_ShowInSmall, aP2_ShowInMedium, ref aP3_ShowInLarge, ref aP4_CurrentMenuItem);
         return AV11CurrentMenuItem ;
      }

      public void executeSubmit( bool aP0_ShowInExtraSmall ,
                                 bool aP1_ShowInSmall ,
                                 bool aP2_ShowInMedium ,
                                 ref bool aP3_ShowInLarge ,
                                 ref SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem aP4_CurrentMenuItem )
      {
         k2bmenusetshowin objk2bmenusetshowin;
         objk2bmenusetshowin = new k2bmenusetshowin();
         objk2bmenusetshowin.AV17ShowInExtraSmall = aP0_ShowInExtraSmall;
         objk2bmenusetshowin.AV18ShowInSmall = aP1_ShowInSmall;
         objk2bmenusetshowin.AV19ShowInMedium = aP2_ShowInMedium;
         objk2bmenusetshowin.AV20ShowInLarge = aP3_ShowInLarge;
         objk2bmenusetshowin.AV11CurrentMenuItem = aP4_CurrentMenuItem;
         objk2bmenusetshowin.context.SetSubmitInitialConfig(context);
         objk2bmenusetshowin.initialize();
         Submit( executePrivateCatch,objk2bmenusetshowin);
         aP3_ShowInLarge=this.AV20ShowInLarge;
         aP4_CurrentMenuItem=this.AV11CurrentMenuItem;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bmenusetshowin)stateInfo).executePrivate();
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
         AV11CurrentMenuItem.gxTpr_Showinextrasmall = AV17ShowInExtraSmall;
         AV11CurrentMenuItem.gxTpr_Showinsmall = AV18ShowInSmall;
         AV11CurrentMenuItem.gxTpr_Showinmedium = AV19ShowInMedium;
         AV11CurrentMenuItem.gxTpr_Showinlarge = AV20ShowInLarge;
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
         /* GeneXus formulas. */
      }

      private bool AV17ShowInExtraSmall ;
      private bool AV18ShowInSmall ;
      private bool AV19ShowInMedium ;
      private bool AV20ShowInLarge ;
      private bool aP3_ShowInLarge ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem aP4_CurrentMenuItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV11CurrentMenuItem ;
   }

}
