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
   public class isvalidurl : GXProcedure
   {
      public isvalidurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public isvalidurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_URL ,
                           out bool aP1_IsValidURL )
      {
         this.AV8URL = aP0_URL;
         this.AV9IsValidURL = false ;
         initialize();
         executePrivate();
         aP1_IsValidURL=this.AV9IsValidURL;
      }

      public bool executeUdp( string aP0_URL )
      {
         execute(aP0_URL, out aP1_IsValidURL);
         return AV9IsValidURL ;
      }

      public void executeSubmit( string aP0_URL ,
                                 out bool aP1_IsValidURL )
      {
         isvalidurl objisvalidurl;
         objisvalidurl = new isvalidurl();
         objisvalidurl.AV8URL = aP0_URL;
         objisvalidurl.AV9IsValidURL = false ;
         objisvalidurl.context.SetSubmitInitialConfig(context);
         objisvalidurl.initialize();
         Submit( executePrivateCatch,objisvalidurl);
         aP1_IsValidURL=this.AV9IsValidURL;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isvalidurl)stateInfo).executePrivate();
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
         AV9IsValidURL = GxRegex.IsMatch(AV8URL,context.GetMessage( "^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*", "")+"\""+context.GetMessage( "'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*", "")+"\""+context.GetMessage( "'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*", "")+"\""+context.GetMessage( "'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*", "")+"\""+context.GetMessage( "'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$", ""));
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

      private bool AV9IsValidURL ;
      private string AV8URL ;
      private bool aP1_IsValidURL ;
   }

}
