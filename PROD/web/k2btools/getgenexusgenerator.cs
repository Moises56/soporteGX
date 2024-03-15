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
namespace GeneXus.Programs.k2btools {
   public class getgenexusgenerator : GXProcedure
   {
      public getgenexusgenerator( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getgenexusgenerator( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out short aP0_GeneXusGenerator )
      {
         this.AV8GeneXusGenerator = 0 ;
         initialize();
         executePrivate();
         aP0_GeneXusGenerator=this.AV8GeneXusGenerator;
      }

      public short executeUdp( )
      {
         execute(out aP0_GeneXusGenerator);
         return AV8GeneXusGenerator ;
      }

      public void executeSubmit( out short aP0_GeneXusGenerator )
      {
         getgenexusgenerator objgetgenexusgenerator;
         objgetgenexusgenerator = new getgenexusgenerator();
         objgetgenexusgenerator.AV8GeneXusGenerator = 0 ;
         objgetgenexusgenerator.context.SetSubmitInitialConfig(context);
         objgetgenexusgenerator.initialize();
         Submit( executePrivateCatch,objgetgenexusgenerator);
         aP0_GeneXusGenerator=this.AV8GeneXusGenerator;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getgenexusgenerator)stateInfo).executePrivate();
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
         AV9java = 1;
         AV10csharp = 2;
         /* User Code */
          AV8GeneXusGenerator = AV10csharp;
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

      private short AV8GeneXusGenerator ;
      private short AV9java ;
      private short AV10csharp ;
      private short aP0_GeneXusGenerator ;
   }

}
