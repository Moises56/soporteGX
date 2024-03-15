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
   public class k2bsessionset : GXProcedure
   {
      public k2bsessionset( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsessionset( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SessionItem ,
                           string aP1_SessionData )
      {
         this.AV8SessionItem = aP0_SessionItem;
         this.AV9SessionData = aP1_SessionData;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_SessionItem ,
                                 string aP1_SessionData )
      {
         k2bsessionset objk2bsessionset;
         objk2bsessionset = new k2bsessionset();
         objk2bsessionset.AV8SessionItem = aP0_SessionItem;
         objk2bsessionset.AV9SessionData = aP1_SessionData;
         objk2bsessionset.context.SetSubmitInitialConfig(context);
         objk2bsessionset.initialize();
         Submit( executePrivateCatch,objk2bsessionset);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsessionset)stateInfo).executePrivate();
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
         AV10Session.Set(AV8SessionItem, AV9SessionData);
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
         AV10Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV8SessionItem ;
      private string AV9SessionData ;
      private IGxSession AV10Session ;
   }

}
