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
   public class convertgammessagestomessages : GXProcedure
   {
      public convertgammessagestomessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public convertgammessagestomessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrors ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         this.AV8GAMErrors = aP0_GAMErrors;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrors )
      {
         execute(aP0_GAMErrors, out aP1_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrors ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         convertgammessagestomessages objconvertgammessagestomessages;
         objconvertgammessagestomessages = new convertgammessagestomessages();
         objconvertgammessagestomessages.AV8GAMErrors = aP0_GAMErrors;
         objconvertgammessagestomessages.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objconvertgammessagestomessages.context.SetSubmitInitialConfig(context);
         objconvertgammessagestomessages.initialize();
         Submit( executePrivateCatch,objconvertgammessagestomessages);
         aP1_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((convertgammessagestomessages)stateInfo).executePrivate();
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
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8GAMErrors.Count )
         {
            AV9GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8GAMErrors.Item(AV12GXV1));
            AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV11Message.gxTpr_Description = StringUtil.Format( context.GetMessage( "Error: %1 - %2", ""), StringUtil.LTrimStr( (decimal)(AV9GAMError.gxTpr_Code), 12, 0), AV9GAMError.gxTpr_Message, "", "", "", "", "", "", "");
            AV10Messages.Add(AV11Message, 0);
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV9GAMError ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
   }

}
