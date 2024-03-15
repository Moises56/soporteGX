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
   public class k2bgetsearchresultfromdata : GXProcedure
   {
      public k2bgetsearchresultfromdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetsearchresultfromdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SearchResultItem aP0_SearchResultItem ,
                           string aP1_SearchCriteria ,
                           out SdtK2BSearchResult_Item aP2_K2BSearchResult )
      {
         this.AV12SearchResultItem = aP0_SearchResultItem;
         this.AV9SearchCriteria = aP1_SearchCriteria;
         this.AV8K2BSearchResult = new SdtK2BSearchResult_Item(context) ;
         initialize();
         executePrivate();
         aP2_K2BSearchResult=this.AV8K2BSearchResult;
      }

      public SdtK2BSearchResult_Item executeUdp( SearchResultItem aP0_SearchResultItem ,
                                                 string aP1_SearchCriteria )
      {
         execute(aP0_SearchResultItem, aP1_SearchCriteria, out aP2_K2BSearchResult);
         return AV8K2BSearchResult ;
      }

      public void executeSubmit( SearchResultItem aP0_SearchResultItem ,
                                 string aP1_SearchCriteria ,
                                 out SdtK2BSearchResult_Item aP2_K2BSearchResult )
      {
         k2bgetsearchresultfromdata objk2bgetsearchresultfromdata;
         objk2bgetsearchresultfromdata = new k2bgetsearchresultfromdata();
         objk2bgetsearchresultfromdata.AV12SearchResultItem = aP0_SearchResultItem;
         objk2bgetsearchresultfromdata.AV9SearchCriteria = aP1_SearchCriteria;
         objk2bgetsearchresultfromdata.AV8K2BSearchResult = new SdtK2BSearchResult_Item(context) ;
         objk2bgetsearchresultfromdata.context.SetSubmitInitialConfig(context);
         objk2bgetsearchresultfromdata.initialize();
         Submit( executePrivateCatch,objk2bgetsearchresultfromdata);
         aP2_K2BSearchResult=this.AV8K2BSearchResult;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetsearchresultfromdata)stateInfo).executePrivate();
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
         AV8K2BSearchResult = new SdtK2BSearchResult_Item(context);
         AV8K2BSearchResult.gxTpr_Searchresulttitle = AV13SearchResultTitle;
         AV8K2BSearchResult.gxTpr_Searchresultdescription = AV10SearchResultDescription;
         AV8K2BSearchResult.gxTpr_Searchresultimage = AV11SearchResultImage;
         AV8K2BSearchResult.gxTpr_Searchresultimage_gxi = AV14Searchresultimage_GXI;
         AV8K2BSearchResult.gxTpr_Searchresultlink = AV12SearchResultItem.Viewer;
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
         AV8K2BSearchResult = new SdtK2BSearchResult_Item(context);
         AV13SearchResultTitle = "";
         AV10SearchResultDescription = "";
         AV11SearchResultImage = "";
         AV14Searchresultimage_GXI = "";
         /* GeneXus formulas. */
      }

      private string AV9SearchCriteria ;
      private string AV13SearchResultTitle ;
      private string AV10SearchResultDescription ;
      private string AV14Searchresultimage_GXI ;
      private string AV11SearchResultImage ;
      private SdtK2BSearchResult_Item aP2_K2BSearchResult ;
      private SearchResultItem AV12SearchResultItem ;
      private SdtK2BSearchResult_Item AV8K2BSearchResult ;
   }

}
