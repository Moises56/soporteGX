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
namespace GeneXus.Programs.k2bfsg {
   public class sleepafterincorrectlogin : GXProcedure
   {
      public sleepafterincorrectlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public sleepafterincorrectlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref short aP0_LoginAttempts )
      {
         this.AV8LoginAttempts = aP0_LoginAttempts;
         initialize();
         executePrivate();
         aP0_LoginAttempts=this.AV8LoginAttempts;
      }

      public short executeUdp( )
      {
         execute(ref aP0_LoginAttempts);
         return AV8LoginAttempts ;
      }

      public void executeSubmit( ref short aP0_LoginAttempts )
      {
         sleepafterincorrectlogin objsleepafterincorrectlogin;
         objsleepafterincorrectlogin = new sleepafterincorrectlogin();
         objsleepafterincorrectlogin.AV8LoginAttempts = aP0_LoginAttempts;
         objsleepafterincorrectlogin.context.SetSubmitInitialConfig(context);
         objsleepafterincorrectlogin.initialize();
         Submit( executePrivateCatch,objsleepafterincorrectlogin);
         aP0_LoginAttempts=this.AV8LoginAttempts;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sleepafterincorrectlogin)stateInfo).executePrivate();
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
         AV11seconds = (decimal)(NumberUtil.Random( )*3);
         AV12result = GXUtil.Sleep( (int)(Math.Round(AV11seconds, 18, MidpointRounding.ToEven)));
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

      private short AV8LoginAttempts ;
      private short AV12result ;
      private decimal AV11seconds ;
      private short aP0_LoginAttempts ;
   }

}
