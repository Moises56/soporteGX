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
   public class k2btoolsmessagequeuegetallmessages : GXProcedure
   {
      public k2btoolsmessagequeuegetallmessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsmessagequeuegetallmessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages )
      {
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP0_Messages=this.AV8Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( )
      {
         execute(out aP0_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages )
      {
         k2btoolsmessagequeuegetallmessages objk2btoolsmessagequeuegetallmessages;
         objk2btoolsmessagequeuegetallmessages = new k2btoolsmessagequeuegetallmessages();
         objk2btoolsmessagequeuegetallmessages.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objk2btoolsmessagequeuegetallmessages.context.SetSubmitInitialConfig(context);
         objk2btoolsmessagequeuegetallmessages.initialize();
         Submit( executePrivateCatch,objk2btoolsmessagequeuegetallmessages);
         aP0_Messages=this.AV8Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsmessagequeuegetallmessages)stateInfo).executePrivate();
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
         AV10SessionString = AV9Session.Get("K2BToolsMessageQueue_Content");
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV10SessionString)) ) )
         {
            AV8Messages.FromJSonString(AV10SessionString, null);
            AV9Session.Remove("K2BToolsMessageQueue_Content");
         }
         else
         {
            AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10SessionString = "";
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV10SessionString ;
      private IGxSession AV9Session ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP0_Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
   }

}
