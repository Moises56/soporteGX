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
   public class k2bgettagcollectionforfiltervalues : GXProcedure
   {
      public k2bgettagcollectionforfiltervalues( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgettagcollectionforfiltervalues( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                           out GXBaseCollection<SdtK2BValueDescriptionCollection_Item> aP3_K2BTagCollection )
      {
         this.AV15ProgramName = aP0_ProgramName;
         this.AV11GridName = aP1_GridName;
         this.AV8K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         this.AV16K2BTagCollection = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test") ;
         initialize();
         executePrivate();
         aP3_K2BTagCollection=this.AV16K2BTagCollection;
      }

      public GXBaseCollection<SdtK2BValueDescriptionCollection_Item> executeUdp( string aP0_ProgramName ,
                                                                                 string aP1_GridName ,
                                                                                 GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT )
      {
         execute(aP0_ProgramName, aP1_GridName, aP2_K2BFilterValuesSDT, out aP3_K2BTagCollection);
         return AV16K2BTagCollection ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                                 out GXBaseCollection<SdtK2BValueDescriptionCollection_Item> aP3_K2BTagCollection )
      {
         k2bgettagcollectionforfiltervalues objk2bgettagcollectionforfiltervalues;
         objk2bgettagcollectionforfiltervalues = new k2bgettagcollectionforfiltervalues();
         objk2bgettagcollectionforfiltervalues.AV15ProgramName = aP0_ProgramName;
         objk2bgettagcollectionforfiltervalues.AV11GridName = aP1_GridName;
         objk2bgettagcollectionforfiltervalues.AV8K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         objk2bgettagcollectionforfiltervalues.AV16K2BTagCollection = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test") ;
         objk2bgettagcollectionforfiltervalues.context.SetSubmitInitialConfig(context);
         objk2bgettagcollectionforfiltervalues.initialize();
         Submit( executePrivateCatch,objk2bgettagcollectionforfiltervalues);
         aP3_K2BTagCollection=this.AV16K2BTagCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgettagcollectionforfiltervalues)stateInfo).executePrivate();
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
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV8K2BFilterValuesSDT.Count )
         {
            AV9K2BFilterValuesSDTItem = ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem)AV8K2BFilterValuesSDT.Item(AV20GXV1));
            AV18Description = AV9K2BFilterValuesSDTItem.gxTpr_Description;
            if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Standard") == 0 )
            {
               GXt_char1 = AV19Value;
               new k2bgetstandardfiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Valuedescription, out  GXt_char1) ;
               AV19Value = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "DateTimeRange") == 0 )
            {
               GXt_char1 = AV19Value;
               new k2bgetdatetimerangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangetovalue, out  GXt_char1) ;
               AV19Value = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "DateRange") == 0 )
            {
               GXt_char1 = AV19Value;
               new k2bgetdaterangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangetovalue, out  GXt_char1) ;
               AV19Value = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Multiple") == 0 )
            {
               GXt_char1 = AV19Value;
               new k2bgetmultiplefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Multiplevalues, out  GXt_char1) ;
               AV19Value = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Numeric Range") == 0 )
            {
               GXt_char1 = AV19Value;
               new k2bgetnumericrangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticnumericrangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Numericrangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Numericrangetovalue, out  GXt_char1) ;
               AV19Value = GXt_char1;
            }
            AV17K2BTagCollectionItem = new SdtK2BValueDescriptionCollection_Item(context);
            AV17K2BTagCollectionItem.gxTpr_Value = AV9K2BFilterValuesSDTItem.gxTpr_Name;
            AV17K2BTagCollectionItem.gxTpr_Description = AV18Description+":"+AV19Value;
            AV17K2BTagCollectionItem.gxTpr_Canbedeleted = AV9K2BFilterValuesSDTItem.gxTpr_Canbedeleted;
            AV16K2BTagCollection.Add(AV17K2BTagCollectionItem, 0);
            AV20GXV1 = (int)(AV20GXV1+1);
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
         AV16K2BTagCollection = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "test");
         AV9K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         AV18Description = "";
         AV19Value = "";
         GXt_char1 = "";
         AV17K2BTagCollectionItem = new SdtK2BValueDescriptionCollection_Item(context);
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private string AV15ProgramName ;
      private string AV11GridName ;
      private string AV18Description ;
      private string AV19Value ;
      private string GXt_char1 ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> aP3_K2BTagCollection ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV8K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV16K2BTagCollection ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV9K2BFilterValuesSDTItem ;
      private SdtK2BValueDescriptionCollection_Item AV17K2BTagCollectionItem ;
   }

}
