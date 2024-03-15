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
   public class k2bsettransactionpk : GXProcedure
   {
      public k2bsettransactionpk( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsettransactionpk( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TransactionName ,
                           GXBaseCollection<SdtK2BAttributeValue_Item> aP1_AttributePK )
      {
         this.AV9TransactionName = aP0_TransactionName;
         this.AV8AttributePK = aP1_AttributePK;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_TransactionName ,
                                 GXBaseCollection<SdtK2BAttributeValue_Item> aP1_AttributePK )
      {
         k2bsettransactionpk objk2bsettransactionpk;
         objk2bsettransactionpk = new k2bsettransactionpk();
         objk2bsettransactionpk.AV9TransactionName = aP0_TransactionName;
         objk2bsettransactionpk.AV8AttributePK = aP1_AttributePK;
         objk2bsettransactionpk.context.SetSubmitInitialConfig(context);
         objk2bsettransactionpk.initialize();
         Submit( executePrivateCatch,objk2bsettransactionpk);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsettransactionpk)stateInfo).executePrivate();
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
         AV10JSon = AV8AttributePK.ToJSonString(false);
         new k2bsessionset(context ).execute(  AV9TransactionName+context.GetMessage( ":TransactionPK", ""),  AV10JSon) ;
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
         AV10JSon = "";
         /* GeneXus formulas. */
      }

      private string AV9TransactionName ;
      private string AV10JSon ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV8AttributePK ;
   }

}
