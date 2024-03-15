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
   public class k2bgetusercode : GXProcedure
   {
      public k2bgetusercode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetusercode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserCode )
      {
         this.AV9UserCode = "" ;
         initialize();
         executePrivate();
         aP0_UserCode=this.AV9UserCode;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserCode);
         return AV9UserCode ;
      }

      public void executeSubmit( out string aP0_UserCode )
      {
         k2bgetusercode objk2bgetusercode;
         objk2bgetusercode = new k2bgetusercode();
         objk2bgetusercode.AV9UserCode = "" ;
         objk2bgetusercode.context.SetSubmitInitialConfig(context);
         objk2bgetusercode.initialize();
         Submit( executePrivateCatch,objk2bgetusercode);
         aP0_UserCode=this.AV9UserCode;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusercode)stateInfo).executePrivate();
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
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV10GAMErrors);
         AV9UserCode = AV11GAMSession.gxTpr_User.gxTpr_Name;
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
         AV9UserCode = "";
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
      }

      private string AV9UserCode ;
      private string aP0_UserCode ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV11GAMSession ;
   }

}
