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
   public class k2btoolsmessagequeueadd : GXProcedure
   {
      public k2btoolsmessagequeueadd( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsmessagequeueadd( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Utils.SdtMessages_Message aP0_Message )
      {
         this.AV8Message = aP0_Message;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Utils.SdtMessages_Message aP0_Message )
      {
         k2btoolsmessagequeueadd objk2btoolsmessagequeueadd;
         objk2btoolsmessagequeueadd = new k2btoolsmessagequeueadd();
         objk2btoolsmessagequeueadd.AV8Message = aP0_Message;
         objk2btoolsmessagequeueadd.context.SetSubmitInitialConfig(context);
         objk2btoolsmessagequeueadd.initialize();
         Submit( executePrivateCatch,objk2btoolsmessagequeueadd);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsmessagequeueadd)stateInfo).executePrivate();
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
         AV11SessionString = AV9Session.Get(context.GetMessage( "K2BToolsMessageQueue_Content", ""));
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV11SessionString)) ) )
         {
            AV10Messages.FromJSonString(AV11SessionString, null);
         }
         else
         {
            AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         }
         AV10Messages.Add(AV8Message, 0);
         AV9Session.Set(context.GetMessage( "K2BToolsMessageQueue_Content", ""), AV10Messages.ToJSonString(false));
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
         AV11SessionString = "";
         AV9Session = context.GetSession();
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
      }

      private string AV11SessionString ;
      private IGxSession AV9Session ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
   }

}
