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
namespace GeneXus.Programs.k2btools.integrationprocedures {
   public class getwebnotificationsunreadcount : GXProcedure
   {
      public getwebnotificationsunreadcount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getwebnotificationsunreadcount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out short aP0_Count )
      {
         this.AV8Count = 0 ;
         initialize();
         executePrivate();
         aP0_Count=this.AV8Count;
      }

      public short executeUdp( )
      {
         execute(out aP0_Count);
         return AV8Count ;
      }

      public void executeSubmit( out short aP0_Count )
      {
         getwebnotificationsunreadcount objgetwebnotificationsunreadcount;
         objgetwebnotificationsunreadcount = new getwebnotificationsunreadcount();
         objgetwebnotificationsunreadcount.AV8Count = 0 ;
         objgetwebnotificationsunreadcount.context.SetSubmitInitialConfig(context);
         objgetwebnotificationsunreadcount.initialize();
         Submit( executePrivateCatch,objgetwebnotificationsunreadcount);
         aP0_Count=this.AV8Count;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getwebnotificationsunreadcount)stateInfo).executePrivate();
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
         AV8Count = 5;
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

      private short AV8Count ;
      private short aP0_Count ;
   }

}
