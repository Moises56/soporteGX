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
   public class k2bgetusercaption : GXProcedure
   {
      public k2bgetusercaption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetusercaption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_UserCaption )
      {
         this.AV8UserCaption = "" ;
         initialize();
         executePrivate();
         aP0_UserCaption=this.AV8UserCaption;
      }

      public string executeUdp( )
      {
         execute(out aP0_UserCaption);
         return AV8UserCaption ;
      }

      public void executeSubmit( out string aP0_UserCaption )
      {
         k2bgetusercaption objk2bgetusercaption;
         objk2bgetusercaption = new k2bgetusercaption();
         objk2bgetusercaption.AV8UserCaption = "" ;
         objk2bgetusercaption.context.SetSubmitInitialConfig(context);
         objk2bgetusercaption.initialize();
         Submit( executePrivateCatch,objk2bgetusercaption);
         aP0_UserCaption=this.AV8UserCaption;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusercaption)stateInfo).executePrivate();
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
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV9GAMErrors);
         AV8UserCaption = AV10GAMSession.gxTpr_User.gxTpr_Firstname + " " + AV10GAMSession.gxTpr_User.gxTpr_Lastname;
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
         AV8UserCaption = "";
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV9GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
      }

      private string AV8UserCaption ;
      private string aP0_UserCaption ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV10GAMSession ;
   }

}
