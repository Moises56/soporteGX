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
   public class k2btoolsgetsearchresults : GXProcedure
   {
      public k2btoolsgetsearchresults( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsgetsearchresults( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SearchType ,
                           string aP1_SearchCriteria ,
                           short aP2_PageSize ,
                           short aP3_ItemsToSkip ,
                           out short aP4_ItemsProcessed ,
                           out bool aP5_PendingItemsExist ,
                           out GXBaseCollection<SdtK2BSearchResult_Item> aP6_K2BSearchResult )
      {
         this.AV10SearchType = aP0_SearchType;
         this.AV24SearchCriteria = aP1_SearchCriteria;
         this.AV19PageSize = aP2_PageSize;
         this.AV15ItemsToSkip = aP3_ItemsToSkip;
         this.AV14ItemsProcessed = 0 ;
         this.AV22PendingItemsExist = false ;
         this.AV16K2BSearchResult = new GXBaseCollection<SdtK2BSearchResult_Item>( context, "Item", "test") ;
         initialize();
         executePrivate();
         aP4_ItemsProcessed=this.AV14ItemsProcessed;
         aP5_PendingItemsExist=this.AV22PendingItemsExist;
         aP6_K2BSearchResult=this.AV16K2BSearchResult;
      }

      public GXBaseCollection<SdtK2BSearchResult_Item> executeUdp( string aP0_SearchType ,
                                                                   string aP1_SearchCriteria ,
                                                                   short aP2_PageSize ,
                                                                   short aP3_ItemsToSkip ,
                                                                   out short aP4_ItemsProcessed ,
                                                                   out bool aP5_PendingItemsExist )
      {
         execute(aP0_SearchType, aP1_SearchCriteria, aP2_PageSize, aP3_ItemsToSkip, out aP4_ItemsProcessed, out aP5_PendingItemsExist, out aP6_K2BSearchResult);
         return AV16K2BSearchResult ;
      }

      public void executeSubmit( string aP0_SearchType ,
                                 string aP1_SearchCriteria ,
                                 short aP2_PageSize ,
                                 short aP3_ItemsToSkip ,
                                 out short aP4_ItemsProcessed ,
                                 out bool aP5_PendingItemsExist ,
                                 out GXBaseCollection<SdtK2BSearchResult_Item> aP6_K2BSearchResult )
      {
         k2btoolsgetsearchresults objk2btoolsgetsearchresults;
         objk2btoolsgetsearchresults = new k2btoolsgetsearchresults();
         objk2btoolsgetsearchresults.AV10SearchType = aP0_SearchType;
         objk2btoolsgetsearchresults.AV24SearchCriteria = aP1_SearchCriteria;
         objk2btoolsgetsearchresults.AV19PageSize = aP2_PageSize;
         objk2btoolsgetsearchresults.AV15ItemsToSkip = aP3_ItemsToSkip;
         objk2btoolsgetsearchresults.AV14ItemsProcessed = 0 ;
         objk2btoolsgetsearchresults.AV22PendingItemsExist = false ;
         objk2btoolsgetsearchresults.AV16K2BSearchResult = new GXBaseCollection<SdtK2BSearchResult_Item>( context, "Item", "test") ;
         objk2btoolsgetsearchresults.context.SetSubmitInitialConfig(context);
         objk2btoolsgetsearchresults.initialize();
         Submit( executePrivateCatch,objk2btoolsgetsearchresults);
         aP4_ItemsProcessed=this.AV14ItemsProcessed;
         aP5_PendingItemsExist=this.AV22PendingItemsExist;
         aP6_K2BSearchResult=this.AV16K2BSearchResult;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsgetsearchresults)stateInfo).executePrivate();
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
         AV13itemsFound = 0;
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 = AV9SearchableTransactions;
         new k2bgetsearchableentities(context ).execute( out  GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1) ;
         AV9SearchableTransactions = GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10SearchType)) )
         {
            AV12i = 1;
            while ( AV12i <= AV9SearchableTransactions.Count )
            {
               if ( StringUtil.StrCmp(((SdtSearchableTransactions_SearchableTransactionsItem)AV9SearchableTransactions.Item(AV12i)).gxTpr_Searchtype, AV10SearchType) == 0 )
               {
                  AV12i = (short)(AV12i+1);
               }
               else
               {
                  AV9SearchableTransactions.RemoveItem(AV12i);
               }
            }
         }
         if ( AV15ItemsToSkip == 0 )
         {
            AV21PageToRead = 1;
            AV20PageSizeSearch = AV19PageSize;
         }
         else
         {
            AV21PageToRead = 2;
            AV20PageSizeSearch = AV15ItemsToSkip;
         }
         AV14ItemsProcessed = AV15ItemsToSkip;
         AV11foundItems = true;
         while ( AV11foundItems && ( AV13itemsFound < AV19PageSize + 1 ) )
         {
            AV25SearchResult = (SearchResult)(GxSearchUtils.Search( AV24SearchCriteria, AV20PageSizeSearch, AV21PageToRead, context));
            AV11foundItems = false;
            AV28GXV2 = 1;
            AV27GXV1 = (SearchResultCollection)(AV25SearchResult.Items());
            while ( AV28GXV2 <= AV27GXV1.Count )
            {
               AV26SearchResultItem = ((SearchResultItem)AV27GXV1.Item(AV28GXV2));
               AV11foundItems = true;
               AV8isAuthorized = false;
               AV29GXV3 = 1;
               while ( AV29GXV3 <= AV9SearchableTransactions.Count )
               {
                  AV23SearchableTransactionsItem = ((SdtSearchableTransactions_SearchableTransactionsItem)AV9SearchableTransactions.Item(AV29GXV3));
                  if ( StringUtil.StrCmp(AV23SearchableTransactionsItem.gxTpr_Searchtype, AV26SearchResultItem.Entity) == 0 )
                  {
                     AV8isAuthorized = true;
                     if (true) break;
                  }
                  AV29GXV3 = (int)(AV29GXV3+1);
               }
               if ( AV8isAuthorized )
               {
                  GXt_SdtK2BSearchResult_Item2 = AV17K2BSearchResultItem;
                  new k2bgetsearchresultfromdata(context ).execute(  AV26SearchResultItem,  AV24SearchCriteria, out  GXt_SdtK2BSearchResult_Item2) ;
                  AV17K2BSearchResultItem = GXt_SdtK2BSearchResult_Item2;
                  if ( AV13itemsFound < AV19PageSize )
                  {
                     AV16K2BSearchResult.Add(AV17K2BSearchResultItem, 0);
                  }
                  AV13itemsFound = (short)(AV13itemsFound+1);
                  if ( AV13itemsFound >= AV19PageSize + 1 )
                  {
                     AV14ItemsProcessed = (short)(AV14ItemsProcessed-1);
                     if (true) break;
                  }
               }
               AV14ItemsProcessed = (short)(AV14ItemsProcessed+1);
               AV28GXV2 = (int)(AV28GXV2+1);
            }
            AV21PageToRead = (short)(AV21PageToRead+1);
         }
         if ( AV13itemsFound > AV19PageSize )
         {
            AV22PendingItemsExist = true;
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
         AV16K2BSearchResult = new GXBaseCollection<SdtK2BSearchResult_Item>( context, "Item", "test");
         AV9SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "test");
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "test");
         AV25SearchResult = new SearchResult();
         AV27GXV1 = new SearchResultCollection();
         AV26SearchResultItem = new SearchResultItem();
         AV23SearchableTransactionsItem = new SdtSearchableTransactions_SearchableTransactionsItem(context);
         AV17K2BSearchResultItem = new SdtK2BSearchResult_Item(context);
         GXt_SdtK2BSearchResult_Item2 = new SdtK2BSearchResult_Item(context);
         /* GeneXus formulas. */
      }

      private short AV19PageSize ;
      private short AV15ItemsToSkip ;
      private short AV14ItemsProcessed ;
      private short AV13itemsFound ;
      private short AV12i ;
      private short AV21PageToRead ;
      private short AV20PageSizeSearch ;
      private int AV28GXV2 ;
      private int AV29GXV3 ;
      private string AV10SearchType ;
      private string AV24SearchCriteria ;
      private bool AV22PendingItemsExist ;
      private bool AV11foundItems ;
      private bool AV8isAuthorized ;
      private short aP4_ItemsProcessed ;
      private bool aP5_PendingItemsExist ;
      private GXBaseCollection<SdtK2BSearchResult_Item> aP6_K2BSearchResult ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> AV9SearchableTransactions ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem1 ;
      private GXBaseCollection<SdtK2BSearchResult_Item> AV16K2BSearchResult ;
      private SearchResultItem AV26SearchResultItem ;
      private SearchResultCollection AV27GXV1 ;
      private SearchResult AV25SearchResult ;
      private SdtSearchableTransactions_SearchableTransactionsItem AV23SearchableTransactionsItem ;
      private SdtK2BSearchResult_Item AV17K2BSearchResultItem ;
      private SdtK2BSearchResult_Item GXt_SdtK2BSearchResult_Item2 ;
   }

}
