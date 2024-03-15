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
   public class updatecontextafterlogin : GXProcedure
   {
      public updatecontextafterlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public updatecontextafterlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         updatecontextafterlogin objupdatecontextafterlogin;
         objupdatecontextafterlogin = new updatecontextafterlogin();
         objupdatecontextafterlogin.context.SetSubmitInitialConfig(context);
         objupdatecontextafterlogin.initialize();
         Submit( executePrivateCatch,objupdatecontextafterlogin);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updatecontextafterlogin)stateInfo).executePrivate();
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
         AV8Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV10Errors);
         new k2bgetcontext(context ).execute( out  AV9Context) ;
         AV9Context.gxTpr_Usercode = AV8Session.gxTpr_User.gxTpr_Name;
         new k2bsetcontext(context ).execute(  AV9Context) ;
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
         AV8Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9Context = new SdtK2BContext(context);
         /* GeneXus formulas. */
      }

      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV8Session ;
      private SdtK2BContext AV9Context ;
   }

}
