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
   public class k2bmenuaddprogram : GXProcedure
   {
      public k2bmenuaddprogram( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bmenuaddprogram( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Code ,
                           string aP1_Title ,
                           string aP2_ImageUrl ,
                           string aP3_ImageClass ,
                           string aP4_Link ,
                           short aP5_SecurityIndex ,
                           GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP6_ActivityList ,
                           bool aP7_ShowInExtraSmall ,
                           bool aP8_ShowInSmall ,
                           bool aP9_ShowInMedium ,
                           ref bool aP10_ShowInLarge ,
                           ref GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP11_CurrentMenu )
      {
         this.AV9Code = aP0_Code;
         this.AV16Title = aP1_Title;
         this.AV13ImageUrl = aP2_ImageUrl;
         this.AV12ImageClass = aP3_ImageClass;
         this.AV14Link = aP4_Link;
         this.AV15SecurityIndex = aP5_SecurityIndex;
         this.AV8ActivityList = aP6_ActivityList;
         this.AV17ShowInExtraSmall = aP7_ShowInExtraSmall;
         this.AV18ShowInSmall = aP8_ShowInSmall;
         this.AV19ShowInMedium = aP9_ShowInMedium;
         this.AV20ShowInLarge = aP10_ShowInLarge;
         this.AV10CurrentMenu = aP11_CurrentMenu;
         initialize();
         executePrivate();
         aP10_ShowInLarge=this.AV20ShowInLarge;
         aP11_CurrentMenu=this.AV10CurrentMenu;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( string aP0_Code ,
                                                                                      string aP1_Title ,
                                                                                      string aP2_ImageUrl ,
                                                                                      string aP3_ImageClass ,
                                                                                      string aP4_Link ,
                                                                                      short aP5_SecurityIndex ,
                                                                                      GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP6_ActivityList ,
                                                                                      bool aP7_ShowInExtraSmall ,
                                                                                      bool aP8_ShowInSmall ,
                                                                                      bool aP9_ShowInMedium ,
                                                                                      ref bool aP10_ShowInLarge )
      {
         execute(aP0_Code, aP1_Title, aP2_ImageUrl, aP3_ImageClass, aP4_Link, aP5_SecurityIndex, aP6_ActivityList, aP7_ShowInExtraSmall, aP8_ShowInSmall, aP9_ShowInMedium, ref aP10_ShowInLarge, ref aP11_CurrentMenu);
         return AV10CurrentMenu ;
      }

      public void executeSubmit( string aP0_Code ,
                                 string aP1_Title ,
                                 string aP2_ImageUrl ,
                                 string aP3_ImageClass ,
                                 string aP4_Link ,
                                 short aP5_SecurityIndex ,
                                 GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP6_ActivityList ,
                                 bool aP7_ShowInExtraSmall ,
                                 bool aP8_ShowInSmall ,
                                 bool aP9_ShowInMedium ,
                                 ref bool aP10_ShowInLarge ,
                                 ref GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP11_CurrentMenu )
      {
         k2bmenuaddprogram objk2bmenuaddprogram;
         objk2bmenuaddprogram = new k2bmenuaddprogram();
         objk2bmenuaddprogram.AV9Code = aP0_Code;
         objk2bmenuaddprogram.AV16Title = aP1_Title;
         objk2bmenuaddprogram.AV13ImageUrl = aP2_ImageUrl;
         objk2bmenuaddprogram.AV12ImageClass = aP3_ImageClass;
         objk2bmenuaddprogram.AV14Link = aP4_Link;
         objk2bmenuaddprogram.AV15SecurityIndex = aP5_SecurityIndex;
         objk2bmenuaddprogram.AV8ActivityList = aP6_ActivityList;
         objk2bmenuaddprogram.AV17ShowInExtraSmall = aP7_ShowInExtraSmall;
         objk2bmenuaddprogram.AV18ShowInSmall = aP8_ShowInSmall;
         objk2bmenuaddprogram.AV19ShowInMedium = aP9_ShowInMedium;
         objk2bmenuaddprogram.AV20ShowInLarge = aP10_ShowInLarge;
         objk2bmenuaddprogram.AV10CurrentMenu = aP11_CurrentMenu;
         objk2bmenuaddprogram.context.SetSubmitInitialConfig(context);
         objk2bmenuaddprogram.initialize();
         Submit( executePrivateCatch,objk2bmenuaddprogram);
         aP10_ShowInLarge=this.AV20ShowInLarge;
         aP11_CurrentMenu=this.AV10CurrentMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bmenuaddprogram)stateInfo).executePrivate();
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
         if ( ( AV15SecurityIndex == 0 ) || ((SdtK2BActivityList_K2BActivityListItem)AV8ActivityList.Item(AV15SecurityIndex)).gxTpr_Isauthorized )
         {
            AV11CurrentMenuItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
            AV11CurrentMenuItem.gxTpr_Code = AV9Code;
            AV11CurrentMenuItem.gxTpr_Imageclass = AV12ImageClass;
            AV11CurrentMenuItem.gxTpr_Imageurl = AV13ImageUrl;
            AV11CurrentMenuItem.gxTpr_Title = AV16Title;
            AV11CurrentMenuItem.gxTpr_Link = AV14Link;
            new k2bmenusetshowin(context ).execute(  AV17ShowInExtraSmall,  AV18ShowInSmall,  AV19ShowInMedium, ref  AV20ShowInLarge, ref  AV11CurrentMenuItem) ;
            AV10CurrentMenu.Add(AV11CurrentMenuItem, 0);
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
         AV11CurrentMenuItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         /* GeneXus formulas. */
      }

      private short AV15SecurityIndex ;
      private string AV9Code ;
      private string AV16Title ;
      private string AV12ImageClass ;
      private bool AV17ShowInExtraSmall ;
      private bool AV18ShowInSmall ;
      private bool AV19ShowInMedium ;
      private bool AV20ShowInLarge ;
      private string AV13ImageUrl ;
      private string AV14Link ;
      private bool aP10_ShowInLarge ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP11_CurrentMenu ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV8ActivityList ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV10CurrentMenu ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV11CurrentMenuItem ;
   }

}
