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
   public class k2bsessionremove : GXProcedure
   {
      public k2bsessionremove( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsessionremove( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SessionItem )
      {
         this.AV10SessionItem = aP0_SessionItem;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_SessionItem )
      {
         k2bsessionremove objk2bsessionremove;
         objk2bsessionremove = new k2bsessionremove();
         objk2bsessionremove.AV10SessionItem = aP0_SessionItem;
         objk2bsessionremove.context.SetSubmitInitialConfig(context);
         objk2bsessionremove.initialize();
         Submit( executePrivateCatch,objk2bsessionremove);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsessionremove)stateInfo).executePrivate();
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
         AV9Session.Remove(AV10SessionItem);
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
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV10SessionItem ;
      private IGxSession AV9Session ;
   }

}
